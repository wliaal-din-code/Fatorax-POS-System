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
using System.Diagnostics;

namespace FatoraX.Users
{
    public partial class frmAddUpdateUser : Form
    {
        private enum enMode { _AddNew = 0, _Update }
        private int _UserId = 0;
        private enMode _Mode;
        private clsUser _User;

        public frmAddUpdateUser()
        {
            InitializeComponent();
            _Mode = enMode._AddNew;
        }

        public frmAddUpdateUser(int UserId)
        {
            InitializeComponent();
            _UserId = UserId;
            _Mode = enMode._Update;
        }

        private void _LoadData()
        {
            _User = clsUser.Find(_UserId);

            if (_User == null)
            {
                MessageBox.Show("No User with ID =" + _UserId, "User not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();

            }

            lblUserid.Text = _UserId.ToString();
            txtPassowrd.Text = _User.Password;
            txtUserName.Text = _User.Username;

            if (_User.IsActive == 1)
            {
                chIsActive.Checked = true;
            }
            else
            {
                chIsActive.Checked = false;
            }


            if (_User.Role == 1)
            {
                chRole.Checked = true;
            }
            else
            {
                chRole.Checked = false;
            }
        }

        private void _ResetDefualtValues()
        {

            if (_Mode == enMode._AddNew)
            {
                lblTitl.Text = "Add User";
                this.Text = lblTitl.Text;
                _User = new clsUser();
            }
            else
            {
                lblTitl.Text = "Edit User";
                this.Text = lblTitl.Text;
            }
            lblUserid.Text = "[???]";
            txtPassowrd.Text = "";
            txtUserName.Text = "";
            chIsActive.Checked = true;
            chRole.Checked = false;
        }

        private void frmAddUpdateUser_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();
            if (_Mode == enMode._Update)
                _LoadData();
        }

        private void butSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro",
                 "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            
            _User.Username = txtUserName.Text.Trim();
            _User.Password = txtPassowrd.Text.Trim();

            if (chRole.Checked)
            {
                _User.Role = 1;
            }
            else
            {
                _User.Role = 0;
            }

            if (chIsActive.Checked)
            {
                _User.IsActive = 1;
            }
            else
            {
                _User.IsActive = 0;
            }

            if (_User.Save())
            {
                lblUserid.Text = _User.UserId.ToString();
                _Mode = enMode._Update;
                lblTitl.Text = "Edit User";
                this.Text = lblTitl.Text;
                
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtUserName, "Username cannot be blank");
            }
            else
            {
                errorProvider1.SetError(txtUserName, null);
            }

            if (_Mode == enMode._AddNew)
            {
                if (clsUser.isUserExist(txtUserName.Text.Trim()))
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtUserName, "username is used by another user");
                }
                else
                {
                    errorProvider1.SetError(txtUserName, null);
                }
            }
            else

            {
                if (_User.Username != txtUserName.Text.Trim())
                {
                    if (clsUser.isUserExist(txtUserName.Text.Trim()))
                    {
                        e.Cancel = true;
                        errorProvider1.SetError(txtUserName, "username is used by another user");
                        return;
                    }
                    else
                    {
                        errorProvider1.SetError(txtUserName, null);
                    }
                }
            }
        }

        private void txtPassowrd_Validating(object sender, CancelEventArgs e) 
        {
            if (string.IsNullOrEmpty(txtPassowrd.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPassowrd, " Password cannot be empty");
            }
            else
            {
                errorProvider1.SetError(txtPassowrd, null);
            }
        }

        private void butClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPassowrd_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
