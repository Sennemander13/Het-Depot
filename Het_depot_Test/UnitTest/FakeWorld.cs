public class FakeWorld : IWorld
{
    private DateTime _now = new DateTime(2024, 6, 14);

    public DateTime Now
    {
        get => _now;
        set => _now = value;
    }

    public void Clear()
    {
        // Console.Clear();
    }

    public void Write(string text)
    {
        // Console.Write(text);
        LinesWritten.Add(text);
    }

    public List<string> LinesWritten { get; } = new();

    public void WriteLine(string line)
    {
        LinesWritten.Add(line);
    }

    public List<string> LinesToRead { private get; set; } = new List<string>();

    public string ReadLine()
    {
        string firstLine = LinesToRead[0];
        LinesToRead.RemoveAt(0);
        return firstLine;
    }

    public Dictionary<string, string> Files = new()
    {
        { "DataSources/UniqueCodesToday.json", "[\"1111\",\"4444\",\"2222\",\"3333\"]" },
        { "DataSources/beep-07a.wav", ""},
        { "DataSources/GidsCodes.json", "[\"2\",\"3\",\"4\",\"5\"]" },
        { "DataSources/RondleidingLogNames.json", "[\"RondleidingLog/14-06-2024.json\",\"RondleidingLog/13-06-2024.json\"]"},
        { "RondleidingLog/14-06-2024.json", "[{\"Id\": \"0\", \"Start\": \"11:10\", \"Spots\": [], \"HasTakenTour\": [], \"GuideCode\": \"\"},{\"Id\": \"1\", \"Start\": \"11:30\", \"Spots\": [], \"HasTakenTour\": [], \"GuideCode\": \"\"},{\"Id\": \"2\", \"Start\": \"11:50\", \"Spots\": [], \"HasTakenTour\": [], \"GuideCode\": \"\"},{\"Id\": \"3\", \"Start\": \"12:10\", \"Spots\": [], \"HasTakenTour\": [], \"GuideCode\": \"\"},{\"Id\": \"4\", \"Start\": \"12:30\", \"Spots\": [], \"HasTakenTour\": [], \"GuideCode\": \"\"},{\"Id\": \"5\", \"Start\": \"12:50\", \"Spots\": [\"2222\"], \"HasTakenTour\": [\"2222\"], \"GuideCode\": \"\"},{\"Id\": \"6\", \"Start\": \"13:10\", \"Spots\": [], \"HasTakenTour\": [], \"GuideCode\": \"\"},{\"Id\": \"7\", \"Start\": \"13:30\", \"Spots\": [], \"HasTakenTour\": [], \"GuideCode\": \"\"},{\"Id\": \"8\", \"Start\": \"13:50\", \"Spots\": [], \"HasTakenTour\": [], \"GuideCode\": \"\"},{\"Id\": \"9\", \"Start\": \"14:10\", \"Spots\": [], \"HasTakenTour\": [], \"GuideCode\": \"\"},{\"Id\": \"10\", \"Start\": \"14:30\", \"Spots\": [], \"HasTakenTour\": [], \"GuideCode\": \"\"},{\"Id\": \"11\", \"Start\": \"14:50\", \"Spots\": [], \"HasTakenTour\": [], \"GuideCode\": \"\"},{\"Id\": \"12\", \"Start\": \"15:10\", \"Spots\": [], \"HasTakenTour\": [], \"GuideCode\": \"\"},{\"Id\": \"13\", \"Start\": \"15:30\", \"Spots\": [], \"HasTakenTour\": [], \"GuideCode\": \"\"},{\"Id\": \"14\", \"Start\": \"15:50\", \"Spots\": [], \"HasTakenTour\": [], \"GuideCode\": \"\"},{\"Id\": \"16\", \"Start\": \"16:10\", \"Spots\": [], \"HasTakenTour\": [], \"GuideCode\": \"\"},{\"Id\": \"16\", \"Start\": \"16:30\", \"Spots\": [], \"HasTakenTour\": [], \"GuideCode\": \"\"},{\"Id\": \"17\", \"Start\": \"16:50\", \"Spots\": [], \"HasTakenTour\": [], \"GuideCode\": \"\"}]"}
    };

    public bool Exists(string path)
    {
        return Files.ContainsKey(path);
    }

    public string ReadAllText(string path)
    {
        return Files[path];
    }

    public void WriteAllText(string path, string contents)
    {
        Files[path] = contents;
    }
}