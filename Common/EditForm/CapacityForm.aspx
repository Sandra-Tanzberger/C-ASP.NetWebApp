<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CapacityForm.aspx.cs" Inherits="Common.EditForm.CapacityForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link href="../../style/PopupMaster.css" rel="stylesheet" type="text/css" />
    <link href="../../style/AtgWebUI.css" rel="stylesheet" type="text/css" />
 </head>
<body style="overflow:auto">
    <form id="form1" runat="server">
        <telerik:RadScriptManager ID="CapacityRSM" runat="server">
            <Scripts>
                <asp:ScriptReference Path="~/Include/Common.js" />
                <asp:ScriptReference Path="~/Include/AtgWebUI.js" />
            </Scripts>
        </telerik:RadScriptManager>
        <telerik:RadAjaxManager ID="CapacityRAM" runat="server">
        </telerik:RadAjaxManager>
        <telerik:RadAjaxLoadingPanel ID="frmRALP" runat="server" />
        <telerik:RadFormDecorator ID="CapacityFormdecorator" runat="server" DecoratedControls="Buttons,CheckBoxes,Label" EnableRoundedCorners="false" />
        <telerik:RadCodeBlock ID="CapacityRCB" runat="server">
            <script type="text/javascript">
                var tmpLicReadOnly;
                
                function pageLoad() {
                    var editMode = document.getElementById("<%= hidEditMode.ClientID %>").value;
                    
                    tmpLicReadOnly = document.getElementById("<%= LicReadOnly.ClientID %>").value;

                    if (tmpLicReadOnly != "RO") {
                        if (editMode == "") {
                            divEditMenu.style.display = "none";
                            divActionMenu.style.display = "block";
                            ErrorText.innerHTML = "";
                            ErrorText.style.display = "none";
                            SetFormReadOnly(true);

                            var gridCtrl = $find("<%=rgBedRecs.ClientID %>");
                            var selRow = gridCtrl.get_masterTableView().get_selectedItems();

                            if (selRow.length > 0) {
                                var MasterTable = gridCtrl.get_masterTableView();
                                MasterTable.get_dataItems();
                                var selectedItem = MasterTable.get_selectedItems()[0];
                                var row = MasterTable.get_dataItems()[selectedItem._itemIndexHierarchical];

                                LoadFormFields(MasterTable, row);
                            }
                            else {
                                ClearFormFields();
                            }
                        }
                        else {
                            divEditMenu.style.display = "block";
                            divActionMenu.style.display = "none";
                            DisableGrid();
                            SetFormReadOnly(false);
                        }
                    }
                    else {
                        SetFormReadOnly(true);
                    }
                }

                function CloseRadWin() {
                    var oWindow = null;
                    if (window.radWindow)
                        oWindow = window.radWindow;
                    else if (window.frameElement.radWindow)
                        oWindow = window.frameElement.radWindow;
                    oWindow.close();
                }
                
                function CloseAndRebind(inArgs) {
                    //var tmpArgs = document.getElementById("hideEventArgsForParent").value;
                    GetRadWindow().BrowserWindow.refreshParentCapSum(''); // Call the function in parent page  
                    GetRadWindow().close(); // Close the window
                }
                
                function GetRadWindow() {
                    var oWindow = null;
                    if (window.radWindow) oWindow = window.radWindow; //Will work in Moz in all cases, including clasic dialog  
                    else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow; //IE (and Moz as well)  

                    return oWindow;
                }

                function SaveCancelClientClick( inMode ) {

                    if (inMode == "Cancel") {
                        document.getElementById("<%= hidEditMode.ClientID %>").value = "";
                        ErrorText.innerHTML = "";
                        ErrorText.style.display = "none";
                        
                        var gridCtrl = $find("<%=rgBedRecs.ClientID %>");
                        var selRow = gridCtrl.get_masterTableView().get_selectedItems();

                        if (selRow.length < 1) {
                            ClearFormFields();
                        }
                        else {
                            gridCtrl.get_masterTableView().get_dataItems();
                            var selectedItem = gridCtrl.get_masterTableView().get_selectedItems()[0];
                            var row = gridCtrl.get_masterTableView().get_dataItems()[selectedItem._itemIndexHierarchical];

                            LoadFormFields(gridCtrl.get_masterTableView(), row);
                        }
                        
                        SetFormReadOnly(true);
                        divEditMenu.style.display = "none";
                        divActionMenu.style.display = "block";
                        EnableGrid();
                        return false;
                    }
                    else {
                        return true;
                    }

                }

                function NewEditClientClick(inMode) {
                    if (tmpLicReadOnly != "RO") {
                        if (inMode == "New") {
                            document.getElementById("<%= hidEditMode.ClientID %>").value = "N";
                            ClearFormFields();
                            var gridCtrl = $find("<%=rgBedRecs.ClientID %>");
                            gridCtrl.get_masterTableView().clearSelectedItems();

                        }
                        else {
                            var gridCtrl = $find("<%=rgBedRecs.ClientID %>");
                            var selRow = gridCtrl.get_masterTableView().get_selectedItems();

                            if (selRow.length > 0) {
                                if (inMode == "Edit") {
                                    document.getElementById("<%= hidEditMode.ClientID %>").value = "E";
                                }
                                else if (inMode == "NewExist") {
                                    document.getElementById("<%= hidEditMode.ClientID %>").value = "NE";
                                    $find("<%= txtRoomNumber.ClientID  %>").set_value("");
                                    $find("<%= txtNumberBeds.ClientID  %>").set_value("");
                                    $find("<%= txtComments.ClientID  %>").set_value("");
                                }
                                else if (inMode == "Remove") {
                                    return ConfirmDelete();
                                }
                            }
                            else {
                                alert("No record selected.");
                                return false;
                            }
                        }

                        SetFormReadOnly(false);
                        divEditMenu.style.display = "block";
                        divActionMenu.style.display = "none";
                        DisableGrid();
                    }
                }

                function ConfirmDelete() {
                    var retVal = confirm("Are you sure you want to remove the selected capacity?");

                    if (retVal) {
                        return true;
                    }
                    else {
                        return false;
                    }
                }

                function SetFormReadOnly(inBool) {

                    var combo = $find("<%= cboServiceType.ClientID %>");

                    if (inBool) {
                        $find("<%= txtUnit.ClientID  %>").disable();
                        combo.disable();
                        $find("<%= txtFloor.ClientID  %>").disable();
                        $find("<%= txtRoomNumber.ClientID  %>").disable();
                        $find("<%= txtNumberBeds.ClientID  %>").disable();
                        $find("<%= txtComments.ClientID  %>").disable();

                        document.getElementById("<%= chkRoomSizeMet.ClientID %>").disabled = true;
                        document.getElementById("<%= ChkCallSysMet.ClientID %>").disabled = true;
                        document.getElementById("<%= ChkFurnitureMet.ClientID %>").disabled = true;
                        document.getElementById("<%= ChkPrivacyMet.ClientID %>").disabled = true;
                    }
                    else {
                        $find("<%= txtUnit.ClientID  %>").enable();
                        combo.enable();
                        $find("<%= txtFloor.ClientID  %>").enable();
                        $find("<%= txtRoomNumber.ClientID  %>").enable();
                        $find("<%= txtNumberBeds.ClientID  %>").enable();
                        $find("<%= txtComments.ClientID  %>").enable();

                        document.getElementById("<%= chkRoomSizeMet.ClientID %>").disabled = false;
                        document.getElementById("<%= ChkCallSysMet.ClientID %>").disabled = false;
                        document.getElementById("<%= ChkFurnitureMet.ClientID %>").disabled = false;
                        document.getElementById("<%= ChkPrivacyMet.ClientID %>").disabled = false;
                    }
                }

                function RowSelected(sender, eventArgs) {
                    var e = eventArgs.get_domEvent();
                    //alert("Row: " + eventArgs.get_itemIndexHierarchical() + " selected.");

                    var MasterTable = sender.get_masterTableView();
                    var row = MasterTable.get_dataItems()[eventArgs.get_itemIndexHierarchical()];
                    LoadFormFields(MasterTable, row);
                }

                function ClearFormFields() {
                    $find("<%= txtUnit.ClientID  %>").set_value("");

                    var combo = $find("<%= cboServiceType.ClientID %>");
                    var item = combo.findItemByText("");

                    if (item) {
                        combo.enable();
                        item.select();
                        combo.disable();
                    }

                    $find("<%= txtFloor.ClientID  %>").set_value("");
                    $find("<%= txtRoomNumber.ClientID  %>").set_value("");
                    $find("<%= txtNumberBeds.ClientID  %>").set_value("");
                    $find("<%= txtComments.ClientID  %>").set_value("");

                    document.getElementById("<%= chkRoomSizeMet.ClientID %>").disabled = false;
                    document.getElementById("<%= ChkCallSysMet.ClientID %>").disabled = false;
                    document.getElementById("<%= ChkFurnitureMet.ClientID %>").disabled = false;
                    document.getElementById("<%= ChkPrivacyMet.ClientID %>").disabled = false;

                    document.getElementById("<%= chkRoomSizeMet.ClientID %>").checked = false;
                    document.getElementById("<%= ChkCallSysMet.ClientID %>").checked = false;
                    document.getElementById("<%= ChkFurnitureMet.ClientID %>").checked = false;
                    document.getElementById("<%= ChkPrivacyMet.ClientID %>").checked = false;

                    document.getElementById("<%= chkRoomSizeMet.ClientID %>").disabled = true;
                    document.getElementById("<%= ChkCallSysMet.ClientID %>").disabled = true;
                    document.getElementById("<%= ChkFurnitureMet.ClientID %>").disabled = true;
                    document.getElementById("<%= ChkPrivacyMet.ClientID %>").disabled = true;

                    document.getElementById("<%= hidUITrackID.ClientID %>").value = "";
                    document.getElementById("<%= hidPopsIntID.ClientID %>").value = "";
                    document.getElementById("<%= hidCapacityID.ClientID %>").value = "";
                }

                function LoadFormFields(inMasterTable, inGridRow) {
                    var BedType = inMasterTable.getCellByColumnUniqueName(inGridRow, "BedsType").innerHTML;
                    var BedLocation = inMasterTable.getCellByColumnUniqueName(inGridRow, "BedsUnit").innerHTML;
                    var BedRoomNum = inMasterTable.getCellByColumnUniqueName(inGridRow, "BedsRoomNumber").innerHTML;
                    var BedFloor = inMasterTable.getCellByColumnUniqueName(inGridRow, "BedsFloor").innerHTML;
                    var BedCapacity = inMasterTable.getCellByColumnUniqueName(inGridRow, "CapacityCount").innerHTML;
                    var BedRmSzMet = inMasterTable.getCellByColumnUniqueName(inGridRow, "BedsRoomSizeMet").innerHTML;
                    var BedCallSysMet = inMasterTable.getCellByColumnUniqueName(inGridRow, "BedsCallSystemMet").innerHTML;
                    var BedFurnMet = inMasterTable.getCellByColumnUniqueName(inGridRow, "BedsFurnitureMet").innerHTML;
                    var BedPrivMet = inMasterTable.getCellByColumnUniqueName(inGridRow, "BedsPrivacyMet").innerHTML;
                    var BedComment = inMasterTable.getCellByColumnUniqueName(inGridRow, "Comments").innerHTML;
                    var BedCapID = inMasterTable.getCellByColumnUniqueName(inGridRow, "CapacityID").innerHTML;
                    var BedPopIntID = inMasterTable.getCellByColumnUniqueName(inGridRow, "PopsIntID").innerHTML;
                    var BedTrackID = inMasterTable.getCellByColumnUniqueName(inGridRow, "UITrackID").innerHTML;

                    $find("<%= txtUnit.ClientID  %>").set_value(BedLocation);

                    var combo = $find("<%= cboServiceType.ClientID %>");
                    var item = combo.findItemByText(BedType);

                    if (item) {
                        combo.enable();
                        item.select();
                        combo.disable();
                    }

                    $find("<%= txtFloor.ClientID  %>").set_value(BedFloor);
                    $find("<%= txtRoomNumber.ClientID  %>").set_value(BedRoomNum);
                    $find("<%= txtNumberBeds.ClientID  %>").set_value(BedCapacity);
                    $find("<%= txtComments.ClientID  %>").set_value(BedComment);

                    document.getElementById("<%= chkRoomSizeMet.ClientID %>").disabled = false;
                    document.getElementById("<%= ChkCallSysMet.ClientID %>").disabled = false;
                    document.getElementById("<%= ChkFurnitureMet.ClientID %>").disabled = false;
                    document.getElementById("<%= ChkPrivacyMet.ClientID %>").disabled = false;

                    document.getElementById("<%= chkRoomSizeMet.ClientID %>").checked = (BedRmSzMet == "Y" ? true : false);
                    document.getElementById("<%= ChkCallSysMet.ClientID %>").checked = (BedCallSysMet == "Y" ? true : false);
                    document.getElementById("<%= ChkFurnitureMet.ClientID %>").checked = (BedFurnMet == "Y" ? true : false);
                    document.getElementById("<%= ChkPrivacyMet.ClientID %>").checked = (BedPrivMet == "Y" ? true : false);

                    document.getElementById("<%= chkRoomSizeMet.ClientID %>").disabled = true;
                    document.getElementById("<%= ChkCallSysMet.ClientID %>").disabled = true;
                    document.getElementById("<%= ChkFurnitureMet.ClientID %>").disabled = true;
                    document.getElementById("<%= ChkPrivacyMet.ClientID %>").disabled = true;

                    document.getElementById("<%= hidPopsIntID.ClientID %>").value = BedPopIntID;
                    document.getElementById("<%= hidCapacityID.ClientID %>").value = BedCapID;
                    document.getElementById("<%= hidUITrackID.ClientID %>").value = BedTrackID;
                }
                
                function DisableGrid() {
                    var gridCtrl = window["<%=rgBedRecs.ClientID %>"];
                    gridCtrl.disabled = "disabled";

                    var elements = $get("rgBedRecs").getElementsByTagName("*");
                    
                    for (var j = 0; j < elements.length; j++) {
                        if (elements[j].tagName && !(elements[j].className == "rcbInput" || (elements[j].tagName.toLowerCase() == "input" && elements[j].type == "hidden")))
                            try {
                                elements[j].disabled = "disabled";
                            }
                            catch (e) { }
                    }

                }
                
                function EnableGrid() {
                    var gridCtrl = window["<%=rgBedRecs.ClientID %>"];
                    gridCtrl.disabled = "";

                    var elements = $get("rgBedRecs").getElementsByTagName("*");

                    for (var j = 0; j < elements.length; j++) {
                        if (elements[j].tagName && !(elements[j].className == "rcbInput" || (elements[j].tagName.toLowerCase() == "input" && elements[j].type == "hidden")))
                            try {
                            elements[j].disabled = "";
                        }
                        catch (e) { }
                    }
                }

                function GridCreated(sender, eventArgs) {
                    //gets the main table scrollArea HTLM element  
                    var scrollArea = document.getElementById(sender.get_element().id + "_GridData");
                    var row = sender.get_masterTableView().get_selectedItems()[0];

                    //if the position of the selected row is below the viewable grid area  
                    if (row) {
                        if ((row.get_element().offsetTop - scrollArea.scrollTop) + row.get_element().offsetHeight + 20 > scrollArea.offsetHeight) {
                            //scroll down to selected row  
                            scrollArea.scrollTop = scrollArea.scrollTop + ((row.get_element().offsetTop - scrollArea.scrollTop) +
                            row.get_element().offsetHeight - scrollArea.offsetHeight) + row.get_element().offsetHeight;
                        }
                        //if the position of the the selected row is above the viewable grid area  
                        else if ((row.get_element().offsetTop - scrollArea.scrollTop) < 0) {
                            //scroll the selected row to the top  
                            scrollArea.scrollTop = row.get_element().offsetTop;
                        }
                    }
                }
                        
            </script>
        </telerik:RadCodeBlock>
        <asp:HiddenField ID="LicReadOnly" runat="server" Value="" />
        <div id="DivFormNavigation" runat="server" style="position:fixed;clear:both;background-color:White;width:99%;padding:3px;border-bottom: solid 1px black;">
            <asp:Button ID="btnExit" runat="server" Text="Exit" OnClientClick="CloseAndRebind(''); return false;" />
            <asp:HiddenField ID="hidEditMode" runat="server" Value="" />
            <asp:HiddenField ID="hidUITrackID" runat="server" Value="" />
            <asp:HiddenField ID="hidPopsIntID" runat="server" Value="" />
            <asp:HiddenField ID="hidCapacityID" runat="server" Value="" />
        </div>
        <br /><br /><br />
        <div style="padding-left:5px;padding-right:5px;">
            <div id="ErrorText" runat="server" style="display:none;overflow:visible;border: solid 1px Red;color:Red;width: 99%;">
            </div>
            <asp:panel ScrollBars="None" CssClass="LicensePanel" id="CapacityEntryContent" runat="server">
                 <asp:table ID="tblEditForm" runat="server" BorderWidth="0" GridLines="None">
                    <asp:TableRow>
                        <asp:TableCell HorizontalAlign="Right" Width="90px">
                            <asp:Literal ID="litServiceType" runat="server" Text="Service Type: " />
                        </asp:TableCell>
                        <asp:TableCell ColumnSpan="3" Width="350px">
                            <telerik:RadComboBox ID="cboServiceType" runat="server" DataValueField="LOOKUP_VAL" DataTextField="VALDESC" Width="350px" />
                        </asp:TableCell>
                        <asp:TableCell RowSpan="5" VerticalAlign="Top" HorizontalAlign="Right" Width="230px">
                            <div id="divEditMenu" runat="server" style="display: none">
                                <asp:Button ID="btnSave" runat="server" CommandName="Save" OnCommand="EditMenu_Click" Text="Done" Width="200px" OnClientClick="return SaveCancelClientClick('Save');" />
                                <br /><br />
                                <asp:Button ID="btnCancel" runat="server" CommandName="Cancel" Text="Cancel" Width="200px" OnClientClick="return SaveCancelClientClick('Cancel');" />
                                <br /><br /><br /><br /><br /><br />
                            </div>
                            <div id="divActionMenu" runat="server" visible="true">
                                <asp:Button ID="btnNew" runat="server" CommandName="New" Text="Add Capacity" Width="200px" OnClientClick="NewEditClientClick('New'); return false;" />
                                <br /><br />
                                <asp:Button ID="btnNewSelected" runat="server" CommandName="NewSelected" Text="Copy Capacity From Selected Row" Width="200px" OnClientClick="NewEditClientClick('NewExist'); return false;"/>
                                <br /><br />
                                <asp:Button ID="btnEditSelected" runat="server" CommandName="EditSelected" Text="Edit Capacity" Width="200px" OnClientClick="NewEditClientClick('Edit'); return false;" />
                                <br /><br />
                                <asp:Button ID="btnDeleteSelected" runat="server" CommandName="DeleteSelected" OnCommand="ActionMenu_Click" Text="Remove Capacity" OnClientClick="return NewEditClientClick('Remove');" Width="200px" />
                            </div>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell HorizontalAlign="Right">
                            <asp:Literal ID="litUnit" runat="server" Text="Location/Wing: " /> 
                        </asp:TableCell>
                        <asp:TableCell Width="110px">
                            <telerik:RadTextBox ID="txtUnit" runat="server" Width="150px" MaxLength="30" />
                        </asp:TableCell>
                        <asp:TableCell HorizontalAlign="Right" Width="150px">
                            <asp:Literal ID="litFloor" runat="server" Text="Floor: " />
                        </asp:TableCell>
                        <asp:TableCell Width="90px">
                            <telerik:RadNumericTextBox ID="txtFloor" runat="server" Width="40" MaxLength="3" Type="Number" NumberFormat-DecimalDigits="0" />
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell HorizontalAlign="Right">
                            <asp:Literal ID="litRoomNumber" runat="server" Text="Room Number: " />
                        </asp:TableCell>
                        <asp:TableCell>
                            <telerik:RadTextBox ID="txtRoomNumber" runat="server" Width="150px" MaxLength="20"/>
                        </asp:TableCell>
                        <asp:TableCell HorizontalAlign="Right">
                            <asp:Literal ID="litNumBeds" runat="server" Text="Number of Beds: " />
                        </asp:TableCell>
                        <asp:TableCell>
                            <telerik:RadNumericTextBox ID="txtNumberBeds" runat="server" Width="40" Type="Number" NumberFormat-DecimalDigits="0" />
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell HorizontalAlign="Right">
                            <asp:Literal ID="litCallSystemMet" runat="server" Text="Call System Met: " />
                        </asp:TableCell>
                        <asp:TableCell>
                            <input type="checkbox" id="ChkCallSysMet" runat="server" />
                        </asp:TableCell>
                        <asp:TableCell HorizontalAlign="Right">
                            <asp:Literal ID="litRoomSizeMet" runat="server" Text="Room Size Met: " />
                        </asp:TableCell>
                        <asp:TableCell>
                            <input type="checkbox" id="chkRoomSizeMet" runat="server" />
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell HorizontalAlign="Right">
                            <asp:Literal ID="litFurnitureMet" runat="server" Text="Furniture Met: " />
                        </asp:TableCell>
                        <asp:TableCell>
                            <input type="checkbox" id="ChkFurnitureMet" runat="server" />
                        </asp:TableCell>    
                        <asp:TableCell HorizontalAlign="Right">
                            <asp:Literal ID="litPrivacyMet" runat="server" Text="Privacy Curtain or Wall Met: " />
                        </asp:TableCell>
                        <asp:TableCell>
                            <input type="checkbox" id="ChkPrivacyMet" runat="server" />
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell HorizontalAlign="Right" VerticalAlign="Top">
                            <asp:Literal ID="litComments" runat="server" Text="Comments: " /><br />
                        </asp:TableCell>
                        <asp:TableCell ColumnSpan="4">
                            <telerik:RadTextBox ID="txtComments" runat="server" TextMode="MultiLine" Columns="85" Rows="3" Height="39px" MaxLength="255" />
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:table>
            </asp:panel>
            <hr />    
            <asp:Label ID="lblTotalRooms" runat="server" Text="Rooms: " />
            <asp:Literal ID="litTotalRooms" runat="server" Text="" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;/&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblTotalLicBeds" runat="server" Text="Licensed Beds: " />
            <asp:Literal ID="litTotalLicBeds" runat="server" Text="" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;/&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblTotalNonLicBeds" runat="server" Text="Non-Licensed Beds: " />
            <asp:Literal ID="litTotalNonLicBeds" runat="server" Text="" />
            <asp:panel ScrollBars="None" CssClass="LicensePanel" id="CapacityGridContent" runat="server">
                <telerik:RadGrid ID="rgBedRecs" runat="server" Height="310" 
                        OnNeedDataSource="rgBedRecs_NeedDataSource"
                        OnItemCreated="rgBedRecs_ItemCreated"
                        OnItemDataBound="rgBedRecs_ItemDataBound"
                        AutoGenerateColumns="false"
                        AllowFilteringByColumn="true"
                        GroupingSettings-CaseSensitive="false">
                    <ClientSettings>
                        <ClientEvents OnRowClick="RowSelected" OnGridCreated="GridCreated" />
                    </ClientSettings>                        
                </telerik:RadGrid>
            </asp:panel>
        </div>
    </form>
</body>
</html>
