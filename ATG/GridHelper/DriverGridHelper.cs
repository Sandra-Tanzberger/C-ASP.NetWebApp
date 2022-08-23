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
    public class DriverGridHelper
    {
        /// <summary>
        /// Define the columns for the Providers's grid
        /// </summary>
        /// 

        private DataTable _gridDataSource;

        public DataTable GridDataSource
        {
            set { _gridDataSource = value; }
            get { return _gridDataSource;}
        }

        public void InitializeDriversGrid(BO_ProviderPrimaryKey pk, BO_ApplicationPrimaryKey ak, string PersonType)
        {
            //get user queue and set datatable for queue datagrid
            GridDataSource = _getGridDataSource(BO_ProviderPerson.SelectByApplicationPersonTypeForGrid(pk, ak, PersonType));
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
            tmpCol.UniqueName = "LastName";
            tmpCol.DataField = "LAST_NAME";
            tmpCol.HeaderText = "Last Name";
            tmpCol.Visible = true;
            tmpCol.HeaderStyle.Width = Unit.Percentage(15);
            tmpCol.AllowFiltering = false;
            retColList[3] = tmpCol;

            tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "FirstName";
            tmpCol.DataField = "FIRST_NAME";
            tmpCol.HeaderText = "First Name";
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
            tmpCol.UniqueName = "Title";
            tmpCol.DataField = "TITLE";
            tmpCol.HeaderText = "Title";
            tmpCol.Visible = true;
            tmpCol.HeaderStyle.Width = Unit.Percentage(10);
            tmpCol.AllowFiltering = false;
            retColList[6] = tmpCol;

            tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "DriversLicenseClassCode";
            tmpCol.DataField = "DRIVERS_LICENSE_CLASS_CODE";
            tmpCol.HeaderText = "Drivers License Class";
            tmpCol.Visible = true;
            tmpCol.HeaderStyle.Width = Unit.Percentage(15);
            tmpCol.AllowFiltering = true;
            retColList[7] = tmpCol;

            tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "DriversLicenseNum";
            tmpCol.DataField = "DRIVERS_LICENSE_NUM";
            tmpCol.HeaderText = "Drivers License Number";
            tmpCol.Visible = true;
            tmpCol.HeaderStyle.Width = Unit.Percentage(15);
            tmpCol.AllowFiltering = true;
            retColList[8] = tmpCol;

            tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "DriversLicenseState";
            tmpCol.DataField = "DRIVERS_LICENSE_STATE";
            tmpCol.HeaderText = "Drivers License State";
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
            tmpDCol = new DataColumn("APPLICATION_ID");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("PERSON_ID");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("LAST_NAME");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("FIRST_NAME");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("MIDDLE_INITIAL");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("TITLE");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("DRIVERS_LICENSE_CLASS_CODE");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("DRIVERS_LICENSE_NUM");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("DRIVERS_LICENSE_STATE");
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
                    tmpDR["LAST_NAME"] = providerPerson.BO_PersonDetail.LastName;
                    tmpDR["FIRST_NAME"] = providerPerson.BO_PersonDetail.FirstName;
                    tmpDR["MIDDLE_INITIAL"] = providerPerson.BO_PersonDetail.MiddleInitial;
                    tmpDR["TITLE"] = providerPerson.BO_PersonDetail.Title;
                    tmpDR["DRIVERS_LICENSE_CLASS_CODE"] = providerPerson.BO_PersonDetail.DriversLicenseClassCode;
                    tmpDR["DRIVERS_LICENSE_NUM"] = providerPerson.BO_PersonDetail.DriversLicenseNum;
                    tmpDR["DRIVERS_LICENSE_STATE"] = providerPerson.BO_PersonDetail.DriversLicenseState;

                    retTable.Rows.Add(tmpDR);
                }
            }

            return retTable;
        }
    }
}