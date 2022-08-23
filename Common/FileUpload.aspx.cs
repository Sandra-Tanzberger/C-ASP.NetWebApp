using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ATG.BusinessObject;
using Telerik.Web.UI;

namespace POPS.Common
{
    public partial class FileUpload : System.Web.UI.Page
    {
        private string _AttachDesc = "";
        private string _AttachParentType = "";
        private decimal _CheckListItemID = 0;

        protected void Page_Load( object sender, EventArgs e )
        {
            _AttachDesc = Request.QueryString["Desc"];
            _AttachParentType = Request.QueryString["Type"];
            
            if ( _AttachParentType.Equals("APPLICATION") && null != Request.QueryString["ChkID"] && Request.QueryString["ChkID"].Length > 0 )
                _CheckListItemID = Convert.ToDecimal( Request.QueryString["ChkID"] );
        }

        protected void SubmitButton_Click( object sender, EventArgs e )
        {
            if ( RadUpload1.UploadedFiles.Count > 0 )
            {
                BO_FileAttach newFileAttach = _UploadFile();

                if ( _AttachParentType.Equals( "APPLICATION" ) )
                {
                    CurrentAppProvider.Attachments.Add( newFileAttach );
                    foreach ( BO_ApplicationItem boAI in CurrentAppProvider.BO_ApplicationItemsApplicationID )
                    {
                        if ( boAI.ChecklistItemID.Equals( _CheckListItemID ) )
                        {
                            boAI.FileAttachID = newFileAttach.FileAttachID;
                            break;
                        }
                    }
                }
                // Call client method in radwindow page  
                ClientScript.RegisterStartupScript( Page.GetType(), newFileAttach.FileAttachID.ToString(), "CloseAndRebind(" + newFileAttach.FileAttachID.ToString() + ");", true ); 
            }
        }

        protected void CancelButton_Click( object sender, EventArgs e )
        {
            ClientScript.RegisterStartupScript( Page.GetType(), "CloseRadWin", "CloseWin();", true ); 
        }

        private BO_FileAttach _UploadFile()
        {
            BO_FileAttach tmpFileAttach = null;

            if ( RadUpload1.UploadedFiles.Count > 0 )
            {
                UploadedFile file = RadUpload1.UploadedFiles[0];

                byte[] data = new byte[file.ContentLength];
                RadUpload1.UploadedFiles[0].InputStream.Read( data, 0, data.Length );

                tmpFileAttach = new BO_FileAttach();

                FileInfo fileInfo = new FileInfo( file.FileName );

                tmpFileAttach.IsNewRec = true;
                tmpFileAttach.AttachDescription = _AttachDesc.ToUpper();
                tmpFileAttach.AttachFilename = fileInfo.Name;
                tmpFileAttach.ContentType = GetFileContentType( tmpFileAttach.AttachFilename );
                tmpFileAttach.FileSize = data.Length;
                tmpFileAttach.Attachment = data;

                if ( _AttachParentType.Equals( "APPLICATION" ) )
                    tmpFileAttach.AttachSaved = "N";
                else
                    tmpFileAttach.AttachSaved = "Y";

                tmpFileAttach.AttachParentID = CurrentAppProvider.ApplicationID;
                tmpFileAttach.AttachParentIdType = _AttachParentType;

                // set the upload date to today's date
                tmpFileAttach.AddDate = DateTime.Today;

                // Note: This adds a record directly into the DB.
                if ( !string.IsNullOrEmpty( tmpFileAttach.ContentType ) )
                {
                    tmpFileAttach.InsertWithDefaultValues( true );

                    // mark this as NOT new
                    tmpFileAttach.IsNewRec = false;
                }
            }

            return tmpFileAttach;
        }

        private string GetFileContentType( string filename )
        {
            string contentType = string.Empty;

            int indexOfDot = filename.LastIndexOf( "." );

            if ( indexOfDot > 0 )
            {
                ++indexOfDot;

                string ext = filename.Substring( indexOfDot, ( filename.Length - indexOfDot ) );

                if ( !string.IsNullOrEmpty( ext ) )
                {
                    switch ( ext.ToLower().Trim() )
                    {
                        case "txt":
                            contentType = "text/plain";
                            break;

                        case "doc":
                        case "docx":
                            contentType = "application/msword";
                            break;

                        case "pdf":
                            contentType = "application/pdf";
                            break;

                        case "xls":
                        case "xlsx":
                            contentType = "application/ms-excel";
                            break;

                        case "rar":
                            contentType = "application/winrar";
                            break;

                    }
                }
            }

            return contentType;

        }

        private BO_Application CurrentAppProvider
        {
            get
            {
                return Session["CurrentAppProvider"] == null ? null : (BO_Application) Session["CurrentAppProvider"];
            }
        }

    }
}
