<%@ Page Title="SMS" Language="C#" MasterPageFile="~/Institute/Institute.Master" AutoEventWireup="true" CodeBehind="SendSMS.aspx.cs" Inherits="Campus2caretaker.Institute.SendSMS" EnableEventValidation ="false" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="block">
        <div class="navbar navbar-inner block-header">
            <div class="muted pull-left">Send SMS</div>
        </div>
        <div class="block-content collapse in">
            <div class="span12">
                <form class="form-horizontal">
                    <fieldset>
                        <legend>Send SMS</legend>
                        <div class="control-group">
                            <label class="control-label"></label>
                            <div class="table-toolbar">
                                 <div class="btn-group">
                                         <button data-toggle="dropdown" class="btn dropdown-toggle">Send SMS To<span class="caret"></span></button>
                                         <ul class="dropdown-menu">
                                            <li><a href="#" id="lnkallstudents" runat="server">All Students</a></li>
											<li><a href="#" id="lnkbranchwise" runat="server">Branchwise</a></li>
											<li><a href="#" id="lnksemesterwise" runat="server">Semesterwise</a></li>
											<li><a href="#" id="lnkindividual" runat="server">Individual</a></li>
                                         </ul>
                                      </div>
                                </div>
                            <div class="nav-collapse collapse">
                                <div id="dvBranch" runat="server">
                                    <asp:Label runat="server" CssClass="control-label" AssociatedControlID="ddlClass">Class</asp:Label>

                                    <div class="controls">

                                        <asp:DropDownList ID="ddlClass" runat="server" class="chzn-select" DataTextField="colBranchName" DataValueField="colBranchId" AutoPostBack="True" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                <div id="dvSemester" runat="server">
                                    <asp:Label runat="server" CssClass="control-label" AssociatedControlID="ddlSemester">Semester</asp:Label>
                                    <div class="controls">
                                        <asp:DropDownList ID="ddlSemester" runat="server" CssClass="chzn-select" AutoPostBack="True" OnSelectedIndexChanged="ddlSemester_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                <div id="dvIndividualStudent" runat="server">
                                    <asp:Label runat="server" CssClass="control-label" AssociatedControlID="txtStudentName">Student Name</asp:Label>
                                    <div class="controls">

                                        <asp:TextBox ID="txtStudentName" runat="server" CssClass="input-xlarge focused"></asp:TextBox>
                                        <asp:HiddenField ID="hfStudentID" runat="server" />

                                    </div>
                                </div>
                            </div>
                            <asp:HiddenField ID="hf"
                            <label class="control-label"></label>
                            <div class="table-toolbar">
                                 <div class="btn-group">
                                         <button data-toggle="dropdown" class="btn dropdown-toggle">SMS Option<span class="caret"></span></button>
                                         <ul class="dropdown-menu">
                                            <li><a href="#" id="lnkinternalmarks" runat="server">Internal Marks</a></li>
											<li><a href="#" id="lnkattendance" runat="server">Attendance</a></li>
											<li><a href="#"  id="lnkpersonalisedmessage" runat="server">Personalised Message</a></li>
                                         </ul>
                                      </div>
                                </div>
                            <div id="dvMonthYear" runat="server">

                                <table>
                                    <tr style="width: 100%;">
                                        <td>
                                            <asp:Label runat="server" CssClass="control-label" AssociatedControlID="ddlMonth">Month</asp:Label>
                                            <div class="controls">
                                                <asp:DropDownList ID="ddlMonth" runat="server" CssClass="chzn-select">
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
                                    </tr>
                                    <tr style="width: 100%;">
                                        <td>
                                            <asp:Label runat="server" CssClass="control-label" AssociatedControlID="ddlYear">Year</asp:Label>
                                            <div class="controls">

                                                <asp:DropDownList ID="ddlYear" runat="server" CssClass="chzn-select">
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
                                    </tr>
                                </table>
                            </div>

                            <asp:Label runat="server" CssClass="control-label" AssociatedControlID="txtSendTo">Send To <span class="required">*</span></asp:Label>
                            <div class="controls">
                           <asp:TextBox ID="txtSendTo" runat="server" CssClass="input-xlarge focused" ValidationGroup="SMS" TextMode="MultiLine" Rows="6" Columns="5"></asp:TextBox>
                                 <asp:RequiredFieldValidator ID="SendToRequired" runat="server" 
                        ControlToValidate="txtSendTo" ErrorMessage="Send To is required." 
                        ToolTip="Send To is required." ValidationGroup="SMS" 
                         ForeColor="#FF3300">*</asp:RequiredFieldValidator>
                            </div>

                            <asp:Label runat="server" CssClass="control-label" AssociatedControlID="txtMessage">Message <span class="required">*</span></asp:Label>
                            <div class="controls">

                                <asp:TextBox ID="txtMessage" runat="server" CssClass="input-xlarge focused" ValidationGroup="SMS" TextMode="MultiLine" Rows="6" Columns="5"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="MessageRequired" runat="server" 
                        ControlToValidate="txtMessage" ErrorMessage="Message is required." 
                        ToolTip="Message is required." ValidationGroup="SMS" 
                         ForeColor="#FF3300">*</asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-actions">
                            <div id="divStatus" runat="server"></div>
                            <asp:Button ID="btnSend" runat="server" CssClass="btn btn-info" Text="Send"
                                OnClick="btnSend_Click" ValidationGroup="SMS" />
                             <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
            ShowMessageBox="false" ValidationGroup="SMS" ForeColor="Red"
                ShowSummary="true" meta:resourcekey="ValidationSummary1Resource1" HeaderText="Please fix the following errors :" />

                        </div>

                    </fieldset>
                </form>

            </div>
        </div>
    </div>


</asp:Content>
