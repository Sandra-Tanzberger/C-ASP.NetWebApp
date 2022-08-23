using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Common.EditForm
{
    public partial class ProgramStaffForm : System.Web.UI.Page
    {
        private AppControl.ProgramStaffForm _programStaffForm = null;
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            _programStaffForm = (AppControl.ProgramStaffForm)LoadControl("~/AppControl/ProgramStaffForm.ascx");
            ProgramStaff.Controls.Add(_programStaffForm);
            _programStaffForm.ID = "ProgramStaffEditForm";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Request.QueryString["programstaffid"].Equals(String.Empty))
                _programStaffForm.LoadProgramStaff(Convert.ToDecimal(Request.QueryString["programstaffid"].ToString()));
            else
                _programStaffForm.LoadProgramStaff();
        }
    }
}
