using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PLAYRATE_DatabaseConnection.Games
{
    public struct GameDTO
    {
        public int ID;
        public string Name;
        public string Developer;
        public string Release_Date;
        public string Genre;
        public string Rating;
        public string Description;
        public string URL_Game;
        public string URL_Page;

    }
}
