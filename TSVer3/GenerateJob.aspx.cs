using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TSVer3.BL;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Drawing;
using System.Text;
using System.Security.Cryptography;
using System.Collections;

namespace TSVer3
{
    public partial class GenerateJob : System.Web.UI.Page
    {
        #region class
        BusLayer obj_admin = new BusLayer();
        SqlDataReader dr = null;
        DataTable dt = new DataTable(); string JobNo = string.Empty; string Client = string.Empty;
        bool value; decimal grdTaxAmount = 0;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            { return; }

            string JobNo_ = Request.QueryString["ien"];
            Clear();
            dGrdAWBDetails();
            cmb_Category.SelectedIndex = 0;
            SalesMan_Load();
        }

        protected void GrdInvoice_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrdInvoice.PageIndex = e.NewPageIndex;
        }

        private void dGrdAWBDetails()
        {
            dt = new DataTable();
            dr = obj_admin.Gen_Job(Convert.ToString(Session["CompanyCode"]));
            GrdInvoice.DataSource = dt;
            GrdInvoice.DataBind();
        }

        protected void GrdInvoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lbl_Status.Text = null;
                cmb_Category.SelectedValue = GrdInvoice.SelectedRow.Cells[1].Text;
                tbx_JobNo.Text = GrdInvoice.SelectedRow.Cells[2].Text;
                cmb_Sales.SelectedValue = GrdInvoice.SelectedRow.Cells[3].Text;
                cmb_JobStatus.SelectedValue = GrdInvoice.SelectedRow.Cells[4].Text;
                //dt = new DataTable(); dr = obj_admin.MAWB_Search(Convert.ToString(Session["CompanyCode"]), tbx_AWB.Text, "MAWB");
                //dt.Load(dr); AWB_Values();
            }
            catch (Exception ex)
            { lbl_Status.Text = ex.Message; }
        }

        private void Btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(tbx_JobNo.Text))
                {
                    if (cmb_Category.SelectedIndex != 0)
                    {
                        string JobNo;
                        if (cmb_Sales.SelectedIndex != 0)
                        {
                            dt = new DataTable();
                            dr = obj_admin.Gen_JobNo(Convert.ToString(Session["CompanyCode"]), tbx_JobNo.Text);
                            dt.Load(dr); JobNo = tbx_JobNo.Text;
                            if (dt.Rows.Count <= 0)
                            {
                                value = obj_admin.Gen_Job_Insert(Convert.ToString(Session["CompanyCode"]), tbx_JobNo.Text, cmb_Category.Text, "YES", cmb_Sales.Text, cmb_JobStatus.Text, Convert.ToString(DateTime.Now.ToString("MMM-yyyy")));
                                if (value == true)
                                {
                                    lbl_Status.Text = "Save Successfully, Your Job No. " + tbx_JobNo.Text; dGrdAWBDetails(); //Btn_Save.Visible = false; tbx_AWB.ReadOnly = true; Btn_GenHAWB.Visible = true;
                                    value = obj_admin.LoginHistory_Insert(Convert.ToString(Session["CompanyCode"]), Convert.ToString(Session["LoginName"]), Convert.ToString(Session["LoginName"]), cmb_Category.Text, "Create", tbx_JobNo.Text, Convert.ToString(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss")));
                                    dt = new DataTable();
                                    dr = obj_admin.Gen_Job_Last(Convert.ToString(Session["CompanyCode"]), cmb_Category.Text);
                                    dt.Load(dr);
                                    GrdInvoice.DataSource = dt;
                                    GrdInvoice.DataBind();
                                }
                                else
                                { lbl_Status.Text = "Please check the Job not saved"; }
                            }
                            else
                            {
                                GenerateJobNo();
                                value = obj_admin.Gen_Job_Insert(Convert.ToString(Session["CompanyCode"]), tbx_JobNo.Text, cmb_Category.Text, "YES", cmb_Sales.Text, cmb_JobStatus.Text, Convert.ToString(DateTime.Now.ToString("MMM-yyyy")));
                                if (value == true)
                                {
                                    lbl_Status.Text = "Save Successfully, Job No. " + JobNo + " already exists, Your New Job No. " + tbx_JobNo.Text; dGrdAWBDetails(); //Btn_Save.Visible = false; tbx_AWB.ReadOnly = true; Btn_GenHAWB.Visible = true;
                                    value = obj_admin.LoginHistory_Insert(Convert.ToString(Session["CompanyCode"]), Convert.ToString(Session["LoginName"]), Convert.ToString(Session["LoginName"]), cmb_Category.Text, "Create", tbx_JobNo.Text, Convert.ToString(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss")));
                                    dt = new DataTable();
                                    dr = obj_admin.Gen_Job_Last(Convert.ToString(Session["CompanyCode"]), cmb_Category.Text);
                                    dt.Load(dr);
                                    GrdInvoice.DataSource = dt;
                                    GrdInvoice.DataBind();
                                }
                                else
                                {
                                    lbl_Status.Text = "Please check the Job not saved";
                                }
                            }
                        }
                        else { lbl_Status.Text = "Please Select - Generate By"; }
                    }
                    else { lbl_Status.Text = "Please Select - Category"; }
                }
                else { lbl_Status.Text = "Please Enter - Job Number"; }
            }
            catch (Exception ex)
            { lbl_Status.Text = ex.Message; }
        }

        private void Btn_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                string confirmValue = Request.Form["confirm_value"];
                if (confirmValue == "Yes")
                {
                    if (!string.IsNullOrEmpty(tbx_JobNo.Text))
                    {
                        value = obj_admin.Gen_Job_Delete(Convert.ToString(Session["CompanyCode"]), tbx_JobNo.Text);
                        if (value == true)
                        {
                            lbl_Status.Text = "Job No. " + tbx_JobNo.Text + " Delete Success!"; dGrdAWBDetails();
                            value = obj_admin.LoginHistory_Insert(Convert.ToString(Session["CompanyCode"]), Convert.ToString(Session["LoginName"]), Convert.ToString(Session["LoginName"]), cmb_Category.Text, "Delete", tbx_JobNo.Text, Convert.ToString(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss")));
                            dt = new DataTable();
                            dr = obj_admin.Gen_Job_Last(Convert.ToString(Session["CompanyCode"]), cmb_Category.Text);
                            dt.Load(dr);
                            GrdInvoice.DataSource = dt;
                            GrdInvoice.DataBind();
                        }
                        else
                        {
                            lbl_Status.Text = "Job No. " + tbx_JobNo.Text + " Not Delete!";
                        }
                    }
                    else { lbl_Status.Text = "Please Enter Job No."; }
                }
                else { lbl_Status.ForeColor = System.Drawing.Color.Red; lbl_Status.Text = "Invoice not delete!"; }
            }
            catch (Exception ex)
            { lbl_Status.Text = ex.Message; }
        }

        private void Clear()
        {
            tbx_JobNo.Text = "";
        }

        protected void Btn_Clear_Click(object sender, EventArgs e)
        {
            Clear(); //Clear_Session();
            Btn_Save.Visible = true; Btn_Delete.Visible = false; //Btn_GenAWB.Visible = false; Btn_GenHAWB.Visible = false;
        }

        protected void Btn_ClearParti_Click(object sender, EventArgs e)
        {

        }

        protected void cmbParticulars_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_Category.SelectedIndex != 0)
            {
                GenerateJobNo();
            }
        }

        private void GenerateJobNo()
        {
            try
            {
                dt = new DataTable();
                dr = obj_admin.Gen_Job_Last(Convert.ToString(Session["CompanyCode"]), cmb_Category.Text);
                dt.Load(dr);
                GrdInvoice.DataSource = dt;

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
            { lbl_Status.Text = ex.Message; }
        }

        private void SalesMan_Load()
        {
            try
            {
                dt = new DataTable();
                dr = obj_admin.Login_Name(Convert.ToString(Session["CompanyCode"]));
                dt.Load(dr);
                cmb_Sales.DataSource = Global._getDTParticulars;
                cmb_Sales.DataTextField = "Name";
                cmb_Sales.DataValueField = "Name";
                cmb_Sales.DataBind();
                cmb_Sales.Items.Insert(0, Global.Select_Default);
            }
            catch (Exception ex)
            { lbl_Status.Text = ex.Message; }
        }
    }
}