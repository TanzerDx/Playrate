namespace Desktop_App___Hristo_Ganchev
{
	public partial class HomePage : Form
	{
		GamesLibraryManagement gamesLibraryManagement = new GamesLibraryManagement();
		AccountLibraryManagement accountLibraryManagement = new AccountLibraryManagement();

		Color bgcolor = Color.FromArgb(48, 52, 145);

		public HomePage()
		{
			InitializeComponent();

			lblDeveloper.BackColor = bgcolor;
			lblReleaseDate.BackColor = bgcolor;
			lblGenres.BackColor = bgcolor;
			lblRating.BackColor = bgcolor;
			lblDesc.BackColor = bgcolor;
		}

		public HomePage(GamesLibraryManagement g, AccountLibraryManagement a)
		{
			gamesLibraryManagement = g;
			accountLibraryManagement = a;

			InitializeComponent();

			this.BackColor = bgcolor;

			lblDeveloper.BackColor = bgcolor;
			lblReleaseDate.BackColor = bgcolor;
			lblGenres.BackColor = bgcolor;
			lblRating.BackColor = bgcolor;
			lblDesc.BackColor = bgcolor;
		}

		private void HomePage_Load(object sender, EventArgs e)
		{

		}

		private void btnAddGame_Click(object sender, EventArgs e)
		{
			AddGame addgame = new AddGame(gamesLibraryManagement, accountLibraryManagement);

			this.Hide();
			addgame.Show();
		}

		private void btnShowAll_Click(object sender, EventArgs e)
		{
			lbAllGames.Items.Clear();

			foreach (Game g in gamesLibraryManagement.GetAllGames())
			{
				lbAllGames.Items.Add(g.GetName());
			}
		}

		private void lbAllGames_SelectedIndexChanged(object sender, EventArgs e)
		{
			Game g = gamesLibraryManagement.GetAllGames()[lbAllGames.SelectedIndex];

			lblDesc.Text = $"Description: {g.GetDesc()}";
			lblGenres.Text = $"Genres: {g.GetGenre()}";
			lblRating.Text = $"Rating: {g.GetRating()}";
			lblDeveloper.Text = $"Developer: {g.GetDeveloper()}";
			lblReleaseDate.Text = $"Release Date: {g.GetReleaseDate()}";
		}

		private void btnDeleteGame_Click(object sender, EventArgs e)
		{
			Game game = gamesLibraryManagement.GetAllGames()[lbAllGames.SelectedIndex];

			gamesLibraryManagement.RemoveGame(game);

			lbAllGames.Items.Clear();

			foreach (Game g in gamesLibraryManagement.GetAllGames())
			{
				lbAllGames.Items.Add(g.GetName());
			}
		}
	}
}