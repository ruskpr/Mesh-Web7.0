namespace Mesh_App
{
    partial class frmProfileManager
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProfileManager));
            label2 = new Label();
            cmbProfiles = new ComboBox();
            label3 = new Label();
            txtPassword = new TextBox();
            btnStart = new Button();
            btnCreateProfile = new Button();
            btnDelete = new Button();
            btnImport = new Button();
            btnExport = new Button();
            btnClose = new Button();
            label4 = new Label();
            label5 = new Label();
            mnuSystemTray = new ContextMenuStrip(components);
            mnuProfileManager = new ToolStripMenuItem();
            mnuSeparator = new ToolStripSeparator();
            toolStripSeparator3 = new ToolStripSeparator();
            mnuCheckUpdate = new ToolStripMenuItem();
            mnuAbout = new ToolStripMenuItem();
            toolStripSeparator5 = new ToolStripSeparator();
            mnuExit = new ToolStripMenuItem();
            iconSystemTray = new NotifyIcon(components);
            label1 = new Label();
            mnuSystemTray.SuspendLayout();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(68, 207);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(36, 13);
            label2.TabIndex = 1;
            label2.Text = "Profile";
            // 
            // cmbProfiles
            // 
            cmbProfiles.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProfiles.FormattingEnabled = true;
            cmbProfiles.Location = new Point(117, 203);
            cmbProfiles.Margin = new Padding(4, 3, 4, 3);
            cmbProfiles.Name = "cmbProfiles";
            cmbProfiles.Size = new Size(233, 23);
            cmbProfiles.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(48, 238);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(57, 15);
            label3.TabIndex = 3;
            label3.Text = "Password";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(117, 234);
            txtPassword.Margin = new Padding(4, 3, 4, 3);
            txtPassword.MaxLength = 255;
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '#';
            txtPassword.Size = new Size(233, 23);
            txtPassword.TabIndex = 1;
            txtPassword.Text = "password";
            // 
            // btnStart
            // 
            btnStart.Location = new Point(117, 264);
            btnStart.Margin = new Padding(4, 3, 4, 3);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(88, 27);
            btnStart.TabIndex = 2;
            btnStart.Text = "&Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // btnCreateProfile
            // 
            btnCreateProfile.Location = new Point(187, 381);
            btnCreateProfile.Margin = new Padding(4, 3, 4, 3);
            btnCreateProfile.Name = "btnCreateProfile";
            btnCreateProfile.Size = new Size(93, 27);
            btnCreateProfile.TabIndex = 4;
            btnCreateProfile.Text = "Create &Profile";
            btnCreateProfile.UseVisualStyleBackColor = true;
            btnCreateProfile.Click += btnCreateProfile_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(262, 264);
            btnDelete.Margin = new Padding(4, 3, 4, 3);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(88, 27);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "&Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnImport
            // 
            btnImport.Location = new Point(14, 492);
            btnImport.Margin = new Padding(4, 3, 4, 3);
            btnImport.Name = "btnImport";
            btnImport.Size = new Size(88, 27);
            btnImport.TabIndex = 5;
            btnImport.Text = "&Import";
            btnImport.UseVisualStyleBackColor = true;
            btnImport.Click += btnImport_Click;
            // 
            // btnExport
            // 
            btnExport.Location = new Point(108, 492);
            btnExport.Margin = new Padding(4, 3, 4, 3);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(88, 27);
            btnExport.TabIndex = 6;
            btnExport.Text = "&Export";
            btnExport.UseVisualStyleBackColor = true;
            btnExport.Click += btnExport_Click;
            // 
            // btnClose
            // 
            btnClose.DialogResult = DialogResult.Cancel;
            btnClose.Location = new Point(346, 492);
            btnClose.Margin = new Padding(4, 3, 4, 3);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(88, 27);
            btnClose.TabIndex = 7;
            btnClose.Text = "&Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // label4
            // 
            label4.Font = new Font("Arial", 36F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = Color.FromArgb(45, 57, 69);
            label4.Location = new Point(14, 39);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(420, 62);
            label4.TabIndex = 11;
            label4.Text = "Mesh";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = Color.FromArgb(45, 57, 69);
            label5.Location = new Point(117, 345);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(233, 28);
            label5.TabIndex = 12;
            label5.Text = "Create a new profile?";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // mnuSystemTray
            // 
            mnuSystemTray.Items.AddRange(new ToolStripItem[] { mnuProfileManager, mnuSeparator, toolStripSeparator3, mnuCheckUpdate, mnuAbout, toolStripSeparator5, mnuExit });
            mnuSystemTray.Name = "systrayMenu";
            mnuSystemTray.Size = new Size(169, 110);
            mnuSystemTray.Opening += mnuSystemTray_Opening;
            // 
            // mnuProfileManager
            // 
            mnuProfileManager.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            mnuProfileManager.Name = "mnuProfileManager";
            mnuProfileManager.Size = new Size(168, 22);
            mnuProfileManager.Text = "Profile Manager";
            mnuProfileManager.Click += mnuProfileManager_Click;
            // 
            // mnuSeparator
            // 
            mnuSeparator.Name = "mnuSeparator";
            mnuSeparator.Size = new Size(165, 6);
            mnuSeparator.Visible = false;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(165, 6);
            // 
            // mnuCheckUpdate
            // 
            mnuCheckUpdate.Name = "mnuCheckUpdate";
            mnuCheckUpdate.Size = new Size(168, 22);
            mnuCheckUpdate.Text = "Check For &Update";
            mnuCheckUpdate.Click += mnuCheckUpdate_Click;
            // 
            // mnuAbout
            // 
            mnuAbout.Image = Properties.Resources.logo2;
            mnuAbout.Name = "mnuAbout";
            mnuAbout.Size = new Size(168, 22);
            mnuAbout.Text = "&About Mesh";
            mnuAbout.Click += mnuAbout_Click;
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new Size(165, 6);
            // 
            // mnuExit
            // 
            mnuExit.Name = "mnuExit";
            mnuExit.Size = new Size(168, 22);
            mnuExit.Text = "E&xit";
            mnuExit.Click += mnuExit_Click;
            // 
            // iconSystemTray
            // 
            iconSystemTray.ContextMenuStrip = mnuSystemTray;
            iconSystemTray.Icon = (Icon)resources.GetObject("iconSystemTray.Icon");
            iconSystemTray.Text = "Technitium Mesh";
            iconSystemTray.Visible = true;
            iconSystemTray.BalloonTipClicked += iconSystemTray_BalloonTipClicked;
            iconSystemTray.DoubleClick += mnuProfileManager_Click;
            // 
            // label1
            // 
            label1.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.FromArgb(45, 57, 69);
            label1.Location = new Point(14, 102);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(420, 65);
            label1.TabIndex = 13;
            label1.Text = "A secure, anonymous, peer-to-peer, instant messenger with end-to-end encryption!";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // frmProfileManager
            // 
            AcceptButton = btnStart;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(250, 250, 250);
            CancelButton = btnClose;
            ClientSize = new Size(448, 532);
            Controls.Add(label1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(btnClose);
            Controls.Add(btnExport);
            Controls.Add(btnImport);
            Controls.Add(btnDelete);
            Controls.Add(btnCreateProfile);
            Controls.Add(btnStart);
            Controls.Add(txtPassword);
            Controls.Add(label3);
            Controls.Add(cmbProfiles);
            Controls.Add(label2);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmProfileManager";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Mesh";
            Activated += frmProfileManager_Activated;
            FormClosing += frmProfileManager_FormClosing;
            FormClosed += frmProfileManager_FormClosed;
            Shown += frmProfileManager_Shown;
            mnuSystemTray.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbProfiles;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnCreateProfile;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ContextMenuStrip mnuSystemTray;
        private System.Windows.Forms.ToolStripMenuItem mnuProfileManager;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem mnuAbout;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.NotifyIcon iconSystemTray;
        private System.Windows.Forms.ToolStripSeparator mnuSeparator;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem mnuCheckUpdate;
    }
}