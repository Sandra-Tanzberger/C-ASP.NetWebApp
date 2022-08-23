using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Common.EditForm
{
    public partial class VehicleForm : System.Web.UI.Page
    {
        private AppControl.VehiclesForm _vehicleForm = null;
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            _vehicleForm = (AppControl.VehiclesForm)LoadControl("~/AppControl/VehiclesForm.ascx");
            Vehicle.Controls.Add(_vehicleForm);
            _vehicleForm.ID = "VehicleForm";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Request.QueryString["vehrecid"].Equals(String.Empty))
                _vehicleForm.LoadVehicle(Convert.ToDecimal(Request.QueryString["vehrecid"].ToString()));
            else
                _vehicleForm.LoadVehicle();
        }
    }
}
