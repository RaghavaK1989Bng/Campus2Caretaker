<%@ Page Title="Class / Branch Details" Language="C#" MasterPageFile="~/Institute/Institute.Master" AutoEventWireup="true" CodeBehind="AddClass.aspx.cs" Inherits="Campus2caretaker.Institute.AddClass" EnableEventValidation="false" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- block -->
    <div class="block">
        <div class="navbar navbar-inner block-header">
            <div class="muted pull-left"><%= HttpContext.Current.Session["InstituteType"].ToString() == "S" ? "Class Details" : "Branch Details"%></div>
        </div>
        <div class="block-content collapse in">
            <div class="span12">
                <form class="form-horizontal">
                    <fieldset>
                        <legend><%= HttpContext.Current.Session["InstituteType"].ToString() == "S" ? "Add Class" : "Add Branch"%></legend>
                        <div class="control-group">
                            <asp:Label runat="server" CssClass="control-label" AssociatedControlID="txtClassName"> <%= HttpContext.Current.Session["InstituteType"].ToString() == "S" ? "Class Name" : "Branch Name"%> <span class="required">*</span></asp:Label>
                            <div class="controls">
                                <asp:TextBox ID="txtClassName" runat="server" CssClass="input-xlarge focused"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ClassNameRequired" runat="server"
                                    ControlToValidate="txtClassName" ErrorMessage="Class Name is required."
                                    ToolTip="Class Name is required." ValidationGroup="Class"
                                    ForeColor="#FF3300">*</asp:RequiredFieldValidator>

                            </div>
                            <label class="control-label"></label>
                            <div class="controls">
                                <asp:Button ID="btnAddClass" runat="server" CssClass="btn btn-info" Text=""
                                    OnClick="btnAddClass_Click" ValidationGroup="Class" />
                                &nbsp;
                    <asp:Button ID="btnRemoveClass" runat="server" CssClass="btn btn-info" Text=""
                        OnClick="btnRemoveClass_Click" />
                            </div>
                            <br />
                            <label class="control-label"></label>
                            <div class="controls">

                                <asp:ListBox ID="lstClasses" runat="server" SelectionMode="Single" CssClass="listbox"></asp:ListBox>
                            </div>

                        </div>
                        <div class="form-actions">
<%--                            <div id="divStatus" runat="server"></div>--%>
                            <asp:Button ID="btnSave" runat="server" CssClass="btn btn-info" Text="Save"
                                OnClick="btnSave_Click" />
                            &nbsp;
                                          <asp:Button ID="btnClear" runat="server" CssClass="btn btn-info"
                                              Text="Cancel" OnClick="btnClear_Click"
                                              meta:resourcekey="btnClearResource1" />
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server"
                                ShowMessageBox="false" ValidationGroup="Class" ForeColor="Red"
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

                    <asp:GridView ID="gvClasses" runat="server" AutoGenerateColumns="False" AllowPaging="true"
                        ShowHeaderWhenEmpty="True" EmptyDataText="No records Found"
                        AllowSorting="false" Width="100%"
                        CssClass="table table-hover"
                        EnableModelValidation="True" OnRowCreated="gvClasses_RowCreated" OnSorting="gvClasses_Sorting" OnPageIndexChanging="gvClasses_PageIndexChanging">
                        <Columns>
                            <asp:BoundField DataField="colBranchId"
                                HeaderText=""
                                SortExpression="colBranchId"
                                ReadOnly="True"></asp:BoundField>
                            <asp:BoundField DataField="colBranchName"
                                HeaderText=""
                                SortExpression="colBranchName"></asp:BoundField>
                        </Columns>
                    </asp:GridView>
            </div>
        </div>



    </div>
    <!-- /block -->

</asp:Content>
