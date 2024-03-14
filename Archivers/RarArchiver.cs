using ComicMeta.Metadata;
using SharpCompress.Archives.Rar;

namespace ComicMeta.Archivers;

public class RarArchiver(string filePath) : IArchiver

{
    private readonly string FilePath = filePath;
    private RarArchive? archive = null;

    public List<string> GetArchiveFilenameList()
    {
        archive ??= RarArchive.Open(FilePath);
        return archive.Entries.Select(e => e.Key).ToList();
    }
    
    public string GetArchiveComment()
    {
        archive ??= RarArchive.Open(FilePath);
        return archive.Volumes.First().Comment ?? string.Empty;
    }

    public Stream? ReadArchiveFileAsStream(string file)
    {
        archive ??= RarArchive.Open(FilePath);
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
        return RarArchive.IsRarFile(file);
    }
}