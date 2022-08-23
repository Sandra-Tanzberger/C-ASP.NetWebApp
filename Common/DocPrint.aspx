<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DocPrint.aspx.cs" Inherits="Common.DocPrint" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
<style media="print" type="text/css" >
	*  
	{
		color: #000 !important; 
	    background: white !important;
	}
	
	.noShow
	{
		visibility: hidden;
		display: none;
	}
	
	.breakBefore
	{
		page-break-before: always; 
	}

	.breakAfter
	{
		page-break-after: always; 
	}
	
	
</style>
</head>
<body>
    <form id="PrintForm" runat="server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
    <div class="noShow" ><a href="javascript:window.print()">Print Letter</a></div>
    <asp:Panel ID="DocPrintPanel" runat="server" />
    </form>
</body>
</html>

