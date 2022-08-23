using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Telerik.Web.UI;
using ATG.BusinessObject;
using ATG.Utilities.Data;
using Microsoft.Reporting.WebForms;

namespace AppControl
{
    public partial class FacilityApplications : System.Web.UI.UserControl
    {
        private BO_Applications _m_ProvApps = null;
        decimal _popsIntId ;

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            RadAjaxManager manager = RadAjaxManager.GetCurrent( Page );
            manager.AjaxRequest += new RadAjaxControl.AjaxRequestDelegate( manager_AjaxRequest );

        }

        protected void manager_AjaxRequest( object sender, Telerik.Web.UI.AjaxRequestEventArgs e )
        {
            if ( null != e.Argument && e.Argument.Length > 0 )
            {
                grdApplicationsDataSource = null;
                grdApplications.Rebind();
            }
        }

        protected void grdApplications_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            if (null != grdApplicationsDataSource)
            {
                grdApplications.DataSource = (DataTable)grdApplicationsDataSource;
            }
            else
            {
                string providerPOPSINTID = (string)Session["ProviderPOPSINTID"];
                InitHistoryGrid(providerPOPSINTID);
                grdApplications.DataSource = (DataTable) grdApplicationsDataSource;
            }
        }

        /// <summary>
        /// Event handler for the button click event of the OPEN / PRINT buttons on each row
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void grdApplications_ItemCommand(object source, GridCommandEventArgs e)
        {
            RadWindowManager1.Windows.Clear();
            if (e.CommandName == RadGrid.InitInsertCommandName)
            {
                foreach (BO_Application boApp in CurrentAppsList)
                {
                    if (!boApp.ApplicationStatus.Equals("4") && !boApp.ApplicationStatus.Equals("6"))
                    {
                        grdApplications.MasterTableView.ClearEditItems();
                        e.Canceled = true;
                        break;
                    }
                }
            }
            if (e.Item is GridDataItem)
            {
                // select the row, if currently unselected
                if (e.Item.Selected != true)
                    e.Item.Selected = true;

                if (e.CommandName == "Open")
                {
                    GridDataItem dataItem = e.Item as GridDataItem;
                    // get the application id
                    string appId = dataItem["APPLICATIONID"].Text;
                    string appType = dataItem["BUSINESSPROCESSNAME"].Text;

                    // get the Facility Name for display on the popup window's Title bar
                    string facilityName = (string)Session["FacilityName"];
                    facilityName = facilityName != null ? facilityName : "";
                    string popupTitle = appType + " for " + facilityName + " (" + Session["StateID"].ToString() + ")" + " Application ID: " + appId;

                    // The license control needs the following Session variable
                    Session["LicenseApplicationId"] = appId;

                    // Load the License control
                    RadWindow newwindow = new RadWindow();
                    newwindow.ID = "RadWindow1";
                    newwindow.NavigateUrl = "~/DHH/StateLicensePage.aspx";
                    newwindow.VisibleStatusbar = false;
                    newwindow.VisibleOnPageLoad = true;
                    newwindow.Height = Unit.Pixel(525);
                    newwindow.Width = Unit.Pixel(730);
                    newwindow.Title = popupTitle;
                    newwindow.InitialBehaviors = WindowBehaviors.Maximize;
                    RadWindowManager1.Windows.Add(newwindow);
                    RadWindowManager1.Style.Add("z-index", "9999");
                    RadWindowManager1.Behaviors = WindowBehaviors.None;
                }
                else if (e.CommandName == "Print")
                {

                    // open a window to display the Letters Print Queue
                    GridDataItem dataItem = e.Item as GridDataItem;

                    // get the application id
                    string appId = dataItem["APPLICATIONID"].Text;
                    string businessProcess = dataItem["BUSINESSPROCESSNAME"].Text;

                    //NewLic(appId, businessProcess);

                    // get the Facility Name for display on the popup window's Title bar
                    string facilityName = (string)Session["FacilityName"];
                    facilityName = facilityName != null ? facilityName : "";
                    string popupTitle = "Printable Letters for " + facilityName;

                    // Load the License control
                    RadWindow newwindow = new RadWindow();
                    newwindow.ID = "RadWindowPrint";
                    newwindow.NavigateUrl = "~/DHH/ApplicationPrintQueue.aspx?PrintKey=" + appId;
                    newwindow.VisibleStatusbar = false;
                    newwindow.VisibleOnPageLoad = true;
                    newwindow.Height = Unit.Pixel(525);
                    newwindow.Width = Unit.Pixel(730);
                    newwindow.Title = popupTitle;
                    newwindow.InitialBehaviors = WindowBehaviors.Maximize;
                    RadWindowManager1.Windows.Add(newwindow);
                    RadWindowManager1.Style.Add("z-index", "9999");
                    RadWindowManager1.Behaviors = WindowBehaviors.Close;
                }

                else if (e.CommandName == "Billing")
                {
                    // open a window to display the License Report
                    GridDataItem dataItem = e.Item as GridDataItem;

                    // get the application id
                    string appId = dataItem["APPLICATIONID"].Text;

                    // get the Facility Name for display on the popup window's Title bar
                    string facilityName = (string)Session["FacilityName"];
                    facilityName = facilityName != null ? facilityName : "";
                    string popupTitle = "Billing Details for " + facilityName;

                    // Load the License control
                    RadWindow newwindow = new RadWindow();
                    newwindow.ID = "RadWindow4";
                    newwindow.NavigateUrl = "~/DHH/BillingHistoryPage.aspx?BillingKeyType=APPLICATION_ID&BillingKey=" + appId;
                    newwindow.VisibleStatusbar = false;
                    newwindow.VisibleOnPageLoad = true;
                    newwindow.Height = Unit.Pixel(525);
                    newwindow.Width = Unit.Pixel(730);
                    newwindow.Title = popupTitle;
                    newwindow.InitialBehaviors = WindowBehaviors.Maximize;
                    RadWindowManager1.Windows.Add(newwindow);
                    RadWindowManager1.Style.Add("z-index", "9999");
                    RadWindowManager1.Behaviors = WindowBehaviors.Close;
                }
            }
            else if (!(e.Item is GridDataItem))
            {
                if (e.CommandName == "Rebind")
                {
                    grdApplicationsDataSource = null;
                    grdApplications.Rebind();
                }
            }
        }

        /// <summary>
        /// Disable the "License" Linkbutton for applications that are NOT approved
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdApplications_ItemDataBound(object sender, GridItemEventArgs e)
        {

            if (e.Item is GridCommandItem)
            {
                if (User.IsReadOnly())
                {
                    LinkButton addButton = (LinkButton)e.Item.FindControl("btnAddNew");
                    addButton.Visible = false;
                    LinkButton deleteButton = (LinkButton)e.Item.FindControl("btnDelete");
                    deleteButton.Visible = false;
                    LinkButton refreshButton = (LinkButton)e.Item.FindControl("btnRefresh");
                    refreshButton.Visible = false;
                }
            }

            if (e.Item is GridDataItem)
            {
                GridDataItem item = (GridDataItem)e.Item;
                //SMM 09/06/2011 - Changed to use code not text description
                string strAppStat = item["APPLICATIONSTATUS"].Text.ToString();
                if ( !string.IsNullOrEmpty( strAppStat ) && !strAppStat.ToUpper().Equals( "4" ) )
                {
                    LinkButton linkButtonLicense = (LinkButton)item["Actions"].FindControl("LinkButtonLicense");
                    if(linkButtonLicense != null)
                        linkButtonLicense.Enabled = false;

                }

                string strAppAct = item["APPLICATIONACTION"].Text.ToString();
                LinkButton linkButtonEdit = (LinkButton) item["Actions"].FindControl( "LinkButtonOpen" );
                LinkButton linkButtonView = (LinkButton) item["Actions"].FindControl( "LinkButtonView" );

                if (User.IsReadOnly())
                {
                    if (linkButtonEdit != null)
                        linkButtonEdit.Visible = false;

                    if (linkButtonView != null)
                        linkButtonView.Visible = true;


                }
                else if ( !string.IsNullOrEmpty( strAppAct ) )
                {
                    //Enable edit for 'DHH-Working' and 'DHH-Pending' apps only
                    if ( ( "2,3" ).Contains( strAppAct.ToUpper() ) )
                    {
                        if ( linkButtonEdit != null )
                            linkButtonEdit.Visible = true;

                        if ( linkButtonView != null )
                            linkButtonView.Visible = false;
                    }
                    else
                    {
                        if ( linkButtonEdit != null )
                            linkButtonEdit.Visible = false;

                        if ( linkButtonView != null )
                            linkButtonView.Visible = true;
                    }
                }
            }
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
                    BO_Provider prov = BO_Provider.SelectOne(boProviderPrimaryKey);
                    if (null != prov) {
                        lblProviderStatus.InnerHtml = prov.StatusCode;
                    }

                    BO_Applications tmpApplications =  BO_Application.SelectForGridByForeignKeyPopsIntID(boProviderPrimaryKey);
                    CurrentAppsList = tmpApplications;

                    if (null != tmpApplications)
                    {
                        BO_Application[] tmpArr = new BO_Application[tmpApplications.Count];
                        int cntr = 0;

                        foreach (BO_Application boApplication in tmpApplications)
                        {
                            tmpArr[cntr] = boApplication;
                            cntr++;
                        }
                        // convert the Array to a DataTable object
                        grdApplicationsDataSource = GridHelper.BO_Array_ConvertToDataTable(tmpArr);
                        // set the dataSource object for thge grid
                        //SMMgrdApplications.DataSource = (DataTable)grdApplicationsDataSource;
                    }
                }
            }

            grdApplications.Height = Unit.Percentage( 95 );
            
            //if ( grdApplicationsDataSource.Rows.Count > 5 )
            //    grdApplications.Height = Unit.Pixel( 375 );
            //else
            //    if ( grdApplicationsDataSource.Rows.Count < 1 )
            //        grdApplications.Height = Unit.Pixel( 65 );
            //    else
            //        grdApplications.Height = Unit.Pixel( ( grdApplicationsDataSource.Rows.Count * 65 ) + 48 );
        }

        private BO_Applications CurrentAppsList
        {
            get
            {
                return (BO_Applications)Session["CurrentAppsList"];
            }
            set
            {
                Session["CurrentAppsList"] = value;
            }
        }

        protected void grdApplications_DeleteCommand(object source, GridCommandEventArgs e)
        {
            bool doDelete = false;
            GridEditableItem editedItem = e.Item as GridEditableItem;
            decimal tmpAppID = Convert.ToDecimal(editedItem["ApplicationID"].Text);

            foreach (BO_Application boApp in CurrentAppsList)
            {
                if (!boApp.ApplicationStatus.Equals("4") && boApp.ApplicationID.Equals(tmpAppID))
                {
                    doDelete = true;
                    break;
                }
            }

            if (doDelete)
            {
                BO_Application.DeleteOneWithAllChildrenUsingApplicationID(new BO_ApplicationPrimaryKey(tmpAppID));
                LoadNewProvider((string)Session["ProviderPOPSINTID"]);
                //SMMgrdApplications.Rebind();                
                doDelete = false;
            }
        }

        protected void grdApplications_InsertCommand(object source, GridCommandEventArgs e)
        {
            GridEditableItem editedItem = e.Item as GridEditableItem;
            LicActivityEditForm tmpBREF = (LicActivityEditForm)e.Item.FindControl(GridEditFormItem.EditFormUserControlID); 
            string tmpBusinessProcessID = "";
            _popsIntId = Convert.ToDecimal(Session["ProviderPOPSINTID"]);

            tmpBusinessProcessID = ((RadComboBox)tmpBREF.FindControl("listAppType")).SelectedValue;
            BO_Application.CreateApplicationByForeignKeyPopsIntID(new BO_ProviderPrimaryKey(_popsIntId), tmpBusinessProcessID);

            CurrentAppsList = BO_Application.SelectForGridByForeignKeyPopsIntID(new BO_ProviderPrimaryKey(_popsIntId));
            LoadNewProvider((string)Session["ProviderPOPSINTID"]);

            //SMM 03/06/2012 - Added to handle applications requiring a letter of intent
            switch ( tmpBusinessProcessID )
            {
                case "8":
                    BO_Application tmpApp = null;
                    BO_LetterOfIntent tmpLOI = new BO_LetterOfIntent();
                    
                    bool AppFound = false;

                    foreach ( BO_Application boApp in CurrentAppsList )
                    {
                        if ( boApp.ApplicationStatus.Equals( "1" ) && boApp.BusinessProcessID.Equals( "8" ) )
                        {
                            tmpApp = boApp;
                            AppFound = true;
                            break;
                        }
                    }

                    if ( AppFound )
                    {
                        tmpLOI.PopsIntID = CurrentProvider.PopsIntID;
                        tmpLOI.StateID = CurrentProvider.StateID;
                        tmpLOI.ApplicationID = tmpApp.ApplicationID;
                        tmpLOI.ProgramID = CurrentProvider.ProgramID;
                        tmpLOI.LetterOfIntentType = "4";
                        tmpLOI.StateCode = CurrentProvider.StateCode;
                        tmpLOI.GeographicAddress = CurrentProvider.GeographicalStreet;
                        tmpLOI.GeographicCity = CurrentProvider.GeographicalCity;
                        tmpLOI.GeographicZip = CurrentProvider.GeographicalZip;
                        tmpLOI.Phone = CurrentProvider.TelephoneNumber;
                        tmpLOI.Email = CurrentProvider.EmailAddress;                        
                        tmpLOI.Name = CurrentProvider.FacilityName;
                        tmpLOI.Insert();
                    }
                    break;
            }

            //SMMgrdApplications.Rebind();
        }

        private DataTable grdApplicationsDataSource
        {
            get { return (DataTable)Session["grdApplicationsDataSource"]; }
            set { Session["grdApplicationsDataSource"] = value; }
        }

        /// <summary>
        /// Reload the fields with the current provider
        /// </summary>
        /// <param name="popsIntId"></param>
        public void LoadNewProvider(string popsIntId)
        {
             // delete pre-existing rows from datasource table
            //DataTable dtTable1 = grdApplicationsDataSource;
            //if (dtTable1 != null)
            //{
            //    dtTable1.Rows.Clear();
            //    dtTable1.AcceptChanges();
            //    grdApplicationsDataSource = dtTable1;
            //    // set the dataSource object for the grid
            //    //grdApplications.DataSource = (DataTable)grdApplicationsDataSource;
            //    //grdApplications.DataBind();
            //}

            if(!string.IsNullOrEmpty(popsIntId))
            {
                // reload the data for the History grid
                InitHistoryGrid(popsIntId);
                // bind the grid
                //grdApplications.DataBind();
            }
        }

        private ATG.Security.User User
        {
            get { return (ATG.Security.User)Session["User"]; }
        }

        private BO_Provider CurrentProvider
        {
            get
            {
                return Session["CurrentProvider"] == null ? null : (BO_Provider) Session["CurrentProvider"];
            }
        }

        private void NewLic(string applicationID, string businessProcess)
        {
            // open a window to display the Physical License
            //GridDataItem dataItem = e.Item as GridDataItem;

            // get the application id
            string appId = applicationID;//dataItem["APPLICATIONID"].Text;
            string appType = businessProcess;//dataItem["BUSINESSPROCESSNAME"].Text;

            //If necessary generate a new license number. 
            //New licensure number when:
            //  Current Licensure number is null/blank
            //  Current Approved Application is 
            //      CHOW, Change of Address, Name Change
            if (!string.IsNullOrEmpty(appId))
            {
                //BO_Application tmpApp = BO_Application.SelectOne( new BO_ApplicationPrimaryKey( Convert.ToDecimal( appId ) ) );
                BO_Application tmpApp = new BO_Application();
                tmpApp.LoadFullApplication(Convert.ToDecimal(appId));
                BO_Provider tmpProv = BO_Provider.SelectOne(new BO_ProviderPrimaryKey(tmpApp.PopsIntID));
                BO_Licenses tmpLics = BO_License.SelectAllByForeignKeyApplicationID(new BO_ApplicationPrimaryKey(tmpApp.ApplicationID));

                if (null != tmpApp)
                {
                    bool GenerateLicenseNum = false;
                    bool LicNumAlreadyGenerated = false;
                    string tmpLicNum = tmpApp.LicensureNum;

                    // No license number then generate one
                    if (string.IsNullOrEmpty(tmpLicNum))
                    {
                        GenerateLicenseNum = true;
                    }
                    // If this is a CHOW or Change of address and a new license number has not
                    // been generated then generate one. 
                    else if (null == tmpLics &&
                             (
                                tmpApp.BusinessProcessID.Equals("4") ||
                                tmpApp.BusinessProcessID.Equals("6")
                             )
                    )
                    {
                        GenerateLicenseNum = true;
                    }
                    // If this is a CHOW or Change of address and other license numbers exist.
                    // This is to allow for forced generation. 
                    else if (null != tmpLics &&
                             (
                                tmpApp.BusinessProcessID.Equals("4") ||
                                tmpApp.BusinessProcessID.Equals("6")
                             )
                    )
                    {
                        tmpLics.Sort("LicensureNum Desc");
                        foreach (BO_License boLic in tmpLics)
                        {
                            if (boLic.LicensureNum.Equals(tmpApp.LicensureNum))
                            {
                                LicNumAlreadyGenerated = true;
                                break;
                            }
                        }
                        if (!LicNumAlreadyGenerated)
                            GenerateLicenseNum = true;
                    }

                    if (GenerateLicenseNum)
                    {
                        tmpApp.GenerateLicensureNum(Convert.ToDecimal(appId), false);
                        tmpApp.Update();

                        if (null != tmpApp.BO_AffiliationsApplicationID)
                        {
                            foreach (BO_Affiliation tmpAffil in tmpApp.BO_AffiliationsApplicationID)
                            {
                                string newLicNum = tmpAffil.LicensureNum;
                                int rhcFirstPos = tmpAffil.LicensureNum.IndexOf("RHC", System.StringComparison.OrdinalIgnoreCase);

                                string[] tmpLicNumParts = tmpAffil.LicensureNum.Split('-');

                                if (null != tmpLicNumParts && tmpLicNumParts.Count() > 0)
                                {
                                    newLicNum = tmpApp.LicensureNum;

                                    if (rhcFirstPos > 0)
                                    {
                                        newLicNum += "RHC";
                                    }

                                    if (tmpLicNumParts.Count() > 1)
                                        newLicNum += "-" + tmpLicNumParts[1];
                                }

                                tmpAffil.LicensureNum = newLicNum;
                                tmpAffil.CurrentLicIssueDate = tmpApp.CurrentLicIssueDate;
                                tmpAffil.Update();
                            }
                        }

                        tmpProv.LicensureNum = tmpApp.LicensureNum;
                        tmpProv.Update();

                        //Create new license tracking record
                        BO_License tmpNewLic = new BO_License();
                        tmpNewLic.PopsIntID = tmpApp.PopsIntID;
                        tmpNewLic.ApplicationID = tmpApp.ApplicationID;
                        tmpNewLic.LicensureNum = tmpApp.LicensureNum;
                        tmpNewLic.Insert();
                    }

                }
            }
        }

    }
}