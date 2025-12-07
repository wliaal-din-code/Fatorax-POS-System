using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FX_Buisness;

namespace FatoraX.FinancialReports
{
    public partial class frmLaitTotalSales : Form
    {
        public frmLaitTotalSales()
        {
            InitializeComponent();
            PrintDocument.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);
            
        }
        float SubTotals = 0, TaxAmounts = 0, TotalAmounts = 0,
      PaidAmounts = 0, Taklafs = 0, Rabhs = 0;


        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            StringFormat rtlFormat = new StringFormat();
            rtlFormat.Alignment = StringAlignment.Far;
            rtlFormat.LineAlignment = StringAlignment.Center;
            rtlFormat.FormatFlags = StringFormatFlags.DirectionRightToLeft;

            Font headerFont = new Font("Arial", 16, FontStyle.Bold);
            Font labelFont = new Font("Arial", 12, FontStyle.Regular);
            int startX = e.MarginBounds.Left;
            int startY = e.MarginBounds.Top;

            // رسم العنوان الرئيسي
            e.Graphics.DrawString("Sales Invoice", headerFont, Brushes.Black, new RectangleF(startX, startY, e.MarginBounds.Width, 40), rtlFormat);
            startY += 50;

            // التاريخ
            e.Graphics.DrawString("Date: " + DateTime.Now.ToString("yyyy/MM/dd"), labelFont, Brushes.Black, new RectangleF(startX, startY, e.MarginBounds.Width, 30), rtlFormat);
            startY += 40;

            // رسم الـ Labels المطلوبة
            string[] infoLines = {
        "Total Tax: " + lbTaxAmount.Text,
        "Total excluding Tax: " + lblTotal.Text,
        "Total including Tax: " + lbTotalAmount.Text,
        "Costs: " + lblTaklaf.Text,
        "Net Profit: " + lblRabh.Text,
        "Expenses: " + lbPiadAmount.Text
    };

            foreach (string line in infoLines)
            {
                e.Graphics.DrawString(line, labelFont, Brushes.Black, new RectangleF(startX, startY, e.MarginBounds.Width, 30), rtlFormat);
                startY += 30;
            }

            startY += 20;

            // رسم رأس جدول الـ DataGridView
            int colWidth = e.MarginBounds.Width / dgvTotalSales.Columns.Count;
            for (int i = 0; i < dgvTotalSales.Columns.Count; i++)
            {
                e.Graphics.DrawRectangle(Pens.Black, startX + i * colWidth, startY, colWidth,30);
                e.Graphics.DrawString(dgvTotalSales.Columns[i].HeaderText, labelFont, Brushes.Black, new RectangleF(startX + i * colWidth, startY, colWidth, 30), rtlFormat);
            }

            startY += 30;

            // رسم بيانات الصفوف
            for (int row = 0; row < dgvTotalSales.Rows.Count; row++)
            {
                for (int col = 0; col < dgvTotalSales.Columns.Count; col++)
                {
                    string value = dgvTotalSales.Rows[row].Cells[col].Value?.ToString() ?? "";
                    e.Graphics.DrawRectangle(Pens.Black, startX + col * colWidth, startY, colWidth, 30);
                    e.Graphics.DrawString(value, labelFont, Brushes.Black, new RectangleF(startX + col * colWidth, startY, colWidth, 30), rtlFormat);
                }
                startY += 30;
            }

        }

        DataTable _dgvTotalSales;

        void ValidDate()
        {
            comFindBy.SelectedIndex = 0;

            dtFrom.MinDate = DateTime.Now.AddYears(-200);
            dtFrom.MaxDate = DateTime.Now.AddDays(-1);
            dtFrom.Value = dtFrom.MaxDate;
            


            dtTo.MinDate = DateTime.Now.AddYears(-200); ;
            dtTo.Value = DateTime.Now.Date;
            dtTo.MaxDate = DateTime.Now;
        }

        PrintDocument PrintDocument = new PrintDocument();
        decimal total = 0;
        decimal taklaf = 0;
        decimal rabh = 0;

        DataTable dtAllReslut;
        private void frmLaitTotalSales_Load(object sender, EventArgs e)
        {
            ValidDate();
            lblTaklaf.Visible =true; 
            lblRabh.Visible =  true;
            label15.Visible =  true;
            label3.Visible = true;
         
           // lbThang.Text = "Number of Invoices";
            _dgvTotalSales = clsInvoec.GetAllTotalSales();


            if (_dgvTotalSales.Rows.Count == 0)
            {
                Faladdata();
                dgvTotalSales.DataSource = null;
                dgvTotalSales.Rows.Clear(); // هذا اختياري بعد فك الربط
                btnPrint.Enabled = false;
                return;
            }


            dgvTotalSales.DataSource = _dgvTotalSales;

            guna2lblRecordsCount.Text = dgvTotalSales.Rows.Count.ToString();
            if (dgvTotalSales.Rows.Count > 0)
            {

                dgvTotalSales.Columns[0].HeaderText = "Invoice Id";
                dgvTotalSales.Columns[0].Width = 100;

                dgvTotalSales.Columns[1].HeaderText = "Customer Id";
                dgvTotalSales.Columns[1].Width = 180;

                dgvTotalSales.Columns[2].HeaderText = "Date";
                dgvTotalSales.Columns[2].Width = 140;

                dgvTotalSales.Columns[3].HeaderText = "Total Before Tax";
                dgvTotalSales.Columns[3].Width = 180;

                dgvTotalSales.Columns[4].HeaderText = "Tax Rate";
                dgvTotalSales.Columns[4].Width = 120;

                dgvTotalSales.Columns[5].HeaderText = "Tax Amount";
                dgvTotalSales.Columns[5].Width = 120;

                dgvTotalSales.Columns[6].HeaderText = "Amount Paid";
                dgvTotalSales.Columns[6].Width = 150;
                
                dgvTotalSales.Columns[7].HeaderText = "Status";
                dgvTotalSales.Columns[7].Width = 150;
             

               
                Rabah();

            }
        }

        private void dgvTotalSales_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comCustomerReport_SelectedIndexChanged(object sender, EventArgs e)
        {

            guna2Panel1.Visible = true;
            switch (comCustomerReport.Text)
                
                {
                case "غير":
                    {

                        comCustomerReport.Visible = false;
                        frmLaitTotalSales_Load(null, null);
                        
                        break;
                    }
                case "Most Purchased":
                    {
                        guna2Panel1.Visible = false;
                        GetMoreCustomersPuy();

                        //lbThang.Text = "Number of Products";
                        break;
                    }
                default:
                    {
                       
                       // lbThang.Text = "Number of Delinquent Customers";
                        guna2Panel1.Visible = false;
                        GetMoreCustomerslatetoPuy();
                        break;
                    }

            }


        }

        private void comFindBy_SelectedIndexChanged(object sender, EventArgs e)
        {
          

              if(comFindBy.Text == "All")
              {
                comCustomerReport.Visible = false;
                comInvoiceStatus.Visible = false;
                comProductReport.Visible = false;
                frmLaitTotalSales_Load(null, null);
                return;
               }
        
            switch(comFindBy.Text)
            {
                case "Net Profit":
                    {

                        guna2Panel1.Visible = true;
                        comCustomerReport.Visible = false;
                        comInvoiceStatus.Visible = true;
                        //comInvoiceStatus.SelectedIndex = 1;

                        comProductReport.Visible = false;
                        break;
                    }
                case "Product Report":
                    {

                        guna2Panel1.Visible = true;
                        //حالة الفواتير
                        comCustomerReport.Visible = false;
                        comInvoiceStatus.Visible = false;
                        comProductReport.Visible = true;
                        comProductReport.SelectedIndex = 0;
                        break;
                    }

                case "Invoice Status":
                    {
                        //
                        guna2Panel1.Visible = true;
                        comCustomerReport.Visible = false;
                        comInvoiceStatus.Visible = true;
                        comInvoiceStatus.SelectedIndex = 1;
                        comProductReport.Visible = false;
                        break;
                    }


                case "Customer Report":
                    {
                        //
                        guna2Panel1.Visible = false;
                        comCustomerReport.SelectedIndex = 0;
                        comCustomerReport.Visible = true;
                        comInvoiceStatus.Visible = false;
                        comProductReport.Visible = false;
                        break;
                    }

            }
        
        
        }

        private void dtFrom_ValueChanged(object sender, EventArgs e)
        {
            
        }

        bool validationDate()
        {

            if (dtTo.Value < dtFrom.Value)
            {
                MessageBox.Show("End date must not be later than the current time", "Should not be greater", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                dtTo.MaxDate = DateTime.Now;
                dtTo.Value = DateTime.Now;
                return true;
            }
            return false;
        }

        private void dtTo_ValueChanged(object sender, EventArgs e)
        {
            if (validationDate())
                return;

          
        }

        private void comProductReport_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comProductReport.Text == "All")
            {
                comCustomerReport.Visible = false;
                comFindBy.Text = "All";
                frmLaitTotalSales_Load(null, null);
               
                return;
            }
            string Type = "";

            if (comProductReport.Text == "Best Selling")
            {
                 Type = "DESC";
                 
                _dgvTotalSales = clsProducts.MoreProdutctsPuy(Type, dtFrom.Value.Date, dtTo.Value);
            }
            else
            {

                Type = "ASC";
                _dgvTotalSales = clsProducts.MoreProdutctsPuy(Type, dtFrom.Value.Date, dtTo.Value);

            }



            if (_dgvTotalSales.Rows.Count == 0)
            {
                Faladdata();
                dgvTotalSales.DataSource = null;
                dgvTotalSales.Rows.Clear(); // هذا اختياري بعد فك الربط

                return;
            }
            guna2lblRecordsCount.Text = dgvTotalSales.Rows.Count.ToString();

            if (_dgvTotalSales.Rows.Count > 0)
            {
               
                    //dataTable = _dgvTotalSales.DefaultView.ToTable(false, "ProductId", "Name", "TotalSold");

                    dgvTotalSales.DataSource = _dgvTotalSales;


                    dgvTotalSales.Columns[0].HeaderText = "Product  Id";
                    dgvTotalSales.Columns[0].Width = 180;

                    dgvTotalSales.Columns[1].HeaderText = "Product Name";
                    dgvTotalSales.Columns[1].Width = 300;

                    dgvTotalSales.Columns[2].HeaderText = "Total Quantity Sold";
                    dgvTotalSales.Columns[2].Width = 300;

                    dgvTotalSales.Columns[3].HeaderText = "Total Sales Excluding Tax";
                   dgvTotalSales.Columns[3].Width = 240;

                   dgvTotalSales.Columns[4].HeaderText = "Total Costs";
                    dgvTotalSales.Columns[4].Width = 240;
                    
                    dgvTotalSales.Columns[5].HeaderText = "Total Tax";
                    dgvTotalSales.Columns[5].Width = 240;
                    
                    dgvTotalSales.Columns[6].HeaderText = "Net Profit";
                    dgvTotalSales.Columns[6].Width = 240;


                   Rabah();
                


            }
            
        }

        string InvoiceStatus = "";
        private void comInvoiceStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comInvoiceStatus.Text == "All")
            {
                comFindBy.Text = "All";
               
                frmLaitTotalSales_Load(null, null);
                return;
            }
           
            switch (comInvoiceStatus.Text )
            {
                case "Paid":
                    InvoiceStatus= "1";
                    break;

                case "Partially Paid":
                    InvoiceStatus = "3";
                    break;

                case "Unpaid":
                    InvoiceStatus = "2";
                    break;
            }

            NetWithInvouceStatus();
           
        }


        void _Refresh()
        {

            TaxAmount = 0;
            taklaf = 0;
            TotalAmount = 0;
            total = 0;
            PaidAmount = 0;
            rabh = 0;
        }
        DataTable dataTable;
        void NetWithInvouceStatus()
        {
            _Refresh();

            _dgvTotalSales = clsInvoec.GetAllNetProfit(dtFrom.Value, dtTo.Value, InvoiceStatus);

            if (_dgvTotalSales.Rows.Count == 0)
            {
                Faladdata();
                dgvTotalSales.DataSource = null;
                dgvTotalSales.Rows.Clear(); // هذا اختياري بعد فك الربط

                return;
            }
            dgvTotalSales.DataSource = _dgvTotalSales;

            guna2lblRecordsCount.Text = dgvTotalSales.Rows.Count.ToString();

            if (_dgvTotalSales.Rows.Count > 0)
            {
                dgvTotalSales.Columns[0].HeaderText = "Invoice Id";
                dgvTotalSales.Columns[0].Width = 100;

                dgvTotalSales.Columns[1].HeaderText = "Customer Name";
                dgvTotalSales.Columns[1].Width = 200;

                dgvTotalSales.Columns[2].HeaderText = "Date";
                dgvTotalSales.Columns[2].Width = 120;

                dgvTotalSales.Columns[3].HeaderText = "Total Sales";
                dgvTotalSales.Columns[3].Width = 190;

                dgvTotalSales.Columns[4].HeaderText = "Total Costs";
                dgvTotalSales.Columns[4].Width = 200;

                dgvTotalSales.Columns[5].HeaderText = "Net Profit";
                dgvTotalSales.Columns[5].Width = 180;

                dgvTotalSales.Columns[6].HeaderText = "Status";
                dgvTotalSales.Columns[6].Width = 120;

                guna2lblRecordsCount.Text = dgvTotalSales.RowCount.ToString();
                RabahJastPay();

            }
        }//

        float RabhPaid = 0;
        void Rabah()
        {
            clsInvoec.GetAllLable(ref SubTotals, ref TaxAmounts, ref PaidAmounts, ref TotalAmounts, ref Taklafs, ref Rabhs, dtFrom.Value.Date, dtTo.Value.Date,ref RabhPaid);


            //if (Rabhs > 0)
            //{
                lblRabh.Text = Rabhs.ToString("0");
          //  }
            //else
            //    lblRabh.Text = "0";

           // if (RabhPaid > 0)
                lbRabhPaid.Text = RabhPaid.ToString();
           // lbRabhPaid.Text = RabhPaid.ToString("0");


            //else
            //    lbRabhPaid.Text = "0";

            lblTaklaf.Text = Taklafs.ToString("0");
            
            lbTotalAmount.Text = TotalAmounts.ToString("0");
            lbTaxAmount.Text = TaxAmounts.ToString("0");
            lblTotal.Text = SubTotals.ToString();
            lbPiadAmount.Text = PaidAmounts.ToString();
          //  lblTotal
          //  lbRabhPaid
        }

        void RabahJastPay()
        {

            clsInvoec.GetNetLable(ref SubTotals, ref TaxAmounts, ref PaidAmounts, ref TotalAmounts, ref Taklafs, ref Rabhs, dtFrom.Value.Date, dtTo.Value.Date, InvoiceStatus, ref RabhPaid);


            if (Rabhs > 0)
            {
                lblRabh.Text = Rabhs.ToString("0");
            }
            else
                lblRabh.Text = "0";


            if (RabhPaid > 0)
                lbRabhPaid.Text = RabhPaid.ToString();
            else
                lbRabhPaid.Text = "0";

            lblTaklaf.Text = Taklafs.ToString("0");
            
            lbTotalAmount.Text = TotalAmounts.ToString("0");
            lbTaxAmount.Text = TaxAmounts.ToString("0");
            lblTotal.Text = SubTotals.ToString();
            lbPiadAmount.Text = PaidAmounts.ToString();
            
        }

        private void GetMoreCustomerslatetoPuy()
        {
            
            _dgvTotalSales = clsCustomers.GetMoreCustomerslatetoPuy(dtFrom.Value.Date, dtTo.Value.Date);


            if (_dgvTotalSales.Rows.Count == 0)
            {
                Faladdata();
                dgvTotalSales.DataSource = null;
                dgvTotalSales.Rows.Clear(); // هذا اختياري بعد فك الربط

                return;
            }
       
            dgvTotalSales.DataSource = _dgvTotalSales;

            guna2lblRecordsCount.Text = dgvTotalSales.Rows.Count.ToString();
            if (_dgvTotalSales.Rows.Count > 0)
            {

                dgvTotalSales.Columns[0].HeaderText = "Customer Id";
                dgvTotalSales.Columns[0].Width = 120;

                dgvTotalSales.Columns[1].HeaderText = "Customer Name";
                dgvTotalSales.Columns[1].Width = 200;

                dgvTotalSales.Columns[2].HeaderText = "Date";
                dgvTotalSales.Columns[2].Width = 140;

                dgvTotalSales.Columns[3].HeaderText = "Phone";
                dgvTotalSales.Columns[3].Width = 130;

                dgvTotalSales.Columns[4].HeaderText = " Total Amount";
                dgvTotalSales.Columns[4].Width = 160;

                dgvTotalSales.Columns[5].HeaderText = "Amount Paid";
                dgvTotalSales.Columns[5].Width = 190;

                dgvTotalSales.Columns[6].HeaderText = "Remaining";
                dgvTotalSales.Columns[6].Width = 120;

                dgvTotalSales.Columns[7].HeaderText = "Status";
                dgvTotalSales.Columns[7].Width = 140;


               
            }
        }
        void Faladdata()
        {
           

            lblRabh.Text = "0";
            guna2lblRecordsCount.Text = "0";
            lblTaklaf.Text = "0";
            lbTotalAmount.Text = "0";
            lbTaxAmount.Text = "0";
            lblTotal.Text = "0";
            lbPiadAmount.Text = "0";
        }
        private void GetMoreCustomersPuy()
        {
            _dgvTotalSales = clsCustomers.GetMoreCustomersPuy(dtFrom.Value.Date, dtTo.Value.Date);


            if (_dgvTotalSales.Rows.Count == 0)
            {
                Faladdata();
                dgvTotalSales.DataSource = null;
                dgvTotalSales.Rows.Clear(); // هذا اختياري بعد فك الربط

                return;
            }



            guna2lblRecordsCount.Text = dgvTotalSales.Rows.Count.ToString();

            if (_dgvTotalSales.Rows.Count > 0)
            {
                //dataTable = _dgvTotalSales.DefaultView.ToTable(false, "CustomerId", "name", "Phone", "InvoiceCount",
            //"TotalPurchases");
                dgvTotalSales.DataSource = _dgvTotalSales;

                dgvTotalSales.Columns[0].HeaderText = "Customer Id";
                dgvTotalSales.Columns[0].Width = 140;

                dgvTotalSales.Columns[1].HeaderText = "Customer Name";
                dgvTotalSales.Columns[1].Width = 250;

                dgvTotalSales.Columns[2].HeaderText = "Number of Invoices";
                dgvTotalSales.Columns[2].Width = 160;

                dgvTotalSales.Columns[3].HeaderText = "Total Paid";
                dgvTotalSales.Columns[3].Width = 190;

                dgvTotalSales.Columns[4].HeaderText = "Total Purchases";
                dgvTotalSales.Columns[4].Width = 220;
                
                dgvTotalSales.Columns[5].HeaderText = "Total Costs";
                dgvTotalSales.Columns[5].Width = 220; 
                
                dgvTotalSales.Columns[6].HeaderText = "Net Profit";
                dgvTotalSales.Columns[6].Width = 220;



            }
         




        }
       
       
        private void butGenrateReport_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void lbRabhPaid_Click(object sender, EventArgs e)
        {

        }

        private void dgvTotalSales_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        decimal TaxAmount = 0;//قيمة الضريبة
        decimal PaidAmount = 0;//قيمة المصروفات 
        decimal TotalAmount = 0;//الإجمالي مع الضريبة


        private void guna2Button2_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = PrintDocument;

            // إذا اختار المستخدم طابعة وطباعة، سيتم الطباعة
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                PrintDocument.Print();  // الطباعة
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
