/*
Gids moet lijst tezien krijgen op
basis van tijd (als ie al is geweest niet laten zien)

Gids moet Rondleiding kunnen kiezen
Waarna hij een lijst te zien krijgt van alle mensen die gereserveerd hebben

hierna moet hij alle nachecken en opnieuw scannen
of toevoegen
*/
using Newtonsoft.Json;

public static class Gids
{
    public static void main()
    {
        display();
        Console.WriteLine("[A] Kies een tijdslot: ");
        Console.WriteLine("[B] Leeg de rondleidingen: ");
        string guideOption = Console.ReadLine()!;

        if (guideOption == "A")
        {
            Console.WriteLine("Kies een tijdslot: ");
            int tourChoice = Convert.ToInt32(Console.ReadLine());
            foreach (Tour tour in Tours.tours!)
            {
                if (tour.Id == tourChoice)
                {
                    GidsTour.tour = tour;
                    GidsTour.display();
                }
            }
        }
        else if (guideOption == "B")
        {
            emptyTours();
        }
    }

    public static void emptyTours()
    {
        foreach (Tour tour in Tours.tours!)
        {
            tour.Spots = [];
            tour.HasTakenTour = [];
        }

        Console.WriteLine("Alle rondleidingen van vandaag zijn leeg gemaakt");
    }

    /*
    public static void ListOfTours()
    {
        public List<string> {get; set;}

    }
    */

    public static void display()
    {
        Console.WriteLine("Gids");
        Console.WriteLine("--------------------");
        foreach (Tour tour in Tours.tours!)
        {
            Console.WriteLine($"|{tour.Id}|{tour.Start} - {tour.End}, {tour.Spots.Count}/13");
        }
        Console.WriteLine("--------------------");
    }
}