using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace FX_DataAccess
{
    public class clsInvoecData 
    {

        public static bool GetCustomerByInvoiceId(int InvoiceId, ref int CustomerId, ref DateTime Date, ref int UserId, ref float SubTotal, ref float Taxpercent, ref float TaxAmount, ref float TotalAmount,
    string Notes, int paymentstatus, ref bool IsTaxIncluded, ref float PaidAmount)
        {
            bool IsFound = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    
                    string query = @"select * from Invoice Where InvoiceId=@InvoiceId";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@InvoiceId", InvoiceId);

                        connection.Open();

                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            IsFound = true;
                            CustomerId = (int)reader["CustomerId"];
                            Date = (DateTime)reader["invoiceDate"];
                            UserId = (int)reader["UserId"];
                            SubTotal = (float)reader["SubTotal"];
                            Taxpercent = (float)reader["Taxpercent"];
                            TaxAmount = (float)reader["TaxAmount"];
                            TotalAmount = (float)reader["TotalAmount"];
                            paymentstatus = (int)reader["paymentstatus"];
                            PaidAmount = (int)reader["PaidAmount"];
                            IsTaxIncluded = Convert.ToBoolean(reader["IsTaxIncluded"]);

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



        public static DataTable GetAllInvoices()
        {
            DataTable dt = new DataTable();


            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    string Query = @"Select InvoiceId ,Customers.Name,invoiceDate,Invoice.Taxpercent,TaxAmount,Invoice.TotalAmount	 
                            ,PaidAmount, paymentstatus =  case
                            
                             when paymentstatus = 1 then N'paid'
                             when paymentstatus = 2 then N'unpaid'
                             when paymentstatus = 3 then N'partial'
                             else
                             N'nothing'
                            
                             end,Invoice.Notes,Users.Username
                             from Invoice join Customers On Invoice.CustomerId = Customers.CustomerId 
                             join Users on Invoice.UserId = Users.UserId";
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
                    string Query = @"Select InvoiceId ,Customers.Name,invoiceDate,SubTotal,Taxpercent,Invoice.TaxAmount 
                            ,PaidAmount,case  
                             when paymentstatus = 1 then N'paid'
                             when paymentstatus = 2 then N'unpaid'
                             when paymentstatus = 3 then N'partial'
                             else
                             N'nothing'
                             end
                             from Invoice join Customers On Invoice.CustomerId = Customers.CustomerId;";
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

       
        public static bool GetNetLable(ref float SubTotal, ref float TaxAmount, ref float TotalAmount,
       ref float PaidAmount, ref float Taklaf, ref float Rabh, DateTime FromDate, DateTime ToDate, string paymentstatus,ref float RabhPaid)
        {


            bool IsFound = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {//
                    string Guery = @"
SELECT  
    SUM(Invoice.SubTotal) AS SubTotals,        
    SUM(Invoice.TaxAmount) AS TaxAmounts, 
    SUM(Invoice.PaidAmount) AS PaidAmounts,
    SUM(Invoice.TotalAmount) AS TotalAmounts,
    SUM(Products.Cost * InvoiceDetails.Quantity) AS Taklaf,

    SUM((InvoiceDetails.Total - (Products.Cost * InvoiceDetails.Quantity))) AS RabhTotal,

    SUM(
        (InvoiceDetails.Total - (Products.Cost * InvoiceDetails.Quantity)) * 
        (Invoice.PaidAmount / NULLIF(Invoice.TotalAmount, 0))
    ) AS RabhPaid
FROM 
    Invoice 
JOIN InvoiceDetails ON InvoiceDetails.InvoiceId = Invoice.InvoiceId 
JOIN Products ON Products.ProductId = InvoiceDetails.ProductId 
WHERE 
    Invoice.invoiceDate BETWEEN @FromDate AND @ToDate
    AND Invoice.paymentstatus = @paymentstatus  -- تم تعديل هذه النقطة
    AND Invoice.TotalAmount > 0;
";




                    using (SqlCommand command = new SqlCommand(Guery, connection))
                    {

                        command.Parameters.AddWithValue("@FromDate", FromDate.Date);

                        // إضافة نهاية اليوم لتاريخ النهاية
                        DateTime dtToWithTime = ToDate.Date.AddDays(1).AddTicks(-1);
                        command.Parameters.AddWithValue("@ToDate", dtToWithTime);

                        int statusValue = 0;
                        int.TryParse(paymentstatus, out statusValue);
                        command.Parameters.AddWithValue("@paymentstatus", statusValue);

                        connection.Open();

                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            IsFound = true;
                            SubTotal = Convert.ToSingle(reader["SubTotals"]);

                            TaxAmount = Convert.ToSingle(reader["TaxAmounts"]);
                            TotalAmount = Convert.ToSingle(reader["TotalAmounts"]);
                          //  RabhPaid = Convert.ToSingle(reader["RabhPaid"]);

                            PaidAmount = Convert.ToSingle(reader["PaidAmounts"]);
                            Taklaf = Convert.ToSingle(reader["Taklaf"]);
                            Rabh = Convert.ToSingle(reader["RabhTotal"]);

                            


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

        public static bool GetAllLable(ref float SubTotal, ref float TaxAmount, ref float TotalAmount,
    ref float PaidAmount, ref float Taklaf, ref float Rabh, DateTime FromDate, DateTime ToDate,ref float RabhPaid)
        {


            bool IsFound = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {

                    string Guery = @"  SELECT  
  
    Sum(Invoice.SubTotal) AS SubTotal,        
  
    sum(Invoice.TaxAmount) as TaxAmount, 
    sum(Invoice.PaidAmount) AS PaidAmount,
    sum(Invoice.TotalAmount) as TotalAmount,
    SUM(Products.Cost * InvoiceDetails.Quantity) AS Taklaf,
    SUM(Invoice.SubTotal) - SUM(Products.Cost * InvoiceDetails.Quantity) AS Rabh
                                 FROM 
    Invoice 
JOIN 
    Customers ON Invoice.CustomerId = Customers.CustomerId 
JOIN 
    InvoiceDetails ON InvoiceDetails.InvoiceId = Invoice.InvoiceId 
JOIN 
    Products ON Products.ProductId = InvoiceDetails.ProductId 
WHERE Invoice.invoiceDate BETWEEN @FromDate AND @ToDate
 

                               --AND       Invoice.paymentstatus = @paymentstatus


;";



                    using (SqlCommand command = new SqlCommand(Guery, connection))
                    {

                        command.Parameters.AddWithValue("@FromDate", FromDate.Date);

                        // إضافة نهاية اليوم لتاريخ النهاية
                        DateTime dtToWithTime = ToDate.Date.AddDays(1).AddTicks(-1);
                        command.Parameters.AddWithValue("@ToDate", dtToWithTime);

                      
                        connection.Open();

                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            IsFound = true;
                            SubTotal = Convert.ToSingle(reader["SubTotal"]);

                            TaxAmount = Convert.ToSingle(reader["TaxAmount"]);
                            TotalAmount = Convert.ToSingle(reader["TotalAmount"]);

                            PaidAmount = Convert.ToSingle(reader["PaidAmount"]);
                            Taklaf = Convert.ToSingle(reader["Taklaf"]);
                            Rabh = Convert.ToSingle(reader["Rabh"]);
                       //     RabhPaid = Convert.ToSingle(reader["RabhPaid"]);




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


        public static bool GetNetLableProj(ref float SubTotal, ref float TaxAmount, ref float TotalAmount,
       ref float PaidAmount, ref float Taklaf, ref float Rabh, DateTime FromDate, DateTime ToDate,string Type)
        {


            bool IsFound = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    string Guery = $@"  SELECT  
  
    Sum(Invoice.SubTotal) AS SubTotals,        
  
    sum(Invoice.TaxAmount) as TaxAmounts, 
    sum(Invoice.PaidAmount) AS PaidAmounts,
    sum(Invoice.TotalAmount) as TotalAmounts,
    SUM(Products.Cost * InvoiceDetails.Quantity) AS Taklaf,
    SUM(Invoice.SubTotal) - SUM(Products.Cost * InvoiceDetails.Quantity) AS Rabh
                                 FROM 
    Invoice 
JOIN 
    Customers ON Invoice.CustomerId = Customers.CustomerId 
JOIN 
    InvoiceDetails ON InvoiceDetails.InvoiceId = Invoice.InvoiceId 
JOIN 
    Products ON Products.ProductId = InvoiceDetails.ProductId 
WHERE Invoice.invoiceDate BETWEEN @FromDate AND @ToDate
 

                             ORDER BY  TotalAmounts {Type}

;";
                    

                    using (SqlCommand command = new SqlCommand(Guery, connection))
                    {

                        command.Parameters.AddWithValue("@FromDate", FromDate.Date);

                        // إضافة نهاية اليوم لتاريخ النهاية
                        DateTime dtToWithTime = ToDate.Date.AddDays(1).AddTicks(-1);
                        command.Parameters.AddWithValue("@ToDate", dtToWithTime);

              

                        connection.Open();

                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            IsFound = true;
                            SubTotal = Convert.ToSingle(reader["SubTotals"]);

                            TaxAmount = Convert.ToSingle(reader["TaxAmounts"]);
                            TotalAmount = Convert.ToSingle(reader["TotalAmounts"]);

                            PaidAmount = Convert.ToSingle(reader["PaidAmounts"]);
                            Taklaf = Convert.ToSingle(reader["Taklaf"]);
                            Rabh = Convert.ToSingle(reader["Rabh"]);




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


        public static DataTable GetAllNetProfit(DateTime dtFrom, DateTime dtTo, string paymentstatus)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    
                     string Query = $@"SELECT 
    Invoice.InvoiceId AS رقم_الفاتورة,
    C.Name AS اسم_العميل,
    Invoice.invoiceDate AS التاريخ,
    Invoice.SubTotal AS اجمالي_المبيعات,
    SUM(ISNULL(P.Cost, 0) * ISNULL(D.Quantity, 0)) AS اجمالي_التكاليف,
    CASE  
        WHEN Invoice.SubTotal - SUM(ISNULL(P.Cost, 0) * ISNULL(D.Quantity, 0)) < 0 THEN 0
        ELSE Invoice.SubTotal - SUM(ISNULL(P.Cost, 0) * ISNULL(D.Quantity, 0))
    END AS الربح_الصافي,
    CASE 
   when paymentstatus = 1 then N'paid'
   when paymentstatus = 2 then N'unpaid'
   when paymentstatus = 3 then N'partial'
   else
   N'nothing'
    END AS حالة_الدفع
FROM
    Invoice 
JOIN Customers C ON C.CustomerId = Invoice.CustomerId
LEFT JOIN InvoiceDetails D ON D.InvoiceId = Invoice.InvoiceId
LEFT JOIN Products P ON P.ProductId = D.ProductId
WHERE 
    Invoice.invoiceDate BETWEEN @dtFrom AND @dtTo
   AND
    
    Invoice.paymentstatus = @paymentstatus
GROUP BY 
    Invoice.InvoiceId, C.Name, Invoice.invoiceDate, Invoice.SubTotal, Invoice.paymentstatus
ORDER BY 
    Invoice.InvoiceId DESC
";

                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {

                        command.Parameters.AddWithValue("@dtFrom", dtFrom.Date);

                        // إضافة نهاية اليوم لتاريخ النهاية
                        DateTime dtToWithTime = dtTo.Date.AddDays(1).AddTicks(-1);
                        command.Parameters.AddWithValue("@dtTo", dtToWithTime);

                        int statusValue = 0;
                        int.TryParse(paymentstatus, out statusValue);
                        command.Parameters.AddWithValue("@paymentstatus", statusValue);


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

        public static int AddNewInvoice(int CustomerId, DateTime invoiceDate, int UserId, float SubTotal, float Taxpercent, float TaxAmount, float TotalAmount,
            string Notes, int paymentstatus, bool IsTaxIncluded, float PaidAmount)
        {
            int InvoiceId = -1;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    string query = @"
                                     INSERT INTO Invoice (PaidAmount,invoiceDate,CustomerId,UserId,SubTotal,Taxpercent,TaxAmount,TotalAmount,Notes,paymentstatus,IsTaxIncluded) 
                                      Values (@PaidAmount,@invoiceDate,@CustomerId,@UserId,@SubTotal,@Taxpercent,@TaxAmount,@TotalAmount,@Notes,@paymentstatus,@IsTaxIncluded) 
                                      
                                      select SCOPE_IDENTITY()";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserId", UserId);
                        command.Parameters.AddWithValue("@PaidAmount", PaidAmount);
                        command.Parameters.AddWithValue("@CustomerId", CustomerId);
                        command.Parameters.AddWithValue("@invoiceDate", invoiceDate);
                        command.Parameters.AddWithValue("@TotalAmount", TotalAmount);
                        command.Parameters.AddWithValue("@SubTotal", SubTotal);
                        command.Parameters.AddWithValue("@Taxpercent", Taxpercent);
                        command.Parameters.AddWithValue("@TaxAmount", TaxAmount);
                        command.Parameters.AddWithValue("@paymentstatus", paymentstatus);
                        command.Parameters.AddWithValue("@IsTaxIncluded", IsTaxIncluded);

                        if (Notes == "")

                            command.Parameters.AddWithValue("@Notes", System.DBNull.Value);
                        else
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


        public static bool UpdateInvoices(int InvoiceId, int CustomerId, DateTime invoiceDate, int UserId, float SubTotal, float Taxpercent, float TaxAmount, float TotalAmount,
            string Notes, int paymentstatus, bool IsTaxIncluded, float PaidAmount)
        {
            int RowAffected = -1;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    string query = @"Update Invoice set PaidAmount = @PaidAmount,invoiceDate = @invoiceDate,CustomerId = @CustomerId,UserId = @UserId,SubTotal = @SubTotal,Taxpercent = @Taxpercent,TaxAmount = @TaxAmount,TotalAmount = @TotalAmount,Notes = @Notes,paymentstatus = @paymentstatus,IsTaxIncluded = @IsTaxIncluded
                                      Where InvoiceId =  @InvoiceId";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@InvoiceId", InvoiceId);
                        command.Parameters.AddWithValue("@UserId", UserId);
                        command.Parameters.AddWithValue("@CustomerId", CustomerId);
                        command.Parameters.AddWithValue("@invoiceDate", invoiceDate);
                        command.Parameters.AddWithValue("@TotalAmount", TotalAmount);
                        command.Parameters.AddWithValue("@SubTotal", SubTotal);
                        command.Parameters.AddWithValue("@Taxpercent", Taxpercent);
                        command.Parameters.AddWithValue("@TaxAmount", TaxAmount);
                        command.Parameters.AddWithValue("@paymentstatus", paymentstatus);
                        command.Parameters.AddWithValue("@IsTaxIncluded", IsTaxIncluded);
                        if (Notes == "")

                            command.Parameters.AddWithValue("@Notes", System.DBNull.Value);
                        else
                            command.Parameters.AddWithValue("@Notes", Notes);

                        command.Parameters.AddWithValue("@PaidAmount", PaidAmount);


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
                    string query = @"Delete  from Invoice Where InvoiceId=@InvoiceId";


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
