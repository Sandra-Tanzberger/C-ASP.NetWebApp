using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ATG.BusinessObject;
using ATG.Utilities.Data;
using Telerik.Web.UI;

namespace AppControl
{
    public partial class FacilityGrid : System.Web.UI.UserControl, IPostBackEventHandler
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                // set the default values for the Grid's properties
                SetDefaultProperties();
            }
        }

        /// <summary>
        /// Set the datasource for the Provider's grid
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void grdProviders_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            if (null != grdDataSource)
            {
                grdProviders.DataSource = (DataTable)grdDataSource;
            }
            else
                _InitializeGrid("Program", "");
        }

        /// <summary>
        /// Get the PopsIntID of the newly provider
        /// and display the details for the selected facility
        /// in a popup window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdProviders_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName.Equals("View"))
            {
                // get the currently selected Provider
                if (grdProviders.SelectedItems.Count > 0)
                {
                    GridDataItem dataItem = (GridDataItem)grdProviders.SelectedItems[0];

                    // Use the GridDataItem to open Facility details
                    OpenItemInWindow(dataItem);
                }
            }
        }

        /// <summary>
        /// The Grid's client side doubleclick event calls a JS that causes postback
        /// </summary>
        /// <param name="eventArgument"></param>
        public void RaisePostBackEvent(string eventArgument)
        {
            if (eventArgument.IndexOf("RowDoubleClicked") != -1)
            {
                GridDataItem dataItem = grdProviders.Items[int.Parse(eventArgument.Split(':')[1])];

                // Use the GridDataItem to open Facility details
                OpenItemInWindow(dataItem);
            }
        }

        /// <summary>
        /// setup the controls and populate the Provider's grid
        /// </summary>
        /// <param name="SelectKey"></param>
        /// <param name="isProgram"></param>
        public void SetUpProvidersArea(string SelectKey, bool isProgram)
        {
            if (isProgram)
            {
                _InitializeGrid("Program", SelectKey);
            }
            else
            {
                _InitializeGrid("Process", SelectKey);
            }
            grdProviders.DataBind();
        }

        /// <summary>
        /// Can be called from either "View" click or row double click
        /// </summary>
        /// <param name="dataItem"></param>
        private void OpenItemInWindow(GridDataItem dataItem)
        {
            string popsIntId = dataItem["PopsIntID"].Text;
            string facilityName = dataItem["FacilityName"].Text;
            string aspenIntID = dataItem["AspenIntID"].Text;
            string programID = dataItem["ProgramID"].Text;

            // set session variables
            Session["ProviderPOPSINTID"] = popsIntId;
            Session["FacilityName"] = facilityName;
            Session["AspenIntID"] = aspenIntID;
            Session["ProgramID"] = programID;

            RadWindow newwindow = new RadWindow();
            newwindow.ID = "RadWindow1";
            newwindow.NavigateUrl = "~/DHH/StateFacilityPage.aspx";
            newwindow.VisibleStatusbar = false;
            newwindow.VisibleOnPageLoad = true;
            newwindow.Height = Unit.Pixel(525);
            newwindow.Width = Unit.Pixel(730);
            newwindow.Title = "Provider Details : " + facilityName;
            newwindow.InitialBehaviors = WindowBehaviors.Maximize;
            RadWindowManager1.Windows.Add(newwindow);
            RadWindowManager1.Style.Add("z-index", "9999");

        }

        /// <summary>
        /// Set the default values for the grid's most used properties
        /// </summary>
        private void SetDefaultProperties()
        {
            grdProviders.AutoGenerateColumns = false;
            grdProviders.AllowPaging = false;
            grdProviders.AllowFilteringByColumn = false;
            grdProviders.AllowSorting = false;
            grdProviders.GridLines = GridLines.None;
        }

        /// <summary>
        /// Define the columns for the Providers's grid
        /// </summary>
        private void BuildProvGridColumns()
        {
            GridBoundColumn col1 = new GridBoundColumn();
            grdProviders.MasterTableView.Columns.Add(col1);
            col1.UniqueName = "StateID";
            col1.DataField = "StateID";
            col1.HeaderText = "State Id";
            col1.Visible = true;
            col1.HeaderStyle.Width = Unit.Percentage(10);

            GridBoundColumn col2 = new GridBoundColumn();
            grdProviders.MasterTableView.Columns.Add(col2);
            col2.UniqueName = "FacilityName";
            col2.DataField = "FacilityName";
            col2.HeaderText = "Facility Name";
            col2.Visible = true;
            col2.HeaderStyle.Width = Unit.Percentage(30);

            GridBoundColumn col3 = new GridBoundColumn();
            grdProviders.MasterTableView.Columns.Add(col3);
            col3.UniqueName = "GeographicalCity";
            col3.DataField = "GeographicalCity";
            col3.HeaderText = "Geographical City";
            col3.Visible = true;
            col3.HeaderStyle.Width = Unit.Percentage(20);

            GridBoundColumn col4 = new GridBoundColumn();
            grdProviders.MasterTableView.Columns.Add(col4);
            col4.UniqueName = "Parish";
            col4.DataField = "Parish";
            col4.HeaderText = "Parish";
            col4.Visible = true;
            col4.HeaderStyle.Width = Unit.Percentage(20);

            GridBoundColumn col5 = new GridBoundColumn();
            grdProviders.MasterTableView.Columns.Add(col5);
            col5.UniqueName = "FieldOffice";
            col5.DataField = "FieldOffice";
            col5.HeaderText = "Field Office";
            col5.Visible = true;
            col5.HeaderStyle.Width = Unit.Percentage(10);

            GridBoundColumn col6 = new GridBoundColumn();
            grdProviders.MasterTableView.Columns.Add(col6);
            col6.UniqueName = "ChapAccreditionYN";
            col6.DataField = "ChapAccreditionYN";
            col6.HeaderText = "Accredited";
            col6.Visible = true;
            col6.HeaderStyle.Width = Unit.Percentage(10);

            GridBoundColumn col7 = new GridBoundColumn();
            grdProviders.MasterTableView.Columns.Add(col7);
            col7.UniqueName = "PopsIntID";
            col7.DataField = "PopsIntID";
            col7.HeaderText = "";
            col7.Visible = false;
            col7.HeaderStyle.Width = Unit.Percentage(0);

            GridBoundColumn col8 = new GridBoundColumn();
            grdProviders.MasterTableView.Columns.Add(col8);
            col8.UniqueName = "AspenIntID";
            col8.DataField = "AspenIntID";
            col8.HeaderText = "";
            col8.Visible = false;
            col8.HeaderStyle.Width = Unit.Percentage(0);

            GridBoundColumn col9 = new GridBoundColumn();
            grdProviders.MasterTableView.Columns.Add(col9);
            col9.UniqueName = "ProgramID";
            col9.DataField = "ProgramID";
            col9.HeaderText = "";
            col9.Visible = false;
            col9.HeaderStyle.Width = Unit.Percentage(0);
        }

        /// <summary>
        /// Define the columns for the Providers-Process grid
        /// </summary>
        private void BuildProvProcessGridColumns()
        {
            GridBoundColumn col1 = new GridBoundColumn();
            grdProviders.MasterTableView.Columns.Add(col1);
            col1.UniqueName = "StateID";
            col1.DataField = "StateID";
            col1.HeaderText = "State Id";
            col1.Visible = true;
            col1.HeaderStyle.Width = Unit.Percentage(10);

            GridBoundColumn col2 = new GridBoundColumn();
            grdProviders.MasterTableView.Columns.Add(col2);
            col2.UniqueName = "BusinessProcessName";
            col2.DataField = "BusinessProcessName";
            col2.HeaderText = "Application Process";
            col2.Visible = true;
            col2.HeaderStyle.Width = Unit.Percentage(20);

            GridBoundColumn col3 = new GridBoundColumn();
            grdProviders.MasterTableView.Columns.Add(col3);
            col3.UniqueName = "FacilityName";
            col3.DataField = "FacilityName";
            col3.HeaderText = "Facility Name";
            col3.Visible = true;
            col3.HeaderStyle.Width = Unit.Percentage(30);

            GridBoundColumn col4 = new GridBoundColumn();
            grdProviders.MasterTableView.Columns.Add(col4);
            col4.UniqueName = "SubmissionDate";
            col4.DataField = "SubmissionDate";
            col4.HeaderText = "Submission Date";
            col4.Visible = true;
            col4.HeaderStyle.Width = Unit.Percentage(20);

            GridBoundColumn col5 = new GridBoundColumn();
            grdProviders.MasterTableView.Columns.Add(col5);
            col5.UniqueName = "ApplicationStatusDesc";
            col5.DataField = "ApplicationStatusDesc";
            col5.HeaderText = "Status";
            col5.Visible = true;
            col5.HeaderStyle.Width = Unit.Percentage(20);

            GridBoundColumn col7 = new GridBoundColumn();
            grdProviders.MasterTableView.Columns.Add(col7);
            col7.UniqueName = "PopsIntID";
            col7.DataField = "PopsIntID";
            col7.HeaderText = "";
            col7.Visible = false;
            col7.HeaderStyle.Width = Unit.Percentage(0);

            GridBoundColumn col8 = new GridBoundColumn();
            grdProviders.MasterTableView.Columns.Add(col8);
            col8.UniqueName = "AspenIntID";
            col8.DataField = "AspenIntID";
            col8.HeaderText = "";
            col8.Visible = false;
            col8.HeaderStyle.Width = Unit.Percentage(0);

            GridBoundColumn col9 = new GridBoundColumn();
            grdProviders.MasterTableView.Columns.Add(col9);
            col9.UniqueName = "ProgramID";
            col9.DataField = "ProgramID";
            col9.HeaderText = "";
            col9.Visible = false;
            col9.HeaderStyle.Width = Unit.Percentage(0);
        }

        /// <summary>
        /// Initialize thr providers Grid for use with Programs / Processes
        /// </summary>
        /// <param name="inGridType"></param>
        /// <param name="inTypeKey"></param>
        private void _InitializeGrid(String inGridType, String inTypeKey)
        {
            switch (inGridType)
            {
                case "Program":
                    BO_Providers boProviders = null;
                    if (!string.IsNullOrEmpty(inTypeKey) && inTypeKey.Equals("~"))
                    {
                        // get ALL records
                        boProviders = BO_Provider.SelectAllForGrid();
                    }
                    else
                    {
                        // get rows for the specified Program Id
                        BO_ProgramPrimaryKey boProgPK = new BO_ProgramPrimaryKey(inTypeKey);
                        boProviders = BO_Provider.SelectAllByForeignKeyProgramIDForGrid(boProgPK);
                    }

                    if (boProviders != null)
                    {
                        BO_Provider[] tmpArr = new BO_Provider[boProviders.Count];
                        int cntr = 0;

                        foreach (BO_Provider bop in boProviders)
                        {
                            tmpArr[cntr] = bop;
                            cntr++;
                        }

                        grdDataSource = GridHelper.BO_Array_ConvertToDataTable(tmpArr);
                    }
                    else
                    {
                        grdDataSource = new DataTable();
                    }
                    grdProviders.MasterTableView.Columns.Clear();
                    BuildProvGridColumns();
                    grdProviders.Rebind();

                    break;
                case "Process":
                    BO_Applications boApplications = null;
                    if (!string.IsNullOrEmpty(inTypeKey) && inTypeKey.Equals("~"))
                    {
                        // get ALL records
                        boApplications = BO_Application.SelectAllProvidersInProcessForGrid();
                    }
                    else
                    {
                        // get rows for the specified Business Process Id
                        BO_BusinessProcessePrimaryKey boBusinessProcPK = new BO_BusinessProcessePrimaryKey(inTypeKey);
                        boApplications = BO_Application.SelectProvidersByProcessForGrid(boBusinessProcPK);
                    }
                    if (boApplications != null)
                    {
                        BO_Application[] tmpArr = new BO_Application[boApplications.Count];
                        int cntr = 0;

                        foreach (BO_Application boApp in boApplications)
                        {
                            tmpArr[cntr] = boApp;
                            cntr++;
                        }
                        grdDataSource = GridHelper.BO_Array_ConvertToDataTable(tmpArr);
                    }
                    else
                    {
                        grdDataSource = new DataTable();
                    }
                    grdProviders.MasterTableView.Columns.Clear();
                    BuildProvProcessGridColumns();
                    grdProviders.Rebind();

                    break;
                default:
                    grdDataSource = new DataTable();

                    break;
            }

            // set the provider grid's properties
            grdProviders.DataSource = grdDataSource;
            grdProviders.AllowFilteringByColumn = true;
            grdProviders.AllowSorting = true;
            grdProviders.Height = Unit.Percentage(99);
            grdProviders.Width = Unit.Percentage(99);
        }

        private DataTable grdDataSource
        {
            get
            {
                return (DataTable)ViewState["grdDataSource"];
            }
            set
            {
                ViewState["grdDataSource"] = value;
            }
        }
    }
}