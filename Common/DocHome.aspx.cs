using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using Telerik.Pdf;
using ATG;
using ATG.BusinessObject;
using AppControl;

namespace Common
{
    public partial class DocHome : System.Web.UI.Page
    {
        private LetterOfIntentControl _m_LettterOfIntentCtrl = null;
        private RequestForAccessControl _m_RequestForAccessCtrl = null;
        private LOICertOnlyControl _m_LOICertOnlyCtrl = null;

        protected override void OnInit( EventArgs e )
        {
            base.OnInit( e );

            //_CurrentDoc = Request.QueryString["doc"];
            //switch ( _CurrentDoc )
            //{
            //    case "loi":
                    _m_LettterOfIntentCtrl = (LetterOfIntentControl) LoadControl( "~/AppControl/LetterOfIntentControl.ascx" );
                    _m_LettterOfIntentCtrl.EnableViewState = true;
                //    break;
                //case "rfa":
                    _m_RequestForAccessCtrl = (RequestForAccessControl) LoadControl( "~/AppControl/RequestForAccessControl.ascx" );
                    _m_RequestForAccessCtrl.EnableViewState = true;
                    //break;
                //case "cer":
                    _m_LOICertOnlyCtrl = (LOICertOnlyControl)LoadControl("~/AppControl/LOICertOnlyControl.ascx");
                    _m_LOICertOnlyCtrl.EnableViewState = true;
                    //break;
                //default:
                //    _CurrentDoc = "loi";
                //    _m_LettterOfIntentCtrl = (LetterOfIntentControl) LoadControl( "~/AppControl/LetterOfIntentControl.ascx" );
                //    _m_LettterOfIntentCtrl.EnableViewState = true;
                //    break;
            //}
            SetUI();
        }

        protected void Page_Load( object sender, EventArgs e )
        {
            if ( CurrentDoc == null )
                CurrentDoc = Request.QueryString["doc"];

            if ( CurrentDoc.Equals( "loi" ) )
            {
                LetterOfIntentControl tmpLOI_ctrl = (LetterOfIntentControl) DocMainPane.FindControlRecursive( "LetterOfIntent" );

                if ( null != tmpLOI_ctrl )
                    _m_LettterOfIntentCtrl = tmpLOI_ctrl;

                _m_LettterOfIntentCtrl.printMode = false;
                LoadMyUserControl( "LetterOfIntent", _m_LettterOfIntentCtrl, DocMainPane );
            }
            else if (CurrentDoc.Equals("rfa"))
            {
                RequestForAccessControl tmpRFA_ctrl = (RequestForAccessControl)DocMainPane.FindControlRecursive("RequestForAccess");

                if (null != tmpRFA_ctrl)
                    _m_RequestForAccessCtrl = tmpRFA_ctrl;

                _m_RequestForAccessCtrl.printMode = false;
                LoadMyUserControl("RequestForAccess", _m_RequestForAccessCtrl, DocMainPane);
            }
            else
            {
                LOICertOnlyControl tmpCER_ctrl = (LOICertOnlyControl)DocMainPane.FindControlRecursive("CertifiedOnly");

                if (null != tmpCER_ctrl)
                    _m_LOICertOnlyCtrl = tmpCER_ctrl;

                _m_LOICertOnlyCtrl.printMode = false;
                LoadMyUserControl("CertifiedOnly", _m_LOICertOnlyCtrl, DocMainPane);
            }
            
            SetUI();
        }

        private void LoadMyUserControl( string CtrlName, Control CtrlToLoad, Control parent )
        {
            parent.Controls.Clear();
            parent.Controls.Add( CtrlToLoad );
            CtrlToLoad.ID = CtrlName;
        }

        protected void SearchButton_Click( object sender, EventArgs e )
        {
            TextBox tbSrchVal = ((TextBox) MenuPanelBar.FindControlRecursive("txtSearchVal"));
            Label lbNotFound = ((Label) MenuPanelBar.FindControlRecursive("lblNotFound"));

            try
            {
                int.Parse( tbSrchVal.Text );
                int tmpLoiID = Convert.ToInt32( tbSrchVal.Text );
                lbNotFound.Visible = false;
                MenuPanelBar.Height = Unit.Pixel( 80 );

                if ( tmpLoiID > 0 )
                {
                    BO_LetterOfIntent tmpLetIntent = BO_LetterOfIntent.SelectOne( new BO_LetterOfIntentPrimaryKey( tmpLoiID ) );

                    if ( null != tmpLetIntent )
                    {
                        if ( CurrentDoc.Equals( "loi" ) )
                        {
                            _m_LettterOfIntentCtrl.Load_LOI( tmpLoiID );
                            LoadMyUserControl( "LetterOfIntent", _m_LettterOfIntentCtrl, DocMainPane );
                            SetUI();
                        }
                        else if ( CurrentDoc.Equals( "rfa" ) )
                        {
                            _m_RequestForAccessCtrl.Load_RFA( tmpLoiID );
                            LoadMyUserControl( "RequestForAccess", _m_RequestForAccessCtrl, DocMainPane );
                            SetUI();
                        }
                        else if (CurrentDoc.Equals("cer"))
                        {
                            _m_LOICertOnlyCtrl.Load_LOI(tmpLoiID);
                            LoadMyUserControl("CertifiedOnly", _m_LOICertOnlyCtrl, DocMainPane);
                            SetUI();
                        }
                    }
                    else
                    {
                        if ( CurrentDoc.Equals( "loi" ) )
                        {
                            _m_LettterOfIntentCtrl.Reset_LOI();
                            LoadMyUserControl( "LetterOfIntent", _m_LettterOfIntentCtrl, DocMainPane );
                            MenuPanelBar.Height = Unit.Pixel( 100 );
                            lbNotFound.Text = "*No Matching Record found";
                            lbNotFound.Visible = true;
                        }
                        else if ( CurrentDoc.Equals( "rfa" ) )
                        {
                            _m_RequestForAccessCtrl.Reset_LOI();
                            LoadMyUserControl( "RequestForAccess", _m_RequestForAccessCtrl, DocMainPane );
                            MenuPanelBar.Height = Unit.Pixel( 100 );
                            lbNotFound.Text = "*No Matching Record found";
                            lbNotFound.Visible = true;
                        }
                        else if (CurrentDoc.Equals("cer"))
                        {
                            _m_LOICertOnlyCtrl.Reset_LOI();
                            LoadMyUserControl("CertifiedOnly", _m_LOICertOnlyCtrl, DocMainPane);
                            MenuPanelBar.Height = Unit.Pixel(100);
                            lbNotFound.Text = "*No Matching Record found";
                            lbNotFound.Visible = true;
                        }
                    }
                }
            }
            catch ( Exception ex )
            {
                MenuPanelBar.Height = Unit.Pixel( 100 );
                lbNotFound.Text = "*Invalid Tracking ID";
                lbNotFound.Visible = true;
            }
        }

        protected void DocNavMenu_ItemClick( object sender, EventArgs e )
        {
            string action = ( (RadMenuEventArgs) e ).Item.Value;

            if ( CurrentDoc.Equals( "loi" ) )
            {
                _m_LettterOfIntentCtrl = (LetterOfIntentControl) Page.FindControlRecursive( "LetterOfIntent" );
                if ( action.Equals( "Print" ) )
                {
                    if (_m_LettterOfIntentCtrl.Save())
                        ScriptManager.RegisterStartupScript( this, typeof( string ), "OPEN_WINDOW", "window.open( 'DocPrint.aspx?doc=LOI&ID=" + _m_LettterOfIntentCtrl.m_LOI.LetterOfIntentID + "', null, 'height=700,width=800,status=no,toolbar=no,menubar=no,location=no, scrollbars=yes' );", true );
                }
            }
            else if ( CurrentDoc.Equals( "rfa" ) )
            {
                _m_RequestForAccessCtrl = (RequestForAccessControl) Page.FindControlRecursive( "RequestForAccess" );
                if ( action.Equals( "Print" ) )
                {
                    if (_m_RequestForAccessCtrl.Save())
                        ScriptManager.RegisterStartupScript( this, typeof( string ), "OPEN_WINDOW", "window.open( 'DocPrint.aspx?doc=RFA&ID=" + _m_RequestForAccessCtrl.m_LOI.LetterOfIntentID + "', null, 'height=700,width=800,status=no,toolbar=no,menubar=no,location=no, scrollbars=yes' );", true );
                }
            }
            else if (CurrentDoc.Equals("cer"))
            {
                _m_LOICertOnlyCtrl = (LOICertOnlyControl)Page.FindControlRecursive("CertifiedOnly");
                if (action.Equals("Print"))
                {
                    if (_m_LOICertOnlyCtrl.Save())
                        ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "window.open( 'DocPrint.aspx?doc=CER&ID=" + _m_LOICertOnlyCtrl.m_LOI.LetterOfIntentID + "', null, 'height=700,width=800,status=no,toolbar=no,menubar=no,location=no, scrollbars=yes' );", true);
                }
            }

        }

        private void SetUI()
        {
            //int ContentHeight = (int) DocSplitter.Height.Value;
            int ContentHeight = ( null != Session["ContentHeight"] && !Session["ContentHeight"].ToString().Equals( "" ) ) ?
                                (int) Session["ContentHeight"] :
                                (int) Application["Default_Height"];
            int ContentWidth = (int) DocSplitter.Width.Value;
            int DocNavMenuHeight = (int) DocNavMenu.Height.Value;

            ContentHeight = ContentHeight < 400 ? 400 : ContentHeight;

            DocMainPane.Height = Unit.Pixel( ContentHeight - DocNavMenuHeight - 8 );
            DocDetailPane.Height = Unit.Pixel( DocNavMenuHeight );
            DocSplitBar.Visible = true;
            DocSplitBar.CollapseMode = SplitBarCollapseMode.None;
            DocSplitBar.EnableResize = false;
            DocNavMenu.Visible = true;
        }

        private string CurrentDoc
        {
            get
            {
                return (string) ViewState["CurrentDoc"];
            }
            set
            {
                ViewState["CurrentDoc"] = value;
            }
        }

    }
}
