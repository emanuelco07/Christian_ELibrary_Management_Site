using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ElibraryManagement
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["role"]?.Equals("") == true) //we put the ? mark becausse the output is null
                {
                    LinkButton1.Visible = true; //user login link button
                    LinkButton2.Visible = true; //user sign up link button

                    LinkButton3.Visible = false; //user log out link button
                    LinkButton5.Visible = false; //user message link button

                    LinkButton6.Visible = true; //admin login link button

                    LinkButton7.Visible = false; //admin author management link button
                    LinkButton8.Visible = false; //admin publisher managemetn link button
                    LinkButton9.Visible = false; //admin book inventory link button
                    LinkButton10.Visible = false; //admin book issuing link button
                    LinkButton11.Visible = false; //admin member management link button
                }
                else if (Session["role"]?.Equals("user") == true) //we put the ? mark becausse the output can be null
                {
                    LinkButton1.Visible = false; //user login link button
                    LinkButton2.Visible = false; //user sign up link button

                    LinkButton3.Visible = true; //user log out link button
                    LinkButton5.Visible = true; //user message link button
                    LinkButton5.Text = "Hello, " + Session["username"].ToString(); //hello, user message

                    LinkButton6.Visible = true; //admin login link button

                    LinkButton7.Visible = false; //admin author management link button
                    LinkButton8.Visible = false; //admin publisher managemetn link button
                    LinkButton9.Visible = false; //admin book inventory link button
                    LinkButton10.Visible = false; //admin book issuing link button
                    LinkButton11.Visible = false; //admin member management link button
                }
                else if (Session["role"]?.Equals("admin") == true) //we put the ? mark becausse the output can be null
                {
                    LinkButton1.Visible = false; //user login link button
                    LinkButton2.Visible = false; //user sign up link button

                    LinkButton3.Visible = true; //admin log out link button
                    LinkButton5.Visible = true; //user message link button
                    LinkButton5.Text = "Hello, Admin"; //hello, admin message

                    LinkButton6.Visible = false; //admin login link button

                    LinkButton7.Visible = true; //admin author management link button
                    LinkButton8.Visible = true; //admin publisher managemetn link button
                    LinkButton9.Visible = true; //admin book inventory link button
                    LinkButton10.Visible = true; //admin book issuing link button
                    LinkButton11.Visible = true; //admin member management link button
                }
            }
            catch (Exception ex)
            {
                //because in the message we can have ' we will replace this
                var safeMessage = ex.Message.Replace("'", "\\'");
                Response.Write("<script>alert('" + safeMessage + "');</script>");
            }
        }

        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminlogin.aspx");
        }

        protected void LinkButton7_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminauthormanagement.aspx");
        }

        protected void LinkButton8_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminpublishermanagement.aspx");
        }

        protected void LinkButton9_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminbookinventory.aspx");
        }

        protected void LinkButton10_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminbookissuing.aspx");
        }

        protected void LinkButton11_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminmembermanagement.aspx");
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewbooks.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("userlogin.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("usersignup.aspx");
        }

        //logout button
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Session["username"] = "";
            Session["full_name"] = "";
            Session["role"] = "";
            Session["status"] = "";

            LinkButton1.Visible = true; //user login link button
            LinkButton2.Visible = true; //user sign up link button

            LinkButton3.Visible = false; //user log out link button
            LinkButton5.Visible = false; //user message link button

            LinkButton6.Visible = true; //admin login link button

            LinkButton7.Visible = false; //admin author management link button
            LinkButton8.Visible = false; //admin publisher managemetn link button
            LinkButton9.Visible = false; //admin book inventory link button
            LinkButton10.Visible = false; //admin book issuing link button
            LinkButton11.Visible = false; //admin member management link button

            Response.Redirect("homepage.aspx");
        }

        //view profile
        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            Response.Redirect("userprofile.aspx");
        }
    }
}