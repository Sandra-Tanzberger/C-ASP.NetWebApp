using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ATG.BusinessObject;

namespace AppControl
{
    public partial class FacilityDates : System.Web.UI.UserControl
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            // do nothing
        }

        /// <summary>
        /// Maintain the Provider object in ViewState
        /// </summary>
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

        /// <summary>
        /// Set the values of the input controls
        /// </summary>
        private void InitFields()
        {
            BO_Provider boProvider = CurrentProvider;

            if (boProvider != null)
            {
                // Current Survey Date
                if (boProvider.CurSurv != null
                    && boProvider.CurSurv.HasValue)
                {
                    // ensure that the date is a valid date
                    if (boProvider.CurSurv > RadDatePickerCurrSurvDate.MinDate
                        && boProvider.CurSurv < RadDatePickerCurrSurvDate.MaxDate)
                        RadDatePickerCurrSurvDate.SelectedDate = boProvider.CurSurv;
                    else
                        RadDatePickerCurrSurvDate.SelectedDate = null;
                }
                else
                    RadDatePickerCurrSurvDate.SelectedDate = null;

                // Original License Issue Date
                if (boProvider.OriginalLicensureDate != null
                    && boProvider.OriginalLicensureDate.HasValue)
                {
                    // ensure that the date is a valid date
                    if (boProvider.OriginalLicensureDate > RadDatePickerOrigLicIssueDate.MinDate
                        && boProvider.OriginalLicensureDate < RadDatePickerOrigLicIssueDate.MaxDate)
                        RadDatePickerOrigLicIssueDate.SelectedDate = boProvider.OriginalLicensureDate;
                    else
                        RadDatePickerOrigLicIssueDate.SelectedDate = null;
                }
                else
                    RadDatePickerOrigLicIssueDate.SelectedDate = null;

                // Current License Issue Date
                if (boProvider.CurrentLicIssueDate != null
                    && boProvider.CurrentLicIssueDate.HasValue)
                {
                    // ensure that the date is a valid date
                    if (boProvider.CurrentLicIssueDate > RadDatePickerCurrLicIssueDate.MinDate
                        && boProvider.CurrentLicIssueDate < RadDatePickerCurrLicIssueDate.MaxDate)
                        RadDatePickerCurrLicIssueDate.SelectedDate = boProvider.CurrentLicIssueDate;
                    else
                        RadDatePickerCurrLicIssueDate.SelectedDate = null;
                }
                else
                    RadDatePickerCurrLicIssueDate.SelectedDate = null;

                // License Expiration Date
                if (boProvider.LicensureExpirationDate != null
                    && boProvider.LicensureExpirationDate.HasValue)
                {
                    // ensure that the date is a valid date
                    if (boProvider.LicensureExpirationDate > RadDatePickerLicExpDate.MinDate
                        && boProvider.LicensureExpirationDate < RadDatePickerLicExpDate.MaxDate)
                        RadDatePickerLicExpDate.SelectedDate = boProvider.LicensureExpirationDate;
                    else
                        RadDatePickerLicExpDate.SelectedDate = null;
                }
                else
                    RadDatePickerLicExpDate.SelectedDate = null;

                // set the value of the license Anniversary month
                RadTextBoxLicAnnivMonth.Text = (boProvider != null) ? boProvider.LicensureAnniversaryMth : "";

                // License Survey Date
                if (boProvider.LicensureSurveyDate != null
                    && boProvider.LicensureSurveyDate.HasValue)
                {
                    // ensure that the date is a valid date
                    if (boProvider.LicensureSurveyDate > RadDatePickerLicSrvyDate.MinDate
                        && boProvider.LicensureSurveyDate < RadDatePickerLicSrvyDate.MaxDate)
                        RadDatePickerLicSrvyDate.SelectedDate = boProvider.LicensureSurveyDate;
                    else
                        RadDatePickerLicSrvyDate.SelectedDate = null;
                }
                else
                    RadDatePickerLicSrvyDate.SelectedDate = null;

                // State Fire Approval Date
                if (boProvider.StateFireApprovalDate != null
                    && boProvider.StateFireApprovalDate.HasValue)
                {
                    // ensure that the date is a valid date
                    if (boProvider.StateFireApprovalDate > RadDatePickerStateFireApprovalDate.MinDate
                        && boProvider.StateFireApprovalDate < RadDatePickerStateFireApprovalDate.MaxDate)
                        RadDatePickerStateFireApprovalDate.SelectedDate = boProvider.StateFireApprovalDate;
                    else
                        RadDatePickerStateFireApprovalDate.SelectedDate = null;
                }
                else
                    RadDatePickerStateFireApprovalDate.SelectedDate = null;

                // Health Approval Date
                if (boProvider.HealthApprovalDate != null
                    && boProvider.HealthApprovalDate.HasValue)
                {
                    // ensure that the date is a valid date
                    if (boProvider.HealthApprovalDate > RadDatePickerHealthApprovalDate.MinDate
                        && boProvider.HealthApprovalDate < RadDatePickerHealthApprovalDate.MaxDate)
                        RadDatePickerHealthApprovalDate.SelectedDate = boProvider.HealthApprovalDate;
                    else
                        RadDatePickerHealthApprovalDate.SelectedDate = null;
                }
                else
                    RadDatePickerHealthApprovalDate.SelectedDate = null;

                // CHOW Date (Change of owner date)
                if (boProvider.ChangeOfOwnerDate != null
                    && boProvider.ChangeOfOwnerDate.HasValue)
                {
                    // ensure that the date is a valid date
                    if (boProvider.ChangeOfOwnerDate > RadDatePickerCHOWDate.MinDate
                        && boProvider.ChangeOfOwnerDate < RadDatePickerCHOWDate.MaxDate)
                        RadDatePickerCHOWDate.SelectedDate = boProvider.ChangeOfOwnerDate;
                    else
                        RadDatePickerCHOWDate.SelectedDate = null;
                }
                else
                    RadDatePickerCHOWDate.SelectedDate = null;

                /* 
                 * Special cases
                 */
                if (boProvider.ProgramID.Equals("RH"))
                {
                    RadDatePickerCHOWDate.Visible = true;
                    LabelCHOWDate.Visible = true;
                }
                else
                {
                    RadDatePickerCHOWDate.Visible = false;
                    LabelCHOWDate.Visible = false;
                }

                if (boProvider.ProgramID.Equals("NA"))
                {
                    CurrentLicenseIssueDate.Text = "Current Approval Date";
                    OriginalLicenseIssueDate.Text = "Original Approval Date";
                    LicsenseSurveyDate.Text = "1 Yr Survey Date";
                    HealthApprovalDate.Text = "2 Yr Survey Date";
                    LicenseExpirationDate.Text = "2 Yr Survey Due Date";
                    RadDatePickerLicExpDate.SelectedDate = boProvider.Year2ReviewDateDue;
                    RadDatePickerLicExpDate.Enabled = false;
                    RadDatePicker1YrSurveyDueDate.SelectedDate = boProvider.Year1ReviewDateDue;
                    RadDatePicker1YrSurveyDueDate.Visible= true;
                    RadDatePicker1YrSurveyDueDate.Enabled = false;
                    OneYrSurveyDueDate.Visible = true;

                }

            }
            else
            {
                // set the values of the date controls to null
                RadDatePickerOrigLicIssueDate.SelectedDate = null;
                RadDatePickerCurrLicIssueDate.SelectedDate = null;
                RadDatePickerLicExpDate.SelectedDate = null;
                RadDatePickerLicSrvyDate.SelectedDate = null;
                RadDatePickerStateFireApprovalDate.SelectedDate = null;
                RadDatePickerHealthApprovalDate.SelectedDate = null;

                RadDatePickerCHOWDate.Visible = false;
                LabelCHOWDate.Visible = false;

            }

            
        }

        /// <summary>
        /// Reload the fields with the current provider
        /// </summary>
        /// <param name="boProvider"></param>
        public void LoadNewProvider()
        {
            // Set the values of the input controls
            InitFields();
        }

    }
}