<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FileUpload.aspx.cs" Inherits="POPS.Common.FileUpload" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <telerik:RadCodeBlock ID="UpldRCB" runat="server" >
        <script type="text/javascript">
            function CloseWin() {
                GetRadWindow().close();
            }
            function CloseAndRebind( inArgs ) {
                //var tmpArgs = document.getElementById("hideEventArgsForParent").value;
                GetRadWindow().BrowserWindow.refreshAttachParent( inArgs ); // Call the function in parent page  
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
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
		<telerik:RadUpload ID="RadUpload1" runat="server" InitialFileInputsCount="1" MaxFileInputsCount="1"
		ControlObjectsVisibility="None" MaxFileSize="6000000" InputSize="100" Width="100px" />
		<telerik:RadProgressManager ID="RadProgressManager2" runat="server"/>
        <telerik:RadProgressArea ID="RadProgressArea2" runat="server" Skin="Vista"></telerik:RadProgressArea>
        <asp:HiddenField ID="hideEventArgsForParent" runat="server" Value="" />      
    </div>
    <asp:Button runat="server" ID="SubmitButton" Text="Upload files" onclick="SubmitButton_Click" />
    <asp:Button runat="server" ID="CancelButton" Text="Cancel" OnClick="CancelButton_Click" />
    </form>
</body>
</html>
