using PLAYRATE_DatabaseConnection;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace Desktop_App___Hristo_Ganchev
{
	public partial class HomePage : Form
	{
		DataLibrary dataLibrary = new DataLibrary();

		Color bgcolor = Color.FromArgb(48, 52, 145);

		SqlConnection con = new SqlConnection("Data Source=DESKTOP-8AACUE7\\SQLEXPRESS;Initial Catalog=dbPLAYRATE;Integrated Security=True;Pooling=False");

		public HomePage()
		{
			InitializeComponent();

			dgAllConsoles.BackgroundColor = bgcolor;
			dgAllGames.BackgroundColor = bgcolor;

		}

		private void HomePage_Load(object sender, EventArgs e)
		{

		}

		private void btnAddGame_Click(object sender, EventArgs e)
		{
			AddGame addgame = new AddGame();

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
			dataLibrary.RemoveGame(tbDeleteIDGame.Text);
		}

		private void btnAddConsole_Click(object sender, EventArgs e)
		{
			AddConsole addConsole = new AddConsole();

			addConsole.Show();
			this.Hide();
		}

		private void dgAllGames_CellClick(object sender, DataGridViewCellEventArgs e)
		{

		}

		private void btnDeleteConsole_Click(object sender, EventArgs e)
		{
			dataLibrary.RemoveConsole(tbDeleteIDConsole.Text);
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