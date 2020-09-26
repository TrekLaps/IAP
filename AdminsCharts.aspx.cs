using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Text;

public partial class AdminsCharts : System.Web.UI.Page
{
    Operations Obj = new Operations();
    StringBuilder strImportByAdm = new StringBuilder();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["Reqq"] != "" && Request.QueryString["Reqq"] != null)
            {
                DataSet ds = Obj.GetDataSetByID("GetAllAdminsByPlanNoSec", Convert.ToInt32(Request.QueryString["Reqq"]));
                AdminsChartsList.DataSource = ds;
                AdminsChartsList.DataBind();
            }
            else
            {
                DataSet ds = Obj.GetDataSet("GetAllAdmins");
                AdminsChartsList.DataSource = ds;
                AdminsChartsList.DataBind();
            }
        }
    }
    private DataTable GetDataImportByAdm02(string Adm)
    {

        DataTable dt = new DataTable();

        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;

        if (Request.QueryString["Reqq"] != "" && Request.QueryString["Reqq"] != null)
        {
            cmd.CommandText = "GetChartByAdminPlanImport";
            cmd.Parameters.AddWithValue("@Plan", Convert.ToInt32(Request.QueryString["Reqq"]));
            cmd.Parameters.AddWithValue("@Admin", Convert.ToInt32(Adm));
        }
        else
        {
            cmd.CommandText = "GetChartByAdmin";
            cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(Adm));
        }

        cmd.Connection = Obj.Conn;


        SqlDataAdapter adp = new SqlDataAdapter();
        adp.SelectCommand = cmd;

        adp.Fill(dt);

        return dt;


    }
    protected void AdminsChartsList_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        DataTable dtImport = new DataTable();

        try
        {

            dtImport = GetDataImportByAdm02(((Label)e.Item.FindControl("RepAdms")).Text);



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


                strImportByAdm.Append("dataImport.setValue( " + i + "," + 0 + "," + "'" + Level + "');");

                strImportByAdm.Append("dataImport.setValue(" + i + "," + 1 + "," + dtImport.Rows[i]["Counts"].ToString() + ") ;");



            }





            strImportByAdm.Append(" var chartImport = new google.visualization.PieChart(document.getElementById('Admins" + ((Label)e.Item.FindControl("RepAdms")).Text + "'));");

            strImportByAdm.Append(" chartImport.draw(dataImport,{'title': '',pieHole: 0.4, 'width': 450, 'height': 300, 'backgroundColor': 'transparent',chartArea : {width:'65%',height:'60%'}, 'textAlign': 'right', 'colors': ['#4CAF50', '#FF9800', '#9C27B0'],legend: { position: 'none'}, vAxis: {minValue: 4,viewWindow:{ min: 0},format: '0' }, hAxis: {showTextEvery:1, slantedText:false}});}");


            strImportByAdm.Append("</script>");

            ((Literal)e.Item.FindControl("LtAdm")).Text = strImportByAdm.ToString().Replace('*', '"');

        }

        catch

        { }




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