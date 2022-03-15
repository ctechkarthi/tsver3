using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TSVer3.Modal
{
    public class EInvoiceModel
    {
        public class AuthTokenModel
        {
            public int Status { get; set; }
            public Data TokenData { get; set; }
            public string ErrorDetails { get; set; }
            public string InfoDtls { get; set; }
        }
        public class Data
        {
            public string ClientId { get; set; }
            public string UserName { get; set; }
            public string AuthToken { get; set; }
            public string Sek { get; set; }
            public DateTime TokenExpiry { get; set; }
        }
    }
}