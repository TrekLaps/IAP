<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SectionAdminsCharts.aspx.cs" Inherits="SectionAdminsCharts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
    <script src="js/jquery.stickyheader.js"></script>
    <script src="js/Pie.js"></script>
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageTitle" Runat="Server">
    نتائج معالجة الملاحظات
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageContent" Runat="Server">
     <!-- Admins List--> <h3>
        
        <span runat="server" id="PagTitle">مستوى الأهمية للملاحظات تبعا للإدارة عليا</span>
    </h3>
                        <div id="AdminsCharts"  class="MainBox" >
                        
                          
                             <div align='center'>
      
                           
                            <asp:DataList ID="AdminsChartsList" runat="server" RepeatDirection="Horizontal"  CssClass="center" CellPadding="0" CellSpacing="0" ItemStyle-CssClass="center padding-0" RepeatColumns="2" OnItemDataBound="AdminsChartsList_ItemDataBound">

                                <ItemTemplate>


                                    <div style="color: #070707; direction: ltr; display: inline-block; text-align: center; background-color: #FFFFFF; border: 1px solid #D8D8D8; margin: 25px;padding-right:25px;  height: 350px; width: 475px; text-align: center;">

                                        <div align='center' style="color: #070707;">
                                            <h4>
                                                <asp:Label ID="Label2" runat="server" Text='<%#Eval("AdmName") %>'></asp:Label>
                                            </h4>
                                        </div>
                                        <asp:Label ID="RepAdms" Visible="false" runat="server" Text='<%# Eval("AdmID") %>'></asp:Label>

                                        <div class="row">

                                            <div class="col-xs-4" style="z-index: 999; font-size: 20px; margin-top: 55px;">
                                                    <div class="row" style="background: none;">
                                                        <div class="col-xs-3">
                                                            <img src="assets/icons/levels/L1/high2.png" height="25" />
                                                        </div>
                                                        <div class="col-xs-9" style="text-align: right;">مرتفعة</div>
                                                    </div>
                                                    <div class="row" style="background: none; margin-bottom: 2px;">
                                                        <div class="col-xs-3">
                                                            <img src="assets/icons/levels/L1/low2.png" height="25" />
                                                        </div>
                                                        <div class="col-xs-9" style="text-align: right;">متوسطة</div>
                                                    </div>

                                                    <div class="row" style="background: none; margin-bottom: 2px;">
                                                        <div class="col-xs-3">
                                                            <img src="assets/icons/levels/L1/mid2.png" height="25" />
                                                        </div>
                                                        <div class="col-xs-9" style="text-align: right;">منخفضة</div>
                                                    </div>

                                                </div>
                                            <div class="col-xs-8">
                                                <div style="text-align: center;" align='center'>

                                                    <asp:Literal ID="LtAdm" runat="server"></asp:Literal>
                                                    <div id='Admins<%# Eval("AdmID") %>'></div>
                                                </div>
                                            </div>
                                        </div>
                                        <h4><asp:Label ID="Label1" runat="server" Text='<%#string.Concat(Eval("TotalCount")," عدد الملاحظات") %>'></asp:Label></h4>
                                    </div>



                                </ItemTemplate>

                            </asp:DataList>


                                 
                            <div >
                                <asp:LinkButton ID="LinkButton2" runat="server" OnClick="BackCharts_Click" Style="float: left;margin-top:-10px;"><i class="ace-icon fa fa-arrow-left icon-only purple bigger-250"></i></asp:LinkButton>

                            </div></div>
                       
</div>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Javascript" Runat="Server">
</asp:Content>

