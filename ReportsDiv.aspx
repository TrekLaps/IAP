﻿<%@ Page Title="الاطلاع على الملاحظات" EnableEventValidation="true" Language="C#" MasterPageFile="~/MasterPage.master" CodeFile="~/ReportsDiv.aspx.cs" AutoEventWireup="true" Inherits="ReportsDiv" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
     <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.min.js"></script>


    <!-- page specific plugin styles -->
    <link rel="stylesheet" href="assets/css/jquery-ui.custom.min.css" />
    <link rel="stylesheet" href="assets/css/chosen.min.css" />
    <link rel="stylesheet" href="assets/css/bootstrap-datepicker3.min.css" />
    <link rel="stylesheet" href="assets/css/bootstrap-datetimepicker.min.css" />

    <!-- page specific plugin styles -->
    <link rel="stylesheet" href="assets/css/jquery.gritter.min.css" />
    <link rel="stylesheet" href="assets/css/bootstrap-multiselect.min.css" />
    <link rel="stylesheet" href="assets/css/select2.min.css" />
    <!-- page specific plugin styles -->
    <link rel="stylesheet" href="assets/css/jquery-ui.custom.min.css" />
    <link rel="stylesheet" href="assets/css/chosen.min.css" />
    <link rel="stylesheet" href="assets/css/bootstrap-datepicker3.min.css" />
    <link rel="stylesheet" href="assets/css/bootstrap-datetimepicker.min.css" />


    <style>
        .modal-backdrop {
            visibility: hidden !important;
        }

        .modal.in {
            background-color: rgba(0,0,0,0.5);
        }
        /*تعديل*/
        .well span {
            font-family: Arial;
            font-size: 20px !important;
            font-weight: normal !important;
        }
        /*---*/

        .box.box-info {
            background-color: #FFFFFF;
           
            width: 100%;

        }

        .box {
            position: relative;
           
            background: #ffffff;
            border-top: 3px solid #d2d6de;
            margin-bottom: 20px;
            width: 100%;
          
        }

        .box-header.with-border {
            border-bottom: 1px solid #f4f4f4;
        }

        .box-header {
            color: #444;
            display: block;
            padding: 10px;
            position: relative;
        }

        .box-body {
            border-top-left-radius: 0;
            border-top-right-radius: 0;
            border-bottom-right-radius: 3px;
            border-bottom-left-radius: 3px;
            padding: 3px;
        }

        .box-footer {
            border-top-left-radius: 0;
            border-top-right-radius: 0;
            
            border-top: 1px solid #f4f4f4;
            padding: 10px;
            background-color: #fff;
        }

        .form-control {
            display: block;
            width: 100%;
            height: 34px;
            padding: 6px 12px;
            font-size: 14px;
            line-height: 1.42857143;
            color: #555;
            background-color: #fff;
            background-image: none;
            border: 1px solid #ccc;
            border-radius: 4px;
            -webkit-box-shadow: inset 0 1px 1px rgba(0,0,0,.075);
            box-shadow: inset 0 1px 1px rgba(0,0,0,.075);
            -webkit-transition: border-color ease-in-out .15s,-webkit-box-shadow ease-in-out .15s;
            -o-transition: border-color ease-in-out .15s,box-shadow ease-in-out .15s;
            transition: border-color ease-in-out .15s,box-shadow ease-in-out .15s;
        }



        .box.box-warning {
            background-color: #FFFFFF;
            
            width: 100%;
           
        }

        .box.box-success {
              background-color: #FFFFFF;
            
            width: 100%;
           
        }

        .box.box-primary {
             background-color: #FFFFFF;
            
            width: 100%;
           
        }

        ul.menudetails li {
            float: right;
            width: 50%;
            direction: rtl;
        }

        ul.menudetails {
            margin-right: 50px;
        }

        ul.menudNoteetails li {
            float: right;
            width: 50%;
            direction: rtl;
            text-align: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="PageTitle" runat="Server">
    الإطلاع على الملاحظات 
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" runat="Server">
    <asp:HiddenField ID="HiddenField1" runat="server" />
    <h3>
        
        <span runat="server" id="PagTitle">الإطلاع على الملاحظات </span>
    </h3>

    <div id="MainTable" style="display: block;" runat="server">


        <div class="row" style="display: none;">
            <h4 class="pink" style="float: right; display: none;">
                <i class="ace-icon fa fa-file-archive-o green"></i>
                <asp:LinkButton ID="Adminfiles" OnClick="Adminfiles_Click" CssClass=" no-backdrop" runat="server">ملفات الإدارة متوسطة</asp:LinkButton>

            </h4>
            <asp:Label ID="LblAdms" runat="server" Style="display: none" Text=""></asp:Label>
        </div>


        <div class="row">
            <div class="col-md-5">
                <div class="box box-info">


                    <div class="box-body">
                        <div class="row">
                            <div class="col-md-12">
                                <label class=" control-label" for="form-field-1">السنوات</label>

                                <div style="width: 210px; height: 60px;">
                                    <asp:DropDownList class="chosen-select chosen-rtl form-control" AppendDataBoundItems="true" ID="PlansSearch" AutoPostBack="true" OnSelectedIndexChanged="PlansSearch_SelectedIndexChanged" runat="server" data-placeholder="الخطة">
                                        <asp:ListItem Value="0" Text="كل السنوات" Selected="True" />
                                    </asp:DropDownList>
                                </div>

                                <asp:Label ID="Label1" Style="display: none;" runat="server" Text=""></asp:Label>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-12">
                                <label class=" control-label" for="form-field-1">الإدارة العليا  </label>

                                <div style="width: 210px; height: 60px;">
                                    <asp:DropDownList class="chosen-select chosen-rtl form-control" ID="Sector" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="Sector_SelectedIndexChanged" runat="server" data-placeholder="الإدارات عليا">
                                        <asp:ListItem Value="0" Text="كل الإدارات عليا" Selected="True" />

                                    </asp:DropDownList>
                                </div>

                            </div>

                        </div>

                        <div class="row">
                            <div class="col-md-12">
                                <label class=" control-label" for="form-field-1">الإدارة متوسطة  </label>
                                <div style="width: 210px; height: 60px;">
                                    <asp:DropDownList class="chosen-select chosen-rtl form-control" AppendDataBoundItems="true" ID="Mang" AutoPostBack="true" OnSelectedIndexChanged="Mang_SelectedIndexChanged" runat="server" data-placeholder="الإدارات المتوسطة">
                                        <asp:ListItem Selected="True" Text="كلالإدارات المتوسطة" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>

                    </div>


                </div>
            </div>
            <div class="col-md-7">
                <div class="box box-info">

                    <div class="box-body">
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">

                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                            <h4 class="control-label">حالة التكرار</h4>
                                            <label>
                                                <input name="switch-field-1" runat="server" id="RepeatSearch" onchange="CheckRepeate();" class="ace ace-switch ace-switch-7" type="checkbox" />
                                                <span class="lbl"></span>
                                            </label>
                                            <span>
                                                <asp:CheckBox ID="CheckRepeat" Text="لايهم حالة التكرار" Style="display: none;" Checked="true" AutoPostBack="true" OnCheckedChanged="CheckRepeat_CheckedChanged" runat="server" />
                                            </span>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>

                                </div>
                            </div>

                            <div class="col-md-6">

                                <div class="form-group" style="padding-left: 5px;">
                                    <h4 class="control-label">تاريخ التنفيذ</h4>

                                    <div class="input-group">
                                        <span class="input-group-addon">
                                            <i class="fa fa-calendar bigger-110"></i>
                                        </span>
                                        <input class="form-control date-picker" id="DateFromSearch" autocomplete="off" onchange="myFunction()" runat="server" type="text" placeholder="يوم - شهر -سنة" data-date-format="yyyy-mm-dd" />

                                    </div>

                                    <div></div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-8" style="margin-bottom: 10px;">

                                <label class=" control-label" for="form-field-1">مستوى الأهمية  </label>


                                <asp:RadioButtonList ID="Importance" AutoPostBack="true" runat="server" OnSelectedIndexChanged="Importance_SelectedIndexChanged" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="3"><img height="40" src="assets/images/Icons/levels/L1/high.png" /></asp:ListItem>
                                    <asp:ListItem Value="2"><img height="40" src="assets/images/Icons/levels/L1/mid.png" /></asp:ListItem>
                                    <asp:ListItem Value="1"><img height="40"  src="assets/images/Icons/levels/L1/low.png" /></asp:ListItem>
                                    <asp:ListItem Selected="True" Value="0" class="btnAll">الكل</asp:ListItem>

                                </asp:RadioButtonList>


                            </div>

                            <div class="col-md-4" style="margin-bottom: 10px;">
                                <div class="form-group">
                                    <label class=" control-label" for="form-field-1">ردود التوصيات</label>



                                    <label>
                                        <input name="switch-field-1" runat="server" id="CheckReplies" onchange="CheckRepliesFun();" class="ace ace-switch ace-switch-7" type="checkbox" />
                                        <span class="lbl"></span>
                                    </label>
                                </div>
                            </div>




                            <div class="col-md-12 no-padding no-margin" style="margin-bottom: 10px;">

                                <label class="control-label" for="form-field-1">حالة الملاحظة  </label>



                                <asp:RadioButtonList ID="RadioStatus" AutoPostBack="true" runat="server" OnSelectedIndexChanged="RadioStatus_SelectedIndexChanged" RepeatDirection="Horizontal">
                                    <asp:ListItem Value='3'><img height="37"  src="assets/icons/levels/L2/solved.png"  /></asp:ListItem>
                                    <asp:ListItem Value='2'><img height="37" src="assets/icons/levels/L2/under.png" /></asp:ListItem>
                                    <asp:ListItem Value='1'><img height="37"  src="assets/icons/levels/L2/hold.png" /></asp:ListItem>
                                    <asp:ListItem Value="5"><img height="37" src="assets/icons/levels/L2/closed.png" /></asp:ListItem>
                                    <asp:ListItem Value="4"><img height="37" src="assets/icons/levels/L2/notstart.png" /></asp:ListItem>
                                    <asp:ListItem Selected="True" Value="0" class="btnAll">الكل</asp:ListItem>
                                </asp:RadioButtonList>



                            </div>
                            <div class="clearfix">&nbsp;</div>
                        </div>
                    </div>

                </div>
            </div>
        </div>
        <div class="col-md-12 col-md-3" style="display: none;">

            <div class="form-group">
                <label class=" control-label" for="form-field-1">بحث  تبعا لرقم الملاحظة   أو تاريخ اصداره </label>

                <div class="col-md-12">


                   <div>
                        <asp:DropDownList class="chosen-select chosen-rtl form-control" AppendDataBoundItems="true" ID="Admins1" AutoPostBack="true" OnSelectedIndexChanged="Admins1_SelectedIndexChanged" runat="server" data-placeholder="كود - تاريخ ">
                            <asp:ListItem Value="0" Text="كل الملاحظات" Selected="True" />

                        </asp:DropDownList>
                    </div>

                    <asp:Label ID="Datt" Style="display: none;" runat="server" Text=""></asp:Label>

                </div>
            </div>
        </div>


        <div class="row">


            <div class="col-md-4">
                <div id="Suc" runat="server" visible="false" class="alert alert-block alert-success">
                    <strong>
                        <i class="ace-icon fa fa-check-square-o icon-only bigger-150"></i>
                        تم الحفظ !
                    </strong>

                </div>
                <div id="SucDel" runat="server" visible="false" class="alert alert-block alert-success">
                    <strong>
                        <i class="ace-icon fa fa-check-square-o icon-only bigger-150"></i>
                        تم حذف الملاحظة بنجاح في حال الرغبة باسترجاع الملاحظة الرجاء التواصل مع إدارة النظام!
                    </strong>

                </div>
            </div>




        </div>


        <!-- div.table-responsive -->

        <!-- div.dataTables_borderWrap -->
        <div class="box box-warning" style="padding: 10px;">

            <table id="dynamic-table" class=" table-striped table-bordered">


                <thead class="TableHead">
                    <tr>
                        <th class="center">الإدارة متوسطة</th>
                        <th class="center">رقم الملاحظة 
                                
                        </th>

                        <th class="center">عرض الملاحظة 

                                       

                        </th>
                        <th class="center">عرض وإضافة توصيات</th>


                        <th class="center">مستوى الأهمية 
                              
                               
                        </th>
                        <th class="center">تاريخ التنفيذ </th>
                        <th class="center">حالة الملاحظة  

                               
                        </th>

                        <th class="center">حالة التكرار
                           
                        </th>
                        <th class="center"></th>
                    </tr>
                </thead>

                <tbody>
                    <asp:Repeater ID="EmployeesData" OnItemDataBound="EmployeesData_ItemDataBound" runat="server">
                        <ItemTemplate>

                            <tr>
                                <td class="center">
                                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("AdmName") %>'></asp:Label>
                                </td>
                                <td class="center">

                                    <asp:LinkButton CssClass="blue" data-rel="tooltip" title="عرض الملاحظة" ID="LinkButton3" CommandArgument='<%# Eval("RepID") %>' OnCommand="LinkDetails_Command" runat="server"> <span><%# Eval("RepCode") %></span> </asp:LinkButton>

                                    <%-- <asp:UpdateProgress ID="UpdateProgress2"
                                                AssociatedUpdatePanelID="UpdatePane02"
                                                runat="server">
                                                <ProgressTemplate>
                                                    <i class="ace-icon fa fa-spinner fa-spin green bigger-125"></i>جارى التحميل...            
                                                </ProgressTemplate>
                                            </asp:UpdateProgress>
                                            <asp:UpdatePanel ID="UpdatePane02" runat="server">
                                                <ContentTemplate>--%>




                                    <%--</ContentTemplate>
                                            </asp:UpdatePanel>--%>
                                </td>


                                <td class="center">
                                    <asp:ImageButton ID="ImageButton1" Height="40" CommandArgument='<%# Eval("RepID") %>' OnCommand="LinkDetails_Command" ToolTip="عرض الملاحظة" ImageUrl="assets/icons/BasicIcon/view.png" runat="server" />

                                </td>

                                <td class="center">

                                    <asp:ImageButton ID="ImageButton2" Height="40" CommandArgument='<%# Eval("RepID") %>' OnCommand="Edit_Command" ImageUrl="assets/icons/BasicIcon/view.png" ToolTip="عرض واضافة توصية" runat="server" />
                                    <hr class="no-margin" />
                                    <asp:Label ID="RepComCount" runat="server" Text='<%# Eval("ComCount") %>'></asp:Label>
                                </td>

                                <td class="center">
                                    <asp:Image ID="TD1" Height="40" runat="server" />
                                    <asp:Label ID="LblImportant" Visible="false" runat="server" Text='<%# Eval("Importance") %>'></asp:Label>
                                </td>
                                <td class="center">
                                    <asp:Label ID="Label8" runat="server" Text='<%# Eval("RepFrom") %>'></asp:Label>
                                </td>

                                <td class="center">

                                    <asp:Label ID="LblStat" Visible="false" runat="server" Style="color: #FFFFFF; padding: 7px;" Text='<%# Eval("RepStatus") %>'></asp:Label>
                                    <asp:Image ID="TD2" Height="40" runat="server" />
                                </td>
                                <td class="center">

                                    <asp:Image ImageUrl="assets/icons/BasicIcon/repete1.png" Height="45" Visible='<%#Convert.ToBoolean(Eval("RepRepeat"))?true:false%>' runat="server" ID="ImRepeat" />

                                    <asp:Image ImageUrl="assets/icons/BasicIcon/repete2.png" Height="45" Visible='<%#Convert.ToBoolean(Eval("RepRepeat"))?false:true%>' runat="server" ID="ImRepeat2" />
                                </td>

                                <td class="center">
                                    <%-- <asp:UpdateProgress ID="UpdateProg07"
                                                AssociatedUpdatePanelID="UpdatePane07"
                                                runat="server">
                                                <ProgressTemplate>
                                                    <i class="ace-icon fa fa-spinner fa-spin green bigger-125"></i>جارى التحميل...            
                                                </ProgressTemplate>
                                            </asp:UpdateProgress>
                                            <asp:UpdatePanel ID="UpdatePane07" runat="server">
                                                <ContentTemplate>--%>
                                    <asp:LinkButton CssClass="green" data-rel="tooltip" title="تعديل" ID="EditRep" CommandArgument='<%# Eval("RepID") %>' OnCommand="EditRep_Command" runat="server"><i class="ace-icon fa fa-pencil icon-only bigger-120"></i></asp:LinkButton>
                                    <!--Open Dlete Report PUP-->
                                    <a class="red" role='button' data-rel="tooltip" title="حذف" href='#DeleteReport_modal' data-toggle='modal' data-book-id='<%# Eval("RepID") %>'>
                                        <i class="ace-icon fa fa-close icon-only bigger-120"></i><span class='hidden'>حذف</span>
                                    </a>
                                    <%--  </ContentTemplate>
                                            </asp:UpdatePanel>--%>
                                            </div>

                                                <div class="hidden-md hidden-lg">
                                                    <div class="inline pos-rel">
                                                        <button class="btn btn-minier btn-#e7ea56 dropdown-toggle" data-toggle="dropdown" data-position="auto">
                                                            <i class="ace-icon fa fa-caret-down icon-only bigger-120"></i>
                                                        </button>

                                                        <ul class="dropdown-menu dropdown-only-icon dropdown-#e7ea56 dropdown-menu-right dropdown-caret dropdown-close">

                                                            <li>
                                                                <asp:LinkButton CssClass="green" data-rel="tooltip" title="تعديل" ID="LinkButton2" CommandArgument='<%# Eval("RepID") %>' OnCommand="EditRep_Command" runat="server"><i class="ace-icon fa fa-pencil icon-only bigger-120"></i></asp:LinkButton>

                                                            </li>
                                                            <li><a class="red" role='button' data-rel="tooltip" title="حذف" href='#DeleteReport_modal' data-toggle='modal' data-book-id='<%# Eval("RepID") %>'>
                                                                <i class="ace-icon fa fa-close icon-only bigger-120"></i><span class='hidden'>حذف</span>
                                                            </a></li>
                                                        </ul>
                                                    </div>
                                                </div>
                                </td>

                            </tr>

                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>

    </div>



    <div id="NewNote" class="MainBox" style="display: none" runat="server">



        <div style="padding: 15px; border: 1px solid #E0E2E5; background-color: #FFF;">

            <h4 class="blue bigger">توصية جديدة</h4>
            <div runat="server" id="MainSave">

                <div class="row">

                    <div class="col-md-12 col-md-8" style="display: none;">

                        <label class="col-md-4 Sub control-label">أهمية التوصية</label>

                        <div class="col-md-8">

                            <div>
                                <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="3"><img height="39" src="assets/images/Icons/levels/L1/high.png" /></asp:ListItem>
                                    <asp:ListItem Value="2"><img height="39" src="assets/images/Icons/levels/L1/mid.png" /></asp:ListItem>
                                    <asp:ListItem Selected="True" Value="1"><img height="39"  src="assets/images/Icons/levels/L1/low.png" /></asp:ListItem>

                                </asp:RadioButtonList>

                            </div>

                        </div>
                    </div>
                    <div class="col-md-12 col-md-4">
                        <label class="col-md-3 Sub control-label">التكرار</label>
                        <div class="col-md-9">
                            <label>
                                <input name="switch-field-1" runat="server" id="LblRepeatU" class="ace ace-switch ace-switch-7" type="checkbox" />
                                <span class="lbl"></span>
                            </label>
                        </div>


                    </div>
                    <div class="col-md-12 col-md-4">

                        <label class="col-md-4 Sub control-label">تاريخ التنفيذ</label>
                        <div class="col-md-8">
                            <div class="input-group">
                                <span class="input-group-addon">
                                    <i class="fa fa-calendar bigger-110"></i>
                                </span>
                                <input class="form-control date-picker" id="DFromNoteUDP" runat="server" type="text" placeholder="يوم - شهر -سنة" data-date-format="yyyy-mm-dd" />

                            </div>

                        </div>


                    </div>

                </div>
                <div class="row">
                    <div class="col-md-12 col-md-12">

                        <label class="col-md-4 Sub control-label">حالة معالجة التوصية</label>

                        <div class="col-md-8">

                            <div>
                                <asp:RadioButtonList ID="RadioButtonList2" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Value='3'><img height="40"  src="assets/icons/levels/L2/solved.png"  /></asp:ListItem>
                                    <asp:ListItem Value='2'><img height="40" src="assets/icons/levels/L2/under.png" /></asp:ListItem>
                                    <asp:ListItem Value='1'><img height="40"  src="assets/icons/levels/L2/hold.png" /></asp:ListItem>
                                    <asp:ListItem Value="5"><img height="40" src="assets/icons/levels/L2/closed.png" /></asp:ListItem>
                                    <asp:ListItem Value="4"><img height="40" src="assets/icons/levels/L2/notstart.png" /></asp:ListItem>
                                </asp:RadioButtonList>

                            </div>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" InitialValue=" " ControlToValidate="RadioButtonList2" runat="server" ValidationGroup="G" ForeColor="#ff3c3c" ErrorMessage="مطلوب تحديد  معالجة التوصية  *"></asp:RequiredFieldValidator>

                        </div>
                    </div>


                </div>
                <div class="row">

                    <div class="col-md-12">
                        <label class="col-md-2 control-label Sub no-padding-right" for="form-field-1">اضافة ملفات  </label>
                        <div class="col-md-5">
                            <div class="form-group">
                                <div class="btn btn-primary btn-sm right">
                                    <span>Select file</span>
                                    <asp:FileUpload ID="FileUpload01" runat="server" />
                                    <div id="ValidatNoteFile" class="red"></div>

                                </div>
                            </div>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ForeColor="Red" Display="Dynamic" ValidationGroup="GFile01" runat="server" ControlToValidate="FileUpload01" ErrorMessage="*مطلوب رفع ملف"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-2">
                            <asp:Label ID="LblNoteFileExist" Visible="false" runat="server" Text="مسجل ملف بنفس الاسم" ForeColor="#ff3c3c"></asp:Label>

                            <asp:Button  CssClass="btn btn-success" Text="حفظ" ID="AddNoteFile" ValidationGroup="GFile01" OnClick="AddNoteFile_Click" runat="server" />

                        </div>
                        <div class="col-md-3">
                            <div id="SucNoteFile" style="margin-top: 2px;" runat="server" visible="false" class="alert alert-block alert-success">
                                <strong>
                                    <i class="ace-icon fa fa-check-square-o icon-only bigger-150"></i>
                                    تم الحفظ !
                                </strong>

                            </div>
                        </div>

                    </div>
                </div>
                <div class="row" style="margin-top: 7px;">
                    <div class="col-md-12">
                        <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                            <ContentTemplate>

                                <table class=" table-striped table-bordered">

                                    <thead class="TableHead">
                                        <tr>

                                            <th class="center">اسم المرفق
                                            </th>
                                            <th class="center">التاريخ
                                            </th>
                                            <th class="center">تحميل
                                            </th>
                                            <th class="center">حذف</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Repeater ID="RepeateNoteFiles" runat="server">

                                            <ItemTemplate>

                                                <tr>
                                                    <td class="center">

                                                        <asp:HyperLink ID="HyperLink2" NavigateUrl='<%# Eval("FPath") %>' Text='<%# Eval("FName") %>' runat="server"></asp:HyperLink>

                                                    </td>
                                                    <td class="center">
                                                        <asp:Label ID="Label1" runat="server" Text='<%# Convert.ToDateTime(Eval("FDate")).ToShortDateString() %>'></asp:Label></td>
                                                    <td class="center">
                                                        <asp:HyperLink ID="HyperLink4" NavigateUrl='<%# Eval("FPath") %>' runat="server"><img height="40" src="assets/icons/BasicIcon/download.png" /></asp:HyperLink></td>



                                                    <td class="center">
                                                        <!--Open Dlete file PUP-->
                                                        <a class="red" role='button' data-rel="tooltip" title="حذف" href='#DelFile_modal' data-toggle='modal' data-book-id='<%# Eval("FID") %>'>
                                                            <i class="ace-icon fa fa-close icon-only bigger-120"></i><span class='hidden'>حذف</span>
                                                        </a>
                                                    </td>
                                                </tr>

                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </tbody>
                                </table>

                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-12 col-md-12">
                        <label class="Sub control-label">نص التوصية </label>
                        <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                            <ContentTemplate>


                                <div style="font-size: 14px; font-family: Arial;" class="wysiwyg-editor" runat="server" id="editor1"></div>
                            </ContentTemplate>
                        </asp:UpdatePanel>

                    </div>
                </div>


                <div class="row">
                    <div class="col-md-12 col-md-12">
                        <label class="Sub control-label">الاجراء التصحيحي من قبل الإدارة متوسطة  </label>
                        <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                            <ContentTemplate>


                                <div style="font-size: 14px; font-family: Arial;" class="wysiwyg-editor" runat="server" id="editor1N"></div>
                            </ContentTemplate>
                        </asp:UpdatePanel>

                    </div>
                </div>

                <div class="row" style="padding-top: 10px;">


                    <asp:Label ID="Rett" runat="server" Text="" CssClass="Rett" ForeColor="#ff3c3c"></asp:Label>
                    <asp:Label ID="ReqDates" Style="color: red; display: none; font-size: 14px; font-weight: bold;" runat="server" Text="* مطلوب تحديد مدة زمنية لمعالجة التوصية خلالها  "></asp:Label>

                    <asp:Label ID="ErrorDay" Style="color: red; display: none; font-size: 14px; font-weight: bold;" runat="server" Text=" يجب أن يكون تاريخ الإنتهاء أكبر من أو يساوى تاريخ اليوم الجارى "></asp:Label>
                    <asp:ImageButton ID="Save" OnClick="Save_Click" ValidationGroup="G" Height="51" runat="server" src="assets/icons/buttons/addrec.png" />



                </div>
                <input style="display: none" type="text" runat="server" name="bookId" id="bookId" value="" />
                <asp:Label ID="LblNotNew" Visible="false" runat="server" Text=""></asp:Label>
            </div>


            <div runat="server" style="display: none;" id="PrntView">
                <div id="dvContents">



                    <div class="row">
                        <h4 style="margin-right: 7px;" class="blue">تفاصيل الملاحظة </h4>
                        <div class="col-md-12 col-md-4">

                            <div class="form-group">


                                <label class="col-md-4 control-label" for="form-field-1">موجه لإدارة عليا</label>
                                <div class="col-md-8">
                                    <asp:Label ID="RepSec" runat="server" Text=""></asp:Label>
                                </div>

                            </div>
                        </div>

                        <div class="col-md-12 col-md-4">

                            <div class="form-group">


                                <label class="col-md-4 control-label" for="form-field-1">موجه لإدارة متوسطة</label>
                                <div class="col-md-8">
                                    <asp:Label ID="RepAdm" runat="server" Text=""></asp:Label>
                                </div>

                            </div>
                        </div>

                        <div class="col-md-12 col-md-4">

                            <div class="form-group">


                                <label class="col-md-4 control-label" for="form-field-1">مستوى الأهمية </label>
                                <div class="col-md-8">
                                    <asp:Label ID="RepIm" runat="server" Text=""></asp:Label>
                                </div>

                            </div>
                        </div>

                    </div>
                    <div class="row">
                        <div class="col-md-12 col-md-4">


                            <div class="form-group">
                                <label class="col-md-4 control-label">تاريخ الملاحظة  </label>

                                <div class="col-md-8">
                                    <asp:Label ID="RepDat" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-12 col-md-4">

                            <div class="form-group">

                                <label class="col-md-4 control-label">التاريخ المحدد للتنفيذ</label>
                                <div class="col-md-8">
                                    <asp:Label ID="RepOn" runat="server" Text=""></asp:Label>

                                </div>

                            </div>
                        </div>

                        <div class="col-md-12 col-md-4">

                            <div class="form-group">

                                <label class="col-md-4 control-label " for="form-field-1">حالة التكرار </label>
                                <div class="col-md-8">

                                    <div class="form-group">
                                        <span id="RepRep" runat="server" />
                                    </div>
                                </div>

                            </div>
                        </div>


                    </div>
                    <div class="row">

                        <div class="col-md-12 col-md-4">

                            <div class="form-group">

                                <label class="col-md-4 control-label">حالة التنفيذ </label>
                                <div class="col-md-8">
                                    <asp:Label ID="RepSt" runat="server" Text=""></asp:Label>

                                </div>

                            </div>
                        </div>

                    </div>
                    <div class="row">

                        <div class="col-md-12 col-md-12">
                            <div class="hr hr8 hr-double hr-dotted"></div>
                            <div class="well">
                                <div id="Div1" runat="server" />
                            </div>
                        </div>

                    </div>

                    <div class="row">
                        <label class="col-md-2 control-label " for="form-field-1">بيان التوصيات : </label>
                        <div class="col-md-12 col-md-10" runat="server" id="NoNotes">لا يوجد توصيات على الملاحظة</div>
                        <div class="col-md-12 col-md-10" runat="server" style="display: none" id="NotesPrev">
                            <div>
                                <table style="width: 95%; border: 1px solid black;" cellspacing="1" cellpadding="1">
                                    <thead class="TableHead">
                                        <tr>
                                            <th class="center">مستوى الأهمية </th>
                                            <th class="center">تاريخ التنفيذ </th>
                                            <th class="center">حالة التوصية </th>
                                            <th class="center">حالة التكرار  </th>
                                            <th class="center">رقم التوصية  </th>
                                        </tr>
                                    </thead>
                                    <tbody runat="server" id="NoteListing">
                                    </tbody>

                                </table>
                            </div>
                            <div class="clear1">&nbsp;</div>
                        </div>
                    </div>



                </div>

                <div class="row">
                    <div class="col-md-12">
                        <asp:Label ID="Label6" runat="server" Text="" CssClass="Rett" ForeColor="#ff3c3c"></asp:Label>

                        <a href="#" id="Prnt" onclick="PrintDiv();">
                            <img src="assets/icons/buttons/print.png" height="40" />
                        </a>

                    </div>
                </div>

            </div>


        </div>

        <div>
            <asp:LinkButton ID="BackNotes" runat="server" OnClick="BackNotes_Click" Style="float: left; margin-top: -10px;"><i class="ace-icon fa fa-arrow-left icon-only purple bigger-250"></i></asp:LinkButton>
        </div>
    </div>

    <div id="AdminFilesView" class="MainBox" style="display: none;" runat="server">


        <h4 class="blue bigger">ملفات الإدارة متوسطة </h4>
        <div style="padding: 15px; border: 1px solid #E0E2E5; background-color: #FFF;">

            <asp:UpdateProgress ID="AdminProg"
                AssociatedUpdatePanelID="UpdAdmin"
                runat="server">
                <ProgressTemplate>
                    <i class="ace-icon fa fa-spinner fa-spin green bigger-125"></i>جارى التحميل...            
                </ProgressTemplate>
            </asp:UpdateProgress>
            <asp:UpdatePanel ID="UpdAdmin" runat="server" UpdateMode="Always">
                <ContentTemplate>
                    <div class="row">

                        <div class="col-md-6">

                            <div class="form-group">
                                <label class=" control-label" for="form-field-1">الإدارة العليا </label>



                               <div>
                                    <asp:DropDownList class="chosen-select chosen-rtl form-control" ID="SectorAdmin" AutoPostBack="true" OnSelectedIndexChanged="SectorAdmin_SelectedIndexChanged" runat="server" data-placeholder="الإدارات عليا">
                                    </asp:DropDownList>
                                </div>

                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ForeColor="Red" ControlToValidate="SectorAdmin" ValidationGroup="GFAdmin" runat="server" ErrorMessage="* مطلوب تحديد الإدارة متوسطة"></asp:RequiredFieldValidator>

                            </div>

                        </div>
                        <div class="col-md-12 col-md-3">
                            <label class="col-md-2 control-label" for="form-field-1">الإدارة متوسطة  </label>
                            <div class="col-md-10" style="margin-left: 2px;">


                                <asp:CheckBox ID="chkAll" Text="كل ادارات القطاع" runat="server" />
                                <asp:CheckBoxList ID="PermChecks" runat="server">
                                </asp:CheckBoxList>
                            </div>
                        </div>


                    </div>

                </ContentTemplate>
            </asp:UpdatePanel>
            <div class="row">

                <div class="col-md-12">
                    <label class="control-label" for="form-field-1">اضافة ملفات  </label>

                    <div id="SucAdminFile" runat="server" visible="false" class="alert alert-block alert-success">
                        <strong>
                            <i class="ace-icon fa fa-check-square-o icon-only bigger-150"></i>
                            تم الحفظ !
                        </strong>

                    </div>
                    <div id="ValidatFileAdmin" class="red"></div>

                    <div class="form-group">

                        <div class="col-md-6">
                            <div class="form-group">
                                <div class="btn btn-primary btn-sm right">
                                    <span>Select file</span>
                                    <asp:FileUpload ID="FileUploadAdmin" runat="server" />

                                </div>
                            </div>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ForeColor="Red" Display="Dynamic" ValidationGroup="GFAdmin" runat="server" ControlToValidate="FileUploadAdmin" ErrorMessage="*مطلوب رفع ملف"></asp:RequiredFieldValidator>
                            <asp:Label ID="FileAdminExsists" Visible="false" runat="server" Text="مسجل ملف بنفس الاسم" ForeColor="#ff3c3c"></asp:Label>

                            <asp:Button ID="AddFileAdmin" OnClick="AddFileAdmin_Click" ValidationGroup="GFAdmin" CssClass="btn btn-success"  Text="حفظ" runat="server" />

                            <asp:Label ID="LblFileError" runat="server" Visible="false" Text=""></asp:Label>

                        </div>
                    </div>
                </div>
            </div>


        </div>
        <div>
            <asp:LinkButton ID="LinkButton5" runat="server" OnClick="BackTables_Click" Style="float: left; margin-top: -10px;"><i class="ace-icon fa fa-arrow-left icon-only purple bigger-250"></i></asp:LinkButton>
        </div>
    </div>


    <div id="UpdReport" style="display: none" runat="server" class="MainBox">


        <asp:Label ID="RepUpdCode" runat="server" Visible="false" Text=""></asp:Label>
        <div style="padding: 15px; border: 1px solid #E0E2E5; background-color: #FFF;">


            <div class="row">

                <asp:UpdateProgress ID="UpdateProgress2"
                    AssociatedUpdatePanelID="UpdateRep01"
                    runat="server">
                    <ProgressTemplate>
                        <i class="ace-icon fa fa-spinner fa-spin green bigger-125"></i>جارى التحميل...            
                    </ProgressTemplate>
                </asp:UpdateProgress>
                <asp:UpdatePanel ID="UpdateRep01" runat="server">
                    <ContentTemplate>
                        <div class="row">
                            <div class="col-md-12 col-md-6">
                                <label class="col-md-2 control-label Sub blue" for="form-field-1">الخطة  </label>

                                <div class="col-md-10">

                                   <div>
                                        <asp:DropDownList class="chosen-select chosen-rtl form-control" ID="DropYearU" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="DropYearU_SelectedIndexChanged" runat="server" data-placeholder="الخطة السنوية">
                                            <asp:ListItem Value=" " Text="اختر الخطة" Selected="True" />

                                        </asp:DropDownList>
                                    </div>

                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" InitialValue=" " ControlToValidate="Sector" runat="server" ValidationGroup="GRep" ForeColor="#ff3c3c" ErrorMessage="مطلوب تحديد الإدارة العليا    *"></asp:RequiredFieldValidator>


                                </div>
                            </div>
                            <div class="col-md-12 col-md-6">
                                <label class="col-md-4 Sub control-label">تاريخ التنفيذ</label>
                                <div class="col-md-12 col-md-8">

                                    <div class="input-group">
                                        <span class="input-group-addon">
                                            <i class="fa fa-calendar bigger-110"></i>
                                        </span>
                                        <input class="form-control date-picker" id="DateFrom" autocomplete="off" runat="server" type="text" placeholder="يوم - شهر -سنة" data-date-format="yyyy-mm-dd" />

                                    </div>
                                </div>

                            </div>
                        </div>
                        <div class="row">

                            <div class="col-md-12 col-md-6">

                                <div class="form-group">
                                    <label class="col-md-2 control-label" for="form-field-1">الإدارة العليا </label>

                                    <div class="col-md-12 col-md-10">

                                       <div>

                                            <asp:DropDownList class="chosen-select chosen-rtl form-control" ID="SectorRep" AutoPostBack="true" OnSelectedIndexChanged="SectorRep_SelectedIndexChanged" runat="server" data-placeholder="الإدارات عليا">
                                            </asp:DropDownList>



                                            <asp:RequiredFieldValidator ID="Required2" InitialValue=" " ControlToValidate="SectorRep" runat="server" ValidationGroup="GRep" ForeColor="#ff3c3c" ErrorMessage="مطلوب تحديد الإدارة العليا  *"></asp:RequiredFieldValidator></span>
              
                                        </div>


                                    </div>
                                </div>
                            </div>


                            <div class="col-md-12 col-md-6">

                                <label class="col-md-3 Sub control-label" for="form-field-1">ادارة  </label>

                                <div class="col-md-12 col-md-9">

                                   <div>
                                        <asp:DropDownList class="chosen-select chosen-rtl form-control" AppendDataBoundItems="true" ID="AdminsRep" runat="server" data-placeholder="اختر الادارة">
                                        </asp:DropDownList>
                                    </div>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ForeColor="#ff3c3c" runat="server" ControlToValidate="AdminsRep" InitialValue="" ValidationGroup="GRep" ErrorMessage="* مطلوب تحديد الادارة المرسل لها  "></asp:RequiredFieldValidator>


                                </div>


                            </div>


                        </div>

                    </ContentTemplate>
                </asp:UpdatePanel>



            </div>


            <div class="row">
                <div class="col-md-12">
                    <label class="control-label col-md-3 Sub no-padding-right">مستوى الأهمية </label>

                    <div class="col-md-9">

                        <div>
                            <asp:RadioButtonList ID="ImportanceRep" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Value="3"><img height="40" src="assets/images/Icons/levels/L1/high.png" /></asp:ListItem>
                                <asp:ListItem Value="2"><img  height="40" src="assets/images/Icons/levels/L1/mid.png" /></asp:ListItem>
                                <asp:ListItem Value="1"><img  height="40" src="assets/images/Icons/levels/L1/low.png" /></asp:ListItem>

                            </asp:RadioButtonList>

                        </div>
                        <asp:RequiredFieldValidator ID="RequiredRep1" InitialValue=" " ControlToValidate="ImportanceRep" runat="server" ValidationGroup="GRep" ForeColor="#ff3c3c" ErrorMessage="مطلوب تحديد درجةمستوى الأهمية   *"></asp:RequiredFieldValidator>

                    </div>

                </div>
            </div>
            <div class="row">

                <div class="col-md-12">

                    <label class="control-label col-md-3 Sub no-padding-right">معالجة الملاحظة </label>

                    <div class="col-md-9">
                        <asp:HiddenField ID="RepStatusMail" runat="server" />
                        <div>
                            <asp:RadioButtonList ID="RadioStatusUpd" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Value='3'><img height="40"  src="assets/icons/levels/L2/solved.png"  /></asp:ListItem>
                                <asp:ListItem Value='2'><img height="40" src="assets/icons/levels/L2/under.png" /></asp:ListItem>
                                <asp:ListItem Value='1'><img height="40"  src="assets/icons/levels/L2/hold.png" /></asp:ListItem>
                                <asp:ListItem Value="5"><img height="40" src="assets/icons/levels/L2/closed.png" /></asp:ListItem>
                                <asp:ListItem Value="4"><img height="40" src="assets/icons/levels/L2/notstart.png" /></asp:ListItem>

                            </asp:RadioButtonList>

                        </div>
                        <asp:RequiredFieldValidator ID="Required3" InitialValue=" " ControlToValidate="RadioStatusUpd" runat="server" ValidationGroup="GRep" ForeColor="#ff3c3c" ErrorMessage="مطلوب تحديد حالة الملاحظة   *"></asp:RequiredFieldValidator>

                    </div>


                </div>

            </div>
            <div class="row">

                <div class="row">
                    <div class="col-md-6">
                        <label class="col-md-4 Sub control-label">التكرار</label>
                        <div class="col-xs-12 col-md-8">
                            <label>
                                <input name="switch-field-1" runat="server" id="RepeatRep" class="ace ace-switch ace-switch-7" type="checkbox" />
                                <span class="lbl"></span>
                            </label>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <label class="col-md-4 Sub control-label">تاريخ الملاحظة</label>
                        <div class="col-md-12 col-md-8">

                            <div class="input-group">
                                <span class="input-group-addon">
                                    <i class="fa fa-calendar bigger-110"></i>
                                </span>
                                <input class="form-control date-picker" id="RePDatUpd" autocomplete="off" runat="server" type="text" placeholder="يوم - شهر -سنة" data-date-format="yyyy-mm-dd" />

                            </div>
                        </div>

                    </div>
                </div>

                <div id="SucUPD" style="margin-top: 2px;" runat="server" visible="false" class="col-md-3 alert alert-block alert-success">
                    <strong>
                        <i class="ace-icon fa fa-check-square-o icon-only bigger-150"></i>
                        تم الحفظ !
                    </strong>

                </div>
                <div class="row">
                    <div class="col-md-12 col-md-12">
                        <div class="form-group" style="margin-top: 30px;">
                            <label class="col-md-2 control-label " for="form-field-1">عنوان الملاحظة </label>

                            <div class="col-md-6">
                                <input runat="server" type="text" id="RepTitleU" placeholder="عنوان الملاحظة" class="form-control text col-md-10 col-md-10" />

                                <span>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" ControlToValidate="RepTitleU" runat="server" ValidationGroup="GRep" ForeColor="#ff3c3c" ErrorMessage="عنوان الملاحظة مطلوب  *"></asp:RequiredFieldValidator></span>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12 col-md-12">
                        <label class="Sub control-label">نص الملاحظة  </label>
                        <asp:UpdatePanel ID="UpdRep" runat="server">
                            <ContentTemplate>

                                <div style="font-size: 14px; font-family: Arial;" class="wysiwyg-editor" runat="server" id="editor3"></div>
                            </ContentTemplate>
                        </asp:UpdatePanel>

                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <div class="form-group" style="margin-top: 30px;">
                            <div>
                                <label class="Sub control-label">أهمية الملاحظة </label>
                            </div>
                            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                <ContentTemplate>
                                    <div style="font-size: 14px; font-family: Arial;" class="wysiwyg-editor" runat="server" id="RepImpTextU"></div>
                                </ContentTemplate>
                            </asp:UpdatePanel>

                        </div>
                    </div>
                </div>
                <div class="row">

                    <asp:Label ID="LblError" runat="server" Text="" CssClass="Rett" ForeColor="#ff3c3c"></asp:Label>

                    <asp:Label ID="ReqDatesRep" Style="color: red; display: none; font-size: 14px; font-weight: bold;" runat="server" Text="* مطلوب تحديد مدة زمنية لتنفيذ لملاحظة  خلالها  "></asp:Label>

                    <asp:Label ID="ErrorDayRep" Style="color: red; display: none; font-size: 14px; font-weight: bold;" runat="server" Text=" يجب أن يكون تاريخ الإنتهاء أكبر من أو يساوى تاريخ اليوم الجارى "></asp:Label>
                    <asp:Label ID="LblReportFile" Style="display: none" runat="server" Text="الملفات المرفقة لها نفس الاسم" ForeColor="#ff3c3c"></asp:Label>
                    <asp:ImageButton Height="40" ID="UpdateReport" OnClick="UpdateReport_Click" ImageUrl="assets/icons/buttons/sendnote.png" ValidationGroup="GRep" runat="server" />

                </div>




            </div>

        </div>
        <div>
            <asp:LinkButton ID="LinkButton7" runat="server" OnClick="BackTables_Click" Style="float: left; margin-top: -10px;"><i class="ace-icon fa fa-arrow-left icon-only purple bigger-250"></i></asp:LinkButton>
        </div>
    </div>

    <div id="RepDetail" style="display: none" runat="server" class="MainBox">


        <a href="#" id="PrntRep" onclick="PrintDivRep();">
            <img src="assets/icons/buttons/print.png" height="40" />
        </a>

        <div id="dvContentsRep" style="padding: 15px; border: 1px solid #E0E2E5; background-color: #FFF; direction: ltr;">
            <h3 class="bigger">بيانات الملاحظة &#10070;</h3>
            <div>

                <div class="row">
                    <div class="col-md-12">

                        <ul class="menudetails">
                            <li><b>عدد التوصيات على الملاحظة</b>:
                                    <asp:Label ID="LblNoteCount" CssClass="grey" runat="server" Text=""></asp:Label></li>
                            <li><b>رقم الملاحظة</b>:
                                    <asp:Label ID="LblNo" CssClass="grey" runat="server" Text=""></asp:Label></li>

                        </ul>
                    </div>

                </div>
                <h3 class="bigger">تفاصيل الملاحظة &#10070;</h3>

                <div class="row">
                    <div class="col-md-12">
                        <ul class="menudetails">
                            <li><b>موجه لإدارة عليا</b>:
                                    <asp:Label ID="LblForSec" CssClass="grey" runat="server" Text=""></asp:Label></li>
                            <li><b>تاريخ الملاحظة  </b>:
                                    <asp:Label ID="LblRepDate" CssClass="grey" runat="server" Text=""></asp:Label></li>

                        </ul>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <ul class="menudetails">
                            <li><b>موجه لإدارة متوسطة</b>:
                                    <asp:Label ID="LblForAdm" CssClass="grey" runat="server" Text=""></asp:Label></li>

                            <li><b>تاريخ التنفيذ </b>:
                                    <asp:Label ID="LblDateFrom" CssClass="grey" runat="server" Text=""></asp:Label></li>

                        </ul>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <ul class="menudetails">
                            <li><b>حالة التكرار </b>:
                                    <asp:Label ID="RPTSign" CssClass="grey" runat="server" Text=""></asp:Label></li>

                            <li><b>مستوى الأهمية </b>:
                                    <asp:Image ID="LblImport" Height="40" runat="server" /></li>

                        </ul>
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-12">
                        <ul class="menudetails">
                            <li><b>عنوان الملاحظة  </b>:
                                    <asp:Label ID="LblReptitle" CssClass="grey" runat="server" Text=""></asp:Label></li>

                            <li><b>حالة الملاحظة  </b>:<asp:Image ID="LblStatus" Height="40" runat="server" /></li>
                        </ul>
                    </div>
                </div>


            </div>


            <div class="row">
                <div class="col-md-12">
                    <ul class="menudetails">
                        <li><b>نص الملاحظة  </b>:
                        </li>
                    </ul>

                </div>
            </div>
            <div class="hr hr8 hr-double hr-dotted"></div>
            <div class="well">
                <div id="Test" runat="server" />
            </div>


            <div class="row">
                <div class="col-md-12">
                    <ul class="menudetails">
                        <li><b>أهمية الملاحظة  </b>:
                        </li>
                    </ul>


                </div>
            </div>
            <div class="hr hr8 hr-double hr-dotted"></div>
            <div class="well">
                <div id="RepImpTxt" runat="server" />
            </div>
        </div>
        <div>
            <asp:LinkButton ID="LinkButton9" runat="server" OnClick="BackTables_Click" Style="float: left; margin-top: -10px;"><i class="ace-icon fa fa-arrow-left icon-only purple bigger-250"></i></asp:LinkButton>
        </div>
    </div>




    <div id="NoteDetails" class="MainBox" style="display: none" runat="server">


        <div style="padding: 15px; border: 1px solid #E0E2E5; background-color: #FFF;">
            <h3 class="bigger">التوصيات</h3>
            <div class="row">
                <div class="col-md-12">
                    <div class="col-md-3">
                        <h4 class="pink" style="float: right;">
                            <span>
                                </span>
                            <asp:LinkButton ID="AddNoe" OnClick="AddNoe_Click" CssClass="no-backdrop" runat="server">إضافة توصية جديدة</asp:LinkButton>

                        </h4>
                    </div>
                    <div class="col-md-9">
                        <div id="SucNote" runat="server" visible="false" class="alert alert-block alert-success">
                            <strong>
                                <i class="ace-icon fa fa-check-square-o icon-only bigger-150"></i>
                                تم حفظ التوصية بنجاح !
                            </strong>

                        </div>
                        <div id="SucNoteDel" runat="server" visible="false" class="alert alert-block alert-success">
                            <strong>
                                <i class="ace-icon fa fa-check-square-o icon-only bigger-150"></i>
                                تم حذف التوصية بنجاح في حال الرغبة باسترجاع التوصية الرجاء التواصل مع إدارة النظام!
                            </strong>

                        </div>
                    </div>

                </div>
            </div>

            <!-- div.table-responsive -->

            <!-- div.dataTables_borderWrap -->
            <table id="dynamic-Notes" class=" table-striped table-bordered">


                <thead class="TableHead">
                    <tr>
                        <th class="center">رقم الملاحظة </th>
                        <th class="center">رقم التوصية </th>
                        <th class="center">عرض التوصية  </th>
                        <th class="center">تاريخ التنفيذ </th>
                        <th class="center">الرد</th>
                        <th class="center">الملفات المرفقة</th>
                        <th class="center">حالة التوصية  </th>
                        <th class="center">  </th>
                    </tr>
                </thead>

                <tbody>
                    <asp:Repeater ID="RepNotes" OnItemDataBound="RepNotes_ItemDataBound" runat="server">
                        <ItemTemplate>

                            <tr>
                                <td class="center">
                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("RepCode") %>'></asp:Label>

                                </td>
                                <td class="center">
                                    
                                    <a class="blue center" role='button' data-rel="tooltip" title="عرض التوصية" href='<%#string.Concat("#Details",Eval("NoteID"))%>' data-toggle='modal'>
                                        <span style="min-width: 30px;">&nbsp;
                                                <%# Container.ItemIndex + 1 %> &nbsp;</span>
                                    </a>



                                    <div id='<%#string.Concat("Details",Eval("NoteID"))%>' data-backdrop="static" data-keyboard="false" aria-hidden="false" class="modal fade" tabindex="-1">
                                        <div class="modal-dialog" style="background-color: #FFFFFF; width: 75%;">

                                           <!-- Log Data Start -->
                                            <div style="float: left;">
                                                <button type="button" id="LogHide"  data-book-id='<%#string.Concat(Eval("RepCode"),"/",(Container.ItemIndex+1).ToString()).Replace("م","")%>' onclick="HiddenLog();" class="close red" data-dismiss="modal">
                                                    <img src="assets/images/Icons/BasicIcon/close.png" height="25" /></button>
                                            </div>

                                             <!-- Log Data End -->
                                            <div class="modal-body" style="font-size: 25px;">
                                                <div class="row">
                                                    <div class="col-md-12">
                                                        <ul class="menudNoteetails">
                                                            <li><b>التكرار</b>:<asp:Label ID="LblNotStat" CssClass="grey" runat="server" Text='<%# Eval("NoteRepeat") %>'></asp:Label>
                                                                <%--<asp:Label ID="Label5" CssClass="grey" runat="server" Text='<%# Eval("NoteRepeat") %>'></asp:Label>--%>
                                                                <asp:Label ID="LblForSec" CssClass="grey" runat="server" Text=""></asp:Label></li>
                                                            <li><b>تاريخ التنفيذ </b>:
                                                                <asp:Label ID="Label16" runat="server" Text='<%# Eval("NoteFrom") %>'></asp:Label>
                                                        </ul>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-12">
                                                        <ul>
                                                            <li style="text-align: right;"><b>حالة التوصية</b>:<asp:Image ID="NotSt" Height="40" runat="server" />

                                                            </li>
                                                            <li><span style="float: right;"><b>نص التوصية </b>:</span><br />
                                                                <asp:Label ID="LitDetail" runat="server" Visible="false" Text='<%# Eval("NoteText") %>'></asp:Label>

                                                                <div id="well" runat="server" class="well">
                                                                </div>
                                                            </li>
                                                            <li><span style="float: right;"><b>الاجراء التصحيحي من قبل الإدارة متوسطة</b>: </span>
                                                                <br />
                                                                <asp:Label ID="LbCorrect" runat="server" Visible="false" Text='<%# Eval("AdminCorrect") %>'></asp:Label>

                                                                <div id="Div2" runat="server" class="well">
                                                                </div>
                                                            </li>
                                                        </ul>
                                                    </div>
                                                </div>


                                                <div class="row">
                                                    <div class="col-md-12 col-md-8">
                                                    </div>
                                                </div>



                                            </div>
                                        </div>
                                    </div>
                                    </div>

                                </td>


                                <td class="center"><a class="blue center" role='button' data-rel="tooltip" title="عرض التوصية" href='<%#string.Concat("#Details",Eval("NoteID"))%>' data-toggle='modal'>
                                    <span>
                                        <img height="40" src="assets/icons/BasicIcon/view.png" />
                                    </span>
                                </a></td>

                                <td class="center">
                                    <asp:Label ID="Label7" runat="server" Text='<%# Eval("NoteFrom") %>'></asp:Label>
                                    <hr />
                                    <asp:Label ID="Late" runat="server" Visible="false" Text='<%# Eval("Late") %>'></asp:Label>
                                    <asp:LinkButton ID="RemindNot" Visible="false" runat="server" class="btn btn-xs btn-info"><span class="glyphicon glyphicon-time"></span> Reminder</asp:LinkButton>

                                </td>


                                <td class="center">
                                    <span>
                                        <asp:LinkButton ID="LinkNotes" OnCommand="LinkNotes_Command" CommandArgument='<%# Eval("NoteID") %>' runat="server">
<img src="assets/icons/BasicIcon/resp.png" height="45" />
                                        </asp:LinkButton></span><span>
                                            <asp:Label ID="ComCount" runat="server" Text='<%# Eval("ComCount") %>'></asp:Label></span></td>

                                <td class="center">

                                    <img src="assets/icons/BasicIcon/attach.png" height="40" />
                                    <asp:Label ID="FNoteCount" Visible="false" runat="server" Text='<%# Eval("FCount") %>'></asp:Label>

                                    <asp:LinkButton title="الملفات المرفقة" ID="LinkNoteFiles" Text="الملفات المرفقة" CommandArgument='<%# Eval("NoteID") %>' OnCommand="LinkNoteFiles_Command" runat="server"></asp:LinkButton>

                                    <div runat="server" class="grey" id="NoNoteFiles" visible="false">لايوجد ملفات مرفقة</div>

                                </td>

                                <td class="center">
                                    <asp:Image ID="TDNote2" Height="40" runat="server" />

                                    <asp:Label ID="LblNoteStat" Visible="false" runat="server" Style="color: #FFFFFF; padding: 7px;" Text='<%# Eval("NoteStatus") %>'></asp:Label>

                                </td>
                                <td class="center">

                                    <asp:LinkButton CssClass="green" data-rel="tooltip" title="تعديل" ID="EditNote" CommandArgument='<%# Eval("NoteID") %>' OnCommand="EditNote_Command" runat="server"><i class="ace-icon fa fa-pencil icon-only bigger-120"></i></asp:LinkButton>
                                    <!--Open Dlete Note PUP-->
                                    <a class="red" role='button' data-rel="tooltip" title="حذف" href='#Delete_modal' data-toggle='modal' data-book-id='<%# Eval("NoteID") %>'>
                                        <i class="ace-icon fa fa-close icon-only bigger-120"></i><span class='hidden'>حذف</span>
                                    </a>


                                    <div class="hidden-md hidden-lg">
                                        <div class="inline pos-rel">
                                            <button class="btn btn-minier btn-#e7ea56 dropdown-toggle" data-toggle="dropdown" data-position="auto">
                                                <i class="ace-icon fa fa-caret-down icon-only bigger-120"></i>
                                            </button>

                                            <ul class="dropdown-menu dropdown-only-icon dropdown-#e7ea56 dropdown-menu-right dropdown-caret dropdown-close">

                                                <li>
                                                    <asp:LinkButton CssClass="green" data-rel="tooltip" title="تعديل" ID="LinkButton1" CommandArgument='<%# Eval("NoteID") %>' OnCommand="EditNote_Command" runat="server"><i class="ace-icon fa fa-pencil icon-only bigger-120"></i></asp:LinkButton>

                                                </li>
                                                <li><a class="red" role='button' data-rel="tooltip" title="حذف" href='#Delete_modal' data-toggle='modal' data-book-id='<%# Eval("NoteID") %>'>
                                                    <i class="ace-icon fa fa-close icon-only bigger-120"></i><span class='hidden'>حذف</span>
                                                </a></li>
                                            </ul>
                                        </div>
                                    </div>
                                </td>


                            </tr>

                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
        <div>
            <asp:LinkButton ID="LinkButton6" runat="server" OnClick="BackTables_Click" Style="float: left; margin-top: -10px;"><i class="ace-icon fa fa-arrow-left icon-only purple bigger-250"></i></asp:LinkButton>
        </div>
    </div>
    <div id="Comm_modal" runat="server" style="display: none;">

        <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal">&times;</button>
            <h4 class="blue bigger">الرد  </h4>
        </div>

        <div class="modal-body">

            <div class="row">
                <div class="col-md-12 col-md-12">

                    <h4 class="blue">ملفات مرفقة بالرد  </h4>

                    <div class="row">

                        <div class="col-md-12 col-md-8">



                            <label class="col-md-4 control-label" for="form-field-1">الملفات المرفقة </label>
                            <div class="col-md-8">
                                <asp:Repeater ID="FileListed" runat="server">

                                    <ItemTemplate>
                                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("FPath") %>' Text='<%# Eval("FName") %>'></asp:HyperLink>

                                    </ItemTemplate>
                                </asp:Repeater>


                            </div>
                        </div>
                        <div class="col-md-12 col-md-4">


                            <div class="form-group">
                                <label class="col-md-4 control-label" for="form-field-1">تاريخ الرد </label>

                                <div class="col-md-8">
                                    <asp:Label ID="LblCommDate" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                        </div>

                        <div class="col-md-12 col-md-4">


                            <div class="form-group">
                                <label class="col-md-4 control-label" for="form-field-1">رقم الملاحظة  </label>

                                <div class="col-md-8">
                                    <asp:Label ID="LblCommRepID" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>







                </div>

            </div>

            <div class="row">
                <h4>الرد</h4>
                <div class="col-md-12 col-md-12">
                    <div class="hr hr8 hr-double hr-dotted"></div>
                    <div class="well">
                        <div id="LblCommTxt" runat="server" />
                    </div>
                </div>

            </div>



        </div>



    </div>


    <asp:Label ID="LblViews" Style="display: none;" runat="server" Text=""></asp:Label>
    <asp:Label ID="NoteId" Style="display: none;" runat="server" Text=""></asp:Label>
    <asp:Label ID="LblUpdate" Style="display: none;" runat="server" Text=""></asp:Label>


    <div id="modal-Replys" data-backdrop="static" data-keyboard="false" class="modal fade" tabindex="-1" style="margin-top: -15px;">
        <div class="modal-dialog" style="right: 2% !important; width: 95%">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="blue bigger">الردود</h4>
                </div>

                <div class="modal-body">

                    <div id="SucReply" runat="server" visible="false" class="alert alert-block alert-success">
                        <strong>
                            <i class="ace-icon fa fa-check-square-o icon-only bigger-150"></i>
                            تم الحفظ !
                        </strong>
                        <asp:Label ID="LblReport" Visible="false" runat="server" Text=""></asp:Label>
                    </div>

                    <div id="SucDelReply" runat="server" visible="false" class="alert alert-block alert-success">
                        <strong>
                            <i class="ace-icon fa fa-check-square-o icon-only bigger-150"></i>
                            تم حذف الرد بنجاح !
                        </strong>

                    </div>

                    <!-- div.table-responsive -->
                    <div>
                        <table id="dynamic-Replys" class=" table-striped table-bordered">


                            <thead class="TableHead">
                                <tr>

                                    <th class="center">من قام بالرد
                                    </th>

                                    <th class="center">تاريخ الرد 
                                                <hr />
                                        الملفات المرفقة
                                                                               
                                    </th>

                                    <th class="center">نص الرد

                                    </th>

                                </tr>
                            </thead>

                            <tbody>
                                <asp:Repeater ID="RepReplys" OnItemDataBound="RepReplys_ItemDataBound" runat="server">
                                    <ItemTemplate>

                                        <tr>
                                            <td class="center">
                                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("EmpName") %>'></asp:Label>
                                                <hr class="center" style="margin-top: 1px; margin-bottom: 1px; border-top: 1px solid #6ad589;" />

                                                <asp:Label ID="Label3" runat="server" Text='<%# Eval("EmpJobTitle") %>'></asp:Label>


                                            </td>
                                            <td class="center">

                                                <asp:Label ID="LblNoteStat" runat="server" Text='<%# Eval("ConfirmDate") %>'></asp:Label>
                                                <hr class="center" style="margin-top: 1px; margin-bottom: 1px; border-top: 1px solid #6ad589;" />

                                                <i class="ace-icon fa fa-paperclip green"></i>
                                                <asp:Label ID="FCount" Visible="false" runat="server" Text='<%# Eval("FCount") %>'></asp:Label>

                                                <asp:LinkButton title="الملفات المرفقة" ID="LinkRepFiles" Text="الملفات المرفقة" CommandArgument='<%# Eval("ConfirmID") %>' OnCommand="LinkRepFiles_Command" runat="server"></asp:LinkButton>
                                                <div runat="server" id="Nofiles" visible="false">لايوجد ملفات مرفقة</div>

                                            </td>

                                            <td class="center">
                                                <div>
                                                    <asp:Literal ID="LitText" runat="server" Text='<%# Eval("ConfirmText") %>'></asp:Literal>
                                                </div>
                                            </td>



                                        </tr>

                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    </div>
                    <!-- div.dataTables_borderWrap -->

                </div>

                <div class="modal-footer" style="min-height: 30px">&nbsp;</div>

            </div>
        </div>
    </div>
    <div id="modalNoteReplyNew" runat="server" class="MainBox" style="display: none;">
        <div style="padding: 15px; border: 1px solid #E0E2E5; background-color: #FFF;">
            <div class="modal-header">
                <h3 class="bigger">الرد والملفات المرفقة</h3>
            </div>
            <div class="row">
                <div class="col-xs-12 col-sm-12">
                    <label class="Sub control-label">نص الرد </label>
                    <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                        <ContentTemplate>

                            <div class="wysiwyg-editor" style="font-size: 14px; font-family: Arial;" runat="server" id="editorReply"></div>

                        </ContentTemplate>
                    </asp:UpdatePanel>

                </div>
            </div>
            <div class="row" style="margin-top: 10px;">

                <div class="col-md-12">
                    <label class="col-md-2 control-label Sub no-padding-right" for="form-field-1">اضافة ملفات  </label>
                    <div class="col-md-5">

                        <asp:FileUpload ID="FileUpload3" runat="server" CssClass="fileR" />


                    </div>


                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="Red" Display="Dynamic" ValidationGroup="GFileReply" runat="server" ControlToValidate="FileUpload3" ErrorMessage="*مطلوب رفع ملف"></asp:RequiredFieldValidator>



                    <div class="col-md-5">
                        <asp:Label ID="Label5" Visible="false" runat="server" Text="مسجل ملف بنفس الاسم" ForeColor="#ff3c3c"></asp:Label>

                        <asp:Label ID="Label9" Visible="false" runat="server" Text="مسجل ملف بنفس الاسم " ForeColor="#ff3c3c"></asp:Label>
                        <asp:Label ID="ConfirmId" Style="display: none;" runat="server" Text=""></asp:Label>

                        <asp:Label ID="NoteReply" Style="display: none;" runat="server" Text=""></asp:Label>

                        <asp:Button ID="AddfileReply" CssClass="btn btn-success" Text="حفظ"  OnClick="AddfileReply_Click" ValidationGroup="GFileReply" runat="server" />

                    </div>

                </div>
            </div>
            <div id="SucFile3" runat="server" visible="false" class="alert alert-block alert-success">
                <strong>
                    <i class="ace-icon fa fa-check-square-o icon-only bigger-150"></i>
                    تم حفظ الملف بنجاح !
                </strong>

            </div>

            <div id="SucDel3" runat="server" visible="false" class="alert alert-block alert-success">
                <strong>
                    <i class="ace-icon fa fa-check-square-o icon-only bigger-150"></i>
                    تم حذف الملف بنجاح !
                </strong>

            </div>

            <div class="row" style="margin-top: 10px;">
                <div class="col-xs-12">


                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>

                            <table class=" table-striped table-bordered">

                                <thead class="TableHead">
                                    <tr>

                                        <th class="center width-70">اسم المرفق
                                        </th>
                                        <th class="center">حذف</th>
                                </thead>
                                <tbody>
                                    <asp:Repeater ID="Repeater1" runat="server">

                                        <ItemTemplate>

                                            <tr>
                                                <td class="center">

                                                    <asp:HyperLink ID="HyperLink2" NavigateUrl='<%# Eval("FPath") %>' Text='<%# Eval("FName") %>' runat="server"></asp:HyperLink>

                                                </td>


                                                <td class="center">
                                                    <!--Open Dlete file PUP-->
                                                    <a class="red" role='button' data-rel="tooltip" title="حذف" href='#DelFile_modal' data-toggle='modal' data-book-id='<%# Eval("FID") %>'>
                                                        <i class="ace-icon fa fa-close icon-only bigger-120"></i><span class='hidden'>حذف</span>
                                                    </a>
                                                </td>
                                            </tr>

                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                            </table>

                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>

            <div class="row" style="padding-top: 10px;">


                <asp:Label ID="RettComment" runat="server" Text="" CssClass="Rett" ForeColor="#ff3c3c"></asp:Label>
                <asp:Button ID="SaveComment" CssClass="btn btn-success" Text="حفظ"  OnClick="SaveComment_Click" runat="server" />


            </div>
        </div>

        <div>
            <asp:LinkButton ID="BackReplies" runat="server" OnClick="BackReplies_Click" Style="float: left; margin-top: -10px;"><i class="ace-icon fa fa-arrow-left icon-only purple bigger-250"></i></asp:LinkButton>
        </div>
    </div>
    <div id="modalNoteReplys" runat="server" class="MainBox" style="display: none;">
        <div style="padding: 15px; border: 1px solid #E0E2E5; background-color: #FFF;">
            <div class="modal-header">
                <h3 class="bigger">الردود</h3>
            </div>
            <div>
                <asp:LinkButton ID="AddNewReply" OnClick="AddNewReply_Click" runat="server">اضافة رد جديد</asp:LinkButton>
            </div>
            <div id="SucReplynew" runat="server" visible="false" class="alert alert-block alert-success">
                <strong>
                    <i class="ace-icon fa fa-check-square-o icon-only bigger-150"></i>
                    تم الحفظ !
                </strong>

            </div>


            <div id="SucReplyNote" runat="server" visible="false" class="alert alert-block alert-success">
                <strong>
                    <i class="ace-icon fa fa-check-square-o icon-only bigger-150"></i>
                    تم الحفظ !
                </strong>

            </div>
            <div id="SucReplyDel" runat="server" visible="false" class="alert alert-block alert-success">
                <strong>
                    <i class="ace-icon fa fa-check-square-o icon-only bigger-150"></i>
                    تم حذف الرد بنجاح !
                </strong>

            </div>

            <!-- div.table-responsive -->
            <div>
                <table id="dynamic-NoteReplys" class=" table-striped table-bordered">


                    <thead class="TableHead">
                        <tr>

                            <th class="center">من قام بالرد
                            </th>

                            <th class="center">تاريخ الرد 
                            </th>
                            <th class="center">الملفات المرفقة
                                                                               
                            </th>

                            <th class="center width-50">نص الرد

                            </th>
                            <th class="center">الغاء الرد

                            </th>
                        </tr>
                    </thead>

                    <tbody>
                        <asp:Repeater ID="NoteReplys" OnItemDataBound="NoteReplys_ItemDataBound" runat="server">
                            <ItemTemplate>

                                <tr>
                                    <td class="center">
                                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("EmpName") %>'></asp:Label>
                                        <hr class="center" style="margin-top: 1px; margin-bottom: 1px; border-top: 1px solid #6ad589;" />

                                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("EmpJobTitle") %>'></asp:Label>


                                    </td>
                                    <td class="center">

                                        <asp:Label ID="LblNoteStat" runat="server" Text='<%# Eval("ConfirmDate") %>'></asp:Label>
                                    </td>
                                    <td class="center">
                                        <i class="ace-icon fa fa-paperclip green"></i>
                                        <asp:Label ID="FNoteCount" Visible="false" runat="server" Text='<%# Eval("FCount") %>'></asp:Label>

                                        <asp:LinkButton title="الملفات المرفقة" ID="LinkNotFiles" Text="الملفات المرفقة" CommandArgument='<%# Eval("ConfirmID") %>' OnCommand="LnkCommentNote_Command" runat="server"></asp:LinkButton>
                                        <div runat="server" id="NoNotefiles" visible="false">لايوجد ملفات مرفقة</div>

                                    </td>

                                    <td class="center">
                                        <div>
                                            <asp:Literal ID="LitNoteText" runat="server" Text='<%# Eval("ConfirmText") %>'></asp:Literal>
                                        </div>
                                    </td>

                                    <td class="center">
                                        <asp:LinkButton CssClass="green" data-rel="tooltip" title="تعديل" ID="EditNoteReply" CommandArgument='<%#Eval("ConfirmID") + ";" +Eval("NoteID")%>' OnCommand="EditNoteReply_Command" runat="server"><i class="ace-icon fa fa-pencil icon-only bigger-120"></i></asp:LinkButton>

                                        <a class="red" role='button' data-rel="tooltip" title="حذف" href='#DelReply_modal' data-toggle='modal' data-book-id='<%#Eval("ConfirmID") + ";" +Eval("NoteID")%>'>
                                            <i class="ace-icon fa fa-close icon-only bigger-120"></i><span class='hidden'>حذف الرد</span>
                                        </a></td>

                                </tr>

                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>
            <!-- div.dataTables_borderWrap -->


            <div>
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="BackNotes_Click" Style="float: left; margin-top: -10px;"><i class="ace-icon fa fa-arrow-left icon-only purple bigger-250"></i></asp:LinkButton>
            </div>


        </div>
    </div>

    <div id="DelReply_modal" data-backdrop="static" data-keyboard="false" aria-hidden="false" class="modal fade" tabindex="-1">
        <div class="modal-dialog" style="top: 20%">
            <div class="modal-content">

                <div class="modal-body">
                    <div style="margin-top: 7px;" class="row">

                        <div class="col-sm-1" style="text-align: right;">
                            
                        </div>
                        <div class="col-lg-8" style="text-align: right;">
                            <h4 class="align-right">هل متأكد من حذف هذا الرد ؟</h4>
                        </div>
                        <div class="col-lg-3">
                            <button type="button" class="close red" data-dismiss="modal">
                                <img src="assets/images/Icons/BasicIcon/close.png" height="46" /></button>
                        </div>
                    </div>
                    <input style="display: none" type="text" runat="server" name="bookId" id="Replyy" value="" />
                </div>

                <div class="modal-footer">

                    <asp:ImageButton ID="DelReply" OnClick="DelReply_Click" Height="55" ImageAlign="AbsMiddle" ImageUrl="assets/icons/buttons/del.png" runat="server" />
                    <span><a href="#" data-dismiss="modal">
                        </a>
                    </span>
                </div>

            </div>
        </div>
    </div>

    <div id="AllFiles_modalCom" runat="server" style="display: none;">

        <div style="padding: 15px; border: 1px solid #E0E2E5; background-color: #FFF;">
            <div class="modal-header">
                <h4 class="blue bigger">الملفات المرفقة</h4>
            </div>


            <div id="SucDelRepl" style="margin-top: 2px;" runat="server" visible="false" class="alert alert-block alert-success">
                <strong>
                    <i class="ace-icon fa fa-check-square-o icon-only bigger-150"></i>
                    تم حذف الملف بنجاح !
                </strong>

            </div>
            <div class="row" style="margin-top: 10px;">
                <div class="col-md-12">

                    <asp:Label ID="LblCommID" Visible="false" runat="server" Text=""></asp:Label>

                    <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                        <ContentTemplate>

                            <table class=" table-striped table-bordered">

                                <thead class="TableHead">
                                    <tr>

                                        <th class="center">اسم المرفق
                                        </th>
                                        <th class="center">التاريخ
                                        </th>
                                        <th class="center">تحميل
                                        </th>
                                        <th class="center">حذف</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater ID="Repeater2" runat="server">

                                        <ItemTemplate>

                                            <tr>
                                                <td class="center">

                                                    <asp:HyperLink ID="HyperLink2" NavigateUrl='<%# Eval("FPath") %>' Text='<%# Eval("FName") %>' runat="server"></asp:HyperLink>

                                                </td>
                                                <td class="center">
                                                    <asp:Label ID="Label1" runat="server" Text='<%# Convert.ToDateTime(Eval("FDate")).ToShortDateString() %>'></asp:Label></td>
                                                <td class="center">
                                                    <asp:HyperLink ID="HyperLink4" NavigateUrl='<%# Eval("FPath") %>' runat="server"><img height="40" src="assets/icons/BasicIcon/download.png" /></asp:HyperLink></td>



                                                <td class="center"><a class="red" role='button' data-rel="tooltip" title="حذف" href='#DelFile_modalComm' data-toggle='modal' data-book-id='<%# Eval("FID") %>'>
                                                    <i class="ace-icon fa fa-close icon-only bigger-120"></i><span class='hidden'>حذف</span>
                                                </a></td>
                                            </tr>

                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                            </table>

                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>


        </div>

        <asp:LinkButton ID="LinkButton4" runat="server" OnClick="BackReplies_Click" Style="float: left; margin-top: -10px;"><i class="ace-icon fa fa-arrow-left icon-only purple bigger-250"></i></asp:LinkButton>
    </div>



    <div id="RepFiles_modal" runat="server" style="display: none;">



        <div style="padding: 15px; border: 1px solid #E0E2E5; background-color: #FFF;">
            <h4 class="blue bigger">الملفات المرفقة</h4>
            <div class="row">

                <div class="col-md-12">
                    <label class="control-label" for="form-field-1">اضافة ملفات  </label>

                    <div id="SucFile" runat="server" visible="false" class="alert alert-block alert-success">
                        <strong>
                            <i class="ace-icon fa fa-check-square-o icon-only bigger-150"></i>
                            تم الحفظ !
                        </strong>

                    </div>
                    <div id="ValidatFileR" class="red"></div>

                    <div class="form-group">

                        <div class="col-md-6">
                            <div class="form-group">
                                <div class="btn btn-primary btn-sm right">
                                    <span>Select file</span>
                                    <asp:FileUpload ID="FileUploadR" runat="server" />
                                </div>

                            </div>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" ForeColor="Red" Display="Dynamic" ValidationGroup="GFile" runat="server" ControlToValidate="FileUploadR" ErrorMessage="*مطلوب رفع ملف"></asp:RequiredFieldValidator>

                            <asp:Label ID="LblEroorNote" Visible="false" runat="server" Text="مسجل ملف بنفس الاسم" ForeColor="#ff3c3c"></asp:Label>

                            <asp:Label ID="LblEroor" Visible="false" runat="server" Text="مسجل ملف بنفس الاسم " ForeColor="#ff3c3c"></asp:Label>
                            <asp:Button ID="AddFile" OnClick="AddFile_Click" ValidationGroup="GFile" CssClass="btn btn-success"  Text="حفظ" runat="server" />

                            <asp:Label ID="LblRep" runat="server" Visible="false" Text=""></asp:Label>

                        </div>
                    </div>
                </div>
            </div>

            <div class="row" style="margin-top: 10px;">
                <div class="col-md-12">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>

                            <table class=" table-striped table-bordered">

                                <thead class="TableHead">
                                    <tr>

                                        <th class="center">اسم المرفق
                                        </th>
                                        <th class="center">التاريخ
                                        </th>
                                        <th class="center">تحميل
                                        </th>
                                        <th class="center">حذف</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater ID="RpeaterFiles" runat="server">

                                        <ItemTemplate>

                                            <tr>
                                                <td class="center">

                                                    <asp:HyperLink ID="HyperLink2" NavigateUrl='<%# Eval("FPath") %>' Text='<%# Eval("FName") %>' runat="server"></asp:HyperLink>

                                                </td>
                                                <td class="center">
                                                    <asp:Label ID="Label1" runat="server" Text='<%# Convert.ToDateTime(Eval("FDate")).ToShortDateString() %>'></asp:Label></td>
                                                <td class="center">
                                                    <asp:HyperLink ID="HyperLink4" NavigateUrl='<%# Eval("FPath") %>' runat="server"><img height="40" src="assets/icons/BasicIcon/download.png" /></asp:HyperLink></td>



                                                <td class="center">
                                                    <!--Open Dlete file PUP-->
                                                    <a class="red" role='button' data-rel="tooltip" title="حذف" href='#DelFile_modal' data-toggle='modal' data-book-id='<%# Eval("FID") %>'>
                                                        <i class="ace-icon fa fa-close icon-only bigger-120"></i><span class='hidden'>حذف</span>
                                                    </a>
                                                </td>
                                            </tr>

                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                            </table>

                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>




        </div>
        <div>
            <asp:LinkButton ID="LinkButton8" runat="server" OnClick="BackNotes_Click" Style="float: left; margin-top: -10px;"><i class="ace-icon fa fa-arrow-left icon-only purple bigger-250"></i></asp:LinkButton>
        </div>
    </div>
    <!------------------- Update Note------------>



    <div id="UPDNot" style="display: none" runat="server" class="MainBox">





        <div style="padding: 15px; border: 1px solid #E0E2E5; background-color: #FFF;">

            <div class="row">



                <div class="col-md-12">
                    <div class="row">
                        <div class="col-md-12 col-md-6" style="display: none;">

                            <label class="col-md-4 Sub control-label">أهمية التوصية</label>

                            <div class="col-md-8">

                                <div>
                                    <asp:RadioButtonList ID="RadioButtonList01" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="3"><img height="40" src="assets/images/Icons/levels/L1/high.png" /></asp:ListItem>
                                        <asp:ListItem Value="2"><img height="40" src="assets/images/Icons/levels/L1/mid.png" /></asp:ListItem>
                                        <asp:ListItem Value="1"><img height="40"  src="assets/images/Icons/levels/L1/low.png" /></asp:ListItem>

                                    </asp:RadioButtonList>

                                </div>

                            </div>
                        </div>
                        <div class="col-md-6">
                            <label class="col-md-3 Sub control-label">التكرار</label>
                            <div class="col-md-9">
                                <label>
                                    <input name="switch-field-1" runat="server" id="LblRepeat0" class="ace ace-switch ace-switch-7" type="checkbox" />
                                    <span class="lbl"></span>
                                </label>
                            </div>


                        </div>
                        <div class="col-md-6">

                            <label class="col-md-3 Sub control-label">تاريخ التنفيذ</label>
                            <div class="col-md-9">

                                <div class="input-group">
                                    <span class="input-group-addon">
                                        <i class="fa fa-calendar bigger-110"></i>
                                    </span>
                                    <input class="form-control date-picker" id="DFromNote" runat="server" type="text" placeholder="يوم - شهر -سنة" data-date-format="yyyy-mm-dd" />

                                </div>
                            </div>



                        </div>

                    </div>
                    <div class="row">
                        <div class="col-md-12">

                            <label class="col-md-3 Sub control-label">حالة معالجة التوصية</label>

                            <div class="col-md-9">

                                <div>
                                    <asp:RadioButtonList ID="RadioButtonList02" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Value='3'><img height="40"  src="assets/icons/levels/L2/solved.png"  /></asp:ListItem>
                                        <asp:ListItem Value='2'><img height="40" src="assets/icons/levels/L2/under.png" /></asp:ListItem>
                                        <asp:ListItem Value='1'><img height="40"  src="assets/icons/levels/L2/hold.png" /></asp:ListItem>
                                        <asp:ListItem Value="5"><img height="40" src="assets/icons/levels/L2/closed.png" /></asp:ListItem>
                                        <asp:ListItem Value="4"><img height="40" src="assets/icons/levels/L2/notstart.png" /></asp:ListItem>
                                    </asp:RadioButtonList>

                                </div>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" InitialValue=" " ControlToValidate="RadioButtonList02" runat="server" ValidationGroup="GU" ForeColor="#ff3c3c" ErrorMessage="مطلوب تحديد  معالجة التوصية  *"></asp:RequiredFieldValidator>

                            </div>
                        </div>



                    </div>
                    <div class="row">

                        <div class="col-md-12">
                            <label class="col-md-2 control-label Sub no-padding-right" for="form-field-1">اضافة ملفات  </label>
                            <div class="col-md-5">
                                <div class="form-group">
                                    <div class="btn btn-primary btn-sm right">
                                        <span>Select file</span>

                                        <asp:FileUpload ID="FileUpload02" runat="server" CssClass="FileNoteUPD" />
                                    </div>

                                </div>

                            </div>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" ForeColor="Red" Display="Dynamic" ValidationGroup="GFile7" runat="server" ControlToValidate="FileUpload02" ErrorMessage="*مطلوب رفع ملف"></asp:RequiredFieldValidator>

                            <div class="col-md-5">
                                <asp:Label ID="NoteFileExistUPD" Visible="false" runat="server" Text="مسجل ملف بنفس الاسم" ForeColor="#ff3c3c"></asp:Label>

                                <asp:Button ID="AddNoteFileUPD"  Text="حفظ" CssClass="btn btn-success" OnClick="AddNoteFileUPD_Click" ValidationGroup="GFile7" runat="server" />


                                <div id="SucNoteFileUpd" style="margin-top: 2px;" runat="server" visible="false" class="alert alert-block alert-success">
                                    <strong>
                                        <i class="ace-icon fa fa-check-square-o icon-only bigger-150"></i>
                                        تم الحفظ !
                                    </strong>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                            <ContentTemplate>

                                <table class=" table-striped table-bordered">

                                    <thead class="TableHead">
                                        <tr>

                                            <th class="center">اسم المرفق
                                            </th>
                                            <th class="center">التاريخ
                                            </th>
                                            <th class="center">تحميل
                                            </th>
                                            <th class="center">حذف</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Repeater ID="RepeatNoteUPD" runat="server">

                                            <ItemTemplate>

                                                <tr>
                                                    <td class="center">

                                                        <asp:HyperLink ID="HyperLink2" NavigateUrl='<%# Eval("FPath") %>' Text='<%# Eval("FName") %>' runat="server"></asp:HyperLink>

                                                    </td>
                                                    <td class="center">
                                                        <asp:Label ID="Label1" runat="server" Text='<%# Convert.ToDateTime(Eval("FDate")).ToShortDateString() %>'></asp:Label></td>
                                                    <td class="center">
                                                        <asp:HyperLink ID="HyperLink4" NavigateUrl='<%# Eval("FPath") %>' runat="server"><img height="40" src="assets/icons/BasicIcon/download.png" /></asp:HyperLink></td>


                                                    <td class="center">
                                                        <!--Open Dlete file PUP-->
                                                        <a class="red" role='button' data-rel="tooltip" title="حذف" href='#DelFile_modal' data-toggle='modal' data-book-id='<%# Eval("FID") %>'>
                                                            <i class="ace-icon fa fa-close icon-only bigger-120"></i><span class='hidden'>حذف</span>
                                                        </a>
                                                    </td>
                                                </tr>

                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </tbody>
                                </table>

                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-12 col-md-12">
                        <label class="Sub control-label">نص التوصية </label>
                        <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                            <ContentTemplate>
                                <div style="font-size: 14px; font-family: Arial;" class="wysiwyg-editor" runat="server" id="editor2"></div>
                            </ContentTemplate>
                        </asp:UpdatePanel>

                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12 col-md-12">
                        <label class="Sub control-label">الاجراء التصحيحي من قبل الإدارة متوسطة  </label>
                        <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                            <ContentTemplate>


                                <div style="font-size: 14px; font-family: Arial;" class="wysiwyg-editor" runat="server" id="editor2N"></div>
                            </ContentTemplate>
                        </asp:UpdatePanel>

                    </div>
                </div>

            </div>
        </div>

        <div class="row">
            <div class="modal-footer">
                <asp:Label ID="Rett2" runat="server" Text="" CssClass="Rett" ForeColor="#ff3c3c"></asp:Label>
                <asp:Label ID="ReqDatesNote" Style="color: red; display: none; font-size: 14px; font-weight: bold;" runat="server" Text="* مطلوب تحديد مدة زمنية لمعالجة التوصية خلالها  "></asp:Label>

                <asp:Label ID="ErrorDayNote" Style="color: red; display: none; font-size: 14px; font-weight: bold;" runat="server" Text=" يجب أن يكون تاريخ الإنتهاء أكبر من أو يساوى تاريخ اليوم الجارى "></asp:Label>
                <asp:Label ID="LblNotFile" Style="display: none;" runat="server" Text="الملفات المرفقة لها نفس الاسم" ForeColor="#ff3c3c"></asp:Label>


                <asp:HiddenField ID="RepCodeMail" runat="server" />
                <asp:HiddenField ID="ReptitleMail" runat="server" />
                <asp:HiddenField ID="NotStatMail" runat="server" />
                <asp:HiddenField ID="NoteCountMail" runat="server" />
                <asp:HiddenField ID="RepDepartMail" runat="server" />
                <asp:HiddenField ID="RepSectionMail" runat="server" />

                <asp:HiddenField ID="RepDepartIDMail" runat="server" />
                <asp:HiddenField ID="RepSectionIDMail" runat="server" />


                <asp:ImageButton ID="UpdateNote" OnClick="UpdateNote_Click" ImageUrl="assets/images/Icons/buttons/editnote.png" ValidationGroup="GU" Height="40" runat="server" />


                <asp:Label ID="LblRepID" runat="server" Visible="false" Text=""></asp:Label>

            </div>

        </div>

        <asp:LinkButton ID="LinkButton14" runat="server" OnClick="BackNotes_Click" Style="float: left; margin-top: -10px;"><i class="ace-icon fa fa-arrow-left icon-only purple bigger-250"></i></asp:LinkButton>



    </div>



    <!---------------------------------->
    <!-- Delete Note PUP-->
    <div id="Delete_modal" data-backdrop="static" data-keyboard="false" aria-hidden="false" class="modal fade" tabindex="-1">
        <div class="modal-dialog" style="top: 20%">
            <div class="modal-content">

                <div class="modal-body">


                    <div style="margin-top: 7px;" class="row">

                        <div class="col-sm-1" style="text-align: right;">
                            
                        </div>
                        <div class="col-lg-8" style="text-align: right;">
                            <h4 class="align-right">هل أنت متأكد من حذف هذه التوصية ؟ </h4>
                        </div>
                        <div class="col-lg-3">
                            <button type="button" class="close red" data-dismiss="modal">
                                <img src="assets/images/Icons/BasicIcon/close.png" height="46" /></button>
                        </div>
                    </div>
                    <input style="display: none" type="text" runat="server" name="bookId" id="NotDel" value="" />
                </div>
                <div class="modal-footer">
                    <asp:ImageButton ID="DelNote" OnClick="DelNote_Click" Height="55" ImageAlign="AbsMiddle" ImageUrl="assets/icons/buttons/del.png" runat="server" />

                    <a href="#" data-dismiss="modal">
                        </a>
                </div>
            </div>
        </div>
    </div>


    <!---------------------------------->
    <!-- Delete Report PUP-->
    <div id="DeleteReport_modal" data-backdrop="static" data-keyboard="false" aria-hidden="false" class="modal fade" tabindex="-1">
        <div class="modal-dialog" style="top: 20%">
            <div class="modal-content">

                <div class="modal-body">
                    <div style="margin-top: 7px;" class="row">

                        <div class="col-sm-1" style="text-align: right;">
                            
                        </div>
                        <div class="col-lg-8" style="text-align: right;">
                            <h4 class="align-right">هل أنت متأكد من حذف هذه الملاحظة ؟ </h4>
                        </div>
                        <div class="col-lg-3">
                            <button type="button" class="close red" data-dismiss="modal">
                                <img src="assets/images/Icons/BasicIcon/close.png" height="46" /></button>
                        </div>
                    </div>
                    <input style="display: none" type="text" runat="server" name="BookReport" id="BookReport" value="" />
                </div>

                <div class="modal-footer">

                    <asp:ImageButton ID="DelReport" OnClick="DelReport_Click" Height="55" ImageAlign="AbsMiddle" ImageUrl="assets/icons/buttons/del.png" runat="server" />
                    <span><a href="#" data-dismiss="modal">
                        </a>
                    </span>
                </div>

            </div>
        </div>
    </div>

    <!--------------------------------->






    <!-- Delete File PUP-->
    <div id="DelFile_modal" data-backdrop="static" data-keyboard="false" style="z-index: 1000000" aria-hidden="false" class="modal fade" tabindex="-1">
        <div class="modal-dialog">
            <div class="modal-content">

                <div class="modal-body">
                    <div style="margin-top: 7px;" class="row">

                        <div class="col-sm-1" style="text-align: right;">
                            
                        </div>
                        <div class="col-lg-8" style="text-align: right;">
                            <h4 class="align-right">هل أنت متأكد من حذف هذا الملف ؟ </h4>
                        </div>
                        <div class="col-lg-3">
                            <button type="button" class="close red" data-dismiss="modal">
                                <img src="assets/images/Icons/BasicIcon/close.png" height="46" /></button>
                        </div>
                    </div>
                    <input style="display: none" type="text" runat="server" name="FileId" id="FileId" value="" />
                </div>

                <div class="modal-footer">

                    <asp:ImageButton ID="DelFile" OnClick="DelFile_Click" Height="55" ImageAlign="AbsMiddle" ImageUrl="assets/icons/buttons/del.png" runat="server" />
                    <span><a href="#" data-dismiss="modal">
                        </a>
                    </span>
                </div>

            </div>
        </div>
    </div>

    <div id="AllFiles_modal" data-backdrop="static" data-keyboard="false" style="z-index: 300000" class="modal fade" tabindex="-1">
        <div class="modal-dialog">
            <div class="modal-content">

                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="blue bigger">الملفات المرفقة</h4>
                </div>

                <div class="modal-body">



                    <div class="row" style="margin-top: 10px;">
                        <div class="col-md-12">


                            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                <ContentTemplate>

                                    <table class=" table-striped table-bordered">

                                        <thead class="TableHead">
                                            <tr>

                                                <th class="center">اسم المرفق
                                                </th>
                                                <th class="center">التاريخ
                                                </th>
                                                <th class="center">تحميل
                                                </th>
                                                <th class="center">حذف</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:Repeater ID="RepAttach" runat="server">

                                                <ItemTemplate>

                                                    <tr>
                                                        <td class="center">

                                                            <asp:HyperLink ID="HyperLink2" NavigateUrl='<%# Eval("FPath") %>' Text='<%# Eval("FName") %>' runat="server"></asp:HyperLink>

                                                        </td>
                                                        <td class="center">
                                                            <asp:Label ID="Label1" runat="server" Text='<%# Convert.ToDateTime(Eval("FDate")).ToShortDateString() %>'></asp:Label></td>
                                                        <td class="center">
                                                            <asp:HyperLink ID="HyperLink4" NavigateUrl='<%# Eval("FPath") %>' runat="server"><img height="40" src="assets/icons/BasicIcon/download.png" /></asp:HyperLink></td>




                                                    </tr>

                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </tbody>
                                    </table>

                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                    <div class="row">
                        <div class="modal-footer">
                            &nbsp;
                        </div>

                    </div>



                </div>

            </div>

        </div>
    </div>
    <!--------------------------------->

    <div id="DelFile_modalComm" data-backdrop="static" data-keyboard="false" style="z-index: 1000000" aria-hidden="false" class="modal fade" tabindex="-1">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="widget-header">
                    <button type="button" class="close red" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                    <h4 class="modal-title">تأكيد الحذف</h4>
                </div>
                <div class="modal-body">


                    <p>هل متأكد من حذف هذا الملف؟</p>
                    <input style="display: none" type="text" runat="server" name="FileId" id="FileIdComm" value="" />
                </div>
                <div class="modal-footer">

                    <asp:ImageButton ID="ImageButton3" OnClick="ImageButton3_Click" Height="55" ImageAlign="AbsMiddle" ImageUrl="assets/icons/buttons/del.png" runat="server" />
                    <span><a href="#" data-dismiss="modal">
                        </a>
                    </span>
                </div>
            </div>
        </div>
    </div>

    <!-- Log Data Start -->
    <asp:HiddenField ID="HiddenLogText" runat="server"  />
    <!-- Log Data End -->
    <asp:HiddenField ID="ConfirmSuc" runat="server" />
    <asp:HiddenField ID="hfRep" runat="server" />
    <asp:HiddenField ID="hf" runat="server" />
    <asp:HiddenField ID="hf1N" runat="server" />
    <asp:HiddenField ID="hf2N" runat="server" />
    <asp:HiddenField ID="hf2" runat="server" />

    <asp:HiddenField ID="hf3" runat="server" />
    <asp:HiddenField ID="HiddenPost" runat="server" />
    <asp:HiddenField ID="HiddenSearch" runat="server" />
    <asp:HiddenField ID="RepImpTextUHid" runat="server" />
    <asp:HiddenField ID="HiddenReplies" runat="server" />
    <asp:HiddenField ID="PartText1" runat="server" />

    <asp:HiddenField ID="PartText2" runat="server" />

    <asp:Label ID="LblView" Style="display: none;" runat="server" Text=""></asp:Label>
    <asp:Label ID="LblEditID" Style="display: none;" runat="server" Text=""></asp:Label>

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

    <link href="assets/font-awesome/4.5.0/css/font-awesome.min.css" rel="stylesheet" />

    <!-- page specific plugin scripts -->
    <script src="assets/js/jquery.ui.touch-punch.min.js"></script>
    <script src="assets/js/markdown.min.js"></script>
    <script src="assets/js/bootstrap-markdown.min.js"></script>
    <script src="assets/js/jquery.hotkeys.index.min.js"></script>
    <script src="assets/js/bootstrap-wysiwyg.min.js"></script>
    <script src="assets/js/bootbox.js"></script>
    <script src="assets/js/spinbox.min.js"></script>
    <script src="assets/js/bootstrap-datepicker.min.js"></script>
    <script src="assets/js/bootstrap-timepicker.min.js"></script>
    <script src="assets/js/moment.min.js"></script>
    <script src="assets/js/daterangepicker.min.js"></script>
    <script src="assets/js/bootstrap-datetimepicker.min.js"></script>
    <script src="assets/js/jquery.knob.min.js"></script>
    <script src="assets/js/autosize.min.js"></script>

    <script type="text/javascript">
        /// Log Data Start
         function HiddenLog() {
             $("#<%=HiddenPost.ClientID %>").val("Log");
             var bookId = $(LogHide).data('book-id');

             $("#<%=HiddenLogText.ClientID %>").val(bookId);
                __doPostBack();

           
        }
        /// Log Data Start
        function myFunction() {

            if (($("#<%=DateFromSearch.ClientID %>").val().length > 0) && ($("#<%=HiddenSearch.ClientID %>").val().length <= 0)) {

                $("#<%=HiddenSearch.ClientID %>").val("1");
                __doPostBack();

            }
        }

        function CheckRepliesFun() {

            $("#<%=HiddenReplies.ClientID %>").val("1");
            __doPostBack();

        }
        $('#DelFile_modalComm').on('show.bs.modal', function (e) {

            var bookId = $(e.relatedTarget).data('book-id');

            // Set bookId label equal the File ID when Opening the Delete PUP to be using in server side
            $(e.currentTarget).find($("#<%=FileIdComm.ClientID%>")).val(bookId);


        });
        function CheckRepeate() {

            $("#<%=HiddenPost.ClientID %>").val("1");
            __doPostBack();
        }
        /* Put your code to run before UpdatePanel begins async postback here */
        function beforeAsyncPostBack() {
           

            var escapeRep = document.createElement('textarea');
            escapeRep.textContent = document.getElementById("<%=editorReply.ClientID%>").innerHTML;
            $("#<%=hfRep.ClientID %>").val(editorReply.innerHTML);
            // Editor2 

            var escape2 = document.createElement('textarea');
            escape2.textContent = document.getElementById("<%=editor2.ClientID%>").innerHTML;
            $("#<%=hf2.ClientID %>").val(escape2.innerHTML);

            var escape3 = document.createElement('textarea');
            escape3.textContent = document.getElementById("<%=editor3.ClientID%>").innerHTML;
            $("#<%=hf3.ClientID %>").val(escape3.innerHTML);

            var EsRepImpTextU = document.createElement('textarea');

            EsRepImpTextU.textContent = document.getElementById("<%=RepImpTextU.ClientID%>").innerText;
            $("#<%=RepImpTextUHid.ClientID %>").val(EsRepImpTextU.innerHTML);



            
            var escape2N = document.createElement('textarea');
            escape2N.textContent = document.getElementById("<%=editor2N.ClientID%>").innerHTML;
            $("#<%=hf2N.ClientID %>").val(escape2N.innerHTML);

        }

        /* Put your code to run after UpdatePanel finishes async postback here */
        function afterAsyncPostBack() {

            var escapeRep = document.createElement('textarea');

            escapeRep.innerHTML = $("#<%=hfRep.ClientID %>").val();
            document.getElementById("<%=editorReply.ClientID%>").innerHTML = escapeRep.textContent;

            SetMVal();

        }

        /* Don't mess with any of the below code */
        Sys.Application.add_init(appl_init);

        function appl_init() {
            var pgRegMgr = Sys.WebForms.PageRequestManager.getInstance();
            pgRegMgr.add_beginRequest(beforeAsyncPostBack);
            pgRegMgr.add_endRequest(afterAsyncPostBack);
        }
    </script>
    <!-- inline scripts related to this page -->
    <script type="text/javascript">


        function SetMVal() {

            var escape = document.createElement('textarea');

            escape.innerHTML = $("#<%=hf.ClientID %>").val();
            document.getElementById("<%=editor1.ClientID%>").innerHTML = escape.textContent;


            var escape2 = document.createElement('textarea');

            escape2.innerHTML = $("#<%=hf2.ClientID %>").val();
            document.getElementById("<%=editor2.ClientID%>").innerHTML = escape2.textContent;

            var escape3 = document.createElement('textarea');

            escape3.innerHTML = $("#<%=hf3.ClientID %>").val();
            document.getElementById("<%=editor3.ClientID%>").innerHTML = escape3.textContent;


            EsRepImpTextU.innerHTML = $("#<%=RepImpTextUHid.ClientID %>").val();
            EsRepImpTextU.style.cssText = "font-family:Arial;font-size:medium";
            document.getElementById("<%=RepImpTextU.ClientID%>").innerHTML = EsRepImpTextU.textContent;


            var escape1N = document.createElement('textarea');

            escape1N.innerHTML = $("#<%=hf1N.ClientID %>").val();
            document.getElementById("<%=editor1N.ClientID%>").innerHTML = escape1N.textContent;
            alert("aa");

            var escape2N = document.createElement('textarea');

            escape2N.innerHTML = $("#<%=hf2N.ClientID %>").val();
            document.getElementById("<%=editor2N.ClientID%>").innerHTML = escape2N.textContent;
        }

        function GetReplys() {

            $('#modal-Replys').modal({ show: true, backdrop: false });
            var myTable = $('#dynamic-Replys')
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



        }

        
        function GetNoteReplys() {
            var myTable = $('#dynamic-NoteReplys')
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

        }


        function RemoveDetails(ModalName) {
            $(ModalName).modal('hide');

        }
        function GetAttach() {
            $(".remove").click();

            $('#AllFiles_modal').modal({ show: true, backdrop: false });



            $('#RepFiles_modal').modal('hide');
            $('#modal-Replys').modal({ show: true, backdrop: false });


        }

        

        function PrintDiv() {

            var contents = document.getElementById("dvContents").innerHTML;
            var frame1 = document.createElement('iframe');
            frame1.name = "frame1";
            frame1.style.position = "absolute";
            frame1.style.top = "-1000000px";
            document.body.appendChild(frame1);
            var frameDoc = frame1.contentWindow ? frame1.contentWindow : frame1.contentDocument.document ? frame1.contentDocument.document : frame1.contentDocument;
            frameDoc.document.open();
            frameDoc.document.write('<html><head><link rel="stylesheet" href="assets/css/ace.min.css" class="ace-main-stylesheet" /><link rel="stylesheet" href="assets/css/ace-part2.min.css" class="ace-main-stylesheet" /> <link rel="stylesheet" href="assets/css/ace-skins.min.css" /><link rel="stylesheet" href="assets/css/ace-rtl.min.css" /><link rel="stylesheet" href="assets/css/bootstrap.min.css" /><title>طلب جديد</title>');
            frameDoc.document.write('</head><body style="width:100%" class="no-skin rtl">');
            frameDoc.document.write(contents);
            frameDoc.document.write('</body></html>');
            frameDoc.document.close();
            setTimeout(function () {
                window.frames["frame1"].focus();
                window.frames["frame1"].print();
                document.body.removeChild(frame1);
            }, 500);
            return false;
        }

        function PrintDivRep() {

            var contents = document.getElementById("dvContentsRep").innerHTML;
            var frame1 = document.createElement('iframe');
            frame1.name = "frame1";
            frame1.style.position = "absolute";
            frame1.style.top = "-1000000px";
            document.body.appendChild(frame1);
            var frameDoc = frame1.contentWindow ? frame1.contentWindow : frame1.contentDocument.document ? frame1.contentDocument.document : frame1.contentDocument;
            frameDoc.document.open();
            frameDoc.document.write('<html><head><link rel="stylesheet" href="assets/css/ace.min.css" class="ace-main-stylesheet" /><link rel="stylesheet" href="assets/css/ace-part2.min.css" class="ace-main-stylesheet" /> <link rel="stylesheet" href="assets/css/ace-skins.min.css" /><link rel="stylesheet" href="assets/css/ace-rtl.min.css" /><link rel="stylesheet" href="assets/css/bootstrap.min.css" /><title>طلب جديد</title>');
            frameDoc.document.write('</head><body style="width:100%" class="no-skin rtl">');
            frameDoc.document.write(contents);
            frameDoc.document.write('</body></html>');
            frameDoc.document.close();
            setTimeout(function () {
                window.frames["frame1"].focus();
                window.frames["frame1"].print();
                document.body.removeChild(frame1);
            }, 500);
            return false;
        }

        var prm = Sys.WebForms.PageRequestManager.getInstance();
        if (prm != null) {
            prm.add_endRequest(function (sender, e) {
                if (sender._postBackSettings.panelsToUpdate != null) {


                    $("[id*=chkAll]").bind("click", function () {

                        if ($("[id*=chkAll]").is(":checked")) {
                            $("[id*=PermChecks] input").prop("checked", true);

                        } else {
                            $("[id*=PermChecks] input").prop("checked", false);
                        }
                    });
                    $("[id*=PermChecks] input").bind("click", function () {

                        if ($("[id*=PermChecks] input:checked").length == $("[id*=PermChecks] input").length) {
                            $("[id*=chkAll]").prop("checked", true);
                        } else {
                            $("[id*=chkAll]").prop("checked", false);
                        }
                    });

                    //initiate dataTables plugin

                    FillTable();
                    DisplayCurrentTime();






                    ////  Bind FileID in the delete Modal

                    $('#DelFile_modal').on('show.bs.modal', function (e) {
                        var bookId = $(e.relatedTarget).data('book-id');

                        // Set bookId label equal the File ID when Opening the Delete PUP to be using in server side
                        $(e.currentTarget).find($("#<%=FileId.ClientID%>")).val(bookId);


                    });

                }
            });
        };



        function DisplayCurrentTime() {

            $('#DelReply_modal').on('show.bs.modal', function (e) {

                var bookId = $(e.relatedTarget).data('book-id');

                // Set bookId label equal the File ID when Opening the Delete PUP to be using in server side
                $(e.currentTarget).find($("#<%=Replyy.ClientID%>")).val(bookId);


            });

            $('.fileR').ace_file_input({
                no_file: 'No File ...',
                btn_choose: 'Choose',
                btn_change: 'Change',
                droppable: false,
                onchange: null,
                thumbnail: false //| true | large
                //whitelist:'gif|png|jpg|jpeg'
                //blacklist:'exe|php'
                //onchange:''
                //
            });

            $("#<%=editorReply.ClientID %>").ace_wysiwyg({
                toolbar:
                    [

                        'print',

                        'togglescreen',
                        { name: 'bold', className: 'btn-info' },
                        { name: 'italic', className: 'btn-info' },
                        { name: 'strikethrough', className: 'btn-info' },
                        { name: 'underline', className: 'btn-info' },
                        null,
                        { name: 'insertunorderedlist', className: 'btn-success' },
                        { name: 'insertorderedlist', className: 'btn-success' },
                        { name: 'outdent', className: 'btn-purple' },
                        { name: 'indent', className: 'btn-purple' },
                        null,
                        { name: 'justifyleft', className: 'btn-primary' },
                        { name: 'justifycenter', className: 'btn-primary' },
                        { name: 'justifyright', className: 'btn-primary' },
                        { name: 'justifyfull', className: 'btn-inverse' },
                        null,
                        { name: 'createLink', className: 'btn-pink' },
                        { name: 'unlink', className: 'btn-pink' },
                        null,
                        'foreColor',
                        null,
                        { name: 'undo', className: 'btn-grey' },
                        { name: 'redo', className: 'btn-grey' }
                    ]

            }).prev().addClass('wysiwyg-style2');


            $("#<%=SaveComment.ClientID %>").click(function (e) {

                var escape = document.createElement('textarea');
                escape.textContent = document.getElementById("<%=editorReply.ClientID%>").innerHTML;
                $("#<%=hfRep.ClientID %>").val(escape.innerHTML);
            })

              $("#<%=AddNoteFile.ClientID %>").click(function (e) {

                var escape = document.createElement('textarea');
                escape.textContent = document.getElementById("<%=editor1.ClientID%>").innerHTML;
                  $("#<%=hf.ClientID %>").val(escape.innerHTML);


                  var escape2 = document.createElement('textarea');
                escape2.textContent = document.getElementById("<%=editor1N.ClientID%>").innerHTML;
                $("#<%=hf1N.ClientID %>").val(escape2.innerHTML);
            })
            $('.date-picker').datepicker({
                autoclose: true,
                todayHighlight: true
            })
            $('.fromSearch').datepicker({
                autoclose: true,
                minViewMode: 1,
                format: 'mm-yyyy'
            }).on('changeDate', function (ev) {
                $("#<%=HiddenSearch.ClientID %>").val("1");
                    __doPostBack();
                });
            $("body").removeAttr("style");


            if ((document.getElementById("<%=LblViews.ClientID%>").innerHTML == "Rep")) {
                GetFiles();
            }
            if ((document.getElementById("<%=LblViews.ClientID%>").innerHTML == "Not")) {
                GetFiles();
            }

            if ((document.getElementById("<%=LblViews.ClientID%>").innerHTML == "Conf")) {
                $('#modal-Replys').modal({ show: true, backdrop: false });

                var myTable = $('#dynamic-Replys')
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

            }


            if ((document.getElementById("<%=LblUpdate.ClientID%>").innerHTML != "")) {

                $('.modal').modal('hide');

                $('#UpdateReport_modal').modal({ show: true, backdrop: false });



            }






            $("#<%=editor2.ClientID %>").ace_wysiwyg({
                toolbar:
                    [

                        'print',

                        'togglescreen',
                        { name: 'bold', className: 'btn-info' },
                        { name: 'italic', className: 'btn-info' },
                        { name: 'strikethrough', className: 'btn-info' },
                        { name: 'underline', className: 'btn-info' },
                        null,
                        { name: 'insertunorderedlist', className: 'btn-success' },
                        { name: 'insertorderedlist', className: 'btn-success' },
                        { name: 'outdent', className: 'btn-purple' },
                        { name: 'indent', className: 'btn-purple' },
                        null,
                        { name: 'justifyleft', className: 'btn-primary' },
                        { name: 'justifycenter', className: 'btn-primary' },
                        { name: 'justifyright', className: 'btn-primary' },
                        { name: 'justifyfull', className: 'btn-inverse' },
                        null,
                        { name: 'createLink', className: 'btn-pink' },
                        { name: 'unlink', className: 'btn-pink' },
                        null,
                        'foreColor',
                        null,
                        { name: 'undo', className: 'btn-grey' },
                        { name: 'redo', className: 'btn-grey' }
                    ]

            }).prev().addClass('wysiwyg-style2');


            $('textarea[data-provide="markdown"]').each(function () {
                var $this = $(this);

                if ($this.data('markdown')) {
                    $this.data('markdown').showEditor();
                }
                else $this.markdown()

                $this.parent().find('.btn').addClass('btn-white');
            })


            if (document.getElementById("<%=LblViews.ClientID%>").innerHTML == "NotUPD") {
                $('#UpdateReport_modal').modal('hide');


            }




            if (document.getElementById("<%=LblViews.ClientID%>").innerHTML == "NewNot") { GetNewNote(); }




            $("#<%=editor2N.ClientID %>").ace_wysiwyg({
                toolbar:
                    [

                        'print',

                        'togglescreen',
                        { name: 'bold', className: 'btn-info' },
                        { name: 'italic', className: 'btn-info' },
                        { name: 'strikethrough', className: 'btn-info' },
                        { name: 'underline', className: 'btn-info' },
                        null,
                        { name: 'insertunorderedlist', className: 'btn-success' },
                        { name: 'insertorderedlist', className: 'btn-success' },
                        { name: 'outdent', className: 'btn-purple' },
                        { name: 'indent', className: 'btn-purple' },
                        null,
                        { name: 'justifyleft', className: 'btn-primary' },
                        { name: 'justifycenter', className: 'btn-primary' },
                        { name: 'justifyright', className: 'btn-primary' },
                        { name: 'justifyfull', className: 'btn-inverse' },
                        null,
                        { name: 'createLink', className: 'btn-pink' },
                        { name: 'unlink', className: 'btn-pink' },
                        null,
                        'foreColor',
                        null,
                        { name: 'undo', className: 'btn-grey' },
                        { name: 'redo', className: 'btn-grey' }
                    ]

            }).prev().addClass('wysiwyg-style2');






            $('[data-toggle="buttons"] .btn').on('click', function (e) {
                var target = $(this).find('input[type=radio]');
                var which = parseInt(target.val());
                var toolbar = $("#<%=editor1.ClientID %>").prev().get(0);
                if (which >= 1 && which <= 4) {
                    toolbar.className = toolbar.className.replace(/wysiwyg\-style(1|2)/g, '');
                    if (which == 1) $(toolbar).addClass('wysiwyg-style1');
                    else if (which == 2) $(toolbar).addClass('wysiwyg-style2');
                    if (which == 4) {
                        $(toolbar).find('.btn-group > .btn').addClass('btn-white btn-round');
                    } else $(toolbar).find('.btn-group > .btn-white').removeClass('btn-white btn-round');
                }
            });

            ////////////////////////////////////Update Report
            $("#<%=UpdateReport.ClientID %>").click(function (e) {

                var escape = document.createElement('textarea');
                escape.textContent = document.getElementById("<%=editor3.ClientID%>").innerHTML;




                $("#<%=hf3.ClientID %>").val(escape.innerHTML);

                var EsRepImpTextU = document.createElement('textarea');
                EsRepImpTextU.textContent = document.getElementById("<%=RepImpTextU.ClientID%>").innerHTML;


                $("#<%=RepImpTextUHid.ClientID %>").val(EsRepImpTextU.innerHTML);

            });
            /////////////////////////////////// Update Note

            $("#<%=UpdateNote.ClientID %>").click(function (e) {

                var escape = document.createElement('textarea');
                escape.textContent = document.getElementById("<%=editor2.ClientID%>").innerHTML;
                var escape2N = document.createElement('textarea');
                escape2N.textContent = document.getElementById("<%=editor2N.ClientID%>").innerHTML;
                $("#<%=hf2N.ClientID %>").val(escape2N.innerHTML);



                $("#<%=hf2.ClientID %>").val(escape.innerHTML);

                if ($("#<%=DFromNote.ClientID %>").val().length <= 0) {


                    document.getElementById("<%=ReqDatesNote.ClientID%>").style.display = "block";
                    e.preventDefault();



                }
                else {
                    document.getElementById("<%=ReqDatesNote.ClientID%>").style.display = "none";

                }

            });
            ////////////////// Check File Added
            $("#<%=AddfileReply.ClientID %>").click(function (e) {

                var escape1N = document.createElement('textarea');
                escape1N.textContent = document.getElementById("<%=editorReply.ClientID%>").innerHTML;
                  $("#<%=hfRep.ClientID %>").val(escape1N.innerHTML);

            });

            ////////////////////// Save new note
            $("#<%=Save.ClientID %>").click(function (e) {

                var escape = document.createElement('textarea');
                escape.textContent = document.getElementById("<%=editor1.ClientID%>").innerHTML;
                 $("#<%=hf.ClientID %>").val(escape.innerHTML);
                var escape1N = document.createElement('textarea');
                escape1N.textContent = document.getElementById("<%=editor1N.ClientID%>").innerHTML;
                $("#<%=hf1N.ClientID %>").val(escape1N.innerHTML);



                $("#<%=PartText2.ClientID %>").val(document.getElementById("<%=editor1.ClientID%>").innerHTML.substring(0, 50));


                $("#<%=hf.ClientID %>").val(escape.innerHTML);

                if ($("#<%=DFromNoteUDP.ClientID %>").val().length <= 0) {


                    document.getElementById("<%=ReqDates.ClientID%>").style.display = "block";
                    e.preventDefault();



                }
                else {
                    document.getElementById("<%=ReqDates.ClientID%>").style.display = "none";

                }

            });







            $('textarea[data-provide="markdown"]').each(function () {
                var $this = $(this);

                if ($this.data('markdown')) {
                    $this.data('markdown').showEditor();
                }
                else $this.markdown()

                $this.parent().find('.btn').addClass('btn-white');
            })



            if (typeof jQuery.ui !== 'undefined' && ace.vars['webkit']) {

                var lastResizableImg = null;
                function destroyResizable() {
                    if (lastResizableImg == null) return;
                    lastResizableImg.resizable("destroy");
                    lastResizableImg.removeData('resizable');
                    lastResizableImg = null;
                }

                var enableImageResize = function () {
                    $('.wysiwyg-editor')
                        .on('mousedown', function (e) {
                            var target = $(e.target);
                            if (e.target instanceof HTMLImageElement) {
                                if (!target.data('resizable')) {
                                    target.resizable({
                                        aspectRatio: e.target.width / e.target.height,
                                    });
                                    target.data('resizable', true);

                                    if (lastResizableImg != null) {
                                        //disable previous resizable image
                                        lastResizableImg.resizable("destroy");
                                        lastResizableImg.removeData('resizable');
                                    }
                                    lastResizableImg = target;
                                }
                            }
                        })
                        .on('click', function (e) {
                            if (lastResizableImg != null && !(e.target instanceof HTMLImageElement)) {
                                destroyResizable();
                            }
                        })
                        .on('keydown', function () {
                            destroyResizable();
                        });
                }

                enableImageResize();

            }




            /////////////////////////////////////////////////








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





        }



        jQuery(function ($) {

            $('.date-picker').datepicker({
                autoclose: true,
                todayHighlight: true
            })
            var myTable = $('#dynamic-Notes')
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

            $('#Delete_modal').on('show.bs.modal', function (e) {
                var bookId = $(e.relatedTarget).data('book-id');

                // Set bookId label equal the Note ID when Opening the Delete PUP to be using in server side
                $(e.currentTarget).find($("#<%=NotDel.ClientID%>")).val(bookId);


            });
            $("#<%=RepImpTextU.ClientID %>").ace_wysiwyg({
                toolbar:
                    [

                        'print',

                        'togglescreen',
                        { name: 'bold', className: 'btn-info' },
                        { name: 'italic', className: 'btn-info' },
                        { name: 'strikethrough', className: 'btn-info' },
                        { name: 'underline', className: 'btn-info' },
                        null,
                        { name: 'insertunorderedlist', className: 'btn-success' },
                        { name: 'insertorderedlist', className: 'btn-success' },
                        { name: 'outdent', className: 'btn-purple' },
                        { name: 'indent', className: 'btn-purple' },
                        null,
                        { name: 'justifyleft', className: 'btn-primary' },
                        { name: 'justifycenter', className: 'btn-primary' },
                        { name: 'justifyright', className: 'btn-primary' },
                        { name: 'justifyfull', className: 'btn-inverse' },
                        null,
                        { name: 'createLink', className: 'btn-pink' },
                        { name: 'unlink', className: 'btn-pink' },
                        null,
                        'foreColor',
                        null,
                        { name: 'undo', className: 'btn-grey' },
                        { name: 'redo', className: 'btn-grey' }
                    ]

            }).prev().addClass('wysiwyg-style2');



            $("#<%=editor3.ClientID %>").ace_wysiwyg({
                toolbar:
                    [

                        'print',

                        'togglescreen',
                        { name: 'bold', className: 'btn-info' },
                        { name: 'italic', className: 'btn-info' },
                        { name: 'strikethrough', className: 'btn-info' },
                        { name: 'underline', className: 'btn-info' },
                        null,
                        { name: 'insertunorderedlist', className: 'btn-success' },
                        { name: 'insertorderedlist', className: 'btn-success' },
                        { name: 'outdent', className: 'btn-purple' },
                        { name: 'indent', className: 'btn-purple' },
                        null,
                        { name: 'justifyleft', className: 'btn-primary' },
                        { name: 'justifycenter', className: 'btn-primary' },
                        { name: 'justifyright', className: 'btn-primary' },
                        { name: 'justifyfull', className: 'btn-inverse' },
                        null,
                        { name: 'createLink', className: 'btn-pink' },
                        { name: 'unlink', className: 'btn-pink' },
                        null,
                        { name: 'insertImage', className: 'btn-grey' },
                        null,
                        'foreColor',
                        null,
                        { name: 'undo', className: 'btn-grey' },
                        { name: 'redo', className: 'btn-grey' }
                    ],
                'wysiwyg': {
                    fileUploadError: showErrorAlert
                }
            }).prev().addClass('wysiwyg-style2');


            function showErrorAlert(reason, detail) {
                var msg = '';
                if (reason === 'unsupported-file-type') { msg = "Unsupported format " + detail; }
                else {
                    //console.log("error uploading file", reason, detail);
                }
                $('<div class="alert"> <button type="button" class="close" data-dismiss="alert">&times;</button>' +
                    '<strong>File Not Image</strong> ' + msg + ' </div>').prependTo('#alerts');
            }
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

            $("#<%=editor1N.ClientID %>").ace_wysiwyg({
                toolbar:
                    [

                        'print',

                        'togglescreen',
                        { name: 'bold', className: 'btn-info' },
                        { name: 'italic', className: 'btn-info' },
                        { name: 'strikethrough', className: 'btn-info' },
                        { name: 'underline', className: 'btn-info' },
                        null,
                        { name: 'insertunorderedlist', className: 'btn-success' },
                        { name: 'insertorderedlist', className: 'btn-success' },
                        { name: 'outdent', className: 'btn-purple' },
                        { name: 'indent', className: 'btn-purple' },
                        null,
                        { name: 'justifyleft', className: 'btn-primary' },
                        { name: 'justifycenter', className: 'btn-primary' },
                        { name: 'justifyright', className: 'btn-primary' },
                        { name: 'justifyfull', className: 'btn-inverse' },
                        null,
                        { name: 'createLink', className: 'btn-pink' },
                        { name: 'unlink', className: 'btn-pink' },
                        null,
                        'foreColor',
                        null,
                        { name: 'undo', className: 'btn-grey' },
                        { name: 'redo', className: 'btn-grey' }
                    ]

            }).prev().addClass('wysiwyg-style2');
            $("#<%=editor1.ClientID %>").ace_wysiwyg({
                toolbar:
                    [

                        'print',

                        'togglescreen',
                        { name: 'bold', className: 'btn-info' },
                        { name: 'italic', className: 'btn-info' },
                        { name: 'strikethrough', className: 'btn-info' },
                        { name: 'underline', className: 'btn-info' },
                        null,
                        { name: 'insertunorderedlist', className: 'btn-success' },
                        { name: 'insertorderedlist', className: 'btn-success' },
                        { name: 'outdent', className: 'btn-purple' },
                        { name: 'indent', className: 'btn-purple' },
                        null,
                        { name: 'justifyleft', className: 'btn-primary' },
                        { name: 'justifycenter', className: 'btn-primary' },
                        { name: 'justifyright', className: 'btn-primary' },
                        { name: 'justifyfull', className: 'btn-inverse' },
                        null,
                        { name: 'createLink', className: 'btn-pink' },
                        { name: 'unlink', className: 'btn-pink' },
                        null,
                        'foreColor',
                        null,
                        { name: 'undo', className: 'btn-grey' },
                        { name: 'redo', className: 'btn-grey' }
                    ]

            }).prev().addClass('wysiwyg-style2');

            //////

            $('#UpdateReport_modal').on('hide.bs.modal', function (e) {

                (document.getElementById("<%=LblUpdate.ClientID%>")).innerHTML = "";
            });




            $('#DelFile_modal').on('show.bs.modal', function (e) {
                var bookId = $(e.relatedTarget).data('book-id');

                // Set bookId label equal the File ID when Opening the Delete PUP to be using in server side
                $(e.currentTarget).find($("#<%=FileId.ClientID%>")).val(bookId);


            });

            $('.from').datepicker({
                autoclose: true,
                minViewMode: 1,
                format: 'mm-yyyy'
            });
            $('.from2').datepicker({
                autoclose: true,
                minViewMode: 1,
                format: 'yyyy-mm-dd'
            });




            $('#DeleteReport_modal').on('show.bs.modal', function (e) {
                var bookId = $(e.relatedTarget).data('book-id');
                // Set bookId label equal the Report ID when Opening the Delete PUP to be using in server side
                $(e.currentTarget).find($("#<%=BookReport.ClientID%>")).val(bookId);


            });

            $('#UpdateReport_modal').on('hide.bs.modal', function (e) {

                (document.getElementById("<%=LblUpdate.ClientID%>")).innerHTML = "";
            });
            FillTable();

            DisplayCurrentTime();

        });

        function FillTable() {
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

            /********************************/
            //add tooltip for small view action buttons in dropdown menu
            $('[data-rel="tooltip"]').tooltip({ placement: tooltip_placement });

            //tooltip placement on right or left
            function tooltip_placement(context, source) {
                var $source = $(source);
                var $parent = $source.closest('table')
                var off1 = $parent.offset();
                var w1 = $parent.width();

                var off2 = $source.offset();
                //var w2 = $source.width();

                if (parseInt(off2.left) < parseInt(off1.left) + parseInt(w1 / 2)) return 'right';
                return 'left';
            }
        }

    </script>

</asp:Content>
