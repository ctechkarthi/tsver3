using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using TSVer3.BL;
using System.Data.OleDb;
using System.IO;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Collections.Generic;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.html;

namespace TSVer3
{
    public partial class ExpensePDF : System.Web.UI.Page
    {
        #region class
        BusLayer obj_admin = new BusLayer();
        SqlDataReader dr = null;
        DataTable dt_ExPart = new DataTable();
        string JobNo = string.Empty;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
           // Session["CompanyCode"] = "CSHBLR"; JobNo = "CSHLAI202100761";
            JobNo = Request.QueryString["ien"];
            if (!string.IsNullOrEmpty(JobNo))
            {
                PDF();
            }
            else { Logout(); }
        }
             
        private void PDF()
        {
            DataTable dt = new DataTable();
            int SNO = 0;
            string htmlStr1 = "", htmlStr2 = ""; string htmlStr3 = "";
            string HeadTbl = "<table border='0' style=' font-size: 12px;'>" +
"<tr><td align='center' colspan='4' ><b>C.S HAWKLER LOGISTICS PVT LTD <br/> 'ANIRUDDH' No.6, 1st Cross, 6th Main, Kamadhenu Layout, <br/> B Narayanapura, Doorvarni Nagar(post), Bangalore-560 048, India." +
" <br/> Tele : 080-8904056651, Email : accounts.blr@cshawkler.com <br/>  <br/>Expense/Cost Sheet<br/> </b></td></tr></table>";

            dr = obj_admin.Job_ExpenseBillAll(Convert.ToString(Session["CompanyCode"]), JobNo);
            dt.Load(dr);

            DataTable dt_Inv = new DataTable();
            dr = obj_admin.Invoice_Search_JobNo_(Convert.ToString(Session["CompanyCode"]), JobNo, "Debit Note");
            dt_Inv.Load(dr);

            htmlStr1 = "Job No   : " + dt.Rows[0]["JobNo"].ToString() + " AWB/BL  : " + dt.Rows[0]["AWBNo"].ToString() + "<br/>Customer : " + dt.Rows[0]["Shipper"].ToString() + "<br/><br/>";

            htmlStr1 += "<table border='1' style=' font-size: 8px;'><tr>" +
            "<td colspan='2' align='center' ><strong>SNo.</strong></td>" +
            "<td colspan='6' align='center' ><strong>Expense Name</strong></td>" +
            "<td colspan='6' align='center' ><strong>Particulars</strong></td>" +
            "<td colspan='4' align='center' ><strong>Amount</strong></td></tr>" +

            " <tr> <td colspan='2' align='center'>1</td>" +
    "<td colspan='6' align='center'>Customs Expenses</td>" +
    "<td colspan='6' align='center'>" + dt.Rows[0]["CustExp"].ToString() + "</td>" +
    "<td colspan='4' align='right'>" + dt.Rows[0]["CustExpAmt"].ToString() + "</td>" +

    "</tr> <tr> <td colspan='2' align='center'>2</td>" +
    "<td colspan='6' align='center'>ADC Charges</td>" +
    "<td colspan='6' align='center'>" + dt.Rows[0]["ADCCrgs"].ToString() + "</td>" +
    "<td colspan='4' align='right'>" + dt.Rows[0]["ADCCrgsAmt"].ToString() + "</td>" +

    "</tr> <tr> <td colspan='2' align='center'>3</td>" +
    "<td colspan='6' align='center'>EDI Charges</td>" +
    "<td colspan='6' align='center'>" + dt.Rows[0]["EDICrgs"].ToString() + "</td>" +
    "<td colspan='4' align='right'>" + dt.Rows[0]["EDICrgsAmt"].ToString() + "</td>" +

    "</tr> <tr> <td colspan='2' align='center'>4</td>" +
    "<td colspan='6' align='center'>Loading / Unloading</td>" +
    "<td colspan='6' align='center'>" + dt.Rows[0]["LoadingUnloading"].ToString() + "</td>" +
    "<td colspan='4' align='right'>" + dt.Rows[0]["LoadingUnloadingAmt"].ToString() + "</td>" +

    "</tr> <tr> <td colspan='2' align='center'>5</td>" +
    "<td colspan='6' align='center'>Terminal Charges</td>" +
    "<td colspan='6' align='center'>" + dt.Rows[0]["TerminalCrgs"].ToString() + "</td>" +
    "<td colspan='4' align='right'>" + dt.Rows[0]["TerminalCrgsAmt"].ToString() + "</td>" +

    "</tr> <tr> <td colspan='2' align='center'>6</td>" +
    "<td colspan='6' align='center'>Transportation Charges</td>" +
    "<td colspan='6' align='center'>" + dt.Rows[0]["TransportCrgs"].ToString() + "</td>" +
    "<td colspan='4' align='right'>" + dt.Rows[0]["TransportCrgsAmt"].ToString() + "</td>" +

    "</tr> <tr> <td colspan='2' align='center'>7</td>" +
    "<td colspan='6' align='center'>AIR Freight</td>" +
    "<td colspan='6' align='center'>" + dt.Rows[0]["AIRFreight"].ToString() + "</td>" +
    "<td colspan='4' align='right'>" + dt.Rows[0]["AIRFreightAmt"].ToString() + "</td>" +

    "</tr> <tr> <td colspan='2' align='center'>8</td>" +
    "<td colspan='6' align='center'>FSC</td>" +
    "<td colspan='6' align='center'>" + dt.Rows[0]["FSC"].ToString() + "</td>" +
    "<td colspan='4' align='right'>" + dt.Rows[0]["FSCAmt"].ToString() + "</td>" +

    "</tr> <tr> <td colspan='2' align='center'>9</td>" +
    "<td colspan='6' align='center'>SC</td>" +
    "<td colspan='6' align='center'>" + dt.Rows[0]["SC"].ToString() + "</td>" +
    "<td colspan='4' align='right'>" + dt.Rows[0]["SCAmt"].ToString() + "</td>" +

    "</tr> <tr> <td colspan='2' align='center'>10</td>" +
    "<td colspan='6' align='center'>MCC</td>" +
    "<td colspan='6' align='center'>" + dt.Rows[0]["MCC"].ToString() + "</td>" +
    "<td colspan='4' align='right'>" + dt.Rows[0]["MCCAmt"].ToString() + "</td>" +

    "</tr> <tr> <td colspan='2' align='center'>11</td>" +
    "<td colspan='6' align='center'>X-RAY</td>" +
    "<td colspan='6' align='center'>" + dt.Rows[0]["XRAY"].ToString() + "</td>" +
    "<td colspan='4' align='right'>" + dt.Rows[0]["XRAYAmt"].ToString() + "</td>" +

    "</tr> <tr> <td colspan='2' align='center'>12</td>" +
    "<td colspan='6' align='center'>AMS</td>" +
    "<td colspan='6' align='center'>" + dt.Rows[0]["AMS"].ToString() + "</td>" +
    "<td colspan='4' align='right'>" + dt.Rows[0]["AMSAmt"].ToString() + "</td>" +

    "</tr> <tr> <td colspan='2' align='center'>13</td>" +
    "<td colspan='6' align='center'>DG Fee/DRY ICE Fee</td>" +
    "<td colspan='6' align='center'>" + dt.Rows[0]["DGFee"].ToString() + "</td>" +
    "<td colspan='4' align='right'>" + dt.Rows[0]["DGFeeAmt"].ToString() + "</td>" +

    "</tr> <tr> <td colspan='2' align='center'>14</td>" +
    "<td colspan='6' align='center'>GSP/COO Charges</td>" +
    "<td colspan='6' align='right'>" + dt.Rows[0]["GSPCrgs"].ToString() + "</td>" +
    "<td colspan='4' align='right'>" + dt.Rows[0]["GSPCrgsAmt"].ToString() + "</td>" +

    "</tr> <tr> <td colspan='2' align='center'>15</td>" +
    "<td colspan='6' align='center'>AWB + PCA</td>" +
    "<td colspan='6' align='center'>" + dt.Rows[0]["AWB"].ToString() + "</td>" +
    "<td colspan='4' align='right'>" + dt.Rows[0]["AWBAmt"].ToString() + "</td>" +

    "</tr> <tr> <td colspan='2' align='center'>16</td>" +
    "<td colspan='6' align='center'>MISC Charges</td>" +
    "<td colspan='6' align='center'>" + dt.Rows[0]["MISCCrgs1"].ToString() + "</td>" +
    "<td colspan='4' align='right'>" + dt.Rows[0]["MISCCrgs1Amt"].ToString() + "</td>" +

    "</tr> <tr> <td colspan='2' align='center'>17</td>" +
    "<td colspan='6' align='center'>OT Charges</td>" +
    "<td colspan='6' align='center'>" + dt.Rows[0]["MISCCrgs2"].ToString() + "</td>" +
    "<td colspan='4' align='right'>" + dt.Rows[0]["MISCCrgs2Amt"].ToString() + "</td>" +

    "</tr> <tr> <td colspan='2' align='center'>18</td>" +
    "<td colspan='6' align='center'>Replacement</td>" +
    "<td colspan='6' align='center'>" + dt.Rows[0]["MISCCrgs3"].ToString() + "</td>" +
    "<td colspan='4' align='right'>" + dt.Rows[0]["MISCCrgs3Amt"].ToString() + "</td>" +

    "</tr> <tr> <td colspan='2' align='center'>19</td>" +
    "<td colspan='6' align='center'>Delivery Order</td>" +
    "<td colspan='6' align='center'>" + dt.Rows[0]["DO"].ToString() + "</td>" +
    "<td colspan='4' align='right'>" + dt.Rows[0]["DOAmt"].ToString() + "</td>" +

    "</tr> <tr> <td colspan='2' align='center'>20</td>" +
    "<td colspan='6' align='center'>IHC / LCL Charges</td>" +
    "<td colspan='6' align='center'>" + dt.Rows[0]["IHC"].ToString() + "</td>" +
    "<td colspan='4' align='right'>" + dt.Rows[0]["IHCAmt"].ToString() + "</td>" +

    "</tr> <tr> <td colspan='2' align='center'>21</td>" +
    "<td colspan='6' align='center'>TSA Charges</td>" +
    "<td colspan='6' align='center'>" + dt.Rows[0]["TSA"].ToString() + "</td>" +
    "<td colspan='4' align='right'>" + dt.Rows[0]["TSAAmt"].ToString() + "</td>" +

    "</tr> <tr> <td colspan='2' align='center'>22</td>" +
    "<td colspan='6' align='center'>Stuffing Charges</td>" +
    "<td colspan='6' align='center'>" + dt.Rows[0]["STUFFING"].ToString() + "</td>" +
    "<td colspan='4' align='right'>" + dt.Rows[0]["STUFFINGAmt"].ToString() + "</td></tr>";

            htmlStr1 += "<tr ><td colspan='14' align='right' >Expense Total Amount Rs.</td><td colspan='4' align='right' >" + dt.Rows[0]["Total"].ToString() + "</td></tr></table>";
            decimal ExpenseTotal = Convert.ToDecimal(dt.Rows[0]["Total"]);
            string htmlStr4 = "<table border='0' style=' font-size: 10px;' ><tr><td>";

            //Profit/Loss 
            decimal PL = 0;
            if (dt_Inv.Rows.Count == 1)
            {
                decimal InvoiceExRate = Convert.ToDecimal(dt_Inv.Rows[0]["ExRate"]);  
                decimal InvoiceTotal_ExGST = Convert.ToDecimal(dt_Inv.Rows[0]["TotalNonTax"]) + Convert.ToDecimal(dt_Inv.Rows[0]["TotalTax"]);  

                htmlStr4 += "<br/> Invoice Currency    : " + dt_Inv.Rows[0]["CurrValue"].ToString() + ", Ex-Rate : " + InvoiceExRate.ToString();
                htmlStr4 += "<br/> Invoice Amount       : " + InvoiceTotal_ExGST.ToString() + " Exclude GST";

                if (dt_Inv.Rows[0]["CurrValue"].ToString() != "INR")
                {
                    decimal InvoiceExRate_R = Math.Round((InvoiceTotal_ExGST * InvoiceExRate), 2);
                    htmlStr4 += "<br/> Invoice INR     : " + InvoiceExRate_R.ToString();
                    InvoiceTotal_ExGST = InvoiceExRate_R;
                }
                PL = InvoiceTotal_ExGST - ExpenseTotal;
                htmlStr4 += "<br/> Profit/Loss      : " + InvoiceTotal_ExGST.ToString() + " - " + ExpenseTotal.ToString() + " = " + PL.ToString();
            }
            else if (dt_Inv.Rows.Count >= 2)            
            {
                decimal TotalBillAmount = 0; decimal TotalGST = 0;
                for (int i = 0; i < dt_Inv.Rows.Count; i++)
                {
                    htmlStr4 += "<br/>BillNo : " + dt_Inv.Rows[i]["BillNo"].ToString();
                    decimal InvoiceExRate = Convert.ToDecimal(dt_Inv.Rows[i]["ExRate"]);  
                    decimal InvoiceTotal_ExGST = Convert.ToDecimal(dt_Inv.Rows[i]["TotalNonTax"]) + Convert.ToDecimal(dt_Inv.Rows[i]["TotalTax"]);
                    InvoiceTotal_ExGST = Math.Round((InvoiceTotal_ExGST), 0);

                    htmlStr4 += ",   Currency : " + dt_Inv.Rows[i]["CurrValue"].ToString() + ", Ex-Rate : " + InvoiceExRate.ToString();

                    if (dt_Inv.Rows[i]["StateCode"].ToString() == "29")
                    { TotalGST += Convert.ToDecimal(dt_Inv.Rows[i]["CGST"]) + Convert.ToDecimal(dt_Inv.Rows[i]["SGST"]); }
                    else { TotalGST += Convert.ToDecimal(dt_Inv.Rows[i]["IGST"]); }

                    decimal InvoiceExRate_R = 0;
                    if (dt_Inv.Rows[i]["CurrValue"].ToString() == "INR")
                    {
                        InvoiceExRate_R = Math.Round((InvoiceTotal_ExGST * InvoiceExRate), 2);
                        InvoiceTotal_ExGST = (InvoiceExRate_R);
                        TotalBillAmount += InvoiceTotal_ExGST;
                    }
                    else 
                    {
                        decimal InvoiceTotal_ExGST_R = Math.Round((InvoiceTotal_ExGST), 2);
                        InvoiceExRate_R = Math.Round((InvoiceTotal_ExGST_R * InvoiceExRate), 2);
                        TotalBillAmount += InvoiceExRate_R;
                    }
                    htmlStr4 += "<br/> Invoice Amount : " + InvoiceTotal_ExGST.ToString() + " Exclude GST,  " + InvoiceTotal_ExGST.ToString() + " * " + InvoiceExRate + " = " + InvoiceExRate_R.ToString() + "<br/> ";
                    PL = TotalBillAmount - ExpenseTotal;
                }
                htmlStr4 += "Profit/Loss : " + PL.ToString();
            }
            htmlStr4 += "</td></tr></table>";
            HTMLToPdf(HeadTbl + htmlStr1 + htmlStr4, "Expense.pdf");
        }


        public void HTMLToPdf(string HTML, string FilePath)
        {
            Document document = new Document();
            PdfWriter.GetInstance(document, new FileStream(Request.PhysicalApplicationPath + "\\Expense.pdf", FileMode.Create));
            document.Open();
            iTextSharp.text.html.simpleparser.StyleSheet styles = new iTextSharp.text.html.simpleparser.StyleSheet();
            styles.LoadStyle("tblparticularstyle", "border-right-style", "solid");
            styles.LoadStyle("tblparticularstyle", "border-left-style", "solid");
            styles.LoadStyle("tblparticularstyle", "border-right-width", "1px");
            styles.LoadStyle("tblparticularstyle", "border-left-width", "1px");
            styles.LoadTagStyle(HtmlTags.HEADERCELL, HtmlTags.BACKGROUNDCOLOR, "Blue");
            iTextSharp.text.html.simpleparser.HTMLWorker hw = new iTextSharp.text.html.simpleparser.HTMLWorker(document);

            hw.Parse(new StringReader(HTML));
            document.Close();
            ShowPdf("Expense.pdf");
        }

        private void ShowPdf(string s)
        {
            Response.ClearContent();
            Response.ClearHeaders();
            Response.AddHeader("Content-Disposition", "inline;filename=" + JobNo + ".pdf"); 
            Response.ContentType = "application/pdf";
            Response.WriteFile(s);
            Response.Flush();
            Response.Clear();
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
    }
}