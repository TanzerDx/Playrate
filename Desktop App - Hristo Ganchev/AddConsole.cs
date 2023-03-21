using BusinessLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop_App___Hristo_Ganchev
{
	public partial class AddConsole : Form
	{
		BusinessLogic.GamesLibraryManagement gamesLibraryManagement = new BusinessLogic.GamesLibraryManagement();
		BusinessLogic.ConsoleManagement consoleManagement = new BusinessLogic.ConsoleManagement();

		BusinessLogic.Console console;

		Color bgcolor = Color.FromArgb(48, 52, 145);

		public AddConsole()
		{
			InitializeComponent();
		}

		public AddConsole(BusinessLogic.GamesLibraryManagement g, BusinessLogic.ConsoleManagement c)
		{
			gamesLibraryManagement = g;
			consoleManagement = c;

			InitializeComponent();

			lblType.BackColor = bgcolor;
			lblReleaseDate.BackColor = bgcolor;
			lblModel.BackColor = bgcolor;
			lblManufacturer.BackColor = bgcolor;
			lblControllerType.BackColor = bgcolor;
			lblChatPlatform.BackColor = bgcolor;
			lblAddConsole.BackColor = bgcolor;
		}

		private void AddConsole_Load(object sender, EventArgs e)
		{

		}

		private void btnAddConsole_Click(object sender, EventArgs e)
		{
			switch (cbbType.Text)
			{
				case "PlayStation":
					console = new PlayStation(tbModel.Text, tbManufacturer.Text, tbReleaseDate.Text, tbControllerType.Text);
					break;
				case "Xbox":
					console = new Xbox(tbModel.Text, tbManufacturer.Text, tbReleaseDate.Text, tbControllerType.Text, tbChatPlatform.Text);
					break;
			}

			consoleManagement.AddConsole(console);

			HomePage homePage = new HomePage(gamesLibraryManagement, consoleManagement);

			homePage.Show();
			this.Hide();

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
	}
}
