using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["login"];
            if (cookie != null)
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=(localdb)\MSSQLlocalDB;Initial Catalog=StudentRegistration;Integrated Security=True";
                SqlCommand cmd;
                if(cookie["admin"] == "1")
                    cmd = new SqlCommand("SELECT lastlogin FROM admin WHERE id=@regno", con);
                else
                    cmd = new SqlCommand("SELECT lastlogin FROM student WHERE regno=@regno", con);
                cmd.Parameters.AddWithValue("@regno", cookie["regno"]);
                try
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();
                    Session["lastlogin"] = reader["lastlogin"];
                }
                catch (Exception err) { }
                finally
                {
                    con.Close();
                }
                if(cookie["admin"] == "1")
                    Response.Redirect("AdminHomePage.aspx");
                else
                    Response.Redirect("StudentHomePage.aspx");
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if(RequiredFieldValidator1.IsValid && RequiredFieldValidator2.IsValid && RegularExpressionValidator1.IsValid && CustomValidator1.IsValid)
            {
                int id;
                int.TryParse(TextBox1.Text, out id);
                HttpCookie cookie = Request.Cookies["login"];
                if (cookie == null)
                {
                    cookie = new HttpCookie("login");
                    cookie["admin"]= "1";
                    cookie.Expires = DateTime.Now.AddYears(1);
                }
                cookie["regno"] = id.ToString();
                Response.Cookies.Add(cookie);
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=(localdb)\MSSQLlocalDB;Initial Catalog=StudentRegistration;Integrated Security=True";
                SqlCommand cmd = new SqlCommand("SELECT lastlogin FROM admin WHERE id=@regno", con);
                cmd.Parameters.AddWithValue("@regno", cookie["regno"]);
                try
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();
                    Session["lastlogin"] = reader["lastlogin"];
                }
                catch (Exception err) { }
                finally
                {
                    con.Close();
                }

                try
                {
                    con.Open();
                    cmd = new SqlCommand("UPDATE admin SET lastlogin=@lastlogin WHERE id=@regno", con);
                    cmd.Parameters.AddWithValue("@regno", cookie["regno"]);
                    cmd.Parameters.AddWithValue("@lastlogin", DateTime.Now);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception err) { }
                finally
                {
                    con.Close();
                }
                Response.Redirect("AdminHomePage.aspx");
            }
            else
            {
                id1.Style["display"] = "block";
                id2.Style["animation"] = "animatezoom 0s";
            }
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(localdb)\MSSQLlocalDB;Initial Catalog=StudentRegistration;Integrated Security=True";
            SqlCommand cmd = new SqlCommand("SELECT id,password FROM admin", con);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                args.IsValid = false;
                while (reader.Read())
                {
                    if (TextBox1.Text == reader["id"].ToString())
                    {
                        if (TextBox2.Text == reader["password"].ToString())
                        {
                            args.IsValid = true;
                            break;
                        }
                    }
                }
            }
            catch (Exception err)
            {
                args.IsValid = false;
            }
            finally
            {
                con.Close();
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");
        }
    }
}