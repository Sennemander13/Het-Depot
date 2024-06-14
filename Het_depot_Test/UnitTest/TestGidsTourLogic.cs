using System.Text.Json;

[TestClass]
public class TestGidsTourLogic
{
    [TestMethod]
    public void TestShow2Lists()
    {
        FakeWorld world = new();
        Program.world = world;

        GidsTourLogic.show2lists(DataModel.listoftours[5]);
        foreach (string s in world.LinesWritten) { Console.WriteLine(s); }
        Assert.AreEqual(true, world.LinesWritten.Contains("Gereserveerde mensen:        Ingecheckte mensen:"));
        Assert.AreEqual(true, world.LinesWritten.Contains("2222                         2222"));
    }


    [TestMethod]
    public void TestAddBezoeker()
    {
        FakeWorld world = new();
        Program.world = world;
        
        GidsTourLogic.AddID("4444",DataModel.listoftours[5]);
        foreach (string s in world.LinesWritten) { Console.WriteLine(s); }
        Assert.AreEqual(true, world.LinesWritten.Contains("Bezoeker is ingecheckt voor rondleiding"));
        Assert.AreEqual(true, world.LinesWritten.Contains("Code is geldig"));
    }

    public void TestAddBezoekerHasTakenTour()
    {
        FakeWorld world = new();
        Program.world = world;

        GidsTourLogic.AddID("2222",DataModel.listoftours[5]);
        foreach (string s in world.LinesWritten) { Console.WriteLine(s); }
        Assert.AreEqual(true, world.LinesWritten.Contains("Bezoeker heeft al een rondleiding gehad"));
        Assert.AreEqual(true, world.LinesWritten.Contains("Code is geldig"));
    }

    public void TestAddInvalidBezoeker()
    {
        FakeWorld world = new();
        Program.world = world;

        GidsTourLogic.AddID("",DataModel.listoftours[5]);
        foreach (string s in world.LinesWritten) { Console.WriteLine(s); }
        Assert.AreEqual(true, world.LinesWritten.Contains("Code is ongeldig"));
    }
}