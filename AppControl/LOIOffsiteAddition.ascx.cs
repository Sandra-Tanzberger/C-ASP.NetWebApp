using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using ATG;
using ATG.BusinessObject;

namespace AppControl
{
    public partial class LOIOffsiteAddition : System.Web.UI.UserControl
    {
        private bool _m_PrintMode = false;
        private decimal? _m_LOI_ID = 0;
        public BO_LetterOfIntent m_LOI = null;
        private BO_Provider _m_Provider = null;
        private BO_LetterOfIntentPrimaryKey _m_LOI_PK = null;
        private AffiliationOffsite _m_AffilOffsiteControl = null;
        
        protected override void OnInit( EventArgs e )
        {
            base.OnInit( e );
        }

        protected void Page_Load( object sender, EventArgs e )
        {
            if ( CurrentLOI_OA == null )
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

                CurrentLOI_OA = m_LOI;
            }
            else
            {
                m_LOI = CurrentLOI_OA;
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

        public void Load_LOI_OA( decimal? inLOI_ID )
        {
            _m_LOI_PK = new BO_LetterOfIntentPrimaryKey( inLOI_ID );
            m_LOI = BO_LetterOfIntent.SelectOne( _m_LOI_PK );

            if ( null != m_LOI )
            {
               
                LOI_ID = m_LOI.LetterOfIntentID;
                lblTrackID.Text = LOI_ID.ToString();
                CurrentLOI_OA = m_LOI;

                _InitAffiliations();

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
            CurrentLOI_OA = m_LOI;
            ErrorText.InnerHtml = "";
            ErrorText.Visible = false;

            InitFieldsInputView();
        }

        public bool Save()
        {
            bool bReturn = true;
            ErrorText.InnerHtml = "";
            ErrorText.Visible = false;

            if ( txtSrchStateID.Text.Length < 1 )
            {
                bReturn = false;
                ErrorText.InnerHtml = ErrorText.InnerHtml + "Please enter State ID<br/>";
            }
            if ( m_LOI.GeographicAddress == null )
            {
                bReturn = false;
                ErrorText.InnerHtml = ErrorText.InnerHtml + "Please find the State ID to populate Geographic Address<br/>";
            }
            if ( m_LOI.GeographicCity == null )
            {
                bReturn = false;
                ErrorText.InnerHtml = ErrorText.InnerHtml + "Please find the State ID to populate Geographic City<br/>";
            }
            if ( m_LOI.GeographicZip == null )
            {
                bReturn = false;
                ErrorText.InnerHtml = ErrorText.InnerHtml + "Please find the State ID to populate Geographic Zip<br/>";
            }
            if ( m_LOI.Name == null )
            {
                bReturn = false;
                ErrorText.InnerHtml = ErrorText.InnerHtml + "Please find the State ID to populate Facility Name<br/>";
            }

            if ( bReturn )
            {
                string theid = lblTrackID.Text;

                Decimal tmpPopsIntId = 0;

                if ( null != Session["ProviderPOPSINTID"] && Session["ProviderPOPSINTID"].ToString().Length > 0 )
                    tmpPopsIntId = Convert.ToDecimal( Session["ProviderPOPSINTID"] );

                String tmpStateID = (String) Session["ProviderStateID"];

                //If confirmed then do not save values. They are read only but this is an extra check.
                if ( m_LOI.Confirmed != 1 )
                {
                    m_LOI.Phone = txtFacilityPhone.Text;
                    m_LOI.Email = txtFacilityEmail.Text;
                    m_LOI.LetterOfIntentType = "4";

                    if ( null != m_LOI.LetterOfIntentID && m_LOI.LetterOfIntentID > 0 )
                        m_LOI.Update();
                    else
                    {
                        m_LOI.InsertWithDefaultValues( true );
                        LOI_ID = m_LOI.LetterOfIntentID;
                    }
                }
            }
            else
            {
                ErrorText.Visible = true;
            }

            return bReturn;
        }

        protected void btnSrchStateID_Click( object sender, CommandEventArgs e )
        {
            lblProvNotFound.Visible = false;
            if ( txtSrchStateID.Text.Length > 0 )
            {
                BO_Providers tmpPrvdrs = BO_Provider.SelectByField( "STATE_ID", txtSrchStateID.Text.ToUpper() );
                if ( null != tmpPrvdrs && tmpPrvdrs.Count > 0 )
                {
                    _m_Provider = tmpPrvdrs[0];
                }
                else
                {
                    lblProvNotFound.Visible = true;
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
                    m_LOI.Name = _m_Provider.FacilityName;
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
                    InitFieldsInputView();
                }

                CurrentLOI_OA = m_LOI;
            }
        }

        private void _InitAffiliations()
        {
            AffiliationRepeater.DataSource = CurrentAffiliationsDataSource;
            AffiliationRepeater.DataBind();
        }

        protected void AffiliationRepeater_ItemDataBound( object sender, RepeaterItemEventArgs e )
        {
            //if ( e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem )
            //{
            //    HiddenField tmpAffilID = (HiddenField) e.Item.FindControl( "hidAffilID" );

            //    LinkButton tmpBtn = (LinkButton) e.Item.FindControl( "AffilRemoveAction" );
            //    if ( tmpBtn != null && !AllowEdit )
            //        tmpBtn.Enabled = false;
            //}
        }
        
        private void InitFieldsInputView()
        {
            if ( null != m_LOI && null != m_LOI.StateID )
            {
                //Fill all remaining fields
                lblTrackID.Text = m_LOI.LetterOfIntentID.ToString();

                if ( !m_LOI.StateID.Equals( "" ) )
                {
                    lblStateID.Text = "State ID:";
                    printStateID.Text = m_LOI.StateID;
                    btnSrchStateID.Visible = false;
                    printStateID.Visible = true;
                    txtSrchStateID.Visible = false;
                }
                else
                {
                    lblStateID.Text = "Enter State ID:";
                    btnSrchStateID.Visible = true;
                    printStateID.Visible = false;
                    txtSrchStateID.Visible = true;
                }

                //SMM 01/22/2012 - Removed title case conversion
                //printFacilityName.Text = CommonFunc.ConvertToTitleCase( m_LOI.Name );
                //printGeoAddress.Text = CommonFunc.ConvertToTitleCase( m_LOI.GeographicAddress );
                printFacilityName.Text = m_LOI.Name;
                printGeoAddress.Text = m_LOI.GeographicAddress;
                printGeoCity.Text = CommonFunc.ConvertToTitleCase( m_LOI.GeographicCity );
                printGeoZip.Text = m_LOI.GeographicZip;
                printFacilityEmail.Text = m_LOI.Email;
                
                if ( null != m_LOI.Phone && m_LOI.Phone.Length > 9 )
                    printFacilityPhone.Text = "(" + m_LOI.Phone.Substring( 0, 3 ) + ")" + m_LOI.Phone.Substring( 3, 3 ) + "-" + m_LOI.Phone.Substring( 6, 4 );
            }

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

            if ( null != m_LOI.Phone && m_LOI.Phone.Length > 9 )
                printFacilityPhone.Text = "(" + m_LOI.Phone.Substring( 0, 3 ) + ")" + m_LOI.Phone.Substring( 3, 3 ) + "-" + m_LOI.Phone.Substring( 6, 4 );
            
            printFacilityEmail.Text = m_LOI.Email;

            EnableDisableControls();
        }

        private void EnableDisableControls()
        {
            ////Enable/Disable footers
            printSpaceTable.Visible = _m_PrintMode;
            printFootP1.Visible = _m_PrintMode;
            printFootP2.Visible = _m_PrintMode;

            //txtSrchStateID.Visible = !_m_PrintMode;
            //btnSrchStateID.Visible = !_m_PrintMode;

            //printStateID.Visible = _m_PrintMode;
            //printFacilityEmail.Visible = _m_PrintMode;
            //printFacilityPhone.Visible = _m_PrintMode;

            txtFacilityEmail.Enabled = false;
            txtFacilityEmail.Visible = false;
            txtFacilityPhone.Enabled = false;
            txtFacilityPhone.Visible = false;

        }

        private DataTable _getAffilGridInitTable()
        {
            DataTable tmpDTbl = new DataTable();
            DataColumn tmpDCol = null;

            tmpDCol = new DataColumn( "LicensureNumber" );
            tmpDTbl.Columns.Add( tmpDCol );
            tmpDCol = new DataColumn( "FacilityName" );
            tmpDTbl.Columns.Add( tmpDCol );
            tmpDCol = new DataColumn( "Address" );
            tmpDTbl.Columns.Add( tmpDCol );
            tmpDCol = new DataColumn( "Phone" );
            tmpDTbl.Columns.Add( tmpDCol );
            tmpDCol = new DataColumn( "Fax" );
            tmpDTbl.Columns.Add( tmpDCol );
            tmpDCol = new DataColumn( "UploadCommandText" );
            tmpDTbl.Columns.Add( tmpDCol );
            tmpDCol = new DataColumn( "CommandArgs" );
            tmpDTbl.Columns.Add( tmpDCol );
            tmpDCol = new DataColumn( "AffiliationID" );
            tmpDTbl.Columns.Add( tmpDCol );

            return tmpDTbl;

        }

        private DataTable CurrentAffiliationsDataSource
        {
            get
            {
                DataTable retTable = _getAffilGridInitTable();

                BO_Application tmpApp = new BO_Application();

                if ( null != CurrentLOI_OA.ApplicationID )
                {
                    tmpApp.LoadFullApplication( CurrentLOI_OA.ApplicationID.Value );

                    if ( null != tmpApp && tmpApp.BO_AffiliationsApplicationID != null )
                    {
                        foreach ( BO_Affiliation boAffil in tmpApp.BO_AffiliationsApplicationID )
                        {
                            if ( !boAffil.Removed && boAffil.ApplicationID == boAffil.OriginalApplicationID )
                            {
                                DataRow tmpDR = retTable.NewRow();
                                string tmpAddress = "";
                                //SMM 01/22/2012 - Removed Title Case conversion
                                //tmpAddress += CommonFunc.ConvertToTitleCase( boAffil.BO_AddressAffiliationID.Street );
                                tmpAddress += boAffil.BO_AddressAffiliationID.Street;
                                tmpAddress += ",<br /> " + CommonFunc.ConvertToTitleCase( boAffil.BO_AddressAffiliationID.City );
                                tmpAddress += ", " + CommonFunc.ConvertToTitleCase( boAffil.BO_AddressAffiliationID.State );
                                tmpAddress += ". " + boAffil.BO_AddressAffiliationID.ZipCode;

                                tmpDR["AffiliationID"] = boAffil.AffiliationID;
                                tmpDR["LicensureNumber"] = boAffil.LicensureNum;
                                //SMM 01/22/2012 - Rmoved Title Case conversion
                                //tmpDR["FacilityName"] = CommonFunc.ConvertToTitleCase( boAffil.FacilityName );
                                tmpDR["FacilityName"] = boAffil.FacilityName;
                                tmpDR["Address"] = tmpAddress;
                                tmpDR["Phone"] = _formatPhoneDisplayText( boAffil.TelephoneNumber );
                                tmpDR["fax"] = _formatPhoneDisplayText( boAffil.FaxPhoneNumber );
                                tmpDR["AffiliationID"] = boAffil.AffiliationID;

                                if ( !tmpApp.BusinessProcessID.Equals( "8" )
                                    && tmpApp.ApplicationAction.Equals( "2" ) ) //DHH-Working
                                {
                                    tmpDR["CommandArgs"] = boAffil.UI_TrackID.ToString() + "," + "Edit";
                                    tmpDR["UploadCommandText"] = "Edit";
                                }
                                else if ( !tmpApp.BusinessProcessID.Equals( "8" )
                                    || tmpApp.ApplicationAction.Equals( "4" ) ) //Locked
                                {
                                    tmpDR["CommandArgs"] = boAffil.UI_TrackID.ToString() + "," + "View";
                                    tmpDR["UploadCommandText"] = "View";
                                }
                                else if ( tmpApp.BusinessProcessID.Equals( "8" ) )
                                {
                                    if ( boAffil.AffiliationID != 0 )
                                    {
                                        BO_Affiliation boa = BO_Affiliation.SelectOne( new BO_AffiliationPrimaryKey( tmpApp.PopsIntID, boAffil.AffiliationID, tmpApp.ApplicationID ) );
                                        //if ( !_AddedThisApp( boa.AddressID ) )
                                        //{
                                        //    tmpDR["CommandArgs"] = boAffil.UI_TrackID.ToString() + "," + "View";
                                        //    tmpDR["UploadCommandText"] = "View";
                                        //}
                                        //else
                                        //{
                                        tmpDR["CommandArgs"] = boAffil.UI_TrackID.ToString() + "," + "Edit";
                                        tmpDR["UploadCommandText"] = "Edit";
                                        //}
                                    }
                                    else
                                    {
                                        tmpDR["CommandArgs"] = boAffil.UI_TrackID.ToString() + "," + "Edit";
                                        tmpDR["UploadCommandText"] = "Edit";
                                    }

                                }
                                else
                                {
                                    tmpDR["CommandArgs"] = boAffil.UI_TrackID.ToString() + "," + "Edit";
                                    tmpDR["UploadCommandText"] = "Edit";
                                }

                                retTable.Rows.Add( tmpDR );
                            }
                        }
                    }
                }
                
                return retTable;
            }
            set
            {
                ViewState["OwnerInterestDataSource"] = value;
            }
        }

        private string _formatPhoneDisplayText( string inPhoneFaxNum )
        {
            string retVal = "";

            if ( null == inPhoneFaxNum || inPhoneFaxNum.Length != 10 )
                retVal = inPhoneFaxNum;
            else
            {
                string tmpStr = "";

                tmpStr += "(" + inPhoneFaxNum.Substring( 0, 3 ) + ")";
                tmpStr += inPhoneFaxNum.Substring( 2, 3 ) + "-";
                tmpStr += inPhoneFaxNum.Substring( 5, 4 );

                retVal = tmpStr;
            }

            return retVal;
        }

        private BO_LetterOfIntent CurrentLOI_OA
        {
            get
            {
                return this.ViewState["CurrentLOI_OA"] == null ? null : (BO_LetterOfIntent) this.ViewState["CurrentLOI_OA"];
            }
            set
            {
                this.ViewState["CurrentLOI_OA"] = value;
            }
        }
    }
}