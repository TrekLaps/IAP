using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MainReportSection : System.Web.UI.Page
{
    Operations Obj = new Operations();
    private void BindAllData()
    {
        if (Session["UData"] != null)
        {
            DataSet MyRecDataSet = (DataSet)Session["UData"];

            EmployeesData.DataSource = Obj.GetDataSetByID("GetMainReportsBySection", Convert.ToInt32(MyRecDataSet.Tables[0].Rows[0]["SectionID"]));
            EmployeesData.DataBind();
        }
    }
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
                if (Obj.ExecuteProcedureID("CheckSectionManger", Convert.ToInt32(MyRecDataSet.Tables[0].Rows[0]["EmpID"])) == 1)
                {
                    

                    MainYear.DataSource = Obj.GetDataSetByID("GetPlansBySection", Convert.ToInt32(MyRecDataSet.Tables[0].Rows[0]["SectionID"]));
                    MainYear.DataTextField ="YearName";
                    MainYear.DataValueField =  "ID";                 
                   
                    MainYear.DataBind();
                    MainDepart.Items.Clear();

                    MainDepart.DataSource = Obj.GetDataSetByID("GetAdministrations", Convert.ToInt32(MyRecDataSet.Tables[0].Rows[0]["SectionID"]));
                    MainDepart.DataTextField = "AdmName";
                    MainDepart.DataValueField = "AdmID";
                    MainDepart.DataBind();
                    ListItem aa0 = new ListItem();
                    aa0.Text = "اختر الإدارة متوسطة";
                    aa0.Value = "0";

                    MainDepart.Items.Insert(0, aa0);

                    BindAllData();

                }
                else
                {
                    Response.Redirect("NoPermissions.aspx");
                }
            }
        }

    }
    protected void MainDepart_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Session["UData"] != null)
        {
            DataSet MyRecDataSet = (DataSet)Session["UData"];

            EmployeesData.DataSource = null;
            EmployeesData.DataBind();
            if (MainDepart.SelectedValue != "0")
            {
                if (MainYear.SelectedValue != "0")
                {
                    EmployeesData.DataSource = Obj.FilterMainReportsAll(Convert.ToInt32(MainYear.SelectedValue), Convert.ToInt32(MyRecDataSet.Tables[0].Rows[0]["SectionID"]), Convert.ToInt32(MainDepart.SelectedValue));
                    EmployeesData.DataBind();
                }
                else
                {
                    EmployeesData.DataSource = Obj.GetDataSetBy2ID("FilterMainReportsAdm", Convert.ToInt32(MyRecDataSet.Tables[0].Rows[0]["SectionID"]), Convert.ToInt32(MainDepart.SelectedValue));
                    EmployeesData.DataBind();
                }
            }
            else
            {
                BindAllData();
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
            MainDepart.Items.Clear();
            MainDepart.DataSource = Obj.GetDataSetBy2ID("GetAdminByYear", Convert.ToInt32(MyRecDataSet.Tables[0].Rows[0]["SectionID"]), Convert.ToInt32(MainYear.SelectedValue));
            MainDepart.DataTextField = "AdmName";
            MainDepart.DataValueField = "AdmID";
            MainDepart.DataBind();

            ListItem aa = new ListItem();
            aa.Text = "اختر الإدارة متوسطة";
            aa.Value = "0";

            MainDepart.Items.Insert(0, aa);

            EmployeesData.DataSource = null;
            EmployeesData.DataBind();
            EmployeesData.DataSource = Obj.FilterMainReportsSector(Convert.ToInt32(MainYear.SelectedValue), Convert.ToInt32(MyRecDataSet.Tables[0].Rows[0]["SectionID"]));
            EmployeesData.DataBind();
        }
        else
        {
            MainDepart.Items.Clear();
            MainDepart.DataSource = Obj.GetDataSetByID("GetAdministrations", Convert.ToInt32(MyRecDataSet.Tables[0].Rows[0]["SectionID"]));
            MainDepart.DataTextField = "AdmName";
            MainDepart.DataValueField = "AdmID";
            MainDepart.DataBind();
            ListItem aa = new ListItem();
            aa.Text = "اختر الإدارة متوسطة";
            aa.Value = "0";

            MainDepart.Items.Insert(0, aa);
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