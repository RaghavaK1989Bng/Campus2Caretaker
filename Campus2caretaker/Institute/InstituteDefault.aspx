<%@ Page Title="" Language="C#" MasterPageFile="~/Institute/Institute.Master" AutoEventWireup="true" CodeBehind="InstituteDefault.aspx.cs" Inherits="Campus2caretaker.Institute.InstituteDefault" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="background-color:White;height:100%;">
        <asp:Chart ID="chartInternals" runat="server" Width="450px">
            <Series>
                <asp:Series ChartType="Pie"  Name="seriesChartInternals" ChartArea="chartAreaInternals"></asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="chartAreaInternals"></asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
    </div>
</asp:Content>
