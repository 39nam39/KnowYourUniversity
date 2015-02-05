using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using FinalWebApplication.NumberToWords;
using FinalWebApplication.TransferSOP;
using FinalWebApplication.YelpNearest;

namespace FinalWebApplication
{
    public partial class Home : Page
    {
        //Default value
        public static string zipcode = "85281";

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    populateDropDown(Path.Combine(Request.PhysicalApplicationPath, @"App_Data\univ.xml"));
                    //Check if the user has required permission to use this page
                    if (Session["USERID"].ToString().Length > 0 && Session["UserType"].ToString().Equals("Student_User"))
                    {

                    }
                    else
                    {
                        Session["ErrorMsg"] = "Invalid User ID";
                        Response.Redirect("Login.aspx", false);
                    }
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine("Excetpion:" + exp.Message);
            }            
        }

        private void populateDropDown(string fileName)
        {
            FileStream FS = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            try
            {
                Dictionary<string, string> dict = new Dictionary<string, string>();
                XmlDocument xdoc = new XmlDocument();
                //xdoc.Load(@"webstrar.fulton.asu.edu\website23\Page2\App_Data\Univ.xml");

                if (File.Exists(fileName))
                {

                    xdoc.Load(FS);
                    FS.Close();
                    
                    XmlNodeList xmlnodelist = xdoc.GetElementsByTagName("University");
                    foreach (XmlNode xmlnode in xmlnodelist)
                    {
                        if (xmlnode.HasChildNodes)
                            //Populate the drop down
                        {
                            dict.Add(xmlnode.SelectSingleNode("ID").InnerText + ": " + xmlnode.SelectSingleNode("Name").InnerText +
                                ": " + xmlnode.SelectSingleNode("Zipcode").InnerText, xmlnode.SelectSingleNode("Name").InnerText);
                        }
                    }
                    univListDD.DataSource = dict;
                    univListDD.DataValueField = "Key";
                    univListDD.DataTextField = "Value";
                    univListDD.DataBind();
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine("Exception" + exp.Message);
            }
            finally
            {
                FS.Close();
            }
        }

        //Used to display the results of the YELP search.
        public class DisplayClass
        {
            public string Name { get; set; }
            public string PhoneNo { get; set; }
            public string Location { get; set; }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                lblErrorMessage.Visible = false;
                if (txtSearchTerm.Text.Length > 0)
                {
                    YelpIServiceClient objSearch = new YelpIServiceClient();
                    YelpSearchResult objYelp = objSearch.searchResults(txtSearchTerm.Text.ToString(), zipcode);

                    List<DisplayClass> lstDisplay = new List<DisplayClass>();
                    foreach (Business business in objYelp.lstBusiness)
                    {
                        DisplayClass objDisplay = new DisplayClass();
                        objDisplay.Name = business.name;
                        objDisplay.PhoneNo = business.phone;
                        objDisplay.Location = string.Join(",", business.location.address) + ":" + business.location.city
                            + ":" + business.location.state_code + "-" + business.location.postal_code;
                        lstDisplay.Add(objDisplay);
                    }
                    if (objYelp != null)
                    {
                        resultGrid.DataSource = lstDisplay.ToArray();
                        resultGrid.DataBind();
                    }
                }
                else
                {
                    lblErrorMessage.Text = " Enter the search term";
                    lblErrorMessage.Visible = true;
                }
                
            }
            catch (Exception exp)
            {
                Console.WriteLine("Exception : " + exp.Message);
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            
            try
            {
                //Checking if the user hase selected a file to be uploaded.
                if (FileUpload.HasFile)
                {
                    FileInfo fileInfo = new FileInfo(FileUpload.PostedFile.FileName);                    
                    TransferSOPIServiceClient objSOPClientUpload = new TransferSOPIServiceClient();
                    //Maximum file size is 3Mb.
                    if (FileUpload.PostedFile.InputStream.Length < 3145728)
                    {
                        //Calling the service.
                        string str = objSOPClientUpload.UploadFile(FileUpload.PostedFile.FileName, FileUpload.PostedFile.InputStream);
                        txtFileLoc.Text = str;
                    }
                    else
                    {
                        lblErrorMessage.Text = "Maximum size of file is 3Mb";
                        lblErrorMessage.Visible = true;
                    }
                }
            }
            catch(Exception exp)
            {
                lblErrorMessage.Text = "Exception has occured";
                lblErrorMessage.Visible = true;
                Console.WriteLine("Exception : " + exp.Message);
            }            
        }

        protected void btnFileLoc_Click(object sender, EventArgs e)
        {   
            lblErrorMessage.Visible = false;            
        }

        protected void univListDD_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                zipcode = univListDD.SelectedValue.ToString().Split(':')[2];
            }
            catch (Exception exp)
            {
                Console.WriteLine("Exception :" + exp.Message);
            }
        }

        protected void btnCourseNo_Click(object sender, EventArgs e)
        {
            try
            {
                Service1Client sr = new Service1Client();
                lblCourseResult.Text = "Your course preference " + sr.Numbertowords(txtCourseNo.Text) + " is submitted to the university";
            }
            catch (Exception exp)
            {
                Console.WriteLine("Exception :" + exp.Message);
            }
        }
    }
}