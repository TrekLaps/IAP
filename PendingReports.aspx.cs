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

public partial class PendingReports : System.Web.UI.Page
{
    Operations Obj = new Operations();

    private void BindEmployeesData()
    {
        if (Session["UData"] != null)
        {
            if (Session["UData"] != null)
            {
                DataSet MyRecDataSet = (DataSet)Session["UData"];
                EmployeesData.DataSource = null;
                EmployeesData.DataBind();
                EmployeesData.DataSource = Obj.GetDataSetByID("GetReportBySection", Convert.ToInt32(MyRecDataSet.Tables[0].Rows[0]["SectionID"]));
                EmployeesData.DataBind();


            }
        }


    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["UData"] != null)
            {
                DataSet MyRecDataSet = (DataSet)Session["UData"];

                if (Obj.ExecuteProcedureID("CheckSectionManger", Convert.ToInt32(MyRecDataSet.Tables[0].Rows[0]["EmpID"])) == 1)
                {  // Fill dropdown Lists For Reports with date and RepiD
                    PlansSearch.DataSource = Obj.GetDataSet("GetPlans");
                    PlansSearch.DataTextField = "YearName";
                    PlansSearch.DataValueField = "ID";
                    PlansSearch.DataBind();

                    DataSet DSSections = Obj.GetDataSetByID("GetSectionsByManager", Convert.ToInt32(MyRecDataSet.Tables[0].Rows[0]["EmpID"]));
                    if (DSSections.Tables[0].Rows.Count > 0)
                    {
                        Sector.Items.Clear();
                        Sector.DataSource = DSSections;
                        Sector.DataTextField = "SectionName";
                        Sector.DataValueField = "SectionID";
                        Sector.DataBind();
                        Sector.Items.Insert(0, "");

                    }




                    // Fill dropdown Lists For Reports with date and RepiD
                    Admins1.DataSource = Obj.GetDataSetByID("GetReportMainBySection", Convert.ToInt32(MyRecDataSet.Tables[0].Rows[0]["SectionID"]));
                    Admins1.DataTextField = "RepDate";
                    Admins1.DataValueField = "RepID";
                    Admins1.DataBind();

                    DataSet DsFiles = Obj.GetDataSetByID("GetAdminFilesBySection", Convert.ToInt32(MyRecDataSet.Tables[0].Rows[0]["SectionID"]));
                    if (DsFiles.Tables[0].Rows.Count > 0)
                    {
                        LblNoData.Visible = false;
                        RepFileAdmins.DataSource = DsFiles;
                        RepFileAdmins.DataBind();
                    }
                    else
                    {
                        LblNoData.Visible = true;
                    }

                    BindEmployeesData();
                    DataTable DTImportant = Obj.GetDataSetByID("ReportCountImportBySec", Convert.ToInt32(MyRecDataSet.Tables[0].Rows[0]["SectionID"])).Tables[0];

                    DataTable DTStatus = Obj.GetDataSetByID("ReportCountStatusBySec", Convert.ToInt32(MyRecDataSet.Tables[0].Rows[0]["SectionID"])).Tables[0];


                    foreach (ListItem ltItem in Importance.Items)
                    {
                        if (ltItem.Value != "0")
                        {
                            var dT = DTImportant.AsEnumerable().Where(x => x.Field<int>("Importance") == Convert.ToInt32(ltItem.Value)).FirstOrDefault();
                            string Counts = "0";
                            if (dT != null)
                            {
                                Counts = dT["Counts"].ToString();
                            }
                            ltItem.Text += " [ " + Counts + " ] ";
                        }
                    }
                    foreach (ListItem ltItem in RadioStatus.Items)
                    {
                        if (ltItem.Value != "0")
                        {
                            var dT = DTStatus.AsEnumerable().Where(x => x.Field<int>("RepStatus") == Convert.ToInt32(ltItem.Value)).FirstOrDefault();
                            string Counts = "0";
                            if (dT != null)
                            {
                                Counts = dT["Counts"].ToString();
                            }
                            ltItem.Text += " [ " + Counts + " ] ";
                        }
                    }
                }
                else
                {
                    Response.Redirect("NoPermissions.aspx");
                }
            }

        }
        else
        {
            ShowFiles.Text = "";
            LblEdit.Text = "";
            Suc.Visible = false;
            SucNote.Visible = false;
            SucFile.Visible = false;
            if (HiddenPost.Value == "1")
            {
                CheckRepeat.Checked = false;
                SearchbyRepeat();
                HiddenPost.Value = "0";
            }
            if (HiddenSearch.Value == "1")
            {
                foreach (ListItem ltItem in Importance.Items)
                {
                    if (ltItem.Value != "0")
                    {
                        ltItem.Text = ltItem.Text.Substring(0, ltItem.Text.LastIndexOf('[') - 1) + " [ " + Convert.ToString(Obj.ExecuteProcedureStringID("ReportCountImportByDate", Convert.ToInt32(ltItem.Value), DateFromSearch.Value)) + " ] ";
                    }
                }
                foreach (ListItem ltItem in RadioStatus.Items)
                {
                    if (ltItem.Value != "0")
                    {
                        ltItem.Text = ltItem.Text.Substring(0, ltItem.Text.LastIndexOf('[') - 1) + " [ " + Convert.ToString(Obj.ExecuteProcedureStringID("ReportCountStatusByDate", Convert.ToInt32(ltItem.Value), DateFromSearch.Value)) + " ] ";
                    }
                }
                if (Session["UData"] != null)
                {
                    DataSet MyRecDataSet = (DataSet)Session["UData"];
                    EmployeesData.DataSource = null;
                    EmployeesData.DataBind();
                    var Repeatchecked = 0;

                    if (HiddenPost.Value == "1")
                    {
                        Repeatchecked = 1;

                    }
      EmployeesData.DataSource = Obj.ReportFilterAll(Convert.ToInt32(Mang.SelectedValue), Convert.ToInt32(Sector.SelectedValue), Convert.ToInt32(Importance.SelectedValue==""?"0":Importance.SelectedValue), Convert.ToInt32(RadioStatus.SelectedValue), RepeatSearch.Checked, CheckRepeat.Checked, DateFromSearch.Value.Equals("") ? "0" : DateFromSearch.Value, Convert.ToInt32(PlansSearch.SelectedValue), Repeatchecked);
                    EmployeesData.DataBind();

                    HiddenSearch.Value = "0";
                }
            }

        }
    }


    protected void Edit_Command(object sender, CommandEventArgs e)
    {

        try
        {

            DataSet Ds = new DataSet();
            RepNotes.DataSource = Obj.GetDataSetByID("GetNotes", Convert.ToInt32(e.CommandArgument));
            RepNotes.DataBind();
            LblEdit.Text = "A";
            LblEditID.Text = e.CommandArgument.ToString();
            EditConfirm.Text = "";
        }
        catch { }
    }






    protected void EmployeesData_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        HtmlControl td = (HtmlControl)e.Item.FindControl("TD1");
        HtmlControl td2 = (HtmlControl)e.Item.FindControl("TD2");

        if (Convert.ToBoolean(((Label)e.Item.FindControl("LblRepeat")).Text) == true)
        {
            ((System.Web.UI.HtmlControls.HtmlGenericControl)(e.Item.FindControl("TRU"))).Visible = true;
        }
        else if (Convert.ToBoolean(((Label)e.Item.FindControl("LblRepeat")).Text) == false)
        {
            ((System.Web.UI.HtmlControls.HtmlGenericControl)(e.Item.FindControl("FALS"))).Visible = true;
        }


        if (((Label)e.Item.FindControl("LblImportant")).Text == "3")
        {
            ((Label)e.Item.FindControl("LblImportant")).Text = "مرتفعة";
            td.Attributes.Add("style", "background-color:Red;");


        }
        if (((Label)e.Item.FindControl("LblImportant")).Text == "2")
        {
            ((Label)e.Item.FindControl("LblImportant")).Text = "متوسطة";

            td.Attributes.Add("style", "background-color:Orange;");


        }
        if (((Label)e.Item.FindControl("LblImportant")).Text == "1")
        {
            ((Label)e.Item.FindControl("LblImportant")).Text = "منخفضة";
            td.Attributes.Add("style", "background-color:LightGreen;");

        }

        if (((Label)e.Item.FindControl("LblStat")).Text == "3")
        {

            ((Label)e.Item.FindControl("LblStat")).Text = "معالجة";

            td2.Attributes.Add("style", "background-color:LightGreen;");

        }
        else if (((Label)e.Item.FindControl("LblStat")).Text == "2")
        {

            ((Label)e.Item.FindControl("LblStat")).Text = "جارى التنفيذ";
            td2.Attributes.Add("style", "background-color:Orange;");
        }
        else if (((Label)e.Item.FindControl("LblStat")).Text == "1")
        {

            ((Label)e.Item.FindControl("LblStat")).Text = "متأخرة";
            td2.Attributes.Add("style", "background-color:Red;");
        }

        else if (((Label)e.Item.FindControl("LblStat")).Text == "4")
        {

            ((Label)e.Item.FindControl("LblStat")).Text = "لم يحن وقت التنفيذ";
            td2.Attributes.Add("style", "background-color:#5b9092;");
        }
        else if (((Label)e.Item.FindControl("LblStat")).Text == "5")
        {

            ((Label)e.Item.FindControl("LblStat")).Text = "مغلقة";
            td2.Attributes.Add("style", "background-color:#cccccc;");
        }


      

    }
    protected void LinkDetails_Command(object sender, CommandEventArgs e)
    {
        DataSet DsFiles = Obj.GetDataSetByID("GetReportFilesComment", Convert.ToInt32(e.CommandArgument));
        FileList.DataSource = DsFiles;
        FileList.DataBind();

        DataSet Ds = Obj.GetDataSetByID("GetReportByID", Convert.ToInt32(e.CommandArgument));

        if (Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow Row in Ds.Tables[0].Rows)
            {


                LblNoteCount.Text = Convert.ToString(Row["NoteCount"]);

                LblRepDate.Text = Convert.ToString(Row["RepDate"]);

                LblForSec.Text = Convert.ToString(Row["RepSection"]);
                LblForAdm.Text = Convert.ToString(Row["RepAdm"]);
                var Imp = Convert.ToString(Row["Importance"]);
                if (Imp == "1")
                {
                    LblImport.Text = "منخفضة";
                }
                else if (Imp == "2")
                {
                    LblImport.Text = "متوسطة";
                }
                else if (Imp == "3")
                {
                    LblImport.Text = "مرتفعة";
                }
                LblDateFrom.Text = Convert.ToString(Row["RepFrom"]);
                LblNo.Text = Convert.ToString(Row["RepID"]);
                if (Convert.ToBoolean(Row["RepRepeat"]) == true) { RPTSign.InnerText = "مكرر"; }
                else { RPTSign.InnerText = "غير مكرر"; }
                var Status = Convert.ToString(Row["RepStatus"]);

                if (Status == "3")
                {
                    LblStatus.Text = "معالجة";

                }
                else if (Status == "1")
                {
                    LblStatus.Text = "متأخرة";

                }
                else if (Status == "2")
                {
                    LblStatus.Text = "جارى التنفيذ";

                }
                else if (Status == "4")
                {
                    LblStatus.Text = "لم يحن وقت التنفيذ";

                }
                else if (Status == "5")
                {
                    LblStatus.Text = "مغلقة";
                }
                Test.InnerHtml = System.Net.WebUtility.HtmlDecode(Convert.ToString(Row["RepText"]));


            }
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "GetDetails();", true);

        }
    }
    protected void Admins1_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Bind Data According to selectd Report date Or ID
        if (Admins1.SelectedValue != "")
        {
            CheckRepeat.Checked = false;
            DateFromSearch.Value = "";
            DataTable DTImportant = Obj.GetDataSetByID("ReportCountByID", Convert.ToInt32(Admins1.SelectedValue)).Tables[0];

            DataTable DTStatus = Obj.GetDataSetByID("ReportCountStatusByID", Convert.ToInt32(Admins1.SelectedValue)).Tables[0];

            foreach (ListItem ltItem in Importance.Items)
            {
                if (ltItem.Value != "0")
                {
                    var dT = DTImportant.AsEnumerable().Where(x => x.Field<int>("Importance") == Convert.ToInt32(ltItem.Value)).FirstOrDefault();
                    string Counts = "0";
                    if (dT != null)
                    {
                        Counts = dT["Counts"].ToString();
                    }
                    ltItem.Text = ltItem.Text.Substring(0, ltItem.Text.LastIndexOf('[') - 1) + " [ " + Counts + " ] ";
                }
            }
            foreach (ListItem ltItem in RadioStatus.Items)
            {
                if (ltItem.Value != "0")
                {
                    var dT = DTStatus.AsEnumerable().Where(x => x.Field<int>("RepStatus") == Convert.ToInt32(ltItem.Value)).FirstOrDefault();
                    string Counts = "0";
                    if (dT != null)
                    {
                        Counts = dT["Counts"].ToString();
                    }
                    ltItem.Text = ltItem.Text.Substring(0, ltItem.Text.LastIndexOf('[') - 1) + " [ " + Counts + " ] ";
                }
            }

            EmployeesData.DataSource = Obj.GetDataSetByID("GetReportByID", Convert.ToInt32(Admins1.SelectedValue));
            EmployeesData.DataBind();
        }
    }

    protected void Mang_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Session["UData"] != null)
        {
            DataSet MyRecDataSet = (DataSet)Session["UData"];

            if (Mang.SelectedValue != "")
            {
                Admins1.SelectedValue = "0";
                EmployeesData.DataSource = null;
                EmployeesData.DataBind();
                var Repeatchecked = 0;

                if (HiddenPost.Value == "1")
                {
                    Repeatchecked = 1;

                }
  EmployeesData.DataSource = Obj.ReportFilterAll(Convert.ToInt32(Mang.SelectedValue), Convert.ToInt32(Sector.SelectedValue), Convert.ToInt32(Importance.SelectedValue==""?"0":Importance.SelectedValue), Convert.ToInt32(RadioStatus.SelectedValue), RepeatSearch.Checked, CheckRepeat.Checked, DateFromSearch.Value.Equals("") ? "0" : DateFromSearch.Value, Convert.ToInt32(PlansSearch.SelectedValue), Repeatchecked);
                EmployeesData.DataBind();
            }
        }
    }
    protected void Importance_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Session["UData"] != null)
        {
            DataSet MyRecDataSet = (DataSet)Session["UData"];
            if (Importance.SelectedValue != "")
            {
                Admins1.SelectedValue = "0";
                EmployeesData.DataSource = null;
                EmployeesData.DataBind();
                var Repeatchecked = 0;

                if (HiddenPost.Value == "1")
                {
                    Repeatchecked = 1;

                }
  EmployeesData.DataSource = Obj.ReportFilterAll(Convert.ToInt32(Mang.SelectedValue), Convert.ToInt32(Sector.SelectedValue), Convert.ToInt32(Importance.SelectedValue==""?"0":Importance.SelectedValue), Convert.ToInt32(RadioStatus.SelectedValue), RepeatSearch.Checked, CheckRepeat.Checked, DateFromSearch.Value.Equals("") ? "0" : DateFromSearch.Value, Convert.ToInt32(PlansSearch.SelectedValue), Repeatchecked);
                EmployeesData.DataBind();
            }
        }
    }
    protected void RadioStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Session["UData"] != null)
        {
            DataSet MyRecDataSet = (DataSet)Session["UData"];


            if (RadioStatus.SelectedValue != "")
            {
                Admins1.SelectedValue = "0";
                EmployeesData.DataSource = null;
                EmployeesData.DataBind();
                var Repeatchecked = 0;

                if (HiddenPost.Value == "1")
                {
                    Repeatchecked = 1;

                }
  EmployeesData.DataSource = Obj.ReportFilterAll(Convert.ToInt32(Mang.SelectedValue), Convert.ToInt32(Sector.SelectedValue), Convert.ToInt32(Importance.SelectedValue==""?"0":Importance.SelectedValue), Convert.ToInt32(RadioStatus.SelectedValue), RepeatSearch.Checked, CheckRepeat.Checked, DateFromSearch.Value.Equals("") ? "0" : DateFromSearch.Value, Convert.ToInt32(PlansSearch.SelectedValue), Repeatchecked);
                EmployeesData.DataBind();
            }
        }
    }


    //Function for upload Note files Comments by manager
    private void SendAttachComment(FileUpload FU, int CommentID)
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

            Obj.NewAttachComment(CommentID, imgPath, FU.FileName);

        }
    }



    protected void Save_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["UData"] != null)
            {
                DataSet MyRecDataSet = (DataSet)Session["UData"];


                Suc.Visible = false;
                var Ret = 0;
                if (EditConfirm.Text == "")
                {

                    if (RepId.Text != "")
                    {
                        if (ConfirmId.Text != "")
                        {
                            Ret = Obj.ActiveReportComment(Convert.ToInt32(ConfirmId.Text), hf.Value);
                        }
                        else
                        {
                            Ret = Obj.NewActiveReportComment(Convert.ToInt32(RepId.Text), Convert.ToInt32(MyRecDataSet.Tables[0].Rows[0]["EmpID"]), hf.Value);
                        }
                        if (Ret != 0)
                        {
                            BindEmployeesData();
                            editor1.InnerHtml = "";

                            Rett.Text = "";
                            Suc.Visible = true;
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "CloseFiles();", true);
                            NoteId.Text = "";
                            RepId.Text = "";

                            string Body = "<table border='0'><tbody><tr><td><b>رد على الملاحظة رقم:  </b></td><td>" + RepId.Text + "</td></tr><tr><td><b>الرد علىالملاحظة:</b></td><td>" + Server.HtmlDecode(hf.Value) + "</td></tr><tr><td><b>تاريخ الرد:</b></td><td>" + DateTime.Now.ToString("yyyy-MM-dd", new System.Globalization.CultureInfo("ar-SA").DateTimeFormat) + "</td></tr><tr><td><b>ملفات مرفقة:</b></td><td><ul style='list-style: none;'>";


                            DataSet DsFil = Obj.GetDataSetByID("GetReportFiles", Convert.ToInt32(RepId.Text));


                            if (DsFil.Tables.Count > 0 && DsFil.Tables[0].Rows.Count > 0)
                            {
                                foreach (DataRow RowFile in DsFil.Tables[0].Rows)
                                {
                                    if (RowFile["FPath"] != null)
                                    {
                                        Body += "<li><a href='http://Mutaweron.com/" + Convert.ToString(RowFile["FPath"]) + "'>" + Convert.ToString(RowFile["FName"]) + "<li>";
                                    }
                                }
                            }

                            Body += "</ul></td></tr></tbody></table>";

                            Obj.OurMails("رد على ملاحظة ", Body, 0, 0, true);



                        }



                    }
                    else if (NoteId.Text != "")
                    {
                        if (ConfirmId.Text != "")
                        {
                            Ret = Obj.ActiveReportComment(Convert.ToInt32(ConfirmId.Text), hf.Value);
                        }
                        else
                        {
                            Ret = Obj.NewNoteComment(Convert.ToInt32(NoteId.Text), Convert.ToInt32(MyRecDataSet.Tables[0].Rows[0]["EmpID"]), hf.Value);
                        }

                        if (Ret != 0)
                        {
                            editor1.InnerText = "";

                            Rett.Text = "";
                            SucNote.Visible = true;
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "CloseFiles();", true);
                            NoteId.Text = "";
                            RepId.Text = "";
                            LblEdit.Text = "A";
                            DataSet Ds = new DataSet();
                            RepNotes.DataSource = Obj.GetDataSetByID("GetNotes", Convert.ToInt32(LblRep.Text));
                            RepNotes.DataBind();
                            LblEdit.Text = "A";
                            string Body = "<table border='0'><tbody><tr><td><b>رد على التوصية رقم:  </b></td><td>" + NoteId.Text + "</td></tr><tr><td><b>الرد على التوصية:</b></td><td>" + Server.HtmlDecode(hf.Value) + "</td></tr><tr><td><b>تاريخ الرد:</b></td><td>" + DateTime.Now.ToString("yyyy-MM-dd", new System.Globalization.CultureInfo("ar-SA").DateTimeFormat) + "</td></tr><tr><td><b>ملفات مرفقة:</b></td><td><ul style='list-style: none;'>";


                            DataSet DsFil = Obj.GetDataSetByID("GetNoteFiles", Convert.ToInt32(NoteId));


                            if (DsFil.Tables.Count > 0 && DsFil.Tables[0].Rows.Count > 0)
                            {
                                foreach (DataRow RowFile in DsFil.Tables[0].Rows)
                                {
                                    if (RowFile["FPath"] != null)
                                    {
                                        Body += "<li><a href='http://Mutaweron.com/" + Convert.ToString(RowFile["FPath"]) + "'>" + Convert.ToString(RowFile["FName"]) + "<li>";
                                    }
                                }
                            }

                            Body += "</ul></td></tr></tbody></table>";





                            Obj.OurMails("رد على التوصية ", Body, 0, 0, true);




                        }

                    }

                    else { Rett.Text = "حدث خطأ "; }


                }

                else if (EditConfirm.Text != "")
                {
                    if (RepId.Text != "")
                    {
                        string[] arg = new string[2];
                        arg = Save.CommandArgument.ToString().Split(';');


                        Ret = Obj.UpdateReportComment(Convert.ToInt32(arg[1]), Convert.ToInt32(MyRecDataSet.Tables[0].Rows[0]["EmpID"]), hf.Value, Convert.ToInt32(arg[0]));

                        if (Ret != 0)
                        {
                            RepReplys.DataSource = Obj.GetDataSetByID("GetReportConfirm", Convert.ToInt32(arg[1]));
                            RepReplys.DataBind();
                            editor1.InnerHtml = "";
                            BindEmployeesData();
                            Rett.Text = "";
                            SucReply.Visible = true;
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "CloseFiles();", true);
                            NoteId.Text = "";
                            RepId.Text = "";
                            ConfirmId.Text = "";


                            string Body = "<table border='0'><tbody><tr><td><b>تعديل رد على الملاحظة رقم:  </b></td><td>" + RepId.Text + "</td></tr><tr><td><b>الرد علىالملاحظة:</b></td><td>" + Server.HtmlDecode(hf.Value) + "</td></tr><tr><td><b>تاريخ الرد:</b></td><td>" + DateTime.Now.ToString("yyyy-MM-dd", new System.Globalization.CultureInfo("ar-SA").DateTimeFormat) + "</td></tr><tr><td><b>ملفات مرفقة:</b></td><td><ul style='list-style: none;'>";


                            DataSet DsFil = Obj.GetDataSetByID("GetReportFiles", Convert.ToInt32(RepId.Text));


                            if (DsFil.Tables.Count > 0 && DsFil.Tables[0].Rows.Count > 0)
                            {
                                foreach (DataRow RowFile in DsFil.Tables[0].Rows)
                                {
                                    if (RowFile["FPath"] != null)
                                    {
                                        Body += "<li><a href='http://Mutaweron.com/" + Convert.ToString(RowFile["FPath"]) + "'>" + Convert.ToString(RowFile["FName"]) + "<li>";
                                    }
                                }
                            }

                            Body += "</ul></td></tr></tbody></table>";

                            Obj.OurMails("تعديل رد على ملاحظة ", Body, 0, 0, true);




                        }



                    }
                    else if (NoteId.Text != "")
                    {
                        string[] arg = new string[2];
                        arg = Save.CommandArgument.ToString().Split(';');

                        Ret = Obj.UpdateNoteComment(Convert.ToInt32(arg[1]), Convert.ToInt32(MyRecDataSet.Tables[0].Rows[0]["EmpID"]), hf.Value, Convert.ToInt32(arg[0]));
                        if (Ret != 0)
                        {


                            editor1.InnerText = "";

                            Rett.Text = "";
                            SucNote.Visible = true;
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "CloseFiles();", true);
                            NoteId.Text = "";
                            RepId.Text = "";
                            LblEdit.Text = "A";
                            NoteReplys.DataSource = Obj.GetDataSetByID("GetNoteConfirm", Convert.ToInt32(arg[1]));
                            NoteReplys.DataBind();
                            string Body = "<table border='0'><tbody><tr><td><b>رد على التوصية رقم:  </b></td><td>" + NoteId.Text + "</td></tr><tr><td><b>الرد على التوصية:</b></td><td>" + Server.HtmlDecode(hf.Value) + "</td></tr><tr><td><b>تاريخ الرد:</b></td><td>" + DateTime.Now.ToString("yyyy-MM-dd", new System.Globalization.CultureInfo("ar-SA").DateTimeFormat) + "</td></tr><tr><td><b>ملفات مرفقة:</b></td><td><ul style='list-style: none;'>";


                            DataSet DsFil = Obj.GetDataSetByID("GetNoteFiles", Convert.ToInt32(NoteId));


                            if (DsFil.Tables.Count > 0 && DsFil.Tables[0].Rows.Count > 0)
                            {
                                foreach (DataRow RowFile in DsFil.Tables[0].Rows)
                                {
                                    if (RowFile["FPath"] != null)
                                    {
                                        Body += "<li><a href='http://Mutaweron.com/" + Convert.ToString(RowFile["FPath"]) + "'>" + Convert.ToString(RowFile["FName"]) + "<li>";
                                    }
                                }
                            }

                            Body += "</ul></td></tr></tbody></table>";





                            Obj.OurMails("رد على التوصية ", Body, 0, 0, true);




                        }

                    }

                    else { Rett.Text = "حدث خطأ "; }
                    EditConfirm.Text = "";

                }
            }

        }
        catch { }
    }
    protected void RepNotes_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        HtmlControl td = (HtmlControl)e.Item.FindControl("TDNote1");
        HtmlControl td2 = (HtmlControl)e.Item.FindControl("TDNote2");
        if (Convert.ToBoolean(((Label)e.Item.FindControl("LblRepeat")).Text) == true)
        {
            ((Label)e.Item.FindControl("LBLRPTCk")).Text = "مكرر";

            ((System.Web.UI.HtmlControls.HtmlGenericControl)(e.Item.FindControl("TRU"))).Visible = true;
        }
        else if (Convert.ToBoolean(((Label)e.Item.FindControl("LblRepeat")).Text) == false)
        {
            ((Label)e.Item.FindControl("LBLRPTCk")).Text = "غير مكرر";

            ((System.Web.UI.HtmlControls.HtmlGenericControl)(e.Item.FindControl("FALS"))).Visible = true;
        }

        Repeater FileListNotes = (Repeater)e.Item.FindControl("FileListNotes");
        DataSet DsFiles = Obj.GetDataSetByID("GetNoteFiles", Convert.ToInt32(((Label)e.Item.FindControl("NotID")).Text));
        FileListNotes.DataSource = DsFiles;
        FileListNotes.DataBind();



        ((System.Web.UI.HtmlControls.HtmlGenericControl)(e.Item.FindControl("well"))).InnerHtml = Server.HtmlDecode(((Label)e.Item.FindControl("LitDetail")).Text);
        ((System.Web.UI.HtmlControls.HtmlGenericControl)(e.Item.FindControl("Div2"))).InnerHtml = Server.HtmlDecode(((Label)e.Item.FindControl("LbCorrect")).Text);
      
        
        if (((Label)e.Item.FindControl("LblNoteImportant")).Text == "3")
        {
            ((Label)e.Item.FindControl("LblNoteImportant")).Text = "مرتفعة";
            td.Attributes.Add("style", "background-color:Red;");


        }
        if (((Label)e.Item.FindControl("LblNoteImportant")).Text == "2")
        {
            ((Label)e.Item.FindControl("LblNoteImportant")).Text = "متوسطة";

            td.Attributes.Add("style", "background-color:Orange;");


        }
        if (((Label)e.Item.FindControl("LblNoteImportant")).Text == "1")
        {
            ((Label)e.Item.FindControl("LblNoteImportant")).Text = "منخفضة";
            td.Attributes.Add("style", "background-color:LightGreen;");

        }

        if (((Label)e.Item.FindControl("LblNoteStat")).Text == "3")
        {

            ((Label)e.Item.FindControl("LblNoteStat")).Text = "معالجة";

            td2.Attributes.Add("style", "background-color:LightGreen;");

        }
        else if (((Label)e.Item.FindControl("LblNoteStat")).Text == "2")
        {

            ((Label)e.Item.FindControl("LblNoteStat")).Text = "جارى التنفيذ";
            td2.Attributes.Add("style", "background-color:Orange;");
        }
        else if (((Label)e.Item.FindControl("LblNoteStat")).Text == "1")
        {

            ((Label)e.Item.FindControl("LblNoteStat")).Text = "متأخرة";
            td2.Attributes.Add("style", "background-color:Red;");
        }
        else if (((Label)e.Item.FindControl("LblNoteStat")).Text == "4")
        {

            ((Label)e.Item.FindControl("LblNoteStat")).Text = "لم يحن وقت التنفيذ";
            td2.Attributes.Add("style", "background-color:#5b9092;");
        }
        else if (((Label)e.Item.FindControl("LblNoteStat")).Text == "5")
        {

            ((Label)e.Item.FindControl("LblSNotetat")).Text = "مغلقة";
            td2.Attributes.Add("style", "background-color:#cccccc;");
        }

        if ((((Label)e.Item.FindControl("ComNoteCount")).Text != "") && (((Label)e.Item.FindControl("ComNoteCount")).Text != "0"))
        {
            ((LinkButton)e.Item.FindControl("LinkNotes")).Attributes.Remove("Style");
            ((LinkButton)e.Item.FindControl("LinkNotes")).Style.Add("display", "block");
            ((LinkButton)e.Item.FindControl("LinkNotes")).Text += " [ " + ((Label)e.Item.FindControl("ComNoteCount")).Text + " ] ";
            ((System.Web.UI.HtmlControls.HtmlGenericControl)(e.Item.FindControl("NoNotereply"))).Visible = false;

        }
        else
        {
            ((LinkButton)e.Item.FindControl("LinkNotes")).Attributes.Remove("Style");
            ((LinkButton)e.Item.FindControl("LinkNotes")).Style.Add("display", "none");
            ((System.Web.UI.HtmlControls.HtmlGenericControl)(e.Item.FindControl("NoNotereply"))).Visible = true;
        }
    }




    protected void LinkReportFiles_Command(object sender, CommandEventArgs e)
    {
        LblEroor.Visible = false;
        LblEroorNote.Visible = false;
        RepId.Text = e.CommandArgument.ToString();

        editor1.InnerHtml = "";
        SucFile.Visible = false;

        DataSet DsFiles = Obj.GetDataSetByID("GetReportFilesComment", Convert.ToInt32(e.CommandArgument));
        RpeaterFiles.DataSource = DsFiles;
        RpeaterFiles.DataBind();
        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "GetFiles();", true);
        LblEdit.Text = "";
        ConfirmId.Text = "";
        NoteId.Text = "";

    }
    protected void AddFile_Click(object sender, EventArgs e)
    {
        if (Session["UData"] != null)
        {
            DataSet MyRecDataSet = (DataSet)Session["UData"];

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
                    if (ConfirmId.Text == "")
                    {
                        ConfirmId.Text = Convert.ToString(Obj.NewNoteComment(Convert.ToInt32(NoteId.Text), Convert.ToInt32(MyRecDataSet.Tables[0].Rows[0]["EmpID"]), hf.Value));
                    }


                    var Res = Obj.NewAttachCommentReport(Convert.ToInt32(ConfirmId.Text), imgPath, FileUploadR.FileName);
                    if (Res != 0)
                    {

                        if (Res == -1)
                        {

                            LblEroorNote.Visible = true;
                        }
                        else
                        {

                            SucFile.Visible = true;
                            DataSet DsFiles = Obj.GetDataSetByID("GetReportFilesComment", Convert.ToInt32(ConfirmId.Text));
                            RpeaterFiles.DataSource = DsFiles;
                            RpeaterFiles.DataBind();

                        }

                    }
                    else { SucFile.Visible = false; }

                    NoteId.Text = "A";
                }
                else if (RepId.Text != "")
                {
                    if (ConfirmId.Text == "")
                    {
                        ConfirmId.Text = Convert.ToString(Obj.NewReportComment(Convert.ToInt32(RepId.Text), Convert.ToInt32(MyRecDataSet.Tables[0].Rows[0]["EmpID"]), hf.Value));
                    }


                    var Res = Obj.NewAttachCommentReport(Convert.ToInt32(ConfirmId.Text), imgPath, FileUploadR.FileName);
                    if (Res != 0)
                    {

                        if (Res == -1)
                        {

                            LblEroor.Visible = true;
                        }
                        else
                        {

                            SucFile.Visible = true;
                            DataSet DsFiles = Obj.GetDataSetByID("GetReportFilesComment", Convert.ToInt32(ConfirmId.Text));
                            RpeaterFiles.DataSource = DsFiles;
                            RpeaterFiles.DataBind();



                        }
                    }
                    else { SucFile.Visible = false; }
                    RepId.Text = "A";
                }
            }

            editor1.InnerHtml = System.Net.WebUtility.HtmlDecode(hf.Value);

        }
    }
    protected void DelFile_Click(object sender, EventArgs e)
    {
        try
        {
            SucFile.Visible = false;
            var Res = Obj.ExecuteProcedureID("DelReportAttach", Convert.ToInt32(FileId.Value));
            if (Res == 1)
            {
                SucFile.Visible = true;

                if (NoteId.Text != "")
                {
                    DataSet DsFiles = Obj.GetDataSetByID("GetNoteFilesComment", Convert.ToInt32(ConfirmId.Text));
                    RpeaterFiles.DataSource = DsFiles;
                    RpeaterFiles.DataBind();
                    NoteId.Text = "A";
                }
                else if (RepId.Text != "")
                {

                    DataSet DsFiles = Obj.GetDataSetByID("GetReportFilesComment", Convert.ToInt32(ConfirmId.Text));
                    RpeaterFiles.DataSource = DsFiles;
                    RpeaterFiles.DataBind();

                    RepId.Text = "A";
                }

                else if (AddAttach.CommandArgument != "")
                {
                    SucAttach.Visible = true;
                    DataSet DsFiles = Obj.GetDataSetByID("GetReportFilesComment", Convert.ToInt32(ConfirmId.Text));
                    RepAttach.DataSource = DsFiles;
                    RepAttach.DataBind();


                    RepReplys.DataSource = Obj.GetDataSetByID("GetReportConfirm", Convert.ToInt32(AddAttach.CommandArgument));
                    RepReplys.DataBind();

                    ShowFiles.Text = "A";
                }

                else if (LblNote.Text != "")
                {
                    SucAttach.Visible = true;
                    DataSet DsFiles = Obj.GetDataSetByID("GetReportFilesComment", Convert.ToInt32(ConfirmId.Text));
                    RepAttach.DataSource = DsFiles;
                    RepAttach.DataBind();


                    RepReplys.DataSource = Obj.GetDataSetByID("GetNoteConfirm", Convert.ToInt32(LblNote.Text));
                    RepReplys.DataBind();

                    ShowFiles.Text = "A";
                }


            }
        }
        catch { }
    }
    protected void LinkNoteFiles_Command(object sender, CommandEventArgs e)
    {
        string[] arg = new string[2];
        arg = e.CommandArgument.ToString().Split(';');
        editor1.InnerHtml = "";
        SucFile.Visible = false;
        LblEroor.Visible = false;
        LblEroorNote.Visible = false;
        NoteId.Text = arg[0];
        LblRep.Text = arg[1];
        DataSet DsFiles = Obj.GetDataSetByID("GetNoteFilesComment", Convert.ToInt32(arg[0]));
        RpeaterFiles.DataSource = DsFiles;
        RpeaterFiles.DataBind();
        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "GetFiles();", true);
        LblEdit.Text = "";
        ConfirmId.Text = "";
        RepId.Text = "";
    }


    private void SearchbyRepeat()
    {

        if (Session["UData"] != null)
        {
            DataSet MyRecDataSet = (DataSet)Session["UData"];

            //Bind Data According to Repeat
            Admins1.SelectedValue = "0";

            EmployeesData.DataSource = null;
            EmployeesData.DataBind();
            var Repeatchecked = 0;

            if (HiddenPost.Value == "1")
            {
                Repeatchecked = 1;

            }
              EmployeesData.DataSource = Obj.ReportFilterAll(Convert.ToInt32(Mang.SelectedValue), Convert.ToInt32(Sector.SelectedValue), Convert.ToInt32(Importance.SelectedValue==""?"0":Importance.SelectedValue), Convert.ToInt32(RadioStatus.SelectedValue), RepeatSearch.Checked, CheckRepeat.Checked, DateFromSearch.Value.Equals("") ? "0" : DateFromSearch.Value, Convert.ToInt32(PlansSearch.SelectedValue), Repeatchecked);
            EmployeesData.DataBind();
        }
    }
    protected void CheckRepeat_CheckedChanged(object sender, EventArgs e)
    {
        //Bind Data According to Repeat
        if (Session["UData"] != null)
        {
            DataSet MyRecDataSet = (DataSet)Session["UData"];
            Admins1.SelectedValue = "0";
            EmployeesData.DataSource = null;
            EmployeesData.DataBind();
            int Repeatchecked = 0;

            if (HiddenPost.Value == "1")
            {
                Repeatchecked = 1;

            }
              EmployeesData.DataSource = Obj.ReportFilterAll(Convert.ToInt32(Mang.SelectedValue), Convert.ToInt32(Sector.SelectedValue), Convert.ToInt32(Importance.SelectedValue==""?"0":Importance.SelectedValue), Convert.ToInt32(RadioStatus.SelectedValue), RepeatSearch.Checked, CheckRepeat.Checked, DateFromSearch.Value.Equals("") ? "0" : DateFromSearch.Value, Convert.ToInt32(PlansSearch.SelectedValue), Repeatchecked);
            EmployeesData.DataBind();
        }
    }
    protected void LinkReports_Command(object sender, CommandEventArgs e)
    {
        RepNew.Text = e.CommandArgument.ToString();
        RepReplys.DataSource = Obj.GetDataSetByID("GetReportConfirm", Convert.ToInt32(e.CommandArgument));
        RepReplys.DataBind();
        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "GetReplys();", true);
        AddAttach.CommandArgument = e.CommandArgument.ToString();
        LblNote.Text = "";
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
    protected void EditReply_Command(object sender, CommandEventArgs e)
    {
        string[] arg = new string[2];
        arg = e.CommandArgument.ToString().Split(';');

        DataSet Ds = Obj.GetDataSetByID("GetConfirmByID", Convert.ToInt32(arg[0]));

        if (Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow Row in Ds.Tables[0].Rows)
            {
                editor1.InnerHtml = System.Net.WebUtility.HtmlDecode(Convert.ToString(Row["ConfirmText"]));
            }
        }
        LblEroor.Visible = false;
        LblEroorNote.Visible = false;

        Save.CommandArgument = e.CommandArgument.ToString();
        ConfirmId.Text = arg[0];
        DataSet DsFiles = Obj.GetDataSetByID("GetReportFilesComment", Convert.ToInt32(arg[0]));
        RpeaterFiles.DataSource = DsFiles;
        RpeaterFiles.DataBind();
        EditConfirm.Text = "A";
        LblEdit.Text = "";
        RepId.Text = arg[1];
        NoteId.Text = "";
        ShowFiles.Text = "";
    }
    protected void DelReply_Click(object sender, EventArgs e)
    {
        SucReply.Visible = false;
        try
        {
            var Ret = Obj.ExecuteProcedureID("DelConfirmation", Convert.ToInt32(Replyy.Value));
            if (Ret == 1)
            {

                BindEmployeesData();

                if (LblNote.Text != "")
                {
                    NoteReplys.DataSource = Obj.GetDataSetByID("GetNoteConfirm", Convert.ToInt32(LblNote.Text));
                    NoteReplys.DataBind();
                    SucReplyNote.Visible = true;
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "GetNoteReplys();", true);
                    DataSet Ds = new DataSet();
                    RepNotes.DataSource = Obj.GetDataSetByID("GetNotes", Convert.ToInt32(LblRep.Text));
                    RepNotes.DataBind();
                    LblEdit.Text = "A";
                    LblNote.Text = "";

                }
                else
                {
                    RepReplys.DataSource = Obj.GetDataSetByID("GetReportConfirm", Convert.ToInt32(RepNew.Text));
                    RepReplys.DataBind();
                    SucReply.Visible = true;
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "GetReplys();", true);

                }

            }
        }
        catch { }
    }
    protected void LinkRepFiles_Command(object sender, CommandEventArgs e)
    {
        ConfirmId.Text = e.CommandArgument.ToString();
        DataSet DsFiles = Obj.GetDataSetByID("GetReportFilesComment", Convert.ToInt32(e.CommandArgument));
        RepAttach.DataSource = DsFiles;
        RepAttach.DataBind();
        EditConfirm.Text = "";
        RepId.Text = "";
        NoteId.Text = "";
        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "GetAttach();", true);

    }
    protected void AddAttach_Click(object sender, EventArgs e)
    {
        if (fileAll.FileName.Length > 0)
        {
            var imgPath = "";
            //sets the image path
            var r = new Random();
            // print random integer >= 0 and  < 100

            imgPath = "Uploads/" + r.Next(100) + fileAll.FileName;

            //get the size in bytes that
            fileAll.SaveAs(Server.MapPath(imgPath));
            LblEroor.Visible = false;
            var Res = Obj.NewAttachCommentReport(Convert.ToInt32(ConfirmId.Text), imgPath, fileAll.FileName);
            if (Res != 0)
            {

                if (Res == -1)
                {

                    AttachRep.Visible = true;
                }
                else
                {
                    SucAttach.Visible = true;
                    DataSet DsFiles = Obj.GetDataSetByID("GetReportFilesComment", Convert.ToInt32(ConfirmId.Text));
                    RepAttach.DataSource = DsFiles;
                    RepAttach.DataBind();

                    if (AddAttach.CommandArgument != "A")
                    {

                        RepReplys.DataSource = Obj.GetDataSetByID("GetReportConfirm", Convert.ToInt32(AddAttach.CommandArgument));
                        RepReplys.DataBind();

                        ShowFiles.Text = "A";
                    }
                    else
                    {
                        RepReplys.DataSource = Obj.GetDataSetByID("GetNoteConfirm", Convert.ToInt32(LblNote.Text));
                        RepReplys.DataBind();

                        ShowFiles.Text = "A";
                    }

                }
            }
            else { SucAttach.Visible = false; }
        }
    }
    protected void LinkNotes_Command(object sender, CommandEventArgs e)
    {
        NoteNew.Text = e.CommandArgument.ToString();
        NoteReplys.DataSource = Obj.GetDataSetByID("GetNoteConfirm", Convert.ToInt32(e.CommandArgument));
        NoteReplys.DataBind();
        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "GetNoteReplys();", true);
        LblNote.Text = e.CommandArgument.ToString();
        AddAttach.CommandArgument = "";
        NoteId.Text = "";
    }
    protected void LinkNotFiles_Command(object sender, CommandEventArgs e)
    {
        ConfirmId.Text = e.CommandArgument.ToString();
        DataSet DsFiles = Obj.GetDataSetByID("GetReportFilesComment", Convert.ToInt32(e.CommandArgument));
        RepAttach.DataSource = DsFiles;
        RepAttach.DataBind();
        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "GetAttach();", true);
        AddAttach.CommandArgument = "A";
        NoteId.Text = "";
        RepId.Text = "";
        EditConfirm.Text = "";


    }
    protected void EditNoteReply_Command(object sender, CommandEventArgs e)
    {
        EditConfirm.Text = "";
        string[] arg = new string[2];
        arg = e.CommandArgument.ToString().Split(';');

        DataSet Ds = Obj.GetDataSetByID("GetConfirmByID", Convert.ToInt32(arg[0]));

        if (Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow Row in Ds.Tables[0].Rows)
            {
                editor1.InnerHtml = System.Net.WebUtility.HtmlDecode(Convert.ToString(Row["ConfirmText"]));
            }
        }
        ConfirmId.Text = arg[0];
        LblEroor.Visible = false;
        LblEroorNote.Visible = false;

        Save.CommandArgument = e.CommandArgument.ToString();

        DataSet DsFiles = Obj.GetDataSetByID("GetReportFilesComment", Convert.ToInt32(arg[0]));
        RpeaterFiles.DataSource = DsFiles;
        RpeaterFiles.DataBind();
        EditConfirm.Text = "B";
        LblEdit.Text = "";
        RepId.Text = "";
        NoteId.Text = arg[1];
        ShowFiles.Text = "";
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

    protected void PlansSearch_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet MyRecDataSet = (DataSet)Session["UData"];


        Admins1.Items.Clear();
        // Fill dropdown Lists For Reports with date and RepiD
        Admins1.DataSource = Obj.GetDataSetByID("GetReportsByPlan", Convert.ToInt32(PlansSearch.SelectedValue));
        Admins1.DataTextField = "RepDate";
        Admins1.DataValueField = "RepID";
        Admins1.DataBind();
        ListItem Adm = new ListItem();
        Adm.Text = "كل الملاحظات";
        Adm.Value = "0";
        Admins1.Items.Insert(0, Adm);
        Admins1.SelectedValue = "0";
        EmployeesData.DataSource = null;
        EmployeesData.DataBind();
        int Repeatchecked = 0;

        if (HiddenPost.Value == "1")
        {
            Repeatchecked = 1;

        }
          EmployeesData.DataSource = Obj.ReportFilterAll(Convert.ToInt32(Mang.SelectedValue), Convert.ToInt32(Sector.SelectedValue), Convert.ToInt32(Importance.SelectedValue==""?"0":Importance.SelectedValue), Convert.ToInt32(RadioStatus.SelectedValue), RepeatSearch.Checked, CheckRepeat.Checked, DateFromSearch.Value.Equals("") ? "0" : DateFromSearch.Value, Convert.ToInt32(PlansSearch.SelectedValue), Repeatchecked);
        EmployeesData.DataBind();

    }
    protected void Sector_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Fill Reports Data according to selected section

        if (Sector.SelectedValue != "")
        {
            if (Admins1.SelectedValue != "0")
            {
                Admins1.SelectedValue = "0";
            }
            if (Sector.SelectedValue != "0")
            {

                DataTable DTImportant = Obj.GetDataSetByID("ReportCountImportBySec", Convert.ToInt32(Sector.SelectedValue)).Tables[0];

                DataTable DTStatus = Obj.GetDataSetByID("ReportCountStatusBySec", Convert.ToInt32(Sector.SelectedValue)).Tables[0];

                foreach (ListItem ltItem in Importance.Items)
                {
                    if (ltItem.Value != "0")
                    {
                        var dT = DTImportant.AsEnumerable().Where(x => x.Field<int>("Importance") == Convert.ToInt32(ltItem.Value)).FirstOrDefault();

                        string Counts = "0";
                        if (dT != null)
                        {
                            Counts = dT["Counts"].ToString();
                        }
                        ltItem.Text = ltItem.Text.Substring(0, ltItem.Text.LastIndexOf('[') - 1) + " [ " + Counts + " ] ";
                    }
                }
                foreach (ListItem ltItem in RadioStatus.Items)
                {
                    if (ltItem.Value != "0")
                    {
                        var dT = DTStatus.AsEnumerable().Where(x => x.Field<int>("RepStatus") == Convert.ToInt32(ltItem.Value)).FirstOrDefault();
                        string Counts = "0";
                        if (dT != null)
                        {
                            Counts = dT["Counts"].ToString();
                        }

                        ltItem.Text = ltItem.Text.Substring(0, ltItem.Text.LastIndexOf('[') - 1) + " [ " + Counts + " ] ";
                    }
                }



                EmployeesData.DataSource = null;
                EmployeesData.DataBind();
                int Repeatchecked = 0;

                if (HiddenPost.Value == "1")
                {
                    Repeatchecked = 1;

                }
                EmployeesData.DataSource = Obj.ReportFilterAll(Convert.ToInt32(Mang.SelectedValue), Convert.ToInt32(Sector.SelectedValue), Convert.ToInt32(Importance.SelectedValue), Convert.ToInt32(RadioStatus.SelectedValue), RepeatSearch.Checked, CheckRepeat.Checked, DateFromSearch.Value.Equals("") ? "0" : DateFromSearch.Value, Convert.ToInt32(PlansSearch.SelectedValue),Repeatchecked);
                EmployeesData.DataBind();

                DataSet DsFiles = Obj.GetDataSetByID("GetAdminFilesBySection", Convert.ToInt32(Sector.SelectedValue));
                RepFileAdmins.DataSource = DsFiles;
                RepFileAdmins.DataBind();
                
                ListItem aa = new ListItem();
                aa.Text = "كلالإدارات المتوسطة";
                aa.Value = "0";
                Mang.Items.Clear();
                Mang.Items.Add(aa);
                Mang.DataBind();

            }
            else
            {
                BindEmployeesData();
                DataTable DTImportant = Obj.GetDataSet("ReportCountRepImportance").Tables[0];

                DataTable DTStatus = Obj.GetDataSet("ReportCountRepStatus").Tables[0];

                foreach (ListItem ltItem in Importance.Items)
                {
                    if (ltItem.Value != "0")
                    {
                        var dT = DTImportant.AsEnumerable().Where(x => x.Field<int>("Importance") == Convert.ToInt32(ltItem.Value)).FirstOrDefault();
                        string Counts = "0";
                        if (dT != null)
                        {
                            Counts = dT["Counts"].ToString();
                        }
                        ltItem.Text = " [ " + Counts + " ] ";
                    }
                }
                foreach (ListItem ltItem in RadioStatus.Items)
                {
                    if (ltItem.Value != "0")
                    {
                        var dT = DTStatus.AsEnumerable().Where(x => x.Field<int>("RepStatus") == Convert.ToInt32(ltItem.Value)).FirstOrDefault();
                        string Counts = "0";
                        if (dT != null)
                        {
                            Counts = dT["Counts"].ToString();
                        }


                        ltItem.Text = " [ " + Counts + " ] ";
                    }
                }
            }


        }


    }

}
