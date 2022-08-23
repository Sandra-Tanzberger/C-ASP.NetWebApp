<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SessionMonitor.aspx.cs" Inherits="State.SessionMonitor" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="IFrameForm" runat="server">
        <telerik:RadScriptManager ID="SessionRSM" runat="server">
            <Scripts>
                <asp:ScriptReference Path="~/Include/Common.js" />
                <asp:ScriptReference Path="~/Include/AtgWebUI.js" />
            </Scripts>
        </telerik:RadScriptManager>        
        <telerik:RadAjaxManager ID="SessionRAJM" runat="server" />
        <div>
            <Telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Height="35px" Width="200px">
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                <asp:Timer ID="SessionTimer" runat="server" OnTick="SessionTimer_Tick" />
            </Telerik:RadAjaxPanel>
        </div>
    </form>
</body>
</html>
