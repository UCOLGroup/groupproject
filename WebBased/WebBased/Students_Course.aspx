﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Students_Course.aspx.cs" Inherits="WebBased.Students_Course" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 
    <title></title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/Site.css" rel="stylesheet" />
</head>
<body style="padding-top:0px;">




    <form id="form1" runat="server">

    <div>
        <asp:Label ID="lblUserNameFromLoginForm" runat="server" Text=""></asp:Label>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="paper_id" DataSourceID="SqlDataSource1" Visible="False">
            <Columns>
                <asp:BoundField DataField="paper_id" HeaderText="paper_id" InsertVisible="False" ReadOnly="True" SortExpression="paper_id" />
                <asp:BoundField DataField="lecturer_id" HeaderText="lecturer_id" SortExpression="lecturer_id" />
                <asp:BoundField DataField="code" HeaderText="code" SortExpression="code" />
                <asp:BoundField DataField="paper_name" HeaderText="paper_name" SortExpression="paper_name" />
                <asp:BoundField DataField="category" HeaderText="category" SortExpression="category" />
                <asp:BoundField DataField="level" HeaderText="level" SortExpression="level" />
                <asp:BoundField DataField="credits" HeaderText="credits" SortExpression="credits" />
                <asp:BoundField DataField="semester" HeaderText="semester" SortExpression="semester" />
            </Columns>
        </asp:GridView>

        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString7 %>" ProviderName="<%$ ConnectionStrings:ConnectionString7.ProviderName %>" SelectCommand="SELECT * FROM [papers]"></asp:SqlDataSource>


         
            <div class="container"">
                    <nav>

        <div class="inside_nav">
            
            <asp:Image ID="logo" runat="server" Width="134px" Height="70px" ImageUrl="~/Images/ucol-logo.png" />
            <asp:Label ID="Label1" runat="server" Font-Size="Larger" style="margin-left:20px;" ForeColor="White" Text="Student Course Details"></asp:Label>
            
        </div>

    </nav>
                <div><h3><span class="label label-primary stud_label">Student</span><asp:Label ID="lblName" runat="server" Text="Student Name"></asp:Label><span class="logout"><asp:Button ID="btnLogout" runat="server" Text="Logout" BackColor="#6699FF" ForeColor="White" OnClick="btnLogout_Click" /></span></h3></div>
         


                <asp:Panel ID="Panel1" runat="server">
                    <div class="stud_body" ><asp:Literal ID="Literal1" runat="server"></asp:Literal></div>
                </asp:Panel>
            </div>


    </div>

        <asp:Label ID="lblTester" runat="server" Font-Size="XX-Large" Font-Bold="True"></asp:Label>
    <script src="Scripts/jquery-1.10.2.js"></script>
    <script src="Scripts/bootstrap.js"></script>
     <script src="Scripts/main.js"></script>   
        <asp:Panel ID="Panel2" runat="server">
        </asp:Panel>
        
    </form>
    </body>
</html>
