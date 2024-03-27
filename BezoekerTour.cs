static class BezoekerTour
{
    public static Tour? tour;
    public static string? uniqueCode;

    public static void display()
    {
        
        Console.Clear();
        Console.WriteLine("-----------------------");
        Console.WriteLine($"{tour!.Start} - {tour.End} is geselecteerd\nconformeer je keuze (ja of nee)");
        string conformation;
        do 
        {
            conformation = Console.ReadLine()!.ToLower();
        } while (conformation != "nee" && conformation != "ja");
        if (conformation == "ja")
        {
            AddID();
        }
        else {
            Console.WriteLine("Terug naar tours");
            Console.Write("press enter");
            Console.ReadLine();
            Bezoeker.main();
        }
        // Console.WriteLine("-----------------------");
    }
    public static void AddID()
    {
        if (!Tours.Checkif(uniqueCode!) && tour!.Spots.Count < 13 && !Tours.CheckifHadTour(uniqueCode!))
        {
            tour.Spots.Add(uniqueCode!);
            Console.WriteLine($"plek gereserveerd\nRondleiding start om {tour.Start}");
            Console.Write("press enter");
            Console.ReadLine();
            Bezoeker.main();
            
        }
        else {Console.WriteLine("Al ingechecked");
        Console.Write("press enter");
        Console.ReadLine();
        Bezoeker.main();}
    }
}