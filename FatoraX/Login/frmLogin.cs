using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FatoraX.Products;
using FatoraX.Users;
using FX_Buisness;
using FatoraX_DataAccess;
using System.IO;
using System.Net.NetworkInformation;

namespace FatoraX.Login
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }


   


        private void frmLogin_Load(object sender, EventArgs e)
        {

            string UserName = "", Password = "";

            if (clsGlobal.GetStoredCredential(ref UserName, ref Password))
            {
                txtUserName.Text = UserName;
                txtPassowrd.Text = Password;
                chkRememberMe.Checked = true;
            }
            else
                chkRememberMe.Checked = false;

         

        }

 
        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buLogin_Click(object sender, EventArgs e)
        {



            clsUser user = clsUser.FindUserByUserNameAndPassword(txtUserName.Text.Trim(), txtPassowrd.Text.Trim());

            if (user != null)
            {
                if (chkRememberMe.Checked)
                {
                    clsGlobal.RememberUsernameAndPassword(txtUserName.Text.Trim(), txtPassowrd.Text.Trim());
                }
                else
                {
                    clsGlobal.RememberUsernameAndPassword("", "");
                }

                if (user.IsActive == 0)
                {
                    txtUserName.Focus();
                    MessageBox.Show("Your account is not activated. Please contact the administrator", "Inactive Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }



                clsGlobal.CurrentUser = user;
                this.Hide();
                frmMainScreen form = new frmMainScreen(this);
                form.ShowDialog();


            }
            else
            {
                txtUserName.Focus();
                MessageBox.Show("Incorrect username or password", "Invalid credentials", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }



        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddUpdateUser frm = new frmAddUpdateUser();
            frm.ShowDialog();
        }

        private void chkRememberMe_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtPassowrd_TextChanged(object sender, EventArgs e)
        {
            txtPassowrd.PasswordChar = '*';
        }
    }
}
