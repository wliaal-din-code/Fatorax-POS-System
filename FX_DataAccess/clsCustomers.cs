using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FX_DataAccess
{
    public class clsCustomersData
    {
        public static bool GetCustomerByCustomerId(int CustomerId, ref string CustomerName, ref string Phone, ref string Email, ref string Address, ref string Notes)
        {
            bool IsFound = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    string query = @"select * from Customers Where CustomerId=@CustomerId";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CustomerId", CustomerId);

                        connection.Open();

                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            IsFound = true;
                            CustomerName = (string)reader["Name"];
                            Phone = Convert.ToString(reader["Phone"]);

                            if (reader["Email"] != System.DBNull.Value)
                                Email = (string)reader["Email"];
                            else
                                Email = "";

                            if (reader["Address"] != System.DBNull.Value)
                                Address = (string)reader["Address"];
                            else
                                Address = "";
                            if (reader["Notes"] != System.DBNull.Value)
                                Notes = (string)reader["Notes"];
                            else
                                Notes = "";
                            
                          

                        }
                        else
                        {
                            IsFound = false;
                        }
                        reader.Close();

                    }
                }
            }

            catch (Exception ex)
            {
                clsEventLog.LogOrCreateEventSoures(ex.Message);
            }

            return IsFound;
        }

        public static bool GetCustomerByName(ref int CustomerId, string CustomerName, ref string Phone, ref string Email, ref string Address, ref string Notes)
        {
            bool IsFound = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    string query = @"select * from Customers Where Name=@Name";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", CustomerName);

                        connection.Open();

                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            IsFound = true;
                            CustomerId = (int)reader["CustomerId"];

                            if (reader["Phone"] != System.DBNull.Value)
                                Phone = (string)reader["Phone"];
                            else
                                Phone = "";

                            if (reader["Address"] != System.DBNull.Value)
                                Address = (string)reader["Address"];
                            else
                                Address = "";

                            if (reader["Email"] !=  System.DBNull.Value)
                                Email = (string)reader["Email"];
                            else
                                Email = "";

                            if (reader["Notes"] == System.DBNull.Value)
                                Notes = "";
                            else
                                Notes = (string)reader["Notes"];

                        }
                        else
                        {
                            IsFound = false;
                        }
                        reader.Close();

                    }
                }
            }

            catch (Exception ex)
            {
                clsEventLog.LogOrCreateEventSoures(ex.Message);
            }

            return IsFound;
        }

        public static DataTable GetAllCustomers()
        {
            DataTable dt = new DataTable();



            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            {
                string Query = "Select CustomerId, Name,Phone,Email from Customers";
                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();


                        if (reader.HasRows)
                        {
                            dt.Load(reader);
                        }
                        reader.Close();
                    }

                    catch (Exception ex)
                    {
                        clsEventLog.LogOrCreateEventSoures(ex.Message);
                    }
                }
            }
            return dt;
        }



        public static DataTable GetMoreCustomersPuy(DateTime dtfrom, DateTime dtto)
        {
            DataTable _dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            {
                string Query = @"select Customers.CustomerId ,Customers.Name,Customers.Phone ,Count(Invoice.InvoiceId) AS InvoiceCount,
                            Sum(InvoiceDetails.Total) AS TotalPurchases,sum(InvoiceDetails.Total) as Total,
                            sum(Invoice.SubTotal) as SubTotal,sum(Invoice.TaxAmount) as TaxAmount,sum(Invoice.TotalAmount) as TotalAmount
                            ,sum(Invoice.PaidAmount) as PaidAmount
                            from 
                             Invoice join Customers on Invoice.CustomerId = Customers.CustomerId
                             JOIN InvoiceDetails on InvoiceDetails.InvoiceId = Invoice.InvoiceId
    
                                 WHERE Invoice.invoiceDate BETWEEN @dtfrom and @dtto
                       
                             group by Customers.CustomerId,Customers.Name,Customers.Phone 
                         
                             ORDER BY 
                                TotalPurchases DESC  ";
                SqlCommand command = new SqlCommand(Query, connection);
                command.Parameters.AddWithValue("@dtfrom", dtfrom);

                DateTime dtToWithTime = dtto.Date.AddDays(1).AddTicks(-1);
                command.Parameters.AddWithValue("@dtto", dtToWithTime);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        _dt.Load(reader);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    clsEventLog.LogOrCreateEventSoures(ex.Message);
                }
                finally
                {
                    connection.Close();
                }

                return _dt;
            }
        }
        public static DataTable GetMoreCustomerslatetoPuy(DateTime dtfrom, DateTime dtto)
        {
            DataTable _dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            {
                string Query = @"
                            select Customers.CustomerId ,Customers.Name,Invoice.invoiceDate ,Customers.Phone ,
                            Invoice.TotalAmount as Amond, Invoice.PaidAmount   ,Invoice.TotalAmount - Invoice.PaidAmount as Remmender,paymentstatus = case 
       
                             when paymentstatus = 2 then N'unpaid'
                             when paymentstatus = 3 then N'partial'
                             else
                             N'nothing'
                             end
                            from 
                             Invoice join Customers on Invoice.CustomerId = Customers.CustomerId
                             WHERE Invoice.paymentstatus !=1 and Invoice.invoiceDate BETWEEN @dtfrom and @dtto;";
                SqlCommand command = new SqlCommand(Query, connection);
                command.Parameters.AddWithValue("@dtfrom", dtfrom);
                DateTime dtToWithTime = dtto.Date.AddDays(1).AddTicks(-1);
                command.Parameters.AddWithValue("@dtto", dtToWithTime);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        _dt.Load(reader);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    clsEventLog.LogOrCreateEventSoures(ex.Message);
                }
                finally
                {
                    connection.Close();
                }

                return _dt;
            }
        }

        public static int AddNewCustomers(string CustomerName, string Phone, string Email, string Address, string Notes)
        {
            int CustomerId = -1;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            {
                string query = @"insert into Customers (Name,Phone,Email, Address,Notes) Values (@Name,@Phone,@Email, @Address,@Notes)
                                      select SCOPE_IDENTITY()";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", CustomerName);

                    if (Phone != "" && Phone != null)
                        command.Parameters.AddWithValue("@Phone", Phone);
                    else
                        command.Parameters.AddWithValue("@Phone", System.DBNull.Value);

                    if (Email != "" && Email != null)
                        command.Parameters.AddWithValue("@Email", Email);
                    else
                        command.Parameters.AddWithValue("@Email", System.DBNull.Value);

                    if (Address != "")
                        command.Parameters.AddWithValue("@Address", Address);
                    else
                        command.Parameters.AddWithValue("@Address","");

                    if (Notes != "" && Notes != null)
                        command.Parameters.AddWithValue("@Notes", Notes);
                    else
                        command.Parameters.AddWithValue("@Notes", System.DBNull.Value);

                    try
                    {
                        connection.Open();
                        object Result = command.ExecuteScalar();


                        if (Result != null && int.TryParse(Result.ToString(), out int InsertId))
                        {
                            CustomerId = InsertId;
                        }
                    }

                    catch (Exception ex)
                    {
                        clsEventLog.LogOrCreateEventSoures(ex.Message);
                    }
                }

            }
            return CustomerId;
        }

        public static bool UpdateCustomer(int CustomerId, string CustomerName, string Phone, string Email, string Address, string Notes)
        {
            int rowAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    string query = @"
                                   update Customers set Name=@Name,
                                   Phone=@Phone,
                                   Email=@Email,
                                   Address=@Address,
                                   Notes=@Notes
                                   where CustomerId=@CustomerId";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CustomerId", CustomerId);
                  
                        command.Parameters.AddWithValue("@Name", CustomerName);


                        if (Phone != "" && Phone != null)
                            command.Parameters.AddWithValue("@Phone", Phone);
                        else
                            command.Parameters.AddWithValue("@Phone", System.DBNull.Value);

                        if (Email != "")
                        {
                            command.Parameters.AddWithValue("@Email", Email);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@Email", System.DBNull.Value);
                        }

                        if (Address != "")
                        {
                            command.Parameters.AddWithValue("@Address", Address);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@Address", System.DBNull.Value);
                        }

                        if (Notes != "")
                        {
                            command.Parameters.AddWithValue("@Notes", Notes);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@Notes", System.DBNull.Value);
                        }

                        connection.Open();

                        rowAffected = command.ExecuteNonQuery();


                    }
                }
            }

            catch (Exception ex)
            {
                clsEventLog.LogOrCreateEventSoures(ex.Message);
            }

            return (rowAffected > 0);
        }

        public static bool DeleteCustomer(int CustomerId)
        {
            int rowAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    string query = @"Delete  from Customers Where CustomerId=@CustomerId";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CustomerId", CustomerId);

                        connection.Open();

                        rowAffected = command.ExecuteNonQuery();

                    }
                }
            }

            catch (Exception ex)
            {
                clsEventLog.LogOrCreateEventSoures(ex.Message);
            }
            return (rowAffected > 0);

        }
    }
}
