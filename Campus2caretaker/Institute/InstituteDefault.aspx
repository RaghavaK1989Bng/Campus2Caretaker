<%@ Page Title="Dashboard" Language="C#" MasterPageFile="~/Institute/Institute.Master" AutoEventWireup="true" CodeBehind="InstituteDefault.aspx.cs" Inherits="Campus2caretaker.Institute.InstituteDefault" EnableEventValidation="false" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <!-- HTML5 shim, for IE6-8 support of HTML5 elements -->
    <!--[if lt IE 9]>
            <script src="http://html5shim.googlecode.com/svn/trunk/html5.js"></script>
        <![endif]-->
    <script type="text/javascript">
        function pageLoad(sender, args) {
            $(document).ready(function () {
                // Easy pie charts
                $('.chart').easyPieChart({ animate: 1000 });
            });
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="block">
        <div class="navbar navbar-inner block-header">
            <div class="muted pull-left">Dashboard</div>
        </div>
        <div class="block-content collapse in">
            <div class="span12">
                <form class="form-horizontal">
                    <fieldset>
                        <legend>Dashboard</legend>
                        <div class="block" style="margin-left: 10px; margin-right: 10px;">
                            <div class="navbar navbar-inner block-header">
                                <div class="muted pull-left" style="font-weight: bold;">Students Strength</div>
                                <div class="pull-right">
                                    <span class="badge badge-warning"></span>

                                </div>
                            </div>
                            <div class="block-content collapse in">
                                <div class="span3">
                                    <div style="width: 110px; height: 110px; line-height: 110px;" class="chart easyPieChart" data-percent="0" id="dvAllCount" runat="server">
                                        <canvas width="110" height="110"></canvas>
                                    </div>
                                    <div class="chart-bottom-heading">
                                        <span class="label label-info" id="lblAllCount" runat="server"></span>
                                        <br />
                                        <span class="label label-info" id="lblAllCountText" runat="server"></span>
                                    </div>
                                </div>
                                <div class="span3">
                                    <div style="width: 110px; height: 110px; line-height: 110px;" class="chart easyPieChart" data-percent="0" id="dvMaleCount" runat="server">
                                        <canvas width="110" height="110"></canvas>
                                    </div>
                                    <div class="chart-bottom-heading">
                                        <span class="label label-info" id="lblMaleCount" runat="server"></span>
                                        <br />
                                        <span class="label label-info" id="lblMaleCountText" runat="server"></span>
                                    </div>
                                </div>
                                <div class="span3">
                                    <div style="width: 110px; height: 110px; line-height: 110px;" class="chart easyPieChart" data-percent="0" id="dvFemaleCount" runat="server">
                                        <canvas width="110" height="110"></canvas>
                                    </div>
                                    <div class="chart-bottom-heading">
                                        <span class="label label-info" id="lblFemaleCount" runat="server"></span>
                                        <br />
                                        <span class="label label-info" id="lblFemaleCountText" runat="server"></span>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row-fluid">
                            <div class="span6">
                                <div class="block">
                                    <div class="navbar navbar-inner block-header">
                                        <div class="muted pull-left">Classwise / Branchwise Students Strength</div>
                                        <div class="pull-right">
                                            <span class="badge badge-info"></span>

                                        </div>
                                    </div>
                                    <div class="block-content collapse in">
                                        <asp:GridView CssClass="table table-striped" ID="gvClasswiseStrength" runat="server" AutoGenerateColumns="False" AllowPaging="true"
                                            ShowHeaderWhenEmpty="True" EmptyDataText="No records Found"
                                            AllowSorting="false" Width="100%" EnableModelValidation="True" OnPageIndexChanging="gvClasswiseStrength_PageIndexChanging">
                                            <Columns>
                                                <asp:BoundField DataField="colBranchName"
                                                    HeaderText="Class/Branch Name"
                                                    ReadOnly="True"></asp:BoundField>
                                                <asp:BoundField DataField="colTotalCount"
                                                    HeaderText="Total Students"></asp:BoundField>
                                                <asp:BoundField DataField="colMaleCount"
                                                    HeaderText="Male"></asp:BoundField>
                                                <asp:BoundField DataField="colFemaleCount"
                                                    HeaderText="Female"></asp:BoundField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                            <div class="span6">
                                <div class="block">
                                    <div class="navbar navbar-inner block-header">
                                        <div class="muted pull-left">Classwise / Branchwise Students Strength Chart</div>
                                        <div class="pull-right">
                                            <span class="badge badge-info"></span>

                                        </div>
                                    </div>
                                    <div class="block-content collapse in">
                                        <asp:Chart ID="chrtStudentsStrengthvsClass" runat="server">
                                            <Series>
                                            </Series>
                                            <ChartAreas>
                                                <asp:ChartArea Name="chrtAreaStudentsStrengthvsClass"></asp:ChartArea>
                                            </ChartAreas>
                                        </asp:Chart>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row-fluid">
                            <div class="span6">
                                <div class="block">
                                    <div class="navbar navbar-inner block-header">
                                        <div class="muted pull-left">Attendance Statistics</div>
                                        <div class="pull-right">
                                            <span class="badge badge-info"></span>

                                        </div>
                                    </div>
                                    <div class="block-content collapse in">
                                        <div class="control-group">
                                            <label class="control-label"></label>
                                            <div class="nav-collapse collapse">
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:Label runat="server" CssClass="control-label" AssociatedControlID="ddlAttendanceMonth">Month</asp:Label>
                                                            <div class="controls">

                                                                <asp:DropDownList ID="ddlAttendanceMonth" runat="server" CssClass="chzn-select" ValidationGroup="DashboardAttendance">
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
                                                                <asp:RequiredFieldValidator ID="AttendanceMonthSelectionRequired" runat="server"
                                                                    ControlToValidate="ddlAttendanceMonth" ErrorMessage="Month Selection is required."
                                                                    ToolTip="Month Selection is required." ValidationGroup="DashboardAttendance" InitialValue="Select"
                                                                    ForeColor="#FF3300">*</asp:RequiredFieldValidator>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label runat="server" CssClass="control-label" AssociatedControlID="ddlAttendanceYear">Year</asp:Label>
                                                            <div class="controls">

                                                                <asp:DropDownList ID="ddlAttendanceYear" runat="server" CssClass="chzn-select">
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
                                                                <asp:RequiredFieldValidator ID="AttendanceYearSelectionRequired" runat="server"
                                                                    ControlToValidate="ddlAttendanceYear" ErrorMessage="Year Selection is required."
                                                                    ToolTip="Year Selection is required." ValidationGroup="DashboardAttendance" InitialValue="Select"
                                                                    ForeColor="#FF3300">*</asp:RequiredFieldValidator>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <div class="controls">
                                                                <asp:Button ID="btnGenerateAttendanceStatistics" runat="server" CssClass="btn btn-info" Text="Generate Attendance Statistics"
                                                                    OnClick="btnGenerateAttendanceStatistics_Click" ValidationGroup="DashboardAttendance" />
                                                                <asp:ValidationSummary ID="ValidationSummary1" runat="server"
                                                                    ShowMessageBox="false" ValidationGroup="DashboardAttendance" ForeColor="Red"
                                                                    ShowSummary="true" meta:resourcekey="ValidationSummary1Resource1" HeaderText="Please fix the following errors :" />
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </div>




                                        <asp:GridView CssClass="table table-striped" ID="gvAttendanceMonth" runat="server" AutoGenerateColumns="False" AllowPaging="true"
                                            ShowHeaderWhenEmpty="True" EmptyDataText="No records Found"
                                            AllowSorting="false" Width="100%" EnableModelValidation="True" OnPageIndexChanging="gvAttendanceMonth_PageIndexChanging">
                                            <Columns>
                                                <asp:BoundField DataField="colBranchName"
                                                    HeaderText="Class/Branch Name"
                                                    ReadOnly="True"></asp:BoundField>
                                                <asp:BoundField DataField="col35"
                                                    HeaderText="0-85%"></asp:BoundField>
                                                <asp:BoundField DataField="col85"
                                                    HeaderText="85-100%"></asp:BoundField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                            <div class="span6">
                                <div class="block">
                                    <div class="navbar navbar-inner block-header">
                                        <div class="muted pull-left">Classwise / Branchwise Attendance Chart</div>
                                        <div class="pull-right">
                                            <span class="badge badge-info"></span>

                                        </div>
                                    </div>
                                    <div class="block-content collapse in">
                                        <asp:Chart ID="chrtAttendanceMonth" runat="server">
                                            <Series>
                                            </Series>
                                            <ChartAreas>
                                                <asp:ChartArea Name="chrtAreaAttendanceMonth"></asp:ChartArea>
                                            </ChartAreas>
                                        </asp:Chart>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row-fluid">
                            <div class="span6">
                                <div class="block">
                                    <div class="navbar navbar-inner block-header">
                                        <div class="muted pull-left">Test/Internals Statistics</div>
                                        <div class="pull-right">
                                            <span class="badge badge-info"></span>

                                        </div>
                                    </div>
                                    <div class="block-content collapse in">
                                        <div class="control-group">
                                            <label class="control-label"></label>
                                            <div class="nav-collapse collapse">
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:Label runat="server" CssClass="control-label" AssociatedControlID="ddlInternalsMonth">Month</asp:Label>
                                                            <div class="controls">

                                                                <asp:DropDownList ID="ddlInternalsMonth" runat="server" CssClass="chzn-select" ValidationGroup="DashboardInternals">
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
                                                                <asp:RequiredFieldValidator ID="InternalsMonthRequired" runat="server"
                                                                    ControlToValidate="ddlInternalsMonth" ErrorMessage="Month Selection is required."
                                                                    ToolTip="Month Selection is required." ValidationGroup="DashboardInternals" InitialValue="Select"
                                                                    ForeColor="#FF3300">*</asp:RequiredFieldValidator>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label runat="server" CssClass="control-label" AssociatedControlID="ddlInternalsYear">Year</asp:Label>
                                                            <div class="controls">

                                                                <asp:DropDownList ID="ddlInternalsYear" runat="server" CssClass="chzn-select" ValidationGroup="DashboardInternals">
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
                                                                <asp:RequiredFieldValidator ID="InternalsYearRequired" runat="server"
                                                                    ControlToValidate="ddlInternalsYear" ErrorMessage="Year Selection is required."
                                                                    ToolTip="Year Selection is required." ValidationGroup="DashboardInternals" InitialValue="Select"
                                                                    ForeColor="#FF3300">*</asp:RequiredFieldValidator>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <div class="controls">
                                                                <asp:Button ID="btnGenerateInternalsStatistics" runat="server" CssClass="btn btn-info" Text="Generate Test/Internals Statistics"
                                                                    OnClick="btnGenerateInternalsStatistics_Click" ValidationGroup="DashboardInternals" />
                                                                <asp:ValidationSummary ID="ValidationSummary2" runat="server"
                                                                    ShowMessageBox="false" ValidationGroup="DashboardInternals" ForeColor="Red"
                                                                    ShowSummary="true" meta:resourcekey="ValidationSummary1Resource1" HeaderText="Please fix the following errors :" />
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </div>




                                        <asp:GridView CssClass="table table-striped" ID="gvInternalsMonth" runat="server" AutoGenerateColumns="False" AllowPaging="true"
                                            ShowHeaderWhenEmpty="True" EmptyDataText="No records Found"
                                            AllowSorting="false" Width="100%" EnableModelValidation="True" OnPageIndexChanging="gvAttendanceMonth_PageIndexChanging">
                                            <Columns>
                                                <asp:BoundField DataField="colBranchName"
                                                    HeaderText="Class/Branch Name"
                                                    ReadOnly="True"></asp:BoundField>
                                                <asp:BoundField DataField="colSubjectName"
                                                    HeaderText="Subject Name"
                                                    ReadOnly="True"></asp:BoundField>
                                                <asp:BoundField DataField="col0"
                                                    HeaderText="0-35%"></asp:BoundField>
                                                <asp:BoundField DataField="col35"
                                                    HeaderText="35-60%"></asp:BoundField>
                                                <asp:BoundField DataField="col60"
                                                    HeaderText="60-85%"></asp:BoundField>
                                                <asp:BoundField DataField="col85"
                                                    HeaderText="85-100%"></asp:BoundField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                            <div class="span6">
                                <div class="block">
                                    <div class="navbar navbar-inner block-header">
                                        <div class="muted pull-left">Classwise / Branchwise Test/Internals Chart</div>
                                        <div class="pull-right">
                                            <span class="badge badge-info"></span>

                                        </div>
                                    </div>
                                    <div class="block-content collapse in">
                                        <asp:Chart ID="chrtInternalsMonth" runat="server">
                                            <Series>
                                            </Series>
                                            <ChartAreas>
                                                <asp:ChartArea Name="chrtAreaInternalsMonth"></asp:ChartArea>
                                            </ChartAreas>
                                        </asp:Chart>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </fieldset>
                </form>
            </div>
        </div>
    </div>
</asp:Content>
