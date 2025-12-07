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

namespace FatoraX.Products
{
    public partial class frmProductList : Form
    {
        public frmProductList()
        {
            InitializeComponent();
        }

        private static DataTable _dtAllProducts;

        private void frmProductList_Load(object sender, EventArgs e)
        {
            _dtAllProducts = clsProducts.GetAllProducts();
            guna2DataGridView1.DataSource = _dtAllProducts;
            gcFilterBy.SelectedIndex = 0;
            guna2lblRecordsCount.Text = guna2DataGridView1.Rows.Count.ToString();

            if (guna2DataGridView1.Rows.Count > 0)
            {
                حذفالمنتجToolStripMenuItem.Enabled = true;
                تعديلالمنتجToolStripMenuItem.Enabled = true;
                إضافةمنتجToolStripMenuItem.Enabled = true;
                معلوماتالمنتجToolStripMenuItem.Enabled = true;

                guna2DataGridView1.Columns[0].HeaderText = "Product Id"; 
                guna2DataGridView1.Columns[0].Width = 100;

                guna2DataGridView1.Columns[1].HeaderText = "Name";
                guna2DataGridView1.Columns[1].Width = 100;

                guna2DataGridView1.Columns[2].HeaderText = "Price";
                guna2DataGridView1.Columns[2].Width = 100;

                guna2DataGridView1.Columns[3].HeaderText = "Cost";
                guna2DataGridView1.Columns[3].Width = 100;

                guna2DataGridView1.Columns[4].HeaderText = "Stock";
                guna2DataGridView1.Columns[4].Width = 100;
            }
            else
            {
                حذفالمنتجToolStripMenuItem.Enabled = false;
                تعديلالمنتجToolStripMenuItem.Enabled = false;
                إضافةمنتجToolStripMenuItem.Enabled = false;
                معلوماتالمنتجToolStripMenuItem.Enabled = false;
            }
        }

        private void guna2putClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (gcFilterBy.Text == "Product Id" || gcFilterBy.Text== "Stock" || gcFilterBy.Text== "Cost" || gcFilterBy.Text== "Price")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void gtxtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";

            switch (gcFilterBy.Text)
            {


                case "Product Id":
                    FilterColumn = "ProductId";
                    break;

                case "Stock":
                    FilterColumn = "Stock";
                    break;

                case "Cost":
                    FilterColumn = "Cost";
                    break;

                case "Price":
                    FilterColumn = "Price";
                    break;

                case "Name":
                    FilterColumn = "Name";
                    break;


                default:
                    FilterColumn = "Undefined";
                    break;

            }


            if (gtxtFilterValue.Text.Trim() == "" || FilterColumn == "Undefined")
            {
                _dtAllProducts.DefaultView.RowFilter = "";
                guna2lblRecordsCount.Text = guna2DataGridView1.Rows.Count.ToString();
                return;
            }


            if (FilterColumn == "Name")

                _dtAllProducts.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, gtxtFilterValue.Text.Trim());
            else
                _dtAllProducts.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, gtxtFilterValue.Text.Trim());

            guna2lblRecordsCount.Text = guna2DataGridView1.Rows.Count.ToString();

        }

        private void gcFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void تعديلالمنتجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fromAdd_EditProduct frm = new fromAdd_EditProduct((int)guna2DataGridView1.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            frmProductList_Load(null, null);

        }

        private void إضافةمنتجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fromAdd_EditProduct frm = new fromAdd_EditProduct();
            frm.ShowDialog();
            frmProductList_Load(null, null);
        }

        private void معلوماتالمنتجToolStripMenuItem_Click(object sender, EventArgs e)
        {
           

            if (MessageBox.Show("Are you sure you want to delete the product?" + "[" + guna2DataGridView1.CurrentRow.Cells[0].Value + "]", "Confirm Deletion", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)

            {


                if (clsProducts.DeleteProducts((int)guna2DataGridView1.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("The product has been deleted successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmProductList_Load(null, null);
                }

                else
                    MessageBox.Show("The product could not be deleted because it contains associated data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void حذفالمنتجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowProductInfo frm = new frmShowProductInfo((int)guna2DataGridView1.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

         

        private void guna2ContextMenuStrip1_Opening(object sender, CancelEventArgs e)
        { 
        }

        private void butAddd_Click(object sender, EventArgs e)
        {
            fromAdd_EditProduct frm = new fromAdd_EditProduct();
            frm.ShowDialog();
            frmProductList_Load(null, null);
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void gcFilterBy_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            gtxtFilterValue.Visible = (gcFilterBy.Text != "Undefined");

            if (gtxtFilterValue.Visible)
            {
                gtxtFilterValue.Text = "";
                gtxtFilterValue.Focus();
            }
            _dtAllProducts.DefaultView.RowFilter = "";
            guna2lblRecordsCount.Text = guna2DataGridView1.Rows.Count.ToString();
        }
    }
}
