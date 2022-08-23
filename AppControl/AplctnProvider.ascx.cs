using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ATG;
using ATG.BusinessObject;
using Telerik.Web.UI;
using ATG.Security;

namespace AppControl
{
    public partial class AplctnProvider : System.Web.UI.UserControl
    {
        protected override void OnInit( EventArgs e )
        {
            base.OnInit( e );
        }

        protected void Page_Load( object sender, EventArgs e )
        {
        }

        public void LoadApplication( string inKeyID, bool inAllowEdit, bool inIsOffsiteAffil )
        {
            BO_Application tmpAppProvider = null;
            BO_Affiliation tmpAffiliation = null;

            IsOffSite = inIsOffsiteAffil;
            AllowEdit = inAllowEdit;

            if ( inKeyID != null )
            {
                if ( !IsOffSite )
                {
                    tmpAppProvider = new BO_Application();
                    tmpAppProvider.LoadFullApplication( Convert.ToDecimal( inKeyID ) );

                    if ( tmpAppProvider.ApplicationID != null )
                    {
                        CurrentAppProvider = tmpAppProvider;
                        _InitFields();
                    }
                    else
                    {
                        CurrentAppProvider = null;
                    }
                }
                else
                {
                    bool AffiliationFound = false;

                    CurrentAffiliationID = inKeyID;

                    if ( null != CurrentAppProvider.BO_AffiliationsApplicationID )
                    {
                        foreach ( BO_Affiliation tmpBA in CurrentAppProvider.BO_AffiliationsApplicationID )
                        {
                            if ( tmpBA.UI_TrackID.Equals( CurrentAffiliationID ) )
                            {
                                tmpAffiliation = tmpBA;
                                _InitFields();
                                AffiliationFound = true;
                                break;
                            }
                        }
                    }

                    if ( !AffiliationFound )
                    {
                        BO_Program tmpPgm = BO_Program.SelectOne( new BO_ProgramPrimaryKey( CurrentAppProvider.ProgramID ) );
                        ProviderType.Text = tmpPgm.ProgramDescription;
                        _LoadSelectLists();
                    }
                }
            }

            if (!IsOffSite)
            {
                getRegionFieldOffice();
            }

            _ShowHideFields();


            if (User.HasAccess("PBG"))
            {
                listProvStatus.Enabled = true;
                txtProvStatusDate.Enabled = true;
                txtProvClosedDate.Enabled = true;

                //aco sync replacement functionality to allow status change
                //tmpSaveAffiliation.StateCode = 
                listBranchStatus.Enabled = true;
                //tmpSaveAffiliation.OpenedDate = 
                txtBranchOpenDate.Enabled= true;
                //tmpSaveAffiliation.ClosedDate = 
                txtBranchClosedDate.Enabled = true;
            }
        }

        public bool SaveData()
        {
            bool noSaveError = true;

            if ( !IsOffSite )
            {
                if ( CurrentAppProvider != null )
                {
                    //hack - code added for new print functionality to allow new licenses to be created when application is saved rather than old logic which required license to be printed to generate license number
                    //check for new license process and create new license num
                    if(CurrentAppProvider.ApplicationStatus == "4")
                        if(!"NE".Contains(CurrentAppProvider.ProgramID))
                            NewLic();

                    noSaveError = _DoValidate();

                    if ( noSaveError )
                    {
                        CurrentAppProvider.FacilityName = FacilityName.Text;
                        CurrentAppProvider.TelephoneNumber = FacilityAdministrationPhone.Text;
                        CurrentAppProvider.FaxPhoneNumber = FacilityAdministrationFax.Text;
                        CurrentAppProvider.EmailAddress = txtAdminEmail.Text;
                        CurrentAppProvider.FiscalIntermediaryNum = listFiscalInt.SelectedValue;
                        CurrentAppProvider.FiscalIntermediaryDesc = listFiscalInt.SelectedItem != null ? listFiscalInt.SelectedItem.Text : null;
                        CurrentAppProvider.AccreditedBody = listAccrdBody.SelectedValue;
                        CurrentAppProvider.ForYearEndingDate = txtFiscalYrEnd.Text;
                        //string tmpStr = dtFiscalYrEnd.SelectedDate.ToString();
                        CurrentAppProvider.AccreditationExpirationDate = calAccrdExpDt.SelectedDate;

                        //aco sync replacement - ST - 11012019
                        CurrentAppProvider.StatusCode = listProvStatus.SelectedValue;
                        CurrentAppProvider.StatusDate = txtProvStatusDate.SelectedDate;
                        CurrentAppProvider.ClosedDate = txtProvClosedDate.SelectedDate;

                        /* removed for release 12.5
                        //save application support table
                        if ("AC,PD,HC,HP".Contains(CurrentAppProvider.ProgramID.ToString()))
                        {
                            CurrentAppProvider.Application_Support.FnrApprovalDate = dpFNRApprovalDate.SelectedDate;
                        }
                        */

                        if (chkRegionFieldOfficeOverride.Checked)
                        {
                            CurrentAppProvider.RegionalOffice = "override";
                            //set Region and Field Office from override if fields aren't empty.
                            if (listDHHAdminRegion.SelectedValue != String.Empty)
                                CurrentAppProvider.RegionCode = listDHHAdminRegion.SelectedValue;
                            if (listHSSFieldOffice.SelectedValue != String.Empty)
                                CurrentAppProvider.FieldOfficeCode = listHSSFieldOffice.SelectedValue;
                        }
                        else
                        {
                            CurrentAppProvider.RegionCode = BO_Parishe.SelectByField("PARISH_CODE", listProviderParish.SelectedValue)[0].DhhAdminRegion.ToString();
                            CurrentAppProvider.FieldOfficeCode = BO_Parishe.SelectByField("PARISH_CODE", listProviderParish.SelectedValue)[0].HssFieldOffice.ToString(); ;
                        }

                        if ("NA".Contains(CurrentAppProvider.ProgramID))//manual ovrride for license num/state code allowed
                        {
                            CurrentAppProvider.LicensureNum = LicenseNum.Text;
                        }

                        if ("HO,NA".Contains(CurrentAppProvider.ProgramID))
                        {
                            CurrentAppProvider.TypeFacility = optFactype.SelectedValue;
                            CurrentAppProvider.FacilityWithinFacilityYN = DdlFacilityInFacilityYN.SelectedValue;
                            CurrentAppProvider.FacilityWithinFacility = TextBoxFacilityInFacility.Text;
                        }
                        else
                            CurrentAppProvider.TypeFacility = listHP_ProviderType.SelectedValue;

                        

                        if ( CurrentAppAddressList.Count > 0 )
                        {
                            bool geoFound = false;
                            bool mailFound = false;

                            foreach ( BO_Address addr in CurrentAppAddressList )
                            {
                                if ( addr.AddressType == 1 )
                                {
                                    geoFound = true;
                                    addr.Street = FacilityGeoStreetAddress.Text;
                                    addr.City = listProviderCity.SelectedValue;
                                    addr.StateCode = listProviderState.SelectedValue;
                                    addr.State = listProviderState.SelectedValue;
                                    addr.ZipCode = listProviderZip.SelectedValue;
                                    addr.ParishCode = listProviderParish.SelectedValue;
                                    //addr.Update();
                                }
                                else if ( addr.AddressType == 2 )
                                {
                                    mailFound = true;
                                    addr.Street = MailStreetPOBox.Text.ToUpper();
                                    addr.City = listMailCity.SelectedValue;
                                    addr.StateCode = listMailState.SelectedValue;
                                    addr.State = listMailState.Text;
                                    addr.ZipCode = listMailZip.SelectedValue;
                                    addr.ZipCodeExtended = MailZipExtn.Text;
                                    //addr.Update();
                                }
                            }

                            if ( !geoFound )
                            {
                                BO_Address tmpGeoAddr = new BO_Address();

                                tmpGeoAddr.PopsIntID = CurrentAppProvider.PopsIntID;
                                tmpGeoAddr.ApplicationID = CurrentAppProvider.ApplicationID;
                                tmpGeoAddr.AddressType = 1;
                                tmpGeoAddr.Street = FacilityGeoStreetAddress.Text;
                                tmpGeoAddr.StateCode = listProviderState.SelectedValue;
                                tmpGeoAddr.State = listProviderState.SelectedValue;
                                tmpGeoAddr.City = listProviderCity.SelectedValue;
                                tmpGeoAddr.ParishCode = listProviderParish.SelectedValue;
                                tmpGeoAddr.ZipCode = listProviderZip.SelectedValue;
                                tmpGeoAddr.ZipCodeExtended = ProviderZipExtn.Text;
                                
                                //tmpGeoAddr.Insert();
                                CurrentAppAddressList.Add( tmpGeoAddr );
                            }

                            if ( !mailFound )
                            {
                                BO_Address tmpMailAddr = new BO_Address();

                                tmpMailAddr.PopsIntID = CurrentAppProvider.PopsIntID;
                                tmpMailAddr.ApplicationID = CurrentAppProvider.ApplicationID;
                                tmpMailAddr.AddressType = 2;
                                tmpMailAddr.Street = MailStreetPOBox.Text;
                                tmpMailAddr.City = listMailCity.SelectedValue;
                                tmpMailAddr.StateCode = listMailState.SelectedValue;
                                tmpMailAddr.State = listMailState.Text;
                                tmpMailAddr.ZipCode = listMailZip.SelectedValue;
                                tmpMailAddr.ZipCodeExtended = MailZipExtn.Text;
                                //tmpMailAddr.Insert();
                                CurrentAppAddressList.Add( tmpMailAddr );

                            }
                        }

                        if ( CurrentAppProvider.ProgramID.Equals( "HC" ) )
                        {
                            CurrentAppProvider.DeemedStatus = chkStatusAccred.Checked ? "1" : "0" ;

                            if ( optPopSrvBoth.Checked )
                                CurrentAppProvider.TypeOfClients = "8";
                            else if ( optPopSrvMale.Checked )
                                CurrentAppProvider.TypeOfClients = "6";
                            else if ( optPopSrvFemale.Checked )
                                CurrentAppProvider.TypeOfClients = "7";
                            else
                                CurrentAppProvider.TypeOfClients = null;

                            CurrentAppProvider.AgeRangeFrom = txtAgeFrom.Text.Length > 0 ? Convert.ToInt16( txtAgeFrom.Text ) : 0 ;
                            CurrentAppProvider.AgeRangeTO = txtAgeTo.Text.Length > 0 ? Convert.ToInt16( txtAgeTo.Text ) : 0 ;
                            CurrentAppProvider.AccreditedBody = listAccrdBody.SelectedValue;
                            CurrentAppProvider.AccreditationExpirationDate = calAccrdExpDt.SelectedDate;
                        }

                        if ( CurrentAppProvider.ProgramID.Equals( "BR" ) )
                        {
                            if ( optPopSrvBoth.Checked )
                                CurrentAppProvider.TypeOfClients = "8";
                            else if ( optPopSrvMale.Checked )
                                CurrentAppProvider.TypeOfClients = "6";
                            else if ( optPopSrvFemale.Checked )
                                CurrentAppProvider.TypeOfClients = "7";
                            else
                                CurrentAppProvider.TypeOfClients = null;

                            CurrentAppProvider.AgeRangeFrom = txtAgeFrom.Text.Length > 0 ? Convert.ToInt16( txtAgeFrom.Text ) : 0;
                            CurrentAppProvider.AgeRangeTO = txtAgeTo.Text.Length > 0 ? Convert.ToInt16( txtAgeTo.Text ) : 0;
                        }

                        if ( CurrentAppProvider.ProgramID.Equals( "HP" ) )
                        {
                            CurrentAppProvider.TypeFacility = listHP_ProviderType.SelectedValue;
                            CurrentAppProvider.AccreditedBody = listHP_Accred.SelectedValue;
                            CurrentAppProvider.JcahYN = listHP_Accred.SelectedValue.Equals( "1" ) ? "Y" : "N" ;
                            CurrentAppProvider.EnrolledInMedicaidYN = listMedicareCertified.SelectedValue;
                            CurrentAppProvider.ForYearEndingDate = txtHP_FYE.Text;
                            CurrentAppProvider.HospitalBasedYN = listHP_HospitalBased.SelectedValue;
                            CurrentAppProvider.ChapAccreditionYN = listHP_Accred.SelectedValue.Equals( "2" ) ? "Y" : "N";
                        }

                        if ( CurrentAppProvider.ProgramID.Equals( "HH" ) )
                        {
                            CurrentAppProvider.AccreditedBody = listHH_Accred.SelectedValue;
                            CurrentAppProvider.JcahYN = listHH_Accred.SelectedValue.Equals( "1" ) ? "Y" : "N";
                            CurrentAppProvider.ForYearEndingDate = txtHH_FYE.Text;
                            CurrentAppProvider.DeemedStatus = listHH_Deemed.SelectedValue;
                            CurrentAppProvider.HospitalBasedYN = listHH_HospBased.SelectedValue;
                            CurrentAppProvider.ChapAccreditionYN = listHH_Accred.SelectedValue.Equals( "2" ) ? "Y" : "N";
                        }

                        if ( CurrentAppProvider.ProgramID.Equals( "PD" ) )
                        {
                            CurrentAppProvider.AgeRangeFrom = txtAgeFrom.Text.Length > 0 ? Convert.ToInt16( txtAgeFrom.Text ) : 0;
                            CurrentAppProvider.AgeRangeTO = txtAgeTo.Text.Length > 0 ? Convert.ToInt16( txtAgeTo.Text ) : 0;
                        }

                        //SMM 05/28/2012 - Removed, not needed
                        //if ( CurrentAppProvider.ProgramID.Equals( "WA" ) )
                        //{
                        //    CurrentAppProvider.AgeRangeFrom = txtAgeFrom.Text.Length > 0 ? Convert.ToInt16( txtAgeFrom.Text ) : 0;
                        //    CurrentAppProvider.AgeRangeTO = txtAgeTo.Text.Length > 0 ? Convert.ToInt16( txtAgeTo.Text ) : 0;
                        //}

                        if (("AC,MT,NE").Contains(CurrentAppProvider.ProgramID))
                        {
                            CurrentAppProvider.TypeFacility = listAC_TypeFacility.SelectedValue;
                        }

                        if (("MT,NE").Contains(CurrentAppProvider.ProgramID))
                        {
                            CurrentAppProvider.EmergencyPhoneNumber = RadMaskedTextBoxEmergencyPhone.Text;
                        }

                        if ( CurrentAppProvider.ProgramID.Equals( "CM" ) )
                        {
                            CurrentAppProvider.TypeOfClients = listTypeClient.SelectedValue;
                        }

                        if ( CurrentAppProvider.ProgramID.Equals( "ES" ) )
                        {
                            if ( !IsOffSite )
                            {
                                if ( chkES_ProviderBased.Checked )
                                {
                                    CurrentAppProvider.TypeFacility = "1";
                                    CurrentAppProvider.RelatedProviderLicensureNum = txtES_RelProvNum.Text;
                                }
                                else if ( chkES_FreeStanding.Checked )
                                {
                                    CurrentAppProvider.TypeFacility = "2";
                                    CurrentAppProvider.RelatedProviderLicensureNum = "";
                                }
                            }
                        }

                        if ( CurrentAppProvider.ProgramID.Equals( "RH" ) )
                        {
                            if ( !IsOffSite )
                            {
                                if ( chkRH_Mobile.Checked )
                                {
                                    CurrentAppProvider.TypeFacility = "3";
                                }
                                else if ( chkRH_Stationary.Checked )
                                {
                                    CurrentAppProvider.TypeFacility = "4";
                                }

                                if ( chkRH_ProvBased.Checked )
                                {
                                    CurrentAppProvider.ProviderBasedYN = "Y";
                                    CurrentAppProvider.RelatedProviderLicensureNum = txtRH_RelProvNum.Text;
                                    CurrentAppProvider.RelatedProviderName = txtRH_RelProvName.Text;
                                }
                                else if ( chkRH_FreeStand.Checked )
                                {
                                    CurrentAppProvider.ProviderBasedYN = "N";
                                    CurrentAppProvider.RelatedProviderLicensureNum = "";
                                    CurrentAppProvider.RelatedProviderName = "";
                                }

                            }

                            if (OverrideLicenseNum.Checked)
                                CurrentAppProvider.LicensureNum = LicenseNum.Text;
                        }

                        if (CurrentAppProvider.ProgramID.Equals("AS") 
                            && !IsOffSite
                        ) {
                            CurrentAppProvider.AccreditedBody = listAS_Accred.SelectedValue;
                            CurrentAppProvider.DeemedStatus = listAS_Deemed.SelectedValue;
                            if (chkAS_HospitalBased.Checked) {
                                CurrentAppProvider.TypeFacility = "1";
                            }
                            else if (chkAS_FreeStanding.Checked) {
                                CurrentAppProvider.TypeFacility = "2";
                            }
                        }

                        if (CurrentAppProvider.ProgramID.Equals("MR") 
                            && !IsOffSite
                        ) {
                            if (optPopSrvBoth.Checked)
                                CurrentAppProvider.TypeOfClients = "8";
                            else if (optPopSrvMale.Checked)
                                CurrentAppProvider.TypeOfClients = "6";
                            else if (optPopSrvFemale.Checked)
                                CurrentAppProvider.TypeOfClients = "7";
                            else
                                CurrentAppProvider.TypeOfClients = null;

                            CurrentAppProvider.AgeRangeFrom = txtAgeFrom.Text.Length > 0 ? Convert.ToInt16(txtAgeFrom.Text) : 0;
                            CurrentAppProvider.AgeRangeTO = txtAgeTo.Text.Length > 0 ? Convert.ToInt16(txtAgeTo.Text) : 0;
                            
                            CurrentAppProvider.TypeFacility = listMR_TypeFacility.SelectedValue;
                        }

                        if (CurrentAppProvider.ProgramID.Equals("NH") 
                            && !IsOffSite
                        ) {
                            if (radMultiFacAdminYes.Checked) {
                                CurrentAppProvider.AdmMultiFacYN = "Y";
                            }
                            if (radMultiFacAdminNo.Checked) {
                                CurrentAppProvider.AdmMultiFacYN = "N";
                            }
                            CurrentAppProvider.AdmMultiFacOtherName = txtNHAdminOtherFacName.Text;
                            if (radSingleStory.Checked) {
                                CurrentAppProvider.SingleStoryYN = "Y";
                            }
                            if (radMultiStory.Checked) {
                                CurrentAppProvider.SingleStoryYN = "N";
                            }
                        }
                    }
                }
            }
            else
            {
                BO_Affiliation tmpSaveAffiliation = null;

                noSaveError = _DoValidate();

                if ( noSaveError )
                {
                    foreach ( BO_Affiliation tmpBA in CurrentAppProvider.BO_AffiliationsApplicationID )
                    {
                        if ( tmpBA.UI_TrackID.Equals( CurrentAffiliationID ) )
                        {
                            tmpSaveAffiliation = tmpBA;
                            break;
                        }
                    }

                    if ( CurrentAffiliationID.Substring( 0, 1 ).Equals( "N" ) )
                    {
                        //tmpSaveAffiliation = new BO_Affiliation();
                        tmpSaveAffiliation.TypeAffiliation = "01";
                        tmpSaveAffiliation.AffiliationID = 0;
                        tmpSaveAffiliation.PopsIntID = CurrentAppProvider.PopsIntID;
                        tmpSaveAffiliation.ApplicationID = CurrentAppProvider.ApplicationID;
                        tmpSaveAffiliation.OriginalApplicationID = CurrentAppProvider.ApplicationID;
                        tmpSaveAffiliation.Active = "1";
                        tmpSaveAffiliation.IsNewRec = true;
                        tmpSaveAffiliation.UI_TrackID = CurrentAffiliationID;
                   }

                    if ( IsNewOffsiteThisApp )
                    {
                        tmpSaveAffiliation.LicensureNum = LicenseNum.Text;
                        
                        if ( txtRHC.Visible )
                            tmpSaveAffiliation.LicensureNum += "RHC";

                        tmpSaveAffiliation.LicensureNum += "-" + LicenseNumOffsitePostFix.Text;
                    }

                    tmpSaveAffiliation.CurrentLicIssueDate = txtCurLicIssueDt.SelectedDate;
                    tmpSaveAffiliation.OffsiteOrigLicensureDate = dpOffsiteOriginalLicenseIssueDate.SelectedDate;
                    tmpSaveAffiliation.OffsiteCurrentLicIssueDate = dpOffSiteCurrentLicenseIssueDate.SelectedDate;
                    tmpSaveAffiliation.OffsiteLicEffectiveDate = dpOffSiteLicenseEffectiveDate.SelectedDate;
                    tmpSaveAffiliation.FacilityName = FacilityName.Text;
                    tmpSaveAffiliation.TelephoneNumber = FacilityAdministrationPhone.Text;
                    tmpSaveAffiliation.FaxPhoneNumber = FacilityAdministrationFax.Text;

                    //added to remove aco dependency 06-28-2019 ST
                    tmpSaveAffiliation.BranchID = !String.IsNullOrEmpty(txtBranchID.Text) ? Convert.ToDecimal(txtBranchID.Text) : (decimal?)null;
                    tmpSaveAffiliation.MedicareBranchID = !String.IsNullOrEmpty(txtMedicareBranchID.Text) ? txtMedicareBranchID.Text : null;

                    if ( CurrentAppProvider.ProgramID.Equals( "HP" ) )
                        tmpSaveAffiliation.TypeFacility = listHP_ProviderType.SelectedValue;

                    //CurrentAppProvider.JcahYN = listJcahoAccred.SelectedValue;
                    //CurrentAppProvider.EnrolledInMedicaidYN = listMedicareCertified.SelectedValue;

                    //aco sync replacement functionality to allow status change
                    tmpSaveAffiliation.OperStatCode = listBranchStatus.SelectedValue;
                    tmpSaveAffiliation.OpenedDate = txtBranchOpenDate.SelectedDate;
                    tmpSaveAffiliation.ClosedDate = txtBranchClosedDate.SelectedDate;


                    //Only Physical Address for offsite
                    if ( tmpSaveAffiliation.BO_AddressAffiliationID != null )
                    {
                        tmpSaveAffiliation.BO_AddressAffiliationID.Street = FacilityGeoStreetAddress.Text;
                        tmpSaveAffiliation.BO_AddressAffiliationID.City = listProviderCity.SelectedValue;
                        tmpSaveAffiliation.BO_AddressAffiliationID.State = listProviderState.SelectedValue;
                        tmpSaveAffiliation.BO_AddressAffiliationID.StateCode = listProviderState.SelectedValue;
                        tmpSaveAffiliation.BO_AddressAffiliationID.ParishCode = listProviderParish.SelectedValue;
                        tmpSaveAffiliation.BO_AddressAffiliationID.ZipCode = listProviderZip.SelectedValue;
                        tmpSaveAffiliation.BO_AddressAffiliationID.ZipCodeExtended = ProviderZipExtn.Text;
                    }
                    else
                    {
                        BO_Address tmpGeoAddr = new BO_Address();

                        tmpGeoAddr.PopsIntID = CurrentAppProvider.PopsIntID;
                        //tmpGeoAddr.ApplicationID = CurrentAppProvider.ApplicationID;
                        tmpGeoAddr.AddressType = 1;
                        tmpGeoAddr.Street = FacilityGeoStreetAddress.Text;
                        tmpGeoAddr.City = listProviderCity.SelectedValue;
                        tmpGeoAddr.State = listProviderState.SelectedValue;
                        tmpGeoAddr.StateCode = listProviderState.SelectedValue;
                        tmpGeoAddr.ParishCode = listProviderParish.SelectedValue;
                        tmpGeoAddr.ZipCode = listProviderZip.SelectedValue;
                        tmpGeoAddr.ZipCodeExtended = ProviderZipExtn.Text;
                        tmpSaveAffiliation.BO_AddressAffiliationID = tmpGeoAddr;
                    }

                    if ( ("HC,BR").Contains(CurrentAppProvider.ProgramID) )
                    {
                        if ( optPopSrvBoth.Checked )
                            tmpSaveAffiliation.TypeOfClients = "8";
                        else if ( optPopSrvMale.Checked )
                            tmpSaveAffiliation.TypeOfClients = "6";
                        else if ( optPopSrvFemale.Checked )
                            tmpSaveAffiliation.TypeOfClients = "7";
                        else
                            tmpSaveAffiliation.TypeOfClients = null;

                        tmpSaveAffiliation.AgeRangeFrom = txtAgeFrom.Text.Length > 0 ? Convert.ToInt16( txtAgeFrom.Text ) : 0;
                        tmpSaveAffiliation.AgeRangeTO = txtAgeTo.Text.Length > 0 ? Convert.ToInt16( txtAgeTo.Text ) : 0;
                        if(!("BR").Contains(CurrentAppProvider.ProgramID))
                            tmpSaveAffiliation.TypeAffiliation = rcbAffiliationType.SelectedValue;
                    }

                    if ( CurrentAppProvider.ProgramID.Equals( "HP" ) )
                    {
                        tmpSaveAffiliation.TypeFacility = listHP_ProviderType.SelectedValue;
                    }
                }
            }

            if ( noSaveError )
            {
                if ( CurrentAppProvider.ProgramID.Equals( "BR" ) )
                {
                    BO_Service tmpService = null;

                    tmpService = _FindServiceBR( "01" ); //Residential
                    if ( chkBR_Residential.Checked )
                    {
                        if ( null == tmpService )
                        {
                            tmpService = _getNewService( "01" );
                        }

                        tmpService.Capacity = ( !string.IsNullOrEmpty( txtBR_ResCapacity.Text ) ? Convert.ToInt16( txtBR_ResCapacity.Text ) : 0 );

                        if ( tmpService.IsNewRec )
                            _AddServiceToLocation( tmpService );
                    }
                    else
                    {
                        if ( null != tmpService )
                        {
                            tmpService.Removed = true;
                        }
                    }

                    if ( !IsOffSite ) // Only process Community Living for the main campus
                    {
                        tmpService = null;
                        tmpService = _FindServiceBR( "02" );
                        if ( chkBR_CommLiving.Checked )
                        {
                            if ( null == tmpService )
                            {
                                tmpService = _getNewService( "02" );
                            }

                            if ( tmpService.IsNewRec )
                                _AddServiceToLocation( tmpService );
                        }
                        else
                        {
                            if ( null != tmpService )
                            {
                                tmpService.Removed = true;
                            }
                        }
                    }

                    tmpService = null;
                    tmpService = _FindServiceBR( "03" ); //Outpatient
                    if ( chkBR_Outpatient.Checked )
                    {
                        if ( null == tmpService )
                        {
                            tmpService = _getNewService( "03" );
                        }

                        tmpService.DayOfOperationMon = CheckBoxDayOfOperationMon.Checked ? "1" : "0";
                        tmpService.DayOfOperationTue = CheckBoxDayOfOperationTue.Checked ? "1" : "0";
                        tmpService.DayOfOperationWed = CheckBoxDayOfOperationWed.Checked ? "1" : "0";
                        tmpService.DayOfOperationThu = CheckBoxDayOfOperationThu.Checked ? "1" : "0";
                        tmpService.DayOfOperationFri = CheckBoxDayOfOperationFri.Checked ? "1" : "0";
                        tmpService.DayOfOperationSat = CheckBoxDayOfOperationSat.Checked ? "1" : "0";
                        tmpService.DayOfOperationSun = CheckBoxDayOfOperationSun.Checked ? "1" : "0";

                        tmpService.OperatingHoursFromTime = txtHoursMinutesFrom.Text;
                        tmpService.OperatingHoursFromMeridiem = listAmPmFrom.SelectedValue;
                        tmpService.OperatingHoursToTime = txtHoursMinutesTo.Text;
                        tmpService.OperatingHoursToMeridiem = listAmPmTo.SelectedValue;

                        if ( tmpService.IsNewRec )
                            _AddServiceToLocation( tmpService );
                    }
                    else
                    {
                        if ( null != tmpService )
                        {
                            tmpService.Removed = true;
                        }
                    }
                }
            }

            return noSaveError;
        }

        private void NewLic()
        {

                BO_Provider tmpProv = BO_Provider.SelectOne(new BO_ProviderPrimaryKey(CurrentAppProvider.PopsIntID));
                BO_Licenses tmpLics = BO_License.SelectAllByForeignKeyApplicationID(new BO_ApplicationPrimaryKey(CurrentAppProvider.ApplicationID));

                if (null != CurrentAppProvider)
                {
                    bool GenerateLicenseNum = false;
                    bool LicNumAlreadyGenerated = false;
                    string tmpLicNum = CurrentAppProvider.LicensureNum;

                    // No license number then generate one
                    if (string.IsNullOrEmpty(tmpLicNum))
                    {
                        GenerateLicenseNum = true;
                    }
                    // If this is a CHOW or Change of address and a new license number has not
                    // been generated then generate one. 
                    else if (null == tmpLics &&
                             (
                                CurrentAppProvider.BusinessProcessID.Equals("4") ||
                                CurrentAppProvider.BusinessProcessID.Equals("6")
                             )
                    )
                    {
                        GenerateLicenseNum = true;
                    }
                    // If this is a CHOW or Change of address and other license numbers exist.
                    // This is to allow for forced generation. 
                    else if (null != tmpLics &&
                             (
                                CurrentAppProvider.BusinessProcessID.Equals("4") ||
                                CurrentAppProvider.BusinessProcessID.Equals("6")
                             )
                    )
                    {
                        tmpLics.Sort("LicensureNum Desc");
                        foreach (BO_License boLic in tmpLics)
                        {
                            if (boLic.LicensureNum.Equals(CurrentAppProvider.LicensureNum))
                            {
                                LicNumAlreadyGenerated = true;
                                break;
                            }
                        }
                        if (!LicNumAlreadyGenerated)
                            GenerateLicenseNum = true;
                    }

                    if (GenerateLicenseNum)
                    {
                        CurrentAppProvider.GenerateLicensureNum(Convert.ToDecimal(CurrentAppProvider.ApplicationID), false);
                        CurrentAppProvider.Update();

                        if (null != CurrentAppProvider.BO_AffiliationsApplicationID)
                        {
                            foreach (BO_Affiliation tmpAffil in CurrentAppProvider.BO_AffiliationsApplicationID)
                            {
                                string newLicNum = tmpAffil.LicensureNum;
                                int rhcFirstPos = tmpAffil.LicensureNum.IndexOf("RHC", System.StringComparison.OrdinalIgnoreCase);

                                string[] tmpLicNumParts = tmpAffil.LicensureNum.Split('-');

                                if (null != tmpLicNumParts && tmpLicNumParts.Count() > 0)
                                {
                                    newLicNum = CurrentAppProvider.LicensureNum;

                                    if (rhcFirstPos > 0)
                                    {
                                        newLicNum += "RHC";
                                    }

                                    if (tmpLicNumParts.Count() > 1)
                                        newLicNum += "-" + tmpLicNumParts[1];
                                }

                                tmpAffil.LicensureNum = newLicNum;
                                tmpAffil.CurrentLicIssueDate = CurrentAppProvider.CurrentLicIssueDate;
                                tmpAffil.Update();
                            }
                        }

                        tmpProv.LicensureNum = CurrentAppProvider.LicensureNum;
                        tmpProv.Update();

                        //Create new license tracking record
                        BO_License tmpNewLic = new BO_License();
                        tmpNewLic.PopsIntID = CurrentAppProvider.PopsIntID;
                        tmpNewLic.ApplicationID = CurrentAppProvider.ApplicationID;
                        tmpNewLic.LicensureNum = CurrentAppProvider.LicensureNum;
                        tmpNewLic.Insert();
                    }
            }
        }

        private void _AddServiceToLocation( BO_Service inService )
        {
            if ( !IsOffSite )
            {
                CurrentAppProvider.BO_ServicesApplicationID.Add( inService );
            }
            else
            {
                if ( null != CurrentAppProvider.BO_AffiliationsApplicationID )
                {
                    foreach ( BO_Affiliation boAffil in CurrentAppProvider.BO_AffiliationsApplicationID )
                    {
                        if ( boAffil.UI_TrackID.Equals( CurrentAffiliationID ) )
                        {
                            boAffil.BO_ServicesAffiliationID.Add( inService );

                            break;
                        }
                    }
                }
            }

        }

        private BO_Service _FindServiceBR( string inServiceType )
        {
            BO_Service retVal = null;

            if ( !IsOffSite )
            {
                if ( null != CurrentAppProvider.BO_ServicesApplicationID )
                {
                    foreach ( BO_Service boSvc in CurrentAppProvider.BO_ServicesApplicationID )
                    {
                        if ( boSvc.ServiceType.Equals( inServiceType ) )
                            retVal = boSvc;
                    }
                }
            }
            else
            {
                if ( null != CurrentAppProvider.BO_AffiliationsApplicationID )
                {
                    foreach ( BO_Affiliation boAffil in CurrentAppProvider.BO_AffiliationsApplicationID )
                    {
                        if ( boAffil.UI_TrackID.Equals( CurrentAffiliationID )
                            && boAffil.BO_ServicesAffiliationID != null )
                        {
                            foreach ( BO_Service boSvc in boAffil.BO_ServicesAffiliationID )
                            {
                                if ( boSvc.ServiceType.Equals( inServiceType ) )
                                {
                                    retVal = boSvc;
                                    break;
                                }
                            }

                            break;
                        }
                    }
                }
            }

            return retVal;
        }

        private BO_Service _getNewService( string inServiceType )
        {
            BO_Service newService = new BO_Service();

            newService.IsNewRec = true;
            newService.PopsIntID = CurrentAppProvider.PopsIntID;
            newService.ApplicationID = CurrentAppProvider.ApplicationID;
            newService.ServiceType = inServiceType;

            if ( IsOffSite )
            {
                int ServiceCnt = 0;

                foreach ( BO_Affiliation boAffil in CurrentAppProvider.BO_AffiliationsApplicationID )
                {
                    if ( boAffil.UI_TrackID.Equals( CurrentAffiliationID )
                        && boAffil.BO_ServicesAffiliationID != null )
                    {
                        ServiceCnt = boAffil.BO_ServicesAffiliationID.Count;
                        break;
                    }
                }

                newService.UI_TrackID = "N" + ServiceCnt.ToString();
            }

            return newService;
        }

        private bool _DoValidate()
        {
            bool retVal = true;
            string validationErrors = "";

            ErrorText.Visible = false;
            ErrorText.InnerHtml = "";

            if ( FacilityName.Text.Length < 1 )
            {
                validationErrors += "Facility Name is Required<br/>";
            }
            if ( FacilityGeoStreetAddress.Text.Length < 1 )
            {
                validationErrors += "Address is Required<br/>";
            }
            if (listProviderState.SelectedValue.Length < 1)
            {
                validationErrors += "State is Required<br/>";
            }
            if ( listProviderCity.SelectedValue.Length < 1 )
            {
                validationErrors += "City is Required<br/>";
            }
            //check to see if parish is shown, will only be visible when state = "LA"
            if (listProviderParish.Enabled)
            {
                if (listProviderParish.SelectedValue.Length < 1)
                {
                    validationErrors += "Parish is Required<br/>";
                }
            }
            if ( listProviderZip.SelectedValue.Length < 1 )
            {
                validationErrors += "Zipcode is Required<br/>";
            }
            //Main campus only
            if ( MailStreetPOBox.Text.Length < 1 && !IsOffSite )
            {
                validationErrors += "Mailing Address is Required<br/>";
            }
            if ( listMailCity.SelectedValue.Length < 1 && !IsOffSite )
            {
                validationErrors += "Mailing City is Required<br/>";
            }
            if ( listMailState.SelectedValue.Length < 1 && !IsOffSite )
            {
                validationErrors += "Mailing State is Required<br/>";
            }
            if ( listMailZip.SelectedValue.Length < 1 && !IsOffSite )
            {
                validationErrors += "Mailing Zipcode is Required<br/>";
            }

            if ( CurrentAppProvider.ProgramID.Equals( "HP" ) && !IsOffSite ) 
            {
                if ( string.IsNullOrEmpty(listHP_ProviderType.SelectedValue) )
                    validationErrors += "Type of Hospice is Required<br/>";
            }

            if (IsOffSite)
            {
                //validate licensure num in affiliation table to ensure no duplication by provider
                BO_Affiliations validateAffiliations = BO_Affiliation.SelectByField("POPS_INT_ID", CurrentAppProvider.PopsIntID);
                foreach (BO_Affiliation valAffiliation in validateAffiliations)
                {
                    if (valAffiliation.FacilityName != FacilityName.Text && valAffiliation.LicensureNum == (LicenseNum.Text + "-" + LicenseNumOffsitePostFix.Text))
                    {
                        validationErrors += (LicenseNum.Text + "-" + LicenseNumOffsitePostFix.Text).ToString() + " is already used by another offsite<br>";
                        break;
                    }
                }

                

                //validate rules for dates offsite additions
                var processidlist = new List<string> { "11", "7", "5", "10", "8" };

                if (processidlist.Contains(CurrentAppProvider.BusinessProcessID))
                {
                    //validation rule only applies for new offsite addition
                    if (CurrentAppProvider.BusinessProcessID == "8")
                    {
                        if (!chkOffSiteOriginalLicenseIssueDate.Checked & dpOffsiteOriginalLicenseIssueDate.SelectedDate != null)
                        {
                            if (((DateTime)dpOffsiteOriginalLicenseIssueDate.SelectedDate) < DateTime.Now.AddDays(-180))
                            {
                                validationErrors += "Offsite Original License Issue Date cannot be more than 180 prior to today's date<br>";
                            }
                        }
                    }

                    if (!chkOffSiteCurrentLicenseIssueDate.Checked & dpOffSiteCurrentLicenseIssueDate.SelectedDate != null)
                    {
                        if (((DateTime)dpOffSiteCurrentLicenseIssueDate.SelectedDate) < DateTime.Now.AddDays(-30) || ((DateTime)dpOffSiteCurrentLicenseIssueDate.SelectedDate) > DateTime.Now.AddDays(30))
                        {
                            validationErrors += "Offsite Current License Issue Date cannnot be more than 30 days prior to or 30 days greater than today's date<br>";
                        }
                    }
                    if (!chkOffSiteLicenseEffectiveDate.Checked & dpOffsiteOriginalLicenseIssueDate.SelectedDate != null)
                    {
                        if (dpOffSiteLicenseEffectiveDate.SelectedDate != null)
                        {
                            if (((DateTime)dpOffSiteLicenseEffectiveDate.SelectedDate) < ((DateTime)dpOffsiteOriginalLicenseIssueDate.SelectedDate))
                            {
                                validationErrors += "Offsite License Effective Date cannot be prior to Offsite Original License Issue Date<br>";
                            }
                        }
                    }
                }
            }

            if ( validationErrors.Length > 0 )
            {
                ErrorText.Visible = true;
                ErrorText.InnerHtml += validationErrors;
                retVal = false;
            }


            return retVal;
        }

        protected void listProviderState_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (listProviderState.SelectedValue != "LA")
            {
                lblParish.Text = "County";
            }

            listProviderCity.Text = "";
            listProviderZip.Text = "";
            listProviderParish.Text = "";

            listProviderCity.ClearSelection();
            listProviderCity.Items.Clear();
            listProviderCity.AppendDataBoundItems = true;
            listProviderCity.Items.Add(new RadComboBoxItem("", ""));
            listProviderCity.DataSource = CommonFunc.getCitiesByState(e.Value.ToString());
            listProviderCity.DataTextField = "City";
            listProviderCity.DataValueField = "City";
            listProviderCity.Height = Unit.Pixel(100);
            listProviderCity.DataBind();
        }

        protected void listMailState_SelectedIndexChanged( object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e )
        {
            listMailZip.Text = "";
            listMailCity.Text = "";
            listMailCity.ClearSelection();
            listMailCity.Items.Clear();
            listMailCity.AppendDataBoundItems = true;
            listMailCity.Items.Add( new RadComboBoxItem( "", "" ) );
            listMailCity.DataSource = CommonFunc.getCitiesByState( e.Value.ToString() );
            listMailCity.DataTextField = "City";
            listMailCity.DataValueField = "City";
            listMailCity.Height = Unit.Pixel( 100 );
            listMailCity.DataBind();
        }

        protected void listMailCity_SelectedIndexChanged( object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e )
        {
            listMailZip.Text = "";
            listMailZip.ClearSelection();
            listMailZip.Items.Clear();
            listMailZip.AppendDataBoundItems = true;
            listMailZip.Items.Add( new RadComboBoxItem( "", "" ) );
            listMailZip.DataSource = CommonFunc.getZipByCityState ( e.Value.ToString(), listMailState.SelectedValue );
            listMailZip.DataTextField = "Zip";
            listMailZip.DataValueField = "Zip";
            listMailZip.Height = Unit.Pixel( 100 );
            listMailZip.DataBind();
        }
        
        protected void listProviderCity_SelectedIndexChanged( Object sender, RadComboBoxSelectedIndexChangedEventArgs e )
        {
            listProviderParish.Text = "";
            listProviderParish.ClearSelection();
            listProviderParish.Items.Clear();
            listProviderParish.AppendDataBoundItems = true;
            listProviderParish.Items.Add(new RadComboBoxItem("", ""));
            listProviderParish.DataSource = BO_Ziplookup.SelectParishes(listProviderState.SelectedValue, listProviderCity.SelectedValue);
            listProviderParish.DataTextField = "CNTYNAME";
            listProviderParish.DataValueField = "COUNTY";
            listProviderParish.Height = Unit.Pixel(100);
            listProviderParish.DataBind();

            listProviderZip.Text = "";
            listProviderZip.ClearSelection();
            listProviderZip.Items.Clear();
            listProviderZip.AppendDataBoundItems = true;
            listProviderZip.Items.Add( new RadComboBoxItem( "", "" ) );
            listProviderZip.DataSource = CommonFunc.getZipByCityState( e.Value.ToString(), listProviderState.SelectedValue );
            listProviderZip.DataTextField = "Zip";
            listProviderZip.DataValueField = "Zip";
            listProviderZip.Height = Unit.Pixel( 100 );
            listProviderZip.DataBind();
        }

        protected void listProviderParish_SelectedIndexChanged(Object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            //getRegionFieldOffice();

            ////RegionFieldOfficeOverride.Visible = true;
        }

        private void getRegionFieldOffice()
        {
            if (CurrentAppProvider.RegionalOffice == "override")
            {
                chkRegionFieldOfficeOverride.Checked = true;
                lblDHHRegionLabel.Text += "<b>" + getRegionName(CurrentAppProvider.RegionCode);
                lblHSSFieldOfficeLabel.Text += "<b>" + getFieldOfficeName(CurrentAppProvider.FieldOfficeCode);
            }
            else
            {
                lblDHHRegionLabel.Text += "<b>" + getRegionByParish(listProviderParish.SelectedValue).ToString() + "</b>";
                lblHSSFieldOfficeLabel.Text += "<b>" + getFieldOfficeByParish(listProviderParish.SelectedValue).ToString() + "</b>";
            }

            listDHHAdminRegion.Items.Clear();
            listDHHAdminRegion.AppendDataBoundItems = true;
            listDHHAdminRegion.Items.Add(new ListItem("", ""));
            listDHHAdminRegion.DataSource = RegionLookups;
            listDHHAdminRegion.DataTextField = "RegionName";
            listDHHAdminRegion.DataValueField = "RegionCode";
            listDHHAdminRegion.DataBind();

            listHSSFieldOffice.Items.Clear();
            listHSSFieldOffice.AppendDataBoundItems = true;
            listHSSFieldOffice.Items.Add(new ListItem("", ""));
            listHSSFieldOffice.DataSource = FieldOfficeLookups;
            listHSSFieldOffice.DataTextField = "Valdesc";
            listHSSFieldOffice.DataValueField = "LookupVal";
            listHSSFieldOffice.DataBind();
        }

        private string getRegionName(string regionCode)
        {
            string regionName = "";
            DataTable regionTable = RegionLookups;
            foreach (DataRow row in regionTable.Rows)
            {
                if (row["RegionCode"].ToString() == regionCode)
                {
                    regionName = row["RegionName"].ToString();
                    break;
                }
            }
            return regionName;
        }

        private string getFieldOfficeName(string fieldOfficeCode)
        {
            string fieldOfficeName = "";
            DataTable fieldOfficeTable = FieldOfficeLookups;
            foreach (DataRow row in fieldOfficeTable.Rows)
            {
                if (row["LookupVal"].ToString() == fieldOfficeCode)
                {
                    fieldOfficeName = row["Valdesc"].ToString();
                    break;
                }
            }
            return fieldOfficeName;
        }

        private string getRegionByParish(string parishCode)
        {
            string regionName = "";
            string regionCode = "";
            if (BO_Parishe.SelectByField("PARISH_CODE", parishCode).Count > 0)
            {
                regionCode = BO_Parishe.SelectByField("PARISH_CODE", parishCode)[0].DhhAdminRegion.ToString();
            }
            DataTable regionTable = RegionLookups;
            foreach (DataRow row in regionTable.Rows)
            {
                if (row["RegionCode"].ToString() == regionCode)
                {
                    regionName = row["RegionName"].ToString();
                    break;
                }
            }
            return regionName;
        }

        private string getFieldOfficeByParish(string parishCode)
        {
            string fieldOfficeName = "";
            string fieldOfficeCode = "";
            if (BO_Parishe.SelectByField("PARISH_CODE", parishCode).Count>0)
            {
                fieldOfficeCode = BO_Parishe.SelectByField("PARISH_CODE", parishCode)[0].HssFieldOffice.ToString();
            }
            DataTable fieldOfficeTable = FieldOfficeLookups;
            foreach (DataRow row in fieldOfficeTable.Rows)
            {
                if (row["LookupVal"].ToString() == fieldOfficeCode)
                {
                    fieldOfficeName = row["Valdesc"].ToString();
                    break;
                }
            }
            return fieldOfficeName;
        }

        protected void FacilityInFacility_SelectedIndexChanged(Object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (DdlFacilityInFacilityYN.SelectedValue == "Y")
            {
                lblFacilityInFacilityDesc.Visible = true;
                TextBoxFacilityInFacility.Visible = true;
            }
            else
            {
                lblFacilityInFacilityDesc.Visible = false;
                TextBoxFacilityInFacility.Visible = false;
                TextBoxFacilityInFacility.Text = "";
            }
        }

        private void _LoadSelectLists()
        {
            //Clear prior to loading
            listProviderState.Items.Clear();
            listProviderCity.Items.Clear();
            listProviderParish.Items.Clear();
            listMailState.Items.Clear();
            listMailCity.Items.Clear();
            listMailZip.Items.Clear();
            listFiscalInt.Items.Clear();
            listAccrdBody.Items.Clear();
            listHP_ProviderType.ClearSelection();
            listHP_Accred.Items.Clear();
            listHH_Accred.Items.Clear();
            listAC_TypeFacility.Items.Clear();
            listMR_TypeFacility.Items.Clear();
            listProvStatus.Items.Clear();
            listBranchStatus.Items.Clear();

            listProviderState.AppendDataBoundItems = true;
            listProviderState.Items.Add(new RadComboBoxItem("", ""));
            listProviderState.DataSource = StateLookups;
            listProviderState.DataTextField = "StateName";
            listProviderState.DataValueField = "StateCode";
            listProviderState.Height = Unit.Pixel(100);
            listProviderState.DataBind();

            listProviderCity.AppendDataBoundItems = true;
            listProviderCity.Items.Add( new RadComboBoxItem( "", "" ) ); 
            listProviderCity.DataSource = LACityLookups;
            listProviderCity.DataTextField = "City";
            listProviderCity.DataValueField = "City";
            listProviderCity.Height = Unit.Pixel( 100 );
            listProviderCity.DataBind();

            /*
            listProviderParish.AppendDataBoundItems = true;
            listProviderParish.Items.Add( new RadComboBoxItem( "", "" ) ); 
            //listProviderParish.DataSource = BO_Ziplookup.SelectByField("STATE_CODE", CurrentAppProvider.StateCode);
            listProviderParish.DataSource = BO_Ziplookup.SelectParishes(CurrentAppProvider.StateCode, getGeoCityFromCurrentAddressList(), );
            listProviderParish.DataTextField = "CNTYNAME";
            listProviderParish.DataValueField = "COUNTY";
            listProviderParish.Height = Unit.Pixel( 100 );
            listProviderParish.DataBind();
             * */

            listMailState.AppendDataBoundItems = true;
            listMailState.Items.Add( new RadComboBoxItem("","") );
            listMailState.DataSource = StateLookups;
            listMailState.DataTextField = "StateName";
            listMailState.DataValueField = "StateCode";
            listMailState.Height = Unit.Pixel( 100 );
            listMailState.DataBind();

            listAccrdBody.AppendDataBoundItems = true;
            listAccrdBody.Items.Add( new RadComboBoxItem( "", "" ) );
            listAccrdBody.DataSource = AOLookups;
            listAccrdBody.DataTextField = "Valdesc";
            listAccrdBody.DataValueField = "LookupVal";
            listAccrdBody.Height = Unit.Pixel( 100 );
            listAccrdBody.DataBind();

            listFiscalInt.AppendDataBoundItems = true;
            listFiscalInt.Items.Add( new RadComboBoxItem( "", "" ) );
            listFiscalInt.DataSource = FILookups;
            listFiscalInt.DataTextField = "Valdesc";
            listFiscalInt.DataValueField = "LookupVal";
            listFiscalInt.Height = Unit.Pixel( 100 );
            listFiscalInt.DataBind();
            
            listProvStatus.AppendDataBoundItems = true;
            listProvStatus.Items.Add(new RadComboBoxItem("", ""));
            listProvStatus.DataSource = ProvStatusLookups;
            listProvStatus.DataTextField = "Valdesc";
            listProvStatus.DataValueField = "LookupVal";
            listProvStatus.Height = Unit.Pixel(100);
            listProvStatus.DataBind();
            
            listBranchStatus.AppendDataBoundItems = true;
            listBranchStatus.Items.Add(new RadComboBoxItem("", ""));
            listBranchStatus.DataSource = BranchStatusLookups;
            listBranchStatus.DataTextField = "Valdesc";
            listBranchStatus.DataValueField = "LookupVal";
            listBranchStatus.Height = Unit.Pixel(100);
            listBranchStatus.DataBind();
            
            if ( CurrentAppProvider.ProgramID.Equals( "HP" ) )
            {
                BO_LookupValues ProvTypeLkups = BO_LookupValue.SelectByField( BO_LookupValueFields.LookupKey, "TYPE_FACILITY" );

                listHP_ProviderType.AppendDataBoundItems = true;
                listHP_ProviderType.Height = Unit.Pixel( 100 );
                listHP_ProviderType.Items.Add( new RadComboBoxItem( "", "" ) );

                foreach ( BO_LookupValue tmpLU in ProvTypeLkups )
                {
                    if ( tmpLU.Allowedtypes.Contains( "HP" ) && !tmpLU.LookupVal.Equals("03") )
                    {
                        if ( IsOffSite ) // All lookup values for Offsite Location
                        {
                            RadComboBoxItem tmpItm = new RadComboBoxItem();
                            tmpItm.Text = tmpLU.Valdesc;
                            tmpItm.Value = tmpLU.LookupVal;
                            listHP_ProviderType.Items.Add( tmpItm );
                        }
                        else if ( !tmpLU.LookupVal.Equals( "02" ) && !tmpLU.LookupVal.Equals( "02" ) ) // "01" Outpatient - only for main campus
                        {
                            RadComboBoxItem tmpItm = new RadComboBoxItem();
                            tmpItm.Text = tmpLU.Valdesc;
                            tmpItm.Value = tmpLU.LookupVal;
                            listHP_ProviderType.Items.Add( tmpItm );

                        }
                    }
                }

                listHP_Accred.AppendDataBoundItems = true;
                listHP_Accred.Items.Add( new RadComboBoxItem( "", "" ) );
                listHP_Accred.DataSource = AOLookups;
                listHP_Accred.DataTextField = "Valdesc";
                listHP_Accred.DataValueField = "LookupVal";
                listHP_Accred.Height = Unit.Pixel( 100 );
                listHP_Accred.DataBind();                
            }

            if ( CurrentAppProvider.ProgramID.Equals( "HH" ) )
            {
                listHH_Accred.AppendDataBoundItems = true;
                listHH_Accred.Items.Add( new RadComboBoxItem( "", "" ) );
                listHH_Accred.DataSource = AOLookups;
                listHH_Accred.DataTextField = "Valdesc";
                listHH_Accred.DataValueField = "LookupVal";
                listHH_Accred.Height = Unit.Pixel( 100 );
                listHH_Accred.DataBind();                
            }

            if (("AC,MT,NE").Contains(CurrentAppProvider.ProgramID))
            {
                listAC_TypeFacility.AppendDataBoundItems = true;
                listAC_TypeFacility.Items.Add( new RadComboBoxItem( "", "" ) );
                listAC_TypeFacility.DataSource = TypFacilityLookups;
                listAC_TypeFacility.DataTextField = "Valdesc";
                listAC_TypeFacility.DataValueField = "LookupVal";
                listAC_TypeFacility.Height = Unit.Pixel( 100 );
                listAC_TypeFacility.DataBind();
            }

            if ( CurrentAppProvider.ProgramID.Equals( "CM" ) )
            {
                listTypeClient.AppendDataBoundItems = true;
                listTypeClient.Items.Add( new RadComboBoxItem( "", "" ) );
                listTypeClient.DataSource = TypeClientLookups;
                listTypeClient.DataTextField = "Valdesc";
                listTypeClient.DataValueField = "LookupVal";
                listTypeClient.Height = Unit.Pixel( 100 );
                listTypeClient.DataBind();
            }

            if (CurrentAppProvider.ProgramID.Equals("AS"))
            {
                listAS_Accred.AppendDataBoundItems = true;
                listAS_Accred.Items.Add( new RadComboBoxItem( "", "" ) );
                listAS_Accred.DataSource = AOLookups;
                listAS_Accred.DataTextField = "Valdesc";
                listAS_Accred.DataValueField = "LookupVal";
                listAS_Accred.Height = Unit.Pixel( 100 );
                listAS_Accred.DataBind();       
            }

            if (CurrentAppProvider.ProgramID.Equals("MR")) {
                listMR_TypeFacility.AppendDataBoundItems = true;
                listMR_TypeFacility.Items.Add(new RadComboBoxItem("", ""));
                listMR_TypeFacility.DataSource = TypFacilityLookups;
                listMR_TypeFacility.DataTextField = "Valdesc";
                listMR_TypeFacility.DataValueField = "LookupVal";
                listMR_TypeFacility.Height = Unit.Pixel(100);
                listMR_TypeFacility.DataBind();
            }

            if (CurrentAppProvider.ProgramID.Equals("HC"))
            {
                rcbAffiliationType.AppendDataBoundItems = true;
                rcbAffiliationType.Items.Add(new RadComboBoxItem("", ""));
                rcbAffiliationType.DataSource = BO_LookupValue.SelectByFieldByKeyAndProgram("TYPE_AFFILIATION","HC");
                rcbAffiliationType.DataTextField = "Valdesc";
                rcbAffiliationType.DataValueField = "LookupVal";
                rcbAffiliationType.Height = Unit.Pixel(100);
                rcbAffiliationType.DataBind();
            }
        }

        private void _ShowHideFields()
        {
            //Turn off all sections first then enable them by program type and location
            divProviderProvExtra.Visible = false;
            divAdministration.Visible = true;
            divHospFacSubType.Visible = false;
            DivFIHeader.Visible = false;
            FacTableFI.Visible = false;
            DivAccred.Visible = false;
            FacTableAccredit.Visible = false;
            divRelatedProvider.Visible = false;
            divBR_ProviderType.Visible = false;
            lblStatusAccred.Visible = false;
            chkStatusAccred.Visible = false;
            divHP_ProviderType.Visible = false;
            divHH_ProviderType.Visible = false;
            divAC_ProviderType.Visible = false;
            divES_ProviderType.Visible = false;
            divRH_ProviderType.Visible = false;
            divAS_ProviderType.Visible = false;
            divMR_ProviderType.Visible = false;
            divNH_ProviderType.Visible = false;

            switch ( CurrentAppProvider.ProgramID )
            {
                case "HC":
                    divProviderProvExtra.Visible = true;
                    tblPopServed_ProvExtra.Visible = true;
                    tblAgeServed_ProvExtra.Visible = true;
                    tblTypeClient_ProvExtra.Visible = false;
                    tblAffiliationType.Visible = true;
                    DivAccred.Visible = true;
                    FacTableAccredit.Visible = true;
                    FNR_ApprovalDate.Visible = true;
                    //divAdministration.Visible = true;
                    if ( !IsOffSite )
                    {
                        lblStatusAccred.Visible = true;
                        chkStatusAccred.Visible = true;
                    }
                    break;
                case "HO":
                    divHospFacSubType.Visible = true;
                    //divAdministration.Visible = true;
                    DivFIHeader.Visible = true;
                    FacTableFI.Visible = true;
                    DivAccred.Visible = true;
                    FacTableAccredit.Visible = true;
                    divRelatedProvider.Visible = true;
                    break;
                case "PT":
                    DivAccred.Visible = true;
                    FacTableAccredit.Visible = true;
                    break;
                case "BR":
                    //divAdministration.Visible = true;
                    divProviderProvExtra.Visible = true;
                    tblPopServed_ProvExtra.Visible = true;
                    tblAgeServed_ProvExtra.Visible = true;
                    tblTypeClient_ProvExtra.Visible = false;
                    divBR_ProviderType.Visible = true;
                    tblResidential.Rows[0].Cells[1].Style.Add( HtmlTextWriterStyle.PaddingTop, "5px" );
                    tblResidential.Rows[0].Cells[2].Style.Add( HtmlTextWriterStyle.PaddingTop, "5px" );
                    tblComLiving.Rows[0].Cells[1].Style.Add( HtmlTextWriterStyle.PaddingTop, "5px" );
                    tblComLiving.Rows[0].Cells[2].Style.Add( HtmlTextWriterStyle.PaddingTop, "5px" );
                    tblOutpatient.Rows[0].Cells[1].Style.Add( HtmlTextWriterStyle.PaddingTop, "5px" );
                    tblOutpatient.Rows[0].Cells[2].Style.Add( HtmlTextWriterStyle.PaddingTop, "5px" );
                    break;
                case "HP":
                    //divAdministration.Visible = true;
                    divHP_ProviderType.Visible = true;
                    FNR_ApprovalDate.Visible = true;

                    if ( IsOffSite )
                    {
                        lblHP_Accred.Visible = false;
                        listHP_Accred.Visible = false;
                        lblMedicareCertified.Visible = false;
                        listMedicareCertified.Visible = false;
                        lblHPFiscalYrEnd.Visible = false;
                        txtHP_FYE.Visible = false;
                        lblHP_HospitalBased.Visible = false;
                        listHP_HospitalBased.Visible = false;
                    }
                    
                    break;
                case "HH":
                    //divAdministration.Visible = true;
                    if ( IsOffSite )
                        divHH_ProviderType.Visible = false;
                    else
                        divHH_ProviderType.Visible = true;
                    break;
                case "PD":
                    //divAdministration.Visible = true;
                    divProviderProvExtra.Visible = true;
                    tblPopServed_ProvExtra.Visible = false;
                    tblAgeServed_ProvExtra.Visible = true;
                    tblTypeClient_ProvExtra.Visible = false;
                    FNR_ApprovalDate.Visible = true;
                    break;
                //SMM 05/28/2012 - Removed, not needed
                //case "WA":
                //    divProviderProvExtra.Visible = true;
                //    tblPopServed_ProvExtra.Visible = false;
                //    tblAgeServed_ProvExtra.Visible = true;
                //    tblTypeClient_ProvExtra.Visible = false;
                //    break;
                case "AC":
                    divAC_ProviderType.Visible = true;
                    FNR_ApprovalDate.Visible = true;
                    break;
                case "CM":
                    divProviderProvExtra.Visible = true;
                    tblPopServed_ProvExtra.Visible = false;
                    tblAgeServed_ProvExtra.Visible = false;
                    tblTypeClient_ProvExtra.Visible = true;
                    break;
                case "ES":
                    divES_ProviderType.Visible = true;
                    DivFIHeader.Visible = true;
                    FacTableFI.Visible = true;
                    break;
                case "RH":
                    divRH_ProviderType.Visible = true;
                    DivFIHeader.Visible = true;
                    FacTableFI.Visible = true;
                    OverrideLicenseNum.Visible = true;
                    break;
                case "CC":
                    DivFIHeader.Visible = true;
                    FacTableFI.Visible = true;
                    break;
                case "AS":
                    divAS_ProviderType.Visible = true;
                    DivFIHeader.Visible = true;
                    FacTableFI.Visible = true;
                    //DivAccred.Visible = true;
                    //FacTableAccredit.Visible = true;
                    //lblStatusAccred.Visible = true;
                    //chkStatusAccred.Visible = true;
                    break;
                case "CO":
                    DivFIHeader.Visible = true;
                    FacTableFI.Visible = true;
                    break;
                case "MR":
                    divProviderProvExtra.Visible = true;
                    tblAgeServed_ProvExtra.Visible = true;
                    tblTypeClient_ProvExtra.Visible = false;
                    divMR_ProviderType.Visible = true;
                    break;
                case "NH":
                    divNH_ProviderType.Visible = true;
                    break;
                case "MT":
                    divAC_ProviderType.Visible = true;
                    DivFIHeader.Visible = true;
                    FacTableFI.Visible = true;
                    lblFiscalYrEnd.Visible = false;
                    txtFiscalYrEnd.Visible = false;
                    lblEmergencyPhone.Visible = true;
                    RadMaskedTextBoxEmergencyPhone.Visible = true;
                    break;
                case "NE":
                    divAC_ProviderType.Visible = true;
                    lblEmergencyPhone.Visible = true;
                    RadMaskedTextBoxEmergencyPhone.Visible = true;
                    break;
            }

            //Alwasy disabled for offsites regardless of type provider
            if ( IsOffSite )
            {
                DivFIHeader.Visible = false;
                FacTableFI.Visible = false;
                DivAccred.Visible = false;
                FacTableAccredit.Visible = false;
                lblLicenseExpirationDate.Visible = true;
                dpLicenseExpirationDate.Visible = true;
                dpLicenseExpirationDate.Enabled = false;
                dpOffsiteOriginalLicenseIssueDate.Enabled = false;
                lblOffSiteOriginalLicenseIssueDate.Visible = true;
                dpOffsiteOriginalLicenseIssueDate.Visible = true;
                lblOffSiteCurrentLicenseIssueDate.Visible = true;
                dpOffSiteCurrentLicenseIssueDate.Visible = true;
                lblOffSiteLicenseEffectiveDate.Visible = true;
                dpOffSiteLicenseEffectiveDate.Visible = true;

                //admin region and field office only available for primary providers, not offsites
                RegionFieldOfficeOverride.Visible = false;

                //original license issue date only enabled and editable if new offsite addition application and application is not yet approved
                if (CurrentAppProvider.BusinessProcessID == "8" & CurrentAppProvider.ApplicationStatus != "4")
                {
                    dpOffsiteOriginalLicenseIssueDate.Enabled = true;
                }
           
                //offsite licensure date overrides by application type
                switch (CurrentAppProvider.BusinessProcessID)
                {
                        //renewal license - no override - current and effective date set by parent provider
                    case "3":
                        chkOffSiteOriginalLicenseIssueDate.Visible = false;
                        chkOffSiteCurrentLicenseIssueDate.Visible = false;
                        chkOffSiteLicenseEffectiveDate.Visible = false;
                        dpOffSiteCurrentLicenseIssueDate.SelectedDate = CurrentAppProvider.CurrentLicIssueDate;
                        dpOffSiteLicenseEffectiveDate.SelectedDate = CurrentAppProvider.LicensureEffectiveDate;
                        dpOffSiteCurrentLicenseIssueDate.Enabled = false;
                        dpOffSiteLicenseEffectiveDate.Enabled = false;
                        break;
                        //change of ownership - 
                    case "4":
                        chkOffSiteOriginalLicenseIssueDate.Visible = false;
                        chkOffSiteCurrentLicenseIssueDate.Visible = false;
                        chkOffSiteLicenseEffectiveDate.Visible = false;
                        dpOffSiteCurrentLicenseIssueDate.SelectedDate = CurrentAppProvider.CurrentLicIssueDate;
                        dpOffSiteLicenseEffectiveDate.SelectedDate = CurrentAppProvider.LicensureEffectiveDate;
                         dpOffSiteCurrentLicenseIssueDate.Enabled = false;
                        dpOffSiteLicenseEffectiveDate.Enabled = false;
                        break;
                        //name change - Original Licensure Date cannot be changed no override
                    case "5":
                        chkOffSiteOriginalLicenseIssueDate.Visible = false;
                        chkOffSiteCurrentLicenseIssueDate.Visible = true;
                        chkOffSiteLicenseEffectiveDate.Visible = true;
                        break;
                        //address change - Original Licensure Date cannot be changed no override
                    case "6":
                        chkOffSiteOriginalLicenseIssueDate.Visible = false;
                        chkOffSiteCurrentLicenseIssueDate.Visible = true;
                        chkOffSiteLicenseEffectiveDate.Visible = true;
                        break;
                        //capabity change - Original Licensure Date cannot be changed no override
                    case "7":
                        chkOffSiteOriginalLicenseIssueDate.Visible = false;
                        chkOffSiteCurrentLicenseIssueDate.Visible = true;
                        chkOffSiteLicenseEffectiveDate.Visible = true;
                        break;
                        //offiste addition - all dates can be updated and overridden
                    case "8":
                        chkOffSiteOriginalLicenseIssueDate.Visible = true;
                        chkOffSiteCurrentLicenseIssueDate.Visible = true;
                        chkOffSiteLicenseEffectiveDate.Visible = true;
                        break;
                        //change of service
                    case "10":
                        chkOffSiteOriginalLicenseIssueDate.Visible = false;
                        chkOffSiteCurrentLicenseIssueDate.Visible = true;
                        chkOffSiteLicenseEffectiveDate.Visible = true;
                        break;
                }

            }

            if ( Session["userType"].ToString() == "State" )
            {
                if ( AllowEdit )
                {
                    FacilityName.ReadOnly = false;
                    FacilityGeoStreetAddress.ReadOnly = false;
                    
                    listProviderCity.ShowDropDownOnTextboxClick = true;
                    listProviderCity.ShowToggleImage = true;

                    foreach ( RadComboBoxItem radComboBoxItem in listProviderCity.Items )
                    {
                        radComboBoxItem.Enabled = true;
                    }

                    listProviderParish.ShowDropDownOnTextboxClick = true;
                    listProviderParish.ShowToggleImage = true;

                    foreach ( RadComboBoxItem radComboBoxItem in listProviderParish.Items )
                    {
                        radComboBoxItem.Enabled = true;
                    }

                    listProviderZip.ShowDropDownOnTextboxClick = true;
                    listProviderZip.ShowToggleImage = true;

                    foreach ( RadComboBoxItem radComboBoxItem in listProviderZip.Items )
                    {
                        radComboBoxItem.Enabled = true;
                    }

                    ProviderZipExtn.ReadOnly = false;
                    MailStreetPOBox.ReadOnly = false;
                    
                    listMailState.ShowDropDownOnTextboxClick = true;
                    listMailState.ShowToggleImage = true;

                    foreach ( RadComboBoxItem radComboBoxItem in listMailState.Items )
                    {
                        radComboBoxItem.Enabled = true;
                    }

                    listMailCity.ShowDropDownOnTextboxClick = true;
                    listMailCity.ShowToggleImage = true;

                    foreach ( RadComboBoxItem radComboBoxItem in listMailCity.Items )
                    {
                        radComboBoxItem.Enabled = true;
                    }

                    listMailZip.ShowDropDownOnTextboxClick = true;
                    listMailZip.ShowToggleImage = true;

                    foreach ( RadComboBoxItem radComboBoxItem in listMailZip.Items )
                    {
                        radComboBoxItem.Enabled = true;
                    }

                    MailZipExtn.ReadOnly = false;
                    
                    FacilityAdministrationPhone.ReadOnly = false;
                    FacilityAdministrationFax.ReadOnly = false;
                    txtAdminEmail.ReadOnly = false;
                    
                    listFiscalInt.ShowDropDownOnTextboxClick = true;
                    listFiscalInt.ShowToggleImage = true;

                    foreach ( RadComboBoxItem radComboBoxItem in listFiscalInt.Items )
                    {
                        radComboBoxItem.Enabled = true;
                    }
                    txtFiscalYrEnd.ReadOnly = false;
                    
                    listAccrdBody.ShowDropDownOnTextboxClick = true;
                    listAccrdBody.ShowToggleImage = true;

                    foreach ( RadComboBoxItem radComboBoxItem in listAccrdBody.Items )
                    {
                        radComboBoxItem.Enabled = true;
                    }
                    calAccrdExpDt.Enabled = true;

                    optFactype.Enabled = true;
                    txtRelatedProvider.ReadOnly = false;

                    optPopSrvBoth.Enabled = true;
                    optPopSrvFemale.Enabled = true;
                    optPopSrvMale.Enabled = true;

                    RadMaskedTextBoxEmergencyPhone.Enabled = true;
                }
                else
                {
                    FacilityName.ReadOnly = true;
                    //FacilityName.BackColor = System.Drawing.Color.LightGray;
                    
                    FacilityGeoStreetAddress.ReadOnly = true;
                    //FacilityGeoStreetAddress.BackColor = System.Drawing.Color.LightGray;

                    listProviderCity.ShowDropDownOnTextboxClick = false;
                    listProviderCity.ShowToggleImage = false;
                    //listProviderCity.BackColor = System.Drawing.Color.LightGray;

                    foreach ( RadComboBoxItem radComboBoxItem in listProviderCity.Items )
                    {
                        radComboBoxItem.Enabled = false;
                    }

                    listProviderParish.ShowDropDownOnTextboxClick = false;
                    listProviderParish.ShowToggleImage = false;
                    //listProviderParish.BackColor = System.Drawing.Color.LightGray;

                    foreach ( RadComboBoxItem radComboBoxItem in listProviderParish.Items )
                    {
                        radComboBoxItem.Enabled = false;
                    }

                    listProviderZip.ShowDropDownOnTextboxClick = false;
                    listProviderZip.ShowToggleImage = false;
                    //listProviderZip.BackColor = System.Drawing.Color.LightGray;

                    foreach ( RadComboBoxItem radComboBoxItem in listProviderZip.Items )
                    {
                        radComboBoxItem.Enabled = false;
                    }

                    ProviderZipExtn.ReadOnly = true;
                    //ProviderZipExtn.BackColor = System.Drawing.Color.LightGray;

                    MailStreetPOBox.ReadOnly = true;
                    //MailStreetPOBox.BackColor = System.Drawing.Color.LightGray;

                    listMailState.ShowDropDownOnTextboxClick = false;
                    listMailState.ShowToggleImage = false;
                    //listMailState.BackColor = System.Drawing.Color.LightGray;

                    foreach ( RadComboBoxItem radComboBoxItem in listMailState.Items )
                    {
                        radComboBoxItem.Enabled = false;
                    }

                    listMailCity.ShowDropDownOnTextboxClick = false;
                    listMailCity.ShowToggleImage = false;
                    //listMailCity.BackColor = System.Drawing.Color.LightGray;

                    foreach ( RadComboBoxItem radComboBoxItem in listMailCity.Items )
                    {
                        radComboBoxItem.Enabled = false;
                    }

                    listMailZip.ShowDropDownOnTextboxClick = false;
                    listMailZip.ShowToggleImage = false;
                    //listMailZip.BackColor = System.Drawing.Color.LightGray;

                    foreach ( RadComboBoxItem radComboBoxItem in listMailZip.Items )
                    {
                        radComboBoxItem.Enabled = false;
                    }

                    MailZipExtn.ReadOnly = true;
                    //MailZipExtn.BackColor = System.Drawing.Color.LightGray;

                    FacilityAdministrationPhone.ReadOnly = true;
                    //FacilityAdministrationPhone.BackColor = System.Drawing.Color.LightGray;
                    FacilityAdministrationFax.ReadOnly = true;
                    //FacilityAdministrationFax.BackColor = System.Drawing.Color.LightGray;
                    txtAdminEmail.ReadOnly = true;
                    //txtAdminEmail.BackColor = System.Drawing.Color.LightGray;

                    listFiscalInt.ShowDropDownOnTextboxClick = false;
                    listFiscalInt.ShowToggleImage = false;
                    //listFiscalInt.BackColor = System.Drawing.Color.LightGray;

                    foreach ( RadComboBoxItem radComboBoxItem in listFiscalInt.Items )
                    {
                        radComboBoxItem.Enabled = false;
                    }
                    txtFiscalYrEnd.ReadOnly = true;
                    //txtFiscalYrEnd.BackColor = System.Drawing.Color.LightGray;

                    listAccrdBody.ShowDropDownOnTextboxClick = false;
                    listAccrdBody.ShowToggleImage = false;
                    //listAccrdBody.BackColor = System.Drawing.Color.LightGray;

                    foreach ( RadComboBoxItem radComboBoxItem in listAccrdBody.Items )
                    {
                        radComboBoxItem.Enabled = false;
                    }

                    calAccrdExpDt.Enabled = false;
                    //calAccrdExpDt.BackColor = System.Drawing.Color.LightGray;
                    
                    optFactype.Enabled = false;
                    txtRelatedProvider.ReadOnly = true;
                    //txtRelatedProvider.BackColor = System.Drawing.Color.LightGray;

                    optPopSrvBoth.Enabled = false;
                    optPopSrvFemale.Enabled = false;
                    optPopSrvMale.Enabled = false;

                    listHH_Accred.Enabled = false;
                    listHH_Deemed.Enabled = false;
                    listHH_HospBased.Enabled = false;
                    listHP_Accred.Enabled = false;
                    listHP_HospitalBased.Enabled = false;
                    listHP_ProviderType.Enabled = false;
                    listAmPmFrom.Enabled = false;
                    listAmPmTo.Enabled = false;
                    listMedicareCertified.Enabled = false;

                    RadMaskedTextBoxEmergencyPhone.Enabled = false;

                }
            }
            else
            {
                if ( !CurrentAppProvider.ApplicationStatus.Equals( "4" ) && AllowEdit )
                {
                    switch ( CurrentAppProvider.BusinessProcessID )
                    {
                        case "2": //INITIAL LICENSING
                            FacilityName.ReadOnly = false;
                            FacilityName.BackColor = System.Drawing.Color.White;
                            FacilityGeoStreetAddress.ReadOnly = false;
                            FacilityGeoStreetAddress.BackColor = System.Drawing.Color.White;

                            listProviderCity.ShowDropDownOnTextboxClick = true;
                            listProviderCity.ShowToggleImage = true;

                            foreach ( RadComboBoxItem radComboBoxItem in listProviderCity.Items )
                            {
                                radComboBoxItem.Enabled = true;
                            }

                            listProviderParish.ShowDropDownOnTextboxClick = true;
                            listProviderParish.ShowToggleImage = true;

                            foreach ( RadComboBoxItem radComboBoxItem in listProviderParish.Items )
                            {
                                radComboBoxItem.Enabled = true;
                            }

                            listProviderZip.ShowDropDownOnTextboxClick = true;
                            listProviderZip.ShowToggleImage = true;

                            foreach ( RadComboBoxItem radComboBoxItem in listProviderZip.Items )
                            {
                                radComboBoxItem.Enabled = true;
                            }

                            ProviderZipExtn.ReadOnly = false;
                            ProviderZipExtn.BackColor = System.Drawing.Color.White;

                            MailStreetPOBox.ReadOnly = false;
                            MailStreetPOBox.BackColor = System.Drawing.Color.White;

                            listMailState.ShowDropDownOnTextboxClick = true;
                            listMailState.ShowToggleImage = true;

                            foreach ( RadComboBoxItem radComboBoxItem in listMailState.Items )
                            {
                                radComboBoxItem.Enabled = true;
                            }

                            listMailCity.ShowDropDownOnTextboxClick = true;
                            listMailCity.ShowToggleImage = true;

                            foreach ( RadComboBoxItem radComboBoxItem in listMailCity.Items )
                            {
                                radComboBoxItem.Enabled = true;
                            }

                            listMailZip.ShowDropDownOnTextboxClick = true;
                            listMailZip.ShowToggleImage = true;

                            foreach ( RadComboBoxItem radComboBoxItem in listMailZip.Items )
                            {
                                radComboBoxItem.Enabled = true;
                            }

                            MailZipExtn.ReadOnly = false;
                            MailZipExtn.BackColor = System.Drawing.Color.White;

                            FacilityAdministrationPhone.ReadOnly = false;
                            FacilityAdministrationPhone.BackColor = System.Drawing.Color.White;
                            FacilityAdministrationFax.ReadOnly = false;
                            FacilityAdministrationFax.BackColor = System.Drawing.Color.White;
                            txtAdminEmail.ReadOnly = false;
                            txtAdminEmail.BackColor = System.Drawing.Color.White;

                            listFiscalInt.ShowDropDownOnTextboxClick = true;
                            listFiscalInt.ShowToggleImage = true;

                            foreach ( RadComboBoxItem radComboBoxItem in listFiscalInt.Items )
                            {
                                radComboBoxItem.Enabled = true;
                            }
                            txtFiscalYrEnd.ReadOnly = false;
                            txtFiscalYrEnd.BackColor = System.Drawing.Color.White;

                            listAccrdBody.ShowDropDownOnTextboxClick = true;
                            listAccrdBody.ShowToggleImage = true;

                            foreach ( RadComboBoxItem radComboBoxItem in listAccrdBody.Items )
                            {
                                radComboBoxItem.Enabled = true;
                            }
                            calAccrdExpDt.Enabled = true;

                            optFactype.Enabled = true;
                            txtRelatedProvider.ReadOnly = false;
                            txtRelatedProvider.BackColor = System.Drawing.Color.White;
                            break;
                        case "3": //LICENSE RENEWAL
                            FacilityName.ReadOnly = false;
                            FacilityName.BackColor = System.Drawing.Color.White;
                            FacilityGeoStreetAddress.ReadOnly = true;
                            FacilityGeoStreetAddress.BackColor = System.Drawing.Color.LightGray;

                            listProviderCity.ShowDropDownOnTextboxClick = false;
                            listProviderCity.ShowToggleImage = false;

                            foreach ( RadComboBoxItem radComboBoxItem in listProviderCity.Items )
                            {
                                radComboBoxItem.Enabled = false;
                            }

                            listProviderParish.ShowDropDownOnTextboxClick = false;
                            listProviderParish.ShowToggleImage = false;

                            foreach ( RadComboBoxItem radComboBoxItem in listProviderParish.Items )
                            {
                                radComboBoxItem.Enabled = false;
                            }

                            listProviderZip.ShowDropDownOnTextboxClick = false;
                            listProviderZip.ShowToggleImage = false;

                            foreach ( RadComboBoxItem radComboBoxItem in listProviderZip.Items )
                            {
                                radComboBoxItem.Enabled = false;
                            }

                            ProviderZipExtn.ReadOnly = true;
                            ProviderZipExtn.BackColor = System.Drawing.Color.LightGray;

                            MailStreetPOBox.ReadOnly = false;
                            MailStreetPOBox.BackColor = System.Drawing.Color.White;

                            listMailState.ShowDropDownOnTextboxClick = true;
                            listMailState.ShowToggleImage = true;

                            foreach ( RadComboBoxItem radComboBoxItem in listMailState.Items )
                            {
                                radComboBoxItem.Enabled = true;
                            }

                            listMailCity.ShowDropDownOnTextboxClick = true;
                            listMailCity.ShowToggleImage = true;

                            foreach ( RadComboBoxItem radComboBoxItem in listMailCity.Items )
                            {
                                radComboBoxItem.Enabled = true;
                            }

                            listMailZip.ShowDropDownOnTextboxClick = true;
                            listMailZip.ShowToggleImage = true;

                            foreach ( RadComboBoxItem radComboBoxItem in listMailZip.Items )
                            {
                                radComboBoxItem.Enabled = true;
                            }

                            MailZipExtn.ReadOnly = false;
                            MailZipExtn.BackColor = System.Drawing.Color.White;

                            FacilityAdministrationPhone.ReadOnly = false;
                            FacilityAdministrationPhone.BackColor = System.Drawing.Color.White;
                            FacilityAdministrationFax.ReadOnly = false;
                            FacilityAdministrationFax.BackColor = System.Drawing.Color.White;
                            txtAdminEmail.ReadOnly = false;
                            txtAdminEmail.BackColor = System.Drawing.Color.White;

                            listFiscalInt.ShowDropDownOnTextboxClick = false;
                            listFiscalInt.ShowToggleImage = false;

                            foreach ( RadComboBoxItem radComboBoxItem in listFiscalInt.Items )
                            {
                                radComboBoxItem.Enabled = false;
                            }
                            txtFiscalYrEnd.ReadOnly = true;
                            txtFiscalYrEnd.BackColor = System.Drawing.Color.LightGray;

                            listAccrdBody.ShowDropDownOnTextboxClick = false;
                            listAccrdBody.ShowToggleImage = false;

                            foreach ( RadComboBoxItem radComboBoxItem in listAccrdBody.Items )
                            {
                                radComboBoxItem.Enabled = false;
                            }
                            calAccrdExpDt.Enabled = false;

                            optFactype.Enabled = false;
                            txtRelatedProvider.ReadOnly = true;
                            txtRelatedProvider.BackColor = System.Drawing.Color.LightGray;
                            break;
                        case "4": //CHANGE OF OWNERSHIP
                            FacilityName.ReadOnly = false;
                            FacilityName.BackColor = System.Drawing.Color.White;
                            FacilityGeoStreetAddress.ReadOnly = true;
                            FacilityGeoStreetAddress.BackColor = System.Drawing.Color.LightGray;

                            listProviderCity.ShowDropDownOnTextboxClick = false;
                            listProviderCity.ShowToggleImage = false;

                            foreach ( RadComboBoxItem radComboBoxItem in listProviderCity.Items )
                            {
                                radComboBoxItem.Enabled = false;
                            }

                            listProviderParish.ShowDropDownOnTextboxClick = false;
                            listProviderParish.ShowToggleImage = false;

                            foreach ( RadComboBoxItem radComboBoxItem in listProviderParish.Items )
                            {
                                radComboBoxItem.Enabled = false;
                            }

                            listProviderZip.ShowDropDownOnTextboxClick = false;
                            listProviderZip.ShowToggleImage = false;

                            foreach ( RadComboBoxItem radComboBoxItem in listProviderZip.Items )
                            {
                                radComboBoxItem.Enabled = false;
                            }

                            ProviderZipExtn.ReadOnly = true;
                            ProviderZipExtn.BackColor = System.Drawing.Color.LightGray;

                            MailStreetPOBox.ReadOnly = false;
                            MailStreetPOBox.BackColor = System.Drawing.Color.White;

                            listMailState.ShowDropDownOnTextboxClick = true;
                            listMailState.ShowToggleImage = true;

                            foreach ( RadComboBoxItem radComboBoxItem in listMailState.Items )
                            {
                                radComboBoxItem.Enabled = true;
                            }

                            listMailCity.ShowDropDownOnTextboxClick = true;
                            listMailCity.ShowToggleImage = true;

                            foreach ( RadComboBoxItem radComboBoxItem in listMailCity.Items )
                            {
                                radComboBoxItem.Enabled = true;
                            }

                            listMailZip.ShowDropDownOnTextboxClick = true;
                            listMailZip.ShowToggleImage = true;

                            foreach ( RadComboBoxItem radComboBoxItem in listMailZip.Items )
                            {
                                radComboBoxItem.Enabled = true;
                            }

                            MailZipExtn.ReadOnly = false;
                            MailZipExtn.BackColor = System.Drawing.Color.White;

                            FacilityAdministrationPhone.ReadOnly = false;
                            FacilityAdministrationPhone.BackColor = System.Drawing.Color.White;
                            FacilityAdministrationFax.ReadOnly = false;
                            FacilityAdministrationFax.BackColor = System.Drawing.Color.White;
                            txtAdminEmail.ReadOnly = false;
                            txtAdminEmail.BackColor = System.Drawing.Color.White;

                            listFiscalInt.ShowDropDownOnTextboxClick = false;
                            listFiscalInt.ShowToggleImage = false;

                            foreach ( RadComboBoxItem radComboBoxItem in listFiscalInt.Items )
                            {
                                radComboBoxItem.Enabled = false;
                            }
                            txtFiscalYrEnd.ReadOnly = true;
                            txtFiscalYrEnd.BackColor = System.Drawing.Color.LightGray;

                            listAccrdBody.ShowDropDownOnTextboxClick = false;
                            listAccrdBody.ShowToggleImage = false;

                            foreach ( RadComboBoxItem radComboBoxItem in listAccrdBody.Items )
                            {
                                radComboBoxItem.Enabled = false;
                            }
                            calAccrdExpDt.Enabled = false;

                            optFactype.Enabled = false;
                            txtRelatedProvider.ReadOnly = true;
                            txtRelatedProvider.BackColor = System.Drawing.Color.LightGray;
                            break;
                        case "5": //NAME CHANGE
                            FacilityName.ReadOnly = false;
                            FacilityName.BackColor = System.Drawing.Color.White;
                            FacilityGeoStreetAddress.ReadOnly = false;
                            FacilityGeoStreetAddress.BackColor = System.Drawing.Color.White;

                            listProviderCity.ShowDropDownOnTextboxClick = true;
                            listProviderCity.ShowToggleImage = true;

                            foreach ( RadComboBoxItem radComboBoxItem in listProviderCity.Items )
                            {
                                radComboBoxItem.Enabled = true;
                            }

                            listProviderParish.ShowDropDownOnTextboxClick = true;
                            listProviderParish.ShowToggleImage = true;

                            foreach ( RadComboBoxItem radComboBoxItem in listProviderParish.Items )
                            {
                                radComboBoxItem.Enabled = true;
                            }

                            listProviderZip.ShowDropDownOnTextboxClick = true;
                            listProviderZip.ShowToggleImage = true;

                            foreach ( RadComboBoxItem radComboBoxItem in listProviderZip.Items )
                            {
                                radComboBoxItem.Enabled = true;
                            }

                            ProviderZipExtn.ReadOnly = false;
                            ProviderZipExtn.BackColor = System.Drawing.Color.White;

                            MailStreetPOBox.ReadOnly = false;
                            MailStreetPOBox.BackColor = System.Drawing.Color.White;

                            listMailState.ShowDropDownOnTextboxClick = true;
                            listMailState.ShowToggleImage = true;

                            foreach ( RadComboBoxItem radComboBoxItem in listMailState.Items )
                            {
                                radComboBoxItem.Enabled = true;
                            }

                            listMailCity.ShowDropDownOnTextboxClick = true;
                            listMailCity.ShowToggleImage = true;

                            foreach ( RadComboBoxItem radComboBoxItem in listMailCity.Items )
                            {
                                radComboBoxItem.Enabled = true;
                            }

                            listMailZip.ShowDropDownOnTextboxClick = true;
                            listMailZip.ShowToggleImage = true;

                            foreach ( RadComboBoxItem radComboBoxItem in listMailZip.Items )
                            {
                                radComboBoxItem.Enabled = true;
                            }

                            MailZipExtn.ReadOnly = false;
                            MailZipExtn.BackColor = System.Drawing.Color.White;

                            FacilityAdministrationPhone.ReadOnly = false;
                            FacilityAdministrationPhone.BackColor = System.Drawing.Color.White;
                            FacilityAdministrationFax.ReadOnly = false;
                            FacilityAdministrationFax.BackColor = System.Drawing.Color.White;
                            txtAdminEmail.ReadOnly = false;
                            txtAdminEmail.BackColor = System.Drawing.Color.White;

                            listFiscalInt.ShowDropDownOnTextboxClick = false;
                            listFiscalInt.ShowToggleImage = false;

                            foreach ( RadComboBoxItem radComboBoxItem in listFiscalInt.Items )
                            {
                                radComboBoxItem.Enabled = false;
                            }
                            txtFiscalYrEnd.ReadOnly = true;
                            txtFiscalYrEnd.BackColor = System.Drawing.Color.LightGray;

                            listAccrdBody.ShowDropDownOnTextboxClick = false;
                            listAccrdBody.ShowToggleImage = false;

                            foreach ( RadComboBoxItem radComboBoxItem in listAccrdBody.Items )
                            {
                                radComboBoxItem.Enabled = false;
                            }
                            calAccrdExpDt.Enabled = false;

                            optFactype.Enabled = false;
                            txtRelatedProvider.ReadOnly = true;
                            txtRelatedProvider.BackColor = System.Drawing.Color.LightGray;
                            break;
                        case "6": //ADDRESS CHANGE
                            FacilityName.ReadOnly = false;
                            FacilityName.BackColor = System.Drawing.Color.White;
                            FacilityGeoStreetAddress.ReadOnly = false;
                            FacilityGeoStreetAddress.BackColor = System.Drawing.Color.White;

                            listProviderCity.ShowDropDownOnTextboxClick = true;
                            listProviderCity.ShowToggleImage = true;

                            foreach ( RadComboBoxItem radComboBoxItem in listProviderCity.Items )
                            {
                                radComboBoxItem.Enabled = true;
                            }

                            listProviderParish.ShowDropDownOnTextboxClick = true;
                            listProviderParish.ShowToggleImage = true;

                            foreach ( RadComboBoxItem radComboBoxItem in listProviderParish.Items )
                            {
                                radComboBoxItem.Enabled = true;
                            }

                            listProviderZip.ShowDropDownOnTextboxClick = true;
                            listProviderZip.ShowToggleImage = true;

                            foreach ( RadComboBoxItem radComboBoxItem in listProviderZip.Items )
                            {
                                radComboBoxItem.Enabled = true;
                            }

                            ProviderZipExtn.ReadOnly = false;
                            ProviderZipExtn.BackColor = System.Drawing.Color.White;

                            MailStreetPOBox.ReadOnly = false;
                            MailStreetPOBox.BackColor = System.Drawing.Color.White;

                            listMailState.ShowDropDownOnTextboxClick = true;
                            listMailState.ShowToggleImage = true;

                            foreach ( RadComboBoxItem radComboBoxItem in listMailState.Items )
                            {
                                radComboBoxItem.Enabled = true;
                            }

                            listMailCity.ShowDropDownOnTextboxClick = true;
                            listMailCity.ShowToggleImage = true;

                            foreach ( RadComboBoxItem radComboBoxItem in listMailCity.Items )
                            {
                                radComboBoxItem.Enabled = true;
                            }

                            listMailZip.ShowDropDownOnTextboxClick = true;
                            listMailZip.ShowToggleImage = true;

                            foreach ( RadComboBoxItem radComboBoxItem in listMailZip.Items )
                            {
                                radComboBoxItem.Enabled = true;
                            }

                            MailZipExtn.ReadOnly = false;
                            MailZipExtn.BackColor = System.Drawing.Color.White;

                            FacilityAdministrationPhone.ReadOnly = false;
                            FacilityAdministrationPhone.BackColor = System.Drawing.Color.White;
                            FacilityAdministrationFax.ReadOnly = false;
                            FacilityAdministrationFax.BackColor = System.Drawing.Color.White;
                            txtAdminEmail.ReadOnly = false;
                            txtAdminEmail.BackColor = System.Drawing.Color.White;

                            listFiscalInt.ShowDropDownOnTextboxClick = false;
                            listFiscalInt.ShowToggleImage = false;

                            foreach ( RadComboBoxItem radComboBoxItem in listFiscalInt.Items )
                            {
                                radComboBoxItem.Enabled = false;
                            }
                            txtFiscalYrEnd.ReadOnly = true;
                            txtFiscalYrEnd.BackColor = System.Drawing.Color.LightGray;

                            listAccrdBody.ShowDropDownOnTextboxClick = false;
                            listAccrdBody.ShowToggleImage = false;

                            foreach ( RadComboBoxItem radComboBoxItem in listAccrdBody.Items )
                            {
                                radComboBoxItem.Enabled = false;
                            }
                            calAccrdExpDt.Enabled = false;

                            optFactype.Enabled = false;
                            txtRelatedProvider.ReadOnly = true;
                            txtRelatedProvider.BackColor = System.Drawing.Color.LightGray;
                            break;
                        case "7": //BED CHANGES
                            FacilityName.ReadOnly = true;
                            FacilityName.BackColor = System.Drawing.Color.LightGray;
                            FacilityGeoStreetAddress.ReadOnly = true;
                            FacilityGeoStreetAddress.BackColor = System.Drawing.Color.LightGray;

                            listProviderCity.ShowDropDownOnTextboxClick = false;
                            listProviderCity.ShowToggleImage = false;

                            foreach ( RadComboBoxItem radComboBoxItem in listProviderCity.Items )
                            {
                                radComboBoxItem.Enabled = false;
                            }

                            listProviderParish.ShowDropDownOnTextboxClick = false;
                            listProviderParish.ShowToggleImage = false;

                            foreach ( RadComboBoxItem radComboBoxItem in listProviderParish.Items )
                            {
                                radComboBoxItem.Enabled = false;
                            }

                            listProviderZip.ShowDropDownOnTextboxClick = false;
                            listProviderZip.ShowToggleImage = false;

                            foreach ( RadComboBoxItem radComboBoxItem in listProviderZip.Items )
                            {
                                radComboBoxItem.Enabled = false;
                            }

                            ProviderZipExtn.ReadOnly = true;
                            ProviderZipExtn.BackColor = System.Drawing.Color.LightGray;

                            MailStreetPOBox.ReadOnly = true;
                            MailStreetPOBox.BackColor = System.Drawing.Color.LightGray;

                            listMailState.ShowDropDownOnTextboxClick = false;
                            listMailState.ShowToggleImage = false;

                            foreach ( RadComboBoxItem radComboBoxItem in listMailState.Items )
                            {
                                radComboBoxItem.Enabled = false;
                            }

                            listMailCity.ShowDropDownOnTextboxClick = false;
                            listMailCity.ShowToggleImage = false;

                            foreach ( RadComboBoxItem radComboBoxItem in listMailCity.Items )
                            {
                                radComboBoxItem.Enabled = false;
                            }

                            listMailZip.ShowDropDownOnTextboxClick = false;
                            listMailZip.ShowToggleImage = false;

                            foreach ( RadComboBoxItem radComboBoxItem in listMailZip.Items )
                            {
                                radComboBoxItem.Enabled = false;
                            }

                            MailZipExtn.ReadOnly = true;
                            MailZipExtn.BackColor = System.Drawing.Color.LightGray;

                            FacilityAdministrationPhone.ReadOnly = true;
                            FacilityAdministrationPhone.BackColor = System.Drawing.Color.LightGray;
                            FacilityAdministrationFax.ReadOnly = true;
                            FacilityAdministrationFax.BackColor = System.Drawing.Color.LightGray;
                            txtAdminEmail.ReadOnly = true;
                            txtAdminEmail.BackColor = System.Drawing.Color.LightGray;

                            listFiscalInt.ShowDropDownOnTextboxClick = false;
                            listFiscalInt.ShowToggleImage = false;

                            foreach ( RadComboBoxItem radComboBoxItem in listFiscalInt.Items )
                            {
                                radComboBoxItem.Enabled = false;
                            }
                            txtFiscalYrEnd.ReadOnly = true;
                            txtFiscalYrEnd.BackColor = System.Drawing.Color.LightGray;

                            listAccrdBody.ShowDropDownOnTextboxClick = false;
                            listAccrdBody.ShowToggleImage = false;

                            foreach ( RadComboBoxItem radComboBoxItem in listAccrdBody.Items )
                            {
                                radComboBoxItem.Enabled = false;
                            }
                            calAccrdExpDt.Enabled = false;

                            optFactype.Enabled = false;
                            txtRelatedProvider.ReadOnly = true;
                            txtRelatedProvider.BackColor = System.Drawing.Color.LightGray;
                            break;
                        case "8": //OFF-SITE ADDITIONS
                            if ( !IsOffSite )
                            {
                                FacilityName.ReadOnly = true;
                                FacilityName.BackColor = System.Drawing.Color.LightGray;
                                FacilityGeoStreetAddress.ReadOnly = true;
                                FacilityGeoStreetAddress.BackColor = System.Drawing.Color.LightGray;

                                listProviderCity.ShowDropDownOnTextboxClick = false;
                                listProviderCity.ShowToggleImage = false;

                                foreach ( RadComboBoxItem radComboBoxItem in listProviderCity.Items )
                                {
                                    radComboBoxItem.Enabled = false;
                                }

                                listProviderParish.ShowDropDownOnTextboxClick = false;
                                listProviderParish.ShowToggleImage = false;

                                foreach ( RadComboBoxItem radComboBoxItem in listProviderParish.Items )
                                {
                                    radComboBoxItem.Enabled = false;
                                }

                                listProviderZip.ShowDropDownOnTextboxClick = false;
                                listProviderZip.ShowToggleImage = false;

                                foreach ( RadComboBoxItem radComboBoxItem in listProviderZip.Items )
                                {
                                    radComboBoxItem.Enabled = false;
                                }

                                ProviderZipExtn.ReadOnly = true;
                                ProviderZipExtn.BackColor = System.Drawing.Color.LightGray;

                                MailStreetPOBox.ReadOnly = true;
                                MailStreetPOBox.BackColor = System.Drawing.Color.LightGray;

                                listMailState.ShowDropDownOnTextboxClick = false;
                                listMailState.ShowToggleImage = false;

                                foreach ( RadComboBoxItem radComboBoxItem in listMailState.Items )
                                {
                                    radComboBoxItem.Enabled = false;
                                }

                                listMailCity.ShowDropDownOnTextboxClick = false;
                                listMailCity.ShowToggleImage = false;

                                foreach ( RadComboBoxItem radComboBoxItem in listMailCity.Items )
                                {
                                    radComboBoxItem.Enabled = false;
                                }

                                listMailZip.ShowDropDownOnTextboxClick = false;
                                listMailZip.ShowToggleImage = false;

                                foreach ( RadComboBoxItem radComboBoxItem in listMailZip.Items )
                                {
                                    radComboBoxItem.Enabled = false;
                                }

                                MailZipExtn.ReadOnly = true;
                                MailZipExtn.BackColor = System.Drawing.Color.LightGray;

                                FacilityAdministrationPhone.ReadOnly = true;
                                FacilityAdministrationPhone.BackColor = System.Drawing.Color.LightGray;
                                FacilityAdministrationFax.ReadOnly = true;
                                FacilityAdministrationFax.BackColor = System.Drawing.Color.LightGray;
                                txtAdminEmail.ReadOnly = true;
                                txtAdminEmail.BackColor = System.Drawing.Color.LightGray;

                                listFiscalInt.ShowDropDownOnTextboxClick = false;
                                listFiscalInt.ShowToggleImage = false;

                                foreach ( RadComboBoxItem radComboBoxItem in listFiscalInt.Items )
                                {
                                    radComboBoxItem.Enabled = false;
                                }
                                txtFiscalYrEnd.ReadOnly = true;
                                txtFiscalYrEnd.BackColor = System.Drawing.Color.LightGray;

                                listAccrdBody.ShowDropDownOnTextboxClick = false;
                                listAccrdBody.ShowToggleImage = false;

                                foreach ( RadComboBoxItem radComboBoxItem in listAccrdBody.Items )
                                {
                                    radComboBoxItem.Enabled = false;
                                }
                                calAccrdExpDt.Enabled = false;

                                optFactype.Enabled = false;
                                txtRelatedProvider.ReadOnly = true;
                                txtRelatedProvider.BackColor = System.Drawing.Color.LightGray;
                            }
                            else
                            {
                                FacilityName.ReadOnly = false;
                                FacilityName.BackColor = System.Drawing.Color.White;
                                FacilityGeoStreetAddress.ReadOnly = false;
                                FacilityGeoStreetAddress.BackColor = System.Drawing.Color.White;

                                listProviderCity.ShowDropDownOnTextboxClick = true;
                                listProviderCity.ShowToggleImage = true;

                                foreach ( RadComboBoxItem radComboBoxItem in listProviderCity.Items )
                                {
                                    radComboBoxItem.Enabled = true;
                                }

                                listProviderParish.ShowDropDownOnTextboxClick = true;
                                listProviderParish.ShowToggleImage = true;

                                foreach ( RadComboBoxItem radComboBoxItem in listProviderParish.Items )
                                {
                                    radComboBoxItem.Enabled = true;
                                }

                                listProviderZip.ShowDropDownOnTextboxClick = true;
                                listProviderZip.ShowToggleImage = true;

                                foreach ( RadComboBoxItem radComboBoxItem in listProviderZip.Items )
                                {
                                    radComboBoxItem.Enabled = true;
                                }

                                ProviderZipExtn.ReadOnly = false;
                                ProviderZipExtn.BackColor = System.Drawing.Color.White;

                                MailStreetPOBox.ReadOnly = false;
                                MailStreetPOBox.BackColor = System.Drawing.Color.White;

                                listMailState.ShowDropDownOnTextboxClick = true;
                                listMailState.ShowToggleImage = true;

                                foreach ( RadComboBoxItem radComboBoxItem in listMailState.Items )
                                {
                                    radComboBoxItem.Enabled = true;
                                }

                                listMailCity.ShowDropDownOnTextboxClick = true;
                                listMailCity.ShowToggleImage = true;

                                foreach ( RadComboBoxItem radComboBoxItem in listMailCity.Items )
                                {
                                    radComboBoxItem.Enabled = true;
                                }

                                listMailZip.ShowDropDownOnTextboxClick = true;
                                listMailZip.ShowToggleImage = true;

                                foreach ( RadComboBoxItem radComboBoxItem in listMailZip.Items )
                                {
                                    radComboBoxItem.Enabled = true;
                                }

                                MailZipExtn.ReadOnly = false;
                                MailZipExtn.BackColor = System.Drawing.Color.White;

                                FacilityAdministrationPhone.ReadOnly = false;
                                FacilityAdministrationPhone.BackColor = System.Drawing.Color.White;
                                FacilityAdministrationFax.ReadOnly = false;
                                FacilityAdministrationFax.BackColor = System.Drawing.Color.White;
                                txtAdminEmail.ReadOnly = false;
                                txtAdminEmail.BackColor = System.Drawing.Color.White;

                                listFiscalInt.ShowDropDownOnTextboxClick = true;
                                listFiscalInt.ShowToggleImage = true;

                                foreach ( RadComboBoxItem radComboBoxItem in listFiscalInt.Items )
                                {
                                    radComboBoxItem.Enabled = true;
                                }
                                txtFiscalYrEnd.ReadOnly = false;
                                txtFiscalYrEnd.BackColor = System.Drawing.Color.White;

                                listAccrdBody.ShowDropDownOnTextboxClick = true;
                                listAccrdBody.ShowToggleImage = true;

                                foreach ( RadComboBoxItem radComboBoxItem in listAccrdBody.Items )
                                {
                                    radComboBoxItem.Enabled = true;
                                }
                                calAccrdExpDt.Enabled = true;

                                optFactype.Enabled = true;
                                txtRelatedProvider.ReadOnly = false;
                                txtRelatedProvider.BackColor = System.Drawing.Color.White;
                            }
                            break;
                        case "9": //KEY PERSONNEL CHANGES
                            FacilityName.ReadOnly = true;
                            FacilityName.BackColor = System.Drawing.Color.LightGray;
                            FacilityGeoStreetAddress.ReadOnly = true;
                            FacilityGeoStreetAddress.BackColor = System.Drawing.Color.LightGray;

                            listProviderCity.ShowDropDownOnTextboxClick = false;
                            listProviderCity.ShowToggleImage = false;

                            foreach ( RadComboBoxItem radComboBoxItem in listProviderCity.Items )
                            {
                                radComboBoxItem.Enabled = false;
                            }

                            listProviderParish.ShowDropDownOnTextboxClick = false;
                            listProviderParish.ShowToggleImage = false;

                            foreach ( RadComboBoxItem radComboBoxItem in listProviderParish.Items )
                            {
                                radComboBoxItem.Enabled = false;
                            }

                            listProviderZip.ShowDropDownOnTextboxClick = false;
                            listProviderZip.ShowToggleImage = false;

                            foreach ( RadComboBoxItem radComboBoxItem in listProviderZip.Items )
                            {
                                radComboBoxItem.Enabled = false;
                            }

                            ProviderZipExtn.ReadOnly = true;
                            ProviderZipExtn.BackColor = System.Drawing.Color.LightGray;

                            MailStreetPOBox.ReadOnly = true;
                            MailStreetPOBox.BackColor = System.Drawing.Color.LightGray;

                            listMailState.ShowDropDownOnTextboxClick = false;
                            listMailState.ShowToggleImage = false;

                            foreach ( RadComboBoxItem radComboBoxItem in listMailState.Items )
                            {
                                radComboBoxItem.Enabled = false;
                            }

                            listMailCity.ShowDropDownOnTextboxClick = false;
                            listMailCity.ShowToggleImage = false;

                            foreach ( RadComboBoxItem radComboBoxItem in listMailCity.Items )
                            {
                                radComboBoxItem.Enabled = false;
                            }

                            listMailZip.ShowDropDownOnTextboxClick = false;
                            listMailZip.ShowToggleImage = false;

                            foreach ( RadComboBoxItem radComboBoxItem in listMailZip.Items )
                            {
                                radComboBoxItem.Enabled = false;
                            }

                            MailZipExtn.ReadOnly = true;
                            MailZipExtn.BackColor = System.Drawing.Color.LightGray;

                            FacilityAdministrationPhone.ReadOnly = true;
                            FacilityAdministrationPhone.BackColor = System.Drawing.Color.LightGray;
                            FacilityAdministrationFax.ReadOnly = true;
                            FacilityAdministrationFax.BackColor = System.Drawing.Color.LightGray;
                            txtAdminEmail.ReadOnly = true;
                            txtAdminEmail.BackColor = System.Drawing.Color.LightGray;

                            listFiscalInt.ShowDropDownOnTextboxClick = false;
                            listFiscalInt.ShowToggleImage = false;

                            foreach ( RadComboBoxItem radComboBoxItem in listFiscalInt.Items )
                            {
                                radComboBoxItem.Enabled = false;
                            }
                            txtFiscalYrEnd.ReadOnly = true;
                            txtFiscalYrEnd.BackColor = System.Drawing.Color.LightGray;

                            listAccrdBody.ShowDropDownOnTextboxClick = false;
                            listAccrdBody.ShowToggleImage = false;

                            foreach ( RadComboBoxItem radComboBoxItem in listAccrdBody.Items )
                            {
                                radComboBoxItem.Enabled = false;
                            }
                            calAccrdExpDt.Enabled = false;

                            optFactype.Enabled = false;
                            txtRelatedProvider.ReadOnly = true;
                            txtRelatedProvider.BackColor = System.Drawing.Color.LightGray;
                            break;
                        case "10": //CHANGE OF SERVICE
                            FacilityName.ReadOnly = true;
                            FacilityName.BackColor = System.Drawing.Color.LightGray;
                            FacilityGeoStreetAddress.ReadOnly = true;
                            FacilityGeoStreetAddress.BackColor = System.Drawing.Color.LightGray;

                            listProviderCity.ShowDropDownOnTextboxClick = false;
                            listProviderCity.ShowToggleImage = false;

                            foreach ( RadComboBoxItem radComboBoxItem in listProviderCity.Items )
                            {
                                radComboBoxItem.Enabled = false;
                            }

                            listProviderParish.ShowDropDownOnTextboxClick = false;
                            listProviderParish.ShowToggleImage = false;

                            foreach ( RadComboBoxItem radComboBoxItem in listProviderParish.Items )
                            {
                                radComboBoxItem.Enabled = false;
                            }

                            listProviderZip.ShowDropDownOnTextboxClick = false;
                            listProviderZip.ShowToggleImage = false;

                            foreach ( RadComboBoxItem radComboBoxItem in listProviderZip.Items )
                            {
                                radComboBoxItem.Enabled = false;
                            }

                            ProviderZipExtn.ReadOnly = true;
                            ProviderZipExtn.BackColor = System.Drawing.Color.LightGray;

                            MailStreetPOBox.ReadOnly = true;
                            MailStreetPOBox.BackColor = System.Drawing.Color.LightGray;

                            listMailState.ShowDropDownOnTextboxClick = false;
                            listMailState.ShowToggleImage = false;

                            foreach ( RadComboBoxItem radComboBoxItem in listMailState.Items )
                            {
                                radComboBoxItem.Enabled = false;
                            }

                            listMailCity.ShowDropDownOnTextboxClick = false;
                            listMailCity.ShowToggleImage = false;

                            foreach ( RadComboBoxItem radComboBoxItem in listMailCity.Items )
                            {
                                radComboBoxItem.Enabled = false;
                            }

                            listMailZip.ShowDropDownOnTextboxClick = false;
                            listMailZip.ShowToggleImage = false;

                            foreach ( RadComboBoxItem radComboBoxItem in listMailZip.Items )
                            {
                                radComboBoxItem.Enabled = false;
                            }

                            MailZipExtn.ReadOnly = true;
                            MailZipExtn.BackColor = System.Drawing.Color.LightGray;

                            FacilityAdministrationPhone.ReadOnly = true;
                            FacilityAdministrationPhone.BackColor = System.Drawing.Color.LightGray;
                            FacilityAdministrationFax.ReadOnly = true;
                            FacilityAdministrationFax.BackColor = System.Drawing.Color.LightGray;
                            txtAdminEmail.ReadOnly = true;
                            txtAdminEmail.BackColor = System.Drawing.Color.LightGray;

                            listFiscalInt.ShowDropDownOnTextboxClick = false;
                            listFiscalInt.ShowToggleImage = false;

                            foreach ( RadComboBoxItem radComboBoxItem in listFiscalInt.Items )
                            {
                                radComboBoxItem.Enabled = false;
                            }
                            txtFiscalYrEnd.ReadOnly = true;
                            txtFiscalYrEnd.BackColor = System.Drawing.Color.LightGray;

                            listAccrdBody.ShowDropDownOnTextboxClick = false;
                            listAccrdBody.ShowToggleImage = false;

                            foreach ( RadComboBoxItem radComboBoxItem in listAccrdBody.Items )
                            {
                                radComboBoxItem.Enabled = false;
                            }
                            calAccrdExpDt.Enabled = false;

                            optFactype.Enabled = false;
                            txtRelatedProvider.ReadOnly = true;
                            txtRelatedProvider.BackColor = System.Drawing.Color.LightGray;
                            break;
                    }
                }
                else
                {
                    FacilityName.ReadOnly = true;
                    FacilityName.BackColor = System.Drawing.Color.LightGray;
                    FacilityGeoStreetAddress.ReadOnly = true;
                    FacilityGeoStreetAddress.BackColor = System.Drawing.Color.LightGray;

                    listProviderCity.ShowDropDownOnTextboxClick = false;
                    listProviderCity.ShowToggleImage = false;

                    foreach ( RadComboBoxItem radComboBoxItem in listProviderCity.Items )
                    {
                        radComboBoxItem.Enabled = false;
                    }

                    listProviderParish.ShowDropDownOnTextboxClick = false;
                    listProviderParish.ShowToggleImage = false;

                    foreach ( RadComboBoxItem radComboBoxItem in listProviderParish.Items )
                    {
                        radComboBoxItem.Enabled = false;
                    }

                    listProviderZip.ShowDropDownOnTextboxClick = false;
                    listProviderZip.ShowToggleImage = false;

                    foreach ( RadComboBoxItem radComboBoxItem in listProviderZip.Items )
                    {
                        radComboBoxItem.Enabled = false;
                    }

                    ProviderZipExtn.ReadOnly = true;
                    ProviderZipExtn.BackColor = System.Drawing.Color.LightGray;

                    MailStreetPOBox.ReadOnly = true;
                    MailStreetPOBox.BackColor = System.Drawing.Color.LightGray;

                    listMailState.ShowDropDownOnTextboxClick = false;
                    listMailState.ShowToggleImage = false;

                    foreach ( RadComboBoxItem radComboBoxItem in listMailState.Items )
                    {
                        radComboBoxItem.Enabled = false;
                    }

                    listMailCity.ShowDropDownOnTextboxClick = false;
                    listMailCity.ShowToggleImage = false;

                    foreach ( RadComboBoxItem radComboBoxItem in listMailCity.Items )
                    {
                        radComboBoxItem.Enabled = false;
                    }

                    listMailZip.ShowDropDownOnTextboxClick = false;
                    listMailZip.ShowToggleImage = false;

                    foreach ( RadComboBoxItem radComboBoxItem in listMailZip.Items )
                    {
                        radComboBoxItem.Enabled = false;
                    }

                    MailZipExtn.ReadOnly = true;
                    MailZipExtn.BackColor = System.Drawing.Color.LightGray;

                    FacilityAdministrationPhone.ReadOnly = true;
                    FacilityAdministrationPhone.BackColor = System.Drawing.Color.LightGray;
                    FacilityAdministrationFax.ReadOnly = true;
                    FacilityAdministrationFax.BackColor = System.Drawing.Color.LightGray;
                    txtAdminEmail.ReadOnly = true;
                    txtAdminEmail.BackColor = System.Drawing.Color.LightGray;

                    listFiscalInt.ShowDropDownOnTextboxClick = false;
                    listFiscalInt.ShowToggleImage = false;

                    foreach ( RadComboBoxItem radComboBoxItem in listFiscalInt.Items )
                    {
                        radComboBoxItem.Enabled = false;
                    }
                    txtFiscalYrEnd.ReadOnly = true;
                    txtFiscalYrEnd.BackColor = System.Drawing.Color.LightGray;

                    listAccrdBody.ShowDropDownOnTextboxClick = false;
                    listAccrdBody.ShowToggleImage = false;

                    foreach ( RadComboBoxItem radComboBoxItem in listAccrdBody.Items )
                    {
                        radComboBoxItem.Enabled = false;
                    }
                    calAccrdExpDt.Enabled = false;

                    optFactype.Enabled = false;
                    txtRelatedProvider.ReadOnly = true;
                    txtRelatedProvider.BackColor = System.Drawing.Color.LightGray;
                }
            }
        }

        private void _InitFields()
        {
            BO_Affiliation tmpAffiliation = null;
            BO_Program tmpPgm = BO_Program.SelectOne( new BO_ProgramPrimaryKey( CurrentAppProvider.ProgramID ) );
            ProviderType.Text = tmpPgm.ProgramDescription;

            if ( !IsOffSite )
            {
                //BO_Program tmpPgm = BO_Program.SelectOne( new BO_ProgramPrimaryKey( CurrentAppProvider.ProgramID ) );
                
                //SMM 01/22/2012 - No title case conversion for HCBS
                //SMM 02/01/2012 - All descritions have been setup in the database so now just load then up.
                //if ( CurrentAppProvider.ProgramID.Equals( "HC" ) )
                //    ProviderType.Text = tmpPgm.ProgramDescription;
                //else
                //    ProviderType.Text = CommonFunc.ConvertToTitleCase( tmpPgm.ProgramDescription );
                
                //SMM 01/22/2012 - Rmoved Title Case conversion
                //FacilityName.Text = CommonFunc.ConvertToTitleCase( CurrentAppProvider.FacilityName );
                FacilityName.Text = CurrentAppProvider.FacilityName;
                LicenseNum.Text = CurrentAppProvider.LicensureNum;
                StateID.Text = CurrentAppProvider.StateID;
                // SMM 02/06/2012 - New Control Only visible for offsite locations.
                lblCurLicIssueDt.Visible = false;
                txtCurLicIssueDt.Visible = false;

                listProvStatus.SelectedValue = CurrentAppProvider.StatusCode;
                txtProvStatusDate.SelectedDate = CurrentAppProvider.StatusDate;
                txtProvClosedDate.SelectedDate = CurrentAppProvider.ClosedDate;
                
                // rjc - 8/15/12 - open/closed dates only visible for offsite
                lblBranchStatus.Visible = false;
                listBranchStatus.Visible = false;
                lblBranchOpenDate.Visible = false;
                txtBranchOpenDate.Visible = false;
                lblBranchClosedDate.Visible = false;
                txtBranchClosedDate.Visible = false;

                FacilityAdministrationPhone.Text = CurrentAppProvider.TelephoneNumber;
                FacilityAdministrationFax.Text = CurrentAppProvider.FaxPhoneNumber;
                txtAdminEmail.Text = CurrentAppProvider.EmailAddress;

                //added for facility in facility fields
                if ("HO,NA".Contains(CurrentAppProvider.ProgramID))
                {
                    LblFacilityInFacilityYN.Visible = true;
                    DdlFacilityInFacilityYN.Visible = true;
                    if(CurrentAppProvider.FacilityWithinFacilityYN!=null)
                        DdlFacilityInFacilityYN.SelectedValue = CurrentAppProvider.FacilityWithinFacilityYN;
                    if (CurrentAppProvider.FacilityWithinFacilityYN == "Y")
                    {
                        TextBoxFacilityInFacility.Text = CurrentAppProvider.FacilityWithinFacility;
                        lblFacilityInFacilityDesc.Visible = true;
                        TextBoxFacilityInFacility.Visible = true;
                    }
                }

                if (CurrentAppProvider.ProgramID.Equals("NA"))
                {
                    lblLicenseNum.Text = "School/Facility Code";
                    LicenseNum.ReadOnly = false;
                }

                if (CurrentAppProvider.ProgramID.Equals("MT"))
                {
                    lblLicenseNum.Text = "State License #";
                }

                if(("MT,NE").Contains(CurrentAppProvider.ProgramID))
                {
                    RadMaskedTextBoxEmergencyPhone.Text = CurrentAppProvider.EmergencyPhoneNumber != null ? CurrentAppProvider.EmergencyPhoneNumber : ""; ;
                }

                _LoadSelectLists();
                _LoadAddresses();
                _LoadFiscalIntermediary();
                _LoadFacSubType();
                _LoadSpecialCases();

                /* removed till 12.5
                //get Application Support Table fields
                if (CurrentAppProvider.Application_Support.FnrApprovalDate != null)
                {
                    dpFNRApprovalDate.SelectedDate = CurrentAppProvider.Application_Support.FnrApprovalDate;
                }
                */
            }
            else
            {
                foreach ( BO_Affiliation tmpBA in CurrentAppProvider.BO_AffiliationsApplicationID )
                {
                    //if ( tmpBA.AffiliationID.Equals( CurrentAffiliationID ) )
                    if ( tmpBA.UI_TrackID.Equals( CurrentAffiliationID ) )
                    {
                        tmpAffiliation = tmpBA;
                        break;
                    }
                }

                BO_Affiliations affilHist = BO_Affiliation.SelectAllByPopsIntIDNotOnApplication
                                                            ( new BO_ProviderPrimaryKey(CurrentAppProvider.PopsIntID)
                                                              , new BO_ApplicationPrimaryKey(CurrentAppProvider.ApplicationID)
                                                             );

                IsNewOffsiteThisApp = true;

                foreach ( BO_Affiliation tmpHistAffil in affilHist )
                {
                    if ( tmpAffiliation.UI_TrackID.Equals(tmpHistAffil.UI_TrackID))
                    {
                        IsNewOffsiteThisApp = false;
                    }
                }

                //SMM 01/22/2012 - Rmoved Title Case conversion
                //FacilityName.Text = CommonFunc.ConvertToTitleCase( tmpAffiliation.FacilityName );
                FacilityName.Text = tmpAffiliation.FacilityName;

                if ( IsNewOffsiteThisApp )
                {
                    LicenseNumOffsitePostFix.Visible = true;
                    lblLicHyphen.Visible = true;

                    if ( string.IsNullOrEmpty( tmpAffiliation.LicensureNum ) )
                    {
                        LicenseNum.Text = CurrentAppProvider.LicensureNum;
                    }
                    else
                    {
                        string fullLicNum = tmpAffiliation.LicensureNum;
                        bool isRHC = fullLicNum.ToUpper().Contains("RHC");
                        string licNum = fullLicNum.Substring(0, fullLicNum.IndexOf("-"));
                        string offsitePostFix = fullLicNum.Substring(fullLicNum.IndexOf("-"),fullLicNum.Length-licNum.Length);

                        LicenseNum.Text = licNum.Replace("RHC", "").Replace("rhc", "");
                            if (isRHC)
                            {
                                txtRHC.Visible = true;
                                txtRHC.Enabled = false;
                                txtRHC.Style.Add( HtmlTextWriterStyle.Color, "BLACK" );
                                txtRHC.Text = "RHC";
                            }
                         LicenseNumOffsitePostFix.Text = offsitePostFix.Replace("-", "").Replace("RHC", "").Replace("rhc", "");
                    }
                }
                else
                {
                    LicenseNum.Text = tmpAffiliation.LicensureNum;
                }

                StateID.Text = CurrentAppProvider.StateID;
                //SMM 02/06/2012 - Added Current License Issue Date
                lblCurLicIssueDt.Visible = true;
                txtCurLicIssueDt.Visible = true;

                // rjc - 8/1/12 - current lic issue date must always be the app's current lic issue date.
                // since tmpAffiliation is loaded when app is 1st loaded, if use changes app's
                // current lic issue date, saves, then goes to affiliation screen, ths date's wrong.
                //txtCurLicIssueDt.SelectedDate = tmpAffiliation.CurrentLicIssueDate;
                txtCurLicIssueDt.SelectedDate = CurrentAppProvider.CurrentLicIssueDate;
                dpLicenseExpirationDate.SelectedDate = CurrentAppProvider.LicensureExpirationDate;
                dpLicenseExpirationDate.Enabled = false;

                dpOffsiteOriginalLicenseIssueDate.SelectedDate = tmpAffiliation.OffsiteOrigLicensureDate;
                dpOffSiteCurrentLicenseIssueDate.SelectedDate = tmpAffiliation.OffsiteCurrentLicIssueDate;
                dpOffSiteLicenseEffectiveDate.SelectedDate = tmpAffiliation.OffsiteLicEffectiveDate;

                //added to remove aco dependency 06-28-2019 ST
                txtBranchID.Text = tmpAffiliation.BranchID.ToString();
                txtMedicareBranchID.Text = tmpAffiliation.MedicareBranchID;

                //use validation rules to set override check boxes.  
                //validate rules for dates offsite additions
                var processidlist = new List<string> { "11", "7", "5", "10", "8" };

                if (processidlist.Contains(CurrentAppProvider.BusinessProcessID))
                {
                    //validation rule only applies for new offsite addition
                    if (CurrentAppProvider.BusinessProcessID == "8")
                    {
                        if (dpOffsiteOriginalLicenseIssueDate.SelectedDate != null)
                        {
                            if (((DateTime)dpOffsiteOriginalLicenseIssueDate.SelectedDate) < DateTime.Now.AddDays(-180))
                            {
                                chkOffSiteOriginalLicenseIssueDate.Checked = true;
                            }
                        }
                    }

                    if (dpOffSiteCurrentLicenseIssueDate.SelectedDate != null)
                    {
                        if (((DateTime)dpOffSiteCurrentLicenseIssueDate.SelectedDate) < DateTime.Now.AddDays(-30) || ((DateTime)dpOffSiteCurrentLicenseIssueDate.SelectedDate) > DateTime.Now.AddDays(30))
                        {
                            chkOffSiteCurrentLicenseIssueDate.Checked = true;
                        }
                    }
                    if (dpOffsiteOriginalLicenseIssueDate.SelectedDate != null)
                    {
                        if (dpOffSiteLicenseEffectiveDate.SelectedDate != null)
                        {
                            if (((DateTime)dpOffSiteLicenseEffectiveDate.SelectedDate) < ((DateTime)dpOffsiteOriginalLicenseIssueDate.SelectedDate))
                            {
                                chkOffSiteLicenseEffectiveDate.Checked = true;
                            }
                        }
                    }
                }

                // rjc - 8/1/12 - since current lic issue date must always be the app's current lic 
                // issue date, disable for all offsites
                //if (CurrentAppProvider.ApplicationStatus.Equals( "4" ) )
                // rjc - 08/27/2012 - if business process is an 8 (offsite addition), then dates is editable
                //txtCurLicIssueDt.Enabled = false;
                txtCurLicIssueDt.Enabled = (CurrentAppProvider.BusinessProcessID == "8");

                lblProvStatus.Visible = false;
                listProvStatus.Visible = false;
                lblProvStatusDate.Visible = false;
                txtProvStatusDate.Visible = false;
                lblProvClosedDate.Visible = false;
                txtProvClosedDate.Visible = false;

                // rjc - 8/15/12 - open/closed dates only visible for offsite
                lblBranchStatus.Visible = true;
                listBranchStatus.Visible = true;
                lblBranchOpenDate.Visible = true;
                txtBranchOpenDate.Visible = true;
                lblBranchClosedDate.Visible = true;
                txtBranchClosedDate.Visible = true;
                lblBranchID.Visible = true;
                txtBranchID.Visible = true;
                lblMedicareBranchID.Visible = true;
                txtMedicareBranchID.Visible = true;
                listBranchStatus.SelectedValue = tmpAffiliation.OperStatCode;
                txtBranchOpenDate.SelectedDate = tmpAffiliation.OpenedDate;
                txtBranchClosedDate.SelectedDate = tmpAffiliation.ClosedDate;

                FacilityAdministrationPhone.Text = tmpAffiliation.TelephoneNumber;
                FacilityAdministrationFax.Text = tmpAffiliation.FaxPhoneNumber;
        
                _LoadSelectLists();
                _LoadAddresses();
                _LoadSpecialCases();

                //Hide unused controls
                DivMailAddrHeader.Visible = false;
                FacTableMailAddr.Visible = false;
                lblAdminEmail.Visible = false;
                txtAdminEmail.Visible = false;
                DivFIHeader.Visible = false;
                FacTableFI.Visible = false;
                DivFacSubtypeHeader.Visible = false;
                optFactype.Visible = false;
            }
        }

        private void _LoadAddresses()
        {
            if ( null != CurrentAppProvider.BO_AddressesApplicationID && !IsOffSite )
            {
                foreach ( BO_Address addr in CurrentAppProvider.BO_AddressesApplicationID )
                {
                    if ( null != addr.PopsIntID && addr.AddressType == 1 ) //Physical
                    {
                        //SMM 01/22/2012 - Rmoved Title Case conversion
                        //FacilityGeoStreetAddress.Text = CommonFunc.ConvertToTitleCase( addr.Street );
                        FacilityGeoStreetAddress.Text = addr.Street;


                        if ((null != addr.StateCode && !addr.StateCode.Equals("")) && (null != addr.City && !addr.City.Equals("")))
                        {
                            listProviderParish.AppendDataBoundItems = true;
                            listProviderParish.Items.Add(new RadComboBoxItem("", ""));
                            listProviderParish.DataSource = BO_Ziplookup.SelectParishes(addr.StateCode, addr.City);
                            listProviderParish.DataTextField = "CNTYNAME";
                            listProviderParish.DataValueField = "COUNTY";
                            listProviderParish.Height = Unit.Pixel(100);
                            listProviderParish.DataBind();

                            listProviderParish.SelectedValue = addr.ParishCode;
                        }

                        if (null != addr.StateCode && !addr.StateCode.Equals(""))
                        {

                            listProviderState.SelectedValue = addr.StateCode;
                            listProviderCity.DataSource = CommonFunc.getCitiesByState(listProviderState.SelectedValue);
                        }

                        listProviderCity.AppendDataBoundItems = true;
                        listProviderCity.Items.Add(new RadComboBoxItem("", ""));
                        listProviderCity.DataTextField = "City";
                        listProviderCity.DataValueField = "City";
                        listProviderCity.Height = Unit.Pixel(100);
                        listProviderCity.DataBind();

                        if ( null != addr.City && !addr.City.Equals( "" ) )
                        {
                            listProviderCity.SelectedValue = addr.City.ToUpper();
                            listProviderZip.DataSource = CommonFunc.getZipByCityState( addr.City, listProviderState.SelectedValue );
                        }
                        else
                        {
                            listProviderZip.DataSource = CommonFunc.getZipByCityState( listProviderCity.SelectedValue, listProviderState.SelectedValue );
                        }
                        ProviderZipExtn.Text = addr.ZipCodeExtended;

                        listProviderZip.AppendDataBoundItems = true;
                        listProviderZip.Items.Add(new RadComboBoxItem("", ""));
                        listProviderZip.DataTextField = "ZIP";
                        listProviderZip.DataValueField = "ZIP";
                        listProviderZip.Height = Unit.Pixel( 100 );
                        listProviderZip.DataBind();

                        if ( null != addr.ZipCode && !addr.ZipCode.Equals( "" ) )
                            listProviderZip.SelectedValue = addr.ZipCode.Substring( 0, 5 );

                    }
                    else if ( null != addr.PopsIntID && addr.AddressType == 2 ) //Mail
                    {
                        //SMM 01/22/2012- Removed Title case conversion
                        //MailStreetPOBox.Text = CommonFunc.ConvertToTitleCase( addr.Street );
                        MailStreetPOBox.Text = addr.Street;

                        if ( null != addr.State && !addr.State.Equals( "" ) )
                        {
                            listMailState.SelectedValue = addr.StateCode;
                            listMailCity.DataSource = CommonFunc.getCitiesByState( addr.StateCode );
                        }
                        else
                        {
                            listMailCity.DataSource = CommonFunc.getCitiesByState( listMailState.SelectedValue );
                        }
                        MailZipExtn.Text = addr.ZipCodeExtended;

                        listMailCity.AppendDataBoundItems = true;
                        listMailCity.Items.Add( new RadComboBoxItem( "", "" ) );
                        listMailCity.DataTextField = "City";
                        listMailCity.DataValueField = "City";
                        listMailCity.Height = Unit.Pixel( 100 );
                        listMailCity.DataBind();

                        if ( null != addr.City && !addr.City.Equals( "" ) )
                        {
                            listMailCity.SelectedValue = addr.City.ToUpper();
                            listMailZip.DataSource = CommonFunc.getZipByCityState( addr.City, listMailState.SelectedValue );
                        }
                        else
                        {
                            listMailZip.DataSource = CommonFunc.getZipByCityState( listMailCity.SelectedValue, listMailState.SelectedValue );
                        }

                        listMailZip.AppendDataBoundItems = true;
                        listMailZip.Items.Add( new RadComboBoxItem( "", "" ) );
                        listMailZip.DataTextField = "ZIP";
                        listMailZip.DataValueField = "ZIP";
                        listMailZip.Height = Unit.Pixel( 100 );
                        listMailZip.DataBind();

                        if ( null != addr.ZipCode && !addr.ZipCode.Equals( "" ) )
                            listMailZip.SelectedValue = addr.ZipCode.Substring( 0, 5 );

                        //listMailCity.SelectedValue = addr.City.ToUpper();
                        //listMailState.SelectedValue = addr.State;
                    }
                }
            }
            //else if ( IsOffSite && CurrentAffiliationID > 0 )
            else if ( IsOffSite && null != CurrentAffiliationID )
            {
                BO_Affiliation tmpAffiliation = null;

                foreach ( BO_Affiliation tmpBA in CurrentAppProvider.BO_AffiliationsApplicationID )
                {
                    //if ( tmpBA.AffiliationID.Equals( CurrentAffiliationID ) )
                    if ( tmpBA.UI_TrackID.Equals( CurrentAffiliationID ) )
                    {
                        tmpAffiliation = tmpBA;
                        break;
                    }
                }

                if ( null != tmpAffiliation.BO_AddressAffiliationID )
                {
                    //SMM 01/22/2012- Removed Title case conversion
                    //FacilityGeoStreetAddress.Text = CommonFunc.ConvertToTitleCase( tmpAffiliation.BO_AddressAffiliationID.Street );
                    FacilityGeoStreetAddress.Text = tmpAffiliation.BO_AddressAffiliationID.Street;

                    if ((null != tmpAffiliation.BO_AddressAffiliationID.StateCode && !tmpAffiliation.BO_AddressAffiliationID.StateCode.Equals("")))
                    {
                     listProviderState.SelectedValue = tmpAffiliation.BO_AddressAffiliationID.StateCode;
                     listProviderCity.DataSource = CommonFunc.getCitiesByState(listProviderState.SelectedValue);
                     listProviderCity.AppendDataBoundItems = true;
                     listProviderCity.Items.Add(new RadComboBoxItem("", ""));
                     listProviderCity.DataTextField = "City";
                     listProviderCity.DataValueField = "City";
                     listProviderCity.Height = Unit.Pixel(100);
                     listProviderCity.DataBind();
                    }

                    if ( null != tmpAffiliation.BO_AddressAffiliationID.City && !tmpAffiliation.BO_AddressAffiliationID.City.Equals( "" ) )
                    {
                        listProviderCity.SelectedValue = tmpAffiliation.BO_AddressAffiliationID.City.ToUpper();
                        listProviderZip.DataSource = CommonFunc.getZipByCityState( tmpAffiliation.BO_AddressAffiliationID.City, tmpAffiliation.BO_AddressAffiliationID.State );
                    }

                    if ((null != tmpAffiliation.BO_AddressAffiliationID.StateCode && !tmpAffiliation.BO_AddressAffiliationID.StateCode.Equals("")) && (null != tmpAffiliation.BO_AddressAffiliationID.City && !tmpAffiliation.BO_AddressAffiliationID.City.Equals("")))
                    {
                        listProviderParish.AppendDataBoundItems = true;
                        listProviderParish.Items.Add(new RadComboBoxItem("", ""));
                        listProviderParish.DataSource = BO_Ziplookup.SelectParishes(tmpAffiliation.BO_AddressAffiliationID.StateCode, tmpAffiliation.BO_AddressAffiliationID.City);
                        listProviderParish.DataTextField = "CNTYNAME";
                        listProviderParish.DataValueField = "COUNTY";
                        listProviderParish.Height = Unit.Pixel(100);
                        listProviderParish.DataBind();

                        listProviderParish.SelectedValue = tmpAffiliation.BO_AddressAffiliationID.ParishCode;
                    }

                    int tmpRslt = 0;
                    
                    if ( Int32.TryParse(tmpAffiliation.BO_AddressAffiliationID.ZipCodeExtended, out tmpRslt) )
                        ProviderZipExtn.Text = tmpRslt.ToString();

                    listProviderZip.AppendDataBoundItems = true;
                    listProviderZip.Items.Add( new RadComboBoxItem( "", "" ) );
                    listProviderZip.DataTextField = "ZIP";
                    listProviderZip.DataValueField = "ZIP";
                    listProviderZip.Height = Unit.Pixel( 100 );
                    listProviderZip.DataBind();

                    if ( null != tmpAffiliation.BO_AddressAffiliationID.ZipCode && !tmpAffiliation.BO_AddressAffiliationID.ZipCode.Equals( "" ) )
                        listProviderZip.SelectedValue = tmpAffiliation.BO_AddressAffiliationID.ZipCode.Substring( 0, 5 );
                }
            }
        }
        
        private void _LoadFacSubType()
        {
            BO_LookupValues lkups = BO_LookupValue.SelectByField( BO_LookupValueFields.LookupKey, "TYPE_FACILITY" );
            optFactype.Items.Clear();

            foreach ( BO_LookupValue lkupval in lkups )
            {
                if ( lkupval.Allowedtypes.Contains( CurrentAppProvider.ProgramID ) )
                {
                    ListItem tmpItm = new ListItem();
                    optFactype.Items.Add( tmpItm );
                    optFactype.Font.Size = FontUnit.Point( 10 );
                    optFactype.Width = Unit.Percentage( 100 );
                    optFactype.Style.Add( HtmlTextWriterStyle.MarginLeft, "10px" );
                    tmpItm.Text = lkupval.Valdesc;
                    tmpItm.Value = lkupval.LookupVal;
                }
            }

            if ( CurrentAppProvider.TypeFacility != null && !CurrentAppProvider.TypeFacility.Equals( "" ) )
                optFactype.SelectedValue = CurrentAppProvider.TypeFacility;

        }

        private void _LoadFiscalIntermediary()
        {
            //listFiscalInt.AppendDataBoundItems = true;
            //listFiscalInt.Items.Add( new RadComboBoxItem( "", "" ) );
            //listFiscalInt.DataSource = FILookups;
            //listFiscalInt.DataTextField = "Valdesc";
            //listFiscalInt.DataValueField = "LookupVal";
            //listFiscalInt.Height = Unit.Pixel( 100 );
            //listFiscalInt.DataBind();

            if ( CurrentAppProvider.FiscalIntermediaryNum != null && !CurrentAppProvider.FiscalIntermediaryNum.Equals( "" ) )
                listFiscalInt.SelectedValue = CurrentAppProvider.FiscalIntermediaryNum;

            if ( CurrentAppProvider.ForYearEndingDate != null && !CurrentAppProvider.ForYearEndingDate.Equals( "" ) )
                txtFiscalYrEnd.Text = CurrentAppProvider.ForYearEndingDate.ToString();
                //listFiscalYrEnd.SelectedValue = _m_AppProvider.ForYearEndingDate.ToString();

            if ( CurrentAppProvider.AccreditedBody != null && !CurrentAppProvider.AccreditedBody.Equals( "" ) )
                listAccrdBody.SelectedValue = CurrentAppProvider.AccreditedBody;

            DateTime tmpDT;
            if ( DateTime.TryParse( CurrentAppProvider.AccreditationExpirationDate.ToString(), out tmpDT ) )
                calAccrdExpDt.SelectedDate = tmpDT;

        }

        /// <summary>
        /// Special Cases like fields only applicable to specific Provider Types
        /// </summary>
        /// 

        private DataTable RegionLookups
        {
            get
            {
                DataTable tmpRegionWorkingTbl = new DataTable();

                if (Session["RegionLookups"] == null)
                {
                    DataColumn tmpDataCol = null;

                    tmpDataCol = new DataColumn("RegionName");
                    tmpRegionWorkingTbl.Columns.Add(tmpDataCol);
                    tmpDataCol = new DataColumn("RegionCode");
                    tmpRegionWorkingTbl.Columns.Add(tmpDataCol);

                    BO_Regions tmpLkups = BO_Region.SelectAll();

                    foreach (BO_Region boRgn in tmpLkups)
                    {
                        DataRow tmpRW = tmpRegionWorkingTbl.NewRow();

                        tmpRW["RegionName"] = boRgn.RegionName;
                        tmpRW["RegionCode"] = boRgn.RegionCode;

                        tmpRegionWorkingTbl.Rows.Add(tmpRW);
                    }

                    Session["RegionLookups"] = tmpRegionWorkingTbl;

                }
                else
                    tmpRegionWorkingTbl = (DataTable)Session["RegionLookups"];

                return tmpRegionWorkingTbl;
            }
            set
            {
                Session["RegionLookups"] = value;
            }
        }

        private DataTable FieldOfficeLookups
        {
            get
            {
                DataTable tmpLkupWorkingTbl = new DataTable();

                if (Session["FieldOfficeLookups"] == null)
                {
                    if (CurrentAppProvider != null)
                    {
                        DataColumn tmpDataCol = null;

                        tmpDataCol = new DataColumn("Valdesc");
                        tmpLkupWorkingTbl.Columns.Add(tmpDataCol);
                        tmpDataCol = new DataColumn("LookupVal");
                        tmpLkupWorkingTbl.Columns.Add(tmpDataCol);

                        BO_LookupValues tmpLkups = BO_LookupValue.SelectByField(BO_LookupValueFields.LookupKey, "FIELD_OFFICE");

                        foreach (BO_LookupValue tmpLV in tmpLkups)
                        {
                            if (tmpLV.Allowedtypes == null || tmpLV.Allowedtypes.Contains(CurrentAppProvider.ProgramID))
                            {
                                DataRow tmpRW = tmpLkupWorkingTbl.NewRow();

                                tmpRW["Valdesc"] = tmpLV.Valdesc;
                                tmpRW["LookupVal"] = tmpLV.LookupVal;

                                tmpLkupWorkingTbl.Rows.Add(tmpRW);
                            }
                        }
                    }

                    Session["FieldOfficeLookups"] = tmpLkupWorkingTbl;
                }
                else
                    tmpLkupWorkingTbl = (DataTable)Session["FieldOfficeLookups"];

                return tmpLkupWorkingTbl;
            }
            set
            {
                Session["FieldOfficeLookups"] = value;
            }
        }

        private void _LoadSpecialCases()
        {
            // Related Provider License # is only visible for Rural Health Clinics
            txtRelatedProvider.Text = CurrentAppProvider.RelatedProviderLicensureNum;
            if (CurrentAppProvider.ProgramID.Equals("RH"))
            {
                txtRelatedProvider.Visible = true;
                lblRelatedProvider.Visible = true;
            }
            else
            {
                txtRelatedProvider.Visible = false;
                lblRelatedProvider.Visible = false;
            }

            if ( CurrentAppProvider.ProgramID.Equals( "HC" ) )
            {
                if ( !IsOffSite )
                {
                    if ( null != CurrentAppProvider.DeemedStatus )
                        chkStatusAccred.Checked = (CurrentAppProvider.DeemedStatus.Equals( "1" ) ? true : false);

                    if ( null != CurrentAppProvider.TypeOfClients )
                    {
                        if ( CurrentAppProvider.TypeOfClients.Equals( "8" ) )
                            optPopSrvBoth.Checked = true;
                        else if ( CurrentAppProvider.TypeOfClients.Equals( "6" ) )
                            optPopSrvMale.Checked = true;
                        else if ( CurrentAppProvider.TypeOfClients.Equals( "7" ) )
                            optPopSrvFemale.Checked = true;
                    }

                    txtAgeFrom.Text = ( null != CurrentAppProvider.AgeRangeFrom ? CurrentAppProvider.AgeRangeFrom.Value.ToString() : "" );
                    txtAgeTo.Text = ( null != CurrentAppProvider.AgeRangeTO ? CurrentAppProvider.AgeRangeTO.Value.ToString() : "" );
                    
                }
                else
                {
                    FacTableAccredit.Visible = false;
                    DivAccred.Visible = false;

                    foreach ( BO_Affiliation tmpBA in CurrentAppProvider.BO_AffiliationsApplicationID )
                    {
                        //if ( tmpBA.AffiliationID.Equals( CurrentAffiliationID ) )
                        if ( tmpBA.UI_TrackID.Equals( CurrentAffiliationID ) )
                        {
                            if ( null != tmpBA.TypeOfClients )
                            {
                                if ( tmpBA.TypeOfClients.Equals( "8" ) )
                                    optPopSrvBoth.Checked = true;
                                else if ( tmpBA.TypeOfClients.Equals( "6" ) )
                                    optPopSrvMale.Checked = true;
                                else if ( tmpBA.TypeOfClients.Equals( "7" ) )
                                    optPopSrvFemale.Checked = true;
                            }

                            txtAgeFrom.Text = ( null != tmpBA.AgeRangeFrom ? tmpBA.AgeRangeFrom.Value.ToString() : "" );
                            txtAgeTo.Text = ( null != tmpBA.AgeRangeTO ? tmpBA.AgeRangeTO.Value.ToString() : "" );
                            rcbAffiliationType.SelectedValue = tmpBA.TypeAffiliation;
                            
                            break;
                        }
                    }
                }
            }

            if ( CurrentAppProvider.ProgramID.Equals( "BR" ) )
            {
                if ( !IsOffSite )
                {
                    if ( null != CurrentAppProvider.BO_ServicesApplicationID )
                    {
                        foreach ( BO_Service tmpSvc in CurrentAppProvider.BO_ServicesApplicationID )
                        {
                            switch ( tmpSvc.ServiceType )
                            {
                                case "01": //Residential
                                    chkBR_Residential.Checked = true;
                                    txtBR_ResCapacity.Text = tmpSvc.Capacity.Value.ToString();
                                    break;
                                case "02": //Community Living
                                    chkBR_CommLiving.Checked = true;
                                    break;
                                case "03": //Outpatient
                                    chkBR_Outpatient.Checked = true;
                                    CheckBoxDayOfOperationMon.Checked = ( null != tmpSvc.DayOfOperationMon && tmpSvc.DayOfOperationMon.Equals( "1" ) );
                                    CheckBoxDayOfOperationTue.Checked = ( null != tmpSvc.DayOfOperationTue && tmpSvc.DayOfOperationTue.Equals( "1" ) );
                                    CheckBoxDayOfOperationWed.Checked = ( null != tmpSvc.DayOfOperationWed && tmpSvc.DayOfOperationWed.Equals( "1" ) );
                                    CheckBoxDayOfOperationThu.Checked = ( null != tmpSvc.DayOfOperationThu && tmpSvc.DayOfOperationThu.Equals( "1" ) );
                                    CheckBoxDayOfOperationFri.Checked = ( null != tmpSvc.DayOfOperationFri && tmpSvc.DayOfOperationFri.Equals( "1" ) );
                                    CheckBoxDayOfOperationSat.Checked = ( null != tmpSvc.DayOfOperationSat && tmpSvc.DayOfOperationSat.Equals( "1" ) );
                                    CheckBoxDayOfOperationSun.Checked = ( null != tmpSvc.DayOfOperationSun && tmpSvc.DayOfOperationSun.Equals( "1" ) );

                                    txtHoursMinutesFrom.Text = ( null != tmpSvc.OperatingHoursFromTime ? tmpSvc.OperatingHoursFromTime : "" );
                                    listAmPmFrom.SelectedValue = ( null != tmpSvc.OperatingHoursFromMeridiem ? tmpSvc.OperatingHoursFromMeridiem : "" );
                                    txtHoursMinutesTo.Text = ( null != tmpSvc.OperatingHoursToTime ? tmpSvc.OperatingHoursToTime : "" );
                                    listAmPmTo.SelectedValue = ( null != tmpSvc.OperatingHoursToMeridiem ? tmpSvc.OperatingHoursToMeridiem : "" );
                                    break;
                            }
                        }
                    }

                    if ( null != CurrentAppProvider.TypeOfClients )
                    {
                        if ( CurrentAppProvider.TypeOfClients.Equals( "8" ) )
                            optPopSrvBoth.Checked = true;
                        else if ( CurrentAppProvider.TypeOfClients.Equals( "6" ) )
                            optPopSrvMale.Checked = true;
                        else if ( CurrentAppProvider.TypeOfClients.Equals( "7" ) )
                            optPopSrvFemale.Checked = true;
                    }

                    txtAgeFrom.Text = ( null != CurrentAppProvider.AgeRangeFrom ? CurrentAppProvider.AgeRangeFrom.Value.ToString() : "" );
                    txtAgeTo.Text = ( null != CurrentAppProvider.AgeRangeTO ? CurrentAppProvider.AgeRangeTO.Value.ToString() : "" );

                }
                else
                {
                    tblComLiving.Visible = false;

                    foreach ( BO_Affiliation tmpAffil in CurrentAppProvider.BO_AffiliationsApplicationID )
                    {
                        if ( tmpAffil.UI_TrackID.Equals( CurrentAffiliationID ) && null != tmpAffil.BO_ServicesAffiliationID )
                        {
                            foreach ( BO_Service tmpSvc in tmpAffil.BO_ServicesAffiliationID )
                            {
                                switch ( tmpSvc.ServiceType )
                                {
                                    case "01": //Residential
                                        chkBR_Residential.Checked = true;
                                        txtBR_ResCapacity.Text = tmpSvc.Capacity.Value.ToString();
                                        break;
                                    case "02": //Community Living
                                        chkBR_CommLiving.Checked = true;
                                        break;
                                    case "03": //Outpatient
                                        chkBR_Outpatient.Checked = true;
                                        CheckBoxDayOfOperationMon.Checked = ( null != tmpSvc.DayOfOperationMon && tmpSvc.DayOfOperationMon.Equals( "1" ) );
                                        CheckBoxDayOfOperationTue.Checked = ( null != tmpSvc.DayOfOperationTue && tmpSvc.DayOfOperationTue.Equals( "1" ) );
                                        CheckBoxDayOfOperationWed.Checked = ( null != tmpSvc.DayOfOperationWed && tmpSvc.DayOfOperationWed.Equals( "1" ) );
                                        CheckBoxDayOfOperationThu.Checked = ( null != tmpSvc.DayOfOperationThu && tmpSvc.DayOfOperationThu.Equals( "1" ) );
                                        CheckBoxDayOfOperationFri.Checked = ( null != tmpSvc.DayOfOperationFri && tmpSvc.DayOfOperationFri.Equals( "1" ) );
                                        CheckBoxDayOfOperationSat.Checked = ( null != tmpSvc.DayOfOperationSat && tmpSvc.DayOfOperationSat.Equals( "1" ) );
                                        CheckBoxDayOfOperationSun.Checked = ( null != tmpSvc.DayOfOperationSun && tmpSvc.DayOfOperationSun.Equals( "1" ) );

                                        txtHoursMinutesFrom.Text = ( null != tmpSvc.OperatingHoursFromTime ? tmpSvc.OperatingHoursFromTime : "" );
                                        listAmPmFrom.SelectedValue = ( null != tmpSvc.OperatingHoursFromMeridiem ? tmpSvc.OperatingHoursFromMeridiem : "" );
                                        txtHoursMinutesTo.Text = ( null != tmpSvc.OperatingHoursToTime ? tmpSvc.OperatingHoursToTime : "" );
                                        listAmPmTo.SelectedValue = ( null != tmpSvc.OperatingHoursToMeridiem ? tmpSvc.OperatingHoursToMeridiem : "" );
                                        break;
                                }
                            }
                        }

                        if ( tmpAffil.UI_TrackID.Equals( CurrentAffiliationID ) )
                        {
                            if ( null != tmpAffil.TypeOfClients )
                            {
                                if ( tmpAffil.TypeOfClients.Equals( "8" ) )
                                    optPopSrvBoth.Checked = true;
                                else if ( tmpAffil.TypeOfClients.Equals( "6" ) )
                                    optPopSrvMale.Checked = true;
                                else if ( tmpAffil.TypeOfClients.Equals( "7" ) )
                                    optPopSrvFemale.Checked = true;
                            }

                            txtAgeFrom.Text = ( null != tmpAffil.AgeRangeFrom ? tmpAffil.AgeRangeFrom.Value.ToString() : "" );
                            txtAgeTo.Text = ( null != tmpAffil.AgeRangeTO ? tmpAffil.AgeRangeTO.Value.ToString() : "" );

                            break;
                        }
                    }
                }
            }

            if ( CurrentAppProvider.ProgramID.Equals( "HP" ) )
            {
                if ( !IsOffSite )
                {
                    listHP_ProviderType.SelectedValue = ( null != CurrentAppProvider.TypeFacility ? CurrentAppProvider.TypeFacility : "" );
                    listHP_Accred.SelectedValue = ( null != CurrentAppProvider.AccreditedBody ? CurrentAppProvider.AccreditedBody : "" );
                    listMedicareCertified.SelectedValue = ( null != CurrentAppProvider.EnrolledInMedicaidYN ? CurrentAppProvider.EnrolledInMedicaidYN : "" );
                    listHP_HospitalBased.SelectedValue = ( null != CurrentAppProvider.HospitalBasedYN ? CurrentAppProvider.HospitalBasedYN : "" );
                    txtHP_FYE.Text = ( null != CurrentAppProvider.ForYearEndingDate ? CurrentAppProvider.ForYearEndingDate : "" );
                }
                else
                {
                    foreach ( BO_Affiliation tmpAffil in CurrentAppProvider.BO_AffiliationsApplicationID )
                    {
                        if ( tmpAffil.UI_TrackID.Equals( CurrentAffiliationID ) && null != tmpAffil.BO_ServicesAffiliationID )
                        {
                            listHP_ProviderType.SelectedValue = ( null != tmpAffil.TypeFacility ? tmpAffil.TypeFacility : "" );                            
                        }
                    }
                }
            }

            if ( CurrentAppProvider.ProgramID.Equals( "HH" ) )
            {
                if ( !IsOffSite )
                {
                    listHH_Accred.SelectedValue = ( null != CurrentAppProvider.AccreditedBody ? CurrentAppProvider.AccreditedBody : "" );
                    listHH_Deemed.SelectedValue = ( null != CurrentAppProvider.DeemedStatus ? CurrentAppProvider.DeemedStatus : "" );
                    listHH_HospBased.SelectedValue = ( null != CurrentAppProvider.HospitalBasedYN ? CurrentAppProvider.HospitalBasedYN : "" );
                    txtHH_FYE.Text = ( null != CurrentAppProvider.ForYearEndingDate ? CurrentAppProvider.ForYearEndingDate : "" );
                }
            }

            if ( CurrentAppProvider.ProgramID.Equals( "PD" ) )
            {
                if ( !IsOffSite )
                {
                    txtAgeFrom.Text = ( null != CurrentAppProvider.AgeRangeFrom ? CurrentAppProvider.AgeRangeFrom.Value.ToString() : "" );
                    txtAgeTo.Text = ( null != CurrentAppProvider.AgeRangeTO ? CurrentAppProvider.AgeRangeTO.Value.ToString() : "" );
                }
            }

            //SMM 05/28/2012 - Removed, not needed
            //if ( CurrentAppProvider.ProgramID.Equals( "WA" ) )
            //{
            //    if ( !IsOffSite )
            //    {
            //        txtAgeFrom.Text = ( null != CurrentAppProvider.AgeRangeFrom ? CurrentAppProvider.AgeRangeFrom.Value.ToString() : "" );
            //        txtAgeTo.Text = ( null != CurrentAppProvider.AgeRangeTO ? CurrentAppProvider.AgeRangeTO.Value.ToString() : "" );
            //    }
            //}

            if (("AC,MT,NE").Contains(CurrentAppProvider.ProgramID))
            {
                if ( !IsOffSite )
                {
                    if ( !string.IsNullOrEmpty( CurrentAppProvider.TypeFacility ) )
                        listAC_TypeFacility.SelectedValue = CurrentAppProvider.TypeFacility;
                }
            }

            if ( CurrentAppProvider.ProgramID.Equals( "CM" ) )
            {
                if ( !IsOffSite )
                {
                    if ( !string.IsNullOrEmpty( CurrentAppProvider.TypeOfClients ) )
                        listTypeClient.SelectedValue = CurrentAppProvider.TypeOfClients;
                }
            }

            if ( CurrentAppProvider.ProgramID.Equals( "ES" ) )
            {
                if ( !IsOffSite )
                {
                    if ( null != CurrentAppProvider.TypeFacility && CurrentAppProvider.TypeFacility.Equals( "1" ) )
                    {
                        chkES_ProviderBased.Checked = true;
                        txtES_RelProvNum.Text = CurrentAppProvider.RelatedProviderLicensureNum;
                    }
                    else if ( null != CurrentAppProvider.TypeFacility && CurrentAppProvider.TypeFacility.Equals( "2" ) )
                        chkES_FreeStanding.Checked = true;
                }
            }

            if ( CurrentAppProvider.ProgramID.Equals( "RH" ) )
            {
                if ( !IsOffSite )
                {
                    if ( null != CurrentAppProvider.TypeFacility && CurrentAppProvider.TypeFacility.Equals( "3" ) )
                    {
                        chkRH_Mobile.Checked = true;
                    }
                    else if ( null != CurrentAppProvider.TypeFacility && CurrentAppProvider.TypeFacility.Equals( "4" ) )
                        chkRH_Stationary.Checked = true;

                    if ( null != CurrentAppProvider.ProviderBasedYN && CurrentAppProvider.ProviderBasedYN.Equals( "Y" ) )
                    {
                        chkRH_ProvBased.Checked = true;
                        txtRH_RelProvNum.Text = CurrentAppProvider.RelatedProviderLicensureNum;
                        txtRH_RelProvName.Text = CurrentAppProvider.RelatedProviderName;
                    }
                    else if ( null != CurrentAppProvider.ProviderBasedYN && CurrentAppProvider.ProviderBasedYN.Equals( "N" ) )
                        chkRH_FreeStand.Checked = true;

                }
            }

            if (CurrentAppProvider.ProgramID.Equals("AS")
                && !IsOffSite
            ) {
                listAS_Accred.SelectedValue = (null != CurrentAppProvider.AccreditedBody ? CurrentAppProvider.AccreditedBody : "");
                listAS_Deemed.SelectedValue = (null != CurrentAppProvider.DeemedStatus ? CurrentAppProvider.DeemedStatus : "");
                if (null != CurrentAppProvider.TypeFacility && CurrentAppProvider.TypeFacility.Equals("1")) {
                    chkAS_HospitalBased.Checked = true;
                }
                else if (null != CurrentAppProvider.TypeFacility && CurrentAppProvider.TypeFacility.Equals("2")) {
                    chkAS_FreeStanding.Checked = true;
                }
            }

            if (CurrentAppProvider.ProgramID.Equals("MR")
                && !IsOffSite 
            ) {
                if ( null != CurrentAppProvider.DeemedStatus )
                    chkStatusAccred.Checked = (CurrentAppProvider.DeemedStatus.Equals( "1" ) ? true : false);

                if ( null != CurrentAppProvider.TypeOfClients )
                {
                    if ( CurrentAppProvider.TypeOfClients.Equals( "8" ) )
                        optPopSrvBoth.Checked = true;
                    else if ( CurrentAppProvider.TypeOfClients.Equals( "6" ) )
                        optPopSrvMale.Checked = true;
                    else if ( CurrentAppProvider.TypeOfClients.Equals( "7" ) )
                        optPopSrvFemale.Checked = true;
                }

                txtAgeFrom.Text = ( null != CurrentAppProvider.AgeRangeFrom ? CurrentAppProvider.AgeRangeFrom.Value.ToString() : "" );
                txtAgeTo.Text = ( null != CurrentAppProvider.AgeRangeTO ? CurrentAppProvider.AgeRangeTO.Value.ToString() : "" );

                if (!string.IsNullOrEmpty(CurrentAppProvider.TypeFacility)) {
                    listMR_TypeFacility.SelectedValue = CurrentAppProvider.TypeFacility;
                }
            }

            if (CurrentAppProvider.ProgramID.Equals("NH")
                && !IsOffSite
            ) {
                radMultiFacAdminYes.Checked = (CurrentAppProvider.AdmMultiFacYN == "Y");
                radMultiFacAdminNo.Checked = (CurrentAppProvider.AdmMultiFacYN == "N");
                txtNHAdminOtherFacName.Text = CurrentAppProvider.AdmMultiFacOtherName;
                radSingleStory.Checked = (CurrentAppProvider.SingleStoryYN == "Y");
                radMultiStory.Checked = (CurrentAppProvider.SingleStoryYN == "N");
            }
        }

        #region Members Variables
        private bool IsOffSite
        {
            get{
                return ( ViewState["IsOffSite"] != null ? (bool) ViewState["IsOffSite"] : false );
            }
            set {
                ViewState["IsOffSite"] = value;
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

        private BO_Addresses CurrentAppAddressList
        {
            get
            {
                BO_Addresses tmpAddrList;

                if ( null != CurrentAppProvider && null != CurrentAppProvider.BO_AddressesApplicationID )
                {
                    tmpAddrList = CurrentAppProvider.BO_AddressesApplicationID;
                }
                else
                {
                    tmpAddrList = new BO_Addresses();
                }
                return tmpAddrList;
            }
            set
            {
                CurrentAppProvider.BO_AddressesApplicationID = value;
            }            

        }

        private DataTable LACityLookups
        {
            get
            {
                return CommonFunc.getCitiesByState( "LA" );
            }
        }

       /* private DataTable ParishLookups
        {
            get
            {
                DataTable tmpParishWorkingTbl = new DataTable();

                if ( Session["ParishLookups"] == null )
                {
                    DataColumn tmpDataCol = null;

                    tmpDataCol = new DataColumn( "ParishName" );
                    tmpParishWorkingTbl.Columns.Add( tmpDataCol );
                    tmpDataCol = new DataColumn( "ParishCode" );
                    tmpParishWorkingTbl.Columns.Add( tmpDataCol );

                    BO_Parishes tmpLkups = BO_Parishe.SelectAll();

                    foreach ( BO_Parishe boPa in tmpLkups )
                    {
                        DataRow tmpRW = tmpParishWorkingTbl.NewRow();

                        tmpRW["ParishName"] = boPa.ParishName;
                        tmpRW["ParishCode"] = boPa.ParishCode;

                        tmpParishWorkingTbl.Rows.Add( tmpRW );
                    }

                    Session["ParishLookups"] = tmpParishWorkingTbl;

                }
                else
                    tmpParishWorkingTbl = (DataTable) Session["ParishLookups"];

                return tmpParishWorkingTbl;
            }
            set
            {
                Session["ParishLookups"] = value;
            }
        }
        */
        //private BO_States StateLookups
        private DataTable StateLookups
        {
            get
            {
                DataTable retTbl = CommonFunc.getStates();
                //retTbl.DefaultView.Sort = "StateName ASC";

                return retTbl;
            }
        }

        //private BO_LookupValues FILookups
        private DataTable FILookups
        {
            get
            {
                DataTable retLkups = new DataTable();
                
                DataColumn tmpSTDCol = new DataColumn( "LookupVal" );
                retLkups.Columns.Add( tmpSTDCol );
                
                tmpSTDCol = new DataColumn( "Valdesc" );
                retLkups.Columns.Add( tmpSTDCol );

                BO_LookupValues tmpLkups = BO_LookupValue.SelectByField( BO_LookupValueFields.LookupKey, "FISCAL_INTERMEDIARY" );
                tmpLkups.Sort("Valdesc");

                foreach ( BO_LookupValue tmpLV in tmpLkups )
                {
                    if ( null == tmpLV.Allowedtypes || tmpLV.Allowedtypes.Equals( CurrentAppProvider.ProgramID ) )
                    {
                        DataRow tmpRW = retLkups.NewRow();

                        tmpRW["LookupVal"] = tmpLV.LookupVal;
                        tmpRW["Valdesc"] = tmpLV.LookupVal + " - " + tmpLV.Valdesc;

                        retLkups.Rows.Add( tmpRW );
                    }
                }
                
                return retLkups;
            }
        }


        private DataTable ProvStatusLookups {
            get {
                DataTable retLkups = new DataTable();

                DataColumn tmpSTDCol = new DataColumn("LookupVal");
                retLkups.Columns.Add(tmpSTDCol);

                tmpSTDCol = new DataColumn("Valdesc");
                retLkups.Columns.Add(tmpSTDCol);

                BO_LookupValues tmpLkups = BO_LookupValue.SelectByField(BO_LookupValueFields.LookupKey, "STATUS_CODE");

                foreach (BO_LookupValue tmpLV in tmpLkups) {
                    if (null == tmpLV.Allowedtypes || tmpLV.Allowedtypes.Equals(CurrentAppProvider.ProgramID)) {
                        DataRow tmpRW = retLkups.NewRow();

                        tmpRW["LookupVal"] = tmpLV.LookupVal;
                        tmpRW["Valdesc"] = tmpLV.LookupVal + " - " + tmpLV.Valdesc;

                        retLkups.Rows.Add(tmpRW);
                    }
                }

                return retLkups;
            }
        }

        private DataTable BranchStatusLookups {
            get {
                DataTable retLkups = new DataTable();

                DataColumn tmpSTDCol = new DataColumn("LookupVal");
                retLkups.Columns.Add(tmpSTDCol);

                tmpSTDCol = new DataColumn("Valdesc");
                retLkups.Columns.Add(tmpSTDCol);

                BO_LookupValues tmpLkups = BO_LookupValue.SelectByField(BO_LookupValueFields.LookupKey, "BRANCH_STATUS_CODE");

                foreach (BO_LookupValue tmpLV in tmpLkups) {
                    if (null == tmpLV.Allowedtypes || tmpLV.Allowedtypes.Equals(CurrentAppProvider.ProgramID)) {
                        DataRow tmpRW = retLkups.NewRow();

                        tmpRW["LookupVal"] = tmpLV.LookupVal;
                        tmpRW["Valdesc"] = tmpLV.LookupVal + " - " + tmpLV.Valdesc;

                        retLkups.Rows.Add(tmpRW);
                    }
                }

                return retLkups;
            }
        }

        private DataTable FI_YR_ENDLookups
        {
            get
            {
                DataTable tmpDTbl = new DataTable();
                DataColumn tmpCol1 = new DataColumn( "Key_Val" );
                DataColumn tmpCol2 = new DataColumn( "Val_Desc" );
                
                tmpDTbl.Columns.Add( tmpCol1 );
                tmpDTbl.Columns.Add( tmpCol2 );

                for ( int x = 2009; x < 2031; x++ )
                {
                    tmpDTbl.Rows.Add( x, x );
                }

                return tmpDTbl;
            }
        }

        private DataTable TypFacilityLookups
        {
            get
            {
                DataTable tmpLkupTbl = null;
                BO_LookupValues tmpBO_Lkups = null;

                tmpLkupTbl = new DataTable();

                DataColumn tmpDC = new DataColumn();
                tmpDC.ColumnName = "Valdesc";
                tmpLkupTbl.Columns.Add( tmpDC );
                tmpDC = new DataColumn();
                tmpDC.ColumnName = "LookupVal";
                tmpLkupTbl.Columns.Add( tmpDC );

                tmpBO_Lkups = BO_LookupValue.SelectByField( BO_LookupValueFields.LookupKey, "TYPE_FACILITY" );
                tmpBO_Lkups.Sort( "Valdesc" );

                foreach ( BO_LookupValue boLV in tmpBO_Lkups )
                {
                    if ( null == boLV.Allowedtypes || boLV.Allowedtypes.Contains( CurrentAppProvider.ProgramID ) )
                    {
                        DataRow tmpRW = tmpLkupTbl.NewRow();

                        tmpRW["Valdesc"] = boLV.Valdesc;
                        tmpRW["LookupVal"] = boLV.LookupVal;

                        tmpLkupTbl.Rows.Add( tmpRW );
                    }
                }
 
                return tmpLkupTbl;
            }
        }

        private DataTable TypeClientLookups
        {
            get
            {
                DataTable tmpLkupTbl = null;
                BO_LookupValues tmpBO_Lkups = null;

                tmpLkupTbl = new DataTable();

                DataColumn tmpDC = new DataColumn();
                tmpDC.ColumnName = "Valdesc";
                tmpLkupTbl.Columns.Add( tmpDC );
                tmpDC = new DataColumn();
                tmpDC.ColumnName = "LookupVal";
                tmpLkupTbl.Columns.Add( tmpDC );

                tmpBO_Lkups = BO_LookupValue.SelectByField( BO_LookupValueFields.LookupKey, "TYPE_CLIENT" );
                tmpBO_Lkups.Sort( "Valdesc" );

                foreach ( BO_LookupValue boLV in tmpBO_Lkups )
                {
                    if ( null == boLV.Allowedtypes || boLV.Allowedtypes.Contains( CurrentAppProvider.ProgramID ) )
                    {
                        DataRow tmpRW = tmpLkupTbl.NewRow();

                        tmpRW["Valdesc"] = boLV.Valdesc;
                        tmpRW["LookupVal"] = boLV.LookupVal;

                        tmpLkupTbl.Rows.Add( tmpRW );
                    }
                }

                return tmpLkupTbl;
            }
        }

        private DataTable AOLookups
        {
            get
            {
                DataTable tmpLkupTbl = null;

                //if ( Session["AOLookups"] == null )
                //{
                    BO_LookupValues tmpBO_Lkups = null;
                    
                    tmpLkupTbl = new DataTable();

                    DataColumn tmpDC = new DataColumn();
                    tmpDC.ColumnName = "Valdesc";
                    tmpLkupTbl.Columns.Add( tmpDC );
                    tmpDC = new DataColumn();
                    tmpDC.ColumnName = "LookupVal";
                    tmpLkupTbl.Columns.Add( tmpDC );

                    tmpBO_Lkups = BO_LookupValue.SelectByField( BO_LookupValueFields.LookupKey, "ACCREDITED_BODY" );

                    foreach ( BO_LookupValue boLV in tmpBO_Lkups )
                    {
                        if ( null == boLV.Allowedtypes || boLV.Allowedtypes.Contains( CurrentAppProvider.ProgramID ) )
                        {
                            DataRow tmpRW = tmpLkupTbl.NewRow();

                            tmpRW["Valdesc"] = boLV.Valdesc;
                            tmpRW["LookupVal"] = boLV.LookupVal;
                            
                            tmpLkupTbl.Rows.Add( tmpRW );
                        }
                    }
                //}
                //else
                //    tmpLkupTbl = (DataTable) Session["AOLookups"];

                //AOLookups = tmpLkupTbl;

                return tmpLkupTbl;
            }
            set
            {
                Session["AOLookups"] = value;
            }
        }

        public bool AllowEdit
        {
            get
            {
                return (null != ViewState["AllowEdit"] ? (bool)ViewState["AllowEdit"] : false);
            }
            set
            {
                ViewState["AllowEdit"] = value;
            }
        }

        private bool IsNewOffsiteThisApp
        {
            get
            {
                return ( null != ViewState["IsNewOffsiteThisApp"] ? (bool) ViewState["IsNewOffsiteThisApp"] : false );
            }
            set
            {
                ViewState["IsNewOffsiteThisApp"] = value;
            }
        }

        private string getGeoCityFromCurrentAddressList()
        {
            string city = "";
            foreach (BO_Address addr in CurrentAppAddressList)
            {
                if (addr.AddressType == 1)
                {

                    city = addr.City;
                }
            }
            return city;
        }

        #endregion

        protected void OverrideLicenseNum_CheckedChanged(object sender, EventArgs e)
        {
            LicenseNum.ReadOnly = false;
        }

        private User User
        {
            get { return (User)Session["User"]; }
        }
    }
}