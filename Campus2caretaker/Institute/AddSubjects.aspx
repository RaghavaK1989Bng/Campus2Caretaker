﻿<%@ Page Title="Subject Details" Language="C#" MasterPageFile="~/Institute/Institute.Master" AutoEventWireup="true" CodeBehind="AddSubjects.aspx.cs" Inherits="Campus2caretaker.Institute.AddSubjects" EnableEventValidation="false" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="block">
        <div class="navbar navbar-inner block-header">
            <div class="muted pull-left">Subject Details</div>
        </div>
        <div class="block-content collapse in">
            <div class="span12">
                <form class="form-horizontal">
                    <fieldset>
                        <legend>Add Subjects</legend>
                        <div class="control-group">
                            <asp:Label runat="server" CssClass="control-label" AssociatedControlID="ddlClass"><%= HttpContext.Current.Session["InstituteType"].ToString() == "S" ? "Class" : "Branch"%> <span class="required">*</span></asp:Label>
                            <div class="controls">

                                <asp:DropDownList ID="ddlClass" ValidationGroup="Subject" runat="server" CssClass="chzn-select" DataTextField="colBranchName" DataValueField="colBranchId">
                                </asp:DropDownList>

                                <asp:RequiredFieldValidator ID="ClassNameRequired" runat="server"
                                    ControlToValidate="ddlClass" ErrorMessage="Class / Branch Selection is required."
                                    ToolTip="Class / Branch Selection is required." ValidationGroup="Subject" InitialValue="Select"
                                    ForeColor="#FF3300">*</asp:RequiredFieldValidator>

                            </div>
                            <div id="dvSemester" runat="server">
                                <asp:Label runat="server" CssClass="control-label" AssociatedControlID="ddlSemester">Semester<span class="required">*</span></asp:Label>
                                <div class="controls">
                                    <asp:DropDownList ID="ddlSemester" runat="server" CssClass="chzn-select">
                                    </asp:DropDownList>

                                </div>
                            </div>
                            <asp:Label runat="server" CssClass="control-label" AssociatedControlID="txtSubjectName">Subject Name<span class="required">*</span></asp:Label>
                            <div class="controls">
                                <asp:TextBox ID="txtSubjectName" runat="server" CssClass="input-xlarge focused"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="SubjectNameRequired" runat="server"
                                    ControlToValidate="txtSubjectName" ErrorMessage="Subject Name is required."
                                    ToolTip="Subject Name is required." ValidationGroup="Subject"
                                    ForeColor="#FF3300">*</asp:RequiredFieldValidator>
                            </div>
                            <label class="control-label"></label>
                            <div class="controls">
                                <asp:Button ID="btnAddSubjectTheory" runat="server" CssClass="btn btn-info" Text="Add Subject (Theory)"
                                    OnClick="btnAddSubjectTheory_Click" ValidationGroup="Subject" />
                                &nbsp;
                    <asp:Button ID="btnAddSubjectLab" runat="server" CssClass="btn btn-info" Text="Add Subject (Lab)"
                        OnClick="btnAddSubjectLab_Click" ValidationGroup="Subject" />
                                &nbsp;
                    <asp:Button ID="btnRemoveSubject" runat="server" CssClass="btn btn-info" Text="Remove Subject"
                        OnClick="btnRemoveSubject_Click" />
                            </div>
                            <br />
                            <label class="control-label" for="focusedInput"></label>
                            <div class="controls">

                                <asp:ListBox ID="lstSubjectsTheory" runat="server" SelectionMode="Single" CssClass="listbox"></asp:ListBox>
                                <asp:ListBox ID="lstSubjectsLab" runat="server" SelectionMode="Single" CssClass="listbox"></asp:ListBox>
                            </div>

                        </div>
                        <div class="form-actions">
                            <%--<div id="divStatus" runat="server"></div>--%>
                            <asp:Button ID="btnSaveSubjects" runat="server" CssClass="btn btn-info" Text="Save"
                                OnClick="btnSaveSubjects_Click" />
                            &nbsp;
                                          <asp:Button ID="btnClearSubjects" runat="server" CssClass="btn btn-info"
                                              Text="Cancel" OnClick="btnClearSubjects_Click" />
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server"
                                ShowMessageBox="false" ValidationGroup="Subject" ForeColor="Red"
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
                <asp:GridView ID="gvSubjects" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                    ShowHeaderWhenEmpty="True" EmptyDataText="No records Found"
                    AllowSorting="false" Width="100%"
                    CssClass="table table-hover"
                    EnableModelValidation="True" OnRowCreated="gvSubjects_RowCreated" OnSorting="gvSubjects_Sorting" OnPageIndexChanging="gvSubjects_PageIndexChanging">
                    <Columns>
                        <asp:BoundField DataField="colBranchId"
                            HeaderText=""
                            SortExpression="colBranchId"
                            ReadOnly="True"></asp:BoundField>
                        <asp:BoundField DataField="colSubjectName"
                            HeaderText="Subject Name"
                            SortExpression="colSubjectName"></asp:BoundField>
                    </Columns>
                </asp:GridView>

            </div>
        </div>



    </div>
    <!-- /block -->
</asp:Content>
