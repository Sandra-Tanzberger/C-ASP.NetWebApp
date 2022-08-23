using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ATG.BusinessObject;

namespace AppControl
{
    public partial class BedRecEditForm : System.Web.UI.UserControl
    {
        protected void Page_Load( object sender, EventArgs e )
        {

        }

        public void LoadBedTypes()
        {
            BO_LookupValues tmpLKUPS = null;

            DataTable tmpDT = new DataTable();
            DataRow tmpRow;

            tmpDT.Columns.Add( "LOOKUP_VAL" );
            tmpDT.Columns.Add( "VALDESC" );

            if ( IsLicensed )
                tmpLKUPS = LicBedTypeLookups;
            else
                tmpLKUPS = NonLicBedTypeLookups;

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
                return int.Parse(txtNumberBeds.Text);
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
                return ErrorText.Visible;
            }
            set
            {
                ErrorText.Visible = value;
            }
        }

        public string ValidationMessage
        {
            get
            {
                return ErrorText.InnerText;
            }
            set
            {
                ErrorText.InnerText = value;
            }
        }

        private BO_Application CurrentAppProvider
        {
            get
            {
                return Session["CurrentAppProvider"] == null ? null : (BO_Application) Session["CurrentAppProvider"];
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

        private bool _IsLicensed = false;
    }
}