using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using TSVer3;

namespace TSVer3
{
    public class Global : HttpApplication
    {
        public static string JobNo;
        public static string JobNo_Trace;
        public static string JobType;
        public static string Admin_Info = "info@tracksen.com";
        public static string SuperAdmin_Email;
        public const string From_EmailId = "info@tracksen.com";
        public static string EmailId = "info@tracksen.com";
        public static string Password = "Ctech@052";
        public static string Regards = "<br/><br/> Thank You,<br /> Help Desk,<br/> Tracksen.com <br/><br/>PLEASE DO NOT REPLY TO THIS MAIL. THIS IS A AUTO GENERATED MAIL AND REPLIES TO THIS EMAIL ID ARE NOT ATTENDED.<br /><br /> This message was sent from a notification-only, Please do not reply this message.<br /> Tracksen(www.tracksen.com) is not response for any type Job changes.";
        public static string Regards2 = "\n\n Thank You,\n Help Desk,\n Tracksen.com \n";
        public static string CreateByJob;
        public static string CreateDateJob;
        public static string Select_Default = "---Select---";
        public static string AirExport = "Air Export";
        public static string AirImport = "Air Import";
        public static string SeaExport = "Sea Export";
        public static string SeaImport = "Sea Import";
        //public static string _sortExpression;
        //public static string _sortDirection = "Ascending";
        //public static string[] _sort = new string[] { "Ascending", "Descending" };
        public static string _user;
        public static string airlinename_img;
        public static string barcodename_img;
        public static string pdfname;
        public static string Logout;
        public static string UserRole1;
        public static string Job_ActiveDays;
        public static string Job_CurrentDate;

        public static int SBCTaxStartId;
        public static int KKCTaxStartId;
        public enum assemblyattribute
        {
            AssemblyConfigurationAttribute = 0,
            AssemblyProductAttribute = 3
        };
        //  public static DataTable _dimensionTable = new DataTable();
      public static System.Data.DataTable _getDT2;
          public static System.Data.DataTable _getDT;
        public static System.Data.DataTable _getDTParticulars;
        public static System.Data.DataSet _getDS;
        public static System.Data.DataSet _getDS_Shipper;
        public static System.Data.DataSet _getDS_Consignee;
        public static System.Data.DataSet _getDS_CarriersAgent;
        public static System.Data.DataTable _getDT_Shipper;
        public static System.Data.DataTable _getDT_Consignee;
        public static System.Data.DataTable _getDT_CarriersAgent;
        public static System.Data.DataTable _getDT_Client;
        public static System.Data.DataTable _getDT_InvAddress;
        public static System.Data.DataSet _getDS_AS;
        public static System.Data.DataSet _getDS_SS;


        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            AuthConfig.RegisterOpenAuth();
            //RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown

        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs

        }
    }
}
