<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="Campus2caretaker.AdminLogin" Title="Administrator Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Institute Login</title>
    <!-- Bootstrap -->
    <link href="css/bootstrap/css/bootstrap.min.css" rel="stylesheet" media="screen" />
    <link href="css/bootstrap/css/bootstrap-responsive.min.css" rel="stylesheet" media="screen" />
    <link href="css/styles.css" rel="stylesheet" media="screen" />
    <link href="css/bootstrap/css/todc-bootstrap.min.css" rel="stylesheet" media="screen" />

     <!-- HTML5 shim, for IE6-8 support of HTML5 elements -->
    <!--[if lt IE 9]>
      <script src="http://html5shim.googlecode.com/svn/trunk/html5.js"></script>
    <![endif]-->
</head>
 <body id="login">
      <header class="navbar navbar-default navbar-fixed-top">
             
		<div class="container">
            <div class="navbar-header">
				<img src="images/newlogo.png" alt="">
			</div>
			<div class="pull-right">
				<ul class="nav navbar-nav">
            <li style="color:white;vertical-align:middle;text-align:center;">
            School Management Software
            </li>
                </ul>
			</div>
            </div>
          </header>
      <h1></h1>
      <p></p>
    <div class="container">
        
    <form id="form1" runat="server" class="form-signin">
        <h5 align="center">
    <asp:Label ID="Label2" runat="server" meta:resourcekey="Label2Resource1" class="form-signin-heading"
            Text="Log In to Campus2Caretaker"></asp:Label>

            </h5>
        <label for="UserName">Username <span class="required">*</span></label>
        <asp:TextBox ID="UserName" runat="server"
                        meta:resourcekey="UserNameResource1" CssClass="input-block-level" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" 
                        ControlToValidate="UserName" ErrorMessage="User Name is required." 
                        ToolTip="User Name is required." ValidationGroup="Login1" 
                        meta:resourcekey="UserNameRequiredResource1" ForeColor="#FF3300">*</asp:RequiredFieldValidator>

         <label for="Password">Password <span class="required">*</span></label>
        <asp:TextBox ID="Password" runat="server" TextMode="Password" CssClass="input-block-level"
                        meta:resourcekey="PasswordResource1"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                        ErrorMessage="Password is required." ToolTip="Password is required." 
                        ValidationGroup="Login1" meta:resourcekey="PasswordRequiredResource1" ForeColor="Red">*</asp:RequiredFieldValidator>
        <label class="checkbox">
            <input type="checkbox" value="remember-me"> Remember me
            </label>
        
                        <asp:Button ID="LoginButton" runat="server" Text="Sign in"
                        ValidationGroup="Login1" CssClass="btn btn-large btn-primary" 
                        meta:resourcekey="LoginButtonResource1" OnClick="LoginButton_Click" />

        <br />

        <asp:Label id="FailureText" ForeColor="Red" runat="server" 
                        meta:resourcekey="FailureTextResource1"></asp:Label>


        <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
            ShowMessageBox="false" ValidationGroup="Login1" ForeColor="Red"
                ShowSummary="true" meta:resourcekey="ValidationSummary1Resource1" HeaderText="Please fix the following errors :" />
    </form>
        </div>

</body>
</html>
