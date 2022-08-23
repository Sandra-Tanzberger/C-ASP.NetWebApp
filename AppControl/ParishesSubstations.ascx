<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ParishesSubstations.ascx.cs" Inherits="AppControl.ParishesSubstations" %>
<telerik:RadCodeBlock ID="RCB_Substations" runat="server">
    <script type="text/javascript">

        function SubstationsConfirmDelete() {
            var selecteditem = $find("<%= grdSubstations.MasterTableView.ClientID %>").get_selectedItems();

            if (!selecteditem.length > 0) {
                alert('Please select at least one record to edit');
            }
            else {
                return confirm("Do you really want to delete this record?");
            }
        }

        function SubstationsCheckSelected() {
            var selecteditem = $find("<%= grdSubstations.MasterTableView.ClientID %>").get_selectedItems();
            if (!selecteditem.length > 0) {
                alert('Please select at least one record to edit');
            }
        }
    </script> 
</telerik:RadCodeBlock>
    <telerik:RadAjaxManagerProxy ID="RadAjaxManagerSubstations" runat="server">  
        <AjaxSettings>  
            <telerik:AjaxSetting AjaxControlID="grdSubstations">  
                <UpdatedControls>  
                    <telerik:AjaxUpdatedControl ControlID="grdSubstations" LoadingPanelID="SubstationsLoadingPanel" />  
                </UpdatedControls>  
            </telerik:AjaxSetting>  
            <telerik:AjaxSetting AjaxControlID="RadAjaxManagerSubstations">  
                <UpdatedControls>  
                    <telerik:AjaxUpdatedControl ControlID="grdSubstations" LoadingPanelID="SubstationsLoadingPanel" />  
                </UpdatedControls>  
            </telerik:AjaxSetting>  
            <telerik:AjaxSetting AjaxControlID="btnAddSubstations">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadWindowManagerSubstations" LoadingPanelID="SubstationsLoadingPanel" />
                </UpdatedControls>
            </telerik:AjaxSetting>
             <telerik:AjaxSetting AjaxControlID="btnEditSubstations">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadWindowManagerSubstations" LoadingPanelID="SubstationsLoadingPanel" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>  
    </telerik:RadAjaxManagerProxy>  
<telerik:RadAjaxLoadingPanel ID="SubstationsLoadingPanel" runat="server" />
<telerik:RadAjaxPanel ID="SubstationsPanel" runat="server" Scrolling="None">
    <telerik:RadGrid ID="grdSubstations" runat="server" 
                     AutoGenerateColumns="false"
                     OnItemCommand="grdSubstations_ItemCommand" 
                     OnItemDataBound="grdSubstations_ItemDataBound"
                     AllowFilteringByColumn="false"
                     GroupingSettings-CaseSensitive="false"
                     AllowMultiRowSelection="true" OnNeedDataSource="SubstationsGrid_NeedsDataSource" EnableViewState="true">
        <MasterTableView CommandItemDisplay="Top" AllowSorting="true" TableLayout="Auto" EnableViewState="true">
            <CommandItemTemplate>
                <table border="0" width="98%">
                         <tr>
                            <td align="left">
                                <asp:LinkButton ID="btnAddSubstations" runat="server" CommandName="Add">
                                    <img style="border:0px;vertical-align:middle;" alt="" src="../../images/AddRecord.gif" />
                                    Add Parish & Substations
                                </asp:LinkButton>&nbsp;&nbsp;
                                 <asp:LinkButton ID="btnEditSubstations" runat="server" CommandName="Edit" OnClientClick="return SubstationsCheckSelected();">
                                    <img style="border:0px;vertical-align:middle;" alt="" src="../../images/Edit.gif" />
                                    Edit Parish & Substations
                                </asp:LinkButton>
                                 <asp:LinkButton ID="btnDeleteSubstations" runat="server" CommandName="Delete" OnClientClick="return SubstationsConfirmDelete();">
                                    <img style="border:0px;vertical-align:middle;" alt="" src="../../images/Delete.gif" />
                                    Delete Selected Parish and Substations
                                </asp:LinkButton>
                        </td>
                        <td align="right">
                            <asp:LinkButton ID="btnRefreshSubstations" Text="Refresh" CommandName="Rebind" runat="server" >  
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
    <telerik:RadWindowManager ID="RadWindowManagerSubstations" runat="server" Modal="true" VisibleOnPageLoad="false" ShowContentDuringLoad="true">
        <Windows>
            <telerik:RadWindow ID="RadWinSubstations" runat="server" VisibleOnPageLoad="false" ></telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>