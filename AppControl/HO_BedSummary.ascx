<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HO_BedSummary.ascx.cs" Inherits="AppControl.HO_BedSummary" %>

<telerik:RadAjaxManagerProxy ID="BedSummRAM" runat="server">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="btnLBEditSelected">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="CapSumRadPanel" LoadingPanelID="CapSumRALP" />
                <telerik:AjaxUpdatedControl ControlID="BedSummRadWinMan" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="BedSummRAM">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="CapSumRadPanel" />
                <telerik:AjaxUpdatedControl ControlID="CapSumRepeater" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>
<telerik:RadCodeBlock ID="AttachRCB" runat="server" >
      <script type="text/javascript">
          //called from open radwindow for attachment
          function refreshParentCapSum(inArgs) {
          try
          {
              $find("<%=RadAjaxManager.GetCurrent(Page).ClientID %>").ajaxRequest(inArgs);
          }
          catch (e) { }
          
          }
      </script>  
</telerik:RadCodeBlock>    
<div id="ErrorText" runat="server" visible="false" style="overflow:visible;border: solid 1px Red;color:Red;width: 100%;">
</div>
<telerik:RadAjaxLoadingPanel ID="CapSumRALP" runat="server" />     
<telerik:RadAjaxPanel ID="CapSumRadPanel" runat="server">
    <div id="DivLocationHeader" class="formTableSectionDiv" runat="server" style="margin-left: 10px;margin-right:30px;margin-top:2px;margin-bottom:5px;padding:8px;background-color:#003399;width: 480px;">
        <asp:LinkButton ID="btnLBEditSelected" runat="server" CommandName="Edit" ForeColor="White" OnCommand="EditView_Click" >
            <img id="imgEdit" runat="server" style="border:0px;vertical-align:middle;" alt="" src="../images/Edit.gif" />
            <asp:Literal ID="litEditText" runat="server" Text="Edit/View Capacities" />
        </asp:LinkButton>
    </div>
    <asp:Repeater id="CapSumRepeater" runat="server">
        <HeaderTemplate>
            <table class="formTable" border="0">
            <tr valign="top" style="height: 10px">
                <td colspan="5"><hr style="color: Black" /></td>
            </tr>
            <tr valign="bottom" >
                <td style="width: 200px">&nbsp;</td>
                <td colspan="2" align="center"><b>Licensed</b></td>
                <td colspan="2" align="center"><b>Non-Licensed</b></td>
            </tr>
            <tr valign="bottom" >
                <td style="width: 200px"><b>Location</b></td>
                <td style="width: 70px" align="center"><b>Beds</b></td>
                <td style="width: 70px" align="center"><b>Rooms</b></td>
                <td style="width: 70px" align="center"><b>Beds</b></td>
                <td style="width: 70px" align="center"><b>Rooms</b></td>
            </tr>
            <tr valign="top" style="height: 10px">
                <td colspan="5"><hr style="color: Black" /></td>
            </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td> <%# DataBinder.Eval( Container.DataItem, "Location" )%> </td>
                <td align="right" style="padding-right: 20px;"> <%# DataBinder.Eval( Container.DataItem, "LicBeds" )%> </td>
                <td align="right" style="padding-right: 20px;"> <%# DataBinder.Eval( Container.DataItem, "LicRooms" )%> </td>
                <td align="right" style="padding-right: 20px;"> <%# DataBinder.Eval( Container.DataItem, "NonLicBeds" )%> </td>
                <td align="right" style="padding-right: 20px;"> <%# DataBinder.Eval( Container.DataItem, "NonLicRooms" )%> </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</telerik:RadAjaxPanel>
<telerik:RadWindowManager ID="BedSummRadWinMan" runat="server" Style="z-index: 9999" >
    <Windows>
        <telerik:RadWindow ID="BedSumRadWin" runat="server" VisibleOnPageLoad="true" Behaviors="Minimize, Move, Resize, Maximize"
                           VisibleStatusbar="false" Visible="false"  />
    </Windows>
</telerik:RadWindowManager>
