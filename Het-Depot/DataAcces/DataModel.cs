using System.Text.Json;
public static class DataModel
{
    public static List<Tour>? listoftours;
    public static List<string>? visitorCodes;
    public static List<string>? guideCodes;

    public static string FilePathSchedule = "RondleidingLog/default.json";
    // public static SoundPlayer soundPlayer = new("DataSources/beep-07a.wav");
    static DataModel()
    {
        getListOfTours();
        getListOfVisitorCodes();
        getListofGuideCodes();
    }

    public static void getListOfTours()
    {
        // Method logic here
        // Read the entire content of the file as a single string
        string fileContents = Program.world.ReadAllText(FilePathSchedule);

        // Deserialize the JSON content into a list of Tour objects
        List<Tour> listOfTours = JsonSerializer.Deserialize<List<Tour>>(fileContents)!;
        
        listoftours = listOfTours;
    }

    private static void getListOfVisitorCodes()
    {
        string fileContents = Program.world.ReadAllText("DataSources/UniqueCodesToday.json");

        List<string> listofvisitors = JsonSerializer.Deserialize<List<string>>(fileContents)!;

        visitorCodes = listofvisitors;
    }

    private static void getListofGuideCodes()
    {
        // Read the JSON file as a string
        string fileContents = Program.world.ReadAllText("DataSources/GidsCodes.json");

        // Deserialize the JSON string into a list of strings
        List<string> listOfObjects = JsonSerializer.Deserialize<List<string>>(fileContents)!;

        guideCodes = listOfObjects;
    }
    
}