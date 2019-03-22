using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment2
{
    public partial class Confirmation : System.Web.UI.Page
    {
        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
        SqlConnection scon = null;
       
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = (DataTable)Session["buyitems"];
            if (dt != null)
            {
                GridView2.DataSource = dt;
                GridView2.DataBind();

                GridView2.FooterRow.Cells[3].Text = "Total Amount";
                AddToCart ac = new AddToCart();
                GridView2.FooterRow.Cells[4].Text = ac.grandtotal().ToString();

                builder.DataSource = "mysqlservernirmi.database.windows.net";
                builder.UserID = "username";
                builder.Password = "Password123$";
                builder.InitialCatalog = "mySampleDatabase";

                scon = new SqlConnection(builder.ConnectionString);

                scon.Open();

                foreach (DataRow row in dt.Rows)
                {
                    string cemail = (string)Session["username"];
                    string itemid = row["itemid"].ToString();
                    string quantity = row["quantity"].ToString();

                    String query = "Insert Into CartItem VALUES (@cemail, @itemid, @quantity)";
                    SqlCommand sqlCmd = new SqlCommand(query, scon);
                    sqlCmd.Parameters.AddWithValue("@cemail", cemail.Trim());
                    sqlCmd.Parameters.AddWithValue("@itemid", itemid.Trim());
                    sqlCmd.Parameters.AddWithValue("@quantity", quantity.Trim());

                    Convert.ToInt32(sqlCmd.ExecuteScalar());
                }

                
            }

                
        }
    }
}