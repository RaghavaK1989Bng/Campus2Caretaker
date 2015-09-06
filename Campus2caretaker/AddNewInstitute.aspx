<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AddNewInstitute.aspx.cs" Inherits="Campus2caretaker.AddNewInstitute" EnableEventValidation="false" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <script type="text/javascript" language="javascript">

        $(document).ready(function () {
            $("#<%=txtInstitutePhoneNumber.ClientID %>").bind('copy paste cut', function (e) {
                    e.preventDefault(); //disable cut,copy,paste
                    alert('cut,copy & paste options are disabled !!');
                });

                $("#<%=txtPrincipalContactNumber.ClientID %>").keypress(function (event) {
                    if (event.which > 31 && (event.which < 48 || event.which > 57)) {
                        event.preventDefault();
                    }
                });

            $("#<%=txtMaxStudents.ClientID %>").keypress(function (event) {
                if (event.which > 31 && (event.which < 48 || event.which > 57)) {
                    event.preventDefault();
                }
            });

            $("[name*='txtInstituteName']").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: "/Auto/GetInstituteNames.aspx",
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
                    $("[name*='txtInstituteName']").val(ui.item.label);
                    $("[name*='hfInstituteID']").val(ui.item.id);
                }
            });
            });
    </script>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="block">
        <div class="navbar navbar-inner block-header">
            <div class="muted pull-left">Institute Details</div>
        </div>
        <div class="block-content collapse in">
            <div class="span12">
                <form class="form-horizontal">
                    <fieldset>
                        <legend>Add / Edit Institute Details</legend>
                        <div class="control-group">
                            <asp:Label runat="server" CssClass="control-label" AssociatedControlID="txtInstituteName">Institute Name <span class="required">*</span></asp:Label>
                            <div class="controls">
                                <asp:TextBox ID="txtInstituteName" runat="server" CssClass="input-xlarge focused"></asp:TextBox>
                                <asp:HiddenField ID="hfInstituteID" runat="server" />
                                <asp:RequiredFieldValidator ID="InstituteNameRequired" runat="server"
                                    ControlToValidate="txtInstituteName" ErrorMessage="Institute Name is required."
                                    ToolTip="Institute Name is required." ValidationGroup="Institute"
                                    ForeColor="#FF3300">*</asp:RequiredFieldValidator>

                            </div>
                            <asp:Label runat="server" CssClass="control-label"></asp:Label>
                            <div class="controls">
                                 <asp:Button ID="btnGetInstituteInfo" runat="server" CssClass="btn btn-info" Text="Get"
                                OnClick="btnGetInstituteInfo_Click" />
                                </div>
                            <asp:Label runat="server" CssClass="control-label" AssociatedControlID="txtInstituteAddress">Institute Address <span class="required">*</span></asp:Label>
                            <div class="controls">
                                <asp:TextBox ID="txtInstituteAddress" runat="server" CssClass="input-xlarge focused"  TextMode="MultiLine" Rows="3" Columns="30"></asp:TextBox>

                                <asp:RequiredFieldValidator ID="InstituteAddressRequired" runat="server"
                                    ControlToValidate="txtInstituteAddress" ErrorMessage="Institute Address is required."
                                    ToolTip="Institute Address is required." ValidationGroup="Institute"
                                    ForeColor="#FF3300">*</asp:RequiredFieldValidator>

                            </div>

                            <asp:Label runat="server" CssClass="control-label" AssociatedControlID="txtDistrict">District <span class="required">*</span></asp:Label>
                            <div class="controls">
                                <asp:TextBox ID="txtDistrict" runat="server" CssClass="input-xlarge focused"></asp:TextBox>

                                <asp:RequiredFieldValidator ID="DistrictRequired" runat="server"
                                    ControlToValidate="txtDistrict" ErrorMessage="District is required."
                                    ToolTip="District is required." ValidationGroup="Institute"
                                    ForeColor="#FF3300">*</asp:RequiredFieldValidator>

                            </div>

                            <asp:Label runat="server" CssClass="control-label" AssociatedControlID="txtState">State <span class="required">*</span></asp:Label>
                            <div class="controls">
                                <asp:TextBox ID="txtState" runat="server" CssClass="input-xlarge focused"></asp:TextBox>

                                <asp:RequiredFieldValidator ID="StateRequired" runat="server"
                                    ControlToValidate="txtState" ErrorMessage="State is required."
                                    ToolTip="State is required." ValidationGroup="Institute"
                                    ForeColor="#FF3300">*</asp:RequiredFieldValidator>

                            </div>

                            <asp:Label runat="server" CssClass="control-label" AssociatedControlID="txtState">Institute Logo</asp:Label>
                            <div class="controls">

                                <asp:FileUpload ID="FileUpPhoto" runat="server" CssClass="input-file uniform_on" />

                                <asp:Button ID="btnUpload" runat="server" CssClass="btn btn-info" Text="Upload"
                                    OnClick="btnUpload_Click" />
                            </div>
                            <label class="control-label"></label>
                            <div class="controls">
                                <img id="imgInstituteLogo" alt="" runat="server"/>
                            </div>

                            <asp:Label runat="server" CssClass="control-label" AssociatedControlID="txtInstitutePhoneNumber">Institute Phone Number <span class="required">*</span></asp:Label>
                            <div class="controls">
                                <asp:TextBox ID="txtInstitutePhoneNumber" runat="server" CssClass="input-xlarge focused"></asp:TextBox>

                                <asp:RequiredFieldValidator ID="InstitutePhoneNumberRequired" runat="server"
                                    ControlToValidate="txtInstitutePhoneNumber" ErrorMessage="Institute Phone Number is required."
                                    ToolTip="Institute Phone Number is required." ValidationGroup="Institute"
                                    ForeColor="#FF3300">*</asp:RequiredFieldValidator>

                            </div>

                            <asp:Label runat="server" CssClass="control-label" AssociatedControlID="ddlInstituteType">Institute Type <span class="required">*</span></asp:Label>
                            <div class="controls">
                                 <asp:DropDownList ID="ddlInstituteType" ValidationGroup="Institute" runat="server" CssClass="chzn-select">
                                     <asp:ListItem Text="Select" Value="" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="School" Value="S"></asp:ListItem>
                            <asp:ListItem Text="PU College" Value="C"></asp:ListItem>
                            <asp:ListItem Text="Degree College" Value="D"></asp:ListItem>
                            <asp:ListItem Text="Engineering College" Value="E"></asp:ListItem>
                                            </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="InstituteTypeRequired" runat="server"
                                    ControlToValidate="ddlInstituteType" ErrorMessage="Institute Type Selection is required."
                                    ToolTip="Institute Type Selection is required." ValidationGroup="Institute" InitialValue="Select"
                                    ForeColor="#FF3300">*</asp:RequiredFieldValidator>

                            </div>

                            <asp:Label runat="server" CssClass="control-label" AssociatedControlID="txtInstituteEmail">Institute Email ID <span class="required">*</span></asp:Label>
                            <div class="controls">
                                <asp:TextBox ID="txtInstituteEmail" runat="server" CssClass="input-xlarge focused"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="InstituteEmailRequired" runat="server"
                                    ControlToValidate="txtInstituteEmail" ErrorMessage="Institute Email is required."
                                    ToolTip="Institute Email is required." ValidationGroup="Institute"
                                    ForeColor="#FF3300">*</asp:RequiredFieldValidator>
                                                                <asp:RegularExpressionValidator ID="InstituteEmailInvalid" runat="server"
                                    ControlToValidate="txtInstituteEmail" ErrorMessage="Institute Email is not valid."
                                    ToolTip="Institute Email is not valid." ValidationGroup="Institute"
                                    ForeColor="#FF3300" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                            </div>

                            <asp:Label runat="server" CssClass="control-label" AssociatedControlID="txtMaxStudents">Maximum Number of Students<span class="required">*</span></asp:Label>
                            <div class="controls">
                                <asp:TextBox ID="txtMaxStudents" runat="server" CssClass="input-xlarge focused"></asp:TextBox>

                                <asp:RequiredFieldValidator ID="MaxStudentsRequired" runat="server"
                                    ControlToValidate="txtMaxStudents" ErrorMessage="Maximum Number of Students is required."
                                    ToolTip="Maximum Number of Students is required." ValidationGroup="Institute"
                                    ForeColor="#FF3300">*</asp:RequiredFieldValidator>

                            </div>

                            <asp:Label runat="server" CssClass="control-label" AssociatedControlID="txtPrincipalName">Principal Name <span class="required">*</span></asp:Label>
                            <div class="controls">
                                <asp:TextBox ID="txtPrincipalName" runat="server" CssClass="input-xlarge focused"></asp:TextBox>

                                <asp:RequiredFieldValidator ID="PrincipalNameRequired" runat="server"
                                    ControlToValidate="txtPrincipalName" ErrorMessage="Principal Name is required."
                                    ToolTip="Principal Name is required." ValidationGroup="Institute"
                                    ForeColor="#FF3300">*</asp:RequiredFieldValidator>

                            </div>

                            <asp:Label runat="server" CssClass="control-label" AssociatedControlID="txtPrincipalContactNumber">Principal Contact Number <span class="required">*</span></asp:Label>
                            <div class="controls">
                                <asp:TextBox ID="txtPrincipalContactNumber" runat="server" CssClass="input-xlarge focused"></asp:TextBox>

                                <asp:RequiredFieldValidator ID="PrincipalContactNumberRequired" runat="server"
                                    ControlToValidate="txtPrincipalContactNumber" ErrorMessage="Principal Contact Number is required."
                                    ToolTip="Principal Contact Number is required." ValidationGroup="Institute"
                                    ForeColor="#FF3300">*</asp:RequiredFieldValidator>

                            </div>

                        </div>

                        <div class="form-actions">
                            <div id="divStatus" runat="server"></div>
                                 <asp:Button ID="btnSave" runat="server" CssClass="btn btn-info" Text="Save"
                                OnClick="btnSave_Click" ValidationGroup="Institute" />
                            &nbsp;
                                          <asp:Button ID="btnUpdate" runat="server" CssClass="btn btn-info" Text="Update"
                                OnClick="btnUpdate_Click" ValidationGroup="Institute" />
                            &nbsp;
                            <asp:Button ID="btnDelete" runat="server" CssClass="btn btn-info" Text="Delete"
                                OnClick="btnDelete_Click" ValidationGroup="Institute" />
                            &nbsp;

                               <asp:Button ID="btnClear" runat="server" CssClass="btn btn-info" Text="Clear"
                                OnClick="btnClear_Click" />

                            <asp:ValidationSummary ID="ValidationSummary1" runat="server"
                                ShowMessageBox="false" ValidationGroup="Institute" ForeColor="Red"
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
                <asp:GridView ID="gvInstitutes" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                    ShowHeaderWhenEmpty="True" EmptyDataText="No records Found"
                    AllowSorting="false" Width="100%"
                    CssClass="table table-hover" OnRowCreated="gvInstitutes_RowCreated" 
                    onsorting="gvInstitutes_Sorting" OnPageIndexChanging="gvInstitutes_PageIndexChanging"
                    EnableModelValidation="True"  DataSourceID="dsGridview" >

                    <Columns>
                                <asp:BoundField DataField="colInstituteId" 
                                                HeaderText="Institute ID" 
                                                SortExpression="colInstituteId"
                                                ReadOnly="True" >
                                </asp:BoundField>
                                <asp:BoundField DataField="colInstituteName" 
                                                HeaderText="Institute Name" 
                                                SortExpression="colInstituteName">
                                </asp:BoundField>
                                <asp:BoundField DataField="colPhone" 
                                                HeaderText="Phone No" 
                                                SortExpression="colPhone" />
                                <asp:BoundField DataField="colInstituteType" 
                                                HeaderText="Institute Type" 
                                                SortExpression="colInstituteType" />
                            </Columns>
                </asp:GridView>
            </div>
             <asp:SqlDataSource ID="dsGridview" runat="server" ConnectionString="<%$ ConnectionStrings:C2CConnectionString %>"
                SelectCommand="SELECT [colInstituteId], [colInstituteName], [colPhone],[colInstituteType] FROM [tblInstituteDetails]">
            </asp:SqlDataSource>
        </div>
    </div>
</asp:Content>
