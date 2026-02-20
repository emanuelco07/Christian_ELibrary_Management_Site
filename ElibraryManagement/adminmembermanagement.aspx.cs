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
    public partial class adminmembermanagement : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

        //GO button link event
        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            if (check_if_member_exists())
                get_member_by_id();
            else
                Response.Write("<script>alert('Member with this ID DOES NOT EXISTS.');</script>");
        }

        //account active button link event 
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            update_member_status_by_id("active");
        }

        //account pendding button link event
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            update_member_status_by_id("pendding");
        }

        //deactivate accont button link event
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            update_member_status_by_id("deactive");
        }

        //delete user button link event
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (check_if_member_exists())
                delete_member();
            else
                Response.Write("<script>alert('Member with this ID DOES NOT EXISTS.');</script>");
        }

        //user defined functions

        void get_member_by_id()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                    con.Open();
                //create the SQL Query
                SqlCommand cmd = new SqlCommand("SELECT * FROM member_master_tbl WHERE member_id ='" + TextBox2.Text.Trim() + "'", con);

                //fire the query
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    //while the data reader is reading all the data from the database
                    while (dr.Read())
                    {
                        TextBox1.Text = dr.GetValue(0).ToString(); //Name
                        TextBox7.Text = dr.GetValue(10).ToString(); //Account Status
                        TextBox3.Text = dr.GetValue(1).ToString(); //Date of Birth
                        TextBox4.Text = dr.GetValue(2).ToString(); //Contact Number
                        TextBox8.Text = dr.GetValue(3).ToString(); //Email
                        TextBox5.Text = dr.GetValue(4).ToString(); //State
                        TextBox6.Text = dr.GetValue(5).ToString(); //City
                        TextBox9.Text = dr.GetValue(6).ToString(); //Pincode
                        TextBox10.Text = dr.GetValue(7).ToString(); //Full address
                    }
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

        bool check_if_member_exists()
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
                SqlCommand cmd = new SqlCommand("SELECT * FROM member_master_tbl WHERE member_id ='" + TextBox2.Text.Trim() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd); //we create an adapter for the query result
                DataTable dt = new DataTable();
                da.Fill(dt); //we want to fill our table with the response from the query
                //if the member id already exists we will have 1 row

                if (dt.Rows.Count >= 1) //we found 1 matching id 
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                //because in the message we can have ' we will replace this
                var safeMessage = ex.Message.Replace("'", "\\'");
                Response.Write("<script>alert('" + safeMessage + "');</script>");
                return false;
            }
        }

        void update_member_status_by_id(string status)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                    con.Open();
                //create the SQL Query
                SqlCommand cmd = new SqlCommand("UPDATE member_master_tbl SET account_status ='" + status + "' WHERE member_id ='" + TextBox2.Text.Trim() + "' ", con);

                //fire the query
                SqlDataReader dr = cmd.ExecuteReader();

                TextBox7.Text = status; //Account Status updated in the Textbox

                con.Close();
                GridView1.DataBind();
                Response.Write("<script>alert('Member Status Updated!');</script>");
            }
            catch (Exception ex)
            {
                //because in the message we can have ' we will replace this
                var safeMessage = ex.Message.Replace("'", "\\'");
                Response.Write("<script>alert('" + safeMessage + "');</script>");
            }
        }

        void clear_forms()
        {
            TextBox2.Text = "";
            TextBox1.Text = "";
            TextBox7.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox8.Text = "";
            TextBox5.Text = "";
            TextBox6.Text = "";
            TextBox9.Text = "";
            TextBox10.Text = "";
        }

        void delete_member()
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
                SqlCommand cmd = new SqlCommand("DELETE FROM member_master_tbl " +
                    "WHERE member_id = '" + TextBox2.Text.ToString() + "'", con);

                //get the values to the placeholders from the textboxes(front-end)
                cmd.Parameters.AddWithValue("@member_id", TextBox2.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close(); //close the connection

                clear_forms();

                Response.Write("<script>alert('Member Deleted Successfully!');</script>");

                GridView1.DataBind(); //update the data from the gridview
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