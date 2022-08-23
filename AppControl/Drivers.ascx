<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Drivers.ascx.cs" Inherits="AppControl.Drivers" %>
<telerik:RadCodeBlock ID="RCB_Drivers" runat="server">
    <script type="text/javascript">

        function DriversConfirmDelete() {
          var selecteditem = $find("<%= grdDrivers.MasterTableView.ClientID %>").get_selectedItems();

          if (!selecteditem.length > 0) {
              alert('Please select at least one record to edit');
          }
          else {
              return confirm("Do you really want to delete this record?");
          }
        }

        function DriversCheckSelected() {
            var selecteditem = $find("<%= grdDrivers.MasterTableView.ClientID %>").get_selectedItems();
            if (!selecteditem.length > 0) {
                alert('Please select at least one record to edit');
            }
        }
    </script> 
</telerik:RadCodeBlock>
    <telerik:RadAjaxManagerProxy ID="RadAjaxManagerDrivers" runat="server">  
        <AjaxSettings>  
            <telerik:AjaxSetting AjaxControlID="grdDrivers">  
                <UpdatedControls>  
                    <telerik:AjaxUpdatedControl ControlID="grdDrivers" LoadingPanelID="DriversLoadingPanel" />  
                </UpdatedControls>  
            </telerik:AjaxSetting>  
            <telerik:AjaxSetting AjaxControlID="RadAjaxManagerDrivers">  
                <UpdatedControls>  
                    <telerik:AjaxUpdatedControl ControlID="grdDrivers" LoadingPanelID="DriversLoadingPanel" />  
                </UpdatedControls>  
            </telerik:AjaxSetting>  
            <telerik:AjaxSetting AjaxControlID="btnAdd">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadWindowManagerDrivers" LoadingPanelID="DriversLoadingPanel" />
                </UpdatedControls>
            </telerik:AjaxSetting>
             <telerik:AjaxSetting AjaxControlID="btnEdit">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadWindowManagerDrivers" LoadingPanelID="DriversLoadingPanel" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>  
    </telerik:RadAjaxManagerProxy>  
<telerik:RadAjaxLoadingPanel ID="DriversLoadingPanel" runat="server" />
<telerik:RadAjaxPanel ID="DriversPanel" runat="server" Scrolling="None">
    <telerik:RadGrid ID="grdDrivers" runat="server" 
                     AutoGenerateColumns="false"
                     OnItemCommand="grdDrivers_ItemCommand" 
                     OnItemDataBound="grdDrivers_ItemDataBound"
                     AllowFilteringByColumn="false"
                     GroupingSettings-CaseSensitive="false"
                     AllowMultiRowSelection="true" OnNeedDataSource="DriversGrid_NeedsDataSource" EnableViewState="true">
        <MasterTableView CommandItemDisplay="Top" AllowSorting="true" TableLayout="Auto" EnableViewState="true">
            <CommandItemTemplate>
             <table border="0" width="98%">
                     <tr>
                        <td align="left">
                            <asp:LinkButton ID="btnAdd" runat="server" CommandName="Add">
                                <img style="border:0px;vertical-align:middle;" alt="" src="../../images/AddRecord.gif" />
                                Add Driver
                            </asp:LinkButton>&nbsp;&nbsp;
                             <asp:LinkButton ID="btnEdit" runat="server" CommandName="Edit" OnClientClick="return DriversCheckSelected();">
                                <img style="border:0px;vertical-align:middle;" alt="" src="../../images/Edit.gif" />
                                Edit Selected Driver
                            </asp:LinkButton>
                             <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" OnClientClick="return DriversConfirmDelete();">
                                <img style="border:0px;vertical-align:middle;" alt="" src="../../images/Delete.gif" />
                                Delete Selected Driver
                            </asp:LinkButton>
                        <td align="right">
                            <asp:LinkButton ID="btnRefreshDrivers" Text="Refresh" CommandName="Rebind" runat="server" >  
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
    <telerik:RadWindowManager ID="RadWindowManagerDrivers" runat="server" Modal="true" VisibleOnPageLoad="false" ShowContentDuringLoad="true">
        <Windows>
            <telerik:RadWindow ID="RadWinDrivers" runat="server" VisibleOnPageLoad="false" ></telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>
