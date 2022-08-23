<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AffiliationForm.aspx.cs" Inherits="Common.EditForm.AffiliationForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link href="../../style/PopupMaster.css" rel="stylesheet" type="text/css" />
    <link href="../../style/AtgWebUI.css" rel="stylesheet" type="text/css" />
 </head>
<body style="overflow:auto" onkeypress="CheckKey();">
    <form id="form1" runat="server">
    <telerik:RadScriptManager ID="AffilEditRSM" runat="server">
        <Scripts>
            <asp:ScriptReference Path="~/Include/Common.js" />
            <asp:ScriptReference Path="~/Include/AtgWebUI.js" />
        </Scripts>
    </telerik:RadScriptManager>
    <telerik:RadAjaxManager ID="AffilEditRAM" runat="server">
    </telerik:RadAjaxManager>
    <telerik:RadFormDecorator ID="AffilEditFormdecorator" runat="server" DecoratedControls="Buttons,CheckBoxes,Label" EnableRoundedCorners="false" />
    <telerik:RadCodeBlock ID="AffilEditRCB" runat="server">
        <script type="text/javascript">
            function pageLoad() {
                var tmpLicReadOnly = document.getElementById("<%= LicReadOnly.ClientID %>").value;
                var SvcCntrlKeys = ["PCA", "SIL", "SIL_SLC", "RESPITE_IN_HOME", "RESPITE_CENTER_BASED", "ADC"];
                var SvcGroupKeys = document.getElementById("<%= GroupStateIDs.ClientID %>").value.split(",");
                var tmpCtrl;
                var tmpPgmID = document.getElementById("<%= hidProgramID.ClientID %>").value;

                if (tmpLicReadOnly == "RO") {
                    //alert("LicRO");
                    if (typeof ToggleGroupROstateHCBS == 'function' && tmpPgmID == 'HC') {
                        ToggleGroupROstateHCBS('<%= AffiliationFormContent.ClientID %>', 'ALL', 'Y');
                    }
                    
                    ChangeCtrlRO(true, document, true);
                }
                else {
                    if (tmpPgmID == 'HC') {
                        for (x = 0; x < SvcCntrlKeys.length; x++) {
                            tmpGrpCtrl = document.getElementById(SvcGroupKeys[x]);
                            //alert(tmpGrpCtrl);
                            if (null != tmpGrpCtrl && tmpGrpCtrl.value == "RO") {
                                if (typeof ToggleGroupROstateHCBS == 'function') {
                                    //alert("Before do toggle");
                                    ToggleGroupROstateHCBS(SvcGroupKeys[x], SvcCntrlKeys[x], 'Y');
                                    //alert("After do toggle");
                                }
                            }
                        }
                    }
                }
            } 
            
            function CloseRadWin() {
                var oWindow = null;
                if (window.radWindow)
                    oWindow = window.radWindow;
                else if (window.frameElement.radWindow)
                    oWindow = window.frameElement.radWindow;
                oWindow.close();
            }
            
            function CloseAndRebind(inArgs) {
                //var tmpArgs = document.getElementById("hideEventArgsForParent").value;
                GetRadWindow().BrowserWindow.refreshParentAffilList(inArgs); // Call the function in parent page
                //GetRadWindow().BrowserWindow.refreshParentCapSum(inArgs); // Call the function in parent page  
                GetRadWindow().close(); // Close the window
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
    <asp:HiddenField ID="GroupStateIDs" runat="server" Value="" />
    <asp:HiddenField ID="LicReadOnly" runat="server" Value="" />
    <asp:HiddenField ID="hidProgramID" runat="server" Value="" />
    <div id="DivFormNavigation" runat="server" style="position:fixed;clear: both;background-color:White;width:100%;padding:3px;border-bottom: solid 1px black;">
        <asp:Button ID="btnSave" runat="server" Text="Save" CommandName="Save" OnClick="btnSave_Click"  />
        <asp:Button ID="btnSaveExit" runat="server" Text="Save and Exit" CommandName="SaveExit" OnClick="btnSave_Click" />
        <asp:Button ID="btnCancelnoDisable" runat="server" Text="Exit without saving" OnClientClick="CloseRadWin(); return false;" />
    </div>
    <br />
    <br />
    <div >
        <asp:panel ScrollBars="None" CssClass="LicensePanel" id="AffiliationFormContent" runat="server"></asp:panel>
    </div>
    </form>
</body>
</html>
