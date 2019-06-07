using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Site2 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(localdb)\MSSQLlocalDB;Initial Catalog=StudentRegistration;Integrated Security=True";
            HttpCookie cookie = Request.Cookies["login"];
            SqlCommand cmd;
            try
            {
                con.Open();
                if(cookie["admin"] == "1")
                    cmd = new SqlCommand("SELECT name FROM admin where id=@regno", con);
                else
                    cmd = new SqlCommand("SELECT name FROM student where regno=@regno", con);
                cmd.Parameters.AddWithValue("@regno", cookie["regno"]);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Label2.Text = reader["name"].ToString();
                    if(Session["lastlogin"] == null)
                    {
                        SqlConnection con1 = new SqlConnection();
                        con1.ConnectionString = @"Data Source=(localdb)\MSSQLlocalDB;Initial Catalog=StudentRegistration;Integrated Security=True";
                        SqlCommand cmd1;
                        if(cookie["admin"] == "1")
                            cmd1= new SqlCommand("SELECT lastlogin FROM admin WHERE id=@regno", con1);
                        else
                            cmd1 = new SqlCommand("SELECT lastlogin FROM student WHERE regno=@regno", con1);
                        cmd1.Parameters.AddWithValue("@regno", cookie["regno"]);
                        try
                        {
                            con1.Open();
                            SqlDataReader reader1 = cmd1.ExecuteReader();
                            reader1.Read();
                            Session["lastlogin"] = reader1["lastlogin"];
                        }
                        catch (Exception err) { }
                        finally
                        {
                            con1.Close();
                        }
                    }
                    Label4.Text = Session["lastlogin"].ToString();
                }
            }
            catch (Exception err) { }
            finally
            {
                con.Close();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["login"];
            cookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(cookie);
            Response.Redirect("HomePage.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentHomePage.aspx");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("CompanyDetails.aspx");
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            Response.Redirect("ExitSurveyForm.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentHomePage.aspx");
        }
    }
}