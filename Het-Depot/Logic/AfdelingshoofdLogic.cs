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
            string keuze;
            do
            {
                // BaseLogic.DisplayRondleidingen();
                // Program.world.WriteLine("Wilt u een rondleiding:\n[A] Toevoegen\n[B] Verwijderen\n[C] Aanpassen\n[D] Terug");
                Program.world.WriteLine("[A] Nieuw schema maken\n[B] Gidsen Toevoegen aan rondleidingen\n[C] Selecteer schema voor gebruik\n[D] Terug");

                keuze = Program.world.ReadLine()!.ToLower();
                ChangeATour(keuze);
            } while (keuze != "d");
        }
        else if (userInput == "B")
        {
            string keuze;
            do
            {
                DisplayCodes();
                Program.world.WriteLine("[A] Leeghalen\n[B] Toevoegen\n[C] Terug");
                keuze = Program.world.ReadLine()!.ToUpper();
                if (keuze == "A")
                {
                    DataModel.visitorCodes = new List<string>(); ;
                }
                else if (keuze == "B")
                {
                    Program.world.WriteLine("[A] Een voor een [B] code,code,code [C] Terug");
                    string keuze2 = Program.world.ReadLine()!.ToUpper();
                    if (keuze2 == "A")
                    {
                        string code;
                        do
                        {
                            Program.world.WriteLine("Welke code wilt u toevoegen:");
                            code = Program.world.ReadLine()!.ToLower();
                            DataModel.visitorCodes!.Add(code);

                        } while (code != "");
                    }
                    else if (keuze2 == "B")
                    {
                        string codes;
                        do
                        {
                            Program.world.WriteLine("Welke codes wilt u toevoegen: (code,code,code,...)");
                            codes = Program.world.ReadLine()!.ToLower();
                            List<string> visitorCodes = codes.Split(",").ToList();
                            // DataModel.visitorCodes!.Add(code);
                            foreach (string code in visitorCodes)
                            { DataModel.visitorCodes!.Add(code); }

                        } while (codes != "");
                    }
                }
            } while (keuze != "C");
        }
        else if (userInput == "C")
        {
            string keuze;
            do
            {
                Program.world.WriteLine("Lijst van gidsen nu:");
                foreach (string gids in DataModel.guideCodes!)
                {
                    Program.world.WriteLine(gids);
                }
                Program.world.WriteLine("wat wilt u doen met deze lijst:\n[A] Gids toevoegen\n[B] Gids verwijderen\n[C] terug");
                keuze = Program.world.ReadLine().ToUpper();
                if (keuze == "A")
                {
                    Program.world.WriteLine("Welke code wilt u toevoegen:");
                    string code = Program.world.ReadLine()!;
                    DataModel.guideCodes.Add(code);
                    Console.WriteLine("Gids toegevoegd");
                }
                else if (keuze == "B")
                {
                    Program.world.WriteLine("Welke gids wilt u verwijderen (gids code)");
                    string gidscode = Program.world.ReadLine();
                    if (DataModel.guideCodes.Contains(gidscode)) { DataModel.guideCodes.Remove(gidscode); }
                    else { Program.world.WriteLine("Ongeldige code"); }
                }
            } while (keuze != "C");
        }
        else if (userInput == "D") { return; }
    }

    public static void ChangeATour(string keuze)
    {
        if (keuze == "a")
        {
            // Schema inplementation
            Program.world.WriteLine("Nieuw schema creeren van start datum tot einddatum");
            Program.world.Write("Welke start datum wilt u (yyyy-mm-dd): ");
            DateTime start = DateTime.Parse(Program.world.ReadLine());
            DateTime startdate = new DateTime(start.Year, start.Month, start.Day, 11, 00, 00);
            Program.world.Write("Welke eind datum wilt u (yyyy-mm-dd): ");
            DateTime enddate = DateTime.Parse(Program.world.ReadLine());
            if (startdate > enddate)
            {
                DateTime s = enddate;
                enddate = startdate;
                startdate = s;
            }
            Program.world.WriteLine($"Nieuw schema wordt gemaakt van {startdate.ToString("yyyy-MM-dd")} tot {enddate.ToString("yyyy-MM-dd")}");
            List<Tour> tours = new();
            int Id = 0;
            DateTime steptime = startdate;

            while (steptime < enddate)
            {
                Tour newT = new Tour(Id.ToString(), steptime.ToString(), steptime.AddMinutes(20).ToString(), new List<string>(), new List<string>());


                tours.Add(newT);
                Id += 1;
                // Console.WriteLine($"{steptime.Day}. { steptime.Month}");
                if (steptime.Hour == 16 && steptime.Minute == 40)
                {
                    steptime = steptime.AddDays(1);
                    steptime = new DateTime(steptime.Year, steptime.Month, steptime.Day, 11, 40, 0);
                }
                else
                {
                    steptime = steptime.AddMinutes(20);
                }
            }
            string jsonString = JsonSerializer.Serialize(tours, new JsonSerializerOptions { WriteIndented = true });

            // Specify the file path
            string filePath = $"RondleidingLog/{startdate.ToString("yyyy-MM-dd")}-{enddate.ToString("yyyy-MM-dd")}.json";

            List<string> logEntries;

            // Write the JSON string to a file
            File.WriteAllText(filePath, jsonString);
            if (File.Exists("DataSources/RondleidingLogNames.json"))
            {
                string existingJson = File.ReadAllText("DataSources/RondleidingLogNames.json");
                logEntries = JsonSerializer.Deserialize<List<string>>(existingJson) ?? new List<string>();
            }
            else
            {
                logEntries = new List<string>();
            }

            logEntries.Add(filePath);
            File.WriteAllText("DataSources/RondleidingLogNames.json", JsonSerializer.Serialize(logEntries, new JsonSerializerOptions { WriteIndented = true }));

            Program.world.WriteLine("Schema Gemaakt");
        }
        if (keuze == "b")
        {
            // Adding guides to their tour
            Program.world.WriteLine("Gids toevoegen aan een rondleiding");
            Program.world.WriteLine("Bij welke dag wilt u gidsen toevoegen op de rondleidingen: ");
            DateTime today = Program.world.Now;
            Program.world.Write("Welke start datum wilt u (yyyy-mm-dd): ");
            DateTime start = DateTime.Parse(Program.world.ReadLine());
            DateTime searchfordate = new DateTime(start.Year, start.Month, start.Day);
            foreach (Tour tour in DataModel.listoftours)
            {
                DateTime toursstart = DateTime.Parse(tour.Start);
                if (toursstart.Day == searchfordate.Day && toursstart.Month == searchfordate.Month && toursstart.Year == searchfordate.Year)
                {
                    Console.WriteLine();
                    Program.world.WriteLine($"|{tour.Id}|{tour.Start} - {tour.End}, Gids: {tour.GuideCode}");
                    Program.world.WriteLine("Wilt u op deze rondleidng een gids toevoegen\nVoer dan nu de code in en druk enter\nZo niet dan Enter drukken om de volgende rondleiding te zien");
                    string gidscode = Program.world.ReadLine();
                    if (gidscode != "" && BaseLogic.IsValidCode(gidscode, DataModel.guideCodes)) { tour.GuideCode = gidscode; }
                }
            }
        }
        if (keuze == "c")
        {
            Program.world.WriteLine("Rondleiding schema kiezen");
            string existingJson = File.ReadAllText("DataSources/RondleidingLogNames.json");
            List<string> logEntries = JsonSerializer.Deserialize<List<string>>(existingJson);
            int id = 0;
            foreach (string schema in logEntries)
            {
                Console.WriteLine($"{id}| {schema}");
                id++;
            }
            Program.world.WriteLine("Welk schema wilt u gebruiken");
            string input = Console.ReadLine();
            DataModel.FilePathSchedule = logEntries[Convert.ToInt32(input)];
            Console.WriteLine(DataModel.FilePathSchedule + " is geselecteerd");
            DataModel.getListOfTours();
        }
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