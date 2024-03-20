using Newtonsoft.Json;

static class GidsTour
{
    public static Tour tour;
    public static void display()
    {
        Console.WriteLine($"Tour van {tour.Start} - {tour.End}");
        foreach (string visitor in tour.Spots)
        {
            Console.WriteLine(visitor);
        }
    }
    public static void AddID(int number)
    {

    }
    public static void CheckVisitor(int number)
    {
        string y;
        do
        {
            y = Console.ReadLine()!;
        }
        while (y != "y");
    }
}