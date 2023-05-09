using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PLAYRATE_ClassLibrary.Games
{
    public struct GameDTO
    {
        public int ID;
        public int Console_ID;
        public string Name;
        public string Developer;
        public string Release_Date;
        public string Genre;
        public double Rating;
        public string Description;
        public string URL_Game;
        public string URL_Page;

    }
}
