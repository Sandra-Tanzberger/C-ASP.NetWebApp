<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ParishesSubstationsForm.ascx.cs" Inherits="AppControl.ParishesSubstationsForm" %>
<telerik:RadAjaxManagerProxy ID="ParishesSubstationsFormProxy" runat="server">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="rcbSubstationsState" >
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="rcbSubstationsCity" LoadingPanelID="ParishesSubstationsLoadingPanel" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="rcbSubstationsCity" >
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="rcbSubstationsZip" LoadingPanelID="ParishesSubstationsLoadingPanel" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>
<telerik:RadCodeBlock ID="ParishesSubstationsFormRCB" runat="server">
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
            //GetRadWindow().BrowserWindow.refreshDrivers(); // Call the function in parent page  
            GetRadWindow().close(); // Close the window  
        }

        function Close() {
            var oWindow = GetRadWindow();
            oWindow.argument = null;
            oWindow.close();
            return false;
        }
       </script>  
</telerik:RadCodeBlock>
<telerik:RadAjaxLoadingPanel ID="ParishesSubstationsLoadingPanel" runat="server" />
<div id="SubstationErrorText" runat="server" visible="false" style="background-color: White;overflow:visible;border: solid 1px Red;color:Red;width: 100%;">
</div>
<asp:Table ID="tblDriver" runat="server" BackColor="#f3f4d7" Width="100%">
    <asp:TableRow>
        <asp:TableCell HorizontalAlign="Left">
            <asp:Label ID="lblNumSubstations" runat="server" Text="No. of Substations"></asp:Label><br />
            <asp:TextBox ID="txtNumSubstations" runat="server" MaxLength="6"></asp:TextBox>
        </asp:TableCell>
        <asp:TableCell HorizontalAlign="Left">
            <asp:Label ID="lblStreet" runat="server" Text="Street"></asp:Label><br />
            <asp:TextBox ID="txtStreet" runat="server" MaxLength="100"></asp:TextBox>
        </asp:TableCell>
              <asp:TableCell HorizontalAlign="Left">
            <asp:Label ID="lblState" runat="server" Text="State"></asp:Label><br />
           <telerik:RadComboBox ID="rcbSubstationsState" runat="server" Width="150" AutoPostBack="true" Filter="StartsWith" AllowCustomText="false" OnSelectedIndexChanged="rcbSubstationsState_SelectedIndexChanged"/>
        </asp:TableCell>
          <asp:TableCell HorizontalAlign="Left">
            <asp:Label ID="lblCityCode" runat="server" Text="City Code"></asp:Label><br />
            <asp:TextBox ID="txtCityCode" runat="server" ReadOnly="true"></asp:TextBox>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell HorizontalAlign="Left">
            <asp:Label ID="lblCity" runat="server" Text="City"></asp:Label><br />
            <telerik:RadComboBox ID="rcbSubstationsCity" runat="server" Width="150" AutoPostBack="true" Filter="StartsWith" AllowCustomText="false" OnSelectedIndexChanged="rcbSubstationsCity_SelectedIndexChanged"/>
        </asp:TableCell>
         <asp:TableCell HorizontalAlign="Left">
            <asp:Label ID="lblParish" runat="server" Text="Parish"></asp:Label><br />
            <telerik:RadComboBox ID="rcbSubstationsParish" runat="server" Width="150" Filter="StartsWith" AllowCustomText="false" />
        </asp:TableCell>
        <asp:TableCell HorizontalAlign="Left">
            <asp:Label ID="lblZip" runat="server" Text="Zip Code"></asp:Label><br />
            <telerik:RadComboBox ID="rcbSubstationsZip" runat="server" Width="75px" Filter="StartsWith" AllowCustomText="false" />&nbsp;-&nbsp;
            <telerik:RadNumericTextBox ID="txtZipExtra" runat="server" Width="45px" MaxLength="4" NumberFormat-DecimalDigits="0" NumberFormat-GroupSeparator="" ></telerik:RadNumericTextBox>  
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell ColumnSpan="2" HorizontalAlign="Left">
            <asp:button id="btnSubstationsUpdate" text="Update" runat="server" OnClick="Substation_Update" Visible="false" />
            <asp:button id="btnSubstationsInsert" text="Save" runat="server" OnClick="Substation_Insert" Visible="false"/>
            &nbsp;
            <asp:button id="btnSubstationsCancel" text="Cancel" runat="server" OnClientClick="Close()" causesvalidation="False" ></asp:button>
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>