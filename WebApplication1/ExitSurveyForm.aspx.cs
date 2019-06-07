using System;
using System.Collections.Generic;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class ExitSurveyForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["login"];
            if(cookie == null)
            {
                Response.Redirect("HomePage.aspx");
            }
            else
            {
                if(cookie["admin"] == "1")
                {
                    Response.Redirect("AdminHomePage.aspx");
                }
                else
                {
                    surveyform();
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = @"Data Source=(localdb)\MSSQLlocalDB;Initial Catalog=StudentRegistration;Integrated Security=True";
                    SqlCommand cmd = new SqlCommand("SELECT regno,name,branch,passingyear,companyname FROM student WHERE regno=@regno",con);
                    cmd.Parameters.AddWithValue("@regno",cookie["regno"]);
                    try
                    {
                        con.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        reader.Read();
                        TextBox1.Text = reader["regno"].ToString();
                        TextBox2.Text = reader["name"].ToString();
                        DropDownList1.Items.FindByText(reader["branch"].ToString()).Selected = true;
                        TextBox3.Text = reader["passingyear"].ToString();
                        TextBox4.Text = reader["companyname"].ToString();
                    }
                    catch(Exception err) { }
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }

        protected void surveyform()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(localdb)\MSSQLlocalDB;Initial Catalog=StudentRegistration;Integrated Security=True";
            SqlCommand cmd = new SqlCommand("SELECT regno FROM exitsurveyform",con);
            HttpCookie cookie = Request.Cookies["login"];
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if(cookie["regno"] == reader["regno"].ToString())
                    {
                        id1.Style["display"] = "none";
                        Label14.Visible = true;
                        break;
                    }
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
            if (Page.IsValid)
            {
                HttpCookie cookie = Request.Cookies["login"];
                int reg;
                int.TryParse(cookie["regno"], out reg);
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=(localdb)\MSSQLlocalDB;Initial Catalog=StudentRegistration;Integrated Security=True";
                string str = "INSERT INTO exitsurveyform (regno,a1,a2,a3,a4,a5,a6,a7,a8) VALUES(@regno,@a1,@a2,@a3,@a4,@a5,@a6,@a7,@a8)";
                SqlCommand cmd = new SqlCommand(str, con);
                cmd.Parameters.AddWithValue("@regno", reg);
                cmd.Parameters.AddWithValue("@a1", RadioButtonList1.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@a2", RadioButtonList2.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@a3", RadioButtonList3.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@a4", RadioButtonList4.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@a5", RadioButtonList5.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@a6", RadioButtonList6.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@a7", RadioButtonList7.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@a8", RadioButtonList8.SelectedItem.Text);
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    surveyform();
                }
                catch (Exception err) { }
                finally
                {
                    con.Close();
                }
            }
        }
    }
}