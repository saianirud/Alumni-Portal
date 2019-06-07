using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class CompanyDetails : System.Web.UI.Page
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
                if (!IsPostBack)
                {
                    if (cookie["admin"] == "1")
                        Response.Redirect("AdminHomePage.aspx");
                    else
                        databind();
                }
            }
        }

        protected void databind()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(localdb)\MSSQLlocalDB;Initial Catalog=StudentRegistration;Integrated Security=True";
            HttpCookie cookie = Request.Cookies["login"];
            SqlCommand cmd = new SqlCommand("SELECT companyname,companylocation,companywebsite,companyphone FROM student WHERE regno=@regno", con);
            cmd.Parameters.AddWithValue("@regno", cookie["regno"]);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "temp");
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
            string cmpname = ((TextBox)DetailsView1.Rows[0].Cells[1].Controls[0]).Text;
            string cmploc = ((TextBox)DetailsView1.Rows[1].Cells[1].Controls[0]).Text;
            string cmpweb = ((TextBox)DetailsView1.Rows[2].Cells[1].Controls[0]).Text;
            string cmpno = ((TextBox)DetailsView1.Rows[3].Cells[1].Controls[0]).Text;
            string str = "UPDATE student SET companyname=@cmpname";
            if (cmploc != "")
                str += ",companylocation=@cmploc";
            if (cmpweb != "")
                str += ",companywebsite=@cmpweb";
            if (cmpno != "")
                str += ",companyphone=@cmpno";
            SqlCommand cmd = new SqlCommand(str+" WHERE regno=@regno", con);
            int reg;
            int.TryParse(cookie["regno"], out reg);
            cmd.Parameters.AddWithValue("@regno", reg);
            cmd.Parameters.AddWithValue("@cmpname", cmpname);
            if (cmploc != "")
                cmd.Parameters.AddWithValue("@cmploc", cmploc);
            if (cmpweb != "")
                cmd.Parameters.AddWithValue("@cmpweb", cmpweb);
            if (cmpno != "")
                cmd.Parameters.AddWithValue("@cmpno", cmpno);
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