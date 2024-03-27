using Newtonsoft.Json;

static class GidsTour
{
    public static Tour? tour;
    public static void display()
    {
        Console.WriteLine($"Tour ID: {tour.Id} | Tijdsinterval: {tour.Start} - {tour.End}");
        foreach (string visitor in tour.Spots)
        {
            Console.WriteLine(visitor);
        }
        Console.WriteLine();

        while (true)
        {
            foreach (string checkedin in tour.HasTakenTour)
            {
                Console.WriteLine(checkedin);
            }
            Console.WriteLine();

            Console.WriteLine("Taak uitvoeren:");
            Console.WriteLine("A: Bezoeker inchecken");
            Console.WriteLine("B: Rondleiding starten");
            Console.WriteLine("C: Last-minute check-in");
            Console.Write("Taak: ");
            string GidsInput = Console.ReadLine()!;
            Console.WriteLine();

            if (GidsInput.ToUpper() == "A")
            {
                Console.Write("Unieke Code: ");
                string UniqueId = Console.ReadLine()!;
                CheckVisitor(UniqueId);
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
        tour.HasTakenTour.Add(number);
    }

    public static void CheckVisitor(string number)
    {
        foreach (string UniqueIds in tour.Spots)
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