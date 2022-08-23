using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using ATG;
using ATG.BusinessObject;
using ATG.Utilities.Data;
using Telerik.Web.UI;

namespace AppControl
{
    public partial class AppAttachment : System.Web.UI.UserControl
    {
        protected void Page_Load( object sender, EventArgs e )
        {
            RadAjaxManager manager = RadAjaxManager.GetCurrent( Page );
            manager.AjaxRequest += new RadAjaxControl.AjaxRequestDelegate( manager_AjaxRequest );
        }

        public void LoadApplication( string inAppID )
        {
            if ( inAppID != null && CurrentAppProvider != null )
            {
                _Init();
            }
        }

        //Stubbed method - no content now left for possible later implementation
        public bool SaveData()
        {
            bool noSaveError = true;

            noSaveError = _DoValidate();

            return noSaveError;
        }

        /// <summary>
        /// Data Validation
        /// </summary>
        /// <returns></returns>
        private bool _DoValidate()
        {
            bool retVal = true;
            string validationErrors = "";

            ErrorText.Visible = false;
            ErrorText.InnerHtml = "";

            /* 
             * TODO: Validation code goes here
             * In case of Validation failure, the following needs to happen:
             * 1) ErrorText.Visible = true;
             * 2) ErrorText.InnerHtml += validationErrors;
             * 3) retVal = false;
             */

            return retVal;
        }

        protected void AttachAction_Click( object sender, EventArgs e )
        {
            string tmpAddQueryString = "";
            string tmpAttachParentType = "APPLICATION";
            LinkButton tmpUpldBtn = (LinkButton) sender;

            string[] commandArgsSent = tmpUpldBtn.CommandArgument.ToString().Split( new char[] { ',' } );

            //This is the add condition
            if ( tmpUpldBtn.CommandName == "Upload" && tmpUpldBtn.Text.Equals( "Attach" ) )
            {
                tmpAddQueryString += "Desc=" + _getAttachFileDesc( Convert.ToDecimal( commandArgsSent[0] ) ) + "&";
                tmpAddQueryString += "ChkID=" + commandArgsSent[0].ToString() + "&";
                tmpAddQueryString += "AttID=" + commandArgsSent[1].ToString() + "&";
                tmpAddQueryString += "Type=" + tmpAttachParentType;


                AttachRadWin.NavigateUrl = "~/Common/FileUpload.aspx?" + tmpAddQueryString;
                AttachRadWin.Height = Unit.Pixel( 125 );
                AttachRadWin.Width = Unit.Pixel( 545 );
                AttachRadWin.Title = "Attach File";
                AttachRadWin.Visible = true;
                AttachRadWin.Modal = true;

            }
            else //Remove condition
            {
                decimal tmpFileAttachID = Convert.ToDecimal( commandArgsSent[1] );

                foreach ( BO_ApplicationItem boAI in CurrentAppProvider.BO_ApplicationItemsApplicationID )
                {
                    if ( boAI.FileAttachID.Equals( tmpFileAttachID ) )
                    {
                        boAI.FileAttachID = null;
                        foreach ( BO_FileAttach boFA in CurrentAppProvider.Attachments )
                        {
                            if ( boFA.FileAttachID.Equals( tmpFileAttachID ) )
                            {
                                boFA.Removed = true;
                                break;
                            }
                        }
                        break;
                    }
                }
                AttachRepeater.DataSource = CurrentAttachDataSource;
                AttachRepeater.DataBind();
            }

        }

        protected void manager_AjaxRequest( object sender, Telerik.Web.UI.AjaxRequestEventArgs e )
        {
            if ( null != e.Argument && e.Argument.Length > 0 )
            {
                AttachRepeater.DataSource = CurrentAttachDataSource;
                AttachRepeater.DataBind();
            }
        }

        protected string getViewLink( string inVal )
        {
            string retVal = "";

            if ( null != inVal && inVal.Length > 0 )
            {
                retVal = "<a href='../../Common/FileViewer.aspx?AttID=" + inVal + "' target='_blank'>View</a>";
            }

            return retVal;
        }

        // return short date string for display
        protected string getDateString(string inVal)
        {
            string retVal = "";
            if (null != inVal && inVal.Trim().Length > 0)
            {
                try
                {
                    retVal = DateTime.Parse(inVal).ToShortDateString();
                }
                catch (Exception ex)
                {
                    retVal = "";
                }
            }
            return retVal;
        }

        private string _getAttachFileDesc( decimal inCheckListItemID )
        {
            string retStr = "";

            foreach ( BO_ChecklistItem boCLI in AppAttachmentItems )
            {
                if ( boCLI.ChecklistItemID.Equals( inCheckListItemID ) )
                {
                    retStr = boCLI.ChecklistUiItemText;
                    break;
                }
            }

            return retStr;
        }

        private void _Init()
        {
            AttachRepeater.DataSource = CurrentAttachDataSource;
            AttachRepeater.DataBind();
        }

        private DataTable _getAttachmentsDataTable()
        {
            DataTable tmpDTbl = new DataTable();
            DataColumn tmpDCol = null;

            tmpDCol = new DataColumn( "CheckListItemID" );
            tmpDTbl.Columns.Add( tmpDCol );
            tmpDCol = new DataColumn( "FileAttachID" );
            tmpDTbl.Columns.Add( tmpDCol );
            tmpDCol = new DataColumn( "CommandArgs" );
            tmpDTbl.Columns.Add( tmpDCol );
            tmpDCol = new DataColumn( "UploadCommandText" );
            tmpDTbl.Columns.Add( tmpDCol );
            tmpDCol = new DataColumn( "ViewCommandText" );
            tmpDTbl.Columns.Add( tmpDCol );
            tmpDCol = new DataColumn( "ShowViewLink" );
            tmpDTbl.Columns.Add( tmpDCol );
            tmpDCol = new DataColumn( "AttachDescription" );
            tmpDTbl.Columns.Add( tmpDCol );
            tmpDCol = new DataColumn( "AttachFileName" );
            tmpDTbl.Columns.Add( tmpDCol );
            tmpDCol = new DataColumn("AddDate");
            tmpDTbl.Columns.Add(tmpDCol);

            return tmpDTbl;
        }

        #region Members
        public bool AllowEdit
        {
            get
            {
                return ( null != ViewState["AllowEdit"] ? (bool) ViewState["AllowEdit"] : false );
            }
            set
            {
                ViewState["AllowEdit"] = value;
            }
        }

        private BO_ChecklistItems AppAttachmentItems
        {
            get
            {
                if ( null == CurrentAppProvider.CheckListItems )
                {
                    CurrentAppProvider.CheckListItems =
                        BO_ChecklistItem.SelectAllByForeignKeyBusinessProcessID(
                                new BO_BusinessProcessePrimaryKey( CurrentAppProvider.BusinessProcessID ) );
                }

                BO_ChecklistItems tmpAppAttachItems = new BO_ChecklistItems();

                if ( null != CurrentAppProvider.CheckListItems )
                {
                    foreach ( BO_ChecklistItem boCLI in CurrentAppProvider.CheckListItems )
                    {
                        if ( boCLI.ChecklistUiItemType.Equals( "ATTACHMENT" )
                             && ( boCLI.Allowedtypes.Contains( CurrentAppProvider.ProgramID )
                                  || boCLI.Allowedtypes == null )
                            )
                        {
                            tmpAppAttachItems.Add( boCLI );
                        }
                    }
                }
                return tmpAppAttachItems;
            }
        }

        private BO_Application CurrentAppProvider
        {
            get
            {
                return Session["CurrentAppProvider"] == null ? null : (BO_Application) Session["CurrentAppProvider"];
            }
            set
            {
                Session["CurrentAppProvider"] = value;
            }
        }

        private DataTable CurrentAttachDataSource
        {
            get
            {
                //DataTable retTable = (DataTable) ViewState["CurrentAttachDataSource"];
                DataTable retTable = null;

                //if ( retTable == null )
                //{
                retTable = _getAttachmentsDataTable();

                if ( null != CurrentAppProvider )
                {
                    foreach ( BO_ChecklistItem boCLI in AppAttachmentItems )
                    {
                        if ( null != boCLI.ChecklistItemID && boCLI.ChecklistItemID > 0 )
                        {
                            DataRow tmpDR = retTable.NewRow();
                            string tmpAttachCmdArgs = "";

                            tmpDR["CheckListItemID"] = boCLI.ChecklistItemID;
                            tmpDR["AttachDescription"] = CommonFunc.ConvertToTitleCase( boCLI.ChecklistUiItemText );
                            tmpDR["UploadCommandText"] = "Attach";
                            tmpDR["ViewCommandText"] = "";
                            tmpDR["ShowViewLink"] = "false";
                            tmpAttachCmdArgs += boCLI.ChecklistItemID.ToString() + ",";

                            foreach ( BO_ApplicationItem boAI in CurrentAppProvider.BO_ApplicationItemsApplicationID )
                            {
                                if ( boAI.ChecklistItemID.Equals( boCLI.ChecklistItemID ) && null != boAI.FileAttachID )
                                {
                                    tmpAttachCmdArgs += boAI.FileAttachID.ToString();
                                    tmpDR["FileAttachID"] = boAI.FileAttachID;
                                    foreach ( BO_FileAttach boFA in CurrentAppProvider.Attachments )
                                    {
                                        if ( boFA.FileAttachID.Equals( boAI.FileAttachID ) )
                                        {
                                            tmpDR["AttachFileName"] = boFA.AttachFilename;
                                            tmpDR["AddDate"] = boFA.AddDate;
                                            break;
                                        }
                                    }
                                    tmpDR["UploadCommandText"] = "Remove";
                                    tmpDR["ViewCommandText"] = "View";
                                    tmpDR["ShowViewLink"] = "true";
                                }
                            }
                            tmpDR["CommandArgs"] = tmpAttachCmdArgs;
                            retTable.Rows.Add( tmpDR );
                        }
                    }
                }
                //}
                return retTable;
            }
            set
            {
                ViewState["CurrentAttachDataSource"] = value;
            }
        }
        #endregion
    }
}