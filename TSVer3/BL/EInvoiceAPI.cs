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
