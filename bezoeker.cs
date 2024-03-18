public class Bezoeker
{
    static void main()
    {
        Console.Write("Choose a timeslot: ");
        string tour_choice = Console.ReadLine();
    }
    public static void displa()
    {
        Console.WriteLine("--------------------");
        foreach (Tour tour in Tours.tours)
        {
            Console.WriteLine($"{tour.Start} - {tour.End}");
        }
        Console.WriteLine("--------------------");
        main();
    }
}
