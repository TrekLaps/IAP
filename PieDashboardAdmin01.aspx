<%@ Page Title="نتائج معالجة ملاحظات الإدارة متوسطة " MaintainScrollPositionOnPostback="true" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PieDashboardAdmin01.aspx.cs" Inherits="PieDashboardAdmin01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.min.js"></script>
    <!-- page specific plugin styles -->
    <link rel="stylesheet" href="assets/css/jquery-ui.custom.min.css" />
    <link rel="stylesheet" href="assets/css/chosen.min.css" />
    <link rel="stylesheet" href="assets/css/bootstrap-datepicker3.min.css" />
    <link rel="stylesheet" href="assets/css/bootstrap-timepicker.min.css" />
    <link rel="stylesheet" href="assets/css/daterangepicker.min.css" />
    <link rel="stylesheet" href="assets/css/bootstrap-datetimepicker.min.css" />
    <link rel="stylesheet" href="assets/css/bootstrap-colorpicker.min.css" />

    <script src="assets/js/jquery-2.1.4.min.js"></script>

    <%--<script type="text/javascript" src="assets/js/loader.js"></script>--%>

    <!-- page specific plugin styles -->
    <link rel="stylesheet" href="assets/css/jquery.gritter.min.css" />
    <link rel="stylesheet" href="assets/css/bootstrap-multiselect.min.css" />
    <link rel="stylesheet" href="assets/css/select2.min.css" />
    <!-- page specific plugin styles -->
    <link rel="stylesheet" href="assets/css/jquery-ui.custom.min.css" />
    <link rel="stylesheet" href="assets/css/chosen.min.css" />
    <link rel="stylesheet" href="assets/css/bootstrap-datepicker3.min.css" />
    <link rel="stylesheet" href="assets/css/bootstrap-datetimepicker.min.css" />

    <script src="https://www.gstatic.com/charts/loader.js"></script>

    <script src="https://www.gstatic.com/charts/loader.js"></script>
    <script type="text/javascript" src="assets/js/loader.js"></script>
    <script src="js/jquery.stickyheader.js"></script>
    <script src="js/Pie.js"></script>
    <script type="text/javascript" src="assets/js/jsapi.js"></script>
<script src="https://www.gstatic.com/charts/loader.js"></script>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="PageTitle" runat="Server">
    نتائج معالجة ملاحظات الإدارة متوسطة 
     
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:UpdateProgress ID="UpdateProgress1z"
                AssociatedUpdatePanelID="UpdatePanel4"
                runat="server">
                <ProgressTemplate>
                    <div id="overlay1" style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 999999; background-color: #808080; opacity: 0.7;">

                        <div class="easy-pie-chart percentage" data-percent="100" data-color="#87B87F" style="top: 40%; height: 75px; width: 75px; line-height: 74px; color: rgb(135, 184, 127);">
                            <span class="percent">جارى التحميل...</span><i class="ace-icon fa fa-spinner fa-spin green bigger-125"></i>
                            <canvas height="75" width="75"></canvas>
                        </div>

                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <asp:UpdatePanel ID="UpdatePanel4" runat="server">

                <ContentTemplate>
                    <h3>
                         نتائج معالجة الملاحظات على مستوى الإدارات المتوسطة                </h3>
                    <div class="MainBox" style="height:300px;">


                        <div class="row">
                            <div class="col-lg-12">

                                <div class="col-lg-4">
                                    <h4 class="box-title">الخطة</h4>
                                    <div style="width: 310px;">
                                        <asp:DropDownList class="chosen-select chosen-rtl form-control" ID="MainYear" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="MainYear_SelectedIndexChanged" runat="server" data-placeholder="الخطة السنوية">
                                            <asp:ListItem Value="0" Text="جميع السنوات" Selected="True" />

                                        </asp:DropDownList>
                                    </div>

                                </div>
                                <div class="col-lg-4" runat="server" id="Sections">
                                    <h4 class="box-title">الإدارة العليا</h4>
                                    <div style="width: 310px;">
                                        <asp:DropDownList class="chosen-select chosen-rtl form-control" ID="MainSector" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="MainSector_SelectedIndexChanged" runat="server" data-placeholder="الإدارة العليا">
                                            <asp:ListItem Value="0" Text="اختر الإدارة العليا" Selected="True" />

                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-lg-4" runat="server" id="Adms">
                                    <h4 class="box-title">الإدارة متوسطة</h4>
                                    <div style="width: 310px;">
                                        <asp:DropDownList class="chosen-select chosen-rtl form-control" ID="MainDepart" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="MainDepart_SelectedIndexChanged" runat="server" data-placeholder="الإدارة متوسطة">
                                            <asp:ListItem Value="0" Text="اختر الإدارة متوسطة" Selected="True" />

                                        </asp:DropDownList>
                                    </div>
                                </div>

                            </div>
                        </div>
                        <div runat="server" id="MainsAll">
                            <div class="alert alert-info" runat="server" id="NoRep" visible="false">
                                لايوجد ملاحظات مسجلة
                            </div>
                            
                        </div>
                      


                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </ContentTemplate>
    </asp:UpdatePanel>

  
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
    <script src="assets/js/bootstrap-datepicker.min.js"></script>
    <script src="assets/js/moment.min.js"></script>
    <script src="assets/js/bootstrap-datetimepicker.min.js"></script>
    <script src="assets/js/jquery.knob.min.js"></script>
    <script src="assets/js/autosize.min.js"></script>


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

