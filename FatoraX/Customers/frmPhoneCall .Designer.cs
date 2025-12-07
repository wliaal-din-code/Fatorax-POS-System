namespace FatoraX.Customers
{
    partial class frmPhoneCall
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
            this.guna2cmbMessageType = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtCustomMessage = new System.Windows.Forms.TextBox();
            this.lblAccountSid = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2btnCall = new Guna.UI2.WinForms.Guna2Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.TwilioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2cmbMessageType
            // 
            this.guna2cmbMessageType.AutoRoundedCorners = true;
            this.guna2cmbMessageType.BackColor = System.Drawing.Color.Transparent;
            this.guna2cmbMessageType.BorderColor = System.Drawing.Color.Silver;
            this.guna2cmbMessageType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.guna2cmbMessageType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.guna2cmbMessageType.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2cmbMessageType.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2cmbMessageType.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold);
            this.guna2cmbMessageType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.guna2cmbMessageType.ItemHeight = 30;
            this.guna2cmbMessageType.Items.AddRange(new object[] {
            "Send a new invoice notification",
            "Send a reminder for overdue invoice",
            "Send payment receipt confirmation",
            "Enter custom text"});
            this.guna2cmbMessageType.Location = new System.Drawing.Point(253, 79);
            this.guna2cmbMessageType.Margin = new System.Windows.Forms.Padding(2);
            this.guna2cmbMessageType.Name = "guna2cmbMessageType";
            this.guna2cmbMessageType.Size = new System.Drawing.Size(312, 36);
            this.guna2cmbMessageType.StartIndex = 1;
            this.guna2cmbMessageType.TabIndex = 5;
            this.guna2cmbMessageType.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.guna2cmbMessageType.SelectedIndexChanged += new System.EventHandler(this.guna2cmbMessageType_SelectedIndexChanged);
            // 
            // txtCustomMessage
            // 
            this.txtCustomMessage.Font = new System.Drawing.Font("Cairo SemiBold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomMessage.Location = new System.Drawing.Point(12, 158);
            this.txtCustomMessage.Multiline = true;
            this.txtCustomMessage.Name = "txtCustomMessage";
            this.txtCustomMessage.Size = new System.Drawing.Size(636, 178);
            this.txtCustomMessage.TabIndex = 6;
            this.txtCustomMessage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCustomMessage.Visible = false;
            // 
            // lblAccountSid
            // 
            this.lblAccountSid.AutoSize = true;
            this.lblAccountSid.BackColor = System.Drawing.Color.White;
            this.lblAccountSid.Font = new System.Drawing.Font("Cairo", 16F, System.Drawing.FontStyle.Bold);
            this.lblAccountSid.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.lblAccountSid.Location = new System.Drawing.Point(11, 73);
            this.lblAccountSid.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAccountSid.Name = "lblAccountSid";
            this.lblAccountSid.Size = new System.Drawing.Size(221, 42);
            this.lblAccountSid.TabIndex = 57;
            this.lblAccountSid.Text = "Select Message Type";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Cairo", 16F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.label1.Location = new System.Drawing.Point(11, 115);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 42);
            this.label1.TabIndex = 58;
            this.label1.Text = "Enter your text";
            this.label1.Visible = false;
            // 
            // guna2btnCall
            // 
            this.guna2btnCall.AutoRoundedCorners = true;
            this.guna2btnCall.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2btnCall.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2btnCall.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2btnCall.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2btnCall.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.guna2btnCall.Font = new System.Drawing.Font("Cairo", 16F, System.Drawing.FontStyle.Bold);
            this.guna2btnCall.ForeColor = System.Drawing.Color.White;
            this.guna2btnCall.Image = global::FatoraX.Properties.Resources.call_32;
            this.guna2btnCall.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.guna2btnCall.Location = new System.Drawing.Point(253, 341);
            this.guna2btnCall.Margin = new System.Windows.Forms.Padding(2);
            this.guna2btnCall.Name = "guna2btnCall";
            this.guna2btnCall.Size = new System.Drawing.Size(225, 44);
            this.guna2btnCall.TabIndex = 56;
            this.guna2btnCall.Text = "Start the call";
            this.guna2btnCall.Click += new System.EventHandler(this.guna2btnCall_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TwilioToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(689, 30);
            this.menuStrip1.TabIndex = 62;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // TwilioToolStripMenuItem
            // 
            this.TwilioToolStripMenuItem.Name = "TwilioToolStripMenuItem";
            this.TwilioToolStripMenuItem.Size = new System.Drawing.Size(157, 26);
            this.TwilioToolStripMenuItem.Text = "Twilio Settings";
            this.TwilioToolStripMenuItem.Click += new System.EventHandler(this.TwilioToolStripMenuItem_Click);
            // 
            // frmPhoneCall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(689, 407);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblAccountSid);
            this.Controls.Add(this.guna2btnCall);
            this.Controls.Add(this.txtCustomMessage);
            this.Controls.Add(this.guna2cmbMessageType);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmPhoneCall";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Call";
            this.Load += new System.EventHandler(this.frmPhoneCall_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ComboBox guna2cmbMessageType;
        private System.Windows.Forms.TextBox txtCustomMessage;
        private Guna.UI2.WinForms.Guna2Button guna2btnCall;
        private System.Windows.Forms.Label lblAccountSid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem TwilioToolStripMenuItem;
        private Guna.UI2.WinForms.Guna2ShadowForm guna2ShadowForm1;
    }
}