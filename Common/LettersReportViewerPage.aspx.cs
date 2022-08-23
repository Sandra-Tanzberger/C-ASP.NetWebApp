using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AppControl;
using ATG.BusinessObject;

namespace Common
{
    public partial class LettersReportViewerPage : System.Web.UI.Page
    {
        private LettersReportViewer m_Letters = null;

         protected override void OnInit( EventArgs e )
        {
            base.OnInit( e );

            m_Letters = (LettersReportViewer)LoadControl("~/AppControl/LettersReportViewer.ascx");
            LettersReports.Controls.Add(m_Letters);
            m_Letters.ID = "LettersReportViewer";

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            m_Letters.LoadLetters((BO_Letters)Session["LetterQueue"], (bool)Session["PrintLabels"], (bool)Session["PrintCover"]); 
        }

    }
}
