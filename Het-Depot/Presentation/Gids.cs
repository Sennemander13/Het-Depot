public static class Gids
{
    public static string GidsCode;
    public static void Display()
    {
        string userInput;
        do
        {
            Program.world.Clear();
            Program.world.WriteLine($"Welkom, {GidsCode}");
            Program.world.WriteLine("--------------------");
            BaseLogic.DisplayRondleidingen("gids");
            Program.world.WriteLine("--------------------");
            Program.world.WriteLine("-Kies tussen opties A of B-");
            Program.world.WriteLine("[A]: Kies een rondleiding");
            Program.world.WriteLine("[B]: Log uit");
            Program.world.WriteLine("--------------------");
            userInput = Program.world.ReadLine()!.ToUpper();
            GidsLogic.GuideMenuOption(userInput);
        } while (userInput != "B");
    }
}