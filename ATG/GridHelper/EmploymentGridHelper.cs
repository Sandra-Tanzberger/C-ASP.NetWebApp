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
    public class EmploymentGridHelper
    {
        /// <summary>
        /// Define the columns for the Providers's grid
        /// </summary>
        /// 

        private DataTable _gridDataSource;

        public DataTable GridDataSource
        {
            set { _gridDataSource = value; }
            get { return _gridDataSource; }
        }

        public void InitializeEmploymentGrid(BO_PersonPrimaryKey pk)
        {
            //get user queue and set datatable for queue datagrid
            GridDataSource = _getGridDataSource(BO_Employment.SelectAllByForeignKeyPersonID(pk));
        }

        public static GridBoundColumn[] GridColumnList()
        {
            GridBoundColumn[] retColList = new GridBoundColumn[7];

            GridBoundColumn tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "StartDate";
            tmpCol.DataField = "StartDate";
            tmpCol.HeaderText = "Start Date";
            tmpCol.Visible = true;
            tmpCol.HeaderStyle.Width = Unit.Percentage(12);
            tmpCol.DataFormatString = "<nobr>{0}</nobr>";
            retColList[0] = tmpCol;

            tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "EndDate";
            tmpCol.DataField = "EndDate";
            tmpCol.HeaderText = "End Date";
            tmpCol.Visible = true;
            tmpCol.HeaderStyle.Width = Unit.Percentage(12);
            tmpCol.DataFormatString = "<nobr>{0}</nobr>";
            retColList[1] = tmpCol;

            tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "FacilityName";
            tmpCol.DataField = "FacilityName";
            tmpCol.HeaderText = "Facility Name";
            tmpCol.Visible = true;
            tmpCol.HeaderStyle.Width = Unit.Percentage(23);
            tmpCol.DataFormatString = "<nobr>{0}</nobr>";
            retColList[2] = tmpCol;

            tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "FacilityAddress";
            tmpCol.DataField = "FacilityAddress";
            tmpCol.HeaderText = "Facility Address";
            tmpCol.Visible = true;
            tmpCol.HeaderStyle.Width = Unit.Percentage(23);
            tmpCol.DataFormatString = "<nobr>{0}</nobr>";
            retColList[3] = tmpCol;

            tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "JobDutySummary";
            tmpCol.DataField = "JobDutySummary";
            tmpCol.HeaderText = "Job Duty Summary";
            tmpCol.Visible = true;
            tmpCol.HeaderStyle.Width = Unit.Percentage(30);
            tmpCol.DataFormatString = "<nobr>{0}</nobr>";
            retColList[4] = tmpCol;

            tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "EmploymentID";
            tmpCol.DataField = "EmploymentID";
            tmpCol.HeaderText = "Employment Internal ID";
            tmpCol.Visible = false;
            retColList[5] = tmpCol;

            tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "PersonID";
            tmpCol.DataField = "PersonID";
            tmpCol.HeaderText = "Person Internal ID";
            tmpCol.Visible = false;
            retColList[6] = tmpCol;

            return retColList;
        }

        private DataTable _getGridDataTableStruct()
        {
            DataTable tmpDTbl = new DataTable();
            DataColumn tmpDCol = null;

            tmpDCol = new DataColumn("StartDate");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("EndDate");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("FacilityName");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("FacilityAddress");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("JobDutySummary");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("EmploymentID");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("PersonID");
            tmpDTbl.Columns.Add(tmpDCol);

            return tmpDTbl;
        }

        private DataTable _getGridDataSource(BO_Employments Employments)
        {
            DataTable retTable = _getGridDataTableStruct();

            if (Employments != null)
            {
                foreach (BO_Employment employment in Employments)
                {
                    DataRow tmpDR = retTable.NewRow();
                    tmpDR["StartDate"] = (null == employment.StartDate ? "" : DateTime.Parse(employment.StartDate.ToString()).ToShortDateString());
                    tmpDR["EndDate"] = (null == employment.EndDate ? "" : DateTime.Parse(employment.EndDate.ToString()).ToShortDateString());
                    tmpDR["FacilityName"] = employment.FacilityName;
                    tmpDR["FacilityAddress"] = employment.FacilityAddress;
                    tmpDR["JobDutySummary"] = employment.JobDutySummary;
                    tmpDR["EmploymentID"] = employment.EmploymentID.ToString();
                    tmpDR["PersonID"] = employment.PersonID.ToString();

                    retTable.Rows.Add(tmpDR);
                }
            }

            return retTable;
        }
    }
}