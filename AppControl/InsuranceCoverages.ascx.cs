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
    public partial class InsuranceCoverage : System.Web.UI.UserControl
    {
        bool hideControls = false;

        public void LoadInsuranceCoverage()
        {
            HideInsuranceCoverageGridNavControls = true;
        }

        protected void grdInsuranceCoverage_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (HideInsuranceCoverageGridNavControls && e.Item is GridCommandItem)
            {
                LinkButton addButton = (LinkButton)e.Item.FindControl("btnAddInsuranceCoverage");
                addButton.Visible = false;
                LinkButton editButton = (LinkButton)e.Item.FindControl("btnEditInsuranceCoverage");
                editButton.Visible = false;
                LinkButton deleteButton = (LinkButton)e.Item.FindControl("btnDeleteInsuranceCoverage");
                deleteButton.Visible = false;
                LinkButton refreshButton = (LinkButton)e.Item.FindControl("btnRefreshInsuranceCoverage");
                refreshButton.Visible = false;
            }
        } 

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _InitInsuranceCoverageGridColumns(InsuranceCoverageGridHelper.GridColumnList());
            }
        }
         
        protected void InsuranceCoverageGrid_NeedsDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            InsuranceCoverageGridHelper insuranceCoverageGridHelper = new InsuranceCoverageGridHelper();
            insuranceCoverageGridHelper.InitializeInsuranceCoveragesGrid(CurrentProvider.PopsIntID);
            grdInsuranceCoverage.DataSource = insuranceCoverageGridHelper.GridDataSource;
        }

        protected void grdInsuranceCoverage_ItemCommand(object sender, GridCommandEventArgs e)
        {
            string popsIntId = "";
            string carrierCode = "";
            string coverageType = "";
            string effectiveDate = "";

            if (e.CommandName.Equals("Add"))
            {
                RadWin1.NavigateUrl = "~/Common/EditForm/InsuranceCoverageForm.aspx?popsIntId=";
                RadWin1.VisibleStatusbar = false;
                RadWin1.VisibleOnPageLoad = true;
                RadWin1.Height = Unit.Pixel(600);
                RadWin1.Width = Unit.Pixel(800);
                RadWin1.Behaviors = WindowBehaviors.None;
                //RadWin1.Behaviors = WindowBehaviors.Close;
                RadWin1.Modal = true;
                RadWin1.VisibleOnPageLoad = true;
                RadWin1.Height = Unit.Pixel(525);
                RadWin1.Width = Unit.Pixel(730);
                RadWin1.Title = "Add Insurance Coverage";
                RadWindowManager1.Style.Add("z-index", "9999");
                //RadWindowManager1.Behaviors = WindowBehaviors.Close;
            }

            if (grdInsuranceCoverage.SelectedItems.Count > 0)
            {
                Telerik.Web.UI.GridDataItem item = (Telerik.Web.UI.GridDataItem)(grdInsuranceCoverage.SelectedItems[0]);
                popsIntId = item["PopsIntId"].Text;
                carrierCode = item["CarrierCode"].Text;
                coverageType = item["CoverageType"].Text;
                effectiveDate = item["EffectiveDate"].Text;

                if (e.CommandName.Equals("Edit"))
                {
                    RadWin1.NavigateUrl = "~/Common/EditForm/InsuranceCoverageForm.aspx" +
                            "?popsIntId=" + popsIntId +
                            "&carrierCode=" + carrierCode +
                            "&coverageType=" + coverageType +
                            "&effectiveDate=" + effectiveDate;
                    RadWin1.VisibleStatusbar = false;
                    RadWin1.VisibleOnPageLoad = true;
                    RadWin1.Height = Unit.Pixel(600);
                    RadWin1.Width = Unit.Pixel(800);
                    RadWin1.Behaviors = WindowBehaviors.None;
                    //RadWin1.Behaviors = WindowBehaviors.Close;
                    RadWin1.Modal = true;
                    RadWin1.VisibleOnPageLoad = true;
                    RadWin1.Height = Unit.Pixel(525);
                    RadWin1.Width = Unit.Pixel(730);
                    RadWin1.Title = "Edit Insurance Coverage";
                    RadWindowManager1.Style.Add("z-index", "9999");
                    //RadWindowManager1.Behaviors = WindowBehaviors.Close;
                }

                if (e.CommandName.Equals("Delete"))
                {
                    BO_InsuranceCoverage insurance = new BO_InsuranceCoverage();
                    insurance.PopsIntID = Convert.ToDecimal(popsIntId);
                    insurance.CarrierCode = carrierCode;
                    insurance.CoverageType = coverageType;
                    insurance.EffectiveDate = Convert.ToDateTime(effectiveDate);
                    insurance.Delete();
                    InsuranceCoverageGridDataBind();
                }
            }

            if (e.CommandName.Equals("Rebind"))
            {
                InsuranceCoverageGridDataBind();
            }
        }

        public void InsuranceCoverageGridDataBind()
        {
            InsuranceCoverageGridHelper InsuranceCoverageGridHelper = new InsuranceCoverageGridHelper();
            InsuranceCoverageGridHelper.InitializeInsuranceCoveragesGrid(CurrentProvider.PopsIntID);
            grdInsuranceCoverage.DataSource = InsuranceCoverageGridHelper.GridDataSource;
            grdInsuranceCoverage.DataBind();
        }

        private void _InitInsuranceCoverageGridColumns(GridBoundColumn[] inColumnList)
        {
            foreach (GridBoundColumn tmpCol in inColumnList)
            {
                GridBoundColumn gbc = new GridBoundColumn();
                grdInsuranceCoverage.Columns.Add(gbc);
                gbc.UniqueName = tmpCol.UniqueName;
                gbc.DataField = tmpCol.DataField;
                gbc.HeaderText = tmpCol.HeaderText;
                if (tmpCol.DataField == "PREPAYMENT_DUE_DATE") {
                    gbc.Visible = (CurrentProvider.ProgramID == "NE");
                }
                else {
                    gbc.Visible = tmpCol.Visible;
                }
                gbc.AllowFiltering = tmpCol.AllowFiltering;
                gbc.HeaderStyle.Width = tmpCol.HeaderStyle.Width;
            }
        }

        private bool HideInsuranceCoverageGridNavControls
        {
            get
            {
                if (ViewState["HideInsuranceCoverageGridNavControls"] == null)
                    return false;
                else
                    return (bool)ViewState["HideInsuranceCoverageGridNavControls"];
            }

            set
            {
                ViewState["HideInsuranceCoverageGridNavControls"] = value;
            }
        }

        private BO_Provider CurrentProvider {
            get {
                return Session["CurrentProvider"] == null ? null : (BO_Provider)Session["CurrentProvider"];
            }
            set {
                Session["CurrentProvider"] = value;
            }
        }
    }
}