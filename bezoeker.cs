/*
Bezoeker moet een lijst krijgen met 
relevante rondleidingen'

Bezoeker moet hieruit kunnen kiezen
en daarna kunnen reserveren


als de bezoeker al ergens is gerserveerd
en hij heeft nog geen tour gedaan

dan mag hij herboek op een andere ronleiding'

Als de bezoeker gereserveerd heeft en hij is op de rondleiding waar hij
gereserveerd mag hij alleen nog annuleren

Reserveren moet kunnen als hij nog nergens ingeschreven staat
*/
public class Bezoeker
{
    static void main()
    {
        Console.Write("Kies een tijdslot: ");
        int tour_choice = Convert.ToInt32(Console.ReadLine());
        foreach (Tour tour in Tours.tours)
        {
            if (tour.Id  == tour_choice)
            {
                BezoekerTour.tour = tour;
                BezoekerTour.display();
            }
        }
    }
    public static void display()
    {
        Console.WriteLine("-----------------------");
        foreach (Tour tour in Tours.tours)
        {
            if (13 - tour.Spots.Count != 0)
            {
            Console.WriteLine($"|{tour.Id}| {tour.Start} - {tour.End}, {tour.Spots.Count}/13");
            }
        }
        Console.WriteLine("-----------------------");
        main();
    }
}
