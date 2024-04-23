using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace BezoekerTests
{
    [TestClass]
    public class BezoekerTests
    {
        private StringWriter _consoleOutput;
        private StringReader _consoleInput;

        [TestInitialize]
        public void Setup()
        {
            _consoleOutput = new StringWriter();
            _consoleInput = new StringReader("A\n"); // Simulate user input of 'A' to log out
            Console.SetOut(_consoleOutput);
            Console.SetIn(_consoleInput);
        }

        [TestMethod]
        public void Expected_when_pressed()
        {
            var expectedOutput = "-----------------------\r\n[A] log uit\r\nKies een rondleiding: ";

            Bezoeker.main();

            StringAssert.Contains(_consoleOutput.ToString(), expectedOutput);
        }

        [TestMethod]
        public void Main_Displays_Tours()
        {

            Tours.tours = new System.Collections.Generic.List<Tour>
            {
                // make test tours
                new Tour { Id = "1", Start = "Start1", End = "End1", Spots = new System.Collections.Generic.List<Spot>() },
                new Tour { Id = "2", Start = "Start2", End = "End2", Spots = new System.Collections.Generic.List<Spot>() }
            };
            var expectedOutput = "-----------------------\r\n|1| Start1 - End1, 0/13\r\n|2| Start2 - End2, 0/13\r\n-----------------------\r\n[A] log uit\r\nKies een rondleiding: ";

            Bezoeker.main();


            StringAssert.Contains(_consoleOutput.ToString(), expectedOutput);
        }

    }
}
