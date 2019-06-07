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
    public partial class AdminStudentSurveyForm : System.Web.UI.Page
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
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = @"Data Source=(localdb)\MSSQLlocalDB;Initial Catalog=StudentRegistration;Integrated Security=True";
                    SqlCommand cmd = new SqlCommand("SELECT q1,a1,q2,a2,q3,a3,q4,a4,q5,a5,q6,a6,q7,a7,q8,a8 FROM exitsurveyform WHERE regno=@regno", con);
                    cmd.Parameters.AddWithValue("@regno", Request.QueryString["regno"].ToString());
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    int r=adapter.Fill(ds, "temp");
                    if(r != 0) {
                        DataTable dt = new DataTable();
                        dt.Columns.Add("Questions");
                        dt.Columns.Add("Answers");
                        for (int i = 0; i < ds.Tables["temp"].Columns.Count; i += 2)
                        {
                            DataRow row = dt.NewRow();
                            for (int j = 0; j < ds.Tables["temp"].Rows.Count; j++)
                            {
                                row[j] = ds.Tables["temp"].Rows[j][i].ToString();
                                row[j + 1] = ds.Tables["temp"].Rows[j][i + 1].ToString();
                            }
                            dt.Rows.Add(row);
                        }
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                    else
                    {
                        Label1.Text = Request.QueryString["regno"].ToString() + " did not submit the form yet.";
                    }
                }
            }
        }
    }
}