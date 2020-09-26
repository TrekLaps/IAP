<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MainPage.aspx.cs" Inherits="MainPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageTitle" runat="Server">
    نظام إدارة الملاحظات والتوصيات
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageContent" runat="Server">

    <div class="container pt-5">

        <div id="SubAdmins" runat="server" visible="false">

            <div class="row">
                <div class="col-lg-4 col-md-12">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <div class="Log">
                                <i class="fa fa-user fa-3x"></i>
                            </div>
                            <div class="LogData">

                                <div><a class="aa" href="Users.aspx">المستخدمين</a></div>
                            </div>

                        </div>

                    </div>
                </div>

                <div class="col-lg-4 col-md-12">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <div class="Log">
                                <i class="fa fa-square-o fa-3x"></i>
                            </div>
                            <div class="LogData">

                                <div><a class="aa" href="Sections.aspx">الإدارات العليا</a></div>
                            </div>

                        </div>

                    </div>
                </div>
                <div class="col-lg-4 col-md-12">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <div class="Log">
                                <i class="fa fa-cubes fa-3x"></i>
                            </div>
                            <div class="LogData">

                                <div><a class="aa" href="Managments.aspx">الإدارات المتوسطة</a></div>
                            </div>

                        </div>

                    </div>
                </div>



            </div>

            <div class="row">
                <div class="col-lg-4 col-md-12">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <div class="Log">
                                <i class="fa fa-calendar-check-o fa-3x"></i>
                            </div>
                            <div class="LogData">

                                <div><a class="aa" href="Plans.aspx">الخطة السنوية</a></div>
                            </div>

                        </div>

                    </div>
                </div>

                <div class="col-lg-4 col-md-12">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <div class="Log">
                                <i class="fa fa-folder-open-o fa-3x"></i>
                            </div>
                            <div class="LogData">

                                <div><a class="aa" href="MainReportNew.aspx">التقارير الأصلية</a></div>
                            </div>

                        </div>

                    </div>
                </div>
                <div class="col-lg-4 col-md-12">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <div class="Log">
                                <i class="fa fa-pencil-square-o fa-3x"></i>
                            </div>
                            <div class="LogData">

                                <div><a class="aa" href="NewReport.aspx">ملاحظة جديدة</a></div>
                            </div>

                        </div>

                    </div>
                </div>



            </div>

            <div class="row">
                <div class="col-lg-4 col-md-12">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <div class="Log">
                                <i class="fa fa-check-circle-o fa-3x"></i>
                            </div>
                            <div class="LogData">

                                <div><a class="aa" href="ReportsDiv.aspx">عرض الملاحظات</a></div>
                            </div>

                        </div>

                    </div>
                </div>

                <div class="col-lg-4 col-md-12">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <div class="Log">
                                <i class="fa fa-info-circle fa-3x"></i>
                            </div>
                            <div class="LogData">

                                <div><a class="aa" href="MainDashboardGraph01.aspx">نتائج المؤسسة</a></div>
                            </div>

                        </div>

                    </div>
                </div>
                <div class="col-lg-4 col-md-12">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <div class="Log">
                                <i class="fa fa-file-text-o fa-3x"></i>
                            </div>
                            <div class="LogData">

                                <div><a class="aa" href="PieDashboard01.aspx">نتائج الإدارات العليا</a></div>
                            </div>

                        </div>

                    </div>
                </div>



            </div>

            <div class="row">
                
                <div class="col-lg-4 col-md-12">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <div class="Log">
                            <i class="fa fa-folder-open-o fa-3x"></i>
                        </div>
                        <div class="LogData">

                            <div><a class="aa" href="PieDashboardAdmin01.aspx"> نتائج الإدارات المتوسطة</a></div>
                        </div>

                    </div>

                </div>
            </div>


                <div class="col-lg-4 col-md-12">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <div class="Log">
                            <i class="fa fa-link fa-3x"></i>
                        </div>
                        <div class="LogData">

                            <div><a class="aa" href="http://mutaweronteam.com/WorkingHours/"> نظام ساعات العمل</a></div>
                        </div>

                    </div>

                </div>
            </div>

            </div>
        </div>

    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Javascript" runat="Server">
</asp:Content>

