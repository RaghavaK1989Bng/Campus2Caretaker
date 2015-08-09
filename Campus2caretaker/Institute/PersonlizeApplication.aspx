<%@ Page Title="" Language="C#" MasterPageFile="~/Institute/Institute.Master" AutoEventWireup="true" CodeBehind="PersonlizeApplication.aspx.cs" Inherits="Campus2caretaker.Institute.PersonlizeApplication" EnableEventValidation="false" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="background-color:White;height:100%;">

        <div class="cd-tabs">
	<nav>
		<ul class="cd-tabs-navigation">
        <li><a data-content="ClassDetails" class="selected" href="#0">Add Class</a></li>
			<li><a data-content="SubjectDetails" href="#0">Add Subject</a></li>
   </ul> <!-- cd-tabs-navigation -->
	</nav>
            <ul class="cd-tabs-content">
                <li data-content="ClassDetails" class="selected">
                <table border="0" align="center" cellpadding="0" cellspacing="1"
            style="width: 100%; height: 100%;">
            <tr>
                <td align="center" colspan="10">
                    <asp:Label ID="Label6" runat="server" CssClass="headertext"
                        Text="Add Class Details" meta:resourcekey="Label11Resource1"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="left" style="width: 121px">&nbsp;</td>
                <td colspan="2" align="left"></td>
                <td align="left" style="width: 238px">&nbsp;</td>
                <td align="left">&nbsp;</td>
                <td align="left">&nbsp;</td>
                <td align="left">&nbsp;</td>
                <td align="left">&nbsp;</td>
                <td align="left">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td align="left" style="width: 121px">
                    &nbsp;</td>
                <td align="left" style="width: 178px">
                    &nbsp;</td>
                <td align="left" style="width: 195px">
                    &nbsp;</td>
                <td align="center">
                    <asp:Label ID="Label8" class="label" runat="server" Text="Class :"></asp:Label></td>
                <td align="left" style="visibility:">
                    <asp:TextBox ID="txtClassName" runat="server" CssClass="textbox"
                        validate="classname" require="Please enter the class name."></asp:TextBox>
                </td>
                <td align="left">
                    &nbsp;</td>
                <td align="left">
                    &nbsp;</td>
                <td align="left">

                    &nbsp;</td>
                <td align="left">&nbsp;</td>
                <td></td>
            </tr>
            <tr runat="server" id="tr1">
                <td align="left" style="width: 121px">
                    &nbsp;</td>
                <td align="left" style="width: 178px">
                    &nbsp;</td>
                <td align="left" style="width: 195px">
                    &nbsp;</td>
                <td align="left" style="width: 238px">&nbsp;</td>
                <td align="left">
                    &nbsp;</td>
                <td align="left">
                    &nbsp;</td>
                <td align="left">
                    &nbsp;</td>
                <td align="left">

                    &nbsp;</td>
                <td align="left">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td align="center" colspan="10">
                    <asp:Button ID="btnAddClass" runat="server" CssClass="button orange" Text="Add Class"
                        OnClick="btnAddClass_Click" ValidationGroup="saveclass" OnClientClick="return validate('classname');"/>
                    <br />
                    <br />
                    <asp:Button ID="btnRemoveClass" runat="server" CssClass="button orange" Text="Remove Class"
                        OnClick="btnRemoveClass_Click" />
                    <br />
                    <br />
                    </td>
            </tr>
            <tr>
                <td align="center" colspan="10">
                        
                                            <div class="lstClassContianer">
                                                <div class="lstClass">
                    <asp:ListBox ID="lstClasses" runat="server" SelectionMode="Single" CssClass="listbox" Height="350px" Width="175px"></asp:ListBox>
                            </div>
                                                </div>
                    <br />
                    <br />
            </tr>
            <tr>
                <td align="left" style="width: 121px">
                    &nbsp;</td>
                <td align="left">
                    &nbsp;</td>
                <td align="left">
                    &nbsp;</td>
                <td align="left" style="width: 238px">
                    <div id="divStatus" runat="server"></div>
                </td>
                <td align="left" style="width: 178px">&nbsp;</td>
                <td align="left" style="width: 178px">&nbsp;</td>
                <td align="left">&nbsp;</td>
                <td align="left">&nbsp;</td>
                <td align="left">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td align="center" colspan="10">
                    <asp:Button ID="btnSave" runat="server" CssClass="button orange" Text="Save"
                        OnClick="btnSave_Click"/>
                    &nbsp;
                    <asp:Button ID="btnClear" runat="server" CssClass="button orange"
                        Text="Clear" OnClick="btnClear_Click"
                        meta:resourcekey="btnClearResource1" />
                    &nbsp;
                    &nbsp;
                    </td>
            </tr>

            <tr>
                <td align="left" style="width: 121px">&nbsp;</td>
                <td align="left" style="width: 178px">&nbsp;</td>
                <td align="left" style="width: 195px">&nbsp;</td>
                <td align="left" style="width: 238px">&nbsp;</td>
                <td align="left" style="width: 178px">&nbsp;</td>
                <td align="left" style="width: 178px">&nbsp;</td>
                <td align="left">&nbsp;</td>
                <td align="left">&nbsp;</td>
                <td align="left">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>

            <tr>
                <td align="left" colspan="10">
        <div align="center">
            <div class="GridviewDiv">
            <table style="width: 380px" border="0" cellpadding="0" cellspacing="1" 
                    class="GridviewTable">
                <tr>
                    <td>

                        <asp:GridView ID="gvClasses" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                            ShowHeaderWhenEmpty="True" EmptyDataText="No records Found"
                            AllowSorting="True" Width="100%" 
                            CssClass="Gridview" 
                            EnableModelValidation="True" OnRowCreated="gvClasses_RowCreated" onsorting="gvClasses_Sorting">
                            <Columns>
                                <asp:BoundField DataField="colBranchId" 
                                                HeaderText="Class / Branch Id"
                                                SortExpression="colBranchId"
                                                ReadOnly="True" >
                                </asp:BoundField>
                                <asp:BoundField DataField="colBranchName" 
                                                HeaderText="Class / Branch Name" 
                                                SortExpression="colBranchName">
                                </asp:BoundField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
            </div>
            </div>
                </td>
            </tr>

            <tr>
                <td align="left" style="width: 121px">&nbsp;</td>
                <td valign="top" colspan="2">
                    &nbsp;</td>
                <td align="left" style="width: 238px">&nbsp;</td>
                <td align="left" colspan="2">&nbsp;</td>
                <td align="left">&nbsp;</td>
                <td align="left">&nbsp;</td>
                <td align="left">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>

                <td style="width: 121px">&nbsp;</td>

                <td style="width: 178px">&nbsp;            </td>

                <td>
                    &nbsp;</td>
                <td style="width: 238px">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td></td>
            </tr>

            <tr>

                <td style="width: 121px">&nbsp;</td>

                <td style="width: 178px">&nbsp;</td>

                <td>
                    &nbsp;</td>
                <td style="width: 238px">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>

        </table>
                    </li>
                <li data-content="SubjectDetails"> 
                    <table border="0" align="center" cellpadding="0" cellspacing="1"
            style="width: 100%; height: 100%;">
            <tr>
                <td align="center" colspan="11">
                    <asp:Label ID="Label7" runat="server" CssClass="headertext"
                        Text="Add Subject Details" meta:resourcekey="Label11Resource1"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="left" style="width: 121px">&nbsp;</td>
                <td colspan="2" align="left"></td>
                <td align="left">&nbsp;</td>
                <td align="left" style="width: 238px">&nbsp;</td>
                <td align="left">&nbsp;</td>
                <td align="left">&nbsp;</td>
                <td align="left">&nbsp;</td>
                <td align="left">&nbsp;</td>
                <td align="left">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td align="left" style="width: 121px">
                    &nbsp;</td>
                <td align="left" style="width: 178px">
                    &nbsp;</td>
                <td align="left" style="width: 238px">
                    <asp:Label ID="Label9" class="label" runat="server" Text="Class :"></asp:Label></td>
                <td align="left" style="width: 238px">
                    <div class="dropdown">
                        <asp:DropDownList ID="ddlClass" runat="server" class="dropdown-select" validate="form"  require="Required Field Missing." 
                            DataSourceID="dsClasses" DataTextField="colBranchName" DataValueField="colBranchId">
                        </asp:DropDownList>
                        </div></td>
                <td align="left" style="visibility:">
                    <asp:SqlDataSource ID="dsClasses" runat="server" 
                                        ConnectionString="<%$ ConnectionStrings:C2CConnectionString %>" 
                                        SelectCommand="SELECT * FROM [tblBranchDetails]"></asp:SqlDataSource>
                    </td>
                <td align="left">
                    &nbsp;</td>
                <td align="left">
                    &nbsp;</td>
                <td align="left">

                    &nbsp;</td>
                <td align="left">&nbsp;</td>
                <td></td>
            </tr>
            <tr runat="server" id="trSemesterLineBreak">
                <td align="left" style="width: 121px">
                    &nbsp;</td>
                <td align="left" style="width: 178px">
                    &nbsp;</td>
                <td align="left" style="width: 238px">&nbsp;</td>
                <td align="left" style="width: 238px">&nbsp;</td>
                <td align="left">
                    &nbsp;</td>
                <td align="left">
                    &nbsp;</td>
                <td align="left">
                    &nbsp;</td>
                <td align="left">

                    &nbsp;</td>
                <td align="left">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr runat="server" id="trSemester">
                <td align="left" style="width: 121px">
                    &nbsp;</td>
                <td align="left" style="width: 178px">
                    &nbsp;</td>
                <td align="left" style="width: 238px">
                                        <asp:Label ID="Label10" class="label" runat="server" Text="Semester :"></asp:Label></td>
                <td align="left" style="width: 238px">
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
                <td align="left">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td align="left" style="width: 121px">
                    &nbsp;</td>
                <td align="left" style="width: 178px">
                    &nbsp;</td>
                <td align="left" style="width: 238px">&nbsp;</td>
                <td align="left" style="width: 238px">&nbsp;</td>
                <td align="left">&nbsp;</td>
                <td align="left">&nbsp;</td>
                <td align="left">
                    &nbsp;</td>
                <td align="left">

                    &nbsp;</td>
                <td align="left">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td align="left" style="width: 121px">
                    &nbsp;</td>
                <td align="left" style="width: 178px">
                    &nbsp;</td>
                <td align="left" style="width: 238px">
                    <asp:Label ID="Label12" runat="server" class="label" Text="Subject Name :"></asp:Label>
                </td>
                <td align="left" style="width: 238px">

                    <asp:TextBox ID="txtSubjectName" runat="server" CssClass="textbox"
                        validate="form" require="Please enter the subject name."></asp:TextBox>
                </td>
                <td align="left">
                    &nbsp;</td>
                <td align="left">

                    &nbsp;</td>
                <td align="left">
                    &nbsp;</td>
                <td align="left">

                    &nbsp;</td>
                <td align="left">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
                        <tr>
                <td align="left" style="width: 121px">
                    &nbsp;</td>
                <td align="left" style="width: 178px">
                    &nbsp;</td>
                <td align="left" style="width: 238px">&nbsp;</td>
                <td align="left" style="width: 238px">&nbsp;</td>
                <td align="left">&nbsp;</td>
                <td align="left">&nbsp;</td>
                <td align="left">
                    &nbsp;</td>
                <td align="left">

                    &nbsp;</td>
                <td align="left">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td align="center" colspan="11">
                    <br />
                    <asp:Button ID="btnAddSubjectTheory" runat="server" CssClass="button orange" Text="Add Subject (Theory)"
                        OnClick="btnAddSubjectTheory_Click" ValidationGroup="saveSubject" OnClientClick="return validate('form');"/>
                    <br />
                    <br />
                    <asp:Button ID="btnAddSubjectLab" runat="server" CssClass="button orange" Text="Add Subject (Lab)"
                        OnClick="btnAddSubjectLab_Click" ValidationGroup="saveSubject" OnClientClick="return validate('form');"/>
                    <br />
                    <br />
                    <asp:Button ID="btnRemoveSubject" runat="server" CssClass="button orange" Text="Remove Subject"
                        OnClick="btnRemoveSubject_Click"/>
                    </td>
            </tr>
                        <tr>
                <td align="left" style="width: 121px">
                    &nbsp;</td>
                <td align="left" style="width: 178px">
                    &nbsp;</td>
                <td align="left" style="width: 238px">&nbsp;</td>
                <td align="left" style="width: 238px">&nbsp;</td>
                <td align="left">&nbsp;</td>
                <td align="left">&nbsp;</td>
                <td align="left">
                    &nbsp;</td>
                <td align="left">

                    &nbsp;</td>
                <td align="left">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td align="left" style="width: 121px">
                    &nbsp;<td align="left" style="width: 178px">
                    &nbsp;<td align="center">
                        
                                            &nbsp;</td>
                <td align="center">
                        
                                            <div class="lstClassContianer">
                                                <div class="lstClass">
                    <asp:ListBox ID="lstSubjectsTheory" runat="server" SelectionMode="Single" CssClass="listbox" Height="350px" Width="175px"></asp:ListBox>
                        </div>
                                                </div>
                </td>
                <td align="center">    
                    <div class="lstClassContianer">
                                                <div class="lstClass">
                    <asp:ListBox ID="lstSubjectsLab" runat="server" SelectionMode="Single" CssClass="listbox" Height="350px" Width="175px"></asp:ListBox>
                        </div>
                                                </div>
                </td>
                <td align="center">
                    &nbsp;</td>
                <td align="center">
                    <br />
                    <br />
                    </td>
                <td align="left">
                    &nbsp;</td>
                <td align="left">&nbsp;</td>
                <td></td>
            </tr>
            <tr>
                <td align="left" style="width: 121px">
                    &nbsp;</td>
                <td align="left">
                    &nbsp;</td>
                <td align="left" style="width: 238px">
                    <div id="div2" runat="server"></div>
                </td>
                <td align="left" style="width: 238px">
                    &nbsp;</td>
                <td align="left" style="width: 178px">&nbsp;</td>
                <td align="left" style="width: 178px">&nbsp;</td>
                <td align="left">&nbsp;</td>
                <td align="left">&nbsp;</td>
                <td align="left">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td align="center" colspan="11">
                    &nbsp;
                    &nbsp;
                    <asp:Button ID="btnSaveSubjects" runat="server" CssClass="button orange" Text="Save"
                        OnClick="btnSaveSubjects_Click"/>
                    &nbsp;
                    <asp:Button ID="btnClearSubjects" runat="server" CssClass="button orange"
                        Text="Clear" OnClick="btnClearSubjects_Click"
                        meta:resourcekey="btnClearResource1"/>
                    </td>
            </tr>

            <tr>
                <td align="left" style="width: 121px">&nbsp;</td>
                <td align="left" style="width: 178px">&nbsp;</td>
                <td align="left" style="width: 238px">&nbsp;</td>
                <td align="left" style="width: 238px">&nbsp;</td>
                <td align="left" style="width: 178px">&nbsp;</td>
                <td align="left" style="width: 178px">&nbsp;</td>
                <td align="left">&nbsp;</td>
                <td align="left">&nbsp;</td>
                <td align="left">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>

            <tr>
                <td align="left" colspan="11">
        <div align="center">
            <div class="GridviewDiv">
            <table style="width: 380px" border="0" cellpadding="0" cellspacing="1" 
                    class="GridviewTable">
                <tr>
                    <td>

                        <asp:GridView ID="gvSubjects" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                            ShowHeaderWhenEmpty="True" EmptyDataText="No records Found"
                            AllowSorting="True" Width="100%" 
                            CssClass="Gridview" 
                            EnableModelValidation="True" OnRowCreated="gvSubjects_RowCreated" onsorting="gvSubjects_Sorting"
                            >
                            <Columns>
                                <asp:BoundField DataField="colBranchId" 
                                                HeaderText="Class / Branch" 
                                                SortExpression="colBranchId"
                                                ReadOnly="True" >
                                </asp:BoundField>
                                <asp:BoundField DataField="colSubjectName" 
                                                HeaderText="Subject Name" 
                                                SortExpression="colSubjectName">
                                </asp:BoundField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
            </div>
            </div>
                </td>
            </tr>

            <tr>
                <td align="left" style="width: 121px">&nbsp;</td>
                <td valign="top" colspan="2">
                    &nbsp;</td>
                <td valign="top">
                    &nbsp;</td>
                <td align="left" style="width: 238px">&nbsp;</td>
                <td align="left" colspan="2">&nbsp;</td>
                <td align="left">&nbsp;</td>
                <td align="left">&nbsp;</td>
                <td align="left">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>

                <td style="width: 121px">&nbsp;</td>

                <td style="width: 178px">&nbsp;            </td>

                <td style="width: 238px">&nbsp;</td>
                <td style="width: 238px">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td></td>
            </tr>

            <tr>

                <td style="width: 121px">&nbsp;</td>

                <td style="width: 178px">&nbsp;</td>

                <td style="width: 238px">&nbsp;</td>
                <td style="width: 238px">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>

        </table>
                 </li>
</ul>
</div>

    </div>
</asp:Content>
