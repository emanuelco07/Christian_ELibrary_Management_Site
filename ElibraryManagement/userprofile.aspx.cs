using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ElibraryManagement
{
    public partial class userprofile : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["username"].ToString() == "" || Session["username"] == null)
                {
                    Response.Write("<script>alert('Sessions Expired! Login Again!');</script>");
                    Response.Redirect("userlogin.aspx");
                }
                else
                {
                    if (!Page.IsPostBack)
                        get_user_personal_details();
                    get_user_book_data();
                }
            }
            catch (Exception ex)
            {
                //because in the message we can have ' we will replace this
                var safeMessage = ex.Message.Replace("'", "\\'");
                Response.Write("<script>alert('" + safeMessage + "');</script>");
            }
        }

        //update button click event
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["username"].ToString() == "" || Session["username"] == null)
                {
                    Response.Write("<script>alert('Sessions Expired! Login Again!');</script>");
                    Response.Redirect("userlogin.aspx");
                }
                else
                    update_user_personal_details();
            }
            catch (Exception ex)
            {
                //because in the message we can have ' we will replace this
                var safeMessage = ex.Message.Replace("'", "\\'");
                Response.Write("<script>alert('" + safeMessage + "');</script>");
            }
        }

        //user defined functions
        void get_user_book_data()
        {
            try
            {
                //open the connection
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                //create the SQL Query
                SqlCommand cmd = new SqlCommand("SELECT * FROM book_issue_tbl WHERE member_id ='" + Session["username"].ToString() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd); //we create an adapter for the query result
                DataTable dt = new DataTable();
                da.Fill(dt); //we want to fill our table with the response from the query

                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                //because in the message we can have ' we will replace this
                var safeMessage = ex.Message.Replace("'", "\\'");
                Response.Write("<script>alert('" + safeMessage + "');</script>");
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    //check your condition here
                    DateTime dt = Convert.ToDateTime(e.Row.Cells[5].Text); //the 5th column of the gridview
                    DateTime today = DateTime.Today;

                    if (today > dt)
                        //we apply the style vor every cell because bootstrap overwrtie the cod for the entire row
                        foreach (TableCell cell in e.Row.Cells)
                        {
                            cell.Attributes["style"] = "background-color:palevioletred !important;";
                        }
                }
            }
            catch (Exception ex)
            {
                //because in the message we can have ' we will replace this
                var safeMessage = ex.Message.Replace("'", "\\'");
                Response.Write("<script>alert('" + safeMessage + "');</script>");
            }
        }

        void get_user_personal_details()
        {
            try
            {
                //open the connection
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                //create the SQL Query
                SqlCommand cmd = new SqlCommand("SELECT * FROM member_master_tbl WHERE member_id ='" + Session["username"].ToString() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd); //we create an adapter for the query result
                DataTable dt = new DataTable();
                da.Fill(dt); //we want to fill our table with the response from the query

                TextBox1.Text = dt.Rows[0]["full_name"].ToString();
                TextBox2.Text = dt.Rows[0]["dob"].ToString();
                TextBox3.Text = dt.Rows[0]["contact_no"].ToString();
                TextBox4.Text = dt.Rows[0]["email"].ToString();
                DropDownList1.SelectedValue = dt.Rows[0]["state"].ToString();
                TextBox6.Text = dt.Rows[0]["city"].ToString();
                TextBox7.Text = dt.Rows[0]["pincode"].ToString();
                TextBox5.Text = dt.Rows[0]["full_address"].ToString();
                TextBox8.Text = dt.Rows[0]["member_id"].ToString();
                TextBox9.Text = dt.Rows[0]["password"].ToString();

                Label1.Text = dt.Rows[0]["account_status"].ToString().Trim();

                if (dt.Rows[0]["account_status"].ToString().Trim() == "active")
                    Label1.Attributes.Add("class", "badge rounded-pill text-bg-success");
                else if (dt.Rows[0]["account_status"].ToString().Trim() == "pending")
                    Label1.Attributes.Add("class", "badge rounded-pill text-bg-warning");
                else if (dt.Rows[0]["account_status"].ToString().Trim() == "deactive")
                    Label1.Attributes.Add("class", "badge rounded-pill text-bg-danger");
                else
                    Label1.Attributes.Add("class", "badge rounded-pill text-bg-secondary");
            }
            catch (Exception ex)
            {
                //because in the message we can have ' we will replace this
                var safeMessage = ex.Message.Replace("'", "\\'");
                Response.Write("<script>alert('" + safeMessage + "');</script>");
            }
        }

        void update_user_personal_details()
        {
            string password = "";

            if (TextBox10.Text.Trim() == "")
                password = TextBox9.Text.Trim();
            else
                password = TextBox10.Text.Trim();

            try
            {
                //open the connection
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                    con.Open();

                //create the SQL Query
                SqlCommand cmd = new SqlCommand("UPDATE member_master_tbl SET " +
                    "full_name = @full_name, dob = @dob, contact_no = @contact_no, email = @email, " +
                    "state = @state, city = @city, pincode = @pincode, full_address = @full_address, " +
                    "password = @password, account_status = @account_status " +
                    "WHERE member_id = '" + Session["username"].ToString().Trim() + "'", con);

                cmd.Parameters.AddWithValue("@full_name", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@dob", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@contact_no", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@email", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@state", DropDownList1.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@city", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@pincode", TextBox7.Text.Trim());
                cmd.Parameters.AddWithValue("@full_address", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@account_status", "pending");

                int result = cmd.ExecuteNonQuery();
                con.Close();

                if (result > 0)
                {
                    Response.Write("<script>alert('Your Details Updated Successfully!');</script>");
                    get_user_personal_details();
                    get_user_book_data();
                }
                else
                    Response.Write("<script>alert('Invalid Entry!');</script>");
            }
            catch (Exception ex)
            {
                //because in the message we can have ' we will replace this
                var safeMessage = ex.Message.Replace("'", "\\'");
                Response.Write("<script>alert('" + safeMessage + "');</script>");
            }
        }
    }
}