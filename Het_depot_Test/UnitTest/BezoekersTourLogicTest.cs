using System.Text.Json;
// using Tour;
[TestClass]
public class BezoekerTourLogicTest
{
    [TestMethod]
    public void TestBookRondleiding()
    {
        FakeWorld world = new() { LinesToRead = new List<string>() { "Y", "" } };
        Program.world = world;

        BezoekerTourLogic.Reserveren("1111", DataModel.listoftours[1]);

        Console.WriteLine(world.LinesWritten.Count);
        foreach (string t in world.LinesWritten)
        { Console.WriteLine(t); }

        Assert.AreEqual(true, world.LinesWritten.Contains("Wilt u op deze rondleiding een plaats reserveren?"));
        Assert.AreEqual(true, world.LinesWritten.Contains("[Y]: Reserveren"));
        Assert.AreEqual(true, world.LinesWritten.Contains("Reserveren voltooid!"));
        Assert.AreEqual(true, world.LinesWritten.Contains("Druk Enter"));
        Assert.AreEqual(true, world.ReadAllText("RondleidingLog/14-06-2024.json").Contains(@"{""Id"":""1"",""Start"":""11:30"",""Spots"":[""1111""],""HasTakenTour"":[],""GuideCode"":""""}"));

    }

    [TestMethod]
    public void TestRebookRondleiding()
    {
        FakeWorld world = new()
        {
            LinesToRead = new List<string>() { "Y", "" }
        };
        Program.world = world;

        BezoekerTourLogic.herboeken("1111", DataModel.listoftours[2]);
        Console.WriteLine(world.LinesWritten.Count);
        foreach (string t in world.LinesWritten)
        { Console.WriteLine(t); }

        Assert.AreEqual(true, world.LinesWritten.Contains("U heeft al gereserveerd op de rondleiding van 11:30"));
        Assert.AreEqual(true, world.LinesWritten.Contains("Wilt u herboeken naar deze rondleiding?"));
        Assert.AreEqual(true, world.LinesWritten.Contains("[Y]: Herboeken"));
        Assert.AreEqual(true, world.LinesWritten.Contains("Herboeken voltooid!"));
        Assert.AreEqual(true, world.LinesWritten.Contains("Druk Enter"));

        Assert.AreEqual(false, world.ReadAllText("RondleidingLog/14-06-2024.json").Contains(@"{""Id"":""1"",""Start"":""11:30"",""Spots"":[""1111""],""HasTakenTour"":[],""GuideCode"":""""}"));
        Assert.AreEqual(true, world.ReadAllText("RondleidingLog/14-06-2024.json").Contains(@"{""Id"":""2"",""Start"":""11:50"",""Spots"":[""1111""],""HasTakenTour"":[],""GuideCode"":""""}"));
    }


    [TestMethod]
    public void TestCancel()
    {
        FakeWorld world = new()
        {
            LinesToRead = new List<string>() { "Y", "" }
        };
        Program.world = world;

        BezoekerTourLogic.Annuleren("1111", DataModel.listoftours[2]);
        Console.WriteLine(world.LinesWritten.Count);
        foreach (string t in world.LinesWritten)
        { Console.WriteLine(t); }

        Assert.AreEqual(true, world.LinesWritten.Contains("U heeft al gereserveerd op deze rondleiding"));
        Assert.AreEqual(true, world.LinesWritten.Contains("Wilt u zich uitschrijven?"));
        Assert.AreEqual(true, world.LinesWritten.Contains("[Y]: Uitschrijven"));
        Assert.AreEqual(true, world.LinesWritten.Contains("Uitschrijven voltooid!"));
        Assert.AreEqual(true, world.LinesWritten.Contains("Druk Enter"));

        Assert.AreEqual(false, world.ReadAllText("RondleidingLog/14-06-2024.json").Contains(@"{""Id"":""2"",""Start"":""11:50"",""Spots"":[""1111""],""HasTakenTour"":[],""GuideCode"":""""}"));

    }

}