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
    public class VehiclesGridHelper
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

        public void InitializeVehiclesGrid(BO_ProviderPrimaryKey pk, string programID)
        {
            //get user queue and set datatable for queue datagrid
            GridDataSource = _getGridDataSource(BO_Vehicle.SelectAllByForeignKeyPopsIntID(pk), programID);
        }

        public static GridBoundColumn[] GridColumnList()
        {
            GridBoundColumn[] retColList = new GridBoundColumn[10];

            GridBoundColumn tmpCol;

            tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "VehicleUnit";
            tmpCol.DataField = "VEHICLE_UNIT";
            tmpCol.HeaderText = "Unit #";
            tmpCol.Visible = true;
            tmpCol.HeaderStyle.Width = Unit.Percentage(5);
            tmpCol.AllowFiltering = false;
            retColList[0] = tmpCol;

            tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "VehicleRecID";
            tmpCol.DataField = "VEHICLE_REC_ID";
            tmpCol.HeaderText = "Vehicle Record ID";
            tmpCol.Visible = false;
            tmpCol.HeaderStyle.Width = Unit.Percentage(0);
            tmpCol.AllowFiltering = false;
            retColList[1] = tmpCol;

            tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "PopsIntID";
            tmpCol.DataField = "POPS_INT_ID";
            tmpCol.HeaderText = "Pops Int ID";
            tmpCol.Visible = false;
            tmpCol.HeaderStyle.Width = Unit.Percentage(0);
            tmpCol.AllowFiltering = false;
            retColList[2] = tmpCol;

            tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "MakeCode";
            tmpCol.DataField = "MAKE_CODE";
            tmpCol.HeaderText = "Make";
            tmpCol.Visible = true;
            tmpCol.HeaderStyle.Width = Unit.Percentage(5);
            tmpCol.AllowFiltering = false;
            retColList[3] = tmpCol;

            tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "MakeDescription";
            tmpCol.DataField = "MAKE_DESCRIPTION";
            tmpCol.HeaderText = "Make Description";
            tmpCol.Visible = false;
            tmpCol.HeaderStyle.Width = Unit.Percentage(15);
            tmpCol.AllowFiltering = false;
            retColList[4] = tmpCol;

            tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "VehicleModelYear";
            tmpCol.DataField = "VEHICLE_MODEL_YEAR";
            tmpCol.HeaderText = "Model";
            tmpCol.Visible = true;
            tmpCol.HeaderStyle.Width = Unit.Percentage(5);
            tmpCol.AllowFiltering = false;
            retColList[5] = tmpCol;

            tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "VehicleVin";
            tmpCol.DataField = "VEHICLE_VIN";
            tmpCol.HeaderText = "VIN";
            tmpCol.Visible = true;
            tmpCol.HeaderStyle.Width = Unit.Percentage(10);
            tmpCol.AllowFiltering = false;
            retColList[6] = tmpCol;

            tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "VehicleDecal";
            tmpCol.DataField = "VEHICLE_DECAL";
            tmpCol.HeaderText = "Decal #";
            tmpCol.Visible = true;
            tmpCol.HeaderStyle.Width = Unit.Percentage(10);
            tmpCol.AllowFiltering = false;
            retColList[7] = tmpCol;

            tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "VehicleLicensePlate";
            tmpCol.DataField = "VEHICLE_LICENSE_PLATE";
            tmpCol.HeaderText = "License Plate #";
            tmpCol.Visible = true;
            tmpCol.HeaderStyle.Width = Unit.Percentage(10);
            tmpCol.AllowFiltering = false;
            retColList[8] = tmpCol;

            tmpCol = new GridBoundColumn();
            tmpCol.UniqueName = "VehicleType";
            tmpCol.DataField = "VEHICLE_TYPE";
            tmpCol.HeaderText = "Vehicle Type";
            tmpCol.Visible = true;
            tmpCol.HeaderStyle.Width = Unit.Percentage(10);
            tmpCol.AllowFiltering = false;
            retColList[9] = tmpCol;

            return retColList;
        }

        private DataTable _getGridDataTableStruct()
        {
            DataTable tmpDTbl = new DataTable();
            DataColumn tmpDCol = null;

            tmpDCol = new DataColumn("VEHICLE_UNIT");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("VEHICLE_REC_ID");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("POPS_INT_ID");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("MAKE_CODE");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("MAKE_DESCRIPTION");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("VEHICLE_MODEL_YEAR");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("VEHICLE_VIN");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("VEHICLE_DECAL");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("VEHICLE_LICENSE_PLATE");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("VEHICLE_TYPE");
            tmpDTbl.Columns.Add(tmpDCol);

            return tmpDTbl;
        }

        private DataTable _getGridDataSource(BO_Vehicles vehicles, string programID)
        {
            DataTable retTable = _getGridDataTableStruct();

            if (vehicles != null)
            {
                foreach (BO_Vehicle vehicle in vehicles)
                {
                    DataRow tmpDR = retTable.NewRow();
                    tmpDR["VEHICLE_UNIT"] = vehicle.VehicleUnit;
                    tmpDR["VEHICLE_REC_ID"] = vehicle.VehicleRecID;
                    tmpDR["POPS_INT_ID"] = vehicle.PopsIntID;
                    tmpDR["MAKE_CODE"] = vehicle.MakeCode;
                    tmpDR["MAKE_DESCRIPTION"] = vehicle.MakeDescription;
                    tmpDR["VEHICLE_MODEL_YEAR"] = vehicle.VehicleModelYear;
                    tmpDR["VEHICLE_VIN"] = vehicle.VehicleVin;
                    tmpDR["VEHICLE_DECAL"] = vehicle.VehicleDecal;
                    if (vehicle.TypeVehicle.ToUpper() == "C")
                        tmpDR["VEHICLE_LICENSE_PLATE"] = vehicle.FaaLicNum;
                    else
                        tmpDR["VEHICLE_LICENSE_PLATE"] = vehicle.VehicleLicensePlate;
                    tmpDR["VEHICLE_TYPE"] = _getLookupValDesc(BO_LookupValue.SelectByFieldByKeyAndProgram("TYPE_VEHICLE", programID), vehicle.TypeVehicle.Trim());

                    retTable.Rows.Add(tmpDR);
                }
            }

            return retTable;
        }

        private string _getLookupValDesc(BO_LookupValues values, string typeVehicleCode)
        {
            string _desc = "";
            foreach (BO_LookupValue value in values)
            {
                if (value.LookupVal == typeVehicleCode)
                    _desc = value.Valdesc;
            }
            return _desc;
        }
    }
}