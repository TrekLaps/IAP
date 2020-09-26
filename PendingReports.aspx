<%@ Page Title="الملاحظات والتوصيات " Language="C#" MasterPageFile="~/MasterPage.master" CodeFile="~/PendingReports.aspx.cs" AutoEventWireup="true" Inherits="PendingReports" %>





<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <!-- page specific plugin styles -->
    <link rel="stylesheet" href="assets/css/jquery-ui.custom.min.css" />
    <link rel="stylesheet" href="assets/css/chosen.min.css" />
    <link rel="stylesheet" href="assets/css/bootstrap-datepicker3.min.css" />
    <link rel="stylesheet" href="assets/css/bootstrap-timepicker.min.css" />
    <link rel="stylesheet" href="assets/css/daterangepicker.min.css" />
    <link rel="stylesheet" href="assets/css/bootstrap-datetimepicker.min.css" />
    <link rel="stylesheet" href="assets/css/bootstrap-colorpicker.min.css" />

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

 
    </style>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="PageTitle" runat="Server">
    الملاحظات والتوصيات
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" runat="Server">



    <asp:UpdateProgress ID="UpdateProgress1z"
        AssociatedUpdatePanelID="UpdatePanel4"
        runat="server">
        <ProgressTemplate>
            <i class="ace-icon fa fa-spinner fa-spin green bigger-125"></i>جارى التحميل...            
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
        <ContentTemplate>

            <div class="row">
                <div class="col-xs-12">
                    <h3><img src="assets/icons/BasicIcon/Tri2.png" style="height: 49px; margin-left: 11px; margin-right: 2px; margin-top: -5px; "/>الرد على الملاحظات   </h3>

                    <div class="col-xs-3"><div class="form-group">
                            <label class=" control-label blue" for="form-field-1">بحث  تبعا للسنوات </label>

                            <div class="col-sm-12">


                               <div>
                                    <asp:DropDownList class="chosen-select chosen-rtl form-control" AppendDataBoundItems="true"  ID="PlansSearch" AutoPostBack="true" OnSelectedIndexChanged="PlansSearch_SelectedIndexChanged" runat="server" data-placeholder="الخطة">
                                        <asp:ListItem Value="0" Text="كل السنوات" Selected="True" />
                                    </asp:DropDownList>
                                </div>

                                <asp:Label ID="Label1" Style="display: none;" runat="server" Text=""></asp:Label>

                            </div>
                        </div></div>
                    <div class="col-xs-12 col-sm-3">

                        <div class="form-group">
                            <label class=" control-label blue" for="form-field-1">بحث بالإدارة العليا  المرسل له الملاحظة  </label>



                           <div>
                                <asp:DropDownList class="chosen-select chosen-rtl form-control"  ID="Sector" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="Sector_SelectedIndexChanged" runat="server" data-placeholder="الإدارات عليا">
                                    <asp:ListItem Value="0" Text="كل الإدارات عليا" Selected="True" />

                                </asp:DropDownList>
                            </div>



                        </div>

                    </div>
                    <div class="col-xs-12 col-sm-3" style="display:none;" >

                        <div class="form-group">
                            <label class=" control-label blue" for="form-field-1">بحث  تبعا لرقم الملاحظة   أو تاريخ اصداره </label>

                            <div class="col-sm-12">


                               <div>
                                    <asp:DropDownList class="chosen-select chosen-rtl form-control" AppendDataBoundItems="true"  ID="Admins1" AutoPostBack="true" OnSelectedIndexChanged="Admins1_SelectedIndexChanged" runat="server" data-placeholder="كود - تاريخ ">
                                        <asp:ListItem Value="0" Text="كل الملاحظات" Selected="True" />

                                    </asp:DropDownList>
                                </div>

                                <asp:Label ID="Datt" Style="display: none;" runat="server" Text=""></asp:Label>

                            </div>
                        </div>
                    </div>

                    <div class="col-xs-12 col-sm-3">
                        <label class=" control-label blue" for="form-field-1">بحث الإدارة متوسطة المرسل لها الملاحظة  </label>
                       <div>
                            <asp:DropDownList class="chosen-select chosen-rtl form-control" AppendDataBoundItems="true"  ID="Mang" AutoPostBack="true" OnSelectedIndexChanged="Mang_SelectedIndexChanged" runat="server" data-placeholder="الإدارات المتوسطة">
                                <asp:ListItem Selected="True" Text="كلالإدارات المتوسطة" Value="0"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="col-xs-12 col-sm-1">


                        <label class=" control-label blue" for="form-field-1">حالة التكرار  </label>
                        <div class="form-group">
                            <label>
                                <input name="switch-field-1" runat="server" id="RepeatSearch" onchange="CheckRepeate();" class="ace ace-switch ace-switch-7" type="checkbox" />
                                <span class="lbl"></span>
                            </label>
                            <span>
                                <asp:CheckBox ID="CheckRepeat"  Text="لايهم حالة التكرار" style="display:none;" Checked="true" AutoPostBack="true" OnCheckedChanged="CheckRepeat_CheckedChanged" runat="server" />
                            </span>
                        </div>

                    </div>

                    <div class="col-xs-12 col-sm-2">
                            <div class="form-group">
                                <label class=" control-label blue" for="form-field-1">حسب تاريخ تنفيذ الملاحظة  </label>


                                <div class="input-group">
                                    <span class="input-group-addon">
                                        <i class="fa fa-calendar bigger-110"></i>
                                    </span>

                                    <input type="text" id="DateFromSearch"  autocomplete="off" class="form-control form-control-1 input-sm fromSearch" runat="server" placeholder="سنة - شهر" />


                                </div>
                            </div>
                        </div>
                </div>

            </div>
            <div class="row">
                <div class="col-xs-12 col-sm-5">

                    <div class="form-group">
                        <label class=" control-label blue" for="form-field-1">مستوى الأهمية  </label>


                        <asp:RadioButtonList ID="Importance" AutoPostBack="true" runat="server" OnSelectedIndexChanged="Importance_SelectedIndexChanged" RepeatDirection="Horizontal" CssClass="radioboxlist" CellPadding="20" CellSpacing="20" Font-Bold="True" ForeColor="White">
                             <asp:ListItem  Value="3"><img width="90" src="assets/images/Icons/levels/L1/high.png" /></asp:ListItem>
                                        <asp:ListItem  Value="2"><img width="90" src="assets/images/Icons/levels/L1/mid.png" /></asp:ListItem>
                                        <asp:ListItem  Selected="True" Value="1"><img width="90"  src="assets/images/Icons/levels/L1/low.png" /></asp:ListItem>


                            
                        </asp:RadioButtonList>

                    </div>
                </div>

                <div class="col-xs-12 col-sm-7">

                    <div class="form-group">
                        <label class=" control-label blue" for="form-field-1">بحث بحالة التنفيذ للملاحظة  </label>

                        <div class="col-sm-12">

                            <asp:RadioButtonList ID="RadioStatus" AutoPostBack="true" runat="server" OnSelectedIndexChanged="RadioStatus_SelectedIndexChanged" RepeatDirection="Horizontal" CssClass="radioboxlist" CellPadding="20" CellSpacing="20" Font-Bold="True" ForeColor="White">
                                <asp:ListItem  Value='3'><img width="90"  src="assets/icons/levels/L2/solved3.png"  /></asp:ListItem>
                                    <asp:ListItem  Value='2'><img width="110" src="assets/icons/levels/L2/under3.png" /></asp:ListItem>
                                    <asp:ListItem Selected="True"  Value='1'><img width="90"  src="assets/icons/levels/L2/hold3.png" /></asp:ListItem>
                                    <asp:ListItem  Value="5"><img width="90" src="assets/icons/levels/L2/closed3.png" /></asp:ListItem>
                                    <asp:ListItem  Value="4"><img width="145" src="assets/icons/levels/L2/notstart3.png" /></asp:ListItem>
                               
                            </asp:RadioButtonList>

                        </div>
                    </div>
                </div>
            </div>

            <div class="row">
                 <div class="col-xs-4">

                    <h4 class="pink" style="float: right;">
                        <i class="ace-icon fa fa-file-archive-o green"></i>
                        <a href="#AdminFiles_modal" role="button" class="blue" id="aa" data-toggle="modal">ملفات الإدارة متوسطة </a>
                    </h4>

                </div>

                <div class="col-xs-4">
                    <div id="Suc" runat="server" visible="false" class="alert alert-block alert-success">
                        <strong>
                            <i class="ace-icon fa fa-check-square-o icon-only bigger-150"></i>
                            تم الحفظ !
                        </strong>

                    </div>
                </div>

                



            </div>



            <!-- div.table-responsive -->

            <!-- div.dataTables_borderWrap -->
            <div>

                <table id="dynamic-table" class=" table-striped table-bordered">


                     <thead class="TableHead">
                        <tr>

                             <th class="center">حالة التكرار
                                        <hr />
                                تاريخ إصدار التقرير  
                            </th>

                             <th class="center">حالة الملاحظة  

                               

                            </th>

                             <th class="center">
                                تاريخ التنفيذ 
                            </th>



                             <th class="center">مستوى الأهمية  
                            
                            </th>


                             <th class="center">  
                                
                                عرض الملاحظة
                            </th>

                             <th class="center">رقم الملاحظة 

                                
                            </th>

                             <th class="center">التوصيات

                                       

                            </th>

                        </tr>
                    </thead>

                    <tbody>
                        <asp:Repeater ID="EmployeesData" OnItemDataBound="EmployeesData_ItemDataBound" runat="server">
                            <ItemTemplate>

                                <tr>
                                    <td class="center">
                                        <asp:Label ID="LblRepeat" Visible="false" runat="server" Text='<%# Eval("RepRepeat") %>'></asp:Label>

                                        <div runat="server" visible="false" id="TRU"><i class="ace-icon blue fa fa-check-circle-o bigger-130"></i></div>

                                        <div runat="server" visible="false" id="FALS"><i class="ace-icon blue fa fa-minus-circle bigger-130"></i></div>

                                        <hr class="center" style="margin-top: 1px; margin-bottom: 1px; border-top: 1px solid #6ad589;" />
                                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("RepDate") %>'></asp:Label>

                                    </td>
                                    <td class="center">
                                        <div runat="server" id="TD2">

                                            <asp:Label ID="LblStat" runat="server" Style="color: #FFFFFF; padding: 7px;" Text='<%# Eval("RepStatus") %>'></asp:Label>

                                        </div>
                                    </td>

                                    <td class="center">
                                         <asp:Label ID="Label8" runat="server" Text='<%# Eval("RepFrom") %>'></asp:Label>

                                    </td>
                                    <td class="center">
                                         <div runat="server" id="TD1">
                                            <asp:Label ID="LblImportant" Style="color: #FFFFFF" runat="server" Text='<%# Eval("Importance") %>'></asp:Label>

                                        </div>
                                    </td>


                                    <td class="center">
                                       
                                       

                                        <asp:UpdateProgress ID="UpNot"
                                            AssociatedUpdatePanelID="UpanelNote"
                                            runat="server">
                                            <ProgressTemplate>
                                                <i class="ace-icon fa fa-spinner fa-spin green bigger-125"></i>جارى التحميل...            
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                        <asp:UpdatePanel ID="UpanelNote" runat="server">
                                            <ContentTemplate>
                                                <i class="ace-icon glyphicon glyphicon-search green"></i>
                                                <asp:LinkButton title="عرض الملاحظة " ID="LinkButton3" Text='عرض الملاحظة' CommandArgument='<%# Eval("RepID") %>' OnCommand="LinkDetails_Command" runat="server"></asp:LinkButton>

                                            </ContentTemplate>
                                        </asp:UpdatePanel>

                                    </td>




                                    <td class="center">
                                     
                                                <i class="ace-icon glyphicon glyphicon-search green"></i>
                                                <asp:LinkButton title="عرض الملاحظة " ID="LinkDetails" Text='<%# Eval("RepCode") %>' CommandArgument='<%# Eval("RepID") %>' OnCommand="LinkDetails_Command" runat="server"></asp:LinkButton>

                                    </td>


                                    <td class="center">
                                        <asp:UpdateProgress ID="UpdateProg3"
                                            AssociatedUpdatePanelID="Update03"
                                            runat="server">
                                            <ProgressTemplate>
                                                <i class="ace-icon fa fa-spinner fa-spin green bigger-125"></i>جارى التحميل...            
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                        <asp:UpdatePanel ID="Update03" runat="server">
                                            <ContentTemplate>
                                                <asp:LinkButton CssClass="green" data-rel="tooltip" title="عرض التوصيات" ID="Edit" CommandArgument='<%# Eval("RepID") %>' OnCommand="Edit_Command" runat="server"><i class="ace-icon glyphicon glyphicon-search blue"></i> عرض التوصيات </asp:LinkButton>


                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>



                                </tr>

                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>

            <div id="Del_modal" data-backdrop="static" data-keyboard="false" class="modal fade" tabindex="-1">
                <div class="modal-dialog">
                    <div class="modal-content">

                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                            <h4 class="blue bigger">بيانات الملاحظة </h4>
                        </div>

                        <div class="modal-body" style="max-height: 400px; overflow-y: scroll;">
                            <div>

                                <div class="row">
                                    <div class="col-xs-12 col-sm-12">


                                        <div class="row">
                                            <div class="col-xs-12 col-sm-4">


                                                <div class="form-group">
                                                    <label class="col-sm-4 control-label" for="form-field-1">عدد التوصيات على الملاحظة </label>

                                                    <div class="col-sm-8">
                                                        <asp:Label ID="LblNoteCount" runat="server" Text=""></asp:Label>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-xs-12 col-sm-4">


                                                <div class="form-group">
                                                    <label class="col-sm-4 control-label" for="form-field-1">تاريخ الملاحظة  </label>

                                                    <div class="col-sm-8">
                                                        <asp:Label ID="LblRepDate" runat="server" Text=""></asp:Label>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-xs-12 col-sm-4">


                                                <div class="form-group">
                                                    <label class="col-sm-4 control-label" for="form-field-1">رقم الملاحظة  </label>

                                                    <div class="col-sm-8">
                                                        <asp:Label ID="LblNo" runat="server" Text=""></asp:Label>
                                                    </div>
                                                </div>
                                            </div>






                                        </div>



                                    </div>

                                </div>

                                <div class="row">
                                    <h4 style="margin-right: 7px;" class="blue">تفاصيل الملاحظة </h4>
                                    <div class="col-xs-12 col-sm-4">

                                        <div class="form-group">


                                            <label class="col-sm-4 control-label" for="form-field-1">موجه لإدارة عليا</label>
                                            <div class="col-sm-8">
                                                <asp:Label ID="LblForSec" runat="server" Text=""></asp:Label>
                                            </div>

                                        </div>
                                    </div>

                                    <div class="col-xs-12 col-sm-4">

                                        <div class="form-group">


                                            <label class="col-sm-4 control-label" for="form-field-1">موجه لإدارة متوسطة</label>
                                            <div class="col-sm-8">
                                                <asp:Label ID="LblForAdm" runat="server" Text=""></asp:Label>
                                            </div>

                                        </div>
                                    </div>

                                    <div class="col-xs-12 col-sm-4">

                                        <div class="form-group">


                                            <label class="col-sm-4 control-label" for="form-field-1">مستوى الأهمية </label>
                                            <div class="col-sm-8">
                                                <asp:Label ID="LblImport" runat="server" Text=""></asp:Label>
                                            </div>

                                        </div>
                                    </div>

                                </div>
                                <div class="row">
                                    <div class="col-xs-12 col-sm-4">

                                        <div class="form-group">

                                            <label class="col-sm-4 control-label" for="form-field-1">التاريخ المحدد للتنفيذ</label>
                                            <div class="col-sm-8">
                                                <asp:Label ID="LblDateFrom" runat="server" Text=""></asp:Label>
                                                من
                                            </div>

                                        </div>
                                    </div>
                                    
                                    <div class="col-xs-12 col-sm-4">

                                        <div class="form-group">

                                            <label class="col-sm-4 control-label" for="form-field-1">حالة التكرار </label>
                                            <div class="col-sm-8">

                                                <div class="form-group">
                                                    <span id="RPTSign" runat="server" />
                                                </div>
                                            </div>

                                        </div>
                                    </div>

                                </div>
                                <div class="row">

                                    <div class="col-xs-12 col-sm-4">

                                        <div class="form-group">

                                            <label class="col-sm-4 control-label" for="form-field-1">حالة التنفيذ </label>
                                            <div class="col-sm-8">
                                                <asp:Label ID="LblStatus" runat="server" Text=""></asp:Label>

                                            </div>

                                        </div>
                                    </div>
                                    <div class="col-xs-12 col-sm-8">



                                        <label class="col-sm-4 control-label" for="form-field-1">الملفات المرفقة </label>
                                        <div class="col-sm-8">
                                            <asp:Repeater ID="FileList" runat="server">

                                                <ItemTemplate>
                                                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("FPath") %>' Text='<%# Eval("FName") %>'></asp:HyperLink>

                                                </ItemTemplate>
                                            </asp:Repeater>


                                        </div>
                                    </div>
                                </div>
                                <div class="row">

                                    <div class="col-xs-12 col-sm-12">
                                        <div class="hr hr8 hr-double hr-dotted"></div>
                                        <div class="well" style="max-height: 100px; overflow-y: scroll">
                                            <div id="Test" runat="server" />
                                        </div>
                                    </div>

                                </div>


                                





                            </div>


                        </div>

                    </div>
                </div>
            </div>

            <asp:Label ID="LblNote" Style="display: none;" runat="server" Text=""></asp:Label>


            <asp:Label ID="EditConfirm" Style="display: none;" runat="server" Text=""></asp:Label>

            <asp:Label ID="ConfirmId" Style="display: none;" runat="server" Text=""></asp:Label>
            <asp:Label ID="RepNew" Style="display: none;" runat="server" Text=""></asp:Label>
            <asp:Label ID="NoteNew" Style="display: none;" runat="server" Text=""></asp:Label>
            <asp:Label ID="LblRep" Style="display: none;" runat="server" Text=""></asp:Label>
            <asp:Label ID="RepId" Style="display: none;" runat="server" Text=""></asp:Label>
            <asp:Label ID="NoteId" Style="display: none;" runat="server" Text=""></asp:Label>
            <asp:Label ID="LblEdit" Style="display: none;" runat="server" Text=""></asp:Label>
            <asp:Label ID="LblEditID" Style="display: none;" runat="server" Text=""></asp:Label>
            <asp:Label ID="ShowFiles" Style="display: none;" runat="server" Text=""></asp:Label>


            <div id="modal-formU" data-backdrop="static" data-keyboard="false" class="modal fade" tabindex="-1" style="margin-top: -15px;">
                <div class="modal-dialog" style="right: 2% !important; width: 95%">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                            <h4 class="blue bigger">التوصيات</h4>
                        </div>

                        <div class="modal-body">
                            <div class="row">
                                <div class="col-xs-3">
                                    <div id="SucNote" runat="server" visible="false" class="alert alert-block alert-success">
                                        <strong>
                                            <i class="ace-icon fa fa-check-square-o icon-only bigger-150"></i>
                                            تم الحفظ !
                                        </strong>

                                    </div>
                                </div>

                                <div class="col-xs-3">
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                            <div class="pull-right tableTools-container pull-left DNotes"></div>

                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>



                            </div>



                            <!-- div.table-responsive -->

                            <!-- div.dataTables_borderWrap -->
                            <div style="max-height: 400px; overflow-y: scroll;">
                                <table id="dynamic-Notes" class=" table-striped table-bordered">


                                     <thead class="TableHead">
                                        <tr>

                                             <th class="center">حالة التكرار
                                        <hr />
                                                تاريخ اصدار التوصية 
                                            </th>

                                             <th class="center">حالة التوصية 
                                                                               
                                            </th>

                                             <th class="center">تاريخ التنفيذ المتفق عليه
                                        
                                        <hr />

                                            </th>



                                             <th class="center">الرد 
                                                  
                                            </th>


                                             <th class="center">أهمية التوصية 
                                            </th>

                                             <th class="center">
                                                رقم التوصية
                                            </th>


                                        </tr>
                                    </thead>

                                    <tbody>
                                        <asp:Repeater ID="RepNotes" OnItemDataBound="RepNotes_ItemDataBound" runat="server">
                                            <ItemTemplate>

                                                <tr>
                                                    <td class="center">
                                                        <asp:Label ID="LblRepeat" Visible="false" runat="server" Text='<%# Eval("NoteRepeat") %>'></asp:Label>

                                                        <div runat="server" visible="false" id="TRU"><i class="ace-icon blue fa fa-check-circle-o bigger-130"></i></div>

                                                        <div runat="server" visible="false" id="FALS"><i class="ace-icon blue fa fa-minus-circle bigger-130"></i></div>

                                                        <hr class="center" style="margin-top: 1px; margin-bottom: 1px; border-top: 1px solid #6ad589;" />
                                                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("NoteDate") %>'></asp:Label>

                                                    </td>
                                                    <td class="center">
                                                        <div runat="server" id="TDNote2">

                                                            <asp:Label ID="LblNoteStat" runat="server" Style="color: #FFFFFF; padding: 7px;" Text='<%# Eval("NoteStatus") %>'></asp:Label>
                                                        </div>
                                                    </td>

                                                    <td class="center">
                                                        <asp:Label ID="Label7" runat="server" Text='<%# Eval("NoteFrom") %>'></asp:Label>

                                                    </td>
                                                    <td class="center">
                                                        <asp:UpdateProgress ID="UPD2"
                                                            AssociatedUpdatePanelID="UpN22"
                                                            runat="server">
                                                            <ProgressTemplate>
                                                                <i class="ace-icon fa fa-spinner fa-spin green bigger-125"></i>جارى التحميل...            
                                                            </ProgressTemplate>
                                                        </asp:UpdateProgress>
                                                        <asp:UpdatePanel ID="UpN22" runat="server">
                                                            <ContentTemplate>
                                                                <i class="ace-icon fa fa-pencil-square-o"></i>
                                                                <asp:LinkButton title="ارسال رد" ID="LinkNoteFiles" Text="ارسال رد" CommandArgument='<%#Eval("NoteID") + ";" +Eval("RepID")%>' OnCommand="LinkNoteFiles_Command" runat="server"></asp:LinkButton>
                                                                <hr class="center" style="margin-top: 1px; margin-bottom: 1px; border-top: 1px solid #6ad589;" />
                                                                <asp:LinkButton title="عرض الردود" ID="LinkNotes" Text="عرض الردود" CommandArgument='<%# Eval("NoteID") %>' OnCommand="LinkNotes_Command" runat="server"></asp:LinkButton>

                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                        <div runat="server" id="NoNotereply" visible="false">لايوجد رد</div>
                                                        <asp:Label ID="NotID" Style="display: none" runat="server" Text='<%# Eval("NoteID") %>'></asp:Label>

                                                        <asp:Label ID="ComNoteCount" Style="display: none" runat="server" Text='<%# Eval("ComCount") %>'></asp:Label>

                                                    </td>


                                                    <td class="center">
                                                        <div runat="server" id="TDNote1">
                                                            <asp:Label ID="LblNoteImportant" Style="color: #FFFFFF" runat="server" Text='<%# Eval("Importance") %>'></asp:Label>

                                                        </div>

                                                    </td>

                                                    <td>
                                                        <asp:Label ID="Label1" class="center" runat="server" Text='<%# Eval("RepID") %>'></asp:Label>
                                                        <hr class="center" style="margin-top: 1px; margin-bottom: 1px; border-top: 1px solid #6ad589;" />

                                                        
                                                                <a class="blue center" role='button' data-rel="tooltip" title="عرض التوصية" href='#Details' data-toggle='modal'>
                                                                    <i class="ace-icon glyphicon glyphicon-search blue"></i><span>
                                                                        <asp:Label ID="Label19" runat="server" Text='<%#Container.ItemIndex+1 %>'></asp:Label></span>
                                                                </a>

                                                            
                                                        <div id="Details" data-backdrop="static" data-keyboard="false" aria-hidden="false" class="modal fade" tabindex="-1">
                                                            <div class="modal-dialog">
                                                                <div class="modal-content ">

                                                                    <div class="modal-header">
                                                                        <button type="button" class="close" data-dismiss-modal="modal" onclick="GetNotes();">&times;</button>
                                                                        <h4 class="blue bigger">بيانات التوصية</h4>
                                                                    </div>

                                                                    <div class="modal-body">


                                                                        <div class="row">


                                                                            <div class="col-xs-12 col-sm-6">


                                                                                <label class="col-sm-6 control-label" for="form-field-1">تاريخ التوصية </label>

                                                                                <div class="col-sm-6">
                                                                                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("NoteDate") %>'></asp:Label>
                                                                                </div>

                                                                            </div>
                                                                            <div class="col-xs-12 col-sm-6">


                                                                                <label class="col-sm-6 control-label" for="form-field-1">تكرار التوصية </label>

                                                                                <div class="col-sm-6">
                                                                                    <asp:Label ID="LBLRPTCk" runat="server"></asp:Label>
                                                                                </div>

                                                                            </div>
                                                                        </div>
                                                                        <div class="row">

                                                                            <div class="col-xs-12 col-sm-6">


                                                                                <label class="col-sm-6 control-label" for="form-field-1">رقم التوصية </label>

                                                                                <div class="col-sm-6">
                                                                                    <asp:Label ID="Label9" runat="server" Text='<%#Container.ItemIndex+1 %>'></asp:Label>
                                                                                </div>
                                                                            </div>



                                                                            <div class="col-xs-12 col-sm-6">


                                                                                <label class="col-sm-4 control-label" for="form-field-1">التاريخ المحدد للتنفيذ</label>
                                                                                <div class="col-sm-8">
                                                                                    <asp:Label ID="Label16" runat="server" Text='<%# Eval("NoteFrom") %>'></asp:Label>
                                                                                    
                                                                                </div>


                                                                            </div>



                                                                        </div>
                                                                        <div class="row">
                                                                            <div class="col-xs-12 col-sm-8">



                                                                                <label class="col-sm-4 control-label" for="form-field-1">الملفات المرفقة </label>
                                                                                <div class="col-sm-8">
                                                                                    <asp:Repeater ID="FileListNotes" runat="server">

                                                                                        <ItemTemplate>
                                                                                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("FPath") %>' Text='<%# Eval("FName") %>'></asp:HyperLink>

                                                                                        </ItemTemplate>
                                                                                    </asp:Repeater>


                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                        <div class="row">

                                                                            <div class="col-xs-12 col-sm-12">
                                                                                <div class="hr hr8 hr-double hr-dotted"></div>
                                                                                <asp:Label ID="LitDetail" runat="server" Visible="false" Text='<%# Eval("NoteText") %>'></asp:Label>

                                                                                <div id="well" runat="server" class="well" style="max-height: 100px; overflow-y: scroll">
                                                                                </div>
                                                                            </div>

                                                                        </div>
                                                                        <div class="row">

                                                                            <div class="col-xs-12 col-sm-12">الاجراء التصحيحي من قبل الإدارة متوسطة 
                                                                                <div class="hr hr8 hr-double hr-dotted"></div>
                                                                                <asp:Label ID="LbCorrect" runat="server" Visible="false" Text='<%# Eval("AdminCorrect") %>'></asp:Label>

                                                                                <div id="Div2" runat="server" class="well" style="max-height: 100px; overflow-y: scroll">
                                                                                </div> <div id="Div1" runat="server" class="well" style="max-height: 100px; overflow-y: scroll">
                                                                                </div>
                                                                            </div>

                                                                        </div>





                                                                    </div>
                                                                    <div class="modal-footer">
                                                                        &nbsp;
                                                                    </div>
                                                                </div>
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
                        <div class="modal-footer" style="min-height: 30px">&nbsp;</div>

                    </div>
                </div>
            </div>


            <div id="modal-Replys" data-backdrop="static" data-keyboard="false" class="modal fade" tabindex="-1" style="margin-top: -15px;">
                <div class="modal-dialog" style="right: 2% !important; width: 95%">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                            <h4 class="blue bigger">الردود</h4>
                        </div>

                        <div class="modal-body" style="max-height: 400px; overflow-y: scroll;">

                            <div id="SucReply" runat="server" visible="false" class="alert alert-block alert-success">
                                <strong>
                                    <i class="ace-icon fa fa-check-square-o icon-only bigger-150"></i>
                                    تم الحفظ !
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

                                             <th class="center"></th>
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
                                                        <div style="max-height: 100px; min-width: 250px; overflow-y: scroll;">
                                                            <asp:Literal ID="LitText" runat="server" Text='<%# Eval("ConfirmText") %>'></asp:Literal>
                                                        </div>
                                                    </td>

                                                    <td class="center">
                                                        <asp:LinkButton CssClass="green" data-rel="tooltip" title="تعديل" ID="EditReply" CommandArgument='<%#Eval("ConfirmID") + ";" +Eval("ReportID")%>' OnCommand="EditReply_Command" runat="server"><i class="ace-icon fa fa-pencil icon-only bigger-120"></i></asp:LinkButton>
                                                        <!--Open Dlete Employee PUP-->
                                                        <a class="red" role='button' data-rel="tooltip" title="حذف" href='#DelReply_modal' data-toggle='modal' data-book-id='<%# Eval("ConfirmID") %>'>
                                                            <i class="ace-icon fa fa-close icon-only bigger-120"></i><span class='hidden'>حذف</span>
                                                        </a></td>







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

                        <div class="modal-body" style="max-height: 400px; overflow-y: scroll;">

                            <div id="SucReplyNote" runat="server" visible="false" class="alert alert-block alert-success">
                                <strong>
                                    <i class="ace-icon fa fa-check-square-o icon-only bigger-150"></i>
                                    تم الحفظ !
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

                                             <th class="center"></th>
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
                                                        <div style="max-height: 100px; min-width: 250px; overflow-y: scroll;">
                                                            <asp:Literal ID="LitNoteText" runat="server" Text='<%# Eval("ConfirmText") %>'></asp:Literal>
                                                        </div>
                                                    </td>

                                                    <td class="center">
                                                        <asp:LinkButton CssClass="green" data-rel="tooltip" title="تعديل" ID="EditNoteReply" CommandArgument='<%#Eval("ConfirmID") + ";" +Eval("NoteID")%>' OnCommand="EditNoteReply_Command" runat="server"><i class="ace-icon fa fa-pencil icon-only bigger-120"></i></asp:LinkButton>
                                                        <!--Open Dlete Employee PUP-->
                                                        <a class="red" role='button' data-rel="tooltip" title="حذف" href='#DelReply_modal' data-toggle='modal' data-book-id='<%# Eval("ConfirmID") %>'>
                                                            <i class="ace-icon fa fa-close icon-only bigger-120"></i><span class='hidden'>حذف</span>
                                                        </a></td>







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

            <!-- Delete File PUP-->
            <div id="DelFile_modal" data-backdrop="static" data-keyboard="false" style="z-index: 1000000" aria-hidden="false" class="modal fade" tabindex="-1">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="widget-header">
                            <button type="button" class="close red" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                            <h4 class="modal-title">تأكيد الحذف</h4>
                        </div>
                        <div class="modal-body">


                            <p>هل متأكد من حذف هذا الملف؟</p>
                            <input style="display: none" type="text" runat="server" name="FileId" id="FileId" value="" />
                        </div>
                        <div class="modal-footer">
                            <asp:LinkButton CssClass="btn btn-danger" runat="server" ID="DelFile" Text="حذف" OnClick="DelFile_Click" />
                            <a href="#"  data-dismiss="modal"></a>
                        </div>
                    </div>
                </div>
            </div>

            <div id="DelReply_modal" data-backdrop="static" data-keyboard="false" aria-hidden="false" class="modal fade" tabindex="-1">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="widget-header">
                            <button type="button" class="close red" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                            <h4 class="modal-title">تأكيد الحذف</h4>
                        </div>
                        <div class="modal-body">
                            <p>هل متأكد من حذف هذا الرد ؟</p>
                            <input style="display: none" type="text" runat="server" name="bookId" id="Replyy" value="" />
                        </div>
                        <div class="modal-footer">
                            <asp:LinkButton CssClass="btn btn-danger" runat="server" ID="DelReply" Text="حذف" OnClick="DelReply_Click" />
                            <a href="#"  data-dismiss="modal"></a>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>


    <div id="RepFiles_modal" data-backdrop="static" data-keyboard="false" style="z-index: 10000" class="modal fade" tabindex="-1">
        <div class="modal-dialog">
            <div class="modal-content">

                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="blue bigger">الرد والملفات المرفقة</h4>
                </div>

                <div class="modal-body">
                    <div class="row">
                        <div class="col-xs-12 col-sm-12">
                            <label class="Sub control-label">نص الرد </label>
                            <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                                <ContentTemplate>

                                    <div style="font-size:14px; font-family:Arial;max-height: 90px;" class="wysiwyg-editor"  runat="server" id="editor1"></div>
                                </ContentTemplate>
                            </asp:UpdatePanel>

                        </div>
                    </div>
                    <div class="row">

                        <div class="col-xs-12">
                            <label class="control-label" for="form-field-1">اضافة ملفات  </label>


                            <div id="ValidatFileR" class="red"></div>


                            <div class="col-sm-6">
                                <div class="form-group">
                                    <asp:FileUpload ID="FileUploadR" runat="server" CssClass="fileR" />

                                </div>
                                <asp:Label ID="LblEroorNote" Visible="false" runat="server" Text="مسجل ملف بنفس الاسم" ForeColor="#ff3c3c"></asp:Label>

                                <asp:Label ID="LblEroor" Visible="false" runat="server" Text="مسجل ملف بنفس الاسم " ForeColor="#ff3c3c"></asp:Label>

                                <asp:LinkButton ID="AddFile" CssClass="btn btn-sm btn-primary" OnClick="AddFile_Click" ValidationGroup="GFile" runat="server"> <i class="ace-icon fa fa-check-square-o icon-only bigger-150"></i>
                      أضف الملف </asp:LinkButton>
                            </div>

                            <div class="col-sm-6">
                                <div id="SucFile" runat="server" visible="false" class="alert alert-block alert-success">
                                    <strong>
                                        <i class="ace-icon fa fa-check-square-o icon-only bigger-150"></i>
                                        تم الحفظ !
                                    </strong>

                                </div>
                            </div>

                        </div>
                    </div>

                    <div class="row" style="max-height: 150px; margin-top: 10px; overflow-y: scroll;">
                        <div class="col-xs-12">


                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>

                                    <table class=" table-striped table-bordered">

                                         <thead class="TableHead">
                                            <tr>

                                                 <th class="center">الملف
                                                </th>
                                                 <th class="center"></th>
                                        </thead>
                                        <tbody>
                                            <asp:Repeater ID="RpeaterFiles" runat="server">

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
                    <div class="row">
                        <div class="modal-footer">
                            <asp:UpdateProgress ID="Upg002"
                                AssociatedUpdatePanelID="Upne022"
                                runat="server">
                                <ProgressTemplate>
                                    <i class="ace-icon fa fa-spinner fa-spin green bigger-125"></i>جارى التحميل...            
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                            <asp:UpdatePanel ID="Upne022" runat="server">
                                <ContentTemplate>

                                    <asp:Label ID="Rett" runat="server" Text="" CssClass="Rett" ForeColor="#ff3c3c"></asp:Label>
                                    <asp:LinkButton ID="Save" CssClass="btn btn-sm btn-primary" OnClick="Save_Click" ValidationGroup="G" runat="server"> <i class="ace-icon fa fa-check-square-o icon-only bigger-150"></i>
                      أرسل الرد </asp:LinkButton>
                                </ContentTemplate>
                            </asp:UpdatePanel>

                        </div>

                    </div>



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

                    <div class="row">

                        <div class="col-xs-12">
                            <label class="control-label" for="form-field-1">اضافة ملفات  </label>


                            <div id="ValidatFileAll" class="red"></div>


                            <div class="col-sm-6">
                                <div class="form-group">
                                    <asp:FileUpload ID="fileAll" runat="server" CssClass="fileAll" />

                                </div>
                                <asp:Label ID="AttachRep" Visible="false" runat="server" Text="مسجل ملف بنفس الاسم" ForeColor="#ff3c3c"></asp:Label>

                                <asp:Label ID="AttachNote" Visible="false" runat="server" Text="مسجل ملف بنفس الاسم " ForeColor="#ff3c3c"></asp:Label>

                                <asp:LinkButton ID="AddAttach" CssClass="btn btn-sm btn-primary" OnClick="AddAttach_Click" runat="server"> <i class="ace-icon fa fa-check-square-o icon-only bigger-150"></i>
                      أضف الملف </asp:LinkButton>
                            </div>

                            <div class="col-sm-6">
                                <div id="SucAttach" runat="server" visible="false" class="alert alert-block alert-success">
                                    <strong>
                                        <i class="ace-icon fa fa-check-square-o icon-only bigger-150"></i>
                                        تم الحفظ !
                                    </strong>

                                </div>
                            </div>

                        </div>
                    </div>

                    <div class="row" style="max-height: 150px; margin-top: 10px; overflow-y: scroll;">
                        <div class="col-xs-12">


                            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                <ContentTemplate>

                                    <table class=" table-striped table-bordered">

                                         <thead class="TableHead">
                                            <tr>

                                                 <th class="center">الملف
                                                </th>
                                                 <th class="center"></th>
                                        </thead>
                                        <tbody>
                                            <asp:Repeater ID="RepAttach" runat="server">

                                                <ItemTemplate>

                                                    <tr>
                                                        <td class="center">

                                                            <asp:HyperLink ID="HyperLink3" NavigateUrl='<%# Eval("FPath") %>' Text='<%# Eval("FName") %>' runat="server"></asp:HyperLink>

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
     <div id="AdminFiles_modal" data-backdrop="static" data-keyboard="false" class="modal fade" tabindex="-1">
                <div class="modal-dialog">
                    <div class="modal-content">

                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                            <h4 class="blue bigger">ملفات الإدارة متوسطة </h4>
                        </div>

                        <div class="modal-body" style="max-height: 400px; overflow-y: scroll;">

                            <asp:Label ID="LblNoData" runat="server" ForeColor="Blue" Visible="false" Text="لايوجد ملفات"></asp:Label>


                            <div class="row" style="max-height: 300px; margin-top: 10px; overflow-y: scroll;">
                                <div class="col-xs-12">
                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                        <ContentTemplate>

                                            <table class=" table-striped table-bordered">

                                                 <thead class="TableHead">
                                                    <tr>

                                                         <th class="center">الملف
                                                        </th>
                                                        
                                                </thead>
                                                <tbody>
                                                    <asp:Repeater ID="RepFileAdmins" runat="server">

                                                        <ItemTemplate>

                                                            <tr>
                                                                <td class="center">

                                                                    <asp:HyperLink ID="HyperLink2" NavigateUrl='<%# Eval("FPath") %>' Text='<%# Eval("FName") %>' runat="server"></asp:HyperLink>

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

                    </div>
                </div>
            </div>
   
    <asp:HiddenField ID="hf" runat="server" />


    <asp:HiddenField ID="HiddenPost" runat="server" />
     <asp:HiddenField ID="HiddenSearch" runat="server" />


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

        function CheckRepeate() {

            $("#<%=HiddenPost.ClientID %>").val("1");
            __doPostBack();
        }
        /* Put your code to run before UpdatePanel begins async postback here */
        function beforeAsyncPostBack() {
            var escape = document.createElement('textarea');
            escape.textContent = document.getElementById("<%=editor1.ClientID%>").innerHTML;
            $("#<%=hf.ClientID %>").val(escape.innerHTML);



        }

        /* Put your code to run after UpdatePanel finishes async postback here */
        function afterAsyncPostBack() {

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


        function GetReplys() {

            $('#modal-Replys').modal({ show: true, backdrop: false });
            $('#modal-formU').modal('hide');
            $('#modal-formU').modal('hide');
            var myTable = $('#dynamic-Replys')
                 //.wrap("<div class='dataTables_borderWrap' />")   //if you are applying horizontal scrolling (sScrollX)
                 .DataTable({
                     "lengthMenu": [[4, -1], [4, "All"]],
                     "fnStateSave": function (oSettings, oData) {
                         localStorage.setItem('offersDataTables', JSON.stringify(oData));
                     },
                     "fnStateLoad": function (oSettings) {
                         return JSON.parse(localStorage.getItem('offersDataTables'));
                     },
                     bAutoWidth: false,
                     "aoColumns": [
                        null, null, null,
                       { "bSortable": false }
                     ],
                     "aaSorting": []

                     , "language": {
                         "info": "",
                         "search": "ابحث بأى بيان :",
                         "zeroRecords": "لاتوجد بيانات متوافقة مع البحث",
                         "emptyTable": "لاتوجد ردود مسجلة",
                         "paginate": {
                             "previous": "<img src='assets/icons/buttons/pre.png' style='height:32px;'>",
                             "next": "<img src='assets/icons/buttons/next.png' style='height:32px;'>"

                         }
                     }

                      , stateSave: true

  , "bDestroy": true

                 });





        }


        function GetNoteReplys() {
            $('#modal-formU').modal('hide');
            $('#modal-NoteReplys').modal({ show: true, backdrop: false });
            var myTable = $('#dynamic-NoteReplys')
                 //.wrap("<div class='dataTables_borderWrap' />")   //if you are applying horizontal scrolling (sScrollX)
                 .DataTable({
                     "lengthMenu": [[4, -1], [4, "All"]],
                     "fnStateSave": function (oSettings, oData) {
                         localStorage.setItem('offersDataTables', JSON.stringify(oData));
                     },
                     "fnStateLoad": function (oSettings) {
                         return JSON.parse(localStorage.getItem('offersDataTables'));
                     },
                     bAutoWidth: false,
                     "aoColumns": [
                        null, null, null,
                       { "bSortable": false }
                     ],
                     "aaSorting": []

                     , "language": {
                         "info": "",
                         "search": "ابحث بأى بيان :",
                         "zeroRecords": "لاتوجد بيانات متوافقة مع البحث",
                         "emptyTable": "لاتوجد ردود مسجلة",
                         "paginate": {
                             "previous": "<img src='assets/icons/buttons/pre.png' style='height:32px;'>",
                             "next": "<img src='assets/icons/buttons/next.png' style='height:32px;'>"

                         }
                     }

                      , stateSave: true

  , "bDestroy": true

                 });





        }

        function GetDetails() {

            $('#Del_modal').modal({ show: true, backdrop: false });
            $('#modal-formU').modal('hide');




        }



        function GetNotes() { $('#modal-formU').modal({ show: true, backdrop: false }); $('#Details').modal('hide'); $('#RepFiles_modal').modal('hide'); }

        function GetFiles() {
            $(".remove").click();

            $('#modal-formU').modal('hide');

            $('#AllFiles_modal').modal('hide');
            $('#Del_modal').modal('hide');
            $('#RepFiles_modal').modal({ show: true, backdrop: false });


        }
        function GetAttach() {
            $(".remove").click();

            $('#modal-formU').modal('hide');
            $('#AllFiles_modal').modal({ show: true, backdrop: false });


            $('#Del_modal').modal('hide');
            $('#RepFiles_modal').modal('hide');
            $('#modal-Replys').modal({ show: true, backdrop: false });
            var myTable = $('#dynamic-Replys')
                 //.wrap("<div class='dataTables_borderWrap' />")   //if you are applying horizontal scrolling (sScrollX)
                 .DataTable({
                     "lengthMenu": [[4, -1], [4, "All"]],
                     "fnStateSave": function (oSettings, oData) {
                         localStorage.setItem('offersDataTables', JSON.stringify(oData));
                     },
                     "fnStateLoad": function (oSettings) {
                         return JSON.parse(localStorage.getItem('offersDataTables'));
                     },
                     bAutoWidth: false,
                     "aoColumns": [
                        null, null, null,
                       { "bSortable": false }
                     ],
                     "aaSorting": []

                     , "language": {
                         "info": "",
                         "search": "ابحث بأى بيان :",
                         "zeroRecords": "لاتوجد بيانات متوافقة مع البحث",
                         "emptyTable": "لاتوجد ردود مسجلة",
                         "paginate": {
                             "previous": "<img src='assets/icons/buttons/pre.png' style='height:32px;'>",
                             "next": "<img src='assets/icons/buttons/next.png' style='height:32px;'>"

                         }
                     }

                      , stateSave: true

  , "bDestroy": true

                 });




        }
        function CloseFiles() { $('#RepFiles_modal').modal('hide'); }



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

                    $('#DelReply_modal').on('show.bs.modal', function (e) {

                        var bookId = $(e.relatedTarget).data('book-id');

                        // Set bookId label equal the File ID when Opening the Delete PUP to be using in server side
                        $(e.currentTarget).find($("#<%=Replyy.ClientID%>")).val(bookId);


                    });


                }
            });
        };



        function DisplayCurrentTime() {

            $('.fromSearch').datepicker({
                autoclose: true,
                minViewMode: 1,
                format: 'mm-yyyy'
            }).on('changeDate', function (ev) {
                $("#<%=HiddenSearch.ClientID %>").val("1");
                __doPostBack();
            });
            $('#modal-NoteReplys').on('hide.bs.modal', function (e) {

                GetNotes();

            });
            $('#DelFile_modal').on('show.bs.modal', function (e) {

                var bookId = $(e.relatedTarget).data('book-id');

                // Set bookId label equal the File ID when Opening the Delete PUP to be using in server side
                $(e.currentTarget).find($("#<%=FileId.ClientID%>")).val(bookId);


            });
            $("body").removeAttr("style");
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

               if ((document.getElementById("<%=RepId.ClientID%>").innerText == "A")) {
                GetFiles();
            }
            if ((document.getElementById("<%=NoteId.ClientID%>").innerText == "A")) {
                GetFiles();
            }

            if ((document.getElementById("<%=EditConfirm.ClientID%>").innerText == "A")) {
                $('#modal-Replys').modal({ show: true, backdrop: false });
                $('#modal-NoteReplys').modal('hide');

                var myTable = $('#dynamic-Replys')
                //.wrap("<div class='dataTables_borderWrap' />")   //if you are applying horizontal scrolling (sScrollX)
                .DataTable({
                    "lengthMenu": [[4, -1], [4, "All"]],
                    "fnStateSave": function (oSettings, oData) {
                        localStorage.setItem('offersDataTables', JSON.stringify(oData));
                    },
                    "fnStateLoad": function (oSettings) {
                        return JSON.parse(localStorage.getItem('offersDataTables'));
                    },
                    bAutoWidth: false,
                    "aoColumns": [
                       null, null,
                      { "bSortable": false }
                    ],
                    "aaSorting": []

                    , "language": {
                        "info": "",
                        "search": "ابحث بأى بيان :",
                        "zeroRecords": "لاتوجد بيانات متوافقة مع البحث",
                        "emptyTable": "لاتوجد ردود مسجلة",
                        "paginate": {
                            "previous": "<img src='assets/icons/buttons/pre.png' style='height:32px;'>",
                            "next": "<img src='assets/icons/buttons/next.png' style='height:32px;'>"

                        }
                    }

                     , stateSave: true

 , "bDestroy": true

                });


                GetFiles();

            }
            else if ((document.getElementById("<%=EditConfirm.ClientID%>").innerText == "B")) {
                $('#modal-NoteReplys').modal({ show: true, backdrop: false });
                $('#modal-Replys').modal('hide');

                var myTable = $('#dynamic-NoteReplys')
                 //.wrap("<div class='dataTables_borderWrap' />")   //if you are applying horizontal scrolling (sScrollX)
                 .DataTable({
                     "lengthMenu": [[4, -1], [4, "All"]],
                     "fnStateSave": function (oSettings, oData) {
                         localStorage.setItem('offersDataTables', JSON.stringify(oData));
                     },
                     "fnStateLoad": function (oSettings) {
                         return JSON.parse(localStorage.getItem('offersDataTables'));
                     },
                     bAutoWidth: false,
                     "aoColumns": [
                        null, null, null,
                       { "bSortable": false }
                     ],
                     "aaSorting": []

                     , "language": {
                         "info": "",
                         "search": "ابحث بأى بيان :",
                         "zeroRecords": "لاتوجد بيانات متوافقة مع البحث",
                         "emptyTable": "لاتوجد ردود مسجلة",
                         "paginate": {
                             "previous": "<img src='assets/icons/buttons/pre.png' style='height:32px;'>",
                             "next": "<img src='assets/icons/buttons/next.png' style='height:32px;'>"

                         }
                     }

                      , stateSave: true

  , "bDestroy": true

                 });




                GetFiles();
            }

            if ((document.getElementById("<%=ShowFiles.ClientID%>").innerText == "A")) {

                GetAttach();
            }


            if ((document.getElementById("<%=LblEdit.ClientID%>").innerText.length > 0)) {

                $('#modal-formU').modal({ show: true, backdrop: false });
                $('#RepFiles_modal').modal('hide');
                var myTable = $('#dynamic-Notes')
                //.wrap("<div class='dataTables_borderWrap' />")   //if you are applying horizontal scrolling (sScrollX)
                .DataTable({
                    "lengthMenu": [[4, -1], [4, "All"]],
                    "fnStateSave": function (oSettings, oData) {
                        localStorage.setItem('offersDataTables', JSON.stringify(oData));
                    },
                    "fnStateLoad": function (oSettings) {
                        return JSON.parse(localStorage.getItem('offersDataTables'));
                    },
                    bAutoWidth: false,
                    "aoColumns": [
                       null, null, null, null, null,
                      { "bSortable": false }
                    ],
                    "aaSorting": []

                    , "language": {
                        "info": "",
                        "search": "ابحث بأى بيان :",
                        "zeroRecords": "لاتوجد بيانات متوافقة مع البحث",
                        "emptyTable": "لاتوجد توصيات مسجلة",
                        "paginate": {
                            "previous": "<img src='assets/icons/buttons/pre.png' style='height:32px;'>",
                            "next": "<img src='assets/icons/buttons/next.png' style='height:32px;'>"

                        }
                    }

                     , stateSave: true

 , "bDestroy": true

                });



                $.fn.dataTable.Buttons.defaults.dom.container.className = 'dt-buttons btn-overlap btn-group btn-overlap';

                new $.fn.dataTable.Buttons(myTable, {
                    buttons: [
                      {
                          "extend": "colvis",
                          "text": "<i class='fa fa-search bigger-110 white'></i> <span class='hidden'>اظهار / اخفاء العواميد</span>",
                          "className": "btn btn-success btn-bold Brd",
                          columns: ':not(:first):not(:last)', exportOptions: {
                              columns: [5, 4, 3, 2, 1, 0]
                          }
                      },
                      {
                          "extend": "copy",
                          "text": "<i class='fa fa-copy bigger-110 white'></i> <span class='hidden'>انسخ جميع البيانات</span>",
                          "className": "btn btn-success btn-bold Brd", exportOptions: {
                              columns: [5, 4, 3, 2, 1, 0]
                          }
                      },

                      {
                          "extend": "excel",
                         "text": "<i class='fa fa-file-excel-o bigger-110 white'></i> <span class='hidden'>الحصول على ملف Excel</span>",

                          "className": "btn btn-success btn-bold Brd", exportOptions: {
                              columns: [5, 4, 3, 2, 1, 0]
                          }
                      },

                      {
                          "extend": "print",
                          "text": "<i class='fa fa-print bigger-110 white'></i> <span class='hidden'>اطبع</span>",
                          "className": "btn btn-success btn-bold Brd",
                          autoPrint: true,
                          customize: function (win) {
                              $(win.document.body)
                                  .css('direction', 'ltr')
                                  .prepend($('<img />')
                            .attr("src", window.location.origin + "/assets/images/logo-250x78.png")
                            .addClass('asset-print-img')
                            );
                              $(win.document.body).find('table')
                                  .addClass('compact')
                                  .css('font-size', 'inherit')
                              .css('th', 'text-align: center');
                          },
                          message: 'نظام الملاحظات بيانات قائمة الملاحظات  ',
                          exportOptions: {
                              columns: [5, 4, 3, 2, 1, 0]

                          }
                      }
                    ]
                });
                myTable.buttons().container().appendTo($('.DNotes'));


                setTimeout(function () {
                    $($('.DNotes')).find('a.dt-button').each(function () {
                        var div = $(this).find(' > div').first();
                        if (div.length == 1) div.tooltip({ container: 'body', title: div.parent().text() });
                        else $(this).tooltip({ container: 'body', title: $(this).text() });
                    });
                }, 500);



                $(document).on('click', '#dynamic-Notes .dropdown-toggle', function (e) {
                    e.stopImmediatePropagation();
                    e.stopPropagation();
                    e.preventDefault();
                });



            }



            ////////////////// Check File Added


            $("#<%=AddFile.ClientID %>").click(function (e) {
                var escape = document.createElement('textarea');
                escape.textContent = document.getElementById("<%=editor1.ClientID%>").innerHTML;

                $("#<%=hf.ClientID %>").val(escape.innerHTML);


                if ($('.fileR').val() == '') {
                    $("#ValidatFileR").text('اختر ملف ');
                    e.preventDefault();
                }
            });

            $("#<%=AddAttach.ClientID %>").click(function (e) {


                if ($('.fileAll').val() == '') {
                    $("#ValidatFileAll").text('اختر ملف ');
                    e.preventDefault();
                }
            });
            ////////////////////// Save new note
            $("#<%=Save.ClientID %>").click(function (e) {

                var escape = document.createElement('textarea');
                escape.textContent = document.getElementById("<%=editor1.ClientID%>").innerHTML;

                $("#<%=hf.ClientID %>").val(escape.innerHTML);



            });


            //////
            $('.fileR').change(function (event) {
                var tmppath = URL.createObjectURL(event.target.files[0]);
                $("#ValidatFileR").text(' ');

                var ext = $('.fileR').val().split('.').pop().toLowerCase();
                if ($.inArray(ext, ['gif', 'doc', 'docx', 'xls', 'xlsx', 'xlt', 'ppt', 'pot', 'pps', 'xps', 'dot', 'dotx', 'pdf', 'png', 'jpg', 'jpeg']) == -1) {
                    $("#ValidatFileR").text("يجب أن تختار ملف مناسب ");
                    $('.fileR').prop('value', '');
                }


            });

            $('.fileR').ace_file_input({
                no_file: 'No File ...',
                btn_choose: 'Choose',
                btn_change: 'Change',
                droppable: false,
                onchange: null,
                thumbnail: false, //| true | large
                whitelist: 'gif|doc|docx|xls|xlsx|xlt|ppt|pot|pps|xps|dot|dotx|pdf|png|jpg|jpeg'
              , blacklist: 'exe|php'
                //onchange:''
                //
            });


            //////
            $('.fileAll').change(function (event) {
                var tmppath = URL.createObjectURL(event.target.files[0]);
                $("#ValidatFileAll").text(' ');

                var ext = $('.fileAll').val().split('.').pop().toLowerCase();
                if ($.inArray(ext, ['gif', 'doc', 'docx', 'xls', 'xlsx', 'xlt', 'ppt', 'pot', 'pps', 'xps', 'dot', 'dotx', 'pdf', 'png', 'jpg', 'jpeg']) == -1) {
                    $("#ValidatFileAll").text("يجب أن تختار ملف مناسب ");
                    $('.fileAll').prop('value', '');
                }


            });

            $('.fileAll').ace_file_input({
                no_file: 'No File ...',
                btn_choose: 'Choose',
                btn_change: 'Change',
                droppable: false,
                onchange: null,
                thumbnail: false, //| true | large
                whitelist: 'gif|doc|docx|xls|xlsx|xlt|ppt|pot|pps|xps|dot|dotx|pdf|png|jpg|jpeg'
              , blacklist: 'exe|php'
                //onchange:''
                //
            });


            //////


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

            $('#RepFiles_modal').on('hide.bs.modal', function (e) {

                (document.getElementById("<%=RepId.ClientID%>")).innerText = "";
                 (document.getElementById("<%=NoteId.ClientID%>")).innerText = "";
                $('#modal-formU').modal({ show: true, backdrop: false });


             });

             ////  Bind FileID in the delete Modal




             FillTable();

             DisplayCurrentTime();

         });

         function FillTable() {
             var myTable =
            $('#dynamic-table')
            //.wrap("<div class='dataTables_borderWrap' />")   //if you are applying horizontal scrolling (sScrollX)
            .DataTable({
                "fnStateSave": function (oSettings, oData) {
                    localStorage.setItem('offersDataTables', JSON.stringify(oData));
                },
                "fnStateLoad": function (oSettings) {
                    return JSON.parse(localStorage.getItem('offersDataTables'));
                },
                bAutoWidth: false,
                "aoColumns": [
                   null, null, null, null, null, null,
                  { "bSortable": false }
                ],
                "aaSorting": []

                , "language": {
                    "info": "",
                    "search": "ابحث بأى بيان :",
                    "zeroRecords": "لاتوجد بيانات متوافقة مع البحث",
                    "emptyTable": "لاتوجد ملاحظات مسجلة",
                    "paginate": {
                        "previous": "<img src='assets/icons/buttons/pre.png' style='height:32px;'>",
                        "next": "<img src='assets/icons/buttons/next.png' style='height:32px;'>"

                    }
                }, stateSave: true

  , "bDestroy": true

            })


             $.fn.dataTable.Buttons.defaults.dom.container.className = 'dt-buttons btn-overlap btn-group btn-overlap';

             new $.fn.dataTable.Buttons(myTable, {
                 buttons: [
                   {
                       "extend": "colvis",
                       "text": "<i class='fa fa-search bigger-110 white'></i> <span class='hidden'>اظهار / اخفاء العواميد</span>",
                       "className": "btn btn-success btn-bold Brd",
                       columns: ':not(:first):not(:last)', exportOptions: {
                           columns: [5, 4, 3, 2, 1, 0]
                       }
                   },
                   {
                       "extend": "copy",
                       "text": "<i class='fa fa-copy bigger-110 white'></i> <span class='hidden'>انسخ جميع البيانات</span>",
                       "className": "btn btn-success btn-bold Brd", exportOptions: {
                           columns: [5, 4, 3, 2, 1, 0]
                       }
                   },

                   {
                       "extend": "excel",
                      "text": "<i class='fa fa-file-excel-o bigger-110 white'></i> <span class='hidden'>الحصول على ملف Excel</span>",

                       "className": "btn btn-success btn-bold Brd", exportOptions: {
                           columns: [5, 4, 3, 2, 1, 0]
                       }
                   },

                   {
                       "extend": "print",
                       "text": "<i class='fa fa-print bigger-110 white'></i> <span class='hidden'>اطبع</span>",
                       "className": "btn btn-success btn-bold Brd",
                       autoPrint: true,
                       customize: function (win) {
                           $(win.document.body)
                               .css('direction', 'ltr')
                               .prepend($('<img />')
                         .attr("src", window.location.origin + "/assets/images/logo-250x78.png")
                         .addClass('asset-print-img')
                         );
                           $(win.document.body).find('table')
                               .addClass('compact')
                               .css('font-size', 'inherit')
                           .css('th', 'text-align: center');
                       },
                       message: 'نظام الملاحظات بيانات قائمة الملاحظات  ',
                       exportOptions: {
                           columns: [5, 4, 3, 2, 1, 0]

                       }
                   }
                 ]
             });
             myTable.buttons().container().appendTo($('.DReport'));


             setTimeout(function () {
                 $($('.DReport')).find('a.dt-button').each(function () {
                     var div = $(this).find(' > div').first();
                     if (div.length == 1) div.tooltip({ container: 'body', title: div.parent().text() });
                     else $(this).tooltip({ container: 'body', title: $(this).text() });
                 });
             }, 500);



             $(document).on('click', '#dynamic-table .dropdown-toggle', function (e) {
                 e.stopImmediatePropagation();
                 e.stopPropagation();
                 e.preventDefault();
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
