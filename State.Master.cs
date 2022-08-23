using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using ATG;

namespace State
{
    public partial class State : System.Web.UI.MasterPage
    {
        protected void Page_Load( object sender, EventArgs e )
        {
            if ( !IsPostBack )
            {
                // the following session variable is used by the Login page
                Session["userType"] = "State";

                RadSplitter mainSplitter = (RadSplitter) Page.FindControlRecursive( "StateMasterSplitter" );
                int tmpContentHeight = ( null != Session["ContentHeight"] && !Session["ContentHeight"].ToString().Equals( "" ) ) ?
                                    (int) Session["ContentHeight"] :
                                    (int) Application["Default_Height"];

                if ( tmpContentHeight > 0 )
                    mainSplitter.Height = Unit.Pixel( tmpContentHeight );
                else
                    mainSplitter.Height = Unit.Percentage( 100 );
            }
        }
    }
}
