﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="~/Managments.aspx.cs" Inherits="Managments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
     <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
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
    </style>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="PageTitle" runat="Server">
   الإدارات المتوسطة
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" runat="Server">

    <h3>
        إضافة ادارة</h3>
    <div class="MainBox">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="row" id="Main" runat="server">


                    <div class="row">
                        <div class="col-xs-12">
                            <div class="row">

                                <div class="form-group">
                                    <label class="col-sm-10 control-label " for="form-field-1">الإدارة العليا  </label>

                                    <div class="col-sm-12">


                                       <div>
                                            <asp:DropDownList class="chosen-select chosen-rtl form-control" ID="Admins" AutoPostBack="true" OnSelectedIndexChanged="Admins_SelectedIndexChanged" runat="server" data-placeholder="الإدارات عليا">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-xs-3">
                                    <h4 class="pink" style="float: right;" runat="server" id="NewReg" visible="false">
                                        <asp:LinkButton ID="LinkButton1" OnClick="ClickNew_Click" CssClass="btn btn-purple large white" runat="server"> <span></span>تسجيل إدارة متوسطة</asp:LinkButton>
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





                            </div>
                                                        
                            <!-- div.table-responsive -->

                            <!-- div.dataTables_borderWrap -->
                            <div  class="col-xs-12 col-sm-12">
                                <table id="dynamic-table" class=" table-striped table-bordered">
                                    <thead class="TableHead">
                                        <tr>


                                            <th class="center">الإدارة متوسطة 
                                            </th>
                                            <th class="center">المدير المسؤول</th>

                                            <th class="center"></th>
                                        </tr>
                                    </thead>

                                    <tbody>
                                        <asp:Repeater ID="EmployeesData" OnItemDataBound="EmployeesData_ItemDataBound" runat="server">
                                            <ItemTemplate>

                                                <tr>
                                                    <td class="center">

                                                        <asp:Label ID="Label1" runat="server" Text='<%#Eval("AdmName")%>'></asp:Label>

                                                    </td>
                                                    <td class="center">
                                                        <asp:LinkButton ID="AdminView"  CommandArgument='<%# Eval("AdmID") %>' OnCommand="AdminView_Command" runat="server" ><i class="ace-icon fa fa-user icon-only bigger-120"></i></asp:LinkButton>

                                                    </td>


                                                    <td class="center">


                                                        <asp:LinkButton CssClass="green" data-rel="tooltip" title="تعديل" ID="Edit" CommandArgument='<%# Eval("AdmID") %>' OnCommand="Edit_Command" runat="server"><i class="ace-icon fa fa-pencil icon-only bigger-120"></i></asp:LinkButton>
                                                         <span id="DelAllow" runat="server">
                                                            <a class="red" role='button' data-rel="tooltip" title="حذف" href='#Del_modal' data-toggle='modal' data-book-id='<%# string.Concat(Eval("AdmID"),"&",Eval("AdmName")) %>'>
                                                                <i class="ace-icon fa fa-close icon-only bigger-120"></i><span class='hidden'>حذف</span>
                                                            </a>
                                                        </span>

                                                        <span id="DisAllow" runat="server"><a class="grey show-option" href="#" title="لايمكن الحذف ">
                                                            <i class="ace-icon fa fa-close icon-only bigger-120"></i>
                                                        </a></span>



                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                   


                </div>

                <div id="Admns" class="row" runat="server" style="display: none;">


                    <div class="modal-header">
                        <h3 class="bigger">المدير </h3>
                    </div>

                    <div>
                        <div class="row">
                            <div id="SucE" runat="server" visible="false" class="alert alert-block alert-success">
                                <strong>
                                    <i class="ace-icon fa fa-check-square-o icon-only bigger-150"></i>
                                    تم الحفظ !
                                </strong>

                            </div>
                            <div id="SucD" runat="server" visible="false" class="alert alert-block alert-success">
                                <strong>
                                    <i class="ace-icon fa fa-check-square-o icon-only bigger-150"></i>
                                    تم الحذف بنجاح !
                                </strong>

                            </div>
                            <div class="col-xs-12 col-sm-12">


                                <div class="form-group">
                                    <label class="col-sm-2 control-label " for="form-field-1">اختر المدير</label>

                                    <div class="col-sm-6">

                                       <div>
                                            <asp:DropDownList class="chosen-select chosen-rtl form-control" ID="DropEmployeesU" runat="server" data-placeholder="اخر الموظف لتسجيله">
                                            </asp:DropDownList><span class="blue" style="font-size: 15px;">الموظفين الغير مسجلين كمديرين ادارة أخرى</span>
                                        </div>
                                    </div>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" InitialValue="" ControlToValidate="DropEmployeesU" runat="server" ValidationGroup="GMang" ForeColor="#ff3c3c" ErrorMessage="اختر المدير  *"></asp:RequiredFieldValidator>

                                    <asp:Label ID="LblAdmID" Visible="false" runat="server" Text=""></asp:Label>
                                </div>

                            </div>

                            <div class="modal-footer">
                                <asp:Label ID="RettE" runat="server" Text="" CssClass="Rett" ForeColor="#ff3c3c"></asp:Label>
                                <asp:Button ID="SaveManger" OnClick="SaveManger_Click1" ValidationGroup="GMang" Height="51" runat="server"  Text="تسجيل" />
                                


                            </div>
                        </div>
                        <div style="margin-bottom:20px;">
                                <table id="dynamic-tableMang" class=" table-striped table-bordered">
                                    <thead class="TableHead">
                                        <tr>


                                            <th class="center">المدير 
                                            </th>

                                            <th class="center">البريد الالكترونى 
                                            </th>

                                            <th class="center">حذف</th>
                                        </tr>
                                    </thead>

                                    <tbody>
                                        <asp:Repeater ID="RepManagers"  runat="server">
                                            <ItemTemplate>

                                                <tr>
                                                    <td class="center">

                                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("EmpName") %>'></asp:Label>

                                                    </td>

                                                    <td class="center">
                                                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("EmpEmail") %>'></asp:Label>
                                                    </td>

                                                    <td class="center">


                                                        <a class="red" role='button' data-rel="tooltip" title="حذف" href='#Del_modalMang' data-toggle='modal' data-book-id='<%#Eval("MangID") %>'>
                                                            <i class="ace-icon fa fa-close icon-only bigger-120"></i><span class='hidden'>حذف الصلاحية</span>
                                                        </a>



                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </tbody>
                                </table>
                            </div>
                    </div>
                    <asp:LinkButton ID="LinkButton3" runat="server" OnClick="BackTables_Click" Style="float: left; margin-top: -10px;"><i class="ace-icon fa fa-arrow-left icon-only purple bigger-250"></i></asp:LinkButton>
                </div>

                <div id="New" class="row" runat="server" style="display: none;">


                    <div class="modal-header">
                        <h4 class="blue bigger">تسجيل إدارة متوسطةه </h4>
                    </div>

                    <div style="background-color: #FFFFFF;">
                        <div class="form-horizontal" role="form">
                            <div style="min-height: 300px;">

                                <div class="form-horizontal" role="form">

                                    <div class="row">
                                        <div class="col-xs-12 col-sm-12">


                                            <div class="form-group" style="margin-top: 30px;">
                                                <label class="col-sm-2 control-label" for="form-field-1">الإسم </label>

                                                <div class="col-sm-6">
                                                    <input runat="server" type="text" id="EmpName" placeholder="اسم الإدارة متوسطة" class="form-control text col-xs-10 col-sm-10" />

                                                    <span>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="EmpName" runat="server" ValidationGroup="G" ForeColor="#ff3c3c" ErrorMessage="اسم الإدارة متوسطة مطلوب  *"></asp:RequiredFieldValidator></span>
                                                </div>



                                            </div>

                                        </div>



                                    </div>



                                </div>
                            </div>
                            <div class="modal-footer">
                                <asp:Label ID="Rett" runat="server" Text="" CssClass="Rett" ForeColor="#ff3c3c"></asp:Label>
                                <asp:Button ID="Save" OnClick="Save_Click" ValidationGroup="G" CssClass="btn btn-success white" runat="server" Text="تسجيل" />
                                

                            </div>
                        </div>
                    </div>
                    <div>
                        <asp:LinkButton ID="LinkButton2" runat="server" OnClick="BackTables_Click" Style="float: left; margin-top: -10px;"><i class="ace-icon fa fa-arrow-left icon-only purple bigger-250"></i></asp:LinkButton>
                    </div>
                </div>
                <!---------------------------------->
                <div class="row" id="Updat" style="display: none;" runat="server">



                    <div class="modal-header">
                        <h4 class="blue bigger">تعديل بيانات الإدارة متوسطة</h4>
                    </div>

                    <div style="background-color: #FFFFFF;">
                        <div class="form-horizontal" role="form">
                            <div style="min-height: 300px;">

                                <div class="row">
                                    <div class="col-xs-12 col-sm-12">


                                        <div class="form-group" style="margin-top: 30px;">
                                            <label class="col-sm-2 control-label " for="form-field-1">الإسم </label>

                                            <div class="col-sm-6">
                                                <input runat="server" type="text" id="EmpNameU" placeholder="اسم الإدارة متوسطة" class="form-control text col-xs-10 col-sm-10" />

                                                <span>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="EmpNameU" runat="server" ValidationGroup="GU" ForeColor="#ff3c3c" ErrorMessage="اسم الإدارة متوسطة مطلوب  *"></asp:RequiredFieldValidator></span>
                                            </div>


                                        </div>


                                    </div>




                                </div>
                                <div class="row">
                                    <div class="col-xs-12 col-sm-12">


                                        <div class="form-group">
                                            <label class="col-sm-2 control-label " for="form-field-1">الإدارة العليا </label>

                                            <div class="col-sm-6">


                                               <div>
                                                    <asp:DropDownList class="chosen-select chosen-rtl form-control" ID="SectorU" runat="server" data-placeholder="الإدارات عليا">
                                                    </asp:DropDownList>
                                                </div>
                                                <span>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" InitialValue=" " ControlToValidate="SectorU" runat="server" ValidationGroup="GU" ForeColor="#ff3c3c" ErrorMessage="الإدارة العليا مطلوب  *"></asp:RequiredFieldValidator></span>
                                            </div>
                                        </div>

                                    </div>



                                </div>



                            </div>
                            <div class="modal-footer">
                                <asp:Label ID="RettU" runat="server" Text="" ForeColor="#ff3c3c"></asp:Label>
                                <asp:Button ID="SaveUpdates" OnClick="SaveUpdates_Click" ValidationGroup="GU" CssClass="btn btn-success white" runat="server" Text="حفظ" />
                                
                            </div>
                        </div>
                    </div>
                    <div>
                        <asp:LinkButton ID="BackTables" runat="server" OnClick="BackTables_Click" Style="float: left; margin-top: -10px;"><i class="ace-icon fa fa-arrow-left icon-only purple bigger-250"></i></asp:LinkButton>
                    </div>
                </div>
                </div>

            </ContentTemplate>
        </asp:UpdatePanel>
        <div id="Del_modalMang" data-backdrop="static" data-keyboard="false" style="top: 20%" aria-hidden="false" class="modal fade" tabindex="-1">
        <div class="modal-dialog" style="width: 60%; padding-right: 20%;">
            <div class="modal-content">
                <div class="modal-body">
                    <div style="margin-top: 7px;" class="row">

                        <div class="col-sm-1" style="text-align: right;">
                            
                        </div>
                        <div class="col-lg-8" style="text-align: right;">
                            <h4 class="align-right">هل أنت متأكد من الغاء الصلاحية ؟ </h4>
                        </div>
                        <div class="col-lg-3">
                            <button type="button" class="close red" data-dismiss="modal">
                                <img src="assets/images/Icons/BasicIcon/close.png" height="46" /></button>
                        </div>


                        <input style="display: none" type="text" runat="server" name="bookId" id="DMang" value="" />
                    </div>
                </div>
                <div class="modal-footer">

                    <asp:ImageButton ID="DelManager" Height="55" ImageAlign="AbsMiddle" ImageUrl="assets/icons/buttons/del.png" OnClick="DelManager_Click" runat="server" />
                    <span><a href="#" data-dismiss="modal">
                        </a>
                    </span>
                </div>
            </div>
        </div>
    </div>
        <div id="Del_modal" data-backdrop="static" data-keyboard="false" style="top: 20%" aria-hidden="false" class="modal fade" tabindex="-1">
            <div class="modal-dialog" style="width: 60%; padding-right: 20%;">
                <div class="modal-content">
                    <div class="modal-body">
                        <div style="margin-top: 7px;" class="row">

                            <div class="col-sm-1" style="text-align: right;">
                                
                            </div>
                            <div class="col-lg-8" style="text-align: right;">
                                <h4 class="align-right">هل أنت متأكد من حذف هذه إدارة متوسطة <span>
                                    <label style="display: inline" id="Admm" />
                                </span>
                                    ؟ </h4>
                            </div>
                            <div class="col-lg-3">
                                <button type="button" class="close red" data-dismiss="modal">
                                    <img src="assets/images/Icons/BasicIcon/close.png" height="46" /></button>
                            </div>


                            <input style="display: none" type="text" runat="server" name="bookId" id="bookId" value="" />
                        </div>
                    </div>
                    <div class="modal-footer">

                        <asp:ImageButton ID="DelEmployee" Height="55" ImageAlign="AbsMiddle" ImageUrl="assets/icons/buttons/del.png" OnClick="DelEmployee_Click" runat="server" />
                        <span><a href="#" data-dismiss="modal">
                            </a>
                        </span>
                    </div>
                </div>
            </div>
        </div>

        <!--------------------------------->

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

            $('#modal-form').on('hide.bs.modal', function (e) {
                $("#<%=EmpName.ClientID%>").val('');
            });
            $('#Del_modal').on('show.bs.modal', function (e) {
                var bookId = $(e.relatedTarget).data('book-id');
                $(e.currentTarget).find($("#<%=bookId.ClientID%>")).val(bookId.substring(0, bookId.indexOf("&")));

                $("#Admm").text(bookId.substring(bookId.indexOf("&") + 1, bookId.length));

            });
             $('#Del_modalMang').on('show.bs.modal', function (e) {
                var bookId = $(e.relatedTarget).data('book-id');
                $(e.currentTarget).find($("#<%=DMang.ClientID%>")).val(bookId);



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

            if ((document.getElementById("<%=LblEdit.ClientID%>").innerText == "A") || (document.getElementById("<%=RettU.ClientID%>").innerText.length > 0)) {
                $('#modal-formU').modal('show');
                $('#modal-form').modal('hide');

            }
            else {
                $("#<%=EmpNameU.ClientID%>").val("");
                $('#modal-formU').modal('hide');
            }

            if (document.getElementById("<%=Rett.ClientID%>").innerText.length > 0) {
                $('#modal-form').modal('show');
                $('#modal-formU').modal('hide');
            }
            else {
                $("#<%=EmpName.ClientID%>").val("");
                $('#modal-form').modal('hide');
            }



        });


    </script>

</asp:Content>
