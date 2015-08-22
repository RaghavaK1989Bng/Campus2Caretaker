<%@ Page Title="SMS" Language="C#" MasterPageFile="~/Institute/Institute.Master" AutoEventWireup="true" CodeBehind="SendSMS.aspx.cs" Inherits="Campus2caretaker.Institute.SendSMS" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Button ID="btnSend" runat="server" CssClass="btn btn-info" Text="Send"
                                OnClick="btnSend_Click" ValidationGroup="SMS" />
</asp:Content>
