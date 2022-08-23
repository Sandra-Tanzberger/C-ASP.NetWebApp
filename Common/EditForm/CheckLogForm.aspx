<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CheckLogForm.aspx.cs" Inherits="Common.EditForm.CheckLogForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link href="../../style/PopupMaster.css" rel="stylesheet" type="text/css" />
    <link href="../../style/AtgWebUI.css" rel="stylesheet" type="text/css" />
 </head>
<body style="overflow:auto">
    <form id="form1" runat="server">
        <telerik:RadScriptManager ID="CheckLogEditRSM" runat="server">
        <Scripts>
            <asp:ScriptReference Path="~/Include/Common.js" />
            <asp:ScriptReference Path="~/Include/AtgWebUI.js" />
        </Scripts>
    </telerik:RadScriptManager>
    <telerik:RadAjaxManager ID="CheckLogEditRAM" runat="server">
    </telerik:RadAjaxManager>
    <telerik:RadFormDecorator ID="CheckLogEditFormdecorator" runat="server" DecoratedControls="Buttons,CheckBoxes,Label" EnableRoundedCorners="false" />
    <telerik:RadCodeBlock ID="CheckLogEditRCB" runat="server">
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
                GetRadWindow().BrowserWindow.refreshParent(inArgs); // Call the function in parent page  
                GetRadWindow().close(); // Close the window
            }
            
            function GetRadWindow() {
                var oWindow = null;
                if (window.radWindow) oWindow = window.radWindow; //Will work in Moz in all cases, including clasic dialog  
                else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow; //IE (and Moz as well)  

                return oWindow;
            }                        
        </script>
    </telerik:RadCodeBlock>
    <div id="DivFormNavigation" runat="server" style="position:fixed;clear: both;background-color:White;width:710px;padding:3px;border-bottom: solid 1px black;">
        <asp:Button ID="btnSaveExit" runat="server" Text="Done" CommandName="SaveExit" OnClick="btnSave_Click" />
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClientClick="CloseRadWin(); return false;" />
    </div>
    <br />
    <br />
    <div id="ErrorText" runat="server" visible="false" style="overflow:visible;border: solid 1px Red;color:Red;width: 99.5%;">
    </div>
    <div >
        <asp:table ID="TblCheckLogForm" runat="server">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblDateEntered" runat="server" Text="Date Entered: " />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Literal ID="litDateEntered" runat="server" Text="" /> 
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblStateID" runat="server" Text="State ID: " />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Textbox ID="txtStateID" runat="server" Text="" Width="90" AutoPostBack="true" OnTextChanged="txtStateID_TextChanged" Font-Size="11px"/>
                    <span id="spanProvNotFound" runat="server" visible="false" style="overflow:visible;border: solid 1px Red;color:Red;width: 100%;">
                        <asp:Label ID="litProvNotFoundErr" runat="server" Text="No matching Provider" />
                    </span>  
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblCompanyIndividual" runat="server" Text="Company/Individual: " />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Textbox ID="txtCompanyIndividual" runat="server" Text="" Width="300" Font-Size="11px"/> 
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblAmount" runat="server" Text="Amount: " />
                </asp:TableCell>
                <asp:TableCell>
                    <telerik:RadNumericTextBox ID="rntbAmount" runat="server" Width="160" Type="Currency" NumberFormat-GroupSeparator="" NumberFormat-DecimalDigits="2" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblCheckNum" runat="server" Text="Check Number: " />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Textbox ID="txtCheckNum" runat="server" Text="" Width="97" Font-Size="11px"/> 
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblCheckDate" runat="server" Text="Check Date: " />
                </asp:TableCell>
                <asp:TableCell>
                    <telerik:RadDatePicker ID="rdpCheckDate" runat="server" Width="120" DateInput-DateFormat="MM/dd/yyyy" MinDate="01/01/1900" ZIndex="9999"  Calendar-FastNavigationStep="12" /> 
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblCheckLogPrefix" runat="server" Text="Type Provider: " />
                </asp:TableCell>
                <asp:TableCell>
                    <telerik:RadComboBox ID="lstCheckLogPrefix" runat="server" Width="300" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblTypeFee" runat="server" Text="Reason: " />
                </asp:TableCell>
                <asp:TableCell>
                    <telerik:RadComboBox ID="lstTypeFee" runat="server" Width="250" OnSelectedIndexChanged="lstTypeFee_SelectedIndexChanged" AutoPostBack="true" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblApplID" runat="server" Text="This Check Linked to: " />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="lblApplIDval" runat="server" Text="" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblPIV" runat="server" Text="PIV Number: " />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Textbox ID="txtPIV" runat="server" Text="" Width="90" MaxLength="6" Font-Size="11px"/> 
                </asp:TableCell>
            </asp:TableRow>
             <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblComment" runat="server" Text="Comment: " />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Textbox ID="txtComment" runat="server" Text="" Width="250" MaxLength="255" Font-Size="11px"/> 
                </asp:TableCell>
            </asp:TableRow>
        </asp:table>
        <br />
        <b><asp:Label ID="lblNote" runat="server" Text="Note:" /></b>
        <asp:Label ID="txtNote" runat="server" Text="Checks linked to an approved application process cannot be de-linked." />
    </div>
    </form>
</body>
</html>
