using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ElibraryManagement
{
    public partial class adminbookinventory : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        static string global_file_path;
        static int global_actual_stock, global_current_stock, global_issued_books;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) //indicates whether the page is rendered for the first time or is being loaded in response to a postback
                fill_author_publisher_values();
            GridView1.DataBind();
        }

        //add button click event
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (check_if_book_exists())
                Response.Write("<script>alert('Book with this ID already exists! Try another Book ID!');</script>");
            else
                add_new_book();
        }

        //update button click event
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (check_if_book_exists())
                update_book_by_id();
            else
                Response.Write("<script>alert('Book with this ID does NOT EXISTS!');</script>");
        }

        //delete button click event
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (check_if_book_exists())
                delete_book_by_id();
            else
                Response.Write("<script>alert('Book with this ID does NOT EXISTS!');</script>");
        }

        //GO button click event
        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            if (check_if_book_exists())
                get_book_by_id();
            else
                Response.Write("<script>alert('Book with this ID does NOT EXISTS!');</script>");
        }

        //user defined functions
        void fill_author_publisher_values()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                    con.Open();

                //add the authors
                SqlCommand cmd = new SqlCommand("SELECT author_name FROM author_master_tbl", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd); //dissconnected arhitecture
                DataTable dt = new DataTable();
                da.Fill(dt);
                DropDownList3.DataSource = dt;
                DropDownList3.DataValueField = "author_name"; //the same name as in DataBase
                DropDownList3.DataBind(); //to bind (update) the data

                //add the publishers
                cmd = new SqlCommand("SELECT publisher_name FROM publisher_master_tbl", con);
                da = new SqlDataAdapter(cmd); //dissconnected arhitecture
                dt = new DataTable();
                da.Fill(dt);
                DropDownList2.DataSource = dt;
                DropDownList2.DataValueField = "publisher_name"; //the same name as in DataBase
                DropDownList2.DataBind(); //to bind (update) the data

                con.Close();
            }
            catch (Exception ex)
            {
                //because in the message we can have ' we will replace this
                var safeMessage = ex.Message.Replace("'", "\\'");
                Response.Write("<script>alert('" + safeMessage + "');</script>");
            }
        }

        bool check_if_book_exists()
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
                SqlCommand cmd = new SqlCommand("SELECT * FROM book_master_tbl WHERE book_id ='" + TextBox2.Text.Trim() + "'", con);
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

        void add_new_book()
        {
            try
            {
                //we can select multiple genres
                string genres = "";
                foreach (int i in ListBox1.GetSelectedIndices())
                    genres = genres + ListBox1.Items[i] + ", ";

                //for the last item we want to remove the comma and space
                genres = genres.Remove(genres.Length - 2);

                //upload image file
                string filepath = "~/bookinventory/books2.png";
                string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                FileUpload1.SaveAs(Server.MapPath("bookinventory/" + filename));
                filepath = "~/bookinventory/" + filename;

                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                    con.Open();

                SqlCommand cmd = new SqlCommand("INSERT INTO book_master_tbl " +
                    "(book_id, book_name, genre, author_name, publisher_name, publish_date, " +
                    "language, edition, book_cost, no_of_pages, book_description, actual_stock, " +
                    "current_stock, book_img_link) " +
                    "VALUES (@book_id, @book_name, @genre, @author_name, @publisher_name, @publish_date, " +
                    "@language, @edition, @book_cost, @no_of_pages, @book_description, @actual_stock, " +
                    "@current_stock, @book_img_link)", con);

                cmd.Parameters.AddWithValue("@book_id", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@book_name", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@genre", genres);
                cmd.Parameters.AddWithValue("@author_name", DropDownList3.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@publisher_name", DropDownList2.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@publish_date", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@language", DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@edition", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@book_cost", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@no_of_pages", TextBox9.Text.Trim());
                cmd.Parameters.AddWithValue("@book_description", TextBox10.Text.Trim());
                cmd.Parameters.AddWithValue("@actual_stock", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@current_stock", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@book_img_link", filepath);

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Book added successfully!');</script>");
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                //because in the message we can have ' we will replace this
                var safeMessage = ex.Message.Replace("'", "\\'");
                Response.Write("<script>alert('" + safeMessage + "');</script>");
            }
        }

        void get_book_by_id()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                    con.Open();

                //add the authors
                SqlCommand cmd = new SqlCommand("SELECT * FROM book_master_tbl WHERE book_id = '" + TextBox2.Text.Trim() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd); //dissconnected arhitecture
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    TextBox1.Text = dt.Rows[0]["book_name"].ToString();
                    DropDownList1.SelectedValue = dt.Rows[0]["language"].ToString().Trim();
                    DropDownList2.SelectedValue = dt.Rows[0]["publisher_name"].ToString().Trim();
                    DropDownList3.SelectedValue = dt.Rows[0]["author_name"].ToString().Trim();
                    TextBox3.Text = dt.Rows[0]["publish_date"].ToString();
                    ListBox1.ClearSelection(); //clear the previous selections from the ListBox

                    string[] delimitators = { ", " };
                    string[] genre = dt.Rows[0]["genre"].ToString().Trim().Split(delimitators, StringSplitOptions.None);
                    //when we use a string parameter instead of a simple ',' parameter we have to use the second parameter
                    //for the split function

                    //we search every component of the genre string and compare with de Multy Select List Box
                    //if we find a match, we select it
                    for (int i = 0; i < genre.Length; i++)
                        for (int j = 0; j < ListBox1.Items.Count; j++)
                            if (ListBox1.Items[j].ToString() == genre[i])
                                ListBox1.Items[j].Selected = true;

                    TextBox5.Text = dt.Rows[0]["edition"].ToString();
                    TextBox6.Text = dt.Rows[0]["book_cost"].ToString().Trim(); //because it number type and we want to eliminate some escape sequences of extra spaces
                    TextBox9.Text = dt.Rows[0]["no_of_pages"].ToString().Trim();
                    TextBox4.Text = dt.Rows[0]["actual_stock"].ToString().Trim();
                    TextBox7.Text = dt.Rows[0]["current_stock"].ToString().Trim();
                    TextBox8.Text = "" + (Convert.ToInt32(dt.Rows[0]["actual_stock"].ToString()) - Convert.ToInt32(dt.Rows[0]["current_stock"].ToString()));
                    TextBox10.Text = dt.Rows[0]["book_description"].ToString();

                    global_actual_stock = Convert.ToInt32(dt.Rows[0]["actual_stock"].ToString().Trim());
                    global_current_stock = Convert.ToInt32(dt.Rows[0]["current_stock"].ToString().Trim());
                    global_issued_books = global_actual_stock - global_current_stock;
                    global_file_path = dt.Rows[0]["book_img_link"].ToString();
                }
                else
                    Response.Write("<script>alert('Invalid Book ID!');</script>");

                con.Close();
            }
            catch (Exception ex)
            {
                //because in the message we can have ' we will replace this
                var safeMessage = ex.Message.Replace("'", "\\'");
                Response.Write("<script>alert('" + safeMessage + "');</script>");
            }
        }

        void update_book_by_id()
        {
            try
            {
                int actual_stock = Convert.ToInt32(TextBox4.Text.Trim());
                int current_stock = Convert.ToInt32(TextBox7.Text.Trim());

                //verify so that the admin cannot add an actual stock less than the issued books stock
                if (global_actual_stock != actual_stock)
                    if (actual_stock < global_issued_books)
                        Response.Write("<script>alert('Actual Stock value can not be less than the Issued Books value!');</script>");
                    else
                    {
                        current_stock = actual_stock - global_issued_books;
                        TextBox7.Text = "" + current_stock;
                    }

                //we can select multiple genres
                string genres = "";
                foreach (int i in ListBox1.GetSelectedIndices())
                    genres = genres + ListBox1.Items[i] + ", ";

                //for the last item we want to remove the comma and space
                genres = genres.Remove(genres.Length - 2);

                //upload image file
                string filepath = "~/bookinventory/books2.png";
                string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                if (filename == "" || filename == null)
                    filepath = global_file_path; //if the admin didn't select a new image, we put the old image
                else
                {
                    FileUpload1.SaveAs(Server.MapPath("bookinventory/" + filename));
                    filepath = "~/bookinventory/" + filename;
                }

                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                    con.Open();
                //create the SQL Query
                SqlCommand cmd = new SqlCommand("UPDATE book_master_tbl SET book_name = @book_name, " +
                    "genre = @genre, author_name = @author_name, publisher_name = @publisher_name, " +
                    "publish_date = @publish_date, language = @language, edition = @edition, " +
                    "book_cost = @book_cost, no_of_pages = @no_of_pages, book_description = @book_description, " +
                    "actual_stock = @actual_stock, current_stock = @current_stock, book_img_link = @book_img_link " +
                    "WHERE book_id = '" + TextBox2.Text.Trim() + "' ", con);

                cmd.Parameters.AddWithValue("@book_name", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@genre", genres);
                cmd.Parameters.AddWithValue("@author_name", DropDownList3.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@publisher_name", DropDownList2.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@publish_date", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@language", DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@edition", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@book_cost", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@no_of_pages", TextBox9.Text.Trim());
                cmd.Parameters.AddWithValue("@book_description", TextBox10.Text.Trim());
                cmd.Parameters.AddWithValue("@actual_stock", actual_stock.ToString());
                cmd.Parameters.AddWithValue("@current_stock", current_stock.ToString());
                cmd.Parameters.AddWithValue("@book_img_link", filepath);

                cmd.ExecuteNonQuery();
                con.Close();
                GridView1.DataBind();
                Response.Write("<script>alert('Book Updated Successfully!');</script>");
            }
            catch (Exception ex)
            {
                //because in the message we can have ' we will replace this
                var safeMessage = ex.Message.Replace("'", "\\'");
                Response.Write("<script>alert('" + safeMessage + "');</script>");
            }
        }

        void delete_book_by_id()
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
                SqlCommand cmd = new SqlCommand("DELETE FROM book_master_tbl " +
                    "WHERE book_id = '" + TextBox2.Text.ToString() + "'", con);

                //get the values to the placeholders from the textboxes(front-end)
                cmd.Parameters.AddWithValue("@member_id", TextBox2.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close(); //close the connection

                Response.Write("<script>alert('Book Deleted Successfully!');</script>");

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