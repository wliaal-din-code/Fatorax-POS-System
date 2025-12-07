using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FatoraX.Customers
{
    public partial class frmFindCustomers : Form
    {
        public delegate void DataBackEventHandler(object sender, int PersonID);
        public event DataBackEventHandler DataBack;

        public frmFindCustomers()
        {
            InitializeComponent();
          
        }

       
        private void guna2putClose_Click(object sender, EventArgs e)
        {
            DataBack?.Invoke(this,ctrlCustomerCardWithFilter1.CustomerID);
            this.Close();
        }

        private void frmFindCustomers_Load(object sender, EventArgs e)
        {

        }
    }
}
