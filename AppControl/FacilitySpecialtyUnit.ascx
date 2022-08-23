<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FacilitySpecialtyUnit.ascx.cs" Inherits="AppControl.FacilitySpecialtyUnit" %>
<%@ Register src="SpecialtyUnit.ascx" tagname="SpecialtyUnit" tagprefix="uc2" %>

<telerik:RadGrid ID="grdSUApplications" runat="server" AutoGenerateColumns="False" 
    Width="100%" Height="130px" 
    OnNeedDataSource="grdSUApplications_NeedDataSource" 
    onselectedindexchanged="grdSUApplications_SelectedIndexChanged" 
    ClientSettings-Scrolling-AllowScroll="true">
    <MasterTableView>
        <Columns>
            <telerik:GridBoundColumn UniqueName="APPLICATIONID" DataField="APPLICATIONID" 
                visible="False" >
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn UniqueName="FEDERALID" DataField="FEDERALID" 
                visible="False">
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn UniqueName="BUSINESSPROCESSNAME" DataField="BUSINESSPROCESSNAME" 
                HeaderText="Application Type" visible="true" HeaderStyle-Width="20%">
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn UniqueName="VALDESC" DataField="VALDESC" 
                HeaderText="Application Status" visible="true" HeaderStyle-Width="20%">
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn UniqueName="GRIDDATESTARTED" DataField="GRIDDATESTARTED" 
                HeaderText="Start Date" visible="true" HeaderStyle-Width="20%" HeaderStyle-Wrap="false" 
                DataFormatString="{0:MM/dd/yyyy}" ItemStyle-Wrap="false" >
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn UniqueName="DATECOMPLETED" DataField="DATECOMPLETED" 
                HeaderText="Completion Date" visible="true" HeaderStyle-Width="20%" HeaderStyle-Wrap="false" 
                DataFormatString="{0:MM/dd/yyyy}" ItemStyle-Wrap="false" >
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn UniqueName="LICENSUREEXPIRATIONDATE" DataField="LICENSUREEXPIRATIONDATE" 
                HeaderText="Expiration Date" visible="true" HeaderStyle-Width="20%" HeaderStyle-Wrap="false" 
                DataFormatString="{0:MM/dd/yyyy}" ItemStyle-Wrap="false" >
            </telerik:GridBoundColumn>
        </Columns>
    </MasterTableView>
    <ClientSettings EnablePostBackOnRowClick="false" Selecting-AllowRowSelect="true">
    </ClientSettings>
</telerik:RadGrid>
<br />
<uc2:SpecialtyUnit ID="SpecialtyUnit1" runat="server" />

