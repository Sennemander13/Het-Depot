static class BezoekerTour
{
    public static Tour? tour;
    public static string? uniqueCode;

    public static void display()
    {
        bool x = true;
        while (x){
            Console.Clear();
            Console.WriteLine("-----------------------");
            Console.WriteLine($"{tour!.Start} - {tour.End} is geselecteerd");
            if (!Tours.Checkif(uniqueCode) && tour.Spots.Count < 13 && !Tours.CheckifHadTour(uniqueCode))
            {
                tour.Spots.Add(uniqueCode);
                Console.WriteLine("Plek gereserveerd");
                Console.ReadLine();
                break;
                x = false;
            }
            // voor als hij al ingecheckt is op deze rondleidng
            if (tour.Spots.Contains(uniqueCode!))
            {
                Console.WriteLine("U bent al ingecheckt op deze Rondleiding\nWilt u uitschrijven? (ja of nee)");
                string conformation;
                do
                {
                    conformation = Console.ReadLine()!.ToLower();
                } while (conformation != "nee" && conformation != "ja");
                if (conformation == "ja")
                {
                    RemoveID();
                }
                else
                {
                    Console.WriteLine("Terug naar tours\npress enter");
                    Console.ReadLine();
                    x = false;
                }
            break;

            }

            if (Tours.Checkif(uniqueCode)){
                Console.WriteLine("U bent al ingechekt op andere Rondleiding\nWilt u herboekern?");
                // herboeken?
                string conformation;
                do
                {
                    conformation = Console.ReadLine()!.ToLower();
                } while (conformation != "nee" && conformation != "ja");
                if (conformation == "ja")
                {
                    foreach (Tour tourt in Tours.tours)
                    {
                        if (tourt.Spots.Contains(uniqueCode))
                        {
                            RemoveIDSpecificTour(tourt);
                        }
                    }
                    tour.Spots.Add(uniqueCode!);
                    x = false;
                }
                break;

            }
            if (tour.Spots.Count == 13){
                Console.WriteLine("De rondleiding is vol");
                Console.WriteLine("Terug naar tours\npress enter");
                Console.ReadLine();
                x = false;
                break;

            }
            if (Tours.CheckifHadTour(uniqueCode)){
                Console.WriteLine("Rondleiding al gehad");
                Console.WriteLine("Terug naar tours\npress enter");
                Console.ReadLine();
                x = false;
                break;

            }
            
            

            Console.WriteLine("Invalid");
            Console.ReadLine();
            x = false;
            break;

        }

    }
    public static void RemoveID()
    {
        tour!.Spots.Remove(uniqueCode!);
        Console.WriteLine("Rondleiding geannuleerd");
        Console.Write("press enter");
        Console.ReadLine();
        // Bezoeker.main();
    }

    public static void RemoveIDSpecificTour(Tour tour)
    {
        tour!.Spots.Remove(uniqueCode!);
        Console.WriteLine("Rondleiding Herboekt");
        Console.Write("press enter");
        Console.ReadLine();
        // Bezoeker.main();
    }
}