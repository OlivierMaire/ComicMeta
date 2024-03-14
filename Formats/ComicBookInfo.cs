
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Nodes;
using ComicMeta.Metadata;

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
        catch
        {
            return false;
        }
    }

    public static GenericMetadata GetMetadataFromString(string comment)
    {
        var comicInfo = JsonSerializer.Deserialize<ComicBookInfoRoot>(comment);

        GenericMetadata md = new GenericMetadata
        {
            Summary = comicInfo?.ComicBookInfo?.Comments,
            Country = comicInfo?.ComicBookInfo?.Country,
            Writers = comicInfo?.ComicBookInfo?.Credits == null ? [] : comicInfo.ComicBookInfo.Credits.Where(c => c.Role == "Writer" && !string.IsNullOrEmpty(c.Person)).Select(c => c.Person ?? string.Empty).ToArray(),
            Pencillers = comicInfo?.ComicBookInfo?.Credits == null ? [] : comicInfo.ComicBookInfo.Credits.Where(c => c.Role == "Artist" && !string.IsNullOrEmpty(c.Person)).Select(c => c.Person ?? string.Empty).ToArray(),
            Letterers = comicInfo?.ComicBookInfo?.Credits == null ? [] : comicInfo.ComicBookInfo.Credits.Where(c => c.Role == "Letterer" && !string.IsNullOrEmpty(c.Person)).Select(c => c.Person ?? string.Empty).ToArray(),
            Colorists = comicInfo?.ComicBookInfo?.Credits == null ? [] : comicInfo.ComicBookInfo.Credits.Where(c => c.Role == "Colorer" && !string.IsNullOrEmpty(c.Person)).Select(c => c.Person ?? string.Empty).ToArray(),
            Editors = comicInfo?.ComicBookInfo?.Credits == null ? [] : comicInfo.ComicBookInfo.Credits.Where(c => c.Role == "Editor" && !string.IsNullOrEmpty(c.Person)).Select(c => c.Person ?? string.Empty).ToArray(),
            Genre = comicInfo?.ComicBookInfo?.Genre,
            Issue = (int?)comicInfo?.ComicBookInfo?.Issue,
            Language = comicInfo?.ComicBookInfo?.Language == null ? null :
                CultureInfo.GetCultures(CultureTypes.AllCultures).FirstOrDefault(ci => ci.EnglishName == comicInfo?.ComicBookInfo?.Language)?.TwoLetterISOLanguageName ?? comicInfo?.ComicBookInfo?.Language,
            IssueCount = comicInfo?.ComicBookInfo?.NumberOfIssues,
            VolumeCount = comicInfo?.ComicBookInfo?.NumberOfVolumes,
            Month = comicInfo?.ComicBookInfo?.PublicationMonth,
            Year = comicInfo?.ComicBookInfo?.PublicationYear,
            Publisher = comicInfo?.ComicBookInfo?.Publisher,
            CommunityRating = comicInfo?.ComicBookInfo?.Rating.ToString(),
            Series = comicInfo?.ComicBookInfo?.Series,
            Tags = comicInfo?.ComicBookInfo?.Tags?.ToArray() ?? [],
            Title = comicInfo?.ComicBookInfo?.Title,
            Volume = comicInfo?.ComicBookInfo?.Volume,
            IsEmpty = false
        };

        return md;
    }

}