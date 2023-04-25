using System;
using PLAYRATE_ClassLibrary;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace PLAYRATE_ClassLibraryTests
{
    public class ConsoleMockDatabase
    {
        List<PLAYRATE_ClassLibrary.Consoles.Console> consoles = new List<PLAYRATE_ClassLibrary.Consoles.Console>();

        public List<PLAYRATE_ClassLibrary.Consoles.Console> GetAll()
        {
            return consoles;
        }

        public PLAYRATE_ClassLibrary.Consoles.Console GetConsole(string model)
        {
            PLAYRATE_ClassLibrary.Consoles.Console console = null;

            foreach (PLAYRATE_ClassLibrary.Consoles.Console c in consoles)
            {
                if (c.Model == model)
                {
                    console = c;
                }
                
                return console;
            }
            
            return console;
        }

        public void AddConsole(int id, string model, string manufacturer, string releaseDate, string urlConsole, string controllerType, string chatPlatform)
        {
            PLAYRATE_ClassLibrary.Consoles.Console console = new PLAYRATE_ClassLibrary.Consoles.Console(id, model, manufacturer, releaseDate, urlConsole, controllerType, chatPlatform);
            consoles.Add(console);
        }

        public void RemoveConsole(string model)
        {
            foreach (PLAYRATE_ClassLibrary.Consoles.Console c in consoles)
            {
                if (c.Model == model)
                {
                    consoles.Remove(c);
                }
            }    
        }
    }
}
