using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TSVer3.BL;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Drawing;
using System.Text;
using System.Security.Cryptography;
using System.Collections;
using System.Configuration;

namespace TSVer3
{
    public partial class InvoiceCopy : System.Web.UI.Page
    {
        #region class
        SqlConnection con;
        BusLayer obj_admin = new BusLayer();
        SqlDataReader dr = null;
        DataTable dt = new DataTable();
        bool value; string sqlconn;
        #endregion
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            { return; }
        }

        private void BillNo_Load()
        {
            dt = new DataTable(); dr = obj_admin.Invoice_Search_BillNoDistinct(Session["CompanyCode"].ToString(), ddl_Category.Text); dt.Load(dr);
            ddl_BillNo.DataSource = dt;
            ddl_BillNo.DataTextField = "BillNo";
            ddl_BillNo.DataValueField = "BillNo";
            ddl_BillNo.DataBind();
            ddl_BillNo.Items.Insert(0, Global.Select_Default);
        }

        protected void ddl_BillNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            dt = new DataTable();
            dr = obj_admin.Invoice_Search_BillNo(Convert.ToString(Session["CompanyCode"]), ddl_BillNo.Text, "Debit Note");
            dt.Load(dr);
            lbl_JobNo.Text = lbl_NewJobNo.Text = dt.Rows[0]["JobNo"].ToString();
            lbl_BillDate.Text = dt.Rows[0]["BillDate"].ToString();
            lbl_Month.Text = dt.Rows[0]["Month"].ToString();   
            lbl_Customer.Text = dt.Rows[0]["To1"].ToString();            
        }

        protected void Btn_Insert_Click(object sender, EventArgs e)
        {
            try
            {
                lbl_Status.Text = "";
                dt = new DataTable();
                dr = obj_admin.Invoice_Search_BillNo(Convert.ToString(Session["CompanyCode"]), ddl_BillNo.Text, "Debit Note");
                dt.Load(dr); 
                value = obj_admin.Invoice_New(Convert.ToString(Session["CompanyCode"]), dt.Rows[0]["Category"].ToString(), lbl_NewJobNo.Text, tbx_NewBillNo.Text, lbl_BillDate.Text, dt.Rows[0]["To1"].ToString(), dt.Rows[0]["To2"].ToString(), dt.Rows[0]["To3"].ToString(), dt.Rows[0]["To4"].ToString(), dt.Rows[0]["To5"].ToString(), dt.Rows[0]["Guaranteel1"].ToString(), dt.Rows[0]["Guaranteel2"].ToString(), dt.Rows[0]["Guaranteel3"].ToString(), dt.Rows[0]["Guaranteel4"].ToString(), dt.Rows[0]["GSTNo"].ToString(), dt.Rows[0]["State"].ToString(), dt.Rows[0]["StateCode"].ToString(), dt.Rows[0]["PAN"].ToString(), dt.Rows[0]["Shipper"].ToString(), "", dt.Rows[0]["AWBNo"].ToString(), dt.Rows[0]["HAWBNo"].ToString(), dt.Rows[0]["SBNo"].ToString(), dt.Rows[0]["SBDate"].ToString(), dt.Rows[0]["Line"].ToString(), dt.Rows[0]["IGM"].ToString(), dt.Rows[0]["CBM"].ToString(), dt.Rows[0]["Origin"].ToString(), dt.Rows[0]["Dest"].ToString(), "", dt.Rows[0]["Pkgs"].ToString(), dt.Rows[0]["GrWeight"].ToString(), dt.Rows[0]["ChWeight"].ToString(), dt.Rows[0]["ShInvoice"].ToString(), "0", "0", "0", "0", "0", "0", "0", "0", "INR", "1", "", dt.Rows[0]["SalesRep"].ToString(), "0", "0", Convert.ToString(Session["LoginName"]), Convert.ToString(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss")), dt.Rows[0]["Month"].ToString(), dt.Rows[0]["Year"].ToString(), "Debit Note", "");
                if (value == true)
                {
                    lbl_Status.ForeColor = System.Drawing.Color.Green; lbl_Status.Text = "Save Successfully!";
                }
                else { lbl_Status.ForeColor = System.Drawing.Color.Red; lbl_Status.Text = "Record Not Save!"; }
            }
            catch (Exception ex)
            { lbl_Status.ForeColor = System.Drawing.Color.Red; lbl_Status.Text = ex.Message; }
        }

        protected void Btn_Clear_Click(object sender, EventArgs e)
        {
            Response.Redirect("InvoiceCopy.aspx");
        }

        protected void ddl_Category_SelectedIndexChanged(object sender, EventArgs e)
        {
            BillNo_Load(); 
        }

        protected void tbx_NewBillNo_TextChanged(object sender, EventArgs e)
        {
            dt = new DataTable(); lbl_Status.Text = "";
            dr = obj_admin.Invoice_Search_BillNo(Convert.ToString(Session["CompanyCode"]), tbx_NewBillNo.Text, "Debit Note");
            dt.Load(dr);
            if (dt.Rows.Count != 0)
            { Btn_Insert.Visible = false;  lbl_Status.ForeColor = System.Drawing.Color.Red; lbl_Status.Text = "Bill No. already exists!!!"; }
            else { Btn_Insert.Visible = true; }
        }
    }
}