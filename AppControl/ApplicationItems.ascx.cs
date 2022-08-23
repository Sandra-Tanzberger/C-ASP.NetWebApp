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
    public partial class ApplicationItems : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void LoadApplication(string inAppID, bool inAllowEdit)
        {
            AllowEdit = inAllowEdit;

            if (CurrentAppProvider != null && CurrentAppProvider.ApplicationID != null)
            {
                _InitUserView(_UserType);
            }

        }

        public bool SaveData()
        {
            ErrorText.Visible = false;
            ErrorText.InnerHtml = "";
            bool noSaveError = true;

            if (_UserType.Equals("State"))
            {
                bool AppApproved = false;
                bool checksavetext = false;

                foreach (RepeaterItem tmpRI in AppStatusRepeater.Items)
                {
                    if (tmpRI.ItemType == ListItemType.Item || tmpRI.ItemType == ListItemType.AlternatingItem)
                    {
                        RadComboBox tmpRCBStatus = (RadComboBox)tmpRI.FindControl("cboStatus");
                        TextBox tmpComment = ((TextBox)tmpRI.FindControl("txtStatusComment"));

                        //if the control below is visible then the application is not closed and the
                        //new status should be captured. If the new status is approved then also set flag
                        //for later processing.
                        if (tmpRCBStatus.Visible && tmpComment.Visible)
                        {
                            LastSaveAppStatus = tmpRCBStatus.SelectedValue;

                            //Check rejected and inprocess status types for comment. If not found then error
                            if (((tmpRCBStatus.SelectedValue.Equals("3") || tmpRCBStatus.SelectedValue.Equals("5") || 
                                tmpRCBStatus.SelectedValue.Equals("6"))
                                  && !CurrentAppProvider.ApplicationStatus.Equals(tmpRCBStatus.SelectedValue))
                                  && tmpComment.Text.Length < 1
                                 )
                            {
                                ErrorText.Visible = true;
                                ErrorText.InnerHtml += "Comment required<br />";
                                noSaveError = false;
                            }
                            //if there was a status change and the text is there then save it
                            else if (((tmpRCBStatus.SelectedValue.Equals("3") || tmpRCBStatus.SelectedValue.Equals("5")
                                || tmpRCBStatus.SelectedValue.Equals("6"))
                                 && !CurrentAppProvider.ApplicationStatus.Equals(tmpRCBStatus.SelectedValue)))
                            {
                                CurrentAppProvider.ApplicationStatus = tmpRCBStatus.SelectedValue;
                                CurrentAppProvider.StatusComment = tmpComment.Text;

                                //if application terminated delete all fees
                                if (tmpRCBStatus.SelectedValue.Equals("6"))
                                {
                                    BO_Billing.DeleteAllByForeignKeyApplicationID(new BO_ApplicationPrimaryKey(CurrentAppProvider.ApplicationID));
                                }
                            }
                            else if ((tmpRCBStatus.SelectedValue.Equals("4"))
                                 && !CurrentAppProvider.ApplicationStatus.Equals(tmpRCBStatus.SelectedValue)
                                 && tmpComment.Text.Length < 1)
                            {
                                ErrorText.Visible = true;
                                ErrorText.InnerHtml += "Comment required<br />";
                                noSaveError = false;
                            }
                            else if ((tmpRCBStatus.SelectedValue.Equals("4"))
                                 && !CurrentAppProvider.ApplicationStatus.Equals(tmpRCBStatus.SelectedValue))
                            {
                                CurrentAppProvider.ApplicationStatus = "4";
                                CurrentAppProvider.StatusComment = tmpComment.Text;
                                CurrentAppProvider.DateCompleted = DateTime.Now;
                                checksavetext = true;
                            }
                            else if (tmpComment.Text.Length > 0)
                            {
                                CurrentAppProvider.StatusComment = tmpComment.Text;
                                CurrentAppProvider.ApplicationStatus = tmpRCBStatus.SelectedValue.ToString();
                                checksavetext = true;
                            }
                        }
                        //Its not available for change but if the application was already approved then a comment
                        //is required for update and if not there then error                      
                        else if (CurrentAppProvider.ApplicationStatus.Equals("4") && tmpComment.Visible && tmpComment.Text.Length < 1 && !checksavetext)
                        {
                            ErrorText.Visible = true;
                            ErrorText.InnerHtml += "Comment required<br />";
                            noSaveError = false;
                        }
                        //Ok the text is there and its already been approved so save it.
                        else if (CurrentAppProvider.ApplicationStatus.Equals("4") && tmpComment.Text.Length > 0)
                        {
                            CurrentAppProvider.ApplicationStatus = "4";
                            CurrentAppProvider.StatusComment = tmpComment.Text;
                            checksavetext = true;
                        }
                        //finally if text was entered then save it as an update
                        else if (tmpComment.Text.Length > 0)
                        {
                            CurrentAppProvider.StatusComment = tmpComment.Text;
                        }

                        if (tmpRCBStatus.SelectedValue.Equals("4") || CurrentAppProvider.ApplicationStatus.Equals("4"))
                        {
                            AppApproved = true;

                            if (CurrentAppProvider.BusinessProcessID.Equals("1"))
                            {
                                CurrentAppProvider.OriginalLicensureDate = dtLicIssue.SelectedDate;
                            }

                            //SMM 03/29/2012 - Moved outside of loop so messages are not duplicated
                            ////These three dates do not have to be entered until the application is approved
                            //if ( null == dtLicEffective.SelectedDate )
                            //{
                            //    ErrorText.Visible = true;
                            //    ErrorText.InnerHtml += "Licensure Effective Date Required<br />";
                            //    noSaveError = false;
                            //}
                            //if ( null == dtLicExpire.SelectedDate )
                            //{
                            //    ErrorText.Visible = true;
                            //    ErrorText.InnerHtml += "Licensure Exipration Date Required<br />";
                            //    noSaveError = false;
                            //}
                            //if ( null == dtLicIssue.SelectedDate )
                            //{
                            //    ErrorText.Visible = true;
                            //    ErrorText.InnerHtml += "Licensure Issue Date Required<br />";
                            //    noSaveError = false;
                            //}
                        }
                    }
                }

                //These three dates do not have to be entered until the application is approved
                //No validation for certified only providers
                if (AppApproved && !("CC,CO,MX,NA,NE,RA").Contains(CurrentAppProvider.ProgramID))
                {
                    if (null == dtLicEffective.SelectedDate)
                    {
                        ErrorText.Visible = true;
                        ErrorText.InnerHtml += "Licensure Effective Date Required<br />";
                        noSaveError = false;
                    }
                    if (null == dtLicExpire.SelectedDate)
                    {
                        ErrorText.Visible = true;
                        ErrorText.InnerHtml += "Licensure Expiration Date Required<br />";
                        noSaveError = false;
                    }
                    if (null == dtLicIssue.SelectedDate)
                    {
                        ErrorText.Visible = true;
                        ErrorText.InnerHtml += "Licensure Issue Date Required<br />";
                        noSaveError = false;
                    }
                }
                else if (AppApproved && CurrentAppProvider.ProgramID.Equals("NA"))//for NA providers set 2 year survey due date = 1 year survey date + 732
                {
                    if (!chkExpDtOvrd.Checked)
                    {
                        if (!RadDatePickerHealthApprovalDate.SelectedDate.ToString().Equals(String.Empty))
                        {
                            dtLicExpire.SelectedDate = Convert.ToDateTime(RadDatePickerHealthApprovalDate.SelectedDate).AddDays(732);
                            CurrentAppProvider.Year2ReviewDateDue = dtLicExpire.SelectedDate;
                        }
                    }
                }

                //No validation for certified only providers
                if (!("CC,CO,MX,NA,NE,RA").Contains(CurrentAppProvider.ProgramID))
                {
                    if (dtLicEffective.Enabled)
                    {
                        if (chkEffDtOvrd.Checked || hidDoEffExpDtValidate.Value.Equals("N"))
                        {
                            CurrentAppProvider.LicEffectiveDateOveride = chkEffDtOvrd.Checked ? "Y" : "N";
                            CurrentAppProvider.LicensureEffectiveDate = dtLicEffective.SelectedDate;
                        }
                        else
                        {
                            if (null != dtLicEffective.SelectedDate && CurrentProvider.LicensureExpirationDate != null)
                            {
                                if (dtLicEffective.SelectedDate > CurrentProvider.LicensureExpirationDate.Value.AddYears(1))
                                {
                                    dtLicEffective.SelectedDate = CurrentAppProvider.LicensureEffectiveDate;
                                    ErrorText.Visible = true;
                                    ErrorText.InnerHtml += "The license effective date entered \"";
                                    ErrorText.InnerHtml += dtLicEffective.SelectedDate.Value.ToShortDateString();
                                    ErrorText.InnerHtml += "\" is more than 366 days after the last license expiration date.";
                                    ErrorText.InnerHtml += " Select the \"Override License Effective Date Rule\" check box to override validation for this field.<br />";
                                    noSaveError = false;
                                }
                                else if (CurrentProvider.LicensureExpirationDate.Value.AddYears(-1) > dtLicEffective.SelectedDate)
                                {
                                    dtLicEffective.SelectedDate = CurrentAppProvider.LicensureEffectiveDate;
                                    ErrorText.Visible = true;
                                    ErrorText.InnerHtml += "The license effective date entered \"";
                                    ErrorText.InnerHtml += dtLicEffective.SelectedDate.Value.ToShortDateString();
                                    ErrorText.InnerHtml += "\" is more than 366 days before the last license expiration date.";
                                    ErrorText.InnerHtml += " Select the \"Override License Effective Date Rule\" check box to override validation for this field.<br />";
                                    noSaveError = false;
                                }
                                else
                                {
                                    CurrentAppProvider.LicensureEffectiveDate = dtLicEffective.SelectedDate;
                                }
                            }
                            else if (CurrentAppProvider.BusinessProcessID.Equals("2")) // For initials just save it
                            {
                                CurrentAppProvider.LicensureEffectiveDate = dtLicEffective.SelectedDate;
                            }
                        }
                    }
                    if (dtLicExpire.Enabled)
                    {
                        if (chkExpDtOvrd.Checked || hidDoEffExpDtValidate.Value.Equals("N"))
                        {
                            CurrentAppProvider.LicExpireDateOveride = chkExpDtOvrd.Checked ? "Y" : "N";
                            CurrentAppProvider.LicensureExpirationDate = dtLicExpire.SelectedDate;
                        }
                        else
                        {
                            if (null != dtLicEffective.SelectedDate && null != dtLicExpire.SelectedDate)
                            {
                                if (dtLicExpire.SelectedDate < dtLicEffective.SelectedDate)
                                {
                                    dtLicExpire.SelectedDate = CurrentAppProvider.LicensureExpirationDate;
                                    ErrorText.Visible = true;
                                    ErrorText.InnerHtml += "The license expiration date must be greater that the license effective date.<br />";
                                    noSaveError = false;
                                }
                                else if (dtLicExpire.SelectedDate > dtLicEffective.SelectedDate.Value.AddYears(1))
                                {
                                    dtLicExpire.SelectedDate = CurrentAppProvider.LicensureExpirationDate;
                                    ErrorText.Visible = true;
                                    ErrorText.InnerHtml += "The license expiration date entered \"";
                                    ErrorText.InnerHtml += dtLicExpire.SelectedDate.Value.ToShortDateString();
                                    ErrorText.InnerHtml += "\" is more than 366 days after the license effective date.";
                                    ErrorText.InnerHtml += " Select the \"Override License Expiration Date Rule\" check box to override validation for this field.<br />";
                                    noSaveError = false;
                                }
                                else
                                {
                                    CurrentAppProvider.LicensureExpirationDate = dtLicExpire.SelectedDate;
                                }
                            }
                        }
                    }
                    if (dtLicIssue.Enabled)
                    {
                        if (null != dtLicIssue.SelectedDate && null != dtLicExpire.SelectedDate)
                        {
                            CurrentAppProvider.CurrentLicIssueDate = dtLicIssue.SelectedDate;
                            if (dtLicIssue.SelectedDate > dtLicExpire.SelectedDate)
                            {
                                dtLicExpire.SelectedDate = CurrentAppProvider.LicensureExpirationDate;
                                ErrorText.Visible = true;
                                ErrorText.InnerHtml += "The current license issue date must be before the license expiration date.<br />";
                                noSaveError = false;
                            }
                            else
                            {
                                CurrentAppProvider.CurrentLicIssueDate = dtLicIssue.SelectedDate;
                            }
                        }
                    }
                }
                else
                {
                    CurrentAppProvider.LicensureEffectiveDate = dtLicEffective.SelectedDate;
                    CurrentAppProvider.LicensureEffectiveDate = dtLicEffective.SelectedDate;
                    CurrentAppProvider.LicensureExpirationDate = dtLicExpire.SelectedDate;
                    CurrentAppProvider.CurrentLicIssueDate = dtLicIssue.SelectedDate;
                }

                // No validation save always
                CurrentAppProvider.LicensureSurveyDate = RadDatePickerLicSrvyDate.SelectedDate;
                CurrentAppProvider.StateFireApprovalDate = RadDatePickerStateFireApprovalDate.SelectedDate;
                CurrentAppProvider.HealthApprovalDate = RadDatePickerHealthApprovalDate.SelectedDate;

            }
            else
            {
                //This is a provider and there is no comment for them. Also the application status is set elsewhere
            }

            // The Proposed Effective Date control will be disabled in the case of Initial Application
            // For all other application types, save the date
            if (dtProposedEffectiveDt.Enabled)
                CurrentAppProvider.ProposedEffectiveDate = dtProposedEffectiveDt.SelectedDate;

            if (cboTypeLicense.Enabled)
            {
                if (string.IsNullOrEmpty(cboTypeLicense.SelectedValue) && CurrentAppProvider.ApplicationStatus.Equals("4"))
                {
                    ErrorText.Visible = true;
                    ErrorText.InnerHtml += "Type License is required.<br />";
                    noSaveError = false;
                }
                else
                {
                    CurrentAppProvider.TypeLicenseCode = cboTypeLicense.SelectedValue;
                }
            }

            if (CurrentAppProvider.ProgramID.Equals("NA") && chkExpDtOvrd.Checked)
                CurrentAppProvider.Year2ReviewDateDue = dtLicExpire.SelectedDate;

            return noSaveError;
        }

        protected void AppStatusRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            RadComboBox tmpRCB = (RadComboBox)e.Item.FindControl("cboStatus");
            bool approved = false;


            if (e.Item.ItemType == ListItemType.Footer)
            {
                if (null != CurrentAppProvider.OriginalLicensureDate)
                    txtOrigLicDate.SelectedDate = CurrentAppProvider.OriginalLicensureDate;

                dtLicEffective.SelectedDate = CurrentAppProvider.LicensureEffectiveDate;
                dtLicExpire.SelectedDate = CurrentAppProvider.LicensureExpirationDate;
                dtLicIssue.SelectedDate = CurrentAppProvider.CurrentLicIssueDate;

                if (CurrentAppProvider.ApplicationStatus.Equals("4"))
                {
                    approved = true;
                }
                else
                {
                    if (("2,3,4,6,10").Contains(CurrentAppProvider.BusinessProcessID))
                    {
                        dtLicEffective.Enabled = true;
                        dtLicExpire.Enabled = true;
                    }
                    else if (("1,5,7,8,9").Contains(CurrentAppProvider.BusinessProcessID))
                    {
                        dtLicEffective.Enabled = false;
                        dtLicExpire.Enabled = false;
                        hidDoEffExpDtValidate.Value = "N";
                    }
                    else
                    {
                        dtLicEffective.Enabled = false;
                        dtLicExpire.Enabled = false;
                        hidDoEffExpDtValidate.Value = "N";
                    }

                    approved = false;
                }
                if (!CurrentAppProvider.ProgramID.Equals("NA"))
                    lblLicEffectiveDt.Visible = true;
                lblLicEffectiveDt.Enabled = _UserType.Equals("State");
                lblLicExpireDt.Visible = true;
                lblLicExpireDt.Enabled = _UserType.Equals("State");
                lblLicIssueDt.Visible = true;
                lblLicIssueDt.Enabled = _UserType.Equals("State");

                // License Survey Date
                if (CurrentAppProvider.LicensureSurveyDate != null
                    && CurrentAppProvider.LicensureSurveyDate.HasValue)
                {
                    // ensure that the date is a valid date
                    if (CurrentAppProvider.LicensureSurveyDate > RadDatePickerLicSrvyDate.MinDate
                        && CurrentAppProvider.LicensureSurveyDate < RadDatePickerLicSrvyDate.MaxDate)
                        RadDatePickerLicSrvyDate.SelectedDate = CurrentAppProvider.LicensureSurveyDate;
                    else
                        RadDatePickerLicSrvyDate.SelectedDate = null;
                }
                else
                    RadDatePickerLicSrvyDate.SelectedDate = null;

                // State Fire Approval Date
                if (CurrentAppProvider.StateFireApprovalDate != null
                    && CurrentAppProvider.StateFireApprovalDate.HasValue)
                {
                    // ensure that the date is a valid date
                    if (CurrentAppProvider.StateFireApprovalDate > RadDatePickerStateFireApprovalDate.MinDate
                        && CurrentAppProvider.StateFireApprovalDate < RadDatePickerStateFireApprovalDate.MaxDate)
                        RadDatePickerStateFireApprovalDate.SelectedDate = CurrentAppProvider.StateFireApprovalDate;
                    else
                        RadDatePickerStateFireApprovalDate.SelectedDate = null;
                }
                else
                    RadDatePickerStateFireApprovalDate.SelectedDate = null;

                // Health Approval Date
                if (CurrentAppProvider.HealthApprovalDate != null
                    && CurrentAppProvider.HealthApprovalDate.HasValue)
                {
                    // ensure that the date is a valid date
                    if (CurrentAppProvider.HealthApprovalDate > RadDatePickerHealthApprovalDate.MinDate
                        && CurrentAppProvider.HealthApprovalDate < RadDatePickerHealthApprovalDate.MaxDate)
                        RadDatePickerHealthApprovalDate.SelectedDate = CurrentAppProvider.HealthApprovalDate;
                    else
                        RadDatePickerHealthApprovalDate.SelectedDate = null;
                }
                else
                    RadDatePickerHealthApprovalDate.SelectedDate = null;


            }

            if (null != tmpRCB && tmpRCB.Visible)
            {
                if (!tmpRCB.Enabled)
                    tmpRCB.SelectedValue = "4";
                else
                    tmpRCB.SelectedValue = CurrentAppProvider.ApplicationStatus;
                    //tmpRCB.SelectedValue = LastSaveAppStatus;
            }
        }

        protected void AppStatusRepeater_PreRender(object sender, EventArgs e)
        {
            AppStatusRepeater.DataSource = null;
            AppStatusRepeater.DataSource = CurrentAppStatusDataSource;
            AppStatusRepeater.DataBind();
        }

        private void _InitUserView(string inUserType)
        {
            _InitFields(inUserType);
            _ToggleReadOnly();

            if (CurrentAppProvider != null)
            {
                /* 
                 * In the case of INITIAL LICENSING:
                 * (1) disable the Proposed Effective Date picker
                 * (2) set the default value to the same as the one on the Letter Of Intent
                 */
                if (CurrentAppProvider.BusinessProcessID != null
                    && CurrentAppProvider.BusinessProcessID.Trim().Equals("2"))
                {
                    // disable the Proposed Effective Date picker
                    dtProposedEffectiveDt.Enabled = false;

                    // set the default value to the same as the one on the Letter Of Intent
                    BO_ApplicationPrimaryKey boApplicationPrimaryKey = new BO_ApplicationPrimaryKey(CurrentAppProvider.ApplicationID);
                    BO_LetterOfIntents boLOIMultiple = BO_LetterOfIntent.SelectAllByForeignKeyApplicationID(boApplicationPrimaryKey);
                    if (boLOIMultiple != null && boLOIMultiple.Count > 0)
                    {
                        BO_LetterOfIntent boLOISingle = boLOIMultiple[0];
                        dtProposedEffectiveDt.SelectedDate = boLOISingle.PlanToOpenDate;
                    }
                }
                else
                {
                    dtProposedEffectiveDt.SelectedDate = CurrentAppProvider.ProposedEffectiveDate;
                }

                hidLastLicExpDate.Value = CurrentProvider.LicensureExpirationDate != null ? CurrentProvider.LicensureExpirationDate.Value.ToShortDateString() : "";
                hidSavedEffDate.Value = CurrentAppProvider.LicensureEffectiveDate != null ? CurrentAppProvider.LicensureEffectiveDate.Value.ToShortDateString() : "";
                hidSavedExpDate.Value = CurrentAppProvider.LicensureExpirationDate != null ? CurrentAppProvider.LicensureExpirationDate.Value.ToShortDateString() : "";
                chkEffDtOvrd.Checked = CurrentAppProvider.LicEffectiveDateOveride != null && CurrentAppProvider.LicEffectiveDateOveride.Equals("Y") ? true : false;
                chkExpDtOvrd.Checked = CurrentAppProvider.LicExpireDateOveride != null && CurrentAppProvider.LicExpireDateOveride.Equals("Y") ? true : false;

                cboTypeLicense.AppendDataBoundItems = true;
                cboTypeLicense.Items.Add(new RadComboBoxItem("", ""));
                cboTypeLicense.DataSource = TypeLicense;
                cboTypeLicense.DataTextField = "VALDESC";
                cboTypeLicense.DataValueField = "LOOKUP_VAL";
                cboTypeLicense.Height = Unit.Pixel(100);
                cboTypeLicense.DataBind();

                cboTypeLicense.SelectedValue = CurrentAppProvider.TypeLicenseCode;

                //special cases

                if (CurrentAppProvider.ProgramID.Equals("NA"))
                {
                    lblLicIssueDt.Text = "Current Approval Date";
                    lblOrigLicDate.Text = "Original Approval Date";
                    LicenseSurveyDate.Text = "1 Yr Survey Date";
                    HealthApprovalDate.Text = "2 Yr Survey Date";
                    lblLicExpireDt.Text = "2 Yr Survey Due Date";
                    dtLicExpire.SelectedDate = CurrentAppProvider.Year2ReviewDateDue;
                    chkExpDtOvrd.Text = "Override 2 Yr Survey Due Date Rule";
                    chkExpDtOvrd.Visible = true;
                    lbl1YrSurveyDueDate.Visible = true;
                    rd1YrSurveyDueDate.SelectedDate = CurrentAppProvider.Year1ReviewDateDue;
                    rd1YrSurveyDueDate.Visible = true;
                    chkEffDtOvrd.Visible = false;
                    lblStateFireApprovalDate.Visible = false;
                    RadDatePickerStateFireApprovalDate.Visible = false;
                    lblLicEffectiveDt.Visible = false;
                    dtLicEffective.Visible = false;
                    chkEffDtOvrd.Visible = false;

                }

            }
        }

        private void _InitFields(string inUserType)
        {
            AppStatusRepeater.DataSource = CurrentAppStatusDataSource;
            AppStatusRepeater.DataBind();
            if (CurrentAppProvider.BusinessProcessID == "2" && !CurrentAppProvider.ApplicationStatus.Equals("4"))
                txtOrigLicDate.Enabled = true;
        }

        private void _ToggleReadOnly()
        {
            dtLicEffective.Enabled = AllowEdit;
            dtLicExpire.Enabled = AllowEdit;
            dtLicIssue.Enabled = AllowEdit;
            dtProposedEffectiveDt.Enabled = AllowEdit;
            cboTypeLicense.Enabled = AllowEdit;
        }

        protected DataTable getAppStatOpts()
        {
            DataTable tmpDT = new DataTable();
            DataRow tmpRow;

            tmpDT.Columns.Add("LOOKUP_VAL");
            tmpDT.Columns.Add("VALDESC");

            foreach (BO_LookupValue boLV in AppStatusLookups)
            {
                tmpRow = tmpDT.NewRow();
                tmpRow["LOOKUP_VAL"] = boLV.LookupVal;
                tmpRow["VALDESC"] = CommonFunc.ConvertToTitleCase(boLV.Valdesc); ;
                tmpDT.Rows.Add(tmpRow);
            }

            return tmpDT;
        }

        private DataTable _getAppStatusDataTable()
        {
            DataTable tmpDTbl = new DataTable();
            DataColumn tmpDCol = null;

            tmpDCol = new DataColumn("StatusCode");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("StatusDesc");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("StatusDate");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("StatusComment");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("ShowLabel");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("ShowEdit");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("CommentText");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("Enabledcombo");
            tmpDTbl.Columns.Add(tmpDCol);

            return tmpDTbl;
        }

        private string _UserType
        {
            get
            {
                return (string)Session["userType"];
            }
        }

        protected string LastSaveAppStatus
        {
            get
            {
                return (null != ViewState["LastSaveAppStatus"] ? (string)ViewState["LastSaveAppStatus"] : null);
            }
            set
            {
                ViewState["LastSaveAppStatus"] = value;
            }
        }

        private BO_Provider CurrentProvider
        {
            get
            {
                return Session["CurrentProvider"] == null ? null : (BO_Provider)Session["CurrentProvider"];
            }
            set
            {
                Session["CurrentProvider"] = value;
            }
        }

        private BO_Application CurrentAppProvider
        {
            get
            {
                return Session["CurrentAppProvider"] == null ? null : (BO_Application)Session["CurrentAppProvider"];
            }
        }

        private DataTable CurrentAppStatusDataSource
        {
            get
            {
                DataTable retTable = null;

                retTable = _getAppStatusDataTable();
                bool AppApproved = false;
                //SMM 06/15/2011 - Prevent Input cotrol row from being added more than once
                bool inputCtrlAdded = false;

                if (null != CurrentAppProvider && null != CurrentAppProvider.BO_StatusHistoriesApplicationID)
                {

                    //CurrentAppProvider.BO_StatusHistoriesApplicationID.Sort( "StatusID" );
                    CurrentAppProvider.BO_StatusHistoriesApplicationID.Sort("StatusID DESC");

                    foreach (BO_StatusHistory boSH in CurrentAppProvider.BO_StatusHistoriesApplicationID)
                    {
                        if (boSH.ApplicationStatus.Equals("4"))
                        {
                            AppApproved = true;
                            LastSaveAppStatus = "4";
                        }

                        DataRow tmpDR = retTable.NewRow();

                        tmpDR["StatusCode"] = boSH.ApplicationStatus;

                        foreach (BO_LookupValue boLV in AppStatusLookups)
                        {
                            if (boLV.LookupVal.Equals(boSH.ApplicationStatus))
                                tmpDR["StatusDesc"] = CommonFunc.ConvertToTitleCase(boLV.Valdesc);
                        }

                        tmpDR["StatusDate"] = boSH.StatusDate.Value.ToShortDateString();
                        tmpDR["StatusComment"] = boSH.Comment;
                        tmpDR["ShowLabel"] = "true";
                        tmpDR["ShowEdit"] = "false";

                        retTable.Rows.Add(tmpDR);
                    }
                }

                //ln - check current application
                decimal? appId = null;
                BO_Provider boProvider = null;
                //SMM This is not needed as we can get the ID from the CurrentAppProvider
                //also is throwing invalid cast exception.
                //string popsIntId = (string) Session["ProviderPOPSINTID"];
                //BO_ProviderPrimaryKey boProviderPrimaryKey = new BO_ProviderPrimaryKey( Convert.ToDecimal( popsIntId ) );
                BO_ProviderPrimaryKey boProviderPrimaryKey = new BO_ProviderPrimaryKey(CurrentAppProvider.PopsIntID);
                boProvider = BO_Provider.SelectOne(boProviderPrimaryKey);

                BO_Applications tmpApplications = BO_Application.SelectCurrentApprovedApplicationsByPopsIntId(boProviderPrimaryKey);
                if (tmpApplications != null && tmpApplications.Count > 0)
                {
                    BO_Application tmpApp = (BO_Application)tmpApplications[0];
                    appId = tmpApp.ApplicationID;
                }

                //If the application has not been approved the add a dummy row for the repeater to show a row with data
                //input controls for setting status indicators.
                if (!inputCtrlAdded && _UserType.Equals("State")
                    && (!AppApproved || (AppApproved && !CurrentAppProvider.ApplicationAction.Equals("4")))) //CurrentAppProvider.ApplicationID == appId)))
                {
                    DataRow tmpDR = retTable.NewRow();

                    tmpDR["StatusCode"] = "";
                    tmpDR["StatusDesc"] = "";
                    tmpDR["StatusDate"] = "";
                    tmpDR["StatusComment"] = "";
                    tmpDR["ShowLabel"] = "false";
                    tmpDR["ShowEdit"] = "true";

                    if (null != CurrentAppProvider.BO_StatusHistoriesApplicationID)
                    {
                        bool statHistFound = false;

                        foreach (BO_StatusHistory boStatHist in CurrentAppProvider.BO_StatusHistoriesApplicationID)
                        {
                            if (!string.IsNullOrEmpty(boStatHist.Comment) && boStatHist.Comment.Equals(CurrentAppProvider.StatusComment))
                            {
                                statHistFound = true;
                            }
                        }

                        if (!statHistFound)
                            tmpDR["CommentText"] = CurrentAppProvider.StatusComment;
                        else
                            tmpDR["CommentText"] = "";
                    }

                    if (AppApproved)// && CurrentAppProvider.ApplicationAction.Equals("4")) //CurrentAppProvider.ApplicationID == appId)
                        tmpDR["Enabledcombo"] = "false";
                    else
                        tmpDR["Enabledcombo"] = "true";
                    retTable.Rows.Add(tmpDR);

                    inputCtrlAdded = true;
                }

                //retTable.DefaultView.Sort = "StatusDate desc";

                return retTable;
            }

        }

        private BO_LookupValues AppStatusLookups
        {
            get
            {
                BO_LookupValues retLkups = new BO_LookupValues();
                if (Session["AppStatusLookups"] == null)
                {
                    retLkups = BO_LookupValue.SelectByField(BO_LookupValueFields.LookupKey, "APPLICATION_STATUS");
                }
                else
                    retLkups = (BO_LookupValues)Session["AppStatusLookups"];

                AppStatusLookups = retLkups;

                return retLkups;
            }
            set
            {
                Session["AppStatusLookups"] = value;
            }
        }

        private DataTable TypeLicense
        {
            get
            {
                DataTable retVal = null;
                if (Session["TypeLicense"] == null)
                {
                    BO_LookupValues retLkups = BO_LookupValue.SelectByField(BO_LookupValueFields.LookupKey, "TYPE_LICENSE");

                    DataTable tmpDT = new DataTable();
                    DataRow tmpRow;

                    tmpDT.Columns.Add("LOOKUP_VAL");
                    tmpDT.Columns.Add("VALDESC");

                    foreach (BO_LookupValue boLV in retLkups)
                    {
                        tmpRow = tmpDT.NewRow();
                        tmpRow["LOOKUP_VAL"] = boLV.LookupVal;
                        tmpRow["VALDESC"] = CommonFunc.ConvertToTitleCase(boLV.Valdesc); ;
                        tmpDT.Rows.Add(tmpRow);
                    }

                    retVal = tmpDT;
                    return retVal;
                }
                else
                    retVal = (DataTable)Session["TypeLicense"];

                TypeLicense = retVal;

                return retVal;
            }
            set
            {
                Session["TypeLicense"] = value;
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

    }
}