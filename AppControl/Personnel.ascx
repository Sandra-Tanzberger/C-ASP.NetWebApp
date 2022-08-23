<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Personnel.ascx.cs" Inherits="AppControl.Personnel" %>
<telerik:RadCodeBlock ID="RCB_Personnel" runat="server">
    <script type="text/javascript">
        function GetRadWindow() {
            var oWindow = null;
            if (window.radWindow)
                oWindow = window.radWindow;
            else if (window.frameElement.radWindow)
                oWindow = window.frameElement.radWindow;
            return oWindow;
        }

        function CloseAndRebind() {
            GetRadWindow().close(); // Close the window  
        }

        function Close() {
            var oWindow = GetRadWindow();
            oWindow.argument = null;
            oWindow.close();
            return false;
        }

        function PersonnelConfirmDelete() {
          var selecteditem = $find("<%= grdPersonnel.MasterTableView.ClientID %>").get_selectedItems();

          if (!selecteditem.length > 0) {
              alert('Please select at least one record to edit');
          }
          else {
              return confirm("Do you really want to delete this record?");
          }
        }

        function PersonnelCheckSelected() {
            var selecteditem = $find("<%= grdPersonnel.MasterTableView.ClientID %>").get_selectedItems();
            if (!selecteditem.length > 0) {
                alert('Please select at least one record to edit');
            }
        }

        function SelectMeOnly(objID) {
            var grid = document.getElementById('<%=grdPersonnel.ClientID%>');
            if (grid) {
                var elements = grid.getElementsByTagName('input');
                var checkcount = 0;
                for (var i = 0; i < elements.length; i++) {
                    if (elements[i].type == 'radio') {
                        if (elements[i].id != objID) {
                            elements[i].checked = false;
                        }                  
                    }
                }
            }          
        }  
    </script> 
</telerik:RadCodeBlock>
    <telerik:RadAjaxManagerProxy ID="RadAjaxManagerPersonnel" runat="server">  
        <AjaxSettings>  
            <telerik:AjaxSetting AjaxControlID="grdPersonnel">  
                <UpdatedControls>  
                    <telerik:AjaxUpdatedControl ControlID="grdPersonnel" LoadingPanelID="PersonnelLoadingPanel" />  
                </UpdatedControls>  
            </telerik:AjaxSetting>  
            <telerik:AjaxSetting AjaxControlID="RadAjaxManagerPersonnel">  
                <UpdatedControls>  
                    <telerik:AjaxUpdatedControl ControlID="grdPersonnel" LoadingPanelID="PersonnelLoadingPanel" />  
                </UpdatedControls>  
            </telerik:AjaxSetting>  
            <telerik:AjaxSetting AjaxControlID="btnAddPersonnel">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadWindowManagerPersonnel" LoadingPanelID="PersonnelLoadingPanel" />
                </UpdatedControls>
            </telerik:AjaxSetting>
             <telerik:AjaxSetting AjaxControlID="btnEditPersonnel">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadWindowManagerPersonnel" LoadingPanelID="PersonnelLoadingPanel" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>  
    </telerik:RadAjaxManagerProxy>  
<telerik:RadAjaxLoadingPanel ID="PersonnelLoadingPanel" runat="server" />
<telerik:RadAjaxPanel ID="PersonnelPanel" runat="server" Scrolling="None">
    <telerik:RadGrid ID="grdPersonnel" runat="server" 
                     AutoGenerateColumns="false"
                     OnItemCommand="grdPersonnel_ItemCommand" 
                     OnItemDataBound="grdPersonnel_ItemDataBound"
                     AllowFilteringByColumn="false"
                     GroupingSettings-CaseSensitive="false"
                     AllowMultiRowSelection="true" OnNeedDataSource="PersonnelGrid_NeedsDataSource" EnableViewState="true">
        <MasterTableView CommandItemDisplay="Top" AllowSorting="true" TableLayout="Auto" EnableViewState="true">
            <CommandItemTemplate>
             <table border="0" width="98%">
                     <tr>
                        <td align="left">
                            <asp:LinkButton ID="LinkButton1" runat="server" CommandName="SetFACAdmin">
                                <img style="border:0px;vertical-align:middle;" alt="" src="../../images/AddRecord.gif" />
                                Set Primary Admin
                            </asp:LinkButton>&nbsp;&nbsp;
                            <asp:LinkButton ID="btnAddPersonnel" runat="server" CommandName="Add">
                                <img style="border:0px;vertical-align:middle;" alt="" src="../../images/AddRecord.gif" />
                                Add Personnel
                            </asp:LinkButton>&nbsp;&nbsp;
                             <asp:LinkButton ID="btnEditPersonnel" runat="server" CommandName="Edit" OnClientClick="return PersonnelCheckSelected();">
                                <img style="border:0px;vertical-align:middle;" alt="" src="../../images/Edit.gif" />
                                Edit Selected Personnel
                            </asp:LinkButton>
                             <asp:LinkButton ID="btnDeletePersonnel" runat="server" CommandName="Delete" OnClientClick="return PersonnelConfirmDelete();">
                                <img style="border:0px;vertical-align:middle;" alt="" src="../../images/Delete.gif" />
                                Delete Selected Personnel
                            </asp:LinkButton>
                        <td align="right">
                            <asp:LinkButton ID="btnRefreshPersonnel" Text="Refresh" CommandName="Rebind" runat="server" >  
                                <img style="border:0px;vertical-align:middle;" alt="" src="../../images/Refresh.gif" />
                                Refresh
                            </asp:LinkButton>
                    </td>
                  </tr>
                </table>
            </CommandItemTemplate>
            <Columns>
                <telerik:GridTemplateColumn HeaderText="Primary FAC Admin" HeaderStyle-Width="5%" ItemStyle-Width="5%" UniqueName="PFAC" ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate><asp:RadioButton ID="rbPFACAdmin" CssClass="kppfac" runat="server" OnClientClick="SelectMeOnly()" /></ItemTemplate>
                </telerik:GridTemplateColumn>
            </Columns>
        </MasterTableView>
        <ClientSettings EnablePostBackOnRowClick="false">
               <Selecting AllowRowSelect="True"></Selecting>
               <Scrolling AllowScroll="True" UseStaticHeaders="True" SaveScrollPosition="false">
                </Scrolling>
        </ClientSettings>
    </telerik:RadGrid>
</telerik:RadAjaxPanel>
    <telerik:RadWindowManager ID="RadWindowManagerPersonnel" runat="server" Modal="true" VisibleOnPageLoad="false" ShowContentDuringLoad="true">
        <Windows>
            <telerik:RadWindow ID="RadWinPersonnel" runat="server" VisibleOnPageLoad="false" ></telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>