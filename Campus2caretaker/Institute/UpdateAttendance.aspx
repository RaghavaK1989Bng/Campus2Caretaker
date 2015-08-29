﻿<%@ Page Title="Attendance Details" Language="C#"  MasterPageFile="~/Institute/Institute.Master" AutoEventWireup="true" CodeBehind="UpdateAttendance.aspx.cs" Inherits="Campus2caretaker.Institute.UpdateAttendance" EnableEventValidation="false" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="block">
        <div class="navbar navbar-inner block-header">
            <div class="muted pull-left">Attendance Details</div>
        </div>
        <div class="block-content collapse in">
            <div class="span12">
                <form class="form-horizontal">
                    <fieldset>
                        <legend>Update Attendane Details</legend>
                        <div class="control-group">
                            <asp:Label runat="server" CssClass="control-label"></asp:Label>
                            <div class="controls">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:RadioButton ID="rbNew" runat="server" AutoPostBack="True" Checked="True" GroupName="rbNewEdit" OnCheckedChanged="rbNew_CheckedChanged" Text="New Entry" />
                                        </td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td>
                                            <asp:RadioButton ID="rbEdit" runat="server" AutoPostBack="True" GroupName="rbNewEdit" OnCheckedChanged="rbEdit_CheckedChanged" Text="Edit Entry" />
                                        </td>
                                    </tr>
                                </table>
                            </div>

                            <table>
                                <tr>
                                    <td>
                                        <asp:Label runat="server" CssClass="control-label" AssociatedControlID="ddlClass">Class <span class="required">*</span></asp:Label>
                                        <div class="controls">

                                            <asp:DropDownList ID="ddlClass" ValidationGroup="Attendance" AutoPostBack="true" runat="server" CssClass="chzn-select" DataTextField="colBranchName" DataValueField="colBranchId" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="ClassNameRequired" runat="server"
                                                ControlToValidate="ddlClass" ErrorMessage="Class Selection is required."
                                                ToolTip="Class Selection is required." ValidationGroup="Attendance" InitialValue="Select"
                                                ForeColor="#FF3300">*</asp:RequiredFieldValidator>
                                        </div>
                                    </td>
                                    <td></td>
                                    <td>
                                        <div id="dvSemester" runat="server">
                                            <asp:Label runat="server" CssClass="control-label" AssociatedControlID="ddlSemester">Semester<span class="required">*</span></asp:Label>
                                            <div class="controls">
                                                <asp:DropDownList ID="ddlSemester" runat="server" CssClass="chzn-select">
                                                </asp:DropDownList>

                                            </div>
                                        </div>
                                    </td>
                                    <td></td>

                                    <td>
                                        <div id="dvSubjects" runat="server">
                                            <asp:Label runat="server" CssClass="control-label" AssociatedControlID="ddlSubjects">Subject<span class="required">*</span></asp:Label>
                                            <div class="controls">
                                                <asp:DropDownList ID="ddlSubjects" runat="server" CssClass="chzn-select" ValidationGroup="Attendance" DataTextField="colSubjectName" DataValueField="colSubjectId">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" CssClass="control-label" AssociatedControlID="ddlMonth">Month<span class="required">*</span></asp:Label>
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
                                                ToolTip="Month Selection is required." ValidationGroup="Attendance" InitialValue="Select"
                                                ForeColor="#FF3300">*</asp:RequiredFieldValidator>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label runat="server" CssClass="control-label" AssociatedControlID="ddlYear">Year<span class="required">*</span></asp:Label>
                                        <div class="controls">
                                            <asp:DropDownList ID="ddlYear" runat="server" CssClass="chzn-select" ValidationGroup="Attendance">
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
                                                ToolTip="Year Selection is required." ValidationGroup="Attendance" InitialValue="Select"
                                                ForeColor="#FF3300">*</asp:RequiredFieldValidator>
                                        </div>
                                    </td>

                                    <td>
                                        <asp:Label runat="server" CssClass="control-label" AssociatedControlID="btnGetStudentsList"></asp:Label>
                                        <div class="controls">
                                            <asp:Button ID="btnGetStudentsList" runat="server" CssClass="btn btn-info" Text="Get Students"
                                                OnClick="btnGetStudentsList_Click" ValidationGroup="Attendance" />
                                            <asp:Button ID="btnGetStudentsListEdit" runat="server" CssClass="btn btn-info" Text="Get Students"
                                                OnClick="btnGetStudentsListEdit_Click" ValidationGroup="Attendance" />
                                        </div>
                                    </td>
                                </tr>
                            </table>


                        </div>
                        <div class="form-actions">
                            <div id="divStatus" runat="server"></div>
                            <asp:Button ID="btnSaveAttendance" runat="server" CssClass="btn btn-info" Text="Save Attendance"
                                OnClick="btnSaveAttendance_Click" />
                            &nbsp;
                                          <asp:Button ID="btnClear" runat="server" CssClass="btn btn-info"
                                              Text="Cancel" OnClick="btnClear_Click" />
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server"
                                ShowMessageBox="false" ValidationGroup="Attendance" ForeColor="Red"
                                ShowSummary="true" meta:resourcekey="ValidationSummary1Resource1" HeaderText="Please fix the following errors :" />
                        </div>
                    </fieldset>
                </form>

            </div>
        </div>
        <div class="block-content collapse in">
            <div class="span12">
                <div class="table-toolbar">
                    <div class="btn-group pull-right">
                        <button data-toggle="dropdown" class="btn dropdown-toggle">Options <span class="caret"></span></button>
                        <ul class="dropdown-menu">
                             <li><a href="#" id="lnkpdfdownload" runat="server">Save as PDF</a></li>
                             <li><a href="#" id="lnkexceldownload" runat="server">Export to Excel</a></li>
                        </ul>
                    </div>
                </div>
                <br />
                <br />
                <asp:GridView ID="gvAttendance" runat="server" AutoGenerateColumns="False" AllowPaging="false"
                    ShowHeaderWhenEmpty="True" EmptyDataText="No records Found"
                    AllowSorting="false" Width="100%"
                    CssClass="table table-hover"
                    EnableModelValidation="True" OnRowCommand="gvAttendance_RowCommand"
                    OnDataBound="gvAttendance_DataBound">
                    <Columns>
                        <asp:BoundField DataField="RowNumber" HeaderText="Row Number" ItemStyle-CssClass="text" HeaderStyle-ForeColor="Black" ItemStyle-Width="30px" />
                        <asp:TemplateField HeaderText="Student Name" HeaderStyle-ForeColor="Black">
                            <ItemTemplate>
                                <asp:Label ID="lblStudentName" runat="server" CssClass="text" Width="110px" Text='<%# Bind("Column1") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Roll No" HeaderStyle-ForeColor="Black">
                            <ItemTemplate>
                                <asp:Label ID="lblRollNo" runat="server" Width="90px" CssClass="text" Text='<%# Bind("Column2") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Classes Held (Month)" HeaderStyle-ForeColor="Black" ControlStyle-Width="45px">
                            <ItemTemplate>
                                <asp:TextBox ID="txtClassesHeld" CssClass="input-large focused" runat="server" AutoPostBack="true" OnTextChanged="txtClassesHeld_TextChanged"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Classes Attended (Month)" HeaderStyle-ForeColor="Black" ControlStyle-Width="45px">
                            <ItemTemplate>
                                <asp:TextBox ID="txtClassesAttended" CssClass="input-large focused" runat="server" AutoPostBack="true" OnTextChanged="txtClassesAttended_TextChanged"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Percentage (Month)" HeaderStyle-ForeColor="Black" ControlStyle-Width="45px">
                            <ItemTemplate>
                                <asp:TextBox ID="txtPercentage" CssClass="uneditable-input focused" runat="server" ReadOnly="true"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Classes Held (Cumulative)" HeaderStyle-ForeColor="Black" ControlStyle-Width="45px">
                            <ItemTemplate>
                                <asp:TextBox ID="txtCumClassesHeld" CssClass="uneditable-input focused" runat="server" AutoPostBack="true" OnTextChanged="txtCumClassesHeld_TextChanged"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Classes Attended (Cumulative)" HeaderStyle-ForeColor="Black" ControlStyle-Width="45px">
                            <ItemTemplate>
                                <asp:TextBox ID="txtCumClassesAttended" CssClass="uneditable-input focused" runat="server" AutoPostBack="true" OnTextChanged="txtCumClassesAttended_TextChanged"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Percentage (Cumulative)" HeaderStyle-ForeColor="Black" ControlStyle-Width="45px">
                            <ItemTemplate>
                                <asp:TextBox ID="txtCumPercentage" CssClass="uneditable-input focused" runat="server" ReadOnly="true"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Student ID" HeaderStyle-ForeColor="Black" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblStudentID" runat="server" CssClass="text" Width="20px" Text='<%# Bind("Column6") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ControlStyle-Width="40px">
                            <ItemTemplate>
                                <asp:LinkButton runat="server" ID="Save"
                                    CommandName="Save" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Text="Save" CssClass="btn btn-info btn-mini" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>

            </div>
        </div>



    </div>
    <!-- /block -->
</asp:Content>
