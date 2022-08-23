using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AppControl;
using ATG.BusinessObject;
using ATG;

namespace Common.EditForm
{
    public partial class AffiliationForm : System.Web.UI.Page
    {
        private AffiliationOffsiteEditForm _m_AffilCtrl = null;
        private decimal tmpAffilID = 0;

        protected override void OnInit( EventArgs e )
        {
            base.OnInit( e );
            _m_AffilCtrl = (AffiliationOffsiteEditForm) LoadControl( "~/AppControl/AffiliationOffsiteEditForm.ascx" );
            _LoadUserControls();

        }
        
        protected void Page_Load( object sender, EventArgs e )
        {
            string tmpID = Request.QueryString["AFID"].ToString();
            string tmpAction = Request.QueryString["TYPE"].ToString();

            if ( !string.IsNullOrEmpty( tmpAction ) )
            {
                if ( tmpAction.Equals( "Edit" ) || tmpAction.Equals( "New" ) )
                {
                    AllowEdit = true;
                    LicReadOnly.Value = "";
                }
                else
                {
                    AllowEdit = false;
                    LicReadOnly.Value = "RO";
                }
            }
            else
            {
                AllowEdit = false;
                LicReadOnly.Value = "RO";
            }

            btnSave.Enabled = AllowEdit;
            btnSaveExit.Enabled = AllowEdit;

            if ( !IsPostBack )
            {
                hidProgramID.Value = CurrentAppProvider.ProgramID;
                _m_AffilCtrl.InitLicenseControls( tmpID, AllowEdit );
            }
        }

        protected void btnSave_Click( object sender, EventArgs e )
        {
            Button tmpCmdBtn = (Button) sender;
            _m_AffilCtrl = (AffiliationOffsiteEditForm) Page.FindControl( "AffiliationControl" );

            if ( null != _m_AffilCtrl )
            {
                switch (tmpCmdBtn.CommandName)
                {
                    case "SaveExit":
                        if ( _m_AffilCtrl.SaveData() )
                            ClientScript.RegisterStartupScript(Page.GetType(), "key", "CloseAndRebind('key');", true); 
                        break;
                    case "Save":
                        _m_AffilCtrl.SaveData();
                        break;
                }
            }
        }

        private void _LoadUserControls()
        {
            AffiliationFormContent.Controls.Add( _m_AffilCtrl );
            _m_AffilCtrl.ID = "AffiliationControl";
            _m_AffilCtrl.Visible = true;
        }

        public bool AllowEdit
        {
            get
            {
                return ( null != ViewState["AllowEdit"] ? (bool) ViewState["AllowEdit"] : false );
            }
            set
            {
                ViewState["AllowEdit"] = value;
            }
        }

        private BO_Application CurrentAppProvider
        {
            get
            {
                return Session["CurrentAppProvider"] == null ? null : (BO_Application) Session["CurrentAppProvider"];
            }
        }
    }
}
