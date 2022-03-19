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
        /// <summary>
        /// Get the IRN & OR code from EInvoice API from TaxPRo
        /// </summary>
        /// <returns></returns>
        public IRNResponseModel GenerateIRNFromTaxPro()
        {
            IRNResponseModel iRNResponseModel = new IRNResponseModel();
            //get the auth token from API
             var authToken = GetAuthToken();
            try
            {
                EInvoiceDetailsModal jsonToSend = new EInvoiceDetailsModal();

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
                sellerDtls.Pin = 560016;
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
                buyerDtls.Pin = 600027;
                buyerDtls.Stdcd = "";
                buyerDtls.Ph = "";
                buyerDtls.Em = "";
                jsonToSend.BuyerDtls = buyerDtls;

                DispDtls dispDtls = new DispDtls();
                dispDtls.Nm = "C.S HAWKLER LOGISTICS PVT LTD";
                dispDtls.Addr1 = "ANIRUDDH No.6, 1st Cross, 6th Main, Kamadhenu Layout,";
                dispDtls.Addr2 = "B Narayanapura, Doorvarni Nagar(post)";
                dispDtls.Loc = "Bangalore";
                dispDtls.Pin = 560016;
                dispDtls.Stdcd = "";
                jsonToSend.DispDtls = dispDtls;

                ShipDtls shipDtls = new ShipDtls();
                shipDtls.Gstin = "33AATCA1244L1ZJ";
                shipDtls.LglNm = "AJ AERO SAIL XPRESS PRIVATE LIMITED";
                shipDtls.TrdNm = "AJ AERO SAIL XPRESS PRIVATE LIMITED";
                shipDtls.Addr1 = "NO 31, DR. AMBEDKAR STREET,";
                shipDtls.Addr2 = "MEENAMBAKKAM,";
                shipDtls.Loc = "CHENNAI";
                shipDtls.Pin = 600027;
                shipDtls.Stdcd = "";
                jsonToSend.ShipDtls = shipDtls;

                BchDtls bchDtls = new BchDtls();
                bchDtls.Nm = "33AATCA1244L1ZJ";
                bchDtls.ExpDt = "MEENAMBAKKAM,";
                bchDtls.wrDt = "MEENAMBAKKAM,";

                List<AttribDetails> attribDtls = new List<AttribDetails>();
                attribDtls.Add(new AttribDetails() { Nm = "33AATCA1244L1ZJ", Val = "MEENAMBAKKAM," });

                List<ItemList> itemLists = new List<ItemList>();
                itemLists.Add(new ItemList()
                {
                    SlNo = "1",
                    PrdDesc = "AIRLINE DELIVERY ORDER",
                    HsnCd = "9967",
                    TotAmt = "2800.00",
                    GstRt = "18",
                    IgstAmt = "504.00",
                    CgstAmt = "0",
                    SgstAmt = "0",
                    TotItemVal = "3304.00",
                    IsServc = "N",
                    Barcd = "",
                    Qty = 1,
                    FreQty = "BAG",
                    Unit = "1",
                    UnitPrice = "3304.00",
                    Discount = "0",
                    PreTaxVal = "2800.00",
                    AssAmt = "",
                    CesAmt = "",
                    CesRt = "",
                    CesNonAdvlAmt = "",
                    StateCesRt = "",
                    StateCesAmt = "",
                    StateCesNonAdvlAmt = "",
                    OthChrg = "",
                    OrdLineRef = "",
                    OrgCntry = "",
                    PrdSlNo = "PRD001",
                    BchDtls = bchDtls,
                    AttribDtls = attribDtls
                });
                jsonToSend.ItemList = itemLists;

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


                List<AddlDocDtls> addlDocDtls = new List<AddlDocDtls>();
                addlDocDtls.Add(new AddlDocDtls() { Url = "https://einv-apisandbox.nic.in", Docs = "Test Doc,", Info = "Doc Test," });
                jsonToSend.AddlDocDtls = addlDocDtls;

                ExpDtls expDtls = new ExpDtls();
                expDtls.ShipBNo = "A-124";
                expDtls.ShipBDt = "10/08/2022";
                expDtls.Port = "NMK";
                expDtls.RefClm = "N";
                expDtls.ForCur = "AED";
                expDtls.CntCode = "AE";
                jsonToSend.ExpDtls = expDtls;

                var json = JsonConvert.SerializeObject(jsonToSend);

                var client = new RestClient("https://gstsandbox.charteredinfo.com/eicore/dec/v1.03/Invoice?aspid=1677089922&password=Etrack@630&Gstin=34AACCC1596Q002&AuthToken=" + authToken.Data.AuthToken + "&user_name=TaxProEnvPON&QrCodeSize=250");
                client.Timeout = -1;
                var irnRequest = new RestRequest(Method.POST);

                irnRequest.AddParameter("application/json; charset=utf-8", json, ParameterType.RequestBody);
                irnRequest.RequestFormat = DataFormat.Json;

                IRestResponse response = client.Execute(irnRequest);
                iRNResponseModel = JsonConvert.DeserializeObject<IRNResponseModel>(response.Content);
            }
            catch (Exception ex)
            {
                throw ex;
            }    

            return iRNResponseModel;
        }


        public IRNResponseModel CancelIRNEInvoice()
        {
            IRNResponseModel iRNResponseModel = new IRNResponseModel();
            //get the auth token from API
            var authToken = GetAuthToken();
            try
            {
                var client = new RestClient("https://gstsandbox.charteredinfo.com/eicore/dec/v1.03/Invoice/Cancel?aspid=1677089922&password=Etrack@630&Gstin=34AACCC1596Q002&eInvPwd=abc34*&AuthToken=a6eyDn7Rj3DPTJ8TyZ3HvgMrw&user_name=TaxProEnvPON");
                client.Timeout = -1;
                var irnRequest = new RestRequest(Method.POST);

                var json = "";

                irnRequest.AddParameter("application/json; charset=utf-8", json, ParameterType.RequestBody);
                irnRequest.RequestFormat = DataFormat.Json;

                IRestResponse response = client.Execute(irnRequest);
                iRNResponseModel = JsonConvert.DeserializeObject<IRNResponseModel>(response.Content);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return iRNResponseModel;
        }

        /// <summary>
        /// Get the Auth token from taxpro for IRN generation
        /// </summary>
        /// <returns></returns>
        public AuthTokenModel GetAuthToken()
        {
            AuthTokenModel authTokenModel = new AuthTokenModel();
            try
            {
                var client = new RestClient("https://gstsandbox.charteredinfo.com/eivital/dec/v1.04/auth?&aspid=1677089922&password=Etrack@630&Gstin=34AACCC1596Q002&user_name=TaxProEnvPON&eInvPwd=abc34*");
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                IRestResponse response = client.Execute(request);
                authTokenModel = JsonConvert.DeserializeObject<AuthTokenModel>(response.Content);
            }
            catch (Exception ex)
            {
                throw ex;
            }            
            return authTokenModel;
        }
    }
}