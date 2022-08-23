using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ATG.BusinessObject;

namespace Common.EditForm
{
    public partial class BatchPIVForm : System.Web.UI.Page
    {
        protected void Page_Load( object sender, EventArgs e )
        {

        }

        protected void btnSave_Click( object sender, EventArgs e )
        {
            BO_BillingDetail tmpBO_Dtl = new BO_BillingDetail();

            if ( ValidateForm() )
                tmpBO_Dtl.UpdatePivByBatchID( Convert.ToDecimal( rntbBatchID.Text ), txtPIVNum.Text );
            else
                return;

            ClientScript.RegisterStartupScript( Page.GetType(), "key", "CloseAndRebind('key');", true );
        }

        private bool ValidateForm()
        {
            bool success = true;
            ErrorText.InnerHtml = "";
            ErrorText.Visible = false;

            if ( rntbBatchID.Text.Length < 1 )
            {
                success = false;
                ErrorText.Visible = true;
                ErrorText.InnerHtml += "Batch ID Required<br/>";
            }

            if ( txtPIVNum.Text.Length < 1 )
            {
                success = false;
                ErrorText.Visible = true;
                ErrorText.InnerHtml += "PIV Number required<br/>";
            }

            return success;
        }

    }
}
