using FX_Buisness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FatoraX.Customers;
using System.Windows.Forms;

namespace FatoraX.People
{
    public partial class ctrlCustomerInfo : UserControl
    {
        private clsCustomers _Customers;

        public int CustomerID
        {
            get { return _CustomerID; }
        }

        private int _CustomerID;
        public ctrlCustomerInfo()
        {
            InitializeComponent();
        }
        private void ResetPersonInfo()
        {
            _CustomerID = -1;
            txtCustomerID.Text = "  " + "[????]";
            txtName.Text = "  " + "[????]";
            txtPhone.Text = "[????]  ";
            txtEmil.Text = "  " + "[????]";
            txtAddress.Text = "  " + "[????]";
            txtNotes.Text = "  " + "[????]";
        }
        public void LoadCustomerInfo(int CustomerID)
        {
            _Customers = clsCustomers.Find(CustomerID);
            if(_Customers == null)
            {

                ResetPersonInfo();
                MessageBox.Show($"[{CustomerID.ToString()}] لا يوجد مستخدم بهذا الرقم التعريفي ", "حدث خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillCustomerInfo();
        }
        private void _FillCustomerInfo()
        {
            txtCustomerID.Text = "  " + _Customers.CustomerId.ToString();
            txtName.Text = "  " + _Customers.CustomerName.ToString();
            txtPhone.Text =  _Customers.Phone.ToString() + "  ";
            txtEmil.Text = "  " + _Customers.Email.ToString();
            txtAddress.Text = "  " + _Customers.Address.ToString();
            txtNotes.Text = "  " + _Customers.Notes.ToString();
            txtNotes.Text = _Customers.Notes.ToString();
        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void ctrlCustomerInfo_Load(object sender, EventArgs e)
        {

        }
    }
}
