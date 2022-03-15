using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using TSVer3.BL;
using PdfSharp.Drawing;
using System.Web.UI.WebControls;
using PdfSharp.Drawing.Layout;
using System.Xml;
using System.Net;
using System.Data.SqlClient;
using System.Text;
using System.Security.Cryptography;

namespace TSVer3
{
    public partial class ExpensePDF1 : System.Web.UI.Page
    {
        #region class
        BusLayer obj_admin = new BusLayer();
        SqlDataReader dr = null; DataTable dt = new DataTable();
        string JobNo = string.Empty;
        string JQ = string.Empty;
        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["CompanyCode"] = "CSHBLR";
            //Session["JobNumber"] = "001"; JobNo = "CSHLAI202100676";// Session["JobNumber"].ToString();
            JobNo = Request.QueryString["ien"];
            Expense_PDF();
        }

        private void Expense_PDF()
        {
            DataTable dt = new DataTable();
            dr = obj_admin.Job_ExpenseBillAll(Convert.ToString(Session["CompanyCode"]), JobNo);
            dt.Load(dr);

            DataTable dt_Inv = new DataTable();
            dr = obj_admin.Invoice_Search_JobNo_(Convert.ToString(Session["CompanyCode"]), JobNo, "Debit Note");
            dt_Inv.Load(dr);

            if (dt.Rows.Count != 0)
            {
                PdfSharp.Pdf.PdfDocument pdf = new PdfSharp.Pdf.PdfDocument();
                {
                    PdfSharp.Pdf.PdfPage pdfPage = pdf.AddPage();
                    XGraphics graph = XGraphics.FromPdfPage(pdfPage);
                    //graph.DrawImage(XImage.FromFile(Server.MapPath("expense.jpg")), 0, -18);

                    //XImage image_logo = XImage.FromFile(Server.MapPath("logo_csh2.JPG"));
                    //graph.DrawImage(image_logo, 32, 10, 60, 70);
                                        
                    XImage image_exp = XImage.FromFile("expense.jpg");

                    graph.DrawImage(image_exp, 50, 135, 500, 470);
                    XTextFormatter tf = new XTextFormatter(graph);

                    XFont font6 = new XFont("Verdana", 6, XFontStyle.Regular);
                    XFont font6i = new XFont("Verdana", 6, XFontStyle.Italic);
                    XFont font6b = new XFont("Verdana", 6, XFontStyle.Bold);
                    XFont font7 = new XFont("Verdana", 7, XFontStyle.Regular);
                    XFont font7b = new XFont("Verdana", 7, XFontStyle.Bold);
                    XFont font8 = new XFont("Verdana", 8, XFontStyle.Regular);
                    XFont font8b = new XFont("Verdana", 8, XFontStyle.Bold);
                    XFont font8bi = new XFont("Verdana", 8, XFontStyle.BoldItalic);
                    XFont font9 = new XFont("Verdana", 9, XFontStyle.Regular);
                    XFont font9b = new XFont("Verdana", 9, XFontStyle.Bold);
                    XFont font10b = new XFont("Verdana", 10, XFontStyle.Bold);
                    XFont font10 = new XFont("Verdana", 10, XFontStyle.Regular);
                    XFont font14 = new XFont("Verdana", 14, XFontStyle.Bold);

                    graph.DrawString("C.S HAWKLER LOGISTICS PVT LTD", font14, XBrushes.Black, new XRect(18, 14, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopCenter);
                    graph.DrawString("'ANIRUDDH' No.6, 1st Cross, 6th Main, Kamadhenu Layout,", font10b, XBrushes.Black, new XRect(5, 33, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopCenter);
                    graph.DrawString("B Narayanapura, Doorvarni Nagar(post), Bangalore-560 048, India.", font10b, XBrushes.Black, new XRect(5, 45, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopCenter);
                    graph.DrawString("Tele : 080-89040566/51/52, Email : accounts.blr@cshawkler.com", font8b, XBrushes.Black, new XRect(5, 57, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopCenter);
                    graph.DrawString("STATE CODE : 29, GST NO : 29AAGCC3874M1Z1, PAN NO : AAGCC3874M", font8b, XBrushes.Black, new XRect(30, 67, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopCenter);
                    //graph.DrawString("CIN NO. U74900KA2016PTC086558", font8b, XBrushes.Black, new XRect(30, 77, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopCenter);

                    graph.DrawString("Job Expense Sheet", font10b, XBrushes.Black, new XRect(30, 85, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopCenter);

                    // Invoice No.
                    graph.DrawString("Job No   : " + dt.Rows[0]["JobNo"].ToString(), font8b, XBrushes.Black, new XRect(62, 105, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString("AWB/BL  : " + dt.Rows[0]["AWBNo"].ToString(), font8, XBrushes.Black, new XRect(62, 115, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString("Customer : " + dt.Rows[0]["Shipper"].ToString(), font8, XBrushes.Black, new XRect(315, 105, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

                    // Particulars Header
                    graph.DrawString("S.No", font9b, XBrushes.Black, new XRect(62, 147, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString("Expense Name", font9b, XBrushes.Black, new XRect(150, 147, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString("Particulars", font9b, XBrushes.Black, new XRect(350, 147, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString("Amount", font9b, XBrushes.Black, new XRect(500, 147, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

                    graph.DrawString("1", font7, XBrushes.Black, new XRect(70, 169, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString("Customs Expenses", font7, XBrushes.Black, new XRect(105, 169, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString(dt.Rows[0]["CustExp"].ToString(), font7, XBrushes.Black, new XRect(240, 169, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString(dt.Rows[0]["CustExpAmt"].ToString(), font7, XBrushes.Black, new XRect(490, 169, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

                    graph.DrawString("2", font7, XBrushes.Black, new XRect(70, 188, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString("ADC Charges", font7, XBrushes.Black, new XRect(105, 188, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString(dt.Rows[0]["ADCCrgs"].ToString(), font7, XBrushes.Black, new XRect(240, 188, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString(dt.Rows[0]["ADCCrgsAmt"].ToString(), font7, XBrushes.Black, new XRect(490, 188, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

                    graph.DrawString("3", font7, XBrushes.Black, new XRect(70, 207, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString("EDI Charges", font7, XBrushes.Black, new XRect(105, 207, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString(dt.Rows[0]["EDICrgs"].ToString(), font7, XBrushes.Black, new XRect(240, 207, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString(dt.Rows[0]["EDICrgsAmt"].ToString(), font7, XBrushes.Black, new XRect(490, 207, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

                    graph.DrawString("4", font7, XBrushes.Black, new XRect(70, 226, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString("Loading / Unloading", font7, XBrushes.Black, new XRect(105, 226, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString(dt.Rows[0]["LoadingUnloading"].ToString(), font7, XBrushes.Black, new XRect(240, 226, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString(dt.Rows[0]["LoadingUnloadingAmt"].ToString(), font7, XBrushes.Black, new XRect(490, 226, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

                    graph.DrawString("5", font7, XBrushes.Black, new XRect(70, 245, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString("Terminal Charges", font7, XBrushes.Black, new XRect(105, 245, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString(dt.Rows[0]["TerminalCrgs"].ToString(), font7, XBrushes.Black, new XRect(240, 245, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString(dt.Rows[0]["TerminalCrgsAmt"].ToString(), font7, XBrushes.Black, new XRect(490, 245, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

                    graph.DrawString("6", font7, XBrushes.Black, new XRect(70, 264, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString("Transportation Charges", font7, XBrushes.Black, new XRect(105, 264, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString(dt.Rows[0]["TransportCrgs"].ToString(), font7, XBrushes.Black, new XRect(240, 264, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString(dt.Rows[0]["TransportCrgsAmt"].ToString(), font7, XBrushes.Black, new XRect(490, 264, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

                    graph.DrawString("7", font7, XBrushes.Black, new XRect(70, 283, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString("AIR Freight", font7, XBrushes.Black, new XRect(105, 283, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString(dt.Rows[0]["AIRFreight"].ToString(), font7, XBrushes.Black, new XRect(240, 283, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString(dt.Rows[0]["AIRFreightAmt"].ToString(), font7, XBrushes.Black, new XRect(490, 283, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

                    graph.DrawString("8", font7, XBrushes.Black, new XRect(70, 302, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString("FSC", font7, XBrushes.Black, new XRect(105, 302, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString(dt.Rows[0]["FSC"].ToString(), font7, XBrushes.Black, new XRect(240, 302, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString(dt.Rows[0]["FSCAmt"].ToString(), font7, XBrushes.Black, new XRect(490, 302, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

                    graph.DrawString("9", font7, XBrushes.Black, new XRect(70, 321, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString("SC", font7, XBrushes.Black, new XRect(105, 321, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString(dt.Rows[0]["SC"].ToString(), font7, XBrushes.Black, new XRect(240, 321, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString(dt.Rows[0]["SCAmt"].ToString(), font7, XBrushes.Black, new XRect(490, 321, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

                    graph.DrawString("10", font7, XBrushes.Black, new XRect(70, 340, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString("MCC", font7, XBrushes.Black, new XRect(105, 340, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString(dt.Rows[0]["MCC"].ToString(), font7, XBrushes.Black, new XRect(240, 340, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString(dt.Rows[0]["MCCAmt"].ToString(), font7, XBrushes.Black, new XRect(490, 340, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

                    graph.DrawString("11", font7, XBrushes.Black, new XRect(70, 359, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString("X-RAY", font7, XBrushes.Black, new XRect(105, 359, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString(dt.Rows[0]["XRAY"].ToString(), font7, XBrushes.Black, new XRect(240, 359, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString(dt.Rows[0]["XRAYAmt"].ToString(), font7, XBrushes.Black, new XRect(490, 359, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

                    graph.DrawString("12", font7, XBrushes.Black, new XRect(70, 378, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString("AMS", font7, XBrushes.Black, new XRect(105, 378, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString(dt.Rows[0]["AMS"].ToString(), font7, XBrushes.Black, new XRect(240, 378, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString(dt.Rows[0]["AMSAmt"].ToString(), font7, XBrushes.Black, new XRect(490, 378, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

                    graph.DrawString("13", font7, XBrushes.Black, new XRect(70, 397, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString("DG Fee/DRY ICE Fee", font7, XBrushes.Black, new XRect(105, 397, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString(dt.Rows[0]["DGFee"].ToString(), font7, XBrushes.Black, new XRect(240, 397, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString(dt.Rows[0]["DGFeeAmt"].ToString(), font7, XBrushes.Black, new XRect(490, 397, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

                    graph.DrawString("14", font7, XBrushes.Black, new XRect(70, 416, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString("GSP/COO Charges", font7, XBrushes.Black, new XRect(105, 416, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString(dt.Rows[0]["GSPCrgs"].ToString(), font7, XBrushes.Black, new XRect(240, 416, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString(dt.Rows[0]["GSPCrgsAmt"].ToString(), font7, XBrushes.Black, new XRect(490, 416, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

                    graph.DrawString("15", font7, XBrushes.Black, new XRect(70, 435, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString("AWB + PCA", font7, XBrushes.Black, new XRect(105, 435, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString(dt.Rows[0]["AWB"].ToString(), font7, XBrushes.Black, new XRect(240, 435, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString(dt.Rows[0]["AWBAmt"].ToString(), font7, XBrushes.Black, new XRect(490, 435, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

                    graph.DrawString("16", font7, XBrushes.Black, new XRect(70, 454, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString("MISC Charges", font7, XBrushes.Black, new XRect(105, 454, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString(dt.Rows[0]["MISCCrgs1"].ToString(), font7, XBrushes.Black, new XRect(240, 454, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString(dt.Rows[0]["MISCCrgs1Amt"].ToString(), font7, XBrushes.Black, new XRect(490, 454, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

                    graph.DrawString("17", font7, XBrushes.Black, new XRect(70, 473, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString("OT Charges", font7, XBrushes.Black, new XRect(105, 473, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString(dt.Rows[0]["MISCCrgs2"].ToString(), font7, XBrushes.Black, new XRect(240, 473, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString(dt.Rows[0]["MISCCrgs2Amt"].ToString(), font7, XBrushes.Black, new XRect(490, 473, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

                    graph.DrawString("18", font7, XBrushes.Black, new XRect(70, 492, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString("Replacement", font7, XBrushes.Black, new XRect(105, 492, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString(dt.Rows[0]["MISCCrgs3"].ToString(), font7, XBrushes.Black, new XRect(240, 492, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString(dt.Rows[0]["MISCCrgs3Amt"].ToString(), font7, XBrushes.Black, new XRect(490, 492, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

                    graph.DrawString("19", font7, XBrushes.Black, new XRect(70, 511, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString("Delivery Order", font7, XBrushes.Black, new XRect(105, 511, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString(dt.Rows[0]["DO"].ToString(), font7, XBrushes.Black, new XRect(240, 511, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString(dt.Rows[0]["DOAmt"].ToString(), font7, XBrushes.Black, new XRect(490, 511, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

                    graph.DrawString("20", font7, XBrushes.Black, new XRect(70, 530, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString("IHC / LCL Charges", font7, XBrushes.Black, new XRect(105, 530, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString(dt.Rows[0]["IHC"].ToString(), font7, XBrushes.Black, new XRect(240, 530, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString(dt.Rows[0]["IHCAmt"].ToString(), font7, XBrushes.Black, new XRect(490, 530, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

                    graph.DrawString("21", font7, XBrushes.Black, new XRect(70, 549, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString("TSA Charges", font7, XBrushes.Black, new XRect(105, 549, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString(dt.Rows[0]["TSA"].ToString(), font7, XBrushes.Black, new XRect(240, 549, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString(dt.Rows[0]["TSAAmt"].ToString(), font7, XBrushes.Black, new XRect(490, 549, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

                    graph.DrawString("22", font7, XBrushes.Black, new XRect(70, 568, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString("Stuffing Charges", font7, XBrushes.Black, new XRect(105, 568, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString(dt.Rows[0]["STUFFING"].ToString(), font7, XBrushes.Black, new XRect(240, 568, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString(dt.Rows[0]["STUFFINGAmt"].ToString(), font7, XBrushes.Black, new XRect(490, 568, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

                    //graph.DrawString("23", font7, XBrushes.Black, new XRect(70, 587, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    //graph.DrawString("", font7, XBrushes.Black, new XRect(105, 587, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    //graph.DrawString(dt.Rows[0]["Others"].ToString(), font7, XBrushes.Black, new XRect(240, 587, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    //graph.DrawString(dt.Rows[0]["Others"].ToString(), font7, XBrushes.Black, new XRect(490, 587, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

                    // Total
                    graph.DrawString("Expense Total Amount Rs.", font9, XBrushes.Black, new XRect(350, 584, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString(dt.Rows[0]["Total"].ToString(), font9b, XBrushes.Black, new XRect(484, 584, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

                    decimal ExpenseTotal = Convert.ToDecimal(dt.Rows[0]["Total"]);

                    //Profit/Loss 
                    decimal PL = 0;
                    if (dt_Inv.Rows.Count == 1)
                    {
                        decimal InvoiceExRate = Convert.ToDecimal(dt_Inv.Rows[0]["ExRate"]); //_getDTInvoice.Rows[0]["ExRate"].ToString();
                        decimal InvoiceTotal_ExGST = Convert.ToDecimal(dt_Inv.Rows[0]["TotalNonTax"]) + Convert.ToDecimal(dt_Inv.Rows[0]["TotalTax"]); //3200

                        graph.DrawString("Invoice Currency    : " + dt_Inv.Rows[0]["CurrValue"].ToString() + ", Ex-Rate : " + InvoiceExRate.ToString(), font8, XBrushes.Black, new XRect(100, 600, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                        graph.DrawString("Invoice Amount       : " + InvoiceTotal_ExGST.ToString() + " Exclude GST", font8, XBrushes.Black, new XRect(100, 615, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

                        if (dt_Inv.Rows[0]["CurrValue"].ToString() != "INR")
                        {
                            decimal InvoiceExRate_R = Math.Round((InvoiceTotal_ExGST * InvoiceExRate), 2);
                            graph.DrawString("Invoice INR     : " + InvoiceExRate_R.ToString(), font7, XBrushes.Black, new XRect(100, 630, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                            InvoiceTotal_ExGST = InvoiceExRate_R;
                        }
                        PL = InvoiceTotal_ExGST - ExpenseTotal;
                        graph.DrawString("Profit/Loss      : " + InvoiceTotal_ExGST.ToString() + " - " + ExpenseTotal.ToString() + " = " + PL.ToString(), font8b, XBrushes.Black, new XRect(100, 645, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    }
                    else if (dt_Inv.Rows.Count >= 2)
                    {
                        int RowLeftWidth = 50; decimal TotalBillAmount = 0; decimal TotalGST = 0;
                        for (int i = 0; i < dt_Inv.Rows.Count; i++)
                        {
                            graph.DrawString("BillNo : " + dt_Inv.Rows[i]["BillNo"].ToString(), font8, XBrushes.Black, new XRect(RowLeftWidth, 600, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                            decimal InvoiceExRate = Convert.ToDecimal(dt_Inv.Rows[i]["ExRate"]); //_getDTInvoice.Rows[0]["ExRate"].ToString();
                            decimal InvoiceTotal_ExGST = Convert.ToDecimal(dt_Inv.Rows[i]["TotalNonTax"]) + Convert.ToDecimal(dt_Inv.Rows[i]["TotalTax"]); //3200

                            graph.DrawString("Invoice : " + dt_Inv.Rows[i]["CurrValue"].ToString() + ", Ex-Rate : " + InvoiceExRate.ToString(), font8, XBrushes.Black, new XRect(RowLeftWidth, 615, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

                            if (dt_Inv.Rows[i]["StateCode"].ToString() == "29")
                            { TotalGST += Convert.ToDecimal(dt_Inv.Rows[i]["CGST"]) + Convert.ToDecimal(dt_Inv.Rows[i]["SGST"]); }
                            else { TotalGST += Convert.ToDecimal(dt_Inv.Rows[i]["IGST"]); }

                            if (dt_Inv.Rows[0]["CurrValue"].ToString() == "INR")
                            {
                                decimal InvoiceExRate_R = Math.Round((InvoiceTotal_ExGST * InvoiceExRate), 2);
                                //     graph.DrawString("Invoice INR : " + InvoiceExRate_R.ToString(), font7, XBrushes.Black, new XRect(RowLeftWidth, 645, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                                InvoiceTotal_ExGST = (InvoiceExRate_R);
                                TotalBillAmount += InvoiceTotal_ExGST;
                            }
                            //else if (dt_Inv.Rows[0]["CurrValue"].ToString() != "INR")
                            //{
                            //    decimal InvoiceExRate_R = Math.Round((InvoiceTotal_ExGST * InvoiceExRate), 2);
                            //    graph.DrawString("Invoice INR : " + InvoiceExRate_R.ToString(), font7, XBrushes.Black, new XRect(RowLeftWidth, 645, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                            //    InvoiceTotal_ExGST = InvoiceExRate_R - TotalGST;
                            //    TotalBillAmount += InvoiceTotal_ExGST;
                            //}
                            graph.DrawString("Invoice Amount : " + InvoiceTotal_ExGST.ToString() + " Exclude GST", font8, XBrushes.Black, new XRect(RowLeftWidth, 630, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                            PL = TotalBillAmount - ExpenseTotal;
                            RowLeftWidth += 160;
                        }
                        graph.DrawString("Profit/Loss : " + PL.ToString(), font8b, XBrushes.Black, new XRect(160, 660, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    }
                }
                string path = String.Concat(Server.MapPath("."), "\\Expense.pdf");
                pdf.Save(path);
                ShowPdf(path);
            }
        }

        private void ShowPdf(string s)
        {
            Response.ClearContent();
            Response.ClearHeaders();
            Response.AddHeader("Content-Disposition", "inline;filename=" + s);
            Response.ContentType = "application/pdf";
            Response.WriteFile(s);
            Response.Flush();
            Response.Clear();
        }

        public override void VerifyRenderingInServerForm(Control txt_salutaion)
        {
            /* Verifies that the control is rendered */
        }
    }
}