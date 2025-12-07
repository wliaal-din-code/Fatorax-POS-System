using FX_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FX_Buisness
{
    public class clsInvoiceDetails
    {

        public enum enMode { AddNew = 0, Update = 1 }
        enMode Mode;
        public int DetailId { get; set; }
        public int InvoiceId { get; set; }
        public clsInvoices InvoicesInfo;
        public int ProductId { get; set; }
        public clsProducts ProductsInfo;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Total { get; set; }
        public decimal PaidAmount { get; set; }
        public DateTime Date { get; set; }
        //8
        public clsInvoiceDetails()
        {
            DetailId = 0;
            InvoiceId = 0;
            ProductId = 0;
            Quantity = 0;
            UnitPrice = 0;
            Total = 0;
            PaidAmount = 0;
            Date = DateTime.Now;
            Mode = enMode.AddNew;
        }

        public clsInvoiceDetails(int Detailid, int invoiceId, int productId, int quantity, decimal unitPrice, decimal total,  DateTime Date)
        {
            DetailId = Detailid;
            InvoiceId = invoiceId;
            InvoicesInfo = clsInvoices.Find(invoiceId);
            ProductId = productId;
            ProductsInfo = clsProducts.Find(productId);
            Quantity = quantity;
            UnitPrice = unitPrice;
            Total = total;
            this.PaidAmount = PaidAmount;
            this.Date = Date;
            Mode = enMode.Update;
        }

        private bool _AddNewInvoiceDetail()
        {
            this.DetailId = clsInvoiceDetailsData.AddNewInvoiceDetail(this.InvoiceId, this.ProductId, this.Quantity, this.UnitPrice, this.Total, this.Date);

            return (this.DetailId != -1);
        }

        public static DataTable GetAllInvoiceDetail()
        {
            return clsInvoiceDetailsData.GetAllInvoiceDetails();
        }



        private bool _UpdateInvoiceDetail()
        {
            return clsInvoiceDetailsData.UpdateInvoiceDetail(this.DetailId, this.InvoiceId, this.ProductId, this.Quantity, this.UnitPrice, this.Total, this.Date);
        }

        public static bool DeleteInvoiceDetail(int DetailId)
        {
            return clsInvoiceDetailsData.DeleteInvoiceDetail(DetailId);
        }

        public static clsInvoiceDetails Find(int DetailId)
        {
            int invoiceId = 0, productId = 0, quantity = 0;
            decimal unitPrice = 0, total = 0;
            DateTime Date = DateTime.Now;
            bool IsFound = clsInvoiceDetailsData.GetInvoiceDetailByDetailId(DetailId, ref invoiceId, ref productId, ref quantity, ref unitPrice, ref total, ref Date);

            if (IsFound)
            {
                return new clsInvoiceDetails(DetailId, invoiceId, productId, quantity, unitPrice, total, Date);
            }
            else
            {
                return null;
            }

        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    {
                        if (_AddNewInvoiceDetail())
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
                    return _UpdateInvoiceDetail();

            }
            return false;
        }
    }
}
