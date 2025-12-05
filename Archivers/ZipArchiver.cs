
using System.IO.Compression;

namespace ComicMeta.Archivers;

public class ZipArchiver(string filePath) : IArchiver

{
    private readonly string FilePath = filePath;
    private ZipArchive? archive = null;

    public List<string> GetArchiveFilenameList()
    {
        archive ??= ZipFile.OpenRead(FilePath);
        return archive.Entries.Select(e => e.FullName).ToList();
    }

    public string GetArchiveComment()
    {
        archive ??= ZipFile.OpenRead(FilePath);
        return archive.Comment;
    }

    public Stream? ReadArchiveFileAsStream(string file)
    {
        archive ??= ZipFile.OpenRead(FilePath);
        return archive.GetEntry(file)?.Open();

    }

    public string ReadArchiveFileAsString(string file)
    {
        using var stream = ReadArchiveFileAsStream(file);
        if (stream == null)
            return string.Empty;
        using var sr = new StreamReader(stream);
        return sr.ReadToEnd();
    }

    public void Dispose()
    {
        if (archive != null)
            archive.Dispose();
    }

    public static bool IsValidArchive(string file)
    {
        try
        {
            using (var zipFile = ZipFile.OpenRead(file))
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
}