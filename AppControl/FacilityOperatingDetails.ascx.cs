using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ATG.BusinessObject;

namespace AppControl
{
    public partial class FacilityOperatingDetails : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // do nothing
        }

        /// <summary>
        /// Load the Services for the Current Application
        /// Called from Public POPS
        /// </summary>
        public void LoadApplication(string inAppID)
        {
            if (inAppID != null && CurrentAppProvider != null)
            {
                InitFields(false);
            }
            _ShowHideFields();
        }

        /// <summary>
        /// Load the values for the specified Provider
        /// Called from State POPS
        /// </summary>
        /// <param name="boProvider"></param>
        public void LoadNewProvider()
        {
            InitFields(true);
            _ShowHideFields();
        }

        /// <summary>
        ///  Show or hide elements based on program
        /// </summary>
        private void _ShowHideFields() {
            LabelNumOperatingRooms.Visible = false;
            TextNumOperatingRooms.Visible = false;

            switch (CurrentAppProvider.ProgramID) {
                case "AS":
                    LabelNumOperatingRooms.Visible = true;
                    TextNumOperatingRooms.Visible = true;
                    break;
            }
        }

        /// <summary>
        /// Called from the state POPS to display information in Read-only mode
        /// </summary>
        public void DisableInputControls()
        {
            TextBoxHoursMinutes.ReadOnly = true;
            TextBoxHoursMinutes1.ReadOnly = true;
            listAmPm.Enabled = false;
            listAmPm1.Enabled = false;
            CheckBoxDayOfOperationMon.Enabled = false;
            CheckBoxDayOfOperationTue.Enabled = false;
            CheckBoxDayOfOperationWed.Enabled = false;
            CheckBoxDayOfOperationThu.Enabled = false;
            CheckBoxDayOfOperationFri.Enabled = false;
            CheckBoxDayOfOperationSat.Enabled = false;
            CheckBoxDayOfOperationSun.Enabled = false;
            TextNumOperatingRooms.Enabled = false;
        }

        /// <summary>
        /// Set the values of the desired columns in the CurrentAppServicesList collection
        /// </summary>
        public bool SaveData()
        {
            // flag will be set to false if there are validation errors
            bool noSaveError = true;

            if (CurrentAppProvider != null)
            {
                // Validate the data
                noSaveError = _DoValidate();

                if (noSaveError)
                {
                    // set the column values
                    CurrentAppProvider.HoursMinutes = TextBoxHoursMinutes.Text;
                    CurrentAppProvider.HoursMinutes1 = TextBoxHoursMinutes1.Text;
                    CurrentAppProvider.AmPM = listAmPm.SelectedValue;
                    CurrentAppProvider.AmPm1 = listAmPm1.SelectedValue;
                    CurrentAppProvider.DayOfOperationMon = (CheckBoxDayOfOperationMon.Checked) ? "X" : "";
                    CurrentAppProvider.DayOfOperationTue = (CheckBoxDayOfOperationTue.Checked) ? "X" : "";
                    CurrentAppProvider.DayOfOperationWed = (CheckBoxDayOfOperationWed.Checked) ? "X" : "";
                    CurrentAppProvider.DayOfOperationThu = (CheckBoxDayOfOperationThu.Checked) ? "X" : "";
                    CurrentAppProvider.DayOfOperationFri = (CheckBoxDayOfOperationFri.Checked) ? "X" : "";
                    CurrentAppProvider.DayOfOperationSat = (CheckBoxDayOfOperationSat.Checked) ? "X" : "";
                    CurrentAppProvider.DayOfOperationSun = (CheckBoxDayOfOperationSun.Checked) ? "X" : "";
                    CurrentAppProvider.NumOperatingRooms = TextNumOperatingRooms.Text.Length > 0 ? Convert.ToInt16(TextNumOperatingRooms.Text) : 0;
                }
            }

            return noSaveError;
        }

        /// <summary>
        /// Data Validation
        /// </summary>
        /// <returns></returns>
        private bool _DoValidate()
        {
            bool retVal = true;
            string validationErrors = "";

            ErrorText.Visible = false;
            ErrorText.InnerHtml = "";

            /* 
             * TODO: Validation code goes here
             * In case of Validation failure, the following needs to happen:
             * 1) ErrorText.Visible = true;
             * 2) ErrorText.InnerHtml += validationErrors;
             * 3) retVal = false;
             */

            return retVal;
        }

        /// <summary>
        /// Set the values of the Input controls
        /// </summary>
        private void InitFields(bool isState)
        {
            if (isState)
            {
                // State POPS displays PROVIDER information
                BO_Provider boProvider = CurrentProvider;

                TextBoxHoursMinutes.Text = (boProvider != null) ? boProvider.HoursMinutes : "";
                TextBoxHoursMinutes1.Text = (boProvider != null) ? boProvider.HoursMinutes1 : "";
                listAmPm.SelectedValue = (boProvider != null) ? boProvider.AmPM : null;
                listAmPm1.SelectedValue = (boProvider != null) ? boProvider.AmPm1 : null;
                CheckBoxDayOfOperationMon.Checked = (boProvider != null && boProvider.DayOfOperationMon != null && boProvider.DayOfOperationMon != "") ? true : false;
                CheckBoxDayOfOperationTue.Checked = (boProvider != null && boProvider.DayOfOperationTue != null && boProvider.DayOfOperationTue != "") ? true : false;
                CheckBoxDayOfOperationWed.Checked = (boProvider != null && boProvider.DayOfOperationWed != null && boProvider.DayOfOperationWed != "") ? true : false;
                CheckBoxDayOfOperationThu.Checked = (boProvider != null && boProvider.DayOfOperationThu != null && boProvider.DayOfOperationThu != "") ? true : false;
                CheckBoxDayOfOperationFri.Checked = (boProvider != null && boProvider.DayOfOperationFri != null && boProvider.DayOfOperationFri != "") ? true : false;
                CheckBoxDayOfOperationSat.Checked = (boProvider != null && boProvider.DayOfOperationSat != null && boProvider.DayOfOperationSat != "") ? true : false;
                CheckBoxDayOfOperationSun.Checked = (boProvider != null && boProvider.DayOfOperationSun != null && boProvider.DayOfOperationSun != "") ? true : false;
                TextNumOperatingRooms.Text = (boProvider != null && boProvider.NumOperatingRooms != null) ? boProvider.NumOperatingRooms.Value.ToString() : "";
            }
            else
            {
                // Public POPS displays APPLICATION information
                BO_Application boApplication = CurrentAppProvider;

                TextBoxHoursMinutes.Text = (boApplication != null) ? boApplication.HoursMinutes : "";
                TextBoxHoursMinutes1.Text = (boApplication != null) ? boApplication.HoursMinutes1 : "";
                listAmPm.SelectedValue = (boApplication != null) ? boApplication.AmPM : null;
                listAmPm1.SelectedValue = (boApplication != null) ? boApplication.AmPm1 : null;
                CheckBoxDayOfOperationMon.Checked = (boApplication != null && boApplication.DayOfOperationMon != null && boApplication.DayOfOperationMon != "") ? true : false;
                CheckBoxDayOfOperationTue.Checked = (boApplication != null && boApplication.DayOfOperationTue != null && boApplication.DayOfOperationTue != "") ? true : false;
                CheckBoxDayOfOperationWed.Checked = (boApplication != null && boApplication.DayOfOperationWed != null && boApplication.DayOfOperationWed != "") ? true : false;
                CheckBoxDayOfOperationThu.Checked = (boApplication != null && boApplication.DayOfOperationThu != null && boApplication.DayOfOperationThu != "") ? true : false;
                CheckBoxDayOfOperationFri.Checked = (boApplication != null && boApplication.DayOfOperationFri != null && boApplication.DayOfOperationFri != "") ? true : false;
                CheckBoxDayOfOperationSat.Checked = (boApplication != null && boApplication.DayOfOperationSat != null && boApplication.DayOfOperationSat != "") ? true : false;
                CheckBoxDayOfOperationSun.Checked = (boApplication != null && boApplication.DayOfOperationSun != null && boApplication.DayOfOperationSun != "") ? true : false;
                TextNumOperatingRooms.Text = (boApplication != null && boApplication.NumOperatingRooms != null) ? boApplication.NumOperatingRooms.Value.ToString() : "";
            }
        }

        /// <summary>
        /// Maintain the BO_Provider object in ViewState
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
        /// Get the Current Application object from the Session
        /// </summary>
        private BO_Application CurrentAppProvider
        {
            get
            {
                return Session["CurrentAppProvider"] == null ? null : (BO_Application)Session["CurrentAppProvider"];
            }
        }
    }
}