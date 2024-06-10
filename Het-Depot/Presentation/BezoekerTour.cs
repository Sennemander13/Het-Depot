public static class BezoekerTour
{
    public static Tour? tour;
    public static string? BezoekerCode;
    public static void Display()
    {
        Program.world.Clear();
        Program.world.WriteLine("--------------------");
        Program.world.WriteLine($"{tour!.Start} is geselecteerd");
        BezoekerTourLogic.TourMenuOptions(BezoekerCode!, tour);
    }
}