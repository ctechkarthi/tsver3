using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Management;
using System.Management.Instrumentation;
using System.IO;
using TSVer3.BL;
using System.Drawing;

namespace TSVer3
{
    public partial class Particulars : System.Web.UI.Page
    {
        #region class
        BusLayer obj_admin = new BusLayer();
        DataTable dt = new DataTable();
        bool value;
        SqlDataReader dr = null;
        string Active_Job; 
        string ExcelFileName = "";
        string CCode;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            { return; }
            GridLoad();
        }

        private void GridLoad()
        {
            try
            {
                dt = new DataTable();
                dr = obj_admin.InvParticulars_Details(Convert.ToString(Session["CompanyCode"]));
                dt.Load(dr);
                Grd.DataSource = Global._getDT = dt;
                Grd.DataBind();
            }
            catch (Exception ex)
            { lbl_Error.Text = ex.Message; }
        }

        protected void Btn_Insert_Click(object sender, EventArgs e)
        {
            try
            {
                lbl_Status.Text = "";
                if (!string.IsNullOrEmpty(tbx_Particulars.Text))
                {
                    dt = Global._getDT;
                    DataRow[] result_dr = dt.Select("Particulars= '" + tbx_Particulars.Text + "'");
                    if (result_dr.Length == 0)
                    {  // Check Job is active
                        if (RB_Yes.Checked == true) { Active_Job = "Y"; }
                        else { Active_Job = "N"; }
                        value = obj_admin.Particulars_New(Convert.ToString(Session["CompanyCode"]), tbx_Particulars.Text,"", tbx_HSN.Text, tbx_GST.Text, tbx_IGST.Text, tbx_CGST.Text, tbx_SGST.Text, Active_Job);
                        if (value == true)
                        {
                            lbl_Status.ForeColor = Color.Green; lbl_Status.Text = "Save Successfully!";
                        }
                        else { lbl_Status.ForeColor = Color.Red; lbl_Status.Text = "Record Not Save!"; }
                    }
                    else { lbl_Status.ForeColor = Color.Red; lbl_Status.Text = "Invalid Record!"; }
                }
                else { lbl_Status.ForeColor = Color.Red; lbl_Status.Text = "Please Enter Particulars"; }
            }
            catch (Exception ex)
            { lbl_Status.ForeColor = Color.Red; lbl_Status.Text = ex.Message; }
        }

        protected void Btn_Edit_Click(object sender, EventArgs e)
        {
            try
            {
                lbl_Status.Text = "";
                if (!string.IsNullOrEmpty(tbx_Particulars.Text))
                {
                    if (RB_Yes.Checked == true) { Active_Job = "Y"; }
                    else { Active_Job = "N"; }
                    value = obj_admin.Particulars_Update(Convert.ToInt32(Session["ParticularsId"]), Convert.ToString(Session["CompanyCode"]), tbx_Particulars.Text,"", tbx_HSN.Text, tbx_GST.Text, tbx_IGST.Text, tbx_CGST.Text, tbx_SGST.Text, Active_Job);

                    if (value == true)
                    {
                        lbl_Status.ForeColor = Color.Green; lbl_Status.Text = "Update Successfully!";
                    }
                    else { lbl_Status.ForeColor = Color.Red; lbl_Status.Text = "Record Not Update"; }
                }
                else { lbl_Status.ForeColor = Color.Red; lbl_Status.Text = "Please Enter Particulars"; }
            }
            catch (Exception ex)
            { lbl_Status.ForeColor = Color.Red; lbl_Status.Text = ex.Message; }
        }

        protected void Btn_Clear_Click(object sender, EventArgs e)
        {
            Clear(); Btn_Insert.Visible = true; Btn_Edit.Visible = false;
        }

        private void Clear()
        {
            lbl_Status.Text = "";
            tbx_Particulars.Text = lbl_Status.Text = tbx_HSN.Text = tbx_GST.Text = tbx_IGST.Text = tbx_CGST.Text = tbx_SGST.Text = string.Empty;
            RB_Yes.Checked = false; RB_No.Checked = false; 
        }

        protected void Grd_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Clear(); // Clear the old values
                DataRow bindDR = Global._getDT.Rows[Grd.SelectedIndex];
                Session["Particulars"] = bindDR["Particulars"].ToString();
                DataView dv = new DataView(Global._getDT);
                dv.RowFilter = "Particulars ='" + bindDR["Particulars"].ToString() + "'";
                dt = dv.ToTable();
                if (dt.Rows.Count == 0)
                {
                    lbl_Error.Text = "Invalid Particulars!"; Btn_Edit.Visible = false;
                }
                else
                {
                    TabContainer1.ActiveTabIndex = 1; Btn_Edit.Visible = true; IB_Excel.Visible = true; Btn_Insert.Visible = false;
                    Session["ParticularsId"] = dt.Rows[0]["Id"];
                    tbx_Particulars.Text = dt.Rows[0]["Particulars"].ToString();
                    tbx_GST.Text = dt.Rows[0]["GST"].ToString();
                    tbx_IGST.Text = dt.Rows[0]["IGST"].ToString();
                    tbx_CGST.Text = dt.Rows[0]["CGST"].ToString();
                    tbx_SGST.Text = dt.Rows[0]["SGST"].ToString();
                    tbx_HSN.Text = dt.Rows[0]["HSN"].ToString();
                    Active_Job = dt.Rows[0]["Active"].ToString();
                    if (Active_Job == "Y")
                    { RB_Yes.Checked = true; RB_No.Checked = false; }
                    else { RB_No.Checked = true; RB_Yes.Checked = false; }
                }
            }
            catch (Exception ex)
            {
                lbl_Status.ForeColor = Color.Red; lbl_Status.Text = ex.Message;
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

        protected void Grd_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                if (e.NewPageIndex == -1) return;
                Grd.PageIndex = e.NewPageIndex;
                Grd.DataSource = Global._getDT;
                Grd.DataBind();
                Grd.SelectedIndex = -1;
            }
            catch (Exception ex)
            { lbl_Error.Text = ex.Message; }
        }

        protected void Grd_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //e.Row.ForeColor = System.Drawing.Color.FromArgb(105, 184, 215);
                e.Row.Attributes["onmouseover"] = "javascript:SetMouseOver(this)";
                e.Row.Attributes["onmouseout"] = "javascript:SetMouseOut(this)";
            }
        }

        protected void Btn_Show_Click(object sender, EventArgs e)
        {
            try
            {
                lbl_Error.Text = "";
                dr = obj_admin.InvParticulars_PartiWise(Convert.ToString(Session["CompanyCode"]), tbx_Particular_Search.Text);
                if (dr.HasRows)
                {
                    dt = new DataTable();
                    dt.Load(dr);
                    Global._getDT = dt;
                    Grd.Font.Size = FontUnit.Small;
                    Grd.DataSource = dt;
                    Grd.DataBind();
                    IB_Excel.Visible = true;
                }
                else
                {
                    Grd.DataSource = new DataTable();
                    Grd.DataBind(); IB_Excel.Visible = false;
                    lbl_Error.Text = "Please Check Particulars!";
                }
            }
            catch (Exception ex)
            {
                lbl_Error.ForeColor = Color.Red; lbl_Error.Text = ex.Message;
            }
        }

        protected void Btn_Reset_Click(object sender, EventArgs e)
        {
            Response.Redirect("Particulars.aspx");
        }

        protected void IB_Excel_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                lbl_Error.Text = "";
                string CreateDate = Convert.ToString(DateTime.Now.ToString("dd-MM-yyyy"));
                ExcelFileName = "Particulars_" + CreateDate + ".xls";
                System.IO.StringWriter tw = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
                DataGrid dgGrid = new DataGrid();
                dt = Global._getDT;

                if (dt.Columns.Contains("Id"))
                { dt.Columns.Remove("Id"); }
                if (dt.Columns.Contains("CCode"))
                { dt.Columns.Remove("CCode"); }

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
                //Response.ContentType = application/vnd.ms-excel;
                Response.ContentType = "application/vnd.ms-excel";
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + ExcelFileName + "");
                //  this.EnableViewState = false;
                Response.Write(tw.ToString());
                Response.End();
            }
            catch (Exception ex)
            { lbl_Error.ForeColor = Color.Red; lbl_Error.Text = ex.Message; }
        }

        protected void tbx_GST_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbx_GST.Text))
            { tbx_IGST.Text = tbx_GST.Text; decimal GST = Convert.ToDecimal(tbx_GST.Text); tbx_CGST.Text = tbx_SGST.Text = (GST / 2).ToString(); }
        }
    }
}