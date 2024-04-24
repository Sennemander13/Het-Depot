public static class BezoekersLogic
{
    public static void BezoekersMenuOption(string keuze)
    {
        if (keuze == "A")
        {
            ChooseTour();
        }
        else if (keuze == "B")
        {
            Bezoeker.BezoekerCode = default;
            Program.Main();
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
                BezoekerTour.tour = tour;
                BezoekerTour.Display();
            }
        }
    }
}