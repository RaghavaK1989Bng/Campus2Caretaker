<%@ Page Title="" Language="C#" MasterPageFile="~/Institute/Institute.Master" AutoEventWireup="true" CodeBehind="PersonlizeApplicationSchool.aspx.cs" Inherits="Campus2caretaker.Institute.PersonlizeApplicationSchool" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Menu" runat="server">
    <span id="tabid" style="display: none">menu_2</span>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="background-color:White;height:100%;">

    <table border="0" align="center" cellpadding="0" cellspacing="1" 
            style="width:100%;height:100%;">
    <tr>
      <td colspan="2" align="left">
          <asp:Label ID="Label11" runat="server" CssClass="headertext" 
              Text="Add / Edit Class Details" meta:resourcekey="Label11Resource1"></asp:Label>
        </td>
        <td align="left">
            &nbsp;</td>
        <td align="left">
            &nbsp;</td>
        <td align="left">
            &nbsp;</td>
        <td align="left">
            &nbsp;</td>
      <td>&nbsp;</td>
    </tr>
    <tr>
      <td colspan="2" align="left">
                      </td>
        <td align="left">
            &nbsp;</td>
        <td align="left">
            &nbsp;</td>
        <td align="left">
            &nbsp;</td>
        <td align="left">
            &nbsp;</td>
      <td>&nbsp;</td>
    </tr>
    <tr>
        <td align="left" style="width: 178px">
            <asp:Label ID="Label1" class="label" runat="server" Text="Class :" ></asp:Label></td>
        <td align="left" style="width: 195px">
        <asp:TextBox ID="txtClassName" runat="server" CssClass="textbox" 
            validate="form" require="Please enter the class name."></asp:TextBox>
</td>
        <td align="left">
                
        </td>
        <td align="left">
           
        </td>
        <td align="left">
            &nbsp;</td>
        <td align="left">
            &nbsp;</td>
            <td>        </td>
</tr>
    <tr>
        <td align="left" style="width: 178px">
            &nbsp;</td>
        <td align="left" style="width: 195px">
            &nbsp;</td>
        <td align="left" style="width: 178px">
            &nbsp;</td>
        <td align="left" style="width: 195px">
            &nbsp;</td>
        <td align="left">
            &nbsp;</td>
        <td align="left">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td align="left" style="width: 178px">
            <asp:Label ID="Label9" runat="server" class="label"  Text="Head of Class :"></asp:Label>
        <td align="left" style="width: 195px">
        
            <asp:TextBox ID="txtHeadOfClass" runat="server" CssClass="textbox" 
            validate="form" require="Please enter the head of class name."></asp:TextBox>
</td>
        <td align="left">
                
        </td>
        <td align="left">
            
        </td>
        <td align="left">
            &nbsp;</td>
        <td align="left">
            &nbsp;</td>
            <td>        </td>
</tr>
    <tr>
        <td align="left" style="width: 178px">
            &nbsp;</td>
        <td align="left" style="width: 195px">
            &nbsp;</td>
        <td align="left" style="width: 178px">
            &nbsp;</td>
        <td align="left" style="width: 195px">
            &nbsp;</td>
        <td align="left">
            &nbsp;</td>
        <td align="left">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
    <td align="left" style="width: 178px">
        <asp:Label ID="Label6" class="label" runat="server" Text="Head of class Contact :" ></asp:Label></td>
    <td align="left" style="width: 195px">
        
        <asp:TextBox ID="txtHeadOfClassContact" runat="server" CssClass="textbox" 
            validate="form" require="Please enter the head of class contact."></asp:TextBox>
</td>
    <td align="left">
                
    </td>
    <td align="left">
            
    </td>
    <td align="left">
        &nbsp;</td>
    <td align="left">
        &nbsp;</td>
        <td>        </td>
</tr>
    <tr>
        <td align="left" style="width: 178px">
            &nbsp;</td>
        <td align="left" style="width: 195px">
            &nbsp;</td>
        <td align="left" style="width: 178px">
            &nbsp;</td>
        <td align="left" style="width: 195px">
            &nbsp;</td>
        <td align="left">
            &nbsp;</td>
        <td align="left">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    
    <tr>
        
        <td style="width: 178px">&nbsp;            </td>
       
        <td colspan="3">
            <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Save" 
                onclick="btnSave_Click" ValidationGroup="save" OnClientClick="return validate('form');" />
            <asp:Button ID="btnUpdate" runat="server" CssClass="button" Text="Update" 
                onclick="btnUpdate_Click" meta:resourcekey="btnUpdateResource1" 
                 OnClientClick="return validate('form');" />
            <asp:Button ID="btnDelete" runat="server" CssClass="button" Text="Delete" 
                onclick="btnDelete_Click" meta:resourcekey="btnDeleteResource1" 
                OnClientClick="return validate('form');" />
            <asp:Button ID="btnClear" runat="server" CssClass="button" 
                Text="Clear" onclick="btnClear_Click" 
                meta:resourcekey="btnClearResource1" />
        </td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>        </td>
    </tr>
    <tr>
        <td align="left" style="width: 178px">
            &nbsp;</td>
        <td align="left" style="width: 195px">
            &nbsp;</td>
        <td align="left" style="width: 178px">
            &nbsp;</td>
        <td align="left" style="width: 195px">
            &nbsp;</td>
        <td align="left">
            &nbsp;</td>
        <td align="left">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
       
        <td style="width: 178px">&nbsp;            </td>
       
        <td>
<div id="divStatus" runat="server"></div>
        </td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>        
        </td>
    </tr>

</table>
    <table>
            <tr><td style="width: 178px" valign="top">&nbsp;</td>
       
        <td valign="top">
        <div align="left">
            <div class="GridviewDiv">
            <table style="width: 538px" border="0" cellpadding="0" cellspacing="1" 
                    class="GridviewTable">
                <tr>
                    <td>

                        <asp:GridView ID="gvClasses" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                            AllowSorting="True" Width="100%" 
                            ShowHeaderWhenEmpty="True" EmptyDataText="No records Found"
                            CssClass="Gridview" DataKeyNames="colClassId" 
                            EnableModelValidation="True" OnRowCreated="gvClasses_RowCreated" onsorting="gvClasses_Sorting"
                            onrowdatabound="gvClasses_RowDataBound" 
                            onselectedindexchanged="gvClasses_SelectedIndexChanged" >
                            <Columns>
                                <asp:BoundField DataField="colClassId" 
                                                HeaderText="Class ID" 
                                                SortExpression="colClassId"
                                                ReadOnly="True" >
                                </asp:BoundField>
                                <asp:BoundField DataField="colClassName" 
                                                HeaderText="Institute Name" 
                                                SortExpression="colInstituteName">
                                </asp:BoundField>
                                <asp:BoundField DataField="colHeadofClass" 
                                                HeaderText="Head of Class" 
                                                SortExpression="colHeadofClass" />
                                <asp:BoundField DataField="colHeadofClassContact" 
                                                HeaderText="Head of Class Contact" 
                                                SortExpression="colHeadofClassContact" />
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
