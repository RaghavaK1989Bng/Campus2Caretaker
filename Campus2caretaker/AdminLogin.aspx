<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="Campus2caretaker.AdminLogin" Title="Administrator Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <style type="text/css">
        .style1
        {
            width: 138px;
        }
        .titletext
        {
            font-family:  'Hoefler Text', Georgia, 'Times New Roman', serif;
	font-weight: bold;
	font-style:italic;
        font-size: 1.45em;
	letter-spacing: .15em;
	line-height: 1.1em;
	margin:0px;
	text-align: center;
	text-transform: capitalize;
        }
    .login_button {
	-moz-box-shadow:inset 0px 1px 0px 0px #ffffff;
	-webkit-box-shadow:inset 0px 1px 0px 0px #ffffff;
	box-shadow:inset 0px 1px 0px 0px #ffffff;
	background:-webkit-gradient( linear, left top, left bottom, color-stop(0.05, #ededed), color-stop(1, #dfdfdf) );
	background:-moz-linear-gradient( center top, #ededed 5%, #dfdfdf 100% );
	filter:progid:DXImageTransform.Microsoft.gradient(startColorstr='#ededed', endColorstr='#dfdfdf');
	background-color:#ededed;
	-moz-border-radius:6px;
	-webkit-border-radius:6px;
	border-radius:6px;
	border:1px solid #dcdcdc;
	display:inline-block;
	color:#777777;
	font-family:arial;
	font-size:15px;
	font-weight:bold;
	padding:6px 24px;
	text-decoration:none;
	text-shadow:1px 1px 0px #ffffff;
}.login_button:hover {
	background:-webkit-gradient( linear, left top, left bottom, color-stop(0.05, #dfdfdf), color-stop(1, #ededed) );
	background:-moz-linear-gradient( center top, #dfdfdf 5%, #ededed 100% );
	filter:progid:DXImageTransform.Microsoft.gradient(startColorstr='#dfdfdf', endColorstr='#ededed');
	background-color:#dfdfdf;
}.login_button:active {
	position:relative;
	top:1px;
}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <br />
    <div style="text-align: center;">
    <div style="text-align: center;">
        <img src="images/newlogo.png" />
    </div>
    <br />
    <div style="text-align: center;" class="titletext">
        &nbsp;<asp:Label ID="Label2" runat="server" meta:resourcekey="Label2Resource1" 
            Text="Administrator LogIn"></asp:Label>
        </div>
    <div style="width: 387px; margin-left: auto; margin-right:auto;">

    &nbsp;

    <asp:Login ID="Login1" runat="server" BackColor="#F7F7DE" BorderColor="#CCCC99"
    BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="10pt" 
            RememberMeSet="True" Height="165px" Width="383px" 
            onauthenticate="Login1_Authenticate" meta:resourcekey="Login1Resource1">
    <TitleTextStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
    <FailureTextStyle ForeColor="Red"></FailureTextStyle>
    <LayoutTemplate>
        <table border="0" cellpadding="1" cellspacing="0" 
            style="border-collapse: collapse; width: 381px;">
            <tr>
                <td align="right" class="style1">
                    <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName" 
                        meta:resourcekey="UserNameLabelResource1">User Name:</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="UserName" runat="server" TabIndex="1" 
                        meta:resourcekey="UserNameResource1"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" 
                        ControlToValidate="UserName" ErrorMessage="User Name is required." 
                        ToolTip="User Name is required." ValidationGroup="Login1" 
                        meta:resourcekey="UserNameRequiredResource1">*</asp:RequiredFieldValidator>
                </td>
                <td align="center" style="padding:15px;">
                                    </td>
            </tr>
            <tr>
                </td>
                <td align="right" class="style1">
                    <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password" 
                        meta:resourcekey="PasswordLabelResource1">Password:</asp:Label></td>
                <td>
                    <asp:TextBox ID="Password" runat="server" TextMode="Password" TabIndex="2" 
                        meta:resourcekey="PasswordResource1"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                        ErrorMessage="Password is required." ToolTip="Password is required." 
                        ValidationGroup="Login1" meta:resourcekey="PasswordRequiredResource1">*</asp:RequiredFieldValidator>
                </td>
                <td align="center" style="padding:15px;">
                </td>
            </tr>
            <tr>
                </td>
                <td class="style1"> </td>
                <td>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Log In"
                        ValidationGroup="Login1" TabIndex="4" CssClass="login_button" 
                        meta:resourcekey="LoginButtonResource1" />

                </td>
                <td align="center" style="padding:15px;">
                </td>
            </tr>
            <tr>
                
                <td colspan="2" align="center">
                    <asp:CheckBox ID="RememberMe" runat="server" Text="Remember me next time." 
                        TabIndex="3" meta:resourcekey="RememberMeResource1" />
                </td>
                <td></td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Label id="FailureText" ForeColor="Red" runat="server" 
                        meta:resourcekey="FailureTextResource1"></asp:Label>
                </td>
            </tr>
        </table>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
            ShowMessageBox="True" ValidationGroup="Login1"
                ShowSummary="False" meta:resourcekey="ValidationSummary1Resource1" />
    </LayoutTemplate>
</asp:Login>

    </div>
    </div>
    </form>
</body>
</html>
