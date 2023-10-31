<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TestFormAuth.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-T3c6CoIi6uLrA9TneNEoa7RxnatzjcDSCmG1MXxSR1GAsXEV/Dwwykc2MPK8M2HN" crossorigin="anonymous">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-C6RzsynM9kWDrMNeT87bh95OGNyZPhcTNXj1NW7RuBCsyN/o0jlpcV8Qyq46cDfL" crossorigin="anonymous"></script>
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
