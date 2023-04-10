using Microsoft.VisualStudio.TestTools.UnitTesting;
using PLAYRATE_DatabaseConnection.Consoles;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PLAYRATE_DatabaseConnection.Consoles.Tests
{
	[TestClass()]
	public class ConsoleLibraryTests
	{
		ConsoleLibrary consoleLibrary = new ConsoleLibrary("Data Source=mssqlstud.fhict.local;Persist Security Info=True;User ID=dbi499630;Password=Jvm5cNGGkr");

		[TestMethod()]
		public void GetAllTest()
		{
			consoleLibrary.GetAll();
		}

		[TestMethod()]
		public void GetConsoleTest()
		{
			string model = "Playstation4";
			
			consoleLibrary.GetConsole(model);
		}

		[TestMethod()]
		public void AddConsoleTest()
		{
			string type = "Playstation";
			string model = "5";
			string manufacturer = "Sony";
			string releaseDate = "14/05/2020";
			string urlConsole = "a";
			string controllerType = "Dual Shock 2.0";
			string chatPlatform = "None";

			consoleLibrary.AddConsole(type, model, manufacturer, releaseDate, urlConsole, controllerType, chatPlatform);
		}

		[TestMethod()]
		public void RemoveConsoleTest()
		{
			string console = "Playstation5";

			consoleLibrary.RemoveConsole(console);
		}
	}
}
