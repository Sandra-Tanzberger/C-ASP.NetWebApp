<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EducationEditForm.ascx.cs" Inherits="AppControl.EducationEditForm" %>
<telerik:RadCodeBlock ID="RCB_Education" runat="server">
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
<telerik:RadAjaxManagerProxy ID="EducationEditFHomeRAMP" runat="server">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="btnEducationUpdate">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="EducationErrorText" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="btnEducationInsert">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="EducationErrorText" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>
<div id="EducationErrorText" runat="server" visible="false" style="background-color: White;overflow:visible;border: solid 1px Red;color:Red;width: 100%;">
</div>
<asp:Table ID="tblKPEducation" runat="server" BackColor="#f3f4d7">
    <asp:TableRow>
        <asp:TableCell>
            <asp:Label ID="lblCollegeSchool" runat="server" Text="College/School" />
        </asp:TableCell>
        <asp:TableCell>
            <asp:TextBox ID="txtCollegeSchool" runat="server" MaxLength="100"/>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell>
            <asp:Label ID="lblGraduationDate" runat="server" Text="Graduation Date" />
        </asp:TableCell>
        <asp:TableCell>
            <telerik:RadDatePicker ID="dtGraduationDate" runat="server" DateInput-DateFormat="MM/dd/yyyy" MinDate="01/01/1900" Calendar-FastNavigationStep="12" />
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell>
            <asp:Label ID="lblDegreeObtained" runat="server" Text="Degree Obtained" />
        </asp:TableCell>
        <asp:TableCell>
            <asp:TextBox ID="txtDegreeObtained" runat="server" MaxLength="50"/>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell ColumnSpan="2">
            <asp:button id="btnEducationUpdate" text="Update" runat="server" OnClick="Education_Update" Visible="false" />
            <asp:button id="btnEducationInsert" text="Save" runat="server" OnClick="Education_Insert" Visible="false"/>
            &nbsp;
            <asp:button id="btnEducationCancel" text="Cancel" runat="server" OnClientClick="Close()" causesvalidation="False" ></asp:button>
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>
