using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace BikeRenter.Pages.Customer
{
    public class EditModel : PageModel
    {
        public CustomerInfo customerInfo = new CustomerInfo();
        public String errorMessage = "";
        public String successMessage = "";
        public void OnGet()
        {
            String CustomerID = Request.Query["id"];

            try
            {
                String connectionString = "Data Source=.\\sqlexpress;Initial Catalog=BikeRental;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM Customer WHERE CustomerID=@CustomerID";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@CustomerID", CustomerID);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                customerInfo.CustomerID = "" + reader.GetInt32(0);
                                customerInfo.name = reader.GetString(1);
                                customerInfo.email = reader.GetString(2);
                                customerInfo.phone = reader.GetString(3);
                                customerInfo.address = reader.GetString(4);

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
            customerInfo.CustomerID = Request.Form["CustomerID"];
            customerInfo.name = Request.Form["name"];
            customerInfo.email = Request.Form["email"];
            customerInfo.phone = Request.Form["phone"];
            customerInfo.address = Request.Form["address"];



            if (customerInfo.CustomerID.Length == 0 || customerInfo.name.Length == 0 || customerInfo.email.Length == 0 || customerInfo.phone.Length == 0 || customerInfo.address.Length == 0)
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
                    String sql = "UPDATE Customer " +
                                 "SET name=@name, email=@email, phone=@phone, address=@address " +
                                 "WHERE CustomerID=@CustomerID";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@name", customerInfo.name);
                        command.Parameters.AddWithValue("@email", customerInfo.email);
                        command.Parameters.AddWithValue("@phone", customerInfo.phone);
                        command.Parameters.AddWithValue("@address", customerInfo.address);
                        command.Parameters.AddWithValue("@CustomerID", customerInfo.CustomerID);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }
            Response.Redirect("/Customer/Index");
    

        }
    }

}
