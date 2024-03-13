
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Serialization;
using ComicMeta.Metadata;

namespace ComicMeta.Formats;

public class CoMet
{

    public static bool ValidateString(string xml)
    {
        // remove faulty xml Declarations
        xml = Regex.Replace(xml, "\\<\\?xml version=\\\"\\d.?\\d?\\\".*\\?\\>", "");
 
        XmlDocument xmlDoc = new();
        if (xmlDoc == null) return false;
        xmlDoc.LoadXml(xml);
        return xmlDoc.DocumentElement?.Name == "comet";
    }

    public static GenericMetadata? GetMetadataFromString(string xml)
    {
        // remove faulty xml Declarations
        xml = Regex.Replace(xml, "\\<\\?xml version=\\\"\\d.?\\d?\\\".*\\?\\>", "");

        XmlDocument xmlDoc = new();
        if (xmlDoc == null) return null;
        xmlDoc.LoadXml(xml);

        if (xmlDoc.DocumentElement?.Name != "comet")
        {
            // Not a ComicInfo file
            return null;
        }

        XmlSerializer s = new(typeof(CoMetObject));
        StringReader rdr = new(xml);
        var comicInfo = s.Deserialize(rdr);

        if (comicInfo == null)
            return null;

        return CoMetToMetadataMapper((CoMetObject)comicInfo);
    }

    private static GenericMetadata? CoMetToMetadataMapper(CoMetObject comet)
    {
        GenericMetadata md = new GenericMetadata
        {
            Characters = comet.Character.ToArray(),
            Colorists = comet.Colorist.ToArray(),
            CoverArtists = comet.CoverDesigner.ToArray(),
            CoverImage = comet.CoverImage,
            Creators = comet.Creator.ToArray(),
            Year = comet.Date.Year,
            Month = comet.Date.Month,
            Day = comet.Date.Day,
            Summary = comet.Description,
            Editors = comet.Editor.ToArray(),
            Format = comet.Format,
            Genre = comet.Genre,
            Identifier = comet.Identifier,
            Inkers = comet.Inker.ToArray(),
            Issue = comet.Issue,
            IsVersionOf = comet.IsVersionOf,
            Language = comet.Language,
            LastMark = comet.LastMark,
            Letterers = comet.Letterer.ToArray(),
            PageCount = comet.Pages,
            Pencillers = comet.Penciller.ToArray(),
            Price = comet.Price,
            Publisher = comet.Publisher,
            MaturityRating = (Metadata.AgeRating)comet.Rating,
            Manga = comet.ReadingDirection == "rtl" ? Metadata.Manga.YesAndRightToLeft : Metadata.Manga.Unknown,
            Rights = comet.Rights,
            Series = comet.Series,
            Title = comet.Title,
            Volume = comet.Volume,
            Writers = comet.Writer.ToArray(),

            IsEmpty = false
        };

        return md;
    }

}

