using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ATG.BusinessObject;
using System.Data;
using Telerik.Web.UI;
using ATG.Database;
using ATG.Utilities.RTF;

namespace AppControl
{
    public partial class FacilityAS400Comments : System.Web.UI.UserControl
    {
        private decimal _pops_int_id;

        protected void Page_Load(object sender, EventArgs e)
        {
            // do nothing
        }

        /// <summary>
        /// Set the values of the input controls
        /// </summary>
        private void InitFields()
        {
            // load the AS400 Comments
            LoadAS400Comments();

            // load the Aspen Notes
            LoadAspenComments();
        }

        /// <summary>
        /// Get comments from ASPEN
        /// </summary>
        private void LoadAspenComments()
        {
            System.Text.StringBuilder sbComments = new System.Text.StringBuilder();
            sbComments.Append("");

            // get the currently selected Provider from the Session
            //string aspenIntID = (string)Session["AspenIntID"];
            if (!string.IsNullOrEmpty(_pops_int_id.ToString()))
            {
                BO_AspenComments boAspenComments = BO_AspenComment.SelectByField("POPS_INT_ID",_pops_int_id.ToString());
                if (boAspenComments.Count != 0)
                {
                    sbComments.Append(boAspenComments[0].LongText);
                }
            }
            // Use the StripRTF utility to strip out RTF formatting
            // Note: pass in an empty string instead of "\r\n"
            textBoxAspenNotes.Text = RTFUtil.StripRTF(sbComments.ToString(), "");
        }

        /// <summary>
        /// Populate the comments pulled in from AS400
        /// </summary>
        private void LoadAS400Comments()
        {
            System.Text.StringBuilder sbComments = new System.Text.StringBuilder();
            sbComments.Append("");

            // get the currently selected Provider from the Session
            string providerPOPSINTID = (string)Session["ProviderPOPSINTID"];
            if (!string.IsNullOrEmpty(providerPOPSINTID))
            {
                BO_ProviderPrimaryKey boProviderPrimaryKey = null;
                try
                {
                    boProviderPrimaryKey = new BO_ProviderPrimaryKey(Convert.ToDecimal(providerPOPSINTID));
                }
                catch (Exception ex)
                {
                    boProviderPrimaryKey = null;
                }
                if (boProviderPrimaryKey != null)
                {
                    BO_Comments boComments = BO_Comment.SelectAllByForeignKeyPopsIntID(boProviderPrimaryKey);
                    if (boComments != null)
                    {
                        foreach (BO_Comment boComment in boComments)
                        {
                            sbComments.Append(boComment.CommentText);
                            sbComments.Append("\n");
                        }
                    }
                }
            }
            textBoxAS400Comments.Text = sbComments.ToString();
        }

        protected void OnClick_UpdateAspenCommments(object sender, EventArgs e)
        {
            RadWinAspenComments.NavigateUrl = "~/Common/EditForm/AspenComments.aspx?";
            RadWinAspenComments.VisibleStatusbar = false;
            RadWinAspenComments.VisibleOnPageLoad = true;
            RadWinAspenComments.Height = Unit.Pixel(600);
            RadWinAspenComments.Width = Unit.Pixel(800);
            //RadWinAspenComments.Behaviors = WindowBehaviors.None; 

            RadWinAspenComments.Modal = true;
            RadWinAspenComments.VisibleOnPageLoad = true;
            RadWinAspenComments.Height = Unit.Pixel(525);
            RadWinAspenComments.Width = Unit.Pixel(730);
            RadWinAspenComments.Title = "Add/Update Aspen Comments";
            RadWindowManagerAspenComments.Style.Add("z-index", "9999");
        }

        /// <summary>
        /// Reload the fields with the current provider
        /// </summary>
        /// 
        public void LoadNewProvider(decimal pop_int_id)
        {
            _pops_int_id = pop_int_id;
            // Set the values of the input controls
            InitFields();
        }
        public void LoadNewProvider()
        {
            // Set the values of the input controls
            InitFields();
        }

    }
}