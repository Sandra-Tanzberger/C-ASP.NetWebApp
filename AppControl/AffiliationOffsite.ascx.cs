using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ATG;
using ATG.BusinessObject;
using ATG.Utilities.Data;
using Telerik.Web.UI;

namespace AppControl
{
    public partial class AffiliationOffsite : System.Web.UI.UserControl
    {
        private BO_Application boApplication = null;
        private bool isProviderTab = false;

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            RadAjaxManager manager = RadAjaxManager.GetCurrent(Page);
            manager.AjaxRequest += new RadAjaxControl.AjaxRequestDelegate(manager_AjaxRequest);
        }

        protected void manager_AjaxRequest(object sender, Telerik.Web.UI.AjaxRequestEventArgs e)
        {
            if (null != e.Argument && e.Argument.Length > 0)
            {
                AffiliationRepeater.DataSource = CurrentAffiliationsDataSource;
                AffiliationRepeater.DataBind();
                _ShowHideFields();
            }
        }

        private BO_Provider CurrentProvider
        {
            get
            {
                return Session["CurrentProvider"] == null ? null : (BO_Provider)Session["CurrentProvider"];
            }
        }

        //overload used to get current provider application for provider page
        public void LoadAffiliation()
        {
            isProviderTab = true;
            AllowEdit = false;
            CurrentAppProvider = BO_Application.SelectMostRecentlyApprovedAppByPopsIntID(new BO_ProviderPrimaryKey(CurrentProvider.PopsIntID));
            _InitAffiliations();

            Button tmpAffilAddAction = (Button)this.FindControlRecursive("AffilAddAction");
            tmpAffilAddAction.Visible = false;

        }

        public void LoadAffiliation( string inAppID, bool inAllowEdit )
        {
            AllowEdit = inAllowEdit;

            if ( inAppID != null && CurrentAppProvider != null )
            {
                _InitAffiliations();
            }
            _ShowHideFields();
        }

        public void ReloadAffilList()
        {
            AffiliationRepeater.DataSource = null;
            _InitAffiliations();
        }

        private void _ShowHideFields()
        {
            if ( Session["userType"].ToString() == "Public" )
            {
                if ( CurrentAppProvider.BusinessProcessID != "8" || CurrentAppProvider.ApplicationStatus.Equals( "4" ) )
                {
                    Button tmpAddAction = (Button) this.FindControlRecursive( "AffilAddAction" );
                    tmpAddAction.Visible = false;
                }

                if ( CurrentAppProvider.BusinessProcessID == "4" || CurrentAppProvider.BusinessProcessID == "5" || CurrentAppProvider.BusinessProcessID == "6" || CurrentAppProvider.BusinessProcessID == "7" || CurrentAppProvider.BusinessProcessID == "9" || CurrentAppProvider.BusinessProcessID == "10" || CurrentAppProvider.ApplicationStatus.Equals( "4" ) )
                {
                    foreach ( RepeaterItem tmpRI in AffiliationRepeater.Items )
                    {
                        if ( tmpRI.ItemType == ListItemType.Item || tmpRI.ItemType == ListItemType.AlternatingItem )
                        {
                            //todo, only hide buttons if this item was added on a previous application
                            //LinkButton tmpEditViewBtn = (LinkButton)tmpRI.FindControl("AffilEditViewAction");
                            LinkButton tmpRemoveBtn = (LinkButton) tmpRI.FindControl( "AffilRemoveAction" );

                            //tmpEditViewBtn.Visible = false;
                            tmpRemoveBtn.Visible = false;
                        }
                    }
                }

                if ( CurrentAppProvider.BusinessProcessID == "8" )
                {
                    Button tmpAddBtn = (Button) Page.FindControl( "AffilAddAction" );

                    if ( null != tmpAddBtn )
                        tmpAddBtn.Enabled = true;

                    foreach ( RepeaterItem tmpRI in AffiliationRepeater.Items )
                    {
                        if ( tmpRI.ItemType == ListItemType.Item || tmpRI.ItemType == ListItemType.AlternatingItem )
                        {
                            HiddenField tmpAffilID = (HiddenField) tmpRI.FindControl( "hidAffilID" );
                            if ( !string.IsNullOrEmpty( tmpAffilID.Value ) && tmpAffilID.Value != "0" )
                            {
                                BO_Affiliation boa = BO_Affiliation.SelectOne( new BO_AffiliationPrimaryKey( CurrentAppProvider.PopsIntID, Convert.ToDecimal( tmpAffilID.Value ), CurrentAppProvider.ApplicationID ) );
                                if ( !_AddedThisApp( boa.AddressID ) )
                                {
                                    //todo, only hide buttons if this item was added on a previous application
                                    //LinkButton tmpEditViewBtn = (LinkButton)tmpRI.FindControl("AffilEditViewAction");
                                    LinkButton tmpRemoveBtn = (LinkButton) tmpRI.FindControl( "AffilRemoveAction" );

                                    //tmpEditViewBtn.Visible = false;
                                    tmpRemoveBtn.Visible = false;
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                if ( CurrentAppProvider.BusinessProcessID == "8" )
                {
                    Button tmpAddAction = (Button) this.FindControlRecursive( "AffilAddAction" );
                    tmpAddAction.Enabled = true;
                }
                else
                {
                    Button tmpAddAction = (Button) this.FindControlRecursive( "AffilAddAction" );
                    tmpAddAction.Enabled = false;
                }

                if ( !CurrentAppProvider.ProgramID.Equals( "HO" ) )
                    DivOwnOtherFacHeader.Visible = false;
            }
        }

        private bool _AddedThisApp(decimal? AddrID)
        {
            bool bRet = true;

            //Determine if this affiliation was added on this application or if it existed on previous applications.
            BO_Affiliations boas = BO_Affiliation.SelectAllByForeignKeyPopsIntID(new BO_ProviderPrimaryKey(CurrentAppProvider.PopsIntID));
            foreach (BO_Affiliation boa in boas)
            {
                if (boa.ApplicationID != CurrentAppProvider.ApplicationID)
                {
                    if (boa.AddressID == AddrID)
                    {
                        bRet = false;
                    }
                }
            }

            return bRet;
        }

        protected void AffiliationRepeater_ItemDataBound( object sender, RepeaterItemEventArgs e )
        {
            if ( e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem )
            {
                HiddenField tmpAffilID = (HiddenField) e.Item.FindControl( "hidAffilID" );

                LinkButton tmpBtn = (LinkButton) e.Item.FindControl( "AffilRemoveAction" );
                if ( tmpBtn != null && !AllowEdit )
                    tmpBtn.Enabled = false;
            }

            //for provider tab
            if (isProviderTab)
            {
                if (e.Item.ItemType == ListItemType.Header)
                {

                    var col = e.Item.FindControl("ActionHeader");
                    if (col != null)
                        col.Visible = false;
                }
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    var col = e.Item.FindControl("ActionColumn");
                    if (col != null)
                        col.Visible = false;
                }
            }
        }

        protected void AffilAddAction_Click( object sender, EventArgs e )
        {
            string tmpAddQueryString = "";
            Button tmpBtn = (Button) sender;
            
            string[] commandArgsSent = tmpBtn.CommandArgument.ToString().Split( new char[] { ',' } );

            tmpAddQueryString += "TYPE=New&";
            tmpAddQueryString += "AFID=0";

            AffiliationRadWin.NavigateUrl = "~/Common/EditForm/AffiliationForm.aspx?" + tmpAddQueryString;
            //AffiliationRadWin.Height = Unit.Pixel( 525 );
            //AffiliationRadWin.Width = Unit.Pixel( 730 );
            AffiliationRadWin.Title = "Add Affiliation";
            AffiliationRadWin.KeepInScreenBounds = true;
            AffiliationRadWin.InitialBehaviors = WindowBehaviors.Maximize;
            AffiliationRadWin.Visible = true;
            AffiliationRadWin.Modal = true;

        }

        protected void AffilEditViewAction_Click( object sender, EventArgs e )
        {
            string tmpAddQueryString = "";
            string tmpAffilID = "";

            LinkButton tmpBtn = (LinkButton) sender;

            string[] commandArgsSent = tmpBtn.CommandArgument.ToString().Split( new char[] { ',' } );
            
            if ( null != CurrentAppProvider.BO_AffiliationsApplicationID && !string.IsNullOrEmpty(commandArgsSent[0]) )
            {
                foreach ( BO_Affiliation tmpAffil in CurrentAppProvider.BO_AffiliationsApplicationID )
                {
                    if ( tmpAffil.getTrackID().Equals( commandArgsSent[0].ToString() ) && tmpAffil.AffiliationID != 0 )
                    {
                        tmpAffilID = tmpAffil.AffiliationID.Value.ToString();
                        break;
                    }
                }
            }

            if ( string.IsNullOrEmpty( tmpAffilID ) )
                tmpAffilID = commandArgsSent[0].ToString();

            tmpAddQueryString += "AFID=" + tmpAffilID + "&"; //Affiliation ID
            tmpAddQueryString += "TYPE=" + commandArgsSent[1].ToString(); //Edit or View

            AffiliationRadWin.NavigateUrl = "~/Common/EditForm/AffiliationForm.aspx?" + tmpAddQueryString;
//            AffiliationRadWin.Height = Unit.Pixel( 525 );
//            AffiliationRadWin.Width = Unit.Pixel( 730 );
            AffiliationRadWin.Title = "Edit Affiliation";
            AffiliationRadWin.KeepInScreenBounds = true;
            AffiliationRadWin.InitialBehaviors = WindowBehaviors.Maximize;
            AffiliationRadWin.Visible = true;
            AffiliationRadWin.Modal = true;

        }

        protected void AffilLinkAction_Click( object sender, EventArgs e )
        {
            string tmpAddQueryString = "";
            LinkButton tmpBtn = (LinkButton) sender;

            string[] commandArgsSent = tmpBtn.CommandArgument.ToString().Split( new char[] { ',' } );

            tmpAddQueryString += "AFID=" + commandArgsSent[0].ToString() + "&"; //Affiliation ID
            tmpAddQueryString += "TYPE=" + commandArgsSent[1].ToString(); //Action

            if ( commandArgsSent[1].ToString().Equals( "Link" ) )
            {
                AffiliationRadWin.NavigateUrl = "~/Common/LinkAffiliation.aspx?" + tmpAddQueryString;
                //            AffiliationRadWin.Height = Unit.Pixel( 525 );
                //            AffiliationRadWin.Width = Unit.Pixel( 730 );
                AffiliationRadWin.Title = "Link Affiliation";
                AffiliationRadWin.KeepInScreenBounds = true;
                AffiliationRadWin.Height = Unit.Pixel( 400 );
                AffiliationRadWin.Width = Unit.Pixel( 800 );
                //AffiliationRadWin.InitialBehavior = WindowBehaviors.Maximize;
                AffiliationRadWin.Behaviors = WindowBehaviors.None;
                AffiliationRadWin.Visible = true;
                AffiliationRadWin.Modal = true;
            }
            else
            {
                foreach ( BO_Affiliation boAffil in CurrentAppProvider.BO_AffiliationsApplicationID )
                {
                    if ( boAffil.UI_TrackID.Equals( commandArgsSent[0].ToString() ) )
                    {
                        boAffil.BranchID = null;
                        boAffil.MedicareBranchID = null;
                        break;
                    }
                }
                CurrentAffiliationsDataSource = null;
                _InitAffiliations();
            }
        }

        protected void AffilRemoveAction_Click( object sender, EventArgs e )
        {
            LinkButton tmpBtn = (LinkButton) sender;

            string[] commandArgsSent = tmpBtn.CommandArgument.ToString().Split( new char[] { ',' } );
            //decimal tmpAffilID = Convert.ToDecimal( commandArgsSent[0].ToString() );

            //if ( tmpAffilID > 0 )
            //{
            //    foreach ( BO_Affiliation tmpBA in CurrentAppProvider.BO_AffiliationsApplicationID )
            //    {
            //        if ( tmpBA.AffiliationID.Equals( tmpAffilID ) )
            //        {
            //            tmpBA.Removed = true;
            //            break;
            //        }
            //    }
            //}

            string tmpUITrackID = commandArgsSent[0].ToString();

            if (tmpUITrackID.Length > 0)
            {
                foreach (BO_Affiliation tmpBA in CurrentAppProvider.BO_AffiliationsApplicationID)
                {
                    if (tmpBA.UI_TrackID.Equals(tmpUITrackID))
                    {
                        tmpBA.Removed = true;
                        break;
                    }
                }
            } 
            
            CurrentAffiliationsDataSource = null;
            AffiliationRepeater.DataSource = CurrentAffiliationsDataSource;
            AffiliationRepeater.DataBind();
            _ShowHideFields();
            
        }

        private void _InitAffiliations()
        {
            AffiliationRepeater.DataSource = CurrentAffiliationsDataSource;
            AffiliationRepeater.DataBind();
        }

        private DataTable _getAffilGridInitTable()        
        {
            DataTable tmpDTbl = new DataTable();
            DataColumn tmpDCol = null;

            tmpDCol = new DataColumn( "LicensureNumber" );
            tmpDTbl.Columns.Add( tmpDCol );
            tmpDCol = new DataColumn( "FacilityName" );
            tmpDTbl.Columns.Add( tmpDCol );
            tmpDCol = new DataColumn( "Address" );
            tmpDTbl.Columns.Add( tmpDCol );
            tmpDCol = new DataColumn( "Phone" );
            tmpDTbl.Columns.Add( tmpDCol );
            tmpDCol = new DataColumn( "Fax" );
            tmpDTbl.Columns.Add( tmpDCol );
            tmpDCol = new DataColumn( "ViewEditCmdText" );
            tmpDTbl.Columns.Add( tmpDCol );
            tmpDCol = new DataColumn( "LinkCmdText" );
            tmpDTbl.Columns.Add( tmpDCol );
            tmpDCol = new DataColumn( "ViewEditCmdArgs" );
            tmpDTbl.Columns.Add( tmpDCol );
            tmpDCol = new DataColumn( "LinkCmdArgs" );
            tmpDTbl.Columns.Add( tmpDCol );
            tmpDCol = new DataColumn( "AffiliationID" );
            tmpDTbl.Columns.Add( tmpDCol );
            tmpDCol = new DataColumn( "BranchID" );
            tmpDTbl.Columns.Add( tmpDCol );
            tmpDCol = new DataColumn( "MCareID" );
            tmpDTbl.Columns.Add( tmpDCol );
            tmpDCol = new DataColumn( "CapSum" );
            tmpDTbl.Columns.Add( tmpDCol );
            // rjc - 8/20/12 - add branch status
            tmpDCol = new DataColumn("BranchStatus");
            tmpDTbl.Columns.Add(tmpDCol);

            return tmpDTbl;
           
        }

        private BO_Application CurrentAppProvider
        {
            get
            {
                return Session["CurrentAppProvider"] == null ? null : (BO_Application) Session["CurrentAppProvider"];
            }

            set
            {
                boApplication = value;
            }
        }

        private DataTable CurrentAffiliationsDataSource
        {
            get
            {
                DataTable retTable = (DataTable) ViewState["CurrentAffiliationsDataSource"];

                if ( retTable == null )
                {
                    retTable = _getAffilGridInitTable();

                    if ( null != CurrentAppProvider && CurrentAppProvider.BO_AffiliationsApplicationID != null )
                    {
                        foreach ( BO_Affiliation boAffil in CurrentAppProvider.BO_AffiliationsApplicationID )
                        {
                            if ( !boAffil.Removed )
                            {
                                DataRow tmpDR = retTable.NewRow();
                                string tmpAddress = "";
                                //SMM 01/22/2012 - Rmoved Title Case conversion
                                //tmpAddress += CommonFunc.ConvertToTitleCase( boAffil.BO_AddressAffiliationID.Street );
                                tmpAddress += boAffil.BO_AddressAffiliationID.Street;
                                tmpAddress += ",<br /> " + CommonFunc.ConvertToTitleCase( boAffil.BO_AddressAffiliationID.City );
                                tmpAddress += ", " + CommonFunc.ConvertToTitleCase( boAffil.BO_AddressAffiliationID.State );
                                tmpAddress += ". " + boAffil.BO_AddressAffiliationID.ZipCode;

                                tmpDR["LicensureNumber"] = boAffil.LicensureNum;
                                //SMM 01/22/2012 - Rmoved Title Case conversion
                                //tmpDR["FacilityName"] = CommonFunc.ConvertToTitleCase( boAffil.FacilityName );
                                tmpDR["FacilityName"] = boAffil.FacilityName;
                                tmpDR["Address"] = tmpAddress;
                                tmpDR["Phone"] = _formatPhoneDisplayText( boAffil.TelephoneNumber );
                                tmpDR["fax"] = _formatPhoneDisplayText( boAffil.FaxPhoneNumber );
                                tmpDR["AffiliationID"] = boAffil.AffiliationID;
                                tmpDR["BranchID"] = null != boAffil.BranchID ? boAffil.BranchID.Value.ToString(): "";
                                tmpDR["MCareID"] = null != boAffil.MedicareBranchID ? boAffil.MedicareBranchID : "";

                                string tmpCapSum = "";

                                switch ( CurrentAppProvider.ProgramID )
                                {
                                    case "HO":
                                        tmpCapSum += "Units/Rooms: " + ( null != boAffil.Unit ? boAffil.Unit.Value.ToString() : "0" );
                                        tmpCapSum += "<br />Licensed Beds: " + ( null != boAffil.TotalLicBeds ? boAffil.TotalLicBeds.Value.ToString() : "0" );
                                        tmpCapSum += "<br />Non-Licensed Beds: " + ( null != boAffil.OtherBeds ? boAffil.OtherBeds.Value.ToString() : "0" );
                                        break;
                                    case "BR":
                                        if ( null != boAffil.BO_ServicesAffiliationID )
                                        {
                                            tmpCapSum = "Total Capacity: 0";

                                            foreach ( BO_Service boSvc in boAffil.BO_ServicesAffiliationID )
                                            {
                                                if ( boSvc.ServiceType.Equals( "01" ) )
                                                {
                                                    if ( null != boSvc.Capacity )
                                                        tmpCapSum = "Total Capacity: " + boSvc.Capacity.Value.ToString();
                                                }
                                            }
                                        }
                                        else
                                        {
                                            tmpCapSum += "Total Capacity: 0";
                                        }
                                        break;
                                }
                                tmpDR["CapSum"] = tmpCapSum;
                                
                                if ( null != boAffil.BranchID && !boAffil.BranchID.Equals( "" ) )
                                {
                                    tmpDR["LinkCmdArgs"] = boAffil.UI_TrackID.ToString() + "," + "Unlink";
                                    tmpDR["LinkCmdText"] = "Unlink";
                                }
                                else
                                {
                                    tmpDR["LinkCmdArgs"] = boAffil.UI_TrackID.ToString() + "," + "Link";
                                    tmpDR["LinkCmdText"] = "Link";
                                }

                                if ( !CurrentAppProvider.BusinessProcessID.Equals("8")
                                    && CurrentAppProvider.ApplicationAction.Equals("2") ) //DHH-Working
                                {
                                    tmpDR["ViewEditCmdArgs"] = boAffil.UI_TrackID.ToString() + "," + "Edit";
                                    tmpDR["ViewEditCmdText"] = "Edit";
                                }
                                else if ( !CurrentAppProvider.BusinessProcessID.Equals( "8" )
                                    || CurrentAppProvider.ApplicationAction.Equals( "4" ) ) //Locked
                                {
                                    tmpDR["ViewEditCmdArgs"] = boAffil.UI_TrackID.ToString() + "," + "View";
                                    tmpDR["ViewEditCmdText"] = "View";
                                }
                                else if ( CurrentAppProvider.BusinessProcessID.Equals( "8" ) )
                                {
                                    if (boAffil.AffiliationID != 0)
                                    {
                                        BO_Affiliation boa = BO_Affiliation.SelectOne(new BO_AffiliationPrimaryKey(CurrentAppProvider.PopsIntID, boAffil.AffiliationID, CurrentAppProvider.ApplicationID));
                                        if (!_AddedThisApp(boa.AddressID))
                                        {
                                            tmpDR["ViewEditCmdArgs"] = boAffil.UI_TrackID.ToString() + "," + "View";
                                            tmpDR["ViewEditCmdText"] = "View";
                                        }
                                        else
                                        {
                                            tmpDR["ViewEditCmdArgs"] = boAffil.UI_TrackID.ToString() + "," + "Edit";
                                            tmpDR["ViewEditCmdText"] = "Edit";
                                        }
                                    }
                                    else
                                    {
                                        tmpDR["ViewEditCmdArgs"] = boAffil.UI_TrackID.ToString() + "," + "Edit";
                                        tmpDR["ViewEditCmdText"] = "Edit";
                                    }

                                }
                                else
                                {
                                    tmpDR["CommandArgs"] = boAffil.UI_TrackID.ToString() + "," + "Edit";
                                    tmpDR["ViewEditCmdText"] = "Edit";
                                }

                                // rjc - 8/20/12 - add branch status
                                String status = "Status: " + boAffil.OperStatCode + "-" + boAffil.StatusCodeDesc + "<br/>";
                                if (boAffil.OpenedDate.HasValue) {
                                    status += "Open: " + boAffil.OpenedDate.Value.ToString("MM/dd/yyyy") + "<br/>";
                                }
                                if (boAffil.ClosedDate.HasValue) {
                                    status += ("Closed: " + boAffil.ClosedDate.Value.ToString("MM/dd/yyyy"));
                                }
                                tmpDR["BranchStatus"] = status;
                                                    
                                retTable.Rows.Add( tmpDR );
                            }
                        }
                    }
                }
                return retTable;
            }
            set
            {
                ViewState["CurrentAffiliationsDataSource"] = value;
            }
        }

        private string _formatPhoneDisplayText( string inPhoneFaxNum )
        {
            string retVal = "";

            if ( null == inPhoneFaxNum || inPhoneFaxNum.Length != 10 )
                retVal = inPhoneFaxNum;
            else
            {
                string tmpStr = "";

                tmpStr += "(" + inPhoneFaxNum.Substring( 0, 3 ) + ")";
                tmpStr += inPhoneFaxNum.Substring( 3, 3 ) + "-";
                tmpStr += inPhoneFaxNum.Substring( 6, 4 );

                retVal = tmpStr;
            }

            return retVal;
        }

        public bool AllowEdit
        {
            get
            {
                return ( null != ViewState["AllowEdit"] ? (bool) ViewState["AllowEdit"] : false );
            }
            set
            {
                ViewState["AllowEdit"] = value;
            }
        }        

    }
}