public static class TourLogic
{
    public static int CheckIfGereserveed(string bezoekerCode)
    {
        foreach (Tour tour in DataModel.listoftours!)
        {
            if (tour.Spots.Contains(bezoekerCode))
            {
                return Convert.ToInt32(tour.Id);
            }
        }
        return -1;
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