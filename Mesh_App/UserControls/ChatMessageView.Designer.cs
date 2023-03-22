namespace Mesh_App.UserControls
{
    partial class ChatMessageView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            splitContainer1 = new SplitContainer();
            labTypingNotification = new Label();
            customListView1 = new CustomListView();
            txtMessage = new TextBox();
            btnShareFile = new Button();
            btnSend = new Button();
            timerTypingNotification = new System.Windows.Forms.Timer(components);
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(223, 223, 224);
            panel2.Controls.Add(splitContainer1);
            panel2.Margin = new Padding(5, 3, 5, 3);
            panel2.Size = new Size(750, 410);
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.FixedPanel = FixedPanel.Panel2;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Margin = new Padding(4, 3, 4, 3);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.BackColor = Color.FromArgb(224, 224, 224);
            splitContainer1.Panel1.Controls.Add(labTypingNotification);
            splitContainer1.Panel1.Controls.Add(customListView1);
            splitContainer1.Panel1MinSize = 100;
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackColor = Color.FromArgb(224, 224, 224);
            splitContainer1.Panel2.Controls.Add(txtMessage);
            splitContainer1.Panel2.Controls.Add(btnShareFile);
            splitContainer1.Panel2.Controls.Add(btnSend);
            splitContainer1.Panel2MinSize = 52;
            splitContainer1.Size = new Size(750, 410);
            splitContainer1.SplitterDistance = 344;
            splitContainer1.SplitterWidth = 2;
            splitContainer1.TabIndex = 3;
            splitContainer1.SplitterMoved += splitContainer1_SplitterMoved;
            // 
            // labTypingNotification
            // 
            labTypingNotification.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labTypingNotification.AutoEllipsis = true;
            labTypingNotification.BackColor = Color.Transparent;
            labTypingNotification.Font = new Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point);
            labTypingNotification.ForeColor = Color.FromArgb(64, 64, 64);
            labTypingNotification.Location = new Point(0, 326);
            labTypingNotification.Margin = new Padding(4, 0, 4, 0);
            labTypingNotification.Name = "labTypingNotification";
            labTypingNotification.Size = new Size(750, 17);
            labTypingNotification.TabIndex = 1;
            // 
            // customListView1
            // 
            customListView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            customListView1.AutoScroll = true;
            customListView1.AutoScrollToBottom = false;
            customListView1.BackColor = Color.Transparent;
            customListView1.BorderColor = Color.Empty;
            customListView1.Location = new Point(0, 0);
            customListView1.Margin = new Padding(5, 3, 5, 3);
            customListView1.Name = "customListView1";
            customListView1.SeparatorColor = Color.Empty;
            customListView1.Size = new Size(750, 326);
            customListView1.SortItems = false;
            customListView1.TabIndex = 0;
            customListView1.ScrolledNearStart += customListView1_ScrolledNearStart;
            // 
            // txtMessage
            // 
            txtMessage.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtMessage.BorderStyle = BorderStyle.None;
            txtMessage.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtMessage.HideSelection = false;
            txtMessage.Location = new Point(4, 3);
            txtMessage.Margin = new Padding(4, 3, 4, 3);
            txtMessage.Multiline = true;
            txtMessage.Name = "txtMessage";
            txtMessage.ScrollBars = ScrollBars.Vertical;
            txtMessage.Size = new Size(645, 55);
            txtMessage.TabIndex = 0;
            txtMessage.KeyDown += txtMessage_KeyDown;
            txtMessage.KeyPress += txtMessage_KeyPress;
            // 
            // btnShareFile
            // 
            btnShareFile.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnShareFile.BackColor = Color.Transparent;
            btnShareFile.Font = new Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point);
            btnShareFile.ForeColor = SystemColors.ControlText;
            btnShareFile.Image = Properties.Resources.Attachment;
            btnShareFile.Location = new Point(678, 30);
            btnShareFile.Margin = new Padding(4, 3, 4, 3);
            btnShareFile.Name = "btnShareFile";
            btnShareFile.Size = new Size(70, 28);
            btnShareFile.TabIndex = 2;
            btnShareFile.Text = "Share";
            btnShareFile.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnShareFile.UseVisualStyleBackColor = false;
            btnShareFile.Click += btnShareFile_Click;
            // 
            // btnSend
            // 
            btnSend.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSend.BackColor = Color.Transparent;
            btnSend.Font = new Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point);
            btnSend.ForeColor = SystemColors.ControlText;
            btnSend.Image = Properties.Resources.send_message;
            btnSend.Location = new Point(678, 2);
            btnSend.Margin = new Padding(4, 3, 4, 3);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(70, 28);
            btnSend.TabIndex = 1;
            btnSend.Text = "Send";
            btnSend.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSend.UseVisualStyleBackColor = false;
            btnSend.Click += btnSend_Click;
            // 
            // timerTypingNotification
            // 
            timerTypingNotification.Interval = 10000;
            timerTypingNotification.Tick += timerTypingNotification_Tick;
            // 
            // ChatMessageView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Margin = new Padding(5, 3, 5, 3);
            Name = "ChatMessageView";
            Size = new Size(753, 443);
            Title = "Chat Title";
            panel2.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnShareFile;
        private CustomListView customListView1;
        private System.Windows.Forms.Label labTypingNotification;
        private System.Windows.Forms.Timer timerTypingNotification;
    }
}
