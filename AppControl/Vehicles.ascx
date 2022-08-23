<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Vehicles.ascx.cs" Inherits="AppControl.Vehicles" %>
<telerik:RadCodeBlock ID="RCB_Vehicles" runat="server">
    <script type="text/javascript">

        function VehiclesConfirmDelete() {
            var selecteditem = $find("<%= grdVehicles.MasterTableView.ClientID %>").get_selectedItems();

            if (!selecteditem.length > 0) {
                alert('Please select at least one record to edit');
            }
            else {
                return confirm("Do you really want to delete this record?");
            }
        }

        function VehiclesCheckSelected() {
            var selecteditem = $find("<%= grdVehicles.MasterTableView.ClientID %>").get_selectedItems();
            if (!selecteditem.length > 0) {
                alert('Please select at least one record to edit');
            }
        }
    </script> 
</telerik:RadCodeBlock>
    <telerik:RadAjaxManagerProxy ID="RadAjaxManagerVehicles" runat="server">  
        <AjaxSettings>  
            <telerik:AjaxSetting AjaxControlID="grdVehicles">  
                <UpdatedControls>  
                    <telerik:AjaxUpdatedControl ControlID="grdVehicles" LoadingPanelID="VehiclesLoadingPanel" />  
                </UpdatedControls>  
            </telerik:AjaxSetting>  
            <telerik:AjaxSetting AjaxControlID="RadAjaxManagerVehicles">  
                <UpdatedControls>  
                    <telerik:AjaxUpdatedControl ControlID="grdVehicles" LoadingPanelID="VehiclesLoadingPanel" />  
                </UpdatedControls>   
            </telerik:AjaxSetting>  
            <telerik:AjaxSetting AjaxControlID="btnAddVehicles">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadWindowManagerVehicles" LoadingPanelID="VehiclesLoadingPanel" />
                </UpdatedControls>
            </telerik:AjaxSetting>
             <telerik:AjaxSetting AjaxControlID="btnEditVehicles">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadWindowManagerVehicles" LoadingPanelID="VehiclesLoadingPanel" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>  
    </telerik:RadAjaxManagerProxy>  
<telerik:RadAjaxLoadingPanel ID="VehiclesLoadingPanel" runat="server" />
<telerik:RadAjaxPanel ID="VehiclesPanel" runat="server" Scrolling="None">
    <telerik:RadGrid ID="grdVehicles" runat="server"
                     AutoGenerateColumns="false"
                     OnItemCommand="grdVehicles_ItemCommand" 
                     OnItemDataBound="grdVehicles_ItemDataBound"
                     AllowFilteringByColumn="false"
                     GroupingSettings-CaseSensitive="false"
                     AllowMultiRowSelection="true" OnNeedDataSource="VehiclesGrid_NeedsDataSource" EnableViewState="true">
        <MasterTableView CommandItemDisplay="Top" AllowSorting="true" TableLayout="Auto" EnableViewState="true">
            <CommandItemTemplate>
                 <table border="0" width="98%">
                     <tr>
                        <td align="left">
                            <asp:LinkButton ID="btnAddVehicles" runat="server" CommandName="Add">
                                <img style="border:0px;vertical-align:middle;" alt="" src="../../images/AddRecord.gif" />
                                Add Vehicle
                            </asp:LinkButton>&nbsp;&nbsp;
                             <asp:LinkButton ID="btnEditVehicles" runat="server" CommandName="Edit" OnClientClick="return VehiclesCheckSelected();">
                                <img style="border:0px;vertical-align:middle;" alt="" src="../../images/Edit.gif" />
                                Edit Vehicle
                            </asp:LinkButton>&nbsp;&nbsp;
                             <asp:LinkButton ID="btnDeleteVehicles" runat="server" CommandName="Delete" OnClientClick="return VehiclesConfirmDelete();">
                                <img style="border:0px;vertical-align:middle;" alt="" src="../../images/Delete.gif" />
                                Delete Selected Vehicle
                            </asp:LinkButton>
                       </td>
                       <td align="right">
                            <asp:LinkButton ID="btnRefreshVehicles" Text="Refresh" CommandName="Rebind" runat="server" >  
                                <img style="border:0px;vertical-align:middle;" alt="" src="../../images/Refresh.gif" />
                                Refresh
                            </asp:LinkButton>
                    </td>
                  </tr>
                </table>
            </CommandItemTemplate>
        </MasterTableView>
        <ClientSettings EnablePostBackOnRowClick="false">
               <Selecting AllowRowSelect="True"></Selecting>
               <Scrolling AllowScroll="True" UseStaticHeaders="True" SaveScrollPosition="false">
                </Scrolling>
        </ClientSettings>
    </telerik:RadGrid>
</telerik:RadAjaxPanel>
    <telerik:RadWindowManager ID="RadWindowManagerVehicles" runat="server" Modal="true" VisibleOnPageLoad="false" ShowContentDuringLoad="true">
        <Windows>
            <telerik:RadWindow ID="RadWinVehicles" runat="server" VisibleOnPageLoad="false" ></telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>