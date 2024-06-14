using System.Media;
public static class GidsTourLogic
{
    public static void show2lists(Tour tour)
    {
        int maxLength = Math.Max(tour.Spots.Count, tour.HasTakenTour.Count);
        Program.world.WriteLine("Gereserveerde mensen:        Ingecheckte mensen:");

        for (int i = 0; i < maxLength; i++)
        {
            string item1 = i < tour.Spots.Count ? tour.Spots[i] : "";
            string item2 = i < tour.HasTakenTour.Count ? tour.HasTakenTour[i] : "";

            Program.world.WriteLine($"{item1,-28} {item2}");
        }

    }

    public static void Menu(string GidsInput, Tour tour)
    {
        if (GidsInput == "A")
        {
            Program.world.Write("Unieke Code: ");
            string UniqueId = Program.world.ReadLine()!;
            AddID(UniqueId, tour);
            Program.world.Write("Press enter");
            Console.ReadLine();
        }
    }

    public static void AddID(string number, Tour tour)
    {
        if (BaseLogic.IsValidCode(number, DataModel.visitorCodes!) && number != "")
        {
            if (!TourLogic.CheckIfRondleidingGedaan(number))
            {
                foreach (Tour atour in DataModel.listoftours!)
                {
                    if (tour.Spots.Contains(number))
                    {
                        atour!.Spots.Remove(number!);
                    }
                }
                tour!.HasTakenTour.Add(number);
                DataModel.WriteToCurrentDayJSON(DataModel.listoftours, DataModel.FilePathSchedule);
                // SoundPlayer soundPlayer = new SoundPlayer("DataSources/beep-07a.wav");
                // soundPlayer.Play();
                // // zorgt dat de applicatie niet opeens afsluit tijdens afspelen
                // while (soundPlayer.IsLoadCompleted == false) { }
                Program.world.WriteLine("Bezoeker is ingecheckt voor rondleiding");
            }
            else { Program.world.WriteLine("Bezoeker heeft al een rondleiding gehad"); }
        }
    }
}