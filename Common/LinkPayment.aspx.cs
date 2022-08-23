using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ATG.BusinessObject;
using System.Collections;
using Telerik.Web.UI;
using ATG.Utilities.Data;
using ATG;


namespace State.Common
{
    public partial class LinkPayment : System.Web.UI.Page
    {
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
        protected void SubmitBtn_Click(object sender, EventArgs e)
        {
            if (grdLinkPayment.SelectedItems.Count > 0)
            {
                //get the billingID for the current application
                //There is always one billing record for each application
                decimal currentAppBillingID = 0 ;
                decimal currentAppID = ( !string.IsNullOrEmpty( (string) Session["LinkAppId"] ) ? Convert.ToDecimal( Session["LinkAppId"] ) : 0 ) ;
                string providerPOPSINTID = (string)Session["ProviderPOPSINTID"];
                BO_ProviderPrimaryKey boProviderPrimaryKey = new BO_ProviderPrimaryKey(Convert.ToDecimal(providerPOPSINTID));
                if (boProviderPrimaryKey != null)
                {
                    //Get the billingID for the current application
                    if (currentAppID != 0)
                    {
                        BO_Billings LinkedBilling = BO_Billing.SelectByField(BO_BillingFields.ApplicationID, currentAppID);
                        if ( null != LinkedBilling && LinkedBilling.Count > 0 )
                        {
                            currentAppBillingID = LinkedBilling[0].BillingID.Value;
                        }
                        else
                        {
                            BO_Billing tmpBilling = new BO_Billing();

                            tmpBilling.PopsIntID = Convert.ToDecimal( providerPOPSINTID );
                            tmpBilling.ApplicationID = currentAppID;
                            tmpBilling.PriceModelID = 999;

                            tmpBilling.InsertWithDefaultValues( true );

                            currentAppBillingID = tmpBilling.BillingID.Value;
                            
                        }
                    }
                }

                if (currentAppID > 0 && currentAppBillingID > 0)
                {
                    foreach ( GridDataItem itm in grdLinkPayment.SelectedItems )
                    {
                        //stamp the Current Application billing_id in billing_detail record
                        //delete the temp billing record attached to this billing detail record
                        decimal editBillingDetailID = Convert.ToDecimal( itm["BillingDetailID"].Text );
                        BO_BillingDetail boBillingDetail = BO_BillingDetail.SelectOne( new BO_BillingDetailPrimaryKey( editBillingDetailID ) );
                        decimal editBillingID = Convert.ToDecimal( boBillingDetail.BillingID.Value );
                        boBillingDetail.BillingID = currentAppBillingID;
                        boBillingDetail.Update();

                        BO_Billing boBilling = BO_Billing.SelectOne( new BO_BillingPrimaryKey( editBillingID ) );
                        boBilling.Delete();

                    }
                }
            }

            // Call client method in radwindow page  
            //ClientScript.RegisterStartupScript(Page.GetType(), "CloseRadWin", "CloseWin();", true);
            ClientScript.RegisterStartupScript(Page.GetType(), "Key", "CloseAndRebind('key');", true);
        }

        protected void UnlinkBtn_Click(object sender, EventArgs e)
        {
            if (grdLinkPayment.SelectedItems.Count > 0)
            {
                //
                string providerPOPSINTID = (string)Session["ProviderPOPSINTID"];
                BO_ProviderPrimaryKey boProviderPrimaryKey = new BO_ProviderPrimaryKey(Convert.ToDecimal(providerPOPSINTID));

                foreach (GridDataItem itm in grdLinkPayment.SelectedItems)
                {
                    //to unlink a payment from current application, create new billing record with state id/pops id, but no application id
                    //copy old billing record fields to new billing record and then update the billing id for the billing detail record
                    //this will be done for each payment being unlinked so each with have a unique billing and billing id record
                    decimal editBillingDetailID = Convert.ToDecimal(itm["BillingDetailID"].Text);
                    BO_BillingDetail boBillingDetail = BO_BillingDetail.SelectOne(new BO_BillingDetailPrimaryKey(editBillingDetailID));

                    //get current billing record for billing detail record to copy fields to new billing record
                     decimal editBillingID = Convert.ToDecimal(boBillingDetail.BillingID.Value);
                    BO_Billing oldBilling = BO_Billing.SelectOne(new BO_BillingPrimaryKey(editBillingID));

                    //create new billing record
                    BO_Billing newbilling = new BO_Billing();
                    newbilling.BillToName = oldBilling.BillToName;
                    newbilling.CheckLogPrefix = oldBilling.CheckLogPrefix;
                    newbilling.PopsIntID = oldBilling.PopsIntID;
                    newbilling.PriceModelID = oldBilling.PriceModelID;
                    newbilling.ProgramID = oldBilling.ProgramID;
                    newbilling.TotalPayments = boBillingDetail.Amount;
                    newbilling.InsertWithDefaultValues(true);
                    //newbilling.Update();

                    //update newbilling record billing id for billing detail record
                    boBillingDetail.BillingID = newbilling.BillingID;
                    boBillingDetail.Update();

                }
            }
             
            // Call client method in radwindow page  
            //ClientScript.RegisterStartupScript(Page.GetType(), "CloseRadWin", "CloseWin();", true);
            ClientScript.RegisterStartupScript(Page.GetType(), "Key", "CloseAndRebind('key');", true);
        }

        protected void CancelBtn_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(Page.GetType(), "Key", "CloseWin();", true);
        }
       
        private DataTable grdLinkPaymentsDataSource
        {
            get {
                DataTable retTable = _getgrdLinkPaymentInitTable();
                string providerPOPSINTID = (string)Session["ProviderPOPSINTID"];
                BO_ProviderPrimaryKey boProviderPrimaryKey = new BO_ProviderPrimaryKey(Convert.ToDecimal(providerPOPSINTID));

                switch(Request.QueryString["lt"].ToString())
                {
                    case "ni":          
                        //DataTable retTable = (DataTable)ViewState["grdLinkPaymentsDataSource"];
                        //string providerPOPSINTID = (string)Session["ProviderPOPSINTID"];
                        //BO_ProviderPrimaryKey boProviderPrimaryKey = new BO_ProviderPrimaryKey(Convert.ToDecimal(providerPOPSINTID));
                        if (boProviderPrimaryKey != null)
                        {
                            // Get all the billing records for the pops_int_id
                            BO_Billings notLinkedBilling = BO_Billing.SelectAllUnlinkedByForeignKeyPopsIntID(boProviderPrimaryKey);
                            retTable = getTableFromBilling(retTable, notLinkedBilling);
                        }
                        break;
                    case "i":
                        //get check log/billing records not yet assigned to a provider
                        BO_Provider provider = BO_Provider.SelectOne(boProviderPrimaryKey);
                        BO_Billings notLinkedBillingInitials = BO_Billing.SelectAllUnlinkedInitialLicenses(provider.ProgramID);
                        retTable = getTableFromBilling(retTable, notLinkedBillingInitials);
                        break;
                    case "u":
                        //get payment available for unlinking by billingdetailsid
                         if (Request.QueryString["bdid"]!=String.Empty)
                         {
                            // Get all the billing records for the pops_int_id for payments linked to an application
                             BO_Billings notLinkedBilling = BO_Billing.SelectAllLinkedByForeignKeyPopsIntID(Convert.ToDecimal(Request.QueryString["bdid"]));
                            retTable = getTableFromBilling(retTable, notLinkedBilling);
                            UnlinkBtn.Visible = true;
                            SubmitBtn.Visible = false;
                         }
                         break;
                }
                return retTable;
            }
            set
            {
                ViewState["grdDataSource"] = value;
            }
            
        }

        private DataTable getTableFromBilling(DataTable table, BO_Billings billings)
        {
            DataTable retTable = table;
            if (null != billings)
            {
                foreach (BO_Billing boBill in billings)
                {
                    foreach (BO_BillingDetail boBillingDetail in boBill.BO_BillingDetailsBillingID)
                    {
                        //add the data row
                        DataRow tmpDR = retTable.NewRow();
                        tmpDR["BillingDetailID"] = boBillingDetail.BillingDetailID;
                        tmpDR["TypeBillingDesc"] = null != boBillingDetail.TypeBilling ? _getBillingTypeText(boBillingDetail.TypeBilling.ToString()) : "";
                        //RS - 09/05/2013 - Issue# 17702/17692
                        //string tmpTypeFeeDesc = null != boBillingDetail.TypeFee ? _getFeeTypeText(boBillingDetail.TypeFee.ToString()) : "";
                        string tmpTypeFeeDesc = null != boBillingDetail.TypeFee ? _getFeeTypeText(boBillingDetail.TypeFee.ToString()) : null;
                        if (null != tmpTypeFeeDesc)
                        {
                            if (!boBillingDetail.TypeFee.ToString().Equals("99"))
                                tmpDR["TypeFeeDesc"] = _getFeeTypeText(boBillingDetail.TypeFee.ToString());
                            else
                                tmpDR["TypeFeeDesc"] = "Other";

                        }
                        tmpDR["TransactionStatus"] = (null != boBillingDetail.TransactionStatus && boBillingDetail.TransactionStatus.Equals("1")) || null == boBillingDetail.TransactionStatus ? "Succeeded" : "Failed"; ;
                        tmpDR["Amount"] = boBillingDetail.Amount;
                        tmpDR["TransactionID"] = boBillingDetail.TransactionID;
                        tmpDR["TransactionDate"] = boBillingDetail.TransactionDate;
                        tmpDR["Comment"] = "Bill To Name: " + boBill.BillToName;

                        retTable.Rows.Add(tmpDR);
                    }
                }
            }
            return retTable;
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _InitializeGrid();
            }
        }
        private void _InitializeGrid()
        {
            grdLinkPayment.AutoGenerateColumns = false;
            grdLinkPayment.AllowPaging = false;
            grdLinkPayment.AllowFilteringByColumn = false;
            grdLinkPayment.GridLines = GridLines.None;
            grdLinkPayment.EnableViewState = true;
            grdLinkPayment.ShowHeader = true;
            grdLinkPayment.AllowSorting = false;
            grdLinkPayment.ClientSettings.Selecting.AllowRowSelect = true;
            grdLinkPayment.ClientSettings.Scrolling.AllowScroll = true;
            grdLinkPayment.ClientSettings.Scrolling.UseStaticHeaders = true;
            grdLinkPayment.ClientSettings.Resizing.AllowColumnResize = true;
            grdLinkPayment.RegisterWithScriptManager = true;

            BuildgrdLinkPaymentColumns();

            grdLinkPayment.DataSource = grdLinkPaymentsDataSource;
            grdLinkPayment.DataBind();

        }
        private void BuildgrdLinkPaymentColumns()
        {
            GridClientSelectColumn col0 = new GridClientSelectColumn();
            grdLinkPayment.MasterTableView.Columns.Add(col0);
            col0.Visible = true;
            col0.ItemStyle.Width = Unit.Pixel(30);
            col0.HeaderStyle.Width = Unit.Pixel(30);


            GridBoundColumn col1 = new GridBoundColumn();
            grdLinkPayment.MasterTableView.Columns.Add(col1);
            col1.UniqueName = "BillingDetailID";
            col1.DataField = "BillingDetailID";
            col1.HeaderText = "ID";
            col1.Visible = true;
            col1.HeaderStyle.Width = Unit.Pixel(60);

            GridBoundColumn col2 = new GridBoundColumn();
            grdLinkPayment.MasterTableView.Columns.Add(col2);
            col2.UniqueName = "TypeBillingDesc";
            col2.DataField = "TypeBillingDesc";
            col2.HeaderText = "Billing Type";
            col2.Visible = true;
            col2.HeaderStyle.Width = Unit.Pixel(180);

            GridBoundColumn col3 = new GridBoundColumn();
            grdLinkPayment.MasterTableView.Columns.Add(col3);
            col3.UniqueName = "TypeFeeDesc";
            col3.DataField = "TypeFeeDesc";
            col3.HeaderText = "Fee Type";
            col3.Visible = true;
            col3.HeaderStyle.Width = Unit.Pixel(240);

            GridBoundColumn col4 = new GridBoundColumn();
            grdLinkPayment.MasterTableView.Columns.Add(col4);
            col4.UniqueName = "TransactionStatus";
            col4.DataField = "TransactionStatus";
            col4.HeaderText = "Trans Status";
            col4.Visible = true;
            col4.HeaderStyle.Width = Unit.Pixel(80);

            GridBoundColumn col5 = new GridBoundColumn();
            grdLinkPayment.MasterTableView.Columns.Add(col5);
            col5.UniqueName = "Amount";
            col5.DataField = "Amount";
            col5.HeaderText = "Amount";
            col5.Visible = true;
            col5.DataFormatString = "{0:C2}";
            col5.HeaderStyle.Width = Unit.Pixel(80);

            GridBoundColumn col6 = new GridBoundColumn();
            grdLinkPayment.MasterTableView.Columns.Add(col6);
            col6.UniqueName = "TransactionID";
            col6.DataField = "TransactionID";
            col6.HeaderText = "Trans ID";
            col6.Visible = true;
            col6.HeaderStyle.Width = Unit.Pixel(110);


            GridBoundColumn col7 = new GridBoundColumn();
            grdLinkPayment.MasterTableView.Columns.Add(col7);
            col7.UniqueName = "TransactionDate";
            col7.DataField = "TransactionDate";
            col7.HeaderText = "Date";
            col7.Visible = true;
            col7.HeaderStyle.Width = Unit.Pixel(210);

            GridBoundColumn col8 = new GridBoundColumn();
            grdLinkPayment.MasterTableView.Columns.Add(col8);
            col8.UniqueName = "Comment";
            col8.DataField = "Comment";
            col8.HeaderText = "Comment";
            col8.Visible = true;
            col8.HeaderStyle.Width = Unit.Pixel(180);

        }
        protected void grdLinkPayment_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            if (null != grdLinkPaymentsDataSource)
            {
                grdLinkPayment.DataSource = (DataTable)grdLinkPaymentsDataSource;


            }
            
        }
        private DataTable _getgrdLinkPaymentInitTable()
        {
            DataTable tmpDTbl = new DataTable();
            DataColumn tmpDCol = null;

            tmpDCol = new DataColumn("BillingDetailID");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("ApplicationID");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("TypeBillingDesc");
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
            
            return tmpDTbl;
        }
    }
}

