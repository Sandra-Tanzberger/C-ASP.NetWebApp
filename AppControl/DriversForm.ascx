<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DriversForm.ascx.cs" Inherits="AppControl.DriversForm" %>
<telerik:RadCodeBlock ID="DriversFormRCB" runat="server">
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
<div id="DriverErrorText" runat="server" visible="false" style="background-color: White;overflow:visible;border: solid 1px Red;color:Red;width: 100%;">
</div>
<asp:Table ID="tblDriver" runat="server" BackColor="#f3f4d7" Width="100%">
    <asp:TableRow>
        <asp:TableCell HorizontalAlign="Left">
            <asp:Label ID="lblTitle" runat="server" Text="Title"></asp:Label><br />
            <asp:TextBox ID="txtTitle" runat="server" MaxLength="5"></asp:TextBox>
        </asp:TableCell>
        <asp:TableCell HorizontalAlign="Left">
            <asp:Label ID="lblFirstName" runat="server" Text="First Name"></asp:Label><br />
            <asp:Textbox ID="txtFirstName" runat="server" MaxLength="15"></asp:Textbox>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell HorizontalAlign="Left">
            <asp:Label ID="lblMiddleInt" runat="server" Text="Middle Initial"></asp:Label><br />
            <asp:TextBox ID="txtMiddleInt" runat="server" MaxLength="1"/>
        </asp:TableCell>
         <asp:TableCell HorizontalAlign="Left">
            <asp:Label ID="lblLastName" runat="server" Text="Last Name"></asp:Label><br />
            <asp:TextBox ID="txtLastName" runat="server" MaxLength="20"></asp:TextBox>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
          <asp:TableCell HorizontalAlign="Left">
            <asp:Label ID="lblDriversLicenseClass" runat="server" Text="Drivers License Class"></asp:Label><br />
            <asp:DropDownList ID="ddlDriversLicenseClass" runat="server"></asp:DropDownList>
        </asp:TableCell>
        <asp:TableCell HorizontalAlign="Left">
            <asp:Label ID="lblDriversLicenseNum" runat="server" Text="Drivers License Number"></asp:Label><br />
            <asp:TextBox ID="txtDriversLicenseNum" runat="server" MaxLength="11"></asp:TextBox>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
         <asp:TableCell HorizontalAlign="Left">
            <asp:Label ID="lblDriversLicenseState" runat="server" Text="Drivers License State"></asp:Label><br />
            <asp:DropDownList ID="ddlDriversLicenseState" runat="server"></asp:DropDownList>
        </asp:TableCell>
         <asp:TableCell HorizontalAlign="Left">
        </asp:TableCell>
    </asp:TableRow>
       <asp:TableRow>
        <asp:TableCell ColumnSpan="2" HorizontalAlign="Left">
            <asp:button id="btnDriverUpdate" text="Update" runat="server" OnClick="Driver_Update" Visible="false" />
            <asp:button id="btnDriverInsert" text="Save" runat="server" OnClick="Driver_Insert" Visible="false"/>
            &nbsp;
            <asp:button id="btnDriverCancel" text="Cancel" runat="server" OnClientClick="Close()" causesvalidation="False" ></asp:button>
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>
