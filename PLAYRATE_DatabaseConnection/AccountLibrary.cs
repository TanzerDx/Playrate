using PLAYRATE_ClassLibrary;
using System.Data.SqlClient;

namespace PLAYRATE_DatabaseConnection
{
    public class AccountLibrary : IAccountRepository
    {
        private readonly string connectionString;

        public AccountLibrary(string con)
        {
            connectionString = con;
        }

        public void AddAccount(string submittedEmail, string submittedUsername, string submittedPassword, string salt)
        {
            using (SqlConnection connection = new SqlConnection("Data Source=mssqlstud.fhict.local;Persist Security Info=True;User ID = dbi499630; Password=Jvm5cNGGkr"))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand("INSERT into dbo.Accounts VALUES (@Email, @Username, @Password, @Salt)", connection);

                cmd.Parameters.AddWithValue("@Email", submittedEmail);
                cmd.Parameters.AddWithValue("@Username", submittedUsername);
                cmd.Parameters.AddWithValue("@Password", submittedPassword);
                cmd.Parameters.AddWithValue("@Salt", salt);

                cmd.ExecuteNonQuery();
            }
        }

        public void RemoveAccount(int id)
        {
            using (SqlConnection connection = new SqlConnection("Data Source=mssqlstud.fhict.local;Persist Security Info=True;User ID = dbi499630; Password=Jvm5cNGGkr"))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand($"DELETE from dbo.Accounts WHERE ID = '{id}'", connection);

                cmd.ExecuteNonQuery();
            }
        }

        public string GetUsernameFromEmail(string email)
        {
            using (SqlConnection con = new SqlConnection("Data Source=mssqlstud.fhict.local;Persist Security Info=True;User ID = dbi499630; Password=Jvm5cNGGkr"))
            {
                con.Open();

                string query = $"SELECT Username FROM dbo.Accounts WHERE Email='{email}'";
                SqlCommand command = new SqlCommand(query, con);

                return command.ExecuteScalar().ToString();
            }
        }

        public SqlDataReader GetAccountLogIn(string email)
        {
            SqlConnection con = new SqlConnection("Data Source=mssqlstud.fhict.local;Persist Security Info=True;User ID=dbi499630;Password=Jvm5cNGGkr");

            con.Open();

            string query = $"SELECT Password, Salt FROM dbo.Accounts WHERE Email='{email}'";
            SqlCommand command = new SqlCommand(query, con);
            SqlDataReader reader = command.ExecuteReader();

            return reader;
        }

    }
}
