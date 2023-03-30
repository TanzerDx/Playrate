namespace Desktop_App___Hristo_Ganchev
{
    partial class AddGame
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblDesc = new Label();
            lblRating = new Label();
            lblGenres = new Label();
            lblReleaseDate = new Label();
            lblDeveloper = new Label();
            lblAddGame = new Label();
            tbDeveloper = new TextBox();
            tbReleaseDate = new TextBox();
            tbDesc = new TextBox();
            tbRating = new TextBox();
            cbbGenre = new ComboBox();
            btnAddGame = new Button();
            tbName = new TextBox();
            lblName = new Label();
            cbbConsole = new ComboBox();
            lblConsole = new Label();
            tbURLGame = new TextBox();
            lblURLGame = new Label();
            tbURLPage = new TextBox();
            lblURLPage = new Label();
            SuspendLayout();
            // 
            // lblDesc
            // 
            lblDesc.AutoSize = true;
            lblDesc.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblDesc.ForeColor = Color.White;
            lblDesc.Location = new Point(19, 256);
            lblDesc.Name = "lblDesc";
            lblDesc.Size = new Size(92, 21);
            lblDesc.TabIndex = 10;
            lblDesc.Text = "Description:";
            // 
            // lblRating
            // 
            lblRating.AutoSize = true;
            lblRating.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblRating.ForeColor = Color.White;
            lblRating.Location = new Point(478, 141);
            lblRating.Name = "lblRating";
            lblRating.Size = new Size(58, 21);
            lblRating.TabIndex = 9;
            lblRating.Text = "Rating:";
            // 
            // lblGenres
            // 
            lblGenres.AutoSize = true;
            lblGenres.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblGenres.ForeColor = Color.White;
            lblGenres.Location = new Point(478, 101);
            lblGenres.Name = "lblGenres";
            lblGenres.Size = new Size(62, 21);
            lblGenres.TabIndex = 8;
            lblGenres.Text = "Genres:";
            // 
            // lblReleaseDate
            // 
            lblReleaseDate.AutoSize = true;
            lblReleaseDate.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblReleaseDate.ForeColor = Color.White;
            lblReleaseDate.Location = new Point(19, 219);
            lblReleaseDate.Name = "lblReleaseDate";
            lblReleaseDate.Size = new Size(102, 21);
            lblReleaseDate.TabIndex = 7;
            lblReleaseDate.Text = "Release Date:";
            // 
            // lblDeveloper
            // 
            lblDeveloper.AutoSize = true;
            lblDeveloper.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblDeveloper.ForeColor = Color.White;
            lblDeveloper.Location = new Point(20, 179);
            lblDeveloper.Name = "lblDeveloper";
            lblDeveloper.Size = new Size(84, 21);
            lblDeveloper.TabIndex = 6;
            lblDeveloper.Text = "Developer:";
            // 
            // lblAddGame
            // 
            lblAddGame.AutoSize = true;
            lblAddGame.Font = new Font("Segoe UI Black", 26.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblAddGame.ForeColor = Color.White;
            lblAddGame.Location = new Point(20, 25);
            lblAddGame.Name = "lblAddGame";
            lblAddGame.Size = new Size(215, 47);
            lblAddGame.TabIndex = 11;
            lblAddGame.Text = "ADD GAME";
            // 
            // tbDeveloper
            // 
            tbDeveloper.Location = new Point(119, 179);
            tbDeveloper.Name = "tbDeveloper";
            tbDeveloper.Size = new Size(222, 23);
            tbDeveloper.TabIndex = 12;
            // 
            // tbReleaseDate
            // 
            tbReleaseDate.Location = new Point(137, 219);
            tbReleaseDate.Name = "tbReleaseDate";
            tbReleaseDate.Size = new Size(222, 23);
            tbReleaseDate.TabIndex = 13;
            // 
            // tbDesc
            // 
            tbDesc.Location = new Point(19, 289);
            tbDesc.Multiline = true;
            tbDesc.Name = "tbDesc";
            tbDesc.Size = new Size(763, 282);
            tbDesc.TabIndex = 14;
            // 
            // tbRating
            // 
            tbRating.Location = new Point(559, 140);
            tbRating.Name = "tbRating";
            tbRating.Size = new Size(222, 23);
            tbRating.TabIndex = 16;
            // 
            // cbbGenre
            // 
            cbbGenre.FormattingEnabled = true;
            cbbGenre.Location = new Point(559, 99);
            cbbGenre.Name = "cbbGenre";
            cbbGenre.Size = new Size(222, 23);
            cbbGenre.TabIndex = 17;
            // 
            // btnAddGame
            // 
            btnAddGame.Location = new Point(18, 582);
            btnAddGame.Name = "btnAddGame";
            btnAddGame.Size = new Size(290, 40);
            btnAddGame.TabIndex = 18;
            btnAddGame.Text = "Add Game";
            btnAddGame.UseVisualStyleBackColor = true;
            btnAddGame.Click += btnAddGame_Click;
            // 
            // tbName
            // 
            tbName.Location = new Point(97, 96);
            tbName.Name = "tbName";
            tbName.Size = new Size(222, 23);
            tbName.TabIndex = 20;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblName.ForeColor = Color.White;
            lblName.Location = new Point(20, 96);
            lblName.Name = "lblName";
            lblName.Size = new Size(55, 21);
            lblName.TabIndex = 19;
            lblName.Text = "Name:";
            // 
            // cbbConsole
            // 
            cbbConsole.FormattingEnabled = true;
            cbbConsole.Location = new Point(97, 137);
            cbbConsole.Name = "cbbConsole";
            cbbConsole.Size = new Size(222, 23);
            cbbConsole.TabIndex = 22;
            // 
            // lblConsole
            // 
            lblConsole.AutoSize = true;
            lblConsole.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblConsole.ForeColor = Color.White;
            lblConsole.Location = new Point(20, 137);
            lblConsole.Name = "lblConsole";
            lblConsole.Size = new Size(69, 21);
            lblConsole.TabIndex = 21;
            lblConsole.Text = "Console:";
            // 
            // tbURLGame
            // 
            tbURLGame.Location = new Point(582, 180);
            tbURLGame.Name = "tbURLGame";
            tbURLGame.Size = new Size(222, 23);
            tbURLGame.TabIndex = 24;
            // 
            // lblURLGame
            // 
            lblURLGame.AutoSize = true;
            lblURLGame.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblURLGame.ForeColor = Color.White;
            lblURLGame.Location = new Point(478, 182);
            lblURLGame.Name = "lblURLGame";
            lblURLGame.Size = new Size(87, 21);
            lblURLGame.TabIndex = 23;
            lblURLGame.Text = "URL Game:";
            // 
            // tbURLPage
            // 
            tbURLPage.Location = new Point(572, 221);
            tbURLPage.Name = "tbURLPage";
            tbURLPage.Size = new Size(222, 23);
            tbURLPage.TabIndex = 26;
            // 
            // lblURLPage
            // 
            lblURLPage.AutoSize = true;
            lblURLPage.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblURLPage.ForeColor = Color.White;
            lblURLPage.Location = new Point(478, 222);
            lblURLPage.Name = "lblURLPage";
            lblURLPage.Size = new Size(79, 21);
            lblURLPage.TabIndex = 25;
            lblURLPage.Text = "URL Page:";
            // 
            // AddGame
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Screenshot_413;
            ClientSize = new Size(831, 634);
            Controls.Add(tbURLPage);
            Controls.Add(lblURLPage);
            Controls.Add(tbURLGame);
            Controls.Add(lblURLGame);
            Controls.Add(cbbConsole);
            Controls.Add(lblConsole);
            Controls.Add(tbName);
            Controls.Add(lblName);
            Controls.Add(btnAddGame);
            Controls.Add(cbbGenre);
            Controls.Add(tbRating);
            Controls.Add(tbDesc);
            Controls.Add(tbReleaseDate);
            Controls.Add(tbDeveloper);
            Controls.Add(lblAddGame);
            Controls.Add(lblDesc);
            Controls.Add(lblRating);
            Controls.Add(lblGenres);
            Controls.Add(lblReleaseDate);
            Controls.Add(lblDeveloper);
            Name = "AddGame";
            Text = "Add Game";
            Load += AddGame_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblDesc;
        private Label lblRating;
        private Label lblGenres;
        private Label lblReleaseDate;
        private Label lblDeveloper;
        private Label lblAddGame;
        private TextBox tbDeveloper;
        private TextBox tbReleaseDate;
        private TextBox tbDesc;
        private TextBox tbRating;
        private ComboBox cbbGenre;
        private Button btnAddGame;
        private TextBox tbName;
        private Label lblName;
        private ComboBox cbbConsole;
        private Label lblConsole;
        private TextBox tbURLGame;
        private Label lblURLGame;
        private TextBox tbURLPage;
        private Label lblURLPage;
    }
}