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
        Console.WriteLine();
        GidsTour.tour = new Tour("test start", "test end", [], []); ;
        GidsTour.display();
    }
    public static void display()
    {
        Console.WriteLine("Gids");
        Console.ReadLine();

        GidsTour.tour = Tours.tours[1];
    }
}