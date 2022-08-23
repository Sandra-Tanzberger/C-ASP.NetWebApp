<%@ Page Language="C#" MasterPageFile="~/Public.Master" AutoEventWireup="True" CodeBehind="DocHome.aspx.cs" Inherits="Common.DocHome" %>

<asp:Content ID="LeftNavContent" ContentPlaceHolderID="Left_Menu_Content" Runat="Server">
    <telerik:RadAjaxManagerProxy ID="DocHomeRAMP" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="MenuPanelBar">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="MenuPanelBar" />
                    <telerik:AjaxUpdatedControl ControlID="DocSplitter" LoadingPanelID="DocHomeLoadingPanel"/>
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
    <telerik:RadAjaxLoadingPanel ID="DocHomeLoadingPanel" runat="server" />
    <telerik:RadPanelBar ID="MenuPanelBar" runat="server" ExpandMode="FullExpandedItem" 
                         Width="200px" BackColor="GradientInactiveCaption" Height="80"
                         CollapseDelay="50" ExpandDelay="10" CollapseAnimation-Duration="100" 
                         ExpandAnimation-Duration="100"  >
        <Items>
            <telerik:RadPanelItem runat="server" Text="Search" Expanded="true" PreventCollapse="true" >
                <Items>
                    <telerik:RadPanelItem>
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblSrchTrackID" Text="Tracking ID:" /><br />
                            <asp:TextBox ID="txtSearchVal" runat="server" Width="100" />
                            <asp:Button runat="server" ID="btnSrch" Text="Find  " OnCommand="SearchButton_Click" /><br />
                            <asp:Label ID="lblNotFound" runat="server" Text="" Visible="false" ForeColor="Red" />
                        </ItemTemplate>
                    </telerik:RadPanelItem>
                </Items>
            </telerik:RadPanelItem>
        </Items>
    </telerik:RadPanelBar>
    <telerik:RadPanelBar ID="MenuPanelBar2" runat="server" ExpandMode="FullExpandedItem" 
                         Width="200px" BackColor="GradientInactiveCaption" Height="225"
                         CollapseDelay="50" ExpandDelay="10" CollapseAnimation-Duration="100" 
                         ExpandAnimation-Duration="100" >
        <Items>
            <telerik:RadPanelItem runat="server" Text="Helpful Hints" Expanded="true" PreventCollapse="true">
                <Items>
                    <telerik:RadPanelItem runat="server">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblSaveHint">
                                <span style="font-size:8.0pt;font-weight: bold">
                                The 'Save and Print' option at the bottom of the form will only save the completed Letter of Intent into the POPS system. If
                                you would like to save a copy to your local hard drive, when the printable copy appears right click on the window and choose save as.
                                </span>
                            </asp:Label>
                        </ItemTemplate>
                    </telerik:RadPanelItem>
                </Items>
            </telerik:RadPanelItem>
        </Items>
    </telerik:RadPanelBar>
</asp:Content>
<asp:Content ID="DocContent" ContentPlaceHolderID="Right_Content" Runat="Server">
    <telerik:RadCodeBlock ID="RCB" runat="server">
    <script type="text/javascript">
        embededChildSplitterID = "<%=DocSplitter.ClientID %>";
    </script>
    </telerik:RadCodeBlock>
    <telerik:RadSplitter ID="DocSplitter" runat="server" Orientation="Horizontal" Width="100%" >
        <telerik:RadPane ID="DocMainPane" runat="server" />
        <telerik:RadSplitBar ID="DocSplitBar" runat="server" CollapseMode="Both" />
        <telerik:RadPane ID="DocDetailPane" runat="server">
            <telerik:RadMenu ID="DocNavMenu" runat="server" Width="100%" Height="28" EnableOverlay="true" OnItemClick="DocNavMenu_ItemClick"  >
            <DefaultGroupSettings ExpandDirection="Auto" Flow="Horizontal" />
                <Items>
                    <telerik:RadMenuItem runat="server" Text="Save and Print" Value="Print"/>
                </Items>
            </telerik:RadMenu>
        </telerik:RadPane>
    </telerik:RadSplitter>  
</asp:Content>

