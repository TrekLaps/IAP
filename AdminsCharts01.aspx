<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdminsCharts01.aspx.cs" Inherits="AdminsCharts01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <script type="text/javascript" src="assets/js/loader.js"></script>
    <script src="js/jquery.stickyheader.js"></script>
    <script src="js/Pie.js"></script>
    <script type="text/javascript" src="assets/js/jsapi.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageTitle" Runat="Server">
    نتائج معالجة الملاحظات
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageContent" Runat="Server">
     <!-- Admins List-->
                        <div id="AdminsCharts"  >
                        
                           
                             <div align='center'>
      
                            <h4 class="blue bigger">مستوى الأهمية للملاحظات  </h4>
                            

                                    <div style="color: #070707; direction: ltr; display: inline-block; text-align: center; background-color: #FFFFFF; border: 1px solid #D8D8D8; margin: 25px;padding-right:25px;  height: 350px; width: 475px; text-align: center;">

                                        <div align='center' style="color: #070707;">
                                            مستوى الأهمية
                                        </div>
                                 
                                        <div class="row">

                                            <div class="col-xs-4" style="z-index: 999; margin-top: 55px; ">
                                                <div class="row" style="margin-top: 10px; margin-bottom: 10px;">
                                                    <div class="col-xs-3" style="color: #4CAF50;"><i class="fa fa-circle"></i></div>
                                                    <div class="col-xs-9" style="text-align: right;">منخفضة</div>
                                                </div>
                                                <div class="row" style="margin-top: 10px; margin-bottom: 10px;">
                                                    <div class="col-xs-3" style="color: #FF9800;"><i class="fa fa-circle"></i></div>
                                                    <div class="col-xs-9" style="text-align: right;">متوسطة</div>
                                                </div>
                                                <div class="row" style="margin-top: 10px; margin-bottom: 10px;">
                                                    <div class="col-xs-3" style="color: #9C27B0;"><i class="fa fa-circle"></i></div>
                                                    <div class="col-xs-9" style="text-align: right;">مرتفعة</div>
                                                </div>

                                            </div>
                                            <div class="col-xs-8">
                                                <div style="text-align: center;" align='center'>

                                                    <asp:Literal ID="LtAdm" runat="server"></asp:Literal>
                                                    <div id='Admins<%# Eval("RepAdms") %>'></div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>



                              
  <div >
                                <asp:LinkButton ID="LinkButton2" runat="server" OnClick="BackCharts_Click" Style="float: left;margin-top:-10px;"><i class="ace-icon fa fa-arrow-left icon-only purple bigger-250"></i></asp:LinkButton>

                            </div>

                                 </div>
                          
                       
</div>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Javascript" Runat="Server">
</asp:Content>

