using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Data;
using System.Configuration;
using System.Data.Sql;
using System.Data.SqlClient;

namespace TSVer3.BL
{
    public class BusLayer // : ApiController
    {
        #region class
       // public static string connection = ConfigurationManager.ConnectionStrings["TracksenConnectionString"].ConnectionString;
        DataSet getDS = new DataSet();
        DataTable getDT = new DataTable();
        public static string connection = "Data Source=43.255.152.25; Initial Catalog=tscsh; Persist Security Info=True; User ID=tsadmin; Password=Ecoaltis@99; Timeout=180;";
       //  public static string connection = "Data Source=THEERTHESHA; Initial Catalog=trackoff; Persist Security Info=True; User ID=sa; Password=CSHAdmin@16;";
       #endregion

        //Login
        public SqlDataReader Login_Verify(string Email, string Password)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_Login";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", DBNull.Value);
            cmd.Parameters.AddWithValue("@Company", DBNull.Value);
            cmd.Parameters.AddWithValue("@Name", DBNull.Value);
            cmd.Parameters.AddWithValue("@Password", Password);
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@UserRole", DBNull.Value);
            cmd.Parameters.AddWithValue("@Active", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "SelectLogin");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }

        public SqlDataReader Login_Name(string CCode)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_Login";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@Company", DBNull.Value);
            cmd.Parameters.AddWithValue("@Name", DBNull.Value);
            cmd.Parameters.AddWithValue("@Password", DBNull.Value);
            cmd.Parameters.AddWithValue("@Email", DBNull.Value);
            cmd.Parameters.AddWithValue("@UserRole", DBNull.Value);
            cmd.Parameters.AddWithValue("@Active", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "SelectName");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }

        public SqlDataReader Login_VerifyActive(string Email, string Active)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_Login";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", DBNull.Value);
            cmd.Parameters.AddWithValue("@Company", DBNull.Value);
            cmd.Parameters.AddWithValue("@Name", DBNull.Value);
            cmd.Parameters.AddWithValue("@Password", DBNull.Value);
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@UserRole", DBNull.Value);
            cmd.Parameters.AddWithValue("@Active", Active);
            cmd.Parameters.AddWithValue("@StatementType", "SelectActiveLogin");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }

        public bool LoginPassword_Update(string CCode, string Email, string Password)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_Login";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@Company", DBNull.Value);
            cmd.Parameters.AddWithValue("@Name", DBNull.Value);
            cmd.Parameters.AddWithValue("@Password", Password);
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@UserRole", DBNull.Value);
            cmd.Parameters.AddWithValue("@Active", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "UpdatePassword");
            int InsertCnt = cmd.ExecuteNonQuery();
            conn.Close();
            return InsertCnt > 0 ? true : false;
        }

        //SCon Users
        public SqlDataReader SC_AllUsers(string CCode)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_SCDetails";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@Type", DBNull.Value);
            cmd.Parameters.AddWithValue("@CompName", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "SelectSCCAll");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }

        public SqlDataReader SC_Category(string CCode, string Type)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_SCDetails";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@Type", Type);
            cmd.Parameters.AddWithValue("@CompName", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "SelectALL");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }

        public SqlDataReader SC_Category_Company(string CCode, string Type, string CompName)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_SCDetails";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@Type", Type);
            cmd.Parameters.AddWithValue("@CompName", CompName);
            cmd.Parameters.AddWithValue("@StatementType", "SelectCompany");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }

        public bool SC_Details_New(string CCode, string Type, string CompName, string ContactName, string Line2, string Line3, string Line4, string Line5, string Line6, string Email, string GSTNo, string StateCode, string State, string PAN, string CreateBy, string CreateDate)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_SCDetailsChanges";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", 0);
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@Type", Type);
            cmd.Parameters.AddWithValue("@CompName", CompName);
            cmd.Parameters.AddWithValue("@ContactName", ContactName);
            cmd.Parameters.AddWithValue("@Line2", Line2);
            cmd.Parameters.AddWithValue("@Line3", Line3);
            cmd.Parameters.AddWithValue("@Line4", Line4);
            cmd.Parameters.AddWithValue("@Line5", Line5);
            cmd.Parameters.AddWithValue("@Line6", Line6);
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@State", State);
            cmd.Parameters.AddWithValue("@StateCode", StateCode);
            cmd.Parameters.AddWithValue("@GSTNo", GSTNo);
            cmd.Parameters.AddWithValue("@PAN", PAN);
            cmd.Parameters.AddWithValue("@CreateBy", CreateBy);
            cmd.Parameters.AddWithValue("@CreateDate", CreateDate);
            cmd.Parameters.AddWithValue("@ModifyBy", DBNull.Value);
            cmd.Parameters.AddWithValue("@ModifyDate", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "Insert");
            int InsertCnt = cmd.ExecuteNonQuery();
            conn.Close();
            return InsertCnt > 0 ? true : false;
        }


        public bool SC_Details_Update(int Id, string CCode, string Type, string CompName, string ContactName, string Line2, string Line3, string Line4, string Line5, string Line6, string Email, string GSTNo, string StateCode, string State, string PAN, string ModifyBy, string ModifyDate)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_SCDetailsChanges";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@Type", Type);
            cmd.Parameters.AddWithValue("@CompName", CompName);
            cmd.Parameters.AddWithValue("@ContactName", ContactName);
            cmd.Parameters.AddWithValue("@Line2", Line2);
            cmd.Parameters.AddWithValue("@Line3", Line3);
            cmd.Parameters.AddWithValue("@Line4", Line4);
            cmd.Parameters.AddWithValue("@Line5", Line5);
            cmd.Parameters.AddWithValue("@Line6", Line6);
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@State", State);
            cmd.Parameters.AddWithValue("@StateCode", StateCode);
            cmd.Parameters.AddWithValue("@GSTNo", GSTNo);
            cmd.Parameters.AddWithValue("@PAN", PAN);
            cmd.Parameters.AddWithValue("@CreateBy", DBNull.Value);
            cmd.Parameters.AddWithValue("@CreateDate", DBNull.Value);
            cmd.Parameters.AddWithValue("@ModifyBy", ModifyBy);
            cmd.Parameters.AddWithValue("@ModifyDate", ModifyDate);
            cmd.Parameters.AddWithValue("@StatementType", "Update");
            int InsertCnt = cmd.ExecuteNonQuery();
            conn.Close();
            return InsertCnt > 0 ? true : false;
        }

        public bool SC_Details_Delete(int Id, string CCode)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_SCDetailsChanges";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@Type", DBNull.Value);
            cmd.Parameters.AddWithValue("@CompName", DBNull.Value);
            cmd.Parameters.AddWithValue("@ContactName", DBNull.Value);
            cmd.Parameters.AddWithValue("@Line2", DBNull.Value);
            cmd.Parameters.AddWithValue("@Line3", DBNull.Value);
            cmd.Parameters.AddWithValue("@Line4", DBNull.Value);
            cmd.Parameters.AddWithValue("@Line5", DBNull.Value);
            cmd.Parameters.AddWithValue("@Line6", DBNull.Value);
            cmd.Parameters.AddWithValue("@Email", DBNull.Value);
            cmd.Parameters.AddWithValue("@State", DBNull.Value);
            cmd.Parameters.AddWithValue("@StateCode", DBNull.Value);
            cmd.Parameters.AddWithValue("@GSTNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@PAN", DBNull.Value);
            cmd.Parameters.AddWithValue("@CreateBy", DBNull.Value);
            cmd.Parameters.AddWithValue("@CreateDate", DBNull.Value);
            cmd.Parameters.AddWithValue("@ModifyBy", DBNull.Value);
            cmd.Parameters.AddWithValue("@ModifyDate", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "Delete");
            int InsertCnt = cmd.ExecuteNonQuery();
            conn.Close();
            return InsertCnt > 0 ? true : false;
        }

        //AirJob

        public SqlDataReader ARefJob_DetailsTOP50(string CCode)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_AirJob";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@JobNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@Category", DBNull.Value);
            cmd.Parameters.AddWithValue("@HAWB", DBNull.Value);
            cmd.Parameters.AddWithValue("@MAWB", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "SelectCompanyWiseTop");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }

        public SqlDataReader ARefJob_Details_Report(string CCode)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_AirJob";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@JobNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@Category", DBNull.Value);
            cmd.Parameters.AddWithValue("@HAWB", DBNull.Value);
            cmd.Parameters.AddWithValue("@MAWB", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "SelectCompanyWiseReport");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }

        public SqlDataReader ARefJob_Details_Report1(string CCode)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_AirJob";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@JobNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@Category", DBNull.Value);
            cmd.Parameters.AddWithValue("@HAWB", DBNull.Value);
            cmd.Parameters.AddWithValue("@MAWB", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "SelectReportClientWise");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }
        public SqlDataReader ARefJob_CategoryWise(string CCode, string Category)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_AirJob";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@JobNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@Category", Category);
            cmd.Parameters.AddWithValue("@HAWB", DBNull.Value);
            cmd.Parameters.AddWithValue("@MAWB", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "SelectJobCategory");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }

        public SqlDataReader ARefJob_CategoryWise_NonGenBill(string CCode)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_AirJob";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@JobNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@Category", DBNull.Value);
            cmd.Parameters.AddWithValue("@HAWB", DBNull.Value);
            cmd.Parameters.AddWithValue("@MAWB", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "SelectJobCategoryNonGenBill");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }

        public SqlDataReader AirRefJob_JobWise(string CCode, string JobNo)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_AirJob";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@JobNo", JobNo);
            cmd.Parameters.AddWithValue("@Category", DBNull.Value);
            cmd.Parameters.AddWithValue("@HAWB", DBNull.Value);
            cmd.Parameters.AddWithValue("@MAWB", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "SelectJob"); //
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }

        public SqlDataReader AirRefJob_JobWiseDetails(string CCode, string JobNo)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_AirJob";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@JobNo", JobNo);
            cmd.Parameters.AddWithValue("@Category", DBNull.Value);
            cmd.Parameters.AddWithValue("@HAWB", DBNull.Value);
            cmd.Parameters.AddWithValue("@MAWB", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "SelectJobDetails");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }

        public SqlDataReader ARefJob1_OrgWise(string Org)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_AirJob";
            cmd.CommandType = CommandType.StoredProcedure;
            // cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@Type", DBNull.Value);
            cmd.Parameters.AddWithValue("@CompName", DBNull.Value);
            cmd.Parameters.AddWithValue("@ContactName", DBNull.Value);
            cmd.Parameters.AddWithValue("@Line2", DBNull.Value);
            cmd.Parameters.AddWithValue("@Line3", DBNull.Value);
            cmd.Parameters.AddWithValue("@Line4", DBNull.Value);
            cmd.Parameters.AddWithValue("@Line5", DBNull.Value);
            cmd.Parameters.AddWithValue("@Line6", DBNull.Value);
            cmd.Parameters.AddWithValue("@Email", DBNull.Value);
            cmd.Parameters.AddWithValue("@CreateBy", DBNull.Value);
            cmd.Parameters.AddWithValue("@CreateDate", DBNull.Value);
            cmd.Parameters.AddWithValue("@ModifyBy", DBNull.Value);
            cmd.Parameters.AddWithValue("@ModifyDate", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "Select");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }

        public SqlDataReader AirRefJob_JobWise_MAWBNo(string CCode, string AWBNo)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_AirJob";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@JobNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@Category", DBNull.Value);
            cmd.Parameters.AddWithValue("@HAWB", DBNull.Value);
            cmd.Parameters.AddWithValue("@MAWB", AWBNo);
            cmd.Parameters.AddWithValue("@StatementType", "SelectMAWBWise");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }

        public SqlDataReader AirRefJob_JobWise_HAWBNo(string CCode, string AWBNo)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_AirJob";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@JobNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@Category", DBNull.Value);
            cmd.Parameters.AddWithValue("@HAWB", AWBNo);
            cmd.Parameters.AddWithValue("@MAWB", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "SelectHAWBWise");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }

        public bool AirJob_New(string CCode, string JobNo, string RefNo, string ShipperInvNo, string Category, string MAWB, string HAWB, string Client, string Org, string OCnt, string Dest, string DCnt, string To1, string T1Cnt, string A1, string A1Code, string A1Dt, string A2, string A2Code, string A2Dt, string Shipperl1, string Shipperl2, string Shipperl3, string Shipperl4, string Shipperl5, string Shipperl6, string Consigneel1, string Consigneel2, string Consigneel3, string Consigneel4, string Consigneel5, string Consigneel6, string Carrierl1, string Carrierl2, string Carrierl3, string Carrierl4, string Carrierl5, string Carrierl6, string IATA, string Freight, string Curr, string Ins, string Pieces, string GW, string CW, string Rate, string Total, string Commodity, string Nature, string Dimn, string Notify, string TAmt, string SBNo, string SBDt, string InvNo, string InvDt, string IEC, string BillNo, string BillDt, string BillAmt, string IGMNo, string IGMDt, string Status, string CloseDt, string Remarks, string Active, string CreateDt, string CreateBy)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_AirJobChanges";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", 0);
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@Company", DBNull.Value);
            cmd.Parameters.AddWithValue("@JobNo", JobNo);
            cmd.Parameters.AddWithValue("@RefNo", RefNo);
            cmd.Parameters.AddWithValue("@ShipperInvNo", ShipperInvNo);
            cmd.Parameters.AddWithValue("@Category", Category);
            cmd.Parameters.AddWithValue("@MAWB", MAWB);
            cmd.Parameters.AddWithValue("@HAWB", HAWB);
            cmd.Parameters.AddWithValue("@Client", Client);
            cmd.Parameters.AddWithValue("@Org", Org);
            cmd.Parameters.AddWithValue("@OCnt", OCnt);
            cmd.Parameters.AddWithValue("@Dest", Dest);
            cmd.Parameters.AddWithValue("@DCnt", DCnt);
            cmd.Parameters.AddWithValue("@To1", To1);
            cmd.Parameters.AddWithValue("@T1Cnt", T1Cnt);
            cmd.Parameters.AddWithValue("@A1", A1);
            cmd.Parameters.AddWithValue("@A1Code", A1Code);
            cmd.Parameters.AddWithValue("@A1Dt", A1Dt);
            cmd.Parameters.AddWithValue("@A2", A2);
            cmd.Parameters.AddWithValue("@A2Code", A2Code);
            cmd.Parameters.AddWithValue("@A2Dt", A2Dt);
            cmd.Parameters.AddWithValue("@Shipperl1", Shipperl1);
            cmd.Parameters.AddWithValue("@Shipperl2", Shipperl2);
            cmd.Parameters.AddWithValue("@Shipperl3", Shipperl3);
            cmd.Parameters.AddWithValue("@Shipperl4", Shipperl4);
            cmd.Parameters.AddWithValue("@Shipperl5", Shipperl5);
            cmd.Parameters.AddWithValue("@Shipperl6", Shipperl6);
            cmd.Parameters.AddWithValue("@Consigneel1", Consigneel1);
            cmd.Parameters.AddWithValue("@Consigneel2", Consigneel2);
            cmd.Parameters.AddWithValue("@Consigneel3", Consigneel3);
            cmd.Parameters.AddWithValue("@Consigneel4", Consigneel4);
            cmd.Parameters.AddWithValue("@Consigneel5", Consigneel5);
            cmd.Parameters.AddWithValue("@Consigneel6", Consigneel6);
            cmd.Parameters.AddWithValue("@Carrierl1", Carrierl1);
            cmd.Parameters.AddWithValue("@Carrierl2", Carrierl2);
            cmd.Parameters.AddWithValue("@Carrierl3", Carrierl3);
            cmd.Parameters.AddWithValue("@Carrierl4", Carrierl4);
            cmd.Parameters.AddWithValue("@Carrierl5", Carrierl5);
            cmd.Parameters.AddWithValue("@Carrierl6", Carrierl6);
            cmd.Parameters.AddWithValue("@IATA", IATA);
            cmd.Parameters.AddWithValue("@Freight", Freight);
            cmd.Parameters.AddWithValue("@Curr", Curr);
            cmd.Parameters.AddWithValue("@Ins", Ins);
            cmd.Parameters.AddWithValue("@Pieces", Pieces);
            cmd.Parameters.AddWithValue("@GW", GW);
            cmd.Parameters.AddWithValue("@CW", CW);
            cmd.Parameters.AddWithValue("@Rate", Rate);
            cmd.Parameters.AddWithValue("@Total", Total);
            cmd.Parameters.AddWithValue("@Commodity", Commodity);
            cmd.Parameters.AddWithValue("@Nature", Nature);
            cmd.Parameters.AddWithValue("@Dimn", Dimn);
            cmd.Parameters.AddWithValue("@Notify", Notify);
            cmd.Parameters.AddWithValue("@TAmt", TAmt);
            cmd.Parameters.AddWithValue("@SBNo", SBNo);
            cmd.Parameters.AddWithValue("@SBDt", SBDt);
            cmd.Parameters.AddWithValue("@InvNo", InvNo);
            cmd.Parameters.AddWithValue("@InvDt", InvDt);
            cmd.Parameters.AddWithValue("@IEC", IEC);
            cmd.Parameters.AddWithValue("@BillNo", BillNo);
            cmd.Parameters.AddWithValue("@BillDt", BillDt);
            cmd.Parameters.AddWithValue("@BillAmt", BillAmt);
            cmd.Parameters.AddWithValue("@IGMNo", IGMNo);
            cmd.Parameters.AddWithValue("@IGMDt", IGMDt);
            cmd.Parameters.AddWithValue("@Status", Status);
            cmd.Parameters.AddWithValue("@CloseDt", CloseDt);
            cmd.Parameters.AddWithValue("@Remarks", Remarks);
            cmd.Parameters.AddWithValue("@Active", Active);
            cmd.Parameters.AddWithValue("@CreateDt", CreateDt);
            cmd.Parameters.AddWithValue("@CreateBy", CreateBy);
            cmd.Parameters.AddWithValue("@ModifyDt", DBNull.Value);
            cmd.Parameters.AddWithValue("@ModifyBy", DBNull.Value);
            cmd.Parameters.AddWithValue("@ExtenDate", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "Insert");
            int InsertCnt = cmd.ExecuteNonQuery();
            conn.Close();
            return InsertCnt > 0 ? true : false;
        }

        public bool AirJob_Update(int Id, string CCode, string Company, string JobNo, string RefNo, string ShipperInvNo, string Category, string MAWB, string HAWB, string Client, string Org, string OCnt, string Dest, string DCnt, string To1, string T1Cnt, string A1, string A1Code, string A1Dt, string A2, string A2Code, string A2Dt, string Shipperl1, string Shipperl2, string Shipperl3, string Shipperl4, string Shipperl5, string Shipperl6, string Consigneel1, string Consigneel2, string Consigneel3, string Consigneel4, string Consigneel5, string Consigneel6, string Carrierl1, string Carrierl2, string Carrierl3, string Carrierl4, string Carrierl5, string Carrierl6, string IATA, string Freight, string Curr, string Ins, string Pieces, string GW, string CW, string Rate, string Total, string Commodity, string Nature, string Dimn, string Notify, string TAmt, string SBNo, string SBDt, string InvNo, string InvDt, string IEC, string BillNo, string BillDt, string BillAmt, string IGMNo, string IGMDt, string Status, string CloseDt, string Remarks, string Active, string ModifyDt, string ModifyBy)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_AirJobChanges";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@Company", Company);
            cmd.Parameters.AddWithValue("@JobNo", JobNo);
            cmd.Parameters.AddWithValue("@RefNo", RefNo);
            cmd.Parameters.AddWithValue("@ShipperInvNo", ShipperInvNo);
            cmd.Parameters.AddWithValue("@Category", Category);
            cmd.Parameters.AddWithValue("@MAWB", MAWB);
            cmd.Parameters.AddWithValue("@HAWB", HAWB);
            cmd.Parameters.AddWithValue("@Client", Client);
            cmd.Parameters.AddWithValue("@Org", Org);
            cmd.Parameters.AddWithValue("@OCnt", OCnt);
            cmd.Parameters.AddWithValue("@Dest", Dest);
            cmd.Parameters.AddWithValue("@DCnt", DCnt);
            cmd.Parameters.AddWithValue("@To1", To1);
            cmd.Parameters.AddWithValue("@T1Cnt", T1Cnt);
            cmd.Parameters.AddWithValue("@A1", A1);
            cmd.Parameters.AddWithValue("@A1Code", A1Code);
            cmd.Parameters.AddWithValue("@A1Dt", A1Dt);
            cmd.Parameters.AddWithValue("@A2", A2);
            cmd.Parameters.AddWithValue("@A2Code", A2Code);
            cmd.Parameters.AddWithValue("@A2Dt", A2Dt);
            cmd.Parameters.AddWithValue("@Shipperl1", Shipperl1);
            cmd.Parameters.AddWithValue("@Shipperl2", Shipperl2);
            cmd.Parameters.AddWithValue("@Shipperl3", Shipperl3);
            cmd.Parameters.AddWithValue("@Shipperl4", Shipperl4);
            cmd.Parameters.AddWithValue("@Shipperl5", Shipperl5);
            cmd.Parameters.AddWithValue("@Shipperl6", Shipperl6);
            cmd.Parameters.AddWithValue("@Consigneel1", Consigneel1);
            cmd.Parameters.AddWithValue("@Consigneel2", Consigneel2);
            cmd.Parameters.AddWithValue("@Consigneel3", Consigneel3);
            cmd.Parameters.AddWithValue("@Consigneel4", Consigneel4);
            cmd.Parameters.AddWithValue("@Consigneel5", Consigneel5);
            cmd.Parameters.AddWithValue("@Consigneel6", Consigneel6);
            cmd.Parameters.AddWithValue("@Carrierl1", Carrierl1);
            cmd.Parameters.AddWithValue("@Carrierl2", Carrierl2);
            cmd.Parameters.AddWithValue("@Carrierl3", Carrierl3);
            cmd.Parameters.AddWithValue("@Carrierl4", Carrierl4);
            cmd.Parameters.AddWithValue("@Carrierl5", Carrierl5);
            cmd.Parameters.AddWithValue("@Carrierl6", Carrierl6);
            cmd.Parameters.AddWithValue("@IATA", IATA);
            cmd.Parameters.AddWithValue("@Freight", Freight);
            cmd.Parameters.AddWithValue("@Curr", Curr);
            cmd.Parameters.AddWithValue("@Ins", Ins);
            cmd.Parameters.AddWithValue("@Pieces", Pieces);
            cmd.Parameters.AddWithValue("@GW", GW);
            cmd.Parameters.AddWithValue("@CW", CW);
            cmd.Parameters.AddWithValue("@Rate", Rate);
            cmd.Parameters.AddWithValue("@Total", Total);
            cmd.Parameters.AddWithValue("@Commodity", Commodity);
            cmd.Parameters.AddWithValue("@Nature", Nature);
            cmd.Parameters.AddWithValue("@Dimn", Dimn);
            cmd.Parameters.AddWithValue("@Notify", Notify);
            cmd.Parameters.AddWithValue("@TAmt", TAmt);
            cmd.Parameters.AddWithValue("@SBNo", SBNo);
            cmd.Parameters.AddWithValue("@SBDt", SBDt);
            cmd.Parameters.AddWithValue("@InvNo", InvNo);
            cmd.Parameters.AddWithValue("@InvDt", InvDt);
            cmd.Parameters.AddWithValue("@IEC", IEC);
            cmd.Parameters.AddWithValue("@BillNo", BillNo);
            cmd.Parameters.AddWithValue("@BillDt", BillDt);
            cmd.Parameters.AddWithValue("@BillAmt", BillAmt);
            cmd.Parameters.AddWithValue("@IGMNo", IGMNo);
            cmd.Parameters.AddWithValue("@IGMDt", IGMDt);
            cmd.Parameters.AddWithValue("@Status", Status);
            cmd.Parameters.AddWithValue("@CloseDt", CloseDt);
            cmd.Parameters.AddWithValue("@Remarks", Remarks);
            cmd.Parameters.AddWithValue("@Active", Active);
            cmd.Parameters.AddWithValue("@CreateDt", DBNull.Value);
            cmd.Parameters.AddWithValue("@CreateBy", DBNull.Value);
            cmd.Parameters.AddWithValue("@ModifyDt", ModifyDt);
            cmd.Parameters.AddWithValue("@ModifyBy", ModifyBy);
            cmd.Parameters.AddWithValue("@ExtenDate", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "Update");
            int InsertCnt = cmd.ExecuteNonQuery();
            conn.Close();
            return InsertCnt > 0 ? true : false;
        }

        public bool AirJob_Delete(string CCode, string JobNo)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_AirJob";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@JobNo", JobNo);
            cmd.Parameters.AddWithValue("@Category", DBNull.Value);
            cmd.Parameters.AddWithValue("@MAWB", DBNull.Value);
            cmd.Parameters.AddWithValue("@HAWB", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "Delete");
            int InsertCnt = cmd.ExecuteNonQuery();
            conn.Close();
            return InsertCnt > 0 ? true : false;
        }

        //Sea Job
        public SqlDataReader SRefJob_DetailsTOP50(string CCode)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_SeaJob";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@JobNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@Category", DBNull.Value);
            cmd.Parameters.AddWithValue("@MBL", DBNull.Value);
            cmd.Parameters.AddWithValue("@HBL", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "SelectCompanyWiseTop");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }

        public SqlDataReader SRefJob_Details_Report(string CCode)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_SeaJob";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@JobNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@Category", DBNull.Value);
            cmd.Parameters.AddWithValue("@MBL", DBNull.Value);
            cmd.Parameters.AddWithValue("@HBL", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "SelectCompanyWiseReport");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }

        public SqlDataReader SRefJob_CategoryWise(string CCode, string Category)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_SeaJob";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@JobNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@Category", Category);
            cmd.Parameters.AddWithValue("@MBL", DBNull.Value);
            cmd.Parameters.AddWithValue("@HBL", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "SelectJobCategory");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }

        public SqlDataReader SeaRefJob_JobWise(string CCode, string JobNo)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_SeaJob";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@JobNo", JobNo);
            cmd.Parameters.AddWithValue("@Category", DBNull.Value);
            cmd.Parameters.AddWithValue("@MBL", DBNull.Value);
            cmd.Parameters.AddWithValue("@HBL", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "SelectJob");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }

        public SqlDataReader SeaRefJob_JobWiseDetails(string CCode, string JobNo)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_SeaJob";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@JobNo", JobNo);
            cmd.Parameters.AddWithValue("@Category", DBNull.Value);
            cmd.Parameters.AddWithValue("@MBL", DBNull.Value);
            cmd.Parameters.AddWithValue("@HBL", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "SelectJobDeatils");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }

        public SqlDataReader SeaRefJob_JobWise_MBLNo(string CCode, string MBLNo)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_SeaJob";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@JobNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@Category", DBNull.Value);
            cmd.Parameters.AddWithValue("@MBL", MBLNo);
            cmd.Parameters.AddWithValue("@HBL", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "SelectMBLWise");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }

        public SqlDataReader SeaRefJob_JobWise_HBLNo(string CCode, string HBLNo)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_SeaJob";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@JobNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@Category", DBNull.Value);
            cmd.Parameters.AddWithValue("@MBL", DBNull.Value);
            cmd.Parameters.AddWithValue("@HBL", HBLNo);
            cmd.Parameters.AddWithValue("@StatementType", "SelectHBLWise");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }

        public bool SeaJob_New(string CCode, string Company, string Category, string JobNo, string RefNo, string ShipperInvNo, string HBL, string MBL, string Client, string Origin, string PortLoad, string PortLoadDt, string FromCountry, string FinalDest, string PortDis, string PortDisDt, string ToCountry, string Container, string Vessel, string VesselCode, string VesselDt, string Exporterl1, string Exporterl2, string Exporterl3, string Exporterl4, string Exporterl5, string Consigneel1, string Consigneel2, string Consigneel3, string Consigneel4, string Consigneel5, string Buyerl1, string Buyerl2, string Buyerl3, string Buyerl4, string Buyerl5, string Freight, string Nature, string Pieces, string Pkgs, string Dimn, string GrossWt, string NetWt, string TotalAmt, string Currency, string SBNo, string SDDt, string IECode, string IEDate, string BillNo, string BillDt, string BillAmt, string TruckNo, string CloseDt, string Remarks, string Status, string Active, string CreateBy, string CreateDt)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_SeaJobChanges";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", 0);
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@Company", Company);
            cmd.Parameters.AddWithValue("@Category", Category);
            cmd.Parameters.AddWithValue("@JobNo", JobNo);
            cmd.Parameters.AddWithValue("@RefNo", RefNo);
            cmd.Parameters.AddWithValue("@ShipperInvNo", ShipperInvNo);
            cmd.Parameters.AddWithValue("@HBL", HBL);
            cmd.Parameters.AddWithValue("@MBL", MBL);
            cmd.Parameters.AddWithValue("@Client", Client);
            cmd.Parameters.AddWithValue("@Origin", Origin);
            cmd.Parameters.AddWithValue("@PortLoad", PortLoad);
            cmd.Parameters.AddWithValue("@PortLoadDt", PortLoadDt);
            cmd.Parameters.AddWithValue("@FromCountry", FromCountry);
            cmd.Parameters.AddWithValue("@FinalDest", FinalDest);
            cmd.Parameters.AddWithValue("@PortDis", PortDis);
            cmd.Parameters.AddWithValue("@PortDisDt", PortDisDt);
            cmd.Parameters.AddWithValue("@ToCountry", ToCountry);
            cmd.Parameters.AddWithValue("@Container", Container);
            cmd.Parameters.AddWithValue("@Vessel", Vessel);
            cmd.Parameters.AddWithValue("@VesselCode", VesselCode);
            cmd.Parameters.AddWithValue("@VesselDt", VesselDt);
            cmd.Parameters.AddWithValue("@Exporterl1", Exporterl1);
            cmd.Parameters.AddWithValue("@Exporterl2", Exporterl2);
            cmd.Parameters.AddWithValue("@Exporterl3", Exporterl3);
            cmd.Parameters.AddWithValue("@Exporterl4", Exporterl4);
            cmd.Parameters.AddWithValue("@Exporterl5", Exporterl5);
            cmd.Parameters.AddWithValue("@Consigneel1", Consigneel1);
            cmd.Parameters.AddWithValue("@Consigneel2", Consigneel2);
            cmd.Parameters.AddWithValue("@Consigneel3", Consigneel3);
            cmd.Parameters.AddWithValue("@Consigneel4", Consigneel4);
            cmd.Parameters.AddWithValue("@Consigneel5", Consigneel5);
            cmd.Parameters.AddWithValue("@Buyerl1", Buyerl1);
            cmd.Parameters.AddWithValue("@Buyerl2", Buyerl2);
            cmd.Parameters.AddWithValue("@Buyerl3", Buyerl3);
            cmd.Parameters.AddWithValue("@Buyerl4", Buyerl4);
            cmd.Parameters.AddWithValue("@Buyerl5", Buyerl5);
            cmd.Parameters.AddWithValue("@Freight", Freight);
            cmd.Parameters.AddWithValue("@Nature", Nature);
            cmd.Parameters.AddWithValue("@Pieces", Pieces);
            cmd.Parameters.AddWithValue("@Pkgs", Pkgs);
            cmd.Parameters.AddWithValue("@Dimn", Dimn);
            cmd.Parameters.AddWithValue("@GrossWt", GrossWt);
            cmd.Parameters.AddWithValue("@NetWt", NetWt);
            cmd.Parameters.AddWithValue("@TotalAmt", TotalAmt);
            cmd.Parameters.AddWithValue("@Currency", Currency);
            cmd.Parameters.AddWithValue("@SBNo", SBNo);
            cmd.Parameters.AddWithValue("@SDDt", SDDt);
            cmd.Parameters.AddWithValue("@IECode", IECode);
            cmd.Parameters.AddWithValue("@IEDate", IEDate);
            cmd.Parameters.AddWithValue("@BillNo", BillNo);
            cmd.Parameters.AddWithValue("@BillDt", BillDt);
            cmd.Parameters.AddWithValue("@BillAmt", BillAmt);
            cmd.Parameters.AddWithValue("@TruckNo", TruckNo);
            cmd.Parameters.AddWithValue("@CloseDt", CloseDt);
            cmd.Parameters.AddWithValue("@Remarks", Remarks);
            cmd.Parameters.AddWithValue("@Status", Status);
            cmd.Parameters.AddWithValue("@Active", Active);
            cmd.Parameters.AddWithValue("@CreateBy", CreateBy);
            cmd.Parameters.AddWithValue("@CreateDt", CreateDt);
            cmd.Parameters.AddWithValue("@ModifyBy", DBNull.Value);
            cmd.Parameters.AddWithValue("@ModifyDt", DBNull.Value);
            cmd.Parameters.AddWithValue("@ExtenDate", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "Insert");
            int InsertCnt = cmd.ExecuteNonQuery();
            conn.Close();
            return InsertCnt > 0 ? true : false;
        }

        public bool SeaJob_Update(int Id, string CCode, string Company, string Category, string JobNo, string RefNo, string ShipperInvNo, string HBL, string MBL, string Client, string Origin, string PortLoad, string PortLoadDt, string FromCountry, string FinalDest, string PortDis, string PortDisDt, string ToCountry, string Container, string Vessel, string VesselCode, string VesselDt, string Exporterl1, string Exporterl2, string Exporterl3, string Exporterl4, string Exporterl5, string Consigneel1, string Consigneel2, string Consigneel3, string Consigneel4, string Consigneel5, string Buyerl1, string Buyerl2, string Buyerl3, string Buyerl4, string Buyerl5, string Freight, string Nature, string Pieces, string Pkgs, string Dimn, string GrossWt, string NetWt, string TotalAmt, string Currency, string SBNo, string SDDt, string IECode, string IEDate, string BillNo, string BillDt, string BillAmt, string TruckNo, string CloseDt, string Remarks, string Status, string Active, string ModifyDt, string ModifyBy, string ExtenDate)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_SeaJobChanges";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@Company", Company);
            cmd.Parameters.AddWithValue("@Category", Category);
            cmd.Parameters.AddWithValue("@JobNo", JobNo);
            cmd.Parameters.AddWithValue("@RefNo", RefNo);
            cmd.Parameters.AddWithValue("@ShipperInvNo", ShipperInvNo);
            cmd.Parameters.AddWithValue("@HBL", HBL);
            cmd.Parameters.AddWithValue("@MBL", MBL);
            cmd.Parameters.AddWithValue("@Client", Client);
            cmd.Parameters.AddWithValue("@Origin", Origin);
            cmd.Parameters.AddWithValue("@PortLoad", PortLoad);
            cmd.Parameters.AddWithValue("@PortLoadDt", PortLoadDt);
            cmd.Parameters.AddWithValue("@FromCountry", FromCountry);
            cmd.Parameters.AddWithValue("@FinalDest", FinalDest);
            cmd.Parameters.AddWithValue("@PortDis", PortDis);
            cmd.Parameters.AddWithValue("@PortDisDt", PortDisDt);
            cmd.Parameters.AddWithValue("@ToCountry", ToCountry);
            cmd.Parameters.AddWithValue("@Container", Container);
            cmd.Parameters.AddWithValue("@Vessel", Vessel);
            cmd.Parameters.AddWithValue("@VesselCode", VesselCode);
            cmd.Parameters.AddWithValue("@VesselDt", VesselDt);
            cmd.Parameters.AddWithValue("@Exporterl1", Exporterl1);
            cmd.Parameters.AddWithValue("@Exporterl2", Exporterl2);
            cmd.Parameters.AddWithValue("@Exporterl3", Exporterl3);
            cmd.Parameters.AddWithValue("@Exporterl4", Exporterl4);
            cmd.Parameters.AddWithValue("@Exporterl5", Exporterl5);
            cmd.Parameters.AddWithValue("@Consigneel1", Consigneel1);
            cmd.Parameters.AddWithValue("@Consigneel2", Consigneel2);
            cmd.Parameters.AddWithValue("@Consigneel3", Consigneel3);
            cmd.Parameters.AddWithValue("@Consigneel4", Consigneel4);
            cmd.Parameters.AddWithValue("@Consigneel5", Consigneel5);
            cmd.Parameters.AddWithValue("@Buyerl1", Buyerl1);
            cmd.Parameters.AddWithValue("@Buyerl2", Buyerl2);
            cmd.Parameters.AddWithValue("@Buyerl3", Buyerl3);
            cmd.Parameters.AddWithValue("@Buyerl4", Buyerl4);
            cmd.Parameters.AddWithValue("@Buyerl5", Buyerl5);
            cmd.Parameters.AddWithValue("@Freight", Freight);
            cmd.Parameters.AddWithValue("@Nature", Nature);
            cmd.Parameters.AddWithValue("@Pieces", Pieces);
            cmd.Parameters.AddWithValue("@Pkgs", Pkgs);
            cmd.Parameters.AddWithValue("@Dimn", Dimn);
            cmd.Parameters.AddWithValue("@GrossWt", GrossWt);
            cmd.Parameters.AddWithValue("@NetWt", NetWt);
            cmd.Parameters.AddWithValue("@TotalAmt", TotalAmt);
            cmd.Parameters.AddWithValue("@Currency", Currency);
            cmd.Parameters.AddWithValue("@SBNo", SBNo);
            cmd.Parameters.AddWithValue("@SDDt", SDDt);
            cmd.Parameters.AddWithValue("@IECode", IECode);
            cmd.Parameters.AddWithValue("@IEDate", IEDate);
            cmd.Parameters.AddWithValue("@BillNo", BillNo);
            cmd.Parameters.AddWithValue("@BillDt", BillDt);
            cmd.Parameters.AddWithValue("@BillAmt", BillAmt);
            cmd.Parameters.AddWithValue("@TruckNo", TruckNo);
            cmd.Parameters.AddWithValue("@CloseDt", CloseDt);
            cmd.Parameters.AddWithValue("@Remarks", Remarks);
            cmd.Parameters.AddWithValue("@Status", Status);
            cmd.Parameters.AddWithValue("@Active", Active);
            cmd.Parameters.AddWithValue("@CreateBy", DBNull.Value);
            cmd.Parameters.AddWithValue("@CreateDt", DBNull.Value);
            cmd.Parameters.AddWithValue("@ModifyBy", ModifyBy);
            cmd.Parameters.AddWithValue("@ModifyDt", ModifyDt);
            cmd.Parameters.AddWithValue("@ExtenDate", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "Update");
            int InsertCnt = cmd.ExecuteNonQuery();
            conn.Close();
            return InsertCnt > 0 ? true : false;
        }

        public bool SeaJob_Delete(string CCode, string JobNo)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_SeaJob";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@JobNo", JobNo);
            cmd.Parameters.AddWithValue("@Category", DBNull.Value);
            cmd.Parameters.AddWithValue("@MBL", DBNull.Value);
            cmd.Parameters.AddWithValue("@HBL", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "Delete");
            int InsertCnt = cmd.ExecuteNonQuery();
            conn.Close();
            return InsertCnt > 0 ? true : false;
        }

        // Master AWB
        public SqlDataReader AWB_PreviousJobNo(string CCode, string Type)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_AWB";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", 0);
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@JobNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@Type", Type);
            cmd.Parameters.AddWithValue("@MAWB", DBNull.Value);
            cmd.Parameters.AddWithValue("@HAWB", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "SelectPreviousInvoiceNo");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }

        public SqlDataReader MAWB_All(string CCode, string Type)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_AWB";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", 0);
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@JobNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@Type", Type);
            cmd.Parameters.AddWithValue("@MAWB", DBNull.Value);
            cmd.Parameters.AddWithValue("@HAWB", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "SelectAll");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }

        public SqlDataReader MAWB_Search(string CCode, string AWB, string Type)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_AWB";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", 0);
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@JobNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@Type", Type);
            cmd.Parameters.AddWithValue("@MAWB", AWB);
            cmd.Parameters.AddWithValue("@HAWB", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "SelectMAWB");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }

        public SqlDataReader HAWB_Search(string CCode, string AWB, string Type)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_AWB";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", 0);
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@JobNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@Type", Type);
            cmd.Parameters.AddWithValue("@MAWB", DBNull.Value);
            cmd.Parameters.AddWithValue("@HAWB", AWB);
            cmd.Parameters.AddWithValue("@StatementType", "SelectHAWB");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }

        public SqlDataReader AWB_Search_Top50(string CCode, string Type)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_AWB";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", 0);
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@JobNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@Type", Type);
            cmd.Parameters.AddWithValue("@MAWB", DBNull.Value);
            cmd.Parameters.AddWithValue("@HAWB", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "SelectCompanyWiseTop");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }

        public SqlDataReader AWB_JobNoList(string CCode)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_AWB";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", 0);
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@JobNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@Type", DBNull.Value);
            cmd.Parameters.AddWithValue("@MAWB", DBNull.Value);
            cmd.Parameters.AddWithValue("@HAWB", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "SelectJobNo-AWB");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }

        public SqlDataReader AWB_Search_JobNo(string CCode, string JobNo)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_AWB";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", 0);
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@JobNo", JobNo);
            cmd.Parameters.AddWithValue("@Type", DBNull.Value);
            cmd.Parameters.AddWithValue("@MAWB", DBNull.Value);
            cmd.Parameters.AddWithValue("@HAWB", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "SelectJobNo");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }

        public SqlDataReader AWB_Search_JobNoType(string CCode, string JobNo, string Type)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_AWB";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", 0);
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@JobNo", JobNo);
            cmd.Parameters.AddWithValue("@Type", Type);
            cmd.Parameters.AddWithValue("@MAWB", DBNull.Value);
            cmd.Parameters.AddWithValue("@HAWB", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "SelectJobNoType");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }


        public SqlDataReader AWB_Search_TemplateName(string CCode, string TemplateName, string Type)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_AWBTemplateName";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@Type", Type);
            cmd.Parameters.AddWithValue("@TemplateName", TemplateName);
            cmd.Parameters.AddWithValue("@StatementType", "SelectAWBTN");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }
        public SqlDataReader AWB_TemplateName(string CCode, string Type)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_AWBTemplateName";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@Type", Type);
            cmd.Parameters.AddWithValue("@TemplateName", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "AWBTemplateName");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }
        public SqlDataReader AWB_JobNoListAll(string CCode)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_AWB";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", 0);
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@JobNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@Type", DBNull.Value);
            cmd.Parameters.AddWithValue("@MAWB", DBNull.Value);
            cmd.Parameters.AddWithValue("@HAWB", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "SelectJobNoList");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }

        //  public bool AWB_New(string CCode, string JobNo, string Type, string Prefix, string OCode, string BillNo, string MAWB, string HAWB, string Shipperl1, string Shipperl2, string Shipperl3, string Shipperl4, string Shipperl5, string Shipperl6, string Shipperl7, string Consigneel1, string Consigneel2, string Consigneel3, string Consigneel4, string Consigneel5, string Consigneel6, string Consigneel7, string Airline, string CAgentl1, string CAgentl2, string CAgentl3, string IATACode, string IATAAccNo, string Freight, string AInfo, string Origin, string RefNo, string OSI1, string OSI2, string DCode, string ACode, string To1, string By1, string To2, string By2, string Currency, string CHGS, string WP, string WC, string OP, string OC, string DVCarriage, string DVCustoms, string Dest, string RFlight, string RFDate, string Ins, string HInfo, string SCI, string P1, string KGQ1, string GW1, string CIN1, string CW1, string Rate1, string Total1, string P2, string GW2, string KGQ2, string CIN2, string CW2, string Rate2, string Total2, string P3, string GW3, string KGQ3, string CIN3, string CW3, string Rate3, string Total3, string TotalPieces, string TotalGW, string Total, string Nature, string Dimn, string Notify, string PWC, string PVC, string PTax, string PCAgent, string PCCarrier, string TotalPrepaid, string CWC, string CVC, string CTax, string CCAgent, string CCCarrier, string TotalCollect, string OCharges, string OChargesCust, string ShipperSign, string EXeDate, string Place, string IssueSign, string Remarks, string Active, string CreateBy, string CreateDate)
        public bool AWB_New(string CCode, string JobNo, string Type, string Prefix, string OCode, string BillNo, string MAWB, string HAWB, string Shipperl1, string Shipperl2, string Shipperl3, string Shipperl4, string Shipperl5, string Shipperl6, string Consigneel1, string Consigneel2, string Consigneel3, string Consigneel4, string Consigneel5, string Consigneel6, string Airline, string CAgentl1, string CAgentl2, string CAgentl3, string IATACode, string IATAAccNo, string Freight, string AInfo, string Origin, string RefNo, string OSI1, string OSI2, string DCode, string ACode, string To1, string By1, string To2, string By2, string Currency, string CHGS, string WP, string WC, string OP, string OC, string DVCarriage, string DVCustoms, string Dest, string RFlight, string RFDate, string Ins, string HInfo, string SCI, string P1, string KGQ1, string GW1, string CIN1, string CW1, string Rate1, string Total1, string TotalPieces, string TotalGW, string Total, string Nature, string Dimn, string Notify, string PWC, string PVC, string PTax, string PCAgent, string PCCarrier, string TotalPrepaid, string CWC, string CVC, string CTax, string CCAgent, string CCCarrier, string TotalCollect, string OCharges, string OChargesCust, string ShipperSign, string EXeDate, string Place, string IssueSign, string Remarks, string Active, string CreateBy, string CreateDate, string Month) //,string Naturel1, string Naturel2, string Naturel3, string Naturel4, string Naturel5, string Naturel6, string Naturel7, string Naturel8, string Naturel9, string Naturel10, string Naturel11, string Naturel12, string Naturel13, string Naturel14, string Naturel15,string TemplateName)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_AWBChanges";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@Id", 0);
            cmd.Parameters.AddWithValue("@JobNo", JobNo);
            cmd.Parameters.AddWithValue("@Type", Type);
            cmd.Parameters.AddWithValue("@Prefix", Prefix);
            cmd.Parameters.AddWithValue("@OCode", OCode);
            cmd.Parameters.AddWithValue("@BillNo", BillNo);
            cmd.Parameters.AddWithValue("@MAWB", MAWB);
            cmd.Parameters.AddWithValue("@HAWB", HAWB);
            cmd.Parameters.AddWithValue("@Shipperl1", Shipperl1);
            cmd.Parameters.AddWithValue("@Shipperl2", Shipperl2);
            cmd.Parameters.AddWithValue("@Shipperl3", Shipperl3);
            cmd.Parameters.AddWithValue("@Shipperl4", Shipperl4);
            cmd.Parameters.AddWithValue("@Shipperl5", Shipperl5);
            cmd.Parameters.AddWithValue("@Shipperl6", Shipperl6);
            //    cmd.Parameters.AddWithValue("@Shipperl7", Shipperl7);
            cmd.Parameters.AddWithValue("@Consigneel1", Consigneel1);
            cmd.Parameters.AddWithValue("@Consigneel2", Consigneel2);
            cmd.Parameters.AddWithValue("@Consigneel3", Consigneel3);
            cmd.Parameters.AddWithValue("@Consigneel4", Consigneel4);
            cmd.Parameters.AddWithValue("@Consigneel5", Consigneel5);
            cmd.Parameters.AddWithValue("@Consigneel6", Consigneel6);
            // cmd.Parameters.AddWithValue("@Consigneel7", Consigneel7);
            cmd.Parameters.AddWithValue("@Airline", Airline);
            cmd.Parameters.AddWithValue("@CAgentl1", CAgentl1);
            cmd.Parameters.AddWithValue("@CAgentl2", CAgentl2);
            cmd.Parameters.AddWithValue("@CAgentl3", CAgentl3);
            cmd.Parameters.AddWithValue("@IATACode", IATACode);
            cmd.Parameters.AddWithValue("@IATAAccNo", IATAAccNo);
            cmd.Parameters.AddWithValue("@Freight", Freight);
            cmd.Parameters.AddWithValue("@AInfo", AInfo);
            cmd.Parameters.AddWithValue("@Origin", Origin);
            cmd.Parameters.AddWithValue("@RefNo", RefNo);
            cmd.Parameters.AddWithValue("@OSI1", OSI1);
            cmd.Parameters.AddWithValue("@OSI2", OSI2);
            cmd.Parameters.AddWithValue("@DCode", DCode);
            cmd.Parameters.AddWithValue("@ACode", ACode);
            cmd.Parameters.AddWithValue("@To1", To1);
            cmd.Parameters.AddWithValue("@By1", By1);
            cmd.Parameters.AddWithValue("@To2", To2);
            cmd.Parameters.AddWithValue("@By2", By2);
            cmd.Parameters.AddWithValue("@Currency", Currency);
            cmd.Parameters.AddWithValue("@CHGS", CHGS);
            cmd.Parameters.AddWithValue("@WP", WP);
            cmd.Parameters.AddWithValue("@WC", WC);
            cmd.Parameters.AddWithValue("@OP", OP);
            cmd.Parameters.AddWithValue("@OC", OC);
            cmd.Parameters.AddWithValue("@DVCarriage", DVCarriage);
            cmd.Parameters.AddWithValue("@DVCustoms", DVCustoms);
            cmd.Parameters.AddWithValue("@Dest", Dest);
            cmd.Parameters.AddWithValue("@RFlight", RFlight);
            cmd.Parameters.AddWithValue("@RFDate", RFDate);
            cmd.Parameters.AddWithValue("@Ins", Ins);
            cmd.Parameters.AddWithValue("@HInfo", HInfo);
            cmd.Parameters.AddWithValue("@SCI", SCI);
            cmd.Parameters.AddWithValue("@P1", P1);
            cmd.Parameters.AddWithValue("@KGQ1", KGQ1);
            cmd.Parameters.AddWithValue("@GW1", GW1);
            cmd.Parameters.AddWithValue("@CIN1", CIN1);
            cmd.Parameters.AddWithValue("@CW1", CW1);
            cmd.Parameters.AddWithValue("@Rate1", Rate1);
            cmd.Parameters.AddWithValue("@Total1", Total1);
            //cmd.Parameters.AddWithValue("@P2", P2);
            //cmd.Parameters.AddWithValue("@GW2", GW2);
            //cmd.Parameters.AddWithValue("@KGQ2", KGQ2);
            //cmd.Parameters.AddWithValue("@CIN2", CIN2);
            //cmd.Parameters.AddWithValue("@CW2", CW2);
            //cmd.Parameters.AddWithValue("@Rate2", Rate2);
            //cmd.Parameters.AddWithValue("@Total2", Total2);
            //cmd.Parameters.AddWithValue("@P3", P3);
            //cmd.Parameters.AddWithValue("@GW3", GW3);
            //cmd.Parameters.AddWithValue("@KGQ3", KGQ3);
            //cmd.Parameters.AddWithValue("@CIN3", CIN3);
            //cmd.Parameters.AddWithValue("@CW3", CW3);
            //cmd.Parameters.AddWithValue("@Rate3", Rate3);
            //cmd.Parameters.AddWithValue("@Total3", Total3);
            cmd.Parameters.AddWithValue("@TotalPieces", TotalPieces);
            cmd.Parameters.AddWithValue("@TotalGW", TotalGW);
            cmd.Parameters.AddWithValue("@Total", Total);
            cmd.Parameters.AddWithValue("@Nature", Nature);
            cmd.Parameters.AddWithValue("@Dimn", Dimn);
            cmd.Parameters.AddWithValue("@Notify", Notify);
            cmd.Parameters.AddWithValue("@PWC", PWC);
            cmd.Parameters.AddWithValue("@PVC", PVC);
            cmd.Parameters.AddWithValue("@PTax", PTax);
            cmd.Parameters.AddWithValue("@PCAgent", PCAgent);
            cmd.Parameters.AddWithValue("@PCCarrier", PCCarrier);
            cmd.Parameters.AddWithValue("@TotalPrepaid", TotalPrepaid);
            cmd.Parameters.AddWithValue("@CWC", CWC);
            cmd.Parameters.AddWithValue("@CVC", CVC);
            cmd.Parameters.AddWithValue("@CTax", CTax);
            cmd.Parameters.AddWithValue("@CCAgent", CCAgent);
            cmd.Parameters.AddWithValue("@CCCarrier", CCCarrier);
            cmd.Parameters.AddWithValue("@TotalCollect", TotalCollect);
            cmd.Parameters.AddWithValue("@OCharges", OCharges);
            cmd.Parameters.AddWithValue("@OChargesCust", OChargesCust);
            cmd.Parameters.AddWithValue("@ShipperSign", ShipperSign);
            cmd.Parameters.AddWithValue("@EXeDate", EXeDate);
            cmd.Parameters.AddWithValue("@Place", Place);
            cmd.Parameters.AddWithValue("@IssueSign", IssueSign);
            cmd.Parameters.AddWithValue("@Remarks", Remarks);
            cmd.Parameters.AddWithValue("@Active", Active);
            cmd.Parameters.AddWithValue("@CreateBy", CreateBy);
            cmd.Parameters.AddWithValue("@CreateDate", CreateDate);
            cmd.Parameters.AddWithValue("@ModifyBy", DBNull.Value);
            cmd.Parameters.AddWithValue("@ModifyDate", DBNull.Value);
            cmd.Parameters.AddWithValue("@ExtenDate", DBNull.Value);
            cmd.Parameters.AddWithValue("@Month", Month);
            //cmd.Parameters.AddWithValue("@Naturel1", Naturel1);
            //cmd.Parameters.AddWithValue("@Naturel2", Naturel2);
            //cmd.Parameters.AddWithValue("@Naturel3", Naturel3);
            //cmd.Parameters.AddWithValue("@Naturel4", Naturel4);
            //cmd.Parameters.AddWithValue("@Naturel5", Naturel5);
            //cmd.Parameters.AddWithValue("@Naturel6", Naturel6);
            //cmd.Parameters.AddWithValue("@Naturel7", Naturel7);
            //cmd.Parameters.AddWithValue("@Naturel8", Naturel8);
            //cmd.Parameters.AddWithValue("@Naturel9", Naturel9);
            //cmd.Parameters.AddWithValue("@Naturel10", Naturel10);
            //cmd.Parameters.AddWithValue("@Naturel11", Naturel11);
            //cmd.Parameters.AddWithValue("@Naturel12", Naturel12);
            //cmd.Parameters.AddWithValue("@Naturel13", Naturel13);
            //cmd.Parameters.AddWithValue("@Naturel14", Naturel14);
            //cmd.Parameters.AddWithValue("@Naturel15", Naturel15);
            //cmd.Parameters.AddWithValue("@TemplateName", TemplateName);
            cmd.Parameters.AddWithValue("@StatementType", "Insert");
            int InsertCnt = cmd.ExecuteNonQuery();
            conn.Close();
            return InsertCnt > 0 ? true : false;
        }

        public bool AWB_Update(string CCode, int Id, string JobNo, string Prefix, string OCode, string BillNo, string MAWB, string Shipperl1, string Shipperl2, string Shipperl3, string Shipperl4, string Shipperl5, string Shipperl6, string Consigneel1, string Consigneel2, string Consigneel3, string Consigneel4, string Consigneel5, string Consigneel6, string Airline, string CAgentl1, string CAgentl2, string CAgentl3, string IATACode, string IATAAccNo, string Freight, string AInfo, string Origin, string RefNo, string OSI1, string OSI2, string DCode, string ACode, string To1, string By1, string To2, string By2, string Currency, string CHGS, string WP, string WC, string OP, string OC, string DVCarriage, string DVCustoms, string Dest, string RFlight, string RFDate, string Ins, string HInfo, string SCI, string P1, string KGQ1, string GW1, string CIN1, string CW1, string Rate1, string Total1, string TotalPieces, string TotalGW, string Total, string Nature, string Dimn, string Notify, string PWC, string PVC, string PTax, string PCAgent, string PCCarrier, string TotalPrepaid, string CWC, string CVC, string CTax, string CCAgent, string CCCarrier, string TotalCollect, string OCharges, string OChargesCust, string ShipperSign, string EXeDate, string Place, string IssueSign, string Remarks, string Active, string ModifyBy, string ModifyDate, string Month) //, string Naturel1, string Naturel2, string Naturel3, string Naturel4, string Naturel5, string Naturel6, string Naturel7, string Naturel8, string Naturel9, string Naturel10, string Naturel11, string Naturel12, string Naturel13, string Naturel14, string Naturel15,string TemplateName)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_AWBChanges";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@JobNo", JobNo);
            cmd.Parameters.AddWithValue("@Type", DBNull.Value);
            cmd.Parameters.AddWithValue("@Prefix", Prefix);
            cmd.Parameters.AddWithValue("@OCode", OCode);
            cmd.Parameters.AddWithValue("@BillNo", BillNo);
            cmd.Parameters.AddWithValue("@MAWB", MAWB);
            cmd.Parameters.AddWithValue("@HAWB", DBNull.Value);
            cmd.Parameters.AddWithValue("@Shipperl1", Shipperl1);
            cmd.Parameters.AddWithValue("@Shipperl2", Shipperl2);
            cmd.Parameters.AddWithValue("@Shipperl3", Shipperl3);
            cmd.Parameters.AddWithValue("@Shipperl4", Shipperl4);
            cmd.Parameters.AddWithValue("@Shipperl5", Shipperl5);
            cmd.Parameters.AddWithValue("@Shipperl6", Shipperl6);
            cmd.Parameters.AddWithValue("@Consigneel1", Consigneel1);
            cmd.Parameters.AddWithValue("@Consigneel2", Consigneel2);
            cmd.Parameters.AddWithValue("@Consigneel3", Consigneel3);
            cmd.Parameters.AddWithValue("@Consigneel4", Consigneel4);
            cmd.Parameters.AddWithValue("@Consigneel5", Consigneel5);
            cmd.Parameters.AddWithValue("@Consigneel6", Consigneel6);
            cmd.Parameters.AddWithValue("@Airline", Airline);
            cmd.Parameters.AddWithValue("@CAgentl1", CAgentl1);
            cmd.Parameters.AddWithValue("@CAgentl2", CAgentl2);
            cmd.Parameters.AddWithValue("@CAgentl3", CAgentl3);
            cmd.Parameters.AddWithValue("@IATACode", IATACode);
            cmd.Parameters.AddWithValue("@IATAAccNo", IATAAccNo);
            cmd.Parameters.AddWithValue("@Freight", Freight);
            cmd.Parameters.AddWithValue("@AInfo", AInfo);
            cmd.Parameters.AddWithValue("@Origin", Origin);
            cmd.Parameters.AddWithValue("@RefNo", RefNo);
            cmd.Parameters.AddWithValue("@OSI1", OSI1);
            cmd.Parameters.AddWithValue("@OSI2", OSI2);
            cmd.Parameters.AddWithValue("@DCode", DCode);
            cmd.Parameters.AddWithValue("@ACode", ACode);
            cmd.Parameters.AddWithValue("@To1", To1);
            cmd.Parameters.AddWithValue("@By1", By1);
            cmd.Parameters.AddWithValue("@To2", To2);
            cmd.Parameters.AddWithValue("@By2", By2);
            cmd.Parameters.AddWithValue("@Currency", Currency);
            cmd.Parameters.AddWithValue("@CHGS", CHGS);
            cmd.Parameters.AddWithValue("@WP", WP);
            cmd.Parameters.AddWithValue("@WC", WC);
            cmd.Parameters.AddWithValue("@OP", OP);
            cmd.Parameters.AddWithValue("@OC", OC);
            cmd.Parameters.AddWithValue("@DVCarriage", DVCarriage);
            cmd.Parameters.AddWithValue("@DVCustoms", DVCustoms);
            cmd.Parameters.AddWithValue("@Dest", Dest);
            cmd.Parameters.AddWithValue("@RFlight", RFlight);
            cmd.Parameters.AddWithValue("@RFDate", RFDate);
            cmd.Parameters.AddWithValue("@Ins", Ins);
            cmd.Parameters.AddWithValue("@HInfo", HInfo);
            cmd.Parameters.AddWithValue("@SCI", SCI);
            cmd.Parameters.AddWithValue("@P1", P1);
            cmd.Parameters.AddWithValue("@KGQ1", KGQ1);
            cmd.Parameters.AddWithValue("@GW1", GW1);
            cmd.Parameters.AddWithValue("@CIN1", CIN1);
            cmd.Parameters.AddWithValue("@CW1", CW1);
            cmd.Parameters.AddWithValue("@Rate1", Rate1);
            cmd.Parameters.AddWithValue("@Total1", Total1);
            cmd.Parameters.AddWithValue("@TotalPieces", TotalPieces);
            cmd.Parameters.AddWithValue("@TotalGW", TotalGW);
            cmd.Parameters.AddWithValue("@Total", Total);
            cmd.Parameters.AddWithValue("@Nature", Nature);
            cmd.Parameters.AddWithValue("@Dimn", Dimn);
            cmd.Parameters.AddWithValue("@Notify", Notify);
            cmd.Parameters.AddWithValue("@PWC", PWC);
            cmd.Parameters.AddWithValue("@PVC", PVC);
            cmd.Parameters.AddWithValue("@PTax", PTax);
            cmd.Parameters.AddWithValue("@PCAgent", PCAgent);
            cmd.Parameters.AddWithValue("@PCCarrier", PCCarrier);
            cmd.Parameters.AddWithValue("@TotalPrepaid", TotalPrepaid);
            cmd.Parameters.AddWithValue("@CWC", CWC);
            cmd.Parameters.AddWithValue("@CVC", CVC);
            cmd.Parameters.AddWithValue("@CTax", CTax);
            cmd.Parameters.AddWithValue("@CCAgent", CCAgent);
            cmd.Parameters.AddWithValue("@CCCarrier", CCCarrier);
            cmd.Parameters.AddWithValue("@TotalCollect", TotalCollect);
            cmd.Parameters.AddWithValue("@OCharges", OCharges);
            cmd.Parameters.AddWithValue("@OChargesCust", OChargesCust);
            cmd.Parameters.AddWithValue("@ShipperSign", ShipperSign);
            cmd.Parameters.AddWithValue("@EXeDate", EXeDate);
            cmd.Parameters.AddWithValue("@Place", Place);
            cmd.Parameters.AddWithValue("@IssueSign", IssueSign);
            cmd.Parameters.AddWithValue("@Remarks", Remarks);
            cmd.Parameters.AddWithValue("@Active", Active);
            cmd.Parameters.AddWithValue("@CreateBy", DBNull.Value);
            cmd.Parameters.AddWithValue("@CreateDate", DBNull.Value);
            cmd.Parameters.AddWithValue("@ModifyBy", ModifyBy);
            cmd.Parameters.AddWithValue("@ModifyDate", ModifyDate);
            cmd.Parameters.AddWithValue("@ExtenDate", DBNull.Value);
            cmd.Parameters.AddWithValue("@Month", Month);
            //cmd.Parameters.AddWithValue("@Naturel1", Naturel1);
            //cmd.Parameters.AddWithValue("@Naturel2", Naturel2);
            //cmd.Parameters.AddWithValue("@Naturel3", Naturel3);
            //cmd.Parameters.AddWithValue("@Naturel4", Naturel4);
            //cmd.Parameters.AddWithValue("@Naturel5", Naturel5);
            //cmd.Parameters.AddWithValue("@Naturel6", Naturel6);
            //cmd.Parameters.AddWithValue("@Naturel7", Naturel7);
            //cmd.Parameters.AddWithValue("@Naturel8", Naturel8);
            //cmd.Parameters.AddWithValue("@Naturel9", Naturel9);
            //cmd.Parameters.AddWithValue("@Naturel10", Naturel10);
            //cmd.Parameters.AddWithValue("@Naturel11", Naturel11);
            //cmd.Parameters.AddWithValue("@Naturel12", Naturel12);
            //cmd.Parameters.AddWithValue("@Naturel13", Naturel13);
            //cmd.Parameters.AddWithValue("@Naturel14", Naturel14);
            //cmd.Parameters.AddWithValue("@Naturel15", Naturel15);
            //cmd.Parameters.AddWithValue("@TemplateName", TemplateName);
            cmd.Parameters.AddWithValue("@StatementType", "UpdateMAWB");
            int InsertCnt = cmd.ExecuteNonQuery();
            conn.Close();
            return InsertCnt > 0 ? true : false;
        }

        public bool HAWB_Update(string CCode, int Id, string JobNo, string Prefix, string OCode, string BillNo, string HAWB, string Shipperl1, string Shipperl2, string Shipperl3, string Shipperl4, string Shipperl5, string Shipperl6, string Consigneel1, string Consigneel2, string Consigneel3, string Consigneel4, string Consigneel5, string Consigneel6, string Airline, string CAgentl1, string CAgentl2, string CAgentl3, string IATACode, string IATAAccNo, string Freight, string AInfo, string Origin, string RefNo, string OSI1, string OSI2, string DCode, string ACode, string To1, string By1, string To2, string By2, string Currency, string CHGS, string WP, string WC, string OP, string OC, string DVCarriage, string DVCustoms, string Dest, string RFlight, string RFDate, string Ins, string HInfo, string SCI, string P1, string KGQ1, string GW1, string CIN1, string CW1, string Rate1, string Total1, string TotalPieces, string TotalGW, string Total, string Nature, string Dimn, string Notify, string PWC, string PVC, string PTax, string PCAgent, string PCCarrier, string TotalPrepaid, string CWC, string CVC, string CTax, string CCAgent, string CCCarrier, string TotalCollect, string OCharges, string OChargesCust, string ShipperSign, string EXeDate, string Place, string IssueSign, string Remarks, string Active, string ModifyBy, string ModifyDate, string Month) //, string Naturel1, string Naturel2, string Naturel3, string Naturel4, string Naturel5, string Naturel6, string Naturel7, string Naturel8, string Naturel9, string Naturel10, string Naturel11, string Naturel12, string Naturel13, string Naturel14, string Naturel15)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_AWBChanges";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@JobNo", JobNo);
            cmd.Parameters.AddWithValue("@Type", DBNull.Value);
            cmd.Parameters.AddWithValue("@Prefix", Prefix);
            cmd.Parameters.AddWithValue("@OCode", OCode);
            cmd.Parameters.AddWithValue("@BillNo", BillNo);
            cmd.Parameters.AddWithValue("@MAWB", DBNull.Value);
            cmd.Parameters.AddWithValue("@HAWB", HAWB);
            cmd.Parameters.AddWithValue("@Shipperl1", Shipperl1);
            cmd.Parameters.AddWithValue("@Shipperl2", Shipperl2);
            cmd.Parameters.AddWithValue("@Shipperl3", Shipperl3);
            cmd.Parameters.AddWithValue("@Shipperl4", Shipperl4);
            cmd.Parameters.AddWithValue("@Shipperl5", Shipperl5);
            cmd.Parameters.AddWithValue("@Shipperl6", Shipperl6);
            cmd.Parameters.AddWithValue("@Consigneel1", Consigneel1);
            cmd.Parameters.AddWithValue("@Consigneel2", Consigneel2);
            cmd.Parameters.AddWithValue("@Consigneel3", Consigneel3);
            cmd.Parameters.AddWithValue("@Consigneel4", Consigneel4);
            cmd.Parameters.AddWithValue("@Consigneel5", Consigneel5);
            cmd.Parameters.AddWithValue("@Consigneel6", Consigneel6);
            cmd.Parameters.AddWithValue("@Airline", Airline);
            cmd.Parameters.AddWithValue("@CAgentl1", CAgentl1);
            cmd.Parameters.AddWithValue("@CAgentl2", CAgentl2);
            cmd.Parameters.AddWithValue("@CAgentl3", CAgentl3);
            cmd.Parameters.AddWithValue("@IATACode", IATACode);
            cmd.Parameters.AddWithValue("@IATAAccNo", IATAAccNo);
            cmd.Parameters.AddWithValue("@Freight", Freight);
            cmd.Parameters.AddWithValue("@AInfo", AInfo);
            cmd.Parameters.AddWithValue("@Origin", Origin);
            cmd.Parameters.AddWithValue("@RefNo", RefNo);
            cmd.Parameters.AddWithValue("@OSI1", OSI1);
            cmd.Parameters.AddWithValue("@OSI2", OSI2);
            cmd.Parameters.AddWithValue("@DCode", DCode);
            cmd.Parameters.AddWithValue("@ACode", ACode);
            cmd.Parameters.AddWithValue("@To1", To1);
            cmd.Parameters.AddWithValue("@By1", By1);
            cmd.Parameters.AddWithValue("@To2", To2);
            cmd.Parameters.AddWithValue("@By2", By2);
            cmd.Parameters.AddWithValue("@Currency", Currency);
            cmd.Parameters.AddWithValue("@CHGS", CHGS);
            cmd.Parameters.AddWithValue("@WP", WP);
            cmd.Parameters.AddWithValue("@WC", WC);
            cmd.Parameters.AddWithValue("@OP", OP);
            cmd.Parameters.AddWithValue("@OC", OC);
            cmd.Parameters.AddWithValue("@DVCarriage", DVCarriage);
            cmd.Parameters.AddWithValue("@DVCustoms", DVCustoms);
            cmd.Parameters.AddWithValue("@Dest", Dest);
            cmd.Parameters.AddWithValue("@RFlight", RFlight);
            cmd.Parameters.AddWithValue("@RFDate", RFDate);
            cmd.Parameters.AddWithValue("@Ins", Ins);
            cmd.Parameters.AddWithValue("@HInfo", HInfo);
            cmd.Parameters.AddWithValue("@SCI", SCI);
            cmd.Parameters.AddWithValue("@P1", P1);
            cmd.Parameters.AddWithValue("@KGQ1", KGQ1);
            cmd.Parameters.AddWithValue("@GW1", GW1);
            cmd.Parameters.AddWithValue("@CIN1", CIN1);
            cmd.Parameters.AddWithValue("@CW1", CW1);
            cmd.Parameters.AddWithValue("@Rate1", Rate1);
            cmd.Parameters.AddWithValue("@Total1", Total1);
            cmd.Parameters.AddWithValue("@TotalPieces", TotalPieces);
            cmd.Parameters.AddWithValue("@TotalGW", TotalGW);
            cmd.Parameters.AddWithValue("@Total", Total);
            cmd.Parameters.AddWithValue("@Nature", Nature);
            cmd.Parameters.AddWithValue("@Dimn", Dimn);
            cmd.Parameters.AddWithValue("@Notify", Notify);
            cmd.Parameters.AddWithValue("@PWC", PWC);
            cmd.Parameters.AddWithValue("@PVC", PVC);
            cmd.Parameters.AddWithValue("@PTax", PTax);
            cmd.Parameters.AddWithValue("@PCAgent", PCAgent);
            cmd.Parameters.AddWithValue("@PCCarrier", PCCarrier);
            cmd.Parameters.AddWithValue("@TotalPrepaid", TotalPrepaid);
            cmd.Parameters.AddWithValue("@CWC", CWC);
            cmd.Parameters.AddWithValue("@CVC", CVC);
            cmd.Parameters.AddWithValue("@CTax", CTax);
            cmd.Parameters.AddWithValue("@CCAgent", CCAgent);
            cmd.Parameters.AddWithValue("@CCCarrier", CCCarrier);
            cmd.Parameters.AddWithValue("@TotalCollect", TotalCollect);
            cmd.Parameters.AddWithValue("@OCharges", OCharges);
            cmd.Parameters.AddWithValue("@OChargesCust", OChargesCust);
            cmd.Parameters.AddWithValue("@ShipperSign", ShipperSign);
            cmd.Parameters.AddWithValue("@EXeDate", EXeDate);
            cmd.Parameters.AddWithValue("@Place", Place);
            cmd.Parameters.AddWithValue("@IssueSign", IssueSign);
            cmd.Parameters.AddWithValue("@Remarks", Remarks);
            cmd.Parameters.AddWithValue("@Active", Active);
            cmd.Parameters.AddWithValue("@CreateBy", DBNull.Value);
            cmd.Parameters.AddWithValue("@CreateDate", DBNull.Value);
            cmd.Parameters.AddWithValue("@ModifyBy", ModifyBy);
            cmd.Parameters.AddWithValue("@ModifyDate", ModifyDate);
            cmd.Parameters.AddWithValue("@ExtenDate", DBNull.Value);
            cmd.Parameters.AddWithValue("@Month", Month);
            //cmd.Parameters.AddWithValue("@Naturel1", Naturel1);
            //cmd.Parameters.AddWithValue("@Naturel2", Naturel2);
            //cmd.Parameters.AddWithValue("@Naturel3", Naturel3);
            //cmd.Parameters.AddWithValue("@Naturel4", Naturel4);
            //cmd.Parameters.AddWithValue("@Naturel5", Naturel5);
            //cmd.Parameters.AddWithValue("@Naturel6", Naturel6);
            //cmd.Parameters.AddWithValue("@Naturel7", Naturel7);
            //cmd.Parameters.AddWithValue("@Naturel8", Naturel8);
            //cmd.Parameters.AddWithValue("@Naturel9", Naturel9);
            //cmd.Parameters.AddWithValue("@Naturel10", Naturel10);
            //cmd.Parameters.AddWithValue("@Naturel11", Naturel11);
            //cmd.Parameters.AddWithValue("@Naturel12", Naturel12);
            //cmd.Parameters.AddWithValue("@Naturel13", Naturel13);
            //cmd.Parameters.AddWithValue("@Naturel14", Naturel14);
            //cmd.Parameters.AddWithValue("@Naturel15", Naturel15);
            //cmd.Parameters.AddWithValue("@TemplateName", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "UpdateHAWB");
            int InsertCnt = cmd.ExecuteNonQuery();
            conn.Close();
            return InsertCnt > 0 ? true : false;
        }

        public bool AWB_Delete(int Id, string CCode, string Type, string JobNo, string MAWB)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_AWB";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@JobNo", JobNo);
            cmd.Parameters.AddWithValue("@Type", Type);
            cmd.Parameters.AddWithValue("@MAWB", MAWB);
            cmd.Parameters.AddWithValue("@HAWB", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "DeleteMAWB");
            int InsertCnt = cmd.ExecuteNonQuery();
            conn.Close();
            return InsertCnt > 0 ? true : false;
        }

        public bool HAWB_Delete(int Id, string CCode, string Type, string JobNo, string HAWB)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_AWB";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@JobNo", JobNo);
            cmd.Parameters.AddWithValue("@Type", Type);
            cmd.Parameters.AddWithValue("@MAWB", DBNull.Value);
            cmd.Parameters.AddWithValue("@HAWB", HAWB);
            cmd.Parameters.AddWithValue("@StatementType", "DeleteHAWB");
            int InsertCnt = cmd.ExecuteNonQuery();
            conn.Close();
            return InsertCnt > 0 ? true : false;
        }
        // AWB Month
        public SqlDataReader AWB_Report_Month(string CCode)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_AWBReport";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@Type", DBNull.Value);
            cmd.Parameters.AddWithValue("@Month", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "Month");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }

        public SqlDataReader AWB_Report_MonthWise(string CCode, string Type, string Month)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_AWBReport";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@Type", Type);
            cmd.Parameters.AddWithValue("@Month", Month);
            cmd.Parameters.AddWithValue("@StatementType", "SelectMonthWise");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }
        // AWB Other Charges
        public SqlDataReader AWB_OC_Search(string CCode, string JobNo)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_AWB_OC";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@JobNo", JobNo);
            cmd.Parameters.AddWithValue("@StatementType", "SelectJob");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }

        public bool AWB_OC_New(string CCode, string JobNo, string ATR_DA, string SB_DA, string MHC_DA, string EPCG_DA, string TX_DA, string AGENCY_DA, string AWB_DA, string APT_DA, string PCA_DA, string CMC_DA, string DEPB_DA, string DOCS_DA, string GSP_DA, string HAWB_DA, string MISC_CHARGES_DA, string MOT_DA, string TC_DA, string OSC_DA, string STAX_DA, string AWC_DC, string DBC_DC, string XRAY_DC, string EXPCHG_DC, string SURCHARGE_DC, string CTG_DC, string MYC_DC, string FSC_DC, string MISC_DC, string SSC_DC, string CG_DC, string SCH_DC, string CC_DC, string AWB_DC, string DGD_DC, string SC_DC, string SGN_DC, string AHC_DC, string PCC_DA, string AMS_DC, string MOC_DC)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_AWB_OC_Changes";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Ccode", CCode);
            cmd.Parameters.AddWithValue("@JobNo", JobNo);
            cmd.Parameters.AddWithValue("@ATR_DA", ATR_DA);
            cmd.Parameters.AddWithValue("@SB_DA", SB_DA);
            cmd.Parameters.AddWithValue("@MHC_DA", MHC_DA);
            cmd.Parameters.AddWithValue("@EPCG_DA", EPCG_DA);
            cmd.Parameters.AddWithValue("@TX_DA", TX_DA);
            cmd.Parameters.AddWithValue("@AGENCY_DA", AGENCY_DA);
            cmd.Parameters.AddWithValue("@AWB_DA", AWB_DA);
            cmd.Parameters.AddWithValue("@APT_DA", APT_DA);
            cmd.Parameters.AddWithValue("@PCA_DA", PCA_DA);
            cmd.Parameters.AddWithValue("@CMC_DA", CMC_DA);
            cmd.Parameters.AddWithValue("@DEPB_DA", DEPB_DA);
            cmd.Parameters.AddWithValue("@DOCS_DA", DOCS_DA);
            cmd.Parameters.AddWithValue("@GSP_DA", GSP_DA);
            cmd.Parameters.AddWithValue("@HAWB_DA", HAWB_DA);
            cmd.Parameters.AddWithValue("@MISC_CHARGES_DA", MISC_CHARGES_DA);
            cmd.Parameters.AddWithValue("@MOT_DA", MOT_DA);
            cmd.Parameters.AddWithValue("@TC_DA", TC_DA);
            cmd.Parameters.AddWithValue("@OSC_DA", OSC_DA);
            cmd.Parameters.AddWithValue("@STAX_DA", STAX_DA);
            cmd.Parameters.AddWithValue("@AWC_DC", AWC_DC);
            cmd.Parameters.AddWithValue("@DBC_DC", DBC_DC);
            cmd.Parameters.AddWithValue("@XRAY_DC", XRAY_DC);
            cmd.Parameters.AddWithValue("@EXPCHG_DC", EXPCHG_DC);
            cmd.Parameters.AddWithValue("@SURCHARGE_DC", SURCHARGE_DC);
            cmd.Parameters.AddWithValue("@CTG_DC", CTG_DC);
            cmd.Parameters.AddWithValue("@MYC_DC", MYC_DC);
            cmd.Parameters.AddWithValue("@FSC_DC", FSC_DC);
            cmd.Parameters.AddWithValue("@MISC_DC", MISC_DC);
            cmd.Parameters.AddWithValue("@SSC_DC", SSC_DC);
            cmd.Parameters.AddWithValue("@CG_DC", CG_DC);
            cmd.Parameters.AddWithValue("@SCH_DC", SCH_DC);
            cmd.Parameters.AddWithValue("@CC_DC", CC_DC);
            cmd.Parameters.AddWithValue("@AWB_DC", AWB_DC);
            cmd.Parameters.AddWithValue("@DGD_DC", DGD_DC);
            cmd.Parameters.AddWithValue("@SC_DC", SC_DC);
            cmd.Parameters.AddWithValue("@SGN_DC", SGN_DC);
            cmd.Parameters.AddWithValue("@AHC_DC", AHC_DC);
            cmd.Parameters.AddWithValue("@PCC_DA", PCC_DA);
            cmd.Parameters.AddWithValue("@AMS_DC", AMS_DC);
            cmd.Parameters.AddWithValue("@MOC_DC", MOC_DC);
            cmd.Parameters.AddWithValue("@StatementType", "Insert");
            int InsertCnt = cmd.ExecuteNonQuery();
            conn.Close();
            return InsertCnt > 0 ? true : false;
        }

        public bool AWB_OC_Update(string CCode, string JobNo, string ATR_DA, string SB_DA, string MHC_DA, string EPCG_DA, string TX_DA, string AGENCY_DA, string AWB_DA, string APT_DA, string PCA_DA, string CMC_DA, string DEPB_DA, string DOCS_DA, string GSP_DA, string HAWB_DA, string MISC_CHARGES_DA, string MOT_DA, string TC_DA, string OSC_DA, string STAX_DA, string AWC_DC, string DBC_DC, string XRAY_DC, string EXPCHG_DC, string SURCHARGE_DC, string CTG_DC, string MYC_DC, string FSC_DC, string MISC_DC, string SSC_DC, string CG_DC, string SCH_DC, string CC_DC, string AWB_DC, string DGD_DC, string SC_DC, string SGN_DC, string AHC_DC, string PCC_DA, string AMS_DC, string MOC_DC)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_AWB_OC_Changes";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Ccode", CCode);
            cmd.Parameters.AddWithValue("@JobNo", JobNo);
            cmd.Parameters.AddWithValue("@ATR_DA", ATR_DA);
            cmd.Parameters.AddWithValue("@SB_DA", SB_DA);
            cmd.Parameters.AddWithValue("@MHC_DA", MHC_DA);
            cmd.Parameters.AddWithValue("@EPCG_DA", EPCG_DA);
            cmd.Parameters.AddWithValue("@TX_DA", TX_DA);
            cmd.Parameters.AddWithValue("@AGENCY_DA", AGENCY_DA);
            cmd.Parameters.AddWithValue("@AWB_DA", AWB_DA);
            cmd.Parameters.AddWithValue("@APT_DA", APT_DA);
            cmd.Parameters.AddWithValue("@PCA_DA", PCA_DA);
            cmd.Parameters.AddWithValue("@CMC_DA", CMC_DA);
            cmd.Parameters.AddWithValue("@DEPB_DA", DEPB_DA);
            cmd.Parameters.AddWithValue("@DOCS_DA", DOCS_DA);
            cmd.Parameters.AddWithValue("@GSP_DA", GSP_DA);
            cmd.Parameters.AddWithValue("@HAWB_DA", HAWB_DA);
            cmd.Parameters.AddWithValue("@MISC_CHARGES_DA", MISC_CHARGES_DA);
            cmd.Parameters.AddWithValue("@MOT_DA", MOT_DA);
            cmd.Parameters.AddWithValue("@TC_DA", TC_DA);
            cmd.Parameters.AddWithValue("@OSC_DA", OSC_DA);
            cmd.Parameters.AddWithValue("@STAX_DA", STAX_DA);
            cmd.Parameters.AddWithValue("@AWC_DC", AWC_DC);
            cmd.Parameters.AddWithValue("@DBC_DC", DBC_DC);
            cmd.Parameters.AddWithValue("@XRAY_DC", XRAY_DC);
            cmd.Parameters.AddWithValue("@EXPCHG_DC", EXPCHG_DC);
            cmd.Parameters.AddWithValue("@SURCHARGE_DC", SURCHARGE_DC);
            cmd.Parameters.AddWithValue("@CTG_DC", CTG_DC);
            cmd.Parameters.AddWithValue("@MYC_DC", MYC_DC);
            cmd.Parameters.AddWithValue("@FSC_DC", FSC_DC);
            cmd.Parameters.AddWithValue("@MISC_DC", MISC_DC);
            cmd.Parameters.AddWithValue("@SSC_DC", SSC_DC);
            cmd.Parameters.AddWithValue("@CG_DC", CG_DC);
            cmd.Parameters.AddWithValue("@SCH_DC", SCH_DC);
            cmd.Parameters.AddWithValue("@CC_DC", CC_DC);
            cmd.Parameters.AddWithValue("@AWB_DC", AWB_DC);
            cmd.Parameters.AddWithValue("@DGD_DC", DGD_DC);
            cmd.Parameters.AddWithValue("@SC_DC", SC_DC);
            cmd.Parameters.AddWithValue("@SGN_DC", SGN_DC);
            cmd.Parameters.AddWithValue("@AHC_DC", AHC_DC);
            cmd.Parameters.AddWithValue("@PCC_DA", PCC_DA);
            cmd.Parameters.AddWithValue("@AMS_DC", AMS_DC);
            cmd.Parameters.AddWithValue("@MOC_DC", MOC_DC);
            cmd.Parameters.AddWithValue("@StatementType", "Update");
            int InsertCnt = cmd.ExecuteNonQuery();
            conn.Close();
            return InsertCnt > 0 ? true : false;
        }

        // Invoice            
        public SqlDataReader Invoice_JobNo(string CCode, string InvoiceType)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_InvoiceDetails";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@Category", DBNull.Value);
            cmd.Parameters.AddWithValue("@JobNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@BillNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@BillDate", DBNull.Value);
            cmd.Parameters.AddWithValue("@To1", DBNull.Value);
            cmd.Parameters.AddWithValue("@SalesRep", DBNull.Value);
            cmd.Parameters.AddWithValue("@Month", DBNull.Value);
            cmd.Parameters.AddWithValue("@CurrValue", DBNull.Value);
            cmd.Parameters.AddWithValue("@InvoiceType", InvoiceType);
            cmd.Parameters.AddWithValue("@CreditNoteNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@AWBNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "SelectJobNo");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }

        public SqlDataReader Invoice_Search_Month(string CCode, string InvoiceType)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_InvoiceDetails";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@Category", DBNull.Value);
            cmd.Parameters.AddWithValue("@JobNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@BillNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@BillDate", DBNull.Value);
            cmd.Parameters.AddWithValue("@To1", DBNull.Value);
            cmd.Parameters.AddWithValue("@SalesRep", DBNull.Value);
            cmd.Parameters.AddWithValue("@Month", DBNull.Value);
            cmd.Parameters.AddWithValue("@CurrValue", DBNull.Value);
            cmd.Parameters.AddWithValue("@InvoiceType", InvoiceType);
            cmd.Parameters.AddWithValue("@CreditNoteNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@AWBNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "SelectMonth");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }

        public SqlDataReader Invoice_Search_Month_Customer(string CCode, string To1, string Category)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_InvoiceDetails";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@Category", Category);
            cmd.Parameters.AddWithValue("@JobNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@BillNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@BillDate", DBNull.Value);
            cmd.Parameters.AddWithValue("@To1", To1);
            cmd.Parameters.AddWithValue("@SalesRep", DBNull.Value);
            cmd.Parameters.AddWithValue("@Month", DBNull.Value);
            cmd.Parameters.AddWithValue("@CurrValue", DBNull.Value);
            cmd.Parameters.AddWithValue("@InvoiceType", DBNull.Value);
            cmd.Parameters.AddWithValue("@CreditNoteNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@AWBNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "SelectMonthCustomerWise");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }

        public SqlDataReader Invoice_Search_Customer(string CCode, string Category)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_InvoiceDetails";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@Category", Category);
            cmd.Parameters.AddWithValue("@JobNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@BillNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@BillDate", DBNull.Value);
            cmd.Parameters.AddWithValue("@To1", DBNull.Value);
            cmd.Parameters.AddWithValue("@SalesRep", DBNull.Value);
            cmd.Parameters.AddWithValue("@Month", DBNull.Value);
            cmd.Parameters.AddWithValue("@CurrValue", DBNull.Value);
            cmd.Parameters.AddWithValue("@InvoiceType", DBNull.Value);
            cmd.Parameters.AddWithValue("@CreditNoteNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@AWBNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "SelectCustomer");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }
        public SqlDataReader Invoice_Search_CustomerWiseReport(string CCode, string Month, string InvoiceType, string Category)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_InvoiceDetails";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@Category", Category);
            cmd.Parameters.AddWithValue("@JobNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@BillNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@BillDate", DBNull.Value);
            cmd.Parameters.AddWithValue("@To1", DBNull.Value);
            cmd.Parameters.AddWithValue("@SalesRep", DBNull.Value);
            cmd.Parameters.AddWithValue("@Month", Month);
            cmd.Parameters.AddWithValue("@CurrValue", DBNull.Value);
            cmd.Parameters.AddWithValue("@InvoiceType", InvoiceType);
            cmd.Parameters.AddWithValue("@CreditNoteNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@AWBNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "SelectCustomerWise");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }
        public SqlDataReader Invoice_Search_CustomerWiseReport_1(string CCode, string Month, string InvoiceType)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_InvoiceDetails";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@Category", DBNull.Value);
            cmd.Parameters.AddWithValue("@JobNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@BillNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@BillDate", DBNull.Value);
            cmd.Parameters.AddWithValue("@To1", DBNull.Value);
            cmd.Parameters.AddWithValue("@SalesRep", DBNull.Value);
            cmd.Parameters.AddWithValue("@Month", Month);
            cmd.Parameters.AddWithValue("@CurrValue", DBNull.Value);
            cmd.Parameters.AddWithValue("@InvoiceType", InvoiceType);
            cmd.Parameters.AddWithValue("@CreditNoteNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@AWBNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "SelectCustomerWise2");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }
        public SqlDataReader Invoice_Search_CustomerMonthWiseReport(string CCode, string Customer, string Month, string Category)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_InvoiceDetails";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@Category", Category);
            cmd.Parameters.AddWithValue("@JobNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@BillNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@BillDate", DBNull.Value);
            cmd.Parameters.AddWithValue("@To1", Customer);
            cmd.Parameters.AddWithValue("@SalesRep", DBNull.Value);
            cmd.Parameters.AddWithValue("@Month", Month);
            cmd.Parameters.AddWithValue("@CurrValue", DBNull.Value);
            cmd.Parameters.AddWithValue("@InvoiceType", DBNull.Value);
            cmd.Parameters.AddWithValue("@CreditNoteNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@AWBNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "SelectCustomerMonthWise");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }

        public SqlDataReader Invoice_InvoiceCopy(string CCode, string JobNo, string BillNo, string Category, string NewBillNo, string NewJobNo)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_InvoiceDetails";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@Category", Category);
            cmd.Parameters.AddWithValue("@JobNo", JobNo);
            cmd.Parameters.AddWithValue("@BillNo", BillNo);
            cmd.Parameters.AddWithValue("@NewBillNo", NewBillNo);
            cmd.Parameters.AddWithValue("@NewJobNo", NewJobNo);
            cmd.Parameters.AddWithValue("@StatementType", "InvoiceCopy");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }

        // Sales Report month wise
        public SqlDataReader Invoice_Search_SalesReport(string CCode, string Month, string InvoiceType)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_InvoiceDetails";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@Category", DBNull.Value);
            cmd.Parameters.AddWithValue("@JobNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@BillNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@BillDate", DBNull.Value);
            cmd.Parameters.AddWithValue("@To1", DBNull.Value);
            cmd.Parameters.AddWithValue("@SalesRep", DBNull.Value);
            cmd.Parameters.AddWithValue("@Month", Month);
            cmd.Parameters.AddWithValue("@CurrValue", DBNull.Value);
            cmd.Parameters.AddWithValue("@InvoiceType", InvoiceType);
            cmd.Parameters.AddWithValue("@CreditNoteNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@AWBNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "SelectSales");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }
        public SqlDataReader Invoice_Search_SalesMonthWiseReport(string CCode, string SalesRep, string Month, string InvoiceType)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_InvoiceDetails";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@Category", DBNull.Value);
            cmd.Parameters.AddWithValue("@JobNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@BillNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@BillDate", DBNull.Value);
            cmd.Parameters.AddWithValue("@To1", DBNull.Value);
            cmd.Parameters.AddWithValue("@SalesRep", SalesRep);
            cmd.Parameters.AddWithValue("@Month", Month);
            cmd.Parameters.AddWithValue("@CurrValue", DBNull.Value);
            cmd.Parameters.AddWithValue("@InvoiceType", InvoiceType);
            cmd.Parameters.AddWithValue("@CreditNoteNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@AWBNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "SelectSalesMonthWise");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }

        public SqlDataReader Invoice_Search_MonthWiseReportAir(string CCode, string Month, string InvoiceType)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_InvoiceDetails";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@Category", DBNull.Value);
            cmd.Parameters.AddWithValue("@JobNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@BillNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@BillDate", DBNull.Value);
            cmd.Parameters.AddWithValue("@To1", DBNull.Value);
            cmd.Parameters.AddWithValue("@SalesRep", DBNull.Value);
            cmd.Parameters.AddWithValue("@Month", Month);
            cmd.Parameters.AddWithValue("@CurrValue", DBNull.Value);
            cmd.Parameters.AddWithValue("@InvoiceType", InvoiceType);
            cmd.Parameters.AddWithValue("@CreditNoteNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@AWBNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "SelectMonthWiseReport3Air");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }

        public SqlDataReader Invoice_Search_MonthWiseReportSea(string CCode, string Month, string InvoiceType)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_InvoiceDetails";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@Category", DBNull.Value);
            cmd.Parameters.AddWithValue("@JobNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@BillNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@BillDate", DBNull.Value);
            cmd.Parameters.AddWithValue("@To1", DBNull.Value);
            cmd.Parameters.AddWithValue("@SalesRep", DBNull.Value);
            cmd.Parameters.AddWithValue("@Month", Month);
            cmd.Parameters.AddWithValue("@CurrValue", DBNull.Value);
            cmd.Parameters.AddWithValue("@InvoiceType", InvoiceType);
            cmd.Parameters.AddWithValue("@CreditNoteNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@AWBNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "SelectMonthWiseReport3Sea");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }

        public SqlDataReader Invoice_Search_MonthWise(string CCode, string Month, string InvoiceType)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_InvoiceDetails";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@Category", DBNull.Value);
            cmd.Parameters.AddWithValue("@JobNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@BillNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@BillDate", DBNull.Value);
            cmd.Parameters.AddWithValue("@To1", DBNull.Value);
            cmd.Parameters.AddWithValue("@SalesRep", DBNull.Value);
            cmd.Parameters.AddWithValue("@Month", Month);
            cmd.Parameters.AddWithValue("@CurrValue", DBNull.Value);
            cmd.Parameters.AddWithValue("@InvoiceType", InvoiceType);
            cmd.Parameters.AddWithValue("@CreditNoteNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@AWBNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "SelectMonthWise");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }

        public SqlDataReader Invoice_Search_MonthWiseReport(string CCode, string Month, string InvoiceType)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_InvoiceDetails";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@Category", DBNull.Value);
            cmd.Parameters.AddWithValue("@JobNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@BillNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@BillDate", DBNull.Value);
            cmd.Parameters.AddWithValue("@To1", DBNull.Value);
            cmd.Parameters.AddWithValue("@SalesRep", DBNull.Value);
            cmd.Parameters.AddWithValue("@Month", Month);
            cmd.Parameters.AddWithValue("@CurrValue", DBNull.Value);
            cmd.Parameters.AddWithValue("@InvoiceType", InvoiceType);
            cmd.Parameters.AddWithValue("@CreditNoteNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@AWBNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "SelectMonthWiseReport");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }


        public SqlDataReader Invoice_Search_TransportReport(string CCode, string Month, string Category)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_InvoiceDetails";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@Category", Category);
            cmd.Parameters.AddWithValue("@JobNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@BillNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@BillDate", DBNull.Value);
            cmd.Parameters.AddWithValue("@To1", DBNull.Value);
            cmd.Parameters.AddWithValue("@SalesRep", DBNull.Value);
            cmd.Parameters.AddWithValue("@Month", Month);
            cmd.Parameters.AddWithValue("@CurrValue", DBNull.Value);
            cmd.Parameters.AddWithValue("@InvoiceType", DBNull.Value);
            cmd.Parameters.AddWithValue("@CreditNoteNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@AWBNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "TransportReport");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }
        public SqlDataReader Invoice_Search_MonthWiseReport2(string CCode, string Month, string Payment, string InvoiceType)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_InvoiceDetails";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@Category", DBNull.Value);
            cmd.Parameters.AddWithValue("@JobNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@BillNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@BillDate", DBNull.Value);
            cmd.Parameters.AddWithValue("@To1", DBNull.Value);
            cmd.Parameters.AddWithValue("@SalesRep", DBNull.Value);
            cmd.Parameters.AddWithValue("@Month", Month);
            cmd.Parameters.AddWithValue("@CurrValue", Payment);
            cmd.Parameters.AddWithValue("@InvoiceType", InvoiceType);
            cmd.Parameters.AddWithValue("@CreditNoteNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@AWBNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "SelectMonthWiseReport2");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }

        public SqlDataReader Invoice_Search_MonthWiseReport3(string CCode, string Month, string Customer, string InvoiceType)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_InvoiceDetails";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@Category", DBNull.Value);
            cmd.Parameters.AddWithValue("@JobNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@BillNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@BillDate", DBNull.Value);
            cmd.Parameters.AddWithValue("@To1", Customer);
            cmd.Parameters.AddWithValue("@SalesRep", DBNull.Value);
            cmd.Parameters.AddWithValue("@Month", Month);
            cmd.Parameters.AddWithValue("@CurrValue", DBNull.Value);
            cmd.Parameters.AddWithValue("@InvoiceType", InvoiceType);
            cmd.Parameters.AddWithValue("@CreditNoteNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@AWBNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "SelectMonthWiseReport2");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }

        public SqlDataReader Invoice_Search_JobNo(string CCode, string JobNo, string InvoiceType)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_InvoiceDetails";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@Category", DBNull.Value);
            cmd.Parameters.AddWithValue("@JobNo", JobNo);
            cmd.Parameters.AddWithValue("@BillNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@BillDate", DBNull.Value);
            cmd.Parameters.AddWithValue("@To1", DBNull.Value);
            cmd.Parameters.AddWithValue("@SalesRep", DBNull.Value);
            cmd.Parameters.AddWithValue("@Month", DBNull.Value);
            cmd.Parameters.AddWithValue("@CurrValue", DBNull.Value);
            cmd.Parameters.AddWithValue("@InvoiceType", InvoiceType);
            cmd.Parameters.AddWithValue("@CreditNoteNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@AWBNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "SelectInvoiceJobNo");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }

        public SqlDataReader Invoice_Search_JobNo_(string CCode, string JobNo, string InvoiceType)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_InvoiceDetails";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@Category", DBNull.Value);
            cmd.Parameters.AddWithValue("@JobNo", JobNo);
            cmd.Parameters.AddWithValue("@BillNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@BillDate", DBNull.Value);
            cmd.Parameters.AddWithValue("@To1", DBNull.Value);
            cmd.Parameters.AddWithValue("@SalesRep", DBNull.Value);
            cmd.Parameters.AddWithValue("@Month", DBNull.Value);
            cmd.Parameters.AddWithValue("@CurrValue", DBNull.Value);
            cmd.Parameters.AddWithValue("@InvoiceType", InvoiceType);
            cmd.Parameters.AddWithValue("@CreditNoteNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@AWBNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "SelectInvoice_JobNo");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }

        public SqlDataReader Invoice_Search_BillNo(string CCode, string BillNo, string InvoiceType)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_InvoiceDetails";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@Category", DBNull.Value);
            cmd.Parameters.AddWithValue("@JobNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@BillNo", BillNo);
            cmd.Parameters.AddWithValue("@BillDate", DBNull.Value);
            cmd.Parameters.AddWithValue("@To1", DBNull.Value);
            cmd.Parameters.AddWithValue("@SalesRep", DBNull.Value);
            cmd.Parameters.AddWithValue("@Month", DBNull.Value);
            cmd.Parameters.AddWithValue("@CurrValue", DBNull.Value);
            cmd.Parameters.AddWithValue("@InvoiceType", InvoiceType);
            cmd.Parameters.AddWithValue("@CreditNoteNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@AWBNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "SelectInvoice");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }

        public SqlDataReader Invoice_Search_BillNo2(string CCode, string BillNo, string InvoiceType)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_InvoiceDetails";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@Category", DBNull.Value);
            cmd.Parameters.AddWithValue("@JobNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@BillNo", BillNo);
            cmd.Parameters.AddWithValue("@BillDate", DBNull.Value);
            cmd.Parameters.AddWithValue("@To1", DBNull.Value);
            cmd.Parameters.AddWithValue("@SalesRep", DBNull.Value);
            cmd.Parameters.AddWithValue("@Month", DBNull.Value);
            cmd.Parameters.AddWithValue("@CurrValue", DBNull.Value);
            cmd.Parameters.AddWithValue("@InvoiceType", InvoiceType);
            cmd.Parameters.AddWithValue("@CreditNoteNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@AWBNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "SelectInvoiceNo");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }

        public SqlDataReader Invoice_Search_BillNo3(string CCode, string BillNo, string InvoiceType)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_InvoiceDetails";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@Category", DBNull.Value);
            cmd.Parameters.AddWithValue("@JobNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@BillNo", BillNo);
            cmd.Parameters.AddWithValue("@BillDate", DBNull.Value);
            cmd.Parameters.AddWithValue("@To1", DBNull.Value);
            cmd.Parameters.AddWithValue("@SalesRep", DBNull.Value);
            cmd.Parameters.AddWithValue("@Month", DBNull.Value);
            cmd.Parameters.AddWithValue("@CurrValue", DBNull.Value);
            cmd.Parameters.AddWithValue("@InvoiceType", InvoiceType);
            cmd.Parameters.AddWithValue("@CreditNoteNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@AWBNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "SelectInvoice3");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }
        public SqlDataReader Invoice_Search_BillNo_Category(string CCode, string BillNo, string InvoiceType, string Category)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_InvoiceDetails";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@Category", Category);
            cmd.Parameters.AddWithValue("@JobNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@BillNo", BillNo);
            cmd.Parameters.AddWithValue("@BillDate", DBNull.Value);
            cmd.Parameters.AddWithValue("@To1", DBNull.Value);
            cmd.Parameters.AddWithValue("@SalesRep", DBNull.Value);
            cmd.Parameters.AddWithValue("@Month", DBNull.Value);
            cmd.Parameters.AddWithValue("@CurrValue", DBNull.Value);
            cmd.Parameters.AddWithValue("@InvoiceType", InvoiceType);
            cmd.Parameters.AddWithValue("@CreditNoteNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@AWBNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "SelectInvoice");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }

        public SqlDataReader Invoice_Search_AWBNo(string CCode, string AWBNo, string InvoiceType)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_InvoiceDetails";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@Category", DBNull.Value);
            cmd.Parameters.AddWithValue("@JobNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@BillNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@BillDate", DBNull.Value);
            cmd.Parameters.AddWithValue("@To1", DBNull.Value);
            cmd.Parameters.AddWithValue("@SalesRep", DBNull.Value);
            cmd.Parameters.AddWithValue("@Month", DBNull.Value);
            cmd.Parameters.AddWithValue("@CurrValue", DBNull.Value);
            cmd.Parameters.AddWithValue("@InvoiceType", InvoiceType);
            cmd.Parameters.AddWithValue("@CreditNoteNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@AWBNo", AWBNo);
            cmd.Parameters.AddWithValue("@StatementType", "SelectInvoice_AWBNo");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }

        public SqlDataReader Invoice_Search_CreditNoteNo(string CCode, string CreditNoteNo, string InvoiceType)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_InvoiceDetails";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@Category", DBNull.Value);
            cmd.Parameters.AddWithValue("@JobNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@BillNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@BillDate", DBNull.Value);
            cmd.Parameters.AddWithValue("@To1", DBNull.Value);
            cmd.Parameters.AddWithValue("@SalesRep", DBNull.Value);
            cmd.Parameters.AddWithValue("@Month", DBNull.Value);
            cmd.Parameters.AddWithValue("@CurrValue", DBNull.Value);
            cmd.Parameters.AddWithValue("@InvoiceType", InvoiceType);
            cmd.Parameters.AddWithValue("@CreditNoteNo", CreditNoteNo);
            cmd.Parameters.AddWithValue("@AWBNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "SelectCreditNoteNo");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }

        public SqlDataReader Invoice_Search_NillNoNOTCreditNoteNo(string CCode, string InvoiceType)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_InvoiceDetails";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@Category", DBNull.Value);
            cmd.Parameters.AddWithValue("@JobNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@BillNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@BillDate", DBNull.Value);
            cmd.Parameters.AddWithValue("@To1", DBNull.Value);
            cmd.Parameters.AddWithValue("@SalesRep", DBNull.Value);
            cmd.Parameters.AddWithValue("@Month", DBNull.Value);
            cmd.Parameters.AddWithValue("@CurrValue", DBNull.Value);
            cmd.Parameters.AddWithValue("@InvoiceType", InvoiceType);
            cmd.Parameters.AddWithValue("@CreditNoteNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@AWBNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "SelectBillNoNOTCreditNotNo");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }
        public SqlDataReader Invoice_Search_BillNoGrd(string CCode, string BillNo, string InvoiceType)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_InvoiceDetails";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@Category", DBNull.Value);
            cmd.Parameters.AddWithValue("@JobNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@BillNo", BillNo);
            cmd.Parameters.AddWithValue("@BillDate", DBNull.Value);
            cmd.Parameters.AddWithValue("@To1", DBNull.Value);
            cmd.Parameters.AddWithValue("@SalesRep", DBNull.Value);
            cmd.Parameters.AddWithValue("@Month", DBNull.Value);
            cmd.Parameters.AddWithValue("@CurrValue", DBNull.Value);
            cmd.Parameters.AddWithValue("@CreditNoteNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@InvoiceType", InvoiceType);
            cmd.Parameters.AddWithValue("@CreditNoteNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@AWBNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "SelectInvoiceGrd");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }
        public SqlDataReader Invoice_BillNoLoad(string CCode, string InvoiceType)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_InvoiceDetails";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@Category", DBNull.Value);
            cmd.Parameters.AddWithValue("@JobNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@BillNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@BillDate", DBNull.Value);
            cmd.Parameters.AddWithValue("@To1", DBNull.Value);
            cmd.Parameters.AddWithValue("@SalesRep", DBNull.Value);
            cmd.Parameters.AddWithValue("@Month", DBNull.Value);
            cmd.Parameters.AddWithValue("@CurrValue", DBNull.Value);
            cmd.Parameters.AddWithValue("@InvoiceType", InvoiceType);
            cmd.Parameters.AddWithValue("@CreditNoteNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@AWBNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "SelectBillNo");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }
        public SqlDataReader Invoice_CategoryWise(string CCode, string Category)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_InvoiceDetails";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@Category", Category);
            cmd.Parameters.AddWithValue("@JobNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@BillNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@BillDate", DBNull.Value);
            cmd.Parameters.AddWithValue("@To1", DBNull.Value);
            cmd.Parameters.AddWithValue("@SalesRep", DBNull.Value);
            cmd.Parameters.AddWithValue("@Month", DBNull.Value);
            cmd.Parameters.AddWithValue("@CurrValue", DBNull.Value);
            cmd.Parameters.AddWithValue("@InvoiceType", DBNull.Value);
            cmd.Parameters.AddWithValue("@CreditNoteNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@AWBNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "SelectCategoryWise");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }

        public SqlDataReader Invoice_PreviousInvoice(string CCode, string InvoiceType)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_InvoiceDetails";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@Category", DBNull.Value);
            cmd.Parameters.AddWithValue("@JobNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@BillNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@BillDate", DBNull.Value);
            cmd.Parameters.AddWithValue("@To1", DBNull.Value);
            cmd.Parameters.AddWithValue("@SalesRep", DBNull.Value);
            cmd.Parameters.AddWithValue("@Month", DBNull.Value);
            cmd.Parameters.AddWithValue("@CurrValue", DBNull.Value);
            cmd.Parameters.AddWithValue("@InvoiceType", InvoiceType);
            cmd.Parameters.AddWithValue("@CreditNoteNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@AWBNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "SelectPreviousInvoice");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }

        public SqlDataReader Invoice_PreviousInvoice_Category(string CCode, string Category, string InvoiceType)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_InvoiceDetails";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@Category", Category);
            cmd.Parameters.AddWithValue("@JobNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@BillNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@BillDate", DBNull.Value);
            cmd.Parameters.AddWithValue("@To1", DBNull.Value);
            cmd.Parameters.AddWithValue("@SalesRep", DBNull.Value);
            cmd.Parameters.AddWithValue("@Month", DBNull.Value);
            cmd.Parameters.AddWithValue("@CurrValue", DBNull.Value);
            cmd.Parameters.AddWithValue("@InvoiceType", InvoiceType);
            cmd.Parameters.AddWithValue("@CreditNoteNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@AWBNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "SelectPreviousInvoiceCategory");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }

        public SqlDataReader Invoice_ProfitLossStmt(string CCode, string Category, string Month, string InvoiceType)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_InvoiceDetails";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@Category", Category);
            cmd.Parameters.AddWithValue("@JobNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@BillNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@BillDate", DBNull.Value);
            cmd.Parameters.AddWithValue("@To1", DBNull.Value);
            cmd.Parameters.AddWithValue("@SalesRep", DBNull.Value);
            cmd.Parameters.AddWithValue("@Month", Month);
            cmd.Parameters.AddWithValue("@CurrValue", DBNull.Value);
            cmd.Parameters.AddWithValue("@InvoiceType", InvoiceType);
            cmd.Parameters.AddWithValue("@CreditNoteNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@AWBNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "SelectPLStatement");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }

        // Invoice Report
        public SqlDataReader Invoice_Search_DailyReport(string CCode, string Month, string InvoiceType)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_InvoiceReport";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@BillDate", DBNull.Value);
            cmd.Parameters.AddWithValue("@To1", DBNull.Value);
            cmd.Parameters.AddWithValue("@SalesRep", DBNull.Value);
            cmd.Parameters.AddWithValue("@Month", Month);
            cmd.Parameters.AddWithValue("@CurrValue", DBNull.Value);
            cmd.Parameters.AddWithValue("@InvoiceType", InvoiceType);
            cmd.Parameters.AddWithValue("@StatementType", "DailyReport");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }

        public bool Invoice_New(string CCode, string Category, string JobNo, string BillNo, string BillDate, string To1, string To2, string To3, string To4, string To5, string Guaranteel1, string Guaranteel2, string Guaranteel3, string Guaranteel4, string GSTNo, string State, string StateCode, string PAN, string Shipper, string Consignee, string AWBNo, string HAWBNo, string SBNo, string SBDate, string Line, string EGM, string CBM, string Origin, string Dest, string Pieces, string Pkgs, string GrWeight, string ChWeight, string ShInvoice, string TotalTax, string TotalNonTax, string IGST, string CGST, string SGST, string Total, string GrandTotal, string Status, string CurrValue, string ExRate, string Remarks, string SalesRep, string Advance, string Balance, string CreateBy, string CreateDate, string Month, string Year, string InvoiceType, string CreditNoteNo)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_InvoiceChanges";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@Category", Category);
            cmd.Parameters.AddWithValue("@JobNo", JobNo);
            cmd.Parameters.AddWithValue("@NewInvoiceNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@BillNo", BillNo);
            cmd.Parameters.AddWithValue("@BillDate", BillDate);
            //cmd.Parameters.AddWithValue("@DueDate", DBNull.Value);
            cmd.Parameters.AddWithValue("@To1", To1);
            cmd.Parameters.AddWithValue("@To2", To2);
            cmd.Parameters.AddWithValue("@To3", To3);
            cmd.Parameters.AddWithValue("@To4", To4);
            cmd.Parameters.AddWithValue("@To5", To5);
            cmd.Parameters.AddWithValue("@Guaranteel1", Guaranteel1);
            cmd.Parameters.AddWithValue("@Guaranteel2", Guaranteel2);
            cmd.Parameters.AddWithValue("@Guaranteel3", Guaranteel3);
            cmd.Parameters.AddWithValue("@Guaranteel4", Guaranteel4);
            cmd.Parameters.AddWithValue("@GSTNo", GSTNo);
            cmd.Parameters.AddWithValue("@State", State);
            cmd.Parameters.AddWithValue("@StateCode", StateCode);
            cmd.Parameters.AddWithValue("@PAN", PAN);
            cmd.Parameters.AddWithValue("@Shipper", Shipper);
            cmd.Parameters.AddWithValue("@Consignee", Consignee);
            cmd.Parameters.AddWithValue("@AWBNo", AWBNo);
            // cmd.Parameters.AddWithValue("@AWBDate", DBNull.Value);
            cmd.Parameters.AddWithValue("@HAWBNo", HAWBNo);
            //cmd.Parameters.AddWithValue("@HAWBDate", DBNull.Value);
            cmd.Parameters.AddWithValue("@SBNo", SBNo);
            cmd.Parameters.AddWithValue("@SBDate", SBDate);
            cmd.Parameters.AddWithValue("@Line", Line);
            cmd.Parameters.AddWithValue("@IGM", EGM);
            cmd.Parameters.AddWithValue("@CBM", CBM);
            cmd.Parameters.AddWithValue("@Origin", Origin);
            cmd.Parameters.AddWithValue("@Dest", Dest);
            cmd.Parameters.AddWithValue("@Pieces", Pieces);
            cmd.Parameters.AddWithValue("@Pkgs", Pkgs);
            cmd.Parameters.AddWithValue("@GrWeight", GrWeight);
            cmd.Parameters.AddWithValue("@ChWeight", ChWeight);
            cmd.Parameters.AddWithValue("@ShInvoice", ShInvoice);
            cmd.Parameters.AddWithValue("@TotalTax", TotalTax);
            cmd.Parameters.AddWithValue("@TotalNonTax", TotalNonTax);
            cmd.Parameters.AddWithValue("@IGST", IGST);
            cmd.Parameters.AddWithValue("@CGST", CGST);
            cmd.Parameters.AddWithValue("@SGST", SGST);
            cmd.Parameters.AddWithValue("@Total", Total);
            //cmd.Parameters.AddWithValue("@Tax", Tax);
            cmd.Parameters.AddWithValue("@GrandTotal", GrandTotal);
            cmd.Parameters.AddWithValue("@Status", Status);
            cmd.Parameters.AddWithValue("@CurrValue", CurrValue);
            cmd.Parameters.AddWithValue("@ExRate", ExRate);
            cmd.Parameters.AddWithValue("@Payment", DBNull.Value);
            cmd.Parameters.AddWithValue("@Remarks", Remarks);
            cmd.Parameters.AddWithValue("@SalesRep", SalesRep);
            cmd.Parameters.AddWithValue("@Advance", Advance);
            cmd.Parameters.AddWithValue("@Balance", Balance);
            cmd.Parameters.AddWithValue("@CreateBy", CreateBy);
            cmd.Parameters.AddWithValue("@CreateDate", CreateDate);
            cmd.Parameters.AddWithValue("@ModifyBy", DBNull.Value);
            cmd.Parameters.AddWithValue("@ModifyDate", DBNull.Value);
            cmd.Parameters.AddWithValue("@Month", Month);
            cmd.Parameters.AddWithValue("@Year", Year);
            cmd.Parameters.AddWithValue("@InvoiceType", InvoiceType);
            cmd.Parameters.AddWithValue("@CreditNoteNo", CreditNoteNo);
            cmd.Parameters.AddWithValue("@StatementType", "Insert");
            int InsertCnt = cmd.ExecuteNonQuery();
            conn.Close();
            return InsertCnt > 0 ? true : false;
        }

        public bool Invoice_Update(string CCode, string Category, string JobNo, string BillNo, string BillDate, string To1, string To2, string To3, string To4, string To5, string Guaranteel1, string Guaranteel2, string Guaranteel3, string Guaranteel4, string GSTNo, string State, string StateCode, string PAN, string Shipper, string Consignee, string AWBNo, string HAWBNo, string SBNo, string SBDate, string Line, string EGM, string CBM, string Origin, string Dest, string Pieces, string Pkgs, string GrWeight, string ChWeight, string ShInvoice, string TotalTax, string TotalNonTax, string IGST, string CGST, string SGST, string Total, string GrandTotal, string Status, string CurrValue, string ExRate, string Remarks, string SalesRep, string Advance, string Balance, string ModifyBy, string ModifyDate, string Month, string Year, string InvoiceType, string CreditNoteNo)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_InvoiceChanges";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@Category", Category);
            cmd.Parameters.AddWithValue("@JobNo", JobNo);
            cmd.Parameters.AddWithValue("@NewInvoiceNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@BillNo", BillNo);
            cmd.Parameters.AddWithValue("@BillDate", BillDate);
            //cmd.Parameters.AddWithValue("@DueDate", DBNull.Value);
            cmd.Parameters.AddWithValue("@To1", To1);
            cmd.Parameters.AddWithValue("@To2", To2);
            cmd.Parameters.AddWithValue("@To3", To3);
            cmd.Parameters.AddWithValue("@To4", To4);
            cmd.Parameters.AddWithValue("@To5", To5);
            cmd.Parameters.AddWithValue("@Guaranteel1", Guaranteel1);
            cmd.Parameters.AddWithValue("@Guaranteel2", Guaranteel2);
            cmd.Parameters.AddWithValue("@Guaranteel3", Guaranteel3);
            cmd.Parameters.AddWithValue("@Guaranteel4", Guaranteel4);
            cmd.Parameters.AddWithValue("@GSTNo", GSTNo);
            cmd.Parameters.AddWithValue("@State", State);
            cmd.Parameters.AddWithValue("@StateCode", StateCode);
            cmd.Parameters.AddWithValue("@PAN", PAN);
            cmd.Parameters.AddWithValue("@Shipper", Shipper);
            cmd.Parameters.AddWithValue("@Consignee", Consignee);
            cmd.Parameters.AddWithValue("@AWBNo", AWBNo);
            // cmd.Parameters.AddWithValue("@AWBDate", DBNull.Value);
            cmd.Parameters.AddWithValue("@HAWBNo", HAWBNo);
            //cmd.Parameters.AddWithValue("@HAWBDate", DBNull.Value);
            cmd.Parameters.AddWithValue("@SBNo", SBNo);
            cmd.Parameters.AddWithValue("@SBDate", SBDate);
            cmd.Parameters.AddWithValue("@Line", Line);
            cmd.Parameters.AddWithValue("@IGM", EGM);
            cmd.Parameters.AddWithValue("@CBM", CBM);
            cmd.Parameters.AddWithValue("@Origin", Origin);
            cmd.Parameters.AddWithValue("@Dest", Dest);
            cmd.Parameters.AddWithValue("@Pieces", Pieces);
            cmd.Parameters.AddWithValue("@Pkgs", Pkgs);
            cmd.Parameters.AddWithValue("@GrWeight", GrWeight);
            cmd.Parameters.AddWithValue("@ChWeight", ChWeight);
            cmd.Parameters.AddWithValue("@ShInvoice", ShInvoice);
            cmd.Parameters.AddWithValue("@TotalTax", TotalTax);
            cmd.Parameters.AddWithValue("@TotalNonTax", TotalNonTax);
            cmd.Parameters.AddWithValue("@IGST", IGST);
            cmd.Parameters.AddWithValue("@CGST", CGST);
            cmd.Parameters.AddWithValue("@SGST", SGST);
            cmd.Parameters.AddWithValue("@Total", Total);
            cmd.Parameters.AddWithValue("@GrandTotal", GrandTotal);
            cmd.Parameters.AddWithValue("@Status", Status);
            cmd.Parameters.AddWithValue("@CurrValue", CurrValue);
            cmd.Parameters.AddWithValue("@ExRate", ExRate);
            cmd.Parameters.AddWithValue("@Payment", DBNull.Value);
            cmd.Parameters.AddWithValue("@Remarks", Remarks);
            cmd.Parameters.AddWithValue("@SalesRep", SalesRep);
            cmd.Parameters.AddWithValue("@Advance", Advance);
            cmd.Parameters.AddWithValue("@Balance", Balance);
            cmd.Parameters.AddWithValue("@CreateBy", DBNull.Value);
            cmd.Parameters.AddWithValue("@CreateDate", DBNull.Value);
            cmd.Parameters.AddWithValue("@ModifyBy", ModifyBy);
            cmd.Parameters.AddWithValue("@ModifyDate", ModifyDate);
            cmd.Parameters.AddWithValue("@Month", Month);
            cmd.Parameters.AddWithValue("@Year", Year);
            cmd.Parameters.AddWithValue("@InvoiceType", InvoiceType);
            cmd.Parameters.AddWithValue("@CreditNoteNo", CreditNoteNo);
            cmd.Parameters.AddWithValue("@StatementType", "Update");
            int InsertCnt = cmd.ExecuteNonQuery();
            conn.Close();
            return InsertCnt > 0 ? true : false;
        }

        public bool Invoice_UpdateInvoice(string CCode, string JobNo, string BillNo, string NewInvoiceNo, string InvoiceType)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_InvoiceUpdate";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@JobNo", JobNo);
            cmd.Parameters.AddWithValue("@NewInvoiceNo", NewInvoiceNo);
            cmd.Parameters.AddWithValue("@BillNo", BillNo);
            cmd.Parameters.AddWithValue("@InvoiceType", InvoiceType);
            cmd.Parameters.AddWithValue("@CreditNoteNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "UpdateInvoiceNo");
            int InsertCnt = cmd.ExecuteNonQuery();
            conn.Close();
            return InsertCnt > 0 ? true : false;
        }

        public bool Invoice_UpdateCreditNoteNo(string CCode, string BillNo, string CreditNoteNo, string InvoiceType)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_InvoiceUpdate";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@JobNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@NewInvoiceNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@BillNo", BillNo);
            cmd.Parameters.AddWithValue("@InvoiceType", InvoiceType);
            cmd.Parameters.AddWithValue("@CreditNoteNo", CreditNoteNo);
            cmd.Parameters.AddWithValue("@StatementType", "UpdateCreditNoteNo");
            int InsertCnt = cmd.ExecuteNonQuery();
            conn.Close();
            return InsertCnt > 0 ? true : false;
        }

        public bool Invoice_UpdateEr(string CCode, string BillNo, string JobNo, string TotalNonTax, string TotalTax, string IGST, string SGST, string CGST, string Total)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_InvoiceChanges";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@Category", DBNull.Value);
            cmd.Parameters.AddWithValue("@JobNo", JobNo);
            cmd.Parameters.AddWithValue("@NewInvoiceNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@BillNo", BillNo);
            cmd.Parameters.AddWithValue("@BillDate", DBNull.Value);
            //cmd.Parameters.AddWithValue("@DueDate", DBNull.Value);
            cmd.Parameters.AddWithValue("@To1", DBNull.Value);
            cmd.Parameters.AddWithValue("@To2", DBNull.Value);
            cmd.Parameters.AddWithValue("@To3", DBNull.Value);
            cmd.Parameters.AddWithValue("@To4", DBNull.Value);
            cmd.Parameters.AddWithValue("@To5", DBNull.Value);
            cmd.Parameters.AddWithValue("@Guaranteel1", DBNull.Value);
            cmd.Parameters.AddWithValue("@Guaranteel2", DBNull.Value);
            cmd.Parameters.AddWithValue("@Guaranteel3", DBNull.Value);
            cmd.Parameters.AddWithValue("@Guaranteel4", DBNull.Value);
            cmd.Parameters.AddWithValue("@GSTNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@State", DBNull.Value);
            cmd.Parameters.AddWithValue("@StateCode", DBNull.Value);
            cmd.Parameters.AddWithValue("@PAN", DBNull.Value);
            cmd.Parameters.AddWithValue("@Shipper", DBNull.Value);
            cmd.Parameters.AddWithValue("@Consignee", DBNull.Value);
            cmd.Parameters.AddWithValue("@AWBNo", DBNull.Value);
            // cmd.Parameters.AddWithValue("@AWBDate", DBNull.Value);
            cmd.Parameters.AddWithValue("@HAWBNo", DBNull.Value);
            //cmd.Parameters.AddWithValue("@HAWBDate", DBNull.Value);
            cmd.Parameters.AddWithValue("@SBNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@SBDate", DBNull.Value);
            cmd.Parameters.AddWithValue("@Line", DBNull.Value);
            cmd.Parameters.AddWithValue("@IGM", DBNull.Value);
            cmd.Parameters.AddWithValue("@CBM", DBNull.Value);
            cmd.Parameters.AddWithValue("@Origin", DBNull.Value);
            cmd.Parameters.AddWithValue("@Dest", DBNull.Value);
            cmd.Parameters.AddWithValue("@Pieces", DBNull.Value);
            cmd.Parameters.AddWithValue("@Pkgs", DBNull.Value);
            cmd.Parameters.AddWithValue("@GrWeight", DBNull.Value);
            cmd.Parameters.AddWithValue("@ChWeight", DBNull.Value);
            cmd.Parameters.AddWithValue("@ShInvoice", DBNull.Value);
            cmd.Parameters.AddWithValue("@TotalNonTax", TotalNonTax);
            cmd.Parameters.AddWithValue("@TotalTax", TotalTax);
            cmd.Parameters.AddWithValue("@IGST", IGST);
            cmd.Parameters.AddWithValue("@CGST", CGST);
            cmd.Parameters.AddWithValue("@SGST", SGST);
            cmd.Parameters.AddWithValue("@Total", Total);
            cmd.Parameters.AddWithValue("@GrandTotal", Total);
            cmd.Parameters.AddWithValue("@Status", DBNull.Value);
            cmd.Parameters.AddWithValue("@CurrValue", DBNull.Value);
            cmd.Parameters.AddWithValue("@ExRate", DBNull.Value);
            cmd.Parameters.AddWithValue("@Payment", DBNull.Value);
            cmd.Parameters.AddWithValue("@Remarks", DBNull.Value);
            cmd.Parameters.AddWithValue("@SalesRep", DBNull.Value);
            cmd.Parameters.AddWithValue("@Advance", DBNull.Value);
            cmd.Parameters.AddWithValue("@Balance", DBNull.Value);
            cmd.Parameters.AddWithValue("@CreateBy", DBNull.Value);
            cmd.Parameters.AddWithValue("@CreateDate", DBNull.Value);
            cmd.Parameters.AddWithValue("@ModifyBy", DBNull.Value);
            cmd.Parameters.AddWithValue("@ModifyDate", DBNull.Value);
            cmd.Parameters.AddWithValue("@Month", DBNull.Value);
            cmd.Parameters.AddWithValue("@Year", DBNull.Value);
            cmd.Parameters.AddWithValue("@InvoiceType", DBNull.Value);
            cmd.Parameters.AddWithValue("@CreditNoteNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "UpdateInvoiceEr");
            int InsertCnt = cmd.ExecuteNonQuery();
            conn.Close();
            return InsertCnt > 0 ? true : false;
        }

        public bool Invoice_Delete(string CCode, string BillNo, string InvoiceType)//, string BillNo, string BillDate, string Month)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_InvoiceDetails";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@Category", DBNull.Value);
            cmd.Parameters.AddWithValue("@JobNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@BillNo", BillNo);
            cmd.Parameters.AddWithValue("@BillDate", DBNull.Value);
            cmd.Parameters.AddWithValue("@To1", DBNull.Value);
            cmd.Parameters.AddWithValue("@SalesRep", DBNull.Value);
            cmd.Parameters.AddWithValue("@Month", DBNull.Value);
            cmd.Parameters.AddWithValue("@CurrValue", DBNull.Value);
            cmd.Parameters.AddWithValue("@InvoiceType", InvoiceType);
            cmd.Parameters.AddWithValue("@CreditNoteNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@AWBNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "Delete");
            int InsertCnt = cmd.ExecuteNonQuery();
            conn.Close();
            return InsertCnt > 0 ? true : false;
        }

        public bool Invoice_UpdateBillNo(string CCode, int Id, string BillNo)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_InvoiceUpdateBill1";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@BillNo", BillNo);
            // cmd.Parameters.AddWithValue("@NewBillNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "UpdateBillNo");
            int InsertCnt = cmd.ExecuteNonQuery();
            conn.Close();
            return InsertCnt > 0 ? true : false;
        }

        public bool Invoice_UpdateBillNoParti(string CCode, string BillNo, string NewBillNo)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_InvoiceUpdateBill1";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", 0);
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@BillNo", BillNo);
            // cmd.Parameters.AddWithValue("@NewBillNo", NewBillNo);
            cmd.Parameters.AddWithValue("@StatementType", "UpdateBillNoParti");
            int InsertCnt = cmd.ExecuteNonQuery();
            conn.Close();
            return InsertCnt > 0 ? true : false;
        }

        // Client Contacts
        public SqlDataReader Client_Details(string CCode)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_ClientContacts";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", 0);
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@CompanyName", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "Select");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }

        public SqlDataReader Client_CompanyName_Details(string CCode, string CompanyName)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_ClientContacts";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", 0);
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@CompanyName", CompanyName);
            cmd.Parameters.AddWithValue("@StatementType", "SelectCompanyWise");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }

        public SqlDataReader Client_CompanyName_Category(string CCode)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_ClientContacts";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", 0);
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@CompanyName", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "SelectJobCategory");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }

        public bool Client_Details_New(string CCode, string CompanyName, string Name1, string Mobile1, string Email1, string Name2, string Mobile2, string Email2, string Phone, string Fax, string Address, string City, string State, string Country, string Pincode, string Active, string CreateBy, string CreateDate)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_ClientContactsChanges";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", 0);
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@CompanyName", CompanyName);
            cmd.Parameters.AddWithValue("@Name1", Name1);
            cmd.Parameters.AddWithValue("@Mobile1", Mobile1);
            cmd.Parameters.AddWithValue("@Email1", Email1);
            cmd.Parameters.AddWithValue("@Name2", Name2);
            cmd.Parameters.AddWithValue("@Mobile2", Mobile2);
            cmd.Parameters.AddWithValue("@Email2", Email2);
            cmd.Parameters.AddWithValue("@Phone", Phone);
            cmd.Parameters.AddWithValue("@Fax", Fax);
            cmd.Parameters.AddWithValue("@Address", Address);
            cmd.Parameters.AddWithValue("@City", City);
            cmd.Parameters.AddWithValue("@State", State);
            cmd.Parameters.AddWithValue("@Country", Country);
            cmd.Parameters.AddWithValue("@Pincode", Pincode);
            cmd.Parameters.AddWithValue("@Active", Active);
            cmd.Parameters.AddWithValue("@CreateBy", CreateBy);
            cmd.Parameters.AddWithValue("@CreateDate", CreateDate);
            cmd.Parameters.AddWithValue("@ModifyBy", DBNull.Value);
            cmd.Parameters.AddWithValue("@ModifyDate", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "Insert");
            int InsertCnt = cmd.ExecuteNonQuery();
            conn.Close();
            return InsertCnt > 0 ? true : false;
        }

        public bool Client_Details_Update(int Id, string CCode, string CompanyName, string Name1, string Mobile1, string Email1, string Name2, string Mobile2, string Email2, string Phone, string Fax, string Address, string City, string State, string Country, string Pincode, string Active, string ModifyBy, string ModifyDate)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_ClientContactsChanges";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@CompanyName", CompanyName);
            cmd.Parameters.AddWithValue("@Name1", Name1);
            cmd.Parameters.AddWithValue("@Mobile1", Mobile1);
            cmd.Parameters.AddWithValue("@Email1", Email1);
            cmd.Parameters.AddWithValue("@Name2", Name2);
            cmd.Parameters.AddWithValue("@Mobile2", Mobile2);
            cmd.Parameters.AddWithValue("@Email2", Email2);
            cmd.Parameters.AddWithValue("@Phone", Phone);
            cmd.Parameters.AddWithValue("@Fax", Fax);
            cmd.Parameters.AddWithValue("@Address", Address);
            cmd.Parameters.AddWithValue("@City", City);
            cmd.Parameters.AddWithValue("@State", State);
            cmd.Parameters.AddWithValue("@Country", Country);
            cmd.Parameters.AddWithValue("@Pincode", Pincode);
            cmd.Parameters.AddWithValue("@Active", Active);
            cmd.Parameters.AddWithValue("@CreateBy", DBNull.Value);
            cmd.Parameters.AddWithValue("@CreateDate", DBNull.Value);
            cmd.Parameters.AddWithValue("@ModifyBy", ModifyBy);
            cmd.Parameters.AddWithValue("@ModifyDate", ModifyDate);
            cmd.Parameters.AddWithValue("@StatementType", "Update");
            int InsertCnt = cmd.ExecuteNonQuery();
            conn.Close();
            return InsertCnt > 0 ? true : false;
        }

        public bool Client_Details_Delete(int Id, string CCode)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_ClientContacts";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@CompanyName", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "Delete");
            int InsertCnt = cmd.ExecuteNonQuery();
            conn.Close();
            return InsertCnt > 0 ? true : false;
        }

        // Invoice Particulars
        public SqlDataReader InvParticulars_Details(string CCode)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_InvoiceParticulars";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@Particulars", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "SelectALL");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }
        public SqlDataReader InvParticulars_PartiWise(string CCode, string Particulars)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_InvoiceParticulars";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@Particulars", Particulars);
            cmd.Parameters.AddWithValue("@StatementType", "SelectParticulars");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }
        public bool Particulars_New(string CCode, string Particulars, string Code, string HSN, string GST, string IGST, string CGST, string SGST, string Active)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_InvoiveParticularsChanges";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", 0);
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@Particulars", Particulars);
            cmd.Parameters.AddWithValue("@Code", Code);
            cmd.Parameters.AddWithValue("@HSN", HSN);
            cmd.Parameters.AddWithValue("@GST", GST);
            cmd.Parameters.AddWithValue("@IGST", IGST);
            cmd.Parameters.AddWithValue("@SGST", SGST);
            cmd.Parameters.AddWithValue("@CGST", CGST);
            cmd.Parameters.AddWithValue("@Active", Active);
            cmd.Parameters.AddWithValue("@StatementType", "Insert");
            int InsertCnt = cmd.ExecuteNonQuery();
            conn.Close();
            return InsertCnt > 0 ? true : false;
        }
        public bool Particulars_Update(int Id, string CCode, string Particulars, string Code, string HSN, string GST, string IGST, string CGST, string SGST, string Active)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_InvoiveParticularsChanges";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@Particulars", Particulars);
            cmd.Parameters.AddWithValue("@Code", Code);
            cmd.Parameters.AddWithValue("@HSN", HSN);
            cmd.Parameters.AddWithValue("@GST", GST);
            cmd.Parameters.AddWithValue("@IGST", IGST);
            cmd.Parameters.AddWithValue("@SGST", SGST);
            cmd.Parameters.AddWithValue("@CGST", CGST);
            cmd.Parameters.AddWithValue("@Active", Active);
            cmd.Parameters.AddWithValue("@StatementType", "Update");
            int InsertCnt = cmd.ExecuteNonQuery();
            conn.Close();
            return InsertCnt > 0 ? true : false;
        }

        public bool Particulars_Delete(int Id, string CCode)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_InvoiveParticularsChanges";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@Particulars", DBNull.Value);
            cmd.Parameters.AddWithValue("@Code", DBNull.Value);
            cmd.Parameters.AddWithValue("@HSN", DBNull.Value);
            cmd.Parameters.AddWithValue("@GST", DBNull.Value);
            cmd.Parameters.AddWithValue("@IGST", DBNull.Value);
            cmd.Parameters.AddWithValue("@SGST", DBNull.Value);
            cmd.Parameters.AddWithValue("@CGST", DBNull.Value);
            cmd.Parameters.AddWithValue("@Active", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "Delete");
            int InsertCnt = cmd.ExecuteNonQuery();
            conn.Close();
            return InsertCnt > 0 ? true : false;
        }

        // Invoice Payment Particulars

        public SqlDataReader InvoiceParticulars_Search(string CCode, string BillNo, string InvoiceType)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_PaymentInv";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@BillNo", BillNo);
            cmd.Parameters.AddWithValue("@InvoiceType", InvoiceType);
            cmd.Parameters.AddWithValue("@StatementType", "Select");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }
        public SqlDataReader InvoiceParticulars_Search1(string CCode, string BillNo, string InvoiceType)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_PaymentInv";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@BillNo", BillNo);
            cmd.Parameters.AddWithValue("@InvoiceType", InvoiceType);
            cmd.Parameters.AddWithValue("@StatementType", "Select_");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }

        public SqlDataReader InvoiceParticulars_SearchIGST(string CCode, string BillNo, string InvoiceType)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_PaymentInv";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@BillNo", BillNo);
            cmd.Parameters.AddWithValue("@InvoiceType", InvoiceType);
            cmd.Parameters.AddWithValue("@StatementType", "Select_IGST");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }

        public SqlDataReader InvoiceParticulars_SearchCGST(string CCode, string BillNo, string InvoiceType)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_PaymentInv";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@BillNo", BillNo);
            cmd.Parameters.AddWithValue("@InvoiceType", InvoiceType);
            cmd.Parameters.AddWithValue("@StatementType", "Select_CGST");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }

        public bool CustInvParticulars_New(string CCode, string BillNo, string HSN, string Particulars, string Additional, string Quantity, string Rate, string TaxAmt, string NonTaxAmt, string IGST, string IGSTValue, string SGST, string SGSTValue, string CGST, string CGSTValue, string Total, string InvoiceType)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_PaymentInvChanges";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", 0);
            cmd.Parameters.AddWithValue("@CCode", CCode);
            // cmd.Parameters.AddWithValue("@NewBillNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@BillNo", BillNo);
            cmd.Parameters.AddWithValue("@HSN", HSN);
            cmd.Parameters.AddWithValue("@Particulars", Particulars);
            cmd.Parameters.AddWithValue("@Additional", Additional);
            cmd.Parameters.AddWithValue("@Quantity", Quantity);
            cmd.Parameters.AddWithValue("@Rate", Rate);
            cmd.Parameters.AddWithValue("@TaxAmt", TaxAmt);
            cmd.Parameters.AddWithValue("@NonTaxAmt", NonTaxAmt);
            cmd.Parameters.AddWithValue("@IGST", IGST);
            cmd.Parameters.AddWithValue("@IGSTValue", IGSTValue);
            cmd.Parameters.AddWithValue("@SGST", SGST);
            cmd.Parameters.AddWithValue("@SGSTValue", SGSTValue);
            cmd.Parameters.AddWithValue("@CGST", CGST);
            cmd.Parameters.AddWithValue("@CGSTValue", CGSTValue);
            cmd.Parameters.AddWithValue("@Total", Total);
            cmd.Parameters.AddWithValue("@InvoiceType", InvoiceType);
            cmd.Parameters.AddWithValue("@StatementType", "Insert");
            int InsertCnt = cmd.ExecuteNonQuery();
            conn.Close();
            return InsertCnt > 0 ? true : false;
        }

        public bool CustInvParticulars_Update(int Id, string CCode, string BillNo, string HSN, string Particulars, string Additional, string Quantity, string Rate, string TaxAmt, string NonTaxAmt, string IGST, string IGSTValue, string SGST, string SGSTValue, string CGST, string CGSTValue, string Total, string InvoiceType)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_PaymentInvChanges";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@CCode", CCode);
            // cmd.Parameters.AddWithValue("@NewBillNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@BillNo", BillNo);
            cmd.Parameters.AddWithValue("@HSN", HSN);
            cmd.Parameters.AddWithValue("@Particulars", Particulars);
            cmd.Parameters.AddWithValue("@Additional", Additional);
            cmd.Parameters.AddWithValue("@Quantity", Quantity);
            cmd.Parameters.AddWithValue("@Rate", Rate);
            cmd.Parameters.AddWithValue("@TaxAmt", TaxAmt);
            cmd.Parameters.AddWithValue("@NonTaxAmt", NonTaxAmt);
            cmd.Parameters.AddWithValue("@IGST", IGST);
            cmd.Parameters.AddWithValue("@IGSTValue", IGSTValue);
            cmd.Parameters.AddWithValue("@SGST", SGST);
            cmd.Parameters.AddWithValue("@SGSTValue", SGSTValue);
            cmd.Parameters.AddWithValue("@CGST", CGST);
            cmd.Parameters.AddWithValue("@CGSTValue", CGSTValue);
            cmd.Parameters.AddWithValue("@Total", Total);
            cmd.Parameters.AddWithValue("@InvoiceType", InvoiceType);
            cmd.Parameters.AddWithValue("@StatementType", "Update");
            int InsertCnt = cmd.ExecuteNonQuery();
            conn.Close();
            return InsertCnt > 0 ? true : false;
        }

        public bool CustInvParticulars_UpdateInvoice(string CCode, string BillNo, string NewBillNo, string InvoiceType)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_PaymentInvChanges";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", 0);
            cmd.Parameters.AddWithValue("@CCode", CCode);
            // cmd.Parameters.AddWithValue("@NewBillNo", NewBillNo);
            cmd.Parameters.AddWithValue("@BillNo", BillNo);
            cmd.Parameters.AddWithValue("@HSN", DBNull.Value);
            cmd.Parameters.AddWithValue("@Particulars", DBNull.Value);
            cmd.Parameters.AddWithValue("@Additional", DBNull.Value);
            cmd.Parameters.AddWithValue("@Quantity", DBNull.Value);
            cmd.Parameters.AddWithValue("@Rate", DBNull.Value);
            cmd.Parameters.AddWithValue("@TaxAmt", DBNull.Value);
            cmd.Parameters.AddWithValue("@NonTaxAmt", DBNull.Value);
            cmd.Parameters.AddWithValue("@IGST", DBNull.Value);
            cmd.Parameters.AddWithValue("@IGSTValue", DBNull.Value);
            cmd.Parameters.AddWithValue("@SGST", DBNull.Value);
            cmd.Parameters.AddWithValue("@SGSTValue", DBNull.Value);
            cmd.Parameters.AddWithValue("@CGST", DBNull.Value);
            cmd.Parameters.AddWithValue("@CGSTValue", DBNull.Value);
            cmd.Parameters.AddWithValue("@Total", DBNull.Value);
            cmd.Parameters.AddWithValue("@InvoiceType", InvoiceType);
            cmd.Parameters.AddWithValue("@StatementType", "UpdateInvoiceNo");
            int InsertCnt = cmd.ExecuteNonQuery();
            conn.Close();
            return InsertCnt > 0 ? true : false;
        }

        public bool Invoice_UpdateInvoice1(string CCode, string BillNo, string NewInvoiceNo, string InvoiceType)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_InvoiceChanges";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@Category", DBNull.Value);
            cmd.Parameters.AddWithValue("@JobNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@NewInvoiceNo", NewInvoiceNo);
            cmd.Parameters.AddWithValue("@BillNo", BillNo);
            cmd.Parameters.AddWithValue("@BillDate", DBNull.Value);
            //cmd.Parameters.AddWithValue("@DueDate", DBNull.Value);
            cmd.Parameters.AddWithValue("@To1", DBNull.Value);
            cmd.Parameters.AddWithValue("@To2", DBNull.Value);
            cmd.Parameters.AddWithValue("@To3", DBNull.Value);
            cmd.Parameters.AddWithValue("@To4", DBNull.Value);
            cmd.Parameters.AddWithValue("@To5", DBNull.Value);
            cmd.Parameters.AddWithValue("@GSTNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@State", DBNull.Value);
            cmd.Parameters.AddWithValue("@StateCode", DBNull.Value);
            cmd.Parameters.AddWithValue("@Shipper", DBNull.Value);
            cmd.Parameters.AddWithValue("@Consignee", DBNull.Value);
            cmd.Parameters.AddWithValue("@AWBNo", DBNull.Value);
            // cmd.Parameters.AddWithValue("@AWBDate", DBNull.Value);
            cmd.Parameters.AddWithValue("@HAWBNo", DBNull.Value);
            //cmd.Parameters.AddWithValue("@HAWBDate", DBNull.Value);
            cmd.Parameters.AddWithValue("@SBNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@SBDate", DBNull.Value);
            cmd.Parameters.AddWithValue("@Line", DBNull.Value);
            cmd.Parameters.AddWithValue("@IGM", DBNull.Value);
            cmd.Parameters.AddWithValue("@CBM", DBNull.Value);
            cmd.Parameters.AddWithValue("@Origin", DBNull.Value);
            cmd.Parameters.AddWithValue("@Dest", DBNull.Value);
            cmd.Parameters.AddWithValue("@Pieces", DBNull.Value);
            cmd.Parameters.AddWithValue("@Pkgs", DBNull.Value);
            cmd.Parameters.AddWithValue("@GrWeight", DBNull.Value);
            cmd.Parameters.AddWithValue("@ChWeight", DBNull.Value);
            cmd.Parameters.AddWithValue("@TotalTax", DBNull.Value);
            cmd.Parameters.AddWithValue("@TotalNonTax", DBNull.Value);
            cmd.Parameters.AddWithValue("@IGST", DBNull.Value);
            cmd.Parameters.AddWithValue("@CGST", DBNull.Value);
            cmd.Parameters.AddWithValue("@SGST", DBNull.Value);
            cmd.Parameters.AddWithValue("@Total", DBNull.Value);
            cmd.Parameters.AddWithValue("@GrandTotal", DBNull.Value);
            cmd.Parameters.AddWithValue("@Status", DBNull.Value);
            cmd.Parameters.AddWithValue("@CurrValue", DBNull.Value);
            cmd.Parameters.AddWithValue("@Payment", DBNull.Value);
            cmd.Parameters.AddWithValue("@Remarks", DBNull.Value);
            cmd.Parameters.AddWithValue("@CreateBy", DBNull.Value);
            cmd.Parameters.AddWithValue("@CreateDate", DBNull.Value);
            cmd.Parameters.AddWithValue("@ModifyBy", DBNull.Value);
            cmd.Parameters.AddWithValue("@ModifyDate", DBNull.Value);
            cmd.Parameters.AddWithValue("@Month", DBNull.Value);
            cmd.Parameters.AddWithValue("@Year", DBNull.Value);
            cmd.Parameters.AddWithValue("@InvoiceType", InvoiceType);
            cmd.Parameters.AddWithValue("@CreditNoteNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "UpdateInvoiceNoParticulars");
            int InsertCnt = cmd.ExecuteNonQuery();
            conn.Close();
            return InsertCnt > 0 ? true : false;
        }

        public bool CustInvParticulars_Delete(int Id, string CCode, string InvoiceType)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_PaymentInvChanges";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@CCode", CCode);
            // cmd.Parameters.AddWithValue("@NewBillNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@BillNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@HSN", DBNull.Value);
            cmd.Parameters.AddWithValue("@Particulars", DBNull.Value);
            cmd.Parameters.AddWithValue("@Additional", DBNull.Value);
            cmd.Parameters.AddWithValue("@Quantity", DBNull.Value);
            cmd.Parameters.AddWithValue("@Rate", DBNull.Value);
            cmd.Parameters.AddWithValue("@TaxAmt", DBNull.Value);
            cmd.Parameters.AddWithValue("@NonTaxAmt", DBNull.Value);
            cmd.Parameters.AddWithValue("@IGST", DBNull.Value);
            cmd.Parameters.AddWithValue("@IGSTValue", DBNull.Value);
            cmd.Parameters.AddWithValue("@SGST", DBNull.Value);
            cmd.Parameters.AddWithValue("@SGSTValue", DBNull.Value);
            cmd.Parameters.AddWithValue("@CGST", DBNull.Value);
            cmd.Parameters.AddWithValue("@CGSTValue", DBNull.Value);
            cmd.Parameters.AddWithValue("@Total", DBNull.Value);
            cmd.Parameters.AddWithValue("@InvoiceType", InvoiceType);
            cmd.Parameters.AddWithValue("@StatementType", "Delete");
            int InsertCnt = cmd.ExecuteNonQuery();
            conn.Close();
            return InsertCnt > 0 ? true : false;
        }

        public bool InvParticulars_New1(string CCode, string BillNo, string Particulars, string Quantity, string Rate, string TaxAmt, string NonTaxAmt, string Total, string InvoiceType)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_PaymentInvChanges";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", 0);
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@BillNo", BillNo);
            cmd.Parameters.AddWithValue("@Particulars", Particulars);
            cmd.Parameters.AddWithValue("@Quantity", Quantity);
            cmd.Parameters.AddWithValue("@Rate", Rate);
            cmd.Parameters.AddWithValue("@TaxAmt", TaxAmt);
            cmd.Parameters.AddWithValue("@NonTaxAmt", NonTaxAmt);
            cmd.Parameters.AddWithValue("@Total", Total);
            cmd.Parameters.AddWithValue("@InvoiceType", InvoiceType);
            cmd.Parameters.AddWithValue("@StatementType", "Insert");
            int InsertCnt = cmd.ExecuteNonQuery();
            conn.Close();
            return InsertCnt > 0 ? true : false;
        }

        public bool InvParticulars_Update1(int Id, string CCode, string BillNo, string Particulars, string Quantity, string Rate, string TaxAmt, string NonTaxAmt, string Total, string InvoiceType)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_PaymentInvChanges";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@BillNo", BillNo);
            cmd.Parameters.AddWithValue("@Particulars", Particulars);
            cmd.Parameters.AddWithValue("@Quantity", Quantity);
            cmd.Parameters.AddWithValue("@Rate", Rate);
            cmd.Parameters.AddWithValue("@TaxAmt", TaxAmt);
            cmd.Parameters.AddWithValue("@NonTaxAmt", NonTaxAmt);
            cmd.Parameters.AddWithValue("@Total", Total);
            cmd.Parameters.AddWithValue("@InvoiceType", InvoiceType);
            cmd.Parameters.AddWithValue("@StatementType", "Update");
            int InsertCnt = cmd.ExecuteNonQuery();
            conn.Close();
            return InsertCnt > 0 ? true : false;
        }

        public bool InvParticulars_Delete(int Id, string CCode, string InvoiceType)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_PaymentInvChanges";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@BillNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@Particulars", DBNull.Value);
            cmd.Parameters.AddWithValue("@Quantity", DBNull.Value);
            cmd.Parameters.AddWithValue("@Rate", DBNull.Value);
            cmd.Parameters.AddWithValue("@TaxAmt", DBNull.Value);
            cmd.Parameters.AddWithValue("@NonTaxAmt", DBNull.Value);
            cmd.Parameters.AddWithValue("@Total", DBNull.Value);
            cmd.Parameters.AddWithValue("@InvoiceType", InvoiceType);
            cmd.Parameters.AddWithValue("@StatementType", "Delete");
            int InsertCnt = cmd.ExecuteNonQuery();
            conn.Close();
            return InsertCnt > 0 ? true : false;
        }

        public bool CustInvParticulars_DeleteAll(string CCode, string BillNo, string InvoiceType)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_PaymentInvChanges";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", 0);
            cmd.Parameters.AddWithValue("@CCode", CCode);
            // cmd.Parameters.AddWithValue("@NewBillNo", DBNull.Value);         
            cmd.Parameters.AddWithValue("@BillNo", BillNo);
            cmd.Parameters.AddWithValue("@HSN", DBNull.Value);
            cmd.Parameters.AddWithValue("@Particulars", DBNull.Value);
            cmd.Parameters.AddWithValue("@Additional", DBNull.Value);
            cmd.Parameters.AddWithValue("@Quantity", DBNull.Value);
            cmd.Parameters.AddWithValue("@Rate", DBNull.Value);
            cmd.Parameters.AddWithValue("@TaxAmt", DBNull.Value);
            cmd.Parameters.AddWithValue("@NonTaxAmt", DBNull.Value);
            cmd.Parameters.AddWithValue("@IGST", DBNull.Value);
            cmd.Parameters.AddWithValue("@IGSTValue", DBNull.Value);
            cmd.Parameters.AddWithValue("@SGST", DBNull.Value);
            cmd.Parameters.AddWithValue("@SGSTValue", DBNull.Value);
            cmd.Parameters.AddWithValue("@CGST", DBNull.Value);
            cmd.Parameters.AddWithValue("@CGSTValue", DBNull.Value);
            cmd.Parameters.AddWithValue("@Total", DBNull.Value);
            cmd.Parameters.AddWithValue("@InvoiceType", InvoiceType);
            cmd.Parameters.AddWithValue("@StatementType", "DeleteBill");
            int InsertCnt = cmd.ExecuteNonQuery();
            conn.Close();
            return InsertCnt > 0 ? true : false;
        }

        // particulars
        public SqlDataReader Particulars_Details(string CCode)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_InvoiceParticulars";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@Particulars", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "SelectALL");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }

        public SqlDataReader ParticularsWithHSNGST_Details(string CCode)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_InvoiceParticulars";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@Particulars", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "SelectALLHSN");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }

        // Shipper Invoice List
        public SqlDataReader ShipInv_Search_Top50(string CCode, string Category)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_ShipperInvoice";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", 0);
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@InvNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@Category", Category);
            cmd.Parameters.AddWithValue("@ICategory", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "SelectTop");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }

        public SqlDataReader ShipInv_InvoiceNoList(string CCode, string Category, string ICategory)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_ShipperInvoice";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", 0);
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@InvNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@Category", Category);
            cmd.Parameters.AddWithValue("@ICategory", ICategory);
            cmd.Parameters.AddWithValue("@StatementType", "SelectInvoiceNoList");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }

        public SqlDataReader ShipInv_Search(string CCode, string Category, string InvNo)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_ShipperInvoice";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", 0);
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@InvNo", InvNo);
            cmd.Parameters.AddWithValue("@Category", Category);
            cmd.Parameters.AddWithValue("@ICategory", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "SelectInvoiceWise");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }

        public bool ShipInv_New(string CCode, string ICategory, string Category, string InvNo, string InvDate, string Shipperl1, string Shipperl2, string Shipperl3, string Shipperl4, string Shipperl5, string Shipperl6, string Consigneel1, string Consigneel2, string Consigneel3, string Consigneel4, string Consigneel5, string Consigneel6, string ExportersRef, string BuyersDetails, string OtherRef, string Buyers, string PreCarriageBy, string Origin, string OriginCtry, string PortLoad, string PortDisch, string FinalDest, string DestCtry, string Vessel, string Terms, string NetWt, string GrossWt, string Dimn, string Total, string Currency, string AmountInWords, string Status, string Remarks, string Active, string CreateDate, string CreateBy, string Month, string Year)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_ShipperInvoiceChanges";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@ICategory", ICategory);
            cmd.Parameters.AddWithValue("@Category", Category);
            cmd.Parameters.AddWithValue("@InvNo", InvNo);
            cmd.Parameters.AddWithValue("@InvDate", InvDate);
            cmd.Parameters.AddWithValue("@Shipperl1", Shipperl1);
            cmd.Parameters.AddWithValue("@Shipperl2", Shipperl2);
            cmd.Parameters.AddWithValue("@Shipperl3", Shipperl3);
            cmd.Parameters.AddWithValue("@Shipperl4", Shipperl4);
            cmd.Parameters.AddWithValue("@Shipperl5", Shipperl5);
            cmd.Parameters.AddWithValue("@Shipperl6", Shipperl6);
            cmd.Parameters.AddWithValue("@Consigneel1", Consigneel1);
            cmd.Parameters.AddWithValue("@Consigneel2", Consigneel2);
            cmd.Parameters.AddWithValue("@Consigneel3", Consigneel3);
            cmd.Parameters.AddWithValue("@Consigneel4", Consigneel4);
            cmd.Parameters.AddWithValue("@Consigneel5", Consigneel5);
            cmd.Parameters.AddWithValue("@Consigneel6", Consigneel6);
            cmd.Parameters.AddWithValue("@ExportersRef", ExportersRef);
            cmd.Parameters.AddWithValue("@BuyersDetails", BuyersDetails);
            cmd.Parameters.AddWithValue("@OtherRef", OtherRef);
            cmd.Parameters.AddWithValue("@Buyers", Buyers);
            cmd.Parameters.AddWithValue("@PreCarriageBy", PreCarriageBy);
            cmd.Parameters.AddWithValue("@Origin", Origin);
            cmd.Parameters.AddWithValue("@OriginCtry", OriginCtry);
            cmd.Parameters.AddWithValue("@PortLoad", PortLoad);
            cmd.Parameters.AddWithValue("@PortDisch", PortDisch);
            cmd.Parameters.AddWithValue("@FinalDest", FinalDest);
            cmd.Parameters.AddWithValue("@DestCtry", DestCtry);
            cmd.Parameters.AddWithValue("@Vessel", Vessel);
            cmd.Parameters.AddWithValue("@Terms", Terms);
            cmd.Parameters.AddWithValue("@NetWt", NetWt);
            cmd.Parameters.AddWithValue("@GrossWt", GrossWt);
            cmd.Parameters.AddWithValue("@Dimn", Dimn);
            cmd.Parameters.AddWithValue("@Total", Total);
            cmd.Parameters.AddWithValue("@Currency", Currency);
            cmd.Parameters.AddWithValue("@AmountInWords", AmountInWords);
            cmd.Parameters.AddWithValue("@Status", Status);
            cmd.Parameters.AddWithValue("@Remarks", Remarks);
            cmd.Parameters.AddWithValue("@Active", Active);
            cmd.Parameters.AddWithValue("@CreateDate", CreateDate);
            cmd.Parameters.AddWithValue("@CreateBy", CreateBy);
            cmd.Parameters.AddWithValue("@ModifyDate", DBNull.Value);
            cmd.Parameters.AddWithValue("@ModifyBy", DBNull.Value);
            cmd.Parameters.AddWithValue("@Month", Month);
            cmd.Parameters.AddWithValue("@Year", Year);
            cmd.Parameters.AddWithValue("@StatementType", "Insert");
            int InsertCnt = cmd.ExecuteNonQuery();
            conn.Close();
            return InsertCnt > 0 ? true : false;
        }

        public bool ShipInv_Update(string CCode, string ICategory, string Category, string InvNo, string InvDate, string Shipperl1, string Shipperl2, string Shipperl3, string Shipperl4, string Shipperl5, string Shipperl6, string Consigneel1, string Consigneel2, string Consigneel3, string Consigneel4, string Consigneel5, string Consigneel6, string ExportersRef, string BuyersDetails, string OtherRef, string Buyers, string PreCarriageBy, string Origin, string OriginCtry, string PortLoad, string PortDisch, string FinalDest, string DestCtry, string Vessel, string Terms, string NetWt, string GrossWt, string Dimn, string Total, string Currency, string AmountInWords, string Status, string Remarks, string Active, string ModifyDate, string ModifyBy, string Month, string Year)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_ShipperInvoiceChanges";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@ICategory", ICategory);
            cmd.Parameters.AddWithValue("@Category", Category);
            cmd.Parameters.AddWithValue("@InvNo", InvNo);
            cmd.Parameters.AddWithValue("@InvDate", InvDate);
            cmd.Parameters.AddWithValue("@Shipperl1", Shipperl1);
            cmd.Parameters.AddWithValue("@Shipperl2", Shipperl2);
            cmd.Parameters.AddWithValue("@Shipperl3", Shipperl3);
            cmd.Parameters.AddWithValue("@Shipperl4", Shipperl4);
            cmd.Parameters.AddWithValue("@Shipperl5", Shipperl5);
            cmd.Parameters.AddWithValue("@Shipperl6", Shipperl6);
            cmd.Parameters.AddWithValue("@Consigneel1", Consigneel1);
            cmd.Parameters.AddWithValue("@Consigneel2", Consigneel2);
            cmd.Parameters.AddWithValue("@Consigneel3", Consigneel3);
            cmd.Parameters.AddWithValue("@Consigneel4", Consigneel4);
            cmd.Parameters.AddWithValue("@Consigneel5", Consigneel5);
            cmd.Parameters.AddWithValue("@Consigneel6", Consigneel6);
            cmd.Parameters.AddWithValue("@ExportersRef", ExportersRef);
            cmd.Parameters.AddWithValue("@BuyersDetails", BuyersDetails);
            cmd.Parameters.AddWithValue("@OtherRef", OtherRef);
            cmd.Parameters.AddWithValue("@Buyers", Buyers);
            cmd.Parameters.AddWithValue("@PreCarriageBy", PreCarriageBy);
            cmd.Parameters.AddWithValue("@Origin", Origin);
            cmd.Parameters.AddWithValue("@OriginCtry", OriginCtry);
            cmd.Parameters.AddWithValue("@PortLoad", PortLoad);
            cmd.Parameters.AddWithValue("@PortDisch", PortDisch);
            cmd.Parameters.AddWithValue("@FinalDest", FinalDest);
            cmd.Parameters.AddWithValue("@DestCtry", DestCtry);
            cmd.Parameters.AddWithValue("@Vessel", Vessel);
            cmd.Parameters.AddWithValue("@Terms", Terms);
            cmd.Parameters.AddWithValue("@NetWt", NetWt);
            cmd.Parameters.AddWithValue("@GrossWt", GrossWt);
            cmd.Parameters.AddWithValue("@Dimn", Dimn);
            cmd.Parameters.AddWithValue("@Total", Total);
            cmd.Parameters.AddWithValue("@Currency", Currency);
            cmd.Parameters.AddWithValue("@AmountInWords", AmountInWords);
            cmd.Parameters.AddWithValue("@Status", Status);
            cmd.Parameters.AddWithValue("@Remarks", Remarks);
            cmd.Parameters.AddWithValue("@Active", Active);
            cmd.Parameters.AddWithValue("@CreateDate", DBNull.Value);
            cmd.Parameters.AddWithValue("@CreateBy", DBNull.Value);
            cmd.Parameters.AddWithValue("@ModifyDate", ModifyDate);
            cmd.Parameters.AddWithValue("@ModifyBy", ModifyBy);
            cmd.Parameters.AddWithValue("@Month", Month);
            cmd.Parameters.AddWithValue("@Year", Year);
            cmd.Parameters.AddWithValue("@StatementType", "Update");
            int InsertCnt = cmd.ExecuteNonQuery();
            conn.Close();
            return InsertCnt > 0 ? true : false;
        }

        public bool ShipInv_Delete(string CCode, string Category, string InvNo)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_ShipperInvoice";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", 0);
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@ICategory", DBNull.Value);
            cmd.Parameters.AddWithValue("@Category", Category);
            cmd.Parameters.AddWithValue("@InvNo", InvNo);
            cmd.Parameters.AddWithValue("@StatementType", "DeleteInv");
            int InsertCnt = cmd.ExecuteNonQuery();
            conn.Close();
            return InsertCnt > 0 ? true : false;
        }

        public SqlDataReader ShipInvParticulars_Search(string CCode, string Category, string InvNo)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_ShipperInvoice";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", 0);
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@Category", Category);
            cmd.Parameters.AddWithValue("@InvNo", InvNo);
            cmd.Parameters.AddWithValue("@ICategory", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "SelectInvoicePartic");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }

        public bool ShipInvParticulars_New(string CCode, string Category, string InvNo, string Marks, string Packs, string Particulars, string Quantity, string Rate, string Amount)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_ShipperInvoiceParticularsChanges";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", 0);
            cmd.Parameters.AddWithValue("@Category", Category);
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@InvNo", InvNo);
            cmd.Parameters.AddWithValue("@Marks", Marks);
            cmd.Parameters.AddWithValue("@Packs", Packs);
            cmd.Parameters.AddWithValue("@Particulars", Particulars);
            cmd.Parameters.AddWithValue("@Quantity", Quantity);
            cmd.Parameters.AddWithValue("@Rate", Rate);
            cmd.Parameters.AddWithValue("@Amount", Amount);
            cmd.Parameters.AddWithValue("@NetWt", DBNull.Value);
            cmd.Parameters.AddWithValue("@GrossWt", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "Insert");
            int InsertCnt = cmd.ExecuteNonQuery();
            conn.Close();
            return InsertCnt > 0 ? true : false;
        }

        public bool ShipInvParticulars_Update(int Id, string CCode, string Category, string InvNo, string Marks, string Packs, string Particulars, string Quantity, string Rate, string Amount)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_ShipperInvoiceParticularsChanges";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@Category", Category);
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@InvNo", InvNo);
            cmd.Parameters.AddWithValue("@Marks", Marks);
            cmd.Parameters.AddWithValue("@Packs", Packs);
            cmd.Parameters.AddWithValue("@Particulars", Particulars);
            cmd.Parameters.AddWithValue("@Quantity", Quantity);
            cmd.Parameters.AddWithValue("@Rate", Rate);
            cmd.Parameters.AddWithValue("@Amount", Amount);
            cmd.Parameters.AddWithValue("@NetWt", DBNull.Value);
            cmd.Parameters.AddWithValue("@GrossWt", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "Update");
            int InsertCnt = cmd.ExecuteNonQuery();
            conn.Close();
            return InsertCnt > 0 ? true : false;
        }
        public bool ShipInvParticulars_Delete(int Id, string CCode, string Category, string InvNo)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_ShipperInvoice";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@ICategory", DBNull.Value);
            cmd.Parameters.AddWithValue("@Category", Category);
            cmd.Parameters.AddWithValue("@InvNo", InvNo);
            cmd.Parameters.AddWithValue("@StatementType", "DeletePartic");
            int InsertCnt = cmd.ExecuteNonQuery();
            conn.Close();
            return InsertCnt > 0 ? true : false;
        }

        public bool ShipInvParticulars_DeleteAll(string CCode, string Category, string InvNo)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_ShipperInvoice";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", 0);
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@ICategory", DBNull.Value);
            cmd.Parameters.AddWithValue("@Category", Category);
            cmd.Parameters.AddWithValue("@InvNo", InvNo);
            cmd.Parameters.AddWithValue("@StatementType", "DeleteAllPartic");
            int InsertCnt = cmd.ExecuteNonQuery();
            conn.Close();
            return InsertCnt > 0 ? true : false;
        }


        //Reports
        public SqlDataReader Report_2Dates_InvoiceAir(string CCode, string FromDate, string ToDate)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_Reports";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@FromDate", FromDate);
            cmd.Parameters.AddWithValue("@ToDate", ToDate);
            cmd.Parameters.AddWithValue("@StatementType", "JobReport_Air");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }

        public SqlDataReader Report_2Dates_AWB(string CCode, string FromDate, string ToDate)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_Reports";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@FromDate", FromDate);
            cmd.Parameters.AddWithValue("@ToDate", ToDate);
            cmd.Parameters.AddWithValue("@StatementType", "AWBJobReport_Air");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }

        public SqlDataReader Report_2Dates_AWBList(string CCode)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_Reports";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
            cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "AWBJobReport_AirList");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }

        public SqlDataReader Report_2Dates_InvoiceSea(string CCode, string FromDate, string ToDate)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_Reports";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@FromDate", FromDate);
            cmd.Parameters.AddWithValue("@ToDate", ToDate);
            cmd.Parameters.AddWithValue("@StatementType", "JobReport_Sea");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }

        // Airway Bill Stock List
        public SqlDataReader AWBStockList(string CCode, string Type, string Active)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_AWBStockList";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@Type", Type);
            cmd.Parameters.AddWithValue("@IATAAgent", DBNull.Value);
            cmd.Parameters.AddWithValue("@AName", DBNull.Value);
            cmd.Parameters.AddWithValue("@AWB", DBNull.Value);
            cmd.Parameters.AddWithValue("@Active", Active);
            cmd.Parameters.AddWithValue("@StatementType", "SelectALL");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }
        public SqlDataReader AWBStockList_IATA_AWB_Distinct(string CCode, string Type, string Active, string IATAAgent)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_AWBStockList";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@Type", Type);
            cmd.Parameters.AddWithValue("@IATAAgent", IATAAgent);
            cmd.Parameters.AddWithValue("@AName", DBNull.Value);
            cmd.Parameters.AddWithValue("@AWB", DBNull.Value);
            cmd.Parameters.AddWithValue("@Active", Active);
            cmd.Parameters.AddWithValue("@StatementType", "SelectIATA_AWB");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }
        public SqlDataReader AWBStockList_IATA_Distinct(string CCode, string Type, string Active)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_AWBStockList";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@Type", Type);
            cmd.Parameters.AddWithValue("@IATAAgent", DBNull.Value);
            cmd.Parameters.AddWithValue("@AName", DBNull.Value);
            cmd.Parameters.AddWithValue("@AWB", DBNull.Value);
            cmd.Parameters.AddWithValue("@Active", Active);
            cmd.Parameters.AddWithValue("@StatementType", "SelectIATA");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }
        public SqlDataReader AWBStockList_AWB(string CCode, string Type, string AWB)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_AWBStockList";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@Type", Type);
            cmd.Parameters.AddWithValue("@IATAAgent", DBNull.Value);
            cmd.Parameters.AddWithValue("@AName", DBNull.Value);
            cmd.Parameters.AddWithValue("@AWB", AWB);
            cmd.Parameters.AddWithValue("@Active", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "SelectAWB");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }

        public SqlDataReader AWBStockList_SingleAWB(string CCode, string AWB)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_AWBStockList";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@Type", DBNull.Value);
            cmd.Parameters.AddWithValue("@IATAAgent", DBNull.Value);
            cmd.Parameters.AddWithValue("@AName", DBNull.Value);
            cmd.Parameters.AddWithValue("@AWB", AWB);
            cmd.Parameters.AddWithValue("@Active", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "SelectSingleAWB");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }
        public bool AWBStockList_Insert(string CCode, string Type, string AName, string ACode, string Prefix, string AWBValue, string IATAAgent, string IATACode, string Active, string CreateBy, string CreateDate, string Place)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_AWBStockListChanges";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", 0);
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@Type", Type);
            cmd.Parameters.AddWithValue("@AName", AName);
            cmd.Parameters.AddWithValue("@ACode", ACode);
            cmd.Parameters.AddWithValue("@Prefix", Prefix);
            cmd.Parameters.AddWithValue("@AWB", AWBValue);
            cmd.Parameters.AddWithValue("@IATAAgent", IATAAgent);
            cmd.Parameters.AddWithValue("@IATACode", IATACode);
            cmd.Parameters.AddWithValue("@Active", Active);
            cmd.Parameters.AddWithValue("@CreateBy", CreateBy);
            cmd.Parameters.AddWithValue("@CreateDate", CreateDate);
            cmd.Parameters.AddWithValue("@ModifyBy", DBNull.Value);
            cmd.Parameters.AddWithValue("@ModifyDate", DBNull.Value);
            cmd.Parameters.AddWithValue("@Place", Place);
            cmd.Parameters.AddWithValue("@StatementType", "Insert");
            int InsertCnt = cmd.ExecuteNonQuery();
            conn.Close();
            return InsertCnt > 0 ? true : false;
        }

        public bool AWBStockList_Update(int Id, string CCode, string Type, string AName, string ACode, string Prefix, string AWBValue, string IATAAgent, string IATACode, string Active, string ModifyBy, string ModifyDate, string Place)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_AWBStockListChanges";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@Type", Type);
            cmd.Parameters.AddWithValue("@AName", AName);
            cmd.Parameters.AddWithValue("@ACode", ACode);
            cmd.Parameters.AddWithValue("@Prefix", Prefix);
            cmd.Parameters.AddWithValue("@AWB", AWBValue);
            cmd.Parameters.AddWithValue("@IATAAgent", IATAAgent);
            cmd.Parameters.AddWithValue("@IATACode", IATACode);
            cmd.Parameters.AddWithValue("@Active", Active);
            cmd.Parameters.AddWithValue("@CreateBy", DBNull.Value);
            cmd.Parameters.AddWithValue("@CreateDate", DBNull.Value);
            cmd.Parameters.AddWithValue("@ModifyBy", ModifyBy);
            cmd.Parameters.AddWithValue("@ModifyDate", ModifyDate);
            cmd.Parameters.AddWithValue("@Place", Place);
            cmd.Parameters.AddWithValue("@StatementType", "Update");
            int InsertCnt = cmd.ExecuteNonQuery();
            conn.Close();
            return InsertCnt > 0 ? true : false;
        }

        public bool AWBStockList_Delete(int Id, string CCode, string Type, string AWBValue)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_AWBStockListChanges";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@Type", Type);
            cmd.Parameters.AddWithValue("@AName", DBNull.Value);
            cmd.Parameters.AddWithValue("@ACode", DBNull.Value);
            cmd.Parameters.AddWithValue("@Prefix", DBNull.Value);
            cmd.Parameters.AddWithValue("@AWB", AWBValue);
            cmd.Parameters.AddWithValue("@IATAAgent", DBNull.Value);
            cmd.Parameters.AddWithValue("@IATACode", DBNull.Value);
            cmd.Parameters.AddWithValue("@Active", DBNull.Value);
            cmd.Parameters.AddWithValue("@CreateBy", DBNull.Value);
            cmd.Parameters.AddWithValue("@CreateDate", DBNull.Value);
            cmd.Parameters.AddWithValue("@ModifyBy", DBNull.Value);
            cmd.Parameters.AddWithValue("@ModifyDate", DBNull.Value);
            cmd.Parameters.AddWithValue("@Place", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "Delete");
            int InsertCnt = cmd.ExecuteNonQuery();
            conn.Close();
            return InsertCnt > 0 ? true : false;
        }

        public bool AWBStockList_Update_AWB(string CCode, string Type, string AWBValue, string Active, string ModifyBy, string ModifyDate)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_AWBStockListChanges";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", 0);
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@Type", Type);
            cmd.Parameters.AddWithValue("@AName", DBNull.Value);
            cmd.Parameters.AddWithValue("@ACode", DBNull.Value);
            cmd.Parameters.AddWithValue("@Prefix", DBNull.Value);
            cmd.Parameters.AddWithValue("@AWB", AWBValue);
            cmd.Parameters.AddWithValue("@IATAAgent", DBNull.Value);
            cmd.Parameters.AddWithValue("@IATACode", DBNull.Value);
            cmd.Parameters.AddWithValue("@Active", Active);
            cmd.Parameters.AddWithValue("@CreateBy", DBNull.Value);
            cmd.Parameters.AddWithValue("@CreateDate", DBNull.Value);
            cmd.Parameters.AddWithValue("@ModifyBy", ModifyBy);
            cmd.Parameters.AddWithValue("@ModifyDate", ModifyDate);
            cmd.Parameters.AddWithValue("@Place", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "Update-Stock");
            int InsertCnt = cmd.ExecuteNonQuery();
            conn.Close();
            return InsertCnt > 0 ? true : false;
        }

        // Job Expense 1
        public SqlDataReader Job_Expense_JobNoList1(string CCode, string Category)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_Expense1";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@Id", 0);
            cmd.Parameters.AddWithValue("@JobNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@Category", Category);
            cmd.Parameters.AddWithValue("@Expense", DBNull.Value);
            cmd.Parameters.AddWithValue("@Particulars", DBNull.Value);
            cmd.Parameters.AddWithValue("@Currency", DBNull.Value);
            cmd.Parameters.AddWithValue("@ExRate", DBNull.Value);
            cmd.Parameters.AddWithValue("@NonTax", DBNull.Value);
            cmd.Parameters.AddWithValue("@Tax", DBNull.Value);
            cmd.Parameters.AddWithValue("@Amount", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "SelectJobNoList");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }
        public SqlDataReader Job_Expense_JobNoList_Last(string CCode, string Category)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_Expense1";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@Id", 0);
            cmd.Parameters.AddWithValue("@JobNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@Category", Category);
            cmd.Parameters.AddWithValue("@Expense", DBNull.Value);
            cmd.Parameters.AddWithValue("@Particulars", DBNull.Value);
            cmd.Parameters.AddWithValue("@Currency", DBNull.Value);
            cmd.Parameters.AddWithValue("@ExRate", DBNull.Value);
            cmd.Parameters.AddWithValue("@NonTax", DBNull.Value);
            cmd.Parameters.AddWithValue("@Tax", DBNull.Value);
            cmd.Parameters.AddWithValue("@Amount", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "SelectJobNoList_Last");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }

        public SqlDataReader Job_Expense_JobNo1(string CCode, string JobNo)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_Expense1";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@Id", 0);
            cmd.Parameters.AddWithValue("@JobNo", JobNo);
            cmd.Parameters.AddWithValue("@Category", DBNull.Value);
            cmd.Parameters.AddWithValue("@Expense", DBNull.Value);
            cmd.Parameters.AddWithValue("@Particulars", DBNull.Value);
            cmd.Parameters.AddWithValue("@Currency", DBNull.Value);
            cmd.Parameters.AddWithValue("@ExRate", DBNull.Value);
            cmd.Parameters.AddWithValue("@NonTax", DBNull.Value);
            cmd.Parameters.AddWithValue("@Tax", DBNull.Value);
            cmd.Parameters.AddWithValue("@Amount", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "SelectJobNo");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }

        public SqlDataReader Job_ExpenseJobId(string CCode, int Id)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_Expense1";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@JobNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@Category", DBNull.Value);
            cmd.Parameters.AddWithValue("@Expense", DBNull.Value);
            cmd.Parameters.AddWithValue("@Particulars", DBNull.Value);
            cmd.Parameters.AddWithValue("@Currency", DBNull.Value);
            cmd.Parameters.AddWithValue("@ExRate", DBNull.Value);
            cmd.Parameters.AddWithValue("@NonTax", DBNull.Value);
            cmd.Parameters.AddWithValue("@Tax", DBNull.Value);
            cmd.Parameters.AddWithValue("@Amount", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "SelectJobId");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }

        public SqlDataReader Job_ExpenseBillAll1(string CCode, string Category)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_Expense1";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", 0);
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@JobNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@Category", Category);
            cmd.Parameters.AddWithValue("@Expense", DBNull.Value);
            cmd.Parameters.AddWithValue("@Particulars", DBNull.Value);
            cmd.Parameters.AddWithValue("@Currency", DBNull.Value);
            cmd.Parameters.AddWithValue("@ExRate", DBNull.Value);
            cmd.Parameters.AddWithValue("@NonTax", DBNull.Value);
            cmd.Parameters.AddWithValue("@Tax", DBNull.Value);
            cmd.Parameters.AddWithValue("@Amount", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "SelectTop");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }

        public bool Job_Expense_Insert1(string CCode, string JobNo, string Category, string ExpenseName, string Particulars, string Currency, string ExRate, string NonTax, string Tax, string Amount)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_Expense1";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@Id", 0);
            cmd.Parameters.AddWithValue("@JobNo", JobNo);
            cmd.Parameters.AddWithValue("@Category", Category);
            cmd.Parameters.AddWithValue("@Expense", ExpenseName);
            cmd.Parameters.AddWithValue("@Particulars", Particulars);
            cmd.Parameters.AddWithValue("@Currency", Currency);
            cmd.Parameters.AddWithValue("@ExRate", ExRate);
            cmd.Parameters.AddWithValue("@NonTax", NonTax);
            cmd.Parameters.AddWithValue("@Tax", Tax);
            cmd.Parameters.AddWithValue("@Amount", Amount);
            cmd.Parameters.AddWithValue("@StatementType", "Insert");
            int InsertCnt = cmd.ExecuteNonQuery();
            conn.Close();
            return InsertCnt > 0 ? true : false;
        }

        public bool Job_Expense_Update1(string CCode, int Id, string JobNo, string Category, string ExpenseName, string Particulars, string Currency, string ExRate, string NonTax, string Tax, string Amount)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_Expense1";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@JobNo", JobNo);
            cmd.Parameters.AddWithValue("@Category", Category);
            cmd.Parameters.AddWithValue("@Expense", ExpenseName);
            cmd.Parameters.AddWithValue("@Particulars", Particulars);
            cmd.Parameters.AddWithValue("@Currency", Currency);
            cmd.Parameters.AddWithValue("@ExRate", ExRate);
            cmd.Parameters.AddWithValue("@NonTax", NonTax);
            cmd.Parameters.AddWithValue("@Tax", Tax);
            cmd.Parameters.AddWithValue("@Amount", Amount);
            cmd.Parameters.AddWithValue("@StatementType", "Update");
            int InsertCnt = cmd.ExecuteNonQuery();
            conn.Close();
            return InsertCnt > 0 ? true : false;
        }

        public bool Job_Expense_Delete1(string CCode, int Id, string JobNo, string Category)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_Expense1";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@JobNo", JobNo);
            cmd.Parameters.AddWithValue("@Category", Category);
            cmd.Parameters.AddWithValue("@Expense", DBNull.Value);
            cmd.Parameters.AddWithValue("@Particulars", DBNull.Value);
            cmd.Parameters.AddWithValue("@Currency", DBNull.Value);
            cmd.Parameters.AddWithValue("@ExRate", DBNull.Value);
            cmd.Parameters.AddWithValue("@NonTax", DBNull.Value);
            cmd.Parameters.AddWithValue("@Tax", DBNull.Value);
            cmd.Parameters.AddWithValue("@Amount", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "Delete");
            int InsertCnt = cmd.ExecuteNonQuery();
            conn.Close();
            return InsertCnt > 0 ? true : false;
        }

        public bool Job_Expense_DeleteAll(string CCode, string JobNo, string Category)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_Expense1";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@Id", 0);
            cmd.Parameters.AddWithValue("@JobNo", JobNo);
            cmd.Parameters.AddWithValue("@Category", Category);
            cmd.Parameters.AddWithValue("@Expense", DBNull.Value);
            cmd.Parameters.AddWithValue("@Particulars", DBNull.Value);
            cmd.Parameters.AddWithValue("@Currency", DBNull.Value);
            cmd.Parameters.AddWithValue("@ExRate", DBNull.Value);
            cmd.Parameters.AddWithValue("@NonTax", DBNull.Value);
            cmd.Parameters.AddWithValue("@Tax", DBNull.Value);
            cmd.Parameters.AddWithValue("@Amount", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "DeleteAll");
            int InsertCnt = cmd.ExecuteNonQuery();
            conn.Close();
            return InsertCnt > 0 ? true : false;
        }

        //Expense Particulars
        public SqlDataReader ExpenseParticulars_SelectExpense(string CCode)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_ExpenseParticulars";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", 0);
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@Expense", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "SelectExpense");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }

        public SqlDataReader ExpenseParticulars_ExpenseVerify(string CCode, string Expense)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_ExpenseParticulars";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", 0);
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@Expense", Expense);
            cmd.Parameters.AddWithValue("@StatementType", "ExpenseVerify");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }

        public bool ExpenseParticulars_Insert(string CCode, string ExpenseName)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_ExpenseParticulars";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@Id", 0);
            cmd.Parameters.AddWithValue("@Expense", ExpenseName);
            cmd.Parameters.AddWithValue("@StatementType", "Insert");
            int InsertCnt = cmd.ExecuteNonQuery();
            conn.Close();
            return InsertCnt > 0 ? true : false;
        }

        public bool ExpenseParticulars_Update(int Id, string CCode, string ExpenseName)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_ExpenseParticulars";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@Expense", ExpenseName);
            cmd.Parameters.AddWithValue("@StatementType", "Update");
            int InsertCnt = cmd.ExecuteNonQuery();
            conn.Close();
            return InsertCnt > 0 ? true : false;
        }

        public bool ExpenseParticulars_Delete(int Id, string CCode, string ExpenseName)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_ExpenseParticulars";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@Expense", ExpenseName);
            cmd.Parameters.AddWithValue("@StatementType", "Delete");
            int InsertCnt = cmd.ExecuteNonQuery();
            conn.Close();
            return InsertCnt > 0 ? true : false;
        }

        // Job Expense
        public SqlDataReader Job_Expense(string CCode, string JobNo)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_Expense";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@JobNo", JobNo);
            cmd.Parameters.AddWithValue("@BillNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "SelectBill");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }

        public SqlDataReader Job_ExpenseAll(string CCode)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_Expense";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@JobNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@BillNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "SelectAll");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }

        public SqlDataReader Job_ExpenseBillAll(string CCode, string JobNo)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_Expense";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@JobNo", JobNo);
            cmd.Parameters.AddWithValue("@BillNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "SelectBillALL");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }

        public SqlDataReader Job_Expense_JobNo(string CCode)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_Expense";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@JobNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@BillNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "SelectAll_Exp");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }

        public SqlDataReader Expense_Invoice(string CCode)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_Expense";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@JobNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@BillNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "SelectExp");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }

        public bool Job_Expense_Insert(string CCode, string Category, string JobNo, string Shipper, string Date, string AWBNo, string CustExp, string ADCCrgs, string EDICrgs, string LoadingUnloading, string TerminalCrgs, string TransportCrgs, string AIRFreight, string FSC, string SC, string MCC, string XRAY, string AMS, string DGFee, string GSPCrgs, string AWB, string MISCCrgs1, string MISCCrgs2, string MISCCrgs3, string DO, string IHC, string TSA, string STUFFING, string Others, string CustExpAmt, string ADCCrgsAmt, string EDICrgsAmt, string LoadingUnloadingAmt, string TerminalCrgsAmt, string TransportCrgsAmt, string AIRFreightAmt, string FSCAmt, string SCAmt, string MCCAmt, string XRAYAmt, string AMSAmt, string DGFeeAmt, string GSPCrgsAmt, string AWBAmt, string MISCCrgs1Amt, string MISCCrgs2Amt, string MISCCrgs3Amt, string DOAmt, string IHCAmt, string TSAAmt, string STUFFINGAmt, string OthersAmt, string Total)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_ExpenseChanges";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@Category", Category);
            cmd.Parameters.AddWithValue("@JobNo", JobNo);
            cmd.Parameters.AddWithValue("@Shipper", Shipper);
            cmd.Parameters.AddWithValue("@Date", Date);
            cmd.Parameters.AddWithValue("@AWBNo", AWBNo);
            cmd.Parameters.AddWithValue("@CustExp", CustExp);
            cmd.Parameters.AddWithValue("@ADCCrgs", ADCCrgs);
            cmd.Parameters.AddWithValue("@EDICrgs", EDICrgs);
            cmd.Parameters.AddWithValue("@LoadingUnloading", LoadingUnloading);
            cmd.Parameters.AddWithValue("@TerminalCrgs", TerminalCrgs);
            cmd.Parameters.AddWithValue("@TransportCrgs", TransportCrgs);
            cmd.Parameters.AddWithValue("@AIRFreight", AIRFreight);
            cmd.Parameters.AddWithValue("@FSC", FSC);
            cmd.Parameters.AddWithValue("@SC", SC);
            cmd.Parameters.AddWithValue("@MCC", MCC);
            cmd.Parameters.AddWithValue("@XRAY", XRAY);
            cmd.Parameters.AddWithValue("@AMS", AMS);
            cmd.Parameters.AddWithValue("@DGFee", DGFee);
            cmd.Parameters.AddWithValue("@GSPCrgs", GSPCrgs);
            cmd.Parameters.AddWithValue("@AWB", AWB);
            cmd.Parameters.AddWithValue("@MISCCrgs1", MISCCrgs1);
            cmd.Parameters.AddWithValue("@MISCCrgs2", MISCCrgs2);
            cmd.Parameters.AddWithValue("@MISCCrgs3", MISCCrgs3);
            cmd.Parameters.AddWithValue("@DO", DO);
            cmd.Parameters.AddWithValue("@IHC", IHC);
            cmd.Parameters.AddWithValue("@TSA", TSA);
            cmd.Parameters.AddWithValue("@STUFFING", STUFFING);
            cmd.Parameters.AddWithValue("@Others", Others);
            cmd.Parameters.AddWithValue("@CustExpAmt", CustExpAmt);
            cmd.Parameters.AddWithValue("@ADCCrgsAmt", ADCCrgsAmt);
            cmd.Parameters.AddWithValue("@EDICrgsAmt", EDICrgsAmt);
            cmd.Parameters.AddWithValue("@LoadingUnloadingAmt", LoadingUnloadingAmt);
            cmd.Parameters.AddWithValue("@TerminalCrgsAmt", TerminalCrgsAmt);
            cmd.Parameters.AddWithValue("@TransportCrgsAmt", TransportCrgsAmt);
            cmd.Parameters.AddWithValue("@AIRFreightAmt", AIRFreightAmt);
            cmd.Parameters.AddWithValue("@FSCAmt", FSCAmt);
            cmd.Parameters.AddWithValue("@SCAmt", SCAmt);
            cmd.Parameters.AddWithValue("@MCCAmt", MCCAmt);
            cmd.Parameters.AddWithValue("@XRAYAmt", XRAYAmt);
            cmd.Parameters.AddWithValue("@AMSAmt", AMSAmt);
            cmd.Parameters.AddWithValue("@DGFeeAmt", DGFeeAmt);
            cmd.Parameters.AddWithValue("@GSPCrgsAmt", GSPCrgsAmt);
            cmd.Parameters.AddWithValue("@AWBAmt", AWBAmt);
            cmd.Parameters.AddWithValue("@MISCCrgs1Amt", MISCCrgs1Amt);
            cmd.Parameters.AddWithValue("@MISCCrgs2Amt", MISCCrgs2Amt);
            cmd.Parameters.AddWithValue("@MISCCrgs3Amt", MISCCrgs3Amt);
            cmd.Parameters.AddWithValue("@DOAmt", DOAmt);
            cmd.Parameters.AddWithValue("@IHCAmt", IHCAmt);
            cmd.Parameters.AddWithValue("@TSAAmt", TSAAmt);
            cmd.Parameters.AddWithValue("@STUFFINGAmt", STUFFINGAmt);
            cmd.Parameters.AddWithValue("@OthersAmt", OthersAmt);
            cmd.Parameters.AddWithValue("@Total", Total);
            cmd.Parameters.AddWithValue("@StatementType", "Insert");
            int InsertCnt = cmd.ExecuteNonQuery();
            conn.Close();
            return InsertCnt > 0 ? true : false;
        }

        public bool Job_Expense_Update(string CCode, string Category, string JobNo, string Shipper, string Date, string AWBNo, string CustExp, string ADCCrgs, string EDICrgs, string LoadingUnloading, string TerminalCrgs, string TransportCrgs, string AIRFreight, string FSC, string SC, string MCC, string XRAY, string AMS, string DGFee, string GSPCrgs, string AWB, string MISCCrgs1, string MISCCrgs2, string MISCCrgs3, string DO, string IHC, string TSA, string STUFFING, string Others, string CustExpAmt, string ADCCrgsAmt, string EDICrgsAmt, string LoadingUnloadingAmt, string TerminalCrgsAmt, string TransportCrgsAmt, string AIRFreightAmt, string FSCAmt, string SCAmt, string MCCAmt, string XRAYAmt, string AMSAmt, string DGFeeAmt, string GSPCrgsAmt, string AWBAmt, string MISCCrgs1Amt, string MISCCrgs2Amt, string MISCCrgs3Amt, string DOAmt, string IHCAmt, string TSAAmt, string STUFFINGAmt, string OthersAmt, string Total)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_ExpenseChanges";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@Category", Category);
            cmd.Parameters.AddWithValue("@JobNo", JobNo);
            cmd.Parameters.AddWithValue("@Shipper", Shipper);
            cmd.Parameters.AddWithValue("@Date", Date);
            cmd.Parameters.AddWithValue("@AWBNo", AWBNo);
            cmd.Parameters.AddWithValue("@CustExp", CustExp);
            cmd.Parameters.AddWithValue("@ADCCrgs", ADCCrgs);
            cmd.Parameters.AddWithValue("@EDICrgs", EDICrgs);
            cmd.Parameters.AddWithValue("@LoadingUnloading", LoadingUnloading);
            cmd.Parameters.AddWithValue("@TerminalCrgs", TerminalCrgs);
            cmd.Parameters.AddWithValue("@TransportCrgs", TransportCrgs);
            cmd.Parameters.AddWithValue("@AIRFreight", AIRFreight);
            cmd.Parameters.AddWithValue("@FSC", FSC);
            cmd.Parameters.AddWithValue("@SC", SC);
            cmd.Parameters.AddWithValue("@MCC", MCC);
            cmd.Parameters.AddWithValue("@XRAY", XRAY);
            cmd.Parameters.AddWithValue("@AMS", AMS);
            cmd.Parameters.AddWithValue("@DGFee", DGFee);
            cmd.Parameters.AddWithValue("@GSPCrgs", GSPCrgs);
            cmd.Parameters.AddWithValue("@AWB", AWB);
            cmd.Parameters.AddWithValue("@MISCCrgs1", MISCCrgs1);
            cmd.Parameters.AddWithValue("@MISCCrgs2", MISCCrgs2);
            cmd.Parameters.AddWithValue("@MISCCrgs3", MISCCrgs3);
            cmd.Parameters.AddWithValue("@DO", DO);
            cmd.Parameters.AddWithValue("@IHC", IHC);
            cmd.Parameters.AddWithValue("@TSA", TSA);
            cmd.Parameters.AddWithValue("@STUFFING", STUFFING);
            cmd.Parameters.AddWithValue("@Others", Others);
            cmd.Parameters.AddWithValue("@CustExpAmt", CustExpAmt);
            cmd.Parameters.AddWithValue("@ADCCrgsAmt", ADCCrgsAmt);
            cmd.Parameters.AddWithValue("@EDICrgsAmt", EDICrgsAmt);
            cmd.Parameters.AddWithValue("@LoadingUnloadingAmt", LoadingUnloadingAmt);
            cmd.Parameters.AddWithValue("@TerminalCrgsAmt", TerminalCrgsAmt);
            cmd.Parameters.AddWithValue("@TransportCrgsAmt", TransportCrgsAmt);
            cmd.Parameters.AddWithValue("@AIRFreightAmt", AIRFreightAmt);
            cmd.Parameters.AddWithValue("@FSCAmt", FSCAmt);
            cmd.Parameters.AddWithValue("@SCAmt", SCAmt);
            cmd.Parameters.AddWithValue("@MCCAmt", MCCAmt);
            cmd.Parameters.AddWithValue("@XRAYAmt", XRAYAmt);
            cmd.Parameters.AddWithValue("@AMSAmt", AMSAmt);
            cmd.Parameters.AddWithValue("@DGFeeAmt", DGFeeAmt);
            cmd.Parameters.AddWithValue("@GSPCrgsAmt", GSPCrgsAmt);
            cmd.Parameters.AddWithValue("@AWBAmt", AWBAmt);
            cmd.Parameters.AddWithValue("@MISCCrgs1Amt", MISCCrgs1Amt);
            cmd.Parameters.AddWithValue("@MISCCrgs2Amt", MISCCrgs2Amt);
            cmd.Parameters.AddWithValue("@MISCCrgs3Amt", MISCCrgs3Amt);
            cmd.Parameters.AddWithValue("@DOAmt", DOAmt);
            cmd.Parameters.AddWithValue("@IHCAmt", IHCAmt);
            cmd.Parameters.AddWithValue("@TSAAmt", TSAAmt);
            cmd.Parameters.AddWithValue("@STUFFINGAmt", STUFFINGAmt);
            cmd.Parameters.AddWithValue("@OthersAmt", OthersAmt);
            cmd.Parameters.AddWithValue("@Total", Total);
            cmd.Parameters.AddWithValue("@StatementType", "Update");
            int InsertCnt = cmd.ExecuteNonQuery();
            conn.Close();
            return InsertCnt > 0 ? true : false;
        }

        public bool Job_Expense_Delete(string CCode, string JobNo)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_Expense";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@JobNo", JobNo);
            cmd.Parameters.AddWithValue("@BillNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "Delete");
            int InsertCnt = cmd.ExecuteNonQuery();
            conn.Close();
            return InsertCnt > 0 ? true : false;
        }

        public SqlDataReader Airline_List()
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_Airline";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Code", DBNull.Value);
            cmd.Parameters.AddWithValue("@Prefix", DBNull.Value);
            cmd.Parameters.AddWithValue("@Name", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "SelectAirline");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }

        //State 
        public SqlDataReader State_All()
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_State";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@State", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "SelectAll");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }
        //Report 
        public SqlDataReader JobReport_AWB(string CCode)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_Report";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@Number", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "SelectAWB");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }
        public SqlDataReader JobReport_Expense(string CCode)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_Report";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@Number", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "SelectExpense");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }
        public SqlDataReader JobReport_Invoice(string CCode)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_Report";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@Number", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "SelectInvoice");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }

        public SqlDataReader JobReport_AWB_Search(string CCode, string Number)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_Report";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@Number", Number);
            cmd.Parameters.AddWithValue("@StatementType", "SelectAWBSearch");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }
        public SqlDataReader JobReport_Expense_Search(string CCode, string Number)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_Report";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@Number", Number);
            cmd.Parameters.AddWithValue("@StatementType", "SelectExpenseSearch");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }
        public SqlDataReader JobReport_Invoice_Search(string CCode, string Number)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_Report";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@Number", Number);
            cmd.Parameters.AddWithValue("@StatementType", "SelectInvoiceSearch");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }

        // Login History
        public SqlDataReader LoginHistory(string CCode)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_LoginHistory";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@Name", DBNull.Value);
            cmd.Parameters.AddWithValue("@Username", DBNull.Value);
            cmd.Parameters.AddWithValue("@Record", DBNull.Value);
            cmd.Parameters.AddWithValue("@Type", DBNull.Value);
            cmd.Parameters.AddWithValue("@Number", DBNull.Value);
            cmd.Parameters.AddWithValue("@Date", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "SelectAll");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }

        public SqlDataReader LoginHistory_Record(string CCode, string Record)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_LoginHistory";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@Name", DBNull.Value);
            cmd.Parameters.AddWithValue("@Username", DBNull.Value);
            cmd.Parameters.AddWithValue("@Record", Record);
            cmd.Parameters.AddWithValue("@Type", DBNull.Value);
            cmd.Parameters.AddWithValue("@Number", DBNull.Value);
            cmd.Parameters.AddWithValue("@Date", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "SelectRecord");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }

        public SqlDataReader LoginHistory_RecordLoad(string CCode)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_LoginHistory";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@Name", DBNull.Value);
            cmd.Parameters.AddWithValue("@Username", DBNull.Value);
            cmd.Parameters.AddWithValue("@Record", DBNull.Value);
            cmd.Parameters.AddWithValue("@Type", DBNull.Value);
            cmd.Parameters.AddWithValue("@Number", DBNull.Value);
            cmd.Parameters.AddWithValue("@Date", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "SelectRecordLoad");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }

        public bool LoginHistory_Insert(string CCode, string Name, string Username, string Record, string Type, string Number, string Date)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_LoginHistory";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@Name", Name);
            cmd.Parameters.AddWithValue("@Username", Username);
            cmd.Parameters.AddWithValue("@Record", Record);
            cmd.Parameters.AddWithValue("@Type", Type);
            cmd.Parameters.AddWithValue("@Number", Number);
            cmd.Parameters.AddWithValue("@Date", Date);
            cmd.Parameters.AddWithValue("@StatementType", "Insert");
            int InsertCnt = cmd.ExecuteNonQuery();
            conn.Close();
            return InsertCnt > 0 ? true : false;
        }

        // Certificate of origin
        public SqlDataReader CO_Details_TOP50(string CompCode)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_CertOrigin";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CompCode);
            cmd.Parameters.AddWithValue("@Id", 0);
            cmd.Parameters.AddWithValue("@StatementType", "SelectTOP50");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }
        public SqlDataReader CO_Details_Id(string CompCode, int Id)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_CertOrigin";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CompCode);
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@StatementType", "SelectId");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }

        public bool CO_Insert(string CCode, string JobNo, string Shipperl1, string Shipperl2, string Shipperl3, string Shipperl4, string Shipperl5, string Shipperl6, string Consigneel1, string Consigneel2, string Consigneel3, string Consigneel4, string Consigneel5, string Consigneel6, string PreCar, string Receipt, string Type, string POL, string POD, string FinalDest, string Date, string Container, string Pkgs, string Descr, string Quantity, string Amount)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_CertOriginChanges";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", 0);
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@JobNo", JobNo);
            cmd.Parameters.AddWithValue("@Shipperl1", Shipperl1);
            cmd.Parameters.AddWithValue("@Shipperl2", Shipperl2);
            cmd.Parameters.AddWithValue("@Shipperl3", Shipperl3);
            cmd.Parameters.AddWithValue("@Shipperl4", Shipperl4);
            cmd.Parameters.AddWithValue("@Shipperl5", Shipperl5);
            cmd.Parameters.AddWithValue("@Shipperl6", Shipperl6);
            cmd.Parameters.AddWithValue("@Consigneel1", Consigneel1);
            cmd.Parameters.AddWithValue("@Consigneel2", Consigneel2);
            cmd.Parameters.AddWithValue("@Consigneel3", Consigneel3);
            cmd.Parameters.AddWithValue("@Consigneel4", Consigneel4);
            cmd.Parameters.AddWithValue("@Consigneel5", Consigneel5);
            cmd.Parameters.AddWithValue("@Consigneel6", Consigneel6);
            cmd.Parameters.AddWithValue("@PreCar", PreCar);
            cmd.Parameters.AddWithValue("@Receipt", Receipt);
            cmd.Parameters.AddWithValue("@Type", Type);
            cmd.Parameters.AddWithValue("@POL", POL);
            cmd.Parameters.AddWithValue("@POD", POD);
            cmd.Parameters.AddWithValue("@FinalDest", FinalDest);
            cmd.Parameters.AddWithValue("@Date", Date);
            cmd.Parameters.AddWithValue("@Container", Container);
            cmd.Parameters.AddWithValue("@Pkgs", Pkgs);
            cmd.Parameters.AddWithValue("@Descr", Descr);
            cmd.Parameters.AddWithValue("@Quantity", Quantity);
            cmd.Parameters.AddWithValue("@Amount", Amount);
            cmd.Parameters.AddWithValue("@StatementType", "Insert");
            int InsertCnt = cmd.ExecuteNonQuery();
            conn.Close();
            return InsertCnt > 0 ? true : false;
        }

        public bool CO_Update(int Id, string CCode, string JobNo, string Shipperl1, string Shipperl2, string Shipperl3, string Shipperl4, string Shipperl5, string Shipperl6, string Consigneel1, string Consigneel2, string Consigneel3, string Consigneel4, string Consigneel5, string Consigneel6, string PreCar, string Receipt, string Type, string POL, string POD, string FinalDest, string Date, string Container, string Pkgs, string Descr, string Quantity, string Amount)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_CertOriginChanges";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@JobNo", JobNo);
            cmd.Parameters.AddWithValue("@Shipperl1", Shipperl1);
            cmd.Parameters.AddWithValue("@Shipperl2", Shipperl2);
            cmd.Parameters.AddWithValue("@Shipperl3", Shipperl3);
            cmd.Parameters.AddWithValue("@Shipperl4", Shipperl4);
            cmd.Parameters.AddWithValue("@Shipperl5", Shipperl5);
            cmd.Parameters.AddWithValue("@Shipperl6", Shipperl6);
            cmd.Parameters.AddWithValue("@Consigneel1", Consigneel1);
            cmd.Parameters.AddWithValue("@Consigneel2", Consigneel2);
            cmd.Parameters.AddWithValue("@Consigneel3", Consigneel3);
            cmd.Parameters.AddWithValue("@Consigneel4", Consigneel4);
            cmd.Parameters.AddWithValue("@Consigneel5", Consigneel5);
            cmd.Parameters.AddWithValue("@Consigneel6", Consigneel6);
            cmd.Parameters.AddWithValue("@PreCar", PreCar);
            cmd.Parameters.AddWithValue("@Receipt", Receipt);
            cmd.Parameters.AddWithValue("@Type", Type);
            cmd.Parameters.AddWithValue("@POL", POL);
            cmd.Parameters.AddWithValue("@POD", POD);
            cmd.Parameters.AddWithValue("@FinalDest", FinalDest);
            cmd.Parameters.AddWithValue("@Date", Date);
            cmd.Parameters.AddWithValue("@Container", Container);
            cmd.Parameters.AddWithValue("@Pkgs", Pkgs);
            cmd.Parameters.AddWithValue("@Descr", Descr);
            cmd.Parameters.AddWithValue("@Quantity", Quantity);
            cmd.Parameters.AddWithValue("@Amount", Amount);
            cmd.Parameters.AddWithValue("@StatementType", "Update");
            int InsertCnt = cmd.ExecuteNonQuery();
            conn.Close();
            return InsertCnt > 0 ? true : false;
        }

        public bool CO_Delete(int Id, string CCode)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_CertOriginChanges";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@Shipperl1", DBNull.Value);
            cmd.Parameters.AddWithValue("@Shipperl2", DBNull.Value);
            cmd.Parameters.AddWithValue("@Shipperl3", DBNull.Value);
            cmd.Parameters.AddWithValue("@Shipperl4", DBNull.Value);
            cmd.Parameters.AddWithValue("@Shipperl5", DBNull.Value);
            cmd.Parameters.AddWithValue("@Shipperl6", DBNull.Value);
            cmd.Parameters.AddWithValue("@Consigneel1", DBNull.Value);
            cmd.Parameters.AddWithValue("@Consigneel2", DBNull.Value);
            cmd.Parameters.AddWithValue("@Consigneel3", DBNull.Value);
            cmd.Parameters.AddWithValue("@Consigneel4", DBNull.Value);
            cmd.Parameters.AddWithValue("@Consigneel5", DBNull.Value);
            cmd.Parameters.AddWithValue("@Consigneel6", DBNull.Value);
            cmd.Parameters.AddWithValue("@PreCar", DBNull.Value);
            cmd.Parameters.AddWithValue("@Receipt", DBNull.Value);
            cmd.Parameters.AddWithValue("@Type", DBNull.Value);
            cmd.Parameters.AddWithValue("@POL", DBNull.Value);
            cmd.Parameters.AddWithValue("@POD", DBNull.Value);
            cmd.Parameters.AddWithValue("@FinalDest", DBNull.Value);
            cmd.Parameters.AddWithValue("@Date", DBNull.Value);
            cmd.Parameters.AddWithValue("@Container", DBNull.Value);
            cmd.Parameters.AddWithValue("@Pkgs", DBNull.Value);
            cmd.Parameters.AddWithValue("@Descr", DBNull.Value);
            cmd.Parameters.AddWithValue("@Quantity", DBNull.Value);
            cmd.Parameters.AddWithValue("@Amount", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "Delete");
            int InsertCnt = cmd.ExecuteNonQuery();
            conn.Close();
            return InsertCnt > 0 ? true : false;
        }

        // Cargo Manifest 
        public SqlDataReader CM_Details_TOP100(string CompCode, string AWB)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_CManifest";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CompCode);
            cmd.Parameters.AddWithValue("@AWB", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "SelectTop100");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }

        public SqlDataReader CM_Details(string CompCode, string AWB)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_CManifest";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CompCode);
            cmd.Parameters.AddWithValue("@AWB", AWB);
            cmd.Parameters.AddWithValue("@StatementType", "Select");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }

        public bool CM_Insert(string CCode, string JobNo, string AWB, string CMNo, string Date, string Line, string POL, string POD, string Shipperl1, string Shipperl2, string Shipperl3, string Shipperl4, string Shipperl5, string Shipperl6, string Consigneel1, string Consigneel2, string Consigneel3, string Consigneel4, string Consigneel5, string Consigneel6, string TotalPkgs, string TotalWeight, string CAR)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_CManifestChanges";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@JobNo", JobNo);
            cmd.Parameters.AddWithValue("@AWB", AWB);
            cmd.Parameters.AddWithValue("@CMNo", CMNo);
            cmd.Parameters.AddWithValue("@Date", Date);
            cmd.Parameters.AddWithValue("@Line", Line);
            cmd.Parameters.AddWithValue("@POL", POL);
            cmd.Parameters.AddWithValue("@POD", POD);
            cmd.Parameters.AddWithValue("@Shipperl1", Shipperl1);
            cmd.Parameters.AddWithValue("@Shipperl2", Shipperl2);
            cmd.Parameters.AddWithValue("@Shipperl3", Shipperl3);
            cmd.Parameters.AddWithValue("@Shipperl4", Shipperl4);
            cmd.Parameters.AddWithValue("@Shipperl5", Shipperl5);
            cmd.Parameters.AddWithValue("@Shipperl6", Shipperl6);
            cmd.Parameters.AddWithValue("@Consigneel1", Consigneel1);
            cmd.Parameters.AddWithValue("@Consigneel2", Consigneel2);
            cmd.Parameters.AddWithValue("@Consigneel3", Consigneel3);
            cmd.Parameters.AddWithValue("@Consigneel4", Consigneel4);
            cmd.Parameters.AddWithValue("@Consigneel5", Consigneel5);
            cmd.Parameters.AddWithValue("@Consigneel6", Consigneel6);
            cmd.Parameters.AddWithValue("@TotalPkgs", TotalPkgs);
            cmd.Parameters.AddWithValue("@TotalWeight", TotalWeight);
            cmd.Parameters.AddWithValue("@CAR", CAR);
            cmd.Parameters.AddWithValue("@StatementType", "Insert");
            int InsertCnt = cmd.ExecuteNonQuery();
            conn.Close();
            return InsertCnt > 0 ? true : false;
        }

        public bool CM_Update(string CCode, string JobNo, string AWB, string CMNo, string Date, string Line, string POL, string POD, string Shipperl1, string Shipperl2, string Shipperl3, string Shipperl4, string Shipperl5, string Shipperl6, string Consigneel1, string Consigneel2, string Consigneel3, string Consigneel4, string Consigneel5, string Consigneel6, string TotalPkgs, string TotalWeight, string CAR)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_CManifestChanges";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@JobNo", JobNo);
            cmd.Parameters.AddWithValue("@AWB", AWB);
            cmd.Parameters.AddWithValue("@CMNo", CMNo);
            cmd.Parameters.AddWithValue("@Date", Date);
            cmd.Parameters.AddWithValue("@Line", Line);
            cmd.Parameters.AddWithValue("@POL", POL);
            cmd.Parameters.AddWithValue("@POD", POD);
            cmd.Parameters.AddWithValue("@Shipperl1", Shipperl1);
            cmd.Parameters.AddWithValue("@Shipperl2", Shipperl2);
            cmd.Parameters.AddWithValue("@Shipperl3", Shipperl3);
            cmd.Parameters.AddWithValue("@Shipperl4", Shipperl4);
            cmd.Parameters.AddWithValue("@Shipperl5", Shipperl5);
            cmd.Parameters.AddWithValue("@Shipperl6", Shipperl6);
            cmd.Parameters.AddWithValue("@Consigneel1", Consigneel1);
            cmd.Parameters.AddWithValue("@Consigneel2", Consigneel2);
            cmd.Parameters.AddWithValue("@Consigneel3", Consigneel3);
            cmd.Parameters.AddWithValue("@Consigneel4", Consigneel4);
            cmd.Parameters.AddWithValue("@Consigneel5", Consigneel5);
            cmd.Parameters.AddWithValue("@Consigneel6", Consigneel6);
            cmd.Parameters.AddWithValue("@TotalPkgs", TotalPkgs);
            cmd.Parameters.AddWithValue("@TotalWeight", TotalWeight);
            cmd.Parameters.AddWithValue("@CAR", CAR);
            cmd.Parameters.AddWithValue("@StatementType", "Update");
            int InsertCnt = cmd.ExecuteNonQuery();
            conn.Close();
            return InsertCnt > 0 ? true : false;
        }

        public bool CM_Delete(string CCode, string AWB)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_CManifestChanges";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@JobNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@AWB", AWB);
            cmd.Parameters.AddWithValue("@CMNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@Date", DBNull.Value);
            cmd.Parameters.AddWithValue("@Line", DBNull.Value);
            cmd.Parameters.AddWithValue("@POL", DBNull.Value);
            cmd.Parameters.AddWithValue("@POD", DBNull.Value);
            cmd.Parameters.AddWithValue("@Shipperl1", DBNull.Value);
            cmd.Parameters.AddWithValue("@Shipperl2", DBNull.Value);
            cmd.Parameters.AddWithValue("@Shipperl3", DBNull.Value);
            cmd.Parameters.AddWithValue("@Shipperl4", DBNull.Value);
            cmd.Parameters.AddWithValue("@Shipperl5", DBNull.Value);
            cmd.Parameters.AddWithValue("@Shipperl6", DBNull.Value);
            cmd.Parameters.AddWithValue("@Consigneel1", DBNull.Value);
            cmd.Parameters.AddWithValue("@Consigneel2", DBNull.Value);
            cmd.Parameters.AddWithValue("@Consigneel3", DBNull.Value);
            cmd.Parameters.AddWithValue("@Consigneel4", DBNull.Value);
            cmd.Parameters.AddWithValue("@Consigneel5", DBNull.Value);
            cmd.Parameters.AddWithValue("@Consigneel6", DBNull.Value);
            cmd.Parameters.AddWithValue("@TotalPkgs", DBNull.Value);
            cmd.Parameters.AddWithValue("@TotalWeight", DBNull.Value);
            cmd.Parameters.AddWithValue("@CAR", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "Delete");
            int InsertCnt = cmd.ExecuteNonQuery();
            conn.Close();
            return InsertCnt > 0 ? true : false;
        }

        // Cargo Manifest Particulars
        public SqlDataReader CMP_Details(string CompCode, string AWB)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_CManifestParticulars";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CompCode);
            cmd.Parameters.AddWithValue("@AWB", AWB);
            cmd.Parameters.AddWithValue("@StatementType", "Select");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }

        public bool CMP_Insert(string CCode, string AWB, string Pos, string HAWB, string Pkgs, string Weight, string Goods, string Dest, string Freight, string Shipperl1, string Shipperl2, string Shipperl3, string Shipperl4, string Shipperl5, string Shipperl6, string Consigneel1, string Consigneel2, string Consigneel3, string Consigneel4, string Consigneel5, string Consigneel6)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_CManifestChanges";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@AWB", AWB);
            cmd.Parameters.AddWithValue("@Pos", Pos);
            cmd.Parameters.AddWithValue("@HAWB", HAWB);
            cmd.Parameters.AddWithValue("@Pkgs", Pkgs);
            cmd.Parameters.AddWithValue("@Weight", Weight);
            cmd.Parameters.AddWithValue("@Goods", Goods);
            cmd.Parameters.AddWithValue("@Dest", Dest);
            cmd.Parameters.AddWithValue("@Freight", Freight);
            cmd.Parameters.AddWithValue("@Shipperl1", Shipperl1);
            cmd.Parameters.AddWithValue("@Shipperl2", Shipperl2);
            cmd.Parameters.AddWithValue("@Shipperl3", Shipperl3);
            cmd.Parameters.AddWithValue("@Shipperl4", Shipperl4);
            cmd.Parameters.AddWithValue("@Shipperl5", Shipperl5);
            cmd.Parameters.AddWithValue("@Shipperl6", Shipperl6);
            cmd.Parameters.AddWithValue("@Consigneel1", Consigneel1);
            cmd.Parameters.AddWithValue("@Consigneel2", Consigneel2);
            cmd.Parameters.AddWithValue("@Consigneel3", Consigneel3);
            cmd.Parameters.AddWithValue("@Consigneel4", Consigneel4);
            cmd.Parameters.AddWithValue("@Consigneel5", Consigneel5);
            cmd.Parameters.AddWithValue("@Consigneel6", Consigneel6);
            cmd.Parameters.AddWithValue("@StatementType", "Insert");
            int InsertCnt = cmd.ExecuteNonQuery();
            conn.Close();
            return InsertCnt > 0 ? true : false;
        }

        public bool CMP_Update(string CCode, string AWB, string Pos, string HAWB, string Pkgs, string Weight, string Goods, string Dest, string Freight, string Shipperl1, string Shipperl2, string Shipperl3, string Shipperl4, string Shipperl5, string Shipperl6, string Consigneel1, string Consigneel2, string Consigneel3, string Consigneel4, string Consigneel5, string Consigneel6)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_CManifestChanges";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@AWB", AWB);
            cmd.Parameters.AddWithValue("@Pos", Pos);
            cmd.Parameters.AddWithValue("@HAWB", HAWB);
            cmd.Parameters.AddWithValue("@Pkgs", Pkgs);
            cmd.Parameters.AddWithValue("@Weight", Weight);
            cmd.Parameters.AddWithValue("@Goods", Goods);
            cmd.Parameters.AddWithValue("@Dest", Dest);
            cmd.Parameters.AddWithValue("@Freight", Freight);
            cmd.Parameters.AddWithValue("@Shipperl1", Shipperl1);
            cmd.Parameters.AddWithValue("@Shipperl2", Shipperl2);
            cmd.Parameters.AddWithValue("@Shipperl3", Shipperl3);
            cmd.Parameters.AddWithValue("@Shipperl4", Shipperl4);
            cmd.Parameters.AddWithValue("@Shipperl5", Shipperl5);
            cmd.Parameters.AddWithValue("@Shipperl6", Shipperl6);
            cmd.Parameters.AddWithValue("@Consigneel1", Consigneel1);
            cmd.Parameters.AddWithValue("@Consigneel2", Consigneel2);
            cmd.Parameters.AddWithValue("@Consigneel3", Consigneel3);
            cmd.Parameters.AddWithValue("@Consigneel4", Consigneel4);
            cmd.Parameters.AddWithValue("@Consigneel5", Consigneel5);
            cmd.Parameters.AddWithValue("@Consigneel6", Consigneel6);
            cmd.Parameters.AddWithValue("@StatementType", "Update");
            int InsertCnt = cmd.ExecuteNonQuery();
            conn.Close();
            return InsertCnt > 0 ? true : false;
        }

        public bool CMP_Delete(string CCode, string AWB)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_CManifestChanges";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@AWB", AWB);
            cmd.Parameters.AddWithValue("@Pos", DBNull.Value);
            cmd.Parameters.AddWithValue("@HAWB", DBNull.Value);
            cmd.Parameters.AddWithValue("@Pkgs", DBNull.Value);
            cmd.Parameters.AddWithValue("@Weight", DBNull.Value);
            cmd.Parameters.AddWithValue("@Goods", DBNull.Value);
            cmd.Parameters.AddWithValue("@Dest", DBNull.Value);
            cmd.Parameters.AddWithValue("@Freight", DBNull.Value);
            cmd.Parameters.AddWithValue("@Shipperl1", DBNull.Value);
            cmd.Parameters.AddWithValue("@Shipperl2", DBNull.Value);
            cmd.Parameters.AddWithValue("@Shipperl3", DBNull.Value);
            cmd.Parameters.AddWithValue("@Shipperl4", DBNull.Value);
            cmd.Parameters.AddWithValue("@Shipperl5", DBNull.Value);
            cmd.Parameters.AddWithValue("@Shipperl6", DBNull.Value);
            cmd.Parameters.AddWithValue("@Consigneel1", DBNull.Value);
            cmd.Parameters.AddWithValue("@Consigneel2", DBNull.Value);
            cmd.Parameters.AddWithValue("@Consigneel3", DBNull.Value);
            cmd.Parameters.AddWithValue("@Consigneel4", DBNull.Value);
            cmd.Parameters.AddWithValue("@Consigneel5", DBNull.Value);
            cmd.Parameters.AddWithValue("@Consigneel6", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "Delete");
            int InsertCnt = cmd.ExecuteNonQuery();
            conn.Close();
            return InsertCnt > 0 ? true : false;
        }

        // Generate Job
        public SqlDataReader Gen_JobAll(string CCode)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_GenerateJob";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@JobNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@Type", DBNull.Value);
            cmd.Parameters.AddWithValue("@Active", DBNull.Value);
            cmd.Parameters.AddWithValue("@GBy", DBNull.Value);
            cmd.Parameters.AddWithValue("@JobStatus", DBNull.Value);
            cmd.Parameters.AddWithValue("@Month", DBNull.Value); //
            cmd.Parameters.AddWithValue("@StatementType", "SelectALL");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }
        public SqlDataReader Gen_Job(string CCode)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_GenerateJob";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@JobNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@Type", DBNull.Value);
            cmd.Parameters.AddWithValue("@Active", DBNull.Value);
            cmd.Parameters.AddWithValue("@GBy", DBNull.Value);
            cmd.Parameters.AddWithValue("@JobStatus", DBNull.Value);
            cmd.Parameters.AddWithValue("@Month", DBNull.Value); //
            cmd.Parameters.AddWithValue("@StatementType", "Select");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }
        public SqlDataReader Gen_JobNo(string CCode, string JobNo)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_GenerateJob";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@JobNo", JobNo);
            cmd.Parameters.AddWithValue("@Type", DBNull.Value);
            cmd.Parameters.AddWithValue("@Active", DBNull.Value);
            cmd.Parameters.AddWithValue("@GBy", DBNull.Value);
            cmd.Parameters.AddWithValue("@JobStatus", DBNull.Value);
            cmd.Parameters.AddWithValue("@Month", DBNull.Value); //
            cmd.Parameters.AddWithValue("@StatementType", "SelectJobNoDetails");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }
        public SqlDataReader Gen_JobNoList(string CCode)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_GenerateJob";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@JobNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@Type", DBNull.Value);
            cmd.Parameters.AddWithValue("@Active", DBNull.Value);
            cmd.Parameters.AddWithValue("@GBy", DBNull.Value);
            cmd.Parameters.AddWithValue("@JobStatus", DBNull.Value);
            cmd.Parameters.AddWithValue("@Month", DBNull.Value); //
            cmd.Parameters.AddWithValue("@StatementType", "SelectJobNo");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }

        public SqlDataReader Gen_JobNoListType(string CCode, string Type)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_GenerateJob";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@JobNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@Type", Type);
            cmd.Parameters.AddWithValue("@Active", DBNull.Value);
            cmd.Parameters.AddWithValue("@GBy", DBNull.Value);
            cmd.Parameters.AddWithValue("@JobStatus", DBNull.Value);
            cmd.Parameters.AddWithValue("@Month", DBNull.Value); //
            cmd.Parameters.AddWithValue("@StatementType", "SelectJobNoType");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }

        public SqlDataReader Gen_Job_Last(string CCode, string Type)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_GenerateJob";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@JobNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@Type", Type);
            cmd.Parameters.AddWithValue("@Active", DBNull.Value);
            cmd.Parameters.AddWithValue("@GBy", DBNull.Value);
            cmd.Parameters.AddWithValue("@JobStatus", DBNull.Value);
            cmd.Parameters.AddWithValue("@Month", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "SelectLast");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }

        public SqlDataReader Expense_JobNonExpense(string CCode, string Type)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_GenerateJob";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@JobNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@Type", Type);
            cmd.Parameters.AddWithValue("@Active", DBNull.Value);
            cmd.Parameters.AddWithValue("@GBy", DBNull.Value);
            cmd.Parameters.AddWithValue("@JobStatus", DBNull.Value);
            cmd.Parameters.AddWithValue("@Month", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "SelectExp");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }

        public bool Gen_Job_Insert(string CCode, string JobNo, string Type, string Active, string GBy, string JobStatus, string Month)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_GenerateJob";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@JobNo", JobNo);
            cmd.Parameters.AddWithValue("@Type", Type);
            cmd.Parameters.AddWithValue("@Active", Active);
            cmd.Parameters.AddWithValue("@GBy", GBy);
            cmd.Parameters.AddWithValue("@JobStatus", JobStatus);
            cmd.Parameters.AddWithValue("@Month", Month);
            cmd.Parameters.AddWithValue("@StatementType", "Insert");
            int InsertCnt = cmd.ExecuteNonQuery();
            conn.Close();
            return InsertCnt > 0 ? true : false;
        }

        public bool Gen_Job_Delete(string CCode, string JobNo)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_GenerateJob";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@JobNo", JobNo);
            cmd.Parameters.AddWithValue("@Type", DBNull.Value);
            cmd.Parameters.AddWithValue("@Active", DBNull.Value);
            cmd.Parameters.AddWithValue("@GBy", DBNull.Value);
            cmd.Parameters.AddWithValue("@JobStatus", DBNull.Value);
            cmd.Parameters.AddWithValue("@Month", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "Delete");
            int InsertCnt = cmd.ExecuteNonQuery();
            conn.Close();
            return InsertCnt > 0 ? true : false;
        }

        // Payment Status
        public SqlDataReader Payment_StatusInvNoAll(string CCode, string BillNo)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_PaymentDetails";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@Id", 0);
            cmd.Parameters.AddWithValue("@BillNo", BillNo);
            cmd.Parameters.AddWithValue("@StatementType", "SelectBill");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }
        public SqlDataReader Payment_StatusInvNo(string CCode, string BillNo)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_PaymentDetails";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@Id", 0);
            cmd.Parameters.AddWithValue("@BillNo", BillNo);
            cmd.Parameters.AddWithValue("@StatementType", "SelectBill2");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }

        public SqlDataReader Payment_StatusId(string CCode, string Id)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_PaymentDetails";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@BillNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "SelectId");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }

        public bool Payment_Status_Insert(string CCode, string BillNo, string Status, string Currency, string CurrValue, string PaymentMode, string Date, string Bank, string Reference, string CollectedBy, string PaymentDetails, string Remarks, string Advance, string OthDeduct, string Received, string Balance)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_PaymentDetailsChanges";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", 0);
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@BillNo", BillNo);
            cmd.Parameters.AddWithValue("@Status", Status);
            cmd.Parameters.AddWithValue("@Currency", Currency);
            cmd.Parameters.AddWithValue("@CurrValue", CurrValue);
            cmd.Parameters.AddWithValue("@PaymentMode", PaymentMode);
            cmd.Parameters.AddWithValue("@Date", Date);
            cmd.Parameters.AddWithValue("@Bank", Bank);
            cmd.Parameters.AddWithValue("@Reference", Reference);
            cmd.Parameters.AddWithValue("@CollectedBy", CollectedBy);
            cmd.Parameters.AddWithValue("@PaymentDetails", PaymentDetails);
            cmd.Parameters.AddWithValue("@Remarks", Remarks);
            cmd.Parameters.AddWithValue("@Advance", Advance);
            cmd.Parameters.AddWithValue("@OthDeduct", OthDeduct);
            cmd.Parameters.AddWithValue("@Received", Received);
            cmd.Parameters.AddWithValue("@Balance", Balance);
            cmd.Parameters.AddWithValue("@StatementType", "Insert");
            int InsertCnt = cmd.ExecuteNonQuery();
            conn.Close();
            return InsertCnt > 0 ? true : false;
        }

        public bool Payment_Status_Update(int Id, string CCode, string BillNo, string Status, string Currency, string CurrValue, string PaymentMode, string Date, string Bank, string Reference, string CollectedBy, string PaymentDetails, string Remarks, string Advance, string OthDeduct, string Received, string Balance)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_PaymentDetailsChanges";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@BillNo", BillNo);
            cmd.Parameters.AddWithValue("@Status", Status);
            cmd.Parameters.AddWithValue("@Currency", Currency);
            cmd.Parameters.AddWithValue("@CurrValue", CurrValue);
            cmd.Parameters.AddWithValue("@PaymentMode", PaymentMode);
            cmd.Parameters.AddWithValue("@Date", Date);
            cmd.Parameters.AddWithValue("@Bank", Bank);
            cmd.Parameters.AddWithValue("@Reference", Reference);
            cmd.Parameters.AddWithValue("@CollectedBy", CollectedBy);
            cmd.Parameters.AddWithValue("@PaymentDetails", PaymentDetails);
            cmd.Parameters.AddWithValue("@Remarks", Remarks);
            cmd.Parameters.AddWithValue("@Advance", Advance);
            cmd.Parameters.AddWithValue("@OthDeduct", OthDeduct);
            cmd.Parameters.AddWithValue("@Received", Received);
            cmd.Parameters.AddWithValue("@Balance", Balance);
            cmd.Parameters.AddWithValue("@StatementType", "Update");
            int InsertCnt = cmd.ExecuteNonQuery();
            conn.Close();
            return InsertCnt > 0 ? true : false;
        }

        public bool Payment_Status_Delete(int Id, string CCode, string BillNo)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_PaymentDetailsChanges";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@BillNo", BillNo);
            cmd.Parameters.AddWithValue("@Status", DBNull.Value);
            cmd.Parameters.AddWithValue("@Currency", DBNull.Value);
            cmd.Parameters.AddWithValue("@CurrValue", DBNull.Value);
            cmd.Parameters.AddWithValue("@PaymentMode", DBNull.Value);
            cmd.Parameters.AddWithValue("@Date", DBNull.Value);
            cmd.Parameters.AddWithValue("@Bank", DBNull.Value);
            cmd.Parameters.AddWithValue("@Reference", DBNull.Value);
            cmd.Parameters.AddWithValue("@CollectedBy", DBNull.Value);
            cmd.Parameters.AddWithValue("@PaymentDetails", DBNull.Value);
            cmd.Parameters.AddWithValue("@Remarks", DBNull.Value);
            cmd.Parameters.AddWithValue("@Advance", DBNull.Value);
            cmd.Parameters.AddWithValue("@OthDeduct", DBNull.Value);
            cmd.Parameters.AddWithValue("@Received", DBNull.Value);
            cmd.Parameters.AddWithValue("@Balance", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "Delete");
            int InsertCnt = cmd.ExecuteNonQuery();
            conn.Close();
            return InsertCnt > 0 ? true : false;
        }



        public SqlDataReader Invoice_Search_GSTReportMonth(string CCode, string Payment, string InvoiceType, string Month)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_InvoiceDetails";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@Category", DBNull.Value);
            cmd.Parameters.AddWithValue("@JobNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@BillNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@BillDate", DBNull.Value);
            cmd.Parameters.AddWithValue("@To1", DBNull.Value);
            cmd.Parameters.AddWithValue("@SalesRep", DBNull.Value);
            cmd.Parameters.AddWithValue("@Month", Month);
            cmd.Parameters.AddWithValue("@CurrValue", Payment);
            cmd.Parameters.AddWithValue("@InvoiceType", InvoiceType);
            cmd.Parameters.AddWithValue("@CreditNoteNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "GSTReportMonth");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }

        public SqlDataReader Invoice_Search_GSTReportCustomer(string CCode, string To, string Payment, string InvoiceType, string Month)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_InvoiceDetails";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@Category", DBNull.Value);
            cmd.Parameters.AddWithValue("@JobNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@BillNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@BillDate", DBNull.Value);
            cmd.Parameters.AddWithValue("@To1", To);
            cmd.Parameters.AddWithValue("@SalesRep", DBNull.Value);
            cmd.Parameters.AddWithValue("@Month", Month);
            cmd.Parameters.AddWithValue("@CurrValue", Payment);
            cmd.Parameters.AddWithValue("@InvoiceType", InvoiceType);
            cmd.Parameters.AddWithValue("@CreditNoteNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "GSTReportCustomer");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }

        public SqlDataReader Invoice_Search_BillNoDistinct(string CCode, string Category)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_InvoiceDetails";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@Category", Category);
            cmd.Parameters.AddWithValue("@JobNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@BillNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@BillDate", DBNull.Value);
            cmd.Parameters.AddWithValue("@To1", DBNull.Value);
            cmd.Parameters.AddWithValue("@SalesRep", DBNull.Value);
            cmd.Parameters.AddWithValue("@Month", DBNull.Value);
            cmd.Parameters.AddWithValue("@CurrValue", DBNull.Value);
            cmd.Parameters.AddWithValue("@InvoiceType", DBNull.Value);
            cmd.Parameters.AddWithValue("@CreditNoteNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@AWBNo", DBNull.Value);
            cmd.Parameters.AddWithValue("@StatementType", "SelectDISTINCTInvoice");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }
        // test date
        public SqlDataReader Invoice_TestDate(string CCode, string InvoiceType, string FromDate, string ToDate)
        {
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "USP_DateReport";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CCode", CCode);
            cmd.Parameters.AddWithValue("@InvoiceType", InvoiceType);
            cmd.Parameters.AddWithValue("@FromDate", FromDate);
            cmd.Parameters.AddWithValue("@ToDate", ToDate);
            cmd.Parameters.AddWithValue("@StatementType", "Select");
            SqlDataReader resultReader = null;
            resultReader = cmd.ExecuteReader();
            return resultReader;
        }
    }
}