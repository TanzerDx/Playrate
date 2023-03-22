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

		public HomePage()
		{
			InitializeComponent();

		}

		public HomePage(BusinessLogic.GamesLibraryManagement g, BusinessLogic.ConsoleManagement c)
		{
			gamesLibraryManagement = g;
			consoleManagement = c;

			InitializeComponent();

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
			SqlConnection con = new SqlConnection("Data Source=DESKTOP-8AACUE7\\SQLEXPRESS;Initial Catalog=dbPLAYRATE;Integrated Security=True;Pooling=False");
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

		private void btnShowAllConsoles_Click(object sender, EventArgs e)
		{
			SqlConnection con = new SqlConnection("Data Source=DESKTOP-8AACUE7\\SQLEXPRESS;Initial Catalog=dbPLAYRATE;Integrated Security=True;Pooling=False");
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