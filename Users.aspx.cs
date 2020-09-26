using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;

public partial class Users : System.Web.UI.Page
{
    Operations Obj = new Operations(); // Define an object fron class Operations.cs

    private void BindEmployeesData() // Bind the EmployeesData reapeterEmployees Data (Employees Data Grid)
    {

        EmployeesData.DataSource = Obj.GetDataSet("GetEmployees"); // Calling the function that returns the dataset fron Operations
        EmployeesData.DataBind();

        Sector.DataSource = Obj.GetDataSet("GetSections"); // Bind the Admins (Administrations) DropdownList
        Sector.DataTextField = "SectionName"; // Set the text in the dropdown list
        Sector.DataValueField = "SectionID"; // Set the value in the dropdown list
        Sector.DataBind();
        Sector.Items.Insert(0, "");

        DataSet DsG = Obj.GetDataSet("GetGover");

        if (DsG.Tables.Count > 0 && DsG.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow RowG in DsG.Tables[0].Rows)
            {
                EmpNameG.Value = Convert.ToString(RowG["EmpName"]);
                PassordG.Attributes.Add("value", Convert.ToString(RowG["EmpPassword"]));
                Passord2G.Attributes.Add("value", Convert.ToString(RowG["EmpPassword"]));
                SaveGov.CommandArgument = Convert.ToString(RowG["EmpID"]);
                EmpJobCodeG.Value = Convert.ToString(RowG["EmpJobCode"]);
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

                if (Convert.ToBoolean(MyRecDataSet.Tables[0].Rows[0]["SystemAdmin"]) == true)
                {
                    BindEmployeesData(); // Call the function for Binding the Admins (Administrations) DropdownList and EmployeesData reapeter(Employees Data)

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
            string imgPath = Img.Src; // Define the Employee Photo file

            if (FileUpload1.HasFiles)
            {
                //sets the image path
                var r = new Random();
                // print random integer >= 0 and  < 100


                imgPath = "Uploads/" + r.Next(100) + FileUpload1.FileName;

                //get the size in bytes that
                FileUpload1.SaveAs(Server.MapPath(imgPath));
            }
            // Call the function that Add new Employee 
            int Department = 0;
            if (Admins.SelectedValue != "")
            {
                Department = Convert.ToInt32(Admins.SelectedValue);
            }
            var Ret = Obj.NewEmployee(Convert.ToInt32(Sector.SelectedValue),  EmpName.Value, Email.Value, Department,UCode.Value, JobName.Value,imgPath, Passord.Value, AddReports.Checked, CheckAdmin.Checked ,CheckReciv.Checked);
            if (Ret == 0)
            {
                Rett.Text = "اسم المستخدم أو الإيميل مسجل من قبل";

            }
            else
            {


                Rett.Text = "";
                Suc.Visible = true; //Preview Success Message
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
        Obj.ExecuteProcedureID("DelEmployee", Convert.ToInt32(bookId.Value));
        Suc.Visible = true;
        BindEmployeesData();

    }


    protected void SaveUpdates_Click(object sender, EventArgs e) // Update Button
    {
        try
        {
            RettU.Text = "";
            string imgPath = Img1U.Src; // Define the updated Employee Photo

            if (FileUpload2.PostedFile.FileName.Length > 0)
            {
                //sets the image path
                var r = new Random();
                // print random integer >= 0 and  < 100


                imgPath = "Uploads/" + r.Next(100) + FileUpload2.FileName;

                //get the size in bytes that
                FileUpload2.SaveAs(Server.MapPath(imgPath));
            }

            int DepartmentU = 0;
            if (AdminsU.SelectedValue != "")
            {
                DepartmentU = Convert.ToInt32(AdminsU.SelectedValue);
            }

            // Update Employee by calling update function fro Operations.cs
            var Ret = Obj.UpdateEmployee(Convert.ToInt32(SectorU.SelectedValue), EmpNameU.Value, EmailU.Value, DepartmentU, UCodeEdt.Value, JobNameU.Value, imgPath, PassordU.Text, AddReportsU.Checked, Convert.ToInt32(SaveUpdates.CommandArgument), CheckAdminU.Checked, CheckRecivU.Checked);


            if (Ret == 0)
            {
                RettU.Text = "اسم المستخدم أو الإيميل مسجل من قبل";

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



    protected void Edit_Command(object sender, CommandEventArgs e) // Edit Button in Reapeater (Employees Data Grid)
    {
        CloseAll();
        LblCase.Text = "> تسجيل بيانات المستخدم  ";
        Updat.Attributes.Remove("style");
        Updat.Style.Add("display", "block");

        SectorU.DataSource = Obj.GetDataSet("GetSections"); // fill the AdminsU (Administrations Dropdownlist in Editing Window)
        SectorU.DataTextField = "SectionName";
        SectorU.DataValueField = "SectionID";
        SectorU.DataBind();
        SectorU.Items.Insert(0, "");
        LblEdit.Text = "";
        Suc.Visible = false;

        DataSet Ds = new DataSet();
        Ds = Obj.GetDataSetByID("GetEmployeeByID", Convert.ToInt32(e.CommandArgument)); // Get the data for the selected Employee
        if (Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
        {
            LblEdit.Text = "A"; // Have to set the Label with "A" to check in Javascript if ==A will open the editing window

            foreach (DataRow Row in Ds.Tables[0].Rows)
            {
                // Fill the Editig Feilds

                Img1U.Src = Convert.ToString(Row["EmpImg"]);

               
               

                AdminsU.DataSource = Obj.GetDataSetByID("GetAdministrations", Convert.ToInt32(Row["SectionID"])); // Bind the Admins (Administrations) DropdownList
                AdminsU.DataTextField = "AdmName"; // Set the text in the dropdown list
                AdminsU.DataValueField = "AdmID"; // Set the value in the dropdown list
                AdminsU.DataBind();
                AdminsU.Items.Insert(0, "");

                AdminsU.SelectedValue = Convert.ToString(Row["AdmID"]);


                EmpNameU.Value = Convert.ToString(Row["EmpName"]);
                PassordU.Attributes.Add("value", Convert.ToString(Row["EmpPassword"]));
                Passord2U.Attributes.Add("value", Convert.ToString(Row["EmpPassword"]));
                SaveUpdates.CommandArgument = Convert.ToString(Row["EmpID"]);
                //EmpJobCodeU.Value = Convert.ToString(Row["EmpJobCode"]);
                JobNameU.Value = Convert.ToString(Row["EmpJobTitle"]);
                EmailU.Value = Convert.ToString(Row["EmpEmail"]);
                AddReportsU.Checked = Convert.ToBoolean(Row["ApprovPermission"]);
                var a = Convert.ToString(Row["SectionID"]);
                SectorU.SelectedValue = Convert.ToString(Row["SectionID"]);

                AdminsU.SelectedValue = Convert.ToString(Row["AdmID"]);


                CheckRecivU.Checked = Convert.ToBoolean(Row["Reciv"]);
                CheckAdminU.Checked = Convert.ToBoolean(Row["SystemAdmin"]);
                  }


        }
        else
        {
            LblEdit.Text = "";
        }

    }





   

    protected void Sector_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Sector.SelectedValue != "")
        {
            Admins.DataSource = Obj.GetDataSetByID("GetAdministrations", Convert.ToInt32(Sector.SelectedValue)); // Bind the Admins (Administrations) DropdownList
            Admins.DataTextField = "AdmName"; // Set the text in the dropdown list
            Admins.DataValueField = "AdmID"; // Set the value in the dropdown list
            Admins.DataBind();
            Admins.Items.Insert(0, "");
        }
    }
    protected void SectorU_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (SectorU.SelectedValue != "")
        {
            AdminsU.DataSource = Obj.GetDataSetByID("GetAdministrations", Convert.ToInt32(SectorU.SelectedValue)); // Bind the Admins (Administrations) DropdownList
            AdminsU.DataTextField = "AdmName"; // Set the text in the dropdown list
            AdminsU.DataValueField = "AdmID"; // Set the value in the dropdown list
            AdminsU.DataBind();
            AdminsU.Items.Insert(0, "");
        }
    }
    protected void SaveGov_Click(object sender, EventArgs e)
    {
         
        try
        {
            Suc.Visible = false;
            
            if (EmpJobCodeG.Value != "")
            {
                if (SaveGov.CommandArgument == "" || Save.CommandArgument == null)
                {
                    var Ret = Obj.NewGover(EmpNameG.Value, EmailG.Value, EmpJobCodeG.Value, PassordG.Text);

                    if (Ret == 0)
                    {
                        RettG.Text = "البيانات مسجلة من قبل";

                    }
                    else
                    {

                        RettG.Text = "";
                        Suc.Visible = true;
                        SaveGov.CommandArgument = "";
                        BindEmployeesData();
                        CloseAll();
                        Main.Attributes.Remove("style");
                        Main.Style.Add("display", "block");

                    }
                }

                else
                {
                    var Ret = Obj.UpdateGover(EmpNameG.Value, EmailG.Value, EmpJobCodeG.Value, PassordG.Text ,Convert.ToInt32(SaveGov.CommandArgument));

                    if (Ret == 0)
                    {
                        RettG.Text = "البيانات مسجلة من قبل";

                    }
                    else
                    {

                        RettG.Text = "";
                        Suc.Visible = true;
                        SaveGov.CommandArgument = "";
                        BindEmployeesData();

                    }

                }
            }
        }
        catch { }
    

   
    }
    protected void DelGov_Click(object sender, EventArgs e)
    {
        if (SaveGov.CommandArgument != "" || Save.CommandArgument != null)
        {

            Suc.Visible = false;
            Obj.ExecuteProcedureID("DelEmployee", Convert.ToInt32(SaveGov.CommandArgument));
            Suc.Visible = true;
            BindEmployeesData();
            CloseAll();
            Main.Attributes.Remove("style");
            Main.Style.Add("display", "block");
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

        Gov.Attributes.Remove("style");
        Gov.Style.Add("display", "none");
    }
    protected void ClickNew_Click(object sender, EventArgs e)
    {
        LblCase.Text = "> تسجيل مستخدم جديد  ";
        CloseAll();
        EmpName.Value="";
        Email.Value="";
         //EmpJobCode.Value="";
        JobName.Value="";
        Passord.Value="";
        Admins.SelectedValue = "";
        AddReports.Checked = false;
        CheckAdmin.Checked=false ;
        CheckReciv.Checked=false;
           
        New.Attributes.Remove("style");
        New.Style.Add("display", "block");
    }
    protected void BackTables_Click(object sender, EventArgs e)
    {
        CloseAll();
        Main.Attributes.Remove("style");
        Main.Style.Add("display", "block");
    }

    protected void GovPermissions_Click(object sender, EventArgs e)
    {
        CloseAll();
        Gov.Attributes.Remove("style");
        Gov.Style.Add("display", "block");

    }
}