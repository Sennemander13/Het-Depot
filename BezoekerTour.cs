static class BezoekerTour
{
    public static Tour tour;
    public static string uniqueCode;

    public static void display()
    {
        Console.WriteLine("-----------------------");
        Console.WriteLine($"{tour.Start} - {tour.End} is geselecteerd\nconformeer je keuze (ja of nee)");
        string conformation = Console.ReadLine()!;
        Console.WriteLine("-----------------------");
        AddID(uniqueCode, conformation);
    }
    public static void AddID(string uniqueCode, string conformation)
    {
        while (true)
        {
            if (conformation == "ja" || conformation == "Ja")
            {
                // nog unique code verwijderen uit UniqueCodesToday en tovoegen aan spots in de Tour.
                Console.WriteLine($"tour: {tour.Start} - {tour.End} succesvol gereserveerd");
                break;
            }
            else if (conformation == "nee" || conformation == "Nee")
            {
                Program.TryEnter(uniqueCode);
                break;
            }
            else
            {
                Console.WriteLine("Ongeldige invoer");
            }
        }
    }
}