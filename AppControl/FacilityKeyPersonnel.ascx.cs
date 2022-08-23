using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ATG.BusinessObject;
using System.Data;
using Telerik.Web.UI;
using ATG.Utilities.Data;

namespace AppControl
{
    public partial class FacilityKeyPersonnel : System.Web.UI.UserControl
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            // do nothing
        }

        protected void grdPersonnel_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            if (null != grdPersonnelDataSource)
            {
                grdPersonnel.DataSource = (DataTable)grdPersonnelDataSource;
            }
            else
            {
                string providerPOPSINTID = (string)Session["ProviderPOPSINTID"];
                InitHistoryGrid(providerPOPSINTID);
            }
        }

        protected void grdPersonnel_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSelectedItem();
        }

        private void LoadSelectedItem()
        {
            // get the currently selected Provider
            GridDataItem dataItem = (GridDataItem)grdPersonnel.SelectedItems[0];

            // get the person id
            string personId = dataItem["PERSONID"].Text;
            decimal? personId_decimal = null;
            try
            {
                personId_decimal = Decimal.Parse(personId);
            }
            catch (Exception ex)
            {
                personId_decimal = null;
            }

            BO_PersonPrimaryKey boPersonPrimaryKey = new BO_PersonPrimaryKey(personId_decimal);
            BO_Person boPerson = BO_PersonBase.SelectOne(boPersonPrimaryKey);

            // Reload the data in the input controls
            InitFields(boPerson);
        }

        /// <summary>
        /// get the data for the grid
        /// </summary>
        private void InitHistoryGrid(string providerPOPSINTID)
        {
            if(!string.IsNullOrEmpty(providerPOPSINTID))
            {
                BO_ProviderPrimaryKey  boProviderPrimaryKey = new BO_ProviderPrimaryKey(Convert.ToDecimal(providerPOPSINTID));
                if (boProviderPrimaryKey != null)
                {
                    BO_ProviderPeople tmpPeople = BO_ProviderPerson.SelectAllByForeignKeyPopsIntIDForGrid(boProviderPrimaryKey);
                    if (null != tmpPeople)
                    {
                        // Create a dataTable with the appropriate data struture
                        DataTable tmpTable = getFacilityKeyPersonnelDataTable();

                        foreach (BO_ProviderPerson boProviderPerson in tmpPeople)
                        {
                            DataRow tmpDR = tmpTable.NewRow();
                            tmpDR["DATESTARTED"] = boProviderPerson.DateStarted.HasValue ? boProviderPerson.DateStarted.Value.ToShortDateString() : "";
                            tmpDR["PERSONTYPEDESC"] = boProviderPerson.PersonTypeDesc;
                            tmpDR["FIRSTNAME"] = boProviderPerson.FirstName;
                            tmpDR["LASTNAME"] = boProviderPerson.LastName;
                            tmpDR["EFFECTIVEDATE"] = boProviderPerson.EffectiveDate.HasValue ? boProviderPerson.EffectiveDate.Value.ToShortDateString() : "";
                            tmpDR["EXPIRATIONDATE"] = boProviderPerson.ExpirationDate.HasValue ? boProviderPerson.ExpirationDate.Value.ToShortDateString() : "";
                            tmpDR["PERSONID"] = boProviderPerson.PersonID;

                            tmpTable.Rows.Add(tmpDR);
                        }
                        // save to the Session Object
                        grdPersonnelDataSource = tmpTable;
                        // set the dataSource object for thge grid
                        grdPersonnel.DataSource = (DataTable)grdPersonnelDataSource;
                    }
                }
            }
        }

        /// <summary>
        /// Set the values of the input controls
        /// </summary>
        private void InitFields(BO_Person boPerson)
        {
            txtPersTitle.Text = ( boPerson != null ) ? boPerson.Title : "";
            TextBoxFirstName.Text = (boPerson != null) ? boPerson.FirstName : "";
            TextBoxMiddleInitial.Text = (boPerson != null) ? boPerson.MiddleInitial : "";
            TextBoxLastName.Text = (boPerson != null) ? boPerson.LastName : "";
            TextBoxPhone.Text = (boPerson != null) ? boPerson.PhoneNumber : "";
            TextBoxFax.Text = (boPerson != null) ? boPerson.FaxNumber : "";
            TextBoxEmail.Text = (boPerson != null) ? boPerson.EmailAddress : "";
            TextBoxDrivLicClassCode.Text = (boPerson != null) ? boPerson.DriversLicenseClassCode : "";
            TextBoxDrivLicNum.Text = (boPerson != null) ? boPerson.DriversLicenseNum : "";
            TextBoxDrivLicState.Text = (boPerson != null) ? boPerson.DriversLicenseState : "";
        }

        private DataTable getFacilityKeyPersonnelDataTable()
        {
            DataTable tmpDTbl = new DataTable();
            DataColumn tmpDCol = null;

            tmpDCol = new DataColumn("DATESTARTED");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("PERSONTYPEDESC");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("FIRSTNAME");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("LASTNAME");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("EFFECTIVEDATE");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("EXPIRATIONDATE");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("PERSONID");
            tmpDTbl.Columns.Add(tmpDCol);

            return tmpDTbl;
        }

        private DataTable grdPersonnelDataSource
        {
            get { return (DataTable)Session["grdPersonnelDataSource"]; }
            set { Session["grdPersonnelDataSource"] = value; }
        }

        /// <summary>
        /// Reload the fields with the current provider
        /// </summary>
        /// <param name="popsIntId"></param>
        public void LoadNewProvider(string popsIntId)
        {
            // delete pre-existing rows from datasource table
            DataTable dtTable1 = grdPersonnelDataSource;
            if (dtTable1 != null)
            {
                dtTable1.Rows.Clear();
                dtTable1.AcceptChanges();
                grdPersonnelDataSource = dtTable1;
                // set the dataSource object for the grid
                grdPersonnel.DataSource = (DataTable)grdPersonnelDataSource;
                grdPersonnel.DataBind();
            }

            if(!string.IsNullOrEmpty(popsIntId))
            {
                // reload the data for the History grid
                InitHistoryGrid(popsIntId);
                // bind the grid
                grdPersonnel.DataBind();
                // pre-select the first row in the grid
                if (grdPersonnel.Items.Count > 0)
                {
                    // select the first row
                    grdPersonnel.Items[0].Selected = true;
                    // reload data in the controls
                    LoadSelectedItem();
                }
                else
                {
                    // Clear the values of the input controls
                    InitFields(null);
                }
            }
            else
            {
                // Clear the values of the input controls
                InitFields(null);
            }
        }


    }
}