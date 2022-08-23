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
    public partial class EducationEditForm : System.Web.UI.UserControl
    {
        protected void Page_Load( object sender, EventArgs e )
        {

        }

        public string CollegeSchool
        {
            get
            {
                return txtCollegeSchool.Text;
            }
            set
            {
                txtCollegeSchool.Text = value;
            }
        }
        
        public DateTime? GraduationDate
        {
            get
            {
                return null == dtGraduationDate.SelectedDate ? dtGraduationDate.SelectedDate : dtGraduationDate.SelectedDate.Value;
            }
            set
            {
                dtGraduationDate.SelectedDate = value;
            }
        }

        public string DegreeObtained
        {
            get
            {
                return txtDegreeObtained.Text;
            }
            set
            {
                txtDegreeObtained.Text = value;
            }
        }

        public bool ValidateData()
        {
            bool IsValid = true;
            string validationErrors = "";

            EducationErrorText.Visible = false;
            EducationErrorText.InnerHtml = "";

            if ( null == CollegeSchool || CollegeSchool.Length < 1 )
            {
                validationErrors += "College/School is Required<br/>";
                IsValid = false;
            }

            if ( null == GraduationDate )
            {
                validationErrors += "Graduation Date is Required<br/>";
                IsValid = false;
            }

            if ( null == DegreeObtained || DegreeObtained.Length < 1 )
            {
                validationErrors += "Degree Obtained is Required<br/>";
                IsValid = false;
            }

            if ( !IsValid )
            {
                // display the error message
                EducationErrorText.Visible = true;
                EducationErrorText.InnerHtml += validationErrors;
            }

            return IsValid;
        }

        //update education
        public void LoadEducation(decimal educationid, decimal personid)
        {
            if (!IsPostBack)
            {
                BO_Education education = BO_Education.SelectOne(new BO_EducationPrimaryKey(educationid, personid));
                txtCollegeSchool.Text = education.CollegeSchool;
                dtGraduationDate.SelectedDate = education.GraduationDate;
                txtDegreeObtained.Text = education.DegreeObtained;

                EducationID = educationid;
                EducationPersonID = personid;

                btnEducationUpdate.Visible = true;
            }
        }
        //insert education
        public void LoadEducation(decimal personid)
        {
            if (!IsPostBack)
            {
                EducationPersonID = personid;
                btnEducationInsert.Visible = true;
            }
        }

        protected void Education_Update(Object sender, EventArgs e)
        {
            BO_Education education = new BO_Education();
            education.EducationID = EducationID;
            education.PersonID = EducationPersonID;
            education.CollegeSchool = txtCollegeSchool.Text;
            education.GraduationDate = dtGraduationDate.SelectedDate;
            education.DegreeObtained = txtDegreeObtained.Text;
            education.Update();
           
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "CloseRebindEducation", "CloseAndRebind();", true);
        }

        protected void Education_Insert(Object sender, EventArgs e)
        {
            BO_Education education = new BO_Education();
            education.PersonID = EducationPersonID;
            education.CollegeSchool = txtCollegeSchool.Text;
            education.GraduationDate = dtGraduationDate.SelectedDate;
            education.DegreeObtained = txtDegreeObtained.Text;
            education.Insert();

            Page.ClientScript.RegisterStartupScript(Page.GetType(), "CloseRebindEducation", "CloseAndRebind();", true);
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

        private decimal EducationPersonID
        {
            get
            {
                return (decimal)ViewState["EducationPersonID"];
            }

            set
            {
                ViewState["EducationPersonID"] = value;
            }
        }

        private decimal EducationID
        {
            get
            {
                return (decimal)ViewState["EducationID"];
            }

            set
            {
                ViewState["EducationID"] = value;
            }
        }
    }
}