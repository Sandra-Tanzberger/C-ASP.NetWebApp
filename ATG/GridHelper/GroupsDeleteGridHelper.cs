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
    public class GroupsDeleteGridHelper
    {
        /// <summary>
        /// Define the columns for the Providers's grid
        /// </summary>
        /// 

        private DataTable _gridDataSourceDeleteGroups;

        public DataTable GridDataSourceDeleteGroups
        {
            set { _gridDataSourceDeleteGroups = value; }
            get { return _gridDataSourceDeleteGroups; }
        }

        public GroupsDeleteGridHelper(string LoginID)
        {
            BO_ApplicationAccesses applicationAccesses = BO_ApplicationAccess.SelectByField("LOGINID", LoginID);
            GridDataSourceDeleteGroups = _getGridDataSourceDeleteGroups(applicationAccesses);
        }

        public static GridBoundColumn[] GridColumnListDeleteGroups()
        {
            GridBoundColumn[] retColList = new GridBoundColumn[2];

            GridBoundColumn tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "GroupID";
            tmpCol.DataField = "GRPID";
            tmpCol.HeaderText = "Group Name";
            tmpCol.Visible = true;
            tmpCol.HeaderStyle.Width = Unit.Percentage(90);
            tmpCol.AllowFiltering = true;
            retColList[0] = tmpCol;

            tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "LoginID";
            tmpCol.DataField = "LOGINID";
            tmpCol.HeaderText = "Login ID";
            tmpCol.Visible = false;
            tmpCol.HeaderStyle.Width = Unit.Percentage(0);
            tmpCol.AllowFiltering = false;
            retColList[1] = tmpCol;

            return retColList;
        }

        private DataTable _getGridDataTableStructDeleteGroups()
        {
            DataTable tmpDTbl = new DataTable();
            DataColumn tmpDCol = null;

            tmpDCol = new DataColumn("GRPID");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("LOGINID");
            tmpDTbl.Columns.Add(tmpDCol);
       
            return tmpDTbl;
        }

        private DataTable _getGridDataSourceDeleteGroups(BO_ApplicationAccesses applicationAccesses)
        {
            DataTable retTable = _getGridDataTableStructDeleteGroups();

            foreach (BO_ApplicationAccess applicationAccess in applicationAccesses)
                {
                    DataRow tmpDR = retTable.NewRow();
                    tmpDR["GRPID"] = applicationAccess.Grpid;
                    tmpDR["LOGINID"] = applicationAccess.Loginid;
                   
                    retTable.Rows.Add(tmpDR);
                }

            return retTable;
        }

    }
}
