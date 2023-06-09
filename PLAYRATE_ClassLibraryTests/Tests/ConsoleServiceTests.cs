using Microsoft.VisualStudio.TestTools.UnitTesting;
using PLAYRATE_ClassLibrary.Consoles;
using PLAYRATE_ClassLibrary.Games;
using PLAYRATE_ClassLibraryTests;
using PLAYRATE_ClassLibraryTests.Repositories;
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
		ConsoleService consoleService;

		ConsoleMockDatabase mock = new ConsoleMockDatabase();

		public ConsoleServiceTests()
		{
			consoleService = new ConsoleService(new MockConsoleRepository());
		}
	}
}