<%@ Page Title=" المستخدمين " Language="C#" MasterPageFile="~/MasterPage.master" CodeFile="~/Users.aspx.cs" AutoEventWireup="true" EnableEventValidation="true" Inherits="Users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.min.js"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">

    <!-- page specific plugin styles -->
    <link rel="stylesheet" href="assets/css/jquery-ui.custom.min.css" />
    <link rel="stylesheet" href="assets/css/chosen.min.css" />
    <link rel="stylesheet" href="assets/css/bootstrap-datepicker3.min.css" />
    <link rel="stylesheet" href="assets/css/bootstrap-timepicker.min.css" />
    <link rel="stylesheet" href="assets/css/daterangepicker.min.css" />
    <link rel="stylesheet" href="assets/css/bootstrap-datetimepicker.min.css" />
    <link rel="stylesheet" href="assets/css/bootstrap-colorpicker.min.css" />

    <!-- page specific plugin styles -->
    <link rel="stylesheet" href="assets/css/jquery-ui.custom.min.css" />
    <link rel="stylesheet" href="assets/css/jquery.gritter.min.css" />
    <link rel="stylesheet" href="assets/css/bootstrap-multiselect.min.css" />
    <link rel="stylesheet" href="assets/css/select2.min.css" />
    <style>
        .Lst li {
            border-bottom: 1px dashed green;
            vertical-align: top;
        }

      
    </style>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="PageTitle" runat="Server">
    المستخدمين 
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" runat="Server">
    <h3>
        المستخدمين
        <asp:Label ID="LblCase" runat="server" Text=""></asp:Label></h3>
    <div class="MainBox">
        <div class="row" id="Main" runat="server">

            <div class="col-xs-12">



                <div class="row">
                    <div class="col-xs-3">
                        <h4 class="pink" style="float: right;">
                            <asp:LinkButton ID="LinkButton2" CssClass="btn btn-purple large white" OnClick="ClickNew_Click" runat="server"> تسجيل مستخدم جديد</asp:LinkButton>
                        </h4>
                    </div>

                    <div class="col-xs-3">
                        <div id="Suc" runat="server" visible="false" class="alert alert-block alert-success">
                            <strong>
                                <i class="ace-icon fa fa-check-square-o icon-only bigger-150"></i>                                
                                تم الحفظ !
                            </strong>

                        </div>
                    </div>



                    <div class="col-xs-3">
                        <h4 class="pink" style="float: left;display:none;">

                            <asp:LinkButton ID="GovPermissions" OnClick="GovPermissions_Click" runat="server">تحديد صلاحية النائب عام</asp:LinkButton>

                        </h4>
                    </div>

                </div>

                <!-- div.table-responsive -->

                <!-- div.dataTables_borderWrap -->
                <div>
                    <table id="dynamic-table" class=" table-bordered">
                        <thead class="TableHead">
                            <tr>


                                <th class="center">اسم الموظف
                                                                             
                                </th>
                                <th class="center">الإدارة العليا

                                </th>
                                <th class="center">الإدارة متوسطة
                                                                            
                                                                      
                                </th>
                                <th class="center">صلاحيات 
                                       
                                </th>



                                <th class="center"></th>
                            </tr>
                        </thead>

                        <tbody>
                            <asp:Repeater ID="EmployeesData" runat="server">
                                <ItemTemplate>

                                    <tr>
                                        <td class="center">
                                            <%--  <asp:Image ID="Image1" Width="70px" Height="70px" ImageUrl='<%# Eval("EmpImg") %>' runat="server" />
                                        <hr class="center" style="margin-top: 1px; margin-bottom: 1px; border-top: 1px solid #6ad589;" />--%>

                                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("EmpName") %>'></asp:Label>

                                        </td>

                                        <td class="center">
                                            <asp:Label ID="Label9" runat="server" Text='<%# Eval("SectionName") %>'></asp:Label>
                                        </td>
                                        <td class="center">


                                            <asp:Label ID="Label5" runat="server" Text='<%# Eval("AdmName") %>'></asp:Label>
                                        </td>

                                        <td class="center">


                                            <span class="badge badge-pill badge-warning" visible='<%#Convert.ToBoolean(Eval("SystemAdmin"))?false:true%>'>إدارة النظام</span>
                                            <span class="badge badge-pill badge-info" visible='<%#Convert.ToBoolean(Eval("ApprovPermission"))?false:true%>'>إدارة الملاحظات</span>



                                        </td>


                                        <td class="center">
                                            <asp:LinkButton CssClass="green" data-rel="tooltip" title="تعديل" ID="Edit" CommandArgument='<%# Eval("EmpID") %>' OnCommand="Edit_Command" runat="server">
                                            
                                            <span class="ace-icon fa fa-pencil icon-only bigger-120">&nbsp;</span></asp:LinkButton>
                                            <!--Open Dlete Employee PUP-->
                                            <a class="red" role='button' data-rel="tooltip" title="حذف" href='#Del_modal' data-toggle='modal' data-book-id='<%# Eval("EmpID") %>'>
                                                <i class="fa fa-close icon-only bigger-120"></i>

                                                <span class='hidden'>حذف</span>
                                            </a>
                                            </div>

                                                
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                </div>
            </div>


            
        </div>


        <!-- New Emloyee PUP -->
        <div id="New" class="row" runat="server" style="display: none;">



            <div>

                <div class="row">
                    <div class="col-md-10" style="margin-top: 27px;">

                        <div class="col-md-12">

                            <div class="form-group">
                                <label class="col-sm-2 control-label" for="form-field-1">الإسم </label>

                                <div class="col-sm-4">
                                    <input runat="server" type="text" id="EmpName" placeholder="اسم الموظف" class="form-control text col-xs-10 col-sm-10" />

                                    <span>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="EmpName" runat="server" ValidationGroup="G" ForeColor="Red" ErrorMessage="اسم الموظف مطلوب  *"></asp:RequiredFieldValidator></span>
                                </div>
                                <div class="form-group">
                                    <label class="col-sm-2 control-label" for="form-field-1">المسمى الوظيفى </label>

                                    <div class="col-sm-4">
                                        <input runat="server" type="text" id="JobName" placeholder="المسمى الوظيفة" class="form-control text col-xs-10 col-sm-10" />

                                        <span>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="JobName" runat="server" ValidationGroup="G" ForeColor="Red" ErrorMessage="اسم الوظيفة مطلوب  *"></asp:RequiredFieldValidator></span>
                                    </div>


                                </div>

                            </div>


                        </div>



                        <div class="col-xs-12 col-sm-12">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="form-field-1">الإدارة العليا </label>

                                        <div class="col-sm-4">


                                           <div>
                                                <asp:DropDownList class="chosen-select chosen-rtl form-control" name="dept" ID="Sector" AutoPostBack="true" OnSelectedIndexChanged="Sector_SelectedIndexChanged" runat="server" data-placeholder="الإدارة العليا">
                                                </asp:DropDownList>
                                            </div>


                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" ControlToValidate="Sector" InitialValue=" " runat="server" ValidationGroup="G" ForeColor="Red" ErrorMessage="الإدارة العليا مطلوب *"></asp:RequiredFieldValidator>

                                        </div>
                                        <label class="col-sm-2 control-label" for="form-field-1">الإدارة متوسطة  </label>

                                        <div class="col-sm-4">


                                           <div>
                                                <asp:DropDownList class="chosen-select chosen-rtl form-control" name="dept" ID="Admins" runat="server" data-placeholder="الإدارة متوسطة">
                                                </asp:DropDownList>
                                            </div>





                                        </div>


                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>

                        </div>


                        <div class="col-xs-12 col-sm-12">

                            <label class="col-sm-2 control-label">اسم المستخدم  </label>

                            <div class="col-sm-4">

                                <input runat="server" placeholder="اسم المستخدم" class="form-control text" type="text" id="UCode" />
                            </div>
                            <label class="col-sm-2 control-label" for="form-field-1">البريد الألكترونى </label>

                            <div class="col-sm-4" style="direction: ltr;">

                                <input runat="server" placeholder="الإيميل" class="form-control text" type="Email" id="Email" />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ValidationGroup="G" ForeColor="Red" ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$" ControlToValidate="Email" runat="server" ErrorMessage="الإيميل غير صحيح"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class="col-xs-12 col-sm-12">
                            <label class="col-sm-2 control-label" for="form-field-1">كلمة المرور </label>

                            <div class="col-sm-4">

                                <input runat="server" placeholder="كلمة المرور" class="form-control text" type="password" id="Passord" />

                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="Passord" runat="server" ValidationGroup="G" ForeColor="Red" ErrorMessage="كلمة المرور مطلوبة  *"></asp:RequiredFieldValidator>
                            </div>


                            <label class="col-sm-2 control-label" for="form-field-1">اعادة كلمة المرور</label>

                            <div class="col-sm-4">
                                <input runat="server" placeholder="اعادة كلمة المرور" class="form-control text" type="password" id="Passord2" />

                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="Passord2" runat="server" ValidationGroup="G" ForeColor="Red" ErrorMessage="اعادة كلمة المرور مطلوبة *"></asp:RequiredFieldValidator>


                            </div>







                            <div class="col-xs-12 col-sm-12">
                                <div class="form-group">
                                    <label class="col-sm-2 control-label">الصلاحيات</label>
                                    <div class="col-sm-10" style="background-color: #FFF; border: 1px solid #d2d9d9">
                                        <div class="col-sm-12">
                                            <label>
                                                <input runat="server" id="AddReports" type="checkbox" />
                                                <span class="lbl">إدارة الملاحظات</span>
                                            </label>
                                        </div>


                                        <div class="col-sm-12">
                                            <label>
                                                <input runat="server" id="CheckAdmin" type="checkbox" />
                                                <span class="lbl">صلاحيةادارةالنظام</span>
                                            </label>
                                        </div>


                                        <div class="col-sm-12">
                                            <label>
                                                <input runat="server" id="CheckReciv" type="checkbox" />
                                                <span class="lbl">استلام الملاحظات والتوصيات</span>
                                            </label>
                                        </div>

                                    </div>
                                </div>

                            </div>

                        </div>

                    </div>
                    <div class="col-md-2" style="display: none;">
                        <label class="col-sm-12 control-label" for="form-field-1">صورة شخصية</label>


                        <div class="widget-body">
                            <div class="widget-main">


                                <div class="form-group">
                                    <div class="col-xs-12">
                                        <div style="width: 150px; height: 170px; border: dashed 1px gray; background: #d8e1e1;">
                                            <img class="img" runat="server" id="Img" width="150" height="170" />

                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-xs-12">
                                        <asp:FileUpload ID="FileUpload1" accept="image/*" multiple="false" runat="server" CssClass="file2" />

                                    </div>
                                </div>

                                <div>
                                    <label id="ValidatFile" style="color: red;" />
                                </div>
                            </div>
                        </div>
                    </div>

                </div>


                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ControlToValidate="Email" runat="server" ValidationGroup="G" ForeColor="Red" ErrorMessage="مطلوب الايميل  *"></asp:RequiredFieldValidator>

                <asp:CompareValidator ID="CompareValidator1" ForeColor="Red" ControlToValidate="Passord2" ControlToCompare="Passord" Operator="Equal" ValidationGroup="G" runat="server" ErrorMessage="يجب أن تكون كلمة المرور هى نفس الكلمة التى أدخلت من قبل"></asp:CompareValidator>

                <div class="modal-footer">
                    <asp:Label ID="Rett" runat="server" Text="" CssClass="Rett" ForeColor="red"></asp:Label>
                    <asp:Button ID="Save" OnClick="Save_Click" ValidationGroup="G" CssClass="btn btn-success white" runat="server" Text="تسجيل" />
                    



                </div>
            </div>
            <asp:LinkButton ID="LinkButton3" runat="server" OnClick="BackTables_Click" Style="float: left; margin-top: -10px;"><i class="ace-icon fa fa-arrow-left icon-only purple bigger-250"></i></asp:LinkButton>

        </div>

        <!-- New Emloyee Gover -->
        <div class="row" id="Gov" style="display: none;" runat="server">


            <div class="modal-header">
                <h4 class="blue bigger">صلاحية النائب عام</h4>
            </div>

            <div style="background-color: #FFFFFF;">
                <div class="form-horizontal" role="form">
                    <div style="min-height: 300px;">

                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                            <ContentTemplate>
                                <div class="form-group" style="margin-top: 27px;">
                                    <div class="row">
                                        <div class="col-xs-12">
                                            <h3>
                                                

                                            <div class="row">
                                                <div class="col-sm-6">
                                                    <label class="col-sm-2 control-label" for="form-field-1">الاسم</label>
                                                    <div class="col-sm-4">
                                                        <input runat="server" type="text" id="EmpNameG" placeholder="الاسم" class="form-control text col-xs-10 col-sm-10" />

                                                        <span>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator17" ControlToValidate="EmpNameG" runat="server" ValidationGroup="GG" ForeColor="Red" ErrorMessage="اسم الموظف مطلوب  *"></asp:RequiredFieldValidator></span>
                                                    </div>
                                                </div>
                                                <div class="col-sm-6">
                                                    <label class="col-sm-2 control-label" for="form-field-1">الرقم الوظيفي</label>

                                                    <div class="col-sm-4">
                                                        <input runat="server" type="text" id="EmpJobCodeG" placeholder="الرقم الوظيفي" class="form-control text col-xs-10 col-sm-10" />
                                                    </div>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator18" ControlToValidate="EmpJobCodeG" runat="server" ValidationGroup="GG" ForeColor="Red" ErrorMessage="الرقم الوظيفي مطلوب  *"></asp:RequiredFieldValidator>
                                                </div>


                                            </div>
                                            <div class="row">


                                                <div class="col-xs-12 col-sm-12">


                                                    <div class=" col-sm-6">
                                                        <div class="row">
                                                            <label class="col-sm-3 control-label" for="form-field-1">كلمة المرور </label>

                                                            <div class="col-sm-4">
                                                                <asp:TextBox placeholder="كلمة المرور" CssClass="form-control text" type="password" ID="PassordG" runat="server"></asp:TextBox>

                                                            </div>
                                                            <div class="col-sm-3">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator19" ControlToValidate="PassordG" runat="server" ValidationGroup="GG" ForeColor="Red" ErrorMessage="كلمة المرور مطلوبة  *"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>
                                                        <div class="row" style="padding-top: 5px;">
                                                            <label class="col-sm-3 control-label" for="form-field-1">اعادة كلمة المرور</label>

                                                            <div class="col-sm-4">
                                                                <asp:TextBox placeholder="كلمة المرور" CssClass="form-control text" type="password" ID="Passord2G" runat="server"></asp:TextBox>
                                                            </div>
                                                            <div class="col-sm-3">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator20" ControlToValidate="Passord2G" runat="server" ValidationGroup="GG" ForeColor="Red" ErrorMessage="اعادة كلمة المرور مطلوبة *"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>
                                                        <asp:CompareValidator ID="CompareValidator3" ForeColor="Red" ControlToValidate="Passord2G" ControlToCompare="PassordG" Operator="Equal" ValidationGroup="GG" runat="server" ErrorMessage="يجب أن تكون كلمة المرور هى نفس الكلمة التى أدخلت من قبل"></asp:CompareValidator>
                                                    </div>


                                                    <div class="col-sm-6">
                                                        <label class="col-sm-3 control-label" for="form-field-1">البريد الألكترونى </label>

                                                        <div class="col-sm-4">

                                                            <input runat="server" placeholder="الإيميل" class="form-control text" type="Email" id="EmailG" />
                                                        </div>
                                                        <div class="col-sm-3">

                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ValidationGroup="GG" ForeColor="Red" ValidationExpression="^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$" ControlToValidate="EmailG" runat="server" ErrorMessage="الإيميل غير صحيح"></asp:RegularExpressionValidator>

                                                        </div>

                                                    </div>
                                                </div>



                                            </div>
                                        </div>


                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="modal-footer">
                        <asp:Label ID="RettG" runat="server" Text="" CssClass="Rett" ForeColor="red"></asp:Label>
                        <asp:LinkButton ID="SaveGov" CssClass="btn btn-sm btn-primary" OnClick="SaveGov_Click" ValidationGroup="GG" runat="server"> <i class="ace-icon fa fa-check-square-o icon-only bigger-150"></i>
                        حفظ</asp:LinkButton>


                        <asp:LinkButton ID="LinkButton7" CssClass="btn btn-sm btn-danger" runat="server" OnClick="BackTables_Click"><i class="ace-icon fa fa-times"></i> الغاء</asp:LinkButton>

                    </div>

                </div>
            </div>
            <asp:LinkButton ID="LinkButton6" runat="server" OnClick="BackTables_Click" Style="float: left; margin-top: -10px;"><i class="ace-icon fa fa-arrow-left icon-only purple bigger-250"></i></asp:LinkButton>

        </div>


        <!---------------------------------->
        <div class="row" id="Updat" style="display: none;" runat="server">


            <div class="row">
                <div class="col-md-10" style="margin-top: 27px;">
                    <div class="col-md-12">


                        <div class="form-group">
                            <label class="col-sm-2 control-label" for="form-field-1">الإسم </label>

                            <div class="col-sm-4">
                                <input runat="server" type="text" id="EmpNameU" placeholder="اسم الموظف" class="form-control text col-xs-10 col-sm-10" />

                                <span>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="EmpNameU" runat="server" ValidationGroup="GU" ForeColor="Red" ErrorMessage="اسم الموظف مطلوب  *"></asp:RequiredFieldValidator></span>
                            </div>


                        </div>
                        <div class="form-group">
                            <label class="col-sm-2 control-label" for="form-field-1">المسمى الوظيفى </label>

                            <div class="col-sm-4">
                                <input runat="server" type="text" id="JobNameU" placeholder=" المسمى الوظيفى" class="form-control text col-xs-10 col-sm-10" />

                                <span>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="JobNameU" runat="server" ValidationGroup="GU" ForeColor="Red" ErrorMessage="اسم الوظيفة مطلوب  *"></asp:RequiredFieldValidator></span>
                            </div>


                        </div>

                    </div>

                    <div class="col-md-12">
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                <div class="form-group">
                                    <label class="col-sm-2 control-label" for="form-field-1">الإدارة العليا</label>

                                    <div class="col-sm-4">


                                       <div>
                                            <asp:DropDownList class="chosen-select chosen-rtl form-control" name="dept" ID="SectorU" AutoPostBack="true" OnSelectedIndexChanged="SectorU_SelectedIndexChanged" runat="server" data-placeholder="الإدارة العليا">
                                            </asp:DropDownList>
                                        </div>


                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" ControlToValidate="SectorU" InitialValue=" " runat="server" ValidationGroup="GU" ForeColor="Red" ErrorMessage="الإدارة العليا مطلوب *"></asp:RequiredFieldValidator>

                                    </div>
                                    <label class="col-sm-2 control-label" for="form-field-1">الإدارة متوسطة   </label>

                                    <div class="col-sm-4">


                                       <div>
                                            <asp:DropDownList class="chosen-select chosen-rtl form-control" name="dept" ID="AdminsU" runat="server" data-placeholder="الإدارة متوسطة">
                                            </asp:DropDownList>
                                        </div>






                                    </div>



                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>






                    <div class="col-xs-12 col-sm-12">
                        <label class="col-sm-2 control-label">اسم المستخدم  </label>

                        <div class="col-sm-4">

                            <input runat="server" placeholder="اسم المستخدم" class="form-control text" type="text" id="UCodeEdt" />
                        </div>
                        <label class="col-sm-2 control-label" for="form-field-1">البريد الألكترونى </label>

                        <div class="col-sm-2" style="direction: ltr;">

                            <input runat="server" placeholder="الإيميل" class="form-control text" type="Email" id="EmailU" />
                        </div>

                    </div>
                    <div class="col-xs-12 col-sm-12">
                        <label class="col-sm-2 control-label" for="form-field-1">كلمة المرور </label>

                        <div class="col-sm-2">
                            <asp:TextBox placeholder="كلمة المرور" CssClass="form-control text" type="password" ID="PassordU" runat="server"></asp:TextBox>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" ControlToValidate="PassordU" runat="server" ValidationGroup="GU" ForeColor="Red" ErrorMessage="كلمة المرور مطلوبة  *"></asp:RequiredFieldValidator>
                        </div>

                        <label class="col-sm-2 control-label" for="form-field-1">اعادة كلمة المرور</label>

                        <div class="col-sm-2">
                            <asp:TextBox placeholder=" اعادة كلمة المرور" CssClass="form-control text" type="password" ID="Passord2U" runat="server"></asp:TextBox>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator16" ControlToValidate="Passord2U" runat="server" ValidationGroup="GU" ForeColor="Red" ErrorMessage="اعادة كلمة المرور مطلوبة *"></asp:RequiredFieldValidator>
                        </div>



                    </div>




                    <div class="col-xs-12 col-sm-12">
                        <label class="col-sm-2 control-label">الصلاحيات</label>
                        <div class="col-sm-10" style="background-color: #FFF; border: 1px solid #d2d9d9">

                            <div class="col-sm-12">
                                <label>
                                    <input runat="server" id="AddReportsU" type="checkbox" />
                                    <span class="lbl">إدارة الملاحظات</span>
                                </label>
                            </div>


                            <div class="col-sm-12">
                                <label>
                                    <input runat="server" id="CheckAdminU" type="checkbox" />
                                    <span class="lbl">ادارة النظام</span>
                                </label>
                            </div>


                            <div class="col-sm-12">
                                <label>
                                    <input runat="server" id="CheckRecivU" type="checkbox" />
                                    <span class="lbl">استلام الملاحظات والتوصيات</span>
                                </label>
                            </div>

                        </div>
                    </div>
                </div>

                <div class="col-md-2" style="display: none;">
                    <label class="col-sm-12 control-label" for="form-field-1">صورة شخصية</label>


                    <div class="widget-body">
                        <div class="widget-main">


                            <div class="form-group">
                                <div class="col-xs-12">
                                    <div style="width: 150px; height: 170px; border: dashed 1px gray; background: #d8e1e1;">
                                        <img class="img" runat="server" id="Img1U" width="150" height="170" />

                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-xs-12">
                                    <asp:FileUpload ID="FileUpload2" accept="image/*" multiple="false" runat="server" CssClass="file2" />

                                </div>
                            </div>

                            <div>
                                <label id="ValidatFileU" style="color: red;" />
                            </div>
                        </div>
                    </div>
                </div>

            </div>
            <div class="modal-footer">
                <asp:CompareValidator ID="CompareValidator2" ForeColor="Red" ControlToValidate="Passord2U" ControlToCompare="PassordU" Operator="Equal" ValidationGroup="GU" runat="server" ErrorMessage="يجب أن تكون كلمة المرور هى نفس الكلمة التى أدخلت من قبل"></asp:CompareValidator>

                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ValidationGroup="GU" ForeColor="Red" ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$" ControlToValidate="EmailU" runat="server" ErrorMessage="الإيميل غير صحيح"></asp:RegularExpressionValidator>

                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ControlToValidate="EmailU" runat="server" ValidationGroup="GU" ForeColor="Red" ErrorMessage="كلمة المرور مطلوبة  *"></asp:RequiredFieldValidator>

                <asp:Label ID="RettU" runat="server" Text="" CssClass="Rett" ForeColor="red"></asp:Label>

                <asp:Button ID="SaveUpdates" OnClick="SaveUpdates_Click" ValidationGroup="GU" CssClass="btn btn-success white" runat="server" Text="حفظ" />
                 
            </div>
            <div>
                <asp:LinkButton ID="BackTables" runat="server" OnClick="BackTables_Click" Style="float: left; margin-top: -10px;"><i class="ace-icon fa fa-arrow-left icon-only purple bigger-250"></i></asp:LinkButton>
            </div>
        </div>

        <!-- Delete PUP-->

        <!-- The Modal -->
        <div class="modal" id="Del_modal" style="top: 25%;">
            <div class="modal-dialog">
                <div class="modal-content">

                    <!-- Modal Header -->
                    <div class="modal-header">
                        <h4 class="modal-title">حذف</h4>
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                    </div>

                    <!-- Modal body -->
                    <div class="modal-body">
                        <input style="display: none" type="text" runat="server" name="bookId" id="bookId" value="" />
                        <h3>..سوف يتم حذف المستخدم </h3>
                    </div>

                    <!-- Modal footer -->
                    <div class="modal-footer">
                        <asp:Button ID="Button1" CssClass="btn btn-purple btn-lg " OnClick="DelEmployee_Click" runat="server" Text="تأكيد الحذف" />
                    </div>

                </div>
            </div>
        </div>



        <asp:Label ID="LablSites" Style="display: none;" runat="server" Text=""></asp:Label>

        <asp:Label ID="LblEdit" Style="display: none;" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Javascript" runat="Server">

    <!-- page specific plugin scripts -->
    <script src="assets/js/jquery.dataTables.min.js"></script>
    <script src="assets/js/jquery.dataTables.bootstrap.min.js"></script>
    <script src="assets/js/dataTables.buttons.min.js"></script>
    <script charset="UTF-8" src="assets/js/JSAllmin.js"></script>
    <script charset="UTF-8" src="assets/js/JSZip.js"></script>
    <script src="assets/js/buttons.html5.min.js"></script>
    <script src="assets/js/buttons.print.min.js"></script>
    <script src="assets/js/buttons.colVis.min.js"></script>
    <script src="assets/js/dataTables.select.min.js"></script>
    <!-- page specific plugin scripts -->

    <!--[if lte IE 8]>
		  <script src="assets/js/excanvas.min.js"></script>
		<![endif]-->
    <script src="assets/js/jquery-ui.custom.min.js"></script>
    <script src="assets/js/jquery.ui.touch-punch.min.js"></script>
    <script src="assets/js/bootbox.js"></script>
    <script src="assets/js/jquery.gritter.min.js"></script>
    <script src="assets/js/jquery-ui.custom.min.js"></script>
    <script src="assets/js/jquery.ui.touch-punch.min.js"></script>
    <script src="assets/js/chosen.jquery.min.js"></script>

    <script src="assets/js/jquery.knob.min.js"></script>
    <script src="assets/js/autosize.min.js"></script>
    <script src="assets/js/jquery.inputlimiter.min.js"></script>
    <script src="assets/js/jquery.maskedinput.min.js"></script>
    <script src="assets/js/bootstrap-tag.min.js"></script>
    <script src="assets/js/bootstrap-multiselect.min.js"></script>

    <!-- inline scripts related to this page -->
    <script type="text/javascript">
        // Execute Javascript in Refresh page
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        if (prm != null) {
            prm.add_endRequest(function (sender, e) {
                if (sender._postBackSettings.panelsToUpdate != null) {
                    DisplayCurrentTime();
                }
            });
        };

        function DisplayCurrentTime() {
            $("body").removeAttr("style");

            $('#Del_modal').on('show.bs.modal', function (e) {
                var bookId = $(e.relatedTarget).data('book-id');

                // Set bookId label equal the Employee ID when Opening the Delete PUP to be using in server side
                $(e.currentTarget).find($("#<%=bookId.ClientID%>")).val(bookId);


            });

            $('.file2U, .file2').ace_file_input({
                no_file: 'No File ...',
                btn_choose: 'Choose',
                btn_change: 'Change',
                droppable: false,
                onchange: null,
                thumbnail: false, //| true | large
                whitelist: 'gif|png|jpg|jpeg'
                , blacklist: 'exe|php'
                //onchange:''
                //
            });






            if (!ace.vars['touch']) {
                $('.chosen-select').chosen({ allow_single_deselect: true });
                //resize the chosen on window resize

                $(window)
                    .off('resize.chosen')
                    .on('resize.chosen', function () {
                        $('.chosen-select').each(function () {
                            var $this = $(this);
                            $this.next().css({ 'width': $this.parent().width() });
                        })
                    }).trigger('resize.chosen');
                //resize chosen on sidebar collapse/expand
                $(document).on('settings.ace.chosen', function (e, event_name, event_val) {
                    if (event_name != 'sidebar_collapsed') return;
                    $('.chosen-select').each(function () {
                        var $this = $(this);
                        $this.next().css({ 'width': $this.parent().width() });
                    })
                });


                $('#chosen-multiple-style .btn').on('click', function (e) {
                    var target = $(this).find('input[type=radio]');
                    var which = parseInt(target.val());
                    if (which == 2) $('#form-field-select-4').addClass('tag-input-style');
                    else $('#form-field-select-4').removeClass('tag-input-style');
                });
            }
            $('.file2').change(function (event) {
                var tmppath = URL.createObjectURL(event.target.files[0]);
                $(".img").fadeIn("fast").attr('src', URL.createObjectURL(event.target.files[0]));
                $("#ValidatFile").text(' ');

                var ext = $('.file2').val().split('.').pop().toLowerCase();
                if ($.inArray(ext, ['gif', 'png', 'jpg', 'jpeg']) == -1) {
                    $("#ValidatFile").text("يجب أن تختار ملف صورة");
                    $('.file2').prop('value', '');
                }


            });

            $('.file2').ace_file_input({
                no_file: 'No File ...',
                btn_choose: 'Choose',
                btn_change: 'Change',
                droppable: false,
                onchange: null,
                thumbnail: false, //| true | large
                whitelist: 'gif|png|jpg|jpeg'
                , blacklist: 'exe|php'
                //onchange:''
                //
            });

        }





        jQuery(function ($) {

            DisplayCurrentTime();

            //initiate dataTables plugin
            var myTable =
                $('#dynamic-table')

                    .DataTable({

                        "lengthChange": false,
                        "ordering": false,
                        "language": {
                            "info": "",
                            "search": "بحث",
                            "zeroRecords": "لاتوجد بيانات متوافقة مع البحث",
                            "emptyTable": "لا توجد بيانات مسجلة",
                            "paginate": {
                                "previous": "<<",
                                "next": ">>"

                            }
                        }



                    });


        });


    </script>

</asp:Content>

