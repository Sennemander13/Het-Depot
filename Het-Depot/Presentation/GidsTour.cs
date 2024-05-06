public static class GidsTour
{
    public static Tour? tour;
    public static void Display()
    {
        Program.world.Clear();
        Program.world.WriteLine($"Tour ID: {tour!.Id} | Tijdsinterval: {tour.Start} - {tour.End} | Bezoekers: {tour.Spots.Count}   ");
        GidsTourLogic.show2lists(tour);
        Program.world.WriteLine("Kies een taak om uit te voeren:");
        Program.world.WriteLine("[A]: Bezoeker inchecken\n[B] terug");
        Program.world.Write("Taak: ");
        string GidsInput = Program.world.ReadLine()!.ToUpper();
        GidsTourLogic.Menu(GidsInput, tour);
    }

}
