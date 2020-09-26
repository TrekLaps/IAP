<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MainReportNew.aspx.cs" Inherits="MainReportNew" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
     <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.min.js"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
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
                <div class="col-xs-3">
                    <h4 class="pink" style="float: right;">
                        <span>
                            </span>
                        <asp:LinkButton ID="NewRep" OnClick="NewRep_Click" CssClass="btn btn-purple large white" runat="server">إضافة تقرير جديد</asp:LinkButton>

                    </h4>
                </div>

                <div class="col-xs-9">
                     <div id="SucDel" runat="server" visible="false" class="alert alert-block alert-success">
                        <strong>
                            <i class="ace-icon fa fa-check-square-o icon-only bigger-150"></i>
                            تم الحذف بنجاح !
                        </strong>

                    </div>
                    <div id="Suc" runat="server" visible="false" class="alert alert-block alert-success">
                        <strong>
                            <i class="ace-icon fa fa-check-square-o icon-only bigger-150"></i>
                            تم الحفظ !
                        </strong>

                    </div>

                </div>
            </div>
            <div class="row">
                <%--<asp:UpdateProgress ID="UpdateProgress2"
                    AssociatedUpdatePanelID="UpdatePanel2"
                    runat="server">
                    <ProgressTemplate>
                        <i class="ace-icon fa fa-spinner fa-spin green bigger-125"></i>جارى التحميل...            
                    </ProgressTemplate>
                </asp:UpdateProgress>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>--%>
                        <div class="col-lg-12">
                            <div class="col-lg-4">
                                <h4 class="box-title">الخطة</h4>
                                <div style="width: 310px;">
                                    <asp:DropDownList class="chosen-select chosen-rtl form-control" ID="MainYear" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="MainYear_SelectedIndexChanged" runat="server" data-placeholder="الخطة السنوية">
                                        <asp:ListItem Value="0" Text="اختر الخطة" Selected="True" />

                                    </asp:DropDownList>
                                </div>

                            </div>
                            <div class="col-lg-4">
                                <h4 class="box-title">الإدارة العليا</h4>
                                <div style="width: 310px;">
                                    <asp:DropDownList class="chosen-select chosen-rtl form-control" ID="MainSector" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="MainSector_SelectedIndexChanged" runat="server" data-placeholder="الإدارة العليا">
                                        <asp:ListItem Value="0" Text="اختر الإدارة العليا" Selected="True" />

                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-lg-4">
                                <h4 class="box-title">الإدارة متوسطة</h4>
                                <div style="width: 310px;">
                                    <asp:DropDownList class="chosen-select chosen-rtl form-control" ID="MainDepart" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="MainDepart_SelectedIndexChanged" runat="server" data-placeholder="الإدارة متوسطة">
                                        <asp:ListItem Value="0" Text="اختر الإدارة متوسطة" Selected="True" />

                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>

                        <div>
                            <table id="dynamic-table" class=" table-bordered">
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
                                        <th class="center">  </th>
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


                                                    <asp:LinkButton CssClass="green" data-rel="tooltip" title="تعديل" ID="Edit" CommandArgument='<%# Eval("ID") %>' OnCommand="Edit_Command" runat="server"><i class="ace-icon fa fa-pencil icon-only bigger-120"></i></asp:LinkButton>
                                                      <a style="color: red; font-size: 20px;" role='button' data-rel="tooltip" title="حذف" href='#Del_modal' data-toggle='modal' data-book-id='<%# Eval("ID") %>'>
                                                        
                                                         <i class="ace-icon fa fa-close icon-only bigger-120"></i>

                                                <span class='hidden'>حذف</span>
                                                    </a>


                                                </td>

                                                <td class="center">
                                                    <asp:HyperLink ID="HyperLink2" NavigateUrl='<%# Eval("MainRFile") %>' runat="server">
                                            
                                                        <i class="ace-icon fa fa-arrow-down icon-only bigger-120"></i>
                                                    </asp:HyperLink></td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                            </table>
                        </div>
                   <%-- </ContentTemplate>
                </asp:UpdatePanel>--%>
            </div>

        </div>
        <div runat="server" style="display: none;" id="NewSave">
            

            <div class="box-body">
                <div class="form-group">
                    <asp:UpdateProgress ID="UpdateProg07"
                        AssociatedUpdatePanelID="UpdatePane07"
                        runat="server">
                        <ProgressTemplate>
                            <i class="ace-icon fa fa-spinner fa-spin green bigger-125"></i>جارى التحميل...            
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                    <asp:UpdatePanel ID="UpdatePane07" runat="server">
                        <ContentTemplate>
                            <div class="col-lg-12">
                                <div class="col-lg-6">
                                    <h4 class="box-title">الخطة</h4>
                                    <div style="width: 310px;">
                                        <asp:DropDownList class="chosen-select chosen-rtl form-control" ID="DropYear" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="DropYear_SelectedIndexChanged" runat="server" data-placeholder="الخطة السنوية">
                                            <asp:ListItem Value="0" Text="اختر الخطة" Selected="True" />

                                        </asp:DropDownList>
                                    </div>

                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" InitialValue=" " ControlToValidate="DropYear" runat="server" ValidationGroup="G" ForeColor="#ff3c3c" ErrorMessage="مطلوب تحديد الإدارة العليا    *"></asp:RequiredFieldValidator>
                                </div>

                                <div class="col-lg-6">
                                    <h4 class="box-title">الإدارة العليا</h4>
                                    <div style="width: 310px;">
                                        <asp:DropDownList class="chosen-select chosen-rtl form-control" ID="Sector" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="Sector_SelectedIndexChanged" runat="server" data-placeholder="الإدارات عليا">
                                            <asp:ListItem Value="0" Text="اختر إدارة عليا" Selected="True" />

                                        </asp:DropDownList>
                                    </div>

                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" InitialValue=" " ControlToValidate="Sector" runat="server" ValidationGroup="G" ForeColor="#ff3c3c" ErrorMessage="مطلوب تحديد الإدارة العليا    *"></asp:RequiredFieldValidator>
                                </div>

                            </div>
                            <div class="col-lg-12">
                                <div class="col-lg-6">
                                    <h4 class="box-title">الإدارة متوسطة</h4>
                                    <div style="width: 310px;">
                                        <asp:DropDownList class="chosen-select chosen-rtl form-control" AppendDataBoundItems="true" ID="Mang" runat="server" data-placeholder="الإدارات المتوسطة">
                                        </asp:DropDownList>
                                    </div>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" InitialValue=" " ControlToValidate="Mang" runat="server" ValidationGroup="G" ForeColor="#ff3c3c" ErrorMessage="مطلوب تحديد الادارة    *"></asp:RequiredFieldValidator>

                                </div>
                                <div class="col-lg-6" style="width: 510px;">
                                    <h4 class="box-title">اسم التقرير</h4>
                                    <div>
                                        <input runat="server" type="text" id="FileName" placeholder="اسم التقرير" class="form-control text col-xs-10 col-sm-10" multiple="multiple" aria-multiline="true" />

                                    </div>

                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" InitialValue=" " ControlToValidate="FileName" runat="server" ValidationGroup="G" ForeColor="#ff3c3c" ErrorMessage="مطلوب تحديد الاسم للتقرير    *"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <div class="form-group">
                        <div class="btn btn-primary btn-sm right" style="width: 350px;">
                            <span>Select file</span>
                            <asp:FileUpload ID="FileUpload1" runat="server" CssClass="file2" />
                        </div>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" ForeColor="Red" Display="Dynamic" ValidationGroup="G" runat="server" ControlToValidate="FileUpload1" ErrorMessage="*مطلوب رفع ملف"></asp:RequiredFieldValidator>

                    </div>




                </div>
            </div>
            <div class="modal-footer">
                <asp:Label ID="Rett" runat="server" Text="" CssClass="Rett" ForeColor="#ff3c3c"></asp:Label>
                <asp:ImageButton ID="Save" OnClick="Save_Click" ValidationGroup="G" Height="51" runat="server" src="assets/icons/buttons/report2.png" />
                <asp:ImageButton ID="ImageButton1" OnClick="BackCharts_Click" Height="51" runat="server" src="assets/icons/buttons/back2.png" />

            </div><div >
             <asp:LinkButton ID="LinkButton1" runat="server" OnClick="BackCharts_Click" Style="float: left;margin-top:-10px;"><i class="ace-icon fa fa-arrow-left icon-only purple bigger-250"></i></asp:LinkButton>
</div>
        </div>

        <div id="Del_modal" data-backdrop="static" data-keyboard="false" style="top: 20%" aria-hidden="false" class="modal fade" tabindex="-1">
            <div class="modal-dialog" style="width: 60%; padding-right: 20%;">
                <div class="modal-content">
                    <div class="modal-body">
                        <div style="margin-top: 7px;" class="row">

                            <div class="col-sm-1" style="text-align: right;">
                                
                            </div>
                            <div class="col-lg-8" style="text-align: right;">
                                <h4 class="align-right">هل أنت متأكد من حذف هذا التقرير ؟ </h4>
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
        <div runat="server" style="display: none;" id="UpdateSave">
            
            <div class="box-body">
                <div class="form-group">
                    <asp:UpdateProgress ID="UpdateProgress1"
                        AssociatedUpdatePanelID="UpdatePane07"
                        runat="server">
                        <ProgressTemplate>
                            <i class="ace-icon fa fa-spinner fa-spin green bigger-125"></i>جارى التحميل...            
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div class="col-lg-12">
                                <div class="col-lg-6">
                                    <h4 class="box-title">الخطة</h4>
                                    <div style="width: 310px;">
                                        <asp:DropDownList class="chosen-select chosen-rtl form-control" ID="DropYearU" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="DropYearU_SelectedIndexChanged" runat="server" data-placeholder="الخطة السنوية">
                                            <asp:ListItem Value="0" Text="اختر الخطة" Selected="True" />

                                        </asp:DropDownList>
                                    </div>

                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" InitialValue=" " ControlToValidate="DropYearU" runat="server" ValidationGroup="GU" ForeColor="#ff3c3c" ErrorMessage="مطلوب تحديد الإدارة العليا    *"></asp:RequiredFieldValidator>
                                </div>

                                <div class="col-lg-6">
                                    <h4 class="box-title">الإدارة العليا</h4>
                                    <div style="width: 310px;">
                                        <asp:DropDownList class="chosen-select chosen-rtl form-control" ID="SectorU" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="SectorU_SelectedIndexChanged" runat="server" data-placeholder="الإدارات عليا">
                                            <asp:ListItem Value="0" Text="اختر إدارة عليا" Selected="True" />

                                        </asp:DropDownList>
                                    </div>

                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" InitialValue=" " ControlToValidate="SectorU" runat="server" ValidationGroup="GU" ForeColor="#ff3c3c" ErrorMessage="مطلوب تحديد الإدارة العليا    *"></asp:RequiredFieldValidator>
                                </div>

                            </div>
                            <div class="col-lg-12">
                                <div class="col-lg-6">
                                    <h4 class="box-title">الإدارة متوسطة</h4>
                                    <div style="width: 310px;">
                                        <asp:DropDownList class="chosen-select chosen-rtl form-control" AppendDataBoundItems="true" ID="MangU" runat="server" data-placeholder="الإدارات المتوسطة">
                                        </asp:DropDownList>
                                    </div>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" InitialValue=" " ControlToValidate="MangU" runat="server" ValidationGroup="GU" ForeColor="#ff3c3c" ErrorMessage="مطلوب تحديد الادارة    *"></asp:RequiredFieldValidator>

                                </div>
                                <div class="col-lg-6" style="width: 510px;">
                                    <h4 class="box-title">اسم التقرير</h4>
                                    <div>
                                        <input runat="server" type="text" id="FileNameU" placeholder="اسم التقرير" class="form-control text col-xs-10 col-sm-10" multiple="multiple" aria-multiline="true" />

                                    </div>

                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" InitialValue=" " ControlToValidate="FileNameU" runat="server" ValidationGroup="GU" ForeColor="#ff3c3c" ErrorMessage="مطلوب تحديد الاسم للتقرير    *"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <div class="form-group">
                        <div class="col-lg-12">
                            <div class="col-lg-6">
                                <h4 class="box-title">الملف</h4>
                                <div>
                                    <span>
                                        
                                    </span>
                                    <asp:HyperLink ID="LinkFile" runat="server"></asp:HyperLink>
                                </div>
                            </div>
                            <div class="col-lg-6">
                                <h4 class="box-title">تغيير الملف</h4>
                                <div class="btn btn-primary btn-sm right" style="width: 350px;">
                                    <span>Select file</span>
                                    <asp:FileUpload ID="FileUpload2" runat="server" CssClass="file2U" />
                                </div>
                            </div>
                        </div>




                    </div>
                </div>
                <div class="modal-footer">
                    <asp:Label ID="RettU" runat="server" Text="" ForeColor="#ff3c3c"></asp:Label>
                    <asp:ImageButton ID="Update" OnClick="Update_Click" ValidationGroup="GU" Height="51" runat="server" src="assets/icons/buttons/report2.png" />
                    <asp:ImageButton ID="ImageButton2" OnClick="BackCharts_Click" Height="51" runat="server" src="assets/icons/buttons/back2.png" />
                </div>

            </div>
            <div >
              <asp:LinkButton ID="BackCharts" runat="server" OnClick="BackCharts_Click" Style="float: left;margin-top:-10px;"><i class="ace-icon fa fa-arrow-left icon-only purple bigger-250"></i></asp:LinkButton>
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



            $('#Del_modal').on('show.bs.modal', function (e) {
                var bookId = $(e.relatedTarget).data('book-id');
                $(e.currentTarget).find($("#<%=bookId.ClientID%>")).val(bookId);


            });







        }


        jQuery(function ($) {

            $('#Del_modal').on('show.bs.modal', function (e) {
                var bookId = $(e.relatedTarget).data('book-id');
                $(e.currentTarget).find($("#<%=bookId.ClientID%>")).val(bookId);


            });

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



        });


    </script>
</asp:Content>
