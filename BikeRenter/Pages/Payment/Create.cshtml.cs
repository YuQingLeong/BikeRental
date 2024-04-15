using BikeRenter.Pages.Customer;
using BikeRenter.Pages.Payment;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace BikeRenter.Pages.Payment
{
    public class CreateModel : PageModel
    {
        public PaymentInfo paymentInfo = new PaymentInfo();
        public String errorMessage = "";
        public String successMessage = "";
        public void OnGet()
        {
        }
        public void OnPost()
        {
            paymentInfo.CustomerID = Request.Form["CustomerID"];
            paymentInfo.RentalID = Request.Form["RentalID"];
            paymentInfo.Method = Request.Form["Method"];
            paymentInfo.Amount = Request.Form["Amount"];
            paymentInfo.Time = Request.Form["Time"];

            if (paymentInfo.CustomerID.Length == 0 || paymentInfo.RentalID.Length == 0 || paymentInfo.Method.Length == 0 || paymentInfo.Amount.Length == 0 || paymentInfo.Time.Length == 0)
            {
                errorMessage = "All the field are required";
                return;
            }

            //add customer into the new database
            try
            {
                String connectionString = "Data Source=.\\sqlexpress;Initial Catalog=BikeRental;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "INSERT INTO Payment " +
                                 "(CustomerID, RentalID, Method, Amount, Time) VALUES " +
                                 "(@CustomerID, @RentalID, @Method, @Amount, @Time);";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@CustomerID", paymentInfo.CustomerID);
                        command.Parameters.AddWithValue("@RentalID", paymentInfo.RentalID);
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

            paymentInfo.CustomerID = "";
            paymentInfo.RentalID = "";
            paymentInfo.Method = "";
            paymentInfo.Amount = "";
            paymentInfo.Time = "";

            successMessage = "New Payment Added Correctly";

            Response.Redirect("/Payment/Index");

        }
    }
}
