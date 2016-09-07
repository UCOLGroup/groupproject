<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Lecturer.aspx.cs" Inherits="WebBased.Lecturer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div>
            <br />
            Lecturer ID:
            <asp:TextBox ID="TextBox1" runat="server" Width="28px">1</asp:TextBox>
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
        </div>
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="paper_id" DataSourceID="SqlDataSource1" Height="185px" CssClass="footable" AllowSorting="True">
                <Columns>
                    <asp:CommandField ShowEditButton="True" />
                    <asp:BoundField DataField="paper_id" HeaderText="paper_id" InsertVisible="False" ReadOnly="True" SortExpression="paper_id" Visible="False" />
                    <asp:BoundField DataField="lecturer_id" HeaderText="lecturer_id" SortExpression="lecturer_id" Visible="False" />
                    <asp:BoundField DataField="code" HeaderText="code" SortExpression="code" />
                    <asp:BoundField DataField="paper_name" HeaderText="paper_name" SortExpression="paper_name" />
                    <asp:BoundField DataField="category" HeaderText="category" SortExpression="category" />
                    <asp:BoundField DataField="level" HeaderText="level" SortExpression="level" />
                    <asp:BoundField DataField="credits" HeaderText="credits" SortExpression="credits" />
                </Columns>
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
        </div>
    </div>

</asp:Content>
