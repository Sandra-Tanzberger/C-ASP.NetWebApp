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
    public partial class OwnFacOtherEditForm : System.Web.UI.UserControl
    {
        protected void Page_Load( object sender, EventArgs e )
        {
            _LoadOwnerList();
        }

        private void _LoadOwnerList()
        {
            foreach ( BO_Ownership boOwn in CurrentAppProvider.BO_OwnershipsApplicationID )
            {
                if ( !boOwn.BO_LegalEntityDetail.Removed )
                {
                    RadComboBoxItem tmpItem = new RadComboBoxItem();
                    cboOwnerInterestList.Items.Add( tmpItem );
                    tmpItem.Value = boOwn.BO_LegalEntityDetail.UI_TrackID;
                    //SMM 01/22/2012 - Removed title case conversion
                    //tmpItem.Text = CommonFunc.ConvertToTitleCase( boOwn.BO_LegalEntityDetail.EntityName );
                    tmpItem.Text = boOwn.BO_LegalEntityDetail.EntityName;
                    cboOwnerInterestList.SelectedValue = LE_UI_TrackID;
                }
            }
        }
 
        public string FacilityName
        {
            get
            {
                return txtFacilityName.Text;
            }
            set
            {
                txtFacilityName.Text = value;
            }
        }

        public string FacilityAddress
        {
            get
            {
                return txtFacilityAddress.Text;
            }
            set
            {
                txtFacilityAddress.Text = value;
            }
        }

        public string ProviderNumber
        {
            get
            {
                return txtProviderNumber.Text;
            }
            set
            {
                txtProviderNumber.Text = value;
            }
        }

        public string StateID
        {
            get
            {
                return txtStateID.Text;
            }
            set
            {
                txtStateID.Text = value;
            }
        }

        public string OwnFacOtherProvID
        {
            get
            {
                return hiddenOwnFacOtherProvID.Value;
            }
            set
            {
                hiddenOwnFacOtherProvID.Value = value;
            }
        }

        public string OrigLE_UI_Trackid
        {
            get
            {
                return hiddenOrigLE_UI_Trackid.Value;
            }
            set
            {
                hiddenOrigLE_UI_Trackid.Value = value;
            }
        }

        public string LE_UI_TrackID
        {
            get
            {
                return cboOwnerInterestList.SelectedValue;
            }
            set
            {
                cboOwnerInterestList.SelectedValue = value;
            }
        }

        public string LegalEntityID
        {
            get
            {
                return cboOwnerInterestList.SelectedValue;
            }
            set
            {
                cboOwnerInterestList.SelectedValue = value;
            }
        }

        public bool ValidateData()
        {
            bool IsValid = true;
            string validationErrors = "";

            ErrorText.Visible = false;
            ErrorText.InnerHtml = "";

            if ( null == cboOwnerInterestList.SelectedValue.Equals("") )
            {
                validationErrors += "Owner Required<br/>";
                IsValid = false;
            }

            if ( string.IsNullOrEmpty(txtFacilityAddress.Text) )
            {
                validationErrors += "Address Required<br/>";
                IsValid = false;
            }

            if ( string.IsNullOrEmpty(txtFacilityName.Text) )
            {
                validationErrors += "Facility Name Required<br/>";
                IsValid = false;
            }
            /*
            if ( !string.IsNullOrEmpty( txtStateID.Text ) )
            {
                if ( txtStateID.Text.Length < 9 )
                {
                    validationErrors += "Invalid State ID entered<br/>";
                    IsValid = false;
                }
                else
                {
                    string tmpStrNumPart = txtStateID.Text.Substring( 2 );
                    Int64 parseRslt = 0;
                    bool IsNumber = true;

                    IsNumber = Int64.TryParse( tmpStrNumPart, out parseRslt );

                    if ( !IsNumber )
                    {
                        validationErrors += "Invalid State ID entered<br/>";
                        IsValid = false;
                    }
                }
            }
            else
            {
                validationErrors += "State ID Required<br/>";
                IsValid = false;
            }
            */
            if ( !IsValid )
            {
                // display the error message
                ErrorText.Visible = true;
                ErrorText.InnerHtml += validationErrors;
            }

            return IsValid;
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

    }
}