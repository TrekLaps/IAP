using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Manual : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Operations Obj = new Operations();

            if (Session["UData"] != null)
            {
                DataSet MyRecDataSet = (DataSet)Session["UData"];
                if (Convert.ToBoolean(MyRecDataSet.Tables[0].Rows[0]["SystemAdmin"]) == true)
                {
                    Response.Redirect("mainpage.aspx");
                }
                else if (Convert.ToBoolean(MyRecDataSet.Tables[0].Rows[0]["Gov"]) == true)
                {
                    ifrm.Attributes["src"] = "Manuals/دليل المستخدم للنائب عام.pdf";

                }
                else if (Convert.ToBoolean(MyRecDataSet.Tables[0].Rows[0]["ApprovPermission"]) == true)
                {
                    ifrm.Attributes["src"] = "Manuals/دليل استخدام منصة الادارة العامة للمراجعة الداخلية (Final).pdf";
                }
                else if (Obj.ExecuteProcedureID("CheckSectionManger", Convert.ToInt32(MyRecDataSet.Tables[0].Rows[0]["EmpID"])) == 1)
                {
                    ifrm.Attributes["src"] = "Manuals/دليل المستخدم لوكلاء النائب عام.pdf";
                }
                else if (Obj.ExecuteProcedureID("CheckAdminManger", Convert.ToInt32(MyRecDataSet.Tables[0].Rows[0]["EmpID"])) == 1)
                {
                    ifrm.Attributes["src"] = "Manuals/دليل المستخدم مدراء الادارات.pdf";
                }
            }
        }
    }
}