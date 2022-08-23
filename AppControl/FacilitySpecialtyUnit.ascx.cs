using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ATG.BusinessObject;
using System.Data;
using ATG.Utilities.Data;
using Telerik.Web.UI;

namespace AppControl
{
    public partial class FacilitySpecialtyUnit : System.Web.UI.UserControl
    {
        #region Event Handlers

        protected void Page_Load(object sender, EventArgs e)
        {
            // do nothing
        }

        protected void grdSUApplications_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            if ( null != grdSUApplicationsDataSource )
            {
                grdSUApplications.DataSource = (DataTable) grdSUApplicationsDataSource;
            }
            else
            {
                string providerPOPSINTID = (string)Session["ProviderPOPSINTID"];
                InitHistoryGrid(providerPOPSINTID);
            }
        }

        protected void grdSUApplications_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSelectedItem();
        }

        #endregion

        #region Private

        private void LoadSelectedItem()
        {
            // get the currently selected Provider
            GridDataItem dataItem = (GridDataItem) grdSUApplications.SelectedItems[0];
            // get the application id
            string appId = dataItem["ApplicationId"].Text;
            // Reuse Public POPS control to display the Speciality Units details
            SpecialtyUnit1.LoadApplication(appId, false, false);
            // Disable the controls 
            SpecialtyUnit1.DisableSpecialityUnits();
        }

        /// <summary>
        /// get the data for the grid
        /// </summary>
        private void InitHistoryGrid(string providerPOPSINTID)
        {
            if(!string.IsNullOrEmpty(providerPOPSINTID))
            {
                BO_ProviderPrimaryKey boProviderPrimaryKey = new BO_ProviderPrimaryKey(Convert.ToDecimal(providerPOPSINTID));
                if (boProviderPrimaryKey != null)
                {
                    BO_Applications tmpApplications = BO_Application.SelectForGridByForeignKeyPopsIntID(boProviderPrimaryKey);
                    if (null != tmpApplications)
                    {

                        // Create a dataTable with the appropriate data struture
                        DataTable tmpTable = getFacilityApplicationsDataTable();

                        foreach (BO_Application boApplication in tmpApplications)
                        {
                            DataRow tmpDR = tmpTable.NewRow();
                            tmpDR["APPLICATIONID"] = boApplication.ApplicationID;
                            tmpDR["FEDERALID"] = boApplication.FederalID;
                            tmpDR["BUSINESSPROCESSNAME"] = boApplication.BusinessProcessName;
                            tmpDR["VALDESC"] = boApplication.StatusValdesc;
                            tmpDR["GRIDDATESTARTED"] = boApplication.GridDateStarted;
                            tmpDR["DATECOMPLETED"] = boApplication.DateCompleted.HasValue ? boApplication.DateCompleted.Value.ToShortDateString() : "";
                            tmpDR["LICENSUREEXPIRATIONDATE"] = boApplication.LicensureExpirationDate.HasValue ? boApplication.LicensureExpirationDate.Value.ToShortDateString() : "";

                            tmpTable.Rows.Add(tmpDR);
                        }
                        // save to the Session Object
                        grdSUApplicationsDataSource = tmpTable;
                        // set the dataSource object for thge grid
                        grdSUApplications.DataSource = (DataTable) grdSUApplicationsDataSource;
                    }
                }
            }
        }

        private DataTable getFacilityApplicationsDataTable()
        {
            DataTable tmpDTbl = new DataTable();
            DataColumn tmpDCol = null;

            tmpDCol = new DataColumn("APPLICATIONID");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("FEDERALID");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("BUSINESSPROCESSNAME");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("VALDESC");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("GRIDDATESTARTED");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("DATECOMPLETED");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("LICENSUREEXPIRATIONDATE");
            tmpDTbl.Columns.Add(tmpDCol);

            return tmpDTbl;
        }

        private DataTable grdSUApplicationsDataSource
        {
            get { return (DataTable) Session["grdSUApplicationsDataSource"]; }
            set { Session["grdSUApplicationsDataSource"] = value; }
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
            DataTable dtTable1 = grdSUApplicationsDataSource;
            if (dtTable1 != null)
            {
                dtTable1.Rows.Clear();
                dtTable1.AcceptChanges();
                grdSUApplicationsDataSource = dtTable1;
                // set the dataSource object for the grid
                grdSUApplications.DataSource = (DataTable) grdSUApplicationsDataSource;
                grdSUApplications.DataBind();
            }

            if (!string.IsNullOrEmpty(popsIntId))
            {
                // reload the data for the History grid
                InitHistoryGrid(popsIntId);
                // bind the grid
                grdSUApplications.DataBind();
                // pre-select the first row in the grid
                if ( grdSUApplications.Items.Count > 0 )
                {
                    // select the first row
                    grdSUApplications.Items[0].Selected = true;
                    // reload data in the controls
                    LoadSelectedItem();
                }
                else
                {
                    // clear pre-existing selections from the SpecialtyUnit1 control
                    SpecialtyUnit1.ClearSpecialityUnits();
                }
            }
            else
            {
                // clear pre-existing selections from the SpecialtyUnit1 control
                SpecialtyUnit1.ClearSpecialityUnits();
            }
        }

        #endregion


    }
}