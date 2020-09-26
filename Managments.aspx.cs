using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System;

public partial class Managments : System.Web.UI.Page
{
    Operations Obj = new Operations();

    private void BindEmployeesData()
    {
        EmployeesData.DataSource = Obj.GetDataSetByID("GetAdministrations", Convert.ToInt32(Admins.SelectedValue));
        EmployeesData.DataBind();

    }
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            if (Session["UData"] != null)
            {
                DataSet MyRecDataSet = (DataSet)Session["UData"];

                if (Convert.ToBoolean(MyRecDataSet.Tables[0].Rows[0]["SystemAdmin"]) == true)
                {


                    SectorU.DataSource = Admins.DataSource = Obj.GetDataSet("GetSections");
                    SectorU.DataTextField = Admins.DataTextField = "SectionName";
                    SectorU.DataValueField = Admins.DataValueField = "SectionID";
                    Admins.DataBind();
                    Admins.Items.Insert(0, "");
                    SectorU.DataBind();
                    SectorU.Items.Insert(0, "");

                   


                }
                else
                {
                    Response.Redirect("NoPermissions.aspx");
                }
            }
        }

    }
    protected void Save_Click(object sender, EventArgs e)
    {
        try
        {
            Suc.Visible = false;
            
            var Ret = Obj.NewAdministration(EmpName.Value, Convert.ToInt32(Admins.SelectedValue) );
            if (Ret == 0)
            {
                Rett.Text = "اسم الإدارة متوسطة مسجل من قبل";

            }
            else
            {


                Rett.Text = "";
                Suc.Visible = true;
                BindEmployeesData();
                CloseAll();
                Main.Attributes.Remove("style");
                Main.Style.Add("display", "block");

            }


        }
        catch { }
    }
    protected void DelEmployee_Click(object sender, EventArgs e)
    {
        Suc.Visible = false;
        Obj.ExecuteProcedureID("DelAdministration", Convert.ToInt32(bookId.Value));
        Suc.Visible = true;
        BindEmployeesData();

    }


    protected void SaveUpdates_Click(object sender, EventArgs e)
    {
        try
        {
            RettU.Text = "";
           
            var Ret = Obj.UpdateAdministration(EmpNameU.Value, Convert.ToInt32(SaveUpdates.CommandArgument), Convert.ToInt32(SectorU.SelectedValue) );


            if (Ret == 0)
            {
                RettU.Text = "اسم الإدارة متوسطة مسجل من قبل";

            }
            else
            {
                BindEmployeesData();
                LblEdit.Text = "";
                RettU.Text = ""; Suc.Visible = true;
                CloseAll();
                Main.Attributes.Remove("style");
                Main.Style.Add("display", "block");
            }



        }
        catch { }
    }



    protected void Edit_Command(object sender, CommandEventArgs e)
    {

        Suc.Visible = false;
        CloseAll();
        EmpNameU.Value = "";
        SectorU.SelectedValue = "";
        
        Updat.Attributes.Remove("style");
        Updat.Style.Add("display", "block");

       
        LblEdit.Text = "A";
        DataSet Ds = new DataSet();
        Ds = Obj.GetDataSetByID("GetAdministrationByID", Convert.ToInt32(e.CommandArgument));
        if (Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
        {


            foreach (DataRow Row in Ds.Tables[0].Rows)
            {
                SaveUpdates.CommandArgument = Convert.ToString(Row["AdmID"]);

                EmpNameU.Value = Convert.ToString(Row["AdmName"]);
               
                SectorU.SelectedValue = Convert.ToString(Row["Section"]);

               
            }

        }


    }


    protected void Admins_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Admins.SelectedValue != "")
        {
            NewReg.Visible = true;
            
            EmployeesData.DataSource = Obj.GetDataSetByID("GetAdministrations", Convert.ToInt32(Admins.SelectedValue));
            EmployeesData.DataBind();


        }
    }


    protected void EmployeesData_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        var ValidDelete = Obj.ExecuteProcedureID("CheckAdmin" , Convert.ToInt32(((LinkButton)e.Item.FindControl("Edit")).CommandArgument));

        if (ValidDelete == 1)
        {

            ((System.Web.UI.HtmlControls.HtmlGenericControl)(e.Item.FindControl("DelAllow"))).Visible = true;
            ((System.Web.UI.HtmlControls.HtmlGenericControl)(e.Item.FindControl("DisAllow"))).Visible = false;
        }
        else if (ValidDelete == 0)
        {

            ((System.Web.UI.HtmlControls.HtmlGenericControl)(e.Item.FindControl("DelAllow"))).Visible = false;
            ((System.Web.UI.HtmlControls.HtmlGenericControl)(e.Item.FindControl("DisAllow"))).Visible = true;
        }
    }

    private void CloseAll()
    {
        Main.Attributes.Remove("style");
        Main.Style.Add("display", "none");

        New.Attributes.Remove("style");
        New.Style.Add("display", "none");

        Updat.Attributes.Remove("style");
        Updat.Style.Add("display", "none");

        Admns.Attributes.Remove("style");
        Admns.Style.Add("display", "none");
    }
    protected void ClickNew_Click(object sender, EventArgs e)
    {
        CloseAll();
        EmpName.Value="";
        New.Attributes.Remove("style");
        New.Style.Add("display", "block");
    }
    protected void BackTables_Click(object sender, EventArgs e)
    {
        CloseAll();
        Main.Attributes.Remove("style");
        Main.Style.Add("display", "block");
    }

    protected void AdminView_Command(object sender, CommandEventArgs e)
    {
        CloseAll();
        Admns.Attributes.Remove("style");
        Admns.Style.Add("display", "block");

        DropEmployeesU.DataSource = Obj.GetDataSetByID("GetEmpNamesByAdm", Convert.ToInt32(e.CommandArgument));
        DropEmployeesU.DataTextField = "EmpName";
        DropEmployeesU.DataValueField = "EmpID";
        DropEmployeesU.DataBind();
        DropEmployeesU.Items.Insert(0, "");
        LblAdmID.Text = e.CommandArgument.ToString();
        FillManagers();
    }
    private void FillManagers()
    {
        RepManagers.DataSource = null;
        RepManagers.DataBind();

        RepManagers.DataSource = Obj.GetDataSetByID("GetAdminManagers", Convert.ToInt32(LblAdmID.Text));
        RepManagers.DataBind();
    }
   
    protected void DelManager_Click(object sender, ImageClickEventArgs e)
    {
        SucE.Visible = false;
        SucD.Visible = false;
        RettE.Text = "";

        var Res = Obj.ExecuteProcedureID("DelManger", Convert.ToInt32(DMang.Value));
        if (Res == 1)
        {
            FillManagers();
            SucD.Visible = true;
            DropEmployeesU.DataSource = Obj.GetDataSetByID("GetEmpNamesByAdm", Convert.ToInt32(LblAdmID.Text));
            DropEmployeesU.DataTextField = "EmpName";
            DropEmployeesU.DataValueField = "EmpID";
            DropEmployeesU.DataBind();
            DropEmployeesU.Items.Insert(0, "");
        }
        else
        {
            RettE.Text = " خطأ فى التنفيذ";
        }
    }

    protected void SaveManger_Click1(object sender, EventArgs e)
    {
        
            SucE.Visible = false;
            SucD.Visible = false;
            RettE.Text = "";
            var Res = Obj.ExecuteProcedure2ID("AssignAdminManager", Convert.ToInt32(DropEmployeesU.SelectedValue), Convert.ToInt32(LblAdmID.Text));
            if (Res != 0)
            {
                DropEmployeesU.DataSource = Obj.GetDataSetByID("GetEmpNamesByAdm", Convert.ToInt32(LblAdmID.Text));
                DropEmployeesU.DataTextField = "EmpName";
                DropEmployeesU.DataValueField = "EmpID";
                DropEmployeesU.DataBind();
                DropEmployeesU.Items.Insert(0, "");
                FillManagers();
                SucE.Visible = true;
            }
            else
            {
                RettE.Text = " خطأ فى التنفيذ";
            }
        

    }
}