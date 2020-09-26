<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Log.aspx.cs" Inherits="Log" %>

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
    <link rel="stylesheet" href="assets/css/jquery-ui.min.css" />

    <!-- page specific plugin styles -->
    <link rel="stylesheet" href="assets/css/jquery-ui.custom.min.css" />
    <link rel="stylesheet" href="assets/css/jquery.gritter.min.css" />
    <link rel="stylesheet" href="assets/css/bootstrap-multiselect.min.css" />
    <link rel="stylesheet" href="assets/css/select2.min.css" />


</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="PageTitle" runat="Server">
    تتبع تسجيل الموظفين
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" runat="Server">

    <h3>
        
        تتبع تسجيل الموظفين
    </h3>
    <div class="row">
        <div class="col-md-4">
            <label class=" control-label" for="form-field-1">بحث بموظف  </label>
            <div style="width: 210px; height: 60px;">
                <asp:DropDownList class="chosen-select chosen-rtl form-control" AppendDataBoundItems="true" ID="DropUsers" AutoPostBack="true" OnSelectedIndexChanged="DropUsers_SelectedIndexChanged" runat="server" data-placeholder="الموظفين">
                    <asp:ListItem Selected="True" Text="كل الموظفين" Value="0"></asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>


    </div>
    <div class="MainBox">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="row" id="Main" runat="server">


                    <div class="row">
                        <div class="col-xs-12">




                            <asp:Label ID="LblData" Visible="false" runat="server" Text="لا يوجد تسجيل دخول للنظام"></asp:Label>

                            <!-- div.table-responsive -->

                            <!-- div.dataTables_borderWrap -->
                            <table id="dynamic-table" class=" table-striped table-bordered">


                                <thead class="TableHead">
                                    <tr>
                                        <th class="center">الإدارة العليا</th>


                                        <th class="center">الإدارة متوسطة
                                        </th>
                                        <th class="center">الموظف</th>


                                        <th class="center">التاريخ والوقت 
                              
                               
                                        </th>
                                        <th class="center">الصفحات </th>

                                    </tr>
                                </thead>

                                <tbody>
                                    <asp:Repeater ID="EmployeesData" runat="server">
                                        <ItemTemplate>

                                            <tr>
                                                <td class="center">
                                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("EmpName") %>'></asp:Label>
                                                </td>
                                                <td class="center">
                                                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("AdmName") %>'></asp:Label>
                                                </td>
                                                <td class="center">
                                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("SectionName") %>'></asp:Label>
                                                </td>

                                                <td class="center">
                                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("LogDatetime") %>'></asp:Label>
                                                </td>

                                                <td class="center">
                                                    <asp:Label ID="Label5" runat="server" Text='<%# Eval("LogTask") %>'></asp:Label>
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

            </ContentTemplate>
        </asp:UpdatePanel>



        <!--------------------------------->

        <asp:Label ID="LablSites" Style="display: none;" runat="server" Text=""></asp:Label>

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
                            null, null,null,null,
                            { "bSortable": false }
                        ],
                        "aaSorting": []

                        , "language": {
                            "info": " ",
                            "search": "ابحث بأى بيان :",
                            "zeroRecords": "لاتوجد بيانات متوافقة مع البحث",
                            "emptyTable": "لا توجد بيانات مسجلة",
                            "paginate": {
                                "previous": "<img src='assets/icons/buttons/pre.png' style='height:32px;'>",
                                "next": "<img src='assets/icons/buttons/next.png' style='height:32px;'>"

                            }
                        }



                    });



            $.fn.dataTable.Buttons.defaults.dom.container.className = 'dt-buttons btn-overlap btn-group btn-overlap';

            new $.fn.dataTable.Buttons(myTable, {
                buttons: [
                    {
                        "extend": "colvis",
                        "text": "<i class='fa fa-search bigger-110 white'></i> <span class='hidden'>اظهار / اخفاء العواميد</span>",
                        "className": "btn btn-success btn-bold Brd",
                        columns: ':not(:first):not(:last)', exportOptions: {
                            columns: [4,3,2, 1, 0]
                        }
                    },
                    {
                        "extend": "copy",
                        "text": "<i class='fa fa-copy bigger-110 white'></i> <span class='hidden'>انسخ جميع البيانات</span>",
                        "className": "btn btn-success btn-bold Brd", exportOptions: {
                            columns: [4,3,2, 1, 0]
                        }
                    },

                    {
                        "extend": "excel",
                        "text": "<i class='fa fa-file-excel-o bigger-110 white'></i> <span class='hidden'>الحصول على ملف Excel</span>",

                        "className": "btn btn-success btn-bold Brd", exportOptions: {
                            columns: [4,3,2, 1, 0]
                        }
                    },

                    {
                        "extend": "print",
                        "text": "<i class='fa fa-print bigger-110 white'></i> <span class='hidden'>اطبع</span>",
                        "className": "btn btn-success btn-bold Brd",
                        autoPrint: true,
                        customize: function (win) {
                            $(win.document.body)
                                .css('direction', 'rtl')
                                .prepend($('<img />')
                                    .attr("src", window.location.origin + "/assets/images/logo-250x78.png")
                                    .addClass('asset-print-img')
                                );
                            $(win.document.body).find('table')
                                .addClass('compact')
                                .css('font-size', 'inherit')
                                .css('th', 'text-align: center');
                        },
                        message: 'نظام إدارة الملاحظات والتوصيات بيانات قائمة متابعة دخول السيستم',
                        exportOptions: {
                            columns:  [4,3,2, 1, 0]

                        }
                    }
                ]
            });



            $(document).on('click', '#dynamic-table .dropdown-toggle', function (e) {
                e.stopImmediatePropagation();
                e.stopPropagation();
                e.preventDefault();
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

            DisplayCurrentTime();





        });


    </script>

</asp:Content>
