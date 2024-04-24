public static class GidsTour
{
    public static Tour? tour;
    public static void Display()
    {
        Program.world.Clear();
        Program.world.WriteLine($"Tour ID: {tour!.Id} | Tijdsinterval: {tour.Start} - {tour.End}       {tour.Spots.Count}   ");
        GidsTourLogic.show2lists(tour);
        Program.world.WriteLine("Taak uitvoeren:");
        Program.world.WriteLine("A: Bezoeker inchecken\n[B] terug");
        Program.world.Write("Taak: ");
        string GidsInput = Program.world.ReadLine()!.ToUpper();
        GidsTourLogic.Menu(GidsInput, tour);
    }

}
