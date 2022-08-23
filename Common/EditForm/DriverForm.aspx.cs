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
    public partial class DriverFormPage : System.Web.UI.Page
    {
        private AppControl.DriversForm _drivers = null;
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            _drivers = (DriversForm)LoadControl("~/AppControl/DriversForm.ascx");
            Drivers.Controls.Add(_drivers);
            _drivers.ID = "DriversEditForm";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Request.QueryString["personid"].Equals(String.Empty))
                _drivers.LoadDriver(Convert.ToDecimal(Request.QueryString["personid"].ToString()));
            else
                _drivers.LoadDriver();
        }
    }
}
