using System.IO;
using Newtonsoft.Json;
public static class Tours
{

    public static List<Tour> tours;

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

}
