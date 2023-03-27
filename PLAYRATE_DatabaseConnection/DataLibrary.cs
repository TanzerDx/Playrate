using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PLAYRATE_DatabaseConnection
{
	public class DataLibrary
	{
		SqlConnection con = new SqlConnection("Data Source=DESKTOP-8AACUE7\\SQLEXPRESS;Initial Catalog=dbPLAYRATE;Integrated Security=True;Pooling=False");

		//public void ShowAllConsoles(string comboBox)
		//{
  //          con.Open();

  //          DataTable tables = con.GetSchema("Tables");
  //          List<string> tableNames = new List<string>();
            
		//	foreach (DataRow row in tables.Rows)
  //          {
  //              string tableName = (string)row[2];
  //              tableNames.Add(tableName);
  //          }

  //          cbbConsole.DataSource = tableNames;

  //          con.Close();
  //      }

		public void AddGame(string console, string name, string genre, string releaseDate, string developer, string rating, string desc, string urlGame, string urlPage)
		{

				con.Open();

				SqlCommand getMaxID = new SqlCommand("SELECT COALESCE(MAX(ID), 0) FROM dbo.Consoles", con);

				int currentMaxID = (int)getMaxID.ExecuteScalar();

				int newID = currentMaxID + 1;

				SqlCommand cmd = new SqlCommand($"INSERT into dbo.{console} VALUES (@ID, @Name, @Genre, @ReleaseDate, @Developer, @Rating, @Description, @URL_Game, @URL_Page)", con);


				cmd.Parameters.AddWithValue("@ID", newID);
				cmd.Parameters.AddWithValue("@Name", name);
				cmd.Parameters.AddWithValue("@Genre", genre);
				cmd.Parameters.AddWithValue("@ReleaseDate", DateTime.Parse(releaseDate));
				cmd.Parameters.AddWithValue("@Developer", developer);
				cmd.Parameters.AddWithValue("@Rating", rating);
				cmd.Parameters.AddWithValue("@Description", desc);
				cmd.Parameters.AddWithValue("@URL_Game", urlGame);
				cmd.Parameters.AddWithValue("@URL_Page", urlPage);

				cmd.ExecuteNonQuery();

				con.Close();
		}

		public void RemoveGame(string console, string tbID)
		{
			int id = Convert.ToInt32(tbID);

			con.Open();

			SqlCommand cmd = new SqlCommand($"DELETE FROM dbo.{console} WHERE ID='{id}'", con);
			cmd.ExecuteNonQuery();

			con.Close();
		}

		//public void ShowGames()
		//{
		//	con.Open();
		//	SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Consoles", con);
		//	SqlDataAdapter da = new SqlDataAdapter(cmd);

		//	DataTable dt = new DataTable();
		//	da.Fill(dt);
		//	dgAllGames.DataSource = dt;

		//	cmd.ExecuteNonQuery();

		//	con.Close();
		//}

		public void AddConsole(string type, string model, string manufacturer, string releaseDate, string urlConsole, string controllerType, string chatPlatform)
		{ 
			con.Open();

            SqlCommand getMaxID = new SqlCommand("SELECT COALESCE(MAX(ID), 0) FROM dbo.Consoles", con);
			
			int currentMaxID = (int)getMaxID.ExecuteScalar();
            
			int newID = currentMaxID + 1;

            SqlCommand cmd = new SqlCommand($"CREATE TABLE dbo.{type+model} (ID int PRIMARY KEY, Name varchar(50), Developer varchar(50), Release_Date date, Genres varchar(50), Rating decimal, Description varchar(5000), URL_Game varchar(5000), URL_Page varchar(5000));", con);
            
			SqlCommand cmd2 = new SqlCommand($"INSERT INTO dbo.Consoles VALUES (@ID, @Model, @Manufacturer, @Release_Date, @URL_Console, @Controller_Type, @Chat_Platform);", con);


            cmd2.Parameters.AddWithValue("@ID", newID);
            cmd2.Parameters.AddWithValue("@Model", type+model);
            cmd2.Parameters.AddWithValue("@Manufacturer", manufacturer);
            cmd2.Parameters.AddWithValue("@Release_Date", DateTime.Parse(releaseDate));
            cmd2.Parameters.AddWithValue("@URL_Console", urlConsole);
            cmd2.Parameters.AddWithValue("@Controller_Type", controllerType);
            cmd2.Parameters.AddWithValue("@Chat_Platform", chatPlatform);

            cmd.ExecuteNonQuery();
			cmd2.ExecuteNonQuery();

			con.Close();
		}

		public void RemoveConsole(string console)
		{

			con.Open();

			SqlCommand cmd = new SqlCommand($"DROP TABLE dbo.{console}", con);
            SqlCommand cmd2 = new SqlCommand($"DELETE FROM dbo.Consoles WHERE Model='{console}'", con);
            
			cmd.ExecuteNonQuery();
			cmd2.ExecuteNonQuery();

			con.Close();
		}

		public void AddAccount(string submittedEmail, string submittedUsername, string submittedPassword)
		{
			SqlConnection con = new SqlConnection("Data Source=DESKTOP-8AACUE7\\SQLEXPRESS;Initial Catalog=dbPLAYRATE;Integrated Security=True;Pooling=False");
			con.Open();
			SqlCommand cmd = new SqlCommand("INSERT into dbo.Accounts VALUES (@ID, @Email, @Username, @Password)", con);

			cmd.Parameters.AddWithValue("@ID", 3);
			cmd.Parameters.AddWithValue("@Email", submittedEmail);
			cmd.Parameters.AddWithValue("@Username", submittedUsername);
			cmd.Parameters.AddWithValue("@Password", submittedPassword);

			cmd.ExecuteNonQuery();

			con.Close();
		}
	}
}
