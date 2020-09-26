using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Xml;

public partial class Login : System.Web.UI.Page
{
    Operations Obj = new Operations();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            Session.Clear(); // Reset Session

            if (Request.Cookies["UserInfo"] != null) // Check if cookies
            {

                UserName.Value = Request.Cookies["UserInfo"].Values.Get("UserMail");
                Password.Attributes.Add("value", Request.Cookies["UserInfo"].Values.Get("UserPWD"));

                //Rem.Checked = true;
            }
            LoginUsingWindowsAuthentications();
        }
    }
    protected void Login_Click(object sender, EventArgs e)
    {
        try
        {
            notUser.Visible = false;
            DataSet Ret = Obj.SignIn(UserName.Value, Password.Text); // Signin function from operatons
            if (Ret.Tables.Count > 0)
            {
                if (Ret.Tables[0].Rows.Count > 0)
                {
                    //   notUser.Visible = false; // Label preview errors

                    Session.Clear();

                    string Reg_Mail = UserName.Value;
                    string Reg_PWD = Password.Text;

                    Session["UData"] = Ret; // save the data set returned in session (contains EmpID ,EmpName , emp department ..)


                    //if (Rem.Checked == true) // if check Remember me create cookies
                    //{
                    //    HttpCookie RememberMe = new HttpCookie("UserInfo");
                    //    RememberMe.Values.Add("UserMail", Reg_Mail);
                    //    RememberMe.Values.Add("UserPWD", Reg_PWD);



                    //    RememberMe.Expires = DateTime.Now.AddDays(+30d);
                    //    Response.AppendCookie(RememberMe);
                    //}

                    //else
                    //{

                    if (Request.Cookies["UserInfo"] != null)  // else remove any existing cookies
                    {
                        HttpCookie myCookie = new HttpCookie("UserInfo");
                        myCookie.Expires = DateTime.Now.AddDays(-1d);
                        Response.Cookies.Add(myCookie);
                    }
                    //}
                    if (Request.QueryString["Url"] != null && Request.QueryString["Url"] != "") // check if there Login is come from a page (If some one tries to open a page without login by URL direct)
                    { Response.Redirect(Request.QueryString["Url"]); }

                    else
                    {
                        DataSet MyRecDataSet = (DataSet)Session["UData"];



                        //else if (Obj.ExecuteProcedureID("CheckSectionManger", Convert.ToInt32(MyRecDataSet.Tables[0].Rows[0]["EmpID"])) == 1)
                        //{

                        //    Response.Redirect("PieDashboard.aspx");
                        //}

                        Response.Redirect("mainpage.aspx");



                    }
                }
                else
                {
                    notUser.Visible = true;
                }
            }
            else
            {
                notUser.Visible = true;
            }
        }
        catch(Exception ex)
        {

        }
    }


    private void LoginUsingWindowsAuthentications()
    {
        try
        {
            //        string Username = System.Security.Principal.WindowsIdentity.GetCurrent().Name.ToString();
            string Username = "";

            try
            {
                Username = Context.User.Identity.Name.ToString();
                if (Username == "")
                    Username = System.Security.Principal.WindowsIdentity.GetCurrent().Name.ToString();
            }
            catch
            {
                Username = System.Security.Principal.WindowsIdentity.GetCurrent().Name.ToString();
            }

            string usernamevalue = Username.Substring(Username.LastIndexOf("\\") + 1);
           // usernamevalue = "seid";
          //  string Email = Username.Substring(Username.LastIndexOf("\\") + 1) + "@mail.com";
            
            DataSet Ret = Obj.SignInByUserName(usernamevalue); 

            if (Ret.Tables.Count > 0)
            {
                if (bool.Parse(Ret.Tables[0].Rows[0]["Active"].ToString()) == true)
                {
                    notUser.Visible = false; // Label preview errors

                    Session.Clear();

                    string Reg_Mail = UserName.Value;
                    string Reg_PWD = Password.Text;

                    Session["UData"] = Ret; 

                    if (Request.QueryString["Url"] != null && Request.QueryString["Url"] != "") 
                    { Response.Redirect(Request.QueryString["Url"]); }

                    else
                    { Response.Redirect("mainpage.aspx"); }
                }
                else
                {
                    Response.Redirect("NoPermissions.aspx");
                }
            }
            else
            {
                notUser.Visible = true;
            }
        }
        catch (Exception ex)
        {

        }


    }

}