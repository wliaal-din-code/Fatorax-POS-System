using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using FX_Buisness;
using Guna.UI2.WinForms;

namespace FatoraX.Users
{
    public partial class frmListUser : Form
    {
        private DataTable _dtAllUsers;

        public frmListUser()
        {
            InitializeComponent();
        }

        void LoadData()
        {
            _dtAllUsers = clsUser.GetAllUsers();
            dgvUsers.DataSource = _dtAllUsers;
            guna2lblRecordsCount.Text = dgvUsers.Rows.Count.ToString();
            cbFilterBy.SelectedIndex = 0;

            if (dgvUsers.Rows.Count > 0)
            {
                showToolStripMenuItem1.Enabled = true;
                editToolStripMenuItem1.Enabled = true;
                deleToolStripMenuItem1.Enabled = true   ;
                ChangePasswordToolStripMenuItem.Enabled = true  ;

                dgvUsers.Columns[0].HeaderText = "User Id";

                dgvUsers.Columns[1].HeaderText = "Username";

                dgvUsers.Columns[2].HeaderText = "User Role";

                dgvUsers.Columns[3].HeaderText = "User Status";
            }

            else
            {
                showToolStripMenuItem1.Enabled = false;
                editToolStripMenuItem1.Enabled = false;
                deleToolStripMenuItem1.Enabled = false;
                ChangePasswordToolStripMenuItem.Enabled = false;
            }


        }

        private void frmListUser_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.Text == "User Status")
            {
                txtFilterValue.Visible = false;
                cbRole.Visible = false; 
                cbIsActive.Visible = true;
                cbIsActive.Focus();
                cbIsActive.SelectedIndex = 0;
                return;
            }
            else
            {
                txtFilterValue.Visible = (cbFilterBy.Text != "Undefined");
                cbIsActive.Visible = false;
                if (cbFilterBy.Text == "Undefined")
                {
                    txtFilterValue.Enabled = false;
                    //frmListUser_Load(null, null);
                    LoadData();
                }
                else
                    txtFilterValue.Enabled = true;
                txtFilterValue.Text = "";
                txtFilterValue.Focus();
            }

            if (cbFilterBy.Text == "User Role")
            {
                txtFilterValue.Visible = false;
                cbRole.Visible = true;
                cbRole.Focus();
                cbRole.SelectedIndex = 0;
            }
            else
            {
                txtFilterValue.Visible = (cbFilterBy.Text != "Undefined");
                cbRole.Visible = false;
                if (cbFilterBy.Text == "Undefined")
                {
                    txtFilterValue.Enabled = false;
                    //frmListUser_Load(null, null);
                    LoadData();
                }
                else
                    txtFilterValue.Enabled = true;
                txtFilterValue.Text = "";
                txtFilterValue.Focus();

                if (cbFilterBy.Text == "User Status")
                {
                    txtFilterValue.Visible = false;
                    cbIsActive.Visible = true;
                    cbIsActive.Focus();
                    cbIsActive.SelectedIndex = 0;
                }
            }
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";

            switch (cbFilterBy.Text)
            {
                case "User Id":
                    FilterColumn = "UserId";
                    break;

                case "Username":
                    FilterColumn = "Username";
                    break;

                case "User Role":
                    FilterColumn = "Role";
                    break;

                default:
                    FilterColumn = "None";
                    break;
            }

            if (txtFilterValue.Text.Trim() == "" | FilterColumn == "None")
            {
                _dtAllUsers.DefaultView.RowFilter = "";
                guna2lblRecordsCount.Text = dgvUsers.Rows.Count.ToString();
                return;
            }

            if (FilterColumn != "Username")
                _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());
            //dgvUsers.DataSource = _dtAllUsers;
            guna2lblRecordsCount.Text = dgvUsers.Rows.Count.ToString();
        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = "IsActive";
            string FilterValue = cbIsActive.Text;

            switch (FilterValue)
            {
                case "Active":
                    FilterValue = "1";
                    break;

                case "Inactive":
                    FilterValue = "0";
                    break;
            }

            _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, FilterValue);

            guna2lblRecordsCount.Text = _dtAllUsers.Rows.Count.ToString();

        }

        private void cbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = "Role";
            string FilterValue = cbRole.Text;

            switch (FilterValue)
            {
                case "Regular User":
                    FilterValue = "0";
                    break;

                case "Admin":
                    FilterValue = "1";
                    break;
            }

            _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, FilterValue);

            guna2lblRecordsCount.Text = _dtAllUsers.Rows.Count.ToString();
        }

        private void AddUser_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser frm = new frmAddUpdateUser();
            frm.ShowDialog();
            frmListUser_Load(null, null);
        }

        private void dgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvUsers_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmShowUserInfo Frm1 = new frmShowUserInfo((int)dgvUsers.CurrentRow.Cells[0].Value);
            Frm1.ShowDialog();
        }

        private void showToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmShowUserInfo Frm1 = new frmShowUserInfo((int)dgvUsers.CurrentRow.Cells[0].Value);
            Frm1.ShowDialog();
        }

        private void editToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser frm = new frmAddUpdateUser((int)dgvUsers.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            frmListUser_Load(null, null);
        }

        private void butClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void deleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete the user?", "Important Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int UserID = (int)dgvUsers.CurrentRow.Cells[0].Value;
                if (clsUser.DeleteUser(UserID))
                {
                    MessageBox.Show("User has been deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmListUser_Load(null, null);
                }
                else
                    MessageBox.Show("User is not delted due to data connected to it.", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void ChangePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword frm = new frmChangePassword((int)dgvUsers.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            frmListUser_Load(null, null);
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "User Id")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void guna2ContextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (dgvUsers.Rows.Count == 0)
            {
                showToolStripMenuItem1.Enabled = false;
                editToolStripMenuItem1.Enabled = false;
                deleToolStripMenuItem1.Enabled=false;
                ChangePasswordToolStripMenuItem.Enabled = false;    
            }
        }
    }
}