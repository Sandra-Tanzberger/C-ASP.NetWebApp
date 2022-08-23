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
    public class PersonnelGridHelper
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

        public void InitializePersonnelGrid(BO_ProviderPrimaryKey pk, BO_ApplicationPrimaryKey ak)
        {
            //get user queue and set datatable for queue datagrid
            GridDataSource = _getGridDataSource(BO_ProviderPerson.SelectPersonnelForGrid(pk, ak));
        }

        public static GridBoundColumn[] GridColumnList()
        {
            GridBoundColumn[] retColList = new GridBoundColumn[8];

            GridBoundColumn tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "PopsIntID";
            tmpCol.DataField = "POPS_INT_ID";
            tmpCol.HeaderText = "Pops Int ID";
            tmpCol.Visible = false;
            tmpCol.HeaderStyle.Width = Unit.Percentage(0);
            tmpCol.AllowFiltering = false;
            retColList[0] = tmpCol;

            tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "ApplicationID";
            tmpCol.DataField = "APPLICATION_ID";
            tmpCol.HeaderText = "Application ID";
            tmpCol.Visible = false;
            tmpCol.HeaderStyle.Width = Unit.Percentage(0);
            tmpCol.AllowFiltering = false;
            retColList[1] = tmpCol;

            tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "PersonID";
            tmpCol.DataField = "PERSON_ID";
            tmpCol.HeaderText = "Person ID";
            tmpCol.Visible = false;
            tmpCol.HeaderStyle.Width = Unit.Percentage(0);
            tmpCol.AllowFiltering = false;
            retColList[2] = tmpCol;

            tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "PersonTypeDesc";
            tmpCol.DataField = "PERSON_TYPE_DESC";
            tmpCol.HeaderText = "Title";
            tmpCol.Visible = true;
            tmpCol.HeaderStyle.Width = Unit.Percentage(10);
            tmpCol.AllowFiltering = false;
            retColList[3] = tmpCol;

            tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "LastName";
            tmpCol.DataField = "LAST_NAME";
            tmpCol.HeaderText = "Last Name";
            tmpCol.Visible = true;
            tmpCol.HeaderStyle.Width = Unit.Percentage(15);
            tmpCol.AllowFiltering = false;
            retColList[4] = tmpCol;

            tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "MiddleInitial";
            tmpCol.DataField = "MIDDLE_INITIAL";
            tmpCol.HeaderText = "Middle Initial";
            tmpCol.Visible = true;
            tmpCol.HeaderStyle.Width = Unit.Percentage(5);
            tmpCol.AllowFiltering = false;
            retColList[5] = tmpCol;

            tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "FirstName";
            tmpCol.DataField = "FIRST_NAME";
            tmpCol.HeaderText = "First Name";
            tmpCol.Visible = true;
            tmpCol.HeaderStyle.Width = Unit.Percentage(15);
            tmpCol.AllowFiltering = false;
            retColList[6] = tmpCol;

            tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "PrimaryFacAdmin";
            tmpCol.DataField = "PRIMARY_FAC_ADMIN";
            tmpCol.HeaderText = "Primary FAC Admin";
            tmpCol.Visible = false;
            tmpCol.HeaderStyle.Width = Unit.Percentage(15);
            tmpCol.AllowFiltering = false;
            retColList[7] = tmpCol;

            return retColList;
        }

        private DataTable _getGridDataTableStruct()
        {
            DataTable tmpDTbl = new DataTable();
            DataColumn tmpDCol = null;

            tmpDCol = new DataColumn("POPS_INT_ID");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("APPLICATION_ID");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("PERSON_ID");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("PERSON_TYPE_DESC");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("LAST_NAME");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("MIDDLE_INITIAL");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("FIRST_NAME");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("PRIMARY_FAC_ADMIN");
            tmpDTbl.Columns.Add(tmpDCol);

            return tmpDTbl;
        }

        private DataTable _getGridDataSource(BO_ProviderPeople ProviderPeople)
        {
            DataTable retTable = _getGridDataTableStruct();

            if (ProviderPeople != null)
            {
                foreach (BO_ProviderPerson providerPerson in ProviderPeople)
                {
                    DataRow tmpDR = retTable.NewRow();
                    tmpDR["POPS_INT_ID"] = providerPerson.PopsIntID;
                    tmpDR["APPLICATION_ID"] = providerPerson.ApplicationID;
                    tmpDR["PERSON_ID"] = providerPerson.PersonID;
                    tmpDR["PERSON_TYPE_DESC"] = providerPerson.PersonTypeDesc;
                    tmpDR["LAST_NAME"] = providerPerson.BO_PersonDetail.LastName;
                    tmpDR["MIDDLE_INITIAL"] = providerPerson.BO_PersonDetail.MiddleInitial;
                    tmpDR["FIRST_NAME"] = providerPerson.BO_PersonDetail.FirstName;
                    tmpDR["PRIMARY_FAC_ADMIN"] = providerPerson.PrimaryFacAdmin;
                    
                    retTable.Rows.Add(tmpDR);
                }
            }

            return retTable;
        }
    }
}