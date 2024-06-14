[TestClass]
public class AfdelingshoofdTest
{

    [TestMethod]
    public void TestKoppelGuide()
    {
        FakeWorld world = new()
        {
            LinesToRead = new List<string>(){"99999","A","2","","2","","2","","3","","3","","4","","4","","","","","","","","","","","","","","","","","","","","","","","","","E","quit"}
        };
        Program.world = world;
        Program.Main();
        foreach (string l in world.LinesWritten)
        {
            Console.WriteLine(l);
        }
        Assert.AreEqual(true, world.LinesWritten.Contains("Welkom, AfdelingsHoofd"));
        Assert.AreEqual(true, world.LinesWritten.Contains("[A]: Gidsen aan schema koppelen"));
        Assert.AreEqual(true, world.LinesWritten.Contains("[B]: Nieuwe codes invoeren"));
        Assert.AreEqual(true, world.LinesWritten.Contains("[C]: Gids lijst aanpassen"));
        Assert.AreEqual(true, world.LinesWritten.Contains("[D]: Schema aanpassen"));
        Assert.AreEqual(true, world.LinesWritten.Contains("[E]: Log uit")); 

       
        Assert.AreEqual(true, DataModel.listoftours[0].GuideCode == "2");
        Assert.AreEqual(true, DataModel.listoftours[1].GuideCode == "2");
        Assert.AreEqual(true, DataModel.listoftours[2].GuideCode == "2");
        Assert.AreEqual(true, DataModel.listoftours[3].GuideCode == "3");
        Assert.AreEqual(true, DataModel.listoftours[4].GuideCode == "3");
        Assert.AreEqual(true, DataModel.listoftours[5].GuideCode == "4");
        Assert.AreEqual(true, DataModel.listoftours[6].GuideCode == "4");
        Assert.AreEqual(true, DataModel.listoftours[7].GuideCode == "");
        Assert.AreEqual(true, DataModel.listoftours[17].GuideCode == "");
    }


    [TestMethod]
    public void TestEmptyBezeoekers()
    {
        FakeWorld world = new()
        {
            LinesToRead = new List<string>(){"99999","B","B","E","quit"}
        };
        Program.world = world;
        Program.Main();
        foreach (string l in world.LinesWritten)
        {
            Console.WriteLine(l);
        }

        Assert.AreEqual(true, world.LinesWritten.Contains("Lijst van unieke code's op dit moment:"));
        Assert.AreEqual(true, world.LinesWritten.Contains("1111"));
        Assert.AreEqual(true, world.LinesWritten.Contains("4444"));
        Assert.AreEqual(true, world.LinesWritten.Contains("2222"));
        Assert.AreEqual(true, world.LinesWritten.Contains("3333"));

        Assert.AreEqual(true, world.LinesWritten.Contains("[A]: Leeghalen"));
        Assert.AreEqual(true, world.LinesWritten.Contains("[B]: Toevoegen"));
        Assert.AreEqual(true, world.LinesWritten.Contains("[C]: Terug"));

        Assert.IsTrue(DataModel.visitorCodes.Count == 0);
    }

    [TestMethod]
    public void TestAddCodeOneByOne()
    {
        FakeWorld world = new()
        {
            LinesToRead = new List<string>(){"99999","B","B","A","1010","","C","E","quit"}
        };
        Program.world = world;
        Program.Main();
        foreach (string l in world.LinesWritten)
        {
            Console.WriteLine(l);
        }
        Assert.AreEqual(true, world.LinesWritten.Contains("Lijst van unieke code's op dit moment:"));
        Assert.AreEqual(false, world.LinesWritten.Contains("1111"));
        Assert.AreEqual(false, world.LinesWritten.Contains("4444"));
        Assert.AreEqual(false, world.LinesWritten.Contains("2222"));
        Assert.AreEqual(false, world.LinesWritten.Contains("3333"));
        Assert.AreEqual(true, world.LinesWritten.Contains("[A]: Één voor Één code's toevoegen"));
        Assert.AreEqual(true, world.LinesWritten.Contains("Welke bezoeker code wilt u toe voegen:"));
        Assert.AreEqual(true, world.LinesWritten.Contains("Bezoekers codes toegevoegd"));


        Assert.AreEqual(true, world.LinesWritten.Contains("1010"));
    }

    [TestMethod]
    public void TestAddCodeCommaSeperated()
    {
        FakeWorld world = new()
        {
            LinesToRead = new List<string>(){"99999","B","B","B","0101,1000","","C","E","quit"}
        };
        Program.world = world;
        Program.Main();
        foreach (string l in world.LinesWritten)
        {
            Console.WriteLine(l);
        }

        Assert.AreEqual(true, world.LinesWritten.Contains("Lijst van unieke code's op dit moment:"));
        Assert.AreEqual(true, world.LinesWritten.Contains("1010"));

        Assert.AreEqual(true, world.LinesWritten.Contains("[B]: Meerdere code's toevoegen"));
        Assert.AreEqual(true, world.LinesWritten.Contains("Format: code,code,code,..."));
        Assert.AreEqual(true, world.LinesWritten.Contains("Format: code,code,code,..."));

        Assert.AreEqual(true, world.LinesWritten.Contains("Bezoekers codes toegevoegd"));   
        Assert.AreEqual(true, world.LinesWritten.Contains("0101"));
        Assert.AreEqual(true, world.LinesWritten.Contains("1000"));
    }

    [TestMethod]
    public void TestAddGuideCode()
    {
        FakeWorld world = new()
        {
            LinesToRead = new List<string>(){"99999","C","A","10","","C","E","quit"}
        };
        Program.world = world;
        Program.Main();
        foreach (string l in world.LinesWritten)
        {
            Console.WriteLine(l);
        }

        Assert.AreEqual(true, world.LinesWritten.Contains("Lijst van huidige gidsen:"));
        Assert.AreEqual(true, world.LinesWritten.Contains("2"));
        Assert.AreEqual(true, world.LinesWritten.Contains("3"));
        Assert.AreEqual(true, world.LinesWritten.Contains("4"));
        Assert.AreEqual(true, world.LinesWritten.Contains("5"));
        Assert.AreEqual(true, world.LinesWritten.Contains("[A]: Gids toevoegen"));
        Assert.AreEqual(true, world.LinesWritten.Contains("Welke code wilt u toevoegen: "));
        Assert.AreEqual(true, world.LinesWritten.Contains("Druk enter"));
        Assert.AreEqual(true, world.LinesWritten.Contains("10"));
        Assert.IsTrue(DataModel.guideCodes.Contains("10"));
    }

    [TestMethod]
    public void TestRemoveGuide()
    {
        FakeWorld world = new()
        {
            LinesToRead = new List<string>(){"99999","C","B","10","","C","E","quit"}
        };
        Program.world = world;
        Program.Main();
        foreach (string l in world.LinesWritten)
        {
            Console.WriteLine(l);
        }

        Assert.AreEqual(true, world.LinesWritten.Contains("Lijst van huidige gidsen:"));
        Assert.AreEqual(true, world.LinesWritten.Contains("2"));
        Assert.AreEqual(true, world.LinesWritten.Contains("3"));
        Assert.AreEqual(true, world.LinesWritten.Contains("4"));
        Assert.AreEqual(true, world.LinesWritten.Contains("5"));
        Assert.AreEqual(true, world.LinesWritten.Contains("10"));
        Assert.AreEqual(true, world.LinesWritten.Contains("[A]: Gids toevoegen"));
        Assert.AreEqual(true, world.LinesWritten.Contains("Welke code wilt u toevoegen: "));
        Assert.AreEqual(true, world.LinesWritten.Contains("Druk enter"));
        Assert.AreEqual(false, DataModel.guideCodes.Contains("10"));
    }

    [TestMethod]
    public void TestAddRondleiding()
    {
        FakeWorld world = new()
        {
            LinesToRead = new List<string>(){"99999","D","A","16:45","","","E","quit"}
        };
        Program.world = world;
        Program.Main();
        foreach (string l in world.LinesWritten)
        {
            Console.WriteLine(l);
        }
        Assert.AreEqual(true, world.LinesWritten.Contains("[A]: Rondleiding toevoegen"));
        Assert.AreEqual(true, world.LinesWritten.Contains("Op welke tijd wilt u een rondleiding toevoegen (Uur:Minuten): "));
        Assert.AreEqual(true, world.LinesWritten.Contains("Rondleiding toegevoegd"));
        Assert.AreEqual(true, world.LinesWritten.Contains("Druk Enter"));
        Assert.AreEqual(true, world.LinesWritten.Contains("|18|16:45, 13 plekken vrij | Gids: "));
    }

    [TestMethod]
    public void TestAdjustRondleiding()
    {
        FakeWorld world = new()
        {
            LinesToRead = new List<string>(){"99999","D","B","13","A","17:30","","","E","quit"}
        };
        Program.world = world;
        Program.Main();
        foreach (string l in world.LinesWritten)
        {
            Console.WriteLine(l);
        }
        Assert.AreEqual(true, world.LinesWritten.Contains("[B]: Aanpassen/Verwijderen"));
        Assert.AreEqual(true, world.LinesWritten.Contains("Welke Rondleiding wilt u aanpassen (id):"));
        Assert.AreEqual(true, world.LinesWritten.Contains("Wat wilt u doen met deze rondleiding"));
        Assert.AreEqual(true, world.LinesWritten.Contains("[A]: Tijd aanpassen"));
        Assert.AreEqual(true, world.LinesWritten.Contains("Naar welke tijd wilt u de rondleiding verplaatsen (Uur:Minuten): "));
        Assert.AreEqual(true, world.LinesWritten.Contains("Tijd veranderd"));

        Assert.AreEqual(true, world.LinesWritten.Contains("|13|17:30, 13 plekken vrij | Gids: "));

    }

    [TestMethod]
    public void TestRemoveRondleiding
    {
        FakeWorld world = new()
        {
            LinesToRead = new List<string>(){"99999","D","B","13","B","","","E","quit"}
        };
        Program.world = world;
        Program.Main();
        foreach (string l in world.LinesWritten)
        {
            Console.WriteLine(l);
        }

        Assert.AreEqual(true, world.LinesWritten.Contains("[B]: Verwijderen"));
        Assert.AreEqual(true, world.LinesWritten.Contains("Rondleiding verwijderd"));        
    }   
}