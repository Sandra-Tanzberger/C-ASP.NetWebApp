<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OwnerEditForm.ascx.cs" Inherits="AppControl.OwnerEditForm" %>

<telerik:RadAjaxManagerProxy ID="ownEditRAMP" runat="server">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="txtZipCode">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="OwnTbl" LoadingPanelID="ownRALP" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>
<telerik:RadScriptBlock ID="OwnEditFrmRSB" runat="server">
    <script type="text/javascript">
        function ToggleCityStateZip(inCountry) {
            var tmpTxtOwnerCountry = document.getElementById("<%= txtOwnerCountry.ClientID %>");
            var tmpTxtOwnerState = document.getElementById("<%= txtOwnerState.ClientID %>");
            var tmpTxtOwnerCity = document.getElementById("<%= txtOwnerCity.ClientID %>");
            var tmpTxtOwnerZip = document.getElementById("<%= txtOwnerZip.ClientID %>");
            var tmpRadTxtZipCode = $find("<%= txtZipCode.ClientID %>");
            var tmpRadTxtZipExtn = $find("<%= txtZipExtn.ClientID %>");
            var tmpRadCbolistCity = $find("<%= listCity.ClientID %>");
            var tmpRadCbolistCounty = $find("<%= listCounty.ClientID %>");
            var tmpRadCbolistState = $find("<%= listState.ClientID %>");

            if (inCountry == "USA") {
                tmpTxtOwnerCountry.disabled = true;
                tmpTxtOwnerState.disabled = true;
                tmpTxtOwnerCity.disabled = true;
                tmpTxtOwnerZip.disabled = true;
                tmpRadTxtZipCode.enable();
                tmpRadTxtZipExtn.enable();
                ToggleRO_RadCombo(tmpRadCbolistCity, false);
                ToggleRO_RadCombo(tmpRadCbolistCounty, false);
                ToggleRO_RadCombo(tmpRadCbolistState, false);
            }
            else {
                tmpTxtOwnerCountry.removeAttribute("disabled");
                tmpTxtOwnerState.removeAttribute("disabled");
                tmpTxtOwnerCity.removeAttribute("disabled");
                tmpTxtOwnerZip.removeAttribute("disabled");
                tmpRadTxtZipCode.disable();
                tmpRadTxtZipExtn.disable();
                ToggleRO_RadCombo(tmpRadCbolistCity, true);
                ToggleRO_RadCombo(tmpRadCbolistCounty, true);
                ToggleRO_RadCombo(tmpRadCbolistState, true);
            } 
        }
    </script>
</telerik:RadScriptBlock>
<div >
<telerik:RadAjaxLoadingPanel ID="ownRALP" runat="server" />
<asp:Table CssClass="formTable" ID="OwnTbl" BorderWidth="0" GridLines="none" Width="98%" runat="server">
    <asp:TableRow ID="tblRwEntityCorp" runat="server" >
        <asp:TableCell>
            <asp:Label ID="lblOwnerNameOfEntity" runat="server" AssociatedControlID="txtOwnerNameOfEntity" Text="Name of Entity: " />
        </asp:TableCell><asp:TableCell ColumnSpan="2">
            <asp:TextBox ID="txtOwnerNameOfEntity" runat="server" Width="300px" MaxLength="60" Text=""></asp:TextBox>
        </asp:TableCell><asp:TableCell ColumnSpan="2">
            <asp:Label ID="lblOwnerEIN" runat="server" AssociatedControlID="txtOwnerEIN" Text="EIN: "/>
            <telerik:RadMaskedTextBox ID="txtOwnerEIN" runat="server" MaxLength="20" Mask="####################"></telerik:RadMaskedTextBox>
        </asp:TableCell></asp:TableRow><asp:TableRow>
        <asp:TableCell>
            <asp:Label ID="lblOwnerDBA" runat="server" AssociatedControlID="txtOwnerDBA" Text="DBA: " />
        </asp:TableCell><asp:TableCell ColumnSpan="2">
            <asp:TextBox ID="txtOwnerDBA" runat="server" Width="300px" MaxLength="68" Text=""></asp:TextBox>
        </asp:TableCell><asp:TableCell ColumnSpan="2">
            <asp:Label ID="lblOwnerPhone" runat="server" AssociatedControlID="txtOwnerPhone" Text="Telephone: "/>
            <telerik:RadMaskedTextBox ID="txtOwnerPhone" runat="server" Mask="(###) ###-####" Width="100px" />
        </asp:TableCell></asp:TableRow><asp:TableRow>
        <asp:TableCell>
            <asp:Label ID="lblOwnerStreetAddr" runat="server" AssociatedControlID="txtOwnerStreetAddr" Text="Street Address: " />
        </asp:TableCell><asp:TableCell ColumnSpan="2">
            <asp:TextBox ID="txtOwnerStreetAddr" runat="server" Width="300px" MaxLength="100" Text=""></asp:TextBox>
        </asp:TableCell><asp:TableCell ColumnSpan="2">
            <asp:Label ID="lblOwnerFax" runat="server" AssociatedControlID="txtOwnerFax" Text="Fax: "/>
            <telerik:RadMaskedTextBox ID="txtOwnerFax" runat="server" Mask="(###) ###-####" Width="100px" />
        </asp:TableCell></asp:TableRow><asp:TableRow>
        <asp:TableCell>
            <asp:Label ID="lblCountrySelect" runat="server" Text="Country:" />
        </asp:TableCell><asp:TableCell ColumnSpan="2">
            <asp:RadioButton ID="optCountryUS" runat="server" Text="US" GroupName="grpCountry" Checked="true" AutoPostBack="false" onClick="ToggleCityStateZip('USA');" />
        </asp:TableCell><asp:TableCell ColumnSpan="2">
            <asp:Label ID="lblPercentOwnership" runat="server" AssociatedControlID="txtPercentOwnership" Text="% Ownership: "/>
            <telerik:RadNumericTextBox ID="txtPercentOwnership" runat="server" Width="100" Type="Number" NumberFormat-DecimalDigits="0" MaxLength="3" MaxValue="100" MinValue="0" />
        </asp:TableCell></asp:TableRow><asp:TableRow>
        <asp:TableCell>
            &nbsp;
        </asp:TableCell><asp:TableCell>
             <asp:Label ID="lblMailZip" runat="server" Text="Zip" />
        </asp:TableCell><asp:TableCell>
            <asp:Label ID="lblMailCity" runat="server" Text="City" />
        </asp:TableCell><asp:TableCell>
            <asp:Label ID="lblOwnerCounty" runat="server" Text="Parish/County"/>
        </asp:TableCell><asp:TableCell>
            <asp:Label ID="lblMailState" runat="server" Text="State" />
        </asp:TableCell></asp:TableRow><asp:TableRow>
        <asp:TableCell>
            &nbsp;
        </asp:TableCell><asp:TableCell>
            <telerik:RadMaskedTextBox ID="txtZipCode" Mask = "#####" runat="server" AutoPostBack="true" OnTextChanged="txtZipCode_TextChanged" Width="55px" MaxLength="5" NumberFormat-DecimalDigits="0" NumberFormat-GroupSeparator="" ></telerik:RadMaskedTextBox>                
            <asp:Literal ID="LiteralZip" runat="server" Text="-"></asp:Literal>
            <telerik:RadNumericTextBox ID="txtZipExtn" runat="server" Width="45px" MaxLength="4" NumberFormat-DecimalDigits="0" NumberFormat-GroupSeparator="" ></telerik:RadNumericTextBox>                
            <asp:Label ID="litInvlidZip" runat="server" Text="Zipcode not found" ForeColor="Red" Visible="false" /><br />
        </asp:TableCell><asp:TableCell>
            <telerik:RadComboBox ID="listCity" ZIndex="9999" runat="server" AutoPostBack="false" Width="140px" Filter="StartsWith" AllowCustomText="false" />
        </asp:TableCell><asp:TableCell>
            <telerik:RadComboBox ID="listCounty" ZIndex="9999" runat="server" Width="140px" Filter="StartsWith" AllowCustomText="false" />
        </asp:TableCell><asp:TableCell>
            <telerik:RadComboBox ID="listState" ZIndex="9999" runat="server" AutoPostBack="false" Width="140px" Filter="StartsWith" AllowCustomText="false" />
        </asp:TableCell></asp:TableRow><asp:TableRow>
        <asp:TableCell>
            &nbsp;
        </asp:TableCell><asp:TableCell ColumnSpan="4">
            <asp:RadioButton ID="optCountryOther" runat="server" Text="Other" GroupName="grpCountry" AutoPostBack="false" onClick="ToggleCityStateZip('OTHER');" />
        </asp:TableCell></asp:TableRow><asp:TableRow>
        <asp:TableCell>
            &nbsp;
        </asp:TableCell><asp:TableCell>
            <asp:Label ID="lblOwnerCountry" runat="server" Text="Country: "/>
        </asp:TableCell><asp:TableCell>
            <asp:Label ID="lblOwnerState" runat="server" AssociatedControlID="txtOwnerState" Text="State: " />
        </asp:TableCell><asp:TableCell>
            <asp:Label ID="lblOwnerCity" runat="server" AssociatedControlID="txtOwnerCity" Text="City: " />
        </asp:TableCell><asp:TableCell>
            <asp:Label ID="lblOwnerZip" runat="server" AssociatedControlID="txtOwnerZip" Text="Zip: " />
        </asp:TableCell></asp:TableRow><asp:TableRow>
        <asp:TableCell>
            &nbsp;
        </asp:TableCell><asp:TableCell>
            <asp:TextBox ID="txtOwnerCountry" runat="server" MaxLength="25" Width="135px" />
        </asp:TableCell><asp:TableCell>
            <asp:TextBox ID="txtOwnerState" runat="server" MaxLength="20" Text="" Width="135px"></asp:TextBox>
        </asp:TableCell><asp:TableCell>
            <asp:TextBox ID="txtOwnerCity" runat="server" MaxLength="20" Text="" Width="135px"></asp:TextBox>
        </asp:TableCell><asp:TableCell>
            <asp:TextBox ID="txtOwnerZip" runat="server" MaxLength="10" Text="" Width="135px"></asp:TextBox>
        </asp:TableCell></asp:TableRow><asp:TableRow>
        <asp:TableCell ColumnSpan="5">
            <asp:button id="btnUpdate" text="Update" runat="server" CommandName="Update" Visible="false" />
            <asp:button id="btnInsert" text="Save" runat="server" CommandName="PerformInsert" Visible="false"/>
            &nbsp;
            <asp:button id="btnCancel" text="Cancel" runat="server" CommandName="Cancel" Visible="false" causesvalidation="False" ></asp:button>
        </asp:TableCell></asp:TableRow></asp:Table></div>