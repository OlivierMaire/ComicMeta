

using System.Xml;
using System.Xml.Serialization;
using ComicMeta.Metadata;
using Microsoft.VisualBasic;

namespace ComicMeta.Formats;

public class ComicInfoXml
{

    private readonly static string[] writer_synonyms = ["writer", "plotter", "scripter"];
    private readonly static string[] penciller_synonyms = ["artist", "penciller", "penciler", "breakdowns"];
    private readonly static string[] inker_synonyms = ["inker", "artist", "finishes"];
    private readonly static string[] colorist_synonyms = ["colorist", "colourist", "colorer", "colourer"];
    private readonly static string[] letterer_synonyms = ["letterer"];
    private readonly static string[] cover_synonyms = ["cover", "covers", "coverartist", "cover artist"];
    private readonly static string[] editor_synonyms = ["editor"];


    public static GenericMetadata? GetMetadataFromString(string xml)
    {
        XmlDocument xmlDoc = new();
        if (xmlDoc == null) return null;
        xmlDoc.LoadXml(xml);

        if (xmlDoc.DocumentElement?.Name != "ComicInfo")
        {
            // Not a ComicInfo file
            return null;
        }

        XmlSerializer s = new(typeof(ComicInfo));
        StringReader rdr = new(xml);
        var comicInfo = s.Deserialize(rdr);

        if (comicInfo == null)
            return null;

        return ComicInfoXmlToMetadataMapper((ComicInfo)comicInfo);
    }

    private static GenericMetadata? ComicInfoXmlToMetadataMapper(ComicInfo comicInfo)
    {
        GenericMetadata md = new GenericMetadata
        {
            Series = comicInfo.Series,
            Title = comicInfo.Title,
            Issue = comicInfo.Number.TryParseToInt(),
            IssueCount = comicInfo.Count < 0 ? null : comicInfo.Count,
            Volume = comicInfo.Volume < 0 ? null : comicInfo.Volume,
            AlternateSeries = comicInfo.AlternateSeries,
            AlternateIssue = comicInfo.AlternateNumber.TryParseToInt(),
            AlternateIssueCount = comicInfo.AlternateCount < 0 ? null : comicInfo.AlternateCount,
            Summary = comicInfo.Summary,
            Notes = comicInfo.Notes,
            Year = comicInfo.Year < 0 ? null : comicInfo.Year,
            Month = comicInfo.Month < 0 ? null : comicInfo.Month,
            Day = comicInfo.Day < 0 ? null : comicInfo.Day,
            Publisher = comicInfo.Publisher,
            Imprint = comicInfo.Imprint,
            Genre = comicInfo.Genre,
            WebLink = comicInfo.Web,
            Language = comicInfo.LanguageISO,
            Format = comicInfo.Format,
            Manga = comicInfo.Manga switch
            {
                Manga.Unknown => Metadata.Manga.Unknown,
                Manga.No => Metadata.Manga.No,
                Manga.YesAndRightToLeft => Metadata.Manga.YesAndRightToLeft,
                Manga.Yes => Metadata.Manga.Yes,
                _ => Metadata.Manga.Unknown
            },
            Characters = comicInfo.Characters.Split(",", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries),
            Teams = comicInfo.Teams,
            Locations = comicInfo.Locations,
            PageCount = comicInfo.PageCount,
            ScanInfo = comicInfo.ScanInformation,
            StoryArc = comicInfo.StoryArc,
            SeriesGroup = comicInfo.SeriesGroup,
            MaturityRating = (Metadata.AgeRating)comicInfo.AgeRating,
            BlackAndWhite = comicInfo.BlackAndWhite switch
            {
                YesNo.Yes => true,
                YesNo.No => false,
                _ => null
            },
            Writers = comicInfo.Writer.Split(",", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries),
            Pencillers = comicInfo.Penciller.Split(",", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries),
            Inkers = comicInfo.Inker.Split(",", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries),
            Colorists = comicInfo.Colorist.Split(",", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries),
            Letterers = comicInfo.Letterer.Split(",", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries),
            Editors = comicInfo.Editor.Split(",", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries),
            CoverArtists = comicInfo.CoverArtist.Split(",", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries),
            Translators = comicInfo.Translator.Split(",", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries),

            Tags = comicInfo.Tags.Split(",", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries),

            Pages = comicInfo.Pages == null ? [] : comicInfo.Pages.Select(p => new GenericMetadata.PageInfo()
            {
                PageNumber = p.Image,
                PageType = p.Type switch
                {
                    ComicPageType.FrontCover => PageType.FrontCover,
                    ComicPageType.InnerCover => PageType.InnerCover,
                    ComicPageType.Roundup => PageType.Roundup,
                    ComicPageType.Story => PageType.Story,
                    ComicPageType.Advertisement => PageType.Advertisement,
                    ComicPageType.Editorial => PageType.Editorial,
                    ComicPageType.Letters => PageType.Letters,
                    ComicPageType.Preview => PageType.Preview,
                    ComicPageType.BackCover => PageType.BackCover,
                    ComicPageType.Other => PageType.Other,
                    ComicPageType.Deleted => PageType.Deleted,
                    _ => PageType.Unknown
                },
                DoublePage = p.DoublePage,
                ImageSize = p.ImageSize,
                Key = p.Key,
                Bookmark = p.Bookmark,
                ImageWidth = p.ImageWidth < 0 ? null : (uint)p.ImageWidth,
                ImageHeight = p.ImageHeight < 0 ? null : (uint)p.ImageHeight

            }).ToArray(),
            IsEmpty = false
        };

        return md;
    }

}


public static class XmlExtensions
{
    public static int? TryParseToInt(this string? str)
    {
        if (decimal.TryParse(str, System.Globalization.CultureInfo.InvariantCulture , out var myInt))
            return (int)myInt;
        return null;
    }
}