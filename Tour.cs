public class Tour{



    public string engDesc { get; set; }
    public string nlDesc { get; set; }
    public List<string> Spots;
    public List<string> HasTakenTour;

    public Tour(string start,string end, List<string> spots, List<string> hastaken)
    {
        engDesc = $"{start} till {end}";
        nlDesc = $"{start} tot {end}";
        Spots = spots;
        HasTakenTour = hastaken;
    }

}