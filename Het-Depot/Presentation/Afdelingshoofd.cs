public static class Afdelingshoofd
{
    public static void Display()
    {
        string userInput;
        do
        {
            Program.world.Clear();
            Program.world.WriteLine($"Welkom, AfdelingsHoofd");
            Program.world.WriteLine("--------------------");
            Program.world.WriteLine("[A]: Gidsen aan schema koppelen");
            Program.world.WriteLine("[B]: Nieuwe codes invoeren");
            Program.world.WriteLine("[C]: gids lijst aanpassen");
            Program.world.WriteLine("[D]: Schema aanpassen");
            Program.world.WriteLine("[E]: Log uit");
            userInput = Program.world.ReadLine().ToUpper();
            AfdelingshoofdLogic.MenuOptions(userInput);
        } while (userInput != "E");
    }
}