using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MainReportNewAdm : System.Web.UI.Page
{
    Operations Obj = new Operations();
    private void BindAllData()
    {
        if (Session["UData"] != null)
        {
            DataSet MyRecDataSet = (DataSet)Session["UData"];

            EmployeesData.DataSource = Obj.GetDataSetByID("GetMainReportsByAdm", Convert.ToInt32(MyRecDataSet.Tables[0].Rows[0]["AdmID"]));
            EmployeesData.DataBind();
        } }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["UData"] != null)
            {
                DataSet MyRecDataSet = (DataSet)Session["UData"];

                CloseAll();
                Main.Attributes.Remove("Style");
                Main.Style.Add("display", "block");
                if (Obj.ExecuteProcedureID("CheckAdminManger", Convert.ToInt32(MyRecDataSet.Tables[0].Rows[0]["EmpID"])) == 1)
                {
                    

                    MainYear.DataSource =   Obj.GetDataSetByID("GetPlansByAdmin", Convert.ToInt32(MyRecDataSet.Tables[0].Rows[0]["AdmID"]));
                    MainYear.DataTextField ="YearName";
                    MainYear.DataValueField =  "ID";
                   
                   
                    MainYear.DataBind();
                    BindAllData();

                }
                else
                {
                    Response.Redirect("NoPermissions.aspx");
                }
            }
        }

    }

    private void CloseAll()
    {
        BindAllData();
        Main.Attributes.Remove("Style");
        Main.Style.Add("display", "none");

       

    }
  

   


   
  
    protected void MainYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet MyRecDataSet = (DataSet)Session["UData"];

        // Fill dropdown Lists For Reports Sections تبعا للسنة
        if (MainYear.SelectedValue != "0")
        {
            EmployeesData.DataSource = null;
            EmployeesData.DataBind();
            EmployeesData.DataSource = Obj.GetDataSetBy2ID("FilterMainReportsYearByAdm", Convert.ToInt32(MainYear.SelectedValue), Convert.ToInt32(MyRecDataSet.Tables[0].Rows[0]["AdmID"]));
            EmployeesData.DataBind();
        }
        else
        {
            BindAllData();
        }
    }

    



    protected void BackCharts_Click(object sender, EventArgs e)
    {
        CloseAll();
        Main.Attributes.Remove("Style");
        Main.Style.Add("display", "block");
    }
}