<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AppAttachment.ascx.cs" Inherits="AppControl.AppAttachment" %>

<telerik:RadCodeBlock ID="AttachRCB" runat="server" >
      <script type="text/javascript">
          //called from open radwindow for attachment
          function refreshAttachParent(inArgs) {
              $find("<%=RadAjaxManager.GetCurrent(Page).ClientID %>").ajaxRequest(inArgs);
          }
          function popup( inURL ) {
              window.open( inURL , 'AttachmentViewer', 'left=250px, top=245px, width=700px, height=470px'); 
              return false;
          }
      </script>  
</telerik:RadCodeBlock>
<telerik:RadAjaxManagerProxy ID="AttachRAM" runat="server">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="AttachRepeater">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="AttachRadWinMan" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="AttachRAM">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="AttachRadPanel" LoadingPanelID="AttachLoadingPanel" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>
<div id="ErrorText" runat="server" visible="false" style="overflow:visible;border: solid 1px Red;color:Red;width: 100%;">
</div>
<asp:Panel ID="pnlAttachments" runat="server">
<div style="margin-left: 10px;" >
    <telerik:RadAjaxLoadingPanel ID="AttachLoadingPanel" runat="server" />
    <telerik:RadAjaxPanel ID="AttachRadPanel" runat="server">
    <asp:Repeater id="AttachRepeater" runat="server">
        <HeaderTemplate>
            <table class="formTable" border="0">
            <tr valign="top" style="height: 10px">
                <td colspan="4"><hr style="color: Black" /></td>
            </tr>
            <tr valign="bottom" >
                <td style="width: 400px"><b>Description</b></td>
                <td style="width: 80px" align="center"><b>Action</b></td>
                <td style="width: 80px"></td>
                <td style="width: 80px"><b>Upload Date </b></td>
            </tr>
            <tr valign="top" style="height: 10px">
                <td colspan="4"><hr style="color: Black" /></td>
            </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td> <%# DataBinder.Eval( Container.DataItem, "AttachDescription" )%> </td>
                <td align="center"> 
                    <asp:LinkButton ID="AttachAction" CommandName="Upload" runat="server" Text='<%# DataBinder.Eval( Container.DataItem, "UploadCommandText" )%>'
                                CommandArgument='<%# DataBinder.Eval( Container.DataItem, "CommandArgs" )%>' 
                                OnCommand="AttachAction_Click" Width="65"/>
                </td>
                <td align="center">
                    <%# getViewLink(DataBinder.Eval(Container.DataItem,"FileAttachID").ToString())%>
                </td>
                <td> <%# getDateString(DataBinder.Eval(Container.DataItem, "AddDate").ToString())%> </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    </telerik:RadAjaxPanel>
</div>
<telerik:RadWindowManager ID="AttachRadWinMan" runat="server" >
    <Windows>
        <telerik:RadWindow ID="AttachRadWin" runat="server" VisibleOnPageLoad="true" VisibleStatusbar="false" Visible="false" />
    </Windows>
</telerik:RadWindowManager>
</asp:Panel>