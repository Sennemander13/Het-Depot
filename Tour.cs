public class Tour
{


    public string Id { get; set; }
    public string Start { get; set; }
    public string End { get; set; }
    public List<string> Spots;
    public List<string> HasTakenTour;

    public Tour(int id, string start, string end, List<string> spots, List<string> hastaken)
    {
        Id = Convert.ToString(id);
        Start = start;
        End = end;
        Spots = spots;
        HasTakenTour = hastaken;
    }
}