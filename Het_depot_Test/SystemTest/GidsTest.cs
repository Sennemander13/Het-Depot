[TestClass]
public class GidsTest2
{

    [TestMethod]
    public void TestGidsRondleidingStarten()
    {
        FakeWorld world = new()
        {
            LinesToRead = new List<string>() { "2", "A", "5", "A", "2222", "", "A", "4444", "", "B", "B", "quit" }
        };
        Program.world = world;
        Program.Main();
        foreach (string l in world.LinesWritten)
        {
            Console.WriteLine(l);
        }
        Assert.AreEqual(true, GidsTour.tour == DataModel.listoftours[5]);
        Assert.AreEqual(true, world.LinesWritten.Contains("Kies een Rondleiding (id): "));
        Assert.AreEqual(true, world.LinesWritten.Contains("Wilt u op deze rondleiding een plaats reserveren?"));
        Assert.AreEqual(true, world.LinesWritten.Contains("Bezoeker is ingecheckt voor rondleiding"));
        Assert.AreEqual(true, world.LinesWritten.Contains("Code is geldig"));
        Assert.AreEqual(true, world.LinesWritten.Contains("2222                         2222"));
        Assert.AreEqual(true, world.LinesWritten.Contains("                             4444"));
    }

}