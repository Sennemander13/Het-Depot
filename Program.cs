using Newtonsoft.Json;


public class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("--------------------");
            Console.WriteLine("Welkom log in met unique id");

            Console.Write("unique code: ");
            string user_id = Console.ReadLine()!;
            TryEnter(user_id);
        }

    }


    public static void TryEnter(string uniqueCode)
    {
        using (StreamReader reader = new StreamReader("UniqueCodesToday.json"))
        {
            // Read the JSON file as a string
            string fileContents = reader.ReadToEnd();

            // Deserialize the JSON string into a list of strings
            List<string> listOfObjects = JsonConvert.DeserializeObject<List<string>>(fileContents)!;

            // Check if deserialization was successful
            if (listOfObjects != null)
            {
                foreach (string code in listOfObjects)
                {
                    // Console.WriteLine(code);
                    if (uniqueCode == "0") 
                    {
                        Gids.main();
                        // for the guides
                        // Console.WriteLine("Guides");
                        break;

                    }
                    else if (code == uniqueCode) // Assuming uniqueCode.Text is accessible here
                    {
                        Bezoeker.main();
                        BezoekerTour.uniqueCode = uniqueCode;
                        // for valid/visitors users
                        // Console.WriteLine("valid code");
                        // link to user page
                        break;
                    }
                    else if (code == "99999")
                    {
                        Afdelingshoofd.display();
                        //afdelingshoofd 
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid code");
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Failed to deserialize JSON file.");
            }
        }
    }
}