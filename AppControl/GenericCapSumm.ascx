<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GenericCapSumm.ascx.cs" Inherits="AppControl.GenericCapSumm" %>

<telerik:RadAjaxManagerProxy ID="CapSummRAM" runat="server">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="BedSummRAM">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="CapSumRadPanel" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>
<telerik:RadCodeBlock ID="CapSummRCB" runat="server" >
      <script type="text/javascript">
          //called from open radwindow for attachment
          function refreshParentCapSum(inArgs) {
              try {
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
    <div id="divBR_CapSumm" runat="server">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblTotLicCapacity_BR" runat="server" Text="Total Licensed Capacity (Residential only, Main Location & Branches) - Read Only " />
        <asp:TextBox ID="txtTotalLicCapacity_BR" runat="server" Enabled="false" Text="" />
    </div>
    <div id="divHP_CapSumm" runat="server">
        <asp:Table ID="tblHP_NumCurActivePatients" CssClass="formTable" CellSpacing="0" BorderWidth="0" runat="server">
            <asp:TableRow>
                <asp:TableCell Width="300px">
                    <label id="lblHP_NumCurActivePatients" style="color: Black">Total Number of Current Active Patients:</label>
                </asp:TableCell>
                <asp:TableCell Width="50px">
                    <telerik:RadMaskedTextBox ID="txtHP_NumCurActivePatients" runat="server" Mask="#####" Width="40px" SelectionOnFocus="CaretToBeginning" /> 
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <asp:Table ID="tblHP_NumberLicensedBeds" CssClass="formTable" CellSpacing="0" BorderWidth="0" runat="server">
            <asp:TableRow>
                <asp:TableCell Width="300px">
                    <label id="lblHP_NumberLicensedBeds" style="color: Black">Total Number of Licensed Beds <i>(If applicable)</i>:</label>
                </asp:TableCell>
                <asp:TableCell Width="50px">
                    <telerik:RadMaskedTextBox ID="txtHP_NumberLicensedBeds" runat="server" Mask="###" Width="20px" SelectionOnFocus="CaretToBeginning" /> 
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <asp:Table ID="tblHP_NumberUnitRoomStations" CssClass="formTable" CellSpacing="0" BorderWidth="0" runat="server">
            <asp:TableRow>
                <asp:TableCell Width="300px">
                    <label id="lblHP_NumberUnitRoomStations" style="color: Black">Total Number of Units, Rooms, Stations <i>(If applicable)</i>:</label>
                </asp:TableCell>
                <asp:TableCell Width="50px">
                    <telerik:RadMaskedTextBox ID="txtHP_NumberUnitRoomStations" runat="server" Mask="###" Width="20px" SelectionOnFocus="CaretToBeginning" /> 
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </div>
    <div id="divAC_CapSumm" runat="server">
        <asp:Table ID="tblAC_CapSumm" CssClass="formTable" CellSpacing="0" BorderWidth="0" runat="server">
            <asp:TableRow>
                <asp:TableCell Width="150px">
                    <asp:Label ID="lblAC_NumLicUnit" runat="server" Text="Number of Licensed Units: " />
                </asp:TableCell>
                <asp:TableCell Width="50px">
                    <telerik:RadNumericTextBox ID="txtAC_NumLicUnit" runat="server" Width="20px" MaxLength="3" SelectionOnFocus="CaretToBeginning" NumberFormat-DecimalDigits="0" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblAC_TotalCapacity" runat="server" Text="Total Capacity: " />
                </asp:TableCell>
                <asp:TableCell>
                    <telerik:RadNumericTextBox ID="txtAC_TotalCapacity" runat="server" Width="20px" MaxLength="3" SelectionOnFocus="CaretToBeginning" NumberFormat-DecimalDigits="0" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </div>
    <div id="divWA_CapSumm" runat="server">
        <asp:Table ID="tblWA_CapSumm" CssClass="formTable" CellSpacing="0" BorderWidth="0" runat="server">
            <asp:TableRow>
                <asp:TableCell Width="150px">
                    <asp:Label ID="lblWA_PresentCapacity" runat="server" Text="Present Capacity: " />
                </asp:TableCell>
                <asp:TableCell Width="50px">
                    <telerik:RadNumericTextBox ID="txtWA_PresentCapacity" runat="server" Width="20px" MaxLength="5" SelectionOnFocus="CaretToBeginning" NumberFormat-DecimalDigits="0" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblWA_LicensedCapacity" runat="server" Text="Licensed Capacity: " />
                </asp:TableCell>
                <asp:TableCell>
                    <telerik:RadNumericTextBox ID="txtWA_LicensedCapacity" runat="server" Width="20px" MaxLength="5" SelectionOnFocus="CaretToBeginning" NumberFormat-DecimalDigits="0" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </div>
    <div id="divSA_CapSumm" runat="server">
        <asp:Table ID="tblSA_CapSumm" CssClass="formTable" CellSpacing="0" BorderWidth="0" runat="server">
            <asp:TableRow>
                <asp:TableCell Width="200px">
                    <asp:Label ID="lblSA_NumLicUnit" runat="server" Text="Number of Licensed Units: " />
                </asp:TableCell>
                <asp:TableCell Width="60px">
                    <telerik:RadNumericTextBox ID="txtSA_NumLicUnit" runat="server" Width="55px" MaxLength="5" SelectionOnFocus="CaretToBeginning" NumberFormat-DecimalDigits="0" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblSA_NumLicBeds" runat="server" Text="Number of Licensed Beds: " />
                </asp:TableCell>
                <asp:TableCell>
                    <telerik:RadNumericTextBox ID="txtSA_NumLicBeds" runat="server" Width="55px" MaxLength="5" SelectionOnFocus="CaretToBeginning" NumberFormat-DecimalDigits="0" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </div>
     <div id="divPT_CapSumm" runat="server">
        <asp:Table ID="Table1" CssClass="formTable" CellSpacing="0" BorderWidth="0" runat="server">
            <asp:TableRow>
                <asp:TableCell Width="200px">
                    <asp:Label ID="lblPTNumLicUnits" runat="server" Text="Number of Licensed Units: " />
                </asp:TableCell>
                <asp:TableCell Width="60px">
                    <telerik:RadNumericTextBox ID="txtPT_NumLicUnit" runat="server" Width="55px" MaxLength="5" SelectionOnFocus="CaretToBeginning" NumberFormat-DecimalDigits="0" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblPTNumLicBeds" runat="server" Text="Number of Licensed Beds: " />
                </asp:TableCell>
                <asp:TableCell>
                    <telerik:RadNumericTextBox ID="txtPT_NumLicBeds" runat="server" Width="55px" MaxLength="5" SelectionOnFocus="CaretToBeginning" NumberFormat-DecimalDigits="0" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </div>
     <div id="divTG_CapSumm" runat="server">
        <asp:Table ID="Table2" CssClass="formTable" CellSpacing="0" BorderWidth="0" runat="server">
            <asp:TableRow>
                <asp:TableCell Width="200px">
                    <asp:Label ID="lblTGNumLicUnits" runat="server" Text="Number of Licensed Units: " />
                </asp:TableCell>
                <asp:TableCell Width="60px">
                    <telerik:RadNumericTextBox ID="txtTG_NumLicUnit" runat="server" Width="55px" MaxLength="5" SelectionOnFocus="CaretToBeginning" NumberFormat-DecimalDigits="0" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblTGNumLicBeds" runat="server" Text="Number of Licensed Beds: " />
                </asp:TableCell>
                <asp:TableCell>
                    <telerik:RadNumericTextBox ID="txtTG_NumLicBeds" runat="server" Width="55px" MaxLength="5" SelectionOnFocus="CaretToBeginning" NumberFormat-DecimalDigits="0" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </div>
    <div id="divMR_CapSumm" runat="server">
        <asp:Table ID="tblMR_CapSumm" CssClass="formTable" CellSpacing="0" BorderWidth="0" runat="server">
            <asp:TableRow>
                <asp:TableCell Width="200px">
                    <asp:Label ID="lblMR_NumLicBedrooms" runat="server" Text="Number of Licensed Bedrooms: " />
                </asp:TableCell>
                <asp:TableCell Width="60px">
                    <telerik:RadNumericTextBox ID="txtMR_NumLicBedrooms" runat="server" Width="55px" MaxLength="5" SelectionOnFocus="CaretToBeginning" NumberFormat-DecimalDigits="0" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblMR_NumLicBeds" runat="server" Text="Number of Licensed Beds: " />
                </asp:TableCell>
                <asp:TableCell>
                    <telerik:RadNumericTextBox ID="txtMR_NumLicBeds" runat="server" Width="55px" MaxLength="5" SelectionOnFocus="CaretToBeginning" NumberFormat-DecimalDigits="0" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblMR_NumCertBeds" runat="server" Text="Number of Certified Beds: " />
                </asp:TableCell>
                <asp:TableCell>
                    <telerik:RadNumericTextBox ID="txtMR_NumCertBeds" runat="server" Width="55px" MaxLength="5" SelectionOnFocus="CaretToBeginning" NumberFormat-DecimalDigits="0" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </div>
    <div id="divNH_CapSumm" runat="server">
        <asp:Table ID="tblNH_CapSumm" CssClass="formTable" CellSpacing="0" BorderWidth="0" runat="server">
            <asp:TableRow>
                <asp:TableCell Width="200px">
                    <asp:Label ID="lblNH_NumLicUnits" runat="server" Text="Number of Licensed Units (Rooms): " />
                </asp:TableCell>
                <asp:TableCell Width="60px">
                    <telerik:RadNumericTextBox ID="txtNH_NumLicUnits" runat="server" Width="55px" MaxLength="5" SelectionOnFocus="CaretToBeginning" NumberFormat-DecimalDigits="0" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblNH_NumLicBeds" runat="server" Text="Number of Licensed Beds: " />
                </asp:TableCell>
                <asp:TableCell>
                    <telerik:RadNumericTextBox ID="txtNH_NumLicBeds" runat="server" Width="55px" MaxLength="5" SelectionOnFocus="CaretToBeginning" NumberFormat-DecimalDigits="0" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblNH_NumCertBeds" runat="server" Text="Number of Certified Beds: " />
                </asp:TableCell>
                <asp:TableCell>
                    <telerik:RadNumericTextBox ID="txtNH_NumCertBeds" runat="server" Width="55px" MaxLength="5" SelectionOnFocus="CaretToBeginning" NumberFormat-DecimalDigits="0" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblNH_NumTitle18" runat="server" Text="Number of Title 18: " />
                </asp:TableCell>
                <asp:TableCell>
                    <telerik:RadNumericTextBox ID="txtNH_NumTitle18" runat="server" Width="55px" MaxLength="5" SelectionOnFocus="CaretToBeginning" NumberFormat-DecimalDigits="0" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblNH_NumTitle1819" runat="server" Text="Number of Title 18/19: " />
                </asp:TableCell>
                <asp:TableCell>
                    <telerik:RadNumericTextBox ID="txtNH_NumTitle1819" runat="server" Width="55px" MaxLength="5" SelectionOnFocus="CaretToBeginning" NumberFormat-DecimalDigits="0" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblNH_NumTitle19" runat="server" Text="Number of Title 19: " />
                </asp:TableCell>
                <asp:TableCell>
                    <telerik:RadNumericTextBox ID="txtNH_NumTitle19" runat="server" Width="55px" MaxLength="5" SelectionOnFocus="CaretToBeginning" NumberFormat-DecimalDigits="0" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </div>
</telerik:RadAjaxPanel>
