<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewEditLOIPage.aspx.cs" Inherits="DHH.ViewEditLOIPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link href="../../style/PopupMaster.css" rel="stylesheet" type="text/css" />
    <link href="../../style/AtgWebUI.css" rel="stylesheet" type="text/css" />
 </head>
<body onkeypress="CheckKey();">
    <form id="form1" runat="server">
        <telerik:RadScriptManager ID="LOI_RSM" runat="server">
            <Scripts>
                <asp:ScriptReference Path="~/Include/Common.js" />
                <asp:ScriptReference Path="~/Include/AtgWebUI.js" />
            </Scripts>
        </telerik:RadScriptManager>
        <telerik:RadFormDecorator ID="LOI_Formdecorator" runat="server" 
                                  DecoratedControls="Buttons,CheckBoxes,Label" 
                                  EnableRoundedCorners="false" />
        <telerik:RadCodeBlock ID="LOI_RCB" runat="server">
            <script type="text/javascript">
                function CloseRadWin() {
                    var oWindow = null;
                    if (window.radWindow)
                        oWindow = window.radWindow;
                    else if (window.frameElement.radWindow)
                        oWindow = window.frameElement.radWindow;
                    oWindow.close();
                }
                function CheckKey() {
                    if (event.keyCode == 13) {
                        window.event.returnValue = false;
                        window.event.cancel = true;
                    }
                }
            </script>
        </telerik:RadCodeBlock>            
        <div id="DivFormNavigation" runat="server" style="position:fixed;clear: both;background-color:White;width:100%;padding:3px;border-bottom: solid 1px black;">
            <asp:Button ID="btnSave" runat="server" Text="Save" CommandName="Save" OnClick="btnSave_Click"  />
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" CommandName="Submit" OnClick="btnSave_Click" Visible="false" />
            <asp:Button ID="btnSaveExit" runat="server" Text="Close" CommandName="Close" OnClick="btnSave_Click" />
        </div>
        <br />
        <br />
        <div>
            <asp:panel ScrollBars="None" CssClass="FacilityPanel" id="LOI_Content" runat="server"></asp:panel>
        </div>
    </form>
</body>
</html>
