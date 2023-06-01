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
		public DateTime Release_Date { get; init; }
        public string Developer { get; init; }
        public double Rating { get; init; }
		public string Description { get; init; }
		public string URL_Game { get; init; }
		public string URL_Page { get; init; }
        public int ConsoleID { get; init; }
        public int Reviews { get; init; }

        public Game (int id, string name, string genre, DateTime releaseDate, string developer, double rating, string desc, string URL_Game, string URL_Page, int consoleID, int reviews)
		{
			this.ID = id;
			this.Name = name;
			this.Genre = genre;
			this.Release_Date = releaseDate;
			this.Developer = developer;
			this.Rating = rating;
			this.Description = desc;
			this.URL_Game = URL_Game;
			this.URL_Page = URL_Page;
			this.ConsoleID = consoleID;
			this.Reviews = reviews;

		}
		public Game ()
		{ }
	}
}
