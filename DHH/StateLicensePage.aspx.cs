using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ATG;
using ATG.BusinessObject;
using AppControl;
using Telerik.Web.UI;

namespace DHH
{
    public partial class StateLicensePage : System.Web.UI.Page
    {
        private License m_License = null;

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            // load the license control
            LoadLicenseControl();

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (m_License != null)
                {
                    string appId = (string)Session["LicenseApplicationId"];
                    BO_Application tmpBOApp = BO_Application.SelectOne( new BO_ApplicationPrimaryKey( Convert.ToDecimal( appId ) ) );
                    decimal tmpPopsIntID = 0;
                    AllowEdit = false;

                    if ( null != tmpBOApp )
                    {
                        tmpPopsIntID = tmpBOApp.PopsIntID.Value;
                        
                      
                        //On the state side only enable save for dhh-working and dhh-pending records
                        if ( ( "2,3" ).Contains( tmpBOApp.ApplicationAction ) && !User.IsReadOnly() )
                        {
                            btnSave.Enabled = true;
                            btnSaveExit.Enabled = true;
                        }
                    }

                    //SMM 03/29/2011 - In addition to the application we will also need the current provider record
                    BO_Provider tmpPrvdr = 
                        BO_Provider.SelectOne( new BO_ProviderPrimaryKey( tmpPopsIntID ) );

                    Session["CurrentProvider"] = tmpPrvdr;

                    hidProgramID.Value = tmpPrvdr.ProgramID;

                    if (User.IsReadOnly())
                    {
                        AllowEdit = false;
                        LicReadOnly.Value = "RO";
                    }
                    else if (null != tmpBOApp && (tmpBOApp.ApplicationAction.Equals("4") || tmpBOApp.BusinessProcessID.Equals("1")))
                    {
                        AllowEdit = false;
                        LicReadOnly.Value = "RO";
                    }
                    else
                    {
                        AllowEdit = true;
                        LicReadOnly.Value = "";
                    }

                    m_License.InitLicenseControls( appId, AllowEdit );

                    if ( ( "HC" ).Contains( tmpPrvdr.ProgramID ) )
                    {
                        string tmpIDs = ( (HiddenField) Page.FindControlRecursive( "hidGroupStateClientIDs" ) ).Value;
                        GroupStateIDs.Value = tmpIDs;
                    }
                }
            }
        }

        protected void Page_Unload(object sender, EventArgs e)
        {
            // Clear Session Variables
            Session["LicenseApplicationId"] = null;
            //Session["CurrentProvider"] = null;
        }

        private void LoadLicenseControl()
        {
            m_License = (License)LoadControl("~/AppControl/License.ascx");
            LicenseContent.Controls.Add( m_License );
            m_License.ID = "License";
        }

        protected void btnSave_Click( object sender, EventArgs e )
        {
            Button tmpCmdBtn = (Button) sender;
            m_License = (License) Page.FindControl( "License" );

            if ( null != m_License )
            {
                bool SaveSuccess = false;
                
                switch ( tmpCmdBtn.CommandName )
                {
                    case "SaveExit":
                        SaveSuccess = m_License.Save();
                        if ( SaveSuccess )
                            //ClientScript.RegisterStartupScript( Page.GetType(), "", "CloseRadWin();", true );
                            // Call client method in radwindow page  
                            ClientScript.RegisterStartupScript( Page.GetType(), "CloseRebindScript", "CloseAndRebind();", true ); 
                        break;
                    case "Save":
                        SaveSuccess = m_License.Save();
                        break;
                    case "Exit":
                        SaveSuccess = true;
                        ClientScript.RegisterStartupScript( Page.GetType(), "", "CloseRadWin();", true ); 
                        break;
                }

            }
        }

        private new ATG.Security.User User
        {
            get { return (ATG.Security.User)Session["User"]; }
        }

        private void SetReadOnly(ControlCollection controlsCol)
        {
            foreach (Control control in controlsCol)
            {
                if (control is TextBox)
                    ((TextBox)control).Enabled = false;
                else if (control is Button)
                    ((Button)control).Enabled = false;
                else if (control is RadioButton)
                    ((RadioButton)control).Enabled = false;
                else if (control is ImageButton)
                    ((ImageButton)control).Enabled = false;
                else if (control is CheckBox)
                    ((CheckBox)control).Enabled = false;
                else if (control is DropDownList)
                    ((DropDownList)control).Enabled = false;
                else if (control is HyperLink)
                    ((HyperLink)control).Enabled = false;
                else if (control is RadDatePicker)
                    ((RadDatePicker)control).Enabled = false;

                SetReadOnly(control.Controls);
            }
        }

        //Current Application Object with all associated child record collections and it is stored in
        //the session. All operations in child controls use this object 
        private BO_Application CurrentAppProvider
        {
            get
            {
                return (BO_Application) Session["CurrentAppProvider"];
            }
            set
            {
                Session["CurrentAppProvider"] = value;
            }
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
    }
}
