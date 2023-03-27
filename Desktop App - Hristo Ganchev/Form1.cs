using BusinessLogic;
using PLAYRATE_DatabaseConnection;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace Desktop_App___Hristo_Ganchev
{
    public partial class HomePage : Form
    {
        GamesLibraryManagement gLM = new GamesLibraryManagement();
        ConsoleManagement cM = new ConsoleManagement();

        DataLibrary dataLibrary = new DataLibrary();

        Color bgcolor = Color.FromArgb(48, 52, 145);

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-8AACUE7\\SQLEXPRESS;Initial Catalog=dbPLAYRATE;Integrated Security=True;Pooling=False");

        public HomePage()
        {
            InitializeComponent();
            GetConsoles();

            lblConsole.BackColor = bgcolor;
            lblID.BackColor = bgcolor;
            dgGames.BackgroundColor = bgcolor;

        }

        public HomePage(GamesLibraryManagement gamesLibraryManagement, ConsoleManagement consoleManagement)
        {
            InitializeComponent();
            GetConsoles();

            gamesLibraryManagement = gLM;
            consoleManagement = cM;

            lblConsole.BackColor = bgcolor;
            lblID.BackColor = bgcolor;
            dgGames.BackgroundColor = bgcolor;

        }

        public void GetConsoles()
        {
            con.Open();

            DataTable tables = con.GetSchema("Tables");
            List<string> consoles = new List<string>();

            foreach (DataRow row in tables.Rows)
            {
                string tableName = (string)row[2];
                consoles.Add(tableName);
            }

            consoles.Remove("Accounts");

            cbbConsole.DataSource = consoles;

            con.Close();
        }

        private void HomePage_Load(object sender, EventArgs e)
        {

        }

        private void btnAddGame_Click(object sender, EventArgs e)
        {
            AddGame addgame = new AddGame(gLM, cM);

            this.Hide();
            addgame.Show();
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            //btnShowGames

            con.Open();
            SqlCommand cmd = new SqlCommand($"SELECT * FROM dbo.{cbbConsole.Text}", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);
            dgGames.DataSource = dt;

            cmd.ExecuteNonQuery();

            con.Close();
        }

        private void lbAllGames_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnDeleteGame_Click(object sender, EventArgs e)
        {
            dataLibrary.RemoveGame(cbbConsole.Text, tbDeleteIDGame.Text);
        }

        private void btnAddConsole_Click(object sender, EventArgs e)
        {
            AddConsole addConsole = new AddConsole(gLM, cM);

            addConsole.Show();
            this.Hide();
        }

        private void dgAllGames_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnDeleteConsole_Click(object sender, EventArgs e)
        {
            dataLibrary.RemoveConsole(cbbConsole.Text);
        }

        private void dgAllConsoles_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void cbbAllConsoles_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void btnShowAllConsoles_Click(object sender, EventArgs e)
        {
            //con.Open();
            //SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Consoles", con);
            //SqlDataAdapter da = new SqlDataAdapter(cmd);

            //DataTable dt = new DataTable();
            //da.Fill(dt);
            //dgAllConsoles.DataSource = dt;

            //cmd.ExecuteNonQuery();

            //con.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void tbDeleteIDGame_TextChanged(object sender, EventArgs e)
        {
        }

        private void cbbConsole_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}