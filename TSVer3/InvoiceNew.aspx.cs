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
using ZXing;
using TSVer3.Modal;

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
        RedData response = new RedData();
        protected void Page_Load(object sender, EventArgs e)
        {
            EInvoiceAPI eInvoiceAPI = new EInvoiceAPI();
            response = eInvoiceAPI.GenerateIRNFromTaxPro();

            Session["CompanyCode"] = "CSHBLR"; Signature = "esge";
            string BillNo_ = "CSHLAI212200566"; // CSHLSE212200058A CSHLSI212200176  CSHLAE212200209 CSHLAI212200565
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

                    string qr = "iVBORw0KGgoAAAANSUhEUgAAAPoAAAD6CAYAAACI7Fo9AAAABGdBTUEAALGPC / xhBQAAAAFzUkdCAK7OHOkAAAAgY0hSTQAAeiYAAICEAAD6AAAAgOgAAHUwAADqYAAAOpgAABdwnLpRPAAAFPVJREFUeJztmNtuHDkMRPP / P737sEmAnVhdFxbHsVUFzEN3S2SR4hGc / Pinqqpvrx + fbaCqqn0V9Kq6QAW9qi5QQa + qC1TQq + oCFfSqukAFvaouUEGvqgtU0KvqAhX0qrpABb2qLlBBr6oLVNCr6gIV9Kq6QAW9qi5QQa + qC1TQq + oCFfSqukAFvaouUBz0Hz9 + WD + 03833uu70zK7bqge9Z + Oj / aiP0 / xqX7fOga3D7W9qPtV5d1XQD / HQc7qeFGhoP + rjNL / a161zYOtw + 5uaT3XeXa2B7q5ngUx9V / 29vp8ORmrQUgOuDpzaHxQn3U / Xp3oRqP1JrafjxgMW9IL + 4BvFKehfFHS1Ue7guQPnvk / 5Qj7V92oeF3i1LlWpvqk + 3LypfQW9oBd0op6pj4LOBgyBfnpGcdUGsqC4B4rExnUvgq18bNztZ + R7Wgd7 / qr / gl7QpfwF / dl3Qf8ZNx4wVBjbcPWXzqPWmao / Vcf0PNX62bjp + lG / 0Xc1v1on689VQQ / FU79P60 / VMT1PtX42brp + 1G / 0Xc2v1sn6c7UOuro + dTCuTzYfe / BsnNM + FzTVv3oBsfGm88D6Z32ieGwet19IBT2UD + 0r6M / +C7oXn9WXA139ve7vc5 +/ 07PLQ0oFvc99LuifJ7dBasPUfWw + FA / tY9dN / aO8rNh63f0oDtsftQ71fLdAnervc / RTBZ1bV9Cf / Rf0 / 7T + pzv6rg4G21h3cFIXSbpOJNW3C3r6vKa + 03nUvk77oM6Vq4Je0B / 7MPVb0D0 / aa2D7jaEbYzqCz2nBiwNkuozBRDKr66bgo76lapjej5sHtW3q4IO4hf05 / zquoLO7UvrbaCzB6geFPv + 9H0KsOtT3Z8aSNf / tG71vNP9Zy8cN457sbH5pyroBX2UH + 1DcQo6l3 + qNdBP79WDPe1HDU7nTdftvkf9UNe7AE4BckF2z5GVO1dbF0lKBb2gF3ShPnbdtwf9jwTiAJ7eqwOQyrN94WxfBGo / TutRPS7gKH7Kj + t7ev7Tc0ypoBf0gl7QB4HNwdouXG28u0 + 9WNTBU + Ow / UgNpAuCei6nvO6z60uN + 24V9JC / gs7FLejfBHQVGLVwdbBTF4x7QNN6UX73wmDzqOCxFwBbl5rXvahS / Um / T6mgF / THPAU94999n9Ia6Og9OxDTwUBxVUBSg8P6mIKL8k7jufHVetl9qs + pfzY + 63ML + IJe0Efx3PgFXfM11dtAR + vdg9sCEflj86t1uflYpQfcBc2N5wKG9rt9mV5YbF1TFXTTH5u / oGt + CvqO9iK / JhoW7l4A7kG5PlSgWd / qepSH9cPWx / bJPQfX//T81Plh87xbBb2gW+sKekH/LzBomHvA0/2neKf4p3XpPqA86sXiDjgbNzXAqf6rfUD72frcvrJ1pVTQC7rVh4L+nJfN/2VBVwcVrVPBmO5n/U3BQnHT8U9x0Hs2//aFdsrL+kvHmV4M7ndXBb2gP75n8xf0gv64jj3waSNd0NkDdeuZ9iF1wWzFV+tV17sXEOsX1e36RPWmVdALekF/yI/qvh706UC4+VA89sBUP+nBQHW6P7cOtk42/7ZPlAftO+1nv6txC7qYD8Ur6F4dbJ0F3Yv75UD/I4E5AGq803f2PVqH/LHv3fgnTetk47n+VP/pvOlznPpKnbuqgl7QqXiuP9V/Om9B/xl/LTJKvDQw7IWixkO+02C5F6Aah70Y2e9u39Q40wtJjY/ioPfTeFMVdDIe8l3QC/rT+28L+nRApsBuDZw6QNNBmOZNAan6Vr+nfW/Xn55jdq5dFXTTF5sX5VN9qXm3Bt1d/y7f2/Wn55ida1dv+8+40zNaz353G7sFsuuL7UPKD/t9ei7I79R/CuBpP9Q824D/zrOeoKAX9IIO+7Gtt/1nHNswdhCmA5F6PuVFfrZBQs/pCyoVz/WfBhL5R3Uh/64PVwW9oD/mK+ha3mtAVw/itB/FZRs8fa/6U+OhOtl1rn+0LxVPrSddN6vpXKTmJ62CHvanxkN1susKekF/0hro6FkF9rR/+737Y/sx7e/p+9QvewGk+pjyf+pT+nzUvrh1pFTQQ4OWHiS2v6fvadDYPK6PlP9Tn9Lno/bFrSOlt//pPt2XBiUNKntw6kGrPtX304F3/Z3iTNeh9Syop+9svunFkVJBL+hWnchXQf/moP+RwGzoaV3qoNk8qA6UR/XP5lHzovipC4T1jfKy39340z6zv5SfqQo6yIPqQHkKupeX/e7GL+jTgOaguI0/rUPr3YNC+5EP1qcbX62frY/V9IJR++b2/+QrFYeNz8aZqqAXdKo+VgVdi8/GmWrtb4VUg1wQ1DyqWF9ovepHjeteOG7daJ/bh/QcsHW475FP5C+tgl7QC/rCe+QT+Utr71//vxKYg68OHvs77WfzuFIvLrZO5FMFJH0hpc5D7X/Knwu+e/EUdDJ+QS/oSX8F/RTQHFx2v9p41e+03tP3VN3s+1N+9b17Du6FMb1YTu9Z/yi+C7jbn5QKekEf+VX9s/lYv+y+gp4OGGqo+pwe6JTP6UWg+nEHye3r1L+7nvWhanoBpM8hpYJ+iFPQCzoTp6Af3rsNUQdRXcf6ZfepdacGmAVE3eeCPQWZ9X/yg96zYs9BPcfUBQX9xwMW9IJe0G0/XxZ0FxA3rntxnPa7g63Wq8ZxLwDX57Tu7QsC9cHdd/LLvmfjTS8ipIIO9hf0gv6RX/Y9G+/Lgp4epOk+dQDcgdmOo9bJ5lfXse/Zuqbv2fjTi+m0buuCSqmgF3RrXUH/ON61oE8LSAHPDqh6QbE+2PrUOCp47gCj+t28KSDeda5oHRvvtG4L+IJe0Au6EAetY+Od1n050E/P7Hr3gKZAsAet1jH1Pa3XHbhU/9V1p32qXxdw15d6obl+ZZ/xgAXd2lfQufiq34L+M2484q/AYeBOcdVGq/nUuOk63UHZvjjYfSgvWufOBRsP1cnW5Z7Xu1TQC3q0HrZ/7LqCntF6RhXE6WBPB386yOz+rYuDFfIz9em+n56j23/0/iQ27meroBf0D5+nPt33BX1HcUcseG68Uxz1IFMXAPLN1sf6RnWo4Lv9Zeth30/nxgWXrdudp7/lIijoBb2gF3QjYBhk9SDUwWcHYTpoqQtr68JhfatgTvvv1jkFGK1jzyFV/1QFvaA/7ivoBf3jgGID2Pev36eDyPqexkFyQVEHOT3Ybl73gmBBUvuG3qM+sc/I97YKOvBd0J/rKujcM/K9rff/r8CrAbNQdt904KZ+VVBZAKbvXZ9uH05yL7K0/+kFpOZHvtMq6AV9tH6qgv5FQVcbhfanDlB9Vg9oClqqrmn/UZ1sfrUudy6m2poH9fu2CnpBf1RBL+gfBzQBURuqxlX9uxdOqh42Hptf/an5t/e565HYvrp1TecxpYI+9FfQC/qVoP8OTB4s2ofeT32wB4z2swCqedy61LjsQKr1qvHS/tMXA/I1nZ+ti6CgF/THutA61k9B5/J/GdDfNSBbvtOAunW78af+3XpQfBW8d/uf9l99fvecF3TTH4rjxi3oBX1D63+6qwWxA8QOgNrIFMhuHrZvLBiuf7W/bjzX//SCmPYf7UPr3q2CTuZHeQu6F6+gv0drf7pPf2y813Xv9ofyq/Wo+VLx02Co/Xf9ozyp80Bxp/HY+XVV0MPgoffpfKn4qJ+sDxcE1z/KkzoPFHcaj51fV+t/Q6iFqA1xBybll92nvkd5UF71wmD3scCj7+55or5ML4J31XPysQV8QR/6ZfcV9IL+rUBPDS4bbzoA6gWk1qEC514U6kCycdID+tn9V/Oq8dXzc/2oKugF/TFOQdfiXwu6epDoYFBDWV+sb3ZQ3uWHjeMO3Ou66cXDnhfalwZXrdsFdXoOKRV04LugF3Qm/rWgq4Cog3CKx+ZJ+XN9uz5Zf2pf2WfkU42zXYfaPzcOWw/rN62CXtALekE3ApJGtxqaAjl1UKlBYvuigqnGTQO7DSibh5Xan9TFMFVBL+gFvaAPApuDpQ6w6sPd78abHrwaH+VFcabgufFZ/+76d4Hvzu8W4L/jrwUu6KP9Bb2gJ7X2p7sLBHugKjBqPHYQVEBev5/8uPHdvqjgqnFZ0FR/U0BT55K6OLZU0At6QS/oRkBz4Ng4LLiqv+nBu+/ddad6UDy1bhVU1g8LxvQiUufPPdet7ykV9IJe0Av6ILB5MGj/FGS0Tv2uPk8HWh1cN47bB9eP65+9YFRNLzq0DuVLq6AX9EcV9ILOJQgNynSfenFsD6ILnurHBVpdl96nnldqH9tP9oJR122poBd0aX1BL+j/DywOdhpkNa56MbgDq/pA79k63f3uerWfKI7qUwWQ3XfS9PwLuhlfjVvQCzqz76TrQN8amJSv1OC5oLuDpQ6SWpf73s2ngqzGYf2weab1nvadntMq6MBnQfd8FvRLQHcbn2q4O3DqYKj1usAiufGn/Vb3uXmm/tlzQOtTfk7rt1TQC3pBJ/IW9NeAIQBcQFP+0H72uzuIbvzT+tRFoNbF1s36R2Ljp3xM46s+XBX0gv4Yp6B7/r896H8kCB/s9IJAPlww3MFn609dIOjH+j8pNajq+bjAuPOi9nU6L1MVdDE+W1dBn6mgZ7X/vwC/EoUKTg2umgf5PT2jfrB51XguCO561g/r163DnQckdl5SvtMq6AWdyl/QC7qXWDygdINVQNWDcde7F5Hq3/WrXhAoPpvfvRjYPrgXhtuvkwp6QafWs/5dvwW9oP8/cLgx7mB8NvhsfBdYdjCmdU4HGMVn87vgqBeNG4f1vdXPo/+1wAVdil/QufwF3VM88tSwCug0v3sxTDW9ANWLDuV3+zn1wcbd8n9an54jdv+WCnpBp/ywdRT0y0FngVJ/Kb/T/Opgpv2o+0/r2fdoXbrPqXlg62Gf3Trd+K4Keig/OwBbftT9p/Xse7Qu3efUPKiguefszk1qrv/wFY/4mkA8kHcDzr4/fWdBY/en86l1p8Gfxpv6VOdl6tvt/7YKOvn+9L2gF/Sn96f479ban+7qgZ/2n+K7eVP+VF/T+pBSFwvrJwWQ6le9IKYXD1vX1P+2CnpBp+JOfRb0WZ6p1kB/fWYLnA4mG8cdYLUOdzBRPnaAWf/bcdhzdOdDBWr63gV4+t1VQQf7Tt8LekG/GvTfgcUBYA9m68JQ/ak+2fWsUv1N55+uS/9UH6yvqf/Tvi0VdNNfQS/oE/+nfVta/9+AVIPRd/Zg3QuAjavWx/pI+d2Oh+K4fVKBYecG1TXNh+pCeVIq6AW9oD/UVdBPAclGp9dPgVQPXn3PHuR0YFI+2fes7xQw7sU09c/WlQI/rYJO7p++L+gFnYmzpTXQT89onwqce/CnOC7w00FBdangsvG3Lh4Ufwto1Xeq/6mLbEsFvaAX9IJuBBTBYQ9UHRi3wVN/qYtpCvr0gj3FSV8cLCCsH7b+9Dmc9qUuvqkKOohX0At6Qf8oIFmgWph68OxAvuvAkQ8U162Ljef6Pfl2B9sFfur3pOncsesL+iHuKU5BL+gF/YM61iK/JhoO3CkOO+jsILPvUR3serVv6sClLxLWhxo/5d/N62rqs6AX9Md61X5M/Rf0WV2n998O9N8JyYF4fWYHUf2O1k0Hnz1IdcDdAZ7Gceuegug+u3135yo1f2kVdLCuoHP7UR0F/RLQUwNwWnd6nvpl/av1qBeBGs+twxW7X+0X2s+uR89u/9l1WwCzKuhi3IL+7Mf1zcYr6J4+HfTTd7T/9f3pmY2P9qs+VH/TPKd9qi/1PYqr1ufWw8ZN98Ptl3u+rgr6YR1bB5uXje/mOe0r6Jy/gr4s9gDRPncg1fzuAG1fdCkQp4Oc9j+tS/WpSs178rEF+O98a5FZAwX9w3UoDvue9Yn8uj6m/gt6RvHIbAHb79X900GZ+lPjqz5QnvTgsxcK2uf2Wb3Qpj7cC5L9PlVBL+gFvaAHE4mNYde5Az8dBDXuFHi1P6mLwu27CqgbXwVkelG4FxHyU9ALekEv6GOt/el+ep8CQd2XGnT3gmDzuuC5daZAnfpIP6s/t86T2DxbYP/hJx6woBd0w0f6uaC/+FkLbA6sCpSaf+vA3wUUWxfbByQUH/lm62KVOvet+Ggd2relgl7QH1XQtfhoHdq3pf0MvxKFwGIPQgU9tQ75V31P900HburH7XP6fNi+TS8y1R8bf6qCXtALekE3AoYPeLsh6bzu4LgXgguqmt8ddNa3u1+t8xRPrcftw8lXQS/olt90/oJe0P8f0DwoFCc14GidC4A6eOqgbfln/U73T32heUJ+tubR9YPypFXQCzrld7q/oH9z0F1Q2Dzs+9P3KahsfHfdKW/qIkCa9ouNn+rnFEi37tR5bqmgF/RHFXSu7utA/yOB2Gi3Ae7Bqgeu5lWVAprNk3pG61xA2DlRNfWp+tk6R1YFvaBHntG6gv7NQf+dSAQiDSgLEFrn+p8OvNoXtQ62r+76lF8XUBXg6dxt911VQS/oUl/d9QX9EtBZpQ769Tt6RnFO+9l807wov+p/epGodbjn4+Zn47oXCOtP9b+lgl7Qre9qHQWd87+leGQW1OlgqgOl+jzFSx3I9MJCdUz9uxeQ2p+Uf/diQvvZfVv+UyroBf3RX0Hn9l0Lurs+XfBnXTxqPPaZrY/NN30/BcmtF+VDUv2rcdXv07zQVzxgQX9cd4rHPrP1sfmm7wv6sz/2+5cHHQ3i9Bm9Z78jv+4F4a5X/aX9u89qvW7/077c83T9q32ZqqAf1m0NBrte9Zf2vwVUqv9pX+55uv7Vvkz114GO3p/isvtYnykf6sCkB2MLGHUd8sPuP+VFeaZS/ap1bINf0IfxCnpBL+j/zEFXf6wP9j1ap/Zjq0+p9+zgsf7Y+KkLgPWpxk+BrvYtpYJe0B/zF3Rv33Wgq+vVgXPzuv7UdduDqcZNx5u+V7V1sZ3epy6Yz1ZBF/2p6wq6F387b0GfBgSNYgcODSJ7EOpgsxfK9OJh60PP6sCy9UzjpfKk61F9sPWxPtR+pFTQD+vZ+tA69ntB59YVdE9/z98WVVWtqaBX1QUq6FV1gQp6VV2ggl5VF6igV9UFKuhVdYEKelVdoIJeVReooFfVBSroVXWBCnpVXaCCXlUXqKBX1QUq6FV1gQp6VV2ggl5VF6igV9UFKuhVdYEKelVdoH8BhHW4szk6JxcAAAAASUVORK5CYIIAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=";
                             
                        byte[] qrImg = Convert.FromBase64String(response.QrCodeImage);
                        TypeConverter tc = TypeDescriptor.GetConverter(typeof(Bitmap));
                        Bitmap bitmap1 = (Bitmap)tc.ConvertFrom(qrImg);

                        XImage image_QRCode = XImage.FromGdiPlusImage(bitmap1);
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
