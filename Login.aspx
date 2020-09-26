<%@ Page Language="C#" EnableEventValidation="false" AutoEventWireup="true" CodeFile="~/Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html lang="ar">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <link href="//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/css/bootstrap.min.css" rel="stylesheet" >
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/js/bootstrap.min.js"></script>
    <script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <!------ Include the above in your HEAD tag ---------->

    <title>منصة المراجعة الداخلية</title>
    <link href="assets/css/logincss/Login.css" rel="stylesheet" />

</head>
<body>
    <div id="login-container">
        <h3>بيانات حسابك</h3>
        <hr>
        <div class="container">
            <div class="row">
                <div class="col-12">
                    <form  runat="server" method="post">

                        <div class="input-group mb-3">
                            <div class="input-group-prepend">
                                <span class="input-group-text" id="email-label">
                                    <i class="fa fa-user-circle" aria-hidden="true"></i>
                                </span>
                            </div>
                            <input type="text" class="form-control"  runat="server" id="UserName"  value="admin" placeholder="ايميل أو اسم المستخدم " />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="UserName" runat="server" ValidationGroup="GL" ForeColor="#ff3c3c" ErrorMessage="*"></asp:RequiredFieldValidator>

                        </div>

                        <div class="input-group mb-3">
                            <div class="input-group-prepend">
                                <span class="input-group-text" id="password-label">
                                    <i class="fa fa-key" aria-hidden="true"></i>
                                </span>
                            </div>
                               <asp:TextBox ID="Password" TextMode="Password" CssClass="form-control input-lg" value="123" placeholder="كلمة المرور" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="Password" runat="server" ValidationGroup="GL" ForeColor="#ff3c3c" ErrorMessage="*"></asp:RequiredFieldValidator>
    </div>

                        <label class="container-checkbox">
                            تذكرنى
             
                            <input type="checkbox" checked="checked">
                            <span class="checkmark"></span>
                        </label>

                        <div class="text-center">
                           <asp:Label ID="notUser" Visible="false" ForeColor="Red" runat="server" Text="هذا المستخدم غير موجود أو ليس لديه صلاحيات"></asp:Label>

                            <div>
                                <asp:Button ID="Button1" OnClick="Login_Click" CssClass="btn btn-customized" runat="server" Text="تسجيل دخول" />
                            </div>
                        </div>

                    </form>
                </div>
            </div>
        </div>
    </div>
    



</body>
</html>
