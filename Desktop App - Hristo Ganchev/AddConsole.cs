﻿using PLAYRATE_ClassLibrary.Games;
using PLAYRATE_DatabaseConnection.Consoles;
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
        PLAYRATE_ClassLibrary.Consoles.Console console;

        ConsoleLibrary consoleLibrary = new ConsoleLibrary("Data Source=DESKTOP-8AACUE7\\SQLEXPRESS;Initial Catalog=dbPLAYRATE;Integrated Security=True;Pooling=False");

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


        private void AddConsole_Load(object sender, EventArgs e)
        {

        }

        private void btnAddConsole_Click(object sender, EventArgs e)
        {
            try
            {

                consoleLibrary.AddConsole(cbbType.Text, tbModel.Text, tbManufacturer.Text, tbReleaseDate.Text, tbURLConsole.Text, tbControllerType.Text, tbChatPlatform.Text);

				MessageBox.Show("Console added successfully!");

				HomePage homePage = new HomePage();

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
