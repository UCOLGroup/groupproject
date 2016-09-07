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

    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 37%;
            margin-left: 633px;
        }
        .auto-style2 {
            width: 163px;
            text-align: center;
            font-weight: bold;
            color: #546BA8;
            font-size: large;
            font-family:Arial, Helvetica, sans-serif;
        }
        .auto-style3 {
            width: 275px;
        }
        .auto-style4 {
            width: 693px;
            height: 341px;
            margin-left: 560px;
        }
        .auto-style7 {
            width: 163px;
            height: 46px;
            text-align: center;
            font-weight: bold;
            color: #546BA8;
            font-size: large;
             font-family:Arial, Helvetica, sans-serif;
        }
        .auto-style8 {
            width: 275px;
            height: 46px;
        }
        .LecturerCheckBox{
            margin-left:625px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <p style="height: 315px; width: 803px">
            <img alt="Image of ucol logo" class="auto-style4" <img src="Images/ucol.png" /> </p>

    </div>
        <div>
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">User Name</td>
                <td class="auto-style3">
                    <asp:TextBox ID="tbxUsername" runat="server" Height="24px" Width="234px" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please type in a Username" ControlToValidate="tbxUsername" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style7">Password</td>
                <td class="auto-style8">
                    <asp:TextBox ID="tbxPassword" runat="server" Height="26px" Width="233px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please type in a Password" ControlToValidate="tbxPassword" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                </td>
            </tr>
        </table>
        <br />
            <asp:CheckBox Class="LecturerCheckBox" ID="chkLecturerLogin" Text="Lecturer Login" runat="server" OnCheckedChanged="CheckBox1_CheckedChanged" />
        <br />
        <br />
        <br />
        <asp:Button ID="btnRegister" runat="server" Height="39px" OnClick="btnRegister_Click" style="margin-left: 813px" Text="Login" Width="260px" />
            </div>
    </form>
</body>
</html>
