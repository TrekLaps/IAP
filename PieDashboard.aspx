<%@ Page Title="نتائج معالجة ملاحظات الإدارة العليا " Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PieDashboard.aspx.cs" Inherits="PieDashboard" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>



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
<script src="https://www.gstatic.com/charts/loader.js"></script>
    <style>
        .panel-group .panel {
            border-radius: 0;
            box-shadow: none;
            border: 0;
        }

        .panel-default > .panel-heading {
            color: #333;
            border-color: #ddd;
        }

        .panel-group .panel + .panel {
            margin-top: 0;
        }

        .panel-body {
            padding: 15px 20px;
        }

            .panel-body .search-label p {
                margin-bottom: 15px;
                font-size: 14px;
                color: #000000;
            }

            .panel-body .search-value span {
                margin-bottom: 15px;
                display: block;
                font-size: 14px;
                font-weight: 100;
                color: #000000;
            }

                .panel-body .search-value span.address {
                    margin-bottom: 0px;
                }

        .panel-default > .panel-heading {
            padding: 0;
            border-radius: 5px;
            margin-top: 2px;
        }



        .panel-title > a {
            height: 50px;
            display: block;
            padding: 17px 20px 0;
            text-decoration: none;
            text-transform: uppercase;
            font-size: 14px;
            font-family: Verdana, Geneva, Tahoma, sans-serif;
            font-weight: bold;
            text-align: right;
        }

        .more-less {
            float: left;
        }

        body {
            background-color: #f6f6f6;
        }
    </style>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="PageTitle" runat="Server">
نتائج معالجة ملاحظات الإدارة العليا </asp:Content>

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
                    <div runat="server" id="MainsAll">
                        <div class="row">

                            <div class="form-group">
                                <label class="col-sm-10 control-label" for="form-field-1">الإدارة العليا </label>

                                <div class="col-sm-5">


                                   <div>
                                        <asp:DropDownList CssClass="chosen-select chosen-rtl form-control"  ID="Admins" AutoPostBack="true" OnSelectedIndexChanged="Admins_SelectedIndexChanged" runat="server" data-placeholder="الإدارات عليا">
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                <div class="col-sm-5" runat="server" style="display: none;" id="PrevAll">
                                    <a class="btn btn-default openall" href="#">اعرض جميع السنوات</a> <a class="btn btn-default closeall" href="#">أغلق جميع السنوات</a>
                                </div>
                            </div>
                        </div>
                        <div class="alert alert-info" runat="server" id="NoRep" visible="false">
                                                                لايوجد ملاحظات مسجلة
                                                            </div>
                        <div runat="server" style="overflow-x: scroll; display: none; max-width: 1075px" id="PrntView">

                            <div id="dvContents">

                                <div class="row">
                                    <div class="col-xs-12">
                                        <h3 class="header smaller lighter blue">نتائج معالجة ملاحظات إدارة متوسطة المراجعة الداخلية لجميع الادارات حسب الإدارة العليا</h3>


                                        <div class="container">
                                            <div class="panel-group" id="accordion">

                                                <div class="panel panel-default">
                                                    <div class="panel-heading">
                                                        <h4 class="panel-title">
                                                            <a data-toggle="collapse" data-parent="#accordion" href="#collapse1">
                                                                <i class="more-less glyphicon glyphicon-chevron-up"></i>
                                                                كل السنوات</a>
                                                        </h4>
                                                    </div>
                                                    <div id="collapse1" class="panel-collapse collapse in">
                                                        <div class="panel-body">
                                                            

                                                            <div class="row">
                                                                <div class="col-sm-1">&nbsp;</div>
                                                                <div class="col-sm-10" style="text-align: center !important;">
                                                                    <table style="width: 100%;">
                                                                        <tr>
                                                                            <td style="float: left;">
                                                                                <asp:Chart ID="Chart4" EnableViewState="true" runat="server" Width="450px" BackColor="White">
                                                                                    <Titles>
                                                                                        <asp:Title
                                                                                            Text="مستوى التنفيذ"
                                                                                            ForeColor="LightGray"
                                                                                            Docking="Top"
                                                                                            Alignment="TopRight"
                                                                                            Font="Comic Sans MS, 14pt, style=Bold">
                                                                                        </asp:Title>
                                                                                    </Titles>
                                                                                    <Series>
                                                                                        <asp:Series Palette="Light" ChartType="Pie" Name="Series1"></asp:Series>
                                                                                    </Series>
                                                                                    <ChartAreas>
                                                                                        <asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64"
                                                                                            BorderDashStyle="Solid" BackColor="WhiteSmoke"
                                                                                            ShadowColor="Transparent" BackGradientStyle="DiagonalLeft">


                                                                                            <Area3DStyle Rotation="3" Inclination="45" IsRightAngleAxes="false" Enable3D="true" IsClustered="true" WallWidth="0" PointDepth="250" LightStyle="Realistic" />

                                                                                            <AxisX IsReversed="true" IsMarginVisible="true">
                                                                                                <MajorGrid
                                                                                                    Enabled="false" />
                                                                                                <LabelStyle TruncatedLabels="false" />
                                                                                                <MajorTickMark Size="15" LineWidth="2" LineColor="White" LineDashStyle="DashDot" />
                                                                                            </AxisX>
                                                                                            <AxisY>
                                                                                                <MajorGrid
                                                                                                    Enabled="false"
                                                                                                    LineColor="White" />
                                                                                                <MajorTickMark Size="5" LineWidth="2" LineColor="White" LineDashStyle="DashDot" />
                                                                                            </AxisY>




                                                                                        </asp:ChartArea>

                                                                                    </ChartAreas>
                                                                                    <Legends>
                                                                                        <asp:Legend Name="MobileBrands" IsDockedInsideChartArea="false" Docking="Top" Alignment="Far" Title="" TableStyle="Wide" BorderDashStyle="Dash" BorderColor="LightGray" TitleSeparator="Line" TitleFont="TimesNewRoman" TitleSeparatorColor="#e8eaf1">
                                                                                        </asp:Legend>


                                                                                        <%--Legends denotes the representing color for each brands--%>
                                                                                        <%--It will automatically takes the names from the series names and it's associated colors or you can give legend text in series--%>
                                                                                    </Legends>
                                                                                </asp:Chart>

                                                                            </td>
                                                                            <td style="width: 100px;">&nbsp;</td>

                                                                            <td style="float: right;">
                                                                                <asp:Chart ID="Chart3" EnableViewState="true" runat="server" Width="450px" BackColor="White">
                                                                                    <Titles>
                                                                                        <asp:Title
                                                                                            Text=" مستوى الأهمية"
                                                                                            ForeColor="LightGray"
                                                                                            Docking="Top"
                                                                                            Alignment="TopRight"
                                                                                            Font="Comic Sans MS, 14pt, style=Bold">
                                                                                        </asp:Title>
                                                                                    </Titles>
                                                                                    <Series>
                                                                                        <asp:Series Palette="Light" ChartType="Pie" Name="Series1"></asp:Series>
                                                                                    </Series>
                                                                                    <ChartAreas>
                                                                                        <asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64"
                                                                                            BorderDashStyle="Solid" BackColor="WhiteSmoke"
                                                                                            ShadowColor="Transparent" BackGradientStyle="DiagonalLeft">


                                                                                            <Area3DStyle Rotation="3" Inclination="45" IsRightAngleAxes="false" Enable3D="true" IsClustered="true" WallWidth="0" PointDepth="250" LightStyle="Realistic" />

                                                                                            <AxisX IsReversed="true" IsMarginVisible="true">
                                                                                                <MajorGrid
                                                                                                    Enabled="false" />
                                                                                                <MajorTickMark Size="15" LineWidth="2" LineColor="White" LineDashStyle="DashDot" />
                                                                                            </AxisX>
                                                                                            <AxisY>
                                                                                                <MajorGrid
                                                                                                    Enabled="false"
                                                                                                    LineColor="White" />
                                                                                                <MajorTickMark Size="5" LineWidth="2" LineColor="White" LineDashStyle="DashDot" />
                                                                                            </AxisY>




                                                                                        </asp:ChartArea>

                                                                                    </ChartAreas>
                                                                                    <Legends>
                                                                                        <asp:Legend Name="MobileBrands" Docking="Top" Alignment="Far" Title="" TableStyle="Wide" BorderDashStyle="Dash" BorderColor="LightGray" TitleSeparator="Line" TitleFont="TimesNewRoman" TitleSeparatorColor="#e8eaf1">
                                                                                        </asp:Legend>


                                                                                        <%--Legends denotes the representing color for each brands--%>
                                                                                        <%--It will automatically takes the names from the series names and it's associated colors or you can give legend text in series--%>
                                                                                    </Legends>

                                                                                </asp:Chart>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </div>
                                                                <div class="col-sm-1">&nbsp;</div>
                                                            </div>


                                                            <div class="row">


                                                                <div class="col-sm-1">
                                                                    &nbsp;
                                                                </div>
                                                                <div class="row">
                                                                    <div class="col-sm-1">&nbsp;</div>
                                                                    <div class="col-sm-10" style="text-align: center;">
                                                                        <table style="width: 100%">
                                                                            <tr>

                                                                                <td class="center" style="vertical-align: middle;">
                                                                                    <table style="width: 100%">
                                                                                        <tr>
                                                                                            <td>
                                                                                                <asp:Button ID="BtnAdminAll" OnClick="BtnAdminAll_Click" CssClass="btn btn-danger" runat="server" Text="مستوى الأهمية" />
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>

                                                                                </td>
                                                                                <td>
                                                                                    <asp:Chart ID="Chart1" OnClick="Chart1_Click" EnableViewState="true" runat="server" RightToLeft="Yes" Width="800px" Height="500px" ToolTip="نتائج معالجة ملاحظات إدارة متوسطة المراجعة الداخلية لجميع الادارات">
                                                                                        <Legends>
                                                                                            <asp:Legend Alignment="Far" Name="MobileBrands" Docking="Top" Title="" TableStyle="Wide" BorderDashStyle="Dash" BorderColor="LightGray" TitleSeparator="Line" TitleFont="TimesNewRoman" TitleSeparatorColor="#e8eaf1">
                                                                                            </asp:Legend>


                                                                                            <%--Legends denotes the representing color for each brands--%>
                                                                                            <%--It will automatically takes the names from the series names and it's associated colors or you can give legend text in series--%>
                                                                                        </Legends>
                                                                                        <Titles>
                                                                                            <asp:Title
                                                                                                Text="مستوى التنفيذ حسبالإدارات المتوسطة"
                                                                                                ForeColor="LightGray"
                                                                                                Docking="Top"
                                                                                                Alignment="TopLeft"
                                                                                                Font="Comic Sans MS, 14pt, style=Bold">
                                                                                            </asp:Title>
                                                                                        </Titles>
                                                                                        <Series>
                                                                                            <asp:Series  Name="Done" ChartType="StackedColumn" IsVisibleInLegend="false" Color="LightGreen" LabelForeColor="Black"></asp:Series>

                                                                                            <asp:Series  Name="SimyDone" ChartType="StackedColumn" IsVisibleInLegend="false" LabelForeColor="Black" Color="#e7ea56"></asp:Series>
                                                                                            <asp:Series  Name="NotDone" ChartType="StackedColumn" IsVisibleInLegend="false" LabelForeColor="Black" Color="DarkRed"></asp:Series>
                                                                                            <asp:Series  Name="NotNow" ChartType="StackedColumn" IsVisibleInLegend="false" Color="#5b9092" LabelForeColor="Black"></asp:Series>
                                                                                            <asp:Series  Name="Closed" ChartType="StackedColumn" IsVisibleInLegend="false" Color="#cccccc" LabelForeColor="Black"></asp:Series>


                                                                                            <%--Name- you can change the product name here such as type, type2--%>
                                                                                            <%--IsValueShownAsLabel- you can enable the count to show on each columns and each series--%>
                                                                                            <%--Each series represents each colour in a column--%>
                                                                                        </Series>

                                                                                        <ChartAreas>
                                                                                            <asp:ChartArea Name="ChartArea1"
                                                                                                BackColor="WhiteSmoke"
                                                                                                ShadowColor="Transparent" BackGradientStyle="DiagonalLeft">
                                                                                                <Area3DStyle Enable3D="true" IsClustered="true" WallWidth="0" PointDepth="50" LightStyle="Realistic" />
                                                                                                <AxisX IsMarginVisible="true">
                                                                                                    <MajorGrid
                                                                                                        Enabled="false" />
                                                                                                    <MajorTickMark LineDashStyle="DashDot" />
                                                                                                </AxisX>
                                                                                                <AxisY>

                                                                                                    <MajorGrid
                                                                                                        Enabled="false"
                                                                                                        LineColor="White" />
                                                                                                    <MajorTickMark LineDashStyle="DashDot" />
                                                                                                </AxisY>




                                                                                            </asp:ChartArea>

                                                                                        </ChartAreas>
                                                                                    </asp:Chart>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </div>
                                                                    <div class="col-sm-1">&nbsp;</div>

                                                                </div>
                                                                <div class="row">
                                                                    <div class="col-sm-2">&nbsp;</div>
                                                                    <div class="col-sm-8" style="text-align: center;">
                                                                        <table id="dynamic-table" style="width: 80%; font-size: 12px; font-family: Verdana, Geneva, Tahoma, sans-serif" class="table table-striped table-bordered ">

                                                                            <tr>
                                                                                <asp:Repeater ID="EmployeesData" runat="server">
                                                                                    <HeaderTemplate>
                                                                                        <th>&nbsp;</th>
                                                                                    </HeaderTemplate>
                                                                                    <ItemTemplate>
                                                                                        <th class="center" style="width: 35px; background-color: whitesmoke">

                                                                                            <%-- <i style="display: <%#(Container.ItemIndex+1)<=3?";":"none;"%>'" title=' <%# string.Concat(Eval("Done"),"%") %>' class="menu-icon fa fa-arrow-up green"></i>
                                                                                            --%>
                                                                                            <div>
                                                                                                <asp:Label ID="Label1" ToolTip=' <%# string.Concat(Eval("Done"),"% [" ,Eval("Status3")," ] ") %>' runat="server" Text='<%# Eval("AdmName") %>'></asp:Label>
                                                                                            </div>

                                                                                        </th>

                                                                                    </ItemTemplate>

                                                                                </asp:Repeater>

                                                                                <th style="width: 15px;" class="center">الإجمالى</th>

                                                                            </tr>

                                                                            <tr>



                                                                                <asp:Repeater ID="Repeater2" runat="server">
                                                                                    <HeaderTemplate>
                                                                                        
                                                                                        <th style="white-space: nowrap; margin: 0; direction: rtl; padding: 0; width: 20%;" class="thover">

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
                                                                    </th>
                                                                                    </HeaderTemplate>
                                                                                    <ItemTemplate>


                                                                                        <th class="center" style="white-space: nowrap; margin: 0; padding: 0; background-color: whitesmoke; width: 20px;">

                                                                                            <asp:Label ID="Label1" Style="display: none" runat="server" Text='<%# Eval("RepAdms") %>'></asp:Label>
                                                                                            <div style="background-color: #ffffff">
                                                                                                <asp:Label ID="Label3" runat="server" Text='<%# Eval("Status3") %>'></asp:Label>
                                                                                            </div>
                                                                                            <div>
                                                                                                <asp:Label ID="Label4" runat="server" Text='<%# Eval("Status2") %>'></asp:Label>
                                                                                            </div>

                                                                                            <div style="background-color: #ffffff">
                                                                                                <asp:Label ID="Label5" runat="server" Text='<%# Eval("Status1") %>'></asp:Label>
                                                                                            </div>

                                                                                            <div>
                                                                                                <asp:Label ID="Label6" runat="server" Text='<%# Eval("Status4") %>'></asp:Label>
                                                                                            </div>
                                                                                            <div style="background-color: #ffffff">
                                                                                                <asp:Label ID="Label7" runat="server" Text='<%# Eval("Status5") %>'></asp:Label>
                                                                                            </div>
                                                                                            <div>
                                                                                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("TotalCount") %>'></asp:Label>

                                                                                            </div>
                                                                                        </th>


                                                                                    </ItemTemplate>


                                                                                </asp:Repeater>


                                                                                <asp:Repeater ID="RepTotals" runat="server">
                                                                                    <ItemTemplate>
                                                                                        <th class="center" style="margin: 0; width: 15px; padding: 0; background-color: whitesmoke;">

                                                                                            <div style="background: #ffffff">

                                                                                                <asp:Label ID="Label3" runat="server" Text='<%# Eval("TotalDone") %>'></asp:Label>
                                                                                            </div>

                                                                                            <div>
                                                                                                <asp:Label ID="Label4" runat="server" Text='<%# Eval("TotalSemiDone") %>'></asp:Label>
                                                                                            </div>

                                                                                            <div style="background: #ffffff">
                                                                                                <asp:Label ID="Label5" runat="server" Text='<%# Eval("TotalNotDone") %>'></asp:Label>
                                                                                            </div>
                                                                                            <div>
                                                                                                <asp:Label ID="Label6" runat="server" Text='<%# Eval("TotalNotNow") %>'></asp:Label>
                                                                                            </div>

                                                                                            <div style="background: #ffffff">
                                                                                                <asp:Label ID="Label7" runat="server" Text='<%# Eval("TotalClosed") %>'></asp:Label>
                                                                                            </div>

                                                                                            <div>
                                                                                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("Total") %>'></asp:Label>
                                                                                            </div>
                                                                                        </th>
                                                                                    </ItemTemplate>
                                                                                </asp:Repeater>


                                                                            </tr>



                                                                        </table>
                                                                    </div>
                                                                    <div class="col-sm-2">&nbsp;</div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <asp:Repeater ID="RepYears" OnItemDataBound="RepYears_ItemDataBound" runat="server">
                                                        <ItemTemplate>
                                                            <div class="panel panel-default">
                                                                <div class="panel-heading">
                                                                    <h4 class="panel-title">
                                                                        <a data-toggle="collapse" data-parent="#accordion" href='<%# string.Concat("#", Eval("ID"))%>'>
                                                                            <i class="more-less glyphicon glyphicon-chevron-up"></i>
                                                                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("YearName") %>'></asp:Label></a>
                                                                    </h4>
                                                                </div>
                                                                <div id='<%# Eval("ID") %>' class="panel-collapse collapse ">
                                                                    <div class="panel-body">

                                                                        <asp:Label ID="PlanID" Visible="false" runat="server" Text='<%# Eval("ID") %>'></asp:Label>

                                                                        <asp:Label ID="NoData" Visible="false" runat="server" Text="لايوجد ملاحظات"></asp:Label>

                                                                        <div class="row">
                                                                            <div class="col-sm-1">&nbsp;</div>
                                                                            <div class="col-sm-10" style="text-align: center !important;">
                                                                                <table style="width: 100%;">
                                                                                    <tr>
                                                                                        <td style="float: left;">
                                                                                            <asp:Chart ID="Chart4" EnableViewState="true" runat="server" Width="420px">
                                                                                                <Titles>
                                                                                                    <asp:Title
                                                                                                        Text="مستوى التنفيذ"
                                                                                                        ForeColor="LightGray"
                                                                                                        Docking="Top"
                                                                                                        Alignment="TopRight"
                                                                                                        Font="Comic Sans MS, 14pt, style=Bold">
                                                                                                    </asp:Title>
                                                                                                </Titles>
                                                                                                <Series>
                                                                                                    <asp:Series Palette="Light" ChartType="Pie" Name="Series1"></asp:Series>
                                                                                                </Series>
                                                                                                <ChartAreas>
                                                                                                    <asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64"
                                                                                                        BorderDashStyle="Solid" BackColor="WhiteSmoke"
                                                                                                        ShadowColor="Transparent" BackGradientStyle="DiagonalLeft">


                                                                                                        <Area3DStyle Inclination="45" IsRightAngleAxes="false" Rotation="3" Enable3D="true" IsClustered="true" WallWidth="0" PointDepth="250" LightStyle="Realistic" />

                                                                                                        <AxisX IsReversed="true" IsMarginVisible="true">
                                                                                                            <MajorGrid
                                                                                                                Enabled="false" />
                                                                                                            <MajorTickMark Size="15" LineWidth="2" LineColor="White" LineDashStyle="DashDot" />
                                                                                                        </AxisX>
                                                                                                        <AxisY>
                                                                                                            <MajorGrid
                                                                                                                Enabled="false"
                                                                                                                LineColor="White" />
                                                                                                            <MajorTickMark Size="5" LineWidth="2" LineColor="White" LineDashStyle="DashDot" />
                                                                                                        </AxisY>




                                                                                                    </asp:ChartArea>

                                                                                                </ChartAreas>
                                                                                                <Legends>
                                                                                                    <asp:Legend Name="MobileBrands" IsDockedInsideChartArea="false" Docking="Top" Alignment="Far" Title="" TableStyle="Wide" BorderDashStyle="Dash" BorderColor="LightGray" TitleSeparator="Line" TitleFont="TimesNewRoman" TitleSeparatorColor="#e8eaf1">
                                                                                                    </asp:Legend>


                                                                                                    <%--Legends denotes the representing color for each brands--%>
                                                                                                    <%--It will automatically takes the names from the series names and it's associated colors or you can give legend text in series--%>
                                                                                                </Legends>
                                                                                            </asp:Chart>

                                                                                            <td style="width: 100px;">&nbsp;</td>

                                                                                            <td style="float: right;">
                                                                                                <asp:Chart ID="ChartImport" EnableViewState="true" runat="server" Width="420px">
                                                                                                    <Titles>
                                                                                                        <asp:Title
                                                                                                            Text="مستوى الأهمية"
                                                                                                            ForeColor="LightGray"
                                                                                                            Docking="Top"
                                                                                                            Alignment="TopRight"
                                                                                                            Font="Comic Sans MS, 14pt, style=Bold">
                                                                                                        </asp:Title>
                                                                                                    </Titles>
                                                                                                    <Series>
                                                                                                        <asp:Series Palette="Light" ChartType="Pie" Name="SeriesA"></asp:Series>
                                                                                                    </Series>
                                                                                                    <ChartAreas>
                                                                                                        <asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64"
                                                                                                            BorderDashStyle="Solid" BackColor="WhiteSmoke"
                                                                                                            ShadowColor="Transparent" BackGradientStyle="DiagonalLeft">


                                                                                                            <Area3DStyle Inclination="45" Rotation="3" IsRightAngleAxes="false" Enable3D="true" IsClustered="true" WallWidth="0" PointDepth="250" LightStyle="Realistic" />

                                                                                                            <AxisX IsReversed="true" IsMarginVisible="true">
                                                                                                                <MajorGrid
                                                                                                                    Enabled="false" />
                                                                                                                <MajorTickMark Size="15" LineWidth="2" LineColor="White" LineDashStyle="DashDot" />
                                                                                                            </AxisX>
                                                                                                            <AxisY>
                                                                                                                <MajorGrid
                                                                                                                    Enabled="false"
                                                                                                                    LineColor="White" />
                                                                                                                <MajorTickMark Size="5" LineWidth="2" LineColor="White" LineDashStyle="DashDot" />
                                                                                                            </AxisY>




                                                                                                        </asp:ChartArea>

                                                                                                    </ChartAreas>
                                                                                                    <Legends>
                                                                                                        <asp:Legend Name="MobileBrands" Docking="Top" Alignment="Far" Title="" TableStyle="Wide" BorderDashStyle="Dash" BorderColor="LightGray" TitleSeparator="Line" TitleFont="TimesNewRoman" InterlacedRows="true" TitleSeparatorColor="#e8eaf1">
                                                                                                        </asp:Legend>


                                                                                                        <%--Legends denotes the representing color for each brands--%>
                                                                                                        <%--It will automatically takes the names from the series names and it's associated colors or you can give legend text in series--%>
                                                                                                    </Legends>
                                                                                                </asp:Chart>
                                                                                            </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </div>
                                                                            <div class="col-sm-1">&nbsp;</div>
                                                                        </div>

                                                                        <div class="row">
                                                                            <div class="col-sm-1">&nbsp;</div>
                                                                            <div class="col-sm-10" style="text-align: center;">
                                                                                <table style="width: 100%">
                                                                                    <tr>

                                                                                        <td class="center" style="vertical-align: middle;">
                                                                                            <table style="width: 100%">
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <asp:Button ID="BtnMainAllRiskSec" CommandArgument='<%# Eval("ID") %>' OnCommand="BtnMainAllRiskSec_Command" CssClass="btn btn-danger" runat="server" Text="مستوى الأهمية" />
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>

                                                                                        <td>
                                                                                            <asp:Chart ID="DataTotal" EnableViewState="true" OnClick="DataTotal_Click" runat="server" RightToLeft="Yes" Width="700" Height="400" ToolTip="نتائج معالجة ملاحظات إدارة متوسطة المراجعة الداخلية لجميع الادارات">
                                                                                                <Legends>
                                                                                                    <asp:Legend Alignment="Far" Name="MobileBrands" Docking="Top" Title="" TableStyle="Wide" BorderDashStyle="Dash" BorderColor="LightGray" TitleSeparator="Line" TitleFont="TimesNewRoman" TitleSeparatorColor="#e8eaf1">
                                                                                                    </asp:Legend>


                                                                                                    <%--Legends denotes the representing color for each brands--%>
                                                                                                    <%--It will automatically takes the names from the series names and it's associated colors or you can give legend text in series--%>
                                                                                                </Legends>
                                                                                                <Titles>
                                                                                                    <asp:Title
                                                                                                        Text="مستوى التنفيذ حسبالإدارات المتوسطة"
                                                                                                        ForeColor="LightGray"
                                                                                                        Docking="Top"
                                                                                                        Alignment="TopLeft"
                                                                                                        Font="Comic Sans MS, 14pt, style=Bold">
                                                                                                    </asp:Title>
                                                                                                </Titles>
                                                                                                <Series>
                                                                                                    <asp:Series  Name="Done" ChartType="StackedColumn" IsVisibleInLegend="false" IsValueShownAsLabel="true" Color="LightGreen" LabelForeColor="LightGreen"></asp:Series>
                                                                                                    <asp:Series  Name="SimyDone" ChartType="StackedColumn" IsVisibleInLegend="false" LabelForeColor="Black" Color="#e7ea56"></asp:Series>
                                                                                                    <asp:Series  Name="NotDone" ChartType="StackedColumn" IsVisibleInLegend="false" LabelForeColor="White" Color="DarkRed"></asp:Series>
                                                                                                    <asp:Series  Name="NotNow" ChartType="StackedColumn" IsVisibleInLegend="false" Color="#9a9ebd" LabelForeColor="Black"></asp:Series>

                                                                                                    <asp:Series  Name="Closed" ChartType="StackedColumn" IsVisibleInLegend="false" Color="CadetBlue" LabelForeColor="Transparent"></asp:Series>


                                                                                                    <%--Name- you can change the product name here such as type, type2--%>
                                                                                                    <%--IsValueShownAsLabel- you can enable the count to show on each columns and each series--%>
                                                                                                    <%--Each series represents each colour in a column--%>
                                                                                                </Series>

                                                                                                <ChartAreas>
                                                                                                    <asp:ChartArea Name="ChartArea1"
                                                                                                        BackColor="WhiteSmoke"
                                                                                                        ShadowColor="Transparent" BackGradientStyle="DiagonalLeft">
                                                                                                        <Area3DStyle Enable3D="true" IsClustered="true" WallWidth="0" PointDepth="50" LightStyle="Realistic" />
                                                                                                        <AxisX IsMarginVisible="true">
                                                                                                            <MajorGrid
                                                                                                                Enabled="false" />
                                                                                                            <MajorTickMark LineDashStyle="DashDot" />
                                                                                                        </AxisX>
                                                                                                        <AxisY>

                                                                                                            <MajorGrid
                                                                                                                Enabled="false"
                                                                                                                LineColor="White" />
                                                                                                            <MajorTickMark LineDashStyle="DashDot" />
                                                                                                        </AxisY>




                                                                                                    </asp:ChartArea>

                                                                                                </ChartAreas>
                                                                                            </asp:Chart>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </div>
                                                                            <div class="col-sm-1">&nbsp;</div>
                                                                        </div>

                                                                        <div class="row">
                                    
                                     <div class="col-sm-12" style="text-align: center!important; direction: ltr;">
                                        <table style="width: 100%; font-size: 12px; font-family: Verdana, Geneva, Tahoma, sans-serif;" class="table table-striped table-bordered">

                                            <tr>
                                                <asp:Repeater ID="EmployeesDataYears" runat="server">
                                                    <HeaderTemplate>
                                                        <th class="center">الإجمالى</th>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <th class="center" style="width: 35px; background-color: whitesmoke">

                                                            <%-- <i style="display: <%#(Container.ItemIndex+1)<=3?";":"none;"%>'" title=' <%# string.Concat(Eval("Done"),"%") %>' class="menu-icon fa fa-arrow-up green"></i>
                                                            --%>
                                                            <div>
                                                                <asp:Label ID="Label1" ToolTip='<%# string.Concat(Eval("Done"),"% [" ,Eval("Status3")," ] ") %>' runat="server" Text='<%# Eval("AdmName") %>'></asp:Label>
                                                            </div>

                                                        </th>

                                                    </ItemTemplate>

                                                </asp:Repeater>

                                                <th style="width: 15px;" class="center">&nbsp;</th>

                                            </tr>

                                            <tr>

                                                <asp:Repeater ID="RepTotalsYears" runat="server">
                                                    <ItemTemplate>
                                                        <th class="center" style="margin: 0; width: 15px; padding: 0; background-color: whitesmoke;">

                                                            <div style="background: #ffffff">

                                                                <asp:Label ID="Label3" runat="server" Text='<%# Eval("TotalDone") %>'></asp:Label>
                                                            </div>

                                                            <div>
                                                                <asp:Label ID="Label4" runat="server" Text='<%# Eval("TotalSemiDone") %>'></asp:Label>
                                                            </div>

                                                            <div style="background: #ffffff">
                                                                <asp:Label ID="Label5" runat="server" Text='<%# Eval("TotalNotDone") %>'></asp:Label>
                                                            </div>
                                                            <div>
                                                                <asp:Label ID="Label6" runat="server" Text='<%# Eval("TotalNotNow") %>'></asp:Label>
                                                            </div>

                                                            <div style="background: #ffffff">
                                                                <asp:Label ID="Label7" runat="server" Text='<%# Eval("TotalClosed") %>'></asp:Label>
                                                            </div>

                                                            <div>
                                                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("Total") %>'></asp:Label>
                                                            </div>
                                                        </th>
                                                    </ItemTemplate>
                                                </asp:Repeater>

                                                <asp:Repeater ID="Repeater2Years" runat="server">

                                                    <ItemTemplate>


                                                        <th class="center" style="white-space: nowrap; margin: 0; padding: 0; background-color: whitesmoke; width: 20px;">

                                                            <asp:Label ID="Label1" Style="display: none" runat="server" Text='<%# Eval("RepAdms") %>'></asp:Label>
                                                            <div style="background-color: #ffffff">
                                                                <asp:Label ID="Label3" runat="server" Text='<%# Eval("Status3") %>'></asp:Label>
                                                            </div>
                                                            <div>
                                                                <asp:Label ID="Label4" runat="server" Text='<%# Eval("Status2") %>'></asp:Label>
                                                            </div>

                                                            <div style="background-color: #ffffff">
                                                                <asp:Label ID="Label5" runat="server" Text='<%# Eval("Status1") %>'></asp:Label>
                                                            </div>

                                                            <div>
                                                                <asp:Label ID="Label6" runat="server" Text='<%# Eval("Status4") %>'></asp:Label>
                                                            </div>
                                                            <div style="background-color: #ffffff">
                                                                <asp:Label ID="Label7" runat="server" Text='<%# Eval("Status5") %>'></asp:Label>
                                                            </div>
                                                            <div>
                                                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("TotalCount") %>'></asp:Label>

                                                            </div>
                                                        </th>


                                                    </ItemTemplate>


                                                </asp:Repeater>
                                                <th style="white-space: nowrap; margin: 0;direction: rtl; padding: 0; width: 22%; background-color: whitesmoke;">
                                                    <div style="background-color: #ffffff; padding-right: 10px; padding-left: 10px;"><span class="fa fa-square" style="color: lightgreen;">&nbsp;</span>
                                                        المعالج
                                                    </div>

                                                    <div style="padding-right: 10px; padding-left: 10px;"><span class="fa fa-square" style="color: #e7ea56;">&nbsp;</span>
                                                        جارى التنفيذ
                                                    </div>
                                                    <div style="padding-right: 10px; padding-left: 10px; background-color: #ffffff"><span class="fa fa-square" style="color: darkred;">&nbsp;</span>
                                                        متأخرة
                                                    </div>


                                                    <div style="padding-right: 10px; padding-left: 10px;"><span class="fa fa-square" style="color: #cccccc;">&nbsp;</span>
                                                        مغلقة
                                                    </div>
                                                    <div style="padding-right: 10px; padding-left: 10px; background-color: #ffffff"><span class="fa fa-square" style="color: #5b9092;">&nbsp;</span>
                                                          لم يحن وقت تنفيذها
                                                    </div>

                                                    <div style="padding-right: 10px; padding-left: 10px;"><span class="fa fa-square" style="color: transparent;">&nbsp;</span>
                                                        إجمالى الملاحظات
                                                    </div>

                                                </th>




                                            </tr>



                                        </table>
                                    </div>
                                    
                                </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </ItemTemplate>
                                                    </asp:Repeater>


                                                </div>
                                            </div>


                                            <!-- div.table-responsive -->

                                            <!-- div.dataTables_borderWrap -->
                                            <div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div id="DataChart" runat="server" style="display: none;">
                        <div style="padding: 15px; border: 1px solid #E0E2E5; background-color: #F8FAFC;">
                            <asp:LinkButton ID="BackCharts" runat="server" OnClick="BackCharts_Click" Style="float: left"><span class="label label-lg label-purple arrowed">رجوع</span></asp:LinkButton>

                        </div>

                        <div runat="server" id="DAll">

                            <table border="1" class="table table-bordered" style="direction: ltr; border: dotted 1px #8ce08c; background-color: #f5f9fd;">

                                <thead>
                                    <tr>
                                        <th class="center"><b>مستوى الأهمية </b></th>
                                        <th class="center"><b>الادارة</b></th>

                                    </tr>
                                </thead>


                                <tbody>
                                    <asp:Repeater ID="AdminsListAll" runat="server">

                                        <ItemTemplate>
                                            <tr>

                                                <td class="center">
                                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                        <ContentTemplate>
                                                            <asp:LinkButton ID="PreviewTotalAll" OnCommand="PreviewTotal_Command" CommandArgument='<%#string.Concat(Eval("AdmID"),"/",Eval("AdmName")) %>' runat="server">
                                                                <asp:Label ID="TCount" runat="server" Text='<%# Eval("TotalCount") %>'></asp:Label>
                                                            </asp:LinkButton></td>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>

                                                    <td class="center">
                                                        <b>
                                                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("AdmName") %>'></asp:Label></b>  </td>

                                                </td>
                                            </tr>

                                        </ItemTemplate>

                                    </asp:Repeater>
                                </tbody>
                            </table>
                        </div>
                        <div runat="server" id="DPlan">
                            <table border="1" class="table table-bordered" style="direction: ltr; border: dotted 1px #8ce08c; background-color: #f5f9fd;">

                                <thead>
                                    <tr>
                                        <th class="center"><b>مستوى الأهمية </b></th>
                                        <th class="center"><b>الادارة</b></th>

                                    </tr>
                                </thead>


                                <tbody>
                                    <asp:Repeater ID="AdminsListBySec" runat="server">

                                        <ItemTemplate>
                                            <tr>

                                                <td class="center">
                                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                        <ContentTemplate>
                                                            <asp:LinkButton ID="PreviewTotal" OnCommand="PreviewTotal_Command" CommandArgument='<%#String.Concat(Eval("PlanID"),",",Eval("AdmID"),",",Eval("TotalCount"),",",Eval("AdmName")) %>' runat="server">
                                                                <asp:Label ID="Label8" runat="server" Text='<%# Eval("TotalCount") %>'></asp:Label>
                                                            </asp:LinkButton></td>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>

                                                    <td class="center">
                                                        <b>
                                                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("AdmName") %>'></asp:Label></b>  </td>

                                                </td>
                                            </tr>

                                        </ItemTemplate>

                                    </asp:Repeater>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>

            <table border="1" style="width: 60%; margin-top: 10px; display: none; direction: ltr; border: dashed 1px #8ce08c">

                <thead>
                    <tr>

                        <th>&nbsp;</th>
                        <th>حالة الملاحظة</th>
                    </tr>
                </thead>


                <tbody>
                    <tr>
                        <td>تم معالجة وتنفيذ جميع التوصيات</td>
                        <td>معالجة</td>
                    </tr>

                    <tr>
                        <td>تم تنفيذ جزء من التوصية فقط / جزء من الملاحظة</td>
                        <td>جارى التنفيذ</td>
                    </tr>

                    <tr>
                        <td>لم يتم معالجة التوصية / الملاحظة وفقا لتاريخ الانتهاء المقدم من قبل الإدارة متوسطة</td>
                        <td>متأخرة</td>
                    </tr>

                    <tr>
                        <td>لم يحن تاريخ تنفيذ التوصية/ الملاحظة المتفق عليه مع الإدارة متوسطة</td>
                        <td>لم يحن وقت تنفيذها</td>
                    </tr>
                    <tr>
                        <td>لعدم مناسبة تطبيقها في الوقت الحالي ، لتكرارها في تقرير آخر</td>
                        <td>مغلقة</td>
                    </tr>
                </tbody>
            </table>

            <div id="Del_modal" data-backdrop="static" data-keyboard="false" style="z-index: 1999999; padding-top: 10%;" class="modal fade" tabindex="-1">
                <div class="modal-dialog" style="width: 70%; padding-right: 20%;">
                    <div class="modal-content">

                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                            <h4 class="blue bigger">مستوى الأهمية للملاحظات تبعا لحالة التنفيذ والإدارة متوسطة </h4>
                        </div>

                        <div class="modal-body">
                            <asp:Chart ID="ChartStatus" runat="server" RightToLeft="Yes" Width="600px" Height="250px" ToolTip="نتائج درجة أهمية ملاحظات إدارة متوسطة المراجعة الداخلية لجميع الادارات">
                                <Legends>
                                    <asp:Legend Name="StatusLegend" Docking="Right" InterlacedRows="true" Title="" TableStyle="Tall" BorderDashStyle="Dash" BorderColor="LightGray" TitleSeparator="Line" TitleFont="TimesNewRoman" TitleSeparatorColor="#e8eaf1">
                                    </asp:Legend>

                                    <%--Legends denotes the representing color for each brands--%>
                                    <%--It will automatically takes the names from the series names and it's associated colors or you can give legend text in series--%>
                                </Legends>
                                <Titles>
                                    <asp:Title
                                        Text="مستوى التنفيذ حسبالإدارات المتوسطة"
                                        ForeColor="LightGray"
                                        Docking="Top"
                                        Alignment="TopLeft"
                                        Font="Comic Sans MS, 14pt, style=Bold">
                                    </asp:Title>
                                </Titles>
                                <Series>
                                    <asp:Series Name="HighStat" LabelForeColor="DarkRed" Color="DarkRed"></asp:Series>
                                    <asp:Series Name="IntermedStat" Color="Orange" LabelForeColor="Orange"></asp:Series>
                                    <asp:Series Name="LowStat" Color="LightGreen" LabelForeColor="LightGreen"></asp:Series>


                                    <%--Name- you can change the product name here such as type, type2--%>
                                    <%--IsValueShownAsLabel- you can enable the count to show on each columns and each series--%>
                                    <%--Each series represents each colour in a column--%>
                                </Series>

                                <ChartAreas>
                                    <asp:ChartArea Name="ChartArea2" BorderColor="Transparent"
                                        BorderDashStyle="NotSet" BorderWidth="0" BackSecondaryColor="White"
                                        BackColor="Transparent"
                                        ShadowColor="Transparent" BackGradientStyle="TopBottom">


                                        <Area3DStyle Enable3D="true" IsClustered="true" WallWidth="0" PointDepth="50" LightStyle="Realistic" />

                                        <AxisX IsMarginVisible="true">
                                            <MajorGrid
                                                Enabled="false" />
                                            <MajorTickMark LineDashStyle="DashDot" />
                                        </AxisX>
                                        <AxisY LabelAutoFitStyle="DecreaseFont">

                                            <MajorGrid
                                                Enabled="false"
                                                LineColor="White" />
                                            <MajorTickMark LineDashStyle="DashDot" />
                                        </AxisY>




                                    </asp:ChartArea>

                                </ChartAreas>
                            </asp:Chart>
                        </div>

                    </div>
                </div>
            </div>

            <div id="AdminImport_modal" data-backdrop="static" data-keyboard="false" style="z-index: 1999999; padding-top: 10%;" class="modal fade" tabindex="-1">
                <div class="modal-dialog" style="width: 70%; padding-right: 20%;">
                    <div class="modal-content">

                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                            <h4 class="blue bigger"><asp:Label ID="LbelPup" runat="server" Text=""></asp:Label></h4>
                        </div>

                        <div class="modal-body">
                            <div class="row">
                                <div class="col-sm-2">&nbsp;</div>
                                <div class="col-sm-10">
                                    <asp:Chart ID="ChartImportByAdm" EnableViewState="true" runat="server" Width="500px" BackColor="White">
                                        <Titles>
                                            <asp:Title
                                               
                                                ForeColor="LightGray"
                                                Docking="Top"
                                                Alignment="TopRight"
                                                Font="Comic Sans MS, 14pt, style=Bold">
                                            </asp:Title>
                                        </Titles>
                                        <Series>
                                            <asp:Series Palette="Light" ChartType="Pie" Name="Series1"></asp:Series>
                                        </Series>
                                        <ChartAreas>
                                            <asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64"
                                                BorderDashStyle="Solid" BackColor="WhiteSmoke"
                                                ShadowColor="Transparent" BackGradientStyle="DiagonalLeft">


                                                <Area3DStyle Rotation="3" Inclination="45" IsRightAngleAxes="false" Enable3D="true" IsClustered="true" WallWidth="0" PointDepth="250" LightStyle="Realistic" />

                                                <AxisX IsReversed="true" IsMarginVisible="true">
                                                    <MajorGrid
                                                        Enabled="false" />
                                                    <MajorTickMark Size="15" LineWidth="2" LineColor="White" LineDashStyle="DashDot" />
                                                </AxisX>
                                                <AxisY>
                                                    <MajorGrid
                                                        Enabled="false"
                                                        LineColor="White" />
                                                    <MajorTickMark Size="5" LineWidth="2" LineColor="White" LineDashStyle="DashDot" />
                                                </AxisY>




                                            </asp:ChartArea>

                                        </ChartAreas>
                                        <Legends>
                                            <asp:Legend Name="MobileBrands" Docking="Top" Alignment="Far" Title="" TableStyle="Wide" BorderDashStyle="Dash" BorderColor="LightGray" TitleSeparator="Line" TitleFont="TimesNewRoman" TitleSeparatorColor="#e8eaf1">
                                            </asp:Legend>


                                            <%--Legends denotes the representing color for each brands--%>
                                            <%--It will automatically takes the names from the series names and it's associated colors or you can give legend text in series--%>
                                        </Legends>

                                    </asp:Chart>
                                </div>


                                <div class="col-sm-2">&nbsp;</div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:Label ID="ShowData" Style="display: none;" runat="server" Text=""></asp:Label>
    <asp:Label ID="ShowAdminImp" Style="display: none;" runat="server" Text=""></asp:Label>
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
        function GetDetails() {
            $('#AdminImport_modal').modal({ show: true, backdrop: false });
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

            
            var paneName = $("[id*=PaneName]").val() != "" ? $("[id*=PaneName]").val() : "collapse1";
            if (paneName != "collapse1") {
                //Remove the previous selected Pane.
                $("#accordion .in").removeClass("in");

            }
            //Set the selected Pane.
            $("#" + paneName).collapse("show");

            //When Pane is clicked, save the ID to the Hidden Field.
            $(".panel-heading a").click(function () {
                if ($(this).attr("href").replace("#", "") != "collapse1") {
                    $("[id*=PaneName]").val($(this).attr("href").replace("#", ""));
                }
            });

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
     

            ////////////////////////
            if (document.getElementById("<%=ShowData.ClientID%>").innerText == "A") {
                $('#Del_modal').modal({ show: true, backdrop: false });
            }
            if (document.getElementById("<%=ShowAdminImp.ClientID%>").innerText == "A") {

                $('#AdminImport_modal').modal({ show: true, backdrop: false });
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

