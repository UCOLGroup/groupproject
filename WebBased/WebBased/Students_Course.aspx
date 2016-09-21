<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Students_Course.aspx.cs" Inherits="WebBased.Students_Course" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/Site.css" rel="stylesheet" />
</head>
<body>
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

        <asp:Panel ID="Panel1" runat="server">
         
            <asp:Literal ID="Literal1" runat="server"></asp:Literal>


           
        </asp:Panel>

    </div>
    </form>
    <script src="Scripts/jquery-1.10.2.js"></script>
    <script src="Scripts/bootstrap.js"></script>
</body>
</html>
