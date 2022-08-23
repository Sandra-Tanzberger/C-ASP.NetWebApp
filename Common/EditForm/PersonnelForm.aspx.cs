using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Common.EditForm
{
    public partial class PersonnelForm : System.Web.UI.Page
    {
        private AppControl.PersonnelForm _personnel = null;
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            _personnel = (AppControl.PersonnelForm)LoadControl("~/AppControl/PersonnelForm.ascx");
            Personnel.Controls.Add(_personnel);
            _personnel.ID = "PersonnelEditForm";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Request.QueryString["personid"].Equals(String.Empty))
                _personnel.LoadPersonnel(Convert.ToDecimal(Request.QueryString["personid"].ToString()));
            else
                _personnel.LoadPersonnel();
        }
    }
}
