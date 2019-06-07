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
    public partial class AdminStudentDetails : System.Web.UI.Page
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
                    {
                        if(Session["Theme"]!=null)
                            DropDownList1.Items.FindByText(Session["Theme"].ToString()).Selected = true;
                    }                     
                }
            }
        }

        protected void Page_PreInit(object sender, EventArgs e)
        {
            if(Session["Theme"] != null)
             Page.Theme = Session["Theme"].ToString();
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["Theme"] = DropDownList1.SelectedItem.Text;
            Server.Transfer(Request.FilePath);
        }
    }
}