﻿using System;
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
		GamesLibraryManagement gamesLibraryManagement = new GamesLibraryManagement();
		AccountLibraryManagement accountLibraryManagement = new AccountLibraryManagement();

		Color bgcolor = Color.FromArgb(48, 52, 145);

		public AddGame()
		{
			InitializeComponent();
		}

		public AddGame(GamesLibraryManagement g, AccountLibraryManagement a)
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

			foreach (string genre in Enum.GetNames(typeof(Genres)))
			{
				cbbGenre.Items.Add(genre);
			}

		}

		private void AddGame_Load(object sender, EventArgs e)
		{

		}

		private void btnAddGame_Click(object sender, EventArgs e)
		{
			Game game = new Game(tbName.Text, tbDesc.Text, Genres.RPG, tbReleaseDate.Text, tbDeveloper.Text, tbRating.Text);

			gamesLibraryManagement.AddGame(game);

			HomePage homePage = new HomePage(gamesLibraryManagement, accountLibraryManagement);

			homePage.Show();
			this.Hide();
		}
	}
}