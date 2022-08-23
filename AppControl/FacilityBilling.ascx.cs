using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ATG;
using ATG.BusinessObject;
using System.Data;
using Telerik.Web.UI;
using ATG.Utilities.Data;
using System.Collections;
using ATG.Security;

namespace AppControl
{
    //FacilityPayments Control maps to the History/Billing Tab and Billing/BillingDetail tables
    public partial class FacilityBilling : System.Web.UI.UserControl
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
           GridCommandItem cmdItem = (GridCommandItem)grdBilling.MasterTableView.GetItems(GridItemType.CommandItem)[0];
           LinkButton printScreen = (LinkButton)cmdItem.FindControl("btnPrintScreen");
           LinkButton btnDelete = (LinkButton)cmdItem.FindControl("btnDelete");
           printScreen.Attributes.Add("Onclick", "getPrint('Facility_rpv_History_Payment_userControl_grdBilling_GridData');");

           if (User.HasAccess("PBG"))
           {
               btnDelete.Visible = true;
           }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetDefaultProperties();
                BuildBillingGridColumns();
            }
        }

        private User User
        {
            get{return (User)Session["User"];}
        }

        protected void grdBilling_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            grdBilling.DataSource = GetBillingGridTable(Convert.ToDecimal(CurrentProvider.PopsIntID));
        }

        private void InitBillingGrid()
        {
            grdBilling.DataSource = GetBillingGridTable(Convert.ToDecimal(CurrentProvider.PopsIntID));
            grdBilling.DataBind();
        }

        protected void grdBilling_ItemCommand(object sender, GridCommandEventArgs e)
        {
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

            if (e.CommandName.Equals("Rebind"))
            {
                InitBillingGrid();
            }
        }

        private BO_Provider CurrentProvider
        {
            get
            {
                return Session["CurrentProvider"] == null ? null : (BO_Provider)Session["CurrentProvider"];
            }

        }

        private void SetDefaultProperties()
        {
            grdBilling.AutoGenerateColumns = false;
            grdBilling.AllowPaging = false;
            grdBilling.AllowFilteringByColumn = false;
            grdBilling.GridLines = GridLines.None;
            grdBilling.EnableViewState = true;
            grdBilling.ShowHeader = true;
            grdBilling.AllowSorting = true;
            grdBilling.SortingSettings.EnableSkinSortStyles = true;

            grdBilling.ClientSettings.Resizing.AllowColumnResize = true;
            grdBilling.RegisterWithScriptManager = true; 


            if (grdBilling.MasterTableView.SortExpressions.Count == 0)
            {
                Telerik.Web.UI.GridSortExpression expression = new Telerik.Web.UI.GridSortExpression();
                expression.FieldName = "BillingDetailID";
                expression.SortOrder = Telerik.Web.UI.GridSortOrder.Descending;
                grdBilling.MasterTableView.SortExpressions.AddSortExpression(expression);
                grdBilling.SortingSettings.EnableSkinSortStyles = false;
            } 

        }

        private DataTable _getBillingGridInitTable()
        {
            DataTable tmpDTbl = new DataTable();
            DataColumn tmpDCol = null;

            tmpDCol = new DataColumn("BillingDetailID");
            tmpDCol.DataType = System.Type.GetType("System.Decimal");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("ApplicationTypeDate");
            tmpDCol.DataType = System.Type.GetType("System.String");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("TypeBillingDesc");
            tmpDCol.DataType = System.Type.GetType("System.String");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("TypeFeeDesc");
            tmpDCol.DataType = System.Type.GetType("System.String");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("TransactionStatus");
            tmpDCol.DataType = System.Type.GetType("System.String");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("Amount");
            tmpDCol.DataType = System.Type.GetType("System.Decimal");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("TransactionID");
            tmpDCol.DataType = System.Type.GetType("System.String");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("TransactionDate");
            tmpDCol.DataType = System.Type.GetType("System.DateTime");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("Comment");
            tmpDCol.DataType = System.Type.GetType("System.String");

            //these columns are not currently being used, set to invisible
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
            tmpDCol = new DataColumn("TotalAdjustments");
            tmpDTbl.Columns.Add(tmpDCol);

            return tmpDTbl;
        }

        private void BuildBillingGridColumns()
        {
            GridBoundColumn tmpCol = new GridBoundColumn();
            grdBilling.MasterTableView.Columns.Add(tmpCol);
            tmpCol.UniqueName = "BillingDetailID";
            tmpCol.DataField = "BillingDetailID";
            tmpCol.HeaderText = "ID";
            tmpCol.Visible = true;
            tmpCol.HeaderStyle.Width = Unit.Percentage(5);

            tmpCol = new GridBoundColumn();
            grdBilling.MasterTableView.Columns.Add(tmpCol);
            tmpCol.UniqueName = "ApplicationTypeDate";
            tmpCol.DataField = "ApplicationTypeDate";
            tmpCol.HeaderText = "App Type/Date";
            tmpCol.Visible = true;
            tmpCol.HeaderStyle.Width = Unit.Percentage(15);

            tmpCol = new GridBoundColumn();
            grdBilling.MasterTableView.Columns.Add(tmpCol);
            tmpCol.UniqueName = "TypeBillingDesc";
            tmpCol.DataField = "TypeBillingDesc";
            tmpCol.HeaderText = "Billing Type";
            tmpCol.Visible = true;
            tmpCol.HeaderStyle.Width = Unit.Percentage(5);

            tmpCol = new GridBoundColumn();
            grdBilling.MasterTableView.Columns.Add(tmpCol);
            tmpCol.UniqueName = "TypeFeeDesc";
            tmpCol.DataField = "TypeFeeDesc";
            tmpCol.HeaderText = "Fee Type";
            tmpCol.Visible = true;
            tmpCol.HeaderStyle.Width = Unit.Percentage(10);

            tmpCol = new GridBoundColumn();
            grdBilling.MasterTableView.Columns.Add(tmpCol);
            tmpCol.UniqueName = "TransactionStatus";
            tmpCol.DataField = "TransactionStatus";
            tmpCol.HeaderText = "Trans Status";
            tmpCol.Visible = true;
            tmpCol.HeaderStyle.Width = Unit.Percentage(5);

            tmpCol = new GridBoundColumn();
            grdBilling.MasterTableView.Columns.Add(tmpCol);
            tmpCol.UniqueName = "Amount";
            tmpCol.DataField = "Amount";
            tmpCol.HeaderText = "Amount";
            tmpCol.DataFormatString = "{0:C2}";
            tmpCol.Visible = true;
            tmpCol.HeaderStyle.Width = Unit.Percentage(5);

            tmpCol = new GridBoundColumn();
            grdBilling.MasterTableView.Columns.Add(tmpCol);
            tmpCol.UniqueName = "TransactionID";
            tmpCol.DataField = "TransactionID";
            tmpCol.HeaderText = "CC Trans ID";
            tmpCol.Visible = true;
            tmpCol.HeaderStyle.Width = Unit.Percentage(5);

            tmpCol = new GridBoundColumn();
            grdBilling.MasterTableView.Columns.Add(tmpCol);
            tmpCol.UniqueName = "TransactionDate";
            tmpCol.DataField = "TransactionDate";
            tmpCol.HeaderText = "Date";
            tmpCol.Visible = true;
            tmpCol.HeaderStyle.Width = Unit.Percentage(10);

            tmpCol = new GridBoundColumn();
            grdBilling.MasterTableView.Columns.Add(tmpCol);
            tmpCol.UniqueName = "Comment";
            tmpCol.DataField = "Comment";
            tmpCol.HeaderText = "Comment";
            tmpCol.Visible = true;
            tmpCol.HeaderStyle.Width = Unit.Percentage(20);

            //these columns are not currently being used
            tmpCol = new GridBoundColumn();
            grdBilling.MasterTableView.Columns.Add(tmpCol);
            tmpCol.UniqueName = "Revised";
            tmpCol.DataField = "Revised";
            tmpCol.HeaderText = "";
            tmpCol.Visible = false;
            tmpCol.HeaderStyle.Width = Unit.Percentage(0);

            tmpCol = new GridBoundColumn();
            grdBilling.MasterTableView.Columns.Add(tmpCol);
            tmpCol.UniqueName = "TotalCharges";
            tmpCol.DataField = "TotalCharges";
            tmpCol.HeaderText = "";
            tmpCol.Visible = false;
            tmpCol.HeaderStyle.Width = Unit.Percentage(0);

            tmpCol = new GridBoundColumn();
            grdBilling.MasterTableView.Columns.Add(tmpCol);
            tmpCol.UniqueName = "TotalPayments";
            tmpCol.DataField = "TotalPayments";
            tmpCol.HeaderText = "";
            tmpCol.Visible = false;
            tmpCol.HeaderStyle.Width = Unit.Percentage(0);

            tmpCol = new GridBoundColumn();
            grdBilling.MasterTableView.Columns.Add(tmpCol);
            tmpCol.UniqueName = "TotalRefunds";
            tmpCol.DataField = "TotalRefunds";
            tmpCol.HeaderText = "";
            tmpCol.Visible = false;
            tmpCol.HeaderStyle.Width = Unit.Percentage(0);

            tmpCol = new GridBoundColumn();
            grdBilling.MasterTableView.Columns.Add(tmpCol);
            tmpCol.UniqueName = "TotalAdjustments";
            tmpCol.DataField = "TotalAdjustments";
            tmpCol.HeaderText = "";
            tmpCol.Visible = false;
            tmpCol.HeaderStyle.Width = Unit.Percentage(0);

        }

        private DataTable GetBillingGridTable(decimal providerPOPSINTID)
        {
            decimal _charges = 0;
            decimal _payments = 0;
            decimal _refunds = 0;
            decimal _adjustments = 0;
            decimal _license = 0;
            decimal _nonlicense = 0;
            DataTable billingTable = _getBillingGridInitTable();
            //get Billings collection and parse out new datatable for billing grid

            BO_Billings boBillings;
            BO_ProviderPrimaryKey providerPrimaryKey = new BO_ProviderPrimaryKey(providerPOPSINTID);
            boBillings = BO_Billing.SelectAllByForeignKeyPopsIntIDWithAllChildren(providerPrimaryKey);

            //loop through BO_Billing collection and BO_BillingDetails collections to create table for billing grid
            foreach (BO_Billing boBilling in boBillings)
            {
                //boBilling.BO_BillingDetailsBillingID.Sort("TransactionDate DESC"); must be done for entire grid for all billingdetail records by provider
                foreach(BO_BillingDetail boBillingDetail in boBilling.BO_BillingDetailsBillingID)
                {
                    DataRow tmpDR = billingTable.NewRow();
                    //RS - 09/05/2013 - Issue# 17702/17692  
                    //string tmpTypeFeeDesc = null != boBillingDetail.TypeFee ? _getFeeTypeText(boBillingDetail.TypeFee.ToString()) : "";
                    string tmpTypeFeeDesc = null != boBillingDetail.TypeFee ? _getFeeTypeText(boBillingDetail.TypeFee.ToString()) : null;

                    if(null!=boBillingDetail.BillingDetailID)
                        tmpDR["BillingDetailID"] = boBillingDetail.BillingDetailID;

                    tmpDR["ApplicationTypeDate"] = (null==boBilling.ApplicationType) || (null==boBilling.ApplicationStartDate) ? "" : boBilling.ApplicationType.ToString() + "&nbsp" + (((DateTime)boBilling.ApplicationStartDate)).ToString("MM/dd/yyyy");

                    tmpDR["TypeBillingDesc"] = null != boBillingDetail.TypeBilling ? _getBillingTypeText(boBillingDetail.TypeBilling.ToString()) : "";

                    if (null != tmpTypeFeeDesc)
                    {
                        if (!boBillingDetail.TypeFee.ToString().Equals("99"))
                            tmpDR["TypeFeeDesc"] = _getFeeTypeText(boBillingDetail.TypeFee.ToString());
                        else
                            tmpDR["TypeFeeDesc"] = "Other";

                    }

                    tmpDR["TransactionStatus"] = (null != boBillingDetail.TransactionStatus && boBillingDetail.TransactionStatus.Equals("1")) || null == boBillingDetail.TransactionStatus ? "Succeeded" : "Failed";

                    if(null!=boBillingDetail.Amount)
                        tmpDR["Amount"] = boBillingDetail.Amount;

                    if(null!=boBillingDetail.TransactionID)
                        tmpDR["TransactionID"] = boBillingDetail.TransactionID;

                    if(null!=boBillingDetail.TransactionDate)
                        tmpDR["TransactionDate"] = boBillingDetail.TransactionDate;

                    if(null!=boBillingDetail.Comment)
                        tmpDR["Comment"] = boBillingDetail.Comment;

                    billingTable.Rows.Add(tmpDR);
                }

                if(boBilling.TotalCharges!=null)
                    _charges += (decimal)boBilling.TotalCharges;
                if(boBilling.TotalPayments!=null)
                    _payments += (decimal)boBilling.TotalPayments;
                if(boBilling.TotalRefunds!=null)
                    _refunds += (decimal)boBilling.TotalRefunds;
                if(boBilling.TotalAdjustments!=null)
                    _adjustments += (decimal)boBilling.TotalAdjustments;

                if(boBilling.ApplicationID!=null)
                    _license += (decimal)boBilling.TotalCharges;
                else
                    _nonlicense += (decimal)boBilling.TotalCharges;
            }

            //grdBillingDataSource = billingTable; //session state not currently turned on for this feature
            txtCharges.Text = _charges.ToString();
            txtPayments.Text = _payments.ToString();
            txtRefunds.Text = _refunds.ToString();
            txtAdjustments.Text = _adjustments.ToString();
            txtLicense.Text = _license.ToString();
            txtNonLicense.Text = _nonlicense.ToString();
            txtBalance.Text = (((_charges - _payments) + _refunds) + _adjustments).ToString();


            //billingTable.DefaultView.Sort = "BillingDetailID DESC";

            return billingTable;

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

    }
}