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
                    String sql = "SELECT * FROM Payment";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PaymentInfo PaymentInfo = new PaymentInfo();
                                PaymentInfo.PaymentID = "" + reader.GetInt32(0);
                                PaymentInfo.CustomerID = "" + reader.GetInt32(1);
                                PaymentInfo.Method = reader.GetString(2);
                                PaymentInfo.Amount = "" + reader.GetDecimal(3);
                                PaymentInfo.Time = "" + reader.GetDateTime(4);

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
        public String Method;
        public String Amount;
        public String Time;
    }
}
