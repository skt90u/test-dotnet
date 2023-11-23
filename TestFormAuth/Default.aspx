<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TestFormAuth.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://unpkg.com/bootstrap@4.5.0/dist/css/bootstrap.min.css" crossorigin="anonymous"/>
    <script src="https://unpkg.com/bootstrap@4.5.0/dist/js/bootstrap.min.js" crossorigin="anonymous"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="table table-bordered">
                <tr>
                    <th>認證方式</th>
                    <th>User.GetType().Name</th>
                    <td><%= User.GetType().Name %></td>
                </tr>

                <tr>
                    <th>客戶端電腦名稱</th>
                    <th>Request.LogonUserIdentity.Name</th>
                    <td><%= Request.LogonUserIdentity.Name %></td>
                </tr>

                 <tr>
                    <th>登入帳號</th>
                    <th>User.Identity.Name</th>
                    <td><%= User.Identity.Name %></td>
                </tr>

                 <tr>
                    <th>是否已認證</th>
                    <th>User.Identity.IsAuthenticated</th>
                    <td><%= User.Identity.IsAuthenticated %></td>
                </tr>

                <tr>
                    <th>登入者資訊</th>
                    <th>UserData (JSON)</th>
                    <td><%= (User.Identity as FormsIdentity)?.Ticket?.UserData %></td>
                </tr>
            </table>
            

            <a href="Login.aspx">Login</a> | <a href="Logout.aspx">Logout</a>
        </div>
    </form>
</body>
</html>
