using System;
using System.Web;
using System.Web.UI;
using System.Web.Security;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using Telerik.Web.UI;
using ATG;
using ATG.BusinessObject;

namespace Public
{
    public partial class Login : System.Web.UI.Page
    {
        private string userType = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            RadPane navPane = (RadPane) Page.FindControlRecursive( "navigationPane" );
            RadPane cntntPane = (RadPane) Page.FindControlRecursive( "contentPane" );
            RadSplitBar vSplitBar = (RadSplitBar) Page.FindControlRecursive( "VSplitBar" );
            
            navPane.Visible = false;
            cntntPane.BackColor = System.Drawing.Color.SteelBlue;
            vSplitBar.Visible = false;
            
            if ( null != Session["userType"] )
                userType = ((string) Session["userType"]).Equals("") ? null : (string) Session["userType"];

            if ( userType != null && userType.Equals( "Public" ) )
                LoginHeaderText.Text = "Provider Login";
            else if ( userType == null )
            {
                LoginHeaderText.Text = "State User Login";
                LoginState();
            }
            //else if ( userType != null && userType.Equals( "State" ) )
            //    LoginHeaderText.Text = "State User Login";

            LoginID.Focus();

        }

        protected void AuthenticateUser( object sender, CommandEventArgs e )
        {
            if ( userType != null && userType.Equals( "Public" ) )
                LoginProvider();
            else if ( userType != null && userType.Equals( "State" ) )
                LoginState();
            else
                FormsAuthentication.RedirectToLoginPage();
        }

        private void LoginProvider()
        {
            bool tmpUsrAuth = false;
            BO_ProviderLogin tmpPL = BO_ProviderLogin.SelectByLogin( LoginID.Text );

            if ( tmpPL != null )
            {
                tmpUsrAuth = tmpPL.PassStaff.Equals( UserPass.Text );
            }

            if ( tmpUsrAuth )
            {
                BO_Provider tmpProv = BO_Provider.SelectOne( new BO_ProviderPrimaryKey( Convert.ToDecimal( tmpPL.PopsIntID ) ) );
                Session["ProviderPOPSINTID"] = tmpPL.PopsIntID;
                Session["ProviderStateID"] = tmpPL.StateID;
                Session["ProviderProgramID"] = tmpProv.ProgramID;
                Session["CurrentProvider"] = tmpProv;
                
                FormsAuthenticationTicket tkt;
                string cookiestr;
                HttpCookie ck;
                tkt = new FormsAuthenticationTicket( 1,
                                                     LoginID.Text, 
                                                     DateTime.Now,
                                                     DateTime.Now.AddMinutes( 30 ), 
                                                     false, 
                                                     "USERTYPE=PUBLIC" );

                cookiestr = FormsAuthentication.Encrypt( tkt );
                ck = new HttpCookie( FormsAuthentication.FormsCookieName, cookiestr );
                ck.Path = FormsAuthentication.FormsCookiePath;
                
                Response.Cookies.Add( ck );

                string strRedirect;
                strRedirect = Request["ReturnUrl"];
            
                if ( strRedirect == null )
                    strRedirect = "~/default.aspx";
                
                Response.Redirect( strRedirect, true );
            }
            else
            {
                Session["ProviderPOPSINTID"] = "";
                Session["ProviderStateID"] = "";
                Session["ProviderName"] = "";
                Session["ProviderProgramID"] = "";
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        private void LoginState()
        {
            FormsAuthentication.RedirectFromLoginPage( "State", true );
        }

        
    }

}
