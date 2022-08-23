using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text.RegularExpressions;
using System.DirectoryServices;
using Telerik.Web.UI;
using ATG;
using ATG.BusinessObject;
using ATG.Utilities.Data;
using ATG.GridHelper;
using ATG.Interface;
using ATG.Security;
using AppControl;
using System.Reflection;
using System.Reflection.Emit;
using Microsoft.Reporting.WebForms;

namespace DHH
{
    public partial class StateHome : System.Web.UI.Page, IPostBackEventHandler
    {

        #region Member Variables

        private FacilityGridHelper m_FacilityGridHelper = null;
        private MessageGridHelper m_MessageGridHelper = null;
        private ReportParameters m_ReportParameters = null;
        private LOIGridHelper m_LOIGridHelper = null;
        private AccountingGridHelper m_AccountingGridHelper = null;
        private LetterQueue m_LetterQueue = null;
        private ProgramStaff m_ProgramStaff = null;

        #endregion

        #region Events

        protected override void OnInit( EventArgs e )
        {
            base.OnInit( e );

            m_ReportParameters = (ReportParameters)LoadControl("~/AppControl/ReportParameters.ascx");
            m_LetterQueue = (LetterQueue)LoadControl("~/AppControl/LetterQueue.ascx");
            m_ProgramStaff = (ProgramStaff)LoadControl("~/AppControl/ProgramStaff.ascx");

            _LoadControlsInTopPane();
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (User.IsReadOnly())
            {   
                RadPanelItem piLetterofIntent = MenuPanelBar.FindItemByText("Letter of Intent");
                piLetterofIntent.Visible = false;
                RadPanelItem piLetters = MenuPanelBar.FindItemByText("Letters");
                piLetters.Visible = false;
                RadPanelItem piAccounting = MenuPanelBar.FindItemByText("Accounting");
                piAccounting.Visible = false;
            }

            if (User.HasAccess("ADMIN"))
            {
                RadPanelItem piLetters = MenuPanelBar.FindItemByText("Admin");
                piLetters.Visible = true;
            }
            else
            {
                RadPanelItem piLetters = MenuPanelBar.FindItemByText("Admin");
                piLetters.Visible = false;
            }
        }
        
        protected void Page_Load( object sender, EventArgs e )
        {
            RadAjaxManager manager = RadAjaxManager.GetCurrent( Page );
            manager.AjaxRequest += new RadAjaxControl.AjaxRequestDelegate( manager_AjaxRequest );

            if ( !IsPostBack )
            {            
                //The main default aspx file that is accessed when comming to the site only
                //calculates the the content area height and then redirects to this page for
                //processing.
                int tmpContentHeight = 0;
                string tmpStrVal = Request.QueryString["res"];

                tmpContentHeight = ( null != tmpStrVal && !tmpStrVal.Equals( "" ) ) ? int.Parse( tmpStrVal ) - 128 : 0;

                RadSplitter mainSplitter = (RadSplitter) Page.FindControlRecursive( "StateMasterSplitter" );

                if ( tmpContentHeight > 0 )
                    mainSplitter.Height = Unit.Pixel( tmpContentHeight );
                else
                    mainSplitter.Height = Unit.Pixel( 400 );

                Session["ContentHeight"] = tmpContentHeight;

                _LoadProgramMenu();
                _LoadProcessMenu();
                _LoadReportsMenu();

                divCheckLogViewType.Visible = false;

                if ( CurrentGridType == null )
                    grdDataSource = null;


                System.Web.UI.WebControls.Label tmpCurUsrName = (System.Web.UI.WebControls.Label) Page.FindControlRecursive( "CurrentUserName" );
                System.Web.UI.WebControls.Label tmpCurUsrID = (System.Web.UI.WebControls.Label) Page.FindControlRecursive( "CurrentUserID" );
                System.Web.UI.WebControls.Label tmpCurStaffTypes = (System.Web.UI.WebControls.Label) Page.FindControlRecursive( "CurrentStaffTypes" );

                String userName = ATG.CommonFunc.getUserName();
                //BO_MdsdbPersonnels tmpPersRecs = BO_MdsdbPersonnel.SelectByField(BO_MdsdbPersonnelFields.Loginid, userName); REMOVED ACO DEPENDENCY FROM POPS
                //LOGIN ID ADDED TO PROGRAM_STAFF TABLE, UPDATED TO SYNC WITH ACO - ST - 08-31-2019
                tmpCurUsrID.Text = userName;

                //BO_MdsdbPersonnel tmpAspenPerson = tmpPersRecs[0];
                BO_ProgramStaffs tmpPrgmStaffs = BO_ProgramStaff.SelectByField(BO_ProgramStaffFields.LoginID, userName);

                if ( null != tmpPrgmStaffs && tmpPrgmStaffs.Count > 0 )
                {
                    BO_ProgramStaff tmpPOPS_User = tmpPrgmStaffs[0];

                    tmpCurUsrName.Text = tmpPOPS_User.FirstName + " " + tmpPOPS_User.LastName;
                    tmpCurUsrID.Text = tmpPOPS_User.LoginID.ToString();

                    Session["UserLoginID"] = tmpPOPS_User.LoginID.ToString();

                    BO_LookupValues tmpStfTypes = BO_LookupValue.SelectByField( BO_LookupValueFields.LookupKey, "STAFF_TYPE" );

                    foreach ( BO_LookupValue boLV in tmpStfTypes )
                    {
                        string[] stfTypes = tmpPOPS_User.StaffType.Split( new char[] { ',' } );

                        for ( int x = 0; x < stfTypes.Length; x++ )
                        {
                            if ( boLV.LookupVal.Equals( stfTypes[x] ) )
                                tmpCurStaffTypes.Text += boLV.Valdesc + ", ";
                        }
                    }
                }

            }
        }

        protected void manager_AjaxRequest( object sender, Telerik.Web.UI.AjaxRequestEventArgs e )
        {
            switch ( CurrentGridType )
            {
                case "PROGRAM":
                    m_FacilityGridHelper = new FacilityGridHelper();
                    m_FacilityGridHelper.Initialize( "PROGRAM", CurrentSelectKey );
                    _InitGridColumn( m_FacilityGridHelper.GridColumnList() );
                    grdContent.DataSource = m_FacilityGridHelper.GridDataSource;
                    grdDataSource = m_FacilityGridHelper.GridDataSource;
                    break;
                case "PROCESS":
                    m_FacilityGridHelper = new FacilityGridHelper();
                    m_FacilityGridHelper.Initialize( "PROCESS", CurrentSelectKey );
                    _InitGridColumn( m_FacilityGridHelper.GridColumnList() );
                    grdContent.DataSource = m_FacilityGridHelper.GridDataSource;
                    grdDataSource = m_FacilityGridHelper.GridDataSource;
                    break;
                case "LETTERS":
                    break;
                case "ADMIN":
                    break;
                case "LETTER OF INTENT":
                    m_LOIGridHelper = new LOIGridHelper();
                    m_LOIGridHelper.Initialize( "ALL", CurrentSelectKey );
                    _InitGridColumn( m_LOIGridHelper.GridColumnList() );
                    grdContent.DataSource = m_LOIGridHelper.GridDataSource;
                    grdDataSource = m_LOIGridHelper.GridDataSource;
                    break;
                case "ACCOUNTING":
                    grdContent.Height = Unit.Pixel( Convert.ToInt16( Session["ContentHeight"] ) - 39 );
                    m_AccountingGridHelper = new AccountingGridHelper();
                    m_AccountingGridHelper.Initialize("ALL", CurrentSelectKey, CurrentDateFilter);
                    _InitGridColumn( m_AccountingGridHelper.GridColumnList() );
                    grdContent.DataSource = m_AccountingGridHelper.GridDataSource;
                    grdDataSource = m_AccountingGridHelper.GridDataSource;
                    break;
                default:
                    break;
            }

            grdContent.Rebind();
        }

        private void _LoadControlsInTopPane()
        {
            Top_Pane.Controls.Add(m_ReportParameters);
            m_ReportParameters.ID = "ReportParameters";
            m_ReportParameters.Visible = false;

            Top_Pane.Controls.Add(m_LetterQueue);
            m_LetterQueue.ID = "LetterQueue";
            m_LetterQueue.Visible = false;

            Top_Pane.Controls.Add(m_ProgramStaff);
            m_ProgramStaff.ID = "ProgramStaff";
            m_ProgramStaff.Visible = false;
        }

        protected void onCheckLogViewFilterChanged(object sender, EventArgs e)
        {
            if (optCheckLogInProcess.Checked) {
                CurrentSelectKey = "APPLICATION";
            }
            else if (optCheckLogNonApplication.Checked) {
                CurrentSelectKey = "OTHER";
            }
            else {
                CurrentSelectKey = "ALL";
            }
            
            CurrentDateFilter = dateFilter.SelectedValue;

            ResetSessionVariables();
            Session["CheckLogFormType"] = CurrentSelectKey;
            Session["CheckLogDateFilter"] = CurrentDateFilter;
            _InitializeGrid( CurrentSelectKey );
            grdContent.MasterTableView.SortExpressions.Clear();
            grdContent.Rebind();
        }

        protected void MenuPanelBar_ItemCreated(object sender, RadPanelBarEventArgs e )
        {
            if ( e.Item is RadPanelItem )
            {
                RadPanelItem tmpRPBSender = (RadPanelItem) e.Item;
                RadPanelBarEventArgs tmpEvntArgs = (RadPanelBarEventArgs) e;

                tmpRPBSender.Style.Add( HtmlTextWriterStyle.FontSize, "10pt" );
            }
        }

        protected void MenuPanelBar_ItemClick( object sender, EventArgs e )
        {
            RadPanelBar tmpRPBSender = (RadPanelBar) sender;
            RadPanelBarEventArgs tmpEvntArgs = (RadPanelBarEventArgs) e;
            
            String SelectKey = tmpEvntArgs.Item.Value;
            String OwnerKey = ((RadPanelItem) tmpRPBSender.SelectedItem.Owner).Text;

            CurrentFilterExpression = "";// grdContent.MasterTableView.FilterExpression; 
            grdContent.MasterTableView.FilterExpression = CurrentFilterExpression;

            CurrentGridType = OwnerKey.ToUpper();
            CurrentSelectKey = SelectKey;
            CurrentDateFilter = "LAST30";
            divCheckLogViewType.Visible = false;

            switch ( CurrentGridType )
            {
                case "PROGRAM":
                    //Reset the Session variables used on the State forms
                    ResetSessionVariables();
                    _InitializeGrid( SelectKey );
                    grdContent.MasterTableView.SortExpressions.Clear();
                    grdContent.Rebind();
                    grdContent.Visible = true;
                    m_ReportParameters.Visible = false;
                    break;
                case "PROCESS":
                    //Reset the Session variables used on the State forms
                    ResetSessionVariables();
                    _InitializeGrid( SelectKey );
                    grdContent.MasterTableView.SortExpressions.Clear();
                    grdContent.Rebind();
                    grdContent.Visible = true;
                    m_ReportParameters.Visible = false ;
                    break;
                case "LETTER OF INTENT":
                    //Reset the Session variables used on the State forms
                    ResetSessionVariables();
                    _InitializeGrid( SelectKey );
                    grdContent.MasterTableView.SortExpressions.Clear();
                    grdContent.Rebind();
                    grdContent.Visible = true;
                    m_ReportParameters.Visible = false;
                    break;
                case "LETTERS":
                    //Reset the Session variables used on the State forms
                    ResetSessionVariables();
                    m_ReportParameters.Visible = false;
                    grdContent.Visible = false;
                    m_LetterQueue.Visible = true;
                    m_LetterQueue.LetterQueueGridDataBind();
                    break;
                case "ADMIN":
                     m_ReportParameters.Visible = false;
                    grdContent.Visible = false;
                    m_LetterQueue.Visible = false;
                    m_ProgramStaff.Visible = true;
                    m_ProgramStaff.ProgramStaffGridDataBind();
                    break;
                case "IDR":
                    if ( SelectKey != "" )
                    {
                        string selectedIDRType = SelectKey;

                        Session["idrid"] = 0;
                        Session["idrtype"] = selectedIDRType;
                        grdContent.Visible = true; 
                        m_ReportParameters.Visible = false;
                        
                        int idrid = Convert.ToInt32( Session["idrid"].ToString() );
                        _InitializeGrid( SelectKey );
                        grdContent.MasterTableView.SortExpressions.Clear();
                        grdContent.Rebind();
                    }
                    break;
                case "REPORTS":
                    grdContent.Visible = false;
                    m_LetterQueue.Visible = false;
                    m_ReportParameters.Visible = true;
                    m_ReportParameters.NameOfReport = SelectKey;
                    break;
                case "ACCOUNTING":
                    if ( SelectKey.Equals( "CheckLogView" ) )
                    {
                        //Reset the Session variables used on the State forms
                        //ResetSessionVariables();
                        _InitializeGrid( SelectKey );
                        grdContent.MasterTableView.SortExpressions.Clear();
                        grdContent.Rebind();
                        grdContent.Visible = true;
                        m_ReportParameters.Visible = false;
                        m_LetterQueue.Visible = false;
                        divCheckLogViewType.Visible = true;
                    }
                    else
                    {
                        grdContent.Visible = false;
                        m_LetterQueue.Visible = false;
                        m_ReportParameters.Visible = true;
                        m_ReportParameters.NameOfReport = SelectKey;
                        divCheckLogViewType.Visible = false;
                        
                    }
                    break;
                default: break;
            }

        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            TextBox tbSrchVal = ((TextBox)MenuPanelBar.FindControlRecursive("txtSearchVal"));
            System.Web.UI.WebControls.Label lbNotFound = ((System.Web.UI.WebControls.Label)MenuPanelBar.FindControlRecursive("lblNotFound"));

            try
            {
                int.Parse(tbSrchVal.Text);
                int tmpLoiID = Convert.ToInt32(tbSrchVal.Text);
                lbNotFound.Visible = false;
                //MenuPanelBar.Height = Unit.Pixel(320);

                if (tmpLoiID > 0)
                {
                    BO_LetterOfIntent tmpLetIntent = BO_LetterOfIntent.SelectOne(new BO_LetterOfIntentPrimaryKey(tmpLoiID));

                    if (null != tmpLetIntent)
                    {
                        //m_ListLetterOfIntentControl.srchID = tmpLoiID;

                        //m_FacilityGrid.Visible = false;
                        //m_ListLetterOfIntentControl = (ListLetterOfIntentControl)Page.FindControlRecursive("ListLetterOfIntentControl");
                        //m_ListLetterOfIntentControl.Visible = true;
                        //m_ListLetterOfIntentControl.loiVisible = true;
                        //m_ListLetterOfIntentControl.Load_LOIs();
                    }
                    else
                    {
                        //MenuPanelBar.Height = Unit.Pixel(350);
                        lbNotFound.Text = "*No Matching Record found";
                        lbNotFound.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                //MenuPanelBar.Height = Unit.Pixel(350);
                lbNotFound.Text = "*Invalid Tracking ID";
                lbNotFound.Visible = true;
            }
        }

        private void _InitializeGrid( String inSelectKey )
        {
            grdContent.ClientSettings.EnablePostBackOnRowClick = false;
            grdContent.ClientSettings.Selecting.AllowRowSelect = true;
            grdContent.ClientSettings.Scrolling.AllowScroll = true;
            grdContent.ClientSettings.Scrolling.UseStaticHeaders = true;
            grdContent.AllowMultiRowSelection = false;
            grdContent.Height = Unit.Pixel( Convert.ToInt16( Session["ContentHeight"] ) - 2 );
                    
            switch ( CurrentGridType )
            {
                case "PROGRAM":
                    m_FacilityGridHelper = new FacilityGridHelper();
                    m_FacilityGridHelper.Initialize( "PROGRAM", inSelectKey );
                    _InitGridColumn( m_FacilityGridHelper.GridColumnList() );
                    grdContent.DataSource = m_FacilityGridHelper.GridDataSource;
                    grdDataSource = m_FacilityGridHelper.GridDataSource;
                    break;
                case "PROCESS":
                    m_FacilityGridHelper = new FacilityGridHelper();
                    m_FacilityGridHelper.Initialize( "PROCESS", inSelectKey );
                    _InitGridColumn( m_FacilityGridHelper.GridColumnList() );
                    grdContent.DataSource = m_FacilityGridHelper.GridDataSource;
                    grdDataSource = m_FacilityGridHelper.GridDataSource;
                    break;
                case "LETTERS":
                    m_MessageGridHelper = new MessageGridHelper();
                    m_MessageGridHelper.Initialize( "APPLICATION", inSelectKey );
                    _InitGridColumn( m_MessageGridHelper.GridColumnList() );
                    grdContent.AllowMultiRowSelection = true;
                    grdContent.DataSource = m_MessageGridHelper.GridDataSource;
                    grdDataSource = m_MessageGridHelper.GridDataSource;
                    break;
                case "LETTER OF INTENT":
                    m_LOIGridHelper = new LOIGridHelper();
                    m_LOIGridHelper.Initialize( "ALL", inSelectKey );
                    _InitGridColumn( m_LOIGridHelper.GridColumnList() );
                    grdContent.DataSource = m_LOIGridHelper.GridDataSource;
                    grdDataSource = m_LOIGridHelper.GridDataSource; 
                    break;
                case "ACCOUNTING":
                    grdContent.Height = Unit.Pixel( Convert.ToInt16( Session["ContentHeight"] ) - 39 );
                    m_AccountingGridHelper = new AccountingGridHelper();
                    m_AccountingGridHelper.Initialize("ALL", inSelectKey, CurrentDateFilter);
                    _InitGridColumn( m_AccountingGridHelper.GridColumnList() );
                    grdContent.DataSource = m_AccountingGridHelper.GridDataSource;
                    grdDataSource = m_AccountingGridHelper.GridDataSource; 
                    break;
                default:
                    break;
            }
        }

        private void _InitGridColumn( GridBoundColumn[] inColumnList )
        {
            //The first column in the grid is a Select (Checkbox) column. This will always exist
            //so we want to keep this one and remove the rest.
            //SMM 02/16/2012 - Added an action column now the first two are kept
            // column[0] = GridClientSelectColumn(Checkbox)
            // column[1] = GridTemplateColumn - Actions
            int colCnt = grdContent.Columns.Count;
            for ( int x = colCnt; x > 2; x-- )
            {
                grdContent.Columns.RemoveAt( x - 1 );
            }

            //Now depending on the gridtype hide 
            switch ( CurrentGridType )
            {
                case "LETTERS":
                    grdContent.Columns[0].Visible = true;
                    grdContent.Columns[1].Visible = false;
                    break;
                case "LETTER OF INTENT":
                    grdContent.Columns[0].Visible = false;
                    grdContent.Columns[1].Visible = true;
                    break;
                default:
                    grdContent.Columns[0].Visible = false;
                    grdContent.Columns[1].Visible = false;
                    break;
            }

            foreach ( GridBoundColumn tmpCol in inColumnList )
            {
                GridBoundColumn gbc = new GridBoundColumn();
                grdContent.Columns.Add( gbc );
                gbc.UniqueName = tmpCol.UniqueName;
                gbc.DataField = tmpCol.DataField;
                gbc.HeaderText = tmpCol.HeaderText;
                gbc.Visible = tmpCol.Visible;
                gbc.AllowFiltering = tmpCol.AllowFiltering;
                gbc.HeaderStyle.Width = tmpCol.HeaderStyle.Width;
            }
        }

        /// <summary>
        /// Set the datasource for the Provider's grid
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void grdContent_NeedDataSource( object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e )
        {
            //If the grid data source is there then use it and capture the current user filter settings
            //if not then initialize it.
            //SMM TODO - When we integrate the user login/security on the state side then we should be able to
            //pick up thier defalut PROGRAM and will set it in place of "ZZ" below.
            if ( null != grdDataSource )
            {
                CurrentFilterExpression = grdContent.MasterTableView.FilterExpression;
                grdContent.DataSource = (DataTable) grdDataSource;
            }
            else
            {
                CurrentFilterExpression = "";
                CurrentGridType = "PROGRAM";
                _InitializeGrid( "ZZ" );
            }
        }

        protected void grdContent_PreRender( object source, EventArgs e )
        {
            //Depending on the GridType enable\disable associated command items
            LinkButton tmpViewBtn = (LinkButton) Page.FindControlRecursive( "btnView" );
            LinkButton tmpPrintSelBtn = (LinkButton) Page.FindControlRecursive( "btnPrintSelected" );
            LinkButton tmpResendBtn = (LinkButton) Page.FindControlRecursive( "btnResend" );
            LinkButton tmpAddBtn = (LinkButton) Page.FindControlRecursive( "btnAdd" );
            LinkButton tmpUpdateBtn = (LinkButton) Page.FindControlRecursive( "btnUpdate" );
            LinkButton tmpDeleteBtn = (LinkButton) Page.FindControlRecursive( "btnDelete" );
            LinkButton tmpDeleteCheckLogBtn = (LinkButton)Page.FindControlRecursive("btnDeleteCheckLog");
            LinkButton tmpAddLOIBtn = (LinkButton) Page.FindControlRecursive( "btnAddLOI" );
            LinkButton tmpAddRFABtn = (LinkButton) Page.FindControlRecursive( "btnAddRFA" );
            LinkButton tmpAddCERBtn = (LinkButton) Page.FindControlRecursive( "btnAddCER" );
            LinkButton tmpMatchBtn = (LinkButton) Page.FindControlRecursive( "btnMatch" );
            LinkButton tmpBatchBtn = (LinkButton) Page.FindControlRecursive( "btnBatchPIV" );
            Button tmpGenBtn = (Button) Page.FindControlRecursive( "btnGridUserDoAction" );
            RadComboBox tmpGridActionCbo = (RadComboBox) Page.FindControlRecursive( "cboGridUserAction" );

            tmpViewBtn.Visible = false;
            tmpPrintSelBtn.Visible = false;
            tmpResendBtn.Visible = false;
            tmpAddBtn.Visible = false;
            tmpUpdateBtn.Visible = false;
            tmpDeleteBtn.Visible = false;
            tmpAddLOIBtn.Visible = false;
            tmpAddRFABtn.Visible = false;
            tmpAddCERBtn.Visible = false;
            tmpMatchBtn.Visible = false;
            tmpBatchBtn.Visible = false;
            tmpGenBtn.Visible = false;
            tmpGridActionCbo.Visible = false;
            tmpDeleteCheckLogBtn.Visible = false;

            switch ( CurrentGridType )
            {
                case "PROGRAM":
                    tmpViewBtn.Visible = true;
                    break;
                case "PROCESS":
                    tmpViewBtn.Visible = true;
                    break;
                case "LETTERS":
                    tmpPrintSelBtn.Visible = true;
                    tmpResendBtn.Visible = true;
                    break;
                case "LETTER OF INTENT":
                    //tmpViewBtn.Visible = true;
                    tmpGenBtn.Visible = true;
                    tmpGridActionCbo.Visible = true;
                    //tmpAddLOIBtn.Visible = true;
                    //tmpAddRFABtn.Visible = true;
                    //tmpAddCERBtn.Visible = true;
                    //tmpMatchBtn.Visible = true;
                    break;
                case "IDR":
                    tmpAddBtn.Visible = true;
                    tmpDeleteBtn.Visible = true;
                    tmpUpdateBtn.Visible = true;
                    
                    if ( ( Session["idrid"] == null || Session["idrid"].ToString() == "0" ) && grdContent.SelectedItems.Count == 0 )
                    {
                        Session["idrid"] = 0;
                        if ( grdContent.Items.Count > 0 )
                        {
                            grdContent.Items[0].Selected = true;
                            Session["idrid"] = grdContent.Items[0]["IdrID"].Text;
                        }
                    }
                    else if ( Session["idrid"].ToString() != "0" ) // && grdIDR.SelectedItems.Count == 0
                    {
                        foreach ( GridDataItem grditm in grdContent.Items )
                        {
                            if ( grditm["IdrID"].Text == Session["idrid"].ToString() )
                            {
                                if ( grditm.Selected == false )
                                {
                                    grditm.Selected = true;
                                }
                                break;
                            }
                        }
                    }

                    break;
                case "ACCOUNTING":
                    //if ( !CurrentSelectKey.Equals( "ALL" ) )
                    //{
                    //    tmpAddBtn.Visible = true;
                    //    tmpUpdateBtn.Visible = true;
                    //}
                    if ( CurrentSelectKey.Equals( "APPLICATION" ) )
                    {
                        tmpAddBtn.Visible = true;
                        tmpUpdateBtn.Visible = true;
                    }
                    if ( CurrentSelectKey.Equals( "OTHER" ) )
                    {
                        tmpAddBtn.Visible = true;
                        tmpUpdateBtn.Visible = true;
                    }

                    if(User.HasAccess("PBG"))
                        tmpDeleteCheckLogBtn.Visible = true;

                    tmpBatchBtn.Visible = true;
                    tmpViewBtn.Visible = false;
                    tmpAddLOIBtn.Visible = false;
                    tmpAddRFABtn.Visible = false;
                    tmpAddCERBtn.Visible = false;
                    tmpMatchBtn.Visible = false;
                    break;
                default:
                    tmpViewBtn.Visible = false;
                    tmpPrintSelBtn.Visible = false;
                    tmpResendBtn.Visible = false;
                    tmpAddBtn.Visible = false;
                    tmpDeleteBtn.Visible = false;
                    tmpUpdateBtn.Visible = false;
                    break;
            }

            //Reapply any Filter expressions applied by the user
            grdContent.MasterTableView.FilterExpression = CurrentFilterExpression;

        }

        protected void grdContent_ItemDataBound( object sender, Telerik.Web.UI.GridItemEventArgs e )
        {
            if ( e.Item is GridDataItem )
            {
                GridDataItem item = (GridDataItem) e.Item;
                int RowIndex = item.ItemIndex;
                string tmpTypeLOI = "";
                string tmpConfirmed = "";

                if ( CurrentGridType.Equals( "LETTER OF INTENT" ) )
                {
                    LinkButton tmpBtnView = (LinkButton) item["Actions"].FindControl( "LinkButtonView" );
                    LinkButton tmpBtnMatch = (LinkButton) item["Actions"].FindControl( "LinkButtonMatch" );
                    LinkButton tmpBtnDelete = (LinkButton) item["Actions"].FindControl( "LinkButtonDelete" );
                    
                    tmpTypeLOI = item["TypeLOI"].Text;
                    tmpConfirmed = item["Confirmed"].Text;

                    if ( ( "4" ).Contains( tmpTypeLOI ) ) //No match for offsite additions
                    {
                        tmpBtnView.Attributes.Add( "OnClick", "return SelectGridRow('" + RowIndex + "','');" );
                        tmpBtnMatch.Visible = false;
                    }
                    else
                    {
                        tmpBtnView.Attributes.Add( "OnClick", "return SelectGridRow('" + RowIndex + "', '');" );
                        tmpBtnMatch.Attributes.Add( "OnClick", "return SelectGridRow('" + RowIndex + "', '');" );
                    }

                    //No delete for confirmed(linked) or Offsite additions
                    //These are handled when an application of the same type is deleted
                    if ( ( "4" ).Contains( tmpTypeLOI ) 
                         || ( tmpConfirmed.Equals( "1" ) && ( "1" ).Contains( tmpTypeLOI ) )
                       )
                    {
                        tmpBtnDelete.Visible = false;
                    }
                    else
                    {
                        tmpBtnDelete.Attributes.Add( "OnClick", "return SelectGridRow('" + RowIndex + "', 'DELETE');" );
                    }
                }
            }
        }  

        /// <summary>
        /// Get the PopsIntID of the newly provider
        /// and display the details for the selected facility
        /// in a popup window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdContent_ItemCommand( object sender, GridCommandEventArgs e )
        {
            GridDataItem dataItem = null;
            if ( e.CommandName.Equals( "Generate" ) )
            {
                RadComboBox tmpGridActionCbo = (RadComboBox) Page.FindControlRecursive( "cboGridUserAction" );

                if ( tmpGridActionCbo.SelectedValue.Equals("AddLOI") )
                {
                    // set session variables
                    Session["Type_LOI"] = "1"; // "LOI";
                    Session["LOI_ID"] = "";
                    OpenItemInWindow( dataItem );
                }

                if ( tmpGridActionCbo.SelectedValue.Equals( "AddLOI_OA" ) )
                {
                    // set session variables
                    Session["Type_LOI"] = "4"; // "LOI";
                    Session["LOI_ID"] = "";
                    OpenItemInWindow( dataItem );
                }

                if ( tmpGridActionCbo.SelectedValue.Equals( "AddRFA" ) )
                {
                    // set session variables
                    Session["Type_LOI"] = "2"; // "RFA";
                    Session["LOI_ID"] = "";
                    OpenItemInWindow( dataItem );
                }

                if ( tmpGridActionCbo.SelectedValue.Equals( "AddCER" ) )
                {
                    // set session variables
                    Session["Type_LOI"] = "3"; // "CER";
                    Session["LOI_ID"] = "";
                    OpenItemInWindow( dataItem );
                }

            }

            if ( e.CommandName.Equals( "View" ) )
            {
                // get the currently selected Provider
                if ( grdContent.SelectedItems.Count > 0 )
                {
                    dataItem = (GridDataItem) grdContent.SelectedItems[0];

                    switch ( CurrentGridType )
                    {
                        case "PROGRAM":
                            // Use the GridDataItem to open Facility details
                            OpenItemInWindow( dataItem );
                            break;
                        case "PROCESS":
                            // Use the GridDataItem to open Facility details
                            OpenItemInWindow( dataItem );
                            break;
                        case "LETTER OF INTENT":
                            // set session variables
                            Session["Type_LOI"] = dataItem["TypeLOI"].Text.ToString();
                            Session["LOI_ID"] = dataItem["LetterOfIntentID"].Text.ToString();

                            OpenItemInWindow( dataItem );
                            break;
                        case "IDR":
                            Session["idreditmode"] = false;
                            Session["idraction"] = "view";
                            Session["idrid"] = dataItem["IdrID"].Text;
                            OpenItemInWindow( null );
                            break;
                    }
                }
            }
            
            if ( e.CommandName.Equals( "Print" ) )
            {
                System.Collections.Hashtable target = null;
                target = MessagesChecked;
                
                foreach ( GridDataItem gdi in grdContent.SelectedItems )
                {
                    target[gdi["MessageID"].Text] = true;
                }
                
                //Print selected rows using MessagesChecked collection
                Session["MessagesChecked"] = MessagesChecked;

                //RadWin1.NavigateUrl = "~/DHH/LettersPrint.aspx";
                RadWin1.NavigateUrl = "~/Common/LettersReportViewerPage.aspx";
                RadWin1.VisibleStatusbar = false;
                RadWin1.VisibleOnPageLoad = true;
                RadWin1.Height = Unit.Pixel( 600 );
                RadWin1.Width = Unit.Pixel( 800 );
                RadWin1.Behaviors = WindowBehaviors.Maximize;
                RadWin1.Behaviors = WindowBehaviors.Close;

                RadWin1.Modal = true;
                RadWin1.VisibleOnPageLoad = true;
                RadWin1.Height = Unit.Pixel(525);
                RadWin1.Width = Unit.Pixel(730);
                RadWin1.Title = "Print Letters";
                RadWin1.InitialBehaviors = WindowBehaviors.Maximize;
                RadWindowManager1.Style.Add("z-index", "9999");
                RadWindowManager1.Behaviors = WindowBehaviors.Close;

                //clear messagechecked viewstate after loading reports
                MessagesChecked = null;
            }

            if ( e.CommandName.Equals( "ReSend" ) )
            {
                System.Collections.Hashtable target = null;
                target = MessagesChecked;

                foreach ( GridDataItem gdi in grdContent.SelectedItems )
                {
                    target[gdi["MessageID"].Text] = true;
                }

                //Reset selected messages to "Pending" to resend the email.
                foreach ( string msgid in MessagesChecked.Keys )
                {
                    object isChecked = null;
                    isChecked = MessagesChecked[msgid];

                    //Is message checked to be printed?
                    if ( isChecked != null )
                    {
                        if ( (bool) isChecked == true )
                        {
                            //Get message and address data and build html
                            BO_MessagePrimaryKey bomkey = new BO_MessagePrimaryKey( Convert.ToDecimal( msgid ) );
                            BO_Message bom = BO_Message.SelectOne( bomkey );

                            // Only resend outgoing electronic message types                           
                            if ( bom.MessageSendType == "2" && bom.MessageDirection == "2" )
                            {
                                bom.MessageDeliveryStatus = "1";
                                bom.MessageFailureCode = null;
                                bom.Update();
                            }
                        }
                    }
                }

                m_MessageGridHelper = new MessageGridHelper();
                m_MessageGridHelper.Initialize( "APPLICATION", CurrentSelectKey );
                grdDataSource = m_MessageGridHelper.GridDataSource;
                grdContent.Rebind();
            }

            if ( e.CommandName.Equals( "Add" ) )
            {
                switch ( CurrentGridType )
                {
                    case "LETTER OF INTENT":
                        OpenItemInWindow( null );
                        break;
                    case "ACCOUNTING":
                        OpenItemInWindow( null );
                        break;
                }
            }

            if ( e.CommandName.Equals( "Update" ) )
            {

                switch ( CurrentGridType )
                {
                    case "IDR":
                        // get the currently selected Provider
                        if ( grdContent.SelectedItems.Count > 0 )
                        {
                            dataItem = (GridDataItem) grdContent.SelectedItems[0];

                            Session["idreditmode"] = true;
                            Session["idraction"] = "update";
                            Session["idrid"] = dataItem["IdrID"].Text;
                            OpenItemInWindow( null );
                        }
                        break;
                    case "ACCOUNTING":
                        // get the currently selected Provider
                        if ( grdContent.SelectedItems.Count > 0 )
                        {
                            dataItem = (GridDataItem) grdContent.SelectedItems[0];
                            OpenItemInWindow( dataItem );
                        }
                        break;
                }
            }

            if ( e.CommandName.Equals( "Delete" ) )
            {
                switch ( CurrentGridType )
                {
                    case "IDR":
                        // get the currently selected Provider
                        if ( grdContent.SelectedItems.Count > 0 )
                        {
                            dataItem = (GridDataItem) grdContent.SelectedItems[0];

                            Session["idrid"] = dataItem["IdrID"].Text;
                            //DeleteBtn_OnClick();
                        }
                        break;
                    case "LETTER OF INTENT":
                        // get the currently selected Provider
                        if ( grdContent.SelectedItems.Count > 0 )
                        {
                            decimal tmpLOI_ID = 0;
                            dataItem = (GridDataItem) grdContent.SelectedItems[0];
                            tmpLOI_ID = Convert.ToDecimal( dataItem["LetterOfIntentID"].Text );

                            BO_LetterOfIntent tmpLOI = BO_LetterOfIntent.SelectOne( new BO_LetterOfIntentPrimaryKey( tmpLOI_ID ) );

                            if ( null != tmpLOI )
                            {
                                tmpLOI.Delete();
                                foreach ( DataRow tmpDR in grdDataSource.Rows )
                                {
                                    if ( tmpDR["LetterOfIntentID"].ToString().Equals( tmpLOI_ID.ToString() ) )
                                    {
                                        tmpDR.Delete();
                                        break;
                                    }
                                }
                                grdContent.Rebind();
                            }
                            
                        }
                        break;
                }

            }
            
            if ( e.CommandName.Equals( "Match" ) )
            {
                // get the currently selected LOI
                if ( grdContent.SelectedItems.Count > 0 )
                {
                    dataItem = (GridDataItem) grdContent.SelectedItems[0];

                    // set session variables
                    Session["Type_LOI"] = "MATCH";
                    Session["LOI_ID"] = dataItem["LetterOfIntentID"].Text.ToString();
                    OpenItemInWindow( dataItem );
                }
            }

            if ( e.CommandName.Equals( "Batch" ) )
            {
                RadWin1.NavigateUrl = "~/Common/EditForm/BatchPIVForm.aspx";
                RadWin1.Title = "Update PIV by Batch ID";
                RadWin1.Behaviors = WindowBehaviors.Move;
                RadWin1.VisibleStatusbar = false;
                RadWin1.VisibleOnPageLoad = true;
                RadWin1.Height = Unit.Pixel( 150 );
                RadWin1.Width = Unit.Pixel( 200 );
            }

            if (e.CommandName.Equals("DeleteCheckLog"))
            {
                if (grdContent.SelectedItems.Count > 0)
                {
                    foreach (Telerik.Web.UI.GridDataItem item in grdContent.SelectedItems)
                    {
                        BO_BillingDetail.Delete(new BO_BillingDetailPrimaryKey(Convert.ToDecimal(item["BillingDetailID"].Text)));
                    }

                    m_AccountingGridHelper = new AccountingGridHelper();
                    m_AccountingGridHelper.Initialize("ALL", "ALL", CurrentDateFilter);
                    _InitGridColumn(m_AccountingGridHelper.GridColumnList());
                    grdContent.DataSource = m_AccountingGridHelper.GridDataSource;
                    grdDataSource = m_AccountingGridHelper.GridDataSource;
                    grdContent.Rebind();
                }
            }
        }

        protected void grdContent_ItemCreated( object sender, GridItemEventArgs e )
        {
            //The filter columns are created dynamically so we need to force them to visible when they
            //are created
            //if ( !IsPostBack && e.Item is GridFilteringItem )
            //{
            //    e.Item.Style["display"] = "block";
            //}

            if ( e.Item is GridFilteringItem )
            {
                e.Item.Style["display"] = "block";

                GridFilteringItem filteringItem = e.Item as GridFilteringItem;

                if ( CurrentGridType.Equals( "PROGRAM" ) || CurrentGridType.Equals( "PROCESS" ) )
                {
                    TextBox box = filteringItem["FacilityName"].Controls[0] as TextBox;
                    box.Width = Unit.Pixel( 165 );
                }

            }

        }  

        /// <summary>
        /// The Grid's client side doubleclick event calls a JS that causes postback
        /// </summary>
        /// <param name="eventArgument"></param>
        public void RaisePostBackEvent( string eventArgument )
        {
            if ( ( CurrentGridType.Equals("PROGRAM") 
                   || CurrentGridType.Equals("PROCESS")
                   || CurrentGridType.Equals("IDR") 
                 ) 
                && eventArgument.IndexOf( "RowDoubleClicked" ) != -1 )
            {
                GridDataItem dataItem = grdContent.Items[int.Parse( eventArgument.Split( ':' )[1] )];

                switch ( CurrentGridType )
                {
                    case "PROGRAM":
                        // Use the GridDataItem to open Facility details
                        OpenItemInWindow( dataItem );
                        break;
                    case "PROCESS":
                        // Use the GridDataItem to open Facility details
                        OpenItemInWindow( dataItem );
                        break;
                    case "IDR":
                        Session["idreditmode"] = false;
                        Session["idraction"] = "view";
                        Session["idrid"] = dataItem["IdrID"].Text;
                        OpenItemInWindow( null );
                        break;
                }
            }
        }

        #endregion

        #region Private

        private void _LoadProgramMenu()
        {
            RadPanelItem rpi = MenuPanelBar.Items.FindItemByText( "Program" );
            BO_Programs boPgm = BO_Program.SelectAll();

            RadPanelItem tmpRPI = new RadPanelItem();
            tmpRPI.Text = "All";
            tmpRPI.Value = "~";
            tmpRPI.Style.Add( HtmlTextWriterStyle.FontSize, "10pt" );
            rpi.Items.Add(tmpRPI);

            boPgm.Sort( "ProgramDescription" );

            foreach (BO_Program itrPgm in boPgm)
            {
                //Show only active programs
                if ( itrPgm.Active.Value )
                {
                    tmpRPI = new RadPanelItem();
                    // Do not conver to title case these providers
                    if ( ( "HC" ).Contains( itrPgm.ProgramID ) )
                        tmpRPI.Text = itrPgm.ProgramDescription;
                    else
                        tmpRPI.Text = CommonFunc.ConvertToTitleCase( itrPgm.ProgramDescription );

                    tmpRPI.Style.Add( HtmlTextWriterStyle.FontSize, "10pt" );
                    tmpRPI.Value = itrPgm.ProgramID;
                    rpi.Items.Add( tmpRPI );
                }
            }
        }

        private void _LoadProcessMenu()
        {
            RadPanelItem rpi = MenuPanelBar.Items.FindItemByText("Process");
            BO_BusinessProcesses boProcs = BO_BusinessProcesse.SelectAll();

            RadPanelItem tmpRPI = new RadPanelItem();
            tmpRPI.Text = "All";
            tmpRPI.Value = "~";
            tmpRPI.Style.Add( HtmlTextWriterStyle.FontSize, "10pt" );
            rpi.Items.Add( tmpRPI );

            foreach (BO_BusinessProcesse itrProc in boProcs)
            {
                if ( !itrProc.BusinessProcessID.Equals( "1" ) ) // No ETL for process list
                {
                    tmpRPI = new RadPanelItem();
                    tmpRPI.Text = CommonFunc.ConvertToTitleCase( itrProc.BusinessProcessName );
                    tmpRPI.Value = itrProc.BusinessProcessID;
                    tmpRPI.Style.Add( HtmlTextWriterStyle.FontSize, "10pt" );
                    rpi.Items.Add( tmpRPI );
                }
            }
        }

        private void _LoadReportsMenu()
        {
            RadPanelItem rpi = MenuPanelBar.Items.FindItemByText("Reports");

            // get the PHYSICAL_LICENSE_REPORT lookup values 
            BO_LookupValues reportNameLookupsCollection = ReportNameLookups;

            RadPanelItem tmpRPI = null;
            foreach (BO_LookupValue tmpLV in reportNameLookupsCollection)
            {
                tmpRPI = new RadPanelItem();
                tmpRPI.Text = tmpLV.Extra;
                tmpRPI.Value = tmpLV.Valdesc;
                tmpRPI.Style.Add( HtmlTextWriterStyle.FontSize, "10pt" );
                rpi.Items.Add( tmpRPI );
            }

        }

        /// <summary>
        /// Can be called from either "View" click or row double click
        /// </summary>
        /// <param name="dataItem"></param>
        private void OpenItemInWindow( GridDataItem dataItem )
        {
            string popsIntId = null;
            string facilityName = null;
            string aspenIntID = null;
            string programID = null;
            string stateID = null;

            switch ( CurrentGridType )
            {
                case "PROGRAM":
                    if ( null != dataItem )
                    {
                        popsIntId = dataItem["PopsIntID"].Text;
                        facilityName = dataItem["FacilityName"].Text;
                        aspenIntID = dataItem["AspenIntID"].Text;
                        programID = dataItem["ProgramID"].Text;
                        stateID = dataItem["StateID"].Text;

                        // set session variables
                        Session["ProviderPOPSINTID"] = popsIntId;
                        Session["FacilityName"] = facilityName;
                        Session["AspenIntID"] = aspenIntID;
                        Session["ProgramID"] = programID;
                        Session["StateID"] = stateID;

                        //Response.Redirect( "~/DHH/StateFacilityPage.aspx" );

                        RadWin1.NavigateUrl = "~/DHH/StateFacilityPage.aspx";
                        RadWin1.Title = "Provider Details : " + facilityName + " (" + stateID + ")";
                    }
                    RadWin1.InitialBehaviors = WindowBehaviors.Maximize;
                    break;
                case "PROCESS":
                    if ( null != dataItem )
                    {
                        popsIntId = dataItem["PopsIntID"].Text;
                        facilityName = dataItem["FacilityName"].Text;
                        aspenIntID = dataItem["AspenIntID"].Text;
                        programID = dataItem["ProgramID"].Text;
                        stateID = dataItem["StateID"].Text;

                        // set session variables
                        Session["ProviderPOPSINTID"] = popsIntId;
                        Session["FacilityName"] = facilityName;
                        Session["AspenIntID"] = aspenIntID;
                        Session["ProgramID"] = programID;
                        Session["StateID"] = stateID;

                        RadWin1.NavigateUrl = "~/DHH/StateFacilityPage.aspx";
                        RadWin1.Title = "Provider Details : " + facilityName + " (" + stateID + ")";
                    }
                    RadWin1.InitialBehaviors = WindowBehaviors.Maximize;
                    break;
                case "LETTER OF INTENT":
                    if ( Session["Type_LOI"].ToString().Equals( "MATCH" ) && null != dataItem )
                    {
                        RadWin1.NavigateUrl = "~/DHH/MatchLOIPage.aspx?loiid=" + Session["LOI_ID"].ToString();
                        RadWin1.Title = "Match Letter of Intent: " + Session["LOI_ID"].ToString();
                    }
                    else
                    {
                        RadWin1.NavigateUrl = "~/DHH/ViewEditLOIPage.aspx";
                        RadWin1.Title = "Tracking ID: " + Session["LOI_ID"].ToString();
                    }
                    RadWin1.InitialBehaviors = WindowBehaviors.Maximize;
                    break;
                case "IDR":
                    string IDRId = "";

                    if ( Session["idrid"].ToString() != "0" && Session["idrid"] != null )
                        IDRId = Session["idrid"].ToString();

                    RadWin1.NavigateUrl = "~/DHH/IDRDetails.aspx";
                    RadWin1.Title = "IDR Details : " + IDRId;
                    RadWin1.InitialBehaviors = WindowBehaviors.Maximize;
                    break;
                case "ACCOUNTING":
                    if ( null != dataItem )
                    {
                        Session["CheckLogID"] = dataItem["BillingID"].Text;
                        
                        if ( dataItem["StateID"].Text.Equals("&nbsp;") )
                            Session["CheckLogStateID"] = "";
                        else
                            Session["CheckLogStateID"] = dataItem["StateID"].Text;
                        
                        if ( !dataItem["ApplicationID"].Text.Equals( "&nbsp;" ) )
                            Session["CheckLogFormType"] = "APPLICATION";
                        else
                            Session["CheckLogFormType"] = "OTHER";

                        RadWin1.Title = "Edit Check Log Entry";
                    }
                    else
                    {
                        Session["CheckLogID"] = "";
                        Session["CheckLogStateID"] = "";
                        RadWin1.Title = "New Check Log Entry";
                    }

                    if ( CurrentSelectKey.Equals( "APPLICATION" ) )
                    {
                        Session["CheckLogFormType"] = "APPLICATION";
                        RadWin1.Title += " - Application";
                    }
                    else
                    {
                        Session["CheckLogFormType"] = "OTHER";
                        RadWin1.Title += " - Other";
                    }

                    RadWin1.NavigateUrl = "~/Common/EditForm/CheckLogForm.aspx";
                    RadWin1.Behaviors = WindowBehaviors.Move;
                    break;
                default:
                    break;
            }

            RadWin1.VisibleStatusbar = false;
            RadWin1.VisibleOnPageLoad = true;
            RadWin1.Height = Unit.Pixel( 390 );
            RadWin1.Width = Unit.Pixel( 500 );
           
        }
        
        /// <summary>
        /// Reset the Session variables used on the State forms
        /// </summary>
        private void ResetSessionVariables()
        {
            Session["ProviderPOPSINTID"] = "";
            Session["FacilityName"] = "";
            Session["AspenIntID"] = "";
            Session["ProgramID"] = "";
            Session["StateID"] = "";
            Session["CurrentProvider"] = null;      // value gets set in the Facility control
            Session["CurrentAppProvider"] = null;   // value gets set in the Facility control
            Session["ServiceLookups"] = null;       // list changes according to Provider type
            Session["CheckLogID"] = null;
            Session["CheckLogStateID"] = null;
            Session["CheckLogFormType"] = null;
            Session["CheckLogDateFilter"] = null;
        }

        private new ATG.Security.User User
        {
            get { return (ATG.Security.User)Session["User"]; }
        }

        /// <summary>
        /// Access the REPORT_NAME lookup values collection
        /// </summary>
        private BO_LookupValues ReportNameLookups
        {
            get
            {
                BO_LookupValues tmpLkups;
                if (Session["ReportNameLookups"] == null)
                {
                    tmpLkups = BO_LookupValue.SelectByField(BO_LookupValueFields.LookupKey, "REPORT_NAME");
                    ReportNameLookups = tmpLkups;
                }
                else
                    tmpLkups = (BO_LookupValues)Session["ReportNameLookups"];

                return tmpLkups;
            }
            set
            {
                Session["ReportNameLookups"] = value;
            }
        }

        private DataTable grdDataSource
        {
            get
            {
                return (DataTable) Session["grdDataSource"];
            }
            set
            {
                Session["grdDataSource"] = value;
            }
        }

        private String CurrentGridType
        {
            get
            {
                return (String) ViewState["CurrentGridType"];
            }
            set
            {
                ViewState["CurrentGridType"] = value;
            }
        }

        private String CurrentSelectKey
        {
            get
            {
                return (String) ViewState["CurrentSelectKey"];
            }
            set
            {
                ViewState["CurrentSelectKey"] = value;
            }
        }

        private String CurrentDateFilter
        {
            get
            {
                return (String)ViewState["CurrentDateFilter"];
            }
            set
            {
                ViewState["CurrentDateFilter"] = value;
            }
        } 

        private String CurrentFilterExpression
        {
            get
            {
                return (String) ViewState["CurrentFilterExpression"];
            }
            set
            {
                ViewState["CurrentFilterExpression"] = value;
            }
        }

        private System.Collections.Hashtable MessagesChecked
        {

            get
            {
                object res = ViewState["_mc"];
                if ( res == null )
                {
                    res = new System.Collections.Hashtable();
                    ViewState["_mc"] = res;
                }

                return (System.Collections.Hashtable) res;
            }

            set { ViewState["_mc"] = value; }
        }

        #endregion

    }
}
