<%@ Page Title="" Language="C#" MasterPageFile="~/Institute/Institute.Master" AutoEventWireup="true" CodeBehind="UpdateInternals.aspx.cs" Inherits="Campus2caretaker.Institute.UpdateInternals" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Menu" runat="server">
    <span id="tabid" style="display: none">menu_6</span>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="background-color: White; height: 100%;">

        <table border="0" align="center" cellpadding="0" cellspacing="1"
            style="width: 100%; height: 100%;">
            <tr>
                <td align="left" colspan="8">
                    <asp:Label ID="Label11" runat="server" CssClass="headertext"
                        Text="Update Internal Details" meta:resourcekey="Label11Resource1"></asp:Label>
                </td>
                <td align="left">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td align="left" style="width: 121px; height: 35px;"></td>
                <td colspan="2" align="left" style="height: 35px">
                    <asp:RadioButton ID="rbNew" runat="server" AutoPostBack="True" Checked="True" GroupName="rbNewEdit" OnCheckedChanged="rbNew_CheckedChanged" Text="New Entry" />
                    <asp:RadioButton ID="rbEdit" runat="server" AutoPostBack="True" GroupName="rbNewEdit" OnCheckedChanged="rbEdit_CheckedChanged" Text="Edit Entry" />
                </td>
                <td align="left" style="width: 238px; height: 35px;"></td>
                <td align="left" style="height: 35px"></td>
                <td align="left" style="height: 35px"></td>
                <td align="left" style="height: 35px"></td>
                <td align="left" style="height: 35px"></td>
                <td align="left" style="height: 35px"></td>
                <td style="height: 35px"></td>
            </tr>
            <tr>
                <td align="left" style="width: 121px">&nbsp;</td>
                <td align="left" style="width: 178px">
                    <asp:Label ID="Label3" class="label" runat="server" Text="Class :"></asp:Label></td>
                <td align="left" style="width: 195px">
                    <div class="dropdown">
                        <asp:DropDownList ID="ddlClass" runat="server" class="dropdown-select" validate="form" require="Required Field Missing."
                            DataTextField="colBranchName" DataValueField="colBranchId">
                        </asp:DropDownList>
                    </div>
                </td>
                <td align="left" style="width: 238px">
                    
                </td>
                <td align="left">&nbsp;</td>
                <td align="left">&nbsp;</td>
                <td align="left">&nbsp;</td>
                <td align="left">&nbsp;</td>
                <td align="left">&nbsp;</td>
                <td></td>
            </tr>
            <tr runat="server" id="trSemesterLineBreak">
                <td align="left" style="width: 121px">&nbsp;</td>
                <td align="left" style="width: 178px">&nbsp;</td>
                <td align="left" style="width: 195px">&nbsp;</td>
                <td align="left" style="width: 238px">&nbsp;</td>
                <td align="left">&nbsp;</td>
                <td align="left">&nbsp;</td>
                <td align="left">&nbsp;</td>
                <td align="left">&nbsp;</td>
                <td align="left">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr runat="server" id="trSemester">
                <td align="left" style="width: 121px">&nbsp;</td>
                <td align="left" style="width: 178px">
                    <asp:Label ID="Label5" class="label" runat="server" Text="Semester :"></asp:Label></td>
                <td align="left" style="width: 195px">
                    <div class="dropdown">
                        <asp:DropDownList ID="ddlSemester" runat="server" class="dropdown-select" validate="form" require="Required Field Missing.">
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
                <td align="left" style="width: 238px">&nbsp;</td>
                <td align="left">&nbsp;</td>
                <td align="left">&nbsp;</td>
                <td align="left">&nbsp;</td>
                <td align="left">&nbsp;</td>
                <td align="left">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td align="left" style="width: 121px">&nbsp;</td>
                <td align="left" style="width: 178px">&nbsp;</td>
                <td align="left" style="width: 195px">&nbsp;</td>
                <td align="left" style="width: 238px">&nbsp;</td>
                <td align="left">&nbsp;</td>
                <td align="left">&nbsp;</td>
                <td align="left">&nbsp;</td>
                <td align="left">&nbsp;</td>
                <td align="left">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td align="left" style="width: 121px">&nbsp;</td>
                <td align="left" style="width: 178px">
                    <asp:Label ID="Label4" runat="server" class="label" Text="Month :"></asp:Label>
                </td>
                <td align="left" style="width: 195px">

                    <div class="dropdown">
                        <asp:DropDownList ID="ddlMonth" runat="server" class="dropdown-select" validate="form" require="Required Field Missing.">
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
                    </div>
                </td>
                <td align="left" style="width: 238px">&nbsp;</td>
                <td align="left">&nbsp;</td>
                <td align="left">&nbsp;</td>
                <td align="left">&nbsp;</td>
                <td align="left">&nbsp;</td>
                <td align="left">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td align="left" style="width: 121px; height: 22px;"></td>
                <td align="left" style="height: 22px"></td>
                <td align="left" style="height: 22px"></td>
                <td align="left" style="width: 238px; height: 22px;">
                    <div id="divStatus" runat="server"></div>
                </td>
                <td align="left" style="width: 178px; height: 22px;"></td>
                <td align="left" style="width: 178px; height: 22px;"></td>
                <td align="left" style="height: 22px"></td>
                <td align="left" style="height: 22px"></td>
                <td align="left" style="height: 22px"></td>
                <td style="height: 22px"></td>
            </tr>
            <tr>
                <td align="left" style="width: 121px">&nbsp;</td>
                <td align="left" >
                    <asp:Label ID="Label12" runat="server" class="label" Text="Year :"></asp:Label>
                </td>
                <td align="left">

                    <div class="dropdown">
                        <asp:DropDownList ID="ddlYear" runat="server" class="dropdown-select" validate="form" require="Required Field Missing.">
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
                    </div>
                </td>
                <td align="center" style="width: 238px">&nbsp;
                    <asp:Button ID="btnGetStudentsList" runat="server" CssClass="button" onclick="btnGetStudentsList_Click" Text="Get Details" ValidationGroup="save" OnClientClick="return validate('form');"/>
                    <asp:Button ID="btnGetStudentsListEdit" runat="server" CssClass="button" onclick="btnGetStudentsListEdit_Click" Text="Get Details" ValidationGroup="save" OnClientClick="return validate('form');"/>
                </td>
                <td align="center" colspan="2">&nbsp;
                </td>
                <td align="left">&nbsp;</td>
                <td align="left">&nbsp;</td>
                <td align="left">&nbsp;</td>
                <td></td>
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
                <td align="left" style="width: 121px">&nbsp;</td>
                <td valign="top" colspan="5">
                    <div align="center">
                        <div class="GridviewDiv">
                            <table style="width: 380px" border="0" cellpadding="0" cellspacing="1"
                                class="GridviewTable">
                                <tr>
                                    <td>

                                        <asp:GridView ID="gvInternals" runat="server" AutoGenerateColumns="False" AllowPaging="false"
                                            ShowHeaderWhenEmpty="True" EmptyDataText="No records Found" OnRowCommand="gvInternals_RowCommand"
                                            AllowSorting="True" Width="100%" OnDataBound="gvInternals_DataBound" OnRowCreated="gvInternals_RowCreated"
                                            CssClass="Gridview">
                                            <Columns>
                                                <asp:BoundField DataField="RowNumber" HeaderText="Row Number" HeaderStyle-ForeColor="Black" ItemStyle-Width="60px" />
                                                <asp:TemplateField HeaderText="Student Name" HeaderStyle-ForeColor="Black">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblStudentName" runat="server" Width="180px" Text='<%# Bind("Column1") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Roll No" HeaderStyle-ForeColor="Black">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblRollNo" runat="server" Width="150px" Text='<%# Bind("Column2") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Max Marks" HeaderStyle-ForeColor="Black" ControlStyle-Width="80px">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtMaxMarks" runat="server"></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Min Marks" HeaderStyle-ForeColor="Black" ControlStyle-Width="80px">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtMinMarks" runat="server"></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Marks Scored" HeaderStyle-ForeColor="Black" ControlStyle-Width="80px">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtMarksScored" runat="server"></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Student ID" HeaderStyle-ForeColor="Black" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblStudentID" runat="server" Width="180px" Text='<%# Bind("Column6") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ControlStyle-Width="80px">
                                                    <ItemTemplate>
                                                       <asp:LinkButton runat="server" ID="Save"
                                                           CommandName="Save" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Text="Save\Update" CssClass="selectbutton btn-custom"/>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </td>
                <td align="left">&nbsp;</td>
                <td align="left">&nbsp;</td>
                <td align="left">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
</table>
                    <div style="visibility:hidden">
        <table>
                            <tr>

                <td style="width: 121px">&nbsp;</td>

                <td style="width: 178px">&nbsp;            </td>

                <td align="center">
            <asp:Label ID="Label1" runat="server" Style="font-size:medium;font-weight:bolder;"
              Text="OR" meta:resourcekey="Label11Resource1"></asp:Label></td>
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

                <td style="width: 178px">
                    <asp:Label ID="Label13" runat="server" class="label" meta:resourcekey="Label2Resource1" Text="Import From File :"></asp:Label>
                    &nbsp; <span class="required">[* Required]</span></td>

                <td>
          <asp:FileUpload ID="FlUploadcsv" runat="server" /></td>
                <td style="width: 238px"><a id="studentRegistration" class="gridLink" href="../Template/StudentRegistrationSample.xlsx" target="_blank">Download sample file</a></td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>

            <tr>

                <td style="width: 121px">&nbsp;</td>

                <td style="width: 178px">
                    &nbsp;</td>

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

            <tr>

                <td style="width: 121px">&nbsp;</td>

                <td style="width: 178px">
                    &nbsp;</td>

                <td>
                    <asp:Button ID="btnUpload" runat="server" CssClass="button" onclick="btnUpload_Click" Text="Upload" />
                </td>
                <td style="width: 238px">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>

            <tr>

                <td style="width: 121px">&nbsp;</td>

                <td style="width: 178px">
                    &nbsp;</td>

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
        </div>
    </div>
</asp:Content>
