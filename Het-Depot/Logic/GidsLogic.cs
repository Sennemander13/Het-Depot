public static class GidsLogic
{
    public static void GuideMenuOption(string keuze)
    {
        if (keuze == "A")
        {
            ChooseTour();
        }
        else if (keuze == "B")
        {
            EmptyTours();
        }
        else if (keuze == "C")
        {
            Gids.GidsCode = default;
            // Program.Main();
        }
        else {
            Program.world.WriteLine("Ongeldige keuze");
        }
    }

    public static void ChooseTour()
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

    public static void EmptyTours()
    {
        foreach (Tour tour in DataModel.listoftours!)
        {
            tour.Spots = [];
            tour.HasTakenTour = [];
        }

    }
}