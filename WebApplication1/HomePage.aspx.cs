using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["login"];
            if (cookie != null)
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=(localdb)\MSSQLlocalDB;Initial Catalog=StudentRegistration;Integrated Security=True";
                SqlCommand cmd;
                if (cookie["admin"] == "1")
                    cmd = new SqlCommand("SELECT lastlogin FROM admin WHERE id=@regno", con);
                else
                    cmd = new SqlCommand("SELECT lastlogin FROM student WHERE regno=@regno", con);
                cookie = Request.Cookies["login"];
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
    }
}