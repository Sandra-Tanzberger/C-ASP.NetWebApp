<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FacilityBeds.ascx.cs" Inherits="AppControl.FacilityBeds" %>
<%@ Register src="BedDetails.ascx" tagname="BedDetails" tagprefix="uc1" %>

<telerik:RadGrid ID="grdBedsGenericATGGrid" runat="server" AutoGenerateColumns="false" 
     Width="100%" Height="130px" 
    onneeddatasource="grdBedsGenericATGGrid_NeedDataSource" 
    onselectedindexchanged="grdBedsGenericATGGrid_SelectedIndexChanged" 
    ClientSettings-Scrolling-AllowScroll="true">
    <MasterTableView>
        <Columns>
            <telerik:GridBoundColumn UniqueName="DateStarted" DataField="DateStarted" 
                HeaderText="Application Start Date" visible="true" 
                HeaderStyle-Width="50%" HeaderStyle-Wrap="false" 
                DataFormatString="{0:MM/dd/yyyy}" ItemStyle-Wrap="false" >
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn UniqueName="TotalBeds" DataField="TotalBeds" 
                HeaderText="Total Beds" visible="true" HeaderStyle-Width="50%">
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn UniqueName="ApplicationId" DataField="ApplicationId" 
                visible="false">
            </telerik:GridBoundColumn>
        </Columns>
    </MasterTableView>
    <ClientSettings EnablePostBackOnRowClick="false" Selecting-AllowRowSelect="true">
    </ClientSettings>
</telerik:RadGrid>
<br />
<uc1:BedDetails ID="BedDetails1" runat="server" />

