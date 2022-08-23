using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using ATG.BusinessObject;
using ATG.Utilities.Data;
using Telerik.Web.UI;

namespace ATG.GridHelper
{
    public class AccountingGridHelper
    {
        private DataTable _gridDataSource = null;
        private String _typeActngGridView = null;

        public void Initialize( String inTypeAccountingView, String inSelectKey, String inFilter )
        {
            _typeActngGridView = inTypeAccountingView;
            BO_CheckLogViews boCheckLogViews = null;
                    
            switch ( _typeActngGridView )
            {
                case "ALL":
                    boCheckLogViews = BO_CheckLogView.SelectByTypeView( inSelectKey, inFilter  );
                    _gridDataSource = _LoadGridDataCheckLogRecs( boCheckLogViews );
                    break;
                default:
                    boCheckLogViews = BO_CheckLogView.SelectByTypeView( inSelectKey, inFilter );
                    _gridDataSource = _LoadGridDataCheckLogRecs( boCheckLogViews );
                    break;
            }
        }

        public DataTable GridDataSource
        {
            get
            {
                return _gridDataSource;
            }
            set
            {
                _gridDataSource = value;
            }
        }

        public GridBoundColumn[] GridColumnList()
        {
            switch ( _typeActngGridView )
            {
                case "ALL":
                    return BuildCheckLogGridColumns();
                default:
                    return BuildCheckLogGridColumns();
            }
        }

        /// <summary>
        /// Define the columns for the Providers's grid
        /// </summary>
        private GridBoundColumn[] BuildCheckLogGridColumns()
        {
            //rs - 05/29/2012 - Added Processed By new column to Accounting grid
            GridBoundColumn[] retColList = new GridBoundColumn[14];
            
            GridBoundColumn tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "BillingID";
            tmpCol.DataField = "BillingID";
            tmpCol.HeaderText = "BillingID";
            tmpCol.Visible = false;
            tmpCol.HeaderStyle.Width = Unit.Pixel( 0 );
            tmpCol.AllowFiltering = false;
            retColList[0] = tmpCol;

            tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "BillingDetailID";
            tmpCol.DataField = "BillingDetailID";
            tmpCol.HeaderText = "BillingDetailID";
            tmpCol.Visible = false;
            tmpCol.HeaderStyle.Width = Unit.Pixel(0);
            tmpCol.AllowFiltering = false;
            retColList[1] = tmpCol;

            tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "DateEntered";
            tmpCol.DataField = "DateEntered";
            tmpCol.HeaderText = "Date Entered";
            tmpCol.HeaderStyle.Width = Unit.Pixel( 125 );
            tmpCol.AllowFiltering = true;
            retColList[2] = tmpCol;

            tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "CompanyIndividual";
            tmpCol.DataField = "CompanyIndividual";
            tmpCol.HeaderText = "Company/Individual";
            tmpCol.Visible = true;
            tmpCol.HeaderStyle.Width = Unit.Pixel( 215 );
            tmpCol.AllowFiltering = true;
            retColList[3] = tmpCol;

            tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "StateID";
            tmpCol.DataField = "StateID";
            tmpCol.HeaderText = "State ID";
            tmpCol.Visible = true;
            tmpCol.HeaderStyle.Width = Unit.Pixel( 125 );
            tmpCol.AllowFiltering = true;
            retColList[4] = tmpCol;

            tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "Amount";
            tmpCol.DataField = "Amount";
            tmpCol.HeaderText = "Amount";
            tmpCol.Visible = true;
            tmpCol.HeaderStyle.Width = Unit.Pixel( 125 );
            tmpCol.AllowFiltering = true;
            retColList[5] = tmpCol;

            tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "CheckNum";
            tmpCol.DataField = "CheckNum";
            tmpCol.HeaderText = "Check Number";
            tmpCol.Visible = true;
            tmpCol.HeaderStyle.Width = Unit.Pixel( 125 );
            tmpCol.AllowFiltering = true;
            retColList[6] = tmpCol;

            tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "CheckDate";
            tmpCol.DataField = "CheckDate";
            tmpCol.HeaderText = "Check Date";
            tmpCol.Visible = true;
            tmpCol.HeaderStyle.Width = Unit.Pixel( 125 );
            tmpCol.AllowFiltering = true;
            retColList[7] = tmpCol;

            tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "Code";
            tmpCol.DataField = "Code";
            tmpCol.HeaderText = "Code";
            tmpCol.Visible = true;
            tmpCol.HeaderStyle.Width = Unit.Pixel( 125 );
            tmpCol.AllowFiltering = true;
            retColList[8] = tmpCol;

            tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "FeeCategory";
            tmpCol.DataField = "FeeCategory";
            tmpCol.HeaderText = "Fee Category";
            tmpCol.Visible = true;
            tmpCol.HeaderStyle.Width = Unit.Pixel( 160 );
            tmpCol.AllowFiltering = true;
            retColList[9] = tmpCol;

            tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "PivNum";
            tmpCol.DataField = "PivNum";
            tmpCol.HeaderText = "PIV Number";
            tmpCol.Visible = true;
            tmpCol.HeaderStyle.Width = Unit.Pixel( 125 );
            tmpCol.AllowFiltering = true;
            retColList[10] = tmpCol;

            tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "ApplicationID";
            tmpCol.DataField = "ApplicationID";
            tmpCol.HeaderText = "Application ID";
            tmpCol.Visible = true;
            tmpCol.HeaderStyle.Width = Unit.Pixel( 125 );
            tmpCol.AllowFiltering = true;
            retColList[11] = tmpCol;

            tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "PopsIntID";
            tmpCol.DataField = "PopsIntID";
            tmpCol.HeaderText = "PopsIntID";
            tmpCol.Visible = false;
            tmpCol.HeaderStyle.Width = Unit.Pixel( 0 );
            tmpCol.AllowFiltering = false;
            retColList[12] = tmpCol;

            tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "ProcessedBY";
            tmpCol.DataField = "ProcessedBY";
            tmpCol.HeaderText = "Processed By";
            tmpCol.Visible = true;
            tmpCol.HeaderStyle.Width = Unit.Pixel(125);
            tmpCol.AllowFiltering = true;
            retColList[13] = tmpCol;

            return retColList;
        }

        private DataTable _getGridDataTableStruct()
        {
            DataTable tmpDTbl = new DataTable();
            DataColumn tmpDCol = null;

            switch ( _typeActngGridView )
            {
                case "ALL":
                    tmpDCol = new DataColumn( "BillingID" );
                    tmpDTbl.Columns.Add( tmpDCol );
                    tmpDCol = new DataColumn("BillingDetailID");
                    tmpDTbl.Columns.Add(tmpDCol);
                    tmpDCol = new DataColumn( "DateEntered" );
                    tmpDTbl.Columns.Add( tmpDCol );
                    tmpDCol = new DataColumn( "CompanyIndividual" );
                    tmpDTbl.Columns.Add( tmpDCol );
                    tmpDCol = new DataColumn( "StateID" );
                    tmpDTbl.Columns.Add( tmpDCol );
                    tmpDCol = new DataColumn( "Amount" );
                    tmpDTbl.Columns.Add( tmpDCol );
                    tmpDCol = new DataColumn( "CheckNum" );
                    tmpDTbl.Columns.Add( tmpDCol );
                    tmpDCol = new DataColumn( "CheckDate" );
                    tmpDTbl.Columns.Add( tmpDCol );
                    tmpDCol = new DataColumn( "Code" );
                    tmpDTbl.Columns.Add( tmpDCol );
                    tmpDCol = new DataColumn( "FeeCategory" );
                    tmpDTbl.Columns.Add( tmpDCol );
                    tmpDCol = new DataColumn( "PivNum" );
                    tmpDTbl.Columns.Add( tmpDCol );
                    tmpDCol = new DataColumn( "ApplicationID" );
                    tmpDTbl.Columns.Add( tmpDCol );
                    tmpDCol = new DataColumn( "PopsIntID" );
                    tmpDTbl.Columns.Add( tmpDCol );
                    tmpDCol = new DataColumn("ProcessedBY");
                    tmpDTbl.Columns.Add(tmpDCol);
                    break;
            }

            return tmpDTbl;
        }

        private DataTable _LoadGridDataCheckLogRecs( BO_CheckLogViews inCheckLogViewList )
        {
            DataTable retTable = _getGridDataTableStruct();

            if ( null != inCheckLogViewList )
            {
                foreach ( BO_CheckLogView boCLV in inCheckLogViewList )
                {
                    DataRow tmpDR = retTable.NewRow();
                    tmpDR["BillingID"] = boCLV.BillingID;
                    tmpDR["BillingDetailID"] = boCLV.BillingDetailID;
                    tmpDR["DateEntered"] = boCLV.DateEntered;
                    tmpDR["CompanyIndividual"] = boCLV.CompanyIndividual;
                    tmpDR["StateID"] = boCLV.StateID;
                    tmpDR["Amount"] = boCLV.Amount;
                    tmpDR["CheckNum"] = boCLV.CheckNum;
                    tmpDR["CheckDate"] = boCLV.CheckDate;
                    tmpDR["Code"] = boCLV.Code;
                    tmpDR["FeeCategory"] = boCLV.FeeCategory;
                    tmpDR["PivNum"] = boCLV.PivNum;
                    tmpDR["ApplicationID"] = boCLV.ApplicationID;
                    tmpDR["PopsIntID"] = boCLV.PopsIntID;
                    tmpDR["ProcessedBY"] = boCLV.ProcessedBY;

                    retTable.Rows.Add( tmpDR );
                }
            }
            return retTable;
        }
    }
}
