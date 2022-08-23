<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OwnFacOtherEditForm.ascx.cs" Inherits="AppControl.OwnFacOtherEditForm" %>

<div id="ErrorText" runat="server" visible="false" style="background-color: White;overflow:visible;border: solid 1px Red;color:Red;width: 100%;">
</div>
<asp:Table ID="tblKPEducation" runat="server" BackColor="#f3f4d7">
    <asp:TableRow>
        <asp:TableCell>
            <asp:Label ID="lblOwnerInterestList" runat="server" Text="Owner:" />
        </asp:TableCell>
        <asp:TableCell>
            <telerik:RadComboBox ID="cboOwnerInterestList" runat="server" />
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell>
            <asp:Label ID="lblFacilityName" runat="server" Text="Facility Name:" />
        </asp:TableCell>
        <asp:TableCell>
            <asp:TextBox ID="txtFacilityName" runat="server" Width="300"/>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell>
            <asp:Label ID="lblFacilityAddress" runat="server" Text="Address, City, State, Zip:" />
        </asp:TableCell>
        <asp:TableCell>
            <asp:TextBox ID="txtFacilityAddress" runat="server" Width="400"/>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell Width="150">
            <asp:Label ID="lblProviderNumber" runat="server" Text="Provider Number:" />
        </asp:TableCell>
        <asp:TableCell Width="300">
            <asp:TextBox ID="txtProviderNumber" runat="server" Width="125"/>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell>
            <asp:Label ID="lblStateID" runat="server" Text="State ID:" />
        </asp:TableCell>
        <asp:TableCell>
            <asp:TextBox ID="txtStateID" runat="server" Width="125"/>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell ColumnSpan="2">
            <asp:button id="btnUpdate" text="Update" runat="server" CommandName="Update" Visible="false" />
            <asp:button id="btnInsert" text="Save" runat="server" CommandName="PerformInsert" Visible="false"/>
            &nbsp;
            <asp:button id="btnCancel" text="Cancel" runat="server" CommandName="Cancel" Visible="false" causesvalidation="False" ></asp:button>
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>
<asp:HiddenField ID="hiddenOwnFacOtherProvID" runat="server" />
<asp:HiddenField ID="hiddenOrigLE_UI_Trackid" runat="server" />