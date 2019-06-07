using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
                id1.Style["display"] = "block";
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if(RequiredFieldValidator1.IsValid && RegularExpressionValidator1.IsValid && CustomValidator1.IsValid)
            {
                id1.Style["display"] = "none";
                id2.Style["display"] = "block";
                id3.Style["display"] = "none";
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (RequiredFieldValidator2.IsValid && CustomValidator2.IsValid)
            {
                id1.Style["display"] = "none";
                id2.Style["display"] = "none";
                id3.Style["display"] = "block";
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if(RequiredFieldValidator3.IsValid && RequiredFieldValidator4.IsValid && CompareValidator1.IsValid && RegularExpressionValidator2.IsValid)
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=(localdb)\MSSQLlocalDB;Initial Catalog=StudentRegistration;Integrated Security=True";
                SqlCommand cmd = new SqlCommand("UPDATE student SET password=@password WHERE regno=@regno", con);
                cmd.Parameters.AddWithValue("@regno",TextBox1.Text);
                cmd.Parameters.AddWithValue("@password",TextBox3.Text);
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    Response.Redirect("login.aspx");
                }
                catch (Exception err) { }
                finally
                {
                    con.Close();
                }
            }
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(localdb)\MSSQLlocalDB;Initial Catalog=StudentRegistration;Integrated Security=True";
            SqlCommand cmd = new SqlCommand("SELECT regno FROM student", con);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                args.IsValid = false;
                while (reader.Read())
                {
                    if (TextBox1.Text == reader["regno"].ToString())
                    {
                        args.IsValid = true;
                        break;
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

        protected void CustomValidator2_ServerValidate(object source, ServerValidateEventArgs args)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(localdb)\MSSQLlocalDB;Initial Catalog=StudentRegistration;Integrated Security=True";
            SqlCommand cmd = new SqlCommand("SELECT secretquestion,answer FROM student WHERE regno=@regno", con);
            int reg;
            int.TryParse(TextBox1.Text, out reg); ;
            cmd.Parameters.AddWithValue("@regno",reg);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                args.IsValid = false;
                while (reader.Read())
                {
                    if (DropDownList1.SelectedItem.Text == reader["secretquestion"].ToString() && TextBox2.Text == reader["answer"].ToString())
                    {
                        args.IsValid = true;
                        break;
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
    }
}