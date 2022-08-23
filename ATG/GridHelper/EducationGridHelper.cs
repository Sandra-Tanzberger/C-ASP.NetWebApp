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
    public class EducationGridHelper
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

        public void InitializeEducationGrid(BO_PersonPrimaryKey pk)
        {
            //get user queue and set datatable for queue datagrid
            GridDataSource = _getGridDataSource(BO_Education.SelectAllByForeignKeyPersonID(pk));
        }

        public static GridBoundColumn[] GridColumnList()
        {
            GridBoundColumn[] retColList = new GridBoundColumn[5];

            GridBoundColumn tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "CollegeSchool";
            tmpCol.DataField = "CollegeSchool";
            tmpCol.HeaderText = "College/School";
            tmpCol.Visible = true;
            tmpCol.HeaderStyle.Width = Unit.Percentage(35);
            tmpCol.DataFormatString = "<nobr>{0}</nobr>";
            retColList[0] = tmpCol;

            tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "GraduationDate";
            tmpCol.DataField = "GraduationDate";
            tmpCol.HeaderText = "Graduation Date";
            tmpCol.Visible = true;
            tmpCol.HeaderStyle.Width = Unit.Percentage(20);
            tmpCol.DataFormatString = "<nobr>{0}</nobr>";
            retColList[1] = tmpCol;

            tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "DegreeObtained";
            tmpCol.DataField = "DegreeObtained";
            tmpCol.HeaderText = "Degree Obtained";
            tmpCol.Visible = true;
            tmpCol.HeaderStyle.Width = Unit.Percentage(45);
            tmpCol.DataFormatString = "<nobr>{0}</nobr>";
            retColList[2] = tmpCol;

            tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "PersonID";
            tmpCol.DataField = "PersonID";
            tmpCol.HeaderText = "Person Internal ID";
            tmpCol.Visible = false;
            retColList[3] = tmpCol;

            tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "EducationID";
            tmpCol.DataField = "EducationID";
            tmpCol.HeaderText = "Education Internal ID";
            tmpCol.Visible = false;
            retColList[4] = tmpCol;

            return retColList;
        }

        private DataTable _getGridDataTableStruct()
        {
            DataTable tmpDTbl = new DataTable();
            DataColumn tmpDCol = null;

            tmpDCol = new DataColumn("CollegeSchool");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("GraduationDate");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("DegreeObtained");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("EducationID");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("PersonID");
            tmpDTbl.Columns.Add(tmpDCol);

            return tmpDTbl;
        }

        private DataTable _getGridDataSource(BO_Educations Educations)
        {
            DataTable retTable = _getGridDataTableStruct();

            if (Educations != null)
            {
                foreach (BO_Education education in Educations)
                {
                    DataRow tmpDR = retTable.NewRow();
                    tmpDR["CollegeSchool"] = education.CollegeSchool;
                    tmpDR["DegreeObtained"] = education.DegreeObtained;
                    tmpDR["GraduationDate"] = (null == education.GraduationDate ? "" : DateTime.Parse(education.GraduationDate.ToString()).ToShortDateString());
                    tmpDR["EducationID"] = education.EducationID.ToString();
                    tmpDR["PersonID"] = education.PersonID.ToString();

                    retTable.Rows.Add(tmpDR);
                }
            }

            return retTable;
        }
    }
}