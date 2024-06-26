public static class GidsTour
{
    public static Tour tour;
    public static void Display()
    {
        string GidsInput;
        do
        {
            Program.world.Clear();
            Program.world.WriteLine($"Rondleiding ID: {tour!.Id} | StartTijd: {tour.Start} | Bezoekers: {tour.HasTakenTour.Count}   ");
            GidsTourLogic.show2lists(tour);
            Program.world.WriteLine("Kies een taak om uit te voeren:");
            Program.world.WriteLine("[A]: Bezoeker inchecken");
            Program.world.WriteLine("[B]: Terug");
            Program.world.Write("Taak: ");
            GidsInput = Program.world.ReadLine()!.ToUpper();
            GidsTourLogic.Menu(GidsInput, tour);
        } while (GidsInput != "B");
    }
}