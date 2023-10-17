<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TestReportingService.Default" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        html,body,form,.container {
            height: 100%;
            overflow-y:hidden;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <asp:ScriptManager ID="ScriptManager1" runat="server" LoadScriptsBeforeUI="true" EnablePageMethods="True"></asp:ScriptManager>
            <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" Height="99%">
                <LocalReport ReportPath="Reports\Report1.rdlc"></LocalReport>
            </rsweb:ReportViewer>
                
        </div>
    </form>
</body>
</html>
