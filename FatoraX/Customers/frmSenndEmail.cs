using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace FatoraX.Customers
{
    public partial class frmSenndEmail : Form
    {
        private string _Email = "";
       
        
        List<string> emailList = new List<string>();
        string[] settings; // متغير لتخزين إعدادات البريد الإلكتروني

      
            public frmSenndEmail(string Email)////
        {
            InitializeComponent();


          

            _Email = Email;
            // تحميل الإعدادات مرة واحدة عند بدء التطبيق
            string path = Application.StartupPath + @"\email_settings.txt";
            if (File.Exists(path))
            {
                settings = File.ReadAllText(path).Split('|');
            }
            else
            {
                MessageBox.Show("The settings are not available", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // تخصيص النص الافتراضي للـ txtEmailInput
            txtEmailInput.Text = "Enter the email here...";
            txtEmailInput.ForeColor = Color.Gray;

            // عندما يدخل المستخدم إلى الـ TextBox (txtEmailInput)
            txtEmailInput.Enter += (s, e) =>
            {
                if (txtEmailInput.Text == "Enter the email here...")
                {
                    txtEmailInput.Text = "";  // مسح النص الافتراضي
                    txtEmailInput.ForeColor = Color.Black;  // تغيير اللون إلى أسود
                }
            };

            // عندما يترك المستخدم الـ TextBox (txtEmailInput)
            txtEmailInput.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtEmailInput.Text))
                {
                    txtEmailInput.Text = "Enter the email here...";  // إرجاع النص الافتراضي
                    txtEmailInput.ForeColor = Color.Gray;  // تغيير اللون إلى الرمادي
                }
            };

            // تخصيص النص الافتراضي للـ txtSubject
            txtSubject.Text = "Enter the subject here...";
            txtSubject.ForeColor = Color.Gray;

            // عندما يدخل المستخدم إلى الـ TextBox (txtSubject)
            txtSubject.Enter += (s, e) =>
            {
                if (txtSubject.Text == "Enter the subject here...")
                {
                    txtSubject.Text = "";  // مسح النص الافتراضي
                    txtSubject.ForeColor = Color.Black;  // تغيير اللون إلى أسود
                }
            };

            // عندما يترك المستخدم الـ TextBox (txtSubject)
            txtSubject.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtSubject.Text))
                {
                    txtSubject.Text = "Enter the subject here...";  // إرجاع النص الافتراضي
                    txtSubject.ForeColor = Color.Gray;  // تغيير اللون إلى الرمادي
                }
            };
        
    }

        private void frmSenndEmail_Load(object sender, EventArgs e)
         {
           
            if (_Email != "")
            {
                Button1.Enabled = true;
                AddEmailBubble(_Email);
            }
        }


        private async void guna2Button1_Click(object sender, EventArgs e)///X
        {

            try
            {
                // إعداد SMTP Client
                SmtpClient smtpClient = new SmtpClient(settings[2]);
                smtpClient.Port = int.Parse(settings[3]);
                smtpClient.Credentials = new NetworkCredential(settings[0], settings[1]);
                smtpClient.EnableSsl = true;

                // إعداد الرسالة الإلكترونية
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(settings[0]);

                // إضافة الإيميلات من القائمة
                foreach (var recipient in emailList)
                {
                    mail.To.Add(recipient);
                }


                // استخدام الموضوع والنص
                mail.Subject = txtSubject.Text;
                mail.Body = txtBody.Text;

                // إرسال البريد الإلكتروني بشكل غير متزامن
                await smtpClient.SendMailAsync(mail);  // التعديل هنا

                MessageBox.Show("The email has been successfully sent to all recipients.", "Awesome", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during sending: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // التحقق من صيغة الإيميل باستخدام Regular Expressions
        private bool IsValidEmail(string email)////
        {
            var regex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            return regex.IsMatch(email);
        }

        private void guna2txtRecipient_TextChanged(object sender, EventArgs e)
        {
        
        }

        private void txtAddEmail_TextChanged(object sender, EventArgs e)
        {
            
        }

       
        // إضافة فقاعة إيميل جديدة
        private void AddEmailBubble(string email)
        {
            if (emailList.Contains(email))
                return; // لا تضيف نفس الإيميل مرتين

            emailList.Add(email);

            Button emailBubble = new Button();
            emailBubble.Text = email + " ✖";
            emailBubble.AutoSize = true;
            emailBubble.BackColor = Color.LightBlue;
            emailBubble.FlatStyle = FlatStyle.Flat;
            emailBubble.Margin = new Padding(5);
            emailBubble.Click += (s, e) =>
            {
                flowLayoutPanelEmails.Controls.Remove(emailBubble);
                emailList.Remove(email);
            };

            flowLayoutPanelEmails.Controls.Add(emailBubble);
        }

        // حدث الضغط على Enter لإضافة الإيميل
        private void txtEmailInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // لمنع صوت التنبيه

                string email = txtEmailInput.Text.Trim();

               
                if (!string.IsNullOrEmpty(email) && IsValidEmail(email))
                {
                    Button1.Enabled = true;
                    AddEmailBubble(email);
                    txtEmailInput.Clear();
                }
                else
                {
                    MessageBox.Show("Invalid email address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtEmailInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSubject_TextChanged(object sender, EventArgs e)
        {

        }

        private void إعداداتTwilioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmEmailSettings frm = new frmEmailSettings();
            frm.ShowDialog();
            this.Close();

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }

    
}
