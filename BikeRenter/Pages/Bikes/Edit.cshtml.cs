using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace BikeRenter.Pages.Bikes
{
    public class EditModel : PageModel
    {
        public BikeInfo bikeInfo = new BikeInfo();
        public String errorMessage = "";
        public String successMessage = "";
        public void OnGet()
        {
            String BikeID = Request.Query["id"];

            try
            {
                String connectionString = "Data Source=.\\sqlexpress;Initial Catalog=BikeRental;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM Bikes WHERE BikeID=@BikeID";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@BikeID", BikeID);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                bikeInfo.BikeID = "" + reader.GetInt32(0);
                                bikeInfo.type = reader.GetString(1);
                                bikeInfo.model = reader.GetString(2);
                                bikeInfo.price = "" + reader.GetDecimal(3);
                            
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
            bikeInfo.BikeID = Request.Form["BikeID"];
            bikeInfo.type = Request.Form["type"];
            bikeInfo.model = Request.Form["model"];
            bikeInfo.price = Request.Form["price"];



            if (bikeInfo.BikeID.Length == 0 || bikeInfo.type.Length == 0 || bikeInfo.model.Length == 0 || bikeInfo.price.Length == 0 )
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
                    String sql = "UPDATE Bikes " +
                                 "SET type=@type, model=@model, price=@price " +
                                 "WHERE BikeID=@BikeID";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@type", bikeInfo.type);
                        command.Parameters.AddWithValue("@model", bikeInfo.model);
                        command.Parameters.AddWithValue("@price", bikeInfo.price);   
                        command.Parameters.AddWithValue("@BikeID", bikeInfo.BikeID);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }
            Response.Redirect("/Bikes/Index");


        }
    }

}

