using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace BikeRenter.Pages.Rental
{
    public class IndexModel : PageModel
    {
        public List<RentalInfo> listRentals = new List<RentalInfo>();
        public void OnGet()
        {
            try
            {
                String connectionString = "Data Source=.\\sqlexpress;Initial Catalog=BikeRental;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM Rental";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                RentalInfo rentalInfo = new RentalInfo();
                                rentalInfo.RentalID = "" + reader.GetInt32(0);
                                rentalInfo.CustomerID = "" + reader.GetInt32(1);
                                rentalInfo.BikeID = "" + reader.GetInt32(2);
                                rentalInfo.PaymentID = "" + reader.GetInt32(3);
                                rentalInfo.rentalDuration = "" + reader.GetDecimal(4);
                                rentalInfo.rentalStartTime = "" + reader.GetDateTime(5);

                                listRentals.Add(rentalInfo);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }
        }
    }

    public class RentalInfo
    {
        public String RentalID;
        public String CustomerID;
        public String BikeID;
        public String PaymentID;
        public String rentalDuration;
        public String rentalStartTime;
    }
}
