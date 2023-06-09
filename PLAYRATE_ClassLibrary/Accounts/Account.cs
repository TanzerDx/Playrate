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

        public int ID { get; set; }

        public string ProfilePicURL { get; set; }

        public string Salt { get; set; }

        [Required]
        public string Username { get; set; }

        [Required, EmailAddress(ErrorMessage = "Invalid email address!")]
        public string Email { get; set; }

        [Required, MinLength(10, ErrorMessage = "The password should be at least 10 characters!")]
        public string Password { get; set; }

        public Account(int ID, string ProfilePicURL, string Salt, string Username, string Email, string Password)
        {
            this.ID = ID;
            this.ProfilePicURL = ProfilePicURL;
            this.Salt = Salt;
            this.Username = Username;
            this.Email = Email;
            this.Password = Password;
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
