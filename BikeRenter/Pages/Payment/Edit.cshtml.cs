using BikeRenter.Pages.Customer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace BikeRenter.Pages.Payment
{
    public class EditModel : PageModel
    {
        public PaymentInfo paymentInfo = new PaymentInfo();
        public String errorMessage = "";
        public String successMessage = "";
        public void OnGet()
        {
            String PaymentID = Request.Query["id"];

            try
            {
                String connectionString = "Data Source=.\\sqlexpress;Initial Catalog=BikeRental;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM Payment WHERE PaymentID=@PaymentID";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@PaymentID", PaymentID);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                paymentInfo.PaymentID = "" + reader.GetInt32(0);
                                paymentInfo.CustomerID = "" + reader.GetInt32(1);
                                paymentInfo.Method = reader.GetString(2);
                                paymentInfo.Amount = "" + reader.GetDecimal(3);
                                paymentInfo.Time = "" + reader.GetDateTime(4);

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
        }

        public void OnPost()
        {
            paymentInfo.PaymentID = Request.Form["PaymentID"];
            paymentInfo.CustomerID = Request.Form["CustomerID"];
            paymentInfo.Method = Request.Form["Method"];
            paymentInfo.Amount = Request.Form["Amount"];
            paymentInfo.Time = Request.Form["Time"];



            if (paymentInfo.PaymentID.Length == 0 || paymentInfo.CustomerID.Length == 0 || paymentInfo.Method.Length == 0 || paymentInfo.Amount.Length == 0 || paymentInfo.Time.Length == 0)
            {
                errorMessage = "All the field are required";
                return;
            }

            try
            {
                String connectionString = "Data Source=.\\sqlexpress;Initial Catalog=BikeRental;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "UPDATE Payment " +
                                 "SET CustomerID=@CustomerID, Method=@Method, Amount=@Amount, Time=@Time " +
                                 "WHERE PaymentID=@PaymentID";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@PaymentID", paymentInfo.PaymentID);
                        command.Parameters.AddWithValue("@CustomerID", paymentInfo.CustomerID);
                        command.Parameters.AddWithValue("@Method", paymentInfo.Method);
                        command.Parameters.AddWithValue("@Amount", paymentInfo.Amount);
                        command.Parameters.AddWithValue("@Time", paymentInfo.Time);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }
            Response.Redirect("/Payment/Index");


        }
    }
}
