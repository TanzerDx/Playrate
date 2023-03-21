using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
	public class PlayStation : Console
	{		
		string controllerType;

		public PlayStation(string model, string manufacturer, string releaseDate, string controllerType) : base(model, manufacturer, releaseDate)
		{
			this.model = model;
			this.manufacturer = manufacturer;
			this.releaseDate = releaseDate;
			this.controllerType = controllerType;
		}

		public string GetControllerType()
		{
			return controllerType;
		}
	}
}
