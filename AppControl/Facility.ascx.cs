using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using ATG.BusinessObject;
using System.Text.RegularExpressions;
using AppControl;
using ATG;
using System.Text;

namespace AppControl
{
    public partial class Facility : System.Web.UI.UserControl
    {

        #region Member Variables

        private FacilityApplications m_FacilityApplicationsControl = null;
        private FacilitySummary     m_FacilitySummaryControl = null;
        private FacilityKeyPersonnel m_FacilityKeyPersonnelControl = null;
        private FacilityOwnership   m_FacilityOwnershipControl = null;
        private FacilityBeds        m_FacilityBedsControl = null;

        private FacilityBilling m_FacilityPaymentsControl = null;
        private FacilityOffiste     m_BranchFacilityDetails = null;
        private FacilityOffiste     m_OffsiteFacilityDetails = null;
        private FacilitySpecialtyUnit m_FacilitySpecialtyUnit = null;

        #endregion

        #region Events

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            LoadProviderTabs();
            InitAllControls();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // do nothing
        }

        /// <summary>
        /// The code in here is for speeding up the Page display in IE, since IE's JS engine
        /// cannot efficiently handle Telerik-generated javascript.
        /// (Note: this would not be required if browser was gecko-based like Firefox)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_PreRender(object sender, EventArgs e)
        {
            // clear out the controls that need not be displayed
            if (rtsProvider.SelectedTab != null)
                HideControlsInInactiveTabs(rtsProvider.SelectedTab.Text);
        }

        /// <summary>
        /// Do nothing in this event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rtsProvider_TabClick(object sender, RadTabStripEventArgs e)
        {
            // when the user clicks on the "History" tab, automatically selecet the Ownership child tab
            if (e.Tab.Text.ToUpper().Equals("HISTORY"))
            {
                RadTab tab1 = rtsProvider.FindTabByText("Billing");
                tab1.Selected = true;
                rpv_History_Billing.Selected = true;
            }
        }

        #endregion

        #region Private

        /// <summary>
        /// Loads all the Provider related custom user controls on the page
        /// </summary>
        private void InitAllControls()
        {
            m_FacilityApplicationsControl = (FacilityApplications)LoadControl("~/AppControl/FacilityApplications.ascx");
            Applications_Content.Controls.Add(m_FacilityApplicationsControl);
            m_FacilityApplicationsControl.ID = "rpv_FacilityApplications_userControl";

            m_FacilitySummaryControl = (FacilitySummary)LoadControl("~/AppControl/FacilitySummary.ascx");
            FacilityDetail_Content.Controls.Add(m_FacilitySummaryControl);
            m_FacilitySummaryControl.ID = "rpv_FacilityDetails_userControl";

            //m_FacilityOwnershipControl = (FacilityOwnership) LoadControl( "~/AppControl/FacilityOwnership.ascx" );
            //FacilityOwnership_Content.Controls.Add( m_FacilityOwnershipControl );
            //m_FacilityOwnershipControl.ID = "rpv_FacilityOwnership_userControl";

            //m_FacilityKeyPersonnelControl = (FacilityKeyPersonnel) LoadControl( "~/AppControl/FacilityKeyPersonnel.ascx" );
            //FacilityPersonnel_Content.Controls.Add( m_FacilityKeyPersonnelControl );
            //m_FacilityKeyPersonnelControl.ID = "rpv_FacilityPersonnel_userControl";

            //m_FacilityBedsControl = (FacilityBeds) LoadControl( "~/AppControl/FacilityBeds.ascx" );
            //History_CapacityBeds_Content.Controls.Add( m_FacilityBedsControl );
            //m_FacilityBedsControl.ID = "rpv_History_CapacityBeds_userControl";

            //m_FacilityPaymentsControl = (BillingHistory) LoadControl( "~/AppControl/BillingHistory.ascx" );
            m_FacilityPaymentsControl = (FacilityBilling)LoadControl("~/AppControl/FacilityBilling.ascx");
            History_Payment_Content.Controls.Add( m_FacilityPaymentsControl );
            m_FacilityPaymentsControl.ID = "rpv_History_Payment_userControl";

            //m_BranchFacilityDetails = (FacilityOffiste) LoadControl( "~/AppControl/FacilityOffiste.ascx" );
            //Branch_Content.Controls.Add( m_BranchFacilityDetails );
            //m_BranchFacilityDetails.ID = "rpv_Branch_Branch_userControl";

            //m_OffsiteFacilityDetails = (FacilityOffiste) LoadControl( "~/AppControl/FacilityOffiste.ascx" );
            //Offsite_Content.Controls.Add( m_OffsiteFacilityDetails );
            //m_OffsiteFacilityDetails.ID = "rpv_Offsite_Offsite_userControl";

            //m_FacilitySpecialtyUnit = (FacilitySpecialtyUnit) LoadControl( "~/AppControl/FacilitySpecialtyUnit.ascx" );
            //SpecialtyUnits_Content.Controls.Add( m_FacilitySpecialtyUnit );
            //m_FacilitySpecialtyUnit.ID = "rpv_SpecialtyUnits_SpecialtyUnits_userControl";
        }

        /// <summary>
        /// 1. Loads tabs into the TabStrip control
        /// 2. Create PageViews for the MultiPage control
        /// 3. Associates the Tabs with their respective PageViews
        /// </summary>
        private void LoadProviderTabs()
        {
            // get the list of PROVIDER_TABS from the LookupValues table
            BO_LookupValues boLookupValues = ProviderTabsLookups;
            if (boLookupValues != null)
            {
                String regexExpSpace = @"\s";
                RadTab parentRadTab = null;
                RadTab newParentRadTab = null;
                string extraTitleCase = "";
                string valOfExtraTitleCaseNoSpaces = "";
                string newRadTabCaption = "";
                string newRadTabCaptionNoSpaces = "";
                string uniqueGeneratedID = "";
                string pageViewId = "";

                foreach (BO_LookupValue boLookupValue in boLookupValues)
                {
                    if (boLookupValue.Extra != null)
                    {
                        extraTitleCase = CommonFunc.ConvertToTitleCase(boLookupValue.Extra);
                        // check if this tab already exists
                        newParentRadTab = rtsProvider.Tabs.FindTabByText(extraTitleCase);
                        if (newParentRadTab == null)
                        {
                            // create a new Parent tab and add it to the TabStrip's tabs colection
                            newParentRadTab = new RadTab();
                            rtsProvider.Tabs.Add(newParentRadTab);
                            // set the Caption for the tab
                            newParentRadTab.Text = extraTitleCase;
                            valOfExtraTitleCaseNoSpaces = Regex.Replace(extraTitleCase, regexExpSpace, "");
                            // set the value
                            newParentRadTab.Value = valOfExtraTitleCaseNoSpaces;
                        }
                        // make this the parent tab
                        parentRadTab = newParentRadTab;
                    }
                    else
                        extraTitleCase = "";

                    // create a new Child tab and add it to the ParentTab's tab colection
                    RadTab newRadTab = new RadTab();
                    bool isChildTab = true;
                    if (parentRadTab != null)
                    {
                        /*
                         * 1. Do NOT add any tabs under the Provider tab. The provider tab's FacilitySummary 
                         * control has RadPanelBar items for displaying the same information.
                         * 
                         * 2. Do NOT add a child tab if the value of "Extra" equals the value of 
                         * the "Valdesc" column
                         */
                        if (!parentRadTab.Text.ToUpper().Equals("PROVIDER")
                            && !boLookupValue.Valdesc.ToUpper().Trim().Equals(boLookupValue.Extra.ToUpper().Trim()))
                        {
                            parentRadTab.Tabs.Add(newRadTab);
                        }
                        else
                            isChildTab = false;
                    }

                    // create the caption for the tab
                    newRadTabCaption = (boLookupValue.Valdesc != null && boLookupValue.Valdesc != "") ? CommonFunc.ConvertToTitleCase(boLookupValue.Valdesc) : "New Tab";
                    // set the Caption for the tab
                    newRadTab.Text = newRadTabCaption;

                    // replace spaces with underscores in the ID strings
                    newRadTabCaptionNoSpaces = Regex.Replace(newRadTabCaption, regexExpSpace, "");
                    uniqueGeneratedID = string.Concat(Regex.Replace(extraTitleCase, regexExpSpace, ""), "_", newRadTabCaptionNoSpaces);
                    newRadTab.Value = uniqueGeneratedID;

                    // set the PageViewId for the new tab
                    pageViewId = string.Concat("rpv_", uniqueGeneratedID);
                    RadPageView rpv = rmpProvider.FindPageViewByID(pageViewId);

                    // if this control is NULL
                    // then we need to create a RadPageView with a panel and load the control
                    // in the Page's onInit !!!
                    if (rpv != null)
                    {
                        if (isChildTab)
                            newRadTab.PageViewID = pageViewId;
                        else
                        {
                            if (string.IsNullOrEmpty(parentRadTab.PageViewID))
                                parentRadTab.PageViewID = pageViewId;
                        }
                    }

                }   //foreach (BO_LookupValue boLookupValue in boLookupValues)

            }   //if (boLookupValues != null)
        }

        /// <summary>
        /// Hide the controls in InActive tabs
        /// </summary>
        /// <param name="tabText"></param>
        private void HideControlsInInactiveTabs(string tabText)
        {
            switch (tabText.ToUpper())
            {
                case "PROVIDER":
                    FacilityDetail_Content.Visible = true;
                    Applications_Content.Visible = false;
                    FacilityOwnership_Content.Visible = false;
                    FacilityPersonnel_Content.Visible = false;
                    History_CapacityBeds_Content.Visible = false;
                    History_Payment_Content.Visible = false;
                    Branch_Content.Visible = false;
                    Offsite_Content.Visible = false;
                    SpecialtyUnits_Content.Visible = false;
                    break;

                case "APPLICATIONS":
                    FacilityDetail_Content.Visible = false;
                    Applications_Content.Visible = true;
                    FacilityOwnership_Content.Visible = false;
                    FacilityPersonnel_Content.Visible = false;
                    History_CapacityBeds_Content.Visible = false;
                    History_Payment_Content.Visible = false;
                    Branch_Content.Visible = false;
                    Offsite_Content.Visible = false;
                    SpecialtyUnits_Content.Visible = false;
                    break;

                case "FACILITY OWNERSHIP":
                    FacilityDetail_Content.Visible = false;
                    Applications_Content.Visible = false;
                    FacilityOwnership_Content.Visible = true;
                    FacilityPersonnel_Content.Visible = false;
                    History_CapacityBeds_Content.Visible = false;
                    History_Payment_Content.Visible = false;
                    Branch_Content.Visible = false;
                    Offsite_Content.Visible = false;
                    SpecialtyUnits_Content.Visible = false;
                    break;

                case "FACILITY PERSONNEL":
                    FacilityDetail_Content.Visible = false;
                    Applications_Content.Visible = false;
                    FacilityOwnership_Content.Visible = false;
                    FacilityPersonnel_Content.Visible = true;
                    History_CapacityBeds_Content.Visible = false;
                    History_Payment_Content.Visible = false;
                    Branch_Content.Visible = false;
                    Offsite_Content.Visible = false;
                    SpecialtyUnits_Content.Visible = false;
                    break;

                case "CAPACITY BEDS":
                    FacilityDetail_Content.Visible = false;
                    Applications_Content.Visible = false;
                    FacilityOwnership_Content.Visible = false;
                    FacilityPersonnel_Content.Visible = false;
                    History_CapacityBeds_Content.Visible = true;
                    History_Payment_Content.Visible = false;
                    Branch_Content.Visible = false;
                    Offsite_Content.Visible = false;
                    SpecialtyUnits_Content.Visible = false;
                    break;

                case "BILLING":
                    FacilityDetail_Content.Visible = false;
                    Applications_Content.Visible = false;
                    FacilityOwnership_Content.Visible = false;
                    FacilityPersonnel_Content.Visible = false;
                    History_CapacityBeds_Content.Visible = false;
                    History_Payment_Content.Visible = true;
                    Branch_Content.Visible = false;
                    Offsite_Content.Visible = false;
                    SpecialtyUnits_Content.Visible = false;
                    break;

                case "BRANCH":
                    FacilityDetail_Content.Visible = false;
                    Applications_Content.Visible = false;
                    FacilityOwnership_Content.Visible = false;
                    FacilityPersonnel_Content.Visible = false;
                    History_CapacityBeds_Content.Visible = false;
                    History_Payment_Content.Visible = false;
                    Branch_Content.Visible = true;
                    Offsite_Content.Visible = false;
                    SpecialtyUnits_Content.Visible = false;
                    break;

                case "OFFSITE":
                    FacilityDetail_Content.Visible = false;
                    Applications_Content.Visible = false;
                    FacilityOwnership_Content.Visible = false;
                    FacilityPersonnel_Content.Visible = false;
                    History_CapacityBeds_Content.Visible = false;
                    History_Payment_Content.Visible = false;
                    Branch_Content.Visible = false;
                    Offsite_Content.Visible = true;
                    SpecialtyUnits_Content.Visible = false;
                    break;

                case "SPECIALTY UNITS":
                    FacilityDetail_Content.Visible = false;
                    Applications_Content.Visible = false;
                    FacilityOwnership_Content.Visible = false;
                    FacilityPersonnel_Content.Visible = false;
                    History_CapacityBeds_Content.Visible = false;
                    History_Payment_Content.Visible = false;
                    Branch_Content.Visible = false;
                    Offsite_Content.Visible = false;
                    SpecialtyUnits_Content.Visible = true;
                    break;

                case "HISTORY":
                    // the history tab has child tabs
                    // call this method again for the selected child tab
                    if (rtsProvider.SelectedTab.SelectedTab != null)
                    {
                        HideControlsInInactiveTabs(rtsProvider.SelectedTab.SelectedTab.Text);
                    }
                    break;
            }
        }

        /// <summary>
        /// Property corresponding to the lookup values for the Tab Structure
        /// </summary>
        private BO_LookupValues ProviderTabsLookups
        {
            get
            {
                BO_LookupValues tmpLkups;
                if (Session["ProviderTabsLookups"] == null)
                {
                    tmpLkups = BO_LookupValue.SelectByFieldOrderByLookupVal("LOOKUP_KEY", "PROVIDER_TABS");
                    ProviderTabsLookups = tmpLkups;
                }
                else
                    tmpLkups = (BO_LookupValues)Session["ProviderTabsLookups"];

                return tmpLkups;
            }
            set
            {
                Session["ProviderTabsLookups"] = value;
            }
        }

        /// <summary>
        /// Maintain the BO_Provider object in Session
        /// </summary>
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

        /// <summary>
        /// Maintain the last approved Application in Session
        /// </summary>
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

        #endregion

        #region Public

        /// <summary>
        /// Sets the visible property of tabs to true/false depending on the current program selected
        /// </summary>
        /// <param name="providerType"></param>
        private void ShowHideProviderTabs(string providerType)
        {
            // get the list of PROVIDER_TABS from the LookupValues table
            BO_LookupValues boLookupValues = ProviderTabsLookups;
            if (boLookupValues != null)
            {
                string extraTitleCase = "";
                String regexExpSpace = @"\s";
                RadTab parentRadTab = null;
                string valOfExtraTitleCaseNoSpaces = "";
                bool isTabVisible = true;

                foreach (BO_LookupValue boLookupValue in boLookupValues)
                {
                    // Display a tab only if either the Allowedtypes is null 
                    // OR if the current ProviderType is in the Allowedtypes value
                    if (boLookupValue.Allowedtypes != null)
                    {
                        if (boLookupValue.Allowedtypes.IndexOf(providerType) > 0)
                            isTabVisible = true;
                        else
                            isTabVisible = false;
                    }
                    else
                        isTabVisible = true;

                    if (boLookupValue.Extra != null)
                    {
                        extraTitleCase = CommonFunc.ConvertToTitleCase(boLookupValue.Extra);
                        valOfExtraTitleCaseNoSpaces = Regex.Replace(extraTitleCase, regexExpSpace, "");

                        RadTab newParentRadTab = rtsProvider.Tabs.FindTabByValue(valOfExtraTitleCaseNoSpaces);
                        // set the Tab's visible property
                        if (newParentRadTab != null)
                            newParentRadTab.Visible = isTabVisible;

                        // make this the parent tab
                        parentRadTab = newParentRadTab;
                    }

                    // create the caption for the tab
                    string newRadTabCaption = (boLookupValue.Valdesc != null && boLookupValue.Valdesc != "") ? CommonFunc.ConvertToTitleCase(boLookupValue.Valdesc) : "New Tab";
                    string newRadTabCaptionNoSpaces = Regex.Replace(newRadTabCaption, regexExpSpace, "");
                    string uniqueGeneratedID = string.Concat(Regex.Replace(extraTitleCase, regexExpSpace, ""), "_", newRadTabCaptionNoSpaces);

                    if (parentRadTab != null)
                    {
                        RadTab newRadTab = parentRadTab.Tabs.FindTabByValue(uniqueGeneratedID);
                        // set the Tab's visible property
                        if (newRadTab != null)
                            newRadTab.Visible = isTabVisible;
                    }

                }   //foreach (BO_LookupValue boLookupValue in boLookupValues)

            }   //if (boLookupValues != null)
        }

        /// <summary>
        /// Reload the controls with data related to the newly selected Provider
        /// </summary>
        public void LoadNewProvider()
        {
            string popsIntId = (string)Session["ProviderPOPSINTID"];
            string programID = (string)Session["ProgramID"];

            //Show or hide Facility tabs
            ShowHideProviderTabs(programID);

            // Reload the data to be displayed in the controls
            BO_Provider boProvider = null;
            BO_Application boApplication = null;
            decimal? appId = null;

            if(!string.IsNullOrEmpty(popsIntId))
            {
                BO_ProviderPrimaryKey boProviderPrimaryKey = new BO_ProviderPrimaryKey(Convert.ToDecimal(popsIntId));
                boProvider = BO_Provider.SelectOne(boProviderPrimaryKey);

                /* 
                 * Load the last approved Application for this Provider
                 */
                if (boProviderPrimaryKey != null)
                {
                    // get the approved apps for this provider
                    BO_Applications tmpApplications = BO_Application.SelectApprovedApplicationsByPopsIntId(boProviderPrimaryKey);
                    if ( tmpApplications != null && tmpApplications.Count > 0 )
                    {
                        // the objects are ordered by completeion date DESC
                        // so the first one is the most recently approved app
                        BO_Application tmpApp = (BO_Application) tmpApplications[0];
                        appId = tmpApp.ApplicationID;

                        // Load the complete Application object with all related child objects
                        boApplication = new BO_Application();
                        boApplication.LoadFullApplication( Convert.ToDecimal( appId ) );
                    }
                    else //Initial
                    {
                        boApplication = BO_Application.SelectCurAppByForeignKeyPopsIntID(boProviderPrimaryKey);                        
                    }
                }
            }

            // set the Session variables
            CurrentProvider = boProvider;
            CurrentAppProvider = boApplication;

            if(appId != null)
                m_FacilitySummaryControl.LoadNewProvider(appId.ToString());
            else
                m_FacilitySummaryControl.LoadNewProvider(string.Empty);

            m_FacilityApplicationsControl.LoadNewProvider(popsIntId);

        }

        #endregion

    }
}