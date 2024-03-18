public class Tour
{



    public string Start { get; set; }
    public string End { get; set; }
    public List<string> Spots;
    public List<string> HasTakenTour;

    public Tour(string start, string end, List<string> spots, List<string> hastaken)
    {
        Start = start;
        End = end;
        Spots = spots;
        HasTakenTour = hastaken;
    }
}