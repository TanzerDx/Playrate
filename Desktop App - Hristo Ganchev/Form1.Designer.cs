﻿namespace Desktop_App___Hristo_Ganchev
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
            lblDeveloper = new Label();
            lblReleaseDate = new Label();
            lblRating = new Label();
            lblGenres = new Label();
            lblDesc = new Label();
            btnAddGame = new Button();
            lbAllGames = new ListBox();
            btnShowAll = new Button();
            btnDeleteGame = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
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
            // lblDeveloper
            // 
            lblDeveloper.AutoSize = true;
            lblDeveloper.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblDeveloper.ForeColor = Color.White;
            lblDeveloper.Location = new Point(12, 69);
            lblDeveloper.Name = "lblDeveloper";
            lblDeveloper.Size = new Size(84, 21);
            lblDeveloper.TabIndex = 1;
            lblDeveloper.Text = "Developer:";
            // 
            // lblReleaseDate
            // 
            lblReleaseDate.AutoSize = true;
            lblReleaseDate.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblReleaseDate.ForeColor = Color.White;
            lblReleaseDate.Location = new Point(12, 120);
            lblReleaseDate.Name = "lblReleaseDate";
            lblReleaseDate.Size = new Size(102, 21);
            lblReleaseDate.TabIndex = 2;
            lblReleaseDate.Text = "Release Date:";
            // 
            // lblRating
            // 
            lblRating.AutoSize = true;
            lblRating.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblRating.ForeColor = Color.White;
            lblRating.Location = new Point(12, 222);
            lblRating.Name = "lblRating";
            lblRating.Size = new Size(58, 21);
            lblRating.TabIndex = 4;
            lblRating.Text = "Rating:";
            // 
            // lblGenres
            // 
            lblGenres.AutoSize = true;
            lblGenres.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblGenres.ForeColor = Color.White;
            lblGenres.Location = new Point(12, 171);
            lblGenres.Name = "lblGenres";
            lblGenres.Size = new Size(62, 21);
            lblGenres.TabIndex = 3;
            lblGenres.Text = "Genres:";
            // 
            // lblDesc
            // 
            lblDesc.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblDesc.ForeColor = Color.White;
            lblDesc.Location = new Point(12, 273);
            lblDesc.Name = "lblDesc";
            lblDesc.Size = new Size(776, 298);
            lblDesc.TabIndex = 5;
            lblDesc.Text = "Description:";
            // 
            // btnAddGame
            // 
            btnAddGame.Location = new Point(334, 24);
            btnAddGame.Name = "btnAddGame";
            btnAddGame.Size = new Size(215, 28);
            btnAddGame.TabIndex = 6;
            btnAddGame.Text = "Add Game";
            btnAddGame.UseVisualStyleBackColor = true;
            btnAddGame.Click += btnAddGame_Click;
            // 
            // lbAllGames
            // 
            lbAllGames.FormattingEnabled = true;
            lbAllGames.ItemHeight = 15;
            lbAllGames.Location = new Point(334, 93);
            lbAllGames.Name = "lbAllGames";
            lbAllGames.Size = new Size(454, 169);
            lbAllGames.TabIndex = 7;
            lbAllGames.SelectedIndexChanged += lbAllGames_SelectedIndexChanged;
            // 
            // btnShowAll
            // 
            btnShowAll.Location = new Point(334, 56);
            btnShowAll.Name = "btnShowAll";
            btnShowAll.Size = new Size(454, 31);
            btnShowAll.TabIndex = 8;
            btnShowAll.Text = "Show all";
            btnShowAll.UseVisualStyleBackColor = true;
            btnShowAll.Click += btnShowAll_Click;
            // 
            // btnDeleteGame
            // 
            btnDeleteGame.Location = new Point(573, 24);
            btnDeleteGame.Name = "btnDeleteGame";
            btnDeleteGame.Size = new Size(215, 28);
            btnDeleteGame.TabIndex = 9;
            btnDeleteGame.Text = "Delete Game";
            btnDeleteGame.UseVisualStyleBackColor = true;
            btnDeleteGame.Click += btnDeleteGame_Click;
            // 
            // HomePage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Screenshot_413;
            ClientSize = new Size(800, 589);
            Controls.Add(btnDeleteGame);
            Controls.Add(btnShowAll);
            Controls.Add(lbAllGames);
            Controls.Add(btnAddGame);
            Controls.Add(lblDesc);
            Controls.Add(lblRating);
            Controls.Add(lblGenres);
            Controls.Add(lblReleaseDate);
            Controls.Add(lblDeveloper);
            Controls.Add(pictureBox1);
            Name = "HomePage";
            Text = "Home Page";
            Load += HomePage_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label lblDeveloper;
        private Label lblReleaseDate;
        private Label lblRating;
        private Label lblGenres;
        private Label lblDesc;
        private Button btnAddGame;
        private ListBox lbAllGames;
        private Button btnShowAll;
        private Button btnDeleteGame;
    }
}