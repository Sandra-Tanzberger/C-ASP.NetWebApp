using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Common.EditForm
{
    public partial class ParishesSubstationsForm : System.Web.UI.Page
    {
        private AppControl.ParishesSubstationsForm _parishesSubstationsForm = null;
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            _parishesSubstationsForm = (AppControl.ParishesSubstationsForm)LoadControl("~/AppControl/ParishesSubstationsForm.ascx");
            ParishesSubstations.Controls.Add(_parishesSubstationsForm);
            _parishesSubstationsForm.ID = "ParishesSubstationsEditForm";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Request.QueryString["substationid"].Equals(String.Empty))
                _parishesSubstationsForm.LoadSubstation(Convert.ToDecimal(Request.QueryString["substationid"].ToString()));
            else
                _parishesSubstationsForm.LoadSubstation();
        }
    }
}
