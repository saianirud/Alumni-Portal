using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Register : System.Web.UI.Page
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
                if (cookie["admin"] == "1")
                    Response.Redirect("AdminHomePage.aspx");
                else
                    Response.Redirect("StudentHomePage.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (RequiredFieldValidator1.IsValid && RequiredFieldValidator2.IsValid && RequiredFieldValidator3.IsValid && RegularExpressionValidator1.IsValid && RegularExpressionValidator2.IsValid && CompareValidator1.IsValid && CustomValidator1.IsValid)
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=(localdb)\MSSQLlocalDB;Initial Catalog=StudentRegistration;Integrated Security=True";
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO student (regno,password,lastlogin) VALUES(@regno,@password,@lastlogin)", con);
                    int reg;
                    int.TryParse(TextBox1.Text, out reg);
                    cmd.Parameters.AddWithValue("@regno", reg);
                    cmd.Parameters.AddWithValue("@password", TextBox2.Text);
                    cmd.Parameters.AddWithValue("@lastlogin", DateTime.Now);
                    cmd.ExecuteNonQuery();
                    HttpCookie cookie = Request.Cookies["login"];
                    if (cookie == null)
                    {
                        cookie = new HttpCookie("login");
                        cookie["admin"] = "0";
                        cookie.Expires = DateTime.Now.AddYears(1);
                    }
                    cookie["regno"] = reg.ToString();
                    Response.Cookies.Add(cookie);
                    Session["lastlogin"]= "NA";
                    Response.Redirect("FurtherRegistration.aspx");
                }
                catch (Exception err) { }
                finally
                {
                    con.Close();
                }
            }
            else
            {
                id1.Style["display"] = "block";
                id2.Style["animation"] = "animatezoom 0s";
            }
        }
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(localdb)\MSSQLlocalDB;Initial Catalog=StudentRegistration;Integrated Security=True";
            SqlCommand cmd = new SqlCommand("SELECT regno FROM student",con);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                args.IsValid = true;
                while (reader.Read())
                {
                    if(TextBox1.Text == reader["regno"].ToString())
                    {
                        args.IsValid = false;
                        break;
                    }
                }
            }
            catch(Exception err) { args.IsValid = false; }
            finally
            {
                con.Close();
            }
        }
    }
}