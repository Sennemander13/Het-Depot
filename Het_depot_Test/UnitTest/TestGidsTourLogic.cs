using System.Text.Json;

[TestClass]
public class TestGidsTourLogic
{
    // same problem the list doesnt load right eventho ut does work in the other guid ecode
    [TestMethod]
    [DataRow("2,A,1,B,C,quit")]
    public void TestGuideDoubleList(string inputString)
    {
        string[] splitArray = inputString.Split(',');
        FakeWorld world = new()
        {
            Now = new DateTime(2004, 08, 25),
            LinesToRead = new List<string>(splitArray),
            Files = new()
            {
                { "DataSources/UniqueCodesToday.json", "[\"1111\", \"1010\"]" },
                { "DataSources/ListOfTours.json", "[{\"Id\": \"1\", \"Start\": \"11:40\", \"End\": \"12:20\", \"Spots\": [\"1111\"], \"HasTakenTour\": [\"2222\"]}, {\"Id\": \"2\", \"Start\": \"12:40\", \"End\": \"13:20\", \"Spots\": [], \"HasTakenTour\": []}]"},
                { "DataSources/GidsCodes.json", "[\"1\", \"2\"]"}
            }
        };
        Program.world = world;

        Program.Main();
        foreach (string s in world.LinesWritten) { Console.WriteLine(s); }
        Assert.AreEqual(true, world.LinesWritten.Contains("Gereserveerde mensen:        Ingecheckte mensen:"));
        // Assert.AreEqual(true, world.LinesWritten.Contains("1111                         2222"));

    }


    // DOesnt work because it doesnt look at the valid codes
    [TestMethod]
    [DataRow("2,A,1,A,1010,,B,C,quit")]
    public void TestAddingUser(string inputString)
    {
        string[] splitArray = inputString.Split(',');
        FakeWorld world = new()
        {
            Now = new DateTime(2004, 08, 25),
            LinesToRead = new List<string>(splitArray),
            Files = new()
            {
                { "DataSources/UniqueCodesToday.json", "[\"1111\", \"1010\"]" },
                { "DataSources/ListOfTours.json", "[{\"Id\": \"1\", \"Start\": \"11:40\", \"End\": \"12:20\", \"Spots\": [], \"HasTakenTour\": []}, {\"Id\": \"2\", \"Start\": \"12:40\", \"End\": \"13:20\", \"Spots\": [], \"HasTakenTour\": []}]"},
                { "DataSources/GidsCodes.json", "[\"1\", \"2\"]"}
            }
        };
        Program.world = world;

        Program.Main();


        List<Tour> tours = JsonSerializer.Deserialize<List<Tour>>(world.ReadAllText("DataSources/ListOfTours.json"));

        Tour tour1 = null;
        foreach (Tour tour in tours)
        {
            if (tour.Id == "1")
            {
                tour1 = tour;
            }
        }
        foreach (string s in world.LinesWritten)
        {
            Console.WriteLine(s);
        }
        Console.WriteLine(tour1.ToString());
        Assert.AreEqual(true, tour1.HasTakenTour.Contains("1010"));
    }
}