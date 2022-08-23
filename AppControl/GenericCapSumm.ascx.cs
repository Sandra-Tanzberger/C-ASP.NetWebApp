using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ATG;
using ATG.BusinessObject;
using Telerik.Web.UI;

namespace AppControl
{
    public partial class GenericCapSumm : System.Web.UI.UserControl
    {
        protected void Page_Load( object sender, EventArgs e )
        {
            RadAjaxManager manager = RadAjaxManager.GetCurrent( Page );
            manager.AjaxRequest += new RadAjaxControl.AjaxRequestDelegate( manager_AjaxRequest );
        }

        protected void manager_AjaxRequest( object sender, Telerik.Web.UI.AjaxRequestEventArgs e )
        {
            _UpdateCapacitySummary();
        }

        public void LoadCapacitySummary( string inKeyID, bool inAllowEdit, bool inIsOffsiteAffil )
        {
            int TotalLicCapacityCountMain = 0;
            int TotalLicCapacityCountOffsite = 0;
            
            AllowEdit = inAllowEdit;
            IsOffSite = inIsOffsiteAffil;
            CurrentAffiliationID = inKeyID;

            //Hide all controls by container and turn them back on by program id
            divBR_CapSumm.Visible = false;
            tblHP_NumberLicensedBeds.Visible = false;
            tblHP_NumberUnitRoomStations.Visible = false;
            tblHP_NumCurActivePatients.Visible = false;
            divAC_CapSumm.Visible = false;
            divHP_CapSumm.Visible = false;
            divWA_CapSumm.Visible = false;
            divSA_CapSumm.Visible = false;
            divMR_CapSumm.Visible = false;
            divNH_CapSumm.Visible = false;
            divPT_CapSumm.Visible = false;
            divTG_CapSumm.Visible = false;

            if ( null != CurrentAppProvider )
            {
                switch( CurrentAppProvider.ProgramID )
                {
                    case "BR":
                        if ( !IsOffSite )
                        {
                            if ( null != CurrentAppProvider.BO_ServicesApplicationID )
                            {
                                foreach ( BO_Service tmpSvc in CurrentAppProvider.BO_ServicesApplicationID )
                                {
                                    if ( tmpSvc.ServiceType.Equals( "01" ) )
                                        TotalLicCapacityCountMain += tmpSvc.Capacity.Value;
                                }
                            }

                            if ( null != CurrentAppProvider.BO_AffiliationsApplicationID )
                            {
                                foreach ( BO_Affiliation tmpAffil in CurrentAppProvider.BO_AffiliationsApplicationID )
                                {
                                    if ( null != tmpAffil.BO_ServicesAffiliationID )
                                    {
                                        foreach ( BO_Service tmpSvcAffil in tmpAffil.BO_ServicesAffiliationID )
                                        {
                                            if ( tmpSvcAffil.ServiceType.Equals( "01" ) )
                                                TotalLicCapacityCountOffsite += tmpSvcAffil.Capacity.Value;
                                        }
                                    }
                                }
                            }

                            divBR_CapSumm.Visible = true;
                            txtTotalLicCapacity_BR.Text = ( TotalLicCapacityCountMain + TotalLicCapacityCountOffsite ).ToString();
                        }                        
                        break;
                    case "HP":
                        divHP_CapSumm.Visible = true;
                        if ( IsOffSite )
                        {
                            foreach ( BO_Affiliation tmpAffil in CurrentAppProvider.BO_AffiliationsApplicationID )
                            {
                                if ( tmpAffil.UI_TrackID.Equals( CurrentAffiliationID ) )
                                {
                                    tblHP_NumberLicensedBeds.Visible = true;
                                    tblHP_NumberUnitRoomStations.Visible = true;

                                    //SMM 06/12/2012 - Active for the main provider not shown for offsites
                                    txtHP_NumCurActivePatients.Enabled = false;
                                    tblHP_NumCurActivePatients.Visible = false;

                                    if ( null != tmpAffil.NumberOfBeds && tmpAffil.NumberOfBeds > 0 )
                                        txtHP_NumberLicensedBeds.Text = tmpAffil.NumberOfBeds.Value.ToString();
                                    if ( null != tmpAffil.Unit && tmpAffil.Unit > 0 )
                                        txtHP_NumberUnitRoomStations.Text = tmpAffil.Unit.Value.ToString();
                                    //SMM 06/12/2012 - Active for the main provider not shown for offsites
                                    //if ( null != tmpAffil.NumActivePatients && tmpAffil.NumActivePatients > 0 )
                                    //    txtHP_NumCurActivePatients.Text = tmpAffil.NumActivePatients.Value.ToString();
                                }
                            }
                        }
                        else
                        {
                            tblHP_NumberLicensedBeds.Visible = true;
                            tblHP_NumberUnitRoomStations.Visible = true;
                            tblHP_NumCurActivePatients.Visible = true;
                            txtHP_NumberLicensedBeds.Enabled = false;
                            txtHP_NumberUnitRoomStations.Enabled = false;
                            //SMM 06/12/2012 - Active for the main provider not shown for offsites
                            //txtHP_NumCurActivePatients.Enabled = false;

                            if ( null != CurrentAppProvider.TotalLicBedsTotal && CurrentAppProvider.TotalLicBedsTotal > 0 )
                                txtHP_NumberLicensedBeds.Text = CurrentAppProvider.TotalLicBedsTotal.Value.ToString();
                            if ( null != CurrentAppProvider.UnitsNumTotal && CurrentAppProvider.UnitsNumTotal > 0 )
                                txtHP_NumberUnitRoomStations.Text = CurrentAppProvider.UnitsNumTotal.Value.ToString();
                            if ( null != CurrentAppProvider.NumActivePatients && CurrentAppProvider.NumActivePatients > 0 )
                                txtHP_NumCurActivePatients.Text = CurrentAppProvider.NumActivePatients.Value.ToString();

                        }
                        break;
                    case "HH":
                        if ( IsOffSite )
                        {
                            divHP_CapSumm.Visible = false;
                            //SMM 05/18/2012 - Removed per Offsite Application review
                            //foreach ( BO_Affiliation tmpAffil in CurrentAppProvider.BO_AffiliationsApplicationID )
                            //{
                            //    if ( tmpAffil.UI_TrackID.Equals( CurrentAffiliationID ) )
                            //    {
                            //        tblHP_NumberLicensedBeds.Visible = true;
                            //        tblHP_NumberUnitRoomStations.Visible = false;
                            //        tblHP_NumCurActivePatients.Visible = true;

                            //        if ( null != tmpAffil.NumberOfBeds && tmpAffil.NumberOfBeds > 0 )
                            //            txtHP_NumberLicensedBeds.Text = tmpAffil.NumberOfBeds.Value.ToString();
                            //        if ( null != tmpAffil.NumActivePatients && tmpAffil.NumActivePatients > 0 )
                            //            txtHP_NumCurActivePatients.Text = tmpAffil.NumActivePatients.Value.ToString();
                            //    }
                            //}
                        }
                        else
                        {
                            divHP_CapSumm.Visible = true;
                            tblHP_NumberLicensedBeds.Visible = false;
                            tblHP_NumberUnitRoomStations.Visible = false;
                            tblHP_NumCurActivePatients.Visible = true;
                            //txtHP_NumberLicensedBeds.Enabled = false;
                            //txtHP_NumCurActivePatients.Enabled = false;

                            //if ( null != CurrentAppProvider.NumberOfBeds && CurrentAppProvider.NumberOfBeds > 0 )
                            //    txtHP_NumberLicensedBeds.Text = CurrentAppProvider.NumberOfBeds.Value.ToString();
                            if ( null != CurrentAppProvider.NumActivePatients && CurrentAppProvider.NumActivePatients > 0 )
                                txtHP_NumCurActivePatients.Text = CurrentAppProvider.NumActivePatients.Value.ToString();

                        }
                        break;
                    case "FF":
                        divHP_CapSumm.Visible = true;
                        if ( !IsOffSite )
                        {
                            tblHP_NumberLicensedBeds.Visible = true;
                            tblHP_NumberUnitRoomStations.Visible = true;
                            tblHP_NumCurActivePatients.Visible = true;
                            
                            if ( null != CurrentAppProvider.TotalLicBedsTotal && CurrentAppProvider.TotalLicBedsTotal > 0 )
                                txtHP_NumberLicensedBeds.Text = CurrentAppProvider.TotalLicBedsTotal.Value.ToString();
                            if ( null != CurrentAppProvider.UnitsNumTotal && CurrentAppProvider.UnitsNumTotal > 0 )
                                txtHP_NumberUnitRoomStations.Text = CurrentAppProvider.UnitsNumTotal.Value.ToString();
                            if ( null != CurrentAppProvider.NumActivePatients && CurrentAppProvider.NumActivePatients > 0 )
                                txtHP_NumCurActivePatients.Text = CurrentAppProvider.NumActivePatients.Value.ToString();

                        }
                        break;
                    case "AC":
                        divAC_CapSumm.Visible = true;
                        if ( !IsOffSite )
                        {
                            if ( null != CurrentAppProvider.Unit && CurrentAppProvider.Unit > 0 )
                                txtAC_NumLicUnit.Text = CurrentAppProvider.Unit.Value.ToString();
                            if ( null != CurrentAppProvider.Capacity && CurrentAppProvider.Capacity > 0 )
                                txtAC_TotalCapacity.Text = CurrentAppProvider.Capacity.Value.ToString();
                        }
                        break;
                    case "WA":
                        divWA_CapSumm.Visible = true;
                        if ( !IsOffSite )
                        {
                            if ( null != CurrentAppProvider.Capacity && CurrentAppProvider.Capacity > 0 )
                                txtWA_LicensedCapacity.Text = CurrentAppProvider.Capacity.Value.ToString();
                            if ( null != CurrentAppProvider.CapacityProvTotal && CurrentAppProvider.CapacityProvTotal > 0 )
                                txtWA_PresentCapacity.Text = CurrentAppProvider.CapacityProvTotal.Value.ToString();

                            if ( !CurrentAppProvider.BusinessProcessID.Equals( "2" ) && !CurrentAppProvider.BusinessProcessID.Equals( "7" ) )
                                txtWA_LicensedCapacity.Enabled = false;
                        }
                        break;
                    case "SA":
                        divSA_CapSumm.Visible = true;
                        if ( !IsOffSite )
                        {
                            if ( null != CurrentAppProvider.Unit && CurrentAppProvider.Unit > 0 )
                                txtSA_NumLicUnit.Text = CurrentAppProvider.Unit.Value.ToString();
                            if ( null != CurrentAppProvider.NumberOfBeds && CurrentAppProvider.NumberOfBeds > 0 )
                                txtSA_NumLicBeds.Text = CurrentAppProvider.NumberOfBeds.Value.ToString();
                        }
                        break;
                    case "MR":
                        divMR_CapSumm.Visible = true;
                        if (!IsOffSite) {
                            if (null != CurrentAppProvider.Unit && CurrentAppProvider.Unit > 0)
                                txtMR_NumLicBedrooms.Text = CurrentAppProvider.Unit.Value.ToString();
                            if (null != CurrentAppProvider.NumberOfBeds && CurrentAppProvider.NumberOfBeds > 0)
                                txtMR_NumLicBeds.Text = CurrentAppProvider.NumberOfBeds.Value.ToString();
                            if (null != CurrentAppProvider.BedsCertified && CurrentAppProvider.BedsCertified > 0)
                                txtMR_NumCertBeds.Text = CurrentAppProvider.BedsCertified.Value.ToString();
                        }
                        break;
                    case "NH":
                        divNH_CapSumm.Visible = true;
                        if (!IsOffSite) {
                            if (null != CurrentAppProvider.Unit && CurrentAppProvider.Unit > 0)
                                txtNH_NumLicUnits.Text = CurrentAppProvider.Unit.Value.ToString();
                            if (null != CurrentAppProvider.TotalLicBeds && CurrentAppProvider.TotalLicBeds > 0)
                                txtNH_NumLicBeds.Text = CurrentAppProvider.TotalLicBeds.Value.ToString();
                            //if (null != CurrentAppProvider.NumberOfBeds && CurrentAppProvider.NumberOfBeds > 0)
                                //txtNH_NumLicBeds.Text = CurrentAppProvider.TotalLicBeds.NumberOfBeds.Value.ToString();
                            if (null != CurrentAppProvider.BedsCertified && CurrentAppProvider.BedsCertified > 0)
                                txtNH_NumCertBeds.Text = CurrentAppProvider.BedsCertified.Value.ToString();
                            if (null != CurrentAppProvider.Snf18beds && CurrentAppProvider.Snf18beds > 0)
                                txtNH_NumTitle18.Text = CurrentAppProvider.Snf18beds.Value.ToString();
                            if (null != CurrentAppProvider.Snf1819beds && CurrentAppProvider.Snf1819beds > 0)
                                txtNH_NumTitle1819.Text = CurrentAppProvider.Snf1819beds.Value.ToString();
                            if (null != CurrentAppProvider.Snf19beds && CurrentAppProvider.Snf19beds > 0)
                                txtNH_NumTitle19.Text = CurrentAppProvider.Snf19beds.Value.ToString();
                        }
                        break;
                    case "PT":
                        divPT_CapSumm.Visible = true;
                        if (!IsOffSite)
                        {
                            if (null != CurrentAppProvider.Unit && CurrentAppProvider.Unit > 0)
                                txtPT_NumLicUnit.Text = CurrentAppProvider.Unit.Value.ToString();
                            if (null != CurrentAppProvider.NumberOfBeds && CurrentAppProvider.NumberOfBeds > 0)
                                txtPT_NumLicBeds.Text = CurrentAppProvider.NumberOfBeds.Value.ToString();
                        }
                        break;
                    case "TG":
                        divTG_CapSumm.Visible = true;
                        if (!IsOffSite)
                        {
                            if (null != CurrentAppProvider.Unit && CurrentAppProvider.Unit > 0)
                                txtTG_NumLicUnit.Text = CurrentAppProvider.Unit.Value.ToString();
                            if (null != CurrentAppProvider.NumberOfBeds && CurrentAppProvider.NumberOfBeds > 0)
                                txtTG_NumLicBeds.Text = CurrentAppProvider.NumberOfBeds.Value.ToString();
                        }
                        break;
                }
                if ( !AllowEdit )
                {
                    txtTotalLicCapacity_BR.Enabled = false;
                    txtHP_NumberLicensedBeds.Enabled = false;
                    txtHP_NumberUnitRoomStations.Enabled = false;
                    txtHP_NumCurActivePatients.Enabled = false;
                    txtAC_TotalCapacity.Enabled = false;
                    txtAC_NumLicUnit.Enabled = false;
                    txtWA_LicensedCapacity.Enabled = false;
                    txtWA_PresentCapacity.Enabled = false;
                    txtSA_NumLicBeds.Enabled = false;
                    txtSA_NumLicUnit.Enabled = false;
                    txtMR_NumLicBedrooms.Enabled = false;
                    txtMR_NumLicBeds.Enabled = false;
                    txtMR_NumCertBeds.Enabled = false;
                    txtNH_NumLicUnits.Enabled = false;
                    txtNH_NumLicBeds.Enabled = false;
                    txtNH_NumCertBeds.Enabled = false;
                    txtNH_NumTitle18.Enabled = false;
                    txtNH_NumTitle1819.Enabled = false;
                    txtNH_NumTitle19.Enabled = false;
                    txtPT_NumLicBeds.Enabled = false;
                    txtPT_NumLicUnit.Enabled = false;
                    txtTG_NumLicBeds.Enabled = false;
                    txtTG_NumLicUnit.Enabled = false;
                }
            }
            
            
        }

        public bool SaveData()
        {
            bool noSaveError = true;
            string validationErrors = "";

            if ( CurrentAppProvider != null )
            {
                //noSaveError = _DoValidate();
                switch ( CurrentAppProvider.ProgramID )
                {
                    case "BR":
                        break;
                    case "HP":
                        if ( IsOffSite )
                        {
                            int totOffsiteBeds = 0;
                            int totOffsiteUnits = 0;

                            foreach ( BO_Affiliation tmpAffil in CurrentAppProvider.BO_AffiliationsApplicationID )
                            {
                                if ( tmpAffil.UI_TrackID.Equals( CurrentAffiliationID ) )
                                {
                                    int tmpArgPlaceHolder = 0;
                                    tmpAffil.NumberOfBeds = Int32.TryParse( txtHP_NumberLicensedBeds.Text, out tmpArgPlaceHolder ) ? Convert.ToInt32( txtHP_NumberLicensedBeds.Text ) : 0;
                                    tmpAffil.Unit = Int32.TryParse( txtHP_NumberUnitRoomStations.Text, out tmpArgPlaceHolder ) ? Convert.ToInt32( txtHP_NumberUnitRoomStations.Text ) : 0;
                                    //SMM 06/12/2012 - Not captured for offsites
                                    //tmpAffil.NumActivePatients = Int32.TryParse( txtHP_NumCurActivePatients.Text, out tmpArgPlaceHolder ) ? Convert.ToInt32( txtHP_NumCurActivePatients.Text ) : 0;
                                    //Sum totals for main campus
                                    totOffsiteBeds += tmpAffil.NumberOfBeds.Value;
                                    totOffsiteUnits += tmpAffil.Unit.Value;
                                }
                            }
                            CurrentAppProvider.TotalLicBedsTotal = totOffsiteBeds;
                            CurrentAppProvider.UnitsNumTotal = totOffsiteUnits;
                        }
                        else
                        {
                            //SMM 06/12/2012 - Captured for main provider
                            int tmpArgPlaceHolder = 0;
                            CurrentAppProvider.NumActivePatients = Int32.TryParse( txtHP_NumCurActivePatients.Text, out tmpArgPlaceHolder ) ? Convert.ToInt32( txtHP_NumCurActivePatients.Text ) : 0;
                        }
                        break;
                    case "HH":
                        if ( IsOffSite )
                        {
                            //SMM 05/18/2012 - Removed per Offsite Application review
                            //foreach ( BO_Affiliation tmpAffil in CurrentAppProvider.BO_AffiliationsApplicationID )
                            //{
                            //    if ( tmpAffil.UI_TrackID.Equals( CurrentAffiliationID ) )
                            //    {
                            //        int tmpArgPlaceHolder = 0;
                            //        tmpAffil.NumberOfBeds = Int32.TryParse( txtHP_NumberLicensedBeds.Text, out tmpArgPlaceHolder ) ? Convert.ToInt32( txtHP_NumberLicensedBeds.Text ) : 0;
                            //        tmpAffil.NumActivePatients = Int32.TryParse( txtHP_NumCurActivePatients.Text, out tmpArgPlaceHolder ) ? Convert.ToInt32( txtHP_NumCurActivePatients.Text ) : 0;
                            //    }
                            //}
                        }
                        else
                        {
                            int tmpArgPlaceHolder = 0;
                            //SMM 05/18/2012 - Removed per Offsite Application review
                            //CurrentAppProvider.NumberOfBeds = Int32.TryParse( txtHP_NumberLicensedBeds.Text, out tmpArgPlaceHolder ) ? Convert.ToInt32( txtHP_NumberLicensedBeds.Text ) : 0;
                            CurrentAppProvider.NumActivePatients = Int32.TryParse( txtHP_NumCurActivePatients.Text, out tmpArgPlaceHolder ) ? Convert.ToInt32( txtHP_NumCurActivePatients.Text ) : 0;
                        }
                        break;
                    case "FF":
                        if ( !IsOffSite )
                        {
                            int tmpArgPlaceHolder = 0;
                            CurrentAppProvider.TotalLicBedsTotal = Int32.TryParse( txtHP_NumberLicensedBeds.Text, out tmpArgPlaceHolder ) ? Convert.ToInt32( txtHP_NumberLicensedBeds.Text ) : 0;
                            CurrentAppProvider.UnitsNumTotal = Int32.TryParse( txtHP_NumberUnitRoomStations.Text, out tmpArgPlaceHolder ) ? Convert.ToInt32( txtHP_NumberUnitRoomStations.Text ) : 0;
                            CurrentAppProvider.NumActivePatients = Int32.TryParse( txtHP_NumCurActivePatients.Text, out tmpArgPlaceHolder ) ? Convert.ToInt32( txtHP_NumCurActivePatients.Text ) : 0;                            
                        }
                        break;
                    case "AC":
                        if ( !IsOffSite )
                        {
                            int tmpArgPlaceHolder = 0;
                            CurrentAppProvider.Unit = Int32.TryParse( txtAC_NumLicUnit.Text, out tmpArgPlaceHolder ) ? Convert.ToInt32( txtAC_NumLicUnit.Text ) : 0;
                            CurrentAppProvider.Capacity = Int32.TryParse( txtAC_TotalCapacity.Text, out tmpArgPlaceHolder ) ? Convert.ToInt32( txtAC_TotalCapacity.Text ) : 0;
                        }
                        break;
                    case "WA":
                        if ( !IsOffSite )
                        {
                            int tmpArgPlaceHolder = 0;
                            CurrentAppProvider.CapacityProvTotal = Int32.TryParse( txtWA_PresentCapacity.Text, out tmpArgPlaceHolder ) ? Convert.ToInt32( txtWA_PresentCapacity.Text ) : 0;
                            CurrentAppProvider.Capacity = Int32.TryParse( txtWA_LicensedCapacity.Text, out tmpArgPlaceHolder ) ? Convert.ToInt32( txtWA_LicensedCapacity.Text ) : 0;
                        }
                        break;
                    case "SA":
                        if ( !IsOffSite )
                        {
                            int tmpArgPlaceHolder = 0;
                            CurrentAppProvider.Unit = Int32.TryParse( txtSA_NumLicUnit.Text, out tmpArgPlaceHolder ) ? Convert.ToInt32( txtSA_NumLicUnit.Text ) : 0;
                            CurrentAppProvider.NumberOfBeds = Int32.TryParse( txtSA_NumLicBeds.Text, out tmpArgPlaceHolder ) ? Convert.ToInt32( txtSA_NumLicBeds.Text ) : 0;
                        }
                        break;
                    case "MR":
                        if (!IsOffSite) {
                            int tmpArgPlaceHolder = 0;
                            int tmpUnits = Int32.TryParse(txtMR_NumLicBedrooms.Text, out tmpArgPlaceHolder) ? Convert.ToInt32(txtMR_NumLicBedrooms.Text) : 0;
                            int tmpNumBeds = Int32.TryParse(txtMR_NumLicBeds.Text, out tmpArgPlaceHolder) ? Convert.ToInt32(txtMR_NumLicBeds.Text) : 0;
                            int tmpCertBeds = Int32.TryParse(txtMR_NumCertBeds.Text, out tmpArgPlaceHolder) ? Convert.ToInt32(txtMR_NumCertBeds.Text) : 0;
                            // can only decrease if business process is change of beds
                            if (!CurrentAppProvider.BusinessProcessID.Equals("7")
                                && ((tmpUnits < CurrentAppProvider.Unit)
                                    || (tmpNumBeds < CurrentAppProvider.NumberOfBeds)
                                    || (tmpCertBeds < CurrentAppProvider.BedsCertified))
                            ) {
                                validationErrors += "Provider may not decrease beds except during a Capacity Change process.";
                                noSaveError = false;
                            }
                            else {
                                CurrentAppProvider.Unit = tmpUnits;
                                CurrentAppProvider.NumberOfBeds = tmpNumBeds;
                                CurrentAppProvider.BedsCertified = tmpCertBeds;
                            }
                        }
                        break;
                    case "NH":
                        if (!IsOffSite) {
                            int tmpArgPlaceHolder = 0;
                            int tmpUnits = Int32.TryParse(txtNH_NumLicUnits.Text, out tmpArgPlaceHolder) ? Convert.ToInt32(txtNH_NumLicUnits.Text) : 0;
                            int tmpNumBeds = Int32.TryParse(txtNH_NumLicBeds.Text, out tmpArgPlaceHolder) ? Convert.ToInt32(txtNH_NumLicBeds.Text) : 0;
                            int tmpCertBeds = Int32.TryParse(txtNH_NumCertBeds.Text, out tmpArgPlaceHolder) ? Convert.ToInt32(txtNH_NumCertBeds.Text) : 0;
                            int tmp18Beds = Int32.TryParse(txtNH_NumTitle18.Text, out tmpArgPlaceHolder) ? Convert.ToInt32(txtNH_NumTitle18.Text) : 0;
                            int tmp1819Beds = Int32.TryParse(txtNH_NumTitle1819.Text, out tmpArgPlaceHolder) ? Convert.ToInt32(txtNH_NumTitle1819.Text) : 0;
                            int tmp19Beds = Int32.TryParse(txtNH_NumTitle19.Text, out tmpArgPlaceHolder) ? Convert.ToInt32(txtNH_NumTitle19.Text) : 0;
                            // can only decrease if business process is change of beds
                            if (!CurrentAppProvider.BusinessProcessID.Equals("7")
                                && ((tmpUnits < CurrentAppProvider.Unit)
                                    || (tmpNumBeds < CurrentAppProvider.TotalLicBeds)
                                    || (tmpCertBeds < CurrentAppProvider.BedsCertified)
//                                || (tmpNumBeds < CurrentAppProvider.NumberOfBeds)
//                                //|| (tmpCertBeds < CurrentAppProvider.BedsCertified)
//                                || (tmpCertBeds < CurrentAppProvider.TotalLicBeds)
                                    || (tmp18Beds < CurrentAppProvider.Snf18beds)
                                    || (tmp1819Beds < CurrentAppProvider.Snf1819beds)
                                    || (tmp19Beds < CurrentAppProvider.Snf19beds))
                            ) {
                                //validationErrors += "Provider may not decrease beds during renewal process.";
                                validationErrors += "Provider may not decrease beds except during a Capacity Change process.";
                                noSaveError = false;
                            }
                            else {
                                CurrentAppProvider.Unit = tmpUnits;
                                //CurrentAppProvider.NumberOfBeds = tmpNumBeds;
                                CurrentAppProvider.TotalLicBeds = tmpNumBeds;
                                CurrentAppProvider.BedsCertified = tmpCertBeds;
                                CurrentAppProvider.Snf18beds = tmp18Beds;
                                CurrentAppProvider.Snf1819beds = tmp1819Beds;
                                CurrentAppProvider.Snf19beds = tmp19Beds;
                            }
                        }
                        break;
                    case "PT":
                        if (!IsOffSite)
                        {
                            int tmpArgPlaceHolder = 0;
                            CurrentAppProvider.Unit = Int32.TryParse(txtPT_NumLicUnit.Text, out tmpArgPlaceHolder) ? Convert.ToInt32(txtPT_NumLicUnit.Text) : 0;
                            CurrentAppProvider.NumberOfBeds = Int32.TryParse(txtPT_NumLicBeds.Text, out tmpArgPlaceHolder) ? Convert.ToInt32(txtPT_NumLicBeds.Text) : 0;
                        }
                        break;
                    case "TG":
                        if (!IsOffSite)
                        {
                            int tmpArgPlaceHolder = 0;
                            CurrentAppProvider.Unit = Int32.TryParse(txtTG_NumLicUnit.Text, out tmpArgPlaceHolder) ? Convert.ToInt32(txtTG_NumLicUnit.Text) : 0;
                            CurrentAppProvider.NumberOfBeds = Int32.TryParse(txtTG_NumLicBeds.Text, out tmpArgPlaceHolder) ? Convert.ToInt32(txtTG_NumLicBeds.Text) : 0;
                        }
                        break;
                }

                ErrorText.Visible = !noSaveError;
                ErrorText.InnerHtml = validationErrors;
            }

            return noSaveError;
        }

        private void _UpdateCapacitySummary()
        {
            txtTotalLicCapacity_BR.Text = DateTime.Now.ToShortDateString();
        }

        private BO_Application CurrentAppProvider
        {
            get            {
                return (BO_Application) Session["CurrentAppProvider"];
            }
            set
            {
                Session["CurrentAppProvider"] = value;
            }
        }

        private string CurrentAffiliationID
        {
            get
            {
                return ( ViewState["CurrentAffiliationID"] != null ? (string) ViewState["CurrentAffiliationID"] : null );
            }
            set
            {
                ViewState["CurrentAffiliationID"] = value;
            }
        }

        private bool IsOffSite
        {
            get
            {
                return ( ViewState["IsOffSite"] != null ? (bool) ViewState["IsOffSite"] : false );
            }
            set
            {
                ViewState["IsOffSite"] = value;
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

    }
}