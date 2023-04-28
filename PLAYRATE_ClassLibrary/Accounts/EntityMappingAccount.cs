using PLAYRATE_ClassLibrary.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace PLAYRATE_ClassLibrary.Accounts
{
    public static class EntityMappingAccount
    {
        public static Account ToAccount(this AccountDTO accountDTO)
        {
            return new Account()
            {
                ID = accountDTO.ID,
                Email = accountDTO.Email,
                Username = accountDTO.Username,
                ProfilePicURL = accountDTO.ProfilePicURL,
                Password = accountDTO.Password,
                Salt = accountDTO.Salt,
            };
        }

        public static AccountDTO ToAccountDTO(this Account account)
        {
            return new AccountDTO()
            {
                ID = account.ID,
                Email = account.Email,
                Username = account.Username,
                ProfilePicURL = account.ProfilePicURL,
                Password = account.Password,
                Salt = account.Salt,
            };
        }
    }
}
