using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ATG;
using ATG.BusinessObject;
using Telerik.Web.UI;

namespace AppControl
{
    public partial class OwnerEditForm : System.Web.UI.UserControl
    {
        protected void Page_Load( object sender, EventArgs e )
        {
            // Set the default value for the country to US
            if ( null == IsUSAAddress || !IsUSAAddress.Equals( "0" ) )
                IsUSAAddress = "1";

            AllowEdit = true;
            if (listState.Items.Count == 0)
            {
                _InitSelectLists();
            }

            // rjc - 07/26/2012 - when address is not US, script manager is set to fire on page startup, but
            // not all controls exist at that point. specifically, disabled telerik controls are not, and
            // when script fires, the controls are not found and script crashes. In addition, the 
            // RegisterStartupScript() had wrong parameters anyway, and failed to actually create the 
            // call to the startup script
            //if ( IsUSAAddress.Equals( "1" ) )
            //{
            //    txtOwnerCity.Enabled = false;
            //    txtOwnerCountry.Enabled = false;
            //    txtOwnerState.Enabled = false;
            //    txtOwnerZip.Enabled = false;
            //}
            //else
            //{
            //    ScriptManager.RegisterStartupScript( this, typeof(string)/*this.GetType()*/, "InitAddressDetailOther", "ToggleCityStateZip('OTHER');", true/*false*/ );
            //}
            if (IsUSAAddress.Equals( "1" )) {
                txtZipCode.Enabled = true;
                txtZipExtn.Enabled = true;
                listCity.Enabled = true;
                listCounty.Enabled = true;
                listState.Enabled = true;
                txtOwnerCountry.Enabled = false;
                txtOwnerState.Enabled = false;
                txtOwnerCity.Enabled = false;
                txtOwnerZip.Enabled = false;
            }
            else {
                txtZipCode.Enabled = false;
                txtZipExtn.Enabled = false;
                listCity.Enabled = false;
                listCounty.Enabled = false;
                listState.Enabled = false;
                txtOwnerCountry.Enabled = true;
                txtOwnerState.Enabled = true;
                txtOwnerCity.Enabled = true;
                txtOwnerZip.Enabled = true;
            }
        }

        public void _ReadOnly(bool bRO)
        {
            AllowEdit = !bRO;
            txtOwnerNameOfEntity.ReadOnly = bRO;
            txtOwnerEIN.ReadOnly = bRO;
            txtOwnerDBA.ReadOnly = bRO;
            txtOwnerPhone.ReadOnly = bRO;
            txtOwnerFax.ReadOnly = bRO;
            txtOwnerStreetAddr.ReadOnly = bRO;
            txtPercentOwnership.ReadOnly = bRO;
            optCountryUS.Enabled = !bRO;
            listState.Enabled = !bRO;
            listCity.Enabled = !bRO;
            //listZip.Enabled = !bRO;
            txtZipExtn.ReadOnly = bRO;
            listCounty.Enabled = !bRO;
            optCountryOther.Enabled = !bRO;
            txtOwnerCountry.ReadOnly = bRO;
            txtOwnerState.ReadOnly = bRO;
            txtOwnerCity.ReadOnly = bRO;
            txtOwnerZip.ReadOnly = bRO;

            if (bRO)
            {
                txtOwnerNameOfEntity.BackColor = System.Drawing.Color.LightGray;
                txtOwnerEIN.BackColor = System.Drawing.Color.LightGray;
                txtOwnerDBA.BackColor = System.Drawing.Color.LightGray;
                txtOwnerPhone.BackColor = System.Drawing.Color.LightGray;
                txtOwnerFax.BackColor = System.Drawing.Color.LightGray;
                txtOwnerStreetAddr.BackColor = System.Drawing.Color.LightGray;
                txtPercentOwnership.BackColor = System.Drawing.Color.LightGray;
                txtZipExtn.BackColor = System.Drawing.Color.LightGray;
                txtOwnerCountry.BackColor = System.Drawing.Color.LightGray;
                txtOwnerState.BackColor = System.Drawing.Color.LightGray;
                txtOwnerCity.BackColor = System.Drawing.Color.LightGray;
                txtOwnerZip.BackColor = System.Drawing.Color.LightGray;
            }
            else
            {
                txtOwnerNameOfEntity.BackColor = System.Drawing.Color.White;
                txtOwnerEIN.BackColor = System.Drawing.Color.White;
                txtOwnerDBA.BackColor = System.Drawing.Color.White;
                txtOwnerPhone.BackColor = System.Drawing.Color.White;
                txtOwnerFax.BackColor = System.Drawing.Color.White;
                txtOwnerStreetAddr.BackColor = System.Drawing.Color.White;
                txtPercentOwnership.BackColor = System.Drawing.Color.White;
                txtZipExtn.BackColor = System.Drawing.Color.White;
                txtOwnerCountry.BackColor = System.Drawing.Color.White;
                txtOwnerState.BackColor = System.Drawing.Color.White;
                txtOwnerCity.BackColor = System.Drawing.Color.White;
                txtOwnerZip.BackColor = System.Drawing.Color.White;
            }
        }

        //SMM - candidate for client side script - postback not required here
        protected void grpCountry_CheckedChanged( object sender, EventArgs e )
        {
            RadioButton tmpChkBx = (RadioButton) sender;

            if ( tmpChkBx.Text.Equals( "US" ) )
            {
                listState.Enabled = true;
                listCity.Enabled = true;
                //listZip.Enabled = true;
                txtZipExtn.Enabled = true;
                listCounty.Enabled = true;
                txtOwnerState.Enabled = false;
                txtOwnerCity.Enabled = false;
                txtOwnerZip.Enabled = false;
                txtOwnerCountry.Enabled = false;
                IsUSAAddress = "1";
            }
            else
            {
                listState.Enabled = false;
                listCity.Enabled = false;
                //listZip.Enabled = false;
                txtZipExtn.Enabled = false;
                listCounty.Enabled = false;
                txtOwnerState.Enabled = true;
                txtOwnerCity.Enabled = true;
                txtOwnerZip.Enabled = true;
                txtOwnerCountry.Enabled = true;
                IsUSAAddress = "0";
            }            
        }

        private void _InitSelectLists()
        {
            //Clear prior to loading
            listCity.Items.Clear();
            //listZip.Items.Clear();
            listCounty.Items.Clear();
            listState.Items.Clear();
            
            //listState.AppendDataBoundItems = true;
            //listState.Items.Add( new RadComboBoxItem( "", "" ) );
            ////StateLookups.Sort( "StateName" );
            ////listState.DataSource = StateLookups;
            //listState.DataSource = StateLookups;
            //listState.DataTextField = "StateName";
            //listState.DataValueField = "StateCode";
            //listState.Height = Unit.Pixel( 100 );
            //listState.DataBind();
        }

        private void _loadCityStateCountyLists( string value )
        {
            _loadCityList( value );
            _loadCountyList( value );
            _loadStateList( value );
        }

        private void _loadCityList( string value )
        {
            DataTable tmpCityTbl = CommonFunc.getCitiesByZip( value );

            listCity.ClearSelection();
            listCity.Items.Clear();
            listCity.AppendDataBoundItems = true;
            listCity.Items.Add(new RadComboBoxItem("", ""));
            //listCity.DataSource = CommonFunc.getCitiesByState( value );
            listCity.DataSource = tmpCityTbl;
            listCity.DataTextField = "City";
            listCity.DataValueField = "City";
            listCity.Height = Unit.Pixel(100);
            listCity.DataBind();

            if ( tmpCityTbl.Rows.Count == 1 )
                listCity.SelectedIndex = 1;
        }

        private void _loadCountyList(string value)
        {
            DataTable tmpCountyTbl = CommonFunc.getCountiesByZip( value );

            listCounty.ClearSelection();
            listCounty.Items.Clear();
            listCounty.AppendDataBoundItems = true;
            listCounty.Items.Add(new RadComboBoxItem("", ""));
            //listCounty.DataSource = CountyList( value );
            listCounty.DataSource = tmpCountyTbl;
            listCounty.DataTextField = BO_ZiplookupFields.Cntyname;
            listCounty.DataValueField = BO_ZiplookupFields.Cntyname;
            listCounty.Height = Unit.Pixel(100);
            listCounty.DataBind();

            if ( tmpCountyTbl.Rows.Count == 1 )
                listCounty.SelectedIndex = 1;

        }

        private void _loadStateList( string value )
        {
            DataTable tmpStateTbl = CommonFunc.getStatesByZip( value );

            listState.ClearSelection();
            listState.Items.Clear();
            listState.AppendDataBoundItems = true;
            listState.Items.Add( new RadComboBoxItem( "", "" ) );
            //listState.DataSource = StateLookups;
            listState.DataSource = tmpStateTbl;
            listState.DataTextField = "StateName";
            listState.DataValueField = "StateCode";
            listState.Height = Unit.Pixel( 100 );
            listState.DataBind();

            if ( tmpStateTbl.Rows.Count == 1 )
                listState.SelectedIndex = 1;

        }

        private void _loadZipList( string value )
        {
            //listZip.ClearSelection();
            //listZip.Items.Clear();
            //listZip.AppendDataBoundItems = true;
            //listZip.Items.Add(new RadComboBoxItem("", ""));
            //listZip.DataSource = CommonFunc.getZipByCityState( value, listState.SelectedValue );
            //listZip.DataTextField = "Zip";
            //listZip.DataValueField = "Zip";
            //listZip.Height = Unit.Pixel(100);
            //listZip.DataBind();
        }

        protected void txtZipCode_TextChanged( object sender, EventArgs e )
        {
            RadMaskedTextBox tmpTxtBox = (RadMaskedTextBox)sender;
            litInvlidZip.Visible = false;
      
            if ( !string.IsNullOrEmpty( tmpTxtBox.Text ) && tmpTxtBox.Text.Length == 5 )
            {
                DataTable tmpTbl = CommonFunc.getCitiesByZip( tmpTxtBox.Text );

                if ( tmpTbl.Rows.Count > 0 )
                {
                    _loadCityStateCountyLists( tmpTxtBox.Text );
                }
                else
                {
                    litInvlidZip.Visible = true;
                }
            }
            else
            {
                litInvlidZip.Visible = true;
            }
        }
        
        protected void listState_SelectedIndexChanged( object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e )
        {
            _loadCityList( e.Value.ToString() );
        }

        protected void listCity_SelectedIndexChanged( object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e )
        {
            _loadZipList( e.Value.ToString() );
        }

        protected void listZip_SelectedIndexChanged( object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e )
        {
            _loadCountyList(e.Value.ToString());
        }

        public void SetReadOnly()
        {
            txtOwnerNameOfEntity.Enabled = AllowEdit;
            txtOwnerDBA.Enabled = AllowEdit;
            txtOwnerEIN.Enabled = AllowEdit;
            txtOwnerPhone.Enabled = AllowEdit;
            txtOwnerFax.Enabled = AllowEdit;
            txtOwnerStreetAddr.Enabled = AllowEdit;
            txtPercentOwnership.Enabled = AllowEdit;
            optCountryOther.Enabled = AllowEdit;
            optCountryUS.Enabled = AllowEdit;
            txtOwnerZip.Enabled = AllowEdit;
            txtZipCode.Enabled = AllowEdit;
            txtZipExtn.Enabled = AllowEdit;
            txtOwnerState.Enabled = AllowEdit;
            txtOwnerCountry.Enabled = AllowEdit;
            txtOwnerCity.Enabled = AllowEdit;
            
            listCity.ShowDropDownOnTextboxClick = AllowEdit;
            listCity.ShowToggleImage = AllowEdit;
            foreach ( RadComboBoxItem radComboBoxItem in listCity.Items )
            {
                radComboBoxItem.Enabled = false;
            }

            listCounty.ShowDropDownOnTextboxClick = AllowEdit;
            listCounty.ShowToggleImage = AllowEdit;
            foreach ( RadComboBoxItem radComboBoxItem in listCounty.Items )
            {
                radComboBoxItem.Enabled = false;
            }

            listState.ShowDropDownOnTextboxClick = AllowEdit;
            listState.ShowToggleImage = AllowEdit;
            foreach ( RadComboBoxItem radComboBoxItem in listState.Items )
            {
                radComboBoxItem.Enabled = false;
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

        public String OwnerNameOfEntity
        {
            get
            {
                return txtOwnerNameOfEntity.Text;
            }
            set
            {
                txtOwnerNameOfEntity.Text = value;
            }
        }

        public String OwnerEIN
        {
            get
            {
                return txtOwnerEIN.Text;
            }
            set
            {
                txtOwnerEIN.Text = value;
            }
        }

        public String OwnerDBA
        {
            get
            {
                return txtOwnerDBA.Text;
            }
            set
            {
                txtOwnerDBA.Text = value;
            }
        }

        public String OwnerPhone
        {
            get
            {
                return txtOwnerPhone.Text;
            }
            set
            {
                txtOwnerPhone.Text = value;
            }
        }

        public String OwnerFax
        {
            get
            {
                return txtOwnerFax.Text;
            }
            set
            {
                txtOwnerFax.Text = value;
            }
        }

        public String OwnerPercent
        {
            get
            {
                return txtPercentOwnership.Text;
            }
            set
            {
                txtPercentOwnership.Text = value;
            }
        }

        public String OwnerCountry
        {
            get
            {
                return txtOwnerCountry.Text;
            }
            set
            {
                if (IsUSAAddress != "1")
                    txtOwnerCountry.Text = value;
            }
        }

        public String OwnerStreetAddr
        {
            get
            {
                return txtOwnerStreetAddr.Text;
            }
            set
            {
                txtOwnerStreetAddr.Text = value;
            }
        }

        public String OwnerCounty
        {
            get
            {
                return listCounty.SelectedValue;
            }
            set
            {
                if (IsUSAAddress == "1")
                    listCounty.SelectedValue = value;
            }
        }

        public String OwnerCity
        {
            get
            {
                if (IsUSAAddress == "1")
                    return listCity.SelectedValue;
                else
                    return txtOwnerCity.Text;
            }
            set
            {
                if (IsUSAAddress == "1")
                {
                    listCity.SelectedValue = value.ToUpper();
                    //_loadZipList(value);
                }
                else
                    txtOwnerCity.Text = value;
            }
        }

        public String OwnerState
        {
            get
            {
                if (IsUSAAddress == "1")
                    return listState.SelectedValue;
                else
                    return txtOwnerState.Text;
            }
            set
            {
                if (IsUSAAddress == "1")
                {
                    //if (listState.Items.Count == 0)
                    //{
                    //    _InitSelectLists();
                    //}

                    listState.SelectedValue = value;
                    //_loadCityList(value);
                }
                else
                    txtOwnerState.Text = value;
            }
        }

        public String OwnerZip
        {
            get
            {
                if (IsUSAAddress == "1")
                    return txtZipCode.Text; //listZip.SelectedValue;
                else
                    return txtOwnerZip.Text;
            }
            set
            {
                if (IsUSAAddress == "1")
                {
                    //listZip.SelectedValue = value;
                    //_loadCountyList(value);
                    txtZipCode.Text = value;
                    _loadCityStateCountyLists( value );
                }
                else
                    txtOwnerZip.Text = value;
            }
        }

        public String ZipExtn
        {
            get
            {
                return txtZipExtn.Text;
            }
            set
            {
                txtZipExtn.Text = value;
            }
        }

        public string IsUSAAddress
        {
            get
            {
                //return (ViewState["IsUSAAddress"] == null ? "": ViewState["IsUSAAddress"].ToString());
                if ( optCountryOther.Checked )
                    return "0";
                else 
                    return "1";
            }
            set
            {
                if (value == "1")
                {
                    optCountryOther.Checked = false;
                    optCountryUS.Checked = true;
                }
                else
                {
                    optCountryOther.Checked = true;
                    optCountryUS.Checked = false;
                }

                ViewState["IsUSAAddress"] = value;
            }
        }

        public decimal LegalEntityID
        {
            get
            {
                return Convert.ToDecimal( ViewState["LegalEntityID"] );
            }
            set
            {
                ViewState["LegalEntityID"] = value;
            }
        }

        public decimal ApplicationID
        {
            get
            {
                return Convert.ToDecimal( ViewState["ApplicationID"] );
            }
            set
            {
                ViewState["ApplicationID"] = value;
            }
        }

        public string LE_UI_TrackID
        {
            get
            {
                return (string) ViewState["LE_UI_TrackID"];
            }
            set
            {
                ViewState["LE_UI_TrackID"] = value;
            }
        }

        #region Select List Lookups
        
        private DataTable CountyList( string value )
        {
            return CommonFunc.getCountiesByZip( value );
        }

        private DataTable StateLookups
        {
            get
            {
                //BO_States tmpLkups;
                //if ( Session["StateLookups"] == null )
                //    tmpLkups = BO_State.SelectAll();
                //else
                //    tmpLkups = (BO_States) Session["StateLookups"];

                //StateLookups = tmpLkups;

                //return tmpLkups;

                DataTable retTbl = CommonFunc.getStates();
                //retTbl.DefaultView.Sort = "StateName ASC";

                return retTbl;
            }
        }

        #endregion Select List Lookups

       
    }
}