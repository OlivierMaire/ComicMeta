using SharpCompress.Archives.SevenZip;

namespace ComicMeta.Archivers;

public class SevenZipArchiver(string filePath) : IArchiver
{
    private readonly string FilePath = filePath;
    private SevenZipArchive? archive = null;

    public List<string> GetArchiveFilenameList()
    {
        archive ??= SevenZipArchive.Open(FilePath);
        return archive.Entries.Select(e => e.Key).ToList();
    }

    public string GetArchiveComment()
    {
        return string.Empty;
    }

    public Stream? ReadArchiveFileAsStream(string file)
    {
        archive ??= SevenZipArchive.Open(FilePath);
        return archive.Entries.FirstOrDefault(e => e.Key == file)?.OpenEntryStream();
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
        return SevenZipArchive.IsSevenZipFile(file);
    }
}