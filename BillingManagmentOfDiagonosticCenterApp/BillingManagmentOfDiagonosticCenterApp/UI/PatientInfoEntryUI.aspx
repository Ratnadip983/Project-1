<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PatientInfoEntryUI.aspx.cs" Inherits="BillingManagmentOfDiagonosticCenterApp.UI.PatientInfoEntryUI" %>

<!DOCTYPE html>

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
                            <asp:Button runat="server" ID="logoutButton" CssClass="btn btn-default text-center" Text="Logout" OnClick="logoutButton_Click" />
                        </a></li>
                    </ul>
                </div>
            </div>
        </nav>
        <!--End Of Nav-->

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
                    <asp:Label runat="server" ID="successLabel"></asp:Label>
             
                <!--Main Contant-->

                <div class="row">
                    <div class="col-lg-8 col-md-8 col-sm-12 col-xs-12 col-lg-offset-2 col-md-offset-1">

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

                        <!--Patent Information Section-->
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h2>Test Request Entry</h2>
                            </div>
                            <div class="panel-body">

                                <div class="row">
                                    <div class="col-lg-12">
                                        <div class="col-lg-5">
                                            <label>Name Of the Patient</label>
                                        </div>
                                        <div class="col-lg-7">
                                            <input type="text" id="nameTextBox" value=" " runat="server" class="form-control" />
                                        </div>
                                    </div>
                                    <div class="col-lg-12 space">
                                        <div class="col-lg-5">
                                            <label>Date Of Barth</label>
                                        </div>
                                        <div class="col-lg-7">
                                            <input type="date" id="dateOfBirthTextBox" class="form-control" runat="server" />
                                        </div>
                                    </div>
                                    <div class="col-lg-12 space">
                                        <div class="col-lg-5">
                                            <label>Mobile Number</label>
                                        </div>
                                        <div class="col-lg-7">
                                            <input type="number" id="mobileTextBox" value=" " runat="server" class="form-control" />
                                        </div>
                                    </div>
                                    <div class="col-lg-12 space">
                                        <div class="col-lg-5">
                                            <label>Select Test</label>
                                        </div>
                                        <div class="col-lg-7">
                                            <asp:DropDownList runat="server" ID="testSelectDropDownList" CssClass="btn btn-default " Width="258px" AutoPostBack="True" OnSelectedIndexChanged="testSelectDropDownList_SelectedIndexChanged" />
                                        </div>
                                    </div>
                                    <div class=" col-lg-6 col-lg-offset-7 space">
                                        <div class="col-lg-4">
                                            <label>Fee</label>
                                        </div>
                                        <div class="col-lg-6 ">
                                            <input type="text" id="feeTextBox" value=" " runat="server" class="form-control" />
                                        </div>
                                    </div>

                                    <div class="col-lg-2 pull-right space">
                                        <asp:Button runat="server" ID="addGridviewButton" CssClass="btn btn-default" Text="Add" OnClick="addGridviewButton_Click" />
                                    </div>

                                </div>

                                <div class="row">
                                    <!--Start of GrideView Section Section-->
                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 space fixd_gridview_patient" id="gridViewControl" style="height: auto">
                                        <asp:GridView ID="testShowGridView" runat="server" AutoGenerateColumns="False"
                                            CssClass="col-lg-12 col-md-12 col-sm-12 col-xs-12 table table-bordered" HeaderStyle="#CDDAD7;">
                                            <HeaderStyle BackColor="#f5f5f5" ForeColor="Black" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="SL NO">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server"><%#Container.DataItemIndex+1 %></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Test">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server"><%#Eval("Name") %></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Fee">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server"><%#Eval("Fee") %></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                    <!--End of GrideView Section Section-->
                                </div>
                                <div class="row">
                                    <div class=" col-lg-6 col-lg-offset-7 space">
                                        <div class="col-lg-4">
                                            <label>Total</label>
                                        </div>
                                        <div class="col-lg-6 ">
                                            <input type="text" id="totalTextBox" value=" " runat="server" class="form-control" />
                                        </div>
                                    </div>
                                    <div class=" col-lg-6 col-lg-offset-7 space">
                                        <div class="col-lg-4"></div>
                                        <div class="col-lg-6 pull-right">
                                            <asp:Button runat="server" ID="saveButton" CssClass="btn btn-default" Text="Save" OnClick="saveButton_Click" />
                                        </div>

                                    </div>

                                </div>
                            </div>
                        </div>

                        <!--Patent Information Section-->
                    </div>
                </div>

                <!--End of main containt-->

            </div>

        </div>
        <!--End Main Contant-->
    </form>

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <script src="../Bootstrap/js/bootstrap.js"></script>
    <script src="../Bootstrap/js/Customize.js"></script>

</body>
</html>
