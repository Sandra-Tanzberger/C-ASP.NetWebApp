using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ATG.BusinessObject;

namespace AppControl
{
    public partial class BillingInsertForm : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void LoadCombos()
        {
            BO_LookupValues tmpLKUPS = null;

            DataTable tmpDT = new DataTable();
            DataRow tmpRow;

            tmpDT.Columns.Add("LOOKUP_VAL");
            tmpDT.Columns.Add("VALDESC");

            tmpLKUPS = FeeTypeLookups;
            tmpLKUPS.Sort( "Valdesc" );

            tmpRow = tmpDT.NewRow();
            tmpRow["LOOKUP_VAL"] = "";
            tmpRow["VALDESC"] = "";
            tmpDT.Rows.Add( tmpRow );

            foreach (BO_LookupValue boLV in tmpLKUPS)
            {
                tmpRow = tmpDT.NewRow();
                tmpRow["LOOKUP_VAL"] = boLV.LookupVal;
                tmpRow["VALDESC"] = boLV.Valdesc;
                tmpDT.Rows.Add(tmpRow);
            }

            tmpRow = tmpDT.NewRow();
            tmpRow["LOOKUP_VAL"] = "99";
            tmpRow["VALDESC"] = "Other";
            tmpDT.Rows.Add(tmpRow);

            cboTypeFee.DataSource = tmpDT;
            cboTypeFee.DataBind();

            tmpLKUPS = null;
            tmpDT = new DataTable();

            tmpDT.Columns.Add("LOOKUP_VAL");
            tmpDT.Columns.Add("VALDESC");

            tmpLKUPS = BillingTypeLookups;
            tmpLKUPS.Sort( "Valdesc" );

            tmpRow = tmpDT.NewRow();
            tmpRow["LOOKUP_VAL"] = "";
            tmpRow["VALDESC"] = "";
            tmpDT.Rows.Add( tmpRow );

            foreach (BO_LookupValue boLV in tmpLKUPS)
            {
                //SMM 06/15/2011 - Allow add of all types of charges
                if (boLV.Valdesc.ToUpper() != "PAYMENT")//do not show payment in dropdown, users must use check log to create payments - 06/26/2013
                {
                    tmpRow = tmpDT.NewRow();
                    tmpRow["LOOKUP_VAL"] = boLV.LookupVal;
                    tmpRow["VALDESC"] = boLV.Valdesc;
                    tmpDT.Rows.Add(tmpRow);
                }
            }

            cboTypeBilling.DataSource = tmpDT;
            cboTypeBilling.DataBind();

            tmpLKUPS = null;

            tmpDT = new DataTable();
            tmpDT.Columns.Add("APPLICATION_ID");
            BO_Applications tmpApps = null;

            tmpApps = Applications;

            foreach (BO_Application boLV in tmpApps)
            {
                tmpRow = tmpDT.NewRow();
                tmpRow["APPLICATION_ID"] = boLV.ApplicationID;
                tmpDT.Rows.Add(tmpRow);
            }

            cboAppID.DataSource = tmpDT;
            cboAppID.DataBind();
        }

        private BO_LookupValues BillingTypeLookups
        {
            get
            {
                BO_LookupValues retLkups = new BO_LookupValues();
                if (Session["BillingTypeLookups"] == null)
                {
                    BO_LookupValues tmpLkups = BO_LookupValue.SelectByField(BO_LookupValueFields.LookupKey, "TYPE_BILLING");
                    foreach (BO_LookupValue tmpLV in tmpLkups)
                    {
                        retLkups.Add(tmpLV);

                    }
                }
                else
                    retLkups = (BO_LookupValues)Session["BillingTypeLookups"];

                return retLkups;
            }
            set
            {
                Session["BillingTypeLookups"] = value;
            }
        }

        private BO_LookupValues FeeTypeLookups
        {
            get
            {
                BO_LookupValues retLkups = new BO_LookupValues();
                if (Session["FeeTypeLookups"] == null)
                {
                    BO_LookupValues tmpLkups = BO_LookupValue.SelectByField(BO_LookupValueFields.LookupKey, "TYPE_FEE");
                    foreach (BO_LookupValue tmpLV in tmpLkups)
                    {
                        retLkups.Add(tmpLV);

                    }
                }
                else
                    retLkups = (BO_LookupValues)Session["FeeTypeLookups"];

                return retLkups;
            }
            set
            {
                Session["FeeTypeLookups"] = value;
            }
        }
        private BO_Applications Applications
        {
            get
            {
                BO_Applications ret = (BO_Applications)ViewState["BillingEditFormApplications"];

                if (ret == null)
                {
                    switch (BillingKeyType)
                    {
                        case "APPLICATION_ID":
                            if (!string.IsNullOrEmpty(BillingKey))
                            {
                                ret = BO_Application.SelectByField("APPLICATION_ID", Convert.ToDecimal(BillingKey));
                            }

                            break;
                        case "POPS_INT_ID":
                            if (!string.IsNullOrEmpty(BillingKey))
                            {
                                // get rows for the specified Business Process Id
                                BO_ProviderPrimaryKey boProvPK = new BO_ProviderPrimaryKey(Convert.ToDecimal(BillingKey));
                                ret = BO_Application.SelectAllByForeignKeyPopsIntID(boProvPK);
                            }

                            break;
                    }
                }

                return ret;
            }
            set
            {
                ViewState["BillingEditFormApplications"] = value;
            }
        }

        public string BillingKeyType
        {
            get
            {
                if (ViewState["BillingKeyType"] != null)
                    return ViewState["BillingKeyType"].ToString();
                else
                    return "";
            }
            set
            {
                ViewState["BillingKeyType"] = value;
            }
        }

        public string BillingKey
        {
            get
            {
                if (ViewState["BillingKey"] != null)
                    return ViewState["BillingKey"].ToString();
                else
                    return "";
            }
            set
            {
                ViewState["BillingKey"] = value;
            }
        }

        public String TypeFee
        {
            get
            {
                return cboTypeFee.SelectedValue;
            }
            set
            {
                cboTypeFee.SelectedValue = value;
            }
        }

        public String TypeBilling
        {
            get
            {
                return cboTypeBilling.SelectedValue;
            }
            set
            {
                cboTypeBilling.SelectedValue = value;
            }
        }

        public String AppID
        {
            get
            {
                return cboAppID.SelectedValue;
            }
            set
            {
                cboAppID.SelectedValue = value;
            }
        }

        public string Amount
        {
            get
            {
                return txtAmount.Text;

            }
            set
            {
                txtAmount.Text = value;
            }
        }

        public string TransactionID
        {
            get
            {
                return txtTransactionID.Text;

            }
            set
            {
                txtTransactionID.Text = value;
            }
        }

        public string Comments
        {
            get
            {
                return txtComment.Text;

            }
            set
            {
                txtComment.Text = value;
            }
        }

        public string ApplicationID
        {
            get
            {
                return hidApplicationID.Value;
            }
            set
            {
                hidApplicationID.Value = value;
            }
        }
    }
}