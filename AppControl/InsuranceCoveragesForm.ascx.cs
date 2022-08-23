using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using ATG;
using ATG.BusinessObject;
using GenFunc;

namespace AppControl
{
    public partial class InsuranceCoveragesForm : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public void LoadInsuranceCoverage(
            decimal popsIntId
          , string carrierCode
          , string coverageType
          , DateTime effectiveDate
        ) {
            if (!IsPostBack)
            {
                _Init();

                BO_InsuranceCoverage boInsuranceCoverage = BO_InsuranceCoverage.SelectOne(new BO_InsuranceCoveragePrimaryKey(popsIntId, carrierCode, coverageType, effectiveDate));
                ddlCoverageType.SelectedValue = boInsuranceCoverage.CoverageType;
                txtCoverageLimit.Text = boInsuranceCoverage.CoverageLimit.ToString();
                ddlCarrier.SelectedValue = boInsuranceCoverage.CarrierCode;
                txtPolicyNum.Text = boInsuranceCoverage.PolicyNum;
                
                if (null != boInsuranceCoverage.EffectiveDate) {
                    txtEffectiveDate.SelectedDate = boInsuranceCoverage.EffectiveDate;
                }
                
                if (null != boInsuranceCoverage.ExpirationDate) {
                    txtExpirationDate.SelectedDate = boInsuranceCoverage.ExpirationDate;
                }
                
                if (null != boInsuranceCoverage.PrepaymentDueDate) {
                    txtPrePaymentDueDate.SelectedDate = boInsuranceCoverage.PrepaymentDueDate;
                }

                // can't update pk
                _DisablePkFields();

                // save pk to viewstate
                CarrierCode = carrierCode;
                CoverageType = coverageType;
                EffectiveDate = effectiveDate;

                btnInsuranceUpdate.Visible = true;
            }
        }


        public void LoadInsuranceCoverage() {
            if (!IsPostBack) {
                _Init();

                btnInsuranceInsert.Visible = true;
            }
        }

        protected void _Init() {
            // coverage type
            ddlCoverageType.DataSource = BO_LookupValue.SelectByField(BO_LookupValueFields.LookupKey, "COVERAGE_TYPE");
            ddlCoverageType.DataTextField = "Valdesc";
            ddlCoverageType.DataValueField = "LookupVal";
            ddlCoverageType.DataBind();

            // carrier
            ddlCarrier.DataSource = GenericSorter<BO_InsuranceCarrier>.Sort(BO_InsuranceCarrier.SelectAll(), "CarrierName", "asc");
            ddlCarrier.DataTextField = "CarrierName";
            ddlCarrier.DataValueField = "CarrierCode";
            ddlCarrier.DataBind();

            // prepayement due date
            if (CurrentProvider.ProgramID != "NE") {
                lblPrepaymentDueDate.Visible = false;
                txtPrePaymentDueDate.Visible = false;
            }
        }

        protected void _DisablePkFields() {
            ddlCoverageType.Enabled = false;
            ddlCarrier.Enabled = false;
            txtEffectiveDate.Enabled = false;
        }

        protected bool _Validate() {
            string errorText = "";
            InsuranceCoverageErrorText.InnerHtml = "";
            InsuranceCoverageErrorText.Visible = false;

            if (null == txtEffectiveDate.SelectedDate) {
                errorText += "Effective Date must be entered.<br/>";
            }

            if (null == txtExpirationDate.SelectedDate) {
                errorText += "Expiration Date must be entered.<br/>";
            }

            if (txtExpirationDate.SelectedDate <= txtEffectiveDate.SelectedDate) {
                errorText += "Expiration Date must be later than Effective Date.<br/>";
            }

            if (0 == txtCoverageLimit.Text.Length) {
                errorText += "Coverage Limit must be entered.<br/>";
            }

            if (0 == txtPolicyNum.Text.Length) {
                errorText += "Policy Number must be entered.<br/>";
            }

            if (errorText.Length > 0) {
                InsuranceCoverageErrorText.InnerHtml = errorText;
                InsuranceCoverageErrorText.Visible = true;
                return false;
            }

            return true;
        }

        protected void Insurance_Update(Object sender, EventArgs e) 
        {
            if (!_Validate()) {
                return;
            }

            BO_InsuranceCoverage insuranceCoverage = BO_InsuranceCoverage.SelectOne(new BO_InsuranceCoveragePrimaryKey(CurrentProvider.PopsIntID, CarrierCode, CoverageType, EffectiveDate));
            insuranceCoverage.ExpirationDate = txtExpirationDate.SelectedDate;
            insuranceCoverage.PolicyNum = txtPolicyNum.Text;
            insuranceCoverage.PrepaymentDueDate = txtPrePaymentDueDate.SelectedDate;
            insuranceCoverage.CoverageLimit = Convert.ToDecimal(txtCoverageLimit.Text);
            insuranceCoverage.Update();

            // save pk to viewstate
            CarrierCode = insuranceCoverage.CarrierCode;
            CoverageType = insuranceCoverage.CoverageType;
            EffectiveDate = insuranceCoverage.EffectiveDate;

            Page.ClientScript.RegisterStartupScript(Page.GetType(), "CloseRebindInsuranceCoverage", "CloseAndRebind();", true); 
        }

        protected void Insurance_Insert(Object sender, EventArgs e)
        {
            if (!_Validate()) {
                return;
            }

            BO_InsuranceCoverage insuranceCoverage = new BO_InsuranceCoverage();
            insuranceCoverage.PopsIntID = CurrentProvider.PopsIntID;
            insuranceCoverage.CarrierCode = ddlCarrier.SelectedValue;
            insuranceCoverage.CoverageType = ddlCoverageType.SelectedValue;
            insuranceCoverage.EffectiveDate = txtEffectiveDate.SelectedDate;
            insuranceCoverage.ExpirationDate = txtExpirationDate.SelectedDate;
            insuranceCoverage.PrepaymentDueDate = txtPrePaymentDueDate.SelectedDate;
            insuranceCoverage.PolicyNum = txtPolicyNum.Text;
            insuranceCoverage.CoverageLimit = Convert.ToDecimal(txtCoverageLimit.Text);
            insuranceCoverage.Insert();

            _DisablePkFields();

            Page.ClientScript.RegisterStartupScript(Page.GetType(), "CloseRebindInsuranceCoverage", "CloseAndRebind();", true);

            /*
            // save pk to viewstate
            CarrierCode = insuranceCoverage.CarrierCode;
            CoverageType = insuranceCoverage.CoverageType;
            EffectiveDate = insuranceCoverage.EffectiveDate;

            btnInsuranceInsert.Visible = false;
            btnInsuranceUpdate.Visible = true;
            */
        }


        private BO_Provider CurrentProvider {
            get {
                return Session["CurrentProvider"] == null ? null : (BO_Provider)Session["CurrentProvider"];
            }
            set {
                Session["CurrentProvider"] = value;
            }
        }

        private string CarrierCode {
            get {
                return (string)ViewState["CarrierCode"];
            }

            set {
                ViewState["CarrierCode"] = value;
            }
        }

        private string CoverageType {
            get {
                return (string)ViewState["CoverageType"];
            }

            set {
                ViewState["CoverageType"] = value;
            }
        }

        private DateTime? EffectiveDate {
            get {
                return (DateTime)ViewState["EffectiveDate"];
            }

            set {
                ViewState["EffectiveDate"] = value;
            }
        }
    }
}