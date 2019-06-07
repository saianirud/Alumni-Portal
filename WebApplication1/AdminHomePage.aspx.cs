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
    public partial class AdminHomePage : System.Web.UI.Page
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
                if (cookie["admin"] == "0")
                    Response.Redirect("StudentHomePage.aspx");
                else
                {
                    Control c = Master.FindControl("id02");
                    c.Visible = false;
                    if (!IsPostBack)
                        databind();
                }
            }
        }

        protected void databind()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(localdb)\MSSQLlocalDB;Initial Catalog=StudentRegistration;Integrated Security=True";
            SqlCommand cmd = new SqlCommand("SELECT * FROM student",con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "temp");
            GridView1.DataSource = ds;
            GridView1.DataBind();
            cmd = new SqlCommand("SELECT DISTINCT passingyear FROM student",con);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                DropDownList1.Items.Clear();
                DropDownList1.Items.Add("Select");
                while (reader.Read())
                {
                    DropDownList1.Items.Add(reader["passingyear"].ToString());
                }
            }
            catch (Exception err) { }
            finally
            {
                con.Close();
            }
            cmd = new SqlCommand("SELECT DISTINCT branch FROM student", con);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                DropDownList2.Items.Clear();
                DropDownList2.Items.Add("Select");
                while (reader.Read())
                {
                    DropDownList2.Items.Add(reader["branch"].ToString());
                }
            }
            catch (Exception err) { }
            finally
            {
                con.Close();
            }
            cmd = new SqlCommand("SELECT DISTINCT companyname FROM student", con);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                DropDownList3.Items.Clear();
                DropDownList3.Items.Add("Select");
                while (reader.Read())
                {
                    DropDownList3.Items.Add(reader["companyname"].ToString());
                }
            }
            catch (Exception err) { }
            finally
            {
                con.Close();
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            id1.Style["animation"] = "animatezoom 0.3s";
            if (id1.Style["display"] == "block")
            {
                id1.Style["display"] = "none";
            }
            else
            {
                id1.Style["display"] = "block";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            id1.Style["animation"] = "animatezoom 0s";
            if (DropDownList1.Text != "Select" || DropDownList2.Text != "Select" || DropDownList3.Text != "Select")
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=(localdb)\MSSQLlocalDB;Initial Catalog=StudentRegistration;Integrated Security=True";
                string query = "SELECT * FROM student WHERE ";
                if (DropDownList1.Text != "Select")
                {
                    query += "passingyear=@py";
                    if (DropDownList2.Text != "Select" || DropDownList3.Text != "Select")
                        query += " and ";
                }
                if (DropDownList2.Text != "Select")
                {
                    query += "branch=@branch";
                    if (DropDownList3.Text != "Select")
                        query += " and ";
                }
                if (DropDownList3.Text != "Select")
                {
                    query += "companyname=@company";
                }
                SqlCommand cmd = new SqlCommand(query, con);
                if (DropDownList1.Text != "Select")
                    cmd.Parameters.AddWithValue("@py", DropDownList1.Text);
                if (DropDownList2.Text != "Select")
                    cmd.Parameters.AddWithValue("@branch", DropDownList2.Text);
                if (DropDownList3.Text != "Select")
                    cmd.Parameters.AddWithValue("@company", DropDownList3.Text);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "temp");
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
            else
                databind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            id1.Style["animation"] = "animatezoom 0s";
            databind();
        }
    }
}