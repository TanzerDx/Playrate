using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using BusinessLogic;

namespace PLAYRATE_ClassLibrary.Games
{
    public class Game
    {
		public int ID	{ get; init; }
		public string Name { get; init; }
        public string Genre { get; init; }
		public string Release_Date { get; init; }
        public string Developer { get; init; }
        public string Rating { get; init; }
		public string Description { get; init; }
		public string URL_Game { get; init; }
		public string URL_Page { get; init; }
	}
}
