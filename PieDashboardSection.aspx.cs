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
using System.Web.UI.HtmlControls;
using System.Data.OleDb;

public partial class PieDashboardSection : System.Web.UI.Page
{
    Operations Obj = new Operations();
    StringBuilder str = new StringBuilder();

    StringBuilder strImport = new StringBuilder();
    
    StringBuilder str0 = new StringBuilder();

    StringBuilder strImport0 = new StringBuilder();
    StringBuilder strImportChart = new StringBuilder();

    StringBuilder strImportByAdm = new StringBuilder();

    StringBuilder strStat = new StringBuilder();
    StringBuilder strStat0 = new StringBuilder();

    private DataTable GetDataStatPlan(int Plan, int Section)
    {

        DataTable dt = new DataTable();

        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "GetChartByPlanNEW";
        cmd.Parameters.AddWithValue("@ID", Plan);
        cmd.Parameters.AddWithValue("@ID2", Section);
        cmd.Connection = Obj.Conn;


        SqlDataAdapter adp = new SqlDataAdapter();
        adp.SelectCommand = cmd;

        adp.Fill(dt);

        return dt;



    }


    private DataTable GetDataImportPlan(int Plan, int Section)
    {

        DataTable dt = new DataTable();

        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "GetChartByPlanImportNew";
        cmd.Parameters.AddWithValue("@ID", Plan);
        cmd.Parameters.AddWithValue("@ID2", Section);
        cmd.Connection = Obj.Conn;


        SqlDataAdapter adp = new SqlDataAdapter();
        adp.SelectCommand = cmd;

        adp.Fill(dt);

        return dt;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["PostID"] = "1001";
            ViewState["PostID"] = Session["PostID"].ToString();

            if (Session["UData"] != null)
            {
                DataSet MyRecDataSet = (DataSet)Session["UData"];


                if (Obj.ExecuteProcedureID("CheckSectionManger", Convert.ToInt32(MyRecDataSet.Tables[0].Rows[0]["EmpID"])) == 1)
                {/// Log Data Start

                    Obj.ExecuteProcedureStringID("NewLogTable", Convert.ToInt32(MyRecDataSet.Tables[0].Rows[0]["EmpID"]), "View Notes and Recommendations Charts by Section manager permission");

                    /// Log Data End

                    DropYear.Items.Clear();
                    DropYear.DataSource = Obj.GetDataSetByID("GetPlansBySection", Convert.ToInt32(MyRecDataSet.Tables[0].Rows[0]["SectionID"]));
                    DropYear.DataTextField = "YearName";
                    DropYear.DataValueField = "ID";
                    DropYear.DataBind();

                    ListItem aa = new ListItem("جميع السنوات ", "0");

                    DropYear.Items.Insert(0, aa);

                    if (Request.QueryString["ReqYR"] != null)
                    {
                        DropYear.SelectedValue = Request.QueryString["ReqYR"];


                        HyperLink1.NavigateUrl = "ReportingAllSections.aspx?ReqY="+DropYear.SelectedValue+"&Reqq=" + Convert.ToString(MyRecDataSet.Tables[0].Rows[0]["SectionID"]);


                    }
                    else
                    {
                        HyperLink1.NavigateUrl = "ReportingAllSections.aspx?ReqY=0&Reqq=" + Convert.ToString(MyRecDataSet.Tables[0].Rows[0]["SectionID"]);


                    }



                    


                }

                else
                {
                    Response.Redirect("NoPermissions.aspx");
                }
            }


            if (Request.QueryString["Reqq"] != null)
            {

                string YearSelectedValue = Request.QueryString["ReqYR"];
                if (!string.IsNullOrEmpty(YearSelectedValue))
                    DropYear.SelectedValue = YearSelectedValue;

                if (Request.QueryString["Reqq"] != "")
                {
                    //Completed
                    BindImportChart();
                    //Tomorrow
                    BindStatChart();
                    BindChart();


                    DataSet ds = null;
                    if (string.IsNullOrEmpty(YearSelectedValue))
                        ds = Obj.GetDataSetByID("GetAllAdminsBySection", Convert.ToInt32(Request.QueryString["Reqq"]));
                    else
                        ds = Obj.GetDataSetBy2ID("GetAllSectionsChartPlanSEC", Convert.ToInt32(Request.QueryString["Reqq"]), Convert.ToInt32(Request.QueryString["ReqYR"]));


                    PrntView.Attributes.Remove("style");
                    PrntView.Style.Add("display", "block");

                    //    PrevAll.Attributes.Remove("style");
                    //   PrevAll.Style.Add("display", "block");

                    NoRep.Visible = false;

                    //RepYears.DataSource = Obj.GetDataSetByID("GetPlansBySection", Convert.ToInt32(Request.QueryString["Reqq"]));
                    //RepYears.DataBind();

                    if (string.IsNullOrEmpty(YearSelectedValue))
                        RepTotals.DataSource = Obj.GetDataSetByID("GetRepSectionCounts", Convert.ToInt32(Request.QueryString["Reqq"]));
                    else
                        RepTotals.DataSource = Obj.GetDataSetBy2ID("GetRepSectionAllPlansBySec", Convert.ToInt32(Request.QueryString["Reqq"]), Convert.ToInt32(Request.QueryString["ReqYR"]));

                    RepTotals.DataBind();


                    Repeater2.DataSource = EmployeesData.DataSource = ds;
                    EmployeesData.DataBind();

                    Repeater2.DataBind();
                }
                else
                {
                    PrntView.Attributes.Remove("style");
                    PrntView.Style.Add("display", "none");

                    //PrevAll.Attributes.Remove("style");
                    //PrevAll.Style.Add("display", "none");

                    NoRep.Visible = true;
                }
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
                HiddenTitle.Value = "0";
            }
                if (HiddenTitle.Value != "0")
            {
                LoadDataChart();
            }

            if (HiddenYear.Value != "0")
            {
                //RepYears.DataSource = Obj.GetDataSetByID("GetPlansBySection", Convert.ToInt32(Request.QueryString["Reqq"]));
                //RepYears.DataBind();
            }
        }

    }


    private void LoadDataChart()
    {
        if (hidden.Value != "0")
        {
            RepImpData.DataSource = null;
            RepImpData.DataBind();
            int Stats = 1;
            string Case = "";
            if (Convert.ToInt32(Stat.Value) == 1)
            {
                Stats = 4;
                Case = "مستوى مخاطر الملاحظات التى لم يحن وقت تنفيذها";
            }
            else if (Convert.ToInt32(Stat.Value) == 3)
            {
                Stats = 5;
                Case = "مستوى مخاطر الملاحظات المغلقة";
            }
            else if (Convert.ToInt32(Stat.Value) == 5)
            {
                Stats = 1;
                Case = "مستوى مخاطر الملاحظات المتأخرة";
            }
            else if (Convert.ToInt32(Stat.Value) == 7)
            {
                Stats = 2;
                Case = "مستوى مخاطر الملاحظات جارى التنفيذ";
            }
            else if (Convert.ToInt32(Stat.Value) == 9)
            {
                Stats = 3;

                Case = "مستوى مخاطر الملاحظات المعالجة";
            }

            MainTitle.InnerHtml = "<h3>" + Case + " / " + HiddenTitle.Value + "</h3>";

            //RepImpData.DataSource = Obj.GetChartBySectionAdminStat(Convert.ToInt32(Request.QueryString["Reqq"]), Obj.ExecuteProcedureString("GetAdminByName", HiddenTitle.Value), Stats);
            if (Request.QueryString["ReqYR"] != "0" && Request.QueryString["ReqYR"] != null)
            {
                hidden.Value = Obj.ExecuteProcedure3ID("GetChartAdmYearCounts", Obj.ExecuteProcedureString("GetAdminByName", HiddenTitle.Value), Stats, Convert.ToInt32(Request.QueryString["ReqYR"])).ToString();

                RepImpData.DataSource = Obj.GetChartBySectionAdminPlanStat(Convert.ToInt32(Request.QueryString["ReqYR"]), Convert.ToInt32(Request.QueryString["Reqq"]), Obj.ExecuteProcedureString("GetAdminByName", HiddenTitle.Value), Stats);

                RepImpData.DataBind();
            }
            else
            {
                hidden.Value = Obj.ExecuteProcedure2ID("GetChartAdmCounts", Obj.ExecuteProcedureString("GetAdminByName", HiddenTitle.Value), Stats).ToString();

                RepImpData.DataSource = Obj.GetChartBySectionAdminStat(Convert.ToInt32(Request.QueryString["Reqq"]), Obj.ExecuteProcedureString("GetAdminByName", HiddenTitle.Value), Stats);

                RepImpData.DataBind();
            }

        }
    }
    protected void RepImpData_ItemDataBound(object sender, RepeaterItemEventArgs e)
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
       

        var Vall = Convert.ToInt32(hidden.Value);



        if (Vall != 0)
        {

            double a = ((Convert.ToDouble(((Label)e.Item.FindControl("LblCounts")).Text)) * 100 / Vall);
            ((Label)e.Item.FindControl("LblAvg")).Text = Math.Round(a, 2, MidpointRounding.ToEven).ToString() + "%";

        }

    }

    protected void RepImpData_Disposed(object sender, EventArgs e)
    {
        hidden.Value = "0";
    }
    private DataTable GetData()
    {


        DataTable dt = new DataTable();

        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "GetAllAdminsBySection";
        cmd.Parameters.AddWithValue("@ID", Request.QueryString["Reqq"]);
        cmd.Connection = Obj.Conn;


        SqlDataAdapter adp = new SqlDataAdapter();
        adp.SelectCommand = cmd;

        adp.Fill(dt);

        return dt;


    }
    private void BindChart()
    {

        DataTable dt = new DataTable();

        try
        {

            // dt = GetData();

            if (string.IsNullOrEmpty(Request.QueryString["ReqYR"]) || Request.QueryString["ReqYR"] == "0")
                dt = GetData();
            else
                dt = GetDataPlan(Convert.ToInt32(Request.QueryString["ReqYR"]), Convert.ToInt32(Request.QueryString["Reqq"]));



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
            str.Append("chart.draw(data,{ width:800, height:500,legend: { position: 'none' }, vAxis: {minValue: 4,viewWindow:{ min: 0},format: '0' ,textPosition: 'none' },colors: ['#93cdf3','#727aa2','#9C27B0','#FF9800','#4CAF50'], hAxis: {showTextEvery:1, slantedText:false}});");
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

    private DataTable GetDataImport()
    {

        DataTable dt = new DataTable();

        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "GetChartBySectionChartNew";

        cmd.Parameters.AddWithValue("@ID", Request.QueryString["Reqq"]);
        cmd.Connection = Obj.Conn;

        SqlDataAdapter adp = new SqlDataAdapter();
        adp.SelectCommand = cmd;

        adp.Fill(dt);

        return dt;



    }
    private DataTable GetDataStat()
    {

        DataTable dt = new DataTable();

        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "GetChartBySectionStatChart";
        cmd.Parameters.AddWithValue("@ID", Request.QueryString["Reqq"]);
        cmd.Connection = Obj.Conn;


        SqlDataAdapter adp = new SqlDataAdapter();
        adp.SelectCommand = cmd;

        adp.Fill(dt);

        return dt;


    }

    private DataTable GetDataImport0(int Plan)
    {

        DataTable dt = new DataTable();

        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "GetChartByPlanImport";
        cmd.Parameters.AddWithValue("@Plan", Plan);
        cmd.Parameters.AddWithValue("@Section", Convert.ToInt32(Request.QueryString["Reqq"]));
        cmd.Connection = Obj.Conn;


        SqlDataAdapter adp = new SqlDataAdapter();
        adp.SelectCommand = cmd;

        adp.Fill(dt);

        return dt;



    }
    private DataTable GetDataStat0(int Plan)
    {

        DataTable dt = new DataTable();

        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "GetChartByPlan";
        cmd.Parameters.AddWithValue("@Plan", Plan);
        cmd.Parameters.AddWithValue("@Section", Convert.ToInt32(Request.QueryString["Reqq"]));
        cmd.Connection = Obj.Conn;


        SqlDataAdapter adp = new SqlDataAdapter();
        adp.SelectCommand = cmd;

        adp.Fill(dt);

        return dt;


    }

    private void BindImportChart()
    {
        DataSet MyRecDataSet = (DataSet)Session["UData"];

        DataTable dtImport = new DataTable();

        try
        {
            if (string.IsNullOrEmpty(Request.QueryString["ReqYR"]) || Request.QueryString["ReqYR"] == "0")
                dtImport = GetDataImport();
            else
                dtImport = GetDataImportPlan(Convert.ToInt32(Request.QueryString["ReqYR"]), Convert.ToInt32(Request.QueryString["Reqq"]));

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

                DataSet DSCounts = Obj.GetDataSetBy3ID("GetRepCountByStatSec01NEW", Convert.ToInt32(dtImport.Rows[i]["Import"].ToString()), Convert.ToInt32(MyRecDataSet.Tables[0].Rows[0]["SectionID"]), Convert.ToInt32(Request.QueryString["ReqYR"]));

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

            strImport.Append(" chartImport.draw(dataImport,{'title': '',pieHole: 0.4, 'width': 300, 'height': 300,tooltip: {isHtml: true}, 'backgroundColor': 'transparent',chartArea:{left:2,top:7,width:'85%',height:'85%'}, 'textAlign': 'center', 'colors': ['#4CAF50', '#FF9800', '#9C27B0'],legend: { position: 'none'}, vAxis: {minValue: 4,viewWindow:{ min: 0},format: '0' }, hAxis: {showTextEvery:1, slantedText:false}});");

            strImport.Append(@"google.visualization.events.addListener(chartImport, 'select', selectHandler123);

  function selectHandler123() {
                    var selectedItem = chartImport.getSelection()[0];
                    if (selectedItem) {
");

            strImport.Append("self.location = *ReportingAllSectionsStat.aspx?"+"ReqY="+Request.QueryString["ReqYR"] +"&Reqq="+Convert.ToString(MyRecDataSet.Tables[0].Rows[0]["SectionID"])+"&Stat=*+chartImport.getSelection()[0].row;");
            strImport.Append("}}}</script>");

            LtImport.Text = strImport.ToString().Replace('*', '"');

        }

        catch

        { }



    }


    private void BindStatChart()
    {

        DataTable dtStat = new DataTable();

        try
        {
            
            //dtStat = GetDataStat();
            if ((string.IsNullOrEmpty(Request.QueryString["ReqYR"]) || Request.QueryString["ReqYR"] == "0") && (Request.QueryString["Reqq"] != "" || Request.QueryString["Reqq"] != null || Request.QueryString["Reqq"] != "0"))
                dtStat = GetDataStat();
            else
                dtStat = GetDataStatPlan(Convert.ToInt32(Request.QueryString["ReqYR"]), Convert.ToInt32(Request.QueryString["Reqq"]));



            strStat.Append(@"<script type=*text/javascript*> google.load( *visualization*, *1*, {packages:[*corechart*]});

            google.setOnLoadCallback(drawChartStat);

            function drawChartStat() {

            var dataStat = new google.visualization.DataTable();

            dataStat.addColumn('string', 'الإلتزام بالتنفيذ على مستوى الإدارة العليا');
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

            strStat.Append(" chartStat.draw(dataStat,{width:300, height:300,pieHole: 0.4,'textAlign': 'right', chartArea:{left:2,top:7,width:'85%',height:'85%'},legend: {position: 'none' }, vAxis:{minValue: 4,viewWindow:{ min: 0},format: '0' },'colors': ['#93cdf3','#727aa2','#9C27B0','#FF9800','#4CAF50'], hAxis: {showTextEvery:1, slantedText:false}});}");



            strStat.Append("</script>");

            LitStat.Text = strStat.ToString().Replace('*', '"');

        }

        catch

        { }



    }



    private DataTable GetDataPlan(int Plan, int Section)
    {


        DataTable dt = new DataTable();

        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "GetAllAdminsByPlan";
        cmd.Parameters.AddWithValue("@Plan", Plan);
        cmd.Parameters.AddWithValue("@Section", Section);
        cmd.Connection = Obj.Conn;


        SqlDataAdapter adp = new SqlDataAdapter();
        adp.SelectCommand = cmd;

        adp.Fill(dt);

        return dt;


    }


    protected void RepImpDataitems_ItemDataBound(object sender, RepeaterItemEventArgs e)
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

        if (Session["UData"] != null)
        {
            DataSet MyRecDataSet = (DataSet)Session["UData"];
            int Stats = 1;
            if (Convert.ToInt32(HiddenStat.Value) == 1)
            { Stats = 4; }
            else if (Convert.ToInt32(HiddenStat.Value) == 3)
            { Stats = 5; }
            else if (Convert.ToInt32(HiddenStat.Value) == 5)
            { Stats = 1; }
            else if (Convert.ToInt32(HiddenStat.Value) == 7)
            { Stats = 2; }
            else if (Convert.ToInt32(HiddenStat.Value) == 9)
            { Stats = 3; }

            var Vall = Obj.GetReportCountAdmPlanStat(Convert.ToInt32(HiddenYear.Value), Convert.ToInt32(MyRecDataSet.Tables[0].Rows[0]["AdmID"]), Stats);


            if (Vall != 0)
            {

                double a = ((Convert.ToDouble(((Label)e.Item.FindControl("LblCounts")).Text)) * 100 / Vall);
                ((Label)e.Item.FindControl("LblAvg")).Text = Math.Round(a, 2, MidpointRounding.ToEven).ToString() + "%";

            }
        }
    }

    protected void RepImpDataitems_Disposed(object sender, EventArgs e)
    {
        HiddenYear.Value = "0";
        HiddenStat.Value = "";
        HiddenTitleP.Value = "";

    }
    protected void AdminsChart_Command(object sender, CommandEventArgs e)
    {
        Response.Redirect("SectionAdminsChartsP.aspx?Reqq=" + Request.QueryString["Reqq"] + "&P=" + e.CommandArgument);
    }
    protected void SectionCharts_Click(object sender, ImageClickEventArgs e)
    {
        if (Request.QueryString["ReqYR"] != null && Request.QueryString["ReqYR"] != "")
        {
            Response.Redirect("SectionAdminsCharts.aspx?S=1&ReqYR="+ Request.QueryString["ReqYR"] + "&Reqq=" + Request.QueryString["Reqq"]);
        }
        else
        {
            Response.Redirect("SectionAdminsCharts.aspx?S=1&Reqq=" + Request.QueryString["Reqq"]);
        }
    }

    protected void DropYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropYear.SelectedValue != "0")
        {
            Response.Redirect("PieDashboardSection.aspx?Reqq=" + Request.QueryString["Reqq"] + "&ReqYR=" + DropYear.SelectedValue);
        }
        else
        {

            Response.Redirect("PieDashboardSection.aspx?Reqq=" + Request.QueryString["Reqq"]);
        }
    }
}