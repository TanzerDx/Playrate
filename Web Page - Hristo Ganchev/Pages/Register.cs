using System.Diagnostics.Metrics;
using System.Xml.Linq;

namespace Home_Page___Hristo_Ganchev
{
	public class Register
	{
		public Register()
		{ }

		public string Email { get; set; }

		public string Username { get; set; }

		public string Password { get; set; }

		public Register(string email, string username, string password)
		{
			Email = email;
			Username = username;
			Password = password;
		}

		public string GetEmail()
		{
			return Email;
		}

		public string GetUsername()
		{
			return Username;
		}

		public string GetPassword()
		{
			return Password;
		}
	}

}