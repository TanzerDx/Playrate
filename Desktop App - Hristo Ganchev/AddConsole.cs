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
using System.Xml.Linq;

namespace Desktop_App___Hristo_Ganchev
{

    public partial class AddConsole : Form
    {
        ConsoleService consoleService;
        GameService gamesService;

        Color bgcolor = Color.FromArgb(48, 52, 145);

        public AddConsole()
        {
            InitializeComponent();

            lblType.BackColor = bgcolor;
            lblReleaseDate.BackColor = bgcolor;
            lblModel.BackColor = bgcolor;
            lblManufacturer.BackColor = bgcolor;
            lblControllerType.BackColor = bgcolor;
            lblChatPlatform.BackColor = bgcolor;
            lblAddConsole.BackColor = bgcolor;
            lblURLConsole.BackColor = bgcolor;

        }

        public AddConsole(ConsoleService cS, GameService gS)
        {
            InitializeComponent();

            lblType.BackColor = bgcolor;
            lblReleaseDate.BackColor = bgcolor;
            lblModel.BackColor = bgcolor;
            lblManufacturer.BackColor = bgcolor;
            lblControllerType.BackColor = bgcolor;
            lblChatPlatform.BackColor = bgcolor;
            lblAddConsole.BackColor = bgcolor;
            lblURLConsole.BackColor = bgcolor;

            consoleService = cS;
            gamesService = gS;
        }


        private void AddConsole_Load(object sender, EventArgs e)
        {

        }

        private void btnAddConsole_Click(object sender, EventArgs e)
        {
            try
            {

                consoleService.AddConsole(cbbType.Text, tbModel.Text, tbManufacturer.Text, tbReleaseDate.Text, tbURLConsole.Text, tbControllerType.Text, tbChatPlatform.Text);

                MessageBox.Show("Console added successfully!");

                HomePage homePage = new HomePage(consoleService, gamesService);

                homePage.Show();
                this.Hide();

            }
            catch
            {
                MessageBox.Show("Error. Make sure that you have entered the correct data!");
            }

        }

        private void cbbType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tbModel_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblChatPlatform_Click(object sender, EventArgs e)
        {

        }

        private void tbChatPlatform_TextChanged(object sender, EventArgs e)
        {
        }

        private void lblURLGame_Click(object sender, EventArgs e)
        {

        }

        private void tbURLGame_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
