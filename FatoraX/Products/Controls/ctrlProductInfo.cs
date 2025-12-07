using FX_Buisness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FatoraX.Products.Controls
{
    public partial class ctrlProductInfo : UserControl
    {
        public ctrlProductInfo()
        {
            InitializeComponent();
        }
        private int _ProductID = -1;

        clsProducts _Product;

        public int ProductID
        {
            get { return _ProductID; }
        }

        public clsProducts SelectedProductInfo
        {
            get { return _Product; }
        }
        private void ctrlProductInfo_Load(object sender, EventArgs e)
        {
           
        }

        public void LoadProductInfo(int ProductId)
        {
            _Product = clsProducts.Find(ProductId);
            _ProductID = ProductId;

            if (_Product == null)
            {
                ResetProductInfo();
                MessageBox.Show("لا يوجد منتج بالمعرف" + ProductId.ToString(), "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillProductInfo();
        }

        public void ResetProductInfo()
        {
            
            txtProductId.Text = "  " + "[????]";
            txtName.Text = "  " + "[????]";
            txtPrice.Text = "  " + "[????]";
            txtCost.Text = "  " + "[????]";
            txtStock.Text = "  " + "[????]";
        }
        private void _FillProductInfo()
        {
            txtProductId.Text="  "+_ProductID.ToString();
            txtName.Text =  "  "+_Product.Name;
            txtPrice.Text="  " +     _Product.Price.ToString();
            txtCost.Text = "  " + _Product.Cost.ToString();
            txtStock.Text = "  " + _Product.Stock.ToString();    
        }

        private void txtProductId_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
