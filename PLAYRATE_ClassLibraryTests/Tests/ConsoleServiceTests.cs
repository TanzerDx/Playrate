﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            consoleService.GetAll();

            //using (SqlConnection con = new SqlConnection(connectionString))
            //{
            //    con.Open();
            //    SqlCommand getAll = new SqlCommand("SELECT * FROM dbo.Consoles ", con);
            //    SqlDataReader reader = getAll.ExecuteReader();
            //    Assert.IsTrue(reader.HasRows);
            //    reader.Read();
            //    con.Close();
            //}
        }

        [TestMethod()]
        public void GetConsoleTest()
        {
            string model = "Playstation5";

            consoleService.GetConsole(model);

            //using (SqlConnection con = new SqlConnection(connectionString))
            //{
            //    con.Open();
            //    SqlCommand getConsole = new SqlCommand("SELECT * FROM dbo.Consoles ", con);
            //    SqlDataReader reader = getConsole.ExecuteReader();
            //    Assert.IsTrue(reader.HasRows);
            //    reader.Read();
            //    con.Close();
            //}
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

            //using (SqlConnection con = new SqlConnection(connectionString))
            //{
            //    con.Open();
            //    SqlCommand createConsole = new SqlCommand("SELECT * FROM dbo.Consoles", con);
            //    SqlDataReader reader = createConsole.ExecuteReader();
            //    Assert.IsTrue(reader.HasRows);
            //    reader.Read();
            //    con.Close();
            //}
        }


        [TestMethod()]
        public void RemoveConsoleTest()
        {
            string console = "Playstation5";

            consoleService.RemoveConsole(console);

            //using (SqlConnection con = new SqlConnection(connectionString))
            //{
            //    con.Open();
            //    SqlCommand deleteConsole = new SqlCommand("SELECT * FROM dbo.Consoles ", con);
            //    SqlDataReader reader = deleteConsole.ExecuteReader();
            //    Assert.IsTrue(reader.HasRows);
            //    reader.Read();
            //    con.Close();
            //}
        }
    }
}