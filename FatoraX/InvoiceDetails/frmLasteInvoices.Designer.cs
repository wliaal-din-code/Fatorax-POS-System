namespace FatoraX.Invoices
{
    partial class frmLasteInvoices
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            this.guna2txtName = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gudgvInvoces = new Guna.UI2.WinForms.Guna2DataGridView();
            this.butAddinvoceies = new Guna.UI2.WinForms.Guna2Button();
            this.guna2putClose = new Guna.UI2.WinForms.Guna2Button();
            this.guna2lblRecordsCount = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2cbFilterBy = new Guna.UI2.WinForms.Guna2ComboBox();
            this.comInvoiceStatus = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gudgvInvoces)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2txtName
            // 
            this.guna2txtName.AutoRoundedCorners = true;
            this.guna2txtName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2txtName.DefaultText = "";
            this.guna2txtName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.guna2txtName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.guna2txtName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2txtName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2txtName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2txtName.Font = new System.Drawing.Font("Cairo", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2txtName.ForeColor = System.Drawing.Color.Black;
            this.guna2txtName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2txtName.Location = new System.Drawing.Point(317, 109);
            this.guna2txtName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.guna2txtName.Name = "guna2txtName";
            this.guna2txtName.PlaceholderText = "";
            this.guna2txtName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.guna2txtName.SelectedText = "";
            this.guna2txtName.Size = new System.Drawing.Size(186, 36);
            this.guna2txtName.TabIndex = 83;
            this.guna2txtName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.guna2txtName.Visible = false;
            this.guna2txtName.TextChanged += new System.EventHandler(this.guna2txtName_TextChanged_2);
            this.guna2txtName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.guna2txtName_KeyPress_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cairo", 16F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.label2.Location = new System.Drawing.Point(12, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 42);
            this.label2.TabIndex = 81;
            this.label2.Text = "Search by:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cairo", 16F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.label1.Location = new System.Drawing.Point(566, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 42);
            this.label1.TabIndex = 80;
            this.label1.Text = "Invoice List";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // gudgvInvoces
            // 
            this.gudgvInvoces.AllowUserToAddRows = false;
            this.gudgvInvoces.AllowUserToDeleteRows = false;
            this.gudgvInvoces.AllowUserToResizeColumns = false;
            this.gudgvInvoces.AllowUserToResizeRows = false;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.gudgvInvoces.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle13;
            this.gudgvInvoces.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.gudgvInvoces.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gudgvInvoces.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.gudgvInvoces.ColumnHeadersHeight = 34;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gudgvInvoces.DefaultCellStyle = dataGridViewCellStyle15;
            this.gudgvInvoces.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.gudgvInvoces.Location = new System.Drawing.Point(9, 153);
            this.gudgvInvoces.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.gudgvInvoces.Name = "gudgvInvoces";
            this.gudgvInvoces.ReadOnly = true;
            this.gudgvInvoces.RowHeadersVisible = false;
            this.gudgvInvoces.RowHeadersWidth = 62;
            this.gudgvInvoces.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.gudgvInvoces.RowsDefaultCellStyle = dataGridViewCellStyle16;
            this.gudgvInvoces.RowTemplate.Height = 29;
            this.gudgvInvoces.Size = new System.Drawing.Size(1192, 253);
            this.gudgvInvoces.TabIndex = 79;
            this.gudgvInvoces.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.gudgvInvoces.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.gudgvInvoces.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.gudgvInvoces.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.gudgvInvoces.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.gudgvInvoces.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.gudgvInvoces.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.gudgvInvoces.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.gudgvInvoces.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.gudgvInvoces.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gudgvInvoces.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.gudgvInvoces.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gudgvInvoces.ThemeStyle.HeaderStyle.Height = 34;
            this.gudgvInvoces.ThemeStyle.ReadOnly = true;
            this.gudgvInvoces.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.gudgvInvoces.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.gudgvInvoces.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gudgvInvoces.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.gudgvInvoces.ThemeStyle.RowsStyle.Height = 29;
            this.gudgvInvoces.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.gudgvInvoces.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // butAddinvoceies
            // 
            this.butAddinvoceies.AutoRoundedCorners = true;
            this.butAddinvoceies.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.butAddinvoceies.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.butAddinvoceies.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.butAddinvoceies.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.butAddinvoceies.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.butAddinvoceies.Font = new System.Drawing.Font("Cairo", 16F, System.Drawing.FontStyle.Bold);
            this.butAddinvoceies.ForeColor = System.Drawing.Color.White;
            this.butAddinvoceies.Location = new System.Drawing.Point(1005, 104);
            this.butAddinvoceies.Margin = new System.Windows.Forms.Padding(4);
            this.butAddinvoceies.Name = "butAddinvoceies";
            this.butAddinvoceies.Size = new System.Drawing.Size(180, 44);
            this.butAddinvoceies.TabIndex = 78;
            this.butAddinvoceies.Text = " Add Invoice";
            this.butAddinvoceies.Click += new System.EventHandler(this.butAddinvoceies_Click_1);
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
            this.guna2putClose.Location = new System.Drawing.Point(1045, 414);
            this.guna2putClose.Name = "guna2putClose";
            this.guna2putClose.Size = new System.Drawing.Size(156, 42);
            this.guna2putClose.TabIndex = 77;
            this.guna2putClose.Text = "Close";
            this.guna2putClose.Click += new System.EventHandler(this.guna2putClose_Click_1);
            // 
            // guna2lblRecordsCount
            // 
            this.guna2lblRecordsCount.BackColor = System.Drawing.Color.Transparent;
            this.guna2lblRecordsCount.Font = new System.Drawing.Font("Cairo", 16F, System.Drawing.FontStyle.Bold);
            this.guna2lblRecordsCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.guna2lblRecordsCount.Location = new System.Drawing.Point(129, 410);
            this.guna2lblRecordsCount.Name = "guna2lblRecordsCount";
            this.guna2lblRecordsCount.Size = new System.Drawing.Size(23, 42);
            this.guna2lblRecordsCount.TabIndex = 76;
            this.guna2lblRecordsCount.Text = "??";
            // 
            // guna2cbFilterBy
            // 
            this.guna2cbFilterBy.AutoRoundedCorners = true;
            this.guna2cbFilterBy.BackColor = System.Drawing.Color.Transparent;
            this.guna2cbFilterBy.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.guna2cbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.guna2cbFilterBy.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2cbFilterBy.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2cbFilterBy.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold);
            this.guna2cbFilterBy.ForeColor = System.Drawing.Color.Black;
            this.guna2cbFilterBy.ItemHeight = 30;
            this.guna2cbFilterBy.Items.AddRange(new object[] {
            "Undefined",
            "Invoice Id",
            "Customer Name",
            "Username",
            "Invoice Status"});
            this.guna2cbFilterBy.Location = new System.Drawing.Point(135, 109);
            this.guna2cbFilterBy.Name = "guna2cbFilterBy";
            this.guna2cbFilterBy.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.guna2cbFilterBy.Size = new System.Drawing.Size(175, 36);
            this.guna2cbFilterBy.StartIndex = 0;
            this.guna2cbFilterBy.TabIndex = 75;
            this.guna2cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.guna2cbFilterBy_SelectedIndexChanged);
            // 
            // comInvoiceStatus
            // 
            this.comInvoiceStatus.AutoRoundedCorners = true;
            this.comInvoiceStatus.BackColor = System.Drawing.Color.Transparent;
            this.comInvoiceStatus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comInvoiceStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comInvoiceStatus.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comInvoiceStatus.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comInvoiceStatus.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold);
            this.comInvoiceStatus.ForeColor = System.Drawing.Color.Black;
            this.comInvoiceStatus.ItemHeight = 30;
            this.comInvoiceStatus.Items.AddRange(new object[] {
            " All",
            "Paid",
            "Unpaid",
            "Partially Paid"});
            this.comInvoiceStatus.Location = new System.Drawing.Point(320, 110);
            this.comInvoiceStatus.Margin = new System.Windows.Forms.Padding(2);
            this.comInvoiceStatus.Name = "comInvoiceStatus";
            this.comInvoiceStatus.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.comInvoiceStatus.Size = new System.Drawing.Size(188, 36);
            this.comInvoiceStatus.StartIndex = 1;
            this.comInvoiceStatus.TabIndex = 84;
            this.comInvoiceStatus.Visible = false;
            this.comInvoiceStatus.SelectedIndexChanged += new System.EventHandler(this.comInvoiceStatus_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.label3.Location = new System.Drawing.Point(12, 418);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 24);
            this.label3.TabIndex = 85;
            this.label3.Text = "# Records:";
            // 
            // frmLasteInvoices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1212, 475);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comInvoiceStatus);
            this.Controls.Add(this.guna2txtName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gudgvInvoces);
            this.Controls.Add(this.butAddinvoceies);
            this.Controls.Add(this.guna2putClose);
            this.Controls.Add(this.guna2lblRecordsCount);
            this.Controls.Add(this.guna2cbFilterBy);
            this.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.Name = "frmLasteInvoices";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Invoice List";
            this.Load += new System.EventHandler(this.frmLasteInvoices_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gudgvInvoces)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox guna2txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2DataGridView gudgvInvoces;
        private Guna.UI2.WinForms.Guna2Button butAddinvoceies;
        private Guna.UI2.WinForms.Guna2Button guna2putClose;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2lblRecordsCount;
        private Guna.UI2.WinForms.Guna2ComboBox guna2cbFilterBy;
        private Guna.UI2.WinForms.Guna2ComboBox comInvoiceStatus;
        private System.Windows.Forms.Label label3;
    }
}