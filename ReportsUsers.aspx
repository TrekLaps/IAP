<%@ Page Title="صلاحيات إدارة الملاحظات" Language="C#" MasterPageFile="~/MasterPage.master" CodeFile="~/ReportsUsers.aspx.cs" AutoEventWireup="true" Inherits="ReportsUsers" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
     <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.min.js"></script>


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
    صلاحيات إدارة الملاحظات
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" runat="Server">
    <h3>
        صلاحيات إدارة الملاحظات </h3>
    <div class="MainBox">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>

                <div class="row">
                    <div class="col-xs-12">

                        <asp:UpdateProgress ID="UpdateProgress1"
                            AssociatedUpdatePanelID="UpdatePanel4"
                            runat="server">
                            <ProgressTemplate>
                                <i class="ace-icon fa fa-spinner fa-spin green bigger-125"></i>جارى التحميل...            
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                            <ContentTemplate>
                                <div class="row">
                                    <div class="col-xs-12 col-sm-4">

                                        <div class="form-group">
                                            <label class="col-sm-2 control-label" for="form-field-1">الإدارة العليا </label>

                                            <div>
                                                <div class="col-sm-10">

                                                   <div>
                                                        <asp:DropDownList class="chosen-select chosen-rtl form-control" ID="Sector" AutoPostBack="true" OnSelectedIndexChanged="Sector_SelectedIndexChanged" runat="server" data-placeholder="الإدارات عليا">
                                                        </asp:DropDownList>
                                                    </div>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="Sector" InitialValue=" " runat="server" ValidationGroup="G" ForeColor="#ff3c3c" ErrorMessage=" مطلوب اختيار الإدارة العليا *"></asp:RequiredFieldValidator>
                                                </div>

                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-xs-12 col-sm-4">

                                        <label class="col-sm-2 control-label" for="form-field-1">الإدارة متوسطة  </label>

                                        <div class="col-sm-10">

                                           <div>
                                                <asp:DropDownList class="chosen-select chosen-rtl form-control" ID="Admins1" AutoPostBack="true" OnSelectedIndexChanged="Admins1_SelectedIndexChanged" runat="server" data-placeholder="الإدارة متوسطة">
                                                </asp:DropDownList>
                                            </div>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ControlToValidate="Admins1" InitialValue=" " runat="server" ValidationGroup="G" ForeColor="#ff3c3c" ErrorMessage="الإدارة متوسطة مطلوب *"></asp:RequiredFieldValidator>

                                        </div>
                                    </div>


                                    <div class="col-xs-12 col-sm-4">


                                        <div class="form-group">
                                            <label class="col-sm-2 control-label" for="form-field-1">الموظف</label>

                                            <div class="col-sm-10">
                                               <div>
                                                    <asp:DropDownList class="chosen-select chosen-rtl form-control" ID="DropNotAdmins" runat="server" data-placeholder="اخر الموظف لتسجيله">
                                                    </asp:DropDownList>
                                                </div>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="DropNotAdmins" InitialValue=" " runat="server" ValidationGroup="G" ForeColor="#ff3c3c" ErrorMessage=" مطلوب اختيار الموظف لتسجيله كأدمن *"></asp:RequiredFieldValidator>
                                            </div>

                                        </div>
                                    </div>
                                </div>
                                </div>

                            <div class="row">
                                <div class="modal-footer">
                                    <asp:Label ID="Rett" runat="server" Text="" CssClass="Rett" ForeColor="#ff3c3c"></asp:Label>
                                    <asp:Button ID="Save" OnClick="Save_Click" ValidationGroup="G" CssClass="btn btn-success white" runat="server" Text="تسجيل" />


                                </div>

                            </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <div class="row">

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
                        <div>
                            <table id="dynamic-table" class=" table-striped table-bordered">
                                <thead class="TableHead">
                                    <tr>


                                        <th class="center">اسم الموظف
                                                                               
                                        </th>
                                        <th class="center">الإدارة العليا</th>
                                        <th class="center">الإدارة متوسطة 
                                        </th>
                                        <th class="center">الوظيفة
                                       
                                        </th>
                                        <th class="center">
                                            ادارة النظام
                                        </th>
                                        <th class="center">ادارة الملاحظات

                                        </th>   

                                       <th class="center">خذف الصلاحية</th>
                                    </tr>
                                </thead>

                                <tbody>
                                    <asp:Repeater ID="EmployeesData" runat="server">
                                        <ItemTemplate>

                                            <tr>
                                                <td class="center">
                                                  
                                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("EmpName") %>'></asp:Label>

                                                </td>
                                                <td class="center">
                                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("SectionName") %>'></asp:Label>

                                                </td>
                                                <td class="center">
                                                    <asp:Label ID="Label5" runat="server" Text='<%# Eval("AdmName") %>'></asp:Label>

                                                </td>


                                                <td class="center">
                                                    <asp:Label ID="Label7" runat="server" Text='<%# Eval("EmpJobTitle") %>'></asp:Label>

                                                </td>


                                                
                                               
                                                <td class="center">
                                                    <i runat="server" class="fa fa-minus-circle" visible='<%#Convert.ToBoolean(Eval("SystemAdmin"))?false:true%>' style="font-size: 27px; color: red"></i>
                                                    <i runat="server" class="fa fa-check-circle" visible='<%#Convert.ToBoolean(Eval("SystemAdmin"))?true:false%>' style="font-size: 27px; color: lightgreen"></i>

                                                </td>
 <td class="center">
                                                    <i runat="server" class="fa fa-minus-circle" visible='<%#Convert.ToBoolean(Eval("ApprovPermission"))?false:true%>' style="font-size: 27px; color: red"></i>
                                                    <i runat="server" class="fa fa-check-circle" visible='<%#Convert.ToBoolean(Eval("ApprovPermission"))?true:false%>' style="font-size: 27px; color: lightgreen"></i>

                                                </td>
                                                <td class="center">

                                                    <a class="red" role='button' data-rel="tooltip" title="حذف" href='#Del_modal' data-toggle='modal' data-book-id='<%# Eval("EmpID") %>'>
                                                        <i class="ace-icon fa fa-close icon-only bigger-120"></i><span class='hidden'>حذف</span>
                                                    </a>
                                                    </div>

                                                <div class="hidden-md hidden-lg">
                                                    <div class="inline pos-rel">
                                                        <button class="btn btn-minier btn-#e7ea56 dropdown-toggle" data-toggle="dropdown" data-position="auto">
                                                            <i class="ace-icon fa fa-caret-down icon-only bigger-120"></i>
                                                        </button>

                                                        <ul class="dropdown-menu dropdown-only-icon dropdown-#e7ea56 dropdown-menu-right dropdown-caret dropdown-close">


                                                            <li><a class="red" role='button' data-rel="tooltip" title="حذف" href='#Del_modal' data-toggle='modal' data-book-id='<%# Eval("EmpID") %>'>
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
                </div>


            </ContentTemplate>
        </asp:UpdatePanel>



        <div id="Del_modal" data-backdrop="static" data-keyboard="false" style="top: 20%" aria-hidden="false" class="modal fade" tabindex="-1">
            <div class="modal-dialog" style="width: 60%; padding-right: 20%;">
                <div class="modal-content">
                    <div class="modal-body">
                        <div style="margin-top: 7px;" class="row">

                            <div class="col-sm-1" style="text-align: right;">
                                
                            </div>
                            <div class="col-lg-8" style="text-align: right;">
                                <h4 class="align-right">هل متأكد من حذف هذا المستخدم من قائمة المسؤولين عن ادارة الملاحظات ؟
 </h4>
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

            $('#Del_modal').on('show.bs.modal', function (e) {
                var bookId = $(e.relatedTarget).data('book-id');
                $(e.currentTarget).find($("#<%=bookId.ClientID%>")).val(bookId);


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




        }





        jQuery(function ($) {

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



        });


    </script>

</asp:Content>

