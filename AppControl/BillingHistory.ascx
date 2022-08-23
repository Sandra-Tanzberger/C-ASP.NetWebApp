<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BillingHistory.ascx.cs" Inherits="AppControl.BillingHistory" %>
<telerik:RadCodeBlock ID="BillingRCB" runat="server" >
      <script type="text/javascript">
          //called from open radwindow for attachment
          function refreshGrid(inArgs) {
              $find("<%=RadAjaxManager.GetCurrent(Page).ClientID %>").ajaxRequest(inArgs);
          }

          function BillingHistoryConfirmDelete() {
              var selecteditem = $find("<%= grdBilling.MasterTableView.ClientID %>").get_selectedItems();

              if (!selecteditem.length > 0) {
                  alert('Please select at least one record to edit');
              }
              else {
                  return confirm("Do you really want to delete the selected record(s)?");
              }
          }

          function CheckFeeType() {
              var grid = $find("<%=grdBilling.ClientID %>");
              var MasterTable = grid.get_masterTableView();
              var selectedRows = MasterTable.get_selectedItems();
              var row = selectedRows[0];
              var cell = MasterTable.getCellByColumnUniqueName(row, "TypeBillingDesc")
              if(cell.innerHTML!="Payment")
              {
                  alert("Please select a payment to un-link, charges and adjustments cannot be un-linked");
                  return false;
              }
          }

      </script>  
</telerik:RadCodeBlock>
<telerik:RadAjaxManagerProxy ID="BillingRAMP" runat="server">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="btnLinkUnassignPayment">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="LinkPaymentRadWinMan" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="btnLinkUnassignPaymentInitials">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="LinkPaymentRadWinMan" />
            </UpdatedControls>
        </telerik:AjaxSetting>
         <telerik:AjaxSetting AjaxControlID="btnUnlink">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="LinkPaymentRadWinMan" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>    
</telerik:RadAjaxManagerProxy>
<telerik:RadGrid ID="grdBilling" runat="server" 
    GridLines="None" Width="99%" Height="300px" 
    OnNeedDataSource="grdBilling_NeedDataSource"
    OnItemCreated="grdBilling_ItemCreated" 
    OnInsertCommand="grdBilling_InsertCommand" 
    OnItemCommand="grdBilling_ItemCommand">
    <MasterTableView CommandItemDisplay=Top>
        <CommandItemTemplate>
          <table border="0" width="98%">
             <tr>
                <td align="left" style="width: 125px;">
                <asp:LinkButton ID="btnAdd" runat="server" CommandName="InitInsert">
                  <img style="border:0px;vertical-align:middle;" alt="" src="../../images/AddRecord.gif" />Add a new record</asp:LinkButton>
                </td>
                <td align="left" style="width: 260px;">
                  <asp:LinkButton ID="btnLinkUnassignPayment" runat="server" CommandName="linkBilling" Enabled="false">
                  <img style="border:0px;vertical-align:middle;" alt="" src="../../images/Update.gif" />Link Unassigned Payments - Non Initials</asp:LinkButton>
                </td>
                <td align="left" style="width: 240px;">
                  <asp:LinkButton ID="btnLinkUnassignPaymentInitials" runat="server" CommandName="linkBillinginitials" Enabled="false">
                  <img style="border:0px;vertical-align:middle;" alt="" src="../../images/Update.gif" />Link Unassigned Payments - Initials</asp:LinkButton>
                </td>
                <td align="left" style="width: 240px;">
                  <asp:LinkButton ID="btnUnlink" runat="server" CommandName="unlink" OnClientClick="return CheckFeeType();" Visible="false">
                  <img style="border:0px;vertical-align:middle;" alt="" src="../../images/Update.gif" />Unlink Assigned Payments</asp:LinkButton>
                </td>
                <td align="left" style="width: 200px;">
                <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" OnClientClick="return BillingHistoryConfirmDelete();" Visible="false">
                  <img style="border:0px;vertical-align:middle;" alt="" src="../../images/Delete.gif" />Delete Selected</asp:LinkButton>
                  </td>
                <td align="right">
                <asp:LinkButton ID="btnRefresh" runat="server" CommandName="RebindGrid" >
                  <img style="border:0px;vertical-align:middle;" alt="" src="../../images/Refresh.gif" />Refresh</asp:LinkButton>
                </td>
             </tr>
          </table>
        </CommandItemTemplate>
        <RowIndicatorColumn>
            <HeaderStyle Width="20px"></HeaderStyle>
        </RowIndicatorColumn>
        <ExpandCollapseColumn>
            <HeaderStyle Width="20px"></HeaderStyle>
        </ExpandCollapseColumn>
        <EditFormSettings FormStyle-BackColor="#f3f4d7" UserControlName="~/AppControl/BillingInsertForm.ascx" EditFormType="WebUserControl">
        </EditFormSettings>
    </MasterTableView>
    <ClientSettings EnablePostBackOnRowClick="false">
        <Selecting AllowRowSelect="True" />
        <Scrolling AllowScroll="True" />
    </ClientSettings>
</telerik:RadGrid>
<telerik:RadWindowManager ID="LinkPaymentRadWinMan" runat="server" Modal="true"></telerik:RadWindowManager>
<telerik:RadAjaxPanel ID="RAPsummary" runat="server">
<asp:table ID="tblSummary" runat="server">
    <asp:TableRow>
        <asp:TableCell>
            <asp:Literal ID="litCharges" runat="server" Text="Charges: " />
        </asp:TableCell>
        <asp:TableCell>
            <telerik:RadNumericTextBox ID="txtCharges" runat="server" Width="160" Type="Currency" NumberFormat-DecimalDigits="2" />
        </asp:TableCell>
        <asp:TableCell>
            <asp:Literal ID="litPayments" runat="server" Text="Payments: " />
        </asp:TableCell>
        <asp:TableCell>
            <telerik:RadNumericTextBox ID="txtPayments" runat="server" Width="160" Type="Currency" NumberFormat-DecimalDigits="2" />
        </asp:TableCell>
        <asp:TableCell>
            <asp:Literal ID="litAdjustments" runat="server" Text="Adjustments: " />
        </asp:TableCell>
        <asp:TableCell>
            <telerik:RadNumericTextBox ID="txtAdjustments" runat="server" Width="160" Type="Currency" NumberFormat-DecimalDigits="2" />
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell>
            <asp:Literal ID="litRefunds" runat="server" Text="Refunds: " />
        </asp:TableCell>
        <asp:TableCell>
            <telerik:RadNumericTextBox ID="txtRefunds" runat="server" Width="160" Type="Currency" NumberFormat-DecimalDigits="2" />
        </asp:TableCell>
        <asp:TableCell>
            <asp:Literal ID="litBeginningBalance" runat="server" Text="Previous Balance: " />
        </asp:TableCell>
        <asp:TableCell>
            <telerik:RadNumericTextBox ID="txtBeginningBalance" runat="server" Width="160" Type="Currency" NumberFormat-DecimalDigits="2" />
        </asp:TableCell>
        <asp:TableCell>
            <asp:Literal ID="litBalance" runat="server" Text="Balance: " />
        </asp:TableCell>
        <asp:TableCell>
            <telerik:RadNumericTextBox ID="txtBalance" runat="server" Width="160" Type="Currency" NumberFormat-DecimalDigits="2" />
        </asp:TableCell>
        <asp:TableCell>
        </asp:TableCell>
        <asp:TableCell>
        </asp:TableCell>
    </asp:TableRow>
</asp:table>
</telerik:RadAjaxPanel>      