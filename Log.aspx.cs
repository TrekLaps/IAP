using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Log : System.Web.UI.Page
{
    Operations Obj = new Operations();

    private void BindEmployeesData()
    {
        

            EmployeesData.DataSource = Obj.GetDataSet("GetLogTable");
            EmployeesData.DataBind();
        
       
    }
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {

            if (!IsPostBack)
            {

                if (Session["UData"] != null)
                {
                    DataSet MyRecDataSet = (DataSet)Session["UData"];

                    if ( Convert.ToBoolean(MyRecDataSet.Tables[0].Rows[0]["SystemAdmin"]) == true)
                    {
                        BindEmployeesData();

                        DropUsers.DataSource = Obj.GetDataSet("GetEmployees");

                        DropUsers.DataTextField = "EmpName";
                        DropUsers.DataValueField = "EmpID";
                        DropUsers.DataBind();
                        ListItem aa = new ListItem();
                        aa.Text = " الموظفين";
                        aa.Value = "0";

                        DropUsers.Items.Insert(0, aa);
                       

                        

                    }
                    else
                    {
                        Response.Redirect("NoPermissions.aspx");
                    }
                }

            }


        }
        catch { }
    }

    protected void DropUsers_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (DropUsers.SelectedValue != "0")
        {
            EmployeesData.DataSource = null;
            EmployeesData.DataBind();
            DataSet Ds = Obj.GetDataSetByID("GetLogTableByUser", Convert.ToInt32(DropUsers.SelectedValue));
            if (Ds.Tables[0].Rows.Count > 0)
            {
                LblData.Visible = false;
                EmployeesData.DataSource = Ds;
                EmployeesData.DataBind();
            }
            else
            {
                BindEmployeesData();
               
                LblData.Visible = true;
            }
        }


    }


}