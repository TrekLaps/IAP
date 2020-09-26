using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.DataVisualization.Charting;
using System.Text;
using System.Data.OleDb;

public partial class PieDashboardAdmin : System.Web.UI.Page
{
    Operations Obj = new Operations();
    StringBuilder strImport = new StringBuilder();
    StringBuilder strStatByAdm = new StringBuilder();


    StringBuilder strStat = new StringBuilder();
    StringBuilder str = new StringBuilder();

    private void FillSectorChart()
    {
        if (Session["UData"] != null)
        {
            DataSet MyRecDataSet = (DataSet)Session["UData"];




            //RepData.DataSource = Obj.GetDataSetByID("GetSectionCounts", Convert.ToInt32(Request.QueryString["Reqq"]));
            //RepData.DataBind();


        }
    }

    protected void MainYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Fill dropdown Lists For Reports Sections تبعا للسنة
        if (MainYear.SelectedValue != "0")
        {
            Response.Redirect("PieDashboardAdmin.aspx?ReqY=" + MainYear.SelectedValue + "&Reqq=" + Request.QueryString["Reqq"]);

        }
        else
        {
            Response.Redirect("PieDashboardAdmin.aspx?ReqY=0&Reqq=" + Request.QueryString["Reqq"]);

        }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UData"] != null)
        {
            DataSet MyRecDataSet = (DataSet)Session["UData"];


            if (!IsPostBack)
            {
                Session["PostID"] = "1001";
                ViewState["PostID"] = Session["PostID"].ToString();


                if (Obj.ExecuteProcedureID("CheckAdminManger", Convert.ToInt32(MyRecDataSet.Tables[0].Rows[0]["EmpID"])) == 1)
                {
                    /// Log Data Start
                    Obj.ExecuteProcedureStringID("NewLogTable", Convert.ToInt32(MyRecDataSet.Tables[0].Rows[0]["EmpID"]), "View Notes and Recommendations Charts by Department manager permission");
                    /// Log Data End
                    HyperLink1.NavigateUrl = "ReportAdmAll.aspx";

                    MainYear.DataSource = Obj.GetDataSetByID("GetPlansByAdmin", Convert.ToInt32(MyRecDataSet.Tables[0].Rows[0]["AdmID"]));
                    MainYear.DataTextField = "YearName";
                    MainYear.DataValueField = "ID";

                    MainYear.DataBind();

                    if (Request.QueryString["ReqY"] != null)
                    {
                        MainYear.SelectedValue = Request.QueryString["ReqY"];

                        HyperLink1.NavigateUrl = "ReportAdmAll.aspx?S=" + MyRecDataSet.Tables[0].Rows[0]["Section"] + "&YQ=" + Request.QueryString["ReqY"];
                    }





                    if (Request.QueryString["Reqq"] != null)
                    {


                        NoRep.Visible = false;
                        if (Request.QueryString["ReqY"] == "0")
                        {
                            var Vall = Obj.ExecuteProcedureID("GetReportCountByAdmin", Convert.ToInt32(Request.QueryString["Reqq"]));
                            if (Vall != 0)
                            {
                                BindImportChart(Convert.ToInt32(Request.QueryString["Reqq"]));
                                BindStatChart(Convert.ToInt32(Request.QueryString["Reqq"]));
                                BindChart(Convert.ToInt32(Request.QueryString["Reqq"]));

                                DataSet ds = Obj.GetDataSetByID("GetCountsByAdmin", Convert.ToInt32(Request.QueryString["Reqq"]));
                                NoRep.Visible = false;

                                FillSectorChart();
                                RepTotals.DataSource = Obj.GetDataSetByID("GetRepAdminCounts", Convert.ToInt32(Request.QueryString["Reqq"]));
                                RepTotals.DataBind();

                                Repeater2.DataSource = ds;

                                Repeater2.DataBind();
                            }
                            else { NoRep.Visible = true; }
                        }

                        else if (Request.QueryString["ReqY"] != "0" && Request.QueryString["ReqY"] != null)
                        {
                            var Vall = Obj.GetReportCountByAdminPlan(Convert.ToInt32(Request.QueryString["Reqq"]), Convert.ToInt32(Request.QueryString["ReqY"]));
                            if (Vall != 0)
                            {
                                BindImportChartAdmin(Convert.ToInt32(Request.QueryString["Reqq"]), Convert.ToInt32(Request.QueryString["ReqY"]));
                                BindStatChartAdmin(Convert.ToInt32(Request.QueryString["Reqq"]), Convert.ToInt32(Request.QueryString["ReqY"]));
                                BindChartAdmin(Convert.ToInt32(Request.QueryString["Reqq"]), Convert.ToInt32(Request.QueryString["ReqY"]));

                                DataSet ds = Obj.GetDataSetBy2ID("GetAllSectionsChartPlanADM", Convert.ToInt32(Request.QueryString["Reqq"]), Convert.ToInt32(Request.QueryString["ReqY"]));
                                NoRep.Visible = false;

                                FillSectorChart();
                                RepTotals.DataSource = Obj.GetDataSetBy2ID("GetRepSectionAllPlansByAdm", Convert.ToInt32(Request.QueryString["Reqq"]), Convert.ToInt32(Request.QueryString["ReqY"]));
                                RepTotals.DataBind();

                                Repeater2.DataSource = ds;

                                Repeater2.DataBind();
                            }
                            else { NoRep.Visible = true; }
                        }




                    }
                    else
                    {

                        PrntView.Attributes.Remove("style");
                        PrntView.Style.Add("display", "none");

                        NoRep.Visible = true;
                    }


                }
                else
                {
                    Response.Redirect("NoPermissions.aspx");
                }
            }
            else
            {
                if (ViewState["PostID"].ToString() == Session["PostID"].ToString())
                {

                    Session["PostID"] = (Convert.ToInt16(Session["PostID"]) + 1).ToString();

                    ViewState["PostID"] = Session["PostID"].ToString();


                }
                else
                {
                    ViewState["PostID"] = Session["PostID"].ToString();

                    hidden.Value = "0";
                    Stat.Value = "0";

                }
                if (Stat.Value != "Non")
                {
                    LoadDataChart();
                }

                if (HiddenYear.Value != "0")
                {
                    MainYear.DataSource = Obj.GetDataSetByID("GetPlansByAdmin", Convert.ToInt32(Request.QueryString["Reqq"]));
                    MainYear.DataBind();
                }

            }
        }
    }


    private void LoadDataChart()
    {

        if (Session["UData"] != null)
        {
            DataSet MyRecDataSet = (DataSet)Session["UData"];

            RepImpData.DataSource = null;
            RepImpData.DataBind();

            int Stats = Convert.ToInt32(Stat.Value) - 1;

            if (Stats == -1)
            {
                Stats = 5;
            }
            else if (Stats == 0)
            {
                Stats = 4;
            }

            string Case = "";
            if (Convert.ToInt32(Stat.Value) == 1)
            {

                Case = "مستوى مخاطر الملاحظات التى لم يحن وقت تنفيذها";
            }
            else if (Convert.ToInt32(Stat.Value) == 3)
            {

                Case = "مستوى مخاطر الملاحظات المغلقة";
            }
            else if (Convert.ToInt32(Stat.Value) == 5)
            {

                Case = "مستوى مخاطر الملاحظات المتأخرة";
            }
            else if (Convert.ToInt32(Stat.Value) == 7)
            {

                Case = "مستوى مخاطر الملاحظات جارى التنفيذ";
            }
            else if (Convert.ToInt32(Stat.Value) == 9)
            {


                Case = "مستوى مخاطر الملاحظات المعالجة";
            }
                       


            LblTitle.InnerHtml = "<h3>" + Case + "</h3>";
            if (Request.QueryString["ReqY"] != "0" && Request.QueryString["ReqY"] != "" && Request.QueryString["ReqY"] != null)
            {
                hidden.Value = Obj.ExecuteProcedure3ID("GetChartAdmYearCounts", Convert.ToInt32(Request.QueryString["Reqq"]), Stats, Convert.ToInt32(Request.QueryString["ReqY"])).ToString();
            }
            else
            {
                hidden.Value = Obj.ExecuteProcedure2ID("GetChartAdmCounts", Convert.ToInt32(Request.QueryString["Reqq"]),Stats).ToString();

            }
            RepImpData.DataSource = Obj.GetChartAdminPlanStat(Convert.ToInt32(Request.QueryString["ReqY"]), Convert.ToInt32(Request.QueryString["Reqq"]), Stats);

            RepImpData.DataBind();
        }

    }
    private DataTable GetData(int Admin)
    {


        DataTable dt = new DataTable();

        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "GetCountsByAdmin";
        cmd.Parameters.AddWithValue("@ID", Admin);
        cmd.Connection = Obj.Conn;


        SqlDataAdapter adp = new SqlDataAdapter();
        adp.SelectCommand = cmd;

        adp.Fill(dt);

        return dt;


    }

    private DataTable GetDataPlan(int Plan, int Admin)
    {


        DataTable dt = new DataTable();

        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "GetAllAdminsByAdmPlan";
        cmd.Parameters.AddWithValue("@ID", Plan);
        cmd.Parameters.AddWithValue("@ID2", Admin);
        cmd.Connection = Obj.Conn;


        SqlDataAdapter adp = new SqlDataAdapter();
        adp.SelectCommand = cmd;

        adp.Fill(dt);

        return dt;


    }
    private void BindChartAdmin(int Admin, int Plan)
    {

        DataTable dt = new DataTable();

        try
        {

            dt = GetDataPlan(Plan, Admin);



            str.Append(@"<script type=*text/javascript*> google.load( *visualization*, *1*, {packages:[*corechart*]});

            google.setOnLoadCallback(drawChart);

            function drawChart() {

            var data = new google.visualization.DataTable();

            data.addColumn('string', 'الإدارة العليا');
            data.addColumn('number', 'لم يحن وقت تنفيذها'); data.addColumn({'type': 'string', 'role': 'tooltip'});
            data.addColumn('number', 'مغلقة');  data.addColumn({'type': 'string', 'role': 'tooltip'});
            data.addColumn('number', 'متأخرة');  data.addColumn({'type': 'string', 'role': 'tooltip'});
            data.addColumn('number', 'جارى التنفيذ');  data.addColumn({'type': 'string', 'role': 'tooltip'});
            data.addColumn('number', 'معالجة'); data.addColumn({'type': 'string', 'role': 'tooltip'});
 data.addRows([");

            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                var Status3 = "";
                var Status3Txt = "";

                if (dt.Rows[i]["Status3"].ToString() == "0")
                {
                    Status3 = null;
                    Status3Txt = null;
                }
                else
                {

                    if (Convert.ToDouble(dt.Rows[i]["Status3"]) < 4)
                    {
                        Status3 = Convert.ToString(Convert.ToDouble(dt.Rows[i]["Status3"]) * 5);
                    }
                    else
                    {
                        Status3 = Convert.ToString(Convert.ToDouble(dt.Rows[i]["Status3"]) * 2);
                    }
                    Status3Txt = "[" + dt.Rows[i]["Status3"].ToString() + "] " + Math.Round(((Convert.ToDouble(dt.Rows[i]["Status3"]) / Convert.ToDouble(dt.Rows[i]["TotalCount"])) * 100), 1).ToString();
                }

                var Status2 = "";
                var Status2Txt = "";

                if (dt.Rows[i]["Status2"].ToString() == "0")
                {
                    Status2 = null;
                    Status2Txt = null;
                }
                else
                {

                    if (Convert.ToDouble(dt.Rows[i]["Status2"]) < 4)
                    {
                        Status2 = Convert.ToString(Convert.ToDouble(dt.Rows[i]["Status2"]) * 5);
                    }
                    else
                    {
                        Status2 = Convert.ToString(Convert.ToDouble(dt.Rows[i]["Status2"]) * 2);
                    }
                    Status2Txt = "[" + dt.Rows[i]["Status2"].ToString() + "] " + Math.Round(((Convert.ToDouble(dt.Rows[i]["Status2"]) / Convert.ToDouble(dt.Rows[i]["TotalCount"])) * 100), 1).ToString();
                }

                var Status1 = "";
                var Status1Txt = "";

                if (dt.Rows[i]["Status1"].ToString() == "0")
                {
                    Status1 = null;
                    Status1Txt = null;
                }
                else
                {

                    if (Convert.ToDouble(dt.Rows[i]["Status1"]) < 4)
                    {
                        Status1 = Convert.ToString(Convert.ToDouble(dt.Rows[i]["Status1"]) * 5);
                    }
                    else
                    {
                        Status1 = Convert.ToString(Convert.ToDouble(dt.Rows[i]["Status1"]) * 2);
                    }
                    Status1Txt = "[" + dt.Rows[i]["Status1"].ToString() + "] " + Math.Round(((Convert.ToDouble(dt.Rows[i]["Status1"]) / Convert.ToDouble(dt.Rows[i]["TotalCount"])) * 100), 1).ToString();
                }

                var Status4 = "";
                var Status4Txt = "";
                if (dt.Rows[i]["Status4"].ToString() == "0")
                {
                    Status4 = null;
                    Status4Txt = null;
                }
                else
                {

                    if (Convert.ToDouble(dt.Rows[i]["Status4"]) < 4)
                    {
                        Status4 = Convert.ToString(Convert.ToDouble(dt.Rows[i]["Status4"]) * 5);
                    }
                    else
                    {
                        Status4 = Convert.ToString(Convert.ToDouble(dt.Rows[i]["Status4"]) * 2);
                    }
                    Status4Txt = "[" + dt.Rows[i]["Status4"].ToString() + "] " + Math.Round(((Convert.ToDouble(dt.Rows[i]["Status4"]) / Convert.ToDouble(dt.Rows[i]["TotalCount"])) * 100), 1).ToString();
                }

                var Status5 = "";
                var Status5Txt = "";
                if (dt.Rows[i]["Status5"].ToString() == "0")
                {
                    Status5 = null;
                    Status5Txt = null;
                }
                else
                {

                    if (Convert.ToDouble(dt.Rows[i]["Status5"]) < 4)
                    {
                        Status5 = Convert.ToString(Convert.ToDouble(dt.Rows[i]["Status5"]) * 5);
                    }
                    else
                    {
                        Status5 = Convert.ToString(Convert.ToDouble(dt.Rows[i]["Status5"]) * 2);
                    }
                    Status5Txt = "[" + dt.Rows[i]["Status5"].ToString() + "] " + Math.Round(((Convert.ToDouble(dt.Rows[i]["Status5"]) / Convert.ToDouble(dt.Rows[i]["TotalCount"])) * 100), 1).ToString();
                }

                str.Append(@"['" + dt.Rows[i]["AdmName"].ToString() + "', " + Status4 + ", '" + Status4Txt + "%" + "', " + Status5 + ",  '" + Status5Txt + "%" + "', " + Status1 + ",  '" + Status1Txt + "%" + "', " + Status2 + ",  '" + Status2Txt + "%" + "', " + Status3 + ",  '" + Status3Txt + "%" + "'],");
            }



            str.Append("]);");



            str.Append("var chart = new google.visualization.ColumnChart(document.getElementById('chart_div'));");
            str.Append("chart.draw(data,{isStacked:false, width:800, height:500,legend: { position: 'none' }, vAxis: {minValue: 4,viewWindow:{ min: 0},format: '0',textPosition: 'none' },colors: ['#93cdf3','#727aa2','#9C27B0','#FF9800','#4CAF50'], hAxis: {showTextEvery:1, slantedText:false}});");
            str.Append(@"google.visualization.events.addListener(chart, 'select', selectHandler);

  function selectHandler() {
                    var selectedItem = chart.getSelection()[0];
                    if (selectedItem) {
var selection = chart.getSelection();
var message = '';
for (var i = 0; i < selection.length; i++) {
var item = selection[i];
if (item.row != null && item.column != null) {
var str = data.getFormattedValue(item.row, item.column);
var category = data
.getValue(chart.getSelection()[0].row, 0)


message += '{row:' + item.row + ',column:' + item.column
+ '} = ' + str ;

Hidden(item.column,str,category);
 ");




            str.Append(@" 
}}
if (message == '') {
message = 'nothing';
}
                        var tooltip = document.getElementsByClassName('google-visualization-tooltip')[0];
                        tooltip.innerHTML = message ;
                    }
                }
               
}");


            str.Append("</script>");

            lt.Text = str.ToString().Replace('*', '"');

        }

        catch

        { }



    }
    private void BindChart(int Admin)
    {

        DataTable dt = new DataTable();

        try
        {

            dt = GetData(Admin);



            str.Append(@"<script type=*text/javascript*> google.load( *visualization*, *1*, {packages:[*corechart*]});

            google.setOnLoadCallback(drawChart);

            function drawChart() {

            var data = new google.visualization.DataTable();

            data.addColumn('string', 'الإدارة العليا');
            data.addColumn('number', 'لم يحن وقت تنفيذها'); data.addColumn({'type': 'string', 'role': 'tooltip'});
            data.addColumn('number', 'مغلقة');  data.addColumn({'type': 'string', 'role': 'tooltip'});
            data.addColumn('number', 'متأخرة');  data.addColumn({'type': 'string', 'role': 'tooltip'});
            data.addColumn('number', 'جارى التنفيذ');  data.addColumn({'type': 'string', 'role': 'tooltip'});
            data.addColumn('number', 'معالجة'); data.addColumn({'type': 'string', 'role': 'tooltip'});
 data.addRows([");

            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                var Status3 = "";
                var Status3Txt = "";

                if (dt.Rows[i]["Status3"].ToString() == "0")
                {
                    Status3 = null;
                    Status3Txt = null;
                }
                else
                {

                    if (Convert.ToDouble(dt.Rows[i]["Status3"]) < 4)
                    {
                        Status3 = Convert.ToString(Convert.ToDouble(dt.Rows[i]["Status3"]) * 5);
                    }
                    else
                    {
                        Status3 = Convert.ToString(Convert.ToDouble(dt.Rows[i]["Status3"]) * 2);
                    }
                    Status3Txt = "[" + dt.Rows[i]["Status3"].ToString() + "] " + Math.Round(((Convert.ToDouble(dt.Rows[i]["Status3"]) / Convert.ToDouble(dt.Rows[i]["TotalCount"])) * 100), 1).ToString();
                }

                var Status2 = "";
                var Status2Txt = "";

                if (dt.Rows[i]["Status2"].ToString() == "0")
                {
                    Status2 = null;
                    Status2Txt = null;
                }
                else
                {

                    if (Convert.ToDouble(dt.Rows[i]["Status2"]) < 4)
                    {
                        Status2 = Convert.ToString(Convert.ToDouble(dt.Rows[i]["Status2"]) * 5);
                    }
                    else
                    {
                        Status2 = Convert.ToString(Convert.ToDouble(dt.Rows[i]["Status2"]) * 2);
                    }
                    Status2Txt = "[" + dt.Rows[i]["Status2"].ToString() + "] " + Math.Round(((Convert.ToDouble(dt.Rows[i]["Status2"]) / Convert.ToDouble(dt.Rows[i]["TotalCount"])) * 100), 1).ToString();
                }

                var Status1 = "";
                var Status1Txt = "";

                if (dt.Rows[i]["Status1"].ToString() == "0")
                {
                    Status1 = null;
                    Status1Txt = null;
                }
                else
                {

                    if (Convert.ToDouble(dt.Rows[i]["Status1"]) < 4)
                    {
                        Status1 = Convert.ToString(Convert.ToDouble(dt.Rows[i]["Status1"]) * 5);
                    }
                    else
                    {
                        Status1 = Convert.ToString(Convert.ToDouble(dt.Rows[i]["Status1"]) * 2);
                    }
                    Status1Txt = "[" + dt.Rows[i]["Status1"].ToString() + "] " + Math.Round(((Convert.ToDouble(dt.Rows[i]["Status1"]) / Convert.ToDouble(dt.Rows[i]["TotalCount"])) * 100), 1).ToString();
                }

                var Status4 = "";
                var Status4Txt = "";
                if (dt.Rows[i]["Status4"].ToString() == "0")
                {
                    Status4 = null;
                    Status4Txt = null;
                }
                else
                {

                    if (Convert.ToDouble(dt.Rows[i]["Status4"]) < 4)
                    {
                        Status4 = Convert.ToString(Convert.ToDouble(dt.Rows[i]["Status4"]) * 5);
                    }
                    else
                    {
                        Status4 = Convert.ToString(Convert.ToDouble(dt.Rows[i]["Status4"]) * 2);
                    }
                    Status4Txt = "[" + dt.Rows[i]["Status4"].ToString() + "] " + Math.Round(((Convert.ToDouble(dt.Rows[i]["Status4"]) / Convert.ToDouble(dt.Rows[i]["TotalCount"])) * 100), 1).ToString();
                }

                var Status5 = "";
                var Status5Txt = "";
                if (dt.Rows[i]["Status5"].ToString() == "0")
                {
                    Status5 = null;
                    Status5Txt = null;
                }
                else
                {

                    if (Convert.ToDouble(dt.Rows[i]["Status5"]) < 4)
                    {
                        Status5 = Convert.ToString(Convert.ToDouble(dt.Rows[i]["Status5"]) * 5);
                    }
                    else
                    {
                        Status5 = Convert.ToString(Convert.ToDouble(dt.Rows[i]["Status5"]) * 2);
                    }
                    Status5Txt = "[" + dt.Rows[i]["Status5"].ToString() + "] " + Math.Round(((Convert.ToDouble(dt.Rows[i]["Status5"]) / Convert.ToDouble(dt.Rows[i]["TotalCount"])) * 100), 1).ToString();
                }

                str.Append(@"['" + dt.Rows[i]["AdmName"].ToString() + "', " + Status4 + ", '" + Status4Txt + "%" + "', " + Status5 + ",  '" + Status5Txt + "%" + "', " + Status1 + ",  '" + Status1Txt + "%" + "', " + Status2 + ",  '" + Status2Txt + "%" + "', " + Status3 + ",  '" + Status3Txt + "%" + "'],");
            }



            str.Append("]);");



            str.Append("var chart = new google.visualization.ColumnChart(document.getElementById('chart_div'));");
            str.Append("chart.draw(data,{isStacked:false, width:800, height:500,legend: { position: 'none' }, vAxis: {minValue: 4,viewWindow:{ min: 0},format: '0' },colors: ['#93cdf3','#727aa2','#9C27B0','#FF9800','#4CAF50'], hAxis: {showTextEvery:1, slantedText:false}});");
            str.Append(@"google.visualization.events.addListener(chart, 'select', selectHandler);

  function selectHandler() {
                    var selectedItem = chart.getSelection()[0];
                    if (selectedItem) {
var selection = chart.getSelection();
var message = '';
for (var i = 0; i < selection.length; i++) {
var item = selection[i];
if (item.row != null && item.column != null) {
var str = data.getFormattedValue(item.row, item.column);
var category = data
.getValue(chart.getSelection()[0].row, 0)


message += '{row:' + item.row + ',column:' + item.column
+ '} = ' + str ;

Hidden(item.column,str,category);
 ");




            str.Append(@" 
}}
if (message == '') {
message = 'nothing';
}
                        var tooltip = document.getElementsByClassName('google-visualization-tooltip')[0];
                        tooltip.innerHTML = message ;
                    }
                }
               
}");


            str.Append("</script>");

            lt.Text = str.ToString().Replace('*', '"');

        }

        catch

        { }



    }
    protected void SectionCharts_Click(object sender, ImageClickEventArgs e)
    {
        DataSet MyRecDataSet = (DataSet)Session["UData"];

        Response.Redirect("AdminsCharts01.aspx?Adm=" + Convert.ToString(Request.QueryString["Reqq"]));
    }
    private DataTable GetDataStat(int Admin)
    {

        DataTable dt = new DataTable();

        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "GetChartReportByStatChartAdm";
        cmd.Parameters.AddWithValue("@ID", Admin);
        cmd.Connection = Obj.Conn;


        SqlDataAdapter adp = new SqlDataAdapter();
        adp.SelectCommand = cmd;

        adp.Fill(dt);

        return dt;


    }

    private DataTable GetDataImport(int Admin)
    {

        DataTable dt = new DataTable();

        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "GetChartByStatChartAdmin";
        cmd.Parameters.AddWithValue("@ID", Admin);
        cmd.Connection = Obj.Conn;


        SqlDataAdapter adp = new SqlDataAdapter();
        adp.SelectCommand = cmd;

        adp.Fill(dt);

        return dt;



    }

    private DataTable GetDataImportPlan(int Admin, int Plan)
    {

        DataTable dt = new DataTable();

        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "GetImportPlanAdmin";
        cmd.Parameters.AddWithValue("@ID", Admin);
        cmd.Parameters.AddWithValue("@ID2", Plan);
        cmd.Connection = Obj.Conn;


        SqlDataAdapter adp = new SqlDataAdapter();
        adp.SelectCommand = cmd;

        adp.Fill(dt);

        return dt;


    }

    private DataTable GetDataStatPlan(int Admin, int Plan)
    {

        DataTable dt = new DataTable();

        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "GetChartPlanAdmin";
        cmd.Parameters.AddWithValue("@ID", Admin);
        cmd.Parameters.AddWithValue("@ID2", Plan);
        cmd.Connection = Obj.Conn;


        SqlDataAdapter adp = new SqlDataAdapter();
        adp.SelectCommand = cmd;

        adp.Fill(dt);

        return dt;



    }


    private void BindImportChartAdmin(int Admin, int Plan)
    {
        DataTable dtImport = new DataTable();

        try
        {

            dtImport = GetDataImportPlan(Admin, Plan);



            strImport.Append(@"<script type=*text/javascript*> google.load( *visualization*, *1*, {packages:[*corechart*]});

            google.setOnLoadCallback(drawChartImport);

            function drawChartImport() {

            var dataImport = new google.visualization.DataTable();

            dataImport.addColumn('string', 'مستوى الأهمية');
            dataImport.addColumn('number', 'Counts');
dataImport.addColumn({type: 'string', role: 'tooltip', 'p': {'html': true}});
            ");

            strImport.Append("dataImport.addRows([");
            string Level = "";
            string Tip = "";
            string Dv = "";

            for (int i = 0; i <= dtImport.Rows.Count - 1; i++)
            {

                if (dtImport.Rows[i]["Import"].ToString() == "3")
                {
                    Level = "مرتفعة";
                    Dv = "<div class=*google-visualization-tooltipL* >";
                }
                else if (dtImport.Rows[i]["Import"].ToString() == "2")
                {
                    Level = "متوسطة";
                    Dv = "<div  class=*google-visualization-tooltipT* >";

                }
                else if (dtImport.Rows[i]["Import"].ToString() == "1")
                {
                    Level = "منخفضة";
                    Dv = "<div  class=*google-visualization-tooltipR* >";
                }
                Dv = Dv + Level + "(" + Convert.ToString(dtImport.Rows[i]["Counts"]) + ")<br/>";

                DataSet DSCounts = Obj.GetDataSetBy3ID("GetRepCountByStatAdminsNEW", Convert.ToInt32(dtImport.Rows[i]["Import"].ToString()), Convert.ToInt32(Admin), Convert.ToInt32(Plan));

                if (DSCounts.Tables[0].Rows.Count > 0)
                {
                    for (int k = 0; k < DSCounts.Tables[0].Rows.Count; k++)
                    {
                        Tip = Dv + " المعالج " + " (" + DSCounts.Tables[0].Rows[k]["Status3"].ToString() + ")" + "<br/>" + "المتبقى " + string.Concat("(", DSCounts.Tables[0].Rows[k]["NotDoneAll"].ToString()) + ")";
                    }

                }
                strImport.Append("['" + Level + "', " + Convert.ToInt32(dtImport.Rows[i]["Counts"]) + "," + "'" + Tip + "</div>'" + "],");
            }
            strImport.Append(" ]);");

            strImport.Append(" var chartImport = new google.visualization.PieChart(document.getElementById('chartImport_div'));");

            strImport.Append(" chartImport.draw(dataImport,{'title': '', pieHole: 0.4,'width': 300, 'height': 300,tooltip: {isHtml: true}, 'backgroundColor': 'transparent',chartArea:{left:2,top:7,width:'85%',height:'85%'}, 'textAlign': 'center', 'colors': ['#4CAF50', '#FF9800', '#9C27B0'],legend: { position: 'none'}, vAxis:{minValue: 4,viewWindow:{ min: 0},format: '0' }, hAxis: {showTextEvery:1, slantedText:false}});");

            strImport.Append(@"google.visualization.events.addListener(chartImport, 'select', selectHandler123);

  function selectHandler123() {
                    var selectedItem = chartImport.getSelection()[0];
                    if (selectedItem) {");


            strImport.Append("self.location = *ReportingAdm.aspx?YQ=" + Plan + "&qq=*+ chartImport.getSelection()[0].row;}}} ");

            strImport.Append("</script>");

            LtImport.Text = strImport.ToString().Replace('*', '"');

        }

        catch

        { }




    }
    private void BindImportChart(int Admin)
    {
        DataTable dtImport = new DataTable();

        try
        {

            dtImport = GetDataImport(Admin);



            strImport.Append(@"<script type=*text/javascript*> google.load( *visualization*, *1*, {packages:[*corechart*]});

            google.setOnLoadCallback(drawChartImport);

            function drawChartImport() {

            var dataImport = new google.visualization.DataTable();

            dataImport.addColumn('string', 'مستوى الأهمية');
            dataImport.addColumn('number', 'Counts');
dataImport.addColumn({type: 'string', role: 'tooltip', 'p': {'html': true}});
            ");

            strImport.Append("dataImport.addRows([");
            string Level = "";
            string Tip = "";
            string Dv = "";

            for (int i = 0; i <= dtImport.Rows.Count - 1; i++)
            {

                if (dtImport.Rows[i]["Import"].ToString() == "3")
                {
                    Level = "مرتفعة";
                    Dv = "<div class=*google-visualization-tooltipL* >";
                }
                else if (dtImport.Rows[i]["Import"].ToString() == "2")
                {
                    Level = "متوسطة";
                    Dv = "<div  class=*google-visualization-tooltipT* >";

                }
                else if (dtImport.Rows[i]["Import"].ToString() == "1")
                {
                    Level = "منخفضة";
                    Dv = "<div  class=*google-visualization-tooltipR* >";
                }
                Dv = Dv + Level + "(" + Convert.ToString(dtImport.Rows[i]["Counts"]) + ")<br/>";

                DataSet DSCounts = Obj.GetDataSetBy2ID("GetRepCountByStatAdm01New", Admin, Convert.ToInt32(dtImport.Rows[i]["Import"].ToString()));
                if (DSCounts.Tables[0].Rows.Count > 0)
                {
                    for (int k = 0; k < DSCounts.Tables[0].Rows.Count; k++)
                    {
                        Tip = Dv + " المعالج " + " (" + DSCounts.Tables[0].Rows[k]["Status3"].ToString() + ")" + "<br/>" + "المتبقى " + string.Concat("(", DSCounts.Tables[0].Rows[k]["NotDoneAll"].ToString()) + ")";
                    }

                }
                strImport.Append("['" + Level + "', " + Convert.ToInt32(dtImport.Rows[i]["Counts"]) + "," + "'" + Tip + "</div>'" + "],");
            }
            strImport.Append(" ]);");

            strImport.Append(" var chartImport = new google.visualization.PieChart(document.getElementById('chartImport_div'));");

            strImport.Append(" chartImport.draw(dataImport,{'title': '',pieHole: 0.4, 'width': 300, 'height': 300,tooltip: {isHtml: true}, 'backgroundColor': 'transparent',chartArea:{top:7,left:5,width:'75%',height:'75%'}, 'textAlign': 'center', 'colors': ['#4CAF50', '#FF9800', '#9C27B0'],legend: { position: 'none'}, vAxis:{minValue: 4,viewWindow:{ min: 0},format: '0' }, hAxis: {showTextEvery:1, slantedText:false}});");

            strImport.Append(@"google.visualization.events.addListener(chartImport, 'select', selectHandler123);

  function selectHandler123() {
                    var selectedItem = chartImport.getSelection()[0];
                    if (selectedItem) {


self.location = *ReportingAdm.aspx?qq=*+ chartImport.getSelection()[0].row;
}}}
 ");


            strImport.Append("</script>");

            LtImport.Text = strImport.ToString().Replace('*', '"');

        }

        catch

        { }




    }

    private void BindStatChartAdmin(int Admin, int Plan)
    {

        DataTable dtStat = new DataTable();

        try
        {
            dtStat = GetDataStatPlan(Admin, Plan);

            strStat.Append(@"<script type=*text/javascript*> google.load( *visualization*, *1*, {packages:[*corechart*]});

            google.setOnLoadCallback(drawChartStat);

            function drawChartStat() {

            var dataStat = new google.visualization.DataTable();

            dataStat.addColumn('string', 'الإلتزام بالتنفيذ على مستوى المؤسسة');
            dataStat.addColumn('number', 'Counts');
            dataStat.addRows(" + dtStat.Rows.Count + ");");
            string Level = "";

            for (int i = 0; i <= dtStat.Rows.Count - 1; i++)
            {
                if (dtStat.Rows[i]["Stat"].ToString() == "4")
                {
                    Level = "لم يحن وقت التنفيذ";
                }
                else if (dtStat.Rows[i]["Stat"].ToString() == "5")
                {
                    Level = "مغلقة";
                }
                else if (dtStat.Rows[i]["Stat"].ToString() == "1")
                {
                    Level = "متأخرة";
                }
                else if (dtStat.Rows[i]["Stat"].ToString() == "2")
                {
                    Level = "جارى التنفيذ";
                }
                else if (dtStat.Rows[i]["Stat"].ToString() == "3")
                {
                    Level = "معالجة";
                }

                strStat.Append("dataStat.setValue( " + i + "," + 0 + "," + "'" + Level + "');");

                strStat.Append("dataStat.setValue(" + i + "," + 1 + "," + dtStat.Rows[i]["Counts"].ToString() + ") ;");



            }




            strStat.Append("var chartStat = new google.visualization.PieChart(document.getElementById('chartStat_div'));");

            strStat.Append("chartStat.draw(dataStat,{width:300, height:300,pieHole: 0.4,'textAlign': 'right', chartArea:{left:2,top:7,width:'85%',height:'85%'},legend: {position: 'none' }, vAxis:{minValue: 4,viewWindow:{ min: 0},format: '0' },'colors': ['#93cdf3','#727aa2','#9C27B0','#FF9800','#4CAF50'], hAxis: {showTextEvery:1, slantedText:false}});");

            strStat.Append(@"google.visualization.events.addListener(chartStat, 'select', selectHandler1235);

  function selectHandler1235() {
                    var selectedItem = chartStat.getSelection()[0];
                    if (selectedItem) {

Hidden(chartStat.getSelection()[0].row);
}}}");

            strStat.Append("</script>");

            LitStat.Text = strStat.ToString().Replace('*', '"');

        }

        catch

        { }



    }
    private void BindStatChart(int Admin)
    {

        DataTable dtStat = new DataTable();

        try
        {

            dtStat = GetDataStat(Admin);



            strStat.Append(@"<script type=*text/javascript*> google.load( *visualization*, *1*, {packages:[*corechart*]});

            google.setOnLoadCallback(drawChartStat);

            function drawChartStat() {

            var dataStat = new google.visualization.DataTable();

            dataStat.addColumn('string', 'الإلتزام بالتنفيذ على مستوى المؤسسة');
            dataStat.addColumn('number', 'Counts');
            dataStat.addRows(" + dtStat.Rows.Count + ");");
            string Level = "";

            for (int i = 0; i <= dtStat.Rows.Count - 1; i++)
            {
                if (dtStat.Rows[i]["Stat"].ToString() == "4")
                {
                    Level = "لم يحن وقت التنفيذ";
                }
                else if (dtStat.Rows[i]["Stat"].ToString() == "5")
                {
                    Level = "مغلقة";
                }
                else if (dtStat.Rows[i]["Stat"].ToString() == "1")
                {
                    Level = "متأخرة";
                }
                else if (dtStat.Rows[i]["Stat"].ToString() == "2")
                {
                    Level = "جارى التنفيذ";
                }
                else if (dtStat.Rows[i]["Stat"].ToString() == "3")
                {
                    Level = "معالجة";
                }

                strStat.Append("dataStat.setValue( " + i + "," + 0 + "," + "'" + Level + "');");

                strStat.Append("dataStat.setValue(" + i + "," + 1 + "," + dtStat.Rows[i]["Counts"].ToString() + ") ;");



            }




            strStat.Append(" var chartStat = new google.visualization.PieChart(document.getElementById('chartStat_div'));");

            strStat.Append(" chartStat.draw(dataStat,{width:300, pieHole: 0.4,height:300,'textAlign': 'right', chartArea:{left:2,top:7,width:'75%',height:'75%'},legend: {position: 'none' }, vAxis:{minValue: 4,viewWindow:{ min: 0},format: '0' },'colors': ['#93cdf3','#727aa2','#9C27B0','#FF9800','#4CAF50'], hAxis: {showTextEvery:1, slantedText:false}});");

            strStat.Append(@"google.visualization.events.addListener(chartStat, 'select', selectHandler1235);

  function selectHandler1235() {
                    var selectedItem = chartStat.getSelection()[0];
                    if (selectedItem) {

Hidden(chartStat.getSelection()[0].row);
}}}
 ");

            strStat.Append("</script>");

            LitStat.Text = strStat.ToString().Replace('*', '"');

        }

        catch

        { }



    }



    protected void RepImpData_ItemDataBound1(object sender, RepeaterItemEventArgs e)
    {
        if (((Label)e.Item.FindControl("LblImp")).Text == "1")
        {
            ((System.Web.UI.HtmlControls.HtmlGenericControl)(e.Item.FindControl("LowVal"))).Visible = true;
            ((System.Web.UI.HtmlControls.HtmlGenericControl)(e.Item.FindControl("HighVal"))).Visible = false;
            ((System.Web.UI.HtmlControls.HtmlGenericControl)(e.Item.FindControl("MidVal"))).Visible = false;
        }
        if (((Label)e.Item.FindControl("LblImp")).Text == "2")
        {
            ((System.Web.UI.HtmlControls.HtmlGenericControl)(e.Item.FindControl("LowVal"))).Visible = false;
            ((System.Web.UI.HtmlControls.HtmlGenericControl)(e.Item.FindControl("HighVal"))).Visible = false;
            ((System.Web.UI.HtmlControls.HtmlGenericControl)(e.Item.FindControl("MidVal"))).Visible = true;
        }
        if (((Label)e.Item.FindControl("LblImp")).Text == "3")
        {
            ((System.Web.UI.HtmlControls.HtmlGenericControl)(e.Item.FindControl("LowVal"))).Visible = false;
            ((System.Web.UI.HtmlControls.HtmlGenericControl)(e.Item.FindControl("HighVal"))).Visible = true;
            ((System.Web.UI.HtmlControls.HtmlGenericControl)(e.Item.FindControl("MidVal"))).Visible = false;
        }

        var Stats = Stat.Value;

        if (Stats == "-1")
        {
            Stats = "5";
        }
        else if (Stats == "0")
        {
            Stats = "4";
        }
        var Vall = Convert.ToInt32(hidden.Value);


        if (Vall != 0)
        {
            double a = ((Convert.ToDouble(((Label)e.Item.FindControl("LblCounts")).Text)) * 100 / Vall);
            ((Label)e.Item.FindControl("LblAvg")).Text = Math.Round(a, 2, MidpointRounding.ToEven).ToString() + "%";

        }

    }

    protected void RepImpData_Disposed(object sender, EventArgs e)
    {
        Stat.Value = "Non";
    }
}