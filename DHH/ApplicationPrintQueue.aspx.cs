using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ATG;
using ATG.BusinessObject;
using ATG.Utilities.Data;
using ATG.GridHelper;
using ATG.Interface;
using AppControl;

namespace DHH
{
    public partial class ApplicationPrintQueue : System.Web.UI.Page
    {
        private ApplicationPrint _applicationPrint = null;
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            _applicationPrint = (ApplicationPrint)LoadControl("~/AppControl/ApplicationPrint.ascx");
            ApplicationLetters.Controls.Add(_applicationPrint);
            _applicationPrint.ID = "ApplicationPrintLetters";
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //_applicationPrint.LoadLettersGrid(Request.QueryString["PrintKey"].ToString());
            
        }
    }
}
