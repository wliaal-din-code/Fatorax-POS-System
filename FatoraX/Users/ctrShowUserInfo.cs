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

namespace FatoraX.Users
{
    public partial class ctrShowUserInfo : UserControl
    {
        clsUser _User;
        public ctrShowUserInfo()
        {
            InitializeComponent();
        }

        public void LoadDataUser(int _UserId)
        {
            _User = clsUser.Find(_UserId);
            if (_User == null)
            {
                MessageBox.Show("No user found with the ID" + _UserId, "User not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
                
            }

            lblUserid.Text = "  " + _User.UserId.ToString();
            lblUserName.Text = "  " + _User.Username;

            if (_User.IsActive == 1)
            {
                lblIsActive.Text = "  " + "Active";
            }
            else
            {
                lblIsActive.Text = "  " + "Inactive";
            }

            if (_User.Role == 1)
            {
                lblRole.Text = "  " + "Admin";
            }
            else
            {
                lblRole.Text = "  " + "Standard user";
            }
        }

        private void ctrShowUserInfo_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
