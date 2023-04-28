using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLAYRATE_ClassLibrary.Accounts
{
    public struct AccountDTO
    {

        public int ID;

        public string ProfilePicURL;

        public string Salt;

        public string Username;

        public string Email;

        public string Password;
    }
}
