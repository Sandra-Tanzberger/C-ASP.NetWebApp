<%@ Page Language="C#" ValidateRequest="false" AutoEventWireup="true" CodeBehind="StateFacilityPage.aspx.cs" Inherits="DHH.StateFacilityPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link href="../../style/PopupMaster.css" rel="stylesheet" type="text/css" />
    <link href="../../style/AtgWebUI.css" rel="stylesheet" type="text/css" />
 </head>
 <body onkeypress="CheckKey();">
    <form id="form1" runat="server">
        <telerik:RadScriptManager ID="LicAppRSM" runat="server">
            <Scripts>
                <asp:ScriptReference Path="~/Include/Common.js" />
                <asp:ScriptReference Path="~/Include/AtgWebUI.js" />
                <asp:ScriptReference Path="~/Include/PrintScreenScript.js" />
            </Scripts>
        </telerik:RadScriptManager>
        <telerik:RadAjaxManager ID="FacilityPageRAM" runat="server">
        </telerik:RadAjaxManager>
        <telerik:RadFormDecorator ID="AffilEditFormdecorator" runat="server" DecoratedControls="Buttons,CheckBoxes,Label" EnableRoundedCorners="false" />
        <telerik:RadCodeBlock ID="AffilEditRCB" runat="server">
            <script type="text/javascript">
                function pageLoad() {
                    if (null != document.getElementById("<%= FacServicesReadOnly.ClientID %>") && document.getElementById("<%= FacServicesReadOnly.ClientID %>").value != "") {
                        if (typeof ToggleGroupROstateHCBS == 'function') {
                            ToggleGroupROstateHCBS(document.getElementById("<%= FacServicesReadOnly.ClientID %>").value, 'ALL', 'Y');
                        }
                    }
                }

//                function CloseAndRebind() {
//                    //var tmpArgs = document.getElementById("hideEventArgsForParent").value;
//                    GetRadWindow().BrowserWindow.refreshApplications(); // Call the function in parent page  
//                    GetRadWindow().close(); // Close the window  
//                }

                function CloseRadWin() {
                    GetRadWindow().close();
                }

                function GetRadWindow() {
                    var oWindow = null;
                    if (window.radWindow) oWindow = window.radWindow; //Will work in Moz in all cases, including clasic dialog  
                    else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow; //IE (and Moz as well)  

                    return oWindow;
                }
                function CheckKey() {
                    if (event.keyCode == 13) {
                        window.event.returnValue = false;
                        window.event.cancel = true;
                    }
                }
            </script>
        </telerik:RadCodeBlock>
        <asp:HiddenField ID="FacServicesReadOnly" runat="server" Value="" />            
        <div id="DivFormNavigation" runat="server" style="position:fixed;clear: both;background-color:White;width:100%;padding:3px;border-bottom: solid 1px black;">
            <%--<div style="float:right;margin-right: 30px;">--%>
                <asp:Button ID="btnCancel" runat="server" Text="Exit" CommandName="Exit" OnClick="btnExit_Click" />
            <%--</div>--%>
        </div>
        <br />
        <br />
        <div >
            <asp:panel ScrollBars="None" CssClass="FacilityPanel" id="FacilityContent" runat="server"></asp:panel>
        </div>
<%--        <iframe ID="KeepAliveFrame" src="../StateSessionMonitor.aspx" frameborder="0" width="0" height="0" runat="server"></iframe>--%>
    </form>
</body>
</html>
