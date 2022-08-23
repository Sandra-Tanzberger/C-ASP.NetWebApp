<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MatchLOIPage.aspx.cs" Inherits="DHH.MatchLOIPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link href="../../style/PopupMaster.css" rel="stylesheet" type="text/css" />
    <link href="../../style/AtgWebUI.css" rel="stylesheet" type="text/css" />
 </head>
 <body>
    <form id="form1" runat="server">
        <telerik:RadScriptManager ID="LicAppRSM" runat="server">
            <Scripts>
                <asp:ScriptReference Path="~/Include/Common.js" />
                <asp:ScriptReference Path="~/Include/AtgWebUI.js" />
            </Scripts>
        </telerik:RadScriptManager>
        <telerik:RadFormDecorator ID="AffilEditFormdecorator" runat="server" DecoratedControls="Buttons,CheckBoxes,Label" EnableRoundedCorners="false" />
        <telerik:RadCodeBlock ID="AffilEditRCB" runat="server">
            <script type="text/javascript">
                function CloseRadWin() {
                    var oWindow = null;
                    if (window.radWindow)
                        oWindow = window.radWindow;
                    else if (window.frameElement.radWindow)
                        oWindow = window.frameElement.radWindow;
                    oWindow.close();
                } 
            </script>
        </telerik:RadCodeBlock>
                    
        <div id="DivFormNavigation" runat="server" style="position:fixed;clear: both;background-color:White;width:98%;padding:3px;border-bottom: solid 1px black;">
                <asp:Button ID="btnCancel" runat="server" Text="Exit" CommandName="Exit" OnClick="btnSaveExit_Click" />
        </div>
        <br />
        <br />
        <div>
        <asp:panel ScrollBars="None" id="MatchContent" runat="server"></asp:panel>
        </div>
    </form>
</body>
</html>