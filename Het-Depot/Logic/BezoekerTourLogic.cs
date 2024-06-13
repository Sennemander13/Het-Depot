public static class BezoekerTourLogic
{
    public static void TourMenuOptions(string code, Tour tour)
    {
        if (TourLogic.CheckIfRondleidingGedaan(code))
        {
            Program.world.WriteLine("U heeft al een rondleiding gevolgd");
            Program.world.WriteLine("Kom morgen terug");
            Program.world.WriteLine("Druk Enter");
            Console.ReadLine();
        }
        else if (tour.Spots.Contains(code))
        {
            Annuleren(code, tour);
        }
        else if (TourLogic.CheckIfGereserveed(code) != -1)
        {
            herboeken(code, tour);
        }
        else
        {
            Reserveren(code, tour);
        }
    }

    public static void Reserveren(string code, Tour tour)
    {
        Program.world.WriteLine("Wilt u op deze rondleiding een plaats reserveren?");
        Program.world.WriteLine("[Y]: Reserveren");
        Program.world.WriteLine("[N]: Niet reserveren");
        string confirm;
        do
        {
            confirm = Program.world.ReadLine()!.ToLower();
        } while (confirm != "n" && confirm != "y");
        if (confirm == "y")
        {
            tour.Spots.Add(code);
            DataModel.WriteToCurrentDayJSON(DataModel.listoftours, DataModel.FilePathSchedule);
            Program.world.WriteLine("Reserveren voltooid!");
            Program.world.WriteLine("Druk Enter");
            Program.world.ReadLine();
        }
    }

    public static void Annuleren(string code, Tour tour)
    {
        Program.world.WriteLine("U heeft al gereserveerd op deze rondleiding");
        Program.world.WriteLine("Wilt u zich uitschrijven?");
        Program.world.WriteLine("[Y]: Uitschrijven");
        Program.world.WriteLine("[N]: Niet uitschrijven");
        string confirm;
        do
        {
            confirm = Program.world.ReadLine()!.ToLower();
        } while (confirm != "n" && confirm != "y");
        if (confirm == "y")
        {
            tour.Spots.Remove(code);
            DataModel.WriteToCurrentDayJSON(DataModel.listoftours, DataModel.FilePathSchedule);
            Program.world.WriteLine("Uitschrijven voltooid!");
            Program.world.WriteLine("Druk Enter");
            Program.world.ReadLine();

        }
    }

    public static void herboeken(string code, Tour tour)
    {
        Program.world.WriteLine($"U heeft al gereserveerd op de rondleiding van {DataModel.listoftours[TourLogic.CheckIfGereserveed(code)].Start}");
        Program.world.WriteLine("Wilt u herboeken naar deze rondleiding?");
        Program.world.WriteLine("[Y]: Herboeken");
        Program.world.WriteLine("[N]: Niet herboeken");

        string confirm;
        do
        {
            confirm = Program.world.ReadLine()!.ToLower();
        } while (confirm != "n" && confirm != "y");
        if (confirm == "y")
        {
            foreach (Tour t in DataModel.listoftours!)
            {
                if (t.Spots.Contains(code))
                {
                    t.Spots.Remove(code);
                }
            }
            tour.Spots.Add(code);
            DataModel.WriteToCurrentDayJSON(DataModel.listoftours, DataModel.FilePathSchedule);
            Program.world.WriteLine("Herboeken voltooid!");
            Program.world.WriteLine("Druk Enter");
            Program.world.ReadLine();
        }
    }
}