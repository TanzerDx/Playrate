using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
		BusinessLogic.AccountLibraryManagement accountLibraryManagement = new BusinessLogic.AccountLibraryManagement();

		Color bgcolor = Color.FromArgb(48, 52, 145);

		public AddGame()
		{
			InitializeComponent();
		}

		public AddGame(BusinessLogic.GamesLibraryManagement g, BusinessLogic.AccountLibraryManagement a)
		{
			gamesLibraryManagement = g;
			accountLibraryManagement = a;

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
			BusinessLogic.Game game = new BusinessLogic.Game(tbName.Text, tbDesc.Text, BusinessLogic.Genres.RPG, tbReleaseDate.Text, tbDeveloper.Text, tbRating.Text);

			gamesLibraryManagement.AddGame(game);

			HomePage homePage = new HomePage(gamesLibraryManagement, accountLibraryManagement);

			homePage.Show();
			this.Hide();
		}
	}
}