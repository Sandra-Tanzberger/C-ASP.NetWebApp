using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AppControl;
using ATG.BusinessObject;
using ATG;

namespace Common
{
    public partial class LinkAffiliation : System.Web.UI.Page
    {

        protected override void OnInit( EventArgs e )
        {
            base.OnInit( e );
        }
        
        protected void Page_Load( object sender, EventArgs e )
        {
            string tmpID = Request.QueryString["AFID"].ToString();
            string tmpAction = Request.QueryString["TYPE"].ToString();

            if ( !string.IsNullOrEmpty( tmpAction ) && !IsPostBack )
            {
                if ( tmpAction.Equals( "Link" ) )
                {
                    CurrentAffiliationID = tmpID;
                    _LoadAspenProviderOffsites();
                }
            }
            
        }

        private void _LoadAspenProviderOffsites()
        {
            AffiliationRepeater.DataSource = CurrentAffiliationsDataSource;
            AffiliationRepeater.DataBind();
        }

        protected void AffiliationRepeater_ItemDataBound( object sender, RepeaterItemEventArgs e )
        {
            if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem) 
                return;

            HiddenField tmpBranchID = (HiddenField) e.Item.FindControl( "hidBranchID" );
            RadioButton rb = (RadioButton) e.Item.FindControl( "optLink" );
            string script = "SetUniqueRadioButton('AffiliationRepeater.*optLinkOffsite',this)";       
            rb.Attributes.Add("onclick", script);
            rb.Attributes.Add( "value", tmpBranchID.Value );
        }

        protected void btnSave_Click( object sender, EventArgs e )
        {

            bool AffilLinked = false;
            string validationErrors = "";

            ErrorText.Visible = false;
            ErrorText.InnerHtml = "";

            foreach ( BO_Affiliation boAffil in CurrentAppProvider.BO_AffiliationsApplicationID )
            {
                if ( boAffil.UI_TrackID.Equals( CurrentAffiliationID ) )
                {
                    foreach ( RepeaterItem tmpRI in AffiliationRepeater.Items )
                    {
                        RadioButton tmpBtn = (RadioButton) tmpRI.FindControl( "optLink" );

                        if ( null != tmpBtn && tmpBtn.Checked )
                        {
                            BO_MdsdbBranchlinks tmpBLS = BO_MdsdbBranchlink.SelectByField( BO_MdsdbBranchlinkFields.Branchid, Convert.ToDecimal( tmpBtn.Attributes["value"] ) );
                            
                            boAffil.BranchID = tmpBLS[0].Branchid;
                            boAffil.MedicareBranchID = tmpBLS[0].MedicaidCareVendNum;
                            boAffil.FacilityName = tmpBLS[0].Name;
                            boAffil.BO_AddressAffiliationID.Street = tmpBLS[0].Address;
                            boAffil.BO_AddressAffiliationID.City = tmpBLS[0].City;
                            boAffil.BO_AddressAffiliationID.StateCode = tmpBLS[0].State;
                            boAffil.BO_AddressAffiliationID.ZipCode = tmpBLS[0].Zip;

                            AffilLinked = true;
                            break;
                        }
                    }
                }

                if ( AffilLinked )
                {
                    ClientScript.RegisterStartupScript( Page.GetType(), "", "CloseAndRebind('Linked');", true );
                    break;
                }
            }

            if ( !AffilLinked )
            {
                validationErrors += "Aspen Affiliation not selected";
                ErrorText.Visible = true;
                ErrorText.InnerHtml = validationErrors;
            }

        }

        private string CurrentAffiliationID
        {
            get
            {
                return null != ViewState["CurrentAffiliationID"] ? (string) ViewState["CurrentAffiliationID"] : null; 
            }
            set
            {
                ViewState["CurrentAffiliationID"] = value;
            }
        }

        private BO_Provider CurrentProvider
        {
            get
            {
                return Session["CurrentProvider"] == null ? null : (BO_Provider) Session["CurrentProvider"];
            }
        }

        private BO_Application CurrentAppProvider
        {
            get
            {
                return Session["CurrentAppProvider"] == null ? null : (BO_Application) Session["CurrentAppProvider"];
            }
        }

        private DataTable _getAffilGridInitTable()
        {
            DataTable tmpDTbl = new DataTable();
            DataColumn tmpDCol = null;

            tmpDCol = new DataColumn( "BranchID" );
            tmpDTbl.Columns.Add( tmpDCol );
            tmpDCol = new DataColumn( "FacilityName" );
            tmpDTbl.Columns.Add( tmpDCol );
            tmpDCol = new DataColumn( "Address" );
            tmpDTbl.Columns.Add( tmpDCol );
            tmpDCol = new DataColumn( "City" );
            tmpDTbl.Columns.Add( tmpDCol );
            tmpDCol = new DataColumn( "Zip" );
            tmpDTbl.Columns.Add( tmpDCol );
            tmpDCol = new DataColumn( "MCareBranchID" );
            tmpDTbl.Columns.Add( tmpDCol );

            return tmpDTbl;

        }

        private DataTable CurrentAffiliationsDataSource
        {
            get
            {
                DataTable retTable = _getAffilGridInitTable();

                BO_MdsdbBranchlinks tmpAspAffils = BO_MdsdbBranchlink.SelectAllUnlinkedByAspenIntID( CurrentAppProvider.ApplicationID.Value, CurrentProvider.AspenIntID.Value );
             
                if ( null != tmpAspAffils )
                {
                    foreach ( BO_MdsdbBranchlink boMBL in tmpAspAffils )
                    {
                        DataRow tmpDR = retTable.NewRow();

                        tmpDR["BranchID"] = boMBL.Branchid.Value.ToString();
                        tmpDR["FacilityName"] = boMBL.Name;
                        tmpDR["Address"] = boMBL.Address;
                        tmpDR["City"] = boMBL.City;
                        tmpDR["Zip"] = boMBL.Zip;
                        tmpDR["MCareBranchID"] = boMBL.McareID;
                        retTable.Rows.Add( tmpDR );
                    }
                }

                return retTable;
            }
        }
    }
}
