using Microsoft.VisualStudio.TestTools.UnitTesting;
using PLAYRATE_ClassLibrary.Consoles;
using PLAYRATE_ClassLibrary.Games;
using PLAYRATE_ClassLibraryTests;
using PLAYRATE_DatabaseConnection;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PLAYRATE_ClassLibrary.Consoles.Tests
{
    [TestClass()]
    public class ConsoleServiceTests
    {
    
        ConsoleMockDatabase consoleService;

        public ConsoleServiceTests()
        {
            consoleService = new ConsoleMockDatabase();
        }

        [TestMethod()]
        public void GetAllTest()
        {
            int id = 1;
            string model = "Playstation5";
            string manufacturer = "Sony";
            string releaseDate = "14/05/2020";
            string urlConsole = "a";
            string controllerType = "Dual Shock 2.0";
            string chatPlatform = "None";

            consoleService.AddConsole(id, model, manufacturer, releaseDate, urlConsole, controllerType, chatPlatform);

            Assert.IsNotNull(consoleService.GetAll());
        }

        [TestMethod()]
        public void GetConsoleTest()
        {
            int id = 1;
            string model = "Playstation5";
            string manufacturer = "Sony";
            string releaseDate = "14/05/2020";
            string urlConsole = "a";
            string controllerType = "Dual Shock 2.0";
            string chatPlatform = "None";

            consoleService.AddConsole(id, model, manufacturer, releaseDate, urlConsole, controllerType, chatPlatform);

            Assert.AreEqual("PLAYRATE_ClassLibrary.Consoles.Console", consoleService.GetConsole(model).ToString());
        }

        [TestMethod()]
        public void AddConsoleTest()
        {
            int id = 1;
            string model = "Playstation5";
            string manufacturer = "Sony";
            string releaseDate = "14/05/2020";
            string urlConsole = "a";
            string controllerType = "Dual Shock 2.0";
            string chatPlatform = "None";

            consoleService.AddConsole(id, model, manufacturer, releaseDate, urlConsole, controllerType, chatPlatform);

            Assert.IsNotNull(consoleService.GetAll());
        }


        [TestMethod()]
        public void RemoveConsoleTest()
        {
            string console = "Playstation5";

            consoleService.RemoveConsole(console);

            Assert.AreEqual(null, consoleService.GetConsole(console));
        }
    }
}