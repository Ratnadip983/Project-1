<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestTypeEntryUI.aspx.cs" Inherits="BillingManagmentOfDiagonosticCenterApp.UI.TestTypeEntryUI" %>

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
        <!--Main Contant-->
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
                        <li><a href="TypeWiseReportUI.aspx"><i class="glyphicon glyphicon-file"></i> Type Wise Report</a></li>
                        <li><a href="DueBillReportUI.aspx"><i class="glyphicon glyphicon-shopping-cart"></i> Unpaid Bill Report</a></li>
                    </ul>
                </div>
            </div>

            <div class="col-lg-9">
                <!--Main Contant-->
                <div class="row">
                    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12 col-md-offset-3">

                        <!--Alart Text Sectio-->
                        <div id="testTypeDangerDiv" runat="server" visible="false">
                            <div class="alert alert-danger" role="alert">
                                <asp:Label ID="testTypeDangerAlartLabel" runat="server" Text=""></asp:Label>
                            </div>
                        </div>

                        <div id="testTypeSuccessfullDiv" runat="server" visible="false">
                            <div class="alert alert-success" role="alert">
                                <asp:Label ID="testTypeSuccessfullAlartLabel" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                        <!--End of Alart Section-->

                        <!--Test Type Setup Section-->
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h3>Test Type Setup</h3>
                            </div>
                            <div class="panel-body">
                                <div class="col-lg-3">
                                    <label>Type Name</label>
                                </div>
                                <div class="col-lg-9">
                                    <input placeholder="Type Name" type="text" id="testTypeNameTextBox" value=" " runat="server" class="form-control" />
                                </div>
                                <div class="col-lg-2 pull-right space">
                                    <asp:Button runat="server" ID="testTypeSaveButton" CssClass="btn btn-default" Text="Save" OnClick="testTypeSaveButton_Click" />
                                </div>
                            </div>
                        </div>

                        <!--End Test Type Setup Section-->
                    </div>
                </div>
                <div class="row">
                    <!--Show All Test Type Here-->
                    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12 col-md-offset-3">
                        <asp:GridView ID="testTypeShowGridView" runat="server" AutoGenerateColumns="False"
                            CssClass="col-lg-12 col-md-12 col-sm-12 col-xs-12 table table-bordered">
                            <HeaderStyle BackColor="#f5f5f5" ForeColor="Black" />
                            <Columns>
                                <asp:TemplateField HeaderText="Serial No">
                                    <ItemTemplate>
                                        <asp:Label runat="server"><%#Container.DataItemIndex+1 %></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Type Name">
                                    <ItemTemplate>
                                        <asp:Label runat="server"><%#Eval("Name") %></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>

                    <!--End of Show All Test Type Here-->
                </div>


                <!--End of main containt-->

            </div>

        </div>
        <!--End Main Contant-->
        <div class="container responsive-container">
        </div>
    </form>

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <script src="../Bootstrap/js/bootstrap.js"></script>
    <script src="../Bootstrap/js/Customize.js"></script>

</body>
</html>
