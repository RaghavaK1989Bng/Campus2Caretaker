<%@ Page Title="Change Password" Language="C#" MasterPageFile="~/Institute/Institute.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="Campus2caretaker.Institute.ChangePassword" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- block -->
    <div class="block">
        <div class="navbar navbar-inner block-header">
            <div class="muted pull-left">Change Password</div>
        </div>
        <div class="block-content collapse in">
            <div class="span12">
                <form class="form-horizontal">
                    <fieldset>
                        <legend>Change Password</legend>
                        <div class="control-group">
                            <asp:Label runat="server" CssClass="control-label" AssociatedControlID="txtCurrentPassword"> Current Password <span class="required">*</span></asp:Label>
                            <div class="controls">
                                <asp:TextBox ID="txtCurrentPassword" runat="server" CssClass="input-xlarge focused" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="CurrentPasswordRequired" runat="server"
                                    ControlToValidate="txtCurrentPassword" ErrorMessage="Current Password is required."
                                    ToolTip="Current Password is required." ValidationGroup="ChangePassword"
                                    ForeColor="#FF3300">*</asp:RequiredFieldValidator>
                            </div>
                            <asp:Label runat="server" CssClass="control-label" AssociatedControlID="txtNewPassword"> New Password <span class="required">*</span></asp:Label>
                            <div class="controls">
                                <asp:TextBox ID="txtNewPassword" runat="server" CssClass="input-xlarge focused" TextMode="Password"></asp:TextBox>
                                 <asp:RequiredFieldValidator ID="NewPasswordRequired" runat="server"
                                    ControlToValidate="txtNewPassword" ErrorMessage="New Password is required."
                                    ToolTip="New Password is required." ValidationGroup="ChangePassword"
                                    ForeColor="#FF3300">*</asp:RequiredFieldValidator>
                            </div>
                            <asp:Label runat="server" CssClass="control-label" AssociatedControlID="txtConfirmPassword" > Confirm Password <span class="required">*</span></asp:Label>
                            <div class="controls">
                                <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="input-xlarge focused" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ConfirmPasswordRequired" runat="server"
                                    ControlToValidate="txtConfirmPassword" ErrorMessage="Confirm Password is required."
                                    ToolTip="Confirm Password is required." ValidationGroup="ChangePassword"
                                    ForeColor="#FF3300">*</asp:RequiredFieldValidator>
                            </div>
                            <asp:CompareValidator ID="RegularExpressionValidator1" runat="server"
                                    ControlToValidate="txtConfirmPassword" ErrorMessage="New and Confirm Password donot match."
                                    ToolTip="New and Confirm Password donot match" ValidationGroup="ChangePassword"
                                    ForeColor="#FF3300" ControlToCompare="txtNewPassword">*</asp:CompareValidator>
                        </div>
                                                <div class="form-actions">
                            <div id="divStatus" runat="server"></div>
                            <asp:Button ID="btnChangePassword" runat="server" CssClass="btn btn-info" Text="Change Password" ValidationGroup="ChangePassword"
                                OnClick="btnChangePassword_Click" />
                            &nbsp;
                                          <asp:Button ID="btnClear" runat="server" CssClass="btn btn-info"
                                              Text="Cancel" OnClick="btnClear_Click"
                                              meta:resourcekey="btnClearResource1" />
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server"
                                ShowMessageBox="false" ValidationGroup="ChangePassword" ForeColor="Red"
                                ShowSummary="true" meta:resourcekey="ValidationSummary1Resource1" HeaderText="Please fix the following errors :" />
                        </div>
                    </fieldset>
                </form>

            </div>
        </div>
    </div>
    <!-- /block -->
</asp:Content>
