using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using FatoraX.Customers;
using FatoraX.Properties;
using FX_Buisness;
using FatoraX_DataAccess;
using Guna.UI2.WinForms;

namespace FatoraX.People
{
    public partial class frmListCustomer : Form
    {
        private DataTable _dtCustomers;
        private DataTable _dtAllCustomers;

        public frmListCustomer()
        {
            InitializeComponent();
        }


        // private static DataTable _dtAllCustomers = clsCustomers.GetAllCustomers();

        private void InitializeCustomersDataTable()
        {
            if (_dtAllCustomers != null && _dtAllCustomers.Rows.Count > 0)
            {
                _dtCustomers = _dtAllCustomers.DefaultView.ToTable(false, "CustomerId", "Name", "Phone", "Email");
            }
            else
            {
                _dtCustomers = new DataTable(); // جدول فارغ إذا كانت البيانات غير موجودة
            }
        }


        private void _RefreshCustomersList()
        {
            _dtAllCustomers = clsCustomers.GetAllCustomers();

            if (_dtAllCustomers.Rows.Count != 0)
            {
                _dtCustomers = _dtAllCustomers.DefaultView.ToTable(false, "CustomerId", "Name",
                                                        "Phone", "Email");
            }
            else
            {
                _dtCustomers = new DataTable(); // جدول فارغ إذا لا توجد بيانات
            }

            guna2dgvPeople.DataSource = _dtAllCustomers;
            guna2lblRecordsCount.Text = guna2dgvPeople.Rows.Count.ToString();


            if (_dtAllCustomers.Rows.Count > 0)
            {
                showDetailsToolStripMenuItem.Enabled = true;
                addNewPersonToolStripMenuItem.Enabled = true;
                editToolStripMenuItem.Enabled = true;
                deleteToolStripMenuItem.Enabled = true;
                sendEmailToolStripMenuItem.Enabled = true;
                phoneCallToolStripMenuItem.Enabled = true;

                guna2dgvPeople.DataSource = _dtCustomers;
                guna2dgvPeople.Columns[0].HeaderText = "Customer Id";
                guna2dgvPeople.Columns[1].HeaderText = "Name";
                guna2dgvPeople.Columns[2].HeaderText = "Phone";
                guna2dgvPeople.Columns[3].HeaderText = "Email";

                guna2cbFilterBy.SelectedIndex = 0;
                guna2lblRecordsCount.Text = guna2dgvPeople.Rows.Count.ToString();

            }
            else
            {
               
                    showDetailsToolStripMenuItem.Enabled = false;
                    addNewPersonToolStripMenuItem.Enabled = false;
                    editToolStripMenuItem.Enabled = false;
                    deleteToolStripMenuItem.Enabled = false;
                    sendEmailToolStripMenuItem.Enabled = false;
                    phoneCallToolStripMenuItem.Enabled = false;
                
            }
        }

        private void frmListPeople_Load(object sender, EventArgs e)
        {

            _RefreshCustomersList();


        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2txtFilterValue_TextChanged(object sender, EventArgs e)
        {

            string FilterColumn = "";

            switch (guna2cbFilterBy.Text)
            {
                case "Customer Id":
                    FilterColumn = "CustomerId";
                    break;

                case "Name":
                    FilterColumn = "Name";
                    break;

                case "Phone":
                    FilterColumn = "Phone";
                    break;

                case "Email":
                    FilterColumn = "Email";
                    break;

                default:
                    FilterColumn = "None";
                    break;

            }


            if (guna2txtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {

                _dtAllCustomers.DefaultView.RowFilter = "";
                guna2lblRecordsCount.Text = guna2dgvPeople.Rows.Count.ToString();
                return;
            }


            if (FilterColumn == "CustomerId")


                _dtAllCustomers.DefaultView.RowFilter = string.Format("[{0}] = '{1}'", FilterColumn, guna2txtFilterValue.Text.Trim());
            else
                _dtAllCustomers.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, guna2txtFilterValue.Text.Trim());

            guna2dgvPeople.DataSource = _dtAllCustomers.DefaultView; // ✨ ملاحظة مهمة
            guna2lblRecordsCount.Text = guna2dgvPeople.Rows.Count.ToString();





        }

        private void guna2cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            guna2txtFilterValue.Visible = (guna2cbFilterBy.Text != "Unspecified");

            if (guna2txtFilterValue.Visible)
            {
                guna2txtFilterValue.Text = "";
                guna2txtFilterValue.Focus();
            }
        }

        private void guna2txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (guna2cbFilterBy.Text == "Customer Id")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowCustomerInfo frm = new frmShowCustomerInfo((int)guna2dgvPeople.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateCustomer frm = new frmAddUpdateCustomer();
            frm.ShowDialog();
            _RefreshCustomersList();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmAddUpdateCustomer frm = new frmAddUpdateCustomer((int)guna2dgvPeople.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshCustomersList();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"[ {guna2dgvPeople.CurrentRow.Cells[0].Value}]   Are you sure you want to delete this customer? ", "Confirm Deletion", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)

            {
                //Perform Delele and refresh
                if (clsCustomers.DeleteCustomer((int)guna2dgvPeople.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show(" The customer was successfully deleted.", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshCustomersList();
                }

                else
                    MessageBox.Show("The person could not be deleted because they are linked to other data.", "An error occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            frmListPeople_Load(null, null);
        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = Application.StartupPath + @"\email_settings.txt";

            // تحقق من وجود الملف
            if (!File.Exists(path))
            {
                OpenEmailSettings();
                return;
            }

            // قراءة أول سطر من الملف (إذا كان موجودًا)
            var lines = File.ReadLines(path).FirstOrDefault();

            if (string.IsNullOrWhiteSpace(lines))
            {
                OpenEmailSettings();
                return;
            }

            // تقسيم النص بناءً على الفاصل "|"
            string[] parts = lines.Split('|');

            // التحقق من وجود 4 أجزاء صحيحة (الإيميل، كلمة المرور، الخادم، والمنفذ)
            if (parts.Length == 4 &&
                !parts.Any(string.IsNullOrEmpty) &&
                parts[0].Contains("@") &&
                int.TryParse(parts[3], out _))  // تأكد أن المنفذ هو رقم صحيح
            {
                OpenSendEmailForm();
            }
            else
            {
                OpenEmailSettings();
            }


        }

        private void OpenSendEmailForm()
        {

            if (guna2dgvPeople.CurrentRow.Cells[3].Value == System.DBNull.Value)
            {
                frmSenndEmail frm1 = new frmSenndEmail("");
                frm1.ShowDialog();
            }
            else
            {
                frmSenndEmail frm2 = new frmSenndEmail((string)guna2dgvPeople.CurrentRow.Cells[3].Value);
                frm2.ShowDialog();
            }

        }

        private void OpenEmailSettings()
        {
            frmEmailSettings frm1 = new frmEmailSettings();
            frm1.ShowDialog();
        }

        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //
            string path = Application.StartupPath + @"\twilio_settings.txt";

            // تحقق مما إذا كان الملف موجودًا بسرعة
            if (!File.Exists(path))
            {
                OpenPhoneSettings();
                return;
            }

            // اقرأ السطور من الملف مباشرة
            var lines = File.ReadLines(path).FirstOrDefault();

            if (string.IsNullOrWhiteSpace(lines))
            {
                OpenPhoneSettings();
                return;
            }

            // تقسيم البيانات إلى أجزاء بناءً على الفاصل "|"
            string[] parts = lines.Split('|');

            // تحقق من التنسيق الصحيح
            if (parts.Length == 3 && !parts.Any(string.IsNullOrEmpty))
            {
                OpenPhoneCallForm();
            }
            else
            {
                OpenPhoneSettings();
            }
        }

        private void OpenPhoneCallForm()
        {

            if (guna2dgvPeople.CurrentRow.Cells[2].Value == System.DBNull.Value)
            {
                frmPhoneCall frm1 = new frmPhoneCall();
                frm1.ShowDialog();
            }
            else
            {
                frmPhoneCall frm2 = new frmPhoneCall((string)guna2dgvPeople.CurrentRow.Cells[2].Value);
                frm2.ShowDialog();
            }

        }

        private void OpenPhoneSettings()
        {
            frmTwilioSettings frm1 = new frmTwilioSettings();
            frm1.ShowDialog();
        }

        private void btnAddNewCustomer_Click(object sender, EventArgs e)
        {
            frmAddUpdateCustomer frm = new frmAddUpdateCustomer();
            frm.ShowDialog();
            _RefreshCustomersList();
        }

        private void guna2putClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2ContextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
           
        }
    }

}
