public static class Bezoeker
{
    public static string? BezoekerCode;
    public static void Display()
    {
        while (true){
            Program.world.Clear();
            Program.world.WriteLine($"Welkom {BezoekerCode}");
            Program.world.WriteLine("--------------------");
            BaseLogic.DisplayRondleidingen();
            Program.world.WriteLine("--------------------");
            Program.world.WriteLine("[A] Kies een rondleiding");
            Program.world.WriteLine("[B] Log uit");
            string BezoekerKeuze = Program.world.ReadLine().ToUpper();
            BezoekerTour.BezoekerCode = BezoekerCode;
            BezoekersLogic.BezoekersMenuOption(BezoekerKeuze);
            break;
        }
    }
}