using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Telerik.Web.UI;
using ATG.BusinessObject;
using ATG.Utilities.Data;
using System.Text.RegularExpressions;

namespace AppControl
{
    public partial class FacilityOffiste : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // do nothing
        }

        protected void grdOffsite_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            if (null != grdOffsiteDataSource)
            {
                grdOffsite.DataSource = (DataTable)grdOffsiteDataSource;
            }
            else
            {
                string providerPOPSINTID = (string)Session["ProviderPOPSINTID"];
                InitHistoryGrid(providerPOPSINTID);
            }
        }

        protected void grdOffsite_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSelectedItem();
        }

        private void LoadSelectedItem()
        {
            // get the currently selected Provider
            GridDataItem dataItem = (GridDataItem) grdOffsite.SelectedItems[0];

            // Reload the data in the input controls
            InitFields(dataItem);
        }

        /// <summary>
        /// get the data for the grid
        /// </summary>
        private void InitHistoryGrid(string providerPOPSINTID)
        {
            if(!string.IsNullOrEmpty(providerPOPSINTID))
            {
                // get the last approved Application for this provider
                BO_ProviderPrimaryKey boProviderPrimaryKey = new BO_ProviderPrimaryKey(Convert.ToDecimal(providerPOPSINTID));
                if (boProviderPrimaryKey != null)
                {
                    BO_Applications tmpApplications = BO_Application.SelectApprovedApplicationsByPopsIntId(boProviderPrimaryKey);
                    if (tmpApplications != null && tmpApplications.Count > 0)
                    {
                        BO_Application boApplication = (BO_Application)tmpApplications[0];
                        decimal? appId = boApplication.ApplicationID;

                        BO_ApplicationPrimaryKey boApplicationPrimaryKey = new BO_ApplicationPrimaryKey(appId);
                        BO_Affiliations tmpAffiliations = BO_Affiliation.SelectWithAddressDescByForeignKeyApplicationID(boApplicationPrimaryKey);
                        if (null != tmpAffiliations)
                        {
                            // save the Affiilations data in the Session
                            savedBOAffiliations = tmpAffiliations;

                            // Create a dataTable with the appropriate data struture
                            DataTable tmpTable = getFacilityOffsiteDataTable();

                            foreach (BO_Affiliation boAffiliation in tmpAffiliations)
                            {
                                DataRow tmpDR = tmpTable.NewRow();
                                tmpDR["FACILITYNAME"] = boAffiliation.FacilityName;
                                tmpDR["AFFILIATIONTYPEDESC"] = boAffiliation.AffiliationTypeDesc;
                                tmpDR["LICENSURENUM"] = boAffiliation.LicensureNum;
                                tmpDR["ORIGINALLICENSUREDATE"] = boAffiliation.OriginalLicensureDate.HasValue ? boAffiliation.OriginalLicensureDate.Value.ToShortDateString() : "" ;
                                tmpDR["AFFILIATIONID"] = boAffiliation.AffiliationID;

                                tmpTable.Rows.Add(tmpDR);
                            }
                            // save to the Session Object
                            grdOffsiteDataSource = tmpTable;
                            // set the dataSource object for the grid
                            grdOffsite.DataSource = (DataTable)grdOffsiteDataSource;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Display/Clear values from the Fields
        /// </summary>
        /// <param name="dataItem"></param>
        private void InitFields(GridDataItem dataItem)
        {
            BO_Affiliation currentAffiliation = null;

            if (dataItem != null && dataItem["AffiliationId"] != null)
            {
                BO_Affiliations boAffiliations = (BO_Affiliations)savedBOAffiliations;
                if (boAffiliations != null)
                {
                    foreach (BO_Affiliation boAffiliation in boAffiliations)
                    {
                        if (boAffiliation.AffiliationID.ToString().Equals(dataItem["AffiliationId"].Text))
                        {
                            currentAffiliation = boAffiliation;
                            break;
                        }
                    }
                }
            }
            TextBoxLicenseNumber.Text = (currentAffiliation != null) ? currentAffiliation.LicensureNum : "";
            TextBoxFacilityName.Text = (currentAffiliation != null) ? currentAffiliation.FacilityName : "";
            TextBoxGeoStreetAddress.Text = (currentAffiliation != null) ? currentAffiliation.Street : "";
            TextBoxGeoCity.Text = (currentAffiliation != null) ? currentAffiliation.City : "";
            TextBoxGeoState.Text = (currentAffiliation != null) ? currentAffiliation.StateCode : "";
            RadMaskedTextBoxGeoZip.Text = (currentAffiliation != null) ? currentAffiliation.ZipCode : "";
            RadMaskedTextBoxTelephoneNumber.Text = (currentAffiliation != null) ? currentAffiliation.TelephoneNumber : "";
            RadMaskedTextBoxFaxNumber.Text = (currentAffiliation != null) ? currentAffiliation.FaxPhoneNumber : "";
            TextBoxNumberofUnits.Text = (currentAffiliation != null && currentAffiliation.Unit != null) ? currentAffiliation.Unit.ToString() : "";
            TextBoxLicensedBeds.Text = (currentAffiliation != null && currentAffiliation.TotalLicBeds != null) ? currentAffiliation.TotalLicBeds.ToString() : "";
            TextBoxPsychBeds.Text = (currentAffiliation != null && currentAffiliation.PsychiatricBeds != null) ? currentAffiliation.PsychiatricBeds.ToString() : "";
            TextBoxRehabBeds.Text = (currentAffiliation != null && currentAffiliation.RehabilitationBeds != null) ? currentAffiliation.RehabilitationBeds.ToString() : "";
            TextBoxSNFBeds.Text = (currentAffiliation != null && currentAffiliation.SnfBeds != null) ? currentAffiliation.SnfBeds.ToString() : "";
            TextBoxOtherLicBeds.Text = (currentAffiliation != null && currentAffiliation.OtherBeds != null) ? currentAffiliation.OtherBeds.ToString() : "";

            // set the value of the date control to null
            RadDatePickerOriginalLicenseDate.SelectedDate = null;
            if (currentAffiliation != null)
            {
                // set the value of the "Accreditation Expiration Date"
                if (currentAffiliation.OriginalLicensureDate != null
                    && currentAffiliation.OriginalLicensureDate.HasValue)
                {
                    // ensure that the date is a valid date
                    if(currentAffiliation.OriginalLicensureDate > RadDatePickerOriginalLicenseDate.MinDate 
                        && currentAffiliation.OriginalLicensureDate < RadDatePickerOriginalLicenseDate.MaxDate)
                        RadDatePickerOriginalLicenseDate.SelectedDate = currentAffiliation.OriginalLicensureDate;
                }
            }
            // setup the lookup comboboxes
            listParish.Items.Clear();
            listParish.DataSource = ParishLookups;
            listParish.DataTextField = "ParishName";
            listParish.DataValueField = "ParishCode";
            listParish.DataBind();
            if (currentAffiliation != null &&
                currentAffiliation.ParishCode != null && !currentAffiliation.ParishCode.Equals(""))
                listParish.SelectedValue = currentAffiliation.ParishCode;
            else
                listParish.SelectedValue = null;

            /* 
             * The CCN for an Offsite is not readily available, get it from the Provider's table
             * using the License number of the Offiste
             */
            string offsiteCCN = "";
            // SMM Fill the program ID while here
            string tmpProgramID = "";

            if (currentAffiliation != null)
            {
                BO_Providers boProviders = BO_Provider.SelectByField("LICENSURE_NUM", currentAffiliation.LicensureNum);
                if (boProviders != null && boProviders.Count > 0)
                {
                    BO_Provider tmpProvider = boProviders[0];
                    // the Federal Id is the CCN
                    offsiteCCN = tmpProvider.FederalID;
                    // Delete any "-" from the CCN
                    offsiteCCN = Regex.Replace(offsiteCCN, "-", "");
                    //Set ProgramID
                    tmpProgramID = tmpProvider.ProgramID;
                }
            }
            TextBoxCCN.Text = offsiteCCN;

            if ( ( "HC" ).Contains( tmpProgramID ) )
            {
                divCapacity_HC.Visible = true;
                divCapByBedType.Visible = false;

                if ( null != currentAffiliation && null != currentAffiliation.BO_ServicesAffiliationID )
                {
                    foreach ( BO_Service boSvc in currentAffiliation.BO_ServicesAffiliationID )
                    {
                        switch ( boSvc.ServiceType )
                        {
                            // ADULT DAY CARE - PRE-VOCATION/EMPLOYMENT RELATED SERVICES
                            case "4":
                                txtADCCapacity.Text = boSvc.Capacity.Value.ToString();
                                break;
                            // *SUPERVISED INDEPENDENT LIVING - SHARED LIVING CONVERSION
                            case "6":
                                txtSIL_SLCCapacity.Text = boSvc.Capacity.Value.ToString();
                                break;
                            // *RESPITE CARE - CENTER BASED
                            case "7":
                                txtRespiteCBCapacity.Text = boSvc.Capacity.Value.ToString();
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }

        private DataTable getFacilityOffsiteDataTable()
        {
            DataTable tmpDTbl = new DataTable();
            DataColumn tmpDCol = null;

            tmpDCol = new DataColumn("FACILITYNAME");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("AFFILIATIONTYPEDESC");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("LICENSURENUM");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("ORIGINALLICENSUREDATE");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("AFFILIATIONID");
            tmpDTbl.Columns.Add(tmpDCol);

            return tmpDTbl;
        }


        private DataTable grdOffsiteDataSource
        {
            get { return (DataTable)Session["grdOffsiteDataSource"]; }
            set { Session["grdOffsiteDataSource"] = value; }
        }

        /// <summary>
        /// Access the Session Variable savedBOAffiliations
        /// </summary>
        private BO_Affiliations savedBOAffiliations
        {
            get { return (BO_Affiliations)Session["savedBOAffiliations"]; }
            set { Session["savedBOAffiliations"] = value; }
        }

        private DataTable ParishLookups
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

        /// <summary>
        /// Reload the fields with the current provider
        /// </summary>
        /// <param name="boProvider"></param>
        public void LoadNewProvider(string popsIntId)
        {
            // reset the Session object that stores BOAffiliations
            savedBOAffiliations = null;

            // delete pre-existing rows from datasource table
            DataTable dtTable1 = grdOffsiteDataSource;
            if (dtTable1 != null)
            {
                dtTable1.Rows.Clear();
                dtTable1.AcceptChanges();
                grdOffsiteDataSource = dtTable1;
                // set the dataSource object for the grid
                grdOffsite.DataSource = (DataTable)grdOffsiteDataSource;
                grdOffsite.DataBind();
            }

            if(!string.IsNullOrEmpty(popsIntId))
            {
                // reload the data for the History grid
                InitHistoryGrid(popsIntId);
                // bind the grid
                grdOffsite.DataBind();
                // pre-select the first row in the grid
                if (grdOffsite.Items.Count > 0)
                {
                    // select the first row
                    grdOffsite.Items[0].Selected = true;
                    // reload data in the controls
                    LoadSelectedItem();
                }
                else
                {
                    // Clear the values of the input controls
                    InitFields(null);
                }
            }
            else
            {
                // Clear the values of the input controls
                InitFields(null);
            }
        }


    }
}