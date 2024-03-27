using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace BikeRenter.Pages.Bikes
{
    public class IndexModel : PageModel
    {
        public List<BikeInfo> listBikes = new List<BikeInfo>();
        public void OnGet()
        {
            try
            {
                String connectionString = "Data Source=.\\sqlexpress;Initial Catalog=BikeRental;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM bikes";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                BikeInfo bikeInfo = new BikeInfo();
                                bikeInfo.BikeID = "" + reader.GetInt32(0);
                                bikeInfo.type = reader.GetString(1);
                                bikeInfo.model = reader.GetString(2);
                                bikeInfo.price = "" + reader.GetDecimal(3);

                                listBikes.Add(bikeInfo);
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

    public class BikeInfo
    {
        public String BikeID;
        public String type;
        public String model;
        public String price;
    }


}
