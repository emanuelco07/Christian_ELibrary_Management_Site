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
    public partial class userlogin : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //user login 
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if(con.State == ConnectionState.Closed)
                    con.Open();
                //create the SQL Query
                SqlCommand cmd = new SqlCommand("SELECT * FROM member_master_tbl WHERE member_id ='" + TextBox1.Text.Trim() + "' AND password ='" +TextBox2.Text.Trim()+ "'", con);

                //fire the query
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    //while the data reader is reading all the data from the database
                    while(dr.Read())
                    {
                        Response.Write("<script>alert('Login Successful!');</script>");
                        //create the session variables (parameters = key, value)
                        Session["username"] = dr.GetValue(8).ToString();
                        Session["full_name"] = dr.GetValue(0).ToString();
                        Session["role"] = "user";
                        Session["status"] = dr.GetValue(10).ToString();
                    }
                    Response.Redirect("homepage.aspx");
                }
                else
                    Response.Write("<script>alert('Invalid Credentials!');</script>");
            }
            catch (Exception ex)
            {
                //because in the message we can have ' we will replace this
                var safeMessage = ex.Message.Replace("'", "\\'");
                Response.Write("<script>alert('" + safeMessage + "');</script>");
            }
        }
        //user login defined functions
    }
}