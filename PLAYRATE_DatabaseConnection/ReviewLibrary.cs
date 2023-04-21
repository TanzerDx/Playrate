using PLAYRATE_ClassLibrary;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLAYRATE_DatabaseConnection
{
    public class ReviewLibrary : IReviewRepository
    {
        private readonly string connectionString;

        public ReviewLibrary(string connectionString)
        {
            this.connectionString = connectionString;
        }
    }
}
