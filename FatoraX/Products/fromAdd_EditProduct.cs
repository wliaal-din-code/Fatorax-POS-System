using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FatoraX.Properties;
using FX_Buisness;
using FatoraX_DataAccess;
using Guna.UI2.WinForms;
using TheArtOfDevHtmlRenderer.Adapters;

namespace FatoraX.Products
{
    public partial class fromAdd_EditProduct : Form
    {
        private int _ProductID;
        private clsProducts _Product;

        enum enMode
        {
            Add,
            Edit
        }

        private enMode _Mode = enMode.Add;

        public fromAdd_EditProduct()
        {
            InitializeComponent();
            _Mode = enMode.Add;
        }

        public fromAdd_EditProduct(int ProductID)
        {
            InitializeComponent();
            _ProductID = ProductID;
            _Mode = enMode.Edit;

        }

        private void _ResetDefualtValues()
        {

            if (_Mode == enMode.Add)
            {
                lblTitle.Text = "Add Product";
                _Product = new clsProducts();
            }
            else
            {
                lblTitle.Text = "Update product";
            }

           

            gtxtName.Text = "";
            gtxtPrice.Text = "";
            gtxtStock.Text = "";
            gtxtCost.Text = "";
            

        }

        public void LoadData()
        {
            _Product = clsProducts.Find(_ProductID);
             
            if(_Product == null)
            {

                MessageBox.Show("There is no product with this number = " + _ProductID + ". Product not found", "Error",MessageBoxButtons.OK,MessageBoxIcon.Error); 
                this.Close();
                return;
            }

            gtxtName.Text = _Product.Name.Trim();
            gtxtPrice.Text = _Product.Price.ToString();
            gtxtCost.Text = _Product.Cost.ToString();
            gtxtStock.Text = _Product.Stock.ToString();
            lblProductID.Text = _ProductID.ToString();
        }

        private void fromAdd_EditProduct_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();
            if (_Mode == enMode.Edit)
                LoadData();
        
        }

        private void ValidateEmptyTextBox(object sender, CancelEventArgs e)
        {

            Guna2TextBox Temp = ((Guna2TextBox)sender);
            if (string.IsNullOrEmpty(Temp.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(Temp, ".!Enter the number ");
                return;
            }
            else
            {
                errorProvider1.SetError(Temp, null);

            };


            if (!clsValidatoin.IsNumber(Temp.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(Temp, ".!Please enter a valid number only");
            }
            else
            {
                errorProvider1.SetError(Temp, null);
            };

        }

        private void guna2putSava_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("This field is required. It cannot be empty", "Invalid input ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _Product.Name = gtxtName.Text.Trim();
            _Product.Price =Convert.ToDecimal(gtxtPrice.Text.Trim());
            _Product.Cost =Convert.ToDecimal(gtxtCost.Text.Trim());
            _Product.Stock = int.Parse(gtxtStock.Text.Trim());

            if (_Product.Save())
            {
                lblProductID.Text = _Product.ProductId.ToString();
                _Mode = enMode.Edit;
                lblTitle.Text = "Update product";
                lblTitle.Location = new Point(148, 9);
                MessageBox.Show(".Data saved successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show(".Error: Data was not saved successfully", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void guna2putClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        private void gtxtName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(gtxtName.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(gtxtName, "!Please enter product name");
            }
            else
            {
                  
                errorProvider1.SetError(gtxtName, null);
            }
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }
    }
}
