using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PLAYRATE_ClassLibrary.Games;

namespace BusinessLogic
{
    public abstract class Console
	{
		protected string model;
		protected string manufacturer;
		protected string releaseDate;

		public Console(string model, string manufacturer, string releaseDate)
		{
			this.model = model;
			this.manufacturer = manufacturer;
			this.releaseDate = releaseDate;

		}

		public string GetModel()
		{
			return model;
		}

		public string GetManufacturer(string manufacturer) 
		{
			return manufacturer;
		}

		public string GetReleaseDate(string releaseDate) 
		{ 
			return releaseDate;
		}

	}
}
