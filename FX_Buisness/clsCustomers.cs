using FX_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FX_Buisness
{
    public class clsCustomers
    {

        enum enMode { Add = 0, Update = 1 }
        enMode Mode = enMode.Add;
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Notes { get; set; }

        public clsCustomers()
        {
            this.CustomerId = -1;
            this.CustomerName = "";
            this.Phone = "";
            this.Email = "";
            this.Address = "";
            this.Notes = "";
            Mode = enMode.Add;
        }

        private clsCustomers(int customerId, string customerName, string phone, string email, string address, string notes)
        {
            this.CustomerId = customerId;
            this.CustomerName = customerName;
            this.Phone = phone;
            this.Email = email;
            this.Address = address;
            this.Notes = notes;
            Mode = enMode.Update;
        }

        private bool _AddNewCustomer()
        {
            this.CustomerId = clsCustomersData.AddNewCustomers(this.CustomerName, this.Phone, this.Email, this.Address, this.Notes);

            return (this.CustomerId != -1);
        }

        private bool _UpdateCustomer()
        {
            return clsCustomersData.UpdateCustomer(this.CustomerId, this.CustomerName, this.Phone, this.Email, this.Address, this.Notes);
        }

        private bool _DeleteCustomer(int CustomerId)
        {
            return clsCustomersData.DeleteCustomer(CustomerId);
        }


        public static bool DeleteCustomer(int CustomerId)
        {
            return clsCustomersData.DeleteCustomer(CustomerId);
        }

        public static clsCustomers Find(int CustomerId)
        {
            string CustomerName = "", Phone = "", Email = "", Address = "", Notes = "";


            bool IsFound = clsCustomersData.GetCustomerByCustomerId(CustomerId, ref CustomerName, ref Phone, ref Email, ref Address, ref Notes);

            if (IsFound)
            {
                return new clsCustomers(CustomerId, CustomerName, Phone, Email, Address, Notes);
            }
            else
            {
                return null;
            }

        }

        public static clsCustomers Find(string CustomerName)
        {
            string Phone = "", Email = "", Address = "", Notes = "";
            int CustomerId = -1;

            bool IsFound = clsCustomersData.GetCustomerByName(ref CustomerId, CustomerName, ref Phone, ref Email, ref Address, ref Notes);

            if (IsFound)
            {
                return new clsCustomers(CustomerId, CustomerName, Phone, Email, Address, Notes);
            }
            else
            {
                return null;
            }

        }

        public static DataTable GetAllCustomers()
        {
            return clsCustomersData.GetAllCustomers();
        }

        public static DataTable GetMoreCustomersPuy(DateTime dtfrom, DateTime dtto)
        {
            return clsCustomersData.GetMoreCustomersPuy(dtfrom, dtto);
        }
        public static DataTable GetMoreCustomerslatetoPuy(DateTime dtfrom, DateTime dtto)
        {
            return clsCustomersData.GetMoreCustomerslatetoPuy(dtfrom, dtto);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.Add:
                    {
                        if (_AddNewCustomer())
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
                    return _UpdateCustomer();

            }
            return false;
        }

    }
}
