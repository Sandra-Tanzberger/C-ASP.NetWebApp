<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FacilityPayments.ascx.cs" Inherits="AppControl.FacilityPayments" %>

<telerik:RadGrid ID="grdPayments" runat="server" AutoGenerateColumns="False" 
    Width="100%" Height="100px" 
    onneeddatasource="grdPayments_NeedDataSource" 
    onselectedindexchanged="grdPayments_SelectedIndexChanged" >
    <MasterTableView>
        <Columns>
            <telerik:GridBoundColumn UniqueName="APPLICATIONID" DataField="APPLICATIONID" 
                visible="False" >
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn UniqueName="BILLINGID" DataField="BILLINGID" 
                visible="False" >
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn UniqueName="LICENSURENUM" DataField="LICENSURENUM" 
                HeaderText="License Number" visible="true" HeaderStyle-Width="25%">
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn UniqueName="LICFEETOTAL" DataField="LICFEETOTAL" 
                HeaderText="Total License Fee" visible="true" HeaderStyle-Width="25%">
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn UniqueName="AMOUNTRECEIVED" DataField="AMOUNTRECEIVED" 
                HeaderText="Amount Received" visible="true" HeaderStyle-Width="25%">
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn UniqueName="AMOUNTRECEIVEDDATE" DataField="AMOUNTRECEIVEDDATE" 
                HeaderText="Receipt Date" visible="true" HeaderStyle-Width="25%" HeaderStyle-Wrap="false" 
                DataFormatString="{0:MM/dd/yyyy}" ItemStyle-Wrap="false" >
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn UniqueName="LICENSEFEEPAID" DataField="LICENSEFEEPAID" 
                visible="False" >
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn UniqueName="CHECKNUMBER" DataField="CHECKNUMBER" 
                visible="False" >
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn UniqueName="TRANSACTIONID" DataField="TRANSACTIONID" 
                visible="False" >
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn UniqueName="LICREFUND" DataField="LICREFUND" 
                visible="False" >
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn UniqueName="PAYMODE" DataField="PAYMODE" 
                visible="False" >
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn UniqueName="CHECKRECEIVED" DataField="CHECKRECEIVED" 
                visible="False" >
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn UniqueName="CHECKPROCESSED" DataField="CHECKPROCESSED" 
                visible="False" >
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn UniqueName="LICREFUNDDATE" DataField="LICREFUNDDATE" 
                visible="False" >
            </telerik:GridBoundColumn>
        </Columns>
    </MasterTableView>
</telerik:RadGrid>
<br />
<asp:Table ID="tableFacilityPaymenst"  CssClass="formTable" CellSpacing="0" BorderWidth="0" Width="98%" runat="server">
    <asp:TableRow>
        <asp:TableCell>
            <asp:Label ID="Label1" runat="server">Licensure Number</asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <asp:TextBox ID="TextBoxLicensureNumber" runat="server" Columns="10" Rows="1" ReadOnly="true" ReadOnlyStyle-BackColor="LightGray" />
        </asp:TableCell>
        <asp:TableCell>
            <asp:Label ID="Label2" runat="server">License Fee</asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <asp:TextBox ID="TextBoxLicenseFee" runat="server" Columns="15" Rows="1" ReadOnly="true" ReadOnlyStyle-BackColor="LightGray" />
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell>
            <asp:Label ID="Label9" runat="server">License Fee Paid</asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <asp:TextBox ID="TextBoxLicenseFeePaid" runat="server" Columns="15" Rows="1" ReadOnly="true" ReadOnlyStyle-BackColor="LightGray" />
        </asp:TableCell>
        <asp:TableCell>
            <asp:Label ID="Label10" runat="server">Check Number</asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <asp:TextBox ID="TextBoxCheckNumber" runat="server" Columns="15" Rows="1" ReadOnly="true" ReadOnlyStyle-BackColor="LightGray" />
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell>
            <asp:Label ID="Label3" runat="server">Amount Received</asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <asp:TextBox ID="TextBoxAmountReceived" runat="server" Columns="15" Rows="1" ReadOnly="true" ReadOnlyStyle-BackColor="LightGray" />
        </asp:TableCell>
        <asp:TableCell>
            <asp:Label ID="Label4" runat="server">Amount Received Date</asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <telerik:RadDatePicker ID="RadDatePickerAmountReceivedDate" runat="server" 
                Enabled="false" MinDate="1900-01-01" Calendar-FastNavigationStep="12" >
            </telerik:RadDatePicker>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell>
            <asp:Label ID="Label5" runat="server">Payment Mode</asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <asp:DropDownList ID="listPayMode" runat="server" Enabled="false" />
        </asp:TableCell>
        <asp:TableCell>
            <asp:Label ID="Label6" runat="server">Transaction Id</asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <asp:TextBox ID="TextBoxTransactionId" runat="server" Columns="40" Rows="1" ReadOnly="true" ReadOnlyStyle-BackColor="LightGray" />
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell>
            <asp:Label ID="Label8" runat="server">Check Received</asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <telerik:RadDatePicker ID="RadDatePickerCheckReceived" runat="server" 
                Enabled="false" MinDate="1900-01-01" Calendar-FastNavigationStep="12" >
            </telerik:RadDatePicker>        
        </asp:TableCell>
        <asp:TableCell>
            <asp:Label ID="Label7" runat="server">Check Processed</asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <telerik:RadDatePicker ID="RadDatePickerCheckProcessed" runat="server" 
                Enabled="false" MinDate="1900-01-01" Calendar-FastNavigationStep="12" >
            </telerik:RadDatePicker>        
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell>
            <asp:Label ID="Label11" runat="server">Refund Amount</asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <asp:TextBox ID="TextBoxRefundAmount" runat="server" Columns="15" Rows="1" ReadOnly="true" ReadOnlyStyle-BackColor="LightGray" />
        </asp:TableCell>
        <asp:TableCell>
            <asp:Label ID="Label12" runat="server">Refund Date</asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <telerik:RadDatePicker ID="RadDatePickerRefundDate" runat="server" 
                Enabled="false" MinDate="1900-01-01" Calendar-FastNavigationStep="12" >
            </telerik:RadDatePicker>
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>