namespace ComicMeta.Formats;

// using System.Xml.Serialization;
// XmlSerializer serializer = new XmlSerializer(typeof(Comet));
// using (StringReader reader = new StringReader(xml))
// {
//    var test = (Comet)serializer.Deserialize(reader);
// }

using System.Xml.Serialization;

[XmlRoot(ElementName = "comet")]
public class CoMetObject
{

    [XmlElement(ElementName = "title")]
    public string Title { get; set; } = string.Empty;

    [XmlElement(ElementName = "description")]
    public string Description { get; set; } = string.Empty;

    [XmlElement(ElementName = "series")]
    public string Series { get; set; } = string.Empty;

    [XmlElement(ElementName = "issue")]
    public int Issue { get; set; }

    [XmlElement(ElementName = "volume")]
    public int Volume { get; set; }

    [XmlElement(ElementName = "publisher")]
    public string Publisher { get; set; } = string.Empty;

    [XmlElement(ElementName = "date")]
    public DateTime Date { get; set; }

    [XmlElement(ElementName = "genre")]
    public string Genre { get; set; } = string.Empty;

    [XmlElement(ElementName = "character")]
    public List<string> Character { get; set; } = [];

    [XmlElement(ElementName = "isVersionOf")]
    public string IsVersionOf { get; set; } = string.Empty;

    [XmlElement(ElementName = "price")]
    public double Price { get; set; }

    [XmlElement(ElementName = "format")]
    public string Format { get; set; } = string.Empty;

    [XmlElement(ElementName = "language")]
    public string Language { get; set; } = string.Empty;

    [XmlElement(ElementName = "rating")]
    public AgeRating Rating { get; set; }

    [XmlElement(ElementName = "rights")]
    public string Rights { get; set; } = string.Empty;

    [XmlElement(ElementName = "identifier")]
    public string Identifier { get; set; } = string.Empty;

    [XmlElement(ElementName = "pages")]
    public int Pages { get; set; }

    [XmlElement(ElementName = "creator")]
    public List<string> Creator { get; set; } = [];

    [XmlElement(ElementName = "writer")]
    public List<string> Writer { get; set; } = [];

    [XmlElement(ElementName = "penciller")]
    public List<string> Penciller { get; set; } = [];

    [XmlElement(ElementName = "editor")]
    public List<string> Editor { get; set; } = [];

    [XmlElement(ElementName = "coverDesigner")]
    public List<string> CoverDesigner { get; set; } = [];

    [XmlElement(ElementName = "letterer")]
    public List<string> Letterer { get; set; } = [];

    [XmlElement(ElementName = "inker")]
    public List<string> Inker { get; set; } = [];

    [XmlElement(ElementName = "colorist")]
    public List<string> Colorist { get; set; } = [];

    [XmlElement(ElementName = "coverImage")]
    public string CoverImage { get; set; } = string.Empty;

    [XmlElement(ElementName = "lastMark")]
    public int LastMark { get; set; }

    [XmlElement(ElementName = "readingDirection")]
    public string ReadingDirection { get; set; } = string.Empty;


    /// <remarks/>
    public enum AgeRating
    {

        /// <remarks/>
        Unknown,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Adults Only 18+")]
        AdultsOnly18,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Early Childhood")]
        EarlyChildhood,

        /// <remarks/>
        Everyone,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Everyone 10+")]
        Everyone10,

        /// <remarks/>
        G,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Kids to Adults")]
        KidstoAdults,

        /// <remarks/>
        M,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("MA15+")]
        MA15,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Mature 17+")]
        Mature17,

        /// <remarks/>
        PG,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("R18+")]
        R18,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("Rating Pending")]
        RatingPending,

        /// <remarks/>
        Teen,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("X18+")]
        X18,
    }

}

