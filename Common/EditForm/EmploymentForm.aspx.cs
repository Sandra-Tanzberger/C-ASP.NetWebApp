using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Common.EditForm
{
    public partial class EmploymentForm : System.Web.UI.Page
    {
        private AppControl.EmploymentEditForm _employmenteditform = null;
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            _employmenteditform = (AppControl.EmploymentEditForm)LoadControl("~/AppControl/EmploymentEditForm.ascx");
            Employment.Controls.Add(_employmenteditform);
            _employmenteditform.ID = "EmploymentEditForm";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Request.QueryString["employmentid"].Equals(String.Empty))
                _employmenteditform.LoadEmployment(Convert.ToDecimal(Request.QueryString["employmentid"].ToString()), Convert.ToDecimal(Request.QueryString["personid"].ToString()));
            else
                _employmenteditform.LoadEmployment(Convert.ToDecimal(Request.QueryString["personid"].ToString()));
        }
    }
}
