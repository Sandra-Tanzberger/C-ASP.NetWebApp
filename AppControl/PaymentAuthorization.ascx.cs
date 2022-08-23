using ATG;
using ATG.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppControl {
    public partial class PaymentAuthorization : System.Web.UI.UserControl {
        protected void Page_Load(object sender, EventArgs e) {

        }

        public bool ValidateAuthorizationPassword() {
            bool valid = false;
            ErrorText.Visible = true;
            ErrorText.InnerHtml = "Invalid authorization password.";
            if (null != CurrentAppProvider) {
                BO_ProviderLogin providerLogin = BO_ProviderLogin.SelectByLogin(CurrentAppProvider.StateID);
                if ((null != providerLogin)
                    && (ATG.Utilities.Crypto.AES.Equals(txtAuthPassword.Text, providerLogin.AuthKey))
                ) {
                    ErrorText.Visible = false;
                    ErrorText.InnerHtml = "";
                    valid = true;
                }
            }
            return valid;
        }

        private BO_Application CurrentAppProvider {
            get {
                return Session["CurrentAppProvider"] == null ? null : (BO_Application)Session["CurrentAppProvider"];
            }
        }
    }
}