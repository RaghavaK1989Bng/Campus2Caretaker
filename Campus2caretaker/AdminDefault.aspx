<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AdminDefault.aspx.cs" Inherits="Campus2caretaker.AdminDefault" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="background-color:White;height:100%;">
        <table border="0" align="center" cellpadding="0" cellspacing="1" 
            style="width:100%;height:100%;">
    <tr>
      <td colspan="6" align="left">
          <asp:Label ID="Label11" runat="server" CssClass="headertext" 
              Text="Registered Institutes" meta:resourcekey="Label11Resource1"></asp:Label>
        </td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
             <tr>
            <td align="left">
                &nbsp;</td>
            <td align="left">
                &nbsp;</td>
            <td align="left">
                &nbsp;</td>
            <td align="left">
                &nbsp;</td>
            <td align="left">
                &nbsp;</td>
            <td align="left">
                &nbsp;</td>
            <td>
                &nbsp;</td>
                 <td align="center">            &nbsp;</td>
                 <td align="center">            &nbsp;</td>
        </tr>
                <tr>
      <td align="left">
        </td>
        <td align="left">
                        <asp:Label ID="Label1" class="label" runat="server" Text="Institute Name :" ></asp:Label></td>

        <td align="left">
            <asp:TextBox ID="txtInstituteName" runat="server" CssClass="textbox"></asp:TextBox></td>
        <td align="left">
                        <asp:Label ID="Label2" class="label" runat="server" Text="District :" ></asp:Label></td>

        <td align="left">
                        <asp:TextBox ID="txtDistrict" runat="server" CssClass="textbox"></asp:TextBox></td>
      <td align="left">            <asp:Label ID="Label3" class="label" runat="server" Text="State :" ></asp:Label></td>

                    <td align="left">            <asp:TextBox ID="txtState" runat="server" CssClass="textbox"></asp:TextBox></td>
 <td > <asp:Button ID="btnApplyFilter" runat="server" CssClass="button" Text="Apply Filter" OnClick="btnApplyFilter_Click" /></td>
            <td><asp:Button ID="btnClearFilter" runat="server" CssClass="button" Text="Clear Filter" OnClick="btnClearFilter_Click" /></td>
                    
    </tr>
             <tr>
            <td align="left">
                &nbsp;</td>
            <td align="left" >
                &nbsp;</td>
            <td align="left">
                &nbsp;</td>
            <td align="left">
                &nbsp;</td>
            <td align="left">
                &nbsp;</td>
            <td align="center">            &nbsp;</td>
            <td>
                    </td>
                 <td align="center">            &nbsp;</td>
        </tr>
            </table>
    <table align="center" cellpadding="0" cellspacing="1" 
            style="width:100%;height:100%;">
            <tr><td style="width: 1px" valign="top">&nbsp;</td>
       
        <td valign="top">
        <div align="center">
            <div class="GridviewDiv">
            <table style="width: 538px" border="0" cellpadding="0" cellspacing="1" 
                    class="GridviewTable">
                <tr>
                    <td>

                        <asp:GridView ID="gvInstitutes" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                            ShowHeaderWhenEmpty="True" EmptyDataText="No records Found"
                            AllowSorting="True" Width="100%" 
                            CssClass="Gridview" 
                            EnableModelValidation="True" OnRowCreated="gvInstitutes_RowCreated" onsorting="gvInstitutes_Sorting"
                            >
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
                    </td>
                </tr>
            </table>
            </div>
            </div>
    </td>
        <td valign="top">        
            &nbsp;</td>
    
    </tr>
        </table>
        </div>
</asp:Content>
