<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Lecturer.aspx.cs" Inherits="WebBased.Lecturer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style type="text/css">
        #btnLogout{
            //float:right;
        }
    </style>
    <nav class="navbar navbar-default" style="background-color: #193980;" >

        <div style="padding:20px;"><asp:Image ID="logo" runat="server" Width="134px" Height="70px" ImageUrl="~/Images/ucol-logo.png" />
            
        </div>

    </nav>


    <div class="container">
        
        <div>
        <div style="float:left;">
            <br /> <br />
            &nbsp;<asp:Label ID="lblWelcome" runat="server" Text="Welcome" Font-Size="Large"></asp:Label>
            
            &nbsp;
            <asp:TextBox ID="TextBox1" runat="server" Width="28px" Visible="False">1</asp:TextBox>
            <br />
            <br />
        </div>

        <div style="float:right; position:relative; top: 40px;"><asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" /></div>
        </div>

        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="paper_id" DataSourceID="SqlDataSource1" Height="185px" CssClass="footable" AllowSorting="True" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal">
                <Columns>
                    <asp:CommandField ShowEditButton="True" />
                    <asp:BoundField DataField="paper_id" HeaderText="paper_id" InsertVisible="False" ReadOnly="True" SortExpression="paper_id" Visible="False" />
                    <asp:BoundField DataField="lecturer_id" HeaderText="lecturer_id" SortExpression="lecturer_id" Visible="False" />
                    <asp:BoundField DataField="code" HeaderText="Code" SortExpression="code" />
                    <asp:BoundField DataField="paper_name" HeaderText="Paper Name" SortExpression="paper_name" />
                    <asp:BoundField DataField="category" HeaderText="Category" SortExpression="category" />
                    <asp:BoundField DataField="level" HeaderText="Level" SortExpression="level" />
                    <asp:BoundField DataField="credits" HeaderText="Credits" SortExpression="credits" />
                </Columns>
                <FooterStyle BackColor="White" ForeColor="#333333" />
                <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="White" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                <SortedAscendingHeaderStyle BackColor="#487575" />
                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                <SortedDescendingHeaderStyle BackColor="#275353" />
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString3 %>" DeleteCommand="DELETE FROM [papers] WHERE [paper_id] = ?" InsertCommand="INSERT INTO [papers] ([paper_id], [lecturer_id], [code], [paper_name], [category], [level], [credits]) VALUES (?, ?, ?, ?, ?, ?, ?)" ProviderName="<%$ ConnectionStrings:ConnectionString3.ProviderName %>" SelectCommand="SELECT * FROM [papers] WHERE ([lecturer_id] = ?)" UpdateCommand="UPDATE [papers] SET [lecturer_id] = ?, [code] = ?, [paper_name] = ?, [category] = ?, [level] = ?, [credits] = ? WHERE [paper_id] = ?">
                <DeleteParameters>
                    <asp:Parameter Name="paper_id" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="paper_id" Type="Int32" />
                    <asp:Parameter Name="lecturer_id" Type="Int32" />
                    <asp:Parameter Name="code" Type="String" />
                    <asp:Parameter Name="paper_name" Type="String" />
                    <asp:Parameter Name="category" Type="String" />
                    <asp:Parameter Name="level" Type="Int32" />
                    <asp:Parameter Name="credits" Type="Int32" />
                </InsertParameters>
                <SelectParameters>
                    <asp:ControlParameter ControlID="TextBox1" Name="lecturer_id" PropertyName="Text" Type="Int32" />
                </SelectParameters>
                <UpdateParameters>
                    <asp:Parameter Name="lecturer_id" Type="Int32" />
                    <asp:Parameter Name="code" Type="String" />
                    <asp:Parameter Name="paper_name" Type="String" />
                    <asp:Parameter Name="category" Type="String" />
                    <asp:Parameter Name="level" Type="Int32" />
                    <asp:Parameter Name="credits" Type="Int32" />
                    <asp:Parameter Name="paper_id" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
            <br />
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" CssClass="footable" DataKeyNames="paper_id" DataSourceID="SqlDataSource2">
                <Columns>
                    <asp:CommandField ShowEditButton="True" />
                    <asp:BoundField DataField="paper_id" HeaderText="Paper Id" InsertVisible="False" ReadOnly="True" SortExpression="paper_id" Visible="False" />
                    <asp:BoundField DataField="code" HeaderText="Code" SortExpression="code" />
                    <asp:BoundField DataField="paper_name" HeaderText="Paper Name" SortExpression="paper_name" />
                    <asp:BoundField DataField="category" HeaderText="Category" SortExpression="category" />
                    <asp:BoundField DataField="level" HeaderText="Level" SortExpression="level" />
                    <asp:BoundField DataField="credits" HeaderText="Credits" SortExpression="credits" />
                </Columns>
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <RowStyle ForeColor="#000066" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#00547E" />
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString4 %>" DeleteCommand="DELETE FROM [papers] WHERE [paper_id] = ?" InsertCommand="INSERT INTO [papers] ([paper_id], [code], [paper_name], [category], [level], [credits]) VALUES (?, ?, ?, ?, ?, ?)" ProviderName="<%$ ConnectionStrings:ConnectionString4.ProviderName %>" SelectCommand="SELECT [paper_id], [code], [paper_name], [category], [level], [credits] FROM [papers]" UpdateCommand="UPDATE [papers] SET [code] = ?, [paper_name] = ?, [category] = ?, [level] = ?, [credits] = ? WHERE [paper_id] = ?">
                <DeleteParameters>
                    <asp:Parameter Name="paper_id" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="paper_id" Type="Int32" />
                    <asp:Parameter Name="code" Type="String" />
                    <asp:Parameter Name="paper_name" Type="String" />
                    <asp:Parameter Name="category" Type="String" />
                    <asp:Parameter Name="level" Type="Int32" />
                    <asp:Parameter Name="credits" Type="Int32" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="code" Type="String" />
                    <asp:Parameter Name="paper_name" Type="String" />
                    <asp:Parameter Name="category" Type="String" />
                    <asp:Parameter Name="level" Type="Int32" />
                    <asp:Parameter Name="credits" Type="Int32" />
                    <asp:Parameter Name="paper_id" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
        </div>
    </div>

</asp:Content>
