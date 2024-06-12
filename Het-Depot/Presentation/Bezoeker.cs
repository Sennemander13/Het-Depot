public static class Bezoeker
{
    public static string? BezoekerCode;
    public static void Display()
    {
        string BezoekerKeuze;
        do
        {
            Program.world.Clear();
            Program.world.WriteLine($"Welkom, {BezoekerCode}");
            Program.world.WriteLine("--------------------");
            BaseLogic.DisplayRondleidingen("bezoeker");
            Program.world.WriteLine("--------------------");
            Program.world.WriteLine("-Kies tussen opties A of B-");
            Program.world.WriteLine("[A]: Kies een rondleiding");
            Program.world.WriteLine("[B]: Log uit");
            Program.world.WriteLine("--------------------");
            BezoekerKeuze = Program.world.ReadLine().ToUpper();
            BezoekerTour.BezoekerCode = BezoekerCode;
            BezoekersLogic.BezoekersMenuOption(BezoekerKeuze);
        } while (BezoekerKeuze != "B");
    }
}