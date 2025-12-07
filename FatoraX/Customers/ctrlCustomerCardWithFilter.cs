using FatoraX.Customers;
using FatoraX.People;
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
    public partial class ctrlCustomerCardWithFilter : UserControl
    {
        public event Action<int> OnPersonSelected;
        public ctrlCustomerCardWithFilter()
        {
            InitializeComponent();
        }

        public int CustomerID
        {
            get { return ctrlCustomerInfo1.CustomerID; }
        }

        private bool _FilterEnabled = true;
        public bool FilterEnabled
        {
            get
            {
                return _FilterEnabled;
            }
            set
            {
                _FilterEnabled = value;
                guna2PaFilters.Enabled = _FilterEnabled;
            }
        }

        public void LoadCustomerInfo(int CustomerID)
        {
           // guna2cbFilterBy.SelectedIndex = 1;
            guna2txtFilterValue.Text = CustomerID.ToString();

            FindNow();
        }

        private void FindNow()
        {

            ctrlCustomerInfo1.LoadCustomerInfo(int.Parse(guna2txtFilterValue.Text));

            if (OnPersonSelected != null && FilterEnabled)
                // Raise the event with a parameter
                OnPersonSelected(ctrlCustomerInfo1.CustomerID);
        }



        private void btnAddNewCustomer_Click(object sender, EventArgs e)
        {

            frmAddUpdateCustomer frm1 = new frmAddUpdateCustomer();
            frm1.DataBack += Frm1_DataBack;
            frm1.ShowDialog();
        }

        private void Frm1_DataBack(object sender, int CustomersID)
        {
            //guna2cbFilterBy.SelectedIndex = 1;
            guna2txtFilterValue.Text = CustomersID.ToString();
            ctrlCustomerInfo1.LoadCustomerInfo(CustomersID);
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //
                MessageBox.Show("بعض الحقول غير صالحة! ضع الماوس فوق الرموز الحمراء لعرض الخطأ", "خطأ في التحقق", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            FindNow();
        }

        private void guna2txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {

                btnFind.PerformClick();
            }

                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void guna2txtFilterValue_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(guna2txtFilterValue.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(guna2txtFilterValue, "!هذا الحقل مطلوب");
            }
            else
            {

                errorProvider1.SetError(guna2txtFilterValue, null);
            }
        }

    }
}
