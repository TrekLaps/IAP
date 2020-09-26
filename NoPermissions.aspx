<%@ page title="" language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" CodeFile="~/NoPermissions.aspx.cs" inherits="NoPermissions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageTitle" Runat="Server">
    ليس لديك صلاحيات كافية
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageContent" Runat="Server">

    <div class="row">
							<div class="col-xs-12">
								<!-- PAGE CONTENT BEGINS -->

								<div class="error-container">
									<div class="well">
										<h1 class="grey lighter smaller">
											<span class="red bigger-125">
												<i class="ace-icon fa fa-user-times"></i>
												
											</span>
											ليس لديك صلاحيات كافية !!!
										</h1>

										
										

										<hr />
										<div class="space"></div>

										<div class="center">
											<a href="Login.aspx" class="btn btn-grey">
												<i class="ace-icon fa fa-arrow-left"></i>
												تسجيل دخول
											</a>

											<a href="MainPage.aspx" class="btn btn-primary">
												<i class="ace-icon fa fa-tachometer"></i>
												الصفحة الرئيسية
											</a>
										</div>
									</div>
								</div>

								<!-- PAGE CONTENT ENDS -->
							</div><!-- /.col -->
						</div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Javascript" Runat="Server">
</asp:Content>

