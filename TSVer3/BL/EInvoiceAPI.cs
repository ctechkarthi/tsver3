using System;
using System.Collections.Generic;
using System.Linq;
using RestSharp;
using System.Web;
using TSVer3.Modal;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace TSVer3.BL
{
    public class EInvoiceAPI
    {
        public AuthTokenModel GetAuthToken()
        {
            AuthTokenModel authTokenModel = new AuthTokenModel();

            var client = new RestClient("https://gstsandbox.charteredinfo.com/eivital/dec/v1.04/auth?&aspid=1677089922&password=Etrack@630&Gstin=34AACCC1596Q002&user_name=TaxProEnvPON&eInvPwd=abc34*");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            authTokenModel = JsonConvert.DeserializeObject<AuthTokenModel>(response.Content);
           
            EInvoiceDetailsModal jsonToSend = new EInvoiceDetailsModal();

            Version ver = new Version();
            jsonToSend.Version = "1.1";

            TranDtls tranDtls = new TranDtls();
            tranDtls.TaxSch = "GST";
            tranDtls.SupTyp = "B2B";
            tranDtls.RegRev = "Y";
            tranDtls.EcmGstin = null;
            tranDtls.IgstOnIntra = "N";
            jsonToSend.TranDtls = tranDtls;

            DocDtls doctls = new DocDtls();
            doctls.Typ = "INV";
            doctls.No = "CSHLAI2122005654";
            doctls.Dt = "17-Mar-2022";
            jsonToSend.DocDtls = doctls;

            SellerDtls sellerDtls = new SellerDtls();
            sellerDtls.Gstin = "29AAGCC3874M1Z1";
            sellerDtls.LglNm = "C.S HAWKLER LOGISTICS PVT LTD";
            sellerDtls.TrdNm = "C.S HAWKLER LOGISTICS PVT LTD";
            sellerDtls.Addr1 = "ANIRUDDH No.6, 1st Cross, 6th Main, Kamadhenu Layout,";
            sellerDtls.Addr2 = "B Narayanapura, Doorvarni Nagar(post)";
            sellerDtls.Loc = "Bangalore";
            sellerDtls.Pin = "560016";
            sellerDtls.Stdcd = "";
            sellerDtls.Ph = "";
            sellerDtls.Em = "accounts.blr@cshawkler.com";
            jsonToSend.SellerDtls = sellerDtls;

            BuyerDtls buyerDtls = new BuyerDtls();
            buyerDtls.Gstin = "33AATCA1244L1ZJ";
            buyerDtls.LglNm = "AJ AERO SAIL XPRESS PRIVATE LIMITED";
            buyerDtls.TrdNm = "AJ AERO SAIL XPRESS PRIVATE LIMITED";
            buyerDtls.Addr1 = "NO 31, DR. AMBEDKAR STREET,";
            buyerDtls.Addr2 = "MEENAMBAKKAM,";
            buyerDtls.Loc = "CHENNAI";
            buyerDtls.Pin = "600027";
            buyerDtls.Stdcd = "";
            buyerDtls.Ph = "";
            buyerDtls.Em = "";
            jsonToSend.BuyerDtls = buyerDtls;

            DispDtls dispDtls = new DispDtls();
            dispDtls.Nm = "C.S HAWKLER LOGISTICS PVT LTD";
            dispDtls.Addr1 = "ANIRUDDH No.6, 1st Cross, 6th Main, Kamadhenu Layout,";
            dispDtls.Addr2 = "B Narayanapura, Doorvarni Nagar(post)";
            dispDtls.Loc = "Bangalore";
            dispDtls.Pin = "560016";
            dispDtls.Stdcd = "";
            jsonToSend.DispDtls = dispDtls;

            ShipDtls shipDtls = new ShipDtls();
            shipDtls.Gstin = "33AATCA1244L1ZJ";
            shipDtls.LglNm = "AJ AERO SAIL XPRESS PRIVATE LIMITED";
            shipDtls.TrdNm = "AJ AERO SAIL XPRESS PRIVATE LIMITED";
            shipDtls.Addr1 = "NO 31, DR. AMBEDKAR STREET,";
            shipDtls.Addr2 = "MEENAMBAKKAM,";
            shipDtls.Loc = "CHENNAI";
            shipDtls.Pin = "600027";
            shipDtls.Stdcd = "";
            jsonToSend.ShipDtls = shipDtls;
           
            //jsonToSend.ItemList.Add(new ItemList() { SlNo="1", PrdDesc = "AIRLINE DELIVERY ORDER", HsnCd = "9967", TotAmt = "2800.00", GstRt = "18", IgstAmt = "504.00", CgstAmt = "0", SgstAmt = "0", TotItemVal = "3304.00" });

            ValDtls valDtls = new ValDtls();
            valDtls.AssVal = "9978.84";
            valDtls.CgsVal = "0";
            valDtls.SgsVal = "0";
            valDtls.IgstVal = "1197.46";
            valDtls.CesVal = "508.94";
            valDtls.StCesVal = "1202.46";
            valDtls.Discount = "10";
            valDtls.OtherChrg = "20";
            valDtls.RndOffAmt = "0.3";
            valDtls.TotInvVal = "12908";
            valDtls.TotInvValFc = "12897.7";
            jsonToSend.ValDtls = valDtls;

            PayDtls payDtls = new PayDtls();
            payDtls.Nm = "ABCDE";
            payDtls.Accdet = "5697389713210";
            payDtls.Mode = "Cash";
            payDtls.Fininsbr = "SBIN11000";
            payDtls.Payterm = "100,";
            payDtls.Payinstr = "Gift";
            payDtls.Crtrn = "test";
            payDtls.Dirdr = "test";
            payDtls.Crday = "test";
            payDtls.Paidamt = "10000";
            payDtls.Paymtdue = "500";
            jsonToSend.PayDtls = payDtls;
                      
            //BchDtls bchDtls = new BchDtls();
            //bchDtls.Nm = "33AATCA1244L1ZJ";
            //bchDtls.ExpDt = "MEENAMBAKKAM,";
            //bchDtls.WrDt = "MEENAMBAKKAM,";
            //jsonToSend.BchDtls = bchDtls;
            
            //AttribDtls attribDtls = new AttribDtls();
            //attribDtls.Nm = "33AATCA1244L1ZJ";
            //attribDtls.Val = "MEENAMBAKKAM,";
            //jsonToSend.AttribDtls = attribDtls;

            AddlDocDtls addlDocDtls = new AddlDocDtls();
            addlDocDtls.Url = "https://einv-apisandbox.nic.in";
            addlDocDtls.Docs = "Test Doc,";
            addlDocDtls.Info = "Doc Test,";
            jsonToSend.AddlDocDtls = addlDocDtls;

            ExpDtls expDtls = new ExpDtls();
            expDtls.ShipBNo = "A-124";
            expDtls.ShipBDt = "10/08/2022";
            expDtls.Port = "NMK";
            expDtls.RefClm = "N";
            expDtls.ForCur = "AED";
            expDtls.CntCode = "AE";
            jsonToSend.ExpDtls = expDtls;

            EwbDtls ewbDtls = new EwbDtls();
            ewbDtls.Distance = "0";
            ewbDtls.TransMode = "1";
            ewbDtls.TransId = "1";
            ewbDtls.TransName = "test";
            ewbDtls.TrnDocDt = "12";
            ewbDtls.TrnDocNo = "123";
            ewbDtls.VehNo = "KA12ER1234";
            ewbDtls.VehType = "R";
            jsonToSend.EwbDtls = ewbDtls;

            var json = JsonConvert.SerializeObject(jsonToSend);

            var client1 = new RestClient("https://gstsandbox.charteredinfo.com/eicore/dec/v1.03/Invoice?aspid=1677089922&password=Etrack@630&Gstin=34AACCC1596Q002&AuthToken=" + authTokenModel.Data.AuthToken + "&user_name=TaxProEnvPON");
            client1.Timeout = -1;
            var request1 = new RestRequest(Method.PUT);
            
            request1.AddParameter("application/json; charset=utf-8", json, ParameterType.RequestBody);
            request1.RequestFormat = DataFormat.Json;

            IRestResponse response1 = client.Execute(request1);
            authTokenModel = JsonConvert.DeserializeObject<AuthTokenModel>(response1.Content);
            
            // HttpWebRequest request = (HttpWebRequest)WebRequest.Create(@"https://gstsandbox.charteredinfo.com/eivital/dec/v1.04/auth?&aspid=1677089922&password=Etrack@360&Gstin=34AACCC1596Q002&user_name=TaxProEnvPON&eInvPwd=abc34*");
            //request.Method = "GET";
            //request.ContentType = "application/json";
            //WebResponse response = request.GetResponse();
            //using (var reader = new StreamReader(response.GetResponseStream()))
            // {
            //    var ApiStatus = reader.ReadToEnd();
            //    authTokenModel = JsonConvert.DeserializeObject<AuthTokenModel>(ApiStatus);
            //}  
            return authTokenModel;
        }
    }
}
