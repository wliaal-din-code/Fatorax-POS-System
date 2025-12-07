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
using System.Net.Mail;
using System.Net;
using Guna.UI2.WinForms;
using System.Text.RegularExpressions;
using FatoraX_DataAccess;
namespace FatoraX.Customers
{
    public partial class frmEmailSettings : Form
    {
      
        public frmEmailSettings()
        {
            InitializeComponent();
        }


        private void LoadSettingsFromFile()
        {
            try
            {
                string settingsFile = @"email_settings.txt";

                // التحقق إذا كان الملف موجودًا
                if (File.Exists(settingsFile))
                {
                    // قراءة السطر بالكامل
                    string content = File.ReadAllText(settingsFile).Trim();

                    // إذا كان السطر يحتوي على '|' نفصل البيانات
                    if (content.Contains("|"))
                    {
                        string[] settings = content.Split('|');

                        // التأكد من وجود 4 عناصر فقط
                        if (settings.Length == 4)
                        {
                            // تعبئة الـ TextBoxes بالبيانات من الملف
                            guna2txtEmailAddress.Text = settings[0].Trim();
                            guna2txtAppPassword.Text = settings[1].Trim();
                            guna2txtSMTPServer.Text = settings[2].Trim();
                            guna2txtPort.Text = settings[3].Trim();
                        }
                    }
                    // إذا لم يتم استخدام '|' يمكن هنا إضافة خيار آخر إذا كان التنسيق مختلفًا
                }
                // إذا لم يكن الملف موجودًا، يتم ترك الحقول فارغة
            }
            catch (Exception)
            {
                // تجاهل الأخطاء أو عرض رسائل أخطاء هنا حسب الحاجة
            }
        }



        private void guna2btnSaveSettings_Click(object sender, EventArgs e)
        {

            if (!this.ValidateChildren())
            {
                
                MessageBox.Show("Some fields contain incorrect data! Hover over the red icon to view the error.", "Data verification error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }


            try
            {
                // تحديد المسار الذي سيتم حفظ الملف فيه
                string path = Application.StartupPath + @"\email_settings.txt";

                // تجميع الإعدادات المدخلة من المستخدم
                string settings = guna2txtEmailAddress.Text + "|" + guna2txtAppPassword.Text + "|" + guna2txtSMTPServer.Text + "|" + guna2txtPort.Text;

                // حفظ الإعدادات في الملف
                File.WriteAllText(path, settings);

                // عرض رسالة تأكيد بأن الإعدادات تم حفظها بنجاح
                MessageBox.Show(" Settings saved successfully.", "Excellent", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Hide();
                frmSenndEmail frm = new frmSenndEmail("");
                frm.ShowDialog();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(" An error occurred while saving the settings " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                // قراءة القيم من الواجهة
                string email = guna2txtEmailAddress.Text.Trim();
                string password = guna2txtAppPassword.Text.Trim();
                string smtpServer = guna2txtSMTPServer.Text.Trim();
                int port = int.Parse(guna2txtPort.Text.Trim());

                // تحقق مبدئي من الحقول قبل الإرسال
                if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(smtpServer))
                {
                    MessageBox.Show(" Please fill in all fields before testing.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // إنشاء رسالة البريد
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(email);
                mail.To.Add(email); // إرسال إلى نفس الإيميل للاختبار
                mail.Subject = " Test Email Settings";
                mail.Body = " This is a test message for your email settings.";

                // إعداد عميل SMTP
                using (SmtpClient smtpClient = new SmtpClient(smtpServer, port))
                {
                    smtpClient.Credentials = new NetworkCredential(email, password);
                    smtpClient.EnableSsl = true; // غالباً ضروري مع جيميل وغيره

                    // إرسال البريد بشكل غير متزامن (Async)
                    await smtpClient.SendMailAsync(mail);

                    // رسالة نجاح في حال الإرسال الناجح
                    MessageBox.Show(" The email was sent successfully. ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (SmtpException smtpEx)
            {
                // إذا كانت المشكلة تتعلق بـ SMTP (مثلاً فشل الاتصال بالخادم)
                string errorMessage = "";

                if (smtpEx.Message.Contains("No connection could be made"))
                {
                    errorMessage = " Unable to connect to the server. Please check the server and port settings.";
                }
                else if (smtpEx.Message.Contains("5.7.1"))
                {
                    errorMessage = " The settings are incorrect. Please verify the email and password.";
                }
                else
                {
                    errorMessage = "An unknown error occurred while connecting to the server.";
                }

                MessageBox.Show($"An error occurred while connecting to the mail server: {errorMessage}\n Error Details: {smtpEx.Message}", "Sending error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FormatException formatEx)
            {
                // إذا كانت المشكلة تتعلق بتنسيق البيانات (مثل الإيميل غير صحيح)
                MessageBox.Show($"Data format is incorrect: Please ensure the email is correct: {formatEx.Message}", " Error in sending", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // أي خطأ آخر
                MessageBox.Show($"Failed to send: An unexpected error occurred: {ex.Message}", " Sending error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void frmEmailSettings_Load(object sender, EventArgs e)
        {
            LoadSettingsFromFile();
        }



        private void guna2txtEmailAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2txtEmailAddress_Validating(object sender, CancelEventArgs e)
        {
            string emailAddress = guna2txtEmailAddress.Text.Trim();

            if (string.IsNullOrWhiteSpace(emailAddress))
                return;

            // التحقق من صحة تنسيق البريد الإلكتروني باستخدام التعبير المنتظم
            if (!clsValidatoin.ValidateEmail(emailAddress))
            {
                e.Cancel = true;
                errorProvider1.SetError(guna2txtEmailAddress, "Please enter a valid email address.");
            }
            else
            {
                // التحقق من النطاق
                string domain = emailAddress.Split('@').Last().ToLower();
                string[] commonDomains = { "gmail.com", "yahoo.com", "outlook.com", "hotmail.com", "icloud.com" };

                if (!commonDomains.Contains(domain))
                {
                    // تحذير المستخدم إذا كان النطاق غير معروف
                    MessageBox.Show(" There may be a typo in the email domain (e.g., gmail.com or yahoo.com). Please check the domain!", "Erorr", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // إذا كان التنسيق والنطاق صحيحين
                    errorProvider1.SetError(guna2txtEmailAddress, null);
                }
            }
        }

        private void guna2txtPort_Validating(object sender, CancelEventArgs e)
        {
            if (guna2txtPort.Text.Trim() == "")
                return;

            if (!int.TryParse(guna2txtPort.Text, out int portNumber) || portNumber < 1 || portNumber > 65535)
            {
                e.Cancel = true;
                errorProvider1.SetError(guna2txtPort, " Please enter a valid port number (from 1 to 65535).");
            }
            else
            {
                errorProvider1.SetError(guna2txtPort, null);
            }
        }

        private void guna2txtSMTPServer_Validating(object sender, CancelEventArgs e)
        {
            if (guna2txtSMTPServer.Text.Trim() == "")
                return;

            // تحقّق بسيط أن النص يشبه اسم نطاق أو عنوان خادم
            string smtp = guna2txtSMTPServer.Text.Trim();
            if (!Regex.IsMatch(smtp, @"^([a-zA-Z0-9\-]+\.)+[a-zA-Z]{2,}$"))
            {
                e.Cancel = true;
                errorProvider1.SetError(guna2txtSMTPServer, " Please enter a valid SMTP server address (e.g., smtp.example.com).");
            }
            else
            {
                errorProvider1.SetError(guna2txtSMTPServer, null);
            }

        }

        private void guna2txtAppPassword_Validating(object sender, CancelEventArgs e)
        {
            if (guna2txtAppPassword.Text.Trim() == "")
            {
                e.Cancel = true;
                errorProvider1.SetError(guna2txtAppPassword, " Please enter the email password.");
            }
            else if (guna2txtAppPassword.Text.Length < 8)
            {
                e.Cancel = true;
                errorProvider1.SetError(guna2txtAppPassword, "The password must be at least 8 characters long.");
            }
            else
            {
                errorProvider1.SetError(guna2txtAppPassword, null);
            }
        }
    }
}
