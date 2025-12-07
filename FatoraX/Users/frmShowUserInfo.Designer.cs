namespace FatoraX.Users
{
    partial class frmShowUserInfo
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
            this.guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
            this.butClose = new Guna.UI2.WinForms.Guna2Button();
            this.label5 = new System.Windows.Forms.Label();
            this.ctrShowUserInfo1 = new FatoraX.Users.ctrShowUserInfo();
            this.SuspendLayout();
            // 
            // butClose
            // 
            this.butClose.BorderRadius = 15;
            this.butClose.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.butClose.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.butClose.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.butClose.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.butClose.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.butClose.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butClose.ForeColor = System.Drawing.Color.White;
            this.butClose.Location = new System.Drawing.Point(479, 252);
            this.butClose.Name = "butClose";
            this.butClose.Size = new System.Drawing.Size(76, 45);
            this.butClose.TabIndex = 54;
            this.butClose.Text = "Close";
            this.butClose.Click += new System.EventHandler(this.butClose_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.label5.Location = new System.Drawing.Point(246, 18);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(144, 20);
            this.label5.TabIndex = 57;
            this.label5.Text = "User Information";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // ctrShowUserInfo1
            // 
            this.ctrShowUserInfo1.BackColor = System.Drawing.Color.White;
            this.ctrShowUserInfo1.Location = new System.Drawing.Point(10, 46);
            this.ctrShowUserInfo1.Margin = new System.Windows.Forms.Padding(1);
            this.ctrShowUserInfo1.Name = "ctrShowUserInfo1";
            this.ctrShowUserInfo1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ctrShowUserInfo1.Size = new System.Drawing.Size(600, 202);
            this.ctrShowUserInfo1.TabIndex = 58;
            // 
            // frmShowUserInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(627, 335);
            this.Controls.Add(this.butClose);
            this.Controls.Add(this.ctrShowUserInfo1);
            this.Controls.Add(this.label5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmShowUserInfo";
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Information";
            this.Load += new System.EventHandler(this.frmShowUserInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2ShadowForm guna2ShadowForm1;
        private Guna.UI2.WinForms.Guna2Button butClose;
        private System.Windows.Forms.Label label5;
        private ctrShowUserInfo ctrShowUserInfo1;
    }
}