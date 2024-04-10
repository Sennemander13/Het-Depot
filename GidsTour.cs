using Newtonsoft.Json;
using System.Media;

static class GidsTour
{
    public static Tour? tour;
    public static void display()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine($"Tour ID: {tour!.Id} | Tijdsinterval: {tour.Start} - {tour.End}           ");
            // foreach (string visitor in tour.Spots)
            // {
            //     Console.WriteLine(visitor);
            // }
            // Console.WriteLine();

            // Console.WriteLine("Mensen die er daadwerkelijk zijn:");
            // foreach (string checkedin in tour.HasTakenTour)
            // {
            //     Console.WriteLine(checkedin);
            // }
            // Console.WriteLine();
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
            }

            else if (GidsInput.ToUpper() == "B")
            {
                break;
            }

            else if (GidsInput.ToUpper() == "C")
            {

            }

            else
            {
                Console.WriteLine($"{GidsInput} is geen optie, kies tussen A en B");
            }
        }

    }

    public static void AddID(string number)
    {
        if (Tours.IsValidCode(number) && !Tours.CheckifHadTour(number))
        {
            // when everything is checked add
            tour!.HasTakenTour.Add(number);
            string audioFilePath = "beep-07a.wav";
            try{
                SoundPlayer soundPlayer = new SoundPlayer(audioFilePath);
                soundPlayer.Play();

                // Keep the console application running until the audio finishes playing
                while (soundPlayer.IsLoadCompleted == false) { }
            }
            catch (Exception ex){Console.WriteLine("Error: " + ex.Message);}
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