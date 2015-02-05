using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using FinalWebApplication.YelpNearest;

namespace FinalWebApplication
{
    public partial class ScholarHome : Page
    {
        //Default values
        public static string zipcode = "85281";
        public static string univName = "Arizona State University";

        private void populateDropDown(string fileName)
        {
            FileStream FS = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            try
            {
                Dictionary<string, string> dict = new Dictionary<string, string>();
                XmlDocument xdoc = new XmlDocument();
                
                if (File.Exists(fileName))
                {                    
                    xdoc.Load(FS);
                    FS.Close();
                    //Populate the drop down list with the respective universities in XML file
                    XmlNodeList xmlnodelist = xdoc.GetElementsByTagName("University");
                    foreach (XmlNode xmlnode in xmlnodelist)
                    {
                        if (xmlnode.HasChildNodes)
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

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    populateDropDown(Path.Combine(Request.PhysicalApplicationPath, @"App_Data\univ.xml"));
                    //Checking if the user id is present and is authorized to enter.
                    if (Session["USERID"].ToString().Length > 0 && Session["UserType"].ToString().Equals("Scholar_User"))
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

        //Classes used for Displaying the search result.
        public class DisplayResults
        {
            public string resID { get; set; }
            public string restitle { get; set; }
            public string resdate { get; set; }
            public string ressource { get; set; }
            public string resdescription { get; set; }
            public string resURL { get; set; }
        }
        public class ArrayOfResults
        {
            public List<DisplayResults> lstDisplayRes = new List<DisplayResults>();
        }

        protected void btnLocalNews_Click(object sender, EventArgs e)
        {
            try
            {
                string stringResponse = string.Empty;
                // Create the base address to the BingSearch service
                //Uri baseUri = new Uri("http://localhost:27466/Service1.svc/");
                Uri baseUri = new Uri("http://webstrar23.fulton.asu.edu/page0/page00/BingSearchService.svc/");
                string searchTerm = "loadSearchResults?strSearch=" + univName;
                Uri completeUri = new Uri(baseUri, searchTerm);
                //Create a web request
                WebRequest request = WebRequest.Create(completeUri);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        StreamReader strReader = new StreamReader(responseStream, Encoding.UTF8);
                        stringResponse = strReader.ReadToEnd();
                    }
                }
                List<ArrayOfResults> lstArr2 = convertXmlToClassReflection(stringResponse);                

                //Binding the grid view to the search result class
                if (lstArr2 != null)
                {
                    gridViewSearch.DataSource = lstArr2[0].lstDisplayRes;
                    gridViewSearch.DataBind();
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine("Excetpion : " + exp.Message);
            }
        }
        /// <summary>
        /// Using reflections to convert XML to class.
        /// </summary>
        /// <param name="strXML">XML to be parsed</param>
        /// <returns></returns>
        public List<ArrayOfResults> convertXmlToClassReflection(string strXML)
        {
            List<ArrayOfResults> lstarr = new List<ArrayOfResults>();
            try
            {
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.LoadXml(strXML);
                var namespaceMgr = new XmlNamespaceManager(xmldoc.NameTable);
                namespaceMgr.AddNamespace("Result", "http://schemas.datacontract.org/2004/07/Rest_BingSearch");
                XmlNode xmlNode = xmldoc.SelectSingleNode("//Result:ArrayOfResults", namespaceMgr);
                XmlNodeList xmlResultsChild = xmlNode.ChildNodes;

                ArrayOfResults arrResult = new ArrayOfResults();
                foreach (XmlNode resultNode in xmlResultsChild)
                {
                    DisplayResults disp = new DisplayResults();
                    //Using reflections to get the class property value and convert it into class
                    foreach (XmlNode xml in resultNode.ChildNodes)
                    {
                        disp.GetType().GetProperty("res" + xml.Name).SetValue(disp, xml.InnerText, null);
                    }
                    //Add the result into the list of results.
                    arrResult.lstDisplayRes.Add(disp);
                }
                //In case of multiple array of results
                lstarr.Add(arrResult);
            }
            catch (Exception exp)
            {
                throw exp;
            }
            return lstarr;
        }

        //class to display the result
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
                YelpIServiceClient objSearch = new YelpIServiceClient();
                //Call the service.
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
            catch (Exception exp)
            {
                Console.WriteLine("Exception : " + exp.Message);
            }
        }

        protected void univListDD_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //Setting the University Name and ZipCode
                univName = univListDD.SelectedValue.ToString().Split(':')[1];
                zipcode = univListDD.SelectedValue.ToString().Split(':')[2];
            }
            catch (Exception exp)
            {
                Console.WriteLine("Exception :" + exp.Message);
            }
        }
    }
}