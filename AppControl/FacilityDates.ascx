<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FacilityDates.ascx.cs" Inherits="AppControl.FacilityDates" %>

<asp:Table ID="tableFacilityDates"  CssClass="formTable" CellSpacing="0" BorderWidth="0" Width="98%" runat="server">
    <asp:TableRow>
        <asp:TableCell>
            <asp:Label ID="Label1" runat="server">Current Survey Date</asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <telerik:RadDatePicker ID="RadDatePickerCurrSurvDate" runat="server" 
                Enabled="false" ToolTip="Current Survey Date" MinDate="1900-01-01" Calendar-FastNavigationStep="12" >
            </telerik:RadDatePicker>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell>
            <asp:Label ID="OriginalLicenseIssueDate" runat="server">Original License Issue Date</asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <telerik:RadDatePicker ID="RadDatePickerOrigLicIssueDate" runat="server" 
                Enabled="false" ToolTip="Original License Issue Date" MinDate="1900-01-01" Calendar-FastNavigationStep="12" >
            </telerik:RadDatePicker>
        </asp:TableCell>
        <asp:TableCell>
            <asp:Label ID="CurrentLicenseIssueDate" runat="server">Current License Issue Date</asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <telerik:RadDatePicker ID="RadDatePickerCurrLicIssueDate" runat="server" 
                Enabled="false" ToolTip="Current License Issue Date" MinDate="1900-01-01" Calendar-FastNavigationStep="12" >
            </telerik:RadDatePicker>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell>
            <asp:Label ID="LicenseExpirationDate" runat="server">License Expiration Date</asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <telerik:RadDatePicker ID="RadDatePickerLicExpDate" runat="server" 
                Enabled="false" ToolTip="License Expiration Date" MinDate="1900-01-01" Calendar-FastNavigationStep="12" >
            </telerik:RadDatePicker>
        </asp:TableCell>
        <asp:TableCell>
            <asp:Label ID="Label34" runat="server">License Anniversary Month</asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <telerik:RadTextBox ID="RadTextBoxLicAnnivMonth" runat="server" MaxLength="02" Columns="02" Rows="1" ToolTip="License Anniversary Month" ReadOnly="true" ReadOnlyStyle-BackColor="LightGray">
            </telerik:RadTextBox>
        </asp:TableCell>
    </asp:TableRow>    
    <asp:TableRow>
        <asp:TableCell>
            <asp:Label ID="LicsenseSurveyDate" runat="server">License Survey Date</asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <telerik:RadDatePicker ID="RadDatePickerLicSrvyDate" runat="server" 
                Enabled="false" ToolTip="License Survey Date" MinDate="1900-01-01" Calendar-FastNavigationStep="12" >
            </telerik:RadDatePicker>
        </asp:TableCell>
        <asp:TableCell>
            <asp:Label ID="HealthApprovalDate" runat="server">Health Approval Date</asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <telerik:RadDatePicker ID="RadDatePickerHealthApprovalDate" runat="server" 
                Enabled="false" ToolTip="Health Approval Date" MinDate="1900-01-01" Calendar-FastNavigationStep="12" >
            </telerik:RadDatePicker>
        </asp:TableCell>
        
    </asp:TableRow>    
    <asp:TableRow>
        <asp:TableCell>
            <asp:Label ID="Label38" runat="server">State Fire Approval Date</asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <telerik:RadDatePicker ID="RadDatePickerStateFireApprovalDate" runat="server" 
                Enabled="false" ToolTip="State Fire Approval Date" MinDate="1900-01-01" Calendar-FastNavigationStep="12" >
            </telerik:RadDatePicker>
        </asp:TableCell>
        <asp:TableCell>
            <asp:Label ID="OneYrSurveyDueDate" runat="server" Visible="false">1 Yr Survey Due Date</asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <telerik:RadDatePicker ID="RadDatePicker1YrSurveyDueDate" runat="server" 
                Enabled="false" ToolTip="1 Yr Survey Due Date" MinDate="1900-01-01" Calendar-FastNavigationStep="12" Visible="false">
            </telerik:RadDatePicker>
        </asp:TableCell>
        <asp:TableCell>
            <asp:Label ID="LabelCHOWDate" runat="server" Text="CHOW Date"></asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <telerik:RadDatePicker ID="RadDatePickerCHOWDate" runat="server" 
                Enabled="false" ToolTip="CHOW Date" MinDate="1900-01-01" Calendar-FastNavigationStep="12" >
            </telerik:RadDatePicker>        
        </asp:TableCell>
    </asp:TableRow>    
</asp:Table>
