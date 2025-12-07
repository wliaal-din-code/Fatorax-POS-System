using FatoraX.FinancialReports;
using FatoraX.InvoiceDetails;
using FatoraX.Invoices;
using FatoraX.Login;
using FatoraX.People;
using FatoraX.Products;
using FatoraX.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FatoraX
{
    public partial class frmMainScreen : Form
    {
        frmLogin _login;
        public frmMainScreen(frmLogin login )
        {
            InitializeComponent();
            _login = login;
        }

        private void المستخدمونToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListUser frm = new frmListUser();
            frm.ShowDialog();
        }

        private void المنتجاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProductList frm = new frmProductList();
            frm.ShowDialog();
        }

        private void العملاءToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListCustomer frm = new frmListCustomer();
            frm.ShowDialog();
        }

        private void الفواتيرToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLasteInvoices frm = new frmLasteInvoices();
            frm.ShowDialog();
        }

        private void تفاصيلالفاتورةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInvoiceDetailsScreen frm=new frmInvoiceDetailsScreen();  
            frm.ShowDialog();
        }

        private void تسجيلخروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLaitTotalSales frm=new frmLaitTotalSales();
            frm.ShowDialog();
        }

        private void التقاريرالماليةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            _login.Show();
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void frmMainScreen_Load(object sender, EventArgs e)
        {

        }

        private void frmMainScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void frmMainScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            _login.Show();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {


        }
    }
}
