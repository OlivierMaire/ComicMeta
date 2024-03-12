using System.IO.Compression;
using ComicMeta.Archivers;
using ComicMeta.Formats;

namespace ComicMeta;


public class ComicArchive
{
    private readonly string FilePath;
    private readonly string FileExt;
    private readonly IArchiver Archiver;

    private const string ci_xml_filename = "ComicInfo.xml";
    private const string comet_default_filename = "CoMet.xml";
    private string comet_filename = string.Empty;

    private uint? _pageCount = null;
    private uint PageCount => _pageCount ??= (uint)this.PageList.Count;


    private List<string>? _pageList = null;
    private List<string> PageList => _pageList ??= this.Archiver.GetArchiveFilenameList();

    private bool? _hasCIX = null;
    private bool HasCIX => _hasCIX ??= HasCIXFile();
    private bool? _hasCBI = null;
    private bool HasCBI => _hasCBI ??= HasCBIFile();
    private bool? _hasCoMet = null;
    private bool HasCoMet => _hasCoMet ??= HasCoMetFile();

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
        foreach (var file in this.PageList)
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

        if (this.PageList.Contains(ci_xml_filename))
        {
            return true;
        }

        return false;
    }

    public enum MetadataStyle
    {
        CBI = 0, //ComicBookLover
        CIX = 1, // ComicRack
        COMET = 2 // CoMet
    }

}
