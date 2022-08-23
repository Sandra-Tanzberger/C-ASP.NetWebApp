<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BatchPIVForm.aspx.cs" Inherits="Common.EditForm.BatchPIVForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link href="../../style/PopupMaster.css" rel="stylesheet" type="text/css" />
    <link href="../../style/AtgWebUI.css" rel="stylesheet" type="text/css" />
 </head>
<body>
    <form id="form1" runat="server">
            <telerik:RadScriptManager ID="BatchPIV_RSM" runat="server">
        <Scripts>
            <asp:ScriptReference Path="~/Include/Common.js" />
            <asp:ScriptReference Path="~/Include/AtgWebUI.js" />
        </Scripts>
    </telerik:RadScriptManager>
    <telerik:RadAjaxManager ID="BatchPIV_RAM" runat="server">
    </telerik:RadAjaxManager>
    <telerik:RadFormDecorator ID="BatchPIV_Formdecorator" runat="server" DecoratedControls="Buttons,CheckBoxes,Label" EnableRoundedCorners="false" />
    <telerik:RadCodeBlock ID="BatchPIV_RCB" runat="server">
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
    <br />
    <div>
        <asp:table ID="TblBatchPIVForm" runat="server">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblBatchID" runat="server" Text="Batch ID: " />
                </asp:TableCell>
                <asp:TableCell>
                    <telerik:RadNumericTextBox ID="rntbBatchID" runat="server" Width="100" Type="Number" 
                        NumberFormat-GroupSeparator="" NumberFormat-DecimalDigits="0" MaxLength="18" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblPIVNum" runat="server" Text="PIV Number: " />
                </asp:TableCell>
                <asp:TableCell>
                    <telerik:RadTextBox ID="txtPIVNum" runat="server" Width="100" MaxLength="6" /> 
                </asp:TableCell>
            </asp:TableRow>
        </asp:table>
    </div>
    </form>
</body>
</html>
