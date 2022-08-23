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
    public class LetterGridHelper
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

        public void InitializeLetterGrid(string ProgramID, string LetterType, string AnniverysaryMonth)
        {
            //get user queue and set datatable for queue datagrid
            GridDataSource = _getGridDataSource(BO_Letter.SelectLettersforSearchGrid(ProgramID, LetterType, AnniverysaryMonth));
        }

        public static GridBoundColumn[] GridColumnList()
        {
            GridBoundColumn[] retColList = new GridBoundColumn[6];

            GridBoundColumn tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "ApplicationID"; 
            tmpCol.DataField = "APPLICATION_ID";
            tmpCol.HeaderText = "Application ID";
            tmpCol.Visible = false;
            tmpCol.HeaderStyle.Width = Unit.Percentage(0);
            tmpCol.AllowFiltering = false;
            retColList[0] = tmpCol;

            tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "FacilityName";
            tmpCol.DataField = "FACILITY_NAME";
            tmpCol.HeaderText = "Facility";
            tmpCol.Visible = true;
            tmpCol.HeaderStyle.Width = Unit.Percentage(40);
            tmpCol.AllowFiltering = false;
            retColList[1] = tmpCol;

            tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "StateID";
            tmpCol.DataField = "STATE_ID";
            tmpCol.HeaderText = "State ID";
            tmpCol.Visible = true;
            tmpCol.HeaderStyle.Width = Unit.Percentage(20);
            tmpCol.AllowFiltering = false;
            retColList[2] = tmpCol;

            tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "LetterType";
            tmpCol.DataField = "LETTER_TYPE";
            tmpCol.HeaderText = "Letter Type";
            tmpCol.Visible = true;
            tmpCol.HeaderStyle.Width = Unit.Percentage(40);
            tmpCol.AllowFiltering = false;
            retColList[3] = tmpCol;

            tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "LetterName";
            tmpCol.DataField = "LETTER_DISPLAY_NAME";
            tmpCol.HeaderText = "Letter Name";
            tmpCol.Visible = false;
            tmpCol.HeaderStyle.Width = Unit.Percentage(0);
            tmpCol.AllowFiltering = true;
            retColList[4] = tmpCol;

            tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "LetterID";
            tmpCol.DataField = "LETTER_ID";
            tmpCol.HeaderText = "Letter ID";
            tmpCol.Visible = false;
            tmpCol.HeaderStyle.Width = Unit.Percentage(0);
            tmpCol.AllowFiltering = true;
            retColList[5] = tmpCol;

            return retColList;
        }

        private DataTable _getGridDataTableStruct()
        {
            DataTable tmpDTbl = new DataTable();
            DataColumn tmpDCol = null;

            tmpDCol = new DataColumn("APPLICATION_ID");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("FACILITY_NAME");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("STATE_ID");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("LETTER_TYPE");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("LETTER_DISPLAY_NAME");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("LETTER_ID");
            tmpDTbl.Columns.Add(tmpDCol);

            return tmpDTbl;
        }

        private DataTable _getGridDataSource(BO_Letters letterQueue)
        {
            DataTable retTable = _getGridDataTableStruct();

            foreach (BO_Letter letter in letterQueue)
            {
                DataRow tmpDR = retTable.NewRow();
                tmpDR["APPLICATION_ID"] = letter.ApplicationID;
                tmpDR["FACILITY_NAME"] = letter.FacilityName;
                tmpDR["STATE_ID"] = letter.StateID;
                tmpDR["LETTER_TYPE"] = letter.LetterType;
                tmpDR["LETTER_DISPLAY_NAME"] = letter.LetterDisplayName;
                tmpDR["LETTER_ID"] = letter.LetterID;

                retTable.Rows.Add(tmpDR);
            }

            return retTable;
        }
    }
}
