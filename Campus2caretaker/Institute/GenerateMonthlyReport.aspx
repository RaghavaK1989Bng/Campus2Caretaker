<%@ Page Title="Monthly Report" Language="C#" MasterPageFile="~/Institute/Institute.Master" AutoEventWireup="true" CodeBehind="GenerateMonthlyReport.aspx.cs" Inherits="Campus2caretaker.Institute.GenerateMonthlyReport" EnableEventValidation ="false" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="block">
        <div class="navbar navbar-inner block-header">
            <div class="muted pull-left">Monthly Report</div>
        </div>
        <div class="block-content collapse in">
            <div class="span12">
                <form class="form-horizontal">
                    <fieldset>
                        <legend>Generate Monthly Report</legend>
                        <div class="control-group">
                            <label class="control-label"></label>
                            <div class="nav-collapse collapse">
                                    <asp:Label runat="server" CssClass="control-label" AssociatedControlID="ddlMonth">Month</asp:Label>

                                    <div class="controls">

                                        <asp:DropDownList ID="ddlMonth" runat="server" CssClass="chzn-select" ValidationGroup="Attendance">
                                                <asp:ListItem Text="January" Value="January"></asp:ListItem>
                                                <asp:ListItem Text="Febraury" Value="Febraury"></asp:ListItem>
                                                <asp:ListItem Text="March" Value="March"></asp:ListItem>
                                                <asp:ListItem Text="April" Value="April"></asp:ListItem>
                                                <asp:ListItem Text="May" Value="May"></asp:ListItem>
                                                <asp:ListItem Text="June" Value="June"></asp:ListItem>
                                                <asp:ListItem Text="July" Value="July"></asp:ListItem>
                                                <asp:ListItem Text="August" Value="August"></asp:ListItem>
                                                <asp:ListItem Text="September" Value="September"></asp:ListItem>
                                                <asp:ListItem Text="October" Value="October"></asp:ListItem>
                                                <asp:ListItem Text="November" Value="November"></asp:ListItem>
                                                <asp:ListItem Text="December" Value="December"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="MonthSelectionRequired" runat="server"
                                                ControlToValidate="ddlMonth" ErrorMessage="Month Selection is required."
                                                ToolTip="Month Selection is required." ValidationGroup="Report" InitialValue="Select"
                                                ForeColor="#FF3300">*</asp:RequiredFieldValidator>
                                    </div>

                                <asp:Label runat="server" CssClass="control-label" AssociatedControlID="ddlYear">Year</asp:Label>
                                            <div class="controls">

                                                <asp:DropDownList ID="ddlYear" runat="server" CssClass="chzn-select">
                                                    <asp:ListItem Text="2015" Value="2015"></asp:ListItem>
                                                    <asp:ListItem Text="2016" Value="2016"></asp:ListItem>
                                                    <asp:ListItem Text="2017" Value="2017"></asp:ListItem>
                                                    <asp:ListItem Text="2018" Value="2018"></asp:ListItem>
                                                    <asp:ListItem Text="2019" Value="2019"></asp:ListItem>
                                                    <asp:ListItem Text="2020" Value="2020"></asp:ListItem>
                                                    <asp:ListItem Text="2021" Value="2021"></asp:ListItem>
                                                    <asp:ListItem Text="2022" Value="2022"></asp:ListItem>
                                                    <asp:ListItem Text="2023" Value="2023"></asp:ListItem>
                                                    <asp:ListItem Text="2024" Value="2024"></asp:ListItem>
                                                    <asp:ListItem Text="2025" Value="2025"></asp:ListItem>
                                                    <asp:ListItem Text="2026" Value="2026"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="YearSelectionRequired" runat="server"
                                                ControlToValidate="ddlYear" ErrorMessage="Year Selection is required."
                                                ToolTip="Year Selection is required." ValidationGroup="Report" InitialValue="Select"
                                                ForeColor="#FF3300">*</asp:RequiredFieldValidator>
                                            </div>
                        </div>
                            </div>
                        <div class="form-actions">
                            <%--<div id="divStatus" runat="server"></div>--%>
                            <asp:Button ID="btnGenerateReport" runat="server" CssClass="btn btn-info" Text="Generate Report"
                                OnClick="btnGenerateReport_Click" ValidationGroup="Report" />
                             <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
            ShowMessageBox="false" ValidationGroup="Report" ForeColor="Red"
                ShowSummary="true" meta:resourcekey="ValidationSummary1Resource1" HeaderText="Please fix the following errors :" />

                        </div>

                    </fieldset>
                </form>

            </div>
        </div>
    </div>


</asp:Content>
