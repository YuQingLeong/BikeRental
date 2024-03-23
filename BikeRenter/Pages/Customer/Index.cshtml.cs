using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace BikeRenter.Pages.Customer
{
    public class IndexModel : PageModel
    {
        public List<CustomerInfo> listCustomers = new List<CustomerInfo>();
        public void OnGet()
        {
            try
            {
                String connectionString = "Data Source=.\\sqlexpress;Initial Catalog=BikeRental;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM Customer";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read()) 
                            {
                                CustomerInfo customerInfo = new CustomerInfo();
                                customerInfo.CustomerID = "" + reader.GetInt32(0);
                                customerInfo.name = reader.GetString(1);
                                customerInfo.email = reader.GetString(2);
                                customerInfo.phone = reader.GetString(3);
                                customerInfo.address = reader.GetString(4);

                                listCustomers.Add(customerInfo);
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

    public class CustomerInfo
    {
        public String CustomerID;
        public String name;
        public String email;
        public String phone;
        public String address;
    }


}
