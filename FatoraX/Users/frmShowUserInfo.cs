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
    public partial class frmShowUserInfo : Form
    {
        private int _UserId = 0;
        
        public frmShowUserInfo(int UserId)
        {
            InitializeComponent();
            _UserId = UserId;
        }

        

        private void frmShowUserInfo_Load(object sender, EventArgs e)
        {
            ctrShowUserInfo1.LoadDataUser(_UserId);
        }

        private void butClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ctrShowUserInfo1_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
