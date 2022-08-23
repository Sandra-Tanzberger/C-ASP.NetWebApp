using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ATG;
using ATG.BusinessObject;
using AppControl;
using Telerik.Web.UI;

namespace Common.EditForm
{
	public partial class AspenComments : System.Web.UI.Page
	{
        private AspenCommentsForm _aspenComments = null;
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            _aspenComments = (AspenCommentsForm)LoadControl("~/AppControl/AspenCommentsForm.ascx");
            AspenCommentsPanel.Controls.Add(_aspenComments);
            _aspenComments.ID = "AspenCommentsEditForm";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            _aspenComments.LoadAspenComments();
        }
	}
}