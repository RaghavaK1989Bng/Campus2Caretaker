<%@ Page Title="" Language="C#" MasterPageFile="~/Institute/Institute.Master" AutoEventWireup="true" CodeBehind="StudentRegistration.aspx.cs" Inherits="Campus2caretaker.Institute.StudentRegistration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Menu" runat="server">
    <span id="tabid" style="display: none">menu_3</span>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <script type="text/javascript" language="javascript">

            $(document).ready(function () {
                $("#<%=txtParentsContactNumber.ClientID %>").bind('copy paste cut', function (e) {
                    e.preventDefault(); //disable cut,copy,paste
                    alert('cut,copy & paste options are disabled !!');
                    });
            });
         </script>

    <div style="background-color:White;height:100%;">

    <table border="0" align="center" cellpadding="0" cellspacing="1" 
            style="width:100%;height:100%;">
    <tr>
      <td colspan="2" align="left">
          <asp:Label ID="Label11" runat="server" CssClass="headertext" 
              Text="Add / Edit Student Details" meta:resourcekey="Label11Resource1"></asp:Label>
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
            <asp:Label ID="Label1" class="label" runat="server" Text="Student Name :" ></asp:Label></td>
        <td align="left" style="width: 195px">
        
            <asp:TextBox ID="txtStudentName" runat="server" CssClass="textbox" 
                 validate="form" require="Please enter the student name."></asp:TextBox>
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
        
            <asp:TextBox ID="txtStudentAddress" runat="server" CssClass="textarea" 
                 require="Please enter the student address." 
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
        <asp:Label ID="Label6" class="label" runat="server" Text="Father Name :" ></asp:Label></td>
    <td align="left" style="width: 195px">
        
        <asp:TextBox ID="txtFatherName" runat="server" CssClass="textbox" 
            validate="form" require="Please enter the father name."></asp:TextBox>
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
        <asp:Label ID="Label8" runat="server" class="label"  Text="Mother Name :"></asp:Label>
    <td align="left" style="width: 195px">
        
        <asp:TextBox ID="txtMotherName" runat="server" CssClass="textbox" 
            validate="form" require="Please enter the mother name."></asp:TextBox>
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
            <asp:Label ID="Label7" runat="server" class="label" 
                     Text="D.O.B :" ></asp:Label>
            </td>
        <td align="left" style="width: 195px">
          <asp:TextBox ID="txtDOB" runat="server" CssClass="textbox" require="Please select the date of birth." 
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
            <asp:label ID="Label2" class="label" runat="server" Text="Class :" ></asp:label></td>
        <td align="left" style="width: 195px">
                    <div class="dropdown">
                        <asp:DropDownList ID="ddlClass" DataTextField="colBranchName" DataValueField="colBranchId" runat="server" class="dropdown-select" validate="form" require="Required Field Missing.">
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
    <tr runat="server" id="trSemester">
            <td align="left" style="width: 178px">
            <asp:Label ID="Label3" class="label" runat="server" Text="Semester :"></asp:Label></td>
                <td align="left">
                    <div class="dropdown">                                          
                     <asp:DropDownList ID="ddlSemester" runat="server" class="dropdown-select" validate="form"  require="Required Field Missing.">
                            <asp:ListItem Text="Select" Value="" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="1" Value="1"></asp:ListItem>
                            <asp:ListItem Text="2" Value="2"></asp:ListItem>
                            <asp:ListItem Text="3" Value="3"></asp:ListItem>
                            <asp:ListItem Text="4" Value="4"></asp:ListItem>
                            <asp:ListItem Text="5" Value="5"></asp:ListItem>
                            <asp:ListItem Text="6" Value="6"></asp:ListItem>
                            <asp:ListItem Text="7" Value="7"></asp:ListItem>
                            <asp:ListItem Text="8" Value="8"></asp:ListItem>
                </asp:DropDownList> 
                        </div>
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
    <tr runat="server" id="trSemesterLineBreak">
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
            <asp:Label ID="Label5" class="label" runat="server" Text="Roll No :" ></asp:Label></td>
        <td align="left" style="width: 195px">
        
            <asp:TextBox ID="txtRollNo" runat="server" CssClass="textbox" 
                 validate="form" require="Please enter the roll no."></asp:TextBox>
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
                    Text="Parents Contact Number :" ></asp:Label></td>
        <td align="left" style="width: 195px">
        
           <asp:TextBox ID="txtParentsContactNumber" runat="server" CssClass="textbox" 
                 require="Please enter parents contact number." 
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

    <tr>
       
        <td style="width: 178px">&nbsp;</td>
       
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>        
            &nbsp;</td>
    </tr>

    <tr>
       
        <td style="width: 178px">&nbsp;</td>
       
        <td align="center">
            <asp:Label ID="Label4" runat="server" Style="font-size:medium;font-weight:bolder;"
              Text="OR" meta:resourcekey="Label11Resource1"></asp:Label></td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>        
            &nbsp;</td>
    </tr>

    <tr>
       
        <td style="width: 178px">&nbsp;</td>
       
        <td >&nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>        
            &nbsp;</td>
    </tr>

    <tr>
       
        <td style="width: 178px"><asp:Label ID="Label13" runat="server" class="label" meta:resourcekey="Label2Resource1" Text="Import From File :"></asp:Label>&nbsp; <span class="required">[* Required]</span></td>
       
        <td>
          <asp:FileUpload ID="FlUploadcsv" runat="server" />  </td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>        
            &nbsp;</td>
    </tr>

    <tr>
       
        <td style="width: 178px">&nbsp;</td>
       
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>        
            &nbsp;</td>
    </tr>

    <tr>
       
        <td style="width: 178px">&nbsp;</td>
       
        <td align="left">
            <asp:Button ID="btnUpload" runat="server" CssClass="button" Text="Upload" 
                onclick="btnSave_Click" />
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
            &nbsp;</td>
    </tr>

    <tr>
       
        <td style="width: 178px">&nbsp;</td>
       
        <td align="left">
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>        
            &nbsp;</td>
    </tr>

    <tr>
       
        <td style="width: 178px">&nbsp;</td>
       
        <td align="left">
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>        
            &nbsp;</td>
    </tr>

    <tr>
       
        <td style="width: 178px">&nbsp;</td>
       
        <td align="left">
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>        
            &nbsp;</td>
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

                        <asp:GridView ID="gvStudents" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                            ShowHeaderWhenEmpty="True" EmptyDataText="No records Found"
                            AllowSorting="True" Width="100%" 
                            CssClass="Gridview" DataKeyNames="colStudentId" 
                            EnableModelValidation="True" OnRowCreated="gvStudents_RowCreated" onsorting="gvStudents_Sorting"
                            onrowdatabound="gvStudents_RowDataBound" 
                            onselectedindexchanged="gvStudents_SelectedIndexChanged" 
                            >
                            <Columns>
                                <asp:BoundField DataField="colStudentId" 
                                                HeaderText="Student ID" 
                                                SortExpression="colStudentId"
                                                ReadOnly="True" >
                                </asp:BoundField>
                                <asp:BoundField DataField="colStudentName" 
                                                HeaderText="Student Name" 
                                                SortExpression="colStudentName">
                                </asp:BoundField>
                                <asp:BoundField DataField="colFatherName" 
                                                HeaderText="Father Name" 
                                                SortExpression="colFatherName" />
                                <asp:BoundField DataField="colParentsMobileNo" 
                                                HeaderText="Parents Mobile No" 
                                                SortExpression="colParentsMobileNo" />
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
