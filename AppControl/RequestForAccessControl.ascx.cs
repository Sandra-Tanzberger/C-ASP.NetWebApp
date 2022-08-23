using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using ATG;
using ATG.BusinessObject;

namespace AppControl
{
    public partial class RequestForAccessControl : System.Web.UI.UserControl
    {
        private bool _m_PrintMode = false;
        private decimal? _m_LOI_ID = 0;
        public BO_LetterOfIntent m_LOI = null;
        private BO_Provider _m_Provider = null;
        private BO_LetterOfIntentPrimaryKey _m_LOI_PK = null;

        protected override void OnInit( EventArgs e )
        {
            base.OnInit( e );
        }

        protected void Page_Load( object sender, EventArgs e )
        {
            if ( CurrentRFA == null )
            {
                if ( m_LOI == null )
                {
                    m_LOI = new BO_LetterOfIntent();
                }
                else
                {
                    _m_LOI_PK = new BO_LetterOfIntentPrimaryKey( LOI_ID );
                    m_LOI = BO_LetterOfIntent.SelectOne( _m_LOI_PK );
                    lblTrackID.Text = LOI_ID.ToString();
                }

                CurrentRFA = m_LOI;
            }
            else
            {
                m_LOI = CurrentRFA;                
            }

            if ( !IsPostBack )
            {
                if ( !_m_PrintMode )
                    InitFieldsInputView();
                else
                    InitFieldsPrintView();
            }
        }

        public bool printMode
        {
            get
            {
                return _m_PrintMode;
            }
            set
            {
                _m_PrintMode = value;
            }
        }

        public decimal? LOI_ID
        {
            get
            {
                return _m_LOI_ID;
            }
            set
            {
                _m_LOI_ID = value;
            }
        }

        public void Load_RFA( decimal? inLOI_ID )
        {
            _m_LOI_PK = new BO_LetterOfIntentPrimaryKey( inLOI_ID );
            m_LOI = BO_LetterOfIntent.SelectOne( _m_LOI_PK );
            
            if ( null != m_LOI )
            {
                LOI_ID = m_LOI.LetterOfIntentID;
                lblTrackID.Text = LOI_ID.ToString();
                CurrentRFA = m_LOI;

                if ( m_LOI.Confirmed > 0 )
                {
                    printMode = true;
                    InitFieldsPrintView();
                }
                else
                {
                    InitFieldsInputView();
                }
            }
        }

        public void Reset_LOI()
        {
            m_LOI = new BO_LetterOfIntent();
            CurrentRFA = m_LOI;
            ErrorText.InnerHtml = "";
            ErrorText.Visible = false;
            txtConfEmail.Text = "";

            InitFieldsInputView();
        }

        public bool Save()
        {

            bool bReturn = true;
            ErrorText.InnerHtml = "";
            ErrorText.Visible = false;

            // no validation needed if no user input allowed
            if (txtAdminPersEmail.Visible) {
                //                return true;
                //            }

                if (txtAdminPersEmail.Text.ToLower() != txtConfEmail.Text.ToLower()) {
                    bReturn = false;
                    ErrorText.InnerHtml = ErrorText.InnerHtml + "Email Address and Confirm Address do not match!<br/>";
                }
                if (txtSrchStateID.Text.Length < 1) {
                    bReturn = false;
                    ErrorText.InnerHtml = ErrorText.InnerHtml + "Please enter State ID<br/>";
                }
                if (txtFacilityPhone.Text.Length < 1) {
                    bReturn = false;
                    ErrorText.InnerHtml = ErrorText.InnerHtml + "Please enter Facility Phone<br/>";
                }
                if (txtFacilityEmail.Text.Length < 1) {
                    bReturn = false;
                    ErrorText.InnerHtml = ErrorText.InnerHtml + "Please enter Facility Email<br/>";
                }
                if (txtAdminPersName.Text.Length < 1) {
                    bReturn = false;
                    ErrorText.InnerHtml = ErrorText.InnerHtml + "Please enter Administrative Person Name<br/>";
                }
                if (txtAdminPersTitle.Text.Length < 1) {
                    bReturn = false;
                    ErrorText.InnerHtml = ErrorText.InnerHtml + "Please enter Administrative Person Title<br/>";
                }
                if (txtAdminPersEmail.Text.Length < 1) {
                    bReturn = false;
                    ErrorText.InnerHtml = ErrorText.InnerHtml + "Please enter Administrative Person Email<br/>";
                }
                if (txtAdminPersPhone.Text.Length < 1) {
                    bReturn = false;
                    ErrorText.InnerHtml = ErrorText.InnerHtml + "Please enter Administrative Person Phone<br/>";
                }


                if (m_LOI.GeographicAddress == null) {
                    bReturn = false;
                    ErrorText.InnerHtml = ErrorText.InnerHtml + "Please find the State ID to populate Geographic Address<br/>";
                }
                if (m_LOI.GeographicCity == null) {
                    bReturn = false;
                    ErrorText.InnerHtml = ErrorText.InnerHtml + "Please find the State ID to populate Geographic City<br/>";
                }
                if (m_LOI.GeographicZip == null) {
                    bReturn = false;
                    ErrorText.InnerHtml = ErrorText.InnerHtml + "Please find the State ID to populate Geographic Zip<br/>";
                }
                if (m_LOI.Name == null) {
                    bReturn = false;
                    ErrorText.InnerHtml = ErrorText.InnerHtml + "Please find the State ID to populate Facility Name<br/>";
                }
            }

            if (bReturn) {
                string theid = lblTrackID.Text;

                Decimal tmpPopsIntId = 0;

                if (null != Session["ProviderPOPSINTID"] && Session["ProviderPOPSINTID"].ToString().Length > 0)
                    tmpPopsIntId = Convert.ToDecimal(Session["ProviderPOPSINTID"]);

                String tmpStateID = (String)Session["ProviderStateID"];

                //If confirmed then do not save values. They are read only but this is an extra check.
                if (m_LOI.Confirmed != 1) {
                    m_LOI.Phone = txtFacilityPhone.Text;
                    m_LOI.Email = txtFacilityEmail.Text;
                    m_LOI.AuthAdminName = txtAdminPersName.Text;
                    m_LOI.AuthAdminTitle = txtAdminPersTitle.Text;
                    m_LOI.AuthAdminEmail = txtAdminPersEmail.Text;
                    m_LOI.AuthAdminPhone = txtAdminPersPhone.Text;
                    m_LOI.LetterOfIntentType = "2";
                    m_LOI.Confirmed = 1;
                    m_LOI.ConfirmedDate = DateTime.Now;
                }

                if (null != m_LOI.LetterOfIntentID && m_LOI.LetterOfIntentID > 0)
                    m_LOI.Update();
                else {
                    m_LOI.InsertWithDefaultValues(true);
                    LOI_ID = m_LOI.LetterOfIntentID;
                }
                //}
            }
            else {
                ErrorText.Visible = true;
            }

            return bReturn;
        }

        protected void btnSrchStateID_Click( object sender, CommandEventArgs e )
        {
            if ( txtSrchStateID.Text.Length > 0 )
            {
                BO_Providers tmpPrvdrs = BO_Provider.SelectByField( "STATE_ID", txtSrchStateID.Text );
                if ( null != tmpPrvdrs )
                {
                    _m_Provider = tmpPrvdrs[0];
                }
            }

            if ( null != _m_Provider )
            {
                //Check for an existing access request form for this provider and if found then load
                // it up in read only mode.
                BO_LetterOfIntents tmpLOI = BO_LetterOfIntent.SelectAllByForeignKeyPopsIntID( new BO_ProviderPrimaryKey( _m_Provider.PopsIntID ) );

                if ( null != tmpLOI )
                {
                    m_LOI = tmpLOI[0];
                }
                else
                {
                    m_LOI.PopsIntID = _m_Provider.PopsIntID;
                    m_LOI.StateID = _m_Provider.StateID;
                    m_LOI.ProgramID = _m_Provider.ProgramID;
                    //SMM 01/22/2012 - Removed title case conversion
                    //m_LOI.Name = CommonFunc.ConvertToTitleCase( _m_Provider.FacilityName );
                    //m_LOI.GeographicAddress = CommonFunc.ConvertToTitleCase( _m_Provider.GeographicalStreet );
                    m_LOI.Name =_m_Provider.FacilityName;
                    m_LOI.GeographicAddress = _m_Provider.GeographicalStreet;
                    m_LOI.GeographicCity = CommonFunc.ConvertToTitleCase( _m_Provider.GeographicalCity );
                    m_LOI.GeographicZip = _m_Provider.GeographicalZip;
                    m_LOI.Email = _m_Provider.EmailAddress;
                    m_LOI.Phone = _m_Provider.TelephoneNumber;
                }

                if ( m_LOI.Confirmed > 0 )
                {
                    printMode = true;
                    InitFieldsPrintView();
                }
                else
                {
                    //m_LOI.Confirmed = 1;
                    //m_LOI.ConfirmedDate = DateTime.Now;
                    InitFieldsInputView();
                }

                CurrentRFA = m_LOI;
            }
        }

        private void InitFieldsInputView()
        {
            //Fill all remaining fields
            lblTrackID.Text = m_LOI.LetterOfIntentID.ToString();
            lblStateID.Text = "Enter State ID:";
            printStateID.Text = m_LOI.StateID;
            //SMM 01/22/2012 - Removed title case conversion
            //printFacilityName.Text = CommonFunc.ConvertToTitleCase( m_LOI.Name );
            //printGeoAddress.Text = CommonFunc.ConvertToTitleCase( m_LOI.GeographicAddress );
            printFacilityName.Text = m_LOI.Name;
            printGeoAddress.Text = m_LOI.GeographicAddress;
            printGeoCity.Text = CommonFunc.ConvertToTitleCase( m_LOI.GeographicCity );
            printGeoZip.Text = m_LOI.GeographicZip;
            txtFacilityEmail.Text = m_LOI.Email;
            txtFacilityPhone.Text = m_LOI.Phone;
            //SMM 01/22/2012 - Removed title case conversion
            //txtAdminPersName.Text = CommonFunc.ConvertToTitleCase( m_LOI.AuthAdminName );
            txtAdminPersName.Text = m_LOI.AuthAdminName;
            txtAdminPersPhone.Text = m_LOI.AuthAdminPhone;
            //SMM 01/22/2012 - Removed title case conversion
            //txtAdminPersTitle.Text = CommonFunc.ConvertToTitleCase( m_LOI.AuthAdminTitle );
            txtAdminPersTitle.Text = m_LOI.AuthAdminTitle;
            txtAdminPersEmail.Text = m_LOI.AuthAdminEmail;
            EnableDisableControls();
        }

        private void InitFieldsPrintView()
        {
            //Fill print Fields
            lblTrackID.Text = m_LOI.LetterOfIntentID.ToString();
            lblStateID.Text = "State ID:"; 
            printStateID.Text = m_LOI.StateID;
            //SMM 01/22/2012 - Removed title case conversion
            //printFacilityName.Text = CommonFunc.ConvertToTitleCase( m_LOI.Name );
            //printGeoAddress.Text = CommonFunc.ConvertToTitleCase( m_LOI.GeographicAddress );
            printFacilityName.Text = m_LOI.Name;
            printGeoAddress.Text = m_LOI.GeographicAddress;
            printGeoCity.Text = CommonFunc.ConvertToTitleCase( m_LOI.GeographicCity );
            printGeoZip.Text = m_LOI.GeographicZip;
            printFacilityPhone.Text = m_LOI.Phone;
            printFacilityEmail.Text = m_LOI.Email;
            //SMM 01/22/2012 - Removed title case conversion
            //printAdminPersName.Text = CommonFunc.ConvertToTitleCase( m_LOI.AuthAdminName );
            printAdminPersName.Text = m_LOI.AuthAdminName;
            //SMM 01/22/2012 - Removed title case conversion
            //printAdminPersTitle.Text = CommonFunc.ConvertToTitleCase( m_LOI.AuthAdminTitle );
            printAdminPersTitle.Text = m_LOI.AuthAdminTitle;
            printAdminPersEmail.Text = m_LOI.AuthAdminEmail;
            printAdminPersPhone.Text = m_LOI.AuthAdminPhone;
        
            EnableDisableControls();
        }

        private void EnableDisableControls()
        {
            ////Enable/Disable footers
            printSpaceTable.Visible = _m_PrintMode;
            printFootP1.Visible = _m_PrintMode;
            printFootP2.Visible = _m_PrintMode;

            txtSrchStateID.Visible = !_m_PrintMode;
            btnSrchStateID.Visible = !_m_PrintMode;
            
            printStateID.Visible = _m_PrintMode;
            printFacilityEmail.Visible = _m_PrintMode;
            printFacilityPhone.Visible = _m_PrintMode;
            printAdminPersName.Visible = _m_PrintMode;
            printAdminPersTitle.Visible = _m_PrintMode;
            printAdminPersEmail.Visible = _m_PrintMode;
            printAdminPersPhone.Visible = _m_PrintMode;

            txtFacilityEmail.Enabled = !_m_PrintMode;
            txtFacilityEmail.Visible = !_m_PrintMode;
            txtFacilityPhone.Enabled = !_m_PrintMode;
            txtFacilityPhone.Visible = !_m_PrintMode;
            txtAdminPersName.Enabled = !_m_PrintMode;
            txtAdminPersName.Visible = !_m_PrintMode;
            txtAdminPersTitle.Enabled = !_m_PrintMode;
            txtAdminPersTitle.Visible = !_m_PrintMode;
            txtAdminPersEmail.Enabled = !_m_PrintMode;
            txtAdminPersEmail.Visible = !_m_PrintMode;
            lblConfEmail.Visible = !_m_PrintMode;
            txtConfEmail.Visible = !_m_PrintMode;
            txtAdminPersPhone.Enabled = !_m_PrintMode;
            txtAdminPersPhone.Visible = !_m_PrintMode;
            
        }

        private BO_LetterOfIntent CurrentRFA
        {
            get
            {
                return this.ViewState["CurrentRFA"] == null ? null : (BO_LetterOfIntent) this.ViewState["CurrentRFA"];
            }
            set
            {
                this.ViewState["CurrentRFA"] = value;
            }
        }
    }
}