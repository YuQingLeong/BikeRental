using BikeRenter.Pages.Customer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace BikeRenter.Pages.Payment
{
    public class IndexModel : PageModel
    {
        public List<PaymentInfo> listPayments = new List<PaymentInfo>();
        public void OnGet()
        {
            try
            {
                String connectionString = "Data Source=.\\sqlexpress;Initial Catalog=BikeRental;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT p.PaymentID, c.name, p.RentalID, p.Method, p.Amount, p.Time FROM Payment p " +
                        "INNER JOIN Customer c ON p.CustomerID = c.CustomerID";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PaymentInfo PaymentInfo = new PaymentInfo();
                                PaymentInfo.PaymentID = "" + reader.GetInt32(0);
                                PaymentInfo.CustomerID = "" + reader.GetString(1);
                                PaymentInfo.RentalID = "" + reader.GetInt32(2);
                                PaymentInfo.Method = reader.GetString(3);
                                PaymentInfo.Amount = "" + reader.GetDecimal(4);
                                PaymentInfo.Time = "" + reader.GetDateTime(5);

                                listPayments.Add(PaymentInfo);
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

    public class PaymentInfo
    {
        public String PaymentID;
        public String CustomerID;
        public String RentalID;
        public String Method;
        public String Amount;
        public String Time;
    }
}
