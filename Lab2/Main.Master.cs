using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab2
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        public static string visitor = "Account";

        protected void Page_Load(object sender, EventArgs e)
        {
            hh.InnerHtml = visitor;
        }
    }
}