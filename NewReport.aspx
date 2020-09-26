<%@ Page Title=" إضافة ملاحظة  " Language="C#" MasterPageFile="~/MasterPage.master" CodeFile="~/NewReport.aspx.cs" AutoEventWireup="true" Inherits="NewReport" %>

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
            border-bottom-right-radius: 3px;
            border-bottom-left-radius: 3px;
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
    الملاحظات والتوصيات
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" runat="Server">

    <h3 style="font-weight: bold; color: #007044;">اضافة ملاحظة جديدة</h3>

    <div id="MainTable" style="display: block;" runat="server">
        <asp:Label ID="LblAdms" runat="server" Style="display: none" Text=""></asp:Label>
        <div class="row">
            <div class="col-xs-12">




                <div id="Suc" runat="server" visible="false" class="alert alert-block alert-success">
                    <strong>
                        <i class="ace-icon fa fa-check-square-o icon-only bigger-150"></i>
                        تم الحفظ بنجاج !
                    </strong>

                </div>
                <div id="SucDel" runat="server" visible="false" class="alert alert-block alert-success">
                    <strong>
                        <i class="ace-icon fa fa-check-square-o icon-only bigger-150"></i>
                        تم حذف الملاحظة بنجاح في حال الرغبة باسترجاع الملاحظة الرجاء التواصل مع إدارة النظام!
                    </strong>

                </div>
                <div id="SucReport" style="background-color: #FFFFFF;" runat="server" visible="false" class="alert alert-block alert-success">
                    <strong>
                        <i class="ace-icon fa fa-check-square-o icon-only bigger-150"></i>
                        تم اضافة الملاحظة  بنجاح برقم 
                <asp:Label ID="LblReport" Visible="false" runat="server" Text=""></asp:Label>
                    </strong>

                </div>
                <section class="content">
                    <div class="row">
                        <!-- left column -->
                        <div class="col-md-5">
                            <!-- general form elements -->
                            <div class="box box-primary">


                                <div class="box-body">
                                    <asp:UpdateProgress ID="UpdateProg3"
                                        AssociatedUpdatePanelID="Update03"
                                        runat="server">
                                        <ProgressTemplate>
                                            <i class="ace-icon fa fa-spinner fa-spin green bigger-125"></i>جارى التحميل...            
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>
                                    <asp:UpdatePanel ID="Update03" runat="server">
                                        <ContentTemplate>
                                            <div class="form-group">
                                                <h4 class="box-title">الخطة</h4>
                                                <div style="width: 310px;">
                                                    <asp:DropDownList class="chosen-select chosen-rtl form-control" ID="DropYear" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="DropYear_SelectedIndexChanged" runat="server" data-placeholder="الخطة السنوية">
                                                        <asp:ListItem Value="0" Text="اختر الخطة" Selected="True" />

                                                    </asp:DropDownList>
                                                </div>

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" InitialValue="0" ControlToValidate="Sector" runat="server" ValidationGroup="GNewRep" ForeColor="#ff3c3c" ErrorMessage="مطلوب تحديد الخطة    *"></asp:RequiredFieldValidator>

                                            </div>
                                            <div>
                                                <h4 class="box-title">الإدارة العليا</h4>
                                                <div style="width: 310px;">
                                                    <asp:DropDownList class="chosen-select chosen-rtl form-control" ID="Sector" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="Sector_SelectedIndexChanged" runat="server" data-placeholder="الإدارات عليا">
                                                        <asp:ListItem Value="0" Text="اختر إدارة عليا" Selected="True" />

                                                    </asp:DropDownList>
                                                </div>

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" InitialValue="0" ControlToValidate="Sector" runat="server" ValidationGroup="GNewRep" ForeColor="#ff3c3c" ErrorMessage="مطلوب تحديد الإدارة العليا    *"></asp:RequiredFieldValidator>

                                            </div>
                                            <div class="form-group">
                                                <h4 class="box-title">الإدارة متوسطة</h4>
                                                <div style="width: 310px;">
                                                    <asp:DropDownList class="chosen-select chosen-rtl form-control" AppendDataBoundItems="true" ID="Mang" runat="server" data-placeholder="الإدارات المتوسطة">
                                                        <asp:ListItem Value="0" Text="اختر الإدارة متوسطة" Selected="True" />
                                                    </asp:DropDownList>
                                                </div>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" InitialValue="0" ControlToValidate="Mang" runat="server" ValidationGroup="GNewRep" ForeColor="#ff3c3c" ErrorMessage="مطلوب تحديد الادارة    *"></asp:RequiredFieldValidator>


                                            </div>

                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>


                                <!-- /.box-body -->

                            </div>
                            <!-- /.box -->




                        </div>
                        <!--/.col (left) -->
                        <!-- right column -->
                        <div class="col-md-7">
                            <!-- Horizontal Form -->
                            <div class="box box-info">
                                <div class="box-body">
                                    <div class="row" style="margin-bottom: 20px;">
                                        <div class="col-md-6">

                                            <h4 class="box-title">حالة التكرار</h4>
                                            <div>
                                                <input name="switch-field-1" runat="server" id="RepeatSearch" class="ace ace-switch ace-switch-7" type="checkbox" />
                                                <span class="lbl"></span>

                                            </div>

                                        </div>
                                        <div class="col-md-6">

                                            <h4 class="box-title">تاريخ التنفيذ</h4>

                                            <div>
                                                <div class="input-group">
                                                    <span class="input-group-addon">
                                                        <i class="fa fa-calendar bigger-110"></i>
                                                    </span>
                                                    <input class="form-control date-picker" id="DateFromMain" autocomplete="off" runat="server" type="text" placeholder="يوم - شهر -سنة" data-date-format="yyyy-mm-dd" />

                                                </div>




                                            </div>


                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group" style="margin-bottom: 20px;">
                                                <h4 class="box-title">مستوى الأهمية</h4>
                                                <asp:RadioButtonList ID="ImportanceRep" runat="server" RepeatDirection="Horizontal" CssClass="radioboxlist" CellPadding="20" CellSpacing="20" Font-Bold="True" ForeColor="White">
                                                    <asp:ListItem Value="3"><img height="40" src="assets/images/Icons/levels/L1/high.png" /></asp:ListItem>
                                                    <asp:ListItem Value="2"><img height="40" src="assets/images/Icons/levels/L1/mid.png" /></asp:ListItem>
                                                    <asp:ListItem Value="1"><img height="40"  src="assets/images/Icons/levels/L1/low.png" /></asp:ListItem>



                                                </asp:RadioButtonList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" InitialValue=" " ControlToValidate="ImportanceRep" runat="server" ValidationGroup="GNewRep" ForeColor="#ff3c3c" ErrorMessage="مطلوب تحديد درجة مستوى الأهمية  *"></asp:RequiredFieldValidator>

                                            </div>



                                        </div>


                                        <div class="col-md-6">
                                            <h4 class="box-title">تاريخ الملاحظة</h4>
                                            <div class="col-md-12 col-md-8">

                                                <div class="input-group">
                                                    <span class="input-group-addon">
                                                        <i class="fa fa-calendar bigger-110"></i>
                                                    </span>
                                                    <input class="form-control date-picker" id="RepDatNew" autocomplete="off" runat="server" type="text" placeholder="يوم - شهر -سنة" data-date-format="yyyy-mm-dd" />

                                                </div>
                                            </div>

                                        </div>
                                    </div>
                                    <div class="form-group" style="margin-bottom: 20px;">
                                        <h4 class="box-title">حالة الملاحظة</h4>
                                        <asp:RadioButtonList ID="RadioStatusRep" runat="server" RepeatDirection="Horizontal" CssClass="radioboxlist" CellPadding="20" CellSpacing="20" Font-Bold="True" ForeColor="White">
                                            <asp:ListItem Value='3'><img height="40"  src="assets/icons/levels/L2/solved.png"  /></asp:ListItem>
                                            <asp:ListItem Value='2'><img height="40" src="assets/icons/levels/L2/under.png" /></asp:ListItem>
                                            <asp:ListItem Value='1'><img height="40"  src="assets/icons/levels/L2/hold.png" /></asp:ListItem>
                                            <asp:ListItem Value="5"><img height="40" src="assets/icons/levels/L2/closed.png" /></asp:ListItem>
                                            <asp:ListItem Value="4"><img height="40" src="assets/icons/levels/L2/notstart.png" /></asp:ListItem>

                                        </asp:RadioButtonList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" InitialValue=" " ControlToValidate="RadioStatusRep" runat="server" ValidationGroup="GNewRep" ForeColor="#ff3c3c" ErrorMessage="مطلوب تحديد حالة الملاحظة  *"></asp:RequiredFieldValidator>

                                    </div>
                                </div>
                            </div>
                            <!-- /.box -->

                        </div>
                        <!--/.col (right) -->

                        <div class="col-md-12">
                            <!-- Form Element sizes -->
                            <div class="box box-success">
                                <div class="box-header with-border">
                                    <h4 class="box-title">معلومات الملاحظة</h4>
                                </div>
                                <div class="box-body">

                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="form-group" style="margin-top: 30px;">
                                                <label class="col-md-3 control-label">عنوان الملاحظة </label>

                                                <div class="col-md-9">
                                                    <input runat="server" type="text" id="RepTitle" placeholder="عنوان الملاحظة" class="form-control text col-xs-10 col-md-10" />

                                                    <span>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" ControlToValidate="RepTitle" runat="server" ValidationGroup="GNewRep" ForeColor="#ff3c3c" ErrorMessage="عنوان الملاحظة مطلوب  *"></asp:RequiredFieldValidator></span>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div>
                                                <label class="control-label" for="form-field-1">نص الملاحظة </label>
                                                &nbsp;&nbsp;
                                                
                                                <asp:Label ID="lblNoteText" Style="display: none;" Font-Size="Medium" ForeColor="#ff3c3c" runat="server" Text="* مطلوب نص الملاحظه"></asp:Label>


                                            </div>
                                            <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                                                <ContentTemplate>

                                                    <div style="font-size: 14px; font-family: Arial;" class="wysiwyg-editor" runat="server" id="Editor0"></div>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="form-group" style="margin-top: 30px;">
                                                <div>
                                                    <label class="control-label" for="form-field-1">أهمية الملاحظة </label>
                                                    &nbsp;&nbsp;
                                                 <asp:Label ID="lblNoteImpText" Style="display: none;" Font-Size="Medium" ForeColor="#ff3c3c" runat="server" Text="* مطلوب أهمية الملاحظه"></asp:Label>

                                                </div>

                                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                    <ContentTemplate>

                                                        <div style="font-size: 14px; font-family: Arial;" class="wysiwyg-editor" runat="server" id="RepImpText"></div>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>

                                            </div>
                                        </div>
                                    </div>
                                    <div style="padding-right: 50px;">
                                        <asp:Label ID="ReqRepDates" Style="display: none;" Font-Size="Medium" ForeColor="#ff3c3c" runat="server" Text="* مطلوب تحديد تاريخ التنفيذ"></asp:Label>

                                    </div>
                                    <asp:Label ID="LblExists" runat="server" CssClass="red" Text=""></asp:Label>
                                    <div style="padding-top: 10px;">
                                        <asp:LinkButton ID="TempReport" CssClass="btn btn-success" ValidationGroup="GNewRep" Text="حفظ" OnClick="TempReport_Click" runat="server">
                                        </asp:LinkButton>
                                    </div>
                                </div>
                                <!-- /.box-body -->
                            </div>
                            <!-- /.box -->
                        </div>
                    </div>
                    <!-- /.row -->
                </section>



            </div>
        </div>

        <div class="row">


            <!-- div.table-responsive -->

            <!-- div.dataTables_borderWrap -->
            <div class="col-md-12">
                <!-- Form Element sizes -->
                <div class="box box-warning">
                    <div class="box-header with-border">
                        <h4 class="box-title">حفظ جميع الملاحظات </h4>
                    </div>
                    <div>


                        <table id="dynamic-table" class=" table-striped table-bordered">


                            <thead class="TableHead">
                                <tr>

                                    <th class="center">الإدارة متوسطة 

                                 
                                    </th>
                                    <th class="center">رقم الملاحظة 

                                 
                                    </th>
                                    <th class="center">عرض الملاحظة والتوصيات
                                    </th>

                                    <th class="center">مستوى الأهمية
                             
                                    </th>

                                    <th class="center">تاريخ التنفيذ 
                                    </th>
                                    <th class="center">حالة الملاحظة  
                                    </th>
                                    <th class="center">حالة التكرار 
                                    </th>
                                    <th class="center">إضافة توصيات

                                    </th>
                                    <th class="center">حذف/تعديل</th>
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


                                                <asp:LinkButton title="عرض الملاحظة " ID="LinkDetails" Text='<%# Eval("RepCode") %>' CommandArgument='<%# Eval("RepID") %>' OnCommand="Edit_Command" runat="server"></asp:LinkButton>


                                            </td>
                                            <td class="center">

                                                <asp:LinkButton CssClass="green" data-rel="tooltip" title="عرض التوصيات" ID="Edit" CommandArgument='<%# Eval("RepID") %>' OnCommand="Edit_Command" runat="server">  <img src="assets/images/Icons/BasicIcon/view.png" height="40" /> </asp:LinkButton>


                                            </td>



                                            <td class="center">
                                                <asp:Label ID="LblImportant" Visible="false" Style="color: #FFFFFF" runat="server" Text='<%# Eval("Importance") %>'></asp:Label>
                                                <asp:Label ID="RepDat" Visible="false" Style="color: #FFFFFF" runat="server" Text='<%# Eval("RepDate") %>'></asp:Label>
                                                <asp:Label ID="RepAdm" Visible="false" runat="server" Text='<%# Eval("RepAdms") %>'></asp:Label>
                                                <asp:Image ID="TD1" Height="40" runat="server" />
                                            </td>

                                            <td class="center">
                                                <asp:Label ID="RepFRM" runat="server" Text='<%# Eval("RepFrom") %>'></asp:Label>
                                                <asp:Label ID="LblRepID" runat="server" Visible="false" Text='<%# Eval("RepID") %>'></asp:Label>

                                            </td>
                                            <td class="center">
                                                <asp:Label ID="RepSec" Visible="false" runat="server" Text='<%# Eval("RepSection") %>'></asp:Label>
                                                <asp:Label ID="RepTit" runat="server" Visible="false" Text='<%# Eval("RepTitle").ToString().TrimStart() %>'></asp:Label>

                                                <asp:Label ID="LblStat" Visible="false" runat="server" Style="color: #FFFFFF; padding: 7px;" Text='<%# Eval("RepStatus") %>'></asp:Label>

                                                <asp:Image ID="TD2" Height="40" runat="server" />
                                            </td>
                                            <td class="center">
                                                <asp:Label ID="LblRepeatRep" Visible="false" runat="server" Style="color: #FFFFFF; padding: 7px;" Text='<%# Eval("RepRepeat") %>'></asp:Label>

                                                <asp:Image ImageUrl="assets/icons/BasicIcon/repete1.png" Height="45" Visible='<%#Convert.ToBoolean(Eval("RepRepeat"))?true:false%>' runat="server" ID="ImRepeat" />

                                                <asp:Image ImageUrl="assets/icons/BasicIcon/repete2.png" Height="45" Visible='<%#Convert.ToBoolean(Eval("RepRepeat"))?false:true%>' runat="server" ID="ImRepeat2" />


                                            </td>







                                            <td class="center">

                                                <%-- <asp:UpdateProgress ID="UpdateProg3"
                                                    AssociatedUpdatePanelID="Update03"
                                                    runat="server">
                                                    <ProgressTemplate>
                                                        <i class="ace-icon fa fa-spinner fa-spin green bigger-125"></i>جارى التحميل...            
                                                    </ProgressTemplate>
                                                </asp:UpdateProgress>--%>
                                                <%-- <asp:UpdatePanel ID="Update03" runat="server">
                                                    <ContentTemplate>--%>
                                                <asp:ImageButton title="إضافة توصية" Height="40" ImageUrl="~/assets/icons/BasicIcon/plus.png" ID="AddNote" CommandArgument='<%# Eval("RepID") %>' OnCommand="AddNote_Command" runat="server" />
                                                <%-- </ContentTemplate>
                                                </asp:UpdatePanel>--%>
                                            </td>

                                            <td class="center">
                                                <%--<asp:UpdateProgress ID="UpdateProgress3"
                                                    AssociatedUpdatePanelID="UpdatePane077"
                                                    runat="server">
                                                    <ProgressTemplate>
                                                        <i class="ace-icon fa fa-spinner fa-spin green bigger-125"></i>جارى التحميل...            
                                                    </ProgressTemplate>
                                                </asp:UpdateProgress>--%>
                                                <%--<asp:UpdatePanel ID="UpdatePane077" runat="server">
                                                    <ContentTemplate>--%>
                                                <asp:LinkButton CssClass="green" data-rel="tooltip" title="تعديل" ID="EditRep" CommandArgument='<%# Eval("RepID") %>' OnCommand="EditRep_Command" runat="server"><i class="ace-icon fa fa-pencil icon-only bigger-120"></i></asp:LinkButton>
                                                <!--Open Dlete Report PUP-->
                                                <a class="red" role='button' data-rel="tooltip" title="حذف" href='#DeleteReport_modal' data-toggle='modal' data-book-id='<%# Eval("RepID") %>'>
                                                    <i class="ace-icon fa fa-close icon-only bigger-120"></i><span class='hidden'>حذف</span>
                                                </a>
                                                <%--</ContentTemplate>
                                                </asp:UpdatePanel>--%>


                                                <div class="hidden-md hidden-lg">
                                                    <div class="inline pos-rel">
                                                        <button class="btn btn-minier btn-#e7ea56 dropdown-toggle" data-toggle="dropdown" data-position="auto">
                                                            <i class="ace-icon fa fa-caret-down icon-only bigger-120"></i>
                                                        </button>

                                                        <ul class="dropdown-menu dropdown-only-icon dropdown-#e7ea56 dropdown-menu-right dropdown-caret dropdown-close">

                                                            <li>
                                                                <asp:LinkButton CssClass="green" data-rel="tooltip" title="تعديل" ID="LinkButton2" CommandArgument='<%# Eval("RepID") %>' OnCommand="EditRep_Command" runat="server"><i class="ace-icon fa fa-pencil icon-only bigger-120"></i></asp:LinkButton>

                                                            </li>
                                                            |
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

                        <div style="padding-top: 10px;">
                            <asp:LinkButton ID="SendAll" CssClass="btn btn-success" OnClick="SendAll_Click" runat="server"> 
                        حفظ</asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </div>
    <div id="RepDetail" class="MainBox" style="display: none" runat="server">



        <div style="padding: 15px; border: 1px solid #E0E2E5; background-color: #FFF; direction: ltr;">
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

                            <li><b>حالة الملاحظة  </b>:
                                    <asp:Image ID="LblStatus" runat="server" Height="40" /></li>

                        </ul>
                    </div>
                </div>





            </div>


            <div class="row">
                <div class="col-md-12">
                    <ul class="menudetails">
                        <li><b>عنوان الملاحظة  </b>:
                        </li>
                    </ul>
                    <div class="hr hr8 hr-double hr-dotted"></div>

                </div>
                <div class="well">
                    <div id="Test" runat="server" />
                </div>
            </div>



            <div class="row">
                <div class="col-md-12">
                    <ul class="menudetails">
                        <li><b>أهمية الملاحظة  </b>:
                        </li>
                    </ul>
                    <div class="hr hr8 hr-double hr-dotted"></div>


                </div>
                <div class="well">
                    <div id="RepImpTxt" runat="server" />
                </div>
            </div>

        </div>
        <div id="NoteDetails">


            <div style="padding: 15px; border: 1px solid #E0E2E5; background-color: #FFF;">
                <div class="modal-header">

                    <h3 class="bigger">التوصيات</h3>
                </div>


                <div class="row">
                    <div class="col-md-12">
                        <div id="SucNote" runat="server" visible="false" class="alert alert-block alert-success">
                            <strong>
                                <i class="ace-icon fa fa-check-square-o icon-only bigger-150"></i>
                                تم حفظ التوصية بنجاج  !
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


                <table id="dynamic-Notes" class=" table-striped table-bordered">


                    <thead class="TableHead">
                        <tr>
                            <th class="center">رقم الملاحظة </th>
                            <th class="center">رقم التوصية </th>
                            <th class="center">عرض التوصية  </th>
                            <th class="center">تاريخ التنفيذ </th>

                            <th class="center">الملفات المرفقة</th>
                            <th class="center">حالة التوصية  </th>
                            <th class="center"></th>
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
                                            <span>
                                                <%# Container.ItemIndex + 1 %></span>
                                        </a>



                                        <div id='<%#string.Concat("Details",Eval("NoteID"))%>' data-backdrop="static" data-keyboard="false" aria-hidden="false" class="modal fade" tabindex="-1">
                                            <div class="modal-dialog" style="background-color: #FFFFFF; width: 75%;">

                                                <div style="float: left;">
                                                    <button type="button" class="close red" data-dismiss="modal">
                                                        <img src="assets/images/Icons/BasicIcon/close.png" height="25" /></button>
                                                </div>
                                                <div class="modal-body" style="font-size: 25px;">
                                                    <div class="row">
                                                        <div class="col-md-12">
                                                            <ul class="menudNoteetails">
                                                                <li><b>التكرار</b>:
                                    <asp:Label ID="LblNotStat" CssClass="grey" runat="server" Text='<%# Eval("NoteRepeat") %>'></asp:Label></li>
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

                                    </td>





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
        </div>
        <div>
            <asp:LinkButton ID="LinkButton9" runat="server" OnClick="BackTables_Click" Style="float: left; margin-top: -10px;"><i class="ace-icon fa fa-arrow-left icon-only purple bigger-250"></i></asp:LinkButton>
        </div>
    </div>
    <div id="Comm_modal" data-backdrop="static" data-keyboard="false" style="z-index: 1000000" class="modal fade" tabindex="-1">
        <div class="modal-dialog">
            <div class="modal-content">

                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="blue bigger">الرد  </h4>
                </div>

                <div class="modal-body">

                    <div class="row">
                        <div class="col-xs-12 col-md-12">

                            <h4 class="blue">ملفات مرفقة بالرد  </h4>

                            <div class="row">

                                <div class="col-xs-12 col-md-8">



                                    <label class="col-md-4 control-label " for="form-field-1">الملفات المرفقة </label>
                                    <div class="col-md-8">
                                        <asp:Repeater ID="FileListed" runat="server">

                                            <ItemTemplate>
                                                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("FPath") %>' Text='<%# Eval("FName") %>'></asp:HyperLink>

                                            </ItemTemplate>
                                        </asp:Repeater>


                                    </div>
                                </div>
                                <div class="col-xs-12 col-md-4">


                                    <div class="form-group">
                                        <label class="col-md-4 control-label " for="form-field-1">تاريخ الرد </label>

                                        <div class="col-md-8">
                                            <asp:Label ID="LblCommDate" runat="server" Text=""></asp:Label>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-xs-12 col-md-4">


                                    <div class="form-group">
                                        <label class="col-md-4 control-label " for="form-field-1">رقم الملاحظة  </label>

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
                        <div class="col-xs-12 col-md-12">
                            <div class="hr hr8 hr-double hr-dotted"></div>
                            <div class="well">
                                <div id="LblCommTxt" runat="server" />
                            </div>
                        </div>

                    </div>



                </div>


            </div>

        </div>
    </div>

    <div data-backdrop="static" id="Done" data-keyboard="true" aria-hidden="true" class="modal" tabindex="-1">

        <div class="modal-dialog" style="padding-right: 30%; width: 60%; top: 20%;">
            <div class="modal-content">
                <div style="background-color: #FFFFFF" class="row">
                    <div class="col-lg-3">
                        <a href="#" data-dismiss="modal" class="close">
                            <img height="55" src="assets/images/Icons/BasicIcon/close.png" />
                        </a>
                    </div>
                    <div class="col-sm-9">
                        &nbsp;
                    </div>


                </div>
                <div class="modal-body">
                    <div class="row" style="background-color: #FFFFFF; border: none; text-align: center;">

                        <div>
                            تم ارسال الملاحظات
                                <span style="display: inline">
                                    <img src="assets/icons/BasicIcon/sendcon.png" height="70" /></span>
                        </div>

                    </div>
                </div>

            </div>
        </div>


    </div>


    <asp:Label ID="LblViews" Style="display: none;" runat="server" Text=""></asp:Label>

    <asp:Label ID="LblDone" Style="display: none;" runat="server" Text=""></asp:Label>


    <asp:Label ID="RepId" Style="display: none;" runat="server" Text=""></asp:Label>
    <asp:Label ID="NoteId" Style="display: none;" runat="server" Text=""></asp:Label>



    <asp:Label ID="LblUpdate" Style="display: none;" runat="server" Text=""></asp:Label>


    <asp:Label ID="LblEditID" Style="display: none;" runat="server" Text=""></asp:Label>



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
                            تم الحفظ بنجاج !
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


    <div id="modal-NoteReplys" data-backdrop="static" data-keyboard="false" class="modal fade" tabindex="-1" style="margin-top: -15px;">
        <div class="modal-dialog" style="right: 2% !important; width: 95%">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="blue bigger">الردود</h4>
                </div>

                <div class="modal-body">

                    <div id="SucReplyNote" runat="server" visible="false" class="alert alert-block alert-success">
                        <strong>
                            <i class="ace-icon fa fa-check-square-o icon-only bigger-150"></i>
                            تم الحفظ بنجاج !
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
                                                <hr />
                                        الملفات المرفقة
                                                                               
                                    </th>

                                    <th class="center">نص الرد

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
                                                <hr class="center" style="margin-top: 1px; margin-bottom: 1px; border-top: 1px solid #6ad589;" />

                                                <i class="ace-icon fa fa-paperclip green"></i>
                                                <asp:Label ID="FNoteCount" Visible="false" runat="server" Text='<%# Eval("FCount") %>'></asp:Label>

                                                <asp:LinkButton title="الملفات المرفقة" ID="LinkNotFiles" Text="الملفات المرفقة" CommandArgument='<%# Eval("ConfirmID") %>' OnCommand="LinkNotFiles_Command" runat="server"></asp:LinkButton>
                                                <div runat="server" id="NoNotefiles" visible="false">لايوجد ملفات مرفقة</div>

                                            </td>

                                            <td class="center">
                                                <div>
                                                    <asp:Literal ID="LitNoteText" runat="server" Text='<%# Eval("ConfirmText") %>'></asp:Literal>
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





    <div id="Chart_modal" data-backdrop="static" data-keyboard="false" style="z-index: 9999" class="modal fade" tabindex="-1">
        <input style="display: none" type="text" runat="server" name="bookId" id="Text1" value="" />
        <div class="modal-dialog" style="width: 80%">
            <div class="modal-content">

                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="blue bigger">توضيح للتوصيات </h4>
                </div>

                <div class="modal-body">

                    <div class="row">
                        <div class="col-xs-12 col-md-12">
                            <asp:UpdateProgress ID="ChartProg"
                                AssociatedUpdatePanelID="ChartProgging"
                                runat="server">
                                <ProgressTemplate>
                                    <i class="ace-icon fa fa-spinner fa-spin green bigger-125"></i>جارى التحميل...            
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                            <asp:UpdatePanel ID="ChartProgging" runat="server">
                                <ContentTemplate>
                                    <div class="alert alert-info" runat="server" id="NoNoteCharts" visible="false">
                                        لايوجد توصيات على هذه الملاحظة
                                    </div>
                                    <div class="col-md-3">&nbsp;</div>
                                    <div class="col-md-6">
                                    </div>
                                    <div class="col-md-3">&nbsp;</div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>







    <div id="AdminFilesView" style="display: none;" runat="server">



        <div class="modal-header">

            <h4 class="blue bigger">الملفات المرفقة</h4>
        </div>

        <asp:Label ID="LblRep" runat="server" Visible="false" Text=""></asp:Label>

        <div class="row">

            <div class="col-xs-12">
                <label class="control-label " for="form-field-1">اضافة ملفات  </label>

                <div id="SucFile" runat="server" visible="false" class="alert alert-block alert-success">
                    <strong>
                        <i class="ace-icon fa fa-check-square-o icon-only bigger-150"></i>
                        تم الحفظ بنجاج !
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
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" ForeColor="Red" Display="Dynamic" ValidationGroup="GFile" runat="server" ControlToValidate="FileUploadR" ErrorMessage="*مطلوب رفع ملف"></asp:RequiredFieldValidator>

                        </div>
                        <asp:Label ID="LblEroorNote" Visible="false" runat="server" Text="مسجل ملف بنفس الاسم" ForeColor="#ff3c3c"></asp:Label>

                        <asp:Label ID="LblEroor" Visible="false" runat="server" Text="مسجل ملف بنفس الاسم " ForeColor="#ff3c3c"></asp:Label>
                        <asp:Button ID="AddFile" OnClick="AddFile_Click1" ValidationGroup="GFile" Text="حفظ" runat="server" />

                    </div>
                </div>
            </div>
        </div>

        <div class="row" style="margin-top: 10px;">
            <div class="col-xs-12">
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

        <div>
            <asp:LinkButton ID="BackFiles" runat="server" OnClick="BackFiles_Click" Style="float: left; margin-top: -10px;"><i class="ace-icon fa fa-arrow-left icon-only purple bigger-250"></i></asp:LinkButton>
        </div>


    </div>
    <div id="UpdReport" runat="server" style="display: none">



        <div style="padding: 15px; border: 1px solid #E0E2E5; background-color: #FFF;">


            <div class="row">

                <div class="modal-header">
                    <h3 class="blue bigger">تعديل بالملاحظة </h3>
                </div>


                <div class="row">
                    <asp:UpdatePanel ID="UpdatePanel14" runat="server">
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
                                    <div class="col-xs-12 col-md-8 ">

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
                                        <label class="col-md-2 control-label " for="form-field-1">الإدارة العليا </label>

                                        <div class="col-md-12 col-md-10">

                                            <div>

                                                <asp:DropDownList CssClass="chosen-select chosen-rtl form-control" ID="SectorRep" AutoPostBack="true" OnSelectedIndexChanged="SectorRep_SelectedIndexChanged" runat="server" data-placeholder="الإدارات عليا">
                                                </asp:DropDownList>



                                                <asp:RequiredFieldValidator ID="Required2" InitialValue=" " ControlToValidate="SectorRep" runat="server" ValidationGroup="GRep" ForeColor="#ff3c3c" ErrorMessage="مطلوب تحديد الإدارة العليا  *"></asp:RequiredFieldValidator></span>
              
                                            </div>


                                        </div>
                                    </div>
                                </div>


                                <div class="col-md-12 col-md-6">

                                    <label class="col-md-3 Sub control-label " for="form-field-1">ادارة  </label>

                                    <div class="col-xs-12 col-md-9">

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


                </div>

                <div class="row">
                    <div class="col-md-12">
                        <label class="col-md-3 Sub control-label">مستوى الأهمية </label>

                        <div class="col-md-9">

                            <div>
                                <asp:RadioButtonList ID="Importance" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="3"><img height="40" src="assets/images/Icons/levels/L1/high.png" /></asp:ListItem>
                                    <asp:ListItem Value="2"><img height="40" src="assets/images/Icons/levels/L1/mid.png" /></asp:ListItem>
                                    <asp:ListItem Value="1"><img height="40"  src="assets/images/Icons/levels/L1/low.png" /></asp:ListItem>



                                </asp:RadioButtonList>

                            </div>
                            <asp:RequiredFieldValidator ID="RequiredRep1" InitialValue=" " ControlToValidate="Importance" runat="server" ValidationGroup="GRep" ForeColor="#ff3c3c" ErrorMessage="مطلوب تحديد درجةمستوى الأهمية   *"></asp:RequiredFieldValidator>

                        </div>

                    </div>


                    <div class="col-xs-12 ">

                        <label class="col-md-3 Sub control-label">معالجة الملاحظة </label>

                        <div class="col-md-9">

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
                <div class="row" style="display: none;">

                    <div class="col-md-12">
                        <label class="col-md-1 control-label Sub " for="form-field-1">اضافة ملفات  </label>
                        <div class="col-md-3">
                            <div class="form-group">
                                <div class="btn btn-primary btn-sm right">
                                    <span>Select file</span>
                                    <asp:FileUpload ID="FileUploadUPD" runat="server" />
                                    <div id="ValidatUPD" class="red"></div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <asp:Label ID="LblEroorUPD" Visible="false" runat="server" Text="مسجل ملف بنفس الاسم" ForeColor="#ff3c3c"></asp:Label>

                            <asp:Label ID="LblErUPD" Visible="false" runat="server" Text="مسجل ملف بنفس الاسم " ForeColor="#ff3c3c"></asp:Label>
                            <asp:Button ID="AddFileUPD" OnClick="AddFileUPD_Click1" Text="إحفظ الملف" runat="server" />



                        </div>

                        <div id="SucUPD" style="margin-top: 2px;" runat="server" visible="false" class="col-md-3 alert alert-block alert-success">
                            <strong>
                                <i class="ace-icon fa fa-check-square-o icon-only bigger-150"></i>
                                تم الحفظ بنجاج !
                            </strong>

                        </div>

                    </div>


                    <div style="margin-top: 2px; background-color: #eff3f8;">
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
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
                                        <asp:Repeater ID="RepeatUPD" runat="server">

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
                    <div class="col-xs-12 col-md-12">
                        <div class="form-group" style="margin-top: 30px;">
                            <label class="col-md-2 control-label " for="form-field-1">عنوان الملاحظة </label>

                            <div class="col-md-6">
                                <input runat="server" type="text" id="RepTitleU" placeholder="عنوان الملاحظة" class="form-control text col-xs-10 col-md-10" />

                                <span>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" ControlToValidate="RepTitleU" runat="server" ValidationGroup="GRep" ForeColor="#ff3c3c" ErrorMessage="عنوان الملاحظة مطلوب  *"></asp:RequiredFieldValidator></span>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-12 col-md-12">
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
                    <div class="modal-footer">
                        <asp:Label ID="LblError" runat="server" Text="" CssClass="Rett" ForeColor="#ff3c3c"></asp:Label>

                        <asp:Label ID="ReqDatesRep" Style="color: red; display: none; font-size: 14px; font-weight: bold;" runat="server" Text="* مطلوب تحديد مدة زمنية لتنفيذ لملاحظة  خلالها  "></asp:Label>

                        <asp:Label ID="ErrorDayRep" Style="color: red; display: none; font-size: 14px; font-weight: bold;" runat="server" Text=" يجب أن يكون تاريخ الإنتهاء أكبر من أو يساوى تاريخ اليوم الجارى "></asp:Label>
                        <asp:Label ID="LblReportFile" Style="display: none" runat="server" Text="الملفات المرفقة لها نفس الاسم" ForeColor="#ff3c3c"></asp:Label>
                        <asp:Button ID="UpdateReport"  OnClick="UpdateReport_Click" ValidationGroup="GRep" CssClass="btn btn-success"  Text="حفظ" runat="server" />

                    </div>

                </div>



            </div>

        </div>
        <div>
            <asp:LinkButton ID="LinkButton7" runat="server" OnClick="BackTables_Click" Style="float: left; margin-top: -10px;"><i class="ace-icon fa fa-arrow-left icon-only purple bigger-250"></i></asp:LinkButton>
        </div>
    </div>

    <!------------------- Update Note------------>
    <div id="UPDNot" class="MainBox" style="display: none" runat="server">



        <div style="padding: 15px; border: 1px solid #E0E2E5; background-color: #FFF;">


            <div class="modal-header">
                <h3 class="blue bigger">تعديل التوصية</h3>
            </div>



            <div class="row">
                <div class="col-xs-12">
                    <div class="row">
                        <div class="col-xs-12 col-md-6" style="display: none;">

                            <label class="col-md-4 Sub control-label">أهمية التوصية</label>

                            <div class="col-md-8">

                                <div>
                                    <asp:RadioButtonList ID="RadioButtonList01" runat="server" RepeatDirection="Horizontal" CssClass="radioboxlist" CellPadding="20" CellSpacing="20" Font-Bold="True" ForeColor="White">
                                        <asp:ListItem Value="3"><img height="40" src="assets/images/Icons/levels/L1/high.png" /></asp:ListItem>
                                        <asp:ListItem Value="2"><img height="40" src="assets/images/Icons/levels/L1/mid.png" /></asp:ListItem>
                                        <asp:ListItem Value="1"><img height="40"  src="assets/images/Icons/levels/L1/low.png" /></asp:ListItem>

                                    </asp:RadioButtonList>

                                </div>


                            </div>
                        </div>
                        <div class="col-md-2">
                            <label class="col-md-4 Sub control-label">التكرار</label>
                            <div class="col-md-8">
                                <label>
                                    <input name="switch-field-1" runat="server" id="LblRepeat0" class="ace ace-switch ace-switch-7" type="checkbox" />
                                    <span class="lbl"></span>
                                </label>
                            </div>


                        </div>
                        <div class="col-md-8">

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

                            <label class="col-md-4 Sub control-label">حالة معالجة التوصية</label>

                            <div class="col-md-8">

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

                        <div class="col-xs-12">
                            <label class="col-md-2 control-label Sub " for="form-field-1">اضافة ملفات  </label>
                            <div class="col-md-5">
                                <div class="form-group">
                                    <div class="btn btn-primary btn-sm right">
                                        <span>Select file</span>
                                        <asp:FileUpload ID="FileUpload02" runat="server" />

                                    </div>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator15" ForeColor="Red" Display="Dynamic" ValidationGroup="ReqNoteFile" runat="server" ControlToValidate="FileUpload02" ErrorMessage="*مطلوب رفع ملف"></asp:RequiredFieldValidator>

                                </div>
                            </div>
                            <div class="col-md-5">
                                <asp:Label ID="NoteFileExistUPD" Visible="false" runat="server" Text="مسجل ملف بنفس الاسم" ForeColor="#ff3c3c"></asp:Label>

                                <asp:Button ID="AddNoteFileUPD" ValidationGroup="ReqNoteFile" OnClick="AddNoteFileUPD_Click1" CssClass="btn btn-success" text="حفظ" runat="server" />



                                <div id="SucNoteFileUpd" style="margin-top: 2px;" runat="server" visible="false" class="alert alert-block alert-success">
                                    <strong>
                                        <i class="ace-icon fa fa-check-square-o icon-only bigger-150"></i>
                                        تم الحفظ بنجاج !
                                    </strong>

                                </div>
                            </div>

                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-12">
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
                        <div class="col-xs-12 col-md-12">
                            <label class="Sub control-label">نص التوصية </label>
                            <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                                <ContentTemplate>
                                    <div style="font-size: 14px; font-family: Arial;" class="wysiwyg-editor" runat="server" id="editor2"></div>
                                </ContentTemplate>
                            </asp:UpdatePanel>

                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-12 col-md-12">
                            <label class="Sub control-label">الاجراء التصحيحي من قبل الإدارة متوسطة  </label>
                            <asp:UpdatePanel ID="UpdatePanel13" runat="server">
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
                    <asp:ImageButton ImageUrl="assets/icons/buttons/editnote.png" Height="40" ID="UpdateNote" OnClick="UpdateNote_Click" ValidationGroup="GU" runat="server" />

                    <asp:Label ID="LblRepID" runat="server" Visible="false" Text=""></asp:Label>


                </div>

            </div>



        </div>
        <div>
            <asp:LinkButton ID="LinkButton4" runat="server" OnClick="BackTables_Click" Style="float: left; margin-top: -10px;"><i class="ace-icon fa fa-arrow-left icon-only purple bigger-250"></i></asp:LinkButton>
        </div>
    </div>


    <div id="NewNote" class="MainBox" style="display: none" runat="server">



        <div>



            <div style="padding: 15px; border: 1px solid #E0E2E5; background-color: #FFF;">

                <h3 class="blue bigger">توصية جديدة</h3>

                <div runat="server" id="MainSave">


                    <div class="row">
                        <div class="col-md-12">
                            <div class="col-md-4">
                                <label class="col-md-2 Sub control-label">التكرار</label>
                                <div class="col-md-10">
                                    <label>
                                        <input name="switch-field-1" runat="server" id="LblRepeatU" class="ace ace-switch ace-switch-7" type="checkbox" />
                                        <span class="lbl"></span>
                                    </label>
                                </div>


                            </div>
                            <div class="col-md-8">

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
                    </div>
                    <div class="row">
                        <div class="col-md-12">

                            <label class="col-md-4 Sub control-label">حالة معالجة التوصية</label>

                            <div class="col-md-8">

                                <div>
                                    <asp:RadioButtonList ID="RadioButtonList2" RepeatDirection="Horizontal" runat="server">
                                        <asp:ListItem Value='3'><img height="40"  src="assets/icons/levels/L2/solved.png"  /></asp:ListItem>
                                        <asp:ListItem Value='2'><img height="40" src="assets/icons/levels/L2/under.png" /></asp:ListItem>
                                        <asp:ListItem Value='1'><img height="40"  src="assets/icons/levels/L2/hold.png" /></asp:ListItem>
                                        <asp:ListItem Value="5"><img height="40" src="assets/icons/levels/L2/closed.png" /></asp:ListItem>
                                        <asp:ListItem Value="4"><img height="40" src="assets/icons/levels/L2/notstart.png" /></asp:ListItem>
                                    </asp:RadioButtonList>

                                </div>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" InitialValue=" " ControlToValidate="RadioButtonList2" runat="server" ValidationGroup="GNotes" ForeColor="#ff3c3c" ErrorMessage="مطلوب تحديد  معالجة التوصية  *"></asp:RequiredFieldValidator>

                            </div>
                        </div>


                    </div>
                    <div class="row">

                        <div class="col-xs-12">
                            <label class="col-md-2 control-label Sub " for="form-field-1">اضافة ملفات  </label>
                            <div class="col-md-5">
                                <div class="form-group">
                                    <div class="btn btn-primary btn-sm right">
                                        <span>Select file</span>
                                        <asp:FileUpload ID="FileUpload01" runat="server" CssClass="FileNoteAdd" />

                                    </div>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator16" ForeColor="Red" Display="Dynamic" ValidationGroup="GNewNFile" runat="server" ControlToValidate="FileUpload01" ErrorMessage="*مطلوب رفع ملف"></asp:RequiredFieldValidator>
                                </div>

                            </div>
                            <div class="col-md-2">
                                <asp:Label ID="LblNoteFileExist" Visible="false" runat="server" Text="مسجل ملف بنفس الاسم" ForeColor="#ff3c3c"></asp:Label>
                                <asp:Button CssClass="btn btn-success"  Text="حفظ" ID="AddNoteFile" ValidationGroup="GNewNFile" OnClick="AddNoteFile_Click" runat="server" />

                            </div>
                            <div class="col-md-3">
                                <div id="SucNoteFile" style="margin-top: 2px;" runat="server" visible="false" class="alert alert-block alert-success">
                                    <strong>
                                        <i class="ace-icon fa fa-check-square-o icon-only bigger-150"></i>
                                        تم الحفظ بنجاج !
                                    </strong>

                                </div>
                            </div>

                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-12">
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
                        <div class="col-xs-12 col-md-12">
                            <label class="Sub control-label">نص التوصية </label>
                            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                <ContentTemplate>

                                    <div style="font-size: 14px; font-family: Arial;" class="wysiwyg-editor" runat="server" id="editor1"></div>
                                </ContentTemplate>
                            </asp:UpdatePanel>

                        </div>
                    </div>

                    <div class="row">
                        <div class="col-xs-12 col-md-12">
                            <label class="Sub control-label">الاجراء التصحيحي من قبل الإدارة متوسطة  </label>
                            <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                <ContentTemplate>


                                    <div style="font-size: 14px; font-family: Arial;" class="wysiwyg-editor" runat="server" id="editor1N"></div>
                                </ContentTemplate>
                            </asp:UpdatePanel>

                        </div>
                    </div>

                    <div class="row">
                        <div class="modal-footer">


                            <asp:Label ID="Rett" runat="server" Text="" CssClass="Rett" ForeColor="#ff3c3c"></asp:Label>
                            <asp:Label ID="ReqDates" Style="color: red; display: none; font-size: 14px; font-weight: bold;" runat="server" Text="* مطلوب تحديد مدة زمنية لمعالجة التوصية خلالها  "></asp:Label>

                            <asp:Label ID="ErrorDay" Style="color: red; display: none; font-size: 14px; font-weight: bold;" runat="server" Text=" يجب أن يكون تاريخ الإنتهاء أكبر من أو يساوى تاريخ اليوم الجارى "></asp:Label>

                            <asp:ImageButton ID="Save" OnClick="Save_Click" ValidationGroup="GNotes" Height="51" runat="server" src="assets/icons/buttons/addrec.png" />



                        </div>

                    </div>
                    <input style="display: none" type="text" runat="server" name="bookId" id="bookId" value="" />
                    <asp:Label ID="LblNotNew" Visible="false" runat="server" Text=""></asp:Label>

                </div>
            </div>
            <div>
                <asp:LinkButton ID="BackNotes" runat="server" OnClick="BackTables_Click" Style="float: left; margin-top: -10px;"><i class="ace-icon fa fa-arrow-left icon-only purple bigger-250"></i></asp:LinkButton>
            </div>
        </div>
    </div>

    <div runat="server" class="MainBox" style="display: none;" id="PrntView">
        <div id="dvContents">
            <div class="row">

                <div class="col-xs-12 col-md-12">
                    <h3 style="margin-right: 7px;" class="blue">بيانات الملاحظة </h3>


                    <div class="row">
                        <div class="col-xs-12 col-md-4">


                            <div class="form-group">
                                <label class="col-md-4 control-label " for="form-field-1">عدد التوصيات على الملاحظة </label>

                                <div class="col-md-8">
                                    <asp:Label ID="RepCount" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                        </div>

                        <div class="col-xs-12 col-md-4">


                            <div class="form-group">
                                <label class="col-md-4 control-label " for="form-field-1">تاريخ الملاحظة  </label>

                                <div class="col-md-8">
                                    <asp:Label ID="RepDat" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                        </div>

                        <div class="col-xs-12 col-md-4">


                            <div class="form-group">
                                <label class="col-md-4 control-label " for="form-field-1">رقم الملاحظة  </label>

                                <div class="col-md-8">
                                    <asp:Label ID="RepNo" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                        </div>






                    </div>



                </div>

            </div>

            <div class="row">
                <h4 style="margin-right: 7px;" class="blue">تفاصيل الملاحظة </h4>
                <div class="col-xs-12 col-md-4">

                    <div class="form-group">


                        <label class="col-md-4 control-label " for="form-field-1">موجه لإدارة عليا</label>
                        <div class="col-md-8">
                            <asp:Label ID="RepSec" runat="server" Text=""></asp:Label>
                        </div>

                    </div>
                </div>

                <div class="col-xs-12 col-md-4">

                    <div class="form-group">


                        <label class="col-md-4 control-label " for="form-field-1">موجه لإدارة متوسطة</label>
                        <div class="col-md-8">
                            <asp:Label ID="RepAdm" runat="server" Text=""></asp:Label>
                        </div>

                    </div>
                </div>

                <div class="col-xs-12 col-md-4">

                    <div class="form-group">


                        <label class="col-md-4 control-label " for="form-field-1">مستوى الأهمية </label>
                        <div class="col-md-8">
                            <asp:Label ID="RepIm" runat="server" Text=""></asp:Label>
                        </div>

                    </div>
                </div>

            </div>
            <div class="row">
                <div class="col-xs-12 col-md-4">

                    <div class="form-group">

                        <label class="col-md-4 control-label " for="form-field-1">التاريخ المحدد للتنفيذ</label>
                        <div class="col-md-8">
                            <asp:Label ID="RepOn" runat="server" Text=""></asp:Label>

                        </div>

                    </div>
                </div>

                <div class="col-xs-12 col-md-4">

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

                <div class="col-xs-12 col-md-4">

                    <div class="form-group">

                        <label class="col-md-4 control-label " for="form-field-1">حالة التنفيذ </label>
                        <div class="col-md-8">
                            <asp:Label ID="RepSt" runat="server" Text=""></asp:Label>

                        </div>

                    </div>
                </div>

            </div>
            <div class="row">

                <div class="col-xs-12 col-md-12">
                    <div class="hr hr8 hr-double hr-dotted"></div>
                    <div class="well">
                        <div id="Div1" runat="server" />
                    </div>
                </div>

            </div>

            <div class="row">
                <label class="control-label " for="form-field-1">بيان التوصيات : </label>
                <div class="col-md-12" runat="server" id="NoNotes">لا يوجد توصيات على الملاحظة</div>
                <div class="col-md-12" runat="server" style="display: none" id="NotesPrev">
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
            <div class="modal-footer">
                <asp:Label ID="Label6" runat="server" Text="" CssClass="Rett" ForeColor="#ff3c3c"></asp:Label>

                <a href="#" id="Prnt" onclick="PrintDiv();">
                    <img src="assets/icons/buttons/print.png" />
                </a>
            </div>

        </div>

        <div>
            <asp:LinkButton ID="LinkButton3" runat="server" OnClick="BackTables_Click" Style="float: left; margin-top: -10px;"><i class="ace-icon fa fa-arrow-left icon-only purple bigger-250"></i></asp:LinkButton>
        </div>
    </div>







    <!------Update Report-------->


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
                    <span><a href="#" data-dismiss="modal"></a>
                    </span>
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
                            <h4 class="align-right">هل أنت متأكد من حذف هذه الملاحظة؟ </h4>
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
                    <span><a href="#" data-dismiss="modal"></a>
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
                    <span><a href="#" data-dismiss="modal"></a>
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
                        <div class="col-xs-12">


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
    <asp:HiddenField ID="hf0" runat="server" />
    <asp:HiddenField ID="hf" runat="server" />

    <asp:HiddenField ID="hf1N" runat="server" />
    <asp:HiddenField ID="hf2N" runat="server" />
    <asp:HiddenField ID="hf2" runat="server" />

    <asp:HiddenField ID="hf3" runat="server" />
    <asp:HiddenField ID="NoteRep" runat="server" />
    <asp:HiddenField ID="RepImpTextHid" runat="server" />

    <asp:HiddenField ID="RepImpTextUHid" runat="server" />
    <asp:HiddenField ID="PartText1" runat="server" />

    <asp:HiddenField ID="PartText2" runat="server" />

    <asp:HiddenField ID="PartText3" runat="server" />

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



        /* Put your code to run before UpdatePanel begins async postback here */
        function beforeAsyncPostBack() {

            //Editor 0


            var EsRepImpText = document.createElement('textarea');
            EsRepImpText.textContent = document.getElementById("<%=RepImpText.ClientID%>").innerHTML;
            $("#<%=RepImpTextHid.ClientID %>").val(EsRepImpText.innerHTML);


            var escape0 = document.createElement('textarea');
            escape0.textContent = document.getElementById("<%=Editor0.ClientID%>").innerHTML;
            $("#<%=hf0.ClientID %>").val(escape0.innerHTML);


            // Editor2 

            var escape2 = document.createElement('textarea');
            escape2.textContent = document.getElementById("<%=editor2.ClientID%>").innerHTML;
            $("#<%=hf2.ClientID %>").val(escape2.innerHTML);



            var escape2N = document.createElement('textarea');
            escape2N.textContent = document.getElementById("<%=editor2N.ClientID%>").innerHTML;
            $("#<%=hf2N.ClientID %>").val(escape2N.innerHTML);

            var escape3 = document.createElement('textarea');
            escape3.textContent = document.getElementById("<%=editor3.ClientID%>").innerHTML;
            $("#<%=hf3.ClientID %>").val(escape3.innerHTML);

            var EsRepImpTextU = document.createElement('textarea');
            EsRepImpTextU.textContent = document.getElementById("<%=RepImpTextU.ClientID%>").innerHTML;
            $("#<%=RepImpTextUHid.ClientID %>").val(EsRepImpTextU.innerHTML);

        }

        /* Put your code to run after UpdatePanel finishes async postback here */
        function afterAsyncPostBack() {
            SetMVal();

        }

        /* Don't mess with any of the below code */
        Sys.Application.add_init(appl_init);

        function appl_init() {
            var pgRegMgr = Sys.WebForms.PageRequestManager.getInstance();
            pgRegMgr.add_beginRequest(beforeAsyncPostBack);
            pgRegMgr.add_endRequest(afterAsyncPostBack);
        }
        $("#<%=AddNoteFile.ClientID %>").click(function (e) {

            var escape = document.createElement('textarea');
            escape.textContent = document.getElementById("<%=editor1.ClientID%>").innerHTML;
             $("#<%=hf.ClientID %>").val(escape.innerHTML);


             var escape2 = document.createElement('textarea');
             escape2.textContent = document.getElementById("<%=editor1N.ClientID%>").innerHTML;
             $("#<%=hf1N.ClientID %>").val(escape2.innerHTML);
        })
    </script>
    <!-- inline scripts related to this page -->
    <script type="text/javascript">


        function SetMVal() {
            var EsRepImpText = document.createElement('textarea');
            EsRepImpText.textContent = document.getElementById("<%=RepImpText.ClientID%>").innerHTML;
            $("#<%=RepImpTextHid.ClientID %>").val(EsRepImpText.innerHTML);


            var escape0 = document.createElement('textarea');

            escape0.innerHTML = $("#<%=hf0.ClientID %>").val();
            document.getElementById("<%=Editor0.ClientID%>").innerHTML = escape0.textContent;

            var escape = document.createElement('textarea');

            escape.innerHTML = $("#<%=hf.ClientID %>").val();
            document.getElementById("<%=editor1.ClientID%>").innerHTML = escape.textContent;


            var escape2 = document.createElement('textarea');

            escape2.innerHTML = $("#<%=hf2.ClientID %>").val();
            document.getElementById("<%=editor2.ClientID%>").innerHTML = escape2.textContent;

            var escape3 = document.createElement('textarea');

            escape3.innerHTML = $("#<%=hf3.ClientID %>").val();
            document.getElementById("<%=editor3.ClientID%>").innerHTML = escape3.textContent;


            var EsRepImpTextU = document.createElement('textarea');

            EsRepImpTextU.innerHTML = $("#<%=RepImpTextUHid.ClientID %>").val();
            document.getElementById("<%=RepImpTextU.ClientID%>").innerHTML = EsRepImpTextU.textContent;



            var escape1N = document.createElement('textarea');

            escape1N.innerHTML = $("#<%=hf1N.ClientID %>").val();
            document.getElementById("<%=editor1N.ClientID%>").innerHTML = escape1N.textContent;


            var escape2N = document.createElement('textarea');

            escape2N.innerHTML = $("#<%=hf2N.ClientID %>").val();
            document.getElementById("<%=editor2N.ClientID%>").innerHTML = escape2N.textContent;

        }

        function GetReplys() {
            $('.modal').modal('hide');
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
            $('#modal-NoteReplys').modal({ show: true, backdrop: false });
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

        function GetDetails() {

            $('.modal').modal('hide');
            $('#Del_modal').modal({ show: true, backdrop: false });


        }
        function GetCharts() {
            $('.modal').modal('hide');
            $('#Chart_modal').modal({ show: true, backdrop: false });

        }
        function RemoveDetails(ModalName) {
            $(ModalName).modal('hide');
            $('#modal-formU').modal({ show: true, backdrop: false });

        }
        function GetNotes() {
            $('.modal').modal('hide');
            $('#modal-formU').modal({ show: true, backdrop: false });

        }
        function GetAttach() {
            $('.modal').modal('hide');
            $(".remove").click();
            $('#AllFiles_modal').modal({ show: true, backdrop: false });


            $('#modal-Replys').modal({ show: true, backdrop: false });


        }




        function GetComments() {
            $('.modal').modal('hide');
            $('#Comm_modal').modal({ show: true, backdrop: false });

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



        var prm = Sys.WebForms.PageRequestManager.getInstance();
        if (prm != null) {
            prm.add_endRequest(function (sender, e) {
                if (sender._postBackSettings.panelsToUpdate != null) {


                    //initiate dataTables plugin

                    FillTable();
                    DisplayCurrentTime();



                    $('#Delete_modal').on('show.bs.modal', function (e) {
                        var bookId = $(e.relatedTarget).data('book-id');

                        // Set bookId label equal the Note ID when Opening the Delete PUP to be using in server side
                        $(e.currentTarget).find($("#<%=NotDel.ClientID%>")).val(bookId);


                    });

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
            $('.date-picker').datepicker({
                autoclose: true,
                todayHighlight: true
            })
            $('.close').click(function () {
                $("#Done").removeAttr('style');
            });

            if (document.getElementById("<%=LblDone.ClientID%>").innerText == "A") {


                $('#Done').modal({ show: true, backdrop: true });
            }

            $('.from2').datepicker({
                autoclose: true,
                minViewMode: 1,
                format: 'mm-yyyy'
            });
            $("body").removeAttr("style");
            if ((document.getElementById("<%=LblViews.ClientID%>").innerHTML == "0")) {
                $('.modal').modal('hide');
            }
            if ((document.getElementById("<%=LblViews.ClientID%>").innerHTML == "CHRT")) {
                $('.modal').modal('hide');
                $('#Chart_modal').modal({ show: true, backdrop: false });

            }

            if ((document.getElementById("<%=LblViews.ClientID%>").innerHTML == "Fils")) {

                $(".remove").click();
                $('.modal').modal('hide');
                $('#RepFiles_modal').modal({ show: true, backdrop: false });
            }
            if ((document.getElementById("<%=LblViews.ClientID%>").innerHTML == "Details")) {

                GetDetails();
            }


            if ((document.getElementById("<%=LblViews.ClientID%>").innerHTML == "EConf")) {
                $('.modal').modal('hide');
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
            else if ((document.getElementById("<%=LblViews.ClientID%>").innerHTML == "EConfB")) {
                $('.modal').modal('hide');
                $('#modal-NoteReplys').modal({ show: true, backdrop: false });
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


            if ((document.getElementById("<%=LblViews.ClientID%>").innerHTML == "RepUPD")) {

                $('.modal').modal('hide');
                $('#UpdateReport_modal').modal({ show: true, backdrop: false });



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
                            { name: 'insertImage', className: 'btn-success' },
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




            $("#<%=RepImpText.ClientID %>").ace_wysiwyg({
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

            $("#<%=Editor0.ClientID %>").ace_wysiwyg({
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
                        null, { name: 'insertImage', className: 'btn-success' },
                        null, 'foreColor',
                        null,
                        { name: 'undo', className: 'btn-grey' },
                        { name: 'redo', className: 'btn-grey' }
                    ],
                'wysiwyg': {
                    fileUploadError: showErrorAlert

                }
            }).prev().addClass('wysiwyg-style2');

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
            $('[data-toggle="buttons"] .btn').on('click', function (e) {
                var target = $(this).find('input[type=radio]');
                var which = parseInt(target.val());
                var toolbar = $("#<%=RepImpText.ClientID %>").prev().get(0);
                if (which >= 1 && which <= 4) {
                    toolbar.className = toolbar.className.replace(/wysiwyg\-style(1|2)/g, '');
                    if (which == 1) $(toolbar).addClass('wysiwyg-style1');
                    else if (which == 2) $(toolbar).addClass('wysiwyg-style2');
                    if (which == 4) {
                        $(toolbar).find('.btn-group > .btn').addClass('btn-white btn-round');
                    } else $(toolbar).find('.btn-group > .btn-white').removeClass('btn-white btn-round');
                }
            });
            function showErrorAlert(reason, detail) {
                var msg = '';
                if (reason === 'unsupported-file-type') { msg = "Unsupported format " + detail; }
                else {
                    //console.log("error uploading file", reason, detail);
                }
                $('<div class="alert"> <button type="button" class="close" data-dismiss="alert">&times;</button>' +
                    '<strong>File Not Image</strong> ' + msg + ' </div>').prependTo('#alerts');
            }
            $('[data-toggle="buttons"] .btn').on('click', function (e) {
                var target = $(this).find('input[type=radio]');
                var which = parseInt(target.val());
                var toolbar = $("#<%=Editor0.ClientID %>").prev().get(0);
                if (which >= 1 && which <= 4) {
                    toolbar.className = toolbar.className.replace(/wysiwyg\-style(1|2)/g, '');
                    if (which == 1) $(toolbar).addClass('wysiwyg-style1');
                    else if (which == 2) $(toolbar).addClass('wysiwyg-style2');
                    if (which == 4) {
                        $(toolbar).find('.btn-group > .btn').addClass('btn-white btn-round');
                    } else $(toolbar).find('.btn-group > .btn-white').removeClass('btn-white btn-round');
                }
            });
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

                $("#<%=PartText1.ClientID %>").val(document.getElementById("<%=editor3.ClientID%>").innerHTML.substring(0, 50));



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

                $("#<%=PartText3.ClientID %>").val(document.getElementById("<%=editor2.ClientID%>").innerHTML.substring(0, 50));



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




            //////Save Temp data


            $("#<%=TempReport.ClientID %>").click(function (e) {


                var EsRepImpText = document.createElement('textarea');
                EsRepImpText.textContent = document.getElementById("<%=RepImpText.ClientID%>").innerHTML;
                $("#<%=RepImpTextHid.ClientID %>").val(EsRepImpText.innerHTML);


                var escape0 = document.createElement('textarea');
                escape0.textContent = document.getElementById("<%=Editor0.ClientID%>").innerHTML;
                $("#<%=hf0.ClientID %>").val(escape0.innerHTML);


                if ($("#<%=DateFromMain.ClientID %>").val().length <= 0) {
                    document.getElementById("<%=ReqRepDates.ClientID%>").style.display = "block";
                    e.preventDefault();
                }
                else {
                    document.getElementById("<%=ReqRepDates.ClientID%>").style.display = "none";
                }
                var varlblNoteText = document.getElementById("<%=Editor0.ClientID%>").innerHTML;
                if (varlblNoteText == null || varlblNoteText == "") {
                    document.getElementById("<%=lblNoteText.ClientID%>").style.display = "block";
                    e.preventDefault();
                }
                else {
                    document.getElementById("<%=lblNoteText.ClientID%>").style.display = "none";
                }

                var varlblNoteImpText = document.getElementById("<%=RepImpText.ClientID%>").innerHTML;
                if (varlblNoteImpText == null || varlblNoteImpText == "") {
                    document.getElementById("<%=lblNoteImpText.ClientID%>").style.display = "block";
                    e.preventDefault();
                }
                else {
                    document.getElementById("<%=lblNoteImpText.ClientID%>").style.display = "none";
                }

            });
            ////////////////////// Save new note
            $("#<%=Save.ClientID %>").click(function (e) {

                var escape1N = document.createElement('textarea');
                escape1N.textContent = document.getElementById("<%=editor1N.ClientID%>").innerHTML;
                $("#<%=hf1N.ClientID %>").val(escape1N.innerHTML);

                var escape = document.createElement('textarea');
                escape.textContent = document.getElementById("<%=editor1.ClientID%>").innerHTML;

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


            $('.FileNoteUPD').change(function (event) {
                var tmppath = URL.createObjectURL(event.target.files[0]);
                $("#ValidatNoteUPD").text(' ');

                var ext = $('.FileNoteUPD').val().split('.').pop().toLowerCase();
                if ($.inArray(ext, ['gif', 'doc', 'docx', 'xls', 'xlsx', 'xlt', 'ppt', 'pot', 'pps', 'xps', 'dot', 'dotx', 'pdf', 'png', 'jpg', 'jpeg']) == -1) {
                    $("#ValidatNoteUPD").text("يجب أن تختار ملف مناسب ");
                    $('.FileNoteUPD').prop('value', '');
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
            $('#Delete_modal').on('show.bs.modal', function (e) {
                var bookId = $(e.relatedTarget).data('book-id');

                // Set bookId label equal the Note ID when Opening the Delete PUP to be using in server side
                $(e.currentTarget).find($("#<%=NotDel.ClientID%>")).val(bookId);


            });
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
                format: 'mm-yyyy'
            });




            $('#DeleteReport_modal').on('show.bs.modal', function (e) {
                var bookId = $(e.relatedTarget).data('book-id');
                // Set bookId label equal the Report ID when Opening the Delete PUP to be using in server side
                $(e.currentTarget).find($("#<%=BookReport.ClientID%>")).val(bookId);


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


        }

    </script>

</asp:Content>
