namespace Mesh_App
{
    partial class frmCreateProfile_DID
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCreateProfile_DID));
            label2 = new Label();
            label1 = new Label();
            txtProfileDisplayName = new TextBox();
            chkCreateNewDIDKey = new CheckBox();
            label14 = new Label();
            txtConfirmPassword = new TextBox();
            label13 = new Label();
            txtProfilePassword = new TextBox();
            label12 = new Label();
            label15 = new Label();
            btnCreate = new Button();
            label3 = new Label();
            label4 = new Label();
            btnBack = new Button();
            txtDidKey = new TextBox();
            btnImportKey = new Button();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.FromArgb(45, 57, 69);
            label2.Location = new Point(13, 10);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(166, 22);
            label2.TabIndex = 9;
            label2.Text = "Create a DID Key";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(69, 133);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 10;
            label1.Text = "Name";
            // 
            // txtProfileDisplayName
            // 
            txtProfileDisplayName.Location = new Point(117, 129);
            txtProfileDisplayName.Margin = new Padding(4, 3, 4, 3);
            txtProfileDisplayName.MaxLength = 255;
            txtProfileDisplayName.Name = "txtProfileDisplayName";
            txtProfileDisplayName.PlaceholderText = "John Smith";
            txtProfileDisplayName.Size = new Size(233, 23);
            txtProfileDisplayName.TabIndex = 11;
            // 
            // chkCreateNewDIDKey
            // 
            chkCreateNewDIDKey.AutoSize = true;
            chkCreateNewDIDKey.ForeColor = Color.FromArgb(32, 32, 32);
            chkCreateNewDIDKey.Location = new Point(117, 215);
            chkCreateNewDIDKey.Margin = new Padding(4, 3, 4, 3);
            chkCreateNewDIDKey.Name = "chkCreateNewDIDKey";
            chkCreateNewDIDKey.Size = new Size(129, 19);
            chkCreateNewDIDKey.TabIndex = 43;
            chkCreateNewDIDKey.Text = "Create new DID Key";
            chkCreateNewDIDKey.UseVisualStyleBackColor = true;
            chkCreateNewDIDKey.CheckedChanged += chkEnableProxy_CheckedChanged;
            // 
            // label14
            // 
            label14.ForeColor = Color.FromArgb(32, 32, 32);
            label14.Location = new Point(14, 303);
            label14.Margin = new Padding(4, 0, 4, 0);
            label14.Name = "label14";
            label14.Size = new Size(420, 38);
            label14.TabIndex = 45;
            label14.Text = "To protect from unauthorized access to your profile, enter a strong encryption password below to stored your profile securely on this computer.";
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Location = new Point(128, 377);
            txtConfirmPassword.Margin = new Padding(4, 3, 4, 3);
            txtConfirmPassword.MaxLength = 255;
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.PasswordChar = '#';
            txtConfirmPassword.Size = new Size(209, 23);
            txtConfirmPassword.TabIndex = 46;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.ForeColor = Color.FromArgb(32, 32, 32);
            label13.Location = new Point(16, 381);
            label13.Margin = new Padding(4, 0, 4, 0);
            label13.Name = "label13";
            label13.Size = new Size(104, 15);
            label13.TabIndex = 42;
            label13.Text = "Confirm password";
            // 
            // txtProfilePassword
            // 
            txtProfilePassword.Location = new Point(128, 347);
            txtProfilePassword.Margin = new Padding(4, 3, 4, 3);
            txtProfilePassword.MaxLength = 255;
            txtProfilePassword.Name = "txtProfilePassword";
            txtProfilePassword.PasswordChar = '#';
            txtProfilePassword.Size = new Size(209, 23);
            txtProfilePassword.TabIndex = 44;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.ForeColor = Color.FromArgb(32, 32, 32);
            label12.Location = new Point(23, 351);
            label12.Margin = new Padding(4, 0, 4, 0);
            label12.Name = "label12";
            label12.Size = new Size(94, 15);
            label12.TabIndex = 39;
            label12.Text = "Profile password";
            // 
            // label15
            // 
            label15.ForeColor = Color.FromArgb(32, 32, 32);
            label15.Location = new Point(14, 415);
            label15.Margin = new Padding(4, 0, 4, 0);
            label15.Name = "label15";
            label15.Size = new Size(420, 73);
            label15.TabIndex = 47;
            label15.Text = resources.GetString("label15.Text");
            // 
            // btnCreate
            // 
            btnCreate.Location = new Point(252, 492);
            btnCreate.Margin = new Padding(4, 3, 4, 3);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(88, 27);
            btnCreate.TabIndex = 48;
            btnCreate.Text = "&Create";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += btnStart_Click;
            // 
            // label3
            // 
            label3.ForeColor = Color.FromArgb(32, 32, 32);
            label3.Location = new Point(14, 44);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(420, 77);
            label3.TabIndex = 50;
            label3.Text = resources.GetString("label3.Text");
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(65, 164);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(48, 15);
            label4.TabIndex = 51;
            label4.Text = "DID Key";
            // 
            // btnBack
            // 
            btnBack.DialogResult = DialogResult.Cancel;
            btnBack.Location = new Point(346, 492);
            btnBack.Margin = new Padding(4, 3, 4, 3);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(88, 27);
            btnBack.TabIndex = 52;
            btnBack.Text = "&Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // txtDidKey
            // 
            txtDidKey.Location = new Point(117, 160);
            txtDidKey.Margin = new Padding(4, 3, 4, 3);
            txtDidKey.MaxLength = 255;
            txtDidKey.Name = "txtDidKey";
            txtDidKey.Size = new Size(233, 23);
            txtDidKey.TabIndex = 11;
            // 
            // btnImportKey
            // 
            btnImportKey.Location = new Point(117, 186);
            btnImportKey.Name = "btnImportKey";
            btnImportKey.Size = new Size(118, 23);
            btnImportKey.TabIndex = 53;
            btnImportKey.Text = "Import DID profile";
            btnImportKey.UseVisualStyleBackColor = true;
            btnImportKey.Click += btnImportKey_Click;
            // 
            // frmCreateProfile_DID
            // 
            AcceptButton = btnCreate;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(250, 250, 250);
            CancelButton = btnBack;
            ClientSize = new Size(448, 532);
            Controls.Add(btnImportKey);
            Controls.Add(btnBack);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(btnCreate);
            Controls.Add(label15);
            Controls.Add(chkCreateNewDIDKey);
            Controls.Add(label14);
            Controls.Add(txtConfirmPassword);
            Controls.Add(label13);
            Controls.Add(txtProfilePassword);
            Controls.Add(label12);
            Controls.Add(txtDidKey);
            Controls.Add(txtProfileDisplayName);
            Controls.Add(label1);
            Controls.Add(label2);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmCreateProfile_DID";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Mesh";
            FormClosing += frmCreateProfile_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtProfileDisplayName;
        private System.Windows.Forms.CheckBox chkCreateNewDIDKey;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtProfilePassword;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnBack;
        private TextBox txtDidKey;
        private Button btnImportKey;
    }
}