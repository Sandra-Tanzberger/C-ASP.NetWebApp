using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using ATG;
using ATG.BusinessObject;
using System.Data;

namespace AppControl
{
    public partial class ParishesSubstationsForm : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void _Init()
        {
            rcbSubstationsState.AppendDataBoundItems = true;
            rcbSubstationsState.Items.Add(new RadComboBoxItem("", ""));
            rcbSubstationsState.DataSource = CommonFunc.getStates();
            rcbSubstationsState.DataTextField = "StateName";
            rcbSubstationsState.DataValueField = "StateCode";
            rcbSubstationsState.Height = Unit.Pixel(100);
            rcbSubstationsState.DataBind();
            rcbSubstationsState.SelectedValue = "LA";

            rcbSubstationsCity.AppendDataBoundItems = true;
            rcbSubstationsCity.Items.Add(new RadComboBoxItem("", ""));
            rcbSubstationsCity.DataSource = CommonFunc.getCitiesByState(rcbSubstationsState.SelectedValue.ToString());
            rcbSubstationsCity.DataTextField = "City";
            rcbSubstationsCity.DataValueField = "City";
            rcbSubstationsCity.Height = Unit.Pixel(100);
            rcbSubstationsCity.DataBind();
 
            rcbSubstationsParish.AppendDataBoundItems = true;
            rcbSubstationsParish.Items.Add(new RadComboBoxItem("", ""));
            rcbSubstationsParish.DataSource = BO_Parishe.SelectAll();
            rcbSubstationsParish.DataTextField = "ParishName";
            rcbSubstationsParish.DataValueField = "ParishCode";
            rcbSubstationsParish.Height = Unit.Pixel(100);
            rcbSubstationsParish.DataBind();
        }

        //update substation
        public void LoadSubstation(decimal substationID)
        {
            if (!IsPostBack)
            {
                _Init();

                BO_Substation substation = BO_Substation.SelectOne(new BO_SubstationPrimaryKey(CurrentProvider.PopsIntID, substationID));
                txtNumSubstations.Text = substation.NumSubstations.ToString();
                txtStreet.Text = substation.Street;
                if(substation.StateCode!=null)
                    rcbSubstationsState.SelectedValue = substation.StateCode;
                txtCityCode.Text = substation.SubstationCityCode;
                rcbSubstationsCity.AppendDataBoundItems = true;
                if (_CityFound((DataTable)CommonFunc.getCitiesByState(rcbSubstationsState.SelectedValue), substation.SubstationCityCode))
                {
                    rcbSubstationsCity.SelectedValue = substation.SubstationCityCode;
                    lblCityCode.Visible = false;
                    txtCityCode.Visible = false;
                }
                rcbSubstationsParish.SelectedValue = substation.SubstationParishCode;
                rcbSubstationsZip.AppendDataBoundItems = true;
                rcbSubstationsZip.Items.Add(new RadComboBoxItem("", ""));
                rcbSubstationsZip.DataSource = CommonFunc.getZipByCityState(rcbSubstationsCity.SelectedValue, rcbSubstationsState.SelectedValue);
                rcbSubstationsZip.DataTextField = "Zip";
                rcbSubstationsZip.DataValueField = "Zip";
                rcbSubstationsZip.Height = Unit.Pixel(100);
                rcbSubstationsZip.DataBind();
                rcbSubstationsZip.SelectedValue = substation.ZipCode;
                txtZipExtra.Text = substation.ZipCodeExtended;

                SubstationID = substationID;

                btnSubstationsUpdate.Visible = true;
            }
        }
        //insert substation
        public void LoadSubstation()
        {
            if (!IsPostBack)
            {
                _Init();

                lblCityCode.Visible = false;
                txtCityCode.Visible = false;
                btnSubstationsInsert.Visible = true;
            }
        }

        protected void Substation_Update(Object sender, EventArgs e)
        {
            BO_Substation substation = new BO_Substation();
            substation.PopsIntID = CurrentProvider.PopsIntID;
            substation.SubstationID = SubstationID;
            substation.NumSubstations = Convert.ToInt32(txtNumSubstations.Text);
            substation.Street = txtStreet.Text;
            substation.StateCode = rcbSubstationsState.SelectedValue;
            substation.SubstationCityCode = rcbSubstationsCity.SelectedValue;
            substation.SubstationParishCode = rcbSubstationsParish.SelectedValue;
            substation.ZipCode = rcbSubstationsZip.SelectedValue;
            substation.ZipCodeExtended = txtZipExtra.Text;
            substation.Update();

            Page.ClientScript.RegisterStartupScript(Page.GetType(), "CloseRebindSustations", "CloseAndRebind();", true);
        }

        protected void Substation_Insert(Object sender, EventArgs e)
        {
            BO_Substation substation = new BO_Substation();
            substation.PopsIntID = CurrentProvider.PopsIntID;
            substation.NumSubstations = Convert.ToInt32(txtNumSubstations.Text);
            substation.Street = txtStreet.Text;
            substation.StateCode = rcbSubstationsState.SelectedValue;
            substation.SubstationCityCode = rcbSubstationsCity.SelectedValue;
            substation.SubstationParishCode = rcbSubstationsParish.SelectedValue;
            substation.ZipCode = rcbSubstationsZip.SelectedValue;
            substation.ZipCodeExtended = txtZipExtra.Text;
            substation.Insert();

            Page.ClientScript.RegisterStartupScript(Page.GetType(), "CloseRebindSubstations", "CloseAndRebind();", true);
        }

        protected void rcbSubstationsState_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            rcbSubstationsZip.Text = "";
            rcbSubstationsCity.Text = "";
            rcbSubstationsCity.ClearSelection();
            rcbSubstationsCity.Items.Clear();
            rcbSubstationsCity.AppendDataBoundItems = true;
            rcbSubstationsCity.Items.Add(new RadComboBoxItem("", ""));
            rcbSubstationsCity.DataSource = CommonFunc.getCitiesByState(e.Value.ToString());
            rcbSubstationsCity.DataTextField = "City";
            rcbSubstationsCity.DataValueField = "City";
            rcbSubstationsCity.Height = Unit.Pixel(100);
            rcbSubstationsCity.DataBind();
        }


        protected void rcbSubstationsCity_SelectedIndexChanged(object o, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            rcbSubstationsZip.Text = "";
            rcbSubstationsZip.ClearSelection();
            rcbSubstationsZip.Items.Clear();
            rcbSubstationsZip.AppendDataBoundItems = true;
            rcbSubstationsZip.Items.Add(new RadComboBoxItem("", ""));
            rcbSubstationsZip.DataSource = CommonFunc.getZipByCityState(e.Value.ToString(), rcbSubstationsState.SelectedValue);
            rcbSubstationsZip.DataTextField = "Zip";
            rcbSubstationsZip.DataValueField = "Zip";
            rcbSubstationsZip.Height = Unit.Pixel(100);
            rcbSubstationsZip.DataBind();
        }

        bool _CityFound(DataTable table, string city)
        {
            bool _found = false;
            foreach (DataRow row in table.Rows)
            {
                if (row["City"].ToString() == city)
                {
                    _found = true;
                    break;
                }
            }
            return _found;
        }
        

        private BO_Provider CurrentProvider
        {
            get
            {
                return Session["CurrentProvider"] == null ? null : (BO_Provider)Session["CurrentProvider"];
            }
            set
            {
                Session["CurrentProvider"] = value;
            }
        }

        private decimal SubstationID
        {
            get
            {
                return (decimal)ViewState["SubstationID"];
            }

            set
            {
                ViewState["SubstationID"] = value;
            }
        }
    }
}