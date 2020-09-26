<%@ Page Title="نتائج معالجة ملاحظات الإدارة متوسطة " MaintainScrollPositionOnPostback="true" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PieDashboardAdmin.aspx.cs" Inherits="PieDashboardAdmin" %>

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
    <style>
        .sticky-thead {
            display: none;
        }

        #chartStat_div svg g {
            cursor: pointer;
        }

        #myBox {
            top: 15%;
            height:420px;
        }
    </style>


    <script type="text/javascript" src="assets/js/loader.js"></script>
    <script src="js/jquery.stickyheader.js"></script>
    <script src="js/Pie.js"></script>
    <script type="text/javascript" src="assets/js/jsapi.js"></script>

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
                        نتائج معالجة الملاحظات على مستوى الإدارة متوسطة 
                    </h3>
                    <div class="MainBox">


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


                            </div>
                        </div>
                        <div runat="server" id="MainsAll">
                            <div class="alert alert-info" runat="server" id="NoRep" visible="false">
                                لايوجد ملاحظات مسجلة
                            </div>
                            <div runat="server" id="PrntView">

                                <div id="dvContents">

                                    <div class="row">

                                        <div class="container ">
                                            <div style="direction: ltr;">
                                                <div align='center' style="text-align: center;">
                                                    <div style="color: #070707; display: inline-block; text-align: center; background-color: #FFFFFF; border: 1px solid #D8D8D8; margin: 25px;  height: 355px; width: 450px; padding-right: 25px; text-align: center;">

                                                        <div align='center' style="color: #070707;">
                                                            <h4>مستوى الأهمية</h4>
                                                        </div>
                                                        <div class="row">


                                                            <div class="col-xs-5" style="z-index: 999; font-size: 20px; margin-top: 55px;">
                                                                <div class="row" style="background: none;">
                                                                    <div class="col-xs-2">
                                                                        <img src="assets/icons/levels/L1/high2.png" height="25" />
                                                                    </div>
                                                                    <div class="col-xs-10 RedImp-tooltip" style="text-align: right;">مرتفعة</div>
                                                                </div>
                                                                <div class="row" style="background: none; margin-bottom: 2px;">
                                                                    <div class="col-xs-2">
                                                                        <img src="assets/icons/levels/L1/low2.png" height="25" />
                                                                    </div>
                                                                    <div class="col-xs-10 YellowImp-tooltip" style="text-align: right;">متوسطة</div>
                                                                </div>

                                                                <div class="row" style="background: none; margin-bottom: 2px;">
                                                                    <div class="col-xs-2">
                                                                        <img src="assets/icons/levels/L1/mid2.png" height="25" />
                                                                    </div>
                                                                    <div class="col-xs-10 GreenImp-tooltip" style="text-align: right;">منخفضة</div>
                                                                </div>
                                                                <div class="row" style="padding-top: 20px; text-align: right;">

                                                                    <asp:HyperLink ID="HyperLink1" runat="server">
                                                            
                                                            <img src="assets/icons/buttons/report.png" height="65" />
                                                                    </asp:HyperLink>
                                                                </div>
                                                            </div>
                                                            <div class="col-xs-7">
                                                                <div id="piechart2" style="text-align: center; display: block" align='center'>

                                                                    <asp:Literal ID="LtImport" runat="server"></asp:Literal>

                                                                    <div id="chartImport_div"></div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div style="display: inline-block; text-align: center;">

                                                        <br />
                                                        <div align='center' style="color: #070707; background-color: #FFFFFF; border: 1px solid #D8D8D8; margin: 25px;  height: 355px; width: 450px; padding-right: 25px; text-align: center;">
                                                            <h4>مستوى التنفيذ </h4>
                                                            <div class="row">
                                                                <div class="col-xs-5" style="z-index: 999; font-size: 20px; margin-top: 55px; color: #000;">

                                                                    <div class="row" style="background: none; margin-bottom: 2px;">
                                                                        <div class="col-xs-2">
                                                                            <img src="assets/icons/levels/L2/hold2.png" height="25" />
                                                                        </div>
                                                                        <div class="col-xs-10" style="text-align: right">
                                                                            <span data-toggle="tooltip" data-placement="bottom" class="red-tooltip" title="لم يتم معالجة الملاحظة وفقا للتاريخ المحدد من قبل الإدارة متوسطة" >متأخرة</span>
                                                                        </div>
                                                                    </div>
                                                                    <div class="row" style="background: none; margin-bottom: 2px;">
                                                                        <div class="col-xs-2">
                                                                            <img src="assets/icons/levels/L2/under2.png" height="25" />
                                                                        </div>
                                                                        <div class="col-xs-10" style="text-align: right"><span data-toggle="tooltip" data-placement="bottom" class="yellow-tooltip" title="تم معالجة جزء من توصيات الملاحظة" >جارى التنفيذ</span></div>
                                                                    </div>
                                                                    <div class="row" style="background: none; margin-bottom: 2px;">
                                                                        <div class="col-xs-2">
                                                                            <img src="assets/icons/levels/L2/notstart2.png" height="25" />
                                                                        </div>
                                                                        <div class="col-xs-10" style="text-align: right">
                                                                            <span data-toggle="tooltip" data-placement="bottom" class="blue-tooltip" title="لم يحن تاريخ معالجة التوصية / الملاحظة" >لم يحن وقت تنفيذها</span>
                                                                        </div>
                                                                    </div>
                                                                    <div class="row" style="background: none; margin-bottom: 2px;">
                                                                        <div class="col-xs-2">
                                                                            <img src="assets/icons/levels/L2/solved2.png" height="25" />
                                                                        </div>
                                                                        <div class="col-xs-10" style="text-align: right"><span data-toggle="tooltip" data-placement="bottom" class="green-tooltip" title="تم معالجة جميع التوصيات" >المعالجة</span></div>
                                                                    </div>


                                                                    <div class="row" style="background: none; margin-bottom: 2px;">
                                                                        <div class="col-xs-2">
                                                                            <img src="assets/icons/levels/L2/closed2.png" height="25" />
                                                                        </div>
                                                                        <div class="col-xs-10" style="text-align: right">
                                                                            <span data-toggle="tooltip" data-placement="bottom" class="grey-tooltip" title="مكررة / غير قابلة للتطبيق" >مغلقة</span>
                                                                        </div>
                                                                    </div>


                                                                </div>
                                                                <div class="col-xs-7">
                                                                    <div id="piechart" style="text-align: center;" align='center'>
                                                                        <asp:Literal ID="LitStat" runat="server"></asp:Literal>

                                                                        <div id="chartStat_div"></div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>


                                                    </div>
                                                    <!-- risk -->

                                                    <div align='center' style="text-align: center;">



                                                        <!--coloum bar -->
                                                        <div style="display: inline-block; text-align: center;">
                                                            <%--height: 935px;--%>
                                                            <div align='center' style="color: #070707; background-color: #FFFFFF; border: 1px solid #D8D8D8; padding: 25px; margin: 25px;  padding-right: 25px; width: 975px; text-align: center;">
                                                                <h4>مستوى التنفيذ </h4>
                                                                <asp:UpdateProgress ID="UpdateProgress1"
                                                                    AssociatedUpdatePanelID="UpdatePanel4"
                                                                    runat="server">
                                                                    <ProgressTemplate>
                                                                        <i class="ace-icon fa fa-spinner fa-spin green bigger-125"></i>جارى التحميل...            
                                                                    </ProgressTemplate>
                                                                </asp:UpdateProgress>
                                                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                                    <ContentTemplate>


                                                                        <asp:HiddenField ID="hidden" runat="server" Value="0" />
                                                                        <asp:HiddenField ID="HiddenTitle" runat="server" />
                                                                        <asp:HiddenField ID="Stat" Value="Non" runat="server" />

                                                                        <div id="myBox" style="display: none;" class="MyBox">


                                                                            <span id="close" class="close">&times;</span>


                                                                            <p>
                                                                                <span runat="server" id="LblTitle" />
                                                                                <!-- Trigger/Open The Modal -->
                                                                            </p>
                                                                            <div class="row">

                                                                                <div class="col-xs-12">
                                                                                    <div class="col-xs-1" style="color: #4CAF50;"><i class="fa fa-circle"></i></div>
                                                                                    <div class="col-xs-2">منخفضة</div>
                                                                                    <div class="col-xs-1" style="color: #FF9800;"><i class="fa fa-circle"></i></div>
                                                                                    <div class="col-xs-2">متوسطة</div>
                                                                                    <div class="col-xs-1" style="color: #9C27B0;"><i class="fa fa-circle"></i></div>
                                                                                    <div class="col-xs-2">مرتفعة</div>
                                                                                </div>
                                                                            </div>
                                                                            <hr />
                                                                            <div class="col-sm-12" style="text-align: center!important; direction: ltr; margin-top: 35px;">
                                                                                <table border="1" class="color" cellpadding="2" cellspacing="2" style="width: 100%">
                                                                                    <thead class="TableHead">
                                                                                        <tr>
                                                                                            <th style="width: 50%" class="center">القيمة</th>
                                                                                            <th class="center">مستوى الأهمية</th>
                                                                                        </tr>
                                                                                    </thead>
                                                                                    <tbody>
                                                                                        <asp:Repeater ID="RepImpData" OnItemDataBound="RepImpData_ItemDataBound1" OnDisposed="RepImpData_Disposed" runat="server">
                                                                                            <ItemTemplate>
                                                                                                <tr>
                                                                                                    <td class="center" style="padding: 10px">
                                                                                                        <asp:Label ID="LblCounts" runat="server" Text='<%# Eval("Counts") %>'></asp:Label>
                                                                                                        [<asp:Label ID="LblAvg" runat="server" Text=""></asp:Label>]

                                                              
                                                                                                    </td>
                                                                                                    <td class="center" style="padding: 10px;">
                                                                                                        <div id="LowVal" visible="false" runat="server">
                                                                                                            <img src="assets/icons/levels/L1/mid2.png" height="25" />
                                                                                                        </div>
                                                                                                        <div id="MidVal" visible="false" runat="server">
                                                                                                            <img src="assets/icons/levels/L1/low2.png" height="25" />
                                                                                                        </div>

                                                                                                        <div id="HighVal" visible="false" runat="server">
                                                                                                            <img src="assets/icons/levels/L1/high2.png" height="25" />
                                                                                                        </div>

                                                                                                        <asp:Label ID="LblImp" runat="server" Visible="false" Text='<%# Eval("Importance") %>'></asp:Label></td>
                                                                                                </tr>
                                                                                            </ItemTemplate>
                                                                                        </asp:Repeater>
                                                                                    </tbody>
                                                                                </table>

                                                                            </div>
                                                                        </div>
                                                                        <asp:Literal ID="lt" runat="server"></asp:Literal>
                                                                        <div class="row" style="display: none;">
                                                                            <div class="col-xs-3" style="z-index: 999; margin-top: 120px;">

                                                                                <div class="row" style="background: none; margin-bottom: 2px;">
                                                                                    <div class="col-xs-2">
                                                                                        <img src="assets/icons/levels/L2/hold2.png" height="25" />
                                                                                    </div>
                                                                                    <div class="col-xs-10" style="text-align: right">
                                                                                        <span data-toggle="tooltip" data-placement="bottom" class="red-tooltip" title="لم يتم معالجة الملاحظة وفقا للتاريخ المحدد من قبل الإدارة متوسطة" >متأخرة</span>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="row" style="background: none; margin-bottom: 2px;">
                                                                                    <div class="col-xs-2">
                                                                                        <img src="assets/icons/levels/L2/under2.png" height="25" />
                                                                                    </div>
                                                                                    <div class="col-xs-10" style="text-align: right"><span data-toggle="tooltip" data-placement="bottom" class="yellow-tooltip" title="تم معالجة جزء من توصيات الملاحظة" >جارى التنفيذ</span></div>
                                                                                </div>
                                                                                <div class="row" style="background: none; margin-bottom: 2px;">
                                                                                    <div class="col-xs-2">
                                                                                        <img src="assets/icons/levels/L2/notstart2.png" height="25" />
                                                                                    </div>
                                                                                    <div class="col-xs-10" style="text-align: right">
                                                                                        <span data-toggle="tooltip" data-placement="bottom" class="blue-tooltip" title="لم يحن تاريخ معالجة التوصية / الملاحظة" >لم يحن وقت تنفيذها</span>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="row" style="background: none; margin-bottom: 2px;">
                                                                                    <div class="col-xs-2">
                                                                                        <img src="assets/icons/levels/L2/solved2.png" height="25" />
                                                                                    </div>
                                                                                    <div class="col-xs-10" style="text-align: right"><span data-toggle="tooltip" data-placement="bottom" class="green-tooltip" title="تم معالجة جميع التوصيات" >المعالجة</span></div>
                                                                                </div>


                                                                                <div class="row" style="background: none; margin-bottom: 2px;">
                                                                                    <div class="col-xs-2">
                                                                                        <img src="assets/icons/levels/L2/closed2.png" height="25" />
                                                                                    </div>
                                                                                    <div class="col-xs-10" style="text-align: right">
                                                                                        <span data-toggle="tooltip" data-placement="bottom" class="grey-tooltip" title="مكررة / غير قابلة للتطبيق" >مغلقة</span>
                                                                                    </div>
                                                                                </div>

                                                                            </div>
                                                                            <div class="col-xs-9">
                                                                                <div id="chart_div"></div>
                                                                            </div>
                                                                        </div>




                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                              <!--  <p style="display: none;">
                                                                    <asp:ImageButton ID="SectionCharts" CssClass="Bttn" Style="background-color: #e6e6e6;" OnClick="SectionCharts_Click" ImageUrl="~/assets/icons/buttons/risk.png" Width="160" Height="60" runat="server" />


                                                                </p> -->
                                                                <div class="row">

                                                                    <div class="col-sm-12" align="center" style="direction: rtl; margin-top: 35px;">
                                                                        <table id="dynamic-table"  class="color">
                                                                            <tr>
                                                                                <th class="thcolor" style="width:200px;">&nbsp;</th>


                                                                                <th style="width: 150px; background-color: #93cdf3;text-align:center;" class=" thcolor">الإجمالى</th>

                                                                            </tr>

                                                                            <tr>



                                                                                <asp:Repeater ID="Repeater2" runat="server">
                                                                                    <HeaderTemplate>
                                                                                        <td style="white-space: nowrap; margin: 0; direction: rtl; padding: 0; width: 20%;" class="thover">

                                                                        <div class="row tdcolor" style="margin: 0 ;text-align: right;background-color:#9c27b0;color:#FFF;">
                                                                                <span data-toggle="tooltip" data-placement="bottom" class="red-tooltip" title="لم يتم معالجة الملاحظة وفقا للتاريخ المحدد من قبل الإدارة متوسطة">متأخرة</span>
                                                                            </div>
                                                                       
                                                                        <div  style="margin: 0;text-align: right ;background-color: #FF9800;color:#FFF;"><span data-toggle="tooltip" data-placement="bottom" class="yellow-tooltip" title="تم معالجة جزء من توصيات الملاحظة">جارى التنفيذ</span></div>
                                                                        
                                                                        <div class="row tdcolor" style="margin: 0 ;text-align: right ; background-color:#727aa2;color:#FFF;">
                                                                                <span data-toggle="tooltip" data-placement="bottom" class="blue-tooltip" title="لم يحن تاريخ معالجة التوصية / الملاحظة">لم يحن وقت تنفيذها</span>
                                                                            </div>
                                                                        
                                                                        <div class="row tdcolor" style="margin: 0 ; text-align: right ; background-color:#4CAF50;color:#FFF;"><span data-toggle="tooltip" data-placement="bottom" class="green-tooltip" title="تم معالجة جميع التوصيات">المعالجة</span></div>
                                                                        


                                                                        <div class="row tdcolor" style="margin: 0 ;text-align: right ; background-color:#93cdf3;color:#FFF;">
                                                                                <span data-toggle="tooltip" data-placement="bottom" class="grey-tooltip" title="مكررة / غير قابلة للتطبيق">مغلقة</span>
                                                                            </div>
                                                                        

                                                                        <div class="row tdcolor" style="margin: 0; text-align:right;background-color:#e6e6e6;">
                                                                               إجمالى الملاحظات
                                                                           
                                                                        </div>
                                                                    </td>
                                                                                    </HeaderTemplate>



                                                                                </asp:Repeater>


                                                                                <asp:Repeater ID="RepTotals" runat="server">
                                                                                    <ItemTemplate>
                                                                                        <td style="white-space: nowrap; vertical-align:top; margin: 0;text-align:center; direction: rtl; padding: 0; width: 80%;" class="thover">
                                                                                        
                                                                                             <div class="row tdcolor" style="margin: 0">
                                                                                    <asp:HyperLink ID="LinkButton1" Text='<%# Eval("TotalNotDone") %>' NavigateUrl='<%#"ReportAdmAll.aspx?E=1&YQ="+Request.QueryString["ReqY"]+"&S="+ Request.QueryString["Reqq"] %>' runat="server"></asp:HyperLink>                                                                                   </div>
                                                                                 <div class="row tdcolor" style="margin: 0">
                                                                                <asp:HyperLink ID="HyperLink1" Text='<%# Eval("TotalSemiDone") %>' NavigateUrl='<%#"ReportAdmAll.aspx?E=2&YQ="+Request.QueryString["ReqY"]+"&S="+ Request.QueryString["Reqq"] %>' runat="server"></asp:HyperLink> </div>
                                                                                 <div class="row tdcolor" style="margin: 0">
                                                                                <asp:HyperLink ID="HyperLink2" Text='<%# Eval("TotalNotNow") %>' NavigateUrl='<%#"ReportAdmAll.aspx?E=4&YQ="+Request.QueryString["ReqY"]+"&S="+ Request.QueryString["Reqq"] %>' runat="server"></asp:HyperLink>  </div>
                                                                                 <div class="row tdcolor" style="margin: 0">
                                                                               <asp:HyperLink ID="HyperLink3" Text='<%# Eval("TotalDone") %>' NavigateUrl='<%#"ReportAdmAll.aspx?E=3&YQ="+Request.QueryString["ReqY"]+"&S="+ Request.QueryString["Reqq"] %>' runat="server"></asp:HyperLink>   </div>

                                                                                 <div class="row tdcolor" style="margin: 0">
                                                                              <asp:HyperLink ID="HyperLink4" Text='<%# Eval("TotalClosed") %>' NavigateUrl='<%#"ReportAdmAll.aspx?E=5&YQ="+Request.QueryString["ReqY"]+"&S="+ Request.QueryString["Reqq"]%>' runat="server"></asp:HyperLink>  </div>

                                                                                          


                                                                                            <div class="row tdcolor" style="margin: 0">
                                                                                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("Total") %>'></asp:Label>
                                                                                            </div>
                                                                                        </td>
                                                                                    </ItemTemplate>
                                                                                </asp:Repeater>


                                                                            </tr>



                                                                        </table>
                                                                    </div>

                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>





                    <div id="Del_modal" data-backdrop="static" data-keyboard="false" style="z-index: 1999999; padding-top: 10%;" class="modal fade" tabindex="-1">
                        <div class="modal-dialog" style="width: 70%; padding-right: 20%;">
                            <div class="modal-content">

                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                                    <h4 class="blue bigger">مستوى الأهمية للملاحظات تبعا لحالة التنفيذ والإدارة متوسطة </h4>
                                </div>

                                <div class="modal-body">
                                </div>

                            </div>
                        </div>
                    </div>


                    <asp:HiddenField ID="HiddenYear" Value="0" runat="server" />
                    <asp:HiddenField ID="HiddenStat" runat="server" />
                    <asp:HiddenField ID="HiddenTitleP" runat="server" />

                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:Label ID="ShowData" Style="display: none;" runat="server" Text=""></asp:Label>
    <asp:HiddenField ID="PaneName" runat="server" />


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

        $(window).load(function () {

            var paneName = $("[id*=PaneName]").val();
            if (paneName != "") {

                $("#accordion .in").removeClass("in");
                $("#accordion .show").removeClass("show");


                //Set the selected Pane.
                $("#" + paneName).addClass("show");
            }
            else {
                $('.panel-collapse.in').removeClass("in");
                $('#collapse1').addClass("in");
            }
        });


        //When Pane is clicked, save the ID to the Hidden Field.
        function Hidden(Stat) {


            document.getElementById('<%=Stat.ClientID %>').value = Stat;
            __doPostBack();
        }
        function HiddenYears(Stat, val, Tit) {

            document.getElementById('<%=HiddenYear.ClientID %>').value = val;
            document.getElementById('<%=HiddenStat.ClientID %>').value = Stat;
            document.getElementById('<%=HiddenTitleP.ClientID %>').value = Tit;
            __doPostBack();
        }
        var span = document.getElementById("close");

        span.onclick = function () {
            document.getElementById('myBox').style.display = "none";
            document.getElementById('<%=Stat.ClientID %>').value = "Non";
        }

        var prm = Sys.WebForms.PageRequestManager.getInstance();
        if (prm != null) {
            prm.add_endRequest(function (sender, e) {
                if (sender._postBackSettings.panelsToUpdate != null) {
                    DisplayCurrentTime();


                }
            });
        };

        function DisplayCurrentTime() {

            var paneName = $("[id*=PaneName]").val() != "";
            if (paneName != "") {
                if (paneName != "collapse1") {
                    //Remove the previous selected Pane.
                    $("#accordion .in").removeClass("in");
                    $("#accordion .show").removeClass("show");

                    //Set the selected Pane.
                    $("#" + paneName).collapse("show");

                }
            }


            ////////////////////////
            $('.closeall').click(function () {
                $('.panel-collapse.in')
                    .collapse('hide');
            });
            $('.openall').click(function () {
                $('.panel-collapse:not(".in")')
                    .collapse('show');
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
            //When Pane is clicked, save the ID to the Hidden Field.
            $(".panel-heading a").click(function () {
                if ($(this).attr("href").replace("#", "") != "collapse1") {
                    $("[id*=PaneName]").val($(this).attr("href").replace("#", ""));
                }
            });

            $(".panel-heading a").click(function () {
                var aa = $(this).attr("href");


                $('.panel-collapse').removeClass("in");
                $('.panel-collapse').removeClass("show");
                $(aa).addClass("show");
            });
            $('[data-toggle="tooltip"]').tooltip();

             $('.YellowImp-tooltip').tooltip({ placement: 'bottom', title: '<p> متوسطة: - هنالك خلل في الضوابط الرقابية وإدارة متوسطة الأهمية ويتطلب تدخل الإدارة متوسطة في معالجته على المدى القصير، حيث ان حجم الأهمية هنا قد تؤدي إلى:</p> <ul><li>خسائر مالية متوسطة.</li><li>مخاطر في الضوابط الرقابية.</li><li>مخاطر متوسطة على السمعة.</li><li>اثار سلبية تأثر على المستوى التنظيمي.</li></ul>', html: true });
                $('.GreenImp-tooltip').tooltip({ placement: 'bottom', title: '<p> منخفضة: - هنالك خلل بسيط في الضوابط الرقابية وإدارة متوسطة الأهمية ولا تتطلب التدخل الفوري من قبل الادارة، حيث ان الاثار السلبية منخفضة.</p>', html: true });
                $('.RedImp-tooltip').tooltip({ placement: 'bottom', title: '<p>مرتفعة: - هنالك خلل في الضوابط الرقابية وإدارة متوسطة الأهمية، وتتطلب اهتمام الإدارة متوسطة الفوري، حيث ان حجم الأهمية كبير جداً وقد يؤدي الى:</p><ul><li>خسائر مالية كبيرة.</li><li>مخاطر استراتيجية.</li><li>مخاطر كبيرة على السمعة.</li>  </ul>', html: true });


            if (document.getElementById('<%=Stat.ClientID %>').value != "Non") {

                document.getElementById('myBox').style.display = 'block';


            }
            if (document.getElementById('<%=HiddenYear.ClientID %>').value != "0") {

                document.getElementById('myBox' + document.getElementById('<%=HiddenYear.ClientID %>').value).style.display = 'block';


            }

            $('[data-toggle="tooltip"]').tooltip

             $('.YellowImp-tooltip').tooltip({ placement: 'bottom', title: '<p> متوسطة: - هنالك خلل في الضوابط الرقابية وإدارة متوسطة الأهمية ويتطلب تدخل الإدارة متوسطة في معالجته على المدى القصير، حيث ان حجم الأهمية هنا قد تؤدي إلى:</p> <ul><li>خسائر مالية متوسطة.</li><li>مخاطر في الضوابط الرقابية.</li><li>مخاطر متوسطة على السمعة.</li><li>اثار سلبية تأثر على المستوى التنظيمي.</li></ul>', html: true });
                $('.GreenImp-tooltip').tooltip({ placement: 'bottom', title: '<p> منخفضة: - هنالك خلل بسيط في الضوابط الرقابية وإدارة متوسطة الأهمية ولا تتطلب التدخل الفوري من قبل الادارة، حيث ان الاثار السلبية منخفضة.</p>', html: true });
                $('.RedImp-tooltip').tooltip({ placement: 'bottom', title: '<p>مرتفعة: - هنالك خلل في الضوابط الرقابية وإدارة متوسطة الأهمية، وتتطلب اهتمام الإدارة متوسطة الفوري، حيث ان حجم الأهمية كبير جداً وقد يؤدي الى:</p><ul><li>خسائر مالية كبيرة.</li><li>مخاطر استراتيجية.</li><li>مخاطر كبيرة على السمعة.</li>  </ul>', html: true });

            ////////////////////////
            if (document.getElementById("<%=ShowData.ClientID%>").innerText == "A") {
                $('#Del_modal').modal({ show: true, backdrop: false });
            }

            $('.closeall').click(function () {
                $('.panel-collapse.in')
                    .collapse('hide');
            });
            $('.openall').click(function () {
                $('.panel-collapse:not(".in")')
                    .collapse('show');
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
        });
    </script>


</asp:Content>

