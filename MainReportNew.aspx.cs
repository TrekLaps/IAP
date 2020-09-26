using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MainReportNew : System.Web.UI.Page
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

                CloseAll();
                Main.Attributes.Remove("Style");
                Main.Style.Add("display", "block");
                if (Convert.ToBoolean(MyRecDataSet.Tables[0].Rows[0]["Gov"]) == true)
                {
                    Response.Redirect("MainReport.aspx");
                }
                else if (Convert.ToBoolean(MyRecDataSet.Tables[0].Rows[0]["ApprovPermission"]) == true)
                {

                    MainYear.DataSource = DropYear.DataSource = DropYearU.DataSource = Obj.GetDataSet("GetPlans");
                    MainYear.DataTextField = DropYear.DataTextField = DropYearU.DataTextField = "YearName";
                    MainYear.DataValueField = DropYear.DataValueField = DropYearU.DataValueField = "ID";
                    DropYear.DataBind();
                    DropYearU.DataBind();
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

    private void CloseAll()
    {
        BindAllData();
        Main.Attributes.Remove("Style");
        Main.Style.Add("display", "none");

        NewSave.Attributes.Remove("Style");
        NewSave.Style.Add("display", "none");

        UpdateSave.Attributes.Remove("Style");
        UpdateSave.Style.Add("display", "none");
    }
    protected void Sector_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Fill Reports Data according to selected section

        if (Sector.SelectedValue != "")
        {
            if (DropYear.SelectedValue != "0")
            {
                ListItem aa = new ListItem();
                aa.Text = "اختر الادارة";
                aa.Value = "0";
                Mang.Items.Clear();
                Mang.Items.Insert(0, aa);

                Mang.DataSource = Obj.GetPlansAdmins(Convert.ToInt32(DropYear.SelectedValue), Convert.ToInt32(Sector.SelectedValue));

                Mang.DataTextField = "AdmName";
                Mang.DataValueField = "AdmID";
                Mang.DataBind();
            }
        }

        else { BindAllData(); }
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
        else { BindAllData(); }
    }


    protected void Save_Click(object sender, EventArgs e)
    {
      Suc.Visible = false; SucDel.Visible = false;
        Rett.Text = "";
        string imgPath = ""; // Define the Employee Photo file

        if (FileUpload1.HasFiles)
        {

            string ext = System.IO.Path.GetExtension(FileUpload1.PostedFile.FileName);
            if (ext != ".exe" || ext != ".php")
            {
                //sets the image path
                var r = new Random();
                // print random integer >= 0 and  < 100


                imgPath = "Uploads/" + r.Next(100) + FileUpload1.FileName;

                //get the size in bytes that
                FileUpload1.SaveAs(Server.MapPath(imgPath));

                var Res = Obj.NewMainReports(Convert.ToInt32(DropYear.SelectedValue), Convert.ToInt32(Sector.SelectedValue), Convert.ToInt32(Mang.SelectedValue), imgPath, FileName.Value);
                if (Res == 0)
                {
                    Rett.Text = "البيانات مسجلة سابقا لنفس الخطة والإدارة العليا والادارة";
                }
                else
                {
                    CloseAll();
                    DropYear.ClearSelection();
                    Sector.ClearSelection();
                    Mang.ClearSelection();
                    FileName.Value="";
                    FileUpload1.Attributes.Clear();
                    Main.Attributes.Remove("Style");
                    Main.Style.Add("display", "block");
                    Suc.Visible = true; SucDel.Visible = false;
                }
            }
        }
    }

    protected void DelEmployee_Click(object sender, EventArgs e)
    {
      Suc.Visible = false; SucDel.Visible = false;
        Obj.ExecuteProcedureID("DelMainReport", Convert.ToInt32(bookId.Value));
        Suc.Visible = false; SucDel.Visible = true;
        BindAllData();
        CloseAll();
        Main.Attributes.Remove("Style");
        Main.Style.Add("display", "block");

    }

    protected void Edit_Command(object sender, CommandEventArgs e)
    {

        CloseAll();
        UpdateSave.Attributes.Remove("Style");
        UpdateSave.Style.Add("display", "block");

        DataSet Ds = Obj.GetDataSetByID("GetMainReportByID", Convert.ToInt32(e.CommandArgument));
        if (Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow Row in Ds.Tables[0].Rows)
            {
                Update.CommandArgument = Convert.ToString(Row["ID"]);

                DropYearU.SelectedValue = Convert.ToString(Row["MainRYear"]);
                FillSectorU();

                SectorU.SelectedValue = Convert.ToString(Row["MainRSector"]);

                FillDepartmentU();
                MangU.SelectedValue = Convert.ToString(Row["MainRDepart"]);
                FileNameU.Value = Convert.ToString(Row["MainRName"]);

                LinkFile.Text = Convert.ToString(Row["MainRName"]);
                LinkFile.NavigateUrl = Convert.ToString(Row["MainRFile"]);
            }
        }
    }

    protected void Update_Click(object sender, EventArgs e)
    {

      Suc.Visible = false; SucDel.Visible = false;
        RettU.Text = "";
        string imgPath = ""; // Define the Employee Photo file
        bool FileUPD = false;
        if (FileUpload2.HasFiles)
        {
            FileUPD = true;
            string ext = System.IO.Path.GetExtension(FileUpload2.PostedFile.FileName);
            if (ext != ".exe" || ext != ".php")
            {
                //sets the image path
                var r = new Random();
                // print random integer >= 0 and  < 100


                imgPath = "Uploads/" + r.Next(100) + FileUpload2.FileName;

                //get the size in bytes that
                FileUpload2.SaveAs(Server.MapPath(imgPath));
            }
        }
        var Res = Obj.UpdateMainReports(Convert.ToInt32(DropYearU.SelectedValue), Convert.ToInt32(SectorU.SelectedValue), Convert.ToInt32(MangU.SelectedValue), imgPath, FileNameU.Value, FileUPD, Convert.ToInt32(Update.CommandArgument));
        if (Res == 0)
        {
            RettU.Text = "البيانات مسجلة سابقا";
        }
        else if (Res == 1)
        {
            CloseAll();
            Main.Attributes.Remove("Style");
            Main.Style.Add("display", "block");
            Suc.Visible = true; SucDel.Visible = false;
        }

    }



    protected void SectorU_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillDepartmentU();
    }

    protected void DropYearU_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillSectorU();
    }
    private void FillDepartmentU()
    { // Fill Reports Data according to selected section

        if (SectorU.SelectedValue != "")
        {
            if (DropYearU.SelectedValue != "0")
            {
                ListItem aa = new ListItem();
                aa.Text = "اختر الادارة";
                aa.Value = "0";
                MangU.Items.Clear();
                MangU.Items.Insert(0, aa);

                MangU.DataSource = Obj.GetPlansAdmins(Convert.ToInt32(DropYearU.SelectedValue), Convert.ToInt32(SectorU.SelectedValue));

                MangU.DataTextField = "AdmName";
                MangU.DataValueField = "AdmID";
                MangU.DataBind();
            }
        }
    }
    private void FillSectorU()
    {
        SectorU.Items.Clear();
        SectorU.DataSource = Obj.GetDataSetByID("GetPlansSection", Convert.ToInt32(DropYearU.SelectedValue));
        SectorU.DataTextField = "SectionName";
        SectorU.DataValueField = "SectionID";
        SectorU.DataBind();
        ListItem aa = new ListItem();
        aa.Text = "اختر الإدارة العليا";
        aa.Value = "0";
        SectorU.Items.Insert(0, aa);
        SectorU.SelectedValue = "0";
    }

    protected void NewRep_Click(object sender, EventArgs e)
    {
        CloseAll();
        NewSave.Attributes.Remove("Style");
        NewSave.Style.Add("display", "block");
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
    {
        if (MainDepart.SelectedValue != "0")
        {
            EmployeesData.DataSource = null;
            EmployeesData.DataBind();
            EmployeesData.DataSource = Obj.FilterMainReportsAll(Convert.ToInt32(MainYear.SelectedValue), Convert.ToInt32(MainSector.SelectedValue), Convert.ToInt32(MainDepart.SelectedValue));
            EmployeesData.DataBind();
        }
        else { BindAllData(); }

    }



    protected void BackCharts_Click(object sender, EventArgs e)
    {
        BindAllData();
        CloseAll();
        Main.Attributes.Remove("Style");
        Main.Style.Add("display", "block");
    }
}