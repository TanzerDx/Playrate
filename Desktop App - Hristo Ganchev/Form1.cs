namespace Desktop_App___Hristo_Ganchev
{
	public partial class HomePage : Form
	{
		BusinessLogic.GamesLibraryManagement gamesLibraryManagement = new BusinessLogic.GamesLibraryManagement();
		BusinessLogic.ConsoleManagement consoleManagement = new BusinessLogic.ConsoleManagement();

		Color bgcolor = Color.FromArgb(48, 52, 145);

		public HomePage()
		{
			InitializeComponent();
			PrintConsoles();

			lblDeveloper.BackColor = bgcolor;
			lblReleaseDate.BackColor = bgcolor;
			lblGenres.BackColor = bgcolor;
			lblRating.BackColor = bgcolor;
			lblDesc.BackColor = bgcolor;
			lblConsole.BackColor = bgcolor;
		}

		public HomePage(BusinessLogic.GamesLibraryManagement g, BusinessLogic.ConsoleManagement c)
		{
			gamesLibraryManagement = g;
			consoleManagement = c;

			InitializeComponent();
			PrintConsoles();

			lblDeveloper.BackColor = bgcolor;
			lblReleaseDate.BackColor = bgcolor;
			lblGenres.BackColor = bgcolor;
			lblRating.BackColor = bgcolor;
			lblDesc.BackColor = bgcolor;
			lblConsole.BackColor = bgcolor;

		}

		private void HomePage_Load(object sender, EventArgs e)
		{

		}

		public void PrintConsoles()
		{
			foreach (BusinessLogic.Console c in consoleManagement.GetAllConsoles())
			{
				cbbAllConsoles.Items.Add(c.GetModel());
			}
		}

		private void btnAddGame_Click(object sender, EventArgs e)
		{
			AddGame addgame = new AddGame(gamesLibraryManagement, consoleManagement);

			this.Hide();
			addgame.Show();
		}

		private void btnShowAll_Click(object sender, EventArgs e)
		{
			lbAllGames.Items.Clear();

			foreach (BusinessLogic.Game g in gamesLibraryManagement.GetAllGames())
			{
				lbAllGames.Items.Add(g.GetName());
			}
		}

		private void lbAllGames_SelectedIndexChanged(object sender, EventArgs e)
		{
			BusinessLogic.Game g = gamesLibraryManagement.GetAllGames()[lbAllGames.SelectedIndex];

			lblDesc.Text = $"Description: {g.GetDesc()}";
			lblGenres.Text = $"Genres: {g.GetGenre()}";
			lblRating.Text = $"Rating: {g.GetRating()}";
			lblDeveloper.Text = $"Developer: {g.GetDeveloper()}";
			lblReleaseDate.Text = $"Release Date: {g.GetReleaseDate()}";
		}

		private void btnDeleteGame_Click(object sender, EventArgs e)
		{
			BusinessLogic.Game game = gamesLibraryManagement.GetAllGames()[lbAllGames.SelectedIndex];

			gamesLibraryManagement.RemoveGame(game);

			lbAllGames.Items.Clear();

			foreach (BusinessLogic.Game g in gamesLibraryManagement.GetAllGames())
			{
				lbAllGames.Items.Add(g.GetName());
			}
		}

		private void btnAddConsole_Click(object sender, EventArgs e)
		{
			AddConsole addConsole = new AddConsole(gamesLibraryManagement, consoleManagement);

			addConsole.Show();
			this.Hide();
		}

		private void btnDeleteConsole_Click(object sender, EventArgs e)
		{

		}

		private void cbbAllConsoles_SelectedIndexChanged(object sender, EventArgs e)
		{
		}
	}
}