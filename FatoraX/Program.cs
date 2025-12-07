using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using FatoraX.Customers;
using FatoraX.FinancialReports;
using FatoraX.InvoiceDetails;
using FatoraX.Invoices;
using FatoraX.Login;
using FatoraX.People;
using FatoraX.Products;
using FatoraX.Users;

namespace FatoraX
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

       
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

                // عند وجود إعدادات محفوظة → أظهر البرنامج الرئيسي
                Application.Run(new frmLogin());
            }
        }
    }

