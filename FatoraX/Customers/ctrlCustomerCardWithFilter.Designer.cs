namespace FatoraX.Customers
{
    partial class ctrlCustomerCardWithFilter
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
            this.components = new System.ComponentModel.Container();
            this.guna2PaFilters = new Guna.UI2.WinForms.Guna2Panel();
            this.btnAddNewCustomer = new System.Windows.Forms.Button();
            this.btnFind = new System.Windows.Forms.Button();
            this.guna2txtFilterValue = new Guna.UI2.WinForms.Guna2TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.ctrlCustomerInfo1 = new FatoraX.People.ctrlCustomerInfo();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2txtFilterBy = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2PaFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2PaFilters
            // 
            this.guna2PaFilters.Controls.Add(this.btnAddNewCustomer);
            this.guna2PaFilters.Controls.Add(this.guna2HtmlLabel1);
            this.guna2PaFilters.Controls.Add(this.btnFind);
            this.guna2PaFilters.Controls.Add(this.guna2txtFilterBy);
            this.guna2PaFilters.Controls.Add(this.guna2txtFilterValue);
            this.guna2PaFilters.Location = new System.Drawing.Point(15, 11);
            this.guna2PaFilters.Margin = new System.Windows.Forms.Padding(2);
            this.guna2PaFilters.Name = "guna2PaFilters";
            this.guna2PaFilters.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.guna2PaFilters.Size = new System.Drawing.Size(666, 69);
            this.guna2PaFilters.TabIndex = 42;
            // 
            // btnAddNewCustomer
            // 
            this.btnAddNewCustomer.Image = global::FatoraX.Properties.Resources.Add_Person_40;
            this.btnAddNewCustomer.Location = new System.Drawing.Point(554, 14);
            this.btnAddNewCustomer.Name = "btnAddNewCustomer";
            this.btnAddNewCustomer.Size = new System.Drawing.Size(59, 45);
            this.btnAddNewCustomer.TabIndex = 46;
            this.btnAddNewCustomer.UseVisualStyleBackColor = true;
            this.btnAddNewCustomer.Click += new System.EventHandler(this.btnAddNewCustomer_Click);
            // 
            // btnFind
            // 
            this.btnFind.Image = global::FatoraX.Properties.Resources.SearchPerson;
            this.btnFind.Location = new System.Drawing.Point(489, 14);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(59, 45);
            this.btnFind.TabIndex = 45;
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // guna2txtFilterValue
            // 
            this.guna2txtFilterValue.Animated = true;
            this.guna2txtFilterValue.AutoRoundedCorners = true;
            this.guna2txtFilterValue.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2txtFilterValue.DefaultText = "";
            this.guna2txtFilterValue.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.guna2txtFilterValue.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.guna2txtFilterValue.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2txtFilterValue.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2txtFilterValue.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2txtFilterValue.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold);
            this.guna2txtFilterValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.guna2txtFilterValue.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2txtFilterValue.Location = new System.Drawing.Point(247, 19);
            this.guna2txtFilterValue.Margin = new System.Windows.Forms.Padding(3, 8, 3, 8);
            this.guna2txtFilterValue.Name = "guna2txtFilterValue";
            this.guna2txtFilterValue.PlaceholderText = "";
            this.guna2txtFilterValue.SelectedText = "";
            this.guna2txtFilterValue.Size = new System.Drawing.Size(236, 37);
            this.guna2txtFilterValue.TabIndex = 37;
            this.guna2txtFilterValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.guna2txtFilterValue_KeyPress);
            this.guna2txtFilterValue.Validating += new System.ComponentModel.CancelEventHandler(this.guna2txtFilterValue_Validating);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ctrlCustomerInfo1
            // 
            this.ctrlCustomerInfo1.BackColor = System.Drawing.Color.White;
            this.ctrlCustomerInfo1.Location = new System.Drawing.Point(0, 87);
            this.ctrlCustomerInfo1.Name = "ctrlCustomerInfo1";
            this.ctrlCustomerInfo1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ctrlCustomerInfo1.Size = new System.Drawing.Size(684, 391);
            this.ctrlCustomerInfo1.TabIndex = 43;
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Cairo", 16F, System.Drawing.FontStyle.Bold);
            this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(2, 14);
            this.guna2HtmlLabel1.Margin = new System.Windows.Forms.Padding(2);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(97, 42);
            this.guna2HtmlLabel1.TabIndex = 47;
            this.guna2HtmlLabel1.Text = "Search by:";
            // 
            // guna2txtFilterBy
            // 
            this.guna2txtFilterBy.Animated = true;
            this.guna2txtFilterBy.AutoRoundedCorners = true;
            this.guna2txtFilterBy.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2txtFilterBy.DefaultText = "Customer Id";
            this.guna2txtFilterBy.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.guna2txtFilterBy.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.guna2txtFilterBy.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2txtFilterBy.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2txtFilterBy.Enabled = false;
            this.guna2txtFilterBy.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2txtFilterBy.Font = new System.Drawing.Font("Cairo", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2txtFilterBy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.guna2txtFilterBy.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2txtFilterBy.Location = new System.Drawing.Point(105, 14);
            this.guna2txtFilterBy.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.guna2txtFilterBy.Name = "guna2txtFilterBy";
            this.guna2txtFilterBy.PlaceholderText = "";
            this.guna2txtFilterBy.SelectedText = "";
            this.guna2txtFilterBy.Size = new System.Drawing.Size(135, 42);
            this.guna2txtFilterBy.TabIndex = 44;
            // 
            // ctrlCustomerCardWithFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.ctrlCustomerInfo1);
            this.Controls.Add(this.guna2PaFilters);
            this.Name = "ctrlCustomerCardWithFilter";
            this.Size = new System.Drawing.Size(697, 470);
            this.guna2PaFilters.ResumeLayout(false);
            this.guna2PaFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Panel guna2PaFilters;
        private People.ctrlCustomerInfo ctrlCustomerInfo1;
        private Guna.UI2.WinForms.Guna2TextBox guna2txtFilterValue;
        private System.Windows.Forms.Button btnAddNewCustomer;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2TextBox guna2txtFilterBy;
    }
}
