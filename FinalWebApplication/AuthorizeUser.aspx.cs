using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using PasswordHash;

namespace FinalWebApplication
{
    public partial class AuthorizeUser : Page
    {
        //Class to map the user details into the XML.
        public class UserDetails
        {
            public string FirstName { set; get; }
            public string LastName { set; get; }
            public string UserName { get; set; }
            public string UserType { get; set; }
            public string SALT { get; set; }
            public string HASH { get; set; }            
            public string SiteKeyIndex { get; set; }
            public string SiteKeyPhrase { get; set; }
        }
        
        static HashPassword objHash = new HashPassword();
        //string filename = @"\\webstrar.fulton.asu.edu\website23\Page2\App_Data\userDetails.xml";
        string filename = string.Empty;

        static UserDetails userDetails = new UserDetails();

        protected void Page_Load(object sender, EventArgs e)
        {
            filename = Path.Combine(Request.PhysicalApplicationPath, @"App_Data\userDetails.xml");
            FileStream FS = new FileStream(filename, FileMode.Open, FileAccess.Read);
            try
            {
                bool bvalidUserID = false;
                if (!IsPostBack)
                {
                    //Checking if the USERID is set appropriately by the previous page.
                    if (Session["USERID"] != null && Session["USERID"].ToString().Length > 0)
                    {
                        XmlDocument xdoc = new XmlDocument();
                        if (File.Exists(filename))
                        {                            
                            xdoc.Load(FS);
                            FS.Close();
                            foreach (XmlNode xmlsinglenode in xdoc.SelectNodes("USERS/User/UserName"))
                            {
                                //Checking if the user name exists in the XML
                                if (Session["USERID"].ToString().ToLower().Equals(xmlsinglenode.InnerText.ToLower()))
                                {
                                    bvalidUserID = true;
                                    XmlNode xmlParentNode = xmlsinglenode.ParentNode;
                                    foreach (XmlNode xmlchildNode in xmlParentNode.ChildNodes)
                                    {
                                        //using reflections map the XML contents into an object
                                        userDetails.GetType().GetProperty(xmlchildNode.Name).SetValue(userDetails, xmlchildNode.InnerText, null);
                                    }
                                    break;
                                }
                            }
                            if (bvalidUserID)
                            {
                                //Setting the appropriate site key and the phrase for the user to vaerify.
                                imgSiteKey.ImageUrl = "./Images/Sitekey/SiteKey" + userDetails.SiteKeyIndex + ".jpg";
                                lblKeyPhrase.Text = userDetails.SiteKeyPhrase;
                            }
                            else
                            {
                                Session["ErrorMsg"] = "Invalid User ID";
                                Response.Redirect("Login.aspx", false);
                            }
                        }
                    }
                    else
                    {
                        Response.Redirect("Login.aspx", false);
                    }
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine("Exception: " + exp.Message);
            }
            finally
            {
                FS.Close();
            }
        }

        private byte[] convertStringtoBytes(string str)
        {
            try
            {
                byte[] byteArray = new byte[str.Length * sizeof(char)];
                System.Buffer.BlockCopy(str.ToCharArray(), 0, byteArray, 0, str.Length);
                return byteArray;
            }
            catch (Exception exp)
            {                
                throw exp;
            }
        }
        protected void btnAUthorize_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkPassword())
                {
                    Session["UserType"] = userDetails.UserType;
                    //Depending upon the type of user, we direct to the respective page
                    if(userDetails.UserType.Equals("Student_User"))
                        Response.Redirect("StudentHome.aspx", false);
                    else if(userDetails.UserType.Equals("Scholar_User"))
                        Response.Redirect("ScholarHome.aspx",false);
                    else
                    {
                        Session["ErrorMsg"] = "Unexpected error";
                        Response.Redirect("Login.aspx",false);
                    }
                }
                else
                {
                    txtPassword.Text = "";
                    lblResult.Text = "Invalid Password";
                    lblResult.Visible = true;
                }
            }
            catch(Exception exp)
            {
                Console.WriteLine("Exception : " + exp.Message);
            }
        }

        private bool checkPassword()
        {
            try
            {
                //Verifying the entered user name and password.
                return objHash.VerifyPassword(txtPassword.Text.Trim(), userDetails.SALT + ":" + userDetails.HASH);
            }
            catch (Exception exp)
            {                
                throw exp;
            }
        }
    }
}