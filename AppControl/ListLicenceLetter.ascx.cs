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
    public partial class ListLicenceLetter : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            _InitializeGrid("Letter", menuOpt);
            if (!IsPostBack)
            {
                grdLetters.DataBind();
            }
        }

        public void Load_Letters()
        {
            _InitializeGrid("Letter", menuOpt);
        }

        private void _InitializeGrid(String inGridType, string menuOpt)
        {
            switch (inGridType)
            {
                case "Letter":

                    if (menuOpt == "")
                    {
                        grdLetterDataSource.SelectParameters["WhereText"].DefaultValue = "4";
                    }
                    else
                    {
                        grdLetterDataSource.SelectParameters["WhereText"].DefaultValue = "99";
                    }

                    break;
                default:
                    break;
            }

            grdLetters.AllowFilteringByColumn = true;
            grdLetters.AutoGenerateColumns = false;
            grdLetters.AllowPaging = true;
            grdLetters.AllowSorting = true;
            grdLetters.GridLines = GridLines.None;
            grdLetters.ClientSettings.Selecting.AllowRowSelect = true;
            grdLetters.ClientSettings.EnablePostBackOnRowClick = true;
            grdLetters.ClientSettings.Scrolling.AllowScroll = true;
            grdLetters.ClientSettings.Scrolling.UseStaticHeaders = true;
            grdLetters.PagerStyle.HorizontalAlign = HorizontalAlign.Left;
            grdLetters.PagerStyle.Mode = GridPagerMode.NextPrev;
            grdLetters.PagerStyle.Position = GridPagerPosition.Top;
            grdLetters.PagerStyle.VerticalAlign = VerticalAlign.Top;
            grdLetters.PagerStyle.Wrap = true;
            grdLetters.PagerStyle.AlwaysVisible = true;
            grdLetters.PagerStyle.BorderStyle = BorderStyle.None;
        }

        protected void grdLetters_ItemCommand(object source, GridCommandEventArgs e)
         {
            if (e.CommandName == "CustomPrint")
            {
                //Print selected rows using MessagesChecked collection
                Session["MessagesChecked"] = MessagesChecked;

                RadWindow newwindow = new RadWindow();
                newwindow.ID = "RadWindow1";
                newwindow.NavigateUrl = "~/DHH/LettersPrint.aspx"; 
                newwindow.VisibleOnPageLoad = true;
                newwindow.Height = 500;
                newwindow.Width = 700;
                RadWindowManager1.Windows.Add(newwindow);
            }

            if (e.CommandName == "CustomReSend")
            {
                //Reset selected messages to "Pending" to resend the email.
                foreach (string msgid in MessagesChecked.Keys)
                {
                    object isChecked = null;
                    isChecked = MessagesChecked[msgid];

                    //Is message checked to be printed?
                    if (isChecked != null)
                    {
                        if ((bool)isChecked == true)
                        {
                            //Get message and address data and build html
                            BO_MessagePrimaryKey bomkey = new BO_MessagePrimaryKey(Convert.ToDecimal(msgid));
                            BO_Message bom = BO_Message.SelectOne(bomkey);

                            // Only resend outgoing electronic message types                           
                            if (bom.MessageSendType == "2" && bom.MessageDirection == "2")
                            {
                                bom.MessageDeliveryStatus = "1";
                                bom.MessageFailureCode = null;
                                bom.Update();
                            }
                        }
                    }
                }
                grdLetters.Rebind();
            }

            if (e.CommandName == "RowClick")
            {
                if (e.Item is GridDataItem)
                {
                    GridDataItem item = e.Item as GridDataItem;
                    System.Collections.Hashtable target = null;

                    target = MessagesChecked;

                    if (item.Selected)
                    {
                        target[item["MESSAGE_ID"].Text] = true;
                        if (item["SEND_TYPE"].Text == "P")
                        {
                            int temp = numPhysicalSelected;
                            temp = temp + 1;
                            numPhysicalSelected = temp;
                        }
                    }
                    else
                    {
                        target[item["MESSAGE_ID"].Text] = null;
                        if (item["SEND_TYPE"].Text == "P")
                        {
                            int temp = numPhysicalSelected;
                            temp = temp - 1;
                            numPhysicalSelected = temp;
                        }
                    }
                }
            }
         }

        protected void grdLetters_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSelection(true);
        }

        protected void grdLetters_PreRender(object sender, EventArgs e)
        {
            int ContentHeight = (null != Session["ContentHeight"] && !Session["ContentHeight"].ToString().Equals("")) ?
                                (int)Session["ContentHeight"] :
                                (int)Application["Default_Height"];

            grdLetters.Height = Unit.Pixel(ContentHeight-10);

            foreach (GridHeaderItem header in grdLetters.MasterTableView.GetItems(GridItemType.Header))
            {
                CheckBox chkbx = (CheckBox)header["CheckboxSelectColumn"].Controls[0];
                chkbx.Visible = false;
            } 

            foreach (GridDataItem item in grdLetters.Items)
            {
                object isChecked = null;

                isChecked = MessagesChecked[item["MESSAGE_ID"].Text];

                if (isChecked != null)
                {
                    item.Selected = (bool)isChecked == true;
                }
                else
                    item.Selected = false;
            }

            if (grdLetters.MasterTableView.Items.Count > 0)
            {
                GridItem gitm = grdLetters.MasterTableView.GetItems(GridItemType.CommandItem)[0];
                LinkButton btn = (LinkButton)gitm.FindControl("btnResend");
                if (numPhysicalSelected > 0)
                {
                    btn.Enabled = false;
                }
                else
                {
                    btn.Enabled = true;
                }
            }
        }

        private void LoadSelection(bool makeVis)
        {

        }

        private System.Collections.Hashtable MessagesChecked
        {
           
            get
            {
                object res = ViewState["_mc"];
                if (res == null)
                {
                    res = new System.Collections.Hashtable();
                    ViewState["_mc"] = res;
                }

                return (System.Collections.Hashtable)res;
            }
        }

        public string menuOpt
        {
            get
            {
                if (ViewState["menuOpt"] != null)
                    return ViewState["menuOpt"].ToString();
                else
                    return "";
            }
            set
            {
                ViewState["menuOpt"] = value;
            }
        }

        private int numPhysicalSelected
        {
            get
            {
                return this.ViewState["numPhysicalSelected"] == null ? 0 : (int)this.ViewState["numPhysicalSelected"];
            }
            set
            {
                this.ViewState["numPhysicalSelected"] = value;
            }
        }
    }
}