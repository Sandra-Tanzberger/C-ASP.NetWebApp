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
using System.Collections;

namespace AppControl
{
    public partial class FacilityPayments : System.Web.UI.UserControl
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            // do nothing
        }

        protected void grdPayments_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            if (null != grdPaymentsDataSource)
            {
                grdPayments.DataSource = (DataTable)grdPaymentsDataSource;
            }
            else
            {
                string providerPOPSINTID = (string)Session["ProviderPOPSINTID"];
                InitHistoryGrid(providerPOPSINTID);
            }
        }

        protected void grdPayments_SelectedIndexChanged(object sender, EventArgs e)
        {
            //LoadSelectedItem();
        }

        private void LoadSelectedItem()
        {
            // get the currently selected Provider
            GridDataItem dataItem = (GridDataItem)grdPayments.SelectedItems[0];

            // get the person id
            string billingId = dataItem["BILLINGID"].Text;
            decimal? billingId_decimal = null;
            try
            {
                billingId_decimal = Decimal.Parse(billingId);
            }
            catch (Exception ex)
            {
                billingId_decimal = null;
            }
           // BO_BillingPrimaryKey boBillingPrimaryKey = new BO_BillingPrimaryKey(billingId_decimal);
           // BO_Billing boBilling = BO_Billing.SelectOne(boBillingPrimaryKey);

            // Reload the data in the input controls
          //  InitFields(boBilling);
        }

        /// <summary>
        /// get the data for the grid
        /// </summary>
        private void InitHistoryGrid(string providerPOPSINTID)
        {
            if(!string.IsNullOrEmpty(providerPOPSINTID))
            {
                /*
                 * NOTE: Unlike the other tables, the BILLING table does not have a POPSINTID
                 * So do the following:
                 * 1. Get a list of applications for this Provider
                 * 2. Get the Billing details for each application
                */
                BO_ProviderPrimaryKey boProviderPrimaryKey = new BO_ProviderPrimaryKey(Convert.ToDecimal(providerPOPSINTID));
                if (boProviderPrimaryKey != null)
                {
                    // get all the applications for this provider
                    BO_Applications tmpApplications = BO_Application.SelectAllByForeignKeyPopsIntID(boProviderPrimaryKey);
                    if (null != tmpApplications)
                    {
                        // use a ArrayList to store Billing info across multiple Applications
                        ArrayList alstBilling = new ArrayList();
                        int cntr = 0;

                        // iterate the list of Applications for this provider
                        foreach (BO_Application boApplication in tmpApplications)
                        {
                            decimal? appId = boApplication.ApplicationID;
                            BO_ApplicationPrimaryKey boApplicationPrimaryKey = new BO_ApplicationPrimaryKey(appId);
                            BO_Billings tmpBillings = BO_Billing.SelectAllByForeignKeyApplicationID(boApplicationPrimaryKey);
                            if (null != tmpBillings)
                            {
                                foreach (BO_Billing boBilling in tmpBillings)
                                {
                                    alstBilling.Add(boBilling);
                                    cntr++;
                                }
                            }
                        }
                        if (cntr > 0)
                        {
                            // At this point, the "alstBilling" ArrayList contains billing  
                            // info from multiple applications
                            BO_Billing[] tmpArr = new BO_Billing[alstBilling.Count];
                            cntr = 0;
                            foreach (BO_Billing boBilling in alstBilling)
                            {
                                tmpArr[cntr] = boBilling;
                                cntr++;
                            }
                            // convert the Array to a DataTable object
                            grdPaymentsDataSource = GridHelper.BO_Array_ConvertToDataTable(tmpArr);
                            // set the dataSource object for thge grid
                            grdPayments.DataSource = (DataTable)grdPaymentsDataSource;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Set the values of the input controls
        /// </summary>
        private void InitFields(BO_Billing boBilling)
        {
            TextBoxLicensureNumber.Text = (boBilling != null) ? boBilling.LicensureNum : "";
            //TextBoxLicenseFee.Text = (boBilling != null) ? boBilling.LicFeeTotal.ToString() : "";
            TextBoxLicenseFeePaid.Text = (boBilling != null) ? boBilling.LicenseFeePaid : "";
            //TextBoxCheckNumber.Text = (boBilling != null) ? boBilling.CheckNumber.ToString() : "";
            //TextBoxAmountReceived.Text = (boBilling != null) ? boBilling.AmountReceived.ToString() : "";
            //TextBoxTransactionId.Text = (boBilling != null) ? boBilling.TransactionID : "";
            //TextBoxRefundAmount.Text = (boBilling != null) ? boBilling.LicRefund.ToString() : "";

            if (boBilling != null)
            {
           //     if (boBilling.AmountReceivedDate != null && boBilling.AmountReceivedDate.HasValue)
           //         RadDatePickerAmountReceivedDate.SelectedDate = boBilling.AmountReceivedDate;
           //     else
           //         RadDatePickerAmountReceivedDate.SelectedDate = null;

           //     if (boBilling.CheckReceived != null && boBilling.CheckReceived.HasValue)
            //        RadDatePickerCheckReceived.SelectedDate = boBilling.CheckReceived;
           //     else
            //        RadDatePickerCheckReceived.SelectedDate = null;

         //       if (boBilling.CheckProcessed != null && boBilling.CheckProcessed.HasValue)
           //         RadDatePickerCheckProcessed.SelectedDate = boBilling.CheckProcessed;
             //   else
               //     RadDatePickerCheckProcessed.SelectedDate = null;

//                if (boBilling.LicRefundDate != null && boBilling.LicRefundDate.HasValue)
  //                  RadDatePickerRefundDate.SelectedDate = boBilling.LicRefundDate;
    //            else
      //              RadDatePickerRefundDate.SelectedDate = null;
            }

            listPayMode.Items.Clear();
            listPayMode.DataSource = PayModeLookups;
            listPayMode.DataTextField = "Valdesc";
            listPayMode.DataValueField = "LookupVal";
            listPayMode.DataBind();
        //    if (boBilling != null && boBilling.PayMode != null)
        //        listPayMode.SelectedValue = boBilling.PayMode;
        //    else
        //        listPayMode.SelectedValue = null;

        }

        private DataTable grdPaymentsDataSource
        {
            get { return (DataTable)Session["grdPaymentsDataSource"]; }
            set { Session["grdPaymentsDataSource"] = value; }
        }

        /// <summary>
        /// Get the list of Payment Modes from the lookupValues table
        /// </summary>
        private BO_LookupValues PayModeLookups
        {
            get
            {
                BO_LookupValues tmpLkups;
                if (Session["PayModeLookups"] == null)
                {
                    tmpLkups = BO_LookupValue.SelectByField(BO_LookupValueFields.LookupKey, "PAY_MODE");
                    PayModeLookups = tmpLkups;
                }
                else
                    tmpLkups = (BO_LookupValues)Session["PayModeLookups"];

                return tmpLkups;
            }
            set
            {
                Session["PayModeLookups"] = value;
            }
        }

        /// <summary>
        /// Reload the fields with the current provider
        /// </summary>
        /// <param name="popsIntId"></param>
        public void LoadNewProvider(string popsIntId)
        {
            // delete pre-existing rows from datasource table
            DataTable dtTable1 = grdPaymentsDataSource;
            if (dtTable1 != null)
            {
                dtTable1.Rows.Clear();
                dtTable1.AcceptChanges();
                grdPaymentsDataSource = dtTable1;
                // set the dataSource object for the grid
                grdPayments.DataSource = (DataTable)grdPaymentsDataSource;
                grdPayments.DataBind();
            }

            if(!string.IsNullOrEmpty(popsIntId))
            {
                // reload the data for the History grid
                InitHistoryGrid(popsIntId);
                // bind the grid
                grdPayments.DataBind();
                // pre-select the first row in the grid
                if (grdPayments.Items.Count > 0)
                {
                    // select the first row
                    grdPayments.Items[0].Selected = true;
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