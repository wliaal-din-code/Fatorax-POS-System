namespace FatoraX.Customers
{
    partial class frmFindCustomers
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
            this.guna2putClose = new Guna.UI2.WinForms.Guna2Button();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
            this.ctrlCustomerCardWithFilter1 = new FatoraX.Customers.ctrlCustomerCardWithFilter();
            this.SuspendLayout();
            // 
            // guna2putClose
            // 
            this.guna2putClose.AutoRoundedCorners = true;
            this.guna2putClose.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2putClose.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2putClose.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2putClose.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2putClose.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.guna2putClose.Font = new System.Drawing.Font("Cairo", 16F, System.Drawing.FontStyle.Bold);
            this.guna2putClose.ForeColor = System.Drawing.Color.White;
            this.guna2putClose.Image = global::FatoraX.Properties.Resources.cross_32;
            this.guna2putClose.Location = new System.Drawing.Point(596, 481);
            this.guna2putClose.Margin = new System.Windows.Forms.Padding(2);
            this.guna2putClose.Name = "guna2putClose";
            this.guna2putClose.Size = new System.Drawing.Size(109, 42);
            this.guna2putClose.TabIndex = 38;
            this.guna2putClose.Text = "إغلاق";
            this.guna2putClose.Click += new System.EventHandler(this.guna2putClose_Click);
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Cairo", 18F, System.Drawing.FontStyle.Bold);
            this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(280, 5);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(154, 47);
            this.guna2HtmlLabel1.TabIndex = 40;
            this.guna2HtmlLabel1.Text = "Find Customer";
            // 
            // ctrlCustomerCardWithFilter1
            // 
            this.ctrlCustomerCardWithFilter1.AutoSize = true;
            this.ctrlCustomerCardWithFilter1.BackColor = System.Drawing.Color.White;
            this.ctrlCustomerCardWithFilter1.FilterEnabled = true;
            this.ctrlCustomerCardWithFilter1.Location = new System.Drawing.Point(12, 58);
            this.ctrlCustomerCardWithFilter1.Name = "ctrlCustomerCardWithFilter1";
            this.ctrlCustomerCardWithFilter1.Size = new System.Drawing.Size(754, 481);
            this.ctrlCustomerCardWithFilter1.TabIndex = 39;
            // 
            // frmFindCustomers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(781, 534);
            this.Controls.Add(this.guna2HtmlLabel1);
            this.Controls.Add(this.ctrlCustomerCardWithFilter1);
            this.Controls.Add(this.guna2putClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmFindCustomers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Find Customer";
            this.Load += new System.EventHandler(this.frmFindCustomers_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Button guna2putClose;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2ShadowForm guna2ShadowForm1;
        private ctrlCustomerCardWithFilter ctrlCustomerCardWithFilter1;
    }
}