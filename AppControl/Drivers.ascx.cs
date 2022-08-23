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
    public partial class Drivers : System.Web.UI.UserControl
    {
        bool hideControls = false;

        public void LoadDrivers()
        {
            HideDriversGridNavControls = true;
        }

        protected void grdDrivers_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (HideDriversGridNavControls)
            {
                if (e.Item is GridCommandItem)
                {
                    LinkButton addButton = (LinkButton)e.Item.FindControl("btnAdd");
                    addButton.Visible = false;
                    LinkButton editButton = (LinkButton)e.Item.FindControl("btnEdit");
                    editButton.Visible = false;
                    LinkButton deleteButton = (LinkButton)e.Item.FindControl("btnDelete");
                    deleteButton.Visible = false;
                    LinkButton refreshButton = (LinkButton)e.Item.FindControl("btnRefreshDrivers");
                    refreshButton.Visible = false;
                }
            }
        } 

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _InitDriverGridColumns(DriverGridHelper.GridColumnList());
            }
        }

        protected void DriversGrid_NeedsDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            DriverGridHelper driverGridHelper = new DriverGridHelper();
            driverGridHelper.InitializeDriversGrid((new BO_ProviderPrimaryKey(CurrentAppProvider.PopsIntID)), (new BO_ApplicationPrimaryKey(CurrentAppProvider.ApplicationID)), "10");//Person_Type 10 = Driver
            grdDrivers.DataSource = driverGridHelper.GridDataSource;
        }

        protected void grdDrivers_ItemCommand(object sender, GridCommandEventArgs e)
        {
            string personID = "";

            if (e.CommandName.Equals("Add"))
            {
                RadWinDrivers.NavigateUrl = "~/Common/EditForm/DriverForm.aspx?personid=";
                RadWinDrivers.VisibleStatusbar = false;
                RadWinDrivers.VisibleOnPageLoad = true;
                RadWinDrivers.Height = Unit.Pixel(600);
                RadWinDrivers.Width = Unit.Pixel(800);
                RadWinDrivers.Behaviors = WindowBehaviors.None;

                RadWinDrivers.Modal = true;
                RadWinDrivers.VisibleOnPageLoad = true;
                RadWinDrivers.Height = Unit.Pixel(525);
                RadWinDrivers.Width = Unit.Pixel(730);
                RadWinDrivers.Title = "Add Driver";
                RadWindowManagerDrivers.Style.Add("z-index", "9999");
            }

            if (grdDrivers.SelectedItems.Count > 0)
            {
                foreach (Telerik.Web.UI.GridDataItem item in grdDrivers.SelectedItems)
                {
                    personID = item["PersonID"].Text;
                }

                if (e.CommandName.Equals("Edit"))
                {
                    RadWinDrivers.NavigateUrl = "~/Common/EditForm/DriverForm.aspx?personid=" + personID;
                    RadWinDrivers.VisibleStatusbar = false;
                    RadWinDrivers.VisibleOnPageLoad = true;
                    RadWinDrivers.Height = Unit.Pixel(600);
                    RadWinDrivers.Width = Unit.Pixel(800);
                    RadWinDrivers.Behaviors = WindowBehaviors.None;

                    RadWinDrivers.Modal = true;
                    RadWinDrivers.VisibleOnPageLoad = true;
                    RadWinDrivers.Height = Unit.Pixel(525);
                    RadWinDrivers.Width = Unit.Pixel(730);
                    RadWinDrivers.Title = "Edit Driver";
                    RadWindowManagerDrivers.Style.Add("z-index", "9999");
                }

                if (e.CommandName.Equals("Delete"))
                {
                    //custom dev., need to create stored procedure to only delete driver persons from the application/provider_person record unless that person record does not belong to any other applications.
                    BO_ProviderPerson _providerPerson = new BO_ProviderPerson();
                    _providerPerson.PopsIntID = CurrentAppProvider.PopsIntID;
                    _providerPerson.ApplicationID = CurrentAppProvider.ApplicationID;
                    _providerPerson.PersonID = Convert.ToDecimal(personID);
                    _providerPerson.DeleteProviderPerson();
                    DriversGridDataBind();
                }
            }

            if (e.CommandName.Equals("Rebind"))
            {
                DriversGridDataBind();
            }
        }

        public void DriversGridDataBind()
        {
            DriverGridHelper driverGridHelper = new DriverGridHelper();
            driverGridHelper.InitializeDriversGrid((new BO_ProviderPrimaryKey(CurrentAppProvider.PopsIntID)), (new BO_ApplicationPrimaryKey(CurrentAppProvider.ApplicationID)), "10");//Person_Type 10 = Driver
            grdDrivers.DataSource = driverGridHelper.GridDataSource;
            grdDrivers.DataBind();
        }

        private void _InitDriverGridColumns(GridBoundColumn[] inColumnList)
        {
            foreach (GridBoundColumn tmpCol in inColumnList)
            {
                GridBoundColumn gbc = new GridBoundColumn();
                grdDrivers.Columns.Add(gbc);
                gbc.UniqueName = tmpCol.UniqueName;
                gbc.DataField = tmpCol.DataField;
                gbc.HeaderText = tmpCol.HeaderText;
                gbc.Visible = tmpCol.Visible;
                gbc.AllowFiltering = tmpCol.AllowFiltering;
                gbc.HeaderStyle.Width = tmpCol.HeaderStyle.Width;
            }
        }

        private bool HideDriversGridNavControls
        {
            get
            {
                if (ViewState["HideDriversGridNavControls"] == null)
                    return false;
                else
                    return (bool)ViewState["HideDriversGridNavControls"];
            }

            set
            {
                ViewState["HideDriversGridNavControls"] = value;
            }
        }

        private BO_Application CurrentAppProvider
        {
            get
            {
                return Session["CurrentAppProvider"] == null ? null : (BO_Application)Session["CurrentAppProvider"];
            }
            set
            {
                Session["CurrentAppProvider"] = value;
            }
        }
    }
}