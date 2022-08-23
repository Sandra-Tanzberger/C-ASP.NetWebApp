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
    public partial class LetterOfIntentControl : System.Web.UI.UserControl
    {
        private bool _m_PrintMode = false;
        private decimal? _m_LOI_ID = 0;
        public BO_LetterOfIntent m_LOI = null;
        private BO_LetterOfIntentPrimaryKey _m_LOI_PK = null;

        protected override void OnInit( EventArgs e )
        {
            base.OnInit( e );
        }

        protected void Page_Load( object sender, EventArgs e )
        {
            if ( CurrentLOI == null )
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

                CurrentLOI = m_LOI;
                
                //if ( !_m_PrintMode )
                //    InitFieldsInputView();
                //else
                //    InitFieldsPrintView();
            }
            else
            {
                m_LOI = CurrentLOI;                
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

        public void Load_LOI( decimal? inLOI_ID )
        {
            _m_LOI_PK = new BO_LetterOfIntentPrimaryKey( inLOI_ID );
            m_LOI = BO_LetterOfIntent.SelectOne( _m_LOI_PK );
            
            if ( null != m_LOI )
            {
                LOI_ID = m_LOI.LetterOfIntentID;
                lblTrackID.Text = LOI_ID.ToString();
                CurrentLOI = m_LOI;

                if ( !IsPostBack )
                    InitFieldsInputView();
            }
        }

        public void Reset_LOI()
        {
            m_LOI = new BO_LetterOfIntent();
            ErrorText.InnerHtml = "";
            ErrorText.Visible = false;
            txtConfEmail.Text = "";

            CurrentLOI = m_LOI;
            InitFieldsInputView();
        }

        public bool Save()
        {
            bool bReturn = true;
            ErrorText.InnerHtml = "";
            ErrorText.Visible = false;

            if ( txtFacilityEmail.Text.ToLower() != txtFacilityEmailConfirm.Text.ToLower() )
            {
                bReturn = false;
                ErrorText.InnerHtml = ErrorText.InnerHtml + "Facility Email Address and Confirmation do not match!<br/>";
            }
            if (txtAdminPersEmail.Text.ToLower() != txtConfEmail.Text.ToLower())
            {
                bReturn = false;
                ErrorText.InnerHtml = ErrorText.InnerHtml + "Admin Email Address and Confirmation do not match!<br/>";
            }

            if (txtFacilityName.Text.Length < 1)
            {
                bReturn = false;
                ErrorText.InnerHtml = ErrorText.InnerHtml + "Please enter Facility Name<br/>";
            }
            if (txtGeoAddress.Text.Length < 1)
            {
                bReturn = false;
                ErrorText.InnerHtml = ErrorText.InnerHtml + "Please enter Geographic Address<br/>";
            }
            if (txtFacilityPhone.Text.Length < 1)
            {
                bReturn = false;
                ErrorText.InnerHtml = ErrorText.InnerHtml + "Please enter Facility Phone<br/>";
            }
            if (txtFacilityFax.Text.Length < 1)
            {
                bReturn = false;
                ErrorText.InnerHtml = ErrorText.InnerHtml + "Please enter Facility Fax<br/>";
            }
            if (txtFacilityEmail.Text.Length < 1)
            {
                bReturn = false;
                ErrorText.InnerHtml = ErrorText.InnerHtml + "Please enter Facility Email<br/>";
            }
            if (txtMailAddr.Text.Length < 1)
            {
                bReturn = false;
                ErrorText.InnerHtml = ErrorText.InnerHtml + "Please enter Mail Address<br/>";
            }
            if ( txtOwnerLegalEntity.Text.Length < 1 )
            {
                bReturn = false;
                ErrorText.InnerHtml = ErrorText.InnerHtml + "Please enter Owner/Legal Entity Name<br/>";
            }
            if (txtOwnerEIN.Text.Length < 1)
            {
                bReturn = false;
                ErrorText.InnerHtml = ErrorText.InnerHtml + "Please enter Owner EIN<br/>";
            }
            if (txtAdminPersName.Text.Length < 1)
            {
                bReturn = false;
                ErrorText.InnerHtml = ErrorText.InnerHtml + "Please enter Administrative Person Name<br/>";
            }
            if (txtAdminPersTitle.Text.Length < 1)
            {
                bReturn = false;
                ErrorText.InnerHtml = ErrorText.InnerHtml + "Please enter Administrative Person Title<br/>";
            }
            if (txtAdminPersEmail.Text.Length < 1)
            {
                bReturn = false;
                ErrorText.InnerHtml = ErrorText.InnerHtml + "Please enter Administrative Person Email<br/>";
            }
            if (txtAdminPersPhone.Text.Length < 1)
            {
                bReturn = false;
                ErrorText.InnerHtml = ErrorText.InnerHtml + "Please enter Administrative Person Phone<br/>";
            }
            if (dtFacilityOpen.SelectedDate == null)
            {
                bReturn = false;
                ErrorText.InnerHtml = ErrorText.InnerHtml + "Please enter Plan to Open Date<br/>";
            }
            if (listGeoState.SelectedValue == null)
            {
                bReturn = false;
                ErrorText.InnerHtml = ErrorText.InnerHtml + "Please enter Geographic State<br/>";
            }
            if (listGeoCity.SelectedValue == null)
            {
                bReturn = false;
                ErrorText.InnerHtml = ErrorText.InnerHtml + "Please enter Geographic City<br/>";
            }
            if (listGeoZip.SelectedValue == null)
            {
                bReturn = false;
                ErrorText.InnerHtml = ErrorText.InnerHtml + "Please enter Geographic Zip<br/>";
            }

            if (listMailCity2.SelectedValue == null)
            {
                bReturn = false;
                ErrorText.InnerHtml = ErrorText.InnerHtml + "Please enter Mail City<br/>";
            }
            if (listMailState.SelectedValue == null)
            {
                bReturn = false;
                ErrorText.InnerHtml = ErrorText.InnerHtml + "Please enter Mail State<br/>";
            }
            if (listMailZip.SelectedValue == null)
            {
                bReturn = false;
                ErrorText.InnerHtml = ErrorText.InnerHtml + "Please enter Mail Zip<br/>";
            }
            if (listTypeFacility.SelectedValue == null)
            {
                bReturn = false;
                ErrorText.InnerHtml = ErrorText.InnerHtml + "Please enter Facility Type<br/>";
            }

            if ( bReturn )
            {
                string theid = lblTrackID.Text;

                Decimal tmpPopsIntId = 0;

                if ( null != Session["ProviderPOPSINTID"] && Session["ProviderPOPSINTID"].ToString().Length > 0 )
                    tmpPopsIntId = Convert.ToDecimal( Session["ProviderPOPSINTID"] );

                String tmpStateID = (String) Session["ProviderStateID"];

                if ( !tmpPopsIntId.Equals( 0 ) )
                    m_LOI.PopsIntID = tmpPopsIntId;

                if ( null != tmpStateID && !tmpStateID.Equals( "" ) )
                    m_LOI.StateID = tmpStateID;

                m_LOI.ProgramID = listTypeFacility.SelectedValue;
                m_LOI.FacilityType = listTypeFacility.SelectedValue;
                m_LOI.Name = txtFacilityName.Text;
                m_LOI.PlanToOpenDate = dtFacilityOpen.SelectedDate;
                m_LOI.GeographicAddress = txtGeoAddress.Text;

                //changes made to allow providers located in other states besides LA, current lookup default values for city, zip will not work for other states
                //if (listGeoState.SelectedIndex == 0)
                   // m_LOI.StateCode = "LA";
               /// else
                    m_LOI.StateCode = listGeoState.SelectedValue;

               // if (m_LOI.StateCode == "LA")
               // {
                    m_LOI.GeographicCity = listGeoCity.SelectedValue;
                    m_LOI.GeographicZip = listGeoZip.SelectedValue;
                //}
               // else
               // {
                  //  m_LOI.GeographicCity = altGeoCity.Text;
                   // m_LOI.GeographicZip = altGeoZip.Text;
               // }


                m_LOI.Phone = txtFacilityPhone.Text;
                m_LOI.Fax = txtFacilityFax.Text;
                m_LOI.Email = txtFacilityEmail.Text;
                m_LOI.MailAddress = txtMailAddr.Text;
                m_LOI.MailCity = listMailCity2.SelectedValue;
                m_LOI.MailState = listMailState.SelectedValue;
                m_LOI.MailZip = listMailZip.SelectedValue;
                m_LOI.OwnerLegalEntity = txtOwnerLegalEntity.Text;
                m_LOI.OwnerEin = txtOwnerEIN.Text;
                m_LOI.FnrApprovalDate = dpFNRApprovalDate.SelectedDate;
                m_LOI.AuthAdminName = txtAdminPersName.Text;
                m_LOI.AuthAdminTitle = txtAdminPersTitle.Text;
                m_LOI.AuthAdminEmail = txtAdminPersEmail.Text;
                m_LOI.AuthAdminPhone = txtAdminPersPhone.Text;
                m_LOI.TypeServicesOffered = txtTypeService.Text;
                m_LOI.LetterOfIntentType = "1";

                if ( null != m_LOI.LetterOfIntentID && m_LOI.LetterOfIntentID > 0 )
                    m_LOI.Update();
                else
                {
                    m_LOI.InsertWithDefaultValues( true );
                    LOI_ID = m_LOI.LetterOfIntentID;
                    lblTrackID.Text = LOI_ID.Value.ToString();
                }
            }
            else
            {
                ErrorText.Visible = true;
            }

            return bReturn;
        }

        protected void listTypeFacility_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if("AC,PD,HC,HP".Contains(e.Value.ToString()))
            {
                lblFNRApprovalDate.Visible = true;
                dpFNRApprovalDate.Visible = true;
            }
        }

        protected void listGeoState_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            listGeoCity.ClearSelection();
            listGeoCity.DataSource = CommonFunc.getCitiesByState(e.Value.ToString());
            listGeoCity.DataTextField = "City";
            listGeoCity.DataValueField = "City";
            listGeoCity.Height = Unit.Pixel(100);
            listGeoCity.DataBind();            
        }

        protected void listGeoCity_SelectedIndexChanged( object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e )
        {
            listGeoZip.ClearSelection();
            listGeoZip.DataSource = CommonFunc.getZipByCityState( e.Value.ToString() ,listGeoState.SelectedValue);
            listGeoZip.DataTextField = "Zip";
            listGeoZip.DataValueField = "Zip";
            listGeoZip.Height = Unit.Pixel( 100 );
            listGeoZip.DataBind();
        }

        protected void listMailState_SelectedIndexChanged( object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e )
        {
            listMailCity2.ClearSelection();
            listMailCity2.DataSource = CommonFunc.getCitiesByState( e.Value.ToString() );
            listMailCity2.DataTextField = "City";
            listMailCity2.DataValueField = "City";
            listMailCity2.Height = Unit.Pixel( 100 );
            listMailCity2.DataBind();            
        }

        protected void listMailCity2_SelectedIndexChanged( object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e )
        {
            listMailZip.ClearSelection();
            listMailZip.DataSource = CommonFunc.getZipByCityState(e.Value.ToString(), listMailState.SelectedValue);
            listMailZip.DataTextField = "Zip";
            listMailZip.DataValueField = "Zip";
            listMailZip.Height = Unit.Pixel( 100 );
            listMailZip.DataBind();
        }

        private void InitFieldsInputView()
        {
            //Clear select lists before loading
            listTypeFacility.Items.Clear();
            listGeoState.Items.Clear();
            listGeoCity.Items.Clear();
            listGeoZip.Items.Clear();
            listMailState.Items.Clear();
            listMailCity2.Items.Clear();
            listMailZip.Items.Clear();
            
            //Fill Select Lists
            listTypeFacility.AppendDataBoundItems = true;
            listTypeFacility.Items.Add(new RadComboBoxItem("", ""));
            listTypeFacility.DataSource = BO_Program.SelectAll();
            listTypeFacility.DataTextField = "ProgramDescription";
            listTypeFacility.DataValueField = "ProgramID";
            listTypeFacility.Height = Unit.Pixel( 100 );

            if ( null != m_LOI.FacilityType && !m_LOI.FacilityType.Equals( "" ) )
                listTypeFacility.SelectedValue = m_LOI.FacilityType;

            listTypeFacility.DataBind();

            listGeoState.AppendDataBoundItems = true;
            listGeoState.Items.Add(new RadComboBoxItem("", ""));
            listGeoState.DataSource = BO_State.SelectAll();
            listGeoState.DataTextField = "StateName";
            listGeoState.DataValueField = "StateCode";
            listGeoState.Height = Unit.Pixel(100);
            listGeoState.DataBind();

            listGeoCity.AppendDataBoundItems = true;
            listGeoCity.Items.Add(new RadComboBoxItem("", ""));

            if (null != m_LOI.StateCode && !m_LOI.StateCode.Equals(""))
            {
                listGeoState.SelectedValue = m_LOI.StateCode;
                listGeoCity.DataSource = CommonFunc.getCitiesByState(m_LOI.StateCode);
            }
            else
            {
                listGeoCity.DataSource = CommonFunc.getCitiesByState(listGeoState.SelectedValue);
            }

            listGeoCity.DataTextField = "City";
            listGeoCity.DataValueField = "City";
            listGeoCity.Height = Unit.Pixel( 100 );
            listGeoCity.DataBind();

            listGeoZip.AppendDataBoundItems = true;
            listGeoZip.Items.Add(new RadComboBoxItem("", ""));

            if ( null != m_LOI.GeographicCity && !m_LOI.GeographicCity.Equals( "" ) )
            {
                listGeoCity.SelectedValue = m_LOI.GeographicCity;
                listGeoZip.DataSource = CommonFunc.getZipByCityState( m_LOI.GeographicCity, listGeoState.SelectedValue );
            }
            else
            {
                listGeoZip.DataSource = CommonFunc.getZipByCityState( listGeoCity.SelectedValue, listGeoState.SelectedValue );
            }
            
            listGeoZip.DataTextField = "ZIP";
            listGeoZip.DataValueField = "ZIP";
            listGeoZip.Height = Unit.Pixel( 100 );

            if ( null != m_LOI.GeographicZip && !m_LOI.GeographicZip.Equals( "" ) )
                listGeoZip.SelectedValue = m_LOI.GeographicZip;

            listGeoZip.DataBind();

            listMailState.AppendDataBoundItems = true;
            listMailState.Items.Add(new RadComboBoxItem("", ""));
            listMailState.DataSource = BO_State.SelectAll();
            listMailState.DataTextField = "StateName";
            listMailState.DataValueField = "StateCode";
            listMailState.Height = Unit.Pixel( 100 );
            listMailState.DataBind();

            listMailCity2.AppendDataBoundItems = true;
            listMailCity2.Items.Add(new RadComboBoxItem("", ""));

            if ( null != m_LOI.MailState && !m_LOI.MailState.Equals( "" ) )
            {
                listMailState.SelectedValue = m_LOI.MailState;
                listMailCity2.DataSource = CommonFunc.getCitiesByState( m_LOI.MailState );
            }
            else
            {
                listMailCity2.DataSource = CommonFunc.getCitiesByState( listMailState.SelectedValue );
            }

            listMailCity2.DataTextField = "City";
            listMailCity2.DataValueField = "City";
            listMailCity2.Height = Unit.Pixel( 100 );
            listMailCity2.DataBind();

            listMailZip.AppendDataBoundItems = true;
            listMailZip.Items.Add(new RadComboBoxItem("", ""));

            if ( null != m_LOI.MailCity && !m_LOI.MailCity.Equals( "" ) )
            {
                listMailCity2.SelectedValue = m_LOI.MailCity;
                listMailZip.DataSource = CommonFunc.getZipByCityState( m_LOI.MailCity , m_LOI.MailState);
            }
            else {
                listMailZip.DataSource = CommonFunc.getZipByCityState(listMailCity2.SelectedValue, listMailState.SelectedValue);
            }

            listMailZip.DataTextField = "ZIP";
            listMailZip.DataValueField = "ZIP";
            listMailZip.Height = Unit.Pixel( 100 );
            listMailZip.DataBind();

            if ( null != m_LOI.MailZip && !m_LOI.MailZip.Equals( "" ) )
                listMailZip.SelectedValue = m_LOI.MailZip;

            //Fill all remaining fields
            txtFacilityName.Text = m_LOI.Name;
            dtFacilityOpen.SelectedDate = m_LOI.PlanToOpenDate;
            txtGeoAddress.Text = m_LOI.GeographicAddress;
            txtFacilityPhone.Text = m_LOI.Phone;
            txtFacilityFax.Text = m_LOI.Fax;
            txtFacilityEmail.Text = m_LOI.Email;
            txtMailAddr.Text = m_LOI.MailAddress;
            txtOwnerLegalEntity.Text = m_LOI.OwnerLegalEntity;
            txtOwnerEIN.Text = m_LOI.OwnerEin;
            txtAdminPersName.Text = m_LOI.AuthAdminName;
            txtAdminPersPhone.Text = m_LOI.AuthAdminPhone;
            txtAdminPersTitle.Text = m_LOI.AuthAdminTitle;
            txtAdminPersEmail.Text = m_LOI.AuthAdminEmail;
            txtTypeService.Text = m_LOI.TypeServicesOffered;

            if (m_LOI.ProgramID != null)
            {
                if ("AC,PD,HC,HP".Contains(m_LOI.ProgramID))
                {
                    dpFNRApprovalDate.SelectedDate = m_LOI.FnrApprovalDate;
                    lblFNRApprovalDate.Visible = true;
                    dpFNRApprovalDate.Visible = true;
                }
            }

            EnableDisableControls();
        }

        private void InitFieldsPrintView()
        {
            string tmpTypeFac = "";

            if ( null != m_LOI.FacilityType && !m_LOI.FacilityType.Equals( "" ) )
                tmpTypeFac = ( BO_Program.SelectOne( new BO_ProgramPrimaryKey( m_LOI.FacilityType ) ) ).ProgramDescription;

            //Fill print Fields
            printTypeFacility.Text = tmpTypeFac;
            printFacilityName.Text = m_LOI.Name;
            printFacilityOpen.Text = m_LOI.PlanToOpenDate.ToString();
            printGeoAddress.Text = m_LOI.GeographicAddress;
            printGeoState.Text = m_LOI.StateCode;
            printGeoCity.Text = m_LOI.GeographicCity;
            printGeoZip.Text = m_LOI.GeographicZip;
            printFacilityPhone.Text = m_LOI.Phone;
            printFacilityFax.Text = m_LOI.Fax;
            printFacilityEmail.Text = m_LOI.Email;
            printMailAddr.Text = m_LOI.MailAddress;
            printMailCity.Text = m_LOI.MailCity;
            printMailState.Text = m_LOI.MailState;
            printMailZip.Text = m_LOI.MailZip;
            printOwnerLegalEntity.Text = m_LOI.OwnerLegalEntity;
            printOwnerEIN.Text = m_LOI.OwnerEin;
            printAdminPersName.Text = m_LOI.AuthAdminName;
            printAdminPersTitle.Text = m_LOI.AuthAdminTitle;
            printAdminPersEmail.Text = m_LOI.AuthAdminEmail;
            printAdminPersPhone.Text = m_LOI.AuthAdminPhone;
            lblTypeService.Text = m_LOI.TypeServicesOffered;

            EnableDisableControls();
        }

        private void EnableDisableControls()
        {
            //Enable/Disable footers
            printFootP1.Visible = _m_PrintMode;
            printFootP2.Visible = _m_PrintMode;
            printFootP3.Visible = _m_PrintMode;

            //Enable print Fields
            printTypeFacility.Visible = _m_PrintMode;
            printFacilityName.Visible = _m_PrintMode;
            printFacilityOpen.Visible = _m_PrintMode;
            printGeoAddress.Visible = _m_PrintMode;
            printGeoCity.Visible = _m_PrintMode;
            printGeoZip.Visible = _m_PrintMode;
            printGeoState.Visible = _m_PrintMode;
            printFacilityPhone.Visible = _m_PrintMode;
            printFacilityFax.Visible = _m_PrintMode;
            printFacilityEmail.Visible = _m_PrintMode;
            printMailAddr.Visible = _m_PrintMode;
            printMailCity.Visible = _m_PrintMode;
            printMailState.Visible = _m_PrintMode;
            printMailZip.Visible = _m_PrintMode;
            printOwnerLegalEntity.Visible = _m_PrintMode;
            printOwnerEIN.Visible = _m_PrintMode;
            printAdminPersName.Visible = _m_PrintMode;
            printAdminPersTitle.Visible = _m_PrintMode;
            printAdminPersEmail.Visible = _m_PrintMode;
            printAdminPersPhone.Visible = _m_PrintMode;
            lblTypeService.Visible = _m_PrintMode;

            //Disable and hide input controls
            listTypeFacility.Enabled = !_m_PrintMode;
            listTypeFacility.Visible = !_m_PrintMode;
            txtFacilityName.Enabled = !_m_PrintMode;
            txtFacilityName.Visible = !_m_PrintMode;
            dtFacilityOpen.Enabled = !_m_PrintMode;
            dtFacilityOpen.Visible = !_m_PrintMode;
            txtGeoAddress.Enabled = !_m_PrintMode;
            txtGeoAddress.Visible = !_m_PrintMode;
            listGeoCity.Enabled = !_m_PrintMode;
            listGeoCity.Visible = !_m_PrintMode;
            listGeoZip.Enabled = !_m_PrintMode;
            listGeoZip.Visible = !_m_PrintMode;
            listGeoState.Enabled = !_m_PrintMode;
            listGeoState.Visible = !_m_PrintMode;
            txtFacilityPhone.Enabled = !_m_PrintMode;
            txtFacilityPhone.Visible = !_m_PrintMode;
            txtFacilityFax.Enabled = !_m_PrintMode;
            txtFacilityFax.Visible = !_m_PrintMode;
            txtFacilityEmail.Enabled = !_m_PrintMode;
            txtFacilityEmail.Visible = !_m_PrintMode;
            txtMailAddr.Enabled = !_m_PrintMode;
            txtMailAddr.Visible = !_m_PrintMode;
            listMailCity2.Enabled = !_m_PrintMode;
            listMailCity2.Visible = !_m_PrintMode;
            listMailState.Enabled = !_m_PrintMode;
            listMailState.Visible = !_m_PrintMode;
            listMailZip.Enabled = !_m_PrintMode;
            listMailZip.Visible = !_m_PrintMode;
            txtOwnerLegalEntity.Enabled = !_m_PrintMode;
            txtOwnerLegalEntity.Visible = !_m_PrintMode;
            txtOwnerEIN.Enabled = !_m_PrintMode;
            txtOwnerEIN.Visible = !_m_PrintMode;
            txtAdminPersName.Enabled = !_m_PrintMode;
            txtAdminPersName.Visible = !_m_PrintMode;
            txtAdminPersTitle.Enabled = !_m_PrintMode;
            txtAdminPersTitle.Visible = !_m_PrintMode;
            txtAdminPersEmail.Enabled = !_m_PrintMode;
            txtAdminPersEmail.Visible = !_m_PrintMode;
            txtAdminPersPhone.Enabled = !_m_PrintMode;
            txtAdminPersPhone.Visible = !_m_PrintMode;
            txtTypeService.Visible = !_m_PrintMode;

        }

        private BO_LetterOfIntent CurrentLOI
        {
            get
            {
                return this.ViewState["CurrentLOI"] == null ? null : (BO_LetterOfIntent) this.ViewState["CurrentLOI"];
            }
            set
            {
                this.ViewState["CurrentLOI"] = value;
            }
        }
    }
}