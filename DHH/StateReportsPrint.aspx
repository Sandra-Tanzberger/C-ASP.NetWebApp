<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StateReportsPrint.aspx.cs" Inherits="DHH.StateReportsPrint" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
    <head runat="server">
        <title></title>
    </head>
    <body>
        <form id="form1" runat="server">
            <div>
                <asp:Label ID="labelMessage" runat="server"></asp:Label>
               <rsweb:ReportViewer ID="RptViewer1" runat="server" Width="1024px" Height="768px" 
                    ProcessingMode="Remote" PromptAreaCollapsed="True" 
                    ShowPromptAreaButton="False">
               </rsweb:ReportViewer>
            </div>
        </form>
    </body>
</html>
