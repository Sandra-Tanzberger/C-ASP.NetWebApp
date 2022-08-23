<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AspenComments.aspx.cs" Inherits="Common.EditForm.AspenComments" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <telerik:RadScriptManager ID="AspenCommentsFormRSM" runat="server">
            <Scripts>
                <asp:ScriptReference Path="~/Include/Common.js" />
                <asp:ScriptReference Path="~/Include/AtgWebUI.js" />
            </Scripts>
        </telerik:RadScriptManager>
    <div>
        <asp:Panel ID="AspenCommentsPanel" runat="server" Width="100%"></asp:Panel>
    </div>
    </form>
</body>
</html>
