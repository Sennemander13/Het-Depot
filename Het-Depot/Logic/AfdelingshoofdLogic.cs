public static class AfdelingshoofdLogic
{
    public static void MenuOptions(string userInput)
    {
        Console.Clear();
        if (userInput == "A")
        {
            KoppelGidsen();
        }
        else if (userInput == "B")
        {
            UniekeCodesAanpassen();
        }
        else if (userInput == "C")
        {
            GidsenAanpassen();
        }
        else if (userInput == "D")
        {
            SchemaAanpassen();
        }
    }

    private static void KoppelGidsen()
    {
        Program.world.WriteLine("Gidsen koppelen aan de rondleidingen van vandaag:");
        foreach (Tour tour in DataModel.listoftours)
        {
            Console.Clear();
            Program.world.WriteLine($"Rondleiding: {tour.Id} | start om: {tour.Start}, Gids: {tour.GuideCode}");
            Program.world.WriteLine("Wilt u op deze rondleiding een gids toevoegen");
            Program.world.WriteLine("Voer dan nu de gids code in en druk enter");
            Program.world.WriteLine("Zo niet dan Enter drukken om de volgende rondleiding te zien");
            string gidscode = Program.world.ReadLine();
            if (gidscode != "" && BaseLogic.IsValidCode(gidscode, DataModel.guideCodes)) { tour.GuideCode = gidscode; Program.world.WriteLine($"Gids {gidscode} gekoppeld aan rondleiding van {tour.Start}"); }
            else { Program.world.WriteLine("Gids code niet gekoppeld"); }
            Console.WriteLine("Druk enter om naar de volgende rondleiding te gaan");
            Program.world.ReadLine();
        }

        DataModel.WriteToCurrentDayJSON(DataModel.listoftours, DataModel.FilePathSchedule);
        Program.world.Write("Gidsen gekoppeld aan de rondleidingen van vandaag\nDruk Enter");
        Program.world.ReadLine();
    }

    private static void UniekeCodesAanpassen()
    {
        string keuze;
        do
        {
            Console.Clear();
            Program.world.WriteLine("Lijst van unieke code's op dit moment:");
            foreach (string ccode in DataModel.visitorCodes!)
            {
                Program.world.WriteLine(ccode);
            }
            Program.world.WriteLine("[A]: Leeghalen");
            Program.world.WriteLine("[B]: Toevoegen");
            Program.world.WriteLine("[C]: Terug");
            keuze = Program.world.ReadLine()!.ToUpper();
            if (keuze == "A")
            {
                UniekeCodesLeeghalen();
            }
            else if (keuze == "B")
            {
                UniekeCodesToevoegen();
            }
        } while (keuze != "C");
    }

    private static void UniekeCodesLeeghalen()
    {
        DataModel.visitorCodes = new List<string>();
        DataModel.WriteToCurrentDayJSON(DataModel.visitorCodes, "DataSources/UniqueCodesToday.json");
        Program.world.WriteLine("Bezoekers codes geleegd");
        Program.world.WriteLine("Druk Enter");
        Console.ReadLine();
    }

    private static void UniekeCodesToevoegen()
    {
        Program.world.WriteLine("[A]: Één voor Één code's toevoegen");
        Program.world.WriteLine("[B]: Meerdere code's toevoegen");
        Program.world.WriteLine("[C]: Terug");
        string keuze2 = Program.world.ReadLine()!.ToUpper();
        Console.Clear();
        if (keuze2 == "A")
        {
            CodesScannen();
        }
        else if (keuze2 == "B")
        {
            MeerdereCodes();
        }
    }

    private static void CodesScannen()
    {
        string code;
        do
        {
            Console.Clear();
            Program.world.WriteLine("Welke bezoeker code wilt u toe voegen:");
            Program.world.WriteLine("Druk enter zonder iets in te voeren om terug te gaan");
            code = Program.world.ReadLine()!.ToLower();
            if (!string.IsNullOrWhiteSpace(code))
            {
                DataModel.visitorCodes!.Add(code);
                Program.world.WriteLine("Bezoeker code toegevoegd");
                Program.world.WriteLine("Druk Enter");
                Program.world.ReadLine();
            }
        } while (code != "");
        DataModel.WriteToCurrentDayJSON(DataModel.visitorCodes, "DataSources/UniqueCodesToday.json");
        Program.world.WriteLine("Bezoekers codes toegevoegd");
        Program.world.WriteLine("Druk Enter");
        Console.ReadLine();
    }

    private static void MeerdereCodes()
    {
        Program.world.WriteLine("Format: code,code,code,...");
        Program.world.WriteLine("Voer codes in zoals gedaan in Format:");
        string codes = Program.world.ReadLine()!.ToLower();
        if (codes == "") { Program.world.WriteLine("Geen codes toegevoegd"); return; }
        List<string> visitorCodes = codes.Replace(" ", "").Split(",").ToList();
        foreach (string code in visitorCodes)
        { if (code != "" && !(code.Contains(" "))) DataModel.visitorCodes!.Add(code); }
        DataModel.WriteToCurrentDayJSON(DataModel.visitorCodes, "DataSources/UniqueCodesToday.json");
        Program.world.WriteLine("Bezoekers codes toegevoegd");
        Program.world.WriteLine("Druk Enter");
        Console.ReadLine();
    }

    private static void GidsenAanpassen()
    {
        string keuze;
        do
        {
            Program.world.WriteLine("Lijst van huidige gidsen:");
            foreach (string gids in DataModel.guideCodes!)
            {
                Program.world.WriteLine(gids);
            }
            Program.world.WriteLine("Wat wilt u doen met deze lijst:");
            Program.world.WriteLine("[A]: Gids toevoegen");
            Program.world.WriteLine("[B]: Gids verwijderen");
            Program.world.WriteLine("[C]: terug");
            keuze = Program.world.ReadLine().ToUpper();
            if (keuze == "A")
            {
                GidsToevoegen();
            }
            else if (keuze == "B")
            {
                GidsVerwijderen();
            }
            Console.Clear();
        } while (keuze != "C");
    }

    private static void GidsToevoegen()
    {
        Program.world.Write("Welke code wilt u toevoegen: ");
        string code = Program.world.ReadLine()!;
        DataModel.guideCodes.Add(code);
        DataModel.WriteToCurrentDayJSON(DataModel.guideCodes, "DataSources/GidsCodes.json");
        Program.world.WriteLine("Gids toegevoegd");
        Program.world.WriteLine("Druk enter");
        Program.world.ReadLine();
    }

    private static void GidsVerwijderen()
    {
        Program.world.Write("Welke gids wilt u verwijderen (gids code): ");
        string gidscode = Program.world.ReadLine();
        if (DataModel.guideCodes.Contains(gidscode))
        {
            DataModel.guideCodes.Remove(gidscode);
            DataModel.WriteToCurrentDayJSON(DataModel.guideCodes, "DataSources/GidsCodes.json");
            Program.world.WriteLine("Gids Verwijderd");
            Program.world.WriteLine("Druk enter");
            Console.ReadLine();
        }
        else { Program.world.WriteLine("Ongeldige code"); }
    }

    private static void SchemaAanpassen()
    {
        string choice;
        do
        {
            Console.Clear();
            BaseLogic.DisplayRondleidingen("afdelingshoofd");
            Program.world.WriteLine("[A]: Rondleiding toevoegen");
            Program.world.WriteLine("[B]: Aanpassen/Verwijderen");
            Program.world.WriteLine("Druk enter om terug te gaan");
            choice = Program.world.ReadLine().ToUpper();
            if (choice == "A")
            {
                AddRondleiding();
            }
            else if (choice == "B")
            {
                Program.world.Write("Welke Rondleiding wilt u aanpassen (id):");
                string id = Program.world.ReadLine();
                foreach (Tour t in DataModel.listoftours)
                {
                    if (t.Id == id)
                    {
                        Program.world.WriteLine("Wat wilt u doen met deze rondleiding");
                        Program.world.WriteLine("[A]: Tijd aanpassen");
                        Program.world.WriteLine("[B]: Verwijderen");
                        string keuze = Program.world.ReadLine().ToUpper();
                        if (keuze == "A")
                        {
                            RondleidingAanpassen(t);
                            break;
                        }
                        else if (keuze == "B")
                        {
                            RondleidingVerwijderen(t);
                            break;
                        }
                    }
                }
            }
        } while (choice != "");
    }

    private static void AddRondleiding()
    {
        Program.world.Write("Op welke tijd wilt u een rondleiding toevoegen (Uur:Minuten): ");
        string start = Program.world.ReadLine();
        DataModel.listoftours.Add(new Tour(Convert.ToString(Convert.ToInt32(DataModel.listoftours.Last().Id) + 1), start, new List<string>(), new List<string>()));
        Program.world.WriteLine("Rondleiding toegevoegd");
        DataModel.listoftours = DataModel.listoftours.OrderBy(x => x.Start).ToList();
        DataModel.WriteToCurrentDayJSON(DataModel.listoftours, DataModel.FilePathSchedule);
        Program.world.WriteLine("Druk Enter");
        Program.world.ReadLine();
    }

    private static void RondleidingAanpassen(Tour t)
    {
        Program.world.Write("Naar welke tijd wilt u de rondleiding verplaatsen (Uur:Minuten): ");
        string time = Program.world.ReadLine();
        t.Start = time;
        DataModel.listoftours = DataModel.listoftours.OrderBy(x => x.Start).ToList();
        DataModel.WriteToCurrentDayJSON(DataModel.listoftours, DataModel.FilePathSchedule);
        Program.world.WriteLine("Tijd veranderd");
        Program.world.WriteLine("Druk Enter");
        Program.world.ReadLine();
    }

    private static void RondleidingVerwijderen(Tour t)
    {
        DataModel.listoftours.Remove(t);
        DataModel.listoftours = DataModel.listoftours.OrderBy(x => x.Start).ToList();
        DataModel.WriteToCurrentDayJSON(DataModel.listoftours, DataModel.FilePathSchedule);
        Program.world.WriteLine("Rondleiding verwijderd");
        Program.world.WriteLine("Druk Enter");
        Program.world.ReadLine();
        return;
    }
}