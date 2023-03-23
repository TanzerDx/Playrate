using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace Desktop_App___Hristo_Ganchev
{
	public partial class HomePage : Form
	{
		BusinessLogic.GamesLibraryManagement gamesLibraryManagement = new BusinessLogic.GamesLibraryManagement();
		BusinessLogic.ConsoleManagement consoleManagement = new BusinessLogic.ConsoleManagement();

		Color bgcolor = Color.FromArgb(48, 52, 145);

		SqlConnection con = new SqlConnection("Data Source=DESKTOP-8AACUE7\\SQLEXPRESS;Initial Catalog=dbPLAYRATE;Integrated Security=True;Pooling=False");

		public HomePage()
		{
			InitializeComponent();

			dgAllConsoles.BackgroundColor = bgcolor;
			dgAllGames.BackgroundColor = bgcolor;

		}

		public HomePage(BusinessLogic.GamesLibraryManagement g, BusinessLogic.ConsoleManagement c)
		{
			gamesLibraryManagement = g;
			consoleManagement = c;

			InitializeComponent();

			dgAllConsoles.BackgroundColor = bgcolor;
			dgAllGames.BackgroundColor = bgcolor;

		}

		private void HomePage_Load(object sender, EventArgs e)
		{

		}

		private void btnAddGame_Click(object sender, EventArgs e)
		{
			AddGame addgame = new AddGame(gamesLibraryManagement, consoleManagement);

			this.Hide();
			addgame.Show();
		}

		private void btnShowAll_Click(object sender, EventArgs e)
		{
			con.Open();
			SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Games", con);
			SqlDataAdapter da = new SqlDataAdapter(cmd);

			DataTable dt = new DataTable();
			da.Fill(dt);
			dgAllGames.DataSource = dt;

			cmd.ExecuteNonQuery();

			con.Close();
		}

		private void lbAllGames_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void btnDeleteGame_Click(object sender, EventArgs e)
		{
			int id = Convert.ToInt32(tbDeleteIDGame.Text);
			con.Open();

			SqlCommand cmd = new SqlCommand($"DELETE FROM dbo.Games WHERE ID='{id}'", con);
			cmd.ExecuteNonQuery();

			con.Close();

		}

		private void btnAddConsole_Click(object sender, EventArgs e)
		{
			AddConsole addConsole = new AddConsole(gamesLibraryManagement, consoleManagement);

			addConsole.Show();
			this.Hide();
		}

		private void dgAllGames_CellClick(object sender, DataGridViewCellEventArgs e)
		{

		}

		private void btnDeleteConsole_Click(object sender, EventArgs e)
		{
			int id = Convert.ToInt32(tbDeleteIDConsole.Text);

			con.Open();

			SqlCommand cmd = new SqlCommand($"DELETE FROM dbo.Consoles WHERE ID='{id}'", con);
			cmd.ExecuteNonQuery();

			con.Close();

		}

		private void dgAllConsoles_CellClick(object sender, DataGridViewCellEventArgs e)
		{

		}


		private void cbbAllConsoles_SelectedIndexChanged(object sender, EventArgs e)
		{
		}

		private void btnShowAllConsoles_Click(object sender, EventArgs e)
		{
			con.Open();
			SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Consoles", con);
			SqlDataAdapter da = new SqlDataAdapter(cmd);

			DataTable dt = new DataTable();
			da.Fill(dt);
			dgAllConsoles.DataSource = dt;

			cmd.ExecuteNonQuery();

			con.Close();
		}
	}
}