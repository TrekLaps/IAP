using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Data.OleDb;

public partial class AdminsCharts01 : System.Web.UI.Page
{
    Operations Obj = new Operations();
    StringBuilder strImportByAdm = new StringBuilder();
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
             DataTable dtImport = new DataTable();

        try
        {

            dtImport = GetDataImportByAdm02();



            strImportByAdm.Append(@"<script type=*text/javascript*> google.load( *visualization*, *1*, {packages:[*corechart*]});

            google.setOnLoadCallback(drawChartImportByAdm);

            function drawChartImportByAdm() {

            var dataImport = new google.visualization.DataTable();

            dataImport.addColumn('string', 'مستوى الأهمية');
            dataImport.addColumn('number', 'Counts');
            dataImport.addRows(" + dtImport.Rows.Count + ");");

            string Level = "";

            for (int i = 0; i <= dtImport.Rows.Count - 1; i++)
            {
                if (dtImport.Rows[i]["Import"].ToString() == "3")
                {
                    Level = "مرتفعة";
                }
                else if (dtImport.Rows[i]["Import"].ToString() == "2")
                {
                    Level = "متوسطة";
                }
                else if (dtImport.Rows[i]["Import"].ToString() == "1")
                {
                    Level = "منخفضة";
                }


                strImportByAdm.Append("dataImport.setValue( " + i + "," + 0 + "," + "'" + Level + "');");

                strImportByAdm.Append("dataImport.setValue(" + i + "," + 1 + "," + dtImport.Rows[i]["Counts"].ToString() + ") ;");



            }





            strImportByAdm.Append(" var chartImport = new google.visualization.PieChart(document.getElementById('Admins'));");

                strImportByAdm.Append(" chartImport.draw(dataImport,{'title': '', 'width': 300, 'height': 300,tooltip: {isHtml: true}, 'backgroundColor': 'transparent',chartArea:{top:7,left:5,width:'75%',height:'75%'}, 'textAlign': 'center', 'colors': ['#4CAF50', '#FF9800', '#9C27B0'],legend: { position: 'none'}, vAxis:{minValue: 4,viewWindow:{ min: 0},format: '0' }, hAxis: {showTextEvery:1, slantedText:false}});");


                strImportByAdm.Append("</script>");

            LtAdm.Text = strImportByAdm.ToString().Replace('*', '"');

        }

        catch

        { }


        }
    }
    private DataTable GetDataImportByAdm02()
    {

        DataTable dt = new DataTable();

        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;

        if (Request.QueryString["pln"] != "" && Request.QueryString["pln"] != null)
        {
            cmd.CommandText = "GetChartByStatAdminChart";
            cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(Request.QueryString["Plan"]));
            cmd.Parameters.AddWithValue("@ID2", Convert.ToInt32(Request.QueryString["Adm"]));
        }
        else if (Request.QueryString["Adm"] != "" && Request.QueryString["Adm"] != null)
        {
            cmd.CommandText = "GetChartByStatChartAdmin";
            cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(Request.QueryString["Adm"]));
        }

        cmd.Connection = Obj.Conn;


        SqlDataAdapter adp = new SqlDataAdapter();
        adp.SelectCommand = cmd;

        adp.Fill(dt);

        return dt;


    }
    
    protected void BackCharts_Click(object sender, EventArgs e)
    {

        Response.Redirect("PieDashboardAdmin.aspx");
    }
   
}