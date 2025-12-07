using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FX_DataAccess
{
    public class clsProductsData
    {

        public static DataTable GetAllProducts()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            {
                string query = "SELECT * FROM Products";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            dt.Load(reader);
                        }
                    }
                    catch (Exception ex)
                    {
                        clsEventLog.LogOrCreateEventSoures(ex.Message);
                    }
                }
            }

            return dt;
        }
        public static DataTable GetAllProductSCok()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            {
                string query = "SELECT * FROM Products WHERE Stock != 0";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            dt.Load(reader);
                        }
                    }
                    catch (Exception ex)
                    {
                        clsEventLog.LogOrCreateEventSoures(ex.Message);
                    }
                }
            }

            return dt;
        }

        public static int AddNewProduct(string Name, decimal Price, decimal Cost, int Stock)
        {
            int ProductId = -1;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            {
                string query = @"INSERT INTO Products (Name,Price,Cost,Stock) 
                                 VALUES (@Name,@Price,@Cost,@Stock) SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", Name);
                    command.Parameters.AddWithValue("@Price", Price);
                    command.Parameters.AddWithValue("@Cost", Cost);
                    command.Parameters.AddWithValue("@Stock", Stock);

                    try
                    {
                        connection.Open();
                        object reslut = command.ExecuteScalar();

                        if (reslut != null && int.TryParse(reslut.ToString(), out int insertid))
                        {
                            ProductId = insertid;
                        }
                    }
                    catch (Exception ex)
                    {
                        clsEventLog.LogOrCreateEventSoures(ex.Message);
                    }
                }

                return ProductId;
            }


        }

        public static bool UpdateProduct(int ProductId, string Name, decimal Price, decimal Cost, int Stock)
        {
            int rowAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    string query = @"UPDATE Products SET Name = @Name,Price = @Price,Cost = @Cost,Stock = @Stock WHERE ProductId = @ProductId";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ProductId", ProductId);
                        command.Parameters.AddWithValue("@Name", Name);
                        command.Parameters.AddWithValue("@Price", Price);
                        command.Parameters.AddWithValue("@Cost", Cost);
                        command.Parameters.AddWithValue("@Stock", Stock);

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

        public static bool UpdateProduct(int ProductId,int Stock)
        {
            int rowAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    string query = @"UPDATE Products SET Stock = @Stock WHERE ProductId = @ProductId";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ProductId", ProductId);
              
                        command.Parameters.AddWithValue("@Stock", Stock);

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


        public static bool GetProductByProductId(int ProductId, ref string Name, ref decimal Price, ref decimal Cost, ref int Stock)
        {
            bool IsFound = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    string query = @"SELECT * FROM Products WHERE ProductId = @ProductId";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ProductId", ProductId);

                        connection.Open();

                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            IsFound = true;
                            Name = (string)reader["Name"];
                            Price = (decimal)reader["Price"];
                            Cost = (decimal)reader["Cost"];
                            Stock = (int)reader["Stock"];
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

        public static bool DeleteProduct(int ProductId)
        {
            int rowAffected = 0;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            {
                string query = @"Delete FROM Products WHERE ProductId = @ProductId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ProductId", ProductId);


                    try
                    {
                        connection.Open();
                        rowAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        clsEventLog.LogOrCreateEventSoures(ex.Message);
                    }
                }

                return (rowAffected != 0);
            }
        }

        public static bool IsProductExist(string Name)
        {
            bool IsFound = false;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            {

                string query = "select Found=1 from  Products where Name=@Name";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@Name", Name);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    IsFound = reader.HasRows;


                }
                catch (Exception ex)
                {
                    clsEventLog.LogOrCreateEventSoures(ex.Message);
                    IsFound = false;
                }
                finally
                {
                    connection.Close();
                }
                return IsFound;
            }
        }
        public static bool GetProductInfoByName(ref int ProductId, string Name, ref decimal Price, ref decimal Cost, ref int Stock)
        {
            bool isFound = false;


            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            {
                string query = "SELECT * FROM Products WHERE Name = @Name";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@Name", Name);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {

                        // The record was found
                        isFound = true;

                        ProductId = (int)reader["ProductId"];
                        Price = (decimal)reader["Price"];
                        Cost = (decimal)reader["Cost"];
                        Stock = (int)reader["Stock"];
                    }
                    else
                    {
                        // The record was not found
                        isFound = false;
                    }

                    reader.Close();


                }
                catch (Exception ex)
                {
                    //Console.WriteLine("Error: " + ex.Message);
                    isFound = false;
                }
                finally
                {
                    connection.Close();
                }

                return isFound;
            }
        }

        public static DataTable MoreProdutctsPuy(string DeceOrAsc, DateTime dtfrom, DateTime dtEnd)
        {

            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            {
              
     

                    string guery = $@"SELECT
    Products.ProductId  ,
    Products.Name ,
    SUM(InvoiceDetails.Quantity) as totalRevenue ,
    SUM(InvoiceDetails.Total) as total ,
    SUM(Products.Cost * InvoiceDetails.Quantity) as talCost,
    SUM((InvoiceDetails.Total * Invoice.TaxPercent)) as taxamout,
    CASE  When SUM(InvoiceDetails.Total - (Products.Cost * InvoiceDetails.Quantity)) < 0 then 0
ELSE  SUM(InvoiceDetails.Total - (Products.Cost * InvoiceDetails.Quantity))
End AS rabh
FROM InvoiceDetails
JOIN Products  ON InvoiceDetails.ProductId = Products.ProductId
JOIN Invoice  ON InvoiceDetails.InvoiceId = Invoice.InvoiceId
WHERE Invoice.invoiceDate BETWEEN @FromDate AND @ToDate
GROUP BY Products.ProductId ,Products.Name
   ORDER BY total  {DeceOrAsc} ";

                using (SqlCommand command = new SqlCommand(guery, connection))
                {
                    command.Parameters.AddWithValue("@FromDate", dtfrom);

                    DateTime dtToWithTime = dtEnd.Date.AddDays(1).AddTicks(-1);
                    command.Parameters.AddWithValue("@ToDate", dtToWithTime);

                  
                   // command.Parameters.AddWithValue("@ToDate", dtEnd);
                    //command.Parameters.AddWithValue("@DeceOrAsc", DeceOrAsc);

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            dt.Load(reader);
                        }
                    }
                    catch (Exception ex)
                    {
                        clsEventLog.LogOrCreateEventSoures(ex.Message);
                    }
                }
            }

            return dt;
        }
    }
}
