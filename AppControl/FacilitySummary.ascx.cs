using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using ATG;
using ATG.BusinessObject;
using Telerik.Web.UI;

namespace AppControl
{
    public partial class FacilitySummary : System.Web.UI.UserControl
    {
        #region Variables: Local
        private FacilityAS400Comments m_AS400CommentsControl = null;
        private FacilityDates m_DatesControl = null;
        private FacilityOperatingDetails m_OperatingDetails = null;
        private Services m_Services = null;
        private SpecialtyUnit _m_ProvSpecUnits = null;
        private FacilityTypeOf _m_FacilityTypeOf = null;
        private GenericCapSumm _m_GenericCapSumm = null;
        private ProgramOperatingInfo _m_ProgramOperatingInfo = null;
        private AffiliationOffsite _m_OffsiteCampuses = null;
        private Drivers _m_Drivers = null;
        private InsuranceCoverage _m_Insurance = null;
        private ParishesSubstations _m_ParishesSubstations = null;
        private Vehicles _m_Vehicles = null;


        /* TODO: declare member variables for the following:
         */
        //private Ownership _m_Ownership = null;
        //private KeyPersonnel _m_KeyPersonnel = null;
        //Substation control
        //Insurance control
        //Vehicle control
        #endregion

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            LoadFacilityNonHistoryControls();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // do nothing
        }

        public void LoadNewProvider(string appId)
        {
            FacilityDetails1.LoadNewProvider();
            m_DatesControl.LoadNewProvider();
            m_AS400CommentsControl.LoadNewProvider(Convert.ToDecimal(CurrentProvider.PopsIntID));

            /* 
             * TODO: display the other controls only
             * if they are applicable for the current Provider Type
             */

            if (m_OperatingDetails != null)
            {
                m_OperatingDetails.LoadNewProvider();
                m_OperatingDetails.DisableInputControls();
            }

            if (m_Services != null)
            {
                m_Services.LoadApplication(appId, false, false);
                m_Services.DisableServices();
            }

            if (null != _m_ProvSpecUnits)
            {
                _m_ProvSpecUnits.LoadApplication(appId, false, false);
                _m_ProvSpecUnits.DisableSpecialityUnits();
            }

            if (_m_OffsiteCampuses != null)
            {
                _m_OffsiteCampuses.LoadAffiliation();
            }

            if ( null != _m_FacilityTypeOf )
            {
                _m_FacilityTypeOf.LoadApplication( appId, false, false );
            }

            if ( null != _m_GenericCapSumm )
            {
                _m_GenericCapSumm.LoadCapacitySummary( appId, false, false );
            }

            if (null != _m_ProgramOperatingInfo)
            {
                _m_ProgramOperatingInfo.LoadApplication(appId, false, false);
            }

            if (null != _m_Drivers)
            {
                _m_Drivers.LoadDrivers();
            }

            if (null != _m_Insurance) {
                _m_Insurance.LoadInsuranceCoverage();
            }

            if (null != _m_ParishesSubstations)
            {
                _m_ParishesSubstations.LoadSubstations();
            }

            if (null != _m_Vehicles)
            {
                _m_Vehicles.LoadVehicles();
            }

            _ShowHideFields();

        }

        private void LoadFacilityNonHistoryControls()
        {
            m_DatesControl = (FacilityDates)LoadControl("~/AppControl/FacilityDates.ascx");
            PanelDatesContent.Controls.Add(m_DatesControl);
            m_DatesControl.ID = "FacilityDates";

            m_AS400CommentsControl = (FacilityAS400Comments)LoadControl("~/AppControl/FacilityAS400Comments.ascx");
            PanelAS400CommentsContent.Controls.Add(m_AS400CommentsControl);
            m_AS400CommentsControl.ID = "FacilityAS400Comments";

            m_OperatingDetails = (FacilityOperatingDetails)LoadControl("~/AppControl/FacilityOperatingDetails.ascx");
            PanelOperatingHoursContent.Controls.Add(m_OperatingDetails);
            m_OperatingDetails.ID = "FacilityOperatingDetails";

            m_Services = (Services)LoadControl("~/AppControl/Services.ascx");
            PanelServices.Controls.Add(m_Services);
            m_Services.ID = "Services";

            _m_ProvSpecUnits = (SpecialtyUnit)LoadControl("~/AppControl/SpecialtyUnit.ascx");
            PanelSpecialtyUnits.Controls.Add(_m_ProvSpecUnits);
            _m_ProvSpecUnits.ID = "FacilitySpecialtyUnits";


            _m_OffsiteCampuses = (AffiliationOffsite)LoadControl("~/AppControl/AffiliationOffsite.ascx");
            PanelOffSiteCampuses.Controls.Add(_m_OffsiteCampuses);
            _m_OffsiteCampuses.ID = "OffsiteCampuses";

            _m_FacilityTypeOf = (FacilityTypeOf)LoadControl("~/AppControl/FacilityTypeOf.ascx");
            PanelFacilityTypeOfContent.Controls.Add(_m_FacilityTypeOf);
            _m_FacilityTypeOf.ID = "FacilityTypeOf";

            _m_ProgramOperatingInfo = (ProgramOperatingInfo)LoadControl("~/AppControl/ProgramOperatingInfo.ascx");
            PanelOperatingInfo.Controls.Add(_m_ProgramOperatingInfo);
            _m_ProgramOperatingInfo.ID = "OperatingInfo";

            _m_GenericCapSumm = (GenericCapSumm)LoadControl("~/AppControl/GenericCapSumm.ascx");
            PanelGenericCapSumm.Controls.Add(_m_GenericCapSumm);
            _m_GenericCapSumm.ID = "GenericCapSumm";

            _m_Drivers = (Drivers)LoadControl("~/AppControl/Drivers.ascx");
            PanelDrivers.Controls.Add(_m_Drivers);
            _m_Drivers.ID = "Drivers";

             _m_Insurance = (InsuranceCoverage)LoadControl("~/AppControl/InsuranceCoverages.ascx");
            PanelInsurance.Controls.Add(_m_Insurance);
            _m_Insurance.ID = "Insurance";

            _m_ParishesSubstations = (ParishesSubstations)LoadControl("~/AppControl/ParishesSubstations.ascx");
            PanelParishesSubstations.Controls.Add(_m_ParishesSubstations);
            _m_ParishesSubstations.ID = "ParishesSubstations";

            _m_Vehicles = (Vehicles)LoadControl("~/AppControl/Vehicles.ascx");
            PanelVehicles.Controls.Add(_m_Vehicles);
            _m_Vehicles.ID = "Vehicles";
        }

        private void _ShowHideFields()
        {
            //Turn off all sections first then enable them by program type and location
            SliderDivAS400Comments.Visible = true;
            SliderDivDates.Visible = true;
            SliderDivFacilityTypeOf.Visible = false;
            SliderDivInsurance.Visible = false;
            SliderDivOperatingHours.Visible = false;
            SliderDivServices.Visible = false;
            SliderDivSpecialtyUnits.Visible = false;
            SliderDivSubstation.Visible = false;
            SliderDivVehicle.Visible = false;
            SliderDivGenericCapSumm.Visible = false;
            SliderDivOffSiteCampuses.Visible = false;
            SliderDivOperatingInfo.Visible = false;
            SliderDivKeyPersonnel.Visible = false;
            SliderDivOwnership.Visible = false;
            SliderDivDrivers.Visible = false;
            SliderDivInsurance.Visible = false;
            SliderVehicles.Visible = false;
            SliderParishesSubstations.Visible = false;

            switch (CurrentAppProvider.ProgramID)
            {
                case "HC":
                    SliderDivOperatingHours.Visible = true;
                    SliderDivServices.Visible = true;
                    SliderDivOffSiteCampuses.Visible = true;
                    break;
                case "HO":
                    SliderDivServices.Visible = true;
                    SliderDivSpecialtyUnits.Visible = true;
                    SliderDivOffSiteCampuses.Visible = true;
                    SliderDivFacilityTypeOf.Visible = true;
                    SliderDivFacilityTypeOf.TitleText = "Additional Provider Information";
                    break;
                case "BR":
                    SliderDivFacilityTypeOf.Visible = true;
                    SliderDivGenericCapSumm.Visible = true;
                    SliderDivOffSiteCampuses.Visible = true;
                    break;
                case "HP":
                    SliderDivServices.Visible = true;
                    SliderDivGenericCapSumm.Visible = true;
                    SliderDivFacilityTypeOf.Visible = true;
                    SliderDivOffSiteCampuses.Visible = true;
                    break;
                case "PD":
                    SliderDivOperatingHours.Visible = true;
                    break;
                case "HH":
                    SliderDivGenericCapSumm.Visible = true;
                    SliderDivServices.Visible = true;
                    SliderDivOperatingHours.Visible = true;
                    SliderDivFacilityTypeOf.Visible = true;
                    SliderDivOffSiteCampuses.Visible = true;
                    break;
                case "WA":
                    SliderDivOperatingHours.Visible = true;
                    SliderDivGenericCapSumm.Visible = true;
                    break;
                case "FF":
                    SliderDivServices.Visible = true;
                    SliderDivGenericCapSumm.Visible = true;
                    break;
                case "PM":
                    SliderDivGenericCapSumm.Visible = true;
                    SliderDivOperatingHours.Visible = true;
                    break;
                case "AC":
                    SliderDivGenericCapSumm.Visible = true;
                    break;
                case "CM":
                    SliderDivServices.Visible = true;
                    break;
                case "ES":
                    SliderDivServices.Visible = true;
                    SliderDivOperatingHours.Visible = true;
                    break;
                case "RH":
                    SliderDivOperatingHours.Visible = true;
                    break;
                case "SA":
                    SliderDivServices.Visible = true;
                    SliderDivOperatingHours.Visible = true;
                    SliderDivGenericCapSumm.Visible = true;
                    SliderDivOffSiteCampuses.Visible = true;
                    break;
                case "BO":
                    SliderDivOperatingHours.Visible = true;
                    break;
                case "AS":
                    SliderDivOperatingHours.Visible = true;
                    SliderDivServices.Visible = true;
                    SliderDivFacilityTypeOf.Visible = true;
                    SliderDivFacilityTypeOf.TitleText = "Additional Provider Information";
                    break;
                case "MR":
                    SliderDivGenericCapSumm.Visible = true;
                    break;
                case "NH":
                    SliderDivFacilityTypeOf.Visible = true;
                    SliderDivFacilityTypeOf.TitleText = "Additional Provider Information";
                    SliderDivGenericCapSumm.Visible = true;
                    break;
                case "CO":
                    SliderDivFacilityTypeOf.Visible = true;
                    SliderDivFacilityTypeOf.TitleText = "Additional Provider Information";
                    SliderDivServices.Visible = true;
                    break;
                case "MH":
                    SliderDivOffSiteCampuses.Visible = true;
                    break;
                case "PT":
                    SliderDivGenericCapSumm.Visible = true;
                    break;
                case "TG":
                    SliderDivGenericCapSumm.Visible = true;
                    break;
                case "MT":
                    SliderDivOperatingInfo.Visible = true;
                    SliderDivInsurance.Visible = true;
                    SliderParishesSubstations.Visible = true;
                    SliderVehicles.Visible = true;
                    break;
                case "NE":
                    SliderDivOperatingInfo.Visible = true;
                    SliderDivDrivers.Visible = true;
                    SliderDivInsurance.Visible = true;
                    SliderParishesSubstations.Visible = true;
                    SliderVehicles.Visible = true;
                    break;
                case "BH":
                    SliderDivServices.Visible = true;
                    SliderDivOperatingHours.Visible = true;
                    SliderDivGenericCapSumm.Visible = true;
                    SliderDivOffSiteCampuses.Visible = true;
                    break;
            }

            //Always disabled for offsites regardless of type provider
            if (IsOffSite)
            {

            }

        }

        #region Variables: Functions

        private BO_Provider CurrentProvider
        {
            get
            {
                return Session["CurrentProvider"] == null ? null : (BO_Provider)Session["CurrentProvider"];
            }
        }

        private BO_Application CurrentAppProvider
        {
            get
            {
                return Session["CurrentAppProvider"] == null ? null : (BO_Application)Session["CurrentAppProvider"];
            }
        }

        private bool IsOffSite
        {
            get
            {
                return (ViewState["IsOffSite"] != null ? (bool)ViewState["IsOffSite"] : false);
            }
        }

        #endregion
    }
}
