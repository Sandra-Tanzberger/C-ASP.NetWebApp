<%@ Control Language="C#" EnableViewState="true" AutoEventWireup="true" CodeBehind="LOIMatchFormControl.ascx.cs" Inherits="AppControl.LOIMatchFormControl" %>

<center>
<asp:Table CssClass="formTable" ID="matchTbl" BorderWidth="0"  
    runat="server" Height="100%">
        <asp:TableRow>
            <asp:TableCell VerticalAlign="Top" ColumnSpan="2" HorizontalAlign="Left">
                <asp:Label ID="lblFinalMsg" runat="server" Text="&nbsp;" Visible="true" ForeColor="Red" />      
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell VerticalAlign="Top" ColumnSpan="2" HorizontalAlign="Center">
                <asp:Label ID="lblInstructions" runat="server" Text="Match Selected Letter of Intent:" Font-Size="Large" Font-Bold="True" />&nbsp;&nbsp;
                <asp:Label ID="lblTrackID" runat="server" Text="     " Font-Size="Large" Font-Bold="True" /><br/><br/>
                <asp:Label ID="lblInstructions2" runat="server" Text="To match the selected Letter of Intent:  " /><br/>
            </asp:TableCell>
        </asp:TableRow>
         <asp:TableRow>
            <asp:TableCell VerticalAlign="Top" ColumnSpan="2" HorizontalAlign="Center">
                <asp:Label ID="Label3" runat="server" AssociatedControlID="btnLink" Text="Step 1: " Font-Bold="True" Visible="false" />
                <asp:Button runat="server" ID="btnLink" Text="Link the Facility to this Letter Of Intent"  OnCommand="LinkButton_Click" Enabled="true"/>            
            </asp:TableCell>            
        </asp:TableRow>    
        <asp:TableRow>
            <asp:TableCell VerticalAlign="Top" ColumnSpan="2">
                <asp:Label ID="lblErrMsg" runat="server" Text="&nbsp;" Visible="true" ForeColor="Red" />                
            </asp:TableCell>
        </asp:TableRow>    
        <asp:TableRow>
            <asp:TableCell VerticalAlign="Top" ColumnSpan="2">
                <asp:Label ID="Label4" runat="server" AssociatedControlID="btnPrntUN" Text="Step 2: " Font-Bold="True" Visible="false" />&nbsp;&nbsp;
                <asp:Button runat="server" ID="btnPrntUN" Text="Print Login &amp; Password Memo"  OnCommand="PrintUNButton_Click" Enabled="False" Visible="false" />                            
            </asp:TableCell>           
        </asp:TableRow>        
        <asp:TableRow>
            <asp:TableCell VerticalAlign="Bottom" HorizontalAlign="Right">
                <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
                </telerik:RadWindowManager>
<%--                <asp:Button runat="server" ID="btnView" Text="View Letter of Intent"  OnCommand="ViewButton_Click"/>            
--%>            </asp:TableCell>
        </asp:TableRow>       
</asp:Table>
</center>