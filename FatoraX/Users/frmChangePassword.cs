using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FX_Buisness;
using Guna.UI2.WinForms;

namespace FatoraX.Users
{
    public partial class frmChangePassword : Form
    {
        private int _UserId;
        private clsUser _UserInfo;
        public frmChangePassword(int UserId)
        {
            InitializeComponent();
            _UserId = UserId;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            txtCurrentPassword.PasswordChar = '*';
        }

        private void butClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butSave_Click(object sender, EventArgs e)
        {
           
            if(!this.ValidateChildren())
            {
                MessageBox.Show("Some fields are invalid! Hover over the red icon to see the error", "Validation error", MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            _UserInfo.Password = txtNewPassword.Text;
            if(_UserInfo.Save())
            {
                MessageBox.Show("Password changed successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
             //   _ResetDefualtValues();
            }
            else
                MessageBox.Show("An error occurred. The password was not changed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void _ResetDefualtValues()
        {
            txtConfirmPassword.Text = "";
            txtCurrentPassword.Text = "";
            txtNewPassword.Text = "";
            txtCurrentPassword.Focus();
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();
            _UserInfo = clsUser.Find(_UserId);
            if (_UserInfo == null)
            {
                MessageBox.Show("No user found with the ID" + _UserId, "User not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            ctrShowUserInfo1.LoadDataUser(_UserId);
        }

        private void txtCurrentPassword_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(txtCurrentPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtCurrentPassword, "Password cannot be empty");
                return;
            }
            else
            {
                errorProvider1.SetError(txtCurrentPassword, null);
            }

            if(_UserInfo.Password != txtCurrentPassword.Text.Trim())
            {
                e.Cancel = true;
                errorProvider1.SetError(txtCurrentPassword, "The current password is incorrect");
                return;
            }
            else
            {
                errorProvider1.SetError(txtCurrentPassword, null);
            }
        }

        private void txtNewPassword_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(txtNewPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNewPassword, "The new password cannot be empty");
                
            }
            else
            {
                errorProvider1.SetError(txtNewPassword, null);
            }
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtConfirmPassword.Text.Trim() != txtNewPassword.Text.Trim())
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "Password confirmation does not match the new password");
                
            }
            else
            {
                errorProvider1.SetError(txtConfirmPassword, null);
            }
        }

        private void txtNewPassword_TextChanged(object sender, EventArgs e)
        {
            txtNewPassword.PasswordChar = '*';
        }

        private void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            txtConfirmPassword.PasswordChar = '*';
        }
    }
}
