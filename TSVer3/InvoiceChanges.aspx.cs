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
    public partial class InvoiceChanges : System.Web.UI.Page
    {
        #region class
        BusLayer obj_admin = new BusLayer();
        DataTable dt = new DataTable();
        SqlDataReader dr = null;    
      bool value;
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
                if (dr.HasRows)
                {
                    ddl_Month.DataSource = dr;
                    ddl_Month.DataTextField = "Month";
                    ddl_Month.DataValueField = "Month";
                    ddl_Month.DataBind();
                    ddl_Month.Items.Insert(0, Global.Select_Default);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Key", "alert('" + ex.Message + "');", true);
            }
        }

        protected void ddl_Month_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_BillNo();
        }
        private void Load_BillNo()
        {
            if (ddl_Month.SelectedIndex != 0)
            {
              //  dr = obj_admin.Invoice_Search_MonthWiseReport(Convert.ToString(Session["CompanyCode"]), ddl_Month.SelectedValue);
                if (dr.HasRows)
                {
                    ddl_BillNo.DataSource = dr;
                    ddl_BillNo.DataTextField = "BillNo";
                    ddl_BillNo.DataValueField = "BillNo";
                    ddl_BillNo.DataBind();
                    ddl_BillNo.Items.Insert(0, Global.Select_Default);
                }
            }
            else
            {
                  lbl_Status.ForeColor = System.Drawing.Color.Red; lbl_Status.Text = "Invalid Selection";
            }
        }

        protected void ddl_BillNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_InvoiceDetails();
        }
        private void Load_InvoiceDetails()
        {
            if (ddl_BillNo.SelectedIndex != 0)
            {
              //  dr = obj_admin.Invoice_Search_BillNo(Convert.ToString(Session["CompanyCode"]), ddl_BillNo.Text);
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        lbl_JobNo.Text = dr["JobNo"].ToString();
                        lbl_InvTo.Text = dr["CompName"].ToString();
                        lbl_InvDate.Text = dr["BillDate"].ToString();
                        Session["Id"] = (Int32)dr["Id"];
                    }
                }
            }
            else
            {
                lbl_Status.ForeColor = System.Drawing.Color.Red; lbl_Status.Text = "Invalid Selection";
            }
        }

        protected void ddl_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_Type.SelectedItem.Text == "Update")
            {
                Btn_Update.Visible = true; Btn_Delete.Visible = false; tr_InvNo.Visible = true;
            }
            else if (ddl_Type.SelectedItem.Text == "Delete")
            {
                Btn_Update.Visible = false; Btn_Delete.Visible = true; tr_InvNo.Visible = false;
            }
            else 
            {
                Btn_Update.Visible = false; Btn_Delete.Visible = false;
            }
        }

        protected void Btn_Update_Click(object sender, EventArgs e)
        {
            lbl_Status.Text = "";
            string confirmValue = Request.Form["confirm_valueUpdate"];
            if (confirmValue == "Yes")
            {
                if ((ddl_Month.SelectedIndex != 0) && (ddl_BillNo.SelectedIndex != 0))
                {
                    if (!string.IsNullOrEmpty(tbx_NewInvNo.Text))
                    {
                      //  dr = obj_admin.Invoice_Search_BillNo(Session["CompanyCode"].ToString(), tbx_NewInvNo.Text);
                        if (dr.HasRows)
                        { ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Key", "alert('Bill Number already exists! Please choose another Bill No.');", true); }
                        else
                        {
                            value = obj_admin.Invoice_UpdateBillNo(Convert.ToString(Session["CompanyCode"]), Convert.ToInt32(Session["Id"]), tbx_NewInvNo.Text);
                            if (value == true)
                            {
                                value = obj_admin.Invoice_UpdateBillNoParti(Convert.ToString(Session["CompanyCode"]), ddl_BillNo.SelectedValue, tbx_NewInvNo.Text);
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Key", "alert('Update Successfully!');", true);
                                lbl_Status.ForeColor = System.Drawing.Color.Green; lbl_Status.Text = "Update Successfully!";
                                Load_BillNo();
                            }
                            else { lbl_Status.ForeColor = System.Drawing.Color.Red; lbl_Status.Text = "Record Not Update!"; }
                        } 
                    }
                    else { lbl_Status.ForeColor = System.Drawing.Color.Red; lbl_Status.Text = "Enter New Invoice Number!"; }
                }
                else { lbl_Status.ForeColor = System.Drawing.Color.Red; lbl_Status.Text = "Invalid Selection!"; }
            }
        }
        protected void Btn_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                lbl_Status.Text = "";
                string confirmValue = Request.Form["confirm_value"];
                if (confirmValue == "Yes")
                {
                    if ((ddl_Month.SelectedIndex != 0) && (ddl_BillNo.SelectedIndex != 0))
                    {
                      //  value = obj_admin.Invoice_Delete(Convert.ToString(Session["CompanyCode"]), ddl_BillNo.SelectedValue);
                        if (value == true)
                        {
                        //    value = obj_admin.InvParticulars_Delete_Bill(Convert.ToString(Session["CompanyCode"]), ddl_BillNo.SelectedValue);
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Key", "alert('Delete Successfully!');", true);
                            lbl_Status.ForeColor = System.Drawing.Color.Green; lbl_Status.Text = "Delete Successfully!";
                            Load_BillNo();
                        }
                        else { lbl_Status.ForeColor = System.Drawing.Color.Red; lbl_Status.Text = "Record Not Delete!"; }
                    }
                    else { lbl_Status.ForeColor = System.Drawing.Color.Red; lbl_Status.Text = "Invalid Selection!"; }
                }
            }
            catch (Exception ex)
            { lbl_Status.ForeColor = System.Drawing.Color.Red; lbl_Status.Text = ex.Message; }
        }
    }
}