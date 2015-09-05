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
                    </fieldset>
                </form>
            </div>
        </div>
        </div>
</asp:Content>
