<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="User_Login_Page.aspx.cs" Inherits="WebBased.User_Login_Page" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

        <script src="Scripts/jquery-1.9.1.js"> </script>
    <script src="Scripts/jquery-migrate-1.2.1.min.js">  </script>
    <script type = "text/javascript" >
function disableBackButton()
{
window.history.forward();
}
setTimeout("disableBackButton()", 0);
</script>

    <title>Login</title>
    <style type="text/css">
        
        .auto-style2 {
            font-weight: bold;
            color: #FFFFFF;
            font-size: large;
            font-family:Arial, Helvetica, sans-serif;
        }

        .auto-style3 {
            position: relative;
            top: 15px;
        }
        .LecturerCheckBox {
            font-weight: bold;
            color: #FFFFFF;
            font-size: medium;
            font-family:Arial, Helvetica, sans-serif;
        }
        body{
            margin: 10px auto;
            width: 260px;
            background-color:#193980;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <p style="height: 100px; width: 200px">
            <img alt="Image of ucol logo" class="auto-style4" <img src="Images/ucol.png" /> </p>

    </div>
        <div>
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">UserName:</td>
                <td class="auto-style3">
                    <asp:TextBox ID="tbxUsername" runat="server" Height="24px" Width="155px" >12345</asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please type in a Username" ControlToValidate="tbxUsername" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Password:</td>
                <td class="auto-style3">
                    <asp:TextBox ID="tbxPassword" runat="server" TextMode="Password" Height="26px" Width="155px">123</asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please type in a Password" ControlToValidate="tbxPassword" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                </td>
            </tr>
        </table>
        <br />
            <asp:CheckBox Class="LecturerCheckBox" ID="chkLecturerLogin" Text="Lecturer Login" runat="server" OnCheckedChanged="CheckBox1_CheckedChanged" />
        <br />
        <br />
        <br />
        <asp:Button ID="btnRegister" runat="server" Height="39px" OnClick="btnRegister_Click"  Text="Login" Width="260px" />
            </div>
    </form>
</body>
</html>
