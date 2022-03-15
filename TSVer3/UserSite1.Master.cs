using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Web.Configuration;
using System.Data;
using System.IO;

namespace TSVer3
{
    public partial class UserSite1 : System.Web.UI.MasterPage
    {
        #region class
        public static int Id_MyProperty { get; set; }
        public static DataSet ds_MyProperty { get; set; }
        public static DataTable dt_MyProperty { get; set; }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            { return; }
            if (!string.IsNullOrEmpty(Session["UN"].ToString()))
            {
                //if (Session["URL"].ToString() == "Admin")
                //{ a_InvoiceChanges.Visible = true; }
                lbl_UserName.Text = Session["LoginName"].ToString();
                //lbl_Validity.Text = Session["Validity"].ToString();
            }
            else { Logout_ClearSession(); Logout(); }
        }

        private void Logout_ClearSession()
        {
            Session.RemoveAll();
            Session.Clear();
            Session.Abandon();

            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();

            // Response.ClearHeaders();
            // Response.AddHeader("Cache-Control", "no-cache, no-store, max-age=0, must-revalidate");
            // Response.AddHeader("Pragma", "no-cache");

            Session["UN"] = "";
            Session["URL"] = "";
            Session["Id_User"] = "";
            Session["CompanyCode"] = "";
            Session["CompanyName"] = "";
            Session["JobNumber"] = "";
        }

        private void Logout()
        {
            Response.Redirect("Default.aspx");
        }

        protected void Logout1_Click(object sender, EventArgs e)
        {
            // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Key", "alert('Logout Successfully');", true);
            Logout_ClearSession(); Global.Logout = "Logout";
            Logout();
        }
    }
}