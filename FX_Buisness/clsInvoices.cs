using FX_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FX_Buisness
{
    public class clsInvoices
    {

        public enum enMode { AddNew = 0, Update = 1 };

        private enMode Mode;

        public int InvoiceId { get; set; }

        public clsUser SelectUserInfo;
        public int UserId { get; set; }

        public clsCustomers SelectCustomerInfo;
        public int CustomerId { get; set; }
        public DateTime Date { get; set; }
        public string Notes { get; set; }
        public float PaidAmount { get; set; }
        public float TotalAmount { get; set; }

        public clsInvoices()
        {
            Mode = enMode.AddNew;
            InvoiceId = -1;
            UserId = -1;
            CustomerId = -1;
            Date = DateTime.Now;
            Notes = string.Empty;
            PaidAmount = 0;
            TotalAmount = 0;
        }


        public clsInvoices(int InvoiceId, int CustomerId, DateTime Date, int UserId, float TotalAmount, string Notes, float PaidAmount)
        {
            Mode = enMode.Update;
            this.InvoiceId = InvoiceId;
            this.UserId = UserId;
            this.CustomerId = CustomerId;
            this.Date = Date;
            this.Notes = Notes;
            this.PaidAmount = PaidAmount;
            this.TotalAmount = TotalAmount;

            SelectCustomerInfo = clsCustomers.Find(CustomerId);
            SelectUserInfo = clsUser.Find(UserId);
        }

        public static clsInvoices Find(int InvoiceId)
        {
            int CustomerId = -1, UserId = -1;
            float TotalAmount = -1, PaidAmount = -1;
            DateTime Date = DateTime.Now;
            string Notes = "";


            bool IsFound = clsInvoicesData.GetCustomerByInvoiceId(InvoiceId, ref CustomerId, ref Date, ref UserId,
                ref TotalAmount, ref Notes, ref PaidAmount);
            if (IsFound)
            {
                return new clsInvoices(InvoiceId, CustomerId, Date, UserId, TotalAmount, Notes, PaidAmount);
            }
            else
            {
                return null;
            }

        }
        private bool _AddNewInvoices()
        {
            this.InvoiceId = clsInvoicesData.AddNewInvoice(this.UserId, this.CustomerId, this.Date, this.TotalAmount, this.PaidAmount, this.Notes);

            return this.InvoiceId != -1;
        }

        private bool _UpdateInvoices()
        {
            return clsInvoicesData.UpdateInvoices(this.InvoiceId, this.UserId, this.CustomerId, this.Date,
                this.TotalAmount, this.PaidAmount, this.Notes);
        }

        public static bool DeleteInvoices(int InvoiceId)
        {
            return clsInvoicesData.DeleteInvoices(InvoiceId);
        }

        public static DataTable GetAllInvoices()
        {

            return clsInvoicesData.GetAllInvoices();
        }

        public static DataTable GetAllTotalSales()
        {

            return clsInvoicesData.GetAllTotalSales();
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    {
                        if (_AddNewInvoices())
                        {
                            Mode = enMode.Update;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                case enMode.Update:
                    return _UpdateInvoices();

            }
            return false;
        }
    }
}
