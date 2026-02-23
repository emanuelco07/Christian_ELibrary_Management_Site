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
    public partial class adminbookissuing : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                GridView1.DataBind();
        }

        //GO button click event
        protected void Button2_Click(object sender, EventArgs e)
        {
            get_names();
        }

        //Issue Book click event
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (check_if_book_exists_for_issuing() == true && check_if_member_exists() == true)
                if (check_if_issues_entry_exists() == true)
                    Response.Write("<script>alert('This Member already has this book!');</script>");
                else
                    issue_book();
            else
                Response.Write("<script>alert('Invalid Member or Book details!');</script>");
        }

        //Return Book click event
        protected void Button4_Click(object sender, EventArgs e)
        {
            if (check_if_book_exists_for_returning() == true && check_if_member_exists() == true)
                if (check_if_issues_entry_exists() == true)
                    return_book();
                else
                    Response.Write("<script>alert('This Entry does NOT EXISTS!');</script>");
            else
                Response.Write("<script>alert('Invalid Member or Book details!');</script>");
        }

        //user defined functions
        void get_names()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                    con.Open();

                SqlCommand cmd = new SqlCommand("SELECT book_name FROM book_master_tbl WHERE book_id = '" + TextBox1.Text.Trim() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd); //dissconnected arhitecture
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    TextBox4.Text = dt.Rows[0]["book_name"].ToString();
                }
                else
                    Response.Write("<script>alert('Invalid Book ID!');</script>");

                cmd = new SqlCommand("SELECT full_name FROM member_master_tbl WHERE member_id = '" + TextBox2.Text.Trim() + "'", con);
                da = new SqlDataAdapter(cmd); //dissconnected arhitecture
                dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    TextBox3.Text = dt.Rows[0]["full_name"].ToString();
                }
                else
                    Response.Write("<script>alert('Invalid Member ID!');</script>");

                con.Close();
            }
            catch (Exception ex)
            {
                //because in the message we can have ' we will replace this
                var safeMessage = ex.Message.Replace("'", "\\'");
                Response.Write("<script>alert('" + safeMessage + "');</script>");
            }
        }

        bool check_if_book_exists_for_issuing()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                    con.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM book_master_tbl WHERE book_id = '" + TextBox1.Text.Trim() + "' AND current_stock > 0", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd); //dissconnected arhitecture
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();

                if (dt.Rows.Count >= 1)
                    return true; //it means that we have a book with this ID
                else
                {
                    Response.Write("<script>alert('The book cannot be borrowed!');</script>");
                    return false;
                }
            }
            catch (Exception ex)
            {
                //because in the message we can have ' we will replace this
                var safeMessage = ex.Message.Replace("'", "\\'");
                Response.Write("<script>alert('" + safeMessage + "');</script>");
            }
            return false;
        }

        bool check_if_book_exists_for_returning()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                    con.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM book_master_tbl WHERE book_id = '" + TextBox1.Text.Trim() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd); //dissconnected arhitecture
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();

                if (dt.Rows.Count >= 1)
                    return true; //it means that we have a book with this ID
                else
                {
                    Response.Write("<script>alert('The book cannot be borrowed!');</script>");
                    return false;
                }
            }
            catch (Exception ex)
            {
                //because in the message we can have ' we will replace this
                var safeMessage = ex.Message.Replace("'", "\\'");
                Response.Write("<script>alert('" + safeMessage + "');</script>");
            }
            return false;
        }

        bool check_if_member_exists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                    con.Open();

                SqlCommand cmd = new SqlCommand("SELECT full_name FROM member_master_tbl WHERE member_id = '" + TextBox2.Text.Trim() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd); //dissconnected arhitecture
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();

                if (dt.Rows.Count >= 1)
                    return true; //it means that we have a book with this ID
                else
                {
                    Response.Write("<script>alert('Member with this ID does NOT EXISTS!');</script>");
                    return false;
                }
            }
            catch (Exception ex)
            {
                //because in the message we can have ' we will replace this
                var safeMessage = ex.Message.Replace("'", "\\'");
                Response.Write("<script>alert('" + safeMessage + "');</script>");
            }
            return false;
        }

        void issue_book()
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
                SqlCommand cmd = new SqlCommand("INSERT INTO book_issue_tbl" +
                    " (member_id, member_name, book_id, book_name, issue_date, due_date)" +
                    "VALUES (@member_id, @member_name, @book_id, @book_name, @issue_date, @due_date)", con);

                //get the values to the placeholders from the textboxes(front-end)
                cmd.Parameters.AddWithValue("@member_id", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@member_name", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@book_id", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@book_name", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@issue_date", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@due_date", TextBox6.Text.Trim());

                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("UPDATE book_master_tbl SET current_stock = current_stock - 1 WHERE book_id = " +
                    "'" + TextBox1.Text.Trim() + "'", con);
                cmd.ExecuteNonQuery();

                con.Close(); //close the connection

                Response.Write("<script>alert('Book Issued Successfully!');</script>");

                GridView1.DataBind(); //update the data from the gridview
            }
            catch (Exception ex)
            {
                //because in the message we can have ' we will replace this
                var safeMessage = ex.Message.Replace("'", "\\'");
                Response.Write("<script>alert('" + safeMessage + "');</script>");
            }
        }

        bool check_if_issues_entry_exists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                    con.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM book_issue_tbl WHERE book_id = '" + TextBox1.Text.Trim() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd); //dissconnected arhitecture
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();

                if (dt.Rows.Count >= 1)
                    return true; //it means that we have a book with this ID
                else
                    return false;
            }
            catch (Exception ex)
            {
                //because in the message we can have ' we will replace this
                var safeMessage = ex.Message.Replace("'", "\\'");
                Response.Write("<script>alert('" + safeMessage + "');</script>");
            }
            return false;
        }

        void return_book()
        {
            try
            {
                //open the connection
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                    con.Open();

                //create the SQL Query
                SqlCommand cmd = new SqlCommand("DELETE FROM book_issue_tbl WHERE book_id = '" + TextBox1.Text.Trim() + "' " +
                    "AND member_id = '" + TextBox2.Text.Trim() + "'", con);

                int result = cmd.ExecuteNonQuery(); //returns the numbers of rows affected

                if (result > 0)
                {
                    cmd = new SqlCommand("UPDATE book_master_tbl SET current_stock = current_stock + 1 WHERE book_id = " +
                        "'" + TextBox1.Text.Trim() + "'", con);

                    cmd.ExecuteNonQuery();
                    con.Close();

                    Response.Write("<script>alert('Book Returned Successfully!');</script>");
                    GridView1.DataBind();
                }
                else
                    Response.Write("<script>alert('Error - Invalid Details!');</script>");
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
    }
}