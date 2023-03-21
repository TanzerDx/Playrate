using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
	public class Xbox : Console
	{
		string controllerType;
		string chatPlatform;

		public Xbox(string model, string manufacturer, string releaseDate, string controllerType, string chatPlatform) : base(model, manufacturer, releaseDate)
		{
			this.model = model;
			this.manufacturer = manufacturer;
			this.releaseDate = releaseDate;
			this.controllerType = controllerType;
			this.chatPlatform = chatPlatform;
		}

		public string GetControllerType() 
		{  return controllerType; }

		public string GetChatPlatform() 
		{  return chatPlatform; }
	}
}
