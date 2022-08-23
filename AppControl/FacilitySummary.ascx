<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FacilitySummary.ascx.cs" Inherits="AppControl.FacilitySummary" %>

<%@ Register src="FacilityDetails.ascx" tagname="FacilityDetails" tagprefix="uc1" %>


<uc1:FacilityDetails ID="FacilityDetails1" runat="server" />


<atg:SliderDiv runat="server" ID="SliderDivDates" TitleText="Dates">
    <asp:panel CssClass="LicensePanel" id="PanelDatesContent" runat="server"></asp:panel>
</atg:SliderDiv>
<atg:SliderDiv runat="server" ID="SliderDivAS400Comments" TitleText="AS400 Comments">
    <asp:panel CssClass="LicensePanel" ID="PanelAS400CommentsContent" runat="server"></asp:panel>
</atg:SliderDiv>
<atg:SliderDiv runat="server" ID="SliderDivFacilityTypeOf" TitleText="Type Of Provider">
    <asp:panel CssClass="LicensePanel" id="PanelFacilityTypeOfContent" runat="server"></asp:panel>
</atg:SliderDiv>
<atg:SliderDiv runat="server" ID="SliderDivOperatingHours" TitleText="Operating Hours">
    <asp:panel CssClass="LicensePanel" id="PanelOperatingHoursContent" runat="server"></asp:panel>
</atg:SliderDiv>
<atg:SliderDiv runat="server" ID="SliderDivSubstation" TitleText="Substation">
    <asp:panel CssClass="LicensePanel" id="PanelSubstationContent" runat="server"></asp:panel>
</atg:SliderDiv>
<atg:SliderDiv runat="server" ID="SliderDivVehicle" TitleText="Vehicle">
    <asp:panel CssClass="LicensePanel" id="PanelVehicleContent" runat="server"></asp:panel>
</atg:SliderDiv>
<atg:SliderDiv runat="server" ID="SliderDivSpecialtyUnits" TitleText="Specialty Units">
    <asp:panel CssClass="LicensePanel" id="PanelSpecialtyUnits" runat="server"></asp:panel>
</atg:SliderDiv>
<atg:SliderDiv runat="server" ID="SliderDivOffSiteCampuses" TitleText="Off-Site Campuses">
        <asp:panel CssClass="LicensePanel" id="PanelOffSiteCampuses" runat="server"></asp:panel>
</atg:SliderDiv>
<atg:SliderDiv runat="server" ID="SliderDivServices" TitleText="Services">
    <asp:panel CssClass="LicensePanel" id="PanelServices" runat="server"></asp:panel>
</atg:SliderDiv>
<atg:SliderDiv runat="server" ID="SliderDivGenericCapSumm" TitleText="Program Operating Information">
    <asp:panel CssClass="LicensePanel" id="PanelGenericCapSumm" runat="server"></asp:panel>
</atg:SliderDiv>
<atg:SliderDiv runat="server" ID="SliderDivOwnership" TitleText="Ownership">
    <asp:panel CssClass="LicensePanel" id="PanelOwnership" runat="server"></asp:panel>
</atg:SliderDiv>
<atg:SliderDiv runat="server" ID="SliderDivKeyPersonnel" TitleText="Key Personnel">
    <asp:panel CssClass="LicensePanel" id="PanelKeyPersonnel" runat="server"></asp:panel>
</atg:SliderDiv>
<atg:SliderDiv runat="server" ID="SliderDivOperatingInfo" TitleText="Program Operating Information">
    <asp:panel CssClass="LicensePanel" id="PanelOperatingInfo" runat="server"></asp:panel>
</atg:SliderDiv>
<atg:SliderDiv runat="server" ID="SliderDivDrivers" TitleText="Drivers">
    <asp:panel CssClass="LicensePanel" id="PanelDrivers" runat="server"></asp:panel>
</atg:SliderDiv>
<atg:SliderDiv runat="server" ID="SliderDivInsurance" TitleText="Insurance Coverage">
    <asp:panel CssClass="LicensePanel" id="PanelInsurance" runat="server"></asp:panel>
</atg:SliderDiv>
<atg:SliderDiv runat="server" ID="SliderParishesSubstations" TitleText="Parishes & Substations">
    <asp:panel CssClass="LicensePanel" id="PanelParishesSubstations" runat="server"></asp:panel>
</atg:SliderDiv>
<atg:SliderDiv runat="server" ID="SliderVehicles" TitleText="Vehicles">
    <asp:panel CssClass="LicensePanel" id="PanelVehicles" runat="server"></asp:panel>
</atg:SliderDiv>


