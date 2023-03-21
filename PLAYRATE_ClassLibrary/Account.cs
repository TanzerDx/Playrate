using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
	public class Account
	{
		public Account() 
		{ }

		List<Game> playedGames = new List<Game>();

		public string Username { get; set; }
		public string Email { get; set; }
        public string Password { get; set; }

        public Account(string username, string email, string password)
		{
			Username = username;
			Email = email;
			Password = password;
		}

		public string GetName()
		{
			return Username;
		}

		public string GetEmail()
		{
			return Email;
		}

		public string GetPassword()
		{
			return Password;
		}

	}
}
