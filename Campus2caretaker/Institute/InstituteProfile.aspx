<%@ Page Title="Institute Profile" Language="C#" MasterPageFile="~/Institute/Institute.Master" AutoEventWireup="true" CodeBehind="InstituteProfile.aspx.cs" Inherits="Campus2caretaker.Institute.InstituteProfile" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- block -->
    <div class="block">
        <div class="navbar navbar-inner block-header">
            <div class="muted pull-left">Institute Profile</div>
        </div>
        <div class="block-content collapse in">
            <div class="span12">
                <form class="form-horizontal">
                    <fieldset>
                        <legend>Institute Profile</legend>
                        <div class="control-group">
                            <asp:Label runat="server" CssClass="control-label" AssociatedControlID="txtAddress"> Address</asp:Label>
                            <div class="controls">
                                <asp:TextBox ID="txtAddress" runat="server" CssClass="input-xlarge disabled" Enabled="false" TextMode="MultiLine" Rows="3" Columns="30"></asp:TextBox>
                            </div>
                            <asp:Label runat="server" CssClass="control-label" AssociatedControlID="txtContactNumber"> Contact Number</asp:Label>
                            <div class="controls">
                                <asp:TextBox ID="txtContactNumber" runat="server" CssClass="input-xlarge disabled" Enabled="false"></asp:TextBox>
                            </div>
                            <asp:Label runat="server" CssClass="control-label" AssociatedControlID="txtPrincipalName"> Principal Name</asp:Label>
                            <div class="controls">
                                <asp:TextBox ID="txtPrincipalName" runat="server" CssClass="input-xlarge disabled" Enabled="false"></asp:TextBox>
                            </div>
                            <asp:Label runat="server" CssClass="control-label" AssociatedControlID="txtPrincipalContactNumber"> Principal Contact Number</asp:Label>
                            <div class="controls">
                                <asp:TextBox ID="txtPrincipalContactNumber" runat="server" CssClass="input-xlarge disabled" Enabled="false"></asp:TextBox>
                            </div>
                            <asp:Label runat="server" CssClass="control-label" AssociatedControlID="txtC2CContact"> Contact C2C @</asp:Label>
                            <div class="controls">
                                <asp:TextBox ID="txtC2CContact" runat="server" CssClass="input-xlarge disabled" Enabled="false"></asp:TextBox>
                            </div>
                        </div>
                    </fieldset>
                </form>

            </div>
        </div>
    </div>
    <!-- /block -->
</asp:Content>

