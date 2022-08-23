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
    public partial class KeyPersonnel : System.Web.UI.UserControl
    {
        protected override void OnInit( EventArgs e )
        {
            base.OnInit( e );
            _LoadKeyPersonnelControls();
        }

        protected void Page_Load( object sender, EventArgs e )
        {
        }

        public void LoadApplication( string inAppID, bool inAllowEdit )
        {
            makeRead = inAllowEdit;

            if ( inAppID != null && CurrentAppProvider != null )
            {
                _Init();
                _ShowHideLabelPersChange();
            }
            _ShowHideFields();
        }

        public bool SaveData()
        {
            bool kp1Saved = false;
            bool kp2Saved = false;
            bool kp3Saved = false;
            bool kp4Saved = false;
            bool kp5Saved = false;
            bool kp6Saved = false;
            bool kp7Saved = false;
            bool kpRNSaved = false;
            bool kpPhysAsstSaved = false;
            bool kpLPNSaved = false;
            bool kpCDSaved = false;
            bool kpHMSaved = false;
            bool kpRNCSaved = false;

            if ( sldrKPAdministrator.Visible )
            {
                if (rbKPAdministrator.Checked)
                    SavePrimaryFACAdmin(Convert.ToDecimal(rbKPAdministrator.Attributes["PFAID"]));
                _m_KPAdminEF = (KeyPersonnelEditForm) Page.FindControlRecursive( CurrentKPAdministratorControlID );
                kp1Saved = _m_KPAdminEF.SaveData( true );
            }
            else
                kp1Saved = true;

            if ( sldrKPAltAdministrator.Visible )
            {
                if (rbKPAltAdministrator.Checked)
                    SavePrimaryFACAdmin(Convert.ToDecimal(rbKPAltAdministrator.Attributes["PFAID"]));
                _m_KPAltAdminEF = (KeyPersonnelEditForm) Page.FindControlRecursive( CurrentKPAltAdministratorControlID );
                kp2Saved = _m_KPAltAdminEF.SaveData(false);

            }
            else
                kp2Saved = true;

            if ( sldrKPDON.Visible )
            {
                if (rbKPDON.Checked)
                    SavePrimaryFACAdmin(Convert.ToDecimal(rbKPDON.Attributes["PFAID"]));
                _m_KPDONEF = (KeyPersonnelEditForm) Page.FindControlRecursive( CurrentKPDONControlID );
                kp3Saved = _m_KPDONEF.SaveData(true); 
            }
            else
                kp3Saved = true;

            if ( sldrKPAltDON.Visible )
            {
                if (rbKPAltDON.Checked)
                    SavePrimaryFACAdmin(Convert.ToDecimal(rbKPAltDON.Attributes["PFAID"]));
                _m_KPAltDONEF = (KeyPersonnelEditForm) Page.FindControlRecursive( CurrentKPAltDonControlID );
                kp4Saved = _m_KPAltDONEF.SaveData(false);
            }
            else
                kp4Saved = true;

            if ( sldrKPDirector.Visible )
            {
                if (rbKPDirector.Checked)
                    SavePrimaryFACAdmin(Convert.ToDecimal(rbKPDirector.Attributes["PFAID"]));
                _m_KPDirectorEF = (KeyPersonnelEditForm) Page.FindControlRecursive( CurrentKPDirectorControlID );
                kp5Saved = _m_KPDirectorEF.SaveData( false );
            }
            else
                kp5Saved = true;

            if ( sldrKPMedDirector.Visible )
            {
                if (rbKPMedDirector.Checked)
                    SavePrimaryFACAdmin(Convert.ToDecimal(rbKPMedDirector.Attributes["PFAID"]));
                _m_KPMedDirectorEF = (KeyPersonnelEditForm) Page.FindControlRecursive( CurrentKPMedDirectorControlID );
               kp6Saved = _m_KPMedDirectorEF.SaveData( false );
            }
            else
                kp6Saved = true;

            if ( sldrKPFacilityRn.Visible )
            {
                if (rbKPFacilityRn.Checked)
                    SavePrimaryFACAdmin(Convert.ToDecimal(rbKPFacilityRn.Attributes["PFAID"]));
                _m_KPFacilityRnEF = (KeyPersonnelEditForm) Page.FindControlRecursive( CurrentKPFacilityRnControlID );
                kp7Saved = _m_KPFacilityRnEF.SaveData( false );
            }
            else
                kp7Saved = true;

            if (sldrKPRN.Visible) {
                if (rbKPRN.Checked)
                    SavePrimaryFACAdmin(Convert.ToDecimal(rbKPRN.Attributes["PFAID"]));
                _m_KPRNEF = (KeyPersonnelEditForm)Page.FindControlRecursive(CurrentKPRNControlID);
                kpRNSaved = _m_KPRNEF.SaveData(false);
            }
            else
                kpRNSaved = true;

            if (sldrKPPhysAsst.Visible) {
                if (rbKPPhysAsst.Checked)
                    SavePrimaryFACAdmin(Convert.ToDecimal(rbKPPhysAsst.Attributes["PFAID"]));
                _m_KPPhysAsstEF = (KeyPersonnelEditForm)Page.FindControlRecursive(CurrentKPPhysAsstControlID);
                kpPhysAsstSaved = _m_KPPhysAsstEF.SaveData(false);
            }
            else
                kpPhysAsstSaved = true;

            if (sldrKPLPN.Visible) {
                if (rbKPLPN.Checked)
                    SavePrimaryFACAdmin(Convert.ToDecimal(rbKPLPN.Attributes["PFAID"]));
                _m_KPLPNEF = (KeyPersonnelEditForm)Page.FindControlRecursive(CurrentKPLPNControlID);
                kpLPNSaved = _m_KPLPNEF.SaveData(false);
            }
            else
                kpLPNSaved = true;

            if (sldrKPCD.Visible)
            {
                if (rbKPCD.Checked)
                    SavePrimaryFACAdmin(Convert.ToDecimal(rbKPCD.Attributes["PFAID"]));
                _m_KPClinicalDirector = (KeyPersonnelEditForm)Page.FindControlRecursive(CurrentKPClinicalDirectorID);
                kpCDSaved = _m_KPClinicalDirector.SaveData(false);
            }
            else
                kpCDSaved = true;

            if (sldrKPHM.Visible)
            {
                if (rbKPHM.Checked)
                    SavePrimaryFACAdmin(Convert.ToDecimal(rbKPHM.Attributes["PFAID"]));
                _m_KPHouseManager = (KeyPersonnelEditForm)Page.FindControlRecursive(CurrentKPHouseManagerID);
                kpHMSaved = _m_KPHouseManager.SaveData(false);
            }
            else
                kpHMSaved = true;

            if (sldrKPRNC.Visible)
            {
                if (rbKPRNC.Checked)
                    SavePrimaryFACAdmin(Convert.ToDecimal(rbKPRNC.Attributes["PFAID"]));
                _m_KPRNCoordinator = (KeyPersonnelEditForm)Page.FindControlRecursive(CurrentKPRNCoordinatorID);
                kpRNCSaved = _m_KPRNCoordinator.SaveData(false);
            }
            else
                kpRNCSaved = true;

            if (kp1Saved
                && kp2Saved
                && kp3Saved
                && kp4Saved
                && kp5Saved
                && kp6Saved
                && kp7Saved
                && kpRNSaved
                && kpPhysAsstSaved
                && kpLPNSaved
                && kpCDSaved
                && kpHMSaved
                && kpRNCSaved
               )
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private void SavePrimaryFACAdmin(decimal personID)
        {
            foreach (BO_ProviderPerson boPP in CurrentKeyPersonnelList)
            {
                if (boPP.PersonID == personID)
                    boPP.PrimaryFacAdmin = "1";
                else
                    boPP.PrimaryFacAdmin = "0";
            }
        }

        private void _LoadKeyPersonnelControls()
        {
            _m_KPAdminEF = (KeyPersonnelEditForm) LoadControl( "~/AppControl/KeyPersonnelEditForm.ascx" );
            pnlKPAdministrator.Controls.Add( _m_KPAdminEF );
            _m_KPAdminEF.EnableViewState = true;
            _m_KPAdminEF.ID = CurrentKPAdministratorControlID;

            _m_KPAltAdminEF = (KeyPersonnelEditForm) LoadControl( "~/AppControl/KeyPersonnelEditForm.ascx" );
            pnlKPAltAdministrator.Controls.Add( _m_KPAltAdminEF );
            _m_KPAltAdminEF.EnableViewState = true;
            _m_KPAltAdminEF.ID = CurrentKPAltAdministratorControlID;

            _m_KPDONEF = (KeyPersonnelEditForm) LoadControl( "~/AppControl/KeyPersonnelEditForm.ascx" );
            pnlKPDON.Controls.Add( _m_KPDONEF );
            _m_KPDONEF.EnableViewState = true;
            _m_KPDONEF.ID = CurrentKPDONControlID;

            _m_KPAltDONEF = (KeyPersonnelEditForm) LoadControl( "~/AppControl/KeyPersonnelEditForm.ascx" );
            pnlKPAltDON.Controls.Add( _m_KPAltDONEF );
            _m_KPAltDONEF.EnableViewState = true;
            _m_KPAltDONEF.ID = CurrentKPAltDonControlID;

            _m_KPDirectorEF = (KeyPersonnelEditForm) LoadControl( "~/AppControl/KeyPersonnelEditForm.ascx" );
            pnlKPDirector.Controls.Add( _m_KPDirectorEF );
            _m_KPDirectorEF.EnableViewState = true;
            _m_KPDirectorEF.ID = CurrentKPDirectorControlID;

            _m_KPMedDirectorEF = (KeyPersonnelEditForm) LoadControl( "~/AppControl/KeyPersonnelEditForm.ascx" );
            pnlKPMedDirector.Controls.Add( _m_KPMedDirectorEF );
            _m_KPMedDirectorEF.EnableViewState = true;
            _m_KPMedDirectorEF.ID = CurrentKPMedDirectorControlID;

            _m_KPFacilityRnEF = (KeyPersonnelEditForm) LoadControl( "~/AppControl/KeyPersonnelEditForm.ascx" );
            pnlKPFacilityRn.Controls.Add( _m_KPFacilityRnEF );
            _m_KPFacilityRnEF.EnableViewState = true;
            _m_KPFacilityRnEF.ID = CurrentKPFacilityRnControlID;

            _m_KPRNEF = (KeyPersonnelEditForm) LoadControl( "~/AppControl/KeyPersonnelEditForm.ascx" );
            pnlKPRN.Controls.Add( _m_KPRNEF );
            _m_KPRNEF.EnableViewState = true;
            _m_KPRNEF.ID = CurrentKPRNControlID;

            _m_KPPhysAsstEF = (KeyPersonnelEditForm)LoadControl("~/AppControl/KeyPersonnelEditForm.ascx");
            pnlKPPhysAsst.Controls.Add(_m_KPPhysAsstEF);
            _m_KPPhysAsstEF.EnableViewState = true;
            _m_KPPhysAsstEF.ID = CurrentKPPhysAsstControlID;

            _m_KPLPNEF = (KeyPersonnelEditForm)LoadControl("~/AppControl/KeyPersonnelEditForm.ascx");
            pnlKPLPN.Controls.Add(_m_KPLPNEF);
            _m_KPLPNEF.EnableViewState = true;
            _m_KPLPNEF.ID = CurrentKPLPNControlID;

            _m_KPClinicalDirector = (KeyPersonnelEditForm)LoadControl("~/AppControl/KeyPersonnelEditForm.ascx");
            pnlKPCD.Controls.Add(_m_KPClinicalDirector);
            _m_KPClinicalDirector.EnableViewState = true;
            _m_KPClinicalDirector.ID = CurrentKPClinicalDirectorID;

            _m_KPHouseManager = (KeyPersonnelEditForm)LoadControl("~/AppControl/KeyPersonnelEditForm.ascx");
            pnlKPHM.Controls.Add(_m_KPHouseManager);
            _m_KPHouseManager.EnableViewState = true;
            _m_KPHouseManager.ID = CurrentKPHouseManagerID;

            _m_KPRNCoordinator = (KeyPersonnelEditForm)LoadControl("~/AppControl/KeyPersonnelEditForm.ascx");
            pnlKPRNC.Controls.Add(_m_KPRNCoordinator);
            _m_KPRNCoordinator.EnableViewState = true;
            _m_KPRNCoordinator.ID = CurrentKPRNCoordinatorID;

        }

        private void _ShowHideLabelPersChange()
        {
            if (CurrentAppProvider != null)
            {
                if (CurrentAppProvider.BusinessProcessID != null 
                    && CurrentAppProvider.BusinessProcessID.Trim().Equals("2")
                    && !CurrentAppProvider.ApplicationAction.Equals("4"))
                {
                    /* 
                     * INITIAL LICENSING: hide question for key personnel change 
                     * and default the option value to "Yes"
                     */
                    labelPersChange.Visible = false;
                    chkKeyPersChangeNo.Visible = false;
                    chkKeyPersChangeYes.Visible = false;

                    chkKeyPersChangeYes.Checked = true;
                    AllowEdit = true;
                }
                else
                {
                    /* 
                     * All other License types: Make visible and default to "No". 
                     * If section modified on an application then default to YES and make readonly.
                     */
                    labelPersChange.Visible = true;
                    chkKeyPersChangeNo.Visible = true;
                    chkKeyPersChangeYes.Visible = true;

                    // check the KeyPersonnelChange flag
                    if (CurrentAppProvider.KeyPersonnelChange != null
                        && CurrentAppProvider.KeyPersonnelChange.Equals("Y")
                        && !CurrentAppProvider.ApplicationAction.Equals("4"))
                    {
                        chkKeyPersChangeYes.Checked = true;
                        AllowEdit = true;

                        chkKeyPersChangeNo.Enabled = false;
                        chkKeyPersChangeYes.Enabled = false;
                    }
                    else
                    {
                        if ( makeRead )
                        {
                            if ( AllowEdit )
                                chkKeyPersChangeYes.Checked = true;
                            else
                                chkKeyPersChangeNo.Checked = true;
                        }
                        else
                        {
                            chkKeyPersChangeYes.Checked = false;
                            chkKeyPersChangeNo.Checked = true;
                            AllowEdit = false;

                            chkKeyPersChangeNo.Enabled = false;
                            chkKeyPersChangeYes.Enabled = false;
                        }
                    }
                }
                // set the AllowEdit property of the child controls
                SetEditable();
            }
        }

        protected override void OnPreRender( EventArgs e )
        {
            base.OnPreRender( e );
            if ( IsPostBack )
            {
                _Init();
                _ShowHideLabelPersChange();
            }
        }

        private void _Init()
        {
            //Clear Business Objects
            //if ( IsPostBack )
            //{
            //    CurrentKeyPersonnelList
            //}

            //Slider Text and Details are determined by the lookup values and person
            //First get the person types then find the associated person record for
            //loading the underlying details. When finished turn off sections not needed
            //for the current provider type.
            foreach ( BO_LookupValue boLV in PersonType )
            {
                BO_Person tmpPers = null;
                decimal primaryFACAdmin = 0;

                if ( ( "1, 11, 9, 6, 7, 8, 2, 12, 13, 14, 15, 16, 17" ).ToString().Contains( boLV.LookupVal )
                     && ( null == boLV.Allowedtypes || boLV.Allowedtypes.Contains(CurrentAppProvider.ProgramID) )
                    )
                {
                    //boLV.Valdesc = ""; //Force Test of Hidding Sections
                    string tmpTitleText = "<b>" + CommonFunc.ConvertToTitleCase( boLV.Valdesc ) + "</b>";
                    string tmpAddtlTitleText = "";
                    bool PersonFound = false;
                    
                    foreach ( BO_ProviderPerson boPrvdrPers in CurrentKeyPersonnelList )
                    {
                        if ( boPrvdrPers.PersonType.Equals( boLV.LookupVal ) && !boPrvdrPers.Removed )
                        {
                            PersonFound = true;
                            tmpPers = boPrvdrPers.BO_PersonDetail;
                            if (boPrvdrPers.PrimaryFacAdmin == "1")
                                primaryFACAdmin = (decimal)tmpPers.PersonID;
                            break;
                        }
                    }

                    if ( !PersonFound || ( null != tmpPers && tmpPers.IsNewRec ) )
                    {
                        //tmpPers = new BO_Person();
                        tmpAddtlTitleText = "- Not Assigned";
                    }
                    else
                    {
                        tmpAddtlTitleText += "- Current: ";
                        //SMM 01/22/2012- Removed Title case conversion
                        //tmpAddtlTitleText += CommonFunc.ConvertToTitleCase( tmpPers.FirstName );
                        //SMM 01/22/2012- Removed Title case conversion
                        //tmpAddtlTitleText += CommonFunc.ConvertToTitleCase( tmpPers.LastName );
                        //tmpAddtlTitleText += tmpPers.LastName;
                        tmpAddtlTitleText += tmpPers.FirstName + " " + tmpPers.LastName;
                    }

                    switch ( boLV.LookupVal )
                    {
                        case "1": //Administrator
                            if (primaryFACAdmin != 0)
                                rbKPAdministrator.Checked = true;
                                
                            sldrKPAdministrator.TitleText = tmpTitleText;
                            sldrKPAdministrator.AdditionalTitleText = tmpAddtlTitleText;
                            _m_KPAdminEF.PersonType = boLV.LookupVal;
                            if ( !PersonFound )
                                _m_KPAdminEF.IsNewRecord = true;

                            if (null != tmpPers)
                            {
                                rbKPAdministrator.Attributes.Add("PFAID", tmpPers.PersonID.ToString());
                                _m_KPAdminEF.LoadPerson(Convert.ToDecimal(tmpPers.PersonID), AllowEdit);
                            }
                            else
                            {
                                rbKPAdministrator.Attributes.Add("PFAID", "0");
                                _m_KPAdminEF.LoadPerson(0, AllowEdit);
                            }
                            
                            break;
                        case "11": //Alternate Administrator
                            if (primaryFACAdmin != 0)
                                rbKPAltAdministrator.Checked = true;

                            sldrKPAltAdministrator.TitleText = tmpTitleText;
                            sldrKPAltAdministrator.AdditionalTitleText = tmpAddtlTitleText;
                            _m_KPAltAdminEF.PersonType = boLV.LookupVal;
                            if ( !PersonFound )
                                _m_KPAltAdminEF.IsNewRecord = true;

                            if (null != tmpPers)
                            {
                                rbKPAltAdministrator.Attributes.Add("PFAID", tmpPers.PersonID.ToString());
                                _m_KPAltAdminEF.LoadPerson(Convert.ToDecimal(tmpPers.PersonID), AllowEdit);
                            }
                            else
                            {
                                rbKPAltAdministrator.Attributes.Add("PFAID", "0");
                                _m_KPAltAdminEF.LoadPerson(0, AllowEdit);
                            }
                            
                            break;
                        case "9": // Director of Nursing
                            if (primaryFACAdmin != 0)
                                rbKPDON.Checked = true;

                            sldrKPDON.TitleText = tmpTitleText;
                            sldrKPDON.AdditionalTitleText = tmpAddtlTitleText;
                            _m_KPDONEF.PersonType = boLV.LookupVal;
                            if ( !PersonFound )
                                _m_KPDONEF.IsNewRecord = true;

                            if (null != tmpPers)
                            {
                                rbKPDON.Attributes.Add("PFAID", tmpPers.PersonID.ToString());
                                _m_KPDONEF.LoadPerson(Convert.ToDecimal(tmpPers.PersonID), AllowEdit);
                            }
                            else
                            {
                                rbKPDON.Attributes.Add("PFAID", "0");
                                _m_KPDONEF.LoadPerson(0, AllowEdit);
                            }
                            
                            break;
                        case "6": // Alternate Director of Nursing
                            if (primaryFACAdmin != 0)
                                rbKPAltDON.Checked = true;

                            sldrKPAltDON.TitleText = tmpTitleText;
                            sldrKPAltDON.AdditionalTitleText = tmpAddtlTitleText;
                            _m_KPAltDONEF.PersonType = boLV.LookupVal;
                            if ( !PersonFound )
                                _m_KPAltDONEF.IsNewRecord = true;

                            if (null != tmpPers)
                            {
                                rbKPAltDON.Attributes.Add("PFAID", tmpPers.PersonID.ToString());
                                _m_KPAltDONEF.LoadPerson(Convert.ToDecimal(tmpPers.PersonID), AllowEdit);
                            }
                            else
                            {
                                rbKPAltDON.Attributes.Add("PFAID", "0");
                                _m_KPAltDONEF.LoadPerson(0, AllowEdit);
                            }

                            break;
                        case "7": // RN Coordinator
                            if (primaryFACAdmin != 0)
                                rbKPRNC.Checked = true;

                            sldrKPRNC.TitleText = tmpTitleText;
                            sldrKPRNC.AdditionalTitleText = tmpAddtlTitleText;
                            _m_KPRNCoordinator.PersonType = boLV.LookupVal;
                            if (!PersonFound)
                                _m_KPRNCoordinator.IsNewRecord = true;

                            if (null != tmpPers)
                            {
                                rbKPRNC.Attributes.Add("PFAID", tmpPers.PersonID.ToString());
                                _m_KPRNCoordinator.LoadPerson(Convert.ToDecimal(tmpPers.PersonID), AllowEdit);
                            }
                            else
                            {
                                rbKPRNC.Attributes.Add("PFAID", "0");
                                _m_KPRNCoordinator.LoadPerson(0, AllowEdit);
                            }

                            break;
                        case "8": // Director
                            if (primaryFACAdmin != 0)
                                rbKPDirector.Checked = true;

                            sldrKPDirector.TitleText = tmpTitleText;
                            sldrKPDirector.AdditionalTitleText = tmpAddtlTitleText;
                            _m_KPDirectorEF.PersonType = boLV.LookupVal;
                            if ( !PersonFound )
                                _m_KPDirectorEF.IsNewRecord = true;

                            if (null != tmpPers)
                            {
                                rbKPDirector.Attributes.Add("PFAID", tmpPers.PersonID.ToString());
                                _m_KPDirectorEF.LoadPerson(Convert.ToDecimal(tmpPers.PersonID), AllowEdit);
                            }
                            else
                            {
                                rbKPDirector.Attributes.Add("PFAID", "0");
                                _m_KPDirectorEF.LoadPerson(0, AllowEdit);
                            }

                            break;
                        case "2": // Medical Director
                            if (primaryFACAdmin != 0)
                                rbKPMedDirector.Checked = true;

                            sldrKPMedDirector.TitleText = tmpTitleText;
                            sldrKPMedDirector.AdditionalTitleText = tmpAddtlTitleText;
                            _m_KPMedDirectorEF.PersonType = boLV.LookupVal;
                            if ( !PersonFound )
                                _m_KPMedDirectorEF.IsNewRecord = true;

                            if (null != tmpPers)
                            {
                                rbKPMedDirector.Attributes.Add("PFAID", tmpPers.PersonID.ToString());
                                _m_KPMedDirectorEF.LoadPerson(Convert.ToDecimal(tmpPers.PersonID), AllowEdit);
                            }
                            else
                            {
                                rbKPMedDirector.Attributes.Add("PFAID", "0");
                                _m_KPMedDirectorEF.LoadPerson(0, AllowEdit);
                            }

                            break;
                        case "12": // Facility RN
                            if (primaryFACAdmin != 0)
                                rbKPFacilityRn.Checked = true;

                            sldrKPFacilityRn.TitleText = tmpTitleText;
                            sldrKPFacilityRn.AdditionalTitleText = tmpAddtlTitleText;
                            _m_KPFacilityRnEF.PersonType = boLV.LookupVal;
                            if ( !PersonFound )
                                _m_KPFacilityRnEF.IsNewRecord = true;

                            if (null != tmpPers)
                            {
                                rbKPFacilityRn.Attributes.Add("PFAID", tmpPers.PersonID.ToString());
                                _m_KPFacilityRnEF.LoadPerson(Convert.ToDecimal(tmpPers.PersonID), AllowEdit);
                            }
                            else
                            {
                                rbKPFacilityRn.Attributes.Add("PFAID", "0");
                                _m_KPFacilityRnEF.LoadPerson(0, AllowEdit);
                            }

                            break;
                        case "13": // RN
                            if (primaryFACAdmin != 0)
                                rbKPRN.Checked = true;

                            sldrKPRN.TitleText = tmpTitleText;
                            sldrKPRN.AdditionalTitleText = tmpAddtlTitleText;
                            _m_KPRNEF.PersonType = boLV.LookupVal;
                            if (!PersonFound)
                                _m_KPRNEF.IsNewRecord = true;

                            if (null != tmpPers) {
                                rbKPRN.Attributes.Add("PFAID", tmpPers.PersonID.ToString());
                                _m_KPRNEF.LoadPerson(Convert.ToDecimal(tmpPers.PersonID), AllowEdit);
                            }
                            else {
                                rbKPRN.Attributes.Add("PFAID", "0");
                                _m_KPRNEF.LoadPerson(0, AllowEdit);
                            }

                            break;

                        case "14": // Phys Asst
                            if (primaryFACAdmin != 0)
                                rbKPPhysAsst.Checked = true;

                            sldrKPPhysAsst.TitleText = tmpTitleText;
                            sldrKPPhysAsst.AdditionalTitleText = tmpAddtlTitleText;
                            _m_KPPhysAsstEF.PersonType = boLV.LookupVal;
                            if (!PersonFound)
                                _m_KPPhysAsstEF.IsNewRecord = true;

                            if (null != tmpPers) {
                                rbKPPhysAsst.Attributes.Add("PFAID", tmpPers.PersonID.ToString());
                                _m_KPPhysAsstEF.LoadPerson(Convert.ToDecimal(tmpPers.PersonID), AllowEdit);
                            }
                            else {
                                rbKPPhysAsst.Attributes.Add("PFAID", "0");
                                _m_KPPhysAsstEF.LoadPerson(0, AllowEdit);
                            }

                            break;

                        case "15": // LPN
                            if (primaryFACAdmin != 0)
                                rbKPLPN.Checked = true;

                            sldrKPLPN.TitleText = tmpTitleText;
                            sldrKPLPN.AdditionalTitleText = tmpAddtlTitleText;
                            _m_KPLPNEF.PersonType = boLV.LookupVal;
                            if (!PersonFound)
                                _m_KPLPNEF.IsNewRecord = true;

                            if (null != tmpPers) {
                                rbKPLPN.Attributes.Add("PFAID", tmpPers.PersonID.ToString());
                                _m_KPLPNEF.LoadPerson(Convert.ToDecimal(tmpPers.PersonID), AllowEdit);
                            }
                            else {
                                rbKPLPN.Attributes.Add("PFAID", "0");
                                _m_KPLPNEF.LoadPerson(0, AllowEdit);
                            }

                            break;

                        case "16": // Clinical Director
                            if (primaryFACAdmin != 0)
                                rbKPCD.Checked = true;

                            sldrKPCD.TitleText = tmpTitleText;
                            sldrKPCD.AdditionalTitleText = tmpAddtlTitleText;
                            _m_KPClinicalDirector.PersonType = boLV.LookupVal;
                            if (!PersonFound)
                                _m_KPClinicalDirector.IsNewRecord = true;

                            if (null != tmpPers)
                            {
                                rbKPCD.Attributes.Add("PFAID", tmpPers.PersonID.ToString());
                                _m_KPClinicalDirector.LoadPerson(Convert.ToDecimal(tmpPers.PersonID), AllowEdit);
                            }
                            else
                            {
                                rbKPCD.Attributes.Add("PFAID", "0");
                                _m_KPClinicalDirector.LoadPerson(0, AllowEdit);
                            }

                            break;

                        case "17": // House Manager 
                            if (primaryFACAdmin != 0)
                                rbKPLPN.Checked = true;

                            sldrKPHM.TitleText = tmpTitleText;
                            sldrKPHM.AdditionalTitleText = tmpAddtlTitleText;
                            _m_KPHouseManager.PersonType = boLV.LookupVal;
                            if (!PersonFound)
                                _m_KPHouseManager.IsNewRecord = true;

                            if (null != tmpPers)
                            {
                                rbKPHM.Attributes.Add("PFAID", tmpPers.PersonID.ToString());
                                _m_KPHouseManager.LoadPerson(Convert.ToDecimal(tmpPers.PersonID), AllowEdit);
                            }
                            else
                            {
                                rbKPHM.Attributes.Add("PFAID", "0");
                                _m_KPHouseManager.LoadPerson(0, AllowEdit);
                            }

                            break;

                    }
                }
            }

            //Once loaded check each control for titletext and if nothing entered then hide it.
            if (string.IsNullOrEmpty(sldrKPAdministrator.TitleText) || sldrKPAdministrator.TitleText.Equals("<b></b>"))
            {
                sldrKPAdministrator.Visible = false;
                rbKPAdministrator.Visible = false;
            }
            if (string.IsNullOrEmpty(sldrKPAltAdministrator.TitleText) || sldrKPAltAdministrator.TitleText.Equals("<b></b>"))
            {
                sldrKPAltAdministrator.Visible = false;
                rbKPAltAdministrator.Visible = false;
            }
            if (string.IsNullOrEmpty(sldrKPDON.TitleText) || sldrKPDON.TitleText.Equals("<b></b>"))
            {
                sldrKPDON.Visible = false;
                rbKPDON.Visible = false;
            }
            if (string.IsNullOrEmpty(sldrKPAltDON.TitleText) || sldrKPAltDON.TitleText.Equals("<b></b>"))
            {
                sldrKPAltDON.Visible = false;
                rbKPAltDON.Visible = false;
            }
            if (string.IsNullOrEmpty(sldrKPDirector.TitleText) || sldrKPDirector.TitleText.Equals("<b></b>"))
            {
                sldrKPDirector.Visible = false;
                rbKPDirector.Visible = false;
            }
            if (string.IsNullOrEmpty(sldrKPMedDirector.TitleText) || sldrKPMedDirector.TitleText.Equals("<b></b>"))
            {
                sldrKPMedDirector.Visible = false;
                rbKPMedDirector.Visible = false;
            }
            if (string.IsNullOrEmpty(sldrKPFacilityRn.TitleText) || sldrKPFacilityRn.TitleText.Equals("<b></b>"))
            {
                sldrKPFacilityRn.Visible = false;
                rbKPFacilityRn.Visible = false;
            }
            if (string.IsNullOrEmpty(sldrKPRN.TitleText) || sldrKPRN.TitleText.Equals("<b></b>")) {
                sldrKPRN.Visible = false;
                rbKPRN.Visible = false;
            }
            if (string.IsNullOrEmpty(sldrKPPhysAsst.TitleText) || sldrKPPhysAsst.TitleText.Equals("<b></b>")) {
                sldrKPPhysAsst.Visible = false;
                rbKPPhysAsst.Visible = false;
            }
            if (string.IsNullOrEmpty(sldrKPLPN.TitleText) || sldrKPLPN.TitleText.Equals("<b></b>")) {
                sldrKPLPN.Visible = false;
                rbKPLPN.Visible = false;
            }
            if (string.IsNullOrEmpty(sldrKPCD.TitleText) || sldrKPCD.TitleText.Equals("<b></b>"))
            {
                sldrKPCD.Visible = false;
                rbKPCD.Visible = false;
            }
            if (string.IsNullOrEmpty(sldrKPHM.TitleText) || sldrKPHM.TitleText.Equals("<b></b>"))
            {
                sldrKPHM.Visible = false;
                rbKPHM.Visible = false;
            }
            if (string.IsNullOrEmpty(sldrKPRNC.TitleText) || sldrKPRNC.TitleText.Equals("<b></b>"))
            {
                sldrKPRNC.Visible = false;
                rbKPRNC.Visible = false;
            }

        }

        private void _ShowHideFields()
        {
            if (Session["userType"].ToString() == "Public")
            {
                if (CurrentAppProvider.BusinessProcessID == "4" || CurrentAppProvider.BusinessProcessID == "5" || CurrentAppProvider.BusinessProcessID == "6" || CurrentAppProvider.BusinessProcessID == "7" || CurrentAppProvider.BusinessProcessID == "8" || CurrentAppProvider.BusinessProcessID == "10" || CurrentAppProvider.ApplicationStatus.Equals("4"))
                {
                    chkKeyPersChangeNo.Enabled = false;
                    chkKeyPersChangeYes.Enabled = false;
                }
            }

            if ( CurrentAppProvider.ProgramID.Equals( "HC" ) )
            {
                sldrKPAltAdministrator.Visible = false;
                sldrKPDON.Visible = false;
                sldrKPAltDON.Visible = false;
                sldrKPDirector.Visible = false;
                sldrKPMedDirector.Visible = false;
                sldrKPFacilityRn.Visible = false;
                sldrKPCD.Visible = false;
                sldrKPHM.Visible = false;
                sldrKPRN.Visible = false;
            }

        }

        protected void PersChange_CheckedChanged( object sender, EventArgs e )
        {
            RadioButton tmpChkBx = (RadioButton) sender;

            if ( tmpChkBx.Text.Equals( "Yes" ) )
            {
                AllowEdit = true;
            }
            else
            {
                AllowEdit = false;
            }

            // set the AllowEdit property of the child controls
            SetEditable();
        }

        /// <summary>
        /// Can be called from two different code execution paths:
        /// 1) _ShowHideLabelPersChange()
        /// 2) PersChange_CheckedChanged
        /// </summary>
        private void SetEditable()
        {
            _m_KPAdminEF = (KeyPersonnelEditForm)Page.FindControlRecursive(CurrentKPAdministratorControlID);
            _m_KPAltAdminEF = (KeyPersonnelEditForm)Page.FindControlRecursive(CurrentKPAltAdministratorControlID);
            _m_KPDONEF = (KeyPersonnelEditForm)Page.FindControlRecursive(CurrentKPDONControlID);
            _m_KPAltDONEF = (KeyPersonnelEditForm)Page.FindControlRecursive(CurrentKPAltDonControlID);
            _m_KPDirectorEF = (KeyPersonnelEditForm)Page.FindControlRecursive(CurrentKPDirectorControlID);
            _m_KPMedDirectorEF = (KeyPersonnelEditForm) Page.FindControlRecursive( CurrentKPMedDirectorControlID );
            _m_KPFacilityRnEF = (KeyPersonnelEditForm) Page.FindControlRecursive( CurrentKPFacilityRnControlID );
            _m_KPRNEF = (KeyPersonnelEditForm) Page.FindControlRecursive( CurrentKPRNControlID );
            _m_KPPhysAsstEF = (KeyPersonnelEditForm) Page.FindControlRecursive( CurrentKPPhysAsstControlID );
            _m_KPLPNEF = (KeyPersonnelEditForm)Page.FindControlRecursive(CurrentKPLPNControlID);
            _m_KPClinicalDirector = (KeyPersonnelEditForm)Page.FindControlRecursive(CurrentKPClinicalDirectorID);
            _m_KPHouseManager = (KeyPersonnelEditForm)Page.FindControlRecursive(CurrentKPHouseManagerID);

            _m_KPAdminEF.AllowEdit = AllowEdit;
            _m_KPAdminEF.setNewPersonActive( AllowEdit );

            _m_KPAltAdminEF.AllowEdit = AllowEdit;
            _m_KPAltAdminEF.setNewPersonActive( AllowEdit );
            
            _m_KPDONEF.AllowEdit = AllowEdit;
            _m_KPDONEF.setNewPersonActive( AllowEdit );
            
            _m_KPAltDONEF.AllowEdit = AllowEdit;
            _m_KPAltDONEF.setNewPersonActive( AllowEdit );
            
            _m_KPDirectorEF.AllowEdit = AllowEdit;
            _m_KPDirectorEF.setNewPersonActive( AllowEdit );
            
            _m_KPMedDirectorEF.AllowEdit = AllowEdit;
            _m_KPMedDirectorEF.setNewPersonActive( AllowEdit );

            _m_KPFacilityRnEF.AllowEdit = AllowEdit;
            _m_KPFacilityRnEF.setNewPersonActive( AllowEdit );

            _m_KPRNEF.AllowEdit = AllowEdit;
            _m_KPRNEF.setNewPersonActive(AllowEdit);

            _m_KPPhysAsstEF.AllowEdit = AllowEdit;
            _m_KPPhysAsstEF.setNewPersonActive(AllowEdit);

            _m_KPLPNEF.AllowEdit = AllowEdit;
            _m_KPLPNEF.setNewPersonActive(AllowEdit);

            _m_KPClinicalDirector.AllowEdit = AllowEdit;
            _m_KPClinicalDirector.setNewPersonActive(AllowEdit);

            _m_KPHouseManager.AllowEdit = AllowEdit;
            _m_KPHouseManager.setNewPersonActive(AllowEdit);
        }

        #region Members
        private KeyPersonnelEditForm _m_KPAdminEF = null;
        private KeyPersonnelEditForm _m_KPAltAdminEF = null;
        private KeyPersonnelEditForm _m_KPDONEF = null;
        private KeyPersonnelEditForm _m_KPAltDONEF = null;
        private KeyPersonnelEditForm _m_KPDirectorEF = null;
        private KeyPersonnelEditForm _m_KPMedDirectorEF = null;
        private KeyPersonnelEditForm _m_KPFacilityRnEF = null;
        private KeyPersonnelEditForm _m_KPRNEF = null;
        private KeyPersonnelEditForm _m_KPPhysAsstEF = null;
        private KeyPersonnelEditForm _m_KPLPNEF = null;
        private KeyPersonnelEditForm _m_KPClinicalDirector = null;
        private KeyPersonnelEditForm _m_KPHouseManager = null;
        private KeyPersonnelEditForm _m_KPRNCoordinator = null;

        private BO_Application _m_AppProvider = null;
        private bool IsDirty = false;

        private bool makeRead
        {
            get
            {
                return ( null != ViewState["makeRead"] ? (bool) ViewState["makeRead"] : false );
            }
            set
            {
                ViewState["makeRead"] = value;
            }
        }
        
        private bool AllowEdit
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
        
        private BO_LookupValues PersonType
        {
            get
            {
                BO_LookupValues retLkups = new BO_LookupValues();
                //if ( Session["PersonType"] == null )
                //{
                    BO_LookupValues tmpLkups = BO_LookupValue.SelectByField( BO_LookupValueFields.LookupKey, "PERSON_TYPE" );
                    foreach ( BO_LookupValue tmpLV in tmpLkups )
                    {
                        if ( tmpLV.Allowedtypes == null || 
                             tmpLV.Allowedtypes.Contains( CurrentAppProvider.ProgramID ) || 
                             tmpLV.Allowedtypes.Equals( "" ) 
                            )
                            retLkups.Add( tmpLV );
                    }
                //}
                //else
                //    retLkups = (BO_LookupValues) Session["PersonType"];

                //PersonType = retLkups;

                return retLkups;
            }
            set
            {
                Session["PersonType"] = value;
            }
        }

        private BO_Application CurrentAppProvider
        {
            get
            {
                return Session["CurrentAppProvider"] == null ? null : (BO_Application) Session["CurrentAppProvider"];
            }
        }

        private BO_ProviderPeople CurrentKeyPersonnelList
        {
            get
            {
                BO_ProviderPeople tmpList;

                if ( CurrentAppProvider != null && CurrentAppProvider.BO_ProviderPeopleApplicationID != null )
                {
                    tmpList = CurrentAppProvider.BO_ProviderPeopleApplicationID;
                }
                else
                {
                    tmpList = new BO_ProviderPeople();
                }
                return tmpList;
            }
            set
            {
                CurrentAppProvider.BO_ProviderPeopleApplicationID = value;
            }
        }

        private string CurrentKPAdministratorControlID = "KPAdministrator";
        private string CurrentKPAltAdministratorControlID = "KPAltAdministrator";
        private string CurrentKPDONControlID = "KPDON";
        private string CurrentKPAltDonControlID = "KPAltDON";
        private string CurrentKPDirectorControlID = "KPDirector";
        private string CurrentKPMedDirectorControlID = "KPMedDirector";
        private string CurrentKPFacilityRnControlID = "KPFacilityRn";
        private string CurrentKPRNControlID = "KPRN";
        private string CurrentKPPhysAsstControlID = "KPPhysAsst";
        private string CurrentKPLPNControlID = "KPLPN";
        private string CurrentKPClinicalDirectorID = "KPCD";
        private string CurrentKPHouseManagerID = "KPHM";
        private string CurrentKPRNCoordinatorID = "KPRNC";

        #endregion
    }
}