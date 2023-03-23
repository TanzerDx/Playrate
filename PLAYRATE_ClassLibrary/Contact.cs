using System.ComponentModel.DataAnnotations;

namespace BusinessLogic
{
	public class Contact
	{

		[Required, MinLength(10, ErrorMessage = "The name should be at least 10 characters!")]
		public string Name { get; set; }

		[Required, EmailAddress(ErrorMessage = "Invalid email address!")]
		public string Email { get; set; }

		public string Country { get; set; }

		[Required]
		public string Subject { get; set; }

		public Contact()
		{ }

		public Contact(string name, string email, string country, string subject)
		{
			Name = name;
			Email = email;
			Country = country;
			Subject = subject;
		}

		public string GetName()
		{
			return Name;
		}

		public string GetEmail()
		{
			return Email;
		}

	}
}

