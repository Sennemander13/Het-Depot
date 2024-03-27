/*
Gids moet lijst tezien krijgen op
basis van tijd (als ie al is geweest niet laten zien)

Gids moet Rondleiding kunnen kiezen
Waarna hij een lijst te zien krijgt van alle mensen die gereserveerd hebben

hierna moet hij alle nachecken en opnieuw scannen
of toevoegen
*/
public class Gids
{
    public static void main()
    {
        Console.WriteLine("Kies een tijdslot: ");
        int tourChoice = Convert.ToInt32(Console.ReadLine());
        foreach (Tour tour in Tours.tours)
        {
            if (tour.Id == tourChoice)
            {
                BezoekerTour.tour = tour;
                BezoekerTour.display();
            }
        }
    }
    public static void display()
    {
        Console.WriteLine("Gids");
        Console.WriteLine("--------------------");
        foreach (Tour tour in Tours.tours)
        {
            Console.WriteLine($"|{tour.Id}|{tour.Start} - {tour.End}, {tour.Spots.Count}/13");
        }
        Console.WriteLine("--------------------");
        main();
    }
}