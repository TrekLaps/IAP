using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Text;

public partial class SectionsCharts : System.Web.UI.Page
{
    Operations Obj = new Operations();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["Reqq"] != "" && Request.QueryString["Reqq"] != null)
            {
                AdminsListAll.DataSource = Obj.GetDataSetByID("GetAllSectionsChartPlans", Convert.ToInt32(Request.QueryString["Reqq"]));

                AdminsListAll.DataBind();
            }
            else
            {
                AdminsListAll.DataSource = Obj.GetDataSet("GetAllSectionsChart");

                AdminsListAll.DataBind();
            }
        }
    }
    private DataTable GetDataImportByAdm(string Adm)
    {

        DataTable dt = new DataTable();

        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        if (Request.QueryString["Reqq"] != "" && Request.QueryString["Reqq"] != null)
        {
            cmd.CommandText = "GetChartBySectionPlanChart";
            cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(Adm));
            cmd.Parameters.AddWithValue("@ID2", Convert.ToInt32(Request.QueryString["Reqq"]));
        }
        else
        {
            cmd.CommandText = "GetChartBySectionChart";
            cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(Adm));
        }
        cmd.Connection = Obj.Conn;


        SqlDataAdapter adp = new SqlDataAdapter();
        adp.SelectCommand = cmd;

        adp.Fill(dt);

        return dt;



    }

    protected void AdminsListAll_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        StringBuilder STT = new StringBuilder();




        DataTable dtImport = new DataTable();



        dtImport = GetDataImportByAdm(((Label)e.Item.FindControl("RepSection")).Text);



        STT.Append(@"<script type=*text/javascript*> google.load( *visualization*, *1*, {packages:[*corechart*]});

            google.setOnLoadCallback(drawChartImportByAdm);

            function drawChartImportByAdm() {

            var dataImport = new google.visualization.DataTable();

            dataImport.addColumn('string', 'مستوى الأهمية');
            dataImport.addColumn('number', 'Counts');
            dataImport.addRows(" + dtImport.Rows.Count + ");");

        string Level = "";

        for (int i = 0; i <= dtImport.Rows.Count - 1; i++)
        {
            if (dtImport.Rows[i]["Importance"].ToString() == "3")
            {
                Level = "مرتفعة";
            }
            else if (dtImport.Rows[i]["Importance"].ToString() == "2")
            {
                Level = "متوسطة";
            }
            else if (dtImport.Rows[i]["Importance"].ToString() == "1")
            {
                Level = "منخفضة";
            }


            STT.Append("dataImport.setValue( " + i + "," + 0 + "," + "'" + Level + "');");

            STT.Append("dataImport.setValue(" + i + "," + 1 + "," + dtImport.Rows[i]["Counts"].ToString() + ") ;");



        }





        STT.Append(" var chartImport = new google.visualization.PieChart(document.getElementById('Section" + ((Label)e.Item.FindControl("RepSection")).Text + "'));");

        STT.Append(" chartImport.draw(dataImport,{'title': '',pieHole: 0.4, 'width': 450, 'height': 300, 'backgroundColor': 'transparent',chartArea : {left:5,top:7,width:'75%',height:'75%'}, 'textAlign': 'center', 'colors': ['#4CAF50', '#FF9800', '#9C27B0'],legend: { position: 'none'}, vAxis: {minValue: 4,viewWindow:{ min: 0},format: '0' }, hAxis: {showTextEvery:1, slantedText:false}});}");


        STT.Append("</script>");

        ((Literal)e.Item.FindControl("Lt")).Text = STT.ToString().Replace('*', '"');




    }
    protected void BackCharts_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["Reqq"] != "" && Request.QueryString["Reqq"] != null)
        {
            Response.Redirect("MainDashboardGraph02.aspx?Reqq=" + Request.QueryString["Reqq"]);
        }
        else
        {
            Response.Redirect("MainDashboardGraph01.aspx");

        }
    }

}