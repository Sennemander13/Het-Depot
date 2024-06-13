public static class BezoekersLogic
{
    public static void BezoekersMenuOption(string keuze)
    {
        if (keuze == "A")
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
        else if (keuze == "B")
        {
            Bezoeker.BezoekerCode = default;
        }
    }
}