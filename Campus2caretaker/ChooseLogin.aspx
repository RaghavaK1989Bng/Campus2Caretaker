﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChooseLogin.aspx.cs" Inherits="Campus2caretaker.ChooseLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link href="css/oldCSS/style.css" rel="stylesheet" type="text/css" media="all" />
    <title>Choose Login</title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align:center;">
        <div style="width:100%; margin: 0 auto; text-align:center;"  class="defaultPagetable">
    <table border="2">
    <%--<tr style="visibility:hidden;">
    <td><a href="AdminLogin.aspx">Administrator Login</a></td>
    </tr>--%>
        <tr>
    <td><a href="Institute/InstituteLogin.aspx">Institute Login</a></td>
    </tr>
        <tr>
    <td><a href="Parents/ParentsLogin.aspx">Parents Login</a></td>
    </tr>
    </table>
    </div>
        </div>
    </form>
</body>
</html>
