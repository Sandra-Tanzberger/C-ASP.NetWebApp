using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ATG;
using ATG.BusinessObject;

namespace AppControl
{
    public partial class AffiliationOffsiteEditForm : System.Web.UI.UserControl
    {
        private AplctnProvider _m_FacControl = null;
        private SpecialtyUnit _m_SpecUnitControl = null;
        private HO_BedSummary _m_BedSummaryControl = null;
        private Services _m_FacServiceControl = null;
        private GenericCapSumm _m_CapacitySummary = null;

        protected override void OnInit( EventArgs e )
        {
            base.OnInit( e );

            _LoadLicenseControls();
        }

        protected void Page_Load( object sender, EventArgs e )
        {

        }

        public void InitLicenseControls( string inKeyID, bool inAllowEdit )
        {
            AllowEdit = inAllowEdit;

            //SMM 03/30/2012 - Added
            //Need to create the ui_trackid for new affiliations here due to dependencies of child controls
            //along with the base record for the controls.
            if ( inKeyID.Equals( "0" ) )
            {
                BO_Affiliation tmpNewAffil = new BO_Affiliation();
                tmpNewAffil.PopsIntID = CurrentAppProvider.PopsIntID;
                tmpNewAffil.ApplicationID = CurrentAppProvider.ApplicationID;
                tmpNewAffil.AffiliationID = 0;
                tmpNewAffil.IsNewRec = true;
                
                if ( null != CurrentAppProvider.BO_AffiliationsApplicationID )
                {
                    CurrentKeyID = "N" + CurrentAppProvider.BO_AffiliationsApplicationID.Count.ToString();
                }
                else
                {
                    CurrentKeyID = "N0";
                }

                tmpNewAffil.UI_TrackID = CurrentKeyID;
                CurrentAppProvider.BO_AffiliationsApplicationID.Add( tmpNewAffil );
            }
            else
            {
                CurrentKeyID = inKeyID;
            }

            //if ( ( "HO,HC" ).Contains( CurrentAppProvider.ProgramID ) )
            //{
                _m_FacControl.LoadApplication( CurrentKeyID, AllowEdit, true );
            //}
            
            if ( ( "HO" ).Contains( CurrentAppProvider.ProgramID ) )
            {
                _m_SpecUnitControl.LoadApplication( CurrentKeyID, AllowEdit, true );
            }

            if ( ( "HO" ).Contains( CurrentAppProvider.ProgramID ) )
            {
                //_m_FacBedDetControl.LoadBeds( inKeyID, _AllowEdit, true );
                _m_BedSummaryControl.LoadBedSummary( CurrentKeyID, AllowEdit, true );
            }
            //else if ( ( "BR" ).Contains( CurrentAppProvider.ProgramID ) )
            //{
            //    sldrRmBedsAffiliation.TitleText = "Capacity Summary";
            //    _m_CapacitySummary.LoadCapacitySummary( CurrentKeyID, inAllowEdit, true );
            //}
            //SMM 05/21/2012 - Removed capacity info for HH and HP offsites
            //else if ( ( "HP,HH" ).Contains( CurrentAppProvider.ProgramID ) )
            //{
            //    sldrRmBedsAffiliation.TitleText = "Program Operational Information";
            //    _m_CapacitySummary.LoadCapacitySummary( CurrentKeyID, inAllowEdit, true );
            //}

            //SMM 05/21/2012 - Removed services for HH and HP offsites
            if ( ( "HC,SA" ).Contains( CurrentAppProvider.ProgramID ) )
            {
                _m_FacServiceControl.LoadApplication( CurrentKeyID, AllowEdit, true );
            }

        }

        public bool SaveData()
        {
            bool retVal = true;
            bool SuccessSaveFac = true;
            bool SuccessSaveSU = true;
            bool SuccessSaveSvcs = true;
            bool SuccessSaveCapSum = true;

            /*
             * HO - Hospital
             * HC - HCBS
             * 
             */
            //if ( ( "HO,HC" ).Contains( CurrentAppProvider.ProgramID ) )
            //{
                SuccessSaveFac = _m_FacControl.SaveData();
            //}
            if ( ( "HO" ).Contains( CurrentAppProvider.ProgramID ) )
            {
                SuccessSaveSU = _m_SpecUnitControl.SaveData();
            }
            //SMM 05/21/2012 - Removed services for HH and HP offsites
            if ( ( "HC,SA" ).Contains( CurrentAppProvider.ProgramID ) )
            {
                SuccessSaveSvcs = _m_FacServiceControl.SaveData();
            }

            //SMM 05/21/2012 - Removed capacity info for HH and HP offsites
            //if ( ( "HP,HH" ).Contains( CurrentAppProvider.ProgramID ) )
            //{
            //    SuccessSaveCapSum = _m_CapacitySummary.SaveData();
            //}

            if ( SuccessSaveFac
                && SuccessSaveSU
                && SuccessSaveSvcs
                && SuccessSaveCapSum
                )
            {
                if ( CurrentKeyID != null )
                {
                    bool SatelliteSvcFound = false;

                    foreach ( BO_Affiliation boAffil in CurrentAppProvider.BO_AffiliationsApplicationID )
                    {
                        if ( boAffil.UI_TrackID.Equals( CurrentKeyID ) )
                        {
                            //SMM 04/01/2012 - Added as indicator to know if temporary object created as a new affiliation
                            //should be commited to the database or discarded.
                            if ( boAffil.IsNewRec )
                                boAffil.NewRecCommitToDB = true;

                            if ( boAffil.BO_ServicesAffiliationID != null )
                            {
                                foreach ( BO_Service boSvc in boAffil.BO_ServicesAffiliationID )
                                {
                                    if ( boSvc.ServiceType.Equals( "4" ) || boSvc.ServiceType.Equals( "7" ) )
                                    {
                                        SatelliteSvcFound = true;
                                        break;
                                    }
                                }

                                /* replaced by drown down list used to select branch or satellite
                                if ( SatelliteSvcFound )
                                    boAffil.TypeAffiliation = "03";
                                else
                                    boAffil.TypeAffiliation = "02";
                                */
                            }
                        }
                    }
                }

                retVal = true;
            }
            else
            {
                retVal = false;
            }

            return retVal;
        }

        private void _LoadLicenseControls()
        {
            sldrProvInfoAffiliation.Visible = false;
            sldrSpecUnitsAffiliation.Visible = false;
            sldrRmBedsAffiliation.Visible = false;
            sldrServicesAffiliation.Visible = false;

            //if ( ( "HO,HC" ).Contains( CurrentAppProvider.ProgramID ) )
            //{
                sldrProvInfoAffiliation.Visible = true;
                _m_FacControl = (AplctnProvider) LoadControl( "~/AppControl/AplctnProvider.ascx" );
                FacilityDetailContent.Controls.Add( _m_FacControl );
                _m_FacControl.EnableViewState = true;
                _m_FacControl.ID = "FacilityDemographics";
                CurrentFacilityControlID = _m_FacControl.ID;
            //}

            if ( ( "HO" ).Contains( CurrentAppProvider.ProgramID ) )
            {
                sldrSpecUnitsAffiliation.Visible = true;
                _m_SpecUnitControl = (SpecialtyUnit) LoadControl( "~/AppControl/SpecialtyUnit.ascx" );
                SpecialtyUnitContent.Controls.Add( _m_SpecUnitControl );
                _m_SpecUnitControl.EnableViewState = true;
                _m_SpecUnitControl.ID = "SpecialtyUnits";
                CurrentSpecialtyUnitControlID = _m_SpecUnitControl.ID;
            }

            if ( ( "HO" ).Contains( CurrentAppProvider.ProgramID ) )
            {
                sldrRmBedsAffiliation.Visible = true;
                _m_BedSummaryControl = (HO_BedSummary) LoadControl( "~/AppControl/HO_BedSummary.ascx" );
                BedDetailContent.Controls.Add( _m_BedSummaryControl );
                _m_BedSummaryControl.EnableViewState = true;
                _m_BedSummaryControl.ID = "FacilityBeds";
                CurrentFacBedDetControlID = _m_BedSummaryControl.ID;
            }
            //SMM 05/21/2012 - Removed capacity info for HH and HP offsites
            //else if ( ( "HP,HH" ).Contains( CurrentAppProvider.ProgramID ) )
            //{
            //    sldrRmBedsAffiliation.Visible = true;
            //    _m_CapacitySummary = (GenericCapSumm) LoadControl( "~/AppControl/GenericCapSumm.ascx" );
            //    BedDetailContent.Controls.Add( _m_CapacitySummary );
            //    _m_CapacitySummary.EnableViewState = true;
            //    _m_CapacitySummary.ID = "FacilityCapacity";
            //    CurrentFacBedDetControlID = _m_CapacitySummary.ID;
            //}

            //SMM 05/21/2012 - Removed services for HH and HP offsites
            //if ( ( "HC,HP,HH" ).Contains( CurrentAppProvider.ProgramID ) )
            if ( ( "HC,SA" ).Contains( CurrentAppProvider.ProgramID ) )
            {
                sldrServicesAffiliation.Visible = true;
                _m_FacServiceControl = (Services) LoadControl( "~/AppControl/Services.ascx" );
                ServiceDetailContent.Controls.Add( _m_FacServiceControl );
                _m_FacServiceControl.EnableViewState = true;
                _m_FacServiceControl.ID = "FacilityBeds";
                CurrentFacServiceControlID = _m_FacServiceControl.ID;
            }
        }

        private BO_Application CurrentAppProvider
        {
            get
            {
                return Session["CurrentAppProvider"] == null ? null : (BO_Application) Session["CurrentAppProvider"];
            }
            set
            {
                Session["CurrentAppProvider"] = value;
            }
        }

        private string CurrentKeyID
        {
            get
            {
                return null != ViewState["CurrentKeyID"] ? (string) ViewState["CurrentKeyID"] : null;
            }
            set
            {
                ViewState["CurrentKeyID"] = value;
            }
        }
        
        public bool AllowEdit
        {
            get
            {
                return ( null != ViewState["AllowEdit"] ? (bool) ViewState["AllowEdit"] : false );
            }
            set
            {
                ViewState["AllowEdit"] = value;
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

        private string CurrentFacServiceControlID
        {
            get
            {
                return this.ViewState["CurrentFacServiceControlID"] == null ? string.Empty : (string) this.ViewState["CurrentFacServiceControlID"];
            }
            set
            {
                this.ViewState["CurrentFacServiceControlID"] = value;
            }
        }
    }
}