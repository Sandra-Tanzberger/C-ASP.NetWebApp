using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Telerik.Web.UI;
using ATG.BusinessObject;
using ATG.Utilities.Data;
using AppControl;
using ATG;

using System.Reflection;
using System.Reflection.Emit;

namespace DHH
{
    public partial class LoginLetterPrint : System.Web.UI.Page
    {
        #region Member Variables

        #endregion

        protected override void OnInit( EventArgs e )
        {
            base.OnInit( e );
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["LOIID"] != "" && Request.QueryString["LOGINID"] != "")
            {
                decimal loiID = Convert.ToDecimal(Request.QueryString["LOIID"]);
                string loginID = Request.QueryString["LOGINID"];

                BO_LetterOfIntentPrimaryKey bopk = new BO_LetterOfIntentPrimaryKey(loiID);
                BO_LetterOfIntent selLetter = BO_LetterOfIntent.SelectOne(bopk);
                BO_ProviderLoginPrimaryKey boplpk = new BO_ProviderLoginPrimaryKey(selLetter.PopsIntID, loginID);
                BO_ProviderLogin bopl = BO_ProviderLogin.SelectOne(boplpk);

                lblDate.Text = System.DateTime.Today.Date.ToString();
                lblAdministrator.Text = selLetter.AuthAdminName;
                lblFacName.Text = selLetter.Name;
                lblFacStreet.Text = selLetter.MailAddress;
                lblCityStateZip.Text = selLetter.MailCity + ", " + selLetter.MailState + " " + selLetter.MailZip;
                lblStateID.Text = bopl.StateID;
                lblAuthPerson.Text = selLetter.AuthAdminName;
                lblTitle.Text = selLetter.AuthAdminTitle;
                //lblLoginID.Text = bopl.LoginID;
                //lblPwd.Text = bopl.PassStaff;
                //lblAuthPwd.Text = bopl.AuthKey;
                lblPwd.Text = ATG.Utilities.Crypto.AES.DecryptStringFromBytes(bopl.PassStaff);
                lblAuthPwd.Text = ATG.Utilities.Crypto.AES.DecryptStringFromBytes(bopl.AuthKey);
            }

        }
    }
}
