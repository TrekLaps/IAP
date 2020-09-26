using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Net;
using System.Globalization;
using System.Web;
using System.Net.Mail;
using System.IO;
using System.Web.UI;


/// <summary>
/// Basic Operations on database 
/// </summary>
public class Operations
{
    // Call the database connection from webconfig 
    public SqlConnection Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LoggedDev"].ConnectionString);

    //==================================================================

    /// <summary>
    /// Open database connection
    /// </summary>
    private void ConOpen()
    {
        try
        {
            // Check if database connection is closed , Open it
            if (Conn.State == ConnectionState.Closed)
            {

                Conn.Open();

            }
        }
        catch { }
    }
    //=================================================================
 
    /// <summary>
    /// Close Database Connection 
    /// </summary>
    private void ConClose()
    {
        try
        {
            // Check if database connection is Opened  , Close it
            if (Conn.State == ConnectionState.Open)
            {
                Conn.Close();
            }
        }
        catch { }
    }

    //=====================================================================

    /// <summary>
    /// General function to execute any stored procedure (stored without paraameters) in database that return Dataset
    /// </summary>
    /// <param name="StoredName"></param>
    /// <returns></returns>

    public DataSet GetDataSet(string StoredName)
    {
        try
        {

            SqlCommand CMD = new SqlCommand();
            CMD.Connection = Conn;
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.CommandText = StoredName;  // Stored without parameters
            DataSet ds = new DataSet();
            SqlDataAdapter ad = new SqlDataAdapter();
            ConOpen();
            CMD.ExecuteNonQuery();
            ad.SelectCommand = CMD;
            ad.Fill(ds);
            ConClose();

            return ds;
        }
        catch { return null; }

    }

    public DataSet ReportFilterAllAdmin(int Admin, int Section, int Importance, int Status, bool Repeat, bool CheckRepeat, string RepFrom, int RepPlan, int RepeatTest, int Replies) // Filter Reports
    {
        try
        {
            SqlCommand CMD = new SqlCommand();
            CMD.Connection = Conn;
            CMD.CommandType = CommandType.StoredProcedure;

            DataSet ds = new DataSet();
            SqlDataAdapter ad = new SqlDataAdapter();

            if (Admin == 0 && Section == 0 && Importance == 0 && Status == 0 && RepeatTest != 1 && RepFrom == "" && RepPlan == 0 && Replies == 0)
            {
                CMD.CommandText = "GetReports";
                ConOpen();
            }
            else
            {

                CMD.CommandText = "ReportFilterAllAdmin";
                ConOpen();
                CMD.Parameters.AddWithValue("@RepeatTest", RepeatTest);
                CMD.Parameters.AddWithValue("@Admin", Admin);
                CMD.Parameters.AddWithValue("@Section", Section);
                CMD.Parameters.AddWithValue("@Importance", Importance);
                CMD.Parameters.AddWithValue("@Status", Status);
                CMD.Parameters.AddWithValue("@RepFrom", RepFrom);
                CMD.Parameters.AddWithValue("@RepPlan", RepPlan);
                CMD.Parameters.AddWithValue("@Repeat", Repeat);
                CMD.Parameters.AddWithValue("@Replies", Replies);

            }
            CMD.ExecuteNonQuery();
            ad.SelectCommand = CMD;
            ad.Fill(ds);
            ConClose();

            return ds;
        }
        catch { return null; }

    }

    public DataSet ReportFilterAll(int Admin, int Section, int Importance, int Status, bool Repeat, bool CheckRepeat, string RepFrom, int RepPlan, int RepeatTest) // Filter Reports
    {
        try
        {
            SqlCommand CMD = new SqlCommand();
            CMD.Connection = Conn;
            CMD.CommandType = CommandType.StoredProcedure;

            DataSet ds = new DataSet();
            SqlDataAdapter ad = new SqlDataAdapter();

            if (Admin == 0 && Section == 0 && Importance == 0 && Status == 0 && RepeatTest != 1 && RepFrom == "" && RepPlan == 0)
            {
                CMD.CommandText = "GetReports";
                ConOpen();
            }
            else
            {

                CMD.CommandText = "ReportFilterAll";
                ConOpen();
                CMD.Parameters.AddWithValue("@RepeatTest", RepeatTest);
                CMD.Parameters.AddWithValue("@Admin", Admin);
                CMD.Parameters.AddWithValue("@Section", Section);
                CMD.Parameters.AddWithValue("@Importance", Importance);
                CMD.Parameters.AddWithValue("@Status", Status);
                CMD.Parameters.AddWithValue("@RepFrom", RepFrom);
                CMD.Parameters.AddWithValue("@RepPlan", RepPlan);
                CMD.Parameters.AddWithValue("@Repeat", Repeat);


            }
            CMD.ExecuteNonQuery();
            ad.SelectCommand = CMD;
            ad.Fill(ds);
            ConClose();

            return ds;
        }
        catch { return null; }

    }

    public DataSet ReportFiltersDate(int Admin, int Section, int Importance, int Status, bool Repeat, bool CheckRepeat, string RepFrom) // Filter Reports
    {
        try
        {
            SqlCommand CMD = new SqlCommand();
            CMD.Connection = Conn;
            CMD.CommandType = CommandType.StoredProcedure;

            DataSet ds = new DataSet();
            SqlDataAdapter ad = new SqlDataAdapter();

            if (Admin == 0 && Section == 0 && Importance == 0 && Status == 0 && CheckRepeat != false && RepFrom == "")
            {
                CMD.CommandText = "GetReports";
                ConOpen();
            }
            else
            {

                CMD.CommandText = "ReportFiltersDate";
                ConOpen();
                CMD.Parameters.AddWithValue("@Admin", Admin);
                CMD.Parameters.AddWithValue("@Section", Section);
                CMD.Parameters.AddWithValue("@Importance", Importance);
                CMD.Parameters.AddWithValue("@Status", Status);
                CMD.Parameters.AddWithValue("@RepFrom", RepFrom);
                if (CheckRepeat == false)
                {
                    CMD.Parameters.AddWithValue("@Repeat", Repeat);
                }
                else
                { CMD.Parameters.AddWithValue("@Repeat", DBNull.Value); }

            }
            CMD.ExecuteNonQuery();
            ad.SelectCommand = CMD;
            ad.Fill(ds);
            ConClose();

            return ds;
        }
        catch { return null; }

    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="Admin"></param>
    /// <param name="Section"></param>
    /// <param name="Importance"></param>
    /// <param name="Status"></param>
    /// <param name="Repeat"></param>
    /// <param name="CheckRepeat"></param>
    /// <returns></returns>
    public DataSet ReportFilters(int Admin, int Section, int Importance, int Status, bool Repeat, bool CheckRepeat) // Filter Reports
    {
        try
        {
            SqlCommand CMD = new SqlCommand();
            CMD.Connection = Conn;
            CMD.CommandType = CommandType.StoredProcedure;

            DataSet ds = new DataSet();
            SqlDataAdapter ad = new SqlDataAdapter();

            if (Admin == 0 && Section == 0 && Importance == 0 && Status == 0 && CheckRepeat != false)
            {
                CMD.CommandText = "GetReports";
                ConOpen();
            }
            else
            {

                CMD.CommandText = "ReportFilters";
                ConOpen();
                CMD.Parameters.AddWithValue("@Admin", Admin);
                CMD.Parameters.AddWithValue("@Section", Section);
                CMD.Parameters.AddWithValue("@Importance", Importance);
                CMD.Parameters.AddWithValue("@Status", Status);
                if (CheckRepeat == false)
                {
                    CMD.Parameters.AddWithValue("@Repeat", Repeat);
                }
                else
                { CMD.Parameters.AddWithValue("@Repeat", DBNull.Value); }

            }
            CMD.ExecuteNonQuery();
            ad.SelectCommand = CMD;
            ad.Fill(ds);
            ConClose();

            return ds;
        }
        catch { return null; }

    }


    public string ReportSecAllByStatYearNew = @"SELECT DISTINCT dbo.Sections.SectionID, dbo.Sections.SectionName,dbo.Reports.RepPlan 
FROM            dbo.Reports INNER JOIN
                         dbo.Sections ON dbo.Reports.RepSection = dbo.Sections.SectionID
WHERE          (dbo.Reports.Active=1)and (dbo.Sections.Active=1) 
";

    public DataSet ReportDashboard(string Datefrom, int Admin, int Section, int Importance, int Status, bool Repeat, bool CheckRepeat) // Filter Reports
    {
        try
        {
            SqlCommand CMD = new SqlCommand();
            CMD.Connection = Conn;
            CMD.CommandType = CommandType.StoredProcedure;

            DataSet ds = new DataSet();
            SqlDataAdapter ad = new SqlDataAdapter();

            if (Admin == 0 && Section == 0 && Importance == 0 && Status == 0 && CheckRepeat != false)
            {
                CMD.CommandText = "GetReports";
                ConOpen();
            }
            else
            {
                CMD.CommandText = "ReportDashboard";
                ConOpen();
                if (Datefrom == "")
                {
                    CMD.Parameters.AddWithValue("@Datefrom", "0");
                }
                else { CMD.Parameters.AddWithValue("@Datefrom", Datefrom); }
                CMD.Parameters.AddWithValue("@Admin", Admin);
                CMD.Parameters.AddWithValue("@Section", Section);
                CMD.Parameters.AddWithValue("@Importance", Importance);
                CMD.Parameters.AddWithValue("@Status", Status);
                if (CheckRepeat == false)
                {
                    CMD.Parameters.AddWithValue("@Repeat", Repeat);
                }
                else
                { CMD.Parameters.AddWithValue("@Repeat", DBNull.Value); }
            }
            CMD.ExecuteNonQuery();
            ad.SelectCommand = CMD;
            ad.Fill(ds);
            ConClose();

            return ds;
        }
        catch { return null; }

    }


    public DataSet ReportFiltersUPD(int Admin, int Section, int Importance, int Status, bool Repeat, bool CheckRepeat) // Filter Reports
    {
        try
        {
            SqlCommand CMD = new SqlCommand();
            CMD.Connection = Conn;
            CMD.CommandType = CommandType.StoredProcedure;

            DataSet ds = new DataSet();
            SqlDataAdapter ad = new SqlDataAdapter();

            if (Admin == 0 && Section == 0 && Importance == 0 && Status == 0 && CheckRepeat != false)
            {
                CMD.CommandText = "GetReportsUpdates";
                ConOpen();
            }
            else
            {
                CMD.CommandText = "ReportFiltersUPD";
                ConOpen();
                CMD.Parameters.AddWithValue("@Admin", Admin);
                CMD.Parameters.AddWithValue("@Section", Section);
                CMD.Parameters.AddWithValue("@Importance", Importance);
                CMD.Parameters.AddWithValue("@Status", Status);
                if (CheckRepeat == false)
                {
                    CMD.Parameters.AddWithValue("@Repeat", Repeat);
                }
                else
                { CMD.Parameters.AddWithValue("@Repeat", DBNull.Value); }
            }
            CMD.ExecuteNonQuery();
            ad.SelectCommand = CMD;
            ad.Fill(ds);
            ConClose();

            return ds;
        }
        catch { return null; }

    }



    //======================================================================

    /// <summary>
    ///  General function to execute any stored procedure (stored with one parameter)in database , Returns dataset 
    /// </summary>
    /// <param name="StoredName"></param>
    /// <param name="ID"></param>
    /// <returns></returns>
    public DataSet GetDataSetByID(string StoredName, int ID)
    {
        try
        {

            SqlCommand CMD = new SqlCommand();
            CMD.Connection = Conn;
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.CommandText = StoredName;
            DataSet ds = new DataSet();
            SqlDataAdapter ad = new SqlDataAdapter();
            ConOpen();
            CMD.Parameters.AddWithValue("@ID", ID); // Stored procedure takes one parameter
            CMD.ExecuteNonQuery();
            ad.SelectCommand = CMD;
            ad.Fill(ds);
            ConClose();

            return ds;
        }
        catch { return null; }

    }

    public DataSet GetDataSetBy2ID(string StoredName, int ID, int ID2)
    {
        try
        {

            SqlCommand CMD = new SqlCommand();
            CMD.Connection = Conn;
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.CommandText = StoredName;
            DataSet ds = new DataSet();
            SqlDataAdapter ad = new SqlDataAdapter();
            ConOpen();
            CMD.Parameters.AddWithValue("@ID", ID);
            CMD.Parameters.AddWithValue("@ID2", ID2);// Stored procedure takes one parameter
            CMD.ExecuteNonQuery();
            ad.SelectCommand = CMD;
            ad.Fill(ds);
            ConClose();

            return ds;
        }
        catch { return null; }

    }
    public DataSet GetDataSetBy3ID(string StoredName, int ID, int ID2, int ID3)
    {
        try
        {

            SqlCommand CMD = new SqlCommand();
            CMD.Connection = Conn;
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.CommandText = StoredName;
            DataSet ds = new DataSet();
            SqlDataAdapter ad = new SqlDataAdapter();
            ConOpen();
            CMD.Parameters.AddWithValue("@ID", ID);
            CMD.Parameters.AddWithValue("@ID2", ID2);
            CMD.Parameters.AddWithValue("@ID3", ID3);

            CMD.ExecuteNonQuery();
            ad.SelectCommand = CMD;
            ad.Fill(ds);
            ConClose();

            return ds;
        }
        catch { return null; }

    }

    public DataSet GetDataSetBy5ID(string StoredName, int ID, int ID2, int ID3, int ID4, int ID5)
    {
        try
        {

            SqlCommand CMD = new SqlCommand();
            CMD.Connection = Conn;
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.CommandText = StoredName;
            DataSet ds = new DataSet();
            SqlDataAdapter ad = new SqlDataAdapter();
            ConOpen();
            CMD.Parameters.AddWithValue("@ID", ID);
            CMD.Parameters.AddWithValue("@ID2", ID2);
            CMD.Parameters.AddWithValue("@ID3", ID3);
            CMD.Parameters.AddWithValue("@ID4", ID4);
            CMD.Parameters.AddWithValue("@ID5", ID5);

            CMD.ExecuteNonQuery();
            ad.SelectCommand = CMD;
            ad.Fill(ds);
            ConClose();

            return ds;
        }
        catch { return null; }

    }
    public DataSet GetDataSetBy4ID(string StoredName, int ID, int ID2, int ID3, int ID4)
    {
        try
        {

            SqlCommand CMD = new SqlCommand();
            CMD.Connection = Conn;
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.CommandText = StoredName;
            DataSet ds = new DataSet();
            SqlDataAdapter ad = new SqlDataAdapter();
            ConOpen();
            CMD.Parameters.AddWithValue("@ID", ID);
            CMD.Parameters.AddWithValue("@ID2", ID2);
            CMD.Parameters.AddWithValue("@ID3", ID3);
            CMD.Parameters.AddWithValue("@ID4", ID4);

            CMD.ExecuteNonQuery();
            ad.SelectCommand = CMD;
            ad.Fill(ds);
            ConClose();

            return ds;
        }
        catch { return null; }

    }

    public DataSet GetPlansAdmBySection(int Plan, int Section)
    {
        try
        {

            SqlCommand CMD = new SqlCommand();
            CMD.Connection = Conn;
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.CommandText = "GetPlansAdmBySection";
            DataSet ds = new DataSet();
            SqlDataAdapter ad = new SqlDataAdapter();
            ConOpen();
            CMD.Parameters.AddWithValue("@Plan", Plan); // Stored procedure takes one parameter
            CMD.Parameters.AddWithValue("@Section", Section);
            CMD.ExecuteNonQuery();
            ad.SelectCommand = CMD;
            ad.Fill(ds);
            ConClose();

            return ds;
        }
        catch { return null; }

    }


    public DataSet GetChartImportnace(int Admin, int Status)
    {
        try
        {

            SqlCommand CMD = new SqlCommand();
            CMD.Connection = Conn;
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.CommandText = "GetChartImportnace";
            DataSet ds = new DataSet();
            SqlDataAdapter ad = new SqlDataAdapter();
            ConOpen();
            CMD.Parameters.AddWithValue("@Status", Status); // Stored procedure takes one parameter
            CMD.Parameters.AddWithValue("@Admin", Admin);
            CMD.ExecuteNonQuery();
            ad.SelectCommand = CMD;
            ad.Fill(ds);
            ConClose();

            return ds;
        }
        catch { return null; }

    }


    public int GetReportCountByAdminPlan(int Admin, int Plan)
    {
        try
        {
            int Done = 0;
            SqlCommand CMD = new SqlCommand();
            CMD.Connection = Conn;
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.CommandText = "GetReportCountByAdminPlan";
            ConOpen();

            CMD.Parameters.AddWithValue("@Admin", Admin);
            CMD.Parameters.AddWithValue("@Plan", Plan);

            Done = Convert.ToInt32(CMD.ExecuteScalar());

            ConClose();
            return Done;
        }
        catch { return 0; }

    }

    public DataSet GetChartBySectionAdmin(int Section, int Admin)
    {
        try
        {

            SqlCommand CMD = new SqlCommand();
            CMD.Connection = Conn;
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.CommandText = "GetChartBySectionAdmin";
            DataSet ds = new DataSet();
            SqlDataAdapter ad = new SqlDataAdapter();
            ConOpen();
            CMD.Parameters.AddWithValue("@Section", Section); // Stored procedure takes one parameter
            CMD.Parameters.AddWithValue("@Admin", Admin);
            CMD.ExecuteNonQuery();
            ad.SelectCommand = CMD;
            ad.Fill(ds);
            ConClose();

            return ds;
        }
        catch { return null; }

    }
    public DataSet GetChartBySectionAdminPlan(int Plan, int Section, int Admin)
    {
        try
        {

            SqlCommand CMD = new SqlCommand();
            CMD.Connection = Conn;
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.CommandText = "GetChartBySectionAdminPlan";
            DataSet ds = new DataSet();
            SqlDataAdapter ad = new SqlDataAdapter();
            ConOpen();
            CMD.Parameters.AddWithValue("@Plan", Plan);
            CMD.Parameters.AddWithValue("@Section", Section); // Stored procedure takes one parameter
            CMD.Parameters.AddWithValue("@Admin", Admin);
            CMD.ExecuteNonQuery();
            ad.SelectCommand = CMD;
            ad.Fill(ds);
            ConClose();

            return ds;
        }
        catch { return null; }

    }


    public DataSet GetChartByPlansStatus(int Plan, int Status, int Admin)
    {
        try
        {

            SqlCommand CMD = new SqlCommand();
            CMD.Connection = Conn;
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.CommandText = "GetChartByPlansStatus";
            DataSet ds = new DataSet();
            SqlDataAdapter ad = new SqlDataAdapter();
            ConOpen();
            CMD.Parameters.AddWithValue("@Plan", Plan);
            CMD.Parameters.AddWithValue("@Status", Status); // Stored procedure takes one parameter
            CMD.Parameters.AddWithValue("@Admin", Admin);
            CMD.ExecuteNonQuery();
            ad.SelectCommand = CMD;
            ad.Fill(ds);
            ConClose();

            return ds;
        }
        catch { return null; }

    }

    public DataSet GetChartImportBySecPlan(int Section, int Status, int Year)
    {
        try
        {

            SqlCommand CMD = new SqlCommand();
            CMD.Connection = Conn;
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.CommandText = "GetChartImportBySecPlan";
            DataSet ds = new DataSet();
            SqlDataAdapter ad = new SqlDataAdapter();
            ConOpen();
            CMD.Parameters.AddWithValue("@Status", Status);
            CMD.Parameters.AddWithValue("@Section", Section); // Stored procedure takes one parameter
            CMD.Parameters.AddWithValue("@Year", Year);
            CMD.ExecuteNonQuery();
            ad.SelectCommand = CMD;
            ad.Fill(ds);
            ConClose();

            return ds;
        }
        catch { return null; }

    }



    public DataSet GetChartImportBySec(int Section, int Status)
    {
        try
        {

            SqlCommand CMD = new SqlCommand();
            CMD.Connection = Conn;
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.CommandText = "GetChartImportBySec";
            DataSet ds = new DataSet();
            SqlDataAdapter ad = new SqlDataAdapter();
            ConOpen();
            CMD.Parameters.AddWithValue("@Status", Status);
            CMD.Parameters.AddWithValue("@Section", Section); // Stored procedure takes one parameter

            CMD.ExecuteNonQuery();
            ad.SelectCommand = CMD;
            ad.Fill(ds);
            ConClose();

            return ds;
        }
        catch { return null; }

    }

    public DataSet GetChartBySectionAdminStat(int Section, int Admin, int Status)
    {
        try
        {

            SqlCommand CMD = new SqlCommand();
            CMD.Connection = Conn;
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.CommandText = "GetChartBySectionAdminStat";
            DataSet ds = new DataSet();
            SqlDataAdapter ad = new SqlDataAdapter();
            ConOpen();
            CMD.Parameters.AddWithValue("@Status", Status);
            CMD.Parameters.AddWithValue("@Section", Section); // Stored procedure takes one parameter
            CMD.Parameters.AddWithValue("@Admin", Admin);
            CMD.ExecuteNonQuery();
            ad.SelectCommand = CMD;
            ad.Fill(ds);
            ConClose();

            return ds;
        }
        catch { return null; }

    }

    public int GetReportCountBySecAdmStat(int Section, int Admin, int Status)
    {
        try
        {
            int Done = 0;
            SqlCommand CMD = new SqlCommand();
            CMD.Connection = Conn;
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.CommandText = "GetReportCountBySecAdmStat";
            DataSet ds = new DataSet();
            SqlDataAdapter ad = new SqlDataAdapter();
            ConOpen();
            CMD.Parameters.AddWithValue("@Status", Status);
            CMD.Parameters.AddWithValue("@Section", Section); // Stored procedure takes one parameter
            CMD.Parameters.AddWithValue("@Admin", Admin);
            Done = Convert.ToInt32(CMD.ExecuteScalar());

            ConClose();
            return Done;
        }
        catch { return 0; }

    }

    public int GetReportCountBySecAdmPlan(int Section, int Admin, int Plan)
    {
        try
        {
            int Done = 0;
            SqlCommand CMD = new SqlCommand();
            CMD.Connection = Conn;
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.CommandText = "GetReportCountBySecAdmPlan";
            DataSet ds = new DataSet();
            SqlDataAdapter ad = new SqlDataAdapter();
            ConOpen();
            CMD.Parameters.AddWithValue("@Plan", Plan);
            CMD.Parameters.AddWithValue("@Section", Section); // Stored procedure takes one parameter
            CMD.Parameters.AddWithValue("@Admin", Admin);
            Done = Convert.ToInt32(CMD.ExecuteScalar());

            ConClose();
            return Done;
        }
        catch { return 0; }

    }

    public int GetReportCountAdmPlanStat(int Plan, int Admin, int Status)
    {
        try
        {
            int Done = 0;
            SqlCommand CMD = new SqlCommand();
            CMD.Connection = Conn;
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.CommandText = "GetReportCountAdmPlanStat";
            DataSet ds = new DataSet();
            SqlDataAdapter ad = new SqlDataAdapter();
            ConOpen();
            CMD.Parameters.AddWithValue("@Plan", Plan);
            CMD.Parameters.AddWithValue("@Admin", Admin);
            CMD.Parameters.AddWithValue("@Status", Status);
            Done = Convert.ToInt32(CMD.ExecuteScalar());

            ConClose();
            return Done;
        }
        catch { return 0; }

    }


    public int GetReportCountBySecAdmPlanStat(int Plan, int Section, int Admin, int Status)
    {
        try
        {
            int Done = 0;
            SqlCommand CMD = new SqlCommand();
            CMD.Connection = Conn;
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.CommandText = "GetReportCountBySecAdmPlanStat";
            DataSet ds = new DataSet();
            SqlDataAdapter ad = new SqlDataAdapter();
            ConOpen();
            CMD.Parameters.AddWithValue("@Plan", Plan);
            CMD.Parameters.AddWithValue("@Section", Section); // Stored procedure takes one parameter
            CMD.Parameters.AddWithValue("@Admin", Admin);
            CMD.Parameters.AddWithValue("@Status", Status);
            Done = Convert.ToInt32(CMD.ExecuteScalar());

            ConClose();
            return Done;
        }
        catch { return 0; }

    }

    public DataSet GetRepCountByStatSec(int ID, int Section)
    {
        try
        {

            SqlCommand CMD = new SqlCommand();
            CMD.Connection = Conn;
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.CommandText = "GetRepCountByStatSec";
            DataSet ds = new DataSet();
            SqlDataAdapter ad = new SqlDataAdapter();
            ConOpen();
            CMD.Parameters.AddWithValue("@ID", ID); // Stored procedure takes one parameter
            CMD.Parameters.AddWithValue("@Section", Section);
            CMD.ExecuteNonQuery();
            ad.SelectCommand = CMD;
            ad.Fill(ds);
            ConClose();

            return ds;
        }
        catch { return null; }

    }

    public string ReadRepwithStatusAllImp = @"select dbo.Reports.RepID ,dbo.Reports.RepText,RepStatus,dbo.Reports.Importance ,RepTitle , dbo.Reports.RepAdms, RepSection
FROM            dbo.Reports INNER JOIN
                         dbo.Administration ON dbo.Reports.RepAdms = dbo.Administration.AdmID
WHERE        (dbo.Reports.Active = 1) AND ";

    public DataSet FilterMainReportsAll(int Year, int Sector, int Depart)
    {
        try
        {

            SqlCommand CMD = new SqlCommand();
            CMD.Connection = Conn;
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.CommandText = "FilterMainReportsAll";
            DataSet ds = new DataSet();
            SqlDataAdapter ad = new SqlDataAdapter();
            ConOpen();
            CMD.Parameters.AddWithValue("@Year", Year); // Stored procedure takes one parameter
            CMD.Parameters.AddWithValue("@Sector", Sector);
            CMD.Parameters.AddWithValue("@Depart", Depart);
            CMD.ExecuteNonQuery();
            ad.SelectCommand = CMD;
            ad.Fill(ds);
            ConClose();

            return ds;
        }
        catch { return null; }

    }

    public DataSet FilterMainReportsSector(int Year, int Sector)
    {
        try
        {

            SqlCommand CMD = new SqlCommand();
            CMD.Connection = Conn;
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.CommandText = "FilterMainReportsSector";
            DataSet ds = new DataSet();
            SqlDataAdapter ad = new SqlDataAdapter();
            ConOpen();
            CMD.Parameters.AddWithValue("@Year", Year); // Stored procedure takes one parameter
            CMD.Parameters.AddWithValue("@Sector", Sector);

            CMD.ExecuteNonQuery();
            ad.SelectCommand = CMD;
            ad.Fill(ds);
            ConClose();

            return ds;
        }
        catch { return null; }

    }


    public DataSet GetPlansAdmBySectionAll(int Section)
    {
        try
        {

            SqlCommand CMD = new SqlCommand();
            CMD.Connection = Conn;
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.CommandText = "GetPlansAdmBySectionAll";
            DataSet ds = new DataSet();
            SqlDataAdapter ad = new SqlDataAdapter();
            ConOpen();

            CMD.Parameters.AddWithValue("@Section", Section);
            CMD.ExecuteNonQuery();
            ad.SelectCommand = CMD;
            ad.Fill(ds);
            ConClose();

            return ds;
        }
        catch { return null; }

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="PlanID"></param>
    /// <param name="SectionID"></param>
    /// <returns></returns>

    public DataSet GetPlansAdmins(int PlanID, int SectionID)
    {
        try
        {

            SqlCommand CMD = new SqlCommand();
            CMD.Connection = Conn;
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.CommandText = "GetPlansAdmins";
            DataSet ds = new DataSet();
            SqlDataAdapter ad = new SqlDataAdapter();
            ConOpen();
            CMD.Parameters.AddWithValue("@PlanID", PlanID); // Stored procedure takes one parameter
            CMD.Parameters.AddWithValue("@SectionID", SectionID);
            CMD.ExecuteNonQuery();
            ad.SelectCommand = CMD;
            ad.Fill(ds);
            ConClose();

            return ds;
        }
        catch { return null; }

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="Plan"></param>
    /// <param name="Section"></param>
    /// <param name="Admin"></param>
    /// <returns></returns>
    public DataSet GetAdminsCounts(int Plan, int Section, int Admin)
    {
        try
        {

            SqlCommand CMD = new SqlCommand();
            CMD.Connection = Conn;
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.CommandText = "GetAdminsCounts";
            DataSet ds = new DataSet();
            SqlDataAdapter ad = new SqlDataAdapter();
            ConOpen();
            CMD.Parameters.AddWithValue("@Plan", Plan); // Stored procedure takes one parameter
            CMD.Parameters.AddWithValue("@Section", Section);
            CMD.Parameters.AddWithValue("@Admin", Admin);
            CMD.ExecuteNonQuery();
            ad.SelectCommand = CMD;
            ad.Fill(ds);
            ConClose();

            return ds;
        }
        catch { return null; }

    }

    public DataSet GetStatusByYear(int Plan, int Section)
    {
        try
        {

            SqlCommand CMD = new SqlCommand();
            CMD.Connection = Conn;
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.CommandText = "GetStatusByYear";
            DataSet ds = new DataSet();
            SqlDataAdapter ad = new SqlDataAdapter();
            ConOpen();
            CMD.Parameters.AddWithValue("@Plan", Plan); // Stored procedure takes one parameter
            CMD.Parameters.AddWithValue("@Section", Section);

            CMD.ExecuteNonQuery();
            ad.SelectCommand = CMD;
            ad.Fill(ds);
            ConClose();

            return ds;
        }
        catch { return null; }

    }

    public DataSet GetChartAdminPlanStat(int Plan, int Admin, int Status)
    {
        try
        {

            SqlCommand CMD = new SqlCommand();
            CMD.Connection = Conn;
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.CommandText = "GetChartAdminPlanStat";
            DataSet ds = new DataSet();
            SqlDataAdapter ad = new SqlDataAdapter();
            ConOpen();
            CMD.Parameters.AddWithValue("@Plan", Plan); // Stored procedure takes one parameter
            CMD.Parameters.AddWithValue("@Admin", Admin); // Stored procedure takes one parameter
            CMD.Parameters.AddWithValue("@Status", Status);

            CMD.ExecuteNonQuery();
            ad.SelectCommand = CMD;
            ad.Fill(ds);
            ConClose();

            return ds;
        }
        catch { return null; }

    }



    public DataSet GetChartBySectionAdminPlanStat(int Plan, int Section, int Admin, int Status)
    {
        try
        {

            SqlCommand CMD = new SqlCommand();
            CMD.Connection = Conn;
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.CommandText = "GetChartBySectionAdminPlanStat";
            DataSet ds = new DataSet();
            SqlDataAdapter ad = new SqlDataAdapter();
            ConOpen();
            CMD.Parameters.AddWithValue("@Plan", Plan); // Stored procedure takes one parameter
            CMD.Parameters.AddWithValue("@Section", Section);
            CMD.Parameters.AddWithValue("@Admin", Admin); // Stored procedure takes one parameter
            CMD.Parameters.AddWithValue("@Status", Status);

            CMD.ExecuteNonQuery();
            ad.SelectCommand = CMD;
            ad.Fill(ds);
            ConClose();

            return ds;
        }
        catch { return null; }

    }

    public DataSet GetImportByPlanStat(int Plan, int Section, int Admin, int Status)
    {
        try
        {

            SqlCommand CMD = new SqlCommand();
            CMD.Connection = Conn;
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.CommandText = "GetImportByPlanStat";
            DataSet ds = new DataSet();
            SqlDataAdapter ad = new SqlDataAdapter();
            ConOpen();
            CMD.Parameters.AddWithValue("@Plan", Plan); // Stored procedure takes one parameter
            CMD.Parameters.AddWithValue("@Section", Section);
            CMD.Parameters.AddWithValue("@Admin", Admin); // Stored procedure takes one parameter
            CMD.Parameters.AddWithValue("@Status", Status);

            CMD.ExecuteNonQuery();
            ad.SelectCommand = CMD;
            ad.Fill(ds);
            ConClose();

            return ds;
        }
        catch { return null; }

    }

    public DataSet GetImportByAdminStat(int Admin, int Status)
    {
        try
        {

            SqlCommand CMD = new SqlCommand();
            CMD.Connection = Conn;
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.CommandText = "GetImportByAdminStat";
            DataSet ds = new DataSet();
            SqlDataAdapter ad = new SqlDataAdapter();
            ConOpen();
            CMD.Parameters.AddWithValue("@Admin", Admin); // Stored procedure takes one parameter
            CMD.Parameters.AddWithValue("@Status", Status);

            CMD.ExecuteNonQuery();
            ad.SelectCommand = CMD;
            ad.Fill(ds);
            ConClose();

            return ds;
        }
        catch { return null; }

    }

    public DataSet GetImportByPlanAll(int Plan, int Section, int Admin)
    {
        try
        {

            SqlCommand CMD = new SqlCommand();
            CMD.Connection = Conn;
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.CommandText = "GetImportByPlanAll";
            DataSet ds = new DataSet();
            SqlDataAdapter ad = new SqlDataAdapter();
            ConOpen();
            CMD.Parameters.AddWithValue("@Plan", Plan); // Stored procedure takes one parameter
            CMD.Parameters.AddWithValue("@Section", Section);
            CMD.Parameters.AddWithValue("@Admin", Admin); // Stored procedure takes one parameter

            CMD.ExecuteNonQuery();
            ad.SelectCommand = CMD;
            ad.Fill(ds);
            ConClose();

            return ds;
        }
        catch { return null; }

    }


    public DataSet GetImportByPlanAllYears(int Section, int Admin)
    {
        try
        {

            SqlCommand CMD = new SqlCommand();
            CMD.Connection = Conn;
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.CommandText = "GetImportByPlanAllYears";
            DataSet ds = new DataSet();
            SqlDataAdapter ad = new SqlDataAdapter();
            ConOpen();
            CMD.Parameters.AddWithValue("@Section", Section);
            CMD.Parameters.AddWithValue("@Admin", Admin); // Stored procedure takes one parameter

            CMD.ExecuteNonQuery();
            ad.SelectCommand = CMD;
            ad.Fill(ds);
            ConClose();

            return ds;
        }
        catch { return null; }

    }


    public DataSet GetImportByAll(int Admin)
    {
        try
        {

            SqlCommand CMD = new SqlCommand();
            CMD.Connection = Conn;
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.CommandText = "GetImportByAll";
            DataSet ds = new DataSet();
            SqlDataAdapter ad = new SqlDataAdapter();
            ConOpen();
            CMD.Parameters.AddWithValue("@Admin", Admin); // Stored procedure takes one parameter

            CMD.ExecuteNonQuery();
            ad.SelectCommand = CMD;
            ad.Fill(ds);
            ConClose();

            return ds;
        }
        catch { return null; }

    }


    public DataSet GetAllAdminsByPlan(int Plan, int Section)
    {
        try
        {

            SqlCommand CMD = new SqlCommand();
            CMD.Connection = Conn;
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.CommandText = "GetAllAdminsByPlan";
            DataSet ds = new DataSet();
            SqlDataAdapter ad = new SqlDataAdapter();
            ConOpen();
            CMD.Parameters.AddWithValue("@Plan", Plan); // Stored procedure takes one parameter
            CMD.Parameters.AddWithValue("@Section", Section);

            CMD.ExecuteNonQuery();
            ad.SelectCommand = CMD;
            ad.Fill(ds);
            ConClose();

            return ds;
        }
        catch { return null; }

    }

    public int GetChartByPlanTotal(int Plan, int Section)
    {
        try
        {
            int Done = 0;
            SqlCommand CMD = new SqlCommand();
            CMD.Connection = Conn;
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.CommandText = "GetChartByPlanTotal";
            ConOpen();

            CMD.Parameters.AddWithValue("@Plan", Plan);
            CMD.Parameters.AddWithValue("@Section", Section);

            Done = Convert.ToInt32(CMD.ExecuteScalar());

            ConClose();
            return Done;
        }
        catch { return 0; }

    }

    public int GetChartByAdminTotal(int Plan, int Section, int Admin)
    {
        try
        {
            int Done = 0;
            SqlCommand CMD = new SqlCommand();
            CMD.Connection = Conn;
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.CommandText = "GetChartByAdminTotal";
            ConOpen();

            CMD.Parameters.AddWithValue("@Plan", Plan);
            CMD.Parameters.AddWithValue("@Section", Section);
            CMD.Parameters.AddWithValue("@Admin", Admin);

            Done = Convert.ToInt32(CMD.ExecuteScalar());

            ConClose();
            return Done;
        }
        catch { return 0; }

    }


    public DataSet GetChartByPlan(int Plan, int Section)
    {
        try
        {

            SqlCommand CMD = new SqlCommand();
            CMD.Connection = Conn;
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.CommandText = "GetChartByPlan";
            DataSet ds = new DataSet();
            SqlDataAdapter ad = new SqlDataAdapter();
            ConOpen();
            CMD.Parameters.AddWithValue("@Plan", Plan); // Stored procedure takes one parameter
            CMD.Parameters.AddWithValue("@Section", Section);
            CMD.ExecuteNonQuery();
            ad.SelectCommand = CMD;
            ad.Fill(ds);
            ConClose();

            return ds;
        }
        catch { return null; }

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="Plan"></param>
    /// <param name="Section"></param>
    /// <param name="Admin"></param>
    /// <returns></returns>
    public DataSet GetChartByAdminPlan(int Plan, int Section, int Admin)
    {
        try
        {

            SqlCommand CMD = new SqlCommand();
            CMD.Connection = Conn;
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.CommandText = "GetChartByAdminPlan";
            DataSet ds = new DataSet();
            SqlDataAdapter ad = new SqlDataAdapter();
            ConOpen();
            CMD.Parameters.AddWithValue("@Plan", Plan); // Stored procedure takes one parameter
            CMD.Parameters.AddWithValue("@Section", Section);
            CMD.Parameters.AddWithValue("@Admin", Admin);
            CMD.ExecuteNonQuery();
            ad.SelectCommand = CMD;
            ad.Fill(ds);
            ConClose();

            return ds;
        }
        catch { return null; }

    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Plan"></param>
    /// <param name="Section"></param>
    /// <param name="Admin"></param>
    /// <returns></returns>
    public DataSet GetChartByAdminPlanImport(int Plan, int Admin)
    {
        try
        {

            SqlCommand CMD = new SqlCommand();
            CMD.Connection = Conn;
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.CommandText = "GetChartByAdminPlanImport";
            DataSet ds = new DataSet();
            SqlDataAdapter ad = new SqlDataAdapter();
            ConOpen();
            CMD.Parameters.AddWithValue("@Plan", Plan); // Stored procedure takes one parameter
            CMD.Parameters.AddWithValue("@Admin", Admin);
            CMD.ExecuteNonQuery();
            ad.SelectCommand = CMD;
            ad.Fill(ds);
            ConClose();

            return ds;
        }
        catch { return null; }

    }



    public DataSet GetChartByPlanImport(int Plan, int Section)
    {
        try
        {

            SqlCommand CMD = new SqlCommand();
            CMD.Connection = Conn;
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.CommandText = "GetChartByPlanImport";
            DataSet ds = new DataSet();
            SqlDataAdapter ad = new SqlDataAdapter();
            ConOpen();
            CMD.Parameters.AddWithValue("@Plan", Plan); // Stored procedure takes one parameter
            CMD.Parameters.AddWithValue("@Section", Section);

            CMD.ExecuteNonQuery();
            ad.SelectCommand = CMD;
            ad.Fill(ds);
            ConClose();

            return ds;
        }
        catch { return null; }

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="Admin"></param>
    /// <param name="Status"></param>
    /// <returns></returns>

    public DataSet GetAllAdminsImport(int Admin, int Status)
    {
        try
        {

            SqlCommand CMD = new SqlCommand();
            CMD.Connection = Conn;
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.CommandText = "GetAllAdminsImport";
            DataSet ds = new DataSet();
            SqlDataAdapter ad = new SqlDataAdapter();
            ConOpen();
            CMD.Parameters.AddWithValue("@Admin", Admin); // Stored procedure takes one parameter
            CMD.Parameters.AddWithValue("@Status", Status);
            CMD.ExecuteNonQuery();
            ad.SelectCommand = CMD;
            ad.Fill(ds);
            ConClose();

            return ds;
        }
        catch { return null; }

    }



    /// <summary>
    /// 
    /// </summary>
    /// <param name="StoredName"></param>
    /// <param name="ID"></param>
    /// <returns></returns>
    public DataSet GetDataSetByString(string StoredName, string ID)
    {
        try
        {

            SqlCommand CMD = new SqlCommand();
            CMD.Connection = Conn;
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.CommandText = StoredName;
            DataSet ds = new DataSet();
            SqlDataAdapter ad = new SqlDataAdapter();
            ConOpen();
            CMD.Parameters.AddWithValue("@ID", ID); // Stored procedure takes one parameter
            CMD.ExecuteNonQuery();
            ad.SelectCommand = CMD;
            ad.Fill(ds);
            ConClose();

            return ds;
        }
        catch { return null; }

    }

    //======================================================================
    /// <summary>
    /// 
    /// </summary>
    /// <param name="StoredName"></param>
    /// <param name="ID"></param>
    /// <returns></returns>
    public DataSet GetDataSetByBoolean(string StoredName, bool ID)
    {
        try
        {

            SqlCommand CMD = new SqlCommand();
            CMD.Connection = Conn;
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.CommandText = StoredName;
            DataSet ds = new DataSet();
            SqlDataAdapter ad = new SqlDataAdapter();
            ConOpen();
            CMD.Parameters.AddWithValue("@ID", ID); // Stored procedure takes one parameter
            CMD.ExecuteNonQuery();
            ad.SelectCommand = CMD;
            ad.Fill(ds);
            ConClose();

            return ds;
        }
        catch { return null; }

    }

    public string ReportAdminsPlanAllAdm = @"SELECT DISTINCT dbo.Administration.AdmName, dbo.Reports.RepPlan,dbo.Reports.RepAdms,dbo.Reports.RepSection
FROM            dbo.Reports INNER JOIN
                         dbo.Administration ON dbo.Reports.RepAdms = dbo.Administration.AdmID WHERE   (dbo.Reports.Active = 1)";


    public string ReportAdminsPlanAllAdmImp = @"SELECT DISTINCT dbo.Administration.AdmName, dbo.Reports.RepPlan,dbo.Reports.RepAdms,dbo.Reports.RepSection
FROM dbo.Reports INNER JOIN
                         dbo.Administration ON dbo.Reports.RepAdms = dbo.Administration.AdmID
WHERE        (dbo.Reports.Active = 1) AND";
    public int NewNoteComment(int NoteId, int ConfirmedBy, string ConfirmText)
    {
        try
        {
            int Done = 0;
            SqlCommand CMD = new SqlCommand();
            CMD.Connection = Conn;
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.CommandText = "NewNoteComment";
            ConOpen();

            CMD.Parameters.AddWithValue("@NoteID", NoteId);
            CMD.Parameters.AddWithValue("@ConfirmedBy", ConfirmedBy);
            CMD.Parameters.AddWithValue("@ConfirmText", ConfirmText);

            Done = Convert.ToInt32(CMD.ExecuteScalar());

            ConClose();
            return Done;
        }
        catch { return 0; }

    }

    //===============================================//



    public int NewActiveReportComment(int ReportID, int ConfirmedBy, string ConfirmText)
    {
        try
        {
            int Done = 0;
            SqlCommand CMD = new SqlCommand();
            CMD.Connection = Conn;
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.CommandText = "NewActiveReportComment";
            ConOpen();

            CMD.Parameters.AddWithValue("@ReportID", ReportID);
            CMD.Parameters.AddWithValue("@ConfirmedBy", ConfirmedBy);
            CMD.Parameters.AddWithValue("@ConfirmText", ConfirmText);

            Done = Convert.ToInt32(CMD.ExecuteScalar());

            ConClose();
            return Done;
        }
        catch { return 0; }

    }

    //==============================================//
    public int NewReportComment(int ReportID, int ConfirmedBy, string ConfirmText)
    {
        try
        {
            int Done = 0;
            SqlCommand CMD = new SqlCommand();
            CMD.Connection = Conn;
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.CommandText = "NewReportComment";
            ConOpen();

            CMD.Parameters.AddWithValue("@ReportID", ReportID);
            CMD.Parameters.AddWithValue("@ConfirmedBy", ConfirmedBy);
            CMD.Parameters.AddWithValue("@ConfirmText", ConfirmText);

            Done = Convert.ToInt32(CMD.ExecuteScalar());

            ConClose();
            return Done;
        }
        catch { return 0; }

    }

    //===============================================//
    public int UpdateNoteComment(int NoteID, int ConfirmedBy, string ConfirmText, int ConfirmID)
    {
        try
        {
            int Done = 0;
            SqlCommand CMD = new SqlCommand();
            CMD.Connection = Conn;
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.CommandText = "UpdateNoteComment";
            ConOpen();

            CMD.Parameters.AddWithValue("@NoteID", NoteID);
            CMD.Parameters.AddWithValue("@ConfirmedBy", ConfirmedBy);
            CMD.Parameters.AddWithValue("@ConfirmText", ConfirmText);
            CMD.Parameters.AddWithValue("@ConfirmID", ConfirmID);

            Done = Convert.ToInt32(CMD.ExecuteScalar());

            ConClose();
            return Done;
        }
        catch { return 0; }

    }

    //===============================================//


    public int UpdateReportComment(int ReportID, int ConfirmedBy, string ConfirmText, int ConfirmID)
    {
        try
        {
            int Done = 0;
            SqlCommand CMD = new SqlCommand();
            CMD.Connection = Conn;
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.CommandText = "UpdateReportComment";
            ConOpen();

            CMD.Parameters.AddWithValue("@ReportID", ReportID);
            CMD.Parameters.AddWithValue("@ConfirmedBy", ConfirmedBy);
            CMD.Parameters.AddWithValue("@ConfirmText", ConfirmText);
            CMD.Parameters.AddWithValue("@ConfirmID", ConfirmID);

            Done = Convert.ToInt32(CMD.ExecuteScalar());

            ConClose();
            return Done;
        }
        catch { return 0; }

    }

    //===============================================//

    public int ActiveReportComment(int ID, string ConfirmText)
    {
        try
        {
            int Done = 0;
            SqlCommand CMD = new SqlCommand();
            CMD.Connection = Conn;
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.CommandText = "ActiveReportComment";
            ConOpen();

            CMD.Parameters.AddWithValue("@ID", ID);
            CMD.Parameters.AddWithValue("@ConfirmText", ConfirmText);

            Done = Convert.ToInt32(CMD.ExecuteScalar());

            ConClose();
            return Done;
        }
        catch { return 0; }

    }

    //===============================================//

    /// <summary>
    /// Execute stored procedure return single value
    /// </summary>
    /// <param name="StoredName"></param>
    /// <param name="ID"></param>
    /// <returns></returns>
    public int ExecuteProcedureID(string StoredName, int ID)
    {
        try
        {
            int Done = 0;
            SqlCommand CMD = new SqlCommand();
            CMD.Connection = Conn;
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.CommandText = StoredName;
            ConOpen();
            CMD.Parameters.AddWithValue("@ID", ID);
            Done = Convert.ToInt32(CMD.ExecuteScalar());

            ConClose();
            return Done;

        }
        catch { return 0; }

    }


    public int ReportCountImportByRepeat(int Admin, int Section, int Importance, bool Repeat)
    {
        try
        {
            int Done = 0;
            SqlCommand CMD = new SqlCommand();
            CMD.Connection = Conn;
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.CommandText = "ReportCountByRepeat";
            ConOpen();
            CMD.Parameters.AddWithValue("@Admin", Admin);
            CMD.Parameters.AddWithValue("@Section", Section);
            CMD.Parameters.AddWithValue("@Importance", Importance);
            CMD.Parameters.AddWithValue("@Repeat", Repeat);

            Done = Convert.ToInt32(CMD.ExecuteScalar());

            ConClose();
            return Done;

        }
        catch { return 0; }

    }



    public int ReportCountStatusByRepeat(int Admin, int Section, int Status, bool Repeat)
    {
        try
        {
            int Done = 0;
            SqlCommand CMD = new SqlCommand();
            CMD.Connection = Conn;
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.CommandText = "ReportCountStatusByRepeat";
            ConOpen();
            CMD.Parameters.AddWithValue("@Admin", Admin);
            CMD.Parameters.AddWithValue("@Section", Section);
            CMD.Parameters.AddWithValue("@Status", Status);
            CMD.Parameters.AddWithValue("@Repeat", Repeat);

            Done = Convert.ToInt32(CMD.ExecuteScalar());

            ConClose();
            return Done;

        }
        catch { return 0; }

    }
    public int ExecuteProcedureStringID(string StoredName, int ID, string ID2)
    {
        try
        {
            int Done = 0;
            SqlCommand CMD = new SqlCommand();
            CMD.Connection = Conn;
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.CommandText = StoredName;
            ConOpen();
            CMD.Parameters.AddWithValue("@ID", ID);
            CMD.Parameters.AddWithValue("@ID2", ID2);
            Done = Convert.ToInt32(CMD.ExecuteScalar());

            ConClose();
            return Done;

        }
        catch { return 0; }

    }

    public int ExecuteProcedure4ID(string StoredName, int ID, int ID2, int ID3, int ID4)
    {
        try
        {
            int Done = 0;
            SqlCommand CMD = new SqlCommand();
            CMD.Connection = Conn;
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.CommandText = StoredName;
            ConOpen();
            CMD.Parameters.AddWithValue("@ID", ID);
            CMD.Parameters.AddWithValue("@ID2", ID2);
            CMD.Parameters.AddWithValue("@ID3", ID3);
            CMD.Parameters.AddWithValue("@ID4", ID4);
            Done = Convert.ToInt32(CMD.ExecuteScalar());

            ConClose();
            return Done;

        }
        catch { return 0; }

    }




    public int ExecuteProcedure3ID(string StoredName, int ID, int ID2, int ID3)
    {
        try
        {
            int Done = 0;
            SqlCommand CMD = new SqlCommand();
            CMD.Connection = Conn;
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.CommandText = StoredName;
            ConOpen();
            CMD.Parameters.AddWithValue("@ID", ID);
            CMD.Parameters.AddWithValue("@ID2", ID2);
            CMD.Parameters.AddWithValue("@ID3", ID3);
            Done = Convert.ToInt32(CMD.ExecuteScalar());

            ConClose();
            return Done;

        }
        catch { return 0; }

    }
    public int ExecuteProcedure2ID(string StoredName, int ID, int ID2)
    {
        try
        {
            int Done = 0;
            SqlCommand CMD = new SqlCommand();
            CMD.Connection = Conn;
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.CommandText = StoredName;
            ConOpen();
            CMD.Parameters.AddWithValue("@ID", ID);
            CMD.Parameters.AddWithValue("@ID2", ID2);
            Done = Convert.ToInt32(CMD.ExecuteScalar());

            ConClose();
            return Done;

        }
        catch { return 0; }

    }
    public int ExecuteProcedureBitID(string StoredName, int ID, Boolean ID2)
    {
        try
        {
            int Done = 0;
            SqlCommand CMD = new SqlCommand();
            CMD.Connection = Conn;
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.CommandText = StoredName;
            ConOpen();
            CMD.Parameters.AddWithValue("@ID", ID);
            CMD.Parameters.AddWithValue("@ID2", ID2);
            Done = Convert.ToInt32(CMD.ExecuteScalar());

            ConClose();
            return Done;

        }
        catch { return 0; }

    }
    public int DelPlansSections(int SectionID, int PlanID)
    {
        try
        {
            int Done = 0;
            SqlCommand CMD = new SqlCommand();
            CMD.Connection = Conn;
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.CommandText = "DelPlansSections";
            ConOpen();
            CMD.Parameters.AddWithValue("@SectionID", SectionID);
            CMD.Parameters.AddWithValue("@PlanID", PlanID);
            Done = Convert.ToInt32(CMD.ExecuteScalar());

            ConClose();
            return Done;

        }
        catch { return 0; }

    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="StoredName"></param>
    /// <param name="ID"></param>
    /// <returns></returns>
    public int ExecuteProcedureString(string StoredName, string ID)
    {
        try
        {
            int Done = 0;
            SqlCommand CMD = new SqlCommand();
            CMD.Connection = Conn;
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.CommandText = StoredName;
            ConOpen();
            CMD.Parameters.AddWithValue("@ID", ID);
            Done = Convert.ToInt32(CMD.ExecuteScalar());

            ConClose();
            return Done;

        }
        catch { return 0; }

    }
    public string ReportOneYearByAdmImp = @"SELECT     distinct   dbo.Plans.* , LEFT(dbo.Plans.YearName, 4)
FROM            dbo.Plans INNER JOIN
                         dbo.Reports ON dbo.Plans.ID = dbo.Reports.RepPlan ";





    public string ReportAdminsPlanAllNew = @"SELECT DISTINCT dbo.Reports.RepPlan,dbo.Administration.AdmName, dbo.Reports.RepAdms,dbo.Reports.RepAdms , dbo.Reports.RepSection ,dbo.Reports.RepPlan
FROM            dbo.Reports INNER JOIN
                         dbo.Administration ON dbo.Reports.RepAdms = dbo.Administration.AdmID
WHERE         (dbo.Reports.Active = 1)";




    public DataSet ExecuteString(string SqlStr)
    {
        try
        {

            SqlCommand CMD = new SqlCommand();
            CMD.Connection = Conn;
            CMD.CommandType = CommandType.Text;
            CMD.CommandText = SqlStr;
            DataSet ds = new DataSet();
            SqlDataAdapter ad = new SqlDataAdapter();
            ConOpen();

            CMD.ExecuteNonQuery();
            ad.SelectCommand = CMD;
            ad.Fill(ds);
            ConClose();

            return ds;
        }
        catch(Exception ex) { var a = ex.InnerException; return null; }

    }




    public int ExecuteProcedure(string StoredName)
    {
        try
        {
            int Done = 0;
            SqlCommand CMD = new SqlCommand();
            CMD.Connection = Conn;
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.CommandText = StoredName;
            ConOpen();
            Done = Convert.ToInt32(CMD.ExecuteScalar());

            ConClose();
            return Done;

        }
        catch { return 0; }

    }

    //====================================================================
    /// <summary>
    /// Login
    /// </summary>
    /// <param name="UserName"></param>
    /// <param name="Password"></param>
    /// <returns></returns>
    public DataSet SignIn(string UserName, string Password)
    {
        try
        {

            SqlCommand CMD = new SqlCommand();
            CMD.Connection = Conn;
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.CommandText = "Login";
            DataSet ds = new DataSet();
            SqlDataAdapter ad = new SqlDataAdapter();
            ConOpen();
            CMD.Parameters.AddWithValue("@EmpJobCode", UserName); //Username (Job Code orEmail)
            CMD.Parameters.AddWithValue("@EmpPassword", Password);
            CMD.ExecuteNonQuery();
            ad.SelectCommand = CMD;
            ad.Fill(ds);
            ConClose();

            return ds;
        }
        catch { return null; }

    }

    public DataSet SignInByUserName(string UserName)
    {
        try
        {

            SqlCommand CMD = new SqlCommand();
            CMD.Connection = Conn;
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.CommandText = "LoginByUserName";
            DataSet ds = new DataSet();
            SqlDataAdapter ad = new SqlDataAdapter();
            ConOpen();
            CMD.Parameters.AddWithValue("@EmpJobCode", UserName); //Username (Job Code orEmail)

            CMD.ExecuteNonQuery();
            ad.SelectCommand = CMD;
            ad.Fill(ds);
            ConClose();

            return ds;
        }
        catch { return null; }

    }



    //=========================================
    /// <summary>
    /// اضافة موظف جديد
    /// </summary>
    /// <param name="EmpName"></param>
    /// <param name="EmpEmail"></param>
    /// <param name="EmpDepartment"></param>
    /// <param name="EmpJobCode"></param>
    /// <param name="EmpJobTitle"></param>
    /// <param name="EmpDegree"></param>
    /// <param name="EmpImg"></param>
    /// <param name="EmpPassword"></param>
    /// <param name="ApprovPermission"></param>
    /// <param name="SystemAdmin"></param>
    /// <returns></returns>
    public int NewEmployee(int Section, string EmpName, string EmpEmail, int EmpDepartment, string EmpJobCode, string EmpJobTitle, string EmpImg, string EmpPassword, bool ApprovPermission, bool SystemAdmin, bool Reciv)
    {
        try
        {
            int Done = 0;
            SqlCommand CMD = new SqlCommand();
            CMD.Connection = Conn;
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.CommandText = "NewEmployee";
            ConOpen();
            CMD.Parameters.AddWithValue("@Section", Section);
            CMD.Parameters.AddWithValue("@EmpName", EmpName);
            CMD.Parameters.AddWithValue("@EmpEmail", EmpEmail);
            if (EmpDepartment == 0) { CMD.Parameters.AddWithValue("@EmpDepartment", DBNull.Value); }
            else
            {
                CMD.Parameters.AddWithValue("@EmpDepartment", EmpDepartment);
            }
            CMD.Parameters.AddWithValue("@EmpJobCode", EmpJobCode);
            CMD.Parameters.AddWithValue("@EmpJobTitle", EmpJobTitle);
            CMD.Parameters.AddWithValue("@EmpImg", EmpImg);
            CMD.Parameters.AddWithValue("@EmpPassword", EmpPassword);
            CMD.Parameters.AddWithValue("@ApprovPermission", ApprovPermission);
            CMD.Parameters.AddWithValue("@SystemAdmin", SystemAdmin);
            CMD.Parameters.AddWithValue("@Reciv", Reciv);

            Done = Convert.ToInt32(CMD.ExecuteScalar());

            ConClose();
            return Done;
        }
        catch { return 0; }

    }

    //=========================================
    public int NewGover(string EmpName, string EmpEmail, string EmpJobCode, string EmpPassword)
    {
        try
        {
            int Done = 0;
            SqlCommand CMD = new SqlCommand();
            CMD.Connection = Conn;
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.CommandText = "NewGover";
            ConOpen();

            CMD.Parameters.AddWithValue("@EmpName", EmpName);
            CMD.Parameters.AddWithValue("@EmpEmail", EmpEmail);

            CMD.Parameters.AddWithValue("@EmpJobCode", EmpJobCode);

            CMD.Parameters.AddWithValue("@EmpPassword", EmpPassword);

            Done = Convert.ToInt32(CMD.ExecuteScalar());

            ConClose();
            return Done;
        }
        catch { return 0; }

    }
    //=========================================
    public int UpdateGover(string EmpName, string EmpEmail, string EmpJobCode, string EmpPassword, int EmpID)
    {
        try
        {
            int Done = 0;
            SqlCommand CMD = new SqlCommand();
            CMD.Connection = Conn;
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.CommandText = "UpdateGover";
            ConOpen();

            CMD.Parameters.AddWithValue("@EmpName", EmpName);
            CMD.Parameters.AddWithValue("@EmpEmail", EmpEmail);

            CMD.Parameters.AddWithValue("@EmpJobCode", EmpJobCode);

            CMD.Parameters.AddWithValue("@EmpPassword", EmpPassword);
            CMD.Parameters.AddWithValue("@EmpID", EmpID);

            Done = Convert.ToInt32(CMD.ExecuteScalar());

            ConClose();
            return Done;
        }
        catch { return 0; }

    }

    //==========================================
    /// <summary>
    /// Adding Administration (اداره جديده)
    /// </summary>
    /// <param name="AdmName"></param>
    /// <returns></returns>
    public int NewAdministration(string AdmName, int Section)
    {
        try
        {
            int Done = 0;
            SqlCommand CMD = new SqlCommand();
            CMD.Connection = Conn;
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.CommandText = "NewAdministration";
            ConOpen();

            CMD.Parameters.AddWithValue("@AdmName", AdmName);
            CMD.Parameters.AddWithValue("@Section", Section);


            Done = Convert.ToInt32(CMD.ExecuteScalar());

            ConClose();
            return Done;
        }
        catch { return 0; }

    }
    //==============================================



    public int NewMainReports(int MainRYear, int MainRSector, int MainRDepart, string MainRFile, string MainRName)
    {
        try
        {
            int Done = 0;
            SqlCommand CMD = new SqlCommand();
            CMD.Connection = Conn;
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.CommandText = "NewMainReports";
            ConOpen();

            CMD.Parameters.AddWithValue("@MainRYear", MainRYear);
            CMD.Parameters.AddWithValue("@MainRSector", MainRSector);
            CMD.Parameters.AddWithValue("@MainRDepart", MainRDepart);
            CMD.Parameters.AddWithValue("@MainRFile", MainRFile);
            CMD.Parameters.AddWithValue("@MainRName", MainRName);

            Done = Convert.ToInt32(CMD.ExecuteScalar());

            ConClose();
            return Done;
        }
        catch { return 0; }

    }
    //=====================

    public int UpdateMainReports(int MainRYear, int MainRSector, int MainRDepart, string MainRFile, string MainRName, Boolean FileUPD, int ID)
    {
        try
        {
            int Done = 0;
            SqlCommand CMD = new SqlCommand();
            CMD.Connection = Conn;
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.CommandText = "UpdateMainReports";
            ConOpen();

            CMD.Parameters.AddWithValue("@MainRYear", MainRYear);
            CMD.Parameters.AddWithValue("@MainRSector", MainRSector);
            CMD.Parameters.AddWithValue("@MainRDepart", MainRDepart);
            CMD.Parameters.AddWithValue("@MainRFile", MainRFile);
            CMD.Parameters.AddWithValue("@MainRName", MainRName);
            CMD.Parameters.AddWithValue("@FileUPD", FileUPD);
            CMD.Parameters.AddWithValue("@ID", ID);

            Done = Convert.ToInt32(CMD.ExecuteScalar());

            ConClose();
            return Done;
        }
        catch { return 0; }

    }

    //===============

    public int NewAdminFiles(int Admin, int Section, string FPath, string FName)
    {
        try
        {
            int Done = 0;
            SqlCommand CMD = new SqlCommand();
            CMD.Connection = Conn;
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.CommandText = "NewAdminFiles";
            ConOpen();

            CMD.Parameters.AddWithValue("@Admin", Admin);
            CMD.Parameters.AddWithValue("@Section", Section);
            CMD.Parameters.AddWithValue("@FPath", FPath);
            CMD.Parameters.AddWithValue("@FName", FName);

            Done = Convert.ToInt32(CMD.ExecuteScalar());

            ConClose();
            return Done;
        }
        catch { return 0; }

    }
    //==============================================
    public int NewAttachComment(int ConfirmID, string FPath, string FName)
    {
        try
        {
            int Done = 0;
            SqlCommand CMD = new SqlCommand();
            CMD.Connection = Conn;
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.CommandText = "NewAttachComment";
            ConOpen();

            CMD.Parameters.AddWithValue("@ConfirmID", ConfirmID);
            CMD.Parameters.AddWithValue("@FPath", FPath);
            CMD.Parameters.AddWithValue("@FName", FName);

            Done = Convert.ToInt32(CMD.ExecuteScalar());

            ConClose();
            return Done;
        }
        catch { return 0; }

    }
    //==============================================
    public int NewAttachCommentNote(int ConfirmID, string FPath, string FName)
    {
        try
        {
            int Done = 0;
            SqlCommand CMD = new SqlCommand();
            CMD.Connection = Conn;
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.CommandText = "NewAttachCommentNote";
            ConOpen();

            CMD.Parameters.AddWithValue("@ConfirmID", ConfirmID);
            CMD.Parameters.AddWithValue("@FPath", FPath);
            CMD.Parameters.AddWithValue("@FName", FName);

            Done = Convert.ToInt32(CMD.ExecuteScalar());

            ConClose();
            return Done;
        }
        catch { return 0; }

    }
    //==============================================
    public int NewAttachCommentReport(int ConfirmID, string FPath, string FName)
    {
        try
        {
            int Done = 0;
            SqlCommand CMD = new SqlCommand();
            CMD.Connection = Conn;
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.CommandText = "NewAttachCommentReport";
            ConOpen();

            CMD.Parameters.AddWithValue("@ConfirmID", ConfirmID);
            CMD.Parameters.AddWithValue("@FPath", FPath);
            CMD.Parameters.AddWithValue("@FName", FName);

            Done = Convert.ToInt32(CMD.ExecuteScalar());

            ConClose();
            return Done;
        }
        catch { return 0; }

    }
    //==============================================

    public int NewAttachNote(int Note, string FPath, string FName)
    {
        try
        {
            int Done = 0;
            SqlCommand CMD = new SqlCommand();
            CMD.Connection = Conn;
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.CommandText = "NewAttachNote";
            ConOpen();

            CMD.Parameters.AddWithValue("@Note", Note);
            CMD.Parameters.AddWithValue("@FPath", FPath);
            CMD.Parameters.AddWithValue("@FName", FName);

            Done = Convert.ToInt32(CMD.ExecuteScalar());

            ConClose();
            return Done;
        }
        catch { return 0; }

    }
    //==============================================

    public int NewAttach(int Report, string FPath, string FName)
    {
        try
        {
            int Done = 0;
            SqlCommand CMD = new SqlCommand();
            CMD.Connection = Conn;
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.CommandText = "NewAttach";
            ConOpen();

            CMD.Parameters.AddWithValue("@Report", Report);
            CMD.Parameters.AddWithValue("@FPath", FPath);
            CMD.Parameters.AddWithValue("@FName", FName);
            Done = Convert.ToInt32(CMD.ExecuteScalar());

            ConClose();
            return Done;
        }
        catch { return 0; }

    }
    //==============================================
    public int UpdatePlan(string YearName, int ID)
    {
        try
        {
            int Done = 0;
            SqlCommand CMD = new SqlCommand();
            CMD.Connection = Conn;
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.CommandText = "UpdatePlan";
            ConOpen();

            CMD.Parameters.AddWithValue("@YearName", YearName);
            CMD.Parameters.AddWithValue("@ID", ID);

            Done = Convert.ToInt32(CMD.ExecuteScalar());

            ConClose();
            return Done;
        }
        catch { return 0; }

    }
    //==============================================
    public int NewPlan(string YearName)
    {
        try
        {
            int Done = 0;
            SqlCommand CMD = new SqlCommand();
            CMD.Connection = Conn;
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.CommandText = "NewPlan";
            ConOpen();

            CMD.Parameters.AddWithValue("@YearName", YearName);

            Done = Convert.ToInt32(CMD.ExecuteScalar());

            ConClose();
            return Done;
        }
        catch { return 0; }

    }
    //==============================================
    public int NewPlansSections(int PlanID, int AdminID, int SectonID)
    {
        try
        {
            int Done = 0;
            SqlCommand CMD = new SqlCommand();
            CMD.Connection = Conn;
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.CommandText = "NewPlansSections";
            ConOpen();
            CMD.Parameters.AddWithValue("@PlanID", PlanID);
            CMD.Parameters.AddWithValue("@AdminID", AdminID);
            CMD.Parameters.AddWithValue("@SectonID", SectonID);

            Done = Convert.ToInt32(CMD.ExecuteScalar());

            ConClose();
            return Done;
        }
        catch { return 0; }

    }
    //==============================================

    //==============================================
    /// <summary>
    /// 
    /// </summary>
    /// <param name="SectionName"></param>
    /// <returns></returns>
    public int NewSection(string SectionName)
    {
        try
        {
            int Done = 0;
            SqlCommand CMD = new SqlCommand();
            CMD.Connection = Conn;
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.CommandText = "NewSection";
            ConOpen();

            CMD.Parameters.AddWithValue("@SectionName", SectionName);

            Done = Convert.ToInt32(CMD.ExecuteScalar());

            ConClose();
            return Done;
        }
        catch { return 0; }

    }
    //==============================================
    public int UpdateSection(string SectionName, int SectionID)
    {
        try
        {
            int Done = 0;
            SqlCommand CMD = new SqlCommand();
            CMD.Connection = Conn;
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.CommandText = "UpdateSection";
            ConOpen();

            CMD.Parameters.AddWithValue("@SectionName", SectionName);
            CMD.Parameters.AddWithValue("@SectionID", SectionID);

            Done = Convert.ToInt32(CMD.ExecuteScalar());

            ConClose();
            return Done;
        }
        catch { return 0; }

    }

    public int UpdateReportNote(int NoteEmployee, string NoteText, string NoteFrom, int Importance, int NoteStatus, bool NoteRepeat, int NoteID)
    {
        try
        {
            int Done = 0;
            SqlCommand CMD = new SqlCommand();
            CMD.Connection = Conn;
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.CommandText = "UpdateReportNote";
            ConOpen();

            CMD.Parameters.AddWithValue("@NoteEmployee", NoteEmployee);
            CMD.Parameters.AddWithValue("@NoteText", NoteText);

            CMD.Parameters.AddWithValue("@NoteFrom", NoteFrom);


            CMD.Parameters.AddWithValue("@Importance", Importance);

            CMD.Parameters.AddWithValue("@NoteStatus", NoteStatus);
            CMD.Parameters.AddWithValue("@NoteRepeat", NoteRepeat);
            CMD.Parameters.AddWithValue("@NoteID", NoteID);
            Done = Convert.ToInt32(CMD.ExecuteScalar());

            ConClose();
            return Done;
        }
        catch { return 0; }

    }
    //=========================================


    public int UpdateReportNoteNew(int NoteEmployee, string NoteText, string NoteFrom, int Importance, int NoteStatus, bool NoteRepeat, int NoteID, string AdminCorrect)
    {
        try
        {
            int Done = 0;
            SqlCommand CMD = new SqlCommand();
            CMD.Connection = Conn;
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.CommandText = "UpdateReportNoteNew";
            ConOpen();

            CMD.Parameters.AddWithValue("@NoteEmployee", NoteEmployee);
            CMD.Parameters.AddWithValue("@NoteText", NoteText);

            CMD.Parameters.AddWithValue("@NoteFrom", NoteFrom);


            CMD.Parameters.AddWithValue("@Importance", Importance);

            CMD.Parameters.AddWithValue("@NoteStatus", NoteStatus);
            CMD.Parameters.AddWithValue("@NoteRepeat", NoteRepeat);
            CMD.Parameters.AddWithValue("@NoteID", NoteID);
            CMD.Parameters.AddWithValue("@AdminCorrect", AdminCorrect);
            Done = Convert.ToInt32(CMD.ExecuteScalar());

            ConClose();
            return Done;
        }
        catch { return 0; }

    }

    //==============================================
    /// <summary>
    /// 
    /// </summary>
    /// <param name="NoteEmployee"></param>
    /// <param name="NoteText"></param>
    /// <param name="NoteFrom"></param>
    /// <param name="NoteTo"></param>
    /// <param name="Importance"></param>
    /// <param name="NoteStatus"></param>
    /// <param name="NoteRepeat"></param>
    /// <param name="RepID"></param>
    /// <returns></returns>
    public int NewReportNote(int NoteEmployee, string NoteText, string NoteFrom, int Importance, int NoteStatus, bool NoteRepeat, int RepID)
    {
        try
        {
            int Done = 0;
            SqlCommand CMD = new SqlCommand();
            CMD.Connection = Conn;
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.CommandText = "NewReportNote";
            ConOpen();

            CMD.Parameters.AddWithValue("@NoteEmployee", NoteEmployee);
            CMD.Parameters.AddWithValue("@NoteText", NoteText);

            CMD.Parameters.AddWithValue("@NoteFrom", NoteFrom);

            CMD.Parameters.AddWithValue("@Importance", Importance);

            CMD.Parameters.AddWithValue("@NoteStatus", NoteStatus);
            CMD.Parameters.AddWithValue("@NoteRepeat", NoteRepeat);
            CMD.Parameters.AddWithValue("@RepID", RepID);
            Done = Convert.ToInt32(CMD.ExecuteScalar());

            ConClose();
            return Done;
        }
        catch { return 0; }

    }
    //=========================================



    public int NewReportNoteNew(int NoteEmployee, string NoteText, string NoteFrom, int Importance, int NoteStatus, bool NoteRepeat, int RepID, string AdminCorrect)
    {
        try
        {
            int Done = 0;
            SqlCommand CMD = new SqlCommand();
            CMD.Connection = Conn;
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.CommandText = "NewReportNoteNew";
            ConOpen();

            CMD.Parameters.AddWithValue("@NoteEmployee", NoteEmployee);
            CMD.Parameters.AddWithValue("@NoteText", NoteText);

            CMD.Parameters.AddWithValue("@NoteFrom", NoteFrom);

            CMD.Parameters.AddWithValue("@Importance", Importance);

            CMD.Parameters.AddWithValue("@NoteStatus", NoteStatus);
            CMD.Parameters.AddWithValue("@NoteRepeat", NoteRepeat);
            CMD.Parameters.AddWithValue("@RepID", RepID);
            CMD.Parameters.AddWithValue("@AdminCorrect", AdminCorrect);
            Done = Convert.ToInt32(CMD.ExecuteScalar());

            ConClose();
            return Done;
        }
        catch { return 0; }

    }

    //============================================
    public int NewTempReportNote(int NoteEmployee, string NoteText, string NoteFrom, int Importance, int NoteStatus, bool NoteRepeat, int RepID, string AdminCorrect)
    {
        try
        {
            int Done = 0;
            SqlCommand CMD = new SqlCommand();
            CMD.Connection = Conn;
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.CommandText = "NewTempReportNote";
            ConOpen();

            CMD.Parameters.AddWithValue("@NoteEmployee", NoteEmployee);
            CMD.Parameters.AddWithValue("@NoteText", NoteText);

            CMD.Parameters.AddWithValue("@NoteFrom", NoteFrom);


            CMD.Parameters.AddWithValue("@Importance", Importance);

            CMD.Parameters.AddWithValue("@NoteStatus", NoteStatus);
            CMD.Parameters.AddWithValue("@NoteRepeat", NoteRepeat);
            CMD.Parameters.AddWithValue("@RepID", RepID);
            CMD.Parameters.AddWithValue("@AdminCorrect", AdminCorrect);
            Done = Convert.ToInt32(CMD.ExecuteScalar());

            ConClose();
            return Done;
        }
        catch(Exception ex) { var aa = ex.InnerException; return 0; }

    }
    //=========================================
    public int ActiveTempReportNote(int NoteEmployee, string NoteText, string NoteFrom, int Importance, int NoteStatus, bool NoteRepeat, int RepID, int Note)
    {
        try
        {
            int Done = 0;
            SqlCommand CMD = new SqlCommand();
            CMD.Connection = Conn;
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.CommandText = "ActiveTempReportNote";
            ConOpen();

            CMD.Parameters.AddWithValue("@NoteEmployee", NoteEmployee);
            CMD.Parameters.AddWithValue("@NoteText", NoteText);

            CMD.Parameters.AddWithValue("@NoteFrom", NoteFrom);

            CMD.Parameters.AddWithValue("@Importance", Importance);

            CMD.Parameters.AddWithValue("@NoteStatus", NoteStatus);
            CMD.Parameters.AddWithValue("@NoteRepeat", NoteRepeat);
            CMD.Parameters.AddWithValue("@RepID", RepID);
            CMD.Parameters.AddWithValue("@Note", Note);
            Done = Convert.ToInt32(CMD.ExecuteScalar());

            ConClose();
            return Done;
        }
        catch { return 0; }

    }
    //=========================================


    /// <summary>
    /// 
    /// </summary>
    /// <param name="RepEmployee"></param>
    /// <param name="RepText"></param>
    /// <param name="RepSection"></param>
    /// <param name="RepAdms"></param>
    /// <param name="RepFrom"></param>

    /// <param name="Importance"></param>
    /// <param name="RepStatus"></param>
    /// <param name="RepRepeat"></param>
    /// <param name="RepID"></param>
    /// <returns></returns>
    public int UpdateReport(int RepEmployee, string RepText, int RepSection, int RepAdms, string RepFrom, int Importance, int RepStatus, Boolean RepRepeat, int RepID, int RepPlan, string RepTitle, string RepImpText, string RepDate)
    {
        try
        {
            int Done = 0;
            SqlCommand CMD = new SqlCommand();
            CMD.Connection = Conn;
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.CommandText = "UpdateReport";
            ConOpen();

            CMD.Parameters.AddWithValue("@RepEmployee", RepEmployee);
            CMD.Parameters.AddWithValue("@RepText", RepText);
            CMD.Parameters.AddWithValue("@RepTitle", RepTitle);
            CMD.Parameters.AddWithValue("@RepSection", RepSection);
            CMD.Parameters.AddWithValue("@RepImpText", RepImpText);
            if (RepAdms == 0)
            {
                CMD.Parameters.AddWithValue("@RepAdms", DBNull.Value);
            }
            else
            {
                CMD.Parameters.AddWithValue("@RepAdms", RepAdms);
            }
            CMD.Parameters.AddWithValue("@RepFrom", RepFrom);


            CMD.Parameters.AddWithValue("@Importance", Importance);

            CMD.Parameters.AddWithValue("@RepStatus", RepStatus);
            CMD.Parameters.AddWithValue("@RepRepeat", RepRepeat);
            CMD.Parameters.AddWithValue("@RepID", RepID);
            CMD.Parameters.AddWithValue("@RepPlan", RepPlan);
            CMD.Parameters.AddWithValue("@RepDate", RepDate);

            Done = Convert.ToInt32(CMD.ExecuteScalar());

            ConClose();
            return Done;
        }
        catch { return 0; }

    }
    //=========================================


    /// <summary>
    /// NewTempReport
    /// </summary>
    /// <param name="RepEmployee"></param>
    /// <param name="RepText"></param>
    /// <param name="RepSection"></param>
    /// <param name="RepAdms"></param>
    /// <param name="RepFrom"></param>

    /// <param name="Importance"></param>
    /// <param name="RepStatus"></param>
    /// <param name="RepRepeat"></param>
    /// <returns></returns>
    public int NewTempReport(int RepEmployee, string RepText, int RepSection, int RepAdms, string RepFrom, int Importance, int RepStatus, Boolean RepRepeat, string TempReport, int RepPlan, string RepTitle, string RepImpText, string RepDate)
    {
        try
        {
            int Done = 0;
            SqlCommand CMD = new SqlCommand();
            CMD.Connection = Conn;
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.CommandText = "NewTempReport";
            ConOpen();
            CMD.Parameters.AddWithValue("@TempReport", TempReport);
            CMD.Parameters.AddWithValue("@RepEmployee", RepEmployee);
            CMD.Parameters.AddWithValue("@RepText", RepText);
            CMD.Parameters.AddWithValue("@RepPlan", RepPlan);
            CMD.Parameters.AddWithValue("@RepSection", RepSection);
            CMD.Parameters.AddWithValue("@RepTitle", RepTitle);
            CMD.Parameters.AddWithValue("@RepImpText", RepImpText);

            if (RepAdms == 0)
            {
                CMD.Parameters.AddWithValue("@RepAdms", DBNull.Value);
            }
            else
            {
                CMD.Parameters.AddWithValue("@RepAdms", RepAdms);
            }
            CMD.Parameters.AddWithValue("@RepFrom", RepFrom);


            CMD.Parameters.AddWithValue("@Importance", Importance);

            CMD.Parameters.AddWithValue("@RepStatus", RepStatus);
            CMD.Parameters.AddWithValue("@RepRepeat", RepRepeat);
            CMD.Parameters.AddWithValue("@RepDate", RepDate);
            Done = Convert.ToInt32(CMD.ExecuteScalar());

            ConClose();
            return Done;
        }
        catch { return 0; }

    }
    //=========================================



    /// <summary>
    /// 
    /// </summary>
    /// <param name="RepEmployee"></param>
    /// <param name="RepText"></param>
    /// <param name="RepSection"></param>
    /// <param name="RepAdms"></param>
    /// <param name="RepFrom"></param>

    /// <param name="Importance"></param>
    /// <param name="RepStatus"></param>
    /// <param name="RepRepeat"></param>
    /// <returns></returns>
    public int NewReport(int RepEmployee, string RepText, int RepSection, int RepAdms, string RepFrom, int Importance, int RepStatus, Boolean RepRepeat, int RepPlan, string RepTitle, string RepImpText)
    {
        try
        {
            int Done = 0;
            SqlCommand CMD = new SqlCommand();
            CMD.Connection = Conn;
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.CommandText = "NewReport";
            ConOpen();

            CMD.Parameters.AddWithValue("@RepEmployee", RepEmployee);
            CMD.Parameters.AddWithValue("@RepText", RepText);
            CMD.Parameters.AddWithValue("@RepTitle", RepTitle);
            CMD.Parameters.AddWithValue("@RepImpText", RepImpText);
            if (RepSection == 0)
            {
                CMD.Parameters.AddWithValue("@RepSection", DBNull.Value);

            }
            else
            {
                CMD.Parameters.AddWithValue("@RepSection", RepSection);

            }
            if (RepAdms == 0)
            {
                CMD.Parameters.AddWithValue("@RepAdms", DBNull.Value);
            }
            else
            {
                CMD.Parameters.AddWithValue("@RepAdms", RepAdms);
            }
            CMD.Parameters.AddWithValue("@RepFrom", RepFrom);

            if (Importance == 0)
            {
                CMD.Parameters.AddWithValue("@Importance", DBNull.Value);
            }
            else
            {
                CMD.Parameters.AddWithValue("@Importance", Importance);
            }

            if (RepStatus == 0)
            {
                CMD.Parameters.AddWithValue("@RepStatus", DBNull.Value);
            }
            else
            {
                CMD.Parameters.AddWithValue("@RepStatus", RepStatus);
            }

            CMD.Parameters.AddWithValue("@RepRepeat", RepRepeat);
            CMD.Parameters.AddWithValue("@RepPlan", RepPlan);

            Done = Convert.ToInt32(CMD.ExecuteScalar());

            ConClose();
            return Done;
        }
        catch { return 0; }

    }
    //=========================================
    /// <summary>
    /// Update Administration
    /// </summary>
    /// <param name="AdmName"></param>
    /// <param name="AdmID"></param>
    /// <returns></returns>
    public int UpdateAdministration(string AdmName, int AdmID, int Section)
    {
        try
        {
            int Done = 0;
            SqlCommand CMD = new SqlCommand();
            CMD.Connection = Conn;
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.CommandText = "UpdateAdministration";
            ConOpen();

            CMD.Parameters.AddWithValue("@AdmName", AdmName);
            CMD.Parameters.AddWithValue("@AdmID", AdmID);
            CMD.Parameters.AddWithValue("@Section", Section);


            Done = Convert.ToInt32(CMD.ExecuteScalar());

            ConClose();
            return Done;
        }
        catch { return 0; }

    }

    //=========================================

    public int Section(string SectionName, int SectionID)
    {
        try
        {
            int Done = 0;
            SqlCommand CMD = new SqlCommand();
            CMD.Connection = Conn;
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.CommandText = "UpdateSection";
            ConOpen();

            CMD.Parameters.AddWithValue("@SectionName", SectionName);
            CMD.Parameters.AddWithValue("@SectionID", SectionID);
            Done = Convert.ToInt32(CMD.ExecuteScalar());

            ConClose();
            return Done;
        }
        catch { return 0; }

    }

    //=========================================

    /// <summary>
    /// Update  android:textColor="#747d82" Data
    /// </summary>
    /// <param name="DepartName"></param>
    /// <param name="Administration"></param>
    /// <param name="DepartID"></param>
    /// <returns></returns>
    public int UpdateDepartment(string DepartName, int Administration, int DepartID)
    {
        try
        {
            int Done = 0;
            SqlCommand CMD = new SqlCommand();
            CMD.Connection = Conn;
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.CommandText = "UpdateDepartment";
            ConOpen();

            CMD.Parameters.AddWithValue("@DepartName", DepartName);
            CMD.Parameters.AddWithValue("@Administration", Administration);
            CMD.Parameters.AddWithValue("@DepartID", DepartID);
            Done = Convert.ToInt32(CMD.ExecuteScalar());

            ConClose();
            return Done;
        }
        catch { return 0; }

    }

    //=========================================

    /// <summary>
    /// Add New  android:textColor="#747d82"
    /// </summary>
    /// <param name="DepartName"></param>
    /// <param name="Administration"></param>
    /// <returns></returns>
    public int NewDepartment(string DepartName, int Administration)
    {
        try
        {
            int Done = 0;
            SqlCommand CMD = new SqlCommand();
            CMD.Connection = Conn;
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.CommandText = "NewDepartment";
            ConOpen();
            CMD.Parameters.AddWithValue("@DepartName", DepartName);
            CMD.Parameters.AddWithValue("@Administration", Administration);

            Done = Convert.ToInt32(CMD.ExecuteScalar());

            ConClose();
            return Done;
        }
        catch { return 0; }

    }

    //=========================================
    /// <summary>
    /// Send Emails
    /// </summary>
    /// <param name="MailTo"></param>
    /// <param name="Subject"></param>
    /// <param name="Body"></param>

    public void OurMails(string Subject, string Body, int SectionHead, int Admin, bool Reply)
    {
        try
        {

            string MainBodyPart01 = System.IO.File.ReadAllText(System.Web.HttpContext.Current.Server.MapPath("App_Code/MailbodyPart1.txt"));
            string MainBodyPart02 = System.IO.File.ReadAllText(System.Web.HttpContext.Current.Server.MapPath("App_Code/MailbodyPart2.txt"));

            MailMessage objeto_mail = new MailMessage();
            SmtpClient client = new SmtpClient();
            client.Port = 26;
            client.Host = "*************";
            client.Timeout = 10000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;

            objeto_mail.From = new MailAddress("Do-Not-Reply@mail.com");

            if (Reply == true) // Reply
            {
                DataSet Ds = GetDataSet("GetApprovingEmails");
                if (Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                {

                    foreach (DataRow Row in Ds.Tables[0].Rows)
                    {
                        objeto_mail.To.Add(new MailAddress(Convert.ToString(Row["EmpEmail"])));

                    }
                }

            }
            else
            {

                if (SectionHead != 0) // Report or Note
                {
                    DataSet DsSection = GetDataSetByID("GetSectionManagers", SectionHead);

                    if (DsSection.Tables.Count > 0 && DsSection.Tables[0].Rows.Count > 0)
                    {

                        foreach (DataRow SectionRow in DsSection.Tables[0].Rows)
                        {

                            objeto_mail.To.Add(new MailAddress(Convert.ToString(SectionRow["EmpEmail"])));
                        }
                    }
                    if (Admin == -1) // Report or Note
                    {

                        DataSet DsAllAdmins = GetDataSetByID("GetAllAdminsMail", SectionHead);
                        if (DsAllAdmins.Tables.Count > 0 && DsAllAdmins.Tables[0].Rows.Count > 0)
                        {

                            foreach (DataRow RowAllAdmins in DsAllAdmins.Tables[0].Rows)
                            {
                                objeto_mail.To.Add(new MailAddress(Convert.ToString(RowAllAdmins["EmpEmail"])));

                            }
                        }
                    }

                }

                if (Admin != 0 && Admin != -1) // Report or Note
                {

                    DataSet DsAll = GetDataSetByID("GetAdminManagers", Admin);
                    if (DsAll.Tables.Count > 0 && DsAll.Tables[0].Rows.Count > 0)
                    {

                        foreach (DataRow RowAll in DsAll.Tables[0].Rows)
                        {
                            objeto_mail.To.Add(new MailAddress(Convert.ToString(RowAll["EmpEmail"])));

                        }
                    }
                }




            }
            objeto_mail.CC.Add("afaifi@mail.com");



            objeto_mail.Subject = Subject;
            objeto_mail.IsBodyHtml = true;
            objeto_mail.Body = MainBodyPart01.Replace("URLS", System.Web.HttpContext.Current.Server.MapPath("assets")) + Body + MainBodyPart02.Replace("URLS", System.Web.HttpContext.Current.Server.MapPath("assets"));
            client.Send(objeto_mail);




            objeto_mail.Dispose();


        }
        catch { }

    }


    public string GetMailString01()
    {
        try
        {
            string MainBodyPart01 = System.IO.File.ReadAllText(System.Web.HttpContext.Current.Server.MapPath("App_Code/MailBody01.txt"));
            return MainBodyPart01;
        }
        catch
        {
            return "";
        }
    }

    public string GetMailString02()
    {
        try
        {
            string MainBodyPart02 = System.IO.File.ReadAllText(System.Web.HttpContext.Current.Server.MapPath("App_Code/MailBody02.txt"));
            return MainBodyPart02;
        }
        catch
        {
            return "";
        }
    }

    public void ReportMails(string Subject, string Body, List<string> Section, List<string> Departs)
    {
        try
        {

            string MainBodyPart01 = System.IO.File.ReadAllText(System.Web.HttpContext.Current.Server.MapPath("App_Code/MailbodyPart1.txt"));
            string MainBodyPart02 = System.IO.File.ReadAllText(System.Web.HttpContext.Current.Server.MapPath("App_Code/MailbodyPart2.txt"));

            MailMessage objeto_mail = new MailMessage();
            SmtpClient client = new SmtpClient();
            client.Port = 26;
            client.Host = "*************";
            client.Timeout = 10000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;

            objeto_mail.From = new MailAddress("Do-Not-Reply@mail.com");




            foreach (string Sectionmail in Section)

            {

                
                        objeto_mail.To.Add(new MailAddress(Sectionmail));

                    
            }
            foreach (string Departmail in Departs)

            {


                objeto_mail.To.Add(new MailAddress(Departmail));


            }




            objeto_mail.CC.Add("afaifi@mail.com");



            objeto_mail.Subject = Subject;
            objeto_mail.IsBodyHtml = true;
            objeto_mail.Body = MainBodyPart01 + Body + MainBodyPart02;
            client.Send(objeto_mail);




            objeto_mail.Dispose();


        }
        catch { }

    }


    //===========================================
    /// <summary>
    /// Update Employee data
    /// </summary>
    /// <param name="EmpName"></param>
    /// <param name="EmpEmail"></param>
    /// <param name="EmpDepartment"></param>
    /// <param name="EmpJobCode"></param>
    /// <param name="EmpJobTitle"></param>
    /// <param name="EmpDegree"></param>
    /// <param name="EmpImg"></param>
    /// <param name="EmpPassword"></param>
    /// <param name="ApprovPermission"></param>
    /// <param name="EmpID"></param>
    /// <param name="SystemAdmin"></param>
    /// <returns></returns>
    public int UpdateEmployee(int Section, string EmpName, string EmpEmail, int EmpDepartment, string EmpJobCode, string EmpJobTitle, string EmpImg, string EmpPassword, bool ApprovPermission, int EmpID, bool SystemAdmin, bool Reciv)
    {
        try
        {
            int Done = 0;
            SqlCommand CMD = new SqlCommand();
            CMD.Connection = Conn;
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.CommandText = "UpdateEmployee";
            ConOpen();
            CMD.Parameters.AddWithValue("@Section", Section);
            CMD.Parameters.AddWithValue("@EmpName", EmpName);
            CMD.Parameters.AddWithValue("@EmpEmail", EmpEmail);
            if (EmpDepartment == 0) { CMD.Parameters.AddWithValue("@EmpDepartment", DBNull.Value); }
            else
            {
                CMD.Parameters.AddWithValue("@EmpDepartment", EmpDepartment);
            }
            CMD.Parameters.AddWithValue("@EmpJobCode", EmpJobCode);
            CMD.Parameters.AddWithValue("@EmpJobTitle", EmpJobTitle);
            CMD.Parameters.AddWithValue("@EmpImg", EmpImg);
            CMD.Parameters.AddWithValue("@EmpPassword", EmpPassword);
            CMD.Parameters.AddWithValue("@ApprovPermission", ApprovPermission);
            CMD.Parameters.AddWithValue("@EmpID", EmpID);
            CMD.Parameters.AddWithValue("@SystemAdmin", SystemAdmin);
            CMD.Parameters.AddWithValue("@Reciv", Reciv);
            CMD.Parameters.AddWithValue("@GeneralAdmin", false);
            Done = Convert.ToInt32(CMD.ExecuteScalar());

            ConClose();
            return Done;
        }
        catch(Exception ex) { return 0; }

    }


    public static bool IsHtmlFragment(string value)
    {
        return Regex.IsMatch(value, @"</?(p|div)>");
    }
    public static string CleanHtmlBehaviour(string value)
    {
        value = Regex.Replace(value, "(<style.+?</style>)|(<script.+?</script>)", "", RegexOptions.IgnoreCase | RegexOptions.Singleline);

        return value;
    }


    public static string CleanHtmlComments(string value)
    {
        //Remove disallowed html tags.
        value = Regex.Replace(value, "<!--.+?-->", "", RegexOptions.IgnoreCase | RegexOptions.Singleline);

        return value;
    }


    public static string HtmlLinkAddNoFollow(string value)
    {
        return Regex.Replace(value, "<a[^>]+href=\"?'?(?!#[\\w-]+)([^'\">]+)\"?'?[^>]*>(.*?)</a>", "<a href=\"$1\" rel=\"nofollow\" target=\"_blank\">$2</a>", RegexOptions.IgnoreCase | RegexOptions.Compiled);
    }
    public string GetTextFromHTML(string value)
    {
        if (value != null)
        {
            value = CleanHtmlComments(value);
            value = CleanHtmlBehaviour(value);
            value = Regex.Replace(value, @"</[^>]+?>", " ");
            value = Regex.Replace(value, @"<[^>]+?>", "");
            value = Regex.Replace(value, @"&nbsp;", "");
            value = value.Trim().TrimStart().TrimEnd();
        }
        return value;
    }

}
