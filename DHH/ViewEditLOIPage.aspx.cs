using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AppControl;

namespace DHH
{
    public partial class ViewEditLOIPage : System.Web.UI.Page
    {
        private ListLetterOfIntentControl _m_ListLOICtrl = null;

        protected override void OnInit( EventArgs e )
        {
            base.OnInit( e );

            _m_ListLOICtrl = (ListLetterOfIntentControl) LoadControl( "~/AppControl/ListLetterOfIntentControl.ascx" );
            LOI_Content.Controls.Add( _m_ListLOICtrl );
            _m_ListLOICtrl.EnableViewState = true;
            _m_ListLOICtrl.Visible = false;
            _m_ListLOICtrl.ID = "ListLOIControl";
            _m_ListLOICtrl.Visible = true;

        }
        protected void Page_Load( object sender, EventArgs e )
        {

        }

        protected void btnSave_Click( object sender, EventArgs e )
        {
            Button tmpCmdBtn = (Button) sender;
            _m_ListLOICtrl = (ListLetterOfIntentControl) LOI_Content.Controls[0]; ;

            switch ( tmpCmdBtn.CommandName )
            {
                case "Save":
                    if ( null != _m_ListLOICtrl )
                    {
                        _m_ListLOICtrl.Save_LOI();
                    }
                    break;
                case "Submit":
                    break;
                case "Close":
                    Session["Type_LOI"] = null;
                    Session["LOI_ID"] = null;
                    ClientScript.RegisterStartupScript( Page.GetType(), "", "CloseRadWin();", true );
                    break;
            }

        }

        //protected override void OnUnload( EventArgs e )
        //{
        //    Session["Type_LOI"] = null;
        //    Session["LOI_ID"] = null;

        //    base.OnUnload( e );

        //}

    }
}
