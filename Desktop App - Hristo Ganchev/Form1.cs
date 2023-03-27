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

            string query = "SELECT Model FROM dbo.Consoles";

            using (SqlCommand command = new SqlCommand(query, con))
            {

                using (SqlDataReader reader = command.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        cbbConsole.Items.Add(reader.GetString(0));
                    }
                }
            }

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
            try
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
            catch
            {
                MessageBox.Show("The console does not exist!");
            }
        }

        private void lbAllGames_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnDeleteGame_Click(object sender, EventArgs e)
        {
            try
            {
                dataLibrary.RemoveGame(cbbConsole.Text, tbDeleteIDGame.Text);
            }
            catch
            {
                MessageBox.Show("Please make sure you have entered a correct ID!");
            }

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
            try
            { 
                dataLibrary.RemoveConsole(cbbConsole.Text);
                MessageBox.Show("Console deleted successfully!");

                cbbConsole.Items.Clear();
                cbbConsole.Text = "";
                GetConsoles();
            }
            catch
            {
                MessageBox.Show("The console does not exist!");
            }
        }

        private void dgAllConsoles_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void cbbAllConsoles_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void btnShowAllConsoles_Click(object sender, EventArgs e)
        {

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