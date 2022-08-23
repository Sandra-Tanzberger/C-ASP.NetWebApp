<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VehiclesForm.ascx.cs" Inherits="AppControl.VehiclesForm" %>
<telerik:RadAjaxManagerProxy ID="VehicleProxy" runat="server">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="rcbType" >
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="rcbMake" LoadingPanelID="VehicleLoadingPanel" />
            </UpdatedControls>
        </telerik:AjaxSetting>
         <telerik:AjaxSetting AjaxControlID="txtMakeDescription" >
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="listBaseDescription" LoadingPanelID="VehicleLoadingPanel" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>
<telerik:RadCodeBlock ID="VehicleRCB" runat="server">
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
<telerik:RadAjaxLoadingPanel ID="VehicleLoadingPanel" runat="server" />
<div id="VehicleErrorText" runat="server" visible="false" style="background-color: White;overflow:visible;border: solid 1px Red;color:Red;width: 100%;">
</div>
<asp:Table ID="tblDriver" runat="server" BackColor="#f3f4d7" Width="100%">
    <asp:TableRow>
         <asp:TableCell>
             <asp:Label ID="lblType" runat="server" Text="Type"></asp:Label><br />
             <telerik:RadComboBox ID="rcbType" runat="server" Width="200" Filter="StartsWith" AutoPostBack="true" AllowCustomText="false" OnSelectedIndexChanged="rcbType_SelectedIndexChanged"/>
        </asp:TableCell>
        <asp:TableCell HorizontalAlign="Left">
            <asp:Label ID="lblMake" runat="server" Text="Make"></asp:Label><br />
            <telerik:RadComboBox ID="rcbMake" runat="server" Width="150" Filter="StartsWith" AllowCustomText="false"/>
        </asp:TableCell>
        <asp:TableCell HorizontalAlign="Left">
            <asp:Label ID="lblModel" runat="server" Text="Model"></asp:Label><br />
           <asp:TextBox ID="txtModel" runat="server" MaxLength="4"></asp:TextBox>
        </asp:TableCell>
        <asp:TableCell HorizontalAlign="Left">
            <asp:Label ID="lblMakeDescription" runat="server" Text="Zip"></asp:Label><br />
            <telerik:RadTextBox ID="txtMakeDescription" runat="server" MaxLength="25" AutoPostBack="true" OnTextChanged="txtZip_TextChanged"></telerik:RadTextBox>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
         <asp:TableCell HorizontalAlign="Left">
            <asp:Label ID="lblVIN" runat="server" Text="VIN"></asp:Label><br />
            <asp:TextBox ID="txtVIN" runat="server" MaxLength="20" style="text-transform: uppercase;"></asp:TextBox>
        </asp:TableCell>
        <asp:TableCell HorizontalAlign="Left">
            <asp:Label ID="lblUnit" runat="server" Text="Unit #"></asp:Label><br />
            <asp:TextBox ID="txtUnit" runat="server" MaxLength="12"></asp:TextBox>
        </asp:TableCell>
        <asp:TableCell HorizontalAlign="Left">
            <asp:Label ID="lblBase" runat="server" Text="State"></asp:Label><br />
            <asp:TextBox ID="txtBase" runat="server" MaxLength="2"></asp:TextBox>
        </asp:TableCell>
        <asp:TableCell HorizontalAlign="Left">
            <asp:Label ID="lblBaseDescription" runat="server" Text="Base Description"></asp:Label><br />
            <telerik:RadComboBox ID="listBaseDescription" runat="server" Width="150" AutoPostBack="true" Filter="StartsWith" AllowCustomText="false" />
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>

        <asp:TableCell HorizontalAlign="Left">
            <asp:Label ID="lblDecal" runat="server" Text="Decal #"></asp:Label><br />
            <asp:TextBox ID="txtDecal" runat="server" MaxLength="10"></asp:TextBox>
        </asp:TableCell>
        <asp:TableCell HorizontalAlign="Left">
            <asp:Label ID="lblDecalExpDate" runat="server" Text="Decal Exp Date"></asp:Label><br />
            <telerik:RadDatePicker ID="rdpDecalExpDate" runat="server" Width="100" DateInput-DateFormat="MM/dd/yyyy" 
                                    MinDate="01/01/1900" ZIndex="9999"  Calendar-FastNavigationStep="12" />
        </asp:TableCell>
           <asp:TableCell HorizontalAlign="Left">
            <asp:Label ID="lblLicensePlateNumber" runat="server" Text="License Plate #" Visible="false"></asp:Label><br />
            <asp:TextBox ID="txtLicensePlateNumber" runat="server" MaxLength="8" Visible="false"></asp:TextBox>
        </asp:TableCell>
        <asp:TableCell>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell >
            <asp:Label ID="lblACAP" runat="server" Text="ACAP" Visible="false"></asp:Label><br />
            <asp:TextBox ID="txtACAP" runat="server" Visible="false"></asp:TextBox>
        </asp:TableCell>
        <asp:TableCell >
            <asp:Label ID="lblHCAP" runat="server" Text="HCAP" Visible="false"></asp:Label><br />
            <asp:TextBox ID="txtHCAP" runat="server" Visible="false"></asp:TextBox>
        </asp:TableCell>
        <asp:TableCell></asp:TableCell>
        <asp:TableCell></asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell >
            <asp:Label ID="lblFAALIC" runat="server" Text="FAA Lic" Visible="false"></asp:Label><br />
            <asp:TextBox ID="txtFAALIC" runat="server" Visible="false" MaxLength="8"></asp:TextBox>
        </asp:TableCell>
        <asp:TableCell >
            <asp:Label ID="lblWing" runat="server" Text="Wing" Visible="false"></asp:Label><br />
             <telerik:RadComboBox ID="rcbWing" runat="server" Width="150" Filter="StartsWith" AllowCustomText="false" Visible="false"/>
        </asp:TableCell>
        <asp:TableCell></asp:TableCell>
        <asp:TableCell></asp:TableCell>
    </asp:TableRow>
    
    <asp:TableRow>
        <asp:TableCell ColumnSpan="2" HorizontalAlign="Left">
            <asp:button id="btnVehicleUpdate" text="Update" runat="server" OnClick="Vehicle_Update" Visible="false" />
            <asp:button id="btnVehicleInsert" text="Save" runat="server" OnClick="Vehicle_Insert" Visible="false"/>
            &nbsp;
            <asp:button id="btnVehicleCancel" text="Cancel" runat="server" OnClientClick="Close()" causesvalidation="False" ></asp:button>
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>