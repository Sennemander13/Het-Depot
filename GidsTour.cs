using Newtonsoft.Json;
using System.Media;

static class GidsTour
{
    public static Tour? tour;
    public static void display()
    {
        bool x = true;
        while (x)
        {
            Console.Clear();
            Console.WriteLine($"Tour ID: {tour!.Id} | Tijdsinterval: {tour.Start} - {tour.End}       {tour.Spots.Count}   ");

            int maxLength = Math.Max(tour.Spots.Count, tour.HasTakenTour.Count);
            Console.WriteLine("Gereserveerde mensen:        Ingecheckte mensen:");

            for (int i = 0; i < maxLength; i++)
            {
                string item1 = i < tour.Spots.Count ? tour.Spots[i] : "";
                string item2 = i < tour.HasTakenTour.Count ? tour.HasTakenTour[i] : "";

                Console.WriteLine($"{item1,-28} {item2,-28}");
            }

            Console.WriteLine("Taak uitvoeren:");
            Console.WriteLine("A: Bezoeker inchecken");
            Console.WriteLine("B: Rondleiding starten");
            // Console.WriteLine("C: Last-minute check-in");
            Console.Write("Taak: ");
            string GidsInput = Console.ReadLine()!.ToUpper();
            Console.WriteLine();

            if (GidsInput.ToUpper() == "A")
            {
                Console.Write("Unieke Code: ");
                string UniqueId = Console.ReadLine()!;
                AddID(UniqueId);
                // CheckVisitor(UniqueId);
                Console.ReadLine();
                // x = false;
                // break;
            }

            else if (GidsInput.ToUpper() == "B")
            {
                x = false;
                break;
            }
            else
            {
                Console.WriteLine($"{GidsInput} is geen optie, kies tussen A en B");
                // x = false;
                // break;
            }
        }

    }

    public static void AddID(string number)
    {
        // als een boezoekers code in de lijst van codes staat,
        // die we elke dag krijgen van afdelingshoofd
        if (Tours.IsValidCode(number))
        {
            // checkt of de bezoeker al een tour heeft gedaan
            if (!Tours.CheckifHadTour(number)){
                // als de bezoeker ergens anders heeft ingeschreven
                // maar nog geen rondleiding heeft gedaan
                // dan kan hij ingecheckt worden op deze rondleiding en
                // wordt zijn reservering weg gehaald
                foreach (Tour atour in Tours.tours)
                {
                    if (tour.Spots.Contains(number))
                    {
                        atour!.Spots.Remove(number!);
                    }
                }
                // Bezoeker wordt ingecheckt op deze tour
                tour!.HasTakenTour.Add(number);
                // speelt het checking geluid af
                SoundPlayer soundPlayer = new SoundPlayer("beep-07a.wav");
                soundPlayer.Play();
                // zorgt dat de applicatie niet opeens afsluit tijdens afspelen
                while (soundPlayer.IsLoadCompleted == false) { }
            }
            // als de bezoeker al een rondleiding heeft gedaan wordt dat gemeld
            else if (Tours.CheckifHadTour(number)){
            Console.WriteLine("Rondleiding al gehad");
            Console.WriteLine("Terug naar tours\npress enter");
            Console.ReadLine();
            }
        }
        // anders is het een invalid code
        else{
            Console.WriteLine("Onjuiste code\npress enter");
            Console.ReadLine();
        }
        
        
    }

    public static void CheckVisitor(string number)
    {
        foreach (string UniqueIds in tour!.Spots)
        {
            if (UniqueIds == number)
            {
                AddID(number);
            }
            else
            {
                Console.WriteLine("ID not in spots list");
                break;
            }
        }
    }
}