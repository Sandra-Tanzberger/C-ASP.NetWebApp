    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ATG.BusinessObject;
using Telerik.Web.UI;
using ATG.Utilities.Presentation.Tables;
using System.Data;
using ATG.Utilities.Data;

namespace AppControl
{
    public partial class FacilityBeds : System.Web.UI.UserControl
    {
        #region Event Handlers

        protected void Page_Load(object sender, EventArgs e)
        {
            // do nothing
        }

        /// <summary>
        /// Handles the grid's NeedDataSourceEvent event handler
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void grdBedsGenericATGGrid_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            if (null != grdbedsDataSource)
            {
                grdBedsGenericATGGrid.DataSource = (DataTable)grdbedsDataSource;
            }
            else
            {
                string providerPOPSINTID = (string)Session["ProviderPOPSINTID"];
                InitHistoryGrid(providerPOPSINTID);
            }
        }

        /// <summary>
        /// Handles the grid's SelectedIndexChanged event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdBedsGenericATGGrid_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSelectedItem();
        }

        #endregion

        #region Private

        private void LoadSelectedItem()
        {
            // get the currently selected Provider
            GridDataItem dataItem = (GridDataItem)grdBedsGenericATGGrid.SelectedItems[0];

            // get the application id
            string appId = dataItem["ApplicationId"].Text;
            // convert to decimal
            decimal? appId_decimal = null;
            try
            {
                appId_decimal = Decimal.Parse(appId);
            }
            catch (Exception ex)
            {
                appId_decimal = null;
            }
            // get the Application object
            BO_ApplicationPrimaryKey boApplicationPrimaryKey = new BO_ApplicationPrimaryKey(appId_decimal);
            //BO_Application boApplication = BO_Application.SelectOne(boApplicationPrimaryKey);
            BO_Application boApplication = new BO_Application();
            boApplication.LoadFullApplication( appId_decimal.Value );
            
            Session["CurrentAppProvider"] = boApplication;
            // Reuse Public POPS control to display the beds details
            BedDetails1.LoadBeds( appId, true, false );
            // Disable the Beds grid
            BedDetails1.DisableBedsGrid();
        }

        private void InitHistoryGrid(string providerPOPSINTID)
        {
            if(!string.IsNullOrEmpty(providerPOPSINTID))
            {
                BO_ProviderPrimaryKey boProviderPrimaryKey = new BO_ProviderPrimaryKey(Convert.ToDecimal(providerPOPSINTID));
                if (boProviderPrimaryKey != null)
                {
                    BO_Capacities tmpCapacities = BO_Capacity.SelectAllByForeignKeyPopsIntIDGroupedApplicationId(boProviderPrimaryKey);
                    if (null != tmpCapacities)
                    {
                        // Create a dataTable with the appropriate data struture
                        DataTable tmpTable = getFacilityBedsDataTable();

                        foreach (BO_Capacity boCapacity in tmpCapacities)
                        {
                            DataRow tmpDR = tmpTable.NewRow();
                            tmpDR["DateStarted"] = boCapacity.DateStarted.HasValue ? boCapacity.DateStarted.Value.ToShortDateString() : "";
                            tmpDR["TotalBeds"] = boCapacity.TotalBeds;
                            tmpDR["ApplicationId"] = boCapacity.ApplicationID;

                            tmpTable.Rows.Add(tmpDR);
                        }
                        // save to the Session Object
                        grdbedsDataSource = tmpTable;
                        // set the dataSource object for thge grid
                        grdBedsGenericATGGrid.DataSource = (DataTable)grdbedsDataSource;
                    }
                }
            }
        }

        private DataTable getFacilityBedsDataTable()
        {
            DataTable tmpDTbl = new DataTable();
            DataColumn tmpDCol = null;

            tmpDCol = new DataColumn("DateStarted");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("TotalBeds");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("ApplicationId");
            tmpDTbl.Columns.Add(tmpDCol);

            return tmpDTbl;
        }

        private DataTable grdbedsDataSource
        {
            get { return (DataTable)Session["grdbedsDataSource"]; }
            set { Session["grdbedsDataSource"] = value; }
        }

        #endregion

        #region Public

        /// <summary>
        /// Reload the fields with the current provider
        /// </summary>
        /// <param name="popsIntId"></param>
        public void LoadNewProvider(string popsIntId)
        {
            // delete pre-existing rows from datasource table
            DataTable dtTable1 = grdbedsDataSource;
            if (dtTable1 != null)
            {
                dtTable1.Rows.Clear();
                dtTable1.AcceptChanges();
                grdbedsDataSource = dtTable1;
                // set the dataSource object for the grid
                grdBedsGenericATGGrid.DataSource = (DataTable)grdbedsDataSource;
                grdBedsGenericATGGrid.DataBind();
            }

            if(!string.IsNullOrEmpty(popsIntId))
            {
                // reload the data for the History grid
                InitHistoryGrid(popsIntId);
                // bind the grid
                grdBedsGenericATGGrid.DataBind();
                // pre-select the first row in the grid
                if (grdBedsGenericATGGrid.Items.Count > 0)
                {
                    // select the first row
                    grdBedsGenericATGGrid.Items[0].Selected = true;
                    // reload data in the controls
                    LoadSelectedItem();
                }
                else
                {
                    // delete pre-existing rows from the BedDetails control
                    BedDetails1.ClearGrid();
                }
            }
            else
            {
                // Reset the Application object stored in the Session
                Session["CurrentAppProvider"] = null;
                // delete pre-existing rows from the BedDetails control
                BedDetails1.ClearGrid();
            }
        }

        #endregion


    }
}