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

namespace TSVer3
{
    public partial class JobDetails : System.Web.UI.Page
    {
        #region class
        BusLayer obj_admin = new BusLayer();
        SqlDataReader dr = null;
        bool value; int Id;
        string ModifiedDate; string ModifiedBy;
        string CreatedDate; string CreatedBy;
        DataTable dt = new DataTable();
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            { return; } 
        }

        private void GridLoad()
        {
            try
            {
                dt = new DataTable();
                dr = obj_admin.Gen_Job_Last(Convert.ToString(Session["CompanyCode"]), cmb_Category.Text);
                dt.Load(dr);
                Grd.DataSource = dt;
                Grd.DataBind();
            }
            catch (Exception ex)
            { lbl_GrdError.Text = ex.Message; }
        }

        protected void Btn_Insert_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(tbx_JobNo.Text))
                {
                    if (cmb_Category.SelectedIndex != 0)
                    {
                        string JobNo;
                        dt = new DataTable();
                        dr = obj_admin.Gen_JobNo(Convert.ToString(Session["CompanyCode"]), tbx_JobNo.Text);
                        dt.Load(dr); JobNo = tbx_JobNo.Text;
                        if (dt.Rows.Count <= 0)
                        {
                            value = obj_admin.Gen_Job_Insert(Convert.ToString(Session["CompanyCode"]), tbx_JobNo.Text, cmb_Category.Text, "YES", cmb_Sales.Text, cmb_JobStatus.Text, Convert.ToString(DateTime.Now.ToString("MMM-yyyy")));
                            if (value == true)
                            {
                                lbl_Status.Text = "Save Successfully, Your Job No. " + tbx_JobNo.Text;
                                //   value = obj_admin.LoginHistory_Insert(Convert.ToString(Session["CompanyCode"]), Login.LoginName, Login.LoginUserName, cmb_Category.Text, "Create", tbx_JobNo.Text, Convert.ToString(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss")));
                                GridLoad();
                            }
                            else
                            {
                                lbl_Status.Text = "Please check the Job not saved";
                            }
                        }
                        else
                        {
                            GenerateJobNo();
                            value = obj_admin.Gen_Job_Insert(Convert.ToString(Session["CompanyCode"]), tbx_JobNo.Text, cmb_Category.Text, "YES", cmb_Sales.Text, cmb_JobStatus.Text, Convert.ToString(DateTime.Now.ToString("MMM-yyyy")));
                            if (value == true)
                            {
                                lbl_Status.Text = "Save Successfully, Job No. " + JobNo + " already exists, Your New Job No. " + tbx_JobNo.Text;
                                //  value = obj_admin.LoginHistory_Insert(Convert.ToString(Session["CompanyCode"]), Login.LoginName, Login.LoginUserName, cmb_Category.Text, "Create", tbx_JobNo.Text, Convert.ToString(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss")));
                                GridLoad();
                            }
                            else
                            {
                                lbl_Status.Text = "Please check the Job not saved";
                            }
                        }
                    }
                    else { lbl_Status.Text = "Please Select - Category"; }
                }
                else { lbl_Status.Text = "Please Enter - Job Number"; }
            }
            catch (Exception ex)
            { lbl_Status.ForeColor = Color.Red; lbl_Status.Text = ex.Message; }
        }

        protected void Btn_Clear_Click(object sender, EventArgs e)
        {
            Clear(); Grd.DataSource = null; Btn_Insert.Visible = true; Btn_Delete.Visible = false; 
        }

        private void Clear()
        {
            lbl_Status.Text = ""; lbl_GrdError.Text = ""; tbx_JobNo.Text = ""; 
        }

        protected void Grd_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Clear(); // Clear the old values
                Btn_Delete.Visible = true; Btn_Insert.Visible = false; 
                Session["Id"] = Grd.SelectedRow.Cells[0].Text;
                tbx_JobNo.Text = Grd.SelectedRow.Cells[1].Text;
                cmb_Category.SelectedValue = Grd.SelectedRow.Cells[2].Text;
                cmb_Sales.SelectedValue = Grd.SelectedRow.Cells[3].Text;
                cmb_JobStatus.SelectedValue = Grd.SelectedRow.Cells[4].Text;
            }
            catch (Exception ex)
            { lbl_Status.Text = ex.Message; }
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
            { lbl_GrdError.Text = ex.Message; }
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

        protected void Btn_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                lbl_Status.Text = "";
                if (!string.IsNullOrEmpty(tbx_JobNo.Text))
                {
                    value = obj_admin.Gen_Job_Delete(Convert.ToString(Session["CompanyCode"]), tbx_JobNo.Text);
                    if (value == true)
                    {
                        lbl_Status.Text = "Job No. " + tbx_JobNo.Text + " Delete Success!"; 
                       // value = obj_admin.LoginHistory_Insert(Convert.ToString(Session["CompanyCode"]), Login.LoginName, Login.LoginUserName, cmb_Category.Text, "Delete", tbx_JobNo.Text, Convert.ToString(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss")));
                        GridLoad();
                    }
                    else
                    {
                        lbl_Status.Text = "Job No. " + tbx_JobNo.Text + " Not Delete!";
                    }
                }
                else { lbl_Status.Text = "Please Enter Job No."; }
            }
            catch (Exception ex)
            { lbl_Status.ForeColor = Color.Red; lbl_Status.Text = ex.Message; }
        }
        private void GenerateJobNo()
        {
            try
            {
                dt = new DataTable();
                dr = obj_admin.Gen_Job_Last(Convert.ToString(Session["CompanyCode"]), cmb_Category.Text);
                dt.Load(dr);
                Grd.DataSource = dt;
                Grd.DataBind();

                string LastNo1 = string.Empty;
                string LastNo = dt.Rows[0]["JobNo"].ToString();
                if (cmb_Category.Text == "Air Export")
                { LastNo1 = LastNo.Replace("CSHLAE", null); }
                if (cmb_Category.Text == "Air Import")
                { LastNo1 = LastNo.Replace("CSHLAI", null); }
                if (cmb_Category.Text == "Sea Export")
                { LastNo1 = LastNo.Replace("CSHLSE", null); }
                if (cmb_Category.Text == "Sea Import")
                { LastNo1 = LastNo.Replace("CSHLSI", null); }
                string LastNo2 = LastNo1.Replace("A", null);
                string LastNo3 = LastNo2.Replace("B", null);
                string LastNo4 = LastNo3.Replace("C", null);
                string LastNo5 = LastNo4.Replace("D", null);
                string LastNo6 = LastNo5.Replace("E", null);
                string LastNo7 = LastNo6.Replace("/", "-");
                string LastNo_ = LastNo7;

                string NewNo = (Convert.ToInt32(LastNo_) + 1).ToString();

                if (cmb_Category.Text == "Air Export")
                { tbx_JobNo.Text = "CSHLAE" + NewNo; }
                if (cmb_Category.Text == "Air Import")
                { tbx_JobNo.Text = "CSHLAI" + NewNo; }
                if (cmb_Category.Text == "Sea Export")
                { tbx_JobNo.Text = "CSHLSE" + NewNo; }
                if (cmb_Category.Text == "Sea Import")
                { tbx_JobNo.Text = "CSHLSI" + NewNo; }

                cmb_JobStatus.SelectedIndex = 0;
            }
            catch (Exception ex)
            { lbl_Status.ForeColor = Color.Red; lbl_Status.Text = ex.Message; }
        }

        protected void cmb_Category_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_Category.SelectedIndex != 0)
            {
                GenerateJobNo();
            }
        }
    }
}