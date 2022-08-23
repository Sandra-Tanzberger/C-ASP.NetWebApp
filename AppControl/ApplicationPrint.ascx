<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ApplicationPrint.ascx.cs" Inherits="AppControl.ApplicationPrint" %>
  <telerik:RadAjaxManagerProxy ID="ApplicationLetterQueueProxy" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="btnAddToQueue">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="grdAppLetters" LoadingPanelID="ALQP" />
                </UpdatedControls>
            </telerik:AjaxSetting>
           <telerik:AjaxSetting AjaxControlID="btnPrintSelected">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="AppPrintRadWinMan" LoadingPanelID="ALQP" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
<telerik:RadAjaxLoadingPanel ID="ALQP" runat="server" />
<telerik:RadCodeBlock ID="RCB_ApplicationPrint" runat="server">
<script type="text/javascript">
    function CheckSelected() {
        var selecteditem = $find("<%= grdAppLetters.MasterTableView.ClientID %>").get_selectedItems();
        if (!selecteditem.length > 0) {
            alert('Please select at least one letter to print');
        }
    }
</script>
</telerik:RadCodeBlock>

    <telerik:RadGrid ID="grdAppLetters" runat="server" 
                     OnNeedDataSource="grdAppLetters_NeedDataSource"
                     AutoGenerateColumns="false"
                     OnItemCommand="grdAppLetters_ItemCommand" 
                     AllowFilteringByColumn="false"
                     GroupingSettings-CaseSensitive="false"
                     AllowMultiRowSelection="true">
        <MasterTableView CommandItemDisplay="Top" AllowSorting="false" TableLayout="Fixed" GridLines="Vertical">
            <CommandItemTemplate>
                <asp:CheckBox ID="cboPrintLabels" runat="server" />Print Mailing Labels&nbsp;&nbsp;
                <asp:CheckBox ID="cboPrintCover" runat="server" />Print License Cover Letters&nbsp;&nbsp;
                <asp:LinkButton ID="btnPrintSelected" runat="server" CommandName="Print" OnClientClick="CheckSelected()">
                    <img style="border:0px;vertical-align:middle;" alt="" src="../../images/Print.gif" />
                    Print Now
                </asp:LinkButton>&nbsp;&nbsp;
                 <asp:LinkButton ID="btnAddToQueue" runat="server" CommandName="Queue">
                    <img style="border:0px;vertical-align:middle;" alt="" src="../../images/AddRecord.gif" />
                    Add To Queue
                </asp:LinkButton>
            </CommandItemTemplate>
             <Columns>
                <telerik:GridClientSelectColumn UniqueName="LetterCheckboxSelectColumn" Visible="true">
                    <HeaderStyle Width="50"  />
                </telerik:GridClientSelectColumn>
            </Columns>
        </MasterTableView>
        <ClientSettings EnablePostBackOnRowClick="false">
               <Selecting AllowRowSelect="True"></Selecting>
               <Scrolling AllowScroll="True" UseStaticHeaders="True" SaveScrollPosition="true">
                </Scrolling>
        </ClientSettings>
    </telerik:RadGrid>

<telerik:RadWindowManager ID="AppPrintRadWinMan" runat="server" Modal="true" VisibleOnPageLoad="true"></telerik:RadWindowManager>


