using System.Text.Json.Serialization;

namespace ComicMeta.Formats;


// Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
public class ComicBookInfoObject
{
    [JsonPropertyName("series")]
    public string? Series { get; set; }

    [JsonPropertyName("title")]
    public string? Title { get; set; }

    [JsonPropertyName("publisher")]
    public string? Publisher { get; set; }

    [JsonPropertyName("publicationMonth")]
    public int PublicationMonth { get; set; }

    [JsonPropertyName("publicationYear")]
    public int PublicationYear { get; set; }

    [JsonPropertyName("issue")]
    public decimal Issue { get; set; }

    [JsonPropertyName("numberOfIssues")]
    public int NumberOfIssues { get; set; }

    [JsonPropertyName("volume")]
    public int Volume { get; set; }

    [JsonPropertyName("numberOfVolumes")]
    public int NumberOfVolumes { get; set; }

    [JsonPropertyName("rating")]
    public int Rating { get; set; }

    [JsonPropertyName("genre")]
    public string? Genre { get; set; }

    [JsonPropertyName("language")]
    public string? Language { get; set; }

    [JsonPropertyName("country")]
    public string? Country { get; set; }

    [JsonPropertyName("credits")]
    public List<Credit>? Credits { get; set; }

    [JsonPropertyName("tags")]
    public List<string>? Tags { get; set; }

    [JsonPropertyName("comments")]
    public string? Comments { get; set; }

    public class Credit
    {
        [JsonPropertyName("person")]
        public string? Person { get; set; }

        [JsonPropertyName("role")]
        public string? Role { get; set; }

        [JsonPropertyName("primary")]
        public string? Primary { get; set; }
    }

}

public class ComicBookInfoRoot
{
    [JsonPropertyName("appID")]
    public string? AppID { get; set; }

    [JsonPropertyName("lastModified")]
    public string? LastModified { get; set; }

    [JsonPropertyName("ComicBookInfo/1.0")]
    public ComicBookInfoObject? ComicBookInfo { get; set; }
}

