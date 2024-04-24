public static class TourLogic
{
    public static bool CheckIfGereserveed(string bezoekerCode)
    {
        foreach (Tour tour in DataModel.listoftours!)
        {
            if (tour.Spots.Contains(bezoekerCode))
            {
                return true;
            }
        }
        return false;
    }

    public static bool CheckIfRondleidingGedaan(string bezoekerCode)
    {
        foreach (Tour tour in DataModel.listoftours!)
        {
            if (tour.HasTakenTour.Contains(bezoekerCode))
            {
                return true;
            }
        }
        return false;
    }
}