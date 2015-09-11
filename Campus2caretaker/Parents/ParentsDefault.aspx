<%@ Page Title="Parents Home Page" Language="C#" AutoEventWireup="true" CodeBehind="ParentsDefault.aspx.cs" Inherits="Campus2caretaker.Parents.ParentsDefault" %>

<!DOCTYPE html>
<html class="no-js">

<head>
    <title>Parents Home Page</title>
    <!-- Bootstrap -->
    <link href="../css/bootstrap/css/bootstrap.min.css" rel="stylesheet" media="screen">
    <link href="../css/bootstrap/css/bootstrap-responsive.min.css" rel="stylesheet" media="screen">
    <link href="../easypiechart/jquery.easy-pie-chart.css" rel="stylesheet" media="screen">
    <link href="../css/styles.css" rel="stylesheet" media="screen">
    <!-- HTML5 shim, for IE6-8 support of HTML5 elements -->
    <!--[if lt IE 9]>
            <script src="http://html5shim.googlecode.com/svn/trunk/html5.js"></script>
        <![endif]-->
    <script src="../js/modernizr-2.6.2-respond-1.1.0.min.js"></script>
</head>

<body>
    <form id="form1" runat="server">
        <div class="navbar navbar-fixed-top">
            <div class="navbar-inner">
                <div class="container-fluid">
                    <a class="btn btn-navbar" data-toggle="collapse" data-target=".nav-collapse"><span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </a>
                    <a class="brand" href="#">
                        <img src="../images/newlogosmall.png" /></a>
                    <a class="brand" href="#" style="margin-left: 450px;">
                        <label style="font-style: oblique; font-weight: bold; vertical-align: middle; font-size: x-large;">Welcome to Campus2Caretaker</label></a>
                    <div class="nav-collapse collapse">
                        <ul class="nav pull-right">
                            <a class="brand" href="#">
                                <label style="font-style: oblique; vertical-align: middle;">Help Line Numbers</label></a>
                        </ul>

                    </div>
                    <!--/.nav-collapse -->
                </div>
            </div>
        </div>
        <div class="container-fluid">
            <div class="row-fluid">
                <div class="span3" id="sidebar">
                    <ul class="nav nav-list bs-docs-sidenav nav-collapse collapse">
                        <li class="active">
                            <a href="ParentsDefault.aspx"><i class="icon-chevron-right"></i>Dashboard</a>
                        </li>
                        <li>
                            <a href="ParentsLogin.aspx"><i class="icon-chevron-right"></i>Logout</a>
                        </li>
                    </ul>
                </div>

                <!--/span-->
                <div class="span9" id="content">
                    <div class="row-fluid">
                        <!-- block -->
                        <div class="block">
                            <div class="navbar navbar-inner block-header">
                                <div class="muted pull-left">Details about:</div>
                                <div class="pull-right"><span class="badge badge-warning"></span></div>
                            </div>
                            <div class="block-content collapse in" id="dvStudentsList" runat="server">
                            </div>
                        </div>
                        <!-- /block -->
                    </div>

                    <div class="row-fluid">
                        <!-- block -->
                        <div class="block">
                            <div class="navbar navbar-inner block-header">
                                <div class="muted pull-left">Student Details:</div>
                                <div class="pull-right"><span class="badge badge-warning"></span></div>
                            </div>
                            <div class="block-content collapse in">
                                <div class="span12">
                                    <form class="form-horizontal">
                                        <fieldset>
                                            <legend>Student Profile</legend>
                                            <div class="control-group">
                                                <asp:Label runat="server" CssClass="control-label" AssociatedControlID="txtStudentName"> Student Name</asp:Label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txtStudentName" runat="server" CssClass="input-xlarge disabled" Enabled="false"></asp:TextBox>
                                                </div>
                                                <asp:Label runat="server" CssClass="control-label" AssociatedControlID="txtAddress"> Address</asp:Label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txtAddress" runat="server" CssClass="input-xlarge disabled" Enabled="false" TextMode="MultiLine" Rows="3" Columns="30"></asp:TextBox>
                                                </div>
                                                <asp:Label runat="server" CssClass="control-label" AssociatedControlID="txtSchoolName"> School/College Name</asp:Label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txtSchoolName" runat="server" CssClass="input-xlarge disabled" Enabled="false"></asp:TextBox>
                                                </div>
                                                <asp:Label runat="server" CssClass="control-label" AssociatedControlID="txtClass"> Class/Branch</asp:Label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txtClass" runat="server" CssClass="input-xlarge disabled" Enabled="false"></asp:TextBox>
                                                </div>
                                                <div id="dvSemester" runat="server">
                                                    <asp:Label runat="server" CssClass="control-label" AssociatedControlID="txtSemester"> Semester</asp:Label>
                                                    <div class="controls">
                                                        <asp:TextBox ID="txtSemester" runat="server" CssClass="input-xlarge disabled" Enabled="false"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <asp:Label runat="server" CssClass="control-label" AssociatedControlID="txtFatherName"> Father Name</asp:Label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txtFatherName" runat="server" CssClass="input-xlarge disabled" Enabled="false"></asp:TextBox>
                                                </div>
                                                <asp:Label runat="server" CssClass="control-label" AssociatedControlID="txtMotherName"> Mother Name</asp:Label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txtMotherName" runat="server" CssClass="input-xlarge disabled" Enabled="false"></asp:TextBox>
                                                </div>
                                                 <asp:Label runat="server" CssClass="control-label" AssociatedControlID="txtPrincipalName"> Principal Name</asp:Label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txtPrincipalName" runat="server" CssClass="input-xlarge disabled" Enabled="false"></asp:TextBox>
                                                </div>
                                                 <asp:Label runat="server" CssClass="control-label" AssociatedControlID="txtPrincipalContact"> Principal Contact</asp:Label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txtPrincipalContact" runat="server" CssClass="input-xlarge disabled" Enabled="false"></asp:TextBox>
                                                </div>
                                            </div>
                                        </fieldset>
                                    </form>

                                </div>
                            </div>
                            <!-- /block -->
                        </div>

                        <div class="row-fluid">
                            <div class="span6">
                                <!-- block -->
                                <div class="block">
                                    <div class="navbar navbar-inner block-header">
                                        <div class="muted pull-left">Test/Internals Details</div>
                                        <div class="pull-right">
                                            <span class="badge badge-info"></span>

                                        </div>
                                    </div>
                                    <div class="block-content collapse in">
                                      <asp:GridView CssClass="table table-striped" ID="gvInternalsMonth" runat="server" AutoGenerateColumns="False" AllowPaging="true"
                                            ShowHeaderWhenEmpty="True" EmptyDataText="No records Found" GridLines="None"
                                            AllowSorting="false" Width="100%" EnableModelValidation="True" OnPageIndexChanging="gvInternalsMonth_PageIndexChanging">
                                            <Columns>
                                                <asp:BoundField DataField="Row"
                                                    HeaderText="#"
                                                    ReadOnly="True"></asp:BoundField>
                                                <asp:BoundField DataField="colSubjectName"
                                                    HeaderText="Subject Name"
                                                    ReadOnly="True"></asp:BoundField>
                                                <asp:BoundField DataField="colMonth"
                                                    HeaderText="Month"></asp:BoundField>
                                                <asp:BoundField DataField="colYear"
                                                    HeaderText="Year"></asp:BoundField>
                                                 <asp:BoundField DataField="colMaxMarks"
                                                    HeaderText="Max Marks"></asp:BoundField>
                                                <asp:BoundField DataField="colMarksScored"
                                                    HeaderText="Marks Scored"></asp:BoundField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                                <!-- /block -->
                            </div>
                            <div class="span6">
                                <!-- block -->
                                <div class="block">
                                    <div class="navbar navbar-inner block-header">
                                        <div class="muted pull-left">Orders</div>
                                        <div class="pull-right">
                                            <span class="badge badge-info">752</span>

                                        </div>
                                    </div>
                                    <div class="block-content collapse in">
                                        <table class="table table-striped">
                                            <thead>
                                                <tr>
                                                    <th>#</th>
                                                    <th>Product</th>
                                                    <th>Date</th>
                                                    <th>Amount</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <tr>
                                                    <td>1</td>
                                                    <td>Coat</td>
                                                    <td>02/02/2013</td>
                                                    <td>$25.12</td>
                                                </tr>
                                                <tr>
                                                    <td>2</td>
                                                    <td>Jacket</td>
                                                    <td>01/02/2013</td>
                                                    <td>$335.00</td>
                                                </tr>
                                                <tr>
                                                    <td>3</td>
                                                    <td>Shoes</td>
                                                    <td>01/02/2013</td>
                                                    <td>$29.99</td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                                <!-- /block -->
                            </div>
                        </div>
                    </div>
                </div>
            </div>
                                <footer>
                        <p align="center">&copy; Campus2Caretaker 2015</p>
                    </footer>
            <!--/.fluid-container-->
            </div>
            <script src="../js/jquery-1.9.1.min.js"></script>
            <script src="../bootstrap/js/bootstrap.min.js"></script>
            <script src="../easypiechart/jquery.easy-pie-chart.js"></script>
            <script src="../js/scripts.js"></script>
            <script>
                $(function () {
                    // Easy pie charts
                    $('.chart').easyPieChart({ animate: 1000 });
                });
            </script>
    </form>
</body>

</html>
