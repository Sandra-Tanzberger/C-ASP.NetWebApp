<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LinkPayment.aspx.cs" Inherits="State.Common.LinkPayment" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link href="../../style/PopupMaster.css" rel="stylesheet" type="text/css" />
    <link href="../../style/AtgWebUI.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <telerik:RadCodeBlock ID="selPaymentRCB" runat="server" >
        <script type="text/javascript">
            function CloseWin() {
                GetRadWindow().close();
            }
            function GetRadWindow() {
                var oWindow = null;
                if (window.radWindow) oWindow = window.radWindow; //Will work in Moz in all cases, including clasic dialog  
                else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow; //IE (and Moz as well)  

                return oWindow;
            }
            function CloseAndRebind(inArgs) {
                GetRadWindow().Close();
                GetRadWindow().BrowserWindow.refreshGrid(inArgs);
            }
            function UnlinkPaymentsConfirm() {
                var selecteditem = $find("<%= grdLinkPayment.MasterTableView.ClientID %>").get_selectedItems();

                 if (!selecteditem.length > 0) {
                     alert('Please select payment to unlink');
                 }
                 else {
                     return confirm("Are you sure you want to unlink the selected payment?");
                 }
             }
        </script> 
    </telerik:RadCodeBlock>
    <telerik:RadScriptManager ID="LinkPaymentRSM" runat="server">
    </telerik:RadScriptManager>
    <telerik:RadGrid ID="grdLinkPayment" runat="server" 
     AutoGenerateColumns = "false"  Width="100%" ClientSettings-Selecting-AllowRowSelect="true" 
     AllowPaging="false" AllowSorting="true" BorderStyle="None" AllowMultiRowSelection="true" 
     PageSize="100" GridLines="None" onneeddatasource="grdLinkPayment_NeedDataSource">
    <MasterTableView EnableViewState="true">
    </MasterTableView>
    <ClientSettings EnableRowHoverStyle="true">
        <Selecting AllowRowSelect="True" />
        <Scrolling AllowScroll="True" />
    </ClientSettings>
    </telerik:RadGrid>
    <asp:Button runat="server" ID="UnlinkBtn" Text="Unlink" onclick="UnlinkBtn_Click" OnClientClick="return UnlinkPaymentsConfirm();" Visible="false"/>
    <asp:Button runat="server" ID="SubmitBtn" Text="Save" onclick="SubmitBtn_Click" />
    <asp:Button runat="server" ID="CancelBtn" Text="Cancel" OnClick="CancelBtn_Click" />
    </form>
</body>
</html>
