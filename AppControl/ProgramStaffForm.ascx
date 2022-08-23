<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProgramStaffForm.ascx.cs" Inherits="AppControl.ProgramStaffForm" %>
  <telerik:RadAjaxManagerProxy ID="GroupsProxy" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="btnDeleteGroups">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="grdDeleteGroups" LoadingPanelID="DeleteGroupsLoadingPanel" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
       <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="btnAddGroups">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="grdDeleteGroups" LoadingPanelID="AddGroupsLoadingPanel" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
      <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="btnProgramStaffInsert">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="grdDeleteGroups" LoadingPanelID="DeleteGroupsLoadingPanel" />
                     <telerik:AjaxUpdatedControl ControlID="grdAddGroups" LoadingPanelID="AddGroupsLoadingPanel" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>

<telerik:RadCodeBlock ID="RCB_ApplicationPrint" runat="server">
<script type="text/javascript">
    function GetRadWindow() {
        var oWindow = null;
        if (window.radWindow)
            oWindow = window.radWindow;
        else if (window.frameElement.radWindow)
            oWindow = window.frameElement.radWindow;
        return oWindow;
    }

    function Close() {
        var oWindow = GetRadWindow();
        oWindow.argument = null;
        oWindow.close();
        return false;
    }
    function DeleteSelected() {
        var selecteditem = $find("<%= grdDeleteGroups.MasterTableView.ClientID %>").get_selectedItems();
        if (!selecteditem.length > 0) {
            alert('Please select at least one record to delete.');
        }
    }
    function AddSelected() {
        var selecteditem = $find("<%= grdAddGroups.MasterTableView.ClientID %>").get_selectedItems();
        if (!selecteditem.length > 0) {
            alert('Please select at least one record to add.');
        }
    }
</script>
</telerik:RadCodeBlock>
 
 
<div id="ErrorText" runat="server" visible="false" style="overflow:visible;border: solid 1px Red;color:Red;width: 100%;">
</div>
<div style="background-color: #EDE99E;" >
<asp:Table ID="ProgramStaffTable" CssClass="formTable" BorderWidth="0" runat="server">
    <asp:TableRow>
        <asp:TableCell VerticalAlign="Bottom" Width="100" HorizontalAlign="Right">
            <asp:Label ID="lblFirstName" runat="server" Text="First Name: " />
        </asp:TableCell><asp:TableCell VerticalAlign="Bottom" Width="120" HorizontalAlign="Left">
            <asp:TextBox ID="txtFirstName" runat="server" MaxLength="15" ></asp:TextBox>
        </asp:TableCell><asp:TableCell VerticalAlign="Bottom" Width="100" HorizontalAlign="Right">
            <asp:Label ID="lblLastName" runat="server" Text="Last Name: " />
        </asp:TableCell><asp:TableCell VerticalAlign="Bottom" Width="120" HorizontalAlign="Left">
            <asp:TextBox ID="txtLastName" runat="server" MaxLength="20" ></asp:TextBox>
        </asp:TableCell><asp:TableCell VerticalAlign="Bottom" HorizontalAlign="Right">
            <asp:Label ID="lblloginid" runat="server" Text="Login ID: "></asp:Label>
         </asp:TableCell><asp:TableCell VerticalAlign="Bottom" HorizontalAlign="Left" ColumnSpan="5">
            <asp:TextBox ID="txtloginid" runat="server" MaxLength="55" Width="350"></asp:TextBox>
        </asp:TableCell></asp:TableRow><asp:TableRow>
        <asp:TableCell ColumnSpan="2" HorizontalAlign="Left">
            <asp:button id="btnProgramStaffUpdate" text="Update" runat="server" OnClick="ProgramStaff_Update" Visible="false" />
            <asp:button id="btnProgramStaffInsert" text="Save" runat="server" OnClick="ProgramStaff_Insert" Visible="false"/>
            &nbsp;
            <asp:button id="btnProgramStaffCancel" text="Cancel" runat="server" OnClientClick="Close()" causesvalidation="False" ></asp:button>
        </asp:TableCell>
</asp:TableRow>
</asp:Table>
</div>
<asp:Table id="GroupsGrids" runat="server" Visible="false">
    <asp:TableRow>
        <asp:TableCell>

<div id="DeleteGroupsGridHeader" class="formTableSectionDiv" runat="server">
            Staff Application Access Groups - Current Group Assignments
            <br />PBG = delete access.
            <br />SUR = read only access
            <br />ADMIN = staff entry access</div>
        <telerik:RadAjaxLoadingPanel ID="DeleteGroupsLoadingPanel" runat="server" />
            <telerik:RadGrid ID="grdDeleteGroups" runat="server" 
                                AutoGenerateColumns="false"
                                OnItemCommand="grdDeleteGroups_ItemCommand" 
                                AllowFilteringByColumn="false"
                                GroupingSettings-CaseSensitive="false"
                                AllowMultiRowSelection="true" OnNeedDataSource="DeleteGroups_NeedsDataSource" EnableViewState="true">
                <MasterTableView CommandItemDisplay=Top AllowSorting="true" TableLayout="Auto" EnableViewState="true">
                    <CommandItemTemplate>  
                        <asp:LinkButton ID="btnDeleteGroups" runat="server" CommandName="Delete" OnClientClick="DeleteSelected()">
                            <img style="border:0px;vertical-align:middle;" alt="" src="../../images/Delete.gif" />
                            Delete Selected
                        </asp:LinkButton>&nbsp;&nbsp;</CommandItemTemplate><Columns>
                       
                    </Columns>
                </MasterTableView>
                <ClientSettings>
                        <Selecting AllowRowSelect="True"></Selecting>
                        <Scrolling AllowScroll="True" UseStaticHeaders="True" SaveScrollPosition="false">
                    </Scrolling>
                    </ClientSettings>
            </telerik:RadGrid>

<div id="AddGroupsGridHeader" class="formTableSectionDiv" runat="server">
            Staff Application Access Groups - All Groups
            <br />PBG = delete access.
            <br />SUR = read only access
            <br />ADMIN = staff entry access</div>
     <telerik:RadAjaxLoadingPanel ID="AddGroupsLoadingPanel" runat="server" />
        <telerik:RadGrid ID="grdAddGroups" runat="server" 
                            AutoGenerateColumns="false"
                            OnItemCommand="grdAddGroups_ItemCommand" 
                            AllowFilteringByColumn="false"
                            GroupingSettings-CaseSensitive="false"
                            AllowMultiRowSelection="true" OnNeedDataSource="AddGroups_NeedsDataSource" EnableViewState="true">
            <MasterTableView CommandItemDisplay=Top AllowSorting="true" TableLayout="Auto" EnableViewState="true">
                <CommandItemTemplate>  
                    <asp:LinkButton ID="btnAddGroups" runat="server" CommandName="Add" OnClientClick="AddSelected()">
                        <img style="border:0px;vertical-align:middle;" alt="" src="../../images/AddRecord.gif" />
                        Add Selected
                    </asp:LinkButton>
                </CommandItemTemplate><Columns>
                   
                </Columns>
            </MasterTableView>
            <ClientSettings>
                    <Selecting AllowRowSelect="True"></Selecting>
                    <Scrolling AllowScroll="True" UseStaticHeaders="True" SaveScrollPosition="false">
                </Scrolling>
                </ClientSettings>
        </telerik:RadGrid>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>