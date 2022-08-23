<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="report.aspx.cs" Inherits="Common.report" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
       <rsweb:ReportViewer ID="RptViewer1" runat="server" Width="100%"   
            ProcessingMode="Remote" PromptAreaCollapsed="True"
            ShowPromptAreaButton="False">
       </rsweb:ReportViewer>
    </div>
    </form>
</body>
</html>
