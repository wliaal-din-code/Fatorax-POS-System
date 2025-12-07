using FX_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FX_Buisness
{
    public class clsInvoec
    {

        public enum enMode { AddNew = 0, Update = 1 };

        private enMode Mode;

        public int InvoiceId { get; set; }

        public clsUser SelectUserInfo;
        public int UserId { get; set; }

        public clsCustomers SelectCustomerInfo;
        public int CustomerId { get; set; }
        public DateTime invoiceDate { get; set; }
        public string Notes { get; set; }
        public float SubTotal { get; set; }
        public float Taxpercent { get; set; }
        public float TotalAmount { get; set; }
        public float TaxAmount { get; set; }
        public int paymentstatus { get; set; }
        public bool IsTaxIncluded { get; set; }
        public float PaidAmount { get; set; }


        public clsInvoec()
        {
            InvoiceId = -1;
            UserId = -1;
            CustomerId = -1;
            SubTotal = 0;
            Taxpercent = 0;
            TotalAmount = 0;
            TaxAmount = 0;
            paymentstatus = 1;
            PaidAmount = 0;
            IsTaxIncluded = true;
            invoiceDate = DateTime.Now;
            Notes = "";
            Mode = enMode.AddNew;
        }


        public clsInvoec(int InvoiceId, int CustomerId, DateTime invoiceDate, int UserId, float SubTotal, float Taxpercent, float TaxAmount, float TotalAmount,
            string Notes, int paymentstatus, bool IsTaxIncluded, float PaidAmount)
        {
            this.InvoiceId = InvoiceId;
            this.UserId = UserId;
            this.CustomerId = CustomerId;
            this.SubTotal = SubTotal;
            this.Taxpercent = Taxpercent;
            this.TotalAmount = TotalAmount;
            this.TaxAmount = TaxAmount;
            this.paymentstatus = paymentstatus;
            this.IsTaxIncluded = IsTaxIncluded;
            this.invoiceDate = invoiceDate;
            this.PaidAmount = PaidAmount;
            this.Notes = Notes;
            Mode = enMode.Update;

            SelectCustomerInfo = clsCustomers.Find(CustomerId);
            SelectUserInfo = clsUser.Find(UserId);
        }

        public static clsInvoec Find(int InvoiceId)
        {
            int CustomerId = -1, UserId = -1;
            float SubTotal = 0, TaxAmount = 0, Taxpercent = 0, TotalAmount = 0, PaidAmount = 0;
            DateTime invoiceDate = DateTime.Now;
            string Notes = "";
            bool IsTaxIncluded = true;
            int paymentstatus = 1;

            bool IsFound = clsInvoecData.GetCustomerByInvoiceId(InvoiceId, ref CustomerId, ref invoiceDate, ref UserId, ref SubTotal, ref Taxpercent, ref TaxAmount, ref TotalAmount,
             Notes, paymentstatus, ref IsTaxIncluded, ref PaidAmount);
            if (IsFound)
            {
                return new clsInvoec(InvoiceId, CustomerId, invoiceDate, UserId, SubTotal, Taxpercent, TaxAmount, TotalAmount,
             Notes, paymentstatus, IsTaxIncluded, PaidAmount);
            }
            else
            {
                return null;
            }
        }

        public static bool GetNetLable(ref float SubTotal, ref float TaxAmount, ref float PaidAmount ,
       ref float TotalAmount, ref float Taklaf,ref float Rabh, DateTime FromDate, DateTime ToDate, string paymentstatus,ref float RabhPaid)
        {
            return clsInvoecData.GetNetLable(ref SubTotal,ref TaxAmount,ref TotalAmount,ref PaidAmount,ref Taklaf, ref Rabh, FromDate, ToDate,  paymentstatus,ref RabhPaid);

        }
        public static bool GetAllLable(ref float SubTotal, ref float TaxAmount, ref float PaidAmount ,
       ref float TotalAmount, ref float Taklaf,ref float Rabh, DateTime FromDate, DateTime ToDate,ref float RabhPaid)
        {
            return clsInvoecData.GetAllLable(ref SubTotal,ref TaxAmount,ref TotalAmount,ref PaidAmount,ref Taklaf, ref Rabh, FromDate, ToDate,ref RabhPaid);

        }
        public static bool GetNetLableProj(ref float SubTotal, ref float TaxAmount, ref float PaidAmount,
      ref float TotalAmount, ref float Taklaf, ref float Rabh, DateTime FromDate, DateTime ToDate,string Type)
        {
            return clsInvoecData.GetNetLableProj(ref SubTotal, ref TaxAmount, ref TotalAmount, ref PaidAmount, ref Taklaf, ref Rabh, FromDate, ToDate, Type);

        }

        private bool _AddNewInvoices()
        {
            this.InvoiceId = clsInvoecData.AddNewInvoice(this.CustomerId, this.invoiceDate, this.UserId, this.SubTotal, this.Taxpercent, this.TaxAmount, this.TotalAmount,
           this.Notes, this.paymentstatus, this.IsTaxIncluded, this.PaidAmount);
            return this.InvoiceId != -1;
        }

        private bool _UpdateInvoices()
        {
            return clsInvoecData.UpdateInvoices(this.InvoiceId, this.CustomerId, this.invoiceDate, this.UserId, this.SubTotal, this.Taxpercent, this.TaxAmount, this.TotalAmount,
           this.Notes, this.paymentstatus, this.IsTaxIncluded, this.PaidAmount);
        }

        public static bool DeleteInvoices(int InvoiceId)
        {
            return clsInvoecData.DeleteInvoices(InvoiceId);
        }


        public static DataTable GetAllTotalSales()
        {

            return clsInvoecData.GetAllTotalSales();
        }
        public static DataTable GetAllInvoices()
        {

            return clsInvoecData.GetAllInvoices();
        }
       


        public static DataTable GetAllNetProfit(DateTime dtFrom, DateTime dtTo, string paymentstatus)
        {

            return clsInvoecData.GetAllNetProfit(dtFrom, dtTo, paymentstatus);
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
