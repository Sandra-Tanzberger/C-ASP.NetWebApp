using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ATG;
using ATG.BusinessObject;
using ATG.Utilities.Data;
using Telerik.Web.UI;
using ATG.Security;

namespace AppControl
{
    public partial class BillingHistory : System.Web.UI.UserControl
    {
        public string dispBalance = "";

        protected void Page_PreRender(object sender, EventArgs e)
        {
            GridCommandItem cmdItem = (GridCommandItem)grdBilling.MasterTableView.GetItems(GridItemType.CommandItem)[0];
            LinkButton btnDelete = (LinkButton)cmdItem.FindControl("btnDelete");
            LinkButton btnUnlink = (LinkButton)cmdItem.FindControl("btnUnlink");

            if (User.HasAccess("PBG"))
            {
                //if(!CurrentAppProvider.ApplicationAction.Equals("4"))//needs later review, application set in session only appears to be the most recent, so previous applications are not be accessed correctly at this level
                    btnDelete.Visible = true;
                    btnUnlink.Visible = true;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //AllowEdit = true;
                // set the default values for the Grid's properties
                SetDefaultProperties();
                _InitializeGrid(grdBilling, BillingKeyType);
                if (!(BO_Application.SelectOne(new BO_ApplicationPrimaryKey((Convert.ToDecimal(BillingKey)))).ApplicationStatus.Equals("4")) || User.HasAccess("PBG"))
                {
                    LinkButton linkunassigned = (LinkButton)grdBilling.MasterTableView.FindControlRecursive("btnLinkUnassignPayment");
                    linkunassigned.Enabled = true;
                    LinkButton linkunassignedinitials = (LinkButton)grdBilling.MasterTableView.FindControlRecursive("btnLinkUnassignPaymentInitials");
                    linkunassignedinitials.Enabled = true;
                }

            }
        }

        /// <summary>
        /// Set the datasource for the Provider's grid
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void grdBilling_ItemCommand(object source, GridCommandEventArgs e)
        {
            if (e.CommandName == "linkBilling")
            {
                Session["LinkAppId"] = BillingKey;
    
                RadWindow newwindow = new RadWindow();
                newwindow.ID = "RadWindow1";
                newwindow.NavigateUrl = "~/Common/LinkPayment.aspx?lt=ni";
                newwindow.VisibleStatusbar = false;
                newwindow.VisibleOnPageLoad = true;
                //newwindow.Height = Unit.Pixel(525);
                //newwindow.Width = Unit.Pixel(545);
                newwindow.Title = "Link Payments";
                LinkPaymentRadWinMan.Windows.Add(newwindow);
                LinkPaymentRadWinMan.Style.Add("z-index", "9999");
                LinkPaymentRadWinMan.Behaviors = WindowBehaviors.None;
                LinkPaymentRadWinMan.InitialBehaviors = WindowBehaviors.Maximize;
                
            }

            if (e.CommandName == "linkBillinginitials")
            {
                Session["LinkAppId"] = BillingKey;

                RadWindow newwindow = new RadWindow();
                newwindow.ID = "RadWindow1";
                newwindow.NavigateUrl = "~/Common/LinkPayment.aspx?lt=i";
                newwindow.VisibleStatusbar = false;
                newwindow.VisibleOnPageLoad = true;
                //newwindow.Height = Unit.Pixel(525);
                //newwindow.Width = Unit.Pixel(545);
                newwindow.Title = "Link Payments";
                LinkPaymentRadWinMan.Windows.Add(newwindow);
                LinkPaymentRadWinMan.Style.Add("z-index", "9999");
                LinkPaymentRadWinMan.Behaviors = WindowBehaviors.None;
                LinkPaymentRadWinMan.InitialBehaviors = WindowBehaviors.Maximize;

            }

            if (e.CommandName == "unlink")
            {
                Session["LinkAppId"] = BillingKey;
                string billingdetailsid = "";

                if (grdBilling.SelectedItems.Count == 1)
                {
             
                    foreach (GridDataItem item in grdBilling.SelectedItems)
                    {
                         billingdetailsid = item["BillingDetailID"].Text;
                    }

                    RadWindow newwindow = new RadWindow();
                    newwindow.ID = "RadWindow1";
                    newwindow.NavigateUrl = "~/Common/LinkPayment.aspx?lt=u&bdid=" + billingdetailsid;
                    newwindow.VisibleStatusbar = false;
                    newwindow.VisibleOnPageLoad = true;
                    newwindow.Title = "Unlink Payments";
                    LinkPaymentRadWinMan.Windows.Add(newwindow);
                    LinkPaymentRadWinMan.Style.Add("z-index", "9999");
                    LinkPaymentRadWinMan.Behaviors = WindowBehaviors.None;
                    LinkPaymentRadWinMan.InitialBehaviors = WindowBehaviors.Maximize;
                }
            }

            if (e.CommandName.Equals("Delete"))
            {
                if (grdBilling.SelectedItems.Count > 0)
                {
                    foreach (Telerik.Web.UI.GridDataItem item in grdBilling.SelectedItems)
                    {
                        BO_BillingDetail.Delete(new BO_BillingDetailPrimaryKey(Convert.ToDecimal(item["BillingDetailID"].Text)));
                    }
                }
            }
        }
        protected void grdBilling_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            int tmpRowCnt = 0;
            if (null != grdDataSource)
            {
                //tmpRowCnt = grdDataSource.Rows.Count > 0 ? grdDataSource.Rows.Count + 2 : 3;
                //grdBilling.Height = Unit.Pixel((30 * tmpRowCnt) + 10);
                grdBilling.DataSource = (DataTable)grdDataSource;


            }
        }


        /// <summary>
        /// Set the default values for the grid's most used properties
        /// </summary>
        private void SetDefaultProperties()
        {
            grdBilling.AutoGenerateColumns = false;
            grdBilling.AllowPaging = false;
            grdBilling.AllowFilteringByColumn = false;
            grdBilling.AllowSorting = true;
            grdBilling.GridLines = GridLines.None;
        }

        private void _InitializeGrid(RadGrid inGridToInit, string inGridType)
        {
            grdBilling.AllowFilteringByColumn = false;
            grdBilling.EnableViewState = true;
            grdBilling.ShowHeader = true;
            grdBilling.AllowPaging = false;
            grdBilling.AllowSorting = false;
            grdBilling.ClientSettings.Selecting.AllowRowSelect = true;
            grdBilling.ClientSettings.Scrolling.AllowScroll = true;
            grdBilling.ClientSettings.Scrolling.UseStaticHeaders = true;
            grdBilling.ClientSettings.Resizing.AllowColumnResize = true;
            grdBilling.RegisterWithScriptManager = true;

            int tmpRowCnt = 0;

            switch (inGridType)
            {
                case "APPLICATION_ID":
                    //tmpRowCnt = grdDataSource.Rows.Count > 0 ? grdDataSource.Rows.Count + 2 : 3;
                    //grdBilling.Height = Unit.Pixel( ( 30 * tmpRowCnt ) + 10 );
                    
                    if ( AllowEdit )
                        grdBilling.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.Top;
                    else
                        grdBilling.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;

                    if ( grdBilling.Columns.Count < 1 )
                        BuildAppBillingGridColumns();

                    grdBilling.DataSource = grdDataSource;
                    grdBilling.DataBind();

                    tblSummary.Style["display"] = "";
                    if (grdBilling.Items.Count > 0)
                    {
                        decimal charges = !string.IsNullOrEmpty(grdBilling.Items[0]["TotalCharges"].Text.Replace("&nbsp;", "")) ? Convert.ToDecimal(grdBilling.Items[0]["TotalCharges"].Text.Replace("&nbsp;", "")) : 0;
                        decimal payments = !string.IsNullOrEmpty(grdBilling.Items[0]["TotalPayments"].Text.Replace("&nbsp;", "")) ? Convert.ToDecimal(grdBilling.Items[0]["TotalCharges"].Text.Replace("&nbsp;", "")) : 0;
                        decimal refunds = !string.IsNullOrEmpty(grdBilling.Items[0]["TotalRefunds"].Text.Replace("&nbsp;", "")) ? Convert.ToDecimal(grdBilling.Items[0]["TotalCharges"].Text.Replace("&nbsp;", "")) : 0;
                        decimal adjustments = !string.IsNullOrEmpty(grdBilling.Items[0]["TotalAdjustments"].Text.Replace("&nbsp;", "")) ? Convert.ToDecimal(grdBilling.Items[0]["TotalAdjustments"].Text.Replace("&nbsp;", "")) : 0;

                        decimal balance = ((charges - payments) + refunds) + adjustments;

                        txtCharges.Text = grdBilling.Items[0]["TotalCharges"].Text.Replace("&nbsp;", "");
                        txtPayments.Text = grdBilling.Items[0]["TotalPayments"].Text.Replace("&nbsp;", "");
                        txtRefunds.Text = grdBilling.Items[0]["TotalRefunds"].Text.Replace("&nbsp;", "");
                        txtAdjustments.Text = grdBilling.Items[0]["TotalAdjustments"].Text.Replace("&nbsp;", "");
                        txtBeginningBalance.Text = BO_Billing.SelectPreviousBillingRecord(new BO_ProviderPrimaryKey(CurrentProvider.PopsIntID), new BO_ApplicationPrimaryKey(CurrentAppProvider.ApplicationID)).Balance.ToString();
                        txtBalance.Text = dispBalance;// grdBilling.Items[0]["Balance"].Text.Replace( "&nbsp;", "" ); //balance.ToString();
                    }

                    break;
                case "POPS_INT_ID":
                    inGridToInit.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    if ( grdBilling.Columns.Count < 1 )
                        BuildProvBillingGridColumns();

                    //tmpRowCnt = grdDataSource.Rows.Count > 0 ? grdDataSource.Rows.Count + 2 : 3;
                    //grdBilling.Height = Unit.Pixel( ( 30 * tmpRowCnt ) + 10 );
                    grdBilling.DataSource = grdDataSource;
                    grdBilling.DataBind();
                    tblSummary.Style["display"] = "none";
                    break;
            }

        }

        protected void grdBilling_ItemCreated(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            BillingInsertForm tmpEF = (BillingInsertForm)e.Item.FindControl(GridEditFormItem.EditFormUserControlID);

            if (tmpEF != null)
            {
                //if ((e.Item is GridEditFormInsertItem) && e.Item.IsInEditMode)
                //{
                //    int tmpRowCnt = grdDataSource.Rows.Count > 0 ? grdDataSource.Rows.Count + 2 : 3;

                //    grdBilling.Height = Unit.Pixel((30 * tmpRowCnt) + 125);
                //}

                //GridEditFormItem editedItem = e.Item as GridEditFormItem;
                ////OwnerEditForm tmpOEF = (OwnerEditForm) e.Item.FindControlRecursive( GridEditFormItem.EditFormUserControlID );

                ////SMM TODO - This is a hack at this point as I have been unable to find a way to determine if the cancel button
                ////was clicked and abort processing on the edit form.  
                //if ( ( e.Item is GridEditFormInsertItem ) && !editedItem["ApplicationID"].Text.Contains( "&nbsp;" ) )
                //{
                    tmpEF.BillingKey = BillingKey;
                    tmpEF.BillingKeyType = BillingKeyType;
                    //tmpEF.ApplicationID = editedItem["ApplicationID"].Text;
                    tmpEF.LoadCombos();
                //}
            }

            if (grdBilling.Items.Count > 0 && BillingKeyType == "APPLICATION_ID")
            {
                decimal charges = !string.IsNullOrEmpty(grdBilling.Items[0]["TotalCharges"].Text.Replace("&nbsp;", "")) ? Convert.ToDecimal(grdBilling.Items[0]["TotalCharges"].Text.Replace("&nbsp;", "")) : 0;
                decimal payments = !string.IsNullOrEmpty(grdBilling.Items[0]["TotalPayments"].Text.Replace("&nbsp;", "")) ? Convert.ToDecimal(grdBilling.Items[0]["TotalCharges"].Text.Replace("&nbsp;", "")) : 0;
                decimal refunds = !string.IsNullOrEmpty(grdBilling.Items[0]["TotalRefunds"].Text.Replace("&nbsp;", "")) ? Convert.ToDecimal(grdBilling.Items[0]["TotalCharges"].Text.Replace("&nbsp;", "")) : 0;
                decimal adjustments = !string.IsNullOrEmpty( grdBilling.Items[0]["TotalAdjustments"].Text.Replace( "&nbsp;", "" ) ) ? Convert.ToDecimal( grdBilling.Items[0]["TotalAdjustments"].Text.Replace( "&nbsp;", "" ) ) : 0;

                decimal balance = ( ( charges - payments ) + refunds ) + adjustments;

                txtCharges.Text = grdBilling.Items[0]["TotalCharges"].Text.Replace("&nbsp;", "");
                txtPayments.Text = grdBilling.Items[0]["TotalPayments"].Text.Replace("&nbsp;", "");
                txtRefunds.Text = grdBilling.Items[0]["TotalRefunds"].Text.Replace("&nbsp;", "");
                txtAdjustments.Text = grdBilling.Items[0]["TotalAdjustments"].Text.Replace( "&nbsp;", "" );
                txtBalance.Text = dispBalance; // grdBilling.Items[0]["Balance"].Text.Replace( "&nbsp;", "" ); //balance.ToString();
            }
            else
            {
                txtCharges.Text = "0.00";
                txtPayments.Text = "0.00";
                txtRefunds.Text = "0.00";
                txtAdjustments.Text = "0.00";
                txtBalance.Text = "0.00";
            }

        }

        protected void grdBilling_InsertCommand(object source, GridCommandEventArgs e)
        {
            GridEditableItem editedItem = e.Item as GridEditableItem;
            BillingInsertForm userControl = (BillingInsertForm)e.Item.FindControl(GridEditFormItem.EditFormUserControlID);

            //Create new row in the DataSource
            BO_BillingDetail newRow = new BO_BillingDetail();

            if (!string.IsNullOrEmpty(userControl.AppID))
            {
                BO_Billings bobs = BO_Billing.SelectByField("APPLICATION_ID", userControl.AppID);
                if (bobs == null || bobs.Count < 1)
                {
                    BO_Billing bob = new BO_Billing();
                    bobs = new BO_Billings();
                    decimal tmpAppID = Convert.ToDecimal( userControl.BillingKey );

                    BO_Application tmpBA = BO_Application.SelectOne( new BO_ApplicationPrimaryKey( tmpAppID ) );
                    bob.PopsIntID = tmpBA.PopsIntID;
                    bob.ApplicationID = tmpAppID;
                    bob.PriceModelID = 999;

                    bob.InsertWithDefaultValues( true );

                    bobs.Add( bob );
                    
                }

                if ( bobs != null && bobs.Count > 0 )
                {
                    newRow.BillingID = bobs[0].BillingID;
                    newRow.TypeBilling = userControl.TypeBilling;
                    if (userControl.TypeFee != "99")
                    {
                        newRow.TypeFee = userControl.TypeFee;
                        foreach (BO_LookupValue bolv in FeeTypeLookups)
                        {
                            if (bolv.LookupVal == userControl.TypeFee)
                            {
                                newRow.Comment = CommonFunc.ConvertToTitleCase(bolv.Valdesc) + " ";
                                newRow.Comment += CommonFunc.ConvertToTitleCase(_getBillingTypeText(userControl.TypeBilling));
                            }
                        }
                    }
                    else 
                    {
                        newRow.TypeFee = userControl.TypeFee;
                        newRow.Comment = userControl.Comments;
                    }

                    newRow.TransactionID = userControl.TransactionID;
                    newRow.TransactionDate = DateTime.Now;
                    newRow.PayMode = "2"; //physical
                    newRow.TransactionStatus = "1"; //success

                    if ( null != userControl.Amount && userControl.Amount.Length > 0 )
                        newRow.Amount = Convert.ToDecimal(userControl.Amount);
                    else
                        newRow.Amount = 0;

                    newRow.InsertWithDefaultValues(false);
                }
            }
                
        }        
        
        /// <summary>
        /// Define the columns for the Application Billing grid
        /// </summary>
        private void BuildAppBillingGridColumns()
        {
            GridBoundColumn col1 = new GridBoundColumn();
            grdBilling.MasterTableView.Columns.Add( col1 );
            col1.UniqueName = "BillingDetailID";
            col1.DataField = "BillingDetailID";
            col1.HeaderText = "ID";
            col1.Visible = true;
            col1.HeaderStyle.Width = Unit.Percentage( 10 );

            GridBoundColumn col2 = new GridBoundColumn();
            grdBilling.MasterTableView.Columns.Add(col2);
            col2.UniqueName = "TypeBillingDesc";
            col2.DataField = "TypeBillingDesc";
            col2.HeaderText = "Billing Type";
            col2.Visible = true;
            col2.HeaderStyle.Width = Unit.Percentage(10);

            GridBoundColumn col3 = new GridBoundColumn();
            grdBilling.MasterTableView.Columns.Add(col3);
            col3.UniqueName = "TypeFeeDesc";
            col3.DataField = "TypeFeeDesc";
            col3.HeaderText = "Fee Type";
            col3.Visible = true;
            col3.HeaderStyle.Width = Unit.Percentage(10);

            GridBoundColumn col4 = new GridBoundColumn();
            grdBilling.MasterTableView.Columns.Add(col4);
            col4.UniqueName = "TransactionStatus";
            col4.DataField = "TransactionStatus";
            col4.HeaderText = "Trans Status";
            col4.Visible = true;
            col4.HeaderStyle.Width = Unit.Percentage(10);

            GridBoundColumn col5 = new GridBoundColumn();
            grdBilling.MasterTableView.Columns.Add(col5);
            col5.UniqueName = "Amount";
            col5.DataField = "Amount";
            col5.HeaderText = "Amount";
            col5.Visible = true;
            col5.DataFormatString = "{0:C2}";
            col5.HeaderStyle.Width = Unit.Percentage(10);            

            GridBoundColumn col6 = new GridBoundColumn();
            grdBilling.MasterTableView.Columns.Add(col6);
            col6.UniqueName = "TransactionID";
            col6.DataField = "TransactionID";
            col6.HeaderText = "Trans ID";
            col6.Visible = true;
            col6.HeaderStyle.Width = Unit.Percentage(15);

            GridBoundColumn col7 = new GridBoundColumn();
            grdBilling.MasterTableView.Columns.Add(col7);
            col7.UniqueName = "TransactionDate";
            col7.DataField = "TransactionDate";
            col7.HeaderText = "Date";
            col7.Visible = true;
            col7.HeaderStyle.Width = Unit.Percentage(10);

            GridBoundColumn col8 = new GridBoundColumn();
            grdBilling.MasterTableView.Columns.Add(col8);
            col8.UniqueName = "Comment";
            col8.DataField = "Comment";
            col8.HeaderText = "Comment";
            col8.Visible = true;
            col8.HeaderStyle.Width = Unit.Percentage(25);

            GridBoundColumn col9 = new GridBoundColumn();
            grdBilling.MasterTableView.Columns.Add(col9);
            col9.UniqueName = "Revised";
            col9.DataField = "Revised";
            col9.HeaderText = "";
            col9.Visible = false;
            col9.HeaderStyle.Width = Unit.Percentage(0);

            GridBoundColumn col10 = new GridBoundColumn();
            grdBilling.MasterTableView.Columns.Add(col10);
            col10.UniqueName = "TotalCharges";
            col10.DataField = "TotalCharges";
            col10.HeaderText = "";
            col10.Visible = false;
            col10.HeaderStyle.Width = Unit.Percentage(0);

            GridBoundColumn col11 = new GridBoundColumn();
            grdBilling.MasterTableView.Columns.Add(col11);
            col11.UniqueName = "TotalPayments";
            col11.DataField = "TotalPayments";
            col11.HeaderText = "";
            col11.Visible = false;
            col11.HeaderStyle.Width = Unit.Percentage(0);

            GridBoundColumn col12 = new GridBoundColumn();
            grdBilling.MasterTableView.Columns.Add(col12);
            col12.UniqueName = "TotalRefunds";
            col12.DataField = "TotalRefunds";
            col12.HeaderText = "";
            col12.Visible = false;
            col12.HeaderStyle.Width = Unit.Percentage(0);

            GridBoundColumn col13 = new GridBoundColumn();
            grdBilling.MasterTableView.Columns.Add(col13);
            col13.UniqueName = "Balance";
            col13.DataField = "Balance";
            col13.HeaderText = "";
            col13.Visible = false;
            col13.HeaderStyle.Width = Unit.Percentage(0);

            GridBoundColumn col14 = new GridBoundColumn();
            grdBilling.MasterTableView.Columns.Add( col14 );
            col14.UniqueName = "TotalAdjustments";
            col14.DataField = "TotalAdjustments";
            col14.HeaderText = "";
            col14.Visible = false;
            col14.HeaderStyle.Width = Unit.Percentage( 0 );

        }

        /// <summary>
        /// Define the columns for the Providers-Billing grid
        /// </summary>
        private void BuildProvBillingGridColumns()
        {
            GridBoundColumn tmpCol = new GridBoundColumn();
            grdBilling.MasterTableView.Columns.Add( tmpCol );
            tmpCol.UniqueName = "BillingDetailID";
            tmpCol.DataField = "BillingDetailID";
            tmpCol.HeaderText = "ID";
            tmpCol.Visible = true;
            tmpCol.HeaderStyle.Width = Unit.Percentage( 10 );

            tmpCol = new GridBoundColumn();
            grdBilling.MasterTableView.Columns.Add( tmpCol );
            tmpCol.UniqueName = "ApplicationID";
            tmpCol.DataField = "ApplicationID";
            tmpCol.HeaderText = "App Id";
            tmpCol.Visible = true;
            tmpCol.HeaderStyle.Width = Unit.Percentage( 5 );

            tmpCol = new GridBoundColumn();
            grdBilling.MasterTableView.Columns.Add( tmpCol );
            tmpCol.UniqueName = "TypeBillingDesc";
            tmpCol.DataField = "TypeBillingDesc";
            tmpCol.HeaderText = "Billing Type";
            tmpCol.Visible = true;
            tmpCol.HeaderStyle.Width = Unit.Percentage( 10 );

            tmpCol = new GridBoundColumn();
            grdBilling.MasterTableView.Columns.Add( tmpCol );
            tmpCol.UniqueName = "TypeFeeDesc";
            tmpCol.DataField = "TypeFeeDesc";
            tmpCol.HeaderText = "Fee Type";
            tmpCol.Visible = true;
            tmpCol.HeaderStyle.Width = Unit.Percentage( 10 );

            tmpCol = new GridBoundColumn();
            grdBilling.MasterTableView.Columns.Add( tmpCol );
            tmpCol.UniqueName = "TransactionStatus";
            tmpCol.DataField = "TransactionStatus";
            tmpCol.HeaderText = "Trans Status";
            tmpCol.Visible = true;
            tmpCol.HeaderStyle.Width = Unit.Percentage( 10 );

            tmpCol = new GridBoundColumn();
            grdBilling.MasterTableView.Columns.Add( tmpCol );
            tmpCol.UniqueName = "Amount";
            tmpCol.DataField = "Amount";
            tmpCol.HeaderText = "Amount";
            tmpCol.DataFormatString = "{0:C2}";
            tmpCol.Visible = true;
            tmpCol.HeaderStyle.Width = Unit.Percentage( 10 );

            tmpCol = new GridBoundColumn();
            grdBilling.MasterTableView.Columns.Add( tmpCol );
            tmpCol.UniqueName = "TransactionID";
            tmpCol.DataField = "TransactionID";
            tmpCol.HeaderText = "Trans ID";
            tmpCol.Visible = true;
            tmpCol.HeaderStyle.Width = Unit.Percentage( 15 );

            tmpCol = new GridBoundColumn();
            grdBilling.MasterTableView.Columns.Add( tmpCol );
            tmpCol.UniqueName = "TransactionDate";
            tmpCol.DataField = "TransactionDate";
            tmpCol.HeaderText = "Date";
            tmpCol.Visible = true;
            tmpCol.HeaderStyle.Width = Unit.Percentage( 10 );

            tmpCol = new GridBoundColumn();
            grdBilling.MasterTableView.Columns.Add( tmpCol );
            tmpCol.UniqueName = "Comment";
            tmpCol.DataField = "Comment";
            tmpCol.HeaderText = "Comment";
            tmpCol.Visible = true;
            tmpCol.HeaderStyle.Width = Unit.Percentage( 20 );

            tmpCol = new GridBoundColumn();
            grdBilling.MasterTableView.Columns.Add( tmpCol );
            tmpCol.UniqueName = "Revised";
            tmpCol.DataField = "Revised";
            tmpCol.HeaderText = "";
            tmpCol.Visible = false;
            tmpCol.HeaderStyle.Width = Unit.Percentage( 0 );

            tmpCol = new GridBoundColumn();
            grdBilling.MasterTableView.Columns.Add( tmpCol );
            tmpCol.UniqueName = "TotalCharges";
            tmpCol.DataField = "TotalCharges";
            tmpCol.HeaderText = "";
            tmpCol.Visible = false;
            tmpCol.HeaderStyle.Width = Unit.Percentage( 0 );

            tmpCol = new GridBoundColumn();
            grdBilling.MasterTableView.Columns.Add( tmpCol );
            tmpCol.UniqueName = "TotalPayments";
            tmpCol.DataField = "TotalPayments";
            tmpCol.HeaderText = "";
            tmpCol.Visible = false;
            tmpCol.HeaderStyle.Width = Unit.Percentage( 0 );

            tmpCol = new GridBoundColumn();
            grdBilling.MasterTableView.Columns.Add( tmpCol );
            tmpCol.UniqueName = "TotalRefunds";
            tmpCol.DataField = "TotalRefunds";
            tmpCol.HeaderText = "";
            tmpCol.Visible = false;
            tmpCol.HeaderStyle.Width = Unit.Percentage( 0 );

            tmpCol = new GridBoundColumn();
            grdBilling.MasterTableView.Columns.Add( tmpCol );
            tmpCol.UniqueName = "TotalAdjustments";
            tmpCol.DataField = "TotalAdjustments";
            tmpCol.HeaderText = "";
            tmpCol.Visible = false;
            tmpCol.HeaderStyle.Width = Unit.Percentage( 0 );
        
        }

        private DataTable _getBillingGridInitTable()
        {
            DataTable tmpDTbl = new DataTable();
            DataColumn tmpDCol = null;

            tmpDCol = new DataColumn( "BillingDetailID" );
            tmpDTbl.Columns.Add( tmpDCol );
            tmpDCol = new DataColumn( "ApplicationID" );
            tmpDTbl.Columns.Add( tmpDCol );
            tmpDCol = new DataColumn( "TypeBillingDesc" );
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("TypeFeeDesc");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("TransactionStatus");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("Amount");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("TransactionID");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("TransactionDate");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("Comment");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("Revised");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("TotalCharges");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("TotalPayments");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("TotalRefunds");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("Balance");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn( "TotalAdjustments" );
            tmpDTbl.Columns.Add( tmpDCol );
            
            return tmpDTbl;
        }

        private User User
        {
            get { return (User)Session["User"]; }
        }

        private BO_Provider CurrentProvider
        {
            get
            {
                return Session["CurrentProvider"] == null ? null : (BO_Provider) Session["CurrentProvider"];
            }

        }

        private string _getBillingTypeText(string inLookupVal)
        {
            string tmpStr = "";

            foreach (BO_LookupValue boLV in BillingTypeLookups)
            {
                if (boLV.LookupVal.Equals(inLookupVal))
                {
                    tmpStr = CommonFunc.ConvertToTitleCase(boLV.Valdesc);
                    break;
                }
            }


            return tmpStr;
        }

        private string _getFeeTypeText(string inLookupVal)
        {
            string tmpStr = "";

            foreach (BO_LookupValue boLV in FeeTypeLookups)
            {
                if (boLV.LookupVal.Equals(inLookupVal))
                {
                    tmpStr = CommonFunc.ConvertToTitleCase(boLV.Valdesc);
                    break;
                }
            }


            return tmpStr;
        }

        private BO_LookupValues BillingTypeLookups
        {
            get
            {
                BO_LookupValues retLkups = new BO_LookupValues();
                if (Session["BillingTypeLookups"] == null)
                {
                    BO_LookupValues tmpLkups = BO_LookupValue.SelectByField(BO_LookupValueFields.LookupKey, "TYPE_BILLING");
                    foreach (BO_LookupValue tmpLV in tmpLkups)
                    {
                        retLkups.Add(tmpLV);

                    }
                }
                else
                    retLkups = (BO_LookupValues)Session["BillingTypeLookups"];

                return retLkups;
            }
            set
            {
                Session["BillingTypeLookups"] = value;
            }
        }

        private BO_LookupValues FeeTypeLookups
        {
            get
            {
                BO_LookupValues retLkups = new BO_LookupValues();
                if (Session["FeeTypeLookups"] == null)
                {
                    BO_LookupValues tmpLkups = BO_LookupValue.SelectByField(BO_LookupValueFields.LookupKey, "TYPE_FEE");
                    foreach (BO_LookupValue tmpLV in tmpLkups)
                    {
                        retLkups.Add(tmpLV);

                    }
                }
                else
                    retLkups = (BO_LookupValues)Session["FeeTypeLookups"];

                return retLkups;
            }
            set
            {
                Session["FeeTypeLookups"] = value;
            }
        }

        private DataTable grdDataSource
        {
            get
            {
                //DataTable retTable = (DataTable)ViewState["grdDataSource"];
                decimal tmpBalance = 0;

                //if (retTable == null)
                //{
                    DataTable retTable = _getBillingGridInitTable();

                    switch (BillingKeyType)
                    {
                        case "APPLICATION_ID":
                            BO_Billings boBillings = null;
                            if (!string.IsNullOrEmpty(BillingKey))
                            {
                                BO_Application boapp = new BO_Application();
                                boapp.LoadFullApplication(Convert.ToDecimal(BillingKey));

                                if ( boapp.BusinessProcessID.Equals( "1" ) || boapp.ApplicationAction.Equals("4") )
                                    AllowEdit = false;
                                else
                                    AllowEdit = true;
                                

                                // get rows for the specified application Id
                                boBillings = boapp.BO_BillingsApplicationID;
                            }

                            if (boBillings != null && boBillings.Count > 0)
                            {
                                foreach (BO_Billing boB in boBillings)
                                {
                                    boB.BO_BillingDetailsBillingID.Sort( "BillingDetailID DESC" );
                                    dispBalance = boB.Balance.Value.ToString();

                                    foreach (BO_BillingDetail boBD in boB.BO_BillingDetailsBillingID)
                                    {
                                        if (boBD.Revised != "1")
                                        {
                                            DataRow tmpDR = retTable.NewRow();
                                            //RS - 09/05/2013 - Issue# 17702/17692
                                            //string tmpTypeFeeDesc = null != boBD.TypeFee ? _getFeeTypeText( boBD.TypeFee.ToString() ) : "";
                                            string tmpTypeFeeDesc = null != boBD.TypeFee ? _getFeeTypeText(boBD.TypeFee.ToString()) : null;
                                            tmpDR["BillingDetailID"] = boBD.BillingDetailID;
                                            tmpDR["ApplicationID"] = boB.ApplicationID;
                                            tmpDR["TypeBillingDesc"] = null != boBD.TypeBilling ? _getBillingTypeText(boBD.TypeBilling.ToString()) : "";
                                            if ( null != tmpTypeFeeDesc )
                                            {
                                                if ( !boBD.TypeFee.ToString().Equals( "99" ) )
                                                    tmpDR["TypeFeeDesc"] = _getFeeTypeText( boBD.TypeFee.ToString() );
                                                else
                                                    tmpDR["TypeFeeDesc"] = "Other";

                                            } 
                                            tmpDR["TransactionStatus"] = ( null != boBD.TransactionStatus && boBD.TransactionStatus.Equals( "1" ) ) || null == boBD.TransactionStatus ? "Succeeded" : "Failed";
                                            tmpDR["Amount"] = boBD.Amount;
                                            tmpDR["TransactionID"] = boBD.TransactionID;
                                            tmpDR["TransactionDate"] = boBD.TransactionDate;
                                            tmpDR["Comment"] = boBD.Comment;
                                            tmpDR["Revised"] = boBD.Revised;
                                            tmpDR["TotalCharges"] = boB.TotalCharges;
                                            tmpDR["TotalPayments"] = boB.TotalPayments;
                                            tmpDR["TotalRefunds"] = boB.TotalRefunds;
                                            tmpDR["TotalAdjustments"] = boB.TotalAdjustments;
                                            tmpDR["Balance"] = boB.Balance;

                                            retTable.Rows.Add(tmpDR);
                                        }
                                    }
                                }
                            }

                            break;
                        case "POPS_INT_ID":
                            BO_Applications boApplications = null;
                            if (!string.IsNullOrEmpty(BillingKey))
                            {
                                // get rows for the specified Business Process Id
                                BO_ProviderPrimaryKey boProvPK = new BO_ProviderPrimaryKey(Convert.ToDecimal(BillingKey));
                                boApplications = BO_Application.SelectAllByForeignKeyPopsIntID(boProvPK);
                            }
                            if (boApplications != null && boApplications.Count > 0)
                            {
                                foreach (BO_Application boa in boApplications)
                                {                                    
                                    boa.LoadFullApplication(boa.ApplicationID.Value);
                                    if (boa.BO_BillingsApplicationID != null && boa.BO_BillingsApplicationID.Count > 0)
                                    {
                                        foreach (BO_Billing boB in boa.BO_BillingsApplicationID)
                                        {
                                            boB.BO_BillingDetailsBillingID.Sort("TransactionDate");
                                            foreach (BO_BillingDetail boBD in boB.BO_BillingDetailsBillingID)
                                            {
                                                if (boBD.Revised != "1")
                                                {
                                                    DataRow tmpDR = retTable.NewRow();
                                                    //RS - 09/05/2013 - Issue# 17702/17692
                                                    //string tmpTypeFeeDesc = null != boBD.TypeFee ? _getFeeTypeText( boBD.TypeFee.ToString() ) : "";
                                                    string tmpTypeFeeDesc = null != boBD.TypeFee ? _getFeeTypeText(boBD.TypeFee.ToString()) : null;
                                                    tmpDR["BillingDetailID"] = boBD.BillingDetailID;
                                                    tmpDR["ApplicationID"] = boB.ApplicationID;
                                                    tmpDR["TypeBillingDesc"] = null != boBD.TypeBilling ? _getBillingTypeText(boBD.TypeBilling.ToString()) : "";
                                                    if ( null != tmpTypeFeeDesc )
                                                    {
                                                        if ( !boBD.TypeFee.ToString().Equals( "99" ) )
                                                            tmpDR["TypeFeeDesc"] =  _getFeeTypeText( boBD.TypeFee.ToString() );
                                                        else
                                                            tmpDR["TypeFeeDesc"] =  "Other";

                                                    }
                                                    tmpDR["TransactionStatus"] = (null != boBD.TransactionStatus && boBD.TransactionStatus.Equals("1")) || null == boBD.TransactionStatus ? "Succeeded" : "Failed";
                                                    tmpDR["Amount"] = boBD.Amount;
                                                    tmpDR["TransactionID"] = boBD.TransactionID;
                                                    tmpDR["TransactionDate"] = boBD.TransactionDate;
                                                    tmpDR["Comment"] = boBD.Comment;
                                                    tmpDR["Revised"] = boBD.Revised;
                                                    tmpDR["TotalCharges"] = boB.TotalCharges;
                                                    tmpDR["TotalPayments"] = boB.TotalPayments;
                                                    tmpDR["TotalRefunds"] = boB.TotalRefunds;
                                                    tmpDR["TotalAdjustments"] = boB.TotalAdjustments;
                                                    tmpDR["Balance"] = boB.Balance;

                                                    retTable.Rows.Add(tmpDR);
                                                }
                                            }
                                        }
                                    }
                                }
                            }

                            break;
                    }
                //}

                return retTable;
            }
            set
            {
                ViewState["grdDataSource"] = value;
            }
        }

        public string BillingKeyType
        {
            get
            {
                if (ViewState["BillingKeyType"] != null)
                    return ViewState["BillingKeyType"].ToString();
                else
                    return "";
            }
            set
            {
                ViewState["BillingKeyType"] = value;
            }
        }

        public string BillingKey
        {
            get
            {
                if (ViewState["BillingKey"] != null)
                    return ViewState["BillingKey"].ToString();
                else
                    return "";
            }
            set
            {
                ViewState["BillingKey"] = value;
            }
        }

        public bool AllowEdit
        {
            get
            {
                return ( null != ViewState["AllowEdit"] ? (bool) ViewState["AllowEdit"] : true );
            }
            set
            {
                ViewState["AllowEdit"] = value;
            }
        }

        private BO_Application CurrentAppProvider
        {
            get
            {
                return Session["CurrentAppProvider"] == null ? null : (BO_Application) Session["CurrentAppProvider"];
            }
        }

    }
}