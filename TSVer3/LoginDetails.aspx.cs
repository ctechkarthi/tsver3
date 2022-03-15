using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Drawing;
using TSVer3.BL;

namespace TSVer3
{
    public partial class LoginDetails : System.Web.UI.Page
    {
        #region class
        BusLayer obj_admin = new BusLayer();
        bool value = false;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                return;
            }
        }

        protected void Btn_Update_Click(object sender, EventArgs e)
        {
            lbl_Status.Text = string.Empty;
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                if (!string.IsNullOrEmpty(tbx_NewPassword1.Text))
                {
                    if (tbx_NewPassword1.Text == tbx_NewPassword2.Text)
                    {
                        if (tbx_NewPassword1.Text.Length >= 5)
                        {
                            value = obj_admin.LoginPassword_Update(Convert.ToString(Session["CompanyCode"]), Session["UN"].ToString(), tbx_NewPassword1.Text);
                            if (value == true)
                            { lbl_Status.ForeColor = Color.Green; lbl_Status.Text = "Password Update Successfully!"; }
                            else { lbl_Status.ForeColor = Color.Red; lbl_Status.Text = "Password Not Update!"; }
                        }
                        else { lbl_Status.ForeColor = Color.Red; lbl_Status.Text = "Password lenght should be more than 5"; }
                    }
                    else { lbl_Status.ForeColor = Color.Red; lbl_Status.Text = "Password Mismatch!"; }
                }
                else { lbl_Status.ForeColor = Color.Red; lbl_Status.Text = "Please enter password!"; }
            }
        }
    }
}