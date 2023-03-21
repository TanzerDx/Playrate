namespace Desktop_App___Hristo_Ganchev
{
	partial class AddConsole
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
			tbManufacturer = new TextBox();
			lblManufacturer = new Label();
			tbModel = new TextBox();
			tbReleaseDate = new TextBox();
			lblAddConsole = new Label();
			lblModel = new Label();
			lblType = new Label();
			lblReleaseDate = new Label();
			btnAddConsole = new Button();
			tbControllerType = new TextBox();
			lblControllerType = new Label();
			tbChatPlatform = new TextBox();
			lblChatPlatform = new Label();
			cbbType = new ComboBox();
			SuspendLayout();
			// 
			// tbManufacturer
			// 
			tbManufacturer.Location = new Point(154, 191);
			tbManufacturer.Name = "tbManufacturer";
			tbManufacturer.Size = new Size(222, 23);
			tbManufacturer.TabIndex = 31;
			// 
			// lblManufacturer
			// 
			lblManufacturer.AutoSize = true;
			lblManufacturer.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
			lblManufacturer.ForeColor = Color.White;
			lblManufacturer.Location = new Point(25, 191);
			lblManufacturer.Name = "lblManufacturer";
			lblManufacturer.Size = new Size(107, 21);
			lblManufacturer.TabIndex = 30;
			lblManufacturer.Text = "Manufacturer:";
			// 
			// tbModel
			// 
			tbModel.Location = new Point(104, 137);
			tbModel.Name = "tbModel";
			tbModel.Size = new Size(222, 23);
			tbModel.TabIndex = 28;
			tbModel.TextChanged += tbModel_TextChanged;
			// 
			// tbReleaseDate
			// 
			tbReleaseDate.Location = new Point(144, 242);
			tbReleaseDate.Name = "tbReleaseDate";
			tbReleaseDate.Size = new Size(222, 23);
			tbReleaseDate.TabIndex = 27;
			// 
			// lblAddConsole
			// 
			lblAddConsole.AutoSize = true;
			lblAddConsole.Font = new Font("Segoe UI Black", 26.25F, FontStyle.Bold, GraphicsUnit.Point);
			lblAddConsole.ForeColor = Color.White;
			lblAddConsole.Location = new Point(12, 9);
			lblAddConsole.Name = "lblAddConsole";
			lblAddConsole.Size = new Size(272, 47);
			lblAddConsole.TabIndex = 25;
			lblAddConsole.Text = "ADD CONSOLE";
			// 
			// lblModel
			// 
			lblModel.AutoSize = true;
			lblModel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
			lblModel.ForeColor = Color.White;
			lblModel.Location = new Point(25, 140);
			lblModel.Name = "lblModel";
			lblModel.Size = new Size(57, 21);
			lblModel.TabIndex = 24;
			lblModel.Text = "Model:";
			// 
			// lblType
			// 
			lblType.AutoSize = true;
			lblType.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
			lblType.ForeColor = Color.White;
			lblType.Location = new Point(25, 89);
			lblType.Name = "lblType";
			lblType.Size = new Size(45, 21);
			lblType.TabIndex = 23;
			lblType.Text = "Type:";
			// 
			// lblReleaseDate
			// 
			lblReleaseDate.AutoSize = true;
			lblReleaseDate.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
			lblReleaseDate.ForeColor = Color.White;
			lblReleaseDate.Location = new Point(25, 242);
			lblReleaseDate.Name = "lblReleaseDate";
			lblReleaseDate.Size = new Size(102, 21);
			lblReleaseDate.TabIndex = 22;
			lblReleaseDate.Text = "Release Date:";
			// 
			// btnAddConsole
			// 
			btnAddConsole.Location = new Point(25, 399);
			btnAddConsole.Name = "btnAddConsole";
			btnAddConsole.Size = new Size(290, 40);
			btnAddConsole.TabIndex = 32;
			btnAddConsole.Text = "Add Console";
			btnAddConsole.UseVisualStyleBackColor = true;
			btnAddConsole.Click += btnAddConsole_Click;
			// 
			// tbControllerType
			// 
			tbControllerType.Location = new Point(160, 291);
			tbControllerType.Name = "tbControllerType";
			tbControllerType.Size = new Size(222, 23);
			tbControllerType.TabIndex = 38;
			// 
			// lblControllerType
			// 
			lblControllerType.AutoSize = true;
			lblControllerType.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
			lblControllerType.ForeColor = Color.White;
			lblControllerType.Location = new Point(25, 293);
			lblControllerType.Name = "lblControllerType";
			lblControllerType.Size = new Size(119, 21);
			lblControllerType.TabIndex = 37;
			lblControllerType.Text = "Controller Type:";
			// 
			// tbChatPlatform
			// 
			tbChatPlatform.Location = new Point(155, 342);
			tbChatPlatform.Name = "tbChatPlatform";
			tbChatPlatform.Size = new Size(222, 23);
			tbChatPlatform.TabIndex = 35;
			// 
			// lblChatPlatform
			// 
			lblChatPlatform.AutoSize = true;
			lblChatPlatform.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
			lblChatPlatform.ForeColor = Color.White;
			lblChatPlatform.Location = new Point(25, 344);
			lblChatPlatform.Name = "lblChatPlatform";
			lblChatPlatform.Size = new Size(109, 21);
			lblChatPlatform.TabIndex = 33;
			lblChatPlatform.Text = "Chat Platform:";
			// 
			// cbbType
			// 
			cbbType.FormattingEnabled = true;
			cbbType.Items.AddRange(new object[] { "Playstation", "Xbox" });
			cbbType.Location = new Point(94, 89);
			cbbType.Name = "cbbType";
			cbbType.Size = new Size(209, 23);
			cbbType.TabIndex = 39;
			cbbType.SelectedIndexChanged += cbbType_SelectedIndexChanged;
			// 
			// AddConsole
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.Blue;
			BackgroundImage = Properties.Resources.Screenshot_413;
			ClientSize = new Size(469, 452);
			Controls.Add(cbbType);
			Controls.Add(tbControllerType);
			Controls.Add(lblControllerType);
			Controls.Add(tbChatPlatform);
			Controls.Add(lblChatPlatform);
			Controls.Add(btnAddConsole);
			Controls.Add(tbManufacturer);
			Controls.Add(lblManufacturer);
			Controls.Add(tbModel);
			Controls.Add(tbReleaseDate);
			Controls.Add(lblAddConsole);
			Controls.Add(lblModel);
			Controls.Add(lblType);
			Controls.Add(lblReleaseDate);
			Name = "AddConsole";
			Text = "AddConsole";
			Load += AddConsole_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private TextBox tbManufacturer;
		private Label lblManufacturer;
		private ComboBox cbbGenre;
		private TextBox tbModel;
		private TextBox tbReleaseDate;
		private Label lblAddConsole;
		private Label lblModel;
		private Label lblType;
		private Label lblReleaseDate;
		private Button btnAddConsole;
		private TextBox tbControllerType;
		private Label lblControllerType;
		private TextBox tbVoiceChat;
		private TextBox tbChatPlatform;
		private Label label2;
		private Label lblChatPlatform;
		private ComboBox cbbType;
	}
}