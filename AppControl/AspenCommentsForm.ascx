<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AspenCommentsForm.ascx.cs" Inherits="AppControl.AspenCommentsForm" %>
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
<div id="AspenCommentsErrorText" runat="server" visible="false" style="background-color: White;overflow:visible;border: solid 1px Red;color:Red;width: 100%;">
</div>
<asp:Table ID="tblAspenComments" runat="server" BackColor="#f3f4d7" Width="100%">
    <asp:TableRow>
        <asp:TableCell HorizontalAlign="Left">
            <asp:Label ID="lblNotesLongText" runat="server" Text="Title"></asp:Label><br />
            <asp:TextBox ID="txtNotesLongText" runat="server" TextMode="MultiLine" Height="100" Width="600"></asp:TextBox>
        </asp:TableCell>
    </asp:TableRow>
       <asp:TableRow>
        <asp:TableCell ColumnSpan="2" HorizontalAlign="Left">
            <asp:button id="btnAspenCommentsUpdate" text="Update" runat="server" OnClick="AspenComments_Update" Visible="false" />
            <asp:button id="btnAspenCommentsInsert" text="Save" runat="server" OnClick="AspenComments_Insert" Visible="false"/>
            &nbsp;
            <asp:button id="btnAspenCommentsCancel" text="Cancel" runat="server" OnClientClick="Close()" causesvalidation="False" ></asp:button>
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>
