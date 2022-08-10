using System;
using System.Collections.Generic;
public class ApplicationContext {
    public const string Japanese = "Japanese";
    public const string English = "English";
    public const string Spanish = "Spanish";
    public string CultureKey{ get; set; } = String.Empty;
    public string Brand{ get; set; } = String.Empty;
    public List<Page> Pages{ get; set; } = new List<Page>();
    public List<string> Languages { get; set;} = new List<string>();
}
public class Page {
    public string ActionKey { get; set; } = String.Empty;
    public string Title { get; set; } = String.Empty;
    public List<Area> Areas { get;set; } = new List<Area>();
}
public class Area {
    public MovieValueObject MovieInfo {get; set;} = new MovieValueObject();
    public HomeContentsObject HomePageInfo {get; set;} = new HomeContentsObject();
    public PrivacyContentsObject PrivacyPageInfo {get; set;} = new PrivacyContentsObject();
    public string Title { get;set; } = String.Empty;
    public string Lead { get;set; } = String.Empty;
    public List<ControlLavel> ControlLavels = new List<ControlLavel>();
}
public record ControlLavel() {
    public string Key { get;set; } = String.Empty;
    public string Lavel { get;set; } = String.Empty;
}
public record MovieValueObject() {
    public string Date{ get; set;} = string.Empty;
    public string SlotStart{ get; set;} = string.Empty;
    public string SlotEnd{ get; set;} = string.Empty;
    public string MovieTitle{ get; set;} = string.Empty;
    public string ScreenNumber{ get; set;} = string.Empty;
}
public record HomeContentsObject() {
    DateTime UpDateTime { get; set;} = new DateTime();
    string Lead { get; set;} = string.Empty;
    string News { get; set;} = string.Empty;
    List<Area> wedgets { get; set;} = new List<Area>();
}

public record PrivacyContentsObject() {
    string Title { get; set;} = string.Empty;
    string Lead { get; set;} = string.Empty;
    string Policy { get; set;} = string.Empty;
    string Usage { get; set;} = string.Empty;
    string DisclosureRequest { get; set;} = string.Empty;
    string ReportPrivacyConcern { get; set;} = string.Empty;
}

// public class Japanese{
//     public string Brand{ get; set; } = String.Empty;
//     public List<Page> Pages{ get; set; } = new List<Page>();
// }

// public class English{
//     public string Brand{ get; set; } = String.Empty;
//     public List<Page> Pages{ get; set; } = new List<Page>();
// }

// record struct Japanese () {
//     string Brand{ get; init; } = String.Empty;
//     List<Page> Pages{ get; init; } = new List<Page>();
// }
// record struct English () {
//     string Brand{ get; init; } = String.Empty;
//     List<Page> Pages{ get; init; } = new List<Page>();
// }
// record struct Japanese (string Brand, List<Page> Pages);
// record struct English (string Brand, List<Page> Pages);
