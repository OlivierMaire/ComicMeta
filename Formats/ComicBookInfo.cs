
using System.Text.Json.Nodes;

namespace ComicMeta.Formats;

public class ComicBookInfo
{

    public static bool ValidateString(string comment)
    {
        try
        {
            var cbi_container = JsonObject.Parse(comment);
            if (cbi_container == null)
                return false;
            return cbi_container.AsObject().ContainsKey("ComicBookInfo/1.0");
        }
        catch{
            return false;
        }
    }

}