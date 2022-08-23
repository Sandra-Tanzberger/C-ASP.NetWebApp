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
    public class ParishesSubstationsGridHelper
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

        public void InitializeSubstationsGrid(BO_ProviderPrimaryKey pk)
        {
            //get user queue and set datatable for queue datagrid
            GridDataSource = _getGridDataSource(BO_Substation.SelectAllByPopsIntID(pk));
        }

        public static GridBoundColumn[] GridColumnList()
        {
            GridBoundColumn[] retColList = new GridBoundColumn[6];

            GridBoundColumn tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "PopsIntID";
            tmpCol.DataField = "POPS_INT_ID";
            tmpCol.HeaderText = "Pops Int ID";
            tmpCol.Visible = false;
            tmpCol.HeaderStyle.Width = Unit.Percentage(0);
            tmpCol.AllowFiltering = false;
            retColList[0] = tmpCol;

            tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "SubstationID";
            tmpCol.DataField = "SUBSTATION_ID";
            tmpCol.HeaderText = "Substation ID";
            tmpCol.Visible = false;
            tmpCol.HeaderStyle.Width = Unit.Percentage(0);
            tmpCol.AllowFiltering = false;
            retColList[1] = tmpCol;

            tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "NumSubstations";
            tmpCol.DataField = "NUM_SUBSTATIONS";
            tmpCol.HeaderText = "No. of Substations";
            tmpCol.Visible = true;
            tmpCol.HeaderStyle.Width = Unit.Percentage(5);
            tmpCol.AllowFiltering = false;
            retColList[2] = tmpCol;

            tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "CityCode";
            tmpCol.DataField = "SUBSTATION_CITY_CODE";
            tmpCol.HeaderText = "City";
            tmpCol.Visible = true;
            tmpCol.HeaderStyle.Width = Unit.Percentage(15);
            tmpCol.AllowFiltering = false;
            retColList[3] = tmpCol;

            //tmpCol = new GridBoundColumn();
            //tmpCol.UniqueName = "City";
            //tmpCol.DataField = "CITY";
            //tmpCol.HeaderText = "City";
            //tmpCol.Visible = true;
            //tmpCol.HeaderStyle.Width = Unit.Percentage(15);
            //tmpCol.AllowFiltering = false;
            //retColList[4] = tmpCol;

            tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "ParishCode";
            tmpCol.DataField = "SUBSTATION_PARISH_CODE";
            tmpCol.HeaderText = "Parish Code";
            tmpCol.Visible = true;
            tmpCol.HeaderStyle.Width = Unit.Percentage(10);
            tmpCol.AllowFiltering = false;
            retColList[4] = tmpCol;

            tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "Parish";
            tmpCol.DataField = "PARISH_NAME";
            tmpCol.HeaderText = "Parish";
            tmpCol.Visible = true;
            tmpCol.HeaderStyle.Width = Unit.Percentage(15);
            tmpCol.AllowFiltering = false;
            retColList[5] = tmpCol;

            return retColList;
        }

        private DataTable _getGridDataTableStruct()
        {
            DataTable tmpDTbl = new DataTable();
            DataColumn tmpDCol = null;

            tmpDCol = new DataColumn("POPS_INT_ID");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("SUBSTATION_ID");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("NUM_SUBSTATIONS");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("SUBSTATION_CITY_CODE");
            tmpDTbl.Columns.Add(tmpDCol);
            //tmpDCol = new DataColumn("CITY");
            //tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("SUBSTATION_PARISH_CODE");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("PARISH_NAME");
            tmpDTbl.Columns.Add(tmpDCol);

            return tmpDTbl;
        }

        private DataTable _getGridDataSource(BO_Substations substations)
        {
            DataTable retTable = _getGridDataTableStruct();

            if (substations != null)
            {
                foreach (BO_Substation substation in substations)
                {
                    DataRow tmpDR = retTable.NewRow();
                    tmpDR["POPS_INT_ID"] = substation.PopsIntID;
                    tmpDR["SUBSTATION_ID"] = substation.SubstationID;
                    tmpDR["NUM_SUBSTATIONS"] = substation.NumSubstations;
                    tmpDR["SUBSTATION_CITY_CODE"] = substation.SubstationCityCode;
                    tmpDR["SUBSTATION_PARISH_CODE"] = substation.SubstationParishCode;
                    tmpDR["PARISH_NAME"] = substation.ParishName;

                    retTable.Rows.Add(tmpDR);
                }
            }

            return retTable;
        }
    }
}