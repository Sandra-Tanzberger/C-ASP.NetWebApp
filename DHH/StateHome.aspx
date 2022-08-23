<%@ Page Title="" Language="C#" MasterPageFile="~/State.Master" AutoEventWireup="true" CodeBehind="StateHome.aspx.cs" Inherits="DHH.StateHome" %>

<asp:Content ID="MenuContentMain" ContentPlaceHolderID="Left_Menu_Content" Runat="Server">
    <telerik:RadAjaxManagerProxy ID="StHomeRAMP" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="optCheckLogAll">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="Top_Pane"  LoadingPanelID="RLP" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="optCheckLogInProcess">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="Top_Pane"  LoadingPanelID="RLP" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="optCheckLogNonApplication">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="Top_Pane"  LoadingPanelID="RLP" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="dateFilter">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="Top_Pane"  LoadingPanelID="RLP" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="MenuPanelBar">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="DetailContentMain" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="grdContent">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="Top_Pane" LoadingPanelID="RLP" />
                    <telerik:AjaxUpdatedControl ControlID="DetailContentMain" />
                    <telerik:AjaxUpdatedControl ControlID="grdContent" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnView">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="Top_Pane" LoadingPanelID="RLP" />
                    <telerik:AjaxUpdatedControl ControlID="RadWindowManager1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnPrintSelected">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="Top_Pane" LoadingPanelID="RLP" />
                    <telerik:AjaxUpdatedControl ControlID="RadWindowManager1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnResend">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="Top_Pane" LoadingPanelID="RLP" />
                    <telerik:AjaxUpdatedControl ControlID="RadWindowManager1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnAdd">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="Top_Pane" LoadingPanelID="RLP" />
                    <telerik:AjaxUpdatedControl ControlID="RadWindowManager1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnUpdate">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="Top_Pane" LoadingPanelID="RLP" />
                    <telerik:AjaxUpdatedControl ControlID="RadWindowManager1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnAddLOI">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="Top_Pane" LoadingPanelID="RLP" />
                    <telerik:AjaxUpdatedControl ControlID="RadWindowManager1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnAddRFA">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="Top_Pane" LoadingPanelID="RLP" />
                    <telerik:AjaxUpdatedControl ControlID="RadWindowManager1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnAddCER">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="Top_Pane" LoadingPanelID="RLP" />
                    <telerik:AjaxUpdatedControl ControlID="RadWindowManager1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnMatch">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="Top_Pane" LoadingPanelID="RLP" />
                    <telerik:AjaxUpdatedControl ControlID="RadWindowManager1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnBatchPIV">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="Top_Pane" LoadingPanelID="RLP" />
                    <telerik:AjaxUpdatedControl ControlID="RadWindowManager1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnGridUserDoAction">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="Top_Pane" LoadingPanelID="RLP" />
                    <telerik:AjaxUpdatedControl ControlID="RadWindowManager1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="LinkButtonView">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="Top_Pane" LoadingPanelID="RLP" />
                    <telerik:AjaxUpdatedControl ControlID="RadWindowManager1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="grdContent">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="Top_Pane" LoadingPanelID="RLP" />
                    <telerik:AjaxUpdatedControl ControlID="RadWindowManager1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
    <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">  
        <script type="text/javascript">
            function rowDoubleClick(sender, eventArgs) {
                __doPostBack("<%= this.UniqueID %>", "RowDoubleClicked:" + eventArgs.get_itemIndexHierarchical());
            }

            function refreshParent(inArgs) {
                $find("<%=RadAjaxManager.GetCurrent(Page).ClientID %>").ajaxRequest(inArgs);
            }

            function SelectGridRow(RowIndex, GridAction) {
                //alert(RowIndex);
                var masterTable = $find("<%= grdContent.ClientID %>").get_masterTableView();
                var rows = masterTable.get_dataItems();

                for (i = 0; i < rows.length; i++) {
                    masterTable.get_dataItems()[i].set_selected(false);
                }

                masterTable.get_dataItems()[RowIndex].set_selected("true");

                if (GridAction == "DELETE") {
                    var retVal = confirm("Are you sure you want to delete the selected record?");

                    if (retVal) {
                        return true;
                    }
                    else {
                        return false;
                    }
                }
            }

            function CheckLogConfirmDelete() {
                var selecteditem = $find("<%= grdContent.MasterTableView.ClientID %>").get_selectedItems();

                if (!selecteditem.length > 0) {
                    alert('Please select at least one record to edit');
                }
                else {
                    return confirm("Do you really want to delete the selected record(s)?");
                }
            }
           
        </script> 
    </telerik:RadScriptBlock> 
    <telerik:RadPanelBar ID="MenuPanelBar" runat="server" 
                         ExpandMode="FullExpandedItem"
                         Height="100%" 
                         Width="100%"
                         BackColor="#336699" 
                         CollapseDelay="50" 
                         ExpandDelay="10" 
                         CollapseAnimation-Duration="100" 
                         ExpandAnimation-Duration="100" 
                         OnItemClick="MenuPanelBar_ItemClick"
                         OnItemCreated="MenuPanelBar_ItemCreated"
                         AllowCollapseAllItems="true"
                         >
        <Items>
            <telerik:RadPanelItem PostBack="false" Font-Bold="true" Text="Current User" Expanded="false" Value="UserProfile">
                <Items><telerik:RadPanelItem>
                <ItemTemplate>
                    <asp:Panel ID="UserPanel" runat="server" BackColor="#cccccc">
                        <table border="0">
                            <tr>
                                <td align="right" valign="top" style="width:75px"><asp:Label ID="litUserID" runat="server" Font-Size="10pt" Text="Login: " ForeColor="Black" /></td>
                                <td><asp:Label ID="CurrentUserID" runat="server" Text="" ForeColor="Black" Font-Size="10pt" /></td>
                            </tr>
                            <tr>
                                <td align="right" valign="top"><asp:Label ID="Label1" runat="server" Font-Size="10pt" Text="Name: " ForeColor="Black" /></td>
                                <td><asp:Label ID="CurrentUserName" runat="server" Text="" ForeColor="Black" Font-Size="10pt" /><br /></td>
                            </tr>
                            <tr>
                                <td align="right" valign="top"><asp:Label ID="Label2" runat="server" Font-Size="10pt" Text="Staff Type(s): " ForeColor="Black" /></td>
                                <td valign="top"><asp:Label ID="CurrentStaffTypes" runat="server" Text="" ForeColor="Black" Font-Size="10pt" /></td>
                            </tr>
                        </table>
                    </asp:Panel>
                </ItemTemplate>
                </telerik:RadPanelItem></Items>
            </telerik:RadPanelItem>
            <telerik:RadPanelItem PostBack="false" Font-Bold="true" Text="Letter of Intent" Expanded="false">
                <Items>
                    <telerik:RadPanelItem runat="server" Text="All" Value="ALL" Expanded="false" />
                    <telerik:RadPanelItem runat="server" Text="New Provider" Value="LOI" Expanded="false" />
                    <telerik:RadPanelItem runat="server" Text="Offsite Addition" Value="LOI_OA" Expanded="false" />
                    <telerik:RadPanelItem runat="server" Text="Request for Access" Value="RFA" Expanded="false" />
                    <telerik:RadPanelItem runat="server" Text="Certified Only" Value="CER" Expanded="false" />
                </Items>
            </telerik:RadPanelItem>
            <telerik:RadPanelItem PostBack="false" Font-Bold="true" Text="Program" Expanded="true" />
            <telerik:RadPanelItem PostBack="false" Font-Bold="true" Text="Process" Expanded="false" />
            <telerik:RadPanelItem PostBack="false" Font-Bold="true" Text="Reports" Expanded="false" />
            <telerik:RadPanelItem PostBack="false" Font-Bold="true" Text="Letters" Expanded="false">
                <Items>
                    <telerik:RadPanelItem runat="server" Text="Bulk Letter Queue" Value="LETTERQUEUE" Expanded="false" />
                </Items>            
            </telerik:RadPanelItem>
            <telerik:RadPanelItem PostBack="false" Font-Bold="true" Text="Accounting" Expanded="false" >
                <Items>
                    <telerik:RadPanelItem runat="server" Text="Check Log View" Value="CheckLogView" Expanded="false" />
                    <telerik:RadPanelItem runat="server" Text="Check Log Report" Value="CheckLogReport" Expanded="false" />
                    <telerik:RadPanelItem runat="server" Text="Check Log Unlinked Payments Report" Value="CheckLogUnlinkedPayments" Expanded="false" />
                    <telerik:RadPanelItem runat="server" Text="Charges Report" Value="CHARGESREPORT" Expanded="false" />
                    <telerik:RadPanelItem runat="server" Text="Payments Report" Value="PAYMENTSREPORT" Expanded="false" />
                    <telerik:RadPanelItem runat="server" Text="Online Payments Report" Value="ONLINEPAYMENTSREPORT" Expanded="false" />
                    <telerik:RadPanelItem runat="server" Text="Transaction Report" Value="TransactionReport" Expanded="false" />
                </Items>            
            </telerik:RadPanelItem>
            <telerik:RadPanelItem PostBack="false" Font-Bold="true" Text="Admin" Expanded="false">
                <Items>
                    <telerik:RadPanelItem runat="server" Text="Staff" Value="ProgramStaff" Expanded="false" />
                </Items>            
            </telerik:RadPanelItem>
        </Items>
    </telerik:RadPanelBar>
</asp:Content>
<asp:Content ID="DetailContentMain" ContentPlaceHolderID="Right_Content" Runat="Server">
    <telerik:RadCodeBlock ID="RCB" runat="server">
        <script type="text/javascript">
            var embededGridID = "<%=grdContent.ClientID %>";
            var checkLogViewTypeID = "<%=divCheckLogViewType.ClientID %>";
        </script>
    </telerik:RadCodeBlock>
    <telerik:RadAjaxLoadingPanel ID="RLP" runat="server" />
    <telerik:RadAjaxPanel ID="Top_Pane" runat="server" Scrolling="None" Height="100%">
        <div id="divCheckLogViewType" runat="server" class="ClassOpt" >
          <asp:Label ID="viewID" runat="server" Text="View:" />&nbsp;&nbsp;
            <asp:RadioButton ID="optCheckLogAll" runat="server" GroupName="optCheckLogView" Text="All" Checked="true" AutoPostBack="true" OnCheckedChanged="onCheckLogViewFilterChanged" />&nbsp;&nbsp;
            <asp:RadioButton ID="optCheckLogInProcess" runat="server" GroupName="optCheckLogView" Text="License-Related Applications" AutoPostBack="true" OnCheckedChanged="onCheckLogViewFilterChanged" />&nbsp;&nbsp;
            <asp:RadioButton ID="optCheckLogNonApplication" runat="server" GroupName="optCheckLogView" Text="Non License-Related Applications" AutoPostBack="true" OnCheckedChanged="onCheckLogViewFilterChanged" />
            &nbsp;&nbsp;
            <asp:DropDownList ID="dateFilter" runat="server" AutoPostBack="true" OnSelectedIndexChanged="onCheckLogViewFilterChanged">
                <asp:ListItem value="ALL">All</asp:ListItem>
                <asp:ListItem value="LAST30" Selected="True">Last 30 Days</asp:ListItem>
                <asp:ListItem value="LAST90">Last 90 Days</asp:ListItem>
                <asp:ListItem value="LAST120">Last 120 Days</asp:ListItem>
                <asp:ListItem value="GREATERTHAN120">&gt; 120 Days</asp:ListItem>
            </asp:DropDownList>
        </div>
        <telerik:RadGrid ID="grdContent" runat="server" 
                         Height="99.5%" AutoGenerateColumns="false"
                         OnNeedDataSource="grdContent_NeedDataSource"
                         OnItemDataBound="grdContent_ItemDataBound" 
                         OnItemCommand="grdContent_ItemCommand" 
                         OnItemCreated="grdContent_ItemCreated"
                         OnPreRender="grdContent_PreRender"
                         AllowFilteringByColumn="true"
                         GroupingSettings-CaseSensitive="false">
            <MasterTableView CommandItemDisplay="Top" AllowSorting="true" TableLayout="Fixed" >
                <CommandItemTemplate>
                    <telerik:RadComboBox ID="cboGridUserAction" runat="server" Width="300px" >
                        <Items>
                            <telerik:RadComboBoxItem Text="New Letter of Intent - Initial Licensure" Value="AddLOI" />
                            <%--<telerik:RadComboBoxItem Text="New Letter of Intent - Offsite Addition" Value="AddLOI_OA" />--%>
                            <telerik:RadComboBoxItem Text="New Request for Access" Value="AddRFA" />
                            <telerik:RadComboBoxItem Text="New Certified Only Letter" Value="AddCER" />
                        </Items>
                    </telerik:RadComboBox>
                    <asp:Button ID="btnGridUserDoAction" runat="server" Text="Generate" CommandName="Generate"/>
                    <asp:LinkButton ID="btnView" runat="server" CommandName="View">
                        <img style="border:0px;vertical-align:middle;" alt="" src="../../images/view.png" />
                        View
                    </asp:LinkButton>&nbsp;&nbsp;
                    <asp:LinkButton ID="btnPrintSelected" runat="server" CommandName="Print" >
                        <img style="border:0px;vertical-align:middle;" alt="" src="../../images/Print.gif" />
                        Print Selected Letters
                    </asp:LinkButton>&nbsp;&nbsp;
                    <asp:LinkButton ID="btnResend" runat="server" CommandName="ReSend" >
                        <img style="border:0px;vertical-align:middle;" alt="" src="../../images/mail.gif" />
                        Resend Selected Letters
                    </asp:LinkButton>
                    <asp:LinkButton ID="btnAdd" runat="server" CommandName="Add" >
                        <img style="border:0px;vertical-align:middle;" alt="" src="../../images/AddRecord.gif" />
                        Add
                    </asp:LinkButton>&nbsp;&nbsp;
                    <asp:LinkButton ID="btnUpdate" runat="server" CommandName="Update" >
                        <img style="border:0px;vertical-align:middle;" alt="" src="../../images/Update.gif" />
                        Update
                    </asp:LinkButton>&nbsp;&nbsp;
                    <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" OnClientClick="if (!confirm('Are you sure you want to delete selected IDR?')) return false;">
                        <img style="border:0px;vertical-align:middle;" alt="" src="../../images/Delete.gif" />
                        Delete
                    </asp:LinkButton>&nbsp;&nbsp;
                    <asp:LinkButton ID="btnDeleteCheckLog" runat="server" CommandName="DeleteCheckLog" OnClientClick="return CheckLogConfirmDelete();">
                        <img style="border:0px;vertical-align:middle;" alt="" src="../../images/Delete.gif" />
                        Delete Selected
                    </asp:LinkButton>&nbsp;&nbsp;
                    <asp:LinkButton ID="btnAddLOI" runat="server" CommandName="AddLOI" Visible="false" >
                        <img style="border:0px;vertical-align:middle;" alt="" src="../../images/AddRecord.gif" />
                        New Letter of Intent
                    </asp:LinkButton>&nbsp;&nbsp;
                    <asp:LinkButton ID="btnAddRFA" runat="server" CommandName="AddRFA" Visible="false" >
                        <img style="border:0px;vertical-align:middle;" alt="" src="../../images/AddRecord.gif" />
                        New Request for Access
                    </asp:LinkButton>&nbsp;&nbsp;                
                    <asp:LinkButton ID="btnAddCER" runat="server" CommandName="AddCER" Visible="false" >
                        <img style="border:0px;vertical-align:middle;" alt="" src="../../images/AddRecord.gif" />
                        New Certified Only Letter
                    </asp:LinkButton>&nbsp;&nbsp;                
                    <asp:LinkButton ID="btnMatch" runat="server" CommandName="Match" >
                        <img style="border:0px;vertical-align:middle;" alt="" src="../../images/link.gif" />
                        Match Selected Letter
                    </asp:LinkButton>&nbsp;&nbsp;
                    <asp:LinkButton ID="btnBatchPIV" runat="server" CommandName="Batch" >
                        <img style="border:0px;vertical-align:middle;" alt="" src="../../images/Update.gif" />
                        Batch Update PIV
                    </asp:LinkButton>&nbsp;&nbsp;
                </CommandItemTemplate>
                <Columns>
                    <telerik:GridClientSelectColumn UniqueName="CheckboxSelectColumn" Visible="true">
                        <HeaderStyle Width="50"  />
                    </telerik:GridClientSelectColumn>
                    <telerik:GridTemplateColumn UniqueName="Actions" HeaderText="" 
                        HeaderStyle-Wrap="true" HeaderStyle-Width="55px" AllowFiltering="false" >
                        <ItemTemplate>
                            <asp:LinkButton runat="server" ID="LinkButtonView" CommandName="View" >View</asp:LinkButton><br />
                            <asp:LinkButton runat="server" ID="LinkButtonMatch" CommandName="Match" >Match</asp:LinkButton><br />
                            <asp:LinkButton runat="server" ID="LinkButtonDelete" CommandName="Delete" >Delete</asp:LinkButton><br />
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>    
                </Columns>
            </MasterTableView>
            <ClientSettings>
                <ClientEvents OnRowDblClick="rowDoubleClick" /> 
            </ClientSettings>
        </telerik:RadGrid>
</telerik:RadAjaxPanel>
<telerik:RadWindowManager ID="RadWindowManager1" runat="server" Modal="true" VisibleOnPageLoad="false" ShowContentDuringLoad="true" Behaviors="None">
    <Windows>
        <telerik:RadWindow ID="RadWin1" runat="server" VisibleOnPageLoad="false"></telerik:RadWindow>
    </Windows>
</telerik:RadWindowManager>

</asp:Content>