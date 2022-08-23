<%@ Control Language="C#"  AutoEventWireup="true" CodeBehind="AffiliationOffsiteEditForm.ascx.cs" Inherits="AppControl.AffiliationOffsiteEditForm" %>

<asp:HiddenField ID="hidKeyIDAffil" runat="server" Value="" />
<atg:SliderDiv ID="sldrProvInfoAffiliation" runat="server" AdditionalTitleText="" IsComplete="" Expanded="true" TitleText="Provider Information" >
    <asp:panel CssClass="LicensePanel" id="FacilityDetailContent" runat="server"></asp:panel>
</atg:SliderDiv>
<atg:SliderDiv ID="sldrSpecUnitsAffiliation" runat="server" AdditionalTitleText="" IsComplete="" Expanded="false" TitleText="Specialty Units" >
    <asp:panel CssClass="LicensePanel" id="SpecialtyUnitContent" runat="server"></asp:panel>
</atg:SliderDiv>
<atg:SliderDiv ID="sldrRmBedsAffiliation" runat="server" AdditionalTitleText="" IsComplete="" Expanded="false" TitleText="Rooms/Beds" >
    <asp:panel CssClass="LicensePanel" id="BedDetailContent" runat="server"></asp:panel>
</atg:SliderDiv>
<atg:SliderDiv ID="sldrServicesAffiliation" runat="server" AdditionalTitleText="" IsComplete="" Expanded="false" TitleText="Services" >
    <asp:panel CssClass="LicensePanel" id="ServiceDetailContent" runat="server"></asp:panel>
</atg:SliderDiv>
