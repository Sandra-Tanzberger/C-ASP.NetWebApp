using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ATG.Interface;
using ATG.ErrorLogging;

namespace State
{
    public partial class SessionMonitor : System.Web.UI.Page
    {
        protected void Page_Load( object sender, EventArgs e )
        {
            this.SessionTimer.Interval = 60000;
        }
        protected void SessionTimer_Tick( object sender, EventArgs e )
        {
            // rjc - 11/21/2012 - remove debug-only code - just clutters error log
            String now = System.DateTime.Now.ToString();
            Label1.Text = now;
            Session["LastRefreshed"] = now;

            /*Label1.Text = System.DateTime.Now.ToString();

            if ( StateConfig.getConfigObj().Environment.Debug )
            {
                GenericException.LogToErrorTable( "Refreshed for user - " + (string)Session["UserLoginID"], System.DateTime.Now.ToString() );
            }

            Session["LastRefreshed"] = System.DateTime.Now.ToString();*/
        }
    }
}
