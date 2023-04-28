using PLAYRATE_ClassLibrary;
using PLAYRATE_ClassLibrary.Accounts;
using PLAYRATE_ClassLibrary.Games;
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

        public AccountDTO? GetAccount(string email)
        {
            AccountDTO? accountDTO = null;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand sqlCommand = new SqlCommand($"select * from dbo.Accounts where Email = @Email",
                    con);
                sqlCommand.Parameters.AddWithValue("@Email", email);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.Read())
                {
                    accountDTO = CreateAccountDTO(reader);
                }
                con.Close();
            }
            return accountDTO;
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

        public string GetProfilePic(string email)
        {
            using (SqlConnection con = new SqlConnection("Data Source=mssqlstud.fhict.local;Persist Security Info=True;User ID = dbi499630; Password=Jvm5cNGGkr"))
            {
                con.Open();

                string query = $"SELECT ProfilePicURL FROM dbo.Accounts WHERE Email='{email}'";
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

        private AccountDTO CreateAccountDTO(SqlDataReader reader)
        {
            return new AccountDTO()
            {
                ID = reader.GetInt32(0),
                Email = reader.GetString(1),
                Username = reader.GetString(2),
                ProfilePicURL = reader.GetString(3),
                Password = reader.GetString(4),
                Salt = reader.GetString(5),
            };
        }

    }
}
