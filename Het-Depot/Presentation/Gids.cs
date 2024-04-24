public static class Gids
{
    public static string? GidsCode;
    public static void Display()
    {
        while (true)
        {
            Program.world.Clear();
            Program.world.WriteLine($"Welkom {GidsCode}");
            Program.world.WriteLine("--------------------");
            BaseLogic.DisplayRondleidingen();
            Program.world.WriteLine("[A] kies een rondleiding");
            Program.world.WriteLine("[B] Leeg de rondleidingen");
            Program.world.WriteLine("[C] Log uit");
            Program.world.WriteLine("--------------------");
            string userInput = Program.world.ReadLine()!.ToUpper();
            GidsLogic.GuideMenuOption(userInput);
        }
    }
}