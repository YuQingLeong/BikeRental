using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace BikeRenter.Pages.Customer
{
    public class CreateModel : PageModel
    {
        public CustomerInfo customerInfo = new CustomerInfo();
        public String errorMessage = "";
        public String successMessage = "";
        public void OnGet()
        {
        }
        public void OnPost()
        {
            customerInfo.name = Request.Form["name"];
            customerInfo.email = Request.Form["email"];
            customerInfo.phone = Request.Form["phone"];
            customerInfo.address = Request.Form["address"];

            if (customerInfo.name.Length == 0 || customerInfo.email.Length == 0 || customerInfo.phone.Length == 0 || customerInfo.address.Length == 0)
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
                    String sql = "INSERT INTO Customer " +
                                 "(name, email, phone, address) VALUES " +
                                 "(@name, @email, @phone, @address);";
                    using (SqlCommand command = new SqlCommand (sql, connection))
                    {
                        command.Parameters.AddWithValue("@name", customerInfo.name);
                        command.Parameters.AddWithValue("@email", customerInfo.email);
                        command.Parameters.AddWithValue("@phone", customerInfo.phone);
                        command.Parameters.AddWithValue("@address", customerInfo.address);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {

                errorMessage = ex.Message;
                return;
            }

            customerInfo.name = "";
            customerInfo.email = "";
            customerInfo.phone = "";
            customerInfo.address = "";

            successMessage = "New Customer Added Correctly";

            Response.Redirect("/Customer/Index");

        }

    }
}
