public static class BezoekerTourLogic
{
    public static void TourMenuOptions(string code, Tour tour)
    {
        if (TourLogic.CheckIfRondleidingGedaan(code))
        {
            Program.world.WriteLine("U heeft al een rondleiding gedaan");
            Program.world.WriteLine("Kom morgen terug");
        }
        else if (tour.Spots.Contains(code))
        {
            Program.world.WriteLine("U heeft al gereserveerd op deze rondleiding");
            Program.world.WriteLine("Wilt u uitschrijven? (y/n)");
            string confirm;
            do
            {
                confirm = Program.world.ReadLine()!.ToLower();
            } while (confirm != "n" && confirm != "y");
            if (confirm == "y")
            {
                tour.Spots.Remove(code);
            }
        }
        else if (TourLogic.CheckIfGereserveed(code))
        {
            Program.world.WriteLine("U heeft al ergens gereserveerd");
            Program.world.WriteLine("Wilt u herboeken naar deze rondleiding? (y/n)");
            string confirm;
            do
            {
                confirm = Program.world.ReadLine()!.ToLower();
            } while (confirm != "n" && confirm != "y");
            if (confirm == "y")
            {
                herboeken(code, tour);
            }
        }
        else
        {
            Program.world.WriteLine("Wilt u op deze rondleiding een plaats reserveren? (y/n)");
            string confirm;
            do
            {
                confirm = Program.world.ReadLine()!.ToLower();
            } while (confirm != "n" && confirm != "y");
            if (confirm == "y")
            {
                tour.Spots.Add(code);
            }
        }
    }
    
    public static void herboeken(string code, Tour tour)
    {
        foreach (Tour t in DataModel.listoftours!)
        {
            if (t.Spots.Contains(code))
            {
                t.Spots.Remove(code);
            }
        }
        tour.Spots.Add(code);
    }

}