<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TestFormAuth.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            
            <asp:Label ID="lbUserName" runat="server">UserName：</asp:Label>
            <asp:TextBox ID="tbUserName" runat="server"></asp:TextBox>

            <asp:Label ID="lbPassword" runat="server">Password：</asp:Label>
            <asp:TextBox ID="tbPassword" runat="server"></asp:TextBox>

            <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
        </div>
    </form>
</body>
</html>
