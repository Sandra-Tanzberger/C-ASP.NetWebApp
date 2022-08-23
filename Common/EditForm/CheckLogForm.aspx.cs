using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using Telerik.Web.UI;
using ATG.BusinessObject;
using ATG;

namespace Common.EditForm
{
    public partial class CheckLogForm : System.Web.UI.Page
    {
        protected void Page_Load( object sender, EventArgs e )
        {
            if ( !IsPostBack )
            {
                BO_Billing editBilling = null;
                BO_BillingDetail editBillingDetail = null;

                CheckLogFormType = Session["CheckLogFormType"].ToString();


                if (CheckLogFormType.Equals("APPLICATION" ) )
                {
                    txtCompanyIndividual.ReadOnly = true;
                    txtCompanyIndividual.BackColor = Color.LightGray;
                    lstCheckLogPrefix.Enabled = false;
                }
                else // rs - 05/31/2012 - Hide 'License-Related Applications' only controls 
                {
                    lblApplID.Visible = false;
                    lblApplIDval.Visible = false;
                    lblNote.Visible = false;
                    txtNote.Visible = false;
                }

                if ( null != Session["CheckLogID"] && !Session["CheckLogID"].ToString().Equals( "" ) )
                    editBillingID = Convert.ToDecimal( Session["CheckLogID"].ToString() );

                lstCheckLogPrefix.ClearSelection();
                lstCheckLogPrefix.Items.Clear();
                lstCheckLogPrefix.AppendDataBoundItems = true;
                lstCheckLogPrefix.Items.Add( new RadComboBoxItem( "", "" ) );
                lstCheckLogPrefix.DataSource = BO_Program.SelectAllSortByDescription();
                lstCheckLogPrefix.DataTextField = "ProgramDescription";
                lstCheckLogPrefix.DataValueField = "ProgramID";
                lstCheckLogPrefix.Height = Unit.Pixel( 100 );
                lstCheckLogPrefix.DataBind();

                lstTypeFee.ClearSelection();
                lstTypeFee.Items.Clear();
                lstTypeFee.AppendDataBoundItems = true;
                lstTypeFee.Items.Add( new RadComboBoxItem( "", "" ) );
                //lstTypeFee.DataSource = BO_LookupValue.SelectByField( BO_LookupValueFields.LookupKey, "TYPE_FEE" );
                //lstTypeFee.DataTextField = "VALDESC";
                //lstTypeFee.DataValueField = "LOOKUPVAL";
                BO_LookupValues tmpLKUPS = BO_LookupValue.SelectByFieldOrderByValDESC( BO_LookupValueFields.LookupKey, "TYPE_FEE" );

                foreach ( BO_LookupValue boLV in tmpLKUPS )
                {
                    if ( CheckLogFormType.Equals( "APPLICATION" ) && null != boLV.Extra && boLV.Extra.Equals( "APP" ) )
                    {
                        RadComboBoxItem tmpRCBI = new RadComboBoxItem( boLV.Valdesc, boLV.LookupVal );
                        lstTypeFee.Items.Add( tmpRCBI );
                    }
                    else if ( CheckLogFormType.Equals( "OTHER" ) && null == boLV.Extra )
                        lstTypeFee.Items.Add( new RadComboBoxItem( boLV.Valdesc, boLV.LookupVal ) );
                }

                lstTypeFee.Height = Unit.Pixel( 100 );
                lstTypeFee.DataBind();

                if ( editBillingID > 0 )
                {
                    editMode = true;
                    BO_BillingDetails tmpBOBillingDetails = BO_BillingDetail.SelectAllByForeignKeyBillingID( new BO_BillingPrimaryKey( editBillingID ) );
                    editBilling = BO_Billing.SelectOne( new BO_BillingPrimaryKey( editBillingID ) );

                    foreach ( BO_BillingDetail boBD in tmpBOBillingDetails )
                    {
                        if ( boBD.TypeBilling.Equals( "1" ) )
                        {
                            editBillingDetail = boBD;
                            editBillingDetailID = boBD.BillingDetailID.Value;
                            break;
                        }
                    }

                    litDateEntered.Text = editBillingDetail.TransactionDate.Value.ToShortDateString();
                    txtStateID.Text = Session["CheckLogStateID"].ToString();
                    txtStateID.ReadOnly = true;
                    txtStateID.BackColor = Color.LightGray;
                    txtCompanyIndividual.Text = editBilling.BillToName;
                    rntbAmount.Text = editBillingDetail.Amount.Value.ToString();
                    txtCheckNum.Text = editBillingDetail.TransactionID;
                    rdpCheckDate.SelectedDate = editBillingDetail.CheckDate;
                    if (editBilling.CheckLogPrefix != null)
                    {
                        lstCheckLogPrefix.FindItemByValue(editBilling.CheckLogPrefix).Selected = true;
                    }
                    lstTypeFee.FindItemByValue( editBillingDetail.TypeFee ).Selected = true;
                    txtPIV.Text = editBillingDetail.PivNum;

                    if (txtStateID.Text.Length > 0)
                    {
                        txtStateID_TextChanged(txtStateID, new EventArgs());
                        lstTypeFee_SelectedIndexChanged(lstTypeFee, new EventArgs());
                    }

                    if ( null != editBillingDetail.PivNum && !string.IsNullOrEmpty( editBillingDetail.PivNum ) )
                    {
                        rntbAmount.ReadOnly = true;
                        txtCheckNum.ReadOnly = true;
                        rdpCheckDate.Enabled = false;
                        txtPIV.ReadOnly = true;
                        btnSaveExit.Enabled = false;
                    }

                    if (!string.IsNullOrEmpty(editBillingDetail.Comment))
                    {
                        txtComment.Text = editBillingDetail.Comment.ToString();
                    }
                }
                else
                {
                    editMode = false;
                    litDateEntered.Text = DateTime.Now.ToShortDateString();
                }
            }
        }

        protected void txtStateID_TextChanged( object sender, EventArgs e )
        {
            TextBox tmpTB = (TextBox) sender;
            ProviderFound = false;

            spanProvNotFound.Visible = ProviderFound;

            if ( txtStateID.Text.Length > 0 )
            {
                switch ( CheckLogFormType )
                {
                    case "APPLICATION":

                        lblApplID.Text = "Not Linked";
                        lblApplIDval.Text = "";

                        //SMM 06/26/2012 - Always lookup by provider
                        BO_Providers tmpPrvdrs = BO_Provider.SelectByField( BO_ProviderFields.StateID, tmpTB.Text.ToUpper() );
                        
                        if ( null != tmpPrvdrs && tmpPrvdrs.Count > 0 )
                        {
                            BO_Provider tmpProv = tmpPrvdrs[0];

                            ProviderFound = true;
                            editPopsIntID = tmpProv.PopsIntID.Value;
                            editStateID = tmpProv.StateID;
                            txtCompanyIndividual.Text = tmpProv.FacilityName;
                            lstCheckLogPrefix.FindItemByValue( tmpProv.ProgramID ).Selected = true;

                            //SMM 06/26/2012 - Now check for an existing record to auto select.
                            BO_Applications tmpApps = BO_Application.SelectByField( BO_ApplicationFields.StateID, tmpTB.Text.ToUpper() );
                            string tmpTypeFee = "";

                            foreach ( BO_Application boApp in tmpApps )
                            {
                                if ( !boApp.ApplicationStatus.Equals( "4" )     //Not Approved
                                    && !boApp.BusinessProcessID.Equals( "9" )   //Exclude Name Change
                                    && !boApp.BusinessProcessID.Equals( "1" ) ) //Exclude ETL Load
                                {
                                    
                                    switch ( boApp.BusinessProcessID )
                                    {
                                        case "2":
                                            tmpTypeFee = "1";
                                            break;
                                        case "3":
                                            tmpTypeFee = "2";
                                            break;
                                        case "4":
                                            tmpTypeFee = "5";
                                            break;
                                        case "5":
                                            tmpTypeFee = "7";
                                            break;
                                        case "6":
                                            tmpTypeFee = "8";
                                            break;
                                        case "7":
                                            tmpTypeFee = "11";
                                            break;
                                        case "8":
                                            tmpTypeFee = "4";
                                            break;
                                    }
                                    if ( !editMode )
                                    {
                                        RadComboBoxItem tmpItem = lstTypeFee.FindItemByValue( tmpTypeFee );
                                        if (tmpItem != null)
                                        {
                                            tmpItem.Selected = true;
                                            tmpItem.Attributes.Add("APPID", boApp.ApplicationID.Value.ToString());
                                            //rs - 05/31/2012 - Show the linked Non-Approved Application ID for License Related Applications
                                            lblApplID.Text = "This Check Linked to: ";
                                            lblApplIDval.Text = boApp.ApplicationID.Value.ToString();
                                        }
                                    }

                                }
                            }
                        }

                        spanProvNotFound.Visible = !ProviderFound;
                        break;
                    case "OTHER":
                        BO_Providers tmpProvs = BO_Provider.SelectByField( BO_ProviderFields.StateID, tmpTB.Text.ToUpper() );

                        foreach ( BO_Provider boProv in tmpProvs )
                        {
                            ProviderFound = true;
                            txtCompanyIndividual.Text = boProv.FacilityName;
                            lstCheckLogPrefix.FindItemByValue( boProv.ProgramID ).Selected = true;
                            editPopsIntID = boProv.PopsIntID.Value;
                            editStateID = boProv.StateID;
                        }
                        spanProvNotFound.Visible = !ProviderFound;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                ProviderFound = false;
                txtCompanyIndividual.Text = "";
                spanProvNotFound.Visible = false;
            }
        }
        
        //rs - 05/31/2012 - Added new function for Reason Drop down selection change
        protected void lstTypeFee_SelectedIndexChanged(object sender, EventArgs e)
        {

            string selectedFeeType = lstTypeFee.SelectedValue.ToString();
            string NotApprovedApplFeeType = "";
            string notApprovedAppID = "";
            
            if (txtStateID.Text.Length > 0 && CheckLogFormType.Equals("APPLICATION"))
            {
                BO_Applications tmpApps = BO_Application.SelectByField(BO_ApplicationFields.StateID, txtStateID.Text.ToUpper());
                string tmpTypeFee = "";

                foreach (BO_Application boApp in tmpApps)
                {
                    if (!boApp.ApplicationStatus.Equals("4")     //Not Approved
                       && !boApp.BusinessProcessID.Equals("9")   //Exclude Name Change
                       && !boApp.BusinessProcessID.Equals("1")) //Exclude ETL Load
                    {
                        switch (boApp.BusinessProcessID)
                        {
                            case "2":
                                tmpTypeFee = "1";
                                break;
                            case "3":
                                tmpTypeFee = "2";
                                break;
                            case "4":
                                tmpTypeFee = "5";
                                break;
                            case "5":
                                tmpTypeFee = "7";
                                break;
                            case "6":
                                tmpTypeFee = "8";
                                break;
                            case "7":
                                tmpTypeFee = "11";
                                break;
                            case "8":
                                tmpTypeFee = "4";
                                break;
                       }

                       NotApprovedApplFeeType = tmpTypeFee;
                       notApprovedAppID = boApp.ApplicationID.Value.ToString();
                    }
                }

                RadComboBoxItem tmpItem = lstTypeFee.FindItemByValue(selectedFeeType);
                tmpItem.Selected = true;
                if (selectedFeeType.Equals(NotApprovedApplFeeType))
                {
                    lblApplID.Text = "This Check Linked to: ";
                    lblApplIDval.Text = notApprovedAppID;
                    tmpItem.Attributes.Add("APPID", notApprovedAppID);
                    
                }
                else
                {
                    lblApplID.Text = "Not Linked";
                    lblApplIDval.Text = "";
                }
           }
           
        }
        
        protected void btnSave_Click( object sender, EventArgs e )
        {
            Button tmpCmdBtn = (Button) sender;

            RadComboBoxItem tmpItem = lstTypeFee.SelectedItem;

            switch ( tmpCmdBtn.CommandName )
            {
                case "SaveExit":
                    BO_Billing tmpBilling = null;
                    BO_BillingDetail tmpBillingDetail = null;

                    if ( ValidateForm() )
                    {
                        if ( editMode )
                        {
                            tmpBilling = BO_Billing.SelectOne( new BO_BillingPrimaryKey( editBillingID ) );
                            //SMM 01/22/2012 - Removed title case conversion
                            //tmpBilling.BillToName = CommonFunc.ConvertToTitleCase( txtCompanyIndividual.Text );
                            tmpBilling.BillToName = txtCompanyIndividual.Text;
                            //rs -06/01/2012 - Update APPLICATION_ID in BILLING table
                            if (lblApplIDval.Text.Length > 0)
                                tmpBilling.ApplicationID = Convert.ToInt64(lblApplIDval.Text);
                            else
                                tmpBilling.ApplicationID = null;
                            tmpBilling.Update();

                            tmpBillingDetail = BO_BillingDetail.SelectOne( new BO_BillingDetailPrimaryKey( editBillingDetailID ) );
                            tmpBillingDetail.Amount = Convert.ToDecimal( rntbAmount.Text );
                            tmpBillingDetail.TransactionID = txtCheckNum.Text;
                            tmpBillingDetail.CheckDate = rdpCheckDate.SelectedDate;
                            tmpBillingDetail.PivNum = txtPIV.Text;
                            tmpBillingDetail.TypeFee = lstTypeFee.SelectedValue;//rs-06/01/2012 - Update TypeFee in BillingDetail record
                            tmpBillingDetail.Comment = txtComment.Text;
                            tmpBillingDetail.Update();
                        }
                        else
                        {
                            if ( null != tmpItem.Attributes["APPID"] )
                            {
                                BO_Billings tmpBillings = BO_Billing.SelectAllByForeignKeyApplicationID(
                                                    new BO_ApplicationPrimaryKey( Convert.ToDecimal( tmpItem.Attributes["APPID"] ) ) );

                                tmpBilling = tmpBillings[0];

                                //tmpBilling.PopsIntID = editPopsIntID;
                                //tmpBilling.ApplicationID = Convert.ToDecimal( tmpItem.Attributes["APPID"] );
                            }
                            else
                            {
                                tmpBilling = new BO_Billing();
                            }

                            //SMM 01/22/2012 - Removed title case conversion
                            //tmpBilling.BillToName = CommonFunc.ConvertToTitleCase( txtCompanyIndividual.Text );
                            tmpBilling.BillToName = txtCompanyIndividual.Text;
                            tmpBilling.CheckLogPrefix = lstCheckLogPrefix.SelectedValue;
                            tmpBilling.ProgramID = lstCheckLogPrefix.SelectedValue;

                            if ( tmpBilling.BillingID == null )
                            {
                                tmpBilling.PriceModelID = 999;
                                tmpBilling.PopsIntID = editPopsIntID; //rs -05/31/2012 - Add popsIntID
                                tmpBilling.InsertWithDefaultValues( true );
                            }
                            else
                            {
                                tmpBilling.Update();
                            }

                            /*ST - removed per 17428 - charges should not be generated with payment, all payments will be linked to provider billing record
                            //If the entry is for other than application process, then add a charge record to balance payment record
                            if ( !CheckLogFormType.Equals( "APPLICATION" ) )
                            {
                                tmpBillingDetail = new BO_BillingDetail();
                                tmpBillingDetail.BillingID = tmpBilling.BillingID;
                                tmpBillingDetail.TypeFee = lstTypeFee.SelectedValue;
                                tmpBillingDetail.TypeBilling = "2";
                                tmpBillingDetail.PayMode = "2";
                                tmpBillingDetail.Amount = Convert.ToDecimal( rntbAmount.Text );
                                tmpBillingDetail.TransactionDate = DateTime.Now;
                                tmpBillingDetail.InsertWithDefaultValues( false );
                            }
                             * */
                            
                            //Add Payment Record
                            tmpBillingDetail = new BO_BillingDetail();
                            tmpBillingDetail.BillingID = tmpBilling.BillingID;
                            tmpBillingDetail.TypeFee = lstTypeFee.SelectedValue;
                            tmpBillingDetail.TypeBilling = "1";
                            tmpBillingDetail.PayMode = "2";
                            tmpBillingDetail.Amount = Convert.ToDecimal( rntbAmount.Text );
                            tmpBillingDetail.TransactionID = txtCheckNum.Text;
                            tmpBillingDetail.TransactionDate = DateTime.Now;
                            tmpBillingDetail.TransactionStatus = "1";
                            tmpBillingDetail.CheckDate = rdpCheckDate.SelectedDate;
                            tmpBillingDetail.Comment = txtComment.Text;
                            tmpBillingDetail.InsertWithDefaultValues( false );

                        }

                        ClientScript.RegisterStartupScript( Page.GetType(), "key", "CloseAndRebind('key');", true );
                        
                    }
                    break;
            }

        }

        private bool ValidateForm()
        {
            bool success = true;
            ErrorText.InnerHtml = "";
            ErrorText.Visible = false;

            if ( CheckLogFormType.Equals( "APPLICATION" ) && ( txtStateID.Text.Length < 9 || !ProviderFound ) )
            {
                success = false;
                ErrorText.Visible = true;
                ErrorText.InnerHtml += "State ID required<br/>";
            }

            if ( CheckLogFormType.Equals( "OTHER" ) && txtCompanyIndividual.Text.Length < 1 )
            {
                success = false;
                ErrorText.Visible = true;
                ErrorText.InnerHtml += "Company/Individual required<br/>";
            }

            if ( rntbAmount.Text.Length < 1 )
            {
                success = false;
                ErrorText.Visible = true;
                ErrorText.InnerHtml += "Amount required<br/>";
            }

            if ( txtCheckNum.Text.Length < 1 )
            {
                success = false;
                ErrorText.Visible = true;
                ErrorText.InnerHtml += "Check Number required<br/>";
            }

            if ( null == rdpCheckDate.SelectedDate ) //|| rdpCheckDate.SelectedDate.Value.ToShortDateString().Length < 10 )
            {
                success = false;
                ErrorText.Visible = true;
                ErrorText.InnerHtml += "Check Date required<br/>";
            }

            if ( lstCheckLogPrefix.SelectedItem.Text.Length < 1 )
            {
                success = false;
                ErrorText.Visible = true;
                ErrorText.InnerHtml += "Type Provider required<br/>";
            }

            if ( lstTypeFee.SelectedItem.Text.Length < 1 )
            {
                success = false;
                ErrorText.Visible = true;
                ErrorText.InnerHtml += "Reason required<br/>";
            }
            
            return success;
        }

        private bool editMode
        {
            get { return (bool) ViewState["editMode"]; }
            set { ViewState["editMode"] = value; }
        }

        private bool ProviderFound
        {
            get
            {
                return (bool) ViewState["ProviderFound"];
            }
            set
            {
                ViewState["ProviderFound"] = value;
            }
        }
        
        private string CheckLogFormType
        {
            get { return (string) ViewState["CheckLogFormType"]; }
            set { ViewState["CheckLogFormType"] = value; }
        }
        
        private decimal editPopsIntID
        {
            get 
            { 
                if ( null != ViewState["editPopsIntID"] )
                    return Convert.ToDecimal( ViewState["editPopsIntID"].ToString() ); 
                else
                    return 0;
            }
            set 
            {
                ViewState["editPopsIntID"] = value; 
            }
        }

        private decimal editBillingID
        {
            get
            {
                if ( null != ViewState["editBillingID"] )
                    return Convert.ToDecimal( ViewState["editBillingID"].ToString() );
                else
                    return 0;
            }
            set
            {
                ViewState["editBillingID"] = value;
            }
        }
        
        private decimal editBillingDetailID
        {
            get
            {
                if ( null != ViewState["editBillingDetailID"] )
                    return Convert.ToDecimal( ViewState["editBillingDetailID"].ToString() );
                else
                    return 0;
            }
            set
            {
                ViewState["editBillingDetailID"] = value;
            }
        }

        private string editStateID
        {
            get
            {
                if ( null != ViewState["editStateID"] )
                    return (string) ViewState["editStateID"].ToString();
                else
                    return "";
            }
            set
            {
                ViewState["editStateID"] = value;
            }
        }

    }
}
