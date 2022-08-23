<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StateLicensePage.aspx.cs" Inherits="DHH.StateLicensePage" %>

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
            </Scripts>
        </telerik:RadScriptManager>
        <telerik:RadAjaxManager ID="LicAppAJM1" runat="server">
            <AjaxSettings>
                <telerik:AjaxSetting AjaxControlID="DocNavMenu" >
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="LicenseContent" LoadingPanelID="LoadPanelLicense" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="btnSave" >
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="LicenseContent" LoadingPanelID="LoadPanelLicense" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
            </AjaxSettings>
        </telerik:RadAjaxManager>
        <telerik:RadFormDecorator ID="AffilEditFormdecorator" runat="server" DecoratedControls="Buttons,CheckBoxes,Label" EnableRoundedCorners="false" />
        <telerik:RadAjaxLoadingPanel ID="LoadPanelLicense" runat="server" />
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
                            //alert("<%= LicenseContent.ClientID %>");
                            //alert(document.getElementById("<%= LicenseContent.ClientID %>"));
                            ToggleGroupROstateHCBS('<%= LicenseContent.ClientID %>', 'ALL', 'Y');
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

                        if (tmpPgmID == 'ES') {
                            if (typeof EnableDisableCheckBoxes == 'function')
                                EnableDisableCheckBoxes();
                            if (typeof InitES_TypeFacilityChk == 'function')
                                InitES_TypeFacilityChk();
                        }
                        
                        if (tmpPgmID == 'RH') {
                            if (typeof InitRH_TypeFacilityChk == 'function')
                                InitRH_TypeFacilityChk();
                        }

                        if (tmpPgmID == 'NH') {
                            if (typeof onMultiFacAdminClick == 'function')
                                onMultiFacAdminClick();
                        }
                    }

//                    for (var idx = 0; idx < Telerik.Web.UI.RadComboBox.ComboBoxes.length; idx++) {
//                        alert(Telerik.Web.UI.RadComboBox.ComboBoxes[idx].ID);
//                    }
                }

                function CloseAndRebind() {
                    //var tmpArgs = document.getElementById("hideEventArgsForParent").value;
                    GetRadWindow().BrowserWindow.refreshApplications(); // Call the function in parent page  
                    GetRadWindow().close(); // Close the window  
                }

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
    <asp:HiddenField ID="GroupStateIDs" runat="server" Value="" />
    <asp:HiddenField ID="LicReadOnly" runat="server" Value="" />
    <asp:HiddenField ID="hidProgramID" runat="server" Value="" />
    <div id="DivFormNavigation" runat="server" style="position:fixed;clear: both;background-color:White;width:100%;padding:3px;border-bottom: solid 1px black;z-index: 9999;">
        <asp:Button ID="btnSave" runat="server" Text="Save" CommandName="Save" OnClick="btnSave_Click" Enabled="false"  />
        <asp:Button ID="btnSaveExit" runat="server" Text="Save and Exit" CommandName="SaveExit" OnClick="btnSave_Click" Enabled="false" />
            <asp:Button ID="btnCancelnoDisable" runat="server" Text="Exit without saving" CommandName="Exit" OnClientClick="CloseRadWin(); return false;" />
            Application Sections: 
            <asp:LinkButton ID="licenseCollapseAll" runat="server" OnClientClick="toggleCollapseAll()" Text="Collapse All" />
            &nbsp;&nbsp;
            <asp:LinkButton ID="licenseExpandAll" runat="server" OnClientClick="toggleExpandAll()" Text="Expand All" />
    </div>
    <br />
    <br />
    <div >
        <asp:panel ScrollBars="None" CssClass="LicensePanel" id="LicenseContent" runat="server"></asp:panel>
    </div>
<%--    <iframe ID="KeepAliveFrame" src="../StateSessionMonitor.aspx" frameborder="0" width="0" height="0" runat="server"></iframe>--%>
    </form>
</body>
</html>
