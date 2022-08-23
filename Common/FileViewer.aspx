<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FileViewer.aspx.cs" Inherits="POPS.Common.FileViewer" %>

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
    </form>
</body>
</html>
