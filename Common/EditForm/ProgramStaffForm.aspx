<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProgramStaffForm.aspx.cs" Inherits="Common.EditForm.ProgramStaffForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link href="../../style/PopupMaster.css" rel="stylesheet" type="text/css" />
    <link href="../../style/AtgWebUI.css" rel="stylesheet" type="text/css" />
     <script type="text/javascript">
         function noErrorMessages() { return true; }
         window.onerror = noErrorMessages;
     </script>
</head>
<body>
    <form id="form1" runat="server">
        <telerik:RadScriptManager ID="ProgramStaffFormRSM" runat="server">
            <Scripts>
                <asp:ScriptReference Path="~/Include/Common.js" />
                <asp:ScriptReference Path="~/Include/AtgWebUI.js" />
            </Scripts>
        </telerik:RadScriptManager>
    <div>
        <asp:Panel ID="ProgramStaff" runat="server" Width="100%"></asp:Panel>
    </div>
    </form>
</body>
</html>
