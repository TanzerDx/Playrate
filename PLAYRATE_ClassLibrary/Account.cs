using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop_App___Hristo_Ganchev
{
	public class Account
	{
		List<Game> playedGames = new List<Game>();

		string username;
		string email;
		string password;

		public Account(string username, string email, string password)
		{
			this.username = username;
			this.email = email;
			this.password = password;
		}

		public string GetName()
		{
			return username;
		}

		public string GetEmail()
		{
			return email;
		}

		public string GetPassword()
		{
			return password;
		}

	}
}
