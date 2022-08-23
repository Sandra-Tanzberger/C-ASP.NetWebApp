using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using AppControl;

namespace DHH
{
    public partial class BillingHistoryPage : System.Web.UI.Page
    {
        private BillingHistory _m_Billing_Hist = null;

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            // load the facility control
            LoadControl();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                _m_Billing_Hist.BillingKeyType = Request.QueryString["BillingKeyType"];
                _m_Billing_Hist.BillingKey = Request.QueryString["BillingKey"];
            }
        }

        private void LoadControl()
        {
            _m_Billing_Hist = (BillingHistory)LoadControl("~/AppControl/BillingHistory.ascx");
            _m_Billing_Hist.EnableViewState = true;
            BillingContent.Controls.Add(_m_Billing_Hist);
        }

        protected void btnSaveExit_Click(object sender, EventArgs e)
        {
            Button tmpCmdBtn = (Button)sender;

            if (null != _m_Billing_Hist)
            {
                switch (tmpCmdBtn.CommandName)
                {
                    case "SaveExit":
                        ClientScript.RegisterStartupScript(Page.GetType(), "", "CloseRadWin();", true);
                        break;
                    case "Save":

                        break;
                    case "Exit":
                        ClientScript.RegisterStartupScript(Page.GetType(), "", "CloseRadWin();", true);
                        break;
                }

            }
        }
    }
}
