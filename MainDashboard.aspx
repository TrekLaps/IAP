<%@ Page Title=" نتائج معالجة الملاحظات " Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MainDashboard.aspx.cs" Inherits="MainDashboard" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>




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
        @media print {
            #Prnt {
                visibility: hidden;
            }

            #dvContents {
                visibility: visible;
            }
        }
    </style>


</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="PageTitle" runat="Server">
   نتائج معالجة الملاحظات 
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" runat="Server">


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

             
            <div id="MainsAll" runat="server">
                <div class="row" style="padding-top:5px;">
                    <label class="col-sm-2 control-label Sub blue" for="form-field-1">السنوات </label>

                    <div class="col-sm-10">

                       <div>
                            <asp:DropDownList class="chosen-select chosen-rtl form-control"  ID="DropYear" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="DropYear_SelectedIndexChanged" runat="server" data-placeholder="الخطة السنوية">
                                <asp:ListItem Value="0" Text="جميع السنوات" Selected="True" />

                            </asp:DropDownList>
                        </div>



                    </div>
                </div>
                 <div class="alert alert-info" runat="server" ID="NoRep" visible="false">
                                                                لايوجد ملاحظات مسجلة
                                                            </div>

                 

                <div id="PrntViewSections" runat="server" style="background-color:#ffffff">



                    <div class="row">
                        <div class="col-xs-12">
                            <h3 class="header smaller lighter blue">&nbsp;</h3>



                            <div class="panel-body">
                                <div class="alert alert-info" runat="server" id="Div1" visible="false">
                                    لايوجد ملاحظات مسجلة
                                </div>

                                <div class="row">
                                  <div class="col-sm-1">&nbsp;</div>
                                    <div class="col-sm-10" style="text-align: center !important; ">
                                    <table style="width:100%;">
                                        <tr>
                                        <td style="float:left;">
                                        <asp:Chart ID="ChartMain4"   EnableViewState="true" runat="server" Width="420px" BackColor="White">
                                            <Titles>
                                                <asp:Title
                                                    Text="مستوى التنفيذ على مستوى المؤسسة"
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
                                                <asp:Legend Name="MobileBrands" Docking="Top" Alignment="Far" Title="" TableStyle="Wide" BorderDashStyle="Dash" BorderColor="LightGray" TitleSeparator="Line" TitleFont="TimesNewRoman" TitleSeparatorColor="#e8eaf1">
                                                </asp:Legend>


                                                <%--Legends denotes the representing color for each brands--%>
                                                <%--It will automatically takes the names from the series names and it's associated colors or you can give legend text in series--%>
                                            </Legends>
                                        </asp:Chart>
                                                                                                                </td>
                                        <td style="width:100px;">&nbsp;</td>
                                        
                                        <td style="float: right;"><asp:Chart ID="ChartMain3"  EnableViewState="true" runat="server" Width="420px" BackColor="White">
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
                                                    ShadowColor="Transparent" BackImageAlignment="Center" BackGradientStyle="DiagonalLeft">
                                                    <Area3DStyle Rotation="3" Inclination="45" IsRightAngleAxes="false" Enable3D="true" IsClustered="true" WallWidth="0" PointDepth="250" LightStyle="Realistic" />

                                                    <AxisX IsReversed="true" IsMarginVisible="true">
                                                        <MajorGrid
                                                            Enabled="false" />
                                                        <MajorTickMark Size="15" LineWidth="2" LineColor="White" LineDashStyle="DashDot" />
                                                        <LabelStyle Font="Arial, 8pt" ForeColor="#828282" />
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

                                        </asp:Chart></td></tr></table>
                                   

                                    </div><div class="col-sm-1">&nbsp;</div>


                                    
                                </div>

                                <div class="row">


                                    <div class="col-sm-1">
                                        &nbsp;
                                    </div>
                                    <div class="col-sm-10" style="text-align: center;">
                                        <table style="width: 100%">
                                            <tr> 
                                               
                                                <td class="center" style="vertical-align: middle;"><table style="width:100%"><tr>
                                                    <td><asp:Button ID="BtnAdminAll" OnClick="BtnAdminAll_Click" CssClass="btn btn-danger" Text="مستوى الأهمية" runat="server" /></td></tr></table>
                                                    
                                                    <td><asp:Chart ID="Chart1" OnClick="Chart1_Click" EnableViewState="true" runat="server" RightToLeft="Yes" Width="800px" Height="500px" ToolTip="نتائج معالجة ملاحظات إدارة متوسطة المراجعة الداخلية لجميع الادارات">
                                                        <Legends>
                                                            <asp:Legend Alignment="Far" Name="MobileBrands" Docking="Top" Title="" TableStyle="Wide" BorderDashStyle="Dash" BorderColor="LightGray" TitleSeparator="Line" TitleFont="TimesNewRoman" TitleSeparatorColor="#e8eaf1">
                                                            </asp:Legend>


                                                            <%--Legends denotes the representing color for each brands--%>
                                                            <%--It will automatically takes the names from the series names and it's associated colors or you can give legend text in series--%>
                                                        </Legends>
                                                        <Titles>
                                                            <asp:Title
                                                                Text="مستوى التنفيذ على مستوى الإدارات عليا "
                                                                ForeColor="LightGray"
                                                                Docking="Top"
                                                                Alignment="TopLeft"
                                                                Font="Comic Sans MS, 14pt, style=Bold">
                                                            </asp:Title>
                                                        </Titles>
                                                        <Series>
                                                            <asp:Series  Name="Done" IsVisibleInLegend="false" ChartType="StackedColumn" Color="LightGreen" LabelForeColor="Black"></asp:Series>

                                                            <asp:Series  Name="SimyDone" IsVisibleInLegend="false" ChartType="StackedColumn" LabelForeColor="Black" Color="#e7ea56"></asp:Series>
                                                            <asp:Series  Name="NotDone" IsVisibleInLegend="false" ChartType="StackedColumn" LabelForeColor="Black" Color="DarkRed"></asp:Series>
                                                            <asp:Series  Name="NotNow" IsVisibleInLegend="false" ChartType="StackedColumn" Color="#5b9092" LabelForeColor="Black"></asp:Series>
                                                            <asp:Series  Name="Closed" IsVisibleInLegend="false" ChartType="StackedColumn" Color="#cccccc" LabelForeColor="Black"></asp:Series>


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
                                                                <AxisY >

                                                                    <MajorGrid
                                                                        Enabled="false"
                                                                        LineColor="White" />
                                                                    <MajorTickMark LineDashStyle="DashDot" />
                                                                </AxisY>




                                                            </asp:ChartArea>

                                                        </ChartAreas>
                                                    </asp:Chart></td>
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
                                                                <asp:Label ID="Label1" ToolTip='<%# string.Concat(Eval("Done"),"% [" ,Eval("Status3")," ] ") %>' runat="server" Text='<%# Eval("SectionName") %>'></asp:Label>
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

                                                            <asp:Label ID="Label1" Style="display: none" runat="server" Text='<%# Eval("SectionName") %>'></asp:Label>
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



                            <!-- div.table-responsive -->

                            <!-- div.dataTables_borderWrap -->
                            <div>
                            </div>
                        </div>
                    </div>

                </div>


                <div id="PrntViewMain" runat="server" style="background-color:#ffffff">
                    <div id="dvContents">
                        <h3 class="header smaller lighter blue" style="padding-right: 20px;">&nbsp; </h3>

                        <div class="row">




                            <div class="panel-body">

                                <!-- div.table-responsive -->

                                <!-- div.dataTables_borderWrap -->


                             
                                <div class="row">
                                    <div class="col-sm-1">
                                        &nbsp;
                                    </div>
                                    <div class="col-sm-10" style="text-align: center;">
                                        <table style="width: 100%">
                                            <tr>
                                                <td style="vertical-align: middle;" class="left">
                                                   &nbsp; </td>
                                                <td class="center" style="vertical-align: middle;">

                                                   <table style="width:100%"><tr>
                                                       
                                                       <td><asp:Button ID="ButtonViewAdmins" OnClick="ButtonViewAdmins_Click" CssClass="btn btn-danger" Text="مستوى الأهمية" runat="server" /></td></tr></table>
                                                    <td><asp:Chart ID="ChartMain1" OnClick="ChartMain1_Click" EnableViewState="true"  runat="server" RightToLeft="Yes" Width="900px" Height="500px" ToolTip="نتائج معالجة ملاحظات إدارة متوسطة المراجعة الداخلية لجميع الادارات">
                                                        <Legends>
                                                            <asp:Legend Alignment="Far" Name="MobileBrands" Docking="Top" Title="" TableStyle="Wide" BorderDashStyle="Dash" BorderColor="LightGray" TitleSeparator="Line" TitleFont="TimesNewRoman" TitleSeparatorColor="#e8eaf1">
                                                            </asp:Legend>


                                                            <%--Legends denotes the representing color for each brands--%>
                                                            <%--It will automatically takes the names from the series names and it's associated colors or you can give legend text in series--%>
                                                        </Legends>
                                                        <Titles>
                                                            <asp:Title
                                                                Text="مستوى التنفيذ على مستوىالإدارات المتوسطة"
                                                                ForeColor="LightGray"
                                                                Docking="Top"
                                                                Alignment="TopLeft"
                                                                Font="Comic Sans MS, 14pt, style=Bold">
                                                            </asp:Title>
                                                        </Titles>
                                                        <Series>
                                                            <asp:Series   Name="Done" ChartType="StackedColumn" Color="LightGreen" IsVisibleInLegend="false" LabelForeColor="Black"></asp:Series>

                                                            <asp:Series   Name="SimyDone" ChartType="StackedColumn" IsVisibleInLegend="false" LabelForeColor="Black" Color="#e7ea56"></asp:Series>
                                                            <asp:Series  Name="NotDone" ChartType="StackedColumn" IsVisibleInLegend="false" LabelForeColor="Black" Color="DarkRed"></asp:Series>
                                                            <asp:Series  Name="NotNow" ChartType="StackedColumn" Color="#5b9092" IsVisibleInLegend="false" LabelForeColor="Black"></asp:Series>
                                                            <asp:Series  Name="Closed" IsVisibleInLegend="false" ChartType="StackedColumn" Color="#cccccc"></asp:Series>


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
                                                    </asp:Chart></td>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div class="col-sm-1">
                                        &nbsp;
                                    </div>
                                </div>


                                <div class="row">
                                    <div class="col-sm-12" style="text-align: center !important; direction: ltr;">
                                        <table id="dynamic-table" style="width: 100%; font-size: 12px; font-family: Verdana, Geneva, Tahoma, sans-serif" class="table table-striped table-bordered ">

                                            <tr>
                                                <asp:Repeater ID="EmployeesData" runat="server">
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

                                                <th style="width: 15px" class="center">&nbsp;</th>

                                            </tr>

                                            <tr>

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

                                                <asp:Repeater ID="Repeater2" runat="server">

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



                                            </tr>



                                        </table>
                                    </div>
                                    
                                </div>

                            </div>




                        </div>

                    </div>
                </div>


            </div>




            <div id="DataChart" runat="server" style="display: none;">
                <div style="border: 1px solid #E0E2E5; background-color: #F8FAFC;">
                    <asp:LinkButton ID="BackCharts" runat="server" OnClick="BackCharts_Click" Style="float: left"><span class="label label-lg label-purple arrowed">رجوع</span></asp:LinkButton>

                </div>
                <div runat="server" id="Ad1">
                    <table class="table table-bordered" style="direction: ltr; border: dotted 1px #8ce08c; font-size: 12px; font-family: Verdana, Geneva, Tahoma, sans-serif; background-color: #f5f9fd;">

                        <thead>
                            <tr>
                                <th class="center"><b>مستوى الأهمية</b></th>
                                <th class="center"><b>الادارة</b></th>

                            </tr>
                        </thead>


                        <tbody>
                            <asp:Repeater ID="AdminsList" runat="server">

                                <ItemTemplate>
                                    <tr>


                                        <td class="center" style="text-decoration: underline; -webkit-text-decoration-color: #1faddb; text-decoration-color: #1faddb;">
                                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                <ContentTemplate>
                                                    <asp:LinkButton ID="PreviewTotalAdmin" CommandArgument='<%# string.Concat(Eval("RepAdms") ,"/",Eval("AdmName"))%>' OnCommand="PreviewTotalAdmin_Command" runat="server">
                                                        <asp:Label ID="Label8" runat="server" Text='<%# Eval("TotalCount") %>'></asp:Label>
                                                    </asp:LinkButton>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>

                                        </td>
                                        <td class="center">
                                            <b>
                                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("AdmName") %>'></asp:Label></b>  </td>


                                    </tr>

                                </ItemTemplate>

                            </asp:Repeater>
                        </tbody>
                    </table>
                </div>

                <div runat="server" id="AdAll">
                    <table border="1" class="table table-bordered" style="direction: ltr; border: dotted 1px #8ce08c; font-size: 12px; font-family: Verdana, Geneva, Tahoma, sans-serif; background-color: #f5f9fd;">

                        <thead>
                            <tr>
                                <th class="center"><b>مستوى الأهمية</b></th>
                                <th class="center"><b>الإدارة العليا</b></th>

                            </tr>
                        </thead>


                        <tbody>
                            <asp:Repeater ID="AdminsListAll" runat="server">

                                <ItemTemplate>
                                    <tr>

                                        <td class="center" style="text-decoration: underline; -webkit-text-decoration-color: #1faddb; text-decoration-color: #1faddb;">
                                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                <ContentTemplate>
                                                    <asp:LinkButton ID="PreviewTotalAll" OnCommand="PreviewTotal_Command" CommandArgument='<%# string.Concat( Eval("RepSection"),"/",Eval("SectionName")) %>' runat="server">
                                                        <asp:Label ID="TCount" runat="server" Text='<%# Eval("TotalCount") %>'></asp:Label>
                                                    </asp:LinkButton></td>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>

                                            <td class="center">
                                                <b>
                                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("SectionName") %>'></asp:Label></b>  </td>

                                        </td>
                                    </tr>

                                </ItemTemplate>

                            </asp:Repeater>
                        </tbody>
                    </table>
                </div>




            </div>

            <div id="AdminImport_modal" data-backdrop="static" data-keyboard="false" style="z-index: 1999999; padding-top: 10%;" class="modal fade" tabindex="-1">
                <div class="modal-dialog" style="width: 70%; padding-right: 20%;">
                    <div class="modal-content">

                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                            <h4 class="blue bigger">
                                <asp:Label ID="LbelPup" runat="server" Text=""></asp:Label> </h4>
                        </div>

                        <div class="modal-body">

                            <div class="row">
                                <div class="col-sm-1">&nbsp;</div>

                                <div class="col-sm-10">
                                    <asp:Chart ID="ChartImportByAdm" EnableViewState="true" runat="server" Width="500px" BackColor="White">
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
                                </div>


                                <div class="col-sm-1">&nbsp;</div>
                            </div>


                        </div>
                    </div>
                </div>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:Label ID="ShowData" Style="display: none;" runat="server" Text=""></asp:Label>
    <asp:Label ID="ShowAdminImp" Style="display: none;" runat="server" Text=""></asp:Label>

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


           

            $('.closeall').click(function () {
                $('.panel-collapse.in')
                  .collapse('hide');
            });
            $('.openall').click(function () {
                $('.panel-collapse:not(".in")')
                  .collapse('show');
            });

            
            if (document.getElementById("<%=ShowAdminImp.ClientID%>").innerText == "A") {

                $('#AdminImport_modal').modal({ show: true, backdrop: false });
            }
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

