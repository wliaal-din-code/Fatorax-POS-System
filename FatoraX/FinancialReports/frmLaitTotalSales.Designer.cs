namespace FatoraX.FinancialReports
{
    partial class frmLaitTotalSales
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLaitTotalSales));
            this.guna2lblRecordsCount = new System.Windows.Forms.Label();
            this.comFindBy = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comInvoiceStatus = new Guna.UI2.WinForms.Guna2ComboBox();
            this.comCustomerReport = new Guna.UI2.WinForms.Guna2ComboBox();
            this.comProductReport = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbTaxAmount = new System.Windows.Forms.Label();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.lbTotalAmount = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lbPiadAmount = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblRabh = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTaklaf = new System.Windows.Forms.Label();
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.dgvTotalSales = new System.Windows.Forms.DataGridView();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.btnPrint = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lbRabhPaid = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTotalSales)).BeginInit();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2lblRecordsCount
            // 
            this.guna2lblRecordsCount.AutoSize = true;
            this.guna2lblRecordsCount.Font = new System.Drawing.Font("Cairo", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2lblRecordsCount.Location = new System.Drawing.Point(122, 397);
            this.guna2lblRecordsCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.guna2lblRecordsCount.Name = "guna2lblRecordsCount";
            this.guna2lblRecordsCount.Size = new System.Drawing.Size(27, 29);
            this.guna2lblRecordsCount.TabIndex = 2;
            this.guna2lblRecordsCount.Text = "??";
            // 
            // comFindBy
            // 
            this.comFindBy.AutoRoundedCorners = true;
            this.comFindBy.BackColor = System.Drawing.Color.Transparent;
            this.comFindBy.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comFindBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comFindBy.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comFindBy.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comFindBy.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold);
            this.comFindBy.ForeColor = System.Drawing.Color.Black;
            this.comFindBy.ItemHeight = 30;
            this.comFindBy.Items.AddRange(new object[] {
            "All",
            "Net Profit",
            "Invoice Status",
            "Customer Report",
            "Product Report"});
            this.comFindBy.Location = new System.Drawing.Point(150, 84);
            this.comFindBy.Margin = new System.Windows.Forms.Padding(2);
            this.comFindBy.Name = "comFindBy";
            this.comFindBy.Size = new System.Drawing.Size(194, 36);
            this.comFindBy.StartIndex = 1;
            this.comFindBy.TabIndex = 3;
            this.comFindBy.SelectedIndexChanged += new System.EventHandler(this.comFindBy_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cairo", 16F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.label2.Location = new System.Drawing.Point(22, 78);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 42);
            this.label2.TabIndex = 4;
            this.label2.Text = "Report by";
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
            "All",
            "Paid",
            "Unpaid",
            "Partially Paid"});
            this.comInvoiceStatus.Location = new System.Drawing.Point(372, 84);
            this.comInvoiceStatus.Margin = new System.Windows.Forms.Padding(2);
            this.comInvoiceStatus.Name = "comInvoiceStatus";
            this.comInvoiceStatus.Size = new System.Drawing.Size(174, 36);
            this.comInvoiceStatus.StartIndex = 0;
            this.comInvoiceStatus.TabIndex = 5;
            this.comInvoiceStatus.SelectedIndexChanged += new System.EventHandler(this.comInvoiceStatus_SelectedIndexChanged);
            // 
            // comCustomerReport
            // 
            this.comCustomerReport.AutoRoundedCorners = true;
            this.comCustomerReport.BackColor = System.Drawing.Color.Transparent;
            this.comCustomerReport.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comCustomerReport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comCustomerReport.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comCustomerReport.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comCustomerReport.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold);
            this.comCustomerReport.ForeColor = System.Drawing.Color.Black;
            this.comCustomerReport.ItemHeight = 30;
            this.comCustomerReport.Items.AddRange(new object[] {
            "None ",
            "Most Purchasing",
            "Customers with Overdue Payments "});
            this.comCustomerReport.Location = new System.Drawing.Point(372, 84);
            this.comCustomerReport.Margin = new System.Windows.Forms.Padding(2);
            this.comCustomerReport.Name = "comCustomerReport";
            this.comCustomerReport.Size = new System.Drawing.Size(231, 36);
            this.comCustomerReport.StartIndex = 0;
            this.comCustomerReport.TabIndex = 6;
            this.comCustomerReport.Visible = false;
            this.comCustomerReport.SelectedIndexChanged += new System.EventHandler(this.comCustomerReport_SelectedIndexChanged);
            // 
            // comProductReport
            // 
            this.comProductReport.AutoRoundedCorners = true;
            this.comProductReport.BackColor = System.Drawing.Color.Transparent;
            this.comProductReport.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comProductReport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comProductReport.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comProductReport.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comProductReport.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold);
            this.comProductReport.ForeColor = System.Drawing.Color.Black;
            this.comProductReport.ItemHeight = 30;
            this.comProductReport.Items.AddRange(new object[] {
            "All",
            "Best Selling",
            "Least Selling"});
            this.comProductReport.Location = new System.Drawing.Point(372, 84);
            this.comProductReport.Margin = new System.Windows.Forms.Padding(2);
            this.comProductReport.Name = "comProductReport";
            this.comProductReport.Size = new System.Drawing.Size(212, 36);
            this.comProductReport.StartIndex = 0;
            this.comProductReport.TabIndex = 7;
            this.comProductReport.Visible = false;
            this.comProductReport.SelectedIndexChanged += new System.EventHandler(this.comProductReport_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Cairo", 16F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.label1.Location = new System.Drawing.Point(312, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(572, 60);
            this.label1.TabIndex = 11;
            this.label1.Text = "Sales Report";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbTaxAmount
            // 
            this.lbTaxAmount.Font = new System.Drawing.Font("Cairo", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTaxAmount.Location = new System.Drawing.Point(90, 24);
            this.lbTaxAmount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbTaxAmount.Name = "lbTaxAmount";
            this.lbTaxAmount.Size = new System.Drawing.Size(148, 29);
            this.lbTaxAmount.TabIndex = 13;
            this.lbTaxAmount.Text = "0  $";
            this.lbTaxAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // guna2Button1
            // 
            this.guna2Button1.AutoRoundedCorners = true;
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.guna2Button1.Font = new System.Drawing.Font("Cairo", 16F, System.Drawing.FontStyle.Bold);
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.Location = new System.Drawing.Point(11, 500);
            this.guna2Button1.Margin = new System.Windows.Forms.Padding(2);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(111, 40);
            this.guna2Button1.TabIndex = 15;
            this.guna2Button1.Text = "Close";
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // lbTotalAmount
            // 
            this.lbTotalAmount.Font = new System.Drawing.Font("Cairo", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalAmount.Location = new System.Drawing.Point(383, 29);
            this.lbTotalAmount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbTotalAmount.Name = "lbTotalAmount";
            this.lbTotalAmount.Size = new System.Drawing.Size(129, 29);
            this.lbTotalAmount.TabIndex = 16;
            this.lbTotalAmount.Text = "0  $";
            this.lbTotalAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Cairo", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(709, 25);
            this.lblTotal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(125, 29);
            this.lblTotal.TabIndex = 18;
            this.lblTotal.Text = "0  $";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Cairo", 14F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label9.Location = new System.Drawing.Point(5, 16);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 36);
            this.label9.TabIndex = 22;
            this.label9.Text = "Total Tax";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Cairo", 14F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label10.Location = new System.Drawing.Point(557, 19);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(158, 36);
            this.label10.TabIndex = 24;
            this.label10.Text = "Total without Tax";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Cairo", 14F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label11.Location = new System.Drawing.Point(251, 25);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(131, 36);
            this.label11.TabIndex = 25;
            this.label11.Text = "Total with Tax";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Cairo", 14F, System.Drawing.FontStyle.Bold);
            this.label15.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label15.Location = new System.Drawing.Point(251, 73);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(160, 36);
            this.label15.TabIndex = 31;
            this.label15.Text = "Actual Profit Only";
            this.label15.Visible = false;
            // 
            // lbPiadAmount
            // 
            this.lbPiadAmount.Font = new System.Drawing.Font("Cairo", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPiadAmount.Location = new System.Drawing.Point(90, 70);
            this.lbPiadAmount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbPiadAmount.Name = "lbPiadAmount";
            this.lbPiadAmount.Size = new System.Drawing.Size(154, 29);
            this.lbPiadAmount.TabIndex = 30;
            this.lbPiadAmount.Text = "0  $";
            this.lbPiadAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Cairo", 14F, System.Drawing.FontStyle.Bold);
            this.label13.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label13.Location = new System.Drawing.Point(5, 64);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(93, 36);
            this.label13.TabIndex = 29;
            this.label13.Text = "Expenses";
            // 
            // lblRabh
            // 
            this.lblRabh.Font = new System.Drawing.Font("Cairo", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRabh.Location = new System.Drawing.Point(412, 80);
            this.lblRabh.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRabh.Name = "lblRabh";
            this.lblRabh.Size = new System.Drawing.Size(141, 29);
            this.lblRabh.TabIndex = 28;
            this.lblRabh.Text = "0  $";
            this.lblRabh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblRabh.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cairo", 14F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(837, 19);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 36);
            this.label3.TabIndex = 27;
            this.label3.Text = "Costs";
            this.label3.Visible = false;
            // 
            // lblTaklaf
            // 
            this.lblTaklaf.Font = new System.Drawing.Font("Cairo", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTaklaf.Location = new System.Drawing.Point(895, 24);
            this.lblTaklaf.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTaklaf.Name = "lblTaklaf";
            this.lblTaklaf.Size = new System.Drawing.Size(117, 29);
            this.lblTaklaf.TabIndex = 26;
            this.lblTaklaf.Text = "0  $";
            this.lblTaklaf.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTaklaf.Visible = false;
            // 
            // dtFrom
            // 
            this.dtFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFrom.Location = new System.Drawing.Point(1069, 57);
            this.dtFrom.Margin = new System.Windows.Forms.Padding(2);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(135, 22);
            this.dtFrom.TabIndex = 27;
            this.dtFrom.ValueChanged += new System.EventHandler(this.dtFrom_ValueChanged);
            // 
            // dtTo
            // 
            this.dtTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtTo.Location = new System.Drawing.Point(1069, 92);
            this.dtTo.Margin = new System.Windows.Forms.Padding(2);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(135, 22);
            this.dtTo.TabIndex = 28;
            this.dtTo.ValueChanged += new System.EventHandler(this.dtTo_ValueChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(981, 53);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(83, 30);
            this.label17.TabIndex = 29;
            this.label17.Text = "Start Date";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(981, 90);
            this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(75, 30);
            this.label18.TabIndex = 30;
            this.label18.Text = "End Date";
            // 
            // dgvTotalSales
            // 
            this.dgvTotalSales.AllowUserToAddRows = false;
            this.dgvTotalSales.AllowUserToDeleteRows = false;
            this.dgvTotalSales.AllowUserToOrderColumns = true;
            this.dgvTotalSales.AllowUserToResizeRows = false;
            this.dgvTotalSales.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Cairo", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTotalSales.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTotalSales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Cairo", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTotalSales.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTotalSales.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvTotalSales.Location = new System.Drawing.Point(8, 138);
            this.dgvTotalSales.Margin = new System.Windows.Forms.Padding(2);
            this.dgvTotalSales.Name = "dgvTotalSales";
            this.dgvTotalSales.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Cairo", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTotalSales.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvTotalSales.RowHeadersVisible = false;
            this.dgvTotalSales.RowHeadersWidth = 62;
            this.dgvTotalSales.RowTemplate.Height = 29;
            this.dgvTotalSales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTotalSales.Size = new System.Drawing.Size(1201, 229);
            this.dgvTotalSales.TabIndex = 8;
            this.dgvTotalSales.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTotalSales_CellContentClick_1);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // btnPrint
            // 
            this.btnPrint.AutoRoundedCorners = true;
            this.btnPrint.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnPrint.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnPrint.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnPrint.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnPrint.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnPrint.Font = new System.Drawing.Font("Cairo", 16F, System.Drawing.FontStyle.Bold);
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.Location = new System.Drawing.Point(1081, 500);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(2);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(111, 40);
            this.btnPrint.TabIndex = 31;
            this.btnPrint.Text = "Printer";
            this.btnPrint.Click += new System.EventHandler(this.guna2Button2_Click);
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.label4);
            this.guna2Panel1.Controls.Add(this.label15);
            this.guna2Panel1.Controls.Add(this.lbRabhPaid);
            this.guna2Panel1.Controls.Add(this.label10);
            this.guna2Panel1.Controls.Add(this.lbPiadAmount);
            this.guna2Panel1.Controls.Add(this.lbTaxAmount);
            this.guna2Panel1.Controls.Add(this.lblTotal);
            this.guna2Panel1.Controls.Add(this.lblRabh);
            this.guna2Panel1.Controls.Add(this.label13);
            this.guna2Panel1.Controls.Add(this.label9);
            this.guna2Panel1.Controls.Add(this.label3);
            this.guna2Panel1.Controls.Add(this.lbTotalAmount);
            this.guna2Panel1.Controls.Add(this.lblTaklaf);
            this.guna2Panel1.Controls.Add(this.label11);
            this.guna2Panel1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.guna2Panel1.Location = new System.Drawing.Point(192, 373);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(1017, 122);
            this.guna2Panel1.TabIndex = 32;
            this.guna2Panel1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cairo", 14F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(557, 73);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 36);
            this.label4.TabIndex = 34;
            this.label4.Text = "Total Profit";
            this.label4.Visible = false;
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // lbRabhPaid
            // 
            this.lbRabhPaid.Font = new System.Drawing.Font("Cairo", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRabhPaid.Location = new System.Drawing.Point(667, 80);
            this.lbRabhPaid.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbRabhPaid.Name = "lbRabhPaid";
            this.lbRabhPaid.Size = new System.Drawing.Size(151, 29);
            this.lbRabhPaid.TabIndex = 33;
            this.lbRabhPaid.Text = "0  $";
            this.lbRabhPaid.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbRabhPaid.Visible = false;
            this.lbRabhPaid.Click += new System.EventHandler(this.lbRabhPaid_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.label5.Location = new System.Drawing.Point(6, 399);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 24);
            this.label5.TabIndex = 61;
            this.label5.Text = "# Records:";
            // 
            // frmLaitTotalSales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1222, 547);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.dtTo);
            this.Controls.Add(this.dtFrom);
            this.Controls.Add(this.guna2Button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.guna2lblRecordsCount);
            this.Controls.Add(this.dgvTotalSales);
            this.Controls.Add(this.comProductReport);
            this.Controls.Add(this.comCustomerReport);
            this.Controls.Add(this.comInvoiceStatus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comFindBy);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmLaitTotalSales";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sales Report";
            this.Load += new System.EventHandler(this.frmLaitTotalSales_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTotalSales)).EndInit();
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2DataGridViewStyler guna2DataGridViewStyler1;
        private System.Windows.Forms.Label guna2lblRecordsCount;
        private Guna.UI2.WinForms.Guna2ComboBox comFindBy;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2ComboBox comInvoiceStatus;
        private Guna.UI2.WinForms.Guna2ComboBox comCustomerReport;
        private Guna.UI2.WinForms.Guna2ComboBox comProductReport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbTaxAmount;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private System.Windows.Forms.Label lbTotalAmount;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lbPiadAmount;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblRabh;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTaklaf;
        private System.Windows.Forms.DateTimePicker dtFrom;
        private System.Windows.Forms.DateTimePicker dtTo;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.PrintDialog printDialog1;
        private Guna.UI2.WinForms.Guna2Button btnPrint;
        private System.Windows.Forms.GroupBox guna2Panel1;
        private System.Windows.Forms.DataGridView dgvTotalSales;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbRabhPaid;
        private System.Windows.Forms.Label label5;
    }
}