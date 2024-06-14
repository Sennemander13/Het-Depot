
[TestClass]
public class BezoekersTest
{
    [TestMethod]
    public void TestTourBooking()
    {
        FakeWorld world = new()
        {
            LinesToRead = new List<string>() { "1111", "A", "1", "Y", "", "B", "quit" }
        };
        Program.world = world;
        Program.Main();
        foreach (string l in world.LinesWritten)
        {
            Console.WriteLine(l);
        }

        Assert.AreEqual(true, BezoekerTour.tour == DataModel.listoftours[1]);
        Assert.AreEqual(true, world.LinesWritten.Contains("Kies een Rondleiding (id): "));
        Assert.AreEqual(true, world.LinesWritten.Contains("Wilt u op deze rondleiding een plaats reserveren?"));
        Assert.AreEqual(true, world.LinesWritten.Contains("[Y]: Reserveren"));
        Assert.AreEqual(true, world.LinesWritten.Contains("Reserveren voltooid!"));
        Assert.AreEqual(true, world.LinesWritten.Contains("Druk Enter"));
        Assert.AreEqual(true, world.ReadAllText("RondleidingLog/14-06-2024.json").Contains(@"{""Id"":""1"",""Start"":""11:30"",""Spots"":[""1111""],""HasTakenTour"":[],""GuideCode"":""""}"));

        Assert.IsTrue(world.LinesWritten.Contains("|1|11:30, 12 plekken vrij"));
    }


    [TestMethod]
    public void TestRebooking()
    {
        FakeWorld world = new()
        {
            LinesToRead = new List<string>() { "1111", "A", "2", "Y", "", "B", "quit" }
        };
        Program.world = world;
        Program.Main();
        foreach (string l in world.LinesWritten)
        {
            Console.WriteLine(l);
        }

        Assert.AreEqual(true, BezoekerTour.tour == DataModel.listoftours[2]);
        Assert.AreEqual(true, world.LinesWritten.Contains("Kies een Rondleiding (id): "));
        Assert.AreEqual(true, world.LinesWritten.Contains("U heeft al gereserveerd op de rondleiding van 11:30"));
        Assert.AreEqual(true, world.LinesWritten.Contains("Wilt u herboeken naar deze rondleiding?"));
        Assert.AreEqual(true, world.LinesWritten.Contains("[Y]: Herboeken"));
        Assert.AreEqual(true, world.LinesWritten.Contains("Herboeken voltooid!"));
        Assert.AreEqual(true, world.LinesWritten.Contains("Druk Enter"));

        Assert.AreEqual(false, world.ReadAllText("RondleidingLog/14-06-2024.json").Contains(@"{""Id"":""1"",""Start"":""11:30"",""Spots"":[""1111""],""HasTakenTour"":[],""GuideCode"":""""}"));
        Assert.AreEqual(true, world.ReadAllText("RondleidingLog/14-06-2024.json").Contains(@"{""Id"":""2"",""Start"":""11:50"",""Spots"":[""1111""],""HasTakenTour"":[],""GuideCode"":""""}"));

        Assert.IsTrue(world.LinesWritten.Contains("|2|11:50, 12 plekken vrij"));

    }


    [TestMethod]
    public void TestAlreadyReserved()
    {
        FakeWorld world = new()
        {
            LinesToRead = new List<string>() { "1111", "A", "2", "Y", "", "B", "quit" }
        };
        Program.world = world;
        Program.Main();
        foreach (string l in world.LinesWritten)
        {
            Console.WriteLine(l);
        }
        Assert.AreEqual(true, BezoekerTour.tour == DataModel.listoftours[2]);
        Assert.AreEqual(true, world.LinesWritten.Contains("Kies een Rondleiding (id): "));
        Assert.AreEqual(true, world.LinesWritten.Contains("[Y]: Uitschrijven"));
        Assert.AreEqual(true, world.LinesWritten.Contains("Uitschrijven voltooid!"));
        Assert.AreEqual(true, world.LinesWritten.Contains("Druk Enter"));
        Assert.AreEqual(false, world.ReadAllText("RondleidingLog/14-06-2024.json").Contains(@"{""Id"":""2"",""Start"":""11:50"",""Spots"":[""1111""],""HasTakenTour"":[],""GuideCode"":""""}"));
        Assert.IsTrue(world.LinesWritten.Contains("|2|11:50, 13 plekken vrij"));
        Assert.IsTrue(false);

    }
}