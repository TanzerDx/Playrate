using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
	public class ConsoleManagement
	{
		List<Console> allConsoles = new List<Console>();


		public void AddConsole(Console c)
		{
			allConsoles.Add(c);
		}

		public void RemoveConsole(Console c)
		{
			allConsoles.Remove(c);
		}

		public List<Console> GetAllConsoles()
		{
			return allConsoles;
		}
	}
}
