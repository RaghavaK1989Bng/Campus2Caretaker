<%@ Page Title="Student Details" Language="C#" MasterPageFile="~/Institute/Institute.Master" AutoEventWireup="true" CodeBehind="AddNewStudent.aspx.cs" Inherits="Campus2caretaker.Institute.AddNewStudent" EnableEventValidation="false" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <script type="text/javascript">
        function pageLoad(sender, args) {
            $(document).ready(function () {
                $("#<%=txtDOB.ClientID %>").datepicker(
                                    {
                                        changeMonth: true,
                                        changeYear: true,
                                        dateFormat: 'd MM, yy',
                                        showAnim: 'fadeIn',
                                        showButtonPanel: true,
                                        yearRange: "-30:+0",
                                    }
                                );
                $("#<%=txtDOB.ClientID %>").attr('readonly', true);

                $("[name*='txtStudentName']").autocomplete({
                    source: function (request, response) {
                        $.ajax({
                            url: "/Auto/GetStudentNames.aspx",
                            dataType: "json",
                            data: {
                                startsWith: request.term
                            }
                            , success: function (data) {
                                response($.map(data, function (item) {
                                    return {
                                        label: item.value,
                                        value: item.value,
                                        id: item.id
                                    }
                                }));
                            }
                        });
                    },
                    minLength: 1,
                    select: function (event, ui) {
                        $("[name*='txtStudentName']").val(ui.item.label);
                        $("[name*='hfStudentID']").val(ui.item.id);
                    }
                });

                $("#<%=txtParentsContactNumber.ClientID %>").bind('copy paste cut', function (e) {
                    e.preventDefault(); //disable cut,copy,paste
                    alert('cut,copy & paste options are disabled !!');
                });
            });
        }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="block">
        <div class="navbar navbar-inner block-header">
            <div class="muted pull-left">Student Details</div>
        </div>
        <div class="block-content collapse in">
            <div class="span12">
                <form class="form-horizontal">
                    <fieldset>
                        <legend>Add/Edit Student Details</legend>
                        <div class="control-group">
                            <asp:Label runat="server" CssClass="control-label" AssociatedControlID="txtStudentName">Student Name <span class="required">*</span></asp:Label>
                            <div class="controls">

                                <asp:TextBox ID="txtStudentName" runat="server" CssClass="input-xlarge focused"></asp:TextBox>
                                <asp:HiddenField ID="hfStudentID" runat="server" />
                                <asp:RequiredFieldValidator ID="StudentNameRequired" runat="server"
                                    ControlToValidate="txtStudentName" ErrorMessage="Student Name is required."
                                    ToolTip="Student Name is required." ValidationGroup="Student"
                                    ForeColor="#FF3300">*</asp:RequiredFieldValidator>

                            </div>
                            <asp:Label runat="server" CssClass="control-label"></asp:Label>
                            <div class="controls">
                                <asp:Button ID="btnGetStudentInfo" runat="server" CssClass="btn btn-info" Text="Get"
                                    OnClick="btnGetStudentInfo_Click" />
                            </div>
                            <asp:Label runat="server" CssClass="control-label" AssociatedControlID="txtStudentAddress">Address <span class="required">*</span></asp:Label>
                            <div class="controls">

                                <asp:TextBox ID="txtStudentAddress" runat="server" CssClass="input-xlarge textarea"></asp:TextBox>

                                <asp:RequiredFieldValidator ID="AddressRequired" runat="server"
                                    ControlToValidate="txtStudentAddress" ErrorMessage="Student Address is required."
                                    ToolTip="Student Address is required." ValidationGroup="Student"
                                    ForeColor="#FF3300">*</asp:RequiredFieldValidator>

                            </div>

                            <asp:Label runat="server" CssClass="control-label" AssociatedControlID="txtFatherName">Father Name <span class="required">*</span></asp:Label>
                            <div class="controls">

                                <asp:TextBox ID="txtFatherName" runat="server" CssClass="input-xlarge focused"></asp:TextBox>

                                <asp:RequiredFieldValidator ID="FatherNameRequired" runat="server"
                                    ControlToValidate="txtFatherName" ErrorMessage="Student Father Name is required."
                                    ToolTip="Student Father Name is required." ValidationGroup="Student"
                                    ForeColor="#FF3300">*</asp:RequiredFieldValidator>

                            </div>

                            <asp:Label runat="server" CssClass="control-label" AssociatedControlID="txtMotherName">Mother Name <span class="required">*</span></asp:Label>
                            <div class="controls">

                                <asp:TextBox ID="txtMotherName" runat="server" CssClass="input-xlarge focused"></asp:TextBox>

                                <asp:RequiredFieldValidator ID="MotherNameRequired" runat="server"
                                    ControlToValidate="txtMotherName" ErrorMessage="Student Mother Name is required."
                                    ToolTip="Student Mother Name is required." ValidationGroup="Student"
                                    ForeColor="#FF3300">*</asp:RequiredFieldValidator>

                            </div>

                            <asp:Label runat="server" CssClass="control-label" AssociatedControlID="txtDOB">Date Of Birth <span class="required">*</span></asp:Label>
                            <div class="controls">

                                <asp:TextBox ID="txtDOB" runat="server" CssClass="input-xlarge focused"></asp:TextBox>

                                <asp:RequiredFieldValidator ID="DOBRequired" runat="server"
                                    ControlToValidate="txtDOB" ErrorMessage="Student Date Of Birth is required."
                                    ToolTip="Student Date Of Birth is required.." ValidationGroup="Student"
                                    ForeColor="#FF3300">*</asp:RequiredFieldValidator>

                            </div>

                            <asp:Label runat="server" CssClass="control-label" AssociatedControlID="ddlClass"><%= HttpContext.Current.Session["InstituteType"].ToString() == "S" ? "Class" : "Branch"%> <span class="required">*</span></asp:Label>
                            <div class="controls">

                                <asp:DropDownList ID="ddlClass" ValidationGroup="Student" runat="server" class="chzn-select" DataTextField="colBranchName" DataValueField="colBranchId">
                                </asp:DropDownList>


                                <asp:RequiredFieldValidator ID="ClassNameRequired" runat="server"
                                    ControlToValidate="ddlClass" ErrorMessage="Student Class Selection is required."
                                    ToolTip="Student Class Selection is required." ValidationGroup="Student" InitialValue="Select"
                                    ForeColor="#FF3300">*</asp:RequiredFieldValidator>

                            </div>

                            <asp:Label runat="server" CssClass="control-label" AssociatedControlID="ddlGender">Gender <span class="required">*</span></asp:Label>
                            <div class="controls">

                                <asp:DropDownList ID="ddlGender" ValidationGroup="Student" runat="server" class="chzn-select">
                                    <asp:ListItem Text="Select" Value="" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                                    <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
                                </asp:DropDownList>


                                <asp:RequiredFieldValidator ID="GenderRequired" runat="server"
                                    ControlToValidate="ddlGender" ErrorMessage="Gender Selection is required."
                                    ToolTip="Gender Selection is required." ValidationGroup="Student" InitialValue="Select"
                                    ForeColor="#FF3300">*</asp:RequiredFieldValidator>

                            </div>

                            <div id="dvSemester" runat="server">
                                <asp:Label runat="server" CssClass="control-label" AssociatedControlID="ddlSemester">Semester<span class="required">*</span></asp:Label>
                                <div class="controls">
                                    <asp:DropDownList ID="ddlSemester" runat="server" CssClass="chzn-select">
                                    </asp:DropDownList>

                                </div>
                            </div>
                            <asp:Label runat="server" CssClass="control-label" AssociatedControlID="txtRollNo">Roll Number<span class="required">*</span></asp:Label>
                            <div class="controls">
                                <asp:TextBox ID="txtRollNo" runat="server" CssClass="input-xlarge focused"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RollNoRequired" runat="server"
                                    ControlToValidate="txtRollNo" ErrorMessage="Student Roll Number is required."
                                    ToolTip="Student Roll Number is required." ValidationGroup="Student"
                                    ForeColor="#FF3300">*</asp:RequiredFieldValidator>
                            </div>

                            <asp:Label runat="server" CssClass="control-label" AssociatedControlID="txtParentsEmail">Parents Email ID</asp:Label>
                            <div class="controls">
                                <asp:TextBox ID="txtParentsEmail" runat="server" CssClass="input-xlarge focused"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="ParentsEmailInvalid" runat="server"
                                    ControlToValidate="txtParentsEmail" ErrorMessage="Students Email is not valid."
                                    ToolTip="Students Email is not valid." ValidationGroup="Student"
                                    ForeColor="#FF3300" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                            </div>

                            <asp:Label runat="server" CssClass="control-label" AssociatedControlID="txtParentsContactNumber">Parents Contact Number<span class="required">*</span></asp:Label>
                            <div class="controls">
                                <asp:TextBox ID="txtParentsContactNumber" runat="server" CssClass="input-xlarge focused"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ParentsContactNumberRequired" runat="server"
                                    ControlToValidate="txtParentsContactNumber" ErrorMessage="Students Parents Contact Number is required."
                                    ToolTip="Students Parents Contact Number is required." ValidationGroup="Student"
                                    ForeColor="#FF3300">*</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="ParentsContactNumberInvalid" runat="server"
                                    ControlToValidate="txtParentsContactNumber" ErrorMessage="Students Parents Contact Number is not valid."
                                    ToolTip="Students Parents Contact Number is not valid." ValidationGroup="Student"
                                    ForeColor="#FF3300" ValidationExpression="[0-9]{10}">*</asp:RegularExpressionValidator>
                            </div>

                        </div>

                        <div class="form-actions">
                            <%--<div id="divStatus" runat="server"></div>--%>
                            <asp:Button ID="btnSave" runat="server" CssClass="btn btn-info" Text="Save"
                                OnClick="btnSave_Click" ValidationGroup="Student" />
                            &nbsp;
                                          <asp:Button ID="btnUpdate" runat="server" CssClass="btn btn-info" Text="Update"
                                              OnClick="btnUpdate_Click" ValidationGroup="Student" />
                            &nbsp;
                            <asp:Button ID="btnDelete" runat="server" CssClass="btn btn-info" Text="Delete"
                                OnClick="btnDelete_Click" ValidationGroup="Student" />
                            &nbsp;

                               <asp:Button ID="btnClear" runat="server" CssClass="btn btn-info" Text="Clear"
                                   OnClick="btnClear_Click" />

                            <asp:ValidationSummary ID="ValidationSummary1" runat="server"
                                ShowMessageBox="false" ValidationGroup="Student" ForeColor="Red"
                                ShowSummary="true" meta:resourcekey="ValidationSummary1Resource1" HeaderText="Please fix the following errors :" />

                        </div>

                        <div style="text-align:center;">
                            <h3>OR</h3>
                        </div>

                        <div class="control-group">
                            <asp:Label runat="server" CssClass="control-label" AssociatedControlID="FlUploadcsv">Import From File <span class="required">*</span></asp:Label>
                            <div class="controls">
                                <asp:FileUpload ID="FlUploadcsv" runat="server" CssClass="input-file uniform_on" />

                                <a href="../Template/StudentRegistrationSample.xlsx" id="LinkstudentRegistrationSample" target="_blank">Download sample file</a>


                            </div>
                        </div>
                        <div class="form-actions">
                           <%-- <div id="dvUploadStatus" runat="server"></div>--%>
                            <asp:Button ID="btnUpload" runat="server" CssClass="btn btn-info" Text="Upload"
                                OnClick="btnUpload_Click" />
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
                <asp:GridView ID="gvStudents" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                    ShowHeaderWhenEmpty="True" EmptyDataText="No records Found"
                    AllowSorting="false" Width="100%"
                    CssClass="table table-hover" OnRowCreated="gvStudents_RowCreated"
                    OnSorting="gvStudents_Sorting" OnPageIndexChanging="gvStudents_PageIndexChanging"
                    EnableModelValidation="True">

                    <Columns>
                        <asp:BoundField DataField="colStudentId"
                            HeaderText="Student ID"
                            SortExpression="colStudentId"></asp:BoundField>
                        <asp:BoundField DataField="colStudentName"
                            HeaderText="Student Name"
                            SortExpression="colStudentName"></asp:BoundField>
                        <asp:BoundField DataField="colFatherName"
                            HeaderText="Father Name"
                            SortExpression="colFatherName" />
                        <asp:BoundField DataField="colParentsMobileNo"
                            HeaderText="Parents Mobile No"
                            SortExpression="colParentsMobileNo" />
                    </Columns>
                </asp:GridView>

            </div>
        </div>

    </div>
    <!-- /block -->
</asp:Content>
