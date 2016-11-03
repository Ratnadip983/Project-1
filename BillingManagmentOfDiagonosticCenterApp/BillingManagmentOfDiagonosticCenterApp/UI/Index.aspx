<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="BillingManagmentOfDiagonosticCenterApp.UI.Index" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <title>Diagosusting Center Managment</title>

    <!-- Bootstrap core CSS -->
    <link href="../Bootstrap/css/bootstrap.min.css" rel="stylesheet">
    <link href="../Bootstrap/css/Customize.css" rel="stylesheet" />

    <!--[if lt IE 9]><script src="../Bootstrap/js/Customize.js"></script><![endif]-->
    <script src="../Bootstrap/js/Customize.js"></script>

    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
      <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->
</head>

<body class="page_color">
    <form id="form1" runat="server">
        <div class="container">
            <div class="row panel_postion">
                <div class="col-lg-4 col-md-4 col-sm-8 col-xs-12 col-lg-offset-4 col-md-offset-3 col-sm-offset-2">
                    <div class="panel panel-success">
                        <div class="panel-heading">
                            <h1 class="text-center">Please Sign In</h1>

                        </div>
                        <div class="panel-body">
                            <div class="col-lg-12">
                                <input type="text" value="" id="userNameTextBox" runat="server" class="form-control" placeholder="User Name" required autofocus />
                                <input type="password" value="" id="passTextBox" runat="server" class="form-control space" placeholder="Password" required />
                                <asp:Label ID="loginFaildLabel" runat="server" Text="" CssClass="text-danger text-center space"></asp:Label>
                                <div class="checkbox">
                                    <label>
                                        <input type="checkbox" runat="server" id="remaindMeCheckBox" value="remember-me" />
                                        Remember me
                                    </label>
                                </div>
                                <asp:Button ID="submitButton" runat="server" Text="Submit" CssClass="btn btn-success btn-block" OnClick="submitButton_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
