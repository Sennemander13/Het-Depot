using System.Text.Json;
// using Tour;
[TestClass]
public class BezoekerTourLogicTest
{
    [TestMethod]
    [DataRow("1010,A,1,y,B,quit")]
    public void TestBookingTour(string inputString)
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
        Assert.AreEqual("1", BezoekerTour.tour.Id);
        Assert.AreEqual(true, world.LinesWritten.Contains("Wilt u op deze rondleiding een plaats reserveren? (y/n)"));

        bool t = false;
        foreach (Tour tour in DataModel.listoftours)
        {
            if (tour.Spots.Contains("1010") && tour.Id == "1")
            {
                t = true;
                break;
            }
        }

        Assert.AreEqual(true, t);
    }

    [TestMethod]
    [DataRow("1010,A,2,y,B,quit")]
    public void TestRebook(string inputString)
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

        Assert.AreEqual("2", BezoekerTour.tour.Id);
        Assert.AreEqual(true, world.LinesWritten.Contains("Wilt u herboeken naar deze rondleiding? (y/n)"));
        bool t = false;
        foreach (Tour tour in DataModel.listoftours)
        {
            if (tour.Id == "1" && tour.Spots.Contains("1010"))
            {
                break;
            }
            if (tour.Spots.Contains("1010") && tour.Id == "2")
            {
                t = true;
                break;
            }
        }

        Assert.AreEqual(true, t);
    }


    [TestMethod]
    [DataRow("1010,A,2,y,B,quit")]
    public void TestCancel(string inputString)
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

        Assert.AreEqual("2", BezoekerTour.tour.Id);
        Assert.AreEqual(true, world.LinesWritten.Contains("U heeft al gereserveerd op deze rondleiding"));
        bool t = true;
        foreach (Tour tour in DataModel.listoftours)
        {
            if (tour.Id == "1" && tour.Spots.Contains("1010"))
            {
                t = false;
                break;
            }
            if (tour.Spots.Contains("1010") && tour.Id == "2")
            {
                t = false;
                break;
            }
        }

        Assert.AreEqual(true, t);
    }




    // [TestMethod]
    // [DataRow("1010,A,1,y,B,quit")]
    // public void TestHasTakenTour(string inputString)
    // {
    //     string[] splitArray = inputString.Split(',');
    //     // string joinedArray = string.Join(", ", splitArray);
    //     // Console.WriteLine($"Split array: {joinedArray}");

    //     FakeWorld world = new()
    //     {
    //         Now = new DateTime(2004, 08, 25),
    //         LinesToRead = new List<string>(splitArray),
    //         Files = new()
    //         {
    //             { "DataSources/UniqueCodesToday.json", "[\"1111\", \"1010\"]" },
    //             { "DataSources/ListOfTours.json", "[{\"Id\": \"1\", \"Start\": \"11:40\", \"End\": \"12:20\", \"Spots\": [], \"HasTakenTour\": [\"1010\"]}, {\"Id\": \"2\", \"Start\": \"12:40\", \"End\": \"13:20\", \"Spots\": [], \"HasTakenTour\": []}]"},
    //             { "DataSources/GidsCodes.json", "[\"1\", \"2\"]"}
    //         }
    //     };
    //     Program.world = world;
    //     Program.Main();
    //     foreach (string s in world.LinesWritten)
    //     {Console.WriteLine(s);}
    //     Assert.AreEqual(true, world.LinesWritten.Contains("11:40 - 12:20 is geselecteerd"));
    //     Assert.AreEqual(true, world.LinesWritten.Contains("U heeft al een rondleiding gedaan"));
    //     bool t = true;
    //     foreach (Tour tour in DataModel.listoftours)
    //     {
    //         if (tour.Id == "1" && tour.Spots.Contains("2222"))
    //         {
    //             t = false;
    //             break;
    //         }
    //         if (tour.HasTakenTour.Contains("1010"))
    //         {
    //             t = false;
    //             break;
    //         }
    //     }
    // }
}