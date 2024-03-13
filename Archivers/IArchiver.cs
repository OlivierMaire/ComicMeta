namespace ComicMeta.Archivers;

public interface IArchiver: IDisposable{

    List<string> GetArchiveFilenameList();

    string GetArchiveComment();
    Stream? ReadArchiveFileAsStream(string file);
    string ReadArchiveFileAsString(string file);
}