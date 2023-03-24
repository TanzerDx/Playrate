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

		public void AddGame(string name, string genre, string releaseDate, string developer, string rating, string desc)
		{
			con.Open();
			SqlCommand cmd = new SqlCommand("INSERT into dbo.Games VALUES (@ID, @Name, @Genre, @ReleaseDate, @Developer, @Rating, @Description)", con);

			cmd.Parameters.AddWithValue("@ID", 8);
			cmd.Parameters.AddWithValue("@Name", name);
			cmd.Parameters.AddWithValue("@Genre", genre);
			cmd.Parameters.AddWithValue("@ReleaseDate", DateTime.Parse(releaseDate));
			cmd.Parameters.AddWithValue("@Developer", developer);
			cmd.Parameters.AddWithValue("@Rating", rating);
			cmd.Parameters.AddWithValue("@Description",	desc);

			cmd.ExecuteNonQuery();

			con.Close();
		}

		public void RemoveGame(string tbID)
		{
			int id = Convert.ToInt32(tbID);

			con.Open();

			SqlCommand cmd = new SqlCommand($"DELETE FROM dbo.Games WHERE ID='{id}'", con);
			cmd.ExecuteNonQuery();

			con.Close();
		}

		//public void ShowAllGames()
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

		public void AddConsole(string type, string model, string manufacturer, string releaseDate, string controllerType, string chatPlatform)
		{ 
			con.Open();

			SqlCommand cmd = new SqlCommand("INSERT into dbo.Consoles VALUES (@ID, @Type, @Model, @Manufacturer, @ReleaseDate, @ControllerType, @ChatPlatform)", con);

			cmd.Parameters.AddWithValue("@ID", 6);
			cmd.Parameters.AddWithValue("@Type", type);
			cmd.Parameters.AddWithValue("@Model", model);
			cmd.Parameters.AddWithValue("@Manufacturer", manufacturer);
			cmd.Parameters.AddWithValue("@ReleaseDate", DateTime.Parse(releaseDate));
			cmd.Parameters.AddWithValue("@ControllerType", controllerType);
			cmd.Parameters.AddWithValue("@ChatPlatform", chatPlatform);

			cmd.ExecuteNonQuery();

			con.Close();
		}

		public void RemoveConsole(string tbID)
		{
			int id = Convert.ToInt32(tbID);

			con.Open();

			SqlCommand cmd = new SqlCommand($"DELETE FROM dbo.Consoles WHERE ID='{id}'", con);
			cmd.ExecuteNonQuery();

			con.Close();
		}

		//public void ShowAllConsoles()
		//{
		//	con.Open();
		//	SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Consoles", con);
		//	SqlDataAdapter da = new SqlDataAdapter(cmd);

		//	DataTable dt = new DataTable();
		//	da.Fill(dt);
		//	dgAllConsoles.DataSource = dt;

		//	cmd.ExecuteNonQuery();

		//	con.Close();
		//}

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
