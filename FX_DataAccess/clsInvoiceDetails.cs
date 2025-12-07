using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FX_DataAccess
{
    public class clsInvoiceDetailsData
    {

        public static bool GetInvoiceDetailByDetailId(int DetailId, ref int InvoiceId, ref int ProductId, ref int Quantity, ref decimal UnitPrice, ref decimal Total,ref DateTime Date)
        {
            bool IsFound = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    string query = @"SELECT * FROM InvoiceDetails WHERE DetailId = @DetailId;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DetailId", DetailId);

                        connection.Open();

                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            IsFound = true;
                            InvoiceId = (int)reader["InvoiceId"];
                            ProductId = (int)reader["ProductId"];
                            Quantity = (int)reader["Quantity"];
                            UnitPrice = (decimal)reader["UnitPrice"];
                            Total = (decimal)reader["Total"];
                            Date = (DateTime)reader["Date"];
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

        public static DataTable GetAllInvoiceDetails()
        {
            DataTable _dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            {
                string Query = @"SELECT DetailId, InvoiceId,ProductId,Quantity,UnitPrice,Total,Date FROM InvoiceDetails";
                SqlCommand command = new SqlCommand(Query, connection);

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

        public static int AddNewInvoiceDetail(int InvoiceId, int ProductId, int Quantity, decimal UnitPrice, decimal Total, DateTime Date)
        {
            int DetailId = -1;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    string query = @"INSERT INTO InvoiceDetails (InvoiceId,ProductId,Quantity,UnitPrice,Total,Date) 
           VALUES (@InvoiceId,@ProductId,@Quantity,@UnitPrice,@Total,@Date) SELECT SCOPE_IDENTITY()";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@InvoiceId", InvoiceId);
                        command.Parameters.AddWithValue("@ProductId", ProductId);
                        command.Parameters.AddWithValue("@Quantity", Quantity);
                        command.Parameters.AddWithValue("@UnitPrice", UnitPrice);
                        command.Parameters.AddWithValue("@Total", Total);
                        command.Parameters.AddWithValue("@Date", Date);

                        connection.Open();
                        object Result = command.ExecuteScalar();

                        if (Result != null && int.TryParse(Result.ToString(), out int InsertId))
                        {
                            DetailId = InsertId;
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                clsEventLog.LogOrCreateEventSoures(ex.Message);
            }

            return DetailId;
        }

        public static bool UpdateInvoiceDetail(int DetailId, int InvoiceId, int ProductId, int Quantity, decimal UnitPrice, decimal Total, DateTime Date)
        {
            int rowAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    string query = @"
                                   UPDATE InvoiceDetails SET InvoiceId = @InvoiceId,
                                   ProductId = @ProductId,
                                   Quantity = @Quantity,
                                   UnitPrice = @UnitPrice,
                                   Total = @Total,
                                   
                                    Date = @Date
                                   WHERE DetailId = @DetailId";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DetailId", DetailId);
                        command.Parameters.AddWithValue("@InvoiceId", InvoiceId);
                        command.Parameters.AddWithValue("@ProductId", ProductId);
                        command.Parameters.AddWithValue("@Quantity", Quantity);
                        command.Parameters.AddWithValue("@UnitPrice", UnitPrice);
                        command.Parameters.AddWithValue("@Total", Total);
                        command.Parameters.AddWithValue("@Date", Date);

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

        public static bool DeleteInvoiceDetail(int DetailId)
        {
            int rowAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    string query = @"DELETE FROM InvoiceDetails WHERE DetailId = @DetailId";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DetailId", DetailId);

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
