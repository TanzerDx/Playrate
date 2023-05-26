using BusinessLogic;
using PLAYRATE_ClassLibrary;
using PLAYRATE_ClassLibrary.Consoles;
using PLAYRATE_ClassLibrary.Games;
using PLAYRATE_DatabaseConnection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Console = PLAYRATE_ClassLibrary.Consoles.Console;

namespace Desktop_App___Hristo_Ganchev
{
    public partial class AddGame : Form
    {
        Color bgcolor = Color.FromArgb(48, 52, 145);

        SqlConnection con = new SqlConnection("Data Source=mssqlstud.fhict.local;Persist Security Info=True;User ID = dbi499630; Password=Jvm5cNGGkr");

        ConsoleService consoleService;
        GameService gamesService;

        public AddGame()
        {
            InitializeComponent();

            lblConsole.BackColor = bgcolor;
            lblAddGame.BackColor = bgcolor;
            lblName.BackColor = bgcolor;
            lblDeveloper.BackColor = bgcolor;
            lblReleaseDate.BackColor = bgcolor;
            lblGenres.BackColor = bgcolor;
            lblDesc.BackColor = bgcolor;
            lblURLGame.BackColor = bgcolor;
            lblURLPage.BackColor = bgcolor;

            GetConsoles();

            foreach (string genre in Enum.GetNames(typeof(BusinessLogic.Genres)))
            {
                cbbGenre.Items.Add(genre);
            }
        }

        public AddGame(ConsoleService cS, GameService gS)
        {
            InitializeComponent();

            lblConsole.BackColor = bgcolor;
            lblAddGame.BackColor = bgcolor;
            lblName.BackColor = bgcolor;
            lblDeveloper.BackColor = bgcolor;
            lblReleaseDate.BackColor = bgcolor;
            lblGenres.BackColor = bgcolor;
            lblDesc.BackColor = bgcolor;
            lblURLGame.BackColor = bgcolor;
            lblURLPage.BackColor = bgcolor;

            consoleService = cS;
            gamesService = gS;

            GetConsoles();

            foreach (string genre in Enum.GetNames(typeof(BusinessLogic.Genres)))
            {
                cbbGenre.Items.Add(genre);
            }
        }

        public void GetConsoles()
        {
            foreach (string c in consoleService.GetConsoleByName().Value)
            {
                cbbConsole.Items.Add(c);
            }
        }

        private void AddGame_Load(object sender, EventArgs e)
        {

        }

        private void btnAddGame_Click(object sender, EventArgs e)
        {
            try
            {
                gamesService.AddGame(cbbConsole.Text, tbName.Text, tbDeveloper.Text, Convert.ToDateTime(tbReleaseDate.Text), cbbGenre.Text, tbDesc.Text, tbURLGame.Text, tbURLPage.Text, consoleService.GetConsoleID(cbbConsole.Text).Value);

                MessageBox.Show("Game added successfully!");

                HomePage homePage = new HomePage(consoleService, gamesService);

                homePage.Show();
                this.Hide();
            }
            catch
            {
                MessageBox.Show("Error. Make sure that you have entered the correct data!");
            }
        }
    }
}