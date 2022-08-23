<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FacilityOffiste.ascx.cs" Inherits="AppControl.FacilityOffiste" %>
<%@ Register src="~/AppControl/GenericATGGrid.ascx" tagname="GenericATGGrid" tagprefix="uc1" %>
<%@ Register src="~/AppControl/FacilityDetails.ascx" tagname="FacilityDetails" tagprefix="uc2" %>

<telerik:RadGrid ID="grdOffsite" runat="server" AutoGenerateColumns="False" 
    Width="100%" Height="130px" 
    onneeddatasource="grdOffsite_NeedDataSource" 
    onselectedindexchanged="grdOffsite_SelectedIndexChanged" 
    ClientSettings-Scrolling-AllowScroll="true">
    <MasterTableView>
        <Columns>
            <telerik:GridBoundColumn UniqueName="FACILITYNAME" DataField="FACILITYNAME" 
                HeaderText="Offiste/Branch/Satellite Name" visible="true" HeaderStyle-Width="40%">
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn UniqueName="AFFILIATIONTYPEDESC" DataField="AFFILIATIONTYPEDESC" 
                HeaderText="Type" visible="true" HeaderStyle-Width="20%">
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn UniqueName="LICENSURENUM" DataField="LICENSURENUM" 
                HeaderText="Licensure Number" visible="true" HeaderStyle-Width="20%">
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn UniqueName="ORIGINALLICENSUREDATE" DataField="ORIGINALLICENSUREDATE"
                HeaderText="Original Licensure Date" visible="true" HeaderStyle-Width="20%" HeaderStyle-Wrap="false" 
                DataFormatString="{0:MM/dd/yyyy}" ItemStyle-Wrap="false" >
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn UniqueName="AFFILIATIONID" DataField="AFFILIATIONID" 
                visible="false">
            </telerik:GridBoundColumn>
        </Columns>
    </MasterTableView>
    <ClientSettings EnablePostBackOnRowClick="true" Selecting-AllowRowSelect="true">
    </ClientSettings>
</telerik:RadGrid>
<br />
<div id="divLocationDetails" class="formTableSectionDiv" runat="server">
    Selected Offsite/Branch/Satellite Details
</div>
<table id="tableFacilityDetails" class="formTable" width="700" cellspacing="1" cellpadding="1">
    <tr>
        <td>
            <asp:Label ID="Label2" runat="server">License Number</asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TextBoxLicenseNumber" runat="server" MaxLength="12"  
                ToolTip="State License Number" ReadOnly="true">
            </asp:TextBox>
        </td>
        <td>
            <asp:Label ID="Label33" runat="server">Original License Date</asp:Label>
        </td>
        <td>
            <telerik:RadDatePicker ID="RadDatePickerOriginalLicenseDate" runat="server" Enabled="false" 
                ToolTip="Original License Date" MinDate="1900-01-01" Calendar-UseRowHeadersAsSelectors="False" 
                Calendar-UseColumnHeadersAsSelectors="False" Calendar-ViewSelectorText="x" Width="90" Calendar-FastNavigationStep="12" >
                <DatePopupButton CssClass="rcCalPopup rcDisabled" ImageUrl="" HoverImageUrl=""></DatePopupButton>
            </telerik:RadDatePicker>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label1" runat="server">CCN#</asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TextBoxCCN" runat="server" MaxLength="10" Columns="10"  
                ToolTip="RHC CCN#" ReadOnly="true">
            </asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label3" runat="server">Facility Name</asp:Label>
            <br />
        </td>
        <td>
            <asp:TextBox ID="TextBoxFacilityName" runat="server" MaxLength="60" 
                Columns="60" ToolTip="Facility Name" ReadOnly="true">
            </asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label4" runat="server">Geographical Street Address</asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TextBoxGeoStreetAddress" runat="server" MaxLength="100"  
                Columns="60" ToolTip="Geographical Street Address" ReadOnly="true">
            </asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label5" runat="server">Geographical City</asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TextBoxGeoCity" runat="server" Columns="30" 
                MaxLength="20" ToolTip="Geographical City" ReadOnly="true">
            </asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label18" runat="server">State</asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TextBoxGeoState" runat="server" Columns="2" 
                MaxLength="2" ToolTip="Geographical State" ReadOnly="true">
            </asp:TextBox>
        </td>
        <td>
            <asp:Label ID="Label19" runat="server">Zip</asp:Label>
        </td>
        <td>
            <telerik:RadMaskedTextBox ID="RadMaskedTextBoxGeoZip" runat="server" Columns="10" 
                ToolTip="Geographical Zip" ReadOnly="true" Mask="#####-####">
            </telerik:RadMaskedTextBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label28" runat="server">Telephone Number</asp:Label>
        </td>
        <td>
            <telerik:RadMaskedTextBox ID="RadMaskedTextBoxTelephoneNumber" runat="server" 
                Mask="(###) ###-####" Columns="13" ToolTip="Telephone Number" ReadOnly="true" >
            </telerik:RadMaskedTextBox>
        </td>
        <td>
            <asp:Label ID="Label29" runat="server">Fax Number</asp:Label>
        </td>
        <td>
            <telerik:RadMaskedTextBox ID="RadMaskedTextBoxFaxNumber" runat="server" 
                Mask="(###) ###-####" Columns="13" ToolTip="Fax Number" ReadOnly="true" >
            </telerik:RadMaskedTextBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label14" runat="server">Parish</asp:Label>
        </td>
        <td>
            <asp:DropDownList ID="listParish" runat="server" Enabled="false" />
        </td>
    </tr>
</table>
<div id="divCapByBedType" runat="server">
<table id="tableCapacityDetails" class="formTable" width="700" cellspacing="1" cellpadding="1">
    <tr>
        <td>
            <asp:Label ID="Label6" runat="server">Number of Units</asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TextBoxNumberofUnits" runat="server" Columns="2" 
                MaxLength="3" ToolTip="Number of Units" ReadOnly="true">
            </asp:TextBox>
        </td>
        <td>
            <asp:Label ID="Label7" runat="server">Licensed Beds</asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TextBoxLicensedBeds" runat="server" Columns="2" 
                MaxLength="3" ToolTip="Licensed Beds" ReadOnly="true">
            </asp:TextBox>
        </td>        
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label10" runat="server">Psych Beds</asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TextBoxPsychBeds" runat="server" Columns="2" 
                MaxLength="3" ToolTip="Psych Beds" ReadOnly="true">
            </asp:TextBox>
        </td>        
        <td>
            <asp:Label ID="Label9" runat="server">Rehab Beds</asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TextBoxRehabBeds" runat="server" Columns="2" 
                MaxLength="3" ToolTip="Rehab Beds" ReadOnly="true">
            </asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label11" runat="server">SNF Beds</asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TextBoxSNFBeds" runat="server" Columns="2" 
                MaxLength="3" ToolTip="SNF Beds" ReadOnly="true">
            </asp:TextBox>
        </td>        
        <td>
            <asp:Label ID="Label12" runat="server">Other Lic Beds</asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TextBoxOtherLicBeds" runat="server" Columns="2" 
                MaxLength="3" ToolTip="Other Lic Beds" ReadOnly="true">
            </asp:TextBox>
        </td>
    </tr>    
</table>
</div>
<div id="divCapacity_HC" runat="server" visible="false">
<div id="DivCapaciltyHeader" class="formTableSectionDiv" runat="server">
    Capacities
</div>
<table id="tblHCCap" class="formTable" width="180" cellspacing="1" cellpadding="1">
    <tr>
        <td style="width: 150px;">
            <asp:Label ID="lblSIL_SLCCapacity" runat="server" Width="150px">SIL Shared Living Conversion</asp:Label>
        </td>
        <td style="width: 30px;">
            <asp:TextBox ID="txtSIL_SLCCapacity" runat="server" Text="" Width="20px" Enabled="false" /><br />
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="lblRespiteCBCap" runat="server" Width="150px">Respite Care - Center Based</asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtRespiteCBCapacity" runat="server" Text="" Width="20px" Enabled="false" /><br />
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="lblADCCapacity" runat="server" Width="150px">ADC</asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtADCCapacity" runat="server" Text="" Width="20px" Enabled="false" /><br />
        </td>
    </tr>
</table>
</div>
