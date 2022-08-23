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
using ATG;

namespace AppControl
{
    public partial class ListLetterOfIntentControl : System.Web.UI.UserControl
    {

        private LOIMatchFormControl _m_LOIControl = null;
        private LOIOffsiteAddition _m_LOI_OA_Ctrl = null;
        private LetterOfIntentControl _m_LettterOfIntentCtrl = null;
        private RequestForAccessControl _m_RequestForAccessCtrl = null;
        private LOICertOnlyControl _m_LOICertOnlyCtrl = null;

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            switch ( Session["Type_LOI"].ToString() )
            {
                case "1": //"LOI":
                    _m_LettterOfIntentCtrl = (LetterOfIntentControl) LoadControl( "~/AppControl/LetterOfIntentControl.ascx" );
                    LOIPanel.Controls.Add( _m_LettterOfIntentCtrl );
                    _m_LettterOfIntentCtrl.EnableViewState = true;
                    _m_LettterOfIntentCtrl.ID = "LOI_Ctrl";
                    break;
                case "4": //"LOI Offsite Addition":
                    _m_LOI_OA_Ctrl = (LOIOffsiteAddition) LoadControl( "~/AppControl/LOIOffsiteAddition.ascx" );
                    LOIPanel.Controls.Add( _m_LOI_OA_Ctrl );
                    _m_LOI_OA_Ctrl.EnableViewState = true;
                    _m_LOI_OA_Ctrl.ID = "LOI_OA_Ctrl";
                    break;
                case "2": //"RFA":
                    _m_RequestForAccessCtrl = (RequestForAccessControl) LoadControl( "~/AppControl/RequestForAccessControl.ascx" );
                    LOIPanel.Controls.Add( _m_RequestForAccessCtrl );
                    _m_RequestForAccessCtrl.EnableViewState = true;
                    _m_RequestForAccessCtrl.ID = "RFA_Ctrl";
                    break;
                case "3": //"CER":
                    _m_LOICertOnlyCtrl = (LOICertOnlyControl) LoadControl( "~/AppControl/LOICertOnlyControl.ascx" );
                    LOIPanel.Controls.Add( _m_LOICertOnlyCtrl );
                    _m_LOICertOnlyCtrl.EnableViewState = true;
                    _m_LOICertOnlyCtrl.ID = "CER_Ctrl";
                    break;
                case "Match":
                    _m_LOIControl = (LOIMatchFormControl) LoadControl( "~/AppControl/LOIMatchFormControl.ascx" );
                    LOIPanel.Controls.Add( _m_LOIControl );
                    _m_LOIControl.EnableViewState = true;
                    _m_LOIControl.ID = "Match_Ctrl";
                    break;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if ( null != Session["LOI_ID"] && Session["LOI_ID"].ToString().Length > 0 )
            {
                switch ( Session["Type_LOI"].ToString() )
                {
                    case "1": //"LOI":
                        _m_LettterOfIntentCtrl.Load_LOI( Convert.ToDecimal( Session["LOI_ID"].ToString() ) );
                        break;
                    case "4": //"LOI Offsite Addtion":
                        _m_LOI_OA_Ctrl.Load_LOI_OA( Convert.ToDecimal( Session["LOI_ID"].ToString() ) );
                        break;
                    case "2": //"RFA":
                        _m_RequestForAccessCtrl.Load_RFA( Convert.ToDecimal( Session["LOI_ID"].ToString() ) );
                        break;
                    case "3": //"CER":
                        _m_LOICertOnlyCtrl.Load_LOI( Convert.ToDecimal( Session["LOI_ID"].ToString() ) );
                        break;
                    case "Match":
                        _m_LOICertOnlyCtrl.Load_LOI( Convert.ToDecimal( Session["LOI_ID"].ToString() ) );
                        break;
                }
            }
        }

        public void Save_LOI()
        {
            switch ( Session["Type_LOI"].ToString() )
            {
                case "1": //"LOI":
                    _m_LettterOfIntentCtrl = (LetterOfIntentControl) LOIPanel.Controls[0];
                    _m_LettterOfIntentCtrl.Save();
                    break;
                case "4": //"LOI":
                    _m_LOI_OA_Ctrl = (LOIOffsiteAddition) LOIPanel.Controls[0];
                    _m_LOI_OA_Ctrl.Save();
                    break;
                case "2": //"RFA":
                    _m_RequestForAccessCtrl = (RequestForAccessControl) LOIPanel.Controls[0];
                    _m_RequestForAccessCtrl.Save();
                    break;
                case "3": //"CER":
                    _m_LOICertOnlyCtrl = (LOICertOnlyControl) LOIPanel.Controls[0];
                    _m_LOICertOnlyCtrl.Save();
                    break;
            }
        }


        //protected void grdLOIs_ItemCommand(object source, GridCommandEventArgs e)
        //{
        //    if (e.CommandName == "CustomViewSelected")
        //    {
        //        _m_RequestForAccessCtrl.Visible = false;
        //        _m_LOICertOnlyCtrl.Visible = false;
        //        GridDataItem dataItem = (GridDataItem)grdLOIs.SelectedItems[0];

        //        RadWindow newwindow = new RadWindow();
        //        newwindow.ID = "RadWindow1";
        //        newwindow.NavigateUrl = "/Common/DocPrint.aspx?doc=" + dataItem["DisplayType"].Text + "&ID=" + ((GridDataItem)grdLOIs.SelectedItems[0])["LetterOfIntentID"].Text;  //loiID.ToString();
        //        newwindow.VisibleOnPageLoad = true;
        //        newwindow.Height = 500;
        //        newwindow.Width = 700;
        //        RadWindowManager1.Windows.Add(newwindow);
        //    }
        //    else if (e.CommandName == "CustomMatchSelected")
        //    {
        //        OpenItemInWindow();
        //    }
        //}

        /// <summary>
        /// Can be called from either "View" click or row double click
        /// </summary>
        /// <param name="dataItem"></param>
        //private void OpenItemInWindow()
        //{
        //    // get the currently selected Provider
        //    GridDataItem dataItem = (GridDataItem)grdLOIs.SelectedItems[0];

        //    string loiTrackId = dataItem["LetterOfIntentID"].Text;

        //    // store the TrackID in the session
        //    Session["loiTrackId"] = loiTrackId;

        //    RadWindow newwindow = new RadWindow();
        //    newwindow.ID = "MatchRadWindow1";
        //    newwindow.NavigateUrl = "~/DHH/MatchLOIPage.aspx?loiid=" + loiTrackId;
        //    newwindow.VisibleStatusbar = false;
        //    newwindow.VisibleOnPageLoad = true;
        //    newwindow.Height = Unit.Pixel(525);
        //    newwindow.Width = Unit.Pixel(730);
        //    newwindow.Title = "Match Letter of Intent: " + loiTrackId;
        //    newwindow.InitialBehaviors = WindowBehaviors.Maximize;
        //    RadWindowManager1.Windows.Add(newwindow);
        //    RadWindowManager1.Style.Add("z-index", "9999");
        //}

    }
}