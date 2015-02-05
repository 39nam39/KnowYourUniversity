using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using FinalWebApplication.ImageVerifier;
using PasswordHash;

namespace FinalWebApplication
{
    public partial class Registration : Page
    {
        static string strSiteKey = string.Empty;
        static HashPassword objHash = new HashPassword();
        ServiceClient sc = new ServiceClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblResult.Visible = false;
                img_site1.ImageUrl = "./Images/Sitekey/SiteKey1.jpg";
                img_site2.ImageUrl = "./Images/Sitekey/SiteKey2.jpg";
                img_site3.ImageUrl = "./Images/Sitekey/SiteKey3.jpg";
                img_site4.ImageUrl = "./Images/Sitekey/SiteKey4.jpg";
                img_site5.ImageUrl = "./Images/Sitekey/SiteKey5.jpg";
                txtCaptcha.Text = sc.GetVerifierString("6");
                
            }
        }

        private string convertBytetoString(Byte[] byteArray)
        {
            try
            {
                char[] charArray = new char[byteArray.Length / sizeof(char)];
                System.Buffer.BlockCopy(byteArray, 0, charArray, 0, byteArray.Length);
                return new string(charArray);
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string userFilePath = Path.Combine(Request.PhysicalApplicationPath, @"App_Data\userDetails.xml"); 
            FileStream FS = new FileStream(userFilePath, FileMode.Open, FileAccess.ReadWrite);
            try
            {
                lblResult.Visible = false;
                bool bUnique = true;
                //Ensuring that all mandatory fields are filled.
                if (txtfName.Text.Length > 0 && txtlName.Text.Length > 0 && txtuName.Text.Length > 0 && txtSiteKey.Text.Length > 0)
                {
                    //Verifying CAPTCHA
                    //if (Page.IsValid)
                    if(txtCaptcha.Text == txtEnteredCaptcha.Text)
                    {
                        if (txtPassword.Text.ToLower().Equals(txtRPassword.Text.ToLower()))
                        {
                            string SaltandHash = objHash.createHash(txtPassword.Text.Trim());
                            if (File.Exists(userFilePath))
                            {
                                XmlDocument xdoc = new XmlDocument();
                                xdoc.Load(FS);
                                FS.Close();
                                foreach (XmlNode xmlnode in xdoc.SelectNodes("USERS/User/UserName"))
                                {
                                    //Checking if the user name exists
                                    if (txtuName.Text.ToLower().Equals(xmlnode.InnerText.ToLower()))
                                    {
                                        bUnique = false;
                                        break;
                                    }
                                }

                                if (bUnique)
                                {
                                    //Creating a XML node and appending the required elements/nodes to the Root node
                                    XmlNode node = xdoc.CreateNode(XmlNodeType.Element, "User", null);

                                    XmlNode firstNameNode = xdoc.CreateElement("FirstName");
                                    firstNameNode.InnerText = txtfName.Text.Trim();
                                    XmlNode lastNameNode = xdoc.CreateElement("LastName");
                                    lastNameNode.InnerText = txtlName.Text.Trim();
                                    XmlNode userNameNode = xdoc.CreateElement("UserName");
                                    userNameNode.InnerText = txtuName.Text.Trim();
                                    XmlNode userType = xdoc.CreateElement("UserType");
                                    userType.InnerText = rbTypeUser.SelectedValue.Trim();

                                    XmlNode passwordSalt = xdoc.CreateElement("SALT");
                                    passwordSalt.InnerText = SaltandHash.Split(':')[0];
                                    XmlNode passwordHash = xdoc.CreateElement("HASH");
                                    passwordHash.InnerText = SaltandHash.Split(':')[1];

                                    XmlNode siteKeyIdx = xdoc.CreateElement("SiteKeyIndex");
                                    siteKeyIdx.InnerText = strSiteKey;
                                    XmlNode siteKeyPhrase = xdoc.CreateElement("SiteKeyPhrase");
                                    siteKeyPhrase.InnerText = txtSiteKey.Text.Trim();

                                    node.AppendChild(firstNameNode);
                                    node.AppendChild(lastNameNode);
                                    node.AppendChild(userNameNode);
                                    node.AppendChild(userType);
                                    node.AppendChild(passwordSalt);
                                    node.AppendChild(passwordHash);
                                    node.AppendChild(siteKeyIdx);
                                    node.AppendChild(siteKeyPhrase);

                                    xdoc.DocumentElement.AppendChild(node);
                                    xdoc.Save(userFilePath);
                                }
                                else
                                {
                                    lblResult.Text = "User name has to be unique";
                                    lblResult.Visible = true;
                                }
                            }
                            else
                            {
                                //If the file doesnt exist.
                                string strXml = "<?xml version=\"1.0\" encoding=\"utf-8\"?>" +
                                            "<USERS>" +
                                              "<User>" +
                                                "<FirstName>" + txtfName.Text.Trim() + "</FirstName>" +
                                                "<LastName>" + txtlName.Text.Trim() + "</LastName>" +
                                                "<UserName>" + txtuName.Text.Trim() + "</UserName>" +
                                                "<UserType>" + rbTypeUser.SelectedValue.Trim() + "</UserType>" +
                                                "<SALT>" + SaltandHash.Split(':')[0] + "</SALT>" +
                                                "<HASH>" + SaltandHash.Split(':')[1] + "</HASH>" +
                                                "<SiteKeyIndex>" + strSiteKey + "</SiteKeyIndex>" +
                                                "<SiteKeyPhrase>" + txtSiteKey.Text.Trim() + "</SiteKeyPhrase>" +
                                              "</User>" +
                                            "</USERS>";

                                File.WriteAllText(userFilePath, strXml);
                            }
                            if (bUnique)
                            {
                                lblResult.Text = "User Successfully Created";
                                lblResult.Visible = true;
                                Session["USERID"] = txtuName.Text.Trim();
                                Session["UserType"] = rbTypeUser.SelectedValue.Trim();

                                //Redirect user to respective page.
                                if (rbTypeUser.SelectedValue.Trim().Equals("Student_User"))
                                    Response.Redirect("StudentHome.aspx", false);
                                else if (rbTypeUser.SelectedValue.Trim().Equals("Scholar_User"))
                                    Response.Redirect("ScholarHome.aspx", false);
                            }
                            else
                            {
                                lblResult.Text = "Please select a unique user name";
                                lblResult.Visible = true;
                                txtuName.Text = "";
                                txtPassword.Text = "";
                                txtRPassword.Text = "";
                            }
                        }
                        else
                        {
                            lblResult.Text = "Passwords dont match";
                            lblResult.Visible = true;
                        }
                    }
                    else
                    {
                        lblResult.Text = "Captcha Verification Failed";
                        lblResult.Visible = true;
                    }
                }
                else
                {
                    lblResult.Text = "All fields are mandatory";
                    lblResult.Visible = true;
                }
            }
            catch (Exception exp)
            {
                lblResult.Text = "User creation Failed. Try Again ";
                lblResult.Visible = true;
                Console.WriteLine("Exception : " + exp.Message);
                throw exp;
            }
            finally
            {
                FS.Close();
            }
        }

        protected void deselect_All_Images()
        {
            strSiteKey = "";
            img_site1.BorderStyle = BorderStyle.None;
            img_site2.BorderStyle = BorderStyle.None;
            img_site3.BorderStyle = BorderStyle.None;
            img_site4.BorderStyle = BorderStyle.None;
            img_site5.BorderStyle = BorderStyle.None;
        }

        protected void img_site1_Click(object sender, ImageClickEventArgs e)
        {
            deselect_All_Images();
            strSiteKey = "1";
            img_site1.BorderColor = System.Drawing.Color.DarkBlue;
            img_site1.BorderStyle = BorderStyle.Solid;
        }

        protected void img_site2_Click(object sender, ImageClickEventArgs e)
        {
            deselect_All_Images();
            strSiteKey = "2";
            img_site2.BorderColor = System.Drawing.Color.DarkBlue;
            img_site2.BorderStyle = BorderStyle.Solid;
        }

        protected void img_site3_Click(object sender, ImageClickEventArgs e)
        {
            deselect_All_Images();
            strSiteKey = "3";
            img_site3.BorderColor = System.Drawing.Color.DarkBlue;
            img_site3.BorderStyle = BorderStyle.Solid;
        }

        protected void img_site4_Click(object sender, ImageClickEventArgs e)
        {
            deselect_All_Images();
            strSiteKey = "4";
            img_site4.BorderColor = System.Drawing.Color.DarkBlue;
            img_site4.BorderStyle = BorderStyle.Solid;
        }

        protected void img_site5_Click(object sender, ImageClickEventArgs e)
        {
            deselect_All_Images();
            strSiteKey = "5";
            img_site5.BorderColor = System.Drawing.Color.DarkBlue;
            img_site5.BorderStyle = BorderStyle.Solid;
        }

        protected void btnCaptcha_Click(object sender, EventArgs e)
        {
            try
            {
                txtCaptcha.Text = sc.GetVerifierString("6");
            }
            catch (Exception exp)
            {
                Console.WriteLine("Exception :" + exp.Message);
            }
        }
    }
}