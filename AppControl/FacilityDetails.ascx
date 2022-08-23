<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FacilityDetails.ascx.cs" Inherits="AppControl.FacilityDetails" %>

<style type="text/css">
    .style1
    {
        width: 200px;
    }
    .style2
    {
        width: 420px;
    }
    .style3
    {
        width: 120px;
    }
    .style4
    {
        width: 150px;
    }
    .style5
    {
        width: 50px;
    }
    .style6
    {
        width: 100px;
    }
</style>

<table id="tableFacilityDetails" class="formTable" cellspacing="1" cellpadding="1" border="0">
        <tr>
            <td class="style1">
                <asp:Label ID="Label1" runat="server">CCN #</asp:Label>
            </td>
            <td class="style2">
                <asp:TextBox ID="TextBoxFederalId" runat="server" 
                MaxLength="12" ToolTip="Federal ID" Columns="12" ReadOnly="true">
                </asp:TextBox> 
            </td>
            <td class="style3">
                <asp:Label ID="LicenseNumber" runat="server">License Number</asp:Label>
            </td>
            <td class="style4">
                <asp:TextBox ID="TextBoxLicenseNumber" runat="server" MaxLength="12"  
                    ToolTip="State License Number" ReadOnly="true">
                </asp:TextBox>
            </td>
            <td class="style5">
                <asp:Label ID="Label22" runat="server">State Id</asp:Label>
            </td>
            <td class="style6">
                <asp:TextBox ID="TextBoxStateId" runat="server" MaxLength="12" Columns="12" 
                    ToolTip="State Id" ReadOnly="true">
                </asp:TextBox>
            </td>                    
        </tr>
        <tr>
            <td class="style1">
                <asp:Label ID="Label3" runat="server">Facility Name</asp:Label>
            </td>
            <td class="style2">
                <asp:TextBox ID="TextBoxFacilityName" runat="server" Width="95%"
                    MaxLength="60" ToolTip="Facility Name" ReadOnly="true">
                </asp:TextBox>
            </td>
            <td class="style3">Operating Status</td>
            <td class="style4"><asp:DropDownList ID="listOperStat" runat="server" Enabled="false" Width="95%" /></td>
            <td class="style5"></td>
            <td class="style6"></td>
        </tr>
        <tr>
            <td class="style1">
                <asp:Label ID="Label4" runat="server">Geographical Street Address</asp:Label>
            </td>
            <td class="style2">
                <asp:TextBox ID="TextBoxGeoStreetAddress" runat="server" Width="95%"
                    ToolTip="Geographical Street Address" ReadOnly="true">
                </asp:TextBox>
            </td>
            <td class="style3">Status Date</td>
            <td class="style4">
                <telerik:RadDatePicker ID="RadDatePickerStatusDate" runat="server" Enabled="false" 
                    ToolTip="Status Date" MinDate="1900-01-01" Calendar-FastNavigationStep="12" >
                </telerik:RadDatePicker>
            </td>
            <td class="style5"></td>
            <td class="style6"></td>
        </tr>
        <tr>
            <td class="style1">
                <asp:Label ID="Label5" runat="server">Geographical City</asp:Label>
            </td>
            <td class="style2">
                <asp:TextBox ID="TextBoxGeoCity" runat="server" Columns="20"
                    MaxLength="20" ToolTip="Geographical City" ReadOnly="true">
                </asp:TextBox>
            </td>
            <td class="style3">
                <asp:Label ID="Label18" runat="server">State</asp:Label>
            </td>
            <td class="style4">
                <asp:TextBox ID="TextBoxGeoState" runat="server" Columns="2" 
                    MaxLength="2" ToolTip="Geographical State" ReadOnly="true">
                </asp:TextBox>
            </td>
            <td class="style5">
                <asp:Label ID="Label19" runat="server">Zip</asp:Label>
            </td>
            <td class="style6">
                <telerik:RadMaskedTextBox ID="RadMaskedTextBoxGeoZip" runat="server" Columns="10" 
                    ToolTip="Geographical Zip" ReadOnly="true" Mask="#####-####">
                </telerik:RadMaskedTextBox>
            </td>
        </tr>
        <tr>
            <td class="style1">
                <asp:Label ID="Label28" runat="server">Telephone Number</asp:Label>
            </td>
            <td class="style2">
                <telerik:RadMaskedTextBox ID="RadMaskedTextBoxTelephoneNumber" runat="server" 
                    Mask="(###) ###-####" Columns="13" ToolTip="Telephone Number" ReadOnly="true" >
                </telerik:RadMaskedTextBox>
            </td>
            <td class="style3">
                <asp:Label ID="Label29" runat="server">Fax Number</asp:Label>
            </td>
            <td class="style4">
                <telerik:RadMaskedTextBox ID="RadMaskedTextBoxFaxNumber" runat="server" 
                    Mask="(###) ###-####" Columns="13" ToolTip="Fax Number" ReadOnly="true" >
                </telerik:RadMaskedTextBox>
            </td>
            <td class="style5"><asp:Label ID="lblEmergencyPhone" runat="server" Visible="false">Emergency Phone</asp:Label></td>
            <td class="style6"> <telerik:RadMaskedTextBox ID="RadMaskedTextBoxEmergencyPhone" runat="server" 
                    Mask="(###) ###-####" Columns="13" ToolTip="Emergency Phone Number" ReadOnly="true" Visible="false">
                </telerik:RadMaskedTextBox></td>
        </tr>
        <tr>
            <td class="style1">
                <asp:Label ID="Label6" runat="server">Mail Street Address</asp:Label>
            </td>
            <td class="style2">
                <asp:TextBox ID="TextBoxMailStreetAddress" runat="server" Width="95%"
                    ToolTip="Mail Street Address" ReadOnly="true">
                </asp:TextBox>
            </td>
            <td class="style3"></td>
            <td class="style4"></td>
            <td class="style5"></td>
            <td class="style6"></td>
        </tr>
        <tr>
            <td class="style1">
                <asp:Label ID="Label7" runat="server">Mail City</asp:Label>
            </td>
            <td class="style2">
                <asp:TextBox ID="TextBoxMailCity" runat="server" Columns="20" 
                    MaxLength="20" ToolTip="Mail City" ReadOnly="true">
                </asp:TextBox>
            </td>
            <td class="style3">
                <asp:Label ID="Label20" runat="server">State</asp:Label>
            </td>
            <td class="style4">
                <asp:TextBox ID="TextBoxMailState" runat="server" Columns="2" 
                    MaxLength="2" ToolTip="Mail State" ReadOnly="true">
                </asp:TextBox>
            </td>
            <td class="style5">
                <asp:Label ID="Label21" runat="server">Zip</asp:Label>
            </td>
            <td class="style6">
                <telerik:RadMaskedTextBox ID="RadMaskedTextBoxMailZip" runat="server" Columns="10" 
                    ToolTip="Mail Zip" ReadOnly="true" Mask="#####-####">
                </telerik:RadMaskedTextBox>
            </td>                             
        </tr>
        <tr>
            <td class="style1">
                <asp:Label ID="Label8" runat="server">Email Address</asp:Label>
            </td>
            <td class="style2">
                <asp:TextBox ID="TextBoxEmailAddress" runat="server" AutoCompleteType="Email" 
                    MaxLength="55" Columns="40" ReadOnly="true"  ToolTip="Email Address">
                </asp:TextBox>
            </td>
                 <td class="style1">
                <asp:Label ID="LblFacilityInFacilityYN" runat="server" Visible="false">Facility In Facility?</asp:Label>
            </td>
            <td class="style4">
                <asp:DropDownList ID="DdlFacilityInFacilityYN" runat="server" Enabled="false"
                    ToolTip="Facility in Facility Y/N?" ReadOnly="true" Visible="false">
                    <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                    <asp:ListItem Text="No" Value="N"></asp:ListItem>
                </asp:DropDownList>
            </td>  
             <td class="style1">
                <asp:Label ID="lblFacilityInFacilityDesc" runat="server" Visible="false">Name Of Facility</asp:Label>
            </td>
            <td class="style4">
                <asp:TextBox ID="TextBoxFacilityInFacility" runat="server" Columns="20" ReadOnly="true" Visible="false"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1">
                <asp:Label ID="lblAdministrator" runat="server">Administrator</asp:Label>
            </td>
            <td class="style2">
                <asp:TextBox ID="txtAdministrator" runat="server" Width="250px" ReadOnly="true" />
            </td>
            <td class="style3"></td>
            <td class="style4"></td>
            <td class="style5"></td>
            <td class="style6"></td>
        </tr>
        <tr>
            <td class="style1">
                <asp:Label ID="Label17" runat="server">Accrediting Body</asp:Label>
            </td>
            <td class="style2">
                <asp:DropDownList ID="listAccrdBody" runat="server" Enabled="false" Width="95%" />
            </td>
            <td class="style3">
                <asp:Label ID="Label33" runat="server">Accreditation Expiration Date</asp:Label>
            </td>
            <td class="style4">
                <telerik:RadDatePicker ID="RadDatePickerAED" runat="server" Enabled="false" 
                    ToolTip="Accreditation Expiration Date" MinDate="1900-01-01" Calendar-FastNavigationStep="12" >
                </telerik:RadDatePicker>
            </td>
            <td class="style5"></td>
            <td class="style6"></td>
        </tr>
        <tr>
            <td class="style1">
                <asp:Label ID="Label9" runat="server">Emergency Preparedness Reporting Required?</asp:Label>
            </td>
            <td class="style2">
                <asp:DropDownList ID="listEmergencyPrepReportRequired" runat="server" Enabled="false" >
                    <asp:ListItem Text="" Value=""></asp:ListItem>
                    <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                    <asp:ListItem Text="No" Value="N"></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="style3">
                <asp:Label ID="Label31" runat="server">Fiscal Intermediary</asp:Label>
            </td>
            <td colspan="2">
                <asp:DropDownList ID="listFiscalInt" runat="server" Enabled="false" Width="300px" />
            </td>
            <td class="style6"></td>
        </tr>
        <tr>
            <td class="style1">
                <asp:Label ID="Label14" runat="server">Parish</asp:Label>
            </td>
            <td class="style2">
                <asp:DropDownList ID="listParish" runat="server" Enabled="false" Width="60%" />
            </td>    
            <td class="style3">
                <asp:Label ID="Label10" runat="server">Region</asp:Label>
            </td>
            <td class="style4">
                <asp:DropDownList ID="listRegion" runat="server" Enabled="false" Width="95%" />
            </td>
            <td class="style5"></td>
            <td class="style6"></td>
        </tr>
        <tr>
            <td class="style1">
                <asp:Label ID="Label11" runat="server">Field Office</asp:Label>
            </td>
            <td class="style2">
                <asp:DropDownList ID="listFieldOffice" runat="server" Enabled="false" Width="60%" />
            </td>
            <td class="style3">
                <asp:Label ID="Label12" runat="server">Zone</asp:Label>
            </td>
            <td class="style4">
                <asp:DropDownList ID="listZone" runat="server" Enabled="false" Width="95%" />
            </td>
            <td class="style5"></td>
            <td class="style6"></td>
        </tr>
        <tr>
            <td class="style1">
                <asp:Label ID="Label15" runat="server">Facility Type</asp:Label>
            </td>
            <td class="style2">
                <asp:DropDownList ID="listTypeFacility" runat="server" Enabled="false" Width="60%" />
            </td>
            <td class="style3">
                <asp:Label ID="lblProvBased" runat="server">Provider Based</asp:Label>
            </td>
            <td class="style4">
                <telerik:RadComboBox ID="listProvBased" runat="server" Enabled="false" Width="55px" >
                    <Items>
                        <telerik:RadComboBoxItem Text="" Value="" />
                        <telerik:RadComboBoxItem Text="Yes" Value="Y" />
                        <telerik:RadComboBoxItem Text="No" Value="N" />
                    </Items>
                </telerik:RadComboBox>
            </td>      
            <td class="style5"></td>
            <td class="style6"></td>
        </tr>
        <tr>
            <td class="style1">
                <asp:Label ID="Label13" runat="server">Client Type</asp:Label>
            </td>
            <td class="style2">
                <asp:DropDownList ID="listClientType" runat="server" Enabled="false" Width="60%" />
            </td>
            <td class="style3">
                <asp:Label ID="Label16" runat="server">License Type</asp:Label>
            </td>
            <td class="style4">
                <asp:DropDownList ID="listLicenseType" runat="server" Enabled="false" Width="95%" />
            </td>
            <td class="style5"></td>
            <td class="style6"></td>
        </tr>
        <tr>
            <td class="style1">
                <asp:Label ID="LabelRelatedProvider" runat="server" Text="Related Provider #"></asp:Label>
            </td>
            <td class="style2">
                <asp:TextBox ID="TextBoxRelatedProvider" runat="server" Columns="20" Enabled="false"></asp:TextBox>
            </td>
            <td class="style3"></td>
            <td class="style4"></td>
            <td class="style5"></td>
            <td class="style6"></td>
        </tr>    
</table>

<table id="tblPopGender" class="formTable" cellspacing="1" cellpadding="1" border="0" runat="server">
    <tr>
        <td class="style1">Population Served:</td>
        <td class="style2">
            <asp:RadioButton ID="optPopSrvMale"   runat="server" Text="Male"   GroupName="PopServed" enabled="false"/>
            <asp:RadioButton ID="optPopSrvFemale" runat="server" Text="Female" GroupName="PopServed" enabled="false"/>
            <asp:RadioButton ID="optPopSrvBoth"   runat="server" Text="Both"   GroupName="PopServed" enabled="false"/>
        </td>
        <td class="style3">&nbsp;</td>
        <td class="style4">&nbsp;</td>
        <td class="style5">&nbsp;</td>
        <td class="style6">&nbsp;</td>
    </tr>
</table>

<table id="tblAgeRange" class="formTable" cellspacing="1" cellpadding="1" border="0" runat="server">
    <tr>
        <td class="style1">Admission Age Range:</td>
        <td class="style2">
            <telerik:RadNumericTextBox ID="txtAgeFrom" runat="server" MaxLength="3" Width="30" 
                     Type="Number" NumberFormat-GroupSeparator="" NumberFormat-DecimalDigits="0" Enabled="false"> 
                <NumberFormat DecimalDigits="0" GroupSeparator=""></NumberFormat>
            </telerik:RadNumericTextBox>
            Yrs.  To 
            <telerik:RadNumericTextBox ID="txtAgeTo" runat="server" MaxLength="3" Width="30" 
                     Type="Number" NumberFormat-GroupSeparator="" NumberFormat-DecimalDigits="0" Enabled="false"> 
                <NumberFormat DecimalDigits="0" GroupSeparator=""></NumberFormat>
            </telerik:RadNumericTextBox>
            Yrs.
        </td>
        <td class="style3">&nbsp;</td>
        <td class="style4">&nbsp;</td>
        <td class="style5">&nbsp;</td>
        <td class="style6">&nbsp;</td>
    </tr>
</table>

<table id="tblAC_ProviderType" class="formTable" cellspacing="1" cellpadding="1" border="0" runat="server">
    <tr>
        <td class="style1">Module/Type Facility</td>
        <td class="style2">
            <telerik:RadComboBox ID="listAC_TypeFacility" runat="server" Width="150px" Enabled="false">
            </telerik:RadComboBox>
        </td>        
        <td class="style3">&nbsp;</td>
        <td class="style4">&nbsp;</td>
        <td class="style5">&nbsp;</td>
        <td class="style6">&nbsp;</td>
    </tr>
</table>