<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ReportParameters.ascx.cs" Inherits="AppControl.ReportParameters" %>

<div id="DirectoryParams" runat="server" visible="true">
    <table id="tableReportParams" class="formTable" width="100%" cellspacing="1" cellpadding="1">
        <tr>
            <td>&nbsp; </td>
            <td>&nbsp; </td>
        </tr>    
        <tr>
            <td>&nbsp; </td>
            <td>&nbsp; </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="labelProvType" runat="server">Select Provider Type</asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="listDirectories" runat="server" Visible="False" />
                <asp:DropDownList ID="listFacilities" runat="server" Visible="False" />
            </td>
        </tr>    
        <tr>
            <td>
                <asp:Label ID="labelTimeLineDateFrom" runat="server">Time Line Date From</asp:Label>
            </td>
            <td>
                <telerik:RadDatePicker ID="dtTimeLineDateFrom" Runat="server" MinDate="01/01/1900"  Calendar-FastNavigationStep="12" />
                <asp:Label ID="lblStartDtReq0" runat="server" ForeColor="Red" 
                    Font-Size="Smaller" Visible="False" Text="Time Line Date From Required" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="labelTimeLineDateTo" runat="server">Time Line Date To</asp:Label>
            </td>
            <td>
                <telerik:RadDatePicker ID="dtTimeLineDateTo" Runat="server" MinDate="01/01/1900"  Calendar-FastNavigationStep="12" />
                <asp:Label ID="lblEndDtReq0" runat="server" ForeColor="Red" Font-Size="Smaller" 
                    Visible="False" Text="Time Line Date To Required" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="labelTimeLineMet" runat="server">Time Line Met</asp:Label>        
            </td>
            <td>
                <asp:DropDownList ID="listTimeLineMet" runat="server">
	                <asp:ListItem Value="1" Text="Yes"/>
	                <asp:ListItem Value="0" Text="No"/>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="labelTypeOfDate" runat="server">Type Of Date</asp:Label>        
            </td>
            <td>
                <asp:DropDownList ID="listTypeOfDate" runat="server">
	                <asp:ListItem Text="Request Date" Value="REQUEST_RECEIVED_DATE" />
	                <asp:ListItem Text="Schedule Date" Value="IDR_SCHEDULED_DATE" />
	                <asp:ListItem Text="Conducted Date" Value="IDR_CONDUCTED_DATE" />
	                <asp:ListItem Text="Withdrawn Date" Value="IDR_WITHDRAWN_DATE" />
	                <asp:ListItem Text="Completed Date" Value="IDR_COMPLETION_DATE" />
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="labelAspenIDRType" runat="server">Aspen IDRType</asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="listAspenIDRType" runat="server" Visible="False" />
            </td>
        </tr>
    </table>
</div>
<div id="DivOwershipReport" runat="server" visible="false">
    <table id="Table1" runat="server" width="99.5%">
        <tr>
            <td colspan="2"><b><asp:Label ID="Label2" runat="server">Select Report Criteria</asp:Label></b><br/></td>
        </tr>
    </table>
    <table id="Table2" runat="server" width="400">
        <tr> 
            <td><br />
                <asp:Label ID="Label8" runat="server" Text="Search By Provider Type" />
            </td>
        </tr>
        <tr> 
            <td>
                <asp:RadioButton ID="OwnershipProgramAll"    runat="server" Text="All" GroupName="grpOwnershipProgram" AutoPostBack="true" oncheckedchanged="grpOwnershipProgram_CheckedChanged" Checked="true" /><br />
                <asp:RadioButton ID="OwernsipProgramChoice" runat="server" text="Provider Type: " GroupName="grpOwnershipProgram" AutoPostBack="true" oncheckedchanged="grpOwnershipProgram_CheckedChanged" />
            </td>
            <td>
                <br />
                <asp:DropDownList ID="listOwnershipProgram" runat="server" Visible="false" Width="250" />
            </td>
        </tr>
    </table>
    <table id="Table3" runat="server" width="400">
        <tr> 
            <td><br />
                <asp:Label ID="Label9" runat="server" Text="Search By Owner/Entity Name" />
            </td>
        </tr>
        <tr> 
            <td>
                <asp:RadioButton ID="OwnerNameAny"    runat="server" Text="Match Any Part of Name" GroupName="grpEntityName" /><br />
                <asp:RadioButton ID="OwnerNameExact" runat="server" text="Exact Match Name" GroupName="grpEntityName"  />
            </td>
            <td>
                <br />
                <asp:TextBox ID="EntityNameMatch" runat="server"></asp:TextBox>
            </td>
        </tr>
    </table>
    <table id="Table4" runat="server" width="400">
        <tr> 
            <td><br />
                <asp:Label ID="Label10" runat="server" Text="Search By EIN #" />
            </td>
        </tr>
        <tr> 
            <td>
                <asp:RadioButton ID="EINNumAny"    runat="server" Text="Match Any Part of EIN" GroupName="grpEIN" AutoPostBack="true"  /><br />
                <asp:RadioButton ID="EINNumExact" runat="server" text="Exact Match EIN" GroupName="grpEIN" AutoPostBack="true"  />
            </td>
            <td>
                <br />
                <asp:TextBox ID="EINMatch" runat="server"></asp:TextBox>
            </td>
        </tr>
    </table>
    <table id="Table5" runat="server" width="400">
        <tr> 
            <td><br />
                <asp:Label ID="Label11" runat="server" Text="Type Ownership" />
            </td>
        </tr>
        <tr> 
            <td>
                <asp:RadioButton ID="OwnershipTypeAll"    runat="server" Text="All" GroupName="grpOwnershipType" AutoPostBack="true" oncheckedchanged="grpOwnershipType_CheckedChanged" Checked="true" /><br />
                <asp:RadioButton ID="OwnershipTypeChoice" runat="server" text="Type Ownership: " GroupName="grpOwnershipType" AutoPostBack="true" oncheckedchanged="grpOwnershipType_CheckedChanged" />
            </td>
            <td>
                <br />
                <asp:DropDownList ID="listOwnershipType" runat="server" Visible="false" Width="250" /><br /><br />
            </td>
        </tr>
    </table>
    <table id="Table6" runat="server" width="400">
        <tr> 
            <td colspan="2">
                <asp:CheckBox ID="PrimaryEntityOnly" runat="server" Text="Display Primary Entity/Owner Only" /><br /><br />
            </td>
        </tr>
    </table>
    <table id="Table7" runat="server" width="400">
        <tr>
            <td colspan="2"><asp:Label ID="Label13" runat="server">Report Sort Order:</asp:Label><br/></td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:RadioButton ID="OwnershipFacilityName" runat="server" Text="Sort By Facility Name" GroupName="OwnershipReportSortBy" Checked="true" /><br /> 
                <asp:RadioButton ID="OwnershipStateId" runat="server" Text="Sort By State Id" GroupName="OwnershipReportSortBy"  /><br />
                <asp:RadioButton ID="OwnershipEntityName" runat="server" Text="Sort By Owner/Entity Name" GroupName="OwnershipReportSortBy" /><br />                       
            </td>
        </tr>
    </table>
</div>
<!--------------------------------------------------------------START SEARCH CRITERIA REPORT----------------------------------------------------------------------->
<div id="DivSearchCriteriaReport" runat="server" visible="false">
    <table id="SCRTable1" runat="server" width="99.5%">
        <tr>
            <td colspan="2"><b><asp:Label ID="Label1" runat="server">Select Report Criteria</asp:Label></b><br/></td>
        </tr>
    </table>
    <table id="SCRTable2" runat="server" width="400">
        <tr> 
            <td><br />
                <asp:Label ID="lblSCRProviderType" runat="server" Text="Search By Provider Type" />
            </td>
        </tr>
        <tr> 
            <td>
                <asp:RadioButton ID="SCRProgramAll"    runat="server" Text="All" GroupName="grpSCRProgram" AutoPostBack="true" oncheckedchanged="grpSCRProgram_CheckedChanged" Checked="true" /><br />
                <asp:RadioButton ID="SCRProgramChoice" runat="server" text="Provider Type: " GroupName="grpSCRProgram" AutoPostBack="true" oncheckedchanged="grpSCRProgram_CheckedChanged" />
            </td>
            <td>
                <br />
                <asp:DropDownList ID="listSCRProgram" runat="server" Visible="false" Width="250" />
            </td>
        </tr>
    </table>
    <table id="SCRTable3" runat="server" width="400">
        <tr>
            <td colspan="3">
                <br />
                <asp:Label ID="SCRlblStateIdList" runat="server" Text="Search by State ID - Enter up to 5 State IDs"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>1: <asp:TextBox ID="SCRStateID1" runat="server"></asp:TextBox></td>
            <td>2: <asp:TextBox ID="SCRStateID2" runat="server"></asp:TextBox></td>
            <td>3: <asp:TextBox ID="SCRStateID3" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>4: <asp:TextBox ID="SCRStateID4" runat="server"></asp:TextBox></td>
            <td>5: <asp:Textbox ID="SCRStateID5" runat="server"></asp:Textbox></td>
            <td></td>
        </tr>
    </table>
    <table id="SCRTable4">
        <tr>
            <td><br />
                <asp:Label ID="SCRlblIncludeClosedProviders" runat="server" Text="Include Closed Providers"></asp:Label></td>
        </tr>
        <tr>
            <td>
                <asp:CheckBox ID="cbSCRIncludeClosedProviders" runat="server" />
            </td>
        </tr>
    </table>
   <!----SCR Table 5 Sub Parameters List, User may select only one at a time, each selection runs a seperate report------------------------------>
    <table id="SCRSReportSelection" runat="server">
        <tr>
            <td>
                <br />
                <asp:Label ID="SCRlblReportSelection" runat="server" Text="Select Sub Report Criteria to Run Individual Report"></asp:Label></td>
        </tr>
        <tr>
            <td><asp:RadioButtonList ID="SCRrbReportSelection" runat="server" AutoPostBack="true" OnSelectedIndexChanged="SCRrbReportSelection_SelectedIndexChanged">
                    <asp:ListItem
                        Text="Administrator Last Name"
                        Value="SCR1"
                    />
                     <asp:ListItem
                        Text="Director Of Nursing Last Name"
                        Value="SCR2"
                    />
                 <asp:ListItem
                        Text="Primary Corporation/Entity Name"
                        Value="SCR3"
                    />
                 <asp:ListItem
                        Text="Non-Primary Owner Name"
                        Value="SCR4"
                    />
                 <asp:ListItem
                        Text="Type Facility/Module"
                        Value="SCR5"
                    />
                 <asp:ListItem
                        Text="HCBS Program Service - Module"
                        Value="SCR6"
                    />
                 <asp:ListItem
                        Text="Offsites/Branches/Satellites"
                        Value="SCR7"
                    />
                </asp:RadioButtonList></td>
        </tr>
    </table>
    <table id="SCRReportSelection1" runat="server" visible="false">
       <tr> 
            <td><br />
                <asp:Label ID="SCRlblReportSelection1" runat="server" Text="Search By Administrator Last Name" />
            </td>
        </tr>
        <tr> 
            <td>
                <asp:RadioButtonList ID="SCRAdministratorLastName" runat="server">
                    <asp:ListItem Text="Match Any Part of Name" value="ANY"></asp:ListItem>
                    <asp:ListItem Text="Exact Match Name" Value="ALL"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
            <td>
                <br />
                <asp:TextBox ID="AdministratorNameMatch" runat="server"></asp:TextBox>
            </td>
        </tr>
    </table>
     <table id="SCRReportSelection2" runat="server" visible="false">
       <tr> 
            <td><br />
                <asp:Label ID="SCRlblReportSelection2" runat="server" Text="Search By Director of Nursing Last Name" />
            </td>
        </tr>
        <tr> 
            <td>
                <asp:RadioButtonList ID="SCRDirectorNursingLastName" runat="server">
                    <asp:ListItem Text="Match Any Part of Name" Value="ANY"></asp:ListItem>
                    <asp:ListItem Text="Exact Match Name" Value="ALL"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
            <td>
                <br />
                <asp:TextBox ID="DirectorNursingNameMatch" runat="server"></asp:TextBox>
            </td>
        </tr>
    </table>
     <table id="SCRReportSelection3" runat="server" visible="false">
       <tr> 
            <td><br />
                <asp:Label ID="SCRlblReportSelection3" runat="server" Text="Search By Primary Corporation Entity Name" />
            </td>
        </tr>
        <tr> 
            <td>
                <asp:RadioButtonList ID="SCRPrimaryCorporationEntityName" runat="server">
                    <asp:ListItem Text="Match Any Part of Name" Value="ANY"></asp:ListItem>
                    <asp:ListItem Text="Exact Match Name" Value="ALL"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
            <td>
                <br />
                <asp:TextBox ID="PrimaryCorporationEntityNameMatch" runat="server"></asp:TextBox>
            </td>
        </tr>
    </table>
     <table id="SCRReportSelection4" runat="server" visible="false">
       <tr> 
            <td><br />
                <asp:Label ID="SCRlblReportSelection4" runat="server" Text="Search By Non-Primary Owner Name" />
            </td>
        </tr>
        <tr> 
            <td>
                <asp:RadioButtonList ID="SCRNonPrimaryOwnerName" runat="server">
                    <asp:ListItem Text="Match Any Part of Name" Value="ANY"></asp:ListItem>
                    <asp:ListItem Text="Exact Match Name" Value="ALL"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
            <td>
                <br />
                <asp:TextBox ID="NonPrimaryOwnerNameMatch" runat="server"></asp:TextBox>
            </td>
        </tr>
    </table>
     <table id="SCRReportSelection5" runat="server" visible="false">
       <tr> 
            <td><br />
                <asp:Label ID="SCRlblReportSelection5" runat="server" Text="Search By Type Facility/Module" />
            </td>
        </tr>
        <tr> 
            <td><asp:Label ID="SCRTypeFacilityErrorMsg" runat="server" visible="false" Text="* Select A Program to enable Type Facility/Module Selection" ></asp:Label>
                <asp:CheckBoxList ID="SCRTypeFacilityModule" runat="server">
                </asp:CheckBoxList>
            </td>
        </tr>
    </table>
     <table id="SCRReportSelection6" runat="server" visible="false">
       <tr> 
            <td><br />
                <asp:Label ID="SCRlblReportSelection6" runat="server" Text="Search By HCBS Program/Service Module" />
            </td>
        </tr>
        <tr> 
            <td>
                <asp:CheckBoxList ID="SCRHBCSProgramServiceModule" runat="server">
                    <asp:ListItem Text="Adult Day Care (ADC)" Value="4"></asp:ListItem>
                    <asp:ListItem Text="Family Support (FS)" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Personal Care Attendant (PCA)" Value="2"></asp:ListItem>
                    <asp:ListItem Text="Respite Care - Center Based" Value="7"></asp:ListItem>
                    <asp:ListItem Text="Respite Care - In Home" Value="8"></asp:ListItem>
                    <asp:ListItem Text="Substitute Family Care" Value="9"></asp:ListItem>
                    <asp:ListItem Text="Supported Employment" Value="10"></asp:ListItem>
                </asp:CheckBoxList>
            </td>
        </tr>
    </table>
     <table id="SCRReportSelection7" runat="server" visible="false">
       <tr> 
            <td><br />
                <asp:Label ID="SCRlblReportSelection7" runat="server" Text="Search By Providers With Offsites/Branches/Satellites" />
            </td>
        </tr>
        <tr> 
            <td>
                 <asp:RadioButtonList ID="SCROffsitesBranchesSatellites" runat="server">
                    <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                    <asp:ListItem Text="NO" Value="N"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
    </table>
    <br />
</div>
<!---------------------------------------------------------------END SEARCH CRITERIA REPORT------------------------------------------------------->

<div id="DivCheckLogParams" runat="server" visible="false">
    <table id="tblCheckLogParams" runat="server" width="99.5%">
        <tr>
            <td colspan="2"><asp:Label ID="lblCheckLogParam" runat="server">Select Report Criteria</asp:Label><br/><br/></td>
        </tr>
    </table>
    <table id="tblCheckLogOpts" runat="server" width="400">
        <tr>
            <td colspan="2">
                <asp:RadioButton ID="optLicensing" runat="server" Text="Licensing" GroupName="CheckLogType" Checked="true" /><br />
                <asp:RadioButton ID="optNonLicensing" runat="server" Text="Non-Licensing" GroupName="CheckLogType" /><br />
                <asp:RadioButton ID="optHealthCareFund" runat="server" Text="Health Care Fund" GroupName="CheckLogType" /><br />
                <asp:RadioButton ID="optNursingHomeFund" runat="server" Text="Nursing Home Fund" GroupName="CheckLogType" /><br />
                <asp:RadioButton ID="optAll" runat="server" Text="All" GroupName="CheckLogType" /><br /><br />
            </td>
        </tr>
    </table>
    <table id="tblReportSortByOpts" runat="server" width="400">
        <tr>
            <td colspan="2"><asp:Label ID="lblReportSortOrder" runat="server">Report Sort Order:</asp:Label><br/></td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:RadioButton ID="optStateId" runat="server" Text="State Id" GroupName="ReportSortByType" Checked="true" /><br />
                <asp:RadioButton ID="optFacilityName" runat="server" Text="Facility Name" GroupName="ReportSortByType" /><br /> 
                <asp:RadioButton ID="optFieldOffice" runat="server" Text="Field Office" GroupName="ReportSortByType" /><br />                       
            </td>
        </tr>
    </table>
    <table id="tblDateParameters" runat="server" width="400">
        <tr>
            <td colspan="2"><br/><asp:Label ID="lblTransactionDates" runat="server">Transaction Dates</asp:Label><br/></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblStartDt" runat="server" Text="Start Date: " />
            </td>
            <td>
                <telerik:RadDatePicker ID="rdpStartDt" runat="server" DateInput-DateFormat="MM/dd/yyyy" MinDate="01/01/0001"  Calendar-FastNavigationStep="12" />
                <asp:Label ID="lblStartDtReq" runat="server" ForeColor="Red" Font-Size="Smaller" Visible="false" Text="Start Date Required" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblEndDt" runat="server" Text="End Date: " />
            </td>
            <td>
                <telerik:RadDatePicker ID="rdpEndDt" runat="server" DateInput-DateFormat="MM/dd/yyyy" MinDate="01/01/0001"  Calendar-FastNavigationStep="12" />
                <asp:Label ID="lblEndDtReq"        runat="server" ForeColor="Red" Font-Size="Smaller" Visible="false" Text="End Date Required" />
            </td>
        </tr>
    </table>
    <table id="tblProviderType" runat="server" width="400">
        <tr> 
            <td><br />
                <asp:Label ID="lblProvTypeChoice" runat="server" Text="Select Provider Type" />
            </td>
        </tr>
        <tr> 
            <td>
                <asp:RadioButton ID="optProvTypeAll"    runat="server" Text="All"             GroupName="grpProvTypeAll" AutoPostBack="true" oncheckedchanged="grpProvTypeAll_CheckedChanged" Checked="true" /><br />
                <asp:RadioButton ID="optProvTypeChoice" runat="server" text="Provider Type: " GroupName="grpProvTypeAll" AutoPostBack="true" oncheckedchanged="grpProvTypeAll_CheckedChanged" />
            </td>
            <td>
                <br />
                <asp:DropDownList ID="lstCheckLogParamsProvType" runat="server" Visible="false" Width="250" />
            </td>
        </tr>
        <tr> 
            <td>
               <br />
                <asp:Label ID="lblStateID" runat="server" Text="State Id" Visible="false" />
            </td>
            <td>
                <asp:TextBox ID="StateIDTxt" runat="server" Visible="false" Width="150" MaxLength="10" />
            </td>
        </tr>
    </table>
</div>

<div id="DivLabelReportParams" runat="server" visible="false">
    <table id="tblLabelReportParameters" runat="server" width="99.5%">
        <tr>
            <td colspan="2">Select Report Criteria<br /><br /></td>
            </tr>
    </table>
    <table id="tblLabelReportOpts" runat="server" width="100%">
        <tr>
            <td>
                <asp:RadioButton ID="optExpirationDate" runat="server" Text="Expiration Date" GroupName="ReportRunByType" Checked="true" /><br />
            </td>
            <td>
                <telerik:RadDatePicker ID="rdpExpirationDate" runat="server" DateInput-DateFormat="MM/dd/yyyy" MinDate="01/01/0001"  Calendar-FastNavigationStep="12" />
                <asp:Label ID="lblExpirationDateReq" runat="server" ForeColor="Red" Font-Size="Smaller" Visible="false" Text="Expiration Date Required" />
            </td>
        </tr>    
         <tr>
            <td>
                <asp:RadioButton ID="optProviderType" runat="server" Text="Provider Type" GroupName="ReportRunByType" /><br />
            </td>
            <td>
                 <asp:DropDownList ID="listProviderType" runat="server" Visible="False" />
            </td>
        </tr> 
        <tr>
            <td>
                <asp:RadioButton ID="optExpirationDateProviderType" runat="server" Text="Expiration Date & Provider Type" GroupName="ReportRunByType" /><br />
            </td>
            <td>
             <telerik:RadDatePicker ID="rdpExpirationDateProviderType" runat="server" DateInput-DateFormat="MM/dd/yyyy" MinDate="01/01/0001"  Calendar-FastNavigationStep="12" />
                <asp:Label ID="lblExpirationDateProviderTypeReq" runat="server" ForeColor="Red" Font-Size="Smaller" Visible="false" Text="Expiration Date Required" />
                 <asp:DropDownList ID="listExpirationDateProviderType" runat="server" Visible="False" />
            </td>
        </tr>   
    </table>
</div>
<div id="DivDecalLabelReport" runat="server" visible="false">
    <table id="tblDecalLabel" runat="server" width="99.5%">
        <tr>
        <td>
                <asp:RadioButton ID="optSingleDecal" runat="server" Text="Single Decal" GroupName="ReportRunByType" /><br />
            </td>
            <td>
                <asp:Label ID="lblDecal" runat="server" Text="Please Enter Decal" />
                <asp:TextBox ID="DecalTxt" runat="server" Visible="true" Width="150" MaxLength="10" />
            </td>
            </tr>
             <tr>
             <td>
                <asp:RadioButton ID="optDecalFromTo" runat="server" Text="From To Decal" GroupName="ReportRunByType" /><br />
            </td>
            <td>
                <asp:Label ID="lblDecalFrom" runat="server" Text="Please Enter Decal From" />
                <asp:TextBox ID="DecalTxtFrom" runat="server" Visible="true" Width="150" MaxLength="10" />
            </td>
            <td>
                <asp:Label ID="lblDecalTo" runat="server" Text="Please Enter Decal To" />
                <asp:TextBox ID="DecalTxtTo" runat="server" Visible="true" Width="150" MaxLength="10" />
            </td>
            </tr>
    </table>    
</div>
<div id="DivVehicleReportParams" runat="server" visible="false">
    <table id="tblVehicleReport" runat="server" width="99.5%">
        <tr>
            <td colspan="2"><asp:Label ID="lblVehicleReportParam" runat="server">Select Report Criteria</asp:Label><br/><br/></td>
        </tr>
    </table>
    <table id="tblVehicleReportOpts" runat="server" width="400">
        <tr>
            <td colspan="2">
                <asp:RadioButton ID="optVehicleStateId" runat="server" Text="State Id" GroupName="grpVehicleReportType" Checked="true" /><br/><br/>
            </td>
	    <td>
                <asp:TextBox ID="VehicleStateIDTxt" runat="server" Visible="false" Width="150" MaxLength="10" /><br/><br/>
            </td>
            <td>
                <asp:RadioButton ID="optVehicleProviderType" runat="server" text="Provider Type: " GroupName="grpVehicleReportType" AutoPostBack="true" oncheckedchanged="grpVehicleReportType_CheckedChanged" /><br/><br/>
            </td>
	    <td>
                 <asp:DropDownList ID="listVehicleProviderType" runat="server" Visible="False" /><br/><br/>
            </td>
        </tr>
    </table>
    <table id="tblVehicleReportSortByOpts" runat="server" width="400">
        <tr>
            <td colspan="2"><asp:Label ID="lblVehicleReportSortOrder" runat="server">Report Sort Order:</asp:Label><br/></td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:RadioButton ID="optVehicleFacilitName" runat="server" Text="Facility Name" GroupName="VehicleReportSortByType" Checked="true" /><br />
                <asp:RadioButton ID="optVehicleDecal" runat="server" Text="Vehicle Decal" GroupName="VehicleReportSortByType" /><br />              
            </td>
        </tr>
    </table>    
    </div>    
<div id="DivAdHocReportParameters" runat="server" visible="false">
    <table id="tblAdHocReport" runat="server" width="99.5%">
        <tr>
            <td colspan="3"><asp:Label ID="lblAdHocReportSelection" runat="server">Select Report Criteria</asp:Label><br/><br/></td>
        </tr>
    </table>    
    <table id="tblAdHocReportProvider" runat="server" width="690">
       <tr>
       <td>
             <asp:Label ID="lblAdHocReportSelectProviderType" runat="server">Select Provider Type</asp:Label>            
             <asp:DropDownList ID="listAdHocProviderType" runat="server" Visible="True" />          
        </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblSelectProviderStatus" runat="server">Include Closed Providers</asp:Label>
                <asp:CheckBox ID="chkIncludeClosedProviders" runat="server" />
                </td>
        </tr>
    </table> 
    <table id="tblAdHocReportOpts"  runat="server" width="99.5%"> 
        <tr>
        <td>
                <asp:CheckBox ID="chkStateId" runat="server" Text="StateId" Checked="false" /><br/><br/>                
            </td>
        <td>
                <asp:CheckBox ID="chkFacilityName" runat="server" Text="Facility Name" Checked="false" /><br/><br/>
            </td>
        <td>
                <asp:CheckBox ID="chkLicenseNum" runat="server" Text="License Number" Checked="false" /><br/><br/>                
            </td>             	
            </tr>   
             <tr>           
        <td>
                <asp:CheckBox ID="chkOriginalLicenseIssueDate" runat="server" Text="Original License Issue Date" Checked="false" /><br/><br/>                
            </td>           
        <td>
                <asp:CheckBox ID="chkLicenseExpirationDate" runat="server" Text="License Expiration Date" Checked="false" /><br/><br/>               
            </td>            
        <td>         
               <asp:CheckBox ID="chkGeoAddress" runat="server" Text="Geographical Street" Checked="false" /><br/><br/>                
            </td>	
            </tr>  
            <tr>
        <td>
               <asp:CheckBox ID="chkGeoCity" runat="server" Text="Geographical City" Checked="false" /><br/><br/>                
            </td>
        <td>
               <asp:CheckBox ID="chkGeoState" runat="server" Text="Geographical State" Checked="false" /><br/><br/>  
            </td>
        <td>
               <asp:CheckBox ID="chkGeoZip" runat="server" Text="Geographical ZIP" Checked="false" /><br/><br/>                
            </td>
             </tr>  
            <tr>
        <td>       
               <asp:CheckBox ID="chkAdministrator" runat="server" Text="Administrator" Checked="false" /><br/><br/>        
            </td>           
        <td>
               <asp:CheckBox ID="chkTelephone" runat="server" Text="Telephone" Checked="false" /><br/><br/>                
            </td>
        <td>
               <asp:CheckBox ID="chkFAX" runat="server" Text="FAX" Checked="false" /><br/><br/>                
            </td>
             </tr>  
            <tr>
        <td>
               <asp:CheckBox ID="chkParish" runat="server" Text="Parish" Checked="false" /><br/><br/>               
            </td>
        <td>
               <asp:CheckBox ID="chkMailAddress" runat="server" Text="Mailing Street" Checked="false" /><br/><br/>                
            </td>
        <td>
               <asp:CheckBox ID="chkMailCity" runat="server" Text="Mailing City" Checked="false" /><br/><br/>
            </td>	
            </tr>
            <tr>
        <td>        
               <asp:CheckBox ID="chkMailState" runat="server" Text="Mailing State" Checked="false" /><br/><br/>                
            </td>
        <td>        
               <asp:CheckBox ID="chkMailZip" runat="server" Text="Mailing ZIP" Checked="false" /><br/><br/>         
            </td>                      
        <td>
               <asp:CheckBox ID="chkTypeOwnership" runat="server" Text="Type Ownership" Checked="false" /><br/><br/>                
            </td>
             </tr>
            <tr> 
        <td>        
               <asp:CheckBox ID="chkCorporationName" runat="server" Text="Corporation Name" Checked="false" /><br/><br/>                
            </td>
        <td>
               <asp:CheckBox ID="chkCorporationAddress" runat="server" Text="Corporation Street" Checked="false" /><br/><br/>        
            </td>
        <td>
               <asp:CheckBox ID="chkCorporationCity" runat="server" Text="Corporation City" Checked="false" /><br/><br/>                
            </td>	
            </tr>
            <tr>
        <td>    
               <asp:CheckBox ID="chkCorporationState" runat="server" Text="Corporation State" Checked="false" /><br/><br/>                
            </td>
        <td>
               <asp:CheckBox ID="chkCorporationZip" runat="server" Text="Corporation ZIP" Checked="false" /><br/><br/>        
            </td>            
        <td>
               <asp:CheckBox ID="chkCorpPhone" runat="server" Text="Corporation Phone" Checked="false" /><br/><br/>                
            </td>
            </tr>
            <tr>
        <td>
               <asp:CheckBox ID="chkTypeProgram" runat="server" Text="Type Program" Checked="false" /><br/><br/>               
            </td>
        <td>
               <asp:CheckBox ID="chkTypeFacility" runat="server" Text="Type Facility" Checked="false" /><br/><br/>         
            </td>
        <td>       
               <asp:CheckBox ID="chkOffsites" runat="server" Text="Offsites - Y/N" Checked="false" /><br/><br/>                
            </td>	
            </tr>
            <tr>
        <td>         
                <asp:CheckBox ID="chkCapacity" runat="server" Text="Capacity" Checked="false" /><br/><br/>                               
            </td>
        <td>
                <asp:CheckBox ID="chkNumberOfLicensedBedsMainCampus" runat="server" Text="Number Of Licensed Beds Main Campus" Checked="false" /><br/><br/>                
            </td>
        <td>
                <asp:CheckBox ID="chkNumberOfLicensedBedsOffsite" runat="server" Text="Number Of Licensed Beds Offsite" Checked="false" /><br/><br/>                
            </td>            	
            </tr>
            <tr>
        <td>        
                <asp:CheckBox ID="chkTotalNumberOfLicensedBeds" runat="server" Text="Total # License Beds" Checked="false" /><br/><br/>                
            </td>
        <td>   
                <asp:CheckBox ID="chkTotalNumberOfCertifiedBeds" runat="server" Text="Total # Certified Beds" Checked="false" /><br/><br/>                
            </td>
        <td>
                <asp:CheckBox ID="chkMedicaidVendorNumber" runat="server" Text="Medicaid Vendor Number" Checked="false" /><br/><br/>                               
            </td>	
            </tr>
            <tr>
        <td>
               <asp:CheckBox ID="chkUnitRoomsMainCampus" runat="server" Text="#Unit/Rooms Main Campus" Checked="false" /><br/><br/>  
            </td>
        <td>
               <asp:CheckBox ID="chkUnitRoomsOffsite" runat="server" Text="#Unit/Rooms Offsite" Checked="false" /><br/><br/>                
            </td>
        <td>                
                <asp:CheckBox ID="chkCCN" runat="server" Text="CCN" Checked="false" /><br/><br/>                               
            </td>            	
            </tr>
            <tr>
            <td>
            <asp:CheckBox ID="chkPsychUnit" runat="server" Text="Psych Unit - Y/N" Checked="false" /><br/><br/>               
            </td> 
            <td>
             <asp:CheckBox ID="chkRehabUnit" runat="server" Text="Rehab Unit - Y/N" Checked="false" /><br/><br/>                               
            </td>    
        <td>             
             <asp:CheckBox ID="chkCertificationExpirationDate" runat="server" Text="Certification Expiration Date" Checked="false" /><br/><br/>             
            </td>	
            </tr>
             <tr>
            <td>
            <asp:CheckBox ID="chkDHHRegion" runat="server" Text="DHH Region" Checked="false" /><br/><br/>
            </td> 
            <td>
            <asp:CheckBox ID="chkHSSFieldOffice" runat="server" Text="HSS Field Office" Checked="false" /><br/><br/> 
            </td>  
            <td>
            <asp:CheckBox ID="chkEmailAddress" runat="server" Text="Email Address" Checked="false" /><br/><br/> 
            </td>          	
            </tr>
             <tr>
            <td>
            <asp:CheckBox ID="chkCurrentLicenseIssueDate" runat="server" Text="Current License Issue Date" Checked="false" /><br/><br/>
            </td> 
            <td>
            <asp:CheckBox ID="chkLicensureEffectiveDate" runat="server" Text="Licensure Effective Date" Checked="false" /><br/><br/> 
            </td>  
            <td>
            <asp:CheckBox ID="chkLicensureSurveyDate" runat="server" Text="Licensure Survey Date" Checked="false" /><br/><br/> 
            </td>
            <td>
            <asp:CheckBox ID="chkCurrentOwners" runat="server" Text="Current Owners" Checked="false" /><br/><br/> 
            </td>                	
            </tr>

    </table>   
    </div>    
<asp:Button runat="server" ID="buttonReport" Text="Generate Report" onclick="buttonReport_Click" />
