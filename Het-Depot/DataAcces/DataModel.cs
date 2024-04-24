using Newtonsoft.Json;
public static class DataModel
{
    public static List<Tour>? listoftours;
    public static List<string>? visitorCodes;
    public static List<string>? guideCodes;
    // public static SoundPlayer soundPlayer = new("DataSources/beep-07a.wav");
    static DataModel()
    {
        getListOfTours();
        getListOfVisitorCodes();
        getListofGuideCodes();
    }

    private static void getListOfTours()
    {
        // Method logic here
        using (StreamReader reader = new("DataSources/ListOfTours.json"))
        {
            // Read the JSON file as a string
            string fileContents = reader.ReadToEnd();

            // Deserialize the JSON string into a list of strings
            List<Tour> listOfObjects = JsonConvert.DeserializeObject<List<Tour>>(fileContents)!;

            listoftours = listOfObjects;
        }
    }

    private static void getListOfVisitorCodes()
    {
        using(StreamReader reader = new("DataSources/UniqueCodesToday.json"))
        {
            // Read the JSON file as a string
            string fileContents = reader.ReadToEnd();

            // Deserialize the JSON string into a list of strings
            List<string> listOfObjects = JsonConvert.DeserializeObject<List<string>>(fileContents)!;

            visitorCodes = listOfObjects;
        }
    }

    private static void getListofGuideCodes()
    {
        using(StreamReader reader = new("DataSources/GidsCodes.json"))
        {
            // Read the JSON file as a string
            string fileContents = reader.ReadToEnd();

            // Deserialize the JSON string into a list of strings
            List<string> listOfObjects = JsonConvert.DeserializeObject<List<string>>(fileContents)!;

            guideCodes = listOfObjects;
        }
    }
    
}