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
    public partial class ParishesSubstations : System.Web.UI.UserControl
    {
        bool hideControls = false;

        public void LoadSubstations()
        {
            HideParishesSubstationsGridNavControls = true;
        }

        protected void grdSubstations_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (HideParishesSubstationsGridNavControls)
            {
                if (e.Item is GridCommandItem)
                {
                    LinkButton addButton = (LinkButton)e.Item.FindControl("btnAddSubstations");
                    addButton.Visible = false;
                    LinkButton editButton = (LinkButton)e.Item.FindControl("btnEditSubstations");
                    editButton.Visible = false;
                    LinkButton deleteButton = (LinkButton)e.Item.FindControl("btnDeleteSubstations");
                    deleteButton.Visible = false;
                    LinkButton refreshButton = (LinkButton)e.Item.FindControl("btnRefreshSubstations");
                    refreshButton.Visible = false;
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _InitSubstationsGridColumns(ParishesSubstationsGridHelper.GridColumnList());
            }
        }

        protected void SubstationsGrid_NeedsDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            ParishesSubstationsGridHelper substationsGridHelper = new ParishesSubstationsGridHelper();
            substationsGridHelper.InitializeSubstationsGrid(new BO_ProviderPrimaryKey(CurrentProvider.PopsIntID));
            grdSubstations.DataSource = substationsGridHelper.GridDataSource;
        }

        protected void grdSubstations_ItemCommand(object sender, GridCommandEventArgs e)
        {
            string _substationid = "";

            if (e.CommandName.Equals("Add"))
            {
                RadWinSubstations.NavigateUrl = "~/Common/EditForm/ParishesSubstationsForm.aspx?substationid=";
                RadWinSubstations.VisibleStatusbar = false;
                RadWinSubstations.VisibleOnPageLoad = true;
                RadWinSubstations.Height = Unit.Pixel(600);
                RadWinSubstations.Width = Unit.Pixel(800);
                RadWinSubstations.Behaviors = WindowBehaviors.None;

                RadWinSubstations.Modal = true;
                RadWinSubstations.VisibleOnPageLoad = true;
                RadWinSubstations.Height = Unit.Pixel(525);
                RadWinSubstations.Width = Unit.Pixel(730);
                RadWinSubstations.Title = "Add Parishes & Substations";
                RadWindowManagerSubstations.Style.Add("z-index", "9999");
            }

            if (grdSubstations.SelectedItems.Count > 0)
            {
                foreach (Telerik.Web.UI.GridDataItem item in grdSubstations.SelectedItems)
                {
                    _substationid = item["SubstationID"].Text;
                }

                if (e.CommandName.Equals("Edit"))
                {
                    RadWinSubstations.NavigateUrl = "~/Common/EditForm/ParishesSubstationsForm.aspx?substationid=" + _substationid;
                    RadWinSubstations.VisibleStatusbar = false;
                    RadWinSubstations.VisibleOnPageLoad = true;
                    RadWinSubstations.Height = Unit.Pixel(600);
                    RadWinSubstations.Width = Unit.Pixel(800);
                    RadWinSubstations.Behaviors = WindowBehaviors.None;

                    RadWinSubstations.Modal = true;
                    RadWinSubstations.VisibleOnPageLoad = true;
                    RadWinSubstations.Height = Unit.Pixel(525);
                    RadWinSubstations.Width = Unit.Pixel(730);
                    RadWinSubstations.Title = "Edit Parishes & Substations";
                    RadWindowManagerSubstations.Style.Add("z-index", "9999");
                }

                if (e.CommandName.Equals("Delete"))
                {
                    //delete substations
                    BO_Substation.Delete(new BO_SubstationPrimaryKey(CurrentProvider.PopsIntID, Convert.ToDecimal(_substationid)));
                    SubstationsGridDataBind();
                }
            }

            if (e.CommandName.Equals("Rebind"))
            {
                SubstationsGridDataBind();
            }
        }

        public void SubstationsGridDataBind()
        {
            ParishesSubstationsGridHelper substationsGridHelper = new ParishesSubstationsGridHelper();
            substationsGridHelper.InitializeSubstationsGrid(new BO_ProviderPrimaryKey(CurrentProvider.PopsIntID));
            grdSubstations.DataSource = substationsGridHelper.GridDataSource;
            grdSubstations.DataBind();
        }

        private void _InitSubstationsGridColumns(GridBoundColumn[] inColumnList)
        {
            foreach (GridBoundColumn tmpCol in inColumnList)
            {
                GridBoundColumn gbc = new GridBoundColumn();
                grdSubstations.Columns.Add(gbc);
                gbc.UniqueName = tmpCol.UniqueName;
                gbc.DataField = tmpCol.DataField;
                gbc.HeaderText = tmpCol.HeaderText;
                gbc.Visible = tmpCol.Visible;
                gbc.AllowFiltering = tmpCol.AllowFiltering;
                gbc.HeaderStyle.Width = tmpCol.HeaderStyle.Width;
            }
        }

        private bool HideParishesSubstationsGridNavControls
        {
            get
            {
                if (ViewState["HideParishesSubstationsGridNavControls"] == null)
                    return false;
                else
                    return (bool)ViewState["HideParishesSubstationsGridNavControls"];
            }

            set
            {
                ViewState["HideParishesSubstationsGridNavControls"] = value;
            }
        }

        private BO_Provider CurrentProvider
        {
            get
            {
                return Session["CurrentProvider"] == null ? null : (BO_Provider)Session["CurrentProvider"];
            }
            set
            {
                Session["CurrentProvider"] = value;
            }
        }
    }
}