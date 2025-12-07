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
using FatoraX_DataAccess;

namespace FatoraX.InvoiceDetails
{
    public partial class frmAddUpdateInvoiceDetails : Form
    {
        enum enMode { AddNew = 0, Update = 1 }
        enMode Mode;
        private clsInvoiceDetails _InvoiceDetails;
        clsInvoec _Invoice;
        private int _InvoiceDetailsID;
        private int _InvoiceID;
        int projId = 0;
        int procost = 0;
        clsProducts products;
        public frmAddUpdateInvoiceDetails()
        {
            InitializeComponent();
            Mode = enMode.AddNew;
            printDocument.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);
        }
        string productName = "";
        decimal Quantity = 0;
        decimal UnitPrice = 0;
        decimal total = 0;
        decimal Amout = 0;
        public frmAddUpdateInvoiceDetails(int InvoiceDetailsID)
        {
            InitializeComponent();
            Mode = enMode.Update;
            _InvoiceID = InvoiceDetailsID;
            printDocument.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);
        }



        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {


            Font titleFont = new Font("Tahoma", 16, FontStyle.Bold);
            Font headerFont = new Font("Tahoma", 10, FontStyle.Bold);
            Font cellFont = new Font("Tahoma", 10);
            Pen pen = new Pen(Color.Black, 1);

            StringFormat centerFormat = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            StringFormat rtlFormat = new StringFormat
            {
                Alignment = StringAlignment.Far,
                FormatFlags = StringFormatFlags.DirectionRightToLeft
            };

            int startX = e.MarginBounds.Left;
            int startY = e.MarginBounds.Top;
            int tableWidth = e.MarginBounds.Width;
            int rowHeight = 30;

            // ===== 1. العنوان =====
            e.Graphics.DrawString("Purchase invoice", titleFont, Brushes.Black, new RectangleF(startX, startY, tableWidth, 40), centerFormat);

            // ===== 2. التاريخ =====
            startY += 45;
            e.Graphics.DrawString(
                "Date: " + DateTime.Now.ToString("yyyy/MM/dd"),
                cellFont,
                Brushes.Black,
                new RectangleF(e.MarginBounds.Left, startY, e.MarginBounds.Width, cellFont.Height),
                new StringFormat()
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center,
                    FormatFlags = StringFormatFlags.DirectionRightToLeft
                }
            );
            startY += 30;

            // ===== 3. رؤوس الأعمدة =====
            int colCount = dataGridView1.Columns.Count;
            int colWidth = tableWidth / colCount;
            int currentX = startX;

            for (int i = colCount - 1; i >= 0; i--) // من اليمين لليسار
            {
                string headerText = dataGridView1.Columns[i].HeaderText;
                Rectangle rect = new Rectangle(currentX, startY, colWidth, rowHeight);
                e.Graphics.FillRectangle(Brushes.LightGray, rect);
                e.Graphics.DrawRectangle(pen, rect);
                e.Graphics.DrawString(headerText, headerFont, Brushes.Black, rect, centerFormat);
                currentX += colWidth;
            }

            // ===== 4. صفوف البيانات =====
            startY += rowHeight;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;

                currentX = startX;
                for (int i = colCount - 1; i >= 0; i--)
                {
                    string cellValue = row.Cells[i].Value?.ToString() ?? "";
                    Rectangle rect = new Rectangle(currentX, startY, colWidth, rowHeight);
                    e.Graphics.DrawRectangle(pen, rect);
                    e.Graphics.DrawString(cellValue, cellFont, Brushes.Black, rect, centerFormat);
                    currentX += colWidth;
                }

                startY += rowHeight;
            }

            // ===== الإجمالي =====
            startY += 30; // يمكنك تعديل القيمة هنا حسب المسافة المطلوبة
            RectangleF totalRect = new RectangleF(e.MarginBounds.Left, startY, e.MarginBounds.Width, rowHeight);

            StringFormat totalFormat = new StringFormat
            {
                Alignment = StringAlignment.Far, // محاذاة إلى اليمين
                LineAlignment = StringAlignment.Center,
                FormatFlags = StringFormatFlags.DirectionRightToLeft // من اليمين إلى اليسار
            };

            string totalText = "Total: " + txtTotal.Text;
            e.Graphics.DrawString(totalText, cellFont, Brushes.Black, totalRect, totalFormat);
            // ===== 5. توقيع (اختياري) =====
            startY += 30;
            e.Graphics.DrawString("Signature: ________________", cellFont, Brushes.Black, new PointF(startX, startY));




        }



        private PrintDocument printDocument = new PrintDocument();
        private void _FillProductIdInComoboBox()
        {
            DataTable daAllCustmer = clsCustomers.GetAllCustomers();
            DataTable dtProduct = clsProducts.GetAllProductSCok();

            foreach (DataRow row in dtProduct.Rows)
            {
                cmbProduct.Items.Add(row["Name"]);
            }

            foreach (DataRow row in daAllCustmer.Rows)
            {
                cmCustomerID.Items.Add(row["Name"]);
            }
        }

        private void _ResetDefualtValues()
        {
            if (Mode == enMode.AddNew)
            {
                lblTitl.Text = "Add Invoice";
                this.Text = lblTitl.Text;
                _Invoice = new clsInvoec();
            }
            else
            {
                lblTitl.Text = "Edit Invoice";
                this.Text = lblTitl.Text;
            }
            chTaxPercent.Checked = true;
            dtDate.Text = clsFormat.DateToShort(DateTime.Now);
            txtPaidAmount.Text = "";
            txtQuantity.Text = "";
            txtTotal.Text = "";
            txtUnitPrice.Text = "";
            //cbInvoiceId.Text = "";
            cmbProduct.Text = "";
        }

        private void _LoadData()
        {
            _Invoice = clsInvoec.Find(_InvoiceID);

            if (_Invoice == null)
            {
                MessageBox.Show("No invoice details found for the ID" + _InvoiceID, "Invoice details not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }



            txtPaidAmount.Text = _Invoice.PaidAmount.ToString();
            txtQuantity.Text = _Invoice.Taxpercent.ToString();
            txtTotal.Text = _Invoice.SubTotal.ToString();
            txtNotes.Text = _Invoice.Notes.ToString();
            dtDate.Text = clsFormat.DateToShort(_Invoice.invoiceDate);
            InvoiceId.Text = _Invoice.InvoiceId.ToString();
            cmCustomerID.Text = _Invoice.SelectCustomerInfo.ToString();

        }



        void FullProduct()
        {
            dataGridView1.Columns[0].HeaderText = "Product Name";
            dataGridView1.Columns[0].Width = 200;

            dataGridView1.Columns[1].HeaderText = "Quantity Sold";
            dataGridView1.Columns[1].Width = 200;

            dataGridView1.Columns[2].HeaderText = "Unit Price";
            dataGridView1.Columns[2].Width = 200;

            dataGridView1.Columns[3].HeaderText = "Total";
            dataGridView1.Columns[3].Width = 200;
        }

        private void frmAddUpdateInvoiceDetails_Load(object sender, EventArgs e)
        {


            SetupDataGridView();
            _FillProductIdInComoboBox();
            _ResetDefualtValues();
            if (Mode == enMode.Update)
                _LoadData();
        }

        private void txtUnitPrice_TextChanged(object sender, EventArgs e)
        {

        }

        decimal SubTotal, TaxAmount, TaxPercents;
        decimal SumTotal;
        decimal AgriAnsr;
        decimal SubTotald = 0;
        decimal TaxAmountd = 0;

        int isclrea = 0;
        int AddFirst = 0;
        bool isBackspace = false;
        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(txtQuantity.Text, out int newQuantity))
            {
                if (procost < newQuantity)
                {
                    isBackspace = true;
                    MessageBox.Show("The quantity is insufficient for your product only ["  + procost + "]"," The quantity is insufficient ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    butAddd.Enabled = false;


                     
                    txtTotal.Text = SumTotal.ToString();
                    txtQuantity .Text ="";
                    isclrea = 1;
                    //  butSave.Enabled = false;
                    return;
                }

                else
                {
                    butAddd.Enabled = true;
                   // butSave.Enabled = true;
                   
                }
            }
            if (TaxPercent.Text == "0")
            { 
                TaxPercent.Text = "0";
                TaxAmount = 0;
                TaxPercents = 0;
            }
            else
            {
                //TaxAmount = (TaxPercents / 100) * SubTotal;
            }
                if(TaxPercent.Enabled == false)
            { TaxPercent.Enabled = true ; }

            if (isclrea == 1)
            {
                isclrea = 0;
                txtQuantity.Text = "";
                return;
            }
            if (isBackspace == true)
            {
                return;
            }
                if (Mode == enMode.Update)
                {
                    if (txtQuantity.Text == "")
                    {
                        txtQuantity.Text = "0";

                        return;
                    }
                    if (txtUnitPrice.Text.Trim() != "")
                    {
                        Quantity = Convert.ToDecimal(txtQuantity.Text);
                        UnitPrice = Convert.ToDecimal(txtUnitPrice.Text);


                        total = total + Quantity * UnitPrice;

                        SumTotal += total;
                        txtTotal.Text = total.ToString();
                    }


                }
                else
                {
                    if (chTaxPercent.Checked)
                    {
                        TaxPercents = Convert.ToDecimal(TaxPercent.Text);
                  
                    }
                    else
                    {
                        TaxPercents = 0;

                    }
                    UnitPrice = 0;
                    Quantity = 0;

                    bool isQuantityValid = decimal.TryParse(txtQuantity.Text.Trim(), out Quantity);
                    bool isUnitPriceValid = decimal.TryParse(txtUnitPrice.Text.Trim(), out UnitPrice);
                total = 0;
                TaxAmount = 0;
                SubTotal = 0;

                if (isQuantityValid && isUnitPriceValid)
                {




                    //    isclrea = 0;

                    SubTotal = Quantity * UnitPrice;

                  //  total = SubTotal;
                    if (chTaxPercent.Checked)
                    {

                        TaxAmount = (TaxPercents / 100) * SubTotal;

                      total = TaxAmount + SubTotal;
                    }
                    else
                    {
                        total = SubTotal;
                    }


                   

                    if(SumTotal != 0)
                    {
                        total += SumTotal;
                     //    SumTotal = total;
                    }
                        //SumTotal += total;
                
                   
                    txtTotal.Text = total.ToString();



                }
                }
            

        }

        private void butClose_Click(object sender, EventArgs e)
        {

            this.Close();
        }



        private void PaymentStatus()
        {
            if (txtPaidAmount.Text == "")
            {
                txtPaidAmount.Text = "0";
                _Invoice.paymentstatus = 2;
                return;
            }

            if (Convert.ToSingle(txtPaidAmount.Text) >= Convert.ToSingle(txtTotal.Text))
            {
                _Invoice.paymentstatus = 1;
            }
            else if (Convert.ToSingle(txtPaidAmount.Text) <= Convert.ToSingle(txtTotal.Text) && Convert.ToSingle(txtPaidAmount.Text) != 0)
                _Invoice.paymentstatus = 3;
            else
                _Invoice.paymentstatus = 2;
        }

        decimal Amount = 0;
       
        decimal RemainingAmount = 0;
        private void SaveInvoiceHeader()
        {


            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fields are incorrect. Please hover over the red icon to view the error details", "Verification Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (TaxPercent.Text != "")
            {
                _Invoice.Taxpercent = Convert.ToSingle(TaxPercent.Text);
            }
            else
            {
                _Invoice.Taxpercent = 0;
            }
            _Invoice.SubTotal = Convert.ToSingle(SubTotald);
            
            _Invoice.TaxAmount = Convert.ToSingle(TaxAmountd);

            _Invoice.TotalAmount = Convert.ToSingle(Amount);

            _Invoice.IsTaxIncluded = chTaxPercent.Checked;
            _Invoice.UserId = clsGlobal.CurrentUser.UserId;
            if (txtNotes.Text == "")
                _Invoice.Notes = "";
            else
                _Invoice.Notes = txtNotes.Text;

            _Invoice.invoiceDate = DateTime.Now;
          
            _Invoice.CustomerId = clsCustomers.Find(cmCustomerID.Text).CustomerId;
            if (txtPaidAmount.Text != "")
                _Invoice.PaidAmount = Convert.ToSingle(txtPaidAmount.Text);
            else
                _Invoice.PaidAmount = 0;
            PaymentStatus();



            if (!_Invoice.Save())
            {
                
                
                MessageBox.Show("Error: The invoice was not saved successfully", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _InvoiceID = _Invoice.InvoiceId;
            if (SaveInvoiceDetail())
            {

                Mode = enMode.Update;
                lblTitl.Text = "Edit Invoice";
                this.Text = lblTitl.Text;
                InvoiceId.Text = _Invoice.InvoiceId.ToString();
                MessageBox.Show("The invoice has been saved successfully", "saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error: The invoice was not saved successfully", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            guna2Button1.Enabled = true;
        }
        private void SetupDataGridView()
        {



            dataGridView1.ColumnCount = 4;
            dataGridView1.Columns[0].Name = "ProductId";
            dataGridView1.Columns[0].Width = 190;
            dataGridView1.Columns[1].Name = "Quantity";
            dataGridView1.Columns[1].Width = 220;
            dataGridView1.Columns[2].Name = "Price";
            dataGridView1.Columns[2].Width = 220;
            dataGridView1.Columns[3].Name = "Total";
            dataGridView1.Columns[3].Width = 220;
        }
        //clsInvoiceDetails ClsInvoiceDetails = new clsInvoiceDetails();
        private bool SaveInvoiceDetail()
        {
            bool Result = true;
            _InvoiceDetails = new clsInvoiceDetails();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                _InvoiceDetails = new clsInvoiceDetails();
                if (row.IsNewRow) continue;


                int quantity = 0;
                var quantityValue = row.Cells["Quantity"].Value?.ToString().Trim();

                if (!int.TryParse(quantityValue, out quantity))
                {
                    // إما تجاهل الصف أو تسجيل خطأ أو إعطاء قيمة افتراضية
                    quantity = 0; // أو return false;
                }

                string productname = "";
                productname = row.Cells["ProductId"].Value?.ToString().Trim();
                int _ProductId = 0;
                _ProductId = clsProducts.Find(productname).ProductId;


                decimal price = Convert.ToDecimal(row.Cells["Price"].Value);
                decimal total = Convert.ToDecimal(row.Cells["Total"].Value);

                _InvoiceDetails.Date = DateTime.Now;
                _InvoiceDetails.InvoiceId = _InvoiceID;
                _InvoiceDetails.ProductId = _ProductId;


                _InvoiceDetails.UnitPrice = price;
                _InvoiceDetails.Total = total;
                _InvoiceDetails.Quantity = quantity;

                if (!_InvoiceDetails.Save())
                {
                    Result = false;
                    return Result;
                }
                else
                {
                    Result = true;
                }
            }

            return Result;

        }
        private void butSave_Click(object sender, EventArgs e)
        {
           

            SaveInvoiceHeader();


        }

        private void cbProductId_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(cmbProduct.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(cmbProduct, "Product ID cannot be empty");
            }
            else
            {
                errorProvider1.SetError(cmbProduct, null);
            }
        }
        int Camaia = 0;
        private void txtQuantity_Validating(object sender, CancelEventArgs e)
        {
           
        }

        private void txtUnitPrice_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUnitPrice.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtUnitPrice, "Unit price cannot be empty");
            }
            else
            {
                errorProvider1.SetError(txtUnitPrice, null);
            }
        }

        private void txtPaidAmount_Validating(object sender, CancelEventArgs e)
        {

        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

           
            


        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        int count = 0;
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (TaxPercent.Text == "")
            {
                if (chTaxPercent.Checked)
                {

                    chTaxPercent.Enabled = true;
                }
                else
                {
                    TaxPercent.Enabled = false;
                }
                return;
            }
            if (Add == false)
                return;
           
                
            decimal TaxAmount  = (TaxPercents / 100) * SubTotal;
            decimal currentTotal = 0;

            // نحاول تحويل القيمة النصية إلى رقم بدون رمي خطأ
            decimal.TryParse(txtTotal.Text, out currentTotal);

            if (chTaxPercent.Checked)
            {
                
               
                // إذا تم تحديد الضريبة نضيفها إلى الإجمالي
                currentTotal += TaxAmount;
                TaxPercent.Enabled = true;
            }
            else
            {
                
                // إذا تم إلغاء التحديد ننقص الضريبة من الإجمالي
                currentTotal -= TaxAmount;
                TaxPercent.Enabled = false;
            }

            // تحديث قيمة المجموع الكلي
            txtTotal.Text = currentTotal.ToString("0.00");
            
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument;

            // إذا اختار المستخدم طابعة وطباعة، سيتم الطباعة
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();  // الطباعة
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }



        bool isTrue = true;
       bool Add = true;
        private void butAddd_Click(object sender, EventArgs e)
        {
            if (cmbProduct.SelectedItem == null || string.IsNullOrWhiteSpace(txtQuantity.Text) || string.IsNullOrWhiteSpace(txtUnitPrice.Text))
            {
                MessageBox.Show("Please enter all the required data");
                return;
            }

            
        
            productName = cmbProduct.Text;
            Quantity = int.Parse(txtQuantity.Text);
            UnitPrice = decimal.Parse(txtUnitPrice.Text);

            Amount = decimal.Parse(txtTotal.Text);
            //total = Quantity * UnitPrice;

            FullProduct();
            dataGridView1.Rows.Add(productName, Quantity, UnitPrice, SubTotal);

            if (chTaxPercent.Checked)
            {

                TaxAmountd += TaxAmount;
            }
                SubTotald += SubTotal;
            int  TTT  = int.Parse(txtQuantity.Text); 
            int h = products.Stock  - TTT;
            
            if(clsProducts._UpdateStock(products.ProductId, h))
            {

            }
            butSave.Enabled = true;
            isclrea = 1;

            
            txtQuantity.Clear();
           
            
            Add = false;

            txtQuantity.Enabled = false;

            //TaxPercent.Enabled = false;
            SumTotal = total;

        }

        private void TaxPercent_TextChanged(object sender, EventArgs e)
        {
            
                
            if(TaxPercent.Text != "")
            {
                TaxPercents = decimal.Parse(TaxPercent.Text);
            }
            
            if (Add == false)
                return;

           
            if (TaxPercent.Text == "")
            {
                return;
            }
            if (chTaxPercent.Checked)
            {
                TaxPercents = Convert.ToDecimal(TaxPercent.Text);
            }
            else
            {
                TaxPercents = 1;

            }
            UnitPrice = 0;
            Quantity = 0;

            bool isQuantityValid = decimal.TryParse(txtQuantity.Text.Trim(), out Quantity);
            bool isUnitPriceValid = decimal.TryParse(txtUnitPrice.Text.Trim(), out UnitPrice);
            total = 0;
            TaxAmount = 0;
            SubTotal = 0;

            if (isQuantityValid && isUnitPriceValid)
            {




                //    isclrea = 0;

                SubTotal = Quantity * UnitPrice;

                //  total = SubTotal;
                if (chTaxPercent.Checked)
                {

                    TaxAmount = (TaxPercents / 100) * SubTotal;

                    total = TaxAmount + SubTotal;
                }



                if (SumTotal != 0)
                {
                    total += SumTotal;
                    //    SumTotal = total;
                }


                txtTotal.Text = total.ToString();



            }
        }

        private void guna2GroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void cmbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmCustomerID_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtPaidAmount_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void InvoiceId_Click(object sender, EventArgs e)
        {

        }
       
        private void cmbProduct_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            products = clsProducts.Find(cmbProduct.Text);
            projId = products.ProductId;
            procost = products.Stock;
            if (products != null)
                txtUnitPrice.Text = products.Price.ToString();
            isclrea = 0;
            Add = true;
            // txtQuantity.Clear();

            txtQuantity.Enabled = true;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtQuantity_KeyDown(object sender, KeyEventArgs e)
        {
             
            if(isclrea ==1)
            {
                return;
            }

            if (e.KeyCode == Keys.Back)
            {
                int pos = txtQuantity.SelectionStart;
                isBackspace = true;
                // التأكد من وجود شيء للحذف ومكان المؤشر يسمح بذلك
                if (pos > 0 && txtQuantity.Text.Length > 0)
                {
                    string originalText = txtQuantity.Text;

                    // هذا هو النص المتوقع بعد الحذف
                    string newText = originalText.Remove(pos - 1, 1);

                    // هنا تستخدمي newText كما تشائين
                    if (newText != "")
                    {
                        // مثال: تحويله إلى عدد
                        if (int.TryParse(newText, out int newQuantity))
                        {
                            

                            Quantity = newQuantity;
                            SubTotal = Quantity * UnitPrice;
                            ////SubTotald -= SubTotal;
                            TaxAmount = (TaxPercents / 100) * SubTotal;

                         
                            total = SubTotal;
                            if (chTaxPercent.Checked)
                            {

                                TaxAmount = (TaxPercents / 100) * SubTotal;

                                TaxAmountd += TaxAmount;

                                total = TaxAmount + SubTotal;

                            }
                            total = total + SumTotal;
                            AgriAnsr = total;
                            if(total < 0)
                                
                                txtTotal.Text ="0";
                            else   
                            txtTotal.Text = total.ToString();
                            
                        }
                    }
                    else
                    {

                        
                        if(SumTotal <0)
                            txtTotal.Text ="0"; 
                        else
                        txtTotal.Text = SumTotal.ToString();
                    }
                }
            }
            else
            {
                isBackspace = false;
            }
        }

        private void cmCustomerID_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cmCustomerID.Text != "")
            {
                cmCustomerID.Enabled = false;
            }
        }

        private void txtQuantity_ImeModeChanged(object sender, EventArgs e)
        {

        }

        private void TaxPercent_KeyDown(object sender, KeyEventArgs e)
        {
            if (TaxPercent.Text == "" || txtQuantity.Text == "")
                return;
            decimal TaxAmount1 = (TaxPercents / 100) * SubTotal;
            decimal currentTotal1 = Convert.ToDecimal(txtTotal.Text);
            currentTotal1 -= TaxAmount1;

            txtTotal.Text = currentTotal1.ToString("0.00");
        }

        private void txtPaidAmount_Validating_1(object sender, CancelEventArgs e)
        {
            //{
            //    if (string.IsNullOrEmpty(txtPaidAmount.Text))
            //    {
            //        e.Cancel = true;
            //        errorProvider1.SetError(txtPaidAmount, "المبلغ المدفوع لا يمكن أن تكون فارغة");
            //    }
            //    else
            //    {
            //        errorProvider1.SetError(txtPaidAmount, null);
            //    }
        }

        private void cmCustomerID_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(cmCustomerID.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(cmCustomerID, "Customer name cannot be empt");
            }
            else
            {
                errorProvider1.SetError(cmCustomerID, null);
            }
        }
    }
}
