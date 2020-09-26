using System;

using System.Collections.Generic;

using System.Linq;

using System.Web;

using System.Web.UI;

using System.Web.UI.WebControls;

using System.Data;

using System.Data.SqlClient;

using System.Text;

using System.Configuration;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.HtmlControls;
using System.Data.OleDb;

public partial class MainDashboardGraph02 : System.Web.UI.Page
{
    Operations Obj = new Operations();

    StringBuilder str = new StringBuilder();
    StringBuilder strAdm = new StringBuilder();

    StringBuilder strImport = new StringBuilder();
    StringBuilder strImportChart = new StringBuilder();

    StringBuilder strImportByAdm = new StringBuilder();
    
    StringBuilder strStat = new StringBuilder();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["PostID"] = "1001";
            ViewState["PostID"] = Session["PostID"].ToString();

            if (Session["UData"] != null)
            {
                DataSet MyRecDataSet = (DataSet)Session["UData"];

                if (Convert.ToBoolean(MyRecDataSet.Tables[0].Rows[0]["Gov"]) == true || Convert.ToBoolean(MyRecDataSet.Tables[0].Rows[0]["SystemAdmin"]) == true || (Convert.ToBoolean(MyRecDataSet.Tables[0].Rows[0]["ApprovPermission"]) == true))
                {
                    HyperLink1.NavigateUrl = "ReportingAll.aspx?ReqY=" + Request.QueryString["Reqq"];

                    DropYear.Items.Clear();
                    DropYear.DataSource = Obj.GetDataSet("GetPlans");
                    DropYear.DataTextField = "YearName";
                    DropYear.DataValueField = "ID";
                    DropYear.DataBind();

                    ListItem aa = new ListItem("جميع السنوات", "0");

                    DropYear.Items.Insert(0, aa);
                    DropYear.SelectedItem.Value = "0";

                    if (Request.QueryString["Reqq"] != "")
                    {
                        DropYear.SelectedValue = Request.QueryString["Reqq"];

                        SectionCharts.PostBackUrl= "SectionsCharts.aspx?Reqq="+ Request.QueryString["Reqq"];

                        AdminCharts.PostBackUrl = "AdminsCharts.aspx?Reqq=" + Request.QueryString["Reqq"];
                    }
                    BindChartAdm();
                    BindChart();
                    BindImportChart();
                    BindStatChart();
                    RepTotalsYears.DataSource = Obj.GetDataSetByID("GetRepSectionAllPlans", Convert.ToInt32(DropYear.SelectedValue));
                    RepTotalsYears.DataBind();


                    Repeater2Years.DataSource = EmployeesDataYears.DataSource = Obj.GetDataSetByID("GetAllSectionsChartPlans", Convert.ToInt32(DropYear.SelectedValue));
                    EmployeesDataYears.DataBind();

                    Repeater2Years.DataBind();

                    DataSet ds = Obj.GetDataSetByID("GetAllSectionsChartPlans", Convert.ToInt32(DropYear.SelectedValue));

                    

                    DataSet dsYear = Obj.GetDataSetByID("GetAllAdminsByPlanNoSec", Convert.ToInt32(DropYear.SelectedValue));

                    Repeater2.DataSource = EmployeesData.DataSource = dsYear;
                    EmployeesData.DataBind();
                    Repeater2.DataBind();
                    RepTotals.DataSource = Obj.GetDataSetByID("GetYearCounts", Convert.ToInt32(DropYear.SelectedValue));
                    RepTotals.DataBind();
                }

                else
                {
                    Response.Redirect("NoPermissions.aspx");
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
                hiddenAdm.Value = "0";

            }
            if (hidden.Value != "0")
            {
                LoadDataChart();
            }
            if (hiddenAdm.Value != "0")
            {
                LoadDataChartAdm();

            }
        }
    }
    private void LoadDataChartAdm()
    {
        if (hiddenAdm.Value != "0")
        {
            RepImpDataAdm.DataSource = null;
            RepImpDataAdm.DataBind();
            int StatsAdm = 1;
            if (Convert.ToInt32(StatAdm.Value) == 1)
            { StatsAdm = 4; }
            else if (Convert.ToInt32(StatAdm.Value) == 3)
            { StatsAdm = 5; }
            else if (Convert.ToInt32(StatAdm.Value) == 5)
            { StatsAdm = 1; }
            else if (Convert.ToInt32(StatAdm.Value) == 7)
            { StatsAdm = 2; }
            else if (Convert.ToInt32(StatAdm.Value) == 9)
            { StatsAdm = 3; }

            MainTitleAdm.InnerHtml = "<h3>" + HiddenTitleAdm.Value + "</h3>";
            hiddenAdm.Value = Obj.ExecuteProcedure3ID("GetChartAdmYearCounts", Obj.ExecuteProcedureString("GetAdminByName", HiddenTitleAdm.Value), StatsAdm, Convert.ToInt32(DropYear.SelectedValue)).ToString();

            RepImpDataAdm.DataSource = Obj.GetChartByPlansStatus(Convert.ToInt32(DropYear.SelectedValue), StatsAdm, Obj.ExecuteProcedureString("GetAdminByName", HiddenTitleAdm.Value));

            RepImpDataAdm.DataBind();


        }
    }
   
    private void LoadDataChart()
    {
        if (hidden.Value != "0")
        {
            RepImpData.DataSource = null;
            RepImpData.DataBind();

            string Case = "";

            int Stats = 1;
            if (Convert.ToInt32(Stat.Value) == 1)
            { Stats = 4;
                Case = "مستوى مخاطر الملاحظات التى لم يحن وقت تنفيذها";
            }
            else if (Convert.ToInt32(Stat.Value) == 3)
            { Stats = 5;
               Case = "مستوى مخاطر الملاحظات المغلقة";
            }
            else if (Convert.ToInt32(Stat.Value) == 5)
            { Stats = 1;
                Case = "مستوى مخاطر الملاحظات المتأخرة";
            }
            else if (Convert.ToInt32(Stat.Value) == 7)
            { Stats = 2;
               Case = "مستوى مخاطر الملاحظات جارى التنفيذ";
            }
            else if (Convert.ToInt32(Stat.Value) == 9)
            { Stats = 3;

               Case = "مستوى مخاطر الملاحظات المعالجة";
            }
            hidden.Value = Obj.ExecuteProcedure3ID("GetChartSecYearCounts", Obj.ExecuteProcedureString("GetSectionByName", HiddenTitle.Value), Stats , Convert.ToInt32(DropYear.SelectedValue)).ToString();

            MainTitle.InnerHtml = "<h3>" +Case +" " +HiddenTitle.Value +"</h3>";
            RepImpData.DataSource = Obj.GetChartImportBySecPlan(Obj.ExecuteProcedureString("GetSectionByName", HiddenTitle.Value), Stats, Convert.ToInt32(DropYear.SelectedValue));

            RepImpData.DataBind();
        }
    }
    private DataTable GetData()
    {


        DataTable dt = new DataTable();

        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "GetAllSectionsChartPlans";
        cmd.Parameters.AddWithValue("@ID", Request.QueryString["Reqq"]);
        cmd.Connection = Obj.Conn;


        SqlDataAdapter adp = new SqlDataAdapter();
        adp.SelectCommand = cmd;

        adp.Fill(dt);

        return dt;


    }
   
    private DataTable GetDataImport()
    {

        DataTable dt = new DataTable();

        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "GetChartByStatPlanChart";
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
        cmd.CommandText = "GetChartReportByStatIDChart";
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

            dt = GetData();



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
                    Status3Txt = "(" + dt.Rows[i]["Status3"].ToString() + ") " + Math.Round(((Convert.ToDouble(dt.Rows[i]["Status3"]) / Convert.ToDouble(dt.Rows[i]["TotalCount"])) * 100), 1).ToString();
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
                    Status2Txt = "(" + dt.Rows[i]["Status2"].ToString() + ") " + Math.Round(((Convert.ToDouble(dt.Rows[i]["Status2"]) / Convert.ToDouble(dt.Rows[i]["TotalCount"])) * 100), 1).ToString();
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
                    Status1Txt = "(" + dt.Rows[i]["Status1"].ToString() + ") " + Math.Round(((Convert.ToDouble(dt.Rows[i]["Status1"]) / Convert.ToDouble(dt.Rows[i]["TotalCount"])) * 100), 1).ToString();
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
                    Status4Txt = "(" + dt.Rows[i]["Status4"].ToString() + ") " + Math.Round(((Convert.ToDouble(dt.Rows[i]["Status4"]) / Convert.ToDouble(dt.Rows[i]["TotalCount"])) * 100), 1).ToString();
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
                    Status5Txt = "(" + dt.Rows[i]["Status5"].ToString() + ") " + Math.Round(((Convert.ToDouble(dt.Rows[i]["Status5"]) / Convert.ToDouble(dt.Rows[i]["TotalCount"])) * 100), 1).ToString();
                }

                str.Append(@"['" + dt.Rows[i]["SectionName"].ToString() + "', " + Status4 + ", '" + Status4Txt + "%" + "', " + Status5 + ",  '" + Status5Txt + "%" + "', " + Status1 + ",  '" + Status1Txt + "%" + "', " + Status2 + ",  '" + Status2Txt + "%" + "', " + Status3 + ",  '" + Status3Txt + "%" + "'],");
            }



            str.Append("]);");



            str.Append("var chart = new google.visualization.ColumnChart(document.getElementById('chart_div'));");
            str.Append("chart.draw(data,{ width:950, height:500,legend: { position: 'none' }, vAxis:{minValue: 4,viewWindow:{ min: 0},format: '0' ,textPosition: 'none' },colors:['#93cdf3','#727aa2','#9C27B0','#FF9800','#4CAF50'], hAxis: {showTextEvery:1, slantedText:false}});");
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


    private void BindImportChart()
    {

        DataTable dtImport = new DataTable();

        try
        {

            dtImport = GetDataImport();



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

                DataSet DSCounts = Obj.GetDataSetBy2ID("GetRepCountByStatPlanNew", Convert.ToInt32(dtImport.Rows[i]["Import"].ToString()) ,Convert.ToInt32(DropYear.SelectedValue));
                if (DSCounts.Tables[0].Rows.Count > 0)
                {
                    for (int k = 0; k < DSCounts.Tables[0].Rows.Count; k++)
                    {
                        Tip = Dv + " المعالج " + " (" + DSCounts.Tables[0].Rows[k]["Status3"].ToString() + ")"  + "<br/>" + "المتبقى " + string.Concat("(", DSCounts.Tables[0].Rows[k]["NotDoneAll"].ToString()) + ")" ;
                    }

                }
                strImport.Append("['" + Level + "', " + Convert.ToInt32(dtImport.Rows[i]["Counts"]) + "," + "'" + Tip + "</div>'" + "],");
            }
            strImport.Append(" ]);");



            strImport.Append(" var chartImport = new google.visualization.PieChart(document.getElementById('chartImport_div'));");

            strImport.Append(" chartImport.draw(dataImport,{'title': '',pieHole: 0.4, 'width': 300, 'height': 300,tooltip: {isHtml: true}, 'backgroundColor': 'transparent',chartArea:{left:2,top:7,width:'85%',height:'85%'}, 'textAlign': 'center', 'colors':['#4CAF50', '#FF9800','#9C27B0'],legend: { position: 'none'}, vAxis:{minValue: 4,viewWindow:{ min: 0},format: '0' }, hAxis: {showTextEvery:1, slantedText:false}});");

            strImport.Append(@"google.visualization.events.addListener(chartImport, 'select', selectHandler123);

  function selectHandler123() {
                    var selectedItem = chartImport.getSelection()[0];
                    if (selectedItem) {");


            strImport.Append("self.location = *Reporting.aspx?ReqY="+DropYear.SelectedValue+"&qq=*+ chartImport.getSelection()[0].row;}}} ");

            strImport.Append("</script>");

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

            dtStat = GetDataStat();



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

            strStat.Append(" chartStat.draw(dataStat,{width:300, height:300,pieHole: 0.4,'textAlign': 'right', chartArea:{left:2,top:7,width:'85%',height:'85%'},legend: {position: 'none' }, vAxis:{minValue: 4,viewWindow:{ min: 0},format: '0' },'colors':['#93cdf3','#727aa2','#9C27B0','#FF9800','#4CAF50'], hAxis: {showTextEvery:1, slantedText:false}});}");



            strStat.Append("</script>");

            LitStat.Text = strStat.ToString().Replace('*', '"');

        }

        catch

        { }



    }

    protected void DropYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropYear.SelectedValue != "0")
        {
            Response.Redirect("MainDashboardGraph02.aspx?Reqq=" + DropYear.SelectedValue);
        }
        else
        {
            Response.Redirect("MainDashboardGraph01.aspx");
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
    protected void BackCharts_Click(object sender, EventArgs e)
    {

        Response.Redirect("MainDashboardGraph02.aspx?Reqq="+DropYear.SelectedValue);


    }
   

   
    protected void RepImpDataAdm_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {

        if (((Label)e.Item.FindControl("LblImpAdm")).Text == "1")
        {
            ((System.Web.UI.HtmlControls.HtmlGenericControl)(e.Item.FindControl("LowValAdm"))).Visible = true;
            ((System.Web.UI.HtmlControls.HtmlGenericControl)(e.Item.FindControl("HighValAdm"))).Visible = false;
            ((System.Web.UI.HtmlControls.HtmlGenericControl)(e.Item.FindControl("MidValAdm"))).Visible = false;
        }
        if (((Label)e.Item.FindControl("LblImpAdm")).Text == "2")
        {
            ((System.Web.UI.HtmlControls.HtmlGenericControl)(e.Item.FindControl("LowValAdm"))).Visible = false;
            ((System.Web.UI.HtmlControls.HtmlGenericControl)(e.Item.FindControl("HighValAdm"))).Visible = false;
            ((System.Web.UI.HtmlControls.HtmlGenericControl)(e.Item.FindControl("MidValAdm"))).Visible = true;
        }
        if (((Label)e.Item.FindControl("LblImpAdm")).Text == "3")
        {
            ((System.Web.UI.HtmlControls.HtmlGenericControl)(e.Item.FindControl("LowValAdm"))).Visible = false;
            ((System.Web.UI.HtmlControls.HtmlGenericControl)(e.Item.FindControl("HighValAdm"))).Visible = true;
            ((System.Web.UI.HtmlControls.HtmlGenericControl)(e.Item.FindControl("MidValAdm"))).Visible = false;
        }



        var Vall = Convert.ToInt32(hiddenAdm.Value);


        if (Vall != 0)
        {
            double a = ((Convert.ToDouble(((Label)e.Item.FindControl("LblCountsAdm")).Text)) * 100 / Vall);
            ((Label)e.Item.FindControl("LblAvgAdm")).Text = Math.Round(a, 2, MidpointRounding.ToEven).ToString() + "%";

        }
    }
    protected void RepImpDataAdm_Disposed(object sender, EventArgs e)
    {
        hiddenAdm.Value = "0";
    }
   
    private DataTable GetDataAdm()
    {
        
        
            DataTable dt = new DataTable();

        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "GetAllAdminsByPlanNoSec";
        cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(DropYear.SelectedValue));
        cmd.Connection = Obj.Conn;


        SqlDataAdapter adp = new SqlDataAdapter();
        adp.SelectCommand = cmd;

        adp.Fill(dt);

        return dt;


    }

    private void BindChartAdm()
    {

        DataTable dt = new DataTable();

        try
        {

            dt = GetDataAdm();



            strAdm.Append(@"<script type=*text/javascript*> google.load( *visualization*, *1*, {packages:[*corechart*]});

            google.setOnLoadCallback(drawChartAdm);

            function drawChartAdm() {

            var dataAdm = new google.visualization.DataTable();

            dataAdm.addColumn('string', 'الإدارة متوسطة');
            dataAdm.addColumn('number', 'لم يحن وقت تنفيذها'); dataAdm.addColumn({'type': 'string', 'role': 'tooltip'});
            dataAdm.addColumn('number', 'مغلقة');  dataAdm.addColumn({'type': 'string', 'role': 'tooltip'});
            dataAdm.addColumn('number', 'متأخرة');  dataAdm.addColumn({'type': 'string', 'role': 'tooltip'});
            dataAdm.addColumn('number', 'جارى التنفيذ');  dataAdm.addColumn({'type': 'string', 'role': 'tooltip'});
            dataAdm.addColumn('number', 'معالجة'); dataAdm.addColumn({'type': 'string', 'role': 'tooltip'});
 dataAdm.addRows([");

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
                    Status3Txt = "(" + dt.Rows[i]["Status3"].ToString() + ") " + Math.Round(((Convert.ToDouble(dt.Rows[i]["Status3"]) / Convert.ToDouble(dt.Rows[i]["TotalCount"])) * 100), 1).ToString();
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
                    Status2Txt = "(" + dt.Rows[i]["Status2"].ToString() + ") " + Math.Round(((Convert.ToDouble(dt.Rows[i]["Status2"]) / Convert.ToDouble(dt.Rows[i]["TotalCount"])) * 100), 1).ToString();
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
                    Status1Txt = "(" + dt.Rows[i]["Status1"].ToString() + ") " + Math.Round(((Convert.ToDouble(dt.Rows[i]["Status1"]) / Convert.ToDouble(dt.Rows[i]["TotalCount"])) * 100), 1).ToString();
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
                    Status4Txt = "(" + dt.Rows[i]["Status4"].ToString() + ") " + Math.Round(((Convert.ToDouble(dt.Rows[i]["Status4"]) / Convert.ToDouble(dt.Rows[i]["TotalCount"])) * 100), 1).ToString();
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
                    Status5Txt = "(" + dt.Rows[i]["Status5"].ToString() + ") " + Math.Round(((Convert.ToDouble(dt.Rows[i]["Status5"]) / Convert.ToDouble(dt.Rows[i]["TotalCount"])) * 100), 1).ToString();
                }

                strAdm.Append(@"['" + dt.Rows[i]["AdmName"].ToString() +  "', " + Status4 + ", '" + Status4Txt + "%" + "', " + Status5 + ",  '" + Status5Txt + "%" + "', " + Status1 + ",  '" + Status1Txt + "%" + "', " + Status2 + ",  '" + Status2Txt + "%" + "', " + Status3 + ",  '" + Status3Txt + "%" + "'],");
            }



            strAdm.Append("]);");



            strAdm.Append("var chartAdm = new google.visualization.ColumnChart(document.getElementById('chartAdm_div'));");
            strAdm.Append("chartAdm.draw(dataAdm,{ width:970, height:500,legend: { position: 'none' }, vAxis:{minValue: 4,viewWindow:{ min: 0},format: '0' , textPosition: 'none' },colors: ['#93cdf3','#727aa2','#9C27B0','#FF9800','#4CAF50'], hAxis: {showTextEvery:1, slantedText:true}});");
            strAdm.Append(@"google.visualization.events.addListener(chartAdm, 'select', selectHandlerAdm);

  function selectHandlerAdm() {
                    var selectedItem = chartAdm.getSelection()[0];
                    if (selectedItem) {
var selection = chartAdm.getSelection();
var message = '';
for (var i = 0; i < selection.length; i++) {
var item = selection[i];
if (item.row != null && item.column != null) {
var str = dataAdm.getFormattedValue(item.row, item.column);
var category = dataAdm
.getValue(chartAdm.getSelection()[0].row, 0)


message += '{row:' + item.row + ',column:' + item.column
+ '} = ' + str ;

HiddenAdm(item.column,str,category);
 ");




            strAdm.Append(@" 
}}
if (message == '') {
message = 'nothing';
}
                        var tooltip = document.getElementsByClassName('google-visualization-tooltip')[0];
                        tooltip.innerHTML = message ;
                    }
                }
               
}");


            strAdm.Append("</script>");

            ltAdm.Text = strAdm.ToString().Replace('*', '"');

        }

        catch

        { }



    }


    protected void SectionCharts_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("SectionsCharts.aspx?Reqq=" + Request.QueryString["Reqq"].ToString());
    }
    protected void AdminsCharts_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("AdminsCharts.aspx?Reqq=" + Request.QueryString["Reqq"].ToString());
    }
}