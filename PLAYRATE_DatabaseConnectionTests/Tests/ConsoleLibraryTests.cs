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
		private readonly string connectionString = "Data Source=mssqlstud.fhict.local;Persist Security Info=True;User ID=dbi499630;Password=Jvm5cNGGkr";
		ConsoleLibrary consoleLibrary = new ConsoleLibrary("Data Source=mssqlstud.fhict.local;Persist Security Info=True;User ID=dbi499630;Password=Jvm5cNGGkr");

		[TestMethod()]
		public void GetAllTest()
		{
			consoleLibrary.GetAll();

			using (SqlConnection con = new SqlConnection(connectionString))
			{
				con.Open();
				SqlCommand getAll = new SqlCommand("SELECT * FROM dbo.Consoles ", con);
				SqlDataReader reader = getAll.ExecuteReader();
				Assert.IsTrue(reader.HasRows);
				reader.Read();
				con.Close();
			}
		}

		[TestMethod()]
		public void GetConsoleTest()
		{
			string model = "Playstation5";
			
			consoleLibrary.GetConsole(model);

			using (SqlConnection con = new SqlConnection(connectionString))
			{
				con.Open();
				SqlCommand getConsole = new SqlCommand("SELECT * FROM dbo.Consoles ", con);
				SqlDataReader reader = getConsole.ExecuteReader();
				Assert.IsTrue(reader.HasRows);
				reader.Read();
				con.Close();
			}
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

			using (SqlConnection con = new SqlConnection(connectionString))
			{
				con.Open();
				SqlCommand createConsole = new SqlCommand("SELECT * FROM dbo.Consoles", con);
				SqlDataReader reader = createConsole.ExecuteReader();
				Assert.IsTrue(reader.HasRows);
				reader.Read();
				con.Close();
			}
		}


		[TestMethod()]
		public void RemoveConsoleTest()
		{
			string console = "Playstation5";

			consoleLibrary.RemoveConsole(console);

			using (SqlConnection con = new SqlConnection(connectionString))
			{
				con.Open();
				SqlCommand deleteConsole = new SqlCommand("SELECT * FROM dbo.Consoles ", con);
				SqlDataReader reader = deleteConsole.ExecuteReader();
				Assert.IsTrue(reader.HasRows);
				reader.Read();
				con.Close();
			}
		}
	}
}
