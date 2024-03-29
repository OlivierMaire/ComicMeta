namespace ComicMeta.Formats {
    
    
    /// <remarks/>
    public partial class ComicInfo {
        
        private string titleField;
        
        private string seriesField;
        
        private string numberField;
        
        private int countField;
        
        private int volumeField;
        
        private string alternateSeriesField;
        
        private string alternateNumberField;
        
        private int alternateCountField;
        
        private string summaryField;
        
        private string notesField;
        
        private int yearField;
        
        private int monthField;
        
        private int dayField;
        
        private string writerField;
        
        private string pencillerField;
        
        private string inkerField;
        
        private string coloristField;
        
        private string lettererField;
        
        private string coverArtistField;
        
        private string editorField;
        
        private string translatorField;
        
        private string publisherField;
        
        private string imprintField;
        
        private string genreField;
        
        private string tagsField;
        
        private string webField;
        
        private int pageCountField;
        
        private string languageISOField;
        
        private string formatField;
        
        private YesNo blackAndWhiteField;
        
        private Manga mangaField;
        
        private string charactersField;
        
        private string teamsField;
        
        private string locationsField;
        
        private string scanInformationField;
        
        private string storyArcField;
        
        private string storyArcNumberField;
        
        private string seriesGroupField;
        
        private AgeRating ageRatingField;
        
        private ComicPageInfo[] pagesField;
        
        private decimal communityRatingField;
        
        private bool communityRatingFieldSpecified;
        
        private string mainCharacterOrTeamField;
        
        private string reviewField;
        
        private string gTINField;
        
        public ComicInfo() {
            this.titleField = "";
            this.seriesField = "";
            this.numberField = "";
            this.countField = -1;
            this.volumeField = -1;
            this.alternateSeriesField = "";
            this.alternateNumberField = "";
            this.alternateCountField = -1;
            this.summaryField = "";
            this.notesField = "";
            this.yearField = -1;
            this.monthField = -1;
            this.dayField = -1;
            this.writerField = "";
            this.pencillerField = "";
            this.inkerField = "";
            this.coloristField = "";
            this.lettererField = "";
            this.coverArtistField = "";
            this.editorField = "";
            this.translatorField = "";
            this.publisherField = "";
            this.imprintField = "";
            this.genreField = "";
            this.tagsField = "";
            this.webField = "";
            this.pageCountField = 0;
            this.languageISOField = "";
            this.formatField = "";
            this.blackAndWhiteField = YesNo.Unknown;
            this.mangaField = Manga.Unknown;
            this.charactersField = "";
            this.teamsField = "";
            this.locationsField = "";
            this.scanInformationField = "";
            this.storyArcField = "";
            this.storyArcNumberField = "";
            this.seriesGroupField = "";
            this.ageRatingField = AgeRating.Unknown;
            this.mainCharacterOrTeamField = "";
            this.reviewField = "";
            this.gTINField = "";
            this.pagesField = [];
        }
        
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute("")]
        public string Title {
            get {
                return this.titleField;
            }
            set {
                this.titleField = value;
            }
        }
        
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute("")]
        public string Series {
            get {
                return this.seriesField;
            }
            set {
                this.seriesField = value;
            }
        }
        
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute("")]
        public string Number {
            get {
                return this.numberField;
            }
            set {
                this.numberField = value;
            }
        }
        
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute(-1)]
        public int Count {
            get {
                return this.countField;
            }
            set {
                this.countField = value;
            }
        }
        
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute(-1)]
        public int Volume {
            get {
                return this.volumeField;
            }
            set {
                this.volumeField = value;
            }
        }
        
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute("")]
        public string AlternateSeries {
            get {
                return this.alternateSeriesField;
            }
            set {
                this.alternateSeriesField = value;
            }
        }
        
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute("")]
        public string AlternateNumber {
            get {
                return this.alternateNumberField;
            }
            set {
                this.alternateNumberField = value;
            }
        }
        
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute(-1)]
        public int AlternateCount {
            get {
                return this.alternateCountField;
            }
            set {
                this.alternateCountField = value;
            }
        }
        
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute("")]
        public string Summary {
            get {
                return this.summaryField;
            }
            set {
                this.summaryField = value;
            }
        }
        
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute("")]
        public string Notes {
            get {
                return this.notesField;
            }
            set {
                this.notesField = value;
            }
        }
        
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute(-1)]
        public int Year {
            get {
                return this.yearField;
            }
            set {
                this.yearField = value;
            }
        }
        
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute(-1)]
        public int Month {
            get {
                return this.monthField;
            }
            set {
                this.monthField = value;
            }
        }
        
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute(-1)]
        public int Day {
            get {
                return this.dayField;
            }
            set {
                this.dayField = value;
            }
        }
        
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute("")]
        public string Writer {
            get {
                return this.writerField;
            }
            set {
                this.writerField = value;
            }
        }
        
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute("")]
        public string Penciller {
            get {
                return this.pencillerField;
            }
            set {
                this.pencillerField = value;
            }
        }
        
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute("")]
        public string Inker {
            get {
                return this.inkerField;
            }
            set {
                this.inkerField = value;
            }
        }
        
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute("")]
        public string Colorist {
            get {
                return this.coloristField;
            }
            set {
                this.coloristField = value;
            }
        }
        
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute("")]
        public string Letterer {
            get {
                return this.lettererField;
            }
            set {
                this.lettererField = value;
            }
        }
        
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute("")]
        public string CoverArtist {
            get {
                return this.coverArtistField;
            }
            set {
                this.coverArtistField = value;
            }
        }
        
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute("")]
        public string Editor {
            get {
                return this.editorField;
            }
            set {
                this.editorField = value;
            }
        }
        
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute("")]
        public string Translator {
            get {
                return this.translatorField;
            }
            set {
                this.translatorField = value;
            }
        }
        
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute("")]
        public string Publisher {
            get {
                return this.publisherField;
            }
            set {
                this.publisherField = value;
            }
        }
        
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute("")]
        public string Imprint {
            get {
                return this.imprintField;
            }
            set {
                this.imprintField = value;
            }
        }
        
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute("")]
        public string Genre {
            get {
                return this.genreField;
            }
            set {
                this.genreField = value;
            }
        }
        
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute("")]
        public string Tags {
            get {
                return this.tagsField;
            }
            set {
                this.tagsField = value;
            }
        }
        
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute("")]
        public string Web {
            get {
                return this.webField;
            }
            set {
                this.webField = value;
            }
        }
        
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute(0)]
        public int PageCount {
            get {
                return this.pageCountField;
            }
            set {
                this.pageCountField = value;
            }
        }
        
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute("")]
        public string LanguageISO {
            get {
                return this.languageISOField;
            }
            set {
                this.languageISOField = value;
            }
        }
        
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute("")]
        public string Format {
            get {
                return this.formatField;
            }
            set {
                this.formatField = value;
            }
        }
        
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute(YesNo.Unknown)]
        public YesNo BlackAndWhite {
            get {
                return this.blackAndWhiteField;
            }
            set {
                this.blackAndWhiteField = value;
            }
        }
        
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute(Manga.Unknown)]
        public Manga Manga {
            get {
                return this.mangaField;
            }
            set {
                this.mangaField = value;
            }
        }
        
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute("")]
        public string Characters {
            get {
                return this.charactersField;
            }
            set {
                this.charactersField = value;
            }
        }
        
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute("")]
        public string Teams {
            get {
                return this.teamsField;
            }
            set {
                this.teamsField = value;
            }
        }
        
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute("")]
        public string Locations {
            get {
                return this.locationsField;
            }
            set {
                this.locationsField = value;
            }
        }
        
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute("")]
        public string ScanInformation {
            get {
                return this.scanInformationField;
            }
            set {
                this.scanInformationField = value;
            }
        }
        
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute("")]
        public string StoryArc {
            get {
                return this.storyArcField;
            }
            set {
                this.storyArcField = value;
            }
        }
        
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute("")]
        public string StoryArcNumber {
            get {
                return this.storyArcNumberField;
            }
            set {
                this.storyArcNumberField = value;
            }
        }
        
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute("")]
        public string SeriesGroup {
            get {
                return this.seriesGroupField;
            }
            set {
                this.seriesGroupField = value;
            }
        }
        
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute(AgeRating.Unknown)]
        public AgeRating AgeRating {
            get {
                return this.ageRatingField;
            }
            set {
                this.ageRatingField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Page")]
        public ComicPageInfo[] Pages {
            get {
                return this.pagesField;
            }
            set {
                this.pagesField = value;
            }
        }
        
        /// <remarks/>
        public decimal CommunityRating {
            get {
                return this.communityRatingField;
            }
            set {
                this.communityRatingField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CommunityRatingSpecified {
            get {
                return this.communityRatingFieldSpecified;
            }
            set {
                this.communityRatingFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute("")]
        public string MainCharacterOrTeam {
            get {
                return this.mainCharacterOrTeamField;
            }
            set {
                this.mainCharacterOrTeamField = value;
            }
        }
        
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute("")]
        public string Review {
            get {
                return this.reviewField;
            }
            set {
                this.reviewField = value;
            }
        }
        
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute("")]
        public string GTIN {
            get {
                return this.gTINField;
            }
            set {
                this.gTINField = value;
            }
        }
    }
    
    /// <remarks/>
    public enum YesNo {
        
        /// <remarks/>
        Unknown,
        
        /// <remarks/>
        No,
        
        /// <remarks/>
        Yes,
    }
    
    /// <remarks/>
    public enum Manga {
        
        /// <remarks/>
        Unknown,
        
        /// <remarks/>
        No,
        
        /// <remarks/>
        Yes,
        
        /// <remarks/>
        YesAndRightToLeft,
    }
    
    /// <remarks/>
    public enum AgeRating {
        
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
    
    /// <remarks/>
    public partial class ComicPageInfo {
        
        private int imageField;
        
        private ComicPageType typeField;
        
        private bool doublePageField;
        
        private long imageSizeField;
        
        private string keyField;
        
        private string bookmarkField;
        
        private int imageWidthField;
        
        private int imageHeightField;
        
        public ComicPageInfo() {
            this.typeField = ComicPageType.Story;
            this.doublePageField = false;
            this.imageSizeField = ((long)(0));
            this.keyField = "";
            this.bookmarkField = "";
            this.imageWidthField = -1;
            this.imageHeightField = -1;
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int Image {
            get {
                return this.imageField;
            }
            set {
                this.imageField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(ComicPageType.Story)]
        public ComicPageType Type {
            get {
                return this.typeField;
            }
            set {
                this.typeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(false)]
        public bool DoublePage {
            get {
                return this.doublePageField;
            }
            set {
                this.doublePageField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(typeof(long), "0")]
        public long ImageSize {
            get {
                return this.imageSizeField;
            }
            set {
                this.imageSizeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute("")]
        public string Key {
            get {
                return this.keyField;
            }
            set {
                this.keyField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute("")]
        public string Bookmark {
            get {
                return this.bookmarkField;
            }
            set {
                this.bookmarkField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(-1)]
        public int ImageWidth {
            get {
                return this.imageWidthField;
            }
            set {
                this.imageWidthField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(-1)]
        public int ImageHeight {
            get {
                return this.imageHeightField;
            }
            set {
                this.imageHeightField = value;
            }
        }
    }
    
    /// <remarks/>
    public enum ComicPageType {
        
        /// <remarks/>
        FrontCover = 1,
        
        /// <remarks/>
        InnerCover = 2,
        
        /// <remarks/>
        Roundup = 4,
        
        /// <remarks/>
        Story = 8,
        
        /// <remarks/>
        Advertisement = 16,
        
        /// <remarks/>
        Editorial = 32,
        
        /// <remarks/>
        Letters = 64,
        
        /// <remarks/>
        Preview = 128,
        
        /// <remarks/>
        BackCover = 256,
        
        /// <remarks/>
        Other = 512,
        
        /// <remarks/>
        Deleted = 1024,
    }
    
    /// <remarks/>
    public partial class ArrayOfComicPageInfo {
        
        private ComicPageInfo[] pageField = [];
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Page", IsNullable=true)]
        public ComicPageInfo[] Page {
            get {
                return this.pageField;
            }
            set {
                this.pageField = value;
            }
        }
    }
}