<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LetterQueue.ascx.cs" Inherits="AppControl.LetterQueue" %>
  <telerik:RadAjaxManagerProxy ID="LetterQueueProxy" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="btnAddToQueue">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="grdLetterQueue" LoadingPanelID="LQP" />
                    <telerik:AjaxUpdatedControl ControlID="grdLetterSearch" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
<telerik:RadAjaxLoadingPanel ID="LQP" runat="server" />
<telerik:RadCodeBlock ID="RCB_ApplicationPrint" runat="server">
<script type="text/javascript">
    function CheckSelected() {
        var selecteditem = $find("<%= grdLetterQueue.MasterTableView.ClientID %>").get_selectedItems();
        if (!selecteditem.length > 0) {
            alert('Please select at least one letter to print');
        }
    }
</script>
</telerik:RadCodeBlock>
<table>
<tr><td valign="top" style="height:50%;width:100%">

<telerik:RadAjaxPanel ID="LetterQueuePanel" runat="server" Scrolling="None">
    <telerik:RadGrid ID="grdLetterQueue" runat="server" 
                     AutoGenerateColumns="false"
                     OnItemCommand="grdLetterQueue_ItemCommand" 
                     AllowFilteringByColumn="false"
                     GroupingSettings-CaseSensitive="false"
                     AllowMultiRowSelection="true" OnNeedDataSource="LetterQueue_NeedsDataSource" EnableViewState="true">
        <MasterTableView CommandItemDisplay="Top" AllowSorting="true" TableLayout="Auto" EnableViewState="true">
            <CommandItemTemplate>
                <asp:CheckBox ID="cbPrintLabels" runat="server" />Print Mailing Labels&nbsp;&nbsp;
                 <asp:CheckBox ID="cboPrintCover" runat="server" />Print License Cover Letters&nbsp;&nbsp;
                <asp:LinkButton ID="btnPrintSelected" runat="server" CommandName="Print" OnClientClick="CheckSelected()">
                    <img style="border:0px;vertical-align:middle;" alt="" src="../../images/Print.gif" />
                    Print Selected
                </asp:LinkButton>&nbsp;&nbsp;
                 <asp:LinkButton ID="btnClearQueue" runat="server" CommandName="Clear">
                    <img style="border:0px;vertical-align:middle;" alt="" src="../../images/Delete.gif" />
                    Clear Selected
                </asp:LinkButton>
            </CommandItemTemplate>
             <Columns>
                <telerik:GridClientSelectColumn UniqueName="LetterQueueCheckboxSelectColumn" Visible="true">
                    <HeaderStyle Width="50"  />
                </telerik:GridClientSelectColumn>
            </Columns>
        </MasterTableView>
        <ClientSettings EnablePostBackOnRowClick="false">
               <Selecting AllowRowSelect="True"></Selecting>
               <Scrolling AllowScroll="True" UseStaticHeaders="True" SaveScrollPosition="false">
                </Scrolling>
        </ClientSettings>
    </telerik:RadGrid>
</telerik:RadAjaxPanel>
</td></tr>
<tr><td valign="top" style="height:50%;width:100%">
 <telerik:RadAjaxPanel ID="LetterSearchPanel" runat="server" Scrolling="None">
        <telerik:RadGrid ID="grdLetterSearch" runat="server" 
                         AutoGenerateColumns="false"
                         OnItemCommand="grdLetterSearch_ItemCommand" 
                         AllowFilteringByColumn="false"
                         GroupingSettings-CaseSensitive="false"
                         AllowMultiRowSelection="true" OnNeedDataSource="LetterSearch_NeedsDataSource" EnableViewState="true">
            <MasterTableView CommandItemDisplay=Top AllowSorting="true" TableLayout="Auto" EnableViewState="true">
                <CommandItemTemplate>  
                    <asp:LinkButton ID="btnAddToQueue" runat="server" CommandName="Add" >
                        <img style="border:0px;vertical-align:middle;" alt="" src="../../images/AddRecord.gif" />
                        Add Selected
                    </asp:LinkButton>&nbsp;&nbsp;
                    <telerik:RadComboBox ID="cboProgram" runat="server" OnSelectedIndexChanged="cboProgram_SelectedIndexChanged" AutoPostBack="true"></telerik:RadComboBox>&nbsp;&nbsp;
                    <telerik:RadComboBox ID="cboLetterType" runat="server" OnSelectedIndexChanged="cboLetterType_SelectedIndexChanged" AutoPostBack="true"></telerik:RadComboBox>&nbsp;&nbsp;
                    <telerik:RadComboBox ID="cboAnniversaryMonth" runat="server" OnSelectedIndexChanged="cboAnniversaryMonth_SelectedIndexChanged" AutoPostBack="true"></telerik:RadComboBox>&nbsp;&nbsp;
                    <asp:LinkButton ID="lbSearch" runat="server" CommandName="Search" >
                        
                        Search
                    </asp:LinkButton>
                </CommandItemTemplate>
                 <Columns>
                    <telerik:GridClientSelectColumn UniqueName="LetterSearchCheckboxSelectColumn" Visible="true">
                        <HeaderStyle Width="50"  />
                    </telerik:GridClientSelectColumn>
                </Columns>
            </MasterTableView>
            <ClientSettings>
                    <Selecting AllowRowSelect="True"></Selecting>
                    <Scrolling AllowScroll="True" UseStaticHeaders="True" SaveScrollPosition="false">
                </Scrolling>
                </ClientSettings>
        </telerik:RadGrid>
</telerik:RadAjaxPanel>
</td></tr>
</table>
<telerik:RadWindowManager ID="RadWindowManager1" runat="server" Modal="true" VisibleOnPageLoad="false" ShowContentDuringLoad="true" Behaviors="None">
    <Windows>
        <telerik:RadWindow ID="RadWin1" runat="server" VisibleOnPageLoad="false"></telerik:RadWindow>
    </Windows>
</telerik:RadWindowManager>