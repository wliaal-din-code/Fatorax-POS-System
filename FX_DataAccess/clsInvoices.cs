using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FX_DataAccess
{
    public class clsInvoicesData
    {

        public static bool GetCustomerByInvoiceId(int InvoiceId, ref int CustomerId, ref DateTime Date, ref int UserId, ref float TotalAmount, ref string Notes, ref float PaidAmount)
        {
            bool IsFound = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    string query = @"select * from Invoices Where InvoiceId=@InvoiceId";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@InvoiceId", InvoiceId);

                        connection.Open();

                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            IsFound = true;
                            CustomerId = (int)reader["CustomerId"];
                            Date = (DateTime)reader["Date"];
                            UserId = (int)reader["UserId"];
                            TotalAmount = Convert.ToSingle(reader["TotalAmount"]);
                            PaidAmount = Convert.ToSingle(reader["PaidAmount"]);
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



        public static DataTable GetAllInvoices()
        {
            DataTable dt = new DataTable();


            try
            { 
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    string Query = @"Select Invoices.InvoiceId ,Customers.Name,Users.Username,Invoices.TotalAmount,Invoices.PaidAmount
                               ,Invoices.Date,Invoices.Notes from Invoices join Customers On Invoices.CustomerId = Customers.CustomerId
                              Join Users on Invoices.UserId = Users.UserId ;";
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            dt.Load(reader);
                        }
                        reader.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                clsEventLog.LogOrCreateEventSoures(ex.Message);
            }
            return dt;
        }


        public static DataTable GetAllTotalSales()
        {
            DataTable dt = new DataTable();


            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    string Query = @"Select Invoices.InvoiceId ,Customers.Name,Invoices.Date,Invoices.TotalAmount,Invoices.TaxRate,Invoices.TotalAmount * Invoices.TaxRate as 
                             TaxAmount,case 
                             when paymentstatus = 1 then N'مدفوع'
                             when paymentstatus = 2 then N'غير مدفوع'
                             when paymentstatus = 3 then N'مدفوع جزئيا'
                             else
                             N'لا شيء'
                             end
                             from Invoices join Customers On Invoices.CustomerId = Customers.CustomerId;";
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            dt.Load(reader);
                        }
                        reader.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                clsEventLog.LogOrCreateEventSoures(ex.Message);
            }
            return dt;
        }


        public static int AddNewInvoice(int UserId, int CustomerId, DateTime Date, float TotalAmount, float PaidAmount, string Notes)
        {
            int InvoiceId = -1;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    string query = @"insert into Invoices (UserId,CustomerId,Date, TotalAmount,PaidAmount,Notes) Values (@UserId,@CustomerId,@Date, @TotalAmount,@PaidAmount,@Notes)
                                      select SCOPE_IDENTITY()";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserId", UserId);
                        command.Parameters.AddWithValue("@CustomerId", CustomerId);
                        command.Parameters.AddWithValue("@Date", Date);
                        command.Parameters.AddWithValue("@TotalAmount", TotalAmount);
                        command.Parameters.AddWithValue("@PaidAmount", PaidAmount);
                        command.Parameters.AddWithValue("@Notes", Notes);

                        connection.Open();
                        object Result = command.ExecuteScalar();

                        if (Result != null && int.TryParse(Result.ToString(), out int InsertId))
                        {
                            InvoiceId = InsertId;
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                clsEventLog.LogOrCreateEventSoures(ex.Message);
            }

            return InvoiceId;
        }

        public static bool UpdateInvoices(int InvoiceId, int UserId, int CustomerId, DateTime Date, float TotalAmount, float PaidAmount, string Notes)
        {
            int RowAffected = -1;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    string query = @"Update Invoices set UserId = @UserId,CustomerId = @CustomerId,Date  = @Date, 
                                    TotalAmount =@TotalAmount ,PaidAmount = @PaidAmount ,Notes  = @Notes) 
                                      Where InvoiceId =  @InvoiceId     ";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@InvoiceId", InvoiceId);
                        command.Parameters.AddWithValue("@UserId", UserId);
                        command.Parameters.AddWithValue("@CustomerId", CustomerId);
                        command.Parameters.AddWithValue("@Date", Date);
                        command.Parameters.AddWithValue("@TotalAmount", TotalAmount);
                        command.Parameters.AddWithValue("@PaidAmount", PaidAmount);
                        command.Parameters.AddWithValue("@Notes", Notes);

                        connection.Open();
                        RowAffected = command.ExecuteNonQuery();

                    }
                }
            }

            catch (Exception ex)
            {
                clsEventLog.LogOrCreateEventSoures(ex.Message);
            }

            return RowAffected > 0;
        }
        public static bool DeleteInvoices(int InvoiceId)
        {
            int rowAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    string query = @"Delete  from Invoices Where InvoiceId=@InvoiceId";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@InvoiceId", InvoiceId);

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
