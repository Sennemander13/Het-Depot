using System.Text.Json.Serialization;

public class Tour
{
    public string Id { get; set; }
    public string Start { get; set; }
    public string End { get; set; }
    public List<string> Spots {get; set;}
    public List<string> HasTakenTour {get; set;}
    public string GuideCode {get; set;}

    public Tour(string id, string start, string end, List<string> spots, List<string> hastakentour)
    {
        Id = id;
        Start = start;
        End = end;
        Spots = spots ?? new List<string>(); // Default to empty list if null
        HasTakenTour = hastakentour ?? new List<string>(); // Default to empty list if null
        GuideCode = "";
    }
}