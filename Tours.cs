using System.IO;
using Newtonsoft.Json;
public static class Tours
{

    public static List<Tour>? tours;

    public static bool isSomething;

    static Tours()
    {
        getListOfTours();
    }

    public static void getListOfTours()
    {
        // Method logic here
        using (StreamReader reader = new StreamReader("ListOfTours.json"))
        {
            // Read the JSON file as a string
            string fileContents = reader.ReadToEnd();

            // Deserialize the JSON string into a list of strings
            List<Tour> listOfObjects = JsonConvert.DeserializeObject<List<Tour>>(fileContents)!;

            tours = listOfObjects;
        }
    }
    public static bool Checkif(string user_id)
    {
        foreach (Tour tour in tours!)
        {
            if (tour.Spots.Contains(user_id))
            {
                // Console.WriteLine("It's already checked in");
                return true; // Set flag to true if user is already checked in
                // Exit the loop since we found a match
            }
        }
        return false;
    }

    public static bool CheckifHadTour(string user_id)
    {
        foreach (Tour tour in tours!)
        {
            if (tour.HasTakenTour.Contains(user_id))
            {
                return true;
            }
        }
        return false;
    }

    public static bool IsValidCode(string id)
    {
        using (StreamReader reader = new StreamReader("UniqueCodesToday.json"))
        {
            // Read the JSON file as a string
            string fileContents = reader.ReadToEnd();

            // Deserialize the JSON string into a list of strings
            List<string> listOfObjects = JsonConvert.DeserializeObject<List<string>>(fileContents)!;

            if (listOfObjects != null)
            {
                foreach (string code in listOfObjects)
                {
                    if (id == code)
                    {
                        return true;
                    }
                }
                return false;
            }
            return false;
        }
    }

}
