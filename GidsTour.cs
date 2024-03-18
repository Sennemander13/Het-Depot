using Newtonsoft.Json;

static class GidsTour
{
    public static Tour tour;
    public static void display()
    {
        CheckVisitor(5);
        Console.WriteLine(tour.engDesc);
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