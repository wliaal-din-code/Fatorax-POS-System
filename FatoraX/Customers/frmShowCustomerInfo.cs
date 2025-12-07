using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FatoraX.People
{
    public partial class frmShowCustomerInfo : Form
    {

        public frmShowCustomerInfo(int CustomerID)
        {
            InitializeComponent();
            ctrlCustomerInfo1.LoadCustomerInfo(CustomerID);
        }

        private void guna2putClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmShowCustomerInfo_Load(object sender, EventArgs e)
        {

        }
    }
}
