using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using Twilio.TwiML;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Twilio.Types;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace FatoraX.Customers
{
    public partial class frmPhoneCall : Form
    {


        // تعريف متغيرات لتخزين الإعدادات
        private string AccountSid;
        private string AuthToken;
        private string TwilioNumber;
        string _Number = "";
        public frmPhoneCall()
        {
            InitializeComponent();
        }

        public frmPhoneCall(string Number)
        {
            InitializeComponent();
            _Number = Number;
        }

        private void frmPhoneCall_Load(object sender, EventArgs e)
        {
            // قراءة البيانات من الملف عند تحميل الفورم
            LoadSettingsFromFile();
        }


        // الحصول على الرسالة بناءً على الاختيار
        private string GetMessageBasedOnSelection()
        {
            switch (guna2cmbMessageType.SelectedItem?.ToString())
            {
                case "Send a new invoice notification":
                    return " Hello, a new invoice has been issued to you. Please check it.";
                case "Send a reminder for overdue invoice":
                    return " Reminder: You have an overdue invoice. Please make the payment as soon as possible.";
                case "Send payment receipt confirmation":
                    return "Your payment has been successfully received. Thank you for using our services..";
                case "Enter custom text":
                    return txtCustomMessage.Text.Trim();
                default:
                    return string.Empty;
            }
        }

        // التحقق من الاتصال بالإنترنت بشكل غير متزامن
        private async Task<bool> CheckInternetConnectionAsync()
        {
            try
            {
                using (var client = new System.Net.Http.HttpClient())
                {
                    client.Timeout = TimeSpan.FromSeconds(5); // تحديد مهلة الاتصال
                    var result = await client.GetAsync("https://www.google.com");
                    return result.IsSuccessStatusCode;
                }
            }
            catch
            {
                return false;
            }
        }

        // تحميل الإعدادات من الملف النصي
        private void LoadSettingsFromFile()
        {
            try
            {
                string settingsFile = @"twilio_settings.txt";
                if (File.Exists(settingsFile))
                {
                    string content = File.ReadAllText(settingsFile).Trim();
                    string[] settings;

                    // فصل المحتوى بناءً على وجود '|' أو '\n'
                    if (content.Contains("|"))
                    {
                        settings = content.Split('|');
                    }
                    else
                    {
                        settings = content.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                    }

                    if (settings.Length == 3)
                    {
                        AccountSid = settings[0].Trim();
                        AuthToken = settings[1].Trim();
                        TwilioNumber = settings[2].Trim();
                    }
                    else
                    {
                        MessageBox.Show(" The file does not contain the settings data correctly..", " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("The settings file was not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reading the file.:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void guna2cmbMessageType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(guna2cmbMessageType.Text == "Custom text input")
            {
                txtCustomMessage.Visible = true;
                label1.Visible = true;
            }
            else
            {
                txtCustomMessage.Visible = false;
                label1.Visible = false;
            }
           

        }

        private async void guna2btnCall_Click(object sender, EventArgs e)
        {
            try
            {
                // تأكد من أن الإعدادات قد تم تحميلها بنجاح من الملف
                if (string.IsNullOrWhiteSpace(AccountSid) ||
                    string.IsNullOrWhiteSpace(AuthToken) ||
                    string.IsNullOrWhiteSpace(TwilioNumber))
                {
                    MessageBox.Show(" Please check the connection settings.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string toNumber = "";
                // إدخال الرقم
                if (_Number == "")
                {
                     toNumber = Microsoft.VisualBasic.Interaction.InputBox("Enter the phone number you want to call (in international format)", "Test Connection", "+966xxxxxxxxx");

                }
                else
                {
                    toNumber = _Number;
                }

                if (!string.IsNullOrEmpty(toNumber))
                {
                    // تحديد النص الذي سيتم قراءته بناءً على اختيار المستخدم
                    string message = GetMessageBasedOnSelection();

                    if (string.IsNullOrEmpty(message))
                    {
                        MessageBox.Show("  Please select or enter a message text.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // التأكد من الاتصال بالإنترنت
                    bool isConnected = await CheckInternetConnectionAsync();
                    if (!isConnected)
                    {
                        MessageBox.Show(" No internet connection. Please check your connection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // الاتصال بـ Twilio
                    TwilioClient.Init(AccountSid.Trim(), AuthToken.Trim());

                    var call = await CallResource.CreateAsync(
                        to: new PhoneNumber(toNumber),
                        from: new PhoneNumber(TwilioNumber.Trim()),
                        twiml: new Twiml($"<Response><Say language=\"ar-SA\" voice=\"Polly.Zeina\">{message}</Say></Response>")
                    );

                    MessageBox.Show($"The connection has started. Connection ID: {call.Sid}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during connection:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TwilioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmTwilioSettings frm = new frmTwilioSettings();
            frm.ShowDialog();
            this.Close();
        }
    }

}

