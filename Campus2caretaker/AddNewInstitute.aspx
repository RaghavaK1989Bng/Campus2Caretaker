<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AddNewInstitute.aspx.cs" Inherits="Campus2caretaker.AddNewInstitute" EnableEventValidation="false"%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
            });
         </script>

    <div style="background-color:White;height:100%;">

    <table border="0" align="center" cellpadding="0" cellspacing="1" 
            style="width:100%;height:100%;">
    <tr>
      <td colspan="2" align="left">
          <asp:Label ID="Label11" runat="server" CssClass="headertext" 
              Text="Add / Edit Institute Details" meta:resourcekey="Label11Resource1"></asp:Label>
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
            <asp:Label ID="Label1" class="label" runat="server" Text="Institute Name :" ></asp:Label></td>
        <td align="left" style="width: 195px">
        
            <asp:TextBox ID="txtInstituteName" runat="server" CssClass="textbox" 
                 validate="form" require="Please enter the institute name."></asp:TextBox>
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
            <asp:Label ID="Label9" runat="server" class="label"  Text="Address :"></asp:Label>
        <td align="left" style="width: 195px">
        
            <asp:TextBox ID="txtInstituteAddress" runat="server" CssClass="textarea" 
                 require="Please enter the institute address." 
                validate="form" TextMode="MultiLine"></asp:TextBox>
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
        <asp:Label ID="Label6" class="label" runat="server" Text="District :" ></asp:Label></td>
    <td align="left" style="width: 195px">
        
        <asp:TextBox ID="txtDistrict" runat="server" CssClass="textbox" 
            validate="form" require="Please enter the district."></asp:TextBox>
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
        <asp:Label ID="Label8" runat="server" class="label"  Text="State :"></asp:Label>
    <td align="left" style="width: 195px">
        
        <asp:TextBox ID="txtState" runat="server" CssClass="textbox" 
            validate="form" require="Please enter the state."></asp:TextBox>
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
                <asp:Label ID="Label4" class="label" runat="server" Text="Institute Logo :" ></asp:Label></td>
            <td align="left" style="width: 195px">
              <asp:FileUpload ID="FileUpPhoto" runat="server" />
                <asp:Button ID="btnUpload" CssClass="button" runat="server" Text="Upload" 
                    onclick="btnUpload_Click" />
              <br />
              <br />
              <img id="imgInstituteLogo" alt="" runat="server" style="height: 150px; width: 150px;" />
    </td>

        <td align="left" style="width: 178px">
                
                </td>
                <td align="left" style="width: 195px">
              
           
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
            <asp:Label ID="Label7" runat="server" class="label" 
                     Text="Institute Phone Number :" ></asp:Label>
            </td>
        <td align="left" style="width: 195px">
          <asp:TextBox ID="txtInstitutePhoneNumber" runat="server" CssClass="textbox" require="Please enter the institute phone number." 
                validate="form"></asp:TextBox>
</td>

    <td align="left" style="width: 178px">
                
            </td>
            <td align="left" style="width: 195px">
                </td>
           
        <td align="left">
            &nbsp;</td>
        <td align="left">
            &nbsp;</td>
            <td>        </td>
    </tr>
    <tr>
            <td style="width: 178px">&nbsp;            </td>
       
            <td align="left" style="width: 195px">
                &nbsp;</td>
            <td align="left">
                &nbsp;</td>
            <td align="left">
                &nbsp;</td>
            <td align="left">
                &nbsp;</td>
            <td align="left">
                &nbsp;</td>
            <td>        </td>

    </tr>
    <tr>
        <td align="left" style="width: 178px">
            <asp:label ID="Label2" class="label" runat="server" Text="Institute Type :" ></asp:label></td>
        <td align="left" style="width: 195px">
        <div class="dropdown">
                        <asp:DropDownList ID="ddlInstituteType" runat="server" class="dropdown-select" validate="form"  require="Required Field Missing.">
                            <asp:ListItem Text="Select" Value="" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="School" Value="S"></asp:ListItem>
                            <asp:ListItem Text="College" Value="C"></asp:ListItem>
                            <asp:ListItem Text="Degree College" Value="D"></asp:ListItem>

                </asp:DropDownList>
                </div>
</td>
                    <td align="left" style="width: 178px">
                        &nbsp;</td>
        <td align="left" style="width: 195px">
        
            &nbsp;</td>
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
            <asp:Label ID="Label13" class="label" runat="server" Text="Institute Email ID:" ></asp:Label></td>
            <td align="left" style="width: 195px">
        
            <asp:TextBox ID="txtInstituteEmail" runat="server" CssClass="textbox" 
                 validate="form" require="Please enter the institute email id." 
                regular="<p>Please check the email address entered in the form</p><p>example@address.com</p>"
                validexpress="[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?\.)+[a-zA-z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?">
            </asp:TextBox>
            </td>
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
            <asp:Label ID="Label5" class="label" runat="server" Text="Principal Name :" ></asp:Label></td>
        <td align="left" style="width: 195px">
        
            <asp:TextBox ID="txtPrincipalName" runat="server" CssClass="textbox" 
                 validate="form" require="Please enter the principal name."></asp:TextBox>
</td>
            <td align="left" style="width: 178px">
                
            </td>
            <td align="left" style="width: 195px">
                </td>
           
            <td align="left">
                &nbsp;</td>
            <td align="left">
                &nbsp;</td>
            <td>
                &nbsp;</td>
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
            <asp:Label ID="Label14" runat="server" class="label" 
                    Text="Principal Contact Number :" ></asp:Label></td>
        <td align="left" style="width: 195px">
        
           <asp:TextBox ID="txtPrincipalContactNumber" runat="server" CssClass="textbox" 
                 require="Please enter principal contact number." 
                validate="form"></asp:TextBox>
            </td>
            <td align="left" style="width: 178px">
                
            </td>
            <td align="left" style="width: 195px">
               </td>
           
            <td align="left">
                &nbsp;</td>
            <td align="left">
                &nbsp;</td>
            <td>
                &nbsp;</td>
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

                        <asp:GridView ID="gvInstitutes" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                            ShowHeaderWhenEmpty="True" EmptyDataText="No records Found"
                            AllowSorting="True" DataSourceID="dsGridview" Width="100%" 
                            CssClass="Gridview" DataKeyNames="colInstituteId" 
                            EnableModelValidation="True" OnRowCreated="gvInstitutes_RowCreated" onsorting="gvInstitutes_Sorting"
                            onrowdatabound="gvInstitutes_RowDataBound" 
                            onselectedindexchanged="gvInstitutes_SelectedIndexChanged" 
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
                                <asp:BoundField DataField="colInstituteType" 
                                                HeaderText="Institute Type" 
                                                SortExpression="colInstituteType" />
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
            </div>
            <asp:SqlDataSource ID="dsGridview" runat="server" ConnectionString="<%$ ConnectionStrings:C2CConnectionString %>"
                SelectCommand="SELECT [colInstituteId], [colInstituteName], [colPhone],[colInstituteType] FROM [tblInstituteDetails]">
            </asp:SqlDataSource>
            </div>
    </td>
        <td valign="top">        
            &nbsp;</td>
    
    </tr>
        </table>

    </div>
</asp:Content>
