<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ReportingAdmSections.aspx.cs" Inherits="ReportingAdmSections" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
      <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.min.js"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">

    <script src="assets/js/jquery-2.1.4.min.js"></script>
    <script type="text/javascript" src="assets/js/loader.js"></script>
    <script src="js/jquery.stickyheader.js"></script>
    <script src="js/Pie.js"></script>
    <script type="text/javascript" src="assets/js/jsapi.js"></script>

    <!-- page specific plugin styles -->
    <link rel="stylesheet" href="assets/css/bootstrap-duallistbox.min.css" />
    <link rel="stylesheet" href="assets/css/bootstrap-multiselect.min.css" />
    <link rel="stylesheet" href="assets/css/select2.min.css" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageTitle" runat="Server">
    تقرير معالجة الملاحظات
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageContent" runat="Server">
    <asp:UpdateProgress ID="UpdateProgress1z"
        AssociatedUpdatePanelID="UpdatePanel1"
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

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">

        <ContentTemplate>


            <div class="row" style="padding: 20px;">



                <div style="margin-bottom: 20px;">

                    <h3>
                        
                        تقرير معالجة الملاحظات 
                    </h3>

                     <div id="Suc" runat="server" visible="false" class="alert alert-block alert-success">
                            <strong>
                                <i class="ace-icon fa fa-check-square-o icon-only bigger-150"></i>
                                تم إرسال الملاحظات بنجاح !
                            </strong>

                        </div>

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
                        <div class="row" style="margin-bottom: 20px;">
                            <div class="col-lg-12">
                                <div class="col-lg-3">
                                    <h4 class="box-title">الخطة</h4>
                                    <div class="form-group">

                                        <div class="col-xs-12 col-sm-9">
                                            <select onchange="SelectYear()" style="font-size: 18px;" multiple="true" id="YearList" runat="server" name="state" class="select2" data-placeholder="اختر الخطة">
                                            </select>


                                        </div>
                                    </div>



                                </div>
                                <div class="col-lg-3">
                                    <h4 class="box-title">الإدارة متوسطة</h4>
                                    <div class="form-group">

                                        <div class="col-xs-12 col-sm-9">
                                            <select onchange="AdminChange()" style="font-size: 18px;" multiple="true" id="AdminList" runat="server" class="select2" data-placeholder="اختر الإدارة متوسطة">
                                            </select>


                                        </div>
                                    </div>


                                </div>
                            <div class="col-lg-3">
                                <h4 class="box-title">مستوى الأهمية</h4>
                                <div>
                                    <asp:DropDownList class="chosen-select chosen-rtl form-control" ID="DropImport" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="DropImport_SelectedIndexChanged" runat="server" data-placeholder="مستوى الأهمية">
                                        <asp:ListItem Selected="True" Value='0'>مستوى الأهمية</asp:ListItem>

                                        <asp:ListItem Value='3' style="color: red">مرتفعة</asp:ListItem>
                                        <asp:ListItem Value='2' style="color: orange">متوسطة</asp:ListItem>
                                        <asp:ListItem Value='1' style="color: green">منخفضة</asp:ListItem>

                                    </asp:DropDownList>
                                </div>
                            </div></div>
                        </div>
                        <div class="row">

                            
                            <div class="col-lg-6">
                                <h4 class="box-title">حالة الملاحظة</h4>
                                <div>
                                    <asp:CheckBoxList ID="RadioStatus" AutoPostBack="true" runat="server" OnSelectedIndexChanged="RadioStatus_SelectedIndexChanged" RepeatDirection="Horizontal">
                                        <asp:ListItem Value='3'><img height="37"  src="assets/icons/levels/L2/solved.png"  /></asp:ListItem>
                                        <asp:ListItem Value='2'><img height="37" src="assets/icons/levels/L2/under.png" /></asp:ListItem>
                                        <asp:ListItem Value='1'><img height="37"  src="assets/icons/levels/L2/hold.png" /></asp:ListItem>
                                        <asp:ListItem Value="5"><img height="37" src="assets/icons/levels/L2/closed.png" /></asp:ListItem>
                                        <asp:ListItem Value="4"><img height="37" src="assets/icons/levels/L2/notstart.png" /></asp:ListItem>

                                    </asp:CheckBoxList>
                                </div>
                            </div>
                        </div>




                        <div id="dvContents">

                            <asp:Repeater ID="RepYears" runat="server" OnItemDataBound="RepYears_ItemDataBound">
                                <ItemTemplate>

                                    <div class="row">
                                        <div align="center" id="yr" class='<%# Container.ItemIndex == 0 ? "ReportY0 col-lg-12" : "ReportY col-lg-12" %> ReportY00' runat="server" style="background-color: #92cb81; color: white; width: 100%; border-bottom: 1px black;">
                                            <asp:Label ID="YearID" Visible="false" runat="server" Text='<%# Eval("ID") %>'></asp:Label>


                                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("YearName") %>'></asp:Label>

                                        </div>
                                    </div>
                                    <asp:Repeater ID="RepReports" runat="server" OnItemDataBound="RepReports_ItemDataBound">
                                        <ItemTemplate>
                                            <div class="row">
                                                <div align="center" class="ReportMain ReportY1 col-lg-12" style="background-color: rgb(175,171,171); color: black; width: 100%;">
                                                    <asp:Label ID="SectionID" Visible="false" runat="server" Text='<%# Eval("SectionID") %>'></asp:Label>

                                                    <asp:Label ID="PlanID" Visible="false" runat="server" Text='<%# Eval("RepPlan") %>'></asp:Label>

                                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("SectionName") %>'></asp:Label>

                                                </div>
                                            </div>
                                            <asp:Repeater ID="RepAdmins" runat="server" OnItemDataBound="RepAdmins_ItemDataBound">
                                                <ItemTemplate>
                                                    <div class="row">
                                                        <div align="center" class="ReportMain ReportY2 col-lg-12" style="background-color: rgb(231,230,230); color: black; width: 100%;">
                                                            <asp:Label ID="DepartID" Visible="false" runat="server" Text='<%# Eval("RepAdms") %>'></asp:Label>
                                                            <asp:Label ID="SectID" Visible="false" runat="server" Text='<%# Eval("RepSection") %>'></asp:Label>
                                                            <asp:Label ID="PlnIDRep" Visible="false" runat="server" Text='<%# Eval("RepPlan") %>'></asp:Label>

                                                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("AdmName") %>'></asp:Label>

                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-lg-12 no-padding">
                                                            <table align="center" border="1" style="width: 100%;">
                                                                <tr class="RepHead">
                                                                    <td align="center" style="width: 5%;">الرقم التسلسلى</td>
                                                                    <td align="center" style="width: 5%;">حالة الملاحظة </td>
                                                                    <td align="center" style="width: 12%;">عنوان الملاحظة</td>
                                                                    <td align="center" style="width: 3%;">مستوى الأهمية</td>
                                                                    <td style="width: 75%; text-align: center; border-bottom: none;">
                                                                        <table class="no-padding no-margin" style="width: 100%;">
                                                                            <tr class="RepHead">
                                                                                <td style="width: 6%; text-align: center; border-left: 1px solid black;">حالة
                                                                                    <br />
                                                                                    التوصية</td>


                                                                                <td style="width: 135px; text-align: center; border-left: 1px solid black;">نص التوصية</td>
                                                                                <td style="width: 135px; text-align: center;">الإجراء التصحيحى</td>

                                                                                <td style="width: 50px; text-align: center; border-right: 1px solid black;">تاريخ
                                                                                    <br />
                                                                                    التنفيذ  </td>
                                                                            </tr>

                                                                        </table>

                                                                    </td>

                                                                </tr>
                                                                <asp:Repeater ID="PreviewReports" runat="server" OnItemDataBound="PreviewReports_ItemDataBound">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="RepID" Visible="false" runat="server" Text='<%# Eval("RepID") %>'></asp:Label>
                                                                        <asp:Label ID="RepStat" Visible="false" runat="server" Text='<%# Eval("RepStatus") %>'></asp:Label>



                                                                        <tr>
                                                                            <td style="width: 5%; text-align: center"><span>
                                                                                <%# Container.ItemIndex + 1 %></span></td>
                                                                            <td style="width: 5%; text-align: center">
                                                                                <span id="Done" visible="false" runat="server">
                                                                                    <img src="assets/icons/levels/L2/solved2.png" height="22"></span>

                                                                                <span id="SemiDone" visible="false" runat="server">
                                                                                    <img src="assets/icons/levels/L2/under2.png" height="22"></span>

                                                                                <span id="NoteDone" visible="false" runat="server">
                                                                                    <img src="assets/icons/levels/L2/hold2.png" height="22"></span>

                                                                                <span id="NoteNow" visible="false" runat="server">
                                                                                    <img src="assets/icons/levels/L2/notstart2.png" height="22"></span>

                                                                                <span id="Closed" visible="false" runat="server">
                                                                                    <img src="assets/icons/levels/L2/closed2.png" height="22"></span>
                                                                                 <div class="MsgButton"> <hr class="margin-3" style="border-top: 1px solid #73bb55;" />
                                                                                <asp:LinkButton title="ارسال اشعار" OnCommand="MsgButton_Command" CssClass="green" ID="MsgButton" CommandArgument='<%#Eval("RepSection") + ";" +Eval("RepAdms") + ";" +Eval("RepID")%>' runat="server"><span class="glyphicon glyphicon-time" style="font-size: 20px;"></span><span class='hidden'>اشعار</span></asp:LinkButton>
</div>

                                                                            </td>

                                                                            <td class="ReptitleRep" style="width: 12%;">


                                                                                <asp:Literal ID="LitText" runat="server" Text='<%# Eval("RepTitle").ToString().TrimStart() %>'></asp:Literal>

                                                                            </td>

                                                                            <td style="width: 3%; text-align: center;">
                                                                                <asp:Image ID="TD1" Height="22" runat="server" />
                                                                                <asp:Label ID="LblImportant" Visible="false" runat="server" Text='<%# Eval("Importance") %>'></asp:Label>
                                                                            </td>
                                                                            <td id="NotRow" runat="server" style="width: 75%; vertical-align: top; border: none; text-align: center;">
                                                                                <table class="no-padding no-margin" style="width: 100%; min-height: 130px;">

                                                                                    <asp:Repeater ID="RepNotes" OnItemDataBound="RepNotes_ItemDataBound" runat="server">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="NotStat" Visible="false" runat="server" Text='<%# Eval("NoteStatus") %>'></asp:Label>

                                                                                            <tr>
                                                                                                <td class="RepPrn" style="width: 6%; min-width: 35px; border-left: 1px solid black; border-top: 1px solid black; text-align: center;">

                                                                                                    <span id="Done" visible="false" runat="server">
                                                                                                        <img src="assets/icons/levels/L2/solved2.png" height="22"></span>

                                                                                                    <span id="SemiDone" visible="false" runat="server">
                                                                                                        <img src="assets/icons/levels/L2/under2.png" height="22"></span>

                                                                                                    <span id="NoteDone" visible="false" runat="server">
                                                                                                        <img src="assets/icons/levels/L2/hold2.png" height="22"></span>

                                                                                                    <span id="NoteNow" visible="false" runat="server">
                                                                                                        <img src="assets/icons/levels/L2/notstart2.png" height="22"></span>

                                                                                                    <span id="Closed" visible="false" runat="server">
                                                                                                        <img src="assets/icons/levels/L2/closed2.png" height="22"></span>

                                                                                                </td>



                                                                                                <td class="RepContent" style="width: 135px">
                                                                                                    <asp:Literal ID="LitNotText" runat="server" Text='<%# Eval("NoteText")%>'></asp:Literal>
                                                                                                </td>


                                                                                                <td class="RepContent" style="border-right: 1px solid black; width: 135px;">

                                                                                                    <asp:Literal ID="LitCorrect" runat="server" Text='<%# Eval("AdminCorrect") %>'></asp:Literal>

                                                                                                </td>


                                                                                                <td class="RepPrn" style="width: 50px; border-right: 1px solid black; border-top: 1px solid black; text-align: center;">

                                                                                                    <asp:Label ID="NotDatt" runat="server" Text='<%# Eval("NoteFrom") %>'></asp:Label>
                                                                                                </td>



                                                                                            </tr>


                                                                                        </ItemTemplate>

                                                                                    </asp:Repeater>
                                                                                </table>


                                                                            </td>
                                                                        </tr>



                                                                    </ItemTemplate>
                                                                </asp:Repeater>
                                                            </table>
                                                        </div>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:Repeater>

                                        </ItemTemplate>
                                    </asp:Repeater>

                                </ItemTemplate>
                            </asp:Repeater>
                            <div class="hr hr2 hr-double"></div>




                           <div style="margin-top: 50px; background-color: #FFFFFF;">

                            <table border="0" style="width: 100%">
                                <tr>
                                    <td>
                                        <div class="col-xs-2">
                                            <img src="assets/icons/levels/L2/solved2.png" height="22">
                                        </div>
                                        <div class="col-xs-10">تم معالجة جميع التوصيات</div>
                                    </td>

                                    <td>
                                        <div class="col-xs-2">
                                            <img src="assets/icons/levels/L2/under2.png" height="22">
                                        </div>
                                        <div class="col-xs-10">تم معالجة جزء من توصيات الملاحظة</div>
                                    </td>

                                    <td>
                                        <div class="col-xs-2">
                                            <img src="assets/icons/levels/L2/hold2.png" height="22">
                                        </div>
                                        <div class="col-xs-10">لم يتم معالجة الملاحظة وفقا للتاريخ المحدد من قبل الإدارة متوسطة</div>
                                    </td>
                                    <td>
                                        <div class="col-xs-2">
                                            <img src="assets/icons/levels/L2/closed2.png" height="22">
                                        </div>
                                        <div class="col-xs-10" style="text-align: right">
                                            مكررة / غير قابلة للتطبيق
                                        </div>
                                    </td>
                                    <td>
                                        <div class="col-xs-2">
                                            <img src="assets/icons/levels/L2/notstart2.png" height="22">
                                        </div>
                                        <div class="col-xs-10" style="text-align: right">
                                            لم يحن تاريخ معالجة التوصية / الملاحظة
                                        </div>
                                    </td>
                                </tr>
                                
                            </table>
                        </div>
                   


                  
                        <div style=" background-color: #FFFFFF;">

                            <table border="0" style="width: 100%;margin-top: 50px;"><tr style="margin-top: 5px; margin-bottom: 5px;">
                                    <td style="vertical-align:top;">
                                        <div class="col-xs-2">
                                            <img src="assets/icons/levels/L1/high2.png" height="22">
                                        </div>
                                        <div class="col-xs-10">
                                            مرتفعة: - هنالك خلل في الضوابط الرقابية وإدارة متوسطة الأهمية، وتتطلب اهتمام الإدارة متوسطة الفوري، حيث ان حجم الأهمية كبير جداً وقد يؤدي الى:
                                            <ul>
                                                <li>خسائر مالية كبيرة.</li>

                                                <li>مخاطر استراتيجية.</li>

                                                <li>مخاطر كبيرة على السمعة.</li>
                                            </ul>
                                        </div>
                                    </td>

                                    <td style="vertical-align:top;">
                                        <div class="col-xs-2">
                                            <img src="assets/icons/levels/L1/mid2.png" height="22">
                                        </div>
                                        <div class="col-xs-10">
                                            متوسطة: - هنالك خلل في الضوابط الرقابية وإدارة متوسطة الأهمية ويتطلب تدخل الإدارة متوسطة في معالجته على المدى القصير، حيث ان حجم الأهمية هنا قد تؤدي إلى:
                                                    <ul>
                                                        <li>خسائر مالية متوسطة.</li>
                                                        <li>مخاطر في الضوابط الرقابية.</li>



                                                        <li>مخاطر متوسطة على السمعة.</li>
                                                        <li>اثار سلبية تأثر على المستوى التنظيمي.</li>
                                                    </ul>
                                        </div>
                                    </td>

                                    <td style="vertical-align:top;">
                                        <div class="col-xs-2">
                                            <img src="assets/icons/levels/L1/low2.png" height="22">
                                        </div>
                                        <div class="col-xs-10">
                                            منخفضة: - هنالك خلل بسيط في الضوابط الرقابية وإدارة متوسطة الأهمية ولا تتطلب التدخل الفوري من قبل الادارة، حيث ان الاثار السلبية منخفضة.
                                        </div>
                                    </td>
                                </tr></table></div>
                        </div>


                        <div class="widget-toolbar hidden-print">
                            <a onclick="PrintDiv();" href="#">
                                <img src="assets/icons/buttons/print.png" height="50" />
                            </a>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="row">
                <div>
                    <asp:LinkButton ID="LinkButton2" runat="server" OnClick="BackCharts_Click" Style="float: left; margin-top: -10px;"><i class="ace-icon fa fa-arrow-left icon-only purple bigger-250"></i></asp:LinkButton>

                </div>
            </div>
            <div id="MsgReport_modal" runat="server" data-backdrop="static" data-keyboard="false" aria-hidden="false" class="modal fade" tabindex="-1">
                                <div class="modal-dialog" style="top: 20%">
                                    <div class="modal-content">

                                        <div class="modal-body">
                                            <div style="margin-top: 7px;" class="row">

                                                <div class="col-sm-1" style="text-align: right;">
                                                    
                                                </div>
                                                <div class="col-lg-8" style="text-align: right;">
                                                    <h4 class="align-right">سوف يتم ارسال اشعار بالملاحظة وجميع التوصيات الى مديرى الإدارة العامة والمديريرن </h4>

                                                </div>
                                                <div class="col-lg-3">
                                                    <asp:ImageButton ID="CloseNotify" OnClick="CloseNotify_Click" Height="46" CssClass="close red" ImageUrl="assets/images/Icons/BasicIcon/close.png" runat="server" />

                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-6 no-padding no-margin" style="margin-bottom: 10px;">

                                                    <label class="control-label" for="form-field-1">مديرى الإدارة العامة  </label>
                                                    <asp:CheckBoxList ID="SectionMangList" runat="server"></asp:CheckBoxList>
                                                </div>

                                                <div class="col-md-6 no-padding no-margin" style="margin-bottom: 10px;">

                                                    <label class="control-label" for="form-field-1">المديرين  </label>
                                                    <asp:CheckBoxList ID="DepartMangList" runat="server"></asp:CheckBoxList>
                                                </div>
                                            </div>
                                            <input style="display: none" type="text" runat="server" name="BookReport" id="BookReport" value="" />
                                        </div>

                                        <div class="modal-footer">

                                            <asp:ImageButton ID="SendRepNot" OnClick="SendRepNot_Click" Height="55" ImageAlign="AbsMiddle" ImageUrl="assets/icons/buttons/Send.png" runat="server" />

                                        </div>

                                    </div>
                                </div>
                            </div>
            <asp:HiddenField ID="HiddenYear" runat="server" />
            <asp:HiddenField ID="HiddenSector" runat="server" />
            <asp:HiddenField ID="HiddenAdmin" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Javascript" runat="Server">


    <!-- page specific plugin scripts -->
    <script src="assets/js/jquery.bootstrap-duallistbox.min.js"></script>
    <script src="assets/js/jquery.raty.min.js"></script>
    <script src="assets/js/bootstrap-multiselect.min.js"></script>
    <script src="assets/js/select2.min.js"></script>
    <script src="assets/js/jquery-typeahead.js"></script>
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
            //////////////////
            //select2
            $('.select2').css('width', '200px').select2({ allowClear: true })
            $('.select2-multiple-style .btn').on('click', function (e) {
                var target = $(this).find('input[type=radio]');
                var which = parseInt(target.val());
                if (which == 2) $('.select2').addClass('tag-input-style');
                else $('.select2').removeClass('tag-input-style');
            });
            ///////////////////
        }
        jQuery(function ($) {
            //////////////////
            //select2
            $('.select2').css('width', '200px').select2({ allowClear: true })
            $('.select2-multiple-style .btn').on('click', function (e) {
                var target = $(this).find('input[type=radio]');
                var which = parseInt(target.val());
                if (which == 2) $('.select2').addClass('tag-input-style');
                else $('.select2').removeClass('tag-input-style');
            });




            ///////////////////
        });
        function SelectYear() {
            $("#<%=HiddenYear.ClientID %>").val("1");
            __doPostBack();
        }

        function SectorChange() {
            $("#<%=HiddenSector.ClientID %>").val("1");
            __doPostBack();
        }

        function AdminChange() {

            $("#<%=HiddenAdmin.ClientID %>").val("1");
            __doPostBack();
        }

        function PrintDiv() {

            var contents = document.getElementById("dvContents").innerHTML;
            var frame1 = document.createElement('iframe');
            frame1.name = "frame1";
            frame1.style.position = "absolute";
            frame1.style.top = "-10px";
            document.body.appendChild(frame1);
            var frameDoc = frame1.contentWindow ? frame1.contentWindow : frame1.contentDocument.document ? frame1.contentDocument.document : frame1.contentDocument;
            frameDoc.document.open();
            frameDoc.document.write('<html><head><link rel="stylesheet" href="assets/css/ace-skins.min.css" /><link href="assets/css/MainPage.css" rel="stylesheet" /><link href="assets/css/bootstrap.min.css" rel="stylesheet" /><link rel="stylesheet" href="assets/css/ace-rtl.min.css" /><link rel="stylesheet" href="assets/css/ace.min.css" />');
             frameDoc.document.write('</head><body style="width:100%" class="no-skin rtl"><style>.RepPrn{border-bottom: 1px solid black;}.RepContent{border-bottom: 1px solid black;}@page { margin: 1cm;size: landscape;} .RepHead{font-size: 16px !important;} .ReportY0{background-color: #92cb81 !important;-webkit-print-color-adjust: exact; }.ReportY1{ background-color:rgb(175,171,171)!important;-webkit-print-color-adjust:exact;}.ReportY2{background-color:rgb(231,230,230)!important;-webkit-print-color-adjust: exact; } .MsgButton{display:none !important;} </style > ');
           frameDoc.document.write('<div class="row"><a><img src="assets/icons/BasicIcon/tri.png" style="height:70px; margin-right: 17px;" /></a><a>');
            frameDoc.document.write('<img src="assets/images/SAGIA-logo.png" style="height: 75px; float: left; margin-left: 20px; margin-top: 8px;" /></a></div> <div class="row">');
            frameDoc.document.write('<div class="col-sm-4" style="text-align: right; padding-right: 12px;"><a><img src="assets/icons/BasicIcon/AuditText2.png" style="height: 75px; margin-right: -22px; margin-top: -17px;" /></a></div></div>');
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

    </script>
</asp:Content>
