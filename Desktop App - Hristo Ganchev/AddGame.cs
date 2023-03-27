﻿using BusinessLogic;
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

namespace Desktop_App___Hristo_Ganchev
{
    public partial class AddGame : Form
    {
        GamesLibraryManagement gLM = new GamesLibraryManagement();
        ConsoleManagement cM = new ConsoleManagement();

        Game game;

        DataLibrary dataLibrary = new DataLibrary();

        Color bgcolor = Color.FromArgb(48, 52, 145);

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-8AACUE7\\SQLEXPRESS;Initial Catalog=dbPLAYRATE;Integrated Security=True;Pooling=False");

        public AddGame()
        {
            InitializeComponent();
            GetConsoles();


            lblConsole.BackColor = bgcolor;
            lblAddGame.BackColor = bgcolor;
            lblName.BackColor = bgcolor;
            lblDeveloper.BackColor = bgcolor;
            lblReleaseDate.BackColor = bgcolor;
            lblGenres.BackColor = bgcolor;
            lblRating.BackColor = bgcolor;
            lblDesc.BackColor = bgcolor;
            lblURLGame.BackColor = bgcolor;
            lblURLPage.BackColor = bgcolor;

        }

        public AddGame(GamesLibraryManagement gamesLibraryManagement, ConsoleManagement consoleManagement)
        {
            InitializeComponent();
            GetConsoles();

            gamesLibraryManagement = gLM;
            consoleManagement = cM;

            lblConsole.BackColor = bgcolor;
            lblAddGame.BackColor = bgcolor;
            lblName.BackColor = bgcolor;
            lblDeveloper.BackColor = bgcolor;
            lblReleaseDate.BackColor = bgcolor;
            lblGenres.BackColor = bgcolor;
            lblRating.BackColor = bgcolor;
            lblDesc.BackColor = bgcolor;
            lblURLGame.BackColor = bgcolor;
            lblURLPage.BackColor = bgcolor;

            foreach (string genre in Enum.GetNames(typeof(BusinessLogic.Genres)))
            {
                cbbGenre.Items.Add(genre);
            }
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

        private void AddGame_Load(object sender, EventArgs e)
        {

        }

        private void btnAddGame_Click(object sender, EventArgs e)
        {
            try
            {
                switch (cbbGenre.Text)
                {
                    case "Fantasy":
                        game = new BusinessLogic.Game(tbName.Text, tbDesc.Text, BusinessLogic.Genres.Fantasy, tbReleaseDate.Text, tbDeveloper.Text, tbRating.Text);
                        break;

                    case "SciFi":
                        game = new BusinessLogic.Game(tbName.Text, tbDesc.Text, BusinessLogic.Genres.SciFi, tbReleaseDate.Text, tbDeveloper.Text, tbRating.Text);
                        break;

                    case "History":
                        game = new BusinessLogic.Game(tbName.Text, tbDesc.Text, BusinessLogic.Genres.History, tbReleaseDate.Text, tbDeveloper.Text, tbRating.Text);
                        break;

                    case "Horror":
                        game = new BusinessLogic.Game(tbName.Text, tbDesc.Text, BusinessLogic.Genres.Horror, tbReleaseDate.Text, tbDeveloper.Text, tbRating.Text);
                        break;

                    case "Action":
                        game = new BusinessLogic.Game(tbName.Text, tbDesc.Text, BusinessLogic.Genres.Action, tbReleaseDate.Text, tbDeveloper.Text, tbRating.Text);
                        break;

                    case "Strategy":
                        game = new BusinessLogic.Game(tbName.Text, tbDesc.Text, BusinessLogic.Genres.Strategy, tbReleaseDate.Text, tbDeveloper.Text, tbRating.Text);
                        break;

                    case "Sports":
                        game = new BusinessLogic.Game(tbName.Text, tbDesc.Text, BusinessLogic.Genres.Sports, tbReleaseDate.Text, tbDeveloper.Text, tbRating.Text);
                        break;

                    case "MMO":
                        game = new BusinessLogic.Game(tbName.Text, tbDesc.Text, BusinessLogic.Genres.MMO, tbReleaseDate.Text, tbDeveloper.Text, tbRating.Text);
                        break;

                    case "RPG":
                        game = new BusinessLogic.Game(tbName.Text, tbDesc.Text, BusinessLogic.Genres.RPG, tbReleaseDate.Text, tbDeveloper.Text, tbRating.Text);
                        break;

                    case "FPS":
                        game = new BusinessLogic.Game(tbName.Text, tbDesc.Text, BusinessLogic.Genres.FPS, tbReleaseDate.Text, tbDeveloper.Text, tbRating.Text);
                        break;
                }

                gLM.AddGame(game);

                dataLibrary.AddGame(cbbConsole.Text, tbName.Text, cbbGenre.Text, tbReleaseDate.Text, tbDeveloper.Text, tbRating.Text, tbDesc.Text, tbURLGame.Text, tbURLPage.Text);

                MessageBox.Show("Game added successfully!");

                HomePage homePage = new HomePage(gLM, cM);

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