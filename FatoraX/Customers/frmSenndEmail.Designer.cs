namespace FatoraX.Customers
{
    partial class frmSenndEmail
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
            this.Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.flowLayoutPanelEmails = new System.Windows.Forms.FlowLayoutPanel();
            this.txtEmailInput = new System.Windows.Forms.TextBox();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.txtBody = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.إعداداتTwilioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
            this.guna2ShadowForm2 = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Button1
            // 
            this.Button1.AutoRoundedCorners = true;
            this.Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Button1.Enabled = false;
            this.Button1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.Button1.Font = new System.Drawing.Font("Cairo", 16F, System.Drawing.FontStyle.Bold);
            this.Button1.ForeColor = System.Drawing.Color.White;
            this.Button1.Location = new System.Drawing.Point(1086, 393);
            this.Button1.Margin = new System.Windows.Forms.Padding(2);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(95, 46);
            this.Button1.TabIndex = 59;
            this.Button1.Text = "إرسال";
            this.Button1.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // flowLayoutPanelEmails
            // 
            this.flowLayoutPanelEmails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanelEmails.Location = new System.Drawing.Point(11, 80);
            this.flowLayoutPanelEmails.Name = "flowLayoutPanelEmails";
            this.flowLayoutPanelEmails.Size = new System.Drawing.Size(1188, 29);
            this.flowLayoutPanelEmails.TabIndex = 60;
            // 
            // txtEmailInput
            // 
            this.txtEmailInput.Location = new System.Drawing.Point(11, 37);
            this.txtEmailInput.Multiline = true;
            this.txtEmailInput.Name = "txtEmailInput";
            this.txtEmailInput.Size = new System.Drawing.Size(342, 37);
            this.txtEmailInput.TabIndex = 0;
            this.txtEmailInput.TextChanged += new System.EventHandler(this.txtEmailInput_TextChanged);
            this.txtEmailInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEmailInput_KeyDown);
            // 
            // txtSubject
            // 
            this.txtSubject.Font = new System.Drawing.Font("Cairo SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubject.Location = new System.Drawing.Point(11, 129);
            this.txtSubject.Multiline = true;
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSubject.Size = new System.Drawing.Size(1188, 37);
            this.txtSubject.TabIndex = 61;
            this.txtSubject.TextChanged += new System.EventHandler(this.txtSubject_TextChanged);
            // 
            // txtBody
            // 
            this.txtBody.Font = new System.Drawing.Font("Cairo SemiBold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBody.Location = new System.Drawing.Point(11, 172);
            this.txtBody.Multiline = true;
            this.txtBody.Name = "txtBody";
            this.txtBody.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtBody.Size = new System.Drawing.Size(1188, 313);
            this.txtBody.TabIndex = 62;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.إعداداتTwilioToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1211, 30);
            this.menuStrip1.TabIndex = 63;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // إعداداتTwilioToolStripMenuItem
            // 
            this.إعداداتTwilioToolStripMenuItem.Name = "إعداداتTwilioToolStripMenuItem";
            this.إعداداتTwilioToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.إعداداتTwilioToolStripMenuItem.Text = " إعدادات البريد الالكتروني";
            this.إعداداتTwilioToolStripMenuItem.Click += new System.EventHandler(this.إعداداتTwilioToolStripMenuItem_Click);
            // 
            // frmSenndEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1211, 497);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.txtEmailInput);
            this.Controls.Add(this.txtSubject);
            this.Controls.Add(this.Button1);
            this.Controls.Add(this.flowLayoutPanelEmails);
            this.Controls.Add(this.txtBody);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmSenndEmail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "إرسال البريد الإلكتروني";
            this.Load += new System.EventHandler(this.frmSenndEmail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Button Button1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelEmails;
        private System.Windows.Forms.TextBox txtBody;
        private System.Windows.Forms.TextBox txtSubject;
        private System.Windows.Forms.TextBox txtEmailInput;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem إعداداتTwilioToolStripMenuItem;
        private Guna.UI2.WinForms.Guna2ShadowForm guna2ShadowForm1;
        private Guna.UI2.WinForms.Guna2ShadowForm guna2ShadowForm2;
    }
}