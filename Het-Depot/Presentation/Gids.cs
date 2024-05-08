public static class Gids
{
    public static string? GidsCode;
    public static void Display()
    {
        string userInput;
        do{
            Program.world.Clear();
            Program.world.WriteLine($"Welkom {GidsCode}");
            Program.world.WriteLine("--------------------");
            BaseLogic.DisplayRondleidingen();
            Program.world.WriteLine("[A] kies een rondleiding");
            Program.world.WriteLine("[B] Leeg de rondleidingen");
            Program.world.WriteLine("[C] Log uit");
            Program.world.WriteLine("--------------------");
            userInput = Program.world.ReadLine()!.ToUpper();
            GidsLogic.GuideMenuOption(userInput);
        }while (userInput != "C");
    }
}