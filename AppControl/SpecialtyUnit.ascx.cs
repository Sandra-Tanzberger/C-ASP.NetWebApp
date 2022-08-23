using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using ATG;
using ATG.BusinessObject;
using Telerik.Web.UI;

namespace AppControl
{
    public partial class SpecialtyUnit : System.Web.UI.UserControl
    {
        private Hashtable _m_Ctrls = null;

        protected override void OnInit( EventArgs e )
        {
            base.OnInit( e );
        }

        protected void Page_Load( object sender, EventArgs e )
        {
        }

        //public void LoadApplication( string inAppID )
        public void LoadApplication( string inKeyID, bool inAllowEdit, bool inIsOffsiteAffil )
        {
            IsOffSite = inIsOffsiteAffil;
            AllowEdit = inAllowEdit;

            if ( CurrentAppProvider != null && CurrentAppProvider.ApplicationID != null )
            {
                if ( IsOffSite )
                {
                    CurrentAffiliationID = inKeyID;
                }
                
                _InitSpecUnits();
            }

            _ShowHideFields();
        
        }

        public bool SaveData()
        {
            bool noSaveError = true;
            string validationErrors = "";

            ErrorText.Visible = false;
            ErrorText.InnerHtml = "";

            //ESRD values are dependant on Transplant values so we process the row for this after 
            //the repeater has been processed
            bool bTransplantSelected = false;
            bool bESRDSelected = false;
            string tmpESRD_SU_ID = "";
            string tmpESRD_CCN = "";
            
            foreach ( RepeaterItem tmpRI in SpecialtyUnitRepeater.Items )
            {
                CheckBox tmpChk = (CheckBox) tmpRI.FindControl( "chkSU" );
                HiddenField tmpSU_ID = (HiddenField) tmpRI.FindControl( "hidSU_ID" );
                HiddenField tmpSU_TypeID = (HiddenField) tmpRI.FindControl( "hidSU_TypeID" );
                RadComboBox tmpCboLevel = (RadComboBox) tmpRI.FindControl( "lstSU_Level" );
                ListBox tmpSU_SubTypeList = (ListBox) tmpRI.FindControl( "lstSU_SubType" );
                TextBox tmpSU_txtCCN = (TextBox)tmpRI.FindControl("txtSU_CCN");
                
                bool suFound = false;

                if ( tmpChk.Checked )
                {
                    //bool suFound = false;

                    if ( tmpSU_TypeID.Value.Equals( "5" ) ) //Transplant
                    {
                        bTransplantSelected = true;
                    }
                    if ( tmpSU_TypeID.Value.Equals( "20" ) ) //Transplant
                    {
                        bESRDSelected = true;
                        tmpESRD_SU_ID = tmpSU_ID.Value;
                        tmpESRD_CCN = tmpSU_txtCCN.Text;
                    }

                    if ( null != CurrentAppSpecUnitList )
                    {
                        //Check for the existing record as the user may have unchecked the box then rechecked it
                        foreach ( BO_SpecialtyUnit boSU in CurrentAppSpecUnitList )
                        {
                            if ( boSU.TypeSpecialtyUnit.Equals( tmpSU_TypeID.Value ) )
                            {
                                boSU.Removed = false;
                                if ( tmpSU_TypeID.Value.Equals( "5" ) ) //Transplant
                                {
                                    string tmpSubTypeLst = "";

                                    foreach ( ListItem tmpLI in tmpSU_SubTypeList.Items )
                                    {
                                        if ( tmpLI.Selected )
                                        {
                                            tmpSubTypeLst += tmpLI.Value + ",";
                                        }
                                    }

                                    if ( tmpSubTypeLst.Length < 1 )
                                        boSU.SubtypeSpecialtyUnit = "";
                                    else
                                        boSU.SubtypeSpecialtyUnit = tmpSubTypeLst.Substring( 0, tmpSubTypeLst.Length - 1 );

                                }
                                else
                                {
                                    boSU.Level = tmpCboLevel.SelectedValue;
                                }
                                boSU.Ccn = tmpSU_txtCCN.Text;
                                //boSU.Update();

                                suFound = true;
                                break;
                            }
                        }
                    }

                    //ESRD units are outside of repeater
                    if ( !suFound && !tmpSU_TypeID.Equals("20") )
                    {
                        BO_SpecialtyUnit tmpSU = new BO_SpecialtyUnit();
                        tmpSU.IsNewRec = true;
                        tmpSU.PopsIntID = CurrentAppProvider.PopsIntID;
                        tmpSU.ApplicationID = CurrentAppProvider.ApplicationID;
                        tmpSU.TypeSpecialtyUnit = tmpSU_TypeID.Value;
                        tmpSU.StateID = CurrentAppProvider.StateID;
                        
                        if (null != CurrentAffiliationID && !CurrentAffiliationID.Substring(0,1).Equals("N") )
                            tmpSU.AffiliationID = Convert.ToDecimal(CurrentAffiliationID);

                        if ( tmpSU_TypeID.Value.Equals( "5" ) ) //Transplant
                        {
                            string tmpSubTypeLst = "";

                            foreach ( ListItem tmpLI in tmpSU_SubTypeList.Items )
                            {
                                if ( tmpLI.Selected )
                                {
                                    tmpSubTypeLst += tmpLI.Value + ",";
                                }
                            }

                            if ( tmpSubTypeLst.Length < 1 )
                                tmpSU.SubtypeSpecialtyUnit = "";
                            else
                                tmpSU.SubtypeSpecialtyUnit = tmpSubTypeLst.Substring( 0, tmpSubTypeLst.Length - 1 );

                        }
                        else
                        {
                            tmpSU.Level = tmpCboLevel.SelectedValue;
                        }
                        tmpSU.Ccn = tmpSU_txtCCN.Text;

                        if ( null == CurrentAppSpecUnitList )
                        {
                            BO_SpecialtyUnits tmpUnits = new BO_SpecialtyUnits();
                            tmpUnits.Add( tmpSU );

                            CurrentAppSpecUnitList = tmpUnits;
                        }
                        else
                        {
                            CurrentAppSpecUnitList.Add( tmpSU );
                        }
                    }
                }
                else
                {
                    if ( null != CurrentAppSpecUnitList )
                    {
                        foreach ( BO_SpecialtyUnit boSU in CurrentAppSpecUnitList )
                        {
                            bool CapacityFound = false;
                            bool OffsiteSpecialtyUnitFound = false;

                            //Check to see if specialty unit exists
                            if ( boSU.TypeSpecialtyUnit.Equals( tmpSU_TypeID.Value ) )
                            {
                                CapacityFound = _CapacityExists( tmpSU_TypeID.Value );
                                OffsiteSpecialtyUnitFound = _OffisteHasSpecialtyUnit( tmpSU_TypeID.Value );

                                //Check for existing capacity records for the Specialty Unit to be removed and
                                //if found message user.
                                if ( !CapacityFound && !OffsiteSpecialtyUnitFound )
                                {
                                    boSU.Removed = true;
                                }
                                else
                                {
                                    noSaveError = false;
                                    string tmpSpecUnitName = "";

                                    foreach ( BO_LookupValue boLU in SpecUnitLookups )
                                    {
                                        if ( boLU.LookupVal.Equals( tmpSU_TypeID.Value ) )
                                            tmpSpecUnitName = boLU.Valdesc;
                                    }

                                    if ( CapacityFound )
                                        validationErrors += "Specialty Unit " + tmpSpecUnitName + " cannot be deleted. Capacity records exist at this location.<br/>";

                                    if ( OffsiteSpecialtyUnitFound )
                                        validationErrors += "Specialty Unit " + tmpSpecUnitName + " is assigned to one or more offsite locations and cannot be deleted.<br/>";
                                }
                            }
                        }
                    }
                }
            }

            bool ESRDFound = false;

            if ( null != CurrentAppSpecUnitList )
            {
                foreach ( BO_SpecialtyUnit tmpSU in CurrentAppSpecUnitList )
                {
                    if ( tmpSU.TypeSpecialtyUnit.Equals( "20" ) )
                    {
                        ESRDFound = true;
                        if ( bTransplantSelected )
                        {
                            tmpSU.Ccn = tmpESRD_CCN;
                        }
                        else
                        {
                            tmpSU.Removed = true;
                        }
                        break;
                    }
                }
            }

            if ( !ESRDFound && bTransplantSelected && bESRDSelected )
            {
                BO_SpecialtyUnit tmpSU = new BO_SpecialtyUnit();
                tmpSU.IsNewRec = true;
                tmpSU.PopsIntID = CurrentAppProvider.PopsIntID;
                tmpSU.ApplicationID = CurrentAppProvider.ApplicationID;
                tmpSU.TypeSpecialtyUnit = "20";
                tmpSU.StateID = CurrentAppProvider.StateID;

                if ( null != CurrentAffiliationID && !CurrentAffiliationID.Substring(0,1).Equals("N") )
                    tmpSU.AffiliationID = Convert.ToDecimal( CurrentAffiliationID );

                tmpSU.Ccn = tmpESRD_CCN;

                if ( null == CurrentAppSpecUnitList )
                {
                    BO_SpecialtyUnits tmpUnits = new BO_SpecialtyUnits();
                    tmpUnits.Add( tmpSU );

                    CurrentAppSpecUnitList = tmpUnits;
                }
                else
                {
                    CurrentAppSpecUnitList.Add( tmpSU );
                }

            }

            if ( !noSaveError )
            {
                ErrorText.Visible = true;
                ErrorText.InnerHtml += validationErrors;
            }

            _InitSpecUnits();

            return noSaveError;
        }

        private bool _OffisteHasSpecialtyUnit( string inTypeSpecialtyUnit )
        {
            bool retVal = false;

            if ( null != CurrentAppProvider.BO_AffiliationsApplicationID )
            {
                foreach ( BO_Affiliation tmpAffil in CurrentAppProvider.BO_AffiliationsApplicationID )
                {
                    if ( null != tmpAffil.BO_SpecialtyUnitsAffiliationID )
                    {
                        foreach ( BO_SpecialtyUnit tmpSU in tmpAffil.BO_SpecialtyUnitsAffiliationID )
                        {
                            if ( tmpSU.TypeSpecialtyUnit.Equals( inTypeSpecialtyUnit ) && !tmpSU.Removed )
                            {
                                retVal = true;
                                break;
                            }
                        }
                    }

                    if ( retVal )
                        break;
                }
            }

            return retVal;
        }

        private bool _CapacityExists( string inTypeSpecialtyUnit )
        {
            bool retVal = false;

            if ( null != CurrentLocCapList )
            {
                foreach ( BO_Capacity boCap in CurrentLocCapList )
                {
                    //Capacity table holds multiple types of provider capacities information
                    //We only need bed capacity records here. CapacityType = 1
                    if ( boCap.CapacityType.Equals( "1" ) ) 
                    {
                        string tmpAllowedTypes = "";

                        switch ( inTypeSpecialtyUnit  )
                        {
                            case "1":
                                if ( boCap.BedsType.Equals("17") )
                                    retVal = true;
                                break;
                            case "2":
                                if ( boCap.BedsType.Equals( "7" ) )
                                    retVal = true;
                                break;
                            case "3":
                                if ( boCap.BedsType.Equals( "3" ) )
                                    retVal = true;
                                break;
                            case "4":
                                if ( boCap.BedsType.Equals( "12" ) )
                                    retVal = true;
                                break;
                            case "5":
                                if ( boCap.BedsType.Equals( "13" ) )
                                    retVal = true;
                                break;
                            case "6":
                                if ( boCap.BedsType.Equals( "26" ) )
                                    retVal = true;
                                break;
                            case "7":
                                if ( boCap.BedsType.Equals( "5" ) )
                                    retVal = true;
                                break;
                            case "8":
                                if ( boCap.BedsType.Equals( "8" ) )
                                    retVal = true;
                                break;
                            case "9":
                                if ( boCap.BedsType.Equals( "11" ) )
                                    retVal = true;
                                break;
                            case "10":
                                if ( boCap.BedsType.Equals( "25" ) )
                                    retVal = true;
                                break;
                            case "12":
                                if ( boCap.BedsType.Equals( "23" ) || boCap.BedsType.Equals( "12" ) )
                                    retVal = true;
                                tmpAllowedTypes = "23,12";
                                break;
                            case "14":
                                if ( boCap.BedsType.Equals( "18" ) )
                                    retVal = true;
                                break;
                            case "15":
                                if ( boCap.BedsType.Equals( "33" ) )
                                    retVal = true;
                                break;
                            case "17":
                                if ( boCap.BedsType.Equals( "6" ) )
                                    retVal = true;
                                break;
                            case "18":
                                if ( boCap.BedsType.Equals( "9" ) )
                                    retVal = true;
                                break;
                            case "19":
                                if ( boCap.BedsType.Equals( "31" ) )
                                    retVal = true;
                                break;
                            default:
                                break;
                        }                        
                    }
                    //Capacities found no need to keep looking
                    if ( retVal )
                        break;
                }
            }

            return retVal;
        } 

        // Fires for each row in the reapeater based on the master speciatly unit list
        // and sets the corresponding values if selected for the current location
        protected void SpecialtyUnitRepeater_ItemDataBound( object sender, RepeaterItemEventArgs e )
        {
            if ( e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem )
            {
                HtmlTable tmpTbl = (HtmlTable) e.Item.FindControl( "tblChildFields" );
                CheckBox tmpChk = (CheckBox) e.Item.FindControl( "chkSU" );
                HiddenField tmpSU_ID = (HiddenField) e.Item.FindControl( "hidSU_ID" );
                HiddenField tmpSU_TypeID = (HiddenField) e.Item.FindControl( "hidSU_TypeID" );
                RadComboBox tmpCboLevel = (RadComboBox) e.Item.FindControl( "lstSU_Level" );
                ListBox tmpSU_SubTypeList = (ListBox) e.Item.FindControl( "lstSU_SubType" );
                TextBox tmpSU_txtCCN = (TextBox)e.Item.FindControl("txtSU_CCN");

                if ( null != CurrentAppSpecUnitList )
                {
                    // match them up and set values
                    foreach ( BO_SpecialtyUnit boSU in CurrentAppSpecUnitList )
                    {

                        // Match the row to the saved specialty unit type
                        if ( boSU.TypeSpecialtyUnit.Equals( tmpSU_TypeID.Value ) && !boSU.Removed )
                        {
                            // check the box
                            tmpChk.Checked = true;
                            // Not shown on all speciatly units, but always set
                            tmpSU_txtCCN.Text = boSU.Ccn;
                            // Unique ID for this specialty unit record
                            tmpSU_ID.Value = boSU.SpecialtyUnitID.ToString();

                            // If the type is not transplant then set the level
                            // and if it is trasplant then set all of the subtypes
                            // selected
                            if ( !boSU.TypeSpecialtyUnit.Equals( "5" ) )
                            {
                                if ( boSU.Level != null )
                                    tmpCboLevel.SelectedValue = boSU.Level;

                            }
                            else
                            {
                                if ( null != boSU.SubtypeSpecialtyUnit )
                                {
                                    string[] tmpVals = boSU.SubtypeSpecialtyUnit.Split( ',' );
                                    foreach ( string tmpStr in tmpVals )
                                    {
                                        foreach ( ListItem tmpLI in tmpSU_SubTypeList.Items )
                                        {
                                            if ( tmpLI.Value.Equals( tmpStr ) )
                                            {
                                                tmpLI.Selected = true;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                if ( !AllowEdit )
                {
                    tmpChk.Enabled = false;
                    tmpCboLevel.Enabled = false;
                    tmpSU_SubTypeList.Enabled = false;
                    foreach ( ListItem tmpLI in tmpSU_SubTypeList.Items )
                    {
                        if ( tmpLI.Selected )
                            tmpLI.Attributes.CssStyle.Add( "Background", "#E2E2E2" );
                    }
                    tmpSU_txtCCN.Enabled = false;
                }

            }
        }

        protected void SpecialtyUnitRepeater_PreRender( object sender, EventArgs e )
        {
            string tmpESRDChkBoxClientID = "";
            string tmpESRDTxtCCNClientID = "";
            bool transplantSelected = false;
            bool esrdFound = false;

            if ( AllowEdit )
            {
                foreach ( RepeaterItem tmpRI in SpecialtyUnitRepeater.Items )
                {
                    HtmlTable tmpTbl = (HtmlTable) tmpRI.FindControl( "tblChildFields" );
                    CheckBox tmpOuterChk = (CheckBox) tmpRI.FindControl( "chkSU" );
                    HiddenField tmpSU_ID = (HiddenField) tmpRI.FindControl( "hidSU_ID" );
                    HiddenField tmpOuterSU_TypeID = (HiddenField) tmpRI.FindControl( "hidSU_TypeID" );
                    RadComboBox tmpCboLevel = (RadComboBox) tmpRI.FindControl( "lstSU_Level" );
                    ListBox tmpSU_SubTypeList = (ListBox) tmpRI.FindControl( "lstSU_SubType" );
                    TextBox tmpSU_txtCCN = (TextBox) tmpRI.FindControl( "txtSU_CCN" );

                    tmpOuterChk.Attributes.Add( "onclick", "ToggleRO_SU_ChildCtrls( '" + tmpOuterChk.ClientID + "', '" + tmpTbl.ClientID + "', '" + tmpCboLevel.ClientID + "','N')" );

                    ScriptManager.RegisterExpandoAttribute( this, tmpOuterChk.ClientID, "SU_TypeID", tmpOuterSU_TypeID.Value, false );
                    tmpOuterChk.Attributes.Add( "SU_TypeID", tmpOuterSU_TypeID.Value );

                    //Place holder for addtion of custom attributes in pre render
                    ChkBoxCtrls.Add( tmpOuterChk.ClientID, new Hashtable() );

                    // Locate ESRD controls and get thier client ids for assignment as dependant of transplant
                    if ( tmpOuterSU_TypeID.Value.Equals( "20" ) ) //ESRD
                    {
                        tmpESRDChkBoxClientID = tmpOuterChk.ClientID;
                        tmpESRDTxtCCNClientID = tmpSU_txtCCN.ClientID;
                        esrdFound = true;
                    }

                    Random tmpRnd = new Random();
                    string tmpStr = tmpRnd.Next(1,100).ToString();

                    // If this is the row for Transplant then call the toggle function to handle the ESRD controls
                    if ( tmpOuterSU_TypeID.Value.Equals( "5" ) ) //Transplant
                    {
                        ScriptManager.RegisterStartupScript( this, this.Page.GetType(), tmpOuterSU_TypeID.Value + tmpStr, "ToggleRO_SU_ChildCtrls( '" + tmpOuterChk.ClientID + "', '" + tmpTbl.ClientID + "', '" + tmpCboLevel.ClientID + "','N');", true );
                    }

                    tmpOuterChk.Enabled = true;

                    if ( tmpOuterChk.Checked )
                    {
                        if ( tmpOuterSU_TypeID.Value.Equals( "5" ) ) //Transplant
                        {
                            transplantSelected = true;
                        }

                        tmpCboLevel.Enabled = true;
                        tmpSU_SubTypeList.Enabled = true;
                        tmpSU_txtCCN.Enabled = true;
                    }
                    else
                    {
                        tmpCboLevel.Enabled = false;
                        tmpSU_SubTypeList.Enabled = true;
                        tmpSU_txtCCN.Enabled = false;
                    }

                }

                if ( esrdFound )
                {
                    //got the client ids of the esrd group so find transplant and set up values to be registered
                    foreach ( RepeaterItem tmpRI in SpecialtyUnitRepeater.Items )
                    {
                        CheckBox tmpInnerChk = (CheckBox) tmpRI.FindControl( "chkSU" );
                        HiddenField tmpInnerSU_TypeID = (HiddenField) tmpRI.FindControl( "hidSU_TypeID" );

                        if ( tmpInnerSU_TypeID.Value.Equals( "5" ) ) //Transplant
                        {
                            Hashtable tmpHTable = (Hashtable) ChkBoxCtrls[tmpInnerChk.ClientID];
                            tmpHTable.Add( "dependants", tmpESRDChkBoxClientID + "," + tmpESRDTxtCCNClientID );
                            ChkBoxCtrls[tmpInnerChk.ClientID] = tmpHTable;
                        }

                        if ( tmpInnerSU_TypeID.Value.Equals( "20" ) )
                        {
                            if ( !transplantSelected )
                                tmpInnerChk.Enabled = false;
                        }
                    }
                }
                RegisterAttributes();
            }

        }

        protected void RegisterAttributes()
        {
            foreach ( string tmpKey in ChkBoxCtrls.Keys )
            {
                foreach ( RepeaterItem tmpRI in SpecialtyUnitRepeater.Items )
                {
                    CheckBox tmpChk = (CheckBox) tmpRI.FindControl( "chkSU" );
                    Hashtable tmpHT = (Hashtable) ChkBoxCtrls[tmpKey];

                    if ( null != tmpChk && tmpChk.ClientID.Equals( tmpKey ) )
                    {
                        foreach ( DictionaryEntry entry in tmpHT )
                        {
                            Page.ClientScript.RegisterExpandoAttribute( tmpKey, (string) entry.Key, (string) entry.Value, false );
                            tmpChk.Attributes.Add( (string) entry.Key, (string) entry.Value );
                        }
                    }
                }
            }
        }

        // Master list of level options for specialty units requiring them
        protected DataTable getLevelOpts()
        {
            DataTable tmpDT = new DataTable();
            DataRow tmpRow;

            tmpDT.Columns.Add( "LOOKUP_VAL" );
            tmpDT.Columns.Add( "VALDESC" );

            tmpRow = tmpDT.NewRow();
            tmpRow["LOOKUP_VAL"] = "";
            tmpRow["VALDESC"] = "";
            tmpDT.Rows.Add( tmpRow );

            foreach ( BO_LookupValue boLV in UnitLevelLookups )
            {
                tmpRow = tmpDT.NewRow();
                tmpRow["LOOKUP_VAL"] = boLV.LookupVal;
                tmpRow["VALDESC"] = boLV.Valdesc;
                tmpDT.Rows.Add( tmpRow );
            }

            return tmpDT;
        }

        // Master list of subtypes for transplant specialty units
        protected DataTable getSubTypeOpts()
        {
            DataTable tmpDT = new DataTable();
            DataRow tmpRow;

            tmpDT.Columns.Add( "LOOKUP_VAL" );
            tmpDT.Columns.Add( "VALDESC" );

            foreach ( BO_LookupValue boLV in TransplantLookups )
            {
                tmpRow = tmpDT.NewRow();
                tmpRow["LOOKUP_VAL"] = boLV.LookupVal;
                tmpRow["VALDESC"] = boLV.Valdesc;
                tmpDT.Rows.Add( tmpRow );
            }

            return tmpDT;
        }

        // Initial the list of specialty units to be used for either the provider or the affilition/offsite
        // Selected values are set in the item data bound event for the repeater
        private void _InitSpecUnits()
        {
            if ( IsOffSite )
            {
                if ( null != CurrentAffiliationSUDataSource && CurrentAffiliationSUDataSource.Rows.Count > 0 )
                {
                    SpecialtyUnitRepeater.DataSource = CurrentAffiliationSUDataSource;
                    SpecialtyUnitRepeater.DataBind();
                }
                else
                {
                    ErrorText.InnerText = "No Specialty Units found. These must be designated on the application for the main campus before they will be shown here.";
                    ErrorText.Visible = true;
                }
            }
            else
            {
                SpecialtyUnitRepeater.DataSource = CurrentSpecialtyUnitsDataSource;
                SpecialtyUnitRepeater.DataBind();
            }
        }

        private void _ShowHideFields()
        {
            if (Session["userType"].ToString() == "Public")
            {
                if (CurrentAppProvider.BusinessProcessID == "4" || CurrentAppProvider.BusinessProcessID == "5" || CurrentAppProvider.BusinessProcessID == "6" || CurrentAppProvider.BusinessProcessID == "7" || CurrentAppProvider.BusinessProcessID == "9" || CurrentAppProvider.BusinessProcessID == "10" || CurrentAppProvider.ApplicationStatus.Equals("4") || !AllowEdit)
                {
                    DisableSpecialityUnits();
                }
                else if (CurrentAppProvider.BusinessProcessID == "8") //OFF-SITE ADDITIONS
                {
                    if (!IsOffSite)
                    {
                        DisableSpecialityUnits();
                    }
                }                        
            }
        }

        // Returns a datatable used for displying the specialty units in the repeater control
        private DataTable _getSpecUnitsDataTable()
        {
            DataTable tmpDTbl = new DataTable();
            DataColumn tmpDCol = null;

            tmpDCol = new DataColumn( "TypeSpecialtyUnit" );
            tmpDTbl.Columns.Add( tmpDCol );
            tmpDCol = new DataColumn( "SpecialtyUnitID" );
            tmpDTbl.Columns.Add( tmpDCol );
            tmpDCol = new DataColumn( "Description" );
            tmpDTbl.Columns.Add( tmpDCol );
            tmpDCol = new DataColumn( "ShowSubType" );
            tmpDTbl.Columns.Add( tmpDCol );
            tmpDCol = new DataColumn( "ShowLevel" );
            tmpDTbl.Columns.Add( tmpDCol );
            tmpDCol = new DataColumn("ShowCCN");
            tmpDTbl.Columns.Add(tmpDCol);

            return tmpDTbl;
        }

        /// <summary>
        /// This is called from State POPS for read-only display of Speciality Units
        /// </summary>
        public void DisableSpecialityUnits()
        {
            foreach (RepeaterItem tmpRI in SpecialtyUnitRepeater.Items)
            {
                CheckBox tmpChk = (CheckBox)tmpRI.FindControl("chkSU");
                RadComboBox tmpCboLevel = (RadComboBox)tmpRI.FindControl("lstSU_Level");
                ListBox tmpSU_SubTypeList = (ListBox)tmpRI.FindControl("lstSU_SubType");
                TextBox tmpSU_txtCCN = (TextBox)tmpRI.FindControl("txtSU_CCN");

                // disable the controls
                tmpChk.Enabled = false;
                tmpCboLevel.Enabled = false;
                tmpSU_SubTypeList.Enabled = false;
                tmpSU_txtCCN.Enabled = false;
            }
        }

        /// <summary>
        /// This is called from State POPS for clearing previous values
        /// </summary>
        public void ClearSpecialityUnits()
        {
            foreach (RepeaterItem tmpRI in SpecialtyUnitRepeater.Items)
            {
                CheckBox tmpChk = (CheckBox)tmpRI.FindControl("chkSU");
                RadComboBox tmpCboLevel = (RadComboBox)tmpRI.FindControl("lstSU_Level");
                ListBox tmpSU_SubTypeList = (ListBox)tmpRI.FindControl("lstSU_SubType");
                TextBox tmpSU_txtCCN = (TextBox)tmpRI.FindControl("txtSU_CCN");

                // clear selections
                tmpChk.Checked = false;
                tmpCboLevel.SelectedIndex = -1;
                tmpSU_SubTypeList.SelectedIndex = -1;
                tmpSU_txtCCN.Text = "";

                // disable the controls
                tmpChk.Enabled = false;
                tmpCboLevel.Enabled = false;
                tmpSU_SubTypeList.Enabled = false;
                tmpSU_txtCCN.Enabled = false;
            }
        }

        #region Members Variables

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

        private BO_Affiliation CurrentAffiliation
        {
            get
            {
                BO_Affiliation tmpAffiliation = null;

                foreach ( BO_Affiliation tmpBA in CurrentAppProvider.BO_AffiliationsApplicationID )
                {
                    if ( tmpBA.UI_TrackID.Equals( CurrentAffiliationID ) )
                    {
                        tmpAffiliation = tmpBA;
                        break;
                    }
                }

                return tmpAffiliation;
            }
            set
            {
                BO_Affiliation tmpAffiliation = null;

                foreach ( BO_Affiliation tmpBA in CurrentAppProvider.BO_AffiliationsApplicationID )
                {
                    if ( tmpBA.UI_TrackID.Equals( CurrentAffiliationID ) )
                    {
                        tmpAffiliation = tmpBA;
                        break;
                    }
                }

                if ( null != tmpAffiliation )
                {
                    tmpAffiliation = value;
                }
            }
        }

        private BO_LookupValues SpecUnitLookups
        {
            get
            {
                BO_LookupValues retLkups = new BO_LookupValues();
                if ( Session["SpecUnitLookups"] == null )
                {
                    BO_LookupValues tmpLkups = BO_LookupValue.SelectByField( BO_LookupValueFields.LookupKey, "SPECIALTY_UNIT" );
                    tmpLkups.Sort("Sortbyvalue");
                    foreach ( BO_LookupValue tmpLV in tmpLkups )
                    {
                        if ( tmpLV.Allowedtypes.Equals( CurrentAppProvider.ProgramID ) )
                            retLkups.Add( tmpLV );
                    }
                }
                else
                    retLkups = (BO_LookupValues) Session["SpecUnitLookups"];

                SpecUnitLookups = retLkups;

                return retLkups;
            }
            set
            {
                Session["SpecUnitLookups"] = value;
            }
        }

        private BO_LookupValues UnitLevelLookups
        {
            get
            {
                BO_LookupValues retLkups = new BO_LookupValues();
                if ( Session["UnitLevelLookups"] == null )
                {
                    BO_LookupValues tmpLkups = BO_LookupValue.SelectByField( BO_LookupValueFields.LookupKey, "LEVEL_OF_CARE" );
                    foreach ( BO_LookupValue tmpLV in tmpLkups )
                    {
                        if ( tmpLV.Allowedtypes.Equals( CurrentAppProvider.ProgramID ) )
                            retLkups.Add( tmpLV );
                    }
                }
                else
                    retLkups = (BO_LookupValues) Session["UnitLevelLookups"];

                UnitLevelLookups = retLkups;

                return retLkups;
            }
            set
            {
                Session["UnitLevelLookups"] = value;
            }
        }

        private BO_LookupValues TransplantLookups
        {
            get
            {
                BO_LookupValues retLkups = new BO_LookupValues();
                if ( Session["TransplantLookups"] == null )
                {
                    BO_LookupValues tmpLkups = BO_LookupValue.SelectByField( BO_LookupValueFields.LookupKey, "TRANSPLANT" );
                    foreach ( BO_LookupValue tmpLV in tmpLkups )
                    {
                        if ( tmpLV.Allowedtypes.Equals( CurrentAppProvider.ProgramID ) )
                            retLkups.Add( tmpLV );
                    }
                }
                else
                    retLkups = (BO_LookupValues) Session["TransplantLookups"];

                TransplantLookups = retLkups;

                return retLkups;
            }
            set
            {
                Session["TransplantLookups"] = value;
            }
        }

        private BO_Application CurrentAppProvider
        {
            get
            {
                return Session["CurrentAppProvider"] == null ? null : (BO_Application) Session["CurrentAppProvider"];
            }
        }

        private BO_Capacities CurrentLocCapList
        {
            get
            {
                BO_Capacities tmpLocCapList = new BO_Capacities();

                if ( !IsOffSite )
                {
                    if ( CurrentAppProvider != null && CurrentAppProvider.BO_CapacitiesApplicationID != null )
                    {
                        foreach ( BO_Capacity boCap in CurrentAppProvider.BO_CapacitiesApplicationID )
                        {
                            if ( null == boCap.AffiliationID && !boCap.Removed )
                                tmpLocCapList.Add( boCap );
                        }
                    }
                }
                else
                {
                    if ( null != CurrentAffiliation
                         && null != CurrentAffiliation.BO_CapacitiesAffiliationID )
                    {
                        foreach ( BO_Capacity boCap in CurrentAffiliation.BO_CapacitiesAffiliationID )
                        {
                            if ( !boCap.Removed )
                                tmpLocCapList.Add( boCap );
                        }
                    }
                }

                return tmpLocCapList;
            }
        }

        // List of Specialty unit business objects associated with this application
        // based on the location (Main vs Offsite) If none have been selected then return an empty collection.
        private BO_SpecialtyUnits CurrentAppSpecUnitList
        {
            get
            {
                if ( !IsOffSite )
                {
                    return ( null != CurrentAppProvider.BO_SpecialtyUnitsApplicationID ? CurrentAppProvider.BO_SpecialtyUnitsApplicationID : null );
                }
                else
                {
                    if ( null != CurrentAffiliation
                        && null != CurrentAffiliation.BO_SpecialtyUnitsAffiliationID
                        && CurrentAffiliation.BO_SpecialtyUnitsAffiliationID.Count > 0 )
                    {
                        return CurrentAffiliation.BO_SpecialtyUnitsAffiliationID;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            set
            {
                if ( !IsOffSite )
                {
                    CurrentAppProvider.BO_SpecialtyUnitsApplicationID = value;
                }
                else
                {
                    CurrentAffiliation.BO_SpecialtyUnitsAffiliationID = value;
                }
            }
        }

        // List of Specialty units at the provider level are not limited so this returns all of them
        private DataTable CurrentSpecialtyUnitsDataSource
        {
            get
            {
                DataTable retTable = null;

                retTable = _getSpecUnitsDataTable();

                if ( null != CurrentAppProvider )
                {
                    foreach ( BO_LookupValue lkupval in SpecUnitLookups )
                    {
                        DataRow tmpDR = retTable.NewRow();

                        tmpDR["TypeSpecialtyUnit"] = lkupval.LookupVal;
                        tmpDR["Description"] = lkupval.Valdesc;
                        tmpDR["ShowSubType"] = ( lkupval.LookupVal.Equals("5") ? "true" : "false" );
                        tmpDR["ShowLevel"] = ((null != lkupval.Extra && lkupval.Extra.Equals("Level")) ? "true" : "false");
                        tmpDR["ShowCCN"] = ((null != lkupval.Attributes1 && lkupval.Attributes1.Equals("CCN")) ? "true" : "false");
                        
                        retTable.Rows.Add( tmpDR );

                    }
                }

                return retTable;
            }
        }

        // List of Speciatly unit selections at the affiliation level are limited to those selected at the main provider level
        // This returns a list of specialty units available for selection for the affiliation
        private DataTable CurrentAffiliationSUDataSource
        {
            get
            {
                DataTable retTable = null;

                retTable = _getSpecUnitsDataTable();

                if ( null != CurrentAppProvider )
                {
                    foreach ( BO_LookupValue lkupval in SpecUnitLookups )
                    {
                        //foreach ( BO_SpecialtyUnit tmpBSU in CurrentAppSpecUnitList )
                        foreach ( BO_SpecialtyUnit tmpBSU in CurrentAppProvider.BO_SpecialtyUnitsApplicationID )
                        {
                            if ( tmpBSU.TypeSpecialtyUnit.Equals( lkupval.LookupVal ) && !tmpBSU.Removed && null == tmpBSU.AffiliationID )
                            {
                                DataRow tmpDR = retTable.NewRow();

                                tmpDR["TypeSpecialtyUnit"] = lkupval.LookupVal;
                                tmpDR["Description"] = lkupval.Valdesc;
                                tmpDR["ShowSubType"] = ( lkupval.LookupVal.Equals( "5" ) ? "true" : "false" );
                                tmpDR["ShowLevel"] = ( ( null != lkupval.Extra && lkupval.Extra.Equals( "Level" ) ) ? "true" : "false" );
                                tmpDR["ShowCCN"] = ((null != lkupval.Attributes1 && lkupval.Attributes1.Equals("CCN")) ? "true" : "false");

                                retTable.Rows.Add( tmpDR );
                            }
                        }
                    }
                }

                return retTable;
            }
        }

        private Hashtable ChkBoxCtrls
        {
            get 
            { 
                if ( null == _m_Ctrls )
                    _m_Ctrls = new Hashtable();

                return _m_Ctrls;
            }
            set 
            { 
                _m_Ctrls = value; 
            }
        }

        #endregion

    }
}