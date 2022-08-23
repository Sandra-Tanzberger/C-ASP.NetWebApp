using System;
using System.Data;
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
    public partial class HO_BedSummary : System.Web.UI.UserControl
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
        
        public void LoadBedSummary( string inKeyID, bool inAllowEdit, bool inIsOffsiteAffil )
        {
            AllowEdit = inAllowEdit;
            IsOffSite = inIsOffsiteAffil;

            if ( IsOffSite )
            {
                if ( AllowEdit )
                {
                    btnLBEditSelected.CommandName = "Edit";
                    litEditText.Text = "Edit Offsite Capacities";
                    imgEdit.Src = "../images/edit.gif";
                }
                else
                {
                    btnLBEditSelected.CommandName = "View";
                    litEditText.Text = "View Offsite Capacities";
                    imgEdit.Src = "../images/view.png";
                }
                CurrentAffiliationID = inKeyID;
            }
            else
            {
                if ( AllowEdit )
                {
                    btnLBEditSelected.CommandName = "Edit";
                    litEditText.Text = "Edit Main Campus Capacities";
                    imgEdit.Src = "../images/edit.gif";
                }
                else
                {
                    btnLBEditSelected.CommandName = "View";
                    litEditText.Text = "View Main Campus Capacities";
                    imgEdit.Src = "../images/view.png";
                }
            }

            _UpdateCapacitySummary();

        }

        protected void EditView_Click( object sender, EventArgs e )
        {
            string tmpAddQueryString = "";
            LinkButton tmpBtn = (LinkButton) sender;

            string[] commandArgsSent = tmpBtn.CommandArgument.ToString().Split( new char[] { ',' } );

            tmpAddQueryString += "TYPE=" + tmpBtn.CommandName + "&";
            tmpAddQueryString += "AFID=" + CurrentAffiliationID;

            BedSumRadWin.NavigateUrl = "~/Common/EditForm/CapacityForm.aspx?" + tmpAddQueryString;
            BedSumRadWin.Height = Unit.Pixel( 635 );
            BedSumRadWin.Width = Unit.Pixel( 730 );
            BedSumRadWin.Title = "Add/Edit Capacities";
            BedSumRadWin.KeepInScreenBounds = true;
            BedSumRadWin.Visible = true;
            BedSumRadWin.Modal = true;

        }

        private void _UpdateCapacitySummary()
        {
            CapSumRepeater.DataSource = CapacitySummaryDataSource;
            CapSumRepeater.DataBind();
        }

        private void _ShowHideFields()
        {
            if ( Session["userType"].ToString() == "Public" )
            {
                if ( ( CurrentAppProvider.BusinessProcessID == "4" || CurrentAppProvider.BusinessProcessID == "5" || CurrentAppProvider.BusinessProcessID == "6" || CurrentAppProvider.BusinessProcessID == "9" || CurrentAppProvider.BusinessProcessID == "10" ) || ( CurrentAppProvider.BusinessProcessID == "8" && !IsOffSite ) || CurrentAppProvider.ApplicationStatus.Equals( "4" ) || !AllowEdit )
                {
                    AllowEdit = false;
                }
                else
                    AllowEdit = true;

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
        
        private BO_Provider CurrentProvider
        {
            get
            {
                return (BO_Provider) Session["CurrentProvider"];
            }
        }
        
        private BO_Affiliation CurrentAffiliation
        {
            get
            {
                BO_Affiliation tmpAffiliation = null;

                if ( null != CurrentAppProvider && null != CurrentAppProvider.BO_AffiliationsApplicationID )
                {
                    foreach ( BO_Affiliation tmpBA in CurrentAppProvider.BO_AffiliationsApplicationID )
                    {
                        if ( tmpBA.UI_TrackID.Equals( CurrentAffiliationID ) )
                        {
                            tmpAffiliation = tmpBA;
                            break;
                        }
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

        private BO_LookupValues LicBedTypeLookups
        {
            get
            {
                BO_LookupValues retLkups = new BO_LookupValues();

                BO_LookupValues tmpLkups = BO_LookupValue.SelectByField( BO_LookupValueFields.LookupKey, "BED_TYPE" );
                foreach ( BO_LookupValue tmpLV in tmpLkups )
                {
                    if ( tmpLV.Allowedtypes.Contains( CurrentAppProvider.ProgramID ) && null != tmpLV.Extra && tmpLV.Extra.Equals( "LICENSED" ) )
                    {
                        //if ( null == tmpLV.Attributes1 )//If not present then Specialty Unit not required for bed type selection
                        //{
                            retLkups.Add( tmpLV );
                        //}
                        //else //Other wise check to see if the specialty unit is selected before adding to list
                        //{
                        //    if ( null != CurrentAppProvider.BO_SpecialtyUnitsApplicationID )
                        //    {
                        //        foreach ( BO_SpecialtyUnit boSU in CurrentAppProvider.BO_SpecialtyUnitsApplicationID )
                        //        {
                        //            if ( null != tmpLV.Attributes1 && boSU.TypeSpecialtyUnit.Equals( tmpLV.Attributes1 ) )
                        //                retLkups.Add( tmpLV );
                        //        }
                        //    }
                        //}
                    }
                }

                return retLkups;
            }
            set
            {
                Session["LicBedTypeLookups"] = value;
            }
        }

        private BO_LookupValues NonLicBedTypeLookups
        {
            get
            {
                BO_LookupValues retLkups = new BO_LookupValues();

                BO_LookupValues tmpLkups = BO_LookupValue.SelectByField( BO_LookupValueFields.LookupKey, "BED_TYPE" );
                foreach ( BO_LookupValue tmpLV in tmpLkups )
                {
                    if ( tmpLV.Allowedtypes.Contains( CurrentAppProvider.ProgramID ) && null != tmpLV.Extra && tmpLV.Extra.Equals( "NONLICENSED" ) )
                    {
                        //if ( null == tmpLV.Attributes1 )//If not present then Specialty Unit not required for bed type selection
                        //{
                            retLkups.Add( tmpLV );
                        //}
                        //else //Other wise check to see if the specialty unit is selected before adding to list
                        //{
                        //    if ( null != CurrentAppProvider.BO_SpecialtyUnitsApplicationID )
                        //    {
                        //        foreach ( BO_SpecialtyUnit boSU in CurrentAppProvider.BO_SpecialtyUnitsApplicationID )
                        //        {
                        //            if ( null != tmpLV.Attributes1 && boSU.TypeSpecialtyUnit.Equals( tmpLV.Attributes1 ) )
                        //                retLkups.Add( tmpLV );
                        //        }
                        //    }
                        //}
                    }
                }

                return retLkups;
            }
            set
            {
                Session["NonLicBedTypeLookups"] = value;
            }
        }
        
        private BO_Application CurrentAppProvider
        {
            get
            {
                return Session["CurrentAppProvider"] == null ? null : (BO_Application) Session["CurrentAppProvider"];
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

        private bool _IsLicensedBedType( string inLookupVal )
        {
            bool retval = false;

            foreach ( BO_LookupValue boLV in LicBedTypeLookups )
            {
                if ( boLV.LookupVal.Equals( inLookupVal ) )
                {
                    retval = true;
                    break;
                }
            }

            return retval;
        }
        
        private bool _IsNonLicensedBedType( string inLookupVal )
        {
            bool retval = false;

            foreach ( BO_LookupValue boLV in NonLicBedTypeLookups )
            {
                if ( boLV.LookupVal.Equals( inLookupVal ) )
                {
                    retval = true;
                    break;
                }
            }

            return retval;
        }

        private DataTable _getCapSumDataTable()
        {
            DataTable tmpDTbl = new DataTable();
            DataColumn tmpDCol = null;

            tmpDCol = new DataColumn( "Location" );
            tmpDTbl.Columns.Add( tmpDCol );
            tmpDCol = new DataColumn( "LicBeds" );
            tmpDTbl.Columns.Add( tmpDCol );
            tmpDCol = new DataColumn( "LicRooms" );
            tmpDTbl.Columns.Add( tmpDCol );
            tmpDCol = new DataColumn( "NonLicBeds" );
            tmpDTbl.Columns.Add( tmpDCol );
            tmpDCol = new DataColumn( "NonLicRooms" );
            tmpDTbl.Columns.Add( tmpDCol );

            return tmpDTbl;
        }
        
        private DataTable CapacitySummaryDataSource
        {
            get
            {
                DataTable retTable = null;

                retTable = _getCapSumDataTable();

                if ( null != CurrentAppProvider )
                {
                    int tmpLicMainCampBeds = 0;
                    int tmpLicMainCampRooms = 0;
                    int tmpLicOffSiteTotBeds = 0;
                    int tmpLicOffSiteTotRooms = 0;
                    int tmpNonLicMainCampBeds = 0;
                    int tmpNonLicMainCampRooms = 0;
                    int tmpNonLicOffSiteTotBeds = 0;
                    int tmpNonLicOffSiteTotRooms = 0;
                    int missedcnt = 0;
                    int othertype = 0;

                    foreach ( BO_Capacity boCap in CurrentAppProvider.BO_CapacitiesApplicationID )
                    {
                        if ( !boCap.Removed && null == boCap.AffiliationID )
                        {
                            if ( _IsLicensedBedType( boCap.BedsType ) )
                            {
                                tmpLicMainCampBeds += boCap.CapacityCount.Value;
                                tmpLicMainCampRooms++;
                            }
                            else if ( _IsNonLicensedBedType( boCap.BedsType ) )
                            {
                                tmpNonLicMainCampBeds += boCap.CapacityCount.Value;
                                tmpNonLicMainCampRooms++;
                            }
                            else
                            {
                                othertype++;
                            }
                        }
                        else
                        {
                            missedcnt++;
                        }
                    }

                    foreach ( BO_Affiliation boAffil in CurrentAppProvider.BO_AffiliationsApplicationID )
                    {
                        if ( IsOffSite )
                        {
                            if ( !boAffil.Removed && null != boAffil.BO_CapacitiesAffiliationID && boAffil.UI_TrackID.Equals( CurrentAffiliationID ) )
                            {
                                foreach ( BO_Capacity boAffilCap in boAffil.BO_CapacitiesAffiliationID )
                                {
                                    if ( !boAffilCap.Removed )
                                    {
                                        if ( _IsLicensedBedType( boAffilCap.BedsType ) )
                                        {
                                            tmpLicOffSiteTotBeds += boAffilCap.CapacityCount.Value;
                                            tmpLicOffSiteTotRooms++;
                                        }
                                        else if ( _IsNonLicensedBedType( boAffilCap.BedsType ) )
                                        {
                                            tmpNonLicOffSiteTotBeds += boAffilCap.CapacityCount.Value;
                                            tmpNonLicOffSiteTotRooms++;
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            if ( !boAffil.Removed && null != boAffil.BO_CapacitiesAffiliationID )
                            {
                                foreach ( BO_Capacity boAffilCap in boAffil.BO_CapacitiesAffiliationID )
                                {
                                    if ( !boAffilCap.Removed )
                                    {
                                        if ( _IsLicensedBedType( boAffilCap.BedsType ) )
                                        {
                                            tmpLicOffSiteTotBeds += boAffilCap.CapacityCount.Value;
                                            tmpLicOffSiteTotRooms++;
                                        }
                                        else if ( _IsNonLicensedBedType( boAffilCap.BedsType ) )
                                        {
                                            tmpNonLicOffSiteTotBeds += boAffilCap.CapacityCount.Value;
                                            tmpNonLicOffSiteTotRooms++;
                                        }
                                    }
                                }
                            }
                        }
                    }

                    DataRow tmpDR = retTable.NewRow();
                    tmpDR["Location"] = "Main Campus";
                    tmpDR["LicBeds"] = tmpLicMainCampBeds.ToString();
                    tmpDR["LicRooms"] = tmpLicMainCampRooms.ToString();
                    tmpDR["NonLicBeds"] = tmpNonLicMainCampBeds.ToString();
                    tmpDR["NonLicRooms"] = tmpNonLicMainCampRooms.ToString();
                    retTable.Rows.Add( tmpDR );

                    tmpDR = retTable.NewRow();
                    if ( !IsOffSite )
                        tmpDR["Location"] = "All Offsites";
                    else
                        tmpDR["Location"] = "Current Offsite";

                    tmpDR["LicBeds"] = tmpLicOffSiteTotBeds.ToString();
                    tmpDR["LicRooms"] = tmpLicOffSiteTotRooms.ToString();
                    tmpDR["NonLicBeds"] = tmpNonLicOffSiteTotBeds.ToString();
                    tmpDR["NonLicRooms"] = tmpNonLicOffSiteTotRooms.ToString();
                    retTable.Rows.Add( tmpDR );

                    tmpDR = retTable.NewRow();
                    tmpDR["Location"] = "Entire Facility";
                    tmpDR["LicBeds"] = ( tmpLicMainCampBeds + tmpLicOffSiteTotBeds ).ToString();
                    tmpDR["LicRooms"] = ( tmpLicMainCampRooms + tmpLicOffSiteTotRooms ).ToString();
                    tmpDR["NonLicBeds"] = ( tmpNonLicMainCampBeds + tmpNonLicOffSiteTotBeds ).ToString();
                    tmpDR["NonLicRooms"] = ( tmpNonLicMainCampRooms + tmpNonLicOffSiteTotRooms ).ToString();
                    retTable.Rows.Add( tmpDR );

                    
                }

                return retTable;
            }

        }

    }
}