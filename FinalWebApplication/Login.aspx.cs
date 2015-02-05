using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalWebApplication
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    //Checking the session for Error Messages and displaying them accordingly.
                    Session["USERID"] = "";
                    if (Session["ErrorMsg"] != null)
                    {
                        if (Session["ErrorMsg"].ToString().Length > 0)
                        {
                            if (Session["ErrorMsg"].ToString().Equals("Logged Out"))
                            {
                                txtLoginID.Text = "";
                            }
                            else
                            {
                                lblErrorMsg.Text = Session["ErrorMsg"].ToString() + ". Please enter valid User ID";
                                lblErrorMsg.Visible = true;
                            }
                        }
                    }
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine("Exception: " + exp.Message);
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtLoginID.Text.Trim().Length > 0)
            {
                //Passing the USER ID to the next page.
                Session["USERID"] = txtLoginID.Text.Trim();
                Response.Redirect("AuthorizeUser.aspx", false);
            }
            else
            {
                lblErrorMsg.Text = "Please enter User ID";
                lblErrorMsg.Visible = true;
            }
        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registration.aspx", false);
        }
    }
}