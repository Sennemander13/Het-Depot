using System.Net.Mail;
using System.Text.Json;
using System.Xml.Linq;
using Microsoft.Win32.SafeHandles;
public static class AfdelingshoofdLogic
{
    public static void MenuOptions(string userInput)
    {
        if (userInput == "A")
        {
            Program.world.WriteLine("Gidsen koppelen aan de rondleidingen van vandaag");
            foreach (Tour tour in DataModel.listoftours)
            {
                Program.world.WriteLine($"Rondleiding: {tour.Id} | start om: {tour.Start}, Gids: {tour.GuideCode}");
                Program.world.WriteLine("Wilt u op deze rondleiding een gids toevoegen\nVoer dan nu de gids code in en druk enter\nZo niet dan Enter drukken om de volgende rondleiding te zien");
                string gidscode = Program.world.ReadLine();
                if (gidscode != "" && BaseLogic.IsValidCode(gidscode, DataModel.guideCodes)) { tour.GuideCode = gidscode; }
            }

            DataModel.WriteToCurrentDayJSON(DataModel.listoftours, DataModel.FilePathSchedule);
            Program.world.Write("Gidsen gekoppeld aan de rondleidingen van vandaag\nDruk Enter");
            Program.world.ReadLine();
        }
        else if (userInput == "B")
        {
            string keuze;
            do
            {
                DisplayCodes();
                Program.world.WriteLine("[A]: Leeghalen");
                Program.world.WriteLine("[B]: Toevoegen");
                Program.world.WriteLine("[C]: Terug");
                keuze = Program.world.ReadLine()!.ToUpper();
                if (keuze == "A")
                {
                    DataModel.visitorCodes = new List<string>();
                    DataModel.WriteToCurrentDayJSON(DataModel.visitorCodes, "DataSources/UniqueCodesToday.json");
                    Program.world.WriteLine("Bezoekers codes geleegd\nDruk enter");
                    Console.ReadLine();
                }
                else if (keuze == "B")
                {
                    Program.world.WriteLine("[A]: Één code toevoegen");
                    Program.world.WriteLine("[B]: Meerdere codes toevoegen");
                    Program.world.WriteLine("[C]: Terug");
                    string keuze2 = Program.world.ReadLine()!.ToUpper();
                    if (keuze2 == "A")
                    {
                        string code;
                        do
                        {
                            Program.world.WriteLine("Welke bezoeker code wilt u toe voegen:");
                            code = Program.world.ReadLine()!.ToLower();
                            if (!string.IsNullOrWhiteSpace(code))
                            {
                                DataModel.visitorCodes!.Add(code);
                            }
                            Program.world.WriteLine("Druk enter zonder iets in te voeren om terug te gaan");
                        } while (code != "");
                        DataModel.WriteToCurrentDayJSON(DataModel.visitorCodes, "DataSources/UniqueCodesToday.json");
                        Program.world.WriteLine("Bezoekers codes toegevoegd");
                        Program.world.WriteLine("Druk Enter");
                        Console.ReadLine();
                    }
                    else if (keuze2 == "B")
                    {
                        Program.world.WriteLine("Format: code,code,code,...");
                        Program.world.WriteLine("Voer codes in zoals gedaan in Format:");
                        string codes = Program.world.ReadLine()!.ToLower();
                        List<string> visitorCodes = codes.Replace(" ", "").Split(",").ToList();
                        foreach (string code in visitorCodes)
                        { DataModel.visitorCodes!.Add(code); }
                        DataModel.WriteToCurrentDayJSON(DataModel.visitorCodes, "DataSources/UniqueCodesToday.json");
                        Program.world.WriteLine("Bezoekers codes toegevoegd");
                        Program.world.WriteLine("Druk Enter");
                        Console.ReadLine();
                    }
                }
            } while (keuze != "C");
        }
        else if (userInput == "C")
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
                Program.world.WriteLine("[C]: Terug");
                keuze = Program.world.ReadLine().ToUpper();
                if (keuze == "A")
                {
                    Program.world.Write("Welke code wilt u toevoegen: ");
                    string code = Program.world.ReadLine()!;
                    DataModel.guideCodes.Add(code);
                    DataModel.WriteToCurrentDayJSON(DataModel.guideCodes, "DataSources/GidsCodes.json");
                    Program.world.WriteLine("Gids toegevoegd");
                    Program.world.WriteLine("Druk enter");
                    Program.world.ReadLine();
                }
                else if (keuze == "B")
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
            } while (keuze != "C");
        }
        else if (userInput == "D")
        {
            BaseLogic.DisplayRondleidingen("afdelingshoofd");
            Program.world.WriteLine("[A]: Rondleiding toevoegen");
            Program.world.WriteLine("[B]: Aanpassen/Verwijderen");
            Program.world.WriteLine("Druk enter om terug te gaan");
            string choice = Program.world.ReadLine().ToUpper();
            if (choice == "B")
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
                            Program.world.Write("Naar welke tijd wilt u de rondleidng verplaatsen (Uur:Minuten): ");
                            string time = Program.world.ReadLine();
                            t.Start = time;
                            Program.world.WriteLine("Tijd veranderd");
                            Program.world.WriteLine("Druk Enter");
                            Program.world.ReadLine();
                        }
                        else if (keuze == "B")
                        {
                            DataModel.listoftours.Remove(t);
                            Program.world.WriteLine("Rondleiding verwijderd");
                            Program.world.WriteLine("Druk Enter");
                            Program.world.ReadLine();
                            return;
                        }
                    }
                }
            }
            else if (choice == "A")
            {
                Program.world.Write("Op welke tijd wilt u een rondleiding toevoegen (Uur:Minuten): ");
                string start = Program.world.ReadLine();
                DataModel.listoftours.Add(new Tour(Convert.ToString(Convert.ToInt32(DataModel.listoftours.Last().Id) + 1), start, new List<string>(), new List<string>()));
                Program.world.WriteLine("Rondleiding toegevoegd");
                DataModel.listoftours = DataModel.listoftours.OrderBy(x => x.Start).ToList();
                Program.world.WriteLine("Druk Enter");
                Program.world.ReadLine();
            }

        }
        else if (userInput == "E") { return; }
    }

    public static void DisplayCodes()
    {
        Program.world.WriteLine("Lijst van code op dit moment:");
        foreach (string ccode in DataModel.visitorCodes!)
        {
            Program.world.WriteLine(ccode);
        }
    }
}