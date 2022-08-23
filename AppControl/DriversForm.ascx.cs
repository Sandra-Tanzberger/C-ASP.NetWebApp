using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using ATG;
using ATG.BusinessObject;

namespace AppControl
{
    public partial class DriversForm : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        //update driver person
        public void LoadDriver(decimal personID)
        {
            if (!IsPostBack)
            {
                BO_Person boPerson = BO_Person.SelectOne(new BO_PersonPrimaryKey(personID));
                txtTitle.Text = boPerson.Title;
                txtFirstName.Text = boPerson.FirstName;
                txtMiddleInt.Text = boPerson.MiddleInitial;
                txtLastName.Text = boPerson.LastName;
                ddlDriversLicenseClass.DataSource = BO_LookupValue.SelectByFieldByKeyAndProgram("DRIVING_LICENSE_CLASS", "NE");
                ddlDriversLicenseClass.DataTextField = "Valdesc";
                ddlDriversLicenseClass.DataValueField = "LookupVal";
                ddlDriversLicenseClass.DataBind();
                ddlDriversLicenseClass.SelectedValue = boPerson.DriversLicenseClassCode;
                txtDriversLicenseNum.Text = boPerson.DriversLicenseNum;
                ddlDriversLicenseState.DataSource = CommonFunc.getStates();
                ddlDriversLicenseState.DataTextField = "StateName";
                ddlDriversLicenseState.DataValueField = "StateCode";
                ddlDriversLicenseState.DataBind();
                ddlDriversLicenseState.SelectedValue = boPerson.DriversLicenseState;

                DriverPersonID = personID;

                btnDriverUpdate.Visible = true;
            }
        }
        //insert driver person
        public void LoadDriver()
        {
            if (!IsPostBack)
            {
                ddlDriversLicenseClass.Items.Add(new ListItem("", ""));
                ddlDriversLicenseClass.DataSource = BO_LookupValue.SelectByFieldByKeyAndProgram("DRIVING_LICENSE_CLASS", "NE");
                ddlDriversLicenseClass.DataTextField = "Valdesc";
                ddlDriversLicenseClass.DataValueField = "LookupVal";
                ddlDriversLicenseClass.DataBind();

                ddlDriversLicenseState.Items.Add(new ListItem("", ""));
                ddlDriversLicenseState.DataSource = CommonFunc.getStates();
                ddlDriversLicenseState.DataTextField = "StateName";
                ddlDriversLicenseState.DataValueField = "StateCode";
                ddlDriversLicenseState.DataBind();

                btnDriverInsert.Visible = true;
            }
        }

        protected void Driver_Update(Object sender, EventArgs e) 
        {
            BO_Person boPerson = new BO_Person();
            boPerson.PersonID = DriverPersonID;
            boPerson.Title = txtTitle.Text;
            boPerson.FirstName = txtFirstName.Text;
            boPerson.MiddleInitial = txtMiddleInt.Text;
            boPerson.LastName = txtLastName.Text;
            boPerson.DriversLicenseClassCode = ddlDriversLicenseClass.SelectedValue;
            boPerson.DriversLicenseNum = txtDriversLicenseNum.Text;
            boPerson.DriversLicenseState = ddlDriversLicenseState.SelectedValue;
            boPerson.Update();
            //btnDriverInsert.Visible = false;
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "CloseRebindDrivers", "CloseAndRebind();", true); 
        }

        protected void Driver_Insert(Object sender, EventArgs e)
        {
            BO_ProviderPerson providerPerson = new BO_ProviderPerson();
            providerPerson.BO_PersonDetail = new BO_Person();
            providerPerson.PopsIntID = CurrentAppProvider.PopsIntID;
            providerPerson.ApplicationID = CurrentAppProvider.ApplicationID;
            providerPerson.IsCurrent = 1;
            providerPerson.PersonType = "10";
            providerPerson.EffectiveDate = DateTime.Now;
            providerPerson.BO_PersonDetail.Title = txtTitle.Text.Trim();
            providerPerson.BO_PersonDetail.FirstName = txtFirstName.Text.Trim();
            providerPerson.BO_PersonDetail.MiddleInitial = txtMiddleInt.Text.Trim();
            providerPerson.BO_PersonDetail.LastName = txtLastName.Text.Trim();
            providerPerson.BO_PersonDetail.DriversLicenseClassCode = ddlDriversLicenseClass.SelectedValue.Trim();
            providerPerson.BO_PersonDetail.DriversLicenseNum = txtDriversLicenseNum.Text.Trim();
            providerPerson.BO_PersonDetail.DriversLicenseState = ddlDriversLicenseState.SelectedValue.Trim();

            BO_Person person = providerPerson.InsertProviderPerson();

            Page.ClientScript.RegisterStartupScript(Page.GetType(), "CloseRebindDrivers", "CloseAndRebind();", true); 

            //DriverPersonID = (decimal)person.PersonID;

            //btnDriverInsert.Visible = false;
            //btnDriverUpdate.Visible = true;
        }

        private BO_Application CurrentAppProvider
        {
            get
            {
                return Session["CurrentAppProvider"] == null ? null : (BO_Application)Session["CurrentAppProvider"];
            }
            set
            {
                Session["CurrentAppProvider"] = value;
            }
        }

        private decimal DriverPersonID
        {
            get
            {
                return (decimal)ViewState["DriverPersonID"];
            }

            set
            {
                ViewState["DriverPersonID"] = value;
            }
        }
    }
}