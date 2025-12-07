using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FatoraX.InvoiceDetails;
using FX_Buisness;

namespace FatoraX.Invoices
{
    public partial class frmLasteInvoices : Form
    {
       
        public frmLasteInvoices()
        {
            InitializeComponent();
        }
        DataTable _dtAllinvoices;
        private void frmLasteInvoices_Load(object sender, EventArgs e)
        {



            _dtAllinvoices = clsInvoec.GetAllInvoices();
            gudgvInvoces.DataSource = _dtAllinvoices;

            guna2lblRecordsCount.Text = gudgvInvoces.Rows.Count.ToString();
            if (gudgvInvoces.Rows.Count > 0)
            {

                gudgvInvoces.Columns[0].HeaderText = "Invoice Id";
                gudgvInvoces.Columns[0].Width = 120;

                gudgvInvoces.Columns[1].HeaderText = "Customer Name";
                gudgvInvoces.Columns[1].Width = 120;

                gudgvInvoces.Columns[2].HeaderText = "Date";
                gudgvInvoces.Columns[2].Width = 120;

                gudgvInvoces.Columns[3].HeaderText = "Tax Rate";                          
                gudgvInvoces.Columns[3].Width = 120;

                gudgvInvoces.Columns[4].HeaderText = "Tax Amount";
                gudgvInvoces.Columns[4].Width = 120;

                gudgvInvoces.Columns[5].HeaderText = "Total";
                gudgvInvoces.Columns[5].Width = 120;

                gudgvInvoces.Columns[6].HeaderText = "Amount Paid";
                gudgvInvoces.Columns[6].Width = 120;

                gudgvInvoces.Columns[7].HeaderText = "Payment Status";
                gudgvInvoces.Columns[7].Width = 120;

                gudgvInvoces.Columns[8].HeaderText = "Notes";
                gudgvInvoces.Columns[8].Width = 120;

                gudgvInvoces.Columns[9].HeaderText = "Username";
                gudgvInvoces.Columns[9].Width = 140;
            }
        }

        private void guna2txtName_KeyPress(object sender, KeyPressEventArgs e)
        {

           
        }

        private void guna2putClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2txtName_TextChanged_2(object sender, EventArgs e)
        {
            string CloumnFilter = "";

            switch (guna2cbFilterBy.Text)
            {
                case "Customer Name":
                    {
                        CloumnFilter = "Name";
                        break;
                    }
                case "Username":
                    {

                        CloumnFilter = "Username";
                        break;
                    }
                case "Invoice Id":
                    {

                        CloumnFilter = "InvoiceId";
                        break;
                    }
                default:
                    CloumnFilter = "Undefined";
                    break;
            }

            if (CloumnFilter == "Undefined" || guna2txtName.Text == "")
            {
                _dtAllinvoices.DefaultView.RowFilter = "";
                guna2lblRecordsCount.Text = gudgvInvoces.Rows.Count.ToString();
                return;
            }

            if (CloumnFilter == "InvoiceId")
            
                _dtAllinvoices.DefaultView.RowFilter = string.Format("[{0}] = {1}", CloumnFilter, guna2txtName.Text);
            else
                _dtAllinvoices.DefaultView.RowFilter = string.Format("[{0}] Like '{1}%'", CloumnFilter, guna2txtName.Text);


            guna2lblRecordsCount.Text = gudgvInvoces.Rows.Count.ToString();
        }

        private void butAddinvoceies_Click_1(object sender, EventArgs e)
        {
            frmAddUpdateInvoiceDetails   frm = new frmAddUpdateInvoiceDetails();
            frm.ShowDialog();
            frmLasteInvoices_Load(null, null);
        }

        private void guna2putClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        string InvoiceStatus = "";
        private void comInvoiceStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comInvoiceStatus.Text == "All")
            {
               
                comInvoiceStatus.Visible = true ;
                frmLasteInvoices_Load(null, null);
                return;
            }
            _dtAllinvoices.DefaultView.RowFilter = string.Format("[{0}] Like '{1}%'", "paymentstatus", comInvoiceStatus.Text);


            guna2lblRecordsCount.Text = gudgvInvoces.Rows.Count.ToString();
        }

        private void guna2cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(guna2cbFilterBy.Text == "Invoice Status")
            {

                guna2txtName.Visible = false;
                comInvoiceStatus.Visible = true;
                comInvoiceStatus.SelectedIndex = 0;
             
                return;
            }
            comInvoiceStatus.Visible = false;
            if (guna2cbFilterBy.Text == "Undefined")
            {
                guna2txtName.Visible = false;
                comInvoiceStatus.Visible = false;
            }
            else
            {
                guna2txtName.Visible =true;
                guna2txtName.Enabled = true;
                guna2txtName.Text = "";
            }
            frmLasteInvoices_Load(null, null);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2txtName_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (guna2cbFilterBy.Text == "Username" || guna2cbFilterBy.Text == "Customer Name")
                e.Handled = char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back;
            else
                e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back;
        }
    }
}
