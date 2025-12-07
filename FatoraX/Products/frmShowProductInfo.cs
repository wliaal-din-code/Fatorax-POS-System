using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FatoraX.Products
{
    public partial class frmShowProductInfo : Form
    {
        int ProductID;
        public frmShowProductInfo(int productID)
        {
            InitializeComponent();
            ProductID = productID;
        }

        private void guna2putClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmShowProductInfo_Load(object sender, EventArgs e)
        {
            ctrlProductInfo1.LoadProductInfo(ProductID);
        }
    }
}
