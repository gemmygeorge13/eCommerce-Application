using System;
using System.Collections.Generic; 
using System.Configuration;     
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment2
{
    public partial class Login : System.Web.UI.Page
    {
        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

        protected void Page_Load(object sender, EventArgs e)
        {
            // Credentials for connecting to Azure SQL Server
            builder.DataSource = "mysqlservernirmi.database.windows.net";
            builder.UserID = "username";
            builder.Password = "Password123$";
            builder.InitialCatalog = "mySampleDatabase";
                
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                //StringBuilder sb = new StringBuilder();
                //sb.Append(query);
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();
                    String query = "Select * from SalesLT.Customer where EmailAddress = @username";
                    SqlCommand sqlCmd = new SqlCommand(query, connection);
                    sqlCmd.Parameters.AddWithValue("@username", txtUserName.Text.Trim());

                    int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                    if(count >= 1)
                    {
                        Session["username"] = txtUserName.Text.Trim();
                        Response.Redirect("Dashboard.aspx");
                        Label3.Text = "Login is successfull";
                    }
                    else
                    {
                        Label3.Text = "Invalid Credentials";
                    }

                }
            }
            catch (SqlException ex)
            {
                // Return valid error message for invalid query 
                Console.WriteLine(ex.ToString());
            }

        }
    }
}