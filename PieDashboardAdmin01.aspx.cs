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


public partial class PieDashboardAdmin01 : System.Web.UI.Page
{
    Operations Obj = new Operations();



    protected void MainSector_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (MainSector.SelectedValue != "")
        {
            if (MainYear.SelectedValue != "0")
            {
                MainDepart.Items.Clear();

                MainDepart.DataSource = Obj.GetPlansAdmins(Convert.ToInt32(MainYear.SelectedValue), Convert.ToInt32(MainSector.SelectedValue));

                MainDepart.DataTextField = "AdmName";
                MainDepart.DataValueField = "AdmID";
                MainDepart.DataBind();
                ListItem aa = new ListItem();
                aa.Text = "اختر الادارة";
                aa.Value = "0";
               
                MainDepart.Items.Insert(0, aa);

            }
            else
            {
                MainDepart.Items.Clear();

                MainDepart.DataSource = Obj.GetDataSetByID("GetAdministrations", Convert.ToInt32(MainSector.SelectedValue));

                MainDepart.DataTextField = "AdmName";
                MainDepart.DataValueField = "AdmID";
                MainDepart.DataBind();
                ListItem aa = new ListItem();
                aa.Text = "اختر الادارة";
                aa.Value = "0";

                MainDepart.Items.Insert(0, aa);

            }
        }
    }

    protected void MainYear_SelectedIndexChanged(object sender, EventArgs e)
    { DataSet MyRecDataSet = (DataSet)Session["UData"];
        // Fill dropdown Lists For Reports Sections تبعا للسنة
        if (MainYear.SelectedValue != "0")
        {
            if ((Convert.ToBoolean(MyRecDataSet.Tables[0].Rows[0]["SystemAdmin"]) == true) || (Convert.ToBoolean(MyRecDataSet.Tables[0].Rows[0]["ApprovPermission"]) == true))
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

            }
           
        }
    }

    protected void MainDepart_SelectedIndexChanged(object sender, EventArgs e)
    {

        Response.Redirect("PieDashboardAdminMang.aspx?S="+ MainSector.SelectedValue + "&ReqY=" + MainYear.SelectedValue + "&Reqq=" + MainDepart.SelectedValue);

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UData"] != null)
        {
            DataSet MyRecDataSet = (DataSet)Session["UData"];


            if (!IsPostBack)
            {

                if ((Convert.ToBoolean(MyRecDataSet.Tables[0].Rows[0]["SystemAdmin"]) == true) || (Convert.ToBoolean(MyRecDataSet.Tables[0].Rows[0]["ApprovPermission"]) == true))
                {
                    /// Log Data Start

                    String Users = "Governorate";

                    if (Convert.ToBoolean(MyRecDataSet.Tables[0].Rows[0]["ApprovPermission"]) == true)
                    {
                        Users = "Internal Audit";
                    }
                    else if (Convert.ToBoolean(MyRecDataSet.Tables[0].Rows[0]["SystemAdmin"]) == true)
                    {
                        Users = "System Administrator";
                    }
                    Obj.ExecuteProcedureStringID("NewLogTable", Convert.ToInt32(MyRecDataSet.Tables[0].Rows[0]["EmpID"]), "View Departments Notes and Recommendations Charts by " + Users + "Permission");

                    /// Log Data End
                    /// 
                    MainYear.DataSource = Obj.GetDataSet("GetPlans");
                    MainYear.DataTextField = "YearName";
                    MainYear.DataValueField = "ID";

                    MainYear.DataBind();

                    if (Request.QueryString["ReqY"] != null)
                    {
                        MainYear.SelectedValue = Request.QueryString["ReqY"];
                    }

                    MainSector.DataSource = Obj.GetDataSet("GetSectionsDashboard");
                    MainSector.DataTextField = "SectionName";
                    MainSector.DataValueField = "SectionID";
                    MainSector.DataBind();

                    ListItem aaSection = new ListItem
                    {
                        Text = "اختر الإدارة العليا",
                        Value = ""
                    };

                    MainSector.Items.Insert(0, aaSection);

                }

                else if (Obj.ExecuteProcedureID("CheckAdminManger", Convert.ToInt32(MyRecDataSet.Tables[0].Rows[0]["EmpID"])) == 1)
                {


                    MainYear.DataSource = Obj.GetDataSetByID("GetPlansByAdmin" , Convert.ToInt32(MyRecDataSet.Tables[0].Rows[0]["AdmID"]));
                    MainYear.DataTextField = "YearName";
                    MainYear.DataValueField = "ID";

                    MainYear.DataBind();

                    if (Request.QueryString["ReqY"] != null)
                    {
                        MainYear.SelectedValue = Request.QueryString["ReqY"];
                    }

                    Sections.Attributes.Remove("style");
                    Sections.Attributes.Add("style", "display:none");

                    Adms.Attributes.Remove("style");
                    Adms.Attributes.Add("style", "display:none");
                }
                else
                {
                    Response.Redirect("NoPermissions.aspx");
                }
            }

        }
    }





}