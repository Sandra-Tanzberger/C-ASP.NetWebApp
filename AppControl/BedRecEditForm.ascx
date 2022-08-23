<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="BedRecEditForm.ascx.cs" Inherits="AppControl.BedRecEditForm" %>

<div >
<div id="ErrorText" runat="server" visible="false" style="overflow:visible;border: solid 1px Red;color:Red;width: 100%;">
</div>
<asp:table ID="tblEditForm" runat="server">
    <asp:TableRow>
        <asp:TableCell>
            <asp:Literal ID="litUnit" runat="server" Text="Location/Wing: " />
        </asp:TableCell>
        <asp:TableCell>
            <telerik:RadTextBox ID="txtUnit" runat="server" Width="100" MaxLength="20"/>
        </asp:TableCell>
        <asp:TableCell>
            <asp:Literal ID="litRoomSizeMet" runat="server" Text="Room Size Met: " />
        </asp:TableCell>
        <asp:TableCell>
            <asp:CheckBox ID="chkRoomSizeMet" runat="server" />
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell>
            <asp:Literal ID="litServiceType" runat="server" Text="Service Type: " />
        </asp:TableCell>
        <asp:TableCell>
            <telerik:RadComboBox ID="cboServiceType" runat="server" DataValueField="LOOKUP_VAL" DataTextField="VALDESC" />
        </asp:TableCell>
        <asp:TableCell>
            <asp:Literal ID="litCallSystemMet" runat="server" Text="Call System Met: " />
        </asp:TableCell>
        <asp:TableCell>
            <asp:CheckBox ID="ChkCallSysMet" runat="server" />
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell>
            <asp:Literal ID="litFloor" runat="server" Text="Floor: " />
        </asp:TableCell>
        <asp:TableCell>
            <telerik:RadNumericTextBox ID="txtFloor" runat="server" Width="40" MaxLength="3" Type="Number" NumberFormat-DecimalDigits="0" />
        </asp:TableCell>
        <asp:TableCell>
            <asp:Literal ID="litFurnitureMet" runat="server" Text="Furniture Met: " />
        </asp:TableCell>
        <asp:TableCell>
            <asp:CheckBox ID="ChkFurnitureMet" runat="server" />
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell>
            <asp:Literal ID="litRoomNumber" runat="server" Text="Room Number: " />
        </asp:TableCell>
        <asp:TableCell>
            <telerik:RadTextBox ID="txtRoomNumber" runat="server" Width="40" MaxLength="5"/>
        </asp:TableCell>
        <asp:TableCell>
            <asp:Literal ID="litPrivacyMet" runat="server" Text="Privacy Curtain or Wall Met: " />
        </asp:TableCell>
        <asp:TableCell>
            <asp:CheckBox ID="ChkPrivacyMet" runat="server" />
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell>
            <asp:Literal ID="litNumBeds" runat="server" Text="Number of Beds: " />
        </asp:TableCell>
        <asp:TableCell ColumnSpan="3">
            <telerik:RadNumericTextBox ID="txtNumberBeds" runat="server" Width="40" Type="Number" NumberFormat-DecimalDigits="0" />
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell ColumnSpan="4">
            <asp:Literal ID="litComments" runat="server" Text="Comments: " /><br />
            <telerik:RadTextBox ID="txtComments" runat="server" TextMode="MultiLine" Columns="80" Rows="2" MaxLength="255" />
        </asp:TableCell>
    </asp:TableRow>
</asp:table>
<asp:button id="btnUpdate" text="Update" runat="server" CommandName="Update" />
<asp:button id="btnInsert" text="Save" runat="server" CommandName="PerformInsert" />
&nbsp;
<asp:button id="btnCancel" text="Cancel" runat="server" causesvalidation="False" commandname="Cancel"></asp:button>
<asp:HiddenField ID="hidUITrackID" runat="server" />
</div>