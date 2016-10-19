<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Students_Course.aspx.cs" Inherits="WebBased.Students_Course" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<%--<head runat="server">--%>
    <head>
 
    <title></title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/Site.css" rel="stylesheet" />

    <script>

        //Snippet found online to print or save the page as a pdf
        function printpage() {
            var getpanel = document.getElementById("<%=Panel5.ClientID%>");
            var MainWindow = window.open('', '', 'height=800,width=800');
            MainWindow.document.write('<html><head><title>Print Page</title>');
            MainWindow.document.write('</head><body>');
            MainWindow.document.write(getpanel.innerHTML);
            MainWindow.document.write('</body></html>');
            MainWindow.document.close();
            setTimeout(function () {
                MainWindow.print();
            }, 500);
            return false;
        }
    </script>
</head>
<body style="padding-top:0px;">


    <asp:Panel ID="Panel5" runat="server">

    <form id="form1" runat="server">

    <%-- Testing form code, not working. --%>
    <%--<form id="form2" runat="server" action="http://www.google.com" method="post">--%>


    <%-- Header Section Starts here --%>
    <div> 

        <%-- Added a gridview that is hidden on the page to access paper information from database --%>
        <asp:Label ID="lblUserNameFromLoginForm" runat="server" Text="">
            <asp:Label ID="lblLoggedIn" runat="server" Text="Label" Visible="False"></asp:Label></asp:Label>
        <asp:GridView ID="gdvDatabase" runat="server" AutoGenerateColumns="False" DataKeyNames="paper_id" DataSourceID="SqlDataSource1" Visible="False" Width="605px">
            <Columns>
                <asp:BoundField DataField="paper_id" HeaderText="paper_id" InsertVisible="False" ReadOnly="True" SortExpression="paper_id" />
                <asp:BoundField DataField="lecturer_id" HeaderText="lecturer_id" SortExpression="lecturer_id" />
                <asp:BoundField DataField="code" HeaderText="code" SortExpression="code" />
                <asp:BoundField DataField="paper_name" HeaderText="paper_name" SortExpression="paper_name" />
                <asp:BoundField DataField="category" HeaderText="category" SortExpression="category" />
                <asp:BoundField DataField="level" HeaderText="level" SortExpression="level" />
                <asp:BoundField DataField="credits" HeaderText="credits" SortExpression="credits" />
                <asp:BoundField DataField="semester" HeaderText="semester" SortExpression="semester" />
                <asp:BoundField DataField="compulsory" HeaderText="compulsory" SortExpression="compulsory" />
            </Columns>
        </asp:GridView>

        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString7 %>" ProviderName="<%$ ConnectionStrings:ConnectionString7.ProviderName %>" SelectCommand="SELECT * FROM [papers]"></asp:SqlDataSource>


         
            <div class="container"">
                    <nav>

        <div class="inside_nav">
            
            <asp:Image ID="logo" runat="server" Width="134px" Height="70px" ImageUrl="~/Images/UCOL_LOGO_123.PNG" />
            <asp:Label ID="Label1" runat="server" Font-Size="Larger" style="margin-left:20px;" ForeColor="White" Text="Student Course Details"></asp:Label>
            
        </div>

    </nav>
                <div><h3><span class="label label-primary stud_label">Student</span><asp:Label ID="lblName" runat="server" Text="Student Name"></asp:Label><span class="logout"><asp:Button ID="btnLogout" runat="server" Text="Logout" BackColor="#6699FF" ForeColor="White" OnClick="btnLogout_Click" /></span><span class="logout"><asp:Button ID="Button1" runat="server" Text="Save/Print" BackColor="#6699FF" ForeColor="White" OnClientClick="printpage()" /></span></h3></div>
         


                <%-- Literal1 will be used to gather all information from the backend code and it will hold all the papers and headings --%>
                <asp:Panel ID="Panel1" runat="server">
                    <div class="stud_body" ><asp:Literal ID="ltlHtml" runat="server"></asp:Literal></div>
                </asp:Panel>
            </div>


    </div>

        <%-- lblTester is used to test database/gridview connection and testing output data --%>
        <asp:Label ID="lblTester" runat="server" Font-Size="XX-Large" Font-Bold="True" Visible="False"></asp:Label>
    <script src="Scripts/jquery-1.10.2.js"></script>
    <script src="Scripts/bootstrap.js"></script>
     <script src="Scripts/main.js"></script>   
        <asp:Panel ID="Panel2" runat="server">
        </asp:Panel>
        
    </form>

    </asp:Panel>
    </body>
</html>
