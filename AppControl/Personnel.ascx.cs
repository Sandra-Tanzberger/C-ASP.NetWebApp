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
    public partial class Personnel : System.Web.UI.UserControl
    {
        public void LoadApplication(string inAppID, bool inAllowEdit)
        {
            if (!inAllowEdit)
                HidePersonnelGridNavControls = true;
        }

        protected void grdPersonnel_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (HidePersonnelGridNavControls)
            {
                if (e.Item is GridCommandItem)
                {
                    LinkButton addButton = (LinkButton)e.Item.FindControl("btnAddPersonnel");
                    addButton.Visible = false;
                    LinkButton editButton = (LinkButton)e.Item.FindControl("btnEditPersonnel");
                    editButton.Visible = false;
                    LinkButton deleteButton = (LinkButton)e.Item.FindControl("btnDeletePersonnel");
                    deleteButton.Visible = false;
                    LinkButton refreshButton = (LinkButton)e.Item.FindControl("btnRefreshPersonnel");
                    refreshButton.Visible = false;
                }
            }

            if (e.Item is GridDataItem)
            {
                GridDataItem item = (GridDataItem)e.Item;
                RadioButton radbtn = (RadioButton)item.FindControlRecursive("rbPFACAdmin");
                radbtn.Attributes.Add("OnClick", "SelectMeOnly('" + radbtn.ClientID + "')");
                if (item["PrimaryFACAdmin"].Text == "1")
                    radbtn.Checked = true;

            }  
        } 

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _InitPersonnelGridColumns(PersonnelGridHelper.GridColumnList());
            }
        }

        protected void PersonnelGrid_NeedsDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            PersonnelGridHelper personnelGridHelper = new PersonnelGridHelper();
            personnelGridHelper.InitializePersonnelGrid((new BO_ProviderPrimaryKey(CurrentAppProvider.PopsIntID)), (new BO_ApplicationPrimaryKey(CurrentAppProvider.ApplicationID)));
            grdPersonnel.DataSource = personnelGridHelper.GridDataSource;
        }

        protected void grdPersonnel_ItemCommand(object sender, GridCommandEventArgs e)
        {
            string personID = "";

            if (e.CommandName.Equals("SetFACAdmin"))
            {
                foreach (Telerik.Web.UI.GridDataItem item in grdPersonnel.Items)
                {
                    RadioButton radbtn = (RadioButton)item.FindControlRecursive("rbPFACAdmin");
                    if (radbtn.Checked == true)
                    {
                        personID = item["PersonID"].Text;
                        BO_ProviderPerson providerPerson = new BO_ProviderPerson();
                        providerPerson.PopsIntID = CurrentAppProvider.PopsIntID;
                        providerPerson.ApplicationID = CurrentAppProvider.ApplicationID;
                        providerPerson.PersonID = Convert.ToDecimal(personID);
                        providerPerson.SetPrimaryFAC();
                    }
                }
            }

            if (e.CommandName.Equals("Add"))
            {
                RadWinPersonnel.NavigateUrl = "~/Common/EditForm/PersonnelForm.aspx?personid=";
                RadWinPersonnel.VisibleStatusbar = false;
                RadWinPersonnel.VisibleOnPageLoad = true;
                //RadWinPersonnel.Height = Unit.Pixel(600);
                //RadWinPersonnel.Width = Unit.Pixel(800);

                RadWinPersonnel.Modal = true;
                RadWinPersonnel.VisibleOnPageLoad = true;
                //RadWinPersonnel.Height = Unit.Pixel(525);
                //RadWinPersonnel.Width = Unit.Pixel(730);
                RadWinPersonnel.Title = "Add Key Personnel";
                RadWindowManagerPersonnel.Style.Add("z-index", "9999");
                RadWindowManagerPersonnel.Behaviors = WindowBehaviors.Close;
                RadWindowManagerPersonnel.InitialBehaviors = WindowBehaviors.Maximize;
            }

            if (grdPersonnel.SelectedItems.Count > 0)
            {
                foreach (Telerik.Web.UI.GridDataItem item in grdPersonnel.SelectedItems)
                {
                    personID = item["PersonID"].Text;
                }

                if (e.CommandName.Equals("Edit"))
                {
                    RadWinPersonnel.NavigateUrl = "~/Common/EditForm/PersonnelForm.aspx?personid=" + personID;
                    RadWinPersonnel.VisibleStatusbar = false;
                    RadWinPersonnel.VisibleOnPageLoad = true;
                    //RadWinPersonnel.Height = Unit.Pixel(600);
                    //RadWinPersonnel.Width = Unit.Pixel(800);

                    RadWinPersonnel.Modal = true;
                    RadWinPersonnel.VisibleOnPageLoad = true;
                    //RadWinPersonnel.Height = Unit.Pixel(525);
                    //RadWinPersonnel.Width = Unit.Pixel(730);
                    RadWinPersonnel.Title = "Edit Key Personnel";
                    RadWindowManagerPersonnel.Style.Add("z-index", "9999");
                    RadWindowManagerPersonnel.Behaviors = WindowBehaviors.Close;
                    RadWindowManagerPersonnel.InitialBehaviors = WindowBehaviors.Maximize;
                }

                if (e.CommandName.Equals("Delete"))
                {
                    //custom dev., need to create stored procedure to only delete driver persons from the application/provider_person record unless that person record does not belong to any other applications.
                    BO_ProviderPerson _providerPerson = new BO_ProviderPerson();
                    _providerPerson.PopsIntID = CurrentAppProvider.PopsIntID;
                    _providerPerson.ApplicationID = CurrentAppProvider.ApplicationID;
                    _providerPerson.PersonID = Convert.ToDecimal(personID);
                    _providerPerson.DeleteProviderPerson();
                    PersonnelGridDataBind();
                }
            }

            if (e.CommandName.Equals("Rebind"))
            {
                PersonnelGridDataBind();
            }
        }

        public void PersonnelGridDataBind()
        {
            PersonnelGridHelper personnelGridHelper = new PersonnelGridHelper();
            personnelGridHelper.InitializePersonnelGrid((new BO_ProviderPrimaryKey(CurrentAppProvider.PopsIntID)), (new BO_ApplicationPrimaryKey(CurrentAppProvider.ApplicationID)));
            grdPersonnel.DataSource = personnelGridHelper.GridDataSource;
            grdPersonnel.DataBind();
        }

        private void _InitPersonnelGridColumns(GridBoundColumn[] inColumnList)
        {
            foreach (GridBoundColumn tmpCol in inColumnList)
            {
                GridBoundColumn gbc = new GridBoundColumn();
                grdPersonnel.Columns.Add(gbc);
                gbc.UniqueName = tmpCol.UniqueName;
                gbc.DataField = tmpCol.DataField;
                gbc.HeaderText = tmpCol.HeaderText;
                gbc.Visible = tmpCol.Visible;
                gbc.AllowFiltering = tmpCol.AllowFiltering;
                gbc.HeaderStyle.Width = tmpCol.HeaderStyle.Width;
            }
        }

        private bool HidePersonnelGridNavControls
        {
            get
            {
                if (ViewState["HidePersonnelGridNavControls"] == null)
                    return false;
                else
                    return (bool)ViewState["HidePersonnelGridNavControls"];
            }

            set
            {
                ViewState["HidePersonnelGridNavControls"] = value;
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