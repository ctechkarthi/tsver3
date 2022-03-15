using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Net;
using System.Data;

namespace TSVer3
{
    public partial class WebHome : System.Web.UI.Page
    {
        #region class
        string Ipaddress;
        #endregion
        
        protected void Page_Load(object sender, EventArgs e)
        {
            lbl_CompName.Text = Convert.ToString(Session["CompanyName"]);
            lbl_LoginUserName.Text = Convert.ToString(Session["UN"]); // Global.LoginUserName;
            lbl_UserName.Text = Convert.ToString(Session["LoginName"]); // Session["LoginName"].ToString();
            lbl_LoginTime.Text = Convert.ToString(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"));
            System.Web.HttpBrowserCapabilities browser = Request.Browser;
            lbl_BType.Text = browser.Type; lbl_BName.Text = browser.Browser;
            lbl_BVersion.Text = browser.Version;

            DateTime dt1 = Convert.ToDateTime(Session["RenewalDate"]);
            //DateTime dt1 = Convert.ToDateTime(dt.Rows[0]["CreateDate"].ToString()); // dd-MM-yyyy 
            DateTime dt2 = Convert.ToDateTime(DateTime.Now.ToString("MM-dd-yyyy"));
            int Duration = (dt1 - dt2).Days;

            if (Duration >= 31)
            { lbl_Validity.Text = "Your account will expires in " + Duration.ToString() + " day/s."; }
            else if (Duration >= 1 && Duration <= 30)
            { lbl_Validity_R.Text = "Your account will expires in " + Duration.ToString() + " day/s, <br/> <br/>Please contact Admin for renewal."; }
            else { Response.Redirect("Expire.aspx"); }

            // Reports_IPAddress();
        }

        private void Reports_IPAddress()
        {
            IPHostEntry host2;
            host2 = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip2 in host2.AddressList)
            {
                if (ip2.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    Ipaddress = ip2.ToString();
                }
            }
            lbl_IpAddress.Text = Ipaddress;
        }

    }
}