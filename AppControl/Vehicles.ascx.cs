using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using ATG;
using ATG.BusinessObject;
using ATG.GridHelper;

namespace AppControl
{
    public partial class Vehicles : System.Web.UI.UserControl
    {
        public void LoadVehicles()
        {
            HideVehiclesGridNavControls = true;
        }

        protected void grdVehicles_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (HideVehiclesGridNavControls)
            {
                if (e.Item is GridCommandItem)
                {
                    LinkButton addButton = (LinkButton)e.Item.FindControl("btnAddVehicles");
                    addButton.Visible = false;
                    LinkButton editButton = (LinkButton)e.Item.FindControl("btnEditVehicles");
                    editButton.Visible = false;
                    LinkButton deleteButton = (LinkButton)e.Item.FindControl("btnDeleteVehicles");
                    deleteButton.Visible = false;
                    LinkButton refreshButton = (LinkButton)e.Item.FindControl("btnRefreshVehicles");
                    refreshButton.Visible = false;
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _InitVehiclesGridColumns(VehiclesGridHelper.GridColumnList());
            }

        }

        protected void VehiclesGrid_NeedsDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            VehiclesGridHelper vehiclesGridHelper = new VehiclesGridHelper();
            vehiclesGridHelper.InitializeVehiclesGrid(new BO_ProviderPrimaryKey(CurrentProvider.PopsIntID),CurrentProvider.ProgramID);
            grdVehicles.DataSource = vehiclesGridHelper.GridDataSource;
        }

        protected void grdVehicles_ItemCommand(object sender, GridCommandEventArgs e)
        {
            string _vehrecid = "";

            if (e.CommandName.Equals("Add"))
            {
                RadWinVehicles.NavigateUrl = "~/Common/EditForm/VehicleForm.aspx?vehrecid=";
                RadWinVehicles.VisibleStatusbar = false;
                RadWinVehicles.VisibleOnPageLoad = true;
                RadWinVehicles.Height = Unit.Pixel(600);
                RadWinVehicles.Width = Unit.Pixel(840);
                RadWinVehicles.Behaviors = WindowBehaviors.None;

                RadWinVehicles.Modal = true;
                RadWinVehicles.VisibleOnPageLoad = true;
                RadWinVehicles.Height = Unit.Pixel(525);
                RadWinVehicles.Width = Unit.Pixel(840);
                RadWinVehicles.Title = "Add Vehicle";
                RadWindowManagerVehicles.Style.Add("z-index", "9999");
            }

            if (grdVehicles.SelectedItems.Count > 0)
            {
                foreach (Telerik.Web.UI.GridDataItem item in grdVehicles.SelectedItems)
                {
                    _vehrecid = item["VehicleRecID"].Text;
                }

                if (e.CommandName.Equals("Edit"))
                {
                    RadWinVehicles.NavigateUrl = "~/Common/EditForm/VehicleForm.aspx?vehrecid=" + _vehrecid;
                    RadWinVehicles.VisibleStatusbar = false;
                    RadWinVehicles.VisibleOnPageLoad = true;
                    RadWinVehicles.Height = Unit.Pixel(600);
                    RadWinVehicles.Width = Unit.Pixel(840);
                    RadWinVehicles.Behaviors = WindowBehaviors.None;

                    RadWinVehicles.Modal = true;
                    RadWinVehicles.VisibleOnPageLoad = true;
                    RadWinVehicles.Height = Unit.Pixel(525);
                    RadWinVehicles.Width = Unit.Pixel(840);
                    RadWinVehicles.Title = "Edit Vehicle";
                    RadWindowManagerVehicles.Style.Add("z-index", "9999");
                }

                if (e.CommandName.Equals("Delete"))
                {
                    //delete substations
                    BO_Vehicle vehicle = BO_Vehicle.SelectOne(new BO_VehiclePrimaryKey(Convert.ToDecimal(_vehrecid), CurrentProvider.PopsIntID));
                    _subtractVehicleTotals(vehicle.TypeVehicle.ToUpper());
                    vehicle.Delete();
                    //BO_Vehicle.Delete(new BO_VehiclePrimaryKey(Convert.ToDecimal(_vehrecid), CurrentProvider.PopsIntID));
                    VehiclesGridDataBind();
                }
            }

            if (e.CommandName.Equals("Rebind"))
            {
                VehiclesGridDataBind();
            }
        }

        public void VehiclesGridDataBind()
        {
            VehiclesGridHelper vehiclesGridHelper = new VehiclesGridHelper();
            vehiclesGridHelper.InitializeVehiclesGrid(new BO_ProviderPrimaryKey(CurrentProvider.PopsIntID), CurrentProvider.ProgramID);
            grdVehicles.DataSource = vehiclesGridHelper.GridDataSource;
            grdVehicles.DataBind();
        }

        private void _InitVehiclesGridColumns(GridBoundColumn[] inColumnList)
        {
            foreach (GridBoundColumn tmpCol in inColumnList)
            {
                GridBoundColumn gbc = new GridBoundColumn();
                grdVehicles.Columns.Add(gbc);
                gbc.UniqueName = tmpCol.UniqueName;
                gbc.DataField = tmpCol.DataField;
                gbc.HeaderText = tmpCol.HeaderText;
                gbc.Visible = tmpCol.Visible;
                gbc.AllowFiltering = tmpCol.AllowFiltering;
                gbc.HeaderStyle.Width = tmpCol.HeaderStyle.Width;
            }
        }

        private bool HideVehiclesGridNavControls
        {
            get
            {
                if (ViewState["HideVehiclesGridNavControls"] == null)
                    return false;
                else
                    return (bool)ViewState["HideVehiclesGridNavControls"];
            }

            set
            {
                ViewState["HideVehiclesGridNavControls"] = value;
            }
        }

        private BO_Provider CurrentProvider
        {
            get
            {
                return Session["CurrentProvider"] == null ? null : (BO_Provider)Session["CurrentProvider"];
            }
        }

        private BO_Application CurrentAppProvider
        {
            get
            {
                return Session["CurrentAppProvider"] == null ? null : (BO_Application)Session["CurrentAppProvider"];
            }
        }

        private void _subtractVehicleTotals(string vehicleType)
        {
            switch (vehicleType.ToUpper())
            {
                case "C":
                    CurrentAppProvider.NoOfAirAmbulances = (Int32.Parse(CurrentAppProvider.NoOfAirAmbulances) - 1).ToString();
                    break;
                case "S":
                    CurrentAppProvider.NoOfSprintVehicles = (Int32.Parse(CurrentAppProvider.NoOfSprintVehicles) - 1).ToString();
                    break;
                case "G":
                    CurrentAppProvider.NoOfGroundAmbulances = (Int32.Parse(CurrentAppProvider.NoOfGroundAmbulances) - 1).ToString();
                    break;
                case "A":
                    CurrentAppProvider.NoOfAmbulatoryVehicles = (Int32.Parse(CurrentAppProvider.NoOfAmbulatoryVehicles) - 1).ToString();
                    break;
                //case "B"://not yet implemented
                //break;
                case "H":
                    CurrentAppProvider.NoOfHandicappedVehicles = (Int32.Parse(CurrentAppProvider.NoOfHandicappedVehicles) - 1).ToString();
                    break;
            }
        }
    }
}