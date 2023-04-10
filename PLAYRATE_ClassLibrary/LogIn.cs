namespace BusinessLogic
{
	public class LogIn
	{
		public LogIn()
		{ }

		public string Email { get; set; }

		public string Password { get; set; }

		public LogIn(string email, string password)
		{
			Email = email;
			Password = password;
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
