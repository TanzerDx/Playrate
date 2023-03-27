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
            btnShowGames = new Button();
            btnDeleteGame = new Button();
            btnDeleteConsole = new Button();
            btnAddConsole = new Button();
            dgGames = new DataGridView();
            lblID = new Label();
            tbDeleteIDGame = new TextBox();
            cbbConsole = new ComboBox();
            lblConsole = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgGames).BeginInit();
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
            btnAddGame.Location = new Point(16, 259);
            btnAddGame.Name = "btnAddGame";
            btnAddGame.Size = new Size(306, 28);
            btnAddGame.TabIndex = 6;
            btnAddGame.Text = "Add Game";
            btnAddGame.UseVisualStyleBackColor = true;
            btnAddGame.Click += btnAddGame_Click;
            // 
            // btnShowGames
            // 
            btnShowGames.Location = new Point(16, 110);
            btnShowGames.Name = "btnShowGames";
            btnShowGames.Size = new Size(306, 31);
            btnShowGames.TabIndex = 8;
            btnShowGames.Text = "Show Games";
            btnShowGames.UseVisualStyleBackColor = true;
            btnShowGames.Click += btnShowAll_Click;
            // 
            // btnDeleteGame
            // 
            btnDeleteGame.Location = new Point(201, 145);
            btnDeleteGame.Name = "btnDeleteGame";
            btnDeleteGame.Size = new Size(121, 28);
            btnDeleteGame.TabIndex = 9;
            btnDeleteGame.Text = "Delete Game";
            btnDeleteGame.UseVisualStyleBackColor = true;
            btnDeleteGame.Click += btnDeleteGame_Click;
            // 
            // btnDeleteConsole
            // 
            btnDeleteConsole.Location = new Point(18, 179);
            btnDeleteConsole.Name = "btnDeleteConsole";
            btnDeleteConsole.Size = new Size(306, 28);
            btnDeleteConsole.TabIndex = 12;
            btnDeleteConsole.Text = "Delete Console";
            btnDeleteConsole.UseVisualStyleBackColor = true;
            btnDeleteConsole.Click += btnDeleteConsole_Click;
            // 
            // btnAddConsole
            // 
            btnAddConsole.Location = new Point(16, 293);
            btnAddConsole.Name = "btnAddConsole";
            btnAddConsole.Size = new Size(306, 28);
            btnAddConsole.TabIndex = 11;
            btnAddConsole.Text = "Add Console";
            btnAddConsole.UseVisualStyleBackColor = true;
            btnAddConsole.Click += btnAddConsole_Click;
            // 
            // dgGames
            // 
            dgGames.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgGames.Location = new Point(399, 12);
            dgGames.Name = "dgGames";
            dgGames.RowTemplate.Height = 25;
            dgGames.Size = new Size(482, 311);
            dgGames.TabIndex = 14;
            // 
            // lblID
            // 
            lblID.AutoSize = true;
            lblID.ForeColor = Color.White;
            lblID.Location = new Point(14, 152);
            lblID.Name = "lblID";
            lblID.Size = new Size(21, 15);
            lblID.TabIndex = 20;
            lblID.Text = "ID:";
            lblID.Click += label2_Click;
            // 
            // tbDeleteIDGame
            // 
            tbDeleteIDGame.Location = new Point(41, 147);
            tbDeleteIDGame.Name = "tbDeleteIDGame";
            tbDeleteIDGame.Size = new Size(154, 23);
            tbDeleteIDGame.TabIndex = 19;
            tbDeleteIDGame.TextChanged += tbDeleteIDGame_TextChanged;
            // 
            // cbbConsole
            // 
            cbbConsole.FormattingEnabled = true;
            cbbConsole.Location = new Point(93, 81);
            cbbConsole.Name = "cbbConsole";
            cbbConsole.Size = new Size(229, 23);
            cbbConsole.TabIndex = 24;
            cbbConsole.SelectedIndexChanged += cbbConsole_SelectedIndexChanged;
            // 
            // lblConsole
            // 
            lblConsole.AutoSize = true;
            lblConsole.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblConsole.ForeColor = Color.White;
            lblConsole.Location = new Point(16, 82);
            lblConsole.Name = "lblConsole";
            lblConsole.Size = new Size(69, 21);
            lblConsole.TabIndex = 23;
            lblConsole.Text = "Console:";
            // 
            // HomePage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Screenshot_413;
            ClientSize = new Size(895, 354);
            Controls.Add(cbbConsole);
            Controls.Add(lblConsole);
            Controls.Add(lblID);
            Controls.Add(tbDeleteIDGame);
            Controls.Add(dgGames);
            Controls.Add(btnDeleteConsole);
            Controls.Add(btnAddConsole);
            Controls.Add(btnDeleteGame);
            Controls.Add(btnShowGames);
            Controls.Add(btnAddGame);
            Controls.Add(pictureBox1);
            Name = "HomePage";
            Text = "Home Page";
            Load += HomePage_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgGames).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Button btnAddGame;
        private Button btnShowGames;
        private Button btnDeleteGame;
        private Button btnDeleteConsole;
        private Button btnAddConsole;
        private DataGridView dgGames;
        private Label lblID;
        private TextBox tbDeleteIDGame;
        private ComboBox cbbConsole;
        private Label lblConsole;
    }
}