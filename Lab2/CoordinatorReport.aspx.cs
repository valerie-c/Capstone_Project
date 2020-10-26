using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Configuration;

namespace Lab2
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //GridView1.DataSource = SqlDataSource1;
            //GridView1.DataBind();
         
        }

  

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "volunteer")
            {
                Label2.Visible = true;
                GridView3.Visible = true;
            }

            if(e.CommandName == "attendee")
            {
                Label1.Visible = true;
                GridView2.Visible = true;
            }
        }
    }
}