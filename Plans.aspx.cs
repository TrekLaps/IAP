using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System;

public partial class Plans : System.Web.UI.Page
{
    Operations Obj = new Operations();

    private void BindEmployeesData()
    {
        EmployeesData.DataSource = Obj.GetDataSet("GetPlans");
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
                    BindEmployeesData();

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
    
    


    protected void SaveUpdates_Click(object sender, EventArgs e)
    {
        try
        {

            SucUpdate.Visible = false;


            var IDP = Obj.UpdatePlan(YearNameU.Value, Convert.ToInt32(SaveAllU.CommandArgument));
            if (IDP == -1)
            {
                RettU.Text = "الخطة مسجلة من قبل";
                YearNamU.Attributes.Remove("Style");
                YearNamU.Style.Add("display", "block");

                YearDetailsU.Attributes.Remove("Style");
                YearDetailsU.Style.Add("display", "none");
            }
            else
            {
                YearNamU.Attributes.Remove("Style");
                YearNamU.Style.Add("display", "none");

                YearDetailsU.Attributes.Remove("Style");
                YearDetailsU.Style.Add("display", "block");
            }

        }
        catch
        { }

    }



    protected void Edit_Command(object sender, CommandEventArgs e)
    {

        Suc.Visible = false;

        LblEdit.Text = "A";
        DataSet Ds = new DataSet();
        Ds = Obj.GetDataSetByID("GetPlanByID", Convert.ToInt32(e.CommandArgument));
        if (Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
        {


            foreach (DataRow Row in Ds.Tables[0].Rows)
            {
                SaveAllU.CommandArgument = Convert.ToString(Row["ID"]);

                YearNameU.Value = Convert.ToString(Row["YearName"]);

                SectionList2U.DataSource = Obj.GetDataSetByID("GetPlansSection", Convert.ToInt32(Row["ID"]));
                SectionList2U.DataBind();

            }

        }

        CloseOthers();
        UPDAT.Attributes.Remove("Style");
        UPDAT.Style.Add("display", "block");

    }
    protected void BackTables_Click(object sender, EventArgs e)
    {
        CloseOthers();
        MainTable.Attributes.Remove("Style");
        MainTable.Style.Add("display", "block");

    }

    protected void Admins_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Admins.SelectedValue != "")
        {
            chkAll.Visible = true;
            chkAll.Checked = false;
            PermChecks.DataSource = Obj.GetDataSetByID("GetAdministrations", Convert.ToInt32(Admins.SelectedValue));
            PermChecks.DataTextField = "AdmName"; // Set the text in the dropdown list
            PermChecks.DataValueField = "AdmID"; // Set the value in the dropdown list
            PermChecks.DataBind();

            PermChecks.Visible = true;


        }
    }




    protected void SectorU_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (SectorU.SelectedValue != "")
        {
            chkAllU.Visible = true;
            chkAllU.Checked = false;
            PermChecksU.DataSource = Obj.GetDataSetByID("GetAdministrations", Convert.ToInt32(SectorU.SelectedValue));
            PermChecksU.DataTextField = "AdmName"; // Set the text in the dropdown list
            PermChecksU.DataValueField = "AdmID"; // Set the value in the dropdown list
            PermChecksU.DataBind();

            PermChecksU.Visible = true;


        }
    }

    protected void SectionList_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
       

        if ((((Label)e.Item.FindControl("IDss")).Text != "") && (((Label)e.Item.FindControl("SectionI")).Text != ""))
        {

            ((Repeater)e.Item.FindControl("AdminList")).DataSource = Obj.GetPlansAdmins(Convert.ToInt32(((Label)e.Item.FindControl("Idss")).Text), Convert.ToInt32((((Label)e.Item.FindControl("SectionI")).Text)));


            ((Repeater)e.Item.FindControl("AdminList")).DataBind();
        }
    }
    protected void DelSection_Click(object sender, EventArgs e)
    {
        string[] Vall = bookSection.Value.Split(',');

        Suc.Visible = false;
        Obj.DelPlansSections(Convert.ToInt32(Vall[0]), Convert.ToInt32(Vall[1]));
        Suc.Visible = true;
        BindEmployeesData();
    }
    protected void DelAdmin_Click(object sender, EventArgs e)
    {
        Suc.Visible = false;
        Obj.ExecuteProcedureID("DelPlansByAdmin", Convert.ToInt32(bookAdmin.Value));
        Suc.Visible = true;
        BindEmployeesData();
    }
    protected void SectionList2_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if ((SaveAll.CommandArgument != "") && (((Label)e.Item.FindControl("SectionI")).Text != ""))
        {

            ((Repeater)e.Item.FindControl("AdminList")).DataSource = Obj.GetPlansAdmins(Convert.ToInt32(SaveAll.CommandArgument), Convert.ToInt32((((Label)e.Item.FindControl("SectionI")).Text)));


            ((Repeater)e.Item.FindControl("AdminList")).DataBind();
        }
    }


    protected void LinkButton1_Command(object sender, CommandEventArgs e)
    {
        string[] Vall = e.CommandArgument.ToString().Split(',');

        SucNew.Visible = false;
        Obj.DelPlansSections(Convert.ToInt32(Vall[0]), Convert.ToInt32(Vall[1]));
        SucNew.Visible = true;
        SectionList2.DataSource = Obj.GetDataSetByID("GetPlansSection", Convert.ToInt32(SaveAll.CommandArgument));
        SectionList2.DataBind();
        BindEmployeesData();
        LablSites.Text = "A";
    }
    protected void DelAdms_Command(object sender, CommandEventArgs e)
    {
        SucNew.Visible = false;
        Obj.ExecuteProcedureID("DelPlansByAdmin", Convert.ToInt32(e.CommandArgument));
        SucNew.Visible = true;
        SectionList2.DataSource = Obj.GetDataSetByID("GetPlansSection", Convert.ToInt32(SaveAll.CommandArgument));
        SectionList2.DataBind();
        BindEmployeesData();
        LablSites.Text = "A";
    }
   
    protected void SectionList2U_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if ((SaveAllU.CommandArgument != "") && (((Label)e.Item.FindControl("SectionI")).Text != ""))
        {

            ((Repeater)e.Item.FindControl("AdminListU")).DataSource = Obj.GetPlansAdmins(Convert.ToInt32(SaveAllU.CommandArgument), Convert.ToInt32((((Label)e.Item.FindControl("SectionI")).Text)));


            ((Repeater)e.Item.FindControl("AdminListU")).DataBind();
        }
    }
    protected void DelSectionU_Command(object sender, CommandEventArgs e)
    {
        string[] Vall = e.CommandArgument.ToString().Split(',');

        SucUpdate.Visible = false;
        Obj.DelPlansSections(Convert.ToInt32(Vall[0]), Convert.ToInt32(Vall[1]));
        SucUpdate.Visible = true;
        SectionList2U.DataSource = Obj.GetDataSetByID("GetPlansSection", Convert.ToInt32(SaveAllU.CommandArgument));
        SectionList2U.DataBind();
        BindEmployeesData();

        LblEdit.Text = "A";

    }
    protected void DelAdmsU_Command(object sender, CommandEventArgs e)
    {
        SucUpdate.Visible = false;
        Obj.ExecuteProcedureID("DelPlansByAdmin", Convert.ToInt32(e.CommandArgument));
        SucUpdate.Visible = true;
        SectionList2U.DataSource = Obj.GetDataSetByID("GetPlansSection", Convert.ToInt32(SaveAllU.CommandArgument));
        SectionList2U.DataBind();
        BindEmployeesData();
        LblEdit.Text = "A";
    }

    private void CloseOthers()
    {
        MainTable.Attributes.Remove("Style");
        MainTable.Style.Add("display", "none");

        NEW.Attributes.Remove("Style");
        NEW.Style.Add("display", "none");

        UPDAT.Attributes.Remove("Style");
        UPDAT.Style.Add("display", "none");

        UPDSecYear.Attributes.Remove("Style");
        UPDSecYear.Style.Add("display", "none");

        UPDAdmYear.Attributes.Remove("Style");
        UPDAdmYear.Style.Add("display", "none");

    }
    protected void NewPlan_Click(object sender, EventArgs e)
    {
        CloseOthers();
        NEW.Attributes.Remove("Style");
        NEW.Style.Add("display", "block");

    }
    protected void EmployeesData_ItemDataBound1(object sender, DataListItemEventArgs e)
    {
        if (((Label)e.Item.FindControl("IDs")).Text != "")
        {
            
            ((Repeater)e.Item.FindControl("SectionList")).DataSource = Obj.GetDataSetByID("GetPlansSection", Convert.ToInt32(((Label)e.Item.FindControl("IDs")).Text));

            ((Repeater)e.Item.FindControl("SectionList")).DataBind();
        }
    }

    
   
    protected void SecYear_Command(object sender, CommandEventArgs e)
    {
        CloseOthers();
        UPDSecYear.Attributes.Remove("Style");
        UPDSecYear.Style.Add("display", "block");
        SavePlanSection.CommandArgument = e.CommandArgument.ToString();
        string[] Vall = e.CommandArgument.ToString().Split(',');

        PlansSec.Items.Clear();

        PlansSec.DataSource = Obj.GetDataSetByID("GetPlansNotInSection" , Convert.ToInt32(Vall[0]));
        PlansSec.DataTextField = "YearName";
        PlansSec.DataValueField = "ID";
        PlansSec.DataBind();
        PlansSec.Items.Insert(0, "");
    }

    protected void AdmYear_Command(object sender, CommandEventArgs e)
    {
        CloseOthers();
        UPDAdmYear.Attributes.Remove("Style");
        UPDAdmYear.Style.Add("display", "block");


        SavePlanAdm.CommandArgument = e.CommandArgument.ToString();
        string[] Vall = e.CommandArgument.ToString().Split(',');

        PlansAdm.Items.Clear();

        PlansAdm.DataSource = Obj.GetDataSetBy2ID("GetPlansNotInAdmin", Convert.ToInt32(Vall[0]), Convert.ToInt32(Vall[2]));
        PlansAdm.DataTextField = "YearName";
        PlansAdm.DataValueField = "ID";
        PlansAdm.DataBind();
        PlansAdm.Items.Insert(0, "");
    }

   
    protected void PermChecksU_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(AddAllAdms.Checked==true)
        {
            AddAllAdms.Checked = false;
        }
    }

    protected void SavePlanSection_Click1(object sender, EventArgs e)
    {

            SucTransSec.Visible = false;
            LblSecTranfer.Text = "";
            string[] Vall = SavePlanSection.CommandArgument.ToString().Split(',');

            var Res = Obj.ExecuteProcedure3ID("TransferSectionYear", Convert.ToInt32(Vall[0]), Convert.ToInt32(Vall[1]), Convert.ToInt32(PlansSec.SelectedValue));
            if (Res != 0)
            {
                SucTransSec.Visible = true;

                CloseOthers();
                MainTable.Attributes.Remove("Style");
                MainTable.Style.Add("display", "block");
                LblSecTranfer.Text = PlansSec.SelectedItem.Text + " تم نقل الإدارة العليا واداراتها مع ملاحظاتها الى عام ";


                BindEmployeesData();


            }
            else
            {
                SucTransSec.Visible = false;
                BindEmployeesData();
            }

        

    }

    protected void SavePlanAdm_Click1(object sender, EventArgs e)
    {
       
            LblAdmTransfer.Text = "";
            SucTransAdm.Visible = false;

            string[] Vall = SavePlanAdm.CommandArgument.ToString().Split(',');

            var Res = Obj.ExecuteProcedure4ID("TransferAdminYear", Convert.ToInt32(Vall[0]), Convert.ToInt32(Vall[1]), Convert.ToInt32(PlansAdm.SelectedValue), Convert.ToInt32(Vall[2]));
            if (Res != 0)
            {
                CloseOthers();
                MainTable.Attributes.Remove("Style");
                MainTable.Style.Add("display", "block");
                LblAdmTransfer.Text = PlansAdm.SelectedItem.Text + " تم نقل الإدارة متوسطة مع ملاحظاتها الى عام ";
                SucTransAdm.Visible = true;
                BindEmployeesData();

            }
            else
            {
                SucTransAdm.Visible = false;
                BindEmployeesData();
            }

        

    }

   

    protected void SaveAllU_Click1(object sender, EventArgs e)
    {
        try
        {
            SucUpdate.Visible = false;

            if (SaveAllU.CommandArgument != "" && SaveAllU.CommandArgument != null && SaveAllU.CommandArgument != "0")
            {
                if (SectorU.SelectedValue != "")
                {
                    var Ret = 0;
                    if (AddAllAdms.Checked == true)
                    {
                        Ret = Obj.ExecuteProcedure2ID("NewPlansSectionsNoAdmins", Convert.ToInt32(SaveAllU.CommandArgument), Convert.ToInt32(SectorU.SelectedValue));
                    }
                    else
                    {
                        foreach (ListItem item in PermChecksU.Items)
                        {
                            if (item.Selected)
                            {
                                Ret = Obj.NewPlansSections(Convert.ToInt32(SaveAllU.CommandArgument), Convert.ToInt32(item.Value), Convert.ToInt32(SectorU.SelectedValue));

                            }
                        }
                    }

                    if (Ret != 0)
                    {
                        SectionList2U.DataSource = Obj.GetDataSetByID("GetPlansSection", Convert.ToInt32(SaveAllU.CommandArgument));
                        SectionList2U.DataBind();
                        RettU.Text = "";
                        SucNew.Visible = true;
                        BindEmployeesData();

                    }
                }
            }


        }
        catch { }
    }

    protected void SaveYear_Click1(object sender, EventArgs e)
    {
        try
        {

            SucNew.Visible = false;

            if (SaveAll.CommandArgument == "" || SaveAll.CommandArgument == null)
            {
                var IDP = Obj.NewPlan(YearNam.Value);
                if (IDP == -1)
                {
                    Rett.Text = "الخطة مسجلة من قبل";

                }
                else
                {
                    Rett.Text = "";
                    SaveAll.CommandArgument = IDP.ToString();
                    BindEmployeesData();
                }

                YearNam.Value = "";

            }

        }
        catch
        { }

    }

    protected void SaveAll_Click1(object sender, EventArgs e)
    {
        try
        {


            if (SaveAll.CommandArgument != "" && SaveAll.CommandArgument != null && SaveAll.CommandArgument != "0")
            {
                if (Admins.SelectedValue != "")
                {
                    var Ret = 0;
                    foreach (ListItem item in PermChecks.Items)
                    {
                        if (item.Selected)
                        {
                            Ret = Obj.NewPlansSections(Convert.ToInt32(SaveAll.CommandArgument), Convert.ToInt32(item.Value), Convert.ToInt32(Admins.SelectedValue));

                        }
                    }

                    if (Ret != 0)
                    {
                        SectionList2.DataSource = Obj.GetDataSetByID("GetPlansSection", Convert.ToInt32(SaveAll.CommandArgument));
                        SectionList2.DataBind();
                        Rett.Text = "";
                        SucNew.Visible = true;
                        BindEmployeesData();

                    }
                }
            }


        }
        catch { }
    }

    protected void DelEmployee_Click1(object sender, EventArgs e)
    {
        Suc.Visible = false;
        SucDel.Visible = false;
        Obj.ExecuteProcedureID("DelPlan", Convert.ToInt32(bookId.Value));
        SucDel.Visible = true;
        BindEmployeesData();
    }
}