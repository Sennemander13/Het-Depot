using System.Text.Json;

[TestClass]
public class TestAfdelingshoofdLogic
{

    [TestMethod]
    public void TestInlogSuccesfull()
    {
        FakeWorld world = new()
        {
            LinesToRead = new List<string>() { "99999", "E", "quit" }
        };
        Program.world = world;

        Program.Main();
        Assert.AreEqual(true, world.LinesWritten.Contains("Welkom, AfdelingsHoofd"));
    }

    public void TestAfdelingshoofdDisplay()
    {
        FakeWorld world = new();
        Program.world = world;

        Afdelingshoofd.Display();

        Assert.AreEqual(true, world.LinesWritten.Contains("Welkom, AfdelingsHoofd"));
        Assert.AreEqual(true, world.LinesWritten.Contains("[A]: Gidsen aan schema koppelen"));
        Assert.AreEqual(true, world.LinesWritten.Contains("[B]: Nieuwe codes invoeren"));
        Assert.AreEqual(true, world.LinesWritten.Contains("[C]: Gids lijst aanpassen"));
        Assert.AreEqual(true, world.LinesWritten.Contains("[D]: Schema aanpassen"));
        Assert.AreEqual(true, world.LinesWritten.Contains("[E]: Log uit"));
    }

    [TestMethod]
    public void TestKoppelGuide()
    {
        FakeWorld world = new()
        {
            LinesToRead = new List<string>() { "2", "", "2", "", "2", "", "3", "", "3", "", "4", "", "4", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" }
        };
        Program.world = world;

        AfdelingshoofdLogic.KoppelGidsen();
        foreach (string s in world.LinesWritten) { Console.WriteLine(s); }
        Assert.AreEqual(true, world.LinesWritten.Contains("Rondleiding: 0 | start om: 11:10, Gids: "));
        Assert.AreEqual(true, world.LinesWritten.Contains("Rondleiding: 1 | start om: 11:30, Gids: "));
        Assert.AreEqual(true, world.LinesWritten.Contains("Rondleiding: 2 | start om: 11:50, Gids: "));
        Assert.AreEqual(true, world.LinesWritten.Contains("Rondleiding: 3 | start om: 12:10, Gids: "));
        Assert.AreEqual(true, world.LinesWritten.Contains("Rondleiding: 4 | start om: 12:30, Gids: "));
        Assert.AreEqual(true, world.LinesWritten.Contains("Rondleiding: 5 | start om: 12:50, Gids: "));
        Assert.AreEqual(true, world.LinesWritten.Contains("Rondleiding: 6 | start om: 13:10, Gids: "));
        Assert.AreEqual(true, world.LinesWritten.Contains("Rondleiding: 7 | start om: 13:30, Gids: "));
        Assert.AreEqual(true, world.LinesWritten.Contains("Rondleiding: 8 | start om: 13:50, Gids: "));
        Assert.AreEqual(true, world.LinesWritten.Contains("Rondleiding: 9 | start om: 14:10, Gids: "));
        Assert.AreEqual(true, world.LinesWritten.Contains("Rondleiding: 10 | start om: 14:30, Gids: "));
        Assert.AreEqual(true, world.LinesWritten.Contains("Rondleiding: 11 | start om: 14:50, Gids: "));
        Assert.AreEqual(true, world.LinesWritten.Contains("Rondleiding: 12 | start om: 15:10, Gids: "));
        Assert.AreEqual(true, world.LinesWritten.Contains("Rondleiding: 13 | start om: 15:30, Gids: "));
        Assert.AreEqual(true, world.LinesWritten.Contains("Rondleiding: 14 | start om: 15:50, Gids: "));
        Assert.AreEqual(true, world.LinesWritten.Contains("Rondleiding: 15 | start om: 16:10, Gids: "));
        Assert.AreEqual(true, world.LinesWritten.Contains("Rondleiding: 16 | start om: 16:30, Gids: "));
        Assert.AreEqual(true, world.LinesWritten.Contains("Rondleiding: 17 | start om: 16:50, Gids: "));
        Assert.AreEqual(true, world.LinesWritten.Contains("Gidsen gekoppeld aan de rondleidingen van vandaag\nDruk Enter"));

        Assert.AreEqual(true, DataModel.listoftours[0].GuideCode == "2");
        Assert.AreEqual(true, DataModel.listoftours[1].GuideCode == "2");
        Assert.AreEqual(true, DataModel.listoftours[2].GuideCode == "2");
        Assert.AreEqual(true, DataModel.listoftours[3].GuideCode == "3");
        Assert.AreEqual(true, DataModel.listoftours[4].GuideCode == "3");
        Assert.AreEqual(true, DataModel.listoftours[5].GuideCode == "4");
        Assert.AreEqual(true, DataModel.listoftours[6].GuideCode == "4");


    }

    [TestMethod]
    public void TestBezoekerCodeDisplay()
    {
        FakeWorld world = new()
        {
            LinesToRead = new List<string>() { "C" }
        };
        Program.world = world;

        AfdelingshoofdLogic.UniekeCodesAanpassen();
        foreach (string s in world.LinesWritten) { Console.WriteLine(s); }
        Assert.AreEqual(true, world.LinesWritten.Contains("Lijst van unieke code's op dit moment:"));
        Assert.AreEqual(true, world.LinesWritten.Contains("1111"));
        Assert.AreEqual(true, world.LinesWritten.Contains("4444"));
        Assert.AreEqual(true, world.LinesWritten.Contains("2222"));
        Assert.AreEqual(true, world.LinesWritten.Contains("3333"));

        Assert.AreEqual(true, world.LinesWritten.Contains("[A]: Leeghalen"));
        Assert.AreEqual(true, world.LinesWritten.Contains("[B]: Toevoegen"));
        Assert.AreEqual(true, world.LinesWritten.Contains("[C]: Terug"));
    }

    [TestMethod]
    public void TestGuideCodesDisplay()
    {
        FakeWorld world = new()
        {
            LinesToRead = new List<string>() { "C" }
        };
        Program.world = world;

        AfdelingshoofdLogic.GidsenAanpassen();
        Assert.AreEqual(true, world.LinesWritten.Contains("Lijst van huidige gidsen:"));
        Assert.AreEqual(true, world.LinesWritten.Contains("2"));
        Assert.AreEqual(true, world.LinesWritten.Contains("3"));
        Assert.AreEqual(true, world.LinesWritten.Contains("4"));
        Assert.AreEqual(true, world.LinesWritten.Contains("5"));

        Assert.AreEqual(true, world.LinesWritten.Contains("Wat wilt u doen met deze lijst:"));
        Assert.AreEqual(true, world.LinesWritten.Contains("[A]: Gids toevoegen"));
        Assert.AreEqual(true, world.LinesWritten.Contains("[B]: Gids verwijderen"));
    }


    [TestMethod]
    public void TestAfdelingshoofdDisplayRondleidingen()
    {
        FakeWorld world = new()
        {
            LinesToRead = new List<string>() { "" }
        };
        Program.world = world;

        AfdelingshoofdLogic.SchemaAanpassen();
        foreach (string t in world.LinesWritten)
        { Console.WriteLine(t); }
        Assert.AreEqual(true, world.LinesWritten.Contains("|0|11:10, 13 plekken vrij | Gids: 2"));
        Assert.AreEqual(true, world.LinesWritten.Contains("|1|11:30, 13 plekken vrij | Gids: 2"));
        Assert.AreEqual(true, world.LinesWritten.Contains("|2|11:50, 13 plekken vrij | Gids: 2"));
        Assert.AreEqual(true, world.LinesWritten.Contains("|3|12:10, 13 plekken vrij | Gids: 3"));
        Assert.AreEqual(true, world.LinesWritten.Contains("|4|12:30, 13 plekken vrij | Gids: 3"));
        Assert.AreEqual(true, world.LinesWritten.Contains("|5|12:50, 12 plekken vrij | Gids: 4"));
        Assert.AreEqual(true, world.LinesWritten.Contains("|6|13:10, 13 plekken vrij | Gids: 4"));
        Assert.AreEqual(true, world.LinesWritten.Contains("|7|13:30, 13 plekken vrij | Gids: "));
        Assert.AreEqual(true, world.LinesWritten.Contains("|8|13:50, 13 plekken vrij | Gids: "));
        Assert.AreEqual(true, world.LinesWritten.Contains("|9|14:10, 13 plekken vrij | Gids: "));
        Assert.AreEqual(true, world.LinesWritten.Contains("|10|14:30, 13 plekken vrij | Gids: "));
        Assert.AreEqual(true, world.LinesWritten.Contains("|11|14:50, 13 plekken vrij | Gids: "));
        Assert.AreEqual(true, world.LinesWritten.Contains("|12|15:10, 13 plekken vrij | Gids: "));
        Assert.AreEqual(true, world.LinesWritten.Contains("|13|15:30, 13 plekken vrij | Gids: "));
        Assert.AreEqual(true, world.LinesWritten.Contains("|14|15:50, 13 plekken vrij | Gids: "));
        Assert.AreEqual(true, world.LinesWritten.Contains("|15|16:10, 13 plekken vrij | Gids: "));
        Assert.AreEqual(true, world.LinesWritten.Contains("|16|16:30, 13 plekken vrij | Gids: "));
        Assert.AreEqual(true, world.LinesWritten.Contains("|17|16:50, 13 plekken vrij | Gids: "));
        Assert.AreEqual(true, world.LinesWritten.Contains("[A]: Rondleiding toevoegen"));
        Assert.AreEqual(true, world.LinesWritten.Contains("[B]: Aanpassen/Verwijderen"));
        Assert.AreEqual(true, world.LinesWritten.Contains("Druk enter om terug te gaan"));
    }

}