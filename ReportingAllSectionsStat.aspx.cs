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



public partial class ReportingAllSectionsStat : System.Web.UI.Page
{
    Operations Obj = new Operations();
    StringBuilder strImportByAdm = new StringBuilder();

    protected void Page_Load(object sender, EventArgs e)
    {
        Int32 Imp = Convert.ToInt32(Request.QueryString["Stat"]) + 1;

        if (!IsPostBack)
        {

            if (Session["UData"] != null)
            {
                DataSet MyRecDataSet = (DataSet)Session["UData"];

                if (Request.QueryString["Stat"] != null)
                {
                    if (Request.QueryString["Stat"] == "0")
                    {
                        LitTitle.Text = " <span><img src='assets/icons/levels/L1/mid2.png' height='22' /></span>  تقرير معالجة الملاحظات تبعا لمستوى الأهمية منخفضة  ";
                    }
                    if (Request.QueryString["Stat"] == "1")
                    {
                        LitTitle.Text = " <span><img src='assets/icons/levels/L1/low2.png' height='22' /></span>  تقرير معالجة الملاحظات تبعا لمستوى الأهمية متوسطة  ";
                    }
                    if (Request.QueryString["Stat"] == "2")
                    {
                        LitTitle.Text = " <span><img src='assets/icons/levels/L1/high2.png' height='22' /></span> تقرير معالجة الملاحظات تبعا لمستوى الأهمية مرتفعة  ";
                    }
                }
                RepYears.DataSource = YearList.DataSource = Obj.GetDataSetByID("ReportYearsBySection", Convert.ToInt32(Request.QueryString["Reqq"]));

                YearList.DataBind();
                RepYears.DataBind();

                YearList.DataTextField = "YearName";
                YearList.DataValueField = "ID";
                YearList.DataBind();


                AdminList.DataSource = Obj.GetDataSetByID("GetAdministrations", Convert.ToInt32(Request.QueryString["Reqq"]));
                AdminList.DataTextField = "AdmName";
                AdminList.DataValueField = "AdmID";
                AdminList.DataBind();
                ListItem aa0 = new ListItem();
                aa0.Text = "اختر الإدارة متوسطة";
                aa0.Value = "0";

                AdminList.Items.Insert(0, aa0);

                if (Request.QueryString["ReqY"] != null)
                {
                    HiddenYear.Value = "1";
                    for (int i = 0; i <= YearList.Items.Count - 1; i++)
                    {
                        if (YearList.Items[i].Value == Request.QueryString["ReqY"])
                        {
                            YearList.Items[i].Selected = true;
                        }
                    }
                }

                if (YearList.SelectedIndex == -1)
                {

                    if (RadioStatus.SelectedIndex != -1)
                    {
                        var sqlstr = Obj.ReportOneYearByAdmImp;

                        var sqlwhere0 = @"where (dbo.Reports.RepStatus = 0 ";

                        for (int k = 0; k <= RadioStatus.Items.Count - 1; k++)
                        {
                            if (RadioStatus.Items[k].Selected == true)
                            {
                                sqlwhere0 += " OR dbo.Reports.RepStatus = " + RadioStatus.Items[k].Value;
                            }
                        }

                        sqlwhere0 += @" ) and dbo.Reports.Importance = (case when " + Imp + @" <> 0 then " + Imp + @"
	  when " + Imp + @" = 0 then dbo.Reports.Importance
end) and   dbo.Reports.Active=1 and dbo.Plans.Active=1 
						";
                        sqlstr += "AND RepSection= " + Request.QueryString["Reqq"];

                        sqlstr += sqlwhere0;

                        sqlstr += " ORDER BY LEFT(dbo.Plans.YearName, 4) ASC";
                        RepYears.DataSource = null;
                        RepYears.DataBind();
                        RepYears.DataSource = Obj.ExecuteString(sqlstr);
                        RepYears.DataBind();

                    }
                    else
                    {
                        var sqlstr = Obj.ReportOneYearByAdmImp;

                        var sqlwhere = @" 
						 where (dbo.Reports.RepStatus= dbo.Reports.RepStatus) and dbo.Reports.Importance = (case when " + Imp + @" <> 0 then " + Imp + @"
	  when " + Imp + @" = 0 then dbo.Reports.Importance
end) and   dbo.Reports.Active=1 and dbo.Plans.Active=1 
						";

                        sqlstr += sqlwhere;
                        sqlstr += "AND RepSection= " + Request.QueryString["Reqq"];

                        sqlstr += " ORDER BY LEFT(dbo.Plans.YearName, 4) ASC";
                        RepYears.DataSource = null;
                        RepYears.DataBind();
                        RepYears.DataSource = Obj.ExecuteString(sqlstr);
                        RepYears.DataBind();
                    }


                }
                else
                {
                    if (RadioStatus.SelectedIndex != -1)
                    {
                        var sqlstr = Obj.ReportOneYearByAdmImp;

                        var sqlwhere0 = @"where (dbo.Reports.RepStatus = 0 ";

                        for (int k = 0; k <= RadioStatus.Items.Count - 1; k++)
                        {
                            if (RadioStatus.Items[k].Selected == true)
                            {
                                sqlwhere0 += " OR dbo.Reports.RepStatus = " + RadioStatus.Items[k].Value;
                            }
                        }

                        sqlwhere0 += @" ) and dbo.Reports.Importance = (case when " + Imp + @" <> 0 then " + Imp + @"
	  when " + Imp + @" = 0 then dbo.Reports.Importance
end) and   dbo.Reports.Active=1 and dbo.Plans.Active=1 and(dbo.Plans.ID=0
						";

                        sqlstr += sqlwhere0;


                        for (int i = 0; i <= YearList.Items.Count - 1; i++)
                        {
                            if (YearList.Items[i].Selected == true)
                            {
                                sqlstr += "OR dbo.Plans.ID=" + YearList.Items[i].Value;
                            }
                        }

                        sqlstr += " ) AND RepSection= " + Request.QueryString["Reqq"];

                        sqlstr += " ORDER BY LEFT(dbo.Plans.YearName, 4) ASC";
                        RepYears.DataSource = null;
                        RepYears.DataBind();
                        RepYears.DataSource = Obj.ExecuteString(sqlstr);
                        RepYears.DataBind();
                    }
                    else
                    {
                        var sqlstr = Obj.ReportOneYearByAdmImp;

                        var sqlwhere = @" 
						 where (dbo.Reports.RepStatus= dbo.Reports.RepStatus) and dbo.Reports.Importance = (case when " + Imp + @" <> 0 then " + Imp + @"
	  when " + Imp + @" = 0 then dbo.Reports.Importance
end) and   dbo.Reports.Active=1 and dbo.Plans.Active=1 and(dbo.Plans.ID=0
						";

                        sqlstr += sqlwhere;
                        for (int i = 0; i <= YearList.Items.Count - 1; i++)
                        {
                            if (YearList.Items[i].Selected == true)
                            {
                                sqlstr += "OR dbo.Plans.ID=" + YearList.Items[i].Value;
                            }
                        }
                        sqlstr += " ) AND RepSection= " + Request.QueryString["Reqq"];

                        sqlstr += "ORDER BY LEFT(dbo.Plans.YearName, 4) ASC";
                        RepYears.DataSource = null;
                        RepYears.DataBind();
                        RepYears.DataSource = Obj.ExecuteString(sqlstr);
                        RepYears.DataBind();
                    }
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

                    if (RadioStatus.SelectedIndex != -1)
                    {
                        var sqlstr = Obj.ReportOneYearByAdmImp;

                        var sqlwhere0 = @"where (dbo.Reports.RepStatus = 0 ";

                        for (int k = 0; k <= RadioStatus.Items.Count - 1; k++)
                        {
                            if (RadioStatus.Items[k].Selected == true)
                            {
                                sqlwhere0 += " OR dbo.Reports.RepStatus = " + RadioStatus.Items[k].Value;
                            }
                        }

                        sqlwhere0 += @" ) and dbo.Reports.Importance = (case when " + Imp + @" <> 0 then " + Imp + @"
	  when " + Imp + @" = 0 then dbo.Reports.Importance
end) and   dbo.Reports.Active=1 and dbo.Plans.Active=1 
						";

                        sqlstr += sqlwhere0;
                        if (AdminList.SelectedIndex != -1)
                        {
                            sqlstr += " ) AND RepSection= " + Request.QueryString["Reqq"] + " AND (  RepAdms=0";

                            for (int J = 0; J <= AdminList.Items.Count - 1; J++)
                            {
                                if (AdminList.Items[J].Selected == true)
                                {
                                    sqlstr += " OR dbo.Reports.RepAdms = " + AdminList.Items[J].Value;
                                }
                            }

                            sqlstr += " ) ";
                        }
                        else if (AdminList.SelectedIndex <= 0 && Request.QueryString["Reqq"] != "0")
                        {
                            sqlstr += " ) AND RepSection= " + Request.QueryString["Reqq"];
                        }
                        {
                            sqlstr += "AND RepSection= " + Request.QueryString["Reqq"];
                        }
                        sqlstr += " ORDER BY LEFT(dbo.Plans.YearName, 4) ASC";
                        RepYears.DataSource = null;
                        RepYears.DataBind();
                        RepYears.DataSource = Obj.ExecuteString(sqlstr);
                        RepYears.DataBind();

                    }
                    else
                    {
                        var sqlstr = Obj.ReportOneYearByAdmImp;

                        var sqlwhere = @" 
						 where (dbo.Reports.RepStatus= dbo.Reports.RepStatus) and dbo.Reports.Importance = (case when " + Imp + @" <> 0 then " + Imp + @"
	  when " + Imp + @" = 0 then dbo.Reports.Importance
end) and   dbo.Reports.Active=1 and dbo.Plans.Active=1 
						";

                        sqlstr += sqlwhere;
                        if (AdminList.SelectedIndex != -1)
                        {
                            sqlstr += "AND RepSection= " + Request.QueryString["Reqq"] + " AND (  RepAdms=0";

                            for (int J = 0; J <= AdminList.Items.Count - 1; J++)
                            {
                                if (AdminList.Items[J].Selected == true)
                                {
                                    sqlstr += " OR dbo.Reports.RepAdms = " + AdminList.Items[J].Value;
                                }
                            }

                            sqlstr += " ) ";
                        }
                        else if (AdminList.SelectedIndex <= 0 && Request.QueryString["Reqq"] != "0")
                        {
                            sqlstr += "AND RepSection= " + Request.QueryString["Reqq"];
                        }
                        sqlstr += " ORDER BY LEFT(dbo.Plans.YearName, 4) ASC";
                        RepYears.DataSource = null;
                        RepYears.DataBind();
                        RepYears.DataSource = Obj.ExecuteString(sqlstr);
                        RepYears.DataBind();
                    }


                }
                else
                {
                    if (RadioStatus.SelectedIndex != -1)
                    {
                        var sqlstr = Obj.ReportOneYearByAdmImp;

                        var sqlwhere0 = @"where (dbo.Reports.RepStatus = 0 ";

                        for (int k = 0; k <= RadioStatus.Items.Count - 1; k++)
                        {
                            if (RadioStatus.Items[k].Selected == true)
                            {
                                sqlwhere0 += " OR dbo.Reports.RepStatus = " + RadioStatus.Items[k].Value;
                            }
                        }

                        sqlwhere0 += @" ) and dbo.Reports.Importance = (case when " + Imp + @" <> 0 then " + Imp + @"
	  when " + Imp + @" = 0 then dbo.Reports.Importance
end) and   dbo.Reports.Active=1 and dbo.Plans.Active=1 and(dbo.Plans.ID=0
						";

                        sqlstr += sqlwhere0;
                        for (int i = 0; i <= YearList.Items.Count - 1; i++)
                        {
                            if (YearList.Items[i].Selected == true)
                            {
                                sqlstr += "OR dbo.Plans.ID=" + YearList.Items[i].Value;
                            }
                        }
                        if (AdminList.SelectedIndex != -1)
                        {
                            sqlstr += " ) AND RepSection= " + Request.QueryString["Reqq"] + " AND (  RepAdms=0";

                            for (int J = 0; J <= AdminList.Items.Count - 1; J++)
                            {
                                if (AdminList.Items[J].Selected == true)
                                {
                                    sqlstr += " OR dbo.Reports.RepAdms = " + AdminList.Items[J].Value;
                                }
                            }
                            sqlstr += " ) ";
                        }
                        else if (AdminList.SelectedIndex <= 0 && Request.QueryString["Reqq"] != "0")
                        {
                            sqlstr += "AND RepSection= " + Request.QueryString["Reqq"];
                        }
                        sqlstr += " ORDER BY LEFT(dbo.Plans.YearName, 4) ASC";
                        RepYears.DataSource = null;
                        RepYears.DataBind();
                        RepYears.DataSource = Obj.ExecuteString(sqlstr);
                        RepYears.DataBind();
                    }
                    else
                    {
                        var sqlstr = Obj.ReportOneYearByAdmImp;

                        var sqlwhere = @" 
						 where (dbo.Reports.RepStatus= dbo.Reports.RepStatus) and dbo.Reports.Importance = (case when " + Imp + @" <> 0 then " + Imp + @"
	  when " + Imp + @" = 0 then dbo.Reports.Importance
end) and   dbo.Reports.Active=1 and dbo.Plans.Active=1 and(dbo.Plans.ID=0
						";

                        sqlstr += sqlwhere;
                        for (int i = 0; i <= YearList.Items.Count - 1; i++)
                        {
                            if (YearList.Items[i].Selected == true)
                            {
                                sqlstr += "OR dbo.Plans.ID=" + YearList.Items[i].Value;
                            }
                        }
                        if (AdminList.SelectedIndex != -1)
                        {
                            sqlstr += " ) AND RepSection= " + Request.QueryString["Reqq"] + " AND (  RepAdms=0";

                            for (int J = 0; J <= AdminList.Items.Count - 1; J++)
                            {
                                if (AdminList.Items[J].Selected == true)
                                {
                                    sqlstr += " OR dbo.Reports.RepAdms = " + AdminList.Items[J].Value;
                                }
                            }

                            sqlstr += " ) ";
                        }
                        else if (AdminList.SelectedIndex <= 0 && Request.QueryString["Reqq"] != "0")
                        {
                            sqlstr += "AND RepSection= " + Request.QueryString["Reqq"];
                        }
                        sqlstr += " ORDER BY LEFT(dbo.Plans.YearName, 4) ASC";
                        RepYears.DataSource = null;
                        RepYears.DataBind();
                        RepYears.DataSource = Obj.ExecuteString(sqlstr);
                        RepYears.DataBind();
                    }
                }
                HiddenYear.Value = "0";
            }



            if (HiddenAdmin.Value == "1")
            {
                DataSet MyRecDataSet = (DataSet)Session["UData"];

                if (YearList.SelectedIndex == -1)
                {

                    if (RadioStatus.SelectedIndex != -1)
                    {
                        var sqlstr = Obj.ReportOneYearByAdmImp;

                        var sqlwhere0 = @"where (dbo.Reports.RepStatus = 0 ";

                        for (int k = 0; k <= RadioStatus.Items.Count - 1; k++)
                        {
                            if (RadioStatus.Items[k].Selected == true)
                            {
                                sqlwhere0 += " OR dbo.Reports.RepStatus = " + RadioStatus.Items[k].Value;
                            }
                        }
                        if (AdminList.SelectedIndex != -1)
                        {
                            sqlwhere0 += " ) AND RepSection= " + Request.QueryString["Reqq"] + " AND (  RepAdms=0";

                            for (int J = 0; J <= AdminList.Items.Count - 1; J++)
                            {
                                if (AdminList.Items[J].Selected == true)
                                {
                                    sqlwhere0 += " OR dbo.Reports.RepAdms = " + AdminList.Items[J].Value;
                                }
                            }
                            sqlwhere0 += " ) ";
                        }
                        else if (AdminList.SelectedIndex <= 0 && Request.QueryString["Reqq"] != "0")
                        {
                            sqlwhere0 += " ) AND RepSection= " + Request.QueryString["Reqq"];
                        }
                        sqlwhere0 += @"  and dbo.Reports.Importance = (case when " + Imp + @" <> 0 then " + Imp + @"
	  when " + Imp + @" = 0 then dbo.Reports.Importance
end) and   dbo.Reports.Active=1 and dbo.Plans.Active=1 
						";

                        sqlstr += sqlwhere0;
                        if (AdminList.SelectedIndex != -1)
                        {
                            sqlstr += "AND RepSection= " + Request.QueryString["Reqq"] + " AND (  RepAdms=0";

                            for (int J = 0; J <= AdminList.Items.Count - 1; J++)
                            {
                                if (AdminList.Items[J].Selected == true)
                                {
                                    sqlstr += " OR dbo.Reports.RepAdms = " + AdminList.Items[J].Value;
                                }
                            }

                            sqlstr += " ) ";
                        }
                        else if (AdminList.SelectedIndex <= 0 && Request.QueryString["Reqq"] != "0")
                        {
                            sqlstr += "AND RepSection= " + Request.QueryString["Reqq"];
                        }
                        sqlstr += " ORDER BY LEFT(dbo.Plans.YearName, 4) ASC";
                        RepYears.DataSource = null;
                        RepYears.DataBind();
                        RepYears.DataSource = Obj.ExecuteString(sqlstr);
                        RepYears.DataBind();

                    }
                    else
                    {
                        var sqlstr = Obj.ReportOneYearByAdmImp;

                        var sqlwhere = @" 
						 where (dbo.Reports.RepStatus=  dbo.Reports.RepStatus) and dbo.Reports.Importance = (case when " + Imp + @" <> 0 then " + Imp + @"
	  when " + Imp + @" = 0 then dbo.Reports.Importance
end) and   dbo.Reports.Active=1 and dbo.Plans.Active=1 
						";

                        sqlstr += sqlwhere;
                        if (AdminList.SelectedIndex != -1)
                        {
                            sqlstr += "AND RepSection= " + Request.QueryString["Reqq"] + " AND (  RepAdms=0";

                            for (int J = 0; J <= AdminList.Items.Count - 1; J++)
                            {
                                if (AdminList.Items[J].Selected == true)
                                {
                                    sqlstr += " OR dbo.Reports.RepAdms = " + AdminList.Items[J].Value;
                                }
                            }

                            sqlstr += " ) ";
                        }
                        else if (AdminList.SelectedIndex <= 0 && Request.QueryString["Reqq"] != "0")
                        {
                            sqlstr += "AND RepSection= " + Request.QueryString["Reqq"];
                        }
                        sqlstr += " ORDER BY LEFT(dbo.Plans.YearName, 4) ASC";
                        RepYears.DataSource = null;
                        RepYears.DataBind();
                        RepYears.DataSource = Obj.ExecuteString(sqlstr);
                        RepYears.DataBind();
                    }


                }
                else
                {
                    if (RadioStatus.SelectedIndex != -1)
                    {
                        var sqlstr = Obj.ReportOneYearByAdmImp;

                        var sqlwhere0 = @"where (dbo.Reports.RepStatus = 0 ";

                        for (int k = 0; k <= RadioStatus.Items.Count - 1; k++)
                        {
                            if (RadioStatus.Items[k].Selected == true)
                            {
                                sqlwhere0 += " OR dbo.Reports.RepStatus = " + RadioStatus.Items[k].Value;
                            }
                        }

                        sqlwhere0 += @" ) and dbo.Reports.Importance = (case when " + Imp + @" <> 0 then " + Imp + @"
	  when " + Imp + @" = 0 then dbo.Reports.Importance
end) and   dbo.Reports.Active=1 and dbo.Plans.Active=1 and(dbo.Plans.ID=0
						";

                        sqlstr += sqlwhere0;
                        for (int i = 0; i <= YearList.Items.Count - 1; i++)
                        {
                            if (YearList.Items[i].Selected == true)
                            {
                                sqlstr += "OR dbo.Plans.ID=" + YearList.Items[i].Value;
                            }
                        }
                        if (AdminList.SelectedIndex != -1)
                        {
                            sqlstr += " ) AND RepSection= " + Request.QueryString["Reqq"] + " AND (  RepAdms=0";

                            for (int J = 0; J <= AdminList.Items.Count - 1; J++)
                            {
                                if (AdminList.Items[J].Selected == true)
                                {
                                    sqlstr += " OR dbo.Reports.RepAdms = " + AdminList.Items[J].Value;

                                }
                            }

                            sqlstr += " ) ";
                        }
                        else if (AdminList.SelectedIndex <= 0 && Request.QueryString["Reqq"] != "0")
                        {
                            sqlstr += "AND RepSection= " + Request.QueryString["Reqq"];
                        }
                        sqlstr += "ORDER BY LEFT(dbo.Plans.YearName, 4) ASC";
                        RepYears.DataSource = null;
                        RepYears.DataBind();
                        RepYears.DataSource = Obj.ExecuteString(sqlstr);
                        RepYears.DataBind();
                    }
                    else
                    {
                        var sqlstr = Obj.ReportOneYearByAdmImp;

                        var sqlwhere = @" 
						 where (dbo.Reports.RepStatus=  dbo.Reports.RepStatus) and dbo.Reports.Importance = (case when " + Imp + @" <> 0 then " + Imp + @"
	  when " + Imp + @" = 0 then dbo.Reports.Importance
end) and   dbo.Reports.Active=1 and dbo.Plans.Active=1 and(dbo.Plans.ID=0
						";

                        sqlstr += sqlwhere;
                        for (int i = 0; i <= YearList.Items.Count - 1; i++)
                        {
                            if (YearList.Items[i].Selected == true)
                            {
                                sqlstr += "OR dbo.Plans.ID=" + YearList.Items[i].Value;
                            }
                        }
                        if (AdminList.SelectedIndex != -1)
                        {
                            sqlstr += " ) AND RepSection= " + Request.QueryString["Reqq"] + " AND (  RepAdms=0";

                            for (int J = 0; J <= AdminList.Items.Count - 1; J++)
                            {
                                if (AdminList.Items[J].Selected == true)
                                {
                                    sqlstr += " OR dbo.Reports.RepAdms = " + AdminList.Items[J].Value;
                                }
                            }

                            sqlstr += " ) ";
                        }
                        else if (AdminList.SelectedIndex <= 0 && Request.QueryString["Reqq"] != "0")
                        {
                            sqlstr += "AND RepSection= " + Request.QueryString["Reqq"];
                        }
                        sqlstr += "ORDER BY LEFT(dbo.Plans.YearName, 4) ASC";
                        RepYears.DataSource = null;
                        RepYears.DataBind();
                        RepYears.DataSource = Obj.ExecuteString(sqlstr);
                        RepYears.DataBind();
                    }
                }
            }
        }
    }
    protected void BackCharts_Click(object sender, EventArgs e)
    {
        DataSet MyRecDataSet = (DataSet)Session["UData"];
        if (Obj.ExecuteProcedureID("CheckSectionManger", Convert.ToInt32(MyRecDataSet.Tables[0].Rows[0]["EmpID"])) == 1)
        {
            if (Request.QueryString["ReqY"] != null && Request.QueryString["ReqY"] != "0")
            {
                Response.Redirect("PieDashboardSection.aspx?ReqYR="+Convert.ToString(Request.QueryString["ReqY"])+ "&Reqq="+Convert.ToString(Request.QueryString["Reqq"]));

            }
            else
            {
                Response.Redirect("PieDashboardSection.aspx?ReqYR=0&Reqq=" + Convert.ToString(Request.QueryString["Reqq"]));
            }
        }
        else
        {
            Response.Redirect("SectionsCharts.aspx");

        }
    }


    protected void RepReports_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Int32 Imp = Convert.ToInt32(Request.QueryString["Stat"]) + 1;;


        if (((Label)e.Item.FindControl("SectionID")).Text != "")
        {

            if (RadioStatus.SelectedIndex != -1)
            {
                var sqlstr = Obj.ReportAdminsPlanAllAdm;

                var sqlwhere0 = " AND" + @"(dbo.Reports.RepSection = " + Convert.ToInt32(((Label)e.Item.FindControl("SectionID")).Text) + ") AND (dbo.Reports.RepStatus=0";

                for (int k = 0; k <= RadioStatus.Items.Count - 1; k++)
                {
                    if (RadioStatus.Items[k].Selected == true)
                    {
                        sqlwhere0 += " OR dbo.Reports.RepStatus = " + RadioStatus.Items[k].Value;
                    }
                }
                if (AdminList.SelectedIndex != -1)
                {
                    sqlwhere0 += " ) AND RepSection= " + Request.QueryString["Reqq"] + " AND (  RepAdms=0";

                    for (int J = 0; J <= AdminList.Items.Count - 1; J++)
                    {
                        if (AdminList.Items[J].Selected == true)
                        {
                            sqlwhere0 += " OR dbo.Reports.RepAdms = " + AdminList.Items[J].Value;
                        }
                    }

                    sqlwhere0 += " ) ";
                }
                else if (AdminList.SelectedIndex <= 0 && Request.QueryString["Reqq"] != "0")
                {
                    sqlwhere0 += " ) AND RepSection= " + Request.QueryString["Reqq"];
                }
                sqlwhere0 += @"  AND dbo.Reports.Importance = (case when " + Imp + @" <> 0 then " + Imp + @"
	  when " + Imp + @" = 0 then dbo.Reports.Importance
end) and   dbo.Reports.Active=1  and  dbo.Reports.RepPlan=" + Convert.ToInt32(((Label)e.Item.FindControl("PlanID")).Text);

                sqlstr += sqlwhere0;


                ((Repeater)e.Item.FindControl("RepAdmins")).DataSource = Obj.ExecuteString(sqlstr);
                ((Repeater)e.Item.FindControl("RepAdmins")).DataBind();
            }
            else
            {

                var sqlstr = Obj.ReportAdminsPlanAllAdm;

                var sqlwhere0 = " AND" + @"(dbo.Reports.RepSection = " + Convert.ToInt32(((Label)e.Item.FindControl("SectionID")).Text) + ") ";


                if (AdminList.SelectedIndex != -1)
                {
                    sqlwhere0 += " AND (  RepAdms=0";

                    for (int J = 0; J <= AdminList.Items.Count - 1; J++)
                    {
                        if (AdminList.Items[J].Selected == true)
                        {
                            sqlwhere0 += " OR dbo.Reports.RepAdms = " + AdminList.Items[J].Value;
                        }
                    }

                    sqlwhere0 += " ) ";
                }

                sqlwhere0 += @"  AND dbo.Reports.Importance = (case when " + Imp + @" <> 0 then " + Imp + @"
	  when " + Imp + @" = 0 then dbo.Reports.Importance
end) and   dbo.Reports.Active=1  and  dbo.Reports.RepPlan=" + Convert.ToInt32(((Label)e.Item.FindControl("PlanID")).Text);

                sqlstr += sqlwhere0;


                ((Repeater)e.Item.FindControl("RepAdmins")).DataSource = Obj.ExecuteString(sqlstr);
                ((Repeater)e.Item.FindControl("RepAdmins")).DataBind();

            }


        }
    }
    protected void RepAdmins_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Int32 Imp = Convert.ToInt32(Request.QueryString["Stat"]) + 1;;

        if (RadioStatus.SelectedIndex != -1)
        {
            var sqlstr = Obj.ReadRepwithStatusAllImp;

            var sqlwhere0 = @" dbo.Reports.RepAdms= " + Convert.ToInt32(((Label)e.Item.FindControl("DepartID")).Text) + @" AND (dbo.Reports.RepSection = " + Convert.ToInt32(((Label)e.Item.FindControl("SectID")).Text) + ") and ( dbo.Reports.RepStatus=0";

            for (int k = 0; k <= RadioStatus.Items.Count - 1; k++)
            {
                if (RadioStatus.Items[k].Selected == true)
                {
                    sqlwhere0 += " OR dbo.Reports.RepStatus = " + RadioStatus.Items[k].Value;
                }
            }

            sqlwhere0 += @" ) and dbo.Reports.Importance = (case when " + Imp + @" <> 0 then " + Imp + @"
	  when " + Imp + @" = 0 then dbo.Reports.Importance
end) and   dbo.Reports.Active=1   and  dbo.Reports.RepPlan=" + Convert.ToInt32(((Label)e.Item.FindControl("PlnIDRep")).Text);

            sqlstr += sqlwhere0;



            ((Repeater)e.Item.FindControl("PreviewReports")).DataSource = Obj.ExecuteString(sqlstr);
            ((Repeater)e.Item.FindControl("PreviewReports")).DataBind();
        }
        else
        {
            ((Repeater)e.Item.FindControl("PreviewReports")).DataSource = Obj.GetDataSetBy5ID("ReadRepwithStatusAllImp", Convert.ToInt32(((Label)e.Item.FindControl("SectID")).Text), Convert.ToInt32(((Label)e.Item.FindControl("PlnIDRep")).Text), Convert.ToInt32(((Label)e.Item.FindControl("DepartID")).Text), Convert.ToInt32(Imp), 0);
            ((Repeater)e.Item.FindControl("PreviewReports")).DataBind();
        }


    }

    protected void RepNotes_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Int32 Imp = Convert.ToInt32(Request.QueryString["Stat"]) + 1;;

        if (((Label)e.Item.FindControl("NotDatt")).Text != "")
        {
            if (DateTime.Parse(((Label)e.Item.FindControl("NotDatt")).Text).Year > 2018)
            {
                System.TimeSpan diffResult = DateTime.Parse(((Label)e.Item.FindControl("NotDatt")).Text).ToUniversalTime().Subtract(DateTime.Now.ToUniversalTime());
                if (diffResult.Days <= 0)
                {
                    ((Label)e.Item.FindControl("NotDatt")).ForeColor = System.Drawing.Color.Red;
                }
            }

        }

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
        Int32 Imp = Convert.ToInt32(Request.QueryString["Stat"]) + 1;;

        if (((Label)e.Item.FindControl("YearID")).Text != "")
        {
            if (Request.QueryString["Reqq"] != "0")
            {
                ((Repeater)e.Item.FindControl("RepReports")).DataSource = Obj.GetDataSetBy2ID("RepSectAllByStatIDYear", Convert.ToInt32(((Label)e.Item.FindControl("YearID")).Text), Convert.ToInt32(Request.QueryString["Reqq"]));
                ((Repeater)e.Item.FindControl("RepReports")).DataBind();
            }
            else
            {
                if (RadioStatus.SelectedIndex != -1)
                {
                    if (YearList.SelectedIndex == -1)
                    {
                        var sqlstr = Obj.ReportSecAllByStatYearNew;

                        var sqlwhere0 = "and dbo.Reports.RepPlan=" + ((Label)e.Item.FindControl("YearID")).Text + @" and (dbo.Reports.RepStatus = 0 ";

                        for (int k = 0; k <= RadioStatus.Items.Count - 1; k++)
                        {
                            if (RadioStatus.Items[k].Selected == true)
                            {
                                sqlwhere0 += " OR dbo.Reports.RepStatus = " + RadioStatus.Items[k].Value;
                            }
                        }

                        sqlwhere0 += @" ) and dbo.Reports.Importance = (case when " + Imp + @" <> 0 then " + Imp + @"
	  when " + Imp + @" = 0 then dbo.Reports.Importance
end) and   dbo.Reports.Active=1 and dbo.Sections.Active=1 
						";

                        sqlstr += sqlwhere0;


                        ((Repeater)e.Item.FindControl("RepReports")).DataSource = null;
                        ((Repeater)e.Item.FindControl("RepReports")).DataBind();
                        ((Repeater)e.Item.FindControl("RepReports")).DataSource = Obj.ExecuteString(sqlstr);
                        ((Repeater)e.Item.FindControl("RepReports")).DataBind();
                    }
                    else
                    {
                        var sqlstr = Obj.ReportSecAllByStatYearNew;

                        var sqlwhere0 = @"and (dbo.Reports.RepStatus = 0 ";

                        for (int k = 0; k <= RadioStatus.Items.Count - 1; k++)
                        {
                            if (RadioStatus.Items[k].Selected == true)
                            {
                                sqlwhere0 += " OR dbo.Reports.RepStatus = " + RadioStatus.Items[k].Value;
                            }
                        }

                        sqlwhere0 += @" ) and dbo.Reports.Importance = (case when " + Imp + @" <> 0 then " + Imp + @"
	  when " + Imp + @" = 0 then dbo.Reports.Importance
end) and   dbo.Reports.Active=1 and dbo.Sections.Active=1 and(dbo.Reports.RepPlan=0
						";

                        sqlstr += sqlwhere0;
                        for (int i = 0; i <= YearList.Items.Count - 1; i++)
                        {
                            if (YearList.Items[i].Selected == true)
                            {
                                sqlstr += "OR dbo.Reports.RepPlan=" + YearList.Items[i].Value;
                            }
                        }
                        sqlstr += ") ";
                        ((Repeater)e.Item.FindControl("RepReports")).DataSource = null;
                        ((Repeater)e.Item.FindControl("RepReports")).DataBind();
                        ((Repeater)e.Item.FindControl("RepReports")).DataSource = Obj.ExecuteString(sqlstr);
                        ((Repeater)e.Item.FindControl("RepReports")).DataBind();
                    }
                }
                else
                {
                    ((Repeater)e.Item.FindControl("RepReports")).DataSource = Obj.GetDataSetBy3ID("ReportSecAllByStatYearNew", Convert.ToInt32(((Label)e.Item.FindControl("YearID")).Text), 0, 0);
                    ((Repeater)e.Item.FindControl("RepReports")).DataBind();
                }
            }
        }
    }






    protected void PreviewReports_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Int32 Imp = Convert.ToInt32(Request.QueryString["Stat"]) + 1;;

        if (((Label)e.Item.FindControl("RepID")).Text != "")
        {
            Image td = (Image)e.Item.FindControl("TD1");


           

            DataSet Ds = Obj.GetDataSetByID("ReportNotes", Convert.ToInt32(((Label)e.Item.FindControl("RepID")).Text));


            if (Ds.Tables[0].Rows.Count > 0)
            {
                ((Repeater)e.Item.FindControl("RepNotes")).DataSource = Ds;
                ((Repeater)e.Item.FindControl("RepNotes")).DataBind();
                ((HtmlTableCell)e.Item.FindControl("NotRow")).Attributes.Remove("Style");
                ((HtmlTableCell)e.Item.FindControl("NotRow")).Attributes.Add("Style", "width: 75%; border: none; text-align: center;");

            }
            else
            {
                ((HtmlTableCell)e.Item.FindControl("NotRow")).Attributes.Remove("Style");
                ((HtmlTableCell)e.Item.FindControl("NotRow")).Attributes.Add("Style", "width: 75%;border-bottom: none; text-align: center;");
            }
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

    protected void DropImport_SelectedIndexChanged(object sender, EventArgs e)
    {
        Int32 Imp = Convert.ToInt32(Request.QueryString["Stat"]) + 1;;

        DataSet MyRecDataSet = (DataSet)Session["UData"];

        if (YearList.SelectedIndex == -1)
        {

            if (RadioStatus.SelectedIndex != -1)
            {
                var sqlstr = Obj.ReportOneYearByAdmImp;

                var sqlwhere0 = @"where (dbo.Reports.RepStatus = 0 ";

                for (int k = 0; k <= RadioStatus.Items.Count - 1; k++)
                {
                    if (RadioStatus.Items[k].Selected == true)
                    {
                        sqlwhere0 += " OR dbo.Reports.RepStatus = " + RadioStatus.Items[k].Value;
                    }
                }

                sqlwhere0 += @" ) and dbo.Reports.Importance = (case when " + Imp + @" <> 0 then " + Imp + @"
	  when " + Imp + @" = 0 then dbo.Reports.Importance
end) and   dbo.Reports.Active=1 and dbo.Plans.Active=1 
						";

                sqlstr += sqlwhere0;
                if (AdminList.SelectedIndex != -1)
                {
                    sqlstr += " ) AND RepSection= " + Request.QueryString["Reqq"] + " AND (  RepAdms=0";

                    for (int J = 0; J <= AdminList.Items.Count - 1; J++)
                    {
                        if (AdminList.Items[J].Selected == true)
                        {
                            sqlstr += " OR dbo.Reports.RepAdms = " + AdminList.Items[J].Value;
                        }
                    }

                    sqlstr += " ) ";
                }
                else if (AdminList.SelectedIndex <= 0 && Request.QueryString["Reqq"] != "0")
                {

                    sqlstr += "AND RepSection= " + Request.QueryString["Reqq"];
                }
                sqlstr += " ORDER BY LEFT(dbo.Plans.YearName, 4) ASC";
                RepYears.DataSource = null;
                RepYears.DataBind();
                RepYears.DataSource = Obj.ExecuteString(sqlstr);
                RepYears.DataBind();

            }
            else
            {
                var sqlstr = Obj.ReportOneYearByAdmImp;

                var sqlwhere = @" 
						 where (dbo.Reports.RepStatus= dbo.Reports.RepStatus) and dbo.Reports.Importance = (case when " + Imp + @" <> 0 then " + Imp + @"
	  when " + Imp + @" = 0 then dbo.Reports.Importance
end) and   dbo.Reports.Active=1 and dbo.Plans.Active=1 
						";

                sqlstr += sqlwhere;
                if (AdminList.SelectedIndex != -1)
                {
                    sqlstr += "AND RepSection= " + Request.QueryString["Reqq"] + " AND (  RepAdms=0";

                    for (int J = 0; J <= AdminList.Items.Count - 1; J++)
                    {
                        if (AdminList.Items[J].Selected == true)
                        {
                            sqlstr += " OR dbo.Reports.RepAdms = " + AdminList.Items[J].Value;
                        }
                    }
                    sqlstr += " ) ";
                }
                else if (AdminList.SelectedIndex <= 0 && Request.QueryString["Reqq"] != "0")
                {
                    sqlstr += "AND RepSection= " + Request.QueryString["Reqq"];
                }
                sqlstr += " ORDER BY LEFT(dbo.Plans.YearName, 4) ASC";
                RepYears.DataSource = null;
                RepYears.DataBind();
                RepYears.DataSource = Obj.ExecuteString(sqlstr);
                RepYears.DataBind();
            }


        }
        else
        {
            if (RadioStatus.SelectedIndex != -1)

            {
                var sqlstr = Obj.ReportOneYearByAdmImp;

                var sqlwhere0 = @"where (dbo.Reports.RepStatus = 0 ";

                for (int k = 0; k <= RadioStatus.Items.Count - 1; k++)
                {
                    if (RadioStatus.Items[k].Selected == true)
                    {
                        sqlwhere0 += " OR dbo.Reports.RepStatus = " + RadioStatus.Items[k].Value;
                    }
                }

                sqlwhere0 += @" ) and dbo.Reports.Importance = (case when " + Imp + @" <> 0 then " + Imp + @"
	  when " + Imp + @" = 0 then dbo.Reports.Importance
end) and   dbo.Reports.Active=1 and dbo.Plans.Active=1 and(dbo.Plans.ID=0
						";

                sqlstr += sqlwhere0;
                for (int i = 0; i <= YearList.Items.Count - 1; i++)
                {
                    if (YearList.Items[i].Selected == true)
                    {
                        sqlstr += "OR dbo.Plans.ID=" + YearList.Items[i].Value;
                    }
                }
                if (AdminList.SelectedIndex != -1)
                {
                    sqlstr += " ) AND RepSection= " + Request.QueryString["Reqq"] + " AND (  RepAdms=0";

                    for (int J = 0; J <= AdminList.Items.Count - 1; J++)
                    {
                        if (AdminList.Items[J].Selected == true)
                        {
                            sqlstr += " OR dbo.Reports.RepAdms = " + AdminList.Items[J].Value;
                        }
                    }

                    sqlstr += " ) ";
                }
                else if (AdminList.SelectedIndex <= 0 && Request.QueryString["Reqq"] != "0")
                {
                    sqlstr += "AND RepSection= " + Request.QueryString["Reqq"];
                }
                sqlstr += "ORDER BY LEFT(dbo.Plans.YearName, 4) ASC";
                RepYears.DataSource = null;
                RepYears.DataBind();
                RepYears.DataSource = Obj.ExecuteString(sqlstr);
                RepYears.DataBind();

            }
            else
            {
                var sqlstr = Obj.ReportOneYearByAdmImp;

                var sqlwhere = @" 
						 where (dbo.Reports.RepStatus=  dbo.Reports.RepStatus) and dbo.Reports.Importance = (case when " + Imp + @" <> 0 then " + Imp + @"
	  when " + Imp + @" = 0 then dbo.Reports.Importance
end) and   dbo.Reports.Active=1 and dbo.Plans.Active=1 and(dbo.Plans.ID=0
						";

                sqlstr += sqlwhere;
                for (int i = 0; i <= YearList.Items.Count - 1; i++)
                {
                    if (YearList.Items[i].Selected == true)
                    {
                        sqlstr += "OR dbo.Plans.ID=" + YearList.Items[i].Value;
                    }
                }
                if (AdminList.SelectedIndex != -1)
                {
                    sqlstr += " ) AND RepSection= " + Request.QueryString["Reqq"] + " AND (  RepAdms=0";

                    for (int J = 0; J <= AdminList.Items.Count - 1; J++)
                    {
                        if (AdminList.Items[J].Selected == true)
                        {
                            sqlstr += " OR dbo.Reports.RepAdms = " + AdminList.Items[J].Value;
                        }
                    }

                    sqlstr += " ) ";
                }
                else if (AdminList.SelectedIndex <= 0 && Request.QueryString["Reqq"] != "0")
                {
                    sqlstr += "AND RepSection= " + Request.QueryString["Reqq"];
                }
                sqlstr += "ORDER BY LEFT(dbo.Plans.YearName, 4) ASC";
                RepYears.DataSource = null;
                RepYears.DataBind();
                RepYears.DataSource = Obj.ExecuteString(sqlstr);
                RepYears.DataBind();
            }
        }
    }
    protected void MsgButton_Command(object sender, CommandEventArgs e)
    {
        string[] arg = new string[2];
        arg = e.CommandArgument.ToString().Split(';');

        

        DepartMangList.DataSource = Obj.GetDataSetByID("GetAdminManagers", Convert.ToInt32(arg[1]));

        DepartMangList.DataTextField = "EmpName";
        DepartMangList.DataValueField = "EmpEmail";
        DepartMangList.DataBind();

        foreach (ListItem item in DepartMangList.Items)
        {
            item.Selected = true;
        }

        MsgReport_modal.Attributes.Remove("Style");
        MsgReport_modal.Style.Add("display", "block");

        MsgReport_modal.Attributes.Remove("class");
        MsgReport_modal.Attributes.Add("class", "modal fadeIn");
        SendRepNot.CommandArgument = arg[2];
    }
    protected void SendRepNot_Click(object sender, ImageClickEventArgs e)
    {
        List<string> Sections = new List<string>();
        Suc.Visible = false;
        
        List<string> Departs = new List<string>();

        foreach (ListItem item in DepartMangList.Items)
        {
            if (item.Selected == true)
            {

                Departs.Add(item.Value);
            }
        }
        DataSet Ds = Obj.GetDataSetByID("GetReportByID", Convert.ToInt32(SendRepNot.CommandArgument));
        string Body = @"<html>

<body>
    <div style='direction:rtl;text-align:right;'>
 <h3 style = 'color: #b0b0b0;'> عزيزي الموظف نذكركم بالملاحظة التي تخصكم في منصة المراجعة الداخلية</h3>

                                                                  
        <b>
            -:  كما هو موضح في التفاصيل ادناه
        </b>

        <ul dir='rtl'>";
        if (Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow Row in Ds.Tables[0].Rows)
            {


                Body += @" <li>
                <b>موجه لإدارة عليا:</b>
                <br />
" + Convert.ToString(Row["SectionName"]) + @"
            </li>
            <li>
                <b>موجه لإدارة متوسطة:</b>

                <br />
" + Convert.ToString(Row["AdmName"]) + @"
            </li>

            <li>
                <b>رقم الملاحظة:</b>

                <br /><span style='direction:ltr;'>
" + Convert.ToString(Row["RepCode"]) + @"</span>
            </li>
            <li>
                <b>عنوان الملاحظة:</b>

                <br />
" + Convert.ToString(Row["RepTitle"]) + @"
            </li>
            
            <li>
                <b>تاريخ تنفيذ الملاحظة :</b>

                <br />
" + Convert.ToString(Row["RepFrom"]) + @"
            </li>
            
  <li>
                <b>تم الإضافة من قبل:</b>

                <br />
" + Convert.ToString(Row["EmpName"]) + @"
            </li>

  <li>
                <b>التوصيات:</b>

               <ul>";
                DataSet DSNotes = Obj.GetDataSetByID("GetNotes", Convert.ToInt32(SendRepNot.CommandArgument));

                if (DSNotes.Tables.Count > 0 && DSNotes.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow RowNot in DSNotes.Tables[0].Rows)
                    {
                        Body += "<li>" + Convert.ToString(RowNot["NoteFrom"]) + " تاريخ التنفيذ " + Convert.ToString(RowNot["NoteCount"]) + "كود التوصية </li>";
                    }
                }

                Body += @"
           </u> </li>

        </ul>


    ";

                Body += @"</div><div style='text-align:right; direction:ltr;'>
            <b>    للاطلاع على مزيد من التفاصيل اضغط هنا <a href='" + HttpContext.Current.Request.Url.Authority + @"'>رابط التوصية</a></b>
</div>

    
</body>
</html>";


            }
        }

        Obj.ReportMails("اشعار تذكير بملاحظات", Body, Sections, Departs);
        MsgReport_modal.Attributes.Remove("Style");
        MsgReport_modal.Style.Add("display", "none");

        MsgReport_modal.Attributes.Remove("class");
        MsgReport_modal.Attributes.Add("class", "modal fade");
        Suc.Visible = true;
    }
    protected void CloseNotify_Click(object sender, ImageClickEventArgs e)
    {
        MsgReport_modal.Attributes.Remove("Style");
        MsgReport_modal.Style.Add("display", "none");

        MsgReport_modal.Attributes.Remove("class");
        MsgReport_modal.Attributes.Add("class", "modal fade");
    }

    protected void RadioStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        Int32 Imp = Convert.ToInt32(Request.QueryString["Stat"]) + 1;;

        DataSet MyRecDataSet = (DataSet)Session["UData"];

        if (YearList.SelectedIndex == -1)
        {

            if (RadioStatus.SelectedIndex != -1)
            {
                var sqlstr = Obj.ReportOneYearByAdmImp;

                var sqlwhere0 = @"where (dbo.Reports.RepStatus = 0 ";

                for (int k = 0; k <= RadioStatus.Items.Count - 1; k++)
                {
                    if (RadioStatus.Items[k].Selected == true)
                    {
                        sqlwhere0 += " OR dbo.Reports.RepStatus = " + RadioStatus.Items[k].Value;
                    }
                }

                sqlwhere0 += @" ) and dbo.Reports.Importance = (case when " + Imp + @" <> 0 then " + Imp + @"
	  when " + Imp + @" = 0 then dbo.Reports.Importance
end) and   dbo.Reports.Active=1 and dbo.Plans.Active=1 
						";

                sqlstr += sqlwhere0;

                if (AdminList.SelectedIndex != -1)
                {
                    sqlstr += "AND RepSection= " + Request.QueryString["Reqq"] + " AND (  RepAdms=0";

                    for (int J = 0; J <= AdminList.Items.Count - 1; J++)
                    {
                        if (AdminList.Items[J].Selected == true)
                        {
                            sqlstr += " OR dbo.Reports.RepAdms = " + AdminList.Items[J].Value;
                        }
                    }

                    sqlstr += " ) ";
                }
                else if (AdminList.SelectedIndex <= 0 && Request.QueryString["Reqq"] != "0")
                {
                    sqlstr += "AND RepSection= " + Request.QueryString["Reqq"];
                }
                sqlstr += " ORDER BY LEFT(dbo.Plans.YearName, 4) ASC";
                RepYears.DataSource = null;
                RepYears.DataBind();
                RepYears.DataSource = Obj.ExecuteString(sqlstr);
                RepYears.DataBind();

            }
            else
            {
                var sqlstr = Obj.ReportOneYearByAdmImp;

                var sqlwhere = @" 
						 where (dbo.Reports.RepStatus=  dbo.Reports.RepStatus) and dbo.Reports.Importance = (case when " + Imp + @" <> 0 then " + Imp + @"
	  when " + Imp + @" = 0 then dbo.Reports.Importance
end) and   dbo.Reports.Active=1 and dbo.Plans.Active=1 
						";

                sqlstr += sqlwhere;
                if (AdminList.SelectedIndex != -1)
                {
                    sqlstr += "AND RepSection= " + Request.QueryString["Reqq"] + " AND (  RepAdms=0";

                    for (int J = 0; J <= AdminList.Items.Count - 1; J++)
                    {
                        if (AdminList.Items[J].Selected == true)
                        {
                            sqlstr += " OR dbo.Reports.RepAdms = " + AdminList.Items[J].Value;
                        }
                    }
                    sqlstr += " ) ";
                }
                else if (AdminList.SelectedIndex <= 0 && Request.QueryString["Reqq"] != "0")
                {
                    sqlstr += "AND RepSection= " + Request.QueryString["Reqq"];
                }
                sqlstr += " ORDER BY LEFT(dbo.Plans.YearName, 4) ASC";
                RepYears.DataSource = null;
                RepYears.DataBind();
                RepYears.DataSource = Obj.ExecuteString(sqlstr);
                RepYears.DataBind();
            }


        }
        else
        {
            if (RadioStatus.SelectedIndex != -1)
            {
                var sqlstr = Obj.ReportOneYearByAdmImp;

                var sqlwhere0 = @"where (dbo.Reports.RepStatus = 0 ";

                for (int k = 0; k <= RadioStatus.Items.Count - 1; k++)
                {
                    if (RadioStatus.Items[k].Selected == true)
                    {
                        sqlwhere0 += " OR dbo.Reports.RepStatus = " + RadioStatus.Items[k].Value;
                    }
                }

                sqlwhere0 += @" ) and dbo.Reports.Importance = (case when " + Imp + @" <> 0 then " + Imp + @"
	  when " + Imp + @" = 0 then dbo.Reports.Importance
end) and   dbo.Reports.Active=1 and dbo.Plans.Active=1 and(dbo.Plans.ID=0
						";

                sqlstr += sqlwhere0;
                for (int i = 0; i <= YearList.Items.Count - 1; i++)
                {
                    if (YearList.Items[i].Selected == true)
                    {
                        sqlstr += "OR dbo.Plans.ID=" + YearList.Items[i].Value;
                    }
                }
                if (AdminList.SelectedIndex != -1)
                {
                    sqlstr += " ) AND RepSection= " + Request.QueryString["Reqq"] + " AND (  RepAdms=0";

                    for (int J = 0; J <= AdminList.Items.Count - 1; J++)
                    {
                        if (AdminList.Items[J].Selected == true)
                        {
                            sqlstr += " OR dbo.Reports.RepAdms = " + AdminList.Items[J].Value;
                        }
                    }

                    sqlstr += " ) ";
                }
                else if (AdminList.SelectedIndex <= 0 && Request.QueryString["Reqq"] != "0")
                {
                    sqlstr += "AND RepSection= " + Request.QueryString["Reqq"];
                }
                sqlstr += " ORDER BY LEFT(dbo.Plans.YearName, 4) ASC";
                RepYears.DataSource = null;
                RepYears.DataBind();
                RepYears.DataSource = Obj.ExecuteString(sqlstr);
                RepYears.DataBind();

            }
            else
            {
                var sqlstr = Obj.ReportOneYearByAdmImp;

                var sqlwhere = @" 
						 where (dbo.Reports.RepStatus= dbo.Reports.RepStatus) and dbo.Reports.Importance = (case when " + Imp + @" <> 0 then " + Imp + @"
	  when " + Imp + @" = 0 then dbo.Reports.Importance
end) and   dbo.Reports.Active=1 and dbo.Plans.Active=1 and(dbo.Plans.ID=0
						";

                sqlstr += sqlwhere;
                for (int i = 0; i <= YearList.Items.Count - 1; i++)
                {
                    if (YearList.Items[i].Selected == true)
                    {
                        sqlstr += "OR dbo.Plans.ID=" + YearList.Items[i].Value;
                    }
                }
                if (AdminList.SelectedIndex != -1)
                {
                    sqlstr += " ) AND RepSection= " + Request.QueryString["Reqq"] + " AND (  RepAdms=0";

                    for (int J = 0; J <= AdminList.Items.Count - 1; J++)
                    {
                        if (AdminList.Items[J].Selected == true)
                        {
                            sqlstr += " OR dbo.Reports.RepAdms = " + AdminList.Items[J].Value;
                        }
                    }

                    sqlstr += " ) ";
                }
                else if (AdminList.SelectedIndex <= 0 && Request.QueryString["Reqq"] != "0")
                {
                    sqlstr += "AND RepSection= " + Request.QueryString["Reqq"];
                }
                sqlstr += "ORDER BY LEFT(dbo.Plans.YearName, 4) ASC";
                RepYears.DataSource = null;
                RepYears.DataBind();
                RepYears.DataSource = Obj.ExecuteString(sqlstr);
                RepYears.DataBind();
            }
        }
    }

}