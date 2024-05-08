[TestClass]
public class TestGidsLogic
{
    [TestMethod]
    public void TestChoosingTour()
    {
        FakeWorld world = new()
        {
            Now = new DateTime(2004, 08, 25),
            LinesToRead = new List<string>() { "2", "A", "1", "B", "C", "quit" },
            Files = new()
            {
                { "DataSources/UniqueCodesToday.json", "[\"1111\", \"1010\"]" },
                { "DataSources/ListOfTours.json", "[{\"Id\": \"1\", \"Start\": \"11:40\", \"End\": \"12:20\", \"Spots\": [], \"HasTakenTour\": []}, {\"Id\": \"2\", \"Start\": \"12:40\", \"End\": \"13:20\", \"Spots\": [], \"HasTakenTour\": []}]"},
                { "DataSources/GidsCodes.json", "[\"1\", \"2\"]"}
            }
        };
        Program.world = world;

        Program.Main();

        Assert.AreEqual(true, world.LinesWritten.Contains("Kies een taak om uit te voeren:"));
        Assert.AreEqual("1", GidsTour.tour.Id);
    }

    [TestMethod]
    public void TestEmptyingTours()
    {
        FakeWorld world = new()
        {
            Now = new DateTime(2004, 08, 25),
            LinesToRead = new List<string>() { "2", "B", "B", "C", "quit" },
            Files = new()
            {
                { "DataSources/UniqueCodesToday.json", "[\"1111\", \"1010\"]" },
                { "DataSources/ListOfTours.json", "[{\"Id\": \"1\", \"Start\": \"11:40\", \"End\": \"12:20\", \"Spots\": [\"a\",\"b\",\"c\",\"d\",\"e\"], \"HasTakenTour\": []}, {\"Id\": \"2\", \"Start\": \"12:40\", \"End\": \"13:20\", \"Spots\": [], \"HasTakenTour\": [\"a\",\"b\",\"c\",\"d\",\"e\"]}]"},
                { "DataSources/GidsCodes.json", "[\"1\", \"2\"]"}
            }
        };
        Program.world = world;

        Program.Main();

        bool t = true;
        foreach (Tour tour in DataModel.listoftours)
        {
            if (tour.Spots.Count != 0 || tour.HasTakenTour.Count != 0)
            {
                t = false;
                break;
            }
        }
    }
}