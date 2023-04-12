using BusinessLogic;
using PLAYRATE_ClassLibrary.Games;
using PLAYRATE_DatabaseConnection.Games;
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
        GameService gameService = new GameService();

        Color bgcolor = Color.FromArgb(48, 52, 145);

        SqlConnection con = new SqlConnection("Data Source=mssqlstud.fhict.local;Persist Security Info=True;User ID = dbi499630; Password=Jvm5cNGGkr");

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
                gameService.AddGame(cbbConsole.Text, tbName.Text, tbDeveloper.Text, tbReleaseDate.Text, cbbGenre.Text, tbRating.Text, tbDesc.Text, tbURLGame.Text, tbURLPage.Text);

                MessageBox.Show("Game added successfully!");

                HomePage homePage = new HomePage();

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