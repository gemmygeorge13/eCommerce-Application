using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Timers;
using System.Windows.Forms;
//using System.Windows.Forms.Timer;

namespace Assignment2
{
    public partial class AddToCart : System.Web.UI.Page
    {
        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
        SqlConnection scon = null;
        
        string message = "<script>alert('Please enter quantity less than or equal to availabale quantity.')</script>";
        //string title = "Error";

        //System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();


        //System.Timers.Timer t = new System.Timers.Timer(5000); // Set the time (1 mins in this case)


        private void timer_Elapsed(object sender1, ElapsedEventArgs e2)
        {
            //t.Stop();
            //t.Dispose();
            RemoveAllItems();
        }





        protected void Page_Load(object sender, EventArgs e)
        {

            //sql connection strings
            builder.DataSource = "mysqlservernirmi.database.windows.net";
            builder.UserID = "username";
            builder.Password = "Password123$";
            builder.InitialCatalog = "mySampleDatabase";

            scon = new SqlConnection(builder.ConnectionString);

            if (!IsPostBack)
            {
                
                DataTable dt = new DataTable();
                DataRow dr;
                dt.Columns.Add("sno");
                dt.Columns.Add("itemid");
                dt.Columns.Add("quantity");
                dt.Columns.Add("price");
                dt.Columns.Add("totalprice");


                if (Request.QueryString["id"] != null)
                {
                    //if there are no items in the cart
                    if (Session["Buyitems"] == null)
                    {

                        dr = dt.NewRow();

                        scon.Open();

                        String myquery = "select * from item$ where ITEMNUMBER=" + Request.QueryString["id"];
                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandText = myquery;
                        cmd.Connection = scon;
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        dr["sno"] = 1;
                        dr["itemid"] = ds.Tables[0].Rows[0]["ITEMNUMBER"].ToString();
                        dr["quantity"] = Request.QueryString["quantity"];
                        dr["price"] = ds.Tables[0].Rows[0]["price"].ToString();
                        double price = Convert.ToDouble(ds.Tables[0].Rows[0]["price"].ToString());
                        int quantity = Convert.ToInt16(Request.QueryString["quantity"].ToString());

                        int qtydb = Convert.ToInt32(ds.Tables[0].Rows[0]["Inventory_item"]);

                        if (quantity <= qtydb)
                        {
                            double totalprice = (double)price * quantity;
                            dr["totalprice"] = totalprice;
                            dt.Rows.Add(dr);
                            GridView1.DataSource = dt;
                            GridView1.DataBind();

                            Session["buyitems"] = dt;
                            GridView1.FooterRow.Cells[3].Text = "Total Amount";
                            GridView1.FooterRow.Cells[4].Text = grandtotal().ToString();

                            UpdateDatabase(-(Convert.ToInt32(Request.QueryString["quantity"])), Convert.ToInt32(Request.QueryString["id"]));

                            Response.Redirect("Dashboard.aspx");
                        }
                        
                    }

                    //if there are already items in the cart
                    else
                    {
                        dt = (DataTable)Session["buyitems"];
                        foreach (DataRow row in dt.Rows)
                        {
                            if (row["itemid"].Equals(Request.QueryString["id"].ToString()))
                            {
                                //double unitPrc = Convert.ToDouble(row["price"]) / Convert.ToInt32(row["quantity"]);

                                int quan = Convert.ToInt16(Request.QueryString["quantity"].ToString());

                                row["quantity"] = (Convert.ToInt32(row["quantity"]) + quan).ToString();

                                //get the quantity from db
                                String qu1 = "select inventory_item from item$ where ITEMNUMBER=" + row["itemid"];
                                SqlCommand cmd1 = new SqlCommand();
                                cmd1.CommandText = qu1;
                                cmd1.Connection = scon;
                                SqlDataAdapter DA = new SqlDataAdapter();
                                DA.SelectCommand = cmd1;
                                DataSet DS = new DataSet();
                                DA.Fill(DS);

                                string dbQuant = DS.Tables[0].Rows[0]["Inventory_item"].ToString();

                                //then only update the footer
                                if(quan <= Convert.ToInt32(dbQuant))
                                {
                                    row["totalprice"] = (Convert.ToDouble(row["price"]) * Convert.ToInt32(row["quantity"])).ToString();

                                    UpdateDatabase(-(Convert.ToInt32(Request.QueryString["quantity"])), Convert.ToInt32(Request.QueryString["id"]));
                                    Response.Redirect("Dashboard.aspx");
                                }

                                
                            }
                        }


                        int sr;
                        sr = dt.Rows.Count;

                        dr = dt.NewRow();

                        String myquery = "select * from item$ where ITEMNUMBER=" + Request.QueryString["id"];
                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandText = myquery;
                        cmd.Connection = scon;
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        dr["sno"] = sr + 1;
                        dr["itemid"] = ds.Tables[0].Rows[0]["ITEMNUMBER"].ToString();
                        dr["quantity"] = Request.QueryString["quantity"];
                        dr["price"] = ds.Tables[0].Rows[0]["price"].ToString();
                        double price = Convert.ToDouble(ds.Tables[0].Rows[0]["price"].ToString());
                        int quantity = Convert.ToInt16(Request.QueryString["quantity"].ToString());
                        int qtydb = Convert.ToInt32(ds.Tables[0].Rows[0]["Inventory_item"]);

                        if (quantity <= qtydb)
                        {
                            double totalprice = (double)price * quantity;
                            dr["totalprice"] = totalprice;
                            dt.Rows.Add(dr);
                            GridView1.DataSource = dt;
                            GridView1.DataBind();

                            Session["buyitems"] = dt;
                            GridView1.FooterRow.Cells[3].Text = "Total Amount";
                            GridView1.FooterRow.Cells[4].Text = grandtotal().ToString();

                            UpdateDatabase(-(Convert.ToInt32(Request.QueryString["quantity"])), Convert.ToInt32(Request.QueryString["id"]));

                            Response.Redirect("Dashboard.aspx");
                        }
                        

                    }
                }
                else
                {
                    dt = (DataTable)Session["buyitems"];
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    if (GridView1.Rows.Count > 0)
                    {
                        GridView1.FooterRow.Cells[3].Text = "Total Amount";
                        GridView1.FooterRow.Cells[4].Text = grandtotal().ToString();

                    }


                }
                Label2.Text = GridView1.Rows.Count.ToString();

            }

        }

        //function to sum all the item purchase

        public double grandtotal()
        {
            DataTable dt = new DataTable();
            dt = (DataTable)Session["buyitems"];
            int nrow = dt.Rows.Count;
            int i = 0;
            double gtotal = 0;
            while (i < nrow)
            {
                gtotal = gtotal + Convert.ToDouble(dt.Rows[i]["totalprice"].ToString());

                i = i + 1;
            }
            return gtotal;
        }

        //remove item from cart
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataTable dt = new DataTable();
            dt = (DataTable)Session["buyitems"];


            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                int sr;
                int sr1;
                string qdata;
                string dtdata;
                sr = Convert.ToInt32(dt.Rows[i]["sno"].ToString());
                TableCell cell = GridView1.Rows[e.RowIndex].Cells[0];
                qdata = cell.Text;
                dtdata = sr.ToString();
                sr1 = Convert.ToInt32(qdata);

                if (sr == sr1)
                {
                    //update inventory

                    UpdateDatabase(Convert.ToInt32(dt.Rows[i]["quantity"]), Convert.ToInt32(dt.Rows[i]["itemid"]));


                    dt.Rows[i].Delete();
                    dt.AcceptChanges();
                    //Label1.Text = "Item Has Been Deleted From Shopping Cart";


                    break;

                }
            }

            for (int i = 1; i <= dt.Rows.Count; i++)
            {
                dt.Rows[i - 1]["sno"] = i;
                dt.AcceptChanges();
            }

            Session["buyitems"] = dt;
            Response.Redirect("AddToCart.aspx");
        }


        //checkcout
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Confirmation.aspx");
        }


        //update database once item ias added to cart 
        protected int UpdateDatabase(int qnty, int itemNo)
        {

            String myquery = "Update item$ SET Inventory_item = (Inventory_item + @qnty) where ITEMNUMBER = @itemNo";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = myquery;

            if (scon.State == ConnectionState.Closed)
            {
                scon.Open();
            }

            cmd.Connection = scon;
            cmd.Parameters.AddWithValue("@itemNo", itemNo);
            cmd.Parameters.AddWithValue("@qnty", qnty);

            return Convert.ToInt32(cmd.ExecuteScalar());

        }

        public void MsgBox(String ex, Page pg, Object obj)
        {
            string s = "<SCRIPT language='javascript'>alert('" + ex.Replace("\r\n", "\\n").Replace("'", "") + "'); </SCRIPT>";
            Type cstype = obj.GetType();
            ClientScriptManager cs = pg.ClientScript;
            cs.RegisterClientScriptBlock(cstype, s, s.ToString());
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            RemoveAllItems();
            Response.Redirect("AddToCart.aspx");
        }


        //on click on cancel - remove all items
        public void RemoveAllItems()
        {
            if (Session["buyitems"] != null)
            {
                DataTable dt = new DataTable();
                dt = (DataTable)Session["buyitems"];
                if (dt != null)
                {
                    int nrows = dt.Rows.Count;

                    while (nrows > 0)
                    {
                        UpdateDatabase(Convert.ToInt32(dt.Rows[0]["quantity"]), Convert.ToInt32(dt.Rows[0]["itemid"]));


                        dt.Rows[0].Delete();
                        dt.AcceptChanges();

                        nrows--;

                    }
                    Session["buyitems"] = dt;

                    Button1.Visible = false;
                    Button2.Visible = false;
                }

                //}
            }
            
        }

        //Back to shopping page
        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Dashboard.aspx");
        }


        //Event to trigger after 1 minute of inactivity
        protected void Timer1_Tick(object sender, EventArgs e)
        {
            Console.WriteLine("Counter Running");
            RemoveAllItems();
            Response.Redirect("AddToCart.aspx");
        }

        //logout

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}