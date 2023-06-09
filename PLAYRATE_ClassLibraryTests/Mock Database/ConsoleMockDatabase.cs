using System;
using PLAYRATE_ClassLibrary;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using PLAYRATE_ClassLibrary.Consoles;

namespace PLAYRATE_ClassLibraryTests
{
    public class ConsoleMockDatabase
    {
		public List<PLAYRATE_ClassLibrary.Consoles.Console> GetMockDatabase()
		{
			PLAYRATE_ClassLibrary.Consoles.Console console1 = new PLAYRATE_ClassLibrary.Consoles.Console(1, "Playstation 4", "Sony", Convert.ToDateTime("2005/05/14"), "url","Dual", "None");
			PLAYRATE_ClassLibrary.Consoles.Console console2 = new PLAYRATE_ClassLibrary.Consoles.Console(2, "XBOX ONE", "Microsoft", Convert.ToDateTime("2005/05/14"), "url", "X", "People");
			PLAYRATE_ClassLibrary.Consoles.Console console3 = new PLAYRATE_ClassLibrary.Consoles.Console(3, "Nintendo Switch", "Nintendo", Convert.ToDateTime("2005/05/14"), "url", "None", "Friends");
			PLAYRATE_ClassLibrary.Consoles.Console console4 = new PLAYRATE_ClassLibrary.Consoles.Console(4, "PC", "John Atanasov", Convert.ToDateTime("2005/05/14"), "url", "None", "None");
			PLAYRATE_ClassLibrary.Consoles.Console console5 = new PLAYRATE_ClassLibrary.Consoles.Console(5, "Wii U", "Nintendo", Convert.ToDateTime("2005/05/14"), "url", "Wii Control Set", "Friends");

			List<PLAYRATE_ClassLibrary.Consoles.Console> consoles = new List<PLAYRATE_ClassLibrary.Consoles.Console> { console1, console2, console3, console4, console5 };

			return consoles;
		}

	}
}
