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
        DateTime date = Program.world.Now;
        string dateTime = date.ToString("dd-MM-yyy");
        List<string> logEntries;

        // Check if there is a file name with today as path file name
        if (File.Exists("DataSources/RondleidingLogNames.json"))
        {
            string existingJson = File.ReadAllText("DataSources/RondleidingLogNames.json");
            logEntries = JsonSerializer.Deserialize<List<string>>(existingJson) ?? new List<string>();
        }
        else
        {
            logEntries = new List<string>();
        }

        if (logEntries.Contains($"RondleidingLog/{dateTime}.json"))
        {
            FilePathSchedule = $"RondleidingLog/{dateTime}.json";
        }
        else
        {
            // if not then make the file
            DateTime starTime = new DateTime(date.Year, date.Month, date.Day, 11, 00, 00);
            DateTime endTime = new DateTime(date.Year, date.Month, date.Day, 17, 20, 00);
            List<Tour> tours = new();
            int id = 0;
            while (starTime < endTime)
            {
                Tour newT = new Tour(id.ToString(), starTime.ToString("HH:mm"), new List<string>(), new List<string>());
                tours.Add(newT);
                id+=1;
                starTime = starTime.AddMinutes(20);

            } 
            string jsonString = JsonSerializer.Serialize(tours, new JsonSerializerOptions { WriteIndented = true });

            File.WriteAllText($"RondleidingLog/{dateTime}.json", jsonString);
            // add name to list
            string filePath = $"RondleidingLog/{dateTime}.json";
            logEntries.Add(filePath);
            File.WriteAllText("DataSources/RondleidingLogNames.json", JsonSerializer.Serialize(logEntries, new JsonSerializerOptions { WriteIndented = true }));

            FilePathSchedule = $"RondleidingLog/{dateTime}.json";

        }

        // if yes then  use the file path for todays tour list

   

        // Method logic here
        // Read the entire content of the file as a single string
        string fileContents = Program.world.ReadAllText("" + FilePathSchedule);

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