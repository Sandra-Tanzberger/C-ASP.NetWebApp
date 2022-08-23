<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FacilityApplications.ascx.cs" Inherits="AppControl.FacilityApplications" %>

<telerik:RadAjaxManagerProxy ID="FacilityAppsRAM" runat="server">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="grdApplications">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="RadWindowManager1" />
                <telerik:AjaxUpdatedControl ControlID="grdApplications" LoadingPanelID="FacAppRALP" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="RadWindowManager1">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="grdApplications" LoadingPanelID="FacAppRALP"/>
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>
<telerik:RadCodeBlock ID="FacilityAppsRCB" runat="server" >
      <script type="text/javascript">
          //called from open radwindow for attachment
          function refreshApplications() {
              $find("<%=RadAjaxManager.GetCurrent(Page).ClientID %>").ajaxRequest();
          }          
          function popup(inURL) {
              window.open( inURL , 'AttachmentViewer', 'left=250px, top=245px, width=700px, height=470px'); 
              return false;
          }

          function checkNewOrDelete() {
              var lbl = document.getElementById("<%= lblProviderStatus.ClientID %>");
              if (lbl.innerHTML != "01") {
                  alert("Facility Closed - Contact System Administrator To Re-Open Facility.");
                  return false;
              }
              return true;
          }

          function canAddNew() {
              return checkNewOrDelete();
          }

          function ConfirmDelete() {
              if (!checkNewOrDelete()) {
                  return false;
              }
              var gridCtrl = $find("<%=grdApplications.ClientID %>");
              var selRow = gridCtrl.get_masterTableView().get_selectedItems();
              var cell;
              var rowAppStatus;
              //here cell.innerHTML holds the value of the cell
              if (selRow.length > 0) {
                  cell = gridCtrl.get_masterTableView().getCellByColumnUniqueName(selRow[0], "APPLICATIONSTATUS");
                  rowAppStatus = cell.innerHTML;

                  if (rowAppStatus == "4") {
                      alert("Approved applications cannot be deleted.");
                      return false;
                  }
                  else {
                      var retVal = confirm("Are you sure you want to remove the selected Application?");

                      if (retVal) {
                          return true;
                      }
                      else {
                          return false;
                      }
                  }
              }
              else {
                  alert("No record selected.");
                  return false;
              }
          }
      </script>  
</telerik:RadCodeBlock>
<telerik:RadAjaxLoadingPanel ID="FacAppRALP" runat="server" />
<label id="lblProviderStatus" runat="server" style="display:none;"></label>
<telerik:RadGrid ID="grdApplications" runat="server" AutoGenerateColumns="False" 
        Width="876px"
        OnItemDataBound="grdApplications_ItemDataBound"
        OnInsertCommand="grdApplications_InsertCommand"
        OnDeleteCommand="grdApplications_DeleteCommand"               
        OnItemCommand="grdApplications_ItemCommand" 
        OnNeedDataSource="grdApplications_NeedDataSource"
        >       
    <MasterTableView CommandItemDisplay ="Top" >   
        <CommandItemTemplate >
            <table border="0" width="98%">
                <tr>
                    <td align="left">
                       <asp:LinkButton ID="btnAddNew" runat="server" CommandName="InitInsert" OnClientClick="return canAddNew();">
                            <img style="border:0px;vertical-align:middle;" alt="" src="../../images/AddRecord.gif" />
                            New
                        </asp:LinkButton>&nbsp;&nbsp;                
                        <asp:LinkButton ID="btnDelete" runat="server" CommandName="DeleteSelected" OnClientClick="return ConfirmDelete();" >
                            <img style="border:0px;vertical-align:middle;" alt="" src="../../images/Delete.gif" />
                            Delete
                        </asp:LinkButton>
                    </td>
                    <td align="right">
                        <asp:LinkButton ID="btnRefresh" Text="Refresh" CommandName="Rebind" runat="server" >  
                            <img style="border:0px;vertical-align:middle;" alt="" src="../../images/Refresh.gif" />
                            Refresh
                        </asp:LinkButton>
                    </td>
                </tr>
            </table>
        </CommandItemTemplate>                
        <EditFormSettings FormStyle-BackColor="#f3f4d7" UserControlName="~/AppControl/LicActivityEditForm.ascx" EditFormType="WebUserControl">
        </EditFormSettings>  
        <Columns>
            <telerik:GridTemplateColumn UniqueName="Actions" HeaderText="" 
                HeaderStyle-Wrap="true" HeaderStyle-Width="80px" >
                <ItemTemplate>
                    <asp:LinkButton runat="server" ID="LinkButtonOpen" CommandName="Open">Edit</asp:LinkButton>
                    <asp:LinkButton runat="server" ID="LinkButtonView" CommandName="Open">View</asp:LinkButton><br />
                     <asp:LinkButton runat="server" ID="LinkButtonPrint" CommandName="Print">Print</asp:LinkButton><br />
                    <!--
                     <asp:LinkButton runat="server" ID="LinkButtonLicense" CommandName="License">License</asp:LinkButton><br />
                    <asp:LinkButton runat="server" ID="LinkButtonReport" CommandName="Report">Report</asp:LinkButton><br />
                    -->
                    <asp:LinkButton runat="server" ID="LinkButtonBilling" CommandName="Billing">Billing</asp:LinkButton>
                </ItemTemplate>
            </telerik:GridTemplateColumn>
            <telerik:GridBoundColumn UniqueName="APPLICATIONID" DataField="APPLICATIONID" 
                HeaderText="Application Id" visible="true" HeaderStyle-Width="120px">
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn UniqueName="FEDERALID" DataField="FEDERALID" 
                HeaderText="Federal Id" display="False">
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn UniqueName="BUSINESSPROCESSID" DataField="BUSINESSPROCESSID" 
                HeaderText="Business Process ID" display="false" HeaderStyle-Width="0">
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn UniqueName="APPLICATIONACTION" DataField="APPLICATIONACTION" 
                HeaderText="Application Action Val" display="false" HeaderStyle-Width="0">
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn UniqueName="APPLICATIONSTATUS" DataField="APPLICATIONSTATUS" 
                HeaderText="Application Status Val" display="false" HeaderStyle-Width="0">
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn UniqueName="BUSINESSPROCESSNAME" DataField="BUSINESSPROCESSNAME" 
                HeaderText="Type" visible="true" HeaderStyle-Width="120px">
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn UniqueName="STATUS_VALDESC" DataField="STATUSVALDESC" 
                HeaderText="Status" visible="true" HeaderStyle-Width="120px">
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn UniqueName="ACTION_VALDESC" DataField="ACTIONVALDESC" 
                HeaderText="Action" visible="true" HeaderStyle-Width="150px">
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn UniqueName="GRIDDATESTARTED" DataField="GRIDDATESTARTED" 
                HeaderText="Start Date" visible="true" HeaderStyle-Width="100px" HeaderStyle-Wrap="false" 
                DataFormatString="{0:MM/dd/yyyy}" ItemStyle-Wrap="false" >
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn UniqueName="DATECOMPLETED" DataField="DATECOMPLETED" 
                HeaderText="Completion Date" visible="true" HeaderStyle-Width="100px" HeaderStyle-Wrap="false" 
                DataFormatString="{0:MM/dd/yyyy}" ItemStyle-Wrap="false" >
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn UniqueName="LICENSUREEXPIRATIONDATE" DataField="LICENSUREEXPIRATIONDATE" 
                HeaderText="Expiration Date" visible="true" HeaderStyle-Width="100px" HeaderStyle-Wrap="false" 
                DataFormatString="{0:MM/dd/yyyy}" ItemStyle-Wrap="false" >
            </telerik:GridBoundColumn>
        </Columns>
    </MasterTableView>
    <ClientSettings EnablePostBackOnRowClick="false" Selecting-AllowRowSelect="true">
    </ClientSettings>
</telerik:RadGrid>

<telerik:RadWindowManager ID="RadWindowManager1" runat="server" Modal="true"  />
