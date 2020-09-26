using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Web.UI.HtmlControls;

public partial class ReportsAll : System.Web.UI.Page
{
    Operations Obj = new Operations();
    StringBuilder strImportByAdm = new StringBuilder();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            if (Session["UData"] != null)
            {
                DataSet MyRecDataSet = (DataSet)Session["UData"];
                if (Convert.ToBoolean(MyRecDataSet.Tables[0].Rows[0]["Gov"]) == true || Convert.ToBoolean(MyRecDataSet.Tables[0].Rows[0]["SystemAdmin"]) == true)
                {

                    RepYears.DataSource = YearList.DataSource = Obj.GetDataSet("ReportAllYears");
                    YearList.DataBind();
                    RepYears.DataBind();

                    YearList.DataTextField = "YearName";
                    YearList.DataValueField = "ID";
                    YearList.DataBind();



                }
                else if (Obj.ExecuteProcedureID("CheckSectionManger", Convert.ToInt32(MyRecDataSet.Tables[0].Rows[0]["EmpID"])) == 1)
                {
                    Sections.Attributes.Remove("style");
                    Sections.Attributes.Add("style", "display:none");

                    RepYears.DataSource = YearList.DataSource = Obj.GetDataSetByID("GetPlansBySection", Convert.ToInt32(MyRecDataSet.Tables[0].Rows[0]["SectionID"]));
                    YearList.DataBind();
                    RepYears.DataBind();

                    YearList.DataTextField = "YearName";
                    YearList.DataValueField = "ID";
                    YearList.DataBind();
                }

                else
                {
                    Response.Redirect("NoPermissions.aspx");
                }
            }
        }

        else
        {
            if (HiddenYear.Value == "1")
            {
                DataSet MyRecDataSet = (DataSet)Session["UData"];

                if (YearList.SelectedIndex == -1)
                {
                    SectorList.Items.Clear();
                    AdminList.Items.Clear();
                    RepYears.DataSource = null;
                    RepYears.DataBind();

                    RepYears.DataSource = Obj.GetDataSet("ReportAllYears");
                    RepYears.DataBind();

                }
                else
                {
                    for (int i = 0; i <= YearList.Items.Count - 1; i++)
                    {
                        if (YearList.Items[i].Selected == true)
                        {
                            // Fill dropdown Lists For Reports Sections تبعا للسنة


                            RepYears.DataSource = null;
                            RepYears.DataBind();
                            RepYears.DataSource = Obj.GetDataSetByID("ReportOneYearAll", Convert.ToInt32(YearList.Items[i].Value));
                            RepYears.DataBind();

                            if (Convert.ToBoolean(MyRecDataSet.Tables[0].Rows[0]["Gov"]) == true || Convert.ToBoolean(MyRecDataSet.Tables[0].Rows[0]["SystemAdmin"]) == true)
                            {



                                SectorList.DataSource = null;
                                SectorList.DataBind();
                                SectorList.DataSource = Obj.GetDataSetByID("ReportSectionsAllStatusYear", Convert.ToInt32(YearList.Items[i].Value));
                                SectorList.DataTextField = "SectionName";
                                SectorList.DataValueField = "SectionID";
                                SectorList.DataBind();
                            }
                            else if (Obj.GetDataSetByID("GetSectionsByManager", Convert.ToInt32(MyRecDataSet.Tables[0].Rows[0]["EmpID"])).Tables[0].Rows.Count > 0)
                            {

                            }

                        }
                    }
                }
                HiddenYear.Value = "0";
            }
            if (HiddenSector.Value == "1")
            {

                for (int i = 0; i <= SectorList.Items.Count - 1; i++)
                {
                    if (SectorList.Items[i].Selected == true)
                    {
                        for (int j = 0; j <= YearList.Items.Count - 1; j++)
                        {
                            if (YearList.Items[j].Selected == true)
                            {
                                RepYears.DataSource = null;
                                RepYears.DataBind();
                                RepYears.DataSource = Obj.GetDataSetByID("ReportOneYearAll", Convert.ToInt32(YearList.Items[j].Value));
                                RepYears.DataBind();
                                AdminList.DataSource = null;
                                AdminList.DataBind();

                                AdminList.DataSource = Obj.GetDataSetBy2ID("RepAllAdminsByStatIDYear", Convert.ToInt32(YearList.Items[j].Value), Convert.ToInt32(SectorList.Items[i].Value));
                                AdminList.DataTextField = "AdmName";
                                AdminList.DataValueField = "AdmID";
                                AdminList.DataBind();
                            }
                        }
                    }
                }
                HiddenSector.Value = "0";
            }


        }
    }
    protected void BackCharts_Click(object sender, EventArgs e)
    {

        Response.Redirect("PieDashboard01.aspx");
    }

    protected void RepReports_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {

        if (((Label)e.Item.FindControl("SectionID")).Text != "")
        {
            if (AdminList.Items.Count > 0)
            {
                for (int i = 0; i <= AdminList.Items.Count - 1; i++)
                {
                    if (AdminList.Items[i].Selected == true)
                    {

                        ((Repeater)e.Item.FindControl("RepAdmins")).DataSource = Obj.GetDataSetBy3ID("ReportAdminsPlanAllAdm", Convert.ToInt32(((Label)e.Item.FindControl("SectionID")).Text), Convert.ToInt32(((Label)e.Item.FindControl("PlanID")).Text), Convert.ToInt32(AdminList.Items[i].Value));
                        ((Repeater)e.Item.FindControl("RepAdmins")).DataBind();
                    }
                }
            }
            else
            {
                ((Repeater)e.Item.FindControl("RepAdmins")).DataSource = Obj.GetDataSetBy2ID("ReportAdminsPlanAll", Convert.ToInt32(((Label)e.Item.FindControl("SectionID")).Text), Convert.ToInt32(((Label)e.Item.FindControl("PlanID")).Text));
                ((Repeater)e.Item.FindControl("RepAdmins")).DataBind();
            }
        }
    }
    protected void RepAdmins_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (AdminList.Items.Count > 0)
        {
            for (int i = 0; i <= AdminList.Items.Count - 1; i++)
            {
                if (AdminList.Items[i].Selected == true)
                {
                    ((Repeater)e.Item.FindControl("PreviewReports")).DataSource = Obj.GetDataSetBy4ID("ReadRepwithStatusAll", Convert.ToInt32(((Label)e.Item.FindControl("SectID")).Text), Convert.ToInt32(((Label)e.Item.FindControl("PlnIDRep")).Text), Convert.ToInt32(AdminList.Items[i].Value), Convert.ToInt32(MainStatus.SelectedValue == "" ? "0" : MainStatus.SelectedValue));
                    ((Repeater)e.Item.FindControl("PreviewReports")).DataBind();
                }
            }
        }
        else
        {
            ((Repeater)e.Item.FindControl("PreviewReports")).DataSource = Obj.GetDataSetBy3ID("ReadReportsAll", Convert.ToInt32(((Label)e.Item.FindControl("SectID")).Text), Convert.ToInt32(((Label)e.Item.FindControl("PlnIDRep")).Text), Convert.ToInt32(((Label)e.Item.FindControl("DepartID")).Text));
            ((Repeater)e.Item.FindControl("PreviewReports")).DataBind();
        }

    }
    protected void RepNotes_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (((Literal)e.Item.FindControl("LitCorrect")).Text != "")
        {
            ((Literal)e.Item.FindControl("LitCorrect")).Text = Obj.GetTextFromHTML(System.Net.WebUtility.HtmlDecode(((Literal)e.Item.FindControl("LitCorrect")).Text));
        }

        if (((Literal)e.Item.FindControl("LitNotText")).Text != "")
        {
            ((Literal)e.Item.FindControl("LitNotText")).Text = Obj.GetTextFromHTML(System.Net.WebUtility.HtmlDecode(((Literal)e.Item.FindControl("LitNotText")).Text));
        }

        if (((Label)e.Item.FindControl("NotStat")).Text == "3")
        {
            ((HtmlControl)e.Item.FindControl("Done")).Visible = true;
            ((HtmlControl)e.Item.FindControl("SemiDone")).Visible = false;
            ((HtmlControl)e.Item.FindControl("NoteDone")).Visible = false;
            ((HtmlControl)e.Item.FindControl("NoteNow")).Visible = false;
            ((HtmlControl)e.Item.FindControl("Closed")).Visible = false;

        }
        else if (((Label)e.Item.FindControl("NotStat")).Text == "2")
        {
            ((HtmlControl)e.Item.FindControl("Done")).Visible = false;
            ((HtmlControl)e.Item.FindControl("SemiDone")).Visible = true;
            ((HtmlControl)e.Item.FindControl("NoteDone")).Visible = false;
            ((HtmlControl)e.Item.FindControl("NoteNow")).Visible = false;
            ((HtmlControl)e.Item.FindControl("Closed")).Visible = false;

        }
        else if (((Label)e.Item.FindControl("NotStat")).Text == "4")
        {


            ((HtmlControl)e.Item.FindControl("Done")).Visible = false;
            ((HtmlControl)e.Item.FindControl("SemiDone")).Visible = false;
            ((HtmlControl)e.Item.FindControl("NoteDone")).Visible = false;
            ((HtmlControl)e.Item.FindControl("NoteNow")).Visible = true;
            ((HtmlControl)e.Item.FindControl("Closed")).Visible = false;

        }
        else if (((Label)e.Item.FindControl("NotStat")).Text == "1")
        {
            ((HtmlControl)e.Item.FindControl("Done")).Visible = false;
            ((HtmlControl)e.Item.FindControl("SemiDone")).Visible = false;
            ((HtmlControl)e.Item.FindControl("NoteDone")).Visible = true;
            ((HtmlControl)e.Item.FindControl("NoteNow")).Visible = false;
            ((HtmlControl)e.Item.FindControl("Closed")).Visible = false;

        }
        else if (((Label)e.Item.FindControl("NotStat")).Text == "5")
        {

            ((HtmlControl)e.Item.FindControl("Done")).Visible = false;
            ((HtmlControl)e.Item.FindControl("SemiDone")).Visible = false;
            ((HtmlControl)e.Item.FindControl("NoteDone")).Visible = false;
            ((HtmlControl)e.Item.FindControl("NoteNow")).Visible = false;
            ((HtmlControl)e.Item.FindControl("Closed")).Visible = true;

        }
    }

    protected void RepYears_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (((Label)e.Item.FindControl("YearID")).Text != "")
        {
            DataSet MyRecDataSet = (DataSet)Session["UData"];


            if (Obj.GetDataSetByID("GetSectionsByManager", Convert.ToInt32(MyRecDataSet.Tables[0].Rows[0]["EmpID"])).Tables[0].Rows.Count > 0)
            {


                ((Repeater)e.Item.FindControl("RepReports")).DataSource = Obj.GetDataSetBy2ID("RepSectAllByStatIDYear", Convert.ToInt32(((Label)e.Item.FindControl("YearID")).Text), Convert.ToInt32(MyRecDataSet.Tables[0].Rows[0]["SectionID"]));
                ((Repeater)e.Item.FindControl("RepReports")).DataBind();

            }
            else if (Convert.ToBoolean(MyRecDataSet.Tables[0].Rows[0]["Gov"]) == true || Convert.ToBoolean(MyRecDataSet.Tables[0].Rows[0]["SystemAdmin"]) == true)
            {
                ((Repeater)e.Item.FindControl("RepReports")).DataSource = Obj.GetDataSetByID("ReportSecAllByStatYear", Convert.ToInt32(((Label)e.Item.FindControl("YearID")).Text));
                ((Repeater)e.Item.FindControl("RepReports")).DataBind();
            }
        }
    }


    protected void MainStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        for (int i = 0; i <= YearList.Items.Count - 1; i++)
        {
            if (YearList.Items[i].Selected == true)
            {
                RepYears.DataSource = Obj.GetDataSetByID("ReportOneYearAll", Convert.ToInt32(YearList.Items[i].Value));
                RepYears.DataBind();
            }
        }
    }




    protected void PreviewReports_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (((Label)e.Item.FindControl("RepID")).Text != "")
        {
            ((Repeater)e.Item.FindControl("RepNotes")).DataSource = Obj.GetDataSetByID("ReportNotes", Convert.ToInt32(((Label)e.Item.FindControl("RepID")).Text));
            ((Repeater)e.Item.FindControl("RepNotes")).DataBind();
        }
        


        if (((Label)e.Item.FindControl("RepStat")).Text == "3")
        {
            ((HtmlControl)e.Item.FindControl("Done")).Visible = true;
            ((HtmlControl)e.Item.FindControl("SemiDone")).Visible = false;
            ((HtmlControl)e.Item.FindControl("NoteDone")).Visible = false;
            ((HtmlControl)e.Item.FindControl("NoteNow")).Visible = false;
            ((HtmlControl)e.Item.FindControl("Closed")).Visible = false;

        }
        else if (((Label)e.Item.FindControl("RepStat")).Text == "2")
        {
            ((HtmlControl)e.Item.FindControl("Done")).Visible = false;
            ((HtmlControl)e.Item.FindControl("SemiDone")).Visible = true;
            ((HtmlControl)e.Item.FindControl("NoteDone")).Visible = false;
            ((HtmlControl)e.Item.FindControl("NoteNow")).Visible = false;
            ((HtmlControl)e.Item.FindControl("Closed")).Visible = false;

        }
        else if (((Label)e.Item.FindControl("RepStat")).Text == "4")
        {
            ((HtmlControl)e.Item.FindControl("Done")).Visible = false;
            ((HtmlControl)e.Item.FindControl("SemiDone")).Visible = false;
            ((HtmlControl)e.Item.FindControl("NoteDone")).Visible = false;
            ((HtmlControl)e.Item.FindControl("NoteNow")).Visible = true;
            ((HtmlControl)e.Item.FindControl("Closed")).Visible = false;

        }
        else if (((Label)e.Item.FindControl("RepStat")).Text == "1")
        {
            ((HtmlControl)e.Item.FindControl("Done")).Visible = false;
            ((HtmlControl)e.Item.FindControl("SemiDone")).Visible = false;
            ((HtmlControl)e.Item.FindControl("NoteDone")).Visible = true;
            ((HtmlControl)e.Item.FindControl("NoteNow")).Visible = false;
            ((HtmlControl)e.Item.FindControl("Closed")).Visible = false;

        }
        else if (((Label)e.Item.FindControl("RepStat")).Text == "5")
        {
            ((HtmlControl)e.Item.FindControl("Done")).Visible = false;
            ((HtmlControl)e.Item.FindControl("SemiDone")).Visible = false;
            ((HtmlControl)e.Item.FindControl("NoteDone")).Visible = false;
            ((HtmlControl)e.Item.FindControl("NoteNow")).Visible = false;
            ((HtmlControl)e.Item.FindControl("Closed")).Visible = true;
        }
    }
}