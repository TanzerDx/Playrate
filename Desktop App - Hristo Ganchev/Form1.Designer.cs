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
			tbDeleteIDConsole = new TextBox();
			label1 = new Label();
			label2 = new Label();
			tbDeleteIDGame = new TextBox();
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
			btnAddGame.Location = new Point(9, 71);
			btnAddGame.Name = "btnAddGame";
			btnAddGame.Size = new Size(454, 28);
			btnAddGame.TabIndex = 6;
			btnAddGame.Text = "Add Game";
			btnAddGame.UseVisualStyleBackColor = true;
			btnAddGame.Click += btnAddGame_Click;
			// 
			// btnShowAll
			// 
			btnShowAll.Location = new Point(9, 139);
			btnShowAll.Name = "btnShowAll";
			btnShowAll.Size = new Size(454, 31);
			btnShowAll.TabIndex = 8;
			btnShowAll.Text = "Show all games";
			btnShowAll.UseVisualStyleBackColor = true;
			btnShowAll.Click += btnShowAll_Click;
			// 
			// btnDeleteGame
			// 
			btnDeleteGame.Location = new Point(297, 105);
			btnDeleteGame.Name = "btnDeleteGame";
			btnDeleteGame.Size = new Size(166, 28);
			btnDeleteGame.TabIndex = 9;
			btnDeleteGame.Text = "Delete Game";
			btnDeleteGame.UseVisualStyleBackColor = true;
			btnDeleteGame.Click += btnDeleteGame_Click;
			// 
			// btnDeleteConsole
			// 
			btnDeleteConsole.Location = new Point(780, 105);
			btnDeleteConsole.Name = "btnDeleteConsole";
			btnDeleteConsole.Size = new Size(167, 28);
			btnDeleteConsole.TabIndex = 12;
			btnDeleteConsole.Text = "Delete Console";
			btnDeleteConsole.UseVisualStyleBackColor = true;
			btnDeleteConsole.Click += btnDeleteConsole_Click;
			// 
			// btnAddConsole
			// 
			btnAddConsole.Location = new Point(493, 71);
			btnAddConsole.Name = "btnAddConsole";
			btnAddConsole.Size = new Size(454, 28);
			btnAddConsole.TabIndex = 11;
			btnAddConsole.Text = "Add Console";
			btnAddConsole.UseVisualStyleBackColor = true;
			btnAddConsole.Click += btnAddConsole_Click;
			// 
			// dgAllGames
			// 
			dgAllGames.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgAllGames.Location = new Point(9, 186);
			dgAllGames.Name = "dgAllGames";
			dgAllGames.RowTemplate.Height = 25;
			dgAllGames.Size = new Size(454, 170);
			dgAllGames.TabIndex = 14;
			// 
			// dgAllConsoles
			// 
			dgAllConsoles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgAllConsoles.Location = new Point(493, 186);
			dgAllConsoles.Name = "dgAllConsoles";
			dgAllConsoles.RowTemplate.Height = 25;
			dgAllConsoles.Size = new Size(454, 170);
			dgAllConsoles.TabIndex = 15;
			// 
			// btnShowAllConsoles
			// 
			btnShowAllConsoles.Location = new Point(492, 139);
			btnShowAllConsoles.Name = "btnShowAllConsoles";
			btnShowAllConsoles.Size = new Size(454, 31);
			btnShowAllConsoles.TabIndex = 16;
			btnShowAllConsoles.Text = "Show all consoles";
			btnShowAllConsoles.UseVisualStyleBackColor = true;
			btnShowAllConsoles.Click += btnShowAllConsoles_Click;
			// 
			// tbDeleteIDConsole
			// 
			tbDeleteIDConsole.Location = new Point(520, 107);
			tbDeleteIDConsole.Name = "tbDeleteIDConsole";
			tbDeleteIDConsole.Size = new Size(254, 23);
			tbDeleteIDConsole.TabIndex = 17;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(493, 112);
			label1.Name = "label1";
			label1.Size = new Size(21, 15);
			label1.TabIndex = 18;
			label1.Text = "ID:";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(10, 112);
			label2.Name = "label2";
			label2.Size = new Size(21, 15);
			label2.TabIndex = 20;
			label2.Text = "ID:";
			// 
			// tbDeleteIDGame
			// 
			tbDeleteIDGame.Location = new Point(37, 107);
			tbDeleteIDGame.Name = "tbDeleteIDGame";
			tbDeleteIDGame.Size = new Size(254, 23);
			tbDeleteIDGame.TabIndex = 19;
			// 
			// HomePage
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackgroundImage = Properties.Resources.Screenshot_413;
			ClientSize = new Size(959, 368);
			Controls.Add(label2);
			Controls.Add(tbDeleteIDGame);
			Controls.Add(label1);
			Controls.Add(tbDeleteIDConsole);
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
			PerformLayout();
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
		private TextBox tbDeleteIDConsole;
		private Label label1;
		private Label label2;
		private TextBox tbDeleteIDGame;
	}
}