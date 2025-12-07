using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.VisualBasic;
using System.Windows.Forms;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using System.Text.RegularExpressions;

namespace FatoraX.Customers
{
    public partial class frmTwilioSettings : Form
    {
        private string settingsFile = Application.StartupPath + @"\twilio_settings.txt";

        public frmTwilioSettings()
        {
            InitializeComponent();
            LoadSettings();
        }

        private void frmTwilioSettings_Load(object sender, EventArgs e)
        {
            LoadSettingsFromFile();
        }


        private void LoadSettingsFromFile()
        {
            try
            {
                string settingsFile = @"twilio_settings.txt";

                // التحقق إذا كان الملف موجودًا
                if (File.Exists(settingsFile))
                {
                    // قراءة السطر بالكامل
                    string content = File.ReadAllText(settingsFile).Trim();

                    // إذا كان السطر يحتوي على '|' نفصل البيانات
                    if (content.Contains("|"))
                    {
                        string[] settings = content.Split('|');

                        // التأكد من وجود 3 عناصر فقط
                        if (settings.Length == 3)
                        {
                            // تعبئة الـ TextBoxes بالبيانات من الملف
                            guna2txtAccountSid.Text = settings[0].Trim();
                            guna2txtAuthToken.Text = settings[1].Trim();
                            guna2txtTwilioNumber.Text = settings[2].Trim();
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
                
                MessageBox.Show("Some Twilio fields are incorrect! Hover over the red icons to see error details in the settings ", "Error validating the data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            try
            {
                // تنظيف القيم من أي أسطر جديدة
                string Clean(string input) => input.Replace("\r", "").Replace("\n", "");

                // تجميع الإعدادات في سطر واحد
                string settings = string.Join("|",
                    Clean(guna2txtAccountSid.Text),
                    Clean(guna2txtAuthToken.Text),
                    Clean(guna2txtTwilioNumber.Text));

                // حفظ الإعدادات في الملف
                File.WriteAllText(settingsFile, settings);

                MessageBox.Show("Settings have been successfully saved", "Excellent", MessageBoxButtons.OK, MessageBoxIcon.Information);


               

                this.Hide();
                frmPhoneCall frm = new frmPhoneCall();
                frm.ShowDialog();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while saving the settings " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void LoadSettings()
        {
            if (File.Exists(settingsFile))
            {
                string[] lines = File.ReadAllLines(settingsFile);
                if (lines.Length >= 3)
                {
                    guna2txtAccountSid.Text = lines[0];
                    guna2txtAuthToken.Text = lines[1];
                    guna2txtTwilioNumber.Text = lines[2];
                }
            }
        }

        private void guna2btnTestCall_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {

                MessageBox.Show("Some Twilio fields are incorrect! Hover over the red icons to see error details in the settings. ", "Error in data validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            try
            {
                // التأكد من أن الحقول ليست فارغة
                if (string.IsNullOrWhiteSpace(guna2txtAccountSid.Text) ||
                    string.IsNullOrWhiteSpace(guna2txtAuthToken.Text) ||
                    string.IsNullOrWhiteSpace(guna2txtTwilioNumber.Text))
                {
                    MessageBox.Show("Please fill in all the fields before testing the connection", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // الحصول على الرقم من المستخدم
                string toNumber = Microsoft.VisualBasic.Interaction.InputBox("📞 Enter the phone number to call (in international format)", "Connection test", "+966xxxxxxxxx");

                // التحقق من صحة الرقم
                if (string.IsNullOrWhiteSpace(toNumber))
                {
                    MessageBox.Show(" The phone number is invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // تهيئة اتصال Twilio
                TwilioClient.Init(guna2txtAccountSid.Text.Trim(), guna2txtAuthToken.Text.Trim());

                // محاولة إجراء المكالمة
                var call = CallResource.Create(
                    to: new PhoneNumber(toNumber),
                    from: new PhoneNumber(guna2txtTwilioNumber.Text.Trim()),
                    url: new Uri("http://demo.twilio.com/docs/voice.xml")
                );

                // إذا تمت المكالمة بنجاح
                MessageBox.Show($"The connection has been successfully initiated. Connection ID: {call.Sid}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // عرض رسالة الخطأ باللغة العربية
                string errorMessage = TranslateError(ex.Message);
                MessageBox.Show($"Error during connection:\n{errorMessage}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        // دالة لترجمة الأخطاء
        private string TranslateError(string englishError)
        {
            if (englishError.Contains("Authenticate"))
                return "❌Data verification failed. Please ensure the SID and Token are correct.";
            else if (englishError.Contains("not a valid phone number"))
                return "❌ The entered phone number is incorrect. Please make sure to enter the number in international format.";
            else if (englishError.Contains("HTTP"))
                return "❌ Internet connection or Twilio service error. Please ensure you are connected to the network.";
            else if (englishError.Contains("balance") || englishError.Contains("insufficient funds"))
                return "❌Insufficient balance in the Twilio account.";
            else if (englishError.Contains("forbidden") || englishError.Contains("Permission"))
                return "❌ You do not have permission to perform this action. Please check the account settings.";
            else if (englishError.Contains("URL") || englishError.Contains("Document at URL"))
                return "❌ There was an issue with loading the audio contact file. Please check the XML link";
            else if (englishError.Contains("inactive"))
                return "❌ Twilio account is not activated. Please activate the account first.";
            else
                return "❌ Unknown error: " + englishError;
        }

        private void guna2txtAccountSid_Validating(object sender, CancelEventArgs e)
        {
            string sid = guna2txtAccountSid.Text.Trim();

            if (sid == "")
            {
                e.Cancel = true;
                errorProvider1.SetError(guna2txtAccountSid, "Please enter the Account SID.");
            }
            else if (sid.Length < 10 || sid.Length > 40)
            {
                e.Cancel = true;
                errorProvider1.SetError(guna2txtAccountSid, "he account number appears to be incorrect. Please check the length or format.");
            }
            else
            {
                errorProvider1.SetError(guna2txtAccountSid, null);
            }
        }

        private void guna2txtAuthToken_Validating(object sender, CancelEventArgs e)
        {
            string authToken = guna2txtAuthToken.Text.Trim();

            if (authToken == "")
            {
                e.Cancel = true;
                errorProvider1.SetError(guna2txtAuthToken, "Please enter the authentication token (Auth Token).");
            }
            else if (authToken.Length < 32 || authToken.Length > 64)
            {
                e.Cancel = true;
                errorProvider1.SetError(guna2txtAuthToken, "The authentication token is incorrect. Please make sure it has the correct length.");
            }
            else
            {
                errorProvider1.SetError(guna2txtAuthToken, null);
            }
        }

        private void guna2txtTwilioNumber_Validating(object sender, CancelEventArgs e)
        {
            string phoneNumber = guna2txtTwilioNumber.Text.Trim();

            if (phoneNumber == "")
            {
                e.Cancel = true;
                errorProvider1.SetError(guna2txtTwilioNumber, "Please enter the Twilio number.");
            }
            else if (!Regex.IsMatch(phoneNumber, @"^\+?[1-9]\d{1,14}$"))
            {
                e.Cancel = true;
                errorProvider1.SetError(guna2txtTwilioNumber, "The Twilio number is incorrect. Please ensure it is formatted correctly (e.g., +1234567890)).");
            }
            else
            {
                errorProvider1.SetError(guna2txtTwilioNumber, null);
            }
        }
    }
}
