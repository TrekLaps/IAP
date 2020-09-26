using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.DataVisualization.Charting;

public partial class PieDashboard01 : System.Web.UI.Page
{
    Operations Obj = new Operations();
     

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            if (Session["UData"] != null)
            {
                DataSet MyRecDataSet = (DataSet)Session["UData"];


                if ((Convert.ToBoolean(MyRecDataSet.Tables[0].Rows[0]["SystemAdmin"]) == true)|| (Convert.ToBoolean(MyRecDataSet.Tables[0].Rows[0]["ApprovPermission"]) == true))
                {/// Log Data Start

                    String Users = "Governorate";

                    if (Convert.ToBoolean(MyRecDataSet.Tables[0].Rows[0]["ApprovPermission"]) == true)
                    {
                        Users = "Internal Audit";
                    }
                    else if (Convert.ToBoolean(MyRecDataSet.Tables[0].Rows[0]["SystemAdmin"]) == true)
                    {
                        Users = "System Administrator";
                    }
                    Obj.ExecuteProcedureStringID("NewLogTable", Convert.ToInt32(MyRecDataSet.Tables[0].Rows[0]["EmpID"]), "View Sections Notes and Recommendations Charts by " + Users + "Permission");

                    /// Log Data End
                    DropYear.Items.Clear();
                    DropYear.DataSource = Obj.GetDataSet("GetPlans");
                    DropYear.DataTextField = "YearName";
                    DropYear.DataValueField = "ID";
                    DropYear.DataBind();

                    ListItem aa = new ListItem("جميع السنوات", "0");

                    DropYear.Items.Insert(0, aa);
                    DropYear.SelectedItem.Value = "0";


                    Admins.DataSource  = Obj.GetDataSet("GetSectionsDashboard");
                    Admins.DataTextField  = "SectionName";
                    Admins.DataValueField = "SectionID";
                    Admins.DataBind();
                    
                    ListItem aaSection = new ListItem
                    {
                        Text = "اختر الإدارة العليا",
                        Value = ""
                    };

                    Admins.Items.Insert(0, aaSection);



                }

                else
                {
                    Response.Redirect("NoPermissions.aspx");
                }
            }
        }
    }



    protected void Admins_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Admins.SelectedValue != "")
        {
            Response.Redirect("PieDashboard02.aspx?ReqYR=" + DropYear.SelectedValue + "&Reqq=" + Admins.SelectedValue);

        }
        else
        {


            NoRep.Visible = true;
        }

    }

    protected void DropYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropYear.SelectedValue != "0")
        {
            if (Session["UData"] != null)
            {
                DataSet MyRecDataSet = (DataSet)Session["UData"];


                if ((Convert.ToBoolean(MyRecDataSet.Tables[0].Rows[0]["SystemAdmin"]) == true) || (Convert.ToBoolean(MyRecDataSet.Tables[0].Rows[0]["ApprovPermission"]) == true))
                {

                    Admins.Items.Clear();
                    Admins.DataSource = Obj.GetDataSetByID("GetPlansSection", Convert.ToInt32(DropYear.SelectedValue));
                    Admins.DataTextField = "SectionName";
                    Admins.DataValueField = "SectionID";
                    Admins.DataBind();
                    ListItem Lst = new ListItem("اختر إدارة عليا", "0");
                 
                    Admins.Items.Insert(0, "");
                    Admins.Items.Insert(1, Lst);

                    Admins.SelectedValue = "0";
                }


                else
                {
                    DataSet DSSections = Obj.GetDataSetByID("GetSectionsByManager", Convert.ToInt32(MyRecDataSet.Tables[0].Rows[0]["EmpID"]));
                    if (DSSections.Tables[0].Rows.Count > 0)
                    {

                        Response.Redirect("PieDashboard02.aspx?ReqYR="+DropYear.SelectedValue+"&Reqq=" + MyRecDataSet.Tables[0].Rows[0]["SectionID"]);




                    }
                }
            }
        }
    }
}


