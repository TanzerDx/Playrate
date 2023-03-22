using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Desktop_App___Hristo_Ganchev
{
	public partial class AddGame : Form
	{
		BusinessLogic.GamesLibraryManagement gamesLibraryManagement = new BusinessLogic.GamesLibraryManagement();
		BusinessLogic.ConsoleManagement consoleManagement = new BusinessLogic.ConsoleManagement();

		BusinessLogic.Game game;

		Color bgcolor = Color.FromArgb(48, 52, 145);

		public AddGame()
		{
			InitializeComponent();
		}

		public AddGame(BusinessLogic.GamesLibraryManagement g, BusinessLogic.ConsoleManagement c)
		{
			gamesLibraryManagement = g;
			consoleManagement = c;

			InitializeComponent();

			lblAddGame.BackColor = bgcolor;
			lblName.BackColor = bgcolor;
			lblDeveloper.BackColor = bgcolor;
			lblReleaseDate.BackColor = bgcolor;
			lblGenres.BackColor = bgcolor;
			lblRating.BackColor = bgcolor;
			lblDesc.BackColor = bgcolor;

			foreach (string genre in Enum.GetNames(typeof(BusinessLogic.Genres)))
			{
				cbbGenre.Items.Add(genre);
			}

		}

		private void AddGame_Load(object sender, EventArgs e)
		{

		}

		private void btnAddGame_Click(object sender, EventArgs e)
		{
			switch (cbbGenre.Text)
			{
				case "Fantasy":
					game = new BusinessLogic.Game(tbName.Text, tbDesc.Text, BusinessLogic.Genres.Fantasy, tbReleaseDate.Text, tbDeveloper.Text, tbRating.Text);
				break;

				case "SciFi":
					game = new BusinessLogic.Game(tbName.Text, tbDesc.Text, BusinessLogic.Genres.SciFi, tbReleaseDate.Text, tbDeveloper.Text, tbRating.Text);
					break;

				case "History":
					game = new BusinessLogic.Game(tbName.Text, tbDesc.Text, BusinessLogic.Genres.History, tbReleaseDate.Text, tbDeveloper.Text, tbRating.Text);
					break;

				case "Horror":
					game = new BusinessLogic.Game(tbName.Text, tbDesc.Text, BusinessLogic.Genres.Horror, tbReleaseDate.Text, tbDeveloper.Text, tbRating.Text);
					break;

				case "Action":
					game = new BusinessLogic.Game(tbName.Text, tbDesc.Text, BusinessLogic.Genres.Action, tbReleaseDate.Text, tbDeveloper.Text, tbRating.Text);
					break;

				case "Strategy":
					game = new BusinessLogic.Game(tbName.Text, tbDesc.Text, BusinessLogic.Genres.Strategy, tbReleaseDate.Text, tbDeveloper.Text, tbRating.Text);
					break;

				case "Sports":
					game = new BusinessLogic.Game(tbName.Text, tbDesc.Text, BusinessLogic.Genres.Sports, tbReleaseDate.Text, tbDeveloper.Text, tbRating.Text);
					break;

				case "MMO":
					game = new BusinessLogic.Game(tbName.Text, tbDesc.Text, BusinessLogic.Genres.MMO, tbReleaseDate.Text, tbDeveloper.Text, tbRating.Text);
					break;

				case "RPG":
					game = new BusinessLogic.Game(tbName.Text, tbDesc.Text, BusinessLogic.Genres.RPG, tbReleaseDate.Text, tbDeveloper.Text, tbRating.Text);
					break;

				case "FPS":
					game = new BusinessLogic.Game(tbName.Text, tbDesc.Text, BusinessLogic.Genres.FPS, tbReleaseDate.Text, tbDeveloper.Text, tbRating.Text);
					break;
			}

			SqlConnection con = new SqlConnection("Data Source=DESKTOP-8AACUE7\\SQLEXPRESS;Initial Catalog=dbPLAYRATE;Integrated Security=True;Pooling=False");
			con.Open();
			SqlCommand cmd = new SqlCommand("INSERT into dbo.Games VALUES (@ID, @Name, @Genre, @ReleaseDate, @Developer, @Rating, @Description)", con);

			cmd.Parameters.AddWithValue("@ID", 8);
			cmd.Parameters.AddWithValue("@Name", tbName.Text);
			cmd.Parameters.AddWithValue("@Genre", cbbGenre.Text);
			cmd.Parameters.AddWithValue("@ReleaseDate", DateTime.Parse(tbReleaseDate.Text));
			cmd.Parameters.AddWithValue("@Developer", tbDeveloper.Text);
			cmd.Parameters.AddWithValue("@Rating", tbRating.Text);
			cmd.Parameters.AddWithValue("@Description", tbDesc.Text);

			cmd.ExecuteNonQuery();

			con.Close();

			HomePage homePage = new HomePage(gamesLibraryManagement, consoleManagement);

			homePage.Show();
			this.Hide();
		}
	}
}