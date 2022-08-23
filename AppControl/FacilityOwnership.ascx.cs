using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ATG.BusinessObject;
using System.Data;
using ATG.Utilities.Data;
using Telerik.Web.UI;

namespace AppControl
{
    public partial class FacilityOwnership : System.Web.UI.UserControl
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            // do nothing
        }

        protected void grdOwnerShip_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            if (null != grdOwnerShipDataSource)
            {
                grdOwnerShip.DataSource = (DataTable)grdOwnerShipDataSource;
            }
            else
            {
                string providerPOPSINTID = (string)Session["ProviderPOPSINTID"];
                InitHistoryGrid(providerPOPSINTID);
            }
        }

        protected void grdOwnerShip_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSelectedItem();
        }

        private void LoadSelectedItem()
        {
            // get the currently selected Provider
            GridDataItem dataItem = (GridDataItem)grdOwnerShip.SelectedItems[0];

            // get the Ownership Type
            string typeOwnership = dataItem["TYPEOWNERSHIP"].Text;

            // get the LegalEntity id
            string legalEntityId = dataItem["LEGALENTITYID"].Text;
            
            // get Percentage Ownership
            string percentOwn = dataItem["PERCENT_OWN"].Text;
            txtPercentOwn.Text = percentOwn;

            decimal? legalEntityId_decimal = null;
            try
            {
                legalEntityId_decimal = Decimal.Parse(legalEntityId);
            }
            catch (Exception ex)
            {
                legalEntityId_decimal = null;
            }

            BO_LegalEntityPrimaryKey boLegalEntityPrimaryKey = new BO_LegalEntityPrimaryKey(legalEntityId_decimal);
            BO_LegalEntity boLegalEntity = BO_LegalEntity.SelectOne(boLegalEntityPrimaryKey);

            // Reload the data in the input controls
            InitFields(boLegalEntity, typeOwnership);
        }

        /// <summary>
        /// get the data for the grid
        /// </summary>
        private void InitHistoryGrid(string providerPOPSINTID)
        {
            if(!string.IsNullOrEmpty(providerPOPSINTID))
            {
                BO_ProviderPrimaryKey boProviderPrimaryKey = new BO_ProviderPrimaryKey(Convert.ToDecimal(providerPOPSINTID));
                if (boProviderPrimaryKey != null)
                {
                    BO_Ownerships tmpOwnerships = BO_Ownership.SelectAllByForeignKeyPopsIntIDWithLegalEntityForGrid(boProviderPrimaryKey);
                    if (null != tmpOwnerships)
                    {
                        // Create a dataTable with the appropriate data struture
                        DataTable tmpTable = getFacilityOwnershipDataTable();

                        foreach (BO_Ownership boOwner in tmpOwnerships)
                        {
                            DataRow tmpDR = tmpTable.NewRow();
                            tmpDR["DATESTARTED"] = boOwner.DateStarted.HasValue ? boOwner.DateStarted.Value.ToShortDateString() : "";
                            tmpDR["ENTITYNAME"] = boOwner.EntityName;
                            tmpDR["APPLICATIONID"] = boOwner.ApplicationID;
                            tmpDR["TYPEOWNERSHIP"] = boOwner.TypeOwnership;
                            tmpDR["LEGALENTITYID"] = boOwner.LegalEntityID;
                            tmpDR["PERCENT_OWN"] = boOwner.PercentOwnership.Value.ToString();

                            tmpTable.Rows.Add(tmpDR);
                        }
                        // save to the Session Object
                        grdOwnerShipDataSource = tmpTable;
                        // set the dataSource object for thge grid
                        grdOwnerShip.DataSource = (DataTable)grdOwnerShipDataSource;
                    }
                }
            }
        }


        /// <summary>
        /// Set the values of the input controls
        /// </summary>
        private void InitFields(BO_LegalEntity boLegalEntity, string typeOwnership)
        {
            listOwnershipType.Items.Clear();
            listOwnershipType.DataSource = OwnershipTypeLookups;
            listOwnershipType.DataTextField = "Valdesc";
            listOwnershipType.DataValueField = "LookupVal";
            listOwnershipType.DataBind();
            if (typeOwnership != null)
                listOwnershipType.SelectedValue = typeOwnership ;
            else
                listOwnershipType.SelectedValue = null;

            TextBoxEIN.Text = (boLegalEntity != null) ? boLegalEntity.EntityEin : "";
            TextBoxEntity.Text = (boLegalEntity != null) ? boLegalEntity.EntityName : "";
            RadMaskedTextBoxEntityPhone.Text = (boLegalEntity != null) ? boLegalEntity.EntityPhone : "";
            RadMaskedTextBoxEntityFax.Text = (boLegalEntity != null) ? boLegalEntity.EntityFax : "";

            if (boLegalEntity != null)
            {
                // get the address object
                BO_AddressPrimaryKey boAddressPrimaryKey = new BO_AddressPrimaryKey(boLegalEntity.AddressID);
                BO_Address boAddress = BO_AddressBase.SelectOne(boAddressPrimaryKey);

                // set the values in the input controls
                TextBoxEntityStreetAddress.Text = (boAddress != null) ? boAddress.Street : "";
                TextBoxEntityCity.Text = (boAddress != null) ? boAddress.City : "";
                TextBoxEntityState.Text = (boAddress != null) ? boAddress.State : "";
                RadMaskedTextBoxEntityZip.Text = (boAddress != null) ? boAddress.ZipCode : "";
            }
            else
            {
                TextBoxEntityStreetAddress.Text = "";
                TextBoxEntityCity.Text = "";
                TextBoxEntityState.Text = "";
                RadMaskedTextBoxEntityZip.Text = "";
            }
        }

        private DataTable getFacilityOwnershipDataTable()
        {
            DataTable tmpDTbl = new DataTable();
            DataColumn tmpDCol = null;

            tmpDCol = new DataColumn("DATESTARTED");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("ENTITYNAME");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("APPLICATIONID");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("TYPEOWNERSHIP");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("LEGALENTITYID");
            tmpDTbl.Columns.Add(tmpDCol);
            tmpDCol = new DataColumn("PERCENT_OWN");
            tmpDTbl.Columns.Add(tmpDCol);
            
            return tmpDTbl;
        }

        private BO_LookupValues OwnershipTypeLookups
        {
            get
            {
                BO_LookupValues tmpLkups;
                if (Session["OwnershipTypeLookups"] == null)
                {
                    tmpLkups = BO_LookupValue.SelectByField(BO_LookupValueFields.LookupKey, "TYPE_OWNERSHIP");
                    OwnershipTypeLookups = tmpLkups;
                }
                else
                    tmpLkups = (BO_LookupValues)Session["OwnershipTypeLookups"];

                return tmpLkups;
            }
            set
            {
                Session["OwnershipTypeLookups"] = value;
            }
        }

        private DataTable grdOwnerShipDataSource
        {
            get { return (DataTable)Session["grdOwnerShipDataSource"]; }
            set { Session["grdOwnerShipDataSource"] = value; }
        }

        /// <summary>
        /// Reload the fields with the current provider
        /// </summary>
        /// <param name="popsIntId"></param>
        public void LoadNewProvider(string popsIntId)
        {
            // delete pre-existing rows from datasource table
            DataTable dtTable1 = grdOwnerShipDataSource;
            if (dtTable1 != null)
            {
                dtTable1.Rows.Clear();
                dtTable1.AcceptChanges();
                grdOwnerShipDataSource = dtTable1;
                // set the dataSource object for the grid
                grdOwnerShip.DataSource = (DataTable)grdOwnerShipDataSource;
                grdOwnerShip.DataBind();
            }

            if(!string.IsNullOrEmpty(popsIntId))
            {
                // reload the data for the History grid
                InitHistoryGrid(popsIntId);
                // bind the grid
                grdOwnerShip.DataBind();
                // pre-select the first row in the grid
                if (grdOwnerShip.Items.Count > 0)
                {
                    // select the first row
                    grdOwnerShip.Items[0].Selected = true;
                    // reload data in the controls
                    LoadSelectedItem();
                }
                else
                {
                    // Clear the values of the input controls
                    InitFields(null, null);
                }
            }
            else
            {
                // Clear the values of the input controls
                InitFields(null, null);
            }
        }

    }
}