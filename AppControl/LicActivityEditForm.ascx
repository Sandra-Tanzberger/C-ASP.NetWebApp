<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LicActivityEditForm.ascx.cs" Inherits="AppControl.LicActivityEditForm" %>

<asp:table ID="tblLicActEditForm" runat="server" BackColor="White" Width="200">
    <asp:TableRow>
        <asp:TableCell>
            <asp:Literal ID="litAppType" runat="server" Text="Application Type: " />
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell>
            <telerik:RadComboBox EnableViewState="true" ID="listAppType" runat="server" Width="250px" />
        </asp:TableCell>
    </asp:TableRow>
</asp:table>
<asp:button id="btnInsert" text="Create  " runat="server" CommandName="PerformInsert" Font-Size="Smaller" />
&nbsp;
<asp:button id="btnCancel" text="Cancel  " runat="server" causesvalidation="False" commandname="Cancel" />
