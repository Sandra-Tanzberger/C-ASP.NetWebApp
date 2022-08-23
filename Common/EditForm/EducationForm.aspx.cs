using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Common.EditForm
{
    public partial class EducationForm : System.Web.UI.Page
    {
        private AppControl.EducationEditForm _educationeditform = null;
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            _educationeditform = (AppControl.EducationEditForm)LoadControl("~/AppControl/EducationEditForm.ascx");
            Education.Controls.Add(_educationeditform);
            _educationeditform.ID = "EducationEditForm";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Request.QueryString["educationid"].Equals(String.Empty))
                _educationeditform.LoadEducation(Convert.ToDecimal(Request.QueryString["educationid"].ToString()), Convert.ToDecimal(Request.QueryString["personid"].ToString()));
            else
                _educationeditform.LoadEducation(Convert.ToDecimal(Request.QueryString["personid"].ToString()));
        }
    }
}
