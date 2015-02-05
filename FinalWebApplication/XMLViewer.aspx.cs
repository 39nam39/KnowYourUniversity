using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace FinalWebApplication
{
    public partial class XMLViewer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["XMLType"].ToString().Equals("1"))
                {
                    FileStream FS = new FileStream(Path.Combine(Request.PhysicalApplicationPath, @"App_Data\univ.xml"), FileMode.Open, FileAccess.Read);
                    XmlDocument xdoc = new XmlDocument();

                    if (File.Exists(Path.Combine(Request.PhysicalApplicationPath, @"App_Data\univ.xml")))
                    {
                        xdoc.Load(FS);
                        FS.Close();
                        txtXMLArea.Text = xdoc.InnerXml;
                    }
                    else
                    {
                        lblError.Text = "Such a file doesnt exist";
                    }
                }
                else
                {
                    FileStream FS = new FileStream(Path.Combine(Request.PhysicalApplicationPath, @"App_Data\userDetails.xml"), FileMode.Open, FileAccess.Read);
                    XmlDocument xdoc = new XmlDocument();

                    if (File.Exists(Path.Combine(Request.PhysicalApplicationPath, @"App_Data\userDetails.xml")))
                    {
                        xdoc.Load(FS);
                        FS.Close();
                        txtXMLArea.Text = xdoc.InnerXml;
                    }
                    else
                    {
                        lblError.Text = "Such a file doesnt exist";
                    }
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine("Exception: " + exp.Message);
                Response.Redirect("Default.aspx", false);
            }
        }
    }
}