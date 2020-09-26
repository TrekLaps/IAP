using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MainPage : System.Web.UI.Page
{
    Operations Obj = new Operations();
    protected void Page_Load(object sender, EventArgs e)
    {
        /// Log Data Start
        if (!IsPostBack)
        {
            if (Session["UData"] != null) // check if session is not null 
            {
                DataSet MyRecDataSet = (DataSet)Session["UData"];

                Obj.ExecuteProcedure("UpdateNoteStatus");

                Obj.ExecuteProcedureStringID("NewLogTable", Convert.ToInt32(MyRecDataSet.Tables[0].Rows[0]["EmpID"]), "Main Page");


                if (Convert.ToBoolean(MyRecDataSet.Tables[0].Rows[0]["SystemAdmin"]) == true)
                {

                    SubAdmins.Visible = true;
                }
                else
                {
                    SubAdmins.Visible = false;

                }
            }
        }

        /// Log Data End
    }
}