namespace Desktop_App___Hristo_Ganchev
{
	partial class HomePage
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			pictureBox1 = new PictureBox();
			btnAddGame = new Button();
			btnShowAll = new Button();
			btnDeleteGame = new Button();
			btnDeleteConsole = new Button();
			btnAddConsole = new Button();
			dgAllGames = new DataGridView();
			dgAllConsoles = new DataGridView();
			btnShowAllConsoles = new Button();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			((System.ComponentModel.ISupportInitialize)dgAllGames).BeginInit();
			((System.ComponentModel.ISupportInitialize)dgAllConsoles).BeginInit();
			SuspendLayout();
			// 
			// pictureBox1
			// 
			pictureBox1.Image = Properties.Resources.Screenshot_414;
			pictureBox1.Location = new Point(3, 2);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new Size(223, 50);
			pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
			pictureBox1.TabIndex = 0;
			pictureBox1.TabStop = false;
			// 
			// btnAddGame
			// 
			btnAddGame.Location = new Point(9, 80);
			btnAddGame.Name = "btnAddGame";
			btnAddGame.Size = new Size(215, 28);
			btnAddGame.TabIndex = 6;
			btnAddGame.Text = "Add Game";
			btnAddGame.UseVisualStyleBackColor = true;
			btnAddGame.Click += btnAddGame_Click;
			// 
			// btnShowAll
			// 
			btnShowAll.Location = new Point(9, 114);
			btnShowAll.Name = "btnShowAll";
			btnShowAll.Size = new Size(454, 31);
			btnShowAll.TabIndex = 8;
			btnShowAll.Text = "Show all games";
			btnShowAll.UseVisualStyleBackColor = true;
			btnShowAll.Click += btnShowAll_Click;
			// 
			// btnDeleteGame
			// 
			btnDeleteGame.Location = new Point(248, 80);
			btnDeleteGame.Name = "btnDeleteGame";
			btnDeleteGame.Size = new Size(215, 28);
			btnDeleteGame.TabIndex = 9;
			btnDeleteGame.Text = "Delete Game";
			btnDeleteGame.UseVisualStyleBackColor = true;
			btnDeleteGame.Click += btnDeleteGame_Click;
			// 
			// btnDeleteConsole
			// 
			btnDeleteConsole.Location = new Point(731, 80);
			btnDeleteConsole.Name = "btnDeleteConsole";
			btnDeleteConsole.Size = new Size(215, 28);
			btnDeleteConsole.TabIndex = 12;
			btnDeleteConsole.Text = "Delete Console";
			btnDeleteConsole.UseVisualStyleBackColor = true;
			btnDeleteConsole.Click += btnDeleteConsole_Click;
			// 
			// btnAddConsole
			// 
			btnAddConsole.Location = new Point(492, 80);
			btnAddConsole.Name = "btnAddConsole";
			btnAddConsole.Size = new Size(215, 28);
			btnAddConsole.TabIndex = 11;
			btnAddConsole.Text = "Add Console";
			btnAddConsole.UseVisualStyleBackColor = true;
			btnAddConsole.Click += btnAddConsole_Click;
			// 
			// dgAllGames
			// 
			dgAllGames.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgAllGames.Location = new Point(9, 151);
			dgAllGames.Name = "dgAllGames";
			dgAllGames.RowTemplate.Height = 25;
			dgAllGames.Size = new Size(454, 170);
			dgAllGames.TabIndex = 14;
			// 
			// dgAllConsoles
			// 
			dgAllConsoles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgAllConsoles.Location = new Point(493, 151);
			dgAllConsoles.Name = "dgAllConsoles";
			dgAllConsoles.RowTemplate.Height = 25;
			dgAllConsoles.Size = new Size(454, 170);
			dgAllConsoles.TabIndex = 15;
			// 
			// btnShowAllConsoles
			// 
			btnShowAllConsoles.Location = new Point(493, 114);
			btnShowAllConsoles.Name = "btnShowAllConsoles";
			btnShowAllConsoles.Size = new Size(454, 31);
			btnShowAllConsoles.TabIndex = 16;
			btnShowAllConsoles.Text = "Show all consoles";
			btnShowAllConsoles.UseVisualStyleBackColor = true;
			btnShowAllConsoles.Click += btnShowAllConsoles_Click;
			// 
			// HomePage
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackgroundImage = Properties.Resources.Screenshot_413;
			ClientSize = new Size(959, 343);
			Controls.Add(btnShowAllConsoles);
			Controls.Add(dgAllConsoles);
			Controls.Add(dgAllGames);
			Controls.Add(btnDeleteConsole);
			Controls.Add(btnAddConsole);
			Controls.Add(btnDeleteGame);
			Controls.Add(btnShowAll);
			Controls.Add(btnAddGame);
			Controls.Add(pictureBox1);
			Name = "HomePage";
			Text = "Home Page";
			Load += HomePage_Load;
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			((System.ComponentModel.ISupportInitialize)dgAllGames).EndInit();
			((System.ComponentModel.ISupportInitialize)dgAllConsoles).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private PictureBox pictureBox1;
		private Button btnAddGame;
		private Button btnShowAll;
		private Button btnDeleteGame;
		private Button btnDeleteConsole;
		private Button btnAddConsole;
		private DataGridView dgAllGames;
		private DataGridView dgAllConsoles;
		private Button btnShowAllConsoles;
	}
}