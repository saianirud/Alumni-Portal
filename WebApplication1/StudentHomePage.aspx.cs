using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

namespace WebApplication1
{
    public partial class studenthomepage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["login"];
            if (cookie == null)
            {
                Response.Redirect("HomePage.aspx");
            }
            else
            {
                if (cookie["admin"] == "1")
                    Response.Redirect("AdminHomePage.aspx");
                else
                {
                    if (!IsPostBack)
                    {
                        databind();
                    }
                }
            }
        }

        protected void databind()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(localdb)\MSSQLlocalDB;Initial Catalog=StudentRegistration;Integrated Security=True";
            HttpCookie cookie = Request.Cookies["login"];
            SqlCommand cmd = new SqlCommand("SELECT regno,name,email,phoneno,branch,cgpa,passingyear,gender,dob FROM student WHERE regno=@regno", con);
            cmd.Parameters.AddWithValue("@regno", cookie["regno"]);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "temp");
            foreach(DataRow row in ds.Tables["temp"].Rows)
            {
                Label label = (Label)Master.FindControl("Label2");
                label.Text = row["name"].ToString();
            }
            DetailsView1.DataSource = ds;
            DetailsView1.DataBind();
        }

        protected void DetailsView1_ModeChanging(object sender, DetailsViewModeEventArgs e)
        {
            if (DetailsView1.CurrentMode == DetailsViewMode.ReadOnly)
            {
                DetailsView1.ChangeMode(DetailsViewMode.Edit);
                databind();
            }
            else if (DetailsView1.CurrentMode == DetailsViewMode.Edit)
            {

                DetailsView1.ChangeMode(DetailsViewMode.ReadOnly);
                databind();
            }
        }

        protected void DetailsView1_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(localdb)\MSSQLlocalDB;Initial Catalog=StudentRegistration;Integrated Security=True";
            HttpCookie cookie = Request.Cookies["login"];
            string name = ((TextBox)DetailsView1.Rows[1].Cells[1].Controls[0]).Text;
            string gender = ((TextBox)DetailsView1.Rows[2].Cells[1].Controls[0]).Text;
            string email = ((TextBox)DetailsView1.Rows[3].Cells[1].Controls[0]).Text;
            string phone = ((TextBox)DetailsView1.Rows[4].Cells[1].Controls[0]).Text;
            string dob = ((TextBox)DetailsView1.Rows[5].Cells[1].Controls[0]).Text;
            string branch = ((TextBox)DetailsView1.Rows[6].Cells[1].Controls[0]).Text;
            string cgpa = ((TextBox)DetailsView1.Rows[7].Cells[1].Controls[0]).Text;
            int passingyear;
            int.TryParse(((TextBox)DetailsView1.Rows[8].Cells[1].Controls[0]).Text,out passingyear);
            string str= "UPDATE student SET name=@name";
            if (gender != "")
                str += ",gender=@gender";
            if (email != "")
                str += ",email=@email";
            if (phone != "")
                str += ",phoneno=@phone";
            if (dob != "")
                str += ",dob=@dob";
            str += ",branch=@branch";
            if (cgpa != "")
                str += ",cgpa=@cgpa";
            str += ",passingyear=@passingyear";
            SqlCommand cmd = new SqlCommand(str+" WHERE regno=@regno", con);
            int reg;
            int.TryParse(cookie["regno"], out reg);
            cmd.Parameters.AddWithValue("@regno", reg);
            cmd.Parameters.AddWithValue("@name", name);
            if (gender != "")
                cmd.Parameters.AddWithValue("@gender", gender);
            if (email != "")
                cmd.Parameters.AddWithValue("@email", email);
            if (phone != "")
                cmd.Parameters.AddWithValue("@phone", phone);
            if (dob != "")
                cmd.Parameters.AddWithValue("@dob", dob);
            cmd.Parameters.AddWithValue("@branch", branch);
            if (cgpa != "")
            {
                float c;
                float.TryParse(cgpa,out c);
                cmd.Parameters.AddWithValue("@cgpa", c);
            }
            cmd.Parameters.AddWithValue("@passingyear", passingyear);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception err) { }
            finally
            {
                DetailsView1.ChangeMode(DetailsViewMode.ReadOnly);
                databind();
                con.Close();
            }
        }
    }
}