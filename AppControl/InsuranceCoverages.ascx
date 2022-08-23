<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="InsuranceCoverages.ascx.cs" Inherits="AppControl.InsuranceCoverage" %>
<telerik:RadCodeBlock ID="RCB_InsuranceCoverage" runat="server">
    <script type="text/javascript">
        function InsuranceCoverageConfirmDelete() {
            var selecteditem = $find("<%= grdInsuranceCoverage.MasterTableView.ClientID %>").get_selectedItems();

            if (!selecteditem.length > 0) {
                alert('Please select at least one record to edit');
            }
            else {
                return confirm("Do you really want to delete this record?");
            }
        }

        function InsuranceCoverageCheckSelected() {
            var selecteditem = $find("<%= grdInsuranceCoverage.MasterTableView.ClientID %>").get_selectedItems();
            if (!selecteditem.length > 0) {
                alert('Please select at least one record to edit');
            }
        }
    </script> 
</telerik:RadCodeBlock>
    <telerik:RadAjaxManagerProxy ID="RadAjaxManagerInsuranceCoverage" runat="server">  
        <AjaxSettings>  
            <telerik:AjaxSetting AjaxControlID="grdInsuranceCoverage">  
                <UpdatedControls>  
                    <telerik:AjaxUpdatedControl ControlID="grdInsuranceCoverage" LoadingPanelID="InsuranceCoverageLoadingPanel" />  
                </UpdatedControls>  
            </telerik:AjaxSetting>  
            <telerik:AjaxSetting AjaxControlID="RadAjaxManagerInsuranceCoverage">  
                <UpdatedControls>  
                    <telerik:AjaxUpdatedControl ControlID="grdInsuranceCoverage" LoadingPanelID="InsuranceCoverageLoadingPanel" />  
                </UpdatedControls>  
            </telerik:AjaxSetting>  
            <telerik:AjaxSetting AjaxControlID="btnAddInsuranceCoverage">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadWindowManager1" LoadingPanelID="InsuranceCoverageLoadingPanel" />
                </UpdatedControls>
            </telerik:AjaxSetting>
             <telerik:AjaxSetting AjaxControlID="btnEditInsuranceCoverage">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadWindowManager1" LoadingPanelID="InsuranceCoverageLoadingPanel" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>  
    </telerik:RadAjaxManagerProxy>  
<telerik:RadAjaxLoadingPanel ID="InsuranceCoverageLoadingPanel" runat="server" />
<telerik:RadAjaxPanel ID="InsuranceCoveragePanel" runat="server" Scrolling="None">
    <telerik:RadGrid ID="grdInsuranceCoverage" runat="server" 
                     AutoGenerateColumns="false"
                     OnItemCommand="grdInsuranceCoverage_ItemCommand" 
                     OnItemDataBound="grdInsuranceCoverage_ItemDataBound"
                     AllowFilteringByColumn="false"
                     GroupingSettings-CaseSensitive="false"
                     AllowMultiRowSelection="true" OnNeedDataSource="InsuranceCoverageGrid_NeedsDataSource" EnableViewState="true">
        <MasterTableView CommandItemDisplay="Top" AllowSorting="true" TableLayout="Auto" EnableViewState="true">
            <CommandItemTemplate>
              <table border="0" width="98%">
                     <tr>
                        <td align="left">
                            <asp:LinkButton ID="btnAddInsuranceCoverage" runat="server" CommandName="Add">
                                <img style="border:0px;vertical-align:middle;" alt="" src="../../images/AddRecord.gif" />
                                Add Insurance Coverage
                            </asp:LinkButton>&nbsp;&nbsp;
                             <asp:LinkButton ID="btnEditInsuranceCoverage" runat="server" CommandName="Edit" OnClientClick="return InsuranceCoverageCheckSelected();">
                                <img style="border:0px;vertical-align:middle;" alt="" src="../../images/Edit.gif" />
                                Edit Selected Insurance Coverage
                            </asp:LinkButton>
                             <asp:LinkButton ID="btnDeleteInsuranceCoverage" runat="server" CommandName="Delete" OnClientClick="return InsuranceCoverageConfirmDelete();">
                                <img style="border:0px;vertical-align:middle;" alt="" src="../../images/Delete.gif" />
                                Delete Selected Insurance Coverage
                            </asp:LinkButton>
                             </td>
                       <td align="right">
                            <asp:LinkButton ID="btnRefreshInsuranceCoverage" Text="Refresh" CommandName="Rebind" runat="server" >  
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
    <telerik:RadWindowManager ID="RadWindowManager1" runat="server" Modal="true" VisibleOnPageLoad="false" ShowContentDuringLoad="true">
        <Windows>
            <telerik:RadWindow ID="RadWin1" runat="server" VisibleOnPageLoad="false"></telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>
