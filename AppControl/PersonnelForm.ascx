<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PersonnelForm.ascx.cs" Inherits="AppControl.PersonnelForm" %>
<telerik:RadCodeBlock ID="RCB_PersonnelForm" runat="server">
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
        
        function EducationConfirmDelete() {
            var selecteditem = $find("<%= grdEducation.MasterTableView.ClientID %>").get_selectedItems();

          if (!selecteditem.length > 0) {
              alert('Please select at least one record to edit');
          }
          else {
              return confirm("Do you really want to delete this record?");
          }
        }

        function EducationCheckSelected() {
            var selecteditem = $find("<%= grdEducation.MasterTableView.ClientID %>").get_selectedItems();
            if (!selecteditem.length > 0) {
                alert('Please select at least one record to edit');
            }
        }

        function EmploymentConfirmDelete() {
            var selecteditem = $find("<%= grdEmployment.MasterTableView.ClientID %>").get_selectedItems();

            if (!selecteditem.length > 0) {
                alert('Please select at least one record to edit');
            }
            else {
                return confirm("Do you really want to delete this record?");
            }
        }

        function EmploymentCheckSelected() {
            var selecteditem = $find("<%= grdEmployment.MasterTableView.ClientID %>").get_selectedItems();
            if (!selecteditem.length > 0) {
                alert('Please select at least one record to edit');
            }
        }
    </script> 
</telerik:RadCodeBlock>
 
<telerik:RadAjaxManagerProxy ID="RadAjaxManagerEducation" runat="server">  
        <AjaxSettings>  
            <telerik:AjaxSetting AjaxControlID="grdEducation">  
                <UpdatedControls>  
                    <telerik:AjaxUpdatedControl ControlID="grdEducation" LoadingPanelID="EducationLoadingPanel" />  
                </UpdatedControls>  
            </telerik:AjaxSetting>  
            <telerik:AjaxSetting AjaxControlID="RadAjaxManagerEducation">  
                <UpdatedControls>  
                    <telerik:AjaxUpdatedControl ControlID="grdEducation" LoadingPanelID="EducationLoadingPanel" />  
                </UpdatedControls>  
            </telerik:AjaxSetting>  
            <telerik:AjaxSetting AjaxControlID="btnAddEducation">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadWindowManagerEducation" LoadingPanelID="EducationLoadingPanel" />
                </UpdatedControls>
            </telerik:AjaxSetting>
             <telerik:AjaxSetting AjaxControlID="btnEditEducation">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadWindowManagerEducation" LoadingPanelID="EducationLoadingPanel" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>  
    </telerik:RadAjaxManagerProxy>  
    
    <telerik:RadAjaxManagerProxy ID="RadAjaxManagerEmployment" runat="server">  
        <AjaxSettings>  
            <telerik:AjaxSetting AjaxControlID="grdEmployment">  
                <UpdatedControls>  
                    <telerik:AjaxUpdatedControl ControlID="grdEmployment" LoadingPanelID="EmploymentLoadingPanel" />  
                </UpdatedControls>  
            </telerik:AjaxSetting>  
            <telerik:AjaxSetting AjaxControlID="RadAjaxManagerEmployment">  
                <UpdatedControls>  
                    <telerik:AjaxUpdatedControl ControlID="grdEmployment" LoadingPanelID="EmploymentLoadingPanel" />  
                </UpdatedControls>  
            </telerik:AjaxSetting>  
            <telerik:AjaxSetting AjaxControlID="btnAddEmployment">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadWindowManagerEmployment" LoadingPanelID="EmploymentLoadingPanel" />
                </UpdatedControls>
            </telerik:AjaxSetting>
             <telerik:AjaxSetting AjaxControlID="btnEditEmployment">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadWindowManagerEmployment" LoadingPanelID="EmploymentLoadingPanel" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>  
    </telerik:RadAjaxManagerProxy>  
 
<div id="ErrorText" runat="server" visible="false" style="overflow:visible;border: solid 1px Red;color:Red;width: 100%;">
</div>
<div style="background-color: #EDE99E;" >
<asp:Table ID="PersonnelTable" CssClass="formTable" BorderWidth="0" runat="server">
    <asp:TableRow>
        <asp:TableCell VerticalAlign="Bottom" Width="100" HorizontalAlign="Right">
            <asp:Label ID="lblFirstName" runat="server" Text="First Name: " />
        </asp:TableCell>
        <asp:TableCell VerticalAlign="Bottom" Width="120" HorizontalAlign="Left">
            <asp:TextBox ID="txtFirstName" runat="server" MaxLength="15" ></asp:TextBox>
        </asp:TableCell>
        <asp:TableCell VerticalAlign="Bottom" Width="100" HorizontalAlign="Right">
            <asp:Label ID="lblMiddleInit" runat="server" Text="Middle Initial: " />
        </asp:TableCell>
        <asp:TableCell VerticalAlign="Bottom" Width="120" HorizontalAlign="Left">
            <asp:TextBox ID="txtMiddleInt" runat="server" MaxLength="1" ></asp:TextBox>
        </asp:TableCell>
        <asp:TableCell VerticalAlign="Bottom" Width="100" HorizontalAlign="Right">
            <asp:Label ID="lblLastName" runat="server" Text="Last Name: " />
        </asp:TableCell>
        <asp:TableCell VerticalAlign="Bottom" Width="120" HorizontalAlign="Left">
            <asp:TextBox ID="txtLastName" runat="server" MaxLength="20" ></asp:TextBox>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell VerticalAlign="Bottom" HorizontalAlign="Right">
            <asp:Label ID="lblPhone" runat="server">Phone Number: </asp:Label>
        </asp:TableCell>
        <asp:TableCell  VerticalAlign="Bottom" HorizontalAlign="Left">
            <telerik:RadMaskedTextBox ID="txtPhone" runat="server" Mask="(###) ###-####" />
        </asp:TableCell>
        <asp:TableCell VerticalAlign="Bottom" HorizontalAlign="Right">
            <asp:Label ID="lblFax" runat="server">Fax Number: </asp:Label>
        </asp:TableCell>
        <asp:TableCell VerticalAlign="Bottom" HorizontalAlign="Left" ColumnSpan="3">
            <telerik:RadMaskedTextBox ID="txtFax" runat="server" Mask="(###) ###-####" />
         </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell VerticalAlign="Bottom" HorizontalAlign="Right">
            <asp:Label ID="lblEmail" runat="server">Email Address: </asp:Label>
         </asp:TableCell>
        <asp:TableCell VerticalAlign="Bottom" HorizontalAlign="Left" ColumnSpan="5">
            <asp:TextBox ID="txtEmail" runat="server" MaxLength="55" Width="350"></asp:TextBox>
        </asp:TableCell>
    </asp:TableRow>
     <asp:TableRow>
        <asp:TableCell VerticalAlign="Bottom" HorizontalAlign="Right">
            <asp:Label ID="lblPersonType" runat="server">Personnel Type: </asp:Label>
         </asp:TableCell>
        <asp:TableCell VerticalAlign="Bottom" HorizontalAlign="Left" ColumnSpan="5">
            <asp:DropDownList ID="ddlPersonType" runat="server"></asp:DropDownList>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell ColumnSpan="2" HorizontalAlign="Left">
            <asp:button id="btnPersonnelUpdate" text="Update" runat="server" OnClick="Personnel_Update" Visible="false" />
            <asp:button id="btnPersonnelInsert" text="Save" runat="server" OnClick="Personnel_Insert" Visible="false"/>
            &nbsp;
            <asp:button id="btnPersonnelCancel" text="Cancel" runat="server" OnClientClick="Close()" causesvalidation="False" ></asp:button>
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>


        <div id="EducationGridHeader" class="formTableSectionDiv" runat="server">
            Educational Qualifications
        </div>
        <telerik:RadAjaxLoadingPanel ID="EducationLoadingPanel" runat="server" />

            <telerik:RadGrid ID="grdEducation" runat="server"  
                             AutoGenerateColumns="false"
                             OnItemCommand="grdEducation_ItemCommand" 
                             AllowFilteringByColumn="false"
                             GroupingSettings-CaseSensitive="false"
                             AllowMultiRowSelection="true" OnNeedDataSource="EducationGrid_NeedsDataSource" EnableViewState="true">
                <MasterTableView CommandItemDisplay="Top" AllowSorting="true" TableLayout="Auto" EnableViewState="true">
                    <CommandItemTemplate>
                     <table border="0" width="98%">
                             <tr>
                                <td align="left">
                                    <asp:LinkButton ID="btnAddEducation" runat="server" CommandName="AddEducation">
                                        <img style="border:0px;vertical-align:middle;" alt="" src="../../images/AddRecord.gif" />
                                        Add Education
                                    </asp:LinkButton>&nbsp;&nbsp;
                                     <asp:LinkButton ID="btnEditEducation" runat="server" CommandName="EditEducation" OnClientClick="return EducationCheckSelected();">
                                        <img style="border:0px;vertical-align:middle;" alt="" src="../../images/Edit.gif" />
                                        Edit Selected Education
                                    </asp:LinkButton>
                                     <asp:LinkButton ID="btnDeleteEducation" runat="server" CommandName="DeleteEducation" OnClientClick="return EducationConfirmDelete();">
                                        <img style="border:0px;vertical-align:middle;" alt="" src="../../images/Delete.gif" />
                                        Delete Selected Education
                                    </asp:LinkButton>
                                <td align="right">
                                    <asp:LinkButton ID="btnRefreshEducation" Text="Refresh" CommandName="RebindEducation" runat="server" >  
                                        <img style="border:0px;vertical-align:middle;" alt="" src="../../images/Refresh.gif" />
                                        Refresh
                                    </asp:LinkButton>
                            </td>
                          </tr>
                        </table>
                    </CommandItemTemplate>
                </MasterTableView>
                <ClientSettings EnablePostBackOnRowClick="false">
                       <Selecting AllowRowSelect="True"></Selecting>
                       <Scrolling AllowScroll="True" UseStaticHeaders="True" SaveScrollPosition="false">
                        </Scrolling>
                </ClientSettings>
            </telerik:RadGrid>

        <div id="EmploymentGridHeader" class="formTableSectionDiv" runat="server">
            Employment History
        </div>
        <telerik:RadAjaxLoadingPanel ID="EmploymentLoadingPanel" runat="server" />

            <telerik:RadGrid ID="grdEmployment" runat="server" 
                             AutoGenerateColumns="false"
                             OnItemCommand="grdEmployment_ItemCommand" 
                             AllowFilteringByColumn="false"
                             GroupingSettings-CaseSensitive="false"
                             AllowMultiRowSelection="true" OnNeedDataSource="EmploymentGrid_NeedsDataSource" EnableViewState="true">
                <MasterTableView CommandItemDisplay="Top" AllowSorting="true" TableLayout="Auto" EnableViewState="true">
                    <CommandItemTemplate>
                     <table border="0" width="98%">
                             <tr>
                                <td align="left">
                                    <asp:LinkButton ID="btnAddEmployment" runat="server" CommandName="AddEmployment">
                                        <img style="border:0px;vertical-align:middle;" alt="" src="../../images/AddRecord.gif" />
                                        Add Employment
                                    </asp:LinkButton>&nbsp;&nbsp;
                                     <asp:LinkButton ID="btnEditEmployment" runat="server" CommandName="EditEmployment" OnClientClick="return EmploymentCheckSelected();">
                                        <img style="border:0px;vertical-align:middle;" alt="" src="../../images/Edit.gif" />
                                        Edit Selected Employment
                                    </asp:LinkButton>
                                     <asp:LinkButton ID="btnDeleteEmployment" runat="server" CommandName="DeleteEmployment" OnClientClick="return EmploymentConfirmDelete();">
                                        <img style="border:0px;vertical-align:middle;" alt="" src="../../images/Delete.gif" />
                                        Delete Selected Employment
                                    </asp:LinkButton>
                                <td align="right">
                                    <asp:LinkButton ID="btnRefreshEmployment" Text="Refresh" CommandName="RebindEmployment" runat="server" >  
                                        <img style="border:0px;vertical-align:middle;" alt="" src="../../images/Refresh.gif" />
                                        Refresh
                                    </asp:LinkButton>
                            </td>
                          </tr>
                        </table>
                    </CommandItemTemplate>
                </MasterTableView>
                <ClientSettings EnablePostBackOnRowClick="false">
                       <Selecting AllowRowSelect="True"></Selecting>
                       <Scrolling AllowScroll="True" UseStaticHeaders="True" SaveScrollPosition="false">
                        </Scrolling>
                </ClientSettings>
            </telerik:RadGrid>

  <telerik:RadWindowManager ID="RadWindowManagerEducation" runat="server" Modal="true" VisibleOnPageLoad="false" ShowContentDuringLoad="true">
        <Windows>
            <telerik:RadWindow ID="RadWinEducation" runat="server" VisibleOnPageLoad="false" ></telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>
    
      <telerik:RadWindowManager ID="RadWindowManagerEmployment" runat="server" Modal="true" VisibleOnPageLoad="false" ShowContentDuringLoad="true">
        <Windows>
            <telerik:RadWindow ID="RadWinEmployment" runat="server" VisibleOnPageLoad="false" ></telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>