using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace BikeRenter.Pages.Bikes
{
    public class CreateModel : PageModel
    {
        public BikeInfo bikeInfo = new BikeInfo();
        public String errorMessage = "";
        public String successMessage = "";
        public void OnGet()
        {
        }
        public void OnPost()
        {
            bikeInfo.type = Request.Form["type"];
            bikeInfo.model = Request.Form["model"];
            bikeInfo.price = Request.Form["price"];

            if (bikeInfo.type.Length == 0 || bikeInfo.model.Length == 0 || bikeInfo.price.Length == 0)
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
                    String sql = "INSERT INTO Bikes " +
                                 "(type, model, price) VALUES " +
                                 "(@type, @model, @price);";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@type", bikeInfo.type);
                        command.Parameters.AddWithValue("@model", bikeInfo.model);
                        command.Parameters.AddWithValue("@price", bikeInfo.price);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {

                errorMessage = ex.Message;
                return;
            }

            bikeInfo.type = "";
            bikeInfo.model = "";
            bikeInfo.price = "";

            successMessage = "New Bikes Added Correctly";

            Response.Redirect("/Bikes/Index");

        }

    }
}
