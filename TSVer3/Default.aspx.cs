using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using TSVer3.BL;

namespace TSVer3
{
    public partial class Default : System.Web.UI.Page
    {
        #region class
        BusLayer obj_admin = new BusLayer();
        DataTable dt = new DataTable();
        SqlDataReader dr = null;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                return;
            }
        }

        protected void Btn_Login_Click(object sender, EventArgs e)
        {
            dr = obj_admin.Login_Verify(tbx_UserName.Text, tbx_Password.Text);
            if (dr.HasRows)
            {  
                while (dr.Read())
                {
                    Session["CompanyName"] = dr["Company"].ToString();
                    Session["CompanyCode"] = dr["CCode"].ToString();
                    Session["LoginName"] = dr["Name"].ToString();
                    Session["URL"] = dr["UserRole"].ToString();
                    Session["UN"] = tbx_UserName.Text; 
                    Session["RenewalDate"] = dr["Validity"].ToString();      
                }
                Response.Redirect("WebHome.aspx");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert('Invalid Username/Password !')", true);
            }
        }
    }
}