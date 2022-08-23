using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using ATG;
using ATG.BusinessObject;
using ATG.GridHelper;

namespace AppControl
{
    public partial class PersonnelForm : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _InitEducationGridColumns(EducationGridHelper.GridColumnList());
                _InitEmploymentGridColumns(EmploymentGridHelper.GridColumnList());
            }
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (PersonnelPersonID == 0)
            {
                SetReadOnly(this.Controls);
            }
            else
            {
                SetActive(this.Controls);
            }
        }

        //update Personnel person
        public void LoadPersonnel(decimal personID)
        {
            if (!IsPostBack)
            {
                PersonnelPersonID = personID;
                _Init();

                BO_Person boPerson = BO_Person.SelectOne(new BO_PersonPrimaryKey(personID));
                BO_ProviderPerson providerPerson = BO_ProviderPerson.SelectOne(new BO_ProviderPersonPrimaryKey(CurrentAppProvider.PopsIntID, personID, CurrentAppProvider.ApplicationID));
                txtFirstName.Text = boPerson.FirstName;
                txtMiddleInt.Text = boPerson.MiddleInitial;
                txtLastName.Text = boPerson.LastName;
                txtPhone.Text = boPerson.PhoneNumber;
                txtFax.Text = boPerson.FaxNumber;
                txtEmail.Text = boPerson.EmailAddress;
                ddlPersonType.SelectedValue = providerPerson.PersonType;

                btnPersonnelUpdate.Visible = true;
            }
        }
        //insert Personnel person
        public void LoadPersonnel()
        {
            if (!IsPostBack)
            {
                PersonnelPersonID = 0;
                _Init();
                btnPersonnelInsert.Visible = true;
            }
        }

        protected void _Init()
        {
            // person type
            ddlPersonType.DataSource = BO_LookupValue.SelectByFieldByKeyAndProgram("PERSON_TYPE", CurrentAppProvider.ProgramID);
            ddlPersonType.DataTextField = "Valdesc";
            ddlPersonType.DataValueField = "LookupVal";
            ddlPersonType.DataBind();

        }

        protected void Personnel_Update(Object sender, EventArgs e) 
        {
            BO_Person boPerson = new BO_Person();
            BO_ProviderPerson providerPerson = new BO_ProviderPerson();
            boPerson.PersonID = PersonnelPersonID;
            boPerson.FirstName = txtFirstName.Text;
            boPerson.MiddleInitial = txtMiddleInt.Text;
            boPerson.LastName = txtLastName.Text;
            boPerson.PhoneNumber = txtPhone.Text;
            boPerson.FaxNumber = txtFax.Text;
            boPerson.EmailAddress = txtEmail.Text;
            providerPerson.PopsIntID = CurrentAppProvider.PopsIntID;
            providerPerson.ApplicationID = CurrentAppProvider.ApplicationID;
            providerPerson.PersonID = PersonnelPersonID;
            providerPerson.PersonType = ddlPersonType.SelectedValue;
            providerPerson.Update();
            boPerson.Update();
            btnPersonnelInsert.Visible = false;
            //Page.ClientScript.RegisterStartupScript(Page.GetType(), "CloseRebindPersonnel", "CloseAndRebind();", true); 
        }

        protected void Personnel_Insert(Object sender, EventArgs e)
        {
            BO_ProviderPerson providerPerson = new BO_ProviderPerson();
            providerPerson.BO_PersonDetail = new BO_Person();
            providerPerson.PopsIntID = CurrentAppProvider.PopsIntID;
            providerPerson.ApplicationID = CurrentAppProvider.ApplicationID;
            providerPerson.IsCurrent = 1;
            providerPerson.EffectiveDate = DateTime.Now;
            providerPerson.BO_PersonDetail.FirstName = txtFirstName.Text.Trim();
            providerPerson.BO_PersonDetail.MiddleInitial = txtMiddleInt.Text.Trim();
            providerPerson.BO_PersonDetail.LastName = txtLastName.Text.Trim();
            providerPerson.BO_PersonDetail.PhoneNumber = txtPhone.Text;
            providerPerson.BO_PersonDetail.FaxNumber = txtFax.Text;
            providerPerson.BO_PersonDetail.EmailAddress = txtEmail.Text;
            providerPerson.PersonType = ddlPersonType.SelectedValue;

            BO_Person person = providerPerson.InsertProviderPerson();

            //Page.ClientScript.RegisterStartupScript(Page.GetType(), "CloseRebindDrivers", "CloseAndRebind();", true); 

            PersonnelPersonID = (decimal)person.PersonID;

            btnPersonnelInsert.Visible = false;
            btnPersonnelUpdate.Visible = true;
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

        private decimal? PersonnelPersonID
        {
            get
            {
                return (decimal)ViewState["PersonnelPersonID"];
            }

            set
            {
                ViewState["PersonnelPersonID"] = value;
            }
        }

        private void SetReadOnly(ControlCollection controlsCol)
        {
            foreach (Control control in controlsCol)
            {
                if (control is LinkButton)
                    ((LinkButton)control).Enabled = false;

                SetReadOnly(control.Controls);
            }
        }

        private void SetActive(ControlCollection controlCol)
        {
            foreach (Control control in controlCol)
            {
                if (control is LinkButton)
                    ((LinkButton)control).Enabled = true;

                SetActive(control.Controls);
            }
        }

        protected void EducationGrid_NeedsDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            //if (PersonnelPersonID != 0)
            //{
            EducationGridHelper educationGridHelper = new EducationGridHelper();
            educationGridHelper.InitializeEducationGrid(new BO_PersonPrimaryKey(PersonnelPersonID));
            grdEducation.DataSource = educationGridHelper.GridDataSource;
            //}
            // else { grdEducation.DataSource = null; }
        }

        protected void grdEducation_ItemCommand(object sender, GridCommandEventArgs e)
        {
            string educationID = "";

            if (e.CommandName.Equals("AddEducation"))
            {
                RadWinEducation.NavigateUrl = "~/Common/EditForm/EducationForm.aspx?educationid=&personid=" + PersonnelPersonID;
                RadWinEducation.VisibleStatusbar = false;
                RadWinEducation.VisibleOnPageLoad = true;
                RadWinEducation.Height = Unit.Pixel(600);
                RadWinEducation.Width = Unit.Pixel(800);
                RadWinEducation.Behaviors = WindowBehaviors.None;

                RadWinEducation.Modal = true;
                RadWinEducation.VisibleOnPageLoad = true;
                RadWinEducation.Height = Unit.Pixel(525);
                RadWinEducation.Width = Unit.Pixel(730);
                RadWinEducation.Title = "Add Education";
                RadWindowManagerEducation.Style.Add("z-index", "9999");
            }

            if (grdEducation.SelectedItems.Count > 0)
            {
                foreach (Telerik.Web.UI.GridDataItem item in grdEducation.SelectedItems)
                {
                    educationID = item["EducationID"].Text;
                }

                if (e.CommandName.Equals("EditEducation"))
                {
                    RadWinEducation.NavigateUrl = "~/Common/EditForm/EducationForm.aspx?educationid=" + educationID + "&personid=" + PersonnelPersonID;
                    RadWinEducation.VisibleStatusbar = false;
                    RadWinEducation.VisibleOnPageLoad = true;
                    RadWinEducation.Height = Unit.Pixel(600);
                    RadWinEducation.Width = Unit.Pixel(800);
                    RadWinEducation.Behaviors = WindowBehaviors.None;

                    RadWinEducation.Modal = true;
                    RadWinEducation.VisibleOnPageLoad = true;
                    RadWinEducation.Height = Unit.Pixel(525);
                    RadWinEducation.Width = Unit.Pixel(730);
                    RadWinEducation.Title = "Edit Education";
                    RadWindowManagerEducation.Style.Add("z-index", "9999");
                }

                if (e.CommandName.Equals("DeleteEducation"))
                {
                    //custom dev., need to create stored procedure to only delete driver persons from the application/provider_person record unless that person record does not belong to any other applications.
                    BO_Education.Delete(new BO_EducationPrimaryKey(Convert.ToDecimal(educationID), PersonnelPersonID));
                  EducationGridDataBind();
                }
            }

            if (e.CommandName.Equals("RebindEducation"))
            {
                EducationGridDataBind();
            }
        }

        public void EducationGridDataBind()
        {
            EducationGridHelper educationGridHelper = new EducationGridHelper();
            educationGridHelper.InitializeEducationGrid(new BO_PersonPrimaryKey(PersonnelPersonID));
            grdEducation.DataSource = educationGridHelper.GridDataSource;
            grdEducation.DataBind();
        }

        private void _InitEducationGridColumns(GridBoundColumn[] inColumnList)
        {
            foreach (GridBoundColumn tmpCol in inColumnList)
            {
                GridBoundColumn gbc = new GridBoundColumn();
                grdEducation.Columns.Add(gbc);
                gbc.UniqueName = tmpCol.UniqueName;
                gbc.DataField = tmpCol.DataField;
                gbc.HeaderText = tmpCol.HeaderText;
                gbc.Visible = tmpCol.Visible;
                gbc.AllowFiltering = tmpCol.AllowFiltering;
                gbc.HeaderStyle.Width = tmpCol.HeaderStyle.Width;
            }
        }

        protected void EmploymentGrid_NeedsDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            //if (PersonnelPersonID != 0)
            //{
            EmploymentGridHelper employmentGridHelper = new EmploymentGridHelper();
            employmentGridHelper.InitializeEmploymentGrid(new BO_PersonPrimaryKey(PersonnelPersonID));
            grdEmployment.DataSource = employmentGridHelper.GridDataSource;
            //}
            // else { grdEmployment.DataSource = null; }
        }

        protected void grdEmployment_ItemCommand(object sender, GridCommandEventArgs e)
        {
            string employmentID = "";

            if (e.CommandName.Equals("AddEmployment"))
            {
                RadWinEmployment.NavigateUrl = "~/Common/EditForm/EmploymentForm.aspx?employmentid=&personid=" + PersonnelPersonID;
                RadWinEmployment.VisibleStatusbar = false;
                RadWinEmployment.VisibleOnPageLoad = true;
                RadWinEmployment.Height = Unit.Pixel(600);
                RadWinEmployment.Width = Unit.Pixel(800);
                RadWinEmployment.Behaviors = WindowBehaviors.None;

                RadWinEmployment.Modal = true;
                RadWinEmployment.VisibleOnPageLoad = true;
                RadWinEmployment.Height = Unit.Pixel(525);
                RadWinEmployment.Width = Unit.Pixel(730);
                RadWinEmployment.Title = "Add Employment";
                RadWindowManagerEmployment.Style.Add("z-index", "9999");
            }

            if (grdEmployment.SelectedItems.Count > 0)
            {
                foreach (Telerik.Web.UI.GridDataItem item in grdEmployment.SelectedItems)
                {
                    employmentID = item["EmploymentID"].Text;
                }

                if (e.CommandName.Equals("EditEmployment"))
                {
                    RadWinEmployment.NavigateUrl = "~/Common/EditForm/EmploymentForm.aspx?employmentid=" + employmentID + "&personid=" + PersonnelPersonID;
                    RadWinEmployment.VisibleStatusbar = false;
                    RadWinEmployment.VisibleOnPageLoad = true;
                    RadWinEmployment.Height = Unit.Pixel(600);
                    RadWinEmployment.Width = Unit.Pixel(800);
                    RadWinEmployment.Behaviors = WindowBehaviors.None;

                    RadWinEmployment.Modal = true;
                    RadWinEmployment.VisibleOnPageLoad = true;
                    RadWinEmployment.Height = Unit.Pixel(525);
                    RadWinEmployment.Width = Unit.Pixel(730);
                    RadWinEmployment.Title = "Edit Employment";
                    RadWindowManagerEmployment.Style.Add("z-index", "9999");
                }

                if (e.CommandName.Equals("DeleteEmployment"))
                {
                    //custom dev., need to create stored procedure to only delete driver persons from the application/provider_person record unless that person record does not belong to any other applications.
                    BO_Employment.Delete(new BO_EmploymentPrimaryKey(Convert.ToDecimal(employmentID), PersonnelPersonID));
                    EmploymentGridDataBind();
                }
            }

            if (e.CommandName.Equals("RebindEmployment"))
            {
                EmploymentGridDataBind();
            }
        }

        public void EmploymentGridDataBind()
        {
            EmploymentGridHelper employmentGridHelper = new EmploymentGridHelper();
            employmentGridHelper.InitializeEmploymentGrid(new BO_PersonPrimaryKey(PersonnelPersonID));
            grdEmployment.DataSource = employmentGridHelper.GridDataSource;
            grdEmployment.DataBind();
        }

        private void _InitEmploymentGridColumns(GridBoundColumn[] inColumnList)
        {
            foreach (GridBoundColumn tmpCol in inColumnList)
            {
                GridBoundColumn gbc = new GridBoundColumn();
                grdEmployment.Columns.Add(gbc);
                gbc.UniqueName = tmpCol.UniqueName;
                gbc.DataField = tmpCol.DataField;
                gbc.HeaderText = tmpCol.HeaderText;
                gbc.Visible = tmpCol.Visible;
                gbc.AllowFiltering = tmpCol.AllowFiltering;
                gbc.HeaderStyle.Width = tmpCol.HeaderStyle.Width;
            }
        }
    }
}