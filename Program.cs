using Newtonsoft.Json;


public class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
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
                        // for the guides
                        // Console.WriteLine("Guides");

                    }
                    else if (code == uniqueCode) // Assuming uniqueCode.Text is accessible here
                    {
                        // for valid users
                        // Console.WriteLine("valid code");
                        // link to user page
                    }
                    else
                    {
                        // invalid input
                        // Console.WriteLine("this is a invalid code");
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