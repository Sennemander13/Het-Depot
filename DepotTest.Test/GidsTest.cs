using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace GidsTests
{
    [TestClass]
    public class GidsTests
    {
        private StringWriter _consoleOutput;
        private StringReader _consoleInput;

        [TestInitialize]
        public void Setup()
        {
            _consoleOutput = new StringWriter();
            _consoleInput = new StringReader("B\nC\n");
            Console.SetOut(_consoleOutput);
            Console.SetIn(_consoleInput);
        }

        [TestMethod]
        public void Main_Displays_Options_And_Logs_Out()
        {
            var expectedOutput = "Gids\r\n--------------------\r\n|1|Start1 - End1, 0/13\r\n|2|Start2 - End2, 0/13\r\n--------------------\r\n[A] Kies een Rondleiding: \r\n[B] Leeg de rondleidingen: \r\n[C] Log uit\r\n";

            Gids.main();

            StringAssert.Contains(_consoleOutput.ToString(), expectedOutput);
        }

        [TestMethod]
        public void Main_Chooses_Tour()
        {
            var expectedOutput = "Kies een Rondleiding: ";

            Gids.main();

            StringAssert.Contains(_consoleOutput.ToString(), expectedOutput);
        }

        [TestMethod]
        public void Main_Logs_Out()
        {
            var expectedOutput = "Log uit";

            Gids.main();

            StringAssert.Contains(_consoleOutput.ToString(), expectedOutput);
        }

        [TestMethod]
        public void EmptyTours_Empties_All_Tours()
        {
            // Arrange
            Tours.tours = new System.Collections.Generic.List<Tour>
            {
                new Tour { Id = "1", Start = "Start1", End = "End1", Spots = new System.Collections.Generic.List<Spot>(), HasTakenTour = new System.Collections.Generic.List<string>() },
                new Tour { Id = "2", Start = "Start2", End = "End2", Spots = new System.Collections.Generic.List<Spot>(), HasTakenTour = new System.Collections.Generic.List<string>() }
            };

            // Act
            Gids.emptyTours();

            // Assert
            foreach (var tour in Tours.tours)
            {
                Assert.AreEqual(0, tour.Spots.Count);
                Assert.AreEqual(0, tour.HasTakenTour.Count);
            }

            StringAssert.Contains(_consoleOutput.ToString(), "Alle rondleidingen van vandaag zijn leeg gemaakt");
        }
    }
}