<%@ Control Language="C#" EnableViewState="true" AutoEventWireup="True" CodeBehind="AplctnProvider.ascx.cs" Inherits="AppControl.AplctnProvider" %>

<telerik:RadAjaxManagerProxy ID="LicAppAJMP" runat="server">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="listProviderState" >
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="FacTableMain" LoadingPanelID="AplctnPRvdrRLP" />
            </UpdatedControls>
        </telerik:AjaxSetting>
         <telerik:AjaxSetting AjaxControlID="listProviderParish" >
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="FacTableMain" LoadingPanelID="AplctnPRvdrRLP" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="listProviderCity" >
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="FacTableMain" LoadingPanelID="AplctnPRvdrRLP" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="listProviderParish" >
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="FacTableMain" LoadingPanelID="AplctnPRvdRLP" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="listProviderZip" >
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="FacTableMain" LoadingPanelID="AplctnPRvdrRLP" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="OverrideLicenseNum" >
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="FacTableMain" LoadingPanelID="AplctnPRvdrRLP" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="listMailState" >
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="FacTableMailAddr" LoadingPanelID="AplctnPRvdrRLP" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="listMailCity" >
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="FacTableMailAddr" LoadingPanelID="AplctnPRvdrRLP" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="DdlFacilityInFacilityYN">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="lblFacilityInFacilityDesc" LoadingPanelID="AplctnPRvdrRLP" />
                <telerik:AjaxUpdatedControl ControlID="TextBoxFacilityInFacility" LoadingPanelID="AplctnPRvdrRLP" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>
<telerik:RadScriptBlock ID="AppProvRSB" runat="server">
    <script type="text/javascript">
        function keyPress(sender, args) {
            if (!sender._isNormalChar(args.get_domEvent())) {
                return;
            }

            var maxWholeDigits = 5;
            var maxDecimalDigits = 2;
            var separator = sender.get_numberFormat().DecimalSeparator;
            var regExpStr = "^\\d{0," + maxWholeDigits + "}(\\" + separator + "\\d{0," + maxDecimalDigits + "})?$";
            var regex = new RegExp(regExpStr);  //this should give "/^\d{0,5}(\.\d{0,2})?$/"

            var caret = sender.get_caretPosition();
            var value = sender._textBoxElement.value;
            var char = args.get_keyCharacter()

            if (caret === value.length) {
                value = value + char;
            }
            else {
                //place the new char to the correct position based on caret location
                value = value.substr(0, caret) + char + value.substr(caret);
            }

            if (!regex.test(value)) {
                args.set_cancel(true);
            }

        }

        function ToggleES_TypeFacilityChk(inCtrlKey) {
            var chkProvBased = document.getElementById("<%= chkES_ProviderBased.ClientID %>");
            var chkFreeStand = document.getElementById("<%= chkES_FreeStanding.ClientID %>");
            var txtRelProvNum = document.getElementById("<%= txtES_RelProvNum.ClientID %>");

            if (inCtrlKey == 'PROVBASED') {
                chkFreeStand.checked = false;
                txtRelProvNum.disabled = false;
            }
            else {
                chkProvBased.checked = false;
                txtRelProvNum.disabled = true;
            }
        }

        function InitES_TypeFacilityChk() {
            var chkProvBased = document.getElementById("<%= chkES_ProviderBased.ClientID %>");
            var chkFreeStand = document.getElementById("<%= chkES_FreeStanding.ClientID %>");

            if (chkProvBased.checked){
                ToggleES_TypeFacilityChk('PROVBASED');
            }
            else{ 
                ToggleES_TypeFacilityChk('FREESTAND');
            }                
        }

        function ToggleRH_TypeFacilityChk(inCtrlKey) {
            var chkMobile = document.getElementById("<%= chkRH_Mobile.ClientID %>");
            var chkStationary = document.getElementById("<%= chkRH_Stationary.ClientID %>");
            var chkFreeStand = document.getElementById("<%= chkRH_FreeStand.ClientID %>");
            var chkProvBased = document.getElementById("<%= chkRH_ProvBased.ClientID %>");
            var txtRH_RelProvNum = document.getElementById("<%= txtRH_RelProvNum.ClientID %>");
            var txtRH_RelProvName = document.getElementById("<%= txtRH_RelProvName.ClientID %>");

            switch ( inCtrlKey )
            {
                case 'MOBILE':
                    chkStationary.checked = false;
                    break;
                case 'STATIONARY':
                    chkMobile.checked = false;
                    break;
                case 'FREESTAND':
                    chkProvBased.checked = false;
                    txtRH_RelProvNum.disabled = true;
                    txtRH_RelProvName.disabled = true;
                    break;
                case 'PROVBASED':
                    chkFreeStand.checked = false;
                    txtRH_RelProvNum.disabled = false;
                    txtRH_RelProvName.disabled = false;
                    break;
            }
        }

        function ToggleAS_LocationChk(inCtrlKey) {
            var chkHospBased = document.getElementById("<%= chkAS_HospitalBased.ClientID %>");
            var chkFreeStand = document.getElementById("<%= chkAS_FreeStanding.ClientID %>");

            switch ( inCtrlKey )
            {
                case 'HOSPBASED':
                    chkFreeStand.checked = false;
                    break;
                case 'FREESTAND':
                    chkHospBased.checked = false;
                    break;
            }
        }

        function InitRH_TypeFacilityChk() {
            var chkMobile = document.getElementById("<%= chkRH_Mobile.ClientID %>");
            var chkStationary = document.getElementById("<%= chkRH_Stationary.ClientID %>");
            var chkFreeStand = document.getElementById("<%= chkRH_FreeStand.ClientID %>");
            var chkProvBased = document.getElementById("<%= chkRH_ProvBased.ClientID %>");
            var txtRH_RelProvNum = document.getElementById("<%= txtRH_RelProvNum.ClientID %>");
            var txtRH_RelProvName = document.getElementById("<%= txtRH_RelProvName.ClientID %>");

            if (chkMobile.checked) {
                ToggleRH_TypeFacilityChk('MOBILE');
            }
            else if (chkStationary.checked) {
                ToggleRH_TypeFacilityChk('STATIONARY');
            }

            if (chkFreeStand.checked) {
                ToggleRH_TypeFacilityChk('FREESTAND');
            }
            else if (chkProvBased.checked){
                ToggleRH_TypeFacilityChk('PROVBASED');
            }
        }

        function onMultiFacAdminClick() {
            var yes = document.getElementById("<%=radMultiFacAdminYes.ClientID%>");
            var otherFacName = document.getElementById("<%=txtNHAdminOtherFacName.ClientID%>");
            var radSingleStory = document.getElementById("<%=radSingleStory.ClientID%>");
            var radMultiStory = document.getElementById("<%=radMultiStory.ClientID%>");
            
            if (yes.checked) {
                otherFacName.disabled = false;
                radSingleStory.checked = true;
                radMultiStory.disabled = true;
            }
            else {
                otherFacName.disabled = true;
                otherFacName.value = "";
                otherFacName.vi
                radMultiStory.disabled = false;
            }
        }

    </script>
</telerik:RadScriptBlock>
<telerik:RadAjaxLoadingPanel ID="AplctnPRvdrRLP" runat="server" />
<div id="ErrorText" runat="server" visible="false" style="overflow:visible;border: solid 1px Red;color:Red;width: 100%;">
</div>
<asp:Table ID="FacTableMain" CssClass="formTable" CellSpacing="0" BorderWidth="0" GridLines="None" runat="server">
    <asp:TableRow>
        <asp:TableCell HorizontalAlign="Right">
            <asp:Label ID="lblProviderType" runat="server" >Provider Type: </asp:Label>
        </asp:TableCell>
        <asp:TableCell ColumnSpan="3">
            <asp:TextBox ID="ProviderType" runat="server" Width="300px" MaxLength="50" Text="" ReadOnly="true" BackColor="LightGray"></asp:TextBox>
        </asp:TableCell>
        <asp:TableCell HorizontalAlign="Right">
            <asp:Label ID="lblLicenseNum" runat="server" >License #: </asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <asp:TextBox ID="LicenseNum" runat="server" Width="100px" MaxLength="20" ReadOnly="true" BackColor="LightGray" Text=""></asp:TextBox>
            <asp:TextBox ID="txtRHC" runat="server" Text="RHC" Visible="false" Width="30px" />
            <asp:Label ID="lblLicHyphen" runat="server" Text="-" Visible="false" />
            <asp:TextBox ID="LicenseNumOffsitePostFix" runat="server" Width="45px" MaxLength="8" Text="" Visible="false" />
        </asp:TableCell>
        <asp:TableCell>  
            <asp:Checkbox ID="OverrideLicenseNum" runat="server" Visible="false" Text="License # Overide" AutoPostBack="true" OnCheckedChanged="OverrideLicenseNum_CheckedChanged"/>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell HorizontalAlign="Right">
            <asp:Label ID="lblFacName" runat="server" >Name (DBA): </asp:Label>
        </asp:TableCell>
        <asp:TableCell ColumnSpan="3">
            <asp:TextBox ID="FacilityName" runat="server" Width="300px" MaxLength="60" Text=""></asp:TextBox>
        </asp:TableCell>
        <asp:TableCell HorizontalAlign="Right">
            <asp:Label ID="lblStateID" runat="server" >State ID: </asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <asp:TextBox ID="StateID" runat="server" Width="90px" MaxLength="10" ReadOnly="true" BackColor="LightGray" Text=""></asp:TextBox>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell HorizontalAlign="Right">
            <asp:Label ID="lblStreetAddr" runat="server">Street Address: </asp:Label>
        </asp:TableCell>
        <asp:TableCell ColumnSpan="3">
            <asp:TextBox ID="FacilityGeoStreetAddress" runat="server" Width="300px" MaxLength="100" Text="" ></asp:TextBox>
        </asp:TableCell>
        <asp:TableCell HorizontalAlign="Right">
            <asp:Label ID="lblCurLicIssueDt" runat="server" >Current License Issue Date: </asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <telerik:RadDatePicker ID="txtCurLicIssueDt" runat="server" Width="100" DateInput-DateFormat="MM/dd/yyyy" 
                                    MinDate="01/01/1900" ZIndex="9999"  Calendar-FastNavigationStep="12" />
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
         <asp:TableCell HorizontalAlign="Right" Width="150px" >
            <asp:Label ID="lblState" runat="server">State: </asp:Label>
        </asp:TableCell>
        <asp:TableCell Width="150px" >
            <telerik:RadComboBox ID="listProviderState" runat="server" Width="150" AutoPostBack="true" 
                        Filter="StartsWith" AllowCustomText="false" 
                        OnSelectedIndexChanged="listProviderState_SelectedIndexChanged" />
        </asp:TableCell>
        <asp:TableCell HorizontalAlign="Right" Width="150px" >
            <asp:Label ID="lblCity" runat="server">City: </asp:Label>
        </asp:TableCell>
        <asp:TableCell Width="150px" >
            <telerik:RadComboBox ID="listProviderCity" runat="server" Width="150" AutoPostBack="true" 
                        Filter="StartsWith" AllowCustomText="false" 
                        OnSelectedIndexChanged="listProviderCity_SelectedIndexChanged" />
        </asp:TableCell>
        <asp:TableCell HorizontalAlign="Right">
            <asp:Label ID="lblLicenseExpirationDate" runat="server" Text="License Expiration Date:" Visible="false" ></asp:Label>
        </asp:TableCell>
        <asp:TableCell>
             <telerik:RadDatePicker ID="dpLicenseExpirationDate" runat="server" Width="100" DateInput-DateFormat="MM/dd/yyyy" 
                                    MinDate="01/01/1900" ZIndex="9999"  Calendar-FastNavigationStep="12" Visible="false" Enabled="false"/>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell HorizontalAlign="Right" Width="60px">
            <asp:Label ID="lblParish" runat="server">Parish: </asp:Label>
        </asp:TableCell>
        <asp:TableCell Width="150px">
             <telerik:RadComboBox ID="listProviderParish" runat="server" Width="150" AutoPostBack="true" 
                        Filter="StartsWith" AllowCustomText="false" 
                        OnSelectedIndexChanged="listProviderParish_SelectedIndexChanged" />
        </asp:TableCell>
        <asp:TableCell HorizontalAlign="Right" Width="145px">
            <asp:Label ID="lblZip" runat="server">Zip: </asp:Label>
        </asp:TableCell>
         <asp:TableCell Width="210px">
            <telerik:RadComboBox ID="listProviderZip" runat="server" Width="75px" Filter="StartsWith" AllowCustomText="false" />&nbsp;-&nbsp;
            <telerik:RadNumericTextBox ID="ProviderZipExtn" runat="server" Width="55px" MaxLength="4" NumberFormat-DecimalDigits="0" NumberFormat-GroupSeparator="" SelectionOnFocus="CaretToBeginning" /> 
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell ColumnSpan="4">
            <asp:Table runat="server" ID="RegionFieldOfficeOverride">
                <asp:TableRow>
                    <asp:TableCell HorizontalAlign="Left" Text="Select to override Region and Field Office."></asp:TableCell>
                    <asp:TableCell HorizontalAlign="Left"><asp:CheckBox ID="chkRegionFieldOfficeOverride" runat="server" /></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell HorizontalAlign="Right" Width="">
                        <asp:Label ID="lblDHHRegionLabel" runat="server">DHH Admin Region: </asp:Label>
                    </asp:TableCell>
                    <asp:TableCell HorizontalAlign="Right" Width="">
                        <asp:DropDownList runat="server" ID="listDHHAdminRegion"></asp:DropDownList>
                    </asp:TableCell>
                </asp:TableRow>
                 <asp:TableRow>
                    <asp:TableCell HorizontalAlign="Right" Width="">
                        <asp:Label ID="lblHSSFieldOfficeLabel" runat="server">HSS Field Office: </asp:Label>
                    </asp:TableCell>
                    <asp:TableCell HorizontalAlign="Right" Width="">
                        <asp:DropDownList runat="server" ID="listHSSFieldOffice"></asp:DropDownList>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </asp:TableCell>
             

    </asp:TableRow>

    <asp:TableRow>
        <asp:TableCell HorizontalAlign="Right">
            <asp:Label ID="lblProvStatus" runat="server">Status:</asp:Label>
        </asp:TableCell>
        <asp:TableCell ColumnSpan="3">
            <telerik:RadComboBox ID="listProvStatus" runat="server" Width="350" Filter="StartsWith" AllowCustomText="false" Enabled="false" />
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell HorizontalAlign="Right">
            <asp:Label ID="lblProvStatusDate" runat="server">Status Date:</asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <telerik:RadDatePicker ID="txtProvStatusDate" runat="server" Width="100" DateInput-DateFormat="MM/dd/yyyy" 
                MinDate="01/01/1900" ZIndex="9999" Calendar-FastNavigationStep="12" Enabled="false" />
        </asp:TableCell>
        <asp:TableCell HorizontalAlign="Right">
            <asp:Label ID="lblProvClosedDate" runat="server">Closed:</asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <telerik:RadDatePicker ID="txtProvClosedDate" runat="server" Width="100" DateInput-DateFormat="MM/dd/yyyy" 
                MinDate="01/01/1900" ZIndex="9999" Calendar-FastNavigationStep="12" Enabled="false" />
        </asp:TableCell>
    </asp:TableRow>

    <asp:TableRow>
        <asp:TableCell HorizontalAlign="Right">
            <asp:Label ID="lblBranchStatus" runat="server">Status:</asp:Label>
        </asp:TableCell>
        <asp:TableCell ColumnSpan="3">
            <telerik:RadComboBox ID="listBranchStatus" runat="server" Width="350" Filter="StartsWith" AllowCustomText="false" Enabled="false" />
        </asp:TableCell>
         <asp:TableCell HorizontalAlign="Right">
            <asp:Label ID="lblOffSiteCurrentLicenseIssueDate" runat="server" Text="Off-Site Current License Issue Date:" HorizontalAlign="Right" Visible="false" ></asp:Label>
        </asp:TableCell>
        <asp:TableCell>
             <telerik:RadDatePicker ID="dpOffSiteCurrentLicenseIssueDate" runat="server" Width="100" DateInput-DateFormat="MM/dd/yyyy" 
                                    MinDate="01/01/1900" ZIndex="9999"  Calendar-FastNavigationStep="12" Visible="false" />
        </asp:TableCell>
        <asp:TableCell>
             <asp:CheckBox ID="chkOffSiteCurrentLicenseIssueDate" runat="server" Text="Override Off-Site Current License Issue Date Rule" Font-Size="10pt" Visible="false" />
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell HorizontalAlign="Right" Width="150px" >
            <asp:Label ID="lblBranchOpenDate" runat="server">Opened:</asp:Label>
        </asp:TableCell>
        <asp:TableCell Width="150px" >
            <telerik:RadDatePicker ID="txtBranchOpenDate" runat="server" Width="100" DateInput-DateFormat="MM/dd/yyyy" 
                MinDate="01/01/1900" ZIndex="9999" Calendar-FastNavigationStep="12" Enabled="false" />
        </asp:TableCell>
        <asp:TableCell HorizontalAlign="Right" Width="60px">
            <asp:Label ID="lblBranchClosedDate" runat="server">Closed:</asp:Label>
        </asp:TableCell>
        <asp:TableCell Width="150px">
            <telerik:RadDatePicker ID="txtBranchClosedDate" runat="server" Width="100" DateInput-DateFormat="MM/dd/yyyy" 
                MinDate="01/01/1900" ZIndex="9999" Calendar-FastNavigationStep="12" Enabled="false"/>
        </asp:TableCell>
         <asp:TableCell HorizontalAlign="Right">
            <asp:Label ID="lblOffSiteLicenseEffectiveDate" runat="server" Text="Off-Site License Effective Date:" HorizontalAlign="Right" Visible="false"></asp:Label>
        </asp:TableCell>
        <asp:TableCell>
             <telerik:RadDatePicker ID="dpOffSiteLicenseEffectiveDate" runat="server" Width="100" DateInput-DateFormat="MM/dd/yyyy" 
                                    MinDate="01/01/1900" ZIndex="9999"  Calendar-FastNavigationStep="12" Visible="false" />
        </asp:TableCell>
         <asp:TableCell>
             <asp:CheckBox ID="chkOffSiteLicenseEffectiveDate" runat="server" Text="Override Off-Site License Effective Date Rule" Font-Size="10pt" Visible="false"/>
        </asp:TableCell>
    </asp:TableRow>
     <asp:TableRow>
       
        <asp:TableCell HorizontalAlign="Right">
            <asp:Label ID="lblOffSiteOriginalLicenseIssueDate" runat="server" Text="Off-Site Original License Issue Date:" HorizontalAlign="Right" Visible="false"></asp:Label>
        </asp:TableCell>
        <asp:TableCell>
             <telerik:RadDatePicker ID="dpOffsiteOriginalLicenseIssueDate" runat="server" Width="100" DateInput-DateFormat="MM/dd/yyyy" 
                                    MinDate="01/01/1900" ZIndex="9999"  Calendar-FastNavigationStep="12" Visible="false" />
        </asp:TableCell>
        <asp:TableCell>
             <asp:CheckBox ID="chkOffSiteOriginalLicenseIssueDate" runat="server" Text="Override Off-Site Original License Issue Date Rule" Font-Size="10pt" Visible="false"/>
        </asp:TableCell>
    </asp:TableRow>
    
     <asp:TableRow>
        <asp:TableCell HorizontalAlign="Right">
            <asp:Label ID="lblBranchID" runat="server" Text="Branch ID:" HorizontalAlign="Right" Visible="false"></asp:Label>
         </asp:TableCell>
         <asp:TableCell><asp:TextBox ID="txtBranchID" runat="server" HorizontalAlign="Right" Visible="false"></asp:TextBox></asp:TableCell>
         <asp:TableCell>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp</asp:TableCell>
        <asp:TableCell>
              <asp:Label ID="lblMedicareBranchID" runat="server" Text="Medicare Branch ID:" HorizontalAlign="Right" Visible="false"></asp:Label>
        </asp:TableCell>
         <asp:TableCell><asp:TextBox ID="txtMedicareBranchID" runat="server" HorizontalAlign="Right" Visible="false"></asp:TextBox></asp:TableCell>
    </asp:TableRow>
</asp:Table>
<div id="DivMailAddrHeader" class="formTableSectionDiv" runat="server">
    Mailing Address
    <% 
        //<asp:CheckBox ID="chkSameAsPhysical" CssClass="formTableSectionDivChk" runat="server" Text="Same as Above" TextAlign="Right" />
    %>
</div>
<asp:Table ID="FacTableMailAddr" CssClass="formTable" CellSpacing="0" BorderWidth="0" GridLines="None"  runat="server">
    <asp:TableRow>
        <asp:TableCell HorizontalAlign="Right">
            <asp:Label ID="lblMailStreetPO" runat="server">Street or P.O. Box: </asp:Label>
        </asp:TableCell>
        <asp:TableCell ColumnSpan="3">
            <asp:TextBox ID="MailStreetPOBox" runat="server" Width="300px" MaxLength="100"></asp:TextBox>
        </asp:TableCell>
        <asp:TableCell ColumnSpan="2">
            &nbsp;
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell HorizontalAlign="Right" Width="150px">
            <asp:Label ID="lblMailState" runat="server">State: </asp:Label>
        </asp:TableCell>
        <asp:TableCell Width="150px">
            <telerik:RadComboBox ID="listMailState" runat="server" Width="150" AutoPostBack="true" Filter="StartsWith" AllowCustomText="false" OnSelectedIndexChanged="listMailState_SelectedIndexChanged"/>
         </asp:TableCell>
        <asp:TableCell HorizontalAlign="Right" Width="40px">
            <asp:Label ID="lblMailCity" runat="server">City: </asp:Label>
        </asp:TableCell>
        <asp:TableCell Width="150px">
             <telerik:RadComboBox ID="listMailCity" runat="server" Width="150" AutoPostBack="true" Filter="StartsWith" AllowCustomText="false" OnSelectedIndexChanged="listMailCity_SelectedIndexChanged"/>
        </asp:TableCell>
        <asp:TableCell HorizontalAlign="Right" Width="70px">
            <asp:Label ID="lblMailZip" runat="server">Zip: </asp:Label>
         </asp:TableCell>
        <asp:TableCell Width="150px">
            <telerik:RadComboBox ID="listMailZip" runat="server" Width="75px" Filter="StartsWith" AllowCustomText="false" />&nbsp;-&nbsp;
            <telerik:RadNumericTextBox ID="MailZipExtn" runat="server" Width="45px" MaxLength="4" NumberFormat-DecimalDigits="0" NumberFormat-GroupSeparator="" ></telerik:RadNumericTextBox>            
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>
<div id="divAdministration" runat="server">
    <div id="DivAdministrativeHeader" class="formTableSectionDiv" runat="server">
        Administrative
    </div>
    <asp:Table ID="FacTableAdministration" CssClass="formTable" CellSpacing="0" BorderWidth="0" runat="server">
        <asp:TableRow>
            <asp:TableCell VerticalAlign="Bottom" Width="150" HorizontalAlign="Right">
                <asp:Label ID="lblAdminPhone" runat="server">Facility Main Phone: </asp:Label>
            </asp:TableCell>
            <asp:TableCell VerticalAlign="Bottom" Width="100" HorizontalAlign="Left">
                (not voice mail)<br />
                <telerik:RadMaskedTextBox ID="FacilityAdministrationPhone" runat="server" Mask="(###) ###-####" Width="100" SelectionOnFocus="CaretToBeginning" />
            </asp:TableCell>
            <asp:TableCell VerticalAlign="Bottom" Width="130" HorizontalAlign="Right">
                <asp:Label ID="lblAdminFax" runat="server">Fax Number: </asp:Label>
            </asp:TableCell>
            <asp:TableCell VerticalAlign="Bottom" Width="100" HorizontalAlign="Left">
                <telerik:RadMaskedTextBox ID="FacilityAdministrationFax" runat="server" Mask="(###) ###-####" Width="100" SelectionOnFocus="CaretToBeginning" />
            </asp:TableCell>
             <asp:TableCell VerticalAlign="Bottom" Width="130" HorizontalAlign="Right">
                <asp:Label ID="lblEmergencyPhone" runat="server" Visible="false">Emergency Phone: </asp:Label>
            </asp:TableCell>
            <asp:TableCell VerticalAlign="Bottom" Width="100" HorizontalAlign="Left">
                <telerik:RadMaskedTextBox ID="RadMaskedTextBoxEmergencyPhone" runat="server" Mask="(###) ###-####" Width="100" SelectionOnFocus="CaretToBeginning" Visible="false"/>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell VerticalAlign="Bottom" HorizontalAlign="Right">
                <asp:Label ID="lblAdminEmail" runat="server">Facility Email Address: </asp:Label>
             </asp:TableCell>
            <asp:TableCell VerticalAlign="Bottom" ColumnSpan="3">
                <asp:TextBox ID="txtAdminEmail" runat="server" MaxLength="55" Width="200" Text=""></asp:TextBox>
            </asp:TableCell>
           <asp:TableCell VerticalAlign="Bottom" ColumnSpan="3">
                <asp:Label ID="LblFacilityInFacilityYN" runat="server" Visible="false">Facility In Facility?</asp:Label>
            </asp:TableCell>
            <asp:TableCell VerticalAlign="Bottom">
                <telerik:RadComboBox ID="DdlFacilityInFacilityYN" runat="server"
                    ToolTip="Facility in Facility Y/N?" Visible="false" AutoPostBack="true" AllowCustomText="false" OnSelectedIndexChanged="FacilityInFacility_SelectedIndexChanged">
                    <Items>
                        <telerik:RadComboBoxItem Text="Yes" Value="Y" />
                        <telerik:RadComboBoxItem Text="No" Value="N" Selected="true" />
                    </Items>
                </telerik:RadComboBox>
            </asp:TableCell>  
            <asp:TableCell VerticalAlign="Bottom">
                <asp:Label ID="lblFacilityInFacilityDesc" runat="server" Visible="false">State ID Of Facility</asp:Label>
            </asp:TableCell>
            <asp:TableCell VerticalAlign="Bottom">
                <asp:TextBox ID="TextBoxFacilityInFacility" runat="server" Columns="20" Visible="false"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</div>
<div id="DivFIHeader" class="formTableSectionDiv" runat="server">
    Fiscal Intermediary
</div>
<asp:Table ID="FacTableFI" CssClass="formTable" BorderWidth="0" runat="server">
    <asp:TableRow>
        <asp:TableCell HorizontalAlign="Right" Width="150px">
            <asp:Label ID="lblFiscalInt" runat="server" >Fiscal Intermediary: </asp:Label>
        </asp:TableCell>
        <asp:TableCell HorizontalAlign="Left" Width="400px">
            <telerik:RadComboBox ID="listFiscalInt" runat="server" Filter="StartsWith" Width="400" AllowCustomText="false" />
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>        
        <asp:TableCell HorizontalAlign="Right">
            <asp:Label ID="lblFiscalYrEnd" runat="server" >Cost Report Year End ('MM/DD'): </asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <telerik:RadMaskedTextBox ID="txtFiscalYrEnd" runat="server" Mask="##/##" Width="40" SelectionOnFocus="CaretToBeginning" />
<%--            <telerik:RadDatePicker ID="dtFiscalYrEnd" runat="server" Width="70" DateInput-DateFormat="MM/yy"
                                       MinDate="01/01/0001" MaxDate="01/01/2211" DateInput-ClientEvents-OnKeyPress="" />--%>
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>
<br />
<div id="DivAccred" class="formTableSectionDiv" runat="server">
    Accreditation
</div>
<asp:Table ID="FacTableAccredit" CssClass="formTable" BorderWidth="0" runat="server">
    <asp:TableRow>
        <asp:TableCell HorizontalAlign="Right" Width="150px">
            <asp:Label ID="lblAccrdBody" runat="server">Accrediting Organization: </asp:Label>
        </asp:TableCell>
        <asp:TableCell HorizontalAlign="Left" ColumnSpan="2" Width="700px">
            <telerik:RadComboBox ID="listAccrdBody" runat="server" Filter="StartsWith" AllowCustomText="false" Width="700px" /><br />
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell HorizontalAlign="Right">
            <asp:Label ID="lblAccrdExpDt" runat="server" >Accreditation Expiration: </asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <telerik:RadDatePicker ID="calAccrdExpDt" runat="server" Width="100" MinDate="01/01/1900" Calendar-FastNavigationStep="12" DateInput-DateFormat="MM/dd/yyyy" />
        </asp:TableCell>
        <asp:TableCell>
            <asp:Label ID="lblStatusAccred" runat="server" Text="Status of Accreditation: " />
            <asp:CheckBox ID="chkStatusAccred" runat="server" Text="Deemed" />
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell columnspan="3">
            <asp:Label ID="lblAccrdLtrRqd" runat="server" >*Must submit current Accreditation letter with each application</asp:Label>
        </asp:TableCell>    
    </asp:TableRow>
</asp:Table>
<div id="divHospFacSubType" runat="server">
    <div id="DivFacSubtypeHeader" class="formTableSectionDiv" runat="server">
        Hospital Type
    </div>
    <asp:RadioButtonList ID="optFactype" runat="server" RepeatColumns="3" RepeatDirection="Horizontal" Width="100%" />
</div>
<div id="divHP_ProviderType" runat="server">
    <div id="divHP_ProviderTypeHeader" class="formTableSectionDiv" runat="server">
        Additional Items
    </div>
    <asp:Table ID="tblHP_ProviderType" runat="server" CssClass="formTable" CellSpacing="0" BorderWidth="0" >
        <asp:TableRow>
            <asp:TableCell Width="175px" HorizontalAlign="Right">
                <asp:Label ID="lblHPTypeFac" runat="server" Text="Type of Hospice: " />
            </asp:TableCell>
            <asp:TableCell Width="200px">
                <telerik:RadComboBox ID="listHP_ProviderType" runat="server" Width="150px" />
            </asp:TableCell>
            <asp:TableCell Width="100px" HorizontalAlign="Right">
                <asp:Label ID="lblHP_Accred" runat="server" Text="Accreditation: " />
            </asp:TableCell>
            <asp:TableCell Width="150px">
                <telerik:RadComboBox ID="listHP_Accred" runat="server" Width="65px" />
            </asp:TableCell>
            <asp:TableCell Width="100px" HorizontalAlign="Right">
                <asp:Label ID="lblMedicareCertified" runat="server" Text="Medicare Certified: " />
            </asp:TableCell>
            <asp:TableCell Width="150px">
                <telerik:RadComboBox ID="listMedicareCertified" runat="server" Width="55px" >
                    <Items>
                        <telerik:RadComboBoxItem Text="" Value="" />
                        <telerik:RadComboBoxItem Text="Yes" Value="Y" />
                        <telerik:RadComboBoxItem Text="No" Value="N" />
                    </Items>
                </telerik:RadComboBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Right">
                <asp:Label ID="lblHPFiscalYrEnd" runat="server" Text="Cost Report Year End ('MM/DD'): " />
            </asp:TableCell>
            <asp:TableCell>
                <telerik:RadMaskedTextBox ID="txtHP_FYE" runat="server" Mask="##/##" Width="40" />
            </asp:TableCell>
            <asp:TableCell HorizontalAlign="Right">
                <asp:Label ID="lblHP_HospitalBased" runat="server" Text="Hospital Based: " />
            </asp:TableCell>
            <asp:TableCell>
                <telerik:RadComboBox ID="listHP_HospitalBased" runat="server" Width="55px" >
                    <Items>
                        <telerik:RadComboBoxItem Text="" Value="" />
                        <telerik:RadComboBoxItem Text="Yes" Value="Y" />
                        <telerik:RadComboBoxItem Text="No" Value="N" />
                    </Items>
                </telerik:RadComboBox>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</div>
<div id="divBR_ProviderType" runat="server">
    <div id="divBR_ProviderTypeHeader" class="formTableSectionDiv" runat="server">
        Type of Brain Injury Provider (Select all that apply to location)
    </div>
    <asp:Table ID="tblBR_ProviderType" CssClass="formTable" CellSpacing="0" BorderWidth="0" runat="server">
        <asp:TableRow>
            <asp:TableCell>
            <asp:Table ID="tblResidential" CssClass="formTable" CellSpacing="0" BorderWidth="0" runat="server">
                <asp:TableRow>
                    <asp:TableCell Width="15px" VerticalAlign="Top" >
                        <asp:CheckBox ID="chkBR_Residential" runat="server" />
                    </asp:TableCell>
                    <asp:TableCell VerticalAlign="Top" Width="100px">
                        Residential
                    </asp:TableCell>
                    <asp:TableCell Width="700px">
                        A facility publicly or privately owned providing a rehabilitative treatment environment which serves four or more adults who suffer from brain injury and at least one of whom is not related to the operator.  Services include personal assistance or supervision for a period of twenty-four hours continuously per day preparing them for community integration.  
                        <br /><br />
                        Capacity
                        <telerik:RadMaskedTextBox ID="txtBR_ResCapacity" runat="server" Mask="###" Width="20px" /> 
                        <br /><br />
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
            <asp:Table ID="tblComLiving" CssClass="formTable" CellSpacing="0" BorderWidth="0" runat="server">
                <asp:TableRow>
                    <asp:TableCell Width="15px" VerticalAlign="Top">
                        <asp:CheckBox ID="chkBR_CommLiving" runat="server" />
                    </asp:TableCell>
                    <asp:TableCell VerticalAlign="Top" Width="100px">
                        Community Living
                    </asp:TableCell>
                    <asp:TableCell Width="700px">
                        A home or apartment publicly or privately owned providing a rehabilitative treatment environment which serves one to six adults who suffer from brain injury and at least one of whom is not related to the operator, in a home or apartment setting preparing them for community integration.  
                        <br /><br />
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
            <asp:Table ID="tblOutpatient" CssClass="formTable" CellSpacing="0" BorderWidth="0" runat="server">
                <asp:TableRow>
                    <asp:TableCell Width="15px" VerticalAlign="Top">
                        <asp:CheckBox ID="chkBR_Outpatient" runat="server" />
                    </asp:TableCell>
                    <asp:TableCell VerticalAlign="Top" Width="100px">
                        Outpatient
                    </asp:TableCell>
                    <asp:TableCell Width="700px">
                        A facility publicly or privately owned providing an outpatient rehabilitative treatment environment which serves adults who suffer from brain injury and at least one of whom is not related to the operator, in an outpatient day treatment setting in order to advance the individual’s independence for higher level of community or transition to a greater level of independence in community or vocational function.
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell ColumnSpan="2">
                    </asp:TableCell>
                    <asp:TableCell HorizontalAlign="Left">
                        <br />
                        Outpatient Operating Hours
                        <br />
                        <table id="tableOperatingDetails" width="500" cellspacing="1" cellpadding="1">
                            <tr>
                                <td style="width: 15px"></td>
                                <td>
                                    <asp:CheckBox ID="CheckBoxDayOfOperationMon" runat="server"
                                        Text="Monday" TextAlign="Right" />
                                </td>
                                <td>
                                    <asp:CheckBox ID="CheckBoxDayOfOperationTue" runat="server"
                                        Text="Tuesday" TextAlign="Right" />
                                </td>
                                <td>
                                    <asp:CheckBox ID="CheckBoxDayOfOperationWed" runat="server"
                                        Text="Wednesday" TextAlign="Right" />
                                </td>
                                <td>
                                    <asp:CheckBox ID="CheckBoxDayOfOperationThu" runat="server"
                                        Text="Thursday" TextAlign="Right" />
                                </td>
                                <td>
                                    <asp:CheckBox ID="CheckBoxDayOfOperationFri" runat="server"
                                        Text="Friday" TextAlign="Right" />
                                </td>
                                <td>
                                    <asp:CheckBox ID="CheckBoxDayOfOperationSat" runat="server"
                                        Text="Saturday" TextAlign="Right" />
                                </td>
                                <td>
                                    <asp:CheckBox ID="CheckBoxDayOfOperationSun" runat="server"
                                        Text="Sunday" TextAlign="Right" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2"></td>
                                <td colspan="2" align="right">
                                    <asp:Label ID="lblFrom" runat="server">From: </asp:Label><telerik:RadMaskedTextBox ID="txtHoursMinutesFrom" runat="server" Mask="##:##" Width="35" />
                                    <asp:DropDownList ID="listAmPmFrom" runat="server" Font-Size="11px">
                                        <asp:ListItem Text="" Value=""></asp:ListItem>
                                        <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
                                        <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td align="right">
                                    <asp:Label ID="lblTO" runat="server">To: </asp:Label>
                                </td>
                                <td colspan="2" valign="top">
                                    <telerik:RadMaskedTextBox ID="txtHoursMinutesTo" runat="server" Mask="##:##" Width="35" />
                                    <asp:DropDownList ID="listAmPmTo" runat="server" Font-Size="11px">
                                        <asp:ListItem Text="" Value=""></asp:ListItem>
                                        <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
                                        <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td colspan="2">
                                </td>                        
                            </tr>
                        </table>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</div>
<div id="divHH_ProviderType" runat="server">
    <div id="divHH_ProviderTypeHeader" class="formTableSectionDiv" runat="server">
        Additional Items
    </div>
    <asp:Table ID="tblHH_ProviderType" runat="server" CssClass="formTable" CellSpacing="0" BorderWidth="0" >
        <asp:TableRow>
            <asp:TableCell Width="200px" HorizontalAlign="Right">
                <asp:Label ID="lblHH_Accred" runat="server" Text="Accreditation: " />
            </asp:TableCell>
            <asp:TableCell Width="100px">
                <telerik:RadComboBox ID="listHH_Accred" runat="server" Width="70px" >
                    <Items>
                        <telerik:RadComboBoxItem Text="" Value="" />
                        <telerik:RadComboBoxItem Text="JCAHO" Value="JCAHO" />
                        <telerik:RadComboBoxItem Text="CHAP" Value="CHAP" />
                        <telerik:RadComboBoxItem Text="ACHC" Value="ACHC" />
                    </Items>
                </telerik:RadComboBox>
            </asp:TableCell>
            <asp:TableCell Width="100px" HorizontalAlign="Right">
                <asp:Label ID="lblHH_Deemed" runat="server" Text="Deemed: " />
            </asp:TableCell>
            <asp:TableCell Width="100px">
                <telerik:RadComboBox ID="listHH_Deemed" runat="server" Width="55px">
                    <Items>
                        <telerik:RadComboBoxItem Text="" Value="" />
                        <telerik:RadComboBoxItem Text="Yes" Value="Y" />
                        <telerik:RadComboBoxItem Text="No" Value="N" />
                    </Items>
                </telerik:RadComboBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
           <asp:TableCell HorizontalAlign="Right">
                <asp:Label ID="lblHH_FYE" runat="server" Text="Cost Report Year End ('MM/DD'): " />
            </asp:TableCell>
            <asp:TableCell>
                <telerik:RadMaskedTextBox ID="txtHH_FYE" runat="server" Mask="##/##" Width="40" />
            </asp:TableCell>
            <asp:TableCell HorizontalAlign="Right">
                <asp:Label ID="lblHH_HospBased" runat="server" Text="Hospital Based: " />
            </asp:TableCell>
            <asp:TableCell>
                <telerik:RadComboBox ID="listHH_HospBased" runat="server" Width="55px" >
                    <Items>
                        <telerik:RadComboBoxItem Text="" Value="" />
                        <telerik:RadComboBoxItem Text="Yes" Value="Y" />
                        <telerik:RadComboBoxItem Text="No" Value="N" />
                    </Items>
                </telerik:RadComboBox>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</div>
<div id="divRelatedProvider" runat="server">
<asp:Table ID="FacTableRelatedProvider" CssClass="formTable" CellSpacing="0" BorderWidth="0" Width="98%" runat="server">
    <asp:TableRow>
        <asp:TableCell Width="250px">
            <asp:Label ID="lblRelatedProvider" runat="server" Text="Related Provider License Number"></asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <asp:TextBox ID="txtRelatedProvider" runat="server" MaxLength="50"></asp:TextBox>
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>
</div>
<div id="divProviderProvExtra" runat="server">
    <div id="Div1" class="formTableSectionDiv" runat="server">
        Additional Information
    </div>
    <asp:Table ID="tblPopServed_ProvExtra" runat="server">
        <asp:TableRow>
            <asp:TableCell Width="10px">&nbsp;</asp:TableCell>
            <asp:TableCell>Population Served: 
            </asp:TableCell>
            <asp:TableCell HorizontalAlign="Center" Width="100px">
                <asp:RadioButton ID="optPopSrvMale" runat="server" Text="Male" GroupName="PopServed" />
            </asp:TableCell>
            <asp:TableCell HorizontalAlign="Center" Width="100px">
                <asp:RadioButton ID="optPopSrvFemale" runat="server" Text="Female" GroupName="PopServed" />
            </asp:TableCell>
            <asp:TableCell HorizontalAlign="Center" Width="100px">
                <asp:RadioButton ID="optPopSrvBoth" runat="server" Text="Both" GroupName="PopServed" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <asp:Table ID="tblAgeServed_ProvExtra" runat="server">
        <asp:TableRow>
            <asp:TableCell Width="10px">&nbsp;</asp:TableCell>
            <asp:TableCell><asp:Label ID="lblAgeRange" runat="server" Text="Admission Age Range: " /></asp:TableCell>
            <asp:TableCell HorizontalAlign="Center">
                <telerik:RadNumericTextBox ID="txtAgeFrom" runat="server" MaxLength="3" Width="30"  
                 Type="Number" NumberFormat-GroupSeparator="" NumberFormat-DecimalDigits="0" SelectionOnFocus="CaretToBeginning" /> Yrs.
            </asp:TableCell>
            <asp:TableCell HorizontalAlign="Center">To&nbsp;&nbsp;
            </asp:TableCell>
            <asp:TableCell HorizontalAlign="Center">
                <telerik:RadNumericTextBox ID="txtAgeTo" runat="server" MaxLength="3" Width="30" 
                 Type="Number" NumberFormat-GroupSeparator="" NumberFormat-DecimalDigits="0" SelectionOnFocus="CaretToBeginning" /> Yrs.
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <asp:Table ID="tblTypeClient_ProvExtra" runat="server">
        <asp:TableRow>
            <asp:TableCell Width="10px">&nbsp;</asp:TableCell>
            <asp:TableCell><asp:Label ID="Label1" runat="server" Text="Ages Served: " /></asp:TableCell>
            <asp:TableCell HorizontalAlign="Center">
                <telerik:RadComboBox ID="listTypeClient" runat="server" Width="220px" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <asp:Table ID="tblAffiliationType" runat="server" Visible="false">
        <asp:TableRow>
            <asp:TableCell Width="10px">&nbsp;</asp:TableCell>
            <asp:TableCell><asp:Label ID="lblAffiliationType" runat="server" Text="Off-Site Type: " /></asp:TableCell>
            <asp:TableCell HorizontalAlign="Center">
                <telerik:RadComboBox ID="rcbAffiliationType" runat="server" Width="220px" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</div>
<div id="divAC_ProviderType" runat="server">
    <div id="divAC_ProviderTypeHeading" class="formTableSectionDiv" runat="server">
        Module/Type Facility
    </div>
    <asp:Table ID="Table1" runat="server" CssClass="formTable" CellSpacing="0" BorderWidth="0" >
        <asp:TableRow>
            <asp:TableCell Width="200px" >
                <telerik:RadComboBox ID="listAC_TypeFacility" runat="server" Width="180px" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</div>        
<div id="divES_ProviderType" runat="server">
    <div id="divES_ProviderTypeHeader" class="formTableSectionDiv" runat="server">
        Type of Facility
    </div>
    <asp:Table ID="Table2" runat="server" CssClass="formTable" CellSpacing="0" BorderWidth="0" >
        <asp:TableRow>
            <asp:TableCell>&nbsp;&nbsp;
            </asp:TableCell>
            <asp:TableCell ColumnSpan="2">
                <asp:CheckBox ID="chkES_ProviderBased" runat="server" OnClick="ToggleES_TypeFacilityChk('PROVBASED');" />
                <asp:Label ID="lblES_ProviderBased" runat="server" Text="Provider Based" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
            </asp:TableCell>
            <asp:TableCell Width="50px">
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblES_RelProvNum" runat="server" Text="Related Provider Number: " />
                <asp:TextBox ID="txtES_RelProvNum" runat="server" Width="150px"/>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
            </asp:TableCell>
            <asp:TableCell ColumnSpan="2">
                <asp:CheckBox ID="chkES_FreeStanding" runat="server" OnClick="ToggleES_TypeFacilityChk('FREESTAND');" />
                <asp:Label ID="lblES_FreeStanding" runat="server" Text="Free Standing" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</div>        
<div id="divRH_ProviderType" runat="server">
    <div id="divRH_ProviderTypeHeader" class="formTableSectionDiv" runat="server">
        Type of Facility
    </div>
    <asp:Table ID="tblRH_ProviderType" runat="server" CssClass="formTable" CellSpacing="0" BorderWidth="0" >
        <asp:TableRow>
            <asp:TableCell>&nbsp;&nbsp;
            </asp:TableCell>
            <asp:TableCell>
                <asp:CheckBox ID="chkRH_Mobile" runat="server" OnClick="ToggleRH_TypeFacilityChk('MOBILE');" />
                <asp:Label ID="lblRH_Mobile" runat="server" Text="Moblie" />
            </asp:TableCell>
            <asp:TableCell Width="50px">&nbsp;
            </asp:TableCell>
            <asp:TableCell>
                <asp:CheckBox ID="chkRH_Stationary" runat="server" OnClick="ToggleRH_TypeFacilityChk('STATIONARY');" />
                <asp:Label ID="lblRH_Stationary" runat="server" Text="Stationary" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <asp:Table ID="Table3" runat="server" CssClass="formTable" CellSpacing="0" BorderWidth="0" >
        <asp:TableRow>
            <asp:TableCell ColumnSpan="4">
            <hr />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>&nbsp;&nbsp;
            </asp:TableCell>
            <asp:TableCell ColumnSpan="3">
                <asp:CheckBox ID="chkRH_FreeStand" runat="server" OnClick="ToggleRH_TypeFacilityChk('FREESTAND');" />
                <asp:Label ID="lblRH_FreeStand" runat="server" Text="Free Standing" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>&nbsp;&nbsp;
            </asp:TableCell>
            <asp:TableCell ColumnSpan="3">
                <asp:CheckBox ID="chkRH_ProvBased" runat="server" OnClick="ToggleRH_TypeFacilityChk('PROVBASED');" />
                <asp:Label ID="lblRH_ProvBased" runat="server" Text="Provider Based" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>&nbsp;&nbsp;
            </asp:TableCell>
            <asp:TableCell Width="50px">
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblRH_RelProvNum" runat="server" Text="CCN for Associated Provider: " />
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtRH_RelProvNum" runat="server" Width="150px" MaxLength="12"/>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>&nbsp;&nbsp;
            </asp:TableCell>
            <asp:TableCell>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblRH_RelProvName" runat="server" Text="Related Provider Name: " />
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtRH_RelProvName" runat="server" Width="300px" MaxLength="50"/>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</div>        
<div id="divAS_ProviderType" runat="server">
    <div id="divAS_ProviderTypeHeader" class="formTableSectionDiv" runat="server">
        Additional Items
    </div>
    <asp:Table ID="tblAS_ProviderType" runat="server" CssClass="formTable" CellSpacing="0" BorderWidth="0" >
    	<asp:TableRow>
            <asp:TableCell Width="150px" HorizontalAlign="Right">
                <asp:Label ID="lblAS_Accred" runat="server" Text="Accreditation: " />
            </asp:TableCell>
            <asp:TableCell Width="150px">
                <telerik:RadComboBox ID="listAS_Accred" runat="server" Width="100px" />
            </asp:TableCell>
            <asp:TableCell Width="150px" HorizontalAlign="Right">
                <asp:Label ID="lblAS_Deemed" runat="server" Text="Deemed Status: " />
            </asp:TableCell>
            <asp:TableCell Width="100px">
                <telerik:RadComboBox ID="listAS_Deemed" runat="server" Width="55px">
                    <Items>
                        <telerik:RadComboBoxItem Text="" Value="" />
                        <telerik:RadComboBoxItem Text="Yes" Value="Y" />
                        <telerik:RadComboBoxItem Text="No" Value="N" />
                    </Items>
                </telerik:RadComboBox>
            </asp:TableCell>        
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell Width="150px" HorizontalAlign="Right">Location:</asp:TableCell>
            <asp:TableCell>
                <asp:CheckBox ID="chkAS_HospitalBased" runat="server" OnClick="ToggleAS_LocationChk('HOSPBASED');" />
                <asp:Label ID="lblAS_HospitalBased" runat="server" Text="Hospital Based" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:CheckBox ID="chkAS_FreeStanding" runat="server" OnClick="ToggleAS_LocationChk('FREESTAND');" />
                <asp:Label ID="lblAS_FreeStanding" runat="server" Text="Free Standing" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</div>        
<div id="divMR_ProviderType" runat="server">
    <div id="divMR_ProviderTypeHeading" class="formTableSectionDiv" runat="server">
        Type of Provider
    </div>
    <asp:Table ID="tblMR_ProviderType" runat="server" CssClass="formTable" CellSpacing="0" BorderWidth="0" >
        <asp:TableRow>
            <asp:TableCell Width="200px" >
                <telerik:RadComboBox ID="listMR_TypeFacility" runat="server" Width="300px" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</div>  
<div id="divNH_ProviderType" runat="server">
    <div id="DivAdminMultiFacHeader" class="formTableSectionDiv" runat="server">
        Multi-Facility Administration
    </div>
    <div>
        <div style="clear:both;">
            <div style="float:left;width:400px;padding-left:20px;">
                Is the administrator an administrator for more than one facility?
            </div>
            <div style="float:left;width:270px;">
                <asp:RadioButton ID="radMultiFacAdminYes" runat="server" GroupName="radMultiFacAdmin" Text="Yes" onclick="onMultiFacAdminClick()"/>
                <asp:RadioButton ID="radMultiFacAdminNo" runat="server" GroupName="radMultiFacAdmin" Text="No" onclick="onMultiFacAdminClick()"/>
            </div>
        </div>
        <div style="clear:both;">
            <div style="float:left;padding-left:20px;width:200px;text-align:right;">
                Name other facility:
            </div>
            <div style="float:left;width:250px;padding-left:10px;">
                <asp:TextBox ID="txtNHAdminOtherFacName" runat="server" MaxLength="60"/>
            </div>
        </div>
        <div style="clear:both;">
            <div style="float:left;padding-left:20px;width:200px;text-align:right;">
                Is facility single or multi-story?
            </div>
            <div style="float:left;width:270px;padding-left:10px;">
                <asp:RadioButton ID="radSingleStory" GroupName="radSingleMultiStory" runat="server" Text="Single Story"/>
                <asp:RadioButton ID="radMultiStory" GroupName="radSingleMultiStory" runat="server" Text="Multi-Story"/>
            </div>
        </div>
        <br style="clear:both"/>
    </div>
</div>
<div id="FNR_ApprovalDate" runat="server" visible="false"> 
     <div id="Div2" class="formTableSectionDiv" runat="server">
        Facility Need Review Approval Date
    </div>
    <asp:Table runat="server">
        <asp:TableRow>
             <asp:TableCell HorizontalAlign="Right">
            <asp:Label ID="lblFNRApprovalDate" runat="server" Text="Facility Need Review Approval Date:" HorizontalAlign="Right"></asp:Label>
        </asp:TableCell>
        <asp:TableCell>
             <telerik:RadDatePicker ID="dpFNRApprovalDate" runat="server" Width="100" DateInput-DateFormat="MM/dd/yyyy" 
                                    MinDate="01/01/1900" ZIndex="9999"  Calendar-FastNavigationStep="12" />
        </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</div>

