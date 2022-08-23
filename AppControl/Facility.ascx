<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Facility.ascx.cs" Inherits="AppControl.Facility" %>

<telerik:RadTabStrip ID="rtsProvider" runat="server" MultiPageID="rmpProvider" 
    ScrollChildren="True" SelectedIndex="0" ontabclick="rtsProvider_TabClick">
    <Tabs>
        <telerik:RadTab runat="server" PageViewID="rpv_FacilityDetails" Text="Provider" />
        <telerik:RadTab runat="server" PageViewID="rpv_Applications" Text="Applications" Selected="True" />
        <telerik:RadTab runat="server" Text="History" SelectedIndex="0">
            <Tabs>
                <telerik:RadTab runat="server" PageViewID="rpv_FacilityOwnership" 
                    Text="Facility Ownership">
                </telerik:RadTab>
                <telerik:RadTab runat="server" PageViewID="rpv_FacilityPersonnel" 
                    Text="Facility Personnel">
                </telerik:RadTab>
            </Tabs>
        </telerik:RadTab>
    </Tabs>
</telerik:RadTabStrip>
<telerik:RadMultiPage ID="rmpProvider" runat="server" SelectedIndex="0">
    <telerik:RadPageView ID="rpv_FacilityDetails" runat="server">
        <asp:panel id="FacilityDetail_Content" runat="server">
        </asp:panel>
    </telerik:RadPageView>
    <telerik:RadPageView ID="rpv_FacilityOwnership" runat="server">
        <asp:panel ID="FacilityOwnership_Content" runat="server">
        </asp:panel>
    </telerik:RadPageView>
    <telerik:RadPageView ID="rpv_FacilityPersonnel" runat="server">
        <asp:panel ID="FacilityPersonnel_Content" runat="server">
        </asp:panel>
    </telerik:RadPageView>
    <telerik:RadPageView ID="rpv_Applications" runat="server">
        <asp:Panel ID="Applications_Content" runat="server">
        </asp:Panel>
    </telerik:RadPageView>
    <telerik:RadPageView ID="rpv_History_CapacityBeds" runat="server">
        <asp:Panel ID="History_CapacityBeds_Content" runat="server">
        </asp:Panel>
    </telerik:RadPageView>
    <telerik:RadPageView ID="rpv_History_Billing" runat="server">
        <asp:Panel ID="History_Payment_Content" runat="server">
        </asp:Panel>
    </telerik:RadPageView>
    <telerik:RadPageView ID="rpv_Branch_Branch" runat="server">
        <asp:Panel ID="Branch_Content" runat="server">
        </asp:Panel>
    </telerik:RadPageView>
    <telerik:RadPageView ID="rpv_Offsite_Offsite" runat="server">
        <asp:Panel ID="Offsite_Content" runat="server">
        </asp:Panel>
    </telerik:RadPageView>
    <telerik:RadPageView ID="rpv_SpecialtyUnits_SpecialtyUnits" runat="server">
        <asp:Panel ID="SpecialtyUnits_Content" runat="server">
        </asp:Panel>
    </telerik:RadPageView>
</telerik:RadMultiPage>
