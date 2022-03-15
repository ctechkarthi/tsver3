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
    public partial class Expense : System.Web.UI.Page
    {
        #region class
        BusLayer obj_admin = new BusLayer();
        SqlDataReader dr = null;
        DataTable dt = new DataTable(); string JobNo = string.Empty; string Client = string.Empty;
        bool value; 
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            { return; }

            string JobNo_ = Request.QueryString["ien"];
            if (!string.IsNullOrEmpty(JobNo_)) { tbx_JobNo.Text = JobNo_; Search_ExpenseValues(); }
        }

        private void Search_ExpenseJobNo()
        {
            try
            {
                DataTable dtSrch = new DataTable();
                dr = obj_admin.Expense_JobNonExpense(Convert.ToString(Session["CompanyCode"]), cmb_Category.Text);
                if (dr.HasRows)
                {
                    dtSrch = new DataTable();
                    dtSrch.Load(dr);
                    ddl_JobNo.DataSource = dtSrch;
                    ddl_JobNo.DataTextField = dtSrch.Columns["JobNo"].ToString();//CompanyName
                    ddl_JobNo.DataValueField = dtSrch.Columns["JobNo"].ColumnName;
                    ddl_JobNo.DataBind();
                    ddl_JobNo.Items.Insert(0, Global.Select_Default);

                    dtSrch = new DataTable();
                    dt = new DataTable();
                }
                dtSrch = new DataTable();
                dr = obj_admin.SC_AllUsers(Session["CompanyCode"].ToString());
                dtSrch.Load(dr);

                dt = (from DataRow drS in dtSrch.Rows
                      where drS["Type"].ToString() == "Invoice Address"
                      select drS).CopyToDataTable();
                ddl_ClientName.DataSource = dt;
                ddl_ClientName.DataTextField = dt.Columns["CompName"].ToString();//CompanyName
                ddl_ClientName.DataValueField = dt.Columns["CompName"].ColumnName;
                ddl_ClientName.DataBind();
                ddl_ClientName.Items.Insert(0, Global.Select_Default);
                
                //else
                //{
                //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Key", "alert('Invalid Job No.');", true);
                //    lbl_Status.ForeColor = System.Drawing.Color.Red; lbl_Status.Text = "Invalid Job No.";
                //}
            }
            catch (Exception ex)
            { lbl_Status.ForeColor = System.Drawing.Color.Red; lbl_Status.Text = ex.Message; }
        }

        private void Search_ExpenseValues()
        {
            try
            {
                Clear_Particulars(); lbl_Status.Text = "Invalid Job No.";
                dt = new DataTable();
                dr = obj_admin.Job_ExpenseBillAll(Convert.ToString(Session["CompanyCode"]), tbx_JobNo.Text);
                dt.Load(dr);
                if (dt.Rows.Count == 1)
                {
                    Btn_Update.Visible = true; Btn_Insert.Visible = false; Btn_Delete.Visible = true; ImBtn_PDF.Visible = true;
                    lbl_Status.Text = ""; tbx_ClientName.Text = dt.Rows[0]["Shipper"].ToString();
                    tbx_Date.Text = dt.Rows[0]["Date"].ToString(); tbx_AWB.Text = dt.Rows[0]["AWBNo"].ToString();

                    cmb_Category.SelectedValue = dt.Rows[0]["Category"].ToString();
                    tbx_p_customs.Text = dt.Rows[0]["CustExp"].ToString();
                    tbx_p_adc.Text = dt.Rows[0]["ADCCrgs"].ToString();
                    tbx_p_edi.Text = dt.Rows[0]["EDICrgs"].ToString();
                    tbx_p_loading.Text = dt.Rows[0]["LoadingUnloading"].ToString();
                    tbx_p_terminal.Text = dt.Rows[0]["TerminalCrgs"].ToString();
                    tbx_p_transport.Text = dt.Rows[0]["TransportCrgs"].ToString();
                    tbx_p_airfreight.Text = dt.Rows[0]["AIRFreight"].ToString();
                    tbx_p_fsc.Text = dt.Rows[0]["FSC"].ToString();
                    tbx_p_sc.Text = dt.Rows[0]["SC"].ToString();
                    tbx_p_mcc.Text = dt.Rows[0]["MCC"].ToString();
                    tbx_p_xray.Text = dt.Rows[0]["XRAY"].ToString();
                    tbx_p_ams.Text = dt.Rows[0]["AMS"].ToString();
                    tbx_p_dgfee.Text = dt.Rows[0]["DGFee"].ToString();
                    tbx_p_gsp.Text = dt.Rows[0]["GSPCrgs"].ToString();
                    tbx_p_awb.Text = dt.Rows[0]["AWB"].ToString();
                    tbx_p_misc1.Text = dt.Rows[0]["MISCCrgs1"].ToString();
                    tbx_p_OT.Text = dt.Rows[0]["MISCCrgs2"].ToString();
                    tbx_p_Replacement.Text = dt.Rows[0]["MISCCrgs3"].ToString();
                    tbx_p_DO.Text = dt.Rows[0]["DO"].ToString();
                    tbx_p_IHC.Text = dt.Rows[0]["IHC"].ToString();
                    tbx_p_TSA.Text = dt.Rows[0]["TSA"].ToString();
                    tbx_p_STUFFING.Text = dt.Rows[0]["STUFFING"].ToString();

                    tbx_a_customs.Text = dt.Rows[0]["CustExpAmt"].ToString();
                    tbx_a_adc.Text = dt.Rows[0]["ADCCrgsAmt"].ToString();
                    tbx_a_edi.Text = dt.Rows[0]["EDICrgsAmt"].ToString();
                    tbx_a_loading.Text = dt.Rows[0]["LoadingUnloadingAmt"].ToString();
                    tbx_a_terminal.Text = dt.Rows[0]["TerminalCrgsAmt"].ToString();
                    tbx_a_transport.Text = dt.Rows[0]["TransportCrgsAmt"].ToString();
                    tbx_a_airfreight.Text = dt.Rows[0]["AIRFreightAmt"].ToString();
                    tbx_a_fsc.Text = dt.Rows[0]["FSCAmt"].ToString();
                    tbx_a_sc.Text = dt.Rows[0]["SCAmt"].ToString();
                    tbx_a_mcc.Text = dt.Rows[0]["MCCAmt"].ToString();
                    tbx_a_xray.Text = dt.Rows[0]["XRAYAmt"].ToString();
                    tbx_a_ams.Text = dt.Rows[0]["AMSAmt"].ToString();
                    tbx_a_dgfee.Text = dt.Rows[0]["DGFeeAmt"].ToString();
                    tbx_a_gsp.Text = dt.Rows[0]["GSPCrgsAmt"].ToString();
                    tbx_a_awb.Text = dt.Rows[0]["AWBAmt"].ToString();
                    tbx_a_misc1.Text = dt.Rows[0]["MISCCrgs1Amt"].ToString();
                    tbx_a_OT.Text = dt.Rows[0]["MISCCrgs2Amt"].ToString();
                    tbx_a_Replacement.Text = dt.Rows[0]["MISCCrgs3Amt"].ToString();
                    tbx_a_DO.Text = dt.Rows[0]["DOAmt"].ToString();
                    tbx_a_IHC.Text = dt.Rows[0]["IHCAmt"].ToString();
                    tbx_a_TSA.Text = dt.Rows[0]["TSAAmt"].ToString();
                    tbx_a_STUFFING.Text = dt.Rows[0]["STUFFINGAmt"].ToString();
                    lbl_total.Text = dt.Rows[0]["Total"].ToString();
                    Search_ExpenseJobNo(); 
                }
            }
            catch (Exception ex)
            { lbl_Status.ForeColor = System.Drawing.Color.Red; lbl_Status.Text = ex.Message; }
        }

        private void Grid_Particulars()
        {
            dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[2] { new DataColumn("Id", typeof(int)),
                            new DataColumn("Particulars", typeof(string)) });
            dt.Rows.Add(1, "ADC Charges");//
            dt.Rows.Add(2, "Air/Sea Freight");//
            dt.Rows.Add(3, "Assessment - Examination");
            dt.Rows.Add(4, "AWB + PCA");
            dt.Rows.Add(5, "Bank Charges");
            dt.Rows.Add(6, "Bond Exceution/Cancellation Charges");
            dt.Rows.Add(7, "Cust. Clearanace Charges");//
            dt.Rows.Add(8, "CWC/Terminal/Concor Charges");
            dt.Rows.Add(9, "Delivery Order");
            dt.Rows.Add(10, "DGFT Charges");
            dt.Rows.Add(11, "EDI Charges");//
            dt.Rows.Add(12, "Fumigation Charges");
            dt.Rows.Add(13, "GSP/COO Charges");
            dt.Rows.Add(14, "IHC/LCL Charges");
            dt.Rows.Add(15, "Liner Charges");
            dt.Rows.Add(16, "Loading/Unloading");//
            dt.Rows.Add(17, "MISC Charges");
            dt.Rows.Add(18, "Notry Charges");
            dt.Rows.Add(19, "Other Clearance Charges");
            dt.Rows.Add(20, "Replacement");
            dt.Rows.Add(21, "Stuffing/Destuffing Charges");
            dt.Rows.Add(22, "Transportation Charges");//
            dt.Rows.Add(22, "Terminal Charges");//
            dt.Rows.Add(23, "TSA Charges");
            dt.Rows.Add(24, "Venfor Charges");
            Global._getDTParticulars = dt;          
        }        
     
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }
        
        private void Clear_Particulars()
        {
            tbx_a_customs.Text = tbx_a_edi.Text = tbx_a_adc.Text = tbx_a_loading.Text =
            tbx_a_terminal.Text = tbx_a_transport.Text = tbx_a_airfreight.Text = tbx_a_fsc.Text =
            tbx_a_sc.Text = tbx_a_mcc.Text = tbx_a_xray.Text = tbx_a_ams.Text =
            tbx_a_dgfee.Text = tbx_a_gsp.Text = tbx_a_awb.Text = tbx_a_misc1.Text =
            tbx_a_OT.Text = tbx_a_Replacement.Text = tbx_a_DO.Text = tbx_a_IHC.Text =
            tbx_a_TSA.Text = tbx_a_STUFFING.Text = string.Empty;

            tbx_p_customs.Text = tbx_p_edi.Text = tbx_p_adc.Text = tbx_p_loading.Text =
            tbx_p_terminal.Text = tbx_p_transport.Text = tbx_p_airfreight.Text = tbx_p_fsc.Text =
            tbx_p_sc.Text = tbx_p_mcc.Text = tbx_p_xray.Text = tbx_p_ams.Text =
            tbx_p_dgfee.Text = tbx_p_gsp.Text = tbx_p_awb.Text = tbx_p_misc1.Text =
            tbx_p_OT.Text = tbx_p_Replacement.Text = tbx_p_DO.Text = tbx_p_IHC.Text =
            tbx_p_TSA.Text = tbx_p_STUFFING.Text = string.Empty;

            tbx_AWB.Text = tbx_Date.Text = tbx_ClientName.Text = string.Empty;
        }

        protected void Btn_ClearParti_Click(object sender, EventArgs e)
        {
            Response.Redirect("Expense.aspx");
        }

        protected void Btn_Insert_Click(object sender, EventArgs e)
        {
            try
            {
                lbl_Status.Text = string.Empty;
                if ((!string.IsNullOrEmpty(tbx_JobNo.Text)) && (!string.IsNullOrEmpty(tbx_ClientName.Text)))
                {
                    dt = new DataTable();
                    dr = obj_admin.Job_Expense(Convert.ToString(Session["CompanyCode"]), tbx_JobNo.Text);
                    dt.Load(dr);
                    if (dt.Rows.Count <= 0)
                    {
                        value = obj_admin.Job_Expense_Insert(Convert.ToString(Session["CompanyCode"]), cmb_Category.Text, tbx_JobNo.Text, tbx_ClientName.Text, tbx_Date.Text, tbx_AWB.Text, tbx_p_customs.Text, tbx_p_adc.Text, tbx_p_edi.Text, tbx_p_loading.Text, tbx_p_terminal.Text, tbx_p_transport.Text, tbx_p_airfreight.Text, tbx_p_fsc.Text, tbx_p_sc.Text, tbx_p_mcc.Text, tbx_p_xray.Text, tbx_p_ams.Text, tbx_p_dgfee.Text, tbx_p_gsp.Text, tbx_p_awb.Text, tbx_p_misc1.Text, tbx_p_OT.Text, tbx_p_Replacement.Text, tbx_p_DO.Text, tbx_p_IHC.Text, tbx_p_TSA.Text, tbx_p_STUFFING.Text, "", tbx_a_customs.Text, tbx_a_adc.Text, tbx_a_edi.Text, tbx_a_loading.Text, tbx_a_terminal.Text, tbx_a_transport.Text, tbx_a_airfreight.Text, tbx_a_fsc.Text, tbx_a_sc.Text, tbx_a_mcc.Text, tbx_a_xray.Text, tbx_a_ams.Text, tbx_a_dgfee.Text, tbx_a_gsp.Text, tbx_a_awb.Text, tbx_a_misc1.Text, tbx_a_OT.Text, tbx_a_Replacement.Text, tbx_a_DO.Text, tbx_a_IHC.Text, tbx_a_TSA.Text, tbx_a_STUFFING.Text, "", lbl_total.Text);
                        if (value == true)
                        {
                            lbl_Status.ForeColor = System.Drawing.Color.Red; lbl_Status.Text = "Save Successfully!"; ImBtn_PDF.Visible = true;
                            //  value = obj_admin.LoginHistory_Insert(Login.CompCode, Login.LoginName, Login.LoginUserName, "Expense", "Create", tbx_JobNo.Text, Convert.ToString(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss")));
                        }
                        else
                        {
                            lbl_Status.ForeColor = System.Drawing.Color.Red; lbl_Status.Text = "Value Not Save";
                        }
                    }
                    else { lbl_Status.ForeColor = System.Drawing.Color.Red; lbl_Status.Text = "Job No. " + tbx_JobNo.Text + " already exists! Please check."; }
                }
                else { lbl_Status.ForeColor = System.Drawing.Color.Red; lbl_Status.Text = "Enter Job No & Shipper Name"; }
            }
            catch (Exception ex)
            { lbl_Status.ForeColor = System.Drawing.Color.Red; lbl_Status.Text = ex.Message; }
        }

        protected void Btn_Update_Click(object sender, EventArgs e)
        {
            try
            {
                lbl_Status.Text = string.Empty;
                if ((!string.IsNullOrEmpty(tbx_JobNo.Text)) && (!string.IsNullOrEmpty(tbx_ClientName.Text)))
                {
                    value = obj_admin.Job_Expense_Update(Convert.ToString(Session["CompanyCode"]), cmb_Category.Text, tbx_JobNo.Text, tbx_ClientName.Text, tbx_Date.Text, tbx_AWB.Text, tbx_p_customs.Text, tbx_p_adc.Text, tbx_p_edi.Text, tbx_p_loading.Text, tbx_p_terminal.Text, tbx_p_transport.Text, tbx_p_airfreight.Text, tbx_p_fsc.Text, tbx_p_sc.Text, tbx_p_mcc.Text, tbx_p_xray.Text, tbx_p_ams.Text, tbx_p_dgfee.Text, tbx_p_gsp.Text, tbx_p_awb.Text, tbx_p_misc1.Text, tbx_p_OT.Text, tbx_p_Replacement.Text, tbx_p_DO.Text, tbx_p_IHC.Text, tbx_p_TSA.Text, tbx_p_STUFFING.Text, "", tbx_a_customs.Text, tbx_a_adc.Text, tbx_a_edi.Text, tbx_a_loading.Text, tbx_a_terminal.Text, tbx_a_transport.Text, tbx_a_airfreight.Text, tbx_a_fsc.Text, tbx_a_sc.Text, tbx_a_mcc.Text, tbx_a_xray.Text, tbx_a_ams.Text, tbx_a_dgfee.Text, tbx_a_gsp.Text, tbx_a_awb.Text, tbx_a_misc1.Text, tbx_a_OT.Text, tbx_a_Replacement.Text, tbx_a_DO.Text, tbx_a_IHC.Text, tbx_a_TSA.Text, tbx_a_STUFFING.Text, "", lbl_total.Text);
                    if (value == true)
                    {
                        lbl_Status.ForeColor = System.Drawing.Color.Red; lbl_Status.Text = "Save Successfully!"; ImBtn_PDF.Visible = true;
                        //  value = obj_admin.LoginHistory_Insert(Login.CompCode, Login.LoginName, Login.LoginUserName, "Expense", "Create", tbx_JobNo.Text, Convert.ToString(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss")));
                    }
                    else
                    {
                        lbl_Status.ForeColor = System.Drawing.Color.Red; lbl_Status.Text = "Value Not Save";
                    }
                }
                else { lbl_Status.ForeColor = System.Drawing.Color.Red; lbl_Status.Text = "Enter Job No & Shipper Name"; }
            }
            catch (Exception ex)
            { lbl_Status.ForeColor = System.Drawing.Color.Red; lbl_Status.Text = ex.Message; }
        }

        protected void Btn_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                lbl_Status.Text = string.Empty;
                string confirmValue = Request.Form["confirm_value"];
                if (confirmValue == "Yes")
                {
                    if (!string.IsNullOrEmpty(tbx_JobNo.Text))
                    {
                        value = obj_admin.Job_Expense_Delete(Convert.ToString(Session["CompanyCode"]), tbx_JobNo.Text);
                        if (value == true)
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Key", "alert(Delete Success !);", true);
                        }
                        else { lbl_Status.ForeColor = System.Drawing.Color.Red; lbl_Status.Text = "Record Not Delete!"; }
                    }
                    else { lbl_Status.ForeColor = System.Drawing.Color.Red; lbl_Status.Text = "Please Enter Job No and MAWB/MBL!"; }
                }
                else { lbl_Status.ForeColor = System.Drawing.Color.Red; lbl_Status.Text = "Cost Sheet not delete!"; }
            }
            catch (Exception ex)
            { lbl_Status.ForeColor = System.Drawing.Color.Red; lbl_Status.Text = ex.Message; }
        }

        protected void ImBtn_PDF_Click(object sender, ImageClickEventArgs e)
        {
            if (!string.IsNullOrEmpty(tbx_JobNo.Text))
            {
                //string js = "javascript:openFile('" + "InvoiceNew.aspx?ien=" + tbx_BillNo.Text + "')";
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop up", js, true);
                //string BillNo = HttpUtility.UrlEncode(Encrypt(tbx_BillNo.Text.Trim()));
                //string JobNo = HttpUtility.UrlEncode(Encrypt("0011"));//ddl_JobNumber.SelectedValue.Trim()));
                StringBuilder sb = new StringBuilder();
                sb.Append("<script type = 'text/javascript'>");
                sb.Append("window.open('");
                sb.Append("ExpensePDF.aspx?sslorf=AL5rthrh12yyjr6j1rtjeKk003ytwewebrq8wmI385yYqEbTmkoM55qOjgTMA884mtrtrt88735780&ei=H2quXvpibvrytynoqoevnewuUL42om4werfwf9fwf2mtohbnnweuqwoinxcvbdfgreggnkoM55qr4Ag&ien=" + tbx_JobNo.Text + "&spjggsrf=ALeKk003385yYqEbTmkoM55qOjgTMA1588488735780&eilp=HvuUL42o9QON1Kr4Ag");
                sb.Append("');");
                sb.Append("</script>");
                ClientScript.RegisterStartupScript(this.GetType(), "script", sb.ToString());
            }
            else { lbl_Status.ForeColor = System.Drawing.Color.Red; lbl_Status.Text = "Please Enter Job No!"; }
        }

        //protected void cmb_Category_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (cmb_Category.SelectedIndex != 0)
        //        {
        //            dt = new DataTable();
        //            //dr = obj_admin.Expense_Invoice(Session["CompanyCode"].ToString(), cmb_Category.Text);
        //            dt.Load(dr);
        //            ddl_JobNo.DataSource = dt;
        //            ddl_JobNo.DataTextField = dt.Columns["JobNo"].ToString();//CompanyName
        //            ddl_JobNo.DataValueField = dt.Columns["JobNo"].ColumnName;
        //            ddl_JobNo.DataBind();
        //            ddl_JobNo.Items.Insert(0, Global.Select_Default);
        //        }
        //    }
        //    catch (Exception ex)
        //    { lbl_Status.ForeColor = System.Drawing.Color.Red; lbl_Status.Text = ex.Message; }
        //}

        protected void ddl_JobNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddl_JobNo.SelectedIndex != 0)
                { tbx_JobNo.Text = ddl_JobNo.SelectedValue.ToString(); }
            }
            catch (Exception ex)
            { lbl_Status.ForeColor = System.Drawing.Color.Red; lbl_Status.Text = ex.Message; }
        }

        protected void ddl_ClientName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddl_ClientName.SelectedIndex != 0)
                { tbx_ClientName.Text = ddl_ClientName.Text; }
            }
            catch (Exception ex)
            { lbl_Status.ForeColor = System.Drawing.Color.Red; lbl_Status.Text = ex.Message; }
        }

        private void ExpenseTotal()
        {
            decimal Total = Convert.ToDecimal(tbx_a_customs.Text) + Convert.ToDecimal(tbx_a_edi.Text) + Convert.ToDecimal(tbx_a_adc.Text) + Convert.ToDecimal(tbx_a_loading.Text) +
            Convert.ToDecimal(tbx_a_terminal.Text) + Convert.ToDecimal(tbx_a_transport.Text) + Convert.ToDecimal(tbx_a_airfreight.Text) + Convert.ToDecimal(tbx_a_fsc.Text) +
            Convert.ToDecimal(tbx_a_sc.Text) + Convert.ToDecimal(tbx_a_mcc.Text) + Convert.ToDecimal(tbx_a_xray.Text) + Convert.ToDecimal(tbx_a_ams.Text) +
            Convert.ToDecimal(tbx_a_dgfee.Text) + Convert.ToDecimal(tbx_a_gsp.Text) + Convert.ToDecimal(tbx_a_awb.Text) + Convert.ToDecimal(tbx_a_misc1.Text) +
            Convert.ToDecimal(tbx_a_OT.Text) + Convert.ToDecimal(tbx_a_Replacement.Text) + Convert.ToDecimal(tbx_a_DO.Text) + Convert.ToDecimal(tbx_a_IHC.Text) +
            Convert.ToDecimal(tbx_a_TSA.Text) + Convert.ToDecimal(tbx_a_STUFFING.Text);
           lbl_total.Text = Total.ToString();
        }

        protected void tbx_a_customs_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbx_a_customs.Text))
            { ExpenseTotal(); }
            else { lbl_Status.Text = "Please Enter the value"; }
        }

        protected void tbx_a_edi_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbx_a_edi.Text))
            { ExpenseTotal(); }
            else { lbl_Status.Text = "Please Enter the value"; }
        }

        protected void tbx_a_adc_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbx_a_adc.Text))
            { ExpenseTotal(); }
            else { lbl_Status.Text = "Please Enter the value"; }
        }

        protected void tbx_a_loading_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbx_a_loading.Text))
            { ExpenseTotal(); }
            else { lbl_Status.Text = "Please Enter the value"; }
        }

        protected void tbx_a_terminal_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbx_a_terminal.Text))
            { ExpenseTotal(); }
            else { lbl_Status.Text = "Please Enter the value"; }
        }

        protected void tbx_a_transport_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbx_a_transport.Text))
            { ExpenseTotal(); }
            else { lbl_Status.Text = "Please Enter the value"; }
        }

        protected void tbx_a_airfreight_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbx_a_airfreight.Text))
            { ExpenseTotal(); }
            else { lbl_Status.Text = "Please Enter the value"; }
        }

        protected void tbx_a_fsc_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbx_a_fsc.Text))
            { ExpenseTotal(); }
            else { lbl_Status.Text = "Please Enter the value"; }
        }

        protected void tbx_a_sc_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbx_a_sc.Text))
            { ExpenseTotal(); }
            else { lbl_Status.Text = "Please Enter the value"; }
        }

        protected void tbx_a_mcc_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbx_a_mcc.Text))
            { ExpenseTotal(); }
            else { lbl_Status.Text = "Please Enter the value"; }
        }

        protected void tbx_a_xray_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbx_a_xray.Text))
            { ExpenseTotal(); }
            else { lbl_Status.Text = "Please Enter the value"; }
        }

        protected void tbx_a_ams_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbx_a_ams.Text))
            { ExpenseTotal(); }
            else { lbl_Status.Text = "Please Enter the value"; }
        }

        protected void tbx_a_dgfee_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbx_a_dgfee.Text))
            { ExpenseTotal(); }
            else { lbl_Status.Text = "Please Enter the value"; }
        }

        protected void tbx_a_gsp_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbx_a_gsp.Text))
            { ExpenseTotal(); }
            else { lbl_Status.Text = "Please Enter the value"; }
        }

        protected void tbx_a_awb_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbx_a_awb.Text))
            { ExpenseTotal(); }
            else { lbl_Status.Text = "Please Enter the value"; }
        }

        protected void tbx_a_misc1_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbx_a_misc1.Text))
            { ExpenseTotal(); }
            else { lbl_Status.Text = "Please Enter the value"; }
        }

        protected void tbx_a_OT_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbx_a_OT.Text))
            { ExpenseTotal(); }
            else { lbl_Status.Text = "Please Enter the value"; }
        }

        protected void tbx_a_Replacement_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbx_a_Replacement.Text))
            { ExpenseTotal(); }
            else { lbl_Status.Text = "Please Enter the value"; }
        }

        protected void tbx_a_DO_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbx_a_DO.Text))
            { ExpenseTotal(); }
            else { lbl_Status.Text = "Please Enter the value"; }
        }

        protected void tbx_a_IHC_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbx_a_IHC.Text))
            { ExpenseTotal(); }
            else { lbl_Status.Text = "Please Enter the value"; }
        }

        protected void tbx_a_TSA_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbx_a_TSA.Text))
            { ExpenseTotal(); }
            else { lbl_Status.Text = "Please Enter the value"; }
        }

        protected void tbx_a_STUFFING_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbx_a_STUFFING.Text))
            { ExpenseTotal(); }
            else { lbl_Status.Text = "Please Enter the value"; }
        }

        protected void cmb_Category_SelectedIndexChanged(object sender, EventArgs e)
        {
            Search_ExpenseJobNo();
        }
    }
}