using BusinessLogic;
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
        GamesLibraryManagement gLM = new GamesLibraryManagement();
        ConsoleManagement cM = new ConsoleManagement();

        BusinessLogic.Console console;

        DataLibrary dataLibrary = new DataLibrary();

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

        public AddConsole(GamesLibraryManagement gamesLibraryManagement, ConsoleManagement consoleManagement)
        {
            InitializeComponent();

            gamesLibraryManagement = gLM;
            consoleManagement = cM;

            lblType.BackColor = bgcolor;
            lblReleaseDate.BackColor = bgcolor;
            lblModel.BackColor = bgcolor;
            lblManufacturer.BackColor = bgcolor;
            lblControllerType.BackColor = bgcolor;
            lblChatPlatform.BackColor = bgcolor;
            lblAddConsole.BackColor = bgcolor;
            lblURLConsole.BackColor = bgcolor;
        }

        private void AddConsole_Load(object sender, EventArgs e)
        {

        }

        private void btnAddConsole_Click(object sender, EventArgs e)
        {
            //try
            //{

                switch (cbbType.Text)
                {
                    case "PlayStation":
                        console = new PlayStation(tbModel.Text, tbManufacturer.Text, tbReleaseDate.Text, tbControllerType.Text);
                        break;
                    case "Xbox":
                        console = new Xbox(tbModel.Text, tbManufacturer.Text, tbReleaseDate.Text, tbControllerType.Text, tbChatPlatform.Text);
                        break;
                }

                cM.AddConsole(console);

                dataLibrary.AddConsole(cbbType.Text, tbModel.Text, tbManufacturer.Text, tbReleaseDate.Text, tbURLConsole.Text, tbControllerType.Text, tbChatPlatform.Text);

                HomePage homePage = new HomePage(gLM, cM);

                homePage.Show();
                this.Hide();

            //}
            //catch
            //{
            //    MessageBox.Show("Error. Make sure that you have entered the correct data!");
            //}

        }

        private void cbbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //switch (cbbType.Text)
            //{
            //	case "PlayStation":

            //		tbModel.Enabled = true;
            //		tbManufacturer.Enabled = true;
            //		tbReleaseDate.Enabled = true;
            //		tbControllerType.Enabled = true;

            //		break;
            //	case "Xbox":

            //		tbModel.Enabled = true;
            //		tbManufacturer.Enabled = true;
            //		tbReleaseDate.Enabled = true;
            //		tbControllerType.Enabled = true;
            //		tbChatPlatform.Enabled = true;

            //		break;
            //}
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
