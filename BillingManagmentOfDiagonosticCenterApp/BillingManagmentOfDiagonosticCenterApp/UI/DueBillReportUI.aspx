﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DueBillReportUI.aspx.cs" Inherits="BillingManagmentOfDiagonosticCenterApp.UI.DueBillReportUI" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Diagosusting Center Managment</title>

    <!-- Bootstrap and Customize Css add section -->
    <link href="../Bootstrap/css/bootstrap.min.css" rel="stylesheet">
    <link href="../Bootstrap/css/Customize.css" rel="stylesheet" />

    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
      <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->
</head>
<body>
    <form id="form1" runat="server">
        <!--Nav Section-->
        <nav class="navbar navbar-default">
            <div class="container-fluid">
                <div class="navbar-header">
                    <button type="button" class="navbar-toggle collapsed pull-left" data-toggle="collapse" data-target="#bscollapse" aria-expanded="false">
                        <span class="sr-only">Toggle navigation</span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </button>
                    <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navbar-collapse" aria-expanded="false">
                        <span class="sr-only">Toggle navigation</span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </button>
                    <a class="navbar-brand" href="PatientInfoEntryUI.aspx">Bill Management System</a>
                </div>


                <div class="collapse navbar-collapse" id="navbar-collapse">
                    <ul class="nav navbar-nav navbar-right">
                        <li><a href="#">
                            <asp:Button runat="server" ID="logoutButton" CssClass="btn btn-default text-center" Text="Logout" OnClick="logoutButton_OnClick" />
                        </a></li>
                    </ul>
                </div>
            </div>
        </nav>
        <!--End Of Nav Section-->

        <!--Main Content-->
        <div class="row">
            <div class="col-lg-3 col-md-3 ">
                <div class="collapse navbar-collapse" id="bscollapse">
                    <ul class="navbar-default nav" style="height: 600px">
                        <li><a href="#"><i class="glyphicon glyphicon-dashboard"></i> Dashboard</a></li>
                        <li>
                            <a href="#new-Item" data-toggle="collapse" aria-haspopup="true" aria-expanded="False">
                                <i class="glyphicon glyphicon-plus"></i> New Item
                            </a>
                            <ul class="nav collapse" id="new-Item">
                                <li><a href="TestTypeEntryUI.aspx">
                                    <div class="col-sm-1"></div>
                                    <i class="glyphicon glyphicon-pencil"></i> Type Entry</a></li>
                                <li><a href="TestEntryUI.aspx">
                                    <div class="col-sm-1"></div>
                                    <i class="glyphicon glyphicon-edit"></i> Test Entry</a></li>
                                <li><a href="PatientInfoEntryUI.aspx">
                                    <div class="col-sm-1"></div>
                                    <i class="glyphicon glyphicon-edit"></i> Patient Info</a></li>
                            </ul>
                        </li>
                        <li><a href="AmountInfoUI.aspx"><i class="glyphicon glyphicon-usd"></i> Payment Info</a></li>
                        <li><a href="TestWiseReportUI.aspx"><i class="glyphicon glyphicon-file"></i> Test Wise Report</a></li>
                        <li><a href="TypeWiseReportUI.aspx"><i class="glyphicon glyphicon-file"></i>T ype Wise Report</a></li>
                        <li><a href="DueBillReportUI.aspx"><i class="glyphicon glyphicon-shopping-cart"></i> Unpaid Bill Report</a></li>
                    </ul>
                </div>
            </div>

            <div class="col-lg-9">

                <!--Main Contant-->

                <div class="row">
                    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12 col-md-offset-3">

                        <!--UnPaide Bill Section-->
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h1>Unpaid Bill Report</h1>
                            </div>
                            <div class="panel-body">
                                <div class="panel panel-default">
                                    <div class="panel-body">
                                        <div class="col-lg-12">
                                            <div class="col-lg-3">
                                                <label>From Date</label>
                                            </div>
                                            <div class="col-lg-6">
                                                <input type="date" id="lowerDateTextBox" value=" " runat="server" class="form-control" />
                                            </div>
                                            <div class="col-lg-3"></div>
                                        </div>
                                        <div class="col-lg-12 space">
                                            <div class="col-lg-3">
                                                <label>To Date</label>
                                            </div>
                                            <div class="col-lg-6">
                                                <input type="date" id="upperDateTextBox" value=" " runat="server" class="form-control" />
                                            </div>
                                            <div class="col-lg-3">
                                                <asp:Button runat="server" ID="reportShowButton" CssClass="btn btn-default" Text="Show" OnClick="reportShowButton_Click" />
                                            </div>
                                        </div>


                                        <div class="col-lg-12">
                                            <!--Start of GrideView Section Section-->
                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 space" id="gridViewControl" style="height: auto">
                                                <asp:GridView ID="billShowGridView" runat="server" AutoGenerateColumns="False"
                                                    CssClass="col-lg-12 col-md-12 col-sm-12 col-xs-12 table table-bordered" HeaderStyle="#CDDAD7;">
                                                    <HeaderStyle BackColor="#f5f5f5" ForeColor="Black" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="SL NO">
                                                            <ItemTemplate>
                                                                <asp:Label runat="server"><%#Container.DataItemIndex+1 %></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Bill Number">
                                                            <ItemTemplate>
                                                                <asp:Label runat="server"><%#Eval("BillNo") %></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Contract Number">
                                                            <ItemTemplate>
                                                                <asp:Label runat="server"><%#Eval("ContactNo") %></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Patient Name">
                                                            <ItemTemplate>
                                                                <asp:Label runat="server"><%#Eval("PatientName") %></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Bill Amount">
                                                            <ItemTemplate>
                                                                <asp:Label runat="server"><%#Eval("BillAmount") %></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                            <!--End of GrideView Section Section-->
                                        </div>

                                        <div class="col-lg-12 space">
                                            <div class="col-lg-6">
                                                <div class="col-lg-8"></div>
                                                <div class="col-lg-4">
                                                    <asp:Button runat="server" ID="pdfButton" CssClass="btn btn-default" Text="PDF" OnClick="pdfButton_Click" />
                                                </div>
                                            </div>
                                            <div class="col-lg-6 pull-right">
                                                <div class="col-lg-4">
                                                    <label>Total</label>
                                                </div>
                                                <div class="col-lg-8">
                                                    <input type="text" id="totalAmountTextBox" value=" " runat="server" class="form-control" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <!--End Of UnPaide Bill Section-->
                    </div>
                </div>

                <!--End of main containt-->

            </div>

        </div>
        <!--End Main Content-->
    </form>

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <script src="../Bootstrap/js/bootstrap.js"></script>
    <script src="../Bootstrap/js/Customize.js"></script>

</body>
</html>
