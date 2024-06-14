using System.Text.Json;

[TestClass]
public class BezoekerLogicTest
{
    [TestMethod]
    [DataRow("1111,B,quit")]
    public void TestInlogSuccesfull(string inputString)
    {
        string[] splitArray = inputString.Split(',');
        FakeWorld world = new()
        {
            LinesToRead = new List<string>(splitArray),
        };
        Program.world = world;

        Program.Main();
        Assert.AreEqual(default, Bezoeker.BezoekerCode);
    }

    [TestMethod]
    [DataRow("1000,quit")]
    public void TestInlogUnsuccesfull(string inputString)
    {
        string[] splitArray = inputString.Split(',');
        FakeWorld world = new()
        {
            LinesToRead = new List<string>(splitArray),
        };
        Program.world = world;

        Program.Main();
        Assert.AreEqual(false, world.LinesWritten.Contains("Welkom, 1000"));
    }

    [TestMethod]
    public void TestBezoekerRondleidingSelect()
    {
        FakeWorld world = new()
        {
            LinesToRead = new List<string>() { "1", "N" }
        };
        Program.world = world;

        BezoekersLogic.BezoekersMenuOption("A");

        Assert.AreEqual(true, BezoekerTour.tour == DataModel.listoftours[1]);
        Assert.AreEqual(true, world.LinesWritten.Contains("Kies een Rondleiding (id): "));
        Assert.AreEqual(true, world.LinesWritten.Contains("Wilt u op deze rondleiding een plaats reserveren?"));
    }

}