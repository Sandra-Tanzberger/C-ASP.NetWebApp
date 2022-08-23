<%@ Control Language="C#" EnableViewState="true" AutoEventWireup="true" CodeBehind="License.ascx.cs" Inherits="AppControl.License" %>

<div id="HideLicense" runat="server" style="display: none;border-right: solid 1px;" >
    <div id="ErrorText" runat="server" visible="false" style="overflow:visible;border: solid 1px Red;color:Red;width: 100%;">
    </div>
    <atg:SliderDiv UserBackground="true" ID="sldrAppItems" runat="server" AdditionalTitleText="" IsComplete="" Expanded="true" TitleText="Application Process" >
        <asp:panel CssClass="LicensePanel" id="ApplicationItemsContent" runat="server"></asp:panel>
    </atg:SliderDiv>
    <atg:SliderDiv UserBackground="true" ID="sldrProvInfo" runat="server" AdditionalTitleText="" IsComplete="" Expanded="true" TitleText="Provider Information" >
        <asp:panel CssClass="LicensePanel" id="FacilityDetailContent" runat="server"></asp:panel>
    </atg:SliderDiv>
    <atg:SliderDiv ID="sldrOperDetails" runat="server" AdditionalTitleText="" IsComplete="" Expanded="false" TitleText="Operating Hours" >
        <asp:panel CssClass="LicensePanel" id="OperDetailsContent" runat="server"></asp:panel>
    </atg:SliderDiv>
    <atg:SliderDiv ID="sldrProgramOperatingInfo" runat="server" AdditionalTitleText="" IsComplete="" Expanded="false" TitleText="Program Operating Information" >
        <asp:panel CssClass="LicensePanel" id="ProgramOperatingInfoContent" runat="server"></asp:panel>
    </atg:SliderDiv>
    <atg:SliderDiv ID="sldrSpecUnits" runat="server" AdditionalTitleText="" IsComplete="" Expanded="false" TitleText="Specialty Units" >
        <asp:panel CssClass="LicensePanel" id="SpecialtyUnitContent" runat="server"></asp:panel>
    </atg:SliderDiv>
    <atg:SliderDiv ID="sldrAdministration" runat="server" AdditionalTitleText="" IsComplete="" Expanded="false" TitleText="Key Personnel" >
        <asp:panel CssClass="LicensePanel" ID="KeyPersonnelDetailContent" runat="server"></asp:panel>
    </atg:SliderDiv>
    <atg:SliderDiv ID="sldrOwnership" runat="server" AdditionalTitleText="" IsComplete="" Expanded="false" TitleText="Ownership" >
        <asp:panel CssClass="LicensePanel" ID="OwnerDetailContent" runat="server"></asp:panel>
    </atg:SliderDiv>
    <atg:SliderDiv ID="sldrOffsite" runat="server" AdditionalTitleText="" IsComplete="" Expanded="false" TitleText="Off-Site Campuses" >
        <asp:panel CssClass="LicensePanel" id="AffiliationDetailContent" runat="server"></asp:panel>
    </atg:SliderDiv>
    <atg:SliderDiv ID="sldrRmBeds" runat="server" AdditionalTitleText="" IsComplete="" Expanded="false" TitleText="Rooms/Beds" >
        <asp:panel CssClass="LicensePanel" id="BedDetailContent" runat="server"></asp:panel>
    </atg:SliderDiv>
    <atg:SliderDiv ID="sldrAttachments" runat="server" AdditionalTitleText="" IsComplete="" Expanded="false" TitleText="Documents/Attachments" >
        <asp:panel CssClass="LicensePanel" id="AttachmentDetailContent" runat="server"></asp:panel>
    </atg:SliderDiv>
    <atg:SliderDiv ID="sldrServices" runat="server" AdditionalTitleText="" IsComplete="" Expanded="false" TitleText="Services" >
        <asp:panel CssClass="LicensePanel" id="ServicesContent" runat="server"></asp:panel>
    </atg:SliderDiv>
    <atg:SliderDiv ID="sldrPaymentAuthorization" runat="server" AdditionalTitleText="" IsComplete="" Expanded="false" TitleText="Authorization of Application" >
        <asp:panel CssClass="LicensePanel" id="PaymentAuthorizationContent" runat="server"></asp:panel>
    </atg:SliderDiv>
    <atg:SliderDiv runat="server" ID="sldrDrivers" Expanded="false" TitleText="Drivers" Visible="false">
        <asp:panel CssClass="LicensePanel" id="DriversContent" runat="server"></asp:panel>
    </atg:SliderDiv>
    <atg:SliderDiv runat="server" ID="sldrInsuranceCoverage" Expanded="false" TitleText="Insurance Coverage" Visible="false">
        <asp:panel CssClass="LicensePanel" id="InsuranceCoverageContent" runat="server"></asp:panel>
    </atg:SliderDiv>
      <atg:SliderDiv runat="server" ID="sldrParishesSubstations" Expanded="false" TitleText="Parishes & Substations" Visible="false">
        <asp:panel CssClass="LicensePanel" id="ParishesSubstationsContent" runat="server"></asp:panel>
    </atg:SliderDiv>
       <atg:SliderDiv runat="server" ID="sldrVehicles" Expanded="false" TitleText="Vehicles" Visible="false">
        <asp:panel CssClass="LicensePanel" id="VehiclesContent" runat="server"></asp:panel>
    </atg:SliderDiv>
</div>
<telerik:RadCodeBlock ID="rcbLicense" runat="server">
    <script type="text/javascript">
        function toggleCollapseAll() {
            if (null != document.getElementById("<%=sldrAppItems.UniqueID %>" + '_ExpandState'))
                document.getElementById("<%=sldrAppItems.UniqueID %>" + '_ExpandState').value = false;

            if (null != document.getElementById("<%=sldrProvInfo.UniqueID %>" + '_ExpandState'))
                document.getElementById("<%=sldrProvInfo.UniqueID %>" + '_ExpandState').value = false;

            if (null != document.getElementById("<%=sldrOperDetails.UniqueID %>" + '_ExpandState'))
                document.getElementById("<%=sldrOperDetails.UniqueID %>" + '_ExpandState').value = false;

            if (null != document.getElementById("<%=sldrSpecUnits.UniqueID %>" + '_ExpandState'))
                document.getElementById("<%=sldrSpecUnits.UniqueID %>" + '_ExpandState').value = false;

            if (null != document.getElementById("<%=sldrAdministration.UniqueID %>" + '_ExpandState'))
                document.getElementById("<%=sldrAdministration.UniqueID %>" + '_ExpandState').value = false;

            if (null != document.getElementById("<%=sldrOwnership.UniqueID %>" + '_ExpandState'))
                document.getElementById("<%=sldrOwnership.UniqueID %>" + '_ExpandState').value = false;

            if (null != document.getElementById("<%=sldrOffsite.UniqueID %>" + '_ExpandState'))
                document.getElementById("<%=sldrOffsite.UniqueID %>" + '_ExpandState').value = false;

            if (null != document.getElementById("<%=sldrRmBeds.UniqueID %>" + '_ExpandState'))
                document.getElementById("<%=sldrRmBeds.UniqueID %>" + '_ExpandState').value = false;

            if (null != document.getElementById("<%=sldrAttachments.UniqueID %>" + '_ExpandState'))
                document.getElementById("<%=sldrAttachments.UniqueID %>" + '_ExpandState').value = false;

            if (null != document.getElementById("<%=sldrServices.UniqueID %>" + '_ExpandState'))
                document.getElementById("<%=sldrServices.UniqueID %>" + '_ExpandState').value = false;

            if (null != document.getElementById("<%=sldrPaymentAuthorization.UniqueID %>" + '_ExpandState'))
                document.getElementById("<%=sldrPaymentAuthorization.UniqueID %>" + '_ExpandState').value = false;
                
            if (null != document.getElementById("<%=sldrDrivers.UniqueID %>" + '_ExpandState'))
                document.getElementById("<%=sldrDrivers.UniqueID %>" + '_ExpandState').value = false;

            if (null != document.getElementById("<%=sldrInsuranceCoverage.UniqueID %>" + '_ExpandState'))
                document.getElementById("<%=sldrInsuranceCoverage.UniqueID %>" + '_ExpandState').value = false;

            if (null != document.getElementById("<%=sldrParishesSubstations.UniqueID %>" + '_ExpandState'))
                document.getElementById("<%=sldrParishesSubstations.UniqueID %>" + '_ExpandState').value = false;

            if (null != document.getElementById("<%=sldrVehicles.UniqueID %>" + '_ExpandState'))
                document.getElementById("<%=sldrVehicles.UniqueID %>" + '_ExpandState').value = false;
            
        }

        function toggleExpandAll() {
            if (null != document.getElementById("<%=sldrAppItems.UniqueID %>" + '_ExpandState'))
                document.getElementById("<%=sldrAppItems.UniqueID %>" + '_ExpandState').value = true;

            if (null != document.getElementById("<%=sldrProvInfo.UniqueID %>" + '_ExpandState'))
                document.getElementById("<%=sldrProvInfo.UniqueID %>" + '_ExpandState').value = true;

            if (null != document.getElementById("<%=sldrOperDetails.UniqueID %>" + '_ExpandState'))
                document.getElementById("<%=sldrOperDetails.UniqueID %>" + '_ExpandState').value = true;

            if (null != document.getElementById("<%=sldrSpecUnits.UniqueID %>" + '_ExpandState'))
                document.getElementById("<%=sldrSpecUnits.UniqueID %>" + '_ExpandState').value = true;

            if (null != document.getElementById("<%=sldrAdministration.UniqueID %>" + '_ExpandState'))
                document.getElementById("<%=sldrAdministration.UniqueID %>" + '_ExpandState').value = true;

            if (null != document.getElementById("<%=sldrOwnership.UniqueID %>" + '_ExpandState'))
                document.getElementById("<%=sldrOwnership.UniqueID %>" + '_ExpandState').value = true;

            if (null != document.getElementById("<%=sldrOffsite.UniqueID %>" + '_ExpandState'))
                document.getElementById("<%=sldrOffsite.UniqueID %>" + '_ExpandState').value = true;

            if (null != document.getElementById("<%=sldrRmBeds.UniqueID %>" + '_ExpandState'))
                document.getElementById("<%=sldrRmBeds.UniqueID %>" + '_ExpandState').value = true;

            if (null != document.getElementById("<%=sldrAttachments.UniqueID %>" + '_ExpandState'))
                document.getElementById("<%=sldrAttachments.UniqueID %>" + '_ExpandState').value = true;

            if (null != document.getElementById("<%=sldrServices.UniqueID %>" + '_ExpandState'))
                document.getElementById("<%=sldrServices.UniqueID %>" + '_ExpandState').value = true;

            if (null != document.getElementById("<%=sldrPaymentAuthorization.UniqueID %>" + '_ExpandState'))
                document.getElementById("<%=sldrPaymentAuthorization.UniqueID %>" + '_ExpandState').value = true;
                
            if (null != document.getElementById("<%=sldrDrivers.UniqueID %>" + '_ExpandState'))
                document.getElementById("<%=sldrDrivers.UniqueID %>" + '_ExpandState').value = true;

            if (null != document.getElementById("<%=sldrInsuranceCoverage.UniqueID %>" + '_ExpandState'))
                document.getElementById("<%=sldrInsuranceCoverage.UniqueID %>" + '_ExpandState').value = true;

            if (null != document.getElementById("<%=sldrParishesSubstations.UniqueID %>" + '_ExpandState'))
                document.getElementById("<%=sldrParishesSubstations.UniqueID %>" + '_ExpandState').value = true;

            if (null != document.getElementById("<%=sldrVehicles.UniqueID %>" + '_ExpandState'))
                document.getElementById("<%=sldrVehicles.UniqueID %>" + '_ExpandState').value = true;
            
        }
        </script>
</telerik:RadCodeBlock>
