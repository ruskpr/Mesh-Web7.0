namespace Mesh_App.UserControls
{
    partial class ChatMessageTextItem
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
            lblUsername = new Label();
            contextMenuStrip1 = new ContextMenuStrip(components);
            mnuCopyMessage = new ToolStripMenuItem();
            mnuForwardTo = new ToolStripMenuItem();
            mnuMessageInfo = new ToolStripMenuItem();
            lblMessage = new Label();
            lblDateTime = new Label();
            pnlBubble = new Panel();
            picDeliveryStatus = new PictureBox();
            picPointLeft = new PictureBox();
            picPointRight = new PictureBox();
            toolTip1 = new ToolTip(components);
            timer1 = new System.Windows.Forms.Timer(components);
            contextMenuStrip1.SuspendLayout();
            pnlBubble.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picDeliveryStatus).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picPointLeft).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picPointRight).BeginInit();
            SuspendLayout();
            // 
            // lblUsername
            // 
            lblUsername.AutoEllipsis = true;
            lblUsername.AutoSize = true;
            lblUsername.Cursor = Cursors.Hand;
            lblUsername.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblUsername.ForeColor = Color.FromArgb(51, 65, 78);
            lblUsername.Location = new Point(6, 3);
            lblUsername.Margin = new Padding(4, 0, 4, 0);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(66, 15);
            lblUsername.TabIndex = 0;
            lblUsername.Text = "Username";
            lblUsername.TextAlign = ContentAlignment.TopRight;
            lblUsername.Click += lblUsername_Click;
            lblUsername.MouseEnter += lblUsername_MouseEnter;
            lblUsername.MouseLeave += lblUsername_MouseLeave;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { mnuCopyMessage, mnuForwardTo, mnuMessageInfo });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(152, 70);
            // 
            // mnuCopyMessage
            // 
            mnuCopyMessage.Name = "mnuCopyMessage";
            mnuCopyMessage.Size = new Size(151, 22);
            mnuCopyMessage.Text = "&Copy Message";
            mnuCopyMessage.Click += mnuCopyMessage_Click;
            // 
            // mnuForwardTo
            // 
            mnuForwardTo.Name = "mnuForwardTo";
            mnuForwardTo.Size = new Size(151, 22);
            mnuForwardTo.Text = "Forward To";
            mnuForwardTo.Click += mnuForwardTo_Click;
            // 
            // mnuMessageInfo
            // 
            mnuMessageInfo.Name = "mnuMessageInfo";
            mnuMessageInfo.Size = new Size(151, 22);
            mnuMessageInfo.Text = "Message &Info";
            mnuMessageInfo.Visible = false;
            mnuMessageInfo.Click += mnuMessageInfo_Click;
            // 
            // lblMessage
            // 
            lblMessage.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblMessage.BackColor = Color.Transparent;
            lblMessage.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblMessage.Location = new Point(6, 24);
            lblMessage.Margin = new Padding(4, 0, 4, 0);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(455, 18);
            lblMessage.TabIndex = 1;
            lblMessage.Text = "Test message";
            // 
            // lblDateTime
            // 
            lblDateTime.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblDateTime.AutoEllipsis = true;
            lblDateTime.AutoSize = true;
            lblDateTime.Font = new Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point);
            lblDateTime.ForeColor = Color.FromArgb(100, 100, 100);
            lblDateTime.Location = new Point(379, 47);
            lblDateTime.Margin = new Padding(4, 0, 4, 0);
            lblDateTime.Name = "lblDateTime";
            lblDateTime.Size = new Size(51, 14);
            lblDateTime.TabIndex = 2;
            lblDateTime.Text = "12:00 PM";
            lblDateTime.TextAlign = ContentAlignment.TopRight;
            // 
            // pnlBubble
            // 
            pnlBubble.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlBubble.BackColor = Color.White;
            pnlBubble.Controls.Add(picDeliveryStatus);
            pnlBubble.Controls.Add(lblDateTime);
            pnlBubble.Controls.Add(lblMessage);
            pnlBubble.Controls.Add(lblUsername);
            pnlBubble.Location = new Point(23, 5);
            pnlBubble.Margin = new Padding(4, 3, 4, 3);
            pnlBubble.Name = "pnlBubble";
            pnlBubble.Size = new Size(467, 67);
            pnlBubble.TabIndex = 3;
            // 
            // picDeliveryStatus
            // 
            picDeliveryStatus.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            picDeliveryStatus.BackColor = Color.Transparent;
            picDeliveryStatus.Image = Properties.Resources.waiting;
            picDeliveryStatus.Location = new Point(443, 46);
            picDeliveryStatus.Margin = new Padding(4, 3, 4, 3);
            picDeliveryStatus.Name = "picDeliveryStatus";
            picDeliveryStatus.Size = new Size(19, 18);
            picDeliveryStatus.TabIndex = 3;
            picDeliveryStatus.TabStop = false;
            picDeliveryStatus.Visible = false;
            // 
            // picPointLeft
            // 
            picPointLeft.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            picPointLeft.BackColor = Color.Transparent;
            picPointLeft.BackgroundImageLayout = ImageLayout.None;
            picPointLeft.Image = Properties.Resources.point_left;
            picPointLeft.Location = new Point(5, 48);
            picPointLeft.Margin = new Padding(4, 3, 4, 3);
            picPointLeft.Name = "picPointLeft";
            picPointLeft.Size = new Size(16, 16);
            picPointLeft.SizeMode = PictureBoxSizeMode.AutoSize;
            picPointLeft.TabIndex = 5;
            picPointLeft.TabStop = false;
            // 
            // picPointRight
            // 
            picPointRight.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            picPointRight.BackColor = Color.Transparent;
            picPointRight.BackgroundImageLayout = ImageLayout.None;
            picPointRight.Image = Properties.Resources.point_right;
            picPointRight.Location = new Point(677, 48);
            picPointRight.Margin = new Padding(4, 3, 4, 3);
            picPointRight.Name = "picPointRight";
            picPointRight.Size = new Size(16, 16);
            picPointRight.SizeMode = PictureBoxSizeMode.AutoSize;
            picPointRight.TabIndex = 4;
            picPointRight.TabStop = false;
            picPointRight.Visible = false;
            // 
            // timer1
            // 
            timer1.Interval = 10000;
            timer1.Tick += timer1_Tick;
            // 
            // ChatMessageTextItem
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            BackColor = Color.Transparent;
            ContextMenuStrip = contextMenuStrip1;
            Controls.Add(picPointLeft);
            Controls.Add(picPointRight);
            Controls.Add(pnlBubble);
            Margin = new Padding(5, 3, 5, 3);
            Name = "ChatMessageTextItem";
            Size = new Size(700, 76);
            contextMenuStrip1.ResumeLayout(false);
            pnlBubble.ResumeLayout(false);
            pnlBubble.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picDeliveryStatus).EndInit();
            ((System.ComponentModel.ISupportInitialize)picPointLeft).EndInit();
            ((System.ComponentModel.ISupportInitialize)picPointRight).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Label lblDateTime;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuCopyMessage;
        private System.Windows.Forms.Panel pnlBubble;
        private System.Windows.Forms.PictureBox picDeliveryStatus;
        private System.Windows.Forms.PictureBox picPointRight;
        private System.Windows.Forms.PictureBox picPointLeft;
        private System.Windows.Forms.ToolStripMenuItem mnuMessageInfo;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem mnuForwardTo;
    }
}
