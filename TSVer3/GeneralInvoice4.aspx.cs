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
using TSVer3.Modal;

namespace TSVer3
{
    public partial class GeneralInvoice4 : System.Web.UI.Page
    {
        #region class
        BusLayer obj_admin = new BusLayer();
        SqlDataReader dr = null;
        DataTable dt = new DataTable(); string BillNo = string.Empty; string Client = string.Empty;
        DataTable dt_NameList = new DataTable();
        bool value; decimal grdTaxAmount = 0; decimal IGST_Particulars = 0; decimal IGSTValue_Particulars = 0;
        decimal GST_Particulars = 0; decimal GSTValue_Particulars = 0; decimal SCGST_Particulars = 0; decimal SCGSTValue_Particulars = 0; DataSet ds = new DataSet();
        decimal grdNonTaxAmount = 0; decimal grdCGSTAmount = 0; decimal grdIGSTAmount = 0;
        RedData response = new RedData();
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            { return; }

            //Session["CompanyCode"] = "CSHBLR"; string BillNo_ = "CSHLAI202100074";// Session["BillNo"].ToString();// Request.QueryString["ien"];
            string BillNo_ = Request.QueryString["ien"];
            if (!string.IsNullOrEmpty(BillNo_)) { tbx_BillNo.Text = BillNo_; Search_Invoice(); }

            dt = new DataTable();
            dr = obj_admin.ParticularsWithHSNGST_Details(Session["CompanyCode"].ToString());
            dt.Load(dr);
            Global._getDTParticulars = dt;
            if (!string.IsNullOrEmpty(Convert.ToString(tbx_BillNo.Text)))
            {
                FillGrid();
            }
            else { Particulars_Load(); FillEmptyGrid(); JobNo_Load(); }
        }

        private void FillEmptyGrid()
        {
            dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[10] { new DataColumn("Id", typeof(int)),
                            new DataColumn("Particulars", typeof(string)),
                            new DataColumn("Additional", typeof(string)),
                            new DataColumn("Quantity", typeof(string)),
                            new DataColumn("Rate", typeof(string)),
                            new DataColumn("NonTaxAmt", typeof(string)),
                            new DataColumn("TaxAmt", typeof(string)),
                            new DataColumn("CGSTValue", typeof(string)),
                            new DataColumn("SGSTValue", typeof(string)),
                            new DataColumn("IGSTValue", typeof(string)) });
            dt.Rows.Add(0, "", "", "", "", "0", "0", "0", "0", "0");
            GrdInvoice.DataSource = dt;
            GrdInvoice.DataBind();
        }

        //protected void OnPaging(object sender, GridViewPageEventArgs e)
        //{
        //    this.BindData();
        //    GrdInvoice.PageIndex = e.NewPageIndex;
        //    GrdInvoice.DataBind();
        //} 

        public void FillGrid()
        {
            Particulars_Load();
            BillNo = Convert.ToString(tbx_BillNo.Text);
            if (!string.IsNullOrEmpty(BillNo))
            {
                Global._getDT = dt = new DataTable();
                dr = obj_admin.InvoiceParticulars_Search(Convert.ToString(Session["CompanyCode"]), BillNo, "Debit Note");
                dt.Load(dr);
                if (dt.Rows.Count == 0)
                { FillEmptyGrid(); }
                else
                {
                    GrdInvoice.DataSource = Global._getDT = dt;
                    GrdInvoice.DataBind();
                }
            }
            else
            {
                FillEmptyGrid();
                //dt = new DataTable();
                //dt.Rows.Add(dt.NewRow());
                //GrdInvoice.DataSource = dt;
                //GrdInvoice.DataBind();
                //int totalcolums = GrdInvoice.Rows[0].Cells.Count;
                //GrdInvoice.Rows[0].Cells.Clear();
                //GrdInvoice.Rows[0].Cells.Add(new TableCell());
                //GrdInvoice.Rows[0].Cells[0].ColumnSpan = totalcolums;
                //GrdInvoice.Rows[0].Cells[0].Text = "No Data Found";
            }
        }

        private void Particulars_Load()
        {
            ////dt = new DataTable(); dr = obj_admin.ParticularsWithHSNGST_Details(Session["CompanyCode"].ToString()); dt.Load(dr);
            //cmb_Particulars.DataSource = Global._getDTParticulars;
            //cmb_Particulars.DataTextField = "Particulars";
            //cmb_Particulars.DataValueField = "Particulars";
            //cmb_Particulars.DataBind();
            //cmb_Particulars.Items.Insert(0, Global.Select_Default);
        }

        private void Clear()
        {
            lbl_Status.Text =  "";
            tbx_BillDate.Text = "";
            tbx_InvToL1.Text = "";
            tbx_InvToL2.Text = "";
            tbx_InvToL3.Text = "";
            tbx_InvToL4.Text = "";
            tbx_InvToL5.Text = "";
            tbx_AWB_No.Text = "";
            tbx_HAWB_No.Text = "";
            tbx_Origin.Text = tbx_Dest.Text = "";
            tbx_GW.Text = "";// tbx_AssesValue.Text = tbx_OOC.Text = "";
            tbx_IGST_Total.Text = "";
            tbx_TotalAmt.Text = tbx_GrandTotal.Text = "";
            tbx_Shipper.Text = tbx_EGM.Text = tbx_CBM.Text = tbx_Volume.Text = tbx_ShInvoice.Text = "";
            tbx_Line.Text = tbx_CurrValue.Text = "";
            lbl_Month.Text = ""; ImBtn_PDF.Visible = false;
            ddl_CurrencyType.SelectedIndex = ddl_SalesRep.SelectedIndex = 0;
            tbx_TotalTax.Text = tbx_TotalNonTax.Text = tbx_Advance.Text = ""; tbx_GurL1.Text = tbx_GurL2.Text = tbx_GurL3.Text = tbx_GurL4.Text = "";
        }

        private void Clear_Particulars()
        {
            lblId.Text = lbl_HSN.Text = string.Empty;
        }

        protected void Btn_Clear_Click(object sender, EventArgs e)
        {
           Response.Redirect("GeneralInvoice4.aspx");
        }

        protected void GrdInvoice_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Footer)//for footer template
            {
                DropDownList cmbParticulars_I = (DropDownList)e.Row.FindControl("cmbParticulars_I");
                cmbParticulars_I.DataSource = Global._getDTParticulars;
                cmbParticulars_I.DataTextField = "Particulars";
                cmbParticulars_I.DataValueField = "Particulars";
                cmbParticulars_I.DataBind();
                cmbParticulars_I.Items.Insert(0, Global.Select_Default);
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (GrdInvoice.Rows.Count >= 0)
                {
                    decimal TotalTaxAmount = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TaxAmt"));
                    grdTaxAmount += TotalTaxAmount;

                    decimal TotalNonTaxAmount = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "NonTaxAmt"));
                    grdNonTaxAmount += TotalNonTaxAmount;
                    //  IGSTTax_Det = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TaxAmt"));
                    decimal TotalCGST = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "CGSTValue"));
                    grdCGSTAmount += TotalCGST;
                    decimal TotalIGST = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "IGSTValue"));
                    grdIGSTAmount += TotalIGST;
                }

                DropDownList cmbType = (DropDownList)e.Row.FindControl("cmbParticulars");
                if (cmbType != null)
                {
                    cmbType.DataSource = Global._getDTParticulars;
                    cmbType.DataTextField = "Particulars";
                    cmbType.DataValueField = "Particulars";
                    cmbType.DataBind();
                    cmbType.Items.Insert(0, Global.Select_Default);
                    cmbType.SelectedValue = GrdInvoice.DataKeys[e.Row.RowIndex].Values[1].ToString();
                }

                //txt_AdditionalInfo.Text = string.Empty;
                //txt_TaxAmt.Text = txt_NonTaxAmt.Text = "0.00";

                tbx_TotalTax.Text = String.Format("{0: #,#.00}", grdTaxAmount.ToString());
                tbx_TotalNonTax.Text = String.Format("{0: #,#.00}", grdNonTaxAmount.ToString());

                double grdTaxAmount_ = Convert.ToDouble(grdTaxAmount);
                decimal TotalTaxAmt = 0;

                if (tbx_StateCodeCust.Text == "29") //KA
                {
                    if (lbl_HSN.Text != "-")
                    {
                        tbx_IGST_Total.Text = "0";
                        tbx_SGST_Total.Text = (Math.Round(grdCGSTAmount, 2)).ToString();
                        TotalTaxAmt = grdCGSTAmount * 2;
                    }
                }
                else //if (tbx_StateCodeCust.Text != "29")
                {
                    if (lbl_HSN.Text != "-") //if (!string.IsNullOrEmpty(lbl_HSN.Text))
                    {
                        tbx_SGST_Total.Text = "0";
                        tbx_IGST_Total.Text = (Math.Round(grdIGSTAmount, 2)).ToString();
                    }
                    TotalTaxAmt = grdIGSTAmount;
                }
                decimal TotAmtRound = 0;
                decimal TotAmt = TotalTaxAmt + grdNonTaxAmount + grdTaxAmount;
                TotAmt = Convert.ToDecimal(String.Format("{0: #,#.00}", TotAmt));
                tbx_TotalAmt.Text = String.Format("{0: #,#.00}", TotAmt.ToString()); TotAmtRound = Math.Round(TotAmt);
                tbx_GrandTotal.Text = String.Format("{0: #,#.00}", TotAmtRound.ToString()); //tbx_GrandTotal.Text = string.Format(String.Format("{0:N2}", TotAmtRound));
            }
            e.Row.Cells[0].Visible = false;
        }

        protected void GrdInvoice_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            lbl_Status.Text = "";
            GrdInvoice.EditIndex = -1;
            FillGrid();
        }

        protected void GrdInvoice_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GrdInvoice.EditIndex = e.NewEditIndex;
            FillGrid();
        }

        protected void GrdInvoice_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrdInvoice.PageIndex = e.NewPageIndex;
            FillGrid();
        }

        protected void GrdInvoice_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            lbl_Status.Text = "";
            Label lblId = (Label)GrdInvoice.Rows[e.RowIndex].FindControl("lblId");
            TextBox txtAdditionalInfo = (TextBox)GrdInvoice.Rows[e.RowIndex].FindControl("txtAdditionalInfo");
            // TextBox txtRate = (TextBox)GrdInvoice.Rows[e.RowIndex].FindControl("txtRate");
            // TextBox txtQuantity = (TextBox)GrdInvoice.Rows[e.RowIndex].FindControl("txtQuantity");
            TextBox txtTaxAmt = (TextBox)GrdInvoice.Rows[e.RowIndex].FindControl("txtTaxAmt");
            TextBox txtNonTaxAmt = (TextBox)GrdInvoice.Rows[e.RowIndex].FindControl("txtNonTaxAmt");
            DropDownList cmbParticulars = (DropDownList)GrdInvoice.Rows[e.RowIndex].FindControl("cmbParticulars");

            if (string.IsNullOrEmpty(txtTaxAmt.Text)) { txtTaxAmt.Text = "0.00"; }
            if (string.IsNullOrEmpty(txtNonTaxAmt.Text)) { txtNonTaxAmt.Text = "0.00"; }

            if (cmbParticulars.SelectedItem.Text != Global.Select_Default)
            {
                int RowCount = Global._getDT.Rows.Count;
                int j = 0;
                for (int i = 0; i < RowCount; i++)
                {
                    if (cmbParticulars.SelectedValue == Global._getDT.Rows[i]["Particulars"].ToString())
                    {
                        j = 1;
                    }
                }
                Particulars_SelectedValue = cmbParticulars.Text; GST_Tax_Amount = Convert.ToDecimal(txtTaxAmt.Text);
                Particulars_TaxCalculation(); //Particulars_TotalCalculation();

                value = obj_admin.CustInvParticulars_Update(Convert.ToInt32(lblId.Text), Session["CompanyCode"].ToString(), tbx_BillNo.Text, lbl_HSN.Text, Particulars_SelectedValue, txtAdditionalInfo.Text, "", "", txtTaxAmt.Text, txtNonTaxAmt.Text, IGST_Particulars.ToString(), IGSTValue_Particulars.ToString(), SCGST_Particulars.ToString(), SCGSTValue_Particulars.ToString(), SCGST_Particulars.ToString(), SCGSTValue_Particulars.ToString(), "0", "Debit Note");
                // value = obj_Admin.CustInvParticulars_Update(ParticularsId,                                  Login.CompCode, tbx_BillNo.Text, lbl_HSN.Text, cmb_Particulars.SelectedValue.ToString(), tbx_Additional.Text, "","", Math.Round(TaxAmount_Particulars, 2).ToString(), tbx_NonTaxAmt.Text, IGST_Particulars.ToString(), IGSTValue_Particulars.ToString(), SCGST_Particulars.ToString(), SCGSTValue_Particulars.ToString(), SCGST_Particulars.ToString(), SCGSTValue_Particulars.ToString(), "0", "Debit Note");
                if (value == true)
                {
                    GrdInvoice.EditIndex = -1; FillGrid(); lbl_POP_Result.Text = "Particulars Update Success!"; Insert_BillNo();
                }
                else { lbl_POP_Result.Text = "Record Already Exits!"; }
            }
        }

        protected void GrdInvoice_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            lbl_POP_Result.Text = "";
            int id = Convert.ToInt32(GrdInvoice.DataKeys[e.RowIndex].Values[0].ToString());
            value = obj_admin.CustInvParticulars_Delete(id, Convert.ToString(Session["CompanyCode"]), "Debit Note");
            if (value == true)
            { FillGrid(); Particulars_TotalCalculation(); lbl_POP_Result.Text = "Particulars Delete Success!"; Insert_BillNo(); }
            else { lbl_POP_Result.Text = "Record Not Delete!"; }
        }

        string Particulars_SelectedValue = string.Empty;
        decimal GST_Tax_Amount = 0;

        // insert new record in database
        protected void Add(object sender, EventArgs e)
        {
            Control control = null;
            if (GrdInvoice.FooterRow != null)
            {
                control = GrdInvoice.FooterRow;
            }
            else
            {
                control = GrdInvoice.Controls[0].Controls[0];
            }
            string txt_AdditionalInfo = (control.FindControl("txt_AdditionalInfo") as TextBox).Text;
            //  string txt_Quantity = (control.FindControl("txt_Quantity") as TextBox).Text;
            //  string txt_Rate = (control.FindControl("txt_Rate") as TextBox).Text;
            string txt_TaxAmt = (control.FindControl("txt_TaxAmt") as TextBox).Text;
            string txt_NonTaxAmt = (control.FindControl("txt_NonTaxAmt") as TextBox).Text;
            string cmbParticulars_I = (control.FindControl("cmbParticulars_I") as DropDownList).Text;
            lbl_POP_Result.Text = string.Empty;
            if (!string.IsNullOrEmpty(tbx_BillNo.Text))
            {
                if (cmbParticulars_I != Global.Select_Default)
                {
                    if (string.IsNullOrEmpty(txt_TaxAmt)) { txt_TaxAmt = "0.00"; }
                    if (string.IsNullOrEmpty(txt_NonTaxAmt)) { txt_NonTaxAmt = "0.00"; }

                    Particulars_SelectedValue = cmbParticulars_I; GST_Tax_Amount = Convert.ToDecimal(txt_TaxAmt);
                    Particulars_TaxCalculation();
                    value = obj_admin.CustInvParticulars_New(Session["CompanyCode"].ToString(), tbx_BillNo.Text, lbl_HSN.Text, Particulars_SelectedValue, txt_AdditionalInfo, "", "", txt_TaxAmt, txt_NonTaxAmt, IGST_Particulars.ToString(), IGSTValue_Particulars.ToString(), SCGST_Particulars.ToString(), SCGSTValue_Particulars.ToString(), SCGST_Particulars.ToString(), SCGSTValue_Particulars.ToString(), "0", "Debit Note");
                    if (value == true)
                    {
                        FillGrid(); Particulars_TotalCalculation(); lbl_POP_Result.ForeColor = System.Drawing.Color.Green; lbl_POP_Result.Text = "Particulars Insert Success!"; Clear_Particulars();
                        Insert_BillNo();
                    }
                    else { lbl_POP_Result.ForeColor = System.Drawing.Color.Red; lbl_POP_Result.Text = "Record Already Exits!"; }
                }
                else { ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Key", "alert('Please select Particulars!');", true); }
            }
            else { ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Key", "alert('Please enter Bill No.!');", true); }
        }

        private void Particulars_TaxCalculation()
        {
            var SelectedParticulars_ = (from dr in Global._getDTParticulars.AsEnumerable()
                                        where (dr.Field<string>("Particulars") == Particulars_SelectedValue) //lbl_Particulars
                                        select new
                                        {
                                            HSN = dr.Field<string>("HSN"),
                                            GST = dr.Field<string>("GST")
                                        }).FirstOrDefault();
            SCGST_Particulars = SCGSTValue_Particulars = 0;
            lbl_HSN.Text = SelectedParticulars_.HSN;
            if ((!string.IsNullOrEmpty(SelectedParticulars_.HSN)) && (SelectedParticulars_.HSN != "-"))
            {
                IGST_Particulars = GST_Particulars = Convert.ToDecimal(SelectedParticulars_.GST);               
                if (tbx_StateCodeCust.Text == "29")
                {
                    if (Particulars_SelectedValue == "AIR FREIGHT CHARGES (INTL COURIER)")
                    {
                        IGSTValue_Particulars = Convert.ToDecimal(String.Format("{0: #,#.00}", Convert.ToDecimal(GST_Tax_Amount * IGST_Particulars / 100)));
                        GST_Particulars = GSTValue_Particulars = 0; 
                    }
                    else
                    {
                        GSTValue_Particulars = Convert.ToDecimal(String.Format("{0: #,#.00}", Convert.ToDecimal(GST_Tax_Amount * GST_Particulars / 100))); //Convert.ToDecimal(String.Format("{0: #,#.00}", Convert.ToDecimal(GSTTax_Det * GST_Particulars / 100)));
                        IGST_Particulars = IGSTValue_Particulars = 0;
                        SCGST_Particulars = GST_Particulars / 2;
                        decimal value = GSTValue_Particulars / 2; SCGSTValue_Particulars = Math.Round(value, 2);
                    }
                }
                else if (tbx_StateCodeCust.Text == "00")
                {
                    IGST_Particulars = IGSTValue_Particulars = 0; SCGST_Particulars = SCGSTValue_Particulars = 0; GST_Particulars = GSTValue_Particulars = 0;
                }
                else if (tbx_StateCodeCust.Text != "29")
                {
                    // IGST_Particulars = Convert.ToDecimal(GSTHSN.Substring(0, 2));// display first 2 character
                    IGSTValue_Particulars = Convert.ToDecimal(String.Format("{0: #,#.00}", Convert.ToDecimal(GST_Tax_Amount * IGST_Particulars / 100)));
                    GST_Particulars = GSTValue_Particulars = 0;
                }

                if ((GST_Tax_Amount == 0) || (GST_Tax_Amount.ToString() == "0.00"))
                { IGST_Particulars = IGSTValue_Particulars = 0; SCGST_Particulars = SCGSTValue_Particulars = 0; GST_Particulars = GSTValue_Particulars = 0;}
            }
            else { lbl_HSN.Text = null; }
        }

        private void Particulars_TotalCalculation()
        {
            BillNo = Convert.ToString(tbx_BillNo.Text);
            if (!string.IsNullOrEmpty(BillNo))
            {
                dt = new DataTable();
                dr = obj_admin.InvoiceParticulars_Search(Convert.ToString(Session["CompanyCode"]), BillNo, "Debit Note");
                dt.Load(dr);
                GrdInvoice.DataSource = dt;
                GrdInvoice.DataBind();
                double grdTaxAmount_ = Convert.ToDouble(grdTaxAmount);
                decimal IGST_Total = 0;
                decimal SGST_Total = 0;
                decimal TotalTaxAmt = 0;
                decimal TotalNonTaxAmt = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    TotalTaxAmt += Convert.ToDecimal(dt.Rows[i]["TaxAmt"]);
                    TotalNonTaxAmt += Convert.ToDecimal(dt.Rows[i]["NonTaxAmt"]);
                    IGST_Total += Convert.ToDecimal(dt.Rows[i]["IGSTValue"]);
                    SGST_Total += Convert.ToDecimal(dt.Rows[i]["SGSTValue"]);
                }
                tbx_IGST_Total.Text = IGST_Total.ToString();
                tbx_SGST_Total.Text = SGST_Total.ToString();
                tbx_TotalNonTax.Text = TotalNonTaxAmt.ToString();
                tbx_TotalTax.Text = TotalTaxAmt.ToString();
                decimal TotAmtRound = 0;
                decimal Total = IGST_Total + SGST_Total + SGST_Total + TotalTaxAmt + TotalNonTaxAmt;
                tbx_TotalAmt.Text = Total.ToString(); TotAmtRound = Math.Round(Total);
                tbx_GrandTotal.Text = TotAmtRound.ToString();// String.Format("{0:0.00}", TotAmtRound);  //string.Format(String.Format("{0:N2}", TotAmtRound));
            }
        }
        
        protected void ddl_Category_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_Client_Shiiper_Consignee();  
        }

        private void Search_Invoice()
        {
            try
            {
                Clear();
                dr = obj_admin.Invoice_Search_BillNo2(Convert.ToString(Session["CompanyCode"]), tbx_BillNo.Text, "Debit Note");
                DataTable dtSrch = new DataTable(); dtSrch.Load(dr);
                if (dtSrch.Rows.Count == 1) 
                {
                    Load_Client_Shiiper_Consignee();
                    tbx_BillNo.ReadOnly = true;
                    tbx_BillDate.Text = dtSrch.Rows[0]["BillDate"].ToString();
                    ddl_Category.SelectedValue = dtSrch.Rows[0]["Category"].ToString();
                    tbx_InvToL1.Text = dtSrch.Rows[0]["To1"].ToString();
                    tbx_InvToL2.Text = dtSrch.Rows[0]["To2"].ToString();
                    tbx_InvToL3.Text = dtSrch.Rows[0]["To3"].ToString();
                    tbx_InvToL4.Text = dtSrch.Rows[0]["To4"].ToString();
                    tbx_InvToL5.Text = dtSrch.Rows[0]["To5"].ToString();
                    tbx_GurL1.Text = dtSrch.Rows[0]["Guaranteel1"].ToString();
                    tbx_GurL2.Text = dtSrch.Rows[0]["Guaranteel2"].ToString();
                    tbx_GurL3.Text = dtSrch.Rows[0]["Guaranteel3"].ToString();
                    tbx_GurL4.Text = dtSrch.Rows[0]["Guaranteel4"].ToString();

                    tbx_StateCodeCust.Text = dtSrch.Rows[0]["StateCode"].ToString();
                    tbx_StateCust.Text = dtSrch.Rows[0]["State"].ToString();
                    tbx_GSTNoCust.Text = dtSrch.Rows[0]["GSTNo"].ToString();
                    tbx_JobNo.Text = dtSrch.Rows[0]["JobNo"].ToString();

                    tbx_HAWB_No.Text = dtSrch.Rows[0]["HAWBNo"].ToString();
                    tbx_AWB_No.Text = dtSrch.Rows[0]["AWBNo"].ToString();
                    tbx_SBNo.Text = dtSrch.Rows[0]["SBNo"].ToString();
                    tbx_SBDate.Text = dtSrch.Rows[0]["SBDate"].ToString();
                    //tbx_EGM.Text = dtSrch.Rows[0]["EGM"].ToString();
                    tbx_GW.Text = dtSrch.Rows[0]["GrWeight"].ToString();
                    tbx_Volume.Text = dtSrch.Rows[0]["ChWeight"].ToString();
                    tbx_ShInvoice.Text = dtSrch.Rows[0]["ShInvoice"].ToString();
                    tbx_Shipper.Text = dtSrch.Rows[0]["Shipper"].ToString();
                    tbx_Origin.Text = dtSrch.Rows[0]["Origin"].ToString();
                    tbx_Dest.Text = dtSrch.Rows[0]["Dest"].ToString();
                    tbx_Pkgs.Text = dtSrch.Rows[0]["Pkgs"].ToString();
                    tbx_Line.Text = dtSrch.Rows[0]["Line"].ToString();
                    tbx_EGM.Text = dtSrch.Rows[0]["IGM"].ToString();
                    tbx_CBM.Text = dtSrch.Rows[0]["CBM"].ToString();
                    tbx_CurrValue.Text = dtSrch.Rows[0]["ExRate"].ToString();
                    tbx_Advance.Text = dtSrch.Rows[0]["Advance"].ToString();
                    ddl_CurrencyType.SelectedValue = dtSrch.Rows[0]["CurrValue"].ToString();
                    ddl_SalesRep.SelectedValue = dtSrch.Rows[0]["SalesRep"].ToString();
                    lbl_Month.Text = dtSrch.Rows[0]["Month"].ToString();
                    //tbx_Year.Text = dtSrch.Rows[0]["Year"].ToString();

                    tbx_IGST_Total.Text = dtSrch.Rows[0]["IGST"].ToString();
                    tbx_SGST_Total.Text = dtSrch.Rows[0]["SGST"].ToString();
                    tbx_TotalNonTax.Text = dtSrch.Rows[0]["TotalNonTax"].ToString();
                    tbx_TotalTax.Text = dtSrch.Rows[0]["TotalTax"].ToString();
                    tbx_TotalAmt.Text = dtSrch.Rows[0]["Total"].ToString();
                    tbx_GrandTotal.Text = dtSrch.Rows[0]["GrandTotal"].ToString();

                    //FillGrid();
                    ImBtn_PDF.Visible = true;
                    Btn_Delete.Visible = true; Btn_Save.Visible = true;
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Key", "alert('Invalid Bill No.');", true);
                    lbl_Status.ForeColor = System.Drawing.Color.Red; lbl_Status.Text = "Invalid Bill No."; tbx_BillNo.ReadOnly = false;
                }
            }
            catch (Exception ex)
            { lbl_Status.ForeColor = System.Drawing.Color.Red; lbl_Status.Text = ex.Message; }
        }

        protected void Btn_Save_Click(object sender, EventArgs e)
        {
            Insert_BillNo();
        }

        private void Insert_BillNo()
        {
            try
            {
                lbl_Status.Text = string.Empty;
                if ((ddl_Category.SelectedValue != Global.Select_Default))
                {
                    if ((!string.IsNullOrEmpty(tbx_BillNo.Text)) && (!string.IsNullOrEmpty(lbl_Month.Text)))
                    {
                        decimal Balance_Total = Convert.ToDecimal(tbx_GrandTotal.Text) - Convert.ToDecimal(tbx_Advance.Text);
                        value = obj_admin.Invoice_New(Convert.ToString(Session["CompanyCode"]), ddl_Category.SelectedValue, tbx_JobNo.Text, tbx_BillNo.Text, tbx_BillDate.Text, tbx_InvToL1.Text, tbx_InvToL2.Text, tbx_InvToL3.Text, tbx_InvToL4.Text, tbx_InvToL5.Text, tbx_GurL1.Text,tbx_GurL2.Text,tbx_GurL3.Text,tbx_GurL4.Text, tbx_GSTNoCust.Text, tbx_StateCust.Text, tbx_StateCodeCust.Text, "", tbx_Shipper.Text, "", tbx_AWB_No.Text, tbx_HAWB_No.Text, tbx_SBNo.Text, tbx_SBDate.Text, tbx_Line.Text, tbx_EGM.Text, tbx_CBM.Text, tbx_Origin.Text, tbx_Dest.Text, "", tbx_Pkgs.Text, tbx_GW.Text, tbx_Volume.Text, tbx_ShInvoice.Text, tbx_TotalTax.Text, tbx_TotalNonTax.Text, tbx_IGST_Total.Text, tbx_SGST_Total.Text, tbx_SGST_Total.Text, tbx_TotalAmt.Text, tbx_GrandTotal.Text, "", ddl_CurrencyType.SelectedValue, tbx_CurrValue.Text, "", ddl_SalesRep.Text, tbx_Advance.Text, Balance_Total.ToString(), Convert.ToString(Session["LoginName"]), Convert.ToString(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss")), lbl_Month.Text, "", "Debit Note", "");
                        if (value == true)
                        {
                            lbl_Status.ForeColor = System.Drawing.Color.Green; lbl_Status.Text = "Save Success";
                            ImBtn_PDF.Visible = true; 
                        }
                        else { lbl_Status.ForeColor = System.Drawing.Color.Red; lbl_Status.Text = "Record Not Save!"; }
                    }
                    else { lbl_Status.ForeColor = System.Drawing.Color.Red; lbl_Status.Text = "Please Enter Invoice Bill No/Month!"; }
                }
                else { lbl_Status.ForeColor = System.Drawing.Color.Red; lbl_Status.Text = "Please Check Invoice Bill No. /Job No!"; }
            }
            catch (Exception ex)
            { lbl_Status.ForeColor = System.Drawing.Color.Red; lbl_Status.Text = ex.Message; }
        }

        private void Update_BillNo()
        {
            try
            {
                lbl_Status.Text = string.Empty;
                if ((ddl_Category.SelectedValue != Global.Select_Default))
                {
                    if (!string.IsNullOrEmpty(tbx_BillNo.Text))
                    {
                        decimal Balance_Total = Convert.ToDecimal(tbx_GrandTotal.Text) - Convert.ToDecimal(tbx_Advance.Text);
                        value = obj_admin.Invoice_Update(Convert.ToString(Session["CompanyCode"]), ddl_Category.SelectedValue, tbx_JobNo.Text, tbx_BillNo.Text, tbx_BillDate.Text, tbx_InvToL1.Text, tbx_InvToL2.Text, tbx_InvToL3.Text, tbx_InvToL4.Text, tbx_InvToL5.Text, tbx_GurL1.Text, tbx_GurL2.Text, tbx_GurL3.Text, tbx_GurL4.Text, tbx_GSTNoCust.Text, tbx_StateCust.Text, tbx_StateCodeCust.Text, "", tbx_Shipper.Text, "", tbx_AWB_No.Text, tbx_HAWB_No.Text, tbx_SBNo.Text, tbx_SBDate.Text, tbx_Line.Text, tbx_EGM.Text, tbx_CBM.Text, tbx_Origin.Text, tbx_Dest.Text, "", tbx_Pkgs.Text, tbx_GW.Text, tbx_Volume.Text, tbx_ShInvoice.Text, tbx_TotalTax.Text, tbx_TotalNonTax.Text, tbx_IGST_Total.Text, tbx_SGST_Total.Text, tbx_SGST_Total.Text, tbx_TotalAmt.Text, tbx_GrandTotal.Text, "", ddl_CurrencyType.SelectedValue, tbx_CurrValue.Text, "", ddl_SalesRep.Text, tbx_Advance.Text, Balance_Total.ToString(), Convert.ToString(Session["LoginName"]), Convert.ToString(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss")), lbl_Month.Text, "", "Debit Note", "");
                        if (value == true)
                        {
                            lbl_Status.ForeColor = System.Drawing.Color.Green; lbl_Status.Text = "Update Success";
                            ImBtn_PDF.Visible = true; Btn_Delete.Visible = true;
                        }
                        else { lbl_Status.ForeColor = System.Drawing.Color.Red; lbl_Status.Text = "Record Not Update!"; }
                    }
                    else { lbl_Status.ForeColor = System.Drawing.Color.Red; lbl_Status.Text = "Please Enter Invoice Bill No!"; }
                }
                else { lbl_Status.ForeColor = System.Drawing.Color.Red; lbl_Status.Text = "Please Check Invoice Bill No. /Job No!"; }
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
                    if ((ddl_Category.SelectedValue != Global.Select_Default))
                    {
                        if (!string.IsNullOrEmpty(tbx_BillNo.Text))
                        {
                            value = obj_admin.Invoice_Delete(Convert.ToString(Session["CompanyCode"]), tbx_BillNo.Text, "Debit Note");
                            if (value == true)
                            {
                                value = obj_admin.CustInvParticulars_DeleteAll(Convert.ToString(Session["CompanyCode"]), tbx_BillNo.Text, "Debit Note"); Clear(); Particulars_Load(); FillEmptyGrid(); ImBtn_PDF.Visible = false;
                                lbl_Status.ForeColor = System.Drawing.Color.Green; lbl_Status.Text = tbx_BillNo.Text + " Delete Success";
                            }
                            else { lbl_Status.ForeColor = System.Drawing.Color.Red; lbl_Status.Text = "Record Not Delete!"; }
                        }
                        else { lbl_Status.ForeColor = System.Drawing.Color.Red; lbl_Status.Text = "Please Enter Invoice Bill No!"; }
                    }
                    else { lbl_Status.ForeColor = System.Drawing.Color.Red; lbl_Status.Text = "Please Check Job Category!"; }
                }
                else { lbl_Status.ForeColor = System.Drawing.Color.Red; lbl_Status.Text = "Invoice not delete!"; }
            }
            catch (Exception ex)
            { lbl_Status.ForeColor = System.Drawing.Color.Red; lbl_Status.Text = ex.Message; }
        }
        
        protected void Btn_IRN_Click(object sender, EventArgs e)
        {
            try
            {
                lbl_Status.Text = string.Empty;
                string confirmValue = Request.Form["confirm_value"];
                if (confirmValue == "Yes")
                {
                        if (!string.IsNullOrEmpty(tbx_BillNo.Text))
                        {
                            EInvoiceAPI eInvoiceAPI = new EInvoiceAPI();
                            //value = eInvoiceAPI.GenerateIRNFromTaxPro2(
                                
                           // response = eInvoiceAPI.GenerateIRNFromTaxPro();                            
                           if (value == true)
                            {
                               lbl_Status.ForeColor = System.Drawing.Color.Green; lbl_Status.Text = tbx_BillNo.Text + " IRN Generate Success";
                            }
                            else { lbl_Status.ForeColor = System.Drawing.Color.Red; lbl_Status.Text = "IRN Not Generated !"; }
                        }
                        else { lbl_Status.ForeColor = System.Drawing.Color.Red; lbl_Status.Text = "Please Enter Invoice Bill No!"; }
                    }
                else { lbl_Status.ForeColor = System.Drawing.Color.Red; lbl_Status.Text = "IRN Not Generated !"; }
            }
            catch (Exception ex)
            { lbl_Status.ForeColor = System.Drawing.Color.Red; lbl_Status.Text = ex.Message; }
        }

        protected void ImBtn_PDF_Click(object sender, ImageClickEventArgs e)
        {
            if (!string.IsNullOrEmpty(tbx_BillNo.Text))
            {
                string Signature = "no";
                if (ddl_Signature.Text == "Manual Signature") { Signature = "msge"; }
                else if (ddl_Signature.Text == "E-Signature") { Signature = "esge"; }

                //string js = "javascript:openFile('" + "InvoiceNew.aspx?ien=" + tbx_BillNo.Text + "')";
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop up", js, true);
                string BillNo = HttpUtility.UrlEncode(Encrypt(tbx_BillNo.Text.Trim()));
                string JobNo = HttpUtility.UrlEncode(Encrypt("0011"));//ddl_JobNumber.SelectedValue.Trim()));
                StringBuilder sb = new StringBuilder();
                sb.Append("<script type = 'text/javascript'>");
                sb.Append("window.open('");
                sb.Append("InvoiceNew.aspx?hkh=eorgnveorwmvpe7p0cff4jhgig3nrg&pjl=uietrnfsvhgag6k812fd0mmv23jkjd5idaawdnsgb&ien=" + tbx_BillNo.Text + "&qepasd=nsdbjd9we3wemldfwoiefutcvjhr3rdvchdfuewheewc7qgt6lehqe&fs=" + ddl_BankName.Text + "&hwkf=lkqxqvhdqwu5wef56wfwd&sge=" + Signature); //BillNo);
                sb.Append("');");
                sb.Append("</script>");
                ClientScript.RegisterStartupScript(this.GetType(), "script", sb.ToString());
            }
            else { lbl_Status.ForeColor = System.Drawing.Color.Red; lbl_Status.Text = "Please Enter Bill No!"; }
        }

        public static string Encrypt(string inputText)
        {
            string encryptionkey = "SAUW193BX628TD57";
            byte[] keybytes = Encoding.ASCII.GetBytes(encryptionkey.Length.ToString());
            RijndaelManaged rijndaelCipher = new RijndaelManaged();
            byte[] plainText = Encoding.Unicode.GetBytes(inputText);
            PasswordDeriveBytes pwdbytes = new PasswordDeriveBytes(encryptionkey, keybytes);
            using (ICryptoTransform encryptrans = rijndaelCipher.CreateEncryptor(pwdbytes.GetBytes(32), pwdbytes.GetBytes(16)))
            {
                using (MemoryStream mstrm = new MemoryStream())
                {
                    using (CryptoStream cryptstm = new CryptoStream(mstrm, encryptrans, CryptoStreamMode.Write))
                    {
                        cryptstm.Write(plainText, 0, plainText.Length);
                        cryptstm.Close();
                        return Convert.ToBase64String(mstrm.ToArray());
                    }
                }
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }

        private void Logout()
        {
            Session.Clear();
            Session.Abandon();
            Session.RemoveAll();

            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();

            // Response.ClearHeaders();
            // Response.AddHeader("Cache-Control", "no-cache, no-store, max-age=0, must-revalidate");
            // Response.AddHeader("Pragma", "no-cache");

            Session["UN"] = string.Empty;
            Session["URL"] = string.Empty;
            Session["CompanyName"] = string.Empty;
            Session["CompanyCode"] = string.Empty;
            Session["CompanyName"] = string.Empty;
            Session["JobNumber"] = string.Empty;

            Response.Redirect("Default.aspx");
        }

        protected void ddl_ClientName_SelectedIndexChanged(object sender, EventArgs e)
        {
            var ClientAddress = (from dr in Global._getDT_Client.AsEnumerable()
                                 where (dr.Field<string>("CompName") == ddl_ClientName.SelectedItem.ToString())
                                 select new
                                 {
                                     CompName = dr.Field<string>("CompName"),
                                     Line2 = dr.Field<string>("Line2"),
                                     Line3 = dr.Field<string>("Line3"),
                                     Line4 = dr.Field<string>("Line4"),
                                     Line5 = dr.Field<string>("Line5"),
                                     State = dr.Field<string>("State"),
                                     StateCode = dr.Field<string>("StateCode"),
                                     GSTNo = dr.Field<string>("GSTNo")
                                 }).FirstOrDefault();

            tbx_InvToL1.Text = ClientAddress.CompName;
            tbx_InvToL2.Text = ClientAddress.Line2;
            tbx_InvToL3.Text = ClientAddress.Line3;
            tbx_InvToL4.Text = ClientAddress.Line4;
            tbx_InvToL5.Text = ClientAddress.Line5;
            tbx_StateCodeCust.Text = ClientAddress.StateCode;
            tbx_StateCust.Text = ClientAddress.State;
            tbx_GSTNoCust.Text = ClientAddress.GSTNo;
        }

        private void Load_Client_Shiiper_Consignee()
        {
            try
            {
                DataTable dt_UserList = new DataTable();
                dt = new DataTable();
                dr = obj_admin.SC_AllUsers(Session["CompanyCode"].ToString());
                dt_UserList.Load(dr); dt = dt_UserList;

                Global._getDT_Client = (from DataRow drS in dt_UserList.Rows
                                        where drS["Type"].ToString() == "Invoice Address"
                                        select drS).CopyToDataTable();
                ddl_ClientName.DataSource = Global._getDT_Client;

                //dr = obj_admin.Client_CompanyName_Category(Session["CompanyCode"].ToString()); dt.Load(dr);
                ddl_ClientName.DataTextField = dt.Columns["CompName"].ToString();//CompanyName
                ddl_ClientName.DataValueField = dt.Columns["Line2"].ColumnName;
                ddl_ClientName.DataBind();
                ddl_ClientName.Items.Insert(0, Global.Select_Default);

                dt = new DataTable();
                dt = (from DataRow drS in dt_UserList.Rows
                      where drS["Type"].ToString() == "Shipper"
                      select drS).CopyToDataTable();
                ddl_Shipper.DataSource = dt;
                ddl_Shipper.DataTextField = dt.Columns["CompName"].ToString();//CompanyName
                ddl_Shipper.DataValueField = dt.Columns["CompName"].ColumnName;
                ddl_Shipper.DataBind();
                ddl_Shipper.Items.Insert(0, Global.Select_Default);
            }
            catch (Exception ex)
            { ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Key", "alert('" + ex.Message + "');", true); }
        }
        private void JobNo_Load()
        {
            try
            {
                dt = new DataTable();
                dr = obj_admin.Expense_Invoice(Session["CompanyCode"].ToString());
                dt.Load(dr);
                ddl_JobNo.DataSource = dt;
                ddl_JobNo.DataTextField = dt.Columns["JobNo"].ToString();//CompanyName
                ddl_JobNo.DataValueField = dt.Columns["JobNo"].ColumnName;
                ddl_JobNo.DataBind();
                ddl_JobNo.Items.Insert(0, Global.Select_Default);
            }
            catch (Exception ex)
            { ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Key", "alert('" + ex.Message + "');", true); }
        }

        protected void ddl_Shipper_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_Shipper.SelectedIndex != 0)
            { tbx_Shipper.Text = ddl_Shipper.Text; }
        }

        protected void cmb_Particulars_SelectedIndexChanged(object sender, EventArgs e)
        {
            //lbl_Particulars.Text = cmb_Particulars.SelectedItem.Text; 
        }
        
        protected void ddl_JobNo_SelectedIndexChanged1(object sender, EventArgs e)
        {
            try
            {
                if (ddl_JobNo.SelectedIndex != 0)
                {
                    dr = obj_admin.Job_Expense(Session["CompanyCode"].ToString(), ddl_JobNo.Text);
                    dt = new DataTable();
                    dt.Load(dr);
                    if (dt.Rows.Count != 0)
                    {
                        tbx_Shipper.Text = dt.Rows[0]["Shipper"].ToString();
                        tbx_AWB_No.Text = dt.Rows[0]["AWBNo"].ToString();
                    }
                    tbx_JobNo.Text = tbx_BillNo.Text = ddl_JobNo.Text;
                    tbx_BillDate.Text = Convert.ToString(DateTime.Now.ToString("dd-MMM-yyyy"));
                    lbl_Month.Text = Convert.ToString(DateTime.Now.ToString("MMM-yyyy"));
                }
            }
            catch (Exception ex)
            { ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Key", "alert('" + ex.Message + "');", true); }
        }

        protected void tbx_BillDate_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbx_BillDate.Text))
            { lbl_Month.Text = (tbx_BillDate.Text).Substring(3); }
        }
    }
}
