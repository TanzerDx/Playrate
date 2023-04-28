using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PLAYRATE_ClassLibrary.Games;

namespace PLAYRATE_ClassLibrary.Accounts
{
    public class Account
    {
        public Account()
        { }

        List<Game> playedGames = new List<Game>();

        public int ID { get; set; }

        public string ProfilePicURL { get; set; }

        public string Salt { get; set; }

        [Required]
        public string Username { get; set; }

        [Required, EmailAddress(ErrorMessage = "Invalid email address!")]
        public string Email { get; set; }

        [Required, MinLength(10, ErrorMessage = "The password should be at least 10 characters!")]
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
