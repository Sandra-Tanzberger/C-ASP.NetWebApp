using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ATG.BusinessObject;
using ATG.Utilities.Data;
using Telerik.Web.UI;
using ATG;

namespace AppControl
{
    public partial class BedDetails : System.Web.UI.UserControl
    {
        protected void Page_Load( object sender, EventArgs e )
        {
        }

        public void LoadBeds( string inKeyID, bool inAllowEdit, bool inIsOffsiteAffil )
        {
            AllowEdit = inAllowEdit;
            IsOffSite = inIsOffsiteAffil;
            CurrentAffiliationID = inKeyID;

            _InitializeGrid( rgLicensedBedRecs, "Licensed" );
            _InitializeGrid( rgNonLicensedBedRecs, "NonLicensed" );
        }

        public bool SaveData()
        {
            bool noSaveError = true;

            // TODO: move the validation code into a separate method ?
            noSaveError = _DoValidate();

            return noSaveError;
        }

        /// <summary>
        /// Data Validation
        /// </summary>
        /// <returns></returns>
        private bool _DoValidate()
        {
            bool retVal = true;
            string validationErrors = "";

            ErrorText.Visible = false;
            ErrorText.InnerHtml = "";

            /* 
             * TODO: Validation code goes here
             * In case of Validation failure, the following needs to happen:
             * 1) ErrorText.Visible = true;
             * 2) ErrorText.InnerHtml += validationErrors;
             * 3) retVal = false;
             */

            return retVal;
        }

        /// <summary>
        /// This is called from State POPS for read-only display of Beds
        /// </summary>
        public void DisableBedsGrid()
        {
            // disable the Grid
            rgLicensedBedRecs.Enabled = false;
        }

        /// <summary>
        /// This is called from State POPS for clearing out the grid
        /// </summary>
        public void ClearGrid()
        {
            // delete pre-existing rows from datasource table
            DataTable dtTable1 = LicensedBedDataSource;
            if ( dtTable1 != null )
            {
                dtTable1.Rows.Clear();
                dtTable1.AcceptChanges();
                LicensedBedDataSource = dtTable1;
                // set the dataSource object for the grid
                rgLicensedBedRecs.DataSource = (DataTable) LicensedBedDataSource;
                rgLicensedBedRecs.DataBind();
            }
        }

        protected void rgLicensedBedRecs_NeedDataSource( object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e )
        {
            int tmpRowCnt = 0;
            if ( null != CurrentAppProvider && null != LicensedBedDataSource )
            {
                //tmpRowCnt = LicensedBedDataSource.Rows.Count > 0 ? LicensedBedDataSource.Rows.Count + 2 : 3;
                //rgLicensedBedRecs.Height = Unit.Pixel( ( 26 * tmpRowCnt ) + 3 );
                rgLicensedBedRecs.DataSource = (DataTable) LicensedBedDataSource;
            }

        }

        protected void rgLicensedBedRecs_ItemCreated( object sender, Telerik.Web.UI.GridItemEventArgs e )
        {
            BedRecEditForm tmpBREF = (BedRecEditForm) e.Item.FindControl( GridEditFormItem.EditFormUserControlID );

            int tmpRowCnt = LicensedBedDataSource.Rows.Count > 0 ? LicensedBedDataSource.Rows.Count + 2 : 3;

            if ( tmpBREF != null )
            {
                Button tmpInsertBtn = (Button) tmpBREF.FindControlRecursive( "btnInsert" );
                Button tmpUpdateBtn = (Button) tmpBREF.FindControlRecursive( "btnUpdate" );

                if ( ( e.Item is GridEditFormInsertItem ) && e.Item.IsInEditMode )
                {
                    rgLicensedBedRecs.Height = Unit.Pixel( ( 26 * tmpRowCnt ) + 225 );
                    tmpInsertBtn.Visible = true;
                    tmpUpdateBtn.Visible = false;
                }
                else if ( ( e.Item is GridEditableItem ) && e.Item.IsInEditMode )
                {
                    rgLicensedBedRecs.Height = Unit.Pixel( ( 26 * tmpRowCnt ) + 225 );
                    tmpInsertBtn.Visible = false;
                    tmpUpdateBtn.Visible = true;
                }


                GridEditFormItem editedItem = e.Item as GridEditFormItem;

                //SMM TODO - This is a hack at this point as I have been unable to find a way to determine if the cancel button
                //was clicked and abort processing on the edit form.  
                if ( !( e.Item is GridEditFormInsertItem ) && !editedItem["UITrackID"].Text.Contains( "&nbsp;" ) )
                {
                    string tmpCapacityID = editedItem["UITrackID"].Text;

                    foreach ( BO_Capacity boCap in CurrentAppBedCapList )
                    {
                        if ( boCap.UI_TrackID.Equals( tmpCapacityID ) )
                        {
                            tmpBREF.BedUnit = boCap.BedsUnit;
                            tmpBREF.BedFloor = boCap.BedsFloor;
                            tmpBREF.BedRoomNumber = boCap.BedsRoomNumber;
                            tmpBREF.CapacityCount = boCap.CapacityCount.Value;
                            tmpBREF.BedRoomSizeMet = boCap.BedsRoomSizeMet.Value;
                            tmpBREF.BedCallSystemMet = boCap.BedsCallSystemMet.Value;
                            tmpBREF.BedFurnitureMet = boCap.BedsFurnitureMet.Value;
                            tmpBREF.BedCurtainWallMet = boCap.BedsPrivacyMet.Value;
                            tmpBREF.BedComments = boCap.BedsComment;
                            tmpBREF.UITrackID = boCap.UI_TrackID;

                            tmpBREF.IsLicensed = true;
                            tmpBREF.LoadBedTypes();
                            tmpBREF.ServiceType = boCap.BedsType;
                        }
                    }
                }
                else if ( e.Item is GridEditFormInsertItem )
                {
                    tmpBREF.IsLicensed = true;
                    tmpBREF.LoadBedTypes();
                }
            }
        }

        protected void rgLicensedBedRecs_InsertCommand( object source, GridCommandEventArgs e )
        {
            GridEditableItem editedItem = e.Item as GridEditableItem;
            BedRecEditForm tmpBREF = (BedRecEditForm) e.Item.FindControl( GridEditFormItem.EditFormUserControlID );

            bool recExists = false;
            tmpBREF.ShowError = false;
            tmpBREF.ValidationMessage = "";
            
            foreach ( BO_Capacity tmpCap in CurrentAppBedCapList )
            {
                if ( IsOffSite && tmpCap.UI_TrackID == CurrentAffiliationID )
                {
                    if ( tmpCap.BedsFloor == tmpBREF.BedFloor && tmpCap.BedsRoomNumber == tmpBREF.BedRoomNumber )
                    {
                        recExists = true;
                        break;
                    }
                }
                else
                {
                    if ( null == tmpCap.AffiliationID )
                    {
                        if ( tmpCap.BedsFloor == tmpBREF.BedFloor && tmpCap.BedsRoomNumber == tmpBREF.BedRoomNumber )
                        {
                            recExists = true;
                            break;
                        }
                    }
                }
            }

            if ( !recExists )
            {
                BO_Capacity newCapacity = new BO_Capacity();

                newCapacity.IsNewRec = true;
                newCapacity.PopsIntID = CurrentAppProvider.PopsIntID;
                newCapacity.ApplicationID = CurrentAppProvider.ApplicationID;

                if (IsOffSite && CurrentAffiliationID.Substring(0, 1) != "N")
                    newCapacity.AffiliationID = Convert.ToDecimal(CurrentAffiliationID);
                else if (IsOffSite)
                    newCapacity.AffiliationID = 0;

                newCapacity.CapacityType = "1";
                newCapacity.BedsUnit = tmpBREF.BedUnit;
                newCapacity.BedsType = tmpBREF.ServiceType;
                newCapacity.BedsFloor = tmpBREF.BedFloor;
                newCapacity.BedsRoomNumber = tmpBREF.BedRoomNumber;
                newCapacity.CapacityCount = tmpBREF.CapacityCount;
                newCapacity.BedsRoomSizeMet = tmpBREF.BedRoomSizeMet;
                newCapacity.BedsFurnitureMet = tmpBREF.BedFurnitureMet;
                newCapacity.BedsPrivacyMet = tmpBREF.BedCurtainWallMet;
                newCapacity.BedsCallSystemMet = tmpBREF.BedCallSystemMet;
                newCapacity.BedsComment = tmpBREF.BedComments;
                newCapacity.UI_TrackID = "N" + LicensedBedDataSource.Rows.Count.ToString();

                CurrentAppBedCapList.Add( newCapacity );

                LicensedBedDataSource = null;
            }
            else
            {
                tmpBREF.ShowError = true;
                tmpBREF.ValidationMessage = "A capacilty record already exists for this location and room number.";
                e.Canceled = true;
            }
        }

        protected void rgLicensedBedRecs_UpdateCommand( object source, GridCommandEventArgs e )
        {
            GridEditableItem editedItem = e.Item as GridEditableItem;
            BedRecEditForm tmpBREF = (BedRecEditForm) e.Item.FindControl( GridEditFormItem.EditFormUserControlID );

            foreach ( BO_Capacity boCap in CurrentAppBedCapList )
            {
                if ( boCap.UI_TrackID.Equals( tmpBREF.UITrackID ) && _IsLicensedBedType( boCap.BedsType ) )
                {
                    boCap.BedsUnit = tmpBREF.BedUnit;
                    boCap.BedsType = tmpBREF.ServiceType;
                    boCap.BedsFloor = tmpBREF.BedFloor;
                    boCap.BedsRoomNumber = tmpBREF.BedRoomNumber;
                    boCap.CapacityCount = tmpBREF.CapacityCount;
                    boCap.BedsRoomSizeMet = tmpBREF.BedRoomSizeMet;
                    boCap.BedsFurnitureMet = tmpBREF.BedFurnitureMet;
                    boCap.BedsPrivacyMet = tmpBREF.BedCurtainWallMet;
                    boCap.BedsCallSystemMet = tmpBREF.BedCallSystemMet;
                    boCap.BedsComment = tmpBREF.BedComments;
                    break;
                }
            }

            LicensedBedDataSource = null;
        }

        protected void rgLicensedBedRecs_DeleteCommand( object source, GridCommandEventArgs e )
        {
            GridEditableItem editedItem = e.Item as GridEditableItem;
            string tmpUITrackID = editedItem["UITrackID"].Text;

            foreach ( BO_Capacity boCap in CurrentAppBedCapList )
            {
                if ( boCap.UI_TrackID.Equals( tmpUITrackID ) && _IsLicensedBedType( boCap.BedsType ) )
                {
                    boCap.Removed = true;
                    break;
                }
            }

            LicensedBedDataSource = null;

        }

        protected void rgLicensedBedRecs_PreRender( object source, EventArgs e )
        {
            LinkButton tmpInsertBtn = (LinkButton) this.FindControlRecursive( "btnLBAddNew" );
            LinkButton tmpEditBtn = (LinkButton) this.FindControlRecursive( "btnLBEditSelected" );
            LinkButton tmpViewBtn = (LinkButton) this.FindControlRecursive( "btnLBViewSelected" );
            LinkButton tmpDeleteBtn = (LinkButton) this.FindControlRecursive( "btnLBDeleteSelected" );

            if (AllowEdit)
            {
                if (null != tmpInsertBtn && null != tmpEditBtn && null != tmpViewBtn && null != tmpDeleteBtn)
                {
                    if (LicensedBedDataSource.Rows.Count < 1)
                    {
                        tmpInsertBtn.Visible = true;
                        tmpEditBtn.Visible = false;
                        tmpViewBtn.Visible = false;
                        tmpDeleteBtn.Visible = false;
                    }
                    else
                    {
                        tmpInsertBtn.Visible = true;
                        tmpEditBtn.Visible = true;
                        tmpViewBtn.Visible = false;
                        tmpDeleteBtn.Visible = true;
                    }
                }
            }
        }

        protected void rgNonLicensedBedRecs_NeedDataSource( object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e )
        {
            int tmpRowCnt = 0;
            if ( null != CurrentAppProvider && null != NonLicensedBedDataSource )
            {
                tmpRowCnt = NonLicensedBedDataSource.Rows.Count > 0 ? NonLicensedBedDataSource.Rows.Count + 2 : 3;
                rgNonLicensedBedRecs.Height = Unit.Pixel( ( 26 * tmpRowCnt ) + 3 );
                rgNonLicensedBedRecs.DataSource = (DataTable) NonLicensedBedDataSource;
            }

        }

        protected void rgNonLicensedBedRecs_ItemCreated( object sender, Telerik.Web.UI.GridItemEventArgs e )
        {
            BedRecEditForm tmpBREF = (BedRecEditForm) e.Item.FindControl( GridEditFormItem.EditFormUserControlID );

            int tmpRowCnt = LicensedBedDataSource.Rows.Count > 0 ? LicensedBedDataSource.Rows.Count + 2 : 3;

            if ( tmpBREF != null )
            {
                Button tmpInsertBtn = (Button) tmpBREF.FindControlRecursive( "btnInsert" );
                Button tmpUpdateBtn = (Button) tmpBREF.FindControlRecursive( "btnUpdate" );

                if ( ( e.Item is GridEditFormInsertItem ) && e.Item.IsInEditMode )
                {
                    rgNonLicensedBedRecs.Height = Unit.Pixel( ( 26 * tmpRowCnt ) + 225 );
                    tmpInsertBtn.Visible = true;
                    tmpUpdateBtn.Visible = false;
                }
                else if ( ( e.Item is GridEditableItem ) && e.Item.IsInEditMode )
                {
                    rgNonLicensedBedRecs.Height = Unit.Pixel( ( 26 * tmpRowCnt ) + 225 );
                    tmpInsertBtn.Visible = false;
                    tmpUpdateBtn.Visible = true;
                }


                GridEditFormItem editedItem = e.Item as GridEditFormItem;

                //SMM TODO - This is a hack at this point as I have been unable to find a way to determine if the cancel button
                //was clicked and abort processing on the edit form.  
                if ( !( e.Item is GridEditFormInsertItem ) && !editedItem["UITrackID"].Text.Contains( "&nbsp;" ) )
                {
                    string tmpCapacityID = editedItem["UITrackID"].Text;

                    foreach ( BO_Capacity boCap in CurrentAppBedCapList )
                    {
                        if ( boCap.UI_TrackID.Equals( tmpCapacityID ) )
                        {
                            tmpBREF.BedUnit = boCap.BedsUnit;
                            tmpBREF.BedFloor = boCap.BedsFloor;
                            tmpBREF.BedRoomNumber = boCap.BedsRoomNumber;
                            tmpBREF.CapacityCount = boCap.CapacityCount.Value;
                            tmpBREF.BedRoomSizeMet = boCap.BedsRoomSizeMet.Value;
                            tmpBREF.BedCallSystemMet = boCap.BedsCallSystemMet.Value;
                            tmpBREF.BedFurnitureMet = boCap.BedsFurnitureMet.Value;
                            tmpBREF.BedCurtainWallMet = boCap.BedsPrivacyMet.Value;
                            tmpBREF.BedComments = boCap.BedsComment;
                            tmpBREF.UITrackID = boCap.UI_TrackID;

                            tmpBREF.IsLicensed = false;
                            tmpBREF.LoadBedTypes();
                            tmpBREF.ServiceType = boCap.BedsType;
                        }
                    }
                }
                else if ( e.Item is GridEditFormInsertItem )
                {
                    tmpBREF.IsLicensed = false;
                    tmpBREF.LoadBedTypes();
                }
            }
        }

        protected void rgNonLicensedBedRecs_InsertCommand( object source, GridCommandEventArgs e )
        {
            GridEditableItem editedItem = e.Item as GridEditableItem;
            BedRecEditForm tmpBREF = (BedRecEditForm) e.Item.FindControl( GridEditFormItem.EditFormUserControlID );

            BO_Capacity newCapacity = new BO_Capacity();

            newCapacity.IsNewRec = true;
            newCapacity.PopsIntID = CurrentAppProvider.PopsIntID;
            newCapacity.ApplicationID = CurrentAppProvider.ApplicationID;
            newCapacity.CapacityType = "1";
            newCapacity.BedsUnit = tmpBREF.BedUnit;
            newCapacity.BedsType = tmpBREF.ServiceType;
            newCapacity.BedsFloor = tmpBREF.BedFloor;
            newCapacity.BedsRoomNumber = tmpBREF.BedRoomNumber;
            newCapacity.CapacityCount = tmpBREF.CapacityCount;
            newCapacity.BedsRoomSizeMet = tmpBREF.BedRoomSizeMet;
            newCapacity.BedsFurnitureMet = tmpBREF.BedFurnitureMet;
            newCapacity.BedsPrivacyMet = tmpBREF.BedCurtainWallMet;
            newCapacity.BedsCallSystemMet = tmpBREF.BedCallSystemMet;
            newCapacity.BedsComment = tmpBREF.BedComments;
            newCapacity.UI_TrackID = "N" + NonLicensedBedDataSource.Rows.Count.ToString();

            CurrentAppBedCapList.Add( newCapacity );

            NonLicensedBedDataSource = null;
        }

        protected void rgNonLicensedBedRecs_UpdateCommand( object source, GridCommandEventArgs e )
        {
            GridEditableItem editedItem = e.Item as GridEditableItem;
            BedRecEditForm tmpBREF = (BedRecEditForm) e.Item.FindControl( GridEditFormItem.EditFormUserControlID );

            foreach ( BO_Capacity boCap in CurrentAppBedCapList )
            {
                if ( boCap.UI_TrackID.Equals( tmpBREF.UITrackID ) && _IsNonLicensedBedType( boCap.BedsType ) )
                {
                    boCap.BedsUnit = tmpBREF.BedUnit;
                    boCap.BedsType = tmpBREF.ServiceType;
                    boCap.BedsFloor = tmpBREF.BedFloor;
                    boCap.BedsRoomNumber = tmpBREF.BedRoomNumber;
                    boCap.CapacityCount = tmpBREF.CapacityCount;
                    boCap.BedsRoomSizeMet = tmpBREF.BedRoomSizeMet;
                    boCap.BedsFurnitureMet = tmpBREF.BedFurnitureMet;
                    boCap.BedsPrivacyMet = tmpBREF.BedCurtainWallMet;
                    boCap.BedsCallSystemMet = tmpBREF.BedCallSystemMet;
                    boCap.BedsComment = tmpBREF.BedComments;
                    break;
                }
            }

            NonLicensedBedDataSource = null;
        }

        protected void rgNonLicensedBedRecs_DeleteCommand( object source, GridCommandEventArgs e )
        {
            GridEditableItem editedItem = e.Item as GridEditableItem;
            string tmpUITrackID = editedItem["UITrackID"].Text;

            foreach ( BO_Capacity boCap in CurrentAppBedCapList )
            {
                if ( boCap.UI_TrackID.Equals( tmpUITrackID ) && _IsNonLicensedBedType( boCap.BedsType ) )
                {
                    boCap.Removed = true;
                    break;
                }
            }

            NonLicensedBedDataSource = null;
        }

        protected void rgNonLicensedBedRecs_PreRender( object source, EventArgs e )
        {
            LinkButton tmpInsertBtn = (LinkButton) this.FindControlRecursive( "btnNLBAddNew" );
            LinkButton tmpEditBtn = (LinkButton) this.FindControlRecursive( "btnNLBEditSelected" );
            LinkButton tmpViewBtn = (LinkButton) this.FindControlRecursive( "btnNLBViewSelected" );
            LinkButton tmpDeleteBtn = (LinkButton) this.FindControlRecursive( "btnNLBDeleteSelected" );

            if (AllowEdit)
            {
                if (null != tmpInsertBtn && null != tmpEditBtn && null != tmpViewBtn && null != tmpDeleteBtn)
                {
                    if (NonLicensedBedDataSource.Rows.Count < 1)
                    {
                        tmpInsertBtn.Visible = true;
                        tmpEditBtn.Visible = false;
                        tmpViewBtn.Visible = false;
                        tmpDeleteBtn.Visible = false;
                    }
                    else
                    {
                        tmpInsertBtn.Visible = true;
                        tmpEditBtn.Visible = true;
                        tmpViewBtn.Visible = false;
                        tmpDeleteBtn.Visible = true;
                    }
                }
            }
        }

        private void _InitializeGrid( RadGrid inGridToInit, string inGridType )
        {
            inGridToInit.AllowFilteringByColumn = false;
            inGridToInit.EnableViewState = true;
            inGridToInit.ShowHeader = true;
            inGridToInit.AllowPaging = true;
            inGridToInit.PageSize = 10;
            inGridToInit.AllowSorting = false;
            inGridToInit.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.Top;
            inGridToInit.ClientSettings.Selecting.AllowRowSelect = true;
            inGridToInit.ClientSettings.Scrolling.AllowScroll = true;
            inGridToInit.ClientSettings.Scrolling.UseStaticHeaders = true;
            inGridToInit.ClientSettings.Resizing.AllowColumnResize = true;
            inGridToInit.RegisterWithScriptManager = true;

            if ( inGridToInit.Columns.Count < 1 )
                _BuildGridColumns( inGridToInit );

            int tmpRowCnt = 0;

            switch ( inGridType )
            {
                case "Licensed":
                    //tmpRowCnt = LicensedBedDataSource.Rows.Count > 0 ? LicensedBedDataSource.Rows.Count + 2 : 3;
                    //inGridToInit.Height = Unit.Pixel( ( 26 * tmpRowCnt ) + 10 );
                    inGridToInit.DataSource = LicensedBedDataSource;
                    inGridToInit.DataBind();
                    break;
                case "NonLicensed":
                    //tmpRowCnt = NonLicensedBedDataSource.Rows.Count > 0 ? NonLicensedBedDataSource.Rows.Count + 2 : 3;
                    //inGridToInit.Height = Unit.Pixel( ( 26 * tmpRowCnt ) + 10 );
                    inGridToInit.DataSource = NonLicensedBedDataSource;
                    inGridToInit.DataBind();
                    break;
            }

        }

        private void _BuildGridColumns( RadGrid inGridToInit )
        {
            GridBoundColumn tmpCol = new GridBoundColumn();
            inGridToInit.MasterTableView.Columns.Add( tmpCol );
            tmpCol.UniqueName = "BedsType";
            tmpCol.DataField = "BedsType";
            tmpCol.HeaderText = "Service Type";
            tmpCol.Visible = true;
            //tmpCol.HeaderStyle.Width = Unit.Percentage( 18 );
            tmpCol.HeaderStyle.Width = Unit.Pixel( 200 );

            tmpCol = new GridBoundColumn();
            inGridToInit.MasterTableView.Columns.Add( tmpCol );
            tmpCol.UniqueName = "BedsUnit";
            tmpCol.DataField = "BedsUnit";
            tmpCol.HeaderText = "Location/Wing";
            tmpCol.Visible = true;
            //tmpCol.HeaderStyle.Width = Unit.Percentage( 18 );
            tmpCol.HeaderStyle.Width = Unit.Pixel( 150 );

            tmpCol = new GridBoundColumn();
            inGridToInit.MasterTableView.Columns.Add( tmpCol );
            tmpCol.UniqueName = "BedsFloor";
            tmpCol.DataField = "BedsFloor";
            tmpCol.HeaderText = "Floor";
            tmpCol.Visible = true;
            //tmpCol.HeaderStyle.Width = Unit.Percentage( 10 );
            tmpCol.HeaderStyle.Width = Unit.Pixel( 50 );

            tmpCol = new GridBoundColumn();
            inGridToInit.MasterTableView.Columns.Add( tmpCol );
            tmpCol.UniqueName = "BedsRoomNumber";
            tmpCol.DataField = "BedsRoomNumber";
            tmpCol.HeaderText = "Room Number";
            tmpCol.Visible = true;
            //tmpCol.HeaderStyle.Width = Unit.Percentage( 18 );
            tmpCol.HeaderStyle.Width = Unit.Pixel( 50 );

            tmpCol = new GridBoundColumn();
            inGridToInit.MasterTableView.Columns.Add( tmpCol );
            tmpCol.UniqueName = "CapacityCount";
            tmpCol.DataField = "CapacityCount";
            tmpCol.HeaderText = "Capacity";
            tmpCol.Visible = true;
            //tmpCol.HeaderStyle.Width = Unit.Percentage( 10 );
            tmpCol.HeaderStyle.Width = Unit.Pixel( 100 );

            tmpCol = new GridBoundColumn();
            inGridToInit.MasterTableView.Columns.Add( tmpCol );
            tmpCol.UniqueName = "BedsRoomSizeMet";
            tmpCol.DataField = "BedsRoomSizeMet";
            tmpCol.HeaderText = "Room Size Criteria Met";
            tmpCol.Visible = false;
            //col6.HeaderStyle.Width = Unit.Percentage( 10 );

            tmpCol = new GridBoundColumn();
            inGridToInit.MasterTableView.Columns.Add( tmpCol );
            tmpCol.UniqueName = "BedsCallSystemMet";
            tmpCol.DataField = "BedsCallSystemMet";
            tmpCol.HeaderText = "Call System Criteria Met";
            tmpCol.Visible = false;
            //col7.HeaderStyle.Width = Unit.Percentage( 10 );

            tmpCol = new GridBoundColumn();
            inGridToInit.MasterTableView.Columns.Add( tmpCol );
            tmpCol.UniqueName = "BedsFurnitureMet";
            tmpCol.DataField = "BedsFurnitureMet";
            tmpCol.HeaderText = "Furniture Criteria Met";
            tmpCol.Visible = false;
            //col8.HeaderStyle.Width = Unit.Percentage( 10 );

            tmpCol = new GridBoundColumn();
            inGridToInit.MasterTableView.Columns.Add( tmpCol );
            tmpCol.UniqueName = "BedsPrivacyMet";
            tmpCol.DataField = "BedsPrivacyMet";
            tmpCol.HeaderText = "Privacy Curtin or Wall Met";
            tmpCol.Visible = false;
            //col9.HeaderStyle.Width = Unit.Percentage( 10 );

            tmpCol = new GridBoundColumn();
            inGridToInit.MasterTableView.Columns.Add( tmpCol );
            tmpCol.UniqueName = "Comments";
            tmpCol.DataField = "Comments";
            tmpCol.HeaderText = "Comments";
            tmpCol.Visible = true;
            //col10.HeaderStyle.Width = Unit.Percentage( 10 );
            tmpCol.HeaderStyle.Width = Unit.Pixel( 300 );

            tmpCol = new GridBoundColumn();
            inGridToInit.MasterTableView.Columns.Add( tmpCol );
            tmpCol.UniqueName = "CapacityID";
            tmpCol.DataField = "CapacityID";
            tmpCol.HeaderText = "Internal ID for Capacity Record";
            tmpCol.Visible = false;
            //col10.HeaderStyle.Width = Unit.Percentage( 10 );

            tmpCol = new GridBoundColumn();
            inGridToInit.MasterTableView.Columns.Add( tmpCol );
            tmpCol.UniqueName = "PopsIntID";
            tmpCol.DataField = "PopsIntID";
            tmpCol.HeaderText = "Provider Internal ID";
            tmpCol.Visible = false;
            //col10.HeaderStyle.Width = Unit.Percentage( 10 );

            tmpCol = new GridBoundColumn();
            inGridToInit.MasterTableView.Columns.Add( tmpCol );
            tmpCol.UniqueName = "UITrackID";
            tmpCol.DataField = "UITrackID";
            tmpCol.HeaderText = "UITrackID";
            tmpCol.Visible = false;
        }

        #region Members Variables
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
                    if ( tmpLV.Allowedtypes.Equals( CurrentAppProvider.ProgramID ) && null != tmpLV.Extra && tmpLV.Extra.Equals( "LICENSED" ) )
                    {
                        if ( null == tmpLV.Attributes1 )//If not present then Specialty Unit not required for bed type selection
                        {
                            retLkups.Add( tmpLV );
                        }
                        else //Other wise check to see if the specialty unit is selected before adding to list
                        {
                            if ( null != CurrentAppProvider.BO_SpecialtyUnitsApplicationID )
                            {
                                foreach ( BO_SpecialtyUnit boSU in CurrentAppProvider.BO_SpecialtyUnitsApplicationID )
                                {
                                    if ( null != tmpLV.Attributes1 && boSU.TypeSpecialtyUnit.Equals( tmpLV.Attributes1 ) )
                                        retLkups.Add( tmpLV );
                                }
                            }
                        }
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
                    if ( tmpLV.Allowedtypes.Equals( CurrentAppProvider.ProgramID ) && null != tmpLV.Extra && tmpLV.Extra.Equals( "NONLICENSED" ) )
                    {
                        if ( null == tmpLV.Attributes1 )//If not present then Specialty Unit not required for bed type selection
                        {
                            retLkups.Add( tmpLV );
                        }
                        else //Other wise check to see if the specialty unit is selected before adding to list
                        {
                            if ( null != CurrentAppProvider.BO_SpecialtyUnitsApplicationID )
                            {
                                foreach ( BO_SpecialtyUnit boSU in CurrentAppProvider.BO_SpecialtyUnitsApplicationID )
                                {
                                    if ( null != tmpLV.Attributes1 && boSU.TypeSpecialtyUnit.Equals( tmpLV.Attributes1 ) )
                                        retLkups.Add( tmpLV );
                                }
                            }
                        }
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

        /// <summary>
        /// Will return capacilty list for either the main campus or an offsite location.
        /// </summary>
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

            foreach ( BO_LookupValue boLV in LicBedTypeLookups )
            {
                if ( boLV.LookupVal.Equals( inLookupVal ) )
                {
                    tmpStr = CommonFunc.ConvertToTitleCase( boLV.Valdesc );
                    break;
                }
            }

            if ( tmpStr.Equals( "" ) )
            {
                foreach ( BO_LookupValue boLV in NonLicBedTypeLookups )
                {
                    if ( boLV.LookupVal.Equals( inLookupVal ) )
                    {
                        tmpStr = CommonFunc.ConvertToTitleCase( boLV.Valdesc );
                        break;
                    }
                }
            }

            return tmpStr;
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

        private DataTable LicensedBedDataSource
        {
            get
            {
                DataTable retTable = (DataTable) ViewState["LicensedBedDataSource"];

                if ( retTable == null )
                {
                    retTable = _getBedsGridInitTable();

                    if ( CurrentAppBedCapList != null && CurrentAppBedCapList.Count > 0 )
                    {
                        foreach ( BO_Capacity boCap in CurrentAppBedCapList )
                        {
                            if ( !IsOffSite )
                            {
                                if ( !boCap.Removed && _IsLicensedBedType( boCap.BedsType ) && null == boCap.AffiliationID )
                                {
                                    DataRow tmpDR = retTable.NewRow();
                                    tmpDR["BedsType"] = _getBedTypeText( boCap.BedsType );
                                    tmpDR["BedsUnit"] = boCap.BedsUnit;
                                    tmpDR["BedsFloor"] = boCap.BedsFloor;
                                    tmpDR["BedsRoomNumber"] = boCap.BedsRoomNumber;
                                    tmpDR["CapacityCount"] = boCap.CapacityCount;
                                    tmpDR["BedsRoomSizeMet"] = ( null != boCap.BedsRoomSizeMet && boCap.BedsRoomSizeMet.Equals( "1" ) ) ? "Y" : "N";
                                    tmpDR["BedsCallSystemMet"] = ( null != boCap.BedsCallSystemMet && boCap.BedsCallSystemMet.Equals( "1" ) ) ? "Y" : "N";
                                    tmpDR["BedsFurnitureMet"] = ( null != boCap.BedsFurnitureMet && boCap.BedsFurnitureMet.Equals( "1" ) ) ? "Y" : "N";
                                    tmpDR["BedsPrivacyMet"] = ( null != boCap.BedsPrivacyMet && boCap.BedsPrivacyMet.Equals( "1" ) ) ? "Y" : "N";
                                    tmpDR["Comments"] = boCap.BedsComment;
                                    tmpDR["CapacityID"] = boCap.CapacityID;
                                    tmpDR["PopsIntID"] = boCap.PopsIntID;
                                    tmpDR["UITrackID"] = boCap.UI_TrackID;

                                    retTable.Rows.Add( tmpDR );
                                }
                            }
                            else
                            {
                                if ( !boCap.Removed && _IsLicensedBedType( boCap.BedsType ) && boCap.AffiliationID == CurrentAffiliation.AffiliationID )
                                {
                                    DataRow tmpDR = retTable.NewRow();
                                    tmpDR["BedsType"] = _getBedTypeText( boCap.BedsType );
                                    tmpDR["BedsUnit"] = boCap.BedsUnit;
                                    tmpDR["BedsFloor"] = boCap.BedsFloor;
                                    tmpDR["BedsRoomNumber"] = boCap.BedsRoomNumber;
                                    tmpDR["CapacityCount"] = boCap.CapacityCount;
                                    tmpDR["BedsRoomSizeMet"] = ( null != boCap.BedsRoomSizeMet && boCap.BedsRoomSizeMet.Equals( "1" ) ) ? "Y" : "N";
                                    tmpDR["BedsCallSystemMet"] = ( null != boCap.BedsCallSystemMet && boCap.BedsCallSystemMet.Equals( "1" ) ) ? "Y" : "N";
                                    tmpDR["BedsFurnitureMet"] = ( null != boCap.BedsFurnitureMet && boCap.BedsFurnitureMet.Equals( "1" ) ) ? "Y" : "N";
                                    tmpDR["BedsPrivacyMet"] = ( null != boCap.BedsPrivacyMet && boCap.BedsPrivacyMet.Equals( "1" ) ) ? "Y" : "N";
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
                ViewState["LicensedBedDataSource"] = value;
            }
        }

        private DataTable NonLicensedBedDataSource
        {
            get
            {
                DataTable retTable = (DataTable) ViewState["NonLicensedBedDataSource"];

                if ( retTable == null )
                {
                    retTable = _getBedsGridInitTable();

                    if ( CurrentAppBedCapList != null && CurrentAppBedCapList.Count > 0 )
                    {
                        foreach ( BO_Capacity boCap in CurrentAppBedCapList )
                        {
                            if ( !IsOffSite )
                            {
                                if ( !boCap.Removed && _IsNonLicensedBedType( boCap.BedsType ) && null == boCap.AffiliationID )
                                {
                                    DataRow tmpDR = retTable.NewRow();
                                    tmpDR["BedsType"] = _getBedTypeText( boCap.BedsType );
                                    tmpDR["BedsUnit"] = boCap.BedsUnit;
                                    tmpDR["BedsFloor"] = boCap.BedsFloor;
                                    tmpDR["BedsRoomNumber"] = boCap.BedsRoomNumber;
                                    tmpDR["CapacityCount"] = boCap.BedsRoomNumber;
                                    tmpDR["BedsRoomSizeMet"] = ( null != boCap.BedsRoomSizeMet && boCap.BedsRoomSizeMet.Equals( "1" ) ) ? "Y" : "N";
                                    tmpDR["BedsCallSystemMet"] = ( null != boCap.BedsCallSystemMet && boCap.BedsCallSystemMet.Equals( "1" ) ) ? "Y" : "N";
                                    tmpDR["BedsFurnitureMet"] = ( null != boCap.BedsFurnitureMet && boCap.BedsFurnitureMet.Equals( "1" ) ) ? "Y" : "N";
                                    tmpDR["BedsPrivacyMet"] = ( null != boCap.BedsPrivacyMet && boCap.BedsPrivacyMet.Equals( "1" ) ) ? "Y" : "N";
                                    tmpDR["Comments"] = boCap.BedsComment;
                                    tmpDR["CapacityID"] = boCap.CapacityID;
                                    tmpDR["PopsIntID"] = boCap.PopsIntID;
                                    tmpDR["UITrackID"] = boCap.UI_TrackID;

                                    retTable.Rows.Add( tmpDR );
                                }
                            }
                            else
                            {
                                if ( !boCap.Removed && _IsNonLicensedBedType( boCap.BedsType ) && boCap.AffiliationID == CurrentAffiliation.AffiliationID )
                                {
                                    DataRow tmpDR = retTable.NewRow();
                                    tmpDR["BedsType"] = _getBedTypeText( boCap.BedsType );
                                    tmpDR["BedsUnit"] = boCap.BedsUnit;
                                    tmpDR["BedsFloor"] = boCap.BedsFloor;
                                    tmpDR["BedsRoomNumber"] = boCap.BedsRoomNumber;
                                    tmpDR["CapacityCount"] = boCap.BedsRoomNumber;
                                    tmpDR["BedsRoomSizeMet"] = ( null != boCap.BedsRoomSizeMet && boCap.BedsRoomSizeMet.Equals( "1" ) ) ? "Y" : "N";
                                    tmpDR["BedsCallSystemMet"] = ( null != boCap.BedsCallSystemMet && boCap.BedsCallSystemMet.Equals( "1" ) ) ? "Y" : "N";
                                    tmpDR["BedsFurnitureMet"] = ( null != boCap.BedsFurnitureMet && boCap.BedsFurnitureMet.Equals( "1" ) ) ? "Y" : "N";
                                    tmpDR["BedsPrivacyMet"] = ( null != boCap.BedsPrivacyMet && boCap.BedsPrivacyMet.Equals( "1" ) ) ? "Y" : "N";
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
                ViewState["NonLicensedBedDataSource"] = value;
            }
        }

        #endregion

    }
}