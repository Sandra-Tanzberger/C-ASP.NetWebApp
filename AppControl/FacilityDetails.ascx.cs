using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ATG.BusinessObject;
using Telerik.Web.UI;

namespace AppControl
{
    public partial class FacilityDetails : System.Web.UI.UserControl
    {

        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            // do nothing
        }

        #endregion

        #region Private

        /// <summary>
        /// Maintain the BO_Provider object in ViewState
        /// </summary>
        private BO_Provider CurrentProvider
        {
            get
            {
                return Session["CurrentProvider"] == null ? null : (BO_Provider)Session["CurrentProvider"];
            }
            set
            {
                Session["CurrentProvider"] = value;
            }
        }

        /// <summary>
        /// Set the values of the input controls
        /// </summary>
        private void InitFields()
        {
            BO_Provider boProvider = CurrentProvider;
            
            //special case for "NA" providers - set labels
            if (boProvider.ProgramID.Equals("NA"))
            {
                LicenseNumber.Text = "School/Facility Code";
            }

            if (boProvider.ProgramID.Equals("MT"))
            {
                LicenseNumber.Text = "State License #";
            }

            TextBoxFederalId.Text = (boProvider != null) ? boProvider.FederalID : "";
            TextBoxLicenseNumber.Text = (boProvider != null) ? boProvider.LicensureNum : "";
            TextBoxStateId.Text = (boProvider != null) ? boProvider.StateID : "";
            TextBoxFacilityName.Text = (boProvider != null) ? boProvider.FacilityName : "";
            TextBoxGeoStreetAddress.Text = (boProvider != null) ? boProvider.GeographicalStreet : "";
            TextBoxGeoCity.Text = (boProvider != null) ? boProvider.GeographicalCity : "";
            TextBoxGeoState.Text = (boProvider != null) ? boProvider.GeographicalState : "";
            RadMaskedTextBoxGeoZip.Text = (boProvider != null) ? boProvider.GeographicalZip : "";
            RadMaskedTextBoxTelephoneNumber.Text = (boProvider != null) ? boProvider.TelephoneNumber : "";
            RadMaskedTextBoxFaxNumber.Text = (boProvider != null) ? boProvider.FaxPhoneNumber : "";
            TextBoxMailStreetAddress.Text = (boProvider != null) ? boProvider.MailStreet : "";
            TextBoxMailCity.Text = (boProvider != null) ? boProvider.MailCity : "";
            TextBoxMailState.Text = (boProvider != null) ? boProvider.MailState : "";
            RadMaskedTextBoxMailZip.Text = (boProvider != null) ? boProvider.MailZip : "";
            TextBoxEmailAddress.Text = (boProvider != null) ? boProvider.EmailAddress : "";
            txtAdministrator.Text = ( boProvider != null ) ? boProvider.Administrator : "";

            

            if (("MT,NE").Contains(boProvider.ProgramID))
            {
                RadMaskedTextBoxEmergencyPhone.Text = boProvider.EmergencyPhoneNumber != null ? boProvider.EmergencyPhoneNumber : "";
                lblEmergencyPhone.Visible = true;
                RadMaskedTextBoxEmergencyPhone.Visible = true;
            }

            if (boProvider != null)
            {
                // set the value of the "Accreditation Expiration Date"
                if (boProvider.AccreditationExpirationDate != null
                    && boProvider.AccreditationExpirationDate.HasValue
                ) {
                    // ensure that the date is a valid date
                    if (boProvider.AccreditationExpirationDate > RadDatePickerAED.MinDate
                        && boProvider.AccreditationExpirationDate < RadDatePickerAED.MaxDate)
                        RadDatePickerAED.SelectedDate = boProvider.AccreditationExpirationDate;
                    else
                        RadDatePickerAED.SelectedDate = null;
                }
                else {
                    RadDatePickerAED.SelectedDate = null;
                }
                // rjc - 08/20/2012 - add status date
                // set "Status Date"
                if (boProvider.StatusDate != null
                    && boProvider.StatusDate.HasValue) {
                    // ensure that the date is a valid date
                    if (boProvider.StatusDate > RadDatePickerStatusDate.MinDate
                        && boProvider.StatusDate < RadDatePickerStatusDate.MaxDate)
                        RadDatePickerStatusDate.SelectedDate = boProvider.StatusDate;
                    else
                        RadDatePickerStatusDate.SelectedDate = null;
                }
                else {
                    RadDatePickerStatusDate.SelectedDate = null;
                }
            }
            else
            {
                // set the value of the date control to null
                RadDatePickerAED.SelectedDate = null;
                RadDatePickerStatusDate.SelectedDate = null;
            }

            if (boProvider != null && !string.IsNullOrEmpty(boProvider.EmergencyPrepReportRequired))
            {
                listEmergencyPrepReportRequired.SelectedValue = (boProvider.EmergencyPrepReportRequired.Equals("Y")) ? "Y" : "N";
            }
            else
                listEmergencyPrepReportRequired.SelectedValue = null;

            if (boProvider != null)
            {
                // setup the lookup comboboxes
                if (null != boProvider.GeographicalState && !boProvider.GeographicalState.Equals(""))
                {
                    listParish.Items.Clear();
                    listParish.AppendDataBoundItems = true;
                    listParish.Items.Add(new ListItem("", ""));
                    listParish.DataSource = BO_Ziplookup.SelectByField("STATE_CODE", boProvider.GeographicalState);
                    listParish.DataTextField = "CNTYNAME";
                    listParish.DataValueField = "COUNTY";
                    listParish.DataBind();
                    SetDropDownListSelectedValue(listParish, boProvider.ParishCode);
                }

                if (boProvider.GeographicalState != "LA")//currently no region or field office data available for states other than LA
                {
                    Label14.Text = "County";

                }
                else
                {
                    listRegion.Items.Clear();
                    listRegion.AppendDataBoundItems = true;
                    listRegion.Items.Add(new ListItem("", ""));
                    listRegion.DataSource = RegionLookups;
                    listRegion.DataTextField = "RegionName";
                    listRegion.DataValueField = "RegionCode";
                    listRegion.DataBind();
                    SetDropDownListSelectedValue(listRegion, boProvider.RegionCode);

                    listFieldOffice.Items.Clear();
                    listFieldOffice.AppendDataBoundItems = true;
                    listFieldOffice.Items.Add(new ListItem("", ""));
                    listFieldOffice.DataSource = FieldOfficeLookups;
                    listFieldOffice.DataTextField = "Valdesc";
                    listFieldOffice.DataValueField = "LookupVal";
                    listFieldOffice.DataBind();
                    SetDropDownListSelectedValue(listFieldOffice, boProvider.FieldOfficeCode);
                }

                listFiscalInt.Items.Clear();
                listFiscalInt.AppendDataBoundItems = true;
                listFiscalInt.Items.Add(new ListItem("", ""));
                listFiscalInt.DataSource = FiscalIntermediaryLookups;
                listFiscalInt.DataTextField = "Valdesc";
                listFiscalInt.DataValueField = "LookupVal";
                listFiscalInt.DataBind();
                SetDropDownListSelectedValue(listFiscalInt, boProvider.FiscalIntermediaryNum); 

                listZone.Items.Clear();
                listZone.AppendDataBoundItems = true;
                listZone.Items.Add(new ListItem("", ""));
                listZone.DataSource = ZoneLookups;
                listZone.DataTextField = "Valdesc";
                listZone.DataValueField = "LookupVal";
                listZone.DataBind();
                SetDropDownListSelectedValue(listZone, boProvider.ZoneNumCode);

                listTypeFacility.Items.Clear();
                listTypeFacility.AppendDataBoundItems = true;
                listTypeFacility.Items.Add(new ListItem("", ""));
                listTypeFacility.DataSource = TypeFacilityLookups;
                listTypeFacility.DataTextField = "Valdesc";
                listTypeFacility.DataValueField = "LookupVal";
                listTypeFacility.DataBind();
                if ( ("HO,ES,RH,MR,MT,NE").Contains(CurrentProvider.ProgramID) )
                    SetDropDownListSelectedValue(listTypeFacility, boProvider.TypeFacilityCode );
                else
                    SetDropDownListSelectedValue( listTypeFacility, boProvider.FacilityTypeCode );

                listProvBased.SelectedValue = boProvider.ProviderBasedYN;

                listLicenseType.Items.Clear();
                listLicenseType.AppendDataBoundItems = true;
                listLicenseType.Items.Add(new ListItem("", ""));
                listLicenseType.DataSource = LicenseTypeLookups;
                listLicenseType.DataTextField = "Valdesc";
                listLicenseType.DataValueField = "LookupVal";
                listLicenseType.DataBind();
                SetDropDownListSelectedValue(listLicenseType, boProvider.TypeLicenseCode);

                listClientType.Items.Clear();
                listClientType.AppendDataBoundItems = true;
                listClientType.Items.Add(new ListItem("", ""));
                listClientType.DataSource = ClientTypeLookups;
                listClientType.DataTextField = "Valdesc";
                listClientType.DataValueField = "LookupVal";
                listClientType.DataBind();
                SetDropDownListSelectedValue(listClientType, boProvider.TypeOfClients);

                listAccrdBody.Items.Clear();
                listAccrdBody.AppendDataBoundItems = true;
                listAccrdBody.Items.Add(new ListItem("", ""));
                listAccrdBody.DataSource = AOLookups;
                listAccrdBody.DataTextField = "Valdesc";
                listAccrdBody.DataValueField = "LookupVal";
                listAccrdBody.DataBind();
                SetDropDownListSelectedValue(listAccrdBody, boProvider.AccreditedBody);

                // rjc - 08/20/2012 - add operation status
                listOperStat.Items.Clear();
                listOperStat.AppendDataBoundItems = true;
                listOperStat.Items.Add(new ListItem("", ""));
                listOperStat.DataSource = OperStatLookups;
                listOperStat.DataTextField = "Valdesc";
                listOperStat.DataValueField = "LookupVal";
                listOperStat.DataBind();
                SetDropDownListSelectedValue(listOperStat, boProvider.StatusCode);

                listAC_TypeFacility.Items.Clear();
                if ( "AC".Contains( CurrentAppProvider.ProgramID ) )
                {
                    listAC_TypeFacility.AppendDataBoundItems = true;
                    listAC_TypeFacility.Items.Add(new RadComboBoxItem("", ""));
                    listAC_TypeFacility.DataSource = TypFacilityLookups;
                    listAC_TypeFacility.DataTextField = "Valdesc";
                    listAC_TypeFacility.DataValueField = "LookupVal";
                    listAC_TypeFacility.Height = Unit.Pixel(100);
                    listAC_TypeFacility.DataBind();
                }

                if ("HO,NA".Contains(CurrentAppProvider.ProgramID))
                {
                    LblFacilityInFacilityYN.Visible = true;
                    DdlFacilityInFacilityYN.Visible = true;
                    DdlFacilityInFacilityYN.SelectedValue = CurrentAppProvider.FacilityWithinFacilityYN;
                    if (CurrentAppProvider.FacilityWithinFacilityYN == "Y")
                    {
                        TextBoxFacilityInFacility.Text = CurrentAppProvider.FacilityWithinFacility;
                        lblFacilityInFacilityDesc.Visible = true;
                        TextBoxFacilityInFacility.Visible = true;
                    }
                }

            }
            else
            {
                listParish.Items.Clear();
                listParish.SelectedValue = null;

                listRegion.Items.Clear();
                listRegion.SelectedValue = null;

                listFiscalInt.Items.Clear();
                listFiscalInt.SelectedValue = null;

                listFieldOffice.Items.Clear();
                listFieldOffice.SelectedValue = null;

                listZone.Items.Clear();
                listZone.SelectedValue = null;

                listTypeFacility.Items.Clear();
                listTypeFacility.SelectedValue = null;

                listLicenseType.Items.Clear();
                listLicenseType.SelectedValue = null;

                listClientType.Items.Clear();
                listClientType.SelectedValue = null;

                listAccrdBody.Items.Clear();
                listAccrdBody.SelectedValue = null;
            }

            /* 
             * Special Cases
             */

            // Related Provider License # is only visible for Rural Health Clinics
            TextBoxRelatedProvider.Text = (boProvider != null) ? boProvider.RelatedProviderLicensureNum : "";
            if (boProvider != null)
            {
                if (boProvider.ProgramID.Equals("RH"))
                {
                    TextBoxRelatedProvider.Visible = true;
                    LabelRelatedProvider.Visible = true;
                }
                else
                {
                    TextBoxRelatedProvider.Visible = false;
                    LabelRelatedProvider.Visible = false;
                }
            }
            else
            {
                TextBoxRelatedProvider.Visible = false;
                LabelRelatedProvider.Visible = false;
            }

            _GenderAndAge();
            _ModuleTypeFacility();
        }

        /// <summary>
        /// Set the value of the Dropdownlist control
        /// </summary>
        /// <param name="ddl"></param>
        /// <param name="checkValue"></param>
        private void SetDropDownListSelectedValue(DropDownList ddl, string checkValue)
        {
            bool isValidValue = false;

            if (!string.IsNullOrEmpty(checkValue))
            {
                for (int i = 0; i < ddl.Items.Count; i++)
                {
                    if (ddl.Items[i].Value.Equals(checkValue))
                    {
                        isValidValue = true;
                        break;
                    }
                }
            }
            // set the SelectedValue of the dropdownlist control
            if (isValidValue)
                ddl.SelectedValue = checkValue;
            else
                ddl.SelectedValue = null;
        }

        private void _ShowHideFields()
        {
            //Turn off all sections first then enable them by program type and location
            tblPopGender.Visible = false;
            tblAgeRange.Visible = false;
            tblAC_ProviderType.Visible = false;

            switch (CurrentProvider.ProgramID)
            {
                case "HC":
                    //tblPopGender.Visible = true;
                    tblAgeRange.Visible = true;
                    break;
                case "PD":
                    tblAgeRange.Visible = true;
                    break;
                //case "WA":
                //    tblAgeRange.Visible = true;
                //    break;
                case "BR":
                    //tblPopGender.Visible = true;
                    tblAgeRange.Visible = true;
                    break;
                case "HP":
                    break;
                case "AC":
                    tblAC_ProviderType.Visible = true;
                    break;
                case "MR":
                    //tblPopGender.Visible = true;
                    tblAgeRange.Visible = true;
                    break;
            }

        }

        private void _GenderAndAge()
        {
            if (("HC,PD,MR").Contains(CurrentAppProvider.ProgramID))
            {
                if (null != CurrentAppProvider.TypeOfClients)
                {
                    if (CurrentAppProvider.TypeOfClients.Equals("8"))
                        optPopSrvBoth.Checked = true;
                    else if (CurrentAppProvider.TypeOfClients.Equals("6"))
                        optPopSrvMale.Checked = true;
                    else if (CurrentAppProvider.TypeOfClients.Equals("7"))
                        optPopSrvFemale.Checked = true;
                }

                txtAgeFrom.Text = (null != CurrentAppProvider.AgeRangeFrom ? CurrentAppProvider.AgeRangeFrom.Value.ToString() : "");
                txtAgeTo.Text = (null != CurrentAppProvider.AgeRangeTO ? CurrentAppProvider.AgeRangeTO.Value.ToString() : "");


                foreach (BO_Affiliation tmpBA in CurrentAppProvider.BO_AffiliationsApplicationID)
                {
                    //if ( tmpBA.AffiliationID.Equals( CurrentAffiliationID ) )
                    if (tmpBA.UI_TrackID.Equals(CurrentAffiliationID))
                    {
                        if (null != tmpBA.TypeOfClients)
                        {
                            if (tmpBA.TypeOfClients.Equals("8"))
                                optPopSrvBoth.Checked = true;
                            else if (tmpBA.TypeOfClients.Equals("6"))
                                optPopSrvMale.Checked = true;
                            else if (tmpBA.TypeOfClients.Equals("7"))
                                optPopSrvFemale.Checked = true;
                        }

                        txtAgeFrom.Text = (null != tmpBA.AgeRangeFrom ? tmpBA.AgeRangeFrom.Value.ToString() : "");
                        txtAgeTo.Text = (null != tmpBA.AgeRangeTO ? tmpBA.AgeRangeTO.Value.ToString() : "");

                        break;
                    }
                }
            }
            else if ( ( "BR" ).Contains( CurrentAppProvider.ProgramID ) )
            {
                if ( null != CurrentAppProvider.TypeOfClients && CurrentAppProvider.TypeOfClients.Equals( "8" ) )
                    optPopSrvBoth.Checked = true;
                else if ( null != CurrentAppProvider.TypeOfClients && CurrentAppProvider.TypeOfClients.Equals( "6" ) )
                    optPopSrvMale.Checked = true;
                else if ( null != CurrentAppProvider.TypeOfClients && CurrentAppProvider.TypeOfClients.Equals( "7" ) )
                    optPopSrvFemale.Checked = true;

                txtAgeFrom.Text = (null != CurrentAppProvider.AgeRangeFrom ? CurrentAppProvider.AgeRangeFrom.Value.ToString() : "");
                txtAgeTo.Text = (null != CurrentAppProvider.AgeRangeTO ? CurrentAppProvider.AgeRangeTO.Value.ToString() : "");
            }
        }

        private void _ModuleTypeFacility()
        {
            if (("AC").Contains(CurrentAppProvider.ProgramID))
            {
                listAC_TypeFacility.SelectedValue = CurrentAppProvider.TypeFacility;
            }
        }
        #endregion

        #region Public

        /// <summary>
        /// Reload the fields with the current provider
        /// </summary>
        /// <param name="boProvider"></param>
        public void LoadNewProvider()
        {
            // Set the values of the input controls
            InitFields();
            _ShowHideFields();
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

        #endregion

        #region LookUps

        private bool IsOffSite
        {
            get
            {
                return (ViewState["IsOffSite"] != null ? (bool)ViewState["IsOffSite"] : false);
            }
            set
            {
                ViewState["IsOffSite"] = value;
            }
        }

        /*private DataTable ParishLookups
        {
            get
            {
                DataTable tmpParishWorkingTbl = new DataTable();
                    
                if (Session["ParishLookups"] == null)
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
        }*/

        private DataTable RegionLookups
        {
            get
            {
                DataTable tmpRegionWorkingTbl = new DataTable();
                    
                if (Session["RegionLookups"] == null)
                {
                    DataColumn tmpDataCol = null;

                    tmpDataCol = new DataColumn( "RegionName" );
                    tmpRegionWorkingTbl.Columns.Add( tmpDataCol );
                    tmpDataCol = new DataColumn( "RegionCode" );
                    tmpRegionWorkingTbl.Columns.Add( tmpDataCol );

                    BO_Regions tmpLkups = BO_Region.SelectAll();

                    foreach ( BO_Region boRgn in tmpLkups )
                    {
                        DataRow tmpRW = tmpRegionWorkingTbl.NewRow();

                        tmpRW["RegionName"] = boRgn.RegionName;
                        tmpRW["RegionCode"] = boRgn.RegionCode;

                        tmpRegionWorkingTbl.Rows.Add( tmpRW );
                    }

                    Session["RegionLookups"] = tmpRegionWorkingTbl;

                }
                else
                    tmpRegionWorkingTbl = (DataTable) Session["RegionLookups"];

                return tmpRegionWorkingTbl;
            }
            set
            {
                Session["RegionLookups"] = value;
            }
        }

        private DataTable FiscalIntermediaryLookups
        {
            get
            {
                DataTable tmpLkupWorkingTbl = new DataTable();
                
                if (Session["FiscalIntermediaryLookups"] == null)
                {
                    if (CurrentProvider != null)
                    {
                        DataColumn tmpDataCol = null;

                        tmpDataCol = new DataColumn( "Valdesc" );
                        tmpLkupWorkingTbl.Columns.Add( tmpDataCol );
                        tmpDataCol = new DataColumn( "LookupVal" );
                        tmpLkupWorkingTbl.Columns.Add( tmpDataCol );

                        BO_LookupValues tmpLkups = BO_LookupValue.SelectByField(BO_LookupValueFields.LookupKey, "FISCAL_INTERMEDIARY");
                        tmpLkups.Sort("Valdesc");

                        foreach (BO_LookupValue tmpLV in tmpLkups)
                        {
                            if ( tmpLV.Allowedtypes == null || tmpLV.Allowedtypes.Contains( CurrentProvider.ProgramID ) )
                            {
                                DataRow tmpRW = tmpLkupWorkingTbl.NewRow();

                                tmpRW["Valdesc"] = tmpLV.LookupVal + " - " + tmpLV.Valdesc;
                                tmpRW["LookupVal"] = tmpLV.LookupVal;

                                tmpLkupWorkingTbl.Rows.Add( tmpRW );
                            }
                        }
                    }

                    Session["FiscalIntermediaryLookups"] = tmpLkupWorkingTbl;
                }
                else
                    tmpLkupWorkingTbl = (DataTable)Session["FiscalIntermediaryLookups"];

                return tmpLkupWorkingTbl;
            }
            set
            {
                Session["FiscalIntermediaryLookups"] = value;
            }
        }

        private DataTable FieldOfficeLookups
        {
            get
            {
                DataTable tmpLkupWorkingTbl = new DataTable();
                
                if (Session["FieldOfficeLookups"] == null)
                {
                    if (CurrentProvider != null)
                    {
                        DataColumn tmpDataCol = null;

                        tmpDataCol = new DataColumn( "Valdesc" );
                        tmpLkupWorkingTbl.Columns.Add( tmpDataCol );
                        tmpDataCol = new DataColumn( "LookupVal" );
                        tmpLkupWorkingTbl.Columns.Add( tmpDataCol );

                        BO_LookupValues tmpLkups = BO_LookupValue.SelectByField(BO_LookupValueFields.LookupKey, "FIELD_OFFICE");
                        
                        foreach (BO_LookupValue tmpLV in tmpLkups)
                        {
                            if ( tmpLV.Allowedtypes == null || tmpLV.Allowedtypes.Contains( CurrentProvider.ProgramID ) )
                            {
                                DataRow tmpRW = tmpLkupWorkingTbl.NewRow();

                                tmpRW["Valdesc"] = tmpLV.Valdesc;
                                tmpRW["LookupVal"] = tmpLV.LookupVal;

                                tmpLkupWorkingTbl.Rows.Add( tmpRW );
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

        private DataTable ZoneLookups
        {
            get
            {
                DataTable tmpLkupWorkingTbl = new DataTable();
                
                if (Session["ZoneLookups"] == null)
                {
                    if (CurrentProvider != null)
                    {
                        DataColumn tmpDataCol = null;

                        tmpDataCol = new DataColumn( "Valdesc" );
                        tmpLkupWorkingTbl.Columns.Add( tmpDataCol );
                        tmpDataCol = new DataColumn( "LookupVal" );
                        tmpLkupWorkingTbl.Columns.Add( tmpDataCol );

                        BO_LookupValues tmpLkups = BO_LookupValue.SelectByField(BO_LookupValueFields.LookupKey, "ZONE");
                        
                        foreach (BO_LookupValue tmpLV in tmpLkups)
                        {
                            if ( tmpLV.Allowedtypes == null || tmpLV.Allowedtypes.Contains( CurrentProvider.ProgramID ) )
                            {
                                DataRow tmpRW = tmpLkupWorkingTbl.NewRow();

                                tmpRW["Valdesc"] = tmpLV.Valdesc;
                                tmpRW["LookupVal"] = tmpLV.LookupVal;

                                tmpLkupWorkingTbl.Rows.Add( tmpRW );
                            }
                        }
                    }

                    Session["ZoneLookups"] = tmpLkupWorkingTbl;
                }
                else
                    tmpLkupWorkingTbl = (DataTable)Session["ZoneLookups"];

                return tmpLkupWorkingTbl;
            }
            set
            {
                Session["ZoneLookups"] = value;
            }
        }

        private DataTable TypeFacilityLookups
        {
            get
            {
                DataTable tmpLkupWorkingTbl = new DataTable();
                
                //if (Session["TypeFacilityLookups"] == null)
                //{
                    if (CurrentProvider != null)
                    {
                        DataColumn tmpDataCol = null;

                        tmpDataCol = new DataColumn( "Valdesc" );
                        tmpLkupWorkingTbl.Columns.Add( tmpDataCol );
                        tmpDataCol = new DataColumn( "LookupVal" );
                        tmpLkupWorkingTbl.Columns.Add( tmpDataCol );

                        BO_LookupValues tmpLkups = null;
                        
                        if ( ( "SA" ).Contains( CurrentProvider.ProgramID ) )
                            tmpLkups = BO_LookupValue.SelectByField( BO_LookupValueFields.LookupKey, "TYPE_OPERATION" );
                        else
                            tmpLkups = BO_LookupValue.SelectByField(BO_LookupValueFields.LookupKey, "TYPE_FACILITY");
                        
                        foreach (BO_LookupValue tmpLV in tmpLkups)
                        {
                            if ( tmpLV.Allowedtypes == null || tmpLV.Allowedtypes.Contains( CurrentProvider.ProgramID ) )
                            {
                                DataRow tmpRW = tmpLkupWorkingTbl.NewRow();

                                tmpRW["Valdesc"] = tmpLV.Valdesc;
                                tmpRW["LookupVal"] = tmpLV.LookupVal;

                                tmpLkupWorkingTbl.Rows.Add( tmpRW );
                            }
                        }
                    }

                //    Session["TypeFacilityLookups"] = tmpLkupWorkingTbl;
                //}
                //else
                //    tmpLkupWorkingTbl = (DataTable)Session["TypeFacilityLookups"];

                return tmpLkupWorkingTbl;
            }
            set
            {
                Session["TypeFacilityLookups"] = value;
            }
        }

        private DataTable LicenseTypeLookups
        {
            get
            {
                DataTable tmpLkupWorkingTbl = new DataTable();
                
                if (Session["LicenseTypeLookups"] == null)
                {
                    if (CurrentProvider != null)
                    {
                        DataColumn tmpDataCol = null;

                        tmpDataCol = new DataColumn( "Valdesc" );
                        tmpLkupWorkingTbl.Columns.Add( tmpDataCol );
                        tmpDataCol = new DataColumn( "LookupVal" );
                        tmpLkupWorkingTbl.Columns.Add( tmpDataCol );

                        BO_LookupValues tmpLkups = BO_LookupValue.SelectByField(BO_LookupValueFields.LookupKey, "TYPE_LICENSE");
                        
                        foreach (BO_LookupValue tmpLV in tmpLkups)
                        {
                            if ( tmpLV.Allowedtypes == null || tmpLV.Allowedtypes.Contains( CurrentProvider.ProgramID ) )
                            {
                                DataRow tmpRW = tmpLkupWorkingTbl.NewRow();

                                tmpRW["Valdesc"] = tmpLV.Valdesc;
                                tmpRW["LookupVal"] = tmpLV.LookupVal;

                                tmpLkupWorkingTbl.Rows.Add( tmpRW );
                            }
                        }
                    }

                    Session["LicenseTypeLookups"] = tmpLkupWorkingTbl;
                }
                else
                    tmpLkupWorkingTbl = (DataTable)Session["LicenseTypeLookups"];

                return tmpLkupWorkingTbl;
            }
            set
            {
                Session["LicenseTypeLookups"] = value;
            }
        }

        private DataTable ClientTypeLookups
        {
            get
            {
                DataTable tmpLkupWorkingTbl = new DataTable();
                
                //if (Session["ClientTypeLookups"] == null)
                //{
                    if (CurrentProvider != null)
                    {
                        DataColumn tmpDataCol = null;

                        tmpDataCol = new DataColumn( "Valdesc" );
                        tmpLkupWorkingTbl.Columns.Add( tmpDataCol );
                        tmpDataCol = new DataColumn( "LookupVal" );
                        tmpLkupWorkingTbl.Columns.Add( tmpDataCol );

                        BO_LookupValues tmpLkups = BO_LookupValue.SelectByField(BO_LookupValueFields.LookupKey, "TYPE_CLIENT");
                        
                        foreach (BO_LookupValue tmpLV in tmpLkups)
                        {
                            if ( tmpLV.Allowedtypes == null || tmpLV.Allowedtypes.Contains( CurrentProvider.ProgramID ) )
                            {
                                DataRow tmpRW = tmpLkupWorkingTbl.NewRow();

                                tmpRW["Valdesc"] = tmpLV.Valdesc;
                                tmpRW["LookupVal"] = tmpLV.LookupVal;

                                tmpLkupWorkingTbl.Rows.Add( tmpRW );
                            }
                        }
                    }

                //    Session["ClientTypeLookups"] = tmpLkupWorkingTbl;
                //}
                //else
                //    tmpLkupWorkingTbl = (DataTable)Session["ClientTypeLookups"];

                return tmpLkupWorkingTbl;
            }
            //set
            //{
            //    Session["ClientTypeLookups"] = value;
            //}
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
                tmpLkupTbl.Columns.Add(tmpDC);
                tmpDC = new DataColumn();
                tmpDC.ColumnName = "LookupVal";
                tmpLkupTbl.Columns.Add(tmpDC);

                tmpBO_Lkups = BO_LookupValue.SelectByField(BO_LookupValueFields.LookupKey, "TYPE_FACILITY");
                tmpBO_Lkups.Sort("Valdesc");

                foreach (BO_LookupValue boLV in tmpBO_Lkups)
                {
                    if (null == boLV.Allowedtypes || boLV.Allowedtypes.Contains(CurrentAppProvider.ProgramID))
                    {
                        DataRow tmpRW = tmpLkupTbl.NewRow();

                        tmpRW["Valdesc"] = boLV.Valdesc;
                        tmpRW["LookupVal"] = boLV.LookupVal;

                        tmpLkupTbl.Rows.Add(tmpRW);
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

                if ( Session["AOLookups"] == null )
                {
                    BO_LookupValues tmpBO_Lkups = null;
                    DataColumn tmpDC = null;

                    tmpLkupTbl = new DataTable();

                    tmpDC = new DataColumn();
                    tmpDC.ColumnName = "Valdesc";
                    tmpLkupTbl.Columns.Add( tmpDC );
                    tmpDC = new DataColumn();
                    tmpDC.ColumnName = "LookupVal";
                    tmpLkupTbl.Columns.Add( tmpDC );

                    tmpBO_Lkups = BO_LookupValue.SelectByField( BO_LookupValueFields.LookupKey, "ACCREDITED_BODY" );

                    foreach ( BO_LookupValue boLV in tmpBO_Lkups )
                    {
                        if ( null == boLV.Allowedtypes || boLV.Allowedtypes.Contains( CurrentProvider.ProgramID ) )
                        {
                            DataRow tmpRW = tmpLkupTbl.NewRow();

                            tmpRW["Valdesc"] = boLV.Valdesc;
                            tmpRW["LookupVal"] = boLV.LookupVal;

                            tmpLkupTbl.Rows.Add( tmpRW );
                        }
                    }
                }
                else
                    tmpLkupTbl = (DataTable) Session["AOLookups"];

                AOLookups = tmpLkupTbl;

                return tmpLkupTbl;
            }
            set
            {
                Session["AOLookups"] = value;
            }
        }

        // rjc - 08/20/2012 - add operation status
        private DataTable OperStatLookups {
            get {
                DataTable tmpLkupTbl = null;

                if (Session["OperStatLookups"] == null) {
                    BO_LookupValues tmpBO_Lkups = null;
                    DataColumn tmpDC = null;

                    tmpLkupTbl = new DataTable();

                    tmpDC = new DataColumn();
                    tmpDC.ColumnName = "Valdesc";
                    tmpLkupTbl.Columns.Add(tmpDC);
                    tmpDC = new DataColumn();
                    tmpDC.ColumnName = "LookupVal";
                    tmpLkupTbl.Columns.Add(tmpDC);

                    tmpBO_Lkups = BO_LookupValue.SelectByField(BO_LookupValueFields.LookupKey, "STATUS_CODE");

                    foreach (BO_LookupValue boLV in tmpBO_Lkups) {
                        if (null == boLV.Allowedtypes || boLV.Allowedtypes.Contains(CurrentProvider.ProgramID)) {
                            DataRow tmpRW = tmpLkupTbl.NewRow();

                            tmpRW["Valdesc"] = boLV.Valdesc;
                            tmpRW["LookupVal"] = boLV.LookupVal;

                            tmpLkupTbl.Rows.Add(tmpRW);
                        }
                    }
                }
                else
                    tmpLkupTbl = (DataTable)Session["OperStatLookups"];

                OperStatLookups = tmpLkupTbl;

                return tmpLkupTbl;
            }
            set {
                Session["OperStatLookups"] = value;
            }
        }
        #endregion
    }
}