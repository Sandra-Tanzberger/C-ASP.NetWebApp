<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="InsuranceCoveragesForm.ascx.cs" Inherits="AppControl.InsuranceCoveragesForm" %>
<telerik:RadCodeBlock ID="InsuranceCoveragesFormRCB" runat="server">
    <script type="text/javascript">
        function GetRadWindow() {
            var oWindow = null;
            if (window.radWindow) {
                oWindow = window.radWindow;
            }
            else if (window.frameElement.radWindow) {
                oWindow = window.frameElement.radWindow;
            }
            return oWindow;
        }

        function CloseAndRebind() {
            // GetRadWindow().BrowserWindow.refreshInsuranceCoverages(); // Call the function in parent page
            GetRadWindow().close(); // Close the window
            return false;
        }

        function Close() {
            var oWindow = GetRadWindow();
            oWindow.argument = null;
            oWindow.close();
            return false;
        }
       </script>  
</telerik:RadCodeBlock>
<div id="InsuranceCoverageErrorText" runat="server" visible="false" style="background-color: White;overflow:visible;border: solid 1px Red;color:Red;width: 100%;">
</div>
<asp:Table ID="tblInsuranceCoverage" runat="server" BackColor="#f3f4d7" Width="100%">
    <asp:TableRow>
        <asp:TableCell HorizontalAlign="Left">
            <asp:Label ID="lblCoverageType" runat="server" Text="Coverage Type"></asp:Label>        
        </asp:TableCell>
        <asp:TableCell HorizontalAlign="Left">
            <asp:DropDownList ID="ddlCoverageType" runat="server"></asp:DropDownList>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell HorizontalAlign="Left">
            <asp:Label ID="lblCoverageLimit" runat="server" Text="Coverage Limit"></asp:Label>
        </asp:TableCell>
        <asp:TableCell HorizontalAlign="Left">
            <telerik:RadNumericTextBox ID="txtCoverageLimit" runat="server"/> 
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell HorizontalAlign="Left">
            <asp:Label ID="lblCarrier" runat="server" Text="Carrier"></asp:Label>
        </asp:TableCell>
        <asp:TableCell HorizontalAlign="Left">
            <asp:DropDownList ID="ddlCarrier" runat="server"></asp:DropDownList>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
          <asp:TableCell HorizontalAlign="Left">
            <asp:Label ID="lblPolicyNum" runat="server" Text="Policy Number"></asp:Label>
        </asp:TableCell>
        <asp:TableCell HorizontalAlign="Left">
            <asp:TextBox ID="txtPolicyNum" runat="server" MaxLength="20"></asp:TextBox>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
         <asp:TableCell HorizontalAlign="Left">
            <asp:Label ID="lblEffectiveDate" runat="server" Text="Effective Date"></asp:Label>
        </asp:TableCell>
        <asp:TableCell HorizontalAlign="Left">
            <telerik:RadDatePicker ID="txtEffectiveDate" runat="server" Width="100" DateInput-DateFormat="MM/dd/yyyy" 
                            MinDate="01/01/1900" ZIndex="9999"  Calendar-FastNavigationStep="12" />
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
         <asp:TableCell HorizontalAlign="Left">
            <asp:Label ID="lblExpirationDate" runat="server" Text="Expiration Date"></asp:Label>
        </asp:TableCell>
        <asp:TableCell HorizontalAlign="Left">
            <telerik:RadDatePicker ID="txtExpirationDate" runat="server" Width="100" DateInput-DateFormat="MM/dd/yyyy" 
                            MinDate="01/01/1900" ZIndex="9999"  Calendar-FastNavigationStep="12" />
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
         <asp:TableCell HorizontalAlign="Left">
            <asp:Label ID="lblPrepaymentDueDate" runat="server" Text="Prepayment Due Date"></asp:Label>
        </asp:TableCell>
        <asp:TableCell HorizontalAlign="Left">
            <telerik:RadDatePicker ID="txtPrePaymentDueDate" runat="server" Width="100" DateInput-DateFormat="MM/dd/yyyy" 
                            MinDate="01/01/1900" ZIndex="9999"  Calendar-FastNavigationStep="12" />
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell ColumnSpan="2" HorizontalAlign="Left">
            <asp:Button ID="btnInsuranceUpdate" Text="Update" runat="server" OnClick="Insurance_Update" Visible="false" ></asp:Button>
            <asp:Button ID="btnInsuranceInsert" Text="Save" runat="server" OnClick="Insurance_Insert" Visible="false" ></asp:Button>
            &nbsp;
            <asp:Button ID="btnInsuranceCancel" Text="Cancel" runat="server" OnClientClick="return Close();" CausesValidation="False" ></asp:Button>
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>
