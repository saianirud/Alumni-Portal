using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class FurtherRegistration : System.Web.UI.Page
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
                Control c1 = Master.FindControl("id01");
                c1.Visible = false;
                Control c2 = Master.FindControl("id02");
                c2.Visible = false;
                if (!IsPostBack)
                {
                    id4.Style["display"] = "block";
                    id5.Style["display"] = "none";
                    id6.Style["display"] = "none";

                    id1.Style["font-weight"] = "bold";
                    id2.Style["font-weight"] = "400";
                    id3.Style["font-weight"] = "400";
                }
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            RequiredFieldValidator5.Validate();
            if (RequiredFieldValidator5.IsValid)
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=(localdb)\MSSQLlocalDB;Initial Catalog=StudentRegistration;Integrated Security=True";
                try
                {
                    con.Open();
                    HttpCookie cookie = Request.Cookies["login"];
                    string str = "UPDATE student SET name=@name,";
                    if (TextBox2.Text != "")
                        str += "email=@email,";
                    if (TextBox5.Text != "")
                        str += "phoneno=@phoneno,";
                    str += "branch=@branch,";
                    if (TextBox4.Text != "")
                        str += "cgpa=@cgpa,";
                    str += "passingyear=@py,";
                    if(DropDownList1.SelectedItem.Text != "Select")
                        str += "gender=@gender,";
                    if (TextBox7.Text != "")
                        str += "dob=@dob,";
                    str += "companyname=@cmpname,";
                    if (TextBox10.Text != "")
                        str += "companylocation=@cmploc,";
                    if (TextBox9.Text != "")
                        str += "companywebsite=@cmpweb,";
                    if (TextBox11.Text != "")
                        str += "companyphone=@cmpphone,";
                    str += "secretquestion=@secretq,";
                    str += "answer=@answer";
                    SqlCommand cmd = new SqlCommand(str + " WHERE regno=@regno", con);
                    cmd.Parameters.AddWithValue("@regno", cookie["regno"]);
                    cmd.Parameters.AddWithValue("@name", TextBox1.Text);
                    if (TextBox2.Text != "")
                        cmd.Parameters.AddWithValue("@email", TextBox2.Text);
                    if (TextBox5.Text != "")
                    {
                        long no;
                        long.TryParse(TextBox5.Text, out no);
                        cmd.Parameters.AddWithValue("@phoneno", no);
                    }
                    cmd.Parameters.AddWithValue("@branch", DropDownList3.SelectedItem.Text);
                    if (TextBox4.Text != "")
                    {
                        float no;
                        float.TryParse(TextBox4.Text, out no);
                        cmd.Parameters.AddWithValue("@cgpa", no);
                    }
                    int py;
                    int.TryParse(TextBox6.Text, out py);
                    cmd.Parameters.AddWithValue("@py", py);
                    if(DropDownList1.SelectedItem.Text != "Select")
                        cmd.Parameters.AddWithValue("@gender", DropDownList1.SelectedItem.Text);
                    if (TextBox7.Text != "")
                        cmd.Parameters.AddWithValue("@dob", TextBox7.Text);
                    cmd.Parameters.AddWithValue("@cmpname", TextBox8.Text);
                    if (TextBox10.Text != "")
                        cmd.Parameters.AddWithValue("@cmploc", TextBox10.Text);
                    if (TextBox9.Text != "")
                        cmd.Parameters.AddWithValue("@cmpweb", TextBox9.Text);
                    if (TextBox11.Text != "")
                    {
                        long no;
                        long.TryParse(TextBox11.Text, out no);
                        cmd.Parameters.AddWithValue("@cmpphone", no);
                    }
                    cmd.Parameters.AddWithValue("@secretq", DropDownList2.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@answer", TextBox12.Text);
                    cmd.ExecuteNonQuery();
                    Response.Redirect("ExitSurveyForm.aspx");
                }
                catch (Exception err) { }
                finally
                {
                    con.Close();
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            RequiredFieldValidator1.Validate();CustomValidator1.Validate();RequiredFieldValidator3.Validate();RegularExpressionValidator1.Validate();RegularExpressionValidator2.Validate();RegularExpressionValidator3.Validate();RegularExpressionValidator4.Validate();
            if(RequiredFieldValidator1.IsValid && CustomValidator1.IsValid && RequiredFieldValidator3.IsValid && RegularExpressionValidator1.IsValid && RegularExpressionValidator2.IsValid && RegularExpressionValidator3.IsValid && RegularExpressionValidator4.IsValid)
            {
                id4.Style["display"] = "none";
                id5.Style["display"] = "block";
                id6.Style["display"] = "none";

                id1.Style["font-weight"] = "400";
                id2.Style["font-weight"] = "bold";
                id3.Style["font-weight"] = "400";
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            RequiredFieldValidator4.Validate();
            if (RequiredFieldValidator4.IsValid)
            {
                id4.Style["display"] = "none";
                id5.Style["display"] = "none";
                id6.Style["display"] = "block";

                id1.Style["font-weight"] = "400";
                id2.Style["font-weight"] = "400";
                id3.Style["font-weight"] = "bold";
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            id4.Style["display"] = "block";
            id5.Style["display"] = "none";
            id6.Style["display"] = "none";

            id1.Style["font-weight"] = "bold";
            id2.Style["font-weight"] = "400";
            id3.Style["font-weight"] = "400";
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            id4.Style["display"] = "none";
            id5.Style["display"] = "block";
            id6.Style["display"] = "none";

            id1.Style["font-weight"] = "400";
            id2.Style["font-weight"] = "bold";
            id3.Style["font-weight"] = "400";
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (DropDownList3.SelectedItem.Text == "Select")
                args.IsValid = false;
            else
                args.IsValid = true;
        }
    }
}