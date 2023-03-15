using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace PLAYRATE.ClassLibrary
{
    public class Administration
    {
        List<Account> allAccounts = new List<Account>();
        List<Game> allGames = new List<Game>();

        public void AddAccount(Account a)
        {
            allAccounts.Add(a);
        }

        public void AddGame(Game g)
        {
            allGames.Add(g);
        }

        public void RemoveGame(Game g)
        {
            allGames.Remove(g);
        }

        public Account GetAccount(string name)
        {
            Account account = null;
            foreach (Account a in allAccounts)
            {
                if (name == a.GetName())
                {
                    account = a;
                    break;
                }
            }
            return account;
        }

        public Game GetGame(string name)
        {
            Game game = null;
            foreach (Game g in allGames)
            {
                if (name == g.GetName())
                {
                    game = g;
                    break;
                }
            }
            return game;
        }

        public List<Account> GetAllAccounts() 
        { 
            return allAccounts;
        }

        public List<Game> GetAllGames()
        {
            return allGames;
        }
    }
}
