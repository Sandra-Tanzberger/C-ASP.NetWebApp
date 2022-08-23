using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ATG.BusinessObject;
using AppControl;

namespace DHH
{
    public partial class MatchLOIPage : System.Web.UI.Page
    {
        private LOIMatchFormControl _m_LOIControl = null;

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            // load the control
            LoadMatchControl();
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string loiTrackID = Request.QueryString["loiid"];

                if (!string.IsNullOrEmpty(loiTrackID))
                {
                    BO_LetterOfIntent boloi = BO_LetterOfIntent.SelectOne(new BO_LetterOfIntentPrimaryKey(Convert.ToDecimal(loiTrackID)));
                    string loiType = boloi.LetterOfIntentType;
                    string loiFacType = boloi.FacilityType;
                    string loiDispConf = boloi.Confirmed == 1 ? "Yes" : "No";
                    decimal dloiTrackId = Convert.ToDecimal(loiTrackID);

                    _m_LOIControl.loiType = loiType;
                    _m_LOIControl.loiID = dloiTrackId;

                    if (loiDispConf == "Yes")
                    {
                        //_m_LOIControl.ClearFields(true);
                    }
                    else
                    {
                       // _m_LOIControl.ClearFields(false);
                    }

                    _m_LOIControl.facType = loiFacType;
                }
            }
        }


        private void LoadMatchControl()
        {
            _m_LOIControl = (LOIMatchFormControl)LoadControl("~/AppControl/LOIMatchFormControl.ascx");
            _m_LOIControl.EnableViewState = true;
            MatchContent.Controls.Add(_m_LOIControl);
        }

        protected void btnSaveExit_Click(object sender, EventArgs e)
        {
            Button tmpCmdBtn = (Button)sender;

            if (null != _m_LOIControl)
            {
                switch (tmpCmdBtn.CommandName)
                {
                    case "Exit":
                        Session["idreditmode"] = false;
                        ClientScript.RegisterStartupScript(Page.GetType(), "", "CloseRadWin();", true);
                        break;
                }

            }
        }

    }
}
