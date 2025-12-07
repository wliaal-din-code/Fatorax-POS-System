using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using FX_Buisness;
using FatoraX_DataAccess;
namespace FatoraX.People
{
    public partial class frmAddUpdateCustomer : Form
    {
        public delegate void DataBackEventHandler(object sender, int CustomersID);

        public event DataBackEventHandler DataBack;

        private enum enMode { _AddNew,_Update}
        private enMode _Mode;
        private int _CustomersId = 0;
        private clsCustomers _Customers;

        public frmAddUpdateCustomer()
        {
            InitializeComponent();
            _Mode = enMode._AddNew;
        }

        public frmAddUpdateCustomer(int CustomersId)
        {
            InitializeComponent();
            _CustomersId = CustomersId;
            _Mode = enMode._Update;
        }

        private void _ResetDefualtValues()
        {
            if (_Mode == enMode._AddNew)
            {
                this.lblTitle.Text = "Add Customer";
                this.Text = "Add Customer";
                lblTitle.Location = new Point(230, 10);

                _Customers = new clsCustomers();
            }
            else
            {
                lblTitle.Text = "Edit Customer Information";
                lblTitle.Location = new Point(148, 9);
                this.Text = "Edit Customer Information";
            }

            guna2Email.Text = "";
            guna2txtName.Text = "";
            txtNote.Text = "";
            guna2txtPhone.Text = "";
            guna2txtAddress.Text = "";
            lblPersonID.Text = "[???]";
        }

        private void _LoadData()
        {
            _Customers = clsCustomers.Find(_CustomersId);

            if(_Customers != null)
            {
                lblPersonID.Text = _Customers.CustomerId.ToString();
                guna2txtName.Text = _Customers.CustomerName.Trim();
                guna2txtPhone.Text = _Customers.Phone.Trim();
                txtNote.Text = _Customers.Notes.Trim();
                guna2Email.Text = _Customers.Email.Trim();
                guna2txtAddress.Text = _Customers.Address.Trim();    
            }
        }

        private void frmAddUpdatePerson_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();

            if (_Mode == enMode._Update)
                _LoadData();
        }

        private void guna2putClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2putSava_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro",
                     "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



            _Customers.CustomerName = guna2txtName.Text.Trim();

            if (guna2txtPhone.Text != "")
            {
                _Customers.Phone = guna2txtPhone.Text.Trim();
            }
            else
                _Customers.Phone = "";

            if (guna2Email.Text != "")
            {
                _Customers.Email = guna2Email.Text.Trim();
            }
            else
            {
                _Customers.Email = "";
            }

            if (guna2txtAddress.Text == "")
            {
                _Customers.Address = "";
            }
            else
                _Customers.Address = guna2txtAddress.Text.Trim();

            if (txtNote.Text == "")
            {
                _Customers.Notes = "";
            }
            else
                _Customers.Notes = txtNote.Text.Trim();

            if (_Customers.Save())
            {
                lblPersonID.Text = _Customers.CustomerId.ToString();
                _Mode = enMode._Update;

                lblTitle.Text = "Edit Customer Information";
                lblTitle.Location = new Point(148, 9);

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DataBack?.Invoke(this, _Customers.CustomerId);
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void guna2txtName_Validating(object sender, CancelEventArgs e)
        {
            
            if (string.IsNullOrEmpty(guna2txtName.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(guna2txtName, " Please enter name");
            }
            else
            {
                //e.Cancel = false;
                errorProvider1.SetError(guna2txtName, null);
            }
        }

        private void guna2txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
                

        }

        private void guna2Email_Validating(object sender, CancelEventArgs e)
        {
            string emailAddress = guna2Email.Text.Trim();

            if (string.IsNullOrWhiteSpace(emailAddress))
                return;

            // التحقق من صحة تنسيق البريد الإلكتروني باستخدام التعبير المنتظم
            if (!clsValidatoin.ValidateEmail(emailAddress))
            {
                e.Cancel = true;
                errorProvider1.SetError(guna2Email, " Please enter a valid email address.");
            }
            else
            {
                // التحقق من النطاق
                string domain = emailAddress.Split('@').Last().ToLower();
                string[] commonDomains = { "gmail.com", "yahoo.com", "outlook.com", "hotmail.com", "icloud.com" };

                if (!commonDomains.Contains(domain))
                {
                    // تحذير المستخدم إذا كان النطاق غير معروف
                    MessageBox.Show("There might be a typo in the email domain (e.g., gmail.com or yahoo.com). Please check the domain.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // إذا كان التنسيق والنطاق صحيحين
                    errorProvider1.SetError(guna2Email, null);
                }
            }
        }

        private void guna2txtPhone_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2txtPhone_Validating(object sender, CancelEventArgs e)
        {
            string phone = guna2txtPhone.Text.Trim();

            if (string.IsNullOrEmpty(phone))
            {
                e.Cancel = true;
                errorProvider1.SetError(guna2txtPhone, "( Please enter  phone number");
            }
            else
            {
                errorProvider1.SetError(guna2txtPhone, null);
            }

            // الصيغة الدولية: تبدأ بـ + ثم 8 إلى 15 رقم
            if (!Regex.IsMatch(phone, @"^\+\d{8,15}$"))
            {
                e.Cancel = true;
                errorProvider1.SetError(guna2txtPhone, "( Please enter a valid international phone number (e.g., +966xxxxxxxx or +2010xxxxxxx)");
            }
            else
            {
                errorProvider1.SetError(guna2txtPhone, null);
            }
        }

        private void guna2txtAddress_Validating(object sender, CancelEventArgs e)
        {
        }

        private void guna2txtPhone_Validated(object sender, EventArgs e)
        {
           
        }
    }
}
