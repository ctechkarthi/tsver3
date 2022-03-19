using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Drawing;

namespace TSVer3.Modal
{
    public class AuthTokenModel
    {
        public int Status { get; set; }
        public Data Data { get; set; }
        public string ErrorDetails { get; set; }
        public string InfoDtls { get; set; }
        public int status_cd { get; set; }
        public Error Error { get; set; }
    }
    public class Error
    {
        public string error_cd { get; set; }
        public string message { get; set; }
    }

    public class Data
    {
        public string ClientId { get; set; }
        public string UserName { get; set; }
        public string AuthToken { get; set; }
        public string Sek { get; set; }
        public DateTime TokenExpiry { get; set; }
    }

    /// <summary>
    /// save the IRN response
    /// </summary>
    public class IRNResponseModel
    {
        public string AckNo { get; set; }
        public DateTime AtckD { get; set; }
        public string Irn { get; set; }
        public string SignedInvoice { get; set; }
        public string SignedQRCode { get; set; }
        public string QrCodeImage { get; set; }
        public string JwtIssuer { get; set; }
        public string Status { get; set; }
        public List<ErrDetails> ErrorDetails { get; set; }
    }
    public class ErrDetails
    {
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
    }

    /// <summary>
    /// pass the json data to generate the IRN number
    /// </summary>
    public class EInvoiceDetailsModal
    {
        public string Version { get; set; }
        public TranDtls TranDtls { get; set; }
        public DocDtls DocDtls { get; set; }
        public SellerDtls SellerDtls { get; set; }
        public BuyerDtls BuyerDtls { get; set; }
        public DispDtls DispDtls { get; set; }
        public ShipDtls ShipDtls { get; set; }
        public List<ItemList> ItemList { get; set; }      
        public ValDtls ValDtls { get; set; }
        public PayDtls PayDtls { get; set; }
        public RefDtls RefDtls { get; set; }
        public List<AddlDocDtls> AddlDocDtls { get; set; }
        public ExpDtls ExpDtls { get; set; }    
    }

    public class TranDtls
    {
        public string TaxSch { get; set; }
        public string SupTyp { get; set; }
        public string RegRev { get; set; }
        public string EcmGstin { get; set; }
        public string IgstOnIntra { get; set; }
    }

    public class DocDtls
    {
        public string Typ { get; set; }
        public string No { get; set; }
        public string Dt { get; set; }
    }

    public class SellerDtls
    {
        public string Gstin { get; set; }
        public string LglNm { get; set; }
        public string TrdNm { get; set; }
        public string Addr1 { get; set; }
        public string Addr2 { get; set; }
        public string Loc { get; set; }
        public int Pin { get; set; }
        public string Stcd { get; set; }
        public string Ph { get; set; }
        public string Em { get; set; }
    }

    public class BuyerDtls
    {
        public string Gstin { get; set; }
        public string LglNm { get; set; }
        public string TrdNm { get; set; }
        public string Pos { get; set; }
        public string Addr1 { get; set; }
        public string Addr2 { get; set; }
        public string Loc { get; set; }
        public int Pin { get; set; }
        public string Stcd { get; set; }
        public string Ph { get; set; }
        public string Em { get; set; }
    }

    public class DispDtls
    {
        public string Nm { get; set; }
        public string Addr1 { get; set; }
        public string Addr2 { get; set; }
        public string Loc { get; set; }
        public int Pin { get; set; }
        public string Stcd { get; set; }
    }

    public class ShipDtls
    {
        public string Gstin { get; set; }
        public string LglNm { get; set; }
        public string TrdNm { get; set; }
        public string Addr1 { get; set; }
        public string Addr2 { get; set; }
        public string Loc { get; set; }
        public int Pin { get; set; }
        public string Stcd { get; set; }
    }

    public class ItemList
    {
        public string SlNo { get; set; }
        public string PrdDesc { get; set; }
        public string IsServc { get; set; }
        public string HsnCd { get; set; }
        public string Barcd { get; set; }
        public decimal Qty { get; set; }
        public string FreQty { get; set; }
        public string Unit { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotAmt { get; set; }
        public decimal Discount { get; set; }
        public decimal PreTaxVal { get; set; }
        public decimal AssAmt { get; set; }
        public decimal GstRt { get; set; }
        public decimal IgstAmt { get; set; }
        public decimal CgstAmt { get; set; }
        public decimal SgstAmt { get; set; }
        public decimal CesRt { get; set; }
        public decimal CesAmt { get; set; }
        public decimal CesNonAdvlAmt { get; set; }
        public decimal StateCesRt { get; set; }
        public decimal StateCesAmt { get; set; }
        public decimal StateCesNonAdvlAmt { get; set; }
        public decimal OthChrg { get; set; }
        public decimal TotItemVal { get; set; }
        public string OrdLineRef { get; set; }
        public string OrgCntry { get; set; }
        public string PrdSlNo { get; set; }
        public BchDtls BchDtls { get; set; }
        public List<AttribDetails> AttribDtls { get; set; }
    }

    public class BchDtls
    {
        public string Nm { get; set; }
        public string ExpDt { get; set; }
        public string wrDt { get; set; }
    }

    public class AttribDetails
    {
        public string Nm { get; set; }
        public string Val { get; set; }
    }

    public class ValDtls
    {
        public decimal AssVal { get; set; }
        public decimal CgsVal { get; set; }
        public decimal SgsVal { get; set; }
        public decimal IgstVal { get; set; }
        public decimal CesVal { get; set; }
        public decimal StCesVal { get; set; }
        public decimal Discount { get; set; }
        public decimal OtherChrg { get; set; }
        public decimal RndOffAmt { get; set; }
        public decimal TotInvVal { get; set; }
        public decimal TotInvValFc { get; set; }
    }

    public class PayDtls
    {
        public string Nm { get; set; }
        public string Accdet { get; set; }
        public string Mode { get; set; }
        public string Fininsbr { get; set; }
        public string Payterm { get; set; }
        public string Payinstr { get; set; }
        public string Crtrn { get; set; }
        public string Dirdr { get; set; }
        public int Crday { get; set; }
        public decimal Paidamt { get; set; }
        public decimal Paymtdue { get; set; }    
    }

    public class RefDtls
    {
        public string InvRm { get; set; }
        public DocPerdDtls DocPerdDtls { get; set; }
        public List<PrecDocDtls> PrecDocDtls { get; set; }
        public List<ContrDtls> ContrDtls { get; set; }
    }

    public class DocPerdDtls
    {
        public string InvStDt { get; set; }
        public string InvEndDt { get; set; }
    }

    public class PrecDocDtls
    {
        public string InvNo { get; set; }
        public string InvDt { get; set; }
        public string OthRefNo { get; set; }
    }

    public class ContrDtls
    {
        public string RecAdvRefr { get; set; }
        public string RecAdvDt { get; set; }
        public string Tendrefr { get; set; }
        public string Contrrefr { get; set; }
        public string Extrefr { get; set; }
        public string Projrefr { get; set; }
        public string Porefr { get; set; }
        public string PoRefDt { get; set; }
    }

    public class AddlDocDtls
    {
        public string Url { get; set; }
        public string Docs { get; set; }
        public string Info { get; set; }
    }

    public class ExpDtls
    {
        public string ShipBNo { get; set; }
        public string ShipBDt { get; set; }
        public string Port { get; set; }
        public string RefClm { get; set; }
        public string ForCur { get; set; }
        public string CntCode { get; set; }
    }

    public class EwbDtls
    {
        public string Distance { get; set; }
        public string TransMode { get; set; }
        public string TransId { get; set; }
        public string TransName { get; set; }
        public string TrnDocDt { get; set; }
        public string TrnDocNo { get; set; }
        public string VehNo { get; set; }
        public string VehType { get; set; }
    }

    public class InvCancel
    {
        public string Irn { get; set; }
        public string CnlRsn { get; set; }
        public string CnlRem { get; set; }
    }
}
