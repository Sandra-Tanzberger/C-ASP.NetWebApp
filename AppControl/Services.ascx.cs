using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ATG.BusinessObject;
using ATG;
using System.Data;
using Telerik.Web.UI;

namespace AppControl
{
    public partial class Services : System.Web.UI.UserControl
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            // add a JavaScript call to the OnClick event of the Checkbox
            // to enable/diable other checkboxes
            chkHomeTraining.Attributes.Add( "onClick", "EnableDisableCheckBoxes();" );
            chkHomeSupport.Attributes.Add( "onClick", "EnableDisableCheckBoxes();" );
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //if ( CurrentAppProvider != null && CurrentProvider.ProgramID.Equals( "SA" ) )
            //    lblHeader.Text = "Capacity";
            //else
            //    lblHeader.Text = "Licensure Number";
        }

        /// <summary>
        /// Set the Checked property of the checkbox, where needed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ServicesRepeater_ItemDataBound( object sender, RepeaterItemEventArgs e )
        {
            Repeater tmpSvcsRptr = (Repeater) sender;

            if ( e.Item.ItemType == ListItemType.Footer )
            {
                Table tmpSvcTbl = (Table) tmpSvcsRptr.FindControlRecursive( "SvcsRptr" );
                Label tmpLblHeaderCapOrLicNum = (Label) tmpSvcsRptr.FindControlRecursive( "lblHeaderCapOrLicNum" );
                Label tmpLblHeaderOther = (Label) tmpSvcsRptr.FindControlRecursive( "lblHeaderOther" );

                if ( null != tmpLblHeaderCapOrLicNum )
                {
                    if ( CurrentAppProvider != null && CurrentProvider.ProgramID.Equals( "SA" ) )
                        tmpLblHeaderCapOrLicNum.Text = "Census   /   Capacity";
                    else if ( CurrentAppProvider != null && CurrentProvider.ProgramID.Equals( "CM" ) )
                        tmpLblHeaderCapOrLicNum.Text = "";
                    else
                        tmpLblHeaderCapOrLicNum.Text = "Licensure Number";
                }

                //if ( null != tmpSvcTbl )
                //{
                //    // If the list of services does not have an other category for data entry then hide the columns
                //    // in the header and child rows
                    if ( !SvcsHasOtherCateg )
                    {
                        tmpLblHeaderOther.Text = "";
                //        tmpSvcTbl.Rows[0].Cells[0].ColumnSpan = 3; //First row is <hr> tag.
                //        tmpSvcTbl.Rows[2].Cells[0].ColumnSpan = 3; //Third row is <hr> tag.

                //        foreach ( TableRow tmpTR in tmpSvcTbl.Rows )
                //        {
                //            tmpTR.Cells.RemoveAt( 3 ); // Remove 4th column
                //        }
                    }
                //}
            }
            else 
                BindServicesRepeater( e.Item );
        }

        protected void HP_CoreServices_ItemDataBound( object sender, RepeaterItemEventArgs e )
        {
            if ( e.Item.ItemType == ListItemType.Item
                || e.Item.ItemType == ListItemType.AlternatingItem )
            {
                HiddenField tmpSvcType = (HiddenField) e.Item.FindControl( "hidHP_CoreServiceType" );
                RadComboBox tmpSvcTypeOpt = (RadComboBox) e.Item.FindControl( "listCoreSrvcTypeOptions" );
                Label tmpSvcTypeDesc = (Label) e.Item.FindControl( "lblCoreServiceTypeDesc" );

                tmpSvcTypeOpt.AppendDataBoundItems = true;
                tmpSvcTypeOpt.Items.Add( new RadComboBoxItem( "", "" ) );

                foreach ( BO_LookupValue boLV in ServiceSubtypes )
                {
                    if ( boLV.LookupVal.Equals("1") ) //Subtype - Direct Staff
                    {
                        tmpSvcTypeOpt.Items.Add( new RadComboBoxItem( boLV.Valdesc, boLV.LookupVal ) );
                    }
                    else if ( boLV.LookupVal.Equals( "2" ) && tmpSvcType.Value.Equals( "1" ) ) //Subtype - Under arrangement and Type Service is Physician
                    {
                        tmpSvcTypeOpt.Items.Add( new RadComboBoxItem( boLV.Valdesc, boLV.LookupVal ) );
                    }                    
                }

                BO_Service tmpService = _FindService( tmpSvcType.Value );

                if ( null != tmpService && !string.IsNullOrEmpty( tmpService.ServiceSubtypes ) )
                {
                    tmpSvcTypeOpt.SelectedValue = tmpService.ServiceSubtypes;
                }
            }

        }

        protected void HP_OtherServices_ItemDataBound( object sender, RepeaterItemEventArgs e )
        {
            if ( e.Item.ItemType == ListItemType.Item
                || e.Item.ItemType == ListItemType.AlternatingItem )
            {
                HiddenField tmpSvcType = (HiddenField) e.Item.FindControl( "hidHP_OtherServiceType" );
                TextBox tmpTextTypeOther = (TextBox) e.Item.FindControl( "txtHPSrvcTypeOther" );
                RadComboBox tmpSvcTypeOpt = (RadComboBox) e.Item.FindControl( "listOtherSrvcTypeOptions" );
                Label tmpSvcTypeDesc = (Label) e.Item.FindControl( "lblOtherServiceTypeDesc" );

                // make the OTHER textbox visible, if applicable
                if ( tmpSvcTypeDesc != null && tmpSvcTypeDesc.Text.Trim().ToUpper().Contains( "OTHER" ) )
                    tmpTextTypeOther.Visible = true;
                else
                    tmpTextTypeOther.Visible = false;

                tmpSvcTypeOpt.AppendDataBoundItems = true;
                tmpSvcTypeOpt.Items.Add( new RadComboBoxItem( "", "" ) );

                foreach ( BO_LookupValue boLV in ServiceSubtypes )
                {
                    tmpSvcTypeOpt.Items.Add( new RadComboBoxItem( boLV.Valdesc, boLV.LookupVal ) );
                }

                BO_Service tmpService = _FindService( tmpSvcType.Value );

                if ( null != tmpService && !string.IsNullOrEmpty( tmpService.ServiceSubtypes ) )
                {
                    tmpSvcTypeOpt.SelectedValue = tmpService.ServiceSubtypes;
                    tmpTextTypeOther.Text = tmpService.TypeServiceOther;
                }
            }
        }

        protected void HH_Services_ItemDataBound( object sender, RepeaterItemEventArgs e )
        {
            if ( e.Item.ItemType == ListItemType.Item
                || e.Item.ItemType == ListItemType.AlternatingItem )
            {
                HiddenField tmpSvcType = (HiddenField) e.Item.FindControl( "hidHH_ServiceType" );
                TextBox tmpTextTypeOther = (TextBox) e.Item.FindControl( "txtHHSrvcTypeOther" );
                RadComboBox tmpSvcTypeOpt = (RadComboBox) e.Item.FindControl( "listHHSrvcTypeOptions" );
                Label tmpSvcTypeDesc = (Label) e.Item.FindControl( "lblHHServiceTypeDesc" );

                // make the OTHER textbox visible, if applicable
                if ( tmpSvcTypeDesc != null && tmpSvcTypeDesc.Text.Trim().ToUpper().Contains( "OTHER" ) )
                    tmpTextTypeOther.Visible = true;
                else
                    tmpTextTypeOther.Visible = false;

                tmpSvcTypeOpt.AppendDataBoundItems = true;
                tmpSvcTypeOpt.Items.Add( new RadComboBoxItem( "", "" ) );

                foreach ( BO_LookupValue boLV in ServiceSubtypes )
                {
                    tmpSvcTypeOpt.Items.Add( new RadComboBoxItem( boLV.Valdesc, boLV.LookupVal ) );
                }

                BO_Service tmpService = _FindService( tmpSvcType.Value );

                if ( null != tmpService && !string.IsNullOrEmpty( tmpService.ServiceSubtypes ) )
                {
                    tmpSvcTypeOpt.SelectedValue = tmpService.ServiceSubtypes;
                    tmpTextTypeOther.Text = tmpService.TypeServiceOther;
                }
            }
        }

        protected void FF_Services_ItemDataBound( object sender, RepeaterItemEventArgs e )
        {
            if ( e.Item.ItemType == ListItemType.Item
                || e.Item.ItemType == ListItemType.AlternatingItem )
            {
                CheckBox tmpchkSvcType = (CheckBox) e.Item.FindControl( "chkFF_Service" );
                HiddenField tmpSvcType = (HiddenField) e.Item.FindControl( "hidFF_ServiceType" );

                BO_Service tmpService = _FindService( tmpSvcType.Value );

                if ( null != tmpService )
                {
                    tmpchkSvcType.Checked = true;
                }
            }
        }

        protected void AS_Services_ItemDataBound(object sender, RepeaterItemEventArgs e) {
            if (e.Item.ItemType == ListItemType.Item
                || e.Item.ItemType == ListItemType.AlternatingItem) {
                CheckBox tmpchkSvcType = (CheckBox)e.Item.FindControl("chkAS_Service");
                HiddenField tmpSvcType = (HiddenField)e.Item.FindControl("hidAS_ServiceType");

                BO_Service tmpService = _FindService(tmpSvcType.Value);

                if (null != tmpService) {
                    tmpchkSvcType.Checked = true;
                }
            }
        }

        protected void CO_Services_ItemDataBound(object sender, RepeaterItemEventArgs e) {
            if (e.Item.ItemType == ListItemType.Item
                || e.Item.ItemType == ListItemType.AlternatingItem) {
                CheckBox tmpchkSvcType = (CheckBox)e.Item.FindControl("chkCO_Service");
                HiddenField tmpSvcType = (HiddenField)e.Item.FindControl("hidCO_ServiceType");

                BO_Service tmpService = _FindService(tmpSvcType.Value);

                if (null != tmpService) {
                    tmpchkSvcType.Checked = true;
                }
            }
        }

        /// <summary>
        /// Load the Services for the Current Application
        /// </summary>
        public void LoadApplication( string inKeyID, bool inAllowEdit, bool inIsOffsiteAffil )
        {
            IsOffSite = inIsOffsiteAffil;
            AllowEdit = inAllowEdit;

            if ( CurrentAppProvider != null )
            {
                if ( IsOffSite && !string.IsNullOrEmpty( inKeyID ) )
                    CurrentAffiliationID = inKeyID;

                InitServices();
            }
            _ShowHideFields();

            
            //InitOperationType(inIdx)
        }

        private void _ShowHideFields()
        {
            //if (Session["userType"].ToString() == "Public")
            //{
            //    if ( CurrentAppProvider.BusinessProcessID == "4" || CurrentAppProvider.BusinessProcessID == "5" || CurrentAppProvider.BusinessProcessID == "6" || CurrentAppProvider.BusinessProcessID == "8" || CurrentAppProvider.BusinessProcessID == "9" || CurrentAppProvider.ApplicationStatus.Equals("4"))
            //    {
            //        DisableServices();
            //    }
            //}

            //Behavioral Health/BH 
            if ( CurrentProvider.ProgramID.Equals( "BH" ) )
            {
                DivBH_Svcs.Visible = true;

                //hide SA services and repeater
                DivOther_Svcs.Visible = false;
                lblTreatmentType.Visible = false;
                lblClientType.Visible = false;
                lblOperationType.Visible = false;
                optTreatmentType.Visible = false;
                optClientType.Visible = false;
                optOperationType.Visible = false;
            }

            // Substance Abuse
            if ( CurrentProvider.ProgramID.Equals( "SA" ) )
            {
                DivOther_Svcs.Visible = true;
                ServicesRepeater.DataSource = ServicesDataSource;
                ServicesRepeater.DataBind();

                lblTreatmentType.Visible = true;
                lblClientType.Visible = true;
                lblOperationType.Visible = true;
                optTreatmentType.Visible = true;
                optClientType.Visible = true;
                optOperationType.Visible = true;
            }
            else
            {
                DivOther_Svcs.Visible = false;
                
                lblTreatmentType.Visible = false;
                lblClientType.Visible = false;
                lblOperationType.Visible = false;
                optTreatmentType.Visible = false;
                optClientType.Visible = false;
                optOperationType.Visible = false;
            }

            // HCBS
            if ( CurrentProvider.ProgramID.Equals( "HC" ) )
            {
                DivHCBS_Svcs.Visible = true;
                DivOther_Svcs.Visible = false;
            }
            else
            {
                DivHCBS_Svcs.Visible = false;
            }

            // Hospice
            if ( CurrentProvider.ProgramID.Equals( "HP" ) )
            {
                DivHP_Svcs.Visible = true;
                DivOther_Svcs.Visible = false;

                if ( !AllowEdit )
                {
                    foreach ( RepeaterItem tmpItm in rptrHP_CoreServices.Items )
                    {
                        RadComboBox tmpSvcTypeOpt = (RadComboBox) tmpItm.FindControl( "listCoreSrvcTypeOptions" );

                        if ( null != tmpSvcTypeOpt )
                            tmpSvcTypeOpt.Enabled = false;

                    }

                    foreach ( RepeaterItem tmpItm in rptrHP_OtherServices.Items )
                    {
                        RadComboBox tmpSvcTypeOpt = (RadComboBox) tmpItm.FindControl( "listOtherSrvcTypeOptions" );
                        HiddenField tmpSvcType = (HiddenField) tmpItm.FindControl( "hidHP_OtherServiceType" );
                        TextBox tmpTextTypeOther = (TextBox) tmpItm.FindControl( "txtHPSrvcTypeOther" );

                        if ( null != tmpSvcTypeOpt )
                            tmpSvcTypeOpt.Enabled = false;

                        if ( null != tmpSvcType && tmpSvcType.Value.Equals( "14" ) && null != tmpTextTypeOther )
                            tmpTextTypeOther.Enabled = false;
                    }
                }
            }
            else
            {
                DivHP_Svcs.Visible = false;
            }

            // Home Health
            if ( CurrentProvider.ProgramID.Equals( "HH" ) )
            {
                DivHH_Svcs.Visible = true;
                DivOther_Svcs.Visible = false;

                if ( !AllowEdit )
                {
                    foreach ( RepeaterItem tmpRI in rptrHH_Services.Items )
                    {
                        RadComboBox tmpSvcTypeOpt = (RadComboBox) tmpRI.FindControl( "listHHSrvcTypeOptions" );
                        HiddenField tmpSvcType = (HiddenField) tmpRI.FindControl( "hidHH_ServiceType" );
                        TextBox tmpTextTypeOther = (TextBox) tmpRI.FindControl( "txtHHSrvcTypeOther" );

                        if ( null != tmpSvcTypeOpt )
                            tmpSvcTypeOpt.Enabled = false;

                        if ( null != tmpSvcType && tmpSvcType.Value.Equals( "11" ) && null != tmpTextTypeOther )
                            tmpTextTypeOther.Enabled = false;
                    }
                }
            }
            else
            {
                DivHH_Svcs.Visible = false;
            }

            // Forensic Supervised
            if ( CurrentProvider.ProgramID.Equals( "FF" ) )
            {
                DivFF_Svcs.Visible = true;
                DivOther_Svcs.Visible = false;

                if ( !AllowEdit )
                {
                    foreach ( RepeaterItem tmpRI in rptrFF_Services.Items )
                    {
                        CheckBox tmpchkSvcType = (CheckBox) tmpRI.FindControl( "chkFF_Service" );

                        if ( null != tmpchkSvcType )
                            tmpchkSvcType.Enabled = false;

                    }
                }
            }
            else
            {
                DivFF_Svcs.Visible = false;
            }

            if ( CurrentProvider.ProgramID.Equals( "ES" ) )
            {
                DivES_Svcs.Visible = true;
                DivOther_Svcs.Visible = false;
            }
            else
            {
                DivES_Svcs.Visible = false;
            }

            if ( CurrentProvider.ProgramID.Equals( "CM" ) )
            {
                DivOther_Svcs.Visible = true;
                ServicesRepeater.DataSource = ServicesDataSource;
                ServicesRepeater.DataBind();
            }

            if (CurrentProvider.ProgramID.Equals("AS")) {
                DivAS_Svcs.Visible = true;
            }
            else {
                DivAS_Svcs.Visible = false;
            }

            if (CurrentProvider.ProgramID.Equals("CO")) {
                DivCO_Svcs.Visible = true;
            }
            else {
                DivCO_Svcs.Visible = false;
            }
        }



        /// <summary>
        /// Set the values of the desired columns in the CurrentServicesList collection
        /// </summary>
        public bool SaveData()
        {
            bool noSaveError = true;
            string validationErrors = "";

            ErrorText.Visible = false;
            ErrorText.InnerHtml = "";

            if ( !( "ES,HC,HP,HH,AS,CO" ).Contains( CurrentProvider.ProgramID ) )
            {
                // Update the Business Objects with the current data
                foreach ( RepeaterItem tmpRI in ServicesRepeater.Items )
                {
                    CheckBox tmpCheckBoxServiceType = (CheckBox) tmpRI.FindControl( "chkServiceType" );
                    HiddenField tmpHiddenFieldServiceType = (HiddenField) tmpRI.FindControl( "HiddenFieldServiceType" );
                    HiddenField tmpHiddenFieldExtra = (HiddenField) tmpRI.FindControl( "HiddenFieldExtra" );
                    TextBox tmpTextBoxServiceLicNumber = (TextBox) tmpRI.FindControl( "txtServiceLicNumber" );
                    RadNumericTextBox tmpRNTextBoxServiceCapacity = (RadNumericTextBox) tmpRI.FindControl( "txtServiceCapacity" );
                    RadNumericTextBox tmpRNTextBoxServiceCensus = (RadNumericTextBox) tmpRI.FindControl( "txtServiceCensus" );
                    TextBox tmpTextBoxTypeServiceOther = (TextBox) tmpRI.FindControl( "txtTypeServiceOther" );

                    // Add/Update appropriate Service Object
                    AddUpdateServiceService( tmpCheckBoxServiceType, tmpHiddenFieldServiceType, tmpHiddenFieldExtra, tmpTextBoxServiceLicNumber, tmpRNTextBoxServiceCapacity, tmpTextBoxTypeServiceOther, tmpRNTextBoxServiceCensus );
                }

                // Referesh the repeater controls
                foreach ( RepeaterItem tmpRI in ServicesRepeater.Items )
                {
                    BindServicesRepeater( tmpRI );
                }
            }

            if ( null != CurrentAppProvider )
            {
                switch ( CurrentProvider.ProgramID )
                {
                    case "ES":
                        noSaveError = _SaveESRD_Services();
                        break;
                    case "SA":
                        noSaveError = _SaveSA_Services();
                        break;
                    case "HC":
                        noSaveError = _SaveHCBS_Services();
                        break;
                    case "HP":
                        noSaveError = _SaveHP_Services();
                        break;
                    case "HH":
                        noSaveError = _SaveHH_Services();
                        break;
                    case "FF":
                        noSaveError = _SaveFF_Services();
                        break;
                    case "AS":
                        noSaveError = _SaveAS_Services();
                        break;
                    case "CO":
                        noSaveError = _SaveCO_Services();
                        break;
                    case "BH":
                        noSaveError = _SaveBH_Services();
                        break;
                }
            }

            if ( !noSaveError )
            {
                ErrorText.Visible = true;
                //ErrorText.InnerHtml = validationErrors;
            }

            return noSaveError;
        }

        private bool _SaveBH_Services()
        {
            if (BHServicesChanged.Value == "true")
            {
                BO_Service BHService = new BO_Service();

                //delete all current services for this application
                foreach (BO_Service _service in CurrentAppProvider.BO_ServicesApplicationID)
                {
                    _service.Delete();
                }

                //set current application services list to null to block application.savefullapplication process
                CurrentAppProvider.BO_ServicesApplicationID = null;

                //add new application services and subtype services
                foreach (ListItem item in chkBHTreatmentType.Items)
                {
                    if (item.Selected)
                    {
                        BHService.PopsIntID = CurrentProvider.PopsIntID;
                        BHService.ApplicationID = CurrentAppProvider.ApplicationID;
                        BHService.ServiceType = item.Value;
                        BHService.TypeServiceOther = "BHTreatmentType";
                        BHService.InsertWithDefaultValues(false);
                    }
                }

                foreach (ListItem item in chkBHClientType.Items)
                {
                    if (item.Selected)
                    {
                        BHService.PopsIntID = CurrentProvider.PopsIntID;
                        BHService.ApplicationID = CurrentAppProvider.ApplicationID;
                        BHService.ServiceType = item.Value;
                        BHService.TypeServiceOther = "BHClientType";
                        BHService.InsertWithDefaultValues(false);
                    }
                }

                foreach (ListItem item in chkBHOperationType.Items)
                {
                    if (item.Selected)
                    {
                        BHService.PopsIntID = CurrentProvider.PopsIntID;
                        BHService.ApplicationID = CurrentAppProvider.ApplicationID;
                        BHService.ServiceType = item.Value;
                        BHService.TypeServiceOther = "BHOperationType";
                        foreach (ListItem facilityItem in chkBHFacilityDescription.Items)
                        {
                            if (facilityItem.Selected)
                                BHService.ServiceSubtypes += facilityItem.Value.ToString() + ",";
                        }
                        if (!String.IsNullOrEmpty(BHService.ServiceSubtypes))
                        {
                            BHService.ServiceSubtypes = BHService.ServiceSubtypes.TrimEnd(',');
                        }
                        if (txtNumberLicensedUnits.Visible & txtNumberLicensedUnits.Text.Length > 0)
                            BHService.NumberUnits = Int32.Parse(txtNumberLicensedUnits.Text);
                        if (txtNumberLicensedBeds.Visible & txtNumberLicensedBeds.Text.Length > 0)
                            BHService.NumberBeds = Int32.Parse(txtNumberLicensedBeds.Text);
                        BHService.InsertWithDefaultValues(false);
                    }
                }
            }
            return true;
        }

        private bool _SaveESRD_Services()
        {
            //Currently no validation requirements for provider so always returns true
            //SMM TODO: Clairify section rules for provider
            bool noSaveError = true;
            BO_Service tmpService = null;

            //HEMODIALYSIS
            tmpService = null;
            tmpService = _FindService( "1" );
            if ( null != tmpService )
            {
                if ( !chkHemodialysis.Checked )
                     tmpService.Removed = true;
            }
            else
            {
                if ( chkHemodialysis.Checked )
                {
                    tmpService = _getNewService( "1" );
                    _AddServiceToLocation( tmpService );
                }
            }

            //PERITONEAL DIALYSIS
            tmpService = null;
            tmpService = _FindService( "2" );
            if ( null != tmpService )
            {
                if ( !chkPeritonealdialysis.Checked )
                    tmpService.Removed = true;
            }
            else
            {
                if ( chkPeritonealdialysis.Checked )
                {
                    tmpService = _getNewService( "2" );
                    _AddServiceToLocation( tmpService );
                }
            }

            //TRANSPLANTATION
            tmpService = null;
            tmpService = _FindService( "3" );
            if ( null != tmpService )
            {
                if ( !chkTransplantation.Checked )
                    tmpService.Removed = true;
            }
            else
            {
                if ( chkTransplantation.Checked )
                {
                    tmpService = _getNewService( "3" );
                    _AddServiceToLocation( tmpService );
                }
            }

            //HOME TRAINING
            tmpService = null;
            tmpService = _FindService( "4" );
            if ( null != tmpService )
            {
                if ( !chkHomeTraining.Checked )
                    tmpService.Removed = true;
                else
                {
                    string tmpSubTypes = "";

                    if ( chkHemodialysis2.Checked )
                        tmpSubTypes += "1";

                    if ( chkPeritonealdialysis2.Checked )
                    {
                        if ( tmpSubTypes.Length > 0 )
                            tmpSubTypes += ",";

                        tmpSubTypes += "2";
                    }

                    tmpService.ServiceSubtypes = tmpSubTypes;
                }
            }
            else
            {
                if ( chkHomeTraining.Checked )
                {
                    tmpService = _getNewService( "4" );

                    string tmpSubTypes = "";

                    if ( chkHemodialysis2.Checked )
                        tmpSubTypes += "1";

                    if ( chkPeritonealdialysis2.Checked )
                    {
                        if ( tmpSubTypes.Length > 0 )
                            tmpSubTypes += ",";

                        tmpSubTypes += "2";
                    }

                    tmpService.ServiceSubtypes = tmpSubTypes;
                    _AddServiceToLocation( tmpService );
                }
            }

            //HOME SUPPORT
            tmpService = null;
            tmpService = _FindService( "5" );
            if ( null != tmpService )
            {
                if ( !chkHomeSupport.Checked )
                    tmpService.Removed = true;
                else
                {
                    string tmpSubTypes = "";

                    if ( chkHemodialysis2.Checked )
                        tmpSubTypes += "1";

                    if ( chkPeritonealdialysis2.Checked )
                    {
                        if ( tmpSubTypes.Length > 0 )
                            tmpSubTypes += ",";

                        tmpSubTypes += "2";
                    }

                    tmpService.ServiceSubtypes = tmpSubTypes;
                }
            }
            else
            {
                if ( chkHomeSupport.Checked )
                {
                    tmpService = _getNewService( "5" );

                    string tmpSubTypes = "";

                    if ( chkHemodialysis3.Checked )
                        tmpSubTypes += "1";

                    if ( chkPeritonealdialysis3.Checked )
                    {
                        if ( tmpSubTypes.Length > 0 )
                            tmpSubTypes += ",";

                        tmpSubTypes += "2";
                    }

                    tmpService.ServiceSubtypes = tmpSubTypes;
                    _AddServiceToLocation( tmpService );
                }
            }

            CurrentAppProvider.HemodialysisNumOfStations = txtHemodialysis.Text;
            //CurrentAppProvider.HemodialysisTrainingNumOfStation = txtHemodialysisTraining.Text;
            CurrentAppProvider.IsolationNumOfStations = txtPeritoneal.Text; //Isolation = Peritoneal

            if ( rblIsolation.SelectedIndex != -1 )
                CurrentAppProvider.IsolationUnitYN = rblIsolation.SelectedValue;
            
            if ( rblReuse.SelectedIndex != -1 )
                CurrentAppProvider.ReuseYN = rblReuse.SelectedValue;

            return noSaveError;
        }

        private bool _SaveSA_Services()
        {
            //Currently no validation requirements for provider so always returns true
            //SMM TODO: Clairify section rules for provider
            bool noSaveError = true;

            string tmpTreatTypeLst = "";

            foreach ( ListItem tmpLI in optTreatmentType.Items )
            {
                if ( tmpLI.Selected )
                {
                    if ( tmpTreatTypeLst.Length > 0 )
                        tmpTreatTypeLst += ",";

                    tmpTreatTypeLst += tmpLI.Value;
                }
            }

            if ( IsOffSite )
                CurrentAffiliation.TypeTreatment = tmpTreatTypeLst;
            else
                CurrentAppProvider.TypeTreatment = tmpTreatTypeLst;

            if ( optClientType.SelectedIndex != -1 )
            {
                if ( IsOffSite )
                    CurrentAffiliation.TypeOfClients = optClientType.SelectedValue;
                else
                    CurrentAppProvider.TypeOfClients = optClientType.SelectedValue;
            }

            if ( optOperationType.SelectedIndex != -1 )
            {
                if ( IsOffSite )
                    CurrentAffiliation.FacilityTypeCode = optOperationType.SelectedValue;
                else
                    CurrentAppProvider.FacilityTypeCode = optOperationType.SelectedValue;
            }            

            return noSaveError;
        }

        private bool _SaveHCBS_Services()
        {
            bool noSaveError = true;
            BO_Service tmpService = null;
            bool OneSelected = false;

            tmpService = _FindService( "2" );
            if ( chkPCA.Checked )
            {
                if ( null == tmpService )
                {
                    tmpService = _getNewService( "2" );
                }

                tmpService.FnrApprovalDate = rdpPCA_FNR_APRVL_DT.SelectedDate;

                if ( tmpService.IsNewRec )
                    _AddServiceToLocation( tmpService );

                OneSelected = true;
            }
            else
            {
                if ( null != tmpService )
                {
                    tmpService.Removed = true;
                }
            }

            tmpService = null;
            tmpService = _FindService( "3" );
            if ( chkSIL.Checked )
            {
                if ( null == tmpService )
                {
                    tmpService = _getNewService( "3" );
                }

                tmpService.FnrApprovalDate = rdpSIL_FNR_APRVL_DT.SelectedDate;

                if ( tmpService.IsNewRec )
                    _AddServiceToLocation( tmpService );

                OneSelected = true;
            }
            else
            {
                if ( null != tmpService )
                {
                    tmpService.Removed = true;
                }
            }

            tmpService = null;
            tmpService = _FindService( "6" );
            if ( chkSIL_SLC.Checked )
            {
                if ( null == tmpService )
                {
                    tmpService = _getNewService( "6" );
                }

                tmpService.FnrApprovalDate = rdpSIL_SLC_FNR_APRVL_DT.SelectedDate;
                tmpService.OcddApprovedDate = rdpOCDD_APRVL_DT.SelectedDate;
                tmpService.Capacity = txtSIL_SLC_CAPACITY.Text.Length > 0 ? Convert.ToInt16( txtSIL_SLC_CAPACITY.Text ) : 0;
                tmpService.IcfddLicenseNum = txtSUR_ICFDD_LIC_NUM.Text;
                tmpService.IcfddLicenseExpDate = rdpSUR_ICFDD_LIC_EXP_DT.SelectedDate;

                if ( tmpService.IsNewRec )
                    _AddServiceToLocation( tmpService );

                OneSelected = true;
            }
            else
            {
                if ( null != tmpService )
                {
                    tmpService.Removed = true;
                }
            }

            tmpService = null;
            tmpService = _FindService( "8" );
            if ( chkRESPITE_IN_HOME.Checked )
            {
                if ( null == tmpService )
                {
                    tmpService = _getNewService( "8" );
                }

                tmpService.FnrApprovalDate = rdpFNR_RESPITE_IN_HOME_DT.SelectedDate;

                if ( tmpService.IsNewRec )
                    _AddServiceToLocation( tmpService );

                OneSelected = true;
            }
            else
            {
                if ( null != tmpService )
                {
                    tmpService.Removed = true;
                }
            }

            tmpService = null;
            tmpService = _FindService( "7" );
            if ( chkRESPITE_CENTER_BASED.Checked )
            {
                if ( null == tmpService )
                {
                    tmpService = _getNewService( "7" );
                }

                tmpService.FnrApprovalDate = rdpFNR_RESPITE_CENTER_BASED.SelectedDate;
                tmpService.Capacity = txtRESPITE_CENTER_BASED_CAPACITY.Text.Length > 0 ? Convert.ToInt16( txtRESPITE_CENTER_BASED_CAPACITY.Text ) : 0;

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

                OneSelected = true;
            }
            else
            {
                if ( null != tmpService )
                {
                    tmpService.Removed = true;
                }
            }

            tmpService = null;
            tmpService = _FindService( "10" );
            if ( chkSUPPORTED_EMPLOYMENT.Checked )
            {
                if ( null == tmpService )
                {
                    tmpService = _getNewService( "10" );
                }

                if ( tmpService.IsNewRec )
                    _AddServiceToLocation( tmpService );

                OneSelected = true;
            }
            else
            {
                if ( null != tmpService )
                {
                    tmpService.Removed = true;
                }
            }

            tmpService = null;
            tmpService = _FindService( "9" );
            if ( chkSUBSTITUTE_FAMILY_CARE.Checked )
            {
                if ( null == tmpService )
                {
                    tmpService = _getNewService( "9" );
                }

                if ( tmpService.IsNewRec )
                    _AddServiceToLocation( tmpService );

                OneSelected = true;
            }
            else
            {
                if ( null != tmpService )
                {
                    tmpService.Removed = true;
                }
            }

            tmpService = null;
            tmpService = _FindService("11");
            if (chkMONITORED_INHOME_CAREGIVING.Checked)
            {
                if (null == tmpService)
                {
                    tmpService = _getNewService("11");
                }

                tmpService.FnrApprovalDate = rdpMIC_NEEDREVIEW_DT.SelectedDate;

                if (tmpService.IsNewRec)
                    _AddServiceToLocation(tmpService);

                OneSelected = true;
            }
            else
            {
                if (null != tmpService)
                {
                    tmpService.Removed = true;
                }
            }

            tmpService = null;
            tmpService = _FindService( "1" );
            if ( chkFAMILY_SUPPORT.Checked )
            {
                if ( null == tmpService )
                {
                    tmpService = _getNewService( "1" );
                }

                if ( tmpService.IsNewRec )
                    _AddServiceToLocation( tmpService );

                OneSelected = true;
            }
            else
            {
                if ( null != tmpService )
                {
                    tmpService.Removed = true;
                }
            }

            tmpService = null;
            tmpService = _FindService( "4" );
            if ( chkADC.Checked )
            {
                string tmpSrvcSubTypes = "";

                if ( null == tmpService )
                {
                    tmpService = _getNewService( "4" );
                }

                tmpService.Capacity = txtADC_CAPACITY.Text.Length > 0 ? Convert.ToInt16( txtADC_CAPACITY.Text ) : 0;

                if ( chkADC_PREVOC.Checked )
                    tmpSrvcSubTypes += "1";

                if ( chkADC_DAY_HABILITATION.Checked )
                {
                    if ( tmpSrvcSubTypes.Length > 0 )
                        tmpSrvcSubTypes += ",";

                    tmpSrvcSubTypes += "2";
                }

                tmpService.ServiceSubtypes = tmpSrvcSubTypes;

                if ( tmpService.IsNewRec )
                    _AddServiceToLocation( tmpService );

                OneSelected = true;
            }
            else
            {
                if ( null != tmpService )
                {
                    tmpService.Removed = true;
                }
            }

            if ( !OneSelected && CurrentAppProvider.ApplicationStatus.Equals( "4" ) )
            {
                noSaveError = false;
                ErrorText.InnerHtml += "A minimum of one service must be selected if application status is set to 'Approved'<br/>";
            }

            return noSaveError;
        }

        private bool _SaveHP_Services()
        {
            bool noSaveError = true;

            foreach ( RepeaterItem tmpRI in rptrHP_CoreServices.Items )
            {
                RadComboBox tmpSvcTypeOpt = (RadComboBox) tmpRI.FindControl( "listCoreSrvcTypeOptions" );
                HiddenField tmpSvcType = (HiddenField) tmpRI.FindControl( "hidHP_CoreServiceType" );
                BO_Service tmpService = null;

                tmpService = null;
                tmpService = _FindService( tmpSvcType.Value );
                if ( null != tmpService )
                {
                    if ( null != tmpSvcTypeOpt && !string.IsNullOrEmpty( tmpSvcTypeOpt.SelectedValue ) )
                        tmpService.ServiceSubtypes = tmpSvcTypeOpt.SelectedValue;
                    else
                        tmpService.Removed = true;
                }
                else
                {
                    if ( null != tmpSvcTypeOpt && !string.IsNullOrEmpty( tmpSvcTypeOpt.SelectedValue ) )
                    {
                        tmpService = _getNewService( tmpSvcType.Value );
                        tmpService.ServiceSubtypes = tmpSvcTypeOpt.SelectedValue;
                        _AddServiceToLocation( tmpService );
                    }
                }
            }

            foreach ( RepeaterItem tmpRI in rptrHP_OtherServices.Items )
            {
                RadComboBox tmpSvcTypeOpt = (RadComboBox) tmpRI.FindControl( "listOtherSrvcTypeOptions" );
                HiddenField tmpSvcType = (HiddenField) tmpRI.FindControl( "hidHP_OtherServiceType" );
                TextBox tmpTextTypeOther = (TextBox) tmpRI.FindControl( "txtHPSrvcTypeOther" );
                BO_Service tmpService = null;

                tmpService = null;
                tmpService = _FindService( tmpSvcType.Value );
                if ( null != tmpService )
                {
                    if ( null != tmpSvcTypeOpt && !string.IsNullOrEmpty( tmpSvcTypeOpt.SelectedValue ) )
                    {
                        tmpService.ServiceSubtypes = tmpSvcTypeOpt.SelectedValue;
                        if ( tmpService.ServiceType.Equals( "14" ) )
                        {
                            tmpService.TypeServiceOther = tmpTextTypeOther.Text;
                        }
                    }
                    else
                        tmpService.Removed = true;
                }
                else
                {
                    if ( null != tmpSvcTypeOpt && !string.IsNullOrEmpty( tmpSvcTypeOpt.SelectedValue ) )
                    {
                        tmpService = _getNewService( tmpSvcType.Value );
                        tmpService.ServiceSubtypes = tmpSvcTypeOpt.SelectedValue;
                        
                        if ( tmpService.ServiceType.Equals( "14" ) )
                        {
                            tmpService.TypeServiceOther = tmpTextTypeOther.Text;
                        }

                        _AddServiceToLocation( tmpService );
                    }
                }
            }

            return noSaveError;
        }

        private bool _SaveHH_Services()
        {
            bool noSaveError = true;

            foreach ( RepeaterItem tmpRI in rptrHH_Services.Items )
            {
                RadComboBox tmpSvcTypeOpt = (RadComboBox) tmpRI.FindControl( "listHHSrvcTypeOptions" );
                HiddenField tmpSvcType = (HiddenField) tmpRI.FindControl( "hidHH_ServiceType" );
                TextBox tmpTextTypeOther = (TextBox) tmpRI.FindControl( "txtHHSrvcTypeOther" );
                BO_Service tmpService = null;

                tmpService = null;
                tmpService = _FindService( tmpSvcType.Value );
                if ( null != tmpService )
                {
                    if ( null != tmpSvcTypeOpt && !string.IsNullOrEmpty( tmpSvcTypeOpt.SelectedValue ) )
                    {
                        tmpService.ServiceSubtypes = tmpSvcTypeOpt.SelectedValue;
                        if ( tmpService.ServiceType.Equals( "11" ) )
                        {
                            tmpService.TypeServiceOther = tmpTextTypeOther.Text;
                        }
                    }
                    else
                        tmpService.Removed = true;
                }
                else
                {
                    if ( null != tmpSvcTypeOpt && !string.IsNullOrEmpty( tmpSvcTypeOpt.SelectedValue ) )
                    {
                        tmpService = _getNewService( tmpSvcType.Value );
                        tmpService.ServiceSubtypes = tmpSvcTypeOpt.SelectedValue;

                        if ( tmpService.ServiceType.Equals( "11" ) )
                        {
                            tmpService.TypeServiceOther = tmpTextTypeOther.Text;
                        }

                        _AddServiceToLocation( tmpService );
                    }
                }
            }

            return noSaveError;
        }

        private bool _SaveFF_Services()
        {
            bool noSaveError = true;

            foreach ( RepeaterItem tmpRI in rptrFF_Services.Items )
            {
                CheckBox tmpchkSvcType = (CheckBox) tmpRI.FindControl( "chkFF_Service" );
                HiddenField tmpSvcType = (HiddenField) tmpRI.FindControl( "hidFF_ServiceType" );

                BO_Service tmpService = null;
                
                tmpService = _FindService( tmpSvcType.Value );
                if ( null != tmpService && !tmpchkSvcType.Checked )
                {
                    tmpService.Removed = true;
                }
                else
                {
                    if ( null == tmpService && tmpchkSvcType.Checked )
                    {
                        tmpService = _getNewService( tmpSvcType.Value );
                        _AddServiceToLocation( tmpService );
                    }
                }
            }

            return noSaveError;
        }

        private bool _SaveAS_Services() {
            bool noSaveError = true;

            foreach (RepeaterItem tmpRI in rptrAS_Services.Items) {
                CheckBox tmpchkSvcType = (CheckBox)tmpRI.FindControl("chkAS_Service");
                HiddenField tmpSvcType = (HiddenField)tmpRI.FindControl("hidAS_ServiceType");

                BO_Service tmpService = null;

                tmpService = _FindService(tmpSvcType.Value);
                if (null != tmpService && !tmpchkSvcType.Checked) {
                    tmpService.Removed = true;
                }
                else {
                    if (null == tmpService && tmpchkSvcType.Checked) {
                        tmpService = _getNewService(tmpSvcType.Value);
                        _AddServiceToLocation(tmpService);
                    }
                }
            }

            return noSaveError;
        }

        private bool _SaveCO_Services() {
            bool noSaveError = true;

            foreach (RepeaterItem tmpRI in rptrCO_Services.Items) {
                CheckBox tmpchkSvcType = (CheckBox)tmpRI.FindControl("chkCO_Service");
                HiddenField tmpSvcType = (HiddenField)tmpRI.FindControl("hidCO_ServiceType");

                BO_Service tmpService = null;

                tmpService = _FindService(tmpSvcType.Value);
                if (null != tmpService && !tmpchkSvcType.Checked) {
                    tmpService.Removed = true;
                }
                else {
                    if (null == tmpService && tmpchkSvcType.Checked) {
                        tmpService = _getNewService(tmpSvcType.Value);
                        _AddServiceToLocation(tmpService);
                    }
                }
            }

            return noSaveError;
        }

        private void _AddServiceToLocation(BO_Service inService)
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

        private BO_Service _FindService( string inServiceType )
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

                if ( IsOffSite && CurrentAffiliationID.Substring( 0, 1 ) != "N" )
                    newService.AffiliationID = Convert.ToDecimal( CurrentAffiliationID );
                else if ( IsOffSite )
                    newService.AffiliationID = 0;
                
                newService.UI_TrackID = "N" + ServiceCnt.ToString();
            }
            else if ( null != CurrentAppProvider.BO_ServicesApplicationID )
            {
                newService.UI_TrackID = "N" + CurrentAppProvider.BO_ServicesApplicationID.Count.ToString();
            }
            else
            {
                newService.UI_TrackID = "N0";
            }

            return newService;
        }

        /// <summary>
        /// Disable the CheckBox and TextBox controls in the repeater
        /// NOTE: this is called from the STATE side code
        /// </summary>
        public void DisableServices()
        {
            foreach (RepeaterItem tmpRI in ServicesRepeater.Items)
            {
                if (tmpRI.ItemType == ListItemType.Item || tmpRI.ItemType == ListItemType.AlternatingItem)
                {
                    CheckBox tmpCheckBoxServiceType = (CheckBox)tmpRI.FindControl("chkServiceType");
                    TextBox tmpTextBoxServiceLicNumber = (TextBox)tmpRI.FindControl("txtServiceLicNumber");
                    RadNumericTextBox tmpRNTextBoxServiceCapacity = (RadNumericTextBox)tmpRI.FindControl("txtServiceCapacity");
                    RadNumericTextBox tmpRNTextBoxServiceCensus = (RadNumericTextBox) tmpRI.FindControl( "txtServiceCensus" );
                    TextBox tmpTextBoxTypeServiceOther = (TextBox)tmpRI.FindControl("txtTypeServiceOther");

                    tmpCheckBoxServiceType.Enabled = false;
                    tmpTextBoxServiceLicNumber.Enabled = false;
                    tmpRNTextBoxServiceCapacity.Enabled = false;
                    tmpTextBoxTypeServiceOther.Enabled = false;
                    tmpRNTextBoxServiceCensus.Enabled = false;
                }
            }

            // Disable the ESRD related controls
            chkHemodialysis.Enabled = false;
            chkPeritonealdialysis.Enabled = false;
            chkTransplantation.Enabled = false;
            chkHomeTraining.Enabled = false;
            chkHomeTraining.Enabled = false;
            chkHemodialysis2.Enabled = false;
            chkPeritonealdialysis2.Enabled = false;
            chkHomeSupport.Enabled = false;
            chkHemodialysis3.Enabled = false;
            chkPeritonealdialysis3.Enabled = false;

            lblPeritoneal.Enabled = false;
            lblPeritoneal.Enabled = false;
            lblReuse.Enabled = false;
            txtHemodialysis.Enabled = false;
            txtPeritoneal.Enabled = false;
            txtPeritoneal.Enabled = false;
            rblIsolation.Enabled = false;
            rblReuse.Enabled = false;

            // disable the Substance Abuse related controls
            lblTreatmentType.Enabled = false;
            lblClientType.Enabled = false;
            lblOperationType.Enabled = false;
            optTreatmentType.Enabled = false;
            optClientType.Enabled = false;
            optOperationType.Enabled = false;

            foreach (RepeaterItem tmpRI in rptrAS_Services.Items)
            {
                ((CheckBox)tmpRI.FindControl("chkAS_Service")).Enabled = false;
            }

            foreach (RepeaterItem tmpRI in rptrCO_Services.Items)
            {
                ((CheckBox)tmpRI.FindControl("chkCO_Service")).Enabled = false;
            }
        }

        /// <summary>
        /// Set the Repeater's datasource and bind the control
        /// </summary>
        private void InitServices()
        {
            if ( CurrentProvider.ProgramID.Equals("ES"))
            {
                foreach ( BO_Service boSvc in CurrentAppProvider.BO_ServicesApplicationID )
                {
                    switch ( boSvc.ServiceType )
                    {
                        case "1":
                            chkHemodialysis.Checked = true;
                            break;
                        case "2":
                            chkPeritonealdialysis.Checked = true;
                            break;
                        case "3":
                            chkTransplantation.Checked = true;
                            break;
                        case "4":
                            chkHomeTraining.Checked = true;
                            if ( !string.IsNullOrEmpty( boSvc.ServiceSubtypes ) )
                            {
                                if ( boSvc.ServiceSubtypes.Contains( "1" ) )
                                    chkHemodialysis2.Checked = true;
                                if ( boSvc.ServiceSubtypes.Contains( "2" ) )
                                    chkPeritonealdialysis2.Checked = true;
                            }
                            break;
                        case "5":
                            chkHomeSupport.Checked = true;
                            if ( !string.IsNullOrEmpty( boSvc.ServiceSubtypes ) )
                            {
                                if ( boSvc.ServiceSubtypes.Contains( "1" ) )
                                    chkHemodialysis3.Checked = true;
                                if ( boSvc.ServiceSubtypes.Contains( "2" ) )
                                    chkPeritonealdialysis3.Checked = true;
                            }
                            break;
                    }

                }

                txtHemodialysis.Text = (CurrentAppProvider.HemodialysisNumOfStations != null) ? CurrentAppProvider.HemodialysisNumOfStations : "";
                txtPeritoneal.Text = ( !string.IsNullOrEmpty( CurrentAppProvider.IsolationNumOfStations ) ) ? CurrentAppProvider.IsolationNumOfStations : "" ;
                int hemo = 0, iso = 0;
                int.TryParse(CurrentAppProvider.HemodialysisNumOfStations, out hemo);
                int.TryParse(CurrentAppProvider.IsolationNumOfStations, out iso);
                txtTotalNonTrainingStations.Text = (hemo + iso).ToString();

                if (CurrentAppProvider.IsolationUnitYN != null)
                {
                    rblIsolation.SelectedValue = CurrentAppProvider.IsolationUnitYN;
                }
                if (CurrentAppProvider.ReuseYN != null)
                {
                    rblReuse.SelectedValue = CurrentAppProvider.ReuseYN;
                }

            }


            // Substance Abuse
            if (CurrentProvider.ProgramID.Equals("BH"))
            {
                // Set the values
                _Init_BHSvcs();
            }

            // Substance Abuse
            if ( CurrentProvider.ProgramID.Equals( "SA" ) )
            {
                // Set the values
                _LoadFacSubTypeForSA();
            }

            // HCBS
            if ( CurrentProvider.ProgramID.Equals( "HC" ) )
            {
                _Init_HCBS();
            }

            // Hospice
            if ( CurrentProvider.ProgramID.Equals( "HP" ) )
            {
                _Init_HospiceSvcs();
            }

            // Home Health
            if ( CurrentProvider.ProgramID.Equals( "HH" ) )
            {
                _Init_HomeHealthSvcs();
            }

            // Home Health
            if ( CurrentProvider.ProgramID.Equals( "FF" ) )
            {
                _Init_ForensicSupervisedSvcs();
            }

            // Ambulatory Surgical Center
            if (CurrentProvider.ProgramID.Equals("AS")) {
                _Init_AmbSurgCtrSvcs();
            }

            // CORF
            if (CurrentProvider.ProgramID.Equals("CO")) {
                _Init_CORFSvcs();
            }
        }

        private void _Init_BHSvcs()
        {
            //init BH_SERVICES_TREATMENT_TYPE
            BO_LookupValues BHTypeTreatment = BO_LookupValue.SelectByField(BO_LookupValueFields.LookupKey, "BH_SERVICES_TREATMENT_TYPE");
            chkBHTreatmentType.DataSource = BHTypeTreatment;
            chkBHTreatmentType.DataTextField = "Valdesc";
            chkBHTreatmentType.DataValueField = "LookupVal";
            chkBHTreatmentType.DataBind();


            //init BH_SERVICES_CLIENT_TYPE
            BO_LookupValues BHClientType = BO_LookupValue.SelectByField(BO_LookupValueFields.LookupKey, "BH_SERVICES_CLIENT_TYPE");
            chkBHClientType.DataSource = BHClientType;
            chkBHClientType.DataTextField = "Valdesc";
            chkBHClientType.DataValueField = "LookupVal";
            chkBHClientType.DataBind();

            //init BH_SERVICES_OPERATION_TYPE
            BO_LookupValues BHOperationType = BO_LookupValue.SelectByField(BO_LookupValueFields.LookupKey, "BH_SERVICES_OPERATION_TYPE");
            chkBHOperationType.DataSource = BHOperationType;
            chkBHOperationType.DataTextField = "Valdesc";
            chkBHOperationType.DataValueField = "LookupVal";
            chkBHOperationType.DataBind();

            //set current application values
            BO_Services BHSvcs = null;
            if ( CurrentAppProvider.BO_ServicesApplicationID != null )
                        BHSvcs = CurrentAppProvider.BO_ServicesApplicationID;

            foreach(BO_Service Svcs in BHSvcs)
            {
                switch (Svcs.TypeServiceOther)
                {
                    case "BHTreatmentType":
                        switch (Svcs.ServiceType)
                        {
                            case "1":
                                chkBHTreatmentType.Items.FindByValue("1").Selected = true;
                                break;
                            case "2":
                                chkBHTreatmentType.Items.FindByValue("2").Selected = true;
                                break;
                        }
                        break;
                    default:
                        //no treatment type selected - do nothing
                        break;
                    case "BHClientType":
                        switch (Svcs.ServiceType)
                        {
                            case "1":
                                chkBHClientType.Items.FindByValue("1").Selected = true;
                                break;
                            case "2":
                                chkBHClientType.Items.FindByValue("2").Selected = true;
                                break;
                            case "3":
                                chkBHClientType.Items.FindByValue("3").Selected = true;
                                break;
                            case "4":
                                chkBHClientType.Items.FindByValue("4").Selected = true;
                                break;
                            default:
                                //no client type selected - do nothing
                                break;
                        }
                        break;
                    case "BHOperationType":
                        switch (Svcs.ServiceType)
                        {
                            case "1":
                                chkBHOperationType.Items.FindByValue("1").Selected = true;
                                lblLicensedUnits.Visible = true;
                                lblLicensedBeds.Visible = true;
                                txtNumberLicensedUnits.Text = Svcs.NumberUnits.ToString();
                                txtNumberLicensedUnits.Visible = true;
                                txtNumberLicensedBeds.Text = Svcs.NumberBeds.ToString();
                                txtNumberLicensedBeds.Visible = true;
                                lblFacilityDescription.Visible = true;
                                chkBHFacilityDescription.Visible = true;
                                BHOperationTypeSubTypes("BH_SERVICES_OPERATION_SUBTYPE_INPATIENT", Svcs.ServiceSubtypes);
                                break;
                            case "2":
                                chkBHOperationType.Items.FindByValue("2").Selected = true;
                                lblFacilityDescription.Visible = true;
                                chkBHFacilityDescription.Visible = true;
                                BHOperationTypeSubTypes("BH_SERVICES_OPERATION_SUBTYPE_OUTPATIENT", Svcs.ServiceSubtypes);
                                break;
                            case "3":
                                chkBHOperationType.Items.FindByValue("3").Selected = true;
                                lblLicensedUnits.Visible = true;
                                lblLicensedBeds.Visible = true;
                                txtNumberLicensedUnits.Text = Svcs.NumberUnits.ToString();
                                txtNumberLicensedUnits.Visible = true;
                                txtNumberLicensedBeds.Text = Svcs.NumberBeds.ToString();
                                txtNumberLicensedBeds.Visible = true;
                                lblFacilityDescription.Visible = true;
                                chkBHFacilityDescription.Visible = true;
                                BHOperationTypeSubTypes("BH_SERVICES_OPERATION_SUBTYPE_IN_OUTPATIENT", Svcs.ServiceSubtypes);
                                break;
                            default:
                                //no operation type selected - do nothing
                                break;
                        }
                        break;
                }
            }

        }

        private void BHOperationTypeSubTypes(string operationSubType, string svcsList)
        {
            switch (operationSubType)
            {
                case "BH_SERVICES_OPERATION_SUBTYPE_INPATIENT":
                    BO_LookupValues OperationSubTypeIN = BO_LookupValue.SelectByField(BO_LookupValueFields.LookupKey, "BH_SERVICES_OPERATION_SUBTYPE_INPATIENT");
                    chkBHFacilityDescription.DataSource = OperationSubTypeIN;
                    chkBHFacilityDescription.DataTextField = "Valdesc";
                    chkBHFacilityDescription.DataValueField = "LookupVal";
                    chkBHFacilityDescription.DataBind();
                    break;
                case "BH_SERVICES_OPERATION_SUBTYPE_OUTPATIENT":
                    BO_LookupValues OperationSubTypeOUT = BO_LookupValue.SelectByField(BO_LookupValueFields.LookupKey, "BH_SERVICES_OPERATION_SUBTYPE_OUTPATIENT");
                    chkBHFacilityDescription.DataSource = OperationSubTypeOUT;
                    chkBHFacilityDescription.DataTextField = "Valdesc";
                    chkBHFacilityDescription.DataValueField = "LookupVal";
                    chkBHFacilityDescription.DataBind();
                    break;
                case "BH_SERVICES_OPERATION_SUBTYPE_IN_OUTPATIENT":
                    BO_LookupValues OperationSubTypeINOUT = BO_LookupValue.SelectByField(BO_LookupValueFields.LookupKey, "BH_SERVICES_OPERATION_SUBTYPE_IN_OUTPATIENT");
                    chkBHFacilityDescription.DataSource = OperationSubTypeINOUT;
                    chkBHFacilityDescription.DataTextField = "Valdesc";
                    chkBHFacilityDescription.DataValueField = "LookupVal";
                    chkBHFacilityDescription.DataBind();
                    break;
                default:
                    //no operation type selected - do nothing
                    break;
            }

            //after loading checkboxlist set selected items
            if (!String.IsNullOrEmpty(svcsList))
            {
                string[] facilityDescriptions = svcsList.Split(',');

                foreach (string item in facilityDescriptions)
                {
                    chkBHFacilityDescription.Items.FindByValue(item).Selected = true;
                }
            }
        }

        private void _Init_HomeHealthSvcs()
        {
            rptrHH_Services.DataSource = ServicesDataSource;
            rptrHH_Services.DataBind();
        }

        private void _Init_HospiceSvcs()
        {
            rptrHP_CoreServices.DataSource = HP_CoreServicesDataSource;
            rptrHP_CoreServices.DataBind();
            rptrHP_OtherServices.DataSource = HP_OtherServicesDataSource;
            rptrHP_OtherServices.DataBind();
        }

        private void _Init_ForensicSupervisedSvcs()
        {
            rptrFF_Services.DataSource = ServicesDataSource;
            rptrFF_Services.DataBind();
        }

        private void _Init_AmbSurgCtrSvcs() 
        {
            rptrAS_Services.DataSource = ServicesDataSource;
            rptrAS_Services.DataBind();
        }

        private void _Init_CORFSvcs() {
            rptrCO_Services.DataSource = ServicesDataSource;
            rptrCO_Services.DataBind();
        }

        // Initialize HCBS Provider
        private void _Init_HCBS()
        {
            //Add click events for svcs that have a child group of controls
            chkPCA.Attributes.Add( "onclick", "ToggleGroupROstateHCBS( '" + tblPCA.ClientID + "', 'PCA', 'N')" );
            chkADC.Attributes.Add( "onclick", "ToggleGroupROstateHCBS( '" + tblADC.ClientID + "', 'ADC', 'N')" );
            chkRESPITE_CENTER_BASED.Attributes.Add( "onclick", "ToggleGroupROstateHCBS( '" + tblRESPITE_CENTER_BASED.ClientID + "', 'RESPITE_CENTER_BASED', 'N')" );
            chkRESPITE_IN_HOME.Attributes.Add( "onclick", "ToggleGroupROstateHCBS( '" + tblRESPITE_IN_HOME.ClientID + "', 'RESPITE_IN_HOME', 'N')" );
            chkSIL.Attributes.Add( "onclick", "ToggleGroupROstateHCBS( '" + tblSIL.ClientID + "','SIL', 'N')" );
            chkSIL_SLC.Attributes.Add( "onclick", "ToggleGroupROstateHCBS( '" + tblSIL_SLC.ClientID + "', 'SIL_SLC', 'N')" );
            
            //This is used with a register startup script for HCBS to make the entire svcs section readonly
            //look into StateFacilityPage.aspx for implementation
            hidSvcsDivClientID.Value = DivHCBS_Svcs.ClientID;
            hidGroupStateClientIDs.Value = GroupStateIDs();

            if ( AllowEdit )
            {
                txtHoursMinutesFrom.Enabled = true;
                txtHoursMinutesTo.Enabled = true;
            }
            else
            {
                txtHoursMinutesFrom.Enabled = false;
                txtHoursMinutesTo.Enabled = false;
            }

            BO_Services tmpSvcs = null;

            if ( CurrentAppProvider.ApplicationID != null )
            {
                if ( !IsOffSite )
                {
                    if ( CurrentAppProvider.BO_ServicesApplicationID != null )
                        tmpSvcs = CurrentAppProvider.BO_ServicesApplicationID;
                }
                else
                {
                    if ( CurrentAppProvider.BO_AffiliationsApplicationID != null )
                    {
                        foreach ( BO_Affiliation boAffil in CurrentAppProvider.BO_AffiliationsApplicationID )
                        {
                            if ( boAffil.UI_TrackID.Equals( CurrentAffiliationID ) )
                            {
                                tmpSvcs = boAffil.BO_ServicesAffiliationID;
                                break;
                            }
                        }
                    }
                }

                //If this is for an offsite the available list of services is limited to those that are available at
                //the parent provider
                if ( IsOffSite )
                {
                    //First set all to disabled
                    chkADC.Disabled = true;
                    chkFAMILY_SUPPORT.Disabled = true;
                    chkPCA.Disabled = true;
                    chkRESPITE_CENTER_BASED.Disabled = true;
                    chkRESPITE_IN_HOME.Disabled = true;
                    chkSIL.Disabled = true;
                    chkSIL_SLC.Disabled = true;
                    chkSUBSTITUTE_FAMILY_CARE.Disabled = true;
                    chkSUPPORTED_EMPLOYMENT.Disabled = true;
                    chkMONITORED_INHOME_CAREGIVING.Disabled = true;

                    rdpMIC_NEEDREVIEW_DT.Enabled = false;
                    rdpPCA_FNR_APRVL_DT.Enabled = false;
                    rdpSIL_FNR_APRVL_DT.Enabled = false;
                    txtADC_CAPACITY.Enabled = false;
                    chkADC_DAY_HABILITATION.Enabled = false;
                    chkADC_PREVOC.Enabled = false;
                    rdpSIL_SLC_FNR_APRVL_DT.Enabled = false;
                    rdpOCDD_APRVL_DT.Enabled = false;
                    txtSIL_SLC_CAPACITY.Enabled = false;
                    txtSUR_ICFDD_LIC_NUM.Enabled = false;
                    rdpSUR_ICFDD_LIC_EXP_DT.Enabled = false;
                    rdpFNR_RESPITE_CENTER_BASED.Enabled = false;
                    txtRESPITE_CENTER_BASED_CAPACITY.Enabled = false;
                    AttachLinkButtonSpan.Visible = false;
                    ViewLinkButtonSpan.Visible = false;

                    CheckBoxDayOfOperationMon.Enabled = false;
                    CheckBoxDayOfOperationTue.Enabled = false;
                    CheckBoxDayOfOperationWed.Enabled = false;
                    CheckBoxDayOfOperationThu.Enabled = false;
                    CheckBoxDayOfOperationFri.Enabled = false;
                    CheckBoxDayOfOperationSat.Enabled = false;
                    CheckBoxDayOfOperationSun.Enabled = false;

                    txtHoursMinutesFrom.Enabled = false;
                    listAmPmFrom.Enabled = false;
                    txtHoursMinutesTo.Enabled = false;
                    listAmPmTo.Enabled = false;
                    rdpFNR_RESPITE_IN_HOME_DT.Enabled = false;

                    if ( CurrentAppProvider.BO_ServicesApplicationID != null )
                    {
                        foreach ( BO_Service boSvc in CurrentAppProvider.BO_ServicesApplicationID )
                        {
                            switch ( boSvc.ServiceType )
                            {
                                // FAMILY SUPPORT
                                case "1":
                                    chkFAMILY_SUPPORT.Disabled = false;
                                    break;
                                // *PERSONAL CARE ATTENDANT
                                case "2":
                                    chkPCA.Disabled = false;
                                    rdpPCA_FNR_APRVL_DT.Enabled = true;
                                    break;
                                // *SUPERVISED INDEPENDENT LIVING
                                case "3":
                                    chkSIL.Disabled = false;
                                    rdpSIL_FNR_APRVL_DT.Enabled = true;
                                    break;
                                // ADULT DAY CARE - DAY HABILITATION and PRE-VOCATION/EMPLOYMENT RELATED SERVICES
                                case "4":
                                    chkADC.Disabled = false;
                                    txtADC_CAPACITY.Enabled = true;
                                    chkADC_DAY_HABILITATION.Enabled = true;
                                    chkADC_PREVOC.Enabled = true;
                                    break;
                                // *SUPERVISED INDEPENDENT LIVING - SHARED LIVING CONVERSION
                                case "6":
                                    chkSIL_SLC.Disabled = false;
                                    rdpSIL_SLC_FNR_APRVL_DT.Enabled = true;
                                    rdpOCDD_APRVL_DT.Enabled = true;
                                    txtSIL_SLC_CAPACITY.Enabled = true;
                                    txtSUR_ICFDD_LIC_NUM.Enabled = true;
                                    rdpSUR_ICFDD_LIC_EXP_DT.Enabled = true;
                                    AttachLinkButtonSpan.Visible = true;
                                    break;
                                // *RESPITE CARE - CENTER BASED
                                case "7":
                                    chkRESPITE_CENTER_BASED.Disabled = false;
                                    rdpFNR_RESPITE_CENTER_BASED.Enabled = true;
                                    txtRESPITE_CENTER_BASED_CAPACITY.Enabled = true;
                                    CheckBoxDayOfOperationMon.Enabled = true;
                                    CheckBoxDayOfOperationTue.Enabled = true;
                                    CheckBoxDayOfOperationWed.Enabled = true;
                                    CheckBoxDayOfOperationThu.Enabled = true;
                                    CheckBoxDayOfOperationFri.Enabled = true;
                                    CheckBoxDayOfOperationSat.Enabled = true;
                                    CheckBoxDayOfOperationSun.Enabled = true;
                                    txtHoursMinutesFrom.Enabled = true;
                                    listAmPmFrom.Enabled = true;
                                    txtHoursMinutesTo.Enabled = true;
                                    listAmPmTo.Enabled = true;
                                    break;
                                // *RESPITE CARE - IN HOME
                                case "8":
                                    chkRESPITE_IN_HOME.Disabled = false;
                                    rdpFNR_RESPITE_IN_HOME_DT.Enabled = true;
                                    break;
                                // SUBSTITUTE FAMILY CARE
                                case "9":
                                    chkSUBSTITUTE_FAMILY_CARE.Disabled = false;
                                    break;
                                // SUPPORTED EMPLOYMENT
                                case "10":
                                    chkSUPPORTED_EMPLOYMENT.Disabled = false;
                                    break;
                                //MONITORED IN-HOME CAREGIVING SERVICES
                                case "11":
                                    chkMONITORED_INHOME_CAREGIVING.Disabled = false;
                                    rdpMIC_NEEDREVIEW_DT.Enabled = true;
                                    break;
                                default:
                                    break;

                            }
                        }
                    }
                }
                else
                {
                    chkADC.Disabled = false;
                    chkFAMILY_SUPPORT.Disabled = false;
                    chkPCA.Disabled = false;
                    chkRESPITE_CENTER_BASED.Disabled = false;
                    chkRESPITE_IN_HOME.Disabled = false;
                    chkSIL.Disabled = false;
                    chkSIL_SLC.Disabled = false;
                    chkSUBSTITUTE_FAMILY_CARE.Disabled = false;
                    chkSUPPORTED_EMPLOYMENT.Disabled = false;
                    chkMONITORED_INHOME_CAREGIVING.Disabled = false;
                }

                if ( tmpSvcs != null )
                {
                    foreach ( BO_Service boSvc in tmpSvcs )
                    {
                        switch ( boSvc.ServiceType )
                        {
                            // FAMILY SUPPORT
                            case "1":
                                chkFAMILY_SUPPORT.Checked = true;
                                break;
                            // *PERSONAL CARE ATTENDANT
                            case "2":
                                chkPCA.Checked = true;
                                hidPCAGroupState.Value = "";
                                rdpPCA_FNR_APRVL_DT.SelectedDate = boSvc.FnrApprovalDate;
                                break;
                            // *SUPERVISED INDEPENDENT LIVING
                            case "3":
                                chkSIL.Checked = true;
                                hidSILGroupState.Value = "";
                                rdpSIL_FNR_APRVL_DT.SelectedDate = boSvc.FnrApprovalDate;
                                break;
                            // ADULT DAY CARE - PRE-VOCATION/EMPLOYMENT RELATED SERVICES
                            case "4":
                                chkADC.Checked = true;
                                hidADCGroupState.Value = "";
                                txtADC_CAPACITY.Text = ( null != boSvc.Capacity ? boSvc.Capacity.Value.ToString() : "0" );

                                if ( null != boSvc.ServiceSubtypes )
                                {
                                    if ( boSvc.ServiceSubtypes.Contains( "2" ) )
                                    {
                                        chkADC_DAY_HABILITATION.Checked = true;
                                    }

                                    if ( boSvc.ServiceSubtypes.Contains( "1" ) )
                                    {
                                        chkADC_PREVOC.Checked = true;
                                    }
                                }
                                break;
                            // *SUPERVISED INDEPENDENT LIVING - SHARED LIVING CONVERSION
                            case "6":
                                chkSIL_SLC.Checked = true;
                                hidSIL_SLCGroupState.Value = "";
                                rdpSIL_SLC_FNR_APRVL_DT.SelectedDate = boSvc.FnrApprovalDate;
                                rdpOCDD_APRVL_DT.SelectedDate = boSvc.OcddApprovedDate;
                                txtSIL_SLC_CAPACITY.Text = ( null != boSvc.Capacity ? boSvc.Capacity.Value.ToString() : "0" );
                                txtSUR_ICFDD_LIC_NUM.Text = boSvc.IcfddLicenseNum;
                                rdpSUR_ICFDD_LIC_EXP_DT.SelectedDate = boSvc.IcfddLicenseExpDate;

                                if ( null != CurrentAppProvider.Attachments && null != boSvc.FileAttachID && boSvc.FileAttachID > 0 )
                                {
                                    foreach ( BO_FileAttach boFA in CurrentAppProvider.Attachments )
                                    {
                                        if ( boFA.FileAttachID == boSvc.FileAttachID )
                                        {
                                            AttachLinkButtonSpan.Visible = true;
                                            ServiceAttachAction.Text = "Remove";
                                            ServiceAttachAction.CommandArgument = boSvc.FileAttachID.Value.ToString();
                                            ViewLinkButtonSpan.Visible = true;
                                            ViewLinkButtonSpan.InnerHtml = "<a href='../../Common/FileViewer.aspx?AttID=" + boSvc.FileAttachID.Value.ToString() + "' target='_blank'>View</a>";
                                            break;
                                        }
                                    }
                                }
                                else
                                {
                                    ServiceAttachAction.Text = "Attach";
                                    ServiceAttachAction.Visible = true;
                                }
                                break;
                            // *RESPITE CARE - CENTER BASED
                            case "7":
                                chkRESPITE_CENTER_BASED.Checked = true;
                                hidRESPITE_CENTER_BASEDGroupState.Value = "";
                                rdpFNR_RESPITE_CENTER_BASED.SelectedDate = boSvc.FnrApprovalDate;
                                txtRESPITE_CENTER_BASED_CAPACITY.Text = ( null != boSvc.Capacity ? boSvc.Capacity.Value.ToString() : "0" );

                                CheckBoxDayOfOperationMon.Checked = ( null != boSvc.DayOfOperationMon && boSvc.DayOfOperationMon.Equals( "1" ) );
                                CheckBoxDayOfOperationTue.Checked = ( null != boSvc.DayOfOperationTue && boSvc.DayOfOperationTue.Equals( "1" ) );
                                CheckBoxDayOfOperationWed.Checked = ( null != boSvc.DayOfOperationWed && boSvc.DayOfOperationWed.Equals( "1" ) );
                                CheckBoxDayOfOperationThu.Checked = ( null != boSvc.DayOfOperationThu && boSvc.DayOfOperationThu.Equals( "1" ) );
                                CheckBoxDayOfOperationFri.Checked = ( null != boSvc.DayOfOperationFri && boSvc.DayOfOperationFri.Equals( "1" ) );
                                CheckBoxDayOfOperationSat.Checked = ( null != boSvc.DayOfOperationSat && boSvc.DayOfOperationSat.Equals( "1" ) );
                                CheckBoxDayOfOperationSun.Checked = ( null != boSvc.DayOfOperationSun && boSvc.DayOfOperationSun.Equals( "1" ) );

                                txtHoursMinutesFrom.Text = ( null != boSvc.OperatingHoursFromTime ? boSvc.OperatingHoursFromTime : "" );
                                listAmPmFrom.SelectedValue = ( null != boSvc.OperatingHoursFromMeridiem ? boSvc.OperatingHoursFromMeridiem : "" );
                                txtHoursMinutesTo.Text = ( null != boSvc.OperatingHoursToTime ? boSvc.OperatingHoursToTime : "" );
                                listAmPmTo.SelectedValue = ( null != boSvc.OperatingHoursToMeridiem ? boSvc.OperatingHoursToMeridiem : "" );
                                break;
                            // *RESPITE CARE - IN HOME
                            case "8":
                                chkRESPITE_IN_HOME.Checked = true;
                                hidRESPITE_IN_HOMEGroupState.Value = "";
                                rdpFNR_RESPITE_IN_HOME_DT.SelectedDate = boSvc.FnrApprovalDate;
                                break;
                            // SUBSTITUTE FAMILY CARE
                            case "9":
                                chkSUBSTITUTE_FAMILY_CARE.Checked = true;
                                break;
                            // SUPPORTED EMPLOYMENT
                            case "10":
                                chkSUPPORTED_EMPLOYMENT.Checked = true;
                                break;
                            case "11":
                                chkMONITORED_INHOME_CAREGIVING.Checked = true;
                                rdpMIC_NEEDREVIEW_DT.SelectedDate = boSvc.FnrApprovalDate;
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }

        private void EnableDisableALL_HCBS( bool inReadOnly )
        {
            //rdpPCA_FNR_APRVL_DT.Enabled = !inReadOnly;
            //rdpPCA_FNR_APRVL_DT.CssClass = !inReadOnly ? "" : "readOnly";
            //rdpSIL_FNR_APRVL_DT.Enabled = !inReadOnly;
            //rdpSIL_FNR_APRVL_DT.CssClass = !inReadOnly ? "" : "readOnly";
            //rdpSIL_SLC_FNR_APRVL_DT.Enabled = !inReadOnly;
            //rdpSIL_SLC_FNR_APRVL_DT.CssClass = !inReadOnly ? "" : "readOnly";
            //rdpOCDD_APRVL_DT.Enabled = !inReadOnly;
            //rdpOCDD_APRVL_DT.CssClass = !inReadOnly ? "" : "readOnly";
            //txtSIL_SLC_CAPACITY.Enabled = !inReadOnly;
            //txtSIL_SLC_CAPACITY.CssClass = !inReadOnly ? "" : "readOnly";
            //txtSUR_ICFDD_LIC_NUM.Enabled = !inReadOnly;
            //txtSUR_ICFDD_LIC_NUM.CssClass = !inReadOnly ? "" : "readOnly";
            //rdpSUR_ICFDD_LIC_EXP_DT.Enabled = !inReadOnly;
            //rdpSUR_ICFDD_LIC_EXP_DT.CssClass = !inReadOnly ? "" : "readOnly";
            //rdpFNR_RESPITE_IN_HOME_DT.Enabled = !inReadOnly;
            //rdpFNR_RESPITE_IN_HOME_DT.CssClass = !inReadOnly ? "" : "readOnly";
            //rdpFNR_RESPITE_CENTER_BASED.Enabled = !inReadOnly;
            //rdpFNR_RESPITE_CENTER_BASED.CssClass = !inReadOnly ? "" : "readOnly";
            //txtRESPITE_CENTER_BASED_CAPACITY.Enabled = !inReadOnly;
            //txtRESPITE_CENTER_BASED_CAPACITY.CssClass = !inReadOnly ? "" : "readOnly";
            //CheckBoxDayOfOperationMon.Enabled = !inReadOnly;
            //CheckBoxDayOfOperationTue.Enabled = !inReadOnly;
            //CheckBoxDayOfOperationWed.Enabled = !inReadOnly;
            //CheckBoxDayOfOperationThu.Enabled = !inReadOnly;
            //CheckBoxDayOfOperationFri.Enabled = !inReadOnly;
            //CheckBoxDayOfOperationSat.Enabled = !inReadOnly;
            //CheckBoxDayOfOperationSun.Enabled = !inReadOnly;
            //txtHoursMinutesFrom.Enabled = !inReadOnly;
            //txtHoursMinutesFrom.CssClass = !inReadOnly ? "" : "readOnly";
            //txtHoursMinutesTo.Enabled = !inReadOnly;
            //txtHoursMinutesTo.CssClass = !inReadOnly ? "" : "readOnly";
            //listAmPmFrom.Enabled = !inReadOnly;
            //listAmPmFrom.CssClass = !inReadOnly ? "" : "readOnly";
            //listAmPmTo.Enabled = !inReadOnly;
            //listAmPmTo.CssClass = !inReadOnly ? "" : "readOnly";
            //txtADC_CAPACITY.Enabled = !inReadOnly;
            //txtADC_CAPACITY.CssClass = !inReadOnly ? "" : "readOnly";

            //Service section grouping tables
            //tblRESPITE_IN_HOME.Disabled = inReadOnly;
            //tblRESPITE_CENTER_BASED.Disabled = inReadOnly;
            //tblSIL.Disabled = inReadOnly;
            //tblSIL_SLC.Disabled = inReadOnly;
            //tblPCA.Disabled = inReadOnly;
            //tblADC.Disabled = inReadOnly;
        }

        /// <summary>
        /// Handle the load of Special case: Substance Abuse
        /// </summary>
        private void _LoadFacSubTypeForSA()
        {
            /*
             * 1. Treatment Type
             */
            BO_LookupValues lkups = BO_LookupValue.SelectByField(BO_LookupValueFields.LookupKey, "TYPE_TREATMENT");
            optTreatmentType.Items.Clear();

            foreach (BO_LookupValue lkupval in lkups)
            {
                if ( lkupval.Allowedtypes.Contains( CurrentProvider.ProgramID ) )
                {
                    if ( IsOffSite )
                    {
                        if ( CurrentAppProvider.TypeTreatment.Contains( lkupval.LookupVal ) )
                        {
                                ListItem tmpItm = new ListItem();
                                optTreatmentType.Items.Add( tmpItm );
                                optTreatmentType.Style.Add( HtmlTextWriterStyle.MarginLeft, "10px" );
                                tmpItm.Text = lkupval.Valdesc;
                                tmpItm.Value = lkupval.LookupVal;
                        }
                    }
                    else
                    {
                        ListItem tmpItm = new ListItem();
                        optTreatmentType.Items.Add( tmpItm );
                        optTreatmentType.Style.Add( HtmlTextWriterStyle.MarginLeft, "10px" );
                        tmpItm.Text = lkupval.Valdesc;
                        tmpItm.Value = lkupval.LookupVal;
                    }
                }
            }
            if ( IsOffSite )
            {
                if ( !string.IsNullOrEmpty( CurrentAffiliation.TypeTreatment ) )
                {
                    foreach ( ListItem tmpLI in optTreatmentType.Items )
                    {
                        if ( CurrentAffiliation.TypeTreatment.Contains( tmpLI.Value ) )
                            tmpLI.Selected = true;
                    }
                }
            }
            else
            {
                if ( !string.IsNullOrEmpty( CurrentAppProvider.TypeTreatment ) )
                {
                    foreach ( ListItem tmpLI in optTreatmentType.Items )
                    {
                        if ( CurrentAppProvider.TypeTreatment.Contains( tmpLI.Value ) )
                            tmpLI.Selected = true;
                    }
                }
            }

            /*
             * 2. Client Type
             */
            lkups = BO_LookupValue.SelectByField(BO_LookupValueFields.LookupKey, "TYPE_CLIENT");
            optClientType.Items.Clear();

            foreach (BO_LookupValue lkupval in lkups)
            {
                if ( lkupval.Allowedtypes.Contains( CurrentAppProvider.ProgramID ) )
                {
                    if ( IsOffSite )
                    {
                        if ( CurrentAppProvider.TypeOfClients.Equals( "3" ) )
                        {
                            ListItem tmpItm = new ListItem();
                            optClientType.Items.Add( tmpItm );
                            optClientType.Style.Add( HtmlTextWriterStyle.MarginLeft, "10px" );
                            tmpItm.Text = lkupval.Valdesc;
                            tmpItm.Value = lkupval.LookupVal;
                        }
                        else if ( CurrentAppProvider.TypeOfClients.Equals( lkupval.LookupVal ) )
                        {
                            ListItem tmpItm = new ListItem();
                            optClientType.Items.Add( tmpItm );
                            optClientType.Style.Add( HtmlTextWriterStyle.MarginLeft, "10px" );
                            tmpItm.Text = lkupval.Valdesc;
                            tmpItm.Value = lkupval.LookupVal;
                        }
                    }
                    else
                    {
                        ListItem tmpItm = new ListItem();
                        optClientType.Items.Add( tmpItm );
                        optClientType.Style.Add( HtmlTextWriterStyle.MarginLeft, "10px" );
                        tmpItm.Text = lkupval.Valdesc;
                        tmpItm.Value = lkupval.LookupVal;
                    }
                }
            }

            if ( IsOffSite )
            {
                if ( !string.IsNullOrEmpty( CurrentAffiliation.TypeOfClients ) )
                {
                    optClientType.SelectedValue = CurrentAffiliation.TypeOfClients;
                }
            }
            else
            {
                if ( CurrentAppProvider.TypeOfClients != null && !CurrentAppProvider.TypeOfClients.Equals( "" ) )
                {
                    optClientType.SelectedValue = CurrentAppProvider.TypeOfClients;
                }
            }

            /*
             * 3. Operation Type
             */
            lkups = BO_LookupValue.SelectByField(BO_LookupValueFields.LookupKey, "TYPE_OPERATION");
            optOperationType.Items.Clear();

            foreach (BO_LookupValue lkupval in lkups)
            {
                if ( lkupval.Allowedtypes.Contains( CurrentProvider.ProgramID ) )
                {
                    if ( IsOffSite )
                    {
                        if ( CurrentAppProvider.FacilityTypeCode.Equals( "3" ) )
                        {
                            ListItem tmpItm = new ListItem();
                            optOperationType.Items.Add( tmpItm );
                            optOperationType.Style.Add( HtmlTextWriterStyle.MarginLeft, "10px" );
                            tmpItm.Text = lkupval.Valdesc;
                            tmpItm.Value = lkupval.LookupVal;
                        }
                        else if ( CurrentAppProvider.FacilityTypeCode.Equals( lkupval.LookupVal ) )
                        {
                            ListItem tmpItm = new ListItem();
                            optOperationType.Items.Add( tmpItm );
                            optOperationType.Style.Add( HtmlTextWriterStyle.MarginLeft, "10px" );
                            tmpItm.Text = lkupval.Valdesc;
                            tmpItm.Value = lkupval.LookupVal;
                        }
                    }
                    else
                    {
                        ListItem tmpItm = new ListItem();
                        optOperationType.Items.Add( tmpItm );
                        optOperationType.Style.Add( HtmlTextWriterStyle.MarginLeft, "10px" );
                        tmpItm.Text = lkupval.Valdesc;
                        tmpItm.Value = lkupval.LookupVal;
                    }
                }
            }

            if ( IsOffSite )
            {
                if ( !string.IsNullOrEmpty( CurrentAffiliation.TypeOfClients ) )
                {
                    optOperationType.SelectedValue = CurrentAffiliation.FacilityTypeCode;
                }
            }
            else
            {
                if ( CurrentAppProvider.TypeOfClients != null && !CurrentAppProvider.TypeOfClients.Equals( "" ) )
                {
                    optOperationType.SelectedValue = CurrentAppProvider.FacilityTypeCode;
                }
            }

            //if (CurrentAppProvider.FacilityTypeCode != null && !CurrentAppProvider.FacilityTypeCode.Equals(""))
            //{
            //    try
            //    {
            //        optOperationType.SelectedValue = CurrentAppProvider.FacilityTypeCode;
            //    }
            //    catch (Exception ex)
            //    {
            //        // TODO: Fix the Lookup values so that they don't have "0" prefix!!!
            //        optOperationType.SelectedValue = "1";
            //    }
            //}

        }

        /// <summary>
        /// This is called from two different methods:
        ///  - ServicesRepeater_ItemDataBound
        ///  - SaveData
        ///  
        ///  This method sets the attributes of the checkbox and textbox controls
        ///  in the Repeater
        /// </summary>
        /// <param name="servicesRepeaterItem"></param>
        private void BindServicesRepeater(RepeaterItem servicesRepeaterItem)
        {
            if (servicesRepeaterItem.ItemType == ListItemType.Item
                || servicesRepeaterItem.ItemType == ListItemType.AlternatingItem)
            {
                CheckBox tmpCheckBoxServiceType = (CheckBox)servicesRepeaterItem.FindControl("chkServiceType");
                HiddenField tmpHiddenFieldServiceType = (HiddenField)servicesRepeaterItem.FindControl("HiddenFieldServiceType");
                HiddenField tmpHiddenFieldExtra = (HiddenField)servicesRepeaterItem.FindControl("HiddenFieldExtra");
                TextBox tmpTextBoxServiceLicNumber = (TextBox)servicesRepeaterItem.FindControl("txtServiceLicNumber");
                RadNumericTextBox tmpRNTextBoxServiceCapacity = (RadNumericTextBox)servicesRepeaterItem.FindControl("txtServiceCapacity");
                RadNumericTextBox tmpRNTextBoxServiceCensus = (RadNumericTextBox) servicesRepeaterItem.FindControl( "txtServiceCensus" );
                TextBox tmpTextBoxTypeServiceOther = (TextBox)servicesRepeaterItem.FindControl("txtTypeServiceOther");
                Label tmpServiceTypeDesc = (Label) servicesRepeaterItem.FindControl("lblServiceTypeDesc");

                // make the OTHER textbox visible, if applicable
                if ( tmpServiceTypeDesc != null && tmpServiceTypeDesc.Text.Trim().ToUpper().Equals( "OTHER" ) )
                {
                    tmpTextBoxTypeServiceOther.Visible = true;
                    SvcsHasOtherCateg = true;
                }
                else
                {
                    tmpTextBoxTypeServiceOther.Visible = false;
                    SvcsHasOtherCateg = false;
                }

                bool serviceFound = false;
                foreach (BO_Service boService in CurrentServicesList)
                {
                    if (boService.ServiceType.Equals(tmpHiddenFieldServiceType.Value)
                        && boService.Removed == false)
                    {
                        // Service found:  set the value of the unbound controls in the Repeater
                        tmpCheckBoxServiceType.Checked = true;
                        tmpTextBoxServiceLicNumber.Text = (boService.TypeServiceLicNum != null ? boService.TypeServiceLicNum : "");
                        tmpTextBoxServiceLicNumber.Enabled = true;
                        tmpTextBoxTypeServiceOther.Text = (boService.TypeServiceOther != null ? boService.TypeServiceOther : "");
                        // Enable the OTHER textbox if it is visible
                        if (tmpTextBoxTypeServiceOther.Visible == true)
                            tmpTextBoxTypeServiceOther.Enabled = true;

                        if ( CurrentAppProvider != null && CurrentProvider.ProgramID.Equals( "SA" ) )
                        {
                            // In the case of Substance Abuse providers, 
                            // If Operation type is Inpatient OR both In&Out-patient, 
                            // then display the Capacity textbox
                            if ( optOperationType.SelectedIndex != -1
                                && ( optOperationType.SelectedIndex == 0 || optOperationType.SelectedIndex == 2 )
                                && tmpHiddenFieldExtra.Value.Equals( "CAP" ) )
                            {
                                tmpRNTextBoxServiceCapacity.Visible = true;
                                //tmpRNTextBoxServiceCapacity.Enabled = true;
                                tmpRNTextBoxServiceCensus.Visible = true;
                                //tmpRNTextBoxServiceCensus.Enabled = true;
                                // set the value of the Capacity textbox
                                tmpRNTextBoxServiceCapacity.Text = "";
                                tmpRNTextBoxServiceCensus.Text = "";
                                foreach ( BO_Capacity boCapacity in CurrentCapacitiesList )
                                {
                                    // For SA check if CapacityType = '3'
                                    if ( boCapacity.CapacityType.Equals( "3" )
                                        && boCapacity.SubstanceAbuseType.Equals( tmpHiddenFieldServiceType.Value ) )
                                    {
                                        if ( boCapacity.CapacityCount != null && boCapacity.CapacityCount.HasValue )
                                            tmpRNTextBoxServiceCapacity.Text = boCapacity.CapacityCount.ToString();

                                        if ( boCapacity.Census != null && boCapacity.Census.HasValue )
                                            tmpRNTextBoxServiceCensus.Text = boCapacity.Census.ToString();
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                tmpRNTextBoxServiceCapacity.Visible = false;
                                tmpRNTextBoxServiceCensus.Visible = false;
                            }


                            tmpTextBoxServiceLicNumber.Visible = false;
                        }
                        else if ( CurrentAppProvider != null && CurrentProvider.ProgramID.Equals( "CM" ) )
                        {
                            tmpRNTextBoxServiceCapacity.Visible = false;
                            tmpRNTextBoxServiceCensus.Visible = false;
                            tmpTextBoxServiceLicNumber.Visible = false;
                        }
                        else
                        {
                            tmpRNTextBoxServiceCapacity.Visible = false;
                            tmpRNTextBoxServiceCensus.Visible = false;
                            tmpTextBoxServiceLicNumber.Visible = true;
                        }

                        serviceFound = true;
                        break;
                    }
                }
                // disable the ServiceLicNumber & TypeServiceOther textboxes if the service is not found
                if (!serviceFound)
                {
                    tmpCheckBoxServiceType.Checked = false;
                    tmpTextBoxServiceLicNumber.Text = string.Empty;
                    //tmpTextBoxServiceLicNumber.Enabled = false;
                    //tmpTextBoxTypeServiceOther.Enabled = false;

                    if ( CurrentAppProvider != null && CurrentProvider.ProgramID.Equals( "SA" ) )
                    {
                        // In the case of Substance Abuse providers, 
                        // If Operation type is Inpatient OR both In&Out-patient, 
                        // then display the Capacity textbox
                        if ( optOperationType.SelectedIndex != -1
                            && ( optOperationType.SelectedIndex == 0 || optOperationType.SelectedIndex == 2 )
                            && tmpHiddenFieldExtra.Value.Equals( "CAP" ) )
                        {
                            tmpRNTextBoxServiceCapacity.Visible = true;
                            tmpRNTextBoxServiceCensus.Visible = true;
                            //tmpRNTextBoxServiceCapacity.Enabled = false;
                            //tmpRNTextBoxServiceCensus.Enabled = false;
                        }
                        else
                        {
                            tmpRNTextBoxServiceCapacity.Visible = false;
                            tmpRNTextBoxServiceCensus.Visible = false;
                        }

                        tmpTextBoxServiceLicNumber.Visible = false;
                    }
                    else if ( CurrentAppProvider != null && CurrentProvider.ProgramID.Equals( "CM" ) )
                    {
                        tmpRNTextBoxServiceCapacity.Visible = false;
                        tmpRNTextBoxServiceCensus.Visible = false;
                        tmpTextBoxServiceLicNumber.Visible = false;
                    }
                    else
                    {
                        tmpRNTextBoxServiceCapacity.Visible = false;
                        tmpRNTextBoxServiceCensus.Visible = false;
                        tmpTextBoxServiceLicNumber.Visible = true;
                    }
                }

                // add a JavaScript call to the OnClick event of the Checkbox
                // to enable/diable the ServiceLicNumber textbox at Runtime
                if ( CurrentAppProvider != null && CurrentProvider.ProgramID.Equals( "SA" ) )
                {
                    // pass the clientId of tmpRNTextBoxServiceCapacity
                    tmpCheckBoxServiceType.Attributes.Add("OnClick", "EnableDisableRadNumericTextBoxInRepeater('" + tmpCheckBoxServiceType.ClientID + "','" + tmpRNTextBoxServiceCapacity.ClientID + "','" + tmpTextBoxTypeServiceOther.ClientID + "');");

                    // pass the clientId of tmpRNTextBoxServiceCensus
                    tmpCheckBoxServiceType.Attributes.Add( "OnClick", "EnableDisableRadNumericTextBoxInRepeater('" + tmpCheckBoxServiceType.ClientID + "','" + tmpRNTextBoxServiceCensus.ClientID + "','" + tmpTextBoxTypeServiceOther.ClientID + "');" );
                }
                else
                {
                    // pass the clientId of tmpTextBoxServiceLicNumber
                    tmpCheckBoxServiceType.Attributes.Add("OnClick", "EnableDisableTextBoxInRepeater('" + tmpCheckBoxServiceType.ClientID + "','" + tmpTextBoxServiceLicNumber.ClientID + "','" + tmpTextBoxTypeServiceOther.ClientID + "');");
                }
            }
        }

        protected void AttachAction_Click( object sender, EventArgs e )
        {
            string tmpAddQueryString = "";
            string tmpAttachParentType = "APPLICATION";
            LinkButton tmpUpldBtn = (LinkButton) sender;

            string[] commandArgsSent = tmpUpldBtn.CommandArgument.ToString().Split( new char[] { ',' } );

            //This is the add condition
            if ( tmpUpldBtn.CommandName == "Upload" && tmpUpldBtn.Text.Equals( "Attach" ) )
            {
                tmpAddQueryString += "Desc=OCDD approved ICF/DD conversion request&";
                tmpAddQueryString += "AttID=" + commandArgsSent[0].ToString() + "&";
                tmpAddQueryString += "Type=" + tmpAttachParentType;


                ServiceAttachRadWin.NavigateUrl = "~/Common/FileUpload.aspx?" + tmpAddQueryString;
                ServiceAttachRadWin.Height = Unit.Pixel( 125 );
                ServiceAttachRadWin.Width = Unit.Pixel( 545 );
                ServiceAttachRadWin.Title = "Attach File";
                ServiceAttachRadWin.Visible = true;
                ServiceAttachRadWin.Modal = true;

            }
            else //Remove condition
            {
                decimal tmpFileAttachID = Convert.ToDecimal( commandArgsSent[1] );

                foreach ( BO_ApplicationItem boAI in CurrentAppProvider.BO_ApplicationItemsApplicationID )
                {
                    if ( boAI.FileAttachID.Equals( tmpFileAttachID ) )
                    {
                        boAI.FileAttachID = null;
                        foreach ( BO_FileAttach boFA in CurrentAppProvider.Attachments )
                        {
                            if ( boFA.FileAttachID.Equals( tmpFileAttachID ) )
                            {
                                boFA.Removed = true;
                                break;
                            }
                        }
                        break;
                    }
                }
            }

        }

        /// <summary>
        /// Populate the DataTable that will be the Repeater's datasource
        /// </summary>
        private DataTable ServicesDataSource
        {
            get
            {
                DataTable retTable = null;

                retTable = GetServicesDataTable();

                if (null != CurrentAppProvider)
                {
                    BO_LookupValues tmpServiceLookups;
                    if ( CurrentProvider.ProgramID != null && CurrentProvider.ProgramID.Equals( "SA" ) )
                        tmpServiceLookups = SAServiceLookups;
                    else if ( CurrentProvider.ProgramID != null && CurrentProvider.ProgramID.Equals( "FF" ) )
                        tmpServiceLookups = FFServiceLookups;
                    else
                        tmpServiceLookups = ServiceLookups;

                    foreach (BO_LookupValue lkupval in tmpServiceLookups)
                    {
                        DataRow tmpDR = retTable.NewRow();

                        tmpDR["ServiceType"] = lkupval.LookupVal;
                        tmpDR["ServiceTypeDesc"] = lkupval.Valdesc;
                        tmpDR["Extra"] = lkupval.Extra;

                        retTable.Rows.Add(tmpDR);
                    }
                }
                return retTable;
            }
        }

        /// <summary>
        /// Populate the DataTable that will be the Repeater's datasource
        /// </summary>
        private DataTable HP_CoreServicesDataSource
        {
            get
            {
                DataTable retTable = null;

                retTable = GetServicesDataTable();

                if ( null != CurrentAppProvider )
                {
                    foreach ( BO_LookupValue lkupval in HPCoreServiceLookups )
                    {
                        DataRow tmpDR = retTable.NewRow();

                        tmpDR["ServiceType"] = lkupval.LookupVal;
                        tmpDR["ServiceTypeDesc"] = lkupval.Valdesc;
                        tmpDR["Extra"] = lkupval.Extra;

                        retTable.Rows.Add( tmpDR );
                    }
                }
                return retTable;
            }
        }

        /// <summary>
        /// Populate the DataTable that will be the Repeater's datasource
        /// </summary>
        private DataTable HP_OtherServicesDataSource
        {
            get
            {
                DataTable retTable = null;

                retTable = GetServicesDataTable();

                if ( null != CurrentAppProvider )
                {
                    foreach ( BO_LookupValue lkupval in HPOtherServiceLookups )
                    {
                        DataRow tmpDR = retTable.NewRow();

                        tmpDR["ServiceType"] = lkupval.LookupVal;
                        tmpDR["ServiceTypeDesc"] = lkupval.Valdesc;
                        tmpDR["Extra"] = lkupval.Extra;

                        retTable.Rows.Add( tmpDR );
                    }
                }
                return retTable;
            }
        }
        
        /// <summary>
        /// Create a DataTable that can be used for populating the Repeater
        /// </summary>
        /// <returns></returns>
        private DataTable GetServicesDataTable()
        {
            DataTable tmpDTbl = new DataTable();
            DataColumn tmpDCol = null;

            tmpDCol = new DataColumn("ServiceType");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("ServiceTypeDesc");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("Extra");
            tmpDTbl.Columns.Add(tmpDCol);

            return tmpDTbl;
        }

        /// <summary>
        /// Add/Update appropriate Service Object
        /// </summary>
        /// <param name="tmpCheckBoxServiceType"></param>
        /// <param name="tmpHiddenFieldServiceType"></param>
        /// <param name="tmpTextBoxServiceLicNumber"></param>
        private void AddUpdateServiceService(CheckBox tmpCheckBoxServiceType,
            HiddenField tmpHiddenFieldServiceType,
            HiddenField tmpHiddenFieldExtra,
            TextBox tmpTextBoxServiceLicNumber,
            RadNumericTextBox tmpRNTextBoxServiceCapacity,
            TextBox tmpTextBoxTypeServiceOther,
            RadNumericTextBox tmpRNTextBoxServiceCensus)
        {
            BO_Services tmpServiceList = null;

            if (tmpCheckBoxServiceType.Checked)
            {
                bool serviceFound = false;

                //Check for the existing record as the user may have unchecked the box then rechecked it
                foreach ( BO_Service boService in CurrentServicesList )
                {
                    if (boService.ServiceType.Equals(tmpHiddenFieldServiceType.Value))
                    {
                        boService.Removed = false;
                        boService.TypeServiceLicNum = tmpTextBoxServiceLicNumber.Text;
                        boService.TypeServiceOther = tmpTextBoxTypeServiceOther.Text;

                        if ( CurrentAppProvider != null && CurrentAppProvider.ProgramID.Equals( "SA" ) )
                        {
                            // In the case of Substance Abuse providers, 
                            // If Operation type is Inpatient OR both In&Out-patient, 
                            // then SAVE the Capacity information
                            if (optOperationType.SelectedIndex != -1
                                && (optOperationType.SelectedIndex == 0 || optOperationType.SelectedIndex == 2)
                                && tmpHiddenFieldExtra.Value.Equals("CAP"))
                            {
                                bool capacityFound = false;

                                foreach ( BO_Capacity boCapacity in CurrentCapacitiesList )
                                {
                                    // For SA check if CapacityType = '3'
                                    if ( boCapacity.CapacityType.Equals( "3" )
                                        && boCapacity.SubstanceAbuseType.Equals( tmpHiddenFieldServiceType.Value ) )
                                    {
                                        capacityFound = true;
                                        try
                                        {
                                            boCapacity.CapacityCount = int.Parse( tmpRNTextBoxServiceCapacity.Text );
                                            boCapacity.Census = int.Parse( tmpRNTextBoxServiceCensus.Text );
                                        }
                                        catch ( Exception ex )
                                        {
                                            boCapacity.CapacityCount = null;
                                        }
                                        break;
                                    }
                                }
                                if (!capacityFound)
                                {
                                    // Add a new CAPACITY row
                                    AddSACapacity( tmpHiddenFieldServiceType, tmpRNTextBoxServiceCapacity, tmpRNTextBoxServiceCensus );
                                }
                            }
                        }

                        serviceFound = true;
                        break;
                    }
                }
                if (!serviceFound)
                {
                    BO_Service tmpService = new BO_Service();
                    tmpService.IsNewRec = true;
                    tmpService.PopsIntID = CurrentAppProvider.PopsIntID;
                    tmpService.ApplicationID = CurrentAppProvider.ApplicationID;
                    tmpService.ServiceType = tmpHiddenFieldServiceType.Value;
                    tmpService.TypeServiceLicNum = tmpTextBoxServiceLicNumber.Text;
                    tmpService.TypeServiceOther = tmpTextBoxTypeServiceOther.Text;

                    // add the new Service to the collection
                    CurrentServicesList.Add(tmpService);

                    // Add a new CAPACITY row
                    AddSACapacity( tmpHiddenFieldServiceType, tmpRNTextBoxServiceCapacity, tmpRNTextBoxServiceCensus );
                }
            }
            else
            {
                // flag this service & associated Capacity (if any) for removal
                foreach (BO_Service boService in CurrentServicesList)
                {
                    if (boService.ServiceType.Equals(tmpHiddenFieldServiceType.Value))
                    {
                        // flag this service for removal
                        boService.Removed = true;

                        if ( CurrentAppProvider != null && CurrentProvider.ProgramID.Equals( "SA" ) )
                        {
                            // In the case of Substance Abuse providers, 
                            foreach (BO_Capacity boCapacity in CurrentCapacitiesList)
                            {
                                // For SA check if CapacityType = '3'
                                if (boCapacity.CapacityType.Equals("3")
                                    && boCapacity.SubstanceAbuseType.Equals(tmpHiddenFieldServiceType.Value))
                                {
                                    // flag this Capacity for removal
                                    boCapacity.Removed = true;
                                    break;
                                }
                            }
                        }
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Add new Capacity object
        /// </summary>
        /// <param name="tmpHiddenFieldExtra"></param>
        /// <param name="tmpRNTextBoxServiceCapacity"></param>
        private void AddSACapacity(HiddenField tmpHiddenFieldServiceType,
            RadNumericTextBox tmpRNTextBoxServiceCapacity,
            RadNumericTextBox tmpRNTextBoxServiceCensus )
        {
            BO_Capacity tmpCapacity = new BO_Capacity();
            tmpCapacity.PopsIntID = CurrentAppProvider.PopsIntID;
            tmpCapacity.ApplicationID = CurrentAppProvider.ApplicationID;
            tmpCapacity.CapacityType = "3"; // SA
            tmpCapacity.SubstanceAbuseType = tmpHiddenFieldServiceType.Value;
            try
            {
                tmpCapacity.CapacityCount = int.Parse( tmpRNTextBoxServiceCapacity.Text );
                tmpCapacity.Census = int.Parse( tmpRNTextBoxServiceCensus.Text );
            }
            catch (Exception ex)
            {
                tmpCapacity.CapacityCount = null;
            }
            tmpCapacity.IsNewRec = true;
            // add the new Capacity to the collection
            CurrentCapacitiesList.Add(tmpCapacity);
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

        private bool SvcsHasOtherCateg
        {
            get
            {
                return ( ViewState["SvcsHasOtherCateg"] != null ? (bool) ViewState["SvcsHasOtherCateg"] : false );
            }
            set
            {
                ViewState["SvcsHasOtherCateg"] = value;
            }
        }


        /// <summary>
        /// Get Collection of Services for the Current application
        /// </summary>
        private BO_Services CurrentServicesList
        {
            get
            {
                BO_Services tmpServices;

                if ( IsOffSite )
                {
                    if ( CurrentAffiliation != null && CurrentAffiliation.BO_ServicesAffiliationID != null )
                        tmpServices = CurrentAffiliation.BO_ServicesAffiliationID;
                    else
                        tmpServices = new BO_Services();
                }
                else
                {
                    if ( CurrentAppProvider != null && CurrentAppProvider.BO_ServicesApplicationID != null )
                        tmpServices = CurrentAppProvider.BO_ServicesApplicationID;
                    else
                        tmpServices = new BO_Services();
                }

                return tmpServices;
            }
            set
            {
                CurrentAppProvider.BO_ServicesApplicationID = value;
            }
        }

        /// <summary>
        /// Get Collection of Capacities for the Current application
        /// </summary>
        private BO_Capacities CurrentCapacitiesList
        {
            get
            {
                BO_Capacities tmpCapacities = null;

                if ( IsOffSite )
                {
                    if ( CurrentAffiliation != null && CurrentAffiliation.BO_ServicesAffiliationID != null )
                        tmpCapacities = CurrentAffiliation.BO_CapacitiesAffiliationID;
                    else
                        tmpCapacities = new BO_Capacities();
                }
                else
                {
                    if ( CurrentAppProvider != null && CurrentAppProvider.BO_ServicesApplicationID != null )
                        tmpCapacities = CurrentAppProvider.BO_CapacitiesApplicationID;
                    else
                        tmpCapacities = new BO_Capacities();
                }

                return tmpCapacities;
            }
            set
            {
                CurrentAppProvider.BO_CapacitiesApplicationID = value;
            }
        }

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
        
        /// <summary>
        /// Get the Current Application object from the Session
        /// </summary>
        private BO_Application CurrentAppProvider
        {
            get
            {
                return Session["CurrentAppProvider"] == null ? null : (BO_Application)Session["CurrentAppProvider"];
            }
        }

        private BO_Affiliation CurrentAffiliation
        {
            get
            {
                if ( null != CurrentAppProvider.BO_AffiliationsApplicationID )
                {
                    foreach ( BO_Affiliation boAffil in CurrentAppProvider.BO_AffiliationsApplicationID )
                    {
                        if ( boAffil.UI_TrackID.Equals( CurrentAffiliationID ) )
                            return boAffil;
                    }
                }

                return null;
            }
        }

        private string CurrentAffiliationID
        {
            get
            {
                return (ViewState["CurrentAffiliationID"] != null ? (string)ViewState["CurrentAffiliationID"] : null);
            }
            set
            {
                ViewState["CurrentAffiliationID"] = value;
            }
        }
        
        /// <summary>
        /// Get the Lookup Values for TYPE_SERVICE
        /// </summary>
        private BO_LookupValues ServiceLookups
        {
            get
            {
                BO_LookupValues retLkups = new BO_LookupValues();
                //if (Session["ServiceLookups"] == null)
                //{
                    string currentProgramID = CurrentProvider.ProgramID;

                    BO_LookupValues tmpLkups = BO_LookupValue.SelectByField(BO_LookupValueFields.LookupKey, "TYPE_SERVICE");
                    tmpLkups.Sort( "Valdesc" );

                    BO_LookupValue tmpLkupOther = null;
                    foreach (BO_LookupValue tmpLV in tmpLkups)
                    {
                        if ( tmpLV.Allowedtypes.Equals( currentProgramID ) )
                        {
                            if ( tmpLV.Valdesc.ToUpper().Contains( "OTHER" ) )
                                tmpLkupOther = tmpLV;
                            else
                                retLkups.Add( tmpLV );
                        }
                    }

                    if ( null != tmpLkupOther )
                        retLkups.Add( tmpLkupOther );
                //}
                //else
                //    retLkups = (BO_LookupValues)Session["ServiceLookups"];

                //ServiceLookups = retLkups;

                return retLkups;
            }
            set
            {
                Session["ServiceLookups"] = value;
            }
        }

        /// <summary>
        /// Get the Lookup Values for SERVICES - special case for Substance Abuse providers
        /// NOTE: The lookups are NOT stored in session since the list changes
        /// based on the Type of Operation selected: in-patient/out-patient/bothtypes
        /// </summary>
        private BO_LookupValues SAServiceLookups
        {
            get
            {
                BO_LookupValues retLkups = new BO_LookupValues();
                string currentProgramID = CurrentProvider.ProgramID;

                BO_LookupValues tmpLkups = BO_LookupValue.SelectByField(BO_LookupValueFields.LookupKey, "SERVICES");
                foreach (BO_LookupValue tmpLV in tmpLkups)
                {
                    if (tmpLV.Allowedtypes.Equals(currentProgramID))
                    {
                        bool AllowOffsiteService = false;

                        //Check for service at parent level first if these are for an offsite
                        foreach ( BO_Service boSvc in CurrentAppProvider.BO_ServicesApplicationID )
                        {
                            if ( boSvc.ServiceType.Equals( tmpLV.LookupVal ) && !boSvc.Removed )
                            {
                                AllowOffsiteService = true;
                                break;
                            }
                        }

                        // check for capacity
                        if (optOperationType.SelectedIndex != -1 && optOperationType.SelectedIndex == 0)
                        {
                            if ( IsOffSite )
                            {
                                // in-patient : only add rows that have capacity
                                if ( tmpLV.Extra != null && tmpLV.Extra.Contains( "CAP" ) && AllowOffsiteService )
                                    retLkups.Add( tmpLV );
                            }
                            else
                            {
                                // in-patient : only add rows that have capacity
                                if ( tmpLV.Extra != null && tmpLV.Extra.Contains( "CAP" ) )
                                    retLkups.Add( tmpLV );
                            }
                        }
                        else if (optOperationType.SelectedIndex != -1 && optOperationType.SelectedIndex == 1)
                        {
                            if ( IsOffSite )
                            {
                                // out-patient : only add rows that do NOT have capacity
                                if ( tmpLV.Extra == null && AllowOffsiteService )
                                    retLkups.Add( tmpLV );
                            }
                            else
                            {
                                // out-patient : only add rows that do NOT have capacity
                                if ( tmpLV.Extra == null )
                                    retLkups.Add( tmpLV );
                            }
                        }
                        else if (optOperationType.SelectedIndex != -1 && optOperationType.SelectedIndex == 2)
                        {
                            if ( IsOffSite )
                            {
                                if ( AllowOffsiteService )
                                    retLkups.Add( tmpLV );
                            }
                            else
                            {
                                retLkups.Add( tmpLV );
                            }
                        }
                        else
                        {
                            if ( !IsOffSite )
                            {
                                // default: Add all the services
                                retLkups.Add( tmpLV );
                            }
                        }
                    }
                }

                return retLkups;
            }
        }

        private BO_LookupValues FFServiceLookups
        {
            get
            {
                BO_LookupValues retLkups = new BO_LookupValues();
                string currentProgramID = CurrentProvider.ProgramID;

                BO_LookupValues tmpLkups = BO_LookupValue.SelectByField( BO_LookupValueFields.LookupKey, "TYPE_SERVICE" );
                foreach ( BO_LookupValue tmpLV in tmpLkups )
                {
                    if ( tmpLV.Allowedtypes.Contains( currentProgramID ) )
                    {
                        retLkups.Add( tmpLV );
                    }
                }

                return retLkups;
            }
        }

        private BO_LookupValues HPCoreServiceLookups
        {
            get
            {
                BO_LookupValues retLkups = new BO_LookupValues();
                string currentProgramID = CurrentProvider.ProgramID;

                BO_LookupValues tmpLkups = BO_LookupValue.SelectByField( BO_LookupValueFields.LookupKey, "TYPE_MODULE" );
                foreach ( BO_LookupValue tmpLV in tmpLkups )
                {
                    if ( tmpLV.Allowedtypes.Equals( currentProgramID ) && ( "1,2,3,4" ).Contains( tmpLV.LookupVal ) )
                    {
                        retLkups.Add( tmpLV );
                    }
                }

                return retLkups;
            }
        }

        private BO_LookupValues HPOtherServiceLookups
        {
            get
            {
                BO_LookupValues retLkups = new BO_LookupValues();
                string currentProgramID = CurrentProvider.ProgramID;

                BO_LookupValues tmpLkups = BO_LookupValue.SelectByField( BO_LookupValueFields.LookupKey, "TYPE_MODULE" );
                foreach ( BO_LookupValue tmpLV in tmpLkups )
                {
                    if ( tmpLV.Allowedtypes.Equals( currentProgramID ) && !("1,2,3,4").Contains( tmpLV.LookupVal ) )
                    {
                        retLkups.Add( tmpLV );
                    }
                }

                return retLkups;
            }
        }

        private BO_LookupValues ServiceSubtypes
        {
            get
            {
                BO_LookupValues retLkups = new BO_LookupValues();
                string currentProgramID = CurrentProvider.ProgramID;

                BO_LookupValues tmpLkups = BO_LookupValue.SelectByField( BO_LookupValueFields.LookupKey, "TYPE_SERVICE_SUBTYPE" );
                foreach ( BO_LookupValue tmpLV in tmpLkups )
                {
                    if ( tmpLV.Allowedtypes.Contains( currentProgramID ) )
                    {
                        retLkups.Add( tmpLV );
                    }
                }

                return retLkups;
            }
        }

        /// <summary>
        /// Reload the list of Services based on the Option selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void optOperationType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ServicesRepeater.DataSource = ServicesDataSource;
            ServicesRepeater.DataBind();
        }

        protected void BHTreatmentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            BHServicesChanged.Value = "true";
        }

        protected void BHClientType_SelectedIndexChanged(object sender, EventArgs e)
        {
            BHServicesChanged.Value = "true";
        }

        protected void BHOperationType_SelectedIndexChanged(object sender, EventArgs e)
        {
            BHServicesChanged.Value = "true";

            chkBHFacilityDescription.Items.Clear();
            lblFacilityDescription.Visible = true;
            chkBHFacilityDescription.Visible = true;

            switch (((RadioButtonList)sender).SelectedValue)
            {
                case "1":
                    BO_LookupValues OperationSubTypeIN = BO_LookupValue.SelectByField(BO_LookupValueFields.LookupKey, "BH_SERVICES_OPERATION_SUBTYPE_INPATIENT");
                    chkBHFacilityDescription.DataSource = OperationSubTypeIN;
                    chkBHFacilityDescription.DataTextField = "Valdesc";
                    chkBHFacilityDescription.DataValueField = "LookupVal";
                    chkBHFacilityDescription.DataBind();
                    lblLicensedUnits.Visible = true;
                    lblLicensedBeds.Visible = true;
                    txtNumberLicensedUnits.Visible = true;
                    txtNumberLicensedBeds.Visible = true;
                    break;
                case "2":
                    BO_LookupValues OperationSubTypeOUT = BO_LookupValue.SelectByField(BO_LookupValueFields.LookupKey, "BH_SERVICES_OPERATION_SUBTYPE_OUTPATIENT");
                    chkBHFacilityDescription.DataSource = OperationSubTypeOUT;
                    chkBHFacilityDescription.DataTextField = "Valdesc";
                    chkBHFacilityDescription.DataValueField = "LookupVal";
                    chkBHFacilityDescription.DataBind();
                    lblLicensedUnits.Visible = false;
                    lblLicensedBeds.Visible = false;
                    txtNumberLicensedUnits.Visible = false;
                    txtNumberLicensedBeds.Visible = false;
                    break;
                case "3":
                    BO_LookupValues OperationSubTypeINOUT = BO_LookupValue.SelectByField(BO_LookupValueFields.LookupKey, "BH_SERVICES_OPERATION_SUBTYPE_IN_OUTPATIENT");
                    chkBHFacilityDescription.DataSource = OperationSubTypeINOUT;
                    chkBHFacilityDescription.DataTextField = "Valdesc";
                    chkBHFacilityDescription.DataValueField = "LookupVal";
                    chkBHFacilityDescription.DataBind();
                    lblLicensedUnits.Visible = true;
                    lblLicensedBeds.Visible = true;
                    txtNumberLicensedUnits.Visible = true;
                    txtNumberLicensedBeds.Visible = true;
                    break;
            }
        }

        protected void BHFacilityDescription_SelectedIndexChanged(object sender, EventArgs e)
        {
            //set hidden field to determine if service selections have changed for update purposes
            BHServicesChanged.Value = "true";
        }

        public string HCBS_DIV_ClientID()
        {
            return DivHCBS_Svcs.ClientID;
        }

        public string GroupStateIDs()
        {
            string retVal = "";

            retVal = hidPCAGroupState.ClientID + "," + hidSILGroupState.ClientID + "," + hidSIL_SLCGroupState.ClientID + "," + hidRESPITE_IN_HOMEGroupState.ClientID + "," + hidRESPITE_CENTER_BASEDGroupState.ClientID + "," + hidADCGroupState.ClientID;

            return retVal;
        }

    }
}