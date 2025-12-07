namespace FatoraX
{
    partial class frmMainScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainScreen));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.المنتجاتToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.العملاءToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.الفواتيرToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.تفاصيلالفاتورةToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.المستخدمونToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.تسجيلخروجToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.التقاريرالماليةToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.المنتجاتToolStripMenuItem,
            this.العملاءToolStripMenuItem,
            this.الفواتيرToolStripMenuItem,
            this.تفاصيلالفاتورةToolStripMenuItem,
            this.المستخدمونToolStripMenuItem,
            this.تسجيلخروجToolStripMenuItem,
            this.التقاريرالماليةToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1303, 38);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // المنتجاتToolStripMenuItem
            // 
            this.المنتجاتToolStripMenuItem.Image = global::FatoraX.Properties.Resources.products__3_;
            this.المنتجاتToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.المنتجاتToolStripMenuItem.Name = "المنتجاتToolStripMenuItem";
            this.المنتجاتToolStripMenuItem.Size = new System.Drawing.Size(107, 34);
            this.المنتجاتToolStripMenuItem.Text = "Products";
            this.المنتجاتToolStripMenuItem.Click += new System.EventHandler(this.المنتجاتToolStripMenuItem_Click);
            // 
            // العملاءToolStripMenuItem
            // 
            this.العملاءToolStripMenuItem.Image = global::FatoraX.Properties.Resources.rating;
            this.العملاءToolStripMenuItem.Name = "العملاءToolStripMenuItem";
            this.العملاءToolStripMenuItem.Size = new System.Drawing.Size(118, 34);
            this.العملاءToolStripMenuItem.Text = "Customers";
            this.العملاءToolStripMenuItem.Click += new System.EventHandler(this.العملاءToolStripMenuItem_Click);
            // 
            // الفواتيرToolStripMenuItem
            // 
            this.الفواتيرToolStripMenuItem.Image = global::FatoraX.Properties.Resources.invoice__3_;
            this.الفواتيرToolStripMenuItem.Name = "الفواتيرToolStripMenuItem";
            this.الفواتيرToolStripMenuItem.Size = new System.Drawing.Size(103, 34);
            this.الفواتيرToolStripMenuItem.Text = "Invoices";
            this.الفواتيرToolStripMenuItem.Click += new System.EventHandler(this.الفواتيرToolStripMenuItem_Click);
            // 
            // تفاصيلالفاتورةToolStripMenuItem
            // 
            this.تفاصيلالفاتورةToolStripMenuItem.Image = global::FatoraX.Properties.Resources.invoice__4_;
            this.تفاصيلالفاتورةToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.تفاصيلالفاتورةToolStripMenuItem.Name = "تفاصيلالفاتورةToolStripMenuItem";
            this.تفاصيلالفاتورةToolStripMenuItem.Size = new System.Drawing.Size(144, 34);
            this.تفاصيلالفاتورةToolStripMenuItem.Text = "Invoice Details";
            this.تفاصيلالفاتورةToolStripMenuItem.Click += new System.EventHandler(this.تفاصيلالفاتورةToolStripMenuItem_Click);
            // 
            // المستخدمونToolStripMenuItem
            // 
            this.المستخدمونToolStripMenuItem.Image = global::FatoraX.Properties.Resources.teamwork__1_;
            this.المستخدمونToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.المستخدمونToolStripMenuItem.Name = "المستخدمونToolStripMenuItem";
            this.المستخدمونToolStripMenuItem.Size = new System.Drawing.Size(85, 34);
            this.المستخدمونToolStripMenuItem.Text = "Users";
            this.المستخدمونToolStripMenuItem.Click += new System.EventHandler(this.المستخدمونToolStripMenuItem_Click);
            // 
            // تسجيلخروجToolStripMenuItem
            // 
            this.تسجيلخروجToolStripMenuItem.Image = global::FatoraX.Properties.Resources.report;
            this.تسجيلخروجToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.تسجيلخروجToolStripMenuItem.Name = "تسجيلخروجToolStripMenuItem";
            this.تسجيلخروجToolStripMenuItem.Size = new System.Drawing.Size(163, 34);
            this.تسجيلخروجToolStripMenuItem.Text = " Financial Reports";
            this.تسجيلخروجToolStripMenuItem.Click += new System.EventHandler(this.تسجيلخروجToolStripMenuItem_Click);
            // 
            // التقاريرالماليةToolStripMenuItem
            // 
            this.التقاريرالماليةToolStripMenuItem.Image = global::FatoraX.Properties.Resources.logout__1_;
            this.التقاريرالماليةToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.التقاريرالماليةToolStripMenuItem.Name = "التقاريرالماليةToolStripMenuItem";
            this.التقاريرالماليةToolStripMenuItem.Size = new System.Drawing.Size(102, 34);
            this.التقاريرالماليةToolStripMenuItem.Text = "Sign out";
            this.التقاريرالماليةToolStripMenuItem.Click += new System.EventHandler(this.التقاريرالماليةToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::FatoraX.Properties.Resources.ريد_صور_ىبحجم_شاشة_لبرنامج__FatoraX_بكن_الصور_بلون_الاسود_و_الشعار_في_المنتصف_شعر_لطبيق_FatoraX_;
            this.pictureBox1.Location = new System.Drawing.Point(0, 38);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1303, 462);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // frmMainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1303, 500);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMainScreen";
            this.Text = "Home Screen";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMainScreen_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMainScreen_FormClosed);
            this.Load += new System.EventHandler(this.frmMainScreen_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem المنتجاتToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem العملاءToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem الفواتيرToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem تفاصيلالفاتورةToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem المستخدمونToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem تسجيلخروجToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem التقاريرالماليةToolStripMenuItem;
    }
}