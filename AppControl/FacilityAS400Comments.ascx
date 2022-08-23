<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FacilityAS400Comments.ascx.cs" Inherits="AppControl.FacilityAS400Comments" %>
 <telerik:RadAjaxManagerProxy ID="RadAjaxManagerAspenComments" runat="server">  
      <AjaxSettings>  
             <telerik:AjaxSetting AjaxControlID="RadWindowManagerAspenComments">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="textBoxAspenNotes" LoadingPanelID="AspenCommentsLoadingPanel" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>  
        <AjaxSettings>  
             <telerik:AjaxSetting AjaxControlID="btnAddUpdateAspenComments">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadWindowManagerAspenComments" LoadingPanelID="AspenCommentsLoadingPanel" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>  
      <AjaxSettings>  
             <telerik:AjaxSetting AjaxControlID="btnAddUpdateAspenComments">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="textBoxAspenNotes" LoadingPanelID="AspenCommentsLoadingPanel" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>  
    </telerik:RadAjaxManagerProxy>  
<telerik:RadAjaxLoadingPanel ID="AspenCommentsLoadingPanel" runat="server" />
<asp:Table runat="server" width="100%" cellspacing="1" cellpadding="1">
    <asp:TableRow>
        <asp:TableCell Width="10%">
            <asp:Label runat="server" ID="labelAS400Comments">AS400 Comments</asp:Label>
        </asp:TableCell>
        <asp:TableCell Width="90%">
            <asp:TextBox ID="textBoxAS400Comments" runat="server" TextMode="MultiLine" Width="100%"  
                Rows="10" Columns="70" ReadOnly="true" BackColor="LightGray"></asp:TextBox>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
             <asp:TableCell ColumnSpan="2" HorizontalAlign="Left">
             <asp:LinkButton ID="btnAddUpdateAspenComments" runat="server" OnClick="OnClick_UpdateAspenCommments">
                                Add, Update Aspen Comments
             </asp:LinkButton>&nbsp;&nbsp;
            </asp:TableCell>
      </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell Width="10%">
            <asp:Label runat="server" ID="labelAspenNotes">Aspen Notes</asp:Label>
        </asp:TableCell>
        <asp:TableCell Width="90%">

            <asp:TextBox ID="textBoxAspenNotes" runat="server" TextMode="MultiLine" Width="100%"  
                Rows="10" Columns="70" ReadOnly="true" BackColor="LightGray"></asp:TextBox>
        </asp:TableCell>
    </asp:TableRow>    
</asp:Table>
   <telerik:RadWindowManager ID="RadWindowManagerAspenComments" runat="server" Modal="true" VisibleOnPageLoad="false" ShowContentDuringLoad="true">
        <Windows>
            <telerik:RadWindow ID="RadWinAspenComments" runat="server" VisibleOnPageLoad="false" ></telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>
