namespace BusinessLogic
{
	public class LogIn
	{
		public LogIn()
		{ }

		public string Username { get; set; }

		public string Password { get; set; }

		public LogIn(string username, string password)
		{
			Username = username;
			Password = password;
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
