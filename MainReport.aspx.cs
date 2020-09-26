using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MainReport : System.Web.UI.Page
{
    Operations Obj = new Operations();
    private void BindAllData()
    {
        EmployeesData.DataSource = Obj.GetDataSet("GetMainReports");
        EmployeesData.DataBind();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["UData"] != null)
            {
                DataSet MyRecDataSet = (DataSet)Session["UData"];

               
              
                if (Convert.ToBoolean(MyRecDataSet.Tables[0].Rows[0]["Gov"]) == true)
                {

                    MainYear.DataSource = Obj.GetDataSet("GetPlans");
                    MainYear.DataTextField = "YearName";
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

    protected void MainSector_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (MainSector.SelectedValue != "")
        {
            if (MainYear.SelectedValue != "0")
            {
                ListItem aa = new ListItem();
                aa.Text = "اختر الادارة";
                aa.Value = "0";
                MainDepart.Items.Clear();
                MainDepart.Items.Insert(0, aa);

                MainDepart.DataSource = Obj.GetPlansAdmins(Convert.ToInt32(MainYear.SelectedValue), Convert.ToInt32(MainSector.SelectedValue));

                MainDepart.DataTextField = "AdmName";
                MainDepart.DataValueField = "AdmID";
                MainDepart.DataBind();
                EmployeesData.DataSource = null;
                EmployeesData.DataBind();
                EmployeesData.DataSource = Obj.FilterMainReportsSector(Convert.ToInt32(MainYear.SelectedValue), Convert.ToInt32(MainSector.SelectedValue));
                EmployeesData.DataBind();
            }
        }
        else { BindAllData(); }
    }

    protected void MainYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Fill dropdown Lists For Reports Sections تبعا للسنة
        if (MainYear.SelectedValue != "0")
        {
            MainSector.Items.Clear();
            MainSector.DataSource = Obj.GetDataSetByID("GetPlansSection", Convert.ToInt32(MainYear.SelectedValue));
            MainSector.DataTextField = "SectionName";
            MainSector.DataValueField = "SectionID";
            MainSector.DataBind();
            ListItem aa = new ListItem();
            aa.Text = "اختر الإدارة العليا";
            aa.Value = "0";
            MainSector.Items.Insert(0, aa);
            MainSector.SelectedValue = "0";
            EmployeesData.DataSource = null;
            EmployeesData.DataBind();
            EmployeesData.DataSource = Obj.GetDataSetByID("FilterMainReportsYear", Convert.ToInt32(MainYear.SelectedValue));
            EmployeesData.DataBind();
        }
        else { BindAllData(); }
    }

    protected void MainDepart_SelectedIndexChanged(object sender, EventArgs e)
    {if (MainDepart.SelectedValue != "0")
        {
            EmployeesData.DataSource = null;
            EmployeesData.DataBind();
            EmployeesData.DataSource = Obj.FilterMainReportsAll(Convert.ToInt32(MainYear.SelectedValue), Convert.ToInt32(MainSector.SelectedValue), Convert.ToInt32(MainDepart.SelectedValue));
            EmployeesData.DataBind();
        }
        else { BindAllData(); }
    }


    
}
