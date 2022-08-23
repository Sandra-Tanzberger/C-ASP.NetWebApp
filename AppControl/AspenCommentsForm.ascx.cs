using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ATG;
using ATG.BusinessObject;
using ATG.Utilities.RTF;

namespace AppControl
{
    public partial class AspenCommentsForm : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

         //update driver person
        public void LoadAspenComments()
        {
            if (!IsPostBack)
            {
                BO_ProviderPrimaryKey providerPrimaryKey = new BO_ProviderPrimaryKey(CurrentProvider.PopsIntID);
                BO_AspenComments _aspenComments = BO_AspenComment.SelectAllByForeignKeyPopsIntID(providerPrimaryKey);
                BO_AspenComment _aspen_comment = null;

                if (_aspenComments != null)
                {
                    if (_aspenComments.Count != 0)
                    {
                        _aspen_comment = BO_AspenComment.SelectOne(new BO_AspenCommentPrimaryKey(_aspenComments[0].AspenCommentID));
                    }
                }

                if (_aspen_comment != null)
                {
                    if (_aspen_comment.LongText != null)
                    {
                        lblNotesLongText.Text = "Enter notes below to append to existing notes: </br>";
                        lblNotesLongText.Text += RTFUtil.StripRTF(_aspen_comment.LongText.ToString(), "");

                        AspenCommentsID = (decimal)_aspen_comment.AspenCommentID;
                        btnAspenCommentsUpdate.Visible = true;
                    }
                    else
                    {
                        lblNotesLongText.Text = "Enter notes below to append to existing notes: </br>";

                        AspenCommentsID = (decimal)_aspen_comment.AspenCommentID;
                        btnAspenCommentsUpdate.Visible = true;
                    }
                }
                else
                {
                    lblNotesLongText.Text = "Enter notes below: </br>";
                    btnAspenCommentsInsert.Visible = true;
                }
            }
        }

        protected void AspenComments_Update(Object sender, EventArgs e) 
        {
            BO_AspenComment _aspenComment = BO_AspenComment.SelectOne(new BO_AspenCommentPrimaryKey(AspenCommentsID));
            _aspenComment.LongText += DateTime.Now.ToString() + ": " + txtNotesLongText.Text.ToString() + Environment.NewLine;
            _aspenComment.Update();

            Page.ClientScript.RegisterStartupScript(Page.GetType(), "CloseRebindDrivers", "CloseAndRebind();", true); 
        }

        protected void AspenComments_Insert(Object sender, EventArgs e)
        {
            BO_AspenComment _aspenComment = new BO_AspenComment();
            _aspenComment.PopsIntID = CurrentProvider.PopsIntID;
            _aspenComment.LongText = DateTime.Now.ToString() + ": " + txtNotesLongText.Text.ToString() + Environment.NewLine;
            _aspenComment.Insert();
         
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "CloseRebindDrivers", "CloseAndRebind();", true); 

        }

        private BO_Provider CurrentProvider
        {
            get
            {
                return Session["CurrentProvider"] == null ? null : (BO_Provider)Session["CurrentProvider"];
            }
            set
            {
                Session["CurrentProvider"] = value;
            }
        }

        private decimal AspenCommentsID
        {
            get
            {
                return (decimal)ViewState["AspenCommentsID"];
            }

            set
            {
                ViewState["AspenCommentsID"] = value;
            }
        }
    }
}