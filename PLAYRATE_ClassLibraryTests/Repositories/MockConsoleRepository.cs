using PLAYRATE_ClassLibrary;
using PLAYRATE_ClassLibrary.Consoles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLAYRATE_ClassLibraryTests.Repositories
{
	public class MockConsoleRepository : IConsoleRepository
	{
		public List<ConsoleDTO> GetAll()
		{
			throw new NotImplementedException();
		}

		public List<string> GetConsoleByName()
		{
			throw new NotImplementedException();
		}

		public ConsoleDTO? GetConsole(string name)
		{
			throw new NotImplementedException();
		}

		public int? GetConsoleID(string console)
		{
			throw new NotImplementedException();
		}

		public void AddConsole(string type, string model, string manufacturer, DateTime releaseDate, string urlConsole, string controllerType, string chatPlatform)
		{
			throw new NotImplementedException();
		}

		public void RemoveConsole(string console)
		{
			throw new NotImplementedException();
		}
	}
}
