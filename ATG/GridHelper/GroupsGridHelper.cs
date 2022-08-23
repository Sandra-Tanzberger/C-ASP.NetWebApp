using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using ATG;
using ATG.BusinessObject;
using ATG.Utilities.Data;
using Telerik.Web.UI;

namespace ATG.GridHelper
{
    public class GroupsGridHelper
    {
        /// <summary>
        /// Define the columns for the Providers's grid
        /// </summary>
        /// 

        private DataTable _gridDataSourceAddGroups;

        public DataTable GridDataSourceAddGroups
        {
            set { _gridDataSourceAddGroups = value; }
            get { return _gridDataSourceAddGroups; }
        }

        public GroupsGridHelper()
        {
            BO_ApplicationAccesses applicationAccesses = BO_ApplicationAccess.SelectAllDistinct();
            GridDataSourceAddGroups = _getGridDataSourceAddGroups(applicationAccesses);
        }

        public static GridBoundColumn[] GridColumnListAddGroups()
        {
            GridBoundColumn[] retColList = new GridBoundColumn[1];

            GridBoundColumn tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "GroupID";
            tmpCol.DataField = "GRPID";
            tmpCol.HeaderText = "Group Name";
            tmpCol.Visible = true;
            tmpCol.HeaderStyle.Width = Unit.Percentage(90);
            tmpCol.AllowFiltering = true;
            retColList[0] = tmpCol;

            return retColList;
        }

        private DataTable _getGridDataTableStructAddGroups()
        {
            DataTable tmpDTbl = new DataTable();
            DataColumn tmpDCol = null;

            tmpDCol = new DataColumn("GRPID");
            tmpDTbl.Columns.Add(tmpDCol);

            return tmpDTbl;
        }

        private DataTable _getGridDataSourceAddGroups(BO_ApplicationAccesses applicationAccesses)
        {
            DataTable retTable = _getGridDataTableStructAddGroups();

            foreach (BO_ApplicationAccess applicationAccess in applicationAccesses)
            {
                DataRow tmpDR = retTable.NewRow();
                tmpDR["GRPID"] = applicationAccess.Grpid;

                retTable.Rows.Add(tmpDR);
            }

            return retTable;
        }

    }
}
