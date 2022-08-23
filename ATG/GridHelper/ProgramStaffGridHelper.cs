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
    public class ProgramStaffGridHelper
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

        public void InitializeProgramStaffGrid()
        {
            //get user queue and set datatable for queue datagrid
            GridDataSource = _getGridDataSource(BO_ProgramStaff.SelectProgramStaffForGrid());
        }

        public static GridBoundColumn[] GridColumnList()
        {
            GridBoundColumn[] retColList = new GridBoundColumn[4];

            GridBoundColumn tmpCol = new GridBoundColumn();

            tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "ProgramStaffID";
            tmpCol.DataField = "PROGRAM_STAFF_ID";
            tmpCol.HeaderText = "Program Staff ID";
            tmpCol.Visible = false;
            tmpCol.HeaderStyle.Width = Unit.Percentage(0);
            tmpCol.AllowFiltering = false;
            retColList[0] = tmpCol;

            tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "LastName";
            tmpCol.DataField = "LAST_NAME";
            tmpCol.HeaderText = "Last Name";
            tmpCol.Visible = true;
            tmpCol.HeaderStyle.Width = Unit.Percentage(15);
            tmpCol.AllowFiltering = false;
            retColList[1] = tmpCol;

            tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "FirstName";
            tmpCol.DataField = "FIRST_NAME";
            tmpCol.HeaderText = "First Name";
            tmpCol.Visible = true;
            tmpCol.HeaderStyle.Width = Unit.Percentage(15);
            tmpCol.AllowFiltering = false;
            retColList[2] = tmpCol;

            tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "LoginID";
            tmpCol.DataField = "LOGIN_ID";
            tmpCol.HeaderText = "Login ID";
            tmpCol.Visible = true;
            tmpCol.HeaderStyle.Width = Unit.Percentage(15);
            tmpCol.AllowFiltering = false;
            retColList[3] = tmpCol;

            return retColList;
        }

        private DataTable _getGridDataTableStruct()
        {
            DataTable tmpDTbl = new DataTable();
            DataColumn tmpDCol = null;

            tmpDCol = new DataColumn("PROGRAM_STAFF_ID");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("LAST_NAME");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("FIRST_NAME");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("LOGIN_ID");
            tmpDTbl.Columns.Add(tmpDCol);

            return tmpDTbl;
        }

        private DataTable _getGridDataSource(BO_ProgramStaffs ProgamStaffs)
        {
            DataTable retTable = _getGridDataTableStruct();

            if (ProgamStaffs != null)
            {
                foreach (BO_ProgramStaff programStaff in ProgamStaffs)
                {
                    DataRow tmpDR = retTable.NewRow();
                    tmpDR["PROGRAM_STAFF_ID"] = programStaff.ProgramStaffID;
                    tmpDR["LAST_NAME"] = programStaff.LastName;
                    tmpDR["FIRST_NAME"] = programStaff.FirstName;
                    tmpDR["LOGIN_ID"] = programStaff.LoginID;
                    
                    retTable.Rows.Add(tmpDR);
                }
            }

            return retTable;
        }
    }
}