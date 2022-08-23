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
    public partial class EmploymentEditForm : System.Web.UI.UserControl
    {
        protected void Page_Load( object sender, EventArgs e )
        {

        }

        public DateTime? StartDate
        {
            get
            {
                return null == dtStartDate.SelectedDate ? dtStartDate.SelectedDate : dtStartDate.SelectedDate.Value;

            }
            set
            {
                dtStartDate.SelectedDate = value;
            }
        }

        public DateTime? EndDate
        {
            get
            {
                return null == dtEndDate.SelectedDate ? dtEndDate.SelectedDate : dtEndDate.SelectedDate.Value;
            }
            set
            {
                dtEndDate.SelectedDate = value;
            }
        }

        public string FacilityName
        {
            get
            {
                return txtFacilityName.Text;
            }
            set
            {
                txtFacilityName.Text = value;
            }
        }

        public string FacilityAddress
        {
            get
            {
                return txtFacilityAddress.Text;
            }
            set
            {
                txtFacilityAddress.Text = value;
            }
        }

        public string JobDuties
        {
            get
            {
                return txtJobDuties.Text;
            }
            set
            {
                txtJobDuties.Text = value;
            }
        }

        public bool ValidateData()
        {
            bool IsValid = true;
            string validationErrors = "";

            EmploymentErrorText.Visible = false;
            EmploymentErrorText.InnerHtml = "";

            //if ( null == StartDate )
            //{
            //    validationErrors += "Start Date is Required<br/>";
            //    IsValid = false;
            //}

            //if ( null == EndDate )
            //{
            //    validationErrors += "End Date is Required<br/>";
            //    IsValid = false;
            //}

            //if ( null == FacilityName || FacilityName.Length < 1 )
            //{
            //    validationErrors += "Facility Name is Required<br/>";
            //    IsValid = false;
            //}

            //if ( null == FacilityAddress || FacilityAddress.Length < 1 )
            //{
            //    validationErrors += "Facility Address is Required<br/>";
            //    IsValid = false;
            //}


            //if ( !IsValid )
            //{
            //    // display the error message
            //    ErrorText.Visible = true;
            //    ErrorText.InnerHtml += validationErrors;
            //}

            return IsValid;
        }

        //update driver person
        public void LoadEmployment(decimal employmentID, decimal personID)
        {
            if (!IsPostBack)
            {

                BO_Employment employment = BO_Employment.SelectOne(new BO_EmploymentPrimaryKey(employmentID, personID));

                dtStartDate.SelectedDate = employment.StartDate;
                dtEndDate.SelectedDate = employment.EndDate;
                txtFacilityName.Text = employment.FacilityName;
                txtFacilityAddress.Text = employment.FacilityAddress;
                txtJobDuties.Text = employment.JobDutySummary;

                EmploymentID = employmentID;
                EmploymentPersonID = personID;
                btnEmploymentUpdate.Visible = true;
            }
        }
        //insert driver person
        public void LoadEmployment(decimal personID)
        {
            if (!IsPostBack)
            {
                EmploymentPersonID = personID;
                btnEmploymentInsert.Visible = true;
            }
        }

        protected void Employment_Update(Object sender, EventArgs e)
        {
            BO_Employment employment = new BO_Employment();
            employment.EmploymentID = EmploymentID;
            employment.PersonID = EmploymentPersonID;
            employment.StartDate = dtStartDate.SelectedDate;
            employment.EndDate = dtEndDate.SelectedDate;
            employment.FacilityName = txtFacilityName.Text;
            employment.FacilityAddress = txtFacilityAddress.Text;
            employment.JobDutySummary = txtJobDuties.Text;
            employment.Update();

            Page.ClientScript.RegisterStartupScript(Page.GetType(), "CloseRebindEmployment", "CloseAndRebind();", true);
        }

        protected void Employment_Insert(Object sender, EventArgs e)
        {
            BO_Employment employment = new BO_Employment();
            employment.PersonID = EmploymentPersonID;
            employment.StartDate = dtStartDate.SelectedDate;
            employment.EndDate = dtEndDate.SelectedDate;
            employment.FacilityName = txtFacilityName.Text;
            employment.FacilityAddress = txtFacilityAddress.Text;
            employment.JobDutySummary = txtJobDuties.Text;
            employment.Insert();

            Page.ClientScript.RegisterStartupScript(Page.GetType(), "CloseRebindEmployment", "CloseAndRebind();", true);
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

        private decimal EmploymentID
        {
            get
            {
                return (decimal)ViewState["EmploymentID"];
            }

            set
            {
                ViewState["EmploymentID"] = value;
            }
        }

        private decimal EmploymentPersonID
        {
            get
            {
                return (decimal)ViewState["EmploymentPersonID"];
            }

            set
            {
                ViewState["EmploymentPersonID"] = value;
            }
        }
    }
}