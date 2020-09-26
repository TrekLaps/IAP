<%@ Page Title=" نتائج معالجة الملاحظات " MaintainScrollPositionOnPostback="true" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MainDashboardGraph02.aspx.cs" Inherits="MainDashboardGraph02" %>

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

    <script type="text/javascript" src="assets/js/loader.js"></script>

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
      
        #chartImport_div svg g {
            cursor: pointer;
        }
    </style>


    <%-- <script type="text/javascript" src="assets/js/loader.js"></script>--%>
    <%--<script src="js/jquery.stickyheader.js"></script>--%>
    <script src="js/Pie.js"></script>
    <script type="text/javascript" src="assets/js/jsapi.js"></script>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="PageTitle" runat="Server">
    نتائج معالجة الملاحظات 
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" runat="Server">
    

    <div class="MainBox">
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
                <div style="padding-top: 5px;">

                    <div class="row">
                        <div class="col-md-6">
                            <h2 style="margin-top: 2px;">
                                <span runat="server" id="Span1">نتائج معالجة الملاحظات على مستوى المؤسسة </span>

                            </h2>
                        </div>
                        <div class="col-md-6">
                            <label class="col-md-2 control-label Sub blue" for="form-field-1">السنوات </label>

                            <div class="col-md-10">

                               <div>
                                    <asp:DropDownList class="chosen-select chosen-rtl form-control" ID="DropYear" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="DropYear_SelectedIndexChanged" runat="server" data-placeholder="الخطة السنوية">
                                        <asp:ListItem Value="0" Text="جميع السنوات" Selected="True" />

                                    </asp:DropDownList>
                                </div>



                            </div>
                        </div>
                    </div>



                    <!-- script-->



                    <div style="direction: ltr;">
                        <div align='center' style="text-align: center;">
                            <div style="direction: ltr; margin-top: 10px;">
                                <div align='center' style="text-align: center;">
                                    <div id="MainInner">

                                        <div style="color: #070707; display: inline-block; text-align: center; background-color: #FFFFFF;  margin: 25px;  padding-right: 20px; height: 355px; width: 475px; text-align: center;">

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

                                                    <div class="row" style="padding-top:60px; text-align:right;">
                                                        
                                                        <asp:HyperLink ID="HyperLink1" runat="server">
                                                            <img src="assets/icons/buttons/report.png" height="65" border="0" /></asp:HyperLink>

                                                    </div>

                                                </div>
                                                <div class="col-xs-7">
                                                    <div id="piechart2" style="text-align: center;" align='center'>

                                                        <asp:Literal ID="LtImport" runat="server"></asp:Literal>

                                                        <div id="chartImport_div"></div>
                                                    </div>
                                                </div>

                                            </div>
                                        </div>
                                        <div style="display: inline-block; text-align: center;">

                                            <br />
                                            <div align='center' style="color: #070707; background-color: #FFFFFF;  margin: 25px; height: 355px; width: 475px; text-align: center;">
                                                <h4>مستوى التنفيذ</h4>



                                                <div class="row">

                                                    <div class="col-xs-7" style="z-index: 999; font-size: 20px; margin-top:55px; color: #000;">
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
                                                    <div class="col-xs-5">
                                                        <div id="piechart" style="text-align: center;" align='center'>
                                                            <asp:Literal ID="LitStat" runat="server"></asp:Literal>

                                                            <div id="chartStat_div"></div>
                                                        </div>
                                                    </div>



                                                </div>
                                            </div>


                                        </div>
                                        <!-- risk -->


                                        <!-- end SAGIA -->
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div style="text-align: right;">
                                                    <h2 style="margin-top: 2px;">

                                                        <span runat="server" id="Span2">نتائج معالجة الملاحظات على مستوى الإدارات عليا </span>
                                                        
                                                    </h2>
                                                </div>
                                            </div>
                                        </div>
                                        <div align='center' style="text-align: center;">



                                            <!--coloum bar -->
                                            <div style="display: inline-block; text-align: center;">
                                                <div align='center' style="color: #070707; background-color: #FFFFFF; border: 1px solid #D8D8D8; margin: 25px;  height: 935px; width: 1000px; text-align: center;">
                                                    <h4>مستوى التنفيذ</h4>
                                                    <asp:UpdateProgress ID="UpdateProgress1"
                                                        AssociatedUpdatePanelID="UpdatePanel4"
                                                        runat="server">
                                                        <ProgressTemplate>
                                                            <i class="ace-icon fa fa-spinner fa-spin green bigger-125"></i>جارى التحميل...            
                                                        </ProgressTemplate>
                                                    </asp:UpdateProgress>
                                                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                        <ContentTemplate>


                                                            <asp:HiddenField ID="hidden" runat="server" Value="0" />
                                                            <asp:HiddenField ID="HiddenTitle" runat="server" />
                                                            <asp:HiddenField ID="Stat" runat="server" />

                                                            <div id="myBox" style="display: none;" class="MyBox">

                                                                <div style="margin-right: 10px; background-color: #FFFFFF" class="row">

                                                                    <div class="col-sm-1" style="text-align: right;">
                                                                        
                                                                    </div>
                                                                    <div class="col-lg-8" style="text-align: right;">
                                                                        <h4 class="align-right"><span runat="server" id="MainTitle">
                                                                            <!-- Trigger/Open The Modal -->
                                                                        </span></h4>
                                                                    </div>
                                                                    <div class="col-lg-3">
                                                                        <span id="close" class="close">
                                                                            <img src="assets/images/Icons/BasicIcon/close.png" height="46" /></button>
                                                                        </span>
                                                                    </div>

                                                                </div>



                                                                <div style="padding: 10px;">

                                                                    <table border="1"  class="color" style="width: 100%;">
                                                                        <thead class="TableHead">
                                                                            <tr>
                                                                                <th class="center">القيمة</th>
                                                                                <th class="center">مستوى الأهمية</th>
                                                                            </tr>
                                                                        </thead>
                                                                        <tbody>
                                                                            <asp:Repeater ID="RepImpData" OnItemDataBound="RepImpData_ItemDataBound" OnDisposed="RepImpData_Disposed" runat="server">
                                                                                <ItemTemplate>
                                                                                    <tr>
                                                                                        <td class="center" style="padding:10px">
                                                                                            <asp:Label ID="LblCounts" runat="server" Text='<%# Eval("Counts") %>'></asp:Label>
                                                                                            [<asp:Label ID="LblAvg" runat="server" Text=""></asp:Label>]

                                                              
                                                                                        </td>
                                                                                        <td class="center" style="padding:10px">
                                                                                            <div id="LowVal" visible="false" runat="server">
                                                                                                <img src="assets/icons/levels/L1/mid2.png" height="25" /></div>
                                                                                            <div id="MidVal" visible="false" runat="server">
                                                                                                <img src="assets/icons/levels/L1/low2.png" height="25" /></div>

                                                                                            <div id="HighVal" visible="false" runat="server">
                                                                                                <img src="assets/icons/levels/L1/high2.png" height="25" /></div>

                                                                                            <asp:Label ID="LblImp" runat="server" Visible="false" Text='<%# Eval("Importance") %>'></asp:Label></td>
                                                                                    </tr>
                                                                                </ItemTemplate>
                                                                            </asp:Repeater>
                                                                        </tbody>
                                                                    </table>
                                                                </div>
                                                                <hr style="border-top: 1px solid #070708;" />
                                                                <div class="row">
                                                                    <div class="col-xs-12">
                                                                        <div class="col-xs-2">
                                                                            <img src="assets/icons/levels/L1/mid2.png" height="20" /></div>
                                                                        <div class="col-xs-2 GreenImp-tooltip">منخفضة</div>
                                                                        <div class="col-xs-2">
                                                                            <img src="assets/icons/levels/L1/low2.png" height="20" /></div>
                                                                        <div class="col-xs-2 YellowImp-tooltip">متوسطة</div>
                                                                        <div class="col-xs-2">
                                                                            <img src="assets/icons/levels/L1/high2.png" height="20" /></div>
                                                                        <div class="col-xs-2 RedImp-tooltip">مرتفعة</div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <asp:Literal ID="lt" runat="server"></asp:Literal>
                                                            <div class="row">
                                                                <div class="col-xs-3" style="z-index: 999; font-size: 20px; margin-top: 155px; color: #000;">
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
                                                   <!-- <p>
                                                        
                                                        <asp:ImageButton  ID="SectionCharts" BackColor="#e6e6e6" ImageUrl="assets/icons/buttons/risk.png" width="160" height="60" runat="server" />
                                                       
                                                    </p> -->

                                                    <div class="row">

                                                        <div class="col-sm-12" style="text-align: center!important; direction: ltr; margin-top: 35px;">
                                                            <table class="color" style="width: 100%">

                                                                <tr>
                                                                    <asp:Repeater ID="EmployeesDataYears" runat="server">
                                                                        <HeaderTemplate>
                                                                            <th class="center thcolor" style="background-color: #93cdf3">الإجمالى</th>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <th class="center thcolor">

                                                                                <%-- <i style="display: <%#(Container.ItemIndex+1)<=3?";":"none;"%>'" title=' <%# string.Concat(Eval("Done"),"%") %>' class="menu-icon fa fa-arrow-up green"></i>
                                                                                --%>
                                                                                <div>
                                                                                    <asp:Label ID="Label1" ToolTip='<%# string.Concat(Eval("Done"),"% [" ,Eval("Status3")," ] ") %>' runat="server" Text='<%# Eval("SectionName") %>'></asp:Label>
                                                                                </div>

                                                                            </th>

                                                                        </ItemTemplate>

                                                                    </asp:Repeater>

                                                                    <th class="center thcolor">&nbsp;</th>

                                                                </tr>

                                                                <tr>

                                                                    <asp:Repeater ID="RepTotalsYears" runat="server">
                                                                        <ItemTemplate>
                                                                            <td class="center thover" style="margin: 0; width: 15px; padding: 0;">
                                                                                <div class="tdcolor">
                                                                                    <asp:Label ID="Label5" runat="server" Text='<%# Eval("TotalNotDone") %>'></asp:Label>
                                                                                </div>


                                                                                <div class="tdcolor">
                                                                                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("TotalSemiDone") %>'></asp:Label>
                                                                                </div>
                                                                                <div class="tdcolor">
                                                                                    <asp:Label ID="Label6" runat="server" Text='<%# Eval("TotalNotNow") %>'></asp:Label>
                                                                                </div>
                                                                                <div class="tdcolor">

                                                                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("TotalDone") %>'></asp:Label>
                                                                                </div>

                                                                                <div class="tdcolor">
                                                                                    <asp:Label ID="Label7" runat="server" Text='<%# Eval("TotalClosed") %>'></asp:Label>
                                                                                </div>



                                                                                <div class="tdcolor">
                                                                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("Total") %>'></asp:Label>
                                                                                </div>
                                                                            </td>
                                                                        </ItemTemplate>
                                                                    </asp:Repeater>

                                                                    <asp:Repeater ID="Repeater2Years" runat="server">

                                                                        <ItemTemplate>
                                                                            <td class="center thover" style="white-space: nowrap; margin: 0; padding: 0; width: 20px;">

                                                                                <asp:Label ID="Label1" Style="display: none" runat="server" Text='<%# Eval("SectionName") %>'></asp:Label>
                                                                                <div class="tdcolor">
                                                                                    <asp:HyperLink ID="LinkButton1" Text='<%# Eval("Status1") %>' NavigateUrl='<%#"ReportingAdmSections.aspx?E=1&ReqYR="+Request.QueryString["Reqq"]+"&Reqq="+ Eval("RepSection").ToString() %>' runat="server"></asp:HyperLink>                                                                                   </div>
                                                                                <div class="tdcolor">
                                                                                <asp:HyperLink ID="HyperLink1" Text='<%# Eval("Status2") %>' NavigateUrl='<%#"ReportingAdmSections.aspx?E=2&ReqYR="+Request.QueryString["Reqq"]+"&Reqq="+ Eval("RepSection").ToString() %>' runat="server"></asp:HyperLink> </div>
                                                                                <div class="tdcolor">
                                                                                <asp:HyperLink ID="HyperLink2" Text='<%# Eval("Status4") %>' NavigateUrl='<%#"ReportingAdmSections.aspx?E=4&ReqYR="+Request.QueryString["Reqq"]+"&Reqq="+ Eval("RepSection").ToString() %>' runat="server"></asp:HyperLink>  </div>
                                                                                <div class="tdcolor ">
                                                                               <asp:HyperLink ID="HyperLink3" Text='<%# Eval("Status3") %>' NavigateUrl='<%#"ReportingAdmSections.aspx?E=3&ReqYR="+Request.QueryString["Reqq"]+"&Reqq="+ Eval("RepSection").ToString() %>' runat="server"></asp:HyperLink>   </div>

                                                                                <div class="tdcolor">
                                                                              <asp:HyperLink ID="HyperLink4" Text='<%# Eval("Status5") %>' NavigateUrl='<%#"ReportingAdmSections.aspx?E=5&ReqYR="+Request.QueryString["Reqq"]+"&Reqq="+ Eval("RepSection").ToString() %>' runat="server"></asp:HyperLink>  </div>

                                                                                <div class="tdcolor">
                                                                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("TotalCount") %>'></asp:Label>

                                                                                </div>
                                                                            </td>

                                                                            


                                                                        </ItemTemplate>


                                                                    </asp:Repeater>
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




                                                                </tr>



                                                            </table>
                                                        </div>

                                                    </div>
                                                </div>
                                            </div>
                                            <!--End coloum bar -->


                                        </div>

                                        <div class="row">
                                            <div class="col-md-12">
                                                <div style="text-align: right;">
                                                    <h2 style="margin-top: 2px;">

                                                        <span runat="server" id="Span3">نتائج معالجة الملاحظات على مستوى الادارات‎ </span>
                                                        
                                                    </h2>
                                                </div>
                                            </div>
                                        </div>
                                        <!--Admin -->
                                        <div align='center' style="text-align: center;">



                                            <!--coloum bar -->
                                            <div style="display: inline-block; text-align: center;">
                                                <div align='center' style="color: #070707; background-color: #FFFFFF; border: 1px solid #D8D8D8; margin: 25px;  height: 935px; width: 1000px; text-align: center;">
                                                    <h4>مستوى التنفيذ على مستوىالإدارات المتوسطة</h4>
                                                    <asp:UpdateProgress ID="UpdateProgress2"
                                                        AssociatedUpdatePanelID="UpdatePanel4"
                                                        runat="server">
                                                        <ProgressTemplate>
                                                            <i class="ace-icon fa fa-spinner fa-spin green bigger-125"></i>جارى التحميل...            
                                                        </ProgressTemplate>
                                                    </asp:UpdateProgress>
                                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                        <ContentTemplate>


                                                            <asp:HiddenField ID="hiddenAdm" runat="server" Value="0" />
                                                            <asp:HiddenField ID="HiddenTitleAdm" runat="server" />
                                                            <asp:HiddenField ID="StatAdm" runat="server" />

                                                            <div id="myBoxAdm" style="display: none;" class="MyBox">
                                                                <div style="margin-right: 10px; background-color: #FFFFFF" class="row">

                                                                    <div class="col-sm-1" style="text-align: right;">
                                                                        
                                                                    </div>
                                                                    <div class="col-lg-8" style="text-align: right;">
                                                                        <h4 class="align-right"><span runat="server" id="MainTitleAdm">
                                                                            <!-- Trigger/Open The Modal -->
                                                                        </span></h4>
                                                                    </div>
                                                                    <div class="col-lg-3">
                                                                        <span id="closeAdm" class="close">
                                                                            <img src="assets/images/Icons/BasicIcon/close.png" height="46" /></button>
                                                                        </span>
                                                                    </div>

                                                                </div>


                                                                <div style="padding: 10px;">

                                                                    <table border="1" class="color" style="width: 100%;">
                                                                        <thead class="TableHead">
                                                                            <tr>
                                                                                <th class="center">القيمة</th>
                                                                                <th class="center">مستوى الأهمية</th>
                                                                            </tr>
                                                                        </thead>
                                                                        <tbody>
                                                                            <asp:Repeater ID="RepImpDataAdm" OnItemDataBound="RepImpDataAdm_ItemDataBound" OnDisposed="RepImpDataAdm_Disposed" runat="server">
                                                                                <ItemTemplate>
                                                                                    <tr>
                                                                                        <td class="center" style="padding:10px">
                                                                                            <asp:Label ID="LblCountsAdm" runat="server" Text='<%# Eval("Counts") %>'></asp:Label>
                                                                                            [<asp:Label ID="LblAvgAdm" runat="server" Text=""></asp:Label>]

                                                              
                                                                                        </td>
                                                                                        <td class="center" style="padding:10px">
                                                                                            <div id="LowValAdm" visible="false" runat="server"><img src="assets/icons/levels/L1/mid2.png" height="25" /></div>
                                                                                            <div id="MidValAdm"  visible="false" runat="server"><img src="assets/icons/levels/L1/low2.png" height="25" /></div>

                                                                                            <div id="HighValAdm" visible="false" runat="server"><img src="assets/icons/levels/L1/high2.png" height="25" /></div>

                                                                                            <asp:Label ID="LblImpAdm" runat="server" Visible="false" Text='<%# Eval("Importance") %>'></asp:Label></td>
                                                                                    </tr>
                                                                                </ItemTemplate>
                                                                            </asp:Repeater>
                                                                        </tbody>
                                                                    </table>
                                                                </div>
                                                                <hr style="border-top: 1px solid #070708;" />
                                                                <div class="row">
                                                                    <div class="col-xs-12">
                                                                        <div class="col-xs-2">
                                                                            <img src="assets/icons/levels/L1/mid2.png" height="20" /></div>
                                                                        <div class="col-xs-2 GreenImp-tooltip">منخفضة</div>
                                                                        <div class="col-xs-2">
                                                                            <img src="assets/icons/levels/L1/low2.png" height="20" /></div>
                                                                        <div class="col-xs-2 YellowImp-tooltip">متوسطة</div>
                                                                        <div class="col-xs-2">
                                                                            <img src="assets/icons/levels/L1/high2.png" height="20" /></div>
                                                                        <div class="col-xs-2 RedImp-tooltip">مرتفعة</div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <asp:Literal ID="ltAdm" runat="server"></asp:Literal>
                                                            <div class="row">
                                                                <div class="col-xs-3" style="z-index: 999; font-size: 20px; margin-top: 155px; color: #000;">
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
                                                                    <div id="chartAdm_div"></div>
                                                                </div>
                                                            </div>




                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                  <!--  <p>
                                                            <asp:ImageButton  ID="AdminCharts" BackColor="#e6e6e6" ImageUrl="assets/icons/buttons/risk.png" width="160" height="60" runat="server" />
                                                  
                                                    </p> -->

                                                    <div class="row">

                                                        <div class="col-sm-12" style="text-align: center!important; direction: ltr; margin-top: 35px;">
                                                            <table class="color" style="width: 100%">

                                                                <tr>
                                                                    <asp:Repeater ID="EmployeesData" runat="server">
                                                                        <HeaderTemplate>
                                                                            <th class="center thcolor" style="background-color: #93cdf3;">الإجمالى</th>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <th style="font-family: 'Lato',Arial;" class="thcolor">

                                                                                <%-- <i style="display: <%#(Container.ItemIndex+1)<=3?";":"none;"%>'" title=' <%# string.Concat(Eval("Done"),"%") %>' class="menu-icon fa fa-arrow-up green"></i>
                                                                                --%>

                                                                                <asp:Label ID="Label1" ToolTip='<%# string.Concat(Eval("Done"),"% [" ,Eval("Status3")," ] ") %>' runat="server" Text='<%# Eval("AdmName") %>'></asp:Label>


                                                                            </th>

                                                                        </ItemTemplate>

                                                                    </asp:Repeater>

                                                                    <th class="center thcolor">&nbsp;</th>

                                                                </tr>

                                                                <tr>

                                                                    <asp:Repeater ID="RepTotals" runat="server">
                                                                        <ItemTemplate>
                                                                            <td class="center thover" style="margin: 0; width: 15px; padding: 0;">
                                                                                <div class="tdcolor">
                                                                                    <asp:Label ID="Label5" runat="server" Text='<%# Eval("TotalNotDone") %>'></asp:Label>
                                                                                </div>
                                                                                <div class="tdcolor">
                                                                                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("TotalSemiDone") %>'></asp:Label>
                                                                                </div>
                                                                                <div class="tdcolor">
                                                                                    <asp:Label ID="Label6" runat="server" Text='<%# Eval("TotalNotNow") %>'></asp:Label>
                                                                                </div>

                                                                                <div class="tdcolor">

                                                                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("TotalDone") %>'></asp:Label>
                                                                                </div>





                                                                                <div class="tdcolor">
                                                                                    <asp:Label ID="Label7" runat="server" Text='<%# Eval("TotalClosed") %>'></asp:Label>
                                                                                </div>

                                                                                <div class="tdcolor">
                                                                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("Total") %>'></asp:Label>
                                                                                </div>
                                                                            </td>
                                                                        </ItemTemplate>
                                                                    </asp:Repeater>

                                                                    <asp:Repeater ID="Repeater2" runat="server">

                                                                        <ItemTemplate>


                                                                            <td class="center thover" style="white-space: nowrap; margin: 0; padding: 0; width: 20px;">

                                                                                <asp:Label ID="Label1" Style="display: none" runat="server" Text='<%# Eval("RepAdms") %>'></asp:Label>
                                                                                <div class="tdcolor">
                                                                                    <asp:HyperLink ID="LinkButton1" Text='<%# Eval("Status1") %>' NavigateUrl='<%#"ReportAdmAllMang.aspx?S="+Eval("Section")+"&E=1&YQ="+Request.QueryString["Reqq"]+"&Reqq="+ Eval("RepAdms").ToString() %>' runat="server"></asp:HyperLink>                                                                                   </div>
                                                                                <div class="tdcolor">
                                                                                <asp:HyperLink ID="HyperLink1" Text='<%# Eval("Status2") %>' NavigateUrl='<%#"ReportAdmAllMang.aspx?S="+Eval("Section")+"&E=2&YQ="+Request.QueryString["Reqq"]+"&Reqq="+ Eval("RepAdms").ToString() %>' runat="server"></asp:HyperLink> </div>
                                                                                <div class="tdcolor">
                                                                                <asp:HyperLink ID="HyperLink2" Text='<%# Eval("Status4") %>' NavigateUrl='<%#"ReportAdmAllMang.aspx?S="+Eval("Section")+"&E=4&YQ="+Request.QueryString["Reqq"]+"&Reqq="+ Eval("RepAdms").ToString() %>' runat="server"></asp:HyperLink>  </div>
                                                                                <div class="tdcolor ">
                                                                               <asp:HyperLink ID="HyperLink3" Text='<%# Eval("Status3") %>' NavigateUrl='<%#"ReportAdmAllMang.aspx?S="+Eval("Section")+"&E=3&YQ="+Request.QueryString["Reqq"]+"&Reqq="+ Eval("RepAdms").ToString() %>' runat="server"></asp:HyperLink>   </div>

                                                                                <div class="tdcolor">
                                                                              <asp:HyperLink ID="HyperLink4" Text='<%# Eval("Status5") %>' NavigateUrl='<%#"ReportAdmAllMang.aspx?S="+Eval("Section")+"&E=5&YQ="+Request.QueryString["Reqq"]+"&Reqq="+ Eval("RepAdms").ToString() %>' runat="server"></asp:HyperLink>  </div>

                                                                             
                                                                                <div class="tdcolor">
                                                                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("TotalCount") %>'></asp:Label>

                                                                                </div>
                                                                            </td>


                                                                        </ItemTemplate>


                                                                    </asp:Repeater>
                                                                    <td class="thover" style="white-space: nowrap; margin: 0; direction: rtl; padding: 0; width: 15%; background-color: #FFFFFF;">
                                                                        <div class="row tdcolor" style="margin: 0">
                                                                            <div class="col-xs-3" style="color: #9C27B0;">
                                                                                <img src="assets/icons/levels/L2/hold2.png" height="20" />
                                                                            </div>
                                                                            <div class="col-xs-9" style="text-align: right">
                                                                                <span data-toggle="tooltip" data-placement="bottom" class="red-tooltip" title="لم يتم معالجة الملاحظة وفقا للتاريخ المحدد من قبل الإدارة متوسطة" >متأخرة</span>
                                                                            </div>
                                                                        </div>
                                                                        <div class="row tdcolor" style="margin: 0">
                                                                            <div class="col-xs-3" style="color: #FF9800;">
                                                                                <img src="assets/icons/levels/L2/under2.png" height="20" />
                                                                            </div>
                                                                            <div class="col-xs-9" style="text-align: right"><span data-toggle="tooltip" data-placement="bottom" class="yellow-tooltip" title="تم معالجة جزء من توصيات الملاحظة" >جارى التنفيذ</span></div>
                                                                        </div>
                                                                        <div class="row tdcolor" style="margin: 0">
                                                                            <div class="col-xs-3" style="color: #727aa2;">
                                                                                <img src="assets/icons/levels/L2/notstart2.png" height="20" />
                                                                            </div>
                                                                            <div class="col-xs-9" style="text-align: right">
                                                                                <span data-toggle="tooltip" data-placement="bottom" class="blue-tooltip" title="لم يحن تاريخ معالجة التوصية / الملاحظة" >لم يحن وقت تنفيذها</span>
                                                                            </div>
                                                                        </div>
                                                                        <div class="row tdcolor" style="margin: 0">
                                                                            <div class="col-xs-3" style="color: #4CAF50;">
                                                                                <img src="assets/icons/levels/L2/solved2.png" height="20" />
                                                                            </div>
                                                                            <div class="col-xs-9" style="text-align: right"><span data-toggle="tooltip" data-placement="bottom" class="green-tooltip" title="تم معالجة جميع التوصيات" >المعالجة</span></div>
                                                                        </div>


                                                                        <div class="row tdcolor" style="margin: 0">
                                                                            <div class="col-xs-3" style="color: #93cdf3;">
                                                                                <img src="assets/icons/levels/L2/closed2.png" height="20" />
                                                                            </div>
                                                                            <div class="col-xs-9" style="text-align: right">
                                                                                <span data-toggle="tooltip" data-placement="bottom" class="grey-tooltip" title="مكررة / غير قابلة للتطبيق" >مغلقة</span>
                                                                            </div>
                                                                        </div>

                                                                        <div class="row tdcolor" style="margin: 0; background-color: #93cdf3;">
                                                                            <div class="col-xs-3">&nbsp;</div>
                                                                            <div class="col-xs-9" style="text-align: right;">
                                                                                إجمالى الملاحظات
                                                                            </div>
                                                                        </div>
                                                                    </td>




                                                                </tr>



                                                            </table>
                                                        </div>

                                                    </div>
                                                </div>
                                            </div>
                                            <!--End coloum bar -->


                                        </div>
                                    </div>





                                </div>
                            </div>
                        </div>
                    </div>

                </div>




            </ContentTemplate>


        </asp:UpdatePanel>

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

        function Hidden(Stat, val, Tit) {

            document.getElementById('<%=hidden.ClientID %>').value = val;
            document.getElementById('<%=HiddenTitle.ClientID %>').value = Tit;
            document.getElementById('<%=Stat.ClientID %>').value = Stat;
            __doPostBack();
        }
        function HiddenAdm(Stat, val, Tit) {

            document.getElementById('<%=hiddenAdm.ClientID %>').value = val;
            document.getElementById('<%=HiddenTitleAdm.ClientID %>').value = Tit;
            document.getElementById('<%=StatAdm.ClientID %>').value = Stat;
            __doPostBack();
        }

        var span = document.getElementById("close");

        span.onclick = function () {
            document.getElementById('myBox').style.display = "none";
            document.getElementById('<%=hidden.ClientID %>').value = 0;
        }

        var spanAdm = document.getElementById("closeAdm");

        spanAdm.onclick = function () {
            document.getElementById('myBoxAdm').style.display = "none";
            document.getElementById('<%=hiddenAdm.ClientID %>').value = 0;
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

            $('[data-toggle="tooltip"]').tooltip();

             $('.YellowImp-tooltip').tooltip({ placement: 'bottom', title: '<p> متوسطة: - هنالك خلل في الضوابط الرقابية وإدارة متوسطة الأهمية ويتطلب تدخل الإدارة متوسطة في معالجته على المدى القصير، حيث ان حجم الأهمية هنا قد تؤدي إلى:</p> <ul><li>خسائر مالية متوسطة.</li><li>مخاطر في الضوابط الرقابية.</li><li>مخاطر متوسطة على السمعة.</li><li>اثار سلبية تأثر على المستوى التنظيمي.</li></ul>', html: true });
                $('.GreenImp-tooltip').tooltip({ placement: 'bottom', title: '<p> منخفضة: - هنالك خلل بسيط في الضوابط الرقابية وإدارة متوسطة الأهمية ولا تتطلب التدخل الفوري من قبل الادارة، حيث ان الاثار السلبية منخفضة.</p>', html: true });
                $('.RedImp-tooltip').tooltip({ placement: 'bottom', title: '<p>مرتفعة: - هنالك خلل في الضوابط الرقابية وإدارة متوسطة الأهمية، وتتطلب اهتمام الإدارة متوسطة الفوري، حيث ان حجم الأهمية كبير جداً وقد يؤدي الى:</p><ul><li>خسائر مالية كبيرة.</li><li>مخاطر استراتيجية.</li><li>مخاطر كبيرة على السمعة.</li>  </ul>', html: true });


            if (document.getElementById('<%=hidden.ClientID %>').value != "0") {

                document.getElementById('myBox').style.display = 'block';


            }

            if (document.getElementById('<%=hiddenAdm.ClientID %>').value != "0") {

                document.getElementById('myBoxAdm').style.display = 'block';


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

