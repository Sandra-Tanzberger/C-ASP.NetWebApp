using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ATG;
using ATG.BusinessObject;
using AppControl;
using Telerik.Web.UI;


namespace Common.EditForm
{
    public partial class CapacityForm : System.Web.UI.Page
    {
        private BedDetails _m_BedDet = null;
        private BedRecEditForm _m_BedRecFrm = null;
        private bool _showError = false;
        
        protected override void RaisePostBackEvent( IPostBackEventHandler sourceControl, string eventArgument )
        {
            base.RaisePostBackEvent( sourceControl, eventArgument );
        } 

        protected void Page_Load( object sender, EventArgs e )
        {
            if ( !IsPostBack )
            {
                string tmpID = Request.QueryString["AFID"].ToString();
                string tmpAction = Request.QueryString["TYPE"].ToString();

                if ( tmpAction.Equals( "Edit" ) )
                {
                    AllowEdit = true;
                    LicReadOnly.Value = "";
                }
                else
                {
                    AllowEdit = false;
                    LicReadOnly.Value = "RO";
                }

                if ( !string.IsNullOrEmpty( tmpID ) )
                {
                    IsOffSite = true;
                    CurrentAffiliationID = tmpID;
                }
                else
                {
                    IsOffSite = false;
                    CurrentAffiliationID = null;
                }

                LoadBedTypes();
                _InitializeGrid( rgBedRecs, "" );
                EnableDisableContrls();
            }
        }

        protected void EnableDisableContrls()
        {
            btnDeleteSelected.Enabled = AllowEdit;
            btnEditSelected.Enabled = AllowEdit;
            btnNewSelected.Enabled = AllowEdit;
            btnNew.Enabled = AllowEdit;
        }

        protected void EditMenu_Click( object sender, EventArgs e )
        {
            Button btnEdit = (Button) sender;
            ShowError = false;
            ValidationMessage = "";

            switch ( btnEdit.CommandName )
            {
                case "Save" :
                    if ( hidEditMode.Value.Equals( "E" ) )
                    {
                        _SaveEditedCapacity();

                        if (!ShowError )
                            hidEditMode.Value = "";
                    }
                    else
                    {
                        if ( !_CheckCapExists() && ( hidEditMode.Value.Equals( "N" ) || hidEditMode.Value.Equals( "NE" ) ) )
                        {
                            _SaveNewCapacity();
                            if ( !ShowError )
                                hidEditMode.Value = "";
                        }
                        else
                        {
                            ShowError = true;
                            ValidationMessage = "A capacity record already exists for this location and room number.";
                        }
                    }                
                    break;
                case "Cancel" :
                    break;

            }

        }

        private void _SaveEditedCapacity()
        {
            ShowError = false;
            ValidationMessage = "";

            if ( string.IsNullOrEmpty(cboServiceType.SelectedValue) )
            {
                ShowError = true;
                ValidationMessage += "Service Type Required<br />";
            }
            if ( txtUnit.Text.Length < 1 )
            {
                ShowError = true;
                ValidationMessage += "Location/Wing is Required<br />";
            }
            if ( txtFloor.Text.Length < 1 )
            {
                ShowError = true;
                ValidationMessage += "Floor is Required<br />";
            }
            if ( txtRoomNumber.Text.Length < 1 )
            {
                ShowError = true;
                ValidationMessage += "Room Number is Required<br />";
            }
            if ( txtNumberBeds.Text.Length < 1 )
            {
                ShowError = true;
                ValidationMessage += "Number of Beds is Required<br />";
            }

            if ( !ShowError )
            {
                foreach ( BO_Capacity boCap in CurrentAppBedCapList )
                {
                    if ( boCap.UI_TrackID.Equals( UITrackID ) )
                    {
                        boCap.BedsUnit = BedUnit;
                        boCap.BedsType = ServiceType;
                        boCap.BedsFloor = BedFloor;
                        boCap.BedsRoomNumber = BedRoomNumber;
                        boCap.CapacityCount = CapacityCount;
                        boCap.BedsRoomSizeMet = BedRoomSizeMet;
                        boCap.BedsFurnitureMet = BedFurnitureMet;
                        boCap.BedsPrivacyMet = BedCurtainWallMet;
                        boCap.BedsCallSystemMet = BedCallSystemMet;
                        boCap.BedsComment = BedComments;
                        break;
                    }
                }

                BedDataSource = null;
                rgBedRecs.Rebind();
                hidUITrackID.Value = UITrackID;
            }
        }

        private void _SaveNewCapacity()
        {
            ShowError = false;
            ValidationMessage = "";

            if ( cboServiceType.SelectedIndex == 0 )
            {
                ShowError = true;
                ValidationMessage += "Service Type Required<br/>";
            }
            if ( txtUnit.Text.Length < 1 )
            {
                ShowError = true;
                ValidationMessage += "Location/Wing is Required<br/>";
            }
            if ( txtFloor.Text.Length < 1 )
            {
                ShowError = true;
                ValidationMessage += "Floor is Required<br/>";
            }
            if ( txtRoomNumber.Text.Length < 1 )
            {
                ShowError = true;
                ValidationMessage += "Room Number is Required<br/>";
            }
            if ( txtNumberBeds.Text.Length < 1 )
            {
                ShowError = true;
                ValidationMessage += "Number of Beds is Required<br/>";
            }

            if ( !ShowError )
            {
                BO_Capacity newCapacity = new BO_Capacity();

                newCapacity.IsNewRec = true;
                newCapacity.PopsIntID = CurrentAppProvider.PopsIntID;
                newCapacity.ApplicationID = CurrentAppProvider.ApplicationID;

                if ( IsOffSite && CurrentAffiliationID.Substring( 0, 1 ) != "N" )
                    newCapacity.AffiliationID = Convert.ToDecimal( CurrentAffiliationID );
                else if ( IsOffSite )
                    newCapacity.AffiliationID = 0;

                newCapacity.CapacityType = "1";
                newCapacity.BedsUnit = BedUnit;
                newCapacity.BedsType = ServiceType;
                newCapacity.BedsFloor = BedFloor;
                newCapacity.BedsRoomNumber = BedRoomNumber;
                newCapacity.CapacityCount = CapacityCount;
                newCapacity.BedsRoomSizeMet = BedRoomSizeMet;
                newCapacity.BedsFurnitureMet = BedFurnitureMet;
                newCapacity.BedsPrivacyMet = BedCurtainWallMet;
                newCapacity.BedsCallSystemMet = BedCallSystemMet;
                newCapacity.BedsComment = BedComments;
                newCapacity.UI_TrackID = "N" + BedDataSource.Rows.Count.ToString();

                CurrentAppBedCapList.Add( newCapacity );

                BedDataSource = null;
                rgBedRecs.Rebind();
                hidUITrackID.Value = newCapacity.UI_TrackID;
            }
        }

        private bool _CheckCapExists()
        {
            bool retVal = false;

            foreach ( BO_Capacity tmpCap in CurrentAppBedCapList )
            {
                if ( IsOffSite && tmpCap.AffiliationID.Value.ToString().Equals( CurrentAffiliationID ) )
                {
                    if ( tmpCap.BedsFloor == BedFloor 
                         && tmpCap.BedsRoomNumber == BedRoomNumber 
                         && tmpCap.BedsUnit == BedUnit
                        )
                    {
                        retVal = true;
                        break;
                    }
                }
                else
                {
                    if ( null == tmpCap.AffiliationID )
                    {
                        if ( tmpCap.BedsFloor == BedFloor
                             && tmpCap.BedsRoomNumber == BedRoomNumber
                             && tmpCap.BedsUnit == BedUnit
                            )
                        {
                            retVal = true;
                            break;
                        }
                    }
                }
            }

            return retVal;
        }

        protected void ActionMenu_Click( object sender, EventArgs e )
        {
            Button btnAction = (Button) sender;

            switch ( btnAction.CommandName )
            {
                case "New":
                    break;
                case "NewSelected":
                    break;
                case "EditSelected":
                    break;
                case "DeleteSelected":
                    _DeleteCapacity();
                    break;

            }

        }

        private void _DeleteCapacity()
        {
            string tmpUITrackID = hidUITrackID.Value;

            foreach ( BO_Capacity boCap in CurrentAppBedCapList )
            {
                if ( boCap.UI_TrackID.Equals( tmpUITrackID ) )
                {
                    boCap.Removed = true;
                    break;
                }
            }

            BedDataSource = null;
            rgBedRecs.Rebind();
        }

        protected void rgBedRecs_NeedDataSource( object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e )
        {
            if ( null != CurrentAppProvider && null != BedDataSource )
            {
                rgBedRecs.DataSource = BedDataSource;
            }

            int TotLicBeds = 0;
            int TotNonLicBeds = 0;
            int TotRooms = 0;

            foreach ( DataRow dr in BedDataSource.Rows )
            {
                if ( dr["Licensed"].ToString().Equals( "Y" ) )
                    TotLicBeds += Convert.ToInt16( dr["CapacityCount"] );
                else
                    TotNonLicBeds += Convert.ToInt16( dr["CapacityCount"] );

                TotRooms += 1;
            }

            litTotalLicBeds.Text = TotLicBeds.ToString();
            litTotalNonLicBeds.Text = TotNonLicBeds.ToString();
            litTotalRooms.Text = TotRooms.ToString();

        }

        protected void rgBedRecs_ItemCreated( object sender, GridItemEventArgs e )
        {
            if ( e.Item is GridCommandItem )
                if ( null != e.Item.FindControl( "InitInsertButton" ) )
                    e.Item.FindControl( "InitInsertButton" ).Parent.Visible = false;
        }

        protected void rgBedRecs_ItemDataBound( object sender, Telerik.Web.UI.GridItemEventArgs e )
        {
            if ( e.Item is GridDataItem )
            {
                GridDataItem item = (GridDataItem) e.Item;
                if ( null != item["UITrackID"] && item["UITrackID"].Text == hidUITrackID.Value )
                {
                    item.Selected = true;
                }
            }
        }  

        private void _InitializeGrid( RadGrid inGridToInit, string inGridType )
        {
            inGridToInit.AllowFilteringByColumn = true;
            inGridToInit.EnableViewState = true;
            inGridToInit.ShowHeader = true;
            inGridToInit.AllowPaging = false;
            //inGridToInit.PageSize = 10;
            inGridToInit.AllowSorting = true;
            inGridToInit.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
            inGridToInit.ClientSettings.Selecting.AllowRowSelect = true;
            inGridToInit.ClientSettings.Scrolling.AllowScroll = true;
            inGridToInit.ClientSettings.Scrolling.UseStaticHeaders = true;
            inGridToInit.ClientSettings.Resizing.AllowColumnResize = true;
            inGridToInit.RegisterWithScriptManager = true;

            if ( inGridToInit.Columns.Count < 1 )
                _BuildGridColumns( inGridToInit );

            inGridToInit.DataSource = BedDataSource;
            inGridToInit.DataBind();

            int TotLicBeds = 0;
            int TotNonLicBeds = 0;
            int TotRooms = 0;

            foreach ( DataRow dr in BedDataSource.Rows )
            {
                if ( dr["Licensed"].ToString().Equals( "Y" ) )
                    TotLicBeds += Convert.ToInt16( dr["CapacityCount"] );
                else
                    TotNonLicBeds += Convert.ToInt16( dr["CapacityCount"] );

                TotRooms += 1;
            }

            litTotalLicBeds.Text = TotLicBeds.ToString();
            litTotalNonLicBeds.Text = TotNonLicBeds.ToString();
            litTotalRooms.Text = TotRooms.ToString();
        }   

        private void _BuildGridColumns( RadGrid inGridToInit )
        {
            GridBoundColumn tmpCol = new GridBoundColumn();
            inGridToInit.MasterTableView.Columns.Add( tmpCol );
            tmpCol.UniqueName = "BedsType";
            tmpCol.DataField = "BedsType";
            tmpCol.HeaderText = "Service Type";
            tmpCol.AllowFiltering = true;
            tmpCol.Visible = true;
            tmpCol.HeaderStyle.Width = Unit.Pixel( 200 );

            tmpCol = new GridBoundColumn();
            inGridToInit.MasterTableView.Columns.Add( tmpCol );
            tmpCol.UniqueName = "BedsUnit";
            tmpCol.DataField = "BedsUnit";
            tmpCol.HeaderText = "Location/Wing";
            tmpCol.AllowFiltering = true;
            tmpCol.Visible = true;
            tmpCol.HeaderStyle.Width = Unit.Pixel( 150 );

            tmpCol = new GridBoundColumn();
            inGridToInit.MasterTableView.Columns.Add( tmpCol );
            tmpCol.UniqueName = "BedsFloor";
            tmpCol.DataField = "BedsFloor";
            tmpCol.HeaderText = "Floor";
            tmpCol.AllowFiltering = true;
            tmpCol.Visible = true;
            tmpCol.HeaderStyle.Width = Unit.Pixel( 125 );

            tmpCol = new GridBoundColumn();
            inGridToInit.MasterTableView.Columns.Add( tmpCol );
            tmpCol.UniqueName = "BedsRoomNumber";
            tmpCol.DataField = "BedsRoomNumber";
            tmpCol.HeaderText = "Room Number";
            tmpCol.AllowFiltering = false;
            tmpCol.Visible = true;
            tmpCol.HeaderStyle.Width = Unit.Pixel( 125 );

            tmpCol = new GridBoundColumn();
            inGridToInit.MasterTableView.Columns.Add( tmpCol );
            tmpCol.UniqueName = "CapacityCount";
            tmpCol.DataField = "CapacityCount";
            tmpCol.HeaderText = "Capacity";
            tmpCol.AllowFiltering = false;
            tmpCol.Visible = true;
            tmpCol.HeaderStyle.Width = Unit.Pixel( 100 );

            tmpCol = new GridBoundColumn();
            inGridToInit.MasterTableView.Columns.Add( tmpCol );
            tmpCol.UniqueName = "Licensed";
            tmpCol.DataField = "Licensed";
            tmpCol.HeaderText = "Licensed";
            tmpCol.AllowFiltering = true;
            tmpCol.Visible = true;
            tmpCol.HeaderStyle.Width = Unit.Pixel( 125 );

            tmpCol = new GridBoundColumn();
            inGridToInit.MasterTableView.Columns.Add( tmpCol );
            tmpCol.UniqueName = "BedsRoomSizeMet";
            tmpCol.DataField = "BedsRoomSizeMet";
            tmpCol.HeaderText = "Room Size Criteria Met";
            tmpCol.AllowFiltering = false;
            tmpCol.Visible = true;
            tmpCol.Display = false;

            tmpCol = new GridBoundColumn();
            inGridToInit.MasterTableView.Columns.Add( tmpCol );
            tmpCol.UniqueName = "BedsCallSystemMet";
            tmpCol.DataField = "BedsCallSystemMet";
            tmpCol.HeaderText = "Call System Criteria Met";
            tmpCol.AllowFiltering = false;
            tmpCol.Visible = true;
            tmpCol.Display = false;

            tmpCol = new GridBoundColumn();
            inGridToInit.MasterTableView.Columns.Add( tmpCol );
            tmpCol.UniqueName = "BedsFurnitureMet";
            tmpCol.DataField = "BedsFurnitureMet";
            tmpCol.HeaderText = "Furniture Criteria Met";
            tmpCol.AllowFiltering = false;
            tmpCol.Visible = true;
            tmpCol.Display = false;

            tmpCol = new GridBoundColumn();
            inGridToInit.MasterTableView.Columns.Add( tmpCol );
            tmpCol.UniqueName = "BedsPrivacyMet";
            tmpCol.DataField = "BedsPrivacyMet";
            tmpCol.HeaderText = "Privacy Curtin or Wall Met";
            tmpCol.AllowFiltering = false;
            tmpCol.Visible = true;
            tmpCol.Display = false;

            tmpCol = new GridBoundColumn();
            inGridToInit.MasterTableView.Columns.Add( tmpCol );
            tmpCol.UniqueName = "Comments";
            tmpCol.DataField = "Comments";
            tmpCol.HeaderText = "Comments";
            tmpCol.AllowFiltering = false;
            tmpCol.Visible = true;
            tmpCol.HeaderStyle.Width = Unit.Pixel( 300 );

            tmpCol = new GridBoundColumn();
            inGridToInit.MasterTableView.Columns.Add( tmpCol );
            tmpCol.UniqueName = "CapacityID";
            tmpCol.DataField = "CapacityID";
            tmpCol.HeaderText = "Internal ID for Capacity Record";
            tmpCol.AllowFiltering = false;
            tmpCol.Visible = true;
            tmpCol.Display = false;
            tmpCol.HeaderStyle.Width = Unit.Pixel( 50 );

            tmpCol = new GridBoundColumn();
            inGridToInit.MasterTableView.Columns.Add( tmpCol );
            tmpCol.UniqueName = "PopsIntID";
            tmpCol.DataField = "PopsIntID";
            tmpCol.HeaderText = "Provider Internal ID";
            tmpCol.AllowFiltering = false;
            tmpCol.Visible = true;
            tmpCol.Display = false;
            tmpCol.HeaderStyle.Width = Unit.Pixel( 50 );

            tmpCol = new GridBoundColumn();
            inGridToInit.MasterTableView.Columns.Add( tmpCol );
            tmpCol.UniqueName = "UITrackID";
            tmpCol.DataField = "UITrackID";
            tmpCol.HeaderText = "UITrackID";
            tmpCol.AllowFiltering = false;
            tmpCol.Visible = true;
            tmpCol.Display = false;
            tmpCol.HeaderStyle.Width = Unit.Pixel( 50 );
        }

        private BO_Capacities CurrentAppBedCapList
        {
            get
            {
                BO_Capacities tmpList = new BO_Capacities();

                if ( null != CurrentAppProvider && null != CurrentAppProvider.BO_CapacitiesApplicationID && !IsOffSite )
                {
                    tmpList = CurrentAppProvider.BO_CapacitiesApplicationID;

                    //foreach ( BO_Capacity boCap in CurrentAppProvider.BO_CapacitiesApplicationID )
                    //{
                    //    if ( null == boCap.AffiliationID )
                    //        tmpList.Add( boCap );
                    //}
                }
                else if ( null != CurrentAffiliation && null != CurrentAffiliation.BO_CapacitiesAffiliationID && IsOffSite )
                {
                    tmpList = CurrentAffiliation.BO_CapacitiesAffiliationID;
                    //foreach ( BO_Capacity boCap in CurrentAffiliation.BO_CapacitiesAffiliationID )
                    //{
                    //    if ( boCap.AffiliationID == CurrentAffiliation.AffiliationID )
                    //        tmpList.Add( boCap );
                    //}
                }

                return tmpList;
            }
            //set
            //{
            //    CurrentAppProvider.BO_CapacitiesApplicationID = value;
            //}
        }

        private DataTable _getBedsGridInitTable()
        {
            DataTable tmpDTbl = new DataTable();
            DataColumn tmpDCol = null;

            tmpDCol = new DataColumn( "BedsType" );
            tmpDTbl.Columns.Add( tmpDCol );
            tmpDCol = new DataColumn( "BedsUnit" );
            tmpDTbl.Columns.Add( tmpDCol );
            tmpDCol = new DataColumn( "BedsFloor" );
            tmpDTbl.Columns.Add( tmpDCol );
            tmpDCol = new DataColumn( "BedsRoomNumber" );
            tmpDTbl.Columns.Add( tmpDCol );
            tmpDCol = new DataColumn( "CapacityCount" );
            tmpDTbl.Columns.Add( tmpDCol );
            tmpDCol = new DataColumn( "Licensed" );
            tmpDTbl.Columns.Add( tmpDCol );
            tmpDCol = new DataColumn( "BedsRoomSizeMet" );
            tmpDTbl.Columns.Add( tmpDCol );
            tmpDCol = new DataColumn( "BedsCallSystemMet" );
            tmpDTbl.Columns.Add( tmpDCol );
            tmpDCol = new DataColumn( "BedsFurnitureMet" );
            tmpDTbl.Columns.Add( tmpDCol );
            tmpDCol = new DataColumn( "BedsPrivacyMet" );
            tmpDTbl.Columns.Add( tmpDCol );
            tmpDCol = new DataColumn( "Comments" );
            tmpDTbl.Columns.Add( tmpDCol );
            tmpDCol = new DataColumn( "CapacityID" );
            tmpDTbl.Columns.Add( tmpDCol );
            tmpDCol = new DataColumn( "PopsIntID" );
            tmpDTbl.Columns.Add( tmpDCol );
            tmpDCol = new DataColumn( "UITrackID" );
            tmpDTbl.Columns.Add( tmpDCol );

            return tmpDTbl;
        }

        private string _getBedTypeText( string inLookupVal )
        {
            string tmpStr = "";

            foreach ( BO_LookupValue boLV in BedTypeLookups )
            {
                if ( boLV.LookupVal.Equals( inLookupVal ) )
                {
                    tmpStr = boLV.Valdesc;// CommonFunc.ConvertToTitleCase( boLV.Valdesc );
                    break;
                }
            }

            //if ( tmpStr.Equals( "" ) )
            //{
            //    foreach ( BO_LookupValue boLV in NonLicBedTypeLookups )
            //    {
            //        if ( boLV.LookupVal.Equals( inLookupVal ) )
            //        {
            //            tmpStr = CommonFunc.ConvertToTitleCase( boLV.Valdesc );
            //            break;
            //        }
            //    }
            //}

            return tmpStr;
        }

        private DataTable BedDataSource
        {
            get
            {
                DataTable retTable = (DataTable) ViewState["BedDataSource"];

                if ( retTable == null )
                {
                    retTable = _getBedsGridInitTable();

                    if ( CurrentAppBedCapList != null && CurrentAppBedCapList.Count > 0 )
                    {
                        foreach ( BO_Capacity boCap in CurrentAppBedCapList )
                        {
                            if ( !IsOffSite )
                            {
                                if ( !boCap.Removed && null == boCap.AffiliationID )
                                {
                                    DataRow tmpDR = retTable.NewRow();
                                    tmpDR["BedsType"] = _getBedTypeText( boCap.BedsType );
                                    tmpDR["BedsUnit"] = boCap.BedsUnit;
                                    tmpDR["BedsFloor"] = boCap.BedsFloor;
                                    tmpDR["BedsRoomNumber"] = boCap.BedsRoomNumber;
                                    tmpDR["CapacityCount"] = boCap.CapacityCount;
                                    tmpDR["Licensed"] = ( _IsLicensedBedType( boCap.BedsType ) ? "Y" : "N" );
                                    tmpDR["BedsRoomSizeMet"] = ( null != boCap.BedsRoomSizeMet && boCap.BedsRoomSizeMet == 1 ) ? "Y" : "N";
                                    tmpDR["BedsCallSystemMet"] = ( null != boCap.BedsCallSystemMet && boCap.BedsCallSystemMet == 1 ) ? "Y" : "N";
                                    tmpDR["BedsFurnitureMet"] = ( null != boCap.BedsFurnitureMet && boCap.BedsFurnitureMet == 1 ) ? "Y" : "N";
                                    tmpDR["BedsPrivacyMet"] = ( null != boCap.BedsPrivacyMet && boCap.BedsPrivacyMet == 1 ) ? "Y" : "N";
                                    tmpDR["Comments"] = boCap.BedsComment;
                                    tmpDR["CapacityID"] = boCap.CapacityID;
                                    tmpDR["PopsIntID"] = boCap.PopsIntID;
                                    tmpDR["UITrackID"] = boCap.UI_TrackID;

                                    retTable.Rows.Add( tmpDR );
                                }
                            }
                            else
                            {
                                if ( !boCap.Removed && boCap.AffiliationID == CurrentAffiliation.AffiliationID )
                                {
                                    DataRow tmpDR = retTable.NewRow();
                                    tmpDR["BedsType"] = _getBedTypeText( boCap.BedsType );
                                    tmpDR["BedsUnit"] = boCap.BedsUnit;
                                    tmpDR["BedsFloor"] = boCap.BedsFloor;
                                    tmpDR["BedsRoomNumber"] = boCap.BedsRoomNumber;
                                    tmpDR["CapacityCount"] = boCap.CapacityCount;
                                    tmpDR["Licensed"] = ( _IsLicensedBedType( boCap.BedsType ) ? "Y" : "N" );
                                    tmpDR["BedsRoomSizeMet"] = ( null != boCap.BedsRoomSizeMet && boCap.BedsRoomSizeMet == 1 ) ? "Y" : "N";
                                    tmpDR["BedsCallSystemMet"] = ( null != boCap.BedsCallSystemMet && boCap.BedsCallSystemMet == 1 ) ? "Y" : "N";
                                    tmpDR["BedsFurnitureMet"] = ( null != boCap.BedsFurnitureMet && boCap.BedsFurnitureMet == 1 ) ? "Y" : "N";
                                    tmpDR["BedsPrivacyMet"] = ( null != boCap.BedsPrivacyMet && boCap.BedsPrivacyMet == 1 ) ? "Y" : "N";
                                    tmpDR["Comments"] = boCap.BedsComment;
                                    tmpDR["CapacityID"] = boCap.CapacityID;
                                    tmpDR["PopsIntID"] = boCap.PopsIntID;
                                    tmpDR["UITrackID"] = boCap.UI_TrackID;

                                    retTable.Rows.Add( tmpDR );
                                }
                            }
                        }
                    }
                }
                return retTable;
            }
            set
            {
                ViewState["BedDataSource"] = value;
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

        private string EditFormControlID
        {
            get
            {
                return this.ViewState["EditFormControlID"] == null ? string.Empty : (string) this.ViewState["EditFormControlID"];
            }
            set
            {
                this.ViewState["EditFormControlID"] = value;
            }
        }

        private string CapacityGridControlID
        {
            get
            {
                return this.ViewState["CapacityGridControlID"] == null ? string.Empty : (string) this.ViewState["CapacityGridControlID"];
            }
            set
            {
                this.ViewState["CapacityGridControlID"] = value;
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

        //Original BedRecEditForm code//
        public void LoadBedTypes()
        {
            BO_LookupValues tmpLKUPS = null;

            DataTable tmpDT = new DataTable();
            DataRow tmpRow;

            tmpDT.Columns.Add( "LOOKUP_VAL" );
            tmpDT.Columns.Add( "VALDESC" );

            tmpLKUPS = BedTypeLookups;
            
            tmpRow = tmpDT.NewRow();
            tmpRow["LOOKUP_VAL"] = "-1";
            tmpRow["VALDESC"] = "";
            tmpDT.Rows.Add( tmpRow );
            
            foreach ( BO_LookupValue boLV in tmpLKUPS )
            {
                tmpRow = tmpDT.NewRow();
                tmpRow["LOOKUP_VAL"] = boLV.LookupVal;
                tmpRow["VALDESC"] = boLV.Valdesc;
                tmpDT.Rows.Add( tmpRow );
            }

            cboServiceType.DataSource = tmpDT;
            cboServiceType.DataBind();
        }

        public String BedUnit
        {
            get
            {
                return txtUnit.Text;
            }
            set
            {
                txtUnit.Text = value;
            }
        }

        public String ServiceType
        {
            get
            {
                return cboServiceType.SelectedValue;
            }
            set
            {
                cboServiceType.SelectedValue = value;
            }
        }

        public String BedFloor
        {
            get
            {
                return txtFloor.Text;
            }
            set
            {
                txtFloor.Text = value;
            }
        }

        public String BedRoomNumber
        {
            get
            {
                return txtRoomNumber.Text;
            }
            set
            {
                txtRoomNumber.Text = value;
            }
        }

        public int CapacityCount
        {
            get
            {
                return int.Parse( txtNumberBeds.Text );
            }
            set
            {
                txtNumberBeds.Text = value.ToString();
            }
        }

        public int BedRoomSizeMet
        {
            get
            {
                return chkRoomSizeMet.Checked ? 1 : 0;

            }
            set
            {
                chkRoomSizeMet.Checked = ( value == 1 ? true : false );
            }
        }

        public int BedCallSystemMet
        {
            get
            {
                return ChkCallSysMet.Checked ? 1 : 0;

            }
            set
            {
                ChkCallSysMet.Checked = ( value == 1 ? true : false );
            }
        }

        public int BedFurnitureMet
        {
            get
            {
                return ChkFurnitureMet.Checked ? 1 : 0;

            }
            set
            {
                ChkFurnitureMet.Checked = ( value == 1 ? true : false );
            }
        }

        public int BedCurtainWallMet
        {
            get
            {
                return ChkPrivacyMet.Checked ? 1 : 0;

            }
            set
            {
                ChkPrivacyMet.Checked = ( value == 1 ? true : false );
            }
        }

        public string BedComments
        {
            get
            {
                return txtComments.Text;

            }
            set
            {
                txtComments.Text = value;
            }
        }

        public string UITrackID
        {
            get
            {
                return hidUITrackID.Value;

            }
            set
            {
                hidUITrackID.Value = value;
            }
        }

        public bool IsLicensed
        {
            get
            {
                return _IsLicensed;
            }
            set
            {
                _IsLicensed = value;
            }
        }

        public bool ShowError
        {
            get
            {
                return _showError;
            }
            set
            {
                _showError = value;
                if (value)
                    ErrorText.Style.Add( "display", "block" );
                else 
                    ErrorText.Style.Add( "display", "none" ); 
            }
        }

        public string ValidationMessage
        {
            get
            {
                return ErrorText.InnerHtml;
            }
            set
            {
                ErrorText.InnerHtml = value;
            }
        }

        private BO_Application CurrentAppProvider
        {
            get
            {
                return Session["CurrentAppProvider"] == null ? null : (BO_Application) Session["CurrentAppProvider"];
            }
        }

        private BO_LookupValues BedTypeLookups
        {
            get
            {
                BO_LookupValues retLkups = new BO_LookupValues();

                BO_LookupValues tmpLkups = BO_LookupValue.SelectByField( BO_LookupValueFields.LookupKey, "BED_TYPE" );

                tmpLkups.Sort( "Valdesc" );

                foreach ( BO_LookupValue tmpLV in tmpLkups )
                {
                    if ( tmpLV.Allowedtypes.Contains( CurrentAppProvider.ProgramID ) )//&& null != tmpLV.Extra && tmpLV.Extra.Equals( "NONLICENSED" ) )
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
            //set
            //{
            //    Session["NonLicBedTypeLookups"] = value;
            //}
        }

        private BO_LookupValues LicBedTypeLookups
        {
            get
            {
                BO_LookupValues retLkups = new BO_LookupValues();

                //BO_LookupValues tmpLkups = BO_LookupValue.SelectByField( BO_LookupValueFields.LookupKey, "BED_TYPE" );
                foreach ( BO_LookupValue tmpLV in BedTypeLookups )
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
            //set
            //{
            //    Session["LicBedTypeLookups"] = value;
            //}
        }

        private BO_LookupValues NonLicBedTypeLookups
        {
            get
            {
                BO_LookupValues retLkups = new BO_LookupValues();

                foreach ( BO_LookupValue tmpLV in BedTypeLookups )
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
            //set
            //{
            //    Session["NonLicBedTypeLookups"] = value;
            //}
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

        private bool _IsLicensed = false;
    }
}
