using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Web.UI.DataVisualization.Charting;
using System.Text.RegularExpressions;

public partial class ReportSection : System.Web.UI.Page
{
    Operations Obj = new Operations();
    public static string RemoveStyle(string html)
    {
        Regex regex = new Regex("font-size:(.)*?(;|>)|line-height:(.)*?(;|>)", RegexOptions.IgnoreCase);

        return regex.Replace(html, string.Empty);
    }
    private void BindEmployeesData()
    {
        if (Session["UData"] != null)
        {
            if (Session["UData"] != null)
            {
                DataSet MyRecDataSet = (DataSet)Session["UData"];

                EmployeesData.DataSource = Obj.GetDataSetByID("GetReportBySection", Convert.ToInt32(MyRecDataSet.Tables[0].Rows[0]["SectionID"]));
                EmployeesData.DataBind();

                Mang.DataSource = Obj.GetDataSetByID("GetAdministrations", Convert.ToInt32(MyRecDataSet.Tables[0].Rows[0]["SectionID"]));

                Mang.DataTextField = "AdmName";
                Mang.DataValueField = "AdmID";
                Mang.DataBind();




            }
        }


    }
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            DataSet MyRecDataSet = (DataSet)Session["UData"];

            if (!IsPostBack)
            {

                if (Session["UData"] != null)
                {
                    if (Obj.ExecuteProcedureID("CheckSectionManger", Convert.ToInt32(MyRecDataSet.Tables[0].Rows[0]["EmpID"])) == 1)
                    {
                        /// Log Data Start

                        Obj.ExecuteProcedureStringID("NewLogTable", Convert.ToInt32(MyRecDataSet.Tables[0].Rows[0]["EmpID"]), "View Notes and Recommendations by Section manager permission");

                        /// Log Data End
                        BindEmployeesData();
                        LblUpdate.Text = "";

                        // Fill dropdown Lists For Reports with date and RepiD
                        PlansSearch.DataSource = Obj.GetDataSetByID("GetPlansBySection", Convert.ToInt32(MyRecDataSet.Tables[0].Rows[0]["SectionID"]));

                        PlansSearch.DataTextField = "YearName";
                        PlansSearch.DataValueField = "ID";
                        PlansSearch.DataBind();



                        Mang.DataSource = Obj.GetDataSetBy2ID("GetAdminByPlanSection", Convert.ToInt32(PlansSearch.SelectedValue), Convert.ToInt32(MyRecDataSet.Tables[0].Rows[0]["SectionID"]));

                        Mang.DataTextField = "AdmName";
                        Mang.DataValueField = "AdmID";
                        Mang.DataBind();

                        ListItem aa0 = new ListItem();
                        aa0.Text = "اختر الإدارة متوسطة";
                        aa0.Value = "0";

                        Mang.Items.Insert(0, aa0);


                        //DataTable DTImportant = Obj.GetDataSet("ReportCountRepImportance").Tables[0];

                        //DataTable DTStatus = Obj.GetDataSet("ReportCountRepStatus").Tables[0];

                        //foreach (ListItem ltItem in Importance.Items)
                        //{
                        //    if (ltItem.Value != "0")
                        //    {
                        //        var dT = DTImportant.AsEnumerable().Where(x => x.Field<int>("Importance") == Convert.ToInt32(ltItem.Value)).FirstOrDefault();
                        //        string Counts = "0";
                        //        if (dT != null)
                        //        {
                        //            Counts = dT["Counts"].ToString();
                        //        }
                        //        ltItem.Text += " [ " + Counts + " ] ";
                        //    }
                        //}
                        //foreach (ListItem ltItem in RadioStatus.Items)
                        //{
                        //    if (ltItem.Value != "0")
                        //    {
                        //        var dT = DTStatus.AsEnumerable().Where(x => x.Field<int>("RepStatus") == Convert.ToInt32(ltItem.Value)).FirstOrDefault();
                        //        string Counts = "0";
                        //        if (dT != null)
                        //        {
                        //            Counts = dT["Counts"].ToString();
                        //        }

                        //        ltItem.Text += " [ " + Counts + " ] ";
                        //    }
                        //}
                        MainTable.Visible = true;
                    }
                    else
                    {
                        Response.Redirect("NoPermissions.aspx");
                    }
                }
            }
            else
            {
                /// Log Data Start
                if (HiddenPost.Value == "Log")
                {
                    if (HiddenLogText.Value.Length > 0)
                    {
                        string[] arg = new string[2];
                        arg = HiddenLogText.Value.ToString().Split('/');



                        Obj.ExecuteProcedureStringID("NewLogTable", Convert.ToInt32(MyRecDataSet.Tables[0].Rows[0]["EmpID"]), "Read Recommendation No." + arg[1] + " for Note No." + arg[0] + "As Sector Manager Permission ");



                    }
                }
                /// Log Data End
                if (HiddenPost.Value == "1")
                {

                    CheckRepeat.Checked = false;
                    SearchbyRepeat();
                    HiddenPost.Value = "0";
                }

                if (HiddenSearch.Value == "1")
                {
                    EmployeesData.DataSource = null;
                    EmployeesData.DataBind();
                    var Repeatchecked = 0;

                    if (HiddenPost.Value == "1")
                    {
                        Repeatchecked = 1;

                    }
                    EmployeesData.DataSource = Obj.ReportFilterAll(Convert.ToInt32(Mang.SelectedValue), Convert.ToInt32(MyRecDataSet.Tables[0].Rows[0]["SectionID"]), Convert.ToInt32(Importance.SelectedValue), Convert.ToInt32(RadioStatus.SelectedValue), RepeatSearch.Checked, CheckRepeat.Checked, DateFromSearch.Value.Equals("") ? "0" : DateFromSearch.Value, Convert.ToInt32(PlansSearch.SelectedValue), Repeatchecked);

                    EmployeesData.DataBind();

                    HiddenSearch.Value = "0";
                }

                Suc.Visible = false; SucDel.Visible = false;
                SucNote.Visible = false;

                PrntView.Attributes.Remove("Style");
                PrntView.Style.Add("display", "none");

                MainSave.Attributes.Remove("Style");
                MainSave.Style.Add("display", "block");
                LblViews.Text = "";

            }
        }
        catch (Exception ex)
        {
        }
    }


    protected void Edit_Command(object sender, CommandEventArgs e)
    {

        try
        {
            CloseOthers();
            NoteDetails.Attributes.Remove("Style");
            NoteDetails.Style.Add("display", "block");

            DataSet Ds = new DataSet();
            RepNotes.DataSource = Obj.GetDataSetByID("GetNotes", Convert.ToInt32(e.CommandArgument));
            RepNotes.DataBind();
            LblViews.Text = "Edt";
            LblEditID.Text = e.CommandArgument.ToString();


        }
        catch { }
    }



    protected void EmployeesData_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Image td = (Image)e.Item.FindControl("TD1");
        Image td2 = (Image)e.Item.FindControl("TD2");

        if (((Label)e.Item.FindControl("RepComCount")).Text != "" && ((Label)e.Item.FindControl("RepComCount")).Text != null)
        {
            ((Label)e.Item.FindControl("RepComCount")).Text = " عدد الردود [" + ((Label)e.Item.FindControl("RepComCount")).Text + "]";

        }
        else
        {
            ((Label)e.Item.FindControl("RepComCount")).Text = " لايوجد ردود";
        }


        if (((Label)e.Item.FindControl("LblImportant")).Text == "3")
        {
            td.ImageUrl = "assets/images/Icons/levels/L1/high.png";

        }
        if (((Label)e.Item.FindControl("LblImportant")).Text == "2")
        {
            td.ImageUrl = "assets/images/Icons/levels/L1/mid.png";
        }
        if (((Label)e.Item.FindControl("LblImportant")).Text == "1")
        {
            td.ImageUrl = "assets/images/Icons/levels/L1/low.png";

        }



        if (((Label)e.Item.FindControl("LblStat")).Text == "3")
        {

            td2.ImageUrl = "assets/icons/levels/L2/solved3.png";

        }
        else if (((Label)e.Item.FindControl("LblStat")).Text == "2")
        {

            td2.ImageUrl = "assets/icons/levels/L2/under3.png";
        }
        else if (((Label)e.Item.FindControl("LblStat")).Text == "1")
        {

            td2.ImageUrl = "assets/icons/levels/L2/hold3.png";
        }

        else if (((Label)e.Item.FindControl("LblStat")).Text == "4")
        {

            td2.ImageUrl = "assets/icons/levels/L2/notstart3.png";
        }
        else if (((Label)e.Item.FindControl("LblStat")).Text == "5")
        {
            td2.ImageUrl = "assets/icons/levels/L2/closed3.png";
        }

    }
    protected void LinkDetails_Command(object sender, CommandEventArgs e)
    {
        PagTitle.InnerText = "الإطلاع على الملاحظات" + ">" + "عرض الملاحظة";

        CloseOthers();

        //DataSet DsFiles = Obj.GetDataSetByID("GetReportFiles", Convert.ToInt32(e.CommandArgument));
        //FileList.DataSource = DsFiles;
        //FileList.DataBind();

        DataSet Ds = Obj.GetDataSetByID("GetReportByID", Convert.ToInt32(e.CommandArgument));

        if (Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow Row in Ds.Tables[0].Rows)
            {


                LblNoteCount.Text = Convert.ToString(Row["NoteCount"]);

                LblRepDate.Text = Convert.ToString(Row["RepDate"]);
                LblReptitle.Text = Convert.ToString(Row["RepTitle"]);

                LblForSec.Text = Convert.ToString(Row["RepSection"]);
                LblForAdm.Text = Convert.ToString(Row["RepAdm"]);
                var Imp = Convert.ToString(Row["Importance"]);

                if (Imp == "3")
                {
                    LblImport.ImageUrl = "assets/images/Icons/levels/L1/high.png";

                }
                if (Imp == "2")
                {
                    LblImport.ImageUrl = "assets/images/Icons/levels/L1/mid.png";
                }
                if (Imp == "1")
                {
                    LblImport.ImageUrl = "assets/images/Icons/levels/L1/low.png";

                }
                LblDateFrom.Text = Convert.ToString(Row["RepFrom"]);
                LblNo.Text = Convert.ToString(Row["RepCode"]);
                if (Convert.ToBoolean(Row["RepRepeat"]) == true) { RPTSign.Text = "مكرر"; }
                else { RPTSign.Text = "غير مكرر"; }
                var Status = Convert.ToString(Row["RepStatus"]);

                if (Status == "3")
                {
                    LblStatus.ImageUrl = "assets/icons/levels/L2/solved3.png";

                }
                else if (Status == "1")
                {
                    LblStatus.ImageUrl = "assets/icons/levels/L2/hold3.png";

                }
                else if (Status == "2")
                {
                    LblStatus.ImageUrl = "assets/icons/levels/L2/under3.png";

                }
                else if (Status == "4")
                {
                    LblStatus.ImageUrl = "assets/icons/levels/L2/notstart3.png";

                }
                else if (Status == "5")
                {
                    LblStatus.ImageUrl = "assets/icons/levels/L2/closed3.png";
                }
                Test.InnerHtml = RemoveStyle(System.Net.WebUtility.HtmlDecode(Convert.ToString(Row["RepText"])));
                RepImpTxt.InnerHtml = RemoveStyle(System.Net.WebUtility.HtmlDecode(Convert.ToString(Row["RepImpText"])));
            }



        }
        ///Log Data Start

        DataSet MyRecDataSet = (DataSet)Session["UData"];


        Obj.ExecuteProcedureStringID("NewLogTable", Convert.ToInt32(MyRecDataSet.Tables[0].Rows[0]["EmpID"]), "Read Note No." + LblNo.Text + "As Sector Manager Permission ");

        /// Log Data End
        RepDetail.Attributes.Remove("Style");
        RepDetail.Style.Add("display", "block");
    }
    protected void LnkComment_Command(object sender, CommandEventArgs e)
    {
        DataSet Ds = Obj.GetDataSetByID("GetReportConfirm", Convert.ToInt32(e.CommandArgument));

        if (Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow Row in Ds.Tables[0].Rows)
            {
                LblCommDate.Text = Convert.ToString(Row["ConfirmDate"]);

                LblCommRepID.Text = Convert.ToString(e.CommandArgument);
                LblCommTxt.InnerText = RemoveStyle(System.Net.WebUtility.HtmlDecode(Convert.ToString(Row["ConfirmText"])));
            }
        }
        DataSet DsFiles = Obj.GetDataSetByID("GetReportFiles", Convert.ToInt32(e.CommandArgument));
        FileListed.DataSource = DsFiles;
        FileListed.DataBind();

        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "GetComments();", true);

    }





    protected void Importance_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet MyRecDataSet = (DataSet)Session["UData"];
        EmployeesData.DataSource = null;
        EmployeesData.DataBind();
        var Repeatchecked = 0;

        if (HiddenPost.Value == "1")
        {
            Repeatchecked = 1;

        }
        EmployeesData.DataSource = Obj.ReportFilterAll(Convert.ToInt32(Mang.SelectedValue), Convert.ToInt32(MyRecDataSet.Tables[0].Rows[0]["SectionID"]), Convert.ToInt32(Importance.SelectedValue), Convert.ToInt32(RadioStatus.SelectedValue), RepeatSearch.Checked, CheckRepeat.Checked, DateFromSearch.Value.Equals("") ? "0" : DateFromSearch.Value, Convert.ToInt32(PlansSearch.SelectedValue), Repeatchecked);
        EmployeesData.DataBind();


    }
    protected void RadioStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        int Repeatchecked = 0;
        DataSet MyRecDataSet = (DataSet)Session["UData"];

        if (HiddenPost.Value == "1")
        {
            Repeatchecked = 1;

        }
        EmployeesData.DataSource = null;
        EmployeesData.DataBind();
        EmployeesData.DataSource = Obj.ReportFilterAll(Convert.ToInt32(Mang.SelectedValue), Convert.ToInt32(MyRecDataSet.Tables[0].Rows[0]["SectionID"]), Convert.ToInt32(Importance.SelectedValue), Convert.ToInt32(RadioStatus.SelectedValue), RepeatSearch.Checked, CheckRepeat.Checked, DateFromSearch.Value.Equals("") ? "0" : DateFromSearch.Value, Convert.ToInt32(PlansSearch.SelectedValue), Repeatchecked);
        EmployeesData.DataBind();

    }


    protected void Save_Click(object sender, EventArgs e)
    {
        try
        {
            Rett.Text = "";

            if (Session["UData"] != null)
            {
                DataSet MyRecDataSet = (DataSet)Session["UData"];


                Suc.Visible = false; SucDel.Visible = false;
                var Ret = 0;

                Ret = Obj.NewReportNoteNew(Convert.ToInt32(MyRecDataSet.Tables[0].Rows[0]["EmpID"]), hf.Value, DFromNoteUDP.Value, 0, Convert.ToInt32(RadioButtonList2.SelectedValue), LblRepeatU.Checked, Convert.ToInt32(LblEditID.Text), hf1N.Value);

                if (Ret != 0)
                {//Call te file uploads function For all the FileUpload Controls
                    NoteListing.InnerHtml = "";
                    Obj.ExecuteProcedure("UpdateNoteStatus");

                    string Stat = "غير مكررة";
                    if (LblRepeatU.Checked == true) { Stat = "مكررة"; }

                    string Body = "<table border='0'><tbody><tr><td><b>توصية على الملاحظة رقم:</b></td><td>" + LblEditID.Text + "</td></tr><tr><td colspan='2'><span style='padding-left:30px'><b>توصية جديدة  </b></span><span><b>رقم:</b></span><span style='padding-left:30px;'>" + Ret + "</span><span><b>بتاريخ:</b></span><span style='padding-left:30px;'>" + DateTime.Now.ToString("yyyy-MM-dd", new System.Globalization.CultureInfo("ar-SA").DateTimeFormat) + " [" + DateTime.Now.ToString("yyyy-MM-dd", new System.Globalization.CultureInfo("en-US").DateTimeFormat) + "] " + "</td></tr><tr><td><b>بدأ تنفيذ التوصية من تاريخ:</b></td><td>" + DFromNoteUDP.Value + "</td></tr></tr><tr><td><b> حالة التكرار:</b></td><td>" + Stat + "</td></tr><tr><td><b>حالة الملاحظة:</b></td><td>" + RadioButtonList2.SelectedItem.Text + "</td></tr><tr><td><b>سبب التوصية:</b></td><td>" + PartText2.Value + "</td></tr><tr><td><b>تاريخ التوصية:</b></td><td>" + DateTime.Now.ToString("yyyy-MM-dd", new System.Globalization.CultureInfo("ar-SA").DateTimeFormat) + "</td></tr><tr><td><b>ملفات مرفقة:</b></td><td><ul style='list-style: none;'>";


                    DataSet DsFil = Obj.GetDataSetByID("GetNoteFiles", Convert.ToInt32(Ret));


                    if (DsFil.Tables.Count > 0 && DsFil.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow RowFile in DsFil.Tables[0].Rows)
                        {
                            Body += "<li><a href='http://Mutaweron.com/" + Convert.ToString(RowFile["FPath"]) + "'>" + Convert.ToString(RowFile["FName"]) + "<li>";
                        }
                    }

                    Body += "</ul></td></tr></tbody></table>";


                    DataSet Ds = Obj.GetDataSetByID("GetReportByID", Convert.ToInt32(LblEditID.Text));


                    if (Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                    {
                        int SectionID = Convert.ToInt32(Ds.Tables[0].Rows[0]["SectionID"]);



                        DataSet DsAdm = Obj.GetDataSetByID("GetAdministrations", Convert.ToInt32(Ds.Tables[0].Rows[0]["SectionID"]));

                        int AdmID = Convert.ToInt32(DsAdm.Tables[0].Rows[0]["AdmID"]);

                        Obj.OurMails("توصية جديدة", Body, SectionID, AdmID, false);
                        CloseOthers();
                        NoteDetails.Attributes.Remove("Style");
                        NoteDetails.Style.Add("display", "block");
                        RepNotes.DataSource = Obj.GetDataSetByID("GetNotes", Convert.ToInt32(LblEditID.Text));
                        RepNotes.DataBind();

                        //DataSet DsRpt = Obj.GetDataSetByID("GetReportByID", Convert.ToInt32(LblEditID.Text));

                        //if (DsRpt.Tables.Count > 0 && DsRpt.Tables[0].Rows.Count > 0)
                        //{
                        //    foreach (DataRow Row in DsRpt.Tables[0].Rows)
                        //    {


                        //        RepDat.Text = Convert.ToString(Row["RepDate"]);

                        //        RepSec.Text = Convert.ToString(Row["RepSection"]);
                        //        RepAdm.Text = Convert.ToString(Row["RepAdm"]);
                        //        var Imp = Convert.ToString(Row["Importance"]);
                        //        if (Imp == "1")
                        //        {
                        //            RepIm.Text = "منخفضة";
                        //        }
                        //        else if (Imp == "2")
                        //        {
                        //            RepIm.Text = "متوسطة";
                        //        }
                        //        else if (Imp == "3")
                        //        {
                        //            RepIm.Text = "مرتفعة";
                        //        }
                        //        RepOn.Text = Convert.ToString(Row["RepFrom"]);
                        //        if (Convert.ToBoolean(Row["RepRepeat"]) == true) { RepRep.InnerText = "مكرر"; }
                        //        else { RepRep.InnerText = "غير مكرر"; }
                        //        var Status = Convert.ToString(Row["RepStatus"]);

                        //        if (Status == "3")
                        //        {
                        //            RepSt.Text = "معالجة";

                        //        }
                        //        else if (Status == "1")
                        //        {
                        //            RepSt.Text = "متأخرة";

                        //        }
                        //        else if (Status == "2")
                        //        {
                        //            RepSt.Text = "جارى التنفيذ";

                        //        }
                        //        else if (Status == "4")
                        //        {
                        //            RepSt.Text = "لم يحن وقت التنفيذ";

                        //        }

                        //        else if (Status == "5")
                        //        {
                        //            RepSt.Text = "مغلقة";
                        //        }
                        //        Div1.InnerHtml = System.Net.WebUtility.HtmlDecode(Convert.ToString(Row["RepText"]));




                        //        //DataSet DSNotes = Obj.GetDataSetByID("GetNotes", Convert.ToInt32(LblEditID.Text));

                        //        //if (DSNotes.Tables.Count > 0 && DSNotes.Tables[0].Rows.Count > 0)
                        //        //{
                        //        //    MainSave.Attributes.Remove("Style");
                        //        //    MainSave.Style.Add("display", "none");

                        //        //    PrntView.Attributes.Remove("Style");
                        //        //    PrntView.Style.Add("display", "block");


                        //        //    NoNotes.Attributes.Remove("Style");
                        //        //    NoNotes.Style.Add("display", "none");

                        //        //    int jj = 0;
                        //        //    foreach (DataRow RowNotes in DSNotes.Tables[0].Rows)
                        //        //    {
                        //        //        jj += 1;
                        //        //        string NoteStatus = "مكررة";
                        //        //        if (Convert.ToBoolean(RowNotes["NoteRepeat"]) == false)
                        //        //        {
                        //        //            NoteStatus = "غير مكررة";
                        //        //        }

                        //        //        string NoteStat = "";
                        //        //        if (Convert.ToInt32(RowNotes["NoteStatus"]) == 3)
                        //        //        {

                        //        //            NoteStat = "معالجة";


                        //        //        }
                        //        //        else if (Convert.ToInt32(RowNotes["NoteStatus"]) == 2)
                        //        //        {

                        //        //            NoteStat = "جارى التنفيذ";
                        //        //        }
                        //        //        else if (Convert.ToInt32(RowNotes["NoteStatus"]) == 1)
                        //        //        {

                        //        //            NoteStat = "متأخرة";

                        //        //        }
                        //        //        else if (Convert.ToInt32(RowNotes["NoteStatus"]) == 4)
                        //        //        {

                        //        //            NoteStat = "لم يحن وقت التنفيذ";

                        //        //        }
                        //        //        else if (Convert.ToInt32(RowNotes["NoteStatus"]) == 5)
                        //        //        {

                        //        //            NoteStat = "مغلقة";

                        //        //        }
                        //        //        string NoteImportant = "";
                        //        //        if (Convert.ToInt32(RowNotes["Importance"]) == 3)
                        //        //        {

                        //        //            NoteImportant = "مرتفعة";
                        //        //        }
                        //        //        else if (Convert.ToInt32(RowNotes["Importance"]) == 2)
                        //        //        {

                        //        //            NoteImportant = "متوسطة";

                        //        //        }
                        //        //        else if (Convert.ToInt32(RowNotes["Importance"]) == 1)
                        //        //        {

                        //        //            NoteImportant = "منخفضة";

                        //        //        }


                        //        //        NoteListing.InnerHtml += "<tr><td>" + NoteImportant + "</td><td>" + Convert.ToString(RowNotes["NoteDate"]) + "</td><td>" + NoteStat + "</td><td>" + NoteStatus + "</td><td>" + Convert.ToString(jj) + "</td></tr><tr><td colspan='5'><b>نص التوصية:</b></td></tr><tr><td colspan='5'>" + Server.HtmlDecode(Convert.ToString(RowNotes["NoteText"])) + "</td></tr><tr><td colspan='5'><b>نص الاجراء التصحيحى:</b></td></tr><tr><td colspan='5'>" + Server.HtmlDecode(Convert.ToString(RowNotes["AdminCorrect"])) + "</td></tr>";


                        //        //    }
                        //        //}

                        //        else
                        //        {
                        //            NotesPrev.Attributes.Remove("Style");
                        //            NotesPrev.Style.Add("display", "none");


                        //            NoNotes.Attributes.Remove("Style");
                        //            NoNotes.Style.Add("display", "block");
                        //        }


                        //    }
                        //}
                        //LblEditID.Text = "";
                        LblRepeatU.Checked = false;
                        RadioButtonList1.ClearSelection();
                        RadioButtonList2.ClearSelection();
                        editor1.InnerText = "";
                        editor1N.InnerHtml = "";
                        DFromNoteUDP.Value = "";
                        Rett.Text = "";
                        SucNote.Visible = true;
                        Save.CommandArgument = "";
                        LblView.Text = "A";
                    }
                }

                else { Rett.Text = "التوصية مكررة لنفس الملاحظة "; }
            }

        }

        catch { }
    }

    protected void RepNotes_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
     

        Image td2 = (Image)e.Item.FindControl("TDNote2");

        Label LblNotStat = (Label)e.Item.FindControl("LblNotStat");

        if ((((Label)e.Item.FindControl("ComCount")).Text != "") && (((Label)e.Item.FindControl("ComCount")).Text != null))
        {
            ((Label)e.Item.FindControl("ComCount")).Text = "[" + ((Label)e.Item.FindControl("ComCount")).Text + "]";
        }
        else
        {
            ((Label)e.Item.FindControl("ComCount")).Text = "لايوجد";
        }

        Image NotSt = (Image)e.Item.FindControl("NotSt");
        if (LblNotStat.Text == "true")
        {
            LblNotStat.Text = "مكررة";
        }
        else
        {
            LblNotStat.Text = "غير مكررة";
        }
        if ((((Label)e.Item.FindControl("FNoteCount")).Text != "") && (((Label)e.Item.FindControl("FNoteCount")).Text != "0"))
        {
            ((LinkButton)e.Item.FindControl("LinkNoteFiles")).Attributes.Remove("Style");
            ((LinkButton)e.Item.FindControl("LinkNoteFiles")).Style.Add("display", "block");
            ((LinkButton)e.Item.FindControl("LinkNoteFiles")).Text += " [ " + ((Label)e.Item.FindControl("FNoteCount")).Text + " ] ";
            ((System.Web.UI.HtmlControls.HtmlGenericControl)(e.Item.FindControl("NoNoteFiles"))).Visible = false;

        }
        else
        {
            ((LinkButton)e.Item.FindControl("LinkNoteFiles")).Attributes.Remove("Style");
            ((LinkButton)e.Item.FindControl("LinkNoteFiles")).Style.Add("display", "none");
            ((System.Web.UI.HtmlControls.HtmlGenericControl)(e.Item.FindControl("NoNoteFiles"))).Visible = true;
        }



        ((System.Web.UI.HtmlControls.HtmlGenericControl)(e.Item.FindControl("well"))).InnerHtml = Server.HtmlDecode(((Label)e.Item.FindControl("LitDetail")).Text);
        ((System.Web.UI.HtmlControls.HtmlGenericControl)(e.Item.FindControl("Div2"))).InnerHtml = Server.HtmlDecode(((Label)e.Item.FindControl("LbCorrect")).Text);

        if (((Label)e.Item.FindControl("LblNoteStat")).Text == "3")
        {

            td2.ImageUrl = "assets/icons/levels/L2/solved3.png";
            NotSt.ImageUrl = "assets/icons/levels/L2/solved3.png";
        }
        else if (((Label)e.Item.FindControl("LblNoteStat")).Text == "2")
        {
            NotSt.ImageUrl = "assets/icons/levels/L2/under3.png";

            td2.ImageUrl = "assets/icons/levels/L2/under3.png";
        }
        else if (((Label)e.Item.FindControl("LblNoteStat")).Text == "1")
        {
            NotSt.ImageUrl = "assets/icons/levels/L2/hold3.png";
            td2.ImageUrl = "assets/icons/levels/L2/hold3.png";
        }

        else if (((Label)e.Item.FindControl("LblNoteStat")).Text == "4")
        {
            NotSt.ImageUrl = "assets/icons/levels/L2/notstart3.png";

            td2.ImageUrl = "assets/icons/levels/L2/notstart3.png";
        }
        else if (((Label)e.Item.FindControl("LblNoteStat")).Text == "5")
        {
            NotSt.ImageUrl = "assets/icons/levels/L2/closed3.png";
            td2.ImageUrl = "assets/icons/levels/L2/closed3.png";
        }
    }
    protected void LnkCommentNote_Command(object sender, CommandEventArgs e)
    {
        LblViews.Text = "Edt";
        DataSet Ds = Obj.GetDataSetByID("GetNoteConfirm", Convert.ToInt32(e.CommandArgument));

        if (Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow Row in Ds.Tables[0].Rows)
            {
                LblCommDate.Text = Convert.ToString(Row["ConfirmDate"]);

                LblCommTxt.InnerText = RemoveStyle(System.Net.WebUtility.HtmlDecode(Convert.ToString(Row["ConfirmText"])));
            }
        }
        DataSet DsFiles = Obj.GetDataSetByID("GetNoteFilesComment", Convert.ToInt32(e.CommandArgument));
        RepAttach.DataSource = DsFiles;
        RepAttach.DataBind();

        CloseOthers();
        LblCommID.Text = e.CommandArgument.ToString();
        AllFiles_modal.Attributes.Remove("Style");
        AllFiles_modal.Style.Add("display", "block");


    }

    protected void LinkNoteFiles_Command(object sender, CommandEventArgs e)
    {

        NoteId.Text = e.CommandArgument.ToString();
        DataSet DsFiles = Obj.GetDataSetByID("GetNoteFiles", Convert.ToInt32(e.CommandArgument));
        RpeaterFiles.DataSource = DsFiles;
        RpeaterFiles.DataBind();
        CloseOthers();
        RepFiles_modal.Attributes.Remove("Style");
        RepFiles_modal.Style.Add("display", "block");


    }
    private void SearchbyRepeat()
    {
        DataSet MyRecDataSet = (DataSet)Session["UData"];

        //Bind Data According to Repeat
        EmployeesData.DataSource = null;
        EmployeesData.DataBind();
        var Repeatchecked = 0;



        if (HiddenPost.Value == "1")
        {
            Repeatchecked = 1;

        }
        EmployeesData.DataSource = Obj.ReportFilterAll(Convert.ToInt32(MyRecDataSet.Tables[0].Rows[0]["AdmID"]), Convert.ToInt32(MyRecDataSet.Tables[0].Rows[0]["SectionID"]), Convert.ToInt32(Importance.SelectedValue), Convert.ToInt32(RadioStatus.SelectedValue), RepeatSearch.Checked, CheckRepeat.Checked, DateFromSearch.Value.Equals("") ? "0" : DateFromSearch.Value, Convert.ToInt32(PlansSearch.SelectedValue), Repeatchecked);
        EmployeesData.DataBind();



    }
    protected void CheckRepeat_CheckedChanged(object sender, EventArgs e)
    {
        //Bind Data According to Repeat
        DataSet MyRecDataSet = (DataSet)Session["UData"];
        EmployeesData.DataSource = null;
        EmployeesData.DataBind();
        var Repeatchecked = 0;



        if (HiddenPost.Value == "1")
        {
            Repeatchecked = 1;

        }
        EmployeesData.DataSource = Obj.ReportFilterAll(Convert.ToInt32(MyRecDataSet.Tables[0].Rows[0]["AdmID"]), Convert.ToInt32(MyRecDataSet.Tables[0].Rows[0]["SectionID"]), Convert.ToInt32(Importance.SelectedValue), Convert.ToInt32(RadioStatus.SelectedValue), RepeatSearch.Checked, CheckRepeat.Checked, DateFromSearch.Value.Equals("") ? "0" : DateFromSearch.Value, Convert.ToInt32(PlansSearch.SelectedValue), Repeatchecked);
        EmployeesData.DataBind();
    }


    protected void LinkReports_Command(object sender, CommandEventArgs e)
    {

        RepReplys.DataSource = Obj.GetDataSetByID("GetReportConfirm", Convert.ToInt32(e.CommandArgument));
        RepReplys.DataBind();
        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "GetReplys();", true);

    }
    protected void NoteReplys_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {

        /*-------التعديل-----------*/
        if ((((Label)e.Item.FindControl("LblUID")).Text != "") && (((Label)e.Item.FindControl("LblUID")).Text != null))
        {
            DataSet MyRecDataSet = (DataSet)Session["UData"];

            if (Convert.ToInt32(MyRecDataSet.Tables[0].Rows[0]["EmpID"]) == Convert.ToInt32(((Label)e.Item.FindControl("LblUID")).Text))
            {
                ((LinkButton)e.Item.FindControl("EditNoteReply")).Enabled = true;
                ((System.Web.UI.HtmlControls.HtmlGenericControl)(e.Item.FindControl("DelNReply"))).Attributes.Remove("Style");
                ((System.Web.UI.HtmlControls.HtmlGenericControl)(e.Item.FindControl("DelNReply"))).Style.Add("display", "inline-block");

                ((System.Web.UI.HtmlControls.HtmlGenericControl)(e.Item.FindControl("DelNReplyView"))).Attributes.Remove("Style");
                ((System.Web.UI.HtmlControls.HtmlGenericControl)(e.Item.FindControl("DelNReplyView"))).Style.Add("display", "none");

                
            }
            else
            {
                ((LinkButton)e.Item.FindControl("EditNoteReply")).Enabled = false;
                ((System.Web.UI.HtmlControls.HtmlGenericControl)(e.Item.FindControl("DelNReply"))).Attributes.Remove("Style");
                ((System.Web.UI.HtmlControls.HtmlGenericControl)(e.Item.FindControl("DelNReply"))).Style.Add("display", "none");

                ((System.Web.UI.HtmlControls.HtmlGenericControl)(e.Item.FindControl("DelNReplyView"))).Attributes.Remove("Style");
                ((System.Web.UI.HtmlControls.HtmlGenericControl)(e.Item.FindControl("DelNReplyView"))).Style.Add("display", "inline-block");

            }


        }

        /*----------------*/
        if (((Literal)e.Item.FindControl("LitNoteText")).Text != "")
        {
            ((Literal)e.Item.FindControl("LitNoteText")).Text = RemoveStyle(System.Net.WebUtility.HtmlDecode(((Literal)e.Item.FindControl("LitNoteText")).Text));
        }

        if ((((Label)e.Item.FindControl("FNoteCount")).Text != "") && (((Label)e.Item.FindControl("FNoteCount")).Text != "0"))
        {
            ((LinkButton)e.Item.FindControl("LinkNotFiles")).Attributes.Remove("Style");
            ((LinkButton)e.Item.FindControl("LinkNotFiles")).Style.Add("display", "block");
            ((LinkButton)e.Item.FindControl("LinkNotFiles")).Text += " [ " + ((Label)e.Item.FindControl("FNoteCount")).Text + " ] ";
            ((System.Web.UI.HtmlControls.HtmlGenericControl)(e.Item.FindControl("NoNotefiles"))).Visible = false;

        }
        else
        {
            ((LinkButton)e.Item.FindControl("LinkNotFiles")).Attributes.Remove("Style");
            ((LinkButton)e.Item.FindControl("LinkNotFiles")).Style.Add("display", "none");
            ((System.Web.UI.HtmlControls.HtmlGenericControl)(e.Item.FindControl("NoNotefiles"))).Visible = true;
        }
    }
    protected void RepReplys_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (((Literal)e.Item.FindControl("LitText")).Text != "")
        {
            ((Literal)e.Item.FindControl("LitText")).Text = RemoveStyle(System.Net.WebUtility.HtmlDecode(((Literal)e.Item.FindControl("LitText")).Text));
        }

        if ((((Label)e.Item.FindControl("FCount")).Text != "") && (((Label)e.Item.FindControl("FCount")).Text != "0"))
        {
            ((LinkButton)e.Item.FindControl("LinkRepFiles")).Attributes.Remove("Style");
            ((LinkButton)e.Item.FindControl("LinkRepFiles")).Style.Add("display", "block");
            ((LinkButton)e.Item.FindControl("LinkRepFiles")).Text += " [ " + ((Label)e.Item.FindControl("FCount")).Text + " ] ";
            ((System.Web.UI.HtmlControls.HtmlGenericControl)(e.Item.FindControl("Nofiles"))).Visible = false;

        }
        else
        {
            ((LinkButton)e.Item.FindControl("LinkRepFiles")).Attributes.Remove("Style");
            ((LinkButton)e.Item.FindControl("LinkRepFiles")).Style.Add("display", "none");
            ((System.Web.UI.HtmlControls.HtmlGenericControl)(e.Item.FindControl("Nofiles"))).Visible = true;
        }

    }

    protected void LinkRepFiles_Command(object sender, CommandEventArgs e)
    {
        LblViews.Text = "Conf";
        DataSet DsFiles = Obj.GetDataSetByID("GetReportFilesComment", Convert.ToInt32(e.CommandArgument));
        RepAttach.DataSource = DsFiles;
        RepAttach.DataBind();


        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "GetAttach();", true);




    }
    protected void LinkNotFiles_Command(object sender, CommandEventArgs e)
    {
        LblViews.Text = "Conf";



        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "GetAttach();", true);


    }

    protected void LinkNotes_Command(object sender, CommandEventArgs e)
    {
        NoteReplys.DataSource = Obj.GetDataSetByID("GetNoteConfirm", Convert.ToInt32(e.CommandArgument));
        NoteReplys.DataBind();
        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "GetNoteReplys();", true);
        CloseOthers();
        modalNoteReplys.Attributes.Remove("Style");
        modalNoteReplys.Style.Add("display", "block");
        NoteReply.Text = e.CommandArgument.ToString();

        BackReplies.Attributes.Remove("Style");
        BackReplies.Style.Add("display", "none");

        SucReplynew.Attributes.Remove("Style");
        SucReplynew.Style.Add("display", "none");
    }


    protected void AddNoteFile_Click(object sender, EventArgs e)
    {
        DataSet MyRecDataSet = (DataSet)Session["UData"];

        if (LblNotNew.Text.Length <= 0)
        {

            LblNotNew.Text = Convert.ToString(Obj.NewTempReportNote(Convert.ToInt32(MyRecDataSet.Tables[0].Rows[0]["EmpID"]), hf2.Value, DFromNoteUDP.Value, 0, Convert.ToInt32(RadioButtonList2.SelectedValue), LblRepeatU.Checked, Convert.ToInt32(LblEditID.Text), hf2N.Value));

        }

        if (FileUpload01.FileName.Length > 0)
        {
            string ext = System.IO.Path.GetExtension(FileUpload01.PostedFile.FileName);
            if (ext != ".exe" || ext != ".php")
            {
                var imgPath = "";
                //sets the image path
                var r = new Random();
                // print random integer >= 0 and  < 100

                imgPath = "Uploads/" + r.Next(100) + FileUpload01.FileName;

                //get the size in bytes that
                FileUpload01.SaveAs(Server.MapPath(imgPath));
                LblNoteFileExist.Visible = false;


                var Res = Obj.NewAttachNote(Convert.ToInt32(LblNotNew.Text), imgPath, FileUpload01.FileName);
                if (Res != 0)
                {

                    if (Res == -1)
                    {
                        LblNoteFileExist.Visible = true;

                    }
                    else
                    {
                        LblNoteFileExist.Visible = false;





                        LblView.Text = "A";
                        DataSet DsFiles = Obj.GetDataSetByID("GetNoteFiles", Convert.ToInt32(LblNotNew.Text));
                        RepeateNoteFiles.DataSource = null;
                        RepeateNoteFiles.DataBind();
                        RepeateNoteFiles.DataSource = DsFiles;
                        RepeateNoteFiles.DataBind();
                        SucNoteFile.Visible = true;
                    }

                }
            }
        }
    }

    // add note
    protected void AddNote_Command(object sender, CommandEventArgs e)
    {

        DFromNoteUDP.Value = "";
        RadioButtonList1.SelectedValue = "0";
        RadioButtonList2.SelectedValue = "0";
        LblRepeatU.Checked = false;
        Save.CommandArgument = "";
        editor1.InnerText = "";
        editor1N.InnerText = "";

        SucNoteFile.Visible = false;
        RepeateNoteFiles.DataSource = null;
        RepeateNoteFiles.DataBind();

        Save.CommandArgument = e.CommandArgument.ToString();
        LblUpdate.Text = "";
        LblEditID.Text = "";
        CloseOthers();
        NewNote.Attributes.Remove("Style");
        NewNote.Style.Add("display", "block");

    }


    protected void BackTables_Click(object sender, EventArgs e)
    {
        /*-------تعديل-------*/
        HiddenPost.Value = "1";

        /*--------------*/
        CloseOthers();
        MainTable.Attributes.Remove("Style");
        MainTable.Style.Add("display", "block");

    }


    private void CloseOthers()
    {
        DataSet MyRecDataSet = (DataSet)Session["UData"];

        var Repeatchecked = 0;

        if (HiddenPost.Value == "1")
        {
            Repeatchecked = 1;

        }
        EmployeesData.DataSource = null;
        EmployeesData.DataBind();
        EmployeesData.DataSource = Obj.ReportFilterAll(Convert.ToInt32(Mang.SelectedValue), Convert.ToInt32(MyRecDataSet.Tables[0].Rows[0]["SectionID"]), Convert.ToInt32(Importance.SelectedValue), Convert.ToInt32(RadioStatus.SelectedValue), RepeatSearch.Checked, CheckRepeat.Checked, DateFromSearch.Value.Equals("") ? "0" : DateFromSearch.Value, Convert.ToInt32(PlansSearch.SelectedValue), Repeatchecked);
        EmployeesData.DataBind();

        MainTable.Attributes.Remove("Style");
        MainTable.Style.Add("display", "none");

        NewNote.Attributes.Remove("Style");
        NewNote.Style.Add("display", "none");

        RepFiles_modal.Attributes.Remove("Style");
        RepFiles_modal.Style.Add("display", "none");
        modalNoteReplys.Attributes.Remove("Style");
        modalNoteReplys.Style.Add("display", "none");

        AllFiles_modal.Attributes.Remove("Style");
        AllFiles_modal.Style.Add("display", "none");


        RepDetail.Attributes.Remove("Style");
        RepDetail.Style.Add("display", "none");
        NoteDetails.Attributes.Remove("Style");
        NoteDetails.Style.Add("display", "none");


        // Comm_modal.Attributes.Remove("Style");
        // Comm_modal.Style.Add("display", "none");
        modalNoteReplys.Attributes.Remove("Style");
        modalNoteReplys.Style.Add("display", "none");
        //AllFiles_modalCom.Attributes.Remove("Style");
        //AllFiles_modalCom.Style.Add("display", "none");
        modalNoteReplyNew.Attributes.Remove("Style");
        modalNoteReplyNew.Style.Add("display", "none");

    }


    protected void AddNoe_Click(object sender, EventArgs e)
    {
        PagTitle.InnerText = "الإطلاع على الملاحظات" + ">" + "عرض واضافة توصيات" + ">" + "إضافة توصية";
        CloseOthers();
        NewNote.Attributes.Remove("Style");
        NewNote.Style.Add("display", "block");
    }

    protected void BackNotes_Click(object sender, EventArgs e)
    {
        PagTitle.InnerText = "الإطلاع على الملاحظات" + ">" + "عرض واضافة توصيات";
        CloseOthers();
        NoteDetails.Attributes.Remove("Style");
        NoteDetails.Style.Add("display", "block");

        SucReplynew.Attributes.Remove("Style");
        SucReplynew.Attributes.Add("display", "block");
        RepNotes.DataSource = Obj.GetDataSetByID("GetNotes", Convert.ToInt32(LblEditID.Text));
        RepNotes.DataBind();
    }
    protected void Mang_SelectedIndexChanged(object sender, EventArgs e)
    {
        MangSelectedIndexChanged();
    }

    private void MangSelectedIndexChanged()
    {
        if (Mang.SelectedValue != "")
        {
            //if (Admins1.SelectedValue != "0")
            //{
            //    Admins1.SelectedValue = "0";
            //}

            //if (Mang.SelectedValue != "0")
            //{
            //    DataTable DTImportant = Obj.GetDataSetByID("ReportCountImportByAdm", Convert.ToInt32(Mang.SelectedValue)).Tables[0];

            //    DataTable DTStatus = Obj.GetDataSetByID("ReportCountStatusByAdm", Convert.ToInt32(Mang.SelectedValue)).Tables[0];

            //    foreach (ListItem ltItem in Importance.Items)
            //    {
            //        if (ltItem.Value != "0")
            //        {
            //            var dT = DTImportant.AsEnumerable().Where(x => x.Field<int>("Importance") == Convert.ToInt32(ltItem.Value)).FirstOrDefault();
            //            string Counts = "0";
            //            if (dT != null)
            //            {
            //                Counts = dT["Counts"].ToString();
            //            }
            //            ltItem.Text = ltItem.Text.Substring(0, ltItem.Text.LastIndexOf('[') - 1) + " [ " + Counts + " ] ";
            //        }
            //    }
            //    foreach (ListItem ltItem in RadioStatus.Items)
            //    {
            //        if (ltItem.Value != "0")
            //        {
            //            var dT = DTStatus.AsEnumerable().Where(x => x.Field<int>("RepStatus") == Convert.ToInt32(ltItem.Value)).FirstOrDefault();

            //            string Counts = "0";
            //            if (dT != null)
            //            {
            //                Counts = dT["Counts"].ToString();
            //            }
            //            ltItem.Text = ltItem.Text.Substring(0, ltItem.Text.LastIndexOf('[') - 1) + " [ " + Counts + " ] ";
            //        }
            //    }



            //}
            //else
            //{
            //    if (Sector.SelectedValue != "")
            //    {
            //        if (Sector.SelectedValue != "0")
            //        {
            //            DataTable DTImportant = Obj.GetDataSetByID("ReportCountImportBySec", Convert.ToInt32(Sector.SelectedValue)).Tables[0];

            //            DataTable DTStatus = Obj.GetDataSetByID("ReportCountStatusBySec", Convert.ToInt32(Sector.SelectedValue)).Tables[0];

            //            foreach (ListItem ltItem in Importance.Items)
            //            {
            //                if (ltItem.Value != "0")
            //                {
            //                    var dT = DTImportant.AsEnumerable().Where(x => x.Field<int>("Importance") == Convert.ToInt32(ltItem.Value)).FirstOrDefault();
            //                    string Counts = "0";
            //                    if (dT != null)
            //                    {
            //                        Counts = dT["Counts"].ToString();
            //                    }
            //                    ltItem.Text = ltItem.Text.Substring(0, ltItem.Text.LastIndexOf('[') - 1) + " [ " + Counts + " ] ";
            //                }
            //            }
            //            foreach (ListItem ltItem in RadioStatus.Items)
            //            {
            //                if (ltItem.Value != "0")
            //                {
            //                    var dT = DTStatus.AsEnumerable().Where(x => x.Field<int>("RepStatus") == Convert.ToInt32(ltItem.Value)).FirstOrDefault();
            //                    string Counts = "0";
            //                    if (dT != null)
            //                    {
            //                        Counts = dT["Counts"].ToString();
            //                    }

            //                    ltItem.Text = ltItem.Text.Substring(0, ltItem.Text.LastIndexOf('[') - 1) + " [ " + Counts + " ] ";
            //                }
            //            }

            //        }
            //    }
            //}
            EmployeesData.DataSource = null;
            EmployeesData.DataBind();
            var Repeatchecked = 0;

            if (HiddenPost.Value == "1")
            {
                Repeatchecked = 1;

            }

            if (Session["UData"] != null)
            {
                DataSet MyRecDataSet = (DataSet)Session["UData"];
                EmployeesData.DataSource = Obj.ReportFilterAll(Convert.ToInt32(Mang.SelectedValue), Convert.ToInt32(MyRecDataSet.Tables[0].Rows[0]["SectionID"]), Convert.ToInt32(Importance.SelectedValue), Convert.ToInt32(RadioStatus.SelectedValue), RepeatSearch.Checked, CheckRepeat.Checked, DateFromSearch.Value.Equals("") ? "0" : DateFromSearch.Value, Convert.ToInt32(PlansSearch.SelectedValue), Repeatchecked);
                EmployeesData.DataBind();
            }
        }
    }

    protected void PlansSearch_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Session["UData"] != null)
        {
            DataSet MyRecDataSet = (DataSet)Session["UData"];

            if (PlansSearch.SelectedValue != "0")
            {
                Mang.Items.Clear();

                Mang.DataSource = Obj.GetDataSetBy2ID("GetAdminByYear", Convert.ToInt32(MyRecDataSet.Tables[0].Rows[0]["SectionID"]), Convert.ToInt32(PlansSearch.SelectedValue));
                Mang.DataTextField = "AdmName";
                Mang.DataValueField = "AdmID";
                Mang.DataBind();
                ListItem aa0 = new ListItem();
                aa0.Text = "اختر الإدارة متوسطة";
                aa0.Value = "0";

                Mang.Items.Insert(0, aa0);

                EmployeesData.DataSource = null;
                EmployeesData.DataBind();
                var Repeatchecked = 0;

                if (HiddenPost.Value == "1")
                {
                    Repeatchecked = 1;

                }
                EmployeesData.DataSource = Obj.ReportFilterAll(Convert.ToInt32(Mang.SelectedValue), Convert.ToInt32(MyRecDataSet.Tables[0].Rows[0]["SectionID"]), Convert.ToInt32(Importance.SelectedValue), Convert.ToInt32(RadioStatus.SelectedValue), RepeatSearch.Checked, CheckRepeat.Checked, DateFromSearch.Value.Equals("") ? "0" : DateFromSearch.Value, Convert.ToInt32(PlansSearch.SelectedValue), Repeatchecked);
                EmployeesData.DataBind();
            }

            else
            {
                Mang.Items.Clear();
                Mang.DataSource = Obj.GetDataSetByID("GetAdministrations", Convert.ToInt32(MyRecDataSet.Tables[0].Rows[0]["SectionID"]));
                Mang.DataTextField = "AdmName";
                Mang.DataValueField = "AdmID";
                Mang.DataBind();
                ListItem aa0 = new ListItem();
                aa0.Text = "اختر الإدارة متوسطة";
                aa0.Value = "0";

                Mang.Items.Insert(0, aa0);

            }
        }
    }

    protected void SaveComment_Click(object sender, EventArgs e)
    {
        try
        {
            if (hfRep.Value != "")
            {
                if (Session["UData"] != null)
                {
                    DataSet MyRecDataSet = (DataSet)Session["UData"];


                    Suc.Visible = false;
                    var Ret = 0;



                    if (ConfirmId.Text != "")
                    {
                        Ret = Obj.ActiveReportComment(Convert.ToInt32(ConfirmId.Text), hfRep.Value);
                    }
                    else
                    {
                        ConfirmId.Text = Obj.NewNoteComment(Convert.ToInt32(NoteReply.Text), Convert.ToInt32(MyRecDataSet.Tables[0].Rows[0]["EmpID"]), hfRep.Value).ToString();

                        Ret = Obj.ActiveReportComment(Convert.ToInt32(ConfirmId.Text), hfRep.Value);

                    }

                    if (Ret != 0)
                    {
                        CloseOthers();
                        modalNoteReplys.Attributes.Remove("Style");
                        modalNoteReplys.Style.Add("display", "block");

                        RettComment.Text = "";
                        SucReplynew.Visible = true;

                        NoteReplys.DataSource = Obj.GetDataSetByID("GetNoteConfirm", Convert.ToInt32(NoteReply.Text));
                        NoteReplys.DataBind();


                        DataSet Ds = Obj.GetDataSetByID("GetNoteByID", Convert.ToInt32(NoteReply.Text));

                        if (Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow Row in Ds.Tables[0].Rows)
                            {




                                string Body = @"<html>

<body>

    <div style='direction:rtl;text-align:right;'>
   
 <h3 style = 'color: #b0b0b0;'>   عزيزي الموظف تم الرد على التوصية  التي تخصكم في منصة المراجعة الداخلية</h3>

                                       
        <b>
            -: يوجد رد جديد على التوصية رقم " + Convert.ToString(Row["NoteCount"]) + @" للملاحظة رقم " + Convert.ToString(Row["RepCode"]) + @" كما هو موضح في التفاصيل ادناه
        </b>
        <ul dir='rtl'>

            <li>
                <b>موجه لإدارة عليا:</b>
                <br />
" + MyRecDataSet.Tables[0].Rows[0]["SectionName"] + @"
            </li>
            <li>
                <b>موجه لإدارة متوسطة:</b>

                <br />
" + MyRecDataSet.Tables[0].Rows[0]["AdmName"] + @"
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
                <b>رقم التوصية:</b>

                <br />
" + Convert.ToString(Row["NoteCount"]) + @"
            </li>
            <li>
                <b>تاريخ تنفيذ التوصية:</b>

                <br />
" + Convert.ToString(Row["NoteDate"]) + @"
            </li>
            <li>
                <b>تم الرد من قبل:</b>

                <br />
" + MyRecDataSet.Tables[0].Rows[0]["EmpName"] + @"
            </li>

        </ul>


    ";
                                Body += "<div><b>ملفات مرفقة:</b></div><ul style='list-style: none;'>";


                                DataSet DsFil = Obj.GetDataSetByID("GetNoteFilesComment", Convert.ToInt32(ConfirmId.Text));


                                if (DsFil.Tables.Count > 0 && DsFil.Tables[0].Rows.Count > 0)
                                {
                                    foreach (DataRow RowFile in DsFil.Tables[0].Rows)
                                    {
                                        if (RowFile["FPath"] != null)
                                        {
                                            Body += "<li><a href='" + HttpContext.Current.Request.Url.Authority + "/" + Convert.ToString(RowFile["FPath"]) + "'/>" + Convert.ToString(RowFile["FName"]) + "<li>";
                                        }
                                    }
                                }

                                Body += @"</ul></div><div style='text-align:right; direction:ltr;'>
            <b>    للاطلاع على مزيد من التفاصيل اضغط هنا <a href='" + HttpContext.Current.Request.Url.Authority + @"'>رابط التوصية</a></b>
</div>

    
</body>
</html>";





                                Obj.OurMails("رد على التوصية ", Body, Convert.ToInt32(Ds.Tables[0].Rows[0]["RepSection"]), Convert.ToInt32(Ds.Tables[0].Rows[0]["RepAdms"]), true);



                            }
                        }



                    }


                    else { Rett.Text = "حدث خطأ "; }




                }
            }
            else
            {
                RettComment.Text = "لايوجد نص";
            }
        }
        catch { }
    }


    protected void AddFile_Click(object sender, EventArgs e)
    {
        SucFile.Visible = false;
        if (FileUploadR.FileName.Length > 0)
        {
            string ext = System.IO.Path.GetExtension(FileUploadR.PostedFile.FileName);
            if (ext != ".exe" || ext != ".php")
            {
                var imgPath = "";
                //sets the image path
                var r = new Random();
                // print random integer >= 0 and  < 100

                imgPath = "Uploads/" + r.Next(100) + FileUploadR.FileName;

                //get the size in bytes that
                FileUploadR.SaveAs(Server.MapPath(imgPath));
                LblEroor.Visible = false;

                if (NoteId.Text != "")
                {
                    var Res = Obj.NewAttachNote(Convert.ToInt32(NoteId.Text), imgPath, FileUploadR.FileName);
                    if (Res != 0)
                    {

                        if (Res == -1)
                        {

                            LblEroorNote.Visible = true;
                            LblViews.Text = "Rep";
                        }
                        else
                        {

                            SucFile.Visible = true;
                            DataSet DsFiles = Obj.GetDataSetByID("GetNoteFiles", Convert.ToInt32(NoteId.Text));
                            RpeaterFiles.DataSource = DsFiles;
                            RpeaterFiles.DataBind();

                            LblViews.Text = "Rep";

                        }
                    }
                    else { SucFile.Visible = false; }
                }

                BindEmployeesData();
            }
        }
    }


    protected void DelFile_Click(object sender, EventArgs e)
    {
        SucDelRepl.Visible = false;
        var Res = Obj.ExecuteProcedureID("DelReportAttach", Convert.ToInt32(FileId.Value));
        if (Res == 1)
        {
            SucDelRepComm.Visible = true;
            CloseOthers();

            DataSet DsFiles = Obj.GetDataSetByID("GetNoteFilesComment", Convert.ToInt32(LblCommID.Text));
            RepAttach.DataSource = DsFiles;
            RepAttach.DataBind();
            AllFiles_modal.Attributes.Remove("Style");
            AllFiles_modal.Style.Add("display", "block");
        }
    }

    protected void BackReplies_Click(object sender, EventArgs e)
    {
        NoteReplys.DataSource = Obj.GetDataSetByID("GetNoteConfirm", Convert.ToInt32(NoteReply.Text));
        NoteReplys.DataBind();
        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "GetNoteReplys();", true);
        CloseOthers();
        modalNoteReplys.Attributes.Remove("Style");
        modalNoteReplys.Style.Add("display", "block");
    }
    protected void AddNewReply_Click(object sender, EventArgs e)
    {
        CloseOthers();
        modalNoteReplyNew.Attributes.Remove("Style");
        modalNoteReplyNew.Style.Add("display", "block");

        //SucFile3.Attributes.Remove("Style");
        //SucFile3.Style.Add("display", "block");

        SucFile3.Visible = false;

        Repeater1.DataSource = null;
        Repeater1.DataBind();


    }

    protected void AddfileReply_Click(object sender, EventArgs e)
    {
        if (Session["UData"] != null)
        {
            DataSet MyRecDataSet = (DataSet)Session["UData"];

            SucFile3.Visible = false;

            if (FileUpload3.FileName.Length > 0)
            {
                var imgPath = "";
                //sets the image path
                var r = new Random();
                // print random integer >= 0 and  < 100

                imgPath = "Uploads/" + r.Next(100) + FileUpload3.FileName;

                //get the size in bytes that
                FileUpload3.SaveAs(Server.MapPath(imgPath));
                LblEroor.Visible = false;

                if (ConfirmId.Text == "")
                {
                    ConfirmId.Text = Convert.ToString(Obj.NewNoteComment(Convert.ToInt32(NoteReply.Text), Convert.ToInt32(MyRecDataSet.Tables[0].Rows[0]["EmpID"]), hfRep.Value));
                }

                var Res = Obj.NewAttachCommentNote(Convert.ToInt32(ConfirmId.Text), imgPath, FileUpload3.FileName);
                if (Res != 0)
                {
                    if (Res == -1)
                    {
                        LblEroorNote.Visible = true;
                    }
                    else
                    {

                        SucFile3.Visible = true;
                        DataSet DsFiles = Obj.GetDataSetByID("GetNoteFilesComment", Convert.ToInt32(ConfirmId.Text));
                        Repeater1.DataSource = DsFiles;
                        Repeater1.DataBind();

                    }
                }
                else { SucFile3.Visible = false; }

                NoteId.Text = "A";

            }

            editorReply.InnerHtml = System.Net.WebUtility.HtmlDecode(hfRep.Value);

        }
    }

    protected void EditNoteReply_Command(object sender, CommandEventArgs e)
    {
        string[] arg = new string[2];
        arg = e.CommandArgument.ToString().Split(';');
        NoteReplys.DataSource = Obj.GetDataSetByID("GetNoteConfirm", Convert.ToInt32(LblEditID.Text));
        NoteReplys.DataBind();

        DataSet DsFiles = Obj.GetDataSetByID("GetNoteFilesComment", Convert.ToInt32(arg[0]));
        Repeater1.DataSource = DsFiles;
        Repeater1.DataBind();
        DataSet Ds = Obj.GetDataSetByID("GetConfirmByID", Convert.ToInt32(arg[0]));

        if (Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow Row in Ds.Tables[0].Rows)
            {
                editorReply.InnerHtml = System.Net.WebUtility.HtmlDecode(Convert.ToString(Row["ConfirmText"]));
            }
        }
        ConfirmId.Text = arg[0];
        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "GetNoteReplys();", true);
        CloseOthers();
        modalNoteReplyNew.Attributes.Remove("Style");
        modalNoteReplyNew.Style.Add("display", "block");
    }
}
