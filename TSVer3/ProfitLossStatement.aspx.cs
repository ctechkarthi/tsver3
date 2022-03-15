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
    public partial class ProfitLossStatement : System.Web.UI.Page
    {
        #region class
        BusLayer obj_admin = new BusLayer();
        DataTable dt = new DataTable();
        SqlDataReader dr = null;
        Decimal TotAmt = 0; Decimal TotalTax = 0; 
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {       
            if (IsPostBack)
            { return; }
            Load_Month();
        }

        private void Load_Month()
        {
            try
            {
                dr = obj_admin.Invoice_Search_Month(Convert.ToString(Session["CompanyCode"]), ddl_InvoiceType.Text);
                ddl_Month.DataSource = dr;
                ddl_Month.DataTextField = "Month";
                ddl_Month.DataValueField = "Month";
                ddl_Month.DataBind();
                ddl_Month.Items.Insert(0, Global.Select_Default);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Key", "alert('" + ex.Message + "');", true);
            }
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

        decimal IGSTValue_grd = 0; decimal SGSTValue_grd = 0; decimal CGSTValue_grd = 0;
        protected void Grd_RowDataBound(object sender, GridViewRowEventArgs e)
        { 
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }

        protected void IBtn_Excel_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                string CreateDate = Convert.ToString(DateTime.Now.ToString("dd-MM-yyyy"));
                string ExcelFileName = "E-Statement_" + ddl_Month.SelectedValue + ".xls";
                System.IO.StringWriter tw = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
                DataGrid dgGrid = new DataGrid();
                DataTable dtExcel = new DataTable();
                dr = obj_admin.Invoice_ProfitLossStmt(Convert.ToString(Session["CompanyCode"]), ddl_Category.Text, ddl_Month.Text, ddl_InvoiceType.Text); //Invoice_Search_DailyReport
                dt.Load(dr);
           
                // dtExcel.Columns.Remove("Status");
              //  dtExcel.Columns["AWBNo"].ColumnName = "MAWB No";
                // dtExcel.Columns["To"].SetOrdinal(0);
               // dtExcel.Rows.Add("", "", "", "", "", "", "Total Rs.", Session["TotalServiceTax"].ToString(), Session["ServiceTax"].ToString(), Session["GrandTotal"].ToString(), "", "");
                
                dgGrid.DataSource = dt;
                dgGrid.HeaderStyle.BackColor = System.Drawing.Color.OrangeRed;
                dgGrid.HeaderStyle.ForeColor = System.Drawing.Color.White;
                dgGrid.HeaderStyle.BorderColor = System.Drawing.Color.DarkGray;
                dgGrid.HeaderStyle.BorderWidth = new Unit(1, UnitType.Pixel);
                dgGrid.HeaderStyle.BorderStyle = BorderStyle.Solid;
                dgGrid.AlternatingItemStyle.BackColor = System.Drawing.Color.LightGray;
                dgGrid.DataBind();
                //Get the HTML for the control.
                dgGrid.RenderControl(hw);
                //Write the HTML back to the browser.
                Response.ContentType = "application/vnd.ms-excel";
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + ExcelFileName + "");
                //  this.EnableViewState = false;
                Response.Write(tw.ToString());
                Response.End();
            }
            catch (Exception ex)
            { lbl_Error.ForeColor = System.Drawing.Color.Red; lbl_Error.Text = ex.Message; }
        }

        protected void Btn_Submit_Click(object sender, EventArgs e)
        {
            try
            {
                lbl_Error.Text = "";
                if (ddl_Month.SelectedIndex != 0)
                {
                    DataTable dt1 = new DataTable();
                    dr = obj_admin.Invoice_ProfitLossStmt(Convert.ToString(Session["CompanyCode"]), ddl_Category.Text, ddl_Month.Text, ddl_InvoiceType.Text); //Invoice_Search_DailyReport
                    dt1.Load(dr);
                    Grd.DataSource = dt1; Session["Report_Month"] = ddl_Month.SelectedValue; 
                    Grd.DataBind();
                    IBtn_Excel.Visible = true; IBtn_PDF.Visible = true; div_Grd.Visible = true;
                }
                else
                {
                    div_Grd.Visible = false; IBtn_Excel.Visible = false;
                    lbl_Error.ForeColor = System.Drawing.Color.Red; lbl_Error.Text = "Invalid Selection";
                }
            }
            catch (Exception ex)
            { lbl_Error.ForeColor = System.Drawing.Color.Red; lbl_Error.Text = ex.Message; }
        }

        protected void IBtn_PDF_Click(object sender, ImageClickEventArgs e)
        {
            Session["Month"] = ddl_Month.SelectedValue;
            StringBuilder sb = new StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.open('");
            sb.Append("JobProfitStatementReport.aspx?ien=" + ddl_Month.Text + "&isa=" + ddl_InvoiceType.Text);
            sb.Append("');");
            sb.Append("</script>");
            ClientScript.RegisterStartupScript(this.GetType(), "script", sb.ToString());
        }

        protected void ddl_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_Month();
        }
    }
}