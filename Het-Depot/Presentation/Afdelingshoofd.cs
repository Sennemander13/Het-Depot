public static class Afdelingshoofd
{
    public static void Display()
    {
        while (true){
            Program.world.Clear();
            Program.world.WriteLine($"Welkom AfdelingsHoofd");
            Program.world.WriteLine("--------------------");
            // BaseLogic.DisplayRondleidingen();
            Program.world.WriteLine("[A] Schema veranderen");
            Program.world.WriteLine("[B] Nieuwe codes invoeren");
            Program.world.WriteLine("[C] gids lijst aanpassen");
            Program.world.WriteLine("[D] Log uit");
            string userInput = Program.world.ReadLine()!.ToUpper();
            AfdelingshoofdLogic.MenuOptions(userInput);
            Program.world.ReadLine();
        }
    }
}