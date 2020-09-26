<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MainReportNewAdm.aspx.cs" Inherits="MainReportNewAdm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageTitle" runat="Server">
    اضافة تقرير 
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageContent" runat="Server">
    <h3>
        التقارير الأصلية  </h3>
    <div class="MainBox">
        <div runat="server" id="Main">
            <div class="row">
                

                <div class="col-xs-9">
                    <div id="Suc" runat="server" visible="false" class="alert alert-block alert-success">
                        <strong>
                            <i class="ace-icon fa fa-check-square-o icon-only bigger-150"></i>
                            تم الحفظ !
                        </strong>

                    </div>

                </div>
            </div>
            <div class="row">
                <asp:UpdateProgress ID="UpdateProgress2"
                    AssociatedUpdatePanelID="UpdatePanel2"
                    runat="server">
                    <ProgressTemplate>
                        <i class="ace-icon fa fa-spinner fa-spin green bigger-125"></i>جارى التحميل...            
                    </ProgressTemplate>
                </asp:UpdateProgress>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <div class="col-lg-12">
                            <div class="col-lg-4">
                                <h4 class="box-title">الخطة</h4>
                                <div style="width: 310px;">
                                    <asp:DropDownList class="chosen-select chosen-rtl form-control" ID="MainYear" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="MainYear_SelectedIndexChanged" runat="server" data-placeholder="الخطة السنوية">
                                        <asp:ListItem Value="0" Text="اختر الخطة" Selected="True" />

                                    </asp:DropDownList>
                                </div>

                            </div>
                            
                            
                        </div>

                        <div >
                            <table id="dynamic-table" style="margin-top:10px;" class=" table-bordered">
                                <thead class="TableHead">
                                    <tr>


                                        <th class="text-center">الخطة  
                                        </th>
                                        <th class="text-center">الإدارة العليا  
                                        </th>
                                        <th class="text-center">الإدارة متوسطة  
                                        </th>
                                        <th class="text-center">التقرير  
                                        </th>
                                        
                                        <th class="center">تحميل</th>
                                    </tr>
                                </thead>

                                <tbody>
                                    <asp:Repeater ID="EmployeesData" runat="server">
                                        <ItemTemplate>

                                            <tr>
                                                <td class="text-center">

                                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("PlanName") %>'></asp:Label>

                                                </td>
                                                <td class="text-center">

                                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("Sector") %>'></asp:Label>

                                                </td>
                                                <td class="text-center">

                                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("Depart") %>'></asp:Label>

                                                </td>
                                                <td class="text-center">

                                                    <asp:HyperLink ID="HyperLink1" NavigateUrl='<%# Eval("MainRFile") %>' runat="server">
                                                        <asp:Label ID="Label4" runat="server" Text='<%# Eval("MainRName") %>'></asp:Label>

                                                    </asp:HyperLink>
                                                </td>
                                                

                                                <td class="center">
                                                    <asp:HyperLink ID="HyperLink2" NavigateUrl='<%# Eval("MainRFile") %>' runat="server">
                                            

                                                    </asp:HyperLink></td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                            </table>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>

        </div>
        

        
        
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Javascript" runat="Server">
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
    <script src="assets/plugins/dataTables/jquery.dataTables.js"></script>
    <script src="assets/plugins/dataTables/dataTables.bootstrap.js"></script>

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
                            null, null, null, null, 
                            { "bSortable": false }
                        ],
                        "aaSorting": []

                        , "language": {
                            "lengthMenu": "عرض _MENU_ صف",
                            "info": "",
                            "search": "ابحث بأى بيان :",
                            "zeroRecords": "لاتوجد بيانات متوافقة مع البحث",
                            "emptyTable": "لا توجد بيانات مسجلة",
                            "paginate": {
                                "previous": "<img src='assets/icons/buttons/pre.png' style='height:32px;'>",
                                "next": "<img src='assets/icons/buttons/next.png' style='height:32px;'>"

                            }
                        }



                    });
        }


        jQuery(function ($) {

           

            $('.file2U, .file2').ace_file_input({
                no_file: 'No File ...',
                btn_choose: 'Choose',
                btn_change: 'Change',
                droppable: false,
                onchange: null,
                thumbnail: false, //| true | large
                blacklist: 'exe|php'
                //onchange:''
                //
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
                            null, null, null, null, 
                            { "bSortable": false }
                        ],
                        "aaSorting": []

                        , "language": {
                            "lengthMenu": "عرض _MENU_ صف",
                            "info": "",
                            "search": "ابحث بأى بيان :",
                            "zeroRecords": "لاتوجد بيانات متوافقة مع البحث",
                            "emptyTable": "لا توجد بيانات مسجلة",
                            "paginate": {
                                "previous": "<img src='assets/icons/buttons/pre.png' style='height:32px;'>",
                                "next": "<img src='assets/icons/buttons/next.png' style='height:32px;'>"

                            }
                        }



                    });




        });


    </script>
</asp:Content>
