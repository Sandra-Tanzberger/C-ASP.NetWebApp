<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="FacilityTypeOf.ascx.cs" Inherits="AppControl.FacilityTypeOf" %>

<telerik:RadAjaxManagerProxy ID="FacilityTypeOfRAM" runat="server">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="BedSummRAM">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="FacilityTypeOfRadPanel" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>
<telerik:RadCodeBlock ID="FacilityTypeOfRCB" runat="server" >
      <script type="text/javascript">
          //called from open radwindow for attachment
          function refreshParentFacilityTypeOf(inArgs) {
              $find("<%=RadAjaxManager.GetCurrent(Page).ClientID %>").ajaxRequest(inArgs);
          }
      </script>  
</telerik:RadCodeBlock>    
<div id="ErrorText" runat="server" visible="false" style="overflow:visible;border: solid 1px Red;color:Red;width: 100%;">
   </div>
<telerik:RadAjaxLoadingPanel ID="FacilityTypeOfRALP" runat="server" />


<telerik:RadAjaxPanel ID="FacilityTypeOfRadPanel" runat="server">
<div id="divBR_ProviderType" runat="server">
    (Select all that apply to location)
        <asp:Table ID="tblBR_ProviderType" CssClass="formTable" CellSpacing="0" BorderWidth="0" runat="server">
        <asp:TableRow>
            <asp:TableCell>
            <div id="divResidential" runat="server">
            <asp:Table ID="tblResidential" CssClass="formTable" CellSpacing="0" BorderWidth="0" runat="server">
                <asp:TableRow>
                    <asp:TableCell Width="15px" VerticalAlign="Top" >
                        <asp:CheckBox ID="chkBR_Residential" runat="server" />
                    </asp:TableCell>
                    <asp:TableCell VerticalAlign="Top" Width="100px">
                        Residential
                    </asp:TableCell>
                    <asp:TableCell Width="700px">
                        A facility publicly or privately owned providing a rehabilitative treatment environment which serves four or more adults who suffer from brain injury and at least one of whom is not related to the operator.  Services include personal assistance or supervision for a period of twenty-four hours continuously per day preparing them for community integration.  
                        <br /><br />
                        Capacity
                        <telerik:RadMaskedTextBox ID="txtBR_ResCapacity" runat="server" Mask="###" Width="20px" /> 
                        <br /><br />
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            </div>
            </asp:TableCell></asp:TableRow><asp:TableRow><asp:TableCell></asp:TableCell></asp:TableRow><asp:TableRow><asp:TableCell>
            <div id="divComLiving" runat="server">
            <asp:Table ID="tblComLiving" CssClass="formTable" CellSpacing="0" BorderWidth="0" runat="server">
                <asp:TableRow>
                    <asp:TableCell Width="15px" VerticalAlign="Top">
                        <asp:CheckBox ID="chkBR_CommLiving" runat="server" />
                    </asp:TableCell>
                    <asp:TableCell VerticalAlign="Top" Width="100px">
                        Community Living
                    </asp:TableCell>
                    <asp:TableCell Width="700px">
                        A home or apartment publicly or privately owned providing a rehabilitative treatment environment which serves one to six adults who suffer from brain injury and at least one of whom is not related to the operator, in a home or apartment setting preparing them for community integration.  
                        <br /><br />
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            </div>
            </asp:TableCell></asp:TableRow><asp:TableRow><asp:TableCell></asp:TableCell></asp:TableRow><asp:TableRow><asp:TableCell>
            <div id="divOutpatient" runat="server">
            <asp:Table ID="tblOutpatient" CssClass="formTable" CellSpacing="0" BorderWidth="0" runat="server">
                <asp:TableRow>
                    <asp:TableCell Width="15px" VerticalAlign="Top">
                        <asp:CheckBox ID="chkBR_Outpatient" runat="server" />
                    </asp:TableCell>
                    <asp:TableCell VerticalAlign="Top" Width="100px">
                        Outpatient
                    </asp:TableCell>
                    <asp:TableCell Width="700px">
                        A facility publicly or privately owned providing an outpatient rehabilitative treatment environment which serves adults who suffer from brain injury and at least one of whom is not related to the operator, in an outpatient day treatment setting in order to advance the individual’s independence for higher level of community or transition to a greater level of independence in community or vocational function.
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell ColumnSpan="2">
                    </asp:TableCell>
                    <asp:TableCell HorizontalAlign="Left">
                        <br />
                        Outpatient Operating Hours
                        <br />
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
                                    <asp:DropDownList ID="listAmPmFrom" runat="server" Font-Size="11px">
                                        <asp:ListItem Text="" Value=""></asp:ListItem>
                                        <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
                                        <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td align="right">
                                    <asp:Label ID="lblTO" runat="server">To: </asp:Label>
                                </td>
                                <td colspan="2" valign="top">
                                    <telerik:RadMaskedTextBox ID="txtHoursMinutesTo" runat="server" Mask="##:##" Width="35" />
                                    <asp:DropDownList ID="listAmPmTo" runat="server" Font-Size="11px">
                                        <asp:ListItem Text="" Value=""></asp:ListItem>
                                        <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
                                        <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td colspan="2">
                                </td>                        
                            </tr>
                        </table>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            </div>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    </div>

<div id="divHP_ProviderType" runat="server">
    <asp:Table ID="tblHP_ProviderType" runat="server" CssClass="formTable" CellSpacing="0" BorderWidth="0" >
        <asp:TableRow>
            <asp:TableCell Width="175px" HorizontalAlign="Right">
                <asp:Label ID="lblHPTypeFac" runat="server" Text="Type of Hospice: " />
            </asp:TableCell>
            <asp:TableCell Width="200px">
                <telerik:RadComboBox ID="listHP_ProviderType" runat="server" Width="150px" />
            </asp:TableCell>
            <asp:TableCell Width="100px" HorizontalAlign="Right">
                <asp:Label ID="lblHP_Accred" runat="server" Text="Accreditation: " />
            </asp:TableCell>
            <asp:TableCell Width="150px">
                <telerik:RadComboBox ID="listHP_Accred" runat="server" Width="65px" />
            </asp:TableCell>
            <asp:TableCell Width="100px" HorizontalAlign="Right">
                <asp:Label ID="lblMedicareCertified" runat="server" Text="Medicare Certified: " />
            </asp:TableCell>
            <asp:TableCell Width="150px">
                <telerik:RadComboBox ID="listMedicareCertified" runat="server" Width="55px" >
                    <Items>
                        <telerik:RadComboBoxItem Text="" Value="" />
                        <telerik:RadComboBoxItem Text="Yes" Value="Y" />
                        <telerik:RadComboBoxItem Text="No" Value="N" />
                    </Items>
                </telerik:RadComboBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Right">
                <asp:Label ID="lblHPFiscalYrEnd" runat="server" Text="Cost Report Year End ('MM/DD'): " />
            </asp:TableCell>
            <asp:TableCell>
                <telerik:RadMaskedTextBox ID="txtHP_FYE" runat="server" Mask="##/##" Width="40" />
            </asp:TableCell>
            <asp:TableCell HorizontalAlign="Right">
                <asp:Label ID="lblHP_HospitalBased" runat="server" Text="Hospital Based: " />
            </asp:TableCell>
            <asp:TableCell>
                <telerik:RadComboBox ID="listHP_HospitalBased" runat="server" Width="55px" >
                    <Items>
                        <telerik:RadComboBoxItem Text="" Value="" />
                        <telerik:RadComboBoxItem Text="Yes" Value="Y" />
                        <telerik:RadComboBoxItem Text="No" Value="N" />
                    </Items>
                </telerik:RadComboBox>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</div>

<div id="divPT_ProviderType" runat="server">
    <div id="divPT_ProviderTypeHeader" runat="server">
        Accreditation (applies to renewals only)
    </div>
    <asp:TableRow>
            <asp:TableCell Width="175px" HorizontalAlign="Right">
                <asp:Label ID="lblPT_AccreditingOrganization" runat="server" Text="Accrediting Organization: " />
            </asp:TableCell>
            <asp:TableCell Width="200px">
                <telerik:RadComboBox ID="rcbPT_AccreditingOrganization" runat="server" Width="70px" Enabled="false" >
                    <Items>
                        <telerik:RadComboBoxItem Text="" Value="" />
                        <telerik:RadComboBoxItem Text="JCAHO" Value="JCAHO" />
                        <telerik:RadComboBoxItem Text="CHAP" Value="CHAP" />
                        <telerik:RadComboBoxItem Text="ACHC" Value="ACHC" />
                    </Items>
                </telerik:RadComboBox>
            </asp:TableCell>
            <asp:TableCell Width="100px" HorizontalAlign="Right">
                <asp:Label ID="lblPTAccreditationExpDate" runat="server" Text="Accreditation Expiration Date: " />
            </asp:TableCell>
            <asp:TableCell Width="150px">
                <asp:TextBox ID="txtPT_AccreditationExpDate" runat="server" Enabled="false"></asp:TextBox>
            </asp:TableCell>
    </asp:TableRow>
</div>

<div id="divHH_ProviderType" runat="server">
    <div id="divHH_ProviderTypeHeader" class="formTableSectionDiv" runat="server">
        Additional Items
    </div>
    <asp:Table ID="tblHH_ProviderType" runat="server" CssClass="formTable" CellSpacing="0" BorderWidth="0" >
        <asp:TableRow>
            <asp:TableCell Width="200px" HorizontalAlign="Right">
                <asp:Label ID="lblHH_Accred" runat="server" Text="Accreditation: " />
            </asp:TableCell>
            <asp:TableCell Width="100px">
                <telerik:RadComboBox ID="listHH_Accred" runat="server" Width="70px" >
                    <Items>
                        <telerik:RadComboBoxItem Text="" Value="" />
                        <telerik:RadComboBoxItem Text="JCAHO" Value="JCAHO" />
                        <telerik:RadComboBoxItem Text="CHAP" Value="CHAP" />
                        <telerik:RadComboBoxItem Text="ACHC" Value="ACHC" />
                    </Items>
                </telerik:RadComboBox>
            </asp:TableCell>
            <asp:TableCell Width="100px" HorizontalAlign="Right">
                <asp:Label ID="lblHH_Deemed" runat="server" Text="Deemed: " />
            </asp:TableCell>
            <asp:TableCell Width="100px">
                <telerik:RadComboBox ID="listHH_Deemed" runat="server" Width="55px">
                    <Items>
                        <telerik:RadComboBoxItem Text="" Value="" />
                        <telerik:RadComboBoxItem Text="Yes" Value="Y" />
                        <telerik:RadComboBoxItem Text="No" Value="N" />
                    </Items>
                </telerik:RadComboBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
           <asp:TableCell HorizontalAlign="Right">
                <asp:Label ID="lblHH_FYE" runat="server" Text="Cost Report Year End ('MM/DD'): " />
            </asp:TableCell>
            <asp:TableCell>
                <telerik:RadMaskedTextBox ID="txtHH_FYE" runat="server" Mask="##/##" Width="30" />
            </asp:TableCell>
            <asp:TableCell HorizontalAlign="Right">
                <asp:Label ID="lblHH_HospBased" runat="server" Text="Hospital Based: " />
            </asp:TableCell>
            <asp:TableCell>
                <telerik:RadComboBox ID="listHH_HospBased" runat="server" Width="55px" >
                    <Items>
                        <telerik:RadComboBoxItem Text="" Value="" />
                        <telerik:RadComboBoxItem Text="Yes" Value="Y" />
                        <telerik:RadComboBoxItem Text="No" Value="N" />
                    </Items>
                </telerik:RadComboBox>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</div>

<div id="divAS_ProviderType" runat="server">
    <div id="divAS_ProviderTypeHeader" class="formTableSectionDiv" runat="server">
        Additional Items
    </div>
    <asp:Table ID="tblAS_ProviderType" runat="server" CssClass="formTable" CellSpacing="0" BorderWidth="0" >
    	<asp:TableRow>
            <asp:TableCell Width="150px" HorizontalAlign="Right">
                <asp:Label ID="lblAS_Deemed" runat="server" Text="Deemed: " />
            </asp:TableCell>
            <asp:TableCell Width="100px">
                <telerik:RadComboBox ID="listAS_Deemed" runat="server" Width="55px">
                    <Items>
                        <telerik:RadComboBoxItem Text="" Value="" />
                        <telerik:RadComboBoxItem Text="Yes" Value="Y" />
                        <telerik:RadComboBoxItem Text="No" Value="N" />
                    </Items>
                </telerik:RadComboBox>
            </asp:TableCell>        
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell Width="150px" HorizontalAlign="Right">
                <asp:Label ID="lblASCostYearEnd" runat="server" Text="Cost Report Year End ('MM/DD'): " />
            </asp:TableCell>
            <asp:TableCell>
                <telerik:RadMaskedTextBox ID="txtAS_FYE" runat="server" Mask="##/##" Width="40" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell Width="150px" HorizontalAlign="Right">Location:</asp:TableCell>
            <asp:TableCell Width="150px" >
                <asp:CheckBox ID="chkAS_HospitalBased" runat="server" OnClick="ToggleAS_LocationChk('HOSPBASED');" />
                <asp:Label ID="lblAS_HospitalBased" runat="server" Text="Hospital Based" />
            </asp:TableCell>
            <asp:TableCell Width="150px" >
                <asp:CheckBox ID="chkAS_FreeStanding" runat="server" OnClick="ToggleAS_LocationChk('FREESTAND');" />
                <asp:Label ID="lblAS_FreeStanding" runat="server" Text="Free Standing" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</div>       

<div id="divNH_ProviderType" runat="server">
    <div id="DivAdminMultiFacHeader" class="formTableSectionDiv" runat="server">
        Multi-Facility Administration
    </div>
    <div>
        <div style="clear:both;">
            <div style="float:left;width:400px;padding-left:20px;">
                Is the administrator an administrator for more than one facility?
            </div>
            <div style="float:left;width:270px;">
                <asp:RadioButton ID="radMultiFacAdminYes" runat="server" GroupName="radMultiFacAdmin" Text="Yes"/>
                <asp:RadioButton ID="radMultiFacAdminNo" runat="server" GroupName="radMultiFacAdmin" Text="No"/>
            </div>
        </div>
        <div style="clear:both;">
            <div style="float:left;padding-left:20px;width:200px;text-align:right;">
                Name other facility:
            </div>
            <div style="float:left;width:250px;padding-left:10px;">
                <asp:TextBox ID="txtNHAdminOtherFacName" runat="server" MaxLength="60"/>
            </div>
        </div>
        <div style="clear:both;">
            <div style="float:left;padding-left:20px;width:200px;text-align:right;">
                Is facility single or multi-story?
            </div>
            <div style="float:left;width:270px;padding-left:10px;">
                <asp:RadioButton ID="radSingleStory" GroupName="radSingleMultiStory" runat="server" Text="Single Story"/>
                <asp:RadioButton ID="radMultiStory" GroupName="radSingleMultiStory" runat="server" Text="Multi-Story"/>
            </div>
        </div>
        <br style="clear:both"/>
    </div>
</div>

<div id="divCO_ProviderType" runat="server">
    <asp:Table ID="tblCO_ProviderType" runat="server" CssClass="formTable" CellSpacing="0" BorderWidth="0" >
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Right">
                <asp:Label ID="lblCOFiscalYrEnd" runat="server" Text="Cost Report Year End ('MM/DD'): " />
            </asp:TableCell>
            <asp:TableCell>
                <telerik:RadMaskedTextBox ID="txtCO_FYE" runat="server" Mask="##/##" Width="40" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</div>

<div id="divHO_ProviderType" runat="server">
    <asp:Table ID="tblHO_ProvderType" runat="server" CssClass="formTable" CellSpacing="0" BorderWidth="0" >
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Right">
                <asp:Label ID="lblHOFiscalYrEnd" runat="server" Text="Cost Report Year End ('MM/DD'): " />
            </asp:TableCell>
            <asp:TableCell>
                <telerik:RadMaskedTextBox ID="txtHO_FYE" runat="server" Mask="##/##" Width="40" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</div>
</telerik:RadAjaxPanel>