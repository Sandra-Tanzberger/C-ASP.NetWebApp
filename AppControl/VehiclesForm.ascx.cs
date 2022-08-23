using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using ATG;
using ATG.BusinessObject;
using System.Globalization;
using ATG.Database;
using System.Data;

namespace AppControl
{
    public partial class VehiclesForm : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ShowHideFields();
        }

        private void ShowHideFields()
        {
            if ("NE".Contains(CurrentProvider.ProgramID))
            {
                lblLicensePlateNumber.Visible = true;
                txtLicensePlateNumber.Visible = true;
                lblACAP.Visible = true;
                txtACAP.Visible = true;
                lblHCAP.Visible = true;
                txtHCAP.Visible = true;
            }
        }

        private void _Init()
        {
            if ("NE".Contains(CurrentProvider.ProgramID))
            {
                rcbType.AppendDataBoundItems = true;
                rcbType.Items.Add(new RadComboBoxItem("", ""));
                rcbType.DataSource = BO_LookupValue.SelectByFieldByKeyAndProgram("TYPE_VEHICLE", "NE");
                rcbType.DataTextField = "Valdesc";
                rcbType.DataValueField = "LookupVal";
                rcbType.Height = Unit.Pixel(100);
                rcbType.DataBind();

                rcbMake.AppendDataBoundItems = true;
                rcbMake.Items.Add(new RadComboBoxItem("", ""));
                rcbMake.DataSource = BO_LookupValue.SelectByFieldByKeyAndProgram("VEHICLE_MAKE", "NE");
                rcbMake.DataTextField = "Valdesc";
                rcbMake.DataValueField = "LookupVal";
                rcbMake.Height = Unit.Pixel(100);
                rcbMake.DataBind();
            }
            else if("MT".Contains(CurrentProvider.ProgramID))
            {
                rcbType.AppendDataBoundItems = true;
                rcbType.Items.Add(new RadComboBoxItem("", ""));
                rcbType.DataSource = BO_LookupValue.SelectByFieldByKeyAndProgram("TYPE_VEHICLE", "MT");
                rcbType.DataTextField = "Valdesc";
                rcbType.DataValueField = "LookupVal";
                rcbType.Height = Unit.Pixel(100);
                rcbType.DataBind();

                rcbMake.AppendDataBoundItems = true;
                rcbMake.Items.Add(new RadComboBoxItem("", ""));
                rcbMake.DataSource = BO_LookupValue.SelectByFieldByKeyAndProgram("VEHICLE_MAKE", "MT");
                rcbMake.DataTextField = "Valdesc";
                rcbMake.DataValueField = "LookupVal";
                rcbMake.Height = Unit.Pixel(100);
                rcbMake.DataBind();

                rcbWing.AppendDataBoundItems = true;
                rcbWing.Items.Add(new RadComboBoxItem("", ""));
                rcbWing.DataSource = BO_LookupValue.SelectByFieldByKeyAndProgram("WING", "MT");
                rcbWing.DataTextField = "Valdesc";
                rcbWing.DataValueField = "LookupVal";
                rcbWing.Height = Unit.Pixel(100);
                rcbWing.DataBind();
            }
        }

        //update substation
        public void LoadVehicle(decimal vecRecID)
        {
            if (!IsPostBack)
            {
                _Init();

                BO_Vehicle vehicle = BO_Vehicle.SelectOne(new BO_VehiclePrimaryKey(vecRecID, CurrentProvider.PopsIntID));
                rcbType.SelectedValue = vehicle.TypeVehicle;
                if (vehicle.TypeVehicle == "C")
                {
                    rcbMake.Text = "";
                    rcbMake.ClearSelection();
                    rcbMake.Items.Clear();
                    rcbMake.AppendDataBoundItems = true;
                    rcbMake.Items.Add(new RadComboBoxItem("", ""));
                    rcbMake.DataSource = BO_LookupValue.SelectByFieldByKeyAndProgram("AIRCRAFT_MAKE", "MT");
                    rcbMake.DataTextField = "Valdesc";
                    rcbMake.DataValueField = "LookupVal";
                    rcbMake.Height = Unit.Pixel(100);
                    rcbMake.DataBind();

                    //show fields by type
                    lblLicensePlateNumber.Visible = false;
                    txtLicensePlateNumber.Visible = false;
                    lblFAALIC.Visible = true;
                    txtFAALIC.Visible = true;
                    lblWing.Visible = true;
                    rcbWing.Visible = true;
                }
                else
                {
                    //show fields by type
                    lblLicensePlateNumber.Visible = true;
                    txtLicensePlateNumber.Visible = true;
                    lblFAALIC.Visible = false;
                    txtFAALIC.Visible = false;
                    lblWing.Visible = false;
                    rcbWing.Visible = false;
                }
                txtMakeDescription.Text = vehicle.MakeDescription;
                if (txtMakeDescription.Text != String.Empty)
                {
                    getMakeDescriptionCityList(txtMakeDescription.Text);
                }
                if (vehicle.VehicleBaseDescription != String.Empty)
                {
                    listBaseDescription.SelectedValue = vehicle.VehicleBaseDescription;
                }
                txtModel.Text = vehicle.VehicleModelYear;
                txtVIN.Text = vehicle.VehicleVin;
                txtUnit.Text = vehicle.VehicleUnit;
                txtLicensePlateNumber.Text = vehicle.VehicleLicensePlate;
                if(String.IsNullOrEmpty(vehicle.VehicleBase))
                    txtBase.Text = "LA";
                else
                    txtBase.Text = vehicle.VehicleBase;
                txtDecal.Text = vehicle.VehicleDecal;
                if(vehicle.VehicleDecalExpDate!=null)
                    if(!vehicle.VehicleDecalExpDate.Equals(String.Empty))
                        rdpDecalExpDate.SelectedDate = vehicle.VehicleDecalExpDate;
                rcbMake.SelectedValue = vehicle.MakeCode;
                txtACAP.Text = vehicle.TotalCapacityAmbulatory.ToString();
                txtHCAP.Text = vehicle.TotalCapacityHandicap.ToString();
                rcbWing.SelectedValue = vehicle.Wing;
                txtFAALIC.Text = vehicle.FaaLicNum;

                VehicleRecordID = vecRecID;

                btnVehicleUpdate.Visible = true;
            }
        }
        //insert substation
        public void LoadVehicle()
        {
            if (!IsPostBack)
            {
                _Init();

                txtBase.Text = "LA";
                btnVehicleInsert.Visible = true;
            }
        }

        protected void Vehicle_Update(Object sender, EventArgs e)
        {
            BO_Vehicle currentVehicle = BO_Vehicle.SelectOne(new BO_VehiclePrimaryKey(VehicleRecordID, CurrentProvider.PopsIntID));
            if (checkDecalAlreadyExists() & (0 != String.Compare(currentVehicle.VehicleDecal.ToString(), txtDecal.Text, true)))
            {
                //rs - 08/27/2013 - POPS 10.8 Release - Issue# 17690- Do not allow duplicates
                // There is already a vehicle record with VEHICLE_DECAL entered value
                // So do not let the user add another vehicle record with same VEHICLE_DECAL value
                // Show a message that duplicate VEHICLE_DECAL value is not allowed.
                string errorMsg = string.Empty;
                errorMsg = "The entered Decal Number already Exists. Please enter another Decal Number.";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('" + errorMsg + "');", true);
            }
            else
            {
                BO_Vehicle vehicle = new BO_Vehicle();
                vehicle.PopsIntID = CurrentProvider.PopsIntID;
                vehicle.VehicleRecID = VehicleRecordID;
                vehicle.MakeCode = rcbMake.SelectedValue;
                vehicle.MakeDescription = txtMakeDescription.Text;
                vehicle.VehicleModelYear = txtModel.Text;
                vehicle.VehicleVin = txtVIN.Text.ToUpper();
                vehicle.VehicleUnit = txtUnit.Text;
                vehicle.VehicleLicensePlate = txtLicensePlateNumber.Text;
                vehicle.VehicleBase = txtBase.Text;
                vehicle.VehicleBaseDescription = listBaseDescription.SelectedValue;
                vehicle.VehicleDecal = txtDecal.Text;
                vehicle.VehicleDecalExpDate = rdpDecalExpDate.SelectedDate;//((DateTime)rdpDecalExpDate.SelectedDate).Date.ToShortDateString().Replace("/", "");
                vehicle.TypeVehicle = rcbType.SelectedValue;
                vehicle.TotalCapacityAmbulatory = txtACAP.Text.Equals(String.Empty) ? 0 : Convert.ToInt32(txtACAP.Text);
                vehicle.TotalCapacityHandicap = txtHCAP.Text.Equals(String.Empty) ? 0 : Convert.ToInt32(txtHCAP.Text);
                if (!rcbWing.SelectedValue.Equals(string.Empty))
                    vehicle.Wing = rcbWing.SelectedValue;
                vehicle.FaaLicNum = txtFAALIC.Text;
                vehicle.Update();

                Page.ClientScript.RegisterStartupScript(Page.GetType(), "CloseRebindVehicle", "CloseAndRebind();", true);
            }
        }
        protected bool checkDecalAlreadyExists()
        {
            DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;

            // Pass the specified field and its value to the stored procedure.
            oDatabaseHelper.AddParameter("@ProgramID", DBNull.Value);
            oDatabaseHelper.AddParameter("@StateID", DBNull.Value);
            oDatabaseHelper.AddParameter("@SortBy", 2);
            // The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
            oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);

            IDataReader dr = oDatabaseHelper.ExecuteReader("ATG_Vehicles_SelectByProgramVehicleProviderDecal", ref ExecutionState);
            string enteredDecalVal = txtDecal.Text;
            bool DecalAlreadyExists = false;
            while (dr.Read())
            {
                if (0 == String.Compare(dr["VEHICLE_DECAL"].ToString(), enteredDecalVal, true))
                {
                    DecalAlreadyExists = true;
                }
            }
            dr.Close();
            oDatabaseHelper.Dispose();

            return DecalAlreadyExists;
        }
        protected void Vehicle_Insert(Object sender, EventArgs e)
        {


            if (checkDecalAlreadyExists())
            {
                //rs - 08/27/2013 - POPS 10.8 Release - Issue# 17690- Do not allow duplicates
                // There is already a vehicle record with VEHICLE_DECAL entered value
                // So do not let the user add another vehicle record with same VEHICLE_DECAL value
                // Show a message that duplicate VEHICLE_DECAL value is not allowed.
                string errorMsg = string.Empty;
                errorMsg = "The entered Decal Number already Exists. Please enter another Decal Number.";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('" + errorMsg + "');", true);
            }
            else
            {
                BO_Vehicle vehicle = new BO_Vehicle();
                vehicle.PopsIntID = CurrentProvider.PopsIntID;
                vehicle.MakeCode = rcbMake.SelectedValue;
                vehicle.MakeDescription = txtMakeDescription.Text;
                vehicle.VehicleModelYear = txtModel.Text;
                vehicle.VehicleVin = txtVIN.Text.ToUpper();
                vehicle.VehicleUnit = txtUnit.Text;
                vehicle.VehicleLicensePlate = txtLicensePlateNumber.Text;
                vehicle.VehicleBase = txtBase.Text;
                vehicle.VehicleBaseDescription = listBaseDescription.SelectedValue;
                vehicle.VehicleDecal = txtDecal.Text;
                vehicle.VehicleDecalExpDate = rdpDecalExpDate.SelectedDate;//((DateTime)rdpDecalExpDate.SelectedDate).Date.ToShortDateString().Replace("/", "");
                vehicle.TypeVehicle = rcbType.SelectedValue;
                vehicle.TotalCapacityAmbulatory = txtACAP.Text.Equals(String.Empty) ? 0 : Convert.ToInt32(txtACAP.Text);
                vehicle.TotalCapacityHandicap = txtHCAP.Text.Equals(String.Empty) ? 0 : Convert.ToInt32(txtHCAP.Text);
                if (!rcbWing.SelectedValue.Equals(string.Empty))
                    vehicle.Wing = rcbWing.SelectedValue;
                vehicle.Insert();
                _addVehicleTotals(vehicle.TypeVehicle);

                Page.ClientScript.RegisterStartupScript(Page.GetType(), "CloseRebindVehicle", "CloseAndRebind();", true);
            }
        }

        protected void rcbType_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if ("MT".Contains(CurrentProvider.ProgramID))
            {
                if (e.Value == "C")
                {
                    rcbMake.Text = "";
                    rcbMake.ClearSelection();
                    rcbMake.Items.Clear();
                    rcbMake.AppendDataBoundItems = true;
                    rcbMake.Items.Add(new RadComboBoxItem("", ""));
                    rcbMake.DataSource = BO_LookupValue.SelectByFieldByKeyAndProgram("AIRCRAFT_MAKE", "MT");
                    rcbMake.DataTextField = "Valdesc";
                    rcbMake.DataValueField = "LookupVal";
                    rcbMake.Height = Unit.Pixel(100);
                    rcbMake.DataBind();

                    //show fields by type
                    lblLicensePlateNumber.Visible = false;
                    txtLicensePlateNumber.Visible = false;
                    lblFAALIC.Visible = true;
                    txtFAALIC.Visible = true;
                    lblWing.Visible = true;
                    rcbWing.Visible = true;
                }
                else
                {
                    rcbMake.Text = "";
                    rcbMake.ClearSelection();
                    rcbMake.Items.Clear();
                    rcbMake.AppendDataBoundItems = true;
                    rcbMake.Items.Add(new RadComboBoxItem("", ""));
                    rcbMake.DataSource = BO_LookupValue.SelectByFieldByKeyAndProgram("VEHICLE_MAKE", "MT");
                    rcbMake.DataTextField = "Valdesc";
                    rcbMake.DataValueField = "LookupVal";
                    rcbMake.Height = Unit.Pixel(100);
                    rcbMake.DataBind();

                    //show fields by type
                    lblLicensePlateNumber.Visible = true;
                    txtLicensePlateNumber.Visible = true;
                    lblFAALIC.Visible = false;
                    txtFAALIC.Visible = false;
                    lblWing.Visible = false;
                    rcbWing.Visible = false;
                }
            }
        }

        protected void txtZip_TextChanged(object o, EventArgs e)
        {
            getMakeDescriptionCityList(txtMakeDescription.Text);
        }

        private void getMakeDescriptionCityList(string zipCode)
        {
            listBaseDescription.ClearSelection();
            listBaseDescription.Items.Clear();
            listBaseDescription.AppendDataBoundItems = true;
            //listBaseDescription.Items.Add(new RadComboBoxItem("Select City", ""));
            listBaseDescription.DataSource = CommonFunc.getCitiesByZip(zipCode);
            listBaseDescription.DataTextField = "City";
            listBaseDescription.DataValueField = "City";
            listBaseDescription.Height = Unit.Pixel(100);
            listBaseDescription.DataBind();
        }

        private BO_Application CurrentAppProvider
        {
            get
            {
                return Session["CurrentAppProvider"] == null ? null : (BO_Application)Session["CurrentAppProvider"];
            }
        }

        private BO_Provider CurrentProvider
        {
            get
            {
                return Session["CurrentProvider"] == null ? null : (BO_Provider)Session["CurrentProvider"];
            }
        }

        private decimal VehicleRecordID
        {
            get
            {
                return (decimal)ViewState["VehicleRecordID"];
            }

            set
            {
                ViewState["VehicleRecordID"] = value;
            }
        }

        private DateTime FormatStringToDate(string date)
        {
            //for known MMddYYYY date
            char[] array = date.ToCharArray();
            string formattedDate = array[0].ToString() + array[1].ToString() + "-" + array[2].ToString() + array[3].ToString() + "-" + array[4].ToString() + array[5].ToString() + array[6].ToString() + array[7].ToString();
            return DateTime.Parse(formattedDate);
        }

        private void _addVehicleTotals(string vehicleType)
        {
            switch (vehicleType.ToUpper())
            {
                case "C":
                    CurrentAppProvider.NoOfAirAmbulances = (Int32.Parse(CurrentAppProvider.NoOfAirAmbulances) + 1).ToString();
                    break;
                case "S":
                    CurrentAppProvider.NoOfSprintVehicles = (Int32.Parse(CurrentAppProvider.NoOfSprintVehicles) + 1).ToString();
                    break;
                case "G":
                    CurrentAppProvider.NoOfGroundAmbulances = (Int32.Parse(CurrentAppProvider.NoOfGroundAmbulances) + 1).ToString();
                    break;
                case "A":
                    CurrentAppProvider.NoOfAmbulatoryVehicles = (Int32.Parse(CurrentAppProvider.NoOfAmbulatoryVehicles) + 1).ToString();
                    break;
                //case "B"://not yet implemented
                    //break;
                case "H":
                    CurrentAppProvider.NoOfHandicappedVehicles = (Int32.Parse(CurrentAppProvider.NoOfHandicappedVehicles) + 1).ToString();
                    break;
            }
        }
    }
}