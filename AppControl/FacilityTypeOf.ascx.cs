using System;
using System.Data;
using System.Text;
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
    public partial class FacilityTypeOf : System.Web.UI.UserControl
    {
        //protected override void OnInit(EventArgs e)
        //{
        //    base.OnInit(e);
        //}
        
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        
        public void LoadApplication(string inKeyID, bool inAllowEdit, bool inIsOffsiteAffil)
        {
            IsOffSite = inIsOffsiteAffil;
            AllowEdit = inAllowEdit;

            _LoadValues();
            _ShowHideFields();
        }
                
        private void _ShowHideFields()
        {
            //Turn off all sections first then enable them by program type and location
            divBR_ProviderType.Visible = false;
            divResidential.Visible = false;
            divComLiving.Visible = false;
            divOutpatient.Visible = false;
            divHP_ProviderType.Visible = false;
            divHH_ProviderType.Visible = false;
            divAS_ProviderType.Visible = false;
            divNH_ProviderType.Visible = false;
            divCO_ProviderType.Visible = false;
            divHO_ProviderType.Visible = false;
            divPT_ProviderType.Visible = false;

            switch (CurrentAppProvider.ProgramID)
            {
                case "HC":
                    //divBR_ProviderType.Visible = true;
                    divResidential.Visible = true;
                    divComLiving.Visible = true;
                    divOutpatient.Visible = true;
                    break;
                case "HO": 
                    //divBR_ProviderType.Visible = true;
                    divResidential.Visible = true;
                    divComLiving.Visible = true;
                    divOutpatient.Visible = true;
                    divHO_ProviderType.Visible = true;
                    break;
                case "BR":
                    divBR_ProviderType.Visible = true;
                    divResidential.Visible = true;
                    divComLiving.Visible = true;
                    divOutpatient.Visible = true;
                    break;
                case "HP":
                    divHP_ProviderType.Visible = true;
                    break;
                case "HH":
                    divHH_ProviderType.Visible = true;
                    break;
                case "AS":
                    divAS_ProviderType.Visible = true;
                    break;
                case "NH":
                    divNH_ProviderType.Visible = true;
                    break;
                case "CO":
                    divCO_ProviderType.Visible = true;
                    break;
                case "PT":
                    divPT_ProviderType.Visible = true;
                    break;
            }

            //Always disabled for offsites regardless of type provider
            if (IsOffSite)
            {
                divComLiving.Visible = false;
            }

            if ( !AllowEdit )
            {
                chkBR_Residential.Enabled = false;
                txtBR_ResCapacity.Enabled = false;
                chkBR_CommLiving.Enabled = false;
                chkBR_Outpatient.Enabled = false;
                CheckBoxDayOfOperationMon.Enabled = false;
                CheckBoxDayOfOperationTue.Enabled = false;
                CheckBoxDayOfOperationWed.Enabled = false;
                CheckBoxDayOfOperationThu.Enabled = false;
                CheckBoxDayOfOperationFri.Enabled = false;
                CheckBoxDayOfOperationSat.Enabled = false;
                CheckBoxDayOfOperationSun.Enabled = false;
                txtHoursMinutesFrom.Enabled = false;
                listAmPmFrom.Enabled = false;
                txtHoursMinutesTo.Enabled = false;
                listAmPmTo.Enabled = false;

                listHP_ProviderType.Enabled = false;
                listHP_Accred.Enabled = false;
                listMedicareCertified.Enabled = false;
                listHP_HospitalBased.Enabled = false;
                txtHP_FYE.Enabled = false;

                listHH_Accred.Enabled = false;
                listHH_Deemed.Enabled = false;
                txtHH_FYE.Enabled = false;
                listHH_HospBased.Enabled = false;

                listAS_Deemed.Enabled = false;
                txtAS_FYE.Enabled = false;
                chkAS_HospitalBased.Enabled = false;
                chkAS_FreeStanding.Enabled = false;

                radMultiFacAdminYes.Enabled = false;
                radMultiFacAdminNo.Enabled = false;
                txtNHAdminOtherFacName.Enabled = false;
                radSingleStory.Enabled = false;
                radMultiStory.Enabled = false;

                txtCO_FYE.Enabled = false;
                txtHO_FYE.Enabled = false;

            }

        }

        private void _LoadValues()
        {
            #region Clear values prior to loading (checks, text, lists, etc.)
            chkBR_Residential.Checked = false;
            txtBR_ResCapacity.Text = null;
            chkBR_Outpatient.Checked = false;
            CheckBoxDayOfOperationMon.Checked = false;
            CheckBoxDayOfOperationTue.Checked = false;
            CheckBoxDayOfOperationWed.Checked = false;
            CheckBoxDayOfOperationThu.Checked = false;
            CheckBoxDayOfOperationFri.Checked = false;
            CheckBoxDayOfOperationSat.Checked = false;
            CheckBoxDayOfOperationSun.Checked = false;
            txtHoursMinutesFrom.Text = null;
            listAmPmFrom.ClearSelection();
            txtHoursMinutesTo.Text = null;
            listAmPmTo.ClearSelection();

            listHP_ProviderType.ClearSelection();
            listHP_Accred.ClearSelection();
            listMedicareCertified.ClearSelection();
            listHP_HospitalBased.ClearSelection();
            txtHP_FYE.Text = null;

            listHH_Accred.ClearSelection();
            listHH_Deemed.ClearSelection();
            txtHH_FYE.Text = null;
            listHH_HospBased.ClearSelection();

            chkAS_HospitalBased.Checked = false;
            chkAS_FreeStanding.Checked = false;

            #endregion

            #region Load BR Values
            if (("BR").Contains(CurrentAppProvider.ProgramID))
            {
                if (!IsOffSite)
                {
                    if (null != CurrentAppProvider.BO_ServicesApplicationID)
                    {
                        foreach (BO_Service tmpSvc in CurrentAppProvider.BO_ServicesApplicationID)
                        {
                            switch (tmpSvc.ServiceType)
                            {
                                case "01": //Residential
                                    chkBR_Residential.Checked = true;
                                    txtBR_ResCapacity.Text = tmpSvc.Capacity.Value.ToString();
                                    break;
                                case "02": //Community Living
                                    chkBR_CommLiving.Checked = true;
                                    break;
                                case "03": //Outpatient
                                    chkBR_Outpatient.Checked = true;
                                    CheckBoxDayOfOperationMon.Checked = (null != tmpSvc.DayOfOperationMon && tmpSvc.DayOfOperationMon.Equals("1"));
                                    CheckBoxDayOfOperationTue.Checked = (null != tmpSvc.DayOfOperationTue && tmpSvc.DayOfOperationTue.Equals("1"));
                                    CheckBoxDayOfOperationWed.Checked = (null != tmpSvc.DayOfOperationWed && tmpSvc.DayOfOperationWed.Equals("1"));
                                    CheckBoxDayOfOperationThu.Checked = (null != tmpSvc.DayOfOperationThu && tmpSvc.DayOfOperationThu.Equals("1"));
                                    CheckBoxDayOfOperationFri.Checked = (null != tmpSvc.DayOfOperationFri && tmpSvc.DayOfOperationFri.Equals("1"));
                                    CheckBoxDayOfOperationSat.Checked = (null != tmpSvc.DayOfOperationSat && tmpSvc.DayOfOperationSat.Equals("1"));
                                    CheckBoxDayOfOperationSun.Checked = (null != tmpSvc.DayOfOperationSun && tmpSvc.DayOfOperationSun.Equals("1"));

                                    txtHoursMinutesFrom.Text = (null != tmpSvc.OperatingHoursFromTime ? tmpSvc.OperatingHoursFromTime : "");
                                    listAmPmFrom.SelectedValue = (null != tmpSvc.OperatingHoursFromMeridiem ? tmpSvc.OperatingHoursFromMeridiem : "");
                                    txtHoursMinutesTo.Text = (null != tmpSvc.OperatingHoursToTime ? tmpSvc.OperatingHoursToTime : "");
                                    listAmPmTo.SelectedValue = (null != tmpSvc.OperatingHoursToMeridiem ? tmpSvc.OperatingHoursToMeridiem : "");
                                    break;
                            }
                        }
                    }
                }
                else
                {
                    tblComLiving.Visible = false;

                    foreach (BO_Affiliation tmpAffil in CurrentAppProvider.BO_AffiliationsApplicationID)
                    {
                        if (tmpAffil.UI_TrackID.Equals(CurrentAffiliationID) && null != tmpAffil.BO_ServicesAffiliationID)
                        {
                            foreach (BO_Service tmpSvc in tmpAffil.BO_ServicesAffiliationID)
                            {
                                switch (tmpSvc.ServiceType)
                                {
                                    case "01": //Residential
                                        chkBR_Residential.Checked = true;
                                        txtBR_ResCapacity.Text = tmpSvc.Capacity.Value.ToString();
                                        break;
                                    case "02": //Community Living
                                        chkBR_CommLiving.Checked = true;
                                        break;
                                    case "03": //Outpatient
                                        chkBR_Outpatient.Checked = true;
                                        CheckBoxDayOfOperationMon.Checked = (null != tmpSvc.DayOfOperationMon && tmpSvc.DayOfOperationMon.Equals("1"));
                                        CheckBoxDayOfOperationTue.Checked = (null != tmpSvc.DayOfOperationTue && tmpSvc.DayOfOperationTue.Equals("1"));
                                        CheckBoxDayOfOperationWed.Checked = (null != tmpSvc.DayOfOperationWed && tmpSvc.DayOfOperationWed.Equals("1"));
                                        CheckBoxDayOfOperationThu.Checked = (null != tmpSvc.DayOfOperationThu && tmpSvc.DayOfOperationThu.Equals("1"));
                                        CheckBoxDayOfOperationFri.Checked = (null != tmpSvc.DayOfOperationFri && tmpSvc.DayOfOperationFri.Equals("1"));
                                        CheckBoxDayOfOperationSat.Checked = (null != tmpSvc.DayOfOperationSat && tmpSvc.DayOfOperationSat.Equals("1"));
                                        CheckBoxDayOfOperationSun.Checked = (null != tmpSvc.DayOfOperationSun && tmpSvc.DayOfOperationSun.Equals("1"));

                                        txtHoursMinutesFrom.Text = (null != tmpSvc.OperatingHoursFromTime ? tmpSvc.OperatingHoursFromTime : "");
                                        listAmPmFrom.SelectedValue = (null != tmpSvc.OperatingHoursFromMeridiem ? tmpSvc.OperatingHoursFromMeridiem : "");
                                        txtHoursMinutesTo.Text = (null != tmpSvc.OperatingHoursToTime ? tmpSvc.OperatingHoursToTime : "");
                                        listAmPmTo.SelectedValue = (null != tmpSvc.OperatingHoursToMeridiem ? tmpSvc.OperatingHoursToMeridiem : "");
                                        break;
                                }
                            }
                        }
                    }
                }
            }

            #endregion

            #region Load HP Values
            if (("HP").Contains(CurrentAppProvider.ProgramID))
            {
                BO_LookupValues ProvTypeLkups = BO_LookupValue.SelectByField(BO_LookupValueFields.LookupKey, "TYPE_FACILITY");

                listHP_ProviderType.AppendDataBoundItems = true;
                listHP_ProviderType.Height = Unit.Pixel(100);
                listHP_ProviderType.Items.Add(new RadComboBoxItem("", ""));

                foreach (BO_LookupValue tmpLU in ProvTypeLkups)
                {
                    if (tmpLU.Allowedtypes.Contains("HP") && !tmpLU.LookupVal.Equals("03"))
                    {
                        if (IsOffSite) // All lookup values for Offsite Location
                        {
                            RadComboBoxItem tmpItm = new RadComboBoxItem();
                            tmpItm.Text = tmpLU.Valdesc;
                            tmpItm.Value = tmpLU.LookupVal;
                            listHP_ProviderType.Items.Add(tmpItm);
                        }
                        else if (!tmpLU.LookupVal.Equals("02") && !tmpLU.LookupVal.Equals("02")) // "01" Outpatient - only for main campus
                        {
                            RadComboBoxItem tmpItm = new RadComboBoxItem();
                            tmpItm.Text = tmpLU.Valdesc;
                            tmpItm.Value = tmpLU.LookupVal;
                            listHP_ProviderType.Items.Add(tmpItm);

                        }
                    }
                }

                listHP_Accred.AppendDataBoundItems = true;
                listHP_Accred.Items.Add(new RadComboBoxItem("", ""));
                listHP_Accred.DataSource = AOLookups;
                listHP_Accred.DataTextField = "Valdesc";
                listHP_Accred.DataValueField = "LookupVal";
                listHP_Accred.Height = Unit.Pixel(100);
                listHP_Accred.DataBind(); 
                
                if (!IsOffSite)
                {
                    listHP_ProviderType.SelectedValue = (null != CurrentAppProvider.TypeFacility ? CurrentAppProvider.TypeFacility : "");

                    //listHP_Accred.SelectedValue = ( null != CurrentAppProvider.AccreditedBody ? CurrentAppProvider.AccreditedBody : "" );
                    if ( !string.IsNullOrEmpty( CurrentAppProvider.AccreditedBody ) )
                        listHP_Accred.SelectedValue = CurrentAppProvider.AccreditedBody;
                    else if ( !string.IsNullOrEmpty( CurrentAppProvider.JcahYN ) && CurrentAppProvider.JcahYN.Equals( "Y" ) )
                        listHP_Accred.SelectedValue = "1";
                    else if ( !string.IsNullOrEmpty( CurrentAppProvider.ChapAccreditionYN ) && CurrentAppProvider.ChapAccreditionYN.Equals( "Y" ) )
                        listHP_Accred.SelectedValue = "2";
                    else
                        listHP_Accred.SelectedValue = "";
                    
                    listMedicareCertified.SelectedValue = (null != CurrentAppProvider.EnrolledInMedicaidYN ? CurrentAppProvider.EnrolledInMedicaidYN : "");
                    listHP_HospitalBased.SelectedValue = (null != CurrentAppProvider.HospitalBasedYN ? CurrentAppProvider.HospitalBasedYN : "");
                    txtHP_FYE.Text = (null != CurrentAppProvider.ForYearEndingDate ? CurrentAppProvider.ForYearEndingDate : "");
                }
                else
                {
                    foreach (BO_Affiliation tmpAffil in CurrentAppProvider.BO_AffiliationsApplicationID)
                    {
                        if (tmpAffil.UI_TrackID.Equals(CurrentAffiliationID) && null != tmpAffil.BO_ServicesAffiliationID)
                        {
                            listHP_ProviderType.SelectedValue = (null != tmpAffil.TypeFacility ? tmpAffil.TypeFacility : "");
                        }
                    }
                }
            }
            #endregion

            #region Load HH Values
            if (("HH").Contains(CurrentAppProvider.ProgramID))
            {
                if (CurrentAppProvider.ProgramID.Equals("HH"))
                {
                    listHH_Accred.AppendDataBoundItems = true;
                    listHH_Accred.Items.Add(new RadComboBoxItem("", ""));
                    listHH_Accred.DataSource = AOLookups;
                    listHH_Accred.DataTextField = "Valdesc";
                    listHH_Accred.DataValueField = "LookupVal";
                    listHH_Accred.Height = Unit.Pixel(100);
                    listHH_Accred.DataBind();
                }

                if (!IsOffSite)
                {
                    listHH_Accred.SelectedValue = (null != CurrentAppProvider.AccreditedBody ? CurrentAppProvider.AccreditedBody : "");
                    listHH_Deemed.SelectedValue = (null != CurrentAppProvider.DeemedStatus ? CurrentAppProvider.DeemedStatus : "");
                    listHH_HospBased.SelectedValue = (null != CurrentAppProvider.HospitalBasedYN ? CurrentAppProvider.HospitalBasedYN : "");
                    txtHH_FYE.Text = (null != CurrentAppProvider.ForYearEndingDate ? CurrentAppProvider.ForYearEndingDate : "");
                }
            }
            #endregion
            #region Load PT Values
            if (("PT").Contains(CurrentAppProvider.ProgramID))
            {
                listHH_Accred.AppendDataBoundItems = true;
                listHH_Accred.Items.Add(new RadComboBoxItem("", ""));
                listHH_Accred.DataSource = AOLookups;
                listHH_Accred.DataTextField = "Valdesc";
                listHH_Accred.DataValueField = "LookupVal";
                listHH_Accred.Height = Unit.Pixel(100);
                listHH_Accred.DataBind();

                if (!IsOffSite)
                {
                    rcbPT_AccreditingOrganization.SelectedValue = (null != CurrentAppProvider.AccreditedBody ? CurrentAppProvider.AccreditedBody : "");
                    txtPT_AccreditationExpDate.Text = (null != CurrentAppProvider.AccreditationExpirationDate ? CurrentAppProvider.AccreditationExpirationDate.ToString() : "");
                }
            }
            #endregion
            #region Load AS Values
            if (("AS").Contains(CurrentAppProvider.ProgramID)) {
                if (!IsOffSite) {
                    listAS_Deemed.SelectedValue = (null != CurrentAppProvider.DeemedStatus ? CurrentAppProvider.DeemedStatus : "");
                    txtAS_FYE.Text = CurrentAppProvider.ForYearEndingDate;

                    if (null != CurrentAppProvider.TypeFacility && CurrentAppProvider.TypeFacility.Equals("1")) {
                        chkAS_HospitalBased.Checked = true;
                    }
                    else if (null != CurrentAppProvider.TypeFacility && CurrentAppProvider.TypeFacility.Equals("2")) {
                        chkAS_FreeStanding.Checked = true;
                    }
                }
            }
            #endregion

            #region Load NH Values
            if (("NH").Contains(CurrentAppProvider.ProgramID)) {
                if (!IsOffSite) {
                    radMultiFacAdminYes.Checked = (CurrentAppProvider.AdmMultiFacYN == "Y");
                    radMultiFacAdminNo.Checked = (CurrentAppProvider.AdmMultiFacYN == "N");
                    txtNHAdminOtherFacName.Text = CurrentAppProvider.AdmMultiFacOtherName;
                    radSingleStory.Checked = (CurrentAppProvider.SingleStoryYN == "Y");
                    radMultiStory.Checked = (CurrentAppProvider.SingleStoryYN == "N");
                }
            }
            #endregion

            #region Load CORF Values
            if (("CO").Contains(CurrentAppProvider.ProgramID)) {
                if (!IsOffSite) {
                    txtCO_FYE.Text = (null != CurrentAppProvider.ForYearEndingDate ? CurrentAppProvider.ForYearEndingDate : "");
                }
            }
            #endregion

            #region Load Hospital Values
            if (("HO").Contains(CurrentAppProvider.ProgramID)) {
                if (!IsOffSite) {
                    txtHO_FYE.Text = (null != CurrentAppProvider.ForYearEndingDate ? CurrentAppProvider.ForYearEndingDate : "");
                }
            }
            #endregion

        }

        #region Members Variables
        
        private bool IsOffSite
        {
            get
            {
                return (ViewState["IsOffSite"] != null ? (bool)ViewState["IsOffSite"] : false);
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
        
        private BO_Application CurrentAppProvider
        {
            get
            {
                return Session["CurrentAppProvider"] == null ? null : (BO_Application)Session["CurrentAppProvider"];
            }
            set
            {
                Session["CurrentAppProvider"] = value;
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

        private DataTable AOLookups
        {
            get
            {
                DataTable tmpLkupTbl = null;

                if (Session["AOLookups"] == null)
                {
                    BO_LookupValues tmpBO_Lkups = null;
                    DataColumn tmpDC = new DataColumn();

                    tmpLkupTbl = new DataTable();

                    tmpDC.ColumnName = "Valdesc";
                    tmpLkupTbl.Columns.Add(tmpDC);
                    tmpDC.ColumnName = "LookupVal";
                    tmpLkupTbl.Columns.Add(tmpDC);

                    tmpBO_Lkups = BO_LookupValue.SelectByField(BO_LookupValueFields.LookupKey, "ACCREDITED_BODY");

                    foreach (BO_LookupValue boLV in tmpBO_Lkups)
                    {
                        if (null == boLV.Allowedtypes || boLV.Allowedtypes.Contains(CurrentAppProvider.ProgramID))
                        {
                            DataRow tmpRW = tmpLkupTbl.NewRow();

                            tmpRW["Valdesc"] = boLV.Valdesc;
                            tmpRW["LookupVal"] = boLV.LookupVal;

                            tmpLkupTbl.Rows.Add(tmpRW);
                        }
                    }
                }
                else
                    tmpLkupTbl = (DataTable)Session["AOLookups"];

                AOLookups = tmpLkupTbl;

                return tmpLkupTbl;
            }
            set
            {
                Session["AOLookups"] = value;
            }
        }

        #endregion

    }
}