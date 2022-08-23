using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using Microsoft.Reporting.WebForms;
using ATG.BusinessObject;

namespace AppControl
{
    public partial class ReportParameters : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                // setup the list controls
                SetUpDirectoriesList();
                SetUpFacilitiesList();
                SetUpIDRTypeList();
                SetUpLabelsList();
                SetUpCheckLogParamsProvType();
                SetUpVehicleParamsProvType();
                SetUpAdHocParamsProvType();
                SetUpLabelsList1();
                SetUpOwnershipTypeList();
                SetUpOwnershipProgramList();
                SetUpSCRProgramList();
            }
        }

        /// <summary>
        /// Display the appropriate Report
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void buttonReport_Click(object sender, EventArgs e)
        {
            RadWindowManager rwm1 = new RadWindowManager();
            this.Controls.Add(rwm1);
            rwm1.ID = "RadWindowManager1";

            // get the selected program's ID
            string programId = null;
            string vehicleDecal = null;
            string vehicleDecalFrom = null;
            string vehicleDecalTo = null;
            string stateID = null;
            string winTitle = "";
            DateTime rptStartDt = new DateTime();
            DateTime rptExpirationDate = new DateTime();
            DateTime rptExpirationDateProviderType = new DateTime();
            DateTime rptEndDt = new DateTime();
            string rptType = "";
            string rptSortBy = "";
            string rptRunBy = "";
            string TypeFacility = "false";
            string FacilityName = "false";
            string GeoAddress = "false";
            string GeoCity = "false";
            string GeoState = "false";
            string TypeProgram = "false";
            string GeoZip = "false";
            string Administrator = "false";
            string Telephone = "false";
            string FAX = "false";
            string MailAddress = "false";
            string MailCity = "false";
            string MailState = "false";
            string MailZip = "false";
            string Parish = "false";
            string TypeOwnership = "false";
            string CorporationName = "false";
            string CorporationAddress = "false";
            string CorporationCity = "false";
            string CorporationState = "false";
            string CorporationZip = "false";
            string CorpPhone = "false";
            string DHHRegion = "false";
            string HSSFieldOffice = "false";
            string Offsites = "false";
            string Capacity = "false";
            string LicensedBedsMain = "false";
            string LicensedBedsOffsite = "false";
            string LicensedBedsTotal = "false";
            string CertifiedBedsTotal = "false";
            string UnitRoomsMainCampus = "false";
            string UnitRoomsOffsite = "false";
            string PsychUnit = "false";
            string RehabUnit = "false";
            string LicenseNum = "false";
            string OriginalLicenseIssueDate = "false";
            string LicenseExpirationDate = "false";
            string CCN = "false";
            string StateId = "false";
            string CertificationExpirationDate = "false";
            string MedicaidVendorNumber = "false";
            string EmailAddress = "false";
            string CurrentLicenseIssueDate = "false";
            string LicensureEffectiveDate = "false";
            string LicensureSurveyDate = "false";
            string IncludeClosedProviders = "false";
            string CurrentOwners = "false";

            switch (NameOfReport)
            {
                #region CASE: ACO_POPS_DISCREPANCY_REPORT
                case "ACOPOPSDISCREPANCYREPORT":
                    programId = listDirectories.SelectedValue;
                    winTitle = "POPS-ACO Discrepancy Report";

                    break;
                #endregion

                #region CASE: DIRECTORIES_REPORT
                case "DIRECTORIESREPORT":
                    winTitle = "Directories Report"; 
                    programId = null;

                    /*** IF ALL IS NOT SELECTED ... Load ProgramID value ***/
                    if (optProvTypeChoice.Checked)
                        programId = lstCheckLogParamsProvType.SelectedValue;               
                    
                    // set the parameters
                    ReportParameter[] parm = new ReportParameter[1];
                    parm[0] = new ReportParameter("Program_Id", programId);

                    // set Session Variables
                    Session["ReportParams"] = parm;

                    break; ;
                #endregion

                #region CASE: FACILITIES_REPORT
                case "FACILITIESREPORT":
                    programId = listFacilities.SelectedValue;
                    winTitle = "Facilities Report";

                    // set the parameters
                    ReportParameter[] parm1 = new ReportParameter[1];
                    parm1[0] = new ReportParameter("Program_Id", programId);

                    // set Session Variables
                    Session["ReportParams"] = parm1;

                    break; ;
                #endregion
                #region CASE: EMS_INSURANCE_REPORT
                case "EMSINSURANCEREPORT":
                    winTitle = "EMS Insurance Report";

                    //// set the parameters
                    //ReportParameter[] parm1 = new ReportParameter[1];
                    //parm1[0] = new ReportParameter("Program_Id", programId);

                    //// set Session Variables
                    //Session["ReportParams"] = parm1;

                    break; ;
                #endregion

                #region CASE: NEMT_INSURANCE_REPORT
                case "NEMTINSURANCEREPORT":
                    winTitle = "NEMT Insurance Report";

                    //// set the parameters
                    //ReportParameter[] parm1 = new ReportParameter[1];
                    //parm1[0] = new ReportParameter("Program_Id", programId);

                    //// set Session Variables
                    //Session["ReportParams"] = parm1;

                    break; ;
                #endregion

                #region CASE: DECAL_LABELS_REPORT
                case "DECALLABELSREPORT5262":
                    winTitle = "Decal Labels Report";
                    ReportParameter[] parm5 = new ReportParameter[1];
                    ReportParameter[] parm6 = new ReportParameter[3];
                    if (optSingleDecal.Checked)
                    {
                        vehicleDecal = DecalTxt.Text;
                        parm5[0] = new ReportParameter("VEHICLE_DECAL", vehicleDecal);
                        Session["ReportParams"] = parm5;
                    }
                    else if (optDecalFromTo.Checked)
                    {
                        vehicleDecalFrom = DecalTxtFrom.Text;
                        vehicleDecalTo = DecalTxtTo.Text;
                        parm6[0] = new ReportParameter("VEHICLE_DECAL", vehicleDecal);
                        parm6[1] = new ReportParameter("VEHICLE_DECAL_FROM", vehicleDecalFrom);
                        parm6[2] = new ReportParameter("VEHICLE_DECAL_TO", vehicleDecalTo);
                        Session["ReportParams"] = parm6;
                    }
                     
                    
                    break; ;
                #endregion

                #region CASE: AD_HOC_DATA_REPORT
                case "ADHOCDATAREPORT":
                    winTitle = "Ad Hoc Data Report";
                    ReportParameter[] AdHocparm = new ReportParameter[48];
                    programId = listAdHocProviderType.SelectedValue;
                    AdHocparm[0] = new ReportParameter("Program_Id", programId);

                    if (chkTypeFacility.Checked)
                    {
                        TypeFacility = "true";
                    }
                    if (chkFacilityName.Checked)
                    {
                        FacilityName = "true";
                    }
                    if (chkGeoAddress.Checked)
                    {
                        GeoAddress = "true";
                    }
                    if (chkGeoCity.Checked)
                    {
                        GeoCity = "true";
                    }
                    if (chkGeoState.Checked)
                    {
                        GeoState = "true";
                    }
                    if (chkTypeProgram.Checked)
                    {
                        TypeProgram = "true";
                    }
                    if (chkGeoZip.Checked)
                    {
                        GeoZip = "true";
                    }
                    if (chkAdministrator.Checked)
                    {
                        Administrator = "true";
                    }
                    if (chkTelephone.Checked)
                    {
                        Telephone = "true";
                    }
                    if (chkFAX.Checked)
                    {
                        FAX = "true";
                    }
                    if (chkMailAddress.Checked)
                    {
                        MailAddress = "true";
                    }
                    if (chkMailCity.Checked)
                    {
                        MailCity = "true";
                    }
                    if (chkMailState.Checked)
                    {
                        MailState = "true";
                    }
                    if (chkMailZip.Checked)
                    {
                        MailZip = "true";
                    }
                    if (chkParish.Checked)
                    {
                        Parish = "true";
                    }
                    if (chkTypeOwnership.Checked)
                    {
                        TypeOwnership = "true";
                    }
                    if (chkCorporationName.Checked)
                    {
                        CorporationName = "true";
                    }
                    if (chkCorporationAddress.Checked)
                    {
                        CorporationAddress = "true";
                    }
                    if (chkCorporationCity.Checked)
                    {
                        CorporationCity = "true";
                    }
                    if (chkCorporationState.Checked)
                    {
                        CorporationState = "true";
                    }
                    if (chkCorporationZip.Checked)
                    {
                        CorporationZip = "true";
                    }
                    if (chkCorpPhone.Checked)
                    {
                        CorpPhone = "true";
                    }
                    if (chkDHHRegion.Checked)
                    {
                        DHHRegion = "true";
                    }
                    if (chkHSSFieldOffice.Checked)
                    {
                        HSSFieldOffice = "true";
                    }
                    if (chkOffsites.Checked)
                    {
                        Offsites = "true";
                    }
                    if (chkCapacity.Checked)
                    {
                        Capacity = "true";
                    }
                    if (chkNumberOfLicensedBedsMainCampus.Checked)
                    {
                        LicensedBedsMain = "true";
                    }
                    if (chkNumberOfLicensedBedsOffsite.Checked)
                    {
                        LicensedBedsOffsite = "true";
                    }
                    if (chkTotalNumberOfLicensedBeds.Checked)
                    {
                        LicensedBedsTotal = "true";
                    }
                    if (chkTotalNumberOfCertifiedBeds.Checked)
                    {
                        CertifiedBedsTotal = "true";
                    }
                    if (chkUnitRoomsMainCampus.Checked)
                    {
                        UnitRoomsMainCampus = "true";
                    }
                    if (chkUnitRoomsOffsite.Checked)
                    {
                        UnitRoomsOffsite = "true";
                    }
                    if (chkPsychUnit.Checked)
                    {
                        PsychUnit = "true";
                    }
                    if (chkRehabUnit.Checked)
                    {
                        RehabUnit = "true";
                    }
                    if (chkLicenseNum.Checked)
                    {
                        LicenseNum = "true";
                    }
                    if (chkOriginalLicenseIssueDate.Checked)
                    {
                        OriginalLicenseIssueDate = "true";
                    }
                    if (chkLicenseExpirationDate.Checked)
                    {
                        LicenseExpirationDate = "true";
                    }
                    if (chkCCN.Checked)
                    {
                        CCN = "true";
                    }
                    if (chkStateId.Checked)
                    {
                        StateId = "true";
                    }
                    if (chkCertificationExpirationDate.Checked)
                    {
                        CertificationExpirationDate = "true";
                    }
                    if (chkMedicaidVendorNumber.Checked)
                    {
                        MedicaidVendorNumber = "true";
                    }
                    if (chkEmailAddress.Checked)
                    {
                        EmailAddress = "true";
                    }
                    if (chkCurrentLicenseIssueDate.Checked)
                    {
                        CurrentLicenseIssueDate = "true";
                    }
                    if (chkLicensureEffectiveDate.Checked)
                    {
                        LicensureEffectiveDate = "true";
                    }
                    if (chkLicensureSurveyDate.Checked)
                    {
                        LicensureSurveyDate = "true";
                    }
                    if (chkIncludeClosedProviders.Checked)
                    {
                        IncludeClosedProviders = "true";
                    }
                    if (chkCurrentOwners.Checked)
                    {
                        CurrentOwners = "true";
                    }

                    AdHocparm[1] = new ReportParameter("TypeFacility", TypeFacility);
                    AdHocparm[2] = new ReportParameter("FacilityName", FacilityName);
                    AdHocparm[3] = new ReportParameter("GeoAddress", GeoAddress);
                    AdHocparm[4] = new ReportParameter("GeoCity", GeoCity);
                    AdHocparm[5] = new ReportParameter("GeoState", GeoState);
                    AdHocparm[6] = new ReportParameter("TypeProgram", TypeProgram);
                    AdHocparm[7] = new ReportParameter("GeoZip", GeoZip);
                    AdHocparm[8] = new ReportParameter("Administrator", Administrator);
                    AdHocparm[9] = new ReportParameter("Telephone", Telephone);
                    AdHocparm[10] = new ReportParameter("FAX", FAX);
                    AdHocparm[11] = new ReportParameter("MailAddress", MailAddress);
                    AdHocparm[12] = new ReportParameter("MailCity", MailCity);
                    AdHocparm[13] = new ReportParameter("MailState", MailState);
                    AdHocparm[14] = new ReportParameter("MailZip", MailZip);
                    AdHocparm[15] = new ReportParameter("Parish", Parish);
                    AdHocparm[16] = new ReportParameter("TypeOwnership", TypeOwnership);
                    AdHocparm[17] = new ReportParameter("CorporationName", CorporationName);
                    AdHocparm[18] = new ReportParameter("CorporationAddress", CorporationAddress);
                    AdHocparm[19] = new ReportParameter("CorporationCity", CorporationCity);
                    AdHocparm[20] = new ReportParameter("CorporationState", CorporationState);
                    AdHocparm[21] = new ReportParameter("CorporationZip", CorporationZip);
                    AdHocparm[22] = new ReportParameter("CorpPhone", CorpPhone);
                    AdHocparm[23] = new ReportParameter("DHHRegion", DHHRegion);
                    AdHocparm[24] = new ReportParameter("HSSFieldOffice", HSSFieldOffice);
                    AdHocparm[25] = new ReportParameter("Offsites", Offsites);
                    AdHocparm[26] = new ReportParameter("Capacity", Capacity);
                    AdHocparm[27] = new ReportParameter("LicensedBedsMain", LicensedBedsMain);
                    AdHocparm[28] = new ReportParameter("LicensedBedsOffsite", LicensedBedsOffsite);
                    AdHocparm[29] = new ReportParameter("LicensedBedsTotal", LicensedBedsTotal);
                    AdHocparm[30] = new ReportParameter("CertifiedBedsTotal", CertifiedBedsTotal);
                    AdHocparm[31] = new ReportParameter("PsychUnit", PsychUnit);
                    AdHocparm[32] = new ReportParameter("RehabUnit", RehabUnit);
                    AdHocparm[33] = new ReportParameter("LicenseNum", LicenseNum);
                    AdHocparm[34] = new ReportParameter("OriginalLicenseIssueDate", OriginalLicenseIssueDate);
                    AdHocparm[35] = new ReportParameter("LicenseExpirationDate", LicenseExpirationDate);
                    AdHocparm[36] = new ReportParameter("CCN", CCN);
                    AdHocparm[37] = new ReportParameter("StateId", StateId);
                    AdHocparm[38] = new ReportParameter("CertificationExpirationDate", CertificationExpirationDate);
                    AdHocparm[39] = new ReportParameter("MedicaidVendorNumber", MedicaidVendorNumber);
                    AdHocparm[40] = new ReportParameter("UnitRoomsMainCampus", UnitRoomsMainCampus);
                    AdHocparm[41] = new ReportParameter("UnitRoomsOffsite", UnitRoomsOffsite);
                    AdHocparm[42] = new ReportParameter("EmailAddress", EmailAddress);
                    AdHocparm[43] = new ReportParameter("CurrentLicenseIssueDate", CurrentLicenseIssueDate);
                    AdHocparm[44] = new ReportParameter("LicensureEffectiveDate", LicensureEffectiveDate);
                    AdHocparm[45] = new ReportParameter("LicensureSurveyDate", LicensureSurveyDate);
                    AdHocparm[46] = new ReportParameter("Include_Closed_Providers", IncludeClosedProviders);
                    AdHocparm[47] = new ReportParameter("Current_Owners", CurrentOwners);
                    Session["ReportParams"] = AdHocparm;
                    break; ;
                #endregion



                #region CASE: ONLINE_PAYMENTS_REPORT
                case "ONLINEPAYMENTSREPORT":
                    lblStartDtReq.Visible = false;
                    lblEndDtReq.Visible = false;

                    rptStartDt = new DateTime();
                    rptEndDt = new DateTime();
                    rptSortBy = "";

                    if (null == rdpStartDt.SelectedDate)
                    {
                        lblStartDtReq.Visible = true;
                    }

                    if (null == rdpEndDt.SelectedDate)
                    {
                        lblEndDtReq.Visible = true;
                    }

                    if (lblStartDtReq.Visible || lblEndDtReq.Visible)
                        return;
                    else
                    {
                        winTitle = "Online Payment Report";

                        rptStartDt = rdpStartDt.SelectedDate.Value;
                        rptEndDt = rdpEndDt.SelectedDate.Value;

                        if (optStateId.Checked)
                            rptSortBy = "1";
                        else if (optFacilityName.Checked)
                            rptSortBy = "2";
                        else if (optFieldOffice.Checked)
                            rptSortBy = "3";
                        // set the parameters
                        ReportParameter[] CheckLogParm = new ReportParameter[3];
                        CheckLogParm[0] = new ReportParameter("ProcessedDateFrom", rptStartDt.ToShortDateString());
                        CheckLogParm[1] = new ReportParameter("ProcessedDateTo", rptEndDt.ToShortDateString());
                        CheckLogParm[2] = new ReportParameter("SortBy", rptSortBy);

                        // set Session Variables
                        Session["ReportParams"] = CheckLogParm;
                    }
                    break; ;
                #endregion

                #region CASE: IDR_SUMMARY_REPORT
                case "IDRSUMMARYREPORT":
                    // IDR Summary report

                    lblStartDtReq0.Visible = false;
                    lblEndDtReq0.Visible = false;
                    
                    rptStartDt = new DateTime();
                    rptEndDt = new DateTime();

                    string strTimeLineDateFrom = "";
                    string strTimeLineDateTo = "";
                    string strTimeLineMet = "";
                    string strAspenIDRType = "";
                    string strTypeOfDate = "";

                    if (null == dtTimeLineDateFrom.SelectedDate)
                    {
                        lblStartDtReq0.Visible = true;
                    }

                    if (null == dtTimeLineDateTo.SelectedDate)
                    {
                        lblEndDtReq0.Visible = true;
                    }

                    if (lblStartDtReq0.Visible || lblEndDtReq0.Visible)
                        return;
                    else
                    {

                        winTitle = "IDR Summary Report";

                        // get the values
                        if (dtTimeLineDateFrom != null && dtTimeLineDateFrom.SelectedDate.HasValue)
                            strTimeLineDateFrom = dtTimeLineDateFrom.SelectedDate.ToString();
                        if (dtTimeLineDateTo != null && dtTimeLineDateTo.SelectedDate.HasValue)
                            strTimeLineDateTo = dtTimeLineDateTo.SelectedDate.ToString();
                        strTimeLineMet = listTimeLineMet.SelectedValue;
                        strAspenIDRType = listAspenIDRType.SelectedValue;
                        strTypeOfDate = listTypeOfDate.SelectedValue;

                        // set the parameters
                        ReportParameter[] parm2 = new ReportParameter[5];
                        parm2[0] = new ReportParameter("TimeLineDateFrom", strTimeLineDateFrom);
                        parm2[1] = new ReportParameter("TimeLineDateTo", strTimeLineDateTo);
                        parm2[2] = new ReportParameter("TimeLineMet", strTimeLineMet);
                        parm2[3] = new ReportParameter("AspenIDRType", strAspenIDRType);
                        parm2[4] = new ReportParameter("TypeOfDate", strTypeOfDate);

                        // set Session Variables
                        Session["ReportParams"] = parm2;
                    }
                    break; ;
                #endregion

                #region CASE: Check_Log_Report
                case "CheckLogReport":
                    lblStartDtReq.Visible = false;
                    lblEndDtReq.Visible = false;

                    rptStartDt = new DateTime();
                    rptEndDt = new DateTime();
                    rptType = "";
                    rptSortBy = ""; //1=State, 2=Facility, 3=Office

                    if ( null == rdpStartDt.SelectedDate )
                    {
                        lblStartDtReq.Visible = true;
                    }
                    
                    if ( null == rdpEndDt.SelectedDate )
                    {
                        lblEndDtReq.Visible = true;
                    }

                    if ( lblStartDtReq.Visible || lblEndDtReq.Visible )
                        return;
                    else
                    {
                        winTitle = "Check Log Report";

                        rptStartDt = rdpStartDt.SelectedDate.Value;
                        rptEndDt = rdpEndDt.SelectedDate.Value;

                        if ( optLicensing.Checked )
                            rptType = "1";
                        else if ( optNonLicensing.Checked )
                            rptType = "2";
                        //else if ( optPlanReview.Checked )
                        //    rptType = "3";
                        else if (optHealthCareFund.Checked)
                            rptType = "3";
                        else if (optNursingHomeFund.Checked)
                            rptType = "4";
                        else if ( optAll.Checked )
                            rptType = "5";

                        if (optStateId.Checked)
                            rptSortBy = "1";
                        else if (optFacilityName.Checked)
                            rptSortBy = "2";
                        else if (optFieldOffice.Checked)
                            rptSortBy = "3";

                        // set the parameters
                        ReportParameter[] CheckLogParm = new ReportParameter[4];
                        CheckLogParm[0] = new ReportParameter( "ProcessedDateFrom", rptStartDt.ToShortDateString() );
                        CheckLogParm[1] = new ReportParameter( "ProcessedDateTo", rptEndDt.ToShortDateString() );
                        CheckLogParm[2] = new ReportParameter( "Licensed", rptType );
                        CheckLogParm[3] = new ReportParameter("SortBy", rptSortBy);

                        // set Session Variables
                        Session["ReportParams"] = CheckLogParm;
                    }
                    break; ;
                #endregion

                #region CASE: Check_Log_UnlinkedPaymentsReport
                case "CheckLogUnlinkedPayments":
                    lblStartDtReq.Visible = false;
                    lblEndDtReq.Visible = false;

                    rptStartDt = new DateTime();
                    rptEndDt = new DateTime();
                    rptType = "";

                    if (null == rdpStartDt.SelectedDate)
                    {
                        lblStartDtReq.Visible = true;
                    }

                    if (null == rdpEndDt.SelectedDate)
                    {
                        lblEndDtReq.Visible = true;
                    }

                    if (lblStartDtReq.Visible || lblEndDtReq.Visible)
                        return;
                    else
                    {
                        winTitle = "Check Log Report Unlinked Payments";

                        rptStartDt = rdpStartDt.SelectedDate.Value;
                        rptEndDt = rdpEndDt.SelectedDate.Value;

                        string providerType = "";
                        if (optProvTypeChoice.Checked)
                            providerType = lstCheckLogParamsProvType.SelectedValue.ToString();


                        // set the parameters
                        ReportParameter[] CheckLogParm = new ReportParameter[3];
                        CheckLogParm[0] = new ReportParameter("ProcessedDateFrom", rptStartDt.ToShortDateString());
                        CheckLogParm[1] = new ReportParameter("ProcessedDateTo", rptEndDt.ToShortDateString());
                        CheckLogParm[2] = new ReportParameter("ProviderType", providerType);

                        // set Session Variables
                        Session["ReportParams"] = CheckLogParm;
                    }
                    break; ;
                #endregion

                #region CASE: OwnershipReport
                case "OWNERSHIPREPORT":
                    {
                        winTitle = "Ownership Reort";
                        string programType = "ALL";
                        string entityNameMatch = "ANY";
                        string einMatch = "ANY";
                        string ownershipType = "ALL";
                        string primaryEntityOnly = "FALSE";
                        string sortBy = "";

                        if (OwernsipProgramChoice.Checked)
                            programType = listOwnershipProgram.SelectedValue.ToString();

                        if (OwnerNameExact.Checked)
                            entityNameMatch = "EXACT";

                        if (EINNumExact.Checked)
                            einMatch = "EXACT";

                        if (OwnershipTypeChoice.Checked)
                            ownershipType = listOwnershipType.SelectedValue.ToString();

                        if (PrimaryEntityOnly.Checked)
                            primaryEntityOnly = "TRUE";

                        if (OwnershipEntityName.Checked)
                            sortBy = "F";
                        else if (OwnershipStateId.Checked)
                            sortBy = "S";
                        else
                            sortBy = "E";

                        // set the parameters
                       ReportParameter[] OwnershipParams = new ReportParameter[8];
                       OwnershipParams[0] = new ReportParameter("Program_Id", programType);
                       OwnershipParams[1] = new ReportParameter("Owner_Entity_Match", entityNameMatch);
                       OwnershipParams[2] = new ReportParameter("Owner_Entity_Value", EntityNameMatch.Text);
                       OwnershipParams[3] = new ReportParameter("EIN_Match", einMatch);
                       OwnershipParams[4] = new ReportParameter("EIN_Value", EINMatch.Text);
                       OwnershipParams[5] = new ReportParameter("Type_Ownership", ownershipType);
                       OwnershipParams[6] = new ReportParameter("Display_Primary_Owner_Only", primaryEntityOnly);
                       OwnershipParams[7] = new ReportParameter("Sort_By", sortBy);

                        // set Session Variables
                       Session["ReportParams"] = OwnershipParams;
                    }
                    break; ;
                #endregion

                #region CASE: SearchCriteriaReport
                case "SEARCHCRITERIAREPORT":
                    {
                        //main search criteria
                        string programType = "ALL";
                        string StateIdList = "";
                        string SCRIncludeClosedProviders = "false";

                        winTitle = "Search Criteria Report";

                        if (SCRProgramChoice.Checked)
                            programType = listSCRProgram.SelectedValue;

                        if (!String.IsNullOrEmpty(SCRStateID1.Text))
                            StateIdList += SCRStateID1.Text;

                        if (!String.IsNullOrEmpty(SCRStateID2.Text))
                            StateIdList += "," + SCRStateID2.Text;

                        if (!String.IsNullOrEmpty(SCRStateID3.Text))
                            StateIdList += "," + SCRStateID3.Text;

                        if (!String.IsNullOrEmpty(SCRStateID4.Text))
                            StateIdList += "," + SCRStateID4.Text;

                        if (!String.IsNullOrEmpty(SCRStateID5.Text))
                            StateIdList += "," + SCRStateID5.Text;

                        if (cbSCRIncludeClosedProviders.Checked)
                            IncludeClosedProviders = "true";

                        //determine which of seven reports to run, paramter list driven of report criteria
                        ReportParameter[] SCRParams = null;

                        switch (SCRrbReportSelection.SelectedValue)
                        {
                            case "SCR1":
                                SCRParams = new ReportParameter[5];
                                SCRParams[0] = new ReportParameter("Program_Id", programType);
                                SCRParams[1] = new ReportParameter("State_Id_List", StateIdList);
                                SCRParams[2] = new ReportParameter("Include_Closed_Providers", SCRIncludeClosedProviders);
                                SCRParams[3] = new ReportParameter("Administrator_Match", SCRAdministratorLastName.SelectedValue);
                                SCRParams[4] = new ReportParameter("Administrator_Last_Name", AdministratorNameMatch.Text);
                                break;
                            case "SCR2":
                                SCRParams = new ReportParameter[5];
                                SCRParams[0] = new ReportParameter("Program_Id", programType);
                                SCRParams[1] = new ReportParameter("State_Id_List", StateIdList);
                                SCRParams[2] = new ReportParameter("Include_Closed_Providers", SCRIncludeClosedProviders);
                                SCRParams[3] = new ReportParameter("Director_Of_Nursing_Match", SCRDirectorNursingLastName.SelectedValue);
                                SCRParams[4] = new ReportParameter("Director_Of_Nursing_Last_Name", DirectorNursingNameMatch.Text);
                                break;
                            case "SCR3":
                                SCRParams = new ReportParameter[5];
                                SCRParams[0] = new ReportParameter("Program_Id", programType);
                                SCRParams[1] = new ReportParameter("State_Id_List", StateIdList);
                                SCRParams[2] = new ReportParameter("Include_Closed_Providers", SCRIncludeClosedProviders);
                                SCRParams[3] = new ReportParameter("Primary_Entity_Name_Match", SCRPrimaryCorporationEntityName.SelectedValue);
                                SCRParams[4] = new ReportParameter("Primary_Entity_Name", PrimaryCorporationEntityNameMatch.Text);
                                break;
                            case "SCR4":
                                SCRParams = new ReportParameter[5];
                                SCRParams[0] = new ReportParameter("Program_Id", programType);
                                SCRParams[1] = new ReportParameter("State_Id_List", StateIdList);
                                SCRParams[2] = new ReportParameter("Include_Closed_Providers", SCRIncludeClosedProviders);
                                SCRParams[3] = new ReportParameter("Non_Primary_Owner_Name_Match", SCRNonPrimaryOwnerName.SelectedValue);
                                SCRParams[4] = new ReportParameter("Non_Primary_Owner_Name", NonPrimaryOwnerNameMatch.Text);
                                break;
                            case "SCR5":
                                string typeFacility = "";
                                foreach (ListItem item in SCRTypeFacilityModule.Items)
                                {
                                    if (item.Selected)
                                        typeFacility += item.Value + ",";
                                }
                                if(!String.IsNullOrEmpty(typeFacility))
                                {
                                int index = typeFacility.LastIndexOf(',');
                                typeFacility.Remove(index, 1);
                                }

                                SCRParams = new ReportParameter[4];
                                SCRParams[0] = new ReportParameter("Program_Id", programType);
                                SCRParams[1] = new ReportParameter("State_Id_List", StateIdList);
                                SCRParams[2] = new ReportParameter("Include_Closed_Providers", SCRIncludeClosedProviders);
                                SCRParams[3] = new ReportParameter("Type_Facility", typeFacility);
                                break;
                            case "SCR6":
                                string hcbsServicesModules = "";
                                foreach (ListItem item in SCRHBCSProgramServiceModule.Items)
                                {
                                    if (item.Selected)
                                        hcbsServicesModules += item.Value + ",";
                                }
                                if (!String.IsNullOrEmpty(hcbsServicesModules))
                                {
                                    int index = hcbsServicesModules.LastIndexOf(',');
                                    hcbsServicesModules.Remove(index, 1);
                                }
                                SCRParams = new ReportParameter[4];
                                SCRParams[0] = new ReportParameter("Program_Id", programType);
                                SCRParams[1] = new ReportParameter("State_Id_List", StateIdList);
                                SCRParams[2] = new ReportParameter("Include_Closed_Providers", SCRIncludeClosedProviders);
                                SCRParams[3] = new ReportParameter("HCBS_Service_Modules", hcbsServicesModules);
                                break;
                            case "SCR7":
                                SCRParams = new ReportParameter[4];
                                SCRParams[0] = new ReportParameter("Program_Id", programType);
                                SCRParams[1] = new ReportParameter("State_Id_List", StateIdList);
                                SCRParams[2] = new ReportParameter("Include_Closed_Providers", SCRIncludeClosedProviders);
                                SCRParams[3] = new ReportParameter("Offsite_Branches_Satellites", SCROffsitesBranchesSatellites.SelectedValue);
                                break;
                            default:
                                SCRParams = new ReportParameter[5];
                                SCRParams[0] = new ReportParameter("Program_Id", programType);
                                SCRParams[1] = new ReportParameter("State_Id_List", StateIdList);
                                SCRParams[2] = new ReportParameter("Include_Closed_Providers", SCRIncludeClosedProviders);
                                SCRParams[3] = new ReportParameter("Administrator_Match", "ANY");
                                SCRParams[4] = new ReportParameter("Administrator_Last_Name", "");
                                break;
                        }

                        // set Session Variables
                        Session["ReportParams"] = SCRParams;
                    }
                    break; ;
                #endregion


                #region CASE: POPS_LABEL_REPORT_5262
                case "POPSLABELREPORT5262":
                    
                    rptRunBy = ""; 
                    winTitle = "5262 Labels Report";

                    if (optExpirationDate.Checked)
                    {
                        lblExpirationDateReq.Visible = false;
                        rptExpirationDate = new DateTime();

                        if (null == rdpExpirationDate.SelectedDate)
                        {
                            lblExpirationDateReq.Visible = true;
                        }

                        if (lblExpirationDateReq.Visible)
                            return;
                        else
                        {
                            rptExpirationDate = rdpExpirationDate.SelectedDate.Value;
                            rptRunBy = "1";
                            programId = "";
                            ReportParameter[] LabelsParm = new ReportParameter[3];
                            LabelsParm[0] = new ReportParameter("LicenseExpirationDate", rptExpirationDate.ToShortDateString());
                            LabelsParm[1] = new ReportParameter("ProgramId", programId);
                            LabelsParm[2] = new ReportParameter("RunBy", rptRunBy);
                            // set Session Variables
                            Session["ReportParams"] = LabelsParm;
                        }
                    }
                    else if (optProviderType.Checked)
                    {
                        programId = listProviderType.SelectedValue;
                        rptRunBy = "2";
                        ReportParameter[] LabelsParm = new ReportParameter[3];
                        LabelsParm[0] = new ReportParameter("LicenseExpirationDate", rptExpirationDate.ToShortDateString());
                        LabelsParm[1] = new ReportParameter("ProgramId", programId);
                        LabelsParm[2] = new ReportParameter("RunBy", rptRunBy);
                        Session["ReportParams"] = LabelsParm;
                            
                    }
                    else if (optExpirationDateProviderType.Checked)
                    {
                        lblExpirationDateProviderTypeReq.Visible = false;
                        rptExpirationDateProviderType = new DateTime();

                        if (null == rdpExpirationDateProviderType.SelectedDate)
                        {
                            lblExpirationDateProviderTypeReq.Visible = true;
                        }

                        if (lblExpirationDateProviderTypeReq.Visible)
                            return;
                        else
                        {
                            rptExpirationDateProviderType = rdpExpirationDateProviderType.SelectedDate.Value;
                            rptRunBy = "3";
                            programId = listExpirationDateProviderType.SelectedValue;
                            ReportParameter[] LabelsParm = new ReportParameter[3];
                            LabelsParm[0] = new ReportParameter("LicenseExpirationDate", rptExpirationDateProviderType.ToShortDateString());
                            LabelsParm[1] = new ReportParameter("ProgramId", programId);
                            LabelsParm[2] = new ReportParameter("RunBy", rptRunBy);
                            Session["ReportParams"] = LabelsParm;
                        }
                    }
                    break; ;
                #endregion

                #region CASE: EMS_NEMT_VEHICLE_REPORT
                case "EMSNEMTVEHICLEREPORT":

                    rptRunBy = "";
                    winTitle = "EMS NEMT VEHICLE";

                    if (optVehicleStateId.Checked)
                    {
                        stateID = VehicleStateIDTxt.Text;
                        programId = null;

                        if (optVehicleFacilitName.Checked)
                        {
                            rptRunBy = "1";
                        }
                        else if (optVehicleDecal.Checked)
                        {
                            rptRunBy = "2";
                        }
                        //programId = "";
                        ReportParameter[] LabelsParm = new ReportParameter[3];
                        LabelsParm[0] = new ReportParameter("ProgramID", programId);
                        LabelsParm[1] = new ReportParameter("StateID", stateID);
                        LabelsParm[2] = new ReportParameter("SortBy", rptRunBy);
                        // set Session Variables
                        Session["ReportParams"] = LabelsParm;
                    }
                    else if (optVehicleProviderType.Checked)
                    {
                        programId = listVehicleProviderType.SelectedValue;
                        if (optVehicleFacilitName.Checked)
                        {
                            rptRunBy = "1";
                        }
                        else if (optVehicleDecal.Checked)
                        {
                            rptRunBy = "2";
                        }
                        ReportParameter[] LabelsParm = new ReportParameter[3];
                        LabelsParm[0] = new ReportParameter("ProgramID", programId);
                        LabelsParm[1] = new ReportParameter("StateID", stateID);
                        LabelsParm[2] = new ReportParameter("SortBy", rptRunBy);
                        // set Session Variables
                        Session["ReportParams"] = LabelsParm;
                    
                    }
                    break;
                #endregion

                #region CASE: CHARGES_REPORT
                case "CHARGESREPORT":
                    optProvTypeAll.Checked = true;
                    lblStartDtReq.Visible = false;
                    lblEndDtReq.Visible = false;

                    rptStartDt = new DateTime();
                    rptEndDt = new DateTime();
                    rptSortBy = null;
                    programId = null;

                    if ( null == rdpStartDt.SelectedDate )
                    {
                        lblStartDtReq.Visible = true;
                    }

                    if ( null == rdpEndDt.SelectedDate )
                    {
                        lblEndDtReq.Visible = true;
                    }

                    if (lblStartDtReq.Visible || lblEndDtReq.Visible)
                        return;
                    else
                    {
                        winTitle = "Charges Report";

                        rptStartDt = rdpStartDt.SelectedDate.Value;
                        rptEndDt = rdpEndDt.SelectedDate.Value;

                        if (optStateId.Checked)
                            rptSortBy = "1";
                        else if (optFacilityName.Checked)
                            rptSortBy = "2";
                        else if (optFieldOffice.Checked)
                            rptSortBy = "3";

                        /*** IF ALL IS NOT SELECTED ... Load ProgramID value ***/
                        if (optProvTypeChoice.Checked)
                            programId = lstCheckLogParamsProvType.SelectedValue;

                        // set the parameters
                        ReportParameter[] CheckLogParm = new ReportParameter[4];
                        CheckLogParm[0] = new ReportParameter("ProcessedDateFrom", rptStartDt.ToShortDateString() );
                        CheckLogParm[1] = new ReportParameter("ProcessedDateTo", rptEndDt.ToShortDateString() );
                        CheckLogParm[2] = new ReportParameter("SortBy", rptSortBy);
                        CheckLogParm[3] = new ReportParameter("ProgramID", programId);

                        // set Session Variables
                        Session["ReportParams"] = CheckLogParm;
                    }
                    break; ;
                #endregion

                #region CASE: PAYMENTS_REPORT
                case "PAYMENTSREPORT":
                    optProvTypeAll.Checked = true;
                    lblStartDtReq.Visible = false;
                    lblEndDtReq.Visible = false;

                    rptStartDt = new DateTime();
                    rptEndDt = new DateTime();
                    rptSortBy = null;
                    programId = null;

                    if (null == rdpStartDt.SelectedDate)
                    {
                        lblStartDtReq.Visible = true;
                    }

                    if (null == rdpEndDt.SelectedDate)
                    {
                        lblEndDtReq.Visible = true;
                    }

                    if (lblStartDtReq.Visible || lblEndDtReq.Visible)
                        return;
                    else
                    {
                        winTitle = "Payments Report";

                        rptStartDt = rdpStartDt.SelectedDate.Value;
                        rptEndDt = rdpEndDt.SelectedDate.Value;

                        if (optStateId.Checked)
                            rptSortBy = "1";
                        else if (optFacilityName.Checked)
                            rptSortBy = "2";
                        else if (optFieldOffice.Checked)
                            rptSortBy = "3";

                        /*** IF ALL IS NOT SELECTED ... Load ProgramID value ***/
                        if (optProvTypeChoice.Checked)
                            programId = lstCheckLogParamsProvType.SelectedValue;

                        // set the parameters
                        ReportParameter[] CheckLogParm = new ReportParameter[4];
                        CheckLogParm[0] = new ReportParameter("ProcessedDateFrom", rptStartDt.ToShortDateString());
                        CheckLogParm[1] = new ReportParameter("ProcessedDateTo", rptEndDt.ToShortDateString());
                        CheckLogParm[2] = new ReportParameter("SortBy", rptSortBy);
                        CheckLogParm[3] = new ReportParameter("ProgramID", programId);

                        // set Session Variables
                        Session["ReportParams"] = CheckLogParm;
                    }
                    break; ;
                #endregion

                #region CASE: TRANSACTION_REPORT
                case "TransactionReport":
                    optProvTypeAll.Checked = true;
                    lblStartDtReq.Visible = false;
                    lblEndDtReq.Visible = false;

                    rptStartDt = new DateTime();
                    rptEndDt = new DateTime();
                    rptSortBy = null;
                    programId = null;

                    string stateId = null;

                    if (null == rdpStartDt.SelectedDate)
                    {
                        lblStartDtReq.Visible = true;
                    }

                    if (null == rdpEndDt.SelectedDate)
                    {
                        lblEndDtReq.Visible = true;
                    }

                    if (lblStartDtReq.Visible || lblEndDtReq.Visible)
                        return;
                    else
                    {
                        winTitle = "Transaction Report";

                        rptStartDt = rdpStartDt.SelectedDate.Value;
                        rptEndDt = rdpEndDt.SelectedDate.Value;

                        if (optStateId.Checked)
                            rptSortBy = "1";
                        else if (optFacilityName.Checked)
                            rptSortBy = "2";
                        else if (optFieldOffice.Checked)
                            rptSortBy = "3";

                        /*** IF ALL IS NOT SELECTED ... Load ProgramID value ***/
                        if (optProvTypeChoice.Checked)
                        {
                            programId = lstCheckLogParamsProvType.SelectedValue;
                            if (StateIDTxt.Text.Length > 0)
                                stateId = StateIDTxt.Text;
                        }

                        // set the parameters
                        ReportParameter[] CheckLogParm = new ReportParameter[5];
                        CheckLogParm[0] = new ReportParameter("ProcessedDateFrom", rptStartDt.ToShortDateString());
                        CheckLogParm[1] = new ReportParameter("ProcessedDateTo", rptEndDt.ToShortDateString());
                        CheckLogParm[2] = new ReportParameter("SortBy", rptSortBy);
                        CheckLogParm[3] = new ReportParameter("ProgramID", programId);
                        CheckLogParm[4] = new ReportParameter("StateID", stateId);
                        // set Session Variables
                        Session["ReportParams"] = CheckLogParm;
                    }
                    break; ;
                #endregion

                #region CASE: Default
                default:
                    // by default, the Directories list will be displayed
                    programId = listDirectories.SelectedValue;
                    winTitle = "Directories Report";

                    // set the parameters
                    ReportParameter[] parm3 = new ReportParameter[1];
                    parm3[0] = new ReportParameter("Program_Id", programId);

                    // set Session Variables
                    Session["ReportParams"] = parm3;

                    break;
                #endregion
            }

            #region --> Set Session Variables
            Session["ReportName"] = NameOfReport;
            //special case for Search Criteria Report, 7 reports in one search page.
            if (NameOfReport == "SEARCHCRITERIAREPORT")
                SetReportNameForSCR();

            // Display the report in a new window
            RadWindow newwindow = new RadWindow();
            newwindow.ID = "RadWindow2";
            newwindow.NavigateUrl = "~/Common/report.aspx";
            newwindow.Modal = true;
            newwindow.VisibleOnPageLoad = true;
            newwindow.Height = Unit.Pixel(525);
            newwindow.Width = Unit.Pixel(730);
            newwindow.Title = winTitle;
            newwindow.InitialBehaviors = WindowBehaviors.Maximize;
            rwm1.Windows.Add(newwindow);
            rwm1.Style.Add("z-index", "9999");
            rwm1.Behaviors = WindowBehaviors.Close;
            #endregion
        }

        /// <summary>
        /// Store / Return the Name of the Report
        /// </summary>
        public string NameOfReport
        {
            get 
            {
                return (string)Session["NameOfReport"]; 
            }
            set 
            {
                Session["NameOfReport"] = value;
                lblStateID.Visible = false;
                StateIDTxt.Visible = false;
                switch (value)
                {

                    #region CASE: ACO_POPS_DISCREPANCY_REPORT
                    case "ACOPOPSDISCREPANCYREPORT":
                        labelProvType.Visible = false;
                        listDirectories.Visible = false;
                        listFacilities.Visible = false;
                        DivCheckLogParams.Visible = false;
                        DivLabelReportParams.Visible = false;
                        tblReportSortByOpts.Visible = false;
                        tblDateParameters.Visible = false;
                        
                        DirectoryParams.Visible = true;

                        dtTimeLineDateFrom.Visible = false;
                        dtTimeLineDateTo.Visible = false;
                        listTimeLineMet.Visible = false;
                        listAspenIDRType.Visible = false;
                        listProviderType.Visible = false;
                        listExpirationDateProviderType.Visible = false;
                        listTypeOfDate.Visible = false;
                        labelTimeLineDateFrom.Visible = false;
                        labelTimeLineDateTo.Visible = false;
                        labelTimeLineMet.Visible = false;
                        labelTypeOfDate.Visible = false;
                        labelAspenIDRType.Visible = false;
                        lblDecal.Visible = false;
                        tblDecalLabel.Visible = false;
                        DivDecalLabelReport.Visible = false;

                        DivVehicleReportParams.Visible = false;
                        tblVehicleReport.Visible = false;
                        tblVehicleReportOpts.Visible = false;
                        optVehicleStateId.Visible = false;
                        optVehicleProviderType.Visible = false;
                        listVehicleProviderType.Visible = false;
                        optVehicleFacilitName.Visible = false;
                        optVehicleDecal.Visible = false;
                        VehicleStateIDTxt.Visible = false;
                        DecalTxtFrom.Visible = false;
                        DecalTxtTo.Visible = false;
                        lblDecalFrom.Visible = false;
                        lblDecalTo.Visible = false;
                        DivAdHocReportParameters.Visible = false;
                        DivOwershipReport.Visible = false;
                        DivSearchCriteriaReport.Visible = false;

                        buttonReport.Text = "Generate POPS-ACO Discrepancy Report";

                        break;
                    #endregion

                    #region CASE: DIRECTORIES_REPORT
                    case "DIRECTORIESREPORT":
                        labelProvType.Visible = false;
                        listDirectories.Visible = false;
                        listFacilities.Visible = false;
                        DivCheckLogParams.Visible = false;
                        DivLabelReportParams.Visible = false;
                        tblReportSortByOpts.Visible = false;
                        tblDateParameters.Visible = false;

                        DirectoryParams.Visible = false;
                        
                        dtTimeLineDateFrom.Visible = false;
                        dtTimeLineDateTo.Visible = false;
                        listTimeLineMet.Visible = false;
                        listAspenIDRType.Visible = false;
                        listProviderType.Visible = false;
                        listExpirationDateProviderType.Visible = false;
                        listTypeOfDate.Visible = false;
                        labelTimeLineDateFrom.Visible = false;
                        labelTimeLineDateTo.Visible = false;
                        labelTimeLineMet.Visible = false;
                        labelTypeOfDate.Visible = false;
                        labelAspenIDRType.Visible = false;

                        DivCheckLogParams.Visible = true;
                        tblCheckLogParams.Visible = false;
                        tblCheckLogOpts.Visible = false;
                        tblReportSortByOpts.Visible = false;
                        tblProviderType.Visible = true;
                        lblDecal.Visible = false;
                        tblDecalLabel.Visible = false;
                        DivDecalLabelReport.Visible = false;

                        DivVehicleReportParams.Visible = false;
                        tblVehicleReport.Visible = false;
                        tblVehicleReportOpts.Visible = false;
                        optVehicleStateId.Visible = false;
                        optVehicleProviderType.Visible = false;
                        listVehicleProviderType.Visible = false;
                        optVehicleFacilitName.Visible = false;
                        optVehicleDecal.Visible = false;
                        VehicleStateIDTxt.Visible = false;

                        DecalTxtFrom.Visible = false;
                        DecalTxtTo.Visible = false;
                        lblDecalFrom.Visible = false;
                        lblDecalTo.Visible = false;
                        DivAdHocReportParameters.Visible = false;
                        DivOwershipReport.Visible = false;
                        DivSearchCriteriaReport.Visible = false;

                        buttonReport.Text = "Generate Directory Report";

                        break;
                    #endregion

                    #region CASE: FACILITIES_REPORT
                    case "FACILITIESREPORT":
                        labelProvType.Visible = true;
                        listFacilities.Visible = true;
                        listDirectories.Visible = false;
                        listProviderType.Visible = false;
                        listExpirationDateProviderType.Visible = false;
                        DivCheckLogParams.Visible = false;
                        DivLabelReportParams.Visible = false;
                        tblReportSortByOpts.Visible = false;
                        tblDateParameters.Visible = false;

                        DirectoryParams.Visible = true;
                        
                        dtTimeLineDateFrom.Visible = false;
                        dtTimeLineDateTo.Visible = false;
                        listTimeLineMet.Visible = false;
                        listAspenIDRType.Visible = false;
                        listTypeOfDate.Visible = false;
                        labelTimeLineDateFrom.Visible = false;
                        labelTimeLineDateTo.Visible = false;
                        labelTimeLineMet.Visible = false;
                        labelTypeOfDate.Visible = false;
                        labelAspenIDRType.Visible = false;
                        lblDecal.Visible = false;
                        tblDecalLabel.Visible = false;
                        DivDecalLabelReport.Visible = false;

                        DivVehicleReportParams.Visible = false;
                        tblVehicleReport.Visible = false;
                        tblVehicleReportOpts.Visible = false;
                        optVehicleStateId.Visible = false;
                        optVehicleProviderType.Visible = false;
                        listVehicleProviderType.Visible = false;
                        optVehicleFacilitName.Visible = false;
                        optVehicleDecal.Visible = false;
                        VehicleStateIDTxt.Visible = false;
                        DecalTxtFrom.Visible = false;
                        DecalTxtTo.Visible = false;
                        lblDecalFrom.Visible = false;
                        lblDecalTo.Visible = false;
                        DivAdHocReportParameters.Visible = false;
                        DivOwershipReport.Visible = false;
                        DivSearchCriteriaReport.Visible = false;

                        buttonReport.Text = "Generate Facility Report";

                        break;
                    #endregion

                    #region CASE: EMS_INSURANCE_REPORT
                    case "EMSINSURANCEREPORT":
                        labelProvType.Visible = false;
                        listFacilities.Visible = false;
                        listDirectories.Visible = false;
                        listProviderType.Visible = false;
                        listExpirationDateProviderType.Visible = false;
                        DivCheckLogParams.Visible = false;
                        DivLabelReportParams.Visible = false;
                        tblReportSortByOpts.Visible = false;
                        tblDateParameters.Visible = false;
                        DivOwershipReport.Visible = false;

                        DirectoryParams.Visible = false;

                        dtTimeLineDateFrom.Visible = false;
                        dtTimeLineDateTo.Visible = false;
                        listTimeLineMet.Visible = false;
                        listAspenIDRType.Visible = false;
                        listTypeOfDate.Visible = false;
                        labelTimeLineDateFrom.Visible = false;
                        labelTimeLineDateTo.Visible = false;
                        labelTimeLineMet.Visible = false;
                        labelTypeOfDate.Visible = false;
                        labelAspenIDRType.Visible = false;
                        lblDecal.Visible = false;
                        tblDecalLabel.Visible = false;
                        DivDecalLabelReport.Visible = false;

                        DivVehicleReportParams.Visible = false;
                        tblVehicleReport.Visible = false;
                        tblVehicleReportOpts.Visible = false;
                        optVehicleStateId.Visible = false;
                        optVehicleProviderType.Visible = false;
                        listVehicleProviderType.Visible = false;
                        optVehicleFacilitName.Visible = false;
                        optVehicleDecal.Visible = false;
                        VehicleStateIDTxt.Visible = false;
                        DecalTxtFrom.Visible = false;
                        DecalTxtTo.Visible = false;
                        lblDecalFrom.Visible = false;
                        lblDecalTo.Visible = false;
                        DivAdHocReportParameters.Visible = false;
                        DivSearchCriteriaReport.Visible = false;

                        buttonReport.Text = "Generate EMS Insurance Report";

                        break;
                    #endregion

                    #region CASE: NEMT_INSURANCE_REPORT
                    case "NEMTINSURANCEREPORT":
                        labelProvType.Visible = false;
                        listFacilities.Visible = false;
                        listDirectories.Visible = false;
                        listProviderType.Visible = false;
                        listExpirationDateProviderType.Visible = false;
                        DivCheckLogParams.Visible = false;
                        DivLabelReportParams.Visible = false;
                        tblReportSortByOpts.Visible = false;
                        tblDateParameters.Visible = false;

                        DirectoryParams.Visible = false;

                        dtTimeLineDateFrom.Visible = false;
                        dtTimeLineDateTo.Visible = false;
                        listTimeLineMet.Visible = false;
                        listAspenIDRType.Visible = false;
                        listTypeOfDate.Visible = false;
                        labelTimeLineDateFrom.Visible = false;
                        labelTimeLineDateTo.Visible = false;
                        labelTimeLineMet.Visible = false;
                        labelTypeOfDate.Visible = false;
                        labelAspenIDRType.Visible = false;
                        lblDecal.Visible = false;
                        tblDecalLabel.Visible = false;
                        DivDecalLabelReport.Visible = false;

                        DivVehicleReportParams.Visible = false;
                        tblVehicleReport.Visible = false;
                        tblVehicleReportOpts.Visible = false;
                        optVehicleStateId.Visible = false;
                        optVehicleProviderType.Visible = false;
                        listVehicleProviderType.Visible = false;
                        optVehicleFacilitName.Visible = false;
                        optVehicleDecal.Visible = false;
                        VehicleStateIDTxt.Visible = false;
                        DecalTxtFrom.Visible = false;
                        DecalTxtTo.Visible = false;
                        lblDecalFrom.Visible = false;
                        lblDecalTo.Visible = false;
                        DivAdHocReportParameters.Visible = false;
                        DivOwershipReport.Visible = false;
                        DivSearchCriteriaReport.Visible = false;

                        buttonReport.Text = "Generate NEMT Insurance Report";

                        break;
                    #endregion

                    #region CASE: DECAL_LABELS_REPORT
                    case "DECALLABELSREPORT5262":
                        labelProvType.Visible = false;
                        listFacilities.Visible = false;
                        listDirectories.Visible = false;
                        listProviderType.Visible = false;
                        listExpirationDateProviderType.Visible = false;
                        DivCheckLogParams.Visible = false;
                        DivLabelReportParams.Visible = false;
                        DivDecalLabelReport.Visible = true;
                        tblReportSortByOpts.Visible = false;
                        tblDateParameters.Visible = false;
                        tblDecalLabel.Visible = true;

                        DirectoryParams.Visible = false;

                        dtTimeLineDateFrom.Visible = false;
                        dtTimeLineDateTo.Visible = false;
                        listTimeLineMet.Visible = false;
                        listAspenIDRType.Visible = false;
                        listTypeOfDate.Visible = false;
                        labelTimeLineDateFrom.Visible = false;
                        labelTimeLineDateTo.Visible = false;
                        labelTimeLineMet.Visible = false;
                        labelTypeOfDate.Visible = false;
                        labelAspenIDRType.Visible = false;
                        lblDecal.Visible = true;

                        DivVehicleReportParams.Visible = false;
                        tblVehicleReport.Visible = false;
                        tblVehicleReportOpts.Visible = false;
                        optVehicleStateId.Visible = false;
                        optVehicleProviderType.Visible = false;
                        listVehicleProviderType.Visible = false;
                        optVehicleFacilitName.Visible = false;
                        optVehicleDecal.Visible = false;
                        VehicleStateIDTxt.Visible = false;

                        DecalTxtFrom.Visible = true;
                        DecalTxtTo.Visible = true;
                        DecalTxtFrom.Text = "";
                        DecalTxtTo.Text = "";
                        lblDecalFrom.Visible = true;
                        lblDecalTo.Visible = true;
                        DivAdHocReportParameters.Visible = false;
                        DivOwershipReport.Visible = false;
                        DivSearchCriteriaReport.Visible = false;

                        buttonReport.Text = "Generate Decal Label Report";

                        break;
                    #endregion

                    #region CASE: AD_HOC_DATA_REPORT
                    case "ADHOCDATAREPORT":
                        labelProvType.Visible = false;
                        listFacilities.Visible = false;
                        listDirectories.Visible = false;
                        listProviderType.Visible = false;
                        listExpirationDateProviderType.Visible = false;
                        DivCheckLogParams.Visible = false;
                        DivLabelReportParams.Visible = false;
                        DivDecalLabelReport.Visible = false;
                        tblReportSortByOpts.Visible = false;
                        tblDateParameters.Visible = false;
                        tblDecalLabel.Visible = false;

                        DirectoryParams.Visible = false;

                        dtTimeLineDateFrom.Visible = false;
                        dtTimeLineDateTo.Visible = false;
                        listTimeLineMet.Visible = false;
                        listAspenIDRType.Visible = false;
                        listTypeOfDate.Visible = false;
                        labelTimeLineDateFrom.Visible = false;
                        labelTimeLineDateTo.Visible = false;
                        labelTimeLineMet.Visible = false;
                        labelTypeOfDate.Visible = false;
                        labelAspenIDRType.Visible = false;
                        lblDecal.Visible = false;

                        DivVehicleReportParams.Visible = false;
                        tblVehicleReport.Visible = false;
                        tblVehicleReportOpts.Visible = false;
                        optVehicleStateId.Visible = false;
                        optVehicleProviderType.Visible = false;
                        listVehicleProviderType.Visible = false;
                        optVehicleFacilitName.Visible = false;
                        optVehicleDecal.Visible = false;
                        VehicleStateIDTxt.Visible = false;

                        DecalTxtFrom.Visible = false;
                        DecalTxtTo.Visible = false;
                        DecalTxtFrom.Text = "";
                        DecalTxtTo.Text = "";
                        lblDecalFrom.Visible = false;
                        lblDecalTo.Visible = false;

                        DivAdHocReportParameters.Visible = true;
                        tblAdHocReport.Visible = true;
                        tblAdHocReportOpts.Visible = true;
                        chkTypeFacility.Visible = true;
                        DivOwershipReport.Visible = false;
                        DivSearchCriteriaReport.Visible = false;

                        buttonReport.Text = "Generate Ad Hoc Data Report";

                        break;
                    #endregion

                    #region CASE: ONLINE_PAYMENTS_REPORT
                    case "ONLINEPAYMENTSREPORT":
                        DirectoryParams.Visible = false;
                        DivCheckLogParams.Visible = true;
                        tblProviderType.Visible = false;
                        DivLabelReportParams.Visible = false;
                        tblCheckLogOpts.Visible = false;
                        tblReportSortByOpts.Visible = true;
                        rdpStartDt.Clear();
                        rdpEndDt.Clear();
                        tblCheckLogParams.Visible = true;
                        tblDateParameters.Visible = true;
                        lblDecal.Visible = false;
                        tblDecalLabel.Visible = false;
                        DivDecalLabelReport.Visible = false;
                        //lblStartDt.Text = "Accounts Receivable Due " + lblStartDt.Text;
                        //lblEndDt.Text = "Accounts Receivable Due " + lblEndDt.Text;
                        lblStartDt.Text = "From Date ";
                        lblEndDt.Text = "Through Date ";

                        DivVehicleReportParams.Visible = false;
                        tblVehicleReport.Visible = false;
                        tblVehicleReportOpts.Visible = false;
                        optVehicleStateId.Visible = false;
                        optVehicleProviderType.Visible = false;
                        listVehicleProviderType.Visible = false;
                        optVehicleFacilitName.Visible = false;
                        optVehicleDecal.Visible = false;
                        VehicleStateIDTxt.Visible = false;
                        DecalTxtFrom.Visible = false;
                        DecalTxtTo.Visible = false;
                        lblDecalFrom.Visible = false;
                        lblDecalTo.Visible = false;
                        DivAdHocReportParameters.Visible = false;
                        DivOwershipReport.Visible = false;
                        DivSearchCriteriaReport.Visible = false;

                        lblCheckLogParam.Text = "Select Report Criteria";
                        buttonReport.Text = "Generate Online Payments Report";

                        break;
                    #endregion

                    #region CASE: IDR_SUMMARY_REPORT
                    case "IDRSUMMARYREPORT":
                        labelProvType.Visible = false;
                        listFacilities.Visible = false;
                        listDirectories.Visible = false;
                        listProviderType.Visible = false;
                        listExpirationDateProviderType.Visible = false;
                        tblCheckLogOpts.Visible = false;
                        tblReportSortByOpts.Visible = false;
                        tblDateParameters.Visible = false;
                        DivCheckLogParams.Visible = false;
                        tblDateParameters.Visible = false;
                        DivLabelReportParams.Visible = false;
                        DirectoryParams.Visible = true;
                        dtTimeLineDateFrom.Visible = true;
                        dtTimeLineDateTo.Visible = true;
                        listTimeLineMet.Visible = true;
                        listAspenIDRType.Visible = true;
                        listTypeOfDate.Visible = true;
                        labelTimeLineDateFrom.Visible = true;
                        labelTimeLineDateTo.Visible = true;
                        labelTimeLineMet.Visible = true;
                        labelTypeOfDate.Visible = true;
                        labelAspenIDRType.Visible = true;
                        lblDecal.Visible = false;
                        tblDecalLabel.Visible = false;
                        DivDecalLabelReport.Visible = false;

                        DivVehicleReportParams.Visible = false;
                        tblVehicleReport.Visible = false;
                        tblVehicleReportOpts.Visible = false;
                        optVehicleStateId.Visible = false;
                        optVehicleProviderType.Visible = false;
                        listVehicleProviderType.Visible = false;
                        optVehicleFacilitName.Visible = false;
                        optVehicleDecal.Visible = false;
                        VehicleStateIDTxt.Visible = false;
                        DecalTxtFrom.Visible = false;
                        DecalTxtTo.Visible = false;
                        lblDecalFrom.Visible = false;
                        lblDecalTo.Visible = false;
                        DivAdHocReportParameters.Visible = false;
                        DivOwershipReport.Visible = false;
                        DivSearchCriteriaReport.Visible = false;
 
                        buttonReport.Text = "Generate IDR Summary Report";
                        break;
                    #endregion

                    #region CASE: POPS_LABEL_REPORT_5262
                    case "POPSLABELREPORT5262":
                        DirectoryParams.Visible = false;
                        DivCheckLogParams.Visible = false;
                        DivLabelReportParams.Visible = true;
                        listProviderType.Visible = true;
                        listExpirationDateProviderType.Visible = true;
                        tblLabelReportParameters.Visible = true;
                        tblLabelReportOpts.Visible = true;
                        lblDecal.Visible = false;
                        tblDecalLabel.Visible = false;
                        DivDecalLabelReport.Visible = false;

                        DivVehicleReportParams.Visible = false;
                        tblVehicleReport.Visible = false;
                        tblVehicleReportOpts.Visible = false;
                        optVehicleStateId.Visible = false;
                        optVehicleProviderType.Visible = false;
                        listVehicleProviderType.Visible = false;
                        optVehicleFacilitName.Visible = false;
                        optVehicleDecal.Visible = false;
                        VehicleStateIDTxt.Visible = false;
                        DecalTxtFrom.Visible = false;
                        DecalTxtTo.Visible = false;
                        lblDecalFrom.Visible = false;
                        lblDecalTo.Visible = false;
                        DivAdHocReportParameters.Visible = false;
                        DivOwershipReport.Visible = false;
                        DivSearchCriteriaReport.Visible = false;

                        buttonReport.Text = "Generate POPS Label Report";

                        break;
                    #endregion

                    #region CASE: EMS_NEMT_VEHICLE_REPORT
                    case "EMSNEMTVEHICLEREPORT":
                        DirectoryParams.Visible = false;
                        DivCheckLogParams.Visible = false;
                        DivLabelReportParams.Visible = true;
                        listProviderType.Visible = false;
                        listExpirationDateProviderType.Visible = false;
                        tblLabelReportParameters.Visible = false;
                        tblLabelReportOpts.Visible = false;
                        lblDecal.Visible = false;
                        tblDecalLabel.Visible = false;
                        DivDecalLabelReport.Visible = false;

                        DivVehicleReportParams.Visible = true;
                        tblVehicleReport.Visible = true;
                        tblVehicleReportOpts.Visible = true;
                        optVehicleStateId.Visible = true;
                        optVehicleProviderType.Visible = true;
                        listVehicleProviderType.Visible = true;
                        optVehicleFacilitName.Visible = true;
                        optVehicleDecal.Visible = true;
                        VehicleStateIDTxt.Visible = true;
                        DecalTxtFrom.Visible = false;
                        DecalTxtTo.Visible = false;
                        lblDecalFrom.Visible = false;
                        lblDecalTo.Visible = false;
                        DivAdHocReportParameters.Visible = false;
                        DivOwershipReport.Visible = false;
                        DivSearchCriteriaReport.Visible = false;

                        buttonReport.Text = "Generate Vehicle Report";

                        break;
                    #endregion
                        
                    #region CASE: Check_Log_Report
                    case "CheckLogReport":
                        DirectoryParams.Visible = false;
                        DivLabelReportParams.Visible = false;
                        DivCheckLogParams.Visible = true;
                        tblProviderType.Visible = false;
                        tblCheckLogOpts.Visible = true;
                        tblCheckLogParams.Visible = true;
                        tblDateParameters.Visible = true;
                        lblDecal.Visible = false;
                        tblDecalLabel.Visible = false;
                        DivDecalLabelReport.Visible = false;

                        DivVehicleReportParams.Visible = false;
                        tblVehicleReport.Visible = false;
                        tblVehicleReportOpts.Visible = false;
                        optVehicleStateId.Visible = false;
                        optVehicleProviderType.Visible = false;
                        listVehicleProviderType.Visible = false;
                        optVehicleFacilitName.Visible = false;
                        optVehicleDecal.Visible = false;
                        VehicleStateIDTxt.Visible = false;
                        DecalTxtFrom.Visible = false;
                        DecalTxtTo.Visible = false;
                        lblDecalFrom.Visible = false;
                        lblDecalTo.Visible = false;
                        DivAdHocReportParameters.Visible = false;
                        DivOwershipReport.Visible = false;
                        DivSearchCriteriaReport.Visible = false;

                        lblCheckLogParam.Text = "Select Report Criteria";
                        buttonReport.Text = "Generate Check Log Report";

                        break;
                    #endregion

                    #region CASE: Check_Log_Unlinked Payments Report
                    case "CheckLogUnlinkedPayments":
                        DirectoryParams.Visible = false;
                        DivLabelReportParams.Visible = false;
                        DivCheckLogParams.Visible = true;
                        tblProviderType.Visible = true;
                        tblCheckLogOpts.Visible = false;
                        tblCheckLogParams.Visible = false;
                        tblDateParameters.Visible = true;
                        lblDecal.Visible = false;
                        tblDecalLabel.Visible = false;
                        DivDecalLabelReport.Visible = false;
                        tblReportSortByOpts.Visible = false;

                        DivVehicleReportParams.Visible = false;
                        tblVehicleReport.Visible = false;
                        tblVehicleReportOpts.Visible = false;
                        optVehicleStateId.Visible = false;
                        optVehicleProviderType.Visible = false;
                        listVehicleProviderType.Visible = false;
                        optVehicleFacilitName.Visible = false;
                        optVehicleDecal.Visible = false;
                        VehicleStateIDTxt.Visible = false;
                        DecalTxtFrom.Visible = false;
                        DecalTxtTo.Visible = false;
                        lblDecalFrom.Visible = false;
                        lblDecalTo.Visible = false;
                        DivAdHocReportParameters.Visible = false;
                        DivOwershipReport.Visible = false;
                        DivSearchCriteriaReport.Visible = false;

                        lblCheckLogParam.Text = "Select Report Criteria";
                        buttonReport.Text = "Generate Unlinked Payments Report";

                        break;
                    #endregion

                    #region CASE: Ownership Report
                    case "OWNERSHIPREPORT":
                        DirectoryParams.Visible = false;
                        DivLabelReportParams.Visible = false;
                        DivCheckLogParams.Visible = false;
                        tblProviderType.Visible = false;
                        tblCheckLogOpts.Visible = false;
                        tblCheckLogParams.Visible = false;
                        tblDateParameters.Visible = false;
                        lblDecal.Visible = false;
                        tblDecalLabel.Visible = false;
                        DivDecalLabelReport.Visible = false;
                        tblReportSortByOpts.Visible = false;

                        DivVehicleReportParams.Visible = false;
                        tblVehicleReport.Visible = false;
                        tblVehicleReportOpts.Visible = false;
                        optVehicleStateId.Visible = false;
                        optVehicleProviderType.Visible = false;
                        listVehicleProviderType.Visible = false;
                        optVehicleFacilitName.Visible = false;
                        optVehicleDecal.Visible = false;
                        VehicleStateIDTxt.Visible = false;
                        DecalTxtFrom.Visible = false;
                        DecalTxtTo.Visible = false;
                        lblDecalFrom.Visible = false;
                        lblDecalTo.Visible = false;
                        DivAdHocReportParameters.Visible = false;
                        DivSearchCriteriaReport.Visible = false;

                        DivOwershipReport.Visible = true;

                        buttonReport.Text = "Generate Ownership Report";

                        break;
                    #endregion

                    #region CASE: Search Criteria Report
                    case "SEARCHCRITERIAREPORT":
                        DirectoryParams.Visible = false;
                        DivLabelReportParams.Visible = false;
                        DivCheckLogParams.Visible = false;
                        tblProviderType.Visible = false;
                        tblCheckLogOpts.Visible = false;
                        tblCheckLogParams.Visible = false;
                        tblDateParameters.Visible = false;
                        lblDecal.Visible = false;
                        tblDecalLabel.Visible = false;
                        DivDecalLabelReport.Visible = false;
                        tblReportSortByOpts.Visible = false;

                        DivVehicleReportParams.Visible = false;
                        tblVehicleReport.Visible = false;
                        tblVehicleReportOpts.Visible = false;
                        optVehicleStateId.Visible = false;
                        optVehicleProviderType.Visible = false;
                        listVehicleProviderType.Visible = false;
                        optVehicleFacilitName.Visible = false;
                        optVehicleDecal.Visible = false;
                        VehicleStateIDTxt.Visible = false;
                        DecalTxtFrom.Visible = false;
                        DecalTxtTo.Visible = false;
                        lblDecalFrom.Visible = false;
                        lblDecalTo.Visible = false;
                        DivAdHocReportParameters.Visible = false;
                        DivOwershipReport.Visible = false;

                        DivSearchCriteriaReport.Visible = true;

                        buttonReport.Text = "Generate Search Criteria Report";

                        break;
                    #endregion

                    #region CASE: CHARGES_REPORT
                    case "CHARGESREPORT":
                        DivLabelReportParams.Visible = false;
                        rdpEndDt.Clear();
                        rdpStartDt.Clear();
                        DirectoryParams.Visible = false;
                        tblCheckLogOpts.Visible = false;

                        DivCheckLogParams.Visible = true;
                        tblProviderType.Visible = false;
                        tblReportSortByOpts.Visible = true;
                        tblCheckLogParams.Visible = true;
                        tblDateParameters.Visible = true;
                        tblProviderType.Visible = true;
                        lblDecal.Visible = false;
                        tblDecalLabel.Visible = false;
                        DivDecalLabelReport.Visible = false;

                        DivVehicleReportParams.Visible = false;
                        tblVehicleReport.Visible = false;
                        tblVehicleReportOpts.Visible = false;
                        optVehicleStateId.Visible = false;
                        optVehicleProviderType.Visible = false;
                        listVehicleProviderType.Visible = false;
                        optVehicleFacilitName.Visible = false;
                        optVehicleDecal.Visible = false;
                        VehicleStateIDTxt.Visible = false;
                        DecalTxtFrom.Visible = false;
                        DecalTxtTo.Visible = false;
                        lblDecalFrom.Visible = false;
                        lblDecalTo.Visible = false;
                        DivAdHocReportParameters.Visible = false;
                        DivOwershipReport.Visible = false;
                        DivSearchCriteriaReport.Visible = false;

                        lblStartDt.Text = "From Date ";
                        lblEndDt.Text = "Through Date ";
                        lblCheckLogParam.Text = "Charges Report Criteria";
                        buttonReport.Text = "Generate Charges Report";

                        break;
                    #endregion

                    #region CASE: PAYMENTS_REPORT
                    case "PAYMENTSREPORT":
                        DivLabelReportParams.Visible = false;
                        rdpEndDt.Clear();
                        rdpStartDt.Clear();
                        DirectoryParams.Visible = false;
                        tblCheckLogOpts.Visible = false;

                        DivCheckLogParams.Visible = true;
                        tblProviderType.Visible = false;
                        tblReportSortByOpts.Visible = true;
                        tblCheckLogParams.Visible = true;
                        tblDateParameters.Visible = true;
                        tblProviderType.Visible = true;
                        lblDecal.Visible = false;
                        tblDecalLabel.Visible = false;
                        DivDecalLabelReport.Visible = false;

                        DivVehicleReportParams.Visible = false;
                        tblVehicleReport.Visible = false;
                        tblVehicleReportOpts.Visible = false;
                        optVehicleStateId.Visible = false;
                        optVehicleProviderType.Visible = false;
                        listVehicleProviderType.Visible = false;
                        optVehicleFacilitName.Visible = false;
                        optVehicleDecal.Visible = false;
                        VehicleStateIDTxt.Visible = false;
                        DecalTxtFrom.Visible = false;
                        DecalTxtTo.Visible = false;
                        lblDecalFrom.Visible = false;
                        lblDecalTo.Visible = false;
                        DivAdHocReportParameters.Visible = false;
                        DivOwershipReport.Visible = false;
                        DivSearchCriteriaReport.Visible = false;

                        lblStartDt.Text = "From Date ";
                        lblEndDt.Text = "Through Date ";
                        lblCheckLogParam.Text = "Payments Report Criteria";
                        buttonReport.Text = "Generate Payments Report";

                        break;
                    #endregion

                    #region CASE: TRANSACTION_REPORT
                    case "TransactionReport":
                        DivLabelReportParams.Visible = false;
                        rdpEndDt.Clear();
                        rdpStartDt.Clear();
                        DirectoryParams.Visible = false;
                        tblCheckLogOpts.Visible = false;

                        DivCheckLogParams.Visible = true;
                        tblProviderType.Visible = false;
                        tblReportSortByOpts.Visible = true;
                        tblCheckLogParams.Visible = true;
                        tblDateParameters.Visible = true;
                        tblProviderType.Visible = true;

                        lblStateID.Visible = true;
                        StateIDTxt.Visible = true;
                        lblDecal.Visible = false;
                        tblDecalLabel.Visible = false;
                        DivDecalLabelReport.Visible = false;

                        DivVehicleReportParams.Visible = false;
                        tblVehicleReport.Visible = false;
                        tblVehicleReportOpts.Visible = false;
                        optVehicleStateId.Visible = false;
                        optVehicleProviderType.Visible = false;
                        listVehicleProviderType.Visible = false;
                        optVehicleFacilitName.Visible = false;
                        optVehicleDecal.Visible = false;
                        VehicleStateIDTxt.Visible = false;
                        DecalTxtFrom.Visible = false;
                        DecalTxtTo.Visible = false;
                        lblDecalFrom.Visible = false;
                        lblDecalTo.Visible = false;
                        DivAdHocReportParameters.Visible = false;
                        DivOwershipReport.Visible = false;
                        DivSearchCriteriaReport.Visible = false;

                        lblStartDt.Text = "From Date ";
                        lblEndDt.Text = "Through Date ";
                        lblCheckLogParam.Text = "Transaction Report Criteria";
                        buttonReport.Text = "Generate Transaction Report";

                        break;
                    #endregion

                    #region CASE: DEFAULT
                    default:
                        // By default: generate the Directory report
                        labelProvType.Visible = true;
                        listDirectories.Visible = true;
                        listFacilities.Visible = false;
                        listProviderType.Visible = false;
                        listExpirationDateProviderType.Visible = false;

                        DirectoryParams.Visible = true;
                        DivLabelReportParams.Visible = false;

                        dtTimeLineDateFrom.Visible = false;
                        dtTimeLineDateTo.Visible = false;
                        listTimeLineMet.Visible = false;
                        listAspenIDRType.Visible = false;
                        listTypeOfDate.Visible = false;
                        labelTimeLineDateFrom.Visible = false;
                        labelTimeLineDateTo.Visible = false;
                        labelTimeLineMet.Visible = false;
                        labelTypeOfDate.Visible = false;
                        labelAspenIDRType.Visible = false;
                        tblCheckLogOpts.Visible = false;
                        tblReportSortByOpts.Visible = false;
                        tblLabelReportParameters.Visible = false;
                        lblDecal.Visible = false;
                        tblDecalLabel.Visible = false;
                        DivDecalLabelReport.Visible = false;

                        DivVehicleReportParams.Visible = false;
                        tblVehicleReport.Visible = false;
                        tblVehicleReportOpts.Visible = false;
                        optVehicleStateId.Visible = false;
                        optVehicleProviderType.Visible = false;
                        listVehicleProviderType.Visible = false;
                        optVehicleFacilitName.Visible = false;
                        optVehicleDecal.Visible = false;
                        VehicleStateIDTxt.Visible = false;
                        DecalTxtFrom.Visible = false;
                        DecalTxtTo.Visible = false;
                        lblDecalFrom.Visible = false;
                        lblDecalTo.Visible = false;
                        DivAdHocReportParameters.Visible = false;
                        DivOwershipReport.Visible = false;
                        DivSearchCriteriaReport.Visible = false;


                        lblCheckLogParam.Text = "Select Report Criteria";
                        buttonReport.Text = "Generate Directory Report";
                        break;
                    #endregion
                }
            }
        }

        #region Private Functions
        //Search Criteria report functions
        private void SetReportNameForSCR()
        {
            switch (SCRrbReportSelection.SelectedValue)
            {
                case "SCR1":
                    Session["ReportName"] = "SearchCriteriaReport1";
                    break;
                case "SCR2":
                    Session["ReportName"] = "SearchCriteriaReport2";
                    break;
                case "SCR3":
                    Session["ReportName"] = "SearchCriteriaReport3";
                    break;
                case "SCR4":
                    Session["ReportName"] = "SearchCriteriaReport4";
                    break;
                case "SCR5":
                    Session["ReportName"] = "SearchCriteriaReport5";
                    break;
                case "SCR6":
                    Session["ReportName"] = "SearchCriteriaReport6";
                    break;
                case "SCR7":
                    Session["ReportName"] = "SearchCriteriaReport7";
                    break;
                default:
                    Session["ReportName"] = "SearchCriteriaReport1";
                    break;
            }
        }
        private void SetUpSCRProgramList()
        {
            listSCRProgram.Items.Clear();
            listSCRProgram.DataSource = FacilitiesLookups;
            listSCRProgram.DataTextField = "ProgramDescription";
            listSCRProgram.DataValueField = "ProgramID";
            listSCRProgram.DataBind();
        }

        //ownership report functions
        private void SetUpOwnershipProgramList()
        {
            listOwnershipProgram.Items.Clear();
            listOwnershipProgram.DataSource = FacilitiesLookups;
            listOwnershipProgram.DataTextField = "ProgramDescription";
            listOwnershipProgram.DataValueField = "ProgramID";
            listOwnershipProgram.DataBind();
        }

        private void SetUpOwnershipTypeList()
        {
            listOwnershipType.Items.Clear();
            listOwnershipType.DataSource = BO_LookupValue.SelectByField("LOOKUP_KEY", "TYPE_OWNERSHIP");
            listOwnershipType.DataTextField = "VALDESC";
            listOwnershipType.DataValueField = "LookupVal";
            listOwnershipType.DataBind();
        }

        //Search Criteria Report - Program Type List
        protected void grpSCRProgram_CheckedChanged(object sender, EventArgs e)
        {
            if (SCRProgramChoice.Checked.Equals(true))
            {
                listSCRProgram.Visible = true;
            }
            else
            {
                listSCRProgram.Visible = false;
            }

            if (SCRrbReportSelection.SelectedValue == "SCR5")
                SetUpSCRFacilityType();
        }

        protected void SetUpSCRFacilityType()
        {
            if (SCRProgramAll.Checked)
            {
                SCRTypeFacilityErrorMsg.Visible = true;
                SCRTypeFacilityModule.Enabled = false;
                buttonReport.Enabled = false;
            }
            else
            {
                SCRTypeFacilityModule.Items.Clear();
                SCRTypeFacilityModule.DataSource = BO_LookupValue.SelectByFieldByKeyAndProgram("TYPE_FACILITY", listSCRProgram.SelectedValue);
                SCRTypeFacilityModule.DataTextField = "VALDESC";
                SCRTypeFacilityModule.DataValueField = "LookupVal";
                SCRTypeFacilityModule.DataBind();
                SCRTypeFacilityErrorMsg.Visible = false;
                SCRTypeFacilityModule.Enabled = true;
                buttonReport.Enabled = true;
            }
        }

        protected void SCRrbReportSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (SCRrbReportSelection.SelectedValue)
            {
                case "SCR1":
                    SCRReportSelection1.Visible = true;
                    SCRReportSelection2.Visible = false;
                    SCRReportSelection3.Visible = false;
                    SCRReportSelection4.Visible = false;
                    SCRReportSelection5.Visible = false;
                    SCRReportSelection6.Visible = false;
                    SCRReportSelection7.Visible = false;
                    break;
                case "SCR2":
                    SCRReportSelection1.Visible = false;
                    SCRReportSelection2.Visible = true;
                    SCRReportSelection3.Visible = false;
                    SCRReportSelection4.Visible = false;
                    SCRReportSelection5.Visible = false;
                    SCRReportSelection6.Visible = false;
                    SCRReportSelection7.Visible = false;
                    break;
                case "SCR3":
                    SCRReportSelection1.Visible = false;
                    SCRReportSelection2.Visible = false;
                    SCRReportSelection3.Visible = true;
                    SCRReportSelection4.Visible = false;
                    SCRReportSelection5.Visible = false;
                    SCRReportSelection6.Visible = false;
                    SCRReportSelection7.Visible = false;
                    break;
                case "SCR4":
                    SCRReportSelection1.Visible = false;
                    SCRReportSelection2.Visible = false;
                    SCRReportSelection3.Visible = false;
                    SCRReportSelection4.Visible = true;
                    SCRReportSelection5.Visible = false;
                    SCRReportSelection6.Visible = false;
                    SCRReportSelection7.Visible = false;
                    break;
                case "SCR5":
                    SCRReportSelection1.Visible = false;
                    SCRReportSelection2.Visible = false;
                    SCRReportSelection3.Visible = false;
                    SCRReportSelection4.Visible = false;
                    SCRReportSelection5.Visible = true;
                    SCRReportSelection6.Visible = false;
                    SCRReportSelection7.Visible = false;
                    SetUpSCRFacilityType();
                    break;
                case "SCR6":
                    SCRReportSelection1.Visible = false;
                    SCRReportSelection2.Visible = false;
                    SCRReportSelection3.Visible = false;
                    SCRReportSelection4.Visible = false;
                    SCRReportSelection5.Visible = false;
                    SCRReportSelection6.Visible = true;
                    SCRReportSelection7.Visible = false;
                    break;
                case "SCR7":
                    SCRReportSelection1.Visible = false;
                    SCRReportSelection2.Visible = false;
                    SCRReportSelection3.Visible = false;
                    SCRReportSelection4.Visible = false;
                    SCRReportSelection5.Visible = false;
                    SCRReportSelection6.Visible = false;
                    SCRReportSelection7.Visible = true;
                    break;
            }
        }

        protected void grpOwnershipProgram_CheckedChanged(object sender, EventArgs e)
        {
            if (OwernsipProgramChoice.Checked.Equals(true))
            {
                listOwnershipProgram.Visible = true;
            }
            else
            {
                listOwnershipProgram.Visible = false;
            }
        }

        protected void grpOwnershipType_CheckedChanged(object sender, EventArgs e)
        {
            if (OwnershipTypeChoice.Checked.Equals(true))
            {
                listOwnershipType.Visible = true;
            }
            else
            {
                listOwnershipType.Visible = false;
            }
        }

        protected void grpProvTypeAll_CheckedChanged(object sender, EventArgs e)
        {
            if (optProvTypeChoice.Checked.Equals(true))
            {
                lstCheckLogParamsProvType.Visible = true;
                if (Session["NameOfReport"] == "TransactionReport")
                {
                    lblStateID.Visible = true;
                    StateIDTxt.Visible = true;
                }
                else
                {
                    lblStateID.Visible = false;
                    StateIDTxt.Visible = false;
                }
            }
            else
            {
                lstCheckLogParamsProvType.Visible = false;
                lblStateID.Visible = false;
                StateIDTxt.Visible = false;
            }
        }

        protected void grpVehicleReportType_CheckedChanged(object sender, EventArgs e)
        {
            if (optVehicleProviderType.Checked.Equals(true))
            {
                listVehicleProviderType.Visible = true;
                //if (Session["NameOfReport"] == "EMSNEMTVEHICLEREPORT")
                //{
                //    lblStateID.Visible = true;
                //    StateIDTxt.Visible = true;
                //}
                //else
                //{
                //    lblStateID.Visible = false;
                //    StateIDTxt.Visible = false;
                //}
            }
            else
            {
                listVehicleProviderType.Visible = false;
                //lblStateID.Visible = false;
                //StateIDTxt.Visible = false;
            }
        }
        
        /// <summary>
        /// Setup the List used for the Directories report
        /// </summary>
        private void SetUpDirectoriesList()
        {   
            listDirectories.Items.Clear();
            listDirectories.DataSource = FacilitiesLookups;
            listDirectories.DataTextField = "ProgramDescription";
            listDirectories.DataValueField = "ProgramID";
            listDirectories.DataBind();
        }

        /// <summary>
        /// Setup the List used for the Facilities report
        /// </summary>
        private void SetUpFacilitiesList()
        {
            listFacilities.Items.Clear();
            listFacilities.DataSource = FacilitiesLookups;
            listFacilities.DataTextField = "ProgramDescription";
            listFacilities.DataValueField = "ProgramID";
            listFacilities.DataBind();
        }

        /// <summary>
        /// Set the list of IDR Types
        /// </summary>
        private void SetUpIDRTypeList()
        {
            listAspenIDRType.Items.Clear();
            listAspenIDRType.DataSource = IDRTypeLookups;
            listAspenIDRType.DataTextField = "VALDESC";
            listAspenIDRType.DataValueField = "LOOKUPVAL";
            listAspenIDRType.DataBind();
        }

        private void SetUpLabelsList()
        {
            listProviderType.Items.Clear();
            listProviderType.DataSource = DirectoriesLookups;
            listProviderType.DataTextField = "ProgramDescription";
            listProviderType.DataValueField = "ProgramID";
            listProviderType.DataBind();
        }

        /// <summary>
        /// Set the list of Facility Types ... for DivCheckLogParams -> tblProviderType -> optProvTypeChoice -> lstCheckLogParamsProvType
        /// </summary>
        private void SetUpCheckLogParamsProvType()
        {
            lstCheckLogParamsProvType.Items.Clear();
            lstCheckLogParamsProvType.DataSource = FacilitiesLookups;
            lstCheckLogParamsProvType.DataTextField = "ProgramDescription";
            lstCheckLogParamsProvType.DataValueField = "ProgramID";
            lstCheckLogParamsProvType.DataBind();
            lstCheckLogParamsProvType.ClearSelection();
        }

        private void SetUpLabelsList1()
        {
            listExpirationDateProviderType.Items.Clear();
            listExpirationDateProviderType.DataSource = FacilitiesLookups;
            listExpirationDateProviderType.DataTextField = "ProgramDescription";
            listExpirationDateProviderType.DataValueField = "ProgramID";
            listExpirationDateProviderType.DataBind();
        }

        private void SetUpVehicleParamsProvType()
        {
            listVehicleProviderType.Items.Clear();
            listVehicleProviderType.DataSource = FacilitiesLookups;
            listVehicleProviderType.DataTextField = "ProgramDescription";
            listVehicleProviderType.DataValueField = "ProgramID";
            listVehicleProviderType.DataBind();
        }

        private void SetUpAdHocParamsProvType()
        {
            listAdHocProviderType.Items.Clear();
            listAdHocProviderType.DataSource = FacilitiesLookups;
            listAdHocProviderType.DataTextField = "ProgramDescription";
            listAdHocProviderType.DataValueField = "ProgramID";
            listAdHocProviderType.DataBind();
        }

        /// <summary>
        /// Return all Programs
        /// </summary>
        private BO_Programs DirectoriesLookups
        {
            get
            {
                BO_Programs boPrograms;

                if (Session["DirectoriesLookups"] == null)
                {
                    boPrograms = BO_Program.SelectAll();
                    DirectoriesLookups = boPrograms;
                }
                else
                    boPrograms = (BO_Programs)Session["DirectoriesLookups"];

                return boPrograms;
            }
            set
            {
                Session["DirectoriesLookups"] = value;
            }
        }

        /// <summary>
        /// Return Programs that are applicable for Facilities Report
        /// </summary>
        private BO_Programs FacilitiesLookups
        {
            get
            {
                BO_Programs tmpPrograms = new BO_Programs();

                if (Session["FacilitiesLookups"] == null)
                {
                    // get all Programs
                    BO_Programs boPrograms = BO_Program.SelectAll();

                    boPrograms.Sort( "ProgramDescription" );
                    // filter out those that are not applicable
                    foreach (BO_Program boProgramItem in boPrograms)
                    {
                        //if (!boProgramItem.ProgramID.Equals("HH") &&
                        //    !boProgramItem.ProgramID.Equals("HP") &&
                        //    //!boProgramItem.ProgramID.Equals("HO") &&
                        //    !boProgramItem.ProgramID.Equals("MH") &&
                        //    !boProgramItem.ProgramID.Equals("SA"))
                        //{
                            tmpPrograms.Add(boProgramItem);
                        //}
                    }
                    // store this in the Sessoin
                    FacilitiesLookups = tmpPrograms;
                }
                else
                    tmpPrograms = (BO_Programs)Session["FacilitiesLookups"];

                return tmpPrograms;
            }
            set
            {
                Session["FacilitiesLookups"] = value;
            }
        }

        /// <summary>
        /// Get List of IDR Types
        /// </summary>
        private BO_LookupValues IDRTypeLookups
        {
            get
            {
                BO_LookupValues retLkups = new BO_LookupValues();
                if (Session["IDRTypeLookups"] == null)
                {
                    retLkups = BO_LookupValue.SelectByField(BO_LookupValueFields.LookupKey, "IDR_TYPE");
                }
                else
                    retLkups = (BO_LookupValues)Session["IDRTypeLookups"];

                IDRTypeLookups = retLkups;

                return retLkups;
            }
            set
            {
                Session["IDRTypeLookups"] = value;
            }
        }

        #endregion
    }

}