using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class MasterPage : System.Web.UI.MasterPage
{
    Operations Obj = new Operations();

    protected void Page_Load(object sender, EventArgs e)
    {
        String activepage = Request.FilePath;
        if (activepage.Contains("MainPage.aspx") || activepage.Contains("mainpage.aspx"))
        {
            Ul1.Attributes.Add("class", "active");
        }
        else if (activepage.Contains("ReportsView"))
        {
            // ViewReps.Attributes.Add("class", "active");
            ViewNotesMyDepartment.Attributes.Add("class", "active");

            // SubRev.Attributes.Add("style", "display:inline-block");


        }

        else if (activepage.Contains("MainReportNewAdm"))
        {
            // ViewReps.Attributes.Add("class", "active");



            NewMainAdm.Attributes.Add("class", "active");
        }
        else if (activepage.Contains("MainReportSection"))
        {
            // ViewReps.Attributes.Add("class", "active");

            NewMainSection.Attributes.Add("class", "active");
        }

        else if (activepage.Contains("ReportSection"))
        {
            // ViewReps.Attributes.Add("class", "active");

            ResSection.Attributes.Add("class", "active");
        }

        else if (activepage.Contains("MainReportNew"))
        {
            // ViewReps.Attributes.Add("class", "active");


            NewMain.Attributes.Add("class", "active");



        }
        else if (activepage.Contains("MainReport"))
        {
            // ViewReps.Attributes.Add("class", "active");


            NewMain.Attributes.Add("class", "active");
            NewMain.Attributes.Add("style", "display:inline-block");



        }


        else if (activepage.Contains("ReportsDiv"))
        {
            ViewNotesRes.Attributes.Add("class", "active");
            Result.Attributes.Add("class", "active");
            // SubRes.Attributes.Add("style", "display:inline-block");


        }
        else if (activepage.Contains("MainReportNew"))
        {
            // ViewAllReps.Attributes.Add("class", "active");
            NewMain.Attributes.Add("class", "active");
            // SubRev.Attributes.Add("style", "display:inline-block");


        }



        else if (activepage.Contains("PieDashboard01")|| activepage.Contains("ReportingAdmSections") || activepage.Contains("PieDashboard02"))
        {
            ViewResSectors.Attributes.Add("class", "active");
            Review.Attributes.Add("class", "active");
            //  SubRev.Attributes.Add("style", "display:inline-block");
        }


        else if (activepage.Contains("PieDashboardAdmin") || activepage.Contains("PieDashboardAdmin01"))
        {
            ViewResAdm.Attributes.Add("class", "active");
            Review.Attributes.Add("class", "active");


            ReviewAdm.Attributes.Add("class", "active");

            // SubRev.Attributes.Add("style", "display:inline-block");
        }

        else if (activepage.Contains("PieDashboardSection") || activepage.Contains("SectionAdminsCharts") || activepage.Contains("SectionAdminsCharts"))
        {
            

            ReviewSection.Attributes.Add("class", "active");

            // SubRev.Attributes.Add("style", "display:inline-block");
        }
        else if (activepage.Contains("MainDashboardGraph01") || activepage.Contains("SectionsCharts.aspx") || activepage.Contains("AdminsCharts.aspx") || activepage.Contains("Reporting.aspx"))
        {
            ViewRes.Attributes.Add("class", "active");
            Review.Attributes.Add("class", "active");
            // SubRev.Attributes.Add("style", "display:inline-block");

            // Result.Attributes.Add("style", "display:none");
        }

        else if (activepage.Contains("MainReportNew"))
        {
            NewMain.Attributes.Add("class", "active");
            //Reply.Attributes.Add("class", "active Reply");
            // SubReply.Attributes.Add("style", "display:inline-block");

        }
        else if (activepage.Contains("PendingReports"))
        {
            ViewPending.Attributes.Add("class", "active");
            SubReply.Attributes.Add("style", "display:inline-block");

        }
        else if (activepage.Contains("NewReport"))
        {
            ViewNewNote.Attributes.Add("class", "active");
            Result.Attributes.Add("class", "active");
            //   SubRes.Attributes.Add("style", "display:inline-block");


        }
        else if (activepage.Contains("ReportingAllSections"))
        {
            ReviewSection.Attributes.Add("class", "active");
            SubAdmin.Attributes.Add("style", "display:none");
        }
        else if (activepage.Contains("Plans"))
        {
            PlansView.Attributes.Add("class", "active");
            SubAdmin.Attributes.Add("class", "active");
            
        }

        else if (activepage.Contains("Sections"))
        {
            SecView.Attributes.Add("class", "active");
            SubAdmin.Attributes.Add("class", "active");
            

        }
        else if (activepage.Contains("Managments"))
        {
            AdmView.Attributes.Add("class", "active");
            SubAdmin.Attributes.Add("class", "active");


           
        }
        else if (activepage.Contains("/Users.aspx"))

        {
            UserView.Attributes.Add("class", "active");
            SubAdmin.Attributes.Add("class", "active");
            
        }
        else if (activepage.Contains("AdminUsers"))
        {
            AdmUseView.Attributes.Add("class", "active");
            SubAdmin.Attributes.Add("class", "active");
            
        }
        else if (activepage.Contains("ReportsUsers"))
        {
            RepView.Attributes.Add("class", "active");
            SubAdmin.Attributes.Add("class", "active");
           
        }


        if (!IsPostBack)
        {
            UName.Visible = false;
            if (Session["UData"] != null) // check if session is not null 
            {
                DataSet MyRecDataSet = (DataSet)Session["UData"];

                foreach (DataRow Row in MyRecDataSet.Tables[0].Rows)
                {
                    UName.Visible = true;
                    UName.InnerText = Convert.ToString(Row["EmpName"]);


                    Ul1.Attributes.Remove("Style");
                    Ul1.Style.Add("display", "inline-block");



                    if ((Convert.ToBoolean(Row["SystemAdmin"]) == true) && (Convert.ToString(Row["EmpName"]) == "Admin"))
                    {
                        /// Log Data Start

                        LogDat.Attributes.Remove("Style");
                        LogDat.Style.Add("display", "block");

                        /// Log Data End

                        ReviewAdm.Attributes.Remove("Style");
                        ReviewAdm.Style.Add("display","none" );

                        Review.Attributes.Remove("Style");
                        Review.Style.Add("display", "inline-block");
                        ReviewSection.Attributes.Remove("Style");
                        ReviewSection.Style.Add("display", "none");

                        SubAdmin.Attributes.Remove("Style");
                        SubAdmin.Style.Add("display", "inline-block"); // display his menu

                        NewMain.Attributes.Remove("Style");
                        NewMain.Style.Add("display", "inline-block");

                        NewMainAdm.Attributes.Remove("Style");
                        NewMainAdm.Style.Add("display", "none");
                        NewMainSection.Attributes.Remove("Style");
                        NewMainSection.Style.Add("display", "none");

                        Result.Attributes.Remove("Style");
                        Result.Style.Add("display", "inline-block");
                        ResSection.Attributes.Remove("Style");
                        ResSection.Style.Add("display", "none");
                        ViewNotesMyDepartment.Attributes.Remove("Style");
                        ViewNotesMyDepartment.Style.Add("display", "none");
                        //Comments.Attributes.Remove("Style");
                        //Comments.Style.Add("display", "inline-block"); // display Top Comments


                        //RepComments.DataSource = Obj.GetDataSet("GetComments");
                        //RepComments.DataBind();

                        // added

                        ViewNewNote.Attributes.Remove("Style");
                        ViewNewNote.Style.Add("display", "inline-block");


                        ViewNotesRes.Attributes.Remove("Style");
                        ViewNotesRes.Style.Add("display", "inline-block");

                        ViewRes.Attributes.Remove("Style");
                        ViewRes.Style.Add("display", "inline-block");

                        ViewResSectors.Attributes.Remove("Style");
                        ViewResSectors.Style.Add("display", "inline-block");

                        ViewResAdm.Attributes.Remove("Style");
                        ViewResAdm.Style.Add("display", "inline-block");




                    }

                 else if ((Convert.ToBoolean(Row["ApprovPermission"]) == true))
                    {

                        ReviewAdm.Attributes.Remove("Style");
                        ReviewAdm.Style.Add("display", "none");

                        Review.Attributes.Remove("Style");
                        Review.Style.Add("display", "inline-block");
                        ReviewSection.Attributes.Remove("Style");
                        ReviewSection.Style.Add("display", "none");

                        SubAdmin.Attributes.Remove("Style");
                        SubAdmin.Style.Add("display", "none"); // display his menu

                        NewMain.Attributes.Remove("Style");
                        NewMain.Style.Add("display", "inline-block");

                        NewMainAdm.Attributes.Remove("Style");
                        NewMainAdm.Style.Add("display", "none");
                        NewMainSection.Attributes.Remove("Style");
                        NewMainSection.Style.Add("display", "none");

                        Result.Attributes.Remove("Style");
                        Result.Style.Add("display", "inline-block");
                        ResSection.Attributes.Remove("Style");
                        ResSection.Style.Add("display", "none");
                        ViewNotesMyDepartment.Attributes.Remove("Style");
                        ViewNotesMyDepartment.Style.Add("display", "none");
                        //Comments.Attributes.Remove("Style");
                        //Comments.Style.Add("display", "inline-block"); // display Top Comments


                        //RepComments.DataSource = Obj.GetDataSet("GetComments");
                        //RepComments.DataBind();

                        // added

                        ViewNewNote.Attributes.Remove("Style");
                        ViewNewNote.Style.Add("display", "inline-block");


                        ViewNotesRes.Attributes.Remove("Style");
                        ViewNotesRes.Style.Add("display", "inline-block");

                        ViewRes.Attributes.Remove("Style");
                        ViewRes.Style.Add("display", "inline-block");

                        ViewResSectors.Attributes.Remove("Style");
                        ViewResSectors.Style.Add("display", "inline-block");

                        ViewResAdm.Attributes.Remove("Style");
                        ViewResAdm.Style.Add("display", "inline-block");



                    }
                    else if ((Convert.ToBoolean(Row["Gov"]) == true))
                    {
                       

                        NewMain.Attributes.Remove("Style");
                        NewMain.Style.Add("display", "none");


                        NewMainSection.Attributes.Remove("Style");
                        NewMainSection.Style.Add("display", "none");

                        Review.Attributes.Remove("Style");
                        Review.Style.Add("display", "none");

                        Result.Attributes.Remove("Style");
                        Result.Style.Add("display", "none");


                        NewMainAdm.Attributes.Remove("Style");
                        NewMainAdm.Style.Add("display", "none");


                        SubAdmin.Attributes.Remove("Style"); // else hide his menu

                        SubAdmin.Style.Add("display", "none");
                        //Comments.Attributes.Remove("Style");
                        //Comments.Style.Add("display", "none"); // display Top Comments


                        NewRep.Attributes.Remove("Style");
                        NewRep.Style.Add("display", "none");

                        ViewRes.Attributes.Remove("Style");
                        ViewRes.Style.Add("display", "none");

                        ViewResSectors.Attributes.Remove("Style");
                        ViewResSectors.Style.Add("display", "none");
                        ResSection.Attributes.Remove("Style");
                        ResSection.Style.Add("display", "none");

                        ViewPending.Attributes.Remove("Style");

                        ViewPending.Style.Add("display", "none");



                        ViewNotesMyDepartment.Attributes.Remove("Style");
                        ViewNotesMyDepartment.Style.Add("display", "none");
                        
                        ViewRes.Attributes.Remove("Style");
                        ViewRes.Style.Add("display", "none");

                        //ViewReps.Attributes.Remove("Style");
                        //ViewReps.Style.Add("display", "inline-block");


                        //ViewResAdm.Attributes.Remove("Style");
                        //ViewResAdm.Style.Add("display", "inline-block");



                        ReviewGv.Attributes.Remove("Style");
                        ReviewGv.Style.Add("display", "inline-block");


                        
                        NewMain.Attributes.Remove("Style");
                        NewMain.Style.Add("display", "inline-block");


                        //ViewResSectors.Attributes.Remove("Style");
                        //ViewResSectors.Style.Add("display", "inline-block");

                    }


                  
                    else  if (Obj.ExecuteProcedureID("CheckSectionManger", Convert.ToInt32(Row["EmpID"])) == 1)
                    {
                        HyperLink2.NavigateUrl = "PieDashboardSection.aspx?ReqY=0&Reqq=" + Convert.ToString(MyRecDataSet.Tables[0].Rows[0]["SectionID"]);

                        ReviewAdm.Attributes.Remove("Style");
                        ReviewAdm.Style.Add("display", "none");

                        Review.Attributes.Remove("Style");
                        Review.Style.Add("display", "none");
                        ReviewSection.Attributes.Remove("Style");
                        ReviewSection.Style.Add("display", "inline-block");

                        NewMainAdm.Attributes.Remove("Style");
                        NewMainAdm.Style.Add("display", "none");

                       
                        SubAdmin.Attributes.Remove("Style");
                        SubAdmin.Style.Add("display", "none"); // display his menu

                        NewMain.Attributes.Remove("Style");
                        NewMain.Style.Add("display", "none");

                        Result.Attributes.Remove("Style");
                        Result.Style.Add("display", "none");

                        ResSection.Attributes.Remove("Style");
                        ResSection.Style.Add("display", "inline-block");

                        ViewResSectors.Attributes.Remove("Style");
                        ViewResSectors.Style.Add("display", "inline-block");

                        ViewNotesRes.Attributes.Remove("Style");
                        ViewNotesRes.Style.Add("display", "inline-block");


                        NewMain.Attributes.Remove("Style");
                        NewMain.Style.Add("display", "none");

                        NewMainAdm.Attributes.Remove("Style");
                        NewMainAdm.Style.Add("display", "none");
                        NewMainSection.Attributes.Remove("Style");
                        NewMainSection.Style.Add("display", "inline-block");


                        if ((Convert.ToBoolean(Row["SystemAdmin"]) == false))
                        {
                            ViewPending.Attributes.Remove("Style");
                            ViewPending.Style.Add("display", "inline-block");
                        }
                    }
                    else  if (Obj.ExecuteProcedureID("CheckAdminManger", Convert.ToInt32(MyRecDataSet.Tables[0].Rows[0]["EmpID"])) == 1)
                    {
                        //ViewReps.Attributes.Remove("Style");
                        //ViewReps.Style.Add("display", "inline-block");

                        HyperLink1.NavigateUrl = "PieDashboardAdmin.aspx?ReqY=0&Reqq=" + Convert.ToString(MyRecDataSet.Tables[0].Rows[0]["AdmID"]);
                        SubAdmin.Attributes.Remove("Style");
                        SubAdmin.Style.Add("display", "none"); // display his menu

                        NewMain.Attributes.Remove("Style");
                        NewMain.Style.Add("display", "none");

                        NewMainAdm.Attributes.Remove("Style");
                        NewMainAdm.Style.Add("display", "inline-block");
                        NewMainSection.Attributes.Remove("Style");
                        NewMainSection.Style.Add("display", "none");

                        ReviewAdm.Attributes.Remove("Style");
                        ReviewAdm.Style.Add("display", "inline-block");

                        Review.Attributes.Remove("Style");
                        Review.Style.Add("display", "none");
                        ReviewSection.Attributes.Remove("Style");
                        ReviewSection.Style.Add("display", "none");

                        Peplyview.Attributes.Remove("Style");
                        Peplyview.Style.Add("display", "inline-block");

                        ResSection.Attributes.Remove("Style");
                        ResSection.Style.Add("display", "none");
                        Result.Attributes.Remove("Style");
                        Result.Style.Add("display", "none");

                        ViewResAdm.Attributes.Remove("Style");
                        ViewResAdm.Style.Add("display", "inline-block");

                        ViewNotesMyDepartment.Attributes.Remove("Style");
                        ViewNotesMyDepartment.Style.Add("display", "inline-block");


                        ResSection.Attributes.Remove("Style");
                        ResSection.Style.Add("display", "none");
                        

                    }
                  
                    else if ((Convert.ToBoolean(Row["Reciv"]) == true))
                    {
                       


                        NewMain.Attributes.Remove("Style");
                        NewMain.Style.Add("display", "none");


                        NewMainSection.Attributes.Remove("Style");
                        NewMainSection.Style.Add("display", "none");

                        Review.Attributes.Remove("Style");
                        Review.Style.Add("display", "none");

                        Result.Attributes.Remove("Style");
                        Result.Style.Add("display", "none");


                        NewMainAdm.Attributes.Remove("Style");
                        NewMainAdm.Style.Add("display", "none");


                        SubAdmin.Attributes.Remove("Style"); // else hide his menu

                        SubAdmin.Style.Add("display", "none");
                        //Comments.Attributes.Remove("Style");
                        //Comments.Style.Add("display", "none"); // display Top Comments


                        NewRep.Attributes.Remove("Style");
                        NewRep.Style.Add("display", "none");

                        ViewRes.Attributes.Remove("Style");
                        ViewRes.Style.Add("display", "none");

                        ViewResSectors.Attributes.Remove("Style");
                        ViewResSectors.Style.Add("display", "none");
                        ResSection.Attributes.Remove("Style");
                        ResSection.Style.Add("display", "none");

                        ViewPending.Attributes.Remove("Style");

                        ViewPending.Style.Add("display", "none");



                        ViewNotesMyDepartment.Attributes.Remove("Style");
                        ViewNotesMyDepartment.Style.Add("display", "none");

                        ReviewGv.Attributes.Remove("Style");
                        ReviewGv.Style.Add("display", "none");

                        ViewRes.Attributes.Remove("Style");
                        ViewRes.Style.Add("display", "none");

                        //ViewReps.Attributes.Remove("Style");
                        //ViewReps.Style.Add("display", "inline-block");


                        //ViewResAdm.Attributes.Remove("Style");
                        //ViewResAdm.Style.Add("display", "inline-block");

                        ViewNewNote.Attributes.Remove("Style");
                        ViewNewNote.Style.Add("display", "none");


                        ViewNotesRes.Attributes.Remove("Style");
                        ViewNotesRes.Style.Add("display", "none");

                        ViewRes.Attributes.Remove("Style");
                        ViewRes.Style.Add("display", "none");

                        ViewResSectors.Attributes.Remove("Style");
                        ViewResSectors.Style.Add("display", "none");

                        ViewResAdm.Attributes.Remove("Style");
                        ViewResAdm.Style.Add("display", "inline-block");

                        ViewNotesMyDepartment.Attributes.Remove("Style");
                        ViewNotesMyDepartment.Style.Add("display", "inline-block");

                        Ul1.Attributes.Remove("Style");
                        Ul1.Style.Add("display", "inline-block");

                    }



                    else
                    {
                        

                        NewMain.Attributes.Remove("Style");
                        NewMain.Style.Add("display", "none");


                        NewMainSection.Attributes.Remove("Style");
                        NewMainSection.Style.Add("display", "none");

                        Review.Attributes.Remove("Style");
                        Review.Style.Add("display", "none");

                        Result.Attributes.Remove("Style");
                        Result.Style.Add("display", "none");


                        NewMainAdm.Attributes.Remove("Style");
                        NewMainAdm.Style.Add("display", "none");


                        SubAdmin.Attributes.Remove("Style"); // else hide his menu

                        SubAdmin.Style.Add("display", "none");
                        //Comments.Attributes.Remove("Style");
                        //Comments.Style.Add("display", "none"); // display Top Comments


                        NewRep.Attributes.Remove("Style");
                        NewRep.Style.Add("display", "none");

                        ViewRes.Attributes.Remove("Style");
                        ViewRes.Style.Add("display", "none");

                        ViewResSectors.Attributes.Remove("Style");
                        ViewResSectors.Style.Add("display", "none");
                        ResSection.Attributes.Remove("Style");
                        ResSection.Style.Add("display", "none");

                        ViewPending.Attributes.Remove("Style");

                        ViewPending.Style.Add("display", "none");



                        ViewNotesMyDepartment.Attributes.Remove("Style");
                        ViewNotesMyDepartment.Style.Add("display", "none");

                        ReviewGv.Attributes.Remove("Style");
                        ReviewGv.Style.Add("display", "none");
                        
                        ViewRes.Attributes.Remove("Style");
                        ViewRes.Style.Add("display", "none");

                        //ViewReps.Attributes.Remove("Style");
                        //ViewReps.Style.Add("display", "inline-block");


                        //ViewResAdm.Attributes.Remove("Style");
                        //ViewResAdm.Style.Add("display", "inline-block");



                        Ul1.Attributes.Remove("Style");
                        Ul1.Style.Add("display", "inline-block");

                    }


                }

            }
            else
            {
                Response.Redirect("Login.aspx?Url=" + HttpContext.Current.Request.Url.PathAndQuery);
            }
        }
    }
    protected void Log_Click(object sender, EventArgs e)
    {
        Session.Clear(); // if logout clear session and go to Login
        Response.Redirect("Login.aspx");
    }
}
