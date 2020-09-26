<%@ Page Title="الخطة السنوية" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Plans.aspx.cs" Inherits="Plans" %>


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
    <link rel="stylesheet" href="assets/css/jquery-ui.min.css" />

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

        .just-padding {
            padding: 15px;
        }

        .list-group.list-group-root {
            padding: 0;
            overflow: hidden;
        }

            .list-group.list-group-root .list-group {
                margin-bottom: 0;
            }

            .list-group.list-group-root .list-group-item {
                border-radius: 0;
                border-width: 1px 0 0 0;
            }

            .list-group.list-group-root > .list-group-item:first-child {
                border-top-width: 0;
            }

            .list-group.list-group-root > .list-group > .list-group-item {
                padding-left: 30px;
            }

            .list-group.list-group-root > .list-group > .list-group > .list-group-item {
                padding-left: 45px;
            }

        .list-group-item .glyphicon {
            margin-right: 5px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="PageTitle" runat="Server">
    الخطة السنوية
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" runat="Server">

    <div id="MainTable" style="display: block;" runat="server">
        <div class="row">
            <div class="col-xs-12">
                <h3>الخطة السنوية</h3>

                <div class="row">
                    <div class="col-xs-3">
                        <h4 class="pink" runat="server" id="NewReg" style="float: right;">
                            
                            <a role='button' class="btn btn-purple large white" data-rel="tooltip" title="تسجيل سنة جديدة" href='#New_modal' data-toggle='modal'>
                                <span>تسجيل سنة جديدة</span>
                            </a>
                        </h4>

                    </div>
                    <asp:Label ID="Rett" runat="server" Text="" CssClass="Rett" ForeColor="#ff3c3c"></asp:Label>

                    <div class="col-xs-3">
                        <div id="SucTransSec" dir="ltr" style="width: 500px" runat="server" visible="false" class="alert alert-block alert-success">
                            <strong>
                                <i class="ace-icon fa fa-check-square-o icon-only bigger-150"></i>
                                <asp:Label ID="LblSecTranfer" runat="server" Text=""></asp:Label>

                            </strong>

                        </div>

                        <div id="SucTransAdm" runat="server" dir="ltr" visible="false" style="width: 500px" class="alert alert-block alert-success">
                            <strong>
                                <i class="ace-icon fa fa-check-square-o icon-only bigger-150"></i>
                                <asp:Label ID="LblAdmTransfer" runat="server" Text=""></asp:Label>
                            </strong>

                        </div>
                        <div id="Suc" runat="server" visible="false" class="alert alert-block alert-success">
                            <strong>
                                <i class="ace-icon fa fa-check-square-o icon-only bigger-150"></i>
                                تم الحفظ !
                            </strong>

                        </div>
                        <div id="SucDel" runat="server" visible="false" class="alert alert-block alert-success">
                            <strong>
                                <i class="ace-icon fa fa-check-square-o icon-only bigger-150"></i>
                                تم الحذف بنجاح !
                            </strong>

                        </div>
                    </div>




                </div>


                <!-- div.table-responsive -->

                <!-- div.dataTables_borderWrap -->
                <div>

                    <div class="col-xs-12 col-sm-12 pricing-span-body">

                        <asp:DataList ID="EmployeesData" Style="width: 100%" RepeatDirection="Horizontal" RepeatColumns="1" OnItemDataBound="EmployeesData_ItemDataBound1" runat="server">
                            <ItemTemplate>


                                <div class="col-xs-4 col-sm-12 pricing-box" style="margin-bottom: 10px;">
                                    <div class="widget-box pricing-box-small widget-color-green">
                                        <div class="widget-header">
                                            <span>
                                                <h5 class="widget-title bigger lighter">

                                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("YearName") %>'></asp:Label></h5>
                                            </span>
                                            <span>
                                                <asp:LinkButton CssClass="white" data-rel="tooltip" title="تعديل" ID="Edit" CommandArgument='<%# Eval("ID") %>' OnCommand="Edit_Command" runat="server"><i class="ace-icon fa fa-pencil icon-only bigger-120"></i> </asp:LinkButton>

                                                <a class="white" role='button' data-rel="tooltip" title="حذف" href='#Del_modal' data-toggle='modal' data-book-id='<%# Eval("ID") %>'>
                                                    <i class="ace-icon fa fa-close icon-only bigger-120"></i>
                                                </a>

                                            </span>
                                        </div>

                                        <div class="widget-body">
                                            <div class="widget-main no-padding" style="height: 300px; overflow-y: scroll;">
                                                <ul class="list-unstyled list-striped pricing-table">


                                                    <asp:Repeater ID="SectionList" OnItemDataBound="SectionList_ItemDataBound" runat="server">
                                                        <ItemTemplate>
                                                            <li>

                                                                <div class="just-padding ">

                                                                    <div class="row bg-light border-bottom" style="padding-top:3px; padding-bottom:10px;">
                                                                        <div class="col-lg-4">
                                                                            <span style="text-align: right;" class="text-info font-weight-bold " >

                                                                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("SectionName") %>'></asp:Label>

                                                                            </span>
                                                                        </div>
                                                                        <div class="col-lg-4">

                                                                            <a class="btn  btn-purple " role='button' data-rel="tooltip" title="حذف من الخطة" href='#Del_Section' data-toggle='modal' data-book-id='<%# string.Concat(Eval("SectionID"),",",Eval("PlanID"))%>'>حذف  من الخطة
                                                                                <i class="ace-icon fa fa-close icon-only bigger-120"></i><i class='hidden'>حذف  من الخطة</i>
                                                                            </a>
                                                                        </div>
                                                                        <div class="col-lg-3">
                                                                            <div class="btn  btn-purple ">
                                                                                <asp:LinkButton ID="SecYear" CommandArgument='<%# string.Concat(Eval("SectionID"),",",Eval("PlanID"))%>' OnCommand="SecYear_Command" CssClass="text-white" runat="server">تعديل الخطة<i class="ace-icon fa fa-pencil icon-only bigger-120"></i></asp:LinkButton>
                                                                            </div>
                                                                        </div>

                                                                    </div>


                                                                    <div>
                                                                        <asp:Repeater ID="AdminList" runat="server">
                                                                            <ItemTemplate>
                                                                                <div>
                                                                                    <div class="row" style="padding-top:5px; padding-bottom:15px;">
                                                                                        <div class="col-lg-4">
                                                                                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("AdmName") %>'></asp:Label>


                                                                                        </div>
                                                                                        <div class="col-lg-4">
                                                                                            <a class="text-danger" role='button' data-rel="tooltip" title="حذف الادارة من الخطة" href='#Del_Admin' data-toggle='modal' data-book-id='<%#Eval("PIDs")%>'>
                                                                                                <i class="ace-icon fa fa-close icon-only bigger-150"></i><span class='hidden'>حذف الإدارة متوسطة من الخطة</span>
                                                                                            </a>
                                                                                        </div>

                                                                                        <div class="col-lg-4">
                                                                                            <div class="btn  btn-warning ">
                                                                                                <asp:LinkButton ID="AdmYear" CssClass="white" CommandArgument='<%# string.Concat(Eval("AdmID"),",",Eval("PlanID"),",",Eval("SectonID"))%>' OnCommand="AdmYear_Command" runat="server">تعديل الخطة</asp:LinkButton>
                                                                                            </div>
                                                                                        </div>
                                                                                    </div>

                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </asp:Repeater>

                                                                    </div>





                                                                </div>




                                                            </li>
                                                            <asp:Label ID="IDss" runat="server" Visible="false" Text='<%# Eval("PlanID") %>'></asp:Label>

                                                            <asp:Label ID="SectionI" runat="server" Visible="false" Text='<%# Eval("SectionID") %>'></asp:Label>

                                                        </ItemTemplate>

                                                    </asp:Repeater>


                                                </ul>



                                            </div>


                                        </div>
                                    </div>
                                </div>


                                <asp:Label ID="IDs" runat="server" Visible="false" Text='<%# Eval("ID") %>'></asp:Label>


                            </ItemTemplate>
                        </asp:DataList>

                    </div>
                </div>
            </div>
        </div>


    </div>

    <!---------------------------------->

    <div id="UPDSecYear" style="display: none" runat="server">
        <div style="background-color: #FFFFFF; min-height: 350px;">

            <div class="modal-header">
                <h4 class="blue bigger">نقل إدارة عليا لسنة بشرط أن تكون غير مسجلة من قبل</h4>
            </div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>

                    <div class="form-horizontal" role="form">
                        <div class="row" runat="server" id="Div2">
                            <div class="col-sm-12 control-label">
                                سوف يتم نقل الإدارة العليا بادارتها وجميع ملاحظتها للسنه 
                            </div>
                            <br />
                            <br />
                            <div class="col-sm-12">
                                <label class="col-sm-10 control-label " for="form-field-1">(السنوات المسجل بها الإدارة العليا فقط) </label>
                                <div class="col-sm-5">
                                    <div style="width: 210px; height: 60px;">
                                        <asp:DropDownList class="chosen-select chosen-rtl form-control" AppendDataBoundItems="true" ID="PlansSec" runat="server" data-placeholder="اختر الخطة">
                                            <asp:ListItem Value="0">اختر الخطة</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="PlansSec" InitialValue="0" runat="server" ValidationGroup="GS" ForeColor="#ff3c3c" ErrorMessage="اختيار الخطة مطلوب  *"></asp:RequiredFieldValidator>
                                </div>
                            </div>



                        </div>


                    </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div align="center" class="col-sm-12" style="padding-top: 20px;">

                <div class="col-sm-3" style="padding-right: 35px;">
                    <asp:Button ID="SavePlanSection" OnClick="SavePlanSection_Click1" CssClass="btn btn-success" ValidationGroup="GS" Text="حفظ" runat="server"></asp:Button>
                </div>

            </div>
            <div>
                <asp:LinkButton ID="LinkButton7" runat="server" OnClick="BackTables_Click" Style="float: left; margin-top: -10px;"><i class="ace-icon fa fa-arrow-left icon-only purple bigger-250"></i></asp:LinkButton>
            </div>
        </div>
    </div>

    <!---------------------------------->

    <div id="UPDAdmYear" style="display: none" runat="server">
        <div style="background-color: #FFFFFF; min-height: 350px;">

            <div class="modal-header">
                <h4 class="blue bigger">نقل ادارة لسنة</h4>
            </div>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>

                    <div class="form-horizontal" role="form">
                        <div class="row" runat="server" id="Div3">
                            <div class="col-sm-12 control-label">
                                سوف يتم نقل الإدارة متوسطة وجميع ملاحظتها للسنه 
                            </div>
                            <br />
                            <br />
                            <div class="col-sm-12">
                                <label class="col-sm-10 control-label " for="form-field-1">(السنوات المسجل بها الإدارة العليا التابع لها الإدارة متوسطة وغير مسجل بها نفس الإدارة متوسطة فقط) </label>
                                <div class="col-sm-5">
                                    <div style="width: 210px; height: 60px;">
                                        <asp:DropDownList class="chosen-select chosen-rtl form-control" AppendDataBoundItems="true" ID="PlansAdm" runat="server" data-placeholder="اختر الخطة">
                                            <asp:ListItem Value="0">اختر الخطة</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="PlansAdm" InitialValue="0" runat="server" ValidationGroup="GAd" ForeColor="#ff3c3c" ErrorMessage="اختيار الخطة مطلوب  *"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                        </div>


                    </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div align="center" class="col-sm-12" style="padding-top: 20px;">

                <div class="col-sm-3" style="padding-right: 35px;">
                    <asp:Button ID="SavePlanAdm" OnClick="SavePlanAdm_Click1" Text="حفظ" CssClass="btn btn-success" ValidationGroup="GAd" runat="server" />
                </div>

            </div>
            <div>
                <asp:LinkButton ID="LinkButton3" runat="server" OnClick="BackTables_Click" Style="float: left; margin-top: -10px;"><i class="ace-icon fa fa-arrow-left icon-only purple bigger-250"></i></asp:LinkButton>
            </div>
        </div>
    </div>


    <div id="UPDAT" style="display: none" runat="server">
        <div style="background-color: #FFFFFF; min-height: 350px;">



            <div class="modal-header">
                <h4 class="blue bigger">تعديل بيانات سنة / خطة عمل</h4>
            </div>
            <asp:UpdateProgress ID="UpdateProgress13"
                AssociatedUpdatePanelID="UpdatePanel50"
                runat="server">
                <ProgressTemplate>
                    <i class="ace-icon fa fa-spinner fa-spin green bigger-125"></i>جارى التحميل...            
                </ProgressTemplate>
            </asp:UpdateProgress>
            <asp:UpdatePanel ID="UpdatePanel50" runat="server">
                <ContentTemplate>
                    <div id="SucUpdate" runat="server" visible="false" class="alert alert-block alert-success">
                        <strong>
                            <i class="ace-icon fa fa-check-square-o icon-only bigger-150"></i>
                            تم الحفظ !
                        </strong>

                    </div>
                    <div class="form-horizontal" role="form">
                        <div class="row" runat="server" id="YearNamU">

                            <div class="col-sm-12">
                                <label class="col-sm-10 control-label " for="form-field-1">اسم الخطة / الخطة </label>
                                <div class="col-sm-5">
                                    <table>
                                        <tr>
                                            <td>
                                                <input id="YearNameU" runat="server" class="form-control" style="width: 300px;" type="text" />
                                            </td>
                                            <td><a class="date-ownU fa fa-calendar bigger" href="#"></a>
                                            </td>
                                        </tr>
                                    </table>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="YearNameU" runat="server" ValidationGroup="GU" ForeColor="#ff3c3c" ErrorMessage="اسم الخطة مطلوب  *"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <asp:Label ID="RettU" runat="server" Text="" CssClass="RettU" ForeColor="#ff3c3c"></asp:Label>

                            <div class="row">
                                <div class="col-sm-12" style="padding-right: 50px;">

                                    <asp:LinkButton ID="SaveUpdates" CssClass="btn btn-sm btn-primary" OnClick="SaveUpdates_Click" ValidationGroup="GU" runat="server"> <i class="ace-icon fa fa-check-square-o icon-only bigger-150"></i>
                        استمرار</asp:LinkButton>


                                </div>
                            </div>

                        </div>
                        <div class="row" style="display: none" runat="server" id="YearDetailsU">

                            <div class="col-sm-12">


                                <label class="col-sm-10 control-label " for="form-field-1">اختر الإدارة العليا  </label>

                                <div class="col-sm-5">


                                    <div>
                                        <asp:DropDownList class="chosen-select chosen-rtl form-control" ID="SectorU" AutoPostBack="true" OnSelectedIndexChanged="SectorU_SelectedIndexChanged" runat="server" data-placeholder="الإدارات عليا">
                                        </asp:DropDownList>
                                    </div>

                                </div>
                            </div>

                            <div class="col-sm-12">
                                <label class="col-sm-2 control-label " for="form-field-1">الادارات</label>

                                <div class="col-sm-10">
                                    <div>
                                        <asp:CheckBox ID="AddAllAdms" Checked="true" Visible="false" runat="server" />
                                    </div>
                                    <asp:CheckBox Visible="false" ID="chkAllU" Text="كل ادارات القطاع" runat="server" />
                                    <asp:CheckBoxList ID="PermChecksU" OnSelectedIndexChanged="PermChecksU_SelectedIndexChanged" AutoPostBack="true" runat="server">
                                    </asp:CheckBoxList>
                                </div>
                                <div></div>
                            </div>
                            <div class="row">
                                <div class="col-sm-12" align="center" style="padding-right: 35px; padding-top: 20px;">

                                    <asp:Button Text="حفظ" ID="SaveAllU" OnClick="SaveAllU_Click1" CssClass="btn btn-success " runat="server" />

                                </div>
                            </div>

                            <div class="row">
                                <div class="col-sm-12" style="margin-right: 35px;">
                                    <table style="width: 90%;">
                                        <tr>
                                            <td class="center">
                                                <table border="1" style="width: 100%; border: 1px dashed #b6fb98;">
                                                    <thead class="TableHead">
                                                        <tr>
                                                            <th class="center">حذف الإدارة العليا</th>
                                                            <th class="center">الإدارة العليا </th>
                                                            <th class="center">الإدارات المتوسطة</th>
                                                        </tr>
                                                    </thead>
                                                    <asp:Repeater ID="SectionList2U" OnItemDataBound="SectionList2U_ItemDataBound" runat="server">
                                                        <ItemTemplate>
                                                            <tr>
                                                                <td class="center" style="vertical-align: top;">

                                                                    <asp:LinkButton ID="DelSectionU" CssClass="btn btn-warning" OnCommand="DelSectionU_Command" ToolTip="حذف الإدارة العليا من الخطة" CommandArgument='<%# string.Concat(Eval("SectionID"),",",Eval("PlanID"))%>' runat="server">حذف<i class="ace-icon fa fa-close icon-only bigger-120"></i></asp:LinkButton>
                                                                </td>
                                                                <td style="text-align: right; width: 30%; vertical-align: top; padding-right: 20px;">

                                                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("SectionName") %>'></asp:Label>

                                                                </td>

                                                                <td style="text-align: right; padding-right: 30px; width: 70%">
                                                                    <table style="width: 100%">

                                                                        <tbody>
                                                                            <asp:Repeater ID="AdminListU" runat="server">
                                                                                <ItemTemplate>
                                                                                    <tr>

                                                                                        <td style="text-align: right">
                                                                                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("AdmName") %>'></asp:Label>
                                                                                            <hr class="hr-14" style="width: 100%" />

                                                                                        </td>
                                                                                        <td class="center" style="width: 70px; vertical-align: top; padding-right: 20px;">
                                                                                            <asp:LinkButton ID="DelAdmsU" CssClass="btn  btn-warning " OnCommand="DelAdmsU_Command" ToolTip="حذف الادارة من الخطة" CommandArgument='<%#Eval("PIDs")%>' runat="server">حذف<i class="ace-icon fa fa-close icon-only bigger-120"></i></asp:LinkButton>

                                                                                        </td>
                                                                                    </tr>
                                                                                </ItemTemplate>
                                                                            </asp:Repeater>
                                                                        </tbody>
                                                                    </table>
                                                                </td>

                                                            </tr>
                                                            <asp:Label ID="IDss" runat="server" Visible="false" Text='<%# Eval("PlanID") %>'></asp:Label>

                                                            <asp:Label ID="SectionI" runat="server" Visible="false" Text='<%# Eval("SectionID") %>'></asp:Label>

                                                        </ItemTemplate>

                                                    </asp:Repeater>


                                                </table>
                                            </td>



                                        </tr>


                                    </table>
                                </div>
                            </div>
                        </div>

                    </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div align="center" class="col-sm-12" style="padding-top: 20px;">


                <asp:LinkButton CssClass="btn btn-sm btn-success" ID="LinkButton4" runat="server" OnClick="BackTables_Click"> حفظ الكل <i class="ace-icon fa fa-check-square-o icon-only bigger-150"></i></asp:LinkButton>

            </div>
            <div>
                <asp:LinkButton ID="LinkButton2" runat="server" OnClick="BackTables_Click" Style="float: left; margin-top: -10px;"><i class="ace-icon fa fa-arrow-left icon-only purple bigger-250"></i></asp:LinkButton>
            </div>
        </div>
    </div>

    <div id="Del_Section" data-backdrop="static" data-keyboard="false" style="top: 20%; width:60%" aria-hidden="false" class="modal fade" tabindex="-1">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="widget-header">
                    <button type="button" class="close red" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                    <h4 class="modal-title">تأكيد الحذف</h4>
                </div>
                <div class="modal-body">
                    <p>هل متأكد من حذف هذه الإدارة العليا من الخطة ؟</p>
                    <input style="display: none" type="text" runat="server" name="bookSection" id="bookSection" value="" />
                </div>
                <div class="modal-footer">
                    <asp:LinkButton CssClass="btn btn-danger" runat="server" ID="DelSection" Text="حذف" OnClick="DelSection_Click" />
                    
                </div>
            </div>
        </div>
    </div>

    <div id="Del_Admin" data-backdrop="static" data-keyboard="false" style="top: 20% ; width:60%" aria-hidden="false" class="modal fade" tabindex="-1">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="widget-header">
                    <button type="button" class="close red" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                    <h4 class="modal-title">تأكيد الحذف</h4>
                </div>
                <div class="modal-body">
                    <p>هل متأكد من حذف هذه الادارة من الخطة ؟</p>
                    <input style="display: none" type="text" runat="server" name="bookAdmin" id="bookAdmin" value="" />
                </div>
                <div class="modal-footer">
                    <asp:LinkButton CssClass="btn btn-danger" runat="server" ID="DelAdmin" Text="حذف" OnClick="DelAdmin_Click" />
                    
                </div>
            </div>
        </div>
    </div>

    <div id="Del_modal" data-backdrop="static" data-keyboard="false" style="top: 20%" aria-hidden="false" class="modal fade" tabindex="-1">
        <div class="modal-dialog" >
            <div class="modal-content">
                <div class="modal-body">
                    <div style="margin-top: 7px;" class="row">

                        <div class="col-sm-1" style="text-align: right;">
                            
                        </div>
                        <div class="col-lg-8" style="text-align: right;">
                            <h4 class="align-right">سوف يتم حذف الخطة </h4>
                        </div>
                        <div class="col-lg-3">
                            <button type="button" class="close red" data-dismiss="modal">
                                <img src="assets/images/Icons/BasicIcon/close.png" height="46" /></button>
                        </div>


                        <input style="display: none" type="text" runat="server" name="bookId" id="bookId" value="" />
                    </div>
                </div>
                <div class="modal-footer">

                    <asp:Button ID="DelEmployee"  ImageAlign="AbsMiddle" Text="حذف"  OnClick="DelEmployee_Click1" CssClass="btn btn-danger" runat="server" />
                   
                </div>
            </div>
        </div>
    </div>
    <div id="New_modal" data-backdrop="static" data-keyboard="false" style="top: 20% ; width:50%" aria-hidden="false" class="modal fade" tabindex="-1">
        <div class="modal-dialog" style="width: 60%; padding-right: 20%;">
            <div class="modal-content">
                <div class="modal-body">
                    <div style="margin-top: 7px;" class="row">

                        <div class="col-sm-1" style="text-align: right;">
                            
                        </div>
                        <div class="col-lg-8" style="text-align: right;">
                            <h4 class="align-right">الخطة  </h4>
                            <div class="row">
                                <div class="col-md-10">
                                    <input id="YearNam" runat="server" class="form-control" style="width: 300px;" type="text" />
                                </div>
                                <div class="col-md-2"><a class="date-own fa fa-calendar bigger" href="#"></a></div>
                            </div>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="YearNam" runat="server" ValidationGroup="GN" ForeColor="#ff3c3c" ErrorMessage="اسم الخطة مطلوب  *"></asp:RequiredFieldValidator>

                        </div>
                        <div class="col-lg-3">

                            <button type="button" class="close red" data-dismiss="modal">
                                <img src="assets/images/Icons/BasicIcon/close.png" height="46" /></button>
                        </div>


                    </div>
                </div>
                <div class="modal-footer">

                    <asp:Button ID="SaveYear" Style="margin-top: -12px;" ImageAlign="AbsMiddle" OnClick="SaveYear_Click1" ValidationGroup="GN" runat="server" />
                    <span><a href="#">
                        </a>
                    </span>
                </div>
            </div>
        </div>
    </div>

    <div id="NEW" style="display: none" runat="server">
        <div style="background-color: #FFFFFF; min-height: 350px;">



            <div class="modal-header">
                <h4 class="blue bigger">تسجيل خطة عمل جديدة </h4>
            </div>

            <asp:UpdateProgress ID="UpdateProgress1z"
                AssociatedUpdatePanelID="UpdatePanel4"
                runat="server">
                <ProgressTemplate>
                    <i class="ace-icon fa fa-spinner fa-spin green bigger-125"></i>جارى التحميل...            
                </ProgressTemplate>
            </asp:UpdateProgress>
            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                <ContentTemplate>
                    <div id="SucNew" runat="server" visible="false" class="alert alert-block alert-success">
                        <strong>
                            <i class="ace-icon fa fa-check-square-o icon-only bigger-150"></i>
                            تم الحفظ !
                        </strong>

                    </div>

                    <div class="form-horizontal" role="form">



                        <div class="row" style="display: none" runat="server" id="YearDetails">

                            <div class="col-sm-4">


                                <label class="col-sm-10 control-label " for="form-field-1">اختر الإدارة العليا  </label>

                                <div class="col-sm-5">


                                    <div>
                                        <asp:DropDownList class="chosen-select chosen-rtl form-control" ID="Admins" AutoPostBack="true" OnSelectedIndexChanged="Admins_SelectedIndexChanged" runat="server" data-placeholder="الإدارات عليا">
                                        </asp:DropDownList>
                                    </div>

                                </div>
                            </div>

                            <div class="col-sm-8">
                                <label class="col-sm-2 control-label " for="form-field-1">الادارات</label>

                                <div class="col-sm-10">


                                    <asp:CheckBox Visible="false" ID="chkAll" Text="كل ادارات القطاع" runat="server" />
                                    <asp:CheckBoxList ID="PermChecks" runat="server">
                                    </asp:CheckBoxList>
                                </div>
                                <div></div>
                            </div>
                            <div class="row">
                                <div class="col-sm-12" style="padding-right: 35px; padding-top: 20px;">

                                    <asp:Button Text="حفظ" ID="SaveAll" OnClick="SaveAll_Click1" ValidationGroup="G" runat="server" />

                                </div>
                            </div>

                            <div class="row">
                                <div class="col-sm-12" style="margin-right: 35px;">
                                    <table style="width: 90%;">

                                        <tr>
                                            <td class="center">
                                                <table border="1" style="width: 100%; border: 1px dashed #b6fb98;">
                                                    <thead class="TableHead">
                                                        <tr>
                                                            <th class="center">حذف الوكلة </th>
                                                            <th class="center">الإدارة العليا</th>
                                                            <th class="center">الإدارات المتوسطة</th>
                                                        </tr>
                                                    </thead>
                                                    <asp:Repeater ID="SectionList2" OnItemDataBound="SectionList2_ItemDataBound" runat="server">
                                                        <ItemTemplate>
                                                            <tr>


                                                                <td class="center" style="vertical-align: top;">

                                                                    <asp:LinkButton ID="LinkButton1" CssClass="btn btn-white btn-warning btn-round" OnCommand="LinkButton1_Command" ToolTip="حذف الإدارة العليا من الخطة" CommandArgument='<%# string.Concat(Eval("SectionID"),",",Eval("PlanID"))%>' runat="server">حذف<i class="ace-icon fa fa-close icon-only bigger-120"></i></asp:LinkButton>
                                                                </td>
                                                                <td style="text-align: right; width: 30%; padding-right: 20px; vertical-align: top">

                                                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("SectionName") %>'></asp:Label>

                                                                </td>
                                                                <td style="text-align: right; padding-right: 30px; width: 70%">
                                                                    <table style="width: 100%">
                                                                        <asp:Repeater ID="AdminList" runat="server">
                                                                            <ItemTemplate>
                                                                                <tr>

                                                                                    <td style="text-align: right; padding-right: 20px;">
                                                                                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("AdmName") %>'></asp:Label>
                                                                                        <hr class="hr-14" style="width: 100%" />

                                                                                    </td>
                                                                                    <td class="center" style="vertical-align: top; width: 70px;">
                                                                                        <asp:LinkButton ID="DelAdms" CssClass="btn btn-white btn-warning btn-round" OnCommand="DelAdms_Command" ToolTip="حذف الادارة من الخطة" CommandArgument='<%#Eval("PIDs")%>' runat="server">حذف<i class="ace-icon fa fa-close icon-only bigger-120"></i></asp:LinkButton>

                                                                                    </td>
                                                                                </tr>
                                                                            </ItemTemplate>
                                                                        </asp:Repeater>

                                                                    </table>
                                                                </td>

                                                            </tr>
                                                            <asp:Label ID="IDss" runat="server" Visible="false" Text='<%# Eval("PlanID") %>'></asp:Label>

                                                            <asp:Label ID="SectionI" runat="server" Visible="false" Text='<%# Eval("SectionID") %>'></asp:Label>

                                                        </ItemTemplate>

                                                    </asp:Repeater>


                                                </table>
                                            </td>



                                        </tr>


                                    </table>
                                </div>
                            </div>

                        </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div align="center" class="col-sm-12" style="padding-top: 20px;">

                <asp:LinkButton CssClass="btn btn-sm btn-success" ID="LinkFinal" runat="server" OnClick="BackTables_Click"> انهاء <i class="ace-icon fa fa-check-square-o icon-only bigger-150"></i></asp:LinkButton>


            </div>
            <div>
                <asp:LinkButton ID="LinkButton9" runat="server" OnClick="BackTables_Click" Style="float: left; margin-top: -10px;"><i class="ace-icon fa fa-arrow-left icon-only purple bigger-250"></i></asp:LinkButton>
            </div>
        </div>
    </div>
    <!--------------------------------->

    <asp:Label ID="LablSites" Style="display: none;" runat="server" Text=""></asp:Label>

    <asp:Label ID="LblEdit" Style="display: none;" runat="server" Text=""></asp:Label>
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
    <script src="assets/js/bootstrap-datepicker.min.js"></script>
    <script src="assets/js/bootstrap-timepicker.min.js"></script>
    <script src="assets/js/moment.min.js"></script>
    <script src="assets/js/daterangepicker.min.js"></script>
    <script src="assets/js/bootstrap-datetimepicker.min.js"></script>
    <!-- inline scripts related to this page -->
    <script type="text/javascript">

        $(function () {

            $('.list-group-item').on('click', function () {
                $('.glyphicon', this)
                    .toggleClass('glyphicon-chevron-right')
                    .toggleClass('glyphicon-chevron-down');
            });

        });

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


            $("[id*=chkAllU]").bind("click", function () {

                if ($("[id*=chkAllU]").is(":checked")) {
                    $("[id*=PermChecksU] input").prop("checked", true);

                } else {
                    $("[id*=PermChecksU] input").prop("checked", false);
                }
            });
            $("[id*=PermChecksU] input").bind("click", function () {

                if ($("[id*=PermChecksU] input:checked").length == $("[id*=PermChecksU] input").length) {
                    $("[id*=chkAllU]").prop("checked", true);
                } else {
                    $("[id*=chkAllU]").prop("checked", false);
                }
            });


            $('#Del_modal').on('show.bs.modal', function (e) {
                var bookId = $(e.relatedTarget).data('book-id');
                $(e.currentTarget).find($("#<%=bookId.ClientID%>")).val(bookId);


            });

            $('#Del_Admin').on('show.bs.modal', function (e) {
                var bookId = $(e.relatedTarget).data('book-id');
                $(e.currentTarget).find($("#<%=bookAdmin.ClientID%>")).val(bookId);


            });
            $('#Del_Section').on('show.bs.modal', function (e) {
                var bookId = $(e.relatedTarget).data('book-id');
                $(e.currentTarget).find($("#<%=bookSection.ClientID%>")).val(bookId);


            });
            $('.date-ownU').datepicker({
                minViewMode: 2,
                format: 'yyyy'
            }).on('changeDate', function (e) {

                document.getElementById("<%=YearNameU.ClientID%>").value = $(".date-ownU").datepicker("getDate").getFullYear();
                    $(this).datepicker('hide');

                });
            $('.date-own').datepicker({
                minViewMode: 2,
                format: 'yyyy'
            }).on('changeDate', function (e) {
                document.getElementById("<%=YearNam.ClientID%>").value = $(".date-own").datepicker("getDate").getFullYear();
                    $(this).datepicker('hide');

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

            $(".show-option").tooltip({
                show: {
                    effect: "slideDown",
                    delay: 250
                }
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
                    //.wrap("<div class='dataTables_borderWrap' />")   //if you are applying horizontal scrolling (sScrollX)
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
