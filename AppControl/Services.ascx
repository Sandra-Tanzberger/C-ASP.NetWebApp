<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="Services.ascx.cs" Inherits="AppControl.Services" %>

<telerik:RadAjaxManagerProxy ID="SvcsRAMP" runat="server">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="optOperationType">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="SvcsRAP" LoadingPanelID="SvcsRALP" />
                <telerik:AjaxUpdatedControl ControlID="optOperationType" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="chkBHOperationType">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="SvcsBH" LoadingPanelID="SvcsRALP" />
                <telerik:AjaxUpdatedControl ControlID="chkBHOperationType" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>
<asp:HiddenField ID="hidSvcsDivClientID" runat="server" Value="" />
<asp:HiddenField ID="hidGroupStateClientIDs" runat="server" Value="" />
<telerik:RadAjaxLoadingPanel ID="SvcsRALP" runat="server" />
<div id="ErrorText" runat="server" visible="false" style="overflow:visible;border: solid 1px Red;color:Red;width: 100%;">
</div>
<div id="DivBH_Svcs" runat="server" visible="false">
     <telerik:RadAjaxPanel ID="SvcsBH" runat="server" Width="750px" >
         <table id="SvcsBHTable" class="formTable" border="0">
             <tr>
                 <td>
                      <b><asp:Label ID="lblBHTreatmentType" runat="server" Text="Treatment Type"></asp:Label></b>
                      <asp:CheckBoxList ID="chkBHTreatmentType" runat="server" RepeatColumns="1" RepeatDirection="Horizontal" onselectedindexchanged="BHTreatmentType_SelectedIndexChanged" />
                 </td>
             </tr>
           <tr>
               <td>
                    <b><asp:Label ID="lblBHClientType" runat="server" Text="Client Type"></asp:Label></b>
                    <asp:CheckBoxList ID="chkBHClientType" runat="server" RepeatColumns="1" RepeatDirection="Horizontal" onselectedindexchanged="BHClientType_SelectedIndexChanged" />
               </td>
           </tr>
            <tr>
                <td>
                    <b><asp:Label ID="lblBHOperationType" runat="server" Text="Operation Type"></asp:Label></b>
                    <asp:RadioButtonList ID="chkBHOperationType" runat="server" RepeatColumns="1" RepeatDirection="Horizontal"
                        AutoPostBack="true" onselectedindexchanged="BHOperationType_SelectedIndexChanged" /> 
                </td>
            </tr>
             <tr>
                 <td>
                     <b><asp:Label ID="lblLicensedUnits" runat="server" Text="Number Licensed Units" Visible="false"></asp:Label></b>
                     <asp:TextBox ID="txtNumberLicensedUnits" runat="server" Visible="false"></asp:TextBox>
                 </td>
                 <td>
                      <b><asp:Label ID="lblLicensedBeds" runat="server" Text="Number Licensed Beds" Visible="false"></asp:label></b>
                      <asp:TextBox ID="txtNumberLicensedBeds" runat="server"  Visible="false"></asp:TextBox>
                 </td>
             </tr>
             <tr>
                 <td>
                     <b><asp:Label ID="lblFacilityDescription" runat="server" Text="Facility Description" Visible="false"></asp:Label></b>
                     <asp:CheckBoxList ID="chkBHFacilityDescription" runat="server" Visible="false" onselectedindexchanged="BHFacilityDescription_SelectedIndexChanged"></asp:CheckBoxList>
                 </td>
             </tr>
        </table>
         <asp:HiddenField ID="BHServicesChanged" runat="server" Value="false" />
    </telerik:RadAjaxPanel>
</div>
<div>
    <asp:Label ID="lblTreatmentType" runat="server" Text="Treatment Type"></asp:Label>
    <asp:CheckBoxList ID="optTreatmentType" runat="server" RepeatColumns="1" RepeatDirection="Horizontal" />
    <asp:Label ID="lblClientType" runat="server" Text="Client Type"></asp:Label>
    <asp:RadioButtonList ID="optClientType" runat="server" RepeatColumns="1" RepeatDirection="Horizontal" />
    <asp:Label ID="lblOperationType" runat="server" Text="Operation Type"></asp:Label>
    <asp:RadioButtonList ID="optOperationType" runat="server" RepeatColumns="1" RepeatDirection="Horizontal"
        AutoPostBack="true" onselectedindexchanged="optOperationType_SelectedIndexChanged" /> 
</div>
<div id="DivOther_Svcs" runat="server">
    <div>
        <telerik:RadAjaxPanel ID="SvcsRAP" runat="server" Width="750px" >
        <asp:Repeater ID="ServicesRepeater" runat="server" 
            onitemdatabound="ServicesRepeater_ItemDataBound">
            <HeaderTemplate>
                <table id="SvcsRptr" class="formTable" border="0">
                    <tr valign="top" style="height: 5px">
                        <td colspan="4"><hr style="color: Black" /></td>
                    </tr>
                    <tr valign="bottom" >
                        <td style="width: 50px"></td>
                        <td style="width: 300px" align="left"><b>Description</b></td>
                        <td style="width: 250px"><b><asp:Label ID="lblHeaderCapOrLicNum" runat="server" /></b></td>
                        <td style="width: 150px"><b><asp:Label ID="lblHeaderOther" runat="server" Text="Other" /></b></td>
                    </tr>
                    <tr valign="top" style="height: 5px">
                        <td colspan="4"><hr style="color: Black" /></td>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                    <tr>
                        <td>
                            <asp:CheckBox ID="chkServiceType" runat="server" AutoPostBack="false" />
                            <asp:HiddenField ID="HiddenFieldServiceType" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "ServiceType") %>' />
                            <asp:HiddenField ID="HiddenFieldExtra" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "Extra") %>' />
                        </td>
                        <td style="width: 300px">
                            <asp:Label ID="lblServiceTypeDesc" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ServiceTypeDesc") %>' />
                        </td>
                        <td style="width: 250px">
                            <asp:TextBox ID="txtServiceLicNumber" runat="server" MaxLength="12" />
                            <telerik:RadNumericTextBox ID="txtServiceCensus" runat="server" MaxLength="5" Width="45px" NumberFormat-DecimalDigits="0" NumberFormat-GroupSeparator="" ></telerik:RadNumericTextBox>
                            &nbsp;
                            <telerik:RadNumericTextBox ID="txtServiceCapacity" runat="server" MaxLength="5" Width="45px" NumberFormat-DecimalDigits="0" NumberFormat-GroupSeparator="" ></telerik:RadNumericTextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtTypeServiceOther" runat="server" MaxLength="25" />
                        </td>
                    </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
        </telerik:RadAjaxPanel>
    </div>
</div>
<div id="DivES_Svcs" runat="server">
    <div style="padding-left:15px">
        <asp:Table runat="server"  class="formTable">
            <asp:TableRow>
                <asp:TableCell ColumnSpan="6">
                    <asp:CheckBox ID="chkHemodialysis" runat="server" AutoPostBack="false" Text="Hemodialysis" Enabled="true" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell ColumnSpan="6">
                    <asp:CheckBox ID="chkPeritonealdialysis" runat="server" AutoPostBack="false" Text="Peritoneal Dialysis" Enabled="true" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell ColumnSpan="6">
                    <asp:CheckBox ID="chkTransplantation" runat="server" AutoPostBack="false" Text="Transplantation" Enabled="true" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:CheckBox ID="chkHomeTraining" runat="server" AutoPostBack="false" Text="Home Training :" />
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Right">
                    <asp:CheckBox ID="chkHemodialysis2" runat="server" AutoPostBack="false" Text="Hemodialysis" />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:CheckBox ID="chkPeritonealdialysis2" runat="server" AutoPostBack="false" Text="Peritoneal Dialysis" />
                </asp:TableCell>
                <asp:TableCell ColumnSpan="3">
                </asp:TableCell>
            </asp:TableRow>        
            <asp:TableRow>
                <asp:TableCell>
                    <asp:CheckBox ID="chkHomeSupport" runat="server" AutoPostBack="false" Text="Home Support :" />
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Right">
                    <asp:CheckBox ID="chkHemodialysis3" runat="server" AutoPostBack="false" Text="Hemodialysis" />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:CheckBox ID="chkPeritonealdialysis3" runat="server" AutoPostBack="false" Text="Peritoneal Dialysis" />
                </asp:TableCell>
                <asp:TableCell ColumnSpan="3">
                </asp:TableCell>
            </asp:TableRow>        
            <asp:TableRow>
                <asp:TableCell ColumnSpan="6">
                <hr />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell ColumnSpan="6">
                    &nbsp;&nbsp;&nbsp;<asp:Label runat="server" ID="lblNumberOfStations" Text="Number Of Stations :" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label runat="server" ID="lblHemodialysis" Text="Hemodialysis" />
                </asp:TableCell>
                <asp:TableCell>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtHemodialysis" runat="server" MaxLength="4" />
                </asp:TableCell>
                <asp:TableCell>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label runat="server" ID="lblPeritoneal" Text="Peritoneal" />
                </asp:TableCell>
                <asp:TableCell>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtPeritoneal" runat="server" MaxLength="4" />
                </asp:TableCell>
                <asp:TableCell ColumnSpan="2"></asp:TableCell>
            </asp:TableRow>
            <asp:TableHeaderRow>
                <asp:TableCell ColumnSpan="1" HorizontalAlign="Left">
                    <asp:Label runat="server" ID="lblTotalNonTrainingStations" Text="Total Non-Training Stations"></asp:Label>
                </asp:TableCell>
                <asp:TableCell ColumnSpan="1" HorizontalAlign="Left">
                    <asp:TextBox runat="server" ID="txtTotalNonTrainingStations"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell ColumnSpan="4"></asp:TableCell>
            </asp:TableHeaderRow>
            <asp:TableRow>
                <asp:TableCell>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label runat="server" ID="lblIsolation" Text="Isolation" />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:RadioButtonList runat="server" ID="rblIsolation" AutoPostBack="false" RepeatDirection="Horizontal">
                        <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                        <asp:ListItem Text="No" Value="N"></asp:ListItem>
                    </asp:RadioButtonList>                
                </asp:TableCell>
                <asp:TableCell ColumnSpan="4">
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label runat="server" ID="lblReuse" Text="Reuse" />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:RadioButtonList runat="server" ID="rblReuse" AutoPostBack="false" RepeatDirection="Horizontal">
                        <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                        <asp:ListItem Text="No" Value="N"></asp:ListItem>
                    </asp:RadioButtonList>
                </asp:TableCell>
                <asp:TableCell ColumnSpan="4">
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </div>
</div>
<div id="DivHCBS_Svcs" runat="server">
    <table border="0">
        <tr valign="top" style="height: 30px">
            <td colspan="3">
            Please check all services currently being provided. PCA, SIL and Respite <b>may not be added</b> at renewal unless accompanied<br />
          by a letter of approval from the DHH Facility Need Review Committee. </td>
        </tr>
        <tr valign="bottom" >
            <td  colspan="3">
                <input type="checkbox" ID="chkPCA" runat="server" /><b><label id="lblChkPCA" runat="server">PCA</label></b></td></tr><tr>
            <td>
                <asp:HiddenField ID="hidPCAGroupState" runat="server" Value="RO" />
                <table id="tblPCA" runat="server" >
                    <tr>
                        <td style="width: 100px" ></td>
                        <td style="width: 250px" ><asp:Literal ID="lblPCA_FNR_APRVL_DT" runat="server" Text="Facility Need Review Approval Date" Visible="false" /></td>
                        <td style="width: 100px" ><span id="noDisablePCA_FNR_APRVL_DT" runat="server">
                            <telerik:RadDatePicker ID="rdpPCA_FNR_APRVL_DT" 
                                runat="server" DateInput-DateFormat="MM/dd/yyyy" MinDate="01/01/0001" 
                                Width="90" Calendar-UseRowHeadersAsSelectors="False" Calendar-UseColumnHeadersAsSelectors="False" 
                                Calendar-ViewSelectorText="x"  Calendar-FastNavigationStep="12" Visible="false" />
                            </span>
                         </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="3" style="border-bottom: solid 1px"></td>
        </tr>
        <tr valign="bottom" >
            <td colspan="3"><input type="checkbox" ID="chkSIL" runat="server" /><b><label id="lblSIL" runat="server">SIL</label></b></td>
        </tr>
        <tr>
            <td>
                <asp:HiddenField ID="hidSILGroupState" runat="server" Value="RO" />
                <table id="tblSIL" runat="server" >
                    <tr>
                        <td style="width: 100px" ></td>
                        <td style="width: 250px" ><asp:Label ID="lblSIL_FNR_APRVL_DT" runat="server" Text="Facility Need Review Approval Date" Visible="false"/></td>
                        <td style="width: 100px" ><span id="noDisableSIL_FNR_APRVL_DT" runat="server">
                            <telerik:RadDatePicker ID="rdpSIL_FNR_APRVL_DT" runat="server" DateInput-DateFormat="MM/dd/yyyy" MinDate="01/01/0001" 
                                Width="90" Calendar-UseRowHeadersAsSelectors="False" Calendar-UseColumnHeadersAsSelectors="False" 
                                Calendar-ViewSelectorText="x"  Calendar-FastNavigationStep="12" Visible="false" />
                            </span>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="3" style="border-bottom: solid 1px"></td>
        </tr>
        <tr valign="bottom" >
            <td colspan="3"><input type="checkbox" ID="chkSIL_SLC" runat="server" /><b><label id="lblSIL_SLC" runat="server">SIL Shared Living Conversion</label></b></td></tr><tr>
            <td>
                <asp:HiddenField ID="hidSIL_SLCGroupState" runat="server" Value="RO" />
                <table id="tblSIL_SLC" runat="server" >
                    <tr>
                        <td style="width: 100px" ></td>
                        <td style="width: 250px" ><asp:Label ID="lblSIL_SLC_FNR_APRVL_DT" runat="server" Text="Facility Need Review Approval Date" Visible="false"/></td>
                        <td style="width: 100px" ><span id="noDisableSIL_SLC_FNR_APRVL_DT" runat="server">
                            <telerik:RadDatePicker ID="rdpSIL_SLC_FNR_APRVL_DT" 
                                runat="server" DateInput-DateFormat="MM/dd/yyyy" MinDate="01/01/0001" 
                                Width="90" Calendar-UseRowHeadersAsSelectors="False" Calendar-UseColumnHeadersAsSelectors="False" 
                                Calendar-ViewSelectorText="x"  Calendar-FastNavigationStep="12" Visible="false" />
                            </span>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td><asp:Label ID="lblOCDD_APRVL_DT" runat="server" Text="Date OCDD approved ICF/DD conversion request" /></td>
                        <td><span id="noDisableOCDD_APRVL_DT" runat="server">
                            <telerik:RadDatePicker ID="rdpOCDD_APRVL_DT" runat="server" DateInput-DateFormat="MM/dd/yyyy" MinDate="01/01/0001" 
                                Width="90" Calendar-UseRowHeadersAsSelectors="False" Calendar-UseColumnHeadersAsSelectors="False" 
                                Calendar-ViewSelectorText="x"  Calendar-FastNavigationStep="12" />
                            </span>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td><asp:Label ID="lblOCDD_CONV_REQ" runat="server" Text="OCDD approved ICF/DD conversion request" /></td>
                        <td>
                            <span id="AttachLinkButtonSpan" runat="server">
                                <asp:LinkButton ID="ServiceAttachAction" CommandName="Upload" runat="server" Text="Attach"
                                            CommandArgument="" OnCommand="AttachAction_Click" Width="65"/>
                            </span>
                            <span id="ViewLinkButtonSpan" runat="server" visible="false"></span>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td><asp:Label ID="lblSIL_SLC_CAPACITY" runat="server" Text="Capacity at License Application/Renewal" /></td>
                        <td><telerik:RadNumericTextBox ID="txtSIL_SLC_CAPACITY" runat="server" MaxLength="5" Width="45" 
                             Type="Number" NumberFormat-GroupSeparator="" NumberFormat-DecimalDigits="0" /></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td><asp:Label ID="lblSUR_ICFDD_LIC_NUM" runat="server" Text="(Surrendered) ICF/DD License Number" /></td>
                        <td><asp:TextBox ID="txtSUR_ICFDD_LIC_NUM" runat="server" MaxLength="12" Width="80" /></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td><asp:Label ID="lblSUR_ICFDD_LIC_EXP_DT" runat="server" Text="(Surrendered) ICF/DD License Expiration Date" /></td>
                        <td style="margin-left: 40px"><span id="noDisableSUR_ICFDD_LIC_EXP_DT" runat="server">
                            <telerik:RadDatePicker ID="rdpSUR_ICFDD_LIC_EXP_DT" runat="server" DateInput-DateFormat="MM/dd/yyyy" MinDate="01/01/0001" 
                                Width="90" Calendar-UseRowHeadersAsSelectors="False" Calendar-UseColumnHeadersAsSelectors="False" 
                                Calendar-ViewSelectorText="x"  Calendar-FastNavigationStep="12" />
                            </span>
                        </td>
                    </tr>
                    </table>
            </td>
        </tr>
        <tr>
            <td colspan="3" style="border-bottom: solid 1px"></td>
        </tr>
        <tr valign="bottom" >
            <td colspan="3"><input type="checkbox" ID="chkRESPITE_IN_HOME" runat="server" /><b><label id="lblRESPITE_IN_HOME" runat="server">Respite Care - InHome</label></b></td></tr><tr>
            <td>
                <asp:HiddenField ID="hidRESPITE_IN_HOMEGroupState" runat="server" Value="RO" />
                <table id="tblRESPITE_IN_HOME" runat="server">
                    <tr>
                        <td style="width: 100px" ></td>
                        <td style="width: 250px" ><asp:Label ID="lblFNR_RESPITE_IN_HOME_DT" runat="server" Text="Facility Need Review Approval Date" Visible="false" /></td>
                        <td style="width: 100px" ><span id="noDisableFNR_RESPITE_IN_HOME_DT" runat="server">
                            <telerik:RadDatePicker ID="rdpFNR_RESPITE_IN_HOME_DT" runat="server" DateInput-DateFormat="MM/dd/yyyy" MinDate="01/01/0001" 
                                Width="90" Calendar-UseRowHeadersAsSelectors="False" Calendar-UseColumnHeadersAsSelectors="False" 
                                Calendar-ViewSelectorText="x"  Calendar-FastNavigationStep="12" Visible="false" />
                            </span>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="3" style="border-bottom: solid 1px"></td>
        </tr>
        <tr valign="bottom" >
            <td colspan="3"><input type="checkbox" ID="chkRESPITE_CENTER_BASED" runat="server" /><b><label id="lblRESPITE_CENTER_BASED" runat="server" >Respite Care - Center Based</label></b></td></tr><tr>
            <td>
                <asp:HiddenField ID="hidRESPITE_CENTER_BASEDGroupState" runat="server" Value="RO" />
                <table id="tblRESPITE_CENTER_BASED" runat="server">
                    <tr>
                        <td style="width: 100px" ></td>
                        <td style="width: 250px" ><asp:Label ID="lblFNR_RESPITE_CENTER_BASED" runat="server" Text="Facility Need Review Approval Date"  Visible="false"/></td>
                        <td style="width: 100px" ><span id="noDisableFNR_RESPITE_CENTER_BASED" runat="server">
                            <telerik:RadDatePicker ID="rdpFNR_RESPITE_CENTER_BASED" runat="server" DateInput-DateFormat="MM/dd/yyyy" MinDate="01/01/0001" 
                                Width="90" Calendar-UseRowHeadersAsSelectors="False" Calendar-UseColumnHeadersAsSelectors="False" 
                                Calendar-ViewSelectorText="x"  Calendar-FastNavigationStep="12" Visible="false" />
                            </span>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td><asp:Label ID="lblRESPITE_CENTER_BASED_CAPACITY" runat="server" Text="Capacity at License Application/Renewal" /></td>
                        <td><telerik:RadNumericTextBox ID="txtRESPITE_CENTER_BASED_CAPACITY" runat="server" MaxLength="5" Width="45" 
                             Type="Number" NumberFormat-GroupSeparator="" NumberFormat-DecimalDigits="0" /></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td colspan="2" style="padding-bottom: 10px">
                            <asp:Label ID="lblHoursOperation" runat="server">Hours of Operation:</asp:Label></td></tr><tr>
                        <td></td>
                        <td colspan="2">
                            <table id="tableOperatingDetails" width="500" cellspacing="1" cellpadding="1">
                                <tr>
                                    <td style="width: 15px"></td>
                                    <td>
                                        <asp:CheckBox ID="CheckBoxDayOfOperationMon" runat="server"
                                            Text="Monday" TextAlign="Right" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="CheckBoxDayOfOperationTue" runat="server"
                                            Text="Tuesday" TextAlign="Right" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="CheckBoxDayOfOperationWed" runat="server"
                                            Text="Wednesday" TextAlign="Right" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="CheckBoxDayOfOperationThu" runat="server"
                                            Text="Thursday" TextAlign="Right" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="CheckBoxDayOfOperationFri" runat="server"
                                            Text="Friday" TextAlign="Right" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="CheckBoxDayOfOperationSat" runat="server"
                                            Text="Saturday" TextAlign="Right" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="CheckBoxDayOfOperationSun" runat="server"
                                            Text="Sunday" TextAlign="Right" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2"></td>
                                    <td colspan="2" align="right">
                                        <asp:Label ID="lblFrom" runat="server">From: </asp:Label><telerik:RadMaskedTextBox ID="txtHoursMinutesFrom" runat="server" Mask="##:##" Width="35" />
                                        <asp:DropDownList ID="listAmPmFrom" runat="server">
                                            <asp:ListItem Text="" Value=""></asp:ListItem><asp:ListItem Text="AM" Value="AM"></asp:ListItem><asp:ListItem Text="PM" Value="PM"></asp:ListItem></asp:DropDownList></td><td align="right">
                                        <asp:Label ID="lblTO" runat="server">To: </asp:Label></td><td colspan="2" valign="top">
                                        <telerik:RadMaskedTextBox ID="txtHoursMinutesTo" runat="server" Mask="##:##" Width="35" />
                                        <asp:DropDownList ID="listAmPmTo" runat="server">
                                            <asp:ListItem Text="" Value=""></asp:ListItem><asp:ListItem Text="AM" Value="AM"></asp:ListItem><asp:ListItem Text="PM" Value="PM"></asp:ListItem></asp:DropDownList></td><td colspan="2">
                                    </td>                        
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="3" style="border-bottom: solid 1px"></td>
        </tr>
        <tr valign="bottom" >
            <td colspan="3"><input type="checkbox" ID="chkADC" runat="server" /><b><label id="lblADC" runat="server">ADC</label></b></td>
        </tr>
        <tr>
            <td>
                <asp:HiddenField ID="hidADCGroupState" runat="server" Value="RO" />
                <table id="tblADC" runat="server" >
                    <tr>
                        <td style="width: 100px" ></td>
                        <td style="width: 250px" ><asp:Label ID="lblADC_CAPACITY" runat="server" Text="Capacity at License Application/Renewal" /></td>
                        <td style="width: 100px" ><telerik:RadNumericTextBox ID="txtADC_CAPACITY" runat="server" MaxLength="5" Width="45"
                             Type="Number" NumberFormat-GroupSeparator="" NumberFormat-DecimalDigits="0" /></td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td colspan="2">ADC Programs (Select one or both)</td>
                    </tr>
                    <tr valign="bottom" >
                        <td>&nbsp;</td>
                        <td colspan="2" style="padding-left: 10px;">
                            <b><asp:CheckBox ID="chkADC_DAY_HABILITATION" runat="server" Text="ADC - Day Habilitation" /></b>
                        </td>
                    </tr>
                    <tr valign="bottom" >
                        <td>&nbsp;</td>
                        <td colspan="2" style="padding-left: 10px;">
                            <b><asp:CheckBox ID="chkADC_PREVOC" runat="server" Text="ADC - Pre-vocation/Employment Related Services" /></b>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="3" style="border-bottom: solid 1px"></td>
        </tr>
        <tr valign="bottom" >
            <td colspan="3"><input type="checkbox" ID="chkFAMILY_SUPPORT" runat="server" /><b><label id="lblFAMILY_SUPPORT" runat="server">Family Support</label></b></td>
        </tr>
        <tr>
            <td colspan="3" style="border-bottom: solid 1px"></td>
        </tr>
        <tr valign="bottom" >
            <td colspan="3"><input type="checkbox" ID="chkSUPPORTED_EMPLOYMENT" runat="server" /><b><label id="lblSUPPORTED_EMPLOYMENT" runat="server">Supported Employment</label></b></td>
        </tr>
        <tr>
            <td colspan="3" style="border-bottom: solid 1px"></td>
        </tr>
        <tr valign="bottom" >
            <td colspan="3"><input type="checkbox" ID="chkSUBSTITUTE_FAMILY_CARE" runat="server" /><b><label id="lblSUBSTITUTE_FAMILY_CARE" runat="server">Substitute Family Care</label></b></td>
        </tr>
        <tr>
            <td colspan="3" style="border-bottom: solid 1px"></td>
        </tr>
          <tr valign="bottom" >
            <td colspan="3"><input type="checkbox" ID="chkMONITORED_INHOME_CAREGIVING" runat="server" /><b><label id="lblMONITORED_INHOME_CAREGIVING" runat="server">Monitored In-Home Caregiving Services</label></b></td></tr><tr>
            <td>
                <asp:HiddenField ID="HiddenField1" runat="server" Value="RO" />
                <table id="Table1" runat="server">
                    <tr>
                        <td style="width: 100px" ></td>
                        <td style="width: 250px" ><asp:Label ID="Label1" runat="server" Text="Facility Need Review Approval Date" Visible="false"/></td>
                        <td style="width: 100px" ><span id="Span1" runat="server">
                            <telerik:RadDatePicker ID="rdpMIC_NEEDREVIEW_DT" runat="server" DateInput-DateFormat="MM/dd/yyyy" MinDate="01/01/0001" 
                                Width="90" Calendar-UseRowHeadersAsSelectors="False" Calendar-UseColumnHeadersAsSelectors="False" 
                                Calendar-ViewSelectorText="x"  Calendar-FastNavigationStep="12" Visible="false" />
                            </span>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</div>
<div id="DivHP_Svcs" runat="server">
    <table class="formTable" border="0" width="575px">
        <tr>
            <td>
                For services provided please indicate if they are by "Direct Staff" or "Under Arrangement". <b>NOTE: CORE services, excluding Physician, must be provided directly by the Hospice and not under arrangment.</b>
                <br /><br />
            </td>
        </tr>
    </table>
    <asp:Repeater ID="rptrHP_CoreServices" runat="server" OnItemDataBound="HP_CoreServices_ItemDataBound">
        <HeaderTemplate>
            <table class="formTable" border="0" width="750px">
                <tr>
                    <td colspan="2">
                        <b>CORE SERVICES</b>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
                <tr>
                    <td style="width: 375px;">
                        <asp:Label ID="lblCoreServiceTypeDesc" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ServiceTypeDesc") %>' />
                        <asp:HiddenField ID="hidHP_CoreServiceType" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "ServiceType") %>' />
                    </td>
                    <td style="width:200px;">
                        <telerik:RadComboBox ID="listCoreSrvcTypeOptions" runat="server" Width="165px">
                        </telerik:RadComboBox>
                    </td>
                    <td style="width:175px;">
                        &nbsp;
                    </td>
                </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    <br />
    <asp:Repeater ID="rptrHP_OtherServices" runat="server" OnItemDataBound="HP_OtherServices_ItemDataBound">
        <HeaderTemplate>
            <table class="formTable" border="0" width="750px">
                <tr>
                    <td colspan="2">
                        <b>OTHER SERVICES</b>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
                <tr>
                    <td style="width: 375px;">
                        <asp:Label ID="lblOtherServiceTypeDesc" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ServiceTypeDesc") %>' />
                        <asp:HiddenField ID="hidHP_OtherServiceType" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "ServiceType") %>' />
                    </td>
                    <td style="width:200px;">
                        <telerik:RadComboBox ID="listOtherSrvcTypeOptions" runat="server" Width="165px">
                        </telerik:RadComboBox>
                    </td>
                    <td style="width:175px;">
                        <asp:TextBox ID="txtHPSrvcTypeOther" runat="server" MaxLength="25" Visible="false" />
                    </td>
                </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</div>
<div id="DivHH_Svcs" runat="server">
    <asp:Repeater ID="rptrHH_Services" runat="server" OnItemDataBound="HH_Services_ItemDataBound">
        <HeaderTemplate>
            <table class="formTable" border="0" width="825px">
                <tr>
                    <td colspan="2">
                       For services provided please indicate if they are by "Direct Staff" or "Under Arrangement". <b>NOTE: Administration, Skilled Nursing and one(1) other service must be provided directly by the agency at all times.</b>
                       <br /><br />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
                <tr>
                    <td style="width: 375px;">
                        <asp:Label ID="lblHHServiceTypeDesc" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ServiceTypeDesc") %>' />
                        <asp:HiddenField ID="hidHH_ServiceType" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "ServiceType") %>' />
                    </td>
                    <td style="width:300px;">
                        <telerik:RadComboBox ID="listHHSrvcTypeOptions" runat="server" Width="265px">
                        </telerik:RadComboBox>
                    </td>
                    <td style="width:150px;">
                        <asp:TextBox ID="txtHHSrvcTypeOther" runat="server" MaxLength="25" Visible="false" Width="190px"  />
                    </td>
                </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</div>
<div id="DivFF_Svcs" runat="server">
    <asp:Repeater ID="rptrFF_Services" runat="server" OnItemDataBound="FF_Services_ItemDataBound">
        <HeaderTemplate>
            <table class="formTable" border="0" width="825px">
        </HeaderTemplate>
        <ItemTemplate>
                <tr>
                    <td style="width: 375px;">
                        <asp:CheckBox ID="chkFF_Service" runat="server" />
                        <asp:Label ID="lblFFServiceTypeDesc" runat="server" ><%# DataBinder.Eval(Container.DataItem, "ServiceTypeDesc") %> <i><%# DataBinder.Eval(Container.DataItem, "Extra") %></i></asp:Label>
                        <asp:HiddenField ID="hidFF_ServiceType" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "ServiceType") %>' />
                    </td>
                </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</div>
<div id="DivAS_Svcs" runat="server">
    <asp:Repeater ID="rptrAS_Services" runat="server" OnItemDataBound="AS_Services_ItemDataBound">
        <HeaderTemplate>
            <table class="formTable" border="0" width="825px">
        </HeaderTemplate>
        <ItemTemplate>
                <tr>
                    <td style="width: 375px;">
                        <asp:CheckBox ID="chkAS_Service" runat="server" />
                        <asp:Label ID="lblASServiceTypeDesc" runat="server" ><%# DataBinder.Eval(Container.DataItem, "ServiceTypeDesc") %> <i><%# DataBinder.Eval(Container.DataItem, "Extra") %></i></asp:Label>
                        <asp:HiddenField ID="hidAS_ServiceType" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "ServiceType") %>' />
                    </td>
                </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</div>
<div id="DivCO_Svcs" runat="server">
    <asp:Repeater ID="rptrCO_Services" runat="server" OnItemDataBound="CO_Services_ItemDataBound">
        <HeaderTemplate>
            <table class="formTable" border="0" width="825px">
        </HeaderTemplate>
        <ItemTemplate>
                <tr>
                    <td style="width: 375px;">
                        <asp:CheckBox ID="chkCO_Service" runat="server" />
                        <asp:Label ID="lblCOServiceTypeDesc" runat="server" ><%# DataBinder.Eval(Container.DataItem, "ServiceTypeDesc") %> <i><%# DataBinder.Eval(Container.DataItem, "Extra") %></i></asp:Label>
                        <asp:HiddenField ID="hidCO_ServiceType" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "ServiceType") %>' />
                    </td>
                </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</div>
<telerik:RadWindowManager ID="ServiceAttachRadWinMan" runat="server" >
    <Windows>
        <telerik:RadWindow ID="ServiceAttachRadWin" runat="server" VisibleOnPageLoad="true" VisibleStatusbar="false" Visible="false" />
    </Windows>
</telerik:RadWindowManager>
