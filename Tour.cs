public class Tour
{


    public int Id { get; set; }
    public string Start { get; set; }
    public string End { get; set; }
    public List<string> Spots;
    public List<string> HasTakenTour;

<<<<<<< HEAD
    public Tour(string start, string end, List<string> spots, List<string> hastaken)
=======
    public Tour(int id, string start, string end, List<string> spots, List<string> hastaken)
>>>>>>> dadac45739a9142314dd72b8eb84276b3c619978
    {
        Id = id;
        Start = start;
        End = end;
        Spots = spots;
        HasTakenTour = hastaken;
    }
}