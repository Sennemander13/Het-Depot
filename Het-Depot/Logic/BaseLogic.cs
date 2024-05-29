public static class BaseLogic
{
    public static bool IsValidCode<T>(string  CodetoCheck, List<T> list)
    {
        foreach (T code in list)
        {
            if (code!.ToString() == CodetoCheck!.ToString())
            {
                Program.world.WriteLine("Code is geldig");
                return true;
            }
        }
        Program.world.WriteLine("Code is ongeldig");
        return false;
    }

    public static void Login(string code)
    {
        if (DataModel.visitorCodes!.Contains(code))
        {
            Bezoeker.BezoekerCode = code;
            Bezoeker.Display();
        }
        else if (DataModel.guideCodes!.Contains(code))
        {
            Gids.GidsCode = code;
            Gids.Display();
        }
        else if (code == "99999")
        {
            Afdelingshoofd.Display();
        }
        else if (code == "quit")
        {return;}
        else {
            Program.world.WriteLine("Ongeldige code");
        }
    }

    public static void DisplayRondleidingen()
    {
        DateTime today = Program.world.Now;
        DateTime searchfordate = new DateTime(today.Year,today.Month,today.Day);
        foreach (Tour tour in DataModel.listoftours)
        {
            DateTime toursstart = DateTime.Parse(tour.Start);
            if (toursstart.Day == searchfordate.Day && toursstart.Month == searchfordate.Month && toursstart.Year == searchfordate.Year)
            {
            // Program.world.Now;
                Program.world.WriteLine($"|{tour.Id}|{tour.Start} - {tour.End}, {tour.Spots.Count}/13");
            }
        }
    }

}