<%@ Page Title="Promote Students" Language="C#" MasterPageFile="~/Institute/Institute.Master" AutoEventWireup="true" CodeBehind="PromoteStudents.aspx.cs" Inherits="Campus2caretaker.Institute.PromoteStudents" EnableEventValidation="false" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="block">
        <div class="navbar navbar-inner block-header">
            <div class="muted pull-left">Promote Students</div>
        </div>
        <div class="block-content collapse in">
            <div class="span12">
                <form class="form-horizontal">
                    <fieldset>
                        <legend>Promote Students</legend>
                        <div class="control-group">
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label runat="server" CssClass="control-label" AssociatedControlID="ddlFromClass"><%= HttpContext.Current.Session["InstituteType"].ToString() == "S" ? "From Class" : "From Branch"%> <span class="required">*</span></asp:Label>
                                        <div class="controls">

                                            <asp:DropDownList ID="ddlFromClass" ValidationGroup="PromoteStudents" runat="server" CssClass="chzn-select" DataTextField="colBranchName" DataValueField="colBranchId">
                                            </asp:DropDownList>

                                            <asp:RequiredFieldValidator ID="FromClassNameRequired" runat="server"
                                                ControlToValidate="ddlFromClass" ErrorMessage="From Class / From Branch Selection is required."
                                                ToolTip="From Class / From Branch Selection is required." ValidationGroup="PromoteStudents" InitialValue="Select"
                                                ForeColor="#FF3300">*</asp:RequiredFieldValidator>
                                        </div>
                                    </td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td>
                                        <asp:Label runat="server" CssClass="control-label" AssociatedControlID="ddlToClass"><%= HttpContext.Current.Session["InstituteType"].ToString() == "S" ? "To Class" : "To Branch"%> <span class="required">*</span></asp:Label>
                                        <div class="controls">

                                            <asp:DropDownList ID="ddlToClass" ValidationGroup="PromoteStudents" runat="server" CssClass="chzn-select" DataTextField="colBranchName" DataValueField="colBranchId">
                                            </asp:DropDownList>

                                            <asp:RequiredFieldValidator ID="ToClassNameRequired" runat="server"
                                                ControlToValidate="ddlToClass" ErrorMessage="To Class / To Branch Selection is required."
                                                ToolTip="To Class / To Branch Selection is required." ValidationGroup="PromoteStudents" InitialValue="Select"
                                                ForeColor="#FF3300">*</asp:RequiredFieldValidator>
                                        </div>
                                    </td>
                                </tr>
                            </table>

                            <div id="dvSemester" runat="server">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Label runat="server" CssClass="control-label" AssociatedControlID="ddlFromSemester">From Semester<span class="required">*</span></asp:Label>
                                            <div class="controls">
                                                <asp:DropDownList ID="ddlFromSemester" runat="server" CssClass="chzn-select">
                                                </asp:DropDownList>

                                            </div>
                                        </td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td>
                                        <td>
                                            <asp:Label runat="server" CssClass="control-label" AssociatedControlID="ddlToSemester">To Semester<span class="required">*</span></asp:Label>
                                            <div class="controls">
                                                <asp:DropDownList ID="ddlToSemester" runat="server" CssClass="chzn-select">
                                                </asp:DropDownList>
                                            </div>
                                        </td>

                                    </tr>
                                </table>
                            </div>

                            <label class="control-label"></label>
                            <div class="controls">
                                <asp:Button ID="btnGetStudents" runat="server" CssClass="btn btn-info" Text="Get Students"
                                    OnClick="btnGetStudents_Click" ValidationGroup="PromoteStudents" />
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
                                <asp:GridView ID="gvPromoteStudents" runat="server" AutoGenerateColumns="False" AllowPaging="false"
                                    ShowHeaderWhenEmpty="True" EmptyDataText="No records Found"
                                    AllowSorting="false" Width="100%"
                                    CssClass="table table-hover"
                                    EnableModelValidation="True"
                                    OnDataBound="gvPromoteStudents_DataBound">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Select" HeaderStyle-ForeColor="Black" ControlStyle-Width="10px" HeaderStyle-Width="10px" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkSelect" runat="server" Width="10px"/>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Student Name" HeaderStyle-ForeColor="Black" ControlStyle-Width="200px" HeaderStyle-Width="200px">
                                            <ItemTemplate>
                                                <asp:Label ID="lblStudentName" runat="server" CssClass="text" Width="200px" Text='<%# Bind("Column1") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Roll No" HeaderStyle-ForeColor="Black" ControlStyle-Width="120px" HeaderStyle-Width="120px">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRollNo" runat="server" Width="120px" CssClass="text" Text='<%# Bind("Column2") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Student ID" HeaderStyle-ForeColor="Black" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblStudentID" runat="server" CssClass="text" Width="40px" Text='<%# Bind("Column3") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>

                            </div>
                        </div>
                        <div class="form-actions">
                            <%--<div id="divStatus" runat="server"></div>--%>
                            <asp:Button ID="btnSavePromoteStudents" runat="server" CssClass="btn btn-info" Text="Save" ValidationGroup="PromoteStudents"
                                OnClick="btnSavePromoteStudents_Click" />
                            &nbsp;
                                          <asp:Button ID="btnClear" runat="server" CssClass="btn btn-info"
                                              Text="Cancel" OnClick="btnClear_Click" />
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server"
                                ShowMessageBox="false" ValidationGroup="PromoteStudents" ForeColor="Red"
                                ShowSummary="true" meta:resourcekey="ValidationSummary1Resource1" HeaderText="Please fix the following errors :" />
                        </div>
                    </fieldset>
                </form>

            </div>
        </div>
    </div>
    <!-- /block -->
</asp:Content>
