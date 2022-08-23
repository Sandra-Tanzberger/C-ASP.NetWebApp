using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AppControl;

namespace Common
{
    public partial class DocPrint : System.Web.UI.Page
    {
        protected void Page_Load( object sender, EventArgs e )
        {
            if ( Request.QueryString["doc"].Equals( "LOI" ) )
            {

                LetterOfIntentControl tmpLOI = (LetterOfIntentControl) LoadControl( "~/AppControl/LetterOfIntentControl.ascx" );
                tmpLOI.printMode = true ;
                tmpLOI.Load_LOI( Convert.ToDecimal(Request.QueryString["ID"]) );
                LoadMyUserControl( "LetterOfIntent",
                                    tmpLOI,
                                    DocPrintPanel );
            }
            else if ( Request.QueryString["doc"].Equals( "RFA" ) )
            {

                RequestForAccessControl tmpRFA = (RequestForAccessControl) LoadControl( "~/AppControl/RequestForAccessControl.ascx" );
                tmpRFA.printMode = true;
                tmpRFA.Load_RFA( Convert.ToDecimal( Request.QueryString["ID"] ) );
                LoadMyUserControl( "RequestForAccess",
                                    tmpRFA,
                                    DocPrintPanel );
            }
            else if (Request.QueryString["doc"].Equals("CER"))
            {

                LOICertOnlyControl tmpCER = (LOICertOnlyControl)LoadControl("~/AppControl/LOICertOnlyControl.ascx");
                tmpCER.printMode = true;
                tmpCER.Load_LOI(Convert.ToDecimal(Request.QueryString["ID"]));
                LoadMyUserControl("CertifiedOnly",
                                    tmpCER,
                                    DocPrintPanel);
            }
        }

        private void LoadMyUserControl( string CtrlName, Control CtrlToLoad, Control parent )
        {
            parent.Controls.Clear();
            parent.Controls.Add( CtrlToLoad );
            CtrlToLoad.ID = CtrlName;
        }
    }
}
