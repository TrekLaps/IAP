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

public partial class NewReport : System.Web.UI.Page
{
    Operations Obj = new Operations();

    private void BindEmployeesData()
    {
        EmployeesData.DataSource = null;
        EmployeesData.DataBind();
        if (Session["UData"] != null)
        {
            DataSet MyRecDataSet = (DataSet)Session["UData"];
            string Tmp = "Temp" + Convert.ToInt32(MyRecDataSet.Tables[0].Rows[0]["EmpID"]);
            //+ DateTime.Now.Date + DateTime.Now.Hour
            EmployeesData.DataSource = Obj.GetDataSetByString("GetTempReports", Tmp);
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

                if (Convert.ToBoolean(MyRecDataSet.Tables[0].Rows[0]["ApprovPermission"]) == true || Convert.ToBoolean(MyRecDataSet.Tables[0].Rows[0]["SystemAdmin"]) == true)
                {

                    DropYear.DataSource = Obj.GetDataSet("GetPlans");
                    DropYear.DataTextField = "YearName";
                    DropYear.DataValueField = "ID";
                    DropYear.DataBind();

                    BindEmployeesData();

                }
                else
                {
                    Response.Redirect("NoPermissions.aspx");
                }
            }
        }
        else
        {


            RepId.Text = "";
            SucDel.Visible = false; Suc.Visible = false;
            SucNote.Visible = false;
            SucFile.Visible = false;



        }
    }


    protected void Edit_Command(object sender, CommandEventArgs e)
    {

        try
        {
            DataSet DsRep = Obj.GetDataSetByID("GetReportByID", Convert.ToInt32(e.CommandArgument));

            if (DsRep.Tables.Count > 0 && DsRep.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow RowRep in DsRep.Tables[0].Rows)
                {
                    LblReptitle.Text = Convert.ToString(RowRep["RepTitle"]);

                    LblNoteCount.Text = Convert.ToString(RowRep["NoteCount"]);

                    LblRepDate.Text = Convert.ToString(RowRep["RepDate"]);

                    LblForSec.Text = Convert.ToString(RowRep["RepSection"]);
                    LblForAdm.Text = Convert.ToString(RowRep["RepAdm"]);
                    var Imp = Convert.ToString(RowRep["Importance"]);


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
                    LblDateFrom.Text = Convert.ToString(RowRep["RepFrom"]);
                    LblNo.Text = Convert.ToString(RowRep["RepCode"]);
                    if (Convert.ToBoolean(RowRep["RepRepeat"]) == true) { RPTSign.Text = "مكرر"; }
                    else { RPTSign.Text = "غير مكرر"; }
                    var Status = Convert.ToString(RowRep["RepStatus"]);

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


                    Test.InnerHtml = System.Net.WebUtility.HtmlDecode(Convert.ToString(RowRep["RepText"]));
                    RepImpTxt.InnerHtml = System.Net.WebUtility.HtmlDecode(Convert.ToString(RowRep["RepImpText"]));


                }
                RepDetail.Attributes.Remove("Style");
                RepDetail.Style.Add("display", "block");

            }
            CloseOthers();
            RepDetail.Attributes.Remove("Style");
            RepDetail.Style.Add("display", "block");
            DataSet Ds = new DataSet();
            RepNotes.DataSource = Obj.GetDataSetByID("GetNotes", Convert.ToInt32(e.CommandArgument));
            RepNotes.DataBind();

            LblEditID.Text = e.CommandArgument.ToString();
        }
        catch { }
    }



    protected void BackNotes_Click(object sender, EventArgs e)
    {
        CloseOthers();
        RepDetail.Attributes.Remove("Style");
        RepDetail.Style.Add("display", "block");
    }


    protected void EmployeesData_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Image td = (Image)e.Item.FindControl("TD1");
        Image td2 = (Image)e.Item.FindControl("TD2");



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

    protected void LnkComment_Command(object sender, CommandEventArgs e)
    {
        DataSet Ds = Obj.GetDataSetByID("GetReportConfirm", Convert.ToInt32(e.CommandArgument));

        if (Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow Row in Ds.Tables[0].Rows)
            {
                LblCommDate.Text = Convert.ToString(Row["ConfirmDate"]);

                LblCommRepID.Text = Convert.ToString(e.CommandArgument);
                LblCommTxt.InnerText = System.Net.WebUtility.HtmlDecode(Convert.ToString(Row["ConfirmText"]));
            }
        }
        DataSet DsFiles = Obj.GetDataSetByID("GetReportFiles", Convert.ToInt32(e.CommandArgument));
        FileListed.DataSource = DsFiles;
        FileListed.DataBind();

        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "GetComments();", true);

    }

    protected void Sector_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Fill Reports Data according to selected section

        if (Sector.SelectedValue != "0")
        {
            if (DropYear.SelectedValue != "0")
            {
                Mang.Items.Clear();

                Mang.DataSource = Obj.GetDataSetBy2ID("GetAdminByPlanSection", Convert.ToInt32(DropYear.SelectedValue), Convert.ToInt32(Sector.SelectedValue));

                Mang.DataTextField = "AdmName";
                Mang.DataValueField = "AdmID";
                Mang.DataBind();
                ListItem aa = new ListItem();
                aa.Text = "اختر الادارة";
                aa.Value = "0";

                Mang.Items.Insert(0, aa);
            }
        }
    }



    //Function for upload Note files attachments
    private void SendAttach(FileUpload FU, int NoteID)
    {
        if (FU.FileName.Length > 0)
        {
            var imgPath = "";
            //sets the image path
            var r = new Random();
            // print random integer >= 0 and  < 100

            imgPath = "Uploads/" + r.Next(100) + FU.FileName;

            //get the size in bytes that
            FU.SaveAs(Server.MapPath(imgPath));

            Obj.NewAttachNote(NoteID, imgPath, FU.FileName);

        }
    }


    //Function for upload Reports files attachments
    private void SendReportAttach(FileUpload FU, int ReportID)
    {
        if (FU.FileName.Length > 0)
        {
            var imgPath = "";
            //sets the image path
            var r = new Random();
            // print random integer >= 0 and  < 100

            imgPath = "Uploads/" + r.Next(100) + FU.FileName;

            //get the size in bytes that
            FU.SaveAs(Server.MapPath(imgPath));

            Obj.NewAttach(ReportID, imgPath, FU.FileName);

        }
    }


    protected void Save_Click(object sender, EventArgs e)
    {
        try
        {
            Rett.Text = "";

            if (Session["UData"] != null)
            {
                DataSet MyRecDataSet = (DataSet)Session["UData"];


                SucDel.Visible = false; Suc.Visible = false;
                var Ret = 0;
                if (LblNotNew.Text.Length <= 0)
                {
                    Ret = Obj.NewReportNoteNew(Convert.ToInt32(MyRecDataSet.Tables[0].Rows[0]["EmpID"]), hf.Value, DFromNoteUDP.Value, 0, Convert.ToInt32(RadioButtonList2.SelectedValue), LblRepeatU.Checked, Convert.ToInt32(Save.CommandArgument), hf1N.Value);


                }
                else
                {
                    Ret = Obj.ActiveTempReportNote(Convert.ToInt32(MyRecDataSet.Tables[0].Rows[0]["EmpID"]), hf.Value, DFromNoteUDP.Value, 0, Convert.ToInt32(RadioButtonList2.SelectedValue), LblRepeatU.Checked, Convert.ToInt32(Save.CommandArgument), Convert.ToInt32(LblNotNew.Text));


                }
                if (Ret != 0)
                {//Call te file uploads function For all the FileUpload Controls
                    NoteListing.InnerHtml = "";
                    DFromNoteUDP.Value = "";
                    Obj.ExecuteProcedure("UpdateNoteStatus");
                    RadioButtonList2.ClearSelection();
                    LblRepeatU.Checked = false;

                    Editor0.InnerHtml = "";

                    CloseOthers();
                    RepDetail.Attributes.Remove("Style");
                    RepDetail.Style.Add("display", "block");
                    RepNotes.DataSource = Obj.GetDataSetByID("GetNotes", Convert.ToInt32(Save.CommandArgument));
                    RepNotes.DataBind();
                    try
                    {
                        DataSet DsRep = Obj.GetDataSetByID("GetReportByID", Convert.ToInt32(Save.CommandArgument));

                        if (DsRep.Tables.Count > 0 && DsRep.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow RowRep in DsRep.Tables[0].Rows)
                            {
                                LblReptitle.Text = Convert.ToString(RowRep["RepTitle"]);

                                LblNoteCount.Text = Convert.ToString(RowRep["NoteCount"]);

                                LblRepDate.Text = Convert.ToString(RowRep["RepDate"]);

                                LblForSec.Text = Convert.ToString(RowRep["RepSection"]);
                                LblForAdm.Text = Convert.ToString(RowRep["RepAdm"]);
                                var Imp = Convert.ToString(RowRep["Importance"]);

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
                                LblDateFrom.Text = Convert.ToString(RowRep["RepFrom"]);
                                LblNo.Text = Convert.ToString(RowRep["RepCode"]);
                                if (Convert.ToBoolean(RowRep["RepRepeat"]) == true) { RPTSign.Text = "مكرر"; }
                                else { RPTSign.Text = "غير مكرر"; }
                                var Status = Convert.ToString(RowRep["RepStatus"]);

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


                                Test.InnerHtml = System.Net.WebUtility.HtmlDecode(Convert.ToString(RowRep["RepText"]));
                                RepImpTxt.InnerHtml = System.Net.WebUtility.HtmlDecode(Convert.ToString(RowRep["RepImpText"]));


                            }
                            RepDetail.Attributes.Remove("Style");
                            RepDetail.Style.Add("display", "block");

                        }

                        DataSet Ds = new DataSet();
                        RepNotes.DataSource = Obj.GetDataSetByID("GetNotes", Convert.ToInt32(Save.CommandArgument));
                        RepNotes.DataBind();


                    }
                    catch { }
                    Save.CommandArgument = "";
                    //DataSet Ds = Obj.GetDataSetByID("GetReportByID", Convert.ToInt32(Save.CommandArgument));


                    //if (Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                    //{

                    //    PrntView.Attributes.Remove("Style");
                    //    PrntView.Style.Add("display", "block");
                    //    NewNote.Attributes.Remove("Style");
                    //    NewNote.Style.Add("display", "none");
                    //    MainSave.Attributes.Remove("Style");
                    //    MainSave.Style.Add("display", "none");

                    //    DataSet DsRpt = Obj.GetDataSetByID("GetReportByID", Convert.ToInt32(Save.CommandArgument));

                    //    if (DsRpt.Tables.Count > 0 && DsRpt.Tables[0].Rows.Count > 0)
                    //    {
                    //        foreach (DataRow Row in DsRpt.Tables[0].Rows)
                    //        {

                    //            RepCount.Text = Convert.ToString(Row["NoteCount"]);

                    //            RepDat.Text = Convert.ToString(Row["RepDate"]);
                    //            RepSec.Text = Convert.ToString(Row["RepSection"]);
                    //            RepAdm.Text = Convert.ToString(Row["RepAdm"]);
                    //            var Imp = Convert.ToString(Row["Importance"]);
                    //            if (Imp == "1")
                    //            {
                    //                RepIm.Text = "منخفضة";
                    //            }
                    //            else if (Imp == "2")
                    //            {
                    //                RepIm.Text = "متوسطة";
                    //            }
                    //            else if (Imp == "3")
                    //            {
                    //                RepIm.Text = "مرتفعة";
                    //            }
                    //            RepOn.Text = Convert.ToString(Row["RepFrom"]);
                    //            RepNo.Text = Convert.ToString(Row["RepCode"]);
                    //            if (Convert.ToBoolean(Row["RepRepeat"]) == true) { RepRep.InnerText = "مكرر"; }
                    //            else { RepRep.InnerText = "غير مكرر"; }
                    //            var Status = Convert.ToString(Row["RepStatus"]);

                    //            if (Status == "3")
                    //            {
                    //                RepSt.Text = "معالجة";

                    //            }
                    //            else if (Status == "1")
                    //            {
                    //                RepSt.Text = "متأخرة";

                    //            }
                    //            else if (Status == "2")
                    //            {
                    //                RepSt.Text = "جارى التنفيذ";

                    //            }
                    //            else if (Status == "4")
                    //            {
                    //                RepSt.Text = "لم يحن وقت التنفيذ";

                    //            }
                    //            Div1.InnerHtml = System.Net.WebUtility.HtmlDecode(Convert.ToString(Row["RepText"]));




                    //            DataSet DSNotes = Obj.GetDataSetByID("GetNotes", Convert.ToInt32(Save.CommandArgument));

                    //            if (DSNotes.Tables.Count > 0 && DSNotes.Tables[0].Rows.Count > 0)
                    //            {
                    //                NotesPrev.Attributes.Remove("Style");
                    //                NotesPrev.Style.Add("display", "block");


                    //                NoNotes.Attributes.Remove("Style");
                    //                NoNotes.Style.Add("display", "none");
                    //                int jj = 0;
                    //                foreach (DataRow RowNotes in DSNotes.Tables[0].Rows)
                    //                {
                    //                    jj += 1;
                    //                    string NoteStatus = "مكررة";
                    //                    if (Convert.ToBoolean(RowNotes["NoteRepeat"]) == false)
                    //                    {
                    //                        NoteStatus = "غير مكررة";
                    //                    }

                    //                    string NoteStat = "";
                    //                    if (Convert.ToInt32(RowNotes["NoteStatus"]) == 3)
                    //                    {

                    //                        NoteStat = "معالجة";


                    //                    }
                    //                    else if (Convert.ToInt32(RowNotes["NoteStatus"]) == 2)
                    //                    {

                    //                        NoteStat = "جارى التنفيذ";
                    //                    }
                    //                    else if (Convert.ToInt32(RowNotes["NoteStatus"]) == 1)
                    //                    {

                    //                        NoteStat = "متأخرة";

                    //                    }
                    //                    else if (Convert.ToInt32(RowNotes["NoteStatus"]) == 4)
                    //                    {

                    //                        NoteStat = "لم يحن وقت التنفيذ";

                    //                    }
                    //                    else if (Convert.ToInt32(RowNotes["NoteStatus"]) == 5)
                    //                    {

                    //                        NoteStat = "مغلقة";

                    //                    }

                    //                    string NoteImportant = "";
                    //                    if (Convert.ToInt32(RowNotes["Importance"]) == 3)
                    //                    {

                    //                        NoteImportant = "مرتفعة";
                    //                    }
                    //                    else if (Convert.ToInt32(RowNotes["Importance"]) == 2)
                    //                    {

                    //                        NoteImportant = "متوسطة";

                    //                    }
                    //                    else if (Convert.ToInt32(RowNotes["Importance"]) == 1)
                    //                    {

                    //                        NoteImportant = "منخفضة";

                    //                    }


                    //                    NoteListing.InnerHtml += "<tr><td>" + NoteImportant + "</td><td>" + Convert.ToString(RowNotes["NoteDate"]) + "</td><td>" + NoteStat + "</td><td>" + NoteStatus + "</td><td>" + Convert.ToString(jj) + "</td></tr><tr><td colspan='5'><b>نص التوصية:</b></td></tr><tr><td colspan='5'>" + Server.HtmlDecode(Convert.ToString(RowNotes["NoteText"])) + "</td></tr><tr><td colspan='5'><b>نص الاجراء التصحيحى:</b></td></tr><tr><td colspan='5'>" + Server.HtmlDecode(Convert.ToString(RowNotes["AdminCorrect"])) + "</td></tr>";

                    //                }
                    //            }

                    //            else
                    //            {
                    //                NotesPrev.Attributes.Remove("Style");
                    //                NotesPrev.Style.Add("display", "none");


                    //                NoNotes.Attributes.Remove("Style");
                    //                NoNotes.Style.Add("display", "block");
                    //            }


                    //        }
                    //    }

                    //    LblRepeatU.Checked = false;

                    //    RadioButtonList2.SelectedValue = "3";
                    //    editor1.InnerText = "";
                    //    DFromNoteUDP.Value = "";
                    //    Rett.Text = "";
                    //    Suc.Visible = true;
                    //    Save.CommandArgument = "";
                    //    LblViews.Text = "ADDNT";
                    //}
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
        if (LblNotStat.Text == "true")
        {
            LblNotStat.Text = "مكررة";
        }
        else
        {
            LblNotStat.Text = "غير مكررة";
        }
        Image NotSt = (Image)e.Item.FindControl("NotSt");
        // ((HtmlElement)e.Item.FindControl("Div2")).InnerHtml = Server.HtmlDecode(((Label)e.Item.FindControl("LbCorrect")).Text);
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
            NotSt.ImageUrl = td2.ImageUrl = "assets/icons/levels/L2/under3.png";
        }
        else if (((Label)e.Item.FindControl("LblNoteStat")).Text == "1")
        {
            NotSt.ImageUrl = td2.ImageUrl = "assets/icons/levels/L2/hold3.png";
        }

        else if (((Label)e.Item.FindControl("LblNoteStat")).Text == "4")
        {
            NotSt.ImageUrl = td2.ImageUrl = "assets/icons/levels/L2/notstart3.png";
        }
        else if (((Label)e.Item.FindControl("LblNoteStat")).Text == "5")
        {
            NotSt.ImageUrl = td2.ImageUrl = "assets/icons/levels/L2/closed3.png";
        }
    }
    protected void LnkCommentNote_Command(object sender, CommandEventArgs e)
    {
        LblViews.Text = "EDT";
        DataSet Ds = Obj.GetDataSetByID("GetNoteConfirm", Convert.ToInt32(e.CommandArgument));

        if (Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow Row in Ds.Tables[0].Rows)
            {
                LblCommDate.Text = Convert.ToString(Row["ConfirmDate"]);

                LblCommRepID.Text = Convert.ToString(Row["ReportID"]);
                LblCommTxt.InnerText = System.Net.WebUtility.HtmlDecode(Convert.ToString(Row["ConfirmText"]));
            }
        }
        DataSet DsFiles = Obj.GetDataSetByID("GetNoteFilesComment", Convert.ToInt32(e.CommandArgument));
        FileListed.DataSource = DsFiles;
        FileListed.DataBind();

        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "GetComments();", true);
    }

    protected void EditNote_Command(object sender, CommandEventArgs e)
    {
        CloseOthers();
        UPDNot.Attributes.Remove("Style");
        UPDNot.Style.Add("display", "block");

        DataSet Ds = Obj.GetDataSetByID("GetNoteByID", Convert.ToInt32(e.CommandArgument));
        DataSet DsFiles = Obj.GetDataSetByID("GetNoteFiles", Convert.ToInt32(e.CommandArgument));

        RepeatNoteUPD.DataSource = DsFiles;
        RepeatNoteUPD.DataBind();
        if (Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow Row in Ds.Tables[0].Rows)
            {
                RadioButtonList01.SelectedValue = Convert.ToString(Row["Importance"]);
                LblRepeat0.Checked = Convert.ToBoolean(Row["NoteRepeat"]);
                RadioButtonList02.SelectedValue = Convert.ToString(Row["NoteStatus"]);
                UpdateNote.CommandArgument = Convert.ToString(Row["NoteID"]);
                editor2.InnerHtml = Server.HtmlDecode(Convert.ToString(Row["NoteText"]));
                editor2N.InnerHtml = Server.HtmlDecode(Convert.ToString(Row["AdminCorrect"]));
                LblRepID.Text = Convert.ToString(Row["RepID"]);
                DFromNote.Value = Convert.ToString(Row["NoteFrom"]);

            }
        }
    }

    protected void DelNote_Click(object sender, EventArgs e)
    {
        SucNote.Visible = false; SucNoteDel.Visible = false;
        var DelNote = Obj.ExecuteProcedureID("DelNote", Convert.ToInt32(NotDel.Value));

        if (DelNote == 1)
        {
            SucNoteDel.Visible = true;
            DataSet Ds = new DataSet();
            RepNotes.DataSource = Obj.GetDataSetByID("GetNotes", Convert.ToInt32(LblEditID.Text));
            RepNotes.DataBind();
            LblViews.Text = "EDT";
            BindEmployeesData();

        }
    }
    protected void UpdateNote_Click(object sender, EventArgs e)
    {
        try
        {


            if (Session["UData"] != null)
            {
                DataSet MyRecDataSet = (DataSet)Session["UData"];


                SucDel.Visible = false; Suc.Visible = false;
                string innerHTML = hf2.Value;


                var Ret = Obj.UpdateReportNoteNew(Convert.ToInt32(MyRecDataSet.Tables[0].Rows[0]["EmpID"]), hf2.Value, DFromNote.Value, 0, Convert.ToInt32(RadioButtonList02.SelectedValue), LblRepeat0.Checked, Convert.ToInt32(UpdateNote.CommandArgument), hf2N.Value);

                if (Ret != 0)
                {//Call te file uploads function For all the FileUpload Controls
                    CloseOthers(); RepDetail.Attributes.Remove("Style");
                    RepDetail.Style.Add("display", "block");
                    RepNotes.DataSource = Obj.GetDataSetByID("GetNotes", Convert.ToInt32(LblEditID.Text));
                    RepNotes.DataBind();
                    Obj.ExecuteProcedure("UpdateNoteStatus");

                    LblViews.Text = "EDT";

                    try
                    {
                        DataSet DsRep = Obj.GetDataSetByID("GetReportByID", Convert.ToInt32(LblEditID.Text));

                        if (DsRep.Tables.Count > 0 && DsRep.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow RowRep in DsRep.Tables[0].Rows)
                            {
                                LblReptitle.Text = Convert.ToString(RowRep["RepTitle"]);

                                LblNoteCount.Text = Convert.ToString(RowRep["NoteCount"]);

                                LblRepDate.Text = Convert.ToString(RowRep["RepDate"]);

                                LblForSec.Text = Convert.ToString(RowRep["RepSection"]);
                                LblForAdm.Text = Convert.ToString(RowRep["RepAdm"]);
                                var Imp = Convert.ToString(RowRep["Importance"]);


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
                                LblDateFrom.Text = Convert.ToString(RowRep["RepFrom"]);
                                LblNo.Text = Convert.ToString(RowRep["RepCode"]);
                                if (Convert.ToBoolean(RowRep["RepRepeat"]) == true) { RPTSign.Text = "مكرر"; }
                                else { RPTSign.Text = "غير مكرر"; }
                                var Status = Convert.ToString(RowRep["RepStatus"]);

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


                                Test.InnerHtml = System.Net.WebUtility.HtmlDecode(Convert.ToString(RowRep["RepText"]));
                                RepImpTxt.InnerHtml = System.Net.WebUtility.HtmlDecode(Convert.ToString(RowRep["RepImpText"]));


                            }
                            CloseOthers();
                            RepDetail.Attributes.Remove("Style");
                            RepDetail.Style.Add("display", "block");

                        }
                        CloseOthers();
                        RepDetail.Attributes.Remove("Style");
                        RepDetail.Style.Add("display", "block");



                    }
                    catch { }
                   
                    RepNotes.DataSource = Obj.GetDataSetByID("GetNotes", Convert.ToInt32(LblEditID.Text));
                    RepNotes.DataBind();

                }

                else { Rett.Text = "حدث خطأ "; }
            }

        }

        catch { }
    }

    protected void LinkReportFiles_Command(object sender, CommandEventArgs e)
    {
        LblEroor.Visible = false;
        LblEroorNote.Visible = false;
        RepId.Text = e.CommandArgument.ToString();
        DataSet DsFiles = Obj.GetDataSetByID("GetReportFiles", Convert.ToInt32(e.CommandArgument));
        RpeaterFiles.DataSource = DsFiles;
        RpeaterFiles.DataBind();
        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "GetFiles();", true);


        LblRep.Text = e.CommandArgument.ToString();

    }
   
    protected void DelFile_Click(object sender, EventArgs e)
    {
        try
        {
            SucFile.Visible = false;


            if (LblNotNew.Text.Length > 0)
            {
                var Res = Obj.ExecuteProcedureID("DelReportAttach", Convert.ToInt32(FileId.Value));
                if (Res == 1)
                {
                    SucFile.Visible = true;


                    DataSet DsFiles = Obj.GetDataSetByID("GetNoteFiles", Convert.ToInt32(LblNotNew.Text));
                    RepeateNoteFiles.DataSource = DsFiles;
                    RepeateNoteFiles.DataBind();


                }
            }

            if (UpdateNote.CommandArgument != "")
            {
                var Ret = Obj.ExecuteProcedureID("DelReportAttach", Convert.ToInt32(FileId.Value));
                if (Ret == 1)
                {
                    SucNoteFile.Visible = true;
                    DataSet DsFiles = Obj.GetDataSetByID("GetNoteFiles", Convert.ToInt32(UpdateNote.CommandArgument));
                    RepeatNoteUPD.DataSource = DsFiles;
                    RepeatNoteUPD.DataBind();
                    LblViews.Text = "NTUPD";
                }
            }
            else
            {
                var Ret = Obj.ExecuteProcedureID("DelReportAttach", Convert.ToInt32(FileId.Value));
                if (Ret == 1)
                {
                    SucFile.Visible = true;
                    DataSet DsFiles = Obj.GetDataSetByID("GetReportFiles", Convert.ToInt32(LblUpdate.Text));
                    RepeatUPD.DataSource = DsFiles;
                    RepeatUPD.DataBind();
                }

            }
        }
        catch { }
    }
    protected void LinkNoteFiles_Command(object sender, CommandEventArgs e)
    {
        CloseOthers();
        LblEroor.Visible = false;
        LblEroorNote.Visible = false;
        NoteId.Text = e.CommandArgument.ToString();
        DataSet DsFiles = Obj.GetDataSetByID("GetNoteFiles", Convert.ToInt32(e.CommandArgument));
        RpeaterFiles.DataSource = DsFiles;
        RpeaterFiles.DataBind();
        AdminFilesView.Attributes.Remove("Style");
        AdminFilesView.Style.Add("display", "block");

    }
    protected void DelReport_Click(object sender, EventArgs e)
    {
        SucDel.Visible = false; Suc.Visible = false;
        SucDel.Visible = false;
        var Res = Obj.ExecuteProcedureID("DeleteTempRep", Convert.ToInt32(BookReport.Value));
        if (Res == 1)
        {
            BindEmployeesData();
            SucDel.Visible = true;
        }
    }
    protected void BackTables_Click(object sender, EventArgs e)
    {
        CloseOthers();
        MainTable.Attributes.Remove("Style");
        MainTable.Style.Add("display", "block");

    }
    protected void EditRep_Command(object sender, CommandEventArgs e)
    {
        CloseOthers();
        DropYearU.DataSource = Obj.GetDataSet("GetPlans");
        DropYearU.DataTextField = "YearName";
        DropYearU.DataValueField = "ID";
        DropYearU.DataBind();



        DataSet DsFiles = Obj.GetDataSetByID("GetReportFiles", Convert.ToInt32(e.CommandArgument));
        RepeatUPD.DataSource = DsFiles;
        RepeatUPD.DataBind();

        LblUpdate.Text = e.CommandArgument.ToString();
        DataSet Ds = Obj.GetDataSetByID("GetReportByID", Convert.ToInt32(e.CommandArgument));

        if (Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow Row in Ds.Tables[0].Rows)
            {
                if (Row["RepPlan"] != "" && Row["RepPlan"] != null)
                {
                    DropYearU.SelectedValue = LblRepDate.Text = Convert.ToString(Row["RepPlan"]);
                    SectorRep.DataSource = Obj.GetDataSetByID("GetPlansSection", Convert.ToInt32(Row["RepPlan"]));
                    SectorRep.DataTextField = "SectionName";
                    SectorRep.DataValueField = "SectionID";
                    SectorRep.DataBind();
                    SectorRep.Items.Insert(0, "");
                    AdminsRep.Items.Clear();

                    SectorRep.SelectedValue = Convert.ToString(Row["SectionID"]);

                    ListItem aa = new ListItem();
                    aa.Text = "اختر الادارة";
                    aa.Value = "0";
                    AdminsRep.Items.Clear();
                    AdminsRep.Items.Insert(0, aa);

                    AdminsRep.DataSource = Obj.GetPlansAdmins(Convert.ToInt32(DropYearU.SelectedValue), Convert.ToInt32(SectorRep.SelectedValue));

                    AdminsRep.DataTextField = "AdmName";
                    AdminsRep.DataValueField = "AdmID";
                    AdminsRep.DataBind();
                    AdminsRep.SelectedValue = Convert.ToString(Row["AdmID"]);

                }
                LblReptitle.Text = Convert.ToString(Row["RepTitle"]);

                RePDatUpd.Value = LblRepDate.Text = Convert.ToString(Row["RepDate"]);
                DateFrom.Value = Convert.ToString(Row["RepFrom"]);

                Importance.SelectedValue = Convert.ToString(Row["Importance"]);
                RadioStatusUpd.SelectedValue = Convert.ToString(Row["RepStatus"]);
                RepImpTextU.InnerHtml = System.Net.WebUtility.HtmlDecode(Convert.ToString(Row["RepImpText"]));
                editor3.InnerHtml = System.Net.WebUtility.HtmlDecode(Convert.ToString(Row["RepText"]));

                RepTitleU.Value = Convert.ToString(Row["RepTitle"]);
                RepeatRep.Checked = Convert.ToBoolean(Row["RepRepeat"]);

            }
        }

        LblViews.Text = "RepUPD";
        UpdReport.Attributes.Remove("Style");
        UpdReport.Style.Add("display", "block");
    }
    protected void UpdateReport_Click(object sender, EventArgs e)
    {
        SucDel.Visible = false; Suc.Visible = false;
        LblError.Text = "";
        if (Session["UData"] != null)
        {
            DataSet MyRecDataSet = (DataSet)Session["UData"];
            Int32 Adm = 0;
            if (AdminsRep.SelectedValue != "")
            {
                Adm = Convert.ToInt32(AdminsRep.SelectedValue);
            }

            var Res = 0;

            Res = Obj.UpdateReport(Convert.ToInt32(MyRecDataSet.Tables[0].Rows[0]["EmpID"]), hf3.Value, Convert.ToInt32(SectorRep.SelectedValue), Adm, DateFrom.Value, Convert.ToInt32(Importance.SelectedValue), Convert.ToInt32(RadioStatusUpd.SelectedValue), RepeatRep.Checked, Convert.ToInt32(LblUpdate.Text), Convert.ToInt32(DropYearU.SelectedValue), RepTitleU.Value, RepImpTextUHid.Value, RePDatUpd.Value);


            if (Res != 0)
            {

                Suc.Visible = true;
                BindEmployeesData();
                CloseOthers();
                MainTable.Attributes.Remove("Style");
                MainTable.Style.Add("display", "block");


                //string Body = "<table border='0'><tbody><tr><td><b>تعديل على الملاحظة رقم:   </b></span><span><b>رقم:</b></span><span style='padding-left:30px;'>" + LblUpdate.Text + "</span><span><b>بتاريخ:</b></span><span style='padding-left:30px;'>" + LblRepDate.Text + "</td></tr></td></tr><tr><td><b>بدأ تنفيذ الملاحظة من تاريخ:</b></td><td>" + DateFrom.Value + "</td></tr><tr><td><b> حالة التكرار:</b></td><td>" + Stat + "</td></tr><tr><td><b>حالة الملاحظة:</b></td><td>" + RadioStatusUpd.SelectedItem.Text + "</td></tr><tr><td><b>مستوى الأهمية:</b></td><td>" + ImportanceRep.SelectedItem.Text + "</td></tr><tr><td><b>سبب الملاحظة:</b></td><td>" + PartText1.Value + "</td></tr><tr><td><b>عدد التوصيات على الملاحظة</b></td><td>" + NotCount + "</td></tr><tr><td><b>التاريخ</b></td><td>" + DateTime.Now.ToString("yyyy-MM-dd", new System.Globalization.CultureInfo("ar-SA").DateTimeFormat) + " [" + DateTime.Now.ToString("yyyy-MM-dd", new System.Globalization.CultureInfo("en-US").DateTimeFormat) + "] " + "</td></tr><tr><td><b>ملفات مرفقة:</b></td><td><ul style='list-style: none;'>";


                //DataSet DsFil = Obj.GetDataSetByID("GetReportFiles", Convert.ToInt32(LblUpdate.Text));


                //if (DsFil.Tables.Count > 0 && DsFil.Tables[0].Rows.Count > 0)
                //{
                //    foreach (DataRow RowFile in DsFil.Tables[0].Rows)
                //    {
                //        if (RowFile["FPath"] != null)
                //        {
                //            Body += "<li><a href='http://Mutaweron.com/" + Convert.ToString(RowFile["FPath"]) + "'>" + Convert.ToString(RowFile["FName"]) + "<li>";
                //        }
                //    }
                //}

                //Body += "</ul></td></tr></tbody></table>";

                //

                //Obj.OurMails("تعديل على ملاحظة  ", Body, Convert.ToInt32(SectorRep.SelectedValue), Adm, false);


            }
            else if (Res == 0)
            {
                LblError.Text = "هذه الملاحظة مسجلة من قبل لنفس السنه - الإدارة العليا والإدارة متوسطة";
            }
        }
    }


    protected void ChartView_Command(object sender, CommandEventArgs e)
    {
        LblViews.Text = "CHRT";

        var Vall = Obj.ExecuteProcedureID("GetNoteCount", Convert.ToInt32(e.CommandArgument));
        if (Vall != 0)
        {
            NoNoteCharts.Visible = false;



        }
        else
        {
            NoNoteCharts.Visible = true;
        }


    }
    protected void SectorRep_SelectedIndexChanged(object sender, EventArgs e)
    {


        if (SectorRep.SelectedValue != "")
        {
            if (DropYearU.SelectedValue != " ")
            {
                AdminsRep.Items.Clear();


                AdminsRep.DataSource = Obj.GetPlansAdmins(Convert.ToInt32(DropYearU.SelectedValue), Convert.ToInt32(SectorRep.SelectedValue));

                AdminsRep.DataTextField = "AdmName";
                AdminsRep.DataValueField = "AdmID";
                AdminsRep.DataBind();

                ListItem aa = new ListItem();
                aa.Text = "كلالإدارات المتوسطة";
                aa.Value = "0";
                AdminsRep.Items.Insert(0, aa);

            }
        }
        LblViews.Text = "RepUPD";
    }
    protected void LinkReports_Command(object sender, CommandEventArgs e)
    {
        RepReplys.DataSource = Obj.GetDataSetByID("GetReportConfirm", Convert.ToInt32(e.CommandArgument));
        RepReplys.DataBind();
        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "GetReplys();", true);

    }
    protected void NoteReplys_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (((Literal)e.Item.FindControl("LitNoteText")).Text != "")
        {
            ((Literal)e.Item.FindControl("LitNoteText")).Text = System.Net.WebUtility.HtmlDecode(((Literal)e.Item.FindControl("LitNoteText")).Text);
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
            ((Literal)e.Item.FindControl("LitText")).Text = System.Net.WebUtility.HtmlDecode(((Literal)e.Item.FindControl("LitText")).Text);
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

        DataSet DsFiles = Obj.GetDataSetByID("GetReportFilesComment", Convert.ToInt32(e.CommandArgument));
        RepAttach.DataSource = DsFiles;
        RepAttach.DataBind();
        RepId.Text = "";
        NoteId.Text = "";
        LblViews.Text = "EConf";
        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "GetAttach();", true);




    }
    protected void LinkNotFiles_Command(object sender, CommandEventArgs e)
    {

        DataSet DsFiles = Obj.GetDataSetByID("GetReportFilesComment", Convert.ToInt32(e.CommandArgument));
        RepAttach.DataSource = DsFiles;
        RepAttach.DataBind();
        NoteId.Text = "";
        RepId.Text = "";
        LblViews.Text = "EConfB";
        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "GetAttach();", true);


    }

    protected void LinkNotes_Command(object sender, CommandEventArgs e)
    {
        NoteReplys.DataSource = Obj.GetDataSetByID("GetNoteConfirm", Convert.ToInt32(e.CommandArgument));
        NoteReplys.DataBind();
        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "GetNoteReplys();", true);

        NoteId.Text = "";
    }
    
    protected void AddNoteFile_Click(object sender, EventArgs e)
    {
        DataSet MyRecDataSet = (DataSet)Session["UData"];

        if (LblNotNew.Text.Length <= 0)
        {

            LblNotNew.Text = Convert.ToString(Obj.NewTempReportNote(Convert.ToInt32(MyRecDataSet.Tables[0].Rows[0]["EmpID"]), hf.Value, DFromNoteUDP.Value, 0, Convert.ToInt32(RadioButtonList2.SelectedValue == "" ? "0" : RadioButtonList2.SelectedValue), LblRepeatU.Checked, Convert.ToInt32(Save.CommandArgument), hf1N.Value));

        }

        if (FileUpload01.FileName.Length > 0)
        {
            editor1.InnerHtml = hf.Value;
            editor1N.InnerHtml = hf1N.Value;

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





                    LblViews.Text = "ADDNT";
                    DataSet DsFilesNewnt = Obj.GetDataSetByID("GetNoteFiles", Convert.ToInt32(LblNotNew.Text));
                    RepeateNoteFiles.DataSource = null;
                    RepeateNoteFiles.DataBind();
                    RepeateNoteFiles.DataSource = DsFilesNewnt;
                    RepeateNoteFiles.DataBind();
                    SucNoteFile.Visible = true;
                }

            }
        }
    }
   
    protected void TempReport_Click(object sender, EventArgs e)
    {
        //if (hf0.Value.Trim() == "")
        //{
        //    lblNoteText.Text = " نص الملاحظه مطلوب *";
        //    return;
        //}
        //else
        //    lblNoteText.Text = "";

        //if (RepImpTextHid.Value == "")
        //{
        //    NoteImpText.Text = "أهمية الملاحظة مطلوبه *";
        //    return;
        //}
        //else
        //    NoteImpText.Text = "";

        LblExists.Text = "";
        SucDel.Visible = false; Suc.Visible = false;
        LblViews.Text = "0";
        if (Session["UData"] != null)
        {//+ DateTime.Now.Date + DateTime.Now.Hour

            DataSet MyRecDataSet = (DataSet)Session["UData"];
            string Tmp = "Temp" + Convert.ToInt32(MyRecDataSet.Tables[0].Rows[0]["EmpID"]);
            var Res = Obj.NewTempReport(Convert.ToInt32(MyRecDataSet.Tables[0].Rows[0]["EmpID"]), hf0.Value, Convert.ToInt32(Sector.SelectedValue), Convert.ToInt32(Mang.SelectedValue), DateFromMain.Value, Convert.ToInt32(ImportanceRep.SelectedValue), Convert.ToInt32(RadioStatusRep.SelectedValue), RepeatSearch.Checked, Tmp, Convert.ToInt32(DropYear.SelectedValue), RepTitle.Value, RepImpTextHid.Value, RepDatNew.Value);

            if (Res != 0)
            {
                Sector.ClearSelection();
                Mang.ClearSelection();
                DateFromMain.Value = "";
                ImportanceRep.ClearSelection();
                RadioStatusRep.ClearSelection();
                RepeatSearch.Checked = false;
                DropYear.ClearSelection();
                RepTitle.Value = "";
                editor1.InnerHtml = "";
                RepImpText.InnerHtml = "";
                BindEmployeesData();
            }
            else if (Res == 0)
            {
                LblExists.Text = "هذه الملاحظة مسجلة من قبل لنفس السنه - الإدارة العليا والإدارة متوسطة";
            }
        }

    }
    protected void SendAll_Click(object sender, EventArgs e)
    {
        if (Session["UData"] != null)
        {
            DataSet MyRecDataSet = (DataSet)Session["UData"];
            string Tmp = "Temp" + Convert.ToInt32(MyRecDataSet.Tables[0].Rows[0]["EmpID"]);
            if (Obj.GetDataSetByString("GetTempReports", Tmp).Tables[0].Rows.Count > 0)
            {
                foreach (RepeaterItem item in EmployeesData.Items)
                {
                    if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                    {
                        var Lbl = (Label)item.FindControl("LblRepID");
                        if (Lbl.Text.Length > 0)
                        {

                            string Statc = "";
                            if (((Label)item.FindControl("LblStat")).Text == "3")
                            { Statc = "<span style='color:green;'>معالجة</span>"; }
                            else if (((Label)item.FindControl("LblStat")).Text == "2")
                            { Statc = "<span style='color:orange;'> جارى التنفيذ</span>"; }

                            else if (((Label)item.FindControl("LblStat")).Text == "1")
                            { Statc = "<span style='color:red;'> متأخرة</span>"; }

                            else if (((Label)item.FindControl("LblStat")).Text == "5")
                            { Statc = "<span style='color:#bfbfbf;'> مغلقة</span>"; }

                            else if (((Label)item.FindControl("LblStat")).Text == "5")
                            { Statc = "<span style='color:#00b0f0;'> لم يحن وقت التنفيذ</span>"; }

                            string Importanc = "<span style='color:green;'>منخفضة</span>";
                            if (((Label)item.FindControl("LblImportant")).Text == "2")
                            { Importanc = "<span style='color:orange;'>متوسطة</span>"; }
                            else if (((Label)item.FindControl("LblImportant")).Text == "3")
                            { Importanc = "<span style='color:red;'>مرتفعة</span>"; }


                            string Body = "<table border='0'><tbody><tr><td><b> إضافة ملاحظة  برقم:</b></td><td><span style='padding-left:30px;'>" + ((LinkButton)item.FindControl("LinkDetails")).Text + "</span></td></tr><tr><td><b>بعنوان:</b></td><td><span style='padding-left:30px;'>" + ((Label)item.FindControl("RepTit")).Text + "</span></td></tr><tr><td><b>بدأ تنفيذ الملاحظة من تاريخ:</b></td><td><span style='padding-left:30px;'>" + ((Label)item.FindControl("RepFRM")).Text + "</span></td></tr><tr><td><b> حالة التكرار:</b></td><td><span style='padding-left:30px;'>" + ((Label)item.FindControl("LblRepeatRep")).Text == "true" ? "نعم" : "لا" + "</span></td></tr><tr><td><b>حالة الملاحظة:</b></td><td><span style='padding-left:30px;'>" + Statc + "</span></td></tr><tr><td><b>مستوى الأهمية:</b></td><td><span style='padding-left:30px;'>" + Importanc + "</span></td></tr><tr><td><b>التاريخ</b></td><td><span style='padding-left:30px;'>" + DateTime.Now.ToString("yyyy-MM-dd", new System.Globalization.CultureInfo("ar-SA").DateTimeFormat) + " [" + DateTime.Now.ToString("yyyy-MM-dd", new System.Globalization.CultureInfo("en-US").DateTimeFormat) + "] " + "</span></td></tr>";

                            Body += "</tbody></table>";



                            Obj.OurMails("ملاحظة جديدة", Body, Convert.ToInt32(((Label)item.FindControl("RepSec")).Text), Convert.ToInt32(((Label)item.FindControl("RepAdm")).Text), false);

                            Obj.ExecuteProcedureID("ActiveReport", Convert.ToInt32(Lbl.Text));


                        }

                    }
                }

                CloseOthers();

                MainTable.Attributes.Remove("Style");
                MainTable.Style.Add("display", "block");

                LblDone.Text = "A";
                BindEmployeesData();
            }
            else
            {
                LblDone.Text = "";
            }
        }
    }
    protected void AddNote_Command(object sender, CommandEventArgs e)
    {
        CloseOthers();
        NewNote.Attributes.Remove("Style");
        NewNote.Style.Add("display", "block");
        Save.CommandArgument = e.CommandArgument.ToString();
        LblNotNew.Text = "";
        RepeateNoteFiles.DataSource = null;
        RepeateNoteFiles.DataBind();
        SucNoteFile.Visible = false;

    }
    protected void DropYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Fill dropdown Lists For Reports Sections تبعا للسنة
        if (DropYear.SelectedValue != "0")
        {
            Sector.Items.Clear();
            Sector.DataSource = Obj.GetDataSetByID("GetPlansSection", Convert.ToInt32(DropYear.SelectedValue));
            Sector.DataTextField = "SectionName";
            Sector.DataValueField = "SectionID";
            Sector.DataBind();
            ListItem aa = new ListItem();
            aa.Text = "اختر الإدارة العليا";
            aa.Value = "0";
            Sector.Items.Insert(0, aa);
            Sector.SelectedValue = "0";
        }
    }
    protected void DropYearU_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Fill dropdown Lists For Reports Sections تبعا للسنة
        if (DropYearU.SelectedValue != " ")
        {
            SectorRep.Items.Clear();
            SectorRep.DataSource = Obj.GetDataSetByID("GetPlansSection", Convert.ToInt32(DropYearU.SelectedValue));
            SectorRep.DataTextField = "SectionName";
            SectorRep.DataValueField = "SectionID";
            SectorRep.DataBind();
            SectorRep.Items.Insert(0, "");
            AdminsRep.Items.Clear();

            ListItem aa = new ListItem();
            aa.Text = "اختر الادارة";
            aa.Value = "0";
            AdminsRep.Items.Clear();
            AdminsRep.Items.Insert(0, aa);
            LblViews.Text = "RepUPD";
        }
    }

    protected void LinkReportFiles_Command2(object sender, CommandEventArgs e)
    {
        LblEroor.Visible = false;
        LblEroorNote.Visible = false;
        RepId.Text = e.CommandArgument.ToString();
        DataSet DsFiles = Obj.GetDataSetByID("GetReportFiles", Convert.ToInt32(e.CommandArgument));
        RpeaterFiles.DataSource = DsFiles;
        RpeaterFiles.DataBind();
        LblViews.Text = "Fils";

        LblRep.Text = e.CommandArgument.ToString();
    }

    private void CloseOthers()
    {
        BindEmployeesData();
        LblDone.Text = "";

        MainTable.Attributes.Remove("Style");
        MainTable.Style.Add("display", "none");

        UPDNot.Attributes.Remove("Style");
        UPDNot.Style.Add("display", "none");

        NewNote.Attributes.Remove("Style");
        NewNote.Style.Add("display", "none");

        UpdReport.Attributes.Remove("Style");
        UpdReport.Style.Add("display", "none");

        AdminFilesView.Attributes.Remove("Style");
        AdminFilesView.Style.Add("display", "none");
        LblAdms.Text = "";
        UpdateReport.CommandArgument = "None";
        UpdateNote.CommandArgument = "None";

        RepDetail.Attributes.Remove("Style");
        RepDetail.Style.Add("display", "none");


        /* التعديل هنا*/
        SucNoteDel.Visible = false;
        SucNote.Visible = false;
        /*-----*/
    }

    protected void BackFiles_Click(object sender, EventArgs e)
    {

        CloseOthers(); RepDetail.Attributes.Remove("Style");
        RepDetail.Style.Add("display", "block");
        RepNotes.DataSource = Obj.GetDataSetByID("GetNotes", Convert.ToInt32(LblEditID.Text));
        RepNotes.DataBind();



    }





    protected void AddFile_Click1(object sender, EventArgs e)
    {

        SucFile.Visible = false;
        if (FileUploadR.FileName.Length > 0)
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
                        RepId.Text = "A";
                    }
                    else
                    {

                        SucFile.Visible = true;
                        DataSet DsFiles = Obj.GetDataSetByID("GetNoteFiles", Convert.ToInt32(NoteId.Text));
                        RpeaterFiles.DataSource = DsFiles;
                        RpeaterFiles.DataBind();

                        RepId.Text = "A";

                    }
                }
                else { SucFile.Visible = false; }
            }
            else if (LblRep.Text != "")
            {

                var Res = Obj.NewAttach(Convert.ToInt32(LblRep.Text), imgPath, FileUploadR.FileName);
                if (Res != 0)
                {

                    if (Res == -1)
                    {

                        LblEroor.Visible = true;
                        RepId.Text = "A";
                    }
                    else
                    {

                        SucFile.Visible = true;
                        DataSet DsFiles = Obj.GetDataSetByID("GetReportFiles", Convert.ToInt32(LblRep.Text));
                        RpeaterFiles.DataSource = DsFiles;
                        RpeaterFiles.DataBind();

                        RepId.Text = "A";

                    }
                }
                else { SucFile.Visible = false; }
            }

            BindEmployeesData();
        }
    }

    protected void AddFileUPD_Click1(object sender, EventArgs e)
    {
        SendReportAttach(FileUploadUPD, Convert.ToInt32(LblUpdate.Text));

        DataSet DsFiles = Obj.GetDataSetByID("GetReportFiles", Convert.ToInt32(LblUpdate.Text));
        RepeatUPD.DataSource = DsFiles;
        RepeatUPD.DataBind();
        SucUPD.Visible = true;
    }

    protected void AddNoteFileUPD_Click1(object sender, EventArgs e)
    {
        if (FileUpload02.FileName.Length > 0)
        {
            var imgPath = "";
            //sets the image path
            var r = new Random();
            // print random integer >= 0 and  < 100

            imgPath = "Uploads/" + r.Next(100) + FileUpload02.FileName;

            //get the size in bytes that
            FileUpload02.SaveAs(Server.MapPath(imgPath));
            LblNoteFileExist.Visible = false;


            var Res = Obj.NewAttachNote(Convert.ToInt32(UpdateNote.CommandArgument), imgPath, FileUpload02.FileName);
            if (Res != 0)
            {

                if (Res == -1)
                {
                    NoteFileExistUPD.Visible = true;
                }
                else
                {
                    DataSet DsFiles = Obj.GetDataSetByID("GetNoteFiles", Convert.ToInt32(UpdateNote.CommandArgument));

                    RepeatNoteUPD.DataSource = DsFiles;
                    RepeatNoteUPD.DataBind();
                    SucUPD.Visible = true;
                    LblViews.Text = "NTUPD";
                }
            }
        }
    }
}
