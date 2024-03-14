using ComicMeta.Metadata;
using SharpCompress.Archives.Rar;

namespace ComicMeta.Archivers;

public class PdfArchiver(string filePath) : IArchiver

{
    private readonly string FilePath = filePath;


    public void Dispose()
    {
    }

    public string GetArchiveComment()
    {
        return string.Empty;
    }

    public List<string> GetArchiveFilenameList()
    {
        using var fileStream = File.Open(FilePath, FileMode.Open);
#pragma warning disable CA1416 // Validate platform compatibility
        var pageCount = PDFtoImage.Conversion.GetPageCount(fileStream);
#pragma warning restore CA1416 // Validate platform compatibility
        List<string> FileList = new();
        for (int i = 1; i <= pageCount; i++)
        {
            FileList.Add($"{i:000}.jpeg");
        }
        return FileList;
    }

    public Stream? ReadArchiveFileAsStream(string file)
    {
        if (int.TryParse(file.Replace(".jpeg", ""), System.Globalization.CultureInfo.InvariantCulture, out var page))
        {
            using var fileStream = File.Open(FilePath, FileMode.Open);
            MemoryStream imageStream = new();
#pragma warning disable CA1416 // Validate platform compatibility
            PDFtoImage.Conversion.SaveJpeg(imageStream, fileStream, page: page);
#pragma warning restore CA1416 // Validate platform compatibility
            imageStream.Seek(0, SeekOrigin.Begin);
            return imageStream;
        }
        else
            return null;
    }

    public string ReadArchiveFileAsString(string file)
    {
        throw new NotImplementedException();
    }

    public static bool IsValidArchive(string file)
    {
        return Path.GetExtension(file) == ".pdf";
    }
}