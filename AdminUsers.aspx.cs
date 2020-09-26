using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;

public partial class AdminUsers : System.Web.UI.Page
{
    Operations Obj = new Operations();

    private void BindEmployeesData()
    {
       
            EmployeesData.DataSource = Obj.GetDataSet("GetSystemAdmins");
            EmployeesData.DataBind();

        


    }
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            if (Session["UData"] != null)
            {
                DataSet MyRecDataSet = (DataSet)Session["UData"];

                if (Convert.ToBoolean(MyRecDataSet.Tables[0].Rows[0]["SystemAdmin"]) == true )
                {
                    EmployeesData.DataSource = Obj.GetDataSet("GetSystemAdmins");
                    EmployeesData.DataBind();

        
                    Sector.DataSource = Obj.GetDataSet("GetSections");
                    Sector.DataTextField = "SectionName";
                    Sector.DataValueField = "SectionID";
                    Sector.DataBind();
                    Sector.Items.Insert(0, "");

                }
                else
                {
                    Response.Redirect("NoPermissions.aspx");
                }
            }
        }
        
    }

    protected void Admins1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Admins1.SelectedValue != "")
        {
            DropNotAdmins.DataSource = Obj.GetDataSetByID("GetEmployeesNotAdmin", Convert.ToInt32(Admins1.SelectedValue));
            DropNotAdmins.DataTextField = "EmpName";
            DropNotAdmins.DataValueField = "EmpID";
            DropNotAdmins.DataBind();
            DropNotAdmins.Items.Insert(0, "");
        }
    }

    protected void Save_Click(object sender, EventArgs e)
    {
        try
        {
            Suc.Visible = false;

            if (DropNotAdmins.SelectedValue != "")
            {
                var Ret = Obj.ExecuteProcedureID("AddEmployeeAdmin", Convert.ToInt32(DropNotAdmins.SelectedValue));

                if (Ret == 0)
                {
                    Rett.Text = "هذا المستخدم مسجل مدير للنظام من قبل";

                }
                else
                {


                    Rett.Text = "";
                    Suc.Visible = true;
                    BindEmployeesData();

                }

            }
        }
        catch { }
    }
    protected void DelEmployee_Click(object sender, EventArgs e)
    {
        Suc.Visible = false;
        Obj.ExecuteProcedureID("DelEmployeeAdmin", Convert.ToInt32(bookId.Value));
        Suc.Visible = true;
        BindEmployeesData();

    }

    protected void Sector_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Sector.SelectedValue != "")
        {
            Admins1.DataSource = Obj.GetDataSetByID("GetAdministrations", Convert.ToInt32(Sector.SelectedValue));
            Admins1.DataTextField = "AdmName";
            Admins1.DataValueField = "AdmID";
            Admins1.DataBind();
            Admins1.Items.Insert(0, "");
        }
    }


    
}