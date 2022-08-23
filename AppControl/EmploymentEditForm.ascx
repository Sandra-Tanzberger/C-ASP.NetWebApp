<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EmploymentEditForm.ascx.cs" Inherits="AppControl.EmploymentEditForm" %>
<telerik:RadCodeBlock ID="RCB_Employment" runat="server">
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
    </script> 
</telerik:RadCodeBlock>
<telerik:RadAjaxManagerProxy ID="EmploymentEditFHomeRAMP" runat="server">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="btnEmploymentUpdate">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="EmploymentErrorText" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="btnEmploymentInsert">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="EmploymentErrorText" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>
<div id="EmploymentErrorText" runat="server" visible="false" style="background-color: White;overflow:visible;border: solid 1px Red;color:Red;width: 100%;">
</div>
<asp:Table ID="tblKPEmployment" runat="server" BackColor="#f3f4d7">
    <asp:TableRow>
        <asp:TableCell Width="100">
            <asp:Label ID="lblStsrtDate" runat="server" Text="Start Date:" />
        </asp:TableCell>
        <asp:TableCell Width="300">
            <telerik:RadDatePicker ID="dtStartDate" runat="server" DateInput-DateFormat="MM/dd/yyyy" MinDate="01/01/1900" Calendar-FastNavigationStep="12" />
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell>
            <asp:Label ID="lblEndDate" runat="server" Text="End Date:" />
        </asp:TableCell>
        <asp:TableCell>
            <telerik:RadDatePicker ID="dtEndDate" runat="server" DateInput-DateFormat="MM/dd/yyyy" MinDate="01/01/1900" Calendar-FastNavigationStep="12" />
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell>
            <asp:Label ID="lblFacilityName" runat="server" Text="Facility Name:" />
        </asp:TableCell>
        <asp:TableCell>
            <asp:TextBox ID="txtFacilityName" runat="server" Width="400" MaxLength="60"/>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell>
            <asp:Label ID="lblFacilityAddress" runat="server" Text="Address:" />
        </asp:TableCell>
        <asp:TableCell>
            <asp:TextBox ID="txtFacilityAddress" runat="server" Width="400" MaxLength="150"/>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell ColumnSpan="2">
            <asp:Label ID="lblJobDuties" runat="server" Text="Job Duties and Personnel Supervised:" />
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell ColumnSpan="2">
            <asp:TextBox ID="txtJobDuties" TextMode="MultiLine" Columns="80" Rows="3" runat="server" MaxLength="512" />
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell ColumnSpan="2">
            <asp:button id="btnEmploymentUpdate" text="Update" runat="server" OnClick="Employment_Update" Visible="false" />
            <asp:button id="btnEmploymentInsert" text="Save" runat="server" OnClick="Employment_Insert" Visible="false"/>
            &nbsp;
            <asp:button id="btnEmploymentCancel" text="Cancel" runat="server" OnClientClick="Close()" causesvalidation="False" ></asp:button>
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>
