using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalWebApplication
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx", false);
        }

        protected void btnUnivXML_Click(object sender, EventArgs e)
        {
            Session["XMLType"] = 1;
            Response.Redirect("XMLViewer.aspx", false);
        }

        protected void btnUserXML_Click(object sender, EventArgs e)
        {
            Session["XMLType"] = 2;
            Response.Redirect("XMLViewer.aspx", false);
        }
    }
}