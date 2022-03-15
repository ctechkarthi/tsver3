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
    public partial class InvoiceList : System.Web.UI.Page
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
            Load_Month();
        }

        private void Load_Month()
        {
            try
            {
              //  dr = obj_admin.Invoice_Search_Month(Convert.ToString(Session["CompanyCode"]));
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

        protected void Btn_Submit_Click(object sender, EventArgs e)
        {
            try
            {
                lbl_Error.Text = string.Empty; IBtn_Excel.Visible = false;
                if (ddl_Month.SelectedIndex != 0)
                {
                    Global._getDT2 = dt = new DataTable();
                    dr = obj_admin.Invoice_Search_MonthWiseReport(Convert.ToString(Session["CompanyCode"]), ddl_Month.SelectedValue, "Debit Note");
                    dt.Load(dr);
                    //DataTable dtAir = new DataTable();
                    //DataTable dtSea = new DataTable();
                    //dr = obj_admin.Invoice_Search_MonthWiseReportAir(Convert.ToString(Session["CompanyCode"]), ddl_Month.SelectedValue);
                    //dtAir.Load(dr);
                    //dr = null;
                    //dr = obj_admin.Invoice_Search_MonthWiseReportSea(Convert.ToString(Session["CompanyCode"]), ddl_Month.SelectedValue);
                    //dtSea.Load(dr);

                    //SELECT sj.JobNo,sj.MBL,sj.HBL,sj.Client,sj.Origin,sj.FinalDest,sj.Vessel,sj.Pieces,sj.GrossWt,inv.BillNo,inv.BillDate,inv.GrandTotal FROM srefjob AS sj INNER JOIN invoice AS inv ON
                    //SELECT aj.JobNo,aj.MAWB,aj.HAWB,aj.Client,aj.Org,aj.Dest,aj.A1,aj.Pieces,aj.GW,inv.BillNo,inv.BillDate,inv.GrandTotal FROM arefjob AS aj INNER JOIN invoice AS inv ON

                    //dtSea.Columns["MBL"].ColumnName = "MAWB";
                    //dtSea.Columns["HBL"].ColumnName = "HAWB";
                    //dtSea.Columns["Origin"].ColumnName = "Org";
                    //dtSea.Columns["FinalDest"].ColumnName = "Dest";
                    //dtSea.Columns["Vessel"].ColumnName = "A1";
                    //dtSea.Columns["GrossWt"].ColumnName = "GW";

                    //dt = dtAir.Copy();
                    //dt.Merge(dtSea);

                    Grd.DataSource = Global._getDT2 = dt;
                    Grd.DataBind();
                    IBtn_Excel.Visible = true; div_Grd.Visible = true;
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

        protected void IBtn_Excel_Click1(object sender, ImageClickEventArgs e)
        {
            string CreateDate = Convert.ToString(DateTime.Now.ToString("dd-MM-yyyy"));
            string ExcelFileName = "E-Statement_" + ddl_Month.SelectedValue + ".xls";
            System.IO.StringWriter tw = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
            DataGrid dgGrid = new DataGrid();
            DataTable dtExcel = new DataTable();
            dtExcel = Global._getDT2;

            //dtExcel.Columns["MAWB"].ColumnName = "MAWB/MBL";
            //dtExcel.Columns["HAWB"].ColumnName = "HAWB/HBL";
            //dtExcel.Columns["A1"].ColumnName = "Airline/Vessel";
            dt = dtExcel;
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
    }
}