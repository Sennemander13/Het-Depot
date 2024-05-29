namespace Het_depot_Test;

[TestClass]
public class GidsTest
{

    [TestMethod]
    [DataRow("2,A,1,A,1111,1010,,B,C,quit")]
    public void TestGidsRondleidingStarten(string inputString)
    {
        string[] splitArray = inputString.Split(',');
        FakeWorld world = new()
        {
            Now = new DateTime(2024, 05, 15),
            LinesToRead = new List<string>(splitArray),
            Files = new()
            {
                { "DataSources/UniqueCodesToday.json", "[\"1111\", \"1010\", \"2222\", \"3333\"]" },
                { "RondleidingLog/default.json", "[{\"Id\": \"1\", \"Start\": \"11:40\", \"End\": \"12:20\", \"Spots\": [], \"HasTakenTour\": [], \"GuideCode\": \"\"}, {\"Id\": \"2\", \"Start\": \"12:40\", \"End\": \"13:20\", \"Spots\": [], \"HasTakenTour\": [], \"GuideCode\": \"\"}]"},
                { "DataSources/GidsCodes.json", "[\"1\", \"2\"]"}
            }
        };
        Program.world = world;

        Program.Main();

        Assert.AreEqual(true, world.LinesWritten.Contains("                             1111"));
        Assert.AreEqual(true, world.LinesWritten.Contains("                             1010"));
        // Assert.AreEqual(true, )
    }

    // [TestMethod]
    // [DataRow("2,A,1,A,1111,,A,1010,,B,C,quit")]
    // public void TestGidsystem(string inputString)
    // {
    //     string[] splitArray = inputString.Split(',');
    //     FakeWorld world = new()
    //     {
    //         Now = new DateTime(2024, 05, 15),
    //         LinesToRead = new List<string>(splitArray),
    //         Files = new()
    //         {
    //             { "DataSources/UniqueCodesToday.json", "[\"1111\", \"1010\", \"2222\", \"3333\"]" },
    //             { "RondleidingLog/2024-05-15-2024-06-05.json", "[{\"Id\": \"1\", \"Start\": \"11:40\", \"End\": \"12:20\", \"Spots\": [], \"HasTakenTour\": [], \"GuideCode\": \"\"}, {\"Id\": \"2\", \"Start\": \"12:40\", \"End\": \"13:20\", \"Spots\": [], \"HasTakenTour\": [], \"GuideCode\": \"\"}]"},
    //             { "DataSources/GidsCodes.json", "[\"1\", \"2\"]"}
    //         }
    //     };
    //     Program.world = world;

    //     Program.Main();


    // }

    // [TestMethod]
    // [DataRow("")]
    // public void TestGidsystem(string inputString)
    // {
    //     string[] splitArray = inputString.Split(',');
    //     FakeWorld world = new()
    //     {
    //         Now = new DateTime(2024, 05, 15),
    //         LinesToRead = new List<string>(splitArray),
    //         Files = new()
    //         {
    //             { "DataSources/UniqueCodesToday.json", "[\"1111\", \"1010\", \"2222\", \"3333\"]" },
    //             { "RondleidingLog/2024-05-15-2024-06-05.json", "[{\"Id\": \"1\", \"Start\": \"11:40\", \"End\": \"12:20\", \"Spots\": [], \"HasTakenTour\": [], \"GuideCode\": \"\"}, {\"Id\": \"2\", \"Start\": \"12:40\", \"End\": \"13:20\", \"Spots\": [], \"HasTakenTour\": [], \"GuideCode\": \"\"}]"},
    //             { "DataSources/GidsCodes.json", "[\"1\", \"2\"]"}
    //         }
    //     };
    //     Program.world = world;

    //     Program.Main();



    // }
}