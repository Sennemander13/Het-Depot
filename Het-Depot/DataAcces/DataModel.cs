using System.Text.Json;
using System.Threading.Tasks.Dataflow;
public static class DataModel
{
    public static List<Tour> listoftours;
    public static List<string> visitorCodes;
    public static List<string> guideCodes;

    public static string FilePathSchedule = "RondleidingLog/default.json";
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
            DateTime starTime = new DateTime(date.Year, date.Month, date.Day, 11, 10, 00);
            DateTime endTime = new DateTime(date.Year, date.Month, date.Day, 17, 10, 00);
            List<Tour> tours = new();
            int id = 0;
            while (starTime < endTime)
            {
                Tour newT = new Tour(id.ToString(), starTime.ToString("HH:mm"), new List<string>(), new List<string>());
                tours.Add(newT);
                id += 1;
                starTime = starTime.AddMinutes(20);

            }
            string jsonString = JsonSerializer.Serialize(tours, new JsonSerializerOptions { WriteIndented = true });

            File.WriteAllText($"RondleidingLog/{dateTime}.json", jsonString);
            string filePath = $"RondleidingLog/{dateTime}.json";
            logEntries.Add(filePath);
            File.WriteAllText("DataSources/RondleidingLogNames.json", JsonSerializer.Serialize(logEntries, new JsonSerializerOptions { WriteIndented = true }));

            FilePathSchedule = $"RondleidingLog/{dateTime}.json";

        }


        string fileContents = Program.world.ReadAllText("" + FilePathSchedule);

        List<Tour> listOfTours = JsonSerializer.Deserialize<List<Tour>>(fileContents)!;

        listoftours = listOfTours;
    }


    public static void WriteToCurrentDayJSON<T>(List<T> ListToJson, string FilePath)
    {
        try
        {
            // Serialize the list to JSON
            string jsonString = JsonSerializer.Serialize(ListToJson);

            // Write the JSON string to the file
            File.WriteAllText(FilePath, jsonString);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
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