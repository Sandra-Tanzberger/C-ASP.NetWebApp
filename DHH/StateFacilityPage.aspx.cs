using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ATG;
using ATG.BusinessObject;
using Telerik.Web.UI;

using AppControl;

namespace DHH
{
    public partial class StateFacilityPage : System.Web.UI.Page
    {
        private Facility m_Facility = null;

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            // load the facility control
            LoadFacilityControl();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                m_Facility.LoadNewProvider();
                if ( ( "HC" ).Contains( CurrentProvider.ProgramID ) )
                {
                    string tmpID = ( (HiddenField) Page.FindControlRecursive( "hidSvcsDivClientID" ) ).Value;
                    FacServicesReadOnly.Value = tmpID;
                }
            }
        }

        protected void btnExit_Click( object sender, EventArgs e )
        {
            CurrentProvider = null;
            ClientScript.RegisterStartupScript( Page.GetType(), "CloseWindowScript", "CloseRadWin();", true ); 
        }

        private void LoadFacilityControl()
        {
            m_Facility = (Facility)LoadControl("~/AppControl/Facility.ascx");
            FacilityContent.Controls.Add(m_Facility);
            m_Facility.ID = "Facility";
        }

        protected void Page_Unload( object sender, EventArgs e )
        {
            // Clear Session Variables
            //Session["CurrentProvider"] = null;
        }

        private BO_Provider CurrentProvider
        {
            get
            {
                return Session["CurrentProvider"] == null ? null : (BO_Provider) Session["CurrentProvider"];
            }
            set
            {
                Session["CurrentProvider"] = value;
            }
        }
    }
}
