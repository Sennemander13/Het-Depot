// namespace UnitTest;
using System.Text.Json;
[TestClass]
public class BaseLogicTest
{
    [TestMethod]
    [DataRow("1111", "B", true, "Welkom 1111")]
    [DataRow("1", "C", true, "Welkom 1")] // gids
    [DataRow("99999", "D", true, "Welkom AfdelingsHoofd")] // afdelingshoofd
    public void LoginTest(string code, string ToLogOut, bool TorF, string expected)
    {
        FakeWorld world = new()
        {
            Now = new DateTime(2004, 08, 25),
            LinesToRead = new List<string>() {code, ToLogOut, "quit"},
            Files = new()
            {
                { "DataSources/UniqueCodesToday.json", "[\"1111\", \"1010\"]" },
                { "DataSources/ListOfTours.json", "[{\"Id\": \"1\", \"Start\": \"11:40\", \"End\": \"12:20\", \"Spots\": [], \"HasTakenTour\": []}, {\"Id\": \"2\", \"Start\": \"12:40\", \"End\": \"13:20\", \"Spots\": [], \"HasTakenTour\": []}]"},
                { "DataSources/GidsCodes.json", "[\"1\", \"2\"]"}
            }
        };

        Program.world = world;
        Program.Main();
        Assert.AreEqual(TorF, world.LinesWritten.Contains(expected));
    }

    [TestMethod]
    [DataRow("1111", true)]
    [DataRow("1010", true)]
    [DataRow("2222", false)]
    public void TestValidBezoekerCode(string code, bool expected)
    {
        FakeWorld world = new()
        {
            Now = new DateTime(2004, 08, 25),
            LinesToRead = new List<string>() {},
            Files = new()
            {
                { "DataSources/UniqueCodesToday.json", "[\"1111\", \"1010\"]" },
                { "DataSources/ListOfTours.json", "[{\"Id\": \"1\", \"Start\": \"11:40\", \"End\": \"12:20\", \"Spots\": [], \"HasTakenTour\": []}, {\"Id\": \"2\", \"Start\": \"12:40\", \"End\": \"13:20\", \"Spots\": [], \"HasTakenTour\": []}]"},
                { "DataSources/GidsCodes.json", "[\"1\", \"2\"]"}
            }
        };
        List<string> list = JsonSerializer.Deserialize<List<string>>(world.ReadAllText("DataSources/UniqueCodesToday.json"));
        Assert.AreEqual(expected, BaseLogic.IsValidCode(code, list));
    }

    [TestMethod]
    [DataRow("1", true)]
    [DataRow("2", true)]
    [DataRow("3", false)]
    public void TestValidGidsCode(string code, bool expected)
    {
        FakeWorld world = new()
        {
            Now = new DateTime(2004, 08, 25),
            LinesToRead = new List<string>() {},
            Files = new()
            {
                { "DataSources/UniqueCodesToday.json", "[\"1111\", \"1010\"]" },
                { "DataSources/ListOfTours.json", "[{\"Id\": \"1\", \"Start\": \"11:40\", \"End\": \"12:20\", \"Spots\": [], \"HasTakenTour\": []}, {\"Id\": \"2\", \"Start\": \"12:40\", \"End\": \"13:20\", \"Spots\": [], \"HasTakenTour\": []}]"},
                { "DataSources/GidsCodes.json", "[\"1\", \"2\"]"}
            }
        };
        List<string> list = JsonSerializer.Deserialize<List<string>>(world.ReadAllText("DataSources/GidsCodes.json"));
        Assert.AreEqual(expected, BaseLogic.IsValidCode(code, list));
    }

    [TestMethod]
    public void TestDisplayRondleidingen()
    {
        FakeWorld world = new()
        {
            Now = new DateTime(2004, 08, 25),
            LinesToRead = new List<string>() {},
            Files = new()
            {
                { "DataSources/UniqueCodesToday.json", "[\"1111\", \"1010\"]" },
                { "DataSources/ListOfTours.json", "[{\"Id\": \"1\", \"Start\": \"11:40\", \"End\": \"12:20\", \"Spots\": [], \"HasTakenTour\": []}, {\"Id\": \"2\", \"Start\": \"12:40\", \"End\": \"13:20\", \"Spots\": [], \"HasTakenTour\": []}]"},
                { "DataSources/GidsCodes.json", "[\"1\", \"2\"]"}
            }
        };
        Program.world = world;
        BaseLogic.DisplayRondleidingen();
        
        Assert.AreEqual(true, world.LinesWritten.Contains("|1|11:40 - 12:20, 0/13"));
        Assert.AreEqual(true, world.LinesWritten.Contains("|2|12:40 - 13:20, 0/13"));
    }
}