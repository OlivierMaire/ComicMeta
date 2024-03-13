using System.IO.Compression;
using ComicMeta.Archivers;
using ComicMeta.Formats;
using ComicMeta.Metadata;

namespace ComicMeta;


public class ComicArchive : IDisposable
{
    private readonly string FilePath;
    private readonly string FileExt;
    private readonly IArchiver Archiver;

    private const string ci_xml_filename = "ComicInfo.xml";
    private const string comet_default_filename = "CoMet.xml";
    private string comet_filename = string.Empty;

    private uint? _pageCount = null;
    private uint PageCount => _pageCount ??= (uint)this.PageList.Count;


    private List<string>? _fileList = null;
    private List<string> FileList => _fileList ??= this.Archiver.GetArchiveFilenameList();

    private List<string>? _pageList = null;
    private List<string> PageList => _pageList ??= this.GetPageList();


    private bool? _isComicArchive = null;
    public bool IsComicArchive => _isComicArchive ??= IsFileComicArchive();



    public ComicArchive(string filePath)
    {
        FilePath = filePath;
        FileExt = Path.GetExtension(filePath);

        if (FileExt == ".cbr" || FileExt == ".rar")
        {
            // rar extracting

        }
        else if (FileExt == ".cbz")
        {
            if (IsZipArchive(filePath))
            {
                Archiver = new ZipArchiver(filePath);
            }
            else
            {
                // test rar method
            }
            //    archive.Entries[0].
        }
        else
        {
            // unsuported Extension
            throw new Exception("Unknown Archive format.");
        }
    }

    private bool IsZipArchive(string path)
    {

        try
        {
            using (var zipFile = ZipFile.OpenRead(path))
            {
                var entries = zipFile.Entries;
                return true;
            }
        }
        catch (InvalidDataException)
        {
            return false;
        }
    }

    public bool IsFileComicArchive()
    {
        if (IsZipArchive(FilePath)
        // || rar || pdf
        )
        {
            if (PageCount > 0)
            {
                _isComicArchive = true;
                return true;
            }
        }
        _isComicArchive = false;
        return false;
    }

    private static string[] VALID_IMAGE_EXT = [".jpg", "jpeg", ".png", ".gif", ".webp"];
    public List<string> GetPageList()
    {
        return FileList.Where(f => VALID_IMAGE_EXT.Contains(Path.GetExtension(f).ToLower()))
            .Where(f => !f.StartsWith('.')).ToList();
    }


    #region HasMetadata
    private bool? _hasCIX = null;
    private bool HasCIX => _hasCIX ??= HasCIXFile();
    private bool? _hasCBI = null;
    private bool HasCBI => _hasCBI ??= HasCBIFile();
    private bool? _hasCoMet = null;
    private bool HasCoMet => _hasCoMet ??= HasCoMetFile();

    public bool HasMetadata(MetadataStyle style)
    {
        return style switch
        {
            MetadataStyle.CIX => HasCIX,
            MetadataStyle.CBI => HasCBI,
            MetadataStyle.COMET => HasCoMet,
            _ => false
        };
    }

    private bool HasCoMetFile()
    {
        if (!this.IsComicArchive)
            return false;
        foreach (var file in this.FileList)
        {
            if (Path.GetDirectoryName(file) == "" && Path.GetExtension(file).ToLower() == ".xml")
            {
                // found an xml file at root folder
                var content = Archiver.ReadArchiveFileAsString(file);
                if (!String.IsNullOrEmpty(content))
                {
                    if (CoMet.ValidateString(content))
                    {
                        comet_filename = file;
                        return true;
                    }
                }
            }
        }
        return false;
    }

    private bool HasCBIFile()
    {
        if (!this.IsComicArchive)
            return false;

        var comment = Archiver.GetArchiveComment();
        return ComicBookInfo.ValidateString(comment);
    }

    private bool HasCIXFile()
    {
        if (!this.IsComicArchive)
            return false;

        if (this.FileList.Contains(ci_xml_filename))
        {
            return true;
        }

        return false;
    }

    #endregion

    #region ReadMetadata


    private GenericMetadata? _cix_metadata = null;
    private GenericMetadata CIXMetadata => _cix_metadata ??= ReadCIX();
    private GenericMetadata? _cbi_metadata = null;
    private GenericMetadata CBIMetadata => _cbi_metadata ??= ReadCBI();

    private GenericMetadata? _comet_metadata = null;
    private GenericMetadata CoMetMetadata => _comet_metadata ??= ReadCoMet();

    public GenericMetadata ReadMetadata(MetadataStyle style)
    {
        var meta = style switch
        {
            MetadataStyle.CIX => CIXMetadata,
            MetadataStyle.CBI => CBIMetadata,
            MetadataStyle.COMET => CoMetMetadata,
            _ => new GenericMetadata()
        };

        if (meta.Pages.Length == 0)
            meta.Pages = GenerateDefaultPages();
        if (!string.IsNullOrEmpty(meta.CoverImage))
        {
            var coverPage = meta.Pages.FirstOrDefault(p => p.Key == meta.CoverImage);
            if (coverPage != null)
            {
                meta.Pages[0].PageType = PageType.Unknown;
                coverPage.PageType = PageType.FrontCover;
            }
        }

        if (meta.PageCount == null || meta.PageCount == 0)
            meta.PageCount = meta.Pages.Length;

        return meta;
    }

    private GenericMetadata.PageInfo[] GenerateDefaultPages()
    {
        return PageList.Select((p, i) => new GenericMetadata.PageInfo
        {
            PageNumber = i+1,
            Key = p,
            PageType = i == 0 ? PageType.FrontCover : PageType.Unknown
        }).ToArray();
    }

    private GenericMetadata ReadCIX()
    {
        if (!HasCIX) return new GenericMetadata();
        var rawCIX = Archiver.ReadArchiveFileAsString(ci_xml_filename);
        GenericMetadata? meta = null;
        if (!string.IsNullOrEmpty(rawCIX))
            meta = ComicInfoXml.GetMetadataFromString(rawCIX);
        if (meta == null)
            meta = new GenericMetadata();

        // validate page nb
        if (meta.Pages.Count() != this.PageCount)
        {
            // pages array doesn't match the actual number of images we're seeing
            // in the archive, so discard the data
            meta.Pages = [];
        }
        return meta;
    }


    private GenericMetadata ReadCBI()
    {
        if (!HasCBI) return new GenericMetadata();
        var rawCBI = Archiver.GetArchiveComment();
        GenericMetadata? meta = null;
        if (!string.IsNullOrEmpty(rawCBI))
            meta = ComicBookInfo.GetMetadataFromString(rawCBI);
        if (meta == null)
            meta = new GenericMetadata();

        // validate page nb
        if (meta.Pages.Count() != this.PageCount)
        {
            // pages array doesn't match the actual number of images we're seeing
            // in the archive, so discard the data
            meta.Pages = [];
        }
        return meta;
    }

    private GenericMetadata ReadCoMet()
    {
        if (!HasCoMet) return new GenericMetadata();
        var rawCoMet = Archiver.ReadArchiveFileAsString(comet_filename);
        GenericMetadata? meta = null;
        if (!string.IsNullOrEmpty(rawCoMet))
            meta = CoMet.GetMetadataFromString(rawCoMet);
        if (meta == null)
            meta = new GenericMetadata();

        // validate page nb
        if (meta.Pages.Count() != this.PageCount)
        {
            // pages array doesn't match the actual number of images we're seeing
            // in the archive, so discard the data
            meta.Pages = [];
        }
        return meta;
    }



    #endregion
    public void Dispose()
    {
        Archiver?.Dispose();
    }
    public enum MetadataStyle
    {
        CBI = 0, //ComicBookLover
        CIX = 1, // ComicRack
        COMET = 2 // CoMet
    }

}
