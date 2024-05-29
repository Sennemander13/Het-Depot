namespace Het_depot_Test;

[TestClass]
public class BezoekrsTest
{

    [TestMethod]
    [DataRow("1010,A,1,y,A,2,y,A,2,y,B,quit")]
    public void TestBezoekerSystem(string inputString)
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

        foreach (string l in world.LinesWritten)
        {
            Console.WriteLine(l);
        }
        Assert.AreEqual(true, world.LinesWritten.Contains("Wilt u op deze rondleiding een plaats reserveren? (y/n)"));
        Assert.AreEqual(true, world.LinesWritten.Contains("Wilt u herboeken naar deze rondleiding? (y/n)"));
        Assert.AreEqual(true, world.LinesWritten.Contains("U heeft al gereserveerd op deze rondleiding"));

    }
}