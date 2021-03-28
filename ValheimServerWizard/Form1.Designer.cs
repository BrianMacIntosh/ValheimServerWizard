namespace ValheimServerWizard
{
	partial class Form1
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
			this.components = new System.ComponentModel.Container();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.controlsGroupBox = new System.Windows.Forms.GroupBox();
			this.showPasswordCheckBox = new System.Windows.Forms.CheckBox();
			this.maxPortNumeric = new System.Windows.Forms.NumericUpDown();
			this.portHyphenLabel = new System.Windows.Forms.Label();
			this.publicLabel = new System.Windows.Forms.Label();
			this.restartButton = new System.Windows.Forms.Button();
			this.publicCheckBox = new System.Windows.Forms.CheckBox();
			this.passwordLabel = new System.Windows.Forms.Label();
			this.stopButton = new System.Windows.Forms.Button();
			this.passwordBox = new System.Windows.Forms.TextBox();
			this.portLabel = new System.Windows.Forms.Label();
			this.startServerButton = new System.Windows.Forms.Button();
			this.portNumeric = new System.Windows.Forms.NumericUpDown();
			this.serverNameLabel = new System.Windows.Forms.Label();
			this.serverNameTextBox = new System.Windows.Forms.TextBox();
			this.worldLabel = new System.Windows.Forms.Label();
			this.worldsListBox = new System.Windows.Forms.ListBox();
			this.playersGroupBox = new System.Windows.Forms.GroupBox();
			this.playerCountLabel = new System.Windows.Forms.Label();
			this.viewProfileButton = new System.Windows.Forms.Button();
			this.playersListBox = new System.Windows.Forms.ListBox();
			this.onlineLabel = new System.Windows.Forms.Label();
			this.logTextBox = new System.Windows.Forms.TextBox();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.adminListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.bannedListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.permittedListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1.SuspendLayout();
			this.controlsGroupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.maxPortNumeric)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.portNumeric)).BeginInit();
			this.playersGroupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(601, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// quitToolStripMenuItem
			// 
			this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
			this.quitToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
			this.quitToolStripMenuItem.Text = "Exit";
			this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
			// 
			// controlsGroupBox
			// 
			this.controlsGroupBox.Controls.Add(this.showPasswordCheckBox);
			this.controlsGroupBox.Controls.Add(this.maxPortNumeric);
			this.controlsGroupBox.Controls.Add(this.portHyphenLabel);
			this.controlsGroupBox.Controls.Add(this.publicLabel);
			this.controlsGroupBox.Controls.Add(this.restartButton);
			this.controlsGroupBox.Controls.Add(this.publicCheckBox);
			this.controlsGroupBox.Controls.Add(this.passwordLabel);
			this.controlsGroupBox.Controls.Add(this.stopButton);
			this.controlsGroupBox.Controls.Add(this.passwordBox);
			this.controlsGroupBox.Controls.Add(this.portLabel);
			this.controlsGroupBox.Controls.Add(this.startServerButton);
			this.controlsGroupBox.Controls.Add(this.portNumeric);
			this.controlsGroupBox.Controls.Add(this.serverNameLabel);
			this.controlsGroupBox.Controls.Add(this.serverNameTextBox);
			this.controlsGroupBox.Controls.Add(this.worldLabel);
			this.controlsGroupBox.Controls.Add(this.worldsListBox);
			this.controlsGroupBox.Location = new System.Drawing.Point(14, 55);
			this.controlsGroupBox.Name = "controlsGroupBox";
			this.controlsGroupBox.Size = new System.Drawing.Size(289, 317);
			this.controlsGroupBox.TabIndex = 1;
			this.controlsGroupBox.TabStop = false;
			this.controlsGroupBox.Text = "Server";
			// 
			// showPasswordCheckBox
			// 
			this.showPasswordCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
			this.showPasswordCheckBox.AutoSize = true;
			this.showPasswordCheckBox.Image = global::ValheimServerWizard.Properties.Resources.PasswordBarElement_10720;
			this.showPasswordCheckBox.Location = new System.Drawing.Point(255, 162);
			this.showPasswordCheckBox.Name = "showPasswordCheckBox";
			this.showPasswordCheckBox.Size = new System.Drawing.Size(22, 22);
			this.showPasswordCheckBox.TabIndex = 15;
			this.toolTip1.SetToolTip(this.showPasswordCheckBox, "Show Password");
			this.showPasswordCheckBox.UseVisualStyleBackColor = true;
			this.showPasswordCheckBox.CheckedChanged += new System.EventHandler(this.showPasswordCheckBox_CheckedChanged);
			// 
			// maxPortNumeric
			// 
			this.maxPortNumeric.Enabled = false;
			this.maxPortNumeric.Location = new System.Drawing.Point(194, 135);
			this.maxPortNumeric.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
			this.maxPortNumeric.Name = "maxPortNumeric";
			this.maxPortNumeric.Size = new System.Drawing.Size(83, 20);
			this.maxPortNumeric.TabIndex = 14;
			this.maxPortNumeric.Value = new decimal(new int[] {
            2457,
            0,
            0,
            0});
			// 
			// portHyphenLabel
			// 
			this.portHyphenLabel.AutoSize = true;
			this.portHyphenLabel.Location = new System.Drawing.Point(176, 138);
			this.portHyphenLabel.Name = "portHyphenLabel";
			this.portHyphenLabel.Size = new System.Drawing.Size(12, 13);
			this.portHyphenLabel.TabIndex = 13;
			this.portHyphenLabel.Text = "–";
			// 
			// publicLabel
			// 
			this.publicLabel.Location = new System.Drawing.Point(12, 186);
			this.publicLabel.Name = "publicLabel";
			this.publicLabel.Size = new System.Drawing.Size(69, 21);
			this.publicLabel.TabIndex = 12;
			this.publicLabel.Text = "Public";
			this.publicLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// restartButton
			// 
			this.restartButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.restartButton.Location = new System.Drawing.Point(15, 282);
			this.restartButton.Name = "restartButton";
			this.restartButton.Size = new System.Drawing.Size(268, 23);
			this.restartButton.TabIndex = 2;
			this.restartButton.Text = "Restart";
			this.restartButton.UseVisualStyleBackColor = true;
			this.restartButton.Click += new System.EventHandler(this.restartButton_Click);
			// 
			// publicCheckBox
			// 
			this.publicCheckBox.AutoSize = true;
			this.publicCheckBox.Location = new System.Drawing.Point(87, 190);
			this.publicCheckBox.Name = "publicCheckBox";
			this.publicCheckBox.Size = new System.Drawing.Size(15, 14);
			this.publicCheckBox.TabIndex = 11;
			this.publicCheckBox.UseVisualStyleBackColor = true;
			this.publicCheckBox.CheckedChanged += new System.EventHandler(this.publicCheckBox_CheckedChanged);
			// 
			// passwordLabel
			// 
			this.passwordLabel.Location = new System.Drawing.Point(12, 163);
			this.passwordLabel.Name = "passwordLabel";
			this.passwordLabel.Size = new System.Drawing.Size(70, 20);
			this.passwordLabel.TabIndex = 10;
			this.passwordLabel.Text = "Password";
			this.passwordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// stopButton
			// 
			this.stopButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.stopButton.Location = new System.Drawing.Point(15, 252);
			this.stopButton.Name = "stopButton";
			this.stopButton.Size = new System.Drawing.Size(268, 23);
			this.stopButton.TabIndex = 1;
			this.stopButton.Text = "Stop";
			this.stopButton.UseVisualStyleBackColor = true;
			this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
			// 
			// passwordBox
			// 
			this.passwordBox.Location = new System.Drawing.Point(87, 163);
			this.passwordBox.Name = "passwordBox";
			this.passwordBox.Size = new System.Drawing.Size(162, 20);
			this.passwordBox.TabIndex = 9;
			this.passwordBox.UseSystemPasswordChar = true;
			this.passwordBox.Leave += new System.EventHandler(this.passwordBox_Leave);
			// 
			// portLabel
			// 
			this.portLabel.Location = new System.Drawing.Point(6, 136);
			this.portLabel.Name = "portLabel";
			this.portLabel.Size = new System.Drawing.Size(76, 20);
			this.portLabel.TabIndex = 8;
			this.portLabel.Text = "Port";
			this.portLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// startServerButton
			// 
			this.startServerButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.startServerButton.Location = new System.Drawing.Point(15, 222);
			this.startServerButton.Name = "startServerButton";
			this.startServerButton.Size = new System.Drawing.Size(268, 23);
			this.startServerButton.TabIndex = 0;
			this.startServerButton.Text = "Start";
			this.startServerButton.UseVisualStyleBackColor = true;
			this.startServerButton.Click += new System.EventHandler(this.startServerButton_Click);
			// 
			// portNumeric
			// 
			this.portNumeric.Location = new System.Drawing.Point(87, 136);
			this.portNumeric.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
			this.portNumeric.Name = "portNumeric";
			this.portNumeric.Size = new System.Drawing.Size(83, 20);
			this.portNumeric.TabIndex = 7;
			this.portNumeric.Value = new decimal(new int[] {
            2456,
            0,
            0,
            0});
			this.portNumeric.ValueChanged += new System.EventHandler(this.portNumeric_ValueChanged);
			// 
			// serverNameLabel
			// 
			this.serverNameLabel.Location = new System.Drawing.Point(6, 109);
			this.serverNameLabel.Name = "serverNameLabel";
			this.serverNameLabel.Size = new System.Drawing.Size(76, 20);
			this.serverNameLabel.TabIndex = 6;
			this.serverNameLabel.Text = "Server Name";
			this.serverNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// serverNameTextBox
			// 
			this.serverNameTextBox.Location = new System.Drawing.Point(87, 109);
			this.serverNameTextBox.Name = "serverNameTextBox";
			this.serverNameTextBox.Size = new System.Drawing.Size(190, 20);
			this.serverNameTextBox.TabIndex = 5;
			this.serverNameTextBox.Leave += new System.EventHandler(this.serverNameTextBox_Leave);
			// 
			// worldLabel
			// 
			this.worldLabel.Location = new System.Drawing.Point(6, 20);
			this.worldLabel.Name = "worldLabel";
			this.worldLabel.Size = new System.Drawing.Size(76, 23);
			this.worldLabel.TabIndex = 4;
			this.worldLabel.Text = "World";
			this.worldLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// worldsListBox
			// 
			this.worldsListBox.FormattingEnabled = true;
			this.worldsListBox.Location = new System.Drawing.Point(87, 20);
			this.worldsListBox.Name = "worldsListBox";
			this.worldsListBox.Size = new System.Drawing.Size(190, 82);
			this.worldsListBox.TabIndex = 3;
			this.worldsListBox.SelectedIndexChanged += new System.EventHandler(this.worldsListBox_SelectedIndexChanged);
			// 
			// playersGroupBox
			// 
			this.playersGroupBox.Controls.Add(this.playerCountLabel);
			this.playersGroupBox.Controls.Add(this.viewProfileButton);
			this.playersGroupBox.Controls.Add(this.playersListBox);
			this.playersGroupBox.Location = new System.Drawing.Point(309, 55);
			this.playersGroupBox.Name = "playersGroupBox";
			this.playersGroupBox.Size = new System.Drawing.Size(277, 317);
			this.playersGroupBox.TabIndex = 2;
			this.playersGroupBox.TabStop = false;
			this.playersGroupBox.Text = "Connected Players";
			// 
			// playerCountLabel
			// 
			this.playerCountLabel.AutoSize = true;
			this.playerCountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.playerCountLabel.Location = new System.Drawing.Point(6, 16);
			this.playerCountLabel.Name = "playerCountLabel";
			this.playerCountLabel.Size = new System.Drawing.Size(40, 17);
			this.playerCountLabel.TabIndex = 2;
			this.playerCountLabel.Text = "0/10";
			// 
			// viewProfileButton
			// 
			this.viewProfileButton.Enabled = false;
			this.viewProfileButton.Location = new System.Drawing.Point(137, 36);
			this.viewProfileButton.Name = "viewProfileButton";
			this.viewProfileButton.Size = new System.Drawing.Size(134, 23);
			this.viewProfileButton.TabIndex = 1;
			this.viewProfileButton.Text = "Steam Profile";
			this.viewProfileButton.UseVisualStyleBackColor = true;
			this.viewProfileButton.Click += new System.EventHandler(this.viewProfileButtom_Click);
			// 
			// playersListBox
			// 
			this.playersListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.playersListBox.FormattingEnabled = true;
			this.playersListBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
			this.playersListBox.Location = new System.Drawing.Point(7, 36);
			this.playersListBox.Name = "playersListBox";
			this.playersListBox.Size = new System.Drawing.Size(124, 264);
			this.playersListBox.TabIndex = 0;
			this.playersListBox.SelectedIndexChanged += new System.EventHandler(this.playersListBox_SelectedIndexChanged);
			// 
			// onlineLabel
			// 
			this.onlineLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.onlineLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.onlineLabel.ForeColor = System.Drawing.Color.Red;
			this.onlineLabel.Location = new System.Drawing.Point(12, 24);
			this.onlineLabel.Name = "onlineLabel";
			this.onlineLabel.Size = new System.Drawing.Size(577, 28);
			this.onlineLabel.TabIndex = 0;
			this.onlineLabel.Text = "STOPPED";
			this.onlineLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// logTextBox
			// 
			this.logTextBox.Location = new System.Drawing.Point(13, 379);
			this.logTextBox.Multiline = true;
			this.logTextBox.Name = "logTextBox";
			this.logTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.logTextBox.Size = new System.Drawing.Size(573, 105);
			this.logTextBox.TabIndex = 3;
			// 
			// editToolStripMenuItem
			// 
			this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adminListToolStripMenuItem,
            this.bannedListToolStripMenuItem,
            this.permittedListToolStripMenuItem});
			this.editToolStripMenuItem.Name = "editToolStripMenuItem";
			this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
			this.editToolStripMenuItem.Text = "Edit";
			// 
			// adminListToolStripMenuItem
			// 
			this.adminListToolStripMenuItem.Name = "adminListToolStripMenuItem";
			this.adminListToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.adminListToolStripMenuItem.Text = "Admin List";
			this.adminListToolStripMenuItem.Click += new System.EventHandler(this.adminListToolStripMenuItem_Click);
			// 
			// bannedListToolStripMenuItem
			// 
			this.bannedListToolStripMenuItem.Name = "bannedListToolStripMenuItem";
			this.bannedListToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.bannedListToolStripMenuItem.Text = "Banned List";
			this.bannedListToolStripMenuItem.Click += new System.EventHandler(this.bannedListToolStripMenuItem_Click);
			// 
			// permittedListToolStripMenuItem
			// 
			this.permittedListToolStripMenuItem.Name = "permittedListToolStripMenuItem";
			this.permittedListToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.permittedListToolStripMenuItem.Text = "Permitted List";
			this.permittedListToolStripMenuItem.Click += new System.EventHandler(this.permittedListToolStripMenuItem_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(601, 496);
			this.Controls.Add(this.logTextBox);
			this.Controls.Add(this.onlineLabel);
			this.Controls.Add(this.playersGroupBox);
			this.Controls.Add(this.controlsGroupBox);
			this.Controls.Add(this.menuStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MainMenuStrip = this.menuStrip1;
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.Text = "Valheim Server Wizard";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.controlsGroupBox.ResumeLayout(false);
			this.controlsGroupBox.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.maxPortNumeric)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.portNumeric)).EndInit();
			this.playersGroupBox.ResumeLayout(false);
			this.playersGroupBox.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
		private System.Windows.Forms.GroupBox controlsGroupBox;
		private System.Windows.Forms.GroupBox playersGroupBox;
		private System.Windows.Forms.Label playerCountLabel;
		private System.Windows.Forms.Button viewProfileButton;
		private System.Windows.Forms.ListBox playersListBox;
		private System.Windows.Forms.Button restartButton;
		private System.Windows.Forms.Button stopButton;
		private System.Windows.Forms.Button startServerButton;
		private System.Windows.Forms.Label onlineLabel;
		private System.Windows.Forms.Label serverNameLabel;
		private System.Windows.Forms.TextBox serverNameTextBox;
		private System.Windows.Forms.Label worldLabel;
		private System.Windows.Forms.ListBox worldsListBox;
		private System.Windows.Forms.Label publicLabel;
		private System.Windows.Forms.CheckBox publicCheckBox;
		private System.Windows.Forms.Label passwordLabel;
		private System.Windows.Forms.TextBox passwordBox;
		private System.Windows.Forms.Label portLabel;
		private System.Windows.Forms.NumericUpDown portNumeric;
		private System.Windows.Forms.TextBox logTextBox;
		private System.Windows.Forms.NumericUpDown maxPortNumeric;
		private System.Windows.Forms.Label portHyphenLabel;
		private System.Windows.Forms.CheckBox showPasswordCheckBox;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem adminListToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem bannedListToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem permittedListToolStripMenuItem;
	}
}

