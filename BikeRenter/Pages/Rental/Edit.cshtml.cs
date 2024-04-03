using BikeRenter.Pages.Customer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace BikeRenter.Pages.Rental
{
    public class EditModel : PageModel
    {
        public RentalInfo rentalInfo = new RentalInfo();
        public String errorMessage = "";
        public String successMessage = "";
        public void OnGet()
        {
            String RentalID = Request.Query["id"];

            try
            {
                String connectionString = "Data Source=.\\sqlexpress;Initial Catalog=BikeRental;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM Rental WHERE RentalID=@RentalID";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@RentalID", RentalID);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                rentalInfo.RentalID = "" + reader.GetInt32(0);
                                rentalInfo.CustomerID = "" + reader.GetInt32(1);
                                rentalInfo.BikeID = "" + reader.GetInt32(2);
                                rentalInfo.PaymentID = "" + reader.GetInt32(3);
                                rentalInfo.rentalDuration = "" + reader.GetDecimal(4);
                                rentalInfo.rentalStartTime = "" + reader.GetDateTime(5);

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

            try
            {
                String connectionString = "Data Source=.\\sqlexpress;Initial Catalog=BikeRental;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "UPDATE Rental " +
                                 "SET CustomerID=@CustomerID, BikeID=@BikeID, PaymentID=@PaymentID, rentalDuration=@rentalDuration, rentalStartTime=@rentalStartTime " +
                                 "WHERE RentalID=@RentalID";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@RentalID", rentalInfo.RentalID);
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
            Response.Redirect("/Rental/Index");


        }
    }
}
