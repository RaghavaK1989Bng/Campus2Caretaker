<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AdminDefault.aspx.cs" Inherits="Campus2caretaker.AdminDefault" EnableEventValidation="false" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <script type="text/javascript">
        $(document).ready(function () {
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

            $("[name*='txtDistrict']").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: "/Auto/GetInstituteDistricts.aspx",
                        dataType: "json",
                        data: {
                            startsWith: request.term
                        }
                        , success: function (data) {
                            response($.map(data, function (item) {
                                return {
                                    label: item.value,
                                    value: item.value
                                }
                            }));
                        }
                    });
                },
                minLength: 1,
                select: function (event, ui) {
                    $("[name*='txtDistrict']").val(ui.item.label);
                }
            });

            $("[name*='txtState']").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: "/Auto/GetInstituteStates.aspx",
                        dataType: "json",
                        data: {
                            startsWith: request.term
                        }
                        , success: function (data) {
                            response($.map(data, function (item) {
                                return {
                                    label: item.value,
                                    value: item.value
                                }
                            }));
                        }
                    });
                },
                minLength: 1,
                select: function (event, ui) {
                    $("[name*='txtState']").val(ui.item.label);
                }
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="block">
        <div class="navbar navbar-inner block-header">
            <div class="muted pull-left">Dashboard</div>
        </div>
        <div class="block-content collapse in">
            <div class="span12">
                <form class="form-horizontal">
                    <fieldset>
                        <legend>Dashboard</legend>
                        <div class="control-group">
                            <div class="controls">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Label runat="server" CssClass="control-label" AssociatedControlID="txtInstituteName">Institute Name</asp:Label>
                                        </td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td>
                                            <asp:Label runat="server" CssClass="control-label" AssociatedControlID="txtDistrict">District</asp:Label>
                                        </td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td>
                                            <asp:Label runat="server" CssClass="control-label" AssociatedControlID="txtState">State</asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtInstituteName" runat="server" CssClass="input-xlarge focused"></asp:TextBox>
                                            <asp:HiddenField ID="hfInstituteID" runat="server" />

                                        </td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td>
                                            <asp:TextBox ID="txtDistrict" runat="server" CssClass="input-xlarge focused"></asp:TextBox></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td>
                                            <asp:TextBox ID="txtState" runat="server" CssClass="input-xlarge focused"></asp:TextBox></td>
                                    </tr>
                                </table>
                            </div>
                            <div class="form-actions">
                                <asp:Button ID="btnApplyFilter" runat="server" CssClass="btn btn-info" Text="Apply Filter"
                                    OnClick="btnApplyFilter_Click" />
                                &nbsp;
                                          <asp:Button ID="btnClearFilter" runat="server" CssClass="btn btn-info"
                                              Text="Clear Filter" OnClick="btnClearFilter_Click"
                                              meta:resourcekey="btnClearResource1" />

                            </div>

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
                <asp:GridView ID="gvInstitutes" runat="server" AutoGenerateColumns="False" AllowPaging="true"
                    ShowHeaderWhenEmpty="True" EmptyDataText="No records Found"
                    AllowSorting="false" Width="100%"
                    CssClass="table table-hover"
                    EnableModelValidation="True" OnRowCreated="gvInstitutes_RowCreated" OnSorting="gvInstitutes_Sorting" OnPageIndexChanging="gvInstitutes_PageIndexChanging">
                    <Columns>
                        <asp:BoundField DataField="colInstituteId"
                            HeaderText="Institute ID"
                            SortExpression="colInstituteId"
                            ReadOnly="True"></asp:BoundField>
                        <asp:BoundField DataField="colInstituteName"
                            HeaderText="Institute Name"
                            SortExpression="colInstituteName"></asp:BoundField>
                        <asp:BoundField DataField="colPhone"
                            HeaderText="Phone No"
                            SortExpression="colPhone" />
                        <asp:BoundField DataField="colDistrict"
                            HeaderText="District"
                            SortExpression="colDistrict" />
                        <asp:BoundField DataField="colState"
                            HeaderText="State"
                            SortExpression="colState" />
                        <asp:BoundField DataField="colInstituteType"
                            HeaderText="Institute Type"
                            SortExpression="colInstituteType" />
                    </Columns>
                </asp:GridView>

            </div>
        </div>
    </div>

</asp:Content>
