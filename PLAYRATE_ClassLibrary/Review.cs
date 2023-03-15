using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLAYRATE.ClassLibrary
{
    public class Review
    {
        string username;
        double ratring;
        string comment;

        public Review(string username, double ratring, string comment)
        {
            this.username = username;
            this.ratring = ratring;
            this.comment = comment;
        }
    }
}
