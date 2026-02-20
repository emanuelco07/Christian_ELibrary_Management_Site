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
    public partial class adminauthormanagement : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind(); //update the data from the gridview
        }

        //add button click event
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (check_if_author_exists())
                Response.Write("<script>alert('Author with this ID already EXISTS. You cannot add " +
                    "another Author with the same Author ID!');</script>");
            else
                add_new_author();
        }

        //update button click event 
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (check_if_author_exists())
                update_author();
            else
                Response.Write("<script>alert('Author with this ID does NOT EXISTS!');</script>");
        }

        //delete button click event
        protected void Button4_Click(object sender, EventArgs e)
        {
            if(check_if_author_exists())
                delete_author();
            else
                Response.Write("<script>alert('Author with this ID does NOT EXISTS!');</script>");
        }

        //GO button click event
        protected void Button2_Click(object sender, EventArgs e)
        {
            get_author_by_id();
        }

        //user defined functions
        bool check_if_author_exists()
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
                SqlCommand cmd = new SqlCommand("SELECT * FROM author_master_tbl WHERE author_id ='" + TextBox1.Text.Trim() + "'", con);
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

        void add_new_author()
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
                SqlCommand cmd = new SqlCommand("INSERT INTO author_master_tbl" +
                    " (author_id, author_name)" +
                    "VALUES (@author_id, @author_name)", con);

                //get the values to the placeholders from the textboxes(front-end)
                cmd.Parameters.AddWithValue("@author_id", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@author_name", TextBox2.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close(); //close the connection

                Response.Write("<script>alert('Author added Successfully!');</script>");

                clear_form(); //clear the textboxes

                GridView1.DataBind(); //update the data from the gridview
            }
            catch (Exception ex)
            {
                //because in the message we can have ' we will replace this
                var safeMessage = ex.Message.Replace("'", "\\'");
                Response.Write("<script>alert('" + safeMessage + "');</script>");
            }
        }

        void update_author()
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
                SqlCommand cmd = new SqlCommand("UPDATE author_master_tbl SET author_name = @author_name " +
                    "WHERE author_id = '" + TextBox1.Text.ToString() + "'", con);

                //get the values to the placeholders from the textboxes(front-end)
                cmd.Parameters.AddWithValue("@author_name", TextBox2.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close(); //close the connection

                Response.Write("<script>alert('Author Updated Successfully!');</script>");

                clear_form(); //clear the textboxes

                GridView1.DataBind(); //update the data from the gridview
            }
            catch (Exception ex)
            {
                //because in the message we can have ' we will replace this
                var safeMessage = ex.Message.Replace("'", "\\'");
                Response.Write("<script>alert('" + safeMessage + "');</script>");
            }
        }

        void delete_author()
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
                SqlCommand cmd = new SqlCommand("DELETE FROM author_master_tbl " +
                    "WHERE author_id = '" + TextBox1.Text.ToString() + "'", con);

                //get the values to the placeholders from the textboxes(front-end)
                cmd.Parameters.AddWithValue("@author_name", TextBox2.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close(); //close the connection

                Response.Write("<script>alert('Author Deleted Successfully!');</script>");

                clear_form(); //clear the textboxes

                GridView1.DataBind(); //update the data from the gridview
            }
            catch (Exception ex)
            {
                //because in the message we can have ' we will replace this
                var safeMessage = ex.Message.Replace("'", "\\'");
                Response.Write("<script>alert('" + safeMessage + "');</script>");
            }
        }

        void clear_form()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
        }

        void get_author_by_id()
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
                SqlCommand cmd = new SqlCommand("SELECT * FROM author_master_tbl WHERE author_id ='" + TextBox1.Text.Trim() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd); //we create an adapter for the query result
                DataTable dt = new DataTable();
                da.Fill(dt); //we want to fill our table with the response from the query
                //if the member id already exists we will have 1 row

                if (dt.Rows.Count >= 1) //we found 1 matching id 
                    TextBox2.Text = dt.Rows[0][1].ToString();
                else
                    Response.Write("<script>alert('Invalid Author ID!');</script>");
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