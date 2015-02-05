using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalWebApplication
{
    public partial class DateTimeUserControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string term = string.Empty;
                if (DateTime.Now.Month >= 5 && DateTime.Now.Month <= 7)
                    term = "Summer";
                else if (DateTime.Now.Month < 5)
                    term = "Spring";
                else
                    term = "Fall";

                lblDay.Text = DateTime.Now.DayOfWeek.ToString();
                lblTime.Text = DateTime.Now.ToString("H:mm:ss");
                lblTerm.Text = term + "-" + DateTime.Now.Year;
            }
            catch (Exception exp)
            {
                Console.WriteLine("Excption : " + exp.Message);
            }
        }        
    }
}