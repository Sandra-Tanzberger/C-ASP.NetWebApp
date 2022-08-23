<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProgramStaff.ascx.cs" Inherits="AppControl.ProgramStaff" %>
<telerik:RadCodeBlock ID="RCB_ProgramStaff" runat="server">
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

        function ProgramStaffConfirmDelete() {
          var selecteditem = $find("<%= grdProgramStaff.MasterTableView.ClientID %>").get_selectedItems();

          if (!selecteditem.length > 0) {
              alert('Please select at least one record to edit');
          }
          else {
              return confirm("Do you really want to delete this record?");
          }
        }

        function ProgramStaffCheckSelected() {
            var selecteditem = $find("<%= grdProgramStaff.MasterTableView.ClientID %>").get_selectedItems();
            if (!selecteditem.length > 0) {
                alert('Please select at least one record to edit');
            }
        }

        function SelectMeOnly(objID) {
            var grid = document.getElementById('<%=grdProgramStaff.ClientID%>');
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
    <telerik:RadAjaxManagerProxy ID="RadAjaxManagerProgramStaff" runat="server">  
        <AjaxSettings>  
            <telerik:AjaxSetting AjaxControlID="grdProgramStaff">  
                <UpdatedControls>  
                    <telerik:AjaxUpdatedControl ControlID="grdProgramStaff" LoadingPanelID="ProgramStaffLoadingPanel" />  
                </UpdatedControls>  
            </telerik:AjaxSetting>  
            <telerik:AjaxSetting AjaxControlID="RadAjaxManagerProgramStaff">  
                <UpdatedControls>  
                    <telerik:AjaxUpdatedControl ControlID="grdProgramStaff" LoadingPanelID="ProgramStaffLoadingPanel" />  
                </UpdatedControls>  
            </telerik:AjaxSetting>  
            <telerik:AjaxSetting AjaxControlID="btnAddProgramStaff">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadWindowManagerProgramStaff" LoadingPanelID="ProgramStaffLoadingPanel" />
                </UpdatedControls>
            </telerik:AjaxSetting>
             <telerik:AjaxSetting AjaxControlID="btnEditProgramStaff">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadWindowManagerProgramStaff" LoadingPanelID="ProgramStaffLoadingPanel" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>  
    </telerik:RadAjaxManagerProxy>  
<telerik:RadAjaxLoadingPanel ID="ProgramStaffLoadingPanel" runat="server" />
<telerik:RadAjaxPanel ID="ProgramStaffPanel" runat="server" Scrolling="None">
    <telerik:RadGrid ID="grdProgramStaff" runat="server" 
                     AutoGenerateColumns="false"
                     OnItemCommand="grdProgramStaff_ItemCommand" 
                     AllowFilteringByColumn="false"
                     GroupingSettings-CaseSensitive="false"
                     AllowMultiRowSelection="true" OnNeedDataSource="ProgramStaffGrid_NeedsDataSource" EnableViewState="true">
        <MasterTableView CommandItemDisplay="Top" AllowSorting="true" TableLayout="Auto" EnableViewState="true">
            <CommandItemTemplate>
             <table border="0" width="98%">
                     <tr>
                        <td align="left">
                            <asp:LinkButton ID="btnAddProgramStaff" runat="server" CommandName="Add">
                                <img style="border:0px;vertical-align:middle;" alt="" src="../../images/AddRecord.gif" />
                                Add Staff
                            </asp:LinkButton>&nbsp;&nbsp;
                             <asp:LinkButton ID="btnEditProgramStaff" runat="server" CommandName="Edit" OnClientClick="return ProgramStaffCheckSelected();">
                                <img style="border:0px;vertical-align:middle;" alt="" src="../../images/Edit.gif" />
                                Edit Selected Staff
                            </asp:LinkButton>
                             <asp:LinkButton ID="btnDeleteProgramStaff" runat="server" CommandName="Delete" OnClientClick="return ProgramStaffConfirmDelete();">
                                <img style="border:0px;vertical-align:middle;" alt="" src="../../images/Delete.gif" />
                                Delete Selected Staff
                            </asp:LinkButton>
                        <td align="right">
                            <asp:LinkButton ID="btnRefreshProgramStaff" Text="Refresh" CommandName="Rebind" runat="server" >  
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
    <telerik:RadWindowManager ID="RadWindowManagerProgramStaff" runat="server" Modal="true" VisibleOnPageLoad="false" ShowContentDuringLoad="true">
        <Windows>
            <telerik:RadWindow ID="RadWinProgramStaff" runat="server" VisibleOnPageLoad="false" ></telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>