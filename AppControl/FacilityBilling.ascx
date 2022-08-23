<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FacilityBilling.ascx.cs" Inherits="AppControl.FacilityBilling" %>
<telerik:RadCodeBlock ID="BillingRCB" runat="server" >
      <script type="text/javascript">
          //called from open radwindow for attachment
          function refreshGrid(inArgs) {
              $find("<%=RadAjaxManager.GetCurrent(Page).ClientID %>").ajaxRequest(inArgs);
          }

          function FacilityBillingConfirmDelete() {
              var selecteditem = $find("<%= grdBilling.MasterTableView.ClientID %>").get_selectedItems();

              if (!selecteditem.length > 0) {
                  alert('Please select at least one record to edit');
              }
              else {
                  return confirm("Do you really want to delete the selected record(s)?");
              }
          }
      </script>  
</telerik:RadCodeBlock>
<telerik:RadGrid ID="grdBilling" runat="server" 
    GridLines="None" AllowMultiRowSelection="true"
    OnNeedDataSource="grdBilling_NeedDataSource"
    OnItemCommand="grdBilling_ItemCommand">
    <MasterTableView CommandItemDisplay="Top">
        <CommandItemTemplate>
          <table border="0" width="98%">
             <tr>
                <td align="left">
                 <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" OnClientClick="return FacilityBillingConfirmDelete();" Visible="false">
                  <img style="border:0px;vertical-align:middle;" alt="" src="../../images/Delete.gif" />Delete Selected</asp:LinkButton>
                  &nbsp;&nbsp;&nbsp;
                  <asp:LinkButton ID="btnRefresh" runat="server" CommandName="Rebind" >
                  <img style="border:0px;vertical-align:middle;" alt="" src="../../images/Refresh.gif" />Refresh</asp:LinkButton>
                   &nbsp;&nbsp;&nbsp;
                  <asp:LinkButton ID="btnPrintScreen" runat="server" CommandName="PrintScreen" >
                  <img style="border:0px;vertical-align:middle;" alt="" src="../../images/Print.gif" />Print</asp:LinkButton>
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
<br />
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
          <asp:TableCell>
            <asp:Literal ID="litRefunds" runat="server" Text="Refunds: " />
        </asp:TableCell>
        <asp:TableCell>
            <telerik:RadNumericTextBox ID="txtRefunds" runat="server" Width="160" Type="Currency" NumberFormat-DecimalDigits="2" />
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
         <asp:TableCell>
            <asp:Literal ID="litLicense" runat="server" Text="License Charges: " />
        </asp:TableCell>
        <asp:TableCell>
            <telerik:RadNumericTextBox ID="txtLicense" runat="server" Width="160" Type="Currency" NumberFormat-DecimalDigits="2" />
        </asp:TableCell>
         <asp:TableCell>
            <asp:Literal ID="litNonLicense" runat="server" Text="Non License Charges: " />
        </asp:TableCell>
        <asp:TableCell>
            <telerik:RadNumericTextBox ID="txtNonLicense" runat="server" Width="160" Type="Currency" NumberFormat-DecimalDigits="2" />
        </asp:TableCell>
         <asp:TableCell>
            <asp:Literal ID="litBalance" runat="server" Text="Balance: " />
        </asp:TableCell>
        <asp:TableCell>
            <telerik:RadNumericTextBox ID="txtBalance" runat="server" Width="160" Type="Currency" NumberFormat-DecimalDigits="2" />
        </asp:TableCell>
    </asp:TableRow>
</asp:table>
</telerik:RadAjaxPanel>      
