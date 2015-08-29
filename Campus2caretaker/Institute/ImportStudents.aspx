<%@ Page Title="Import Student Details" Language="C#" MasterPageFile="~/Institute/Institute.Master" AutoEventWireup="true" CodeBehind="ImportStudents.aspx.cs" Inherits="Campus2caretaker.Institute.ImportStudents" EnableEventValidation="false" EnableViewState="true" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="block">
        <div class="navbar navbar-inner block-header">
            <div class="muted pull-left">Import Student Details</div>
        </div>
        <div class="block-content collapse in">
            <div class="span12">
                <form class="form-horizontal">
                    <fieldset>
                        <legend>Import Student Details</legend>
                        <div class="control-group">
                            <asp:Label runat="server" CssClass="control-label" AssociatedControlID="FlUploadcsv">Import From File <span class="required">*</span></asp:Label>
                            <div class="controls">
                                <asp:FileUpload ID="FlUploadcsv" runat="server" CssClass="input-file uniform_on" />

                                <a href="../Template/StudentRegistrationSample.xlsx" id="LinkstudentRegistrationSample" target="_blank">Download sample file</a>


                            </div>
                        </div>
                        <div class="form-actions">
                            <div id="divStatus" runat="server"></div>
                            <asp:Button ID="btnUpload" runat="server" CssClass="btn btn-info" Text="Upload"
                                OnClick="btnUpload_Click" />
                        </div>

                    </fieldset>
                </form>

            </div>
        </div>
    </div>
    <!-- /block -->
</asp:Content>
