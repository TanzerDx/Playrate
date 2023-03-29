using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLAYRATE_DatabaseConnection
{
	public class ConsoleLibrary
	{

		public void AddConsole(string type, string model, string manufacturer, string releaseDate, string urlConsole, string controllerType, string chatPlatform)
		{
			using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-8AACUE7\\SQLEXPRESS;Initial Catalog=dbPLAYRATE;Integrated Security=True;Pooling=False"))
			{
				connection.Open();

				SqlCommand getMaxID = new SqlCommand("SELECT COALESCE(MAX(ID), 0) FROM dbo.Consoles", connection);

				int currentMaxID = (int)getMaxID.ExecuteScalar();

				int newID = currentMaxID + 1;

				SqlCommand cmd = new SqlCommand($"CREATE TABLE dbo.{type + model} (ID int PRIMARY KEY, Name varchar(50), Developer varchar(50), Release_Date varchar(20), Genres varchar(50), Rating varchar(20), Description varchar(5000), URL_Game varchar(MAX), URL_Page varchar(MAX));", connection);

				SqlCommand cmd2 = new SqlCommand($"INSERT INTO dbo.Consoles VALUES (@ID, @Model, @Manufacturer, @Release_Date, @URL_Console, @Controller_Type, @Chat_Platform);", connection);


				cmd2.Parameters.AddWithValue("@ID", newID);
				cmd2.Parameters.AddWithValue("@Model", type + model);
				cmd2.Parameters.AddWithValue("@Manufacturer", manufacturer);
				cmd2.Parameters.AddWithValue("@Release_Date", releaseDate);
				cmd2.Parameters.AddWithValue("@URL_Console", urlConsole);
				cmd2.Parameters.AddWithValue("@Controller_Type", controllerType);
				cmd2.Parameters.AddWithValue("@Chat_Platform", chatPlatform);

				cmd.ExecuteNonQuery();
				cmd2.ExecuteNonQuery();
			}
		}

		public void RemoveConsole(string console)
		{
			using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-8AACUE7\\SQLEXPRESS;Initial Catalog=dbPLAYRATE;Integrated Security=True;Pooling=False"))
			{

				SqlCommand cmd = new SqlCommand($"DROP TABLE dbo.{console}", con);
				SqlCommand cmd2 = new SqlCommand($"DELETE FROM dbo.Consoles WHERE Model='{console}'", con);

				cmd.ExecuteNonQuery();
				cmd2.ExecuteNonQuery();

				con.Close();
			}
		}
	}
}
