using BikeRenter.Pages.Customer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace BikeRenter.Pages.Rental
{
    public class CreateModel : PageModel
    {
        public RentalInfo rentalInfo = new RentalInfo();
        public String errorMessage = "";
        public String successMessage = "";
        public void OnGet()
        {
        }
        public void OnPost()
        {
            rentalInfo.RentalID = Request.Form["RentalID"];
            rentalInfo.CustomerID = Request.Form["CustomerID"];
            rentalInfo.BikeID = Request.Form["BikeID"];
            rentalInfo.PaymentID = Request.Form["PaymentID"];
            rentalInfo.rentalDuration = Request.Form["rentalDuration"];
            rentalInfo.rentalStartTime = Request.Form["rentalStartTime"];

            if (rentalInfo.RentalID.Length == 0 || rentalInfo.CustomerID.Length == 0 || rentalInfo.BikeID.Length == 0 || rentalInfo.PaymentID.Length == 0 || rentalInfo.rentalDuration.Length == 0 || rentalInfo.rentalStartTime.Length == 0)
            {
                errorMessage = "All the field are required";
                return;
            }

            //add rental into the new database
            try
            {
                String connectionString = "Data Source=.\\sqlexpress;Initial Catalog=BikeRental;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "INSERT INTO Rental " +
                                 "(CustomerID, BikeID, PaymentID, rentalDuration, rentalStartTime) VALUES " +
                                 "(@CustomerID, @BikeID, @PaymentID, @rentalDuration, @rentalStartTime);";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@CustomerID", rentalInfo.CustomerID);
                        command.Parameters.AddWithValue("@BikeID", rentalInfo.BikeID);
                        command.Parameters.AddWithValue("@PaymentID", rentalInfo.PaymentID);
                        command.Parameters.AddWithValue("@rentalDuration", rentalInfo.rentalDuration);
                        command.Parameters.AddWithValue("@rentalStartTime", rentalInfo.rentalStartTime);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {

                errorMessage = ex.Message;
                return;
            }

            rentalInfo.CustomerID = "";
            rentalInfo.BikeID = "";
            rentalInfo.PaymentID = "";
            rentalInfo.rentalDuration = "";
            rentalInfo.rentalStartTime = "";

            successMessage = "New Rental Added Correctly";

            Response.Redirect("/Rental/Index");

        }
    }
}
