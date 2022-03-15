using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using TSVer3.BL;
using System.Text;

namespace TSVer3
{
    public partial class ExpenseList : System.Web.UI.Page
    {
        #region class
        BusLayer obj_admin = new BusLayer();
        DataTable dt = new DataTable();
        SqlDataReader dr = null;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            { return; }
        }

        protected void cmb_Category_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_ExpenseList();
        }

        private void Load_ExpenseList()
        {
            try
            {
                dt = new DataTable();
                dr = obj_admin.Job_Expense_JobNoList_Last(Convert.ToString(Session["CompanyCode"]), cmb_Category.Text);
                dt.Load(dr);
                Grd.DataSource = dt;
                Grd.DataBind();
            }
            catch (Exception ex)
            { ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Key", "alert('" + ex.Message + "');", true); }
        }

        protected override void Render(HtmlTextWriter writer)
        {
            foreach (GridViewRow e in Grd.Rows)
            {
                if (e.RowType == DataControlRowType.DataRow)
                {
                    e.Attributes["onclick"] = ClientScript.GetPostBackEventReference(Grd, "Select$" + e.DataItemIndex, true);
                }
            }
            base.Render(writer);
        }

        protected void Grd_OnPaging(object sender, GridViewPageEventArgs e)
        {
            this.Load_ExpenseList();
            Grd.PageIndex = e.NewPageIndex;
            Grd.DataBind();
        }

        protected void Grd_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // e.Row.ForeColor = System.Drawing.Color.FromArgb(105, 184, 215);
                e.Row.Attributes["onmouseover"] = "javascript:SetMouseOver(this)";
                e.Row.Attributes["onmouseout"] = "javascript:SetMouseOut(this)";
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }

        protected void Btn_Search_Click(object sender, EventArgs e)
        {
            try
            {
                lbl_SerchError.Text = "";
                if (!string.IsNullOrEmpty(tbx_JobNo.Text))
                {
                    dt = new DataTable();
                    dr = obj_admin.Job_Expense(Convert.ToString(Session["CompanyCode"]), tbx_JobNo.Text);
                    dt.Load(dr);
                    Grd.DataSource = dt;
                    Grd.DataBind();
                }
                else { lbl_SerchError.Text = "Please Enter Invoice No.!"; }
            }
            catch (Exception ex)
            { ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Key", "alert('" + ex.Message + "');", true); }
        }
    }
}