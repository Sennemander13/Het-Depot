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

    public static void DisplayRondleidingen(string UserType)
    {
        foreach (Tour tour in DataModel.listoftours)
        {
            string[] timeparts = tour.Start.Split(":");
            int newHour = int.Parse(timeparts[0]);
            int newMinute = int.Parse(timeparts[1]);

            DateTime updatedTime = new DateTime(
                Program.world.Now.Year,
                Program.world.Now.Month,
                Program.world.Now.Day,
                newHour,
                newMinute,
                Program.world.Now.Second,
                Program.world.Now.Millisecond
            );
            if (UserType == "bezoeker")
            {
                if (updatedTime > Program.world.Now && tour.Spots.Count != 13)
                {
                    Program.world.WriteLine($"|{tour.Id}|{tour.Start}, {13 - tour.Spots.Count} plekken vrij");
                }
            }
            else if (UserType == "afdelingshoofd")
            {
                Program.world.WriteLine($"|{tour.Id}|{tour.Start}, {13 - tour.Spots.Count} plekken vrij | Gids: {tour.GuideCode}");
            }
            else
            {
                if (updatedTime > Program.world.Now)
                {
                    Program.world.WriteLine($"|{tour.Id}|{tour.Start}, {13 - tour.Spots.Count} plekken vrij | Gids: {tour.GuideCode}");
                }
            }
            
        }
    }

}