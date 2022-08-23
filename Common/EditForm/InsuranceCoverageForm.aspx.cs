using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ATG;
using ATG.BusinessObject;
using AppControl;
using Telerik.Web.UI;

namespace Common.EditForm
{
    public partial class InsuranceCoverageFormPage : System.Web.UI.Page
    {
        private AppControl.InsuranceCoveragesForm insuranceCoverageForm = null;
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            insuranceCoverageForm = (InsuranceCoveragesForm)LoadControl("~/AppControl/InsuranceCoveragesForm.ascx");
            InsuranceCoverages.Controls.Add(insuranceCoverageForm);
            insuranceCoverageForm.ID = "InsuranceCoveragesEditForm";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Request.QueryString["popsIntId"].Equals(String.Empty))
                insuranceCoverageForm.LoadInsuranceCoverage(
                    Convert.ToDecimal(Request.QueryString["popsIntId"].ToString()),
                    Request.QueryString["carrierCode"].ToString(),
                    Request.QueryString["coverageType"].ToString(),
                    Convert.ToDateTime(Request.QueryString["effectiveDate"].ToString())
                );
            else
                insuranceCoverageForm.LoadInsuranceCoverage();
        }
    }
}
