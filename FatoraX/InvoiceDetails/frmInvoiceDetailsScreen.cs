using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FX_Buisness;
using Guna.UI2.WinForms;

namespace FatoraX.InvoiceDetails
{
    public partial class frmInvoiceDetailsScreen : Form
    {
        private DataTable _dtAllInvoiceDetails;
        public frmInvoiceDetailsScreen()
        {
            InitializeComponent();
        }

        void LoadData()
        {
            _dtAllInvoiceDetails = clsInvoiceDetails.GetAllInvoiceDetail();
            dgvInvoiceDetails.DataSource = _dtAllInvoiceDetails;
            lblRecordsCount.Text = dgvInvoiceDetails.Rows.Count.ToString();
            cbFilterBy.SelectedIndex = 0;

            if(dgvInvoiceDetails.Rows.Count > 0)
            {
                
                dgvInvoiceDetails.Columns[0].HeaderText = "Details Id";

                dgvInvoiceDetails.Columns[1].HeaderText = "Invoice Id";

                dgvInvoiceDetails.Columns[2].HeaderText = "Product Id";

                dgvInvoiceDetails.Columns[3].HeaderText = "Quantity";

                dgvInvoiceDetails.Columns[4].HeaderText = " Unit Price";

                dgvInvoiceDetails.Columns[5].HeaderText = "Total";
                dgvInvoiceDetails.Columns[6].HeaderText = "Date";
            }
            
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void frmInvoiceDetailsScreen_Load(object sender, EventArgs e)
        {
            dgvInvoiceDetails.AutoGenerateColumns = true;
            dgvInvoiceDetails.ColumnHeadersVisible = true;
            dgvInvoiceDetails.EnableHeadersVisualStyles = false;
            LoadData();
        }

        private void showToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

        private void editToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAddUpdateInvoiceDetails frm = new frmAddUpdateInvoiceDetails((int)dgvInvoiceDetails.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            frmInvoiceDetailsScreen_Load(null, null);
        }

        private void deleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete the invoice details?", "Important Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int InvoiceDetailID = (int)dgvInvoiceDetails.CurrentRow.Cells[0].Value;
                if (clsInvoiceDetails.DeleteInvoiceDetail(InvoiceDetailID))
                {
                    MessageBox.Show("Invoice details were deleted successfully", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmInvoiceDetailsScreen_Load(null, null);
                }
                else
                    MessageBox.Show(" Cannot delete the invoice details because they are linked to other data.", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void butAddUser_Click(object sender, EventArgs e)
        {
            //frmAddUpdateInvoiceDetails frm = new frmAddUpdateInvoiceDetails();
            //frm.ShowDialog();
            //frmInvoiceDetailsScreen_Load(null, null);
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";

            switch (cbFilterBy.Text)
            {
                case "Details Id":
                    FilterColumn = "DetailId";
                    break;

                case "Invoice Id":
                    FilterColumn = "InvoiceId";
                    break;

                case "Product Id":
                    FilterColumn = "ProductId";
                    break;

                case "Quantity":
                    FilterColumn = "Quantity";
                    break;

                case "Unit Price":
                    FilterColumn = "UnitPrice";
                    break;

                case "Total":
                    FilterColumn = "Total";
                    break;

                case "Amount Paid":
                    FilterColumn = "PaidAmount";
                    break;

                

                default:
                    FilterColumn = "None";
                    break;
            }

            if (txtFilterValue.Text.Trim() == "" | FilterColumn == "None")
            {
                _dtAllInvoiceDetails.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvInvoiceDetails.Rows.Count.ToString();
                return;
            }

           
                _dtAllInvoiceDetails.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
           
            lblRecordsCount.Text = dgvInvoiceDetails.Rows.Count.ToString();
        }

        private void butClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2ContextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {


        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            frmAddUpdateInvoiceDetails frm = new frmAddUpdateInvoiceDetails();
            frm.ShowDialog();
            frmInvoiceDetailsScreen_Load(null, null);
        }

        private void dgvInvoiceDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
