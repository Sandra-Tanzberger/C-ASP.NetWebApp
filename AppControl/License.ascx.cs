using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using ATG;
using ATG.BusinessObject;
using ATG.Security;

namespace AppControl
{
    public partial class License : System.Web.UI.UserControl
    {
        private ApplicationItems _m_AppItemControl = null;
        private AplctnProvider _m_FacControl = null;
        private SpecialtyUnit _m_SpecUnitControl = null;
        private Personnel _m_FacPersControl = null;
        private HO_BedSummary _m_BedSummaryControl = null;
        private GenericCapSumm _m_CapacitySummary = null;
        private AffiliationOffsite _m_AffilOffsiteControl = null;
        private Ownership _m_OwnControl = null;
        private AppAttachment _m_AppAttachControl = null;
        private Services _m_ServicesControl = null;
        private PaymentAuthorization _m_PaymentAuthorizationControl = null;
        private FacilityOperatingDetails _m_FacilityOperatingDetails = null;
        private ProgramOperatingInfo _m_ProgramOperatingInfo = null;
        private Drivers _m_Drivers = null;
        private InsuranceCoverage _m_InsuranceCoverage = null;
        private ParishesSubstations _m_ParishesSubstations = null;
        private Vehicles _m_Vehicles = null;

        protected override void OnInit( EventArgs e )
        {
            base.OnInit( e );

            _LoadLicenseControls();
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (User.IsReadOnly())
            {
                SetReadOnly(this.Controls);//currently only setting link button's as they have fallen outside the normal read only, allow edit handling
            }
        }

        private void _LoadLicenseControls()
        {
            //Always show Application Items/Summary section
            _m_AppItemControl = (ApplicationItems) LoadControl( "~/AppControl/ApplicationItems.ascx" );
            ApplicationItemsContent.Controls.Add( _m_AppItemControl );
            _m_AppItemControl.EnableViewState = true;
            _m_AppItemControl.ID = "ApplicationItems";
            CurrentAppItemControlID = _m_AppItemControl.ID;
            // don't show for public site
            sldrAppItems.Visible = ((string)Session["userType"]).Equals("State");

            _m_FacControl = (AplctnProvider) LoadControl( "~/AppControl/AplctnProvider.ascx" );
            FacilityDetailContent.Controls.Add( _m_FacControl );
            _m_FacControl.EnableViewState = true;
            _m_FacControl.ID = "FacilityDemographics";
            CurrentFacilityControlID = _m_FacControl.ID;

            _m_SpecUnitControl = (SpecialtyUnit) LoadControl( "~/AppControl/SpecialtyUnit.ascx" );
            SpecialtyUnitContent.Controls.Add( _m_SpecUnitControl );
            _m_SpecUnitControl.EnableViewState = true;
            _m_SpecUnitControl.ID = "SpecialtyUnits";
            CurrentSpecialtyUnitControlID = _m_SpecUnitControl.ID;

            _m_FacPersControl = (Personnel) LoadControl( "~/AppControl/Personnel.ascx" );
            KeyPersonnelDetailContent.Controls.Add( _m_FacPersControl );
            _m_FacPersControl.EnableViewState = true;
            _m_FacPersControl.ID = "FacilityPersonnel";
            CurrentFacPersControlID = _m_FacPersControl.ID;

            if ( CurrentProvider.ProgramID.Equals( "HO" ) )
            {
                _m_BedSummaryControl = (HO_BedSummary) LoadControl( "~/AppControl/HO_BedSummary.ascx" );
                BedDetailContent.Controls.Add( _m_BedSummaryControl );
                _m_BedSummaryControl.EnableViewState = true;
                _m_BedSummaryControl.ID = "FacilityBeds";
                CurrentFacBedDetControlID = _m_BedSummaryControl.ID;
            }
            else if ( ("BR,HP,HH,FF,AC,WA,SA,AS,MR,NH,PT,TG").Contains(CurrentProvider.ProgramID) )
            {
                _m_CapacitySummary = (GenericCapSumm) LoadControl( "~/AppControl/GenericCapSumm.ascx" );
                BedDetailContent.Controls.Add( _m_CapacitySummary );
                _m_CapacitySummary.EnableViewState = true;
                _m_CapacitySummary.ID = "FacilityCapacity";
                CurrentFacBedDetControlID = _m_CapacitySummary.ID;
            }

            _m_AffilOffsiteControl = (AffiliationOffsite) LoadControl( "~/AppControl/AffiliationOffsite.ascx" );
            AffiliationDetailContent.Controls.Add( _m_AffilOffsiteControl );
            _m_AffilOffsiteControl.EnableViewState = true;
            _m_AffilOffsiteControl.ID = "FacilityAffiliations";
            CurrentAffilOffsiteControlID = _m_AffilOffsiteControl.ID;

            _m_OwnControl = (Ownership) LoadControl( "~/AppControl/Ownership.ascx" );
            OwnerDetailContent.Controls.Add( _m_OwnControl );
            _m_OwnControl.EnableViewState = true;
            _m_OwnControl.ID = "FacilityOwnership";
            CurrentOwnerControlID = _m_OwnControl.ID;

            _m_AppAttachControl = (AppAttachment) LoadControl( "~/AppControl/AppAttachment.ascx" );
            AttachmentDetailContent.Controls.Add( _m_AppAttachControl );
            _m_AppAttachControl.EnableViewState = true;
            _m_AppAttachControl.ID = "FacilityAttachments";
            CurrentAttachControlID = _m_AppAttachControl.ID;

            _m_ServicesControl = (Services) LoadControl( "~/AppControl/Services.ascx" );
            ServicesContent.Controls.Add( _m_ServicesControl );
            _m_ServicesControl.EnableViewState = true;
            _m_ServicesControl.ID = "Services";
            CurrentServicesControlID = _m_ServicesControl.ID;

            _m_FacilityOperatingDetails = (FacilityOperatingDetails) LoadControl( "~/AppControl/FacilityOperatingDetails.ascx" );
            OperDetailsContent.Controls.Add( _m_FacilityOperatingDetails );
            _m_FacilityOperatingDetails.EnableViewState = true;
            _m_FacilityOperatingDetails.ID = "FacilityOperatingDetails";
            CurrentFacilityOperatingDetailsControlId = _m_FacilityOperatingDetails.ID;

            _m_ProgramOperatingInfo = (ProgramOperatingInfo) LoadControl( "~/AppControl/ProgramOperatingInfo.ascx" );
            ProgramOperatingInfoContent.Controls.Add( _m_ProgramOperatingInfo );
            _m_ProgramOperatingInfo.EnableViewState = true;
            _m_ProgramOperatingInfo.ID = "ProgramOperatingInfo";
            CurrentProgOpInfoControlID = _m_ProgramOperatingInfo.ID;

            _m_PaymentAuthorizationControl = (PaymentAuthorization)LoadControl("~/AppControl/PaymentAuthorization.ascx");
            PaymentAuthorizationContent.Controls.Add(_m_PaymentAuthorizationControl);
            _m_PaymentAuthorizationControl.EnableViewState = true;
            _m_PaymentAuthorizationControl.ID = "PayementAuthorization";
            CurrentPayAuthControlID = _m_PaymentAuthorizationControl.ID;
            sldrPaymentAuthorization.Visible = ((string)Session["userType"]).Equals("Public"); // don't show for state site

             if ( ("NE").Contains(CurrentProvider.ProgramID) )
             {
                 _m_Drivers = (Drivers)LoadControl("~/AppControl/Drivers.ascx");
                 DriversContent.Controls.Add(_m_Drivers);
                 _m_Drivers.EnableViewState = true;
                 _m_Drivers.ID = "Drivers";
                 sldrDrivers.Visible = true;
             }

             if (("MT,NE").Contains(CurrentProvider.ProgramID)) {
                 _m_InsuranceCoverage = (InsuranceCoverage)LoadControl("~/AppControl/InsuranceCoverages.ascx");
                 InsuranceCoverageContent.Controls.Add(_m_InsuranceCoverage);
                 _m_InsuranceCoverage.EnableViewState = true;
                 _m_InsuranceCoverage.ID = "InsuranceCoverage";
                 sldrInsuranceCoverage.Visible = true;

                 _m_ParishesSubstations = (ParishesSubstations)LoadControl("~/AppControl/ParishesSubstations.ascx");
                 ParishesSubstationsContent.Controls.Add(_m_ParishesSubstations);
                 _m_ParishesSubstations.EnableViewState = true;
                 _m_ParishesSubstations.ID = "ParishesSubstations";
                 sldrParishesSubstations.Visible = true;

                 _m_Vehicles = (Vehicles)LoadControl("~/AppControl/Vehicles.ascx");
                 VehiclesContent.Controls.Add(_m_Vehicles);
                 _m_Vehicles.EnableViewState = true;
                 _m_Vehicles.ID = "Vehicles";
                 sldrVehicles.Visible = true;
             }

        }

        protected void Page_Load( object sender, EventArgs e )
        {
 
            //Enable nav menu
            RadAjaxPanel licPanel = (RadAjaxPanel) Page.FindControlRecursive( "LicNavPanel" );

            if ( null != licPanel )
                licPanel.Visible = true;

        }

        public void InitLicenseControls( string inAppID, bool inAllowEdit )
        {
            _m_FacControl.LoadApplication( inAppID, inAllowEdit, false );
            _m_AppItemControl.LoadApplication( inAppID, inAllowEdit );
            _m_SpecUnitControl.LoadApplication( inAppID, inAllowEdit, false );
            _m_FacPersControl.LoadApplication( inAppID, inAllowEdit );
            _m_OwnControl.LoadApplication( inAppID, inAllowEdit );
            _m_AffilOffsiteControl.LoadAffiliation( inAppID, inAllowEdit );
            _m_ProgramOperatingInfo.LoadApplication( inAppID, inAllowEdit, false );

            if ( ("HO").Contains(CurrentAppProvider.ProgramID) )
            {
                _m_BedSummaryControl.LoadBedSummary( inAppID, inAllowEdit, false );
            }
            else if ( ("BR").Contains(CurrentAppProvider.ProgramID) )
            {
                sldrRmBeds.TitleText = "Capacity Summary";
                _m_CapacitySummary.LoadCapacitySummary( inAppID, inAllowEdit, false );
            }
            else if ( ("HP,HH,FF,AC,WA,SA,AS,MR,NH,PT,TG").Contains(CurrentAppProvider.ProgramID) )
            {
                sldrRmBeds.TitleText = "Program Operational Information";
                _m_CapacitySummary.LoadCapacitySummary( inAppID, inAllowEdit, false );
            }

            _m_AppAttachControl.LoadApplication( inAppID );
            _m_ServicesControl.LoadApplication( inAppID, inAllowEdit, false );
            _m_FacilityOperatingDetails.LoadApplication( inAppID );
            HideLicense.Style["display"] = "block";

            if (User.IsReadOnly())
            {

                if (("NE").Contains(CurrentProvider.ProgramID))
                {
                    _m_Drivers.LoadDrivers();//load read only version, same as used for the provider view
                }

                if (("MT,NE").Contains(CurrentProvider.ProgramID))
                {
                    _m_InsuranceCoverage.LoadInsuranceCoverage();
                    _m_ParishesSubstations.LoadSubstations();
                    _m_Vehicles.LoadVehicles();
                }

            }
            
            /* 
             * Hide the sliders containing controls that are:
             * 1) not applicable for the current Provider type OR
             * 2) not applicable for the current Business Process
             */
            HideSlidersIfNotApplicable();
            Validate();
        }

        public bool Save()
        {
            return Save_Command( null, null );
        }

        public bool SaveSubmit()
        {
            bool bSaved = false;

            CurrentAppProvider.ApplicationStatus = "2";
            CurrentAppProvider.ApplicationStatusDesc = "Submitted";
            CurrentAppProvider.StatusComment = "";
            CurrentAppProvider.SubmissionDate = DateTime.Today;
            bSaved = Save_Command(null, null);

            //If save was successful then create billing rows.
            if (bSaved) {
                BO_ApplicationPrimaryKey pk = new BO_ApplicationPrimaryKey(CurrentAppProvider.ApplicationID);
                BO_Billing.NewBillingRecordByForeignKeyApplicationID(pk);
            }

            return bSaved;
        }

        protected bool Save_Command( object sender, CommandEventArgs e )
        {
            bool SaveAppItemCtrl = false;
            bool SaveFacCtrl = false;
            bool SaveSUCtrl = false;
            bool SaveFacPersCtrl = false;
            bool SaveOwnCtrl = false;
            bool SaveBedDetCtrl = false;
            bool SaveAttachCtrl = false;
            bool SaveServicesCtrl = false;
            bool SaveOperatingDetails = false;
            bool SaveProgramOpInfo = false;
            bool IsValidAuthPassword = false;

            bool noSaveError = true;
            string validationErrors = "";

            ErrorText.Visible = false;
            ErrorText.InnerHtml = "";

            //Save Data from controls to Session Application Object

            // Note: Validate only if the controls are visible
            // Application items must be saved first as there are
            // validation edits that occur based on the values in it
            if ( sldrAppItems.Visible )
            {
                _m_AppItemControl = (ApplicationItems) Page.FindControlRecursive( CurrentAppItemControlID );
                SaveAppItemCtrl = _m_AppItemControl.SaveData();
                if ( SaveAppItemCtrl )
                    sldrAppItems.IsComplete = "C";
                else
                {
                    noSaveError = false;
                    sldrAppItems.IsComplete = "I";
                }
            }
            else
                SaveAppItemCtrl = true;

            if ( sldrProvInfo.Visible )
            {
                _m_FacControl = (AplctnProvider)Page.FindControlRecursive(CurrentFacilityControlID);
                SaveFacCtrl = _m_FacControl.SaveData();
                if ( SaveFacCtrl )
                    sldrProvInfo.IsComplete = "C";
                else
                {
                    noSaveError = false;
                    sldrProvInfo.IsComplete = "I";
                }
            }
            else
                SaveFacCtrl = true;

            if (sldrSpecUnits.Visible)
            {
                _m_SpecUnitControl = (SpecialtyUnit)Page.FindControlRecursive(CurrentSpecialtyUnitControlID);
                SaveSUCtrl = _m_SpecUnitControl.SaveData();
                if ( SaveSUCtrl )
                    sldrSpecUnits.IsComplete = "C";
                else
                {
                    noSaveError = false;
                    sldrSpecUnits.IsComplete = "I";
                }
            }
            else
                SaveSUCtrl = true;

            if (sldrAdministration.Visible)
            {
                //_m_FacPersControl = (Personnel)Page.FindControlRecursive(CurrentFacPersControlID);
                //SaveFacPersCtrl = _m_FacPersControl.SaveData();
                //if ( SaveFacPersCtrl )
                sldrAdministration.IsComplete = "C";
                //else
                //{
                // noSaveError = false;
                /// sldrAdministration.IsComplete = "I";
                //}
                //}
                //else
                SaveFacPersCtrl = true;
            }

            if (sldrOwnership.Visible)
            {
                _m_OwnControl = (Ownership)Page.FindControlRecursive(CurrentOwnerControlID);
                SaveOwnCtrl = _m_OwnControl.SaveData();
                if ( SaveOwnCtrl )
                    sldrOwnership.IsComplete = "C";
                else
                {
                    noSaveError = false;
                    sldrOwnership.IsComplete = "I";
                }
            }
            else
                SaveOwnCtrl = true;

            if ( sldrRmBeds.Visible )
            {
                if ( ( "BR,HP,HH,AC,WA,FF,SA,AS,MR,NH,PT,TG" ).Contains( CurrentAppProvider.ProgramID ) )
                {
                    _m_CapacitySummary = (GenericCapSumm) Page.FindControlRecursive( CurrentFacBedDetControlID );
                    SaveBedDetCtrl = _m_CapacitySummary.SaveData();
                    if (SaveBedDetCtrl)
                        sldrRmBeds.IsComplete = "C";
                    else {
                        noSaveError = false;
                        sldrRmBeds.IsComplete = "I";
                    }
                }
                else
                    SaveBedDetCtrl = true;
            }
            else
                SaveBedDetCtrl = true;

            if (sldrAttachments.Visible)
            {
                _m_AppAttachControl = (AppAttachment)Page.FindControlRecursive(CurrentAttachControlID);
                SaveAttachCtrl = _m_AppAttachControl.SaveData();
                if ( SaveAttachCtrl )
                    sldrAttachments.IsComplete = "C";
                else
                {
                    noSaveError = false;
                    sldrAttachments.IsComplete = "I";
                }
            }
            else
                SaveAttachCtrl = true;

            if (sldrServices.Visible)
            {
                _m_ServicesControl = (Services)Page.FindControlRecursive(CurrentServicesControlID);
                SaveServicesCtrl = _m_ServicesControl.SaveData();
                if ( SaveServicesCtrl )
                    sldrServices.IsComplete = "C";
                else
                {
                    noSaveError = false;
                    sldrServices.IsComplete = "I";
                }
            }
            else
                SaveServicesCtrl = true;

            if (sldrOperDetails.Visible)
            {
                _m_FacilityOperatingDetails = (FacilityOperatingDetails)Page.FindControlRecursive(CurrentFacilityOperatingDetailsControlId);
                SaveOperatingDetails = _m_FacilityOperatingDetails.SaveData();
                if ( SaveOperatingDetails )
                    sldrOperDetails.IsComplete = "C";
                else
                {
                    noSaveError = false;
                    sldrOperDetails.IsComplete = "I";
                }
            }
            else
                SaveOperatingDetails = true;

            if ( sldrProgramOperatingInfo.Visible )
            {
                _m_ProgramOperatingInfo = (ProgramOperatingInfo) Page.FindControlRecursive( CurrentProgOpInfoControlID );
                SaveProgramOpInfo = _m_ProgramOperatingInfo.SaveData();
                if ( SaveProgramOpInfo )
                    sldrProgramOperatingInfo.IsComplete = "C";
                else
                {
                    noSaveError = false;
                    sldrProgramOperatingInfo.IsComplete = "I";
                }
            }
            else
                SaveProgramOpInfo = true;

            if (sldrPaymentAuthorization.Visible) {
                IsValidAuthPassword = ((PaymentAuthorization)Page.FindControlRecursive(CurrentPayAuthControlID)).ValidateAuthorizationPassword();
                if (IsValidAuthPassword) {
                    sldrPaymentAuthorization.IsComplete = "C";
                }
                else {
                    noSaveError = false;
                    sldrPaymentAuthorization.IsComplete = "I";
                }
            }
            else {
                IsValidAuthPassword = true;
            }

            //If the current application has not been approved then allow the application to be saved
            //even if all required fields are not complete
            if ( null != CurrentAppProvider && !CurrentAppProvider.ApplicationStatus.Equals("4") && noSaveError )
            {
                CurrentAppProvider.SaveFullApplication();
                return true;
            }
            else
            {
                //If the application is approved and there are no errors then save it.
                if ( null != CurrentAppProvider && CurrentAppProvider.ApplicationStatus.Equals( "4" )
                    && SaveFacCtrl
                    && SaveSUCtrl
                    && SaveFacPersCtrl
                    && SaveOwnCtrl
                    && SaveBedDetCtrl
                    && SaveAttachCtrl
                    && SaveServicesCtrl
                    && SaveAppItemCtrl
                    && SaveOperatingDetails
                    && SaveProgramOpInfo
                    && IsValidAuthPassword
                )
                {
                    //Before the save validate key required fields/values
                    noSaveError = _ValidateApprovedRequired();

                    if ( noSaveError )
                        CurrentAppProvider.SaveFullApplication();
                    
                    return noSaveError;
                }
                else
                {
                    validationErrors += "Validation errors encountered in the following sections<br />";

                    if ( !SaveFacCtrl )
                        validationErrors += sldrProvInfo.TitleText + "<br />";
                    if ( !SaveSUCtrl )
                        validationErrors += sldrSpecUnits.TitleText + "<br />"; 
                    if ( !SaveFacPersCtrl )
                        validationErrors += sldrAdministration.TitleText + "<br />";
                    if ( !SaveOwnCtrl )
                        validationErrors += sldrOwnership.TitleText + "<br />";
                    if ( !SaveBedDetCtrl )
                        validationErrors += sldrRmBeds.TitleText + "<br />";
                    if ( !SaveAttachCtrl )
                        validationErrors += sldrAttachments.TitleText + "<br />";
                    if ( !SaveServicesCtrl )
                        validationErrors += sldrServices.TitleText + "<br />";
                    if ( !SaveAppItemCtrl )
                        validationErrors += sldrAppItems.TitleText + "<br />";
                    if ( !SaveOperatingDetails )
                        validationErrors += sldrOperDetails.TitleText + "<br />";
                    if ( !SaveProgramOpInfo )
                        validationErrors += sldrProgramOperatingInfo.TitleText + "<br />";
                    if (!IsValidAuthPassword)
                        validationErrors += sldrPaymentAuthorization.TitleText + "<br />";

                    ErrorText.Visible = true;
                    ErrorText.InnerHtml = validationErrors;

                    return noSaveError;
                }
            }
        }

        // Validate method for approved applications as multiple values may be required 
        // prior to setting the status of an application to approved.
        private bool _ValidateApprovedRequired()
        {
            bool retSuccess = true;
            string validationErrors = "";

            if ( ( "HC" ).Contains( CurrentAppProvider.ProgramID ) )
            {
                if ( null == CurrentAppProvider.BO_ServicesApplicationID
                    || CurrentAppProvider.BO_ServicesApplicationID.Count < 1 )
                {
                    validationErrors += "Main Provider - You must select one or more service modules to in order to approve an application.<br />";
                }

                if ( null != CurrentAppProvider.BO_AffiliationsApplicationID )
                {
                    foreach ( BO_Affiliation boAfil in CurrentAppProvider.BO_AffiliationsApplicationID )
                    {
                        if ( null == boAfil.BO_ServicesAffiliationID
                             || boAfil.BO_ServicesAffiliationID.Count < 1 )
                        {
                            validationErrors += "Offsite (" + boAfil.LicensureNum + ") - You must select one or more service modules for this offsite in order to approve an application.<br />";
                        }
                    }
                }
            }

            if ( !retSuccess )
            {
                ErrorText.Visible = true;
                ErrorText.InnerHtml += validationErrors;
            }

            return retSuccess;
        }

        protected void Validate()
        {
            bool SaveAppItemCtrl = false;
            bool SaveFacCtrl = false;
            bool SaveSUCtrl = false;
            bool SaveFacPersCtrl = false;
            bool SaveOwnCtrl = false;
            bool SaveBedDetCtrl = false;
            bool SaveAttachCtrl = false;
            bool SaveServicesCtrl = false;
            bool SaveOperatingDetails = false;
            bool SaveProgramOpInfo = false;

            string validationErrors = "";

            ErrorText.Visible = false;
            ErrorText.InnerHtml = "";

            if ( !CurrentAppProvider.ApplicationAction.Equals("4") )
            {
                // Note: Validate only if the controls are visible
                // Application items must be saved first as there are
                // validation edits that occur based on the values in it
                if ( sldrAppItems.Visible )
                {
                    _m_AppItemControl = (ApplicationItems) Page.FindControlRecursive( CurrentAppItemControlID );
                    SaveAppItemCtrl = _m_AppItemControl.SaveData();
                    if ( SaveAppItemCtrl )
                        sldrAppItems.IsComplete = "C";
                    else
                        sldrAppItems.IsComplete = "I";
                }
                else
                    SaveAppItemCtrl = true;

                if ( sldrProvInfo.Visible )
                {
                    _m_FacControl = (AplctnProvider) Page.FindControlRecursive( CurrentFacilityControlID );
                    SaveFacCtrl = _m_FacControl.SaveData();
                    if ( SaveFacCtrl )
                        sldrProvInfo.IsComplete = "C";
                    else
                        sldrProvInfo.IsComplete = "I";
                }
                else
                    SaveFacCtrl = true;

                if ( sldrSpecUnits.Visible )
                {
                    _m_SpecUnitControl = (SpecialtyUnit) Page.FindControlRecursive( CurrentSpecialtyUnitControlID );
                    SaveSUCtrl = _m_SpecUnitControl.SaveData();
                    if ( SaveSUCtrl )
                        sldrSpecUnits.IsComplete = "C";
                    else
                        sldrSpecUnits.IsComplete = "I";
                }
                else
                    SaveSUCtrl = true;

                if (sldrAdministration.Visible)
                {
                    //_m_FacPersControl = (Personnel) Page.FindControlRecursive( CurrentFacPersControlID );
                    //SaveFacPersCtrl = _m_FacPersControl.SaveData();
                    //if ( SaveFacPersCtrl )
                    sldrAdministration.IsComplete = "C";
                    //else
                    // sldrAdministration.IsComplete = "I";
                    //}
                    //else
                    SaveFacPersCtrl = true;
                }

                if ( sldrOwnership.Visible )
                {
                    _m_OwnControl = (Ownership) Page.FindControlRecursive( CurrentOwnerControlID );
                    SaveOwnCtrl = _m_OwnControl.SaveData();
                    if ( SaveOwnCtrl )
                        sldrOwnership.IsComplete = "C";
                    else
                        sldrOwnership.IsComplete = "I";
                }
                else
                    SaveOwnCtrl = true;

                if ( sldrRmBeds.Visible )
                {
                    if ( ( "BR,HP,HH,AC,WA,AS,MR,NH" ).Contains( CurrentAppProvider.ProgramID ) )
                    {
                        _m_CapacitySummary = (GenericCapSumm) Page.FindControlRecursive( CurrentFacBedDetControlID );
                        SaveBedDetCtrl = _m_CapacitySummary.SaveData();
                        if ( SaveBedDetCtrl )
                            sldrRmBeds.IsComplete = "C";
                        else
                            sldrRmBeds.IsComplete = "I";
                    }
                    else
                        SaveBedDetCtrl = true;
                }
                else
                    SaveBedDetCtrl = true;

                if ( sldrAttachments.Visible )
                {
                    _m_AppAttachControl = (AppAttachment) Page.FindControlRecursive( CurrentAttachControlID );
                    SaveAttachCtrl = _m_AppAttachControl.SaveData();
                    if ( SaveAttachCtrl )
                        sldrAttachments.IsComplete = "C";
                    else
                        sldrAttachments.IsComplete = "I";
                }
                else
                    SaveAttachCtrl = true;

                if ( sldrServices.Visible )
                {
                    _m_ServicesControl = (Services) Page.FindControlRecursive( CurrentServicesControlID );
                    SaveServicesCtrl = _m_ServicesControl.SaveData();
                    if ( SaveServicesCtrl )
                        sldrServices.IsComplete = "C";
                    else
                        sldrServices.IsComplete = "I";
                }
                else
                    SaveServicesCtrl = true;

                if ( sldrOperDetails.Visible )
                {
                    _m_FacilityOperatingDetails = (FacilityOperatingDetails) Page.FindControlRecursive( CurrentFacilityOperatingDetailsControlId );
                    SaveOperatingDetails = _m_FacilityOperatingDetails.SaveData();
                    if ( SaveOperatingDetails )
                        sldrOperDetails.IsComplete = "C";
                    else
                        sldrOperDetails.IsComplete = "I";
                }
                else
                    SaveOperatingDetails = true;

                if ( sldrProgramOperatingInfo.Visible )
                {
                    _m_ProgramOperatingInfo = (ProgramOperatingInfo) Page.FindControlRecursive( CurrentProgOpInfoControlID );
                    SaveProgramOpInfo = _m_ProgramOperatingInfo.SaveData();
                    if ( SaveProgramOpInfo )
                        sldrProgramOperatingInfo.IsComplete = "C";
                    else
                    {
                        sldrProgramOperatingInfo.IsComplete = "I";
                    }
                }
                else
                    SaveProgramOpInfo = true;

                if ( null != CurrentAppProvider
                    && ( !SaveFacCtrl
                        || !SaveSUCtrl
                        || !SaveFacPersCtrl
                        || !SaveOwnCtrl
                        || !SaveBedDetCtrl
                        || !SaveAttachCtrl
                        || !SaveServicesCtrl
                        || !SaveAppItemCtrl
                        || !SaveOperatingDetails
                        || !SaveProgramOpInfo )
                )
                {
                    validationErrors += "Validation errors encountered in the following sections<br />";

                    if ( !SaveFacCtrl )
                        validationErrors += sldrProvInfo.TitleText + "<br />";
                    if ( !SaveSUCtrl )
                        validationErrors += sldrSpecUnits.TitleText + "<br />";
                    if ( !SaveFacPersCtrl )
                        validationErrors += sldrAdministration.TitleText + "<br />";
                    if ( !SaveOwnCtrl )
                        validationErrors += sldrOwnership.TitleText + "<br />";
                    if ( !SaveBedDetCtrl )
                        validationErrors += sldrRmBeds.TitleText + "<br />";
                    if ( !SaveAttachCtrl )
                        validationErrors += sldrAttachments.TitleText + "<br />";
                    if ( !SaveServicesCtrl )
                        validationErrors += sldrServices.TitleText + "<br />";
                    if ( !SaveAppItemCtrl )
                        validationErrors += sldrAppItems.TitleText + "<br />";
                    if ( !SaveOperatingDetails )
                        validationErrors += sldrOperDetails.TitleText + "<br />";
                    if ( !SaveProgramOpInfo )
                        validationErrors += sldrProgramOperatingInfo.TitleText + "<br />";

                    ErrorText.Visible = true;
                    ErrorText.InnerHtml = validationErrors;

                }
            }
        }

        /// <summary>
        /// Hide the sliders containing controls that are 
        /// 1) not applicable for the current Provider type OR
        /// 2) not applicable for the current Business Process
        /// </summary>
        private void HideSlidersIfNotApplicable()
        {
            BO_LookupValues tmpLkups = PublicSectionSwitchLookups;
            foreach (BO_LookupValue tmpLV in tmpLkups)
            {
                // check the Allowedtypes value for current ProgramID
                if (tmpLV.Allowedtypes != null)
                {
                    if (!tmpLV.Allowedtypes.Contains(CurrentAppProvider.ProgramID))
                    {
                        // this lookup value is not applicable for Current Provider Type
                        //switch (tmpLV.Valdesc.Trim())
                        switch (tmpLV.LookupVal)
                        {
                            case "03": //"SPECIALITY UNITS":
                                sldrSpecUnits.Visible = false;
                                break;
                            case "06": //"OFF-SITE CAMPUSES":
                                sldrOffsite.Visible = false;
                                break;
                            case "07": //"ROOMS/BEDS":
                                sldrRmBeds.Visible = false;
                                break;
                            case "09": //"SERVICES":
                                sldrServices.Visible = false;
                                break;
                            case "10": //"OPERATING HOURS":
                                sldrOperDetails.Visible = false;
                                break;
                            case "11": //"INSURANCE":
                                // TODO: implement when the control has been created
                                break;
                            case "12": //"VEHICLE":
                                // TODO: implement when the control has been created
                                break;
                            case "13": //"PROGRAMOPERATINGINFO":
                                sldrProgramOperatingInfo.Visible = false;
                                break;
                        }
                    }
                }
                //// check the Extra value for the Current BusinessProcessID
                //if (tmpLV.Extra != null)
                //{
                //    if (!tmpLV.Extra.Contains(CurrentAppProvider.BusinessProcessID))
                //    {
                //        // this lookup value is not applicable for Current Business Process
                //        switch (tmpLV.Valdesc.Trim())
                //        {
                //            case "PROVIDER INFORMATION":
                //                sldrProvInfo.Visible = false;
                //                break;
                //            case "SPECIALITY UNITS":
                //                sldrSpecUnits.Visible = false;
                //                break;
                //            case "KEY PERSONNEL":
                //                sldrAdministration.Visible = false;
                //                break;
                //            case "OWNERSHIP":
                //                sldrOwnership.Visible = false;
                //                break;
                //            case "OFF-SITE CAMPUSES":
                //                sldrOffsite.Visible = false;
                //                break;
                //            case "ROOMS/BEDS":
                //                sldrRmBeds.Visible = false;
                //                break;
                //            case "SERVICES":
                //                sldrServices.Visible = false;
                //                break;
                //            case "OPERATING HOURS":
                //                sldrOperDetails.Visible = false;
                //                break;
                //            case "INSURANCE":
                //                // TODO: implement when the control has been created
                //                break;
                //            case "VEHICLE":
                //                // TODO: implement when the control has been created
                //                break;
                //        }
                //    }
                //}
            }
        }

        private void SetReadOnly(ControlCollection controlsCol)
        {
            foreach (Control control in controlsCol)
            {
                if (control is LinkButton)
                    ((LinkButton)control).Visible = false;
                    /*
                else if (control is TextBox)
                    ((TextBox)control).Enabled = false;
                else if (control is RadioButton)
                    ((RadioButton)control).Enabled = false;
                else if (control is ImageButton)
                    ((ImageButton)control).Enabled = false;
                else if (control is CheckBox)
                    ((CheckBox)control).Enabled = false;
                else if (control is DropDownList)
                    ((DropDownList)control).Enabled = false;
                else if (control is HyperLink)
                    ((HyperLink)control).Enabled = false;
                else if (control is RadDatePicker)
                    ((RadDatePicker)control).Enabled = false;
                else if (control is RadListBox)
                    ((RadListBox)control).Enabled = false;
                else if (control is RadComboBox)
                    ((RadComboBox)control).Enabled = false;
                else if (control is RadNumericTextBox)
                    ((RadNumericTextBox)control).Enabled = false;
                else if (control is RadMaskedTextBox)
                    ((RadMaskedTextBox)control).Enabled = false;
                else if (control is RadioButtonList)
                    ((RadioButtonList)control).Enabled = false;
                     * */

                SetReadOnly(control.Controls);
            }
        }

        /// <summary>
        /// Lookup data for displaying/hiding Application sections
        /// </summary>
        private BO_LookupValues PublicSectionSwitchLookups
        {
            get
            {
                BO_LookupValues tmpLkups;
                if (Session["PublicSectionSwitchLookups"] == null)
                {
                    tmpLkups = BO_LookupValue.SelectByField(BO_LookupValueFields.LookupKey, "PUBLIC_SECTION_SWITCH");
                    PublicSectionSwitchLookups = tmpLkups;
                }
                else
                    tmpLkups = (BO_LookupValues)Session["PublicSectionSwitchLookups"];

                return tmpLkups;
            }
            set
            {
                Session["PublicSectionSwitchLookups"] = value;
            }
        }

        private User User
        {
            get { return (User)Session["User"]; }
        }

        /// <summary>
        /// Maintain the BO_Provider object in Session
        /// </summary>
        private BO_Provider CurrentProvider
        {
            get
            {
                return Session["CurrentProvider"] == null ? null : (BO_Provider) Session["CurrentProvider"];
            }
            set
            {
                Session["CurrentProvider"] = value;
            }
        }

        //Current Application Object with all associated child record collections and it is stored in
        //the session. All operations in child controls use this object 
        private BO_Application CurrentAppProvider
        {
            get
            {
                return (BO_Application) Session["CurrentAppProvider"];
            }
            set
            {
                Session["CurrentAppProvider"] = value;
            }
        }

        //Fixed control ID's for loaded controls
        private string CurrentAppItemControlID
        {
            get
            {
                return this.ViewState["CurrentAppItemControlID"] == null ? string.Empty : (string) this.ViewState["CurrentAppItemControlID"];
            }
            set
            {
                this.ViewState["CurrentAppItemControlID"] = value;
            }
        }
        private string CurrentFacilityControlID
        {
            get
            {
                return this.ViewState["CurrentFacilityControlID"] == null ? string.Empty : (string) this.ViewState["CurrentFacilityControlID"];
            }
            set
            {
                this.ViewState["CurrentFacilityControlID"] = value;
            }
        }
        private string CurrentSpecialtyUnitControlID
        {
            get
            {
                return this.ViewState["CurrentSpecialtyUnitControlID"] == null ? string.Empty : (string) this.ViewState["CurrentSpecialtyUnitControlID"];
            }
            set
            {
                this.ViewState["CurrentSpecialtyUnitControlID"] = value;
            }
        }
        private string CurrentOwnerControlID
        {
            get
            {
                return this.ViewState["CurrentOwnerControlID"] == null ? string.Empty : (string) this.ViewState["CurrentOwnerControlID"];
            }
            set
            {
                this.ViewState["CurrentOwnerControlID"] = value;
            }
        }
        private string CurrentFacPersControlID
        {
            get
            {
                return this.ViewState["CurrentFacPersControlID"] == null ? string.Empty : (string) this.ViewState["CurrentFacPersControlID"];
            }
            set
            {
                this.ViewState["CurrentFacPersControlID"] = value;
            }
        }
        private string CurrentFacBedDetControlID
        {
            get
            {
                return this.ViewState["CurrentFacBedDetControlID"] == null ? string.Empty : (string) this.ViewState["CurrentFacBedDetControlID"];
            }
            set
            {
                this.ViewState["CurrentFacBedDetControlID"] = value;
            }
        }
        private string CurrentAffilOffsiteControlID
        {
            get
            {
                return this.ViewState["CurrentAffilOffsiteControlID"] == null ? string.Empty : (string) this.ViewState["CurrentAffilOffsiteControlID"];
            }
            set
            {
                this.ViewState["CurrentAffilOffsiteControlID"] = value;
            }
        }
        private string CurrentAttachControlID
        {
            get
            {
                return this.ViewState["CurrentAttachControlID"] == null ? string.Empty : (string) this.ViewState["CurrentAttachControlID"];
            }
            set
            {
                this.ViewState["CurrentAttachControlID"] = value;
            }
        }
        private string CurrentServicesControlID
        {
            get
            {
                return this.ViewState["CurrentServicesControlID"] == null ? string.Empty : (string)this.ViewState["CurrentServicesControlID"];
            }
            set
            {
                this.ViewState["CurrentServicesControlID"] = value;
            }
        }
        private string CurrentFacilityOperatingDetailsControlId
        {
            get 
            {
                return this.ViewState["CurrentFacilityOperatingDetailsControlId"] == null ? string.Empty : (string)this.ViewState["CurrentFacilityOperatingDetailsControlId"];
            }
            set 
            {
                this.ViewState["CurrentFacilityOperatingDetailsControlId"] = value;
            }
        }
        private string CurrentProgOpInfoControlID
        {
            get 
            {
                return this.ViewState["CurrentProgOpInfoControlID"] == null ? string.Empty : (string) this.ViewState["CurrentProgOpInfoControlID"];
            }
            set 
            {
                this.ViewState["CurrentProgOpInfoControlID"] = value;
            }
        }
        private string CurrentPayAuthControlID  {
            get {
                return this.ViewState["CurrentPayAuthControlID"] == null ? string.Empty : (string)this.ViewState["CurrentPayAuthControlID"];
            }
            set {
                this.ViewState["CurrentPayAuthControlID"] = value;
            }
        }
    }
}