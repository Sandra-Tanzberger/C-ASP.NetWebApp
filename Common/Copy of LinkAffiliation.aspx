<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LinkAffiliation.aspx.cs" Inherits="Common.LinkAffiliation" %>

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
            
            function SetUniqueRadioButton(nameregex, current) {
                re = new RegExp(nameregex);       
                for(i = 0; i < document.forms[0].elements.length; i++){
                    elm = document.forms[0].elements[i]
                    if (elm.type == 'radio') {
                        if (re.test(elm.name)) {
                            elm.checked = false;
                        }
                    }
                }
                current.checked = true; 
            }               
        </script>
    </telerik:RadCodeBlock>
    <div id="DivFormNavigation" runat="server" style="position:fixed;background-color:White;width:799px;padding:3px;">
        <asp:Button ID="btnSave" runat="server" Text="Done" CommandName="Save" OnClick="btnSave_Click"  />
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClientClick="CloseRadWin(); return false;" />
    </div>
    <br />
    <br />
    <div id="ErrorText" runat="server" visible="false" style="overflow:visible;border: solid 1px Red;color:Red;width: 799px;margin-top:3px;">
    </div>
    <div style="background-color:White;padding:3px;margin-top:3px;">
        &nbsp;&nbsp;&nbsp;Select an Aspen affiliation to be linked.
        <asp:Repeater ID="AffiliationRepeater" runat="server" OnItemDataBound="AffiliationRepeater_ItemDataBound">
            <HeaderTemplate>
                <table class="formTable" style="border: solid 1px silver;table-layout:fixed;" cellspacing="0" >
                    <tr valign="bottom">
                        <th style="width: 20px;border: solid 1px silver;background-color:Silver" align="center" valign="middle">&nbsp</th>
                        <th style="width: 60px;border: solid 1px silver;background-color:Silver" align="left">Branch ID</th>
                        <th style="width: 190px;border: solid 1px silver;background-color:Silver" align="left">Name</th>
                        <th style="width: 190px;border: solid 1px silver;background-color:Silver" align="left">Address</th>
                        <th style="width: 90px;border: solid 1px silver;background-color:Silver" align="left">City</th>
                        <th style="width: 90px;border: solid 1px silver;background-color:Silver" align="left">Zip</th>
                        <th style="width: 90px;border: solid 1px silver;background-color:Silver" align="center">Medicare<br />Branch ID</th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                    <tr valign="top">
                        <td style="border: solid 1px silver;">
                            <asp:RadioButton ID="optLink" runat="server" GroupName="optLinkOffsite" />
                        </td>
                        <td style="border: solid 1px silver;">
                            <asp:Label ID='lblBranchID' runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "BranchID") %>' />&nbsp;
                            <asp:HiddenField ID="hidBranchID" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "BranchID") %>' />
                        </td>
                        <td style="border: solid 1px silver;">
                            <asp:Label ID='lblFacName' runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FacilityName") %>' />&nbsp;
                        </td>
                        <td style="border: solid 1px silver;">
                            <asp:Label ID='lblAddress' runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Address") %>' />&nbsp;
                        </td>
                        <td align="center" style="border: solid 1px silver;">
                            <asp:Label ID='lblCity' runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "City") %>' />&nbsp;
                        </td>
                        <td align="center" style="border: solid 1px silver;">
                            <asp:Label ID='lblZip' runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Zip") %>' />&nbsp;
                        </td>
                        <td align="center" style="border: solid 1px silver;">
                            <asp:Label ID='lblMCareBranchID' runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "MCareBranchID") %>' />&nbsp;
                        </td>
                    </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
    </form>
</body>
</html>
