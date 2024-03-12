namespace ComicMeta.Archivers;

public interface IArchiver{

    List<string> GetArchiveFilenameList();

    string GetArchiveComment();
    Stream? ReadArchiveFileAsStream(string file);
    string ReadArchiveFileAsString(string file);
}