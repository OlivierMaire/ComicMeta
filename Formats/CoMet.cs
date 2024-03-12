
using System.Xml;

namespace ComicMeta.Formats;

public class CoMet
{

    public static bool ValidateString(string xml)
    {
        XmlDocument xmlDoc = new();
        if (xmlDoc == null) return false;
        xmlDoc.LoadXml(xml);
        return xmlDoc.DocumentElement?.Name == "comet";
    }



}