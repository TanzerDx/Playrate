using BusinessLogic;
using PLAYRATE_ClassLibrary;
using PLAYRATE_ClassLibrary.Consoles;
using PLAYRATE_ClassLibrary.Games;
using PLAYRATE_DatabaseConnection;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace Desktop_App___Hristo_Ganchev
{
    public partial class HomePage : Form
    {
        SqlConnection con = new SqlConnection("Data Source=mssqlstud.fhict.local;Persist Security Info=True;User ID = dbi499630; Password=Jvm5cNGGkr");

        Color bgcolor = Color.FromArgb(48, 52, 145);

        
        ConsoleService consoleService;    
        GameService gamesService;

        public HomePage(IConsoleRepository consoleRepository, IGameRepository gamesRepository)
        {
            InitializeComponent();
            GetConsoles();

            lblConsole.BackColor = bgcolor;
            lblID.BackColor = bgcolor;
            dgGames.BackgroundColor = bgcolor;

            consoleService = new ConsoleService(consoleRepository);
            gamesService = new GameService(gamesRepository);

        }

        public HomePage(ConsoleService cS, GameService gS)
        {
            InitializeComponent();
            GetConsoles();

            lblConsole.BackColor = bgcolor;
            lblID.BackColor = bgcolor;
            dgGames.BackgroundColor = bgcolor;

            consoleService = cS;
            gamesService = gS;

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
            AddGame addgame = new AddGame(consoleService, gamesService);

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
                gamesService.RemoveGame(cbbConsole.Text, tbDeleteIDGame.Text);

				MessageBox.Show("Game deleted successfully!");
			}
            catch
            {
                MessageBox.Show("Please make sure you have entered a correct ID!");
            }

        }

        private void btnAddConsole_Click(object sender, EventArgs e)
        {
            AddConsole addConsole = new AddConsole(consoleService, gamesService);

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
                consoleService.RemoveConsole(cbbConsole.Text);
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