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
    public class InsuranceCoverageGridHelper
    {
        /// <summary>
        /// Define the columns for the insurance coverage grid
        /// </summary>
        /// 

        private DataTable _gridDataSource;

        public DataTable GridDataSource
        {
            set { _gridDataSource = value; }
            get { return _gridDataSource;}
        }

        public void InitializeInsuranceCoveragesGrid(decimal? popsIntId) {
            GridDataSource = _getGridDataSource(BO_InsuranceCoverage.SelectAllByPopsIntIdForGrid(popsIntId));
        }

        public static GridBoundColumn[] GridColumnList()
        {
            GridBoundColumn[] retColList = new GridBoundColumn[10];

            GridBoundColumn tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "PopsIntID";
            tmpCol.DataField = "POPS_INT_ID";
            tmpCol.HeaderText = "Pops Int ID";
            tmpCol.Visible = false;
            tmpCol.HeaderStyle.Width = Unit.Percentage(0);
            tmpCol.AllowFiltering = false;
            retColList[0] = tmpCol;

            tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "CarrierCode";
            tmpCol.DataField = "CARRIER_CODE";
            tmpCol.HeaderText = "Carrier Code";
            tmpCol.Visible = false;
            tmpCol.HeaderStyle.Width = Unit.Percentage(0);
            tmpCol.AllowFiltering = false;
            retColList[1] = tmpCol;
            
            tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "CarrierName";
            tmpCol.DataField = "CARRIER_NAME";
            tmpCol.HeaderText = "Carrier Name";
            tmpCol.Visible = true;
            tmpCol.HeaderStyle.Width = Unit.Percentage(15);
            tmpCol.AllowFiltering = false;
            retColList[2] = tmpCol;

            tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "CoverageType";
            tmpCol.DataField = "COVERAGE_TYPE";
            tmpCol.HeaderText = "Coverage Type Code";
            tmpCol.Visible = false;
            tmpCol.HeaderStyle.Width = Unit.Percentage(0);
            tmpCol.AllowFiltering = false;
            retColList[3] = tmpCol;

            tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "CoverageTypeDesc";
            tmpCol.DataField = "COVERAGE_TYPE_DESC";
            tmpCol.HeaderText = "Coverage Type";
            tmpCol.Visible = true;
            tmpCol.HeaderStyle.Width = Unit.Percentage(15);
            tmpCol.AllowFiltering = false;
            retColList[4] = tmpCol;

            tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "PolicyNum";
            tmpCol.DataField = "POLICY_NUM";
            tmpCol.HeaderText = "Policy Num";
            tmpCol.Visible = true;
            tmpCol.HeaderStyle.Width = Unit.Percentage(12);
            tmpCol.AllowFiltering = false;
            retColList[5] = tmpCol;

            tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "EffectiveDate";
            tmpCol.DataField = "EFFECTIVE_DATE";
            tmpCol.HeaderText = "Effective Date";
            tmpCol.Visible = true;
            tmpCol.HeaderStyle.Width = Unit.Percentage(10);
            tmpCol.AllowFiltering = false;
            retColList[6] = tmpCol;

            tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "ExpirationDate";
            tmpCol.DataField = "EXPIRATION_DATE";
            tmpCol.HeaderText = "Expiration Date";
            tmpCol.Visible = true;
            tmpCol.HeaderStyle.Width = Unit.Percentage(10);
            tmpCol.AllowFiltering = false;
            retColList[7] = tmpCol;

            tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "CoverageLimit";
            tmpCol.DataField = "COVERAGE_LIMIT";
            tmpCol.HeaderText = "Coverage Limit";
            tmpCol.Visible = true;
            tmpCol.HeaderStyle.Width = Unit.Percentage(10);
            tmpCol.AllowFiltering = true;
            retColList[8] = tmpCol;

            tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "PrepaymentDueDate";
            tmpCol.DataField = "PREPAYMENT_DUE_DATE";
            tmpCol.HeaderText = "Prepayment Due Date";
            tmpCol.Visible = true;
            tmpCol.HeaderStyle.Width = Unit.Percentage(10);
            tmpCol.AllowFiltering = true;
            retColList[9] = tmpCol;

            return retColList;
        }

        private DataTable _getGridDataTableStruct()
        {
            DataTable tmpDTbl = new DataTable();
            DataColumn tmpDCol = null;

            tmpDCol = new DataColumn("POPS_INT_ID");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("CARRIER_CODE");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("CARRIER_NAME");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("COVERAGE_TYPE");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("COVERAGE_TYPE_DESC");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("POLICY_NUM");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("EFFECTIVE_DATE");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("EXPIRATION_DATE");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("COVERAGE_LIMIT");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("PREPAYMENT_DUE_DATE");
            tmpDTbl.Columns.Add(tmpDCol);

            return tmpDTbl;
        }

        private DataTable _getGridDataSource(BO_InsuranceCoverages InsuranceCoverages)
        {
            DataTable retTable = _getGridDataTableStruct();

            if (InsuranceCoverages != null)
            {
                foreach (BO_InsuranceCoverage InsuranceCoverage in InsuranceCoverages)
                {
                    DataRow tmpDR = retTable.NewRow();
                    tmpDR["POPS_INT_ID"] = InsuranceCoverage.PopsIntID;
                    tmpDR["CARRIER_CODE"] = InsuranceCoverage.CarrierCode;
                    tmpDR["CARRIER_NAME"] = InsuranceCoverage.CarrierName;
                    tmpDR["COVERAGE_TYPE"] = InsuranceCoverage.CoverageType;
                    tmpDR["COVERAGE_TYPE_DESC"] = InsuranceCoverage.CoverageTypeDesc;
                    tmpDR["POLICY_NUM"] = InsuranceCoverage.PolicyNum;
                    tmpDR["EFFECTIVE_DATE"] = (null == InsuranceCoverage.EffectiveDate ? "" : ((DateTime)InsuranceCoverage.EffectiveDate).ToShortDateString());
                    tmpDR["EXPIRATION_DATE"] = (null == InsuranceCoverage.ExpirationDate ? "" : ((DateTime)InsuranceCoverage.ExpirationDate).ToShortDateString());
                    tmpDR["COVERAGE_LIMIT"] = String.Format("{0:C}", InsuranceCoverage.CoverageLimit);
                    tmpDR["PREPAYMENT_DUE_DATE"] = (null == InsuranceCoverage.PrepaymentDueDate ? "" : ((DateTime)InsuranceCoverage.PrepaymentDueDate).ToShortDateString()); ;

                    retTable.Rows.Add(tmpDR);
                }
            }

            return retTable;
        }
    }
}