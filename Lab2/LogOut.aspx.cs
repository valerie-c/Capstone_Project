using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab2
{
    public partial class LogOut : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null) 
            {
                Session["InvalidUsage"] = "You must first Log In to view the site!"; 
                Response.Redirect("HomePage.aspx"); 
            } 
            else 
            {
                lblUserStatus.Text = Session["UserName"].ToString() + ", please click in button below to logout. Have a nice day!";
            }
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Site1.visitor = "Visitor";
            Session.Abandon();
            Response.Redirect("Login.aspx?loggeout =true");
        }
    }
}