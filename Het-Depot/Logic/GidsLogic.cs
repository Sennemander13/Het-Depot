public static class GidsLogic
{
    public static void GuideMenuOption(string keuze)
    {
        if (keuze == "A")
        {
            Program.world.WriteLine("Kies een Rondleiding (id): ");
            string tourChoice = Program.world.ReadLine()!;
            foreach (Tour tour in DataModel.listoftours!)
            {
                if (tour.Id == tourChoice)
                {
                    GidsTour.tour = tour;
                    GidsTour.Display();
                }
            }
        }
        else if (keuze == "B")
        {
            Gids.GidsCode = default;
        }
    }

}