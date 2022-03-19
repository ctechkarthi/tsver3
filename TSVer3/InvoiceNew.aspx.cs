using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using TSVer3.BL;
using System.Xml;
using System.Net;
using System.Collections.Generic;
using System.Text;
using PdfSharp.Drawing;
using System.Web.UI.WebControls;
using PdfSharp.Drawing.Layout;
using System.ComponentModel;
using System.Drawing;

//using System.Web.UI.WebControls;
//using PdfSharp.Drawing.Layout;
//using System.Security.Cryptography;

namespace TSVer3
{
    public partial class InvoiceNew : System.Web.UI.Page
    {
        #region class
        BusLayer obj_admin = new BusLayer();
        SqlDataReader dr = null; DataTable dt = new DataTable();
        string BillNo = string.Empty;
        string BankName = "HDFC Bank - INR";
        string JobNumber = string.Empty; string Signature = null;
        string JQ = string.Empty; string IRN = string.Empty; string AckNo = string.Empty; string AckDate = string.Empty;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            EInvoiceAPI eInvoiceAPI = new EInvoiceAPI();
            var response = eInvoiceAPI.GenerateIRNFromTaxPro();

            Session["CompanyCode"] = "CSHBLR"; Signature = "esge";
            string BillNo_ = "CSHLAI212200565"; // CSHLSE212200058A CSHLSI212200176  CSHLAE212200209 CSHLAI212200565
            //string BillNo_ = Request.QueryString["ien"];
            Signature = Request.QueryString["sge"];    
            BankName = Request.QueryString["fs"];        
            string JobNo_ = "0011"; 
            BillNo = BillNo_;
            Invoice_PDF();
            ////this.Page.Title = BillNo;
            ////Page.Header.Title = BillNo;
            //PageTitle.Text = BillNo; Page.Title = BillNo; this.Title = "Title of my page";
            Page.Header.Title = BillNo;
        }

        private void Invoice_PDF()
        {
            dt = new DataTable();
            dr = obj_admin.Invoice_Search_BillNo2(Convert.ToString(Session["CompanyCode"]), BillNo, "Debit Note");
            dt.Load(dr);

            DataTable dt_Particulars = new DataTable();
            dr = obj_admin.InvoiceParticulars_Search(Convert.ToString(Session["CompanyCode"]), BillNo, "Debit Note");
            dt_Particulars.Load(dr);

            //DataTable dt_Einv = new DataTable();
            //dr = obj_admin.EInv_BillNo(BillNo);
            //dt_Einv.Load(dr);

            if (dt.Rows.Count != 0)
            {
                PdfSharp.Pdf.PdfDocument pdf = new PdfSharp.Pdf.PdfDocument();
                {
                    PdfSharp.Pdf.PdfPage pdfPage = pdf.AddPage();
                    XGraphics graph = XGraphics.FromPdfPage(pdfPage);
                    graph.DrawImage(XImage.FromFile(Server.MapPath("inv5.jpg")), 0, -18);
                    
                    XImage image_logo = XImage.FromFile(Server.MapPath("logo_csh2.JPG"));
                    graph.DrawImage(image_logo, 32, 10, 60, 70);

                    //string QR = dt_Einv.Rows[0]["QR"].ToString();

                    ////string strJson = File.ReadAllText(WorkingFilesPath + @"\SandBoxSampleJsonGenIRN.txt");
                    //string strJson = File.ReadAllText(WorkingFilesPath + @"\ProductionSampleJsonGenIRN.txt");
                    ////RestClient client = new RestClient("http://gstsandbox.charteredinfo.comeicore/dec/v1.03/Invoice?aspid=************&password=************&Gstin=************&AuthToken=jSNGkXqh8RshEAf91CAFMMdcp&user_name=************&QrCodeSize=250");
                    //RestClient client = new RestClient("https://einvapi.charteredinfo.com/eicore/dec/v1.03/Invoice?aspid=************&password=************&Gstin=************&AuthToken=7wTMc7VccewQSqraD46qz2lCd&user_name=************&QrCodeSize=150");

                    //RestRequest request = new RestRequest(Method.POST);
                    //request.AddHeader("Gstin", "************");
                    //request.AddHeader("user_name", "************");

                    ////request.AddHeader("Gstin", "************");
                    ////request.AddHeader("user_name", "************");
                    //request.AddHeader("AuthToken", "jSNGkXqh8RshEAf91CAFMMdcp");
                    //request.AddHeader("aspid", "************");
                    //request.AddHeader("password", "************");
                    //request.AddHeader("Content-Type", "application/json; charset=utf-8");
                    //request.RequestFormat = DataFormat.Json;
                    ////ReqPlGenIRN reqPlGenIRN = new ReqPlGenIRN();
                    ////reqPlGenIRN = JsonConvert.DeserializeObject<ReqPlGenIRN>(strJson);
                    ////request.AddBody(reqPlGenIRN);
                    //request.AddParameter("application/json", strJson, ParameterType.RequestBody);
                    //IRestResponse response = await client.ExecuteTaskAsync(request);

                    //RespPl respPl = new RespPl();
                    //respPl = JsonConvert.DeserializeObject<RespPl>(response.Content);

                    //RespPlGenIRNDec respPlGenIRNDec = new RespPlGenIRNDec();
                    //respPlGenIRNDec = JsonConvert.DeserializeObject<RespPlGenIRNDec>(respPl.Data);
                    //rtbResponce.Text = respPlGenIRNDec.Irn;

                    string qr = "eyJhbGciOiJSUzI1NiIsImtpZCI6IkVEQzU3REUxMzU4QjMwMEJBOUY3OTM0MEE2Njk2ODMxRjNDODUwNDciLCJ0eXAiOiJKV1QiLCJ4NXQiOiI3Y1Y5NFRXTE1BdXA5NU5BcG1sb01mUElVRWMifQ.eyJkYXRhIjoie1wiQWNrTm9cIjoxNTIyMTAwMTk1MDE4MDMsXCJBY2tEdFwiOlwiMjAyMi0wMy0xOSAwNzo1MzoxOFwiLFwiSXJuXCI6XCIxZWEwY2IyMDM5ZGM5N2UxMWZhMTc3NDBhYjYwNzI1ZDBkNDhmN2UxYjczNTZhYWQzYTRmYmQ2NWJjMjU4OGJhXCIsXCJWZXJzaW9uXCI6XCIxLjFcIixcIlRyYW5EdGxzXCI6e1wiVGF4U2NoXCI6XCJHU1RcIixcIlN1cFR5cFwiOlwiQjJCXCIsXCJSZWdSZXZcIjpcIllcIixcIklnc3RPbkludHJhXCI6XCJOXCJ9LFwiRG9jRHRsc1wiOntcIlR5cFwiOlwiSU5WXCIsXCJOb1wiOlwiRE9DL3dlMjEzNTZcIixcIkR0XCI6XCIxOS8wMy8yMDIxXCJ9LFwiU2VsbGVyRHRsc1wiOntcIkdzdGluXCI6XCIzNEFBQ0NDMTU5NlEwMDJcIixcIkxnbE5tXCI6XCJOSUMgY29tcGFueSBwdnQgbHRkXCIsXCJUcmRObVwiOlwiTklDIEluZHVzdHJpZXNcIixcIkFkZHIxXCI6XCI1dGggYmxvY2ssIGt1dmVtcHUgbGF5b3V0XCIsXCJBZGRyMlwiOlwia3V2ZW1wdSBsYXlvdXRcIixcIkxvY1wiOlwiR0FOREhJTkFHQVJcIixcIlBpblwiOjYwNTAwMSxcIlN0Y2RcIjpcIjM0XCIsXCJQaFwiOlwiOTAwMDAwMDAwMFwiLFwiRW1cIjpcImFiY0BnbWFpbC5jb21cIn0sXCJCdXllckR0bHNcIjp7XCJHc3RpblwiOlwiMjlBV0dQVjcxMDdCMVoxXCIsXCJMZ2xObVwiOlwiWFlaIGNvbXBhbnkgcHZ0IGx0ZFwiLFwiVHJkTm1cIjpcIlhZWiBJbmR1c3RyaWVzXCIsXCJQb3NcIjpcIjEyXCIsXCJBZGRyMVwiOlwiN3RoIGJsb2NrLCBrdXZlbXB1IGxheW91dFwiLFwiQWRkcjJcIjpcImt1dmVtcHUgbGF5b3V0XCIsXCJMb2NcIjpcIkdBTkRISU5BR0FSXCIsXCJQaW5cIjo1NjIxNjAsXCJQaFwiOlwiOTExMTExMTExMTFcIixcIkVtXCI6XCJ4eXpAeWFob28uY29tXCIsXCJTdGNkXCI6XCIyOVwifSxcIkRpc3BEdGxzXCI6e1wiTm1cIjpcIkFCQyBjb21wYW55IHB2dCBsdGRcIixcIkFkZHIxXCI6XCI3dGggYmxvY2ssIGt1dmVtcHUgbGF5b3V0XCIsXCJBZGRyMlwiOlwia3V2ZW1wdSBsYXlvdXRcIixcIkxvY1wiOlwiQmFuYWdhbG9yZVwiLFwiUGluXCI6NTYyMTYwLFwiU3RjZFwiOlwiMjlcIn0sXCJTaGlwRHRsc1wiOntcIkdzdGluXCI6XCIyOUFXR1BWNzEwN0IxWjFcIixcIkxnbE5tXCI6XCJDQkUgY29tcGFueSBwdnQgbHRkXCIsXCJUcmRObVwiOlwia3V2ZW1wdSBsYXlvdXRcIixcIkFkZHIxXCI6XCI3dGggYmxvY2ssIGt1dmVtcHUgbGF5b3V0XCIsXCJBZGRyMlwiOlwia3V2ZW1wdSBsYXlvdXRcIixcIkxvY1wiOlwiQmFuYWdhbG9yZVwiLFwiUGluXCI6NTYyMTYwLFwiU3RjZFwiOlwiMjlcIn0sXCJJdGVtTGlzdFwiOlt7XCJJdGVtTm9cIjowLFwiU2xOb1wiOlwiMVwiLFwiSXNTZXJ2Y1wiOlwiTlwiLFwiUHJkRGVzY1wiOlwiUmljZVwiLFwiSHNuQ2RcIjpcIjEwMDYxMFwiLFwiQmFyY2RlXCI6XCIxMjM0NTZcIixcIlF0eVwiOjEwMC4zNDUsXCJGcmVlUXR5XCI6MTAsXCJVbml0XCI6XCJCQUdcIixcIlVuaXRQcmljZVwiOjk5LjU0NSxcIlRvdEFtdFwiOjk5ODguODQsXCJEaXNjb3VudFwiOjEwLFwiUHJlVGF4VmFsXCI6MSxcIkFzc0FtdFwiOjk5NzguODQsXCJHc3RSdFwiOjEyLjAsXCJJZ3N0QW10XCI6MTE5Ny40NixcIkNnc3RBbXRcIjowLFwiU2dzdEFtdFwiOjAsXCJDZXNSdFwiOjUsXCJDZXNBbXRcIjo0OTguOTQsXCJDZXNOb25BZHZsQW10XCI6MTAsXCJTdGF0ZUNlc1J0XCI6MTIsXCJTdGF0ZUNlc0FtdFwiOjExOTcuNDYsXCJTdGF0ZUNlc05vbkFkdmxBbXRcIjo1LFwiT3RoQ2hyZ1wiOjEwLFwiVG90SXRlbVZhbFwiOjEyODk3LjcsXCJPcmRMaW5lUmVmXCI6XCIzMjU2XCIsXCJPcmdDbnRyeVwiOlwiQUdcIixcIlByZFNsTm9cIjpcIjEyMzQ1XCIsXCJCY2hEdGxzXCI6e1wiTm1cIjpcIjEyMzQ1NlwiLFwiRXhwRHRcIjpcIjAxLzA4LzIwMjBcIixcIldyRHRcIjpcIjAxLzA5LzIwMjBcIn0sXCJBdHRyaWJEdGxzXCI6W3tcIk5tXCI6XCJSaWNlXCIsXCJWYWxcIjpcIjEwMDAwXCJ9XX1dLFwiVmFsRHRsc1wiOntcIkFzc1ZhbFwiOjk5NzguODQsXCJDZ3N0VmFsXCI6MCxcIlNnc3RWYWxcIjowLFwiSWdzdFZhbFwiOjExOTcuNDYsXCJDZXNWYWxcIjo1MDguOTQsXCJTdENlc1ZhbFwiOjEyMDIuNDYsXCJEaXNjb3VudFwiOjEwLFwiT3RoQ2hyZ1wiOjIwLFwiUm5kT2ZmQW10XCI6MC4zLFwiVG90SW52VmFsXCI6MTI5MDgsXCJUb3RJbnZWYWxGY1wiOjEyODk3Ljd9LFwiUGF5RHRsc1wiOntcIk5tXCI6XCJBQkNERVwiLFwiQWNjRGV0XCI6XCI1Njk3Mzg5NzEzMjEwXCIsXCJNb2RlXCI6XCJDYXNoXCIsXCJGaW5JbnNCclwiOlwiU0JJTjExMDAwXCIsXCJQYXlUZXJtXCI6XCIxMDBcIixcIlBheUluc3RyXCI6XCJHaWZ0XCIsXCJDclRyblwiOlwidGVzdFwiLFwiRGlyRHJcIjpcInRlc3RcIixcIkNyRGF5XCI6MTAwLFwiUGFpZEFtdFwiOjEwMDAwLFwiUGF5bXREdWVcIjo1MDAwfSxcIlJlZkR0bHNcIjp7XCJJbnZSbVwiOlwiVEVTVFwiLFwiRG9jUGVyZER0bHNcIjp7XCJJbnZTdER0XCI6XCIwMS8wOC8yMDIwXCIsXCJJbnZFbmREdFwiOlwiMDEvMDkvMjAyMFwifSxcIlByZWNEb2NEdGxzXCI6W3tcIkludk5vXCI6XCJET0MvMDAyXCIsXCJJbnZEdFwiOlwiMDEvMDgvMjAyMFwiLFwiT3RoUmVmTm9cIjpcIjEyMzQ1NlwifV0sXCJDb250ckR0bHNcIjpbe1wiUmVjQWR2UmVmclwiOlwiRG9jLzAwM1wiLFwiUmVjQWR2RHRcIjpcIjAxLzA4LzIwMjBcIixcIlRlbmRSZWZyXCI6XCJBYmMwMDFcIixcIkNvbnRyUmVmclwiOlwiQ28xMjNcIixcIkV4dFJlZnJcIjpcIllvNDU2XCIsXCJQcm9qUmVmclwiOlwiRG9jLTQ1NlwiLFwiUE9SZWZyXCI6XCJEb2MtNzg5XCIsXCJQT1JlZkR0XCI6XCIwMS8wOC8yMDIwXCJ9XX0sXCJBZGRsRG9jRHRsc1wiOlt7XCJVcmxcIjpcImh0dHBzOi8vZWludi1hcGlzYW5kYm94Lm5pYy5pblwiLFwiRG9jc1wiOlwiVGVzdCBEb2NcIixcIkluZm9cIjpcIkRvY3VtZW50IFRlc3RcIn1dLFwiRXhwRHRsc1wiOntcIlNoaXBCTm9cIjpcIkEtMjQ4XCIsXCJTaGlwQkR0XCI6XCIwMS8wOC8yMDIwXCIsXCJQb3J0XCI6XCJJTkFCRzFcIixcIlJlZkNsbVwiOlwiTlwiLFwiRm9yQ3VyXCI6XCJBRURcIixcIkNudENvZGVcIjpcIkFFXCJ9LFwiRXdiRHRsc1wiOntcIlRyYW5zTW9kZVwiOlwiMVwiLFwiRGlzdGFuY2VcIjowLFwiVmVoTm9cIjpcIktBMTJFUjEyMzRcIixcIlZlaFR5cGVcIjpcIlJcIn19IiwiaXNzIjoiTklDIn0.Wiu74x8nGHVha6FTtT7wy5nEWxKWFU0xaVLUdlW3-WypMiOfbQKfoXEl38NEuJi8cdpWuN7kNLaWQQvFLzzkJpYl2gStZlSaUD6E52uUkIn21wMtzDcOZRp0KxJ5L9E5_U6SUL8MUDB6Pqqi9R3WEdCsn2tUJ99Fa0kuqBdsR-aUULA5cpVzxTR_xLpvSfWuluM3bDIRe3-PZzHdBuuvhgP9wC-ZCmY7IWXf1F2cu4iBDx-4jY3adGX1sRs2ZL0Sj5h3aXE2TPtK3DtkO4OnOOu9t6x6OEN85Q11BqGMl7WefXH2v-7D3RisQ6xTk0kHchqr0gWVGZuH9tartABbTg";
                    byte[] qrImg = Convert.FromBase64String(qr);
                  ////  byte[] qrImg = Convert.FromBase64String(respPlGenIRNDec.QrCodeImage);
                    TypeConverter tc = TypeDescriptor.GetConverter(typeof(Bitmap));
                    ////Bitmap bitmap1 = (Bitmap)tc.ConvertFrom(qrImg);

                    System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
                    Bitmap bitmap2 = (Bitmap)tc.ConvertFrom(qrImg);
                    MemoryStream ms = new MemoryStream();
                    bitmap2.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                      byte[] byteImage = ms.ToArray();
                      imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);

                      ////plBarCode.Controls.Add(imgBarCode);

                    ////bitmap1.Save(WorkingFilesPath + @"\qr.png");

                    XImage image_QRCode = XImage.FromFile(Server.MapPath(imgBarCode)); //FromGdiPlusImage(imgBarCode);//
                    graph.DrawImage(image_QRCode, 480, 110, 90, 90);
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
                    XFont font16 = new XFont("Verdana", 16, XFontStyle.Bold);

                    graph.DrawString("C.S HAWKLER LOGISTICS PVT LTD", font16, XBrushes.Black, new XRect(0, 11, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopCenter);
                    graph.DrawString("'ANIRUDDH' No.6, 1st Cross, 6th Main, Kamadhenu Layout,", font10b, XBrushes.Black, new XRect(0, 30, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopCenter);
                    graph.DrawString("B Narayanapura, Doorvarni Nagar(post), Bangalore-560 016, India.", font10b, XBrushes.Black, new XRect(0, 42, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopCenter);
                    graph.DrawString("Email : accounts.blr@cshawkler.com", font10b, XBrushes.Black, new XRect(0, 54, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopCenter);
                    graph.DrawString("STATE CODE : 29, GST NO : 29AAGCC3874M1Z1, PAN NO : AAGCC3874M", font10b, XBrushes.Black, new XRect(0, 63, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopCenter);
                    graph.DrawString("CIN NO. U74900KA2016PTC086558, UDYAM REG. No.: UDYAM-KR-03-0053270", font10b, XBrushes.Black, new XRect(0, 72, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopCenter);
                    graph.DrawString("ARN : AD290921003967P", font10b, XBrushes.Black, new XRect(0, 81, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopCenter);

                    graph.DrawString("TAX INVOICE", font10b, XBrushes.Black, new XRect(0, 101, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopCenter);
                    graph.DrawString("IRN : 8b7fe214b18dd13532016760fdbc90bbdeffac686c5d5b8cdf29836a00078fd8", font8, XBrushes.Black, new XRect(50, 113, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    //graph.DrawString("IRN : " + dt_Einv.Rows[0]["IRN"].ToString(), font8, XBrushes.Black, new XRect(50, 113, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                      
                    /*Customer Address*/
                    if (string.IsNullOrEmpty(dt.Rows[0]["Guaranteel1"].ToString())) // (Guarantee == "No")
                    {
                        /*Customer Address*/
                        graph.DrawString("To:", font8, XBrushes.Black, new XRect(38, 122, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                        graph.DrawString(dt.Rows[0]["To1"].ToString(), font8b, XBrushes.Black, new XRect(40, 132, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                        graph.DrawString(dt.Rows[0]["To2"].ToString(), font8, XBrushes.Black, new XRect(40, 142, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                        graph.DrawString(dt.Rows[0]["To3"].ToString(), font8, XBrushes.Black, new XRect(40, 152, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                        graph.DrawString(dt.Rows[0]["To4"].ToString(), font8, XBrushes.Black, new XRect(40, 162, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                        graph.DrawString(dt.Rows[0]["To5"].ToString(), font8, XBrushes.Black, new XRect(40, 172, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

                        if (dt.Rows[0]["StateCode"].ToString() != "00")
                        {
                            graph.DrawString("State Code: " + dt.Rows[0]["StateCode"].ToString() + "   State Name: " + dt.Rows[0]["State"].ToString(), font8, XBrushes.Black, new XRect(40, 182, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                            graph.DrawString("GST No: " + dt.Rows[0]["GSTNo"].ToString() + ",  " + "PAN: " + dt.Rows[0]["PAN"].ToString(), font8, XBrushes.Black, new XRect(40, 191, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                        }
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[0]["Guaranteel1"].ToString())) //if (Guarantee == "Yes")
                    {
                        graph.DrawString("To:", font8, XBrushes.Black, new XRect(38, 112, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                        /*Guarantee Address*/
                        graph.DrawString(dt.Rows[0]["Guaranteel1"].ToString(), font7b, XBrushes.Black, new XRect(40, 132, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                        graph.DrawString(dt.Rows[0]["Guaranteel2"].ToString(), font7, XBrushes.Black, new XRect(40, 140, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                        graph.DrawString(dt.Rows[0]["Guaranteel3"].ToString(), font7, XBrushes.Black, new XRect(40, 148, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                        graph.DrawString(dt.Rows[0]["Guaranteel4"].ToString(), font7, XBrushes.Black, new XRect(40, 156, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                        /*Customer Address*/
                        graph.DrawString(dt.Rows[0]["To1"].ToString(), font7b, XBrushes.Black, new XRect(40, 169, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                        graph.DrawString(dt.Rows[0]["To2"].ToString(), font7, XBrushes.Black, new XRect(40, 179, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                        graph.DrawString(dt.Rows[0]["To3"].ToString(), font7, XBrushes.Black, new XRect(40, 189, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                        graph.DrawString(dt.Rows[0]["To4"].ToString(), font7, XBrushes.Black, new XRect(40, 199, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                        graph.DrawString(dt.Rows[0]["To5"].ToString(), font7, XBrushes.Black, new XRect(40, 209, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

                        if (dt.Rows[0]["StateCode"].ToString() != "00")
                        {
                            graph.DrawString("State Code: " + dt.Rows[0]["StateCode"].ToString() + "  State Name: " + dt.Rows[0]["State"].ToString(), font7, XBrushes.Black, new XRect(40, 218, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                            graph.DrawString("GST No: " + dt.Rows[0]["GSTNo"].ToString() + ",  " + "PAN: " + dt.Rows[0]["PAN"].ToString(), font7, XBrushes.Black, new XRect(40, 226, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                        }
                    } 
                                      
                    // Invoice No.
                    graph.DrawString("Ack No.  : 321644616484984558", font8, XBrushes.Black, new XRect(330, 132, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString("Ack Date : 2022-12-22", font8, XBrushes.Black, new XRect(330, 142, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

                    //graph.DrawString("Ack No.  : " + dt_Einv.Rows[0]["AckNo"].ToString(), font8, XBrushes.Black, new XRect(330, 132, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    //graph.DrawString("Ack Date : " + dt_Einv.Rows[0]["AckDate"].ToString(), font8, XBrushes.Black, new XRect(330, 142, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    
                    graph.DrawString("Invoice No  : " + dt.Rows[0]["BillNo"].ToString(), font8b, XBrushes.Black, new XRect(330, 160, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString("Invoice Date : " + dt.Rows[0]["BillDate"].ToString(), font8, XBrushes.Black, new XRect(330, 170, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

                    graph.DrawString("Currency: " + dt.Rows[0]["CurrValue"].ToString(), font8b, XBrushes.Black, new XRect(330, 180, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString("Ex-Rate     : " + dt.Rows[0]["ExRate"].ToString(), font8, XBrushes.Black, new XRect(330, 190, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    //graph.DrawString("Other Reference: " + dt.Rows[0]["JobNo"].ToString(), font8, XBrushes.Black, new XRect(330, 150, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    //graph.DrawString("IEC : " + dt.Rows[0]["IEC"].ToString(), font8, XBrushes.Black, new XRect(330, 160, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

                    // Bill Details
                    graph.DrawString("BE/SB No./ Date", font8, XBrushes.Black, new XRect(60, 212, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString(": " + dt.Rows[0]["SBNo"].ToString() + " " + dt.Rows[0]["SBDate"].ToString(), font8, XBrushes.Black, new XRect(127, 212, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                   
                    graph.DrawString("Origin", font8, XBrushes.Black, new XRect(60, 242, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString(": " + dt.Rows[0]["Origin"].ToString(), font8, XBrushes.Black, new XRect(127, 242, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

                    graph.DrawString("Destination", font8, XBrushes.Black, new XRect(60, 252, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString(": " + dt.Rows[0]["Dest"].ToString(), font8, XBrushes.Black, new XRect(127, 252, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

                    graph.DrawString("IGM/EGM", font8, XBrushes.Black, new XRect(60, 262, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString(": " + dt.Rows[0]["IGM"].ToString(), font8, XBrushes.Black, new XRect(127, 262, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

                    graph.DrawString("Shipper/Consignee", font8, XBrushes.Black, new XRect(310, 212, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString(": " + dt.Rows[0]["Shipper"].ToString(), font8, XBrushes.Black, new XRect(385, 212, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

                    graph.DrawString("PKGS", font8, XBrushes.Black, new XRect(310, 222, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString(": " + dt.Rows[0]["Pkgs"].ToString(), font8, XBrushes.Black, new XRect(385, 222, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

                    graph.DrawString("Gr Weight", font8, XBrushes.Black, new XRect(310, 232, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString(": " + dt.Rows[0]["GrWeight"].ToString(), font8, XBrushes.Black, new XRect(385, 232, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

                    graph.DrawString("Ch Weight", font8, XBrushes.Black, new XRect(310, 242, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString(": " + dt.Rows[0]["ChWeight"].ToString(), font8, XBrushes.Black, new XRect(385, 242, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

                    graph.DrawString("Sh. Invoice", font8, XBrushes.Black, new XRect(310, 262, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString(": " + dt.Rows[0]["ShInvoice"].ToString(), font8, XBrushes.Black, new XRect(385, 262, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

                    if ((dt.Rows[0]["Category"].ToString() == "Air Export") || (dt.Rows[0]["Category"].ToString() == "Air Import"))
                    {
                        graph.DrawString("MAWB", font8, XBrushes.Black, new XRect(60, 222, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                        graph.DrawString(": " + dt.Rows[0]["AWBNo"].ToString(), font8, XBrushes.Black, new XRect(127, 222, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

                        graph.DrawString("HAWB", font8, XBrushes.Black, new XRect(60, 232, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                        graph.DrawString(": " + dt.Rows[0]["HAWBNo"].ToString(), font8, XBrushes.Black, new XRect(127, 232, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

                        graph.DrawString("Airline", font8, XBrushes.Black, new XRect(310, 252, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                        graph.DrawString(": " + dt.Rows[0]["Line"].ToString(), font8, XBrushes.Black, new XRect(385, 252, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

                        //   graph.DrawString("Sh. Invoice", font8, XBrushes.Black, new XRect(60, 272, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                        //    graph.DrawString(": " + dt.Rows[0]["ShInvoice"].ToString(), font8, XBrushes.Black, new XRect(127, 272, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    }
                    else if ((dt.Rows[0]["Category"].ToString() == "Sea Export") || (dt.Rows[0]["Category"].ToString() == "Sea Import"))
                    {
                        graph.DrawString("MBL", font8, XBrushes.Black, new XRect(60, 222, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                        graph.DrawString(": " + dt.Rows[0]["AWBNo"].ToString(), font8, XBrushes.Black, new XRect(127, 222, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

                        graph.DrawString("HBL", font8, XBrushes.Black, new XRect(60, 232, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                        graph.DrawString(": " + dt.Rows[0]["HAWBNo"].ToString(), font8, XBrushes.Black, new XRect(127, 232, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

                        graph.DrawString("Line", font8, XBrushes.Black, new XRect(310, 252, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                        graph.DrawString(": " + dt.Rows[0]["Line"].ToString(), font8, XBrushes.Black, new XRect(385, 252, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

                        graph.DrawString("CBM", font8, XBrushes.Black, new XRect(60, 272, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                        graph.DrawString(": " + dt.Rows[0]["CBM"].ToString(), font8, XBrushes.Black, new XRect(127, 272, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    }
                    // Particulars Header
                    graph.DrawString("S.N", font7, XBrushes.Black, new XRect(30, 294, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString("Particulars", font7, XBrushes.Black, new XRect(78, 294, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString("SAC/", font7, XBrushes.Black, new XRect(275, 290, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString("HSN", font7, XBrushes.Black, new XRect(275, 299, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    //      graph.DrawString("Qty", font7, XBrushes.Black, new XRect(226, 294, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    //    graph.DrawString("Unit", font7, XBrushes.Black, new XRect(255, 290, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    //   graph.DrawString("Rate", font7, XBrushes.Black, new XRect(255, 299, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString("Non Tax", font7, XBrushes.Black, new XRect(313, 294, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString("Tax", font7, XBrushes.Black, new XRect(369, 294, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString("IGST", font7, XBrushes.Black, new XRect(403, 290, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString("%", font7, XBrushes.Black, new XRect(405, 299, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString("IGST", font7, XBrushes.Black, new XRect(434, 294, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString("CGST", font7, XBrushes.Black, new XRect(462, 290, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString("%", font7, XBrushes.Black, new XRect(469, 299, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString("CGST", font7, XBrushes.Black, new XRect(492, 294, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString("SGST", font7, XBrushes.Black, new XRect(525, 290, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString("%", font7, XBrushes.Black, new XRect(529, 299, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString("SGST", font7, XBrushes.Black, new XRect(555, 294, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

                    string stringEmpty = " ";
                    // Particulars Details
                    int RowHeight = 310;
                    int y = 310;
                    decimal Tax5 = 0;
                    decimal Tax18 = 0;
                    string AirFreight_INTLCourier = string.Empty;

                    for (int PartiRowCount = 0; PartiRowCount < dt_Particulars.Rows.Count; PartiRowCount++)
                    {
                        tf.Alignment = XParagraphAlignment.Right;
                        graph.DrawString((PartiRowCount + 1).ToString(), font7, XBrushes.Black, new XRect(33, RowHeight, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                        graph.DrawString(dt_Particulars.Rows[PartiRowCount]["Particulars"].ToString(), font7, XBrushes.Black, new XRect(48, RowHeight, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                        if (!string.IsNullOrEmpty(dt_Particulars.Rows[PartiRowCount]["Additional"].ToString()))
                        {
                            graph.DrawString(dt_Particulars.Rows[PartiRowCount]["Additional"].ToString(), font6i, XBrushes.Black, new XRect(48, RowHeight + 7, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                            RowHeight = RowHeight + 4;
                            y = y + 4;
                        }
                        graph.DrawString(dt_Particulars.Rows[PartiRowCount]["HSN"].ToString(), font7, XBrushes.Black, new XRect(270, RowHeight, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                        //  graph.DrawString(dt_Particulars.Rows[PartiRowCount]["Quantity"].ToString(), font7, XBrushes.Black, new XRect(223, RowHeight, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                        //  tf.DrawString(dt_Particulars.Rows[PartiRowCount]["Rate"].ToString(), font7, XBrushes.Black, new XRect(29, y, 250, 220), XStringFormats.TopLeft);

                        string NonTaxAmt = string.Empty;
                        NonTaxAmt = dt_Particulars.Rows[PartiRowCount]["NonTaxAmt"].ToString();
                        if (("0" == NonTaxAmt) || ("0.00" == NonTaxAmt) || (string.IsNullOrEmpty(NonTaxAmt)))
                        { tf.DrawString(stringEmpty, font7, XBrushes.Black, new XRect(95, y, 250, 220), XStringFormats.TopLeft); }
                        else
                        { tf.DrawString(NonTaxAmt, font7, XBrushes.Black, new XRect(95, y, 250, 220), XStringFormats.TopLeft); }
                        NonTaxAmt = string.Empty;

                        string TaxAmt = string.Empty;
                        TaxAmt = dt_Particulars.Rows[PartiRowCount]["TaxAmt"].ToString();
                        if (("0" == TaxAmt) || ("0.00" == TaxAmt) || (string.IsNullOrEmpty(TaxAmt)))
                        { tf.DrawString(stringEmpty, font7, XBrushes.Black, new XRect(146, y, 250, 220), XStringFormats.TopLeft); }
                        else
                        { tf.DrawString(TaxAmt, font7, XBrushes.Black, new XRect(146, y, 250, 220), XStringFormats.TopLeft); }
                        TaxAmt = string.Empty;

                        if (dt.Rows[0]["StateCode"].ToString() == "29")
                        {
                            if (dt_Particulars.Rows[PartiRowCount]["Particulars"].ToString() == "AIR FREIGHT CHARGES (INTL COURIER)")
                            {
                                AirFreight_INTLCourier = "AIR FREIGHT CHARGES (INTL COURIER)";
                                string IGST = dt_Particulars.Rows[PartiRowCount]["IGST"].ToString();
                                if (("0" == IGST) || ("0.00" == IGST) || (string.IsNullOrEmpty(IGST)))
                                { graph.DrawString(stringEmpty, font7, XBrushes.Black, new XRect(405, RowHeight, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft); }
                                else { graph.DrawString(IGST, font7, XBrushes.Black, new XRect(405, RowHeight, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft); }

                                string IGSTValue = dt_Particulars.Rows[PartiRowCount]["IGSTValue"].ToString();
                                if (("0" == IGSTValue) || ("0.00" == IGSTValue) || (string.IsNullOrEmpty(IGSTValue)))
                                { tf.DrawString(stringEmpty, font7, XBrushes.Black, new XRect(210, y, 250, 220), XStringFormats.TopLeft); }
                                else { tf.DrawString(IGSTValue, font7, XBrushes.Black, new XRect(210, y, 250, 220), XStringFormats.TopLeft); }

                                if (IGST == "5")
                                { Tax5 += Convert.ToDecimal(IGSTValue); }
                                if (IGST == "18")
                                { Tax18 += Convert.ToDecimal(IGSTValue); }
                            }
                            else
                            {
                                string CGST = dt_Particulars.Rows[PartiRowCount]["CGST"].ToString();
                                if (("0" == CGST) || ("0.00" == CGST) || (string.IsNullOrEmpty(CGST)))
                                { graph.DrawString(stringEmpty, font7, XBrushes.Black, new XRect(469, RowHeight, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft); }
                                else { graph.DrawString(CGST, font7, XBrushes.Black, new XRect(469, RowHeight, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft); }

                                string CGSTValue = dt_Particulars.Rows[PartiRowCount]["CGSTValue"].ToString();
                                if (("0" == CGSTValue) || ("0.00" == CGSTValue) || (string.IsNullOrEmpty(CGSTValue)))
                                { tf.DrawString(stringEmpty, font7, XBrushes.Black, new XRect(271, y, 250, 220), XStringFormats.TopLeft); }
                                else { tf.DrawString(CGSTValue, font7, XBrushes.Black, new XRect(271, y, 250, 220), XStringFormats.TopLeft); }

                                string SGST = dt_Particulars.Rows[PartiRowCount]["SGST"].ToString();
                                if (("0" == SGST) || ("0.00" == SGST) || (string.IsNullOrEmpty(SGST)))
                                { graph.DrawString(stringEmpty, font7, XBrushes.Black, new XRect(532, RowHeight, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft); }
                                else { graph.DrawString(SGST, font7, XBrushes.Black, new XRect(532, RowHeight, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft); }

                                string SGSTValue = dt_Particulars.Rows[PartiRowCount]["SGSTValue"].ToString();
                                if (("0" == SGSTValue) || ("0.00" == SGSTValue) || (string.IsNullOrEmpty(SGSTValue)))
                                { tf.DrawString(stringEmpty, font7, XBrushes.Black, new XRect(334, y, 250, 220), XStringFormats.TopLeft); }
                                else { tf.DrawString(SGSTValue, font7, XBrushes.Black, new XRect(334, y, 250, 220), XStringFormats.TopLeft); }

                                if (CGST == "2.5")
                                { Tax5 += Convert.ToDecimal(CGSTValue); }
                                if (CGST == "9")
                                { Tax18 += Convert.ToDecimal(CGSTValue); }
                            }
                        }
                        else if ((dt.Rows[0]["StateCode"] != "00") && (dt.Rows[0]["StateCode"] != "29"))
                        {
                            string IGST = dt_Particulars.Rows[PartiRowCount]["IGST"].ToString();
                            if (("0" == IGST) || ("0.00" == IGST) || (string.IsNullOrEmpty(IGST)))
                            { graph.DrawString(stringEmpty, font7, XBrushes.Black, new XRect(405, RowHeight, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft); }
                            else { graph.DrawString(IGST, font7, XBrushes.Black, new XRect(405, RowHeight, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft); }

                            string IGSTValue = dt_Particulars.Rows[PartiRowCount]["IGSTValue"].ToString();
                            if (("0" == IGSTValue) || ("0.00" == IGSTValue) || (string.IsNullOrEmpty(IGSTValue)))
                            { tf.DrawString(stringEmpty, font7, XBrushes.Black, new XRect(210, y, 250, 220), XStringFormats.TopLeft); }
                            else { tf.DrawString(IGSTValue, font7, XBrushes.Black, new XRect(210, y, 250, 220), XStringFormats.TopLeft); }

                            if (IGST == "5")
                            { Tax5 += Convert.ToDecimal(IGSTValue); }
                            if (IGST == "18")
                            { Tax18 += Convert.ToDecimal(IGSTValue); }
                        }
                        y += 15;
                        RowHeight += 15;
                    }

                    // Total
                    string TotalNonTax = dt.Rows[0]["TotalNonTax"].ToString();
                    if (("0" == TotalNonTax) || ("0.00" == TotalNonTax) || (string.IsNullOrEmpty(TotalNonTax)))
                    { tf.DrawString(stringEmpty, font7, XBrushes.Black, new XRect(96, 548, 250, 220), XStringFormats.TopLeft); }
                    else { tf.DrawString(dt.Rows[0]["TotalNonTax"].ToString(), font7, XBrushes.Black, new XRect(96, 548, 250, 220), XStringFormats.TopLeft); }

                    string TotalTax = dt.Rows[0]["TotalTax"].ToString();
                    if (("0" == TotalTax) || ("0.00" == TotalTax) || (string.IsNullOrEmpty(TotalTax)))
                    { tf.DrawString(stringEmpty, font7, XBrushes.Black, new XRect(147, 548, 250, 220), XStringFormats.TopLeft); }
                    else { tf.DrawString(dt.Rows[0]["TotalTax"].ToString(), font7, XBrushes.Black, new XRect(147, 548, 250, 220), XStringFormats.TopLeft); }

                    if ((dt.Rows[0]["StateCode"].ToString()) == "29")
                    {
                        //for (int PartiRowCount = 0; PartiRowCount < dt_Particulars.Rows.Count; PartiRowCount++)
                        //{
                        //    if (dt_Particulars.Rows[PartiRowCount]["Particulars"].ToString() == "AIR FREIGHT CHARGES (INTL COURIER)")
                        //    {
                        //    }
                        //}
                         if (AirFreight_INTLCourier == "AIR FREIGHT CHARGES (INTL COURIER)")
                        {
                            string IGST = dt.Rows[0]["IGST"].ToString();
                            if (("0" == IGST) || ("0.00" == IGST) || (string.IsNullOrEmpty(IGST)))
                            { tf.DrawString(stringEmpty, font7, XBrushes.Black, new XRect(210, 548, 250, 220), XStringFormats.TopLeft); }
                            else { tf.DrawString(dt.Rows[0]["IGST"].ToString(), font7, XBrushes.Black, new XRect(210, 548, 250, 220), XStringFormats.TopLeft); }
                            AirFreight_INTLCourier = null;
                        }
                        else
                        {
                            string CGST = dt.Rows[0]["CGST"].ToString();
                            if (("0" == CGST) || ("0.00" == CGST) || (string.IsNullOrEmpty(CGST)))
                            { tf.DrawString(stringEmpty, font7, XBrushes.Black, new XRect(271, 548, 250, 220), XStringFormats.TopLeft); }
                            else { tf.DrawString(dt.Rows[0]["CGST"].ToString(), font7, XBrushes.Black, new XRect(271, 548, 250, 220), XStringFormats.TopLeft); }

                            string SGST = dt.Rows[0]["SGST"].ToString();
                            if (("0" == SGST) || ("0.00" == SGST) || (string.IsNullOrEmpty(SGST)))
                            { tf.DrawString(stringEmpty, font7, XBrushes.Black, new XRect(334, 548, 250, 220), XStringFormats.TopLeft); }
                            else { tf.DrawString(dt.Rows[0]["SGST"].ToString(), font7, XBrushes.Black, new XRect(334, 548, 250, 220), XStringFormats.TopLeft); }

                            tf.DrawString("CGST @2.5% =" + Tax5 + ", SGST @2.5% = " + Tax5, font8, XBrushes.Black, new XRect(30, 583, 250, 220), XStringFormats.TopLeft);
                            tf.DrawString("CGST @9% = " + Tax18 + ", SGST @9% = " + Tax18, font8, XBrushes.Black, new XRect(30, 600, 250, 220), XStringFormats.TopLeft);     
                        }

                    }
                    else if ((dt.Rows[0]["StateCode"].ToString()) != "29")
                    {
                        string IGST = dt.Rows[0]["IGST"].ToString();
                        if (("0" == IGST) || ("0.00" == IGST) || (string.IsNullOrEmpty(IGST)))
                        { tf.DrawString(stringEmpty, font7, XBrushes.Black, new XRect(210, 548, 250, 220), XStringFormats.TopLeft); }
                        else { tf.DrawString(dt.Rows[0]["IGST"].ToString(), font7, XBrushes.Black, new XRect(210, 548, 250, 220), XStringFormats.TopLeft); }

                        tf.DrawString("IGST @5% =" + Tax5 + ", IGST @18% = " + Tax18, font8, XBrushes.Black, new XRect(30, 583, 250, 220), XStringFormats.TopLeft);
                    }

                    // Grand Total                  
                    tf.DrawString("SUB TOTAL ", font8, XBrushes.Black, new XRect(237, 569, 250, 220), XStringFormats.TopLeft);
                    tf.DrawString("ROUND OFF ", font8, XBrushes.Black, new XRect(237, 586, 250, 220), XStringFormats.TopLeft);
                    tf.DrawString("TOTAL AMOUNT (" + dt.Rows[0]["CurrValue"].ToString() + ") ", font8b, XBrushes.Black, new XRect(237, 600, 250, 220), XStringFormats.TopLeft);

                    decimal GrandTotal = Convert.ToDecimal(dt.Rows[0]["GrandTotal"].ToString()); // TotalAmtRounded.ToString();
                
                    //decimal TotalAmtRounded = Math.Round(Balance);
                    decimal TotalAmt = Convert.ToDecimal(dt.Rows[0]["Total"].ToString()); // TotalAmtRounded.ToString();
                    string TotalAmtVal = string.Empty;
                    Int64 NumVal = Convert.ToInt64(GrandTotal); //.Trim());

                    string CurrencyValue = GrandTotal.ToString("F2").Split('.')[1];
                    if (!string.IsNullOrEmpty(CurrencyValue))
                    {
                        int CurrencyValue_ = Convert.ToInt32(CurrencyValue);
                        //if ((CurrencyValue_ >= 1) && (CurrencyValue_ <= 99))
                        //{
                        //    TotalAmtVal += " AND " + ConvertNumbertoWords(Convert.ToInt32(CurrencyValue)) + " CENT";
                        //}
                    }
                    // If currency is Non-INR then INR value calulate here
                    if (dt.Rows[0]["CurrValue"].ToString() == "INR")
                    {
                        TotalAmtVal = rupees_INR(Convert.ToInt32(GrandTotal));
                    }
                    else //if(dt.Rows[0]["CurrValue"].ToString() != "INR")
                    {
                        TotalAmtVal = ConvertNumbertoWords(Convert.ToInt32(GrandTotal)) + " ONLY";
                        decimal InvoiceExRate = Convert.ToDecimal(dt.Rows[0]["ExRate"].ToString());  //Convert.ToDecimal(tbx_InvoiceExRate.Text); //_getDTInvoice.Rows[0]["ExRate"].ToString();
                        decimal InvoiceExRate_R = Math.Round((GrandTotal * InvoiceExRate), 2);
                        graph.DrawString("TOTAL INR :" + InvoiceExRate_R.ToString(), font7, XBrushes.Black, new XRect(40, 603, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    }

                    tf.DrawString(TotalAmt.ToString(), font8, XBrushes.Black, new XRect(336, 568, 250, 220), XStringFormats.TopLeft);
                    tf.DrawString((GrandTotal - TotalAmt).ToString(), font8, XBrushes.Black, new XRect(336, 585, 250, 220), XStringFormats.TopLeft);
                    tf.DrawString(GrandTotal.ToString(), font8b, XBrushes.Black, new XRect(336, 600, 250, 220), XStringFormats.TopLeft);
                    tf.DrawString("ADVANCE ", font8, XBrushes.Black, new XRect(237, 618, 250, 220), XStringFormats.TopLeft);
                    tf.DrawString("BALANCE ", font8b, XBrushes.Black, new XRect(237, 634, 250, 220), XStringFormats.TopLeft);
                    tf.DrawString(dt.Rows[0]["Advance"].ToString(), font8, XBrushes.Black, new XRect(336, 618, 250, 220), XStringFormats.TopLeft);
                    tf.DrawString(dt.Rows[0]["Balance"].ToString(), font8b, XBrushes.Black, new XRect(336, 634, 250, 220), XStringFormats.TopLeft);
                    
                    graph.DrawString(dt.Rows[0]["CurrValue"].ToString() + " IN WORDS : " + TotalAmtVal, font8b, XBrushes.Black, new XRect(40, 647, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

                    // Terms
                    graph.DrawString("Terms & Conditions:", font7b, XBrushes.Black, new XRect(40, 661, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString("1. Payment to be made by cross cheque / Draft in favour of “C.S. Hawkler Logistics Pvt Ltd”.,", font7, XBrushes.Black, new XRect(40, 673, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString("2. Payment should be settled within 30 days from the date of Invoice", font7, XBrushes.Black, new XRect(40, 683, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString("3. Contents of the invoice will be considered correct if no error is reported within 7 days of the invoice", font7, XBrushes.Black, new XRect(40, 693, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString("4. Interest @ 2% per month or part thereof or at the rate stipulated in the", font7, XBrushes.Black, new XRect(40, 703, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString("   contract will be imposed on overdue amounts.", font7, XBrushes.Black, new XRect(40, 713, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    if (Signature == "msge")
                    {
                        tf.DrawString("FOR C.S HAWKLER LOGISTICS PVT LTD", font8, XBrushes.Black, new XRect(300, 725, 250, 220), XStringFormats.TopLeft);
                        tf.DrawString("AUTHORISED SIGNATORY", font8, XBrushes.Black, new XRect(290, 765, 250, 220), XStringFormats.TopLeft);
                    }
                    else if (Signature == "esge")
                    {
                        XImage image_sign = XImage.FromFile(Server.MapPath("AE-Anand.jpg"));
                        
                        if ((BillNo.Contains("SI") == true) || (BillNo.Contains("SE") == true))
                        {
                            image_sign = XImage.FromFile(Server.MapPath("SI-Madhu.jpg"));
                            graph.DrawImage(image_sign, 390, 692, 160, 90);
                        }
                        else if (BillNo.Contains("AI") == true)
                        {
                            image_sign = XImage.FromFile(Server.MapPath("AI-Theerthesha.jpg"));
                            graph.DrawImage(image_sign, 390, 688, 150, 95);
                        }
                        else if (BillNo.Contains("AE") == true)
                        {
                            image_sign = XImage.FromFile(Server.MapPath("AE-Anand.jpg"));
                            graph.DrawImage(image_sign, 390, 688, 170, 90);
                        }

                        tf.DrawString("FOR C.S HAWKLER LOGISTICS PVT LTD", font8, XBrushes.Black, new XRect(300, 715, 250, 220), XStringFormats.TopLeft);
                        tf.DrawString("AUTHORISED SIGNATORY", font8, XBrushes.Black, new XRect(290, 755, 250, 220), XStringFormats.TopLeft);
                    }
                    else
                    {
                        graph.DrawString("*This is system generated invoice, signature not required", font10b, XBrushes.Black, new XRect(100, 750, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopCenter);
                    }
                    //  tf.DrawString("E & O E", font8, XBrushes.Black, new XRect(300, 760, 250, 220), XStringFormats.TopLeft);
                    // Bank
                    graph.DrawString("Our Bank Details:", font7b, XBrushes.Black, new XRect(40, 726, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

                    if (BankName == "HDFC Bank - INR")
                    {
                        graph.DrawString("A/c No: 50200048906565", font7, XBrushes.Black, new XRect(40, 736, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                        graph.DrawString("Bank Name: HDFC Bank Ltd", font7, XBrushes.Black, new XRect(40, 746, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                        graph.DrawString("Branch: B.NARAYANAPURA, Bangalore-560016", font7, XBrushes.Black, new XRect(40, 756, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                        graph.DrawString("IFSC Code: HDFC0004210", font7, XBrushes.Black, new XRect(40, 766, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                        //graph.DrawString("MICR Code: 560240114", font7, XBrushes.Black, new XRect(40, 776, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    }
                    else if (BankName == "HDFC Bank - USD")
                    {
                        graph.DrawString("A/c No: 50200048993548", font7, XBrushes.Black, new XRect(40, 736, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                        graph.DrawString("Bank Name: HDFC Bank Ltd", font7, XBrushes.Black, new XRect(40, 746, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                        graph.DrawString("Branch: B.NARAYANAPURA, Bangalore-560016", font7, XBrushes.Black, new XRect(40, 756, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                        graph.DrawString("IFSC Code: HDFC0004210", font7, XBrushes.Black, new XRect(40, 766, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                        graph.DrawString("MICR Code: 560240114", font7, XBrushes.Black, new XRect(40, 776, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    }
                    else if (BankName == "IDBI Bank")
                    {
                        graph.DrawString("A/c No: 1620102000004978", font7, XBrushes.Black, new XRect(40, 736, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                        graph.DrawString("Bank Name: IDBI Bank Ltd", font7, XBrushes.Black, new XRect(40, 746, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                        graph.DrawString("Branch: Banaswadi, Bangalore", font7, XBrushes.Black, new XRect(40, 756, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                        graph.DrawString("IFSC Code: IBKL0001620", font7, XBrushes.Black, new XRect(40, 766, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    }
                    else if (BankName == "ICICI Bank")
                    {
                        graph.DrawString("A/c No: 428405000187", font7, XBrushes.Black, new XRect(40, 736, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                        graph.DrawString("Bank Name: ICICI Bank Ltd", font7, XBrushes.Black, new XRect(40, 746, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                        graph.DrawString("Branch: B.Narayanapura Branch, Bangalore", font7, XBrushes.Black, new XRect(40, 756, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                        graph.DrawString("IFSC Code: ICIC0004284, Swift Code: ICICINBBCTS", font7, XBrushes.Black, new XRect(40, 766, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    }
                    else if (BankName == "YES Bank")
                    {
                        graph.DrawString("A/c No: 002287300000844", font7, XBrushes.Black, new XRect(40, 736, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                        graph.DrawString("Bank Name: YES Bank Ltd", font7, XBrushes.Black, new XRect(40, 746, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                        graph.DrawString("Branch: Kasturba Road, Bangalore", font7, XBrushes.Black, new XRect(40, 756, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                        graph.DrawString("IFSC Code: YESB0000022, Swift Code: YESBINBB", font7, XBrushes.Black, new XRect(40, 766, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                        graph.DrawString("MICR Code: 560532012, BSR Code: 6391040", font7, XBrushes.Black, new XRect(40, 776, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    }

                    string path = String.Concat(Server.MapPath("."), "\\Invoice.pdf");
                    pdf.Save(path);
                    ShowPdf(path);
                }
            }
        }
        
        public override void VerifyRenderingInServerForm(Control txt_salutaion)
        {
            /* Verifies that the control is rendered */
        }

        private void ShowPdf(string s)
        {
            Response.ClearContent();
            Response.ClearHeaders();
            Response.AddHeader("Content-Disposition", "inline;filename=" + BillNo + ".pdf");
            Response.ContentType = "application/pdf";
            Response.WriteFile(s);
            Response.Flush();
            Response.Clear();
        }
        
        public string rupees_INR(Int64 rupees)
        {
            string result = "";
            Int64 res;
            if ((rupees / 10000000) > 0)
            {
                res = rupees / 10000000;
                rupees = rupees % 10000000;
                result = result + ' ' + rupeestowords_INR(res) + " Crore";
            }
            if ((rupees / 100000) > 0)
            {
                res = rupees / 100000;
                rupees = rupees % 100000;
                result = result + ' ' + rupeestowords_INR(res) + " Lakh";
            }
            if ((rupees / 1000) > 0)
            {
                res = rupees / 1000;
                rupees = rupees % 1000;
                result = result + ' ' + rupeestowords_INR(res) + " Thousand";
            }
            if ((rupees / 100) > 0)
            {
                res = rupees / 100;
                rupees = rupees % 100;
                result = result + ' ' + rupeestowords_INR(res) + " Hundred";
            }
            if ((rupees % 10) >= 0)
            {
                res = rupees % 100;
                result = result + " " + rupeestowords_INR(res);
            }
            result = result + ' ' + " Rupees only";
            return result;
        }

        public string rupeestowords_INR(Int64 rupees)
        {
            string result = "";
            if ((rupees >= 1) && (rupees <= 10))
            {
                if ((rupees % 10) == 1) result = "One";
                if ((rupees % 10) == 2) result = "Two";
                if ((rupees % 10) == 3) result = "Three";
                if ((rupees % 10) == 4) result = "Four";
                if ((rupees % 10) == 5) result = "Five";
                if ((rupees % 10) == 6) result = "Six";
                if ((rupees % 10) == 7) result = "Seven";
                if ((rupees % 10) == 8) result = "Eight";
                if ((rupees % 10) == 9) result = "Nine";
                if ((rupees % 10) == 0) result = "Ten";
            }
            if (rupees > 9 && rupees < 20)
            {
                if (rupees == 11) result = "Eleven";
                if (rupees == 12) result = "Twelve";
                if (rupees == 13) result = "Thirteen";
                if (rupees == 14) result = "Forteen";
                if (rupees == 15) result = "Fifteen";
                if (rupees == 16) result = "Sixteen";
                if (rupees == 17) result = "Seventeen";
                if (rupees == 18) result = "Eighteen";
                if (rupees == 19) result = "Nineteen";
            }
            if (rupees > 20 && (rupees / 10) == 2 && (rupees % 10) == 0) result = "Twenty";
            if (rupees > 20 && (rupees / 10) == 3 && (rupees % 10) == 0) result = "Thirty";
            if (rupees > 20 && (rupees / 10) == 4 && (rupees % 10) == 0) result = "Forty";
            if (rupees > 20 && (rupees / 10) == 5 && (rupees % 10) == 0) result = "Fifty";
            if (rupees > 20 && (rupees / 10) == 6 && (rupees % 10) == 0) result = "Sixty";
            if (rupees > 20 && (rupees / 10) == 7 && (rupees % 10) == 0) result = "Seventy";
            if (rupees > 20 && (rupees / 10) == 8 && (rupees % 10) == 0) result = "Eighty";
            if (rupees > 20 && (rupees / 10) == 9 && (rupees % 10) == 0) result = "Ninty";

            if (rupees > 20 && (rupees / 10) == 2 && (rupees % 10) != 0)
            {
                if ((rupees % 10) == 1) result = "Twenty One";
                if ((rupees % 10) == 2) result = "Twenty Two";
                if ((rupees % 10) == 3) result = "Twenty Three";
                if ((rupees % 10) == 4) result = "Twenty Four";
                if ((rupees % 10) == 5) result = "Twenty Five";
                if ((rupees % 10) == 6) result = "Twenty Six";
                if ((rupees % 10) == 7) result = "Twenty Seven";
                if ((rupees % 10) == 8) result = "Twenty Eight";
                if ((rupees % 10) == 9) result = "Twenty Nine";
            }
            if (rupees > 20 && (rupees / 10) == 3 && (rupees % 10) != 0)
            {
                if ((rupees % 10) == 1) result = "Thirty One";
                if ((rupees % 10) == 2) result = "Thirty Two";
                if ((rupees % 10) == 3) result = "Thirty Three";
                if ((rupees % 10) == 4) result = "Thirty Four";
                if ((rupees % 10) == 5) result = "Thirty Five";
                if ((rupees % 10) == 6) result = "Thirty Six";
                if ((rupees % 10) == 7) result = "Thirty Seven";
                if ((rupees % 10) == 8) result = "Thirty Eight";
                if ((rupees % 10) == 9) result = "Thirty Nine";
            }
            if (rupees > 20 && (rupees / 10) == 4 && (rupees % 10) != 0)
            {
                if ((rupees % 10) == 1) result = "Forty One";
                if ((rupees % 10) == 2) result = "Forty Two";
                if ((rupees % 10) == 3) result = "Forty Three";
                if ((rupees % 10) == 4) result = "Forty Four";
                if ((rupees % 10) == 5) result = "Forty Five";
                if ((rupees % 10) == 6) result = "Forty Six";
                if ((rupees % 10) == 7) result = "Forty Seven";
                if ((rupees % 10) == 8) result = "Forty Eight";
                if ((rupees % 10) == 9) result = "Forty Nine";
            }
            if (rupees > 20 && (rupees / 10) == 5 && (rupees % 10) != 0)
            {
                if ((rupees % 10) == 1) result = "Fifty One";
                if ((rupees % 10) == 2) result = "Fifty Two";
                if ((rupees % 10) == 3) result = "Fifty Three";
                if ((rupees % 10) == 4) result = "Fifty Four";
                if ((rupees % 10) == 5) result = "Fifty Five";
                if ((rupees % 10) == 6) result = "Fifty Six";
                if ((rupees % 10) == 7) result = "Fifty Seven";
                if ((rupees % 10) == 8) result = "Fifty Eight";
                if ((rupees % 10) == 9) result = "Fifty Nine";
            }
            if (rupees > 20 && (rupees / 10) == 6 && (rupees % 10) != 0)
            {
                if ((rupees % 10) == 1) result = "Sixty One";
                if ((rupees % 10) == 2) result = "Sixty Two";
                if ((rupees % 10) == 3) result = "Sixty Three";
                if ((rupees % 10) == 4) result = "Sixty Four";
                if ((rupees % 10) == 5) result = "Sixty Five";
                if ((rupees % 10) == 6) result = "Sixty Six";
                if ((rupees % 10) == 7) result = "Sixty Seven";
                if ((rupees % 10) == 8) result = "Sixty Eight";
                if ((rupees % 10) == 9) result = "Sixty Nine";
            }
            if (rupees > 20 && (rupees / 10) == 7 && (rupees % 10) != 0)
            {
                if ((rupees % 10) == 1) result = "Seventy One";
                if ((rupees % 10) == 2) result = "Seventy Two";
                if ((rupees % 10) == 3) result = "Seventy Three";
                if ((rupees % 10) == 4) result = "Seventy Four";
                if ((rupees % 10) == 5) result = "Seventy Five";
                if ((rupees % 10) == 6) result = "Seventy Six";
                if ((rupees % 10) == 7) result = "Seventy Seven";
                if ((rupees % 10) == 8) result = "Seventy Eight";
                if ((rupees % 10) == 9) result = "Seventy Nine";
            }
            if (rupees > 20 && (rupees / 10) == 8 && (rupees % 10) != 0)
            {
                if ((rupees % 10) == 1) result = "Eighty One";
                if ((rupees % 10) == 2) result = "Eighty Two";
                if ((rupees % 10) == 3) result = "Eighty Three";
                if ((rupees % 10) == 4) result = "Eighty Four";
                if ((rupees % 10) == 5) result = "Eighty Five";
                if ((rupees % 10) == 6) result = "Eighty Six";
                if ((rupees % 10) == 7) result = "Eighty Seven";
                if ((rupees % 10) == 8) result = "Eighty Eight";
                if ((rupees % 10) == 9) result = "Eighty Nine";
            }
            if (rupees > 20 && (rupees / 10) == 9 && (rupees % 10) != 0)
            {
                if ((rupees % 10) == 1) result = "Ninty One";
                if ((rupees % 10) == 2) result = "Ninty Two";
                if ((rupees % 10) == 3) result = "Ninty Three";
                if ((rupees % 10) == 4) result = "Ninty Four";
                if ((rupees % 10) == 5) result = "Ninty Five";
                if ((rupees % 10) == 6) result = "Ninty Six";
                if ((rupees % 10) == 7) result = "Ninty Seven";
                if ((rupees % 10) == 8) result = "Ninty Eight";
                if ((rupees % 10) == 9) result = "Ninty Nine";
            }
            return result;

        }
        public string RupeesToWords(Int64 rup)
        {
            string result = "";
            if ((rup >= 1) && (rup <= 10))
            {
                if ((rup % 10) == 1) result = "One";
                if ((rup % 10) == 2) result = "Two";
                if ((rup % 10) == 3) result = "Three";
                if ((rup % 10) == 4) result = "Four";
                if ((rup % 10) == 5) result = "Five";
                if ((rup % 10) == 6) result = "Six";
                if ((rup % 10) == 7) result = "Seven";
                if ((rup % 10) == 8) result = "Eight";
                if ((rup % 10) == 9) result = "Nine";
                if ((rup % 10) == 0) result = "Ten";
            }
            if (rup > 9 && rup < 20)
            {
                if (rup == 11) result = "Eleven";
                if (rup == 12) result = "Twelve";
                if (rup == 13) result = "Thirteen";
                if (rup == 14) result = "Fourteen";
                if (rup == 15) result = "Fifteen";
                if (rup == 16) result = "Sixteen";
                if (rup == 17) result = "Seventeen";
                if (rup == 18) result = "Eighteen";
                if (rup == 19) result = "Nineteen";
            }
            if (rup > 20 && (rup / 10) == 2 && (rup % 10) == 0) result = "Twenty";
            if (rup > 20 && (rup / 10) == 3 && (rup % 10) == 0) result = "Thirty";
            if (rup > 20 && (rup / 10) == 4 && (rup % 10) == 0) result = "Fourty";
            if (rup > 20 && (rup / 10) == 5 && (rup % 10) == 0) result = "Fifty";
            if (rup > 20 && (rup / 10) == 6 && (rup % 10) == 0) result = "Sixty";
            if (rup > 20 && (rup / 10) == 7 && (rup % 10) == 0) result = "Seventy";
            if (rup > 20 && (rup / 10) == 8 && (rup % 10) == 0) result = "Eighty";
            if (rup > 20 && (rup / 10) == 9 && (rup % 10) == 0) result = "Ninety";

            if (rup > 20 && (rup / 10) == 2 && (rup % 10) != 0)
            {
                if ((rup % 10) == 1) result = "Twenty One";
                if ((rup % 10) == 2) result = "Twenty Two";
                if ((rup % 10) == 3) result = "Twenty Three";
                if ((rup % 10) == 4) result = "Twenty Four";
                if ((rup % 10) == 5) result = "Twenty Five";
                if ((rup % 10) == 6) result = "Twenty Six";
                if ((rup % 10) == 7) result = "Twenty Seven";
                if ((rup % 10) == 8) result = "Twenty Eight";
                if ((rup % 10) == 9) result = "Twenty Nine";
            }
            if (rup > 20 && (rup / 10) == 3 && (rup % 10) != 0)
            {
                if ((rup % 10) == 1) result = "Thirty One";
                if ((rup % 10) == 2) result = "Thirty Two";
                if ((rup % 10) == 3) result = "Thirty Three";
                if ((rup % 10) == 4) result = "Thirty Four";
                if ((rup % 10) == 5) result = "Thirty Five";
                if ((rup % 10) == 6) result = "Thirty Six";
                if ((rup % 10) == 7) result = "Thirty Seven";
                if ((rup % 10) == 8) result = "Thirty Eight";
                if ((rup % 10) == 9) result = "Thirty Nine";
            }
            if (rup > 20 && (rup / 10) == 4 && (rup % 10) != 0)
            {
                if ((rup % 10) == 1) result = "Forty One";
                if ((rup % 10) == 2) result = "Forty Two";
                if ((rup % 10) == 3) result = "Forty Three";
                if ((rup % 10) == 4) result = "Forty Four";
                if ((rup % 10) == 5) result = "Forty Five";
                if ((rup % 10) == 6) result = "Forty Six";
                if ((rup % 10) == 7) result = "Forty Seven";
                if ((rup % 10) == 8) result = "Forty Eight";
                if ((rup % 10) == 9) result = "Forty Nine";
            }
            if (rup > 20 && (rup / 10) == 5 && (rup % 10) != 0)
            {
                if ((rup % 10) == 1) result = "Fifty One";
                if ((rup % 10) == 2) result = "Fifty Two";
                if ((rup % 10) == 3) result = "Fifty Three";
                if ((rup % 10) == 4) result = "Fifty Four";
                if ((rup % 10) == 5) result = "Fifty Five";
                if ((rup % 10) == 6) result = "Fifty Six";
                if ((rup % 10) == 7) result = "Fifty Seven";
                if ((rup % 10) == 8) result = "Fifty Eight";
                if ((rup % 10) == 9) result = "Fifty Nine";
            }
            if (rup > 20 && (rup / 10) == 6 && (rup % 10) != 0)
            {
                if ((rup % 10) == 1) result = "Sixty One";
                if ((rup % 10) == 2) result = "Sixty Two";
                if ((rup % 10) == 3) result = "Sixty Three";
                if ((rup % 10) == 4) result = "Sixty Four";
                if ((rup % 10) == 5) result = "Sixty Five";
                if ((rup % 10) == 6) result = "Sixty Six";
                if ((rup % 10) == 7) result = "Sixty Seven";
                if ((rup % 10) == 8) result = "Sixty Eight";
                if ((rup % 10) == 9) result = "Sixty Nine";
            }
            if (rup > 20 && (rup / 10) == 7 && (rup % 10) != 0)
            {
                if ((rup % 10) == 1) result = "Seventy One";
                if ((rup % 10) == 2) result = "Seventy Two";
                if ((rup % 10) == 3) result = "Seventy Three";
                if ((rup % 10) == 4) result = "Seventy Four";
                if ((rup % 10) == 5) result = "Seventy Five";
                if ((rup % 10) == 6) result = "Seventy Six";
                if ((rup % 10) == 7) result = "Seventy Seven";
                if ((rup % 10) == 8) result = "Seventy Eight";
                if ((rup % 10) == 9) result = "Seventy Nine";
            }
            if (rup > 20 && (rup / 10) == 8 && (rup % 10) != 0)
            {
                if ((rup % 10) == 1) result = "Eighty One";
                if ((rup % 10) == 2) result = "Eighty Two";
                if ((rup % 10) == 3) result = "Eighty Three";
                if ((rup % 10) == 4) result = "Eighty Four";
                if ((rup % 10) == 5) result = "Eighty Five";
                if ((rup % 10) == 6) result = "Eighty Six";
                if ((rup % 10) == 7) result = "Eighty Seven";
                if ((rup % 10) == 8) result = "Eighty Eight";
                if ((rup % 10) == 9) result = "Eighty Nine";
            }
            if (rup > 20 && (rup / 10) == 9 && (rup % 10) != 0)
            {
                if ((rup % 10) == 1) result = "Ninety One";
                if ((rup % 10) == 2) result = "Ninety Two";
                if ((rup % 10) == 3) result = "Ninety Three";
                if ((rup % 10) == 4) result = "Ninety Four";
                if ((rup % 10) == 5) result = "Ninety Five";
                if ((rup % 10) == 6) result = "Ninety Six";
                if ((rup % 10) == 7) result = "Ninety Seven";
                if ((rup % 10) == 8) result = "Ninety Eight";
                if ((rup % 10) == 9) result = "Ninety Nine";
            }
            return result;
        }

        public static string ConvertNumbertoWords(int number)
        {
            if (number == 0)
                return "ZERO";
            if (number < 0)
                return "minus " + ConvertNumbertoWords(Math.Abs(number));
            string words = "";
            if ((number / 1000000) > 0)
            {
                words += ConvertNumbertoWords(number / 1000000) + " MILLION ";
                number %= 1000000;
            }
            if ((number / 100000) > 0)
            {
                words += ConvertNumbertoWords(number / 100000) + " LAKH ";
                number %= 100000;
            }
            if ((number / 1000) > 0)
            {
                words += ConvertNumbertoWords(number / 1000) + " THOUSAND ";
                number %= 1000;
            }
            if ((number / 100) > 0)
            {
                words += ConvertNumbertoWords(number / 100) + " HUNDRED ";
                number %= 100;
            }
            if (number > 0)
            {
                //  if (words != "")
                // words += "AND ";
                var unitsMap = new[] { "ZERO", "ONE", "TWO", "THREE", "FOUR", "FIVE", "SIX", "SEVEN", "EIGHT", "NINE", "TEN", "ELEVEN", "TWELVE", "THIRTEEN", "FOURTEEN", "FIFTEEN", "SIXTEEN", "SEVENTEEN", "EIGHTEEN", "NINETEEN" };
                var tensMap = new[] { "ZERO", "TEN", "TWENTY", "THIRTY", "FORTY", "FIFTY", "SIXTY", "SEVENTY", "EIGHTY", "NINETY" };

                if (number < 20)
                    words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += " " + unitsMap[number % 10];
                }
            }
            return words;
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

            Response.Redirect("Logout.aspx");
        }
    }
}
