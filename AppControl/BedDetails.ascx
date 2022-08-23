<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BedDetails.ascx.cs" Inherits="AppControl.BedDetails" %>

<div id="ErrorText" runat="server" visible="false" style="overflow:visible;border: solid 1px Red;color:Red;width: 100%;">
</div>
<div id="DivLocationHeader" class="formTableSectionDiv" runat="server">
    <asp:Label ID="lblLocation" runat="server" Text="" />
</div>     
<div style="margin-left: 10px;" >
    <asp:Table ID="tblLocCapacities" runat="server" CssClass="formTable" Width="200" BorderWidth="1" GridLines="Both" BorderColor="#999966">
        <asp:TableHeaderRow>
            <asp:TableHeaderCell HorizontalAlign="Left" BackColor="#999966" Width="100" Text="Current Location Totals" ColumnSpan="2" />
        </asp:TableHeaderRow>
        <asp:TableHeaderRow>
            <asp:TableHeaderCell Width="100" Text="Current Bed Capacity" BorderColor="#999966" />
            <asp:TableHeaderCell Width="100" Text="Current Number of Rooms" BorderColor="#999966" />
        </asp:TableHeaderRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Center" BorderColor="#999966"><asp:Literal ID="LocCurrentBedCap" runat="server" Text="" /></asp:TableCell>
            <asp:TableCell HorizontalAlign="Center" BorderColor="#999966"><asp:Literal ID="LocCurrentNumRooms" runat="server" Text="" /></asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <div id="DivLicBedHdr" class="formTableSectionDiv" runat="server">
        Licensed Beds
    </div>     
        <telerik:RadGrid ID="rgLicensedBedRecs" runat="server" Height="350" Width="98%"
                         OnNeedDataSource="rgLicensedBedRecs_NeedDataSource"
                         OnItemCreated="rgLicensedBedRecs_ItemCreated"
                         OnInsertCommand="rgLicensedBedRecs_InsertCommand"
                         OnDeleteCommand="rgLicensedBedRecs_DeleteCommand"
                         OnUpdateCommand="rgLicensedBedRecs_UpdateCommand" 
                         OnPreRender="rgLicensedBedRecs_PreRender"
                         AutoGenerateColumns="false">
            <MasterTableView>
                <CommandItemTemplate>
                    <asp:LinkButton ID="btnLBAddNew" runat="server" CommandName="InitInsert" >
                        <img style="border:0px;vertical-align:middle;" alt="" src="../../images/AddRecord.gif" />
                        Add Bed Item
                    </asp:LinkButton>
                    &nbsp;&nbsp;&nbsp;
                    <asp:LinkButton ID="btnLBEditSelected" runat="server" CommandName="EditSelected" >
                        <img style="border:0px;vertical-align:middle;" alt="" src="../../images/Edit.gif" />
                        Edit Selected Bed Item
                    </asp:LinkButton>
                    &nbsp;&nbsp;&nbsp;
                    <asp:LinkButton ID="btnLBViewSelected" runat="server" CommandName="EditSelected" >
                        <img style="border:0px;vertical-align:middle;" alt="" src="../../images/Edit.gif" />
                        View Selected Bed Item
                    </asp:LinkButton>
                    &nbsp;&nbsp;&nbsp;
                    <asp:LinkButton ID="btnLBDeleteSelected" runat="server" CommandName="DeleteSelected" >
                        <img style="border:0px;vertical-align:middle;" alt="" src="../../images/Delete.gif" />
                        Delete Selected Bed Item
                    </asp:LinkButton>
                </CommandItemTemplate>
                <EditFormSettings FormStyle-BackColor="#f3f4d7" UserControlName="~/AppControl/BedRecEditForm.ascx" EditFormType="WebUserControl">
                </EditFormSettings>
            </MasterTableView>
        </telerik:RadGrid>
    <div id="DivNonLicBedHdr" class="formTableSectionDiv" runat="server">
        Non-Licensed Beds
    </div>     
        <telerik:RadGrid ID="rgNonLicensedBedRecs" runat="server" Height="350" Width="98%"
                     OnNeedDataSource="rgNonLicensedBedRecs_NeedDataSource"
                     OnItemCreated="rgNonLicensedBedRecs_ItemCreated"
                     OnInsertCommand="rgNonLicensedBedRecs_InsertCommand"
                     OnDeleteCommand="rgNonLicensedBedRecs_DeleteCommand"
                     OnUpdateCommand="rgNonLicensedBedRecs_UpdateCommand" 
                     OnPreRender="rgNonLicensedBedRecs_PreRender"
                     AutoGenerateColumns="false">
        <MasterTableView>
            <CommandItemTemplate>
                <asp:LinkButton ID="btnNLBAddNew" runat="server" CommandName="InitInsert" >
                    <img style="border:0px;vertical-align:middle;" alt="" src="../../images/AddRecord.gif" />
                    Add Bed Item
                </asp:LinkButton>
                &nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="btnNLBEditSelected" runat="server" CommandName="EditSelected" >
                    <img style="border:0px;vertical-align:middle;" alt="" src="../../images/Edit.gif" />
                    Edit Selected Bed Item
                </asp:LinkButton>
                &nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="btnNLBViewSelected" runat="server" CommandName="EditSelected" >
                    <img style="border:0px;vertical-align:middle;" alt="" src="../../images/Edit.gif" />
                    View Selected Bed Item
                </asp:LinkButton>
                &nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="btnNLBDeleteSelected" runat="server" CommandName="DeleteSelected" >
                    <img style="border:0px;vertical-align:middle;" alt="" src="../../images/Delete.gif" />
                    Delete Selected Bed Item
                </asp:LinkButton>
            </CommandItemTemplate>
            <EditFormSettings FormStyle-BackColor="#f3f4d7" UserControlName="~/AppControl/BedRecEditForm.ascx" EditFormType="WebUserControl">
            </EditFormSettings>
        </MasterTableView>
    </telerik:RadGrid>
</div>
<br />
<br />
    <asp:Table ID="tblLicTotals" runat="server" CssClass="formTable" Width="600" BorderWidth="1" GridLines="Both" BorderColor="#999966">
        <asp:TableHeaderRow>
            <asp:TableHeaderCell HorizontalAlign="Left" BackColor="#999966" Width="100" Text="Licensed Totals" ColumnSpan="6" BorderColor="#999966" />
        </asp:TableHeaderRow>
        <asp:TableHeaderRow VerticalAlign="Bottom">
            <asp:TableHeaderCell Width="100" Text="Main Campus Beds" BorderColor="#999966" />
            <asp:TableHeaderCell Width="100" Text="Offsite Beds" BorderColor="#999966" />
            <asp:TableHeaderCell Width="100" Text="Entire Facility Beds" BorderColor="#999966" />
            <asp:TableHeaderCell Width="100" Text="Main Campus Rooms" BorderColor="#999966" />
            <asp:TableHeaderCell Width="100" Text="Offsite Rooms" BorderColor="#999966" />
            <asp:TableHeaderCell Width="100" Text="Entire Facility Rooms" BorderColor="#999966" />
        </asp:TableHeaderRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Center" BorderColor="#999966"><asp:Literal ID="LicMainCampBeds" runat="server" Text="" /></asp:TableCell>
            <asp:TableCell HorizontalAlign="Center" BorderColor="#999966"><asp:Literal ID="LicOffSiteTotBeds" runat="server" Text="" /></asp:TableCell>
            <asp:TableCell HorizontalAlign="Center" BorderColor="#999966"><asp:Literal ID="LicPrvdrTotBeds" runat="server" Text="" /></asp:TableCell>
            <asp:TableCell HorizontalAlign="Center" BorderColor="#999966"><asp:Literal ID="LicMainCampRooms" runat="server" Text="" /></asp:TableCell>
            <asp:TableCell HorizontalAlign="Center" BorderColor="#999966"><asp:Literal ID="LicOffSiteTotRooms" runat="server" Text="" /></asp:TableCell>
            <asp:TableCell HorizontalAlign="Center" BorderColor="#999966"><asp:Literal ID="LicPrvdrTotRooms" runat="server" Text="" /></asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <br />
    <asp:Table ID="tblNonLicTotals" runat="server" CssClass="formTable" Width="600" BorderWidth="1" GridLines="Both" BorderColor="#999966">
        <asp:TableHeaderRow>
            <asp:TableHeaderCell HorizontalAlign="Left" BackColor="#999966" Width="100" Text="Non-Licensed Totals" ColumnSpan="6" />
        </asp:TableHeaderRow>
        <asp:TableHeaderRow VerticalAlign="Bottom">
            <asp:TableHeaderCell Width="100" Text="Main Campus Beds" BorderColor="#999966" />
            <asp:TableHeaderCell Width="100" Text="Offsite Beds" BorderColor="#999966" />
            <asp:TableHeaderCell Width="100" Text="Entire Facility Beds" BorderColor="#999966" />
            <asp:TableHeaderCell Width="100" Text="Main Campus Rooms" BorderColor="#999966" />
            <asp:TableHeaderCell Width="100" Text="Offsite Rooms" BorderColor="#999966" />
            <asp:TableHeaderCell Width="100" Text="Entire Facility Rooms" BorderColor="#999966" />
        </asp:TableHeaderRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Center" BorderColor="#999966"><asp:Literal ID="NonLicMainCampBeds" runat="server" Text="" /></asp:TableCell>
            <asp:TableCell HorizontalAlign="Center" BorderColor="#999966"><asp:Literal ID="NonLicOffSiteTotBeds" runat="server" Text="" /></asp:TableCell>
            <asp:TableCell HorizontalAlign="Center" BorderColor="#999966"><asp:Literal ID="NonLicPrvdrTotBeds" runat="server" Text="" /></asp:TableCell>
            <asp:TableCell HorizontalAlign="Center" BorderColor="#999966"><asp:Literal ID="NonLicMainCampRooms" runat="server" Text="" /></asp:TableCell>
            <asp:TableCell HorizontalAlign="Center" BorderColor="#999966"><asp:Literal ID="NonLicOffSiteTotRooms" runat="server" Text="" /></asp:TableCell>
            <asp:TableCell HorizontalAlign="Center" BorderColor="#999966"><asp:Literal ID="NonLicPrvdrTotRooms" runat="server" Text="" /></asp:TableCell>
        </asp:TableRow>
    </asp:Table>
  
