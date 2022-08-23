using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ATG.BusinessObject;

namespace POPS.Common
{
    public partial class FileViewer : System.Web.UI.Page
    {
        private decimal _FileAttachID = 0;

        protected void Page_Load( object sender, EventArgs e )
        {
            _FileAttachID = Convert.ToDecimal( Request.QueryString["AttID"] );

            if ( _FileAttachID > 0 )
            {
                BO_FileAttach boFA = BO_FileAttach.SelectOne( new BO_FileAttachPrimaryKey( _FileAttachID ) );

                if ( boFA != null )
                {
                    Response.Buffer = true;
                    //Response.OutputStream.Write(buffer)
                    Response.ContentType = boFA.ContentType;
                    Response.AddHeader("content-transfer-encoding", "binary");
                    Response.AddHeader("content-disposition", string.Format("attachment;filename={0}", boFA.AttachFilename));

                    Response.BinaryWrite( boFA.Attachment );
                }
            }

            ClientScript.RegisterStartupScript( Page.GetType(), "CloseRadWin", "CloseWin();", true );
        }
    }
}
