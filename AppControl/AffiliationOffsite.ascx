<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AffiliationOffsite.ascx.cs" Inherits="AppControl.AffiliationOffsite" %>

<telerik:RadCodeBlock ID="OffsiteRCB" runat="server" >
      <script type="text/javascript">
          //called from open radwindow for attachment
          function refreshParentAffilList(inArgs) {
              $find("<%=RadAjaxManager.GetCurrent(Page).ClientID %>").ajaxRequest(inArgs);
          }
          function ConfirmDelete() {
              var retVal = confirm("Are you sure you want to remove the selected Offsite/Affiliation?");

              if (retVal) {
                  return true;
              }
              else {
                  return false;
              }
          }
      </script>  
</telerik:RadCodeBlock>
<telerik:RadAjaxManagerProxy ID="AffilRAM" runat="server">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="AffiliationRepeater">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="AffiliationRadWinMan" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="AffiliationRepeater">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="AffilRadPanel" LoadingPanelID="AffilRLP"/>
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>
<telerik:RadAjaxLoadingPanel ID="AffilRLP" runat="server" />
<div id="DivOwnOtherFacHeader" class="formTableSectionDiv" runat="server">
    Includes all sites being billed under the hospital's provider agreement or any NPI numbers associated with the hospital.
</div>     
<div style="margin-left: 10px;" >
<telerik:RadAjaxPanel ID="AffilRadPanel" runat="server">
    <asp:Repeater ID="AffiliationRepeater" runat="server" OnItemDataBound="AffiliationRepeater_ItemDataBound">
        <HeaderTemplate>
            <table class="formTable" style="border: solid 1px silver;table-layout:fixed;" cellspacing="0" >
                <tr valign="bottom">
                    <th style="width: 60px;border: solid 1px silver;background-color:Silver" align="left" id="ActionHeader" runat="server">&nbsp</th>
                    <th style="width: 60px;border: solid 1px silver;background-color:Silver" align="left">License<br />Number</th>
                    <th style="width: 150px;border: solid 1px silver;background-color:Silver" align="left">Facility<br />Name</th>
                    <th style="width: 150px;border: solid 1px silver;background-color:Silver" align="left">Address</th>
                    <th style="width: 90px;border: solid 1px silver;background-color:Silver" align="center">Phone</th>
                    <th style="width: 90px;border: solid 1px silver;background-color:Silver" align="center">Fax</th>
                    <th style="width: 60px;border: solid 1px silver;background-color:Silver" align="center">Branch ID</th>
                    <th style="width: 120px;border: solid 1px silver;background-color:Silver" align="center">Medicare<br />Branch ID</th>
                    <th style="width: 150px;border: solid 1px silver;background-color:Silver" align="center">Capacity<br />Summary</th>
                    <th style="border: solid 1px silver;background-color:Silver" align="center">Status</th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
                <tr valign="top">
                    <td style="border: solid 1px silver;" id="actioncolumn" runat="server">
                        <asp:LinkButton ID="AffilEditViewAction" runat="server" CommandName='<%# DataBinder.Eval( Container.DataItem, "ViewEditCmdArgs" )%>' 
                                CommandArgument='<%# DataBinder.Eval( Container.DataItem, "ViewEditCmdArgs" )%>' 
                                OnCommand="AffilEditViewAction_Click" Width="60">
                                <%# DataBinder.Eval( Container.DataItem, "ViewEditCmdText" )%>
                        </asp:LinkButton>
                        <asp:LinkButton ID="AffilRemoveAction" CommandName="Remove" runat="server" 
                                CommandArgument='<%# DataBinder.Eval( Container.DataItem, "ViewEditCmdArgs" )%>' 
                                OnCommand="AffilRemoveAction_Click" Width="60" OnClientClick="return ConfirmDelete();">
                                Remove
                        </asp:LinkButton>
                    </td>
                    <td style="border: solid 1px silver;">
                        <asp:Label ID='lblLicNum' runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "LicensureNumber") %>' />&nbsp;
                        <asp:HiddenField ID="hidAffilID" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "AffiliationID") %>' />
                    </td>
                    <td style="border: solid 1px silver;">
                        <asp:Label ID='lblFacName' runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FacilityName") %>' />&nbsp;
                    </td>
                    <td style="border: solid 1px silver;">
                        <asp:Label ID='lblAddress' runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Address") %>' />&nbsp;
                    </td>
                    <td align="center" style="border: solid 1px silver;">
                        <asp:Label ID='lblPhone' runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Phone") %>' />&nbsp;
                    </td>
                    <td align="center" style="border: solid 1px silver;">
                        <asp:Label ID='lblFax' runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Fax") %>' />&nbsp;
                    </td>
                    <td align="center" style="border: solid 1px silver;">
                        <asp:Label ID='lblBranchID' runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "BranchID") %>' />&nbsp;
                    </td>
                    <td align="center" style="border: solid 1px silver;">
                        <asp:Label ID='lblMCareID' runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "MCareID") %>' />&nbsp;
                    </td>
                    <td align="center" style="border: solid 1px silver;">
                        <asp:Label ID='lblCapSum' runat="server" ><%# DataBinder.Eval(Container.DataItem, "CapSum") %></asp:Label>
                    </td>
                    <td style="border: solid 1px silver;">
                        <asp:Label ID='Label1' runat="server" ><%# DataBinder.Eval(Container.DataItem, "BranchStatus")%></asp:Label>
                    </td>
                </tr>
        </ItemTemplate>
        <FooterTemplate>
                <tr>
                    <td colspan="6">
                        <asp:Button ID="AffilAddAction" runat="server" CommandName="Add"
                                CommandArgument="" OnCommand="AffilAddAction_Click" Width="145"
                                Text="New Offsite/Affiliation" Font-Size="11px" Enabled="true" />
                    </td>
                </tr>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</telerik:RadAjaxPanel>    
</div>
<telerik:RadWindowManager ID="AffiliationRadWinMan" runat="server" Style="z-index: 9999" >
    <Windows>
        <telerik:RadWindow ID="AffiliationRadWin" runat="server" VisibleOnPageLoad="true" Behaviors="Minimize, Move, Resize, Maximize"
                           VisibleStatusbar="false" Visible="false" />
    </Windows>
</telerik:RadWindowManager>
