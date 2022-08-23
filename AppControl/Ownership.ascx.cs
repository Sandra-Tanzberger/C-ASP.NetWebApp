using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using ATG;
using ATG.Utilities.Data;
using ATG.BusinessObject;

namespace AppControl
{
    public partial class Ownership : System.Web.UI.UserControl
    {
        protected override void OnInit( EventArgs e )
        {
            base.OnInit( e );
            AllowEdit = true;
            _m_OwnEditForm = (OwnerEditForm) LoadControl( "~/AppControl/OwnerEditForm.ascx" );
            pnlPrimaryOwner.Controls.Add( _m_OwnEditForm );
            _m_OwnEditForm.ID = "PrimaryOwnerForm";
        }

        protected void Page_Load( object sender, EventArgs e )
        {

        }

        public void LoadApplication( string inAppID, bool inAllowEdit )
        {
            AllowEdit = inAllowEdit;

            if ( inAppID != null && CurrentAppProvider != null )
            {
                _Init();
            }
            _ShowHideFields();
        }

        private void _ShowHideFields()
        {
            AllowEdit = true;
            if (Session["userType"].ToString() == "Public")
            {
                if (CurrentAppProvider.BusinessProcessID == "3" || CurrentAppProvider.BusinessProcessID == "5" || CurrentAppProvider.BusinessProcessID == "6" || CurrentAppProvider.BusinessProcessID == "7" || CurrentAppProvider.BusinessProcessID == "8" || CurrentAppProvider.BusinessProcessID == "9" || CurrentAppProvider.BusinessProcessID == "10" || CurrentAppProvider.ApplicationStatus.Equals("4"))
                {
                    optNonProfit.Enabled = false;
                    optForProfit.Enabled = false;
                    optGovernment.Enabled = false;

                    optNonProfitTypeOwnership.Enabled = false;
                    optProfitTypeOwnership.Enabled = false;
                    optGovernmentTypeOwnership.Enabled = false;

                    //OwnerInterest.Enabled = false;
                    LinkButton tmpInsertBtn = (LinkButton)this.FindControlRecursive("btnOIAddNew");
                    LinkButton tmpEditBtn = (LinkButton)this.FindControlRecursive("btnOIEditSelected");
                    LinkButton tmpDeleteBtn = (LinkButton)this.FindControlRecursive("btnOIDeleteSelected");

                    tmpInsertBtn.Visible = false;
                    tmpEditBtn.Visible = false;
                    tmpDeleteBtn.Visible = false;

                    OtherLicFacNo.Enabled = false;
                    OtherLicFacYes.Enabled = false;

                    //OwnFacOther
                    LinkButton tmpOFOInsertBtn = (LinkButton)this.FindControlRecursive("btnOFOAddNew");
                    LinkButton tmpOFOEditBtn = (LinkButton)this.FindControlRecursive("btnOFOEditSelected");
                    LinkButton tmpOFOViewBtn = (LinkButton)this.FindControlRecursive("btnOFOViewSelected");
                    LinkButton tmpOFODeleteBtn = (LinkButton)this.FindControlRecursive("btnOFODeleteSelected");

                    tmpOFOInsertBtn.Visible = false;
                    tmpOFOEditBtn.Visible = false;
                    tmpOFOViewBtn.Visible = false;
                    tmpOFODeleteBtn.Visible = false;

                    AllowEdit = false;
                }
                else
                {
                    optNonProfit.Enabled = true;
                    optForProfit.Enabled = true;
                    optGovernment.Enabled = true;
                }

                _m_OwnEditForm._ReadOnly(!AllowEdit);
            }
        }

        public bool SaveData()
        {
            bool noSaveError = true;
            string validationErrors = "";

            ErrorText.Visible = false;
            ErrorText.InnerHtml = "";

            if(CurrentAppProvider.ProgramID.Equals("NA"))
            {
            }
            else
            {
                if ( null == CurrentOwnershipList || CurrentOwnershipList.Count < 1 )
                {
                    BO_Ownership tmpBOO = new BO_Ownership();
                    BO_LegalEntity tmpBOLE = new BO_LegalEntity();
                    BO_Address tmpBOA = new BO_Address();

                    if ( _m_OwnEditForm.OwnerNameOfEntity.Length < 1
                     || _m_OwnEditForm.OwnerDBA.Length < 1
                     //|| _m_OwnEditForm.OwnerEIN.Length < 1
                     || _m_OwnEditForm.OwnerStreetAddr.Length < 1
                     || _m_OwnEditForm.OwnerCity.Length < 1
                     || _m_OwnEditForm.OwnerState.Length < 1
                     || _m_OwnEditForm.OwnerZip.Length < 1
                     )
                    {
                        noSaveError = false;

                        if( _m_OwnEditForm.OwnerNameOfEntity.Length < 1 )
                            validationErrors += "Name of Entity is Required<br/>";
                        if ( _m_OwnEditForm.OwnerDBA.Length < 1 )
                            validationErrors += "DBA is Required for : " + _m_OwnEditForm.OwnerNameOfEntity + "<br/>";
                        //if ( _m_OwnEditForm.OwnerEIN.Length < 1 )
                        //    validationErrors += "EIN is Required for : " + _m_OwnEditForm.OwnerNameOfEntity + "<br/>";
                        if ( _m_OwnEditForm.OwnerStreetAddr.Length < 1 )
                            validationErrors += "Street Address is Required for : " + _m_OwnEditForm.OwnerNameOfEntity + "<br/>";
                        if ( _m_OwnEditForm.OwnerCity.Length < 1 )
                            validationErrors += "City is Required for : " + _m_OwnEditForm.OwnerNameOfEntity + "<br/>";
                        if ( _m_OwnEditForm.OwnerState.Length < 1 )
                            validationErrors += "State is Required for : " + _m_OwnEditForm.OwnerNameOfEntity + "<br/>";
                        if ( _m_OwnEditForm.OwnerZip.Length < 1 )
                            validationErrors += "Zip is Required for : " + _m_OwnEditForm.OwnerNameOfEntity + "<br/>";

                        if ( !optNonProfit.Checked && !optForProfit.Checked && !optGovernment.Checked )
                        {
                            validationErrors += "TypeOwnership is Required.<br/>";
                        }
                        else
                        {
                            if ( optNonProfit.Checked )
                            {
                                if ( string.IsNullOrEmpty( optNonProfitTypeOwnership.SelectedValue ) )
                                    validationErrors += "Non Profit Type Category is Required.<br/>";
                            }
                            else if ( optForProfit.Checked )
                            {
                                if ( string.IsNullOrEmpty( optProfitTypeOwnership.SelectedValue ) )
                                    validationErrors += "Profit Type Category is Required.<br/>";
                            }
                            else if ( optGovernment.Checked )
                            {
                                if ( string.IsNullOrEmpty( optGovernmentTypeOwnership.SelectedValue ) )
                                    validationErrors += "Government Type Category is Required.<br/>";
                            }
                        }

                        if ( string.IsNullOrEmpty( validationErrors ) )
                            noSaveError = true;


                    }
                    else
                    {
                        tmpBOO.IsNewRec = true;
                        tmpBOO.PopsIntID = CurrentAppProvider.PopsIntID;
                        tmpBOO.ApplicationID = CurrentAppProvider.ApplicationID;
                        tmpBOO.IsPrimary = "1";
                        tmpBOO.PercentOwnership = _m_OwnEditForm.OwnerPercent != "" ? Convert.ToInt16(_m_OwnEditForm.OwnerPercent) : 0;

                        tmpBOLE.IsNewRec = true;
                        tmpBOLE.LegalEntityID = 0;
                        tmpBOLE.EntityName = _m_OwnEditForm.OwnerNameOfEntity;
                        tmpBOLE.EntityDba = _m_OwnEditForm.OwnerDBA;
                        tmpBOLE.EntityEin = _m_OwnEditForm.OwnerEIN;
                        tmpBOLE.EntityPhone = _m_OwnEditForm.OwnerPhone;
                        tmpBOLE.EntityFax = _m_OwnEditForm.OwnerFax;

                        tmpBOA.AddressID = 0;
                        tmpBOA.Street = _m_OwnEditForm.OwnerStreetAddr;
                        tmpBOA.City = _m_OwnEditForm.OwnerCity.ToUpper();
                        tmpBOA.County = _m_OwnEditForm.OwnerCounty.ToUpper();
                        tmpBOA.State = _m_OwnEditForm.OwnerState.ToUpper();
                        tmpBOA.ZipCode = _m_OwnEditForm.OwnerZip;
                        tmpBOA.ZipCodeExtended = _m_OwnEditForm.ZipExtn;
                        tmpBOA.IsUsaAddress = _m_OwnEditForm.IsUSAAddress;
                        if (_m_OwnEditForm.IsUSAAddress == "1")
                        {
                            tmpBOA.StateCode = _m_OwnEditForm.OwnerState.ToUpper();
                            tmpBOA.Country = "USA";
                        }
                        else
                        {
                            tmpBOA.Country = _m_OwnEditForm.OwnerCountry;
                        }

                        tmpBOLE.BO_AddressDetail = tmpBOA;
                        tmpBOO.BO_LegalEntityDetail = tmpBOLE;

                        CurrentOwnershipList.Add( tmpBOO );
                    }
                }
            }

            foreach ( BO_Ownership boOwn in CurrentOwnershipList )
            {
                //Save primary ownership information current application object
                if ( boOwn.IsPrimary.Equals( "1" ) && !boOwn.Removed && !boOwn.IsNewRec )
                {
                    if ( _m_OwnEditForm.OwnerNameOfEntity.Length < 1
                        || _m_OwnEditForm.OwnerDBA.Length < 1
                        //|| _m_OwnEditForm.OwnerEIN.Length < 1
                        || _m_OwnEditForm.OwnerStreetAddr.Length < 1
                        || _m_OwnEditForm.OwnerCity.Length < 1
                        || _m_OwnEditForm.OwnerState.Length < 1
                        || _m_OwnEditForm.OwnerZip.Length < 1
                        || ( !optNonProfit.Checked && !optForProfit.Checked && !optGovernment.Checked )
                        || ( string.IsNullOrEmpty(optNonProfitTypeOwnership.SelectedValue) 
                            && string.IsNullOrEmpty( optProfitTypeOwnership.SelectedValue )
                            && string.IsNullOrEmpty(optGovernmentTypeOwnership.SelectedValue)
                            )
                        )
                    {
                        noSaveError = false;

                        if (_m_OwnEditForm.OwnerNameOfEntity.Length < 1)
                            validationErrors += "Name of Entity is Required<br/>";
                        if (_m_OwnEditForm.OwnerDBA.Length < 1)
                            validationErrors += "DBA is Required for : " + _m_OwnEditForm.OwnerNameOfEntity + "<br/>";
                        //if (_m_OwnEditForm.OwnerEIN.Length < 1)
                        //    validationErrors += "EIN is Required for : " + _m_OwnEditForm.OwnerNameOfEntity + "<br/>";
                        if (_m_OwnEditForm.OwnerStreetAddr.Length < 1)
                            validationErrors += "Street Address is Required for : " + _m_OwnEditForm.OwnerNameOfEntity + "<br/>";
                        if (_m_OwnEditForm.OwnerCity.Length < 1)
                            validationErrors += "City is Required for : " + _m_OwnEditForm.OwnerNameOfEntity + "<br/>";
                        if (_m_OwnEditForm.OwnerState.Length < 1)
                            validationErrors += "State is Required for : " + _m_OwnEditForm.OwnerNameOfEntity + "<br/>";
                        if (_m_OwnEditForm.OwnerZip.Length < 1)
                            validationErrors += "Zip is Required for : " + _m_OwnEditForm.OwnerNameOfEntity + "<br/>";

                        if ( !optNonProfit.Checked && !optForProfit.Checked && !optGovernment.Checked )
                        {
                            validationErrors += "TypeOwnership is Required.<br/>";
                        }
                        else
                        {
                            if ( optNonProfit.Checked )
                            {
                                if ( string.IsNullOrEmpty(optNonProfitTypeOwnership.SelectedValue) )
                                    validationErrors += "Non Profit Type Category is Required.<br/>";
                            }
                            else if ( optForProfit.Checked )
                            {
                                if ( string.IsNullOrEmpty( optProfitTypeOwnership.SelectedValue ) )
                                    validationErrors += "Profit Type Category is Required.<br/>";
                            }
                            else if ( optGovernment.Checked )
                            {
                                if ( string.IsNullOrEmpty(optGovernmentTypeOwnership.SelectedValue) )
                                    validationErrors += "Government Type Category is Required.<br/>";
                            }
                        }

                        if ( string.IsNullOrEmpty(validationErrors) )
                            noSaveError = true;

                    }
                    else
                    {
                        boOwn.PercentOwnership = _m_OwnEditForm.OwnerPercent != "" ? Convert.ToInt16(_m_OwnEditForm.OwnerPercent) : 0;
                        boOwn.BO_LegalEntityDetail.EntityName = _m_OwnEditForm.OwnerNameOfEntity;
                        boOwn.BO_LegalEntityDetail.EntityDba = _m_OwnEditForm.OwnerDBA;
                        boOwn.BO_LegalEntityDetail.EntityEin = _m_OwnEditForm.OwnerEIN;
                        boOwn.BO_LegalEntityDetail.EntityPhone = _m_OwnEditForm.OwnerPhone;
                        boOwn.BO_LegalEntityDetail.EntityFax = _m_OwnEditForm.OwnerFax;
                        boOwn.BO_LegalEntityDetail.BO_AddressDetail.Street = _m_OwnEditForm.OwnerStreetAddr;
                        boOwn.BO_LegalEntityDetail.BO_AddressDetail.City = _m_OwnEditForm.OwnerCity.ToUpper();
                        boOwn.BO_LegalEntityDetail.BO_AddressDetail.County = _m_OwnEditForm.OwnerCounty.ToUpper();
                        boOwn.BO_LegalEntityDetail.BO_AddressDetail.State = _m_OwnEditForm.OwnerState.ToUpper();
                        boOwn.BO_LegalEntityDetail.BO_AddressDetail.ZipCode = _m_OwnEditForm.OwnerZip;
                        boOwn.BO_LegalEntityDetail.BO_AddressDetail.ZipCodeExtended = _m_OwnEditForm.ZipExtn;
                        boOwn.BO_LegalEntityDetail.BO_AddressDetail.IsUsaAddress = _m_OwnEditForm.IsUSAAddress;
                        if (_m_OwnEditForm.IsUSAAddress == "1")
                        {
                            boOwn.BO_LegalEntityDetail.BO_AddressDetail.StateCode = _m_OwnEditForm.OwnerState.ToUpper();
                            boOwn.BO_LegalEntityDetail.BO_AddressDetail.Country = "USA";
                        }
                        else
                        {
                            boOwn.BO_LegalEntityDetail.BO_AddressDetail.Country = _m_OwnEditForm.OwnerCountry;
                        }
                    }
                }

                //Although only one value is needed for type ownership it is set on all ownership records
                if ( !boOwn.Removed && noSaveError )
                {
                    if ( optNonProfit.Checked )
                    {
                        boOwn.TypeOwnership = optNonProfitTypeOwnership.SelectedValue;
                        if (optNonProfitTypeOwnership.SelectedItem.Text.ToUpper().Trim().Equals("OTHER"))
                            boOwn.TypeOwnershipOther = txtOwnershipOtherNP.Text;
                    }
                    else if ( optForProfit.Checked )
                    {
                        boOwn.TypeOwnership = optProfitTypeOwnership.SelectedValue;
                        if (optProfitTypeOwnership.SelectedItem.Text.ToUpper().Trim().Equals("OTHER"))
                            boOwn.TypeOwnershipOther = txtOwnershipOtherFP.Text;
                    }
                    else if ( optGovernment.Checked )
                    {
                        boOwn.TypeOwnership = optGovernmentTypeOwnership.SelectedValue;
                        if (optGovernmentTypeOwnership.SelectedItem.Text.ToUpper().Trim().Equals("OTHER"))
                            boOwn.TypeOwnershipOther = txtOwnershipOtherG.Text;
                    }
                }
            }

            //noSaveError = true;
            if (!noSaveError)
            {
                // display the error message
                ErrorText.Visible = true;
                ErrorText.InnerHtml += validationErrors;
            }

            return noSaveError;
        }

        protected void OwnerInterest_NeedDataSource( object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e )
        {
            int tmpRowCnt = 0;
            if ( null != CurrentAppProvider && null != OwnerInterestDataSource )
            {
                tmpRowCnt = OwnerInterestDataSource.Rows.Count > 0 ? OwnerInterestDataSource.Rows.Count + 2 : 3;
                OwnerInterest.Height = Unit.Pixel( ( 26 * tmpRowCnt ) + 3 );
                OwnerInterest.DataSource = (DataTable) OwnerInterestDataSource;
            }
        }

        protected void OwnerInterest_ItemCreated( object sender, Telerik.Web.UI.GridItemEventArgs e )
        {
            OwnerEditForm tmpOEF = (OwnerEditForm) e.Item.FindControl( GridEditFormItem.EditFormUserControlID );

            if ( tmpOEF != null )
            {
                int tmpRowCnt = OwnerInterestDataSource.Rows.Count > 0 ? OwnerInterestDataSource.Rows.Count + 2 : 3;

                Button tmpInsertBtn = (Button) tmpOEF.FindControl( "btnInsert" );
                Button tmpUpdateBtn = (Button) tmpOEF.FindControl( "btnUpdate" );
                Button tmpCancelBtn = (Button) tmpOEF.FindControl( "btnCancel" );

                if ( tmpInsertBtn != null && tmpUpdateBtn != null )
                {
                    tmpCancelBtn.Visible = true;

                    if ( ( e.Item is GridEditFormInsertItem ) && e.Item.IsInEditMode )
                    {
                        OwnerInterest.Height = Unit.Pixel( ( 26 * tmpRowCnt ) + 250 );
                        tmpInsertBtn.Visible = true;
                        tmpUpdateBtn.Visible = false;
                    }
                    else if ( ( e.Item is GridEditableItem ) && e.Item.IsInEditMode )
                    {
                        OwnerInterest.Height = Unit.Pixel( ( 26 * tmpRowCnt ) + 250 );
                        tmpInsertBtn.Visible = false;
                        tmpUpdateBtn.Visible = true;
                    }
                }

                GridEditFormItem editedItem = e.Item as GridEditFormItem;
                //OwnerEditForm tmpOEF = (OwnerEditForm) e.Item.FindControlRecursive( GridEditFormItem.EditFormUserControlID );

                //SMM TODO - This is a hack at this point as I have been unable to find a way to determine if the cancel button
                //was clicked and abort processing on the edit form.  
                if ( !( e.Item is GridEditFormInsertItem ) && !editedItem["UITrackID"].Text.Contains( "&nbsp;" ) )
                {
                    string tmpUITrackID = editedItem["UITrackID"].Text;
                    decimal tmpApplicationID = Convert.ToDecimal( editedItem["ApplicationID"].Text );

                    foreach ( BO_Ownership boOwn in CurrentOwnershipList )
                    {
                        if ( boOwn.BO_LegalEntityDetail.UI_TrackID.Equals( tmpUITrackID ) )
                        {
                            tmpOEF.OwnerPercent = boOwn.PercentOwnership.ToString();
                            //SMM 01/22/2012 - Removed Title case conversion
                            //tmpOEF.OwnerNameOfEntity = CommonFunc.ConvertToTitleCase( boOwn.BO_LegalEntityDetail.EntityName );
                            //tmpOEF.OwnerDBA = CommonFunc.ConvertToTitleCase( boOwn.BO_LegalEntityDetail.EntityDba );
                            tmpOEF.OwnerNameOfEntity = boOwn.BO_LegalEntityDetail.EntityName;
                            tmpOEF.OwnerDBA = boOwn.BO_LegalEntityDetail.EntityDba;
                            tmpOEF.OwnerEIN = boOwn.BO_LegalEntityDetail.EntityEin;
                            tmpOEF.OwnerPhone = boOwn.BO_LegalEntityDetail.EntityPhone;
                            tmpOEF.OwnerFax = boOwn.BO_LegalEntityDetail.EntityFax;
                            tmpOEF.ApplicationID = tmpApplicationID;
                            tmpOEF.LegalEntityID = boOwn.BO_LegalEntityDetail.LegalEntityID.Value;
                            tmpOEF.LE_UI_TrackID = boOwn.BO_LegalEntityDetail.UI_TrackID;
                            //SMM 01/22/2012 - Removed Title case conversion
                            //tmpOEF.OwnerStreetAddr = boOwn.BO_LegalEntityDetail.BO_AddressDetail != null ? CommonFunc.ConvertToTitleCase( boOwn.BO_LegalEntityDetail.BO_AddressDetail.Street ) : "";
                            tmpOEF.OwnerStreetAddr = boOwn.BO_LegalEntityDetail.BO_AddressDetail != null ? boOwn.BO_LegalEntityDetail.BO_AddressDetail.Street : "";
                            tmpOEF.IsUSAAddress = boOwn.BO_LegalEntityDetail.BO_AddressDetail != null ? boOwn.BO_LegalEntityDetail.BO_AddressDetail.IsUsaAddress : "";
                            tmpOEF.OwnerState = boOwn.BO_LegalEntityDetail.BO_AddressDetail != null ? boOwn.BO_LegalEntityDetail.BO_AddressDetail.State : "";
                            tmpOEF.OwnerCity = boOwn.BO_LegalEntityDetail.BO_AddressDetail != null ? CommonFunc.ConvertToTitleCase(boOwn.BO_LegalEntityDetail.BO_AddressDetail.City) : "";
                            tmpOEF.OwnerZip = boOwn.BO_LegalEntityDetail.BO_AddressDetail != null ? boOwn.BO_LegalEntityDetail.BO_AddressDetail.ZipCode : "";
                            tmpOEF.ZipExtn = boOwn.BO_LegalEntityDetail.BO_AddressDetail != null ? boOwn.BO_LegalEntityDetail.BO_AddressDetail.ZipCodeExtended : "";
                            tmpOEF.OwnerCounty = boOwn.BO_LegalEntityDetail.BO_AddressDetail != null ? boOwn.BO_LegalEntityDetail.BO_AddressDetail.County : "";
                            tmpOEF.OwnerCountry = boOwn.BO_LegalEntityDetail.BO_AddressDetail != null ? boOwn.BO_LegalEntityDetail.BO_AddressDetail.Country : "";
                        }
                    }
                }
            }
        }

        protected void OwnerInterest_InsertCommand( object source, GridCommandEventArgs e )
        {
            GridEditableItem editedItem = e.Item as GridEditableItem;
            OwnerEditForm tmpOEF = (OwnerEditForm) e.Item.FindControl( GridEditFormItem.EditFormUserControlID );

            BO_Ownership newOwner = new BO_Ownership();
            BO_LegalEntity newLegalEntity = new BO_LegalEntity();
            BO_Address newAddress = new BO_Address();

            newOwner.PopsIntID = CurrentAppProvider.PopsIntID;
            newOwner.ApplicationID = CurrentAppProvider.ApplicationID;
            newOwner.TypeOwnership = "";
            newOwner.IsPrimary = "0";
            newOwner.UI_TrackID = "N" + OwnerInterestDataSource.Rows.Count.ToString();
            newOwner.IsNewRec = true;
            newOwner.PercentOwnership = tmpOEF.OwnerPercent != "" ? Convert.ToInt16(tmpOEF.OwnerPercent) : 0;
            
            newLegalEntity.EntityName = tmpOEF.OwnerNameOfEntity;
            newLegalEntity.EntityDba = tmpOEF.OwnerDBA;
            newLegalEntity.EntityEin = tmpOEF.OwnerEIN;
            newLegalEntity.EntityPhone = tmpOEF.OwnerPhone;
            newLegalEntity.EntityFax = tmpOEF.OwnerFax;
            newLegalEntity.LegalEntityID = 0;
            newLegalEntity.IsNewRec = true;
            newLegalEntity.UI_TrackID = "N" + OwnerInterestDataSource.Rows.Count.ToString();

            newAddress.AddressType = 1; //Physical
            newAddress.AddressID = 0;
            newAddress.Street = tmpOEF.OwnerStreetAddr;
            newAddress.City = tmpOEF.OwnerCity.ToUpper();
            newAddress.State = tmpOEF.OwnerState.ToUpper();
            newAddress.ZipCode = tmpOEF.OwnerZip;
            newAddress.ZipCodeExtended = tmpOEF.ZipExtn;
            newAddress.County = tmpOEF.OwnerCounty;
            newAddress.IsUsaAddress = tmpOEF.IsUSAAddress;
            if (tmpOEF.IsUSAAddress == "1")
            {
                newAddress.StateCode = tmpOEF.OwnerState.ToUpper();
                newAddress.Country = "USA";
            }
            else
            {
                newAddress.Country = tmpOEF.OwnerCountry;
            }

            newLegalEntity.BO_AddressDetail = newAddress;
            newOwner.BO_LegalEntityDetail = newLegalEntity;

            CurrentOwnershipList.Add( newOwner );
            
            OwnerInterestDataSource = null;

        }

        protected void OwnerInterest_UpdateCommand( object source, GridCommandEventArgs e )
        {
            GridEditableItem editedItem = e.Item as GridEditableItem;
            OwnerEditForm tmpOEF = (OwnerEditForm)e.Item.FindControl(GridEditFormItem.EditFormUserControlID);

            //We get the entire list of legal Owners here and find the one modified
            foreach (BO_Ownership boOwn in CurrentOwnershipList)
            {
                if (boOwn.BO_LegalEntityDetail.UI_TrackID.Equals(tmpOEF.LE_UI_TrackID))
                {
                    boOwn.PercentOwnership = tmpOEF.OwnerPercent != "" ? Convert.ToInt16(tmpOEF.OwnerPercent) : 0;
                    boOwn.BO_LegalEntityDetail.EntityName = tmpOEF.OwnerNameOfEntity;
                    boOwn.BO_LegalEntityDetail.EntityDba = tmpOEF.OwnerDBA;
                    boOwn.BO_LegalEntityDetail.EntityEin = tmpOEF.OwnerEIN;
                    boOwn.BO_LegalEntityDetail.EntityPhone = tmpOEF.OwnerPhone;
                    boOwn.BO_LegalEntityDetail.EntityFax = tmpOEF.OwnerFax;

                    if (boOwn.BO_LegalEntityDetail.AddressID == null)
                    {
                        BO_Address newAddress = new BO_Address();

                        newAddress.AddressType = 1; //Physical
                        newAddress.AddressID = 0;
                        newAddress.Street = tmpOEF.OwnerStreetAddr;
                        newAddress.City = tmpOEF.OwnerCity.ToUpper();
                        newAddress.State = tmpOEF.OwnerState.ToUpper();
                        newAddress.ZipCode = tmpOEF.OwnerZip;
                        newAddress.ZipCodeExtended = tmpOEF.ZipExtn;
                        newAddress.County = tmpOEF.OwnerCounty;
                        newAddress.IsUsaAddress = tmpOEF.IsUSAAddress;
                        if (tmpOEF.IsUSAAddress == "1")
                        {
                            newAddress.StateCode = tmpOEF.OwnerState.ToUpper();
                            newAddress.Country = "USA";
                        }
                        else
                        {
                            newAddress.Country = tmpOEF.OwnerCountry;
                        }

                        boOwn.BO_LegalEntityDetail.BO_AddressDetail = newAddress;            
                    }
                    else
                    {
                        boOwn.BO_LegalEntityDetail.BO_AddressDetail.Street = tmpOEF.OwnerStreetAddr;
                        boOwn.BO_LegalEntityDetail.BO_AddressDetail.City = tmpOEF.OwnerCity.ToUpper();
                        boOwn.BO_LegalEntityDetail.BO_AddressDetail.State = tmpOEF.OwnerState.ToUpper();
                        boOwn.BO_LegalEntityDetail.BO_AddressDetail.ZipCode = tmpOEF.OwnerZip;
                        boOwn.BO_LegalEntityDetail.BO_AddressDetail.ZipCodeExtended = tmpOEF.ZipExtn;
                        boOwn.BO_LegalEntityDetail.BO_AddressDetail.County = tmpOEF.OwnerCounty;
                        boOwn.BO_LegalEntityDetail.BO_AddressDetail.IsUsaAddress = tmpOEF.IsUSAAddress;
                        if (tmpOEF.IsUSAAddress == "1")
                        {
                            boOwn.BO_LegalEntityDetail.BO_AddressDetail.StateCode = tmpOEF.OwnerState.ToUpper();
                            boOwn.BO_LegalEntityDetail.BO_AddressDetail.Country = "USA";
                        }
                        else
                        {
                            boOwn.BO_LegalEntityDetail.BO_AddressDetail.Country = tmpOEF.OwnerCountry;
                        }
                    }

                }
            }

            OwnerInterestDataSource = null;
        }

        protected void OwnerInterest_DeleteCommand( object source, GridCommandEventArgs e )
        {
            GridEditableItem editedItem = e.Item as GridEditableItem;
            string tmpLegalEntityTrackID = editedItem["UITrackID"].Text;

            foreach ( BO_Ownership boOwn in CurrentOwnershipList )
            {
                if ( boOwn.BO_LegalEntityDetail.UI_TrackID.Equals( tmpLegalEntityTrackID ) )
                {
                    boOwn.Removed = true;
                    break;
                }
            }


            OwnerInterestDataSource = null;
        }

        protected void OwnerInterest_PreRender( object source, EventArgs e )
        {
            LinkButton tmpInsertBtn = (LinkButton) this.FindControlRecursive( "btnOIAddNew" );
            LinkButton tmpEditBtn = (LinkButton) this.FindControlRecursive( "btnOIEditSelected" );
            LinkButton tmpViewBtn = (LinkButton) this.FindControlRecursive( "btnOIViewSelected" );
            LinkButton tmpDeleteBtn = (LinkButton) this.FindControlRecursive( "btnOIDeleteSelected" );

            if ( null != tmpInsertBtn && null != tmpEditBtn && null != tmpViewBtn && null != tmpDeleteBtn )
            {
                if (AllowEdit)
                {
                    if (OwnerOtherFacDataSource.Rows.Count < 1)
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

        protected void OwnFacOther_NeedDataSource( object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e )
        {
            int tmpRowCnt = 0;
            if ( null != CurrentAppProvider && null != OwnerOtherFacDataSource )
            {
                tmpRowCnt = OwnerOtherFacDataSource.Rows.Count > 0 ? OwnerOtherFacDataSource.Rows.Count + 2 : 3;
                OwnFacOther.Height = Unit.Pixel( ( 26 * tmpRowCnt ) + 3 );
                OwnFacOther.DataSource = (DataTable) OwnerOtherFacDataSource;
            }
        }

        protected void OwnFacOther_ItemCreated( object sender, Telerik.Web.UI.GridItemEventArgs e )
        {
            OwnFacOtherEditForm tmpOFO = (OwnFacOtherEditForm) e.Item.FindControl( GridEditFormItem.EditFormUserControlID );

            if ( tmpOFO != null )
            {
                int tmpRowCnt = OwnerOtherFacDataSource.Rows.Count > 0 ? OwnerOtherFacDataSource.Rows.Count + 2 : 3;

                Button tmpInsertBtn = (Button) tmpOFO.FindControl( "btnInsert" );
                Button tmpUpdateBtn = (Button) tmpOFO.FindControl( "btnUpdate" );
                Button tmpCancelBtn = (Button) tmpOFO.FindControl( "btnCancel" );

                if ( tmpInsertBtn != null && tmpUpdateBtn != null )
                {
                    tmpCancelBtn.Visible = true;

                    if ( ( e.Item is GridEditFormInsertItem ) && e.Item.IsInEditMode )
                    {
                        OwnFacOther.Height = Unit.Pixel( ( 26 * tmpRowCnt ) + 175 );

                        if ( AllowEdit )
                        {
                            tmpInsertBtn.Visible = true;
                            tmpUpdateBtn.Visible = false;
                        }
                    }
                    else if ( ( e.Item is GridEditableItem ) && e.Item.IsInEditMode )
                    {
                        OwnFacOther.Height = Unit.Pixel( ( 26 * tmpRowCnt ) + 175 );

                        if ( AllowEdit )
                        {
                            tmpInsertBtn.Visible = false;
                            tmpUpdateBtn.Visible = true;
                        }
                    }
                }

                GridEditFormItem editedItem = e.Item as GridEditFormItem;

                //SMM TODO - This is a hack at this point as I have been unable to find a way to determine if the cancel button
                //was clicked and abort processing on the edit form.  
                if ( !( e.Item is GridEditFormInsertItem ) && !editedItem["LegalEntityID"].Text.Contains( "&nbsp;" ) )
                {
                    string tmpLegalEntityID = editedItem["LegalEntityID"].Text;
                    string tmpUITrackID = editedItem["UITrackID"].Text;
                    
                    foreach ( BO_LegalEntity boLE in CurrentLegalEntityList )
                    {
                        if ( boLE.UI_TrackID.Equals( tmpLegalEntityID ) )
                        {
                            foreach ( BO_OwnerOtherProvider boOOP in boLE.BO_OwnerOtherProvidersLegalEntityID )
                            {
                                if ( boOOP.UI_TrackID.Equals( tmpUITrackID ) )
                                {
                                    //SMM 01/22/2012 - Removed Title case conversion
                                    //tmpOFO.FacilityName = CommonFunc.ConvertToTitleCase( boOOP.FacilityName );
                                    tmpOFO.FacilityName = boOOP.FacilityName;
                                    tmpOFO.FacilityAddress = boOOP.FacilityAddress;
                                    tmpOFO.ProviderNumber = boOOP.ProviderNum;
                                    tmpOFO.StateID = boOOP.StateID;
                                    tmpOFO.LE_UI_TrackID = tmpLegalEntityID;
                                    tmpOFO.OrigLE_UI_Trackid = tmpLegalEntityID;
                                    tmpOFO.OwnFacOtherProvID = boOOP.UI_TrackID;
                                    break;
                                }
                            }
                        }
                    }
                }
            } 
        }

        protected void OwnFacOther_InsertCommand( object source, GridCommandEventArgs e )
        {
            GridEditableItem editedItem = e.Item as GridEditableItem;
            OwnFacOtherEditForm tmpOFO = (OwnFacOtherEditForm) e.Item.FindControl( GridEditFormItem.EditFormUserControlID );
            string tmpLegalEntityUITrackID = tmpOFO.LE_UI_TrackID;
            BO_OwnerOtherProvider tmpOOP = new BO_OwnerOtherProvider();

            if ( tmpOFO.ValidateData() )
            {
            tmpOOP.FacilityName = tmpOFO.FacilityName;
            tmpOOP.FacilityAddress = tmpOFO.FacilityAddress;
            tmpOOP.ProviderNum = tmpOFO.ProviderNumber;
            tmpOOP.StateID = tmpOFO.StateID;
            tmpOOP.IsNewRec = true;
            tmpOOP.UI_TrackID = "N" + OwnerOtherFacDataSource.Rows.Count.ToString();

            foreach ( BO_LegalEntity boLE in CurrentLegalEntityList )
            {
                if ( boLE.UI_TrackID.Equals( tmpLegalEntityUITrackID ) )
                {
                    if ( null != boLE.LegalEntityID && boLE.LegalEntityID > 0 )
                        tmpOOP.LegalEntityID = boLE.LegalEntityID;

                    boLE.BO_OwnerOtherProvidersLegalEntityID.Add( tmpOOP );
                    break;
                }
            }
            
            OwnerOtherFacDataSource = null;
            }
            else
            {
                e.Canceled = true;
            }

        }

        protected void OwnFacOther_UpdateCommand( object source, GridCommandEventArgs e )
        {
            GridEditableItem editedItem = e.Item as GridEditableItem;
            OwnFacOtherEditForm tmpOFO = (OwnFacOtherEditForm) e.Item.FindControl( GridEditFormItem.EditFormUserControlID );
            string tmpLEID = tmpOFO.LE_UI_TrackID;
            string tmpOrigLEID = tmpOFO.OrigLE_UI_Trackid;
            BO_OwnerOtherProvider tmpBO_OOP = null;

            if ( tmpOFO.ValidateData() )
            {
                foreach ( BO_LegalEntity boLE in CurrentLegalEntityList )
                {
                    if ( boLE.UI_TrackID.Equals( tmpOrigLEID ) )
                    {
                        foreach ( BO_OwnerOtherProvider bo_OOP in boLE.BO_OwnerOtherProvidersLegalEntityID )
                        {
                            if ( bo_OOP.UI_TrackID.Equals( tmpOFO.OwnFacOtherProvID ) )
                            {
                                tmpBO_OOP = bo_OOP;
                                break;
                            }
                        }
                        break;
                    }
                }

                if ( null != tmpBO_OOP )
                {
                    if ( !tmpOrigLEID.Equals( tmpLEID ) )
                    {
                        //Still update fields
                        tmpBO_OOP.FacilityName = tmpOFO.FacilityName;
                        tmpBO_OOP.FacilityAddress = tmpOFO.FacilityAddress;
                        tmpBO_OOP.ProviderNum = tmpOFO.ProviderNumber;
                        tmpBO_OOP.StateID = tmpOFO.StateID;

                        //look for the original record and mark removed
                        foreach ( BO_LegalEntity boLE in CurrentLegalEntityList )
                        {
                            if ( boLE.UI_TrackID.Equals( tmpOrigLEID ) )
                            {
                                foreach ( BO_OwnerOtherProvider boOOP in boLE.BO_OwnerOtherProvidersLegalEntityID )
                                {
                                    if ( boOOP.UI_TrackID.Equals( tmpOFO.OwnFacOtherProvID ) )
                                    {
                                        boLE.BO_OwnerOtherProvidersLegalEntityID.Remove( boOOP );
                                        break;
                                    }
                                }
                            }

                            if ( boLE.UI_TrackID.Equals( tmpLEID ) )
                            {
                                BO_OwnerOtherProvider tmpNewOOP = new BO_OwnerOtherProvider();

                                tmpNewOOP.OrigLegalEntityID = tmpBO_OOP.LegalEntityID.Value;
                                tmpNewOOP.FacilityAddress = tmpBO_OOP.FacilityAddress;
                                tmpNewOOP.FacilityName = tmpBO_OOP.FacilityName;
                                tmpNewOOP.OwnOtherProvID = tmpBO_OOP.OwnOtherProvID;
                                tmpNewOOP.ProviderNum = tmpBO_OOP.ProviderNum;
                                tmpNewOOP.StateID = tmpBO_OOP.StateID;
                                tmpNewOOP.UI_TrackID = tmpBO_OOP.UI_TrackID;

                                boLE.BO_OwnerOtherProvidersLegalEntityID.Add( tmpNewOOP );
                            }
                        }
                    }
                    else
                    {
                        tmpBO_OOP.FacilityName = tmpOFO.FacilityName;
                        tmpBO_OOP.FacilityAddress = tmpOFO.FacilityAddress;
                        tmpBO_OOP.ProviderNum = tmpOFO.ProviderNumber;
                        tmpBO_OOP.StateID = tmpOFO.StateID;
                    }
                }

                OwnerOtherFacDataSource = null;
            }
            else
            {
                e.Canceled = true;
            }

        }

        protected void OwnFacOther_DeleteCommand( object source, GridCommandEventArgs e )
        {
            GridEditableItem editedItem = e.Item as GridEditableItem;
            string tmpLE_UI_TrackID = editedItem["LegalEntityID"].Text;
            string tmpUITrackID = editedItem["UITrackID"].Text;

            foreach ( BO_LegalEntity boLE in CurrentLegalEntityList )
            {
                if ( boLE.UI_TrackID.Equals( tmpLE_UI_TrackID ) )
                {
                    foreach ( BO_OwnerOtherProvider bo_OOP in boLE.BO_OwnerOtherProvidersLegalEntityID )
                    {
                        if ( bo_OOP.UI_TrackID.Equals( tmpUITrackID ) )
                        {
                            bo_OOP.Removed = true;
                            break;
                        }
                    }
                    break;
                }
            }

            OwnerOtherFacDataSource = null;
        }

        protected void OwnFacOther_PreRender( object source, EventArgs e )
        {
            LinkButton tmpInsertBtn = (LinkButton) this.FindControlRecursive( "btnOFOAddNew" );
            LinkButton tmpEditBtn = (LinkButton) this.FindControlRecursive( "btnOFOEditSelected" );
            LinkButton tmpViewBtn = (LinkButton) this.FindControlRecursive( "btnOFOViewSelected" );
            LinkButton tmpDeleteBtn = (LinkButton) this.FindControlRecursive( "btnOFODeleteSelected" );

            if (AllowEdit)
            {
                if (null != tmpInsertBtn && null != tmpEditBtn && null != tmpViewBtn && null != tmpDeleteBtn)
                {
                    if (OwnerOtherFacDataSource.Rows.Count < 1)
                    {
                        tmpInsertBtn.Visible = true;
                        tmpEditBtn.Visible = false;
                        tmpViewBtn.Visible = false;
                        tmpDeleteBtn.Visible = false;
                    }
                }

                if (OwnFacOther.MasterTableView.Items.Count > 0)
                {
                    GridCommandItem tmpCmdEMItem = null;
                    if (OwnFacOther.MasterTableView.GetItems(GridItemType.CommandItem).Length > 0)
                    {
                        tmpCmdEMItem = (GridCommandItem)OwnFacOther.MasterTableView.GetItems(GridItemType.CommandItem)[0];
                    }

                    if (AllowEdit)
                    {
                        if (tmpCmdEMItem != null)
                        {
                            tmpInsertBtn.Visible = true;
                            tmpViewBtn.Visible = false;

                            if (OwnerOtherFacDataSource.Rows.Count > 0)
                            {
                                tmpEditBtn.Visible = true;
                                tmpDeleteBtn.Visible = true;
                            }
                            else
                            {
                                tmpEditBtn.Visible = false;
                                tmpDeleteBtn.Visible = false;
                            }
                        }
                    }
                    else
                    {
                        if (tmpCmdEMItem != null)
                        {
                            tmpInsertBtn.Visible = false;
                            tmpEditBtn.Visible = false;
                            tmpDeleteBtn.Visible = false;

                            if (OwnerOtherFacDataSource.Rows.Count > 0)
                            {
                                tmpViewBtn.Visible = true;
                            }
                            else
                            {
                                tmpViewBtn.Visible = false;
                            }

                        }
                    }
                }
            }
        }

        protected void OtherLicFacYesNo_CheckedChanged( object sender, EventArgs e )
        {
            RadioButton tmpChkBx = (RadioButton) sender;

            if ( tmpChkBx.Text.Equals( "Yes" ) )
                AllowEdit = true;
            else
                AllowEdit = false;

        }

        private void _Init()
        {
            if ( CurrentOwnershipList != null )
            {
                _InitPrimaryOwner();
                _InitializeGrid( "OwnInterest", OwnerInterest );
                _InitTypeOwnership();
                _InitializeGrid( "OwnOtherFac", OwnFacOther );
                OwnerInterest.DataBind();

                if ( OwnerOtherFacDataSource.Rows.Count > 0 )
                {
                    OtherLicFacNo.Checked = false;
                    OtherLicFacNo.Enabled = false;
                    OtherLicFacYes.Checked = true;
                    OtherLicFacYes.Enabled = false;
                    AllowEdit = true;
                }
            }
        }

        private void _InitPrimaryOwner()
        {
            foreach ( BO_Ownership boOwn in CurrentOwnershipList )
            {
                if ( boOwn.IsPrimary.Equals( "1" ) )
                {
                    //SMM 01/022/2012 - Removed title case conversion
                    //_m_OwnEditForm.OwnerNameOfEntity = CommonFunc.ConvertToTitleCase( boOwn.BO_LegalEntityDetail.EntityName );
                    //_m_OwnEditForm.OwnerDBA = CommonFunc.ConvertToTitleCase( boOwn.BO_LegalEntityDetail.EntityDba );
                    _m_OwnEditForm.OwnerNameOfEntity = boOwn.BO_LegalEntityDetail.EntityName;
                    _m_OwnEditForm.OwnerDBA = boOwn.BO_LegalEntityDetail.EntityDba;
                    _m_OwnEditForm.OwnerEIN = boOwn.BO_LegalEntityDetail.EntityEin;
                    _m_OwnEditForm.OwnerPercent = boOwn.PercentOwnership != null ? boOwn.PercentOwnership.ToString() : "";
                    _m_OwnEditForm.OwnerPhone = boOwn.BO_LegalEntityDetail.EntityPhone;
                    _m_OwnEditForm.OwnerFax = boOwn.BO_LegalEntityDetail.EntityFax;
                    //SMM 01/022/2012 - Removed title case conversion
                    //_m_OwnEditForm.OwnerStreetAddr = CommonFunc.ConvertToTitleCase( boOwn.BO_LegalEntityDetail.BO_AddressDetail.Street );
                    _m_OwnEditForm.OwnerStreetAddr = boOwn.BO_LegalEntityDetail.BO_AddressDetail.Street;
                    _m_OwnEditForm.IsUSAAddress = boOwn.BO_LegalEntityDetail.BO_AddressDetail.IsUsaAddress;
                    //SMM 01/10/2012 - The edit form was modified such that a zipcode must be entered first. This will trigger 
                    //the population of the associated city, county and state select lists 
                    _m_OwnEditForm.OwnerZip = boOwn.BO_LegalEntityDetail.BO_AddressDetail.ZipCode;
                    _m_OwnEditForm.ZipExtn = boOwn.BO_LegalEntityDetail.BO_AddressDetail.ZipCodeExtended;
                    //now set the remaing values for the above 
                    _m_OwnEditForm.OwnerState = boOwn.BO_LegalEntityDetail.BO_AddressDetail.StateCode;
                    _m_OwnEditForm.OwnerCity = CommonFunc.ConvertToTitleCase(boOwn.BO_LegalEntityDetail.BO_AddressDetail.City);
                    _m_OwnEditForm.OwnerCounty = boOwn.BO_LegalEntityDetail.BO_AddressDetail.County;

                    _m_OwnEditForm.OwnerCountry = boOwn.BO_LegalEntityDetail.BO_AddressDetail.Country;
                    break;
                }
            }

            if ( !AllowEdit )
            {
                _m_OwnEditForm.AllowEdit = false;
                _m_OwnEditForm.SetReadOnly();
            }
        }

        private void _InitTypeOwnership()
        {
            optNonProfitTypeOwnership.Font.Size = FontUnit.Point( 8 );
            optNonProfitTypeOwnership.Width = Unit.Percentage( 100 );
            optNonProfitTypeOwnership.Style.Add( HtmlTextWriterStyle.MarginLeft, "10px" );
            
            if ( optNonProfitTypeOwnership.Items.Count < 1
                || optProfitTypeOwnership.Items.Count < 1
                || optGovernmentTypeOwnership.Items.Count < 1 )
            {
                TypeOwnership.Sort( "Sortbyvalue" );

                foreach ( BO_LookupValue bolkup in TypeOwnership )
                {
                    ListItem tmpItm = new ListItem();
                    if ( bolkup.LookupVal.Substring( 0, 1 ).Equals( "N" ) )
                    {
                        tmpItm.Text = bolkup.Valdesc;
                        tmpItm.Value = bolkup.LookupVal;
                        optNonProfitTypeOwnership.Items.Add( tmpItm );
                    }
                    if ( bolkup.LookupVal.Substring( 0, 1 ).Equals( "P" ) )
                    {
                        tmpItm.Text = bolkup.Valdesc;
                        tmpItm.Value = bolkup.LookupVal;
                        optProfitTypeOwnership.Items.Add( tmpItm );
                    }
                    if ( bolkup.LookupVal.Substring( 0, 1 ).Equals( "G" ) )
                    {
                        tmpItm.Text = bolkup.Valdesc;
                        tmpItm.Value = bolkup.LookupVal;
                        optGovernmentTypeOwnership.Items.Add( tmpItm );
                    }

                }
            }

            bool isOwnershipOtherValueSet = false;

            foreach ( BO_Ownership boOwn in CurrentOwnershipList )
            {
                if ( boOwn.IsPrimary.Equals( "1" ) && !boOwn.Removed && null != boOwn.TypeOwnership )
                {
                    string tmpOwnTypeCateg = boOwn.TypeOwnership.Substring( 0, 1 );

                    switch ( tmpOwnTypeCateg )
                    {
                        case "N":
                            optNonProfitTypeOwnership.Enabled = true;
                            optNonProfitTypeOwnership.SelectedValue = boOwn.TypeOwnership;
                            optNonProfit.Checked = true;
                            if (optNonProfitTypeOwnership.SelectedItem.Text.ToUpper().Trim().Equals("OTHER"))
                            {
                                isOwnershipOtherValueSet = true;
                                txtOwnershipOtherNP.Text = boOwn.TypeOwnershipOther;
                                txtOwnershipOtherFP.Enabled = false;
                                txtOwnershipOtherG.Enabled = false;
                            }
                            break;
                        case "P":
                            optProfitTypeOwnership.Enabled = true;
                            optProfitTypeOwnership.SelectedValue = boOwn.TypeOwnership;
                            optForProfit.Checked = true;
                            if (optProfitTypeOwnership.SelectedItem.Text.ToUpper().Trim().Equals("OTHER"))
                            {
                                isOwnershipOtherValueSet = true;
                                txtOwnershipOtherFP.Text = boOwn.TypeOwnershipOther;
                                txtOwnershipOtherNP.Enabled = false;
                                txtOwnershipOtherG.Enabled = false;
                            }
                            break;
                        case "G":
                            optGovernmentTypeOwnership.Enabled = true;
                            optGovernmentTypeOwnership.SelectedValue = boOwn.TypeOwnership;
                            optGovernment.Checked = true;
                            if (optGovernmentTypeOwnership.SelectedItem.Text.ToUpper().Trim().Equals("OTHER"))
                            {
                                isOwnershipOtherValueSet = true;
                                txtOwnershipOtherG.Text = boOwn.TypeOwnershipOther;
                                txtOwnershipOtherNP.Enabled = false;
                                txtOwnershipOtherFP.Enabled = false;
                            }
                            break;
                    }
                }
            }

            //if ( ( "PM" ).Contains( CurrentAppProvider.ProgramID ) )
            if (("PM,BO").Contains(CurrentAppProvider.ProgramID)) {
                optGovernment.Visible = false;
                optGovernmentTypeOwnership.Visible = false;
                txtOwnershipOtherG.Visible = false;
            }

            if ( !isOwnershipOtherValueSet )
            {
                txtOwnershipOtherNP.Enabled = false;
                txtOwnershipOtherFP.Enabled = false;
                txtOwnershipOtherG.Enabled = false;
            }

            if ( !AllowEdit )
            {
                optNonProfit.Enabled = false;
                optNonProfitTypeOwnership.Enabled = false;
                optForProfit.Enabled = false;
                optProfitTypeOwnership.Enabled = false;
                optGovernment.Enabled = false;
                optGovernmentTypeOwnership.Enabled = false;

                OtherLicFacNo.Enabled = false;
                OtherLicFacYes.Enabled = false;
            }
        }

        private void _InitializeGrid( String inGridType, RadGrid inGridToInit )
        {
            inGridToInit.AllowFilteringByColumn = false;
            inGridToInit.EnableViewState = true;
            inGridToInit.AllowPaging = true;
            inGridToInit.AllowSorting = true;
            inGridToInit.GridLines = GridLines.Both;
            inGridToInit.PageSize = 10;
            
            if ( AllowEdit )
                inGridToInit.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.Top;
            else
                inGridToInit.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;

            inGridToInit.MasterTableView.EnableViewState = true;
            inGridToInit.ClientSettings.Selecting.AllowRowSelect = true;
            inGridToInit.ClientSettings.Scrolling.AllowScroll = true;
            inGridToInit.ClientSettings.Scrolling.UseStaticHeaders = true;
            inGridToInit.ClientSettings.Resizing.AllowColumnResize = true;
            inGridToInit.RegisterWithScriptManager = true;

            if ( inGridToInit.Columns.Count < 1 )
                _BuildGridColumns( inGridType );

            int tmpRowCnt = 0;
            GridSortExpression tmpSrtExp = new GridSortExpression();

            switch ( inGridType )
            {
                case "OwnInterest":
                    tmpRowCnt = OwnerInterestDataSource.Rows.Count > 0 ? OwnerInterestDataSource.Rows.Count + 2 : 3;
                    inGridToInit.Height = Unit.Pixel( ( 26 * tmpRowCnt ) + 10 );
                    inGridToInit.DataSource = OwnerInterestDataSource;
                    break;
                case "OwnOtherFac":
                    tmpRowCnt = OwnerOtherFacDataSource.Rows.Count > 0 ? OwnerOtherFacDataSource.Rows.Count + 2 : 3;
                    inGridToInit.Height = Unit.Pixel( ( 26 * tmpRowCnt ) + 10 );
                    inGridToInit.DataSource = OwnerOtherFacDataSource;
                    tmpSrtExp.FieldName = "LegalEntity";
                    tmpSrtExp.SortOrder = GridSortOrder.Ascending;
                    inGridToInit.MasterTableView.SortExpressions.AddSortExpression( tmpSrtExp ); 
                    inGridToInit.DataBind();
                    break;
                default:
                    break;
            }

        }

        private void _BuildGridColumns( String inGridType )
        {
            GridBoundColumn tmpCol = null;

            switch ( inGridType )
            {
                case "OwnInterest":
                    tmpCol = new GridBoundColumn();
                    OwnerInterest.MasterTableView.Columns.Add( tmpCol );
                    tmpCol.UniqueName = "PercentOwnership";
                    tmpCol.DataField = "PercentOwnership";
                    tmpCol.HeaderText = "Percent";
                    tmpCol.Visible = true;
                    tmpCol.HeaderStyle.Width = Unit.Pixel( 150 );
                    tmpCol.DataFormatString = "<nobr>{0}</nobr>&nbsp;";

                    tmpCol = new GridBoundColumn();
                    OwnerInterest.MasterTableView.Columns.Add( tmpCol );
                    tmpCol.UniqueName = "EntityName";
                    tmpCol.DataField = "EntityName";
                    tmpCol.HeaderText = "Name";
                    tmpCol.Visible = true;
                    tmpCol.HeaderStyle.Width = Unit.Pixel( 150 );
                    tmpCol.DataFormatString = "<nobr>{0}</nobr>&nbsp;";

                    tmpCol = new GridBoundColumn();
                    OwnerInterest.MasterTableView.Columns.Add( tmpCol );
                    tmpCol.UniqueName = "Street";
                    tmpCol.DataField = "Street";
                    tmpCol.HeaderText = "Street";
                    tmpCol.Visible = true;
                    tmpCol.HeaderStyle.Width = Unit.Pixel( 200 );
                    tmpCol.DataFormatString = "<nobr>{0}</nobr>&nbsp;";

                    tmpCol = new GridBoundColumn();
                    OwnerInterest.MasterTableView.Columns.Add( tmpCol );
                    tmpCol.UniqueName = "City";
                    tmpCol.DataField = "City";
                    tmpCol.HeaderText = "City";
                    tmpCol.Visible = true;
                    tmpCol.HeaderStyle.Width = Unit.Pixel( 70 );
                    tmpCol.DataFormatString = "<nobr>{0}</nobr>&nbsp;";

                    tmpCol = new GridBoundColumn();
                    OwnerInterest.MasterTableView.Columns.Add( tmpCol );
                    tmpCol.UniqueName = "State";
                    tmpCol.DataField = "State";
                    tmpCol.HeaderText = "State";
                    tmpCol.Visible = true;
                    tmpCol.HeaderStyle.Width = Unit.Pixel( 25 );
                    tmpCol.DataFormatString = "<nobr>{0}</nobr>&nbsp;";

                    tmpCol = new GridBoundColumn();
                    OwnerInterest.MasterTableView.Columns.Add( tmpCol );
                    tmpCol.UniqueName = "Zip";
                    tmpCol.DataField = "Zip";
                    tmpCol.HeaderText = "Zip";
                    tmpCol.Visible = true;
                    tmpCol.HeaderStyle.Width = Unit.Pixel( 50 );
                    tmpCol.DataFormatString = "<nobr>{0}</nobr>&nbsp;";

                    tmpCol = new GridBoundColumn();
                    OwnerInterest.MasterTableView.Columns.Add( tmpCol );
                    tmpCol.UniqueName = "Phone";
                    tmpCol.DataField = "Phone";
                    tmpCol.HeaderText = "Phone";
                    tmpCol.Visible = true;
                    tmpCol.HeaderStyle.Width = Unit.Pixel( 60 );
                    tmpCol.DataFormatString = "<nobr>{0}</nobr>&nbsp;";

                    tmpCol = new GridBoundColumn();
                    OwnerInterest.MasterTableView.Columns.Add( tmpCol );
                    tmpCol.UniqueName = "Ein";
                    tmpCol.DataField = "Ein";
                    tmpCol.HeaderText = "EIN";
                    tmpCol.Visible = true;
                    tmpCol.HeaderStyle.Width = Unit.Pixel( 50 );
                    tmpCol.DataFormatString = "<nobr>{0}</nobr>&nbsp;";

                    tmpCol = new GridBoundColumn();
                    OwnerInterest.MasterTableView.Columns.Add( tmpCol );
                    tmpCol.UniqueName = "PopsIntID";
                    tmpCol.DataField = "PopsIntID";
                    tmpCol.HeaderText = "Pops Internal Id";
                    tmpCol.Visible = false;

                    tmpCol = new GridBoundColumn();
                    OwnerInterest.MasterTableView.Columns.Add( tmpCol );
                    tmpCol.UniqueName = "ApplicationID";
                    tmpCol.DataField = "ApplicationID";
                    tmpCol.HeaderText = "Application Id";
                    tmpCol.Visible = false;

                    tmpCol = new GridBoundColumn();
                    OwnerInterest.MasterTableView.Columns.Add( tmpCol );
                    tmpCol.UniqueName = "LegalEntityID";
                    tmpCol.DataField = "LegalEntityID";
                    tmpCol.HeaderText = "Legal Entity Id";
                    tmpCol.Visible = false;

                    tmpCol = new GridBoundColumn();
                    OwnerInterest.MasterTableView.Columns.Add( tmpCol );
                    tmpCol.UniqueName = "UITrackID";
                    tmpCol.DataField = "UITrackID";
                    tmpCol.HeaderText = "Row Tracking ID";
                    tmpCol.Visible = false; 
                    break;

                case "OwnOtherFac":
                    tmpCol = new GridBoundColumn();
                    OwnFacOther.MasterTableView.Columns.Add( tmpCol );
                    tmpCol.UniqueName = "LegalEntity";
                    tmpCol.DataField = "LegalEntity";
                    tmpCol.HeaderText = "Owner";
                    tmpCol.DataFormatString = "<nobr>{0}</nobr>&nbsp;";
                    tmpCol.Visible = true;

                    tmpCol = new GridBoundColumn();
                    OwnFacOther.MasterTableView.Columns.Add( tmpCol );
                    tmpCol.UniqueName = "FacilityName";
                    tmpCol.DataField = "FacilityName";
                    tmpCol.HeaderText = "Facility Name";
                    tmpCol.DataFormatString = "<nobr>{0}</nobr>&nbsp;";
                    tmpCol.Visible = true;

                    tmpCol = new GridBoundColumn();
                    OwnFacOther.MasterTableView.Columns.Add( tmpCol );
                    tmpCol.UniqueName = "FacilityAddress";
                    tmpCol.DataField = "FacilityAddress";
                    tmpCol.HeaderText = "Facility Address";
                    tmpCol.DataFormatString = "<nobr>{0}</nobr>&nbsp;";
                    tmpCol.Visible = true;

                    tmpCol = new GridBoundColumn();
                    OwnFacOther.MasterTableView.Columns.Add( tmpCol );
                    tmpCol.UniqueName = "ProviderNumber";
                    tmpCol.DataField = "ProviderNumber";
                    tmpCol.HeaderText = "Provider Number";
                    tmpCol.DataFormatString = "<nobr>{0}</nobr>&nbsp;";
                    tmpCol.Visible = true;

                    tmpCol = new GridBoundColumn();
                    OwnFacOther.MasterTableView.Columns.Add( tmpCol );
                    tmpCol.UniqueName = "StateID";
                    tmpCol.DataField = "StateID";
                    tmpCol.HeaderText = "State ID";
                    tmpCol.DataFormatString = "<nobr>{0}</nobr>&nbsp;";
                    tmpCol.Visible = true;

                    tmpCol = new GridBoundColumn();
                    OwnFacOther.MasterTableView.Columns.Add( tmpCol );
                    tmpCol.UniqueName = "OwnOtherProvID";
                    tmpCol.DataField = "OwnOtherProvID";
                    tmpCol.HeaderText = "OwnOtherProvID";
                    tmpCol.Visible = false;

                    tmpCol = new GridBoundColumn();
                    OwnFacOther.MasterTableView.Columns.Add( tmpCol );
                    tmpCol.UniqueName = "LegalEntityID";
                    tmpCol.DataField = "LegalEntityID";
                    tmpCol.HeaderText = "Legal Entity Id";
                    tmpCol.Visible = false;

                    tmpCol = new GridBoundColumn();
                    OwnFacOther.MasterTableView.Columns.Add( tmpCol );
                    tmpCol.UniqueName = "UITrackID";
                    tmpCol.DataField = "UITrackID";
                    tmpCol.HeaderText = "Row Tracking ID";
                    tmpCol.Visible = false;
                    break;
                default:
                    break;
            }

        }

        private DataTable _getOwnIntDataTable()
        {
            DataTable tmpDTbl = new DataTable();
            DataColumn tmpDCol = null;

            tmpDCol = new DataColumn( "PercentOwnership" );
            tmpDTbl.Columns.Add( tmpDCol );
            tmpDCol = new DataColumn( "EntityName" );
            tmpDTbl.Columns.Add( tmpDCol );
            tmpDCol = new DataColumn( "Street" );
            tmpDTbl.Columns.Add( tmpDCol );
            tmpDCol = new DataColumn( "City" );
            tmpDTbl.Columns.Add( tmpDCol );
            tmpDCol = new DataColumn( "State" );
            tmpDTbl.Columns.Add( tmpDCol );
            tmpDCol = new DataColumn( "Zip" );
            tmpDTbl.Columns.Add( tmpDCol );
            tmpDCol = new DataColumn( "Phone" );
            tmpDTbl.Columns.Add( tmpDCol );
            tmpDCol = new DataColumn( "Ein" );
            tmpDTbl.Columns.Add( tmpDCol );
            tmpDCol = new DataColumn( "PopsIntID" );
            tmpDTbl.Columns.Add( tmpDCol );
            tmpDCol = new DataColumn( "ApplicationID" );
            tmpDTbl.Columns.Add( tmpDCol );
            tmpDCol = new DataColumn( "LegalEntityID" );
            tmpDTbl.Columns.Add( tmpDCol );
            tmpDCol = new DataColumn( "UITrackID" );
            tmpDTbl.Columns.Add( tmpDCol );

            return tmpDTbl;
        }

        private DataTable _getOwnFacOtherDataTable()
        {
            DataTable tmpDTbl = new DataTable();
            DataColumn tmpDCol = null;

            tmpDCol = new DataColumn( "LegalEntity" );
            tmpDTbl.Columns.Add( tmpDCol );
            tmpDCol = new DataColumn( "FacilityName" );
            tmpDTbl.Columns.Add( tmpDCol );
            tmpDCol = new DataColumn( "FacilityAddress" );
            tmpDTbl.Columns.Add( tmpDCol );
            tmpDCol = new DataColumn( "ProviderNumber" );
            tmpDTbl.Columns.Add( tmpDCol );
            tmpDCol = new DataColumn( "StateID" );
            tmpDTbl.Columns.Add( tmpDCol );
            tmpDCol = new DataColumn( "OwnOtherProvID" );
            tmpDTbl.Columns.Add( tmpDCol );
            tmpDCol = new DataColumn( "LegalEntityID" );
            tmpDTbl.Columns.Add( tmpDCol );
            tmpDCol = new DataColumn( "UITrackID" );
            tmpDTbl.Columns.Add( tmpDCol );

            return tmpDTbl;
        }

        private string _getLookupValText( string inLookupVal )
        {
            string tmpStr = inLookupVal;

            foreach ( BO_LookupValue boLkup in TypeOwnership )
            {
                if ( boLkup.LookupVal.Equals( inLookupVal ) )
                    return boLkup.Valdesc;
            }

            return tmpStr;
        }

        #region Members
        private OwnerEditForm _m_OwnEditForm = null;

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

        private BO_LookupValues TypeOwnership
        {
            get
            {
                BO_LookupValues retLkups = new BO_LookupValues();
                if ( Session["TypeOwnership"] == null )
                {
                    BO_LookupValues tmpLkups = BO_LookupValue.SelectByField( BO_LookupValueFields.LookupKey, "TYPE_OWNERSHIP" );
                    foreach ( BO_LookupValue tmpLV in tmpLkups )
                    {
                        if ( tmpLV.Allowedtypes.Contains( CurrentAppProvider.ProgramID ) || tmpLV.Allowedtypes.Equals( "" ) )
                            retLkups.Add( tmpLV );
                    }
                }
                else
                    retLkups = (BO_LookupValues) Session["TypeOwnership"];

                TypeOwnership = retLkups;

                return retLkups;
            }
            set
            {
                Session["TypeOwnership"] = value;
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

        private BO_Ownerships CurrentOwnershipList
        {
            get
            {
                BO_Ownerships tmpList;

                if ( CurrentAppProvider != null && CurrentAppProvider.BO_OwnershipsApplicationID != null )
                {
                    tmpList = CurrentAppProvider.BO_OwnershipsApplicationID;
                }
                else
                {
                    tmpList = new BO_Ownerships();
                }
                return tmpList;
            }
            set
            {
                CurrentAppProvider.BO_OwnershipsApplicationID = value;
            }

        }

        private BO_LegalEntities CurrentLegalEntityList
        {
            get
            {
                BO_LegalEntities tmpList = new BO_LegalEntities();

                if ( CurrentAppProvider != null && CurrentAppProvider.BO_OwnershipsApplicationID != null )
                {
                    foreach ( BO_Ownership boOwnShip in CurrentAppProvider.BO_OwnershipsApplicationID )
                    {
                        tmpList.Add( boOwnShip.BO_LegalEntityDetail );
                    }
                }

                return tmpList;
            }
        }

        private BO_Addresses CurrentLegalEntityAddressList
        {
            get
            {
                BO_Addresses tmpList = new BO_Addresses();

                if ( CurrentAppProvider != null && CurrentAppProvider.BO_OwnershipsApplicationID != null )
                {
                    foreach( BO_LegalEntity boLE in CurrentLegalEntityList )
                    {
                        tmpList.Add( boLE.BO_AddressDetail );
                    }
                }

                return tmpList;
            }
        }

        private DataTable OwnerInterestDataSource
        {
            get
            {
                DataTable retTable = (DataTable) ViewState["OwnerInterestDataSource"];
 
                if ( retTable == null )
                {
                    retTable = _getOwnIntDataTable();

                    if ( null != CurrentAppProvider && CurrentAppProvider.BO_OwnershipsApplicationID.Count > 0 )
                    {
                        foreach ( BO_Ownership boOwn in CurrentOwnershipList )
                        {
                            if ( boOwn.IsPrimary.Equals( "0" ) && !boOwn.Removed )
                            {
                                DataRow tmpDR = retTable.NewRow();
                                tmpDR["PopsIntID"] = boOwn.PopsIntID.ToString();
                                tmpDR["ApplicationID"] = boOwn.ApplicationID.ToString();
                                tmpDR["LegalEntityID"] = boOwn.BO_LegalEntityDetail.LegalEntityID.ToString();
                                tmpDR["PercentOwnership"] = boOwn.PercentOwnership != null ? boOwn.PercentOwnership.ToString() : "";
                                //SMM 01/022/2012 - Removed title case conversion
                                //tmpDR["EntityName"] = CommonFunc.ConvertToTitleCase( boOwn.BO_LegalEntityDetail.EntityName );
                                tmpDR["EntityName"] = boOwn.BO_LegalEntityDetail.EntityName;
                                tmpDR["Ein"] = boOwn.BO_LegalEntityDetail.EntityEin;
                                tmpDR["Phone"] = boOwn.BO_LegalEntityDetail.EntityPhone;
                                
                                if ( null != boOwn.BO_LegalEntityDetail.BO_AddressDetail )
                                {
                                    //SMM 01/022/2012 - Removed title case conversion
                                    //tmpDR["Street"] = CommonFunc.ConvertToTitleCase( boOwn.BO_LegalEntityDetail.BO_AddressDetail.Street );
                                    tmpDR["Street"] = boOwn.BO_LegalEntityDetail.BO_AddressDetail.Street;
                                    tmpDR["City"] = CommonFunc.ConvertToTitleCase( boOwn.BO_LegalEntityDetail.BO_AddressDetail.City );
                                    tmpDR["State"] = boOwn.BO_LegalEntityDetail.BO_AddressDetail.State;
                                    tmpDR["Zip"] = boOwn.BO_LegalEntityDetail.BO_AddressDetail.ZipCode;
                                }
                                
                                tmpDR["UITrackID"] = boOwn.BO_LegalEntityDetail.UI_TrackID;

                                retTable.Rows.Add( tmpDR );
                            }
                        }
                    }
                }
                
                OwnerInterestDataSource = retTable;
                return retTable;
            }
            set
            {
                ViewState["OwnerInterestDataSource"] = value;
            }
        }

        private DataTable OwnerOtherFacDataSource
        {
            get
            {
                DataTable retTable = (DataTable) ViewState["OwnerOtherFacDataSource"];

                if ( retTable == null )
                {
                    retTable = _getOwnFacOtherDataTable();

                    if ( null != CurrentAppProvider && CurrentAppProvider.BO_OwnershipsApplicationID.Count > 0 )
                    {
                        foreach ( BO_Ownership boOW in CurrentAppProvider.BO_OwnershipsApplicationID )
                        {
                            if ( !boOW.Removed )
                            {
                                foreach ( BO_OwnerOtherProvider boOOP in boOW.BO_LegalEntityDetail.BO_OwnerOtherProvidersLegalEntityID )
                                {
                                    if ( !boOOP.Removed )
                                    {
                                        DataRow tmpDR = retTable.NewRow();
                                        //SMM 01/22/2012 - Removed title case conversion
                                        //tmpDR["LegalEntity"] = CommonFunc.ConvertToTitleCase( boOW.BO_LegalEntityDetail.EntityName );
                                        //tmpDR["FacilityName"] = CommonFunc.ConvertToTitleCase( boOOP.FacilityName );
                                        //tmpDR["FacilityAddress"] = CommonFunc.ConvertToTitleCase( boOOP.FacilityAddress );
                                        tmpDR["LegalEntity"] = boOW.BO_LegalEntityDetail.EntityName;
                                        tmpDR["FacilityName"] = boOOP.FacilityName;
                                        tmpDR["FacilityAddress"] = boOOP.FacilityAddress;
                                        tmpDR["ProviderNumber"] = boOOP.ProviderNum;
                                        tmpDR["StateID"] = boOOP.StateID;
                                        tmpDR["OwnOtherProvID"] = boOOP.OwnOtherProvID.ToString();
                                        tmpDR["LegalEntityID"] = boOW.BO_LegalEntityDetail.UI_TrackID;
                                        tmpDR["UITrackID"] = boOOP.UI_TrackID;

                                        retTable.Rows.Add( tmpDR );
                                    }
                                }
                            }
                        }
                    }
                }
                
                return retTable;
            }
            set
            {
                ViewState["OwnerOtherFacDataSource"] = value;
            }
        }

        #endregion
    }
}